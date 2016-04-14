Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frmSuiviPrescription
    Dim requette As String
    Dim listpid As String
    Dim debut As String
    Dim fin As String
    Dim dtpid As DataTable
    Dim myConn, myConn2 As New MySqlConnection
    Dim listeprescripteur As New DataTable
    Dim Comd, Comd2 As MySqlCommand
    Dim PrescReader, PrescReader2 As MySqlDataReader

    Dim qry, nom, consultation As String
    Dim dtaAdapter As New MySqlDataAdapter
    Dim newListRow, elementrow As DataRow



    Private Sub frmSuiviPrescription_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        myConn.ConnectionString = frmMain.ServerString

        listeprescripteur.Clear()
        listeprescripteur.Columns.Add("nom", Type.GetType("System.String"))


        Try
            qry = "SELECT DISTINCT(`name`) FROM  `care_users` ORDER BY name ASC"
            myConn.Open()
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                While PrescReader.Read()

                    nom = PrescReader.Item("name")

                    'jinserre la ligne

                    elementrow = listeprescripteur.NewRow
                    elementrow("nom") = nom

                    listeprescripteur.Rows.Add(elementrow)
                    listeprescripteur.AcceptChanges()


                End While
            End If
            PrescReader.Close()
            Comd.ExecuteNonQuery()
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try

        prescripteur.DataSource = listeprescripteur
        prescripteur.DisplayMember = "nom"
        prescripteur.SelectedIndex = -1

    End Sub


    Private Sub valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles valider.Click
        'recuperation des dates pour ma requete
        ' debut = datedebut.ToString("yyyy-MM-dd")
        ' fin = datefin.ToString("yyyy-MM-dd")
        consultation = ""
        'recuperation des id pour ma requette
        Dim debut, fin As String

        debut = datedebut.Value.ToString("yyyy-MM-dd") & " 00:00:00"
        fin = datefin.Value.ToString("yyyy-MM-dd") & " 23:59:59"

        'requette principale
        If inclusion() Then

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
                    "WHERE " & _
                    "((CASE " & _
                    "WHEN `care_billing_bill_item`.`islab`=0 THEN `care_encounter_prescription`.`prescriber` LIKE '" & prescripteur.Text & "'  " & _
                    "WHEN `care_billing_bill_item`.`islab`=1 THEN `care_test_request_chemlabor`.`create_id` LIKE '" & prescripteur.Text & "' " & _
                    "End) OR (`care_billing_bill_item`.`article`  IN " & consultation & ")) " & _
                    "AND ((`care_billing_bill_item`.`islab`=0 AND `care_encounter_prescription`.`prescriber` IS NOT NULL) OR (`care_billing_bill_item`.`islab`=1)) " & _
                    "  AND (`date` BETWEEN'" & debut & "' AND '" & fin & "')" & _
                    ""

        Else

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
                    "WHERE " & _
                    "CASE " & _
                    "WHEN `care_billing_bill_item`.`islab`=0 THEN `care_encounter_prescription`.`prescriber` LIKE '" & prescripteur.Text & "'  " & _
                    "WHEN `care_billing_bill_item`.`islab`=1 THEN `care_test_request_chemlabor`.`create_id` LIKE '" & prescripteur.Text & "' " & _
                    "End " & _
                    "AND ((`care_billing_bill_item`.`islab`=0 AND `care_encounter_prescription`.`prescriber` IS NOT NULL) OR (`care_billing_bill_item`.`islab`=1)) " & _
                    "  AND (`date` BETWEEN'" & debut & "' AND '" & fin & "')" & _
                    ""

        End If

        

        'MsgBox(requette)
        'appel du formulaire
        Dim frm As New frmImpressionEtatEntree
        frm.requette = requette
        frm.ShowDialog()

    End Sub

    Function inclusion() As Boolean
        Dim i As Integer
        Dim chaine As String
        chaine = ""
        i = 0

        'urologie
        If consulturo.Checked = True Then
            If i = 0 Then
                chaine = "( 'Consultation Urologue'"
                i = i + 1
            Else
                chaine = chaine & " ," & " 'Consultation Urologue'"
                i = i + 1
            End If

        End If


        If controleuro.Checked = True Then
            If i = 0 Then
                chaine = "( 'Contrôle Urologue'"
                i = i + 1
            Else
                chaine = chaine & " ," & "'Contrôle Urologue'"
                i = i + 1
            End If
        End If

        'orl
        If consultorl.Checked = True Then
            If i = 0 Then
                chaine = "( 'ORL Consultation'"
                i = i + 1
            Else
                chaine = chaine & " ," & " 'ORL Consultation'"
                i = i + 1
            End If
        End If

        If controleorl.Checked = True Then
            If i = 0 Then
                chaine = "( 'Controle ORL'"
                i = i + 1
            Else
                chaine = chaine & " ," & "'Controle ORL'"
                i = i + 1
            End If
        End If

        'infectiologue
        If consultinfectiologue.Checked = True Then
            If i = 0 Then
                chaine = "( 'Consultation Infectologue'"
                i = i + 1
            Else
                chaine = chaine & " ," & " 'Consultation Infectologue'"
                i = i + 1
            End If
        End If
        If controleinfectiologue.Checked = True Then
            If i = 0 Then
                chaine = "( 'Contrôle Infectologue', 'Controle Infectiologue'"
                i = i + 1
            Else
                chaine = chaine & " ," & "'Contrôle Infectologue', 'Controle Infectiologue'"
                i = i + 1
            End If
        End If

        'traumatologue
        If consultrauma.Checked = True Then
            If i = 0 Then
                chaine = "( 'Consultation Traumatologie'"
                i = i + 1
            Else
                chaine = chaine & " ," & " 'Consultation Traumatologie'"
                i = i + 1
            End If
        End If
        If controletrauma.Checked = True Then
            If i = 0 Then
                chaine = "( 'Controle Traumatologie'"
                i = i + 1
            Else
                chaine = chaine & " ," & "'Controle Traumatologie'"
                i = i + 1
            End If
        End If

        'gyneco

        If consultgyneco.Checked = True Then
            If i = 0 Then
                chaine = "( 'consultation Gynecologue'"
                i = i + 1
            Else
                chaine = chaine & " ," & " 'consultation Gynecologue'"
                i = i + 1
            End If
        End If
        If controlegyneco.Checked = True Then
            If i = 0 Then
                chaine = "( 'Controle Gynecologue'"
                i = i + 1
            Else
                chaine = chaine & " ," & "'Controle Gynecologue'"
                i = i + 1
            End If
        End If

        chaine = chaine & " )"

        consultation = chaine
        If i > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

End Class