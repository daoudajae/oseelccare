Imports MySql.Data.MySqlClient

Public Class frmGestionCaissePrincipale
    Private Libele As New AutoCompleteStringCollection
    Private Montant As New AutoCompleteStringCollection
    Private Client As New AutoCompleteStringCollection
    Private Quittancier As New AutoCompleteStringCollection
    Private myConn As New MySqlConnection
    Private Comd As New MySqlCommand
    Private drDataReader As MySqlDataReader
    Private acctDataReader As MySqlDataReader
    Private SQL As String
    Private numJournal As Integer

    Private Sub btnQuitter_Click(sender As System.Object, e As System.EventArgs) Handles btnQuitter.Click
        Me.Close()
    End Sub

    Private Sub txtDescription_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescription.KeyDown
        If e.KeyValue = Keys.Tab Or e.KeyValue = Keys.Enter Then
            txtNumOrdre.Focus()
        End If
    End Sub

    Private Sub txtDescription_Leave(sender As Object, e As System.EventArgs) Handles txtDescription.Leave

    End Sub

    'Mettre a jour les champs concernes lorsqu'un libele est selectionne de la liste des libeles
    Private Sub txtDescription_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescription.LostFocus
        Dim Description, Account As String

        Try
            Description = txtDescription.Text.Replace("'", "''")
            SQL = "SELECT contrepartie, direction FROM care_cashier_transactions_description WHERE description = '" & Description & "'"

            drDataReader = ReturnDataReader(myConn, SQL)
            If drDataReader.Read Then
                SQL = "SELECT acountnumber, accountdescription FROM care_cashier_accounts WHERE acountnumber "
                Account = drDataReader.Item("contrepartie").ToString.Remove(0, 2).ToString
                If Account.Length = 5 Then
                    cboContrepartie.Text = Account
                    'txtNumOrdre.Focus()
                Else
                    cboContrepartie.Text = Account
                End If
                txtDebitCredit.Text = drDataReader.Item("direction")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Erreur! - txtDescription_TextChanged")
        End Try

    End Sub

    Private Sub frmGestionCaissePrincipale_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Create the autoComplete collection for the description of the transaction
        txtCpteTresorerie.Text = 57100
        myConn.ConnectionString = frmMain.ServerString

        Try
            'Ajout de la liste des libeles pour la liste auto complete
            SQL = "SELECT distinct description FROM care_cashier_transactions_description"
            drDataReader = ReturnDataReader(myConn, SQL)

            While drDataReader.Read()
                Libele.Add(drDataReader.Item(0))
            End While
            txtDescription.AutoCompleteCustomSource = Libele

            'Ajout des comptes dans la liste auto complete des comptes contreparties
            SQL = "SELECT accountnumber, accountdescription FROM care_cashier_accounts"
            acctDataReader = ReturnDataReader(myConn, SQL)
            'cboContrepartie.Items.Clear()
            While acctDataReader.Read
                Libele.Add(acctDataReader.Item(0) & " - " & acctDataReader.Item(1))
            End While
            cboContrepartie.AutoCompleteCustomSource = Libele

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur - Gestion Caisse Principale!")
        End Try

        'UpdateAutocomplete(txtDescription)
    End Sub

    Private Sub btnCreerJournal_Click(sender As System.Object, e As System.EventArgs) Handles btnCreerJournal.Click
        Dim newJournal As Integer
        Dim arrSelectFields(0), arrInsertFields(1, 1), arrWhere(0, 1), arrOrderGroup(0, 2), strArr(3, 2), strDate, strTable As String

        Try
            If btnCreerJournal.Text = "Nouveau Journal" Then
                SQL = "INSERT INTO "
                strTable = "care_cashier_journals ("

                'Donner la liste des elements pour constituer la requette
                strDate = String.Format("{0:yyyy-MM-dd}", dtpDate.Value)
                'Champ suivi de la valeur a inserer
                arrInsertFields(0, 0) = "description"
                arrInsertFields(0, 1) = "'Journal de Caisse - " & strDate & "'"

                'Champ suivi de la valeur a inserer
                arrInsertFields(1, 0) = "date"
                arrInsertFields(1, 1) = "'" & strDate & "'"

                'Generer et executer la requette pour inserer les donnees dans la table
                GenererNonRequette(myConn, SQL, strTable, arrInsertFields)

                'recuperer le numero du nouveau journal pour l'afficher
                SQL = "SELECT "
                'Fields to select
                arrSelectFields(0) = "id"

                'table to select from
                strTable = "care_cashier_journals"

                'Conditions, ici il y en a aucune

                'Tri et groupement
                arrOrderGroup(0, 0) = "ORDER BY "
                arrOrderGroup(0, 1) = "id "
                arrOrderGroup(0, 2) = "DESC"


                drDataReader = GenererRequetteSelect(myConn, SQL, strTable, arrSelectFields, , arrOrderGroup)
                If drDataReader.Read Then
                    newJournal = drDataReader.Item("id")
                End If
                txtNumJournal.Text = newJournal
            ElseIf btnCreerJournal.Text = "Editer Journal" Then
                txtNumJournal.Enabled = True
                'recuperer le numero du nouveau journal pour l'afficher
                SQL = "SELECT "
                'Fields to select
                arrSelectFields(0) = "id"

                'table to select from
                strTable = "care_cashier_journals"

                'Conditions, ici il y en a aucune
                arrWhere(0, 0) = "id"
                arrWhere(0, 1) = Integer.Parse(txtNumJournal.Text.ToString)

                drDataReader = GenererRequetteSelect(myConn, SQL, strTable, arrSelectFields, arrWhere)
                If drDataReader.Read Then
                    newJournal = drDataReader.Item("id")
                End If
                txtNumJournal.Text = newJournal
                SQL = "SELECT cptecontrepartie, numordre, description, date, credit, debit, numfacture, client, id, numquitancier " & _
                    "FROM care_cashier_transactions WHERE numjournal=" & newJournal
                myConn.Close()
                AfficherElementDataGridView(myConn, SQL, dgvCaisse)
                txtTotalCredit.Text = CalculCreditDebit(1, newJournal)
                txtTotalDebit.Text = CalculCreditDebit(0, newJournal)
            End If
            'Activer le bloc pour edition du journal
            grpGestion.Enabled = True
            txtNumJournal.Enabled = False
            btnCreerJournal.Enabled = False
            cboContrepartie.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Erreur - Creation Nouveau Journal!")
        End Try
    End Sub

    Private Sub txtClient_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClient.LostFocus
  
    End Sub

    Private Sub txtClient_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClient.TextChanged

    End Sub

    Private Sub txtDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.TextChanged

    End Sub

    Private Sub txtMemo_Leave(sender As Object, e As System.EventArgs) Handles txtMemo.Leave
        Dim DbtCrt As Integer
        Dim arrFieldsValues(9, 1) As String
        Dim strTable As String
        'myConn.ConnectionString = frmMain.ServerString

        'Verifier si c'est un debit ou un credit au compte
        If txtDebitCredit.Text = "Credit" Then
            DbtCrt = 1
        Else
            DbtCrt = 0
        End If

        SQL = "INSERT INTO "
        strTable = "care_cashier_transactions ("
        'Liste des champs a inserer
        arrFieldsValues(0, 0) = "description"
        arrFieldsValues(1, 0) = "date"
        If DbtCrt = 1 Then
            arrFieldsValues(2, 0) = "credit"
        Else
            arrFieldsValues(2, 0) = "debit"
        End If
        arrFieldsValues(3, 0) = "type"
        arrFieldsValues(4, 0) = "numquitancier"
        arrFieldsValues(5, 0) = "numordre"
        arrFieldsValues(6, 0) = "numfacture"
        arrFieldsValues(7, 0) = "client"
        arrFieldsValues(8, 0) = "cptesource"
        arrFieldsValues(9, 0) = "cptecontrepartie"
        'arrFieldsValues(10, 0) = "numjournal"

        'liste des valeurs a inserer
        arrFieldsValues(0, 1) = "'" & txtDescription.Text.ToString.Replace("'", "''") & "'"
        arrFieldsValues(1, 1) = "'" & String.Format("{0:yyyy-MM-dd}", dtpDate.Value) & "'"
        arrFieldsValues(2, 1) = Integer.Parse(txtMontant.Text)
        arrFieldsValues(3, 1) = DbtCrt
        arrFieldsValues(4, 1) = "'" & txtNumeroQuittancier.Text & "'"
        arrFieldsValues(5, 1) = "'" & txtNumOrdre.Text & "'"
        arrFieldsValues(6, 1) = "'" & txtRefFacture.Text & "'"
        arrFieldsValues(7, 1) = "'" & txtClient.Text & "'"
        arrFieldsValues(8, 1) = "'" & txtCpteTresorerie.Text & "'"
        arrFieldsValues(9, 1) = "'" & cboContrepartie.Text & "'"
        'arrFieldsValues(10, 1) = Integer.Parse(txtNumJournal.Text)

        'Executer la requette pour inserer les donnees de la transaction dans la table transactions
        GenererNonRequette(myConn, SQL, strTable, arrFieldsValues)
        txtDescription.Focus()

    End Sub

    Private Sub txtMemo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMemo.TextChanged

    End Sub
End Class