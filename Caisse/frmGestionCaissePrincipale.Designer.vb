<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGestionCaissePrincipale
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
        Me.grpGestion = New System.Windows.Forms.GroupBox()
        Me.cboContrepartie = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtMemo = New System.Windows.Forms.TextBox()
        Me.txtDebitCredit = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTotalCredit = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotalDebit = New System.Windows.Forms.TextBox()
        Me.txtCpteTresorerie = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnQuitter = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSolde = New System.Windows.Forms.TextBox()
        Me.dgvCaisse = New System.Windows.Forms.DataGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtClient = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMontant = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNumeroQuittancier = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRefFacture = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtNumOrdre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSelectOption = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtNumJournal = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnCreerJournal = New System.Windows.Forms.Button()
        Me.grpGestion.SuspendLayout()
        CType(Me.dgvCaisse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpGestion
        '
        Me.grpGestion.Controls.Add(Me.cboContrepartie)
        Me.grpGestion.Controls.Add(Me.Label16)
        Me.grpGestion.Controls.Add(Me.txtMemo)
        Me.grpGestion.Controls.Add(Me.txtDebitCredit)
        Me.grpGestion.Controls.Add(Me.Label15)
        Me.grpGestion.Controls.Add(Me.txtTotalCredit)
        Me.grpGestion.Controls.Add(Me.Label14)
        Me.grpGestion.Controls.Add(Me.txtTotalDebit)
        Me.grpGestion.Controls.Add(Me.txtCpteTresorerie)
        Me.grpGestion.Controls.Add(Me.Label11)
        Me.grpGestion.Controls.Add(Me.Label10)
        Me.grpGestion.Controls.Add(Me.btnQuitter)
        Me.grpGestion.Controls.Add(Me.Label9)
        Me.grpGestion.Controls.Add(Me.txtSolde)
        Me.grpGestion.Controls.Add(Me.dgvCaisse)
        Me.grpGestion.Controls.Add(Me.Label8)
        Me.grpGestion.Controls.Add(Me.Label6)
        Me.grpGestion.Controls.Add(Me.txtClient)
        Me.grpGestion.Controls.Add(Me.Label7)
        Me.grpGestion.Controls.Add(Me.txtMontant)
        Me.grpGestion.Controls.Add(Me.Label5)
        Me.grpGestion.Controls.Add(Me.txtNumeroQuittancier)
        Me.grpGestion.Controls.Add(Me.Label4)
        Me.grpGestion.Controls.Add(Me.txtRefFacture)
        Me.grpGestion.Controls.Add(Me.Label3)
        Me.grpGestion.Controls.Add(Me.txtDescription)
        Me.grpGestion.Controls.Add(Me.Label2)
        Me.grpGestion.Controls.Add(Me.dtpDate)
        Me.grpGestion.Controls.Add(Me.txtNumOrdre)
        Me.grpGestion.Controls.Add(Me.Label1)
        Me.grpGestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpGestion.Location = New System.Drawing.Point(13, 72)
        Me.grpGestion.Margin = New System.Windows.Forms.Padding(4)
        Me.grpGestion.Name = "grpGestion"
        Me.grpGestion.Padding = New System.Windows.Forms.Padding(4)
        Me.grpGestion.Size = New System.Drawing.Size(866, 442)
        Me.grpGestion.TabIndex = 0
        Me.grpGestion.TabStop = False
        Me.grpGestion.Text = "Gestion de la caisse principale"
        '
        'cboContrepartie
        '
        Me.cboContrepartie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboContrepartie.Location = New System.Drawing.Point(260, 88)
        Me.cboContrepartie.Name = "cboContrepartie"
        Me.cboContrepartie.Size = New System.Drawing.Size(84, 22)
        Me.cboContrepartie.TabIndex = 4
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(636, 70)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 16)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "Memo"
        '
        'txtMemo
        '
        Me.txtMemo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtMemo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtMemo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemo.Location = New System.Drawing.Point(636, 88)
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.Size = New System.Drawing.Size(208, 22)
        Me.txtMemo.TabIndex = 8
        '
        'txtDebitCredit
        '
        Me.txtDebitCredit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtDebitCredit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtDebitCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDebitCredit.Location = New System.Drawing.Point(209, 42)
        Me.txtDebitCredit.Name = "txtDebitCredit"
        Me.txtDebitCredit.Size = New System.Drawing.Size(77, 22)
        Me.txtDebitCredit.TabIndex = 5
        Me.txtDebitCredit.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(75, 402)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 18)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "Total Credit"
        '
        'txtTotalCredit
        '
        Me.txtTotalCredit.BackColor = System.Drawing.Color.White
        Me.txtTotalCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCredit.Location = New System.Drawing.Point(171, 399)
        Me.txtTotalCredit.Name = "txtTotalCredit"
        Me.txtTotalCredit.ReadOnly = True
        Me.txtTotalCredit.Size = New System.Drawing.Size(112, 24)
        Me.txtTotalCredit.TabIndex = 27
        Me.txtTotalCredit.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(289, 402)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 18)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Total Debit"
        '
        'txtTotalDebit
        '
        Me.txtTotalDebit.BackColor = System.Drawing.Color.White
        Me.txtTotalDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDebit.Location = New System.Drawing.Point(381, 399)
        Me.txtTotalDebit.Name = "txtTotalDebit"
        Me.txtTotalDebit.ReadOnly = True
        Me.txtTotalDebit.Size = New System.Drawing.Size(112, 24)
        Me.txtTotalDebit.TabIndex = 25
        Me.txtTotalDebit.TabStop = False
        '
        'txtCpteTresorerie
        '
        Me.txtCpteTresorerie.Enabled = False
        Me.txtCpteTresorerie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCpteTresorerie.Location = New System.Drawing.Point(118, 42)
        Me.txtCpteTresorerie.Name = "txtCpteTresorerie"
        Me.txtCpteTresorerie.Size = New System.Drawing.Size(85, 22)
        Me.txtCpteTresorerie.TabIndex = 24
        Me.txtCpteTresorerie.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(257, 69)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Contrepartie"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(115, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 16)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Tresorerie"
        '
        'btnQuitter
        '
        Me.btnQuitter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitter.Location = New System.Drawing.Point(721, 394)
        Me.btnQuitter.Name = "btnQuitter"
        Me.btnQuitter.Size = New System.Drawing.Size(133, 37)
        Me.btnQuitter.TabIndex = 19
        Me.btnQuitter.TabStop = False
        Me.btnQuitter.Text = "Quitter"
        Me.btnQuitter.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(499, 402)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 20)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Solde"
        '
        'txtSolde
        '
        Me.txtSolde.BackColor = System.Drawing.Color.White
        Me.txtSolde.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSolde.Location = New System.Drawing.Point(560, 399)
        Me.txtSolde.Name = "txtSolde"
        Me.txtSolde.ReadOnly = True
        Me.txtSolde.Size = New System.Drawing.Size(155, 26)
        Me.txtSolde.TabIndex = 17
        Me.txtSolde.TabStop = False
        '
        'dgvCaisse
        '
        Me.dgvCaisse.AllowUserToAddRows = False
        Me.dgvCaisse.AllowUserToDeleteRows = False
        Me.dgvCaisse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCaisse.Location = New System.Drawing.Point(7, 119)
        Me.dgvCaisse.Name = "dgvCaisse"
        Me.dgvCaisse.ReadOnly = True
        Me.dgvCaisse.Size = New System.Drawing.Size(847, 269)
        Me.dgvCaisse.TabIndex = 16
        Me.dgvCaisse.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(206, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Dbt./Crt."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(525, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Percep./Remett."
        '
        'txtClient
        '
        Me.txtClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClient.Location = New System.Drawing.Point(525, 88)
        Me.txtClient.Name = "txtClient"
        Me.txtClient.Size = New System.Drawing.Size(105, 22)
        Me.txtClient.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(350, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Montant"
        '
        'txtMontant
        '
        Me.txtMontant.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtMontant.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtMontant.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontant.Location = New System.Drawing.Point(350, 88)
        Me.txtMontant.Name = "txtMontant"
        Me.txtMontant.Size = New System.Drawing.Size(79, 22)
        Me.txtMontant.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(292, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Quittancier:"
        '
        'txtNumeroQuittancier
        '
        Me.txtNumeroQuittancier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtNumeroQuittancier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtNumeroQuittancier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroQuittancier.Location = New System.Drawing.Point(292, 42)
        Me.txtNumeroQuittancier.Name = "txtNumeroQuittancier"
        Me.txtNumeroQuittancier.Size = New System.Drawing.Size(74, 22)
        Me.txtNumeroQuittancier.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(435, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Ref. Facture:"
        '
        'txtRefFacture
        '
        Me.txtRefFacture.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtRefFacture.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtRefFacture.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefFacture.Location = New System.Drawing.Point(435, 88)
        Me.txtRefFacture.Name = "txtRefFacture"
        Me.txtRefFacture.Size = New System.Drawing.Size(83, 22)
        Me.txtRefFacture.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Libele:"
        '
        'txtDescription
        '
        Me.txtDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(7, 88)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(249, 22)
        Me.txtDescription.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(372, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "No d'ordre:"
        '
        'dtpDate
        '
        Me.dtpDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(7, 42)
        Me.dtpDate.MaxDate = New Date(2035, 12, 31, 0, 0, 0, 0)
        Me.dtpDate.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(105, 22)
        Me.dtpDate.TabIndex = 1
        Me.dtpDate.TabStop = False
        '
        'txtNumOrdre
        '
        Me.txtNumOrdre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumOrdre.Location = New System.Drawing.Point(372, 42)
        Me.txtNumOrdre.Name = "txtNumOrdre"
        Me.txtNumOrdre.Size = New System.Drawing.Size(75, 22)
        Me.txtNumOrdre.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date:"
        '
        'cboSelectOption
        '
        Me.cboSelectOption.FormattingEnabled = True
        Me.cboSelectOption.Items.AddRange(New Object() {"Nouveau Journal de Caisse", "Editer un Journal de Caisse"})
        Me.cboSelectOption.Location = New System.Drawing.Point(13, 34)
        Me.cboSelectOption.Name = "cboSelectOption"
        Me.cboSelectOption.Size = New System.Drawing.Size(183, 24)
        Me.cboSelectOption.TabIndex = 1
        Me.cboSelectOption.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Enabled = False
        Me.Label12.Location = New System.Drawing.Point(10, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 16)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Choix a faire"
        Me.Label12.Visible = False
        '
        'txtNumJournal
        '
        Me.txtNumJournal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumJournal.Location = New System.Drawing.Point(202, 34)
        Me.txtNumJournal.Name = "txtNumJournal"
        Me.txtNumJournal.Size = New System.Drawing.Size(44, 22)
        Me.txtNumJournal.TabIndex = 25
        Me.txtNumJournal.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Enabled = False
        Me.Label13.Location = New System.Drawing.Point(199, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 16)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Jrnl no"
        Me.Label13.Visible = False
        '
        'btnCreerJournal
        '
        Me.btnCreerJournal.Location = New System.Drawing.Point(254, 30)
        Me.btnCreerJournal.Name = "btnCreerJournal"
        Me.btnCreerJournal.Size = New System.Drawing.Size(119, 28)
        Me.btnCreerJournal.TabIndex = 27
        Me.btnCreerJournal.TabStop = False
        Me.btnCreerJournal.Text = "Nouveau Journal"
        Me.btnCreerJournal.UseVisualStyleBackColor = True
        '
        'frmGestionCaissePrincipale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(876, 527)
        Me.Controls.Add(Me.btnCreerJournal)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtNumJournal)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cboSelectOption)
        Me.Controls.Add(Me.grpGestion)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmGestionCaissePrincipale"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Formulaire de la Gestion de la Caisse Principale"
        Me.grpGestion.ResumeLayout(False)
        Me.grpGestion.PerformLayout()
        CType(Me.dgvCaisse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpGestion As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCaisse As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtClient As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMontant As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroQuittancier As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRefFacture As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNumOrdre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSolde As System.Windows.Forms.TextBox
    Friend WithEvents btnQuitter As System.Windows.Forms.Button
    Friend WithEvents txtCpteTresorerie As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboSelectOption As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtNumJournal As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnCreerJournal As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCredit As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDebit As System.Windows.Forms.TextBox
    Friend WithEvents txtDebitCredit As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtMemo As System.Windows.Forms.TextBox
    Friend WithEvents cboContrepartie As System.Windows.Forms.TextBox
End Class
