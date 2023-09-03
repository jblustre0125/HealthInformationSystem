Imports BlackCoffeeLibrary
Imports HealthInformationSystem.dsHealth
Imports HealthInformationSystem.dsHealthTableAdapters
Imports System.Data.SqlClient

Public Class frmHealthScreeningHeader
    Private connection As New clsConnection
    Private directories As New clsDirectory
    Private dbHealth As New SqlDbMethod(connection.MyConnection)
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private dsLeaveFiling As New dsHealth
    Private adpScreening As New ScreeningTableAdapter
    Private dtScreening As New ScreeningDataTable
    Private bsScreening As New BindingSource

    Private pageSize As Integer
    Private pageIndex As Integer
    Private totalCount As Integer
    Private pageCount As Integer
    Private indexScroll As Integer = 0
    Private indexPosition As Integer = 0

    Private dicSearchCriteria As New Dictionary(Of String, Integer)

    Private isFilterByScreenDate As Boolean = False
    Private isFilterByEmployeeName As Boolean = False
    Private isFilterByAbsentFrom As Boolean = False
    Private isFilterByReason As Boolean = False
    Private isFilterByDiagnosis As Boolean = False

    Private Shared IsSent As Boolean = False
    Private senderEmailAddress As String = String.Empty
    Private senderEmailPassword As String = String.Empty
    Private devEmailAddress As String = String.Empty
    Private devEmailPassword As String = String.Empty

    Private attendantId As Integer = 0

    Public Sub New(_attendantId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        attendantId = _attendantId
    End Sub

    Private Sub frmHealthScreeningMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pageIndex = 0
        pageSize = 100
        BindPage()

        dbMain.EnableDoubleBuffered(dgvList)

        Me.dgvList.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvList.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvList.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        FillSearchCriteria()

        Me.ActiveControl = dgvList
    End Sub

    Private Sub frmHealthScreeningMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                e.Handled = True
                btnAdd.PerformClick()
            Case Keys.F3
                e.Handled = True
                btnEdit.PerformClick()
            Case Keys.F8
                e.Handled = True
                btnDelete.PerformClick()
            Case Keys.F5
                e.Handled = True
                RefreshList()
        End Select
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Select Case cmbSearchCriteria.SelectedValue
                Case 1
                    If dtpDateFrom.Value.Date > dtpDateTo.Value.Date Then
                        MessageBox.Show("Start date is later than end date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    isFilterByScreenDate = True
                    isFilterByEmployeeName = False
                    isFilterByAbsentFrom = False
                    isFilterByReason = False
                    isFilterByDiagnosis = False

                Case 2
                    isFilterByScreenDate = False
                    isFilterByEmployeeName = True
                    isFilterByAbsentFrom = False
                    isFilterByReason = False
                    isFilterByDiagnosis = False

                Case 3
                    If dtpDateFrom.Value.Date > dtpDateTo.Value.Date Then
                        MessageBox.Show("Start date is later than end date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    isFilterByScreenDate = False
                    isFilterByEmployeeName = False
                    isFilterByAbsentFrom = True
                    isFilterByReason = False
                    isFilterByDiagnosis = False

                Case 4
                    isFilterByScreenDate = False
                    isFilterByEmployeeName = False
                    isFilterByAbsentFrom = False
                    isFilterByReason = True
                    isFilterByDiagnosis = False

                Case 5
                    isFilterByScreenDate = False
                    isFilterByEmployeeName = False
                    isFilterByAbsentFrom = False
                    isFilterByReason = False
                    isFilterByDiagnosis = True
            End Select

            pageIndex = 0
            BindPage()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Select Case cmbSearchCriteria.SelectedValue
            Case 1
                isFilterByScreenDate = False
                isFilterByEmployeeName = False
                isFilterByAbsentFrom = False
                isFilterByReason = False
                isFilterByDiagnosis = False

                dtpDateFrom.Value = dbHealth.GetServerDate
                dtpDateTo.Value = dbHealth.GetServerDate

            Case 2
                isFilterByScreenDate = False
                isFilterByEmployeeName = True
                isFilterByAbsentFrom = False
                isFilterByReason = False
                isFilterByDiagnosis = False

                cmbEmployeeName.SelectedValue = 0

            Case 3
                isFilterByScreenDate = False
                isFilterByEmployeeName = False
                isFilterByAbsentFrom = False
                isFilterByReason = False
                isFilterByDiagnosis = False

                dtpDateFrom.Value = dbHealth.GetServerDate
                dtpDateTo.Value = dbHealth.GetServerDate

            Case 4
                isFilterByScreenDate = False
                isFilterByEmployeeName = False
                isFilterByAbsentFrom = False
                isFilterByReason = True
                isFilterByDiagnosis = False

                txtText.Clear()

            Case 5
                isFilterByScreenDate = False
                isFilterByEmployeeName = False
                isFilterByAbsentFrom = False
                isFilterByReason = False
                isFilterByDiagnosis = True

                txtText.Clear()
        End Select

        pageIndex = 0
        BindPage()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshList()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Using frmDetail As New frmHealthScreeningDetail(attendantId)
                frmDetail.ShowDialog(Me)
            End Using
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If dgvList.Rows.Count > 0 Then
                Dim screenId As Integer = CType(Me.bsScreening.Current, DataRowView).Item("ScreenId")
                Using frmDetail As New frmHealthScreeningDetail(attendantId, screenId)
                    If frmDetail.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                        RefreshList()
                    End If
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pageIndex = 0
        BindPage()
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pageIndex -= 1
        If pageIndex < 0 Then
            pageIndex = 0
        End If
        BindPage()
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pageIndex += 1
        If pageIndex > pageCount - 1 Then
            pageIndex = pageCount - 1
        End If
        BindPage()
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pageIndex = pageCount - 1
        BindPage()
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Go()
    End Sub

    Private Sub cmbSearchCriteria_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSearchCriteria.SelectedValueChanged
        Try
            Select Case cmbSearchCriteria.SelectedValue
                Case 1, 3
                    pnlDate.BringToFront()
                    pnlText.SendToBack()
                    pnlEmployeeName.SendToBack()
                    Me.ActiveControl = dtpDateFrom

                Case 2
                    pnlDate.SendToBack()
                    pnlText.SendToBack()
                    pnlEmployeeName.BringToFront()

                    dbJeonsoft.FillCmbWithCaption("SELECT Id, (TRIM(EmployeeCode) + '  ' + (FirstName + ' ' + ISNULL(SUBSTRING(CASE WHEN LEN(TRIM(MiddleName)) = 0 " &
                                                  "THEN NULL WHEN TRIM(MiddleName) = '-' THEN NULL ELSE TRIM(MiddleName) END, 1, 1) + '. ' , '') + LastName)) AS Name " &
                                                  "FROM dbo.tblEmployees WHERE Active = 1 And EmployeeCode Is Not NULL", CommandType.Text, "Id", "Name", cmbEmployeeName, "")

                    Me.ActiveControl = cmbEmployeeName

                Case 4, 5
                    pnlDate.SendToBack()
                    pnlText.BringToFront()
                    pnlEmployeeName.SendToBack()
                    Me.ActiveControl = txtText
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbEmployeeName_Validated(sender As Object, e As EventArgs) Handles cmbEmployeeName.Validated
        If cmbEmployeeName.Text.Trim.Length = 0 Or cmbEmployeeName.SelectedValue = 0 Then
            cmbEmployeeName.SelectedValue = 0
        End If
    End Sub

    Private Sub dgvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        btnEdit.PerformClick()
    End Sub

    Private Sub BindingNavigatorPositionItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPageNumber.KeyPress
        If ((Asc(e.KeyChar) >= 48 AndAlso Asc(e.KeyChar) <= 57) OrElse Asc(e.KeyChar) = 8 OrElse Asc(e.KeyChar) = 13 OrElse Asc(e.KeyChar) = 127) Then
            e.Handled = False
            If Asc(e.KeyChar) = 13 Then
                Go()
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub FillSearchCriteria()
        dicSearchCriteria.Add(" Screening Date", 1)
        dicSearchCriteria.Add(" Employee Name", 2)
        dicSearchCriteria.Add(" Absent Date", 3)
        dicSearchCriteria.Add(" Reason", 4)
        dicSearchCriteria.Add(" Diagnosis", 5)
        cmbSearchCriteria.DisplayMember = "Key"
        cmbSearchCriteria.ValueMember = "Value"
        cmbSearchCriteria.DataSource = New BindingSource(dicSearchCriteria, Nothing)
    End Sub

    Private Sub BindPage()
        Try
            totalCount = 0

            If isFilterByScreenDate = True Then
                Me.adpScreening.FillByScreenDate(Me.dsLeaveFiling.Screening, pageIndex, pageSize, totalCount, dtpDateFrom.Value.Date, dtpDateTo.Value.Date)
            ElseIf isFilterByEmployeeName = True Then
                Me.adpScreening.FillByEmployeeId(Me.dsLeaveFiling.Screening, pageIndex, pageSize, totalCount, IIf(cmbEmployeeName.SelectedValue, cmbEmployeeName.SelectedValue, Nothing))
            ElseIf isFilterByAbsentFrom = True Then
                Me.adpScreening.FillByAbsentFrom(Me.dsLeaveFiling.Screening, pageIndex, pageSize, totalCount, dtpDateFrom.Value.Date, dtpDateTo.Value.Date)
            ElseIf isFilterByReason = True Then
                Me.adpScreening.FillByReason(Me.dsLeaveFiling.Screening, pageIndex, pageSize, totalCount, txtText.Text.Trim)
            ElseIf isFilterByDiagnosis = True Then
                Me.adpScreening.FillByDiagnosis(Me.dsLeaveFiling.Screening, pageIndex, pageSize, totalCount, txtText.Text.Trim)
            Else
                Me.adpScreening.FillScreening(Me.dsLeaveFiling.Screening, pageIndex, pageSize, totalCount)
            End If

            Me.bsScreening.DataSource = Me.dsLeaveFiling
            Me.bsScreening.DataMember = dtScreening.TableName
            Me.bsScreening.ResetBindings(True)
            dgvList.AutoGenerateColumns = False
            Me.dgvList.DataSource = Me.bsScreening

            If totalCount Mod pageSize = 0 Then
                If totalCount = 0 Then
                    pageCount = (totalCount / pageSize) + 1
                Else
                    pageCount = totalCount / pageSize
                End If
            Else
                pageCount = Math.Truncate(totalCount / pageSize) + 1
            End If

            'current and total pages
            txtPageNumber.Text = pageIndex + 1
            txtTotalPageNumber.Text = " of " & CInt(pageCount) & " Page(s)"

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

    Public Sub RefreshList()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))
        pageIndex = 0
        BindPage()
        If dgvList IsNot Nothing AndAlso dgvList.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf SetScrollingIndex))
    End Sub

    Private Sub GetScrollingIndex()
        indexScroll = dgvList.FirstDisplayedCell.RowIndex
        indexPosition = dgvList.CurrentRow.Index
    End Sub

    Private Sub SetScrollingIndex()
        dgvList.FirstDisplayedScrollingRowIndex = indexScroll
        If dgvList.Rows.Count > indexPosition Then
            dgvList.Rows(indexPosition).Selected = True
        Else
            dgvList.Rows(indexPosition - 1).Selected = True
        End If
        Me.bsScreening.Position = dgvList.SelectedCells(0).RowIndex
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
            BindPage()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class