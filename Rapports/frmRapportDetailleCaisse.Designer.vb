<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRapportDetailleCaisse
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
        Me.datagridelementspecialise = New System.Windows.Forms.DataGridView()
        Me.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.societecredit = New System.Windows.Forms.DataGridView()
        Me.FFF = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        CType(Me.datagridelementspecialise, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.societecredit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FFF.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'datagridelementspecialise
        '
        Me.datagridelementspecialise.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridelementspecialise.Location = New System.Drawing.Point(33, 21)
        Me.datagridelementspecialise.Name = "datagridelementspecialise"
        Me.datagridelementspecialise.Size = New System.Drawing.Size(320, 203)
        Me.datagridelementspecialise.TabIndex = 13
        '
        'CrystalReportViewer
        '
        Me.CrystalReportViewer.ActiveViewIndex = -1
        Me.CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer.Location = New System.Drawing.Point(3, 3)
        Me.CrystalReportViewer.Name = "CrystalReportViewer"
        Me.CrystalReportViewer.Size = New System.Drawing.Size(852, 713)
        Me.CrystalReportViewer.TabIndex = 14
        Me.CrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'societecredit
        '
        Me.societecredit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.societecredit.Location = New System.Drawing.Point(76, 241)
        Me.societecredit.Name = "societecredit"
        Me.societecredit.Size = New System.Drawing.Size(276, 151)
        Me.societecredit.TabIndex = 15
        '
        'FFF
        '
        Me.FFF.Controls.Add(Me.TabPage1)
        Me.FFF.Controls.Add(Me.TabPage2)
        Me.FFF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FFF.Location = New System.Drawing.Point(0, 0)
        Me.FFF.Name = "FFF"
        Me.FFF.SelectedIndex = 0
        Me.FFF.Size = New System.Drawing.Size(866, 745)
        Me.FFF.TabIndex = 16
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CrystalReportViewer)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(858, 719)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Rapport Detaillé de Caisse"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.CrystalReportViewer1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(858, 719)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Liste Societé à Credit"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(3, 3)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(852, 713)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frmRapportDetailleCaisse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 745)
        Me.Controls.Add(Me.FFF)
        Me.Controls.Add(Me.societecredit)
        Me.Controls.Add(Me.datagridelementspecialise)
        Me.Name = "frmRapportDetailleCaisse"
        Me.Text = "frmRapportDetailleCaisse"
        CType(Me.datagridelementspecialise, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.societecredit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FFF.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents datagridelementspecialise As System.Windows.Forms.DataGridView
    Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents societecredit As System.Windows.Forms.DataGridView
    Friend WithEvents FFF As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
