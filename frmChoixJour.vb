Public Class frmChoixJour
    Dim datejour As Date
    Private Sub frmChoixJour_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles valider.Click
        datejour = selectdate.Value

        Dim frm As New frmRecapitulatifJournalier
        frm.datedujour = datejour
        frm.ShowDialog()
    End Sub
End Class