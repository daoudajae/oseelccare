Imports MySql.Data.MySqlClient

Public Class frmPatientAdmission
    Public Property Permission As String
    Public Property Utilisateur As String
    Public Property Id As Long
    Public Property Noms As String
    Public Property Birth As String
    Public Property Profession As String
    Public Property Index As Integer
    Public Property Ville As String
    Public Property Adresse As String
    Public Property DateEnregistrement As String
    Public Property Telephone As String
    Public Property Sex As String
    Public Property Status As String
    Public Property Groupe As String
    'Private DB As New MySQLDataBaseAccess("server=192.168.6.1;userid=root;password=;database=caredb")
    Dim DB As New MySQLDataBaseAccess(frmMain.ServerString)


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnInscrire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInscrire.Click
        '

        'Recuperer le no encounter
        Dim Qry As String
        Dim Encounter As Long
        'Search to see if the patient is already admitted in a ward
        DB.AddParams("@pid", CLng(txtId.Text))
        Qry = "SELECT encounter_nr FROM care_encounter WHERE pid=@pid AND is_discharged=0"
        DB.ExecQuery(Qry)

        'Il ya deja un numero de rencontre
        If DB.RecordCount > 0 Then
            Encounter = DB.DBDataTable.Rows(0).Item("encounter_nr")
        Else
            Encounter = 0
        End If

        If btnInscrire.Text = "Admettre" Then

            'if found do not add
            If Encounter > 0 Then

                MsgBox(Encounter & " est deja admis dans un service.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Admission Patient")
            Else
                DB.AddParams("@pid", CLng(txtId.Text))
                DB.AddParams("@datereg", Now().ToString("yyyy-MM-dd hh:mm:ss"))
                DB.AddParams("@indept", 1)
                DB.AddParams("@deptid", cboDept.SelectedItem)
                DB.AddParams("@history", "Created: " & Me.Utilisateur & " " & Now().ToString("yyyy-MM-dd hh:mm:ss"))
                DB.AddParams("@modifyby", Me.Utilisateur)
                DB.AddParams("@modifyon", Now().ToString("yyyy-MM-dd hh:mm:ss"))
                DB.AddParams("@createby", Me.Utilisateur)
                DB.AddParams("@createon", Now().ToString("yyyy-MM-dd hh:mm:ss"))

                Qry = "INSERT INTO care_encounter (pid, encounter_date, in_dept, current_dept_nr, history, modify_id, modify_time, " & _
                    "create_id, create_time) " & _
                    "VALUES (@pid, @datereg, @indept, @deptid, @history, @modifyby, @modifyon, " & _
                    "@createby, @createon)"
                DB.ExecQuery(Qry)

                DialogResult = MsgBox("Admission de " & txtName.Text & " au service de " & cboServices.Text & " avec succes!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, _
                       "Admission Patient")
                btnInscrire.Text = "Tableau de Board"
                btnSearch_Click(sender, e)
            End If
        ElseIf btnInscrire.Text = "Liberation" Then
            Dim frmLiberation As New frmLiberationPatient
            frmLiberation.Id = CLng(txtId.Text)
            frmLiberation.Utilisateur = Me.Utilisateur
            frmLiberation.ShowDialog()
        ElseIf btnInscrire.Text = "Tableau de Board" Then

            Dim frmTableau As New frmTableauBoard
            GetPatientInformation(txtId, frmMain.txtInfos)
            'frmTableau.MdiParent = frmMain
            frmMain.lblId.Text = txtId.Text
            frmMain.DashBoard.Visible = True
            Me.Close()

            'frmTableau.Show()

            'MsgBox("Ouvrir un tableau de board", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Admission Patient")
        End If

    End Sub

    Private Function NotEmpty(ByVal Value As String)
        If Not String.IsNullOrEmpty(Value) Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub frmPatientAdmission_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Utilisateur = frmMain.Utilisateur
        txtAge.Text = Me.Birth
        txtDate.Text = Me.DateEnregistrement
        txtName.Text = Me.Noms
        txtProfession.Text = Me.Profession
        txtTelephone.Text = Me.Telephone
        txtVille.Text = Me.Ville
        txtId.Text = Me.Id
        txtMessage.Visible = False
        txtSex.Text = Me.Sex
        txtStatus.Text = Me.Status
        txtGroupe.Text = Me.Groupe
        txtSearch.Text = Me.Id
        Me.Text = Me.Text & " - " & frmMain.Utilisateur

        DB.ExecQuery("SELECT nr, name_formal FROM caredb.care_department WHERE type=4 ORDER BY name_formal ASC")
        If DB.RecordCount > 0 Then
            For Each row As DataRow In DB.DBDataTable.Rows
                cboServices.Items.Add(row("name_formal"))
                cboDept.Items.Add(row("nr"))
            Next
        End If
        cboServices.SelectedIndex = 1
        txtSearch.Focus()
        txtSearch.SelectAll()
    End Sub

    Private Sub cboServices_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServices.SelectedIndexChanged
        cboDept.SelectedIndex = cboServices.SelectedIndex
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim PId As Long
        Dim DeathNr As Long
        Dim Qry, Noms, Prenoms, FullName As String
        Dim CurDept As String = ""
        Dim Registered As Boolean = False

        cboServices.Enabled = True
        btnInscrire.Enabled = True


        If IsNumeric(txtSearch.Text) Then
            If CLng(txtSearch.Text) >= 10000000 Then
                PId = CLng(txtSearch.Text)
            Else
                MsgBox("Bien vouloir verifier le numero!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Recherche patient")

            End If
        Else
            'Separer le nom et le prenoms pour initier une recherche
            FullName = txtSearch.Text
            Noms = FullName.Substring(0, FullName.IndexOf(" "))
            Prenoms = FullName.Substring(Noms.Length + 1, FullName.Length - (Noms.Length + 1))
            DB.AddParams("@noms", Noms)
            DB.AddParams("@prenoms", Prenoms)
            Qry = "SELECT pid FROM care_person WHERE name_first=@noms AND name_last=@prenoms"
            DB.ExecQuery(Qry)
            If DB.RecordCount > 0 Then
                PId = DB.DBDataTable.Rows(0).Item("pid")
            Else
                MsgBox("Bien vouloir verifier le nom!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Recherche patient")

            End If
        End If
        If PId > 0 Then
            DB.AddParams("@pid", PId)

            'Verifiez si le patient est deja admis
            DB.ExecQuery("SELECT care_department.name_formal FROM care_department LEFT JOIN care_encounter ON care_encounter.current_dept_nr=care_department.nr WHERE care_encounter.pid=@pid AND is_discharged=0")
            If DB.RecordCount > 0 Then
                CurDept = DB.DBDataTable.Rows(0).Item("name_formal").ToString
                Registered = True
            Else
                Registered = False
            End If

            DB.AddParams("@pid", PId)
            DB.ExecQuery("SELECT date_reg, name_first, name_last, date_birth, title, citizenship, phone_1_nr, civil_status, sex, " & _
                        "blood_group, rh, death_encounter_nr FROM care_person WHERE pid=@pid")
            If DB.RecordCount > 0 Then
                With DB.DBDataTable.Rows(0)
                    txtDate.Text = .Item("date_reg").ToString.ToUpper
                    txtName.Text = .Item("name_first").ToString.ToUpper & " " & .Item("name_last").ToString.ToUpper
                    txtAge.Text = .Item("date_birth")
                    txtProfession.Text = .Item("title").ToString.ToUpper
                    txtVille.Text = .Item("citizenship").ToString.ToUpper
                    txtTelephone.Text = .Item("phone_1_nr").ToString.ToUpper
                    txtStatus.Text = .Item("civil_status").ToString.ToUpper
                    txtSex.Text = .Item("sex").ToString.ToUpper
                    txtId.Text = PId
                    txtGroupe.Text = .Item("blood_group").ToString & "-" & .Item("rh").ToString
                    DeathNr = .Item("death_encounter_nr")
                End With
                If DeathNr > 0 Then
                    btnInscrire.Enabled = False
                    picCross.Visible = True
                    txtMessage.Text = ""
                Else
                    picCross.Visible = False
                    If Registered = True Then
                        cboServices.SelectedIndex = cboServices.FindString(CurDept)
                        cboServices.Enabled = False
                        btnInscrire.Text = "Liberation"
                        txtMessage.Text = txtName.Text & " est admis(e) dans le service " & CurDept & "."
                        txtMessage.ForeColor = Color.LawnGreen
                        btnDiagnostique.Visible = True
                    Else
                        txtMessage.Text = txtName.Text & " n'est pas encore admis(e) dans un service."
                        txtMessage.ForeColor = Color.Red
                        btnInscrire.Text = "Admettre"
                        btnDiagnostique.Visible = False
                    End If
                    txtMessage.Visible = True
                End If
            Else
                MsgBox("Bien vouloir verifier le numero!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Recherche patient")
            End If
        End If

    End Sub

    Private Sub frmPatientAdmission_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            btnSearch_Click(sender, e)
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles picCross.Click

    End Sub

    Private Sub btnPrescription_Click(sender As System.Object, e As System.EventArgs) Handles btnDiagnostique.Click
        Dim frmDiag As New frmPatientDianostique
        frmDiag.Id = CLng(txtId.Text)
        frmDiag.Utilisateur = Me.Utilisateur
        frmDiag.ShowDialog()
    End Sub
End Class