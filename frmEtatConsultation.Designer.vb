<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEtatConsultation
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.datefin = New System.Windows.Forms.DateTimePicker()
        Me.datedebut = New System.Windows.Forms.DateTimePicker()
        Me.valider = New System.Windows.Forms.Button()
        Me.Consultations = New System.Windows.Forms.GroupBox()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.libelle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nbre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nbre1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.Consultations.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.datefin)
        Me.GroupBox2.Controls.Add(Me.datedebut)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(288, 128)
        Me.GroupBox2.TabIndex = 4
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
        Me.datefin.Location = New System.Drawing.Point(94, 87)
        Me.datefin.Name = "datefin"
        Me.datefin.Size = New System.Drawing.Size(182, 20)
        Me.datefin.TabIndex = 1
        Me.datefin.Value = New Date(2015, 5, 6, 0, 0, 0, 0)
        '
        'datedebut
        '
        Me.datedebut.Location = New System.Drawing.Point(94, 29)
        Me.datedebut.Name = "datedebut"
        Me.datedebut.Size = New System.Drawing.Size(182, 20)
        Me.datedebut.TabIndex = 0
        Me.datedebut.Value = New Date(2015, 5, 6, 0, 0, 0, 0)
        '
        'valider
        '
        Me.valider.Location = New System.Drawing.Point(13, 168)
        Me.valider.Name = "valider"
        Me.valider.Size = New System.Drawing.Size(287, 25)
        Me.valider.TabIndex = 6
        Me.valider.Text = "Valider"
        Me.valider.UseVisualStyleBackColor = True
        '
        'Consultations
        '
        Me.Consultations.Controls.Add(Me.DataGridView)
        Me.Consultations.Location = New System.Drawing.Point(312, 19)
        Me.Consultations.Name = "Consultations"
        Me.Consultations.Size = New System.Drawing.Size(735, 329)
        Me.Consultations.TabIndex = 7
        Me.Consultations.TabStop = False
        Me.Consultations.Text = "Consultations"
        '
        'DataGridView
        '
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.libelle, Me.nbre, Me.nbre1, Me.total})
        Me.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.Size = New System.Drawing.Size(729, 310)
        Me.DataGridView.TabIndex = 0
        '
        'libelle
        '
        Me.libelle.HeaderText = "Bureaux de Consultation"
        Me.libelle.Name = "libelle"
        Me.libelle.Width = 250
        '
        'nbre
        '
        Me.nbre.HeaderText = "Consultations Payés"
        Me.nbre.Name = "nbre"
        Me.nbre.Width = 150
        '
        'nbre1
        '
        Me.nbre1.HeaderText = "Consultations Impayées"
        Me.nbre1.Name = "nbre1"
        Me.nbre1.Width = 150
        '
        'total
        '
        Me.total.HeaderText = "Total"
        Me.total.Name = "total"
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.btnExport.Location = New System.Drawing.Point(13, 212)
        Me.btnExport.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(287, 25)
        Me.btnExport.TabIndex = 11
        Me.btnExport.Text = "Exporter sous Excel"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'frmEtatConsultation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1143, 360)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.Consultations)
        Me.Controls.Add(Me.valider)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmEtatConsultation"
        Me.Text = "frmEtatConsultation"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Consultations.ResumeLayout(False)
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents datefin As System.Windows.Forms.DateTimePicker
    Friend WithEvents datedebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents valider As System.Windows.Forms.Button
    Friend WithEvents Consultations As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents libelle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nbre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nbre1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnExport As System.Windows.Forms.Button
End Class
