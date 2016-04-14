Imports MySql.Data.MySqlClient

Public Class frmPatientPrescription
    Public Property Permission As String
    Public Property Utilisateur As String
    Public Property Qte As Integer
    Public Property Id As Long
    'Public ServerString As String

    Dim myConn, myLabConn As New MySqlConnection
    Dim Comd, LabCmd As MySqlCommand
    Dim PrescReader, LabReader As MySqlDataReader
    Dim ArticleNumber, EncounterPercent, Price As Integer
    Dim Article, DrugClass, PrescribeDate, Precriber, History, WhereClose, Qry, LabQry As String
    Dim TotalSelect, TotalAssureur, TotalAssurer, TotalExclusion, billAmount, billNo, Exclusion, BonCfg As Integer
    Dim ConnMode, EncounterType, FirmName, ContactName, PatientRelation, PatientQuality As String
    Dim Encounter As ULong
    Dim Pharma As String

    Dim DB As New MySQLDataBaseAccess(frmMain.ServerString)

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click

        Encounter = GetPatientInformation(txtId, txtInfos)
        If Encounter > 0 Then
            grpPrescriptions.Visible = True
            grpInfo.Visible = True

            'Get the stock of the connected pharmacie
            Qry = "SELECT level FROM care_users WHERE personell_nr=1 AND level LIKE '%pharmacie%'"
            myConn.Open()
            Comd = New MySqlCommand(Qry, myConn)
            PrescReader = Comd.ExecuteReader
            PrescReader.Read()

            If PrescReader.HasRows = True Then
                Pharma = Pharmacie(PrescReader("level"))
            End If
            myConn.Close()
            Dim Query = "SELECT item_description as Article, unit_price as Prix FROM care_tz_drugsandservices  WHERE item_number='CON' OR (" & Pharma & ">0 AND item_number='CAR') ORDER BY item_description ASC"
            FillPrescriptionsItems(Query)

        End If
    End Sub

    '/----------------------------------------------------------------------------------
    '/ 
    '/ Description:
    '/      Ce module permet de rechercher les prescriptions, et examens de labo qui ne sont pas payes 
    '/      pour la facturation.  Les prescriptions se trouvent dans la table care_encounter_prescription
    '/      Les examens de laboratoire se trouves
    '/
    '/ Parametres a passer:
    '/      Aucun.
    '/
    '/  Resultat:
    '/      Les prescriptions et les examens de labo trouves sont listes dans un datagrid
    '/
    '/----------------------------------------------------------------------------------
    Private Sub FillPrescriptionsItems(ByVal strQuery As String)
        Dim Element As String
        lstAllActs.Items.Clear()
        Try

            myConn.Open()
            'Qry = "SELECT item_description as Article, unit_price as Prix FROM care_tz_drugsandservices " & WhereClose

            'Qry = "SELECT item_id as Number, item_number as Class, item_description as Article, unit_price as Prix, purchasing_class Classification FROM care_tz_drugsandservices " & WhereClose
            Comd = New MySqlCommand(strQuery, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader
            While PrescReader.Read()
                'If PrescReader.HasRows Then
                Element = PrescReader("Article") & " (" & PrescReader("Prix") & " F)"
                lstAllActs.Items.Add(Element.ToUpper)

                'btnValidate.Enabled = True
                'End If
            End While
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            myConn.Close()
            myConn.Dispose()
        End Try
    End Sub


    Private Sub frmSearch_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        myConn = New MySqlConnection
        myLabConn = New MySqlConnection
        myConn.ConnectionString = frmMain.ServerString
        myLabConn.ConnectionString = frmMain.ServerString
        Me.Utilisateur = frmMain.Utilisateur
        Me.Text = Me.Text & " - " & frmMain.Utilisateur
        If Me.Id > 0 Then
            txtId.Text = Me.Id
            btnSearch_Click(sender, e)
        End If
        'Remplir les prescripteurs
        Qry = "SELECT noms FROM care_prescribers"
        Fillcbo(DB, cboPrescripteur, Qry)

    End Sub

    Private Sub txtId_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtId.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            btnSearch_Click(sender, e)

        End If
    End Sub

    Private Sub tabAllElements_Click(sender As Object, e As System.EventArgs) Handles tabAllElements.Click
        Dim isLab As Integer = 0

        If String.IsNullOrEmpty(txtInfos.Text.ToString) Then
            MsgBox("Bien vouloir chercher un patient avant faire une prescription")
        Else
            Try
                'Qry = "SELECT level FROM care_users WHERE personell_nr=1 AND level LIKE '%pharmacie%'"
                'myConn.Open()
                'Comd = New MySqlCommand(Qry, myConn)
                'PrescReader = Comd.ExecuteReader
                'PrescReader.Read()

                If Not IsNothing(Pharma) Then 'If PrescReader.HasRows = True Then
                    'Pharma = Pharmacie(PrescReader("level"))
                    If (tabAllElements.SelectedIndex = 0) Then
                        WhereClose = "item_number='CON' OR (" & Pharma & ">0 AND item_number='CAR') ORDER BY item_description ASC"
                    ElseIf (tabAllElements.SelectedIndex = 1) Then
                        WhereClose = Pharma & ">0 AND item_number='COM' ORDER BY item_description ASC"
                    ElseIf (tabAllElements.SelectedIndex = 2) Then
                        WhereClose = Pharma & ">0 AND item_number='INJ' ORDER BY item_description ASC"
                    ElseIf (tabAllElements.SelectedIndex = 3) Then
                        WhereClose = Pharma & ">0 AND item_number='SOL' ORDER BY item_description ASC"
                    ElseIf (tabAllElements.SelectedIndex = 4) Then
                        WhereClose = "(item_number='HOS' OR item_number='SPA') ORDER BY item_description ASC"
                    ElseIf (tabAllElements.SelectedIndex = 5) Then
                        WhereClose = Pharma & ">0 AND (item_number='SUP' OR item_number='VAC' OR item_number='POM' OR item_number='BUV') ORDER BY item_description ASC"
                    ElseIf (tabAllElements.SelectedIndex = 6) Then
                        WhereClose = "purchasing_class IN ('RADIOLOGIE', 'ECOGRAPHIE', 'ECG') ORDER BY item_description ASC"
                    ElseIf (tabAllElements.SelectedIndex = 7) Then
                        WhereClose = "purchasing_class='chirurgie' ORDER BY item_description ASC"
                    ElseIf (tabAllElements.SelectedIndex = 8) Then
                        WhereClose = "purchasing_class='maternite' ORDER BY item_description ASC"
                    ElseIf (tabAllElements.SelectedIndex = 9) Then
                        WhereClose = "purchasing_class='Laboratoire' ORDER BY item_description ASC"
                        'isLab = 1
                        'Qry = "SELECT name as Article, price as Prix FROM care_tz_laboratory_param ORDER BY name ASC"
                    End If
                    'If isLab = 0 Then
                    WhereClose = " WHERE " & WhereClose
                    Qry = "SELECT item_description as Article, unit_price as Prix FROM care_tz_drugsandservices " & WhereClose
                    'End If
                    myConn.Close()
                    FillPrescriptionsItems(Qry)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                myConn.Close()
                myConn.Dispose()
            End Try
        End If
    End Sub

    Private Sub txtId_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtId.TextChanged
        btnSearch.Enabled = True
    End Sub

    Private Sub lstAllActs_DoubleClick(sender As Object, e As System.EventArgs) Handles lstAllActs.DoubleClick
        'Dim Article As String
        Dim Result, TotalPrescription, Stock, QteDialogResult As Integer
        Dim Pharma, Level, Classe As String

        Article = lstAllActs.SelectedItem.ToString

        'Recuperer le nom de l'article
        Article = Article.Substring(0, Article.IndexOf("("))
        Article = Article.Substring(0, Article.Length - 1)

        If FindElementInList(lstPrescriptions, Article) = False Then
            Try
                'Get the appropriate stock according to the pharmacie that is logged on
                Qry = "SELECT level FROM care_users WHERE personell_nr=1 AND level LIKE '%pharmacie%'"
                myConn.Open()
                Comd = New MySqlCommand(Qry, myConn)
                PrescReader = Comd.ExecuteReader
                PrescReader.Read()

                If PrescReader.HasRows = True Then
                    Level = PrescReader.Item("level").ToString
                    myConn.Close()
                    Pharma = Pharmacie(Level)
                    Qry = "SELECT " & Pharma & ", purchasing_class FROM care_tz_drugsandservices WHERE item_description='" & Article & "'"
                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)
                    PrescReader = Comd.ExecuteReader
                    PrescReader.Read()
                    If PrescReader.HasRows = True Then
                        Stock = PrescReader.Item(Pharma)
                        Classe = PrescReader.Item("purchasing_class")

                        myConn.Close()
                        If Stock > 0 AndAlso (Classe = "MEDICAMENTS" Or Classe = "INJECTABLES" Or Classe = "POMADES" Or Classe = "SOLLUTES" Or Classe = "SUPPO" Or Classe = "VACCINS" Or Classe = "SUSPENSION") Then
                            Dim frmQte As New frmMettreQuantite
                            frmQte.Article = Article
                            frmQte.Stock = Stock

                            frmQte.ShowDialog()
                            QteDialogResult = frmQte.DialogResult
                            If QteDialogResult = Windows.Forms.DialogResult.OK Then
                                Result = CInt(frmQte.txtQuantite.Text)
                            End If
                        ElseIf (Classe = "CONSULTATION" Or Classe = "CARNET" Or Classe = "SALLES" Or Classe = "HOSPITALISATION" Or Classe = "MATERNITE" Or Classe = "CHIRURGIE" Or Classe = "LABORATOIRE" Or Classe = "ECG" Or Classe = "ECOGRAPHIE" Or Classe = "RADIOLOGIE") Then
                            Result = 1
                        End If
                        'Calculer le total de la prescription
                        If Result > 0 Then
                            Qry = "SELECT unit_price FROM care_tz_drugsandservices WHERE item_description='" & Article & "'"
                            myConn.Open()
                            Comd = New MySqlCommand(Qry, myConn)
                            PrescReader = Comd.ExecuteReader
                            PrescReader.Read()
                            'afficher le total
                            If PrescReader.HasRows = True Then
                                Price = CInt(PrescReader("unit_price"))
                                TotalPrescription = Result * Price
                                If String.IsNullOrEmpty(txtTotal.Text) Then
                                    txtTotal.Text = TotalPrescription
                                Else
                                    txtTotal.Text = CInt(txtTotal.Text) + TotalPrescription
                                End If
                                lstPrescriptions.Items.Add(Article & " (QUANTITE PRESCRITE=" & Result & ")")
                            End If
                            myConn.Close()
                        End If
                    Else
                        'myConn.Close()
                        'Result = 1

                        'Qry = "SELECT price FROM care_tz_laboratory_param WHERE name='" & Article & "'"
                        'myConn.Open()
                        'Comd = New MySqlCommand(Qry, myConn)
                        'PrescReader = Comd.ExecuteReader
                        'PrescReader.Read()
                        'afficher le total
                        'If PrescReader.HasRows = True Then
                        'Price = CInt(PrescReader("price"))
                        'TotalPrescription = Result * Price
                        'If String.IsNullOrEmpty(txtTotal.Text) Then
                        '   txtTotal.Text = TotalPrescription
                        'Else
                        '     txtTotal.Text = CInt(txtTotal.Text) + TotalPrescription
                        '  End If
                        '   lstPrescriptions.Items.Add(Article & " (QUANTITE PRESCRITE=" & Result & ")")
                        'End If
                        ' myConn.Close()
                    End If
                End If
            Catch ex As MySqlException
                MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Total Prescriptions")
            Finally
                myConn.Close()
                myConn.Dispose()
            End Try

        Else
            MsgBox("Element deja dans la liste des prescriptions", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Prescriptions")
        End If

    End Sub


    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSupprimer_Click(sender As System.Object, e As System.EventArgs) Handles btnSupprimer.Click
        Dim Result, Qte, Total As Integer
        Dim Article As String
        Result = MsgBox("Voulez vous vraiment supprimer cet element des prescriptions?" & Environment.NewLine & lstPrescriptions.SelectedItem.ToString, MsgBoxStyle.OkCancel Or MsgBoxStyle.Critical, "Prescriptions")
        If Result = 1 Then
            Try
                Article = ReturnArticle(lstPrescriptions.SelectedItem.ToString)
                Qte = ReturnQte(lstPrescriptions.SelectedItem.ToString)

                Qry = "SELECT unit_price FROM care_tz_drugsandservices WHERE item_description='" & Article & "'"
                myConn.Open()
                Comd = New MySqlCommand(Qry, myConn)
                PrescReader = Comd.ExecuteReader
                PrescReader.Read()
                'Modifier le total de la prescription et afficher ce total
                If PrescReader.HasRows = True Then
                    Price = CInt(PrescReader("unit_price"))
                    Total = Qte * Price
                    txtTotal.Text = CInt(txtTotal.Text) - Total
                Else
                    myConn.Close()
                    Qry = "SELECT price FROM care_tz_laboratory_param WHERE name='" & Article & "'"
                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)
                    PrescReader = Comd.ExecuteReader
                    PrescReader.Read()
                    'afficher le total
                    If PrescReader.HasRows = True Then
                        Price = CInt(PrescReader("price"))
                        Total = Qte * Price
                        txtTotal.Text = CInt(txtTotal.Text) - Total
                    End If
                End If
                myConn.Close()
                lstPrescriptions.Items().Remove(lstPrescriptions.SelectedItem)
                MsgBox("Element supprime avec success")
            Catch ex As MySqlException
                MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Total Prescriptions")
            Finally
                myConn.Close()
                myConn.Dispose()
            End Try
        End If
    End Sub

    Private Sub btnModifier_Click(sender As System.Object, e As System.EventArgs) Handles btnModifier.Click
        Dim Qte, NouvelleQte, TotalPrescription As Integer
        Dim Article As String
        Article = ReturnArticle(lstPrescriptions.SelectedItem.ToString)
        Qte = ReturnQte(lstPrescriptions.SelectedItem.ToString)

        Try
            Qry = "SELECT unit_price FROM care_tz_drugsandservices WHERE item_description='" & Article & "'"
            myConn.Open()
            Comd = New MySqlCommand(Qry, myConn)
            PrescReader = Comd.ExecuteReader
            PrescReader.Read()
            'Modifier le total de la prescription et afficher ce total
            If PrescReader.HasRows = True Then
                Price = CInt(PrescReader("unit_price"))
                TotalPrescription = Qte * Price
                txtTotal.Text = CInt(txtTotal.Text) - TotalPrescription

            End If

            lstPrescriptions.Items().Remove(lstPrescriptions.SelectedItem)
            'MsgBox("Element supprime avec success")
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Total Prescriptions")
        Finally
            myConn.Close()
            myConn.Dispose()
        End Try

        Dim frmQte As New frmMettreQuantite
        frmQte.Article = Article
        frmQte.Qte = Qte

        frmQte.ShowDialog()
        NouvelleQte = CInt(frmQte.txtQuantite.Text)

        'Calculer le total de la prescription
        Try
            Qry = "SELECT unit_price FROM care_tz_drugsandservices WHERE item_description='" & Article & "'"
            myConn.Open()
            Comd = New MySqlCommand(Qry, myConn)
            PrescReader = Comd.ExecuteReader
            PrescReader.Read()
            'afficher le total
            If PrescReader.HasRows = True Then
                Price = CInt(PrescReader("unit_price"))
                TotalPrescription = NouvelleQte * Price
                If String.IsNullOrEmpty(txtTotal.Text) Then
                    txtTotal.Text = TotalPrescription
                Else
                    txtTotal.Text = CInt(txtTotal.Text) + TotalPrescription
                End If
            End If

        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Total Prescriptions")
        Finally
            myConn.Close()
            myConn.Dispose()
        End Try
        lstPrescriptions.Items.Add(Article & " (QUANTITE PRESCRITE=" & NouvelleQte & ")")
    End Sub

    Private Sub lstPrescriptions_LostFocus(sender As Object, e As System.EventArgs) Handles lstPrescriptions.LostFocus
        'btnModifier.Enabled = False
        'btnSupprimer.Enabled = False
    End Sub

    Private Sub lstPrescriptions_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstPrescriptions.SelectedIndexChanged
        btnModifier.Enabled = True
        btnSupprimer.Enabled = True
        'btnPrescrire.Enabled = True
    End Sub

    Private Sub txtInfos_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtInfos.TextChanged
        grpPrescriptions.Enabled = True
    End Sub

    Private Sub btnModifier_LostFocus(sender As Object, e As System.EventArgs) Handles btnModifier.LostFocus
        btnModifier.Enabled = False
        btnSupprimer.Enabled = False
    End Sub

    Private Sub btnPrescrire_Click(sender As System.Object, e As System.EventArgs) Handles btnPrescrire.Click
        Dim Article, DrugClass As String
        Dim Dose, ItemNum, Price As Integer
        DrugClass = ""
        If cboPrescripteur.SelectedIndex < 0 Then
            MsgBox("Choisir le prescripteur svp.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Prescription")
            cboPrescripteur.Focus()
            Exit Sub
        End If
        If lstPrescriptions.Items.Count > 0 Then
            For Count As Integer = 0 To lstPrescriptions.Items.Count - 1
                Article = ReturnArticle(lstPrescriptions.Items(Count).ToString)
                Dose = ReturnQte(lstPrescriptions.Items(Count).ToString)

                Try
                    Qry = "SELECT item_id as Id, unit_price as Prix, purchasing_class as Type FROM " & _
                        "care_tz_drugsandservices WHERE item_description='" & Article & "'"

                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)
                    PrescReader = Comd.ExecuteReader
                    PrescReader.Read()
                    'afficher le total
                    If PrescReader.HasRows = True Then
                        ItemNum = CInt(PrescReader("Id"))
                        Price = CInt(PrescReader("Prix"))
                        DrugClass = PrescReader("Type").ToString
                        myConn.Close()
                    Else
                        myConn.Close()
                        Qry = "SELECT nr, price FROM care_tz_laboratory_param WHERE name='" & Article & "'"
                        myConn.Open()
                        Comd = New MySqlCommand(Qry, myConn)
                        PrescReader = Comd.ExecuteReader
                        PrescReader.Read()
                        If PrescReader.HasRows = True Then
                            ItemNum = CInt(PrescReader("nr"))
                            Price = CInt(PrescReader("price"))
                            DrugClass = "Laboratoire"
                        End If
                    End If
                    ''''''''''''''''''''''''''''
                    '' Inserer les donnees dans la table des prescriptions
                    '''''''''''''''''''''''''''''''''''

                    myConn.Close()
                    Qry = "INSERT INTO care_encounter_prescription " & _
                        "(encounter_nr, article, article_item_number, price, drug_class, dosage, prescribe_date, prescriber, create_id, create_time) " & _
                        "VALUES (" & Encounter & ", '" & Article & "', " & ItemNum & ", " & Price & ", '" & DrugClass & "', " & _
                        Dose & ",' " & Now().ToString("yyyy-MM-dd") & "', '" & cboPrescripteur.Text & "', '" & Me.Utilisateur & "', '" & Now().ToString("yyyy-MM-dd hh:mm") & "')"
                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)
                    Comd.ExecuteNonQuery()
                    myConn.Close()
                Catch ex As MySqlException
                    MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Total Prescriptions")
                Finally
                    myConn.Close()
                    myConn.Dispose()
                End Try
            Next
            MsgBox("Prescriptions faites avec succes!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Prescriptions")
            Me.Close()
        Else
            MsgBox("Il n'y a aucun elements a prescrire!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Prescriptions")
        End If
    End Sub

    Private Sub lstAllActs_GotFocus(sender As Object, e As System.EventArgs) Handles lstAllActs.GotFocus
        btnModifier.Enabled = False
        btnSupprimer.Enabled = False
    End Sub

    Private Sub lstAllActs_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstAllActs.SelectedIndexChanged

    End Sub

    Private Sub frmPatientPrescription_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

    End Sub
End Class