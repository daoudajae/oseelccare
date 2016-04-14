Public Class frmRapportRecette

    Private Sub frmRapportRecette_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cb_agentcaisse.DataSource = remplir_table_condition("care_users", "name", "level", "'caisse','admin'")
        cb_agentcaisse.DisplayMember = "name"
        cb_agentcaisse.ValueMember = "name"

    End Sub

    Private Sub btn_rechercher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rechercher.Click

        MsgBox("Debut: " & dp_datedebut.Value.ToString("yyyy-MM-dd HH:mm:ss") & ", Fin: " & dp_datefin.Value.ToString("yyyy-MM-dd HH:mm:ss"))

        'recuperation des facture de la periode, 

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
End Class