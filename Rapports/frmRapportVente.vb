Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports DBLibrary.DB
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmRapportVente
    Public Property Permission As String
    Public Property Utilisateur As String

    Dim myConn As New MySqlConnection
    Dim Comd As MySqlCommand
    Dim PrescReader As MySqlDataReader
    Dim dtaDataTable, copy As New DataTable
    Dim dtaAdapter As New MySqlDataAdapter

    'Dim DB As New MySQLDataBaseAccess("server=localhost;userid=root;password=God15g00d;database=caredb")
    Dim DB As New MySQLDataBaseAccess(frmMain.ServerString)

    Dim rptDoc As New rptRapportCaisse


    Private Sub frmRapportVente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Utilisateur = frmMain.Utilisateur
        Me.Permission = frmMain.Permission
        Me.Text = Me.Text & " - " & frmMain.Utilisateur

        myConn.ConnectionString = frmMain.ServerString
        

    End Sub


    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Rapport As String

        Rapport = "GAROUA-BOULAI Du:" & datedebut.Value.ToString("yyyy-MM-dd hh:mm") & "Au: " & datefin.Value.ToString("yyyy-MM-dd hh:mm")
        'Export_Data_Excel(dgvVentes, Rapport, Me.Utilisateur)
    End Sub

    Private Sub frmRapportVente_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Dim Qry As String
        cboAgentCaisse.Items.Clear()
        cboAgentCaisse.Items.Add("-Tous-")
        Qry = "SELECT distinct(p.encaisseur) FROM care_billing_payment AS p " & _
            "LEFT JOIN care_billing_bill_item AS b ON p.receipt_no=b.bill_no " & _
            "WHERE p.paid>0 ORDER BY p.encaisseur ASC"
        Fillcbo(DB, cboAgentCaisse, Qry)
        cboAgentCaisse.SelectedIndex = 0
    End Sub

    Private Sub cboAgentCaisse_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAgentCaisse.SelectedIndexChanged
        Dim Qry As String
        Dim TableDT As DataTable
        Dim bon100 As Integer = 0
        Dim bonClerge As Integer = 0
        Dim bonPersonel As Integer = 0
        Dim bonSociete As Integer = 0

        'Rajouter les lignes
        DB.AddParams("@debut", datedebut.Text)
        DB.AddParams("@fin", datefin.Text)
        If cboAgentCaisse.SelectedIndex = 0 Then
            Qry = "SELECT CASE " & _
                "WHEN b.class='CARNET' THEN 'CARNETS/DOSSIERS MEDICAUX' " & _
                "WHEN b.class='CHIRURGIE' THEN 'CHIRURGIE' " & _
                "WHEN b.class='CONSULTATION' THEN 'CONSULTATION' " & _
                "WHEN b.class='ECG' THEN 'ECG' " & _
                "WHEN b.class='ECOGRAPHIE' THEN 'ECOGRAPHIE' " & _
                "WHEN b.class='HOSPITALISATION' THEN 'HOSPITALISATION' " & _
                "WHEN b.class='VACCINS' OR b.class='SUPPOSITOIRES' OR b.class='SOLLUTES' OR b.class='SUSPENSION' OR b.class='MEDICAMENTS' OR b.class='INJECTABLES' OR b.class='POMADES' THEN 'MEDICAMENTS' " & _
                "WHEN b.class='RADIOLOGIE' THEN 'RADIOLOGIE' " & _
                "WHEN b.class='SALLES' THEN 'SALLES PAYANTES' " & _
                "WHEN b.class='MATERNITE' THEN 'MATERNITE' " & _
                "WHEN b.class='LABORATOIRE' THEN 'LABORATOIRE' " & _
                "END AS Classe, SUM(b.amount) AS Total " & _
                "FROM care_billing_bill_item AS b " & _
                "INNER JOIN care_billing_payment as p ON b.bill_no=p.receipt_no " & _
                "WHERE p.datepaid>=@debut AND p.datepaid<=@fin AND  p.paid>0 " & _
                "GROUP BY Classe ORDER BY b.class ASC"
        Else
            DB.AddParams("@encaisseur", cboAgentCaisse.Text)
            Qry = "SELECT CASE " & _
                "WHEN b.class='CARNET' THEN 'CARNETS/DOSSIERS' " & _
                "WHEN b.class='CHIRURGIE' THEN 'CHIRURGIE' " & _
                "WHEN b.class='CONSULTATION' THEN 'CONSULTATION' " & _
                "WHEN b.class='ECG' THEN 'ECG' " & _
                "WHEN b.class='ECOGRAPHIE' THEN 'ECOGRAPHIE' " & _
                "WHEN b.class='HOSPITALISATION' THEN 'HOSPITALISATION' " & _
                "WHEN b.class='VACCINS' OR b.class='SUPPOSITOIRES' OR b.class='SOLLUTES' OR b.class='SUSPENSION' OR b.class='MEDICAMENTS' OR b.class='INJECTABLES' OR b.class='POMADES' THEN 'MEDICAMENTS' " & _
                "WHEN b.class='RADIOLOGIE' THEN 'RADIOLOGIE' " & _
                "WHEN b.class='SALLES' THEN 'SALLES PAYANTES' " & _
                "WHEN b.class='MATERNITE' THEN 'MATERNITE' " & _
                "WHEN b.class='LABORATOIRE' THEN 'LABORATOIRE' " & _
                "END AS Classe, SUM(b.amount) AS Total " & _
                "FROM care_billing_bill_item AS b " & _
                "INNER JOIN care_billing_payment as p ON b.bill_no=p.receipt_no " & _
                "WHERE p.datepaid>=@debut AND p.datepaid<=@fin AND p.encaisseur=@encaisseur AND p.paid>0 " & _
                "GROUP BY Classe ORDER BY Classe ASC"
        End If
        DB.ExecQuery(Qry)
        'RefreshGrid(DB, dgvVentes, Qry)
        TableDT = DB.DBDataTable

        'Recuperer les avances 
        DB.AddParams("@debut", datedebut.Text)
        DB.AddParams("@fin", datefin.Text)

        If cboAgentCaisse.SelectedIndex = 0 Then
            Qry = "SELECT SUM(avance) as Avance FROM care_billing_avances " & _
                "WHERE `date`>=@debut AND `date`<=@fin AND `status`='avance' "

        Else
            DB.AddParams("@encaisseur", cboAgentCaisse.Text)
            Qry = "SELECT SUM(avance) as Avance FROM care_billing_avances " & _
                "WHERE `date`>=@debut AND `date`<=@fin AND `status`='avance' " & _
                "AND encaisseur=@encaisseur"
        End If
        DB.ExecQuery(Qry)

        'Verifier s'il ya des avance
        If Not IsDBNull(DB.DBDataTable.Rows(0).Item("Avance")) Then
            Dim Avance = DB.DBDataTable.Rows(0).Item("Avance")

            Dim newRow As DataRow
            newRow = TableDT.NewRow

            'Mettre les donnees dans le newRow
            newRow.Item(0) = "AVANCES"
            newRow.Item(1) = Avance

            TableDT.Rows.InsertAt(newRow, 0)
            TableDT.AcceptChanges()
        End If
        'Verser les donnees pour affichage du rapport
        rptDoc.SetDataSource(TableDT)
        rptDoc.SetParameterValue("agentcaisse", cboAgentCaisse.Text)
        rptDoc.SetParameterValue("debut", datedebut.Text & " - " & datefin.Text)

        'Ressortir le montant des bons de 100 
        DB.AddParams("@debut", datedebut.Text)
        DB.AddParams("@fin", datefin.Text)
        Qry = "SELECT SUM(c.patientamount) as total FROM care_billing_credit as c " & _
            "LEFT JOIN care_billing_bill as b ON c.billno=b.bill_no WHERE c.datepatientpaid IS NULL AND c.typebon='100%' " & _
            "AND b.date>=@debut and b.date<=@fin"
        DB.ExecQuery(Qry)
        If Not IsDBNull(DB.DBDataTable.Rows(0).Item("total")) Then
            bon100 = DB.DBDataTable.Rows(0).Item("total")
            rptDoc.SetParameterValue("100", bon100)
        Else
            rptDoc.SetParameterValue("100", 0)
        End If
        'Ressortir le montant du clerge
        DB.AddParams("@debut", datedebut.Text)
        DB.AddParams("@fin", datefin.Text)
        Qry = "SELECT SUM(c.patientamount) as total FROM care_billing_credit as c " & _
            "LEFT JOIN care_billing_bill as b ON c.billno=b.bill_no WHERE c.datepatientpaid IS NULL AND c.typebon='Clergé' " & _
            "AND b.date>=@debut and b.date<=@fin"
        DB.ExecQuery(Qry)
        If Not IsDBNull(DB.DBDataTable.Rows(0).Item("total")) Then
            bonClerge = DB.DBDataTable.Rows(0).Item("total")
            rptDoc.SetParameterValue("50", bonClerge)
        Else
            rptDoc.SetParameterValue("50", 0)
        End If
        'Ressortir le bon a 20%
        DB.AddParams("@debut", datedebut.Text)
        DB.AddParams("@fin", datefin.Text)
        Qry = "SELECT SUM(c.patientamount) as total FROM care_billing_credit as c " & _
            "LEFT JOIN care_billing_bill as b ON c.billno=b.bill_no WHERE c.datepatientpaid IS NULL AND c.typebon='Personnel' " & _
            "AND b.date>=@debut and b.date<=@fin"
        DB.ExecQuery(Qry)
        If Not IsDBNull(DB.DBDataTable.Rows(0).Item("total")) Then
            bonPersonel = DB.DBDataTable.Rows(0).Item("total")
            rptDoc.SetParameterValue("20", bonPersonel)
        Else
            rptDoc.SetParameterValue("20", 0)
        End If
        'Ressortir les bons societe
        DB.AddParams("@debut", datedebut.Text)
        DB.AddParams("@fin", datefin.Text)
        Qry = "SELECT SUM(c.firmamount) as total FROM care_billing_credit as c " & _
            "LEFT JOIN care_billing_bill as b ON c.billno=b.bill_no WHERE c.datepatientpaid IS NULL AND c.typebon='Société' " & _
            "AND b.date>=@debut and b.date<=@fin"
        DB.ExecQuery(Qry)
        If Not IsDBNull(DB.DBDataTable.Rows(0).Item("total")) Then
            bonSociete = DB.DBDataTable.Rows(0).Item("total")
            rptDoc.SetParameterValue("societe", bonSociete)
        Else
            rptDoc.SetParameterValue("societe", 0)
        End If
        Dim Credit = bon100 + bonClerge + bonPersonel + bonSociete

        rptDoc.SetParameterValue("credit", Credit)
        crtViewer.ReportSource = rptDoc
    End Sub

    Private Sub btnQuiter_Click(sender As System.Object, e As System.EventArgs) Handles btnQuiter.Click
        Me.Close()
    End Sub

    Private Sub btnImprimer_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimer.Click
        rptDoc.PrintToPrinter(1, False, 0, 0)
    End Sub

    Private Sub datedebut_ValueChanged(sender As System.Object, e As System.EventArgs) Handles datedebut.ValueChanged
        cboAgentCaisse_SelectedIndexChanged(sender, e)

    End Sub

    Private Sub datefin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles datefin.ValueChanged
        cboAgentCaisse_SelectedIndexChanged(sender, e)

    End Sub

End Class