Imports MySql.Data.MySqlClient
Public Class frmAjoutAssurance
    Dim myConn As New MySqlConnection
    Dim Comd As MySqlCommand
    Dim Reader As MySqlDataReader
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub FillDataGrid()
        myConn = New MySqlConnection
        myConn.ConnectionString = frmMain.ServerString
        Dim dtaAdapter As New MySqlDataAdapter
        Dim dtaDataTable As New DataTable
        Dim bindSource As New BindingSource
        'Dim newListRow As DataRow

        Dim qry As String


        'Selectionner les donnees de la table des assurances et les afficher dans le dataGrid
        qry = "SELECT name as Assurance, contact as Contact, city as Ville, bp as BP, maxpay as Plafond, phone as Tél, email, exclusion " & _
            "FROM care_insurances ORDER BY name ASC"
        myConn.Open()
        Comd = New MySqlCommand(qry, myConn)
        dtaAdapter.SelectCommand = Comd
        dtaAdapter.Fill(dtaDataTable)
        'dtaDataTable.Columns.Add("total", GetType(Integer))
        bindSource.DataSource = dtaDataTable

        'link to the datagridview
        dgvInsurances.DataSource = bindSource
        dtaAdapter.Update(dtaDataTable)
        dgvInsurances.AutoResizeColumns()
        dgvInsurances.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvInsurances.MultiSelect = True
        dgvInsurances.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        For Each ColHead As DataGridViewColumn In dgvInsurances.Columns
            ColHead.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        myConn.Close()

    End Sub
    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        myConn.Close()
        myConn.ConnectionString = frmMain.ServerString
        Dim dtaAdapter As New MySqlDataAdapter
        Dim dtaDataTable As New DataTable
        Dim bindSource As New BindingSource
        'Dim newListRow As DataRow

        Dim qry As String
        Dim MaxPay As Integer
        Dim isChecked As Boolean
        'Remplir les donnees dans le datagrid

        dgvInsurances.DataSource = Nothing
        dgvInsurances.Rows.Clear()
        dgvInsurances.Columns.Clear()
        bindSource.DataSource = Nothing
        'Verifier si rien n'est saisie dans les zone des texte
        If txtInsurance.Text.Trim = "" Then
            FillDataGrid()
            MsgBox("Vous devez saisir le nom de l'assureur.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Assureur!")
            txtInsurance.Focus()
            Exit Sub
        End If
        If txtContact.Text.Trim = "" Then
            FillDataGrid()
            MsgBox("Vous devez saisir le nom du contact.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Contact!")
            txtContact.Focus()
            Exit Sub
        End If
        If txtBP.Text.Trim = "" Then
            FillDataGrid()
            MsgBox("Vous devez saisir la boite postale.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Boite Postale!")
            txtBP.Focus()
            Exit Sub
        End If
        If txtCity.Text.Trim = "" Then
            FillDataGrid()
            MsgBox("Vous devez saisir nom de la ville.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Ville!")
            txtCity.Focus()
            Exit Sub
        End If
        If txtTel.Text.Trim = "" Then
            FillDataGrid()
            MsgBox("Vous devez saisir le numero du téléphone.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Téléphone!")
            txtTel.Focus()
            Exit Sub
        End If

        'Ajouter les elements dans la table des assureurs
        If txtMaxPay.Text.Trim = "" Then
            MaxPay = 0
        Else
            MaxPay = Integer.Parse(txtMaxPay.Text)
        End If
        If chkExclude.Checked Then
            isChecked = 1
        Else
            isChecked = 0
        End If
        FillDataGrid()
        qry = "SELECT * FROM care_insurances WHERE name='" & txtInsurance.Text & "' AND city='" & txtCity.Text & "'"
        myConn.Open()
        Comd = New MySqlCommand(qry, myConn)
        Reader = Comd.ExecuteReader
        If Reader.HasRows = False Then
            myConn.Close()
            myConn.Open()
            qry = "INSERT INTO care_insurances (name, maxpay, contact, bp, city, phone, email, exclusion) VALUES ('" & _
                txtInsurance.Text & "'," & MaxPay & ",'" & txtContact.Text & "','" & txtBP.Text & _
                "','" & txtCity.Text & "','" & txtTel.Text & "','" & txtEmail.Text & "'," & isChecked & ")"
            Comd = New MySqlCommand(qry, myConn)
            Reader = Comd.ExecuteReader
            FillDataGrid()
        Else
            FillDataGrid()
            MsgBox("Cette Compagnie d'assurance existe déjà!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur")
        End If
        myConn.Close()
    End Sub

    Private Sub frmAjoutAssurance_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillDataGrid()
    End Sub
End Class