<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatientPrescription
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatientPrescription))
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.grpInfo = New System.Windows.Forms.GroupBox()
        Me.txtInfos = New System.Windows.Forms.TextBox()
        Me.tabAllElements = New System.Windows.Forms.TabControl()
        Me.tabCarnets = New System.Windows.Forms.TabPage()
        Me.tabComprimes = New System.Windows.Forms.TabPage()
        Me.tabInjectables = New System.Windows.Forms.TabPage()
        Me.tabSollutes = New System.Windows.Forms.TabPage()
        Me.tabHospitalisation = New System.Windows.Forms.TabPage()
        Me.tabSuspension = New System.Windows.Forms.TabPage()
        Me.tabImagerie = New System.Windows.Forms.TabPage()
        Me.tabChirurgie = New System.Windows.Forms.TabPage()
        Me.tabServices = New System.Windows.Forms.TabPage()
        Me.tabLaboratoire = New System.Windows.Forms.TabPage()
        Me.lstPrescriptions = New System.Windows.Forms.ListBox()
        Me.lstAllActs = New System.Windows.Forms.ListBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPrescrire = New System.Windows.Forms.Button()
        Me.btnSupprimer = New System.Windows.Forms.Button()
        Me.btnModifier = New System.Windows.Forms.Button()
        Me.grpPrescriptions = New System.Windows.Forms.GroupBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.cboPrescripteur = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpSearch.SuspendLayout()
        Me.grpInfo.SuspendLayout()
        Me.tabAllElements.SuspendLayout()
        Me.grpPrescriptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Enabled = False
        Me.btnSearch.Location = New System.Drawing.Point(8, 62)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(167, 32)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Rechercher"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(8, 25)
        Me.txtId.Margin = New System.Windows.Forms.Padding(4)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(167, 28)
        Me.txtId.TabIndex = 0
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.txtId)
        Me.grpSearch.Controls.Add(Me.btnSearch)
        Me.grpSearch.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearch.ForeColor = System.Drawing.Color.Teal
        Me.grpSearch.Location = New System.Drawing.Point(13, 24)
        Me.grpSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Padding = New System.Windows.Forms.Padding(4)
        Me.grpSearch.Size = New System.Drawing.Size(192, 103)
        Me.grpSearch.TabIndex = 3
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Numero du patient"
        '
        'grpInfo
        '
        Me.grpInfo.Controls.Add(Me.txtInfos)
        Me.grpInfo.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInfo.ForeColor = System.Drawing.Color.Teal
        Me.grpInfo.Location = New System.Drawing.Point(215, 10)
        Me.grpInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.grpInfo.Name = "grpInfo"
        Me.grpInfo.Padding = New System.Windows.Forms.Padding(4)
        Me.grpInfo.Size = New System.Drawing.Size(441, 122)
        Me.grpInfo.TabIndex = 4
        Me.grpInfo.TabStop = False
        Me.grpInfo.Text = "Information sur le patient"
        Me.grpInfo.Visible = False
        '
        'txtInfos
        '
        Me.txtInfos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtInfos.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfos.Location = New System.Drawing.Point(4, 25)
        Me.txtInfos.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfos.Multiline = True
        Me.txtInfos.Name = "txtInfos"
        Me.txtInfos.ReadOnly = True
        Me.txtInfos.Size = New System.Drawing.Size(433, 93)
        Me.txtInfos.TabIndex = 4
        '
        'tabAllElements
        '
        Me.tabAllElements.Controls.Add(Me.tabCarnets)
        Me.tabAllElements.Controls.Add(Me.tabComprimes)
        Me.tabAllElements.Controls.Add(Me.tabInjectables)
        Me.tabAllElements.Controls.Add(Me.tabSollutes)
        Me.tabAllElements.Controls.Add(Me.tabHospitalisation)
        Me.tabAllElements.Controls.Add(Me.tabSuspension)
        Me.tabAllElements.Controls.Add(Me.tabImagerie)
        Me.tabAllElements.Controls.Add(Me.tabChirurgie)
        Me.tabAllElements.Controls.Add(Me.tabServices)
        Me.tabAllElements.Controls.Add(Me.tabLaboratoire)
        Me.tabAllElements.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabAllElements.Location = New System.Drawing.Point(8, 23)
        Me.tabAllElements.Margin = New System.Windows.Forms.Padding(4)
        Me.tabAllElements.Name = "tabAllElements"
        Me.tabAllElements.SelectedIndex = 0
        Me.tabAllElements.Size = New System.Drawing.Size(779, 34)
        Me.tabAllElements.TabIndex = 2
        '
        'tabCarnets
        '
        Me.tabCarnets.Location = New System.Drawing.Point(4, 29)
        Me.tabCarnets.Margin = New System.Windows.Forms.Padding(4)
        Me.tabCarnets.Name = "tabCarnets"
        Me.tabCarnets.Padding = New System.Windows.Forms.Padding(4)
        Me.tabCarnets.Size = New System.Drawing.Size(771, 1)
        Me.tabCarnets.TabIndex = 0
        Me.tabCarnets.Text = "Carnets/Consultations"
        Me.tabCarnets.UseVisualStyleBackColor = True
        '
        'tabComprimes
        '
        Me.tabComprimes.Location = New System.Drawing.Point(4, 29)
        Me.tabComprimes.Margin = New System.Windows.Forms.Padding(4)
        Me.tabComprimes.Name = "tabComprimes"
        Me.tabComprimes.Padding = New System.Windows.Forms.Padding(4)
        Me.tabComprimes.Size = New System.Drawing.Size(771, 1)
        Me.tabComprimes.TabIndex = 1
        Me.tabComprimes.Text = "Comprimes"
        Me.tabComprimes.UseVisualStyleBackColor = True
        '
        'tabInjectables
        '
        Me.tabInjectables.Location = New System.Drawing.Point(4, 29)
        Me.tabInjectables.Margin = New System.Windows.Forms.Padding(4)
        Me.tabInjectables.Name = "tabInjectables"
        Me.tabInjectables.Size = New System.Drawing.Size(771, 1)
        Me.tabInjectables.TabIndex = 2
        Me.tabInjectables.Text = "Injectables"
        Me.tabInjectables.UseVisualStyleBackColor = True
        '
        'tabSollutes
        '
        Me.tabSollutes.Location = New System.Drawing.Point(4, 29)
        Me.tabSollutes.Margin = New System.Windows.Forms.Padding(4)
        Me.tabSollutes.Name = "tabSollutes"
        Me.tabSollutes.Size = New System.Drawing.Size(771, 1)
        Me.tabSollutes.TabIndex = 3
        Me.tabSollutes.Text = "Sollutes"
        Me.tabSollutes.UseVisualStyleBackColor = True
        '
        'tabHospitalisation
        '
        Me.tabHospitalisation.Location = New System.Drawing.Point(4, 29)
        Me.tabHospitalisation.Margin = New System.Windows.Forms.Padding(4)
        Me.tabHospitalisation.Name = "tabHospitalisation"
        Me.tabHospitalisation.Size = New System.Drawing.Size(771, 1)
        Me.tabHospitalisation.TabIndex = 4
        Me.tabHospitalisation.Text = "Hospitalisation/Salles"
        Me.tabHospitalisation.UseVisualStyleBackColor = True
        '
        'tabSuspension
        '
        Me.tabSuspension.Location = New System.Drawing.Point(4, 29)
        Me.tabSuspension.Margin = New System.Windows.Forms.Padding(4)
        Me.tabSuspension.Name = "tabSuspension"
        Me.tabSuspension.Size = New System.Drawing.Size(771, 1)
        Me.tabSuspension.TabIndex = 5
        Me.tabSuspension.Text = "Suspensions/Suppo/Vaccins"
        Me.tabSuspension.UseVisualStyleBackColor = True
        '
        'tabImagerie
        '
        Me.tabImagerie.Location = New System.Drawing.Point(4, 29)
        Me.tabImagerie.Margin = New System.Windows.Forms.Padding(4)
        Me.tabImagerie.Name = "tabImagerie"
        Me.tabImagerie.Size = New System.Drawing.Size(771, 1)
        Me.tabImagerie.TabIndex = 6
        Me.tabImagerie.Text = "Imagerie"
        Me.tabImagerie.UseVisualStyleBackColor = True
        '
        'tabChirurgie
        '
        Me.tabChirurgie.Location = New System.Drawing.Point(4, 29)
        Me.tabChirurgie.Margin = New System.Windows.Forms.Padding(4)
        Me.tabChirurgie.Name = "tabChirurgie"
        Me.tabChirurgie.Size = New System.Drawing.Size(771, 1)
        Me.tabChirurgie.TabIndex = 7
        Me.tabChirurgie.Text = "Actes Chirurgie"
        Me.tabChirurgie.UseVisualStyleBackColor = True
        '
        'tabServices
        '
        Me.tabServices.Location = New System.Drawing.Point(4, 29)
        Me.tabServices.Margin = New System.Windows.Forms.Padding(4)
        Me.tabServices.Name = "tabServices"
        Me.tabServices.Size = New System.Drawing.Size(771, 1)
        Me.tabServices.TabIndex = 8
        Me.tabServices.Text = "Actes Services"
        Me.tabServices.UseVisualStyleBackColor = True
        '
        'tabLaboratoire
        '
        Me.tabLaboratoire.Location = New System.Drawing.Point(4, 29)
        Me.tabLaboratoire.Margin = New System.Windows.Forms.Padding(4)
        Me.tabLaboratoire.Name = "tabLaboratoire"
        Me.tabLaboratoire.Size = New System.Drawing.Size(771, 1)
        Me.tabLaboratoire.TabIndex = 9
        Me.tabLaboratoire.Text = "Laboratoire"
        Me.tabLaboratoire.UseVisualStyleBackColor = True
        '
        'lstPrescriptions
        '
        Me.lstPrescriptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPrescriptions.FormattingEnabled = True
        Me.lstPrescriptions.ItemHeight = 20
        Me.lstPrescriptions.Location = New System.Drawing.Point(6, 217)
        Me.lstPrescriptions.Margin = New System.Windows.Forms.Padding(4)
        Me.lstPrescriptions.Name = "lstPrescriptions"
        Me.lstPrescriptions.Size = New System.Drawing.Size(635, 144)
        Me.lstPrescriptions.TabIndex = 3
        '
        'lstAllActs
        '
        Me.lstAllActs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAllActs.FormattingEnabled = True
        Me.lstAllActs.ItemHeight = 20
        Me.lstAllActs.Location = New System.Drawing.Point(8, 65)
        Me.lstAllActs.Margin = New System.Windows.Forms.Padding(4)
        Me.lstAllActs.Name = "lstAllActs"
        Me.lstAllActs.Size = New System.Drawing.Size(779, 144)
        Me.lstAllActs.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(649, 328)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(138, 29)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Quitter"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPrescrire
        '
        Me.btnPrescrire.Location = New System.Drawing.Point(649, 291)
        Me.btnPrescrire.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPrescrire.Name = "btnPrescrire"
        Me.btnPrescrire.Size = New System.Drawing.Size(138, 29)
        Me.btnPrescrire.TabIndex = 2
        Me.btnPrescrire.Text = "Prescrire"
        Me.btnPrescrire.UseVisualStyleBackColor = True
        '
        'btnSupprimer
        '
        Me.btnSupprimer.Enabled = False
        Me.btnSupprimer.Location = New System.Drawing.Point(649, 254)
        Me.btnSupprimer.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSupprimer.Name = "btnSupprimer"
        Me.btnSupprimer.Size = New System.Drawing.Size(138, 29)
        Me.btnSupprimer.TabIndex = 1
        Me.btnSupprimer.Text = "Supprimer Element"
        Me.btnSupprimer.UseVisualStyleBackColor = True
        '
        'btnModifier
        '
        Me.btnModifier.Enabled = False
        Me.btnModifier.Location = New System.Drawing.Point(649, 217)
        Me.btnModifier.Margin = New System.Windows.Forms.Padding(4)
        Me.btnModifier.Name = "btnModifier"
        Me.btnModifier.Size = New System.Drawing.Size(138, 29)
        Me.btnModifier.TabIndex = 0
        Me.btnModifier.Text = "Modifier Quantite"
        Me.btnModifier.UseVisualStyleBackColor = True
        '
        'grpPrescriptions
        '
        Me.grpPrescriptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPrescriptions.Controls.Add(Me.Label1)
        Me.grpPrescriptions.Controls.Add(Me.cboPrescripteur)
        Me.grpPrescriptions.Controls.Add(Me.lblTotal)
        Me.grpPrescriptions.Controls.Add(Me.btnClose)
        Me.grpPrescriptions.Controls.Add(Me.txtTotal)
        Me.grpPrescriptions.Controls.Add(Me.lstAllActs)
        Me.grpPrescriptions.Controls.Add(Me.btnPrescrire)
        Me.grpPrescriptions.Controls.Add(Me.lstPrescriptions)
        Me.grpPrescriptions.Controls.Add(Me.btnSupprimer)
        Me.grpPrescriptions.Controls.Add(Me.tabAllElements)
        Me.grpPrescriptions.Controls.Add(Me.btnModifier)
        Me.grpPrescriptions.Enabled = False
        Me.grpPrescriptions.Location = New System.Drawing.Point(15, 140)
        Me.grpPrescriptions.Margin = New System.Windows.Forms.Padding(4)
        Me.grpPrescriptions.Name = "grpPrescriptions"
        Me.grpPrescriptions.Padding = New System.Windows.Forms.Padding(4)
        Me.grpPrescriptions.Size = New System.Drawing.Size(795, 432)
        Me.grpPrescriptions.TabIndex = 8
        Me.grpPrescriptions.TabStop = False
        Me.grpPrescriptions.Text = "ELEMENTS DISPONIBLE POUR PRESCRIPTION"
        Me.grpPrescriptions.Visible = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(603, 365)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(180, 20)
        Me.lblTotal.TabIndex = 9
        Me.lblTotal.Text = "Total de la prescription"
        '
        'txtTotal
        '
        Me.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotal.Enabled = False
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.DarkRed
        Me.txtTotal.Location = New System.Drawing.Point(607, 389)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(176, 30)
        Me.txtTotal.TabIndex = 10
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboPrescripteur
        '
        Me.cboPrescripteur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrescripteur.FormattingEnabled = True
        Me.cboPrescripteur.Location = New System.Drawing.Point(7, 396)
        Me.cboPrescripteur.Name = "cboPrescripteur"
        Me.cboPrescripteur.Size = New System.Drawing.Size(288, 24)
        Me.cboPrescripteur.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 373)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(235, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Medecin/Infirmier Prescripteur"
        '
        'frmPatientPrescription
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(827, 585)
        Me.Controls.Add(Me.grpPrescriptions)
        Me.Controls.Add(Me.grpInfo)
        Me.Controls.Add(Me.grpSearch)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPatientPrescription"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prescriptions"
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.grpInfo.ResumeLayout(False)
        Me.grpInfo.PerformLayout()
        Me.tabAllElements.ResumeLayout(False)
        Me.grpPrescriptions.ResumeLayout(False)
        Me.grpPrescriptions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents grpInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtInfos As System.Windows.Forms.TextBox
    Friend WithEvents tabAllElements As System.Windows.Forms.TabControl
    Friend WithEvents tabCarnets As System.Windows.Forms.TabPage
    Friend WithEvents tabComprimes As System.Windows.Forms.TabPage
    Friend WithEvents lstPrescriptions As System.Windows.Forms.ListBox
    Friend WithEvents tabInjectables As System.Windows.Forms.TabPage
    Friend WithEvents tabSollutes As System.Windows.Forms.TabPage
    Friend WithEvents tabHospitalisation As System.Windows.Forms.TabPage
    Friend WithEvents tabSuspension As System.Windows.Forms.TabPage
    Friend WithEvents tabImagerie As System.Windows.Forms.TabPage
    Friend WithEvents tabChirurgie As System.Windows.Forms.TabPage
    Friend WithEvents tabServices As System.Windows.Forms.TabPage
    Friend WithEvents lstAllActs As System.Windows.Forms.ListBox
    Friend WithEvents btnModifier As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPrescrire As System.Windows.Forms.Button
    Friend WithEvents btnSupprimer As System.Windows.Forms.Button
    Friend WithEvents grpPrescriptions As System.Windows.Forms.GroupBox
    Friend WithEvents tabLaboratoire As System.Windows.Forms.TabPage
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPrescripteur As System.Windows.Forms.ComboBox
End Class
