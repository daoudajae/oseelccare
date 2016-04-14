<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRemboursement
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
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.grpRembourser = New System.Windows.Forms.GroupBox()
        Me.btnValidate = New System.Windows.Forms.Button()
        Me.txtAAvancer = New System.Windows.Forms.TextBox()
        Me.txtFacture = New System.Windows.Forms.TextBox()
        Me.grpAvance = New System.Windows.Forms.GroupBox()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtInfos = New System.Windows.Forms.TextBox()
        Me.grpTotalFacture = New System.Windows.Forms.GroupBox()
        Me.txtAvances = New System.Windows.Forms.TextBox()
        Me.grpReste = New System.Windows.Forms.GroupBox()
        Me.txtReste = New System.Windows.Forms.TextBox()
        Me.cboChoixFacture = New System.Windows.Forms.ComboBox()
        Me.dgvElements = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpSearch.SuspendLayout()
        Me.grpRembourser.SuspendLayout()
        Me.grpAvance.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpTotalFacture.SuspendLayout()
        Me.grpReste.SuspendLayout()
        CType(Me.dgvElements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.btnSearch)
        Me.grpSearch.Controls.Add(Me.txtSearch)
        Me.grpSearch.Location = New System.Drawing.Point(17, 14)
        Me.grpSearch.Margin = New System.Windows.Forms.Padding(5)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Padding = New System.Windows.Forms.Padding(5)
        Me.grpSearch.Size = New System.Drawing.Size(337, 68)
        Me.grpSearch.TabIndex = 2
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Rechercher Patient"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(196, 27)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(131, 32)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Rechercher"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(10, 32)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(5)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(173, 22)
        Me.txtSearch.TabIndex = 0
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grpRembourser
        '
        Me.grpRembourser.Controls.Add(Me.btnValidate)
        Me.grpRembourser.Controls.Add(Me.txtAAvancer)
        Me.grpRembourser.Enabled = False
        Me.grpRembourser.Location = New System.Drawing.Point(364, 421)
        Me.grpRembourser.Margin = New System.Windows.Forms.Padding(5)
        Me.grpRembourser.Name = "grpRembourser"
        Me.grpRembourser.Padding = New System.Windows.Forms.Padding(5)
        Me.grpRembourser.Size = New System.Drawing.Size(337, 56)
        Me.grpRembourser.TabIndex = 4
        Me.grpRembourser.TabStop = False
        Me.grpRembourser.Text = "Montant a avancer"
        '
        'btnValidate
        '
        Me.btnValidate.Location = New System.Drawing.Point(192, 21)
        Me.btnValidate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnValidate.Name = "btnValidate"
        Me.btnValidate.Size = New System.Drawing.Size(131, 28)
        Me.btnValidate.TabIndex = 3
        Me.btnValidate.Text = "Valider"
        Me.btnValidate.UseVisualStyleBackColor = True
        '
        'txtAAvancer
        '
        Me.txtAAvancer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAAvancer.Location = New System.Drawing.Point(10, 23)
        Me.txtAAvancer.Margin = New System.Windows.Forms.Padding(5)
        Me.txtAAvancer.Name = "txtAAvancer"
        Me.txtAAvancer.ReadOnly = True
        Me.txtAAvancer.Size = New System.Drawing.Size(173, 22)
        Me.txtAAvancer.TabIndex = 0
        Me.txtAAvancer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFacture
        '
        Me.txtFacture.BackColor = System.Drawing.Color.White
        Me.txtFacture.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFacture.Location = New System.Drawing.Point(6, 21)
        Me.txtFacture.Name = "txtFacture"
        Me.txtFacture.ReadOnly = True
        Me.txtFacture.Size = New System.Drawing.Size(106, 22)
        Me.txtFacture.TabIndex = 6
        Me.txtFacture.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grpAvance
        '
        Me.grpAvance.BackColor = System.Drawing.Color.Green
        Me.grpAvance.Controls.Add(Me.txtFacture)
        Me.grpAvance.Enabled = False
        Me.grpAvance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpAvance.Location = New System.Drawing.Point(17, 421)
        Me.grpAvance.Name = "grpAvance"
        Me.grpAvance.Size = New System.Drawing.Size(118, 51)
        Me.grpAvance.TabIndex = 7
        Me.grpAvance.TabStop = False
        Me.grpAvance.Text = "Total Facture"
        '
        'btnQuit
        '
        Me.btnQuit.Location = New System.Drawing.Point(556, 483)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(131, 31)
        Me.btnQuit.TabIndex = 8
        Me.btnQuit.Text = "Quitter"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtInfos)
        Me.GroupBox1.Location = New System.Drawing.Point(364, 14)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Size = New System.Drawing.Size(337, 127)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Information sur le patient"
        '
        'txtInfos
        '
        Me.txtInfos.BackColor = System.Drawing.Color.White
        Me.txtInfos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtInfos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfos.ForeColor = System.Drawing.Color.Black
        Me.txtInfos.Location = New System.Drawing.Point(5, 20)
        Me.txtInfos.Margin = New System.Windows.Forms.Padding(5)
        Me.txtInfos.Multiline = True
        Me.txtInfos.Name = "txtInfos"
        Me.txtInfos.ReadOnly = True
        Me.txtInfos.Size = New System.Drawing.Size(327, 102)
        Me.txtInfos.TabIndex = 0
        '
        'grpTotalFacture
        '
        Me.grpTotalFacture.BackColor = System.Drawing.Color.White
        Me.grpTotalFacture.Controls.Add(Me.txtAvances)
        Me.grpTotalFacture.Enabled = False
        Me.grpTotalFacture.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTotalFacture.Location = New System.Drawing.Point(141, 421)
        Me.grpTotalFacture.Name = "grpTotalFacture"
        Me.grpTotalFacture.Size = New System.Drawing.Size(101, 51)
        Me.grpTotalFacture.TabIndex = 8
        Me.grpTotalFacture.TabStop = False
        Me.grpTotalFacture.Text = "Avances"
        '
        'txtAvances
        '
        Me.txtAvances.BackColor = System.Drawing.Color.White
        Me.txtAvances.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvances.Location = New System.Drawing.Point(6, 21)
        Me.txtAvances.Name = "txtAvances"
        Me.txtAvances.ReadOnly = True
        Me.txtAvances.Size = New System.Drawing.Size(89, 22)
        Me.txtAvances.TabIndex = 6
        Me.txtAvances.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grpReste
        '
        Me.grpReste.BackColor = System.Drawing.Color.Salmon
        Me.grpReste.Controls.Add(Me.txtReste)
        Me.grpReste.Enabled = False
        Me.grpReste.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpReste.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grpReste.Location = New System.Drawing.Point(248, 421)
        Me.grpReste.Name = "grpReste"
        Me.grpReste.Size = New System.Drawing.Size(106, 51)
        Me.grpReste.TabIndex = 8
        Me.grpReste.TabStop = False
        Me.grpReste.Text = "Reste"
        '
        'txtReste
        '
        Me.txtReste.BackColor = System.Drawing.Color.White
        Me.txtReste.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReste.Location = New System.Drawing.Point(6, 21)
        Me.txtReste.Name = "txtReste"
        Me.txtReste.ReadOnly = True
        Me.txtReste.Size = New System.Drawing.Size(94, 22)
        Me.txtReste.TabIndex = 6
        Me.txtReste.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboChoixFacture
        '
        Me.cboChoixFacture.FormattingEnabled = True
        Me.cboChoixFacture.Location = New System.Drawing.Point(17, 106)
        Me.cboChoixFacture.Name = "cboChoixFacture"
        Me.cboChoixFacture.Size = New System.Drawing.Size(222, 24)
        Me.cboChoixFacture.TabIndex = 10
        '
        'dgvElements
        '
        Me.dgvElements.AllowUserToAddRows = False
        Me.dgvElements.AllowUserToDeleteRows = False
        Me.dgvElements.AllowUserToResizeColumns = False
        Me.dgvElements.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvElements.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvElements.BackgroundColor = System.Drawing.Color.White
        Me.dgvElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvElements.Location = New System.Drawing.Point(17, 149)
        Me.dgvElements.Name = "dgvElements"
        Me.dgvElements.Size = New System.Drawing.Size(684, 266)
        Me.dgvElements.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Choisir la facture"
        '
        'frmRemboursement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 522)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvElements)
        Me.Controls.Add(Me.cboChoixFacture)
        Me.Controls.Add(Me.grpReste)
        Me.Controls.Add(Me.grpTotalFacture)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.grpAvance)
        Me.Controls.Add(Me.grpRembourser)
        Me.Controls.Add(Me.grpSearch)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRemboursement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enregistrer un Remboursement"
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.grpRembourser.ResumeLayout(False)
        Me.grpRembourser.PerformLayout()
        Me.grpAvance.ResumeLayout(False)
        Me.grpAvance.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpTotalFacture.ResumeLayout(False)
        Me.grpTotalFacture.PerformLayout()
        Me.grpReste.ResumeLayout(False)
        Me.grpReste.PerformLayout()
        CType(Me.dgvElements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents grpRembourser As System.Windows.Forms.GroupBox
    Friend WithEvents btnValidate As System.Windows.Forms.Button
    Friend WithEvents txtAAvancer As System.Windows.Forms.TextBox
    Friend WithEvents txtFacture As System.Windows.Forms.TextBox
    Friend WithEvents grpAvance As System.Windows.Forms.GroupBox
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtInfos As System.Windows.Forms.TextBox
    Friend WithEvents grpTotalFacture As System.Windows.Forms.GroupBox
    Friend WithEvents txtAvances As System.Windows.Forms.TextBox
    Friend WithEvents grpReste As System.Windows.Forms.GroupBox
    Friend WithEvents txtReste As System.Windows.Forms.TextBox
    Friend WithEvents cboChoixFacture As System.Windows.Forms.ComboBox
    Friend WithEvents dgvElements As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
