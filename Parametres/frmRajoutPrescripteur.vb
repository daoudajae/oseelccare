Imports MySql.Data.MySqlClient

Public Class frmRajoutPrescripteur
    Public Property Permission As String
    Public Property Utilisateur As String
    'Public ServerString As String

    Dim myConn As New MySqlConnection
    Dim Comd As MySqlCommand
    Dim dtaReader As MySqlDataReader
    Dim Id As Integer
    Dim Qry As String
    Dim DB As New MySQLDataBaseAccess(frmMain.ServerString)
    Private Sub RefreshList()
        Dim Prescriber As String
        lstFournisseur.Items.Clear()

        'Refresh the liste of Items in the listbox
        Qry = "SELECT noms, grade FROM care_prescribers "
        DB.ExecQuery(Qry)

        If DB.RecordCount > 0 Then
            For Each r As DataRow In DB.DBDataTable.Rows
                Prescriber = r.Item("noms") & " (" & r.Item("grade") & ")"
                lstFournisseur.Items.Add(Prescriber)
            Next
        End If

    End Sub

    Private Sub frmRajoutPrecribter_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        myConn.ConnectionString = frmMain.ServerString
        Me.Utilisateur = frmMain.Utilisateur
        Me.Permission = frmMain.Permission
        Me.Text = Me.Text & " - " & frmMain.Utilisateur

        cboGrade.Enabled = False
        btnAjouter.Enabled = False
        Try
            RefreshList()
            btnAjouter.Enabled = False
        Catch ex As MySqlException
            MsgBox(ex.Message, vbOKOnly Or MsgBoxStyle.Critical)
        Finally
            myConn.Close()
        End Try
    End Sub


    Private Sub btnAjouter_Click(sender As System.Object, e As System.EventArgs) Handles btnAjouter.Click
        'Dim Prescriber As String

        'Verifier si le bouton dit Ajouter ou Mettre a Jour

        If btnAjouter.Text = "Ajouter" Then

            If ((txtName.Text = "") OrElse (cboGrade.SelectedIndex < 0)) Then
            Else
                Try
                    DB.AddParams("@nom", txtName.Text)
                    Qry = "SELECT noms FROM care_prescribers WHERE noms=@nom"
                    DB.ExecQuery(Qry)

                    If DB.RecordCount > 0 Then
                        MsgBox("Le prescriteur '" & txtName.Text.ToString & "' existe deja dans la liste!", vbOKOnly Or MsgBoxStyle.Information)
                        myConn.Close()
                    Else
                        DB.AddParams("@noms", txtName.Text)
                        DB.AddParams("@grade", cboGrade.Text)
                        Qry = "INSERT INTO care_prescribers (noms, grade) VALUES (@noms, @grade)"
                        DB.ExecQuery(Qry)
                    End If

                    'Clear the text boxes
                    cboGrade.SelectedIndex = -1
                    txtName.Text = ""
                    'txtAdresse.Enabled = False
                    'txtName.Enabled = False
                    btnAjouter.Enabled = False

                    RefreshList()

                Catch ex As MySqlException
                    MsgBox(ex.Message, vbOKOnly Or MsgBoxStyle.Critical)
                Finally
                    myConn.Close()
                End Try
            End If
        ElseIf btnAjouter.Text = "Mettre a Jour" Then
            Try
                DB.AddParams("@noms", txtName.Text)
                DB.AddParams("@grade", cboGrade.Text)
                DB.AddParams("@id", Id)
                Qry = "UPDATE care_prescribers SET noms=@noms, grade=@grade WHERE id=@id"
                DB.ExecQuery(Qry)

                RefreshList()
                'Vider le contenue des zones de texte
                txtName.Text = ""
                cboGrade.SelectedIndex = -1

                btnAjouter.Enabled = False
                btnAjouter.Text = "Ajouter"
            Catch ex As MySqlException
                MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Information)
            Finally
                myConn.Close()
            End Try
        End If
    End Sub

    Private Sub txtName_Leave(sender As Object, e As System.EventArgs) Handles txtName.Leave
        txtName.Text = txtName.Text.ToUpper
    End Sub

    Private Sub txtName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtName.TextChanged
        'btnAjouter.Enabled = True
        cboGrade.Enabled = True
    End Sub

    Private Sub lstFournisseur_Click(sender As Object, e As System.EventArgs) Handles lstFournisseur.Click
        Dim FullString, FirstPart, SecondPart, Qry As String

        'Recuperer la ligne selectionnee
        FullString = lstFournisseur.SelectedItem.ToString

        'Recuperer le nom du fournisseur
        FirstPart = FullString.Substring(0, FullString.IndexOf("("))
        FirstPart = FirstPart.Substring(0, FirstPart.Length - 1)

        'Recuperer le nom du responsable de l'entreprise
        SecondPart = FullString.Substring(FirstPart.Length, FullString.Length - FirstPart.Length)
        SecondPart = SecondPart.Substring(2, SecondPart.Length - 3)

        'Les afficher dans les zones de texte
        txtName.Text = FirstPart
        cboGrade.SelectedIndex = cboGrade.FindString(SecondPart)

        Try
            'Recuper le Id d'elelement selectionner
            DB.AddParams("@noms", txtName.Text)
            DB.AddParams("@grade", cboGrade.Text)
            Qry = "SELECT id FROM care_prescribers WHERE noms=@noms AND grade=@grade"
            DB.ExecQuery(Qry)
            If DB.RecordCount > 0 Then
                Id = DB.DBDataTable.Rows(0).Item("id")
            End If

            myConn.Close()
        Catch ex As MySqlException
            MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Information)
        Finally
            myConn.Close()
        End Try

        btnAjouter.Text = "Mettre a Jour"

    End Sub

    Private Sub lstFournisseur_DoubleClick(sender As Object, e As System.EventArgs) Handles lstFournisseur.DoubleClick
        'Supprimer un Fournisseur
        Dim Response As Integer
        Dim Qry, Fournisseur As String

        Response = MsgBox("Voulez vous vraiment supprimer cet element?", MsgBoxStyle.OkCancel)

        If Response = 1 Then
            Try
                DB.AddParams("@id", Id)
                Qry = "DELETE FROM care_prescribers WHERE id=@id"
                DB.ExecQuery(Qry)

                RefreshList()
                txtName.Text = ""
                cboGrade.SelectedIndex = -1

                cboGrade.Enabled = False
                btnAjouter.Enabled = False
                btnAjouter.Text = "Ajouter"
            Catch ex As MySqlException
                MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation)
            Finally
                myConn.Close()
            End Try
        End If

    End Sub

    Private Sub lstFournisseur_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstFournisseur.SelectedIndexChanged

    End Sub

    Private Sub btnQuitter_Click(sender As System.Object, e As System.EventArgs) Handles btnQuitter.Click
        Me.Close()
    End Sub

    Private Sub cboGrade_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboGrade.SelectedIndexChanged
        If cboGrade.SelectedIndex > -1 Then
            btnAjouter.Enabled = True
        End If
    End Sub
End Class