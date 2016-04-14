<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewProduit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewProduit))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProduit = New System.Windows.Forms.TextBox()
        Me.btnNewProduit = New System.Windows.Forms.Button()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.txtPrix = New System.Windows.Forms.TextBox()
        Me.Prix = New System.Windows.Forms.Label()
        Me.cboTypeProduit = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkEditer = New System.Windows.Forms.CheckBox()
        Me.cboProduit = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkARV = New System.Windows.Forms.CheckBox()
        Me.chkAutre = New System.Windows.Forms.CheckBox()
        Me.chkAdulte = New System.Windows.Forms.CheckBox()
        Me.chkPediatrie = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboId = New System.Windows.Forms.ComboBox()
        Me.cboCategorie = New System.Windows.Forms.ComboBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(376, 39)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Catgorie"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 75)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Produit"
        '
        'txtProduit
        '
        Me.txtProduit.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProduit.Location = New System.Drawing.Point(84, 72)
        Me.txtProduit.Margin = New System.Windows.Forms.Padding(4)
        Me.txtProduit.Name = "txtProduit"
        Me.txtProduit.Size = New System.Drawing.Size(508, 28)
        Me.txtProduit.TabIndex = 2
        '
        'btnNewProduit
        '
        Me.btnNewProduit.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewProduit.Location = New System.Drawing.Point(477, 225)
        Me.btnNewProduit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNewProduit.Name = "btnNewProduit"
        Me.btnNewProduit.Size = New System.Drawing.Size(150, 34)
        Me.btnNewProduit.TabIndex = 6
        Me.btnNewProduit.Text = "Ajouter Produit"
        Me.btnNewProduit.UseVisualStyleBackColor = True
        '
        'btnQuit
        '
        Me.btnQuit.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuit.Location = New System.Drawing.Point(635, 225)
        Me.btnQuit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(106, 34)
        Me.btnQuit.TabIndex = 7
        Me.btnQuit.Text = "Quitter"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'txtPrix
        '
        Me.txtPrix.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrix.Location = New System.Drawing.Point(84, 108)
        Me.txtPrix.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPrix.Name = "txtPrix"
        Me.txtPrix.Size = New System.Drawing.Size(186, 28)
        Me.txtPrix.TabIndex = 3
        '
        'Prix
        '
        Me.Prix.AutoSize = True
        Me.Prix.BackColor = System.Drawing.Color.Transparent
        Me.Prix.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Prix.Location = New System.Drawing.Point(36, 111)
        Me.Prix.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Prix.Name = "Prix"
        Me.Prix.Size = New System.Drawing.Size(40, 23)
        Me.Prix.TabIndex = 9
        Me.Prix.Text = "Prix"
        '
        'cboTypeProduit
        '
        Me.cboTypeProduit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTypeProduit.FormattingEnabled = True
        Me.cboTypeProduit.Location = New System.Drawing.Point(84, 36)
        Me.cboTypeProduit.Name = "cboTypeProduit"
        Me.cboTypeProduit.Size = New System.Drawing.Size(285, 29)
        Me.cboTypeProduit.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 39)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 23)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Type"
        '
        'chkEditer
        '
        Me.chkEditer.AutoSize = True
        Me.chkEditer.Location = New System.Drawing.Point(149, 190)
        Me.chkEditer.Name = "chkEditer"
        Me.chkEditer.Size = New System.Drawing.Size(143, 27)
        Me.chkEditer.TabIndex = 13
        Me.chkEditer.Text = "Mode Edition"
        Me.chkEditer.UseVisualStyleBackColor = True
        '
        'cboProduit
        '
        Me.cboProduit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProduit.Enabled = False
        Me.cboProduit.FormattingEnabled = True
        Me.cboProduit.Location = New System.Drawing.Point(298, 189)
        Me.cboProduit.Name = "cboProduit"
        Me.cboProduit.Size = New System.Drawing.Size(443, 29)
        Me.cboProduit.TabIndex = 14
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkARV)
        Me.GroupBox1.Controls.Add(Me.chkAutre)
        Me.GroupBox1.Controls.Add(Me.chkAdulte)
        Me.GroupBox1.Controls.Add(Me.chkPediatrie)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(131, 159)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Options"
        '
        'chkARV
        '
        Me.chkARV.AutoSize = True
        Me.chkARV.Location = New System.Drawing.Point(6, 126)
        Me.chkARV.Name = "chkARV"
        Me.chkARV.Size = New System.Drawing.Size(67, 27)
        Me.chkARV.TabIndex = 3
        Me.chkARV.Text = "ARV"
        Me.chkARV.UseVisualStyleBackColor = True
        '
        'chkAutre
        '
        Me.chkAutre.AutoSize = True
        Me.chkAutre.Location = New System.Drawing.Point(6, 93)
        Me.chkAutre.Name = "chkAutre"
        Me.chkAutre.Size = New System.Drawing.Size(76, 27)
        Me.chkAutre.TabIndex = 2
        Me.chkAutre.Text = "Autre"
        Me.chkAutre.UseVisualStyleBackColor = True
        '
        'chkAdulte
        '
        Me.chkAdulte.AutoSize = True
        Me.chkAdulte.Location = New System.Drawing.Point(6, 60)
        Me.chkAdulte.Name = "chkAdulte"
        Me.chkAdulte.Size = New System.Drawing.Size(86, 27)
        Me.chkAdulte.TabIndex = 1
        Me.chkAdulte.Text = "Adulte"
        Me.chkAdulte.UseVisualStyleBackColor = True
        '
        'chkPediatrie
        '
        Me.chkPediatrie.AutoSize = True
        Me.chkPediatrie.Location = New System.Drawing.Point(6, 27)
        Me.chkPediatrie.Name = "chkPediatrie"
        Me.chkPediatrie.Size = New System.Drawing.Size(104, 27)
        Me.chkPediatrie.TabIndex = 0
        Me.chkPediatrie.Text = "Pediatrie"
        Me.chkPediatrie.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboCategorie)
        Me.GroupBox2.Controls.Add(Me.cboTypeProduit)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Prix)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtProduit)
        Me.GroupBox2.Controls.Add(Me.txtPrix)
        Me.GroupBox2.Location = New System.Drawing.Point(149, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(600, 159)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Informations sur le Produit"
        '
        'cboId
        '
        Me.cboId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboId.FormattingEnabled = True
        Me.cboId.Location = New System.Drawing.Point(179, 225)
        Me.cboId.Name = "cboId"
        Me.cboId.Size = New System.Drawing.Size(68, 29)
        Me.cboId.TabIndex = 13
        Me.cboId.Visible = False
        '
        'cboCategorie
        '
        Me.cboCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboCategorie.Enabled = False
        Me.cboCategorie.FormattingEnabled = True
        Me.cboCategorie.Location = New System.Drawing.Point(462, 36)
        Me.cboCategorie.Name = "cboCategorie"
        Me.cboCategorie.Size = New System.Drawing.Size(130, 29)
        Me.cboCategorie.TabIndex = 18
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(319, 225)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(150, 34)
        Me.btnDelete.TabIndex = 18
        Me.btnDelete.Text = "Supprimer"
        Me.btnDelete.UseVisualStyleBackColor = True
        Me.btnDelete.Visible = False
        '
        'frmNewProduit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 269)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.cboId)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cboProduit)
        Me.Controls.Add(Me.chkEditer)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnNewProduit)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewProduit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nouveau Produit"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProduit As System.Windows.Forms.TextBox
    Friend WithEvents btnNewProduit As System.Windows.Forms.Button
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents txtPrix As System.Windows.Forms.TextBox
    Friend WithEvents Prix As System.Windows.Forms.Label
    Friend WithEvents cboTypeProduit As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkEditer As System.Windows.Forms.CheckBox
    Friend WithEvents cboProduit As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkARV As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutre As System.Windows.Forms.CheckBox
    Friend WithEvents chkAdulte As System.Windows.Forms.CheckBox
    Friend WithEvents chkPediatrie As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboId As System.Windows.Forms.ComboBox
    Friend WithEvents cboCategorie As System.Windows.Forms.ComboBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button

End Class
