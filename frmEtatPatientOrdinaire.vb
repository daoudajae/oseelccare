Imports MySql.Data.MySqlClient
Public Class frmEtatPatientOrdinaire

    Public Property Permission As String
    Public Property Utilisateur As String
    'Public ServerString As String

    Dim myConn, myConn1, myLabConn As New MySqlConnection
    Dim Comd, Comd1, LabCmd As MySqlCommand
    Dim PrescReader, LabReader As MySqlDataReader
    Dim TotalSelect, EncounterPercent, TotalAssureur, TotalAssurer, TotalExclusion, billAmount, billNo, Exclusion, BonCfg As Integer
    Dim ConnMode, EncounterType, FirmName, ContactName, PatientRelation, PatientQuality As String
    Dim Encounter As ULong
    Dim facturetotal, factureclient, facturesociete As Double
    Dim qry1, qry2, qry3, qry4, qry5, nom, liste As String


    Private Sub frmEtatPatientOrdinaire_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        myConn.ConnectionString = frmMain.ServerString
        myConn1.ConnectionString = frmMain.ServerString
        myLabConn.ConnectionString = frmMain.ServerString



    End Sub

    Private Sub GetEncounterInformation()

        Dim qry, Enc_Date, Patient_Name, Patient_Birth As String
        Dim dtaAdapter As New MySqlDataAdapter
        Dim dtaDataTable As New DataTable
        Dim bindSource As New BindingSource

        'dgvPrescriptions.Width = 60

        'dtaDataTable.DataSet.Clear()
        bindSource.DataSource = Nothing
        'myConn = New MySqlConnection
        'myConn.ConnectionString = "server=192.168.15.20;userid=root;password=server;database=caredb"
        myConn.ConnectionString = frmMain.ServerString

        If String.IsNullOrEmpty(txtId.Text) Then
            MsgBox("Vous devez saisir le numero du patient", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
            txtId.Focus()
            txtId.Clear()
            Exit Sub
        End If
        If Not IsNumeric(txtId.Text) Then
            MsgBox("Vous devez saisir le numero du patient", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
            txtId.Focus()
            Exit Sub
        End If
        If (Integer.Parse(txtId.Text) >= 10000000) Then
            Try
                'Get the encounter number, encounter date, config bon, encounter_type of the patient
                myConn.Open()
                qry = "SELECT insurance_firm, contact_name, contact_relation, quality, exclusion, bonpercent, encounter_nr, encounter_date, boncfg, encounter_type  FROM caredb.care_encounter WHERE pid=" & CULng(txtId.Text) & _
                    " AND is_discharged=0 ORDER BY encounter_date"
                Comd = New MySqlCommand(qry, myConn)
                'Get the encounter number
                PrescReader = Comd.ExecuteReader
                PrescReader.Read()
                If PrescReader.HasRows = True Then
                    Encounter = PrescReader.Item("encounter_nr")
                    BonCfg = PrescReader.Item("boncfg")
                    Enc_Date = PrescReader.Item("encounter_date")
                    EncounterType = PrescReader.Item("encounter_type")
                    EncounterPercent = PrescReader.Item("bonpercent")
                    FirmName = PrescReader.Item("insurance_firm")
                    ContactName = PrescReader.Item("contact_name")
                    PatientRelation = PrescReader.Item("contact_relation")
                    PatientQuality = PrescReader.Item("quality")
                    Exclusion = PrescReader.Item("exclusion")

                    myConn.Close()
                    '
                    'Get the Patient information
                    myConn.Open()
                    qry = "SELECT name_first, name_last, date_birth FROM caredb.care_person WHERE pid=" & CULng(txtId.Text)
                    Comd = New MySqlCommand(qry, myConn)
                    'Get the encounter number
                    PrescReader = Comd.ExecuteReader
                    PrescReader.Read()
                    Patient_Name = PrescReader.Item("name_last") & " " & PrescReader.Item("name_first")
                    nom = Patient_Name
                    Patient_Birth = PrescReader.Item("date_birth")
                    myConn.Close()
                    'grpFacturation.Visible = True
                    grpInfo.Visible = True
                    'Me.Height = 205
                    'Me.Width = 765
                    'Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
                    'Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
                    txtInfos.Text = "Noms: " & Patient_Name & Environment.NewLine & "Né(e) le: " & Patient_Birth & _
                        Environment.NewLine & "No Visite: " & Encounter & " du: " & Enc_Date
                    If BonCfg > 0 Then
                        txtInfos.Text = txtInfos.Text & Environment.NewLine & "Bon de type: " & EncounterType & " à: " & EncounterPercent & "%" & _
                            Environment.NewLine & "Assurance: " & FirmName
                        If BonCfg = 3 Then
                            txtInfos.Text = txtInfos.Text & Environment.NewLine & "En qualité de: " & PatientQuality
                        End If
                        If Exclusion = 1 Then
                            txtInfos.Text = txtInfos.Text & Environment.NewLine & _
                                "Bon à eclusion!!!"
                        End If
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
            txtId.Focus()
            txtId.Clear()
            Exit Sub
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        GetEncounterInformation()
        GetEncounterList()

        ' GetFactureInformation()

    End Sub

    Private Sub GetEncounterList()

        Dim dtaDataTable As New DataTable
        Dim dtlaAdapter As New MySqlDataAdapter
        Dim qry As String
        Dim factlist As New DataTable

        listerencontre.DataSource = Nothing
        listerencontre.Rows.Clear()
        listerencontre.Columns.Clear()
        ' If DataGridView1.GetRowCount Then
        Try
            myConn.Open()
            qry = "SELECT `care_encounter`.`encounter_nr`, `care_encounter`.`encounter_date`  FROM `care_encounter`  WHERE   `care_encounter`.`pid`=" & (Integer.Parse(txtId.Text)) & " ORDER BY `encounter_nr` DESC  LIMIT 10"

            Comd = New MySqlCommand(qry, myConn)

            dtlaAdapter.SelectCommand = Comd
            dtlaAdapter.Fill(factlist)
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            myConn.Close()
        End Try
        myConn.Close()



        listerencontre.DataSource = factlist

        'je cache et je renomme les colonne 
        With listerencontre

            .Columns("encounter_nr").HeaderCell.Value = "N. Rencontre"
            .Columns("encounter_nr").ReadOnly = True
            .Columns("encounter_nr").Width = 150
            .Columns("encounter_date").HeaderCell.Value = "Date Rencontre"
            .Columns("encounter_date").Width = 150
            .Columns("encounter_date").ReadOnly = True
            
            ' .Columns("encounter_nr").Width = 200
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            Dim col As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
            col.HeaderText = "A Considerer"
            listerencontre.Columns.Add(col)
            'listerencontre.Columns("A Considerer").Width = 150


        End With

    End Sub



    Private Sub GetFactureInformation()

        'Dim PrescReader, PrescReader1 As MySqlDataReader
        Dim dtaDataTable As New DataTable
        Dim dtaAdapter As New MySqlDataAdapter
        Dim qry As String
        Dim factcredit As New DataTable

        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        ' If DataGridView1.GetRowCount Then
        Try
            myConn.Open()
            qry = "SELECT `care_billing_payment`.`receipt_no`, `care_billing_payment`.`datebilled`,`care_billing_payment`.`datepaid`,`care_billing_payment`.`billtotal`, `care_billing_payment`.`typepaiement`,`care_billing_payment`.`paid`  FROM `care_billing_payment`  WHERE   `care_billing_payment`.`encounter_nr` IN " & liste & " ORDER BY `datebilled` DESC"

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
            '.Columns("billamount").Visible = False
            '.Columns("patientamount").Visible = False
            '.Columns("billamount").Visible = False
            ' .Columns("encounter_nr").Visible = False
            '.RowHeadersVisible = False


            .Columns("receipt_no").HeaderCell.Value = "N. Facture"
            .Columns("receipt_no").ReadOnly = True
            .Columns("datebilled").HeaderCell.Value = "Facturé le"
            .Columns("datebilled").ReadOnly = True
            .Columns("datepaid").HeaderCell.Value = "Payé le"
            .Columns("datepaid").ReadOnly = True
            .Columns("billtotal").HeaderCell.Value = "Total Fact."
            .Columns("billtotal").ReadOnly = True
            .Columns("typepaiement").HeaderCell.Value = "Type Facture"
            .Columns("typepaiement").ReadOnly = True
            .Columns("paid").Visible = False
            ' .Columns("name_last").Width = 200
            '.Columns("datebilled").HeaderCell.Value = "Date Facturation"
            '.Columns("name_first").Width = 200
            '.Columns("typepaiement").HeaderCell.Value = "Type"
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

    Private Sub imprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imprimer.Click

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

            qry3 = "SELECT `id`,`date` as Date, `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total, `status` as Status  FROM `care_billing_bill_item` WHERE `encounter_nr`IN " & liste & "  AND  `islab`=1 " ' "AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"

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
                    factureclient = factureclient + CInt(DataGridView1.Rows(j).Cells(5).Value)


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
            frm.facturesociete = facturetotal - factureclient
            frm.factureclient = factureclient
            frm.facturetotal = facturetotal
            frm.nom = nom
            frm.isbon = False
            frm.pid = txtId.Text

            'lbrequete.Text = qry2
            frm.ShowDialog()

        Else
            MsgBox("Selectionner une/des facture(s)")
        End If
        
    End Sub



    ' End Sub

    Private Sub validerrencontre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles validerrencontre.Click
        liste = ""
        Dim tour As Integer = 0
        For j As Integer = 0 To (listerencontre.Rows.Count - 1)

            If listerencontre.Rows(j).Cells(2).Value = True Then
                If tour = 0 Then
                    liste = " (" & listerencontre.Rows(j).Cells(0).Value '& ""

                Else
                    liste = liste & " ," & listerencontre.Rows(j).Cells(0).Value '& ""

                End If

                tour = tour + 1
            End If

        Next
        liste = liste & ")"


        GetFactureInformation()
    End Sub
End Class