<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectionFacture
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.validerfacture = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbnom = New System.Windows.Forms.Label()
        Me.lbrencontre = New System.Windows.Forms.Label()
        Me.lbpatient = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbrequete = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(24, 19)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(510, 211)
        Me.DataGridView1.TabIndex = 0
        '
        'validerfacture
        '
        Me.validerfacture.Location = New System.Drawing.Point(233, 373)
        Me.validerfacture.Name = "validerfacture"
        Me.validerfacture.Size = New System.Drawing.Size(142, 29)
        Me.validerfacture.TabIndex = 1
        Me.validerfacture.Text = "Valider Facture"
        Me.validerfacture.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbnom)
        Me.GroupBox1.Controls.Add(Me.lbrencontre)
        Me.GroupBox1.Controls.Add(Me.lbpatient)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(567, 67)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Information Personnelle"
        '
        'lbnom
        '
        Me.lbnom.AutoSize = True
        Me.lbnom.Location = New System.Drawing.Point(111, 19)
        Me.lbnom.Name = "lbnom"
        Me.lbnom.Size = New System.Drawing.Size(39, 13)
        Me.lbnom.TabIndex = 5
        Me.lbnom.Text = "Label4"
        '
        'lbrencontre
        '
        Me.lbrencontre.AutoSize = True
        Me.lbrencontre.Location = New System.Drawing.Point(271, 41)
        Me.lbrencontre.Name = "lbrencontre"
        Me.lbrencontre.Size = New System.Drawing.Size(39, 13)
        Me.lbrencontre.TabIndex = 4
        Me.lbrencontre.Text = "Label5"
        '
        'lbpatient
        '
        Me.lbpatient.AutoSize = True
        Me.lbpatient.Location = New System.Drawing.Point(77, 41)
        Me.lbpatient.Name = "lbpatient"
        Me.lbpatient.Size = New System.Drawing.Size(39, 13)
        Me.lbpatient.TabIndex = 3
        Me.lbpatient.Text = "Label4"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(200, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "N. Rencontre:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "N. Patient:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nom et Prenom:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGridView1)
        Me.GroupBox2.Location = New System.Drawing.Point(33, 101)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(564, 251)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Factures de la rencontre"
        '
        'lbrequete
        '
        Me.lbrequete.AutoSize = True
        Me.lbrequete.Location = New System.Drawing.Point(51, 355)
        Me.lbrequete.Name = "lbrequete"
        Me.lbrequete.Size = New System.Drawing.Size(39, 13)
        Me.lbrequete.TabIndex = 4
        Me.lbrequete.Text = "Label4"
        Me.lbrequete.Visible = False
        '
        'frmSelectionFacture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 414)
        Me.Controls.Add(Me.lbrequete)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.validerfacture)
        Me.Name = "frmSelectionFacture"
        Me.Text = "frmSelectionFacture"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents validerfacture As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbnom As System.Windows.Forms.Label
    Friend WithEvents lbrencontre As System.Windows.Forms.Label
    Friend WithEvents lbpatient As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbrequete As System.Windows.Forms.Label
End Class
