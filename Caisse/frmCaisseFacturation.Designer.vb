<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaisseFacturation
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
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.grpItems = New System.Windows.Forms.GroupBox()
        Me.dgvPrescriptions = New System.Windows.Forms.DataGridView()
        Me.grpInfo = New System.Windows.Forms.GroupBox()
        Me.txtInfos = New System.Windows.Forms.TextBox()
        Me.grpPrescriptions = New System.Windows.Forms.GroupBox()
        Me.grpCharge = New System.Windows.Forms.GroupBox()
        Me.lblAssure = New System.Windows.Forms.Label()
        Me.txtAssurer = New System.Windows.Forms.TextBox()
        Me.lblAssureur = New System.Windows.Forms.Label()
        Me.txtAssureur = New System.Windows.Forms.TextBox()
        Me.btnValidate = New System.Windows.Forms.Button()
        Me.grpTotal = New System.Windows.Forms.GroupBox()
        Me.lblReste = New System.Windows.Forms.Label()
        Me.txtResteAPayer = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotalPay = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotalToPay = New System.Windows.Forms.TextBox()
        Me.grpSearch.SuspendLayout()
        Me.grpItems.SuspendLayout()
        CType(Me.dgvPrescriptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpInfo.SuspendLayout()
        Me.grpPrescriptions.SuspendLayout()
        Me.grpCharge.SuspendLayout()
        Me.grpTotal.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(244, 22)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(149, 38)
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
        Me.grpSearch.Size = New System.Drawing.Size(405, 75)
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
        Me.grpItems.Size = New System.Drawing.Size(594, 418)
        Me.grpItems.TabIndex = 4
        Me.grpItems.TabStop = False
        Me.grpItems.Text = "Liste des prescriptions et Labo"
        '
        'dgvPrescriptions
        '
        Me.dgvPrescriptions.AllowUserToAddRows = False
        Me.dgvPrescriptions.AllowUserToDeleteRows = False
        Me.dgvPrescriptions.AllowUserToResizeColumns = False
        Me.dgvPrescriptions.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvPrescriptions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
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
        Me.dgvPrescriptions.Size = New System.Drawing.Size(586, 389)
        Me.dgvPrescriptions.TabIndex = 0
        '
        'grpInfo
        '
        Me.grpInfo.Controls.Add(Me.txtInfos)
        Me.grpInfo.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInfo.ForeColor = System.Drawing.Color.Teal
        Me.grpInfo.Location = New System.Drawing.Point(20, 150)
        Me.grpInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.grpInfo.Name = "grpInfo"
        Me.grpInfo.Padding = New System.Windows.Forms.Padding(4)
        Me.grpInfo.Size = New System.Drawing.Size(405, 131)
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
        Me.txtInfos.Size = New System.Drawing.Size(397, 102)
        Me.txtInfos.TabIndex = 4
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
        Me.grpPrescriptions.Size = New System.Drawing.Size(602, 447)
        Me.grpPrescriptions.TabIndex = 7
        Me.grpPrescriptions.TabStop = False
        Me.grpPrescriptions.Text = "FACTURATION"
        '
        'grpCharge
        '
        Me.grpCharge.Controls.Add(Me.lblAssure)
        Me.grpCharge.Controls.Add(Me.txtAssurer)
        Me.grpCharge.Controls.Add(Me.lblAssureur)
        Me.grpCharge.Controls.Add(Me.txtAssureur)
        Me.grpCharge.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCharge.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grpCharge.Location = New System.Drawing.Point(16, 392)
        Me.grpCharge.Margin = New System.Windows.Forms.Padding(4)
        Me.grpCharge.Name = "grpCharge"
        Me.grpCharge.Padding = New System.Windows.Forms.Padding(4)
        Me.grpCharge.Size = New System.Drawing.Size(405, 98)
        Me.grpCharge.TabIndex = 13
        Me.grpCharge.TabStop = False
        Me.grpCharge.Text = "Details du bon de prise en charge"
        Me.grpCharge.Visible = False
        '
        'lblAssure
        '
        Me.lblAssure.AutoSize = True
        Me.lblAssure.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssure.Location = New System.Drawing.Point(8, 30)
        Me.lblAssure.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAssure.Name = "lblAssure"
        Me.lblAssure.Size = New System.Drawing.Size(126, 23)
        Me.lblAssure.TabIndex = 15
        Me.lblAssure.Text = "Charge Assuré"
        '
        'txtAssurer
        '
        Me.txtAssurer.BackColor = System.Drawing.Color.White
        Me.txtAssurer.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssurer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtAssurer.Location = New System.Drawing.Point(12, 54)
        Me.txtAssurer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAssurer.Name = "txtAssurer"
        Me.txtAssurer.ReadOnly = True
        Me.txtAssurer.Size = New System.Drawing.Size(124, 28)
        Me.txtAssurer.TabIndex = 14
        Me.txtAssurer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblAssureur
        '
        Me.lblAssureur.AutoSize = True
        Me.lblAssureur.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssureur.Location = New System.Drawing.Point(164, 27)
        Me.lblAssureur.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAssureur.Name = "lblAssureur"
        Me.lblAssureur.Size = New System.Drawing.Size(142, 23)
        Me.lblAssureur.TabIndex = 13
        Me.lblAssureur.Text = "Charge Assureur"
        '
        'txtAssureur
        '
        Me.txtAssureur.BackColor = System.Drawing.Color.White
        Me.txtAssureur.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssureur.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtAssureur.Location = New System.Drawing.Point(171, 53)
        Me.txtAssureur.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAssureur.Name = "txtAssureur"
        Me.txtAssureur.ReadOnly = True
        Me.txtAssureur.Size = New System.Drawing.Size(139, 28)
        Me.txtAssureur.TabIndex = 12
        Me.txtAssureur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnValidate
        '
        Me.btnValidate.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValidate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnValidate.Location = New System.Drawing.Point(807, 470)
        Me.btnValidate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnValidate.Name = "btnValidate"
        Me.btnValidate.Size = New System.Drawing.Size(220, 34)
        Me.btnValidate.TabIndex = 11
        Me.btnValidate.Text = "Terminer facturation"
        Me.btnValidate.UseVisualStyleBackColor = True
        Me.btnValidate.Visible = False
        '
        'grpTotal
        '
        Me.grpTotal.Controls.Add(Me.lblReste)
        Me.grpTotal.Controls.Add(Me.txtResteAPayer)
        Me.grpTotal.Controls.Add(Me.Label3)
        Me.grpTotal.Controls.Add(Me.txtTotalPay)
        Me.grpTotal.Controls.Add(Me.Label2)
        Me.grpTotal.Controls.Add(Me.txtTotalToPay)
        Me.grpTotal.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTotal.ForeColor = System.Drawing.Color.Green
        Me.grpTotal.Location = New System.Drawing.Point(20, 285)
        Me.grpTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.grpTotal.Name = "grpTotal"
        Me.grpTotal.Padding = New System.Windows.Forms.Padding(4)
        Me.grpTotal.Size = New System.Drawing.Size(405, 100)
        Me.grpTotal.TabIndex = 12
        Me.grpTotal.TabStop = False
        Me.grpTotal.Text = "Details de la facturation"
        Me.grpTotal.Visible = False
        '
        'lblReste
        '
        Me.lblReste.AutoSize = True
        Me.lblReste.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReste.Location = New System.Drawing.Point(229, 33)
        Me.lblReste.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblReste.Name = "lblReste"
        Me.lblReste.Size = New System.Drawing.Size(125, 24)
        Me.lblReste.TabIndex = 9
        Me.lblReste.Text = "Total General"
        Me.lblReste.Visible = False
        '
        'txtResteAPayer
        '
        Me.txtResteAPayer.BackColor = System.Drawing.Color.White
        Me.txtResteAPayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResteAPayer.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResteAPayer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtResteAPayer.Location = New System.Drawing.Point(236, 58)
        Me.txtResteAPayer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtResteAPayer.MaximumSize = New System.Drawing.Size(99, 24)
        Me.txtResteAPayer.Name = "txtResteAPayer"
        Me.txtResteAPayer.ReadOnly = True
        Me.txtResteAPayer.Size = New System.Drawing.Size(99, 28)
        Me.txtResteAPayer.TabIndex = 8
        Me.txtResteAPayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtResteAPayer.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(75, 33)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 24)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Total a payer"
        '
        'txtTotalPay
        '
        Me.txtTotalPay.BackColor = System.Drawing.Color.White
        Me.txtTotalPay.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPay.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalPay.Location = New System.Drawing.Point(79, 58)
        Me.txtTotalPay.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalPay.MaximumSize = New System.Drawing.Size(99, 24)
        Me.txtTotalPay.Name = "txtTotalPay"
        Me.txtTotalPay.ReadOnly = True
        Me.txtTotalPay.Size = New System.Drawing.Size(99, 28)
        Me.txtTotalPay.TabIndex = 2
        Me.txtTotalPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 33)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total"
        Me.Label2.Visible = False
        '
        'txtTotalToPay
        '
        Me.txtTotalToPay.BackColor = System.Drawing.Color.White
        Me.txtTotalToPay.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalToPay.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalToPay.Location = New System.Drawing.Point(8, 58)
        Me.txtTotalToPay.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalToPay.Name = "txtTotalToPay"
        Me.txtTotalToPay.ReadOnly = True
        Me.txtTotalToPay.Size = New System.Drawing.Size(37, 28)
        Me.txtTotalToPay.TabIndex = 0
        Me.txtTotalToPay.TabStop = False
        Me.txtTotalToPay.Text = "F"
        Me.txtTotalToPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTotalToPay.Visible = False
        '
        'frmCaisseFacturation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1045, 521)
        Me.Controls.Add(Me.grpCharge)
        Me.Controls.Add(Me.btnValidate)
        Me.Controls.Add(Me.grpTotal)
        Me.Controls.Add(Me.grpPrescriptions)
        Me.Controls.Add(Me.grpInfo)
        Me.Controls.Add(Me.grpSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCaisseFacturation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paiement des Prescriptions"
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.grpItems.ResumeLayout(False)
        CType(Me.dgvPrescriptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpInfo.ResumeLayout(False)
        Me.grpInfo.PerformLayout()
        Me.grpPrescriptions.ResumeLayout(False)
        Me.grpCharge.ResumeLayout(False)
        Me.grpCharge.PerformLayout()
        Me.grpTotal.ResumeLayout(False)
        Me.grpTotal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents grpItems As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPrescriptions As System.Windows.Forms.DataGridView
    Friend WithEvents grpInfo As System.Windows.Forms.GroupBox
    Friend WithEvents grpPrescriptions As System.Windows.Forms.GroupBox
    Friend WithEvents txtInfos As System.Windows.Forms.TextBox
    Friend WithEvents grpCharge As System.Windows.Forms.GroupBox
    Friend WithEvents lblAssure As System.Windows.Forms.Label
    Friend WithEvents txtAssurer As System.Windows.Forms.TextBox
    Friend WithEvents lblAssureur As System.Windows.Forms.Label
    Friend WithEvents txtAssureur As System.Windows.Forms.TextBox
    Friend WithEvents btnValidate As System.Windows.Forms.Button
    Friend WithEvents grpTotal As System.Windows.Forms.GroupBox
    Friend WithEvents lblReste As System.Windows.Forms.Label
    Friend WithEvents txtResteAPayer As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPay As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalToPay As System.Windows.Forms.TextBox
End Class
