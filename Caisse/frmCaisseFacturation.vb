Imports MySql.Data.MySqlClient

Public Class frmCaisseFacturation
    Public Property Permission As String
    Public Property Utilisateur As String
    'Public ServerString As String

    Dim myConn, myLabConn As New MySqlConnection
    Dim Comd, LabCmd As MySqlCommand
    Dim PrescReader, LabReader As MySqlDataReader
    Dim TotalSelect, EncounterPercent, TotalAssureur, TotalAssurer, TotalExclusion, billAmount, billNo, Exclusion, BonCfg As Integer
    Dim ConnMode, EncounterType, FirmName, ContactName, PatientRelation, PatientQuality As String
    Dim Encounter As ULong
    Dim DB As New MySQLDataBaseAccess(frmMain.ServerString)

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        'radPrescriptions.Checked = False
        'radPaiement.Checked = False
        txtTotalPay.Text = 0
        txtTotalToPay.Text = 0
        TotalSelect = 0
        grpCharge.Visible = False
        lblReste.Visible = False
        txtResteAPayer.Visible = False
        txtResteAPayer.Text = 0
        GetEncounterInformation()
        FillPrescriptionsLabs()
    End Sub

    '/----------------------------------------------------------------------------------
    '/ 
    '/ Description:
    '/      Ce module permet de rechercher les prescriptions, et examens de labo qui ne sont pas payes 
    '/      pour la facturation.  Les prescriptions se trouvent dans la table care_encounter_prescription
    '/      Les examens de laboratoire se trouves
    '/
    '/ Parametres a passer:
    '/      Aucun.
    '/
    '/  Resultat:
    '/      Les prescriptions et les examens de labo trouves sont listes dans un datagrid
    '/
    '/----------------------------------------------------------------------------------
    Private Sub FillPrescriptionsLabs()
        Dim Qry, Parameter, PrescribeDate As String
        Dim dtaAdapter As New MySqlDataAdapter
        Dim dtaDataTable As New DataTable
        Dim bindSource As New BindingSource

        Dim LabId, PrescId As Integer
        Dim newListRow As DataRow
        'dgvPrescriptions.Rows.Clear()
        'dgvPrescriptions.Columns.Clear()
        'dgvPrescriptions.Width = 60
        txtAssurer.Text = ""
        txtAssureur.Text = ""
        txtAssurer.Visible = False
        txtAssureur.Visible = False

        'dtaDataTable.DataSet.Clear()
        bindSource.DataSource = Nothing
        dgvPrescriptions.DataSource = Nothing

        Try
            'Get the prescriptions for that encounter
            myConn.Open()
            'Qry = "SELECT nr as Prescription, `article` as Article,`price` as Prix, SUM(`dosage`) as Qte, SUM(`price`*`dosage`) as Total, prescribe_date as Date, drug_class as Class FROM `care_encounter_prescription` WHERE `encounter_nr`=" & Encounter & " AND `bill_number`=0 GROUP BY nr"
            'Qry = "SELECT nr as Prescription, `article` as Article,`price` as Prix, SUM(`dosage`) as Qte, SUM(`price`*`dosage`) as Total, prescribe_date as Date, drug_class as Class FROM `care_encounter_prescription` WHERE `encounter_nr`=" & Encounter & " AND (bill_status IS NULL OR bill_status NOT IN ('billed', 'paid', 'avance'))  AND `bill_number`=0 GROUP BY nr"
            'Ceci pour prendre en compte toutes les factures impayes, meme celles des rencontres precedentes
            Qry = "SELECT nr as Prescription, `article` as Article,`price` as Prix, SUM(`dosage`) as Qte, SUM(`price`*`dosage`) as Total, prescribe_date as Date, drug_class as Class FROM `care_encounter_prescription` WHERE `encounter_nr` IN (SELECT encounter_nr FROM care_encounter WHERE pid=" & CLng(txtId.Text) & ") AND (bill_status IS NULL OR bill_status NOT IN ('billed', 'paid', 'avance'))  AND `bill_number`=0 GROUP BY nr"
            Comd = New MySqlCommand(Qry, myConn)
            'myConn.Close()
            dtaAdapter.SelectCommand = Comd

            dtaAdapter.Fill(dtaDataTable)
            dtaDataTable.Columns.Add("Facturé", GetType(Boolean))
            If Exclusion = 1 Then
                dtaDataTable.Columns.Add("Exclusion", GetType(Boolean))
            End If
            bindSource.DataSource = dtaDataTable
            'link to the datagridview
            dgvPrescriptions.DataSource = bindSource
            dtaAdapter.Update(dtaDataTable)
            myConn.Close()
            'Dim checkBoxCol As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
            'checkBoxCol.HeaderText = "Facturé"
            'checkBoxCol.ReadOnly = False
            'dgvPrescriptions.Columns.Add(checkBoxCol)

            dgvPrescriptions.Visible = True
            dtaDataTable.AcceptChanges()
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
                    newListRow("Prix") = CInt(LabReader.Item("Prix"))
                    newListRow("Qte") = 1
                    newListRow("Total") = CInt(LabReader.Item("Prix"))
                    newListRow("Prescription") = PrescId
                    newListRow("Date") = PrescribeDate
                    newListRow("Class") = "Laboratoire" 'rajout du 29 octobre 2015 - Daouda
                    'newListRow("islab") = 1
                    dtaDataTable.Rows.Add(newListRow)
                    dtaDataTable.AcceptChanges()
                    myLabConn.Close()
                Else
                    MsgBox("Ce patient n'a aucun examen de Labo.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Prescriptions!")
                End If
                dgvPrescriptions.ReadOnly = True
            End While

            If dtaDataTable.Rows.Count = 0 Then
            Else
                'Get the cumulated amount of the bill
                txtTotalToPay.Text = dtaDataTable.Compute("SUM(Total)", String.Empty).ToString
                TotalSelect = Integer.Parse(txtTotalToPay.Text)
                billAmount = TotalSelect
                txtTotalToPay.Text = FormatCurrency(txtTotalToPay.Text)
                txtTotalPay.Text = txtTotalToPay.Text
                txtTotalPay.Text = FormatCurrency(txtTotalPay.Text)
                'If EncounterPercent > 0 Then
                If BonCfg > 0 Then
                    'Verifier si c'est la societe qui se charge de tout le paiement
                    'Verifier si la societe a un plafond
                    If ((BonCfg = 4) And (EncounterPercent = 100)) Then
                        TotalAssureur = TotalSelect * EncounterPercent / 100
                        TotalAssurer = billAmount - TotalAssureur
                        TotalSelect = TotalAssureur
                    ElseIf BonCfg = 5 And EncounterPercent = 0 Then
                        DB.AddParams("@assurance", FirmName)
                        Qry = "SELECT maxpay FROM care_insurances WHERE name=@assurance"
                        DB.ExecQuery(Qry)
                        If DB.RecordCount > 0 Then
                            'Total a payer par l'assurance
                            TotalAssureur = DB.DBDataTable.Rows(0).Item("maxpay")
                            If billAmount > TotalAssureur Then
                                'Total apayer par l'assure
                                TotalAssurer = billAmount - TotalAssureur
                                TotalSelect = TotalAssureur
                            End If
                        End If
                    Else
                        TotalAssurer = TotalSelect * EncounterPercent / 100
                        TotalAssureur = billAmount - TotalAssurer
                        TotalSelect = TotalAssurer

                    End If

                    'txtAssureur.Text = TotalAssureur
                    txtTotalToPay.Text = FormatCurrency(TotalSelect)
                    txtTotalPay.Text = TotalSelect
                    txtTotalPay.Text = FormatCurrency(txtTotalPay.Text)
                    txtResteAPayer.Text = billAmount 'CInt(txtAssurer.Text.Remove(txtAssurer.Text.Length - 1)) - CInt(txtTotalPay.Text.Remove(txtTotalPay.Text.Length - 1))
                    txtResteAPayer.Text = FormatCurrency(txtResteAPayer.Text)
                    'Part de l'assure
                    txtAssurer.Visible = True
                    txtAssurer.Text = TotalAssurer
                    txtAssurer.Text = FormatCurrency(txtAssurer.Text)
                    'Par de l'assurance
                    txtAssureur.Visible = True
                    txtAssureur.Text = FormatCurrency(TotalAssureur)
                    lblAssure.Visible = True
                    lblAssureur.Visible = True
                    grpCharge.Visible = True
                    txtResteAPayer.Visible = True
                    lblReste.Visible = True
                End If

                grpItems.Width = dgvPrescriptions.Width

                'Resize the columns of the datagridview
                dgvPrescriptions.AutoResizeColumns()
                dgvPrescriptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                For Each ColHead As DataGridViewColumn In dgvPrescriptions.Columns
                    ColHead.SortMode = DataGridViewColumnSortMode.NotSortable
                    dgvPrescriptions.Width += ColHead.Width
                Next

                grpInfo.Visible = True
                btnValidate.Visible = True
                grpItems.Width = dgvPrescriptions.Width
                grpItems.Visible = True
                grpTotal.Visible = True
                grpPrescriptions.Visible = True
                grpTotal.Visible = True
                ' Me.Height = 720
                'Me.Width = 765
                'Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
                'Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
            End If
            dgvPrescriptions.Columns("Prix").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvPrescriptions.Columns("Qte").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvPrescriptions.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvPrescriptions.Columns("Prescription").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvPrescriptions.Columns("Class").Visible = False 'Rajout du 29 octobre 2015 - Daouda

            For i As Integer = 0 To dgvPrescriptions.Rows.Count - 1
                dgvPrescriptions.Rows(i).Cells("Facturé").Value = True
            Next
            If Exclusion = 1 Then
                For i As Integer = 0 To dgvPrescriptions.Rows.Count - 1
                    dgvPrescriptions.Rows(i).Cells("Exclusion").Value = False
                Next
            End If
        Catch ex As MySqlException
            MsgBox("Pas de Connection à la base des donnés " & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur de Connexion!!!")
        Finally
            myConn.Dispose()
        End Try
    End Sub

    'Cette Sub routine recherche les informations de la visite du patient de la base des donnees p
    Private Sub GetEncounterInformation()

        Dim qry, Enc_Date, Patient_Name, Patient_Birth As String
        Dim dtaAdapter As New MySqlDataAdapter
        Dim dtaDataTable As New DataTable
        Dim bindSource As New BindingSource

        dgvPrescriptions.DataSource = Nothing
        dgvPrescriptions.Rows.Clear()
        dgvPrescriptions.Columns.Clear()
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
                    If Not IsDBNull(PrescReader.Item("insurance_firm")) Then
                        FirmName = PrescReader.Item("insurance_firm")
                    End If
                    If Not IsDBNull(PrescReader.Item("contact_name")) Then
                        ContactName = PrescReader.Item("contact_name")
                    End If
                    If Not IsDBNull(PrescReader.Item("contact_relation")) Then
                        PatientRelation = PrescReader.Item("contact_relation")
                    End If
                    If Not IsDBNull(PrescReader.Item("contact_relation")) Then
                        PatientRelation = PrescReader.Item("contact_relation")
                    End If
                    If Not IsDBNull(PrescReader.Item("quality")) Then
                        PatientQuality = PrescReader.Item("quality")
                    End If
                    If Not IsDBNull(PrescReader.Item("exclusion")) Then
                        Exclusion = PrescReader.Item("exclusion")
                    End If


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
 
    Private Sub dgvPrescriptions_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescriptions.CellContentClick
        Dim RowAmount, PercentAmount, TotalFacture As Integer

        RowAmount = dgvPrescriptions.Rows(e.RowIndex).Cells("Total").Value
        PercentAmount = dgvPrescriptions.Rows(e.RowIndex).Cells("Total").Value

        TotalFacture = billAmount

        'Verifier si c'est une configuration a exclusion. Prendre le total du produit:
        'dans la colonne derniere -1 si bon sans exclusion
        'dans la colonne derniere -2 si bon a exclusion

        'Verifier pourcentage pour calculer le pourcentage
        If EncounterPercent > 0 Then
            PercentAmount = PercentAmount * EncounterPercent / 100

        End If
        'Decocher ou recocher le montant d'un element de la facture, parceque cet element n'est 
        'pas dans la facturation
        If ((e.ColumnIndex = 7) And (e.RowIndex > -1)) Then 'Modification du 29 octobre 2015 - Daouda, c'etait e.columnindex=6
            If dgvPrescriptions.Rows(e.RowIndex).Cells("Facturé").Value = False Then
                dgvPrescriptions.Rows(e.RowIndex).Cells("Facturé").Value = True

                TotalSelect = TotalSelect + RowAmount
                'TotalAssurer = TotalAssurer + PercentAmount
                billAmount = billAmount + RowAmount
                'TotalAssureur=TotalAssu
            ElseIf dgvPrescriptions.Rows(e.RowIndex).Cells("Facturé").Value = True Then
                dgvPrescriptions.Rows(e.RowIndex).Cells("Facturé").Value = False
                'Verifier si l'element avait ete exclu
                'L'enlever puisqu'on ne peut exclure ce que nous n'avons pas facture
                If Exclusion = 1 Then
                    If dgvPrescriptions.Rows(e.RowIndex).Cells("Exclusion").Value = True Then
                        dgvPrescriptions.Rows(e.RowIndex).Cells("Exclusion").Value = False
                        TotalExclusion = TotalExclusion - RowAmount
                    End If
                End If
                TotalSelect = TotalSelect - RowAmount
                'TotalAssurer = TotalAssurer - PercentAmount
                billAmount = billAmount - RowAmount
            End If
        End If
        TotalAssurer = billAmount * EncounterPercent / 100
        'Verifier l'exclusion.
        'Elle n'est valide que si l'element est facture
        If ((e.ColumnIndex = 8) And (e.RowIndex > -1)) Then 'Modification du 29 octobre 2015 - Daouda, c'etait e.columnindex=7
            If dgvPrescriptions.Rows(e.RowIndex).Cells("Facturé").Value = True Then
                If dgvPrescriptions.Rows(e.RowIndex).Cells("Exclusion").Value = False Then
                    dgvPrescriptions.Rows(e.RowIndex).Cells("Exclusion").Value = True
                    TotalExclusion = TotalExclusion + RowAmount
                    'billAmount = billAmount + TotalExclusion
                Else
                    dgvPrescriptions.Rows(e.RowIndex).Cells("Exclusion").Value = False
                    TotalExclusion = TotalExclusion - RowAmount
                    'billAmount = billAmount - TotalExclusion
                End If
            Else
                'TotalExclusion = 0
            End If
            'billAmount = billAmount + TotalExclusion
            TotalAssurer = ((billAmount - TotalExclusion) * EncounterPercent / 100) + TotalExclusion
            TotalAssureur = billAmount - ((billAmount - TotalExclusion) * EncounterPercent / 100)
        End If


        If ((EncounterType = "Société") And (EncounterPercent = 100)) Then
            TotalAssurer = 0
        End If

        If EncounterPercent > 0 Then
            txtTotalPay.TextAlign = HorizontalAlignment.Right
            txtTotalPay.Text = FormatCurrency(TotalAssurer)
            If (EncounterType = "Société") And EncounterPercent = 100 Then
                txtTotalPay.Text = FormatCurrency(billAmount)
            End If

        Else
            txtTotalPay.TextAlign = HorizontalAlignment.Right
            txtTotalPay.Text = FormatCurrency(billAmount)
        End If
        'Total Facture
        txtResteAPayer.Text = FormatCurrency(billAmount)
        txtResteAPayer.TextAlign = HorizontalAlignment.Center

        'Total assurer
        txtAssurer.Text = FormatCurrency(TotalAssurer)
        txtAssurer.TextAlign = HorizontalAlignment.Center

        'Total assureur
        txtAssureur.Text = FormatCurrency(billAmount - TotalAssurer)
        txtAssureur.TextAlign = HorizontalAlignment.Center

        txtTotalToPay.TextAlign = HorizontalAlignment.Right
        txtTotalToPay.Text = TotalSelect
        txtTotalToPay.Text = FormatCurrency(txtTotalToPay.Text)

        'txtTotalExclusion.Text = TotalExclusion
    End Sub

    Private Sub frmSearch_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtTotalPay.TextAlign = HorizontalAlignment.Right
        myConn = New MySqlConnection
        myLabConn = New MySqlConnection
        myConn.ConnectionString = frmMain.ServerString
        myLabConn.ConnectionString = frmMain.ServerString
        Me.Utilisateur = frmMain.Utilisateur
        'dgvPrescriptions.Width = 60
        'grpItems.Width = 60
        Me.Text = Me.Text & " - " & frmMain.Utilisateur
        TotalSelect = 0
        TotalExclusion = 0
    End Sub

    Private Sub txtId_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtId.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            btnSearch_Click(sender, e)

        End If
    End Sub

    Private Sub dgvPrescriptions_ColumnHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPrescriptions.ColumnHeaderMouseClick
        dgvPrescriptions.Columns(e.ColumnIndex).SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub

    Public Sub FillBillItem()
        Dim Prescription, Qte, Prix, Total, isLab As Integer
        Dim Article, Qry, EltClass As String 'Rajout EltClass du 29 octobre 2015 - Daouda
        '        Me.StartPosition = FormStartPosition.CenterScreen
        Try

            'Verifier si la facturation a deja ete faite
            Dim ToPay = CInt(txtTotalPay.Text.Remove(txtTotalPay.Text.Length - 1))
            Dim Paid = CInt(txtTotalPay.Text)
            Dim Remain = ToPay - Paid
           
            'Il n'y a rien dans la base des donnees cree donc cette facture pour la premiere fois
            Qry = "INSERT INTO care_billing_bill (encounter_nr, date, amount, billgeneral, agent) " & _
                "VALUES (" & Encounter & ",'" & Now().ToString("yyyy-MM-dd hh:mm") & "'," & ToPay & "," & billAmount & ",'" & Me.Utilisateur & "')"
            myConn.Open()
            Comd = New MySqlCommand(Qry, myConn)
            Comd.ExecuteNonQuery()
            myConn.Close()
            Qry = "SELECT bill_no, amount FROM care_billing_bill WHERE encounter_nr=" & Encounter & " AND amount=" & ToPay & " ORDER BY bill_no DESC"
            myConn.Open()
            Comd = New MySqlCommand(Qry, myConn)
            PrescReader = Comd.ExecuteReader
            PrescReader.Read()
            billAmount = PrescReader.Item("amount")
            billNo = PrescReader.Item("bill_no")
            myConn.Close()

            'Update the bill no of the billing_item table
            'Insert the new data in the billing_bill_item
            'Qry = "UPDATE `care_billing_bill_item` LEFT JOIN `care_billing_bill` ON `care_billing_bill`.`encounter_nr`= `care_billing_bill_item`.`encounter_nr` SET `care_billing_bill_item`.`bill_no`=`care_billing_bill`.`bill_no` WHERE `care_billing_bill_item`.`encounter_nr`=" & Encounter
            'myConn.Open()
            'Comd = New MySqlCommand(Qry, myConn)
            'Comd.ExecuteNonQuery()
            'myConn.Close()

            'Inserrer les donnes dnas la table de paiements

            If BonCfg > 0 Then
                Qry = "INSERT INTO care_billing_payment (encounter_nr, receipt_no, datebilled, billtotal,  factureur, typepaiement) " & _
                     "VALUES (" & Encounter & "," & billNo & ",'" & Now().ToString("yyyy-MM-dd HH:MM") & "'," & billAmount & ",'" & Me.Utilisateur & "', 'bon')"
            Else
                Qry = "INSERT INTO care_billing_payment (encounter_nr, receipt_no, datebilled, billtotal,  factureur, typepaiement) " & _
                     "VALUES (" & Encounter & "," & billNo & ",'" & Now().ToString("yyyy-MM-dd HH:MM") & "'," & billAmount & ",'" & Me.Utilisateur & "', 'normal')"
            End If
            myConn.Open()
            Comd = New MySqlCommand(Qry, myConn)
            Comd.ExecuteNonQuery()
            myConn.Close()
            'Verifier si ce n'est pas un bon de prise en charge

            If BonCfg > 0 Then
                billAmount = CInt(txtAssurer.Text.Remove(txtAssurer.Text.Length - 1)) + CInt(txtAssureur.Text.Remove(txtAssureur.Text.Length - 1))
                Qry = "INSERT INTO care_billing_credit (encounter_nr, billamount, patientamount, firmamount, billno, typebon, status) " & _
                       "VALUES (" & Encounter & "," & billAmount & "," & CInt(txtAssurer.Text.Remove(txtAssurer.Text.Length - 1)) & "," & CInt(txtAssureur.Text.Remove(txtAssureur.Text.Length - 1)) & _
                       "," & billNo & ",'" & EncounterType & "', 'billed')"
                myConn.Open()
                Comd = New MySqlCommand(Qry, myConn)
                Comd.ExecuteNonQuery()
                myConn.Close()
            Else
                'billAmount = PrescReader.Item("amount")
                'billNo = PrescReader.Item("bill_no")
                'MsgBox("Ces donnees existent deja!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur")
                myConn.Close()
            End If
                'Fill in the bill_item table with all the prescriptions

            For Each dtr As DataGridViewRow In dgvPrescriptions.Rows
                If dtr.Cells("Facturé").Value = True Then
                    Prescription = Integer.Parse(dtr.Cells("Prescription").Value)
                    Qte = Integer.Parse(dtr.Cells("Qte").Value)
                    Prix = Integer.Parse(dtr.Cells("prix").Value)
                    Total = Integer.Parse(dtr.Cells("total").Value)
                    Article = dtr.Cells("Article").Value
                    EltClass = dtr.Cells("Class").Value
                    'Verifier l'existance de ces donnees dans la table afin d'eviter les doublons
                    Qry = "SELECT id FROM care_billing_bill_item WHERE " & _
                        " encounter_nr=" & Encounter & _
                        " AND code=" & Prescription & _
                        " AND unit_cost=" & Prix & _
                        " AND units=" & Qte & _
                        " AND amount=" & Total & _
                        " AND status='billed'"

                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)
                    PrescReader = Comd.ExecuteReader
                    PrescReader.Read()

                    'Si les donnees ne sont pas deja dans la table, les inserrer
                    If PrescReader.HasRows = False Then
                        myConn.Close()

                        If String.Equals(EltClass, "Laboratoire") Then
                            isLab = 1
                            'Mettre a jour l'element dans la table 
                            'Qry = "UPDATE `care_test_request_chemlabor`  SET `bill_status`='billed' WHERE `encounter_nr`=" & Encounter & " AND batch_nr=" & Prescription
                            'myLabConn.Open()
                            'Comd = New MySqlCommand(Qry, myLabConn)
                            'Comd.ExecuteNonQuery()
                            'myLabConn.Close()
                        Else
                            isLab = 0
                            'Mettre a jour la table des prescriptions pour ne plus avoir la liste de ses elements si ils sont deja factures

                        End If
                        Qry = "UPDATE `care_encounter_prescription`  SET `bill_status`='billed' WHERE `encounter_nr`=" & Encounter & " AND nr=" & Prescription
                        myLabConn.Open()
                        Comd = New MySqlCommand(Qry, myLabConn)
                        Comd.ExecuteNonQuery()
                        myLabConn.Close()
                        'Inserer les donnees dans la table bill_item - Rajouter le champ class le 29 octobre 2015
                        Qry = "INSERT INTO care_billing_bill_item (encounter_nr, code, article, unit_cost, units, amount, date, status, islab, bill_no, class) " & _
                                "VALUES (" & Encounter & "," & Prescription & ",""" & Article & """," & Prix & "," & Qte & "," & Total & ",'" & Now().ToString("yyyy-MM-dd hh-mm-ss") & "'," & "'billed'," & isLab & "," & billNo & ",'" & EltClass & "')"
                        myConn.Open()
                        Comd = New MySqlCommand(Qry, myConn)
                        Comd.ExecuteNonQuery()
                        myConn.Close()
                    Else
                        'Exit Sub
                        MsgBox("Ces donnees existent deja!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur")
                        myConn.Close()
                    End If
                End If
            Next
                myConn.Close()

            grpPrescriptions.Visible = True

        Catch ex As Exception
            myConn.Close()
            MsgBox("Erreur d'access a la base des donnees!! " & ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly)
        Finally
            myConn.Dispose()
        End Try
        MsgBox("Facturation terminer avec success! Rechercher un autre patient", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
        'Me.Close()
        'FacurationToolStripMenuItem_Click(se
    End Sub


    Private Sub txtTotalPay_LostFocus(sender As Object, e As EventArgs)
        If EncounterPercent > 0 Then
            If (CInt(txtTotalPay.Text) > CInt(txtAssurer.Text.Remove(txtAssurer.Text.Length - 1))) Then
                MsgBox("Montant a verser est superieure au montant a payer!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!")
                txtTotalPay.Focus()
                Exit Sub
            Else
                txtResteAPayer.Text = CInt(txtAssurer.Text.Remove(txtAssurer.Text.Length - 1) - txtTotalPay.Text)
                txtResteAPayer.Text = FormatCurrency(txtResteAPayer.Text)
                txtTotalPay.Text = FormatCurrency(txtTotalPay.Text)
            End If
        Else
            If (CInt(txtTotalPay.Text) > CInt(txtTotalToPay.Text.Remove(txtTotalToPay.Text.Length - 1))) Then
                MsgBox("Montant a verser est superieure au montant a payer!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!")
                txtTotalToPay.Focus()
                Exit Sub
            Else
                txtResteAPayer.Text = CInt(txtTotalToPay.Text.Remove(txtTotalToPay.Text.Length - 1) - txtTotalPay.Text)
                txtResteAPayer.Text = FormatCurrency(txtResteAPayer.Text)
                txtTotalPay.Text = FormatCurrency(txtTotalPay.Text)
            End If
        End If
    End Sub

    Private Sub txtTotalPay_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnValidate_Click(sender As System.Object, e As System.EventArgs) Handles btnValidate.Click
        FillBillItem()
        Controls.Clear()
        InitializeComponent()
        txtId.Focus()
        Show()
    End Sub
End Class