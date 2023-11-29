Imports BlackCoffeeLibrary
Imports System.Data.SqlClient
Imports System.IO

Public Class Consultation
    Private connection As New clsConnection
    Private directories As New clsDirectory
    Private dbHealth As New SqlDbMethod(connection.MyConnection)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private bsEmployeeMedicalRecord As New BindingSource
    Private dtEmployeeMedicalRecord As New DataTable
    Private bsRestAlarm As New BindingSource
    Private dtRestAlarm As New DataTable

    Private employeeId As Integer = 0
    Private isAdmin As Boolean = False

    Private pageIndex As Integer
    Private pageSize As Integer
    Private pageCount As Integer
    Private totalCount As Integer

    Private indexPosition As Integer = 0
    Private indexScroll As Integer = 0

    Private dicSearchCriteria As New Dictionary(Of String, Integer)

    Private attachDirMedicalRecord As String = directories.AttDirMedRecord

    Private isFilterByCreationDate As Boolean = False
    Private isFilterByAlarmTime As Boolean = False
    Private isFilterByEmployeeCode As Boolean = False

    Private imgList As New List(Of clsAttachment)

    Public Sub New(_employeeId As Integer, _isAdmin As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        employeeId = _employeeId
        isAdmin = _isAdmin
    End Sub

    Private Sub ConsultationHeader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSearchCriteria()

        pageIndex = 0
        pageSize = 50
        LoadTransaction()

        Me.dgvConsultation.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvConsultation.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvRest.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        dbMain.EnableDoubleBuffered(dgvConsultation)
        dbMain.EnableDoubleBuffered(dgvMedicine)
        dbMain.EnableDoubleBuffered(dgvRest)
        dbMain.EnableDoubleBuffered(dgvScreening)
        dbMain.EnableDoubleBuffered(dgvApe)
        Me.ActiveControl = dgvConsultation
    End Sub

    Private Sub LoadSearchCriteria()
        cmbSearchCriteria.SelectedValue = 0
        cmbSearchCriteria.DataSource = Nothing
        cmbSearchCriteria.Items.Clear()
        dicSearchCriteria.Clear()

        Select Case tcDashboard.SelectedIndex
            Case 0 'consultation
                dicSearchCriteria.Add(" Employee ID", 1)
                dicSearchCriteria.Add(" Creation Date", 2)
                cmbSearchCriteria.DisplayMember = "Key"
                cmbSearchCriteria.ValueMember = "Value"
                cmbSearchCriteria.DataSource = New BindingSource(dicSearchCriteria, Nothing)

            Case 1 'rest monitoring
                dicSearchCriteria.Add(" Alarm Time", 1)
                cmbSearchCriteria.DisplayMember = "Key"
                cmbSearchCriteria.ValueMember = "Value"
                cmbSearchCriteria.DataSource = New BindingSource(dicSearchCriteria, Nothing)

        End Select
    End Sub

    Private Sub LoadTransaction()
        Try
            totalCount = 0

            Select Case tcDashboard.SelectedIndex
                Case 0 'consultation
                    If isFilterByCreationDate = True Then
                        Dim prm(4) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount
                        prm(3) = New SqlParameter("@StartDate", SqlDbType.Date)
                        prm(3).Value = CDate(dtpStartDateCommon.Value)
                        prm(4) = New SqlParameter("@EndDate", SqlDbType.DateTime)
                        prm(4).Value = CDate(dtpEndDateCommon.Value)

                        dtEmployeeMedicalRecord = dbHealth.FillDataTable("RdEmployeeMedicalRecordMasterlistByDateCreated", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value

                    ElseIf isFilterByEmployeeCode = True Then
                        Dim prm(3) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount
                        prm(3) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
                        prm(3).Value = IIf(String.IsNullOrWhiteSpace(txtCommon.Text.Trim), Nothing, txtCommon.Text.Trim)

                        dtEmployeeMedicalRecord = dbHealth.FillDataTable("RdEmployeeMedicalRecordMasterlistByEmployeeCode", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value

                    Else
                        Dim prm(2) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount

                        dtEmployeeMedicalRecord = dbHealth.FillDataTable("RdEmployeeMedicalRecordMasterlist", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value
                    End If

                    Me.bsEmployeeMedicalRecord.DataSource = dtEmployeeMedicalRecord
                    Me.bsEmployeeMedicalRecord.ResetBindings(True)
                    Me.dgvConsultation.AutoGenerateColumns = False
                    Me.dgvConsultation.DataSource = Me.bsEmployeeMedicalRecord

                Case 1 'rest monitoring
                    If isFilterByAlarmTime = True Then
                        Dim prm(4) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount
                        prm(3) = New SqlParameter("@StartDate", SqlDbType.Date)
                        prm(3).Value = CDate(dtpStartDateCommon.Value)
                        prm(4) = New SqlParameter("@EndDate", SqlDbType.DateTime)
                        prm(4).Value = CDate(dtpEndDateCommon.Value)

                        dtRestAlarm = dbHealth.FillDataTable("RdRestAlarmMasterlistByAlarmTime", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value

                    Else
                        Dim prm(3) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount
                        prm(3) = New SqlParameter("@IsActive", SqlDbType.Bit)
                        prm(3).Value = True

                        dtRestAlarm = dbHealth.FillDataTable("RdRestAlarmMasterlistByIsActive", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value
                    End If

                    Me.bsRestAlarm.DataSource = dtRestAlarm
                    Me.bsRestAlarm.ResetBindings(True)
                    Me.dgvRest.AutoGenerateColumns = False
                    Me.dgvRest.DataSource = Me.bsRestAlarm

            End Select

            If totalCount Mod pageSize = 0 Then
                If totalCount = 0 Then
                    pageCount = (totalCount / pageSize) + 1
                Else
                    pageCount = totalCount / pageSize
                End If
            Else
                pageCount = Math.Truncate(totalCount / pageSize) + 1
            End If

            BindingNavigatorPageNumber.Enabled = True
            BindingNavigatorTotalPageNumber.Enabled = True
            BindingNavigatorPageNumber.Text = pageIndex + 1
            BindingNavigatorTotalPageNumber.Text = "of " & CInt(pageCount) & " Page(s)"

            BindingNavigatorMoveFirstItem.Enabled = True
            BindingNavigatorMovePreviousItem.Enabled = True
            BindingNavigatorMoveNextItem.Enabled = True
            BindingNavigatorMoveLastItem.Enabled = True
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        dgvConsultation.Dispose()
        dgvMedicine.Dispose()
        dgvRest.Dispose()
        dgvScreening.Dispose()
        dgvApe.Dispose()
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Select Case tcDashboard.SelectedIndex
                Case 0
                    Using frmDetail As New ConsultationDetail(employeeId)
                        If frmDetail.ShowDialog(Me) = DialogResult.OK Then
                            Reload()
                        End If
                    End Using

                Case 1

                Case 2

            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Dashboard_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                e.Handled = True
                btnAdd.PerformClick()
            Case Keys.F3
                e.Handled = True
                btnEdit.PerformClick()
            Case Keys.F4
                If Not ActiveControl Is btnSearch Then
                    btnSearch.Focus()
                Else
                    btnSearch.PerformClick()
                End If
            Case Keys.F5
                e.Handled = True
                BindingNavigatorRefresh.PerformClick()
            Case Keys.F8
                e.Handled = True
                btnDelete.PerformClick()
        End Select
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pageIndex += 1
        If pageIndex > pageCount - 1 Then
            pageIndex = pageCount - 1
        End If

        LoadTransaction()
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pageIndex = pageCount - 1
        LoadTransaction()
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pageIndex -= 1
        If pageIndex < 0 Then
            pageIndex = 0
        End If

        LoadTransaction()
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pageIndex = 0
        LoadTransaction()
    End Sub

    Private Sub BindingNavigatorRefresh_Click(sender As Object, e As EventArgs) Handles BindingNavigatorRefresh.Click
        Reload()
    End Sub

    Private Sub BindingNavigatorGo_Click(sender As Object, e As EventArgs) Handles BindingNavigatorGo.Click
        Go()
    End Sub

    Private Sub BindingNavigatorPageNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BindingNavigatorPageNumber.KeyPress
        If ((Asc(e.KeyChar) >= 48 AndAlso Asc(e.KeyChar) <= 57) OrElse Asc(e.KeyChar) = 8 OrElse Asc(e.KeyChar) = 13 OrElse Asc(e.KeyChar) = 127) Then
            e.Handled = False
            If Asc(e.KeyChar) = 13 Then
                Go()
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Go()
        Try
            If String.IsNullOrEmpty(BindingNavigatorPageNumber.Text) Then
                MessageBox.Show("Page not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                BindingNavigatorPageNumber.Focus()
                Return
            End If

            If CInt(BindingNavigatorPageNumber.Text) > pageCount Then
                MessageBox.Show("Page not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                BindingNavigatorPageNumber.Focus()
                Return
            End If

            If CInt(BindingNavigatorPageNumber.Text) = 0 Then
                MessageBox.Show("Page not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                BindingNavigatorPageNumber.Focus()
                Return
            End If

            pageIndex = CInt(BindingNavigatorPageNumber.Text) - 1
            LoadTransaction()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GetScrollingIndex()
        Try
            Select Case tcDashboard.SelectedIndex
                Case 0
                    indexScroll = dgvConsultation.FirstDisplayedCell.RowIndex
                    indexPosition = dgvConsultation.CurrentRow.Index

                Case 1
                    indexScroll = dgvRest.FirstDisplayedCell.RowIndex
                    indexPosition = dgvRest.CurrentRow.Index

            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetScrollingIndex()
        Try
            Select Case tcDashboard.SelectedIndex
                Case 0
                    dgvConsultation.FirstDisplayedScrollingRowIndex = indexScroll
                    If dgvConsultation.Rows.Count > indexPosition Then
                        dgvConsultation.Rows(indexPosition).Selected = True
                    Else
                        dgvConsultation.Rows(indexPosition - 1).Selected = True
                    End If
                    Me.bsEmployeeMedicalRecord.Position = dgvConsultation.SelectedCells(0).RowIndex

                Case 1
                    dgvRest.FirstDisplayedScrollingRowIndex = indexScroll
                    If dgvRest.Rows.Count > indexPosition Then
                        dgvRest.Rows(indexPosition).Selected = True
                    Else
                        dgvRest.Rows(indexPosition - 1).Selected = True
                    End If
                    Me.bsEmployeeMedicalRecord.Position = dgvRest.SelectedCells(0).RowIndex

            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Reload()
        Try
            Select Case tcDashboard.SelectedIndex
                Case 0
                    If dgvConsultation IsNot Nothing AndAlso dgvConsultation.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))
                    pageIndex = 0
                    LoadTransaction()
                    If dgvConsultation IsNot Nothing AndAlso dgvConsultation.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf SetScrollingIndex))

                Case 1
                    If dgvRest IsNot Nothing AndAlso dgvRest.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))
                    pageIndex = 0
                    LoadTransaction()
                    If dgvRest IsNot Nothing AndAlso dgvRest.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf SetScrollingIndex))

            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Select Case tcDashboard.SelectedIndex
            Case 0
                If Me.dgvConsultation.Rows.Count > 0 Then
                    Dim recordId As Integer = CType(Me.bsEmployeeMedicalRecord.Current, DataRowView).Item("RecordId")

                    Using frmDetail As New ConsultationDetail(employeeId, recordId)
                        If frmDetail.ShowDialog(Me) = DialogResult.OK Then
                            Reload()
                        End If
                    End Using

                End If
        End Select
    End Sub

    Private Sub dgvConsultation_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConsultation.CellDoubleClick
        btnEdit.PerformClick()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Select Case tcDashboard.SelectedIndex
                Case 0
                    If Me.dgvConsultation.Rows.Count > 0 AndAlso dgvConsultation.SelectedRows.Count > 0 Then
                        Dim recordId As Integer = CType(Me.bsEmployeeMedicalRecord.Current, DataRowView).Item("RecordId")
                        Dim attachmentCount As Integer = 0
                        Dim trxId As Integer = 0
                        Dim employeeId As Integer = 0
                        Dim employeeCode As String = String.Empty

                        If MessageBox.Show("Are you sure you want to delete this record?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) =
                            System.Windows.Forms.DialogResult.Yes Then

                            Dim prmRdHeader(0) As SqlParameter
                            prmRdHeader(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                            prmRdHeader(0).Value = recordId

                            Using rdrHeader As IDataReader = dbHealth.ExecuteReader("RdMedicineTrxHeaderByRecordId", CommandType.StoredProcedure, prmRdHeader)
                                While rdrHeader.Read
                                    trxId = rdrHeader.Item("TrxId")
                                    employeeId = rdrHeader.Item("EmployeeId")
                                    employeeCode = rdrHeader.Item("EmployeeCode").ToString.Trim
                                End While
                                rdrHeader.Close()
                            End Using

                            Dim prmRdDetail(0) As SqlParameter
                            prmRdDetail(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                            prmRdDetail(0).Value = trxId

                            're-add the issued medicine quantity to current ending balance
                            Using rdr As IDataReader = dbHealth.ExecuteReader("RdMedicineTrxDetailByTrxId", CommandType.StoredProcedure, prmRdDetail)
                                While rdr.Read
                                    Dim prmAdj(2) As SqlParameter
                                    prmAdj(0) = New SqlParameter("@

", SqlDbType.Int)
                                    prmAdj(0).Value = rdr.Item("StockId")
                                    prmAdj(1) = New SqlParameter("@TrxTypeId", SqlDbType.Int)
                                    prmAdj(1).Value = 1
                                    prmAdj(2) = New SqlParameter("@Qty", SqlDbType.Int)
                                    prmAdj(2).Value = rdr.Item("Qty")

                                    dbHealth.ExecuteNonQuery("UpdMedicineStockByStockId", CommandType.StoredProcedure, prmAdj)
                                End While
                                rdr.Close()
                            End Using

                            Dim prmAttachment(0) As SqlParameter
                            prmAttachment(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                            prmAttachment(0).Value = recordId

                            Using rdrAttachment As IDataReader = dbHealth.ExecuteReader("RdEmployeeMedicalAttachmentByRecordId", CommandType.StoredProcedure, prmAttachment)
                                While rdrAttachment.Read
                                    Dim oldPic As New clsAttachment(attachDirMedicalRecord & "\" & rdrAttachment.Item("Filename").ToString,
                                           rdrAttachment.Item("Filename").ToString, Path.GetExtension(rdrAttachment.Item("Filename").ToString).ToLower,
                                           rdrAttachment.Item("AttachmentId"))
                                    imgList.Add(oldPic)
                                End While
                                rdrAttachment.Close()
                            End Using

                            If imgList.Count > 0 Then
                                For i As Integer = 0 To imgList.Count - 1
                                    Dim ext As String = String.Empty
                                    Dim newName As String = String.Empty
                                    ext = Path.GetExtension(imgList(i).FileName).ToLower

                                    If employeeId <> 0 Then 'nbc
                                        newName = employeeId & "-" & recordId & "-" & imgList(i).AttachmentId & ext
                                    Else
                                        newName = employeeCode.ToString.ToLower & "-" & recordId & "-" & imgList(i).AttachmentId & ext
                                    End If

                                    File.Delete(attachDirMedicalRecord & "\" & newName)
                                Next
                            End If

                            Dim prmRdAlarm(0) As SqlParameter
                            prmRdAlarm(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                            prmRdAlarm(0).Value = recordId

                            Dim restAlarmId As Integer = 0
                            Dim roomId As Integer = 0
                            Dim bedId As Integer = 0
                            Dim activeRestAlarmId As Integer = 0

                            Using rdrAlarm As IDataReader = dbHealth.ExecuteReader("RdRestAlarmByRecordId", CommandType.StoredProcedure, prmRdAlarm)
                                While rdrAlarm.Read
                                    restAlarmId = rdrAlarm.Item("RestAlarmId")
                                    roomId = rdrAlarm.Item("RoomId")
                                    bedId = rdrAlarm.Item("BedId")
                                End While
                                rdrAlarm.Close()

                                Dim prmRdRoom(0) As SqlParameter
                                prmRdRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                prmRdRoom(0).Value = roomId

                                activeRestAlarmId = dbHealth.ExecuteScalar("SELECT RestAlarmId FROM dbo.RestAlarm WHERE RoomId = @RoomId AND IsActive = 1 ORDER BY RestAlarmId DESC", CommandType.Text, prmRdRoom)

                                If activeRestAlarmId = restAlarmId Then
                                    Dim prmOrgBed(1) As SqlParameter
                                    prmOrgBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                    prmOrgBed(0).Value = 1
                                    prmOrgBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                    prmOrgBed(1).Value = bedId
                                    dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmOrgBed)

                                    Dim prmOrgRoom(0) As SqlParameter
                                    prmOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                    prmOrgRoom(0).Value = roomId
                                    dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmOrgRoom)
                                End If

                                Dim prmDelRecord(0) As SqlParameter
                                prmDelRecord(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                                prmDelRecord(0).Value = recordId
                                dbHealth.ExecuteNonQuery("DelEmployeeMedicalRecord", CommandType.StoredProcedure, prmDelRecord)
                            End Using
                        End If
                    End If

                Case 1

                Case 2

                Case 3

                Case 4

            End Select

            LoadTransaction()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbSearchCriteria_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSearchCriteria.SelectedValueChanged
        Try
            Select Case tcDashboard.SelectedIndex
                Case 0 'consultation
                    Select Case cmbSearchCriteria.SelectedValue
                        Case 1
                            pnlSearchDate.Visible = False
                            pnlSearchCmb.Visible = False
                            pnlSearchTxt.Visible = True

                            txtCommon.Clear()

                        Case 2
                            pnlSearchDate.Visible = True
                            pnlSearchCmb.Visible = False
                            pnlSearchTxt.Visible = False

                            dtpStartDateCommon.Value = CDate(dbHealth.GetServerDate).Date
                            dtpEndDateCommon.Value = CDate(dbHealth.GetServerDate).Date

                    End Select

                Case 1 'rest monitoring
                    Select Case cmbSearchCriteria.SelectedValue
                        Case 1
                            pnlSearchDate.Visible = True
                            pnlSearchCmb.Visible = False
                            pnlSearchTxt.Visible = False

                            dtpStartDateCommon.Value = CDate(dbHealth.GetServerDate).Date
                            dtpEndDateCommon.Value = CDate(dbHealth.GetServerDate).Date

                    End Select

            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Select Case tcDashboard.SelectedIndex
                Case 0 'consultation
                    Select Case cmbSearchCriteria.SelectedValue
                        Case 1
                            isFilterByCreationDate = False
                            isFilterByEmployeeCode = True

                        Case 2
                            If dtpStartDateCommon.Value.Date > dtpEndDateCommon.Value.Date Then
                                MessageBox.Show("Start date is later than end date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return
                            End If

                            isFilterByCreationDate = True
                            isFilterByEmployeeCode = False

                    End Select

                Case 1 'rest monitoring
                    Select Case cmbSearchCriteria.SelectedValue
                        Case 1
                            If dtpStartDateCommon.Value.Date > dtpEndDateCommon.Value.Date Then
                                MessageBox.Show("Start date is later than end date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return
                            End If

                            isFilterByAlarmTime = True
                    End Select
            End Select

            pageIndex = 0
            LoadTransaction()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            Select Case tcDashboard.SelectedIndex
                Case 0 'consultation
                    Select Case cmbSearchCriteria.SelectedValue
                        Case 1
                            txtCommon.Clear()

                        Case 2
                            dtpStartDateCommon.Value = CDate(dbHealth.GetServerDate).Date
                            dtpEndDateCommon.Value = CDate(dbHealth.GetServerDate).Date

                    End Select

                    isFilterByEmployeeCode = False
                    isFilterByCreationDate = False

                Case 1 'rest monitoring
                    Select Case cmbSearchCriteria.SelectedValue
                        Case 1
                            dtpStartDateCommon.Value = CDate(dbHealth.GetServerDate).Date
                            dtpEndDateCommon.Value = CDate(dbHealth.GetServerDate).Date

                    End Select

                    isFilterByAlarmTime = False
            End Select

            pageIndex = 0
            LoadTransaction()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tcDashboard_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcDashboard.SelectedIndexChanged
        LoadSearchCriteria()
        LoadTransaction()
    End Sub

End Class