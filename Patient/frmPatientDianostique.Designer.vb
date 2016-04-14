<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatientDianostique
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatientDianostique))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.cboId = New System.Windows.Forms.ComboBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtInfos = New System.Windows.Forms.TextBox()
        Me.lblId = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.btnAjouter = New System.Windows.Forms.Button()
        Me.cboDiagnostique = New System.Windows.Forms.ComboBox()
        Me.dgvDiagnostiques = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpSearch.SuspendLayout()
        CType(Me.dgvDiagnostiques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(735, 420)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(122, 35)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Quitter"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grpSearch
        '
        Me.grpSearch.BackColor = System.Drawing.Color.Transparent
        Me.grpSearch.Controls.Add(Me.cboId)
        Me.grpSearch.Controls.Add(Me.txtId)
        Me.grpSearch.Controls.Add(Me.txtInfos)
        Me.grpSearch.Controls.Add(Me.lblId)
        Me.grpSearch.Location = New System.Drawing.Point(12, 12)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(845, 170)
        Me.grpSearch.TabIndex = 33
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Liberation Patient"
        '
        'cboId
        '
        Me.cboId.FormattingEnabled = True
        Me.cboId.Location = New System.Drawing.Point(464, 20)
        Me.cboId.Name = "cboId"
        Me.cboId.Size = New System.Drawing.Size(63, 28)
        Me.cboId.TabIndex = 39
        Me.cboId.Visible = False
        '
        'txtId
        '
        Me.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(88, 24)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(206, 20)
        Me.txtId.TabIndex = 32
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtInfos
        '
        Me.txtInfos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfos.Location = New System.Drawing.Point(6, 57)
        Me.txtInfos.Multiline = True
        Me.txtInfos.Name = "txtInfos"
        Me.txtInfos.ReadOnly = True
        Me.txtInfos.Size = New System.Drawing.Size(833, 100)
        Me.txtInfos.TabIndex = 26
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.Location = New System.Drawing.Point(6, 23)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(74, 20)
        Me.lblId.TabIndex = 24
        Me.lblId.Text = "Numero"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(18, 379)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(85, 20)
        Me.lblUser.TabIndex = 35
        Me.lblUser.Text = "Utilisateur"
        '
        'btnAjouter
        '
        Me.btnAjouter.Enabled = False
        Me.btnAjouter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAjouter.Location = New System.Drawing.Point(634, 62)
        Me.btnAjouter.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAjouter.Name = "btnAjouter"
        Me.btnAjouter.Size = New System.Drawing.Size(203, 35)
        Me.btnAjouter.TabIndex = 36
        Me.btnAjouter.Text = "Ajouter Diagnostique"
        Me.btnAjouter.UseVisualStyleBackColor = True
        '
        'cboDiagnostique
        '
        Me.cboDiagnostique.FormattingEnabled = True
        Me.cboDiagnostique.Location = New System.Drawing.Point(8, 26)
        Me.cboDiagnostique.Name = "cboDiagnostique"
        Me.cboDiagnostique.Size = New System.Drawing.Size(829, 28)
        Me.cboDiagnostique.TabIndex = 37
        '
        'dgvDiagnostiques
        '
        Me.dgvDiagnostiques.AllowUserToAddRows = False
        Me.dgvDiagnostiques.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        Me.dgvDiagnostiques.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDiagnostiques.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDiagnostiques.BackgroundColor = System.Drawing.Color.White
        Me.dgvDiagnostiques.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvDiagnostiques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDiagnostiques.Location = New System.Drawing.Point(8, 105)
        Me.dgvDiagnostiques.Name = "dgvDiagnostiques"
        Me.dgvDiagnostiques.ReadOnly = True
        Me.dgvDiagnostiques.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvDiagnostiques.RowTemplate.Height = 24
        Me.dgvDiagnostiques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDiagnostiques.Size = New System.Drawing.Size(829, 113)
        Me.dgvDiagnostiques.TabIndex = 39
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dgvDiagnostiques)
        Me.GroupBox1.Controls.Add(Me.btnAjouter)
        Me.GroupBox1.Controls.Add(Me.cboDiagnostique)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 188)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(843, 224)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Choisir les diagnostiques"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 20)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Diagnostiques"
        '
        'frmPatientDianostique
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(869, 465)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.btnClose)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPatientDianostique"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajouter diagnostique"
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        CType(Me.dgvDiagnostiques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents txtInfos As System.Windows.Forms.TextBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents btnAjouter As System.Windows.Forms.Button
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents cboId As System.Windows.Forms.ComboBox
    Friend WithEvents cboDiagnostique As System.Windows.Forms.ComboBox
    Friend WithEvents dgvDiagnostiques As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
