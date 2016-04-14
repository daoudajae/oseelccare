<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRapportVente
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.datefin = New System.Windows.Forms.DateTimePicker()
        Me.datedebut = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboAgentCaisse = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.crtViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnImprimer = New System.Windows.Forms.Button()
        Me.btnQuiter = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.datefin)
        Me.GroupBox2.Controls.Add(Me.datedebut)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cboAgentCaisse)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(523, 87)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periode"
        '
        'datefin
        '
        Me.datefin.CustomFormat = "yyyy-MM-dd HH:mm"
        Me.datefin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datefin.Location = New System.Drawing.Point(66, 53)
        Me.datefin.Margin = New System.Windows.Forms.Padding(4)
        Me.datefin.Name = "datefin"
        Me.datefin.Size = New System.Drawing.Size(155, 22)
        Me.datefin.TabIndex = 17
        '
        'datedebut
        '
        Me.datedebut.CustomFormat = "yyyy-MM-dd HH:mm"
        Me.datedebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datedebut.Location = New System.Drawing.Point(66, 28)
        Me.datedebut.Margin = New System.Windows.Forms.Padding(4)
        Me.datedebut.Name = "datedebut"
        Me.datedebut.Size = New System.Drawing.Size(155, 22)
        Me.datedebut.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(229, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 17)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Agent de caisse"
        '
        'cboAgentCaisse
        '
        Me.cboAgentCaisse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgentCaisse.FormattingEnabled = True
        Me.cboAgentCaisse.Location = New System.Drawing.Point(228, 51)
        Me.cboAgentCaisse.Name = "cboAgentCaisse"
        Me.cboAgentCaisse.Size = New System.Drawing.Size(282, 24)
        Me.cboAgentCaisse.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 58)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fin:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 28)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Début:"
        '
        'crtViewer
        '
        Me.crtViewer.ActiveViewIndex = -1
        Me.crtViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crtViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.crtViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crtViewer.Location = New System.Drawing.Point(3, 18)
        Me.crtViewer.Name = "crtViewer"
        Me.crtViewer.Size = New System.Drawing.Size(513, 385)
        Me.crtViewer.TabIndex = 15
        Me.crtViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.crtViewer)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 107)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(519, 406)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rapport De Caisse"
        '
        'btnImprimer
        '
        Me.btnImprimer.Location = New System.Drawing.Point(285, 519)
        Me.btnImprimer.Name = "btnImprimer"
        Me.btnImprimer.Size = New System.Drawing.Size(121, 31)
        Me.btnImprimer.TabIndex = 17
        Me.btnImprimer.Text = "Imprimer"
        Me.btnImprimer.UseVisualStyleBackColor = True
        '
        'btnQuiter
        '
        Me.btnQuiter.Location = New System.Drawing.Point(412, 519)
        Me.btnQuiter.Name = "btnQuiter"
        Me.btnQuiter.Size = New System.Drawing.Size(121, 31)
        Me.btnQuiter.TabIndex = 18
        Me.btnQuiter.Text = "Quitter"
        Me.btnQuiter.UseVisualStyleBackColor = True
        '
        'frmRapportVente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 564)
        Me.Controls.Add(Me.btnQuiter)
        Me.Controls.Add(Me.btnImprimer)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmRapportVente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmRapportVente"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents crtViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboAgentCaisse As System.Windows.Forms.ComboBox
    Friend WithEvents crtRapportCaisse1 As OSEELCCare.crtRapportCaisse
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnImprimer As System.Windows.Forms.Button
    Friend WithEvents btnQuiter As System.Windows.Forms.Button
    Friend WithEvents datedebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents datefin As System.Windows.Forms.DateTimePicker
End Class
