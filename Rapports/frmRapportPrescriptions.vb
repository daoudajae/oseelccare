Imports MySql.Data.MySqlClient

Public Class frmRapportPrescription
    Public Property Permission As String
    Public Property Utilisateur As String
    Dim SQL, Condition As String
    Dim PrescReader As MySqlDataReader
    Dim myConn As New MySqlConnection

    Private Sub PreparerAffichage()
        Dim strArr(3, 2), grpArr(1, 1) As String
        myConn = New MySqlConnection
        myConn.ConnectionString = frmMain.ServerString

        'Date de debut
        strArr(0, 0) = "date"
        strArr(0, 1) = dtpFrom.Text.ToString
        strArr(0, 2) = "From"

        'Date de fin
        strArr(1, 0) = "date"
        strArr(1, 1) = dtpTo.Text.ToString
        strArr(1, 2) = "To"

        'Elements selon mode de paiement
        strArr(2, 0) = "status"
        If cboStatus.Text = "Payés" Then
            strArr(2, 1) = "paid"
        End If
        If cboStatus.Text = "à Crédit" Then
            strArr(2, 1) = "credit"
        End If
        If cboStatus.Text = "Payés partiellement" Then
            strArr(2, 1) = "partial"
        End If
        If cboStatus.Text = "Non payés" Then
            strArr(2, 1) = "billed"
        End If
        strArr(2, 2) = ""

        'examen de laboratoire
        strArr(3, 0) = "islab"
        If cboIsLab.Text = "Prescriptions" Then
            strArr(3, 1) = "0"
        ElseIf cboIsLab.Text = "Examens de Laboratoire" Then
            strArr(3, 1) = "1"
        End If
        strArr(3, 2) = ""

        'Appliquer un groupement
        grpArr(0, 0) = "GROUP BY"
        grpArr(0, 1) = "article"

        'Appliquer ordre de triage
        grpArr(1, 0) = "ORDER BY"
        grpArr(1, 1) = "article ASC"

        'Requette principale
        SQL = "SELECT `article` as Article , `unit_cost` as Prix , sum(`units`) as Qte, sum(units)*unit_cost as Total, class as Groupe FROM `care_billing_bill_item` WHERE"

        AutoUpdateDataGrid(myConn, SQL, strArr, grpArr, dgvPrescriptions)
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFrom.ValueChanged
        If dtpFrom.Value > dtpTo.Value Then
            dtpFrom.Value = DateAndTime.Today.AddDays(-1)
        End If
        PreparerAffichage()
    End Sub

    Private Sub btnFermer_Click(sender As System.Object, e As System.EventArgs) Handles btnFermer.Click
        Me.Close()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpTo.ValueChanged
        If dtpTo.Value < dtpFrom.Value Then
            dtpTo.Value = DateAndTime.Today
        End If
        PreparerAffichage()
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboStatus.SelectedIndexChanged
        PreparerAffichage()
    End Sub

    Private Sub cboIsLab_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboIsLab.SelectedIndexChanged
        PreparerAffichage()
    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        Dim Rapport As String

        Rapport = "GAROUA-BOULAI Du:" & dtpFrom.Value.ToString("yyyy-MM-dd hh:mm") & "Au: " & dtpTo.Value.ToString("yyyy-MM-dd hh:mm")
        Export_Data_Excel(dgvPrescriptions, Rapport, Me.Utilisateur)
    End Sub

    Private Sub grpPrescriptions_Enter(sender As System.Object, e As System.EventArgs) Handles grpPrescriptions.Enter
    End Sub

    Private Sub frmRapportPrescriptions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Utilisateur = frmMain.Utilisateur
        Me.Permission = frmMain.Permission
        Me.Text = Me.Text & " - " & frmMain.Utilisateur

        cboStatus.SelectedIndex = 0
        cboIsLab.SelectedIndex = 0
        dtpFrom.Value = DateAndTime.Today.AddDays(-1)
    End Sub
End Class