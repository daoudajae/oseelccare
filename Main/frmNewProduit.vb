Imports MySql.Data.MySqlClient

Public Class frmNewProduit
    Public Property Utilisateur
    Public Property Permission
    Public Property Id As String
    Public ServerString As String

    Dim DBAccess As New MySQLDataBaseAccess(frmMain.ServerString)
    Dim Qry As String
    'Dim Id As Integer

    Private Sub PrepareParams()
        DBAccess.AddParams("@itemnum", cboCategorie.Text)
        If chkPediatrie.Checked = True Then
            DBAccess.AddParams("@ped", 1)
        Else
            DBAccess.AddParams("@ped", 0)
        End If
        If chkAdulte.Checked = True Then
            DBAccess.AddParams("@adult", 1)
        Else
            DBAccess.AddParams("@adult", 0)
        End If
        If chkAutre.Checked = True Then
            DBAccess.AddParams("@autre", 1)
        Else
            DBAccess.AddParams("@autre", 0)
        End If
        If chkARV.Checked = True Then
            DBAccess.AddParams("@arv", 1)
        Else
            DBAccess.AddParams("@arv", 0)
        End If
        DBAccess.AddParams("@desc", txtProduit.Text.ToUpper)
        DBAccess.AddParams("@full", txtProduit.Text.ToUpper)
        DBAccess.AddParams("@prix", CLng(txtPrix.Text))
        DBAccess.AddParams("@class", cboTypeProduit.Text.ToUpper)
    End Sub

    Private Sub btnNewProduit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewProduit.Click
        Try
            If btnNewProduit.Text = "Ajouter Produit" Then
                'Verifier si le produit n'existe pas dans la liste

                DBAccess.AddParams("@number", cboCategorie.Text)
                DBAccess.AddParams("@desc", txtProduit.Text)

                Qry = "SELECT item_id FROM care_tz_drugsandservices WHERE item_number=@number AND item_description=@desc"
                DBAccess.ExecQuery(Qry)
                If DBAccess.RecordCount > 0 Then
                    MsgBox("Produit existant.")
                Else
                    PrepareParams()
                    'Creer requette
                    Qry = "INSERT INTO care_tz_drugsandservices (item_number, is_pediatric, is_adult, is_other, is_arv, " & _
                        "item_description, item_full_description, unit_price, purchasing_class) VALUES (" & _
                        "@itemnum, @ped, @adult, @autre, @arv, @desc, @full, @prix, @class)"
                    DBAccess.ExecQuery(Qry)
                End If
            ElseIf btnNewProduit.Text = "Modifier Produit" Then
                PrepareParams()
                DBAccess.AddParams("@id", CLng(cboId.Text))
                Qry = "UPDATE care_tz_drugsandservices SET item_number=@itemnum, is_pediatric=@ped, is_adult=@adult, " & _
                    "is_other=@autre, is_arv=@arv, " & _
                        "item_description=@desc, item_full_description=@full, unit_price=@prix, purchasing_class=@class WHERE " & _
                        "item_id=@id"
                DBAccess.ExecQuery(Qry)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtProduit.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            btnNewProduit_Click(sender, e)
        End If
    End Sub

    Private Sub txtUser_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If (e.KeyCode = Keys.Enter) Then
            txtProduit.Focus()
        End If
    End Sub


    Private Sub frmConnection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ServerString = frmMain.ServerString
        Me.Utilisateur = frmMain.Utilisateur
    End Sub

    Private Sub chkEditer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEditer.CheckedChanged
        If chkEditer.Checked = True Then
            cboProduit.Enabled = True
            Qry = "SELECT item_description, item_id  FROM care_tz_drugsandservices ORDER BY purchasing_class ASC, item_description ASC"
            'Remplir les listes deroulantes
            Fillcbos(DBAccess, cboProduit, cboId, Qry)
            cboProduit.SelectedIndex = 0
            btnDelete.Visible = True
            'txtProduit.ReadOnly = True
        Else
            btnDelete.Visible = False
            cboProduit.Enabled = False
            txtProduit.ReadOnly = False
            'txtCategorie.Text = ""
            txtProduit.Text = ""
            txtPrix.Text = ""
            'txtConfirm.Text = ""
            cboTypeProduit.SelectedIndex = 0
            btnNewProduit.Text = "Ajouter Produit"
            cboProduit.Items.Clear()
        End If
    End Sub

    Private Sub cboProduit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProduit.SelectedIndexChanged
        cboId.SelectedIndex = cboProduit.SelectedIndex
        DBAccess.AddParams("@itemid", cboId.Text)
        Qry = "SELECT item_number, is_pediatric, is_adult, is_other, is_arv, item_description, item_full_description, unit_price, purchasing_class  FROM care_tz_drugsandservices WHERE item_id=@itemid"
        DBAccess.ExecQuery(Qry)

        If DBAccess.RecordCount > 0 Then
            With DBAccess.DBDataTable.Rows(0)

                If .Item("is_pediatric") = 1 Then
                    chkPediatrie.Checked = True
                End If
                If .Item("is_adult") = 1 Then
                    chkAdulte.Checked = True
                End If
                If .Item("is_other") = 1 Then
                    chkAutre.Checked = True
                End If
                If .Item("is_arv") = 1 Then
                    chkARV.Checked = True
                End If
                cboTypeProduit.SelectedIndex = cboTypeProduit.FindString(.Item("purchasing_class"))
                txtProduit.Text = .Item("item_description".ToString)
                txtPrix.Text = .Item("unit_price")
            End With
            btnNewProduit.Text = "Modifier Produit"
            'txtUser.ReadOnly = True
        End If
    End Sub

    Private Sub frmNewProduit_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Qry = "SELECT DISTINCT purchasing_class, item_number FROM care_tz_drugsandservices"

        Fillcbos(DBAccess, cboTypeProduit, cboCategorie, Qry)
        cboTypeProduit.SelectedIndex = 0
    End Sub

    Private Sub cboTypeProduit_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTypeProduit.SelectedIndexChanged
        cboCategorie.SelectedIndex = cboTypeProduit.SelectedIndex
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        DBAccess.AddParams("@id", CLng(cboId.Text))
        Qry = "DELETE FROM `caredb`.`care_tz_drugsandservices` WHERE `care_tz_drugsandservices`.`item_id` =@id"

        DBAccess.ExecQuery(Qry)

    End Sub
End Class
