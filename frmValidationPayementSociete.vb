Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmValidationPayementSociete
    Dim myConn, myConn2, myLabConn As New MySqlConnection
    Dim Comd, Comd2, LabCmd As MySqlCommand
    Dim PrescReader, LabReader As MySqlDataReader
    Dim TotalSelect As Integer
    Dim ConnMode As String
    Public Encounter As ULong
    Public billnum As String
    Dim billamount As Double
    Dim patientamount As Double
    Dim firmamount As Double
    Dim firmpaid As Integer = 0
    Dim patientpaid As Integer = 0
    Dim datepatientpaid As DateTime = Nothing
    Dim datefirmpaid As DateTime = Nothing
    Dim status As String
    Dim user As String
    Dim testbill As String
    Dim agentdefacturation As String
    Dim montantverse As Double
    Dim pid As Integer

    Dim qry, Enc_Date, Enc_type, Patient_Name, Patient_Birth As String
    Dim dtaAdapter As New MySqlDataAdapter
    Dim dtaDataTable As New DataTable
    Dim bindSource As New BindingSource

    Dim BonCfg As Integer
    Dim newListRow As DataRow

    Private Sub frmImpressionEtatCreditNonPaye_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'je recupere le pid de l'utilisateur
        myConn.ConnectionString = frmMain.ServerString


        Try
            'Get the encounter number, encounter date, config bon, encounter_type of the patient
            myConn.Close()
            myConn.Open()
            qry = "SELECT pid, encounter_date, boncfg, encounter_type  FROM caredb.care_encounter WHERE encounter_nr=" & Encounter & _
                " ORDER BY encounter_date DESC" 'LIMIT 1" 'ABS(DATEDIFF(NOW(), encounter_date)) ASC" 'AND is_discharged=0"
            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader


            If PrescReader.HasRows Then
                PrescReader.Read()
                pid = CInt(PrescReader.Item("pid"))
                testbill = pid
                BonCfg = PrescReader.Item("boncfg")
                Enc_Date = PrescReader.Item("encounter_date")
                Enc_type = PrescReader.Item("encounter_type")
                myConn.Close()


            Else
                MsgBox("Non Inscrit")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try

        'recupration des information du patient

        Try
            'Get the Patient information
            myConn.Open()
            qry = "SELECT name_first, name_last, date_birth FROM caredb.care_person WHERE pid=" & pid
            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader
            PrescReader.Read()
            Patient_Name = PrescReader.Item("name_last") & "  " & PrescReader.Item("name_first")
            Patient_Birth = PrescReader.Item("date_birth")
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try

        'j'affiche les info du patient 
        nomprenom.Text = lblPatientInfo.Text & " " & Patient_Name.ToString
        daterencontre.Text = lblEncInfo.Text & " " & Enc_Date.ToString
        typebon.Text = lblBonInfo.Text & " " & BonCfg.ToString
        'je recupere les elements de la facture
        element_facture()

        'info facture
        info_facture()

        'j'affiche dans 







    End Sub

    Private Sub info_facture()

        Try

            myConn.Open()
            qry = "SELECT `billamount`, `patientamount`, `firmamount`, `patientpaid`, `firmpaid`, `datepatientpaid`, `datefirmpaid`, `status` FROM `care_billing_credit` WHERE `encounter_nr`=" & Encounter & " AND `billno`=" & billnum
            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader

            If PrescReader.HasRows Then
                PrescReader.Read()

                billamount = PrescReader.Item("billamount")
                patientamount = PrescReader.Item("patientamount")
                firmamount = PrescReader.Item("firmamount")
                patientpaid = CInt(PrescReader.Item("patientpaid"))
                firmpaid = CInt(PrescReader.Item("firmpaid"))

                If IsDBNull(PrescReader.Item("datefirmpaid")) Then

                Else
                    datefirmpaid = (PrescReader.Item("datefirmpaid"))
                End If
                If IsDBNull(PrescReader.Item("datepatientpaid")) Then

                Else
                    datepatientpaid = (PrescReader.Item("datepatientpaid"))
                End If
                '
                status = (PrescReader.Item("status"))

            End If

            myConn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        lblbillamount.Text = billamount.ToString
        lblpatientpaid.Text = patientamount.ToString
        lblfrimpaid.Text = firmamount.ToString
        If datepatientpaid = Nothing Then
        Else
            lbldatepatientpaid.Text = datepatientpaid.ToString
        End If
        If datefirmpaid = Nothing Then

        Else
            lbldatefirmpaid.Text = datefirmpaid.ToString
        End If
        If patientpaid = 0 Then
        Else
            cbetatpatient.Checked = True
            txtpatient.Visible = False
            lblpatientaverser.Visible = False

        End If

        If firmpaid = 0 Then

        Else

            cbetatsociete.Checked = True
            txtsociete.Visible = False
            labersocieteverse.Visible = False
        End If

       
        'lbletatpatientpaid.Text = patientpaid
        'lbletatfirmpaid.Text = firmpaid
        'MsgBox(firmpaid.ToString & "  et  " & patientpaid.ToString)
    End Sub

    Private Sub element_facture()

        Try
            myConn.Open()
            dtaDataTable.Reset()
            qry = "SELECT `article` as Article,`units` as Qte,`amount` as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=0  AND `bill_no`=" & billnum & " ORDER BY  article" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)

            dtaAdapter.SelectCommand = Comd
            dtaAdapter.Fill(dtaDataTable)
            myConn.Close()

            If ilyalabetproduit() Then
                myConn.Open()
                qry = "SELECT SUM(`amount`) as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=0 AND status='billed' AND `bill_no`=" & billnum  'AND `bill_number`=0"
                Comd = New MySqlCommand(qry, myConn)
                PrescReader = Comd.ExecuteReader
                While PrescReader.Read()
                    newListRow = dtaDataTable.NewRow
                    newListRow("Article") = "Total Prescription:"
                    '  newListRow("Prix") = ""
                    '  newListRow("Qte") = ""
                    newListRow("Total") = PrescReader.Item("Total")
                    dtaDataTable.Rows.Add(newListRow)
                    dtaDataTable.AcceptChanges()

                End While
                myConn.Close()
            End If
            

            myConn.Open()
            qry = "SELECT `article` as Article,`units` as Qte,`amount` as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=1 AND `bill_no`=" & billnum & " ORDER BY  article" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                While PrescReader.Read()
                    newListRow = dtaDataTable.NewRow
                    newListRow("Article") = PrescReader.Item("Article")
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
                        newListRow("Article") = "Total Examen Laboratoire"
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
        End Try

        DataGridView.DataSource = dtaDataTable



        DataGridView.Refresh()


    End Sub

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
        End Try



        Return ilya
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click



        Me.Close()
    End Sub
    Private Sub facture_ordinaire()

    End Sub

    Private Sub versement_societe()

    End Sub

End Class