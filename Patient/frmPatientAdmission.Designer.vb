<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatientAdmission
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatientAdmission))
        Me.btnInscrire = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpPrescriptions = New System.Windows.Forms.GroupBox()
        Me.txtGroupe = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSex = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTelephone = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtVille = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProfession = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboServices = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboDept = New System.Windows.Forms.ComboBox()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMessage = New System.Windows.Forms.Label()
        Me.picCross = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvSearchResult = New System.Windows.Forms.DataGridView()
        Me.btnDiagnostique = New System.Windows.Forms.Button()
        Me.grpPrescriptions.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpSearch.SuspendLayout()
        CType(Me.picCross, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvSearchResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnInscrire
        '
        Me.btnInscrire.Location = New System.Drawing.Point(567, 23)
        Me.btnInscrire.Margin = New System.Windows.Forms.Padding(5)
        Me.btnInscrire.Name = "btnInscrire"
        Me.btnInscrire.Size = New System.Drawing.Size(177, 35)
        Me.btnInscrire.TabIndex = 2
        Me.btnInscrire.Text = "Admettre"
        Me.btnInscrire.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(634, 590)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(122, 35)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Quitter"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grpPrescriptions
        '
        Me.grpPrescriptions.BackColor = System.Drawing.Color.Silver
        Me.grpPrescriptions.Controls.Add(Me.txtGroupe)
        Me.grpPrescriptions.Controls.Add(Me.Label12)
        Me.grpPrescriptions.Controls.Add(Me.txtStatus)
        Me.grpPrescriptions.Controls.Add(Me.Label10)
        Me.grpPrescriptions.Controls.Add(Me.txtSex)
        Me.grpPrescriptions.Controls.Add(Me.Label7)
        Me.grpPrescriptions.Controls.Add(Me.txtId)
        Me.grpPrescriptions.Controls.Add(Me.Label5)
        Me.grpPrescriptions.Controls.Add(Me.txtTelephone)
        Me.grpPrescriptions.Controls.Add(Me.Label11)
        Me.grpPrescriptions.Controls.Add(Me.txtVille)
        Me.grpPrescriptions.Controls.Add(Me.Label9)
        Me.grpPrescriptions.Controls.Add(Me.txtAge)
        Me.grpPrescriptions.Controls.Add(Me.Label8)
        Me.grpPrescriptions.Controls.Add(Me.txtName)
        Me.grpPrescriptions.Controls.Add(Me.Label4)
        Me.grpPrescriptions.Controls.Add(Me.txtProfession)
        Me.grpPrescriptions.Controls.Add(Me.Label3)
        Me.grpPrescriptions.Controls.Add(Me.txtDate)
        Me.grpPrescriptions.Controls.Add(Me.Label1)
        Me.grpPrescriptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPrescriptions.Location = New System.Drawing.Point(12, 329)
        Me.grpPrescriptions.Margin = New System.Windows.Forms.Padding(5)
        Me.grpPrescriptions.Name = "grpPrescriptions"
        Me.grpPrescriptions.Padding = New System.Windows.Forms.Padding(5)
        Me.grpPrescriptions.Size = New System.Drawing.Size(764, 177)
        Me.grpPrescriptions.TabIndex = 8
        Me.grpPrescriptions.TabStop = False
        Me.grpPrescriptions.Text = "Informations du Patient"
        '
        'txtGroupe
        '
        Me.txtGroupe.Location = New System.Drawing.Point(675, 101)
        Me.txtGroupe.Margin = New System.Windows.Forms.Padding(5)
        Me.txtGroupe.Name = "txtGroupe"
        Me.txtGroupe.ReadOnly = True
        Me.txtGroupe.Size = New System.Drawing.Size(67, 26)
        Me.txtGroupe.TabIndex = 37
        Me.txtGroupe.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(624, 104)
        Me.Label12.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 20)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "Grp."
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(172, 137)
        Me.txtStatus.Margin = New System.Windows.Forms.Padding(5)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(152, 26)
        Me.txtStatus.TabIndex = 35
        Me.txtStatus.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(105, 140)
        Me.Label10.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 20)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Status"
        '
        'txtSex
        '
        Me.txtSex.Location = New System.Drawing.Point(364, 101)
        Me.txtSex.Margin = New System.Windows.Forms.Padding(5)
        Me.txtSex.Name = "txtSex"
        Me.txtSex.ReadOnly = True
        Me.txtSex.Size = New System.Drawing.Size(41, 26)
        Me.txtSex.TabIndex = 33
        Me.txtSex.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(308, 104)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 20)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Sexe"
        '
        'txtId
        '
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtId.Location = New System.Drawing.Point(501, 29)
        Me.txtId.Margin = New System.Windows.Forms.Padding(5)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(243, 27)
        Me.txtId.TabIndex = 31
        Me.txtId.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(400, 32)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 20)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "No. Patient"
        '
        'txtTelephone
        '
        Me.txtTelephone.Location = New System.Drawing.Point(622, 137)
        Me.txtTelephone.Margin = New System.Windows.Forms.Padding(5)
        Me.txtTelephone.Name = "txtTelephone"
        Me.txtTelephone.ReadOnly = True
        Me.txtTelephone.Size = New System.Drawing.Size(122, 26)
        Me.txtTelephone.TabIndex = 14
        Me.txtTelephone.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(526, 140)
        Me.Label11.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 20)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Telephone"
        '
        'txtVille
        '
        Me.txtVille.Location = New System.Drawing.Point(364, 137)
        Me.txtVille.Margin = New System.Windows.Forms.Padding(5)
        Me.txtVille.Name = "txtVille"
        Me.txtVille.ReadOnly = True
        Me.txtVille.Size = New System.Drawing.Size(152, 26)
        Me.txtVille.TabIndex = 12
        Me.txtVille.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(334, 140)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 20)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "A"
        '
        'txtAge
        '
        Me.txtAge.Location = New System.Drawing.Point(172, 101)
        Me.txtAge.Margin = New System.Windows.Forms.Padding(5)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.ReadOnly = True
        Me.txtAge.Size = New System.Drawing.Size(126, 26)
        Me.txtAge.TabIndex = 5
        Me.txtAge.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(111, 104)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 20)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Ne(e)"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(172, 65)
        Me.txtName.Margin = New System.Windows.Forms.Padding(5)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(572, 26)
        Me.txtName.TabIndex = 2
        Me.txtName.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 65)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 20)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Noms et Prenoms"
        '
        'txtProfession
        '
        Me.txtProfession.Location = New System.Drawing.Point(469, 101)
        Me.txtProfession.Margin = New System.Windows.Forms.Padding(5)
        Me.txtProfession.Name = "txtProfession"
        Me.txtProfession.ReadOnly = True
        Me.txtProfession.Size = New System.Drawing.Size(143, 26)
        Me.txtProfession.TabIndex = 7
        Me.txtProfession.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(415, 104)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Prof."
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(172, 29)
        Me.txtDate.Margin = New System.Windows.Forms.Padding(5)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(209, 26)
        Me.txtDate.TabIndex = 1
        Me.txtDate.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 32)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Date d'Insription"
        '
        'cboServices
        '
        Me.cboServices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServices.FormattingEnabled = True
        Me.cboServices.Location = New System.Drawing.Point(172, 27)
        Me.cboServices.Margin = New System.Windows.Forms.Padding(4)
        Me.cboServices.Name = "cboServices"
        Me.cboServices.Size = New System.Drawing.Size(386, 28)
        Me.cboServices.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 30)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 20)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Choix du Service"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboServices)
        Me.GroupBox1.Controls.Add(Me.btnInscrire)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 514)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(764, 68)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Admission dans un service"
        '
        'cboDept
        '
        Me.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDept.FormattingEnabled = True
        Me.cboDept.Location = New System.Drawing.Point(12, 12)
        Me.cboDept.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(82, 28)
        Me.cboDept.TabIndex = 32
        Me.cboDept.Visible = False
        '
        'grpSearch
        '
        Me.grpSearch.BackColor = System.Drawing.Color.LightSkyBlue
        Me.grpSearch.Controls.Add(Me.btnSearch)
        Me.grpSearch.Controls.Add(Me.txtSearch)
        Me.grpSearch.Controls.Add(Me.Label6)
        Me.grpSearch.Location = New System.Drawing.Point(186, 13)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(590, 111)
        Me.grpSearch.TabIndex = 33
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Recherche"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(460, 65)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(5)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(122, 35)
        Me.btnSearch.TabIndex = 16
        Me.btnSearch.Text = "Recherche"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(172, 28)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(5)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(410, 27)
        Me.txtSearch.TabIndex = 14
        Me.txtSearch.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 31)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(148, 20)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Numero du Patient"
        '
        'txtMessage
        '
        Me.txtMessage.AutoSize = True
        Me.txtMessage.Location = New System.Drawing.Point(11, 124)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(68, 20)
        Me.txtMessage.TabIndex = 34
        Me.txtMessage.Text = "Label13"
        Me.txtMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picCross
        '
        Me.picCross.Image = CType(resources.GetObject("picCross.Image"), System.Drawing.Image)
        Me.picCross.Location = New System.Drawing.Point(123, 12)
        Me.picCross.Name = "picCross"
        Me.picCross.Size = New System.Drawing.Size(44, 76)
        Me.picCross.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCross.TabIndex = 35
        Me.picCross.TabStop = False
        Me.picCross.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvSearchResult)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 147)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(764, 169)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Resultat"
        Me.GroupBox2.Visible = False
        '
        'dgvSearchResult
        '
        Me.dgvSearchResult.AllowUserToAddRows = False
        Me.dgvSearchResult.AllowUserToDeleteRows = False
        Me.dgvSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearchResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSearchResult.Location = New System.Drawing.Point(3, 23)
        Me.dgvSearchResult.Name = "dgvSearchResult"
        Me.dgvSearchResult.ReadOnly = True
        Me.dgvSearchResult.RowTemplate.Height = 24
        Me.dgvSearchResult.Size = New System.Drawing.Size(758, 143)
        Me.dgvSearchResult.TabIndex = 0
        '
        'btnDiagnostique
        '
        Me.btnDiagnostique.Location = New System.Drawing.Point(431, 590)
        Me.btnDiagnostique.Margin = New System.Windows.Forms.Padding(5)
        Me.btnDiagnostique.Name = "btnDiagnostique"
        Me.btnDiagnostique.Size = New System.Drawing.Size(193, 35)
        Me.btnDiagnostique.TabIndex = 32
        Me.btnDiagnostique.Text = "Ajouter Diagnostique"
        Me.btnDiagnostique.UseVisualStyleBackColor = True
        Me.btnDiagnostique.Visible = False
        '
        'frmPatientAdmission
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(792, 636)
        Me.Controls.Add(Me.btnDiagnostique)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.picCross)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.cboDept)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpPrescriptions)
        Me.Controls.Add(Me.btnClose)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPatientAdmission"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admission Patient"
        Me.grpPrescriptions.ResumeLayout(False)
        Me.grpPrescriptions.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        CType(Me.picCross, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvSearchResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnInscrire As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents grpPrescriptions As System.Windows.Forms.GroupBox
    Friend WithEvents txtTelephone As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtVille As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAge As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtProfession As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboServices As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboDept As System.Windows.Forms.ComboBox
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSex As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtGroupe As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtMessage As System.Windows.Forms.Label
    Friend WithEvents picCross As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvSearchResult As System.Windows.Forms.DataGridView
    Friend WithEvents btnDiagnostique As System.Windows.Forms.Button
End Class
