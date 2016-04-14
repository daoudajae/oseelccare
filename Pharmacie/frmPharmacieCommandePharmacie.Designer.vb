<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPharmacieCommandePharmacie
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpStockActuel = New System.Windows.Forms.GroupBox()
        Me.dgvStockActuel = New System.Windows.Forms.DataGridView()
        Me.grpListeCommande = New System.Windows.Forms.GroupBox()
        Me.dgvEltACommander = New System.Windows.Forms.DataGridView()
        Me.btnValider = New System.Windows.Forms.Button()
        Me.lblOrderer = New System.Windows.Forms.Label()
        Me.grpStockActuel.SuspendLayout()
        CType(Me.dgvStockActuel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpListeCommande.SuspendLayout()
        CType(Me.dgvEltACommander, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpStockActuel
        '
        Me.grpStockActuel.Controls.Add(Me.dgvStockActuel)
        Me.grpStockActuel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpStockActuel.Location = New System.Drawing.Point(10, 64)
        Me.grpStockActuel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpStockActuel.Name = "grpStockActuel"
        Me.grpStockActuel.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpStockActuel.Size = New System.Drawing.Size(581, 398)
        Me.grpStockActuel.TabIndex = 0
        Me.grpStockActuel.TabStop = False
        Me.grpStockActuel.Text = "Stock Disponible au Magasin"
        '
        'dgvStockActuel
        '
        Me.dgvStockActuel.AllowUserToAddRows = False
        Me.dgvStockActuel.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvStockActuel.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvStockActuel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStockActuel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStockActuel.Location = New System.Drawing.Point(3, 21)
        Me.dgvStockActuel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvStockActuel.Name = "dgvStockActuel"
        Me.dgvStockActuel.ReadOnly = True
        Me.dgvStockActuel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStockActuel.Size = New System.Drawing.Size(575, 375)
        Me.dgvStockActuel.TabIndex = 0
        '
        'grpListeCommande
        '
        Me.grpListeCommande.Controls.Add(Me.dgvEltACommander)
        Me.grpListeCommande.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpListeCommande.Location = New System.Drawing.Point(596, 10)
        Me.grpListeCommande.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpListeCommande.Name = "grpListeCommande"
        Me.grpListeCommande.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpListeCommande.Size = New System.Drawing.Size(402, 423)
        Me.grpListeCommande.TabIndex = 1
        Me.grpListeCommande.TabStop = False
        Me.grpListeCommande.Text = "Liste A Commander"
        '
        'dgvEltACommander
        '
        Me.dgvEltACommander.AllowUserToAddRows = False
        Me.dgvEltACommander.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvEltACommander.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvEltACommander.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEltACommander.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEltACommander.Location = New System.Drawing.Point(3, 21)
        Me.dgvEltACommander.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvEltACommander.Name = "dgvEltACommander"
        Me.dgvEltACommander.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEltACommander.Size = New System.Drawing.Size(396, 400)
        Me.dgvEltACommander.TabIndex = 0
        '
        'btnValider
        '
        Me.btnValider.Location = New System.Drawing.Point(807, 438)
        Me.btnValider.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnValider.Name = "btnValider"
        Me.btnValider.Size = New System.Drawing.Size(191, 24)
        Me.btnValider.TabIndex = 2
        Me.btnValider.Text = "Valider Commande"
        Me.btnValider.UseVisualStyleBackColor = True
        '
        'lblOrderer
        '
        Me.lblOrderer.AutoSize = True
        Me.lblOrderer.Location = New System.Drawing.Point(11, 10)
        Me.lblOrderer.Name = "lblOrderer"
        Me.lblOrderer.Size = New System.Drawing.Size(59, 20)
        Me.lblOrderer.TabIndex = 3
        Me.lblOrderer.Text = "Label1"
        '
        'frmPharmacieCommandePharmacie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 471)
        Me.Controls.Add(Me.lblOrderer)
        Me.Controls.Add(Me.btnValider)
        Me.Controls.Add(Me.grpListeCommande)
        Me.Controls.Add(Me.grpStockActuel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPharmacieCommandePharmacie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Commande des produits de la pharmacie"
        Me.grpStockActuel.ResumeLayout(False)
        CType(Me.dgvStockActuel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpListeCommande.ResumeLayout(False)
        CType(Me.dgvEltACommander, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpStockActuel As System.Windows.Forms.GroupBox
    Friend WithEvents dgvStockActuel As System.Windows.Forms.DataGridView
    Friend WithEvents grpListeCommande As System.Windows.Forms.GroupBox
    Friend WithEvents btnValider As System.Windows.Forms.Button
    Friend WithEvents dgvEltACommander As System.Windows.Forms.DataGridView
    Friend WithEvents lblOrderer As System.Windows.Forms.Label
End Class
