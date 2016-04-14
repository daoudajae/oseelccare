<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRapportdentree
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.datagridpatient = New System.Windows.Forms.DataGridView()
        Me.IDPatient = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.datefin = New System.Windows.Forms.DateTimePicker()
        Me.datedebut = New System.Windows.Forms.DateTimePicker()
        Me.valier = New System.Windows.Forms.Button()
        Me.nomservice = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.datagridpatient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(182, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RAPPORT D'ENTREE PERIODIQUE"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.datagridpatient)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(266, 297)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Numero du Patient"
        '
        'datagridpatient
        '
        Me.datagridpatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridpatient.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDPatient})
        Me.datagridpatient.Location = New System.Drawing.Point(6, 19)
        Me.datagridpatient.Name = "datagridpatient"
        Me.datagridpatient.Size = New System.Drawing.Size(254, 260)
        Me.datagridpatient.TabIndex = 0
        '
        'IDPatient
        '
        Me.IDPatient.HeaderText = "ID Patient"
        Me.IDPatient.Name = "IDPatient"
        Me.IDPatient.Width = 170
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.datefin)
        Me.GroupBox2.Controls.Add(Me.datedebut)
        Me.GroupBox2.Location = New System.Drawing.Point(338, 46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(288, 143)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periode"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Date Fin:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Date début:"
        '
        'datefin
        '
        Me.datefin.Location = New System.Drawing.Point(94, 96)
        Me.datefin.Name = "datefin"
        Me.datefin.Size = New System.Drawing.Size(182, 20)
        Me.datefin.TabIndex = 1
        '
        'datedebut
        '
        Me.datedebut.Location = New System.Drawing.Point(94, 29)
        Me.datedebut.Name = "datedebut"
        Me.datedebut.Size = New System.Drawing.Size(182, 20)
        Me.datedebut.TabIndex = 0
        '
        'valier
        '
        Me.valier.Location = New System.Drawing.Point(339, 285)
        Me.valier.Name = "valier"
        Me.valier.Size = New System.Drawing.Size(287, 25)
        Me.valier.TabIndex = 3
        Me.valier.Text = "Valider"
        Me.valier.UseVisualStyleBackColor = True
        '
        'nomservice
        '
        Me.nomservice.Location = New System.Drawing.Point(15, 29)
        Me.nomservice.Name = "nomservice"
        Me.nomservice.Size = New System.Drawing.Size(261, 20)
        Me.nomservice.TabIndex = 4
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.nomservice)
        Me.GroupBox3.Location = New System.Drawing.Point(339, 195)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(287, 79)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Nom du Service"
        '
        'frmRapportdentree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 378)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.valier)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmRapportdentree"
        Me.Text = "frmRapportdentree"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.datagridpatient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents datagridpatient As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents datefin As System.Windows.Forms.DateTimePicker
    Friend WithEvents datedebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents valier As System.Windows.Forms.Button
    Friend WithEvents nomservice As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents IDPatient As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
