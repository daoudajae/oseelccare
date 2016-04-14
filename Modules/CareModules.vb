Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Module CareModules

    Public Function getSHA1Hash(ByVal strToHash As String) As String

        Dim sha1Obj As New Security.Cryptography.MD5CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = sha1Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult

    End Function

    Public Function FindIndex(ByVal cboBox As ComboBox, ByVal dbString As String) As Integer
        Dim Index As Integer
        Dim found As Boolean
        found = False
        Index = 0
        While ((found = False) And (Index < cboBox.Items.Count))
            If (cboBox.Items(Index).ToString = dbString) Then
                found = True
            Else
                Index += 1
            End If
        End While
        Return Index
    End Function


    Function remplir_table(ByVal nomtable, ByVal nomcolonne) As DataTable
        Dim myConn = New MySqlConnection
        Dim dtadatatable As New DataTable
        Dim req As String = "SELECT DISTINCT (" & nomcolonne & ") FROM `" & nomtable & "`"
        Dim dtaAdapter As New MySqlDataAdapter

        Try

            myConn.ConnectionString = frmMain.ServerString
            dtadatatable.Reset()
            myConn.Open()
            Dim Comd = New MySqlCommand(req, myConn)
            dtaAdapter.SelectCommand = Comd
            dtaAdapter.Fill(dtadatatable)
            myConn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            myConn.Close()
        End Try
        Return dtadatatable
    End Function

    Function remplir_table_condition(ByVal nomtable, ByVal nomcolonne, ByVal coloonnecond, ByVal valeurscond) As DataTable
        Dim myConn = New MySqlConnection
        Dim dtadatatable As New DataTable
        Dim req As String = "SELECT DISTINCT (" & nomcolonne & ") FROM `" & nomtable & "` WHERE `" & coloonnecond & "` IN (" & valeurscond & ")"
        Dim dtaAdapter As New MySqlDataAdapter

        Try

            myConn.ConnectionString = frmMain.ServerString
            dtadatatable.Reset()
            myConn.Open()
            Dim Comd = New MySqlCommand(req, myConn)
            dtaAdapter.SelectCommand = Comd
            dtaAdapter.Fill(dtadatatable)
            myConn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            myConn.Close()
        End Try
        Return dtadatatable
    End Function

End Module
