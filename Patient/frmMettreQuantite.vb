Public Class frmMettreQuantite
    Public Property Article As String
    Public Property Qte As Integer
    Public Property Stock As Integer
    'Public Property ConString As String

    Dim DB As New MySQLDataBaseAccess(frmMain.ServerString)

    Private Sub frmMettreQuantite_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblArticle.Text = Me.Article
        lblStock.Text = Me.Stock
        If Me.Qte = 0 Then
            txtQuantite.Text = 1
        Else
            txtQuantite.Text = Me.Qte
        End If
        txtQuantite.SelectAll()
    End Sub

    Private Sub btnPrecrire_Click(sender As System.Object, e As System.EventArgs) Handles btnPrecrire.Click
        DialogResult = Windows.Forms.DialogResult.OK
        Total(CInt(txtQuantite.Text))
        Me.Close()
    End Sub

    Private Sub txtQuantite_LostFocus(sender As Object, e As System.EventArgs) Handles txtQuantite.LostFocus
        Dim Qry, Classe As String
        DB.AddParams("@article", Article)
        Qry = "SELECT purchasing_class FROM care_tz_drugsandservices WHERE item_description=@article"
        DB.ExecQuery(Qry)
        If DB.RecordCount > 0 Then
            Classe = DB.DBDataTable.Rows(0).Item("purchasing_class")
            If Classe = "CARNET" OrElse Classe = "CHIRURGIE" OrElse Classe = "CONSULTATION" OrElse Classe = "HOSPITALISATION" _
                OrElse Classe = "IMAGERIE" OrElse Classe = "LABORATOIRE" OrElse Classe = "MATERNITE" OrElse Classe = "SALLES" Then
            Else
                If CInt(txtQuantite.Text) > Me.Stock Then
                    txtQuantite.Text = Me.Stock
                    MsgBox("Stock insufisant!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Quantite a prescrire.")
                End If
            End If
        End If
    End Sub

    Private Sub txtQuantite_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtQuantite.TextChanged
        btnPrecrire.Enabled = True
    End Sub

    Private Function Total(ByVal Val As Integer) As Integer
        Return Val
    End Function

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs)
        DialogResult = 2
        Me.Close()
    End Sub

    Private Sub btnAnnuler_Click(sender As System.Object, e As System.EventArgs) Handles btnAnnuler.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class