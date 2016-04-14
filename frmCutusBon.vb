Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmCutusBon
    Dim myConn, myConn2, myLabConn As New MySqlConnection
    Dim Comd, Comd2, LabCmd As MySqlCommand
    Dim PrescReader, LabReader As MySqlDataReader
    Dim TotalSelect As Integer
    Dim ConnMode As String
    Dim Encounter As ULong
    Dim billnum As String
    Dim totalbillamount As Double
    Dim totalreceiptamount As Double
    Dim amountdue As Double
    Public user As String
    Dim testbill As String
    Dim agentdefacturation As String
    Dim montantverse As Double
    Dim typepaiement As String

    Dim qry, Enc_Date, Enc_type, Patient_Name, Patient_Birth As String
    Dim dtaAdapter As New MySqlDataAdapter
    Dim dtaDataTable As New DataTable
    Dim bindSource As New BindingSource

    Dim BonCfg As Integer
    Dim newListRow As DataRow
    Private Sub frmCutusBon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myConn.ConnectionString = frmMain.ServerString
        myLabConn.ConnectionString = frmMain.ServerString
        myConn2.ConnectionString = frmMain.ServerString
    End Sub

    Private Sub GetBilledItems()


        'dtaDataTable.DataSet.Clear()
        bindSource.DataSource = Nothing

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

                myConn.Open()
                qry = "SELECT name_first, name_last, date_birth FROM caredb.care_person WHERE pid=" & CULng(txtId.Text)
                Comd = New MySqlCommand(qry, myConn)
                'Get the encounter number
                PrescReader = Comd.ExecuteReader
                PrescReader.Read()
                Patient_Name = PrescReader.Item("name_last") & "  " & PrescReader.Item("name_first")
                Patient_Birth = PrescReader.Item("date_birth")
                myConn.Close()

                grpInfo.Visible = True
                lblPatientInfo.Visible = True
                lblEncInfo.Visible = True
                lblPatientInfo.Text = "Noms: " & Patient_Name & " Né(e) le: " & Patient_Birth
                lblEncInfo.Text = "No Visite: " & Encounter & " du: " & Enc_Date
                If BonCfg > 0 Then
                    lblBonInfo.Visible = True
                    lblBonInfo.Text = "Type du bon: " & BonCfg & ". Pour: " & Enc_type
                End If

                affichercrystalreport()


            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                myConn.Dispose()
            End Try
        Else
            MsgBox("Vous devez saisir un numero de patient valide a 8 chiffres.", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Erreur!!!")
            txtId.Focus()
            txtId.Clear()
            Exit Sub
        End If
    End Sub

    Private Sub affichercrystalreport()
        Dim rpt As New cutusbon
        

        ' affectation des autres element constitutif de la facture
        rpt.SetParameterValue("nom", Patient_Name)
        rpt.SetParameterValue("liens", "")
        rpt.SetParameterValue("datenaissance", Patient_Birth)
        rpt.SetParameterValue("agent", user)

        CrystalReportViewer.ReportSource = rpt

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        GetBilledItems()
    End Sub
End Class