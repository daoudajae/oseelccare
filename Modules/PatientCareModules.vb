Imports MySql.Data.MySqlClient

Module PatientCareModules

    Dim myConn As New MySqlConnection
    Dim Comd, LabCmd As MySqlCommand
    Dim PrescReader, LabReader As MySqlDataReader
    Dim TotalSelect, Enc_Percent, TotalAssureur, TotalAssurer, billAmount As Integer
    Dim SQL, Name As String

    Public Function GetPatientName(ByVal PId As Long, ByVal DB As MySQLDataBaseAccess) As String
        Dim Name As String
        DB.AddParams("@pid", PId)
        SQL = "SELECT name_first, name_last FROM care_person WHERE pid=@pid"
        DB.ExecQuery(SQL)
        If DB.RecordCount > 0 Then
            With DB.DBDataTable.Rows(0)
                Name = .Item("name_first") & " " & .Item("name_last")
            End With
        End If

        Return Name
    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''
    '
    '   Description: 
    '       Module permettant d'initialiser les elements pour l'auto complition des champs
    '       a usage repetitif
    '
    '   Variables:
    '       Aucun 
    '
    '   Resultat attendu:
    '       met a jour la liste des champs autocomplete
    '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub UpdateAutocomplete(Optional ByVal txtDescription As TextBox = Nothing, Optional ByVal txtMontant As TextBox = Nothing, Optional ByVal txtClient As TextBox = Nothing, Optional ByVal txtQuittancier As TextBox = Nothing, Optional ByVal cboComptes As ComboBox = Nothing)

        Dim drDataReader As MySqlDataReader
        Dim SQL As String
        Dim Libele As New AutoCompleteStringCollection
        Dim Montant As New AutoCompleteStringCollection
        Dim Client As New AutoCompleteStringCollection
        Dim Quittancier As New AutoCompleteStringCollection
        Dim Comptes As New AutoCompleteStringCollection

        myConn.ConnectionString = frmMain.ServerString

        Try
            If Not IsNothing(txtDescription) Then
                'Ajout de la liste des libeles pour la liste auto complete
                SQL = "SELECT distinct description FROM care_cashier_transactions_description"
                drDataReader = ReturnDataReader(myConn, SQL)

                While drDataReader.Read()
                    Libele.Add(drDataReader.Item(0))
                End While
                txtDescription.AutoCompleteCustomSource = Libele
            End If
            If Not IsNothing(cboComptes) Then
                'Ajout de la liste des libeles pour la liste auto complete
                SQL = "SELECT acountnumber, accountdescription FROM care_cashier_accounts"
                drDataReader = ReturnDataReader(myConn, SQL)

                While drDataReader.Read()
                    Comptes.Add(drDataReader.Item(0) & "-" & drDataReader.Item(1))
                End While
                cboComptes.AutoCompleteCustomSource = Comptes
            End If
            If Not IsNothing(txtMontant) Then
                'Ajout de la liste des montants deja introduits
                SQL = "SELECT DISTINCT credit FROM care_cashier_transactions"
                drDataReader = ReturnDataReader(myConn, SQL)
                While drDataReader.Read
                    Montant.Add(drDataReader.Item(0))
                End While
                txtMontant.AutoCompleteCustomSource = Montant
                txtMontant.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            End If
            If Not IsNothing(txtClient) Then
                'Ajout de la liste des clients
                SQL = "SELECT DISTINCT client FROM care_cashier_transactions"
                drDataReader = ReturnDataReader(myConn, SQL)
                While drDataReader.Read
                    Client.Add(drDataReader.Item(0))
                End While
                txtClient.AutoCompleteCustomSource = Client
                txtClient.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            End If
            If Not IsNothing(cboComptes) Then
                'Ajout de la liste du quittancier
                SQL = "SELECT DISTINCT numquitancier FROM care_cashier_transactions"
                drDataReader = ReturnDataReader(myConn, SQL)
                While drDataReader.Read
                    Quittancier.Add(drDataReader.Item(0))
                End While
                txtQuittancier.AutoCompleteCustomSource = Quittancier
                txtQuittancier.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Erreur - Gestion Caisse Principale Form Load")
        End Try

    End Sub
    '##################################################################################################
    '#
    '#  Module pour creer une requette pour insertion de plusieurs elements dans une table
    '#
    '#  Variables:
    '#      SQL as string qui contient le debut de la requette
    '#      strElements (,) as tring, matrice qui contient le reste de la requette
    '# 
    '# Resultat attendu:
    '#      La requette est creee et est executee.
    '#
    '##################################################################################################
    Public Sub GenererNonRequette(ByRef Conn As MySqlConnection, ByVal SQL As String, ByVal strTable As String, ByVal strElements(,) As String)

        Dim queryBuilder As New System.Text.StringBuilder

        Conn = New MySqlConnection
        Conn.ConnectionString = frmMain.ServerString

        Try
            Conn.Open()
            queryBuilder.Append(SQL & strTable)
            Dim arrElmtsCount = strElements.GetLength(0)

            'Verifier si il ya des elements a utiliser
            If arrElmtsCount > 0 Then
                'Ajouter les elements de la premieres partie de la requette si c'est une requette INSERT
                For i As Integer = 0 To arrElmtsCount - 1
                    If Not strElements(i, 1) = Nothing Then
                        queryBuilder.Append(strElements(i, 0) & ",")
                    End If
                Next
                'Enlever la derniere vigule pour continuer la requette
                queryBuilder.Replace(queryBuilder.ToString, queryBuilder.Remove(queryBuilder.Length - 1, 1).ToString)

                'Preparer la suite de la requette
                queryBuilder.Append(") VALUES (")

                'Rajouter les elements de la 2eme partie d'une requette INSERT INTO
                For i As Integer = 0 To arrElmtsCount - 1
                    If Not strElements(i, 1) = Nothing Then
                        queryBuilder.Append(strElements(i, 1) & ",")
                    End If
                Next
                'Enlever la derniere vigule pour terminer la requette
                queryBuilder.Replace(queryBuilder.ToString, queryBuilder.Remove(queryBuilder.Length - 1, 1).ToString)

                'Terminer de la requette
                queryBuilder.Append(")")

                'Fermer la connection avant d'entrer dans le module suivant
                Conn.Close()
                'Executer la requette
                ExecuterRequette(Conn, queryBuilder.ToString)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Erreur dans GenererNonRequette")
        Finally
            Conn.Close()
        End Try
    End Sub
    '???????????????????????????????????????????????????????????????????????????????????????????????
    '?
    '?  Module pour reconstruire une requette de type SELECT ... WHERE
    '?
    '?  Variables:
    '?      Conn: as MySQLConnection 
    '?      SQL: de type String, requette principale
    '?      strArray: Matrice d'objets pour l'ajout a la requette principale 
    '?
    '?  Resultat attendu
    '?      Requete reconstituee et executee et renvoi un datareader pour qu'on puisse utiliser
    '?      de la requette
    '?
    '????????????????????????????????????????????????????????????????????????????????????????????????

    Public Function GenererRequetteSelect(ByRef Conn As MySqlConnection, _
                                  ByVal startSQL As String, ByVal strTable As String, ByVal SelectFields() As Object, _
                                  Optional ByVal arrWhere(,) As Object = Nothing, Optional ByVal arrGroupOrder(,) As Object = Nothing) As MySqlDataReader
        Try

            'Conn.Open()
            Dim queryBuilder As New System.Text.StringBuilder
            Dim Sign As String
            queryBuilder.Append(startSQL)
            Sign = " = "
            'Aligner les elements a selectionner
            Dim ListElements = SelectFields.GetLength(0)
            'Check the fields if values are inserted
            If ListElements > 0 Then
                For i As Integer = 0 To ListElements - 1
                    'S'assurer que les champs utilises pour la recherche ne sont pas vides
                    If Not SelectFields(i) = Nothing Then
                        queryBuilder.Append(SelectFields(i) & ",")
                    End If
                Next
                'Elever la derniere virgule
                queryBuilder.Replace(queryBuilder.ToString, queryBuilder.Remove(queryBuilder.Length - 1, 1).ToString)
            End If
            'Ajouter FROM et le nom de la table
            queryBuilder.Append(" FROM ")
            queryBuilder.Append(strTable & " ")

            'Verifier si il ya une condition
            If Not IsNothing(arrWhere) Then
                ListElements = arrWhere.GetLength(0)
                If ListElements > 0 Then
                    queryBuilder.Append("WHERE ")
                    For i As Integer = 0 To ListElements - 1
                        If Not arrWhere(i, 0) = Nothing Then
                            queryBuilder.Append(arrWhere(i, 0) & " " & Sign & " " & arrWhere(i, 1) & " AND  ")
                        End If
                    Next
                    'Elever la derniere virgule
                    queryBuilder.Replace(queryBuilder.ToString, queryBuilder.Remove(queryBuilder.Length - 5, 5).ToString)
                End If
            End If
            'Verifier si il ya un groupement
            If Not IsNothing(arrGroupOrder) Then
                ListElements = arrGroupOrder.GetLength(0)
                If ListElements > 0 Then
                    For i As Integer = 0 To ListElements - 1
                        If Not arrGroupOrder(i, 0) = Nothing Then
                            queryBuilder.Append(arrGroupOrder(i, 0) & arrGroupOrder(i, 1) & arrGroupOrder(i, 2))
                        End If
                    Next
                End If
            End If
            Conn.Close()
            Return ReturnDataReader(Conn, queryBuilder.ToString)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Erreur - GenererRequetteSelect")
        End Try

    End Function

    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
    '$
    '$  Function pour mettre a jour le dataGridViewer
    '$
    '$  Variables:
    '$      Conn: as MySQLConnection 
    '$      SQL: de type String, requette principale
    '$      strArray: Matrice d'objets pour l'ajout a la requette principale
    '$      grpArray: Matricr contenant les filtres ORDER ou GROUP
    '$      dgv: DataGridView qui sera mis a jour
    '$
    '$  Resultat attendu:
    '$      Mise a jour du dataGridView selon la selection 
    '$
    '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

    Public Sub AutoUpdateDataGrid(ByRef Conn As MySqlConnection, _
                                      ByVal SQL As String, ByVal objArray(,) As Object, _
                                      ByVal grpArr(,) As String, ByVal dgv As DataGridView)
        Try
            Conn.Open()
            Dim queryBuilder As New System.Text.StringBuilder
            Dim Sign As String
            queryBuilder.Append(SQL)
            Sign = ""
            Dim ListElements = objArray.GetLength(0)
            'Check the fields if values are inserted
            If ListElements > 0 Then
                For i As Integer = 0 To ListElements - 1
                    'S'assurer que les champs utilises pour la recherche ne sont pas vides
                    If Not objArray(i, 1) = Nothing Then
                        'Si c'est une date nous verifions la date du debut et la date de fin pour 
                        'utiliser le signe adequat
                        If objArray(i, 0) = "date" Or objArray(i, 0) = "livrerle" Then
                            If objArray(i, 2) = "From" Then
                                Sign = " > "
                            ElseIf objArray(i, 2) = "To" Then
                                Sign = " < "
                            End If
                            queryBuilder.Append(" " & objArray(i, 0) & " " & Sign & " '" & objArray(i, 1) & "' AND  ")
                        ElseIf objArray(i, 1) = "IN" Or objArray(i, 1) = "IS" Then
                            Sign = objArray(i, 1)
                            queryBuilder.Append(" " & objArray(i, 0) & " " & Sign & " " & objArray(i, 2) & " AND  ")
                        Else
                            Sign = " = "
                            queryBuilder.Append(" " & objArray(i, 0) & " " & Sign & " '" & objArray(i, 1) & "' AND  ")
                        End If

                    End If
                Next
            End If
            'Create la requette finale 
            queryBuilder.Replace(queryBuilder.ToString, queryBuilder.Remove(queryBuilder.Length - 5, 5).ToString)

            'Verifier sii on va faire un groupage et ordonner 
            ListElements = grpArr.GetLength(0)
            If ListElements > 0 Then
                'Rajouter le groupement affin de compter les quantite seulement
                For i As Integer = 0 To ListElements - 1
                    queryBuilder.Append(" " & grpArr(i, 0) & " " & grpArr(i, 1) & " ")
                Next
            End If

            'AfficherElementDataGridView(Conn, queryBuilder.ToString, dgv)

            'Remplir le resultat de la requette dans une table
            Dim Comd As New MySqlCommand(queryBuilder.ToString, Conn)
            Dim daDataAdapter As New MySqlDataAdapter
            Dim dtDatatable As New DataTable
            daDataAdapter.SelectCommand = Comd
            daDataAdapter.Fill(dtDatatable)

            'Afficher la table dans le datagrid view
            dgv.DataSource = dtDatatable
            dgv.AutoResizeColumns()
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgv.ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!")
        End Try
        Conn.Close()
    End Sub
    ']]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
    ']
    ']  Description
    ']      Module qui permet de mettre a jour le data grid view
    ']
    ']  Variables
    ']      Conn as mysqlconnection pour la connection a la base des donnees
    ']      SQL as string est la requette qui retrouve les donnees de la table pour afficher
    ']      dgv as datagridview qui va afficher les donnees.
    ']
    ']  Resultat attendu
    ']      Le resultat de la selection est afficher dans le datagridview
    ']
    ']]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
    Public Sub AfficherElementDataGridView(ByVal Conn As MySqlConnection, ByVal SQL As String, ByVal dgv As DataGridView)
        Conn.ConnectionString = frmMain.ServerString
        Try
            'Remplir le resultat de la requette dans une table
            Dim Comd As New MySqlCommand(SQL, Conn)
            Dim daDataAdapter As New MySqlDataAdapter
            Dim dtDatatable As New DataTable
            daDataAdapter.SelectCommand = Comd
            daDataAdapter.Fill(dtDatatable)

            'Afficher la table dans le datagrid view
            dgv.DataSource = dtDatatable
            dgv.AutoResizeColumns()
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgv.ReadOnly = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Erreur! - AfficherElementDataGridView")
        End Try
    End Sub

    '''''''''''''''''''''''''''''''''''''''
    ''
    ''  Calcul la somme de de la colonne debit ou credit
    ''
    ''
    '''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function CalculCreditDebit(ByVal CrdtDbt As Integer, ByVal NumJournal As Integer) As Integer
        Dim SQL As String
        Dim DbtCdt As String
        Dim Calcul As Integer = 0
        DbtCdt = ""
        Try
            If CrdtDbt = 1 Then
                DbtCdt = "credit"
            ElseIf CrdtDbt = 0 Then
                DbtCdt = "debit"
            End If

            SQL = "SELECT sum(" & DbtCdt & ") FROM care_cashier_transactions WHERE type=" & CrdtDbt & " AND numjournal=" & NumJournal
            PrescReader = ReturnDataReader(myConn, SQL)

            If PrescReader.Read Then
                Calcul = PrescReader.Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Erreur - CalculCeditDebit")
        End Try

        Return Calcul
    End Function

    '--------------------------------------------------------------------------------------------------
    '-
    '-      Description:
    '-          Recherche une valeur dans un objet Collection
    '-
    '-      Variable:
    '-          Col: un objet Collection
    '-
    '-      Resultat attendu:
    '-          
    '--------------------------------------------------------------------------------------------------

    Public Function CollectionContains(ByVal col As Object, ByVal key As Object) As Boolean
        Dim obj As Object
        On Error GoTo err
        CollectionContains = True
        obj = col(key)
        Exit Function
