Imports MySql.Data.MySqlClient

Public Class frmAvancePaie
    Public Property Permission As String
    Public Property Utilisateur As String
    'Public ServerString As String

    Dim myConn As New MySqlConnection
    Dim Comd As MySqlCommand
    Public Encounter, Bill As ULong
    Dim Reader As MySqlDataReader
    Dim SQL, Name, Agent As String
    Dim Facture As Integer
    Dim AAvancer, Avances, NoFacture, PId, Reste As Long
    Dim User As String
    Dim FactureAssure As Long = 0
    Dim FactureAssurance As Long = 0
    Dim FactureTotale As Long = 0
    Dim APayer As Long
    Public Outside As Boolean = False
    Dim rpt As New rptFactureAvance

    Dim DB As New MySQLDataBaseAccess(frmMain.ServerString)

    Private Sub btnQuit_Click(sender As System.Object, e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Public Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        If Outside = False Then
            Encounter = GetPatientInformation(txtSearch, txtInfos)
        End If
        'Retrouver le montant que le patient a deja payer
        If Encounter > 0 Then
            Name = GetPatientName(CLng(txtSearch.Text), DB)
            'txtFacture.Text = Montant(Encounter)
            grpRembourser.Enabled = True
            grpAvance.Enabled = True
            'txtAAvancer.Focus()
            Try
                'Fill the combobox with all the bills of the patient
                DB.AddParams("@encounter", Encounter)
                DB.AddParams("@paid", 0)
                SQL = "SELECT DISTINCT (receipt_no) FROM care_billing_payment WHERE encounter_nr=@encounter AND paid=@paid ORDER BY receipt_no DESC"

                Fillcbo(DB, cboChoixFacture, SQL)
                If DB.RecordCount > 0 Then
                    cboChoixFacture.SelectedIndex = 0
                Else
                    MsgBox("Patient n'a pas de facture", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Avancement")
                    txtSearch.Focus()
                    Exit Sub
                End If
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
        'Dim Prescriber As String
        Try
            If txtAAvancer.Text > 0 Then
                Valide = ValideTextBox(txtAAvancer, 2)
                If Valide = True Then
                    If CLng(txtAAvancer.Text) > CLng(txtFacture.Text) Then
                        MsgBox("Le montant a avancer ne peut pas etre superieur au montant de la facture!", vbCritical Or vbOKOnly, "Erreur!")
                        txtAAvancer.SelectAll()
                        Exit Sub
                    End If

                    If CLng(txtAAvancer.Text) < 0 Then
                        MsgBox("Le montant a avancer ne peut pas etre negatif!", vbCritical Or vbOKOnly, "Erreur!")
                        txtAAvancer.SelectAll()
                        Exit Sub
                    End If

                    If CLng(txtAAvancer.Text) > (txtReste.Text) Then
                        MsgBox("Le montant a avancer depasse le solde a payer.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Avance")
                    Else
                        txtReste.Text = CLng(txtFacture.Text) - (CLng(txtAvances.Text) + CLng(txtAAvancer.Text))
                        'Mettre a jour le champ de payement dans la table care_tz_billing_bill_item
                        DB.AddParams("@status", "avance")
                        DB.AddParams("@billno", Facture)
                        SQL = "UPDATE care_billing_bill_item SET status=@status WHERE bill_no=@billno"
                        DB.ExecQuery(SQL)

                        'Inserer l'avance dans la liste des avances
                        DB.AddParams("@encounter", Encounter)
                        DB.AddParams("@billno", Facture)
                        DB.AddParams("@avance", CLng(txtAAvancer.Text))
                        DB.AddParams("@date", Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        DB.AddParams("@utilisateur", Me.Utilisateur)

                        SQL = "INSERT INTO care_billing_avances (encounter_nr,bill_no,avance,date,encaisseur) VALUES " & _
                            "(@encounter,@billno,@avance,@date,@utilisateur)"
                        DB.ExecQuery(SQL)


                        If CLng(txtReste.Text) = 0 Then
                            'Mettre a jour care_billing_bill_item
                            DB.AddParams("@datepaid", Now.ToString("yyyy-MM-dd HH:mm"))
                            DB.AddParams("@paid", CLng(txtFacture.Text))
                            DB.AddParams("@encaisseur", Me.Utilisateur)
                            DB.AddParams("@id", Facture)
                            SQL = "UPDATE care_billing_payment SET datepaid=@datepaid, paid=@paid, encaisseur=@encaisseur WHERE receipt_no=@id"
                            DB.ExecQuery(SQL)

                            'Update care_tz_billing
                            DB.AddParams("@status", "paid")
                            DB.AddParams("@bill_no", Facture)
                            SQL = "UPDATE care_billing_bill_item SET status=@status WHERE bill_no=@bill_no"
                            DB.ExecQuery(SQL)

                            'Inserrer dans la facture finale
                            DB.AddParams("@encounter", Encounter)
                            DB.AddParams("@bill", Facture)
                            DB.AddParams("@date", Now.ToString("yyyy-MM-dd HH:mm"))
                            DB.AddParams("@amount", CLng(txtFacture.Text))
                            DB.AddParams("@received", CLng(txtFacture.Text))
                            DB.AddParams("@agent", Me.Utilisateur)
                            DB.AddParams("@status", "paid")

                            SQL = "INSERT INTO care_billing_final (encounter_nr, bill_no, date, bill_amount, amount_recieved, agent, status) " & _
                                "VALUES (@encounter, @bill, @date, @amount, @received, @agent, @status)"
                            DB.ExecQuery(SQL)

                            'Update care_tz_billing_avances
                            DB.AddParams("@status", "paid")
                            DB.AddParams("@bill_no", Facture)
                            SQL = "UPDATE care_billing_avances SET status=@status WHERE bill_no=@bill_no"
                            DB.ExecQuery(SQL)

                        End If
                        'rpt.PrintToPrinter(1, False, 0, 0)
                        rpt.PrintToPrinter(1, False, 0, 0)

                        Controls.Clear()
                        InitializeComponent()
                        Show()
                    End If


                    'Me.Close()

                End If
            Else
                MsgBox("Bien vouloir saisir le montant a avancer svp!", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Avances")
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
        If Outside = True Then
            cboChoixFacture.Items.Add(Bill)
            cboChoixFacture.SelectedIndex = 0
        End If
        Me.crptFacture.RefreshReport()
    End Sub

    Private Sub cboChoixFacture_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboChoixFacture.SelectedIndexChanged
        Dim dtaAdapter As New MySqlDataAdapter
        Dim dtaDataTable As New DataTable
        Dim bindSource As New BindingSource

        'Dim newListRow As DataRow
        txtAvances.Text = 0
        txtAAvancer.Text = 0
        Try
            'dgvElements.Rows.Clear()
            'dgvElements.Columns.Clear()
            If myConn.State = ConnectionState.Open Then myConn.Close()
            bindSource.DataSource = Nothing
            'dgvElements.DataSource = Nothing

            Facture = CInt(cboChoixFacture.SelectedItem)
            'SQL = "SELECT code, article as Article, unit_cost as Prix, units as Unite, amount as Total FROM care_billing_bill_item WHERE encounter_nr=" & Encounter & " AND bill_no=" & Facture
            'myConn.Open()
            'Comd = New MySqlCommand(SQL, myConn)
            ''Reader = Comd.ExecuteReader
            'dtaAdapter.SelectCommand = Comd

            'dtaAdapter.Fill(dtaDataTable)
            ''dtaDataTable.Columns.Add("Remboursé", GetType(Boolean))

            'bindSource.DataSource = dtaDataTable
            ''link to the datagridview
            'dgvElements.DataSource = bindSource
            'dtaAdapter.Update(dtaDataTable)
            'myConn.Close()

            'dgvElements.Visible = True
            'dtaDataTable.AcceptChanges()


            ''Resize the columns of the datagridview
            'dgvElements.AutoResizeColumns()
            'dgvElements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            'For Each ColHead As DataGridViewColumn In dgvElements.Columns
            'ColHead.SortMode = DataGridViewColumnSortMode.NotSortable
            'ColHead.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'dgvElements.Width += ColHead.Width
            'Next
            'dgvElements.Columns("code").Visible = False
            'dgvElements.Columns("Prix").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'dgvElements.Columns("Unite").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'dgvElements.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'Get the total amount of the bill
            SQL = "SELECT amount, billgeneral, agent FROM care_billing_bill WHERE encounter_nr=" & Encounter & " AND bill_no=" & Facture
            myConn.Open()
            Comd = New MySqlCommand(SQL, myConn)
            Reader = Comd.ExecuteReader
            Reader.Read()

            If Reader.HasRows Then
                FactureTotale = Reader("billgeneral")
                FactureAssure = Reader("amount")
                agent = Reader("agent")
            End If
            myConn.Close()
            txtFacture.Text = FactureAssure
            txtTotal.Text = FactureTotale
            'Acquerir les totaux des avances
            SQL = "SELECT sum(avance) as avance FROM care_billing_avances WHERE encounter_nr=" & Encounter & " AND bill_no=" & Facture
            myConn.Open()
            Comd = New MySqlCommand(SQL, myConn)
            Reader = Comd.ExecuteReader
            Reader.Read()

            If Reader.HasRows Then
                If Not IsDBNull(Reader("avance")) Then
                    txtAvances.Text = Reader("avance")
                End If

            Else
                txtAvances.Text = 0
            End If
            myConn.Close()

            If String.IsNullOrEmpty(txtAvances.Text) Then txtAvances.Text = 0

            txtReste.Text = CInt(txtFacture.Text) - CInt(txtAvances.Text)
            If txtAAvancer.Text = "" Then
                AAvancer = 0
            Else
                AAvancer = CLng(txtAAvancer.Text)
            End If
            If txtAvances.Text = "" Then
                Avances = 0
            Else
                Avances = CLng(txtAvances.Text)
            End If
            APayer = CLng(txtFacture.Text)
            User = Me.Utilisateur
            NoFacture = CLng(cboChoixFacture.Text)
            PId = CLng(txtSearch.Text)


            'Afficher la facture
            ''AAvancer = CLng(txtAAvancer.Text)
            If (Avances + AAvancer) > APayer Then
                txtAAvancer.Text = APayer - Avances
            End If
            ''AAvancer = CLng(txtAAvancer.Text)
            Avances = Avances + AAvancer
            Reste = APayer - Avances

            SQL = "SELECT `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=0 AND (status='billed' OR status='avance') AND `bill_no`=" & CLng(cboChoixFacture.Text) & " ORDER BY  article"
            AfficherFacture(Encounter, NoFacture, User, Agent, AAvancer, Avances, _
                            FactureTotale, PId, Name, APayer, Reste, crptFacture, rpt, DB, SQL)
            btnValidate.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Close()
            'myConn.Dispose()
        End Try
    End Sub

    Private Sub txtAAvancer_Leave(sender As Object, e As System.EventArgs) Handles txtAAvancer.Leave

    End Sub

    Private Sub txtAAvancer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAAvancer.TextChanged


    End Sub

    Private Sub txtReste_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtReste.TextChanged

    End Sub

    Private Sub crptFacture_Load(sender As System.Object, e As System.EventArgs) Handles crptFacture.Load

    End Sub
End Class