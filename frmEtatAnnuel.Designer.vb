<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEtatAnnuel
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
        Me.valider = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtannee = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'valider
        '
        Me.valider.Location = New System.Drawing.Point(74, 137)
        Me.valider.Name = "valider"
        Me.valider.Size = New System.Drawing.Size(158, 26)
        Me.valider.TabIndex = 0
        Me.valider.Text = "Valider"
        Me.valider.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(121, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Annee"
        '
        'txtannee
        '
        Me.txtannee.Location = New System.Drawing.Point(74, 85)
        Me.txtannee.Name = "txtannee"
        Me.txtannee.Size = New System.Drawing.Size(156, 20)
        Me.txtannee.TabIndex = 2
        '
        'frmEtatAnnuel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(315, 237)
        Me.Controls.Add(Me.txtannee)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.valider)
        Me.Name = "frmEtatAnnuel"
        Me.Text = "frmEtatAnnuel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents valider As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtannee As System.Windows.Forms.TextBox
End Class
