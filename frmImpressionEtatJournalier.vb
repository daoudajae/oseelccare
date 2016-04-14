Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmImpressionEtatJournalier
    Public datedebut As Date
    Public facturation As Boolean
    Public datefin As Date
    Public agentfacturation As String
    Public agentcaisse As String
    Public dt As New DataTable
    Public bindingrecherche As BindingSource
    Dim myConn As New MySqlConnection
    Dim Comd As MySqlCommand
    Dim PrescReader As MySqlDataReader
    Dim dtaAdapter As New MySqlDataAdapter
    Dim qry As String

    Private Sub frmImpressionEtatJournalier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'recuperation des elements de la table care_billing_payment
        myConn.ConnectionString = frmMain.ServerString


        Try
            myConn.Open()
            qry = "SELECT `care_billing_payment`.`encounter_nr`,`care_encounter`.`pid`,`care_person`.`name_last`,`care_person`.`name_first`,`care_billing_payment`.`receipt_no`,`care_billing_payment`.`typepaiement`, " &
 "CASE " &
"WHEN `care_billing_payment`.`typepaiement`='normal' THEN `care_billing_payment`.`billtotal` " &
"WHEN `care_billing_payment`.`typepaiement`='bon' THEN `care_billing_credit`.`billamount` " &
"END AS montantfacture, " &
"CASE " &
"WHEN `care_billing_payment`.`typepaiement`='normal' THEN `care_billing_payment`.`billtotal` " &
"WHEN `care_billing_payment`.`typepaiement`='bon' THEN `care_billing_credit`.`patientamount` " &
"END AS montantpaye, " &
"CASE " &
"WHEN `care_billing_payment`.`typepaiement`='normal' THEN 0 " &
"WHEN `care_billing_payment`.`typepaiement`='bon' THEN `care_billing_credit`.`firmamount` " &
"END AS montantcredit, " &
"`care_billing_payment`.`encaisseur`, " &
"CASE " &
"WHEN `care_billing_payment`.`typepaiement`='normal' THEN `care_billing_payment`.`datepaid` " &
"WHEN `care_billing_payment`.`typepaiement`='bon' THEN `care_billing_payment`.`datebilled` " &
"END AS date " &
"FROM `care_billing_payment` " &
"LEFT OUTER JOIN `care_billing_credit` ON `care_billing_payment`.`receipt_no` = `care_billing_credit`.`billno` " &
"INNER JOIN `care_encounter` ON `care_billing_payment`.`encounter_nr`=`care_encounter`.`encounter_nr` " &
"INNER JOIN `care_person` ON `care_encounter`.`pid`=`care_person`.`pid` " &
"WHERE " &
"CASE " &
"WHEN `care_billing_payment`.`typepaiement`='normal' THEN `datepaid` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "' AND '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "'" &
"WHEN `care_billing_payment`.`typepaiement`='bon' THEN `datebilled` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "' AND '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "'" &
"End "

            If agentcaisse = "None" Then

            Else
                qry = qry & " AND  `care_billing_payment`.`encaisseur` ='" & agentcaisse & "'"
            End If

            Comd = New MySqlCommand(qry, myConn)

            dtaAdapter.SelectCommand = Comd
            dtaAdapter.Fill(dt)
            myConn.Close()


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        

        'definition du crystal report et de ses parametres
        Dim rp As New journalencaissement

        rp.SetDataSource(dt)

        'affectation des parametre au crystal
        ' rp.SetParameterValue("datedebut", datedebut)
        ' rp.SetParameterValue("datefin", datefin)


        CrystalReportViewer.ReportSource = rp


    End Sub
End Class