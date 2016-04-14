Public Class frmRapportdentree
    Dim requette As String
    Dim listpid As String
    Dim debut As String
    Dim fin As String
    Dim dtpid As DataTable



    Private Sub frmRapportdentree_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        

    End Sub


    Private Sub valier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles valier.Click
        'recuperation des dates pour ma requete
        ' debut = datedebut.ToString("yyyy-MM-dd")
        ' fin = datefin.ToString("yyyy-MM-dd")

        'recuperation des id pour ma requette
        If datagridpatient.RowCount = 0 Then

            MsgBox("Pas de Patient dans la grille")
            Exit Sub
        ElseIf datagridpatient.RowCount - 1 = 1 Then
            listpid = datagridpatient.Rows(0).Cells(0).Value.ToString
        Else
            listpid = datagridpatient.Rows(0).Cells(0).Value.ToString

            For i As Integer = 1 To datagridpatient.RowCount - 2
                listpid = listpid & "," & datagridpatient.Rows(i).Cells(0).Value.ToString

            Next

        End If

        'requette principale
        requette = "SELECT CONCAT ( `care_person`.`name_first`, `care_person`.`name_last`) AS nom,`care_encounter`.`pid` , `care_encounter`.`encounter_nr` , `care_billing_bill_item`.`code` , `care_billing_bill_item`.`article` , `care_billing_bill_item`.`units` , `care_billing_bill_item`.`unit_cost` , `care_billing_bill_item`.`amount` , `care_billing_bill_item`.`date` , `care_billing_bill_item`.`status` , `care_billing_bill_item`.`islab`,  " & _
                    "CASE " & _
                    "WHEN `care_billing_bill_item`.`islab`=0 THEN `care_encounter_prescription`.`prescriber` " & _
                    "WHEN `care_billing_bill_item`.`islab`=1 THEN `care_test_request_chemlabor`.`create_id` " & _
                    "End AS Prescripteur " & _
                    "FROM `care_encounter` " & _
                    "INNER JOIN `care_billing_bill_item` ON `care_encounter`.`encounter_nr` = `care_billing_bill_item`.`encounter_nr` " & _
                    "INNER JOIN  `care_person` ON `care_encounter`.`pid`=`care_person`.`pid` " & _
                    "LEFT OUTER JOIN `care_encounter_prescription` ON `care_encounter_prescription`.`nr`=`care_billing_bill_item`.`code` " & _
                    "LEFT OUTER JOIN `care_test_request_chemlabor` ON `care_test_request_chemlabor`.`batch_nr` =`care_billing_bill_item`.`code` " & _
                    "WHERE `care_encounter`.`pid` IN (" & listpid & ") " & _
                    "AND ((`care_billing_bill_item`.`islab`=0 AND `care_encounter_prescription`.`prescriber` IS NOT NULL) OR (`care_billing_bill_item`.`islab`=1)) " & _
                    "  AND `date` >= '" & datedebut.Value.ToString("yyyy-MM-dd") & "' AND `date` <= '" & datefin.Value.ToString("yyyy-MM-dd") & "'"

        'appel du formulaire
        Dim frm As New frmImpressionEtatEntree
        frm.requette = requette
        frm.ShowDialog()

    End Sub

End Class