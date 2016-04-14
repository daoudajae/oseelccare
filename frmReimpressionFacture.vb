Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmReimpressionFacture
     Public Property Permission As String
    Public Property Utilisateur As String
    'Public ServerString As String

    Dim myConn, myConn1, myConn3, myLabConn As New MySqlConnection
    Dim Comd, Comd1, Comd3, LabCmd As MySqlCommand
    Dim PrescReader, PrescReader3, LabReader As MySqlDataReader
    Dim TotalSelect, EncounterPercent, TotalAssureur, TotalAssurer, TotalExclusion, billAmount, billNo, Exclusion, BonCfg, pid As Integer
    Dim ConnMode, EncounterType, FirmName, ContactName, PatientRelation, PatientQuality As String
    Dim Encounter As ULong
    Dim facturetotal, factureclient, facturesociete As Double
    Dim qry1, qry2, qry3, qry4, qry5, nom, liste As String
    Private rpt As New copyfacture
    Dim dtaDataTable As New DataTable
    Dim newListRow As DataRow
    Dim dtaAdapter As New MySqlDataAdapter
    Dim qry As String

    Dim encounter_nr As ULong
    Dim receipt_no As Integer
    Dim datebilled, datepaid As DateTime
    Dim typepaimenent, encaisseur, factureur, etatfacture As String
    Dim patientamount, firmamount, montantfacture As Double

    Private Sub frmReimpressionFacture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        myConn.ConnectionString = frmMain.ServerString
        myConn3.ConnectionString = frmMain.ServerString
        myLabConn.ConnectionString = frmMain.ServerString
    

    End Sub

   

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        GetEncounterInformation()
        GetEncounterList()
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
                    nom = Patient_Name
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

                    'je recupere imediatement le pid pour eviter les pb
                    pid = CULng(txtId.Text)
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

    Private Sub GetEncounterList()

        Dim dtaDataTable As New DataTable
        Dim dtlaAdapter As New MySqlDataAdapter
        Dim qry As String
        Dim factlist As New DataTable

        listerencontre.DataSource = Nothing
        listerencontre.Rows.Clear()
        listerencontre.Columns.Clear()
        ' If DataGridView1.GetRowCount Then
        Try
            myConn.Open()
            qry = "SELECT `care_encounter`.`encounter_nr`, `care_encounter`.`encounter_date`  FROM `care_encounter`  WHERE   `care_encounter`.`pid`=" & (Integer.Parse(txtId.Text)) & " ORDER BY `encounter_nr` DESC  LIMIT 10"

            Comd = New MySqlCommand(qry, myConn)

            dtlaAdapter.SelectCommand = Comd
            dtlaAdapter.Fill(factlist)
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConn.Close()
        End Try
        myConn.Close()



        listerencontre.DataSource = factlist

        'je cache et je renomme les colonne 
        With listerencontre

            .Columns("encounter_nr").HeaderCell.Value = "N. Rencontre"
            .Columns("encounter_nr").ReadOnly = True
            .Columns("encounter_nr").Width = 150
            .Columns("encounter_date").HeaderCell.Value = "Date Rencontre"
            .Columns("encounter_date").Width = 150
            .Columns("encounter_date").ReadOnly = True

            ' .Columns("encounter_nr").Width = 200
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            Dim col As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
            col.HeaderText = "A Considerer"
            listerencontre.Columns.Add(col)
            'listerencontre.Columns("A Considerer").Width = 150


        End With

    End Sub

    Private Sub GetFactureInformation()

        'Dim PrescReader, PrescReader1 As MySqlDataReader
        Dim dtaDataTable As New DataTable
        Dim dtaAdapter As New MySqlDataAdapter

        Dim factcredit As New DataTable

        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        ' If DataGridView1.GetRowCount Then
        Try
            myConn.Open()
            qry = "SELECT `care_billing_payment`.`encounter_nr`,`care_billing_payment`.`receipt_no`,`care_billing_payment`.`datebilled`,`care_billing_payment`.`datepaid`,`care_billing_payment`.`typepaiement`,`care_billing_payment`.`encaisseur`,`care_billing_payment`.`factureur`," & _
                " CASE" & _
                " WHEN `care_billing_payment`.`typepaiement`='normal' THEN `care_billing_payment`.`billtotal`" & _
                " WHEN `care_billing_payment`.`typepaiement`='bon' THEN `care_billing_credit`.`billamount`" & _
                " END AS montantfacture, `care_billing_credit`.`patientamount`,`care_billing_credit`.`firmamount`" & _
                " FROM `care_billing_payment`" & _
                " LEFT OUTER JOIN `care_billing_credit` ON `care_billing_payment`.`receipt_no` = `care_billing_credit`.`billno`" & _
                " WHERE   `care_billing_payment`.`encounter_nr` IN " & liste & _
                " AND" & _
                " CASE" & _
                " WHEN `care_billing_payment`.`typepaiement`='normal' THEN `care_billing_payment`.`datepaid` NOT IN ('NULL')" & _
                " WHEN `care_billing_payment`.`typepaiement`='bon' THEN `care_billing_payment`.`datebilled` NOT IN ('NULL')" & _
                " End" & _
                " ORDER BY `datebilled` DESC"



            Comd = New MySqlCommand(qry, myConn)

            dtaAdapter.SelectCommand = Comd
            dtaAdapter.Fill(factcredit)
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConn.Close()

        DataGridView1.DataSource = factcredit

        'je cache et je renomme les colonne 
        With DataGridView1
            .Columns("encounter_nr").Visible = False

            .Columns("receipt_no").HeaderCell.Value = "N. Facture"
            .Columns("receipt_no").ReadOnly = True

            .Columns("datebilled").HeaderCell.Value = "D. Facture"
            .Columns("datebilled").ReadOnly = True

            .Columns("datepaid").HeaderCell.Value = "D. Paiement"
            .Columns("datepaid").ReadOnly = True

            .Columns("typepaiement").HeaderCell.Value = "T. Fact."
            .Columns("typepaiement").ReadOnly = True

            .Columns("encaisseur").HeaderCell.Value = "Ag. Encai."
            .Columns("encaisseur").ReadOnly = True

            .Columns("factureur").HeaderCell.Value = "Ag. Fact."
            .Columns("factureur").ReadOnly = True

            .Columns("montantfacture").HeaderCell.Value = "M. Fact."
            .Columns("montantfacture").ReadOnly = True

            .Columns("patientamount").HeaderCell.Value = "M. Patient"
            .Columns("patientamount").ReadOnly = True

            .Columns("firmamount").HeaderCell.Value = "M. Societe"
            .Columns("firmamount").ReadOnly = True
            ' .Columns("receipt_no").HeaderCell.Value = "N. Facture"
            ' .Columns("receipt_no").ReadOnly = True
            ' .Columns("datebilled").HeaderCell.Value = "Facturé le"
            '  .Columns("datebilled").ReadOnly = True
            '  .Columns("datepaid").HeaderCell.Value = "Payé le"
            ' .Columns("datepaid").ReadOnly = True
            ' .Columns("billtotal").HeaderCell.Value = "Total Fact."
           
            ' .Columns("encounter_nr").HeaderCell.Value = "N. Rencontre"
            ' .Columns("encounter_nr").Width = 200
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            'Dim col As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
            'col.HeaderText = "A Facturé"
            'DataGridView1.Columns.Add(col)

        End With

    End Sub

    Private Sub validerrencontre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles validerrencontre.Click
        Dim coche As Integer = 0

        For i As Integer = 0 To (listerencontre.Rows.Count - 1)
            If listerencontre.Rows(i).Cells(2).Value = True Then
                coche = coche + 1
            End If
        Next

        If coche > 0 Then

            liste = ""
            Dim tour As Integer = 0
            For j As Integer = 0 To (listerencontre.Rows.Count - 1)

                If listerencontre.Rows(j).Cells(2).Value = True Then
                    If tour = 0 Then
                        liste = " (" & listerencontre.Rows(j).Cells(0).Value '& ""

                    Else
                        liste = liste & " ," & listerencontre.Rows(j).Cells(0).Value '& ""

                    End If

                    tour = tour + 1
                End If

            Next
            liste = liste & ")"
            GetFactureInformation()
            impression.Visible = True

        Else

            MsgBox("Selectionner une rencontre")

        End If



    End Sub

    Private Sub affichercrystalreport()
        'ByVal rencontre As ULong, ByVal numero As Integer
        Dim ds As New DataSet1()
        ' Dim rencontre As ULong
        ' Dim numero As Integer

        'recuperation des informations 

        'affectation de la bd
        rpt.SetDataSource(dtaDataTable)


        ' affectation des autres element constitutif de la facture
        rpt.SetParameterValue("total", montantfacture)
        rpt.SetParameterValue("reste", montantfacture)
        rpt.SetParameterValue("verse", 0)
        rpt.SetParameterValue("agentcaisse", encaisseur)
        rpt.SetParameterValue("agentfacturation", factureur)
        rpt.SetParameterValue("billnum", receipt_no)
        rpt.SetParameterValue("patient", nom)
        rpt.SetParameterValue("pid", pid)
        rpt.SetParameterValue("encounter", encounter_nr)

        If isbon(encounter_nr, receipt_no) Then

            rpt.SetParameterValue("payee", patientamount)
            rpt.SetParameterValue("payement", etatfacture)

            rpt.SetParameterValue("societe", "Societé: " & FirmName)
            rpt.SetParameterValue("charge", "CREDIT STE:")
            rpt.SetParameterValue("montantcharge", firmamount & "  CFA")
            rpt.SetParameterValue("assure", "Assuré: " & ContactName)
        Else
            rpt.SetParameterValue("payee", montantfacture)
            rpt.SetParameterValue("payement", "PAYE:")
            rpt.SetParameterValue("charge", "")
            rpt.SetParameterValue("montantcharge", "")
            rpt.SetParameterValue("societe", "")
            rpt.SetParameterValue("assure", "")
        End If

        rpt.SetParameterValue("datefacture", datepaid)

        'rpt.PrintOptions.PaperSize.

        CrystalReportViewer.ReportSource = rpt

    End Sub

    Function isbon(ByVal rencontre As ULong, ByVal numero As Integer) As Boolean
        'verifie si on a à faire à un bon
        Dim bon As Boolean
        Dim type As String = "normal"
        bon = False

        Try
            myConn3.Open()
            qry3 = "SELECT `typepaiement` FROM `care_billing_payment` WHERE `encounter_nr`=" & rencontre & " AND `receipt_no`=" & numero & " ORDER BY datebilled DESC LIMIT 1"
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

    Private Sub affiche_element_complet_paye(ByVal rencontre As ULong, ByVal numero As Integer)

        dtaDataTable.Clear()

        Try
            myConn.Open()
            dtaDataTable.Reset()
            qry = "SELECT `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & rencontre & "  AND  `islab`=0 AND `bill_no`=" & numero & " ORDER BY  article" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)

            dtaAdapter.SelectCommand = Comd
            dtaAdapter.Fill(dtaDataTable)
            myConn.Close()

            If ilyalabetproduit(rencontre, numero) Then
                myConn.Open()
                qry = "SELECT SUM(`amount`) as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & rencontre & "  AND  `islab`=0 AND `bill_no`=" & numero
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
            qry = "SELECT `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & rencontre & "  AND  `islab`=1 AND `bill_no`=" & numero & " ORDER BY  article" 'AND `bill_number`=0"
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

            If ilyalabetproduit(rencontre, numero) Then
                myConn.Open()
                qry = "SELECT SUM(`amount`) as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & rencontre & "  AND  `islab`=1 AND `bill_no`=" & numero  'AND `bill_number`=0"
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

    Function ilyalabetproduit(ByVal rencontre As ULong, ByVal numero As Integer) As Boolean

        Dim ilya As Boolean = False
        Dim lab As Boolean = False
        Dim prod As Boolean = False
        Dim qry As String
        'verification de la presence des prodeuits
        Try
            myConn.Open()
            qry = "SELECT *  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & rencontre & "  AND  `islab`=0 AND status='billed' AND `bill_no`=" & numero  'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                prod = True
            End If

            myConn.Close()
            '   Comd.ExecuteNonQuery()

            'verification de la presences des labo
            myConn.Open()
            qry = "SELECT *  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & rencontre & "  AND  `islab`=1 AND status='billed' AND `bill_no`=" & numero  'AND `bill_number`=0"
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

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim num As Integer
        datebilled = Nothing
        datepaid = Nothing


        num = DataGridView1.CurrentRow.Index
        'MsgBox(num.ToString)
        'billno = DataGridView1.Rows(num).Cells("billno").Value
        encounter_nr = DataGridView1.Rows(num).Cells("encounter_nr").Value
        receipt_no = DataGridView1.Rows(num).Cells("receipt_no").Value
        datebilled = DataGridView1.Rows(num).Cells("datebilled").Value
        If IsDBNull(DataGridView1.Rows(num).Cells("datepaid").Value) Then
            etatfacture = " CREDIT:"
            datepaid = datebilled
        Else
            datepaid = DataGridView1.Rows(num).Cells("datepaid").Value
            etatfacture = " PAYE:"
        End If

        typepaimenent = DataGridView1.Rows(num).Cells("typepaiement").Value
        encaisseur = DataGridView1.Rows(num).Cells("encaisseur").Value
        factureur = DataGridView1.Rows(num).Cells("factureur").Value
        montantfacture = DataGridView1.Rows(num).Cells("montantfacture").Value

        If IsDBNull(DataGridView1.Rows(num).Cells("patientamount").Value) Then
            patientamount = 0
        Else
            patientamount = DataGridView1.Rows(num).Cells("patientamount").Value
        End If

        If IsDBNull(DataGridView1.Rows(num).Cells("firmamount").Value) Then
            firmamount = 0
        Else
            firmamount = DataGridView1.Rows(num).Cells("firmamount").Value
        End If



        ' MsgBox(pid)
        'recuperation des elements de la facture
        affiche_element_complet_paye(encounter_nr, receipt_no)

        'affichage du crystalreport
        affichercrystalreport()


    End Sub

    Private Sub impression_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles impression.Click
        'impression du ticket
        rpt.PrintToPrinter(1, False, 0, 0)
        'rpt.PrintToPrinter(1, False, 0, 0)
        'CrystalReportViewer.PrintReport()
        'Controls.Clear()
        'InitializeComponent()
        ' Show()
    End Sub
End Class