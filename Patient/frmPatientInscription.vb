Imports MySql.Data.MySqlClient

Public Class frmPatientInscription
    Public Property Permission As String
    Public Property Utilisateur As String
    Public Property Qte As Integer
    'Public ServerString As String

    Dim myConn, myLabConn As New MySqlConnection
    Dim Comd, LabCmd As MySqlCommand
    Dim PrescReader, LabReader As MySqlDataReader
    Dim ArticleNumber, EncounterPercent, Price As Integer
    Dim Article, DrugClass, PrescribeDate, Precriber, History, WhereClose, Qry, LabQry As String
    Dim TotalSelect, TotalAssureur, TotalAssurer, TotalExclusion, billAmount, billNo, Exclusion, BonCfg As Integer
    Dim ConnMode, EncounterType, FirmName, ContactName, PatientRelation, PatientQuality As String
    Dim Encounter As ULong

    Dim DB As New MySQLDataBaseAccess(frmMain.ServerString)


    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Sub frmPatientInscription_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'DB = New MySQLDataBaseAccess(ConString)
    End Sub

    Private Sub dtpDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpDate.ValueChanged
        If dtpDate.Value < Now().ToString("yyyy-MM-dd") Then
            'Dim AgeYear, NowYear, Age As Integer
            'NowYear = CInt(Now().ToString("yyyy"))
            'AgeYear = CInt(Year(dtpDate.Value))
            'Age = NowYear - AgeYear
            'txtAge.Text = Age
            txtAge.Text = DateDiff(DateInterval.Year, dtpDate.Value, Now())

        Else
            txtAge.Text = 0
        End If
    End Sub

    Private Sub txtAge_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAge.LostFocus
        Dim Year As Long
        Year = Now.Year - CULng(txtAge.Text)

        dtpDate.Value = "1/7/" & Year
    End Sub

    Private Sub txtAge_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAge.TextChanged

    End Sub

    Private Sub btnInscrire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInscrire.Click
        '
        Dim Qry, Sexe, Status, Rhesus, Groupe As String
        Sexe = ""
        Status = ""
        DB.Params.Clear()
        If NotEmpty(txtName.Text) Then
            DB.AddParams("@nom", txtName.Text)
        Else
            txtName.Focus()
            Exit Sub
        End If

        'Verifier le prenoms
        If NotEmpty(txtPrenoms.Text) Then
            DB.AddParams("@prenom", txtPrenoms.Text)
        Else
            txtPrenoms.Focus()
            Exit Sub
        End If

        'Ajouter la date denregistrement
        DB.AddParams("@datereg", txtDate.Text)
        DB.AddParams("@nele", dtpDate.Value.ToString("yyyy-MM-dd"))

        DB.AddParams("@tribe", cboTribe.Text)

        'Verifier la profession
        If NotEmpty(txtProfession.Text) Then
            DB.AddParams("@profession", txtProfession.Text)
        Else
            txtProfession.Focus()
            Exit Sub
        End If

        'Verifier le sexe
        If radMas.Checked = True Then
            Sexe = "M"
        ElseIf radFem.Checked = True Then
            Sexe = "F"
        End If
        DB.AddParams("@sex", Sexe)

        'Verifier le sexe
        If radCelibataire.Checked = True Then
            Status = "Celibataire"
        ElseIf (radMarie.Checked = True) And (radMas.Checked = True) Then
            Status = "Marie"
        ElseIf (radMarie.Checked = True) And (radFem.Checked = True) Then
            Status = "Mariee"
        ElseIf (radDivorce.Checked = True) And (radMas.Checked = True) Then
            Status = "Divorce"
        ElseIf (radDivorce.Checked = True) And (radFem.Checked = True) Then
            Status = "Divorcee"
        ElseIf (radVeuf.Checked = True) And (radMas.Checked = True) Then
            Status = "Veuf"
        ElseIf (radVeuf.Checked = True) And (radFem.Checked = True) Then
            Status = "Veuve"
        ElseIf (radSepare.Checked = True) And (radMas.Checked = True) Then
            Status = "Separe"
        ElseIf (radSepare.Checked = True) And (radFem.Checked = True) Then
            Status = "Separee"
        End If
        DB.AddParams("@status", Status)

        'Ville
        If NotEmpty(txtVille.Text) Then
            DB.AddParams("@ville", txtVille.Text)
        Else
            txtVille.Focus()
            Exit Sub
        End If

        'Adresse
        If NotEmpty(txtBP.Text) Then
            DB.AddParams("@bp", txtBP.Text)
        Else
            txtBP.Focus()
            Exit Sub
        End If

        'Telephone
        If NotEmpty(txtTelephone.Text) Then
            DB.AddParams("@fone", txtTelephone.Text)
        Else
            txtTelephone.Focus()
            Exit Sub
        End If

        '        'Verifier le rhesus
        If radPos.Checked = True Then
            Rhesus = "Pos"
        ElseIf radNeg.Checked = True Then
            Rhesus = "Neg"
        Else
            Rhesus = ""
        End If
        DB.AddParams("@rhesus", Rhesus)

        'Verifier le sexe
        If radA.Checked = True Then
            Groupe = "A"
        ElseIf radB.Checked = True Then
            Groupe = "B"
        ElseIf radAB.Checked = True Then
            Groupe = "AB"
        ElseIf radO.Checked = True Then
            Groupe = "O"
        Else
            Groupe = ""
        End If

        DB.AddParams("@group", Groupe)
        DB.AddParams("@history", "Init. Reg. " & txtDate.Text & " " & Me.Utilisateur)

        Qry = "INSERT INTO care_person (name_first, name_last, create_time, date_birth, date_reg, ethnic_orig, title, " & _
            "sex, civil_status, citizenship, addr_zip, phone_1_nr, rh, blood_group, history) " & _
            "VALUES (@nom, @prenom, @datereg, @nele, @datereg, @tribe, @profession, " & _
            "@sex, @status, @ville, @bp, @fone, @rhesus, @group, @history)"
        DB.ExecQuery(Qry)

        DB.AddParams("@name", txtName.Text)
        DB.AddParams("@first", txtPrenoms.Text)
        DB.AddParams("@dateenreg", txtDate.Text)

        Qry = "SELECT pid FROM care_person WHERE name_first=@name AND name_last=@first AND date_reg=@dateenreg"
        DB.ExecQuery(Qry)

        If DB.RecordCount > 0 Then
            Dim frmAdmission As New frmPatientAdmission

            frmAdmission.Utilisateur = Me.Utilisateur.ToUpper
            frmAdmission.Noms = txtName.Text & " " & txtPrenoms.Text.ToUpper
            frmAdmission.Id = DB.DBDataTable.Rows(0).Item("pid").ToString.ToUpper
            frmAdmission.Birth = dtpDate.Text.ToUpper
            frmAdmission.Profession = txtProfession.Text.ToUpper
            frmAdmission.Ville = txtVille.Text.ToUpper
            frmAdmission.Adresse = txtBP.Text.ToUpper
            frmAdmission.Telephone = txtTelephone.Text.ToUpper
            frmAdmission.DateEnregistrement = txtDate.Text.ToUpper
            frmAdmission.Sex = Sexe.ToUpper
            frmAdmission.Status = Status.ToUpper
            frmAdmission.Groupe = Groupe & "-" & Rhesus
            'Ouvrir le formulaire d'admission
            Me.Close()
            frmAdmission.ShowDialog()

        End If
    End Sub

    Private Function NotEmpty(ByVal Value As String)
        If Not String.IsNullOrEmpty(Value) Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub frmPatientInscription_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        myConn = New MySqlConnection
        myLabConn = New MySqlConnection
        myConn.ConnectionString = frmMain.ServerString
        myLabConn.ConnectionString = frmMain.ServerString
        Me.Utilisateur = frmMain.Utilisateur

        Me.Text = Me.Text & " - " & frmMain.Utilisateur

        txtDate.Text = Now().ToString("yyyy-MM-dd HH:mm:ss")
        'txtHeure.Text = Now().ToString("HH:mm")
        txtAge.Text = 0
        txtName.Focus()
        radCelibataire.Select()
        'radA.Select()
        'radPos.Select()

        DB.ExecQuery("SELECT tribe_name FROM caredb.care_tz_tribes ORDER BY tribe_name ASC")
        If DB.RecordCount > 0 Then
            For Each row As DataRow In DB.DBDataTable.Rows
                cboTribe.Items.Add(row("tribe_name"))
            Next
        End If
        cboTribe.SelectedIndex = 0
    End Sub

    Private Sub txtName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.LostFocus
        txtName.Text = txtName.Text.ToUpper()
    End Sub

    Private Sub txtPrenoms_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrenoms.LostFocus
        txtPrenoms.Text = txtPrenoms.Text.ToUpper
    End Sub

    Private Sub txtProfession_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProfession.LostFocus
        txtProfession.Text = txtProfession.Text.ToUpper
    End Sub

    Private Sub txtVille_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVille.LostFocus
        txtVille.Text = txtVille.Text.ToUpper
    End Sub

End Class