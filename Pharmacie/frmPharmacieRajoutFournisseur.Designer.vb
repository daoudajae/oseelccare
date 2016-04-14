<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPharmacieRajoutFournisseur
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
        Me.btnAjouter = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtAdresse = New System.Windows.Forms.TextBox()
        Me.lstFournisseur = New System.Windows.Forms.ListBox()
        Me.btnQuitter = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAjouter
        '
        Me.btnAjouter.Location = New System.Drawing.Point(266, 57)
        Me.btnAjouter.Name = "btnAjouter"
        Me.btnAjouter.Size = New System.Drawing.Size(126, 38)
        Me.btnAjouter.TabIndex = 0
        Me.btnAjouter.Text = "Ajouter"
        Me.btnAjouter.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(6, 25)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(386, 26)
        Me.txtName.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtAdresse)
        Me.GroupBox1.Controls.Add(Me.lstFournisseur)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.btnAjouter)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 428)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rajouter un fournisseur"
        '
        'txtAdresse
        '
        Me.txtAdresse.Location = New System.Drawing.Point(6, 57)
        Me.txtAdresse.Name = "txtAdresse"
        Me.txtAdresse.Size = New System.Drawing.Size(254, 26)
        Me.txtAdresse.TabIndex = 3
        '
        'lstFournisseur
        '
        Me.lstFournisseur.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lstFournisseur.FormattingEnabled = True
        Me.lstFournisseur.ItemHeight = 20
        Me.lstFournisseur.Location = New System.Drawing.Point(3, 101)
        Me.lstFournisseur.Name = "lstFournisseur"
        Me.lstFournisseur.Size = New System.Drawing.Size(394, 324)
        Me.lstFournisseur.TabIndex = 2
        '
        'btnQuitter
        '
        Me.btnQuitter.Location = New System.Drawing.Point(301, 449)
        Me.btnQuitter.Name = "btnQuitter"
        Me.btnQuitter.Size = New System.Drawing.Size(102, 35)
        Me.btnQuitter.TabIndex = 3
        Me.btnQuitter.Text = "Quitter"
        Me.btnQuitter.UseVisualStyleBackColor = True
        '
        'frmPharmacieRajoutFournisseur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 487)
        Me.Controls.Add(Me.btnQuitter)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPharmacieRajoutFournisseur"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rajout des fournisseurs"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAjouter As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstFournisseur As System.Windows.Forms.ListBox
    Friend WithEvents txtAdresse As System.Windows.Forms.TextBox
    Friend WithEvents btnQuitter As System.Windows.Forms.Button
End Class
