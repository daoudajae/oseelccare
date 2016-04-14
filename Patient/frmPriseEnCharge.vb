Imports MySql.Data.MySqlClient

Public Class frmPriseEnCharge
    Public Property Utilisateur As String
    Public Property Permission As String
    Public Property ConString As String
    Public Property Id As Long

    Dim myConn As New MySqlConnection
    Dim Comd As MySqlCommand
    Dim Reader As MySqlDataReader
    Dim Encounter As Integer

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Public Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Dim qry, Enc_quality, Enc_Date, Enc_type, Enc_Contact, Enc_Relation, Enc_Firm As String
        myConn = New MySqlConnection
        Dim BonCfg, Enc_Percent, Enc_Exclusion As Integer ', Encounter As Integer
        myConn.ConnectionString = frmMain.ServerString

        grpInfo.Enabled = True

        txtContact.Text = ""
        txtDiscount.Text = ""
        'cboInsurance.SelectedIndex = -1
        'cboQuality.SelectedIndex = -1
        'cboRelation.SelectedIndex = -1
        'cboType.SelectedIndex = -1
        'chkExclusion.Checked = False

        If String.IsNullOrEmpty(txtSearch.Text) Then
            MsgBox("Vous devez saisir le numero du patient", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
            txtSearch.Focus()
            txtSearch.Clear()
            Exit Sub
        End If
        If Not IsNumeric(txtSearch.Text) Then
            MsgBox("Vous devez saisir le numero du patient", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
            txtSearch.Focus()
            Exit Sub
        End If
        If (Integer.Parse(txtSearch.Text) >= 10000000) Then
            Try
                'Get the encounter number, encounter date, config bon, encounter_type of the patient
                myConn.Open()
                qry = "SELECT exclusion, quality, encounter_nr, encounter_date, bonpercent, boncfg, encounter_type, insurance_firm, contact_name, contact_relation  FROM caredb.care_encounter WHERE pid=" & CULng(txtSearch.Text) & _
                    " AND is_discharged=0 ORDER BY encounter_date DESC LIMIT 1"
                '" AND boncfg>0  AND is_discharged=0 ORDER BY encounter_date DESC LIMIT 1"
                Comd = New MySqlCommand(qry, myConn)
                'Get the encounter number
                Reader = Comd.ExecuteReader
                Reader.Read()
                If Reader.HasRows = True Then
                    'Numero de rencontre
                    Encounter = Reader.Item("encounter_nr")
                    'Configuration du bon 1, 2, 3 etc
                    BonCfg = Reader.Item("boncfg")
                    'Date de la rencontre
                    Enc_Date = Reader.Item("encounter_date")
                    'Type du bon de prise en charge, personnel, clerge, 100%
                    Enc_type = Reader.Item("encounter_type")
                    'Nom du contact
                    Enc_Contact = Reader.Item("contact_name")
                    'Nom de la firme d'assurance
                    Enc_Firm = Reader.Item("insurance_firm")
                    'Relation avec le patient parent, soi-meme, enfant, etc...
                    Enc_Relation = Reader.Item("contact_relation")
                    'Pourcentage du bon a payer
                    Enc_Percent = Reader.Item("bonpercent")
                    'Choisir si c'est une societe a exclusion
                    Enc_Exclusion = Reader.Item("exclusion")
                    'Qualite de la personne dans la societe cadre, non cadre, directeur etc...
                    Enc_quality = Reader.Item("quality")
                    myConn.Close()
                    '
                    'Get the Patient information
                    'myConn.Open()
                    'qry = "SELECT name_first, name_last, date_birth FROM caredb.care_person WHERE pid=" & CULng(txtSearch.Text)
                    'Comd = New MySqlCommand(qry, myConn)
                    'Get the encounter number
                    'Reader = Comd.ExecuteReader
                    'Reader.Read()
                    'If lblNoms.Text.Length < 6 Then
                    'lblNoms.Text = lblNoms.Text & " " & Reader.Item("name_last") & " " & Reader.Item("name_first")
                    'lblBirth.Text = lblBirth.Text & " " & Reader.Item("date_birth")
                    'lblEncounter.Text = lblEncounter.Text & " " & Encounter
                    txtInfos.ReadOnly = False
                    GetPatientInformation(txtSearch, txtInfos)
                    txtInfos.ReadOnly = True
                    'End If
                    If BonCfg = 0 Then
                        cboType.SelectedIndex = 0
                    ElseIf BonCfg = 1 Then
                        cboType.SelectedIndex = 1
                    ElseIf BonCfg = 2 Then
                        cboType.SelectedIndex = 2
                    ElseIf BonCfg = 3 Then
                        cboType.SelectedIndex = 3
                    End If
                    'Remplir les informations deja enregistrees s'il y en a
                    txtContact.Text = Enc_Contact

                    'Retrouver la compagnie d'assurance
                    cboInsurance.SelectedIndex = FindIndex(cboInsurance, Enc_Firm)

                    'Remplir le pourcentage du bon
                    txtDiscount.Text = Enc_Percent

                    'Remplir la relation entre l'assure et le patient
                    cboRelation.SelectedIndex = FindIndex(cboRelation, Enc_Relation)

                    'Remplir la qualite du patient
                    cboQuality.SelectedIndex = FindIndex(cboQuality, Enc_quality)
                    chkExclusion.Checked = Enc_Exclusion

                    myConn.Close()
                Else
                    MsgBox("Patient pas en viste actuellement.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!")
                    txtSearch.Focus()
                    Exit Sub
                End If
            Catch
                myConn.Close()
            Finally
                myConn.Dispose()
            End Try
        Else
            MsgBox("Patient pas en visite actuellement.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!")
            txtSearch.Focus()
        End If
    End Sub

    Private Sub frmPriseEnCharge_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim qry As String
        myConn = New MySqlConnection
        myConn.ConnectionString = frmMain.ServerString
        qry = "SELECT name FROM care_insurances"
        myConn.Open()
        Comd = New MySqlCommand(qry, myConn)
        Reader = Comd.ExecuteReader()
        While Reader.Read()
            cboInsurance.Items.Add(Reader.Item("name"))
        End While
        myConn.Close()
    End Sub

    Private Sub btnValidate_Click(sender As System.Object, e As System.EventArgs) Handles btnValidate.Click
        Dim qry As String
        myConn = New MySqlConnection
        'Dim BonCfg, Encounter As Integer
        myConn.ConnectionString = frmMain.ServerString
        If cboInsurance.Text.Trim = "" Then
            MsgBox("Veuillez choisir une assurence de la liste!", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Erreur!")
            cboInsurance.Focus()
            Exit Sub
        End If
        Try
            qry = "UPDATE care_encounter set boncfg=" & cboType.SelectedIndex + 1 & ", bonpercent='" & txtDiscount.Text & "'," & " encounter_type='" & cboType.Text & "', contact_name='" & txtContact.Text & "', insurance_firm='" & cboInsurance.Text & "', contact_relation='" & cboRelation.Text & "' WHERE encounter_nr=" & Encounter
            myConn.Open()
            Comd = New MySqlCommand(qry, myConn)
            Comd.ExecuteNonQuery()
            myConn.Close()
            If cboType.SelectedIndex = 3 Then
                qry = "UPDATE care_encounter set quality='" & cboQuality.Text & "', exclusion=" & chkExclusion.Checked & " WHERE encounter_nr=" & Encounter
                myConn.Open()
                Comd = New MySqlCommand(qry, myConn)
                Comd.ExecuteNonQuery()
                myConn.Close()
            End If
            MsgBox("Donnees enregistrees avec succes!", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Enregistrement!")
            btnValidate.Enabled = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboType.SelectedIndexChanged
        If cboType.SelectedIndex = 0 Then 'Bon a 100% normal
            txtDiscount.Text = 100
            cboQuality.Visible = False
            chkExclusion.Visible = False
            lblQuality.Visible = False
        ElseIf cboType.SelectedIndex = 1 Then 'Bon a 20% personnel
            txtDiscount.Text = 20
            cboQuality.Visible = False
            chkExclusion.Visible = False
            lblQuality.Visible = False
        ElseIf cboType.SelectedIndex = 2 Then 'Bon a 50% clerge
            txtDiscount.Text = 50
            cboQuality.Visible = False
            chkExclusion.Visible = False
            lblQuality.Visible = False
        ElseIf cboType.SelectedIndex = 3 Then 'Bon Societe
            txtDiscount.Text = 0
            cboQuality.Visible = True
            chkExclusion.Visible = True
            lblQuality.Visible = True
        ElseIf cboType.SelectedIndex = 4 Then 'Bon a plafond
            txtDiscount.Text = 0
            cboQuality.Visible = False
            chkExclusion.Visible = False
            lblQuality.Visible = False
        ElseIf cboType.SelectedIndex = 5 Then 'Bon de la mutuelle
            txtDiscount.Text = 0
            cboQuality.Visible = False
            chkExclusion.Visible = False
            lblQuality.Visible = False

        End If
    End Sub

    Private Sub cboInsurance_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboInsurance.SelectedIndexChanged
        btnValidate.Enabled = True
    End Sub

    Private Sub cboQuality_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboQuality.SelectedIndexChanged
        Dim frmPercent As New frmPercentPayment
        frmPercent.ShowDialog()
        If frmPercent.DialogResult = Windows.Forms.DialogResult.OK Then
            txtDiscount.Text = frmPercent.txtPercent.Text
        End If
    End Sub
End Class