<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEtatJournalier
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
        Me.DateDebut = New System.Windows.Forms.DateTimePicker()
        Me.DateFin = New System.Windows.Forms.DateTimePicker()
        Me.agentcaisse = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rapport_journalier = New System.Windows.Forms.Button()
        Me.rapport_detaille_caisse = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rubrique = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'DateDebut
        '
        Me.DateDebut.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.DateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateDebut.Location = New System.Drawing.Point(6, 55)
        Me.DateDebut.Name = "DateDebut"
        Me.DateDebut.Size = New System.Drawing.Size(200, 20)
        Me.DateDebut.TabIndex = 0
        '
        'DateFin
        '
        Me.DateFin.CustomFormat = "yyyy-MM-dd HH:mm:ss"
        Me.DateFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateFin.Location = New System.Drawing.Point(237, 55)
        Me.DateFin.Name = "DateFin"
        Me.DateFin.Size = New System.Drawing.Size(200, 20)
        Me.DateFin.TabIndex = 1
        '
        'agentcaisse
        '
        Me.agentcaisse.FormattingEnabled = True
        Me.agentcaisse.Location = New System.Drawing.Point(16, 61)
        Me.agentcaisse.Name = "agentcaisse"
        Me.agentcaisse.Size = New System.Drawing.Size(421, 21)
        Me.agentcaisse.TabIndex = 3
        Me.agentcaisse.Text = "None"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(176, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Agent de Caisse"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(64, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Date de Debut"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.agentcaisse)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(35, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(454, 100)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Choix de l'Agent de  Caisse"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.DateDebut)
        Me.GroupBox2.Controls.Add(Me.DateFin)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(35, 173)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(454, 102)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Definition de la plage des dates"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(318, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Date de Fin"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(74, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(398, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "ETAT JOURNALIER FACTURATION ET CAISSE"
        '
        'rapport_journalier
        '
        Me.rapport_journalier.Location = New System.Drawing.Point(32, 437)
        Me.rapport_journalier.Name = "rapport_journalier"
        Me.rapport_journalier.Size = New System.Drawing.Size(141, 44)
        Me.rapport_journalier.TabIndex = 9
        Me.rapport_journalier.Text = "Journal de Encaissement"
        Me.rapport_journalier.UseVisualStyleBackColor = True
        '
        'rapport_detaille_caisse
        '
        Me.rapport_detaille_caisse.Location = New System.Drawing.Point(348, 437)
        Me.rapport_detaille_caisse.Name = "rapport_detaille_caisse"
        Me.rapport_detaille_caisse.Size = New System.Drawing.Size(141, 44)
        Me.rapport_detaille_caisse.TabIndex = 11
        Me.rapport_detaille_caisse.Text = "Rapport Detaillé       Caisse"
        Me.rapport_detaille_caisse.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(112, 91)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(203, 24)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Rapport detaille par rubrique"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rubrique)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Location = New System.Drawing.Point(32, 298)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(457, 121)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rapport Detaille par Rubrique"
        '
        'rubrique
        '
        Me.rubrique.FormattingEnabled = True
        Me.rubrique.Items.AddRange(New Object() {"70 110 - RECETTE MEDICAMENTS", "70 610 - RECETTE CONSULTATIONS", "70 620 - RECETTE GYNECO-OBSTETRIQUE", "70 630 - RECETTE CHIRURGIE", "70 640 - RECETTE LABORATOIRE", "70 650 - RECETTE IMAGERIE", "70 660 -  RECETTE HOSPITALISATION", "70 670 - RECETTE KINESITHERAPIE", "70 675 - RECETTE SMI", "70 680 - RECETTE ORL"})
        Me.rubrique.Location = New System.Drawing.Point(19, 47)
        Me.rubrique.Name = "rubrique"
        Me.rubrique.Size = New System.Drawing.Size(399, 21)
        Me.rubrique.TabIndex = 13
        '
        'frmEtatJournalier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 510)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.rapport_detaille_caisse)
        Me.Controls.Add(Me.rapport_journalier)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmEtatJournalier"
        Me.Text = "frmEtatJournalier"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateDebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents agentcaisse As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rapport_journalier As System.Windows.Forms.Button
    Friend WithEvents rapport_detaille_caisse As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rubrique As System.Windows.Forms.ComboBox
End Class
