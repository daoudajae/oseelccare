Imports MySql.Data.MySqlClient

Public Class frmLiberationPatient
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


    Private Sub btnLiberer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiberer.Click
        Dim Status As String = ""
        Dim DiagLines As String = ""

        If chkAccord.Checked = True Then
            Dim History As String = ""
            DB.AddParams("@encounter", Encounter)
            DB.ExecQuery("SELECT history FROM care_encounter WHERE encounter_nr=@encounter")
            If DB.RecordCount > 0 Then
                History = DB.DBDataTable.Rows(0).Item("history")
            End If
            If String.Equals(History, "") Then
                History = "Libere le: " & Now.ToString("yyyy-MM-dd HH:mm") & " par: " & Me.Utilisateur
            Else
                History = History & "; Libere le: " & Now.ToString("yyyy-MM-dd HH:mm") & " par: " & Me.Utilisateur
            End If

            'preparer les parametres
            'Verifier ce qui est cocher

            If radNormal.Checked = True Then
                Status = "Liberation Normale"
            End If
            If radDeces.Checked = True Then
                Status = "Deces du patient"
            End If
            If radEvader.Checked = True Then
                Status = "Patient s'est evader"
            End If
            If radEvacuation.Checked = True Then
                Status = "Evacuation du patient"
            End If
            If radSansAvis.Checked = True Then
                Status = "Liberation Sans Avis Medical"
            End If

            DB.AddParams("@inward", 0)
            DB.AddParams("@indept", 0)
            DB.AddParams("@discharged", 1)
            DB.AddParams("@datedis", Now.ToString("yyyy-MM-dd"))
            DB.AddParams("@timedis", Now.ToString("hh:mm"))
            DB.AddParams("@history", History)
            DB.AddParams("@modid", Me.Utilisateur)
            DB.AddParams("@modtime", Now.ToString("yyyy-MM-dd HH:mm"))
            DB.AddParams("@status", Status)
            DB.AddParams("@encounter", Encounter)

            'Create requette
            Qry = "UPDATE care_encounter SET in_ward=@inward, in_dept=@indept, is_discharged=@discharged, " & _
                "discharge_date=@datedis, discharge_time=@timedis, history=@history, modify_id=@modid, " & _
                "modify_time=@modtime, status=@status WHERE encounter_nr=@encounter"
            DB.ExecQuery(Qry)

            If radDeces.Checked = True Then
                'Lister les diagnostiques
                DB.AddParams("@encounter", Encounter)
                Qry = "SELECT i.description as name FROM care_icd10.en as i " & _
                    "LEFT JOIN care_encounter_diagnosis as d ON d.code=i.code WHERE d.encounter_nr=@encounter"
                DB.ExecQuery(Qry)
                If DB.RecordCount > 0 Then
                    For Each r As DataRow In DB.DBDataTable.Rows
                        DiagLines = r.Item("name") & ";"
                    Next
                End If

                'Retrouver l'historique
                DB.AddParams("@id", Id)
                Qry = "SELECT history FROM care_person WHERE pid=@id"
                DB.ExecQuery(Qry)
                If DB.RecordCount > 0 Then
                    History = DB.DBDataTable.Rows(0).Item("history") & "> Deces le " & dtpDeath.Value.ToString("yyyy-MM-dd") & _
                        "; Valider le " & Now.ToString("yyyy-MM-dd") & "; Par " & Me.Utilisateur
                End If

                DB.AddParams("@deathdate", Now.ToString("yyyy-MM-dd HH:mm"))
                DB.AddParams("@deathencounter", Encounter)
                DB.AddParams("@deathcause", DiagLines)
                DB.AddParams("@history", History)
                DB.AddParams("@modid", Me.Utilisateur)
                DB.AddParams("@timedis", Now.ToString("yyyy-MM-dd HH:mm"))
                DB.AddParams("@id", Id)
                Qry = "UPDATE care_person SET death_date=@deathdate, death_encounter_nr=@deathencounter, death_cause=@deathcause, " & _
                    "history=@history, modify_id=@modid, modify_time=@timedis WHERE pid=@id"

                DB.ExecQuery(Qry)
            End If
        End If
    End Sub

    Private Sub frmLiberationPatient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmLiberationPatient_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtId.Text = Me.Id
        radNormal.Checked = True
        Encounter = GetPatientInformation(txtId, txtInfos)
        lblUser.Text = Me.Utilisateur

        'selectionner les diagnostiques du patient
        DB.AddParams("@encounter", Encounter)
        Qry = "SELECT i.code as Code, i.description AS Diagnostique FROM care_icd10_en as i " & _
            "RIGHT JOIN care_encounter_diagnosis AS d ON d.code=i.code WHERE d.encounter_nr=@encounter"

        'Afficher dans le grid
        RefreshGrid(DB, dgvDiagnostiques, Qry)
    End Sub

    Private Sub radDeces_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles radDeces.CheckedChanged
        If radDeces.Checked = True Then
            dtpDeath.Visible = True
        Else
            dtpDeath.Visible = False
        End If
    End Sub

    Private Sub chkAccord_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAccord.CheckedChanged
        If chkAccord.Checked = True Then
            btnLiberer.Enabled = True
        Else
            btnLiberer.Enabled = False
        End If
    End Sub
End Class