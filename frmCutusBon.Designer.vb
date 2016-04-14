<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCutusBon
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
        Me.grpInfo = New System.Windows.Forms.GroupBox()
        Me.lblBonInfo = New System.Windows.Forms.Label()
        Me.lblEncInfo = New System.Windows.Forms.Label()
        Me.lblPatientInfo = New System.Windows.Forms.Label()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.grpInfo.SuspendLayout()
        Me.grpSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpInfo
        '
        Me.grpInfo.Controls.Add(Me.lblBonInfo)
        Me.grpInfo.Controls.Add(Me.lblEncInfo)
        Me.grpInfo.Controls.Add(Me.lblPatientInfo)
        Me.grpInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInfo.ForeColor = System.Drawing.Color.Teal
        Me.grpInfo.Location = New System.Drawing.Point(429, 13)
        Me.grpInfo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpInfo.Name = "grpInfo"
        Me.grpInfo.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpInfo.Size = New System.Drawing.Size(355, 129)
        Me.grpInfo.TabIndex = 6
        Me.grpInfo.TabStop = False
        Me.grpInfo.Text = "Information sur le patient"
        Me.grpInfo.Visible = False
        '
        'lblBonInfo
        '
        Me.lblBonInfo.AutoSize = True
        Me.lblBonInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblBonInfo.Location = New System.Drawing.Point(12, 91)
        Me.lblBonInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBonInfo.Name = "lblBonInfo"
        Me.lblBonInfo.Size = New System.Drawing.Size(48, 20)
        Me.lblBonInfo.TabIndex = 3
        Me.lblBonInfo.Text = "Bon:"
        Me.lblBonInfo.Visible = False
        '
        'lblEncInfo
        '
        Me.lblEncInfo.AutoSize = True
        Me.lblEncInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblEncInfo.Location = New System.Drawing.Point(12, 60)
        Me.lblEncInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEncInfo.Name = "lblEncInfo"
        Me.lblEncInfo.Size = New System.Drawing.Size(101, 20)
        Me.lblEncInfo.TabIndex = 2
        Me.lblEncInfo.Text = "Rencontre:"
        Me.lblEncInfo.Visible = False
        '
        'lblPatientInfo
        '
        Me.lblPatientInfo.AutoSize = True
        Me.lblPatientInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblPatientInfo.Location = New System.Drawing.Point(12, 27)
        Me.lblPatientInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPatientInfo.Name = "lblPatientInfo"
        Me.lblPatientInfo.Size = New System.Drawing.Size(63, 20)
        Me.lblPatientInfo.TabIndex = 1
        Me.lblPatientInfo.Text = "Noms:"
        Me.lblPatientInfo.Visible = False
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.txtId)
        Me.grpSearch.Controls.Add(Me.btnSearch)
        Me.grpSearch.Controls.Add(Me.Label1)
        Me.grpSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearch.ForeColor = System.Drawing.Color.Teal
        Me.grpSearch.Location = New System.Drawing.Point(29, 15)
        Me.grpSearch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpSearch.Size = New System.Drawing.Size(392, 108)
        Me.grpSearch.TabIndex = 7
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Rechercher un patient"
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(205, 23)
        Me.txtId.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(172, 26)
        Me.txtId.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(205, 60)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(172, 36)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Rechercher"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(13, 37)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Numero du  patient"
        '
        'CrystalReportViewer
        '
        Me.CrystalReportViewer.ActiveViewIndex = -1
        Me.CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer.Location = New System.Drawing.Point(29, 152)
        Me.CrystalReportViewer.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CrystalReportViewer.Name = "CrystalReportViewer"
        Me.CrystalReportViewer.Size = New System.Drawing.Size(755, 268)
        Me.CrystalReportViewer.TabIndex = 8
        Me.CrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frmCutusBon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 443)
        Me.Controls.Add(Me.CrystalReportViewer)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.grpInfo)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmCutusBon"
        Me.Text = "FrmCutusBon"
        Me.grpInfo.ResumeLayout(False)
        Me.grpInfo.PerformLayout()
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblBonInfo As System.Windows.Forms.Label
    Friend WithEvents lblEncInfo As System.Windows.Forms.Label
    Friend WithEvents lblPatientInfo As System.Windows.Forms.Label
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
