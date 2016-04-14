Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmEtatCredit

    Dim billno As Integer
    Dim encounter_nr As ULong
    Dim num As Integer = 0


    Dim myConn, myConn1, myConn2, myConn3, myConn4, myConn5 As New MySqlConnection
    Dim Comd, Comd1, Comd2, Comd3, Comd4, Comd5 As MySqlCommand
    Dim PrescReader, PrescReader2, PrescReader3 As MySqlDataReader
    Dim dtaAdapter, dtaAdapter2, dtaAdapter3 As New MySqlDataAdapter
    Dim Qry, qry2, qry3, liste As String
    Dim bindingrecherche As New BindingSource
    Dim factcredit, lencounter, fact As New DataTable

    Dim DB As New MySQLDataBaseAccess(frmMain.ServerString)

    Private Sub UpdateGrid()

        'je cache et je renomme les colonne 
        With dgvListePatients
            .Columns("id").Visible = False
            .Columns("pid").Visible = False
            .Columns("contact_name").Visible = False
            .Columns("encounter_nr").Visible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

        End With

        If dgvListePatients.RowCount > 0 Then
            dgvListePatients.Rows(0).Selected = True
            encounter_nr = dgvListePatients.Rows(0).Cells("encounter_nr").Value
        End If


    End Sub
    Private Sub frmEtatCredit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'recuperation de la chaine de connexion
        'Dim Qry As String
        myConn1.ConnectionString = frmMain.ServerString
        myConn.ConnectionString = frmMain.ServerString
        myConn2.ConnectionString = frmMain.ServerString
        myConn3.ConnectionString = frmMain.ServerString
        myConn4.ConnectionString = frmMain.ServerString
        myConn5.ConnectionString = frmMain.ServerString

        cboAssurances.Items.Add("-Toutes les Assurances-")
        qry = "SELECT DISTINCT(name) FROM care_insurances"
        Fillcbo(DB, cboAssurances, qry)
        cboAssurances.SelectedIndex = 0

        Qry = "SELECT c.`id`,e.`pid`, p.`name_last` AS Noms, p.`name_first` as Prenoms,e.`insurance_firm` as Assurances,e.`contact_name`,c.`encounter_nr`, b.`date` as Date " & _
    ",c.firmamount as Montant FROM `care_billing_credit` AS c " & _
    "INNER JOIN `care_billing_bill` AS b ON c.billno=b.bill_no " & _
    "INNER JOIN `care_encounter` AS e ON c.`encounter_nr`= e.`encounter_nr` " & _
    "INNER JOIN `care_person`AS p ON e.`pid`=p.`pid` " & _
    "WHERE b.date>='" & dtpDebut.Value.ToString("yyyy-MM-dd 00:00") & "' AND b.date<='" & dtpFin.Value.ToString("yyyy-MM-dd 23:59") & "' " & _
    "GROUP BY e.`pid`  " & _
    "ORDER BY c.`id` DESC "

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListePatients.CellClick
        num = dgvListePatients.CurrentRow.Index
        'MsgBox(num.ToString)
        'billno = DataGridView1.Rows(num).Cells("billno").Value
        encounter_nr = dgvListePatients.Rows(num).Cells("encounter_nr").Value

    End Sub

    Private Sub ImprimerFactureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'MsgBox(num.ToString)

        ' Dim frm As New frmImpressionEtatCreditPaye


        'frm.ShowDialog()
    End Sub

    Private Sub ValiderPayementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValiderPayementToolStripMenuItem.Click

    End Sub


    Private Sub imprimerfacture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimerFacture.Click

        Dim ischeck As Integer = 0

        For i As Integer = 0 To dgvRencontres.Rows.Count - 1
            If dgvRencontres.Rows(i).Cells(2).Value = True Then
                ischeck = ischeck + 1
            End If

        Next

        'If ischeck > 0 Then

        'impression
        liste = ""
        Dim tour As Integer = 0
        'For j As Integer = 0 To (dgvRencontres.Rows.Count - 1)
        'For Each Row As DataGridViewRow In dgvRencontres.Rows
        'If dgvRencontres.Rows(j).Cells(2).Value = True Then
        'If tour = 0 Then
        'liste = " (" & dgvRencontres.Rows(j).Cells(0).Value '& ""

        'Else
        'liste = liste & " ," & dgvRencontres.Rows(j).Cells(0).Value '& ""

        'End If

        'tour = tour + 1
        'End If

        'Next
        For Each r As DataGridViewRow In dgvRencontres.Rows
            If r.Cells(2).Value = True Then
                If tour = 0 Then
                    liste = " (" & r.Cells(0).Value '& ""

                Else
                    liste = liste & " ," & r.Cells(0).Value '& ""

                End If

                tour = tour + 1
            End If

        Next
        If tour > 0 Then
            liste = liste & ")"
        End If
        'appel de la facture

        ' MsgBox(liste)

        'Dim frm As New frmSelectionFacture

        'frm.Encounter = encounter_nr
        'frm.id = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("pid").Value
        'frm.nom = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("name_last").Value & "  " & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("name_first").Value
        'frm.liste = liste
        'frm.ShowDialog()
        dgvFactures.DataSource = Nothing
        dgvFactures.Rows.Clear()
        dgvFactures.Columns.Clear()
        ' DataGridView2.Clear()
        If liste = "" Then
        Else
            selection_facture()
        End If


        'End If




    End Sub

    Private Sub filtre()
        Dim requete As String
        bindingrecherche.Filter = String.Empty
        requete = "id>0 "

        If txtpatient.Text <> "" Then
            requete = requete & " AND `care_encounter`.pid=" & txtpatient.Text & ""
        End If

        If txtsociete.Text <> "" Then
            requete = requete & " AND `care_encounter`.insurance_firm like '%" & txtsociete.Text & "%'"
        End If

        If txtassure.Text <> "" Then
            requete = requete & " AND `care_encounter`.contact_name like '%" & txtassure.Text & "%'"
        End If

        If txtassure.Text = "" And txtpatient.Text = "" And txtsociete.Text = "" Then
            requete = "id>0 "

        End If

        bindingrecherche.Filter = requete
        dgvListePatients.DataSource = bindingrecherche
        dgvListePatients.Refresh()

    End Sub

    Private Sub txtpatient_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpatient.TextChanged
        filtre()
    End Sub

    Private Sub txtsociete_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsociete.TextChanged
        filtre()
    End Sub

    Private Sub txtassure_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtassure.TextChanged
        filtre()
    End Sub

    Private Sub DataGridView1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvListePatients.CellMouseDoubleClick

        ' 
        'recherche
        dgvRencontres.DataSource = Nothing
        dgvRencontres.Rows.Clear()
        dgvRencontres.Columns.Clear()
        lencounter.Clear()

        Try
            myConn2.Open()
            qry2 = "SELECT `care_encounter`.`encounter_nr`,`care_encounter`.`encounter_date`  FROM `care_encounter` WHERE `pid`=" & dgvListePatients.Rows(dgvListePatients.CurrentRow.Index).Cells("pid").Value & " ORDER BY encounter_nr DESC"

            Comd2 = New MySqlCommand(qry2, myConn2)

            dtaAdapter2.SelectCommand = Comd2
            dtaAdapter2.Fill(lencounter)
            myConn2.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConn2.Close()

        dgvRencontres.DataSource = lencounter

        With dgvRencontres

            .Columns("encounter_nr").HeaderCell.Value = "N. Rencontre"
            .Columns("encounter_nr").ReadOnly = True
            .Columns("encounter_nr").Width = 100
            .Columns("encounter_date").HeaderCell.Value = "Date Rencontre"
            .Columns("encounter_date").Width = 130
            .Columns("encounter_date").ReadOnly = True

            ' .Columns("encounter_nr").Width = 200
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            Dim col As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
            col.HeaderText = "A Considerer"
            dgvRencontres.Columns.Add(col)
            'listerencontre.Columns("A Considerer").Width = 150




        End With

        dgvFactures.DataSource = Nothing
        dgvFactures.Rows.Clear()
        dgvFactures.Columns.Clear()


    End Sub

    Private Sub selection_facture()
        fact.Clear()
        Try
            myConn3.Open()
            qry3 = "SELECT `care_billing_payment`.`receipt_no`, `care_billing_payment`.`datebilled`, `care_billing_payment`.`typepaiement`, `care_billing_credit`.`billamount`,`care_billing_credit`.`patientamount`,`care_billing_credit`.`firmamount`  FROM `care_billing_payment` INNER JOIN `care_billing_credit` ON `care_billing_payment`.`receipt_no`= `care_billing_credit`.`billno` WHERE   `care_billing_payment`.`encounter_nr` IN " & liste & " ORDER BY `datebilled` DESC"

            Comd3 = New MySqlCommand(qry3, myConn3)

            dtaAdapter3.SelectCommand = Comd3
            dtaAdapter3.Fill(fact)
            myConn3.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConn3.Close()



        dgvFactures.DataSource = fact

        'je cache et je renomme les colonne 
        With dgvFactures
            .Columns("billamount").Visible = False
            .Columns("patientamount").Visible = False
            .Columns("billamount").Visible = False
            ' .Columns("encounter_nr").Visible = False
            '.RowHeadersVisible = False

            ' .Columns("pid").HeaderCell.Value = "N. Patient"
            .Columns("receipt_no").HeaderCell.Value = "N. Facture"
            .Columns("receipt_no").Width = 100
            .Columns("datebilled").HeaderCell.Value = "Date Facturation"
            '.Columns("name_first").Width = 200
            .Columns("typepaiement").HeaderCell.Value = "Type"
            .Columns("typepaiement").Width = 50
            .Columns("firmamount").HeaderCell.Value = "Societé"
            .Columns("firmamount").Width = 70
            ' .Columns("billamount").HeaderCell.Value = "Montant Total"
            '.Columns("patientamount").HeaderCell.Value = "M. Patient"
            '.Columns("firmamount").HeaderCell.Value = "M. Societe"
            '.Columns("patientpaid").HeaderCell.Value = "E.P Patient"
            '.Columns("firmpaid").HeaderCell.Value = "E.P. Societe"
            '.Columns("datepatientpaid").HeaderCell.Value = "D. Patient"
            '.Columns("datefirmpaid").HeaderCell.Value = "D. Societe"
            '.Columns("billno").HeaderCell.Value = "N. Facture"
            '.Columns("typebon").HeaderCell.Value = "Type Bon"
            '.Columns("status").HeaderCell.Value = "Statut"
            ' .Columns("encounter_nr").HeaderCell.Value = "N. Rencontre"
            ' .Columns("encounter_nr").Width = 200
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            Dim col As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
            col.HeaderText = "A Facturé"
            dgvFactures.Columns.Add(col)
            'DataGridView2.Columns("col").Width = 50



        End With


    End Sub


    Private Sub validerfacture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValiderFacture.Click

        num = dgvListePatients.CurrentRow.Index

        Dim facturetotal As Long
        Dim factureclient As Long
        Dim facturesociete As Long
        Dim ry2, ry3, ry4, ry5 As String


        Dim ischeck As Integer = 0

        For i As Integer = 0 To dgvFactures.Rows.Count - 1
            If dgvFactures.Rows(i).Cells(6).Value = True Then
                ischeck = ischeck + 1
            End If

        Next

        If ischeck > 0 Then

            facturetotal = 0
            factureclient = 0
            facturesociete = 0

            Dim tour As Integer = 0

            ry2 = "SELECT `id`,`date` as Date, `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total, `status` as Status  FROM `care_billing_bill_item` WHERE `encounter_nr` IN " & liste & "  AND  `islab`=0 " ' "AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"

            ry3 = "SELECT `id`,`date` as Date, `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total, `status` as Status  FROM `care_billing_bill_item` WHERE `encounter_nr` IN " & liste & "  AND  `islab`=1 " ' "AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"

            ry4 = "SELECT COUNT(*) as num  FROM `care_billing_bill_item` WHERE `encounter_nr` IN " & liste & "  AND  `islab`=0 " ' "AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"

            ry5 = "SELECT COUNT(*) as num  FROM `care_billing_bill_item` WHERE `encounter_nr` IN " & liste & "  AND  `islab`=1 " ' "AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"


            For j As Integer = 0 To (dgvFactures.Rows.Count - 1)

                If dgvFactures.Rows(j).Cells(6).Value = True Then
                    If tour = 0 Then
                        ry2 = ry2 & " AND `bill_no` IN (" & dgvFactures.Rows(j).Cells(0).Value '& ""
                        ry3 = ry3 & " AND `bill_no` IN (" & dgvFactures.Rows(j).Cells(0).Value
                        ry4 = ry4 & " AND `bill_no` IN (" & dgvFactures.Rows(j).Cells(0).Value
                        ry5 = ry5 & " AND `bill_no` IN (" & dgvFactures.Rows(j).Cells(0).Value

                    Else
                        ry2 = ry2 & " ," & dgvFactures.Rows(j).Cells(0).Value '& ""
                        ry3 = ry3 & " ," & dgvFactures.Rows(j).Cells(0).Value
                        ry4 = ry4 & " ," & dgvFactures.Rows(j).Cells(0).Value
                        ry5 = ry5 & " ," & dgvFactures.Rows(j).Cells(0).Value


                    End If


                    facturetotal = facturetotal + CInt(dgvFactures.Rows(j).Cells(3).Value)
                    factureclient = factureclient + CInt(dgvFactures.Rows(j).Cells(4).Value)
                    facturesociete = facturesociete + CInt(dgvFactures.Rows(j).Cells(5).Value)

                    '  MsgBox("Colonne " & i & " Cochez")
                    tour = tour + 1
                End If



            Next

            ry2 = ry2 & ")"
            ry3 = ry3 & ")"
            ry4 = ry4 & ")"
            ry5 = ry5 & ")"

            ry2 = ry2 & " GROUP BY `id` ORDER BY  `date`,`article`"
            ry3 = ry3 & " GROUP BY `id` ORDER BY  `date`,`article`"
            ry4 = ry4 & " GROUP BY `id` ORDER BY  `date`,`article`"
            ry5 = ry5 & " GROUP BY `id` ORDER BY  `date`,`article`"

            'MsgBox(qry2)

            Dim med, lab As Integer
            med = 0
            lab = 0


            Try
                myConn4.Open()
                Comd4 = New MySqlCommand(ry4, myConn4)
                med = Comd4.ExecuteScalar
                myConn4.Close()
            Catch ex As Exception
                myConn4.Close()
            End Try


            Try
                myConn5.Open()
                Comd5 = New MySqlCommand(ry5, myConn5)
                lab = Comd5.ExecuteScalar
                myConn5.Close()
            Catch ex As Exception
                myConn5.Close()
            End Try


            Dim frm As New frmImpressionFactureBon

            If med > 0 Then
                frm.ismed = True
            Else
                frm.ismed = False
            End If

            If lab > 0 Then
                frm.islab = True
            Else
                frm.islab = False
            End If
            frm.qry2 = ry2
            frm.qry3 = ry3
            frm.Encounter = 10000000
            'Encounter
            frm.facturesociete = facturesociete
            frm.factureclient = factureclient
            frm.facturetotal = facturetotal
            frm.nom = dgvListePatients.Rows(num).Cells("Noms").Value & "  " & dgvListePatients.Rows(num).Cells("Prenoms").Value
            'lbnom.Text
            frm.pid = dgvListePatients.Rows(num).Cells("pid").Value
            'lbpatient.Text
            frm.isbon = True

            'lbrequete.Text = qry2
            frm.ShowDialog()

        Else
            MsgBox("Selectionner une/des facture(s)")
        End If


    End Sub


    Private Sub DataGridView1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub listerencontre_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRencontres.CellContentClick

    End Sub

    Private Sub dgvRencontres_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRencontres.CellValueChanged
        If e.ColumnIndex = 2 Then
            imprimerfacture_Click(sender, e)
        End If
    End Sub

    Private Sub dgvFactures_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFactures.CellContentClick

    End Sub

    Private Sub dgvFactures_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFactures.CellValueChanged

    End Sub

    Private Sub dtpDebut_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpDebut.ValueChanged
        cboAssurances_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub dtpFin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFin.ValueChanged
        cboAssurances_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub cboAssurances_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAssurances.SelectedIndexChanged
        If cboAssurances.SelectedIndex = 0 Then
            Qry = "SELECT c.`id`,e.`pid`, p.`name_last` AS Noms, p.`name_first` as Prenoms,e.`insurance_firm` as Assurances,e.`contact_name`,c.`encounter_nr`, b.`date` as Date " & _
    ",c.firmamount as Montant FROM `care_billing_credit` AS c " & _
    "INNER JOIN `care_billing_bill` AS b ON c.billno=b.bill_no " & _
    "INNER JOIN `care_encounter` AS e ON c.`encounter_nr`= e.`encounter_nr` " & _
    "INNER JOIN `care_person`AS p ON e.`pid`=p.`pid` " & _
    "WHERE b.date>='" & dtpDebut.Value.ToString("yyyy-MM-dd 00:00") & "' AND b.date<='" & dtpFin.Value.ToString("yyyy-MM-dd 23:59") & "' " & _
    "GROUP BY e.`pid`  " & _
    "ORDER BY c.`id` DESC "

        Else
            Qry = "SELECT c.`id`,e.`pid`, p.`name_last` AS Noms, p.`name_first` as Prenoms,e.`insurance_firm` as Assurances,e.`contact_name`,c.`encounter_nr`, b.`date` as Date " & _
    ",c.firmamount as Montant FROM `care_billing_credit` AS c " & _
    "INNER JOIN `care_billing_bill` AS b ON c.billno=b.bill_no " & _
    "INNER JOIN `care_encounter` AS e ON c.`encounter_nr`= e.`encounter_nr` " & _
    "INNER JOIN `care_person`AS p ON e.`pid`=p.`pid` " & _
    "WHERE b.date>='" & dtpDebut.Value.ToString("yyyy-MM-dd 00:00") & "' AND b.date<='" & dtpFin.Value.ToString("yyyy-MM-dd 23:59") & "' " & _
    "AND e.insurance_firm='" & cboAssurances.Text & "' " & _
    "GROUP BY e.`pid`  " & _
    "ORDER BY c.`id` DESC "
        End If
        RefreshGrid(DB, dgvListePatients, Qry)
        UpdateGrid()

        dgvListePatients.Columns("Montant").DefaultCellStyle.Format = "### ### ### ##0 F"

        'Calcul de la some de la societe
        Dim FactureSte As Integer
        For Each r As DataGridViewRow In dgvListePatients.Rows
            FactureSte = FactureSte + r.Cells("Montant").Value
        Next
        txtTotalAssurances.Text = FactureSte.ToString("### ### ### ##0 F")
    End Sub
End Class