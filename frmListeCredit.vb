Public Class frmListeCredit

    
    Private Sub Imprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Imprimer.Click
        Dim frm As New frmImpressionListeCredit
       
        frm.datedebut = DateDebut.Value
        frm.datefin = DateFin.Value

        frm.ShowDialog()
    End Sub

    Private Sub frmListeCredit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class