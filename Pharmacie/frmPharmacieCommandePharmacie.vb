Imports MySql.Data.MySqlClient

Public Class frmPharmacieCommandePharmacie
    Public Property Permission As String
    Public Property Utilisateur As String
    'Public ServerString As String

    Dim myConn As New MySqlConnection
    Dim Comd As MySqlCommand
    Dim PharmaReader As MySqlDataReader
    Dim dtaDataTableCommande As New DataTable
    Dim bindSourceCommande As New BindingSource
    Dim Qry As String = ""
    Dim Pharma As String = ""
    Dim Id, QteStock As Integer


    Private Sub frmComandePharmacie_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

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

        Dim Qry, fieldPharma As String
        'Retrouver le service qui commande

        fieldPharma = Pharmacie(Me.Permission)

        'For debugging purposes
        If Me.Permission = "admin" Then
            fieldPharma = "pharma1"
        End If

        'Afficher celui qui commande

        lblOrderer.Text = "Commande pour " & Me.Permission.ToUpper & Environment.NewLine & "Pharmacien: " & Me.Utilisateur.ToUpper
        If fieldPharma = "pharma1" Then
            Pharma = "Box1"
        ElseIf fieldPharma = "pharma2" Then
            Pharma = "Box2"
        ElseIf fieldPharma = "pharma3" Then
            Pharma = "Box3"
        ElseIf fieldPharma = "pharma4" Then
            Pharma = "Box4"
        End If
        'Qry = "SELECT item_id as ID, item_description as Description, purchasing_class as Classe, " & fieldPharma & " as Qte FROM care_tz_drugsandservices WHERE purchasing_class ='medicaments' AND quantity>0 ORDER BY item_description ASC"
        Qry = "SELECT s.drugid as ID, p.item_description as Description, SUM(s.qte) as Magasin, p." & fieldPharma & _
            " as '" & Pharma & "', p.purchasing_class as Type FROM care_tz_drugsandservices as p " & _
            "LEFT JOIN care_tz_stock_item_amount as s ON s.drugid=p.item_id " & _
            "WHERE p.purchasing_class IN ('MEDICAMENTS', 'INJECTABLES', 'POMADES', 'SUSPENSION', 'SUPPOSITOIRES', 'VACCINS', 'SOLLUTES') AND s.qte>0 GROUP BY s.drugid ORDER BY p.purchasing_class ASC, p.item_description ASC"

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

            'Initialise the datatable
            dtaDataTableCommande.Columns.Add("Id", GetType(Integer))
            dtaDataTableCommande.Columns.Add("Article", GetType(String))
            dtaDataTableCommande.Columns.Add("Qte", GetType(Integer))

            bindSourceCommande.DataSource = dtaDataTableCommande
            dgvEltACommander.DataSource = bindSourceCommande


            dgvEltACommander.AutoResizeColumns()
            dgvEltACommander.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            For Each ColHead As DataGridViewColumn In dgvEltACommander.Columns
                ColHead.SortMode = DataGridViewColumnSortMode.NotSortable
                dgvEltACommander.Width += ColHead.Width
            Next

            dgvStockActuel.Columns("ID").Visible = False
            dgvEltACommander.Columns("Id").Visible = False
            'dgvEltACommander.ReadOnly = True
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            myConn.Close()
        End Try
    End Sub

    Private Sub dgvStockActuel_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvStockActuel.CellContentClick
        Dim rowIndex As Integer
        Dim Elt As String
        Dim Qte As Integer
        Dim newListRow As DataRow
        Dim Found As Boolean
        rowIndex = 0
        Found = False
        Id = dgvStockActuel.Rows(e.RowIndex).Cells("ID").Value


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
            Elt = dgvStockActuel.Rows(e.RowIndex).Cells("Description").Value.ToString
            Qte = CLng(dgvStockActuel.Rows(e.RowIndex).Cells("Magasin").Value)

            'Creer une nouvelle ligne a ajouter a la datatable
            newListRow = dtaDataTableCommande.NewRow
            newListRow("Id") = Id
            newListRow("Article") = Elt
            newListRow("Qte") = 1
            dtaDataTableCommande.Rows.Add(newListRow)
            dtaDataTableCommande.AcceptChanges()
        Else
            MsgBox("Cet element est deja dans la liste.", vbCritical Or vbOKOnly)
        End If
    End Sub

    Private Sub lstListeCommande_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub


    Private Sub dgvEltACommander_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEltACommander.CellContentClick

    End Sub

    Private Sub btnNext_DoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles btnValider.DoubleClick
        dtaDataTableCommande.Rows(e.RowIndex).Delete()
        dtaDataTableCommande.AcceptChanges()

    End Sub

    Private Sub btnValider_Click(sender As System.Object, e As System.EventArgs) Handles btnValider.Click
        Dim Qry As String
        Dim Id As Integer
        Dim Pharma As String
        Dim Qte As Integer
        If dgvEltACommander.RowCount > 0 Then
            Try
                'myConn.Open()
                Pharma = Pharmacie(Me.Permission)

                For Each row As DataGridViewRow In dgvEltACommander.Rows
                    Id = CInt(row.Cells("Id").Value)
                    'Elt = row.Cells("Article").Value.ToString
                    Qte = CInt(row.Cells("Qte").Value)
                    If Qte > 0 Then
                        Qry = "INSERT INTO care_tz_stock_transfer (drugid, qtedemande, transfererde, transferera, datecommande, commandepar) " & _
                            "VALUES (" & Id & "," & Qte & ", 'stock','" & Pharma & "','" & Now().ToString("yyyy-MM-dd hh:mm") & "','" & Me.Utilisateur & "')"
                        myConn.Open()
                        Comd = New MySqlCommand(Qry, myConn)
                        Comd.ExecuteNonQuery()
                        myConn.Close()
                    End If
                Next
                MsgBox("Commande Faite Avec Success!.", vbInformation Or vbOKOnly, "Commande Produits")

            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                myConn.Close()
            End Try
            Me.Close()
        Else
            MsgBox("Aucune Commande faite.  SVP Choisir les elements a commander", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Commande des produits")
        End If
    End Sub

    Private Sub dgvEltACommander_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEltACommander.CellDoubleClick
        dgvEltACommander.Rows.Remove(dgvEltACommander.CurrentRow)
    End Sub


    Private Sub dgvEltACommander_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEltACommander.CellValueChanged
        Dim QteCommande As Integer

        dgvEltACommander.Rows(e.RowIndex).Cells("Id").ReadOnly = True
        dgvEltACommander.Rows(e.RowIndex).Cells("Article").ReadOnly = True
        Id = CInt(dgvEltACommander.Rows(e.RowIndex).Cells("Id").Value)
        Try

            If ((e.ColumnIndex = 2) And (e.RowIndex > -1)) Then
                dgvEltACommander.Rows(e.RowIndex).Cells("Qte").ReadOnly = False

                ' Verifier si le stock actuel permet de faire la commande
                ' Pour ne pas demander plus que la quantite en stock
                '
                If dgvEltACommander.Rows(e.RowIndex).Cells("Qte").Selected = True Then
                    Qry = "SELECT SUM(qte) as Stock FROM care_tz_stock_item_amount WHERE drugid=" & Id
                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)
                    PharmaReader = Comd.ExecuteReader
                    PharmaReader.Read()
                    If PharmaReader.HasRows = True Then
                        QteStock = CInt(PharmaReader("Stock"))
                    End If
                    myConn.Close()


                    QteCommande = CInt(dgvEltACommander.Rows(e.RowIndex).Cells("Qte").Value)
                    If QteCommande <= QteStock Then
                    Else
                        dgvEltACommander.Rows(e.RowIndex).Cells("Qte").Value = QteStock
                        MsgBox("Votre commande d'une quantite de " & QteCommande & " est superieure au stock existant. " & Environment.NewLine & _
                            "Le stock existant est de " & QteStock & " et est inseree plutot. Merci.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Commande Services")

                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Close()
            myConn.Dispose()
        End Try

    End Sub
End Class