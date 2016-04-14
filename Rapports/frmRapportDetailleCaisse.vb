Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmRapportDetailleCaisse

    Dim myConn, myConn2, myConn3, myConn4, myConn5, myConn6, myConn7, myConn8, myConn9, myConn10, myConn11, myConn12 As New MySqlConnection
    Dim Comd, Comd2, Comd3, Comd4, Comd5, Comd6, Comd7, Comd8, Comd9, Comd10, Comd11, Comd12 As MySqlCommand
    Dim PrescReader, PrescReader2, PrescReader3, PrescReader4, PrescReader5, PrescReader6, PrescReader7, PrescReader8, PrescReader9, PrescReader10, PrescReader11, PrescReader12 As MySqlDataReader
    Dim TotalSelect As Integer
    Dim ConnMode As String
    Dim Encounter As ULong
    Dim billnum As String
    Dim totalbillamount As Double
    Dim totalreceiptamount As Double
    Dim amountdue As Double
    Dim user As String
    Dim testbill As String
    Dim agentdefacturation As String
    Dim montantverse, montantversehors, creditfacture, creditfirm, creditpatient, profacture, creditbon, facture As Double
    Dim article, item_number As String
    Dim amount As Integer
    Dim nomprenom As String
    Dim Pid As Integer

    Dim totalfirm As Integer

    Dim qry, qry2, qry3, qry4, qry5, qry6, qry7, qry8, qry9, qry10, qry11, qry12, Enc_Date, Enc_type, Patient_Name, Patient_Birth As String
    Dim dtaAdapter As New MySqlDataAdapter
    Dim dtaDataTable, ltcredit As New DataTable
    Dim bindSource As New BindingSource

    Dim BonCfg As Integer
    Dim newListRow, elementrow As DataRow

    Dim dtelement, dtelementgroupe, dtcredit, dtdetaillepersonnel, dtdetailleclerge, dtfacture As New DataTable
    Public datedebut As Date
    Public facturation As Boolean
    Public datefin As Date
    Public agentfacturation As String
    Public agentcaisse As String

    Private Sub frmRapportDetailleCaisse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myConn.ConnectionString = frmMain.ServerString
        myConn2.ConnectionString = frmMain.ServerString
        myConn3.ConnectionString = frmMain.ServerString
        myConn4.ConnectionString = frmMain.ServerString
        myConn5.ConnectionString = frmMain.ServerString
        myConn6.ConnectionString = frmMain.ServerString
        myConn7.ConnectionString = frmMain.ServerString
        myConn8.ConnectionString = frmMain.ServerString
        myConn9.ConnectionString = frmMain.ServerString
        myConn10.ConnectionString = frmMain.ServerString
        myConn11.ConnectionString = frmMain.ServerString
        myConn12.ConnectionString = frmMain.ServerString

        ' Me.Text = Me.Text & " - " & 

        element_detaille()
        total_global()
        ' credit()


        datagridelementspecialise.DataSource = element_groupe()

        'je rempli la table ltcredit contanat la liste des patient a credit
        listecredit()

        'je rempli le datagrid sciete avec les credit
        societecredit.DataSource = liste_credit()


        Dim dt, dtlist As New DataTable
        Dim r As DataRow
        dt.Columns.Add("Item_Number", Type.GetType("System.String"))
        dt.Columns.Add("Montant", Type.GetType("System.Double"))
        dtlist.Columns.Add("typebon", Type.GetType("System.String"))
        dtlist.Columns.Add("firmamount", Type.GetType("System.Double"))


        For i = 0 To datagridelementspecialise.RowCount - 1
            r = dt.NewRow
            r("Item_Number") = datagridelementspecialise.Rows(i).Cells(0).Value.ToString
            r("Montant") = datagridelementspecialise.Rows(i).Cells(1).Value.ToString
            dt.Rows.Add(r)

        Next

        
        For i = 0 To societecredit.RowCount - 1
            r = dtlist.NewRow
            r("typebon") = societecredit.Rows(i).Cells(0).Value.ToString
            r("firmamount") = societecredit.Rows(i).Cells(1).Value.ToString
            dtlist.Rows.Add(r)

        Next
       
       


        'je definit les parametre du rapport principal

        Dim rptprincipal As New detaillefacturation

        rptprincipal.SetDataSource(dt)
        ' rptprincipal.SetParameterValue("datedebut", datedebut)

        rptprincipal.SetParameterValue("total", profacture.ToString)
        rptprincipal.SetParameterValue("facture", profacture.ToString)
        'MsgBox(trecette.ToString)
        rptprincipal.SetParameterValue("recette", (montantverse + montantversehors).ToString)
        rptprincipal.SetParameterValue("recu", montantverse.ToString)
        rptprincipal.SetParameterValue("recuhors", montantversehors.ToString)
        rptprincipal.SetParameterValue("credit", (creditbon).ToString)
        rptprincipal.SetParameterValue("creditfacture", (creditfacture).ToString)
        rptprincipal.SetParameterValue("creditfirm", (0).ToString)
        rptprincipal.SetParameterValue("creditpatient", (0).ToString)
        rptprincipal.SetParameterValue("datedebut", datedebut.ToString)
        rptprincipal.SetParameterValue("datefin", datefin.ToString)
        rptprincipal.SetParameterValue("agent", "")
        'rptprincipal.SetParameterValue("agentcaisse", "")

        CrystalReportViewer.ReportSource = rptprincipal

        Dim rptsociete As New listesocietecredit
        rptsociete.SetDataSource(dtlist)
        CrystalReportViewer1.ReportSource = rptsociete


    End Sub

    Function element_credit() As IList
        
        Dim result = (From orders In dtcredit.AsEnumerable
Group orders By typebon = orders.Field(Of String)("typebon") Into g = Group
Select New With {Key typebon,
 .Amount = g.Sum(Function(r) r.Field(Of Double)("reste"))
}).OrderBy(Function(tkey) tkey.typebon).ToList

        Return result

    End Function

    
    Private Sub total_global()

        Dim result As Integer = 0
        creditbon = 0
        profacture = 0


        Try

            myConn.Open()
            'montant des factures payes
            dtfacture.Reset()

            qry = "Select  `care_billing_payment`.`paid` " &
                    "FROM `care_billing_payment` " &
                    "WHERE `datepaid` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "' AND '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "' " &
            " AND `care_billing_payment`.`typepaiement`='normal'  "


            If agentcaisse = "None" Then

            Else
                qry = qry & " AND  `care_billing_payment`.`encaisseur` ='" & agentcaisse & "'"
            End If
            
            
            Comd = New MySqlCommand(qry, myConn)

            dtaAdapter.SelectCommand = Comd
            dtaAdapter.Fill(dtfacture)
            myConn.Close()

            If dtfacture.Rows.Count > 0 Then

                profacture = dtfacture.Compute("SUM(paid)", "")

            Else
                profacture = 0
            End If

        Catch ex As Exception
            myConn.Close()
        End Try

        'Ajout du billamount des factures repertorié pour a periode en question

        Try

            myConn.Open()

            dtfacture.Reset()

            qry = "Select `billamount` " &
                    "FROM `care_billing_payment` " &
                    "INNER JOIN `care_billing_credit` ON `care_billing_payment`.`receipt_no` = `care_billing_credit`.`billno` " &
                    "WHERE `datebilled` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "' AND '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "' " &
                    " AND `care_billing_payment`.`typepaiement`='bon'"

            If agentcaisse = "None" Then

            Else
                qry = qry & " AND  `care_billing_payment`.`encaisseur` ='" & agentcaisse & "'"
            End If


            Comd = New MySqlCommand(qry, myConn)

            dtaAdapter.SelectCommand = Comd
            dtaAdapter.Fill(dtfacture)
            myConn.Close()

            If dtfacture.Rows.Count > 0 Then

                profacture = profacture + dtfacture.Compute("SUM(billamount)", "")

            Else
                profacture = profacture
            End If

        Catch ex As Exception
            myConn.Close()
        End Try
       

        'calcul du credit en prenant compte de la part societe

        Try

            myConn.Open()

            dtfacture.Reset()

            qry = "Select  `care_billing_credit`.`firmamount` " &
                    "FROM `care_billing_payment` " &
                    "INNER JOIN `care_billing_credit` ON `care_billing_payment`.`receipt_no` = `care_billing_credit`.`billno` " &
                    "WHERE `datebilled` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "' AND '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "' " &
                    " AND `care_billing_payment`.`typepaiement`='bon'  " 

            If agentcaisse = "None" Then

            Else
                qry = qry & " AND  `care_billing_payment`.`encaisseur` ='" & agentcaisse & "'"
            End If


            Comd = New MySqlCommand(qry, myConn)

            dtaAdapter.SelectCommand = Comd
            dtaAdapter.Fill(dtfacture)
            myConn.Close()

            If dtfacture.Rows.Count > 0 Then

                creditbon = dtfacture.Compute("SUM(firmamount)", "")

            End If

        Catch ex As Exception
            myConn.Close()
        End Try


        'je recupere le montant des factures des patiens non payes

        Try

            myConn.Open()

            dtfacture.Reset()

            qry = "Select  `care_billing_credit`.`patientamount` " &
                    "FROM `care_billing_payment` " &
                    "INNER JOIN `care_billing_credit` ON `care_billing_payment`.`receipt_no` = `care_billing_credit`.`billno` " &
                    "WHERE `care_billing_payment`.`datebilled` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "' AND '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "' " &
                    " AND `care_billing_payment`.`typepaiement`='bon'  " &
                    " AND `care_billing_credit`.`patientpaid`=0  "

            If agentcaisse = "None" Then

            Else
                qry = qry & " AND  `care_billing_payment`.`encaisseur` ='" & agentcaisse & "'"
            End If


            Comd = New MySqlCommand(qry, myConn)

            dtaAdapter.SelectCommand = Comd
            dtaAdapter.Fill(dtfacture)
            myConn.Close()

            If dtfacture.Rows.Count > 0 Then

                creditbon = creditbon + dtfacture.Compute("SUM(patientamount)", "")

            End If

        Catch ex As Exception
            myConn.Close()
        End Try

       



        Try

            'je calculele le total montant recu pendant la periode en question
            myConn.Open()

            qry = "SELECT SUM(`paid`) as paid FROM `care_billing_payment` WHERE `datepaid` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "'  AND  '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "'"
            qry = qry & " AND `datebilled` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "'  AND  '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "'"

            If agentcaisse = "None" Then

            Else
                qry = qry & " AND  `care_billing_payment`.`encaisseur` ='" & agentcaisse & "'"
            End If


            Comd = New MySqlCommand(qry, myConn)

            PrescReader = Comd.ExecuteReader

            If PrescReader.HasRows Then
                PrescReader.Read()

                If IsDBNull((PrescReader.Item("paid"))) = False Then
                    montantverse = CDbl(PrescReader.Item("paid"))
                Else
                    montantverse = 0
                End If

            End If

            myConn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try

            'je calcule le total montant recu pour des fatures precedentes
            myConn.Open()

            qry = "SELECT SUM(`paid`) as paid FROM `care_billing_payment` WHERE `datepaid` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "'  AND  '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "'"
            qry = qry & "  AND `datebilled` < '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "' "

            If agentcaisse = "None" Then

            Else
                qry = qry & " AND  `care_billing_payment`.`encaisseur` ='" & agentcaisse & "'"
            End If


            Comd = New MySqlCommand(qry, myConn)

            PrescReader = Comd.ExecuteReader

            If PrescReader.HasRows Then
                PrescReader.Read()

                If IsDBNull((PrescReader.Item("paid"))) = False Then
                    montantversehors = CDbl(PrescReader.Item("paid"))
                Else
                    montantversehors = 0
                End If

            End If

            myConn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ' total credit

        Try
            dtfacture.Reset()
            myConn.Open()

            dtfacture.Reset()

            qry = "Select `care_billing_credit`.`billamount`" &
                    "FROM `care_billing_payment` " &
                    "INNER JOIN `care_billing_credit` ON `care_billing_payment`.`receipt_no` = `care_billing_credit`.`billno` " &
                    "WHERE `datebilled` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "' AND '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "' " &
                    " AND `care_billing_payment`.`typepaiement`='bon'"


            If agentcaisse = "None" Then

            Else
                qry = qry & " AND  `care_billing_payment`.`encaisseur` ='" & agentcaisse & "'"
            End If


            Comd = New MySqlCommand(qry, myConn)

            dtaAdapter.SelectCommand = Comd
            dtaAdapter.Fill(dtfacture)
            myConn.Close()

            If dtfacture.Rows.Count > 0 Then

                creditfirm = dtfacture.Compute("SUM(billamount)", "")

            Else
                creditfirm = 0
            End If

        Catch ex As Exception
            myConn.Close()
        End Try



        Try

            myConn.Open()
            'calcul le montant des facture a credit
            dtfacture.Reset()

            qry = "Select SUM(`care_billing_payment`.`billtotal`) AS `paid` " &
                  "FROM `care_billing_payment` " &
                  "WHERE `datebilled` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "' AND '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "' " &
                  " AND `care_billing_payment`.`typepaiement`='normal'" &
                  " AND `care_billing_payment`.`datepaid` IS NULL"

            If agentcaisse = "None" Then

            Else
                qry = qry & " AND  `care_billing_payment`.`encaisseur` ='" & agentcaisse & "'"
            End If

            Comd = New MySqlCommand(qry, myConn)

            PrescReader = Comd.ExecuteReader

            If PrescReader.HasRows Then
                PrescReader.Read()

                If IsDBNull((PrescReader.Item("paid"))) = False Then
                    creditfacture = CDbl(PrescReader.Item("paid"))
                Else
                    creditfacture = 0
                End If

            End If
            

        Catch ex As Exception
            myConn.Close()
        End Try

        'affectation des nouvelles valeurs aux anciennes variables


    End Sub


    Function element_groupe() As IList

        Dim result = (From orders In dtelement.AsEnumerable
Group orders By ItemNumber = orders.Field(Of String)("item_number") Into g = Group
Select New With {Key ItemNumber,
 .Amount = g.Sum(Function(r) r.Field(Of Double)("amount"))
}).OrderBy(Function(tkey) tkey.ItemNumber).ToList

        Return result

    End Function

    Private Sub element_detaille()
        Dim islab As Integer = 0
        Dim purchassing_class As String
        'Dim typepaiement As String
        'Dim bonpercent, bonconfig As Integer
        Dim elelment As Integer = 0
        Dim nfact As Integer
        ' Dim encouter_type As String


        dtelement.Reset()
        dtelement.Columns.Add("item_number", Type.GetType("System.String"))
        dtelement.Columns.Add("article", Type.GetType("System.String"))
        dtelement.Columns.Add("amount", Type.GetType("System.Double"))
        'dtelement.AcceptChanges()

        dtelement = init_table(dtelement)

        Try

            ' recuperation de encounter et bill number dans care_billing_payment
            
            qry = "SELECT `encounter_nr`,`receipt_no` FROM `care_billing_payment` WHERE `datepaid` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "' AND '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "' " &
             " AND `typepaiement`='normal'"

            If agentcaisse = "None" Then

            Else
                qry = qry & " AND  `care_billing_payment`.`encaisseur` ='" & agentcaisse & "'"
            End If

            myConn.Open()
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            ' If PrescReader.HasRows Then
            While PrescReader.Read()

                Encounter = PrescReader.Item("encounter_nr")
                nfact = PrescReader.Item("receipt_no")

                ' je doit recuperer le encouter typ ici


                Try
                    'recuperations de article et amount dans care_billing_bill_item
                    qry2 = "SELECT `article`,`amount`,`islab` FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `bill_no`=" & nfact ' "'" 'AND `bill_number`=0"
                    myConn2.Open()
                    Comd2 = New MySqlCommand(qry2, myConn2)
                    PrescReader2 = Comd2.ExecuteReader
                    'If PrescReader2.HasRows Then
                    While PrescReader2.Read

                        article = PrescReader2.Item("article")
                        amount = CInt(PrescReader2.Item("amount"))
                        islab = CInt(PrescReader2.Item("islab"))
                        elelment = elelment + 1
                        Try
                            'recuperation de item_number dans care_tz_drugsandservices

                            If islab = 0 Then
                                qry3 = "SELECT `item_number`,`purchasing_class` FROM `care_tz_drugsandservices` WHERE `item_description`='" & MySqlHelper.EscapeString(article) & "'" '  AND  `bill_no`=" & billnum ' "'" 'AND `bill_number`=0"
                                myConn3.Open()
                                Comd3 = New MySqlCommand(qry3, myConn3)
                                PrescReader3 = Comd3.ExecuteReader
                                If PrescReader3.HasRows Then
                                    PrescReader3.Read()

                                    item_number = conversion_item_number(PrescReader3.Item("item_number"))
                                    purchassing_class = PrescReader3.Item("purchasing_class")

                                    If purchassing_class <> "xray" Then
                                        elementrow = dtelement.NewRow
                                        elementrow("item_number") = item_number
                                        elementrow("article") = article
                                        elementrow("amount") = amount
                                        dtelement.Rows.Add(elementrow)
                                        dtelement.AcceptChanges()

                                    Else

                                        elementrow = dtelement.NewRow
                                        elementrow("item_number") = "70 650 - RECETTE IMAGERIE"
                                        elementrow("article") = article
                                        elementrow("amount") = amount
                                        dtelement.Rows.Add(elementrow)
                                        dtelement.AcceptChanges()
                                        'jajoute une ligne dans mon tableau

                                    End If
                                    'jajoute une ligne dans mon tableau



                                    ' End While
                                End If
                                PrescReader3.Close()
                                Comd3.ExecuteNonQuery()
                                myConn3.Close()
                            Else

                                'je separe les CD4 des labo ici

                                item_number = "70 640 - RECETTE LABORATOIRE"
                                elementrow = dtelement.NewRow
                                elementrow("item_number") = item_number
                                elementrow("article") = article
                                
                                elementrow("amount") = amount
                                dtelement.Rows.Add(elementrow)
                                dtelement.AcceptChanges()

                            End If




                        Catch ex As Exception
                            MsgBox(ex.ToString)
                            myConn3.Close()
                        End Try

                    End While
                    'End If
                    PrescReader2.Close()
                    Comd2.ExecuteNonQuery()
                    myConn2.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    myConn2.Close()
                End Try

            End While
            'End If
            PrescReader.Close()
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try

        'ajout des elements des bons de prise en charge
        Try

            qry = "SELECT `encounter_nr`,`receipt_no` FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "'  AND  '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "'" &
             " AND `typepaiement`='bon'"

            If agentcaisse = "None" Then

            Else
                qry = qry & " AND  `care_billing_payment`.`encaisseur` ='" & agentcaisse & "'"
            End If

            myConn.Open()
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            ' If PrescReader.HasRows Then
            While PrescReader.Read()

                Encounter = PrescReader.Item("encounter_nr")
                nfact = PrescReader.Item("receipt_no")

                ' je doit recuperer le encouter typ ici


                Try
                    'recuperations de article et amount dans care_billing_bill_item
                    qry2 = "SELECT `article`,`amount`,`islab` FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `bill_no`=" & nfact ' "'" 'AND `bill_number`=0"
                    myConn2.Open()
                    Comd2 = New MySqlCommand(qry2, myConn2)
                    PrescReader2 = Comd2.ExecuteReader
                    'If PrescReader2.HasRows Then
                    While PrescReader2.Read

                        article = PrescReader2.Item("article")
                        amount = CInt(PrescReader2.Item("amount"))
                        islab = CInt(PrescReader2.Item("islab"))
                        elelment = elelment + 1
                        Try
                            'recuperation de item_number dans care_tz_drugsandservices

                            If islab = 0 Then
                                qry3 = "SELECT `item_number`,`purchasing_class` FROM `care_tz_drugsandservices` WHERE `item_description`='" & MySqlHelper.EscapeString(article) & "'" '  AND  `bill_no`=" & billnum ' "'" 'AND `bill_number`=0"
                                myConn3.Open()
                                Comd3 = New MySqlCommand(qry3, myConn3)
                                PrescReader3 = Comd3.ExecuteReader
                                If PrescReader3.HasRows Then
                                    PrescReader3.Read()

                                    item_number = conversion_item_number(PrescReader3.Item("item_number"))
                                    purchassing_class = PrescReader3.Item("purchasing_class")

                                    If purchassing_class <> "xray" Then
                                        elementrow = dtelement.NewRow
                                        elementrow("item_number") = item_number
                                        elementrow("article") = article
                                        elementrow("amount") = amount
                                        dtelement.Rows.Add(elementrow)
                                        dtelement.AcceptChanges()

                                    Else

                                        elementrow = dtelement.NewRow
                                        elementrow("item_number") = "70 650 - RECETTE IMAGERIE"
                                        elementrow("article") = article
                                        elementrow("amount") = amount
                                        dtelement.Rows.Add(elementrow)
                                        dtelement.AcceptChanges()
                                        'jajoute une ligne dans mon tableau

                                    End If
                                    'jajoute une ligne dans mon tableau



                                    ' End While
                                End If
                                PrescReader3.Close()
                                Comd3.ExecuteNonQuery()
                                myConn3.Close()
                            Else

                                'je separe les CD4 des labo ici

                                item_number = "70 640 - RECETTE LABORATOIRE"
                                elementrow = dtelement.NewRow
                                elementrow("item_number") = item_number
                                elementrow("article") = article

                                elementrow("amount") = amount
                                dtelement.Rows.Add(elementrow)
                                dtelement.AcceptChanges()

                            End If




                        Catch ex As Exception
                            MsgBox(ex.ToString)
                            myConn3.Close()
                        End Try

                    End While
                    'End If
                    PrescReader2.Close()
                    Comd2.ExecuteNonQuery()
                    myConn2.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    myConn2.Close()
                End Try

            End While
            'End If
            PrescReader.Close()
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try




    End Sub

    Function pourcentage(ByVal encounter_nr As ULong) As Integer
        Dim percent As Integer = 0

        Try
            qry4 = "SELECT bonpercent FROM care_encounter WHERE encounter_nr=" & encounter_nr
            myConn4.Open()
            Comd4 = New MySqlCommand(qry4, myConn4)
            PrescReader4 = Comd4.ExecuteReader

            If PrescReader4.HasRows Then
                PrescReader4.Read()
                percent = CInt(PrescReader4.Item("bonpercent"))
            End If
            PrescReader4.Close()
            myConn4.Close()
        Catch ex As Exception
            PrescReader4.Close()
            MsgBox(ex.ToString)
            myConn4.Close()
        End Try

        Return percent

    End Function

    Function numconfig(ByVal encounter_nr As ULong) As Integer
        Dim percent As Integer = 0

        Try
            qry4 = "SELECT boncfg FROM care_encounter WHERE encounter_nr=" & encounter_nr
            myConn4.Open()
            Comd4 = New MySqlCommand(qry4, myConn4)
            PrescReader4 = Comd4.ExecuteReader

            If PrescReader4.HasRows Then
                PrescReader4.Read()
                percent = CInt(PrescReader4.Item("boncfg"))
            End If
            PrescReader4.Close()
            myConn4.Close()
        Catch ex As Exception
            PrescReader4.Close()
            MsgBox(ex.ToString)
            myConn4.Close()
        End Try

        Return percent

    End Function

    Function patientpaid(ByVal numfact As Integer) As Boolean
        Dim ispaid As Boolean = False
        Dim status As Integer = 0


        Try
            qry7 = "SELECT patientpaid FROM care_billing_credit WHERE billno=" & numfact
            myConn7.Open()
            Comd7 = New MySqlCommand(qry7, myConn7)
            PrescReader7 = Comd7.ExecuteReader

            If PrescReader7.HasRows Then
                PrescReader7.Read()
                status = CInt(PrescReader7.Item("patientpaid"))
            End If
            PrescReader7.Close()
            myConn7.Close()
        Catch ex As Exception
            PrescReader7.Close()
            MsgBox(ex.ToString)
            myConn7.Close()
        End Try

        If status = 1 Then
            ispaid = True
        End If

        Return ispaid
    End Function

    Function ispaidorpartial(ByVal numfact As Integer) As Boolean
        Dim resp As Boolean = False
        Dim status As String = "billed"

        Try
            qry7 = "SELECT status FROM care_billing_final WHERE bill_no=" & numfact
            myConn7.Open()
            Comd7 = New MySqlCommand(qry7, myConn7)
            PrescReader7 = Comd7.ExecuteReader

            If PrescReader7.HasRows Then
                PrescReader7.Read()
                status = PrescReader7.Item("status")
            End If
            PrescReader7.Close()
            myConn7.Close()
        Catch ex As Exception
            PrescReader7.Close()
            MsgBox(ex.ToString)
            myConn7.Close()
        End Try

        If status = "paid" Or status = "partial" Then
            resp = True
        End If

        Return resp

    End Function


    Function conversion_item_number(ByVal item_number As String) As String
        Dim nomgroupe As String = item_number


        If item_number = "MED" Or item_number = "SUP" Or item_number = "CAR" Then
            nomgroupe = "70 110 - RECETTE MEDICAMENTS"


        ElseIf item_number = "CON" Then
            nomgroupe = "70 610 - RECETTE CONSULTATIONS"

        ElseIf item_number = "ACC" Or item_number = "GYN" Or item_number = "MAT" Then
            nomgroupe = "70 620 - RECETTE GYNECO-OBSTETRIQUE"

        ElseIf item_number = "ORL" Or item_number = "ORT" Or item_number = "URO" Or item_number = "ANE" Or item_number = "CHP" Or item_number = "GAS" Or item_number = "GCH" Or item_number = "GEN" Or item_number = "PAA" Or item_number = "PAD" Or item_number = "PCH" Or item_number = "PEN" Or item_number = "PTR" Then
            nomgroupe = "70 630 - RECETTE CHIRURGIE"

        ElseIf item_number = "LAB" Then
            nomgroupe = "70 640 - RECETTE LABORATOIRE"

        ElseIf item_number = "ECO" Or item_number = "EEN" Then
            nomgroupe = "70 650 - RECETTE IMAGERIE"


        ElseIf item_number = "REA" Or item_number = "PED" Or item_number = "HMD" Or item_number = "CHI" Or item_number = "HCH" Or item_number = "CHIR" Or item_number = "ICU" Or item_number = "URG" Then
            nomgroupe = "70 660 -  RECETTE HOSPITALISATION"

        ElseIf item_number = "KIN" Then
            nomgroupe = "70 670 - RECETTE KINESITHERAPIE"

        ElseIf item_number = "SMI" Then
            nomgroupe = "70 675 - RECETTE SMI"

            '  Else

            '   nomgroupe = "70 681 - Autres"
        End If


        Return nomgroupe
    End Function

    Function init_table(ByVal dt As DataTable) As DataTable

        elementrow = dt.NewRow
        elementrow("item_number") = "70 110 - RECETTE MEDICAMENTS"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()


        elementrow = dt.NewRow
        elementrow("item_number") = "70 610 - RECETTE CONSULTATIONS"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        elementrow = dt.NewRow
        elementrow("item_number") = "70 620 - RECETTE GYNECO-OBSTETRIQUE"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        elementrow = dt.NewRow
        elementrow("item_number") = "70 630 - RECETTE CHIRURGIE"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()


        elementrow = dt.NewRow
        elementrow("item_number") = "70 640 - RECETTE LABORATOIRE"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        
        elementrow = dt.NewRow
        elementrow("item_number") = "70 650 - RECETTE IMAGERIE"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        

        elementrow = dt.NewRow
        elementrow("item_number") = "70 660 -  RECETTE HOSPITALISATION"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        

        elementrow = dt.NewRow
        elementrow("item_number") = "70 670 - RECETTE KINESITHERAPIE"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        elementrow = dt.NewRow
        elementrow("item_number") = "70 675 - RECETTE SMI"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()


        '      elementrow = dt.NewRow
        '     elementrow("item_number") = "70 681 - Autres"
        '    elementrow("article") = ""
        '    elementrow("amount") = 0
        '   dt.Rows.Add(elementrow)
        '  dt.AcceptChanges()

        Return dt
    End Function

    Private Sub listecredit()
        ltcredit.Reset()
        ltcredit.Columns.Add("typebon", Type.GetType("System.String"))
        ltcredit.Columns.Add("boncfg", Type.GetType("System.Byte"))
        ltcredit.Columns.Add("nom", Type.GetType("System.String"))
        ltcredit.Columns.Add("total", Type.GetType("System.Double"))
        ltcredit.Columns.Add("firmamount", Type.GetType("System.Double"))
        ltcredit.Columns.Add("patientamount", Type.GetType("System.Double"))
        ltcredit.Columns.Add("payementfirm", Type.GetType("System.Boolean"))
        ltcredit.Columns.Add("payementpatient", Type.GetType("System.Boolean"))


        Dim typebon, temp As String
        Dim total, partpatient, partfirm As Double
        Dim payementfirm, payementpatient As Boolean

        Try

            qry8 = "SELECT `receipt_no`,`encounter_nr`  FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "'  AND  '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "' AND `typepaiement`='bon'"

            If agentcaisse = "None" Then

            Else
                qry8 = qry8 & " AND  `care_billing_payment`.`encaisseur` ='" & agentcaisse & "'"
            End If


            myConn8.Open()
            Comd8 = New MySqlCommand(qry8, myConn8)
            'Get the encounter number
            PrescReader8 = Comd8.ExecuteReader
            If PrescReader8.HasRows Then
                While PrescReader8.Read()

                    billnum = PrescReader8.Item("receipt_no")
                    Encounter = PrescReader8.Item("encounter_nr")


                    'si le statut du bon n'est pas paye alors je continu
                    If iscreditpaid() = False Then

                        Try
                            qry9 = "SELECT `insurance_firm`, `boncfg` FROM `care_encounter` WHERE `encounter_nr`=" & Encounter '  AND  `bill_no`=" & billnum ' "'" 'AND `bill_number`=0"
                            myConn9.Open()
                            Comd9 = New MySqlCommand(qry9, myConn9)

                            PrescReader9 = Comd9.ExecuteReader
                            If PrescReader9.HasRows Then
                                While PrescReader9.Read()


                                    typebon = PrescReader9.Item("insurance_firm").ToString
                                    temp = typebon
                                    If typebon = "RETRAITE" Then
                                        typebon = "SOINS GRATUIT RETRAITE"
                                    ElseIf typebon = "CLERGE" Then
                                        typebon = "SOINS GRATUIT CLERGE"
                                    Else
                                        typebon = "CREDIT " & typebon
                                    End If

                                    BonCfg = PrescReader9.Item("boncfg")


                                    'recuperation de l'etat de la facture dans care_billing_credit

                                    Try
                                        qry10 = "SELECT `billamount`,`patientamount`,`firmamount`,`patientpaid`,`firmpaid` FROM `care_billing_credit` WHERE `encounter_nr`=" & Encounter & " AND  `billno`=" & billnum ' "'" 'AND `bill_number`=0"
                                        myConn10.Open()
                                        Comd10 = New MySqlCommand(qry10, myConn10)
                                        PrescReader10 = Comd10.ExecuteReader
                                        If PrescReader10.HasRows Then
                                            While PrescReader10.Read()
                                                total = CDbl(PrescReader10.Item("billamount"))
                                                partpatient = CDbl(PrescReader10.Item("patientamount"))
                                                partfirm = CDbl(PrescReader10.Item("firmamount"))
                                                payementfirm = CBool((PrescReader10.Item("firmpaid")))
                                                payementpatient = CBool(PrescReader10.Item("patientpaid"))

                                               

                                                'je recupere le id du patient

                                                Try
                                                    qry11 = "SELECT `pid`  FROM `care_encounter` WHERE `encounter_nr`=" & Encounter
                                                    myConn11.Open()
                                                    Comd11 = New MySqlCommand(qry11, myConn11)
                                                    PrescReader11 = Comd11.ExecuteReader
                                                    If PrescReader11.HasRows Then
                                                        While PrescReader11.Read()

                                                            Pid = CInt(PrescReader11.Item("pid"))

                                                            'je recupere le nom du patient
                                                            Try
                                                                qry12 = "SELECT `name_first`, `name_last` FROM `care_person` WHERE `pid`=" & Pid
                                                                myConn12.Open()
                                                                Comd12 = New MySqlCommand(qry12, myConn12)
                                                                PrescReader12 = Comd12.ExecuteReader
                                                                If PrescReader12.HasRows Then
                                                                    While PrescReader12.Read()

                                                                        nomprenom = PrescReader12.Item("name_last") & "  " & PrescReader12.Item("name_first")

                                                                        'jinserre la ligne

                                                                        elementrow = ltcredit.NewRow
                                                                        elementrow("typebon") = typebon
                                                                        elementrow("boncfg") = BonCfg
                                                                        elementrow("nom") = nomprenom.ToUpper
                                                                        elementrow("total") = total
                                                                        elementrow("firmamount") = partfirm
                                                                        elementrow("patientamount") = partpatient
                                                                        elementrow("payementfirm") = payementfirm
                                                                        elementrow("payementpatient") = payementpatient
                                                                        ltcredit.Rows.Add(elementrow)
                                                                        ltcredit.AcceptChanges()

                                                                        If payementpatient = False Then

                                                                            elementrow = ltcredit.NewRow
                                                                            elementrow("typebon") = "CREDIT " & temp
                                                                            elementrow("boncfg") = BonCfg
                                                                            elementrow("nom") = nomprenom.ToUpper
                                                                            elementrow("total") = total
                                                                            elementrow("firmamount") = partpatient
                                                                            elementrow("patientamount") = partpatient
                                                                            elementrow("payementfirm") = payementfirm
                                                                            elementrow("payementpatient") = payementpatient
                                                                            ltcredit.Rows.Add(elementrow)
                                                                            ltcredit.AcceptChanges()

                                                                        End If

                                                                    End While
                                                                End If
                                                                PrescReader12.Close()
                                                                Comd12.ExecuteNonQuery()
                                                                myConn12.Close()
                                                            Catch ex As Exception
                                                                MsgBox(ex.ToString)
                                                                myConn12.Close()
                                                            End Try

                                                        End While
                                                    End If
                                                    PrescReader11.Close()
                                                    Comd11.ExecuteNonQuery()
                                                    myConn11.Close()
                                                Catch ex As Exception
                                                    MsgBox(ex.ToString)
                                                    myConn11.Close()
                                                End Try


                                            End While

                                        End If
                                        PrescReader10.Close()
                                        Comd10.ExecuteNonQuery()
                                        myConn10.Close()
                                    Catch ex As Exception
                                        MsgBox(ex.ToString)
                                        myConn10.Close()
                                    End Try

                                End While
                            End If
                            PrescReader9.Close()
                            Comd9.ExecuteNonQuery()
                            myConn9.Close()
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                            myConn9.Close()
                        End Try

                    End If


                End While

            End If

            myConn8.Close()

        Catch ex As Exception
            myConn8.Close()
            MsgBox(ex.ToString)
        End Try


    End Sub

    Function iscreditpaid() As Boolean
        Dim ispaid As Boolean = False
        Dim status As String = "billed"

        Try
            qry6 = "SELECT `status` FROM  `care_billing_credit` WHERE `billno`=" & billnum
            myConn6.Open()
            Comd6 = New MySqlCommand(qry6, myConn6)
            PrescReader6 = Comd6.ExecuteReader
            If PrescReader6.HasRows Then
                PrescReader6.Read()
                status = PrescReader6.Item("status").ToString
            End If
            myConn6.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn6.Close()
        End Try

        If status = "paid" Then
            ispaid = True
        End If

        Return ispaid
    End Function


    Function liste_credit() As IList

        Dim result = (From orders In ltcredit.AsEnumerable
Group orders By typebon = orders.Field(Of String)("typebon") Into g = Group
Select New With {Key typebon,
 .Amount = g.Sum(Function(r) r.Field(Of Double)("firmamount"))
}).OrderBy(Function(tkey) tkey.typebon).ToList

        Return result

    End Function


End Class