err:

        CollectionContains = False
    End Function

    '////////////////////////////////////////////////////////////////////////////////////////////////
    '/
    '/  Function qui retourne un MySqlDataReader
    '/
    '/  Syntax:
    '/      Function ReturnDataReader (byVal Conn as MySQLConnection, byVal SQL as String) as MySQLDataReader
    '/
    '/  Variables:
    '/      L'utilisateur doit passer un MySQLConnection, la chaine qui contient la requette MySQL
    '/
    '/  Resultat attendu:
    '/      Un objet de type MySQLDataReader est retourner
    '/
    '//////////////////////////////////////////////////////////////////////////////////////////////////

    Public Function ReturnDataReader(ByRef Conn As MySqlConnection, ByVal SQL As String) As MySqlDataReader
        Dim Comd As MySqlCommand
        Dim dtaReader As MySqlDataReader
        Conn = New MySqlConnection
        Conn.ConnectionString = frmMain.ServerString

        Try
            Conn.Open()
            Comd = New MySqlCommand(SQL, Conn)
            dtaReader = Comd.ExecuteReader
        Catch ex As Exception
            dtaReader = Nothing
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur dans ReturnDataReader")
        End Try
        Return dtaReader
        Conn.Close()
    End Function
    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '+
    '+  Description
    '+      Routine qui permet d'executer les requettes tels que INSERT, UPDATE, DROP etc...
    '+
    '+  Variable
    '+      Conn de type MySqlConnection pour la connection a la base de donnees
    '+      SQL de Type String qui contient la requette a executer
    '+
    '+  Resultat attendu:
    '+      La requette est executee
    '+
    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    Public Sub ExecuterRequette(ByRef Conn As MySqlConnection, ByVal SQL As String)
        Dim Comd As MySqlCommand
        Try
            Conn.Open()
            Comd = New MySqlCommand(SQL, Conn)
            Comd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur - ExecuterRequette")
        End Try
        Conn.Close()
    End Sub

    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%
    '%  Description
    '%      Function qui verifie si un numero de journal existe dans la table des journaux.
    '%
    '%  Variables:
    '%      Conn as MySqlConnection pour la connection a la base des donnees
    '%      numJournal as integer est le numero du journal a verifier
    '%
    '%  Resultat attendu:
    '%      Renvoi vrai ou faux selon l'existance du numero du journal
    '%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


    '/------------------------------------------------------------------------------------------------
    '/
    '/  Description:
    '/      Module pour retrouver les divers payements
    '/
    '/------------------------------------------------------------------------------------------------
    Public Sub GetPayment(ByVal Encounter As Integer, ByVal BillNo As Integer, ByRef dgvPayment As DataGridView, ByVal Conn As MySqlConnection)
        Dim Qry As String
        Dim Paid, Billed, TotalBill As Integer

        Dim Comd As MySqlCommand
        Dim PrescReader As MySqlDataReader
        Dim dtaAdapter As New MySqlDataAdapter
        Dim dtaDataTable As New DataTable
        Dim bindSource As New BindingSource
        Try
            'Mettre bindSource a Nothing (vider)
            bindSource.DataSource = Nothing
            dgvPayment.DataSource = Nothing

            'Verifier si tout a ete payer ou pas
            Qry = "SELECT sum(paid) as Paid, sum(topay) as Billed, billtotal as Total FROM `care_billing_payment` WHERE encounter_nr=" & Encounter & _
                " AND receipt_no=" & BillNo
            Conn.Open()
            Comd = New MySqlCommand(Qry, Conn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.Read Then
                Paid = PrescReader.Item("Paid")
                Billed = PrescReader.Item("Billed")
                TotalBill = PrescReader.Item("Total")
                If Paid < Billed Then
                    Conn.Close()
                    'Afficher toutes les precedentes facturations et prevenir qu'il ya une
                    'facturation non effectuee
                    Qry = "SELECT article, unit_cost, units, amount, date, bill_no FROM care_billing_bill_item WHERE encounter_nr=" & Encounter & _
                    " AND bill_no=" & BillNo
                    Comd = New MySqlCommand(Qry, Conn)
                    dtaAdapter.SelectCommand = Comd

                    dtaAdapter.Fill(dtaDataTable)
                    'dtaDataTable.Columns.Add("total", GetType(Integer))
                    bindSource.DataSource = dtaDataTable

                    'link to the datagridview
                    dgvPayment.DataSource = bindSource
                    dtaAdapter.Update(dtaDataTable)
                    Conn.Close()
                Else
                    'Le paiement et la facturation sont egaux 
                    Conn.Close()
                    If Paid < TotalBill Then
                        'La facture n'est pas entierement payee, lister les divers paiements
                        Qry = "SELECT datebilled, datepaid, billtotal, paid, encaisseur, remain, topay, factureur FROM care_billing_payment WHERE encounter_nr=" & Encounter & _
                            " AND receipt_no=" & BillNo
                        Conn.Open()
                        Comd = New MySqlCommand(Qry, Conn)
                        dtaAdapter.SelectCommand = Comd

                        dtaAdapter.Fill(dtaDataTable)
                        'dtaDataTable.Columns.Add("total", GetType(Integer))
                        bindSource.DataSource = dtaDataTable

                        'link to the datagridview
                        dgvPayment.DataSource = bindSource
                        dtaAdapter.Update(dtaDataTable)
                        Conn.Close()
                    Else
                        MsgBox("Facture entierement payee. MERCI!", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Information!")

                    End If
                    Conn.Close()
                End If
                MsgBox("Total Facture: " & TotalBill & Environment.NewLine & _
                       "Versement fait: " & Paid & Environment.NewLine & _
                       "Reste a payer: " & TotalBill - Paid, MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Infos")
            End If

        Catch ex As Exception
            Conn.Close()
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
        Finally
            Conn.Dispose()
        End Try
    End Sub

    Public Function GetPatientInformation(ByVal IdBox As TextBox, ByRef InfosBox As TextBox) As ULong
        Dim Qry, Enc_Date, Patient_Name, Patient_Birth As String
        Dim EncounterPercent, Exclusion, BonCfg As Integer
        Dim EncounterType, FirmName, ContactName, PatientRelation, PatientQuality As String
        Dim Encounter As ULong

        Encounter = 0
        myConn.ConnectionString = frmMain.ServerString

        If String.IsNullOrEmpty(IdBox.Text) Then
            MsgBox("Vous devez saisir le numero du patient", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
            IdBox.Focus()
            IdBox.Clear()
            Return 0
            Exit Function
        End If
        If Not IsNumeric(IdBox.Text) Then
            MsgBox("Vous devez saisir le numero du patient", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
            IdBox.Focus()
            Return 0
            Exit Function
        End If
        If (Integer.Parse(IdBox.Text) >= 10000000) Then
            Try
                'Get the encounter number, encounter date, config bon, encounter_type of the patient
                myConn.Open()
                Qry = "SELECT insurance_firm, contact_name, contact_relation, quality, exclusion, bonpercent, encounter_nr, encounter_date, boncfg, encounter_type  FROM caredb.care_encounter WHERE pid=" & CULng(IdBox.Text) & _
                    " AND is_discharged=0 ORDER BY encounter_date"
                Comd = New MySqlCommand(Qry, myConn)
                'Get the encounter number
                PrescReader = Comd.ExecuteReader
                PrescReader.Read()
                If PrescReader.HasRows = True Then
                    Encounter = PrescReader.Item("encounter_nr")
                    BonCfg = PrescReader.Item("boncfg")
                    Enc_Date = PrescReader.Item("encounter_date")
                    EncounterType = PrescReader.Item("encounter_type")
                    EncounterPercent = PrescReader.Item("bonpercent")
                    If Not IsDBNull(PrescReader.Item("insurance_firm")) Then
                        FirmName = PrescReader.Item("insurance_firm")
                    End If
                    If Not IsDBNull(PrescReader.Item("contact_name")) Then
                        ContactName = PrescReader.Item("contact_name")
                    End If
                    If Not IsDBNull(PrescReader.Item("contact_relation")) Then
                        PatientRelation = PrescReader.Item("contact_relation")
                    End If
                    If Not IsDBNull(PrescReader.Item("quality")) Then
                        PatientQuality = PrescReader.Item("quality")
                    End If
                    If Not IsDBNull(PrescReader.Item("exclusion")) Then
                        Exclusion = PrescReader.Item("exclusion")
                    End If

                    myConn.Close()
                    '
                    'Get the Patient information
                    myConn.Open()
                    Qry = "SELECT name_first, name_last, date_birth FROM caredb.care_person WHERE pid=" & CULng(IdBox.Text)
                    Comd = New MySqlCommand(Qry, myConn)
                    'Get the encounter number
                    PrescReader = Comd.ExecuteReader
                    PrescReader.Read()
                    Patient_Name = PrescReader.Item("name_last") & " " & PrescReader.Item("name_first")
                    Patient_Birth = PrescReader.Item("date_birth")
                    myConn.Close()

                    InfosBox.Text = "Noms: " & Patient_Name & Environment.NewLine & "Né(e) le: " & Patient_Birth & _
                        Environment.NewLine & "No Visite: " & Encounter & Environment.NewLine & "Du: " & Enc_Date
                    If BonCfg > 0 Then
                        InfosBox.Text = InfosBox.Text & Environment.NewLine & "Bon de type: " & EncounterType & " à: " & EncounterPercent & "%" & _
                            Environment.NewLine & "Assurance: " & FirmName
                        If BonCfg = 3 Then
                            InfosBox.Text = InfosBox.Text & Environment.NewLine & "En qualité de: " & PatientQuality
                        End If
                        If Exclusion = 1 Then
                            InfosBox.Text = InfosBox.Text & Environment.NewLine & _
                                "Bon à eclusion!!!"
                        End If
                        InfosBox.Visible = True
                    End If
                Else
                    MsgBox("Ce patient n'a pas de rencontre!!!", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Patient Non Trouvé!!")
                End If
            Catch ex As MySqlException
                myConn.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur de Connexion!!!")
            Finally
                myConn.Dispose()
            End Try
        Else
            MsgBox("Vous devez saisir un numéro de patient valide à 8 chiffres.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
            IdBox.Focus()
            IdBox.Clear()
            Return 0
            Exit Function
        End If
        Return Encounter
    End Function

    '************************************************************************************
    '*
    '* Function pour retrouver la somme totale payee par un patient pendant sa rencontre
    '*
    '* Variables:
    '*      Encounter est passe comme numero de rencontre du patient
    '*      Montant aura le montant total de paye par le patient
    '*
    '************************************************************************************

    Public Function Montant(ByVal Encounter As ULong) As Integer
        Dim Somme As Integer
        Dim Qry As String
        Somme = 0
        myConn.ConnectionString = frmMain.ServerString

        Try

            'Get the encounter number, encounter date, config bon, encounter_type of the patient
            myConn.Open()
            Qry = "SELECT SUM(paid) as montant from care_billing_payment WHERE encounter_nr=" & Encounter
            Comd = New MySqlCommand(Qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader
            PrescReader.Read()
            If PrescReader.HasRows = True Then
                Somme = PrescReader.Item("montant")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Renvoyer la somme totale payel par le patient
        myConn.Close()
        Return Somme
    End Function

    Public Function ValideTextBox(ByVal txtBox As TextBox, ByVal Type As Byte) As Boolean
        Dim Valide As Boolean
        Dim msgString As String
        Valide = False

        If String.IsNullOrEmpty(txtBox.Text) Then
            msgString = "Vous devez saisir le montant a rembourser"

            If Type = 2 Then
                If Not IsNumeric(txtBox.Text) Then
                    msgString = "Vous devez saisir un montant pas un texte"
                End If
            End If
            MsgBox(msgString, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur")
            txtBox.Focus()
            Return False
            Exit Function
        Else
            Valide = True
        End If
        Return Valide
    End Function


    '***********************************************************************************************************
    '*
    '*      Desc: Module pour l'export des donnees dans un fichier excel.
    '*
    '*      Variables:
    '*          dgv: est le datagridview qui contient les donnees 
    '*
    '*      Resultat attendu:
    '*          Un fichier excel est creer et enregistrer sous le nom que l'utilisateur 
    '*          a donner et contenant les donnees du datagriview
    '*
    '***********************************************************************************************************

    Public Sub Export_Data_Excel(ByVal dgv As DataGridView, ByVal Rapport As String, ByVal User As String)
        Dim SFD As New SaveFileDialog()
        SFD.Filter = "Fichiers Microsoft Office Excel | *.xlsx"
        If SFD.ShowDialog = DialogResult.OK Then
            Dim filename As String
            Dim col, row As Integer
            Dim Excel As Object = CreateObject("Excel.Application")

            'Verifier si Excel est present
            If Excel Is Nothing Then
                MessageBox.Show("Cette operation necessite la presence du logiciel MS Excel.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            With Excel
                .SheetsInNewWorkbook = 1
                .Workbooks.Add()
                .Worksheets(1).Select()

                .Cells(2, 1).value = "BP 06"
                .Cells(3, 1).value = Rapport.Substring(0, Rapport.IndexOf(" ")) 'Name of the Hospital
                .cells(5, 1).value = Rapport.Substring(Len(.Cells(3, 1).value)) 'Date du and au
                .Cells(1, 1).value = "HOPITAL PROTESTANT DE " & .Cells(3, 1).value
                .Cells(1, 1).entirerow.font.bold = True

                'Recuperer l'entete des colonnes
                'et creer l'entete du fichier excel
                Dim i As Integer = 1
                For col = 0 To dgv.ColumnCount - 1 ' ComDTable.Tables(0).Columns.Count - 1
                    .cells(7, i).value = dgv.Columns(col).HeaderText 'ComDTable.Tables(0).Columns(col).ColumnName
                    .cells(7, i).EntireRow.Font.Bold = True
                    i += 1
                Next

                '
                'i = 2
                'Recuperer les donnees dans le datagrid pour les copier dans le nouveau fichier Excel
                Dim k As Integer = 1

                For col = 0 To dgv.ColumnCount - 1
                    'Nous commencons a partir de la 8e ligne
                    i = 8
                    For row = 0 To dgv.RowCount - 1
                        .Cells(i, k).Value = dgv.Rows(row).Cells(col).Value
                        i += 1
                    Next
                    k += 1
                Next

                i += 2

                .Cells(i, 1).Value = "Fait le: " & Now().ToString("yyyy-MM-dd") & " A: " & Now().ToString("hh:mm")
                .Cells(i + 1, 1).Value = "Par : " & User
                'Enregistrer le fichier
                filename = SFD.FileName
                .ActiveCell.Worksheet.SaveAs(filename)
            End With

            System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel)

            'Netoyage des processus
            Excel = Nothing
            Dim pro() As Process = System.Diagnostics.Process.GetProcessesByName("EXCEL")
            Dim ii As Process
            For Each ii In pro
                ii.Kill()
            Next
            MsgBox("Fichier Exporter avec succes...!", MsgBoxStyle.Information, "OSEELCCare!")
        End If

    End Sub


    ''''
    '' Module pour avoir la pharmacie connectee
    ''
    Public Function Pharmacie(ByVal Pharma As String) As String
        Dim fieldPharma As String
        fieldPharma = ""
        If ((Pharma = "pharmacie1") Or (Pharma = "Pharmacie1")) Then
            fieldPharma = "pharma1"
        ElseIf ((Pharma = "pharmacie2") Or (Pharma = "Pharmacie2")) Then
            fieldPharma = "pharma2"
        ElseIf ((Pharma = "pharmacie3") Or (Pharma = "Pharmacie3")) Then
            fieldPharma = "pharma3"
        ElseIf ((Pharma = "pharmacie4") Or (Pharma = "Pharmacie4")) Then
            fieldPharma = "pharma4"
        End If

        Return fieldPharma

    End Function

    ''
    '' Renvoyer le long nom de la place
    ''
    Public Function PharmaLong(ByVal Pharma As String) As String
        Dim fieldPharma As String
        fieldPharma = ""
        If Pharma = "pharma1" Then
            fieldPharma = "Pharmacie1"
        ElseIf Pharma = "pharma2" Then
            fieldPharma = "Pharmacie2"
        ElseIf Pharma = "pharma3" Then
            fieldPharma = "Pharmacie3"
        ElseIf Pharma = "pharma4" Then
            fieldPharma = "Pharmacie4"
        End If

        Return fieldPharma

    End Function
    ''' <summary>
    ''' Veriffie si un element seretrouve dans la listebox en reduisant 
    ''' </summary>
    ''' <param name="lstList"></param>
    ''' lstList est de type ListBox et contient plusieurs elements concatener avec les quantites prescrites
    ''' <param name="Article"></param>
    ''' Article est la chaine qui nous permet de faire la comparaison
    ''' <returns></returns>
    ''' Nous renvoi Vrai ou Faux selon le resultat de la recherche
    ''' <remarks></remarks>
    Public Function FindElementInList(ByVal lstList As ListBox, ByVal Article As String) As Boolean
        Dim Element As String
        'Traverser la liste pour rechercher l'article
        For Count = 0 To lstList.Items.Count - 1
            Element = ReturnArticle(lstList.Items(Count).ToString)
            'Article = ReturnArticle(Article)

            'Strip out the article name
            'Element = Element.Substring(0, Article.Length)
            If String.Equals(Element, Article) Then
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function

    Public Function ReturnFoundElementInList(ByVal lstList As ListBox, ByVal Article As String) As String
        Dim Element As String
        Element = ""
        'Traverser la liste pour rechercher l'article
        For Count = 0 To lstList.Items.Count - 1
            Element = ReturnArticle(lstList.Items(Count).ToString)

            'Strip out the article name
            'Element = Element.Substring(0, Article.Length)
            If String.Equals(Element, Article) Then
                Return Element
                Exit Function
            End If
        Next
        Return Element
    End Function

    Public Function ReturnArticle(ByVal strArticle As String) As String
        Dim Article As String
        Article = strArticle.Substring(0, strArticle.IndexOf("("))
        Article = Article.Substring(0, Article.Length - 1)

        Return Article
    End Function

    Public Function ReturnQte(ByVal strArticle As String) As Integer
        Dim Qte As Integer
        Dim Article, SndPart As String
        'Stripout the first partof the string
        Article = strArticle.Substring(0, strArticle.IndexOf("="))
        SndPart = strArticle.Substring(0, strArticle.IndexOf(")"))

        'Get the second part of the string
        Article = strArticle.Substring(Article.Length + 1, SndPart.Length - Article.Length - 1)
        'Article = Article.Substring(0, Article.Length - 1)

        Qte = CInt(Article)
        Return Qte
    End Function
End Module

