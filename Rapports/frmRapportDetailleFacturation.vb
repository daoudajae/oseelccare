Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Reflection


Public Class frmRapportDetailleFacturation
    Dim myConn, myConn2, myConn3 As New MySqlConnection
    Dim Comd, Comd2, Comd3 As MySqlCommand
    Dim PrescReader, PrescReader2, PrescReader3 As MySqlDataReader
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
    Dim totalfirm As Integer



    Dim qry, qry2, qry3, Enc_Date, Enc_type, Patient_Name, Patient_Birth As String
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

    Public Class produit

        Property item_number As String

        Property montant As Double

    End Class
    Private Sub frmRapportDetailleFacturation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        myConn.ConnectionString = frmMain.ServerString
        myConn2.ConnectionString = frmMain.ServerString
        myconn3.ConnectionString = frmMain.ServerString
        ' Me.Text = Me.Text & " - " & 

        element_detaille()
        total_global()
        'credit()

        DataGridView.DataSource = element_groupe()

        '  MsgBox(DataGridView.RowCount.ToString)

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

        '   MsgBox(dt.Rows.Count.ToString)

        ' lglobal.Text = totalbillamount.ToString
        ' lfacture.Text = totalreceiptamount.ToString
        ' lrecu.Text = montantverse.ToString
        ' lcredit.Text = amountdue.ToString


        Dim rpt As New detaillefacturation



        'affectation de la bd
        rpt.SetDataSource(dt)

        ' affectation des autres element constitutif de la facture
        rpt.SetParameterValue("total", totalbillamount)
        rpt.SetParameterValue("facture", totalreceiptamount)
        rpt.SetParameterValue("recette", montantverse + montantversehors)
        rpt.SetParameterValue("recu", montantverse)
        rpt.SetParameterValue("recuhors", montantversehors)
        rpt.SetParameterValue("credit", amountdue)
        rpt.SetParameterValue("creditfacture", creditfacture)
        rpt.SetParameterValue("creditfirm", totalfirm)
        rpt.SetParameterValue("datedebut", datedebut)
        rpt.SetParameterValue("datefin", datefin)
        rpt.SetParameterValue("agent", "AGENT DE FACTURATION: " & agentfacturation)

        CrystalReportViewer.ReportSource = rpt
       


    End Sub

    Function ConvertToDataTable(Of T)(ByVal list As IList) As DataTable
        Dim table As New DataTable()

        Dim fields() As FieldInfo = GetType(T).GetFields()
        For Each field As FieldInfo In fields
            table.Columns.Add(field.Name, field.FieldType)
        Next
        For Each item As T In list
            Dim row As DataRow = table.NewRow()
            For Each field As FieldInfo In fields
                row(field.Name) = field.GetValue(item)
            Next
            table.Rows.Add(row)
        Next
        Return table
    End Function


    Private Sub credit()
        dtcredit.Reset()
        dtcredit.Columns.Add("typebon", Type.GetType("System.String"))
        dtcredit.Columns.Add("reste", Type.GetType("System.Double"))

        Dim typebon As String
        Dim reste As Double


        Try

            '
            myConn.Open()
            If facturation Then
                qry = "SELECT `receipt_no`,`encounter_nr`  FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "'  AND  '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "' AND `typepaiement`='bon'"
            Else
                qry = "SELECT `receipt_no`,`encounter_nr` FROM `care_billing_payment` WHERE `datepaid` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "'  AND  '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "' AND `typepaiement`='bon'"
            End If

            If facturation = True And agentfacturation.ToString <> "None" Then
                MsgBox(agentfacturation.ToString & " Agent de facturation")
                qry = qry & " AND `factureur`='" & agentfacturation.ToString & "'"

            ElseIf facturation = False And agentcaisse.ToString <> "None" Then
                MsgBox(agentcaisse.ToString & "Agent de caisse")
                qry = qry & " AND `encaisseur`='" & agentcaisse.ToString & "'"
            End If

            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader

            If PrescReader.HasRows Then
                While PrescReader.Read()

                    billnum = PrescReader.Item("receipt_no")
                    Encounter = PrescReader.Item("encounter_nr")

                    'je vais a care_encounter pour avoir type bon

                    qry2 = "SELECT `insurance_firm`,`boncfg` FROM `care_encounter` WHERE `encounter_nr`=" & Encounter '  AND  `bill_no`=" & billnum ' "'" 'AND `bill_number`=0"
                    myConn2.Open()
                    Comd2 = New MySqlCommand(qry2, myConn2)
                    PrescReader2 = Comd2.ExecuteReader
                    If PrescReader2.HasRows Then
                        While PrescReader2.Read

                            typebon = PrescReader2.Item("insurance_firm")
                            BonCfg = PrescReader2.Item("boncfg")


                            'recuperation du reste de la facture dans care_billing final
                            qry3 = "SELECT `amount_due` FROM `care_billing_final` WHERE `encounter_nr`='" & Encounter & "'   AND  `bill_no`=" & billnum ' "'" 'AND `bill_number`=0"
                            myConn3.Open()
                            Comd3 = New MySqlCommand(qry3, myConn3)
                            PrescReader3 = Comd3.ExecuteReader
                            If PrescReader3.HasRows Then
                                While PrescReader3.Read

                                    reste = PrescReader3.Item("amount_due")

                                    'jajoute une ligne dans mon tableau
                                    elementrow = dtcredit.NewRow
                                    elementrow("typebon") = typebon
                                    elementrow("reste") = reste
                                    dtcredit.Rows.Add(elementrow)
                                    dtcredit.AcceptChanges()


                                End While
                            End If
                            PrescReader3.Close()
                            Comd3.ExecuteNonQuery()
                            myConn3.Close()

                        End While
                    End If
                    PrescReader2.Close()
                    Comd2.ExecuteNonQuery()
                    myConn2.Close()




                End While

            End If
            PrescReader.Close()
            myConn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub


    Private Sub total_global()

        Dim result As Integer = 0

        Try
            myConn.Open()

            qry = "SELECT `receipt_no`,`encounter_nr`  FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "'  AND  '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "' AND `typepaiement`='bon'"
            

            If facturation = True And agentfacturation.ToString <> "None" Then
                ' MsgBox(agentfacturation.ToString & " Agent de facturation")
                qry = qry & " AND `factureur`='" & agentfacturation.ToString & "'"
            End If
            If agentcaisse.ToString <> "None" Then

                ' MsgBox(agentfacturation.ToString & " Agent de facturation")
                qry = qry & " AND `encaisseur`='" & agentcaisse.ToString & "'"

            End If

            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader

            If PrescReader.HasRows Then
                While PrescReader.Read()

                    billnum = PrescReader.Item("receipt_no")
                    Encounter = PrescReader.Item("encounter_nr")

                    'recuperation des montant de payement des firm

                    Try
                        qry3 = "SELECT `firmamount`,`firmpaid` FROM `care_billing_credit` WHERE `encounter_nr`=" & Encounter & " AND  `billno`=" & billnum ' "'" 'AND `bill_number`=0"
                        myConn3.Open()
                        Comd3 = New MySqlCommand(qry3, myConn3)
                        PrescReader3 = Comd3.ExecuteReader
                        If PrescReader3.HasRows Then
                            While PrescReader3.Read()
                                If (PrescReader3.Item("firmpaid")) = 0 Then
                                    result = result + (PrescReader3.Item("firmamount"))
                                End If
                            End While

                        End If
                        PrescReader3.Close()
                        Comd3.ExecuteNonQuery()
                        myConn3.Close()
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                        myConn3.Close()
                    End Try

                End While

            End If
            PrescReader.Close()
            myConn.Close()

        Catch ex As Exception
            myConn.Close()
            MsgBox(ex.ToString)
        End Try

        totalfirm = result



        Try

            'je calculele le total receipt amount et montant recu pour facturation en periode
            myConn.Open()

            qry = "SELECT SUM(`paid`) as paid, SUM(`billtotal`) as topay FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "'  AND  '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "'" 'AND `bill_number`=0"

            If facturation = True And agentfacturation.ToString <> "None" Then
                ' MsgBox(agentfacturation.ToString & " Agent de facturation")
                qry = qry & " AND `factureur`='" & agentfacturation.ToString & "'"

            End If

            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader

            If PrescReader.HasRows Then
                PrescReader.Read()

                totalreceiptamount = CInt(PrescReader.Item("topay"))
                montantverse = CInt(PrescReader.Item("paid"))



            End If

            myConn.Close()

            
            'je calcule le montant recu hors facturation periode
            myConn.Open()
            
            qry = "SELECT SUM(`paid`) as paid FROM `care_billing_payment` WHERE `datepaid` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "'  AND  '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "'" 'AND `bill_number`=0"
            
            If facturation = True And agentfacturation.ToString <> "None" Then
                MsgBox(agentfacturation.ToString & " Agent de facturation")
                qry = qry & " AND `factureur`='" & agentfacturation.ToString & "'"
            End If

            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader

            If PrescReader.HasRows Then
                PrescReader.Read()

                montantversehors = CInt(PrescReader.Item("paid"))
                montantversehors = montantversehors - montantverse
            End If

            myConn.Close()

            creditfacture = totalreceiptamount - montantverse
            amountdue = creditfacture + totalfirm
            totalbillamount = totalreceiptamount + montantversehors + totalfirm



        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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
        dtelement.Reset()
        dtelement.Columns.Add("item_number", Type.GetType("System.String"))
        dtelement.Columns.Add("article", Type.GetType("System.String"))
        dtelement.Columns.Add("amount", Type.GetType("System.Double"))
        'dtelement.AcceptChanges()

        Try

            ' recuperation de encounter et bill number dans care_billing_payment
            If facturation Then
                qry = "SELECT `encounter_nr`,`receipt_no` FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "'  AND  '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "'" 'AND `bill_number`=0"
            Else
                qry = "SELECT `encounter_nr`,`receipt_no` FROM `care_billing_payment` WHERE `datepaid` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "'  AND  '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "'" 'AND `bill_number`=0"
            End If

            If agentfacturation.ToString <> "None" Then
                MsgBox(agentfacturation.ToString & " Agent de facturation")
                qry = qry & " AND `factureur`='" & agentfacturation.ToString & "'"

            ElseIf agentcaisse.ToString <> "None" Then
                MsgBox(agentcaisse.ToString & "Agent de caisse")
                qry = qry & " AND `encaisseur`='" & agentcaisse.ToString & "'"
            End If

            myConn.Open()
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                While PrescReader.Read()

                    Encounter = PrescReader.Item("encounter_nr")
                    billnum = PrescReader.Item("receipt_no")

                    Try
                        'recuperations de article et amount dans care_billing_bill_item
                        qry2 = "SELECT `article`,`amount`,`islab` FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `bill_no`=" & billnum & " AND `status`<>'billed'"
                        myConn2.Open()
                        Comd2 = New MySqlCommand(qry2, myConn2)
                        PrescReader2 = Comd2.ExecuteReader
                        If PrescReader2.HasRows Then
                            While PrescReader2.Read

                                article = PrescReader2.Item("article")
                                amount = PrescReader2.Item("amount")
                                islab = CInt(PrescReader2.Item("islab"))

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

                                            ElseIf item_number = "70 651 - RECETTE ECHOGRAPHIE" Then

                                                elementrow = dtelement.NewRow
                                                elementrow("item_number") = "70 651 - RECETTE ECHOGRAPHIE"
                                                elementrow("article") = article
                                                elementrow("amount") = amount
                                                dtelement.Rows.Add(elementrow)
                                                dtelement.AcceptChanges()
                                            Else


                                                'jajoute une ligne dans mon tableau
                                                elementrow = dtelement.NewRow
                                                elementrow("item_number") = "70 650 - RECETTE RADIOLOGIE"
                                                elementrow("article") = article
                                                elementrow("amount") = amount
                                                dtelement.Rows.Add(elementrow)
                                                dtelement.AcceptChanges()
                                            End If
                                            'jajoute une ligne dans mon tableau
                                            


                                            ' End While
                                        End If
                                        PrescReader3.Close()
                                        Comd3.ExecuteNonQuery()
                                        myConn3.Close()
                                    Else

                                        item_number = "70 640 - RECETTE LABORATOIRE"

                                        'jajoute une ligne dans mon tableau
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
                        End If
                        PrescReader2.Close()
                        Comd2.ExecuteNonQuery()
                        myConn2.Close()
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                        myConn2.Close()
                    End Try

                End While
            End If
            PrescReader.Close()
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try

    End Sub

    Function conversion_compte(ByVal compte As String) As String



        Return (compte)
    End Function
    Function conversion_item_number(ByVal item_number As String) As String
        Dim nomgroupe As String = item_number


        If item_number = "MED" Or item_number = "SUP" Then
            nomgroupe = "70 110 - RECETTE MEDICAMENTS"

        ElseIf item_number = "CAR" Then
            nomgroupe = "70 120 - RECETTE CARNET MEDICAL ET DOSSIER"

        ElseIf item_number = "CON" Then
            nomgroupe = "70 610 - RECETTE CONSULTATIONS"

        ElseIf item_number = "ACC" Then
            nomgroupe = "70 620 - RECETTE MATERNITES - ACCOUCHEMENTS"

        ElseIf item_number = "CHP" Or item_number = "EEN" Or item_number = "GAS" Or item_number = "GCH" Or item_number = "GEN" Or item_number = "GYN" Or item_number = "PAA" Or item_number = "PAD" Or item_number = "PCH" Or item_number = "PEN" Or item_number = "PTR" Then
            nomgroupe = "70 630 - RECETTE ACTES CHIRURGIE ET AUTRES"

        ElseIf item_number = "ANE" Then
            nomgroupe = "70 631 - RECETTE ANESTHESIE"

        ElseIf item_number = "URO" Then
            nomgroupe = "70 632 - RECETTE ACTES CHIRURGIE UROLOGIE"

        ElseIf item_number = "ORT" Then
            nomgroupe = "70 633 - RECETTE ACTES CHIRURGIE TRAUMATOLOGIE"

        ElseIf item_number = "LAB" Then
            nomgroupe = "70 640 - RECETTE LABORATOIRE"

        ElseIf item_number = "ECO" Then
            nomgroupe = "70 651 - RECETTE ECHOGRAPHIE"

        ElseIf item_number = "URG" Then
            nomgroupe = "70 661 - RECETTES URGENCES"

        ElseIf item_number = "MAT" Then
            nomgroupe = "70 622 - RECETTE HOSPITALISATION MATERNITES"

        ElseIf item_number = "PED" Then
            nomgroupe = "70 663 -  RECETTE HOSPITALISATION PEDIATRIE"

        ElseIf item_number = "HMD" Then
            nomgroupe = "70 664 - RECETTE HOSPITALISATION  MEDECINE"

        ElseIf item_number = "CHI" Or item_number = "HCH" Then
            nomgroupe = "70 665 - RECETTE  HOSPITALISATION CHIRURGIE"

        ElseIf item_number = "ICU" Or item_number = "REA" Then
            nomgroupe = "70 666 - RECETTE HOSPITALISATION REANIMATION"

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

End Class