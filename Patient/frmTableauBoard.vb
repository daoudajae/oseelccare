Imports MySql.Data.MySqlClient

Public Class frmTableauBoard
    Public Property Permission As String
    Public Property Utilisateur As String
    Public Property Id As Long
    Public Property Noms As String
    Public Property Birth As String
    Public Property Profession As String
    Public Property Index As Integer
    Public Property Ville As String
    Public Property Adresse As String
    Public Property DateEnregistrement As String
    Public Property Telephone As String
    Public Property Sex As String
    Public Property Status As String
    Public Property Groupe As String
    Public Property Encouter As Long

    'Private DB As New MySQLDataBaseAccess("server=192.168.6.1;userid=root;password=;database=caredb")
    Dim DB As New MySQLDataBaseAccess(frmMain.ServerString)


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


    Private Sub frmPatientAdmission_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        lblId.Text = Me.Id

    End Sub


    Private Sub btnPrescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrescription.Click
        Dim frmPrescription As New frmPatientPrescription
        frmPrescription.Id = Me.Id
        frmPrescription.ShowDialog()
    End Sub

    Private Sub frmTableauBoard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnLiberation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiberation.Click
        Dim frmLiberation As New frmLiberationPatient
        frmLiberation.Id = Me.Id

        frmLiberation.Utilisateur = frmMain.Utilisateur
        frmLiberation.ShowDialog()
    End Sub

    Private Sub btnDiagnostic_Click(sender As System.Object, e As System.EventArgs) Handles btnDiagnostic.Click
        Dim frmDiag As New frmPatientDianostique
        frmDiag.Id = Me.Id
        frmDiag.Utilisateur = frmMain.Utilisateur
        frmDiag.ShowDialog()
    End Sub

    Private Sub btnAssurances_Click(sender As System.Object, e As System.EventArgs) Handles btnAssurances.Click
        Dim frmNewInsurance As New frmPriseEnCharge
        'frmNewInsurance.MdiParent = Me
        frmNewInsurance.ShowDialog()
    End Sub
End Class