Imports BlackCoffeeLibrary
Imports System.Data.SqlClient
Imports System.IO

Public Class Consultation
    Private connection As New clsConnection
    Private directories As New clsDirectory
    Private dbHealth As New SqlDbMethod(connection.MyConnection)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private dicSearchCriteria As New Dictionary(Of String, Integer)
    Private dicAlarmStatus As New Dictionary(Of String, Integer)

    Private imgList As New List(Of clsAttachment)

    Private attachDirMedicalRecord As String = directories.AttDirMedRecord

    Private bsConsultation As New BindingSource
    Private bsRestAlarm As New BindingSource
    Private bsScreening As New BindingSource
    Private bsSickLeave As New BindingSource
    Private dtConsultation As New DataTable
    Private dtRestAlarm As New DataTable
    Private dtScreening As New DataTable
    Private dtSickLeave As New DataTable

    Private pageIndex As Integer
    Private pageSize As Integer
    Private pageCount As Integer
    Private totalCount As Integer

    Private indexPosition As Integer = 0
    Private indexScroll As Integer = 0

    Private isFilterByAbsentDate As Boolean = False
    Private isFilterByAlarmDate As Boolean = False
    Private isFilterByAlarmStatus As Boolean = False
    Private isFilterByDateCreated As Boolean = False
    Private isFilterByDiagnosis As Boolean = False
    Private isFilterByEmployeeCode As Boolean = False
    Private isFilterByEmployeeName As Boolean = False
    Private isFilterByEmployeeNameAgency As Boolean = False
    Private isFilterByEmployeeNameNbc As Boolean = False
    Private isFilterByEmployeeNameRestAgency As Boolean = False
    Private isFilterByEmployeeNameRestNbc As Boolean = False
    Private isFilterByLeaveDate As Boolean = False
    Private isFilterByLeaveType As Boolean = False
    Private isFilterByMedCertDate As Boolean = False
    Private isFilterByReason As Boolean = False
    Private isFilterByScreeningDate As Boolean = False

    Private employeeId As Integer = 0

    Public Sub New(employeeId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.employeeId = employeeId
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSearchCriteria()

        pageIndex = 0
        pageSize = 50
        LoadTransaction()

        Me.dgvConsultation.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvConsultation.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvRestAlarm.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvScreening.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvScreening.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvSickLeave.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnsMode.Fill

        dbMain.EnableDoubleBuffered(dgvConsultation)
        dbMain.EnableDoubleBuffered(dgvMedicine)
        dbMain.EnableDoubleBuffered(dgvRestAlarm)
        dbMain.EnableDoubleBuffered(dgvApe)
        dbMain.EnableDoubleBuffered(dgvScreening)
        dbMain.EnableDoubleBuffered(dgvSickLeave)
        Me.ActiveControl = dgvConsultation
    End Sub

    Private Sub LoadSearchCriteria()
        cmbSearchCriteria.SelectedValue = 0
        cmbSearchCriteria.DataSource = Nothing
        cmbSearchCriteria.Items.Clear()
        dicSearchCriteria.Clear()

        Select Case tcDashboard.SelectedIndex
            Case 0 'consultation
                dicSearchCriteria.Add(" Name (NBC)", 1)
                dicSearchCriteria.Add(" Name (Agency)", 2)
                dicSearchCriteria.Add(" Employee ID", 3)
                dicSearchCriteria.Add(" Creation Date", 4)
                cmbSearchCriteria.DisplayMember = "Key"
                cmbSearchCriteria.ValueMember = "Value"
                cmbSearchCriteria.DataSource = New BindingSource(dicSearchCriteria, Nothing)

            Case 1 'rest monitoring
                dicSearchCriteria.Add(" Alarm Status", 1)
                dicSearchCriteria.Add(" Alarm Date", 2)
                dicSearchCriteria.Add(" Name (NBC)", 3)
                dicSearchCriteria.Add(" Name (Agency)", 4)
                cmbSearchCriteria.DisplayMember = "Key"
                cmbSearchCriteria.ValueMember = "Value"
                cmbSearchCriteria.DataSource = New BindingSource(dicSearchCriteria, Nothing)

            Case 2 'health screening
                dicSearchCriteria.Add(" Absent Date", 1)
                dicSearchCriteria.Add(" Screening Date", 2)
                dicSearchCriteria.Add(" Medical Cert Date", 3)
                dicSearchCriteria.Add(" Leave Type", 4)
                dicSearchCriteria.Add(" Employee Name", 5)
                dicSearchCriteria.Add(" Reason", 6)
                dicSearchCriteria.Add(" Diagnosis", 7)
                cmbSearchCriteria.DisplayMember = "Key"
                cmbSearchCriteria.ValueMember = "Value"
                cmbSearchCriteria.DataSource = New BindingSource(dicSearchCriteria, Nothing)

            Case 3 'sick leave
                dicSearchCriteria.Add(" Absent Date", 1)
                dicSearchCriteria.Add(" Leave Type", 2)
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
                    If isFilterByDateCreated = True Then
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

                        dtConsultation = dbHealth.FillDataTable("RdEmployeeMedicalRecordMasterlistByDateCreated", CommandType.StoredProcedure, prm)
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

                        dtConsultation = dbHealth.FillDataTable("RdEmployeeMedicalRecordMasterlistByEmployeeCode", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value

                    ElseIf isFilterByEmployeeNameNbc = True Then
                        Dim prm(3) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount
                        prm(3) = New SqlParameter("@EmployeeName", SqlDbType.NVarChar)
                        prm(3).Value = IIf(String.IsNullOrWhiteSpace(txtCommon.Text.Trim), Nothing, txtCommon.Text.Trim)

                        dtConsultation = dbHealth.FillDataTable("RdEmployeeMedicalRecordMasterlistByEmployeeName", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value

                    ElseIf isFilterByEmployeeNameAgency = True Then
                        Dim prm(3) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount
                        prm(3) = New SqlParameter("@EmployeeName", SqlDbType.NVarChar)
                        prm(3).Value = IIf(String.IsNullOrWhiteSpace(txtCommon.Text.Trim), Nothing, txtCommon.Text.Trim)

                        dtConsultation = dbHealth.FillDataTable("RdEmployeeMedicalRecordMasterlistByEmployeeNameAgency", CommandType.StoredProcedure, prm)
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

                        dtConsultation = dbHealth.FillDataTable("RdEmployeeMedicalRecordMasterlist", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value
                    End If

                    Me.bsConsultation.DataSource = dtConsultation
                    Me.bsConsultation.ResetBindings(True)
                    Me.dgvConsultation.AutoGenerateColumns = False
                    Me.dgvConsultation.DataSource = Me.bsConsultation

                Case 1 'rest monitoring
                    If isFilterByAlarmStatus = True Then
                        Dim prm(3) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount
                        prm(3) = New SqlParameter("@IsActive", SqlDbType.Bit)

                        Select Case cmbCommon.SelectedValue
                            Case 1
                                prm(3).Value = Nothing
                            Case 2
                                prm(3).Value = 1
                            Case 3
                                prm(3).Value = 0
                        End Select

                        dtRestAlarm = dbHealth.FillDataTable("RdRestAlarmMasterlistByIsActive", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value

                    ElseIf isFilterByAlarmDate = True Then
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

                    ElseIf isFilterByEmployeeNameRestNbc = True Then
                        Dim prm(3) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount
                        prm(3) = New SqlParameter("@EmployeeName", SqlDbType.NVarChar)
                        prm(3).Value = IIf(String.IsNullOrWhiteSpace(txtCommon.Text.Trim), Nothing, txtCommon.Text.Trim)

                        dtRestAlarm = dbHealth.FillDataTable("RdRestAlarmMasterlistByEmployeeName", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value

                    ElseIf isFilterByEmployeeNameRestAgency = True Then
                        Dim prm(3) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount
                        prm(3) = New SqlParameter("@EmployeeName", SqlDbType.NVarChar)
                        prm(3).Value = IIf(String.IsNullOrWhiteSpace(txtCommon.Text.Trim), Nothing, txtCommon.Text.Trim)

                        dtRestAlarm = dbHealth.FillDataTable("RdRestAlarmMasterlistByEmployeeNameAgency", CommandType.StoredProcedure, prm)
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
                        prm(3).Value = Nothing

                        dtRestAlarm = dbHealth.FillDataTable("RdRestAlarmMasterlistByIsActive", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value
                    End If

                    Me.bsRestAlarm.DataSource = dtRestAlarm
                    Me.bsRestAlarm.ResetBindings(True)
                    Me.dgvRestAlarm.AutoGenerateColumns = False
                    Me.dgvRestAlarm.DataSource = Me.bsRestAlarm

                Case 2 'health screening
                    If isFilterByAbsentDate = True Then
                        Dim prm(4) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount
                        prm(3) = New SqlParameter("@AbsentDateFrom", SqlDbType.Date)
                        prm(3).Value = dtpStartDateCommon.Value
                        prm(4) = New SqlParameter("@AbsentDateTo", SqlDbType.Date)
                        prm(4).Value = dtpEndDateCommon.Value

                        dtScreening = dbHealth.FillDataTable("RdScreeningByAbsentDate", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value

                    ElseIf isFilterByScreeningDate = True Then
                        Dim prm(4) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount
                        prm(3) = New SqlParameter("@ScreenDateFrom", SqlDbType.Date)
                        prm(3).Value = dtpStartDateCommon.Value
                        prm(4) = New SqlParameter("@ScreenDateTo", SqlDbType.Date)
                        prm(4).Value = dtpEndDateCommon.Value

                        dtScreening = dbHealth.FillDataTable("RdScreeningByScreenDate", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value

                    ElseIf isFilterByMedCertDate = True Then
                        Dim prm(4) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount
                        prm(3) = New SqlParameter("@AbsentDateFrom", SqlDbType.Date)
                        prm(3).Value = dtpStartDateCommon.Value
                        prm(4) = New SqlParameter("@AbsentDateTo", SqlDbType.Date)
                        prm(4).Value = dtpEndDateCommon.Value

                        dtScreening = dbHealth.FillDataTable("RdScreeningByMedCertDate", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value

                    ElseIf isFilterByLeaveType = True Then
                        Dim prm(3) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount
                        prm(3) = New SqlParameter("@LeaveTypeId", SqlDbType.Int)
                        prm(3).Value = IIf(cmbCommon.SelectedValue = 0, Nothing, cmbCommon.SelectedValue)

                        dtScreening = dbHealth.FillDataTable("RdScreeningByLeaveTypeId", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value

                    ElseIf isFilterByEmployeeName = True Then
                        Dim prm(3) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount
                        prm(3) = New SqlParameter("@EmployeeName", SqlDbType.NVarChar)
                        prm(3).Value = IIf(String.IsNullOrEmpty(txtCommon.Text.Trim), Nothing, txtCommon.Text.Trim)

                        dtScreening = dbHealth.FillDataTable("RdScreeningByEmployeeName", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value

                    ElseIf isFilterByReason = True Then
                        Dim prm(3) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount
                        prm(3) = New SqlParameter("@Reason", SqlDbType.NVarChar)
                        prm(3).Value = IIf(String.IsNullOrEmpty(txtCommon.Text.Trim), Nothing, txtCommon.Text.Trim)

                        dtScreening = dbHealth.FillDataTable("RdScreeningByReason", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value

                    ElseIf isFilterByDiagnosis = True Then
                        Dim prm(3) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount
                        prm(3) = New SqlParameter("@Diagnosis", SqlDbType.NVarChar)
                        prm(3).Value = IIf(String.IsNullOrEmpty(txtCommon.Text.Trim), Nothing, txtCommon.Text.Trim)

                        dtScreening = dbHealth.FillDataTable("RdScreeningByDiagnosis", CommandType.StoredProcedure, prm)
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

                        dtScreening = dbHealth.FillDataTable("RdScreening", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value
                    End If

                    Me.bsScreening.DataSource = dtScreening
                    Me.bsScreening.ResetBindings(True)
                    Me.dgvScreening.AutoGenerateColumns = False
                    Me.dgvScreening.DataSource = Me.bsScreening

                Case 3 'sick leave
                    If isFilterByLeaveDate = True Then

                    Else
                        Dim prm(2) As SqlParameter
                        prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
                        prm(0).Value = pageIndex
                        prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
                        prm(1).Value = pageSize
                        prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
                        prm(2).Direction = ParameterDirection.Output
                        prm(2).Value = totalCount

                        dtSickLeave = dbHealth.FillDataTable("RdLeaveFilingClinic", CommandType.StoredProcedure, prm)
                        totalCount = prm(2).Value
                    End If

                    Me.bsSickLeave.DataSource = dtSickLeave
                    Me.bsSickLeave.ResetBindings(True)
                    Me.dgvSickLeave.AutoGenerateColumns = False
                    Me.dgvSickLeave.DataSource = Me.bsSickLeave
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
        dgvRestAlarm.Dispose()
        dgvApe.Dispose()
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Select Case tcDashboard.SelectedIndex
                Case 0, 1
                    Using frmDetail As New ConsultationDetail(employeeId)
                        If frmDetail.ShowDialog(Me) = DialogResult.OK Then
                            Reload()
                        End If
                    End Using

                Case 2
                    'Using frmDetail As New ConsultationScreening(employeeId)
                    '    If frmDetail.ShowDialog(Me) = DialogResult.OK Then
                    '        Reload()
                    '    End If
                    'End Using
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
                    indexScroll = dgvRestAlarm.FirstDisplayedCell.RowIndex
                    indexPosition = dgvRestAlarm.CurrentRow.Index

                Case 2
                    indexScroll = dgvScreening.FirstDisplayedCell.RowIndex
                    indexPosition = dgvScreening.CurrentRow.Index

                Case 3
                    indexScroll = dgvSickLeave.FirstDisplayedCell.RowIndex
                    indexPosition = dgvSickLeave.CurrentRow.Index
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
                    Me.bsConsultation.Position = dgvConsultation.SelectedCells(0).RowIndex

                Case 1
                    dgvRestAlarm.FirstDisplayedScrollingRowIndex = indexScroll
                    If dgvRestAlarm.Rows.Count > indexPosition Then
                        dgvRestAlarm.Rows(indexPosition).Selected = True
                    Else
                        dgvRestAlarm.Rows(indexPosition - 1).Selected = True
                    End If
                    Me.bsRestAlarm.Position = dgvRestAlarm.SelectedCells(0).RowIndex

                Case 2
                    dgvScreening.FirstDisplayedScrollingRowIndex = indexScroll
                    If dgvScreening.Rows.Count > indexPosition Then
                        dgvScreening.Rows(indexPosition).Selected = True
                    Else
                        dgvScreening.Rows(indexPosition - 1).Selected = True
                    End If
                    Me.bsScreening.Position = dgvScreening.SelectedCells(0).RowIndex

                Case 3
                    dgvSickLeave.FirstDisplayedScrollingRowIndex = indexScroll
                    If dgvSickLeave.Rows.Count > indexPosition Then
                        dgvSickLeave.Rows(indexPosition).Selected = True
                    Else
                        dgvSickLeave.Rows(indexPosition - 1).Selected = True
                    End If
                    Me.bsSickLeave.Position = dgvSickLeave.SelectedCells(0).RowIndex
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
                    If dgvRestAlarm IsNot Nothing AndAlso dgvRestAlarm.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))
                    pageIndex = 0
                    LoadTransaction()
                    If dgvRestAlarm IsNot Nothing AndAlso dgvRestAlarm.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf SetScrollingIndex))

                Case 2
                    If dgvScreening IsNot Nothing AndAlso dgvScreening.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))
                    pageIndex = 0
                    LoadTransaction()
                    If dgvScreening IsNot Nothing AndAlso dgvScreening.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf SetScrollingIndex))

                Case 3
                    If dgvSickLeave IsNot Nothing AndAlso dgvSickLeave.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))
                    pageIndex = 0
                    LoadTransaction()
                    If dgvSickLeave IsNot Nothing AndAlso dgvSickLeave.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf SetScrollingIndex))
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            Select Case tcDashboard.SelectedIndex
                Case 0
                    If Me.dgvConsultation.Rows.Count > 0 Then
                        Dim recordId As Integer = CType(Me.bsConsultation.Current, DataRowView).Item("RecordId")

                        Using frmDetail As New ConsultationDetail(employeeId, recordId)
                            If frmDetail.ShowDialog(Me) = DialogResult.OK Then
                                Reload()
                            End If
                        End Using
                    End If

                Case 1
                    If Me.dgvRestAlarm.Rows.Count > 0 Then
                        Dim recordId As Integer = CType(Me.bsRestAlarm.Current, DataRowView).Item("RecordId")

                        Using frmDetail As New ConsultationDetail(employeeId, recordId)
                            If frmDetail.ShowDialog(Me) = DialogResult.OK Then
                                Reload()
                            End If
                        End Using
                    End If

                Case 2
                    'If Me.dgvScreening.Rows.Count > 0 Then
                    '    Dim recordId As Integer = CType(Me.bsScreening.Current, DataRowView).Item("RecordId")

                    '    Using frmDetail As New ConsultationScreening(employeeId, recordId)
                    '        If frmDetail.ShowDialog(Me) = DialogResult.OK Then
                    '            Reload()
                    '        End If
                    '    End Using
                    'End If
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConsultation.CellDoubleClick, dgvRestAlarm.CellDoubleClick, dgvScreening.CellDoubleClick
        btnEdit.PerformClick()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Select Case tcDashboard.SelectedIndex
                Case 0
                    If Me.dgvConsultation.Rows.Count > 0 AndAlso dgvConsultation.SelectedRows.Count > 0 Then
                        Dim recordId As Integer = CType(Me.bsConsultation.Current, DataRowView).Item("RecordId")
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
            End Select

            LoadTransaction()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbSearchCriteria_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSearchCriteria.SelectedValueChanged
        Try
            cmbCommon.SelectedValue = 0
            cmbCommon.DataSource = Nothing
            cmbCommon.Items.Clear()

            Select Case tcDashboard.SelectedIndex
                Case 0 'consultation
                    Select Case cmbSearchCriteria.SelectedValue
                        Case 1, 2, 3
                            pnlSearchDate.Visible = False
                            pnlSearchCmb.Visible = False
                            pnlSearchTxt.Visible = True

                            txtCommon.Clear()

                        Case 4
                            pnlSearchDate.Visible = True
                            pnlSearchCmb.Visible = False
                            pnlSearchTxt.Visible = False

                            dtpStartDateCommon.Value = CDate(dbHealth.GetServerDate).Date
                            dtpEndDateCommon.Value = CDate(dbHealth.GetServerDate).Date
                    End Select

                Case 1 'rest monitoring
                    Select Case cmbSearchCriteria.SelectedValue
                        Case 1
                            pnlSearchDate.Visible = False
                            pnlSearchCmb.Visible = True
                            pnlSearchTxt.Visible = False

                            LoadAlarmStatus()

                        Case 2
                            pnlSearchDate.Visible = True
                            pnlSearchCmb.Visible = False
                            pnlSearchTxt.Visible = False

                            dtpStartDateCommon.Value = CDate(dbHealth.GetServerDate).Date
                            dtpEndDateCommon.Value = CDate(dbHealth.GetServerDate).Date

                        Case 3, 4
                            pnlSearchDate.Visible = False
                            pnlSearchCmb.Visible = False
                            pnlSearchTxt.Visible = True
                    End Select

                Case 2 'health screening
                    Select Case cmbSearchCriteria.SelectedValue
                        Case 1, 2, 3
                            pnlSearchDate.Visible = True
                            pnlSearchCmb.Visible = False
                            pnlSearchTxt.Visible = False

                            dtpStartDateCommon.Value = CDate(dbHealth.GetServerDate).Date
                            dtpEndDateCommon.Value = CDate(dbHealth.GetServerDate).Date

                        Case 4
                            pnlSearchDate.Visible = False
                            pnlSearchCmb.Visible = True
                            pnlSearchTxt.Visible = False

                            LoadLeaveType()

                        Case 5, 6, 7
                            pnlSearchDate.Visible = False
                            pnlSearchCmb.Visible = False
                            pnlSearchTxt.Visible = True

                            txtCommon.Clear()
                    End Select

                Case 3 'sick leave
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
                            isFilterByEmployeeNameNbc = True
                            isFilterByEmployeeNameAgency = False
                            isFilterByEmployeeCode = False
                            isFilterByDateCreated = False

                        Case 2
                            isFilterByEmployeeNameNbc = False
                            isFilterByEmployeeNameAgency = True
                            isFilterByEmployeeCode = False
                            isFilterByDateCreated = False

                        Case 3
                            isFilterByEmployeeNameNbc = False
                            isFilterByEmployeeNameAgency = False
                            isFilterByEmployeeCode = True
                            isFilterByDateCreated = False

                        Case 4
                            If dtpStartDateCommon.Value.Date > dtpEndDateCommon.Value.Date Then
                                MessageBox.Show("Start date is later than end date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return
                            End If

                            isFilterByEmployeeNameNbc = False
                            isFilterByEmployeeNameAgency = False
                            isFilterByEmployeeCode = False
                            isFilterByDateCreated = True
                    End Select

                Case 1 'rest monitoring
                    Select Case cmbSearchCriteria.SelectedValue
                        Case 1
                            isFilterByAlarmStatus = True
                            isFilterByAlarmDate = False
                            isFilterByEmployeeNameRestNbc = False
                            isFilterByEmployeeNameRestAgency = False

                        Case 2
                            If dtpStartDateCommon.Value.Date > dtpEndDateCommon.Value.Date Then
                                MessageBox.Show("Start date is later than end date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return
                            End If

                            isFilterByAlarmStatus = False
                            isFilterByAlarmDate = True
                            isFilterByEmployeeNameRestNbc = False
                            isFilterByEmployeeNameRestAgency = False

                        Case 3
                            isFilterByAlarmStatus = False
                            isFilterByAlarmDate = False
                            isFilterByEmployeeNameRestNbc = True
                            isFilterByEmployeeNameRestAgency = False

                        Case 4
                            isFilterByAlarmStatus = False
                            isFilterByAlarmDate = False
                            isFilterByEmployeeNameRestNbc = False
                            isFilterByEmployeeNameRestAgency = True
                    End Select

                Case 2 'health screening
                    Select Case cmbSearchCriteria.SelectedValue
                        Case 1
                            If dtpStartDateCommon.Value.Date > dtpEndDateCommon.Value.Date Then
                                MessageBox.Show("Start date is later than end date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return
                            End If

                            isFilterByAbsentDate = True
                            isFilterByScreeningDate = False
                            isFilterByMedCertDate = False
                            isFilterByLeaveType = False
                            isFilterByEmployeeName = False
                            isFilterByReason = False
                            isFilterByDiagnosis = False

                        Case 2
                            If dtpStartDateCommon.Value.Date > dtpEndDateCommon.Value.Date Then
                                MessageBox.Show("Start date is later than end date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return
                            End If

                            isFilterByAbsentDate = False
                            isFilterByScreeningDate = True
                            isFilterByMedCertDate = False
                            isFilterByLeaveType = False
                            isFilterByEmployeeName = False
                            isFilterByReason = False
                            isFilterByDiagnosis = False

                        Case 3
                            If dtpStartDateCommon.Value.Date > dtpEndDateCommon.Value.Date Then
                                MessageBox.Show("Start date is later than end date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return
                            End If

                            isFilterByAbsentDate = False
                            isFilterByScreeningDate = False
                            isFilterByMedCertDate = True
                            isFilterByLeaveType = False
                            isFilterByEmployeeName = False
                            isFilterByReason = False
                            isFilterByDiagnosis = False

                        Case 4
                            isFilterByAbsentDate = False
                            isFilterByScreeningDate = False
                            isFilterByMedCertDate = False
                            isFilterByLeaveType = True
                            isFilterByEmployeeName = False
                            isFilterByReason = False
                            isFilterByDiagnosis = False

                        Case 5
                            isFilterByAbsentDate = False
                            isFilterByScreeningDate = False
                            isFilterByMedCertDate = False
                            isFilterByLeaveType = False
                            isFilterByEmployeeName = True
                            isFilterByReason = False
                            isFilterByDiagnosis = False

                        Case 6
                            isFilterByAbsentDate = False
                            isFilterByScreeningDate = False
                            isFilterByMedCertDate = False
                            isFilterByLeaveType = False
                            isFilterByEmployeeName = False
                            isFilterByReason = True
                            isFilterByDiagnosis = False

                        Case 7
                            isFilterByAbsentDate = False
                            isFilterByScreeningDate = False
                            isFilterByMedCertDate = False
                            isFilterByLeaveType = False
                            isFilterByEmployeeName = False
                            isFilterByReason = False
                            isFilterByDiagnosis = True
                    End Select

                Case 3 'sick leave
                    Select Case cmbSearchCriteria.SelectedValue
                        Case 1
                            isFilterByAbsentDate = True
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
                        Case 1, 2, 3
                            txtCommon.Clear()

                        Case 4
                            dtpStartDateCommon.Value = CDate(dbHealth.GetServerDate).Date
                            dtpEndDateCommon.Value = CDate(dbHealth.GetServerDate).Date
                    End Select

                    isFilterByEmployeeNameNbc = False
                    isFilterByEmployeeNameAgency = False
                    isFilterByEmployeeCode = False
                    isFilterByDateCreated = False

                Case 1 'rest monitoring
                    Select Case cmbSearchCriteria.SelectedValue
                        Case 1
                            cmbCommon.SelectedValue = 1

                        Case 2
                            dtpStartDateCommon.Value = CDate(dbHealth.GetServerDate).Date
                            dtpEndDateCommon.Value = CDate(dbHealth.GetServerDate).Date

                        Case 3, 4
                            txtCommon.Clear()
                    End Select

                    isFilterByAlarmStatus = False
                    isFilterByAlarmDate = False
                    isFilterByEmployeeNameRestNbc = False
                    isFilterByEmployeeNameRestAgency = False

                Case 2 'health screening
                    Select Case cmbSearchCriteria.SelectedValue
                        Case 1, 2, 3
                            dtpStartDateCommon.Value = CDate(dbHealth.GetServerDate).Date
                            dtpEndDateCommon.Value = CDate(dbHealth.GetServerDate).Date

                        Case 4
                            cmbCommon.SelectedValue = 1

                        Case 5, 6, 7
                            txtCommon.Clear()
                    End Select

                    isFilterByAbsentDate = False
                    isFilterByScreeningDate = False
                    isFilterByMedCertDate = False
                    isFilterByLeaveType = False
                    isFilterByEmployeeName = False
                    isFilterByReason = False
                    isFilterByDiagnosis = False

                Case 3 'sick leave
                    Select Case cmbSearchCriteria.SelectedValue
                        Case 1
                            dtpStartDateCommon.Value = CDate(dbHealth.GetServerDate).Date
                            dtpEndDateCommon.Value = CDate(dbHealth.GetServerDate).Date
                    End Select

                    isFilterByAbsentDate = False
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

    Private Sub LoadAlarmStatus()
        Try
            dicAlarmStatus.Clear()

            dicAlarmStatus.Add(" < All >", 1)
            dicAlarmStatus.Add(" Active", 2)
            dicAlarmStatus.Add(" Inactive", 3)

            cmbCommon.DisplayMember = "Key"
            cmbCommon.ValueMember = "Value"
            cmbCommon.DataSource = New BindingSource(dicAlarmStatus, Nothing)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadLeaveType()
        Try
            dbHealth.FillCmbWithCaption("RdLeaveType", CommandType.StoredProcedure, "LeaveTypeId", "LeaveTypeName", cmbCommon, "< All >")
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class