Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmImpressionEtatAnnuel
    Public annee As String
    Public datedebut As Date
    Public datefin As Date
    Public agentfacturation As String
    Public agentcaisse As String
    Public dt As New DataTable
    Public bindingrecherche As BindingSource
    Dim myConn As New MySqlConnection
    Dim Comd As MySqlCommand
    Dim PrescReader As MySqlDataReader
    Dim dtaAdapter As New MySqlDataAdapter
    Dim qry As String

    Private Sub frmImpressionEtatAnnuel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'recuperation des elements de la table care_billing_payment
        'format de la date "yyyy-MM-dd HH:mm:ss"
        myConn.ConnectionString = frmMain.ServerString

        Dim totalf, totalc As Integer
        totalc = 0
        totalf = 0

        Dim madatedebut, madatefin As String
        Dim janf, janc, fevf, fevc, mrsf, mrsc, avlf, avlc, maif, maic, junf, junc, julf, julc, aotf, aotc, sepf, sepc, octf, octc, novf, novc, decf, decc As Integer
        janf = 0
        janc = 0
        fevc = 0
        fevf = 0
        mrsc = 0
        mrsf = 0
        avlc = 0
        avlf = 0
        maic = 0
        maif = 0
        junc = 0
        junf = 0
        julc = 0
        julf = 0
        aotc = 0
        aotf = 0
        sepc = 0
        sepf = 0
        octc = 0
        octf = 0
        novc = 0
        novf = 0
        decc = 0
        decf = 0

        'janvier
        madatedebut = Nothing
        madatefin = Nothing
        madatedebut = annee.ToString & "-01-01 00:00:00"
        madatefin = annee.ToString & "-01-31 23:59:59"


        Try
            myConn.Open()
            qry = "SELECT `datebilled`,SUM(`paid`) as paye,SUM(`billtotal`) as apaye  FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & madatedebut & "'  AND  '" & madatefin & "'" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                PrescReader.Read()

                janf = PrescReader.Item("apaye")
                janc = (PrescReader.Item("paye"))


            End If
            Comd.ExecuteNonQuery()
            myConn.Close()

        Catch ex As Exception
            ' MsgBox(ex.ToString)
            myConn.Close()
        End Try

        'fevrier
        madatedebut = Nothing
        madatefin = Nothing
        madatedebut = annee.ToString & "-02-01 00:00:00"
        madatefin = annee.ToString & "-02-31 23:59:59"


        Try
            myConn.Open()
            qry = "SELECT `datebilled`,SUM(`paid`) as paye,SUM(`billtotal`) as apaye  FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & madatedebut & "'  AND  '" & madatefin & "'" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                
                PrescReader.Read()

                fevf = (PrescReader.Item("apaye"))
                fevc = (PrescReader.Item("paye"))


            End If
            Comd.ExecuteNonQuery()
            myConn.Close()

        Catch ex As Exception
            ' MsgBox(ex.ToString)
            myConn.Close()
        End Try

        'mars
        madatedebut = Nothing
        madatefin = Nothing
        madatedebut = annee.ToString & "-03-01 00:00:00"
        madatefin = annee.ToString & "-03-31 23:59:59"


        Try
            myConn.Open()
            qry = "SELECT `datebilled`,SUM(`paid`) as paye,SUM(`billtotal`) as apaye  FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & madatedebut & "'  AND  '" & madatefin & "'" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                
                PrescReader.Read()

                mrsf = (PrescReader.Item("apaye"))
                mrsc = (PrescReader.Item("paye"))


            End If
            Comd.ExecuteNonQuery()
            myConn.Close()

        Catch ex As Exception
            'MsgBox(ex.ToString)
            myConn.Close()
        End Try

        'avril
        madatedebut = Nothing
        madatefin = Nothing
        madatedebut = annee.ToString & "-04-01 00:00:00"
        madatefin = annee.ToString & "-04-31 23:59:59"


        Try
            myConn.Open()
            qry = "SELECT `datebilled`,SUM(`paid`) as paye,SUM(`billtotal`) as apaye  FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & madatedebut & "'  AND  '" & madatefin & "'" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                
                PrescReader.Read()

                avlf = (PrescReader.Item("apaye"))
                avlc = (PrescReader.Item("paye"))


            End If
            Comd.ExecuteNonQuery()
            myConn.Close()

        Catch ex As Exception
            'MsgBox(ex.ToString)
            myConn.Close()
        End Try

        'mai
        madatedebut = Nothing
        madatefin = Nothing
        madatedebut = annee.ToString & "-05-01 00:00:00"
        madatefin = annee.ToString & "-05-31 23:59:59"


        Try
            myConn.Open()
            qry = "SELECT `datebilled`,SUM(`paid`) as paye,SUM(`billtotal`) as apaye  FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & madatedebut & "'  AND  '" & madatefin & "'" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                PrescReader.Read()

                maif = (PrescReader.Item("apaye"))
                maic = (PrescReader.Item("paye"))


            End If
            Comd.ExecuteNonQuery()
            myConn.Close()

        Catch ex As Exception
            ' MsgBox(ex.ToString)
            myConn.Close()
        End Try

        'juin
        madatedebut = Nothing
        madatefin = Nothing
        madatedebut = annee.ToString & "-06-01 00:00:00"
        madatefin = annee.ToString & "-06-31 23:59:59"


        Try
            myConn.Open()
            qry = "SELECT `datebilled`,SUM(`paid`) as paye,SUM(`billtotal`) as apaye  FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & madatedebut & "'  AND  '" & madatefin & "'" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                PrescReader.Read()

                junf = (PrescReader.Item("apaye"))
                junc = (PrescReader.Item("paye"))


            End If
            Comd.ExecuteNonQuery()
            myConn.Close()

        Catch ex As Exception
            ' MsgBox(ex.ToString)
            myConn.Close()
        End Try

        'juillet
        madatedebut = Nothing
        madatefin = Nothing
        madatedebut = annee.ToString & "-07-01 00:00:00"
        madatefin = annee.ToString & "-07-31 23:59:59"


        Try
            myConn.Open()
            qry = "SELECT `datebilled`,SUM(`paid`) as paye,SUM(`billtotal`) as apaye  FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & madatedebut & "'  AND  '" & madatefin & "'" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                PrescReader.Read()

                julf = (PrescReader.Item("apaye"))
                julc = (PrescReader.Item("paye"))


            End If
            Comd.ExecuteNonQuery()
            myConn.Close()

        Catch ex As Exception
            'MsgBox(ex.ToString)
            myConn.Close()
        End Try

        'aout
        madatedebut = Nothing
        madatefin = Nothing
        madatedebut = annee.ToString & "-08-01 00:00:00"
        madatefin = annee.ToString & "-08-31 23:59:59"


        Try
            myConn.Open()
            qry = "SELECT `datebilled`,SUM(`paid`) as paye,SUM(`billtotal`) as apaye  FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & madatedebut & "'  AND  '" & madatefin & "'" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                PrescReader.Read()

                aotf = (PrescReader.Item("apaye"))
                aotc = (PrescReader.Item("paye"))


            End If
            Comd.ExecuteNonQuery()
            myConn.Close()

        Catch ex As Exception
            'MsgBox(ex.ToString)
            myConn.Close()
        End Try


        'septembre
        madatedebut = Nothing
        madatefin = Nothing
        madatedebut = annee.ToString & "-09-01 00:00:00"
        madatefin = annee.ToString & "-09-31 23:59:59"


        Try
            myConn.Open()
            qry = "SELECT `datebilled`,SUM(`paid`) as paye,SUM(`billtotal`) as apaye  FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & madatedebut & "'  AND  '" & madatefin & "'" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                PrescReader.Read()

                sepf = (PrescReader.Item("apaye"))
                sepc = (PrescReader.Item("paye"))


            End If
            Comd.ExecuteNonQuery()
            myConn.Close()

        Catch ex As Exception
            ' MsgBox(ex.ToString)
            myConn.Close()
        End Try

        'octobre
        madatedebut = Nothing
        madatefin = Nothing
        madatedebut = annee.ToString & "-10-01 00:00:00"
        madatefin = annee.ToString & "-10-31 23:59:59"


        Try
            myConn.Open()
            qry = "SELECT `datebilled`,SUM(`paid`) as paye,SUM(`billtotal`) as apaye  FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & madatedebut & "'  AND  '" & madatefin & "'" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                PrescReader.Read()

                octf = (PrescReader.Item("apaye"))
                octc = (PrescReader.Item("paye"))
            
            End If
            Comd.ExecuteNonQuery()
            myConn.Close()

        Catch ex As Exception
            ' MsgBox(ex.ToString)
            myConn.Close()
        End Try

        'novembre
        madatedebut = Nothing
        madatefin = Nothing
        madatedebut = annee.ToString & "-11-01 00:00:00"
        madatefin = annee.ToString & "-11-31 23:59:59"


        Try
            myConn.Open()
            qry = "SELECT `datebilled`,SUM(`paid`) as paye,SUM(`billtotal`) as apaye  FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & madatedebut & "'  AND  '" & madatefin & "'" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                PrescReader.Read()

                novf = (PrescReader.Item("apaye"))
                novc = (PrescReader.Item("paye"))


            End If
            Comd.ExecuteNonQuery()
            myConn.Close()

        Catch ex As Exception
            'MsgBox(ex.ToString)
            myConn.Close()
        End Try

        'decembre
        madatedebut = Nothing
        madatefin = Nothing
        madatedebut = annee.ToString & "-12-01 00:00:00"
        madatefin = annee.ToString & "-12-31 23:59:59"


        Try
            myConn.Open()
            qry = "SELECT `datebilled`,SUM(`paid`) as paye,SUM(`billtotal`) as apaye  FROM `care_billing_payment` WHERE `datebilled` BETWEEN '" & madatedebut & "'  AND  '" & madatefin & "'" 'AND `bill_number`=0"
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                PrescReader.Read()

                decf = (PrescReader.Item("apaye"))
                decc = (PrescReader.Item("paye"))


            End If
            Comd.ExecuteNonQuery()
            myConn.Close()

        Catch ex As Exception
            ' MsgBox(ex.ToString)
            myConn.Close()
        End Try

        totalf = janf + fevf + mrsf + avlf + maif + junf + julf + aotf + sepf + octf + novf + decf
        totalc = janc + fevc + mrsc + avlc + maic + junc + julc + aotc + sepc + octc + novc + decc
        'definition du crystal report et de ses parametres
        Dim rp As New etatannuel


        'affectation des parametre au crystal
        rp.SetParameterValue("anne", annee.ToString)

        rp.SetParameterValue("janf", janf)
        rp.SetParameterValue("fevf", fevf)
        rp.SetParameterValue("mrsf", mrsf)
        rp.SetParameterValue("avlf", avlf)
        rp.SetParameterValue("maif", maif)
        rp.SetParameterValue("junf", junf)
        rp.SetParameterValue("julf", julf)
        rp.SetParameterValue("aotf", aotf)
        rp.SetParameterValue("sepf", sepf)
        rp.SetParameterValue("octf", octf)
        rp.SetParameterValue("novf", novf)
        rp.SetParameterValue("decf", decf)
        rp.SetParameterValue("janc", janc)
        rp.SetParameterValue("fevc", fevc)
        rp.SetParameterValue("mrsc", mrsc)
        rp.SetParameterValue("avlc", avlc)
        rp.SetParameterValue("maic", maic)
        rp.SetParameterValue("junc", junc)
        rp.SetParameterValue("julc", julc)
        rp.SetParameterValue("aotc", aotc)
        rp.SetParameterValue("sepc", sepc)
        rp.SetParameterValue("octc", octc)
        rp.SetParameterValue("novc", novc)
        rp.SetParameterValue("decc", decc)

        rp.SetParameterValue("totalf", totalf)
        rp.SetParameterValue("totalc", totalc)


        CrystalReportViewer.ReportSource = rp


    End Sub
End Class