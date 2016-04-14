<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAjoutAssurance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAjoutAssurance))
        Me.grpAssurance = New System.Windows.Forms.GroupBox()
        Me.txtMaxPay = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkExclude = New System.Windows.Forms.CheckBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBP = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtInsurance = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.grpDataGrid = New System.Windows.Forms.GroupBox()
        Me.dgvInsurances = New System.Windows.Forms.DataGridView()
        Me.grpAssurance.SuspendLayout()
        Me.grpDataGrid.SuspendLayout()
        CType(Me.dgvInsurances, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpAssurance
        '
        Me.grpAssurance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grpAssurance.Controls.Add(Me.txtMaxPay)
        Me.grpAssurance.Controls.Add(Me.Label7)
        Me.grpAssurance.Controls.Add(Me.chkExclude)
        Me.grpAssurance.Controls.Add(Me.txtEmail)
        Me.grpAssurance.Controls.Add(Me.Label6)
        Me.grpAssurance.Controls.Add(Me.txtTel)
        Me.grpAssurance.Controls.Add(Me.Label5)
        Me.grpAssurance.Controls.Add(Me.txtCity)
        Me.grpAssurance.Controls.Add(Me.Label4)
        Me.grpAssurance.Controls.Add(Me.txtBP)
        Me.grpAssurance.Controls.Add(Me.Label3)
        Me.grpAssurance.Controls.Add(Me.txtContact)
        Me.grpAssurance.Controls.Add(Me.Label2)
        Me.grpAssurance.Controls.Add(Me.txtInsurance)
        Me.grpAssurance.Controls.Add(Me.Label1)
        Me.grpAssurance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.grpAssurance.Location = New System.Drawing.Point(16, 16)
        Me.grpAssurance.Margin = New System.Windows.Forms.Padding(4)
        Me.grpAssurance.Name = "grpAssurance"
        Me.grpAssurance.Padding = New System.Windows.Forms.Padding(4)
        Me.grpAssurance.Size = New System.Drawing.Size(827, 120)
        Me.grpAssurance.TabIndex = 0
        Me.grpAssurance.TabStop = False
        Me.grpAssurance.Text = "Information de l'Assurance"
        '
        'txtMaxPay
        '
        Me.txtMaxPay.Location = New System.Drawing.Point(102, 81)
        Me.txtMaxPay.Name = "txtMaxPay"
        Me.txtMaxPay.Size = New System.Drawing.Size(85, 28)
        Me.txtMaxPay.TabIndex = 7
        Me.txtMaxPay.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 23)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Plafond:"
        Me.Label7.Visible = False
        '
        'chkExclude
        '
        Me.chkExclude.AutoSize = True
        Me.chkExclude.Location = New System.Drawing.Point(231, 81)
        Me.chkExclude.Name = "chkExclude"
        Me.chkExclude.Size = New System.Drawing.Size(126, 27)
        Me.chkExclude.TabIndex = 8
        Me.chkExclude.Text = "A exclusion"
        Me.chkExclude.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(643, 54)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(177, 28)
        Me.txtEmail.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(588, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 23)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Email:"
        '
        'txtTel
        '
        Me.txtTel.Location = New System.Drawing.Point(458, 54)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Size = New System.Drawing.Size(124, 28)
        Me.txtTel.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(424, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 23)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Tel:"
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(231, 51)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(187, 28)
        Me.txtCity.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(178, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 23)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Ville:"
        '
        'txtBP
        '
        Me.txtBP.Location = New System.Drawing.Point(102, 51)
        Me.txtBP.Name = "txtBP"
        Me.txtBP.Size = New System.Drawing.Size(70, 28)
        Me.txtBP.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 23)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "BP:"
        '
        'txtContact
        '
        Me.txtContact.Location = New System.Drawing.Point(548, 21)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(272, 28)
        Me.txtContact.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(424, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Responsable:"
        '
        'txtInsurance
        '
        Me.txtInsurance.Location = New System.Drawing.Point(102, 21)
        Me.txtInsurance.Name = "txtInsurance"
        Me.txtInsurance.Size = New System.Drawing.Size(316, 28)
        Me.txtInsurance.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Assurance:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(732, 143)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(111, 31)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Enregistrer"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(732, 523)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(111, 31)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Terminer"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'grpDataGrid
        '
        Me.grpDataGrid.Controls.Add(Me.dgvInsurances)
        Me.grpDataGrid.Location = New System.Drawing.Point(12, 180)
        Me.grpDataGrid.Name = "grpDataGrid"
        Me.grpDataGrid.Size = New System.Drawing.Size(834, 337)
        Me.grpDataGrid.TabIndex = 3
        Me.grpDataGrid.TabStop = False
        Me.grpDataGrid.Text = "Liste des assurances"
        '
        'dgvInsurances
        '
        Me.dgvInsurances.AllowUserToAddRows = False
        Me.dgvInsurances.AllowUserToDeleteRows = False
        Me.dgvInsurances.BackgroundColor = System.Drawing.Color.White
        Me.dgvInsurances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInsurances.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInsurances.Location = New System.Drawing.Point(3, 24)
        Me.dgvInsurances.Name = "dgvInsurances"
        Me.dgvInsurances.ReadOnly = True
        Me.dgvInsurances.Size = New System.Drawing.Size(828, 310)
        Me.dgvInsurances.TabIndex = 0
        '
        'frmAjoutAssurance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 566)
        Me.Controls.Add(Me.grpDataGrid)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpAssurance)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAjoutAssurance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAjoutAssurance"
        Me.grpAssurance.ResumeLayout(False)
        Me.grpAssurance.PerformLayout()
        Me.grpDataGrid.ResumeLayout(False)
        CType(Me.dgvInsurances, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpAssurance As System.Windows.Forms.GroupBox
    Friend WithEvents txtMaxPay As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkExclude As System.Windows.Forms.CheckBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTel As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtBP As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtInsurance As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grpDataGrid As System.Windows.Forms.GroupBox
    Friend WithEvents dgvInsurances As System.Windows.Forms.DataGridView
End Class
