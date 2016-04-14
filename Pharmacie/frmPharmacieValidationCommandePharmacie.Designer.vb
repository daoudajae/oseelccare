<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPharmacieValidationCommandePharmacie
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
        Me.grpQteCommande = New System.Windows.Forms.GroupBox()
        Me.dgvQteACommander = New System.Windows.Forms.DataGridView()
        Me.btnValiderCommande = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cboPlace = New System.Windows.Forms.ComboBox()
        Me.lblPlace = New System.Windows.Forms.Label()
        Me.txtResponsable = New System.Windows.Forms.TextBox()
        Me.lblResponsable = New System.Windows.Forms.Label()
        Me.grpQteCommande.SuspendLayout()
        CType(Me.dgvQteACommander, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpQteCommande
        '
        Me.grpQteCommande.Controls.Add(Me.dgvQteACommander)
        Me.grpQteCommande.Location = New System.Drawing.Point(12, 99)
        Me.grpQteCommande.Name = "grpQteCommande"
        Me.grpQteCommande.Size = New System.Drawing.Size(452, 430)
        Me.grpQteCommande.TabIndex = 0
        Me.grpQteCommande.TabStop = False
        Me.grpQteCommande.Text = "Mettre les quantite a Commander"
        '
        'dgvQteACommander
        '
        Me.dgvQteACommander.AllowUserToAddRows = False
        Me.dgvQteACommander.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvQteACommander.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvQteACommander.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQteACommander.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvQteACommander.Location = New System.Drawing.Point(3, 26)
        Me.dgvQteACommander.MultiSelect = False
        Me.dgvQteACommander.Name = "dgvQteACommander"
        Me.dgvQteACommander.ReadOnly = True
        Me.dgvQteACommander.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvQteACommander.Size = New System.Drawing.Size(446, 401)
        Me.dgvQteACommander.TabIndex = 0
        '
        'btnValiderCommande
        '
        Me.btnValiderCommande.Location = New System.Drawing.Point(299, 535)
        Me.btnValiderCommande.Name = "btnValiderCommande"
        Me.btnValiderCommande.Size = New System.Drawing.Size(165, 33)
        Me.btnValiderCommande.TabIndex = 1
        Me.btnValiderCommande.Text = "Valider Commande"
        Me.btnValiderCommande.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.ForeColor = System.Drawing.Color.Red
        Me.btnCancel.Location = New System.Drawing.Point(202, 535)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 33)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Annuler"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cboPlace
        '
        Me.cboPlace.FormattingEnabled = True
        Me.cboPlace.Location = New System.Drawing.Point(12, 37)
        Me.cboPlace.Name = "cboPlace"
        Me.cboPlace.Size = New System.Drawing.Size(182, 33)
        Me.cboPlace.TabIndex = 3
        '
        'lblPlace
        '
        Me.lblPlace.AutoSize = True
        Me.lblPlace.Location = New System.Drawing.Point(8, 9)
        Me.lblPlace.Name = "lblPlace"
        Me.lblPlace.Size = New System.Drawing.Size(156, 25)
        Me.lblPlace.TabIndex = 4
        Me.lblPlace.Text = "Lieu Commande"
        '
        'txtResponsable
        '
        Me.txtResponsable.Enabled = False
        Me.txtResponsable.Location = New System.Drawing.Point(200, 32)
        Me.txtResponsable.Multiline = True
        Me.txtResponsable.Name = "txtResponsable"
        Me.txtResponsable.ReadOnly = True
        Me.txtResponsable.Size = New System.Drawing.Size(264, 61)
        Me.txtResponsable.TabIndex = 5
        '
        'lblResponsable
        '
        Me.lblResponsable.AutoSize = True
        Me.lblResponsable.Location = New System.Drawing.Point(250, 9)
        Me.lblResponsable.Name = "lblResponsable"
        Me.lblResponsable.Size = New System.Drawing.Size(193, 25)
        Me.lblResponsable.TabIndex = 6
        Me.lblResponsable.Text = "Responsable et Date"
        '
        'frmPharmacieValidationCommandePharmacie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 580)
        Me.Controls.Add(Me.lblResponsable)
        Me.Controls.Add(Me.txtResponsable)
        Me.Controls.Add(Me.lblPlace)
        Me.Controls.Add(Me.cboPlace)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnValiderCommande)
        Me.Controls.Add(Me.grpQteCommande)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPharmacieValidationCommandePharmacie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quantite A Commander"
        Me.grpQteCommande.ResumeLayout(False)
        CType(Me.dgvQteACommander, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpQteCommande As System.Windows.Forms.GroupBox
    Friend WithEvents dgvQteACommander As System.Windows.Forms.DataGridView
    Friend WithEvents btnValiderCommande As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cboPlace As System.Windows.Forms.ComboBox
    Friend WithEvents lblPlace As System.Windows.Forms.Label
    Friend WithEvents txtResponsable As System.Windows.Forms.TextBox
    Friend WithEvents lblResponsable As System.Windows.Forms.Label
End Class
