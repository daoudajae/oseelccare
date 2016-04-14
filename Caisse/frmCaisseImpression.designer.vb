<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaisseImpression
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
        Me.grpItems = New System.Windows.Forms.GroupBox()
        Me.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.grpTotal = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotalPay = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotalToPay = New System.Windows.Forms.TextBox()
        Me.dgvListeFactures = New System.Windows.Forms.DataGridView()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.checkversementbon = New System.Windows.Forms.CheckBox()
        Me.grpInfo = New System.Windows.Forms.GroupBox()
        Me.txtInfos = New System.Windows.Forms.TextBox()
        Me.btnValidate = New System.Windows.Forms.Button()
        Me.grpSearch.SuspendLayout()
        Me.grpItems.SuspendLayout()
        Me.grpTotal.SuspendLayout()
        CType(Me.dgvListeFactures, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(170, 27)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(126, 26)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Rechercher"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(8, 27)
        Me.txtId.Margin = New System.Windows.Forms.Padding(4)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(154, 26)
        Me.txtId.TabIndex = 0
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.txtId)
        Me.grpSearch.Controls.Add(Me.btnSearch)
        Me.grpSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearch.ForeColor = System.Drawing.Color.Teal
        Me.grpSearch.Location = New System.Drawing.Point(17, 13)
        Me.grpSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Padding = New System.Windows.Forms.Padding(4)
        Me.grpSearch.Size = New System.Drawing.Size(344, 66)
        Me.grpSearch.TabIndex = 3
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Saisir Numero Patient"
        '
        'grpItems
        '
        Me.grpItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpItems.Controls.Add(Me.CrystalReportViewer)
        Me.grpItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpItems.Location = New System.Drawing.Point(368, 13)
        Me.grpItems.Margin = New System.Windows.Forms.Padding(4)
        Me.grpItems.Name = "grpItems"
        Me.grpItems.Padding = New System.Windows.Forms.Padding(4)
        Me.grpItems.Size = New System.Drawing.Size(523, 501)
        Me.grpItems.TabIndex = 4
        Me.grpItems.TabStop = False
        Me.grpItems.Text = "Facture à Imprimer"
        '
        'CrystalReportViewer
        '
        Me.CrystalReportViewer.ActiveViewIndex = -1
        Me.CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer.Location = New System.Drawing.Point(4, 23)
        Me.CrystalReportViewer.Margin = New System.Windows.Forms.Padding(4)
        Me.CrystalReportViewer.Name = "CrystalReportViewer"
        Me.CrystalReportViewer.Size = New System.Drawing.Size(515, 474)
        Me.CrystalReportViewer.TabIndex = 0
        Me.CrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'grpTotal
        '
        Me.grpTotal.Controls.Add(Me.Label3)
        Me.grpTotal.Controls.Add(Me.txtTotalPay)
        Me.grpTotal.Controls.Add(Me.Label2)
        Me.grpTotal.Controls.Add(Me.txtTotalToPay)
        Me.grpTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTotal.ForeColor = System.Drawing.Color.Navy
        Me.grpTotal.Location = New System.Drawing.Point(16, 439)
        Me.grpTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.grpTotal.Name = "grpTotal"
        Me.grpTotal.Padding = New System.Windows.Forms.Padding(4)
        Me.grpTotal.Size = New System.Drawing.Size(276, 101)
        Me.grpTotal.TabIndex = 5
        Me.grpTotal.TabStop = False
        Me.grpTotal.Text = "Totaux"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(148, 28)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "À Versé"
        '
        'txtTotalPay
        '
        Me.txtTotalPay.Enabled = False
        Me.txtTotalPay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPay.Location = New System.Drawing.Point(140, 58)
        Me.txtTotalPay.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalPay.Name = "txtTotalPay"
        Me.txtTotalPay.Size = New System.Drawing.Size(120, 26)
        Me.txtTotalPay.TabIndex = 2
        Me.txtTotalPay.TabStop = False
        Me.txtTotalPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 33)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total Facture"
        '
        'txtTotalToPay
        '
        Me.txtTotalToPay.Enabled = False
        Me.txtTotalToPay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalToPay.Location = New System.Drawing.Point(11, 58)
        Me.txtTotalToPay.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalToPay.Name = "txtTotalToPay"
        Me.txtTotalToPay.Size = New System.Drawing.Size(121, 26)
        Me.txtTotalToPay.TabIndex = 0
        Me.txtTotalToPay.TabStop = False
        Me.txtTotalToPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvListeFactures
        '
        Me.dgvListeFactures.AllowUserToAddRows = False
        Me.dgvListeFactures.AllowUserToDeleteRows = False
        Me.dgvListeFactures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListeFactures.Location = New System.Drawing.Point(13, 215)
        Me.dgvListeFactures.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvListeFactures.Name = "dgvListeFactures"
        Me.dgvListeFactures.ReadOnly = True
        Me.dgvListeFactures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListeFactures.Size = New System.Drawing.Size(347, 216)
        Me.dgvListeFactures.TabIndex = 7
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'checkversementbon
        '
        Me.checkversementbon.AutoSize = True
        Me.checkversementbon.Location = New System.Drawing.Point(17, 548)
        Me.checkversementbon.Margin = New System.Windows.Forms.Padding(4)
        Me.checkversementbon.Name = "checkversementbon"
        Me.checkversementbon.Size = New System.Drawing.Size(131, 21)
        Me.checkversementbon.TabIndex = 8
        Me.checkversementbon.Text = "Facture à Credit"
        Me.checkversementbon.UseVisualStyleBackColor = True
        '
        'grpInfo
        '
        Me.grpInfo.Controls.Add(Me.txtInfos)
        Me.grpInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInfo.ForeColor = System.Drawing.Color.Teal
        Me.grpInfo.Location = New System.Drawing.Point(13, 89)
        Me.grpInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.grpInfo.Name = "grpInfo"
        Me.grpInfo.Padding = New System.Windows.Forms.Padding(4)
        Me.grpInfo.Size = New System.Drawing.Size(347, 122)
        Me.grpInfo.TabIndex = 9
        Me.grpInfo.TabStop = False
        Me.grpInfo.Text = "Information sur le patient"
        '
        'txtInfos
        '
        Me.txtInfos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtInfos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfos.Location = New System.Drawing.Point(4, 23)
        Me.txtInfos.Margin = New System.Windows.Forms.Padding(4)
        Me.txtInfos.Multiline = True
        Me.txtInfos.Name = "txtInfos"
        Me.txtInfos.ReadOnly = True
        Me.txtInfos.Size = New System.Drawing.Size(339, 95)
        Me.txtInfos.TabIndex = 4
        '
        'btnValidate
        '
        Me.btnValidate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValidate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnValidate.Location = New System.Drawing.Point(619, 522)
        Me.btnValidate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnValidate.Name = "btnValidate"
        Me.btnValidate.Size = New System.Drawing.Size(268, 38)
        Me.btnValidate.TabIndex = 2
        Me.btnValidate.Text = "Imprimer Facture"
        Me.btnValidate.UseVisualStyleBackColor = True
        '
        'frmCaisseImpression
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 573)
        Me.Controls.Add(Me.grpInfo)
        Me.Controls.Add(Me.checkversementbon)
        Me.Controls.Add(Me.dgvListeFactures)
        Me.Controls.Add(Me.grpTotal)
        Me.Controls.Add(Me.btnValidate)
        Me.Controls.Add(Me.grpItems)
        Me.Controls.Add(Me.grpSearch)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCaisseImpression"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impression de la Facture"
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.grpItems.ResumeLayout(False)
        Me.grpTotal.ResumeLayout(False)
        Me.grpTotal.PerformLayout()
        CType(Me.dgvListeFactures, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpInfo.ResumeLayout(False)
        Me.grpInfo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents grpItems As System.Windows.Forms.GroupBox
    Friend WithEvents grpTotal As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPay As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalToPay As System.Windows.Forms.TextBox
    ' Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents dgvListeFactures As System.Windows.Forms.DataGridView
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents checkversementbon As System.Windows.Forms.CheckBox
    Friend WithEvents grpInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtInfos As System.Windows.Forms.TextBox
    Private WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnValidate As System.Windows.Forms.Button
End Class
