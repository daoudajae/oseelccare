Imports MySql.Data.MySqlClient
Public Class frmBalancePatients

    Public Property Permission As String
    Public Property Utilisateur As String
    'Public ServerString As String

    Dim myConn, myConn1, myLabConn As New MySqlConnection
    Dim Comd, Comd1, LabCmd As MySqlCommand
    Dim PrescReader, LabReader As MySqlDataReader
    Dim TotalSelect, EncounterPercent, TotalAssureur, TotalAssurer, TotalExclusion, billAmount, billNo, Exclusion, BonCfg As Integer
    Dim ConnMode, EncounterType, FirmName, ContactName, PatientRelation, PatientQuality As String
    Dim Encounter As ULong
    Dim facturetotal, factureclient, facturesociete As Double
    Dim qry1, qry2, qry3, qry4, qry5, nom, liste As String

    Private Sub frmBalancePatients_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Utilisateur = frmMain.Utilisateur
        Me.Permission = frmMain.Permission
        Me.Text = Me.Text & " - " & frmMain.Utilisateur


        myConn.ConnectionString = frmMain.ServerString
        myConn1.ConnectionString = frmMain.ServerString
        myLabConn.ConnectionString = frmMain.ServerString

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
        Dim qry As String
        Dim factcredit As New DataTable

        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        ' If DataGridView1.GetRowCount Then
        Try
            myConn.Open()
            qry = "SELECT `care_billing_payment`.`receipt_no`, `care_billing_payment`.`datebilled`,`care_billing_payment`.`datepaid`,`care_billing_payment`.`billtotal`, `care_billing_payment`.`typepaiement`,`care_billing_payment`.`paid`  FROM `care_billing_payment`  WHERE   `care_billing_payment`.`encounter_nr` IN " & liste & " ORDER BY `datebilled` DESC"

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
            '.Columns("billamount").Visible = False
            '.Columns("patientamount").Visible = False
            '.Columns("billamount").Visible = False
            ' .Columns("encounter_nr").Visible = False
            '.RowHeadersVisible = False


            .Columns("receipt_no").HeaderCell.Value = "N. Facture"
            .Columns("receipt_no").ReadOnly = True
            .Columns("datebilled").HeaderCell.Value = "Facturé le"
            .Columns("datebilled").ReadOnly = True
            .Columns("datepaid").HeaderCell.Value = "Payé le"
            .Columns("datepaid").ReadOnly = True
            .Columns("billtotal").HeaderCell.Value = "Total Fact."
            .Columns("billtotal").ReadOnly = True
            .Columns("typepaiement").HeaderCell.Value = "Type Facture"
            .Columns("typepaiement").ReadOnly = True
            .Columns("paid").Visible = False
            ' .Columns("name_last").Width = 200
            '.Columns("datebilled").HeaderCell.Value = "Date Facturation"
            '.Columns("name_first").Width = 200
            '.Columns("typepaiement").HeaderCell.Value = "Type"
            ' .Columns("insurance_firm").Width = 200
            ' .Columns("contact_name").HeaderCell.Value = "Assuré"
            ' .Columns("contact_name").Width = 200
            ' .Columns("billamount").HeaderCell.Value = "Montant Total"
            '.Columns("patientamount").HeaderCell.Value = "M. Patient"
            '.Columns("firmamount").HeaderCell.Value = "M. Societe"
            '.Columns("patientpaid").HeaderCell.Value = "E.P Patient"
            '.Columns("firmpaid").HeaderCell.Value = "E.P. Societe"
            '.Columns("datepatientpaid").HeaderCell.Value = "D. Patient"
            '.Columns("datefirmpaid").HeaderCell.Value = "D. Societe"
            '.Columns("billno").HeaderCell.Value = "N. Facture"
            '.Columns("typebon").HeaderCell.Value = "Type Bon"
            '.Columns("status").HeaderCell.Value = "Statut"
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

            prescription()

        Else

            MsgBox("Selectionner une rencontre")

        End If



    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        GetEncounterInformation()
        GetEncounterList()
    End Sub

    Private Sub prescription()

        Dim qry, Parameter, PrescribeDate As String
        Dim dtaAdapter As New MySqlDataAdapter
        Dim dtaDataTable As New DataTable
        Dim bindSource As New BindingSource
        Dim LabId, PrescId As Integer
        Dim newListRow As DataRow

        dtaDataTable.Clear()
        dgvPrescriptions.DataSource = Nothing
        dgvPrescriptions.Rows.Clear()
        dgvPrescriptions.Columns.Clear()
        dgvPrescriptions.Refresh()

        Try
            'Get the prescriptions for that encounter
            myConn.Open()
            qry = "SELECT nr as Prescription, `article` as Article,`price` as Prix, SUM(`dosage`) as Qte, SUM(`price`*`dosage`) as Total, prescribe_date as Date, livrer as Servi FROM `care_encounter_prescription` WHERE `encounter_nr` IN " & liste & " AND `bill_number`=0 GROUP BY nr" 'AND bill_status NOT IN ('billed', 'paid')  
            Comd = New MySqlCommand(qry, myConn)
            'myConn.Close()
            dtaAdapter.SelectCommand = Comd

            dtaAdapter.Fill(dtaDataTable)
            bindSource.DataSource = dtaDataTable
            'link to the datagridview
            dgvPrescriptions.DataSource = bindSource
            myConn.Close()
            'Dim checkBoxCol As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
            'checkBoxCol.HeaderText = "Facturé"
            'checkBoxCol.ReadOnly = False
            'dgvPrescriptions.Columns.Add(checkBoxCol)

            dgvPrescriptions.Visible = True
            'Get the labs of a the patient
            myConn.Open()
            qry = "SELECT parameters, batch_nr, send_date FROM care_test_request_chemlabor WHERE encounter_nr=" & Encounter & " AND bill_status NOT IN ('billed', 'paid') AND `bill_number`=0 GROUP BY batch_nr"
            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader
            While PrescReader.Read()
                Parameter = PrescReader.Item("parameters")
                Parameter = Parameter.Substring(5, Parameter.Length - 5)
                LabId = CInt(Parameter.Remove(Parameter.Length - 1))
                PrescId = PrescReader.Item("batch_nr")
                PrescribeDate = PrescReader.Item("send_date")
                PrescribeDate = PrescribeDate.Substring(0, 10)
                qry = "SELECT name as Article, price as Prix, SUM(price) as Total FROM care_tz_laboratory_param WHERE id=" & LabId
                myLabConn.Open()
                LabCmd = New MySqlCommand(qry, myLabConn)
                LabReader = LabCmd.ExecuteReader
                LabReader.Read()
                If LabReader.HasRows = True Then
                    newListRow = dtaDataTable.NewRow
                    newListRow("Article") = LabReader.Item("Article")
                    newListRow("Prix") = LabReader.Item("Prix")
                    newListRow("Qte") = 1
                    newListRow("Total") = LabReader.Item("Prix")
                    newListRow("Prescription") = PrescId
                    newListRow("Date") = PrescribeDate
                    'newListRow("islab") = 1
                    dtaDataTable.Rows.Add(newListRow)
                    dtaDataTable.AcceptChanges()
                    myLabConn.Close()
                Else
                    MsgBox("Ce patient n'a aucun examen de Labo.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Prescriptions!")
                End If
                dgvPrescriptions.ReadOnly = True
            End While

            
            dgvPrescriptions.Columns("Prix").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvPrescriptions.Columns("Qte").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvPrescriptions.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvPrescriptions.Columns("Prescription").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            
        Catch ex As MySqlException
            MsgBox("Pas de Connection à la base des donnés " & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur de Connexion!!!")
            myConn.Close()
        Finally
            myConn.Close()
        End Try

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim Rapport As String

        Rapport = "GAROUA-BOULAI "
        Export_Data_Excel(dgvPrescriptions, Rapport, Me.Utilisateur)
    End Sub
End Class