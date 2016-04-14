Imports MySql.Data.MySqlClient

Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmEtatJournalier

    Dim myConn, myConn2 As New MySqlConnection
    Dim Comd, Comd2 As MySqlCommand
    Dim PrescReader, PrescReader2 As MySqlDataReader
    

    Dim qry, nom As String
    Dim dtaAdapter As New MySqlDataAdapter
    
    Dim newListRow, elementrow As DataRow

    Dim listecaissier, listefactureur As New DataTable
    

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub frmEtatJournalier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        myConn.ConnectionString = frmMain.ServerString
        myConn2.ConnectionString = frmMain.ServerString
        'radiofacturation.Checked = True

        listecaissier.Clear()
        listecaissier.Columns.Add("nom", Type.GetType("System.String"))

        listefactureur.Clear()
        listefactureur.Columns.Add("nom", Type.GetType("System.String"))



        'recherche des caissiers
        Try
            qry = "SELECT DISTINCT(`encaisseur`) FROM  `care_billing_payment`"
            myConn.Open()
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                While PrescReader.Read()

                    nom = PrescReader.Item("encaisseur")

                    'jinserre la ligne

                    elementrow = listecaissier.NewRow
                    elementrow("nom") = nom
                    
                    listecaissier.Rows.Add(elementrow)
                    listecaissier.AcceptChanges()


                End While
            End If
            PrescReader.Close()
            Comd.ExecuteNonQuery()
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try

        'recherche des factureurs
        Try
            qry = "SELECT DISTINCT(`factureur`) FROM  `care_billing_payment`"
            myConn.Open()
            Comd = New MySqlCommand(qry, myConn)
            PrescReader = Comd.ExecuteReader
            If PrescReader.HasRows Then
                While PrescReader.Read()

                    nom = PrescReader.Item("factureur")

                    'jinserre la ligne

                    elementrow = listefactureur.NewRow
                    elementrow("nom") = nom

                    listefactureur.Rows.Add(elementrow)
                    listefactureur.AcceptChanges()


                End While
            End If
            PrescReader.Close()
            Comd.ExecuteNonQuery()
            myConn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            myConn.Close()
        End Try


        agentcaisse.DataSource = listecaissier
        agentcaisse.DisplayMember = "nom"
        agentcaisse.SelectedIndex = -1

        'agentfacturation.DataSource = listefactureur
        ' agentfacturation.DisplayMember = "nom"
        ' agentfacturation.SelectedIndex = -1


        'valeur par defaut
        'agentcaisse.SelectedValue = "None"
        'agentfacturation.SelectedValue = "None"

    End Sub

    Private Sub valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rapport_journalier.Click


        'verification des parametres

        ' MsgBox(DateDebut.ToString & "  " & DateFin.ToString)

        If agentcaisse.Text = "" Then
            agentcaisse.Text = "None"
        End If
        

        Dim date1 As Date = "#" & DateDebut.Value & "#"
        Dim date2 As Date = "#" & DateFin.Value & "#"
        Dim result As Integer = Date.Compare(date1, date2)

        If result < 0 Then

        ElseIf result = 0 Then

        Else

            MsgBox("Veuiller choisir une plage de date valide")
            Exit Sub

        End If

        '
        Dim frm As New frmImpressionEtatJournalier
       
        frm.datedebut = DateDebut.Value
        frm.datefin = DateFin.Value
        frm.agentcaisse = agentcaisse.Text
        'frm.agentfacturation = agentfacturation.Text

        frm.ShowDialog()
    End Sub

    Private Sub rapport_detaille_facturation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        agentcaisse.Text = "None"


        Dim date1 As Date = "#" & DateDebut.Value & "#"
        Dim date2 As Date = "#" & DateFin.Value & "#"
        Dim result As Integer = Date.Compare(date1, date2)

        If result < 0 Then

        ElseIf result = 0 Then

        Else

            MsgBox("Veuiller choisir une plage de date valide")
            Exit Sub

        End If

        '
        Dim frm As New frmRapportDetailleFacturation
       
        frm.datedebut = DateDebut.Value
        frm.datefin = DateFin.Value
        frm.agentcaisse = agentcaisse.Text
        'frm.agentfacturation = agentfacturation.Text

        frm.ShowDialog()

    End Sub

    Private Sub rapport_detaille_caisse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rapport_detaille_caisse.Click


        If agentcaisse.Text = "" Then
            agentcaisse.Text = "None"
        End If
        

        Dim date1 As Date = "#" & DateDebut.Value & "#"
        Dim date2 As Date = "#" & DateFin.Value & "#"
        Dim result As Integer = Date.Compare(date1, date2)

        If result < 0 Then

        ElseIf result = 0 Then

        Else

            MsgBox("Veuiller choisir une plage de date valide")
            Exit Sub

        End If

        '
        Dim frm As New frmRapportDetailleCaisse
       

        frm.datedebut = DateDebut.Value
        frm.datefin = DateFin.Value
        frm.agentcaisse = agentcaisse.Text
        'frm.agentfacturation = agentfacturation.Text

        frm.ShowDialog()


    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If agentcaisse.Text = "" Then
            agentcaisse.Text = "None"
        End If
        
        If rubrique.Text = "" Then

            MsgBox("Choisissez une rubrique")
            Exit Sub
        End If

        Dim date1 As Date = "#" & DateDebut.Value & "#"
        Dim date2 As Date = "#" & DateFin.Value & "#"
        Dim result As Integer = Date.Compare(date1, date2)

        If result < 0 Then

        ElseIf result = 0 Then

        Else

            MsgBox("Veuiller choisir une plage de date valide")
            Exit Sub

        End If

        '
        Dim frm As New frmRapportDetailleCategorie

        frm.datedebut = DateDebut.Value
        frm.datefin = DateFin.Value
        frm.agentcaisse = agentcaisse.Text
        'frm.agentfacturation = agentfacturation.Text
        frm.rubrique = rubrique.Text

        frm.ShowDialog()

    End Sub

    Private Sub agentcaisse_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles agentcaisse.SelectedIndexChanged

    End Sub
End Class