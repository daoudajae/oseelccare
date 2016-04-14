Imports MySql.Data.MySqlClient

Public Class frmRemboursement
    Public Property Permission As String
    Public Property Utilisateur As String
    'Public ServerString As String

    Dim myConn As New MySqlConnection
    Dim Comd As MySqlCommand
    Dim Encounter As ULong
    Dim Reader As MySqlDataReader
    Dim SQL As String
    Dim Facture As Integer

    Private Sub btnQuit_Click(sender As System.Object, e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click

        Encounter = GetPatientInformation(txtSearch, txtInfos)

        'Retrouver le montant que le patient a deja payer
        If Encounter > 0 Then
            'txtFacture.Text = Montant(Encounter)
            grpRembourser.Enabled = True
            grpAvance.Enabled = True
            txtAAvancer.Focus()
            Try
                'Fill the combobox with all the bills of the patient
                SQL = "SELECT DISTINCT (bill_no) FROM care_billing_bill_item WHERE encounter_nr=" & Encounter & " ORDER BY bill_no DESC"
                myConn.Open()
                Comd = New MySqlCommand(SQL, myConn)
                Reader = Comd.ExecuteReader
                'Reader.Read()
                cboChoixFacture.Items.Clear()
                While Reader.Read
                    cboChoixFacture.Items.Add(Reader("bill_no").ToString)
                End While
                myConn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                myConn.Close()
                myConn.Dispose()

            End Try

        End If
    End Sub

    'Valider le paiement de l'avance
    Private Sub btnValidate_Click(sender As System.Object, e As System.EventArgs) Handles btnValidate.Click
        Dim Valide As Boolean
        Dim Prescriber As String
        Try

            Valide = ValideTextBox(txtAAvancer, 2)
            If Valide = True Then
                If CLng(txtAAvancer.Text) > CLng(txtFacture.Text) Then
                    MsgBox("Le montant a rembourser ne peut pas etre superieur au montant deja paye!", vbCritical Or vbOKOnly, "Erreur!")
                    txtAAvancer.SelectAll()
                    Exit Sub
                End If

                If CLng(txtAAvancer.Text) < 0 Then
                    MsgBox("Le montant a rembourser ne peut pas etre negatif!", vbCritical Or vbOKOnly, "Erreur!")
                    txtAAvancer.SelectAll()
                    Exit Sub
                End If


                SQL = "SELECT configureur FROM care_billing_remboursement WHERE encounter=" & Encounter & " AND montantpayer=" & CLng(txtFacture.Text)
                myConn.Open()
                Comd = New MySqlCommand(SQL, myConn)
                Reader = Comd.ExecuteReader
                Reader.Read()
                If Reader.HasRows = True Then
                    Prescriber = Reader.Item("configureur")
                    MsgBox("Ce remboursement a deja ete configurer par " & Prescriber, MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Remboursement")
                    myConn.Close()
                Else
                    myConn.Close()
                    SQL = "INSERT INTO care_billing_remboursement (encounter, montantpayer, billno, remboursement, configureur, dateconfig) " & _
                        "VALUES (" & Encounter & "," & CLng(txtFacture.Text) & ", 0, " & CLng(txtAAvancer.Text) & ",'" & Me.Utilisateur & "','" & Now().ToString("yyyy-MM-dd hh:mm") & "')"
                    myConn.Open()
                    Comd = New MySqlCommand(SQL, myConn)
                    Comd.ExecuteNonQuery()
                    myConn.Close()
                    MsgBox("Configuration du remboursement fait. Veuillez voir l'econome.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Remboursement")
                End If
                Me.Close()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            myConn.Close()

        End Try

    End Sub

    Private Sub frmConfigureRemboursement_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        myConn = New MySqlConnection
        myConn.ConnectionString = frmMain.ServerString
        Me.Utilisateur = frmMain.Utilisateur
        'Me.Text = "Remboursement - " & frmMain.Utilisateur

    End Sub

    Private Sub cboChoixFacture_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboChoixFacture.SelectedIndexChanged
        Dim dtaAdapter As New MySqlDataAdapter
        Dim dtaDataTable As New DataTable
        Dim bindSource As New BindingSource
        'Dim newListRow As DataRow



        Try
            'dgvElements.Rows.Clear()
            'dgvElements.Columns.Clear()
            bindSource.DataSource = Nothing
            dgvElements.DataSource = Nothing

            Facture = CInt(cboChoixFacture.SelectedItem)
            SQL = "SELECT code, article as Article, unit_cost as Prix, units as Unite, amount as Total FROM care_billing_bill_item WHERE encounter_nr=" & Encounter & " AND bill_no=" & Facture
            myConn.Open()
            Comd = New MySqlCommand(SQL, myConn)
            'Reader = Comd.ExecuteReader
            dtaAdapter.SelectCommand = Comd

            dtaAdapter.Fill(dtaDataTable)
            dtaDataTable.Columns.Add("Remboursé", GetType(Boolean))

            bindSource.DataSource = dtaDataTable
            'link to the datagridview
            dgvElements.DataSource = bindSource
            dtaAdapter.Update(dtaDataTable)
            myConn.Close()

            dgvElements.Visible = True
            dtaDataTable.AcceptChanges()

            'Resize the columns of the datagridview
            dgvElements.AutoResizeColumns()
            dgvElements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            For Each ColHead As DataGridViewColumn In dgvElements.Columns
                ColHead.SortMode = DataGridViewColumnSortMode.NotSortable
                'ColHead.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvElements.Width += ColHead.Width
            Next
            dgvElements.Columns("code").Visible = False
            dgvElements.Columns("Prix").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvElements.Columns("Unite").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvElements.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'Get the total amount of the bill
            SQL = "SELECT billgeneral FROM care_billing_bill WHERE encounter_nr=" & Encounter & " AND bill_no=" & Facture
            myConn.Open()
            Comd = New MySqlCommand(SQL, myConn)
            Reader = Comd.ExecuteReader
            Reader.Read()

            If Reader.HasRows Then
                txtFacture.Text = Reader("billgeneral")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Close()
            myConn.Dispose()
        End Try
    End Sub
End Class