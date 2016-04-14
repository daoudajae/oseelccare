<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiberationPatient
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.radDeces = New System.Windows.Forms.RadioButton()
        Me.radEvacuation = New System.Windows.Forms.RadioButton()
        Me.radEvader = New System.Windows.Forms.RadioButton()
        Me.radSansAvis = New System.Windows.Forms.RadioButton()
        Me.radNormal = New System.Windows.Forms.RadioButton()
        Me.txtInfos = New System.Windows.Forms.TextBox()
        Me.lblId = New System.Windows.Forms.Label()
        Me.chkAccord = New System.Windows.Forms.CheckBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.btnLiberer = New System.Windows.Forms.Button()
        Me.dgvDiagnostiques = New System.Windows.Forms.DataGridView()
        Me.dtpDeath = New System.Windows.Forms.DateTimePicker()
        Me.grpSearch.SuspendLayout()
        CType(Me.dgvDiagnostiques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(501, 471)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(122, 35)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Quitter"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grpSearch
        '
        Me.grpSearch.BackColor = System.Drawing.Color.Transparent
        Me.grpSearch.Controls.Add(Me.dtpDeath)
        Me.grpSearch.Controls.Add(Me.txtId)
        Me.grpSearch.Controls.Add(Me.radDeces)
        Me.grpSearch.Controls.Add(Me.radEvacuation)
        Me.grpSearch.Controls.Add(Me.radEvader)
        Me.grpSearch.Controls.Add(Me.radSansAvis)
        Me.grpSearch.Controls.Add(Me.radNormal)
        Me.grpSearch.Controls.Add(Me.txtInfos)
        Me.grpSearch.Controls.Add(Me.lblId)
        Me.grpSearch.Location = New System.Drawing.Point(12, 12)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(613, 259)
        Me.grpSearch.TabIndex = 33
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Liberation Patient"
        '
        'txtId
        '
        Me.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtId.Location = New System.Drawing.Point(88, 24)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(206, 20)
        Me.txtId.TabIndex = 32
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'radDeces
        '
        Me.radDeces.AutoSize = True
        Me.radDeces.Location = New System.Drawing.Point(331, 193)
        Me.radDeces.Name = "radDeces"
        Me.radDeces.Size = New System.Drawing.Size(79, 24)
        Me.radDeces.TabIndex = 31
        Me.radDeces.TabStop = True
        Me.radDeces.Text = "Deces"
        Me.radDeces.UseVisualStyleBackColor = True
        '
        'radEvacuation
        '
        Me.radEvacuation.AutoSize = True
        Me.radEvacuation.Location = New System.Drawing.Point(331, 163)
        Me.radEvacuation.Name = "radEvacuation"
        Me.radEvacuation.Size = New System.Drawing.Size(112, 24)
        Me.radEvacuation.TabIndex = 30
        Me.radEvacuation.TabStop = True
        Me.radEvacuation.Text = "Evacuation"
        Me.radEvacuation.UseVisualStyleBackColor = True
        '
        'radEvader
        '
        Me.radEvader.AutoSize = True
        Me.radEvader.Location = New System.Drawing.Point(6, 223)
        Me.radEvader.Name = "radEvader"
        Me.radEvader.Size = New System.Drawing.Size(82, 24)
        Me.radEvader.TabIndex = 29
        Me.radEvader.TabStop = True
        Me.radEvader.Text = "Evader"
        Me.radEvader.UseVisualStyleBackColor = True
        '
        'radSansAvis
        '
        Me.radSansAvis.AutoSize = True
        Me.radSansAvis.Location = New System.Drawing.Point(6, 193)
        Me.radSansAvis.Name = "radSansAvis"
        Me.radSansAvis.Size = New System.Drawing.Size(275, 24)
        Me.radSansAvis.TabIndex = 28
        Me.radSansAvis.TabStop = True
        Me.radSansAvis.Text = "Liberation Sans Avis du Medecin"
        Me.radSansAvis.UseVisualStyleBackColor = True
        '
        'radNormal
        '
        Me.radNormal.AutoSize = True
        Me.radNormal.Location = New System.Drawing.Point(6, 163)
        Me.radNormal.Name = "radNormal"
        Me.radNormal.Size = New System.Drawing.Size(172, 24)
        Me.radNormal.TabIndex = 27
        Me.radNormal.TabStop = True
        Me.radNormal.Text = "Liberation Normale"
        Me.radNormal.UseVisualStyleBackColor = True
        '
        'txtInfos
        '
        Me.txtInfos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfos.Location = New System.Drawing.Point(6, 57)
        Me.txtInfos.Multiline = True
        Me.txtInfos.Name = "txtInfos"
        Me.txtInfos.ReadOnly = True
        Me.txtInfos.Size = New System.Drawing.Size(601, 100)
        Me.txtInfos.TabIndex = 26
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.Location = New System.Drawing.Point(6, 23)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(74, 20)
        Me.lblId.TabIndex = 24
        Me.lblId.Text = "Numero"
        '
        'chkAccord
        '
        Me.chkAccord.AutoSize = True
        Me.chkAccord.Location = New System.Drawing.Point(343, 277)
        Me.chkAccord.Name = "chkAccord"
        Me.chkAccord.Size = New System.Drawing.Size(242, 24)
        Me.chkAccord.TabIndex = 34
        Me.chkAccord.Text = "Confirmer Accord Liberation"
        Me.chkAccord.UseVisualStyleBackColor = True
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(339, 304)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(85, 20)
        Me.lblUser.TabIndex = 35
        Me.lblUser.Text = "Utilisateur"
        '
        'btnLiberer
        '
        Me.btnLiberer.Enabled = False
        Me.btnLiberer.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLiberer.Location = New System.Drawing.Point(325, 471)
        Me.btnLiberer.Margin = New System.Windows.Forms.Padding(5)
        Me.btnLiberer.Name = "btnLiberer"
        Me.btnLiberer.Size = New System.Drawing.Size(166, 35)
        Me.btnLiberer.TabIndex = 36
        Me.btnLiberer.Text = "Liberer"
        Me.btnLiberer.UseVisualStyleBackColor = True
        '
        'dgvDiagnostiques
        '
        Me.dgvDiagnostiques.AllowUserToAddRows = False
        Me.dgvDiagnostiques.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        Me.dgvDiagnostiques.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDiagnostiques.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDiagnostiques.BackgroundColor = System.Drawing.Color.White
        Me.dgvDiagnostiques.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvDiagnostiques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDiagnostiques.Location = New System.Drawing.Point(12, 327)
        Me.dgvDiagnostiques.Name = "dgvDiagnostiques"
        Me.dgvDiagnostiques.ReadOnly = True
        Me.dgvDiagnostiques.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.dgvDiagnostiques.RowTemplate.Height = 24
        Me.dgvDiagnostiques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDiagnostiques.Size = New System.Drawing.Size(611, 136)
        Me.dgvDiagnostiques.TabIndex = 40
        '
        'dtpDeath
        '
        Me.dtpDeath.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDeath.Location = New System.Drawing.Point(331, 220)
        Me.dtpDeath.MinDate = New Date(2015, 1, 1, 0, 0, 0, 0)
        Me.dtpDeath.Name = "dtpDeath"
        Me.dtpDeath.Size = New System.Drawing.Size(128, 27)
        Me.dtpDeath.TabIndex = 33
        Me.dtpDeath.Visible = False
        '
        'frmLiberationPatient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(637, 520)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvDiagnostiques)
        Me.Controls.Add(Me.btnLiberer)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.chkAccord)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.btnClose)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLiberationPatient"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Liberation Patient"
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        CType(Me.dgvDiagnostiques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents txtInfos As System.Windows.Forms.TextBox
    Friend WithEvents radDeces As System.Windows.Forms.RadioButton
    Friend WithEvents radEvacuation As System.Windows.Forms.RadioButton
    Friend WithEvents radEvader As System.Windows.Forms.RadioButton
    Friend WithEvents radSansAvis As System.Windows.Forms.RadioButton
    Friend WithEvents radNormal As System.Windows.Forms.RadioButton
    Friend WithEvents chkAccord As System.Windows.Forms.CheckBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents btnLiberer As System.Windows.Forms.Button
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents dgvDiagnostiques As System.Windows.Forms.DataGridView
    Friend WithEvents dtpDeath As System.Windows.Forms.DateTimePicker
End Class
