Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Reflection

Public Class frmImpressionEtatEntree

    Dim myConn As New MySqlConnection
    Dim Comd As MySqlCommand
    Dim PrescReader As MySqlDataReader
    Dim dtaDataTable As New DataTable
    Dim dtaAdapter As New MySqlDataAdapter
    Dim rpt As New rapportdentree
    Public requette As String


    Private Sub frmImpressionEtatEntree_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        myConn.ConnectionString = frmMain.ServerString
        ' MsgBox(requette)

        myConn.Open()
        dtaDataTable.Reset()
        Comd = New MySqlCommand(requette, myConn)

        dtaAdapter.SelectCommand = Comd
        dtaAdapter.Fill(dtaDataTable)
        myConn.Close()


        rpt.SetDataSource(dtaDataTable)

        CrystalReportViewer1.ReportSource = rpt

    End Sub


End Class