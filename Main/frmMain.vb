Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class frmMain
    Public Property myConn As New MySqlConnection
    Public Property Comd As MySqlCommand
    Public Property Permission As String
    Public Property Utilisateur As String
    Public Property Id As String

    Public ServerString As String

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Dim Qry As String
        Try
            myConn.Open()
            Qry = "UPDATE care_users SET personell_nr=0 WHERE login_id='" & Me.Id & "'"
            Comd = New MySqlCommand(Qry, myConn)
            Comd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Care 2X!")
        Finally
            myConn.Close()
            myConn.Dispose()
        End Try
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub frmMain_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim Qry As String
        Try
            myConn.Open()
            Qry = "UPDATE care_users SET personell_nr=0 WHERE login_id='" & Me.Id & "'"
            Comd = New MySqlCommand(Qry, myConn)
            Comd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Care 2X!")
        Finally
            myConn.Close()
            myConn.Dispose()
        End Try
    End Sub


    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim frmConnect = New frmConnection

            'Dim count As Integer

            frmConnect.ShowDialog()
            If frmConnect.DialogResult = Windows.Forms.DialogResult.OK Then
                Me.Utilisateur = frmConnect.Utilisateur
                Me.Permission = frmConnect.Permission
                Me.Id = frmConnect.Id
                Me.ServerString = frmConnect.ServerString
                myConn.ConnectionString = Me.ServerString

                TSSLabel.Text = "Bienvenue " & frmConnect.Utilisateur '& " | Vos permissions d'acces sont pour le Module " & frmConnect.Permission
                TSSLabel.TextAlign = ContentAlignment.MiddleRight
                StatusStrip.Enabled = True

                'Activer Menu Statistiques
                If Me.Permission = "statistiques" Then
                    StatistiquesMenu.Visible = True
                    RapportDEntréeToolStripMenuItem.Visible = True
                    SuiviPrescripteurToolStripMenuItem.Visible = True
                    EtatConsultationToolStripMenuItem.Visible = True
                End If

                'Activer le menu facturation
                If Me.Permission = "facturation" Then
                    FactutationMenu.Visible = True
                    FacurationMenuItem.Visible = True
                End If

                'Activer le menu d'ecaissement
                If Me.Permission = "caisse" Then
                    CaisseMenu.Visible = True
                    EncaissementMenu.Visible = True
                    PaiementAvanceMenuItem.Visible = True
                End If

                'Activer le recouvrement 
                If Me.Permission = "recouvrement" Then
                    FactutationMenu.Visible = True
                    FacurationMenuItem.Visible = True
                    factureMenu.Visible = True
                    ' EncaissementBonsMenu.Visible = True
                    PatientMenu.Visible = True
                    'CaisseMenu.Visible = True
                    SettingsMenu.Visible = True
                    AssurancesMenu.Visible = True
                    RechercherMenu.Visible = True
                    EnregistrementMenu.Visible = True
                    PaiementAvanceMenuItem.Visible = True
                    'Recouvrement Menu
                    RecouvrementMenu.Visible = True
                    'BPCMenu.Visible = True
                    QuitusBPCMenu.Visible = True
                    BonDePriseEnChargeMenu.Visible = True
                    factureMenu.Visible = True
                    ETATSToolStripMenuItem.Visible = True
                    PrescriptionsMenu.Visible = True
                    PrescriptionsToolStripMenuItem.Visible = True
                    'LibererLePatientToolStripMenuItem.Visible = True
                    AjouterDiagnostiquesToolStripMenuItem.Visible = True

                End If

                If Me.Permission = "enregistrement" Then
                    PatientMenu.Visible = True
                    RechercherMenu.Visible = True
                    EnregistrementMenu.Visible = True
                    PrescriptionsMenu.Visible = True
                    PrescriptionsToolStripMenuItem.Visible = True

                End If

                'Activer le Economat 
                If Me.Permission = "economat" Then
                    FactutationMenu.Visible = True
                    FacurationMenuItem.Visible = True
                    factureMenu.Visible = True
                    ' EncaissementBonsMenu.Visible = True
                    PatientMenu.Visible = True
                    CaisseMenu.Visible = True
                    SettingsMenu.Visible = True
                    AssurancesMenu.Visible = True

                    'Recouvrement Menu
                    RecouvrementMenu.Visible = True
                    BPCMenu.Visible = True
                    QuitusBPCMenu.Visible = True
                    BonDePriseEnChargeMenu.Visible = True
                    factureMenu.Visible = True
                    ETATSToolStripMenuItem.Visible = True

                    'Activer Menu Rapports
                    RapportsMenu.Visible = True
                    'RapportPeriodiqueMenu.Visible = True
                    'RapportAnnuelMenu.Visible = True
                    'Rapport100Menu.Visible = True
                    'Rapport100Menu.Visible = True
                    PrescriptionsMenu.Visible = True

                    'statistique
                    StatistiquesMenu.Visible = True

                End If

                'Activer tous les menus
                If Me.Permission = "admin" Then
                    'Activer Menu Patient
                    PatientMenu.Visible = True
                    RechercherMenu.Visible = True
                    EnregistrementMenu.Visible = True
                    BonDePriseEnChargeMenu.Visible = True

                    'Activer Menu Caisse
                    CaisseMenu.Visible = True
                    EncaissementMenu.Visible = True
                    ' EncaissementBonsMenu.Visible = True
                    PaiementAvanceMenuItem.Visible = True
                    PaiementDuRemboursementMenu.Visible = True
                    GestionCaissePrincipale.Visible = True
                    GestionCaissePrincipale.Visible = True
                    PrescriptionsMenu.Visible = True
                    PrescriptionsToolStripMenuItem.Visible = True
                    ReimpressionFactureToolStripMenuItem.Visible = True
                    'LibererLePatientToolStripMenuItem.Visible = True

                    'Activer Menu Facturation
                    FactutationMenu.Visible = True
                    FacurationMenuItem.Visible = True
                    factureMenu.Visible = True

                    'Activer Menu Pharmacie
                    PharmacieMenu.Visible = True
                    LivraisonPatientMenu.Visible = True
                    ValiderCommande.Visible = True
                    'SuivieDeStockDesProduitsMenu.Visible = True

                    'Activer Menu Rapports
                    RapportsMenu.Visible = True
                    'RapportPeriodiqueMenu.Visible = True
                    'RapportAnnuelMenu.Visible = True
                    'Rapport100Menu.Visible = True
                    'Rapport100Menu.Visible = True
                    PrescriptionsMenu.Visible = True

                    'Activer Menu Parametrage
                    SettingsMenu.Visible = True
                    UtilisateursMenu.Visible = True
                    ProduitsMenu.Visible = True
                    AssurancesMenu.Visible = True

                    'Recouvrement Menu
                    RecouvrementMenu.Visible = True
                    BPCMenu.Visible = True
                    QuitusBPCMenu.Visible = True
                    BonDePriseEnChargeMenu.Visible = True
                    ETATSToolStripMenuItem.Visible = True
                    factureMenu.Visible = True

                    'Statistiques
                    StatistiquesMenu.Visible = True

                    'Menu pharmacie
                    PharmacieMenu.Visible = True
                    LivraisonPatientMenu.Visible = True
                    CommandeDeStockToolStripMenuItem.Visible = True
                    VoirStockMenuItem.Visible = True
                    RavitaillementDuMagasinToolStripMenuItem.Visible = True
                    RajouterUnFournisseurToolStripMenuItem.Visible = True
                    RajouterUnServiceToolStripMenuItem.Visible = True
                    RapportVenteToolStripMenuItem.Visible = True

                End If

                'Activer les elements pour la caisse principale 
                If Me.Permission = "caissep" Then
                    FactutationMenu.Visible = True
                    FacurationMenuItem.Visible = True
                    ' EncaissementBonsMenu.Visible = True
                    PatientMenu.Visible = True
                    CaisseMenu.Visible = True
                    SettingsMenu.Visible = True
                    AssurancesMenu.Visible = True
                    GestionCaissePrincipale.Visible = True
                    GestionCaissePrincipale.Visible = True

                    'Recouvrement Menu
                    RecouvrementMenu.Visible = True
                    BPCMenu.Visible = True
                    QuitusBPCMenu.Visible = True
                    BonDePriseEnChargeMenu.Visible = True
                    factureMenu.Visible = True
                    ETATSToolStripMenuItem.Visible = True

                    'Activer Menu Rapports
                    RapportsMenu.Visible = True
                    'RapportPeriodiqueMenu.Visible = True
                    'RapportAnnuelMenu.Visible = True
                    'Rapport100Menu.Visible = True
                    'Rapport100Menu.Visible = True
                    PrescriptionsMenu.Visible = True
                End If

                'Activer le menu d'ecaissement
                If Me.Permission = "pharmacie1" Or Me.Permission = "pharmacie2" Or Me.Permission = "pharmacie3" Or Me.Permission = "pharmacie4" Then
                    PharmacieMenu.Visible = True
                    LivraisonPatientMenu.Visible = True
                    CommandeDeStockToolStripMenuItem.Visible = True
                    VoirStockMenuItem.Visible = True
                    ValiderCommande.Visible = True
                    'EncaissementMenu.Enabled = True
                End If

                If Me.Permission = "magasin" Then
                    PharmacieMenu.Visible = True
                    VoirStockMenuItem.Visible = True
                    RavitaillementDuMagasinToolStripMenuItem.Visible = True
                    RajouterUnFournisseurToolStripMenuItem.Visible = True
                    RajouterUnServiceToolStripMenuItem.Visible = True
                End If
                MenuStrip.Enabled = True
                frmConnect.Close()
            End If
            myConn.Close()

        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            myConn.Dispose()
        End Try

        'Me.StatusStrip.Text = Me.Utilisateur

    End Sub

    Private Sub lblUser_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub AssurancesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AssurancesMenu.Click
        Dim frmNewInsurance As New frmAjoutAssurance
        'frmNewInsurance.MdiParent = Me
        frmNewInsurance.ShowDialog()
    End Sub

    Private Sub BonDePriseEnChargeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BonDePriseEnChargeMenu.Click
        Dim frmBonConfig As New frmPriseEnCharge
        'frmBonConfig.MdiParent = Me
        frmBonConfig.ShowDialog()
    End Sub

    Private Sub EncaissementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EncaissementMenu.Click
        Dim frm As New frmCaisseImpression
        'Dim frm As New fr
        frm.user = Utilisateur
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub RapportPériodiqueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Dim frm As New frmEtatJournalier
        Dim frm As New frmRapportRecette
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub RapportAnnuelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RapportAnnuelMenu.Click
        Dim frm As New frmEtatAnnuel
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub FacurationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FacurationMenuItem.Click
        Dim frmFacture As New frmCaisseFacturation
        frmFacture.MdiParent = Me
        frmFacture.Show()
        ''frmFacture.Text = Utilisateur
    End Sub

    Private Sub PaiementAvanceMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PaiementAvanceMenuItem.Click
        Dim frmAvance As New frmAvancePaie
        frmAvance.MdiParent = Me
        'frmRemboursement.Text = "Bonjour " & Me.Utilisateur
        frmAvance.Show()
    End Sub

    Private Sub PaiementDuRemboursementToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PaiementDuRemboursementMenu.Click
        Dim frmValidate As New frmValidateRemboursement
        frmValidate.MdiParent = Me
        ''frmValidate.Text = "Bonjour " & Me.Utilisateur
        frmValidate.Show()
    End Sub

    Private Sub BONDEPRISEENCHARGEToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmEtatCredit
        ' frm.txtuser.Text = Utilisateur
        frm.MdiParent = Me
        frm.Show()
    End Sub


    Private Sub CutusBPCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitusBPCMenu.Click
        Dim frm As New frmCutusBon
        frm.user = Utilisateur
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub EtatCreditMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EtatCreditMenu.Click
        Dim frm As New frmEtatCredit
        ' frm.txtuser.Text = Utilisateur
        'frm.MdiParent = Me
        frm.ShowDialog()
    End Sub

    Private Sub FacturePatientOrdinaireToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturePatientOrdinaireToolStripMenuItem.Click
        Dim frm As New frmEtatPatientOrdinaire
        ' frm.txtuser.Text = Utilisateur
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub PrescriptionsMenu_Click(sender As System.Object, e As System.EventArgs) Handles PrescriptionsMenu.Click
        Dim frm As New frmRapportPrescription
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub GestionCaissePrincipale_Click(sender As System.Object, e As System.EventArgs) Handles GestionCaissePrincipale.Click
        Dim frm As New frmGestionCaissePrincipale
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub RapportDEntréeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RapportDEntréeToolStripMenuItem.Click
        Dim frm As New frmRapportdentree
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub SuiviPrescripteurToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuiviPrescripteurToolStripMenuItem.Click
        Dim frm As New frmSuiviPrescription
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub EtatConsultationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EtatConsultationToolStripMenuItem.Click
        Dim frm As New frmEtatConsultation
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ListeDesPatientsÀCréditToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListeDesPatientsÀCréditToolStripMenuItem.Click
        Dim frm As New frmListeCredit
        ' frm.txtuser.Text = Utilisateur
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BalacePatientToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalacePatientToolStripMenuItem.Click
        Dim frm As New frmBalancePatients
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub RecapBonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecapBonToolStripMenuItem.Click
        Dim frm As New frmSelectionDateRecapBon
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub SyntheseBonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SyntheseBonToolStripMenuItem.Click
        Dim frm As New frmRecapSoinsCredit
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub RéimpressionFactureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReimpressionFactureToolStripMenuItem.Click
        Dim frm As New frmReimpressionFacture
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub RapportVenteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RapportVenteToolStripMenuItem.Click
        Dim frm As New frmRapportVente
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ConnectionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ConnectionToolStripMenuItem.Click
        Dim frmConn As New frmConnection
        frmConn.MdiParent = Me
        frmConn.Show()
    End Sub

    Private Sub PharmacieLivraisonMenu_Click(sender As System.Object, e As System.EventArgs) Handles LivraisonPatientMenu.Click
        Dim frmPharma As New frmPharmacieLivraisonPatients
        frmPharma.MdiParent = Me
        frmPharma.Show()
    End Sub

    Private Sub CommandeDeStockToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CommandeDeStockToolStripMenuItem.Click
        Dim frmCommande As New frmPharmacieCommandePharmacie
        frmCommande.MdiParent = Me
        frmCommande.Show()
    End Sub

    Private Sub PharmacieLivraisonServicesMenu_Click(sender As System.Object, e As System.EventArgs) Handles ValiderCommande.Click
        Dim frmValidate As New frmPharmacieValidationCommandePharmacie
        frmValidate.MdiParent = Me
        frmValidate.Show()
    End Sub

    Private Sub RavitaillementDuMagasinToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RavitaillementDuMagasinToolStripMenuItem.Click
        Dim frmMagasin As New frmPharmacieRavitaillementMagasin
        frmMagasin.MdiParent = Me
        frmMagasin.Show()
    End Sub

    Private Sub RajouterUnFournisseurToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RajouterUnFournisseurToolStripMenuItem.Click
        Dim frmAjoutFournisseur As New frmPharmacieRajoutFournisseur
        frmAjoutFournisseur.MdiParent = Me
        frmAjoutFournisseur.Show()
    End Sub

    Private Sub SuivieDeStockDesProduitsMenu_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub PrescriptionsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrescriptionsToolStripMenuItem.Click
        Dim frmPrescription As New frmPatientPrescription
        frmPrescription.MdiParent = Me
        frmPrescription.Show()
    End Sub

    Private Sub EnregistrementMenu_Click(sender As System.Object, e As System.EventArgs) Handles EnregistrementMenu.Click
        Dim frmPrescription As New frmPatientInscription
        frmPrescription.MdiParent = Me
        frmPrescription.Show()
    End Sub

    Private Sub StockDeLaPharmacieToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VoirStockMenuItem.Click
        Dim frmRapPharma As New frmRapportPharmacie
        frmRapPharma.MdiParent = Me
        frmRapPharma.Show()
    End Sub

    Private Sub NouvelUtilisateurToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NouvelUtilisateurToolStripMenuItem.Click
        Dim frmUser As New frmNewUser
        frmUser.MdiParent = Me
        frmUser.Show()
    End Sub

    Private Sub ModifierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmUpdate As New frmModifyUser
        frmUpdate.MdiParent = Me
        frmUpdate.Show()
    End Sub

    Private Sub RechercherMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RechercherMenu.Click
        Dim frmSearchUser As New frmPatientAdmission
        'frmSearchUser.MdiParent = Me
        frmSearchUser.ShowDialog()
    End Sub

    Private Sub AjoutDesProduitsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AjoutDesProduitsToolStripMenuItem.Click
        Dim frmProduct As New frmNewProduit
        frmProduct.ShowDialog()
    End Sub

    Private Sub AjouterDiagnostiquesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AjouterDiagnostiquesToolStripMenuItem.Click
        Dim frmDiag As New frmPatientDianostique
        frmDiag.ShowDialog()
    End Sub

    Private Sub DeconnectionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeconnectionToolStripMenuItem.Click
        Dim Qry As String
        Try
            myConn.Open()
            Qry = "UPDATE care_users SET personell_nr=0 WHERE login_id='" & Me.Id & "'"
            Comd = New MySqlCommand(Qry, myConn)
            Comd.ExecuteNonQuery()
            myConn.Close()
            myConn.Dispose()
            Controls.Clear()
            InitializeComponent()
            Me.frmMain_Load(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Care 2X!")
        Finally
            myConn.Close()
            myConn.Dispose()
        End Try
    End Sub

    Private Sub BPCMenu_Click(sender As System.Object, e As System.EventArgs) Handles BPCMenu.Click

    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Dim frmSearchUser As New frmPatientAdmission
        'frmSearchUser.MdiParent = Me
        frmSearchUser.ShowDialog()
    End Sub

    Private Sub btnAssurances_Click(sender As System.Object, e As System.EventArgs) Handles btnAssurances.Click
        Dim frmNewInsurance As New frmPriseEnCharge
        frmNewInsurance.txtSearch.Text = Me.lblId.Text
        frmNewInsurance.btnSearch_Click(sender, e)
        'GetPatientInformation(lblId, frmNewInsurance.txtInfos)
        'frmNewInsurance.MdiParent = Me
        frmNewInsurance.ShowDialog()
    End Sub

    Private Sub btnDiagnostic_Click(sender As System.Object, e As System.EventArgs) Handles btnDiagnostic.Click
        Dim frmDiag As New frmPatientDianostique
        frmDiag.Id = CLng(Me.lblId.Text)
        frmDiag.Utilisateur = Me.Utilisateur
        frmDiag.ShowDialog()
    End Sub

    Private Sub btnPrescription_Click(sender As System.Object, e As System.EventArgs) Handles btnPrescription.Click
        Dim frmPrescription As New frmPatientPrescription
        frmPrescription.Id = CLng(Me.lblId.Text)
        frmPrescription.ShowDialog()
    End Sub

    Private Sub btnLiberation_Click(sender As System.Object, e As System.EventArgs) Handles btnLiberation.Click
        Dim frmLiberation As New frmLiberationPatient
        frmLiberation.Id = CLng(Me.lblId.Text)
        frmLiberation.Utilisateur = Me.Utilisateur
        frmLiberation.ShowDialog()
    End Sub

    Private Sub RecapitulatifEncaissementToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RecapitulatifEncaissementToolStripMenuItem.Click

    End Sub

    Private Sub PrescripteursToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrescripteursToolStripMenuItem.Click
        Dim frmPrescriber As New frmRajoutPrescripteur
        frmPrescriber.ShowDialog()
    End Sub

End Class
