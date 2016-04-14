Imports MySql.Data.MySqlClient

Public Class frmPharmacieRavitaillementMagasin
    Public Property Permission As String
    Public Property Utilisateur As String
    'Public ServerString As String

    Dim myConn As New MySqlConnection
    Dim Comd As MySqlCommand
    Dim PharmaReader As MySqlDataReader
    Dim dtaDataTableCommande As New DataTable
    Dim bindSourceCommande As New BindingSource
    Dim Qry As String

    Dim DB As New MySQLDataBaseAccess(frmMain.ServerString)

    Private Sub FillGrid(ByVal Var As String)
        Dim dtaAdapter As New MySqlDataAdapter
        Dim dtaDataTable As New DataTable
        Dim bindSource As New BindingSource

        'Qry = "SELECT item_id as Id, item_description as Article, purchasing_class as Type, quantity as Qte, unit_price as Price FROM care_tz_drugsandservices WHERE purchasing_class IN ('medicaments', 'Injectables', 'Pomades', 'Suspension', 'Supo', 'Vaccins', 'Sollutes') ORDER BY item_description ASC"
        'Qry = "SELECT p.item_id as Id, p.item_description as Article, SUM(s.qte) as Qte, p.unit_price as Price, p.purchasing_class as Type FROM care_tz_drugsandservices as p LEFT OUTER JOIN care_tz_stock_item_amount as s ON p.item_id=s.drugid WHERE p.purchasing_class IN ('medicaments', 'Injectables', 'Pomades', 'Suspension', 'Supo', 'Vaccins', 'Sollutes', 'Carnet', 'Consommables') GROUP BY p.item_id ORDER BY p.purchasing_class ASC, p.item_description ASC "

        Qry = "SELECT p.item_id as Id, p.item_description as Article, SUM(s.qte) as Qte, p.unit_price as Price, p.purchasing_class as Type FROM care_tz_drugsandservices as p LEFT OUTER JOIN care_tz_stock_item_amount as s ON p.item_id=s.drugid WHERE p.purchasing_class IN ('" & Var & "') GROUP BY p.item_id ORDER BY p.purchasing_class ASC, p.item_description ASC "
        Try
            myConn.Open()
            Comd = New MySqlCommand(Qry, myConn)

            dtaAdapter.SelectCommand = Comd

            dtaAdapter.Fill(dtaDataTable)

            bindSource.DataSource = dtaDataTable
            'link to the datagridview
            dgvStockActuel.DataSource = bindSource
            dtaAdapter.Update(dtaDataTable)
            myConn.Close()

            dgvStockActuel.AutoResizeColumns()
            dgvStockActuel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            For Each ColHead As DataGridViewColumn In dgvStockActuel.Columns
                ColHead.SortMode = DataGridViewColumnSortMode.NotSortable
                dgvStockActuel.Width += ColHead.Width
            Next


            dgvStockActuel.Columns("Id").Visible = False
            'dgvEltACommander.ReadOnly = True
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            myConn.Close()
        End Try

    End Sub

    Private Sub frmRavitaillementMagasin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim dtaAdapter As New MySqlDataAdapter
        Dim dtaDataTable As New DataTable
        Dim bindSource As New BindingSource


        dgvStockActuel.Rows.Clear()
        dgvStockActuel.Columns.Clear()

        'dtaDataTable.DataSet.Clear()
        bindSource.DataSource = Nothing
        dgvStockActuel.DataSource = Nothing

        myConn = New MySqlConnection
        myConn.ConnectionString = frmMain.ServerString
        Me.Utilisateur = frmMain.Utilisateur
        Me.Permission = frmMain.Permission
        Me.Text = Me.Text & " - " & frmMain.Utilisateur

        ''''
        '' Get the list of the available stock in the pharmacie
        ''
        ''''

        Qry = "SELECT DISTINCT purchasing_class FROM care_tz_drugsandservices WHERE purchasing_class IN ('medicaments', 'Injectables', 'Pomades', 'Suspension', 'Supo', 'Vaccins', 'Sollutes', 'Carnet', 'Consommables') ORDER BY purchasing_class ASC"
        Fillcbo(DB, cboListe, Qry)

        cboListe.SelectedIndex = 0

        'Initialise the datatable
        dtaDataTableCommande.Columns.Add("Id", GetType(Integer))
        dtaDataTableCommande.Columns.Add("Article", GetType(String))
        dtaDataTableCommande.Columns.Add("Qte", GetType(Integer))
        dtaDataTableCommande.Columns.Add("Batch", GetType(String))
        dtaDataTableCommande.Columns.Add("Expiration", GetType(String))
        dtaDataTableCommande.Columns.Add("Achat", GetType(Integer))
        dtaDataTableCommande.Columns.Add("Vente", GetType(Integer))
        dtaDataTableCommande.Columns.Add("Fournisseur", GetType(String))

        bindSourceCommande.DataSource = dtaDataTableCommande
        dgvEltACommander.DataSource = bindSourceCommande


        dgvEltACommander.AutoResizeColumns()
        dgvEltACommander.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        For Each ColHead As DataGridViewColumn In dgvEltACommander.Columns
            ColHead.SortMode = DataGridViewColumnSortMode.NotSortable
            dgvEltACommander.Width += ColHead.Width
        Next
        dgvEltACommander.Columns("Id").Visible = False

     End Sub

    Private Sub dgvStockActuel_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvStockActuel.CellContentClick
        Dim Id, rowIndex As Integer
        Dim Elt As String
        Dim Qte, SalePrice As Integer
        Dim newListRow As DataRow
        Dim Found As Boolean
        rowIndex = 0
        Found = False
        Id = dgvStockActuel.Rows(e.RowIndex).Cells("Id").Value
        If dgvEltACommander.Rows.Count > 0 Then
            For Each row As DataGridViewRow In dgvEltACommander.Rows
                If Id = row.Cells("id").Value Then
                    Found = True
                Else
                    rowIndex = rowIndex + 1
                End If
            Next
        End If
        If Found = False Then
            Elt = dgvStockActuel.Rows(e.RowIndex).Cells("Article").Value.ToString
            If IsDBNull(dgvStockActuel.Rows(e.RowIndex).Cells("Qte").Value) Then
                Qte = 0
            Else
                Qte = CInt(dgvStockActuel.Rows(e.RowIndex).Cells("Qte").Value)
            End If
            SalePrice = CInt(dgvStockActuel.Rows(e.RowIndex).Cells("Price").Value)

            'Creer une nouvelle ligne a ajouter a la datatable
            newListRow = dtaDataTableCommande.NewRow
            newListRow("Id") = Id
            newListRow("Article") = Elt
            newListRow("Qte") = 1
            newListRow("Batch") = ""
            newListRow("Expiration") = Now().ToString("yyyy-MM-dd")
            newListRow("Achat") = 0
            newListRow("Vente") = SalePrice
            newListRow("Fournisseur") = ""
            dtaDataTableCommande.Rows.Add(newListRow)
            dtaDataTableCommande.AcceptChanges()
        Else
            MsgBox("Cet element est deja dans la liste.", vbCritical Or vbOK)
        End If
    End Sub

    Private Sub lstListeCommande_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    ''
    '' Block les 2 premier elements qui neseront pas editables
    ''
    Private Sub dgvEltACommander_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEltACommander.CellContentClick
        If e.ColumnIndex > -1 Then
            dgvEltACommander.Rows(e.RowIndex).Cells("Id").ReadOnly = True
            dgvEltACommander.Rows(e.RowIndex).Cells("Article").ReadOnly = True
        End If

    End Sub


    Private Sub btnValider_Click(sender As System.Object, e As System.EventArgs) Handles btnValider.Click
        Dim Qry As String
        Dim Id, QtyStock As Integer
        Dim Pharma, Batch, Fournisseur, Expire As String
        Dim Qte, Achat, Vente As Integer
        Dim Found As Boolean

        'Initialiser found a faux
        Found = False

        Try
            'myConn.Open()
            Pharma = Pharmacie(Me.Permission)

            For Each row As DataGridViewRow In dgvEltACommander.Rows
                Id = CInt(row.Cells("Id").Value)
                Qte = CInt(row.Cells("Qte").Value)
                Batch = row.Cells("Batch").Value
                Fournisseur = row.Cells("Fournisseur").Value
                Expire = row.Cells("Expiration").Value
                Achat = CInt(row.Cells("Achat").Value)
                Vente = CInt(row.Cells("Vente").Value)

                'Verifier si l'element existe dans la table de ravitaillement
                Qry = "SELECT drugid, qte FROM care_tz_stock_item_amount WHERE batch='" & Batch & "' AND expire='" & Expire & "' AND drugid=" & Id

                myConn.Open()
                Comd = New MySqlCommand(Qry, myConn)

                PharmaReader = Comd.ExecuteReader
                PharmaReader.Read()

                If PharmaReader.HasRows Then
                    QtyStock = CInt(PharmaReader("qte")) + Qte
                    Found = True
                End If
                myConn.Close()

                If Found = True Then
                    'Si l'element existe avec la meme date d'expiration et numero de batch, juste le mettre a jour
                    Qry = "UPDATE care_tz_stock_item_amount SET qte =" & QtyStock & " WHERE batch='" & Batch & "' AND expire='" & Expire & "' AND drugid=" & Id
                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)
                    Comd.ExecuteNonQuery()
                    myConn.Close()
                Else
                    'sinon inserer cet elements dans la base des donnees du ravitaillement
                    Qry = "INSERT INTO care_tz_stock_item_amount (drugid, qte, batch, expire, achat, vente, fournisseur) " & _
                        "VALUES (" & Id & "," & Qte & ",'" & Batch & "', '" & Expire & "'," & Achat & "," & Vente & ",'" & Fournisseur & "')"
                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)
                    Comd.ExecuteNonQuery()
                    myConn.Close()
                End If

                'Rajouter les nouvelles quantites commandees dans le total general
                'Qry = "SELECT quantity FROM care_tz_drugsandservices WHERE item_id=" & Id

                'myConn.Open()
                'Comd = New MySqlCommand(Qry, myConn)

                'PharmaReader = Comd.ExecuteReader
                'PharmaReader.Read()

                'If PharmaReader.HasRows Then
                'QtyStock = CInt(PharmaReader("quantity")) + Qte
                'Found = True
                'End If
                'myConn.Close()

                'Update les quantite dans care_tz_drugsandservices
                'Qry = "UPDATE care_tz_drugsandservices SET quantity =" & QtyStock & " WHERE item_id=" & Id
                'myConn.Open()
                'Comd = New MySqlCommand(Qry, myConn)
                'Comd.ExecuteNonQuery()
                'myConn.Close()
            Next
            MsgBox("Ravitaillement Fait Avec Success!.", vbInformation Or vbOKOnly, "Ravitaillement Produits")

        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            myConn.Close()
        End Try
        Me.Close()
    End Sub

    Private Sub dgvEltACommander_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEltACommander.CellDoubleClick
        dgvEltACommander.Rows.Remove(dgvEltACommander.CurrentRow)
    End Sub


    Private Sub cboListe_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboListe.SelectedIndexChanged
        Dim Var As String
        Var = cboListe.Text
        'dgvStockActuel.Refresh()
        FillGrid(Var)
    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs)

    End Sub
End Class