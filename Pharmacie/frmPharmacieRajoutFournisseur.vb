Imports MySql.Data.MySqlClient

Public Class frmPharmacieRajoutFournisseur
    Public Property Permission As String
    Public Property Utilisateur As String
    'Public ServerString As String

    Dim myConn As New MySqlConnection
    Dim Comd As MySqlCommand
    Dim dtaReader As MySqlDataReader
    Dim Id As Integer


    Private Sub frmPharmacieRajoutFournisseur_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim Qry, Fournisseur As String

        myConn.ConnectionString = frmMain.ServerString
        Me.Utilisateur = frmMain.Utilisateur
        Me.Permission = frmMain.Permission
        Me.Text = Me.Text & " - " & frmMain.Utilisateur

        txtAdresse.Enabled = False
        btnAjouter.Enabled = False
        Try
            Qry = "SELECT name, responsable FROM care_tz_stock_suppliers "

            myConn.Open()
            Comd = New MySqlCommand(Qry, myConn)
            dtaReader = Comd.ExecuteReader
            lstFournisseur.Items.Clear()
            While dtaReader.Read()
                Fournisseur = dtaReader("name").ToString & " (" & dtaReader("responsable").ToString & ")"
                lstFournisseur.Items.Add(Fournisseur)
            End While
            btnAjouter.Enabled = False
        Catch ex As MySqlException
            MsgBox(ex.Message, vbOKOnly Or MsgBoxStyle.Critical)
        Finally
            myConn.Close()
        End Try
    End Sub


    Private Sub btnAjouter_Click(sender As System.Object, e As System.EventArgs) Handles btnAjouter.Click
        Dim Qry, Fournisseur As String

        'Verifier si le bouton dit Ajouter ou Mettre a Jour

        If btnAjouter.Text = "Ajouter" Then

            If ((txtName.Text = "") And (txtAdresse.Text = "")) Then
            Else
                Try
                    Qry = "SELECT name FROM care_tz_stock_suppliers WHERE name='" & txtName.Text.ToString & "'"

                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)
                    dtaReader = Comd.ExecuteReader
                    dtaReader.Read()

                    If dtaReader.HasRows = True Then
                        MsgBox("Le fournisseur '" & txtName.Text.ToString & "' existe deja dans la liste!", vbOKOnly Or MsgBoxStyle.Information)
                        myConn.Close()
                    Else
                        myConn.Close()
                        myConn.Open()
                        Qry = "INSERT INTO care_tz_stock_suppliers (name, responsable) VALUES ('" & txtName.Text.ToString & "','" & txtAdresse.Text.ToString & "')"
                        'MsgBox(Qry)
                        Comd = New MySqlCommand(Qry, myConn)
                        Comd.ExecuteNonQuery()
                        myConn.Close()
                    End If

                    'Clear the text boxes
                    txtAdresse.Text = ""
                    txtName.Text = ""
                    txtAdresse.Enabled = False
                    'txtName.Enabled = False
                    btnAjouter.Enabled = False

                    'rafraichir la liste desfournisseur
                    lstFournisseur.Items.Clear()

                    'Refresh the liste of Items in the listbox
                    Qry = "SELECT name, responsable FROM care_tz_stock_suppliers "

                    myConn.Open()
                    Comd = New MySqlCommand(Qry, myConn)
                    dtaReader = Comd.ExecuteReader
                    While dtaReader.Read()
                        Fournisseur = dtaReader("name").ToString & " (" & dtaReader("responsable").ToString & ")"
                        lstFournisseur.Items.Add(Fournisseur)
                    End While

                Catch ex As MySqlException
                    MsgBox(ex.Message, vbOKOnly Or MsgBoxStyle.Critical)
                Finally
                    myConn.Close()
                End Try
            End If
        ElseIf btnAjouter.Text = "Mettre a Jour" Then
            Try
                myConn.Open()
                Qry = "UPDATE care_tz_stock_suppliers SET name='" & txtName.Text.ToString & "', responsable='" & txtAdresse.Text.ToString & "' WHERE id=" & Id
                'MsgBox(Qry)
                Comd = New MySqlCommand(Qry, myConn)
                Comd.ExecuteNonQuery()
                myConn.Close()

                'Refresh the liste of Items in the listbox
                Qry = "SELECT name, responsable FROM care_tz_stock_suppliers "

                'Vider la listbox
                lstFournisseur.Items.Clear()

                'Ouvrir la connection au serveur
                myConn.Open()
                Comd = New MySqlCommand(Qry, myConn)
                dtaReader = Comd.ExecuteReader
                While dtaReader.Read()
                    Fournisseur = dtaReader("name").ToString & " (" & dtaReader("responsable").ToString & ")"
                    lstFournisseur.Items.Add(Fournisseur)
                End While
                myConn.Close()

                'Vider le contenue des zones de texte
                txtName.Text = ""
                txtAdresse.Text = ""

                txtAdresse.Enabled = False
                btnAjouter.Enabled = False
                btnAjouter.Text = "Ajouter"
            Catch ex As MySqlException
                MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Information)
            Finally
                myConn.Close()
            End Try
        End If
    End Sub

    Private Sub txtName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtName.TextChanged
        btnAjouter.Enabled = True
        txtAdresse.Enabled = True
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
        txtAdresse.Text = SecondPart

        Try
            'Recuper le Id d'elelement selectionner
            Qry = "SELECT id FROM care_tz_stock_suppliers WHERE name='" & txtName.Text.ToString & "' AND responsable='" & txtAdresse.Text.ToString & "'"
            myConn.Open()
            Comd = New MySqlCommand(Qry, myConn)
            dtaReader = Comd.ExecuteReader
            dtaReader.Read()

            If dtaReader.HasRows = True Then
                Id = CInt(dtaReader("id"))
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
                myConn.Open()
                Qry = "DELETE FROM care_tz_stock_suppliers WHERE id=" & Id
                'MsgBox(Qry)
                Comd = New MySqlCommand(Qry, myConn)
                Comd.ExecuteNonQuery()
                myConn.Close()

                'Refresh the liste of Items in the listbox
                Qry = "SELECT name, responsable FROM care_tz_stock_suppliers "

                'Vider la listbox
                lstFournisseur.Items.Clear()

                'Ouvrir la connection au serveur
                myConn.Open()
                Comd = New MySqlCommand(Qry, myConn)
                dtaReader = Comd.ExecuteReader
                While dtaReader.Read()
                    Fournisseur = dtaReader("name").ToString & " (" & dtaReader("responsable").ToString & ")"
                    lstFournisseur.Items.Add(Fournisseur)
                End While
                myConn.Close()

                txtName.Text = ""
                txtAdresse.Text = ""

                txtAdresse.Enabled = False
                btnAjouter.Enabled = False
                btnAjouter.Text = "Ajouter"
            Catch ex As MySqlException
                MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation)
            Finally
                myConn.Close()
            End Try
        End If

    End Sub

    Private Sub RefreshList()

    End Sub
    Private Sub lstFournisseur_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstFournisseur.SelectedIndexChanged

    End Sub

    Private Sub btnQuitter_Click(sender As System.Object, e As System.EventArgs) Handles btnQuitter.Click
        Me.Close()
    End Sub
End Class