Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine


Public Class frmCaisseImpression
    Dim myConn, myConn2, myConn3, myLabConn As New MySqlConnection
    Dim Comd, Comd2, Comd3, LabCmd As MySqlCommand
    Dim PrescReader, LabReader, PrescReader2, PrescReader3 As MySqlDataReader
    Dim TotalSelect As Integer
    Dim ConnMode As String
    Public Encounter As ULong
    Dim billnum As String
    Dim totalbillamount As Double
    Dim totalreceiptamount As Double
    Dim amountdue As Double
    Public user As String
    Dim Testbill As String
    Dim Agentdefacturation As String
    Dim Montantverse As Double
    Dim Typepaiement As String
    Public OutSide As Boolean = False

    Dim Qry, qry2, qry3, assure, Enc_Date, Enc_type, Patient_Name, Patient_Birth, EncounterType, FirmName, ContactName, PatientRelation, PatientQuality As String
    Dim dtaAdapter As New MySqlDataAdapter
    Dim dtaDataTable As New DataTable
    Dim bindSource As New BindingSource
    Dim DB As New MySQLDataBaseAccess(frmMain.ServerString)
    Dim BonCfg, EncounterPercent, Exclusion As Integer
    Dim newListRow As DataRow
    Private rpt As New facture


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        txtTotalPay.Text = 0
        txtTotalToPay.Text = 0
        TotalSelect = 0
        If OutSide = True Then

        Else
            Encounter = GetPatientInformation(txtId, txtInfos)
        End If
        GetBilledItems()

    End Sub
    Private Sub GetBilledItems()


        'dtaDataTable.DataSet.Clear()
        bindSource.DataSource = Nothing

        If String.IsNullOrEmpty(txtId.Text) Then
            MsgBox("Vous devez saisir le numero du patient", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
            txtId.Focus()
            txtId.Clear()
            Exit Sub
        End If
        If Not IsNumeric(txtId.Text) Then
            MsgBox("Vous devez saisir le numero du patient", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
            txtId.Focus()
            Exit Sub
        End If
        If (Integer.Parse(txtId.Text) >= 10000000) Then
            Try

                'Get the encounter number, encounter date, config bon, encounter_type of the patient
                myConn.Close()
                myConn.Open()
                qry = "SELECT encounter_date, boncfg, encounter_type, contact_name  FROM caredb.care_encounter WHERE pid=" & CULng(txtId.Text) & _
                    " ORDER BY encounter_date DESC" 'LIMIT 1" 'ABS(DATEDIFF(NOW(), encounter_date)) ASC" 'AND is_discharged=0"
                Comd = New MySqlCommand(qry, myConn)
                'Get the encounter number
                PrescReader = Comd.ExecuteReader


                If PrescReader.HasRows Then
                    PrescReader.Read()
                    'Encounter = PrescReader.Item("encounter_nr")
                    BonCfg = PrescReader.Item("boncfg")
                    Enc_Date = PrescReader.Item("encounter_date")
                    Enc_type = PrescReader.Item("encounter_type")
                    assure = PrescReader.Item("contact_name")
                    myConn.Close()
                Else
                    MsgBox("Non Inscrit")
                    Exit Sub
                End If

                'je recherche les facture de la rencontre
                'Get the prescriptions for that encounter

                DB.AddParams("@encounter", Encounter)
                Qry = "SELECT encounter_nr AS no,bill_no,date,agent FROM `care_billing_bill` WHERE encounter_nr IN (SELECT encounter_nr FROM care_encounter WHERE pid=" & CLng(txtId.Text) & ") ORDER BY bill_no DESC, date DESC" ' LIMIT 1"
                RefreshGrid(DB, dgvListeFactures, Qry)
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                myConn.Dispose()
            End Try
        Else
            MsgBox("Vous devez saisir un numero de patient valide a 8 chiffres.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
            txtId.Focus()
            txtId.Clear()
            Exit Sub
        End If
    End Sub


    Private Sub frmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtTotalPay.TextAlign = HorizontalAlignment.Right
        myConn = New MySqlConnection

        'dgvListeFactures.Visible = False
        checkversementbon.Visible = False
        myConn.ConnectionString = frmMain.ServerString
        myLabConn.ConnectionString = frmMain.ServerString
        myConn2.ConnectionString = frmMain.ServerString
        myConn3.ConnectionString = frmMain.ServerString
        Me.Text = Me.Text & " - " & user

        'Me.Height = 260
        'Me.Width = 385
        TotalSelect = 0
        txtId.Focus()
        'txtId.Focus = True

    End Sub

    Private Sub txtId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtId.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            GetBilledItems()
        End If
    End Sub


    Private Sub btnValidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidate.Click


        'si la facture est paye je l'imprime simplement sans rien modifier
        If ispaid() Then

            'impression du ticket
            rpt.PrintToPrinter(1, False, 0, 0)
            'rpt.PrintToPrinter(1, False, 0, 0)
            'CrystalReportViewer.PrintReport()
            Controls.Clear()
            InitializeComponent()
            checkversementbon.Visible = False
            Show()
            Exit Sub

        ElseIf isbon() And checkversementbon.Checked Then
            'rpt.PrintToPrinter(1, False, 0, 0)
            rpt.PrintToPrinter(1, False, 0, 0)

            'CrystalReportViewer.PrintReport()
            Controls.Clear()
            InitializeComponent()
            checkversementbon.Visible = False
            Show()
            Exit Sub


        Else


            Dim Qry As String

            'je verifie si cet enregiistrement n'existe pas dans la bd

            Qry = "SELECT id FROM care_billing_final WHERE " & _
                    " bill_no=" & billnum '& " AND amount_recieved=" & totalreceiptamount & " AND amount_due=" & amountdue

            myConn.Open()
            Comd = New MySqlCommand(Qry, myConn)
            PrescReader = Comd.ExecuteReader
            PrescReader.Read()
            If PrescReader.HasRows = False Then
                myConn.Close()
                'Insert the new data in the billing_bill_item
                Qry = "INSERT INTO care_billing_final (encounter_nr, bill_no, date, bill_amount, amount_recieved, amount_due, agent) " & _
                    "VALUES (" & Encounter & "," & billnum & ",'" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "'," & totalbillamount & "," & totalreceiptamount & "," & amountdue & ",'" & user & "')"
                myConn.Open()
                Comd = New MySqlCommand(Qry, myConn)
                Comd.ExecuteNonQuery()
                myConn.Close()



            Else
                'MsgBox("Ces donnees existent deja!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur")
                myConn.Close()
                'Insert the new data in the billing_bill_item
                Qry = "UPDATE `care_billing_final` SET encounter_nr=" & Encounter & ", bill_no=" & billnum & ", date= '" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "', bill_amount=" & totalbillamount & ", amount_recieved=" & totalreceiptamount & ", amount_due=" & amountdue & ", agent='" & user & "' WHERE `care_billing_final`.`bill_no`=" & billnum
                myConn.Open()
                Comd = New MySqlCommand(Qry, myConn)
                Comd.ExecuteNonQuery()
                myConn.Close()

            End If

            'mise a jour de care_billing_payment

            miseajour_care_billing_payement()

            'Rajout de la facturation par avances
            'Cette portiona ete faite pour gerer le pblem des avance de paiements.

            'mise a jour de care_billing final

            miseajour_care_billing_final()

            'mise a jour prescription 
            If ispaid() Then
                UpdatePrescription("paid")
                UpdateBillingItems("paid")
            Else
                UpdatePrescription("partial")
                UpdateBillingItems("partial")

                'miseajour_prescription_partiel()
                'miseajour_care_billing_bill_item_partial()

            End If

            'mis a jour care_biling_credit si le patient est ous bon
            miseajour_carebilling_credit_patientpaid()

            'impression du ticket
            'PrintDialog1.PrinterSettings.PrinterName = def
            ' CrystalReportViewer.pa



            'CrystalReportViewer.PrintReport()
            'rpt.PrintToPrinter(1, False, 0, 0)
            'rpt.PrintToPrinter(1, False, 0, 0)

            rpt.PrintToPrinter(1, True, 1, 0)
            'rpt.PrintToPrinter(1, True, 1, 0)
            'rpt.PrintToPrinter(
        End If

        Controls.Clear()
        InitializeComponent()
        checkversementbon.Visible = False
        Show()

    End Sub

    Function ispaid() As Boolean
        ' Dim Qry As String
        Dim stat As String
        stat = "partial"
        Try
            myConn.Open()
            qry = "SELECT status FROM `care_billing_final` WHERE `care_billing_final`.`encounter_nr`=" & Encounter & " AND `care_billing_final`.`bill_no`=" & testbill ' & "ORDER BY date DESC LIMIT 1"
            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                PrescReader.Read()
                stat = PrescReader.Item("status")
            End If

            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try

        If stat = "paid" Then
            Return True
        Else
            Return False
        End If

    End Function

    Function ispartial() As Boolean
        'Dim Qry As String
        Dim stat As String
        stat = "billed"

        Try
            myConn.Open()
            qry = "SELECT status FROM care_billing_final WHERE encounter_nr=" & Encounter & " AND bill_no=" & testbill
            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                PrescReader.Read()
                stat = PrescReader.Item("status")
            End If

            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try

        If stat = "partial" Then
            Return True
        Else
            Return False
        End If

    End Function



    Function compareamount() As Boolean
        'Dim qry As String
        Dim total As Integer

        Try


            myConn.Open()
            qry = "SELECT `amount_recieved` FROM care_billing_final WHERE bill_no=" & testbill
            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader
            PrescReader.Read()
            total = PrescReader.Item("amount_recieved")
            myConn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try
        If total < totalbillamount Then
            Return True
        Else
            Return False
        End If

    End Function

    Function ilyalabetproduit() As Boolean

        Dim ilya As Boolean = False
        Dim lab As Boolean = False
        Dim prod As Boolean = False

        'verification de la presence des prodeuits
        Try
            myConn.Open()
            qry = "SELECT *  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=0 AND status='billed' AND `bill_no`=" & testbill  'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                prod = True
            End If

            myConn.Close()
            '   Comd.ExecuteNonQuery()

            'verification de la presences des labo
            myConn.Open()
            qry = "SELECT *  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=1 AND status='billed' AND `bill_no`=" & testbill  'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                lab = True
            End If

            myConn.Close()
            '  Comd.ExecuteNonQuery()

            If prod = True And lab = True Then
                ilya = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try



        Return ilya
    End Function


    Private Sub affiche_element_complet()

        Try
            myConn.Open()
            dtaDataTable.Reset()
            qry = "SELECT `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=0 AND status='billed' AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)

            dtaAdapter.SelectCommand = Comd
            dtaAdapter.Fill(dtaDataTable)
            myConn.Close()

            If ilyalabetproduit() Then
                myConn.Open()
                qry = "SELECT SUM(`amount`) as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=0 AND status='billed' AND `bill_no`=" & testbill  'AND `bill_number`=0"
                Comd = New MySqlCommand(qry, myConn)
                PrescReader = Comd.ExecuteReader
                While PrescReader.Read()
                    newListRow = dtaDataTable.NewRow
                    newListRow("Article") = "Total Presc."
                    '  newListRow("Prix") = ""
                    '  newListRow("Qte") = ""
                    newListRow("Total") = PrescReader.Item("Total")
                    dtaDataTable.Rows.Add(newListRow)
                    dtaDataTable.AcceptChanges()

                End While
                myConn.Close()

            End If

            myConn.Open()
            qry = "SELECT `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=1 AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                While PrescReader.Read()
                    newListRow = dtaDataTable.NewRow
                    newListRow("Article") = PrescReader.Item("Article")
                    newListRow("Prix") = PrescReader.Item("Prix")
                    newListRow("Qte") = PrescReader.Item("Qte")
                    newListRow("Total") = PrescReader.Item("Total")
                    dtaDataTable.Rows.Add(newListRow)
                    dtaDataTable.AcceptChanges()

                End While
            End If
            myConn.Close()

            If ilyalabetproduit() Then

                myConn.Open()
                qry = "SELECT SUM(`amount`) as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=1 AND `bill_no`=" & testbill  'AND `bill_number`=0"
                Comd = New MySqlCommand(qry, myConn)
                PrescReader = Comd.ExecuteReader

                If PrescReader.HasRows Then
                    While PrescReader.Read()
                        newListRow = dtaDataTable.NewRow
                        newListRow("Article") = "Total Lab."
                        '  newListRow("Prix") = ""
                        '  newListRow("Qte") = ""
                        newListRow("Total") = PrescReader.Item("Total")
                        dtaDataTable.Rows.Add(newListRow)
                        dtaDataTable.AcceptChanges()

                    End While
                End If
                myConn.Close()

            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try


    End Sub

    Private Sub affiche_element_complet_bon()

        Try
            myConn.Open()
            dtaDataTable.Reset()
            qry = "SELECT `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=0  AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)

            dtaAdapter.SelectCommand = Comd
            dtaAdapter.Fill(dtaDataTable)
            myConn.Close()

            If ilyalabetproduit() Then
                myConn.Open()
                qry = "SELECT SUM(`amount`) as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=0  AND `bill_no`=" & testbill  'AND `bill_number`=0"
                Comd = New MySqlCommand(qry, myConn)
                PrescReader = Comd.ExecuteReader
                While PrescReader.Read()
                    newListRow = dtaDataTable.NewRow
                    newListRow("Article") = "Total Presc."
                    '  newListRow("Prix") = ""
                    '  newListRow("Qte") = ""
                    newListRow("Total") = PrescReader.Item("Total")
                    dtaDataTable.Rows.Add(newListRow)
                    dtaDataTable.AcceptChanges()

                End While
                myConn.Close()

            End If

            myConn.Open()
            qry = "SELECT `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=1 AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                While PrescReader.Read()
                    newListRow = dtaDataTable.NewRow
                    newListRow("Article") = PrescReader.Item("Article")
                    newListRow("Prix") = PrescReader.Item("Prix")
                    newListRow("Qte") = PrescReader.Item("Qte")
                    newListRow("Total") = PrescReader.Item("Total")
                    dtaDataTable.Rows.Add(newListRow)
                    dtaDataTable.AcceptChanges()

                End While
            End If
            myConn.Close()

            If ilyalabetproduit() Then

                myConn.Open()
                qry = "SELECT SUM(`amount`) as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=1 AND `bill_no`=" & testbill  'AND `bill_number`=0"
                Comd = New MySqlCommand(qry, myConn)
                PrescReader = Comd.ExecuteReader

                If PrescReader.HasRows Then
                    While PrescReader.Read()
                        newListRow = dtaDataTable.NewRow
                        newListRow("Article") = "Total Lab."
                        '  newListRow("Prix") = ""
                        '  newListRow("Qte") = ""
                        newListRow("Total") = PrescReader.Item("Total")
                        dtaDataTable.Rows.Add(newListRow)
                        dtaDataTable.AcceptChanges()

                    End While
                End If
                myConn.Close()

            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try


    End Sub

    Private Sub affiche_element_complet_paye()

        Try
            myConn.Open()
            dtaDataTable.Reset()
            qry = "SELECT `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=0 AND `status`='paid' AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)

            dtaAdapter.SelectCommand = Comd
            dtaAdapter.Fill(dtaDataTable)
            myConn.Close()

            If ilyalabetproduit() Then
                myConn.Open()
                qry = "SELECT SUM(`amount`) as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=0 AND `status`='paid' AND `bill_no`=" & testbill
                Comd = New MySqlCommand(qry, myConn)
                PrescReader = Comd.ExecuteReader
                While PrescReader.Read()
                    newListRow = dtaDataTable.NewRow
                    newListRow("Article") = "Total Presc."
                    '  newListRow("Prix") = ""
                    'newListRow("Qte") = ""
                    newListRow("Total") = PrescReader.Item("Total")
                    dtaDataTable.Rows.Add(newListRow)
                    dtaDataTable.AcceptChanges()

                End While
                myConn.Close()
            End If

            myConn.Open()
            qry = "SELECT `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=1 AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                While PrescReader.Read()
                    newListRow = dtaDataTable.NewRow
                    newListRow("Article") = PrescReader.Item("Article")
                    newListRow("Prix") = PrescReader.Item("Prix")
                    newListRow("Qte") = PrescReader.Item("Qte")
                    newListRow("Total") = PrescReader.Item("Total")
                    dtaDataTable.Rows.Add(newListRow)
                    dtaDataTable.AcceptChanges()

                End While
            End If
            myConn.Close()

            If ilyalabetproduit() Then
                myConn.Open()
                qry = "SELECT SUM(`amount`) as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=1 AND `bill_no`=" & testbill  'AND `bill_number`=0"
                Comd = New MySqlCommand(qry, myConn)
                PrescReader = Comd.ExecuteReader

                If PrescReader.HasRows Then
                    While PrescReader.Read()
                        newListRow = dtaDataTable.NewRow
                        newListRow("Article") = "Total Lab."
                        '  newListRow("Prix") = ""
                        '  newListRow("Qte") = ""
                        newListRow("Total") = PrescReader.Item("Total")
                        dtaDataTable.Rows.Add(newListRow)
                        dtaDataTable.AcceptChanges()

                    End While
                End If
                myConn.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try



    End Sub

    Private Sub affiche_element_partiel()

        Try
            myConn.Open()
            dtaDataTable.Reset()
            Qry = "SELECT `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=0 AND status IN('paid','partial','avance') AND `bill_no`=" & Testbill & " ORDER BY  article" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)

            dtaAdapter.SelectCommand = Comd
            dtaAdapter.Fill(dtaDataTable)
            myConn.Close()

            If ilyalabetproduit() Then
                myConn.Open()
                Qry = "SELECT SUM(`amount`) as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=0 AND status IN('paid','partial','avance') AND `bill_no`=" & Testbill  'AND `bill_number`=0"
                Comd = New MySqlCommand(qry, myConn)
                PrescReader = Comd.ExecuteReader
                While PrescReader.Read()
                    newListRow = dtaDataTable.NewRow
                    newListRow("Article") = "Total Presc."
                    '  newListRow("Prix") = ""
                    '  newListRow("Qte") = ""
                    newListRow("Total") = PrescReader.Item("Total")
                    dtaDataTable.Rows.Add(newListRow)
                    dtaDataTable.AcceptChanges()

                End While
                myConn.Close()

            End If

            myConn.Open()
            qry = "SELECT `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=1 AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                While PrescReader.Read()
                    newListRow = dtaDataTable.NewRow
                    newListRow("Article") = PrescReader.Item("Article")
                    newListRow("Prix") = PrescReader.Item("Prix")
                    newListRow("Qte") = PrescReader.Item("Qte")
                    newListRow("Total") = PrescReader.Item("Total")
                    dtaDataTable.Rows.Add(newListRow)
                    dtaDataTable.AcceptChanges()

                End While
            End If
            myConn.Close()

            If ilyalabetproduit() Then

                myConn.Open()
                qry = "SELECT SUM(`amount`) as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=1 AND `bill_no`=" & testbill  'AND `bill_number`=0"
                Comd = New MySqlCommand(qry, myConn)
                PrescReader = Comd.ExecuteReader

                If PrescReader.HasRows Then
                    While PrescReader.Read()
                        newListRow = dtaDataTable.NewRow
                        newListRow("Article") = "Total Lab."
                        '  newListRow("Prix") = ""
                        '  newListRow("Qte") = ""
                        newListRow("Total") = PrescReader.Item("Total")
                        dtaDataTable.Rows.Add(newListRow)
                        dtaDataTable.AcceptChanges()

                    End While
                End If
                myConn.Close()

            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try


    End Sub

    Private Sub info_premier_versement_bon()

        Try

            myConn.Open()
            qry = "SELECT `billamount`, `patientamount`, `firmamount` FROM `care_billing_credit` WHERE `encounter_nr`=" & Encounter & " AND `billno`=" & testbill
            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader

            If PrescReader.HasRows Then
                PrescReader.Read()

                txtTotalToPay.Text = PrescReader.Item("billamount")
                totalbillamount = PrescReader.Item("billamount")
                montantverse = 0
                '  TotalSelect = txtTotalToPay.Text
                txtTotalToPay.Text = FormatCurrency(txtTotalToPay.Text)
                txtTotalPay.Text = PrescReader.Item("patientamount")
                totalreceiptamount = CInt(PrescReader.Item("patientamount"))
                ' txtTotalPay.Text = FormatCurrency(txtTotalPay.Text)
                'txtReste.Text = PrescReader.Item("remain")
                amountdue = CInt(PrescReader.Item("firmamount"))
                Typepaiement = "bon"


                ' billnum = testbill


            End If

            myConn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try



    End Sub
    Private Sub info_premier_versement()

        Try

            myConn.Open()
            qry = "SELECT `billtotal`, `paid`, `remain`, `topay`,`typepaiement` FROM `care_billing_payment` WHERE `encounter_nr`=" & Encounter & " AND `receipt_no`=" & testbill
            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader

            If PrescReader.HasRows Then
                PrescReader.Read()

                txtTotalToPay.Text = PrescReader.Item("billtotal")
                totalbillamount = PrescReader.Item("billtotal")
                montantverse = 0
                '  TotalSelect = txtTotalToPay.Text
                txtTotalToPay.Text = FormatCurrency(txtTotalToPay.Text)
                txtTotalPay.Text = totalbillamount
                totalreceiptamount = totalbillamount
                ' txtTotalPay.Text = FormatCurrency(txtTotalPay.Text)
                'txtReste.Text = PrescReader.Item("remain")
                amountdue = CInt(PrescReader.Item("remain"))
                If IsDBNull(PrescReader.Item("typepaiement")) = False Then
                    Typepaiement = PrescReader.Item("typepaiement")
                Else
                    Typepaiement = "normal"
                End If

                ' billnum = testbill


            End If

            myConn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try


    End Sub

    Private Sub info_autre_versement()

        Try
            'recuperation du montant a verse au moment
            myConn.Open()
            qry = "SELECT `paid` FROM `care_billing_payment` WHERE `encounter_nr`=" & Encounter & " AND `receipt_no`=" & testbill & " ORDER BY datebilled DESC LIMIT 1"
            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader

            If PrescReader.HasRows Then
                PrescReader.Read()
                montantverse = CInt(PrescReader.Item("paid"))

            End If

            myConn.Close()
            'Recuperation de ce que jai bye

            myConn.Open()
            qry = "SELECT `billtotal`, SUM(`paid`) as topay FROM `care_billing_payment` WHERE `encounter_nr`=" & Encounter & " AND `receipt_no`=" & testbill
            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader

            If PrescReader.HasRows Then
                PrescReader.Read()

                txtTotalToPay.Text = PrescReader.Item("billtotal")
                totalbillamount = CInt(PrescReader.Item("billtotal"))
                '  TotalSelect = txtTotalToPay.Text
                txtTotalToPay.Text = FormatCurrency(txtTotalToPay.Text)

                txtTotalPay.Text = montantverse
                totalreceiptamount = CInt(PrescReader.Item("topay"))

                ' txtTotalPay.Text = FormatCurrency(txtTotalPay.Text)
                'txtReste.Text = (CInt(PrescReader.Item("billtotal")) - CInt(PrescReader.Item("topay"))).ToString
                If isbon() Then

                    myConn2.Open()
                    qry2 = "SELECT `billamount`,`firmamount` FROM `care_billing_credit` WHERE `encounter_nr`=" & Encounter & " AND `billno`=" & testbill
                    Comd2 = New MySqlCommand(qry2, myConn2)
                    'Get the encounter number
                    PrescReader2 = Comd2.ExecuteReader

                    If PrescReader2.HasRows Then
                        PrescReader2.Read()
                        amountdue = PrescReader2.Item("firmamount")
                        txtTotalToPay.Text = PrescReader2.Item("billamount")
                        totalbillamount = CInt(PrescReader2.Item("billamount"))
                    End If
                    myConn2.Close()




                End If


                ' billnum = testbill

            End If

            myConn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try



    End Sub

    Private Sub info_facture_paye()

        Try
            myConn.Open()
            qry = "SELECT `bill_amount`  FROM `care_billing_final` WHERE `encounter_nr`=" & Encounter & " AND `bill_no`=" & testbill
            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader

            If PrescReader.HasRows Then
                PrescReader.Read()

                txtTotalToPay.Text = PrescReader.Item("bill_amount")
                totalbillamount = PrescReader.Item("bill_amount")
                montantverse = 0
                '  TotalSelect = txtTotalToPay.Text
                txtTotalToPay.Text = FormatCurrency(txtTotalToPay.Text)
                txtTotalPay.Text = PrescReader.Item("bill_amount")
                totalreceiptamount = CInt(PrescReader.Item("bill_amount"))
                ' txtTotalPay.Text = FormatCurrency(txtTotalPay.Text)
                'txtReste.Text = 0
                amountdue = 0


            End If

            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try

    End Sub
    ''' <summary>
    ''' Update table des elements factures
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub UpdateBillingItems(Status As String)
        Try
            'Dim long as integer

            'mise a jour de care_encounter_prescription
            qry = "UPDATE `care_billing_bill_item` SET `status`='" & Status & "' WHERE `bill_no`=" & testbill & " AND `encounter_nr`=" & Encounter
            myConn2.Open()
            Comd2 = New MySqlCommand(qry, myConn2)
            Comd2.ExecuteNonQuery()
            myConn2.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn2.Close()
        End Try



    End Sub
    Private Sub miseajour_care_billing_bill_item_paid()
        Try
            'Dim long as integer

            'mise a jour de care_encounter_prescription
            qry = "UPDATE `care_billing_bill_item` SET `status`='paid' WHERE `bill_no`=" & testbill & " AND `encounter_nr`=" & Encounter
            myConn2.Open()
            Comd2 = New MySqlCommand(qry, myConn2)
            Comd2.ExecuteNonQuery()
            myConn2.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn2.Close()
        End Try



    End Sub

    Private Sub miseajour_care_billing_bill_item_partial()

        'Dim long as integer

        'mise a jour de care_encounter_prescription
        Try
            qry = "UPDATE `care_billing_bill_item` SET `status`='partial' WHERE `bill_no`=" & testbill & " AND `encounter_nr`=" & Encounter
            myConn2.Open()
            Comd2 = New MySqlCommand(qry, myConn2)
            Comd2.ExecuteNonQuery()
            myConn2.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn2.Close()
        End Try


    End Sub

    'Mise a jour table des prescriptions
    Private Sub UpdatePrescription(Status As String)

        Try
            Dim qry2 As String
            'Dim long as integer

            'mise a jour de care_encounter_prescription
            qry = "SELECT `code` FROM care_billing_bill_item WHERE bill_no=" & testbill & " AND encounter_nr=" & Encounter
            myConn.Open()
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                While PrescReader.Read()
                    Dim code As Integer
                    code = PrescReader.Item("code")

                    qry2 = "UPDATE `care_encounter_prescription` SET `care_encounter_prescription`.`status`='" & Status & "', `care_encounter_prescription`.`bill_number`=" & testbill & " WHERE `care_encounter_prescription`.`nr`=" & code & " AND `care_encounter_prescription`.`encounter_nr`=" & Encounter
                    myConn2.Open()
                    Comd2 = New MySqlCommand(qry2, myConn2)
                    Comd2.ExecuteNonQuery()
                    myConn2.Close()
                End While
            End If
            myConn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try

    End Sub

    Private Sub miseajour_prescription_partiel()

        Try
            Dim qry2 As String
            'Dim long as integer

            'mise a jour de care_encounter_prescription
            qry = "SELECT `code` FROM care_billing_bill_item WHERE bill_no=" & testbill & " AND encounter_nr=" & Encounter
            myConn.Open()
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                While PrescReader.Read()
                    Dim code As Integer
                    code = PrescReader.Item("code")
                    'si le code a la longueur = 7 je fouille dans les prescription pour changer son statut sinon dans la table des labo
                    If code < 2010000000 Then
                        qry2 = "UPDATE `care_encounter_prescription` SET `care_encounter_prescription`.`status`='partial', `care_encounter_prescription`.`bill_number`=" & testbill & " WHERE `care_encounter_prescription`.`nr`=" & code & " AND `care_encounter_prescription`.`encounter_nr`=" & Encounter
                        myConn2.Open()
                        Comd2 = New MySqlCommand(qry2, myConn2)
                        Comd2.ExecuteNonQuery()
                        myConn2.Close()
                    Else
                        '  qry2 = "UPDATE `care_test_request_chemlabor` SET `care_test_request_chemlabor`.`status`='partial', `care_test_request_chemlabor`.`bill_number`=" & testbill & " WHERE `care_test_request_chemlabor`.`batch_nr`=" & code & " AND `care_test_request_chemlabor`.`encounter_nr`=" & Encounter
                        ' myConn2.Open()
                        ' Comd2 = New MySqlCommand(qry2, myConn2)
                        ' Comd2.ExecuteNonQuery()
                        'myConn2.Close()
                    End If

                End While
            End If
            myConn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try

    End Sub

    Private Sub miseajour_prescription_paid()

        Try
            Dim qry2 As String
            'Dim long as integer

            'mise a jour de care_encounter_prescription
            qry = "SELECT `code` FROM care_billing_bill_item WHERE bill_no=" & testbill & " AND encounter_nr=" & Encounter
            myConn.Open()
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            ' PrescReader.Read()
            If PrescReader.HasRows Then
                While PrescReader.Read()
                    Dim code As Integer
                    code = PrescReader.Item("code")
                    'si le code a la longueur = 7 je fouille dans les prescription pour changer son statut sinon dans la table des labo
                    If code < 2010000000 Then
                        qry2 = "UPDATE `care_encounter_prescription` SET `care_encounter_prescription`.`status`='paid', `care_encounter_prescription`.`bill_number`=" & testbill & " WHERE `care_encounter_prescription`.`nr`=" & code & " AND `care_encounter_prescription`.`encounter_nr`=" & Encounter
                        myConn2.Open()
                        Comd2 = New MySqlCommand(qry2, myConn2)
                        Comd2.ExecuteNonQuery()
                        myConn2.Close()
                    Else
                        '   qry2 = "UPDATE `care_test_request_chemlabor` SET `care_test_request_chemlabor`.`status`='paid', `care_test_request_chemlabor`.`bill_number`=" & testbill & " WHERE `care_test_request_chemlabor`.`batch_nr`=" & code & " AND `care_test_request_chemlabor`.`encounter_nr`=" & Encounter
                        '   myConn2.Open()
                        '   Comd2 = New MySqlCommand(qry2, myConn2)
                        '   Comd2.ExecuteNonQuery()
                        '  myConn2.Close()
                    End If

                End While
            End If
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try


    End Sub
    ''' <summary>
    ''' Update table des factures finales
    ''' Status est passee a la subroutine (paid ou partial ou avance)
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub UpdateBillingFinal(Status As String)
        Try
            qry = "UPDATE `care_billing_final` SET `care_billing_final`.`status`='" & Status & "' WHERE `care_billing_final`.`bill_no`=" & billnum
            myConn.Open()
            Comd = New MySqlCommand(qry, myConn)
            Comd.ExecuteNonQuery()
            myConn.Close()
            miseajour_prescription_partiel()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Close()
        End Try
    End Sub

    Private Sub miseajour_care_billing_final()

        Try
            'je met a jour le statut dans care_billing_final en fonction du total recu
            If compareamount() Then
                qry = "UPDATE `care_billing_final` SET `care_billing_final`.`status`='partial' WHERE `care_billing_final`.`bill_no`=" & billnum
                myConn.Open()
                Comd = New MySqlCommand(qry, myConn)
                Comd.ExecuteNonQuery()
                myConn.Close()
                miseajour_prescription_partiel()

            Else
                qry = "UPDATE `care_billing_final` SET `care_billing_final`.`status`='paid' WHERE `care_billing_final`.`bill_no`=" & billnum
                myConn.Open()
                Comd = New MySqlCommand(qry, myConn)
                Comd.ExecuteNonQuery()
                myConn.Close()
                miseajour_prescription_paid()

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try


    End Sub

    Private Sub miseajour_care_billing_payement()

        Try
            'je recupere la date du versement le plus recent
            Dim dateversement As Date
            myConn.Open()
            qry = "SELECT datebilled FROM care_billing_payment WHERE encounter_nr=" & Encounter & " AND receipt_no=" & testbill & " ORDER BY datebilled DESC LIMIT 1"
            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader

            If PrescReader.HasRows Then
                PrescReader.Read()
                dateversement = PrescReader.Item("datebilled")

                ' MsgBox(dateversement.ToString("yyyy-MM-dd HH:mm:ss"))
            End If

            myConn.Close()

            myConn.Open()
            qry = "UPDATE `care_billing_payment` SET paid=" & totalreceiptamount & ", encaisseur='" & user & "', datepaid='" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "' WHERE `care_billing_payment`.`receipt_no`=" & billnum & " AND datebilled='" & dateversement.ToString("yyyy-MM-dd HH:mm:ss") & "'"
            Comd = New MySqlCommand(qry, myConn)
            Comd.ExecuteNonQuery()
            myConn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try


    End Sub
    Function isbon() As Boolean
        'verifie si on a à faire à un bon
        Dim bon As Boolean
        Dim type As String = "normal"
        bon = False

        Try
            myConn3.Open()
            qry3 = "SELECT `typepaiement` FROM `care_billing_payment` WHERE `encounter_nr`=" & Encounter & " AND `receipt_no`=" & testbill & " ORDER BY datebilled DESC LIMIT 1"
            Comd3 = New MySqlCommand(qry3, myConn3)
            'Get the encounter number
            PrescReader3 = Comd3.ExecuteReader

            If PrescReader3.HasRows Then
                PrescReader3.Read()
                If IsDBNull(PrescReader3.Item("typepaiement")) = False Then
                    type = (PrescReader3.Item("typepaiement").ToString)
                Else
                    type = "normal"
                End If


            End If

            myConn3.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn3.Close()
        End Try

        If type = "normal" Then
            bon = False
        Else
            bon = True
        End If

        Return bon
    End Function

    Private Sub miseajour_carebilling_credit_patientpaid()

        'je doit mettre a jour le moment ou la firme et le patient paye (1) et les date si le patient est sous bon
        If isbon() And ispaid() Or ispartial() Then

            myConn.Open()
            qry = "UPDATE `care_billing_credit` SET `patientpaid`=1, `datepatientpaid`='" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "' WHERE `billno`=" & billnum & " AND `encounter_nr`=" & Encounter
            Comd = New MySqlCommand(qry, myConn)
            Comd.ExecuteNonQuery()
            myConn.Close()

        End If


    End Sub

    Private Sub miseajour_carebilling_credit_firmpaid()

        'je doit mettre a jour le moment ou la firme et le patient paye (1) et les date si le patient est sous bon
        If isbon() And ispaid() Then

            myConn.Open()
            qry = "UPDATE `care_billing_credit` SET `firmpaid`=1, `datefirmpaid`='" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "' WHERE `billno`=" & billnum & " AND `encounter_nr`=" & Encounter
            Comd = New MySqlCommand(qry, myConn)
            Comd.ExecuteNonQuery()
            myConn.Close()

        End If


    End Sub


    Function iscreditcomplete() As Boolean

        'je verifie si dans care billing credit patientpaid et firmpaid sont =1
        Dim status As Boolean = False
        Dim patientpaid, firmpaid As Integer
        patientpaid = 0
        firmpaid = 0

        Try

            myConn.Open()
            qry = "SELECT patientpaid,firmpaid FROM `care_billing_credit` WHERE `billno`=" & billnum & " AND `encounter_nr`=" & Encounter
            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                PrescReader.Read()
                patientpaid = PrescReader.Item("patientpaid")
                firmpaid = PrescReader.Item("firmpaid")
            End If
            Comd.ExecuteNonQuery()
            myConn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
            Comd.ExecuteNonQuery()
            myConn.Close()
        End Try

        If patientpaid = 1 And firmpaid = 1 Then
            status = True
        End If


        Return status
    End Function
    Private Sub afficher_facture()

        Try
            'Get the Patient information
            myConn.Open()
            qry = "SELECT name_first, name_last, date_birth FROM caredb.care_person WHERE pid=" & CULng(txtId.Text)
            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader
            PrescReader.Read()
            Patient_Name = PrescReader.Item("name_last") & "  " & PrescReader.Item("name_first")
            Patient_Birth = PrescReader.Item("date_birth")
            myConn.Close()


            'si la facture est paye
            If ispaid() Then
                MsgBox("Facture Payée")

                affiche_element_complet_paye()
                info_facture_paye()


            ElseIf isbon() Then

                affiche_element_complet_bon()
                info_premier_versement_bon()

            Else

                'si c'est le tout premier versement de la facture
                affiche_element_complet()
                info_premier_versement()

            End If

            'info personnel


            If isbon() Then
                checkversementbon.Visible = True
            Else
                checkversementbon.Visible = False
            End If

            'Affichage de la facture
            affichercrystalreport()


            grpItems.Width = CrystalReportViewer.Width
            grpItems.Visible = True
            grpTotal.Visible = True


        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try


    End Sub
    Private Sub affichercrystalreport()

        Dim ds As New DataSet1()


        'affectation de la bd
        rpt.SetDataSource(dtaDataTable)


        ' affectation des autres element constitutif de la facture
        rpt.SetParameterValue("total", totalbillamount)
        rpt.SetParameterValue("payee", totalreceiptamount)
        rpt.SetParameterValue("reste", amountdue)
        rpt.SetParameterValue("verse", 0)
        rpt.SetParameterValue("agentcaisse", user)
        rpt.SetParameterValue("agentfacturation", agentdefacturation)
        rpt.SetParameterValue("billnum", billnum)
        rpt.SetParameterValue("patient", Patient_Name)
        rpt.SetParameterValue("pid", txtId.Text)
        rpt.SetParameterValue("encounter", Encounter)

        If isbon() Then

            If checkversementbon.Checked = True Then
                rpt.SetParameterValue("payement", "CREDIT:")

            Else
                rpt.SetParameterValue("payement", "PAYE:")

            End If
            rpt.SetParameterValue("societe", "Societé:  " & FirmName)
            rpt.SetParameterValue("charge", "CREDIT STE:")
            rpt.SetParameterValue("montantcharge", amountdue.ToString & "  CFA")
            rpt.SetParameterValue("assure", "Assuré:  " & assure)
        Else
            rpt.SetParameterValue("payement", "PAYE:")
            rpt.SetParameterValue("charge", "")
            rpt.SetParameterValue("montantcharge", "")
            rpt.SetParameterValue("societe", "")
            rpt.SetParameterValue("assure", "")
        End If


        'rpt.PrintOptions.PaperSize.

        CrystalReportViewer.ReportSource = rpt

    End Sub

    Private Sub midififieValeurSiBon()

    End Sub

    Private Sub listefacture_doubleclick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListeFactures.CellDoubleClick


    End Sub

    Private Sub checkversementbon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkversementbon.CheckedChanged
        affichercrystalreport()
    End Sub

    Private Sub GetEncounterInformation()

        Dim qry, Enc_Date, Patient_Name, Patient_Birth As String
        Dim dtaAdapter As New MySqlDataAdapter
        Dim dtaDataTable As New DataTable
        Dim bindSource As New BindingSource


        'dgvPrescriptions.Width = 60

        'dtaDataTable.DataSet.Clear()
        bindSource.DataSource = Nothing
        'myConn = New MySqlConnection
        'myConn.ConnectionString = "server=192.168.15.20;userid=root;password=server;database=caredb"
        myConn.ConnectionString = frmMain.ServerString

        If String.IsNullOrEmpty(txtId.Text) Then
            MsgBox("Vous devez saisir le numero du patient", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
            txtId.Focus()
            txtId.Clear()
            Exit Sub
        End If
        If Not IsNumeric(txtId.Text) Then
            MsgBox("Vous devez saisir le numero du patient", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
            txtId.Focus()
            Exit Sub
        End If
        If (Integer.Parse(txtId.Text) >= 10000000) Then
            Try
                'Get the encounter number, encounter date, config bon, encounter_type of the patient
                myConn.Open()
                qry = "SELECT insurance_firm, contact_name, contact_relation, quality, exclusion, bonpercent, encounter_nr, encounter_date, boncfg, encounter_type  FROM caredb.care_encounter WHERE pid=" & CULng(txtId.Text) & _
                    " AND is_discharged=0 ORDER BY encounter_date"
                Comd = New MySqlCommand(qry, myConn)
                'Get the encounter number
                PrescReader = Comd.ExecuteReader
                PrescReader.Read()
                If PrescReader.HasRows = True Then
                    Encounter = PrescReader.Item("encounter_nr")
                    BonCfg = PrescReader.Item("boncfg")
                    Enc_Date = PrescReader.Item("encounter_date")
                    EncounterType = PrescReader.Item("encounter_type")
                    EncounterPercent = PrescReader.Item("bonpercent")
                    FirmName = PrescReader.Item("insurance_firm")
                    ContactName = PrescReader.Item("contact_name")
                    PatientRelation = PrescReader.Item("contact_relation")
                    PatientQuality = PrescReader.Item("quality")
                    Exclusion = PrescReader.Item("exclusion")

                    myConn.Close()
                    '
                    'Get the Patient information
                    myConn.Open()
                    qry = "SELECT name_first, name_last, date_birth FROM caredb.care_person WHERE pid=" & CULng(txtId.Text)
                    Comd = New MySqlCommand(qry, myConn)
                    'Get the encounter number
                    PrescReader = Comd.ExecuteReader
                    PrescReader.Read()
                    Patient_Name = PrescReader.Item("name_last") & " " & PrescReader.Item("name_first")
                    Patient_Birth = PrescReader.Item("date_birth")
                    myConn.Close()
                    'grpFacturation.Visible = True
                    grpInfo.Visible = True
                    'Me.Height = 205
                    'Me.Width = 765
                    'Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
                    'Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
                    txtInfos.Text = "Noms: " & Patient_Name & Environment.NewLine & "Né(e) le: " & Patient_Birth & _
                        Environment.NewLine & "No Visite: " & Encounter & " du: " & Enc_Date
                    If BonCfg > 0 Then
                        txtInfos.Text = txtInfos.Text & Environment.NewLine & "Bon de type: " & EncounterType & " à: " & EncounterPercent & "%" & _
                            Environment.NewLine & "Assurance: " & FirmName
                        If BonCfg = 3 Then
                            txtInfos.Text = txtInfos.Text & Environment.NewLine & "En qualité de: " & PatientQuality
                        End If
                        If Exclusion = 1 Then
                            txtInfos.Text = txtInfos.Text & Environment.NewLine & _
                                "Bon à eclusion!!!"
                        End If
                    End If
                Else
                    MsgBox("Ce patient n'a pas de rencontre!!!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Patient Non Trouvé!!")
                End If
            Catch ex As MySqlException
                myConn.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur de Connexion!!!")
            Finally
                myConn.Dispose()
            End Try
        Else
            MsgBox("Vous devez saisir un numéro de patient valide à 8 chiffres.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
            txtId.Focus()
            txtId.Clear()
            Exit Sub
        End If
    End Sub


    Private Sub grpItems_Enter(sender As System.Object, e As System.EventArgs) Handles grpItems.Enter

    End Sub

    Private Sub grpSearch_Enter(sender As System.Object, e As System.EventArgs) Handles grpSearch.Enter

    End Sub

    Private Sub chkVersementAvance_CheckedChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub listfacture_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListeFactures.CellContentClick
        Testbill = dgvListeFactures.Rows(dgvListeFactures.CurrentRow.Index).Cells(1).Value
        Agentdefacturation = dgvListeFactures.Rows(dgvListeFactures.CurrentRow.Index).Cells(3).Value.ToString
        billnum = Testbill
        Encounter = dgvListeFactures.Rows(dgvListeFactures.CurrentRow.Index).Cells(0).Value
        'GetEncounterInformation()

        'Verifier si c'est pas de ja une avance
        DB.AddParams("@encounter", Encounter)
        DB.AddParams("@bill", billnum)
        Qry = "SELECT DISTINCT(status) FROM care_billing_bill_item WHERE encounter_nr=@encounter AND bill_no=@bill AND status='avance'"
        DB.ExecQuery(Qry)
        If DB.RecordCount > 0 Then
            Dim frmAvance As New frmAvancePaie
            frmAvance.Outside = True
            frmAvance.txtSearch.Text = txtId.Text
            frmAvance.Encounter = Encounter
            frmAvance.Bill = billnum
            frmAvance.ShowDialog()

        Else
            afficher_facture()
        End If

    End Sub
End Class