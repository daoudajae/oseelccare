Imports MySql.Data.MySqlClient

Public Class frmNewUser
    Public Property Utilisateur
    Public Property Permission
    Public Property Id As String
    Public Property myConn As New MySqlConnection
    Public Property Comd As MySqlCommand
    Public ServerString As String

    Dim DBAccess As New MySQLDataBaseAccess(frmMain.ServerString)
    Dim Qry As String

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewUser.Click
        Dim Qry, Name, UserName, Password, Level, STime, SDate, User, CreateDate, History As String
        Dim Reader As MySqlDataReader
        Try
            UserName = txtUser.Text
            If btnNewUser.Text = "Creer Utilisateur" Then
                myConn.Open()
                Qry = "SELECT login_id, name, level FROM caredb.care_users WHERE login_id='" & UserName & "'" 'AND password='" & Password & "'"
                Comd = New MySqlCommand(Qry, myConn)
                Reader = Comd.ExecuteReader
                Reader.Read()
                If Reader.HasRows = True Then
                    myConn.Close()
                    MsgBox("Cet utilisateur existe deja.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Ajout nouvel utilisateur")
                    'InitializeComponent()
                Else
                    If String.IsNullOrWhiteSpace(txtNoms.Text) Or String.IsNullOrWhiteSpace(txtUser.Text) _
                        Or String.IsNullOrWhiteSpace(txtPassword.Text) Or String.IsNullOrWhiteSpace(txtConfirm.Text) _
                        Or String.IsNullOrWhiteSpace(cboAcces.Text) Then

                        MsgBox("Toutes les informations sont obligatoires, svp!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Ajout Utilisateur")
                    Else
                        If String.Equals(txtPassword.Text, txtConfirm.Text) Then
                            Name = txtNoms.Text
                            Password = getSHA1Hash(txtUser.Text.ToString)
                            Level = cboAcces.Text
                            SDate = Now.ToString("yyyy-MM-dd")
                            STime = Now.ToString("hh:mm:ss")
                            User = Me.Utilisateur
                            CreateDate = Now.ToString("yyyy-MM-dd hh:mm:ss")
                            History = "Cree par: " & User & ". Le " & CreateDate

                            'CreateDate = SDate & " " & STime
                            'Faire la requette
                            Qry = "INSERT INTO care_users (name, login_id, password, level, s_date, s_time, status, modify_id, modify_time, " & _
                                "create_id, create_time, history) VALUES ('" & Name & "','" & UserName & "','" & Password & "','" & Level & _
                                "','" & SDate & "','" & STime & "', 'normal', '" & User & "','" & CreateDate & "','" & User & _
                                "','" & CreateDate & "','" & History & "')"
                            myConn.Close()
                            myConn.Open()
                            Comd = New MySqlCommand(Qry, myConn)
                            Comd.ExecuteNonQuery()
                            MsgBox("Le compte cree avec succes!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Ajout Utilisateur")
                        Else
                            MsgBox("Les mots de passe ne correspondent pas", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Ajout Utilisateur")
                            txtPassword.Text = ""
                            txtConfirm.Text = ""
                            txtPassword.Focus()
                            Exit Sub

                        End If
                    End If
                    'MsgBox(Password)
                    'myConn.Open()
                    'qry = "INSERT INTO care_users ( personell_nr=1 WHERE login_id='" & Id & "'"
                    'Comd = New MySqlCommand(qry, myConn)

                End If
                myConn.Close()
            ElseIf btnNewUser.Text = "Modifier Utilisateur" Then
                If String.Equals(txtPassword.Text, txtConfirm.Text) Then
                    'Rechercher Historique
                    DBAccess.AddParams("@user", txtUser.Text)
                    DBAccess.ExecQuery("SELECT history FROM care_users WHERE login_id=@user")
                    If DBAccess.RecordCount > 0 Then
                        History = DBAccess.DBDataTable.Rows(0).Item("history").ToString
                    End If

                    DBAccess.AddParams("@name", txtNoms.Text)
                    DBAccess.AddParams("@login", txtUser.Text)
                    DBAccess.AddParams("@password", getSHA1Hash(txtPassword.Text.ToString))
                    DBAccess.AddParams("@level", cboAcces.Text)
                    DBAccess.AddParams("@moduser", Me.Utilisateur)
                    DBAccess.AddParams("@modtime", Now.ToString("yyyy-MM-dd hh:mm:ss"))
                    DBAccess.AddParams("@history", History & ", " & Me.Utilisateur & ", " & Now.ToString("yyyy-MM-dd hh:mm:ss"))
                    DBAccess.AddParams("@user", txtUser.Text)
                    Qry = "UPDATE care_users SET name=@name, login_id=@login, password=@password, level=@level, " & _
                        "modify_id=@moduser, modify_time=@modtime, history=@history WHERE login_id=@user"
                    DBAccess.ExecQuery(Qry)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Close()
            myConn.Dispose()
        End Try
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtUser.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            btnLogin_Click(sender, e)
        End If
    End Sub

    Private Sub txtUser_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtNoms.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            txtUser.Focus()
        End If
    End Sub


    Private Sub frmConnection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myConn = New MySqlConnection
        myConn.ConnectionString = frmMain.ServerString
        Me.Utilisateur = frmMain.Utilisateur
    End Sub

    Private Sub chkEditer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEditer.CheckedChanged
        If chkEditer.Checked = True Then
            cboUtilisateur.Enabled = True
            Qry = "SELECT name, login_id  FROM care_users ORDER BY name ASC"
            'Remplir les listes deroulantes
            Fillcbos(DBAccess, cboUtilisateur, cboId, Qry)
            cboUtilisateur.SelectedIndex = -1
            txtUser.ReadOnly = True
        Else
            cboUtilisateur.Enabled = False
            txtUser.ReadOnly = False
            txtNoms.Text = ""
            txtUser.Text = ""
            txtPassword.Text = ""
            txtConfirm.Text = ""
            cboAcces.SelectedIndex = -1
            btnNewUser.Text = "Creer Utilisateur"
            cboUtilisateur.Items.Clear()
        End If
    End Sub

    Private Sub cboUtilisateur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUtilisateur.SelectedIndexChanged
        cboId.SelectedIndex = cboUtilisateur.SelectedIndex
        DBAccess.AddParams("@user", cboId.Text)
        Qry = "SELECT name, login_id, level FROM care_users WHERE login_id=@user"
        DBAccess.ExecQuery(Qry)

        If DBAccess.RecordCount > 0 Then
            With DBAccess.DBDataTable.Rows(0)
                txtNoms.Text = .Item("name").ToString
                txtUser.Text = .Item("login_id".ToString)
                If IsDBNull(.Item("level")) Then
                Else
                    cboAcces.SelectedIndex = cboAcces.FindString(.Item("level"))
                End If

            End With
            btnNewUser.Text = "Modifier Utilisateur"
            'txtUser.ReadOnly = True
        End If
    End Sub
End Class
