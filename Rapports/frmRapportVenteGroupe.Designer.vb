<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRapportVenteGroupe
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
        Me.btnExport = New System.Windows.Forms.Button()
        Me.valider = New System.Windows.Forms.Button()
        Me.Consultations = New System.Windows.Forms.GroupBox()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
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
        Me.GroupBox2.Location = New System.Drawing.Point(39, 15)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(384, 158)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periode"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 127)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Date Fin:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 44)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Date début:"
        '
        'datefin
        '
        Me.datefin.Location = New System.Drawing.Point(125, 107)
        Me.datefin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.datefin.Name = "datefin"
        Me.datefin.Size = New System.Drawing.Size(241, 22)
        Me.datefin.TabIndex = 1
        Me.datefin.Value = New Date(2015, 6, 18, 0, 0, 0, 0)
        '
        'datedebut
        '
        Me.datedebut.Location = New System.Drawing.Point(125, 36)
        Me.datedebut.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.datedebut.Name = "datedebut"
        Me.datedebut.Size = New System.Drawing.Size(241, 22)
        Me.datedebut.TabIndex = 0
        Me.datedebut.Value = New Date(2015, 6, 18, 0, 0, 0, 0)
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.btnExport.Location = New System.Drawing.Point(39, 278)
        Me.btnExport.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(383, 31)
        Me.btnExport.TabIndex = 13
        Me.btnExport.Text = "Exporter sous Excel"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'valider
        '
        Me.valider.Location = New System.Drawing.Point(39, 224)
        Me.valider.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.valider.Name = "valider"
        Me.valider.Size = New System.Drawing.Size(383, 31)
        Me.valider.TabIndex = 12
        Me.valider.Text = "Valider"
        Me.valider.UseVisualStyleBackColor = True
        '
        'Consultations
        '
        Me.Consultations.Controls.Add(Me.DataGridView)
        Me.Consultations.Location = New System.Drawing.Point(431, 15)
        Me.Consultations.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Consultations.Name = "Consultations"
        Me.Consultations.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Consultations.Size = New System.Drawing.Size(500, 460)
        Me.Consultations.TabIndex = 14
        Me.Consultations.TabStop = False
        Me.Consultations.Text = "Rapport de Vente"
        '
        'DataGridView
        '
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView.Location = New System.Drawing.Point(4, 19)
        Me.DataGridView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.Size = New System.Drawing.Size(492, 437)
        Me.DataGridView.TabIndex = 0
        '
        'frmRapportVenteGroupe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 490)
        Me.Controls.Add(Me.Consultations)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.valider)
        Me.Controls.Add(Me.GroupBox2)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmRapportVenteGroupe"
        Me.Text = "frmRapportVente"
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
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents valider As System.Windows.Forms.Button
    Friend WithEvents Consultations As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
End Class
