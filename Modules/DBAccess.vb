Imports MySql.Data.MySqlClient


Public Class MySQLDataBaseAccess
    'CREATE DB CONNECTION
    Private DBCon As New MySqlConnection

    'Preparer la commande
    Private DBCmd As MySqlCommand

    'Donees
    Public DBDataAdapter As MySqlDataAdapter
    Public DBDataTable As DataTable

    'Parametres des requettes
    Public Params As New List(Of MySqlParameter)

    'Statistique des requettes
    Public RecordCount As Integer
    Public Exception As String

    'Overload the New sub to send the connection string as a param
    Public Sub New(Optional ByRef ConString As String = "")
        DBCon.ConnectionString = ConString
    End Sub
    ''' <summary>
    ''' Sub pour executer les requettes mysql 
    ''' </summary>
    ''' <param name="Query"> Est la requette envoyer a la Sub pour execution</param>
    ''' <remarks>Les requettes peuvent etre SELECT, INSERT, UPDATE etc</remarks>
    ''' 
    Public Sub ExecQuery(ByVal Query As String)
        'Remetre stat a 0
        RecordCount = 0
        Exception = ""

        Try
            'Ouvrir la connection
            DBCon.Open()

            'Creerla commande
            DBCmd = New MySqlCommand(Query, DBCon)

            'Parametrage
            Params.ForEach(Sub(p) DBCmd.Parameters.Add(p))
            Params.Clear()

            'Executer la commande pour remplir la table
            DBDataTable = New DataTable
            DBDataAdapter = New MySqlDataAdapter(DBCmd)
            RecordCount = DBDataAdapter.Fill(DBDataTable)

        Catch ex As MySqlException
            Exception = ex.Message
            MsgBox(ex.Message)
        Finally
            DBCon.Close()
        End Try
        If DBCon.State = ConnectionState.Open Then DBCon.Close()
    End Sub

    ''' 
    ''' <summary>
    ''' Permet de rajouter les parametres passees pour la requette
    ''' </summary>
    ''' <param name="Name">Name est l'indentifiant du parametre</param>
    ''' <param name="Value"> Est la valuer de du parametre</param>
    ''' <remarks></remarks>
    ''' 
    Public Sub AddParams(ByVal Name As String, ByVal Value As Object)
        Dim NewParam As New MySqlParameter(Name, Value)
        Params.Add(NewParam)
    End Sub
End Class


