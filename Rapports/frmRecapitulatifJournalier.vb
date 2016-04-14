Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmRecapitulatifJournalier
    Public datedujour As Date
    Dim datetemoins As String
    Dim datedebut As Date
    Dim datefin As Date
    Dim dtelement As New DataTable
    Dim article, item_number As String
    Dim myConn, myConn2, myConn3, myConn4, myConn5, myConn6 As New MySqlConnection
    Dim Comd, Comd2, Comd3, Comd4, Comd5, Comd6 As MySqlCommand
    Dim PrescReader, PrescReader2, PrescReader3, PrescReader4, PrescReader5, PrescReader6 As MySqlDataReader
    Dim qry, qry2, qry3, qry4, qry5, qry6, Enc_Date, Enc_type, Patient_Name, Patient_Birth As String
    Dim billnum, pourcentage, numconfig, amount As Integer
    Dim Encounter As ULong
    Dim newListRow, elementrow As DataRow
    Dim magrille As New DataGridView


    Private Sub frmRecapitulatifJournalier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myConn.ConnectionString = frmMain.ServerString


        datedebut = Format(datedujour, "yyyy-MM-dd") & " 00:00:00"
        datefin = Format(datedujour, "yyyy-MM-dd") & " 23:59:59"

        Label1.Text = Format(datedebut, "yyyy-MM-dd HH:mm:ss") & "   " & Format(datefin, "yyyy-MM-dd HH:mm:ss")

        'je cree la premiere colonne
        addcol("RUBRIQUE")
        'jajoute les premieres lignes
        initgrid()

        Dim dt As New DataTable
        dt = TryCast(magrille.DataSource, DataTable)


        'j'associe le datagrid virtuel a cluit que j'ai sur la feuille
        'question de voir à quoi ca resemble
        DataGridView1.DataSource = dt
       

    End Sub


    Private Sub element_detaille()
        Dim islab As Integer = 0
        Dim purchassing_class As String
        Dim typepaiement As String
        'Dim bonpercent, bonconfig As Integer
        Dim elelment As Integer = 0
        Dim nfact As Integer
        'Dim encouter_type As String


        dtelement.Reset()
        dtelement.Columns.Add("item_number", Type.GetType("System.String"))
        dtelement.Columns.Add("article", Type.GetType("System.String"))
        dtelement.Columns.Add("amount", Type.GetType("System.Double"))
        'dtelement.AcceptChanges()

        ' dtelement = init_table(dtelement)

        Try

            ' recuperation de encounter et bill number dans care_billing_payment

            qry = "SELECT `encounter_nr`,`receipt_no`, `typepaiement` FROM `care_billing_payment` WHERE `datepaid` BETWEEN '" & datedebut.ToString("yyyy-MM-dd HH:mm:ss") & "'  AND  '" & datefin.ToString("yyyy-MM-dd HH:mm:ss") & "'" 'AND `bill_number`=0"


            myConn.Open()
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            ' If PrescReader.HasRows Then
            While PrescReader.Read()

                Encounter = PrescReader.Item("encounter_nr")
                nfact = PrescReader.Item("receipt_no")
                typepaiement = PrescReader.Item("typepaiement")

                'je ne prend que les bons de prise en charge

                If typepaiement Like "bon" Then

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
                                            'medicament et les autres actes et services

                                        ElseIf item_number = "ECHOGRAPHIE" Then
                                            'echographie
                                            
                                        Else
                                            'radiologie


                                            
                                        End If
                                       
                                    End If
                                    PrescReader3.Close()
                                    Comd3.ExecuteNonQuery()
                                    myConn3.Close()
                                Else

                                    'les lboratoires                                    
                                    item_number = "LABORATOIRE"


                                        


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
                End If

                
                'si c'est un bon
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

    Function conversion_item_number(ByVal item_number As String) As String
        Dim nomgroupe As String = item_number


        If item_number = "MED" Or item_number = "SUP" Then
            nomgroupe = "MEDICAMENTS"

        ElseIf item_number = "CAR" Then
            nomgroupe = "CARNET MEDICAL ET DOSSIER"

        ElseIf item_number = "CON" Then
            nomgroupe = "CONSULTATIONS"

        ElseIf item_number = "ACC" Or item_number = "GYN" Then
            nomgroupe = "MATERNITES - ACCOUCHEMENTS"

        ElseIf item_number = "CHP" Or item_number = "EEN" Or item_number = "GAS" Or item_number = "GCH" Or item_number = "GEN" Or item_number = "PAA" Or item_number = "PAD" Or item_number = "PCH" Or item_number = "PEN" Or item_number = "PTR" Then
            nomgroupe = "CHIRURGIE ET AUTRES"

        ElseIf item_number = "ANE" Then
            nomgroupe = "ANESTHESIE"

        ElseIf item_number = "URO" Then
            nomgroupe = "ACTES CHIRURGIE UROLOGIE"

        ElseIf item_number = "ORT" Then
            nomgroupe = "ACTES CHIRURGIE TRAUMATOLOGIE"

        ElseIf item_number = "LAB" Then
            nomgroupe = "LABORATOIRE"

        ElseIf item_number = "ECO" Then
            nomgroupe = "ECHOGRAPHIE"

        ElseIf item_number = "URG" Then
            nomgroupe = "URGENCES"

        ElseIf item_number = "MAT" Then
            nomgroupe = "HOSPITALISATION MATERNITES"

        ElseIf item_number = "PED" Then
            nomgroupe = "HOSPITALISATION PEDIATRIE"

        ElseIf item_number = "HMD" Then
            nomgroupe = "HOSPITALISATION  MEDECINE"

        ElseIf item_number = "CHI" Or item_number = "HCH" Or item_number = "CHIR" Then
            nomgroupe = "HOSPITALISATION CHIRURGIE"

        ElseIf item_number = "REA" Then
            nomgroupe = "REANIMATION CHIRURGICALE"

        ElseIf item_number = "ICU" Then
            nomgroupe = "REANIMATION MEDICALE"

        ElseIf item_number = "KIN" Then
            nomgroupe = "KINESITHERAPIE"

        ElseIf item_number = "SMI" Then
            nomgroupe = "SMI"

        ElseIf item_number = "ORL" Then
            nomgroupe = "ACTES ORL"

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
        elementrow("item_number") = "70 120 - RECETTE CARNET MEDICAL ET DOSSIER"
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
        elementrow("item_number") = "70 620 - RECETTE MATERNITES - ACCOUCHEMENTS"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        elementrow = dt.NewRow
        elementrow("item_number") = "70 630 - RECETTE ACTES CHIRURGIE ET AUTRES"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        elementrow = dt.NewRow
        elementrow("item_number") = "70 631 - RECETTE ANESTHESIE"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        elementrow = dt.NewRow
        elementrow("item_number") = "70 632 - RECETTE ACTES CHIRURGIE UROLOGIE"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        elementrow = dt.NewRow
        elementrow("item_number") = "70 633 - RECETTE ACTES CHIRURGIE TRAUMATOLOGIE"
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
        elementrow("item_number") = "70 641 - RECETTE LABORATOIRE CD4"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        elementrow = dt.NewRow
        elementrow("item_number") = "70 651 - RECETTE ECHOGRAPHIE"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        elementrow = dt.NewRow
        elementrow("item_number") = "70 661 - RECETTES URGENCES"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        elementrow = dt.NewRow
        elementrow("item_number") = "70 622 - RECETTE HOSPITALISATION MATERNITES"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        elementrow = dt.NewRow
        elementrow("item_number") = "70 663 -  RECETTE HOSPITALISATION PEDIATRIE"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        elementrow = dt.NewRow
        elementrow("item_number") = "70 664 - RECETTE HOSPITALISATION  MEDECINE"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        elementrow = dt.NewRow
        elementrow("item_number") = "70 665 - RECETTE  HOSPITALISATION CHIRURGIE"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        elementrow = dt.NewRow
        elementrow("item_number") = "70 666 - RECETTE REANIMATION CHIRURGICALE"
        elementrow("article") = ""
        elementrow("amount") = 0
        dt.Rows.Add(elementrow)
        dt.AcceptChanges()

        elementrow = dt.NewRow
        elementrow("item_number") = "70 667 - RECETTE REANIMATION MEDICALE"
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

    Private Sub addcol(ByRef name As String)

        Dim col As New DataGridViewTextBoxColumn
        col.DataPropertyName = name
        col.HeaderText = name
        col.Name = name
        magrille.Columns.Add(col)
    End Sub

    Private Sub initgrid()
        'Dim row1() As String = "First"
        ' Dim row2() As String = "First"

        ' Dim rows() As Object = {row1, row2}

        ' Dim row As String()
        'For Each row In rows
        'DataGridView1.Rows.Add(row)
        'Next row

    End Sub
End Class