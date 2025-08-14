Imports BlackCoffeeLibrary
Imports ClosedXML.Excel
Imports System.Data.SqlClient
Imports System.IO

Public Class Medicine
    Private connection As New clsConnection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.LeaveConnection)

    Private dicSearchCriteria As New Dictionary(Of String, Integer)
    Private dicStockStatus As New Dictionary(Of String, Integer)
    Private dtMedicine As New DataTable

    Public bsMedicine As New BindingSource

    Private pageCount As Integer
    Private pageIndex As Integer
    Private pageSize As Integer
    Private totalCount As Integer

    Private indexPosition As Integer = 0
    Private indexScroll As Integer = 0

    Private isFilterByCategory As Boolean = False
    Private isFilterByMedicineName As Boolean = False
    Private isFilterByStockStatus As Boolean = False
    Private isFilterByUnit As Boolean = False

    Private attendantId As Integer = 0

    Public Sub New(attendantId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dbMain.EnableDoubleBuffered(dgvList)

        Me.attendantId = attendantId
    End Sub

    Public Sub Reload()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))
        LoadMedicine()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf SetScrollingIndex))
    End Sub

    Private Sub AllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllToolStripMenuItem.Click
        Try
            Dim dt As New DataTable

            dt = dbMethod.FillDataTable("SELECT * FROM dbo.VwMedicineStock ORDER BY MedicineName ASC", CommandType.Text)

            Dim folderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\"
            Dim fileName As String = folderPath & Convert.ToString(CDate(dbMethod.GetServerDate).Date.ToString("yyyyMMdd") & " Medicine Inventory.xlsx")

            If Not Directory.Exists(folderPath) Then
                Directory.CreateDirectory(folderPath)
            End If

            Using wb As New XLWorkbook()
                wb.Worksheets.Add(dt, "Sheet1")
                wb.SaveAs(fileName)
            End Using

            Process.Start(fileName)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BelowMinStockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BelowMinStockToolStripMenuItem.Click
        Try
            Dim dt As New DataTable

            dt = dbMethod.FillDataTable("SELECT * FROM dbo.VwMedicineStock WHERE ActualStock <= MinStock ORDER BY MedicineName ASC", CommandType.Text)

            Dim folderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\"
            Dim fileName As String = folderPath & Convert.ToString(CDate(dbMethod.GetServerDate).Date.ToString("yyyyMMdd") & " Medicine Inventory.xlsx")

            If Not Directory.Exists(folderPath) Then
                Directory.CreateDirectory(folderPath)
            End If

            Using wb As New XLWorkbook()
                wb.Worksheets.Add(dt, "Sheet1")
                wb.SaveAs(fileName)
            End Using

            Process.Start(fileName)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BelowOrderingPointToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BelowOrderingPointToolStripMenuItem.Click
        Try
            Dim dt As New DataTable

            dt = dbMethod.FillDataTable("SELECT * FROM dbo.VwMedicineStock WHERE ActualStock <= OrderingPoint ORDER BY MedicineName ASC", CommandType.Text)

            Dim folderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\"
            Dim fileName As String = folderPath & Convert.ToString(CDate(dbMethod.GetServerDate).Date.ToString("yyyyMMdd") & " Medicine Inventory.xlsx")

            If Not Directory.Exists(folderPath) Then
                Directory.CreateDirectory(folderPath)
            End If

            Using wb As New XLWorkbook()
                wb.Worksheets.Add(dt, "Sheet1")
                wb.SaveAs(fileName)
            End Using

            Process.Start(fileName)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pageIndex = 0
        LoadMedicine()
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pageIndex = pageCount - 1
        LoadMedicine()
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pageIndex += 1
        If pageIndex > pageCount - 1 Then
            pageIndex = pageCount - 1
        End If

        LoadMedicine()
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pageIndex -= 1
        If pageIndex < 0 Then
            pageIndex = 0
        End If

        LoadMedicine()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Using frm As New MedicineDetail(attendantId)
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    Reload()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If Me.dgvList.Rows.Count > 0 Then
                Dim medicineId As Integer = CType(Me.bsMedicine.Current, DataRowView).Item("MedicineId")

                Dim prmCnt(0) As SqlParameter
                prmCnt(0) = New SqlParameter("@MedicineId", SqlDbType.Int)
                prmCnt(0).Value = medicineId

                Dim count As Integer = dbMethod.ExecuteScalar("CntMedicineTrx", CommandType.StoredProcedure, prmCnt)

                If count > 0 Then
                    MessageBox.Show("This item contains records. Set to inactive instead.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                Dim question = String.Format("Are you sure you want to delete this item?")
                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim prmDel(0) As SqlParameter
                    prmDel(0) = New SqlParameter("@MedicineId", SqlDbType.Int)
                    prmDel(0).Value = medicineId

                    dbMethod.ExecuteNonQuery("DelMedicine", CommandType.StoredProcedure, prmDel)
                End If

                btnRefresh.PerformClick()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If Me.dgvList.Rows.Count > 0 Then
                Dim medicineId As Integer = CType(Me.bsMedicine.Current, DataRowView).Item("MedicineId")

                Using frm As New MedicineDetail(attendantId, medicineId)
                    If frm.ShowDialog(Me) = DialogResult.OK Then
                        Reload()
                    End If
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            cmsExport.Show(btnExport, New Point(0, 0))
            AllToolStripMenuItem.Select()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Go()
    End Sub

    Private Sub btnIssueStock_Click(sender As Object, e As EventArgs) Handles btnIssueStock.Click
        Try
            Using frm As New MedicineIssue(attendantId)
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    Reload()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReceiveStock_Click(sender As Object, e As EventArgs) Handles btnReceiveStock.Click
        Try
            Using frm As New MedicineReceive(attendantId)
                If frm.ShowDialog(Me) = DialogResult.OK Then
                    Reload()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Reload()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            isFilterByMedicineName = False
            isFilterByCategory = False
            isFilterByUnit = False
            isFilterByStockStatus = False

            cmbSearchCriteria.SelectedValue = 1

            txtCommon.Clear()
            cmbCommon.SelectedValue = 0
            cmbCommon2.SelectedValue = 0
            dtpStartDate.Value = CDate(dbMethod.GetServerDate).Date
            dtpEndDate.Value = CDate(dbMethod.GetServerDate).Date

            pageIndex = 0
            LoadMedicine()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Select Case cmbSearchCriteria.SelectedValue
                Case 1
                    isFilterByMedicineName = True
                    isFilterByCategory = False
                    isFilterByUnit = False
                    isFilterByStockStatus = False

                Case 2
                    isFilterByMedicineName = False
                    isFilterByCategory = True
                    isFilterByUnit = False
                    isFilterByStockStatus = False

                Case 3
                    isFilterByMedicineName = False
                    isFilterByCategory = False
                    isFilterByUnit = True
                    isFilterByStockStatus = False

                Case 4
                    isFilterByMedicineName = False
                    isFilterByCategory = False
                    isFilterByUnit = False
                    isFilterByStockStatus = True
            End Select

            pageIndex = 0
            LoadMedicine()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnViewLogs_Click(sender As Object, e As EventArgs) Handles btnViewLogs.Click
        Try
            'https://www.vbforums.com/showthread.php?369474-RESOLVED-Accessing-MDI-Parent-object-from-MDI-Child
            DirectCast(Me.MdiParent, Main).ClickMedicineLogs()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbCommon_Validated(sender As Object, e As EventArgs) Handles cmbCommon.Validated
        If cmbCommon.SelectedValue = 0 Then
            cmbCommon.SelectedValue = 0
        End If
    End Sub

    Private Sub cmbSearchCriteria_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSearchCriteria.SelectedValueChanged
        Try
            cmbCommon.SelectedValue = 0
            cmbCommon.DataSource = Nothing
            cmbCommon.Items.Clear()

            cmbCommon2.SelectedValue = 0
            cmbCommon2.DataSource = Nothing
            cmbCommon2.Items.Clear()

            Select Case cmbSearchCriteria.SelectedValue
                Case 1
                    txtCommon.Clear()

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = False
                    pnlSearchByCmb2.Visible = False
                    pnlSearchByText.Visible = True

                Case 2
                    LoadCategory()

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = True
                    pnlSearchByCmb2.Visible = False
                    pnlSearchByText.Visible = False

                Case 3
                    LoadUnit()

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = True
                    pnlSearchByCmb2.Visible = False
                    pnlSearchByText.Visible = False

                Case 4
                    LoadStockStatus()

                    pnlSearchByDate.Visible = False
                    pnlSearchByCmb.Visible = True
                    pnlSearchByCmb2.Visible = False
                    pnlSearchByText.Visible = False
            End Select

            Select Case cmbSearchCriteria.SelectedValue
                Case 2, 3, 4
                    ActiveControl = cmbCommon
                Case 1
                    ActiveControl = txtCommon
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'https://www.vbforums.com/showthread.php?600244-RESOLVED-DataGridView-Paint-and-Repaint-)
    Private Sub dgvList_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvList.CellPainting
        If (e.RowIndex < 0) Then
            Exit Sub
        End If

        Dim act As Integer = dgvList.Rows(e.RowIndex).Cells("ColActualStock").Value
        Dim ord As Integer = dgvList.Rows(e.RowIndex).Cells("ColOrderingPoint").Value
        Dim min As Integer = dgvList.Rows(e.RowIndex).Cells("ColMinStock").Value

        If act <= ord AndAlso Not act <= min Then
            e.CellStyle.BackColor = Color.Yellow
        End If

        If act <= min Then
            e.CellStyle.BackColor = Color.Orange
        End If

        If act = 0 Then
            e.CellStyle.BackColor = Color.Red
        End If
    End Sub

    Private Sub dgvTransactionHeader_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        btnEdit.PerformClick()
    End Sub

    Private Sub dgvTransactionHeader_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvList.DataError
        e.Cancel = False
    End Sub

    Private Sub GetScrollingIndex()
        indexScroll = dgvList.FirstDisplayedCell.RowIndex
        indexPosition = dgvList.CurrentRow.Index
    End Sub

    Private Sub Go()
        Try
            If String.IsNullOrEmpty(txtPageNumber.Text) Then
                MessageBox.Show("Page not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPageNumber.Focus()
                Return
            End If

            If CInt(txtPageNumber.Text) > pageCount Then
                MessageBox.Show("Page not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPageNumber.Focus()
                Return
            End If

            If CInt(txtPageNumber.Text) = 0 Then
                MessageBox.Show("Page not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPageNumber.Focus()
                Return
            End If

            pageIndex = CInt(txtPageNumber.Text) - 1
            LoadMedicine()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadCategory()
        dbMethod.FillCmbWithCaption("RdMedicineCategory", CommandType.StoredProcedure, "CategoryId", "CategoryName", cmbCommon, "< All >")
    End Sub

    Private Sub LoadMedicine()
        Try
            totalCount = 0

            If isFilterByMedicineName = True Then
                Dim prmPart(3) As SqlParameter
                prmPart(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmPart(0).Value = pageIndex
                prmPart(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmPart(1).Value = pageSize
                prmPart(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmPart(2).Direction = ParameterDirection.Output
                prmPart(2).Value = totalCount
                prmPart(3) = New SqlParameter("@MedicineName", SqlDbType.VarChar)
                prmPart(3).Value = IIf(String.IsNullOrWhiteSpace(txtCommon.Text.Trim), Nothing, txtCommon.Text.Trim)

                dtMedicine = dbMethod.FillDataTable("RdMedicineStockMasterlistByMedicineName", CommandType.StoredProcedure, prmPart)
                totalCount = prmPart(2).Value

            ElseIf isFilterByCategory = True Then
                Dim prmPart(3) As SqlParameter
                prmPart(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmPart(0).Value = pageIndex
                prmPart(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmPart(1).Value = pageSize
                prmPart(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmPart(2).Direction = ParameterDirection.Output
                prmPart(2).Value = totalCount
                prmPart(3) = New SqlParameter("@CategoryId", SqlDbType.Int)
                prmPart(3).Value = IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue)

                dtMedicine = dbMethod.FillDataTable("RdMedicineStockMasterlistByCategoryId", CommandType.StoredProcedure, prmPart)
                totalCount = prmPart(2).Value

            ElseIf isFilterByUnit = True Then
                Dim prmPart(3) As SqlParameter
                prmPart(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmPart(0).Value = pageIndex
                prmPart(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmPart(1).Value = pageSize
                prmPart(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmPart(2).Direction = ParameterDirection.Output
                prmPart(2).Value = totalCount
                prmPart(3) = New SqlParameter("@UnitId", SqlDbType.Int)
                prmPart(3).Value = IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue)

                dtMedicine = dbMethod.FillDataTable("RdMedicineStockMasterlistByUnitId", CommandType.StoredProcedure, prmPart)
                totalCount = prmPart(2).Value

            ElseIf isFilterByStockStatus = True Then
                Dim prmPart(3) As SqlParameter
                prmPart(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmPart(0).Value = pageIndex
                prmPart(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmPart(1).Value = pageSize
                prmPart(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmPart(2).Direction = ParameterDirection.Output
                prmPart(2).Value = totalCount
                prmPart(3) = New SqlParameter("@StockStatusId", SqlDbType.Int)
                prmPart(3).Value = IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue)

                dtMedicine = dbMethod.FillDataTable("RdMedicineStockMasterlistByStockStatusId", CommandType.StoredProcedure, prmPart)
                totalCount = prmPart(2).Value

            Else
                Dim prmPart(2) As SqlParameter
                prmPart(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                prmPart(0).Value = pageIndex
                prmPart(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                prmPart(1).Value = pageSize
                prmPart(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                prmPart(2).Direction = ParameterDirection.Output
                prmPart(2).Value = totalCount

                dtMedicine = dbMethod.FillDataTable("RdMedicineStockMasterlist", CommandType.StoredProcedure, prmPart)
                totalCount = prmPart(2).Value
            End If

            bsMedicine.DataSource = dtMedicine
            bsMedicine.ResetBindings(True)
            dgvList.AutoGenerateColumns = False
            dgvList.DataSource = bsMedicine

            If totalCount Mod pageSize = 0 Then
                If totalCount = 0 Then
                    pageCount = (totalCount / pageSize) + 1
                Else
                    pageCount = totalCount / pageSize
                End If
            Else
                pageCount = Math.Truncate(totalCount / pageSize) + 1
            End If

            'current page index and total number of pages
            txtPageNumber.Text = pageIndex + 1
            txtTotalPageNumber.Text = "of " & CInt(pageCount) & " Page(s)"

            'enables pager
            txtPageNumber.Enabled = True
            txtTotalPageNumber.Enabled = True
            BindingNavigatorMoveFirstItem.Enabled = True
            BindingNavigatorMovePreviousItem.Enabled = True
            BindingNavigatorMoveNextItem.Enabled = True
            BindingNavigatorMoveLastItem.Enabled = True
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSearchCriteria()
        Try
            dicSearchCriteria.Add(" Medicine Name", 1)
            dicSearchCriteria.Add(" Category", 2)
            dicSearchCriteria.Add(" Unit", 3)
            dicSearchCriteria.Add(" Stock Status", 4)

            cmbSearchCriteria.DisplayMember = "Key"
            cmbSearchCriteria.ValueMember = "Value"
            cmbSearchCriteria.DataSource = New BindingSource(dicSearchCriteria, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadStockStatus()
        Try
            dicStockStatus.Clear()

            dicStockStatus.Add(" < All >", 0)
            dicStockStatus.Add(" Zero Stock", 1)
            dicStockStatus.Add(" Stock Below Min Stock", 2)
            dicStockStatus.Add(" Stock Below Ordering Point", 3)

            cmbCommon.DisplayMember = "Key"
            cmbCommon.ValueMember = "Value"
            cmbCommon.DataSource = New BindingSource(dicStockStatus, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadUnit()
        dbMethod.FillCmbWithCaption("RdMedicineUnit", CommandType.StoredProcedure, "UnitId", "UnitName", cmbCommon, "< All >")
    End Sub

    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dgvList.Dispose()
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F2) Then
            e.Handled = True
            btnAdd.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F3) Then
            e.Handled = True
            btnEdit.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F5) Then
            e.Handled = True
            btnRefresh.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F8) Then
            e.Handled = True
            btnDelete.PerformClick()
        End If
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSearchCriteria()

        pageIndex = 0
        pageSize = 100
        LoadMedicine()

        Me.dgvList.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvList.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Me.ActiveControl = dgvList
    End Sub

    Private Sub SetScrollingIndex()
        dgvList.FirstDisplayedScrollingRowIndex = indexScroll
        If dgvList.Rows.Count > indexPosition Then
            dgvList.Rows(indexPosition).Selected = True
        Else
            dgvList.Rows(indexPosition - 1).Selected = True
        End If
        Me.bsMedicine.Position = dgvList.SelectedCells(0).RowIndex
    End Sub

    Private Sub txtPageNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPageNumber.KeyPress
        If ((Asc(e.KeyChar) >= 48 AndAlso Asc(e.KeyChar) <= 57) OrElse Asc(e.KeyChar) = 8 OrElse Asc(e.KeyChar) = 13 OrElse Asc(e.KeyChar) = 127) Then
            e.Handled = False
            If Asc(e.KeyChar) = 13 Then
                Go()
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub ZeroStockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZeroStockToolStripMenuItem.Click
        Try
            Dim dt As New DataTable

            dt = dbMethod.FillDataTable("SELECT * FROM dbo.VwMedicineStock WHERE ActualStock = 0", CommandType.Text)

            Dim folderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\"
            Dim fileName As String = folderPath & Convert.ToString(CDate(dbMethod.GetServerDate).Date.ToString("yyyyMMdd") & " Medicine Inventory.xlsx")

            If Not Directory.Exists(folderPath) Then
                Directory.CreateDirectory(folderPath)
            End If

            Using wb As New XLWorkbook()
                wb.Worksheets.Add(dt, "Sheet1")
                wb.SaveAs(fileName)
            End Using

            Process.Start(fileName)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class