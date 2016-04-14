<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPharmacieLivraisonPatients
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.grpItems = New System.Windows.Forms.GroupBox()
        Me.dgvPrescriptions = New System.Windows.Forms.DataGridView()
        Me.grpInfo = New System.Windows.Forms.GroupBox()
        Me.txtInfos = New System.Windows.Forms.TextBox()
        Me.btnValidate = New System.Windows.Forms.Button()
        Me.lblNoProduct = New System.Windows.Forms.Label()
        Me.cboFactures = New System.Windows.Forms.ComboBox()
        Me.grpFactures = New System.Windows.Forms.GroupBox()
        Me.grpPrescriptions = New System.Windows.Forms.GroupBox()
        Me.grpSearch.SuspendLayout()
        Me.grpItems.SuspendLayout()
        CType(Me.dgvPrescriptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpInfo.SuspendLayout()
        Me.grpFactures.SuspendLayout()
        Me.grpPrescriptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(244, 22)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(149, 32)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Rechercher"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(8, 25)
        Me.txtId.Margin = New System.Windows.Forms.Padding(4)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(215, 28)
        Me.txtId.TabIndex = 0
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.txtId)
        Me.grpSearch.Controls.Add(Me.btnSearch)
        Me.grpSearch.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearch.ForeColor = System.Drawing.Color.Teal
        Me.grpSearch.Location = New System.Drawing.Point(16, 15)
        Me.grpSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Padding = New System.Windows.Forms.Padding(4)
        Me.grpSearch.Size = New System.Drawing.Size(405, 73)
        Me.grpSearch.TabIndex = 3
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Numero du patient"
        '
        'grpItems
        '
        Me.grpItems.Controls.Add(Me.dgvPrescriptions)
        Me.grpItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpItems.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpItems.Location = New System.Drawing.Point(4, 25)
        Me.grpItems.Margin = New System.Windows.Forms.Padding(4)
        Me.grpItems.Name = "grpItems"
        Me.grpItems.Padding = New System.Windows.Forms.Padding(4)
        Me.grpItems.Size = New System.Drawing.Size(603, 386)
        Me.grpItems.TabIndex = 4
        Me.grpItems.TabStop = False
        Me.grpItems.Text = "Liste des produits a livrer"
        Me.grpItems.Visible = False
        '
        'dgvPrescriptions
        '
        Me.dgvPrescriptions.AllowUserToAddRows = False
        Me.dgvPrescriptions.AllowUserToDeleteRows = False
        Me.dgvPrescriptions.AllowUserToResizeColumns = False
        Me.dgvPrescriptions.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        Me.dgvPrescriptions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPrescriptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPrescriptions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvPrescriptions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvPrescriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrescriptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrescriptions.Location = New System.Drawing.Point(4, 25)
        Me.dgvPrescriptions.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvPrescriptions.MultiSelect = False
        Me.dgvPrescriptions.Name = "dgvPrescriptions"
        Me.dgvPrescriptions.ReadOnly = True
        Me.dgvPrescriptions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvPrescriptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPrescriptions.ShowEditingIcon = False
        Me.dgvPrescriptions.Size = New System.Drawing.Size(595, 357)
        Me.dgvPrescriptions.TabIndex = 0
        '
        'grpInfo
        '
        Me.grpInfo.Controls.Add(Me.txtInfos)
        Me.grpInfo.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInfo.ForeColor = System.Drawing.Color.Teal
        Me.grpInfo.Location = New System.Drawing.Point(16, 95)
        Me.grpInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.grpInfo.Name = "grpInfo"
        Me.grpInfo.Padding = New System.Windows.Forms.Padding(4)
        Me.grpInfo.Size = New System.Drawing.Size(405, 122)
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
        Me.txtInfos.Size = New System.Drawing.Size(397, 93)
        Me.txtInfos.TabIndex = 4
        '
        'btnValidate
        '
        Me.btnValidate.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValidate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnValidate.Location = New System.Drawing.Point(816, 437)
        Me.btnValidate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnValidate.Name = "btnValidate"
        Me.btnValidate.Size = New System.Drawing.Size(220, 39)
        Me.btnValidate.TabIndex = 11
        Me.btnValidate.Text = "VALIDER LIVRAISON"
        Me.btnValidate.UseVisualStyleBackColor = True
        Me.btnValidate.Visible = False
        '
        'lblNoProduct
        '
        Me.lblNoProduct.AutoSize = True
        Me.lblNoProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoProduct.ForeColor = System.Drawing.Color.Red
        Me.lblNoProduct.Location = New System.Drawing.Point(13, 317)
        Me.lblNoProduct.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNoProduct.Name = "lblNoProduct"
        Me.lblNoProduct.Size = New System.Drawing.Size(390, 18)
        Me.lblNoProduct.TabIndex = 12
        Me.lblNoProduct.Text = "PAS DE PRODUITS A LIVRER POUR CE PATIENT"
        '
        'cboFactures
        '
        Me.cboFactures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFactures.FormattingEnabled = True
        Me.cboFactures.Location = New System.Drawing.Point(6, 21)
        Me.cboFactures.Name = "cboFactures"
        Me.cboFactures.Size = New System.Drawing.Size(180, 24)
        Me.cboFactures.TabIndex = 13
        '
        'grpFactures
        '
        Me.grpFactures.Controls.Add(Me.cboFactures)
        Me.grpFactures.Location = New System.Drawing.Point(16, 224)
        Me.grpFactures.Name = "grpFactures"
        Me.grpFactures.Size = New System.Drawing.Size(193, 58)
        Me.grpFactures.TabIndex = 14
        Me.grpFactures.TabStop = False
        Me.grpFactures.Text = "Liste des factures"
        '
        'grpPrescriptions
        '
        Me.grpPrescriptions.Controls.Add(Me.grpItems)
        Me.grpPrescriptions.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPrescriptions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grpPrescriptions.Location = New System.Drawing.Point(429, 15)
        Me.grpPrescriptions.Margin = New System.Windows.Forms.Padding(4)
        Me.grpPrescriptions.Name = "grpPrescriptions"
        Me.grpPrescriptions.Padding = New System.Windows.Forms.Padding(4)
        Me.grpPrescriptions.Size = New System.Drawing.Size(611, 415)
        Me.grpPrescriptions.TabIndex = 7
        Me.grpPrescriptions.TabStop = False
        Me.grpPrescriptions.Text = "LIVRAISON DES PRODUITS"
        Me.grpPrescriptions.Visible = False
        '
        'frmPharmacieLivraisonPatients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1052, 490)
        Me.Controls.Add(Me.grpFactures)
        Me.Controls.Add(Me.lblNoProduct)
        Me.Controls.Add(Me.btnValidate)
        Me.Controls.Add(Me.grpPrescriptions)
        Me.Controls.Add(Me.grpInfo)
        Me.Controls.Add(Me.grpSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmPharmacieLivraisonPatients"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paiement des Prescriptions"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.grpItems.ResumeLayout(False)
        CType(Me.dgvPrescriptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpInfo.ResumeLayout(False)
        Me.grpInfo.PerformLayout()
        Me.grpFactures.ResumeLayout(False)
        Me.grpPrescriptions.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents grpItems As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPrescriptions As System.Windows.Forms.DataGridView
    Friend WithEvents grpInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtInfos As System.Windows.Forms.TextBox
    Friend WithEvents btnValidate As System.Windows.Forms.Button
    Friend WithEvents lblNoProduct As System.Windows.Forms.Label
    Friend WithEvents cboFactures As System.Windows.Forms.ComboBox
    Friend WithEvents grpFactures As System.Windows.Forms.GroupBox
    Friend WithEvents grpPrescriptions As System.Windows.Forms.GroupBox
End Class
