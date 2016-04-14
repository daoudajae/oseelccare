Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmRecapBonPriseEnCharges

    Dim myConn, myConn2, myConn3, myConn4, myConn5, myConn6, myConn7, myConn8, myConn9, myConn10, myConn11, myConn12 As New MySqlConnection
    Dim Comd, Comd2, Comd3, Comd4, Comd5, Comd6, Comd7, Comd8, Comd9, Comd10, Comd11, Comd12 As MySqlCommand
    Dim PrescReader, PrescReader2, PrescReader3, PrescReader4, PrescReader5, PrescReader6, PrescReader7, PrescReader8, PrescReader9, PrescReader10, PrescReader11, PrescReader12 As MySqlDataReader
    Dim qry, qry2, qry3, qry4, qry5, qry6, qry7, qry8, qry9, qry10, qry11, qry12, Enc_Date, Enc_type, Patient_Name, Patient_Birth As String
    Dim dtaAdapter As New MySqlDataAdapter
    Dim ltcredit, dtcredit As New DataTable
    Public datedebut As Date
    Public facturation As Boolean
    Public datefin As Date
    Public agentfacturation As String
    Public agentcaisse As String
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
    Dim BonCfg As Integer
    Dim newListRow, elementrow As DataRow

    Private Sub frmRecapBonPriseEnCharges_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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


        For i = 0 To societecredit.RowCount - 1
            r = dtlist.NewRow
            r("typebon") = societecredit.Rows(i).Cells(0).Value.ToString
            r("firmamount") = societecredit.Rows(i).Cells(1).Value.ToString
            dtlist.Rows.Add(r)

        Next

        Dim rptsociete As New listesocietecredit
        rptsociete.SetDataSource(dtlist)
        CrystalReportViewer.ReportSource = rptsociete

    End Sub

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
                ' qry8 = qry8 & " AND  `care_billing_payment`.`encaisseur` ='" & agentcaisse & "'"
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

    Function element_credit() As IList

        Dim result = (From orders In dtcredit.AsEnumerable
Group orders By typebon = orders.Field(Of String)("typebon") Into g = Group
Select New With {Key typebon,
 .Amount = g.Sum(Function(r) r.Field(Of Double)("reste"))
}).OrderBy(Function(tkey) tkey.typebon).ToList

        Return result

    End Function


End Class