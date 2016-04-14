<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEtatCredit
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvListePatients = New System.Windows.Forms.DataGridView()
        Me.clicdroit = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ValiderPayementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimerFacture = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTotalAssurances = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grpPeriode = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpDebut = New System.Windows.Forms.DateTimePicker()
        Me.cboAssurances = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtassure = New System.Windows.Forms.TextBox()
        Me.txtsociete = New System.Windows.Forms.TextBox()
        Me.txtpatient = New System.Windows.Forms.TextBox()
        Me.dgvRencontres = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgvFactures = New System.Windows.Forms.DataGridView()
        Me.btnValiderFacture = New System.Windows.Forms.Button()
        CType(Me.dgvListePatients, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.clicdroit.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpPeriode.SuspendLayout()
        CType(Me.dgvRencontres, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvFactures, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvListePatients
        '
        Me.dgvListePatients.AllowUserToAddRows = False
        Me.dgvListePatients.AllowUserToDeleteRows = False
        Me.dgvListePatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvListePatients.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListePatients.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListePatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListePatients.ContextMenuStrip = Me.clicdroit
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvListePatients.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvListePatients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvListePatients.Location = New System.Drawing.Point(4, 19)
        Me.dgvListePatients.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvListePatients.MultiSelect = False
        Me.dgvListePatients.Name = "dgvListePatients"
        Me.dgvListePatients.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListePatients.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvListePatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListePatients.Size = New System.Drawing.Size(982, 137)
        Me.dgvListePatients.TabIndex = 4
        '
        'clicdroit
        '
        Me.clicdroit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ValiderPayementToolStripMenuItem})
        Me.clicdroit.Name = "clicdroit"
        Me.clicdroit.Size = New System.Drawing.Size(193, 28)
        '
        'ValiderPayementToolStripMenuItem
        '
        Me.ValiderPayementToolStripMenuItem.Name = "ValiderPayementToolStripMenuItem"
        Me.ValiderPayementToolStripMenuItem.Size = New System.Drawing.Size(192, 24)
        Me.ValiderPayementToolStripMenuItem.Text = "Valider Payement"
        '
        'btnImprimerFacture
        '
        Me.btnImprimerFacture.Location = New System.Drawing.Point(385, 520)
        Me.btnImprimerFacture.Margin = New System.Windows.Forms.Padding(4)
        Me.btnImprimerFacture.Name = "btnImprimerFacture"
        Me.btnImprimerFacture.Size = New System.Drawing.Size(160, 38)
        Me.btnImprimerFacture.TabIndex = 13
        Me.btnImprimerFacture.Text = "Facture"
        Me.btnImprimerFacture.UseVisualStyleBackColor = True
        Me.btnImprimerFacture.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTotalAssurances)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.grpPeriode)
        Me.GroupBox1.Controls.Add(Me.cboAssurances)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtassure)
        Me.GroupBox1.Controls.Add(Me.txtsociete)
        Me.GroupBox1.Controls.Add(Me.txtpatient)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(986, 104)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Information Du Patient"
        '
        'txtTotalAssurances
        '
        Me.txtTotalAssurances.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAssurances.Location = New System.Drawing.Point(236, 38)
        Me.txtTotalAssurances.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotalAssurances.Name = "txtTotalAssurances"
        Me.txtTotalAssurances.ReadOnly = True
        Me.txtTotalAssurances.Size = New System.Drawing.Size(160, 24)
        Me.txtTotalAssurances.TabIndex = 11
        Me.txtTotalAssurances.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(242, 15)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Total Assurance"
        '
        'grpPeriode
        '
        Me.grpPeriode.Controls.Add(Me.Label5)
        Me.grpPeriode.Controls.Add(Me.Label4)
        Me.grpPeriode.Controls.Add(Me.dtpFin)
        Me.grpPeriode.Controls.Add(Me.dtpDebut)
        Me.grpPeriode.Location = New System.Drawing.Point(796, 16)
        Me.grpPeriode.Name = "grpPeriode"
        Me.grpPeriode.Size = New System.Drawing.Size(183, 81)
        Me.grpPeriode.TabIndex = 9
        Me.grpPeriode.TabStop = False
        Me.grpPeriode.Text = "Periode"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "au"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "du"
        '
        'dtpFin
        '
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFin.Location = New System.Drawing.Point(42, 50)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(135, 22)
        Me.dtpFin.TabIndex = 8
        '
        'dtpDebut
        '
        Me.dtpDebut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDebut.Location = New System.Drawing.Point(42, 22)
        Me.dtpDebut.Name = "dtpDebut"
        Me.dtpDebut.Size = New System.Drawing.Size(135, 22)
        Me.dtpDebut.TabIndex = 7
        '
        'cboAssurances
        '
        Me.cboAssurances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAssurances.FormattingEnabled = True
        Me.cboAssurances.Location = New System.Drawing.Point(8, 39)
        Me.cboAssurances.Name = "cboAssurances"
        Me.cboAssurances.Size = New System.Drawing.Size(221, 24)
        Me.cboAssurances.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 19)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Societé"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(521, 15)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nom de l'Assuré"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(672, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "N° Patient"
        Me.Label1.Visible = False
        '
        'txtassure
        '
        Me.txtassure.Location = New System.Drawing.Point(524, 36)
        Me.txtassure.Margin = New System.Windows.Forms.Padding(4)
        Me.txtassure.Name = "txtassure"
        Me.txtassure.Size = New System.Drawing.Size(236, 22)
        Me.txtassure.TabIndex = 2
        Me.txtassure.Visible = False
        '
        'txtsociete
        '
        Me.txtsociete.Location = New System.Drawing.Point(523, 66)
        Me.txtsociete.Margin = New System.Windows.Forms.Padding(4)
        Me.txtsociete.Name = "txtsociete"
        Me.txtsociete.Size = New System.Drawing.Size(221, 22)
        Me.txtsociete.TabIndex = 1
        Me.txtsociete.Visible = False
        '
        'txtpatient
        '
        Me.txtpatient.Location = New System.Drawing.Point(675, 38)
        Me.txtpatient.Margin = New System.Windows.Forms.Padding(4)
        Me.txtpatient.Name = "txtpatient"
        Me.txtpatient.Size = New System.Drawing.Size(114, 22)
        Me.txtpatient.TabIndex = 0
        Me.txtpatient.Visible = False
        '
        'dgvRencontres
        '
        Me.dgvRencontres.AllowUserToAddRows = False
        Me.dgvRencontres.AllowUserToDeleteRows = False
        Me.dgvRencontres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvRencontres.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRencontres.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRencontres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRencontres.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvRencontres.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRencontres.Location = New System.Drawing.Point(4, 19)
        Me.dgvRencontres.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvRencontres.Name = "dgvRencontres"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRencontres.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvRencontres.Size = New System.Drawing.Size(528, 198)
        Me.dgvRencontres.TabIndex = 15
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvRencontres)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 293)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(536, 221)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Liste des Rencontres"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvListePatients)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 125)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(990, 160)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Liste des Patients"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgvFactures)
        Me.GroupBox4.Location = New System.Drawing.Point(557, 293)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(446, 221)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Factures de la rencontre"
        '
        'dgvFactures
        '
        Me.dgvFactures.AllowUserToAddRows = False
        Me.dgvFactures.AllowUserToDeleteRows = False
        Me.dgvFactures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvFactures.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFactures.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvFactures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFactures.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvFactures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFactures.Location = New System.Drawing.Point(4, 19)
        Me.dgvFactures.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvFactures.Name = "dgvFactures"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFactures.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvFactures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFactures.Size = New System.Drawing.Size(438, 198)
        Me.dgvFactures.TabIndex = 0
        '
        'btnValiderFacture
        '
        Me.btnValiderFacture.Location = New System.Drawing.Point(825, 522)
        Me.btnValiderFacture.Margin = New System.Windows.Forms.Padding(4)
        Me.btnValiderFacture.Name = "btnValiderFacture"
        Me.btnValiderFacture.Size = New System.Drawing.Size(178, 36)
        Me.btnValiderFacture.TabIndex = 19
        Me.btnValiderFacture.Text = "Valider Facture"
        Me.btnValiderFacture.UseVisualStyleBackColor = True
        '
        'frmEtatCredit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 571)
        Me.Controls.Add(Me.btnValiderFacture)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnImprimerFacture)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmEtatCredit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Etat Des Crédits"
        CType(Me.dgvListePatients, System.ComponentModel.ISupportInitialize).EndInit()
        Me.clicdroit.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpPeriode.ResumeLayout(False)
        Me.grpPeriode.PerformLayout()
        CType(Me.dgvRencontres, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvFactures, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvListePatients As System.Windows.Forms.DataGridView
    Friend WithEvents clicdroit As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ValiderPayementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnImprimerFacture As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtpatient As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtassure As System.Windows.Forms.TextBox
    Friend WithEvents txtsociete As System.Windows.Forms.TextBox
    Friend WithEvents dgvRencontres As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvFactures As System.Windows.Forms.DataGridView
    Friend WithEvents btnValiderFacture As System.Windows.Forms.Button
    Friend WithEvents grpPeriode As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboAssurances As System.Windows.Forms.ComboBox
    Friend WithEvents txtTotalAssurances As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
