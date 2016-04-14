<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPharmacieRavitaillementMagasin
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpListeCommande = New System.Windows.Forms.GroupBox()
        Me.dgvEltACommander = New System.Windows.Forms.DataGridView()
        Me.btnValider = New System.Windows.Forms.Button()
        Me.grpStockActuel = New System.Windows.Forms.GroupBox()
        Me.dgvStockActuel = New System.Windows.Forms.DataGridView()
        Me.cboListe = New System.Windows.Forms.ComboBox()
        Me.grpListeCommande.SuspendLayout()
        CType(Me.dgvEltACommander, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStockActuel.SuspendLayout()
        CType(Me.dgvStockActuel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpListeCommande
        '
        Me.grpListeCommande.Controls.Add(Me.dgvEltACommander)
        Me.grpListeCommande.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpListeCommande.Location = New System.Drawing.Point(473, 15)
        Me.grpListeCommande.Name = "grpListeCommande"
        Me.grpListeCommande.Size = New System.Drawing.Size(501, 452)
        Me.grpListeCommande.TabIndex = 1
        Me.grpListeCommande.TabStop = False
        Me.grpListeCommande.Text = "Liste A Ravitailler"
        '
        'dgvEltACommander
        '
        Me.dgvEltACommander.AllowUserToAddRows = False
        Me.dgvEltACommander.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvEltACommander.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvEltACommander.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEltACommander.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEltACommander.Location = New System.Drawing.Point(3, 22)
        Me.dgvEltACommander.Name = "dgvEltACommander"
        Me.dgvEltACommander.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEltACommander.Size = New System.Drawing.Size(495, 427)
        Me.dgvEltACommander.TabIndex = 0
        '
        'btnValider
        '
        Me.btnValider.Location = New System.Drawing.Point(764, 473)
        Me.btnValider.Name = "btnValider"
        Me.btnValider.Size = New System.Drawing.Size(210, 38)
        Me.btnValider.TabIndex = 2
        Me.btnValider.Text = "Valider Commande"
        Me.btnValider.UseVisualStyleBackColor = True
        '
        'grpStockActuel
        '
        Me.grpStockActuel.Controls.Add(Me.dgvStockActuel)
        Me.grpStockActuel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpStockActuel.Location = New System.Drawing.Point(11, 51)
        Me.grpStockActuel.Name = "grpStockActuel"
        Me.grpStockActuel.Size = New System.Drawing.Size(456, 413)
        Me.grpStockActuel.TabIndex = 0
        Me.grpStockActuel.TabStop = False
        Me.grpStockActuel.Text = "Stock Dans Le Magasin"
        '
        'dgvStockActuel
        '
        Me.dgvStockActuel.AllowUserToAddRows = False
        Me.dgvStockActuel.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.dgvStockActuel.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvStockActuel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStockActuel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStockActuel.Location = New System.Drawing.Point(3, 22)
        Me.dgvStockActuel.Name = "dgvStockActuel"
        Me.dgvStockActuel.ReadOnly = True
        Me.dgvStockActuel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStockActuel.Size = New System.Drawing.Size(450, 388)
        Me.dgvStockActuel.TabIndex = 0
        '
        'cboListe
        '
        Me.cboListe.FormattingEnabled = True
        Me.cboListe.Location = New System.Drawing.Point(14, 12)
        Me.cboListe.Name = "cboListe"
        Me.cboListe.Size = New System.Drawing.Size(326, 33)
        Me.cboListe.TabIndex = 4
        '
        'frmPharmacieRavitaillementMagasin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 525)
        Me.Controls.Add(Me.cboListe)
        Me.Controls.Add(Me.btnValider)
        Me.Controls.Add(Me.grpListeCommande)
        Me.Controls.Add(Me.grpStockActuel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPharmacieRavitaillementMagasin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Commande des produits de la pharmacie"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpListeCommande.ResumeLayout(False)
        CType(Me.dgvEltACommander, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStockActuel.ResumeLayout(False)
        CType(Me.dgvStockActuel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpListeCommande As System.Windows.Forms.GroupBox
    Friend WithEvents btnValider As System.Windows.Forms.Button
    Friend WithEvents dgvEltACommander As System.Windows.Forms.DataGridView
    Friend WithEvents grpStockActuel As System.Windows.Forms.GroupBox
    Friend WithEvents dgvStockActuel As System.Windows.Forms.DataGridView
    Friend WithEvents cboListe As System.Windows.Forms.ComboBox
End Class
