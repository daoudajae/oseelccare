Module Functions
    Public Function NotEmpty(ByVal Text As String) As Boolean
        Return Not String.IsNullOrEmpty(Text)
    End Function
    'Faire une requette avec un parametre
    Public Sub Search(ByVal Name As String, ByVal Query As String, ByRef DBClass As MySQLDataBaseAccess, ByVal dgvView As DataGridView)
        DBClass.AddParams("@user", "%" & Name & "%")
        DBClass.ExecQuery(Query & " LIKE @user")

        'Verifier s'il ya une erreur
        If NotEmpty(DBClass.Exception) Then MsgBox(DBClass.Exception) : Exit Sub

        'Remplir le resultat dans le datagridview
        dgvView.DataSource = DBClass.DBDataTable
    End Sub

    Public Function ItemExist(ByVal Item As Object, ByVal DB As MySQLDataBaseAccess, ByVal Field As String, ByVal Table As String) As Boolean
        Dim Qry As String
        DB.AddParams("@item", Item)
        DB.AddParams("@field", Field)
        DB.AddParams("@table", Table)

        Qry = "SELECT @field FROM @table WHERE @field=@item"
        DB.ExecQuery(Qry)

        If DB.RecordCount > 0 Then Return True Else Return False
    End Function
    'Subd to refrersh the grid
    Public Sub RefreshGrid(ByVal DB As MySQLDataBaseAccess, ByVal dgView As DataGridView, ByVal Query As String)
        DB.ExecQuery(Query)
        If NotEmpty(DB.Exception) Then MsgBox(DB.Exception) : Exit Sub

        dgView.DataSource = DB.DBDataTable
        'dgView.Columns("ID").Visible = False

     End Sub

    'Sub to Fill two combobox
    Public Sub Fillcbos(ByVal DB As MySQLDataBaseAccess, ByVal cboNames As ComboBox, ByVal cboIds As ComboBox, ByVal Qry As String)
        DB.ExecQuery(Qry)
        If NotEmpty(DB.Exception) Then MsgBox(DB.Exception) : Exit Sub
        'Remplir le combo metiers
        For Each r As DataRow In DB.DBDataTable.Rows
            cboNames.Items.Add(r(0))
            cboIds.Items.Add(r(1))
        Next
    End Sub

    Public Sub Fillcbo(ByVal DB As MySQLDataBaseAccess, ByVal cboNames As ComboBox, ByVal Qry As String)
        DB.ExecQuery(Qry)
        If NotEmpty(DB.Exception) Then MsgBox(DB.Exception) : Exit Sub
        'Remplir le combo metiers
        For Each r As DataRow In DB.DBDataTable.Rows
            cboNames.Items.Add(r(0))

        Next
    End Sub

    '***********************************************************************************************************
    '*
    '*      Desc: Module pour l'export des donnees dans un fichier excel.
    '*
    '*      Variables:
    '*          dgv: est le datagridview qui contient les donnees 
    '*
    '*      Resultat attendu:
    '*          Un fichier excel est creer et enregistrer sous le nom que l'utilisateur 
    '*          a donner et contenant les donnees du datagriview
    '*
    '***********************************************************************************************************

    Public Sub Export_Data_ExcelBis(ByVal dgv As DataGridView, Optional ByVal Rapport As String = "", Optional ByVal User As String = "")
        Dim SFD As New SaveFileDialog()
        SFD.Filter = "Fichiers Microsoft Office Excel | *.xlsx"
        If SFD.ShowDialog = DialogResult.OK Then
            Dim filename As String
            Dim col, row As Integer
            Dim Excel As Object = CreateObject("Excel.Application")

            'Verifier si Excel est present
            If Excel Is Nothing Then
                MessageBox.Show("Cette operation necessite la presence du logiciel MS Excel.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            With Excel
                .SheetsInNewWorkbook = 1
                .Workbooks.Add()
                .Worksheets(1).Select()
                'If Rapport.Length > 0 Then
                .Cells(2, 1).value = "BP 06"
                .Cells(3, 1).value = "GAROUA BOULAI"
                .cells(5, 1).value = "Date du jour " & Now().ToString("dd-MM-yyyy")
                .Cells(1, 1).value = "HOPITAL PROTESTANT DE " & .Cells(3, 1).value
                .Cells(1, 1).entirerow.font.bold = True
                'End If
                'Recuperer l'entete des colonnes
                'et creer l'entete du fichier excel
                Dim i As Integer = 1
                For col = 0 To dgv.ColumnCount - 1 ' ComDTable.Tables(0).Columns.Count - 1
                    .cells(7, i).value = dgv.Columns(col).HeaderText 'ComDTable.Tables(0).Columns(col).ColumnName
                    .cells(7, i).EntireRow.Font.Bold = True
                    i += 1
                Next

                '
                'i = 2
                'Recuperer les donnees dans le datagrid pour les copier dans le nouveau fichier Excel
                Dim k As Integer = 1

                For col = 0 To dgv.ColumnCount - 1
                    'Nous commencons a partir de la 8e ligne
                    i = 8
                    For row = 0 To dgv.RowCount - 1
                        .Cells(i, k).Value = dgv.Rows(row).Cells(col).Value
                        i += 1
                    Next
                    k += 1
                Next

                i += 2

                .Cells(i, 1).Value = "Fait le: " & Now().ToString("dd-MM-yyyy") & " A: GAROUA BOULAI"
                '.Cells(i + 1, 1).Value = "Par : "
                'Enregistrer le fichier
                filename = SFD.FileName
                .ActiveCell.Worksheet.SaveAs(filename)
            End With

            System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel)

            'Netoyage des processus
            Excel = Nothing
            Dim pro() As Process = System.Diagnostics.Process.GetProcessesByName("EXCEL")
            Dim ii As Process
            For Each ii In pro
                ii.Kill()
            Next
            MsgBox("Fichier Exporter avec succes...!", MsgBoxStyle.Information, "Export!")
        End If
    End Sub
    ''' <summary>
    ''' Routine pour cloturer un mois 
    ''' </summary>
    ''' <param name="Annee">est l'annee a cloturer</param>
    ''' <param name="Mois">est le mois de la periode a cloturer</param>
    ''' <remarks></remarks>
    Public Sub ClotureJournal(ByVal Annee As Integer, ByVal Mois As Integer)
        Dim Qry As String

        Qry = "SELECT distinct "
    End Sub
    '
    'Verifier si l'objet n'es pas DBnull pui renvoyer une chaine
    Public Function VerifyDBNull(ByVal Element As VariantType) As VariantType
        Dim ToReturn As VariantType
        If Not IsDBNull(Element) Then
            ToReturn = Element
        Else
            ToReturn = ""
        End If
        Return ToReturn
    End Function

    Public Sub AfficherFacture(ByVal Encounter As Long, ByVal NoFacture As Long, _
                                ByVal User As String, ByVal Agent As String, _
                                ByVal Versement As Long, ByVal Payee As Long, ByVal TotalFacture As Long, _
                                ByVal Pid As Long, ByVal PatientName As String, _
                                ByVal APayer As Long, ByVal Reste As Long, _
                                ByVal crptReport As CrystalDecisions.Windows.Forms.CrystalReportViewer, _
                                ByRef rpt As rptFactureAvance, ByVal DB As MySQLDataBaseAccess, ByVal SQL As String)

        'Dim ds As New DataSet1()
        DB.ExecQuery(SQL)

        Dim dtaDataTable As DataTable

        If NotEmpty(DB.Exception) Then MsgBox(DB.Exception) : Exit Sub
        dtaDataTable = DB.DBDataTable

        'affectation de la bd
        rpt.SetDataSource(dtaDataTable)


        ' affectation des autres element constitutif de la facture
        rpt.SetParameterValue("total", TotalFacture)
        rpt.SetParameterValue("payee", Payee)
        rpt.SetParameterValue("reste", Reste)
        rpt.SetParameterValue("verse", Versement)
        rpt.SetParameterValue("agentcaisse", User)
        rpt.SetParameterValue("agentfacturation", Agent)
        rpt.SetParameterValue("billnum", NoFacture)
        rpt.SetParameterValue("patient", PatientName)
        rpt.SetParameterValue("pid", Pid)
        rpt.SetParameterValue("encounter", Encounter)
        rpt.SetParameterValue("payement", APayer)

        'rpt.PrintOptions.PaperSize.

        crptReport.ReportSource = rpt
        crptReport.Show()
    End Sub


End Module
