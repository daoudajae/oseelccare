<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPriseEnCharge
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
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.grpInfo = New System.Windows.Forms.GroupBox()
        Me.txtInfos = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnValidate = New System.Windows.Forms.Button()
        Me.grpBon = New System.Windows.Forms.GroupBox()
        Me.cboRelation = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDiscount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboQuality = New System.Windows.Forms.ComboBox()
        Me.lblQuality = New System.Windows.Forms.Label()
        Me.chkExclusion = New System.Windows.Forms.CheckBox()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboInsurance = New System.Windows.Forms.ComboBox()
        Me.lblSociete = New System.Windows.Forms.Label()
        Me.grpSearch.SuspendLayout()
        Me.grpInfo.SuspendLayout()
        Me.grpBon.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.btnSearch)
        Me.grpSearch.Controls.Add(Me.txtSearch)
        Me.grpSearch.Location = New System.Drawing.Point(12, 14)
        Me.grpSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpSearch.Size = New System.Drawing.Size(386, 66)
        Me.grpSearch.TabIndex = 0
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Rechercher le patient"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(167, 27)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(154, 32)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Rechercher"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(9, 28)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(150, 31)
        Me.txtSearch.TabIndex = 0
        '
        'grpInfo
        '
        Me.grpInfo.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.grpInfo.Controls.Add(Me.txtInfos)
        Me.grpInfo.Controls.Add(Me.btnCancel)
        Me.grpInfo.Controls.Add(Me.btnValidate)
        Me.grpInfo.Controls.Add(Me.grpBon)
        Me.grpInfo.Enabled = False
        Me.grpInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grpInfo.Location = New System.Drawing.Point(12, 98)
        Me.grpInfo.Name = "grpInfo"
        Me.grpInfo.Size = New System.Drawing.Size(406, 435)
        Me.grpInfo.TabIndex = 2
        Me.grpInfo.TabStop = False
        Me.grpInfo.Text = "Information du patient"
        '
        'txtInfos
        '
        Me.txtInfos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfos.Location = New System.Drawing.Point(6, 30)
        Me.txtInfos.Multiline = True
        Me.txtInfos.Name = "txtInfos"
        Me.txtInfos.ReadOnly = True
        Me.txtInfos.Size = New System.Drawing.Size(391, 100)
        Me.txtInfos.TabIndex = 27
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(257, 394)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(121, 31)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "Terminer"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnValidate
        '
        Me.btnValidate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnValidate.Enabled = False
        Me.btnValidate.Location = New System.Drawing.Point(143, 394)
        Me.btnValidate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnValidate.Name = "btnValidate"
        Me.btnValidate.Size = New System.Drawing.Size(106, 31)
        Me.btnValidate.TabIndex = 11
        Me.btnValidate.Text = "Valider"
        Me.btnValidate.UseVisualStyleBackColor = True
        '
        'grpBon
        '
        Me.grpBon.BackColor = System.Drawing.Color.Transparent
        Me.grpBon.Controls.Add(Me.cboRelation)
        Me.grpBon.Controls.Add(Me.Label5)
        Me.grpBon.Controls.Add(Me.txtContact)
        Me.grpBon.Controls.Add(Me.Label4)
        Me.grpBon.Controls.Add(Me.txtDiscount)
        Me.grpBon.Controls.Add(Me.Label3)
        Me.grpBon.Controls.Add(Me.cboQuality)
        Me.grpBon.Controls.Add(Me.lblQuality)
        Me.grpBon.Controls.Add(Me.chkExclusion)
        Me.grpBon.Controls.Add(Me.cboType)
        Me.grpBon.Controls.Add(Me.Label1)
        Me.grpBon.Controls.Add(Me.cboInsurance)
        Me.grpBon.Controls.Add(Me.lblSociete)
        Me.grpBon.Location = New System.Drawing.Point(10, 175)
        Me.grpBon.Name = "grpBon"
        Me.grpBon.Size = New System.Drawing.Size(387, 183)
        Me.grpBon.TabIndex = 3
        Me.grpBon.TabStop = False
        Me.grpBon.Text = "Parametrage du Bon"
        '
        'cboRelation
        '
        Me.cboRelation.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRelation.FormattingEnabled = True
        Me.cboRelation.Items.AddRange(New Object() {"Soi-même", "Epoux(se)", "Enfant", "Parent", "Autre Famille", "Société"})
        Me.cboRelation.Location = New System.Drawing.Point(9, 142)
        Me.cboRelation.Name = "cboRelation"
        Me.cboRelation.Size = New System.Drawing.Size(104, 29)
        Me.cboRelation.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(9, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 23)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Relation:"
        '
        'txtContact
        '
        Me.txtContact.Location = New System.Drawing.Point(188, 94)
        Me.txtContact.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(189, 31)
        Me.txtContact.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(189, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 23)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Assuré:"
        '
        'txtDiscount
        '
        Me.txtDiscount.Location = New System.Drawing.Point(124, 93)
        Me.txtDiscount.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.Size = New System.Drawing.Size(56, 31)
        Me.txtDiscount.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(138, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 23)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "%:"
        '
        'cboQuality
        '
        Me.cboQuality.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboQuality.FormattingEnabled = True
        Me.cboQuality.Items.AddRange(New Object() {"Directeurs", "Cadres", "Non Cadres", "Famille Cadres"})
        Me.cboQuality.Location = New System.Drawing.Point(127, 142)
        Me.cboQuality.Name = "cboQuality"
        Me.cboQuality.Size = New System.Drawing.Size(80, 29)
        Me.cboQuality.TabIndex = 9
        Me.cboQuality.Visible = False
        '
        'lblQuality
        '
        Me.lblQuality.AutoSize = True
        Me.lblQuality.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuality.ForeColor = System.Drawing.Color.Blue
        Me.lblQuality.Location = New System.Drawing.Point(124, 122)
        Me.lblQuality.Name = "lblQuality"
        Me.lblQuality.Size = New System.Drawing.Size(73, 23)
        Me.lblQuality.TabIndex = 7
        Me.lblQuality.Text = "Qualité:"
        Me.lblQuality.Visible = False
        '
        'chkExclusion
        '
        Me.chkExclusion.AutoSize = True
        Me.chkExclusion.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkExclusion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkExclusion.Location = New System.Drawing.Point(213, 144)
        Me.chkExclusion.Name = "chkExclusion"
        Me.chkExclusion.Size = New System.Drawing.Size(125, 27)
        Me.chkExclusion.TabIndex = 10
        Me.chkExclusion.Text = "A Exclusion"
        Me.chkExclusion.UseVisualStyleBackColor = True
        Me.chkExclusion.Visible = False
        '
        'cboType
        '
        Me.cboType.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"100%", "Personnel", "Clergé", "Société", "Plafond", "Mutuelle"})
        Me.cboType.Location = New System.Drawing.Point(9, 93)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(111, 29)
        Me.cboType.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(6, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Type:"
        '
        'cboInsurance
        '
        Me.cboInsurance.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInsurance.FormattingEnabled = True
        Me.cboInsurance.Location = New System.Drawing.Point(9, 46)
        Me.cboInsurance.Name = "cboInsurance"
        Me.cboInsurance.Size = New System.Drawing.Size(371, 29)
        Me.cboInsurance.TabIndex = 3
        '
        'lblSociete
        '
        Me.lblSociete.AutoSize = True
        Me.lblSociete.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSociete.ForeColor = System.Drawing.Color.Blue
        Me.lblSociete.Location = New System.Drawing.Point(6, 26)
        Me.lblSociete.Name = "lblSociete"
        Me.lblSociete.Size = New System.Drawing.Size(75, 23)
        Me.lblSociete.TabIndex = 2
        Me.lblSociete.Text = "Société:"
        '
        'frmPriseEnCharge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 545)
        Me.Controls.Add(Me.grpInfo)
        Me.Controls.Add(Me.grpSearch)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPriseEnCharge"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parametrage Bon de Prise en Charge"
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.grpInfo.ResumeLayout(False)
        Me.grpInfo.PerformLayout()
        Me.grpBon.ResumeLayout(False)
        Me.grpBon.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents grpInfo As System.Windows.Forms.GroupBox
    Friend WithEvents grpBon As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnValidate As System.Windows.Forms.Button
    Friend WithEvents txtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboQuality As System.Windows.Forms.ComboBox
    Friend WithEvents lblQuality As System.Windows.Forms.Label
    Friend WithEvents chkExclusion As System.Windows.Forms.CheckBox
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboInsurance As System.Windows.Forms.ComboBox
    Friend WithEvents lblSociete As System.Windows.Forms.Label
    Friend WithEvents cboRelation As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtInfos As System.Windows.Forms.TextBox
End Class
