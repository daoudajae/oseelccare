Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmSelectionFacture
    Dim myConn, myConn1 As New MySqlConnection
    Dim Comd, Comd1 As MySqlCommand
    Dim PrescReader, PrescReader1 As MySqlDataReader
    Dim dtaDataTable As New DataTable
    Dim dtaAdapter As New MySqlDataAdapter
    Dim qry, qry2, qry3, qry4, qry5 As String
    Public Encounter As ULong
    Public nom As String
    Public id As ULong
    Public liste As String
    Dim testbill As String
    Dim newListRow As DataRow
    Dim factcredit As New DataTable
    Private facturetotal As Long
    Private factureclient As Long
    Private facturesociete As Long





    Private Sub frmSelectionFacture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'recuperation de la chaine de connexion
        myConn.ConnectionString = frmMain.ServerString
        myConn1.ConnectionString = frmMain.ServerString

        lbnom.Text = nom
        lbpatient.Text = id
        lbrencontre.Text = liste




        Try
            myConn.Open()
            qry = "SELECT `care_billing_payment`.`receipt_no`, `care_billing_payment`.`datebilled`, `care_billing_payment`.`typepaiement`, `care_billing_credit`.`billamount`,`care_billing_credit`.`patientamount`,`care_billing_credit`.`firmamount`  FROM `care_billing_payment` INNER JOIN `care_billing_credit` ON `care_billing_payment`.`receipt_no`= `care_billing_credit`.`billno` WHERE   `care_billing_payment`.`encounter_nr` IN " & liste & " ORDER BY `datebilled` DESC"

            Comd = New MySqlCommand(qry, myConn)

            dtaAdapter.SelectCommand = Comd
            dtaAdapter.Fill(factcredit)
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConn.Close()

        DataGridView1.DataSource = factcredit

        'je cache et je renomme les colonne 
        With DataGridView1
            .Columns("billamount").Visible = False
            .Columns("patientamount").Visible = False
            .Columns("billamount").Visible = False
            ' .Columns("encounter_nr").Visible = False
            '.RowHeadersVisible = False

            ' .Columns("pid").HeaderCell.Value = "N. Patient"
            .Columns("receipt_no").HeaderCell.Value = "N. Facture"
            ' .Columns("name_last").Width = 200
            .Columns("datebilled").HeaderCell.Value = "Date Facturation"
            '.Columns("name_first").Width = 200
            .Columns("typepaiement").HeaderCell.Value = "Type"
            ' .Columns("insurance_firm").Width = 200
            ' .Columns("contact_name").HeaderCell.Value = "Assuré"
            ' .Columns("contact_name").Width = 200
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
            DataGridView1.Columns.Add(col)



        End With

        
    End Sub


    Private Sub validerfacture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles validerfacture.Click

        Dim ischeck As Integer = 0

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(6).Value = True Then
                ischeck = ischeck + 1
            End If

        Next

        If ischeck > 0 Then

            facturetotal = 0
            factureclient = 0
            facturesociete = 0

            Dim tour As Integer = 0

            qry2 = "SELECT `id`,`date` as Date, `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total, `status` as Status  FROM `care_billing_bill_item` WHERE `encounter_nr` IN " & liste & "  AND  `islab`=0 " ' "AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"

            qry3 = "SELECT `id`,`date` as Date, `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total, `status` as Status  FROM `care_billing_bill_item` WHERE `encounter_nr` IN " & liste & "  AND  `islab`=1 " ' "AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"

            qry4 = "SELECT COUNT(*) as num  FROM `care_billing_bill_item` WHERE `encounter_nr` IN " & liste & "  AND  `islab`=0 " ' "AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"

            qry5 = "SELECT COUNT(*) as num  FROM `care_billing_bill_item` WHERE `encounter_nr` IN " & liste & "  AND  `islab`=1 " ' "AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"


            For j As Integer = 0 To (DataGridView1.Rows.Count - 1)

                If DataGridView1.Rows(j).Cells(6).Value = True Then
                    If tour = 0 Then
                        qry2 = qry2 & " AND `bill_no` IN (" & DataGridView1.Rows(j).Cells(0).Value '& ""
                        qry3 = qry3 & " AND `bill_no` IN (" & DataGridView1.Rows(j).Cells(0).Value
                        qry4 = qry4 & " AND `bill_no` IN (" & DataGridView1.Rows(j).Cells(0).Value
                        qry5 = qry5 & " AND `bill_no` IN (" & DataGridView1.Rows(j).Cells(0).Value

                    Else
                        qry2 = qry2 & " ," & DataGridView1.Rows(j).Cells(0).Value '& ""
                        qry3 = qry3 & " ," & DataGridView1.Rows(j).Cells(0).Value
                        qry4 = qry4 & " ," & DataGridView1.Rows(j).Cells(0).Value
                        qry5 = qry5 & " ," & DataGridView1.Rows(j).Cells(0).Value


                    End If


                    facturetotal = facturetotal + CInt(DataGridView1.Rows(j).Cells(3).Value)
                    factureclient = factureclient + CInt(DataGridView1.Rows(j).Cells(4).Value)
                    facturesociete = facturesociete + CInt(DataGridView1.Rows(j).Cells(5).Value)

                    '  MsgBox("Colonne " & i & " Cochez")
                    tour = tour + 1
                End If



            Next

            qry2 = qry2 & ")"
            qry3 = qry3 & ")"
            qry4 = qry4 & ")"
            qry5 = qry5 & ")"

            qry2 = qry2 & " GROUP BY `id` ORDER BY  `date`,`article`"
            qry3 = qry3 & " GROUP BY `id` ORDER BY  `date`,`article`"
            qry4 = qry4 & " GROUP BY `id` ORDER BY  `date`,`article`"
            qry5 = qry5 & " GROUP BY `id` ORDER BY  `date`,`article`"

            'MsgBox(qry2)

            Dim med, lab As Integer
            med = 0
            lab = 0


            Try
                myConn.Open()
                Comd = New MySqlCommand(qry4, myConn)
                med = Comd.ExecuteScalar
                myConn.Close()
            Catch ex As Exception
                myConn.Close()
            End Try


            Try
                myConn1.Open()
                Comd1 = New MySqlCommand(qry5, myConn1)
                lab = Comd1.ExecuteScalar
                myConn1.Close()
            Catch ex As Exception
                myConn1.Close()
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
            frm.qry2 = qry2
            frm.qry3 = qry3
            frm.Encounter = Encounter
            frm.facturesociete = facturesociete
            frm.factureclient = factureclient
            frm.facturetotal = facturetotal
            frm.nom = lbnom.Text
            frm.pid = lbpatient.Text
            frm.isbon = True

            'lbrequete.Text = qry2
            frm.ShowDialog()

        Else
            MsgBox("Selectionner une/des facture(s)")
        End If

        
    End Sub



End Class