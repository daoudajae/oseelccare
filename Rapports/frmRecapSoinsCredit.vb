Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Reflection

Public Class frmRecapSoinsCredit
    Public Property Permission As String
    Public Property Utilisateur As String

    Dim myConn As New MySqlConnection
    Dim Comd As MySqlCommand
    Dim PrescReader As MySqlDataReader
    Dim dtaDataTable, copy As New DataTable
    Dim dtaAdapter As New MySqlDataAdapter
    Dim rpt As New rapportdentree
    Dim requette As String


    Dim listpid As String
    Dim debut As String
    Dim fin As String
    Dim dtpid As DataTable

    Private Sub frmRecapSoinsCredit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Utilisateur = frmMain.Utilisateur
        Me.Permission = frmMain.Permission
        Me.Text = Me.Text & " - " & frmMain.Utilisateur


        myConn.ConnectionString = frmMain.ServerString

        ' MsgBox(requette)
        ' "  AND `date` >= '" & datedebut.Value.ToString("yyyy-MM-dd") & "' AND `date` <= '" & datefin.Value.ToString("yyyy-MM-dd") & "'"
        

    End Sub

    Private Sub valier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles valier.Click

        dtaDataTable.Clear()

        requette = " SELECT t.insurance_firm,t.item_number,SUM(t.amount)" & _
        " FROM" & _
        " (" & _
        " SELECT `care_billing_payment`.`encounter_nr`,`care_billing_payment`.`receipt_no`,`care_billing_bill_item`.`amount`,`care_billing_payment`.`typepaiement`,`care_encounter`.`insurance_firm`, `care_billing_bill_item`.`article`,`care_billing_bill_item`.`islab`,`care_billing_bill_item`.`code`,`care_tz_drugsandservices`.`purchasing_class`," & _
        " CASE" & _
        " WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`='xray' THEN 'IMAGERIE'" & _
        " WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('MED','SUP') THEN 'MEDICAMENTS'" & _
        " WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('CAR') THEN 'CARNET-DOSSIER'" & _
        " WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('CON') THEN 'CONSULTATIONS'" & _
        " WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('ACC','GYN','MAT') THEN 'GYNECO-OBSTETRIQUE'" & _
        " WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('ORL','ORT','URO','ANE','CHP','GAS','GCH','GEN','PAA','PAD','PCH','PEN','PTR') THEN 'CHIRURGIE'" & _
        " WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('ECO','EEN') THEN 'IMAGERIE'" & _
        " WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('REA','PED','HMD','CHI','HCH','CHIR','ICU','URG') THEN 'HOSPITALISATION'" & _
        " WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('KIN' ) THEN 'KINESITHERAPIE'" & _
        " WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('SMI' ) THEN 'SMI'" & _
        " WHEN `care_billing_bill_item`.`islab`='0' AND `care_tz_drugsandservices`.`purchasing_class`!='xray' AND `care_tz_drugsandservices`.`item_number` IN ('LAB' ) THEN 'LABORATOIRE'" & _
        " WHEN `care_billing_bill_item`.`islab`='1' THEN 'LABORATOIRE'" & _
        " END AS item_number" & _
        " FROM `care_billing_payment`" & _
        " INNER JOIN `care_encounter` ON `care_billing_payment`.`encounter_nr`=`care_encounter`.`encounter_nr`" & _
        " INNER JOIN `care_billing_bill_item` ON `care_billing_payment`.`receipt_no`=`care_billing_bill_item`.`bill_no`" & _
        " LEFT OUTER JOIN `care_tz_drugsandservices` ON `care_billing_bill_item`.`article` = `care_tz_drugsandservices`.`item_description`" & _
        " WHERE `care_billing_payment`.`typepaiement`='bon' AND `datebilled` BETWEEN '" & datedebut.Value.ToString("yyyy-MM-dd") & "' AND '" & datefin.Value.ToString("yyyy-MM-dd") & "'" & _
        " )t" & _
        " GROUP BY insurance_firm,item_number" & _
        " ORDER BY insurance_firm,item_number"

        myConn.Open()
        dtaDataTable.Reset()
        Comd = New MySqlCommand(requette, myConn)

        dtaAdapter.SelectCommand = Comd
        dtaAdapter.Fill(dtaDataTable)
        myConn.Close()
        copy = dtaDataTable.Copy
        DataGridView.DataSource = dtaDataTable

        ' Dim rptsociete As New nouvellesynthese
        'rptsociete.SetDataSource(copy)
        ' CrystalReportViewer1.ReportSource = rptsociete

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim Rapport As String

        Rapport = "GAROUA-BOULAI Du:" & datedebut.Value.ToString("yyyy-MM-dd hh:mm") & "Au: " & datefin.Value.ToString("yyyy-MM-dd hh:mm")
        Export_Data_Excel(DataGridView, Rapport, Me.Utilisateur)
    End Sub
End Class