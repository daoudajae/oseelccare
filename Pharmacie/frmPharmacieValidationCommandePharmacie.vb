Imports MySql.Data.MySqlClient

Public Class frmPharmacieValidationCommandePharmacie
    Public Property Permission As String
    Public Property Utilisateur As String
    Public Property lstData As ListBox


    'Public ServerString As String

    Dim myConn, myStockConn As New MySqlConnection
    Dim Comd, StockComd As MySqlCommand
    Dim PharmaReader As MySqlDataReader

    Private Sub frmCommandeValidation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim dtaAdapter As New MySqlDataAdapter
        Dim dtaDataTable As New DataTable
        Dim bindSource As New BindingSource

        dgvQteACommander.Rows.Clear()
        dgvQteACommander.Columns.Clear()

        'dtaDataTable.DataSet.Clear()
        bindSource.DataSource = Nothing
        dgvQteACommander.DataSource = Nothing

        myConn = New MySqlConnection
        myConn.ConnectionString = frmMain.ServerString
        myStockConn.ConnectionString = frmMain.ServerString
        Me.Utilisateur = frmMain.Utilisateur
        Me.Permission = frmMain.Permission
        Me.Text = Me.Text & " - " & frmMain.Utilisateur

        ''''
        '' Get the list of the available stock in the pharmacie
        ''
        ''''

        Dim Qry, fieldPharma As String

        fieldPharma = Pharmacie(Me.Permission)

        If Me.Permission = "admin" OrElse Me.Permission = "magasin" Then
            Qry = "SELECT DISTINCT transferera as Place FROM `care_tz_stock_transfer` ORDER BY transferera ASC"
        Else
            Qry = "SELECT DISTINCT transferera as Place FROM `care_tz_stock_transfer` WHERE transferera='" & fieldPharma & "' ORDER BY transferera ASC"
        End If

        Try
            myConn.Open()
            Comd = New MySqlCommand(Qry, myConn)

            PharmaReader = Comd.ExecuteReader
            Dim Pharm As String
            'Load the combobox with the liste of places
            While PharmaReader.Read
                Pharm = PharmaLong(PharmaReader("Place").ToString)
                If Not String.IsNullOrEmpty(Pharm) Then
                    cboPlace.Items.Add(Pharm)
                End If
            End While
            myConn.Close()

        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            myConn.Close()
        End Try

    End Sub

    Private Sub cboPlace_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPlace.SelectedIndexChanged
        Dim dtaAdapter As New MySqlDataAdapter
        Dim dtaDataTable As New DataTable
        Dim bindSource As New BindingSource

        dgvQteACommander.Rows.Clear()
        dgvQteACommander.Columns.Clear()

        'dtaDataTable.DataSet.Clear()
        bindSource.DataSource = Nothing
        dgvQteACommander.DataSource = Nothing

        ''''
        '' Get the list of the available stock in the pharmacie
        ''
        ''''

        Dim Qry, fieldPharma As String

        fieldPharma = Pharmacie(cboPlace.Text)

        Try
            Qry = "SELECT DISTINCT(commandepar) as Par, datecommande as Date FROM `care_tz_stock_transfer` WHERE transferera='" & fieldPharma & "' AND validationpar IS NULL"

            myConn.Open()
            Comd = New MySqlCommand(Qry, myConn)
            PharmaReader = Comd.ExecuteReader
            PharmaReader.Read()
            If PharmaReader.HasRows Then
                txtResponsable.Text = PharmaReader.Item("Par") & Environment.NewLine & PharmaReader.Item("Date")
            End If
            myConn.Close()

            Qry = "SELECT drugid as Id, qtedemande as Qte FROM `care_tz_stock_transfer` WHERE 	transferera LIKE '" & fieldPharma & "' AND validationpar IS NULL"

            myConn.Open()
            Comd = New MySqlCommand(Qry, myConn)

            dtaAdapter.SelectCommand = Comd
            myConn.Close()

            dtaAdapter.Fill(dtaDataTable)
            dtaDataTable.Columns.Add("Article")


            bindSource.DataSource = dtaDataTable
            'link to the datagridview
            dgvQteACommander.DataSource = bindSource
            dtaAdapter.Update(dtaDataTable)

            Dim DrugId, Index As Integer
            Index = 0
            For Each row As DataGridViewRow In dgvQteACommander.Rows
                DrugId = CInt(row.Cells("Id").Value)

                'search the namein drugsandservices table
                Qry = "SELECT item_description FROM care_tz_drugsandservices WHERE item_id=" & DrugId

                myConn.Open()
                Comd = New MySqlCommand(Qry, myConn)

                PharmaReader = Comd.ExecuteReader
                PharmaReader.Read()

                If PharmaReader.HasRows Then
                    dgvQteACommander.Rows(Index).Cells("Article").Value = PharmaReader("item_description").ToString
                End If
                Index = Index + 1
                myConn.Close()
            Next

            dgvQteACommander.AutoResizeColumns()
            dgvQteACommander.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            For Each ColHead As DataGridViewColumn In dgvQteACommander.Columns
                ColHead.SortMode = DataGridViewColumnSortMode.NotSortable
                dgvQteACommander.Width += ColHead.Width
            Next

            dgvQteACommander.Columns("Id").Visible = False
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            myConn.Close()
        End Try
    End Sub

    Private Sub btnValiderCommande_Click(sender As System.Object, e As System.EventArgs) Handles btnValiderCommande.Click
        Dim Qry As String
        Dim Id, OldId, ReaderId, DrugId As Integer
        Dim Pharma, Batch, Fournisseur, strDate As String
        Dim Qte, QtyStock, QtyPharma, QtyOrder, StockMagasin, stockDiff, QtyInsert As Integer
        Dim Finish, PremierPass As Boolean
        'Dim Expire As Date
        Finish = False
        PremierPass = True

        If dgvQteACommander.RowCount > 0 Then
            Try
                'myConn.Open()
                Pharma = Pharmacie(cboPlace.Text)

                For Each row As DataGridViewRow In dgvQteACommander.Rows
                    Finish = False
                    ' Id de l'element a commander
                    Id = CInt(row.Cells("Id").Value)
                    'Quantite de l'element a commander
                    Qte = CInt(row.Cells("Qte").Value)

                    ''
                    ' Gestion des stock de toutes les pharmacies
                    ' Mettre a jour le stock existant en sommation
                    ' Prendre le stock existant et sommer avec lanouvelle commande qui ient d'etre faite
                    ''
                    Qry = "SELECT quantity FROM care_tz_drugsandservices WHERE item_id=" & Id

                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)

                    PharmaReader = Comd.ExecuteReader
                    PharmaReader.Read()

                    If PharmaReader.HasRows Then
                        QtyStock = CInt(PharmaReader("quantity"))
                    End If
                    myConn.Close()

                    'Calcul du stock general cad sommation de toutes les pharmacies
                    QtyStock = QtyStock + Qte
                    'Mise a jour du stock Pharmacie
                    Qry = "UPDATE care_tz_drugsandservices SET quantity=" & QtyStock & " WHERE item_id=" & Id
                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)
                    Comd.ExecuteNonQuery()
                    myConn.Close()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''
                    ' Gestion du stock de la paharmacie qui a fait la commande
                    ' Prendre le stock existant dela phamacie concernee
                    ' Et la sommer avec les quantites de la nouvelle commande
                    ''
                    Qry = "SELECT " & Pharma & " FROM care_tz_drugsandservices WHERE item_id=" & Id

                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)

                    PharmaReader = Comd.ExecuteReader
                    PharmaReader.Read()

                    If PharmaReader.HasRows Then
                        QtyPharma = CInt(PharmaReader(Pharma))
                        'Calcul du stock pharmacie du pharmacien
                        QtyPharma = QtyPharma + Qte
                    End If
                    myConn.Close()
                    'Mise a jour du stock pharmacie
                    Qry = "UPDATE care_tz_drugsandservices SET " & Pharma & "=" & QtyPharma & " WHERE item_id=" & Id
                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)
                    Comd.ExecuteNonQuery()
                    myConn.Close()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '
                    ' Mise a jour du stock Pharmacie
                    'Qry = "UPDATE care_tz_stock_item_amount SET qte=" & QtyStock & " WHERE item_id=" & Id
                    'myConn.Open()
                    'Comd = New MySqlCommand(Qry, myConn)
                    'Comd.ExecuteNonQuery()
                    'myConn.Close()


                    ' Remplir la table de transfer pour suivie et historique de vvalisation des commandes
                    ' Get the qty of the transfer
                    Qry = "SELECT qtedemande FROM care_tz_stock_transfer WHERE drugid=" & Id & " AND qterecu=0 AND validationpar IS NULL"

                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)

                    PharmaReader = Comd.ExecuteReader
                    PharmaReader.Read()

                    If PharmaReader.HasRows Then
                        QtyOrder = CInt(PharmaReader("qtedemande"))
                    End If
                    myConn.Close()
                    'QtyOrder = QtyOrder + Qte

                    'Mettre a jour de la table des transfer
                    Qry = "UPDATE care_tz_stock_transfer SET qterecu=" & QtyOrder & _
                        ", datevalidation='" & Now().ToString("yyyy-MM-dd hh:mm") & "', validationpar='" & Me.Utilisateur & "'" & _
                        " WHERE drugid=" & Id & " AND transferera='" & Pharma & "'"
                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)
                    Comd.ExecuteNonQuery()
                    myConn.Close()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Prendre le stock du magasin magasin
                    ' Gestion du stock du magasin de la pharmacie, d'ou se ravitaillent les services et les pharmacies
                    ' Nous recuperons la somme general des stock du mm produit
                    ' Defalquer les quantites des stocks proches de la peremption dabord
                    '''''

                    ''''
                    '''' Faire la somme de tout le stock existant
                    '''' 
                    Qry = "SELECT SUM(qte) as Stock FROM care_tz_stock_item_amount WHERE drugid=" & Id

                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)

                    PharmaReader = Comd.ExecuteReader
                    PharmaReader.Read()
                    ''
                    '' Enregistrer la quantite totale dans Stock magasin
                    ''
                    If PharmaReader.HasRows Then
                        StockMagasin = CInt(PharmaReader("Stock"))
                    End If
                    myConn.Close()
                    ''
                    '' Selectionner toutes les lignes dans le stock dudit produit
                    ''
                    Qry = "SELECT id, drugid, qte, batch, expire, fournisseur FROM care_tz_stock_item_amount WHERE qte>0 AND drugid=" & Id & " ORDER BY expire ASC" 'WHERE qterecu=0 AND validationpar IS NULL"
                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)

                    PharmaReader = Comd.ExecuteReader
                    OldId = 0
                    While (PharmaReader.Read() And Finish = False)
                        ReaderId = CInt(PharmaReader("id"))
                        Qte = CInt(PharmaReader("qte"))
                        DrugId = CInt(PharmaReader("drugid"))
                        Batch = PharmaReader("batch").ToString
                        strDate = Format(CDate(PharmaReader("expire").ToString), "yyyy-MM-dd")
                        'Expire = Format(CDate(strDate).ToString, "yyyy-MM-dd")
                        Fournisseur = PharmaReader("fournisseur").ToString

                        If OldId = Id Then
                            'PremierPass = False
                            QtyOrder = stockDiff * (-1)
                        End If

                        stockDiff = Qte - QtyOrder
                        If stockDiff >= 0 Then
                            'myConn.Close()
                            Qry = "UPDATE care_tz_stock_item_amount SET qte=" & stockDiff & " WHERE id=" & ReaderId
                            myStockConn.Open()
                            StockComd = New MySqlCommand(Qry, myStockConn)
                            StockComd.ExecuteNonQuery()
                            myStockConn.Close()
                            'myConn.Close()
                            Finish = True
                            QtyInsert = QtyOrder
                        Else
                            Qry = "UPDATE care_tz_stock_item_amount SET qte=0 WHERE id=" & ReaderId
                            myStockConn.Open()
                            StockComd = New MySqlCommand(Qry, myStockConn)
                            StockComd.ExecuteNonQuery()
                            myStockConn.Close()
                            QtyInsert = Qte
                        End If
                        Qry = "INSERT INTO care_tz_stock_pharmacy_history (drugid, qte, batch, expire, pharmacie, datemvmt, fournisseur) VALUES " & _
                            "(" & DrugId & ", " & QtyInsert & ", '" & Batch & "', '" & strDate & "', '" & Pharma & "', '" & Now().ToString("yyyy-MM-dd hh:mm") & _
                            "', '" & Fournisseur & "')"
                        myStockConn.Open()
                        StockComd = New MySqlCommand(Qry, myStockConn)
                        StockComd.ExecuteNonQuery()
                        myStockConn.Close()
                        OldId = Id
                    End While

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''
                    myConn.Close()
                    'Index = Index + 1
                Next
                MsgBox("Commande Faite Avec Success!.", vbInformation Or vbOKOnly, "Commande Produits")

            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                myConn.Close()
                myStockConn.Close()
                myStockConn.Dispose()
                myConn.Dispose()
            End Try
            Me.Close()
        Else
            MsgBox("Aucune commande a valider!!!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Validation dela commande!")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class