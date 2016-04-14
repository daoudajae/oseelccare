<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatientSearch
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
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.grpInfo = New System.Windows.Forms.GroupBox()
        Me.txtInfos = New System.Windows.Forms.TextBox()
        Me.btnPrescrire = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpPrescriptions = New System.Windows.Forms.GroupBox()
        Me.txtTelephone = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtBP = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtVille = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.radSepare = New System.Windows.Forms.RadioButton()
        Me.radVeuf = New System.Windows.Forms.RadioButton()
        Me.radDivorce = New System.Windows.Forms.RadioButton()
        Me.radMarie = New System.Windows.Forms.RadioButton()
        Me.radCelibataire = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.radNeg = New System.Windows.Forms.RadioButton()
        Me.radPos = New System.Windows.Forms.RadioButton()
        Me.grpSanguin = New System.Windows.Forms.GroupBox()
        Me.radO = New System.Windows.Forms.RadioButton()
        Me.radAB = New System.Windows.Forms.RadioButton()
        Me.radB = New System.Windows.Forms.RadioButton()
        Me.radA = New System.Windows.Forms.RadioButton()
        Me.grpSexe = New System.Windows.Forms.GroupBox()
        Me.radFem = New System.Windows.Forms.RadioButton()
        Me.radMas = New System.Windows.Forms.RadioButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboTribe = New System.Windows.Forms.ComboBox()
        Me.txtPrenoms = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProfession = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHeure = New System.Windows.Forms.TextBox()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpSearch.SuspendLayout()
        Me.grpInfo.SuspendLayout()
        Me.grpPrescriptions.SuspendLayout()
        Me.grpStatus.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpSanguin.SuspendLayout()
        Me.grpSexe.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Enabled = False
        Me.btnSearch.Location = New System.Drawing.Point(6, 50)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(162, 32)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Rechercher"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(6, 20)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(162, 24)
        Me.txtId.TabIndex = 0
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.txtId)
        Me.grpSearch.Controls.Add(Me.btnSearch)
        Me.grpSearch.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearch.ForeColor = System.Drawing.Color.Teal
        Me.grpSearch.Location = New System.Drawing.Point(11, 9)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(174, 99)
        Me.grpSearch.TabIndex = 3
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Numero du patient"
        '
        'grpInfo
        '
        Me.grpInfo.Controls.Add(Me.txtInfos)
        Me.grpInfo.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInfo.ForeColor = System.Drawing.Color.Teal
        Me.grpInfo.Location = New System.Drawing.Point(191, 9)
        Me.grpInfo.Name = "grpInfo"
        Me.grpInfo.Size = New System.Drawing.Size(352, 99)
        Me.grpInfo.TabIndex = 4
        Me.grpInfo.TabStop = False
        Me.grpInfo.Text = "Information sur le patient"
        Me.grpInfo.Visible = False
        '
        'txtInfos
        '
        Me.txtInfos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtInfos.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfos.Location = New System.Drawing.Point(3, 20)
        Me.txtInfos.Multiline = True
        Me.txtInfos.Name = "txtInfos"
        Me.txtInfos.ReadOnly = True
        Me.txtInfos.Size = New System.Drawing.Size(346, 76)
        Me.txtInfos.TabIndex = 4
        '
        'btnPrescrire
        '
        Me.btnPrescrire.Location = New System.Drawing.Point(363, 330)
        Me.btnPrescrire.Name = "btnPrescrire"
        Me.btnPrescrire.Size = New System.Drawing.Size(163, 28)
        Me.btnPrescrire.TabIndex = 2
        Me.btnPrescrire.Text = "Inscrire"
        Me.btnPrescrire.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(363, 364)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(163, 28)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Quitter"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grpPrescriptions
        '
        Me.grpPrescriptions.Controls.Add(Me.txtTelephone)
        Me.grpPrescriptions.Controls.Add(Me.btnClose)
        Me.grpPrescriptions.Controls.Add(Me.Label11)
        Me.grpPrescriptions.Controls.Add(Me.btnPrescrire)
        Me.grpPrescriptions.Controls.Add(Me.txtBP)
        Me.grpPrescriptions.Controls.Add(Me.Label10)
        Me.grpPrescriptions.Controls.Add(Me.txtVille)
        Me.grpPrescriptions.Controls.Add(Me.Label9)
        Me.grpPrescriptions.Controls.Add(Me.grpStatus)
        Me.grpPrescriptions.Controls.Add(Me.GroupBox1)
        Me.grpPrescriptions.Controls.Add(Me.grpSanguin)
        Me.grpPrescriptions.Controls.Add(Me.grpSexe)
        Me.grpPrescriptions.Controls.Add(Me.TextBox1)
        Me.grpPrescriptions.Controls.Add(Me.Label8)
        Me.grpPrescriptions.Controls.Add(Me.dtpDate)
        Me.grpPrescriptions.Controls.Add(Me.Label7)
        Me.grpPrescriptions.Controls.Add(Me.Label6)
        Me.grpPrescriptions.Controls.Add(Me.cboTribe)
        Me.grpPrescriptions.Controls.Add(Me.txtPrenoms)
        Me.grpPrescriptions.Controls.Add(Me.Label5)
        Me.grpPrescriptions.Controls.Add(Me.txtName)
        Me.grpPrescriptions.Controls.Add(Me.Label4)
        Me.grpPrescriptions.Controls.Add(Me.txtProfession)
        Me.grpPrescriptions.Controls.Add(Me.Label3)
        Me.grpPrescriptions.Controls.Add(Me.txtHeure)
        Me.grpPrescriptions.Controls.Add(Me.txtDate)
        Me.grpPrescriptions.Controls.Add(Me.Label2)
        Me.grpPrescriptions.Controls.Add(Me.Label1)
        Me.grpPrescriptions.Enabled = False
        Me.grpPrescriptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPrescriptions.Location = New System.Drawing.Point(11, 114)
        Me.grpPrescriptions.Name = "grpPrescriptions"
        Me.grpPrescriptions.Size = New System.Drawing.Size(532, 403)
        Me.grpPrescriptions.TabIndex = 8
        Me.grpPrescriptions.TabStop = False
        Me.grpPrescriptions.Text = "INSCRIPTION"
        Me.grpPrescriptions.Visible = False
        '
        'txtTelephone
        '
        Me.txtTelephone.Location = New System.Drawing.Point(333, 302)
        Me.txtTelephone.Name = "txtTelephone"
        Me.txtTelephone.Size = New System.Drawing.Size(166, 22)
        Me.txtTelephone.TabIndex = 31
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(330, 283)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 16)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Telephone"
        '
        'txtBP
        '
        Me.txtBP.Location = New System.Drawing.Point(237, 302)
        Me.txtBP.Name = "txtBP"
        Me.txtBP.Size = New System.Drawing.Size(90, 22)
        Me.txtBP.TabIndex = 29
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(234, 283)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 16)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "BP"
        '
        'txtVille
        '
        Me.txtVille.Location = New System.Drawing.Point(6, 302)
        Me.txtVille.Name = "txtVille"
        Me.txtVille.Size = New System.Drawing.Size(225, 22)
        Me.txtVille.TabIndex = 27
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 283)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 16)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Ville/Quartier"
        '
        'grpStatus
        '
        Me.grpStatus.Controls.Add(Me.radSepare)
        Me.grpStatus.Controls.Add(Me.radVeuf)
        Me.grpStatus.Controls.Add(Me.radDivorce)
        Me.grpStatus.Controls.Add(Me.radMarie)
        Me.grpStatus.Controls.Add(Me.radCelibataire)
        Me.grpStatus.Location = New System.Drawing.Point(6, 230)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Size = New System.Drawing.Size(520, 47)
        Me.grpStatus.TabIndex = 25
        Me.grpStatus.TabStop = False
        Me.grpStatus.Text = "Groupe Sanguin"
        '
        'radSepare
        '
        Me.radSepare.AutoSize = True
        Me.radSepare.Location = New System.Drawing.Point(373, 21)
        Me.radSepare.Name = "radSepare"
        Me.radSepare.Size = New System.Drawing.Size(87, 20)
        Me.radSepare.TabIndex = 4
        Me.radSepare.TabStop = True
        Me.radSepare.Text = "Separe(e)"
        Me.radSepare.UseVisualStyleBackColor = True
        '
        'radVeuf
        '
        Me.radVeuf.AutoSize = True
        Me.radVeuf.Location = New System.Drawing.Point(280, 21)
        Me.radVeuf.Name = "radVeuf"
        Me.radVeuf.Size = New System.Drawing.Size(87, 20)
        Me.radVeuf.TabIndex = 3
        Me.radVeuf.TabStop = True
        Me.radVeuf.Text = "Veu(f) (ve)"
        Me.radVeuf.UseVisualStyleBackColor = True
        '
        'radDivorce
        '
        Me.radDivorce.AutoSize = True
        Me.radDivorce.Location = New System.Drawing.Point(185, 21)
        Me.radDivorce.Name = "radDivorce"
        Me.radDivorce.Size = New System.Drawing.Size(89, 20)
        Me.radDivorce.TabIndex = 2
        Me.radDivorce.TabStop = True
        Me.radDivorce.Text = "Divorce(e)"
        Me.radDivorce.UseVisualStyleBackColor = True
        '
        'radMarie
        '
        Me.radMarie.AutoSize = True
        Me.radMarie.Location = New System.Drawing.Point(103, 21)
        Me.radMarie.Name = "radMarie"
        Me.radMarie.Size = New System.Drawing.Size(76, 20)
        Me.radMarie.TabIndex = 1
        Me.radMarie.TabStop = True
        Me.radMarie.Text = "Marie(e)"
        Me.radMarie.UseVisualStyleBackColor = True
        '
        'radCelibataire
        '
        Me.radCelibataire.AutoSize = True
        Me.radCelibataire.Location = New System.Drawing.Point(6, 21)
        Me.radCelibataire.Name = "radCelibataire"
        Me.radCelibataire.Size = New System.Drawing.Size(91, 20)
        Me.radCelibataire.TabIndex = 0
        Me.radCelibataire.TabStop = True
        Me.radCelibataire.Text = "Celibataire"
        Me.radCelibataire.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radNeg)
        Me.GroupBox1.Controls.Add(Me.radPos)
        Me.GroupBox1.Location = New System.Drawing.Point(362, 177)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(165, 47)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rhesus"
        '
        'radNeg
        '
        Me.radNeg.AutoSize = True
        Me.radNeg.Location = New System.Drawing.Point(86, 21)
        Me.radNeg.Name = "radNeg"
        Me.radNeg.Size = New System.Drawing.Size(69, 20)
        Me.radNeg.TabIndex = 1
        Me.radNeg.TabStop = True
        Me.radNeg.Text = "Negatif"
        Me.radNeg.UseVisualStyleBackColor = True
        '
        'radPos
        '
        Me.radPos.AutoSize = True
        Me.radPos.Location = New System.Drawing.Point(6, 21)
        Me.radPos.Name = "radPos"
        Me.radPos.Size = New System.Drawing.Size(62, 20)
        Me.radPos.TabIndex = 0
        Me.radPos.TabStop = True
        Me.radPos.Text = "Positif"
        Me.radPos.UseVisualStyleBackColor = True
        '
        'grpSanguin
        '
        Me.grpSanguin.Controls.Add(Me.radO)
        Me.grpSanguin.Controls.Add(Me.radAB)
        Me.grpSanguin.Controls.Add(Me.radB)
        Me.grpSanguin.Controls.Add(Me.radA)
        Me.grpSanguin.Location = New System.Drawing.Point(177, 177)
        Me.grpSanguin.Name = "grpSanguin"
        Me.grpSanguin.Size = New System.Drawing.Size(179, 47)
        Me.grpSanguin.TabIndex = 24
        Me.grpSanguin.TabStop = False
        Me.grpSanguin.Text = "Groupe Sanguin"
        '
        'radO
        '
        Me.radO.AutoSize = True
        Me.radO.Location = New System.Drawing.Point(138, 21)
        Me.radO.Name = "radO"
        Me.radO.Size = New System.Drawing.Size(36, 20)
        Me.radO.TabIndex = 3
        Me.radO.TabStop = True
        Me.radO.Text = "O"
        Me.radO.UseVisualStyleBackColor = True
        '
        'radAB
        '
        Me.radAB.AutoSize = True
        Me.radAB.Location = New System.Drawing.Point(88, 21)
        Me.radAB.Name = "radAB"
        Me.radAB.Size = New System.Drawing.Size(44, 20)
        Me.radAB.TabIndex = 2
        Me.radAB.TabStop = True
        Me.radAB.Text = "AB"
        Me.radAB.UseVisualStyleBackColor = True
        '
        'radB
        '
        Me.radB.AutoSize = True
        Me.radB.Location = New System.Drawing.Point(47, 21)
        Me.radB.Name = "radB"
        Me.radB.Size = New System.Drawing.Size(35, 20)
        Me.radB.TabIndex = 1
        Me.radB.TabStop = True
        Me.radB.Text = "B"
        Me.radB.UseVisualStyleBackColor = True
        '
        'radA
        '
        Me.radA.AutoSize = True
        Me.radA.Location = New System.Drawing.Point(6, 21)
        Me.radA.Name = "radA"
        Me.radA.Size = New System.Drawing.Size(35, 20)
        Me.radA.TabIndex = 0
        Me.radA.TabStop = True
        Me.radA.Text = "A"
        Me.radA.UseVisualStyleBackColor = True
        '
        'grpSexe
        '
        Me.grpSexe.Controls.Add(Me.radFem)
        Me.grpSexe.Controls.Add(Me.radMas)
        Me.grpSexe.Location = New System.Drawing.Point(6, 177)
        Me.grpSexe.Name = "grpSexe"
        Me.grpSexe.Size = New System.Drawing.Size(165, 47)
        Me.grpSexe.TabIndex = 23
        Me.grpSexe.TabStop = False
        Me.grpSexe.Text = "Sexe"
        '
        'radFem
        '
        Me.radFem.AutoSize = True
        Me.radFem.Location = New System.Drawing.Point(86, 21)
        Me.radFem.Name = "radFem"
        Me.radFem.Size = New System.Drawing.Size(73, 20)
        Me.radFem.TabIndex = 1
        Me.radFem.TabStop = True
        Me.radFem.Text = "Feminin"
        Me.radFem.UseVisualStyleBackColor = True
        '
        'radMas
        '
        Me.radMas.AutoSize = True
        Me.radMas.Location = New System.Drawing.Point(6, 21)
        Me.radMas.Name = "radMas"
        Me.radMas.Size = New System.Drawing.Size(79, 20)
        Me.radMas.TabIndex = 0
        Me.radMas.TabStop = True
        Me.radMas.Text = "Masculin"
        Me.radMas.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(237, 145)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(62, 22)
        Me.TextBox1.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(234, 126)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 16)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "ou Age"
        '
        'dtpDate
        '
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(139, 147)
        Me.dtpDate.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.dtpDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(92, 22)
        Me.dtpDate.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(136, 126)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 16)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Ne(e) le:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 16)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Tribu"
        '
        'cboTribe
        '
        Me.cboTribe.FormattingEnabled = True
        Me.cboTribe.Location = New System.Drawing.Point(9, 145)
        Me.cboTribe.Name = "cboTribe"
        Me.cboTribe.Size = New System.Drawing.Size(121, 24)
        Me.cboTribe.TabIndex = 17
        '
        'txtPrenoms
        '
        Me.txtPrenoms.Location = New System.Drawing.Point(191, 97)
        Me.txtPrenoms.Name = "txtPrenoms"
        Me.txtPrenoms.Size = New System.Drawing.Size(165, 22)
        Me.txtPrenoms.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(187, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 16)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Prenoms"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(9, 97)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(176, 22)
        Me.txtName.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Noms"
        '
        'txtProfession
        '
        Me.txtProfession.Location = New System.Drawing.Point(180, 47)
        Me.txtProfession.Name = "txtProfession"
        Me.txtProfession.Size = New System.Drawing.Size(176, 22)
        Me.txtProfession.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(177, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Profession"
        '
        'txtHeure
        '
        Me.txtHeure.Location = New System.Drawing.Point(97, 47)
        Me.txtHeure.Name = "txtHeure"
        Me.txtHeure.Size = New System.Drawing.Size(77, 22)
        Me.txtHeure.TabIndex = 10
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(9, 47)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(82, 22)
        Me.txtDate.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(94, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Heure"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Date"
        '
        'frmPatientInscription
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(555, 530)
        Me.Controls.Add(Me.grpPrescriptions)
        Me.Controls.Add(Me.grpInfo)
        Me.Controls.Add(Me.grpSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPatientInscription"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paiement des Prescriptions"
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.grpInfo.ResumeLayout(False)
        Me.grpInfo.PerformLayout()
        Me.grpPrescriptions.ResumeLayout(False)
        Me.grpPrescriptions.PerformLayout()
        Me.grpStatus.ResumeLayout(False)
        Me.grpStatus.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpSanguin.ResumeLayout(False)
        Me.grpSanguin.PerformLayout()
        Me.grpSexe.ResumeLayout(False)
        Me.grpSexe.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents grpInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtInfos As System.Windows.Forms.TextBox
    Friend WithEvents btnPrescrire As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents grpPrescriptions As System.Windows.Forms.GroupBox
    Friend WithEvents txtTelephone As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtBP As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtVille As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents radSepare As System.Windows.Forms.RadioButton
    Friend WithEvents radVeuf As System.Windows.Forms.RadioButton
    Friend WithEvents radDivorce As System.Windows.Forms.RadioButton
    Friend WithEvents radMarie As System.Windows.Forms.RadioButton
    Friend WithEvents radCelibataire As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radNeg As System.Windows.Forms.RadioButton
    Friend WithEvents radPos As System.Windows.Forms.RadioButton
    Friend WithEvents grpSanguin As System.Windows.Forms.GroupBox
    Friend WithEvents radO As System.Windows.Forms.RadioButton
    Friend WithEvents radAB As System.Windows.Forms.RadioButton
    Friend WithEvents radB As System.Windows.Forms.RadioButton
    Friend WithEvents radA As System.Windows.Forms.RadioButton
    Friend WithEvents grpSexe As System.Windows.Forms.GroupBox
    Friend WithEvents radFem As System.Windows.Forms.RadioButton
    Friend WithEvents radMas As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboTribe As System.Windows.Forms.ComboBox
    Friend WithEvents txtPrenoms As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtProfession As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHeure As System.Windows.Forms.TextBox
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
