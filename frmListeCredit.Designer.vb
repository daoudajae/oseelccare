<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListeCredit
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
        Me.DateDebut = New System.Windows.Forms.DateTimePicker()
        Me.DateFin = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Imprimer = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.DateDebut)
        Me.GroupBox2.Controls.Add(Me.DateFin)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 62)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(454, 148)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Definition de la plage des dates"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(316, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Date de Fin"
        '
        'DateDebut
        '
        Me.DateDebut.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.DateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateDebut.Location = New System.Drawing.Point(20, 70)
        Me.DateDebut.Name = "DateDebut"
        Me.DateDebut.Size = New System.Drawing.Size(200, 20)
        Me.DateDebut.TabIndex = 0
        '
        'DateFin
        '
        Me.DateFin.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.DateFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateFin.Location = New System.Drawing.Point(237, 70)
        Me.DateFin.Name = "DateFin"
        Me.DateFin.Size = New System.Drawing.Size(200, 20)
        Me.DateFin.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(64, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Date de Debut"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(84, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(291, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "LISTE DES PATIENTS A CREDITS"
        '
        'Imprimer
        '
        Me.Imprimer.Location = New System.Drawing.Point(136, 231)
        Me.Imprimer.Name = "Imprimer"
        Me.Imprimer.Size = New System.Drawing.Size(197, 32)
        Me.Imprimer.TabIndex = 10
        Me.Imprimer.Text = "Imprimer"
        Me.Imprimer.UseVisualStyleBackColor = True
        '
        'frmListeCredit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 303)
        Me.Controls.Add(Me.Imprimer)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmListeCredit"
        Me.Text = "frmListeCredit"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateDebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Imprimer As System.Windows.Forms.Button
End Class
