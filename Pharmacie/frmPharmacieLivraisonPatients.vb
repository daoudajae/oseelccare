Imports MySql.Data.MySqlClient

Public Class frmPharmacieLivraisonPatients
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
    Dim Qry As String
    Dim Numfacture As ULong


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        'Search for the user Information
        cboFactures.Items.Clear()
        Encounter = GetPatientInformation(txtId, txtInfos)
        DB.AddParams("@encounter", Encounter)
        Qry = "SELECT DISTINCT(bill_no) FROM care_billing_bill_item WHERE status IN  ('paid', 'partial', 'avance') AND class IN ('INJECTABLES', 'MEDICAMENTS', 'POMADES', 'SOLLUTES', 'SUPPOSITOIRES', 'SUSPENSION', 'VACCINS') AND livrer=0 AND encounter_nr=@encounter " & _
            "ORDER BY bill_no DESC"
        Fillcbo(DB, cboFactures, Qry)
        If DB.RecordCount > 0 Then
            cboFactures.SelectedIndex = 0
            lblNoProduct.Visible = False
            dgvPrescriptions.Visible = True
            btnValidate.Enabled = True
        Else
            dgvPrescriptions.Visible = False
            btnValidate.Enabled = False
            lblNoProduct.Visible = True
        End If
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
    Private Sub GetPaidPharmacyItems()
        Dim qry As String
        Dim dtaAdapter As New MySqlDataAdapter
        Dim dtaDataTable As New DataTable
        Dim bindSource As New BindingSource

        'If dgvPrescriptions.Rows.Count > 0 Then

        'dgvPrescriptions.Rows.Clear()
        'dgvPrescriptions.Columns.Clear()
        'End If
        'dtaDataTable.DataSet.Clear()
        bindSource.DataSource = Nothing
        dgvPrescriptions.DataSource = Nothing

        Try
            'Get the prescriptions for that encounter
            myConn.Open()

            qry = "SELECT `id`, `article` as Article, `units` as Qte FROM `care_billing_bill_item`  WHERE `status` IN ('paid', 'partial', 'avance') AND  `class` IN ('INJECTABLES', 'MEDICAMENTS', 'POMADES', 'SOLLUTES', 'SUPPOSITOIRES', 'SUSPENSION', 'VACCINS') AND `livrer`=0 AND bill_no=" & CLng(cboFactures.Text)
            Comd = New MySqlCommand(qry, myConn)
            'myConn.Close()
            dtaAdapter.SelectCommand = Comd

            dtaAdapter.Fill(dtaDataTable)
            dtaDataTable.Columns.Add("Livré", GetType(Boolean))

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

            If dtaDataTable.Rows.Count = 0 Then
                lblNoProduct.Visible = True
            Else
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
                grpPrescriptions.Visible = True
                'Me.Height = 720
                'Me.Width = 765
                'Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
                'Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
            End If
            dgvPrescriptions.Columns("Article").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvPrescriptions.Columns("Qte").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvPrescriptions.Columns("id").Visible = False

            For i As Integer = 0 To dgvPrescriptions.Rows.Count - 1
                dgvPrescriptions.Rows(i).Cells("Livré").Value = True
            Next

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

    Private Sub dgvPrescriptions_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescriptions.CellContentClick

    End Sub

    Private Sub frmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myConn = New MySqlConnection
        myLabConn = New MySqlConnection
        myConn.ConnectionString = frmMain.ServerString
        myLabConn.ConnectionString = frmMain.ServerString
        Me.Utilisateur = frmMain.Utilisateur
        Me.Permission = frmMain.Permission
        lblNoProduct.Visible = False
        'dgvPrescriptions.Width = 60
        'grpItems.Width = 60
        Me.Text = Me.Text & " - " & frmMain.Utilisateur
    End Sub

    Private Sub txtId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtId.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            btnSearch_Click(sender, e)

        End If
    End Sub

    Private Sub dgvPrescriptions_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPrescriptions.ColumnHeaderMouseClick
        dgvPrescriptions.Columns(e.ColumnIndex).SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub

    Public Sub UpdateLivraison()
        Dim Qry, Pharma, Article, User As String
        Dim StockTotal, StockPharma, ResteStockTotal, ResteStockPharma, Qte, ArticleId As Integer
        'Dim MsgResult As Integer
        '        Me.StartPosition = FormStartPosition.CenterScreen
        Try
            For Each dtr As DataGridViewRow In dgvPrescriptions.Rows
                If dtr.Cells("Livré").Value = True Then
                    'Mettre a jour les donnees dans la table bill_item
                    Article = dtr.Cells("Article").Value.ToString
                    Qte = CInt(dtr.Cells("Qte").Value)

                    'Chercher a mettre a jour a mettre a jour les tock restant dans la pharmacie concernee
                    'Chercher la pharmacie qui est connectee
                    Pharma = ""
                    If (String.Equals(Me.Permission, "Admin")) Or (String.Equals(Me.Permission, "admin")) Then
                        Qry = "SELECT level FROM care_users WHERE personell_nr=1 AND level LIKE '%pharmacie%'"
                        myConn.Open()
                        Comd = New MySqlCommand(Qry, myConn)
                        PrescReader = Comd.ExecuteReader
                        PrescReader.Read()
                        If PrescReader.HasRows Then
                            User = PrescReader.Item("level").ToString
                            myConn.Close()
                            Pharma = Pharmacie(User)
                        Else
                            MsgBox("Pharma is empty")
                        End If


                    Else
                        Pharma = Pharmacie(Me.Permission)
                    End If

                    If String.IsNullOrEmpty(Pharma) = False Then
                        'Receuillir les quantites du stock total et les quantite du stock de la pharmacie concernee
                        Qry = "SELECT item_id as id, quantity, " & Pharma & " FROM care_tz_drugsandservices WHERE item_description='" & Article & "'"
                        myConn.Open()
                        Comd = New MySqlCommand(Qry, myConn)
                        PrescReader = Comd.ExecuteReader
                        PrescReader.Read()
                        If PrescReader.HasRows Then
                            'Recuperer le stock des produits actuel
                            StockTotal = CInt(PrescReader.Item("quantity").ToString)
                            StockPharma = CInt(PrescReader.Item(Pharma).ToString)
                            ArticleId = CInt(PrescReader.Item("id").ToString)
                            myConn.Close()

                            'Soustraire les produits a livrer des stock respectifs
                            ResteStockTotal = StockTotal - Qte
                            ResteStockPharma = StockPharma - Qte

                            'Mettre a jour les stocks des produits 
                            Qry = "UPDATE care_tz_drugsandservices SET quantity=" & ResteStockTotal & ", " & Pharma & "=" & ResteStockPharma & " WHERE item_id=" & ArticleId
                            myConn.Open()
                            Comd = New MySqlCommand(Qry, myConn)
                            Comd.ExecuteNonQuery()
                            myConn.Close()

                            'Mettre a jour la livraison
                            Qry = "UPDATE care_billing_bill_item SET livrer=1, livrerle='" & Now().ToString("yyyy-MM-dd hh-mm-ss") & "', livrerpar='" & Me.Utilisateur & "' WHERE `id`=" & CULng(dtr.Cells("id").Value) & ""
                            myConn.Open()
                            Comd = New MySqlCommand(Qry, myConn)
                            Comd.ExecuteNonQuery()
                            myConn.Close()
                        End If
                    Else
                        MsgBox("Aucune pharmacie n'est connectee pour l'instant", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Livraison Produits")
                        Me.Close()
                    End If
                Else
                    'Exit Sub
                    'MsgBox("Ces donnees existent deja!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur")
                    myConn.Close()
                End If
            Next
            myConn.Close()
            grpPrescriptions.Visible = True
            MsgBox("Livraison terminer avec success! Rechercher un autre patient", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly)
            lblNoProduct.Visible = False

        Catch ex As Exception
            myConn.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly)
        Finally
            myConn.Dispose()
        End Try
        'Me.Close()
        'FacurationToolStripMenuItem_Click(se
    End Sub


    Private Sub txtTotalPay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnValidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidate.Click
        UpdateLivraison()
        Controls.Clear()
        InitializeComponent()
        txtId.Focus()
        Show()
    End Sub

    Private Sub txtId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtId.TextChanged

    End Sub

    Private Sub txtInfos_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtInfos.TextChanged

    End Sub

    Private Sub cboFactures_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboFactures.SelectedIndexChanged
        GetPaidPharmacyItems()
    End Sub
End Class