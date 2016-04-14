Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Reflection



Public Class frmImpressionListeCredit

    Public DateDebut As Date
    Public DateFin As Date

    Dim dtcredit As New DataTable
    Dim myConn, myConn2, myConn3, myConn4, myConn5, myConn6 As New MySqlConnection
    Dim Comd, Comd2, Comd3, Comd4, Comd5, Comd6 As MySqlCommand
    Dim PrescReader, PrescReader2, PrescReader3, PrescReader4, PrescReader5, PrescReader6 As MySqlDataReader
    Dim TotalSelect As Integer
    Dim ConnMode As String
    Dim Encounter As ULong
    Dim billnum As String
    Dim totalbillamount As Double
    Dim totalreceiptamount As Double
    Dim amountdue As Double
    Dim user As String
    Dim testbill As String
    Dim agentdefacturation, agentcaisse As String
    Dim montantverse, montantversehors, creditfacture, creditfirm As Double
    Dim article, item_number As String
    Dim amount As Integer
    Dim nomprenom As String
    Dim Pid As Integer

    Dim totalfirm As Integer

    Dim qry, qry2, qry3, qry4, qry5, qry6, Enc_Date, Enc_type, Patient_Name, Patient_Birth As String
    Dim dtaAdapter As New MySqlDataAdapter
    Dim dtaDataTable As New DataTable
    Dim bindSource As New BindingSource

    Dim BonCfg As Integer
    Dim newListRow, elementrow As DataRow



    Private Sub frmImpressionListeCredit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myConn.ConnectionString = frmMain.ServerString
        myConn2.ConnectionString = frmMain.ServerString
        myConn3.ConnectionString = frmMain.ServerString
        myConn4.ConnectionString = frmMain.ServerString
        myConn5.ConnectionString = frmMain.ServerString
        myConn6.ConnectionString = frmMain.ServerString
        'MsgBox(DateDebut & " date  " & DateFin)
        credit()

        Dim liste As New listecreditspecialise

        liste.SetDataSource(dtcredit)

        CrystalReportViewer.ReportSource = liste

    End Sub

    Private Sub credit()
        dtcredit.Reset()
        dtcredit.Columns.Add("typebon", Type.GetType("System.String"))
        dtcredit.Columns.Add("boncfg", Type.GetType("System.Byte"))
        dtcredit.Columns.Add("nom", Type.GetType("System.String"))
        dtcredit.Columns.Add("total", Type.GetType("System.Double"))
        dtcredit.Columns.Add("firmamount", Type.GetType("System.Double"))
        dtcredit.Columns.Add("patientamount", Type.GetType("System.Double"))
        dtcredit.Columns.Add("payementfirm", Type.GetType("System.Boolean"))
        dtcredit.Columns.Add("payementpatient", Type.GetType("System.Boolean"))


        Dim typebon As String
        Dim total, partpatient, partfirm As Double
        Dim payementfirm, payementpatient As Boolean

        Try

            qry = "SELECT `receipt_no`,`encounter_nr`  FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & DateDebut.ToString("yyyy-MM-dd HH:mm:ss") & "'  AND  '" & DateFin.ToString("yyyy-MM-dd HH:mm:ss") & "' AND `typepaiement`='bon'"


            myConn.Open()
            Comd = New MySqlCommand(qry, myConn)
            'Get the encounter number
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                While PrescReader.Read()

                    billnum = PrescReader.Item("receipt_no")
                    Encounter = PrescReader.Item("encounter_nr")


                    'si le statut du bon n'est pas paye alors je continu
                    If iscreditpaid() = False Then

                        Try
                            qry2 = "SELECT `insurance_firm`, `boncfg` FROM `care_encounter` WHERE `encounter_nr`=" & Encounter '  AND  `bill_no`=" & billnum ' "'" 'AND `bill_number`=0"
                            myConn2.Open()
                            Comd2 = New MySqlCommand(qry2, myConn2)

                            PrescReader2 = Comd2.ExecuteReader
                            If PrescReader2.HasRows Then
                                While PrescReader2.Read()

                                    typebon = PrescReader2.Item("insurance_firm").ToString
                                    BonCfg = PrescReader2.Item("boncfg")


                                    'recuperation de l'etat de la facture dans care_billing_credit

                                    Try
                                        qry3 = "SELECT `billamount`,`patientamount`,`firmamount`,`patientpaid`,`firmpaid` FROM `care_billing_credit` WHERE `encounter_nr`=" & Encounter & " AND  `billno`=" & billnum ' "'" 'AND `bill_number`=0"
                                        myConn3.Open()
                                        Comd3 = New MySqlCommand(qry3, myConn3)
                                        PrescReader3 = Comd3.ExecuteReader
                                        If PrescReader3.HasRows Then
                                            While PrescReader3.Read()
                                                total = CDbl(PrescReader3.Item("billamount"))
                                                partpatient = CDbl(PrescReader3.Item("patientamount"))
                                                partfirm = CDbl(PrescReader3.Item("firmamount"))
                                                payementfirm = CBool((PrescReader3.Item("firmpaid")))
                                                payementpatient = CBool(PrescReader3.Item("patientpaid"))


                                                'je recupere le id du patient

                                                Try
                                                    qry4 = "SELECT `pid`  FROM `care_encounter` WHERE `encounter_nr`=" & Encounter
                                                    myConn4.Open()
                                                    Comd4 = New MySqlCommand(qry4, myConn4)
                                                    PrescReader4 = Comd4.ExecuteReader
                                                    If PrescReader4.HasRows Then
                                                        While PrescReader4.Read()

                                                            Pid = CInt(PrescReader4.Item("pid"))

                                                            'je recupere le nom du patient
                                                            Try
                                                                qry5 = "SELECT `name_first`, `name_last` FROM `care_person` WHERE `pid`=" & Pid
                                                                myConn5.Open()
                                                                Comd5 = New MySqlCommand(qry5, myConn5)
                                                                PrescReader5 = Comd5.ExecuteReader
                                                                If PrescReader5.HasRows Then
                                                                    While PrescReader5.Read()

                                                                        nomprenom = PrescReader5.Item("name_last") & "  " & PrescReader5.Item("name_first")

                                                                        'jinserre la ligne

                                                                        elementrow = dtcredit.NewRow
                                                                        elementrow("typebon") = typebon
                                                                        elementrow("boncfg") = BonCfg
                                                                        elementrow("nom") = nomprenom.ToUpper
                                                                        elementrow("total") = total
                                                                        elementrow("firmamount") = partfirm
                                                                        elementrow("patientamount") = partpatient
                                                                        elementrow("payementfirm") = payementfirm
                                                                        elementrow("payementpatient") = payementpatient
                                                                        dtcredit.Rows.Add(elementrow)
                                                                        dtcredit.AcceptChanges()


                                                                    End While
                                                                End If
                                                                PrescReader5.Close()
                                                                Comd5.ExecuteNonQuery()
                                                                myConn5.Close()
                                                            Catch ex As Exception
                                                                MsgBox(ex.ToString)
                                                                myConn5.Close()
                                                            End Try

                                                        End While
                                                    End If
                                                    PrescReader4.Close()
                                                    Comd4.ExecuteNonQuery()
                                                    myConn4.Close()
                                                Catch ex As Exception
                                                    MsgBox(ex.ToString)
                                                    myConn4.Close()
                                                End Try


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
                            PrescReader2.Close()
                            Comd2.ExecuteNonQuery()
                            myConn2.Close()
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                            myConn2.Close()
                        End Try

                    End If


                End While

            End If

            myConn.Close()

        Catch ex As Exception
            myConn.Close()
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

End Class