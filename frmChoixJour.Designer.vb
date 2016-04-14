<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChoixJour
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.valider = New System.Windows.Forms.Button()
        Me.selectdate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.selectdate)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(319, 109)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Choix de la Période"
        '
        'valider
        '
        Me.valider.Location = New System.Drawing.Point(108, 161)
        Me.valider.Name = "valider"
        Me.valider.Size = New System.Drawing.Size(195, 26)
        Me.valider.TabIndex = 1
        Me.valider.Text = "Valider"
        Me.valider.UseVisualStyleBackColor = True
        '
        'selectdate
        '
        Me.selectdate.Location = New System.Drawing.Point(47, 52)
        Me.selectdate.Name = "selectdate"
        Me.selectdate.Size = New System.Drawing.Size(234, 20)
        Me.selectdate.TabIndex = 0
        '
        'frmChoixJour
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 213)
        Me.Controls.Add(Me.valider)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmChoixJour"
        Me.Text = "frmChoixJour"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents selectdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents valider As System.Windows.Forms.Button
End Class
