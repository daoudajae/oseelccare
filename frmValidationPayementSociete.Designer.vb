<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValidationPayementSociete
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
        Me.grpInfo = New System.Windows.Forms.GroupBox()
        Me.typebon = New System.Windows.Forms.Label()
        Me.daterencontre = New System.Windows.Forms.Label()
        Me.nomprenom = New System.Windows.Forms.Label()
        Me.lblBonInfo = New System.Windows.Forms.Label()
        Me.lblEncInfo = New System.Windows.Forms.Label()
        Me.lblPatientInfo = New System.Windows.Forms.Label()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ddd = New System.Windows.Forms.Label()
        Me.lblbillamount = New System.Windows.Forms.Label()
        Me.lblpatientpaid = New System.Windows.Forms.Label()
        Me.lblfrimpaid = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtsociete = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.labersocieteverse = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cbetatsociete = New System.Windows.Forms.CheckBox()
        Me.cbetatpatient = New System.Windows.Forms.CheckBox()
        Me.lbldatepatientpaid = New System.Windows.Forms.Label()
        Me.lbldatefirmpaid = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblpatientaverser = New System.Windows.Forms.Label()
        Me.txtpatient = New System.Windows.Forms.TextBox()
        Me.payement = New System.Windows.Forms.GroupBox()
        Me.grpInfo.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.payement.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpInfo
        '
        Me.grpInfo.Controls.Add(Me.typebon)
        Me.grpInfo.Controls.Add(Me.daterencontre)
        Me.grpInfo.Controls.Add(Me.nomprenom)
        Me.grpInfo.Controls.Add(Me.lblBonInfo)
        Me.grpInfo.Controls.Add(Me.lblEncInfo)
        Me.grpInfo.Controls.Add(Me.lblPatientInfo)
        Me.grpInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInfo.ForeColor = System.Drawing.Color.Teal
        Me.grpInfo.Location = New System.Drawing.Point(485, 12)
        Me.grpInfo.Name = "grpInfo"
        Me.grpInfo.Size = New System.Drawing.Size(357, 94)
        Me.grpInfo.TabIndex = 5
        Me.grpInfo.TabStop = False
        Me.grpInfo.Text = "Information sur le patient"
        '
        'typebon
        '
        Me.typebon.AutoSize = True
        Me.typebon.ForeColor = System.Drawing.Color.Maroon
        Me.typebon.Location = New System.Drawing.Point(92, 76)
        Me.typebon.Name = "typebon"
        Me.typebon.Size = New System.Drawing.Size(12, 16)
        Me.typebon.TabIndex = 6
        Me.typebon.Text = "'"
        '
        'daterencontre
        '
        Me.daterencontre.AutoSize = True
        Me.daterencontre.ForeColor = System.Drawing.Color.Maroon
        Me.daterencontre.Location = New System.Drawing.Point(92, 49)
        Me.daterencontre.Name = "daterencontre"
        Me.daterencontre.Size = New System.Drawing.Size(12, 16)
        Me.daterencontre.TabIndex = 5
        Me.daterencontre.Text = "'"
        '
        'nomprenom
        '
        Me.nomprenom.AutoSize = True
        Me.nomprenom.ForeColor = System.Drawing.Color.Maroon
        Me.nomprenom.Location = New System.Drawing.Point(92, 22)
        Me.nomprenom.Name = "nomprenom"
        Me.nomprenom.Size = New System.Drawing.Size(12, 16)
        Me.nomprenom.TabIndex = 4
        Me.nomprenom.Text = "'"
        '
        'lblBonInfo
        '
        Me.lblBonInfo.AutoSize = True
        Me.lblBonInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblBonInfo.Location = New System.Drawing.Point(9, 74)
        Me.lblBonInfo.Name = "lblBonInfo"
        Me.lblBonInfo.Size = New System.Drawing.Size(39, 16)
        Me.lblBonInfo.TabIndex = 3
        Me.lblBonInfo.Text = "Bon:"
        Me.lblBonInfo.Visible = False
        '
        'lblEncInfo
        '
        Me.lblEncInfo.AutoSize = True
        Me.lblEncInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblEncInfo.Location = New System.Drawing.Point(9, 49)
        Me.lblEncInfo.Name = "lblEncInfo"
        Me.lblEncInfo.Size = New System.Drawing.Size(83, 16)
        Me.lblEncInfo.TabIndex = 2
        Me.lblEncInfo.Text = "Rencontre:"
        Me.lblEncInfo.Visible = False
        '
        'lblPatientInfo
        '
        Me.lblPatientInfo.AutoSize = True
        Me.lblPatientInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblPatientInfo.Location = New System.Drawing.Point(9, 22)
        Me.lblPatientInfo.Name = "lblPatientInfo"
        Me.lblPatientInfo.Size = New System.Drawing.Size(52, 16)
        Me.lblPatientInfo.TabIndex = 1
        Me.lblPatientInfo.Text = "Noms:"
        Me.lblPatientInfo.Visible = False
        '
        'DataGridView
        '
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Location = New System.Drawing.Point(6, 19)
        Me.DataGridView.MultiSelect = False
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView.Size = New System.Drawing.Size(450, 265)
        Me.DataGridView.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(467, 303)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ELEMENTS DE LA FACTURE"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Teal
        Me.GroupBox2.Location = New System.Drawing.Point(486, 112)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(357, 75)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Information sur la Societé"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(9, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(161, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Personne à Contacter:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(9, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 16)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Noms:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.ddd)
        Me.GroupBox3.Controls.Add(Me.lblbillamount)
        Me.GroupBox3.Controls.Add(Me.lblpatientpaid)
        Me.GroupBox3.Controls.Add(Me.lblfrimpaid)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Teal
        Me.GroupBox3.Location = New System.Drawing.Point(486, 193)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(357, 122)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detail de la Facture"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(289, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "CFA"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(289, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 16)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "CFA"
        '
        'ddd
        '
        Me.ddd.AutoSize = True
        Me.ddd.ForeColor = System.Drawing.Color.Maroon
        Me.ddd.Location = New System.Drawing.Point(289, 27)
        Me.ddd.Name = "ddd"
        Me.ddd.Size = New System.Drawing.Size(37, 16)
        Me.ddd.TabIndex = 10
        Me.ddd.Text = "CFA"
        '
        'lblbillamount
        '
        Me.lblbillamount.AutoSize = True
        Me.lblbillamount.ForeColor = System.Drawing.Color.Maroon
        Me.lblbillamount.Location = New System.Drawing.Point(145, 27)
        Me.lblbillamount.Name = "lblbillamount"
        Me.lblbillamount.Size = New System.Drawing.Size(12, 16)
        Me.lblbillamount.TabIndex = 7
        Me.lblbillamount.Text = "'"
        '
        'lblpatientpaid
        '
        Me.lblpatientpaid.AutoSize = True
        Me.lblpatientpaid.ForeColor = System.Drawing.Color.Maroon
        Me.lblpatientpaid.Location = New System.Drawing.Point(145, 57)
        Me.lblpatientpaid.Name = "lblpatientpaid"
        Me.lblpatientpaid.Size = New System.Drawing.Size(12, 16)
        Me.lblpatientpaid.TabIndex = 8
        Me.lblpatientpaid.Text = "'"
        '
        'lblfrimpaid
        '
        Me.lblfrimpaid.AutoSize = True
        Me.lblfrimpaid.ForeColor = System.Drawing.Color.Maroon
        Me.lblfrimpaid.Location = New System.Drawing.Point(145, 87)
        Me.lblfrimpaid.Name = "lblfrimpaid"
        Me.lblfrimpaid.Size = New System.Drawing.Size(12, 16)
        Me.lblfrimpaid.TabIndex = 9
        Me.lblfrimpaid.Text = "'"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(16, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Solde Total:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(16, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Solde Societe:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(15, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Solde Patient:"
        '
        'txtsociete
        '
        Me.txtsociete.Location = New System.Drawing.Point(177, 19)
        Me.txtsociete.Name = "txtsociete"
        Me.txtsociete.Size = New System.Drawing.Size(153, 20)
        Me.txtsociete.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(735, 399)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(149, 30)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Valider"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'labersocieteverse
        '
        Me.labersocieteverse.AutoSize = True
        Me.labersocieteverse.Location = New System.Drawing.Point(27, 26)
        Me.labersocieteverse.Name = "labersocieteverse"
        Me.labersocieteverse.Size = New System.Drawing.Size(126, 13)
        Me.labersocieteverse.TabIndex = 11
        Me.labersocieteverse.Text = "Montant à verser Societe"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(735, 446)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(149, 30)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Anuler"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cbetatsociete)
        Me.GroupBox4.Controls.Add(Me.cbetatpatient)
        Me.GroupBox4.Controls.Add(Me.lbldatepatientpaid)
        Me.GroupBox4.Controls.Add(Me.lbldatefirmpaid)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Teal
        Me.GroupBox4.Location = New System.Drawing.Point(12, 332)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(356, 144)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Etat Paiement"
        '
        'cbetatsociete
        '
        Me.cbetatsociete.AutoSize = True
        Me.cbetatsociete.CausesValidation = False
        Me.cbetatsociete.Enabled = False
        Me.cbetatsociete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.cbetatsociete.ForeColor = System.Drawing.Color.Black
        Me.cbetatsociete.Location = New System.Drawing.Point(207, 67)
        Me.cbetatsociete.Name = "cbetatsociete"
        Me.cbetatsociete.Size = New System.Drawing.Size(132, 17)
        Me.cbetatsociete.TabIndex = 24
        Me.cbetatsociete.Text = "Etat de la Facture:"
        Me.cbetatsociete.UseVisualStyleBackColor = True
        '
        'cbetatpatient
        '
        Me.cbetatpatient.AutoSize = True
        Me.cbetatpatient.CausesValidation = False
        Me.cbetatpatient.Enabled = False
        Me.cbetatpatient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.cbetatpatient.ForeColor = System.Drawing.Color.Black
        Me.cbetatpatient.Location = New System.Drawing.Point(17, 67)
        Me.cbetatpatient.Name = "cbetatpatient"
        Me.cbetatpatient.Size = New System.Drawing.Size(132, 17)
        Me.cbetatpatient.TabIndex = 23
        Me.cbetatpatient.Text = "Etat de la Facture:"
        Me.cbetatpatient.UseVisualStyleBackColor = True
        '
        'lbldatepatientpaid
        '
        Me.lbldatepatientpaid.AutoSize = True
        Me.lbldatepatientpaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lbldatepatientpaid.ForeColor = System.Drawing.Color.Black
        Me.lbldatepatientpaid.Location = New System.Drawing.Point(20, 125)
        Me.lbldatepatientpaid.Name = "lbldatepatientpaid"
        Me.lbldatepatientpaid.Size = New System.Drawing.Size(9, 13)
        Me.lbldatepatientpaid.TabIndex = 22
        Me.lbldatepatientpaid.Text = "'"
        '
        'lbldatefirmpaid
        '
        Me.lbldatefirmpaid.AutoSize = True
        Me.lbldatefirmpaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lbldatefirmpaid.ForeColor = System.Drawing.Color.Black
        Me.lbldatefirmpaid.Location = New System.Drawing.Point(211, 125)
        Me.lbldatefirmpaid.Name = "lbldatefirmpaid"
        Me.lbldatefirmpaid.Size = New System.Drawing.Size(9, 13)
        Me.lbldatefirmpaid.TabIndex = 21
        Me.lbldatefirmpaid.Text = "'"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(15, 103)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(111, 13)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Date de paiement:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(204, 103)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(111, 13)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Date de paiement:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(218, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 16)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Societe:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(15, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 16)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Patient:"
        '
        'lblpatientaverser
        '
        Me.lblpatientaverser.AutoSize = True
        Me.lblpatientaverser.Location = New System.Drawing.Point(27, 74)
        Me.lblpatientaverser.Name = "lblpatientaverser"
        Me.lblpatientaverser.Size = New System.Drawing.Size(122, 13)
        Me.lblpatientaverser.TabIndex = 14
        Me.lblpatientaverser.Text = "Montant à verser patient"
        '
        'txtpatient
        '
        Me.txtpatient.Location = New System.Drawing.Point(177, 71)
        Me.txtpatient.Name = "txtpatient"
        Me.txtpatient.Size = New System.Drawing.Size(153, 20)
        Me.txtpatient.TabIndex = 15
        '
        'payement
        '
        Me.payement.Controls.Add(Me.labersocieteverse)
        Me.payement.Controls.Add(Me.txtpatient)
        Me.payement.Controls.Add(Me.txtsociete)
        Me.payement.Controls.Add(Me.lblpatientaverser)
        Me.payement.Location = New System.Drawing.Point(374, 332)
        Me.payement.Name = "payement"
        Me.payement.Size = New System.Drawing.Size(355, 144)
        Me.payement.TabIndex = 16
        Me.payement.TabStop = False
        Me.payement.Text = "Valider Payement"
        '
        'frmValidationPayementSociete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 514)
        Me.Controls.Add(Me.payement)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpInfo)
        Me.Name = "frmValidationPayementSociete"
        Me.Text = "frmValidationPayementSociete"
        Me.grpInfo.ResumeLayout(False)
        Me.grpInfo.PerformLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.payement.ResumeLayout(False)
        Me.payement.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblBonInfo As System.Windows.Forms.Label
    Friend WithEvents lblEncInfo As System.Windows.Forms.Label
    Friend WithEvents lblPatientInfo As System.Windows.Forms.Label
    Friend WithEvents typebon As System.Windows.Forms.Label
    Friend WithEvents daterencontre As System.Windows.Forms.Label
    Friend WithEvents nomprenom As System.Windows.Forms.Label
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtsociete As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents labersocieteverse As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ddd As System.Windows.Forms.Label
    Friend WithEvents lblbillamount As System.Windows.Forms.Label
    Friend WithEvents lblpatientpaid As System.Windows.Forms.Label
    Friend WithEvents lblfrimpaid As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbldatepatientpaid As System.Windows.Forms.Label
    Friend WithEvents lbldatefirmpaid As System.Windows.Forms.Label
    Friend WithEvents cbetatsociete As System.Windows.Forms.CheckBox
    Friend WithEvents cbetatpatient As System.Windows.Forms.CheckBox
    Friend WithEvents lblpatientaverser As System.Windows.Forms.Label
    Friend WithEvents txtpatient As System.Windows.Forms.TextBox
    Friend WithEvents payement As System.Windows.Forms.GroupBox
End Class
