Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmImpressionFactureBon

    Dim myConn, myConn1 As New MySqlConnection
    Dim Comd, comd1 As MySqlCommand
    Dim PrescReader As MySqlDataReader
    Dim dtaDataTable As New DataTable
    Dim dtaAdapter As New MySqlDataAdapter
    Public qry2, qry3 As String
    Public Encounter As ULong
    Public testbill As String
    Public isbon As Boolean
    Dim newListRow As DataRow
    Private rpt As New facturesociete
    Public facturetotal As Integer
    Public factureclient As Integer
    Public facturesociete As Integer
    Public nom As String
    Public pid As ULong
    Public islab As Boolean
    Public ismed As Boolean






    Private Sub frmImpressionFactureBon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myConn.ConnectionString = frmMain.ServerString
        myConn1.ConnectionString = frmMain.ServerString

        'Encounter = ""


        affiche_element_complet()

        'DataGridView.DataSource = dtaDataTable

        affichercrystalreport()
    End Sub
    Private Sub affiche_element_complet()

        Try

            dtaDataTable.Reset()

            If ismed = True Then

                myConn.Open()

                ' qry = "SELECT `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=0 AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"
                Comd = New MySqlCommand(qry2, myConn)

                dtaAdapter.SelectCommand = Comd
                dtaAdapter.Fill(dtaDataTable)
                myConn.Close()

            End If

            If islab = True Then

                If ismed = False Then

                    dtaDataTable.Columns.Add("id", GetType(String))
                    dtaDataTable.Columns.Add("Date", GetType(Date))
                    dtaDataTable.Columns.Add("Article", GetType(String))
                    dtaDataTable.Columns.Add("Qte", GetType(Integer))
                    dtaDataTable.Columns.Add("Total", GetType(Double))
                    dtaDataTable.Columns.Add("Status", GetType(String))
                End If
                myConn1.Open()
                ' qry = "SELECT `article` as Article,`unit_cost` as Prix,`units` as Qte,`amount` as Total  FROM `care_billing_bill_item` WHERE `encounter_nr`=" & Encounter & "  AND  `islab`=1 AND `bill_no`=" & testbill & " ORDER BY  article" 'AND `bill_number`=0"
                comd1 = New MySqlCommand(qry3, myConn1)
                PrescReader = comd1.ExecuteReader
                If PrescReader.HasRows Then
                    While PrescReader.Read()
                        newListRow = dtaDataTable.NewRow
                        newListRow("id") = PrescReader.Item("id")
                        newListRow("Date") = PrescReader.Item("Date")
                        newListRow("Article") = PrescReader.Item("Article")
                        newListRow("Qte") = PrescReader.Item("Qte")
                        newListRow("Total") = PrescReader.Item("Total")
                        newListRow("Status") = PrescReader.Item("Status")
                        dtaDataTable.Rows.Add(newListRow)
                        dtaDataTable.AcceptChanges()
                        '
                    End While
                End If
                myConn1.Close()

            End If



        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
            myConn1.Close()
        End Try


    End Sub


    Public Function ConvNumberLetter(ByVal TheNo As Double, ByVal Langue As Byte) As String
        Dim dblEnt As Object, byDec As Byte
        Dim bNegatif As Boolean
        Dim strDev As String, strCentimes As String
        If TheNo = 0 Then
            ConvNumberLetter = "Zéro"
        Else
            If TheNo < 0 Then
                bNegatif = True
                TheNo = Math.Abs(TheNo)
            End If
            dblEnt = Int(TheNo)
            byDec = CInt((TheNo - dblEnt) * 100)
            If byDec = 0 Then
                If dblEnt > 999999999999999.0# Then
                    ConvNumberLetter = "#TropGrand"
                    Exit Function
                End If
            Else
                If dblEnt > 9999999999999.99 Then
                    ConvNumberLetter = "#TropGrand"
                    Exit Function
                End If
            End If
            strDev = " Franc"
            strCentimes = " Centime"
            If byDec = 1 Then strCentimes = strCentimes & "."
            If byDec > 1 Then strCentimes = strCentimes & "s."
            If dblEnt > 1 Then strDev = strDev & "s"
            If byDec <> 0 Then
                ConvNumberLetter = ConvNumEnt(CDbl(dblEnt), Langue) & strDev & " et " & _
                ConvNumDizaine(byDec, Langue) & strCentimes
            Else : ConvNumberLetter = ConvNumEnt(CDbl(dblEnt), Langue) & strDev & " CFA."
            End If
        End If
    End Function

    Private Function ConvNumEnt(ByVal TheNo As Double, ByVal Langue As Byte)
        Dim iTmp As Object, dblReste As Double
        Dim strTmp As String

        iTmp = TheNo - (Int(TheNo / 1000) * 1000)
        ConvNumEnt = ConvNumCent(CInt(iTmp), Langue)
        dblReste = Int(TheNo / 1000)
        iTmp = dblReste - (Int(dblReste / 1000) * 1000)
        strTmp = ConvNumCent(CInt(iTmp), Langue)
        Select Case iTmp
            Case 0
            Case 1
                strTmp = "Mille "
            Case Else
                strTmp = strTmp & " Mille "
        End Select
        ConvNumEnt = strTmp & ConvNumEnt
        dblReste = Int(dblReste / 1000)
        iTmp = dblReste - (Int(dblReste / 1000) * 1000)
        strTmp = ConvNumCent(CInt(iTmp), Langue)
        Select Case iTmp
            Case 0
            Case 1
                strTmp = strTmp & " Million "
            Case Else
                strTmp = strTmp & " Millions "
        End Select
        ConvNumEnt = strTmp & ConvNumEnt
        dblReste = Int(dblReste / 1000)
        iTmp = dblReste - (Int(dblReste / 1000) * 1000)
        strTmp = ConvNumCent(CInt(iTmp), Langue)
        Select Case iTmp
            Case 0
            Case 1
                strTmp = strTmp & " Milliard "
            Case Else
                strTmp = strTmp & " Milliards "
        End Select
        ConvNumEnt = strTmp & ConvNumEnt
        dblReste = Int(dblReste / 1000)
        iTmp = dblReste - (Int(dblReste / 1000) * 1000)
        strTmp = ConvNumCent(CInt(iTmp), Langue)
        Select Case iTmp
            Case 0
            Case 1
                strTmp = strTmp & " Billion "
            Case Else
                strTmp = strTmp & " Billions "
        End Select
        ConvNumEnt = strTmp & ConvNumEnt

    End Function

    Private Function ConvNumDizaine(ByVal TheNo As Byte, ByVal Langue As Byte) As String
        Dim TabUnit As Object, TabDiz As Object
        Dim byUnit As Byte, byDiz As Byte
        Dim strLiaison As String
        Dim array01() As String = {"", "Un", "Deux", "Trois", "Quatre", "Cinq", "Six", "Sept", _
            "Huit", "Neuf", "Dix", "Onze", "Douze", "Treize", "Quatorze", "Quinze", _
            "Seize", "Dix-sept", "Dix-huit", "Dix-neuf"}
        Dim array10() As String = {"", "", "Vingt", "Trente", "Quarante", "Cinquante", _
            "Soixante", "Soixante", "Quatre-vingt", "Quatre-vingt"}
        TabUnit = array01
        TabDiz = array10

        byDiz = Int(TheNo / 10)
        byUnit = TheNo - (byDiz * 10)
        strLiaison = "-"
        If byUnit = 1 Then strLiaison = " et "
        Select Case byDiz
            Case 0
                strLiaison = ""
            Case 1
                byUnit = byUnit + 10
                strLiaison = ""
            Case 7
                If Langue = 0 Then byUnit = byUnit + 10
            Case 8
                If Langue <> 2 Then strLiaison = "-"
            Case 9
                If Langue = 0 Then
                    byUnit = byUnit + 10
                    strLiaison = "-"
                End If
        End Select
        ConvNumDizaine = TabDiz(byDiz)
        If byDiz = 8 And Langue <> 2 And byUnit = 0 Then ConvNumDizaine = ConvNumDizaine & "s"
        If TabUnit(byUnit) <> "" Then
            ConvNumDizaine = ConvNumDizaine & strLiaison & TabUnit(byUnit)
        Else
            ConvNumDizaine = ConvNumDizaine
        End If
    End Function

    Private Function ConvNumCent(ByVal TheNo As Integer, ByVal Langue As Byte) As String
        Dim TabUnit As Object
        Dim byCent As Byte, byReste As Byte
        Dim strReste As String
        Dim arrray() As String = {"", "Un", "Deux", "Trois", "Quatre", "Cinq", "Six", "Sept", "Huit", "Neuf", "Dix"}
        TabUnit = arrray

        byCent = Int(TheNo / 100)
        byReste = TheNo - (byCent * 100)
        strReste = ConvNumDizaine(byReste, Langue)
        Select Case byCent
            Case 0
                ConvNumCent = strReste
            Case 1
                If byReste = 0 Then
                    ConvNumCent = "Cent"
                Else
                    ConvNumCent = "Cent " & strReste
                End If
            Case Else
                If byReste = 0 Then
                    ConvNumCent = TabUnit(byCent) & " Cent"
                Else
                    ConvNumCent = TabUnit(byCent) & " Cent " & strReste
                End If
        End Select
    End Function


    Private Sub affichercrystalreport()

        Dim ds As New DataSet1()


        'affectation de la bd
        rpt.SetDataSource(dtaDataTable)


        ' affectation des autres element constitutif de la facture
        rpt.SetParameterValue("facturetotal", facturetotal)
        rpt.SetParameterValue("facturesociete", facturesociete)
        rpt.SetParameterValue("factureclient", factureclient)
        rpt.SetParameterValue("nom", nom)
        rpt.SetParameterValue("pid", pid)
        If isbon = True Then
            rpt.SetParameterValue("montantenlettre", (ConvNumberLetter(CDbl(facturesociete), 0)))
        Else
            rpt.SetParameterValue("montantenlettre", (ConvNumberLetter(CDbl(factureclient), 0)))
        End If


        'rpt.PrintOptions.PaperSize.

        CrystalReportViewer.ReportSource = rpt

    End Sub

    Private Function status_payement(ByVal status As String) As String
        Dim result As String
        result = ""
        If status Like "billed" Then
            result = "Non payé"
        ElseIf status Like "partial" Then
            result = "Partiel"
        Else
            result = "Payé"
        End If

        Return result

    End Function

End Class