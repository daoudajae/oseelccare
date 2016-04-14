Imports MySql.Data.MySqlClient

Public Class frmConnection
    Public Property Utilisateur
    Public Property Permission
    Public Property Id As String
    Public Property myConn As New MySqlConnection
    Public Property Comd As MySqlCommand
    Public ServerString As String

    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
        Dim Qry As String
        'Dim Reader As MySqlDataReader
        Dim ConString As String
        'ConString = "server=192.168.15.20;userid=root;password=server;database=caredb"
        'ConString = "server=192.168.5.187;userid=root;password=server;database=caredb"
        'ConString = "server=192.168.6.1;userid=root;password=;database=caredb;Connection Timeout=200"
        'ConString = "server=192.168.5.2;userid=root;password=;database=caredb;Connection Timeout=200"
        ConString = "server=localhost;userid=root;password=God15g00d;database=caredb"
        'Dim count As Integer
        Dim DB As New MySQLDataBaseAccess(ConString)

        Try
            DB.AddParams("@login", txtUser.Text)
            DB.AddParams("@password", getSHA1Hash(txtPassword.Text.ToString))
            Qry = "SELECT login_id, name, level FROM caredb.care_users WHERE login_id=@login AND password=@password"
            DB.ExecQuery(Qry)
            If DB.RecordCount > 0 Then
                With DB.DBDataTable.Rows(0)
                    Me.Utilisateur = .Item("name")
                    Me.Permission = .Item("level")
                    Me.Id = .Item("login_id")
                End With
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.ServerString = ConString

                DB.AddParams("@id", Id)
                Qry = "UPDATE care_users SET personell_nr=1 WHERE login_id=@id"
                DB.ExecQuery(Qry)
                If Me.Utilisateur = "admin" Then
                    frmMain.panSearch.Visible = True
                End If
            Else
                txtUser.Focus()
                MsgBox("User name and password are not correct!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Connection!")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnQuit_Click(sender As System.Object, e As System.EventArgs) Handles btnQuit.Click
        End
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            btnLogin_Click(sender, e)
        End If
    End Sub

    Private Sub txtUser_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUser.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            txtPassword.Focus()
        End If
    End Sub


    Private Sub frmConnection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
