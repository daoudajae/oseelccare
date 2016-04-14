Public Class frmPercentPayment

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If txtPercent.Text.Trim = "" Then
            MsgBox("Veuillez saisir un pourcentage svp!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
            txtPercent.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtPercent.Text) Then
            MsgBox("Veuillez saisir un pourcentage svp!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
            txtPercent.Focus()
            Exit Sub
        Else
            If txtPercent.Text.Trim = "-" Then
                MsgBox("Veuillez saisir un pourcentage svp!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
                txtPercent.Focus()
                Exit Sub
            End If

            If Integer.Parse(txtPercent.Text) < 0 Then
                MsgBox("Le pourcentage ne peut etre negatif svp!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
                txtPercent.Focus()
                Exit Sub
            End If
            If Integer.Parse(txtPercent.Text) > 100 Then
                MsgBox("Le pourcentage ne peut etre superieur a 100 svp!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
                txtPercent.Focus()
                Exit Sub
            End If

        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class