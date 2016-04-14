Public Class frmValidateRemboursement

    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        GetPatientInformation(txtSearch, txtInfos)
    End Sub
End Class