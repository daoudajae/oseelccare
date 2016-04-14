Public Class frmSelectionDateRecapBon

    Private Sub rapport_detaille_caisse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rapport_detaille_caisse.Click
        Dim date1 As Date = "#" & DateDebut.Value & "#"
        Dim date2 As Date = "#" & DateFin.Value & "#"
        Dim result As Integer = Date.Compare(date1, date2)

        If result < 0 Then

        ElseIf result = 0 Then

        Else

            MsgBox("Veuiller choisir une plage de date valide")
            Exit Sub

        End If

        '
        Dim frm As New frmRecapBonPriseEnCharges


        frm.datedebut = DateDebut.Value
        frm.datefin = DateFin.Value
        'frm.agentfacturation = agentfacturation.Text

        frm.ShowDialog()

    End Sub
End Class