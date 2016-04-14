Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmRapportDetailleCategorie

    Dim myConn, myConn2, myConn3, myConn4, myConn5, myConn6, myConn7 As New MySqlConnection
    Dim Comd, Comd2, Comd3, Comd4, Comd5, Comd6, Comd7 As MySqlCommand
    Dim PrescReader, PrescReader2, PrescReader3, PrescReader4, PrescReader5, PrescReader6, PrescReader7 As MySqlDataReader
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
    Dim montantverse, montantversehors, creditfacture, creditfirm As Double
    Dim article, item_number As String
    Dim amount As Integer
    Dim nomprenom As String
    Dim Pid As Integer

    Dim totalfirm As Integer

    Dim qry, qry2, qry3, qry4, qry5, qry6, qry7, Enc_Date, Enc_type, Patient_Name, Patient_Birth As String
    Dim dtaAdapter As New MySqlDataAdapter
    Dim dtaDataTable As New DataTable
    Dim bindSource As New BindingSource

    Dim BonCfg As Integer
    Dim newListRow, elementrow As DataRow

    Dim dtelement, dtelementgroupe, dtcredit, dtdetaillepersonnel, dtdetailleclerge As New DataTable
    Public datedebut As Date
    Public facturation As Boolean
    Public datefin As Date
    Public agentfacturation As String
    Public agentcaisse As String
    Public rubrique As String




    Private Sub frmRapportDetailleCategorie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        myConn.ConnectionString = frmMain.ServerString
        myConn2.ConnectionString = frmMain.ServerString
        myConn3.ConnectionString = frmMain.ServerString
        myConn4.ConnectionString = frmMain.ServerString
        myConn5.ConnectionString = frmMain.ServerString
        myConn6.ConnectionString = frmMain.ServerString
        myConn7.ConnectionString = frmMain.ServerString


        element_detaille()

        DataGridView.DataSource = element_groupe()

        Dim dt As New DataTable
        Dim r As DataRow
        dt.Columns.Add("Item_Number", Type.GetType("System.String"))
        dt.Columns.Add("Montant", Type.GetType("System.Double"))


        For i = 0 To DataGridView.RowCount - 1
            r = dt.NewRow
            r("Item_Number") = DataGridView.Rows(i).Cells(0).Value.ToString
            r("Montant") = DataGridView.Rows(i).Cells(1).Value.ToString
            dt.Rows.Add(r)

        Next

        'crystal repport
        Dim rpt As New etatdetaillerubrique

        rpt.SetDataSource(dt)
        rpt.SetParameterValue("rubrique", rubrique)
        rpt.SetParameterValue("datedebut", datedebut)
        rpt.SetParameterValue("datefin", datefin)
        CrystalReportViewer.ReportSource = rpt

    End Sub


    'fonctions

    Private Sub element_detaille()
        Dim islab As Integer = 0
        Dim purchassing_class As String
        Dim typepaiement As String
        Dim bonpercent, bonconfig As Integer
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

            qry = "SELECT `encounter_nr`,`receipt_no`, `typepaiement` FROM `care_billing_payment` WHERE  (CASE WHEN `typepaiement`='normal' THEN  `datepaid` WHEN `typepaiement`='bon' THEN  `datebilled` END) BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "'  AND  '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "'" 'AND `bill_number`=0"

            If agentcaisse <> "None" Then

                qry = qry & "   AND `encaisseur`=" & "'" & agentcaisse & "'"
            End If

            myConn.Open()
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            ' If PrescReader.HasRows Then
            While PrescReader.Read()

                Encounter = PrescReader.Item("encounter_nr")
                nfact = PrescReader.Item("receipt_no")
                typepaiement = PrescReader.Item("typepaiement")

                ' je doit recuperer le encouter typ ici

                If typepaiement Like "bon" Then
                    bonpercent = CInt(pourcentage(Encounter))
                    bonconfig = CInt(numconfig(Encounter))
                End If


                Try
                    'recuperations de article et amount dans care_billing_bill_item
                    qry2 = "SELECT `article`,`amount`,`islab` FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `bill_no`=" & nfact ' "'" 'AND `bill_number`=0"
                    myConn2.Open()
                    Comd2 = New MySqlCommand(qry2, myConn2)
                    PrescReader2 = Comd2.ExecuteReader
                    'If PrescReader2.HasRows Then
                    While PrescReader2.Read

                        article = PrescReader2.Item("article")
                        amount = PrescReader2.Item("amount")
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


                                        If item_number Like rubrique Then
                                            dtelement.Rows.Add(elementrow)
                                            dtelement.AcceptChanges()
                                        End If


                                ElseIf item_number = "70 650 - RECETTE IMAGERIE" Then

                                    elementrow = dtelement.NewRow
                                    elementrow("item_number") = "70 650 - RECETTE IMAGERIE"
                                    elementrow("article") = article
                                        elementrow("amount") = amount


                                        If item_number Like rubrique Then
                                            dtelement.Rows.Add(elementrow)
                                            dtelement.AcceptChanges()
                                        End If
                                    Else


                                        'jajoute une ligne dans mon tableau
                                        If item_number Like "X44" Or item_number Like "X45" Or item_number Like "X43" Or item_number Like "EEN" Then

                                            elementrow = dtelement.NewRow
                                            elementrow("item_number") = "70 650 - RECETTE IMAGERIE"
                                            elementrow("article") = article
                                            elementrow("amount") = amount

                                                
                                                elementrow("amount") = amount

                                            If item_number Like rubrique Then
                                                dtelement.Rows.Add(elementrow)
                                                dtelement.AcceptChanges()
                                            End If
                                        Else

                                            elementrow = dtelement.NewRow
                                            elementrow("item_number") = "70 650 - RECETTE IMAGERIE"
                                            elementrow("article") = article
                                            
                                                elementrow("amount") = amount

                                            If item_number Like rubrique Then
                                                dtelement.Rows.Add(elementrow)
                                                dtelement.AcceptChanges()
                                            End If
                                        End If

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

                            'jajoute une ligne dans mon tableau
                            elementrow = dtelement.NewRow
                            elementrow("item_number") = item_number
                            elementrow("article") = article
                            
                                elementrow("amount") = amount

                                If item_number Like rubrique Then
                                    dtelement.Rows.Add(elementrow)
                                    dtelement.AcceptChanges()
                                End If

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
        '  MsgBox(elelment & " Elements")
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

        ElseIf item_number = "ORT" Or item_number = "URO" Or item_number = "ANE" Or item_number = "CHP" Or item_number = "GAS" Or item_number = "GCH" Or item_number = "GEN" Or item_number = "PAA" Or item_number = "PAD" Or item_number = "PCH" Or item_number = "PEN" Or item_number = "PTR" Then
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

        ElseIf item_number = "ORL" Then
            nomgroupe = "70 680 - RECETTE ORL"

        Else
            nomgroupe = item_number
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

        elementrow = dt.NewRow
        elementrow("item_number") = "70 680 - RECETTE ORL"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()


        Return dt
    End Function

    Function element_groupe() As IList

        Dim result = (From orders In dtelement.AsEnumerable
Group orders By ItemNumber = orders.Field(Of String)("article") Into g = Group
Select New With {Key ItemNumber,
 .Amount = g.Sum(Function(r) r.Field(Of Double)("amount"))
}).OrderBy(Function(tkey) tkey.ItemNumber).ToList

        Return result

    End Function

End Class