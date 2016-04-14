<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSuiviPrescription
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.prescripteur = New System.Windows.Forms.ComboBox()
        Me.valider = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.controleviscerale = New System.Windows.Forms.CheckBox()
        Me.consulviscerale = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CheckBox11 = New System.Windows.Forms.CheckBox()
        Me.CheckBox12 = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.controleinfectiologue = New System.Windows.Forms.CheckBox()
        Me.consultinfectiologue = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.controlegyneco = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.consultgyneco = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.controletrauma = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.consultrauma = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.controleorl = New System.Windows.Forms.CheckBox()
        Me.consultorl = New System.Windows.Forms.CheckBox()
        Me.controleuro = New System.Windows.Forms.CheckBox()
        Me.consulturo = New System.Windows.Forms.CheckBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.datefin)
        Me.GroupBox2.Controls.Add(Me.datedebut)
        Me.GroupBox2.Location = New System.Drawing.Point(445, 94)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(288, 128)
        Me.GroupBox2.TabIndex = 3
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
        '
        'datedebut
        '
        Me.datedebut.Location = New System.Drawing.Point(94, 29)
        Me.datedebut.Name = "datedebut"
        Me.datedebut.Size = New System.Drawing.Size(182, 20)
        Me.datedebut.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.prescripteur)
        Me.GroupBox1.Location = New System.Drawing.Point(446, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(287, 71)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Choix du Prescripteur"
        '
        'prescripteur
        '
        Me.prescripteur.FormattingEnabled = True
        Me.prescripteur.Location = New System.Drawing.Point(6, 28)
        Me.prescripteur.Name = "prescripteur"
        Me.prescripteur.Size = New System.Drawing.Size(269, 21)
        Me.prescripteur.TabIndex = 6
        '
        'valider
        '
        Me.valider.Location = New System.Drawing.Point(446, 228)
        Me.valider.Name = "valider"
        Me.valider.Size = New System.Drawing.Size(287, 25)
        Me.valider.TabIndex = 5
        Me.valider.Text = "Valider"
        Me.valider.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.controleviscerale)
        Me.GroupBox3.Controls.Add(Me.consulviscerale)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.CheckBox11)
        Me.GroupBox3.Controls.Add(Me.CheckBox12)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.controleinfectiologue)
        Me.GroupBox3.Controls.Add(Me.consultinfectiologue)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.controlegyneco)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.consultgyneco)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.controletrauma)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.consultrauma)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.controleorl)
        Me.GroupBox3.Controls.Add(Me.consultorl)
        Me.GroupBox3.Controls.Add(Me.controleuro)
        Me.GroupBox3.Controls.Add(Me.consulturo)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(296, 291)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Inclusion"
        '
        'controleviscerale
        '
        Me.controleviscerale.AutoSize = True
        Me.controleviscerale.Enabled = False
        Me.controleviscerale.Location = New System.Drawing.Point(8, 261)
        Me.controleviscerale.Name = "controleviscerale"
        Me.controleviscerale.Size = New System.Drawing.Size(65, 17)
        Me.controleviscerale.TabIndex = 19
        Me.controleviscerale.Text = "Contrôle"
        Me.controleviscerale.UseVisualStyleBackColor = True
        '
        'consulviscerale
        '
        Me.consulviscerale.AutoSize = True
        Me.consulviscerale.Enabled = False
        Me.consulviscerale.Location = New System.Drawing.Point(7, 238)
        Me.consulviscerale.Name = "consulviscerale"
        Me.consulviscerale.Size = New System.Drawing.Size(84, 17)
        Me.consulviscerale.TabIndex = 18
        Me.consulviscerale.Text = "Consultation"
        Me.consulviscerale.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Enabled = False
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(20, 222)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Chir. Viscerale"
        '
        'CheckBox11
        '
        Me.CheckBox11.AutoSize = True
        Me.CheckBox11.Enabled = False
        Me.CheckBox11.Location = New System.Drawing.Point(153, 189)
        Me.CheckBox11.Name = "CheckBox11"
        Me.CheckBox11.Size = New System.Drawing.Size(65, 17)
        Me.CheckBox11.TabIndex = 16
        Me.CheckBox11.Text = "Contrôle"
        Me.CheckBox11.UseVisualStyleBackColor = True
        '
        'CheckBox12
        '
        Me.CheckBox12.AutoSize = True
        Me.CheckBox12.Enabled = False
        Me.CheckBox12.Location = New System.Drawing.Point(153, 166)
        Me.CheckBox12.Name = "CheckBox12"
        Me.CheckBox12.Size = New System.Drawing.Size(84, 17)
        Me.CheckBox12.TabIndex = 15
        Me.CheckBox12.Text = "Consultation"
        Me.CheckBox12.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Enabled = False
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(169, 150)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Ped."
        '
        'controleinfectiologue
        '
        Me.controleinfectiologue.AutoSize = True
        Me.controleinfectiologue.Location = New System.Drawing.Point(7, 192)
        Me.controleinfectiologue.Name = "controleinfectiologue"
        Me.controleinfectiologue.Size = New System.Drawing.Size(65, 17)
        Me.controleinfectiologue.TabIndex = 13
        Me.controleinfectiologue.Text = "Contrôle"
        Me.controleinfectiologue.UseVisualStyleBackColor = True
        '
        'consultinfectiologue
        '
        Me.consultinfectiologue.AutoSize = True
        Me.consultinfectiologue.Location = New System.Drawing.Point(6, 169)
        Me.consultinfectiologue.Name = "consultinfectiologue"
        Me.consultinfectiologue.Size = New System.Drawing.Size(84, 17)
        Me.consultinfectiologue.TabIndex = 12
        Me.consultinfectiologue.Text = "Consultation"
        Me.consultinfectiologue.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(20, 150)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Intectiologue"
        '
        'controlegyneco
        '
        Me.controlegyneco.AutoSize = True
        Me.controlegyneco.Location = New System.Drawing.Point(153, 121)
        Me.controlegyneco.Name = "controlegyneco"
        Me.controlegyneco.Size = New System.Drawing.Size(65, 17)
        Me.controlegyneco.TabIndex = 8
        Me.controlegyneco.Text = "Contrôle"
        Me.controlegyneco.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(169, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Gyneco"
        '
        'consultgyneco
        '
        Me.consultgyneco.AutoSize = True
        Me.consultgyneco.Location = New System.Drawing.Point(153, 98)
        Me.consultgyneco.Name = "consultgyneco"
        Me.consultgyneco.Size = New System.Drawing.Size(84, 17)
        Me.consultgyneco.TabIndex = 7
        Me.consultgyneco.Text = "Consultation"
        Me.consultgyneco.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(169, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Trauma"
        '
        'controletrauma
        '
        Me.controletrauma.AutoSize = True
        Me.controletrauma.Location = New System.Drawing.Point(153, 58)
        Me.controletrauma.Name = "controletrauma"
        Me.controletrauma.Size = New System.Drawing.Size(65, 17)
        Me.controletrauma.TabIndex = 7
        Me.controletrauma.Text = "Contrôle"
        Me.controletrauma.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Uro"
        '
        'consultrauma
        '
        Me.consultrauma.AutoSize = True
        Me.consultrauma.Location = New System.Drawing.Point(153, 35)
        Me.consultrauma.Name = "consultrauma"
        Me.consultrauma.Size = New System.Drawing.Size(84, 17)
        Me.consultrauma.TabIndex = 7
        Me.consultrauma.Text = "Consultation"
        Me.consultrauma.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "ORL"
        '
        'controleorl
        '
        Me.controleorl.AutoSize = True
        Me.controleorl.Location = New System.Drawing.Point(7, 121)
        Me.controleorl.Name = "controleorl"
        Me.controleorl.Size = New System.Drawing.Size(65, 17)
        Me.controleorl.TabIndex = 8
        Me.controleorl.Text = "Contrôle"
        Me.controleorl.UseVisualStyleBackColor = True
        '
        'consultorl
        '
        Me.consultorl.AutoSize = True
        Me.consultorl.Location = New System.Drawing.Point(6, 98)
        Me.consultorl.Name = "consultorl"
        Me.consultorl.Size = New System.Drawing.Size(84, 17)
        Me.consultorl.TabIndex = 7
        Me.consultorl.Text = "Consultation"
        Me.consultorl.UseVisualStyleBackColor = True
        '
        'controleuro
        '
        Me.controleuro.AutoSize = True
        Me.controleuro.Location = New System.Drawing.Point(6, 58)
        Me.controleuro.Name = "controleuro"
        Me.controleuro.Size = New System.Drawing.Size(65, 17)
        Me.controleuro.TabIndex = 7
        Me.controleuro.Text = "Contrôle"
        Me.controleuro.UseVisualStyleBackColor = True
        '
        'consulturo
        '
        Me.consulturo.AutoSize = True
        Me.consulturo.Location = New System.Drawing.Point(6, 35)
        Me.consulturo.Name = "consulturo"
        Me.consulturo.Size = New System.Drawing.Size(84, 17)
        Me.consulturo.TabIndex = 0
        Me.consulturo.Text = "Consultation"
        Me.consulturo.UseVisualStyleBackColor = True
        '
        'frmSuiviPrescription
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 311)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.valider)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmSuiviPrescription"
        Me.Text = "frmSuiviPrescription"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents datefin As System.Windows.Forms.DateTimePicker
    Friend WithEvents datedebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents valider As System.Windows.Forms.Button
    Friend WithEvents prescripteur As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents controletrauma As System.Windows.Forms.CheckBox
    Friend WithEvents consultrauma As System.Windows.Forms.CheckBox
    Friend WithEvents controleorl As System.Windows.Forms.CheckBox
    Friend WithEvents consultorl As System.Windows.Forms.CheckBox
    Friend WithEvents controleuro As System.Windows.Forms.CheckBox
    Friend WithEvents consulturo As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents controlegyneco As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents consultgyneco As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents controleviscerale As System.Windows.Forms.CheckBox
    Friend WithEvents consulviscerale As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CheckBox11 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox12 As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents controleinfectiologue As System.Windows.Forms.CheckBox
    Friend WithEvents consultinfectiologue As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
