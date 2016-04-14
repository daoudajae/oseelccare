<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTableauBoard
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.txtInfos = New System.Windows.Forms.TextBox()
        Me.btnLiberation = New System.Windows.Forms.Button()
        Me.lblId = New System.Windows.Forms.Label()
        Me.btnAssurances = New System.Windows.Forms.Button()
        Me.btnXRayResults = New System.Windows.Forms.Button()
        Me.btnLabResults = New System.Windows.Forms.Button()
        Me.btnRendezVous = New System.Windows.Forms.Button()
        Me.btnParameters = New System.Windows.Forms.Button()
        Me.btnDiagnostic = New System.Windows.Forms.Button()
        Me.btnPrescription = New System.Windows.Forms.Button()
        Me.grpSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(172, 549)
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
        Me.grpSearch.Controls.Add(Me.txtInfos)
        Me.grpSearch.Controls.Add(Me.btnLiberation)
        Me.grpSearch.Controls.Add(Me.lblId)
        Me.grpSearch.Controls.Add(Me.btnAssurances)
        Me.grpSearch.Controls.Add(Me.btnXRayResults)
        Me.grpSearch.Controls.Add(Me.btnLabResults)
        Me.grpSearch.Controls.Add(Me.btnRendezVous)
        Me.grpSearch.Controls.Add(Me.btnParameters)
        Me.grpSearch.Controls.Add(Me.btnDiagnostic)
        Me.grpSearch.Controls.Add(Me.btnPrescription)
        Me.grpSearch.Location = New System.Drawing.Point(12, 12)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(293, 529)
        Me.grpSearch.TabIndex = 33
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Tableau de board"
        '
        'txtInfos
        '
        Me.txtInfos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfos.Location = New System.Drawing.Point(8, 57)
        Me.txtInfos.Multiline = True
        Me.txtInfos.Name = "txtInfos"
        Me.txtInfos.ReadOnly = True
        Me.txtInfos.Size = New System.Drawing.Size(275, 100)
        Me.txtInfos.TabIndex = 26
        '
        'btnLiberation
        '
        Me.btnLiberation.FlatAppearance.BorderSize = 0
        Me.btnLiberation.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnLiberation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnLiberation.Location = New System.Drawing.Point(6, 480)
        Me.btnLiberation.Margin = New System.Windows.Forms.Padding(5)
        Me.btnLiberation.Name = "btnLiberation"
        Me.btnLiberation.Size = New System.Drawing.Size(277, 35)
        Me.btnLiberation.TabIndex = 25
        Me.btnLiberation.Text = "Liberation du patient"
        Me.btnLiberation.UseVisualStyleBackColor = True
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblId.Location = New System.Drawing.Point(6, 23)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(65, 20)
        Me.lblId.TabIndex = 24
        Me.lblId.Text = "Label1"
        '
        'btnAssurances
        '
        Me.btnAssurances.FlatAppearance.BorderSize = 0
        Me.btnAssurances.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnAssurances.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnAssurances.Location = New System.Drawing.Point(5, 210)
        Me.btnAssurances.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAssurances.Name = "btnAssurances"
        Me.btnAssurances.Size = New System.Drawing.Size(277, 35)
        Me.btnAssurances.TabIndex = 23
        Me.btnAssurances.Text = "Assurances"
        Me.btnAssurances.UseVisualStyleBackColor = True
        '
        'btnXRayResults
        '
        Me.btnXRayResults.FlatAppearance.BorderSize = 0
        Me.btnXRayResults.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnXRayResults.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnXRayResults.Location = New System.Drawing.Point(5, 435)
        Me.btnXRayResults.Margin = New System.Windows.Forms.Padding(5)
        Me.btnXRayResults.Name = "btnXRayResults"
        Me.btnXRayResults.Size = New System.Drawing.Size(277, 35)
        Me.btnXRayResults.TabIndex = 22
        Me.btnXRayResults.Text = "Resultats Imagerie"
        Me.btnXRayResults.UseVisualStyleBackColor = True
        '
        'btnLabResults
        '
        Me.btnLabResults.FlatAppearance.BorderSize = 0
        Me.btnLabResults.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnLabResults.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnLabResults.Location = New System.Drawing.Point(5, 390)
        Me.btnLabResults.Margin = New System.Windows.Forms.Padding(5)
        Me.btnLabResults.Name = "btnLabResults"
        Me.btnLabResults.Size = New System.Drawing.Size(277, 35)
        Me.btnLabResults.TabIndex = 21
        Me.btnLabResults.Text = "Resultats Laboratoire"
        Me.btnLabResults.UseVisualStyleBackColor = True
        '
        'btnRendezVous
        '
        Me.btnRendezVous.FlatAppearance.BorderSize = 0
        Me.btnRendezVous.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnRendezVous.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnRendezVous.Location = New System.Drawing.Point(5, 255)
        Me.btnRendezVous.Margin = New System.Windows.Forms.Padding(5)
        Me.btnRendezVous.Name = "btnRendezVous"
        Me.btnRendezVous.Size = New System.Drawing.Size(277, 35)
        Me.btnRendezVous.TabIndex = 20
        Me.btnRendezVous.Text = "Rendez-vous"
        Me.btnRendezVous.UseVisualStyleBackColor = True
        '
        'btnParameters
        '
        Me.btnParameters.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnParameters.FlatAppearance.BorderSize = 0
        Me.btnParameters.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnParameters.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnParameters.Location = New System.Drawing.Point(6, 165)
        Me.btnParameters.Margin = New System.Windows.Forms.Padding(5)
        Me.btnParameters.Name = "btnParameters"
        Me.btnParameters.Size = New System.Drawing.Size(277, 35)
        Me.btnParameters.TabIndex = 18
        Me.btnParameters.Text = "Parametres"
        Me.btnParameters.UseVisualStyleBackColor = True
        '
        'btnDiagnostic
        '
        Me.btnDiagnostic.FlatAppearance.BorderSize = 0
        Me.btnDiagnostic.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnDiagnostic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnDiagnostic.Location = New System.Drawing.Point(5, 300)
        Me.btnDiagnostic.Margin = New System.Windows.Forms.Padding(5)
        Me.btnDiagnostic.Name = "btnDiagnostic"
        Me.btnDiagnostic.Size = New System.Drawing.Size(277, 35)
        Me.btnDiagnostic.TabIndex = 17
        Me.btnDiagnostic.Text = "Diagnostiques"
        Me.btnDiagnostic.UseVisualStyleBackColor = True
        '
        'btnPrescription
        '
        Me.btnPrescription.FlatAppearance.BorderSize = 0
        Me.btnPrescription.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnPrescription.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnPrescription.Location = New System.Drawing.Point(5, 345)
        Me.btnPrescription.Margin = New System.Windows.Forms.Padding(5)
        Me.btnPrescription.Name = "btnPrescription"
        Me.btnPrescription.Size = New System.Drawing.Size(277, 35)
        Me.btnPrescription.TabIndex = 16
        Me.btnPrescription.Text = "Prescriptions"
        Me.btnPrescription.UseVisualStyleBackColor = True
        '
        'frmTableauBoard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(316, 597)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.btnClose)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTableauBoard"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrescription As System.Windows.Forms.Button
    Friend WithEvents btnAssurances As System.Windows.Forms.Button
    Friend WithEvents btnXRayResults As System.Windows.Forms.Button
    Friend WithEvents btnLabResults As System.Windows.Forms.Button
    Friend WithEvents btnRendezVous As System.Windows.Forms.Button
    Friend WithEvents btnParameters As System.Windows.Forms.Button
    Friend WithEvents btnDiagnostic As System.Windows.Forms.Button
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents btnLiberation As System.Windows.Forms.Button
    Friend WithEvents txtInfos As System.Windows.Forms.TextBox
End Class
