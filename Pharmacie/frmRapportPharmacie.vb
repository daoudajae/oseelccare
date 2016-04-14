Imports MySql.Data.MySqlClient

Public Class frmRapportPharmacie
    Public Property Permission As String
    Public Property Utilisateur As String

    Dim SQL, Condition As String
    Dim PrescReader As MySqlDataReader
    Dim myConn As New MySqlConnection
    Dim myStockConn As New MySqlConnection
    Dim Comd, StockComd As MySqlCommand
    Dim PharmaReader As MySqlDataReader

    Private Sub PreparerAffichage()
        Dim strArr(3, 2), grpArr(1, 1) As String
        myConn = New MySqlConnection
        myConn.ConnectionString = frmMain.ServerString
        Dim fieldPharma As String

        fieldPharma = Pharmacie(Me.Permission)

        'For debugging purposes
        If Me.Permission = "admin" Then
            fieldPharma = "pharma1"
        End If

        If cboStatus.Text = "Livrés" Then
            'cboAgent.Enabled = False
            dtpFrom.Enabled = True
            dtpTo.Enabled = True
            'Date de debut
            strArr(0, 0) = "livrerle"
            strArr(0, 1) = dtpFrom.Text.ToString
            strArr(0, 2) = "From"

            'Date de fin
            strArr(1, 0) = "livrerle"
            strArr(1, 1) = dtpTo.Text.ToString
            strArr(1, 2) = "To"

            'Elements selon mode de paiement
            strArr(2, 0) = "livrer"
            strArr(2, 1) = 1
            strArr(2, 2) = ""

            'Elements selon mode de paiement
            strArr(2, 0) = "livrerpar"
            If cboAgent.Text = "Tous" Then
                strArr(2, 1) = "IS"
            Else
                strArr(2, 1) = cboAgent.Text.ToString
            End If
            strArr(2, 2) = "NOT NULL"

            'Appliquer un groupement
            grpArr(0, 0) = "GROUP BY"
            grpArr(0, 1) = "article"

            'Appliquer ordre de triage
            grpArr(1, 0) = "ORDER BY"
            grpArr(1, 1) = "article ASC"


            'Requette principale
            SQL = "SELECT `article` as Article , `unit_cost` as Prix , sum(`units`) as Qte, sum(units)*unit_cost as Total, class as Groupe FROM `care_billing_bill_item` WHERE"

        ElseIf cboStatus.Text = "En stock" Then
            dtpFrom.Enabled = False
            dtpTo.Enabled = False
            'ReDim strArr(6, 2)
            'cboAgent.Enabled = True
            'Date de medicaments
            strArr(0, 0) = "item_number"
            strArr(0, 2) = "('INJ','COM', 'BUV', 'SOL', 'POM', 'VAC', 'CAR', 'SUP', 'CSM')"
            strArr(0, 1) = "IN"

            'Date de fin
            'strArr(1, 0) = ""
            'strArr(1, 1) = ""
            'strArr(1, 2) = ""

            'Elements selon mode de paiement
            'strArr(2, 0) = ""
            'strArr(2, 1) = ""
            'strArr(2, 2) = ""
            'Requette principale
            If cboAgent.Text = "Tous" Then
                SQL = "SELECT `care_tz_drugsandservices`.`item_description` as Article , `care_tz_drugsandservices`.`unit_price` as Prix , `care_tz_stock_item_amount`.qte as Qte, `care_tz_stock_item_amount`.qte*`care_tz_drugsandservices`.unit_price as Total, `care_tz_drugsandservices`.purchasing_class as Groupe FROM `care_tz_drugsandservices` LEFT JOIN `care_tz_stock_item_amount` ON `care_tz_drugsandservices`.item_id=`care_tz_stock_item_amount`.drugid WHERE"
            Else
                SQL = "SELECT `item_description` as Article , `unit_price` as Prix , " & fieldPharma & " as Qte, " & fieldPharma & "*unit_price as Total FROM `care_tz_drugsandservices` WHERE"
            End If

            'Appliquer un groupement
            grpArr(0, 0) = "GROUP BY"
            grpArr(0, 1) = "item_description"

            'Appliquer ordre de triage
            grpArr(1, 0) = "ORDER BY"
            grpArr(1, 1) = " purchasing_class ASC, item_description ASC"


        End If
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



    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        Dim Rapport As String
        If cboStatus.Text = "En stock" Then
            Rapport = "GAROUA-BOULAI VALEUR DU STOCK EN DATE DU:" & Now.ToString("yyyy-MM-dd hh:mm") & " ---- PAR: " & Me.Utilisateur
        Else
            Rapport = "GAROUA-BOULAI RAPPORT DU:" & dtpFrom.Value.ToString("yyyy-MM-dd hh:mm") & "AU: " & dtpTo.Value.ToString("yyyy-MM-dd hh:mm")
        End If
        Export_Data_Excel(dgvPrescriptions, Rapport, Me.Utilisateur)
    End Sub

    Private Sub grpPrescriptions_Enter(sender As System.Object, e As System.EventArgs) Handles grpPrescriptions.Enter
    End Sub

    Private Sub frmRapportPrescriptions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Utilisateur = frmMain.Utilisateur
        Me.Permission = frmMain.Permission
        Me.Text = Me.Text & " - " & frmMain.Utilisateur

        myConn = New MySqlConnection
        myConn.ConnectionString = frmMain.ServerString

        'Remplir les noms des livreurs dans la liste des agents de pharmacie
        Dim qry As String
        Dim Pharm As String
        If Me.Permission = "admin" Then
            qry = "SELECT DISTINCT livrerpar as Agent FROM `care_billing_bill_item` WHERE livrerpar IS NOT NULL ORDER BY livrerpar ASC"
            Pharm = "Tous"
            cboAgent.Items.Add(Pharm)
            Try
                myConn.Open()
                Comd = New MySqlCommand(qry, myConn)

                PharmaReader = Comd.ExecuteReader

                'Load the combobox with the liste of places
                While PharmaReader.Read
                    Pharm = PharmaReader("Agent").ToString
                    cboAgent.Items.Add(Pharm)
                End While
                myConn.Close()

            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                myConn.Close()
            End Try
        Else
            'qry = "SELECT DISTINCT livrerpar as Agent FROM `care_billing_bill_item` WHERE livrerpar='" & Me.Utilisateur & "'"
            cboAgent.Items.Add(Me.Utilisateur)
        End If




        cboStatus.SelectedIndex = 0
        cboAgent.SelectedIndex = 0

        dtpFrom.Value = DateAndTime.Today.AddDays(-1)

    End Sub


    Private Sub cboAgent_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAgent.SelectedIndexChanged
        PreparerAffichage()
    End Sub
End Class