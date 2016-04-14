Imports MySql.Data.MySqlClient

Public Class frmPatientDianostique
    Public Property Permission As String
    Public Property Utilisateur As String
    Public Property Id As Long
    Public Property Encounter As Long

    'Private DB As New MySQLDataBaseAccess("server=192.168.6.1;userid=root;password=;database=caredb")
    Dim DB As New MySQLDataBaseAccess(frmMain.ServerString)
    Dim Qry As String


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Function NotEmpty(ByVal Value As String)
        If Not String.IsNullOrEmpty(Value) Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub frmLiberationPatient_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtId.Text = Me.Id
        Encounter = GetPatientInformation(txtId, txtInfos)
        lblUser.Text = Me.Utilisateur
        Qry = "SELECT description, code FROM care_icd10_en ORDER BY description ASC"

        DB.ExecQuery(Qry)

        If DB.RecordCount > 0 Then
            Fillcbos(DB, cboDiagnostique, cboId, Qry)
        End If
    End Sub

    Private Sub cboDiagnostique_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDiagnostique.SelectedIndexChanged
        cboId.SelectedIndex = cboDiagnostique.SelectedIndex
        btnAjouter.Enabled = True
    End Sub

    Private Sub btnAjouter_Click(sender As System.Object, e As System.EventArgs) Handles btnAjouter.Click
        Dim History As String = ""
        If Not String.IsNullOrEmpty(cboDiagnostique.Text) Then
            'Get the previous history
            DB.AddParams("@encounter", Encounter)
            DB.AddParams("@code", cboId.Text)
            DB.ExecQuery("SELECT history FROM care_encounter_diagnosis WHERE encounter_nr=@encounter AND code=@code")

            If DB.RecordCount > 0 Then
                If Not IsDBNull(DB.DBDataTable.Rows(0).Item("history")) Then
                    History = DB.DBDataTable.Rows(0).Item("history")
                End If
                MsgBox("Diagnostique existant pour cette rencontre.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Diagnostique")
            Else

                DB.AddParams("@encounter", Encounter)
                DB.AddParams("@date", Now.ToString("yyyy-MM-dd hh:mm"))
                DB.AddParams("@code", cboId.Text)
                'DB.AddParams("@name", cboDiagnostique.Text)
                DB.AddParams("@modid", Me.Utilisateur)
                DB.AddParams("@modtime", Now.ToString("yyyy-MM-dd hh:mm"))
                DB.AddParams("@createid", Me.Utilisateur)
                DB.AddParams("@createtime", Now.ToString("yyyy-MM-dd hh:mm"))
                If String.Equals(History, "") Then
                    History = Me.Utilisateur & "-" & Now.ToString("yyyy-MM-dd hh:mm")
                Else
                    History = History & ";" & Me.Utilisateur & "-" & Now.ToString("yyyy-MM-dd hh:mm")
                End If
                DB.AddParams("@history", History)
                Qry = "INSERT INTO care_encounter_diagnosis (encounter_nr,`date`, `code`,`modify_id`,`modify_time`,`create_id`,`create_time`,`history`) " & _
                    "VALUES (@encounter, @date, @code, @modid, @modtime, @createid, @createtime, @history)"

                DB.ExecQuery(Qry)

                'selectionner les diagnostiques du patient
                DB.AddParams("@encounter", Encounter)
                Qry = "SELECT d.code as Code, i.description AS Diagnostique FROM care_encounter_diagnosis as d " & _
                    "LEFT JOIN care_icd10_en as i ON d.code=i.code WHERE d.encounter_nr=@encounter"

                'Afficher dans le grid
                RefreshGrid(DB, dgvDiagnostiques, Qry)
            End If
        End If
    End Sub

    Private Sub frmPatientDianostique_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class