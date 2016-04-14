<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatientInscription
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
        Me.btnInscrire = New System.Windows.Forms.Button()
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
        Me.txtAge = New System.Windows.Forms.TextBox()
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
        Me.grpPrescriptions.SuspendLayout()
        Me.grpStatus.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpSanguin.SuspendLayout()
        Me.grpSexe.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnInscrire
        '
        Me.btnInscrire.Location = New System.Drawing.Point(499, 295)
        Me.btnInscrire.Margin = New System.Windows.Forms.Padding(4)
        Me.btnInscrire.Name = "btnInscrire"
        Me.btnInscrire.Size = New System.Drawing.Size(182, 34)
        Me.btnInscrire.TabIndex = 15
        Me.btnInscrire.Text = "Inscrire"
        Me.btnInscrire.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(499, 337)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(182, 34)
        Me.btnClose.TabIndex = 16
        Me.btnClose.Text = "Quitter"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grpPrescriptions
        '
        Me.grpPrescriptions.Controls.Add(Me.txtTelephone)
        Me.grpPrescriptions.Controls.Add(Me.btnClose)
        Me.grpPrescriptions.Controls.Add(Me.Label11)
        Me.grpPrescriptions.Controls.Add(Me.btnInscrire)
        Me.grpPrescriptions.Controls.Add(Me.txtBP)
        Me.grpPrescriptions.Controls.Add(Me.Label10)
        Me.grpPrescriptions.Controls.Add(Me.txtVille)
        Me.grpPrescriptions.Controls.Add(Me.Label9)
        Me.grpPrescriptions.Controls.Add(Me.grpStatus)
        Me.grpPrescriptions.Controls.Add(Me.GroupBox1)
        Me.grpPrescriptions.Controls.Add(Me.grpSanguin)
        Me.grpPrescriptions.Controls.Add(Me.grpSexe)
        Me.grpPrescriptions.Controls.Add(Me.txtAge)
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
        Me.grpPrescriptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPrescriptions.Location = New System.Drawing.Point(16, 15)
        Me.grpPrescriptions.Margin = New System.Windows.Forms.Padding(4)
        Me.grpPrescriptions.Name = "grpPrescriptions"
        Me.grpPrescriptions.Padding = New System.Windows.Forms.Padding(4)
        Me.grpPrescriptions.Size = New System.Drawing.Size(689, 387)
        Me.grpPrescriptions.TabIndex = 8
        Me.grpPrescriptions.TabStop = False
        Me.grpPrescriptions.Text = "INSCRIPTION"
        '
        'txtTelephone
        '
        Me.txtTelephone.Location = New System.Drawing.Point(121, 333)
        Me.txtTelephone.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTelephone.Name = "txtTelephone"
        Me.txtTelephone.Size = New System.Drawing.Size(253, 26)
        Me.txtTelephone.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(27, 336)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 20)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Telephone:"
        '
        'txtBP
        '
        Me.txtBP.Location = New System.Drawing.Point(420, 299)
        Me.txtBP.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBP.Name = "txtBP"
        Me.txtBP.Size = New System.Drawing.Size(71, 26)
        Me.txtBP.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(382, 302)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 20)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "BP"
        '
        'txtVille
        '
        Me.txtVille.Location = New System.Drawing.Point(121, 299)
        Me.txtVille.Margin = New System.Windows.Forms.Padding(4)
        Me.txtVille.Name = "txtVille"
        Me.txtVille.Size = New System.Drawing.Size(253, 26)
        Me.txtVille.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 302)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 20)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Ville/Quartier:"
        '
        'grpStatus
        '
        Me.grpStatus.Controls.Add(Me.radSepare)
        Me.grpStatus.Controls.Add(Me.radVeuf)
        Me.grpStatus.Controls.Add(Me.radDivorce)
        Me.grpStatus.Controls.Add(Me.radMarie)
        Me.grpStatus.Controls.Add(Me.radCelibataire)
        Me.grpStatus.Location = New System.Drawing.Point(8, 233)
        Me.grpStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Padding = New System.Windows.Forms.Padding(4)
        Me.grpStatus.Size = New System.Drawing.Size(673, 58)
        Me.grpStatus.TabIndex = 11
        Me.grpStatus.TabStop = False
        Me.grpStatus.Text = "Groupe Sanguin"
        '
        'radSepare
        '
        Me.radSepare.AutoSize = True
        Me.radSepare.Location = New System.Drawing.Point(497, 26)
        Me.radSepare.Margin = New System.Windows.Forms.Padding(4)
        Me.radSepare.Name = "radSepare"
        Me.radSepare.Size = New System.Drawing.Size(104, 24)
        Me.radSepare.TabIndex = 4
        Me.radSepare.Text = "Separe(e)"
        Me.radSepare.UseVisualStyleBackColor = True
        '
        'radVeuf
        '
        Me.radVeuf.AutoSize = True
        Me.radVeuf.Location = New System.Drawing.Point(373, 26)
        Me.radVeuf.Margin = New System.Windows.Forms.Padding(4)
        Me.radVeuf.Name = "radVeuf"
        Me.radVeuf.Size = New System.Drawing.Size(110, 24)
        Me.radVeuf.TabIndex = 3
        Me.radVeuf.Text = "Veu(f) (ve)"
        Me.radVeuf.UseVisualStyleBackColor = True
        '
        'radDivorce
        '
        Me.radDivorce.AutoSize = True
        Me.radDivorce.Location = New System.Drawing.Point(247, 26)
        Me.radDivorce.Margin = New System.Windows.Forms.Padding(4)
        Me.radDivorce.Name = "radDivorce"
        Me.radDivorce.Size = New System.Drawing.Size(109, 24)
        Me.radDivorce.TabIndex = 2
        Me.radDivorce.Text = "Divorce(e)"
        Me.radDivorce.UseVisualStyleBackColor = True
        '
        'radMarie
        '
        Me.radMarie.AutoSize = True
        Me.radMarie.Location = New System.Drawing.Point(137, 26)
        Me.radMarie.Margin = New System.Windows.Forms.Padding(4)
        Me.radMarie.Name = "radMarie"
        Me.radMarie.Size = New System.Drawing.Size(93, 24)
        Me.radMarie.TabIndex = 1
        Me.radMarie.Text = "Marie(e)"
        Me.radMarie.UseVisualStyleBackColor = True
        '
        'radCelibataire
        '
        Me.radCelibataire.AutoSize = True
        Me.radCelibataire.Checked = True
        Me.radCelibataire.Location = New System.Drawing.Point(8, 26)
        Me.radCelibataire.Margin = New System.Windows.Forms.Padding(4)
        Me.radCelibataire.Name = "radCelibataire"
        Me.radCelibataire.Size = New System.Drawing.Size(110, 24)
        Me.radCelibataire.TabIndex = 0
        Me.radCelibataire.TabStop = True
        Me.radCelibataire.Text = "Celibataire"
        Me.radCelibataire.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radNeg)
        Me.GroupBox1.Controls.Add(Me.radPos)
        Me.GroupBox1.Location = New System.Drawing.Point(483, 167)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(198, 58)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rhesus"
        '
        'radNeg
        '
        Me.radNeg.AutoSize = True
        Me.radNeg.Location = New System.Drawing.Point(93, 26)
        Me.radNeg.Margin = New System.Windows.Forms.Padding(4)
        Me.radNeg.Name = "radNeg"
        Me.radNeg.Size = New System.Drawing.Size(83, 24)
        Me.radNeg.TabIndex = 1
        Me.radNeg.TabStop = True
        Me.radNeg.Text = "Negatif"
        Me.radNeg.UseVisualStyleBackColor = True
        '
        'radPos
        '
        Me.radPos.AutoSize = True
        Me.radPos.Location = New System.Drawing.Point(8, 26)
        Me.radPos.Margin = New System.Windows.Forms.Padding(4)
        Me.radPos.Name = "radPos"
        Me.radPos.Size = New System.Drawing.Size(77, 24)
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
        Me.grpSanguin.Location = New System.Drawing.Point(236, 167)
        Me.grpSanguin.Margin = New System.Windows.Forms.Padding(4)
        Me.grpSanguin.Name = "grpSanguin"
        Me.grpSanguin.Padding = New System.Windows.Forms.Padding(4)
        Me.grpSanguin.Size = New System.Drawing.Size(239, 58)
        Me.grpSanguin.TabIndex = 9
        Me.grpSanguin.TabStop = False
        Me.grpSanguin.Text = "Groupe Sanguin"
        '
        'radO
        '
        Me.radO.AutoSize = True
        Me.radO.Location = New System.Drawing.Point(184, 26)
        Me.radO.Margin = New System.Windows.Forms.Padding(4)
        Me.radO.Name = "radO"
        Me.radO.Size = New System.Drawing.Size(43, 24)
        Me.radO.TabIndex = 3
        Me.radO.Text = "O"
        Me.radO.UseVisualStyleBackColor = True
        '
        'radAB
        '
        Me.radAB.AutoSize = True
        Me.radAB.Location = New System.Drawing.Point(117, 26)
        Me.radAB.Margin = New System.Windows.Forms.Padding(4)
        Me.radAB.Name = "radAB"
        Me.radAB.Size = New System.Drawing.Size(53, 24)
        Me.radAB.TabIndex = 2
        Me.radAB.Text = "AB"
        Me.radAB.UseVisualStyleBackColor = True
        '
        'radB
        '
        Me.radB.AutoSize = True
        Me.radB.Location = New System.Drawing.Point(63, 26)
        Me.radB.Margin = New System.Windows.Forms.Padding(4)
        Me.radB.Name = "radB"
        Me.radB.Size = New System.Drawing.Size(42, 24)
        Me.radB.TabIndex = 1
        Me.radB.Text = "B"
        Me.radB.UseVisualStyleBackColor = True
        '
        'radA
        '
        Me.radA.AutoSize = True
        Me.radA.Location = New System.Drawing.Point(8, 26)
        Me.radA.Margin = New System.Windows.Forms.Padding(4)
        Me.radA.Name = "radA"
        Me.radA.Size = New System.Drawing.Size(41, 24)
        Me.radA.TabIndex = 0
        Me.radA.Text = "A"
        Me.radA.UseVisualStyleBackColor = True
        '
        'grpSexe
        '
        Me.grpSexe.Controls.Add(Me.radFem)
        Me.grpSexe.Controls.Add(Me.radMas)
        Me.grpSexe.Location = New System.Drawing.Point(8, 167)
        Me.grpSexe.Margin = New System.Windows.Forms.Padding(4)
        Me.grpSexe.Name = "grpSexe"
        Me.grpSexe.Padding = New System.Windows.Forms.Padding(4)
        Me.grpSexe.Size = New System.Drawing.Size(220, 58)
        Me.grpSexe.TabIndex = 8
        Me.grpSexe.TabStop = False
        Me.grpSexe.Text = "Sexe"
        '
        'radFem
        '
        Me.radFem.AutoSize = True
        Me.radFem.Location = New System.Drawing.Point(115, 26)
        Me.radFem.Margin = New System.Windows.Forms.Padding(4)
        Me.radFem.Name = "radFem"
        Me.radFem.Size = New System.Drawing.Size(89, 24)
        Me.radFem.TabIndex = 1
        Me.radFem.Text = "Feminin"
        Me.radFem.UseVisualStyleBackColor = True
        '
        'radMas
        '
        Me.radMas.AutoSize = True
        Me.radMas.Checked = True
        Me.radMas.Location = New System.Drawing.Point(8, 26)
        Me.radMas.Margin = New System.Windows.Forms.Padding(4)
        Me.radMas.Name = "radMas"
        Me.radMas.Size = New System.Drawing.Size(97, 24)
        Me.radMas.TabIndex = 0
        Me.radMas.TabStop = True
        Me.radMas.Text = "Masculin"
        Me.radMas.UseVisualStyleBackColor = True
        '
        'txtAge
        '
        Me.txtAge.Location = New System.Drawing.Point(303, 99)
        Me.txtAge.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Size = New System.Drawing.Size(71, 26)
        Me.txtAge.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(234, 102)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 20)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "ou Age"
        '
        'dtpDate
        '
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(105, 99)
        Me.dtpDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDate.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.dtpDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(121, 26)
        Me.dtpDate.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 102)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 20)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Ne(e) le:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(407, 104)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 20)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Tribu:"
        '
        'cboTribe
        '
        Me.cboTribe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTribe.FormattingEnabled = True
        Me.cboTribe.Location = New System.Drawing.Point(462, 99)
        Me.cboTribe.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTribe.Name = "cboTribe"
        Me.cboTribe.Size = New System.Drawing.Size(219, 28)
        Me.cboTribe.TabIndex = 6
        '
        'txtPrenoms
        '
        Me.txtPrenoms.Location = New System.Drawing.Point(462, 68)
        Me.txtPrenoms.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPrenoms.Name = "txtPrenoms"
        Me.txtPrenoms.Size = New System.Drawing.Size(219, 26)
        Me.txtPrenoms.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(377, 71)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 20)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Prenoms:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(105, 65)
        Me.txtName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(269, 26)
        Me.txtName.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 68)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 20)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Noms:"
        '
        'txtProfession
        '
        Me.txtProfession.Location = New System.Drawing.Point(105, 133)
        Me.txtProfession.Margin = New System.Windows.Forms.Padding(4)
        Me.txtProfession.Name = "txtProfession"
        Me.txtProfession.Size = New System.Drawing.Size(269, 26)
        Me.txtProfession.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 136)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Profession:"
        '
        'txtHeure
        '
        Me.txtHeure.Enabled = False
        Me.txtHeure.Location = New System.Drawing.Point(569, 20)
        Me.txtHeure.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHeure.Name = "txtHeure"
        Me.txtHeure.Size = New System.Drawing.Size(101, 26)
        Me.txtHeure.TabIndex = 2
        Me.txtHeure.TabStop = False
        Me.txtHeure.Visible = False
        '
        'txtDate
        '
        Me.txtDate.Enabled = False
        Me.txtDate.Location = New System.Drawing.Point(105, 31)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(269, 26)
        Me.txtDate.TabIndex = 1
        Me.txtDate.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(471, 23)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Heure"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Date:"
        '
        'frmPatientInscription
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(723, 416)
        Me.Controls.Add(Me.grpPrescriptions)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPatientInscription"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paiement des Prescriptions"
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
    Friend WithEvents btnInscrire As System.Windows.Forms.Button
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
    Friend WithEvents txtAge As System.Windows.Forms.TextBox
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
