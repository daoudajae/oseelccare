Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class frmRapportVenteGroupe
    Public Property Permission As String
    Public Property Utilisateur As String

    Dim myConn As New MySqlConnection
    Dim Comd As MySqlCommand
    Dim PrescReader As MySqlDataReader
    Dim dtaDataTable, copy As New DataTable
    Dim dtaAdapter As New MySqlDataAdapter

    Private Sub frmRapportVente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Utilisateur = frmMain.Utilisateur
        Me.Permission = frmMain.Permission
        Me.Text = Me.Text & " - " & frmMain.Utilisateur

        myConn.ConnectionString = frmMain.ServerString


    End Sub

    Private Sub valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles valider.Click
        Dim debut, fin As String
        Dim req As String

        debut = datedebut.Value.ToString("yyyy-MM-dd") & " 00:00:00"
        fin = datefin.Value.ToString("yyyy-MM-dd") & " 23:59:59"
        dtaDataTable.Clear()
        DataGridView.DataSource = Nothing
        'DataGridView.Columns.Clear()
        DataGridView.Rows.Clear()

        req = "SELECT t.Poste,t.Detail,SUM(t.amount)" & _
" FROM" & _
" (" & _
" SELECT " & _
" CASE" & _
" WHEN  `care_tz_drugsandservices`.`purchasing_class`='xray' THEN 'IMAGERIE'" & _
" WHEN `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('MED','SUP','CAR') THEN 'MEDICAMENTS'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('CON','SMI')  OR `care_billing_bill_item`.`article` IN ('Consultation Pre Anesthesique 1500f','KINE Consultation')  THEN 'CONSULTATIONS' " & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_billing_bill_item`.`article` IN ('URG Consultation Infirmier','MED Consultation infirmier','PED Consultation infirmier','CHIR Consultation infirmier','REA Consultation Brulés Externe','Consultation Infirmier (Dispensaire)') THEN 'CONSULTATIONS'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('ACC','GYN','MAT') THEN 'GYNECO-OBSTETRIQUE'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('ORL','ORT','URO','ANE','CHP','GAS','GCH','GEN','PAA','PAD','PCH','PEN','PTR') THEN 'CHIRURGIE'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('ECO','EEN') THEN 'IMAGERIE'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('KIN') THEN 'KINESITHERAPIE'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('REA','PED','HMD','CHI','HCH','CHIR','ICU','URG') THEN 'HOSPITALISATION'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('LAB') THEN 'LABORATOIRE'" & _
" WHEN `care_billing_bill_item`.`islab`='1' THEN 'LABORATOIRE'" & _
" END AS Poste," & _
" " & _
" CASE" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`='xray' THEN 'RADIOGRAPHIE'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_billing_bill_item`.`article` IN ('MAT Kit Maternite - Accouchement normal (6000F)') THEN 'KIT ACCOUCHEMENT'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_billing_bill_item`.`article` IN ('KIT Césarienne (Maternité)') THEN 'KIT CESARIENNE'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('CAR')  AND `care_billing_bill_item`.`article` IN ('Dossier medical') THEN  'DOSSIERS'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('CAR')  AND `care_billing_bill_item`.`article` IN ('Carnet medical') THEN 'CARNETS'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('MED','SUP') THEN 'MEDICAMENTS'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('CON') AND `care_billing_bill_item`.`article` IN ('Controle Urologue','Controle Infectiologue','Controle Gynecologue','Consultation spécialiste','Consultation Infectologue','Consultation Urologue','consultation Gynecologue','consultation chirurgie viscerale') THEN 'SPECIALISTES'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('CON') AND `care_billing_bill_item`.`article` IN ('Consultation Medical direct','Controle Medical') THEN 'GENERALISTES'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_billing_bill_item`.`article` IN ('Consultation Pre Anesthesique 1500f') THEN 'ANESTHESISTES'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_billing_bill_item`.`article` IN ('KINE Consultation') THEN 'KINESITHERAPIE'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_billing_bill_item`.`article` IN ('URG Consultation Infirmier','MED Consultation infirmier','PED Consultation infirmier','CHIR Consultation infirmier','REA Consultation Brulés Externe','Consultation Infirmier (Dispensaire)') THEN 'INFIRMIERS'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('SMI') THEN 'SMI'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('ACC','GYN','MAT') THEN 'GYNECO-OBSTETRIQUE'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('ORL','ORT','URO','ANE','CHP','GAS','GCH','GEN','PAA','PAD','PCH','PEN','PTR') THEN 'CHIRURGIE'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('ECO') THEN 'ECHOGRAPHIE'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('EEN') THEN 'EEN'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('KIN') THEN 'KINESITHERAPIE'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('URG') THEN 'URGENCE'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('PED') THEN 'PEDIATRIE'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('HMD') THEN 'MEDECINE'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('CHIR','HCH','CHI') THEN 'CHIRURGIE'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('ICU') THEN 'REA MEDICAL'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('REA') THEN 'REA CHIRURGICAL'" & _
" WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('LAB' ) THEN 'LABORATOIRE'" & _
" WHEN `care_billing_bill_item`.`islab`='1' THEN 'LABORATOIRE'" & _
" END AS Detail, `care_billing_bill_item`.`amount`" & _
" " & _
" FROM `care_billing_payment`" & _
" INNER JOIN `care_encounter` ON `care_billing_payment`.`encounter_nr`=`care_encounter`.`encounter_nr`" & _
" INNER JOIN `care_billing_bill_item` ON `care_billing_payment`.`receipt_no`=`care_billing_bill_item`.`bill_no`" & _
" LEFT OUTER JOIN `care_tz_drugsandservices` ON `care_billing_bill_item`.`article` = `care_tz_drugsandservices`.`item_description`" & _
" " & _
" WHERE" & _
" CASE" & _
" WHEN `care_encounter`.`boncfg`=0 THEN `datepaid` BETWEEN '" & debut & "' AND '" & fin & "'" & _
" ELSE `datebilled` BETWEEN '" & debut & "' AND '" & fin & "'" & _
" End" & _
" )t Group By t.Poste, t.Detail"


        myConn.Open()
        dtaDataTable.Reset()

        Comd = New MySqlCommand(req, myConn)
        Comd.CommandTimeout = 300
        dtaAdapter.SelectCommand = Comd
        dtaAdapter.Fill(dtaDataTable)
        'copy = dtaDataTable.Copy
        myConn.Close()


        ' Dim rptsociete As New rptvente
        ' rptsociete.SetDataSource(copy)
        DataGridView.DataSource = dtaDataTable

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim Rapport As String

        Rapport = "GAROUA-BOULAI Du:" & datedebut.Value.ToString("yyyy-MM-dd hh:mm") & "Au: " & datefin.Value.ToString("yyyy-MM-dd hh:mm")
        Export_Data_Excel(DataGridView, Rapport, Me.Utilisateur)
    End Sub

    Private Sub DataGridView_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.CellContentClick

    End Sub
End Class