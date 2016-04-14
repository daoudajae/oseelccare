Imports MySql.Data.MySqlClient

Public Class frmModifyUser
    Private DB As New MySQLDataBaseAccess("server=localhost;userid=root;password=God15g00d;database=caredb")

    Public Property Utilisateur
    Public Property Permission
    Public Property Id As String
    Public Property myConn As New MySqlConnection
    Public Property Comd As MySqlCommand
    Public ServerString As String

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewUser.Click
        Dim Qry, Name, UserName, Password, Level, STime, SDate, User, CreateDate, History As String
        Dim Reader As MySqlDataReader
        Try
            UserName = txtUser.Text

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

    Private Sub frmModifyUser_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim Qry As String
        Qry = "SELECT name as Noms, login_id as Identifiant, level as Niveau FROM care_users"

        RefreshGrid(DB, dgvUsers, Qry)

    End Sub
End Class
