Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient


Public Class frmEtatConsultation
    Public Property Permission As String
    Public Property Utilisateur As String

    Dim requette As String
    Dim listpid As String
    Dim debut As String
    Dim fin As String
    Dim dtpid As DataTable
    Dim myConn, myConn2 As New MySqlConnection
    Dim consultation As New DataTable
    Dim Comd, Comd2 As MySqlCommand
    Dim PrescReader, PrescReader2 As MySqlDataReader
    Dim consultation_orl, consultation_medical_direct, consultation_gynecologue, consultation_traumatologue, consultation_infectiologue, consultation_kinesytherapie, consultation_chirurgie_vicerale, consultation_prenatale, consultation_preanesthesique, consultation_infirmier, consultation_urologue As Integer
    Dim consultation_orl1, consultation_medical_direct1, consultation_gynecologue1, consultation_traumatologue1, consultation_infectiologue1, consultation_kinesytherapie1, consultation_chirurgie_vicerale1, consultation_prenatale1, consultation_preanesthesique1, consultation_infirmier1, consultation_urologue1 As Integer

    Dim qry, qry1, nom As String
    Dim dtaAdapter As New MySqlDataAdapter
    Dim newListRow, elementrow1, elementrow2, elementrow3, elementrow4, elementrow5, elementrow6, elementrow7 As DataRow

    Private Sub frmEtatConsultation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Utilisateur = frmMain.Utilisateur
        Me.Permission = frmMain.Permission
        Me.Text = Me.Text & " - " & frmMain.Utilisateur


        myConn.ConnectionString = frmMain.ServerString

        consultation.Clear()
        consultation.Columns.Add("libelle", Type.GetType("System.String"))
        consultation.Columns.Add("nbre", Type.GetType("System.String"))
        ' datedebut = Today.


    End Sub


    Private Sub valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles valider.Click

        Dim debut, fin As String

        debut = datedebut.Value.ToString("yyyy-MM-dd") & " 00:00:00"
        fin = datefin.Value.ToString("yyyy-MM-dd") & " 23:59:59"

        consultation_orl = 0
        consultation_medical_direct = 0
        consultation_gynecologue = 0
        consultation_traumatologue = 0
        consultation_infectiologue = 0
        consultation_kinesytherapie = 0
        consultation_chirurgie_vicerale = 0
        consultation_prenatale = 0
        consultation_preanesthesique = 0
        consultation_infirmier = 0
        consultation_urologue = 0

        consultation_orl1 = 0
        consultation_medical_direct1 = 0
        consultation_gynecologue1 = 0
        consultation_traumatologue1 = 0
        consultation_infectiologue1 = 0
        consultation_kinesytherapie1 = 0
        consultation_chirurgie_vicerale1 = 0
        consultation_prenatale1 = 0
        consultation_preanesthesique1 = 0
        consultation_infirmier1 = 0
        consultation_urologue1 = 0


        qry = "SELECT " & _
                "SUM(CASE WHEN `article` = 'ORL Consultation' OR `article` = 'Controle ORL' THEN 1 ELSE 0 END) AS consultation_orl, " & _
                "SUM(CASE WHEN `article` = 'Consultation Medical direct' OR `article` = 'Controle Medical' THEN 1 ELSE 0 END) AS consultation_medical_direct, " & _
                "SUM(CASE WHEN `article` = 'Consultation Traumatologie' OR `article` = 'Controle Traumatologie' THEN 1 ELSE 0 END) AS consultation_traumatologue, " & _
                "SUM(CASE WHEN `article` = 'Consultation Urologue' OR `article` = 'Contrôle Urologue' THEN 1 ELSE 0 END) AS consultation_urologue, " & _
                "SUM(CASE WHEN `article` = 'Consultation Infectologue' OR `article` = 'Controle Infectiologue' OR `article` = 'Contrôle Infectologue' THEN 1 ELSE 0 END) AS consultation_infectiologue, " & _
                "SUM(CASE WHEN `article` = 'KINE Consultation' OR `article` = 'KINE Controle' THEN 1 ELSE 0 END) AS consultation_kinesytherapie, " & _
                "SUM(CASE WHEN `article` = 'consultation Gynecologue' OR `article` = 'Controle Gynecologue' THEN 1 ELSE 0 END) AS consultation_gynecologue, " & _
                "SUM(CASE WHEN `article` = 'consultation chirurgie viscerale' OR `article` = 'Controle Chirurgie viscerale' THEN 1 ELSE 0 END) AS consultation_chirurgie_vicerale, " & _
                "SUM(CASE WHEN `article` = 'SMI Consultation pré-natale 2 ou 3 (1100f)' OR `article` = 'Consultation pré-natale 1 (1600f)' THEN 1 ELSE 0 END) AS consultation_prenatale, " & _
                "SUM(CASE WHEN `article` = 'Consultation Pre Anesthesique 1500f' THEN 1 ELSE 0 END) AS consultation_preanesthesique, " & _
                "SUM(CASE WHEN `article` = 'Consultation Infirmier (Dispensaire)' OR `article` like 'SMI Consultation Enfant' OR `article` = 'URG Consultation Infirmier' OR `article` like 'MED Consultation infirmier' OR `article` like 'PED Consultation infirmier' OR `article` like 'SMI Consultation Planning Familial' OR `article` like 'SMI Consultation infirmier' OR `article` like 'CHIR Consultation infirmier' THEN 1 ELSE 0 END) AS consultation_infirmier " & _
                "FROM `care_billing_bill_item` " & _
               "WHERE (`date` BETWEEN '" & debut & "' AND  '" & fin & "') " & _
               "AND (`care_billing_bill_item`.`status`='paid' OR `care_billing_bill_item`.`status`='partial') "

        qry1 = "SELECT " & _
               "SUM(CASE WHEN `article` = 'ORL Consultation' OR `article` = 'Controle ORL' THEN 1 ELSE 0 END) AS consultation_orl, " & _
               "SUM(CASE WHEN `article` = 'Consultation Medical direct' OR `article` = 'Controle Medical' THEN 1 ELSE 0 END) AS consultation_medical_direct, " & _
               "SUM(CASE WHEN `article` = 'Consultation Traumatologie' OR `article` = 'Controle Traumatologie' THEN 1 ELSE 0 END) AS consultation_traumatologue, " & _
               "SUM(CASE WHEN `article` = 'Consultation Urologue' OR `article` = 'Contrôle Urologue' THEN 1 ELSE 0 END) AS consultation_urologue, " & _
               "SUM(CASE WHEN `article` = 'Consultation Infectologue' OR `article` = 'Controle Infectiologue' OR `article` = 'Contrôle Infectologue' THEN 1 ELSE 0 END) AS consultation_infectiologue, " & _
               "SUM(CASE WHEN `article` = 'KINE Consultation' OR `article` = 'KINE Controle' THEN 1 ELSE 0 END) AS consultation_kinesytherapie, " & _
               "SUM(CASE WHEN `article` = 'consultation Gynecologue' OR `article` = 'Controle Gynecologue' THEN 1 ELSE 0 END) AS consultation_gynecologue, " & _
               "SUM(CASE WHEN `article` = 'consultation chirurgie viscerale' OR `article` = 'Controle Chirurgie viscerale' THEN 1 ELSE 0 END) AS consultation_chirurgie_vicerale, " & _
               "SUM(CASE WHEN `article` = 'SMI Consultation pré-natale 2 ou 3 (1100f)' OR `article` = 'Consultation pré-natale 1 (1600f)' THEN 1 ELSE 0 END) AS consultation_prenatale, " & _
               "SUM(CASE WHEN `article` = 'Consultation Pre Anesthesique 1500f' THEN 1 ELSE 0 END) AS consultation_preanesthesique, " & _
               "SUM(CASE WHEN `article` = 'Consultation Infirmier (Dispensaire)' OR `article` = 'SMI Consultation Enfant' OR `article` like 'URG Consultation Infirmier' OR `article` like 'MED Consultation infirmier' OR `article` like 'PED Consultation infirmier' OR `article` like 'SMI Consultation Planning Familial' OR `article` like 'SMI Consultation infirmier' OR `article` like 'CHIR Consultation infirmier' THEN 1 ELSE 0 END) AS consultation_infirmier " & _
               "FROM `care_billing_bill_item` " & _
               "WHERE (`date` BETWEEN '" & debut & "' AND '" & fin & "') " & _
               "AND (`care_billing_bill_item`.`status`='billed') "


        Try
            myConn.Open()
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                PrescReader.Read()
                consultation_orl = CInt(PrescReader.Item("consultation_orl"))
                consultation_medical_direct = CInt(PrescReader.Item("consultation_medical_direct"))
                consultation_gynecologue = CInt(PrescReader.Item("consultation_gynecologue"))
                consultation_traumatologue = CInt(PrescReader.Item("consultation_traumatologue"))
                consultation_infectiologue = CInt(PrescReader.Item("consultation_infectiologue"))
                consultation_kinesytherapie = CInt(PrescReader.Item("consultation_kinesytherapie"))
                consultation_chirurgie_vicerale = CInt(PrescReader.Item("consultation_chirurgie_vicerale"))
                consultation_prenatale = CInt(PrescReader.Item("consultation_prenatale"))
                consultation_preanesthesique = CInt(PrescReader.Item("consultation_preanesthesique"))
                consultation_infirmier = CInt(PrescReader.Item("consultation_infirmier"))
                consultation_urologue = CInt(PrescReader.Item("consultation_urologue"))
            End If
            PrescReader.Close()
            Comd.ExecuteNonQuery()
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try


        Try
            myConn.Open()
            Comd = New MySqlCommand(qry1, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                PrescReader.Read()
                consultation_orl1 = CInt(PrescReader.Item("consultation_orl"))
                consultation_medical_direct1 = CInt(PrescReader.Item("consultation_medical_direct"))
                consultation_gynecologue1 = CInt(PrescReader.Item("consultation_gynecologue"))
                consultation_traumatologue1 = CInt(PrescReader.Item("consultation_traumatologue"))
                consultation_infectiologue1 = CInt(PrescReader.Item("consultation_infectiologue"))
                consultation_kinesytherapie1 = CInt(PrescReader.Item("consultation_kinesytherapie"))
                consultation_chirurgie_vicerale1 = CInt(PrescReader.Item("consultation_chirurgie_vicerale"))
                consultation_prenatale1 = CInt(PrescReader.Item("consultation_prenatale"))
                consultation_preanesthesique1 = CInt(PrescReader.Item("consultation_preanesthesique"))
                consultation_infirmier1 = CInt(PrescReader.Item("consultation_infirmier"))
                consultation_urologue1 = CInt(PrescReader.Item("consultation_urologue"))
            End If
            PrescReader.Close()
            Comd.ExecuteNonQuery()
            myConn.Close()
        Catch ex As Exception
            ' MsgBox(ex.ToString)
            myConn.Close()
        End Try

        DataGridView.Rows.Clear()
        DataGridView.Rows.Add("Consultation Medical Diect", consultation_medical_direct, consultation_medical_direct1, consultation_medical_direct + consultation_medical_direct1)
        DataGridView.Rows.Add("Consultation ORL", consultation_orl, consultation_orl1, consultation_orl + consultation_orl1)
        DataGridView.Rows.Add("Consultation Gynecologue", consultation_gynecologue, consultation_gynecologue1, consultation_gynecologue + consultation_gynecologue1)
        DataGridView.Rows.Add("Consultation Traumatologue", consultation_traumatologue, consultation_traumatologue1, consultation_traumatologue + consultation_traumatologue1)
        DataGridView.Rows.Add("Consultation Infectiologue", consultation_infectiologue, consultation_infectiologue1, consultation_infectiologue1 + consultation_infectiologue)
        DataGridView.Rows.Add("Consultation Kinesytherapie", consultation_kinesytherapie, consultation_kinesytherapie1, consultation_kinesytherapie1 + consultation_kinesytherapie)
        DataGridView.Rows.Add("Consultation Chirurgie Vicerale", consultation_chirurgie_vicerale, consultation_chirurgie_vicerale1, consultation_chirurgie_vicerale + consultation_chirurgie_vicerale1)
        DataGridView.Rows.Add("Consultation Prenatale", consultation_prenatale, consultation_prenatale1, consultation_prenatale + consultation_prenatale1)
        DataGridView.Rows.Add("Consultation Preanesthesique", consultation_preanesthesique, consultation_preanesthesique1, consultation_preanesthesique + consultation_preanesthesique1)
        DataGridView.Rows.Add("Consultation Infirmier", consultation_infirmier, consultation_infirmier1, consultation_infirmier + consultation_infirmier1)
        DataGridView.Rows.Add("Consultation Urologue", consultation_urologue, consultation_urologue1, consultation_urologue + consultation_urologue1)


    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim Rapport As String

        Rapport = "RAPPORT"
        Export_Data_Excel(DataGridView, Rapport, Me.Utilisateur)
    End Sub
End Class