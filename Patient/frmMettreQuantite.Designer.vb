<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMettreQuantite
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
        Me.btnPrecrire = New System.Windows.Forms.Button()
        Me.lblArticle = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtQuantite = New System.Windows.Forms.TextBox()
        Me.lblStock = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPrecrire
        '
        Me.btnPrecrire.Enabled = False
        Me.btnPrecrire.Location = New System.Drawing.Point(228, 108)
        Me.btnPrecrire.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnPrecrire.Name = "btnPrecrire"
        Me.btnPrecrire.Size = New System.Drawing.Size(124, 32)
        Me.btnPrecrire.TabIndex = 0
        Me.btnPrecrire.Text = "Precrire Dose"
        Me.btnPrecrire.UseVisualStyleBackColor = True
        '
        'lblArticle
        '
        Me.lblArticle.AutoSize = True
        Me.lblArticle.ForeColor = System.Drawing.Color.Red
        Me.lblArticle.Location = New System.Drawing.Point(9, 25)
        Me.lblArticle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblArticle.Name = "lblArticle"
        Me.lblArticle.Size = New System.Drawing.Size(71, 25)
        Me.lblArticle.TabIndex = 1
        Me.lblArticle.Text = "Label1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(295, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Dose"
        '
        'txtQuantite
        '
        Me.txtQuantite.Location = New System.Drawing.Point(268, 76)
        Me.txtQuantite.Name = "txtQuantite"
        Me.txtQuantite.Size = New System.Drawing.Size(84, 30)
        Me.txtQuantite.TabIndex = 3
        '
        'lblStock
        '
        Me.lblStock.AutoSize = True
        Me.lblStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStock.Location = New System.Drawing.Point(359, 79)
        Me.lblStock.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(77, 25)
        Me.lblStock.TabIndex = 5
        Me.lblStock.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 25)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Article "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(359, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 25)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Stock"
        '
        'btnAnnuler
        '
        Me.btnAnnuler.Location = New System.Drawing.Point(364, 108)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(97, 32)
        Me.btnAnnuler.TabIndex = 8
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.UseVisualStyleBackColor = True
        '
        'frmMettreQuantite
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 148)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAnnuler)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblStock)
        Me.Controls.Add(Me.txtQuantite)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblArticle)
        Me.Controls.Add(Me.btnPrecrire)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMettreQuantite"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPrecrire As System.Windows.Forms.Button
    Friend WithEvents lblArticle As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtQuantite As System.Windows.Forms.TextBox
    Friend WithEvents lblStock As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAnnuler As System.Windows.Forms.Button
End Class
