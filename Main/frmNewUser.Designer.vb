<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewUser))
        Me.txtNoms = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.btnNewUser = New System.Windows.Forms.Button()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.txtConfirm = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboAcces = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkEditer = New System.Windows.Forms.CheckBox()
        Me.cboUtilisateur = New System.Windows.Forms.ComboBox()
        Me.cboId = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtNoms
        '
        Me.txtNoms.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoms.Location = New System.Drawing.Point(177, 17)
        Me.txtNoms.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNoms.Name = "txtNoms"
        Me.txtNoms.Size = New System.Drawing.Size(302, 28)
        Me.txtNoms.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Noms et Prenoms"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 54)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nom d'Utilisateur"
        '
        'txtUser
        '
        Me.txtUser.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUser.Location = New System.Drawing.Point(177, 51)
        Me.txtUser.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(302, 28)
        Me.txtUser.TabIndex = 2
        '
        'btnNewUser
        '
        Me.btnNewUser.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewUser.Location = New System.Drawing.Point(177, 192)
        Me.btnNewUser.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNewUser.Name = "btnNewUser"
        Me.btnNewUser.Size = New System.Drawing.Size(188, 30)
        Me.btnNewUser.TabIndex = 6
        Me.btnNewUser.Text = "Creer Utilisateur"
        Me.btnNewUser.UseVisualStyleBackColor = True
        '
        'btnQuit
        '
        Me.btnQuit.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuit.Location = New System.Drawing.Point(373, 192)
        Me.btnQuit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(106, 30)
        Me.btnQuit.TabIndex = 7
        Me.btnQuit.Text = "Quitter"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'txtConfirm
        '
        Me.txtConfirm.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirm.Location = New System.Drawing.Point(177, 121)
        Me.txtConfirm.Margin = New System.Windows.Forms.Padding(4)
        Me.txtConfirm.Name = "txtConfirm"
        Me.txtConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirm.Size = New System.Drawing.Size(302, 28)
        Me.txtConfirm.TabIndex = 4
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(177, 87)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(302, 28)
        Me.txtPassword.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(76, 124)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 23)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Confirmer"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(46, 90)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 23)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Mot de passe"
        '
        'cboAcces
        '
        Me.cboAcces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAcces.FormattingEnabled = True
        Me.cboAcces.Items.AddRange(New Object() {"admin", "caisse", "caissep", "economat", "enregistrement", "facturation", "magasin", "pharmacie1", "pharmacie2", "pharmacie3", "pharmacie4", "recouvrement", "statistiques"})
        Me.cboAcces.Location = New System.Drawing.Point(177, 156)
        Me.cboAcces.Name = "cboAcces"
        Me.cboAcces.Size = New System.Drawing.Size(302, 29)
        Me.cboAcces.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(35, 159)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 23)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Niveau d'acces"
        '
        'chkEditer
        '
        Me.chkEditer.AutoSize = True
        Me.chkEditer.Location = New System.Drawing.Point(30, 231)
        Me.chkEditer.Name = "chkEditer"
        Me.chkEditer.Size = New System.Drawing.Size(143, 27)
        Me.chkEditer.TabIndex = 13
        Me.chkEditer.Text = "Mode Edition"
        Me.chkEditer.UseVisualStyleBackColor = True
        '
        'cboUtilisateur
        '
        Me.cboUtilisateur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUtilisateur.Enabled = False
        Me.cboUtilisateur.FormattingEnabled = True
        Me.cboUtilisateur.Location = New System.Drawing.Point(179, 230)
        Me.cboUtilisateur.Name = "cboUtilisateur"
        Me.cboUtilisateur.Size = New System.Drawing.Size(299, 29)
        Me.cboUtilisateur.TabIndex = 14
        '
        'cboId
        '
        Me.cboId.Enabled = False
        Me.cboId.FormattingEnabled = True
        Me.cboId.Location = New System.Drawing.Point(108, 196)
        Me.cboId.Name = "cboId"
        Me.cboId.Size = New System.Drawing.Size(50, 29)
        Me.cboId.TabIndex = 15
        Me.cboId.Visible = False
        '
        'frmNewUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 276)
        Me.ControlBox = False
        Me.Controls.Add(Me.cboId)
        Me.Controls.Add(Me.cboUtilisateur)
        Me.Controls.Add(Me.chkEditer)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboAcces)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtConfirm)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnNewUser)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNoms)
        Me.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nouvel Utilisateur"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNoms As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents btnNewUser As System.Windows.Forms.Button
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents txtConfirm As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboAcces As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkEditer As System.Windows.Forms.CheckBox
    Friend WithEvents cboUtilisateur As System.Windows.Forms.ComboBox
    Friend WithEvents cboId As System.Windows.Forms.ComboBox

End Class
