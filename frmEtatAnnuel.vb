Public Class frmEtatAnnuel

    Private Sub valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles valider.Click

        If IsNumeric(txtannee.Text) Then
            If CInt(txtannee.Text) > 2000 Then

            Else
                MsgBox("L'année choisis n'est pas valide")
                Exit Sub
            End If
        Else
            MsgBox("La valeur entrée n'est pas un entier")
            Exit Sub
        End If

        Dim frm As New frmImpressionEtatAnnuel
        frm.annee = txtannee.Text
        frm.ShowDialog()
    End Sub

    Private Sub frmEtatAnnuel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class