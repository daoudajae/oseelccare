Imports MySql.Data.MySqlClient

Public Class frmPatientSearch
    Public Property Permission As String
    Public Property Utilisateur As String
    Public Property Qte As Integer
    'Public ServerString As String

    Dim myConn, myLabConn As New MySqlConnection
    Dim Comd, LabCmd As MySqlCommand
    Dim PrescReader, LabReader As MySqlDataReader
    Dim ArticleNumber, EncounterPercent, Price As Integer
    Dim Article, DrugClass, PrescribeDate, Precriber, History, WhereClose, Qry, LabQry As String
    Dim TotalSelect, TotalAssureur, TotalAssurer, TotalExclusion, billAmount, billNo, Exclusion, BonCfg As Integer
    Dim ConnMode, EncounterType, FirmName, ContactName, PatientRelation, PatientQuality As String
    Dim Encounter As ULong


    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click

        Encounter = GetPatientInformation(txtId, txtInfos)
        If Encounter > 0 Then
            grpPrescriptions.Visible = True
            grpInfo.Visible = True
        End If
    End Sub


    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPrescrire_Click(sender As System.Object, e As System.EventArgs) Handles btnPrescrire.Click
        Dim Article, DrugClass As String
        Dim Dose, ItemNum, Price As Integer
        DrugClass = ""
        Article = ""
        Try
            Qry = "SELECT item_id as Id, unit_price as Prix, purchasing_class as Type FROM " & _
                "care_tz_drugsandservices WHERE item_description='" & Article & "'"

            myConn.Open()
            Comd = New MySqlCommand(Qry, myConn)
            PrescReader = Comd.ExecuteReader
            PrescReader.Read()
            'afficher le total
            If PrescReader.HasRows = True Then
                ItemNum = CInt(PrescReader("Id"))
                Price = CInt(PrescReader("Prix"))
                DrugClass = PrescReader("Type").ToString
                myConn.Close()
            Else
                myConn.Close()
                Qry = "SELECT nr, price FROM care_tz_laboratory_param WHERE name='" & Article & "'"
                myConn.Open()
                Comd = New MySqlCommand(Qry, myConn)
                PrescReader = Comd.ExecuteReader
                PrescReader.Read()
                If PrescReader.HasRows = True Then
                    ItemNum = CInt(PrescReader("nr"))
                    Price = CInt(PrescReader("price"))
                    DrugClass = "Laboratoire"
                End If
            End If
            ''''''''''''''''''''''''''''
            '' Inserer les donnees dans la table des prescriptions
            '''''''''''''''''''''''''''''''''''
            myConn.Close()
            Qry = "INSERT INTO care_encounter_prescription " & _
                "(encounter_nr, article, article_item_number, price, drug_class, dosage, prescribe_date, prescriber, create_id, create_time) " & _
                "VALUES (" & Encounter & ", '" & Article & "', " & ItemNum & ", " & Price & ", '" & DrugClass & "', " & _
                Dose & ",' " & Now().ToString("yyyy-MM-dd") & "', '" & Me.Utilisateur & "', '" & Me.Utilisateur & "', '" & Now().ToString("yyyy-MM-dd hh:mm") & "')"
            myConn.Open()
            Comd = New MySqlCommand(Qry, myConn)
            Comd.ExecuteNonQuery()
            myConn.Close()
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Total Prescriptions")
        Finally
            myConn.Close()
            myConn.Dispose()
        End Try

        MsgBox("Prescriptions faites avec succes!", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Prescriptions")

    End Sub

    Private Sub frmPatientInscription_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        myConn = New MySqlConnection
        myLabConn = New MySqlConnection
        myConn.ConnectionString = frmMain.ServerString
        myLabConn.ConnectionString = frmMain.ServerString
        Me.Utilisateur = frmMain.Utilisateur

        Me.Text = Me.Text & " - " & frmMain.Utilisateur

    End Sub
End Class