Imports BlackCoffeeLibrary
Imports HealthInformationSystem.dsHealth
Imports HealthInformationSystem.dsHealthTableAdapters
Imports System.Data.SqlClient

Public Class frmHealthScreeningDetail
    Private connection As New clsConnection
    Private directories As New clsDirectory
    Private dbHealth As New SqlDbMethod(connection.MyConnection)
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private dsHealth As New dsHealth
    Private adpScreening As New ScreeningTableAdapter
    Private adpLeaveFiling As New LeaveFilingTableAdapter
    Private dtScreening As New ScreeningDataTable
    Private dtLeaveFiling As New LeaveFilingDataTable
    Private bsScreening As New BindingSource
    Private bsLeaveFiling As New BindingSource

    Private WithEvents createdDate As Binding
    Private WithEvents modifiedDate As Binding
    Private WithEvents absentFrom As Binding
    Private WithEvents absentTo As Binding

    Private employeeId As Integer = 0
    Private departmentId As Integer = 0
    Private departmentName As String = String.Empty
    Private teamId As Integer = 0
    Private teamName As String = String.Empty
    Private positionId As Integer = 0
    Private positionName As String = String.Empty
    Private screenId As Integer = 0

    Private arrSplitted() As String 'value from scanner

    Private attendantId As Integer = 0

    Private lstLeaveTypeId As New List(Of Integer)

    Public Sub New(_attendantId As Integer, Optional _screenId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        attendantId = _attendantId
        screenId = _screenId
    End Sub

    Private Sub frmHealthScreeningDetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        dbHealth.FillCmbWithCaption("SELECT LeaveTypeId, TRIM(LeaveTypeName) AS LeaveTypeName " &
                                    "FROM LeaveType WHERE IsClinic = 1 " &
                                    "ORDER BY TRIM(LeaveTypeName) ",
                                    CommandType.Text, "LeaveTypeId", "LeaveTypeName",
                                    cmbLeaveType, "< Select Leave Type >")

        If screenId = 0 Then
            ResetForm()
        Else
            Me.adpScreening.FillByScreenId(Me.dsHealth.Screening, screenId)
            Me.bsScreening.DataSource = Me.dsHealth
            Me.bsScreening.DataMember = dtScreening.TableName
            Me.bsScreening.Position = Me.bsScreening.Find("ScreenId", screenId)

            Me.Text = "Record No. " & screenId
            btnDelete.Enabled = True

            txtEmployeeScanId.Enabled = False
            If CType(Me.bsScreening.Current, DataRowView).Item("EmployeeId") Is DBNull.Value Then
                employeeId = 0
            Else
                employeeId = CType(Me.bsScreening.Current, DataRowView).Item("EmployeeId")
            End If

            txtEmployeeCode.DataBindings.Add(New Binding("Text", Me.bsScreening.Current, "EmployeeCode"))
            txtEmployeeName.DataBindings.Add(New Binding("Text", Me.bsScreening.Current, "EmployeeName"))
            createdDate = New Binding("Text", Me.bsScreening.Current, "ScreenDate")
            txtCreatedDate.DataBindings.Add(createdDate)
            modifiedDate = New Binding("Text", Me.bsScreening.Current, "ModifiedDate")
            txtModifiedDate.DataBindings.Add(modifiedDate)
            absentFrom = New Binding("Text", Me.bsScreening.Current, "AbsentFrom")
            txtAbsentFrom.DataBindings.Add(absentFrom)
            absentTo = New Binding("Text", Me.bsScreening.Current, "AbsentTo")
            txtAbsentTo.DataBindings.Add(absentTo)
            txtReason.DataBindings.Add(New Binding("Text", Me.bsScreening.Current, "Reason"))
            txtDiagnosis.DataBindings.Add(New Binding("Text", Me.bsScreening.Current, "Diagnosis"))

            txtCreatedBy.DataBindings.Add(New Binding("Text", Me.bsScreening.Current, "ScreenByName"))

            cmbLeaveType.DataBindings.Add(New Binding("SelectedValue", Me.bsScreening.Current, "LeaveTypeId"))

            If CType(Me.bsScreening.Current, DataRowView).Item("IsFitToWork") = True Then
                chkNotFtw.Checked = False
            Else
                chkNotFtw.Checked = True
            End If

            If txtEmployeeCode.Text.Trim.Substring(0, 3).ToUpper.Trim.Equals("FMB") Then
                txtEmployeeName.ReadOnly = False
            Else
                txtEmployeeName.ReadOnly = True
            End If

            Me.ActiveControl = txtDiagnosis
            txtDiagnosis.Select(txtDiagnosis.Text.Trim.Length, 0)
        End If

        'list of leave types that is not automatic filed by health screening, (9,14) - ecq leaves
        Using rdrLeaveType As IDataReader = dbHealth.ExecuteReader("SELECT LeaveTypeId FROM dbo.LeaveType WHERE IsClinic = 1 AND LeaveTypeId NOT IN (9,14)",
                                                                   CommandType.Text)
            While rdrLeaveType.Read
                lstLeaveTypeId.Add(rdrLeaveType.Item("LeaveTypeId"))
            End While
            rdrLeaveType.Close()
        End Using
    End Sub

    Private Sub frmHealthScreeningDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                e.Handled = True
                btnCancel.PerformClick()
            Case Keys.F8
                e.Handled = True
                btnDelete.PerformClick()
            Case Keys.F10
                e.Handled = True
                btnSave.PerformClick()
            Case Keys.F11
                e.Handled = True
                'NotFitToWork()
        End Select
    End Sub

    Private Sub txtEmployeeScanId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmployeeScanId.KeyDown
        If e.KeyCode.Equals(Keys.Enter) Then
            e.Handled = True
            If String.IsNullOrEmpty(txtEmployeeScanId.Text.Trim) Then
                Me.ActiveControl = txtEmployeeScanId
                MessageBox.Show("Please enter employee ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            arrSplitted = Split(txtEmployeeScanId.Text.Trim, " ", 2)
            GetEmployeeInformation(arrSplitted(0).ToString)
        End If
    End Sub

    Private Sub createdDate_Format(sender As Object, e As ConvertEventArgs) Handles createdDate.Format
        If Not e.Value Is DBNull.Value Then
            e.Value = Format(e.Value, "MMMM dd, yyyy hh:mm:ss tt")
        Else
            e.Value = dbHealth.GetServerDate.ToString("MMMM dd, yyyy hh:mm:ss tt")
        End If
    End Sub

    Private Sub modifiedDate_Format(sender As Object, e As ConvertEventArgs) Handles modifiedDate.Format
        If Not e.Value Is DBNull.Value Then
            e.Value = Format(e.Value, "MMMM dd, yyyy hh:mm:ss tt")
        Else
            e.Value = ""
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(txtEmployeeScanId.Text.Trim) AndAlso String.IsNullOrEmpty(txtEmployeeCode.Text.Trim) Then
                Me.ActiveControl = txtEmployeeScanId
                MessageBox.Show("Please enter employee ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If cmbLeaveType.SelectedValue = 0 Then
                MessageBox.Show("Please select leave type.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ActiveControl = cmbLeaveType
                Return
            End If

            If String.IsNullOrEmpty(txtReason.Text.Trim) Then
                MessageBox.Show("Please indicate the reason.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ActiveControl = txtReason
                Return
            End If

            If String.IsNullOrEmpty(txtDiagnosis.Text.Trim) Then
                MessageBox.Show("Please indicate the diagnosis.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ActiveControl = txtDiagnosis
                Return
            End If

            If CDate(txtAbsentFrom.Text).Date > CDate(txtAbsentTo.Text).Date Then
                MessageBox.Show("Start date is later than end date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ActiveControl = txtAbsentFrom
                Return
            End If

            If cmbLeaveType.SelectedValue = 12 AndAlso Not (CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date)) Then
                MessageBox.Show("Half-day leave should have the same dates.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ActiveControl = cmbLeaveType
                Return
            End If

            SaveRecord(chkNotFtw.Checked)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub SaveRecord(isUnfitToWork As Boolean)
        Try
            Dim frmMain As Main = TryCast(Me.Owner, Main)

            If screenId = 0 Then 'new record
                Dim newScreeningRow As ScreeningRow = Me.dsHealth.Screening.NewScreeningRow

                Dim prmCntScreeningDateRange(4) As SqlParameter 'check if has duplicate record in screening (date range)
                prmCntScreeningDateRange(0) = New SqlParameter("@ScreenId", SqlDbType.Int)
                prmCntScreeningDateRange(0).Value = Nothing
                prmCntScreeningDateRange(1) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                prmCntScreeningDateRange(1).Value = employeeId
                prmCntScreeningDateRange(2) = New SqlParameter("@AbsentFrom", SqlDbType.Date)
                prmCntScreeningDateRange(2).Value = CDate(txtAbsentFrom.Text)
                prmCntScreeningDateRange(3) = New SqlParameter("@AbsentTo", SqlDbType.Date)
                prmCntScreeningDateRange(3).Value = CDate(txtAbsentTo.Text)
                prmCntScreeningDateRange(4) = New SqlParameter("TotalCount", SqlDbType.Int)
                prmCntScreeningDateRange(4).Direction = ParameterDirection.Output

                dbHealth.ExecuteScalar("CntScreeningDateRange", CommandType.StoredProcedure, prmCntScreeningDateRange)

                If prmCntScreeningDateRange(4).Value > 0 Then 'do not allow duplicate entry in screening
                    MessageBox.Show("Record already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                Else
                    Dim prmCntLeaveFilingDateExact(6) As SqlParameter 'check if has duplicate record in leave filing (exact date) i.e. leave filed in advance
                    prmCntLeaveFilingDateExact(0) = New SqlParameter("@LeaveFileId", SqlDbType.Int)
                    prmCntLeaveFilingDateExact(0).Value = Nothing
                    prmCntLeaveFilingDateExact(1) = New SqlParameter("@ScreenId", SqlDbType.Int)
                    prmCntLeaveFilingDateExact(1).Value = Nothing
                    prmCntLeaveFilingDateExact(2) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                    prmCntLeaveFilingDateExact(2).Value = employeeId
                    prmCntLeaveFilingDateExact(3) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmCntLeaveFilingDateExact(3).Value = CDate(txtAbsentFrom.Text)
                    prmCntLeaveFilingDateExact(4) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmCntLeaveFilingDateExact(4).Value = CDate(txtAbsentTo.Text)
                    prmCntLeaveFilingDateExact(5) = New SqlParameter("TotalLeaveFileId", SqlDbType.Int)
                    prmCntLeaveFilingDateExact(5).Direction = ParameterDirection.Output
                    prmCntLeaveFilingDateExact(6) = New SqlParameter("TotalScreenId", SqlDbType.Int)
                    prmCntLeaveFilingDateExact(6).Direction = ParameterDirection.Output

                    dbHealth.ExecuteScalar("CntLeaveFilingDateExact", CommandType.StoredProcedure, prmCntLeaveFilingDateExact)

                    If prmCntLeaveFilingDateExact(5).Value > 0 Then 'has duplicate record in leave filing, overwrite existing record
                        Dim rdrDateExact(2) As SqlParameter
                        rdrDateExact(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                        rdrDateExact(0).Value = employeeId
                        rdrDateExact(1) = New SqlParameter("@StartDate", SqlDbType.Date)
                        rdrDateExact(1).Value = CDate(txtAbsentFrom.Text)
                        rdrDateExact(2) = New SqlParameter("@EndDate", SqlDbType.Date)
                        rdrDateExact(2).Value = CDate(txtAbsentTo.Text)

                        Dim leaveFileId As Integer = 0 'get existing record in leave filing (exact date)
                        Dim startDate As Date = Nothing
                        Dim endDate As Date = Nothing
                        Dim question As String = String.Empty
                        Using rdrDate As IDataReader = dbHealth.ExecuteReader("RdLeaveFilingByLeaveDate", CommandType.StoredProcedure, rdrDateExact)
                            While rdrDate.Read
                                leaveFileId = rdrDate.Item("LeaveFileId")
                                startDate = CDate(rdrDate.Item("StartDate"))
                                endDate = CDate(rdrDate.Item("EndDate"))
                            End While
                            rdrDate.Close()
                        End Using

                        If startDate.Equals(endDate) Then
                            question = String.Format("Employee has existing leave dated {0}. Overwrite this record?", startDate.ToString("MMM dd, yyyy"))
                        Else
                            question = String.Format("Employee has existing leave dated from {0} to {1}. Overwrite this record?", startDate.ToString("MMM dd, yyyy"),
                                                     endDate.ToString("MMM dd, yyyy"))
                        End If

                        If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                            'direct - save to screening then automatic filing in leave application
                            'agency - save to screening only
                            If cmbLeaveType.SelectedValue = 9 Or cmbLeaveType.SelectedValue = 14 Then 'ecq leaves
                                With newScreeningRow
                                    .ScreenDate = dbHealth.GetServerDate
                                    .ScreenBy = attendantId
                                    .SetModifiedByNull()
                                    .SetModifiedDateNull()

                                    If employeeId = 0 Then
                                        .SetEmployeeIdNull() 'agency
                                    Else
                                        .EmployeeId = employeeId 'direct
                                    End If

                                    .EmployeeCode = txtEmployeeCode.Text.Trim
                                    .EmployeeName = txtEmployeeName.Text.Trim
                                    .AbsentFrom = CDate(txtAbsentFrom.Text)
                                    .AbsentTo = CDate(txtAbsentTo.Text)
                                    .Quantity = GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text))
                                    .LeaveTypeId = cmbLeaveType.SelectedValue
                                    .Reason = txtReason.Text.Trim
                                    .Diagnosis = txtDiagnosis.Text.Trim

                                    If cmbLeaveType.SelectedValue = 14 Then 'ecq - quarantine
                                        .IsFitToWork = False
                                    Else
                                        If isUnfitToWork = True Then
                                            .IsFitToWork = False
                                        Else
                                            .IsFitToWork = True
                                        End If
                                    End If

                                    .IsUsed = True
                                End With
                                Me.dsHealth.Screening.AddScreeningRow(newScreeningRow)
                                Me.adpScreening.Update(Me.dsHealth.Screening)

                                If employeeId <> 0 Then
                                    Me.adpLeaveFiling.FillByLeaveFileId(Me.dsHealth.LeaveFiling, leaveFileId)
                                    Dim leaveFilingRow As LeaveFilingRow = Me.dsHealth.LeaveFiling.FindByLeaveFileId(leaveFileId)

                                    'overwriting existing record in leave filing
                                    'change the modified date only, not the date created column
                                    'revert status to pending if already processed by hr
                                    With leaveFilingRow
                                        .ScreenId = newScreeningRow.ScreenId
                                        .StartDate = CDate(txtAbsentFrom.Text)
                                        .EndDate = CDate(txtAbsentTo.Text)
                                        .Quantity = GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text))
                                        .Reason = txtReason.Text.Trim
                                        .LeaveCredits = GetLeaveCredits(employeeId)
                                        .LeaveBalance = GetLeaveBalance(employeeId)
                                        .ClinicIsApproved = True
                                        .ClinicId = attendantId
                                        .ClinicApprovalDate = dbHealth.GetServerDate
                                        .ClinicRemarks = txtDiagnosis.Text.Trim
                                        .IsLateFiling = 1
                                        .LeaveTypeId = cmbLeaveType.SelectedValue
                                        .ModifiedBy = attendantId
                                        .ModifiedDate = dbHealth.GetServerDate
                                        .IsEncoded = False
                                        .IsDone = False

                                        .SuperiorIsApproved1 = 0
                                        .SetSuperiorApprovalDate1Null()
                                        .SetSuperiorRemarks1Null()

                                        .SuperiorIsApproved2 = 0
                                        .SetSuperiorApprovalDate2Null()
                                        .SetSuperiorRemarks2Null()

                                        .ManagerIsApproved = 0
                                        .SetManagerApprovalDateNull()
                                        .SetManagerRemarksNull()

                                        Dim prmCountRecipient(2) As SqlParameter
                                        prmCountRecipient(0) = New SqlParameter("@DepartmentId", SqlDbType.Int)
                                        prmCountRecipient(0).Value = departmentId
                                        prmCountRecipient(1) = New SqlParameter("@TeamId", SqlDbType.Int)
                                        prmCountRecipient(1).Value = teamId
                                        prmCountRecipient(2) = New SqlParameter("PositionId", SqlDbType.Int)
                                        prmCountRecipient(2).Value = positionId

                                        'check if automatic filing has recipient
                                        Dim count As Integer = dbHealth.ExecuteScalar("SELECT COUNT(RecipientId) AS Count FROM dbo.Recipient WHERE DepartmentId = @DepartmentId " &
                                                                                      "AND TeamId = @TeamId And PositionId = @PositionId ", CommandType.Text, prmCountRecipient)

                                        If count = 0 Then 'inform the developer regarding automatic filing with no recipients
                                            frmMain.SendEmailDeveloper(employeeId, txtEmployeeName.Text.ToString.Trim, cmbLeaveType.SelectedValue,
                                                                       cmbLeaveType.Text, departmentId, departmentName, teamId, teamName, positionId, positionName)
                                            'set the last approver based on the majority of other records per department
                                            Dim managerId As Integer = 0
                                            Dim prmDeptId(0) As SqlParameter
                                            prmDeptId(0) = New SqlParameter("@DepartmentId", SqlDbType.Int)
                                            prmDeptId(0).Value = departmentId

                                            managerId = dbHealth.ExecuteScalar("SELECT TOP 1 ManagerId FROM dbo.Recipient " &
                                                                           "WHERE DepartmentId = @DepartmentId GROUP BY ManagerId " &
                                                                           "ORDER BY COUNT(RecipientId) DESC",
                                                                           CommandType.Text, prmDeptId)

                                            If employeeId = managerId Then 'employee is a manager, set dgm as the approver
                                                .ManagerId = 70
                                            Else
                                                .ManagerId = managerId
                                            End If

                                            .RoutingStatusId = 3
                                        Else
                                            Dim prmRecipient(2) As SqlParameter
                                            prmRecipient(0) = New SqlParameter("@DepartmentId", SqlDbType.Int)
                                            prmRecipient(0).Value = departmentId
                                            prmRecipient(1) = New SqlParameter("@TeamId", SqlDbType.Int)
                                            prmRecipient(1).Value = teamId
                                            prmRecipient(2) = New SqlParameter("PositionId", SqlDbType.Int)
                                            prmRecipient(2).Value = positionId

                                            Using rdrRecipient As IDataReader = dbHealth.ExecuteReader("RdRecipient", CommandType.StoredProcedure, prmRecipient)
                                                While rdrRecipient.Read
                                                    If rdrRecipient.Item("SuperiorId1") Is DBNull.Value Then 'no superior 1
                                                        .SetSuperiorId1Null()

                                                        If rdrRecipient.Item("SuperiorId2") Is DBNull.Value Then
                                                            .SetSuperiorId2Null()

                                                            If employeeId = rdrRecipient.Item("ManagerId") Then 'employee is a manager, set dgm as the approver
                                                                .RoutingStatusId = 3
                                                                .ManagerId = 70 'dgm
                                                            Else
                                                                .RoutingStatusId = 3
                                                                .ManagerId = rdrRecipient.Item("ManagerId")
                                                            End If
                                                        Else
                                                            If employeeId = rdrRecipient.Item("SuperiorId2") Then
                                                                .RoutingStatusId = 3
                                                                .SetSuperiorId2Null()
                                                            Else
                                                                .RoutingStatusId = 4
                                                                .SuperiorId2 = rdrRecipient.Item("SuperiorId2")
                                                            End If
                                                        End If
                                                    Else 'with superior 1
                                                        If employeeId = rdrRecipient.Item("SuperiorId1") Then
                                                            .RoutingStatusId = 4
                                                            .SetSuperiorId1Null()
                                                        Else
                                                            .RoutingStatusId = 5
                                                            .SuperiorId1 = rdrRecipient.Item("SuperiorId1")
                                                        End If

                                                        If rdrRecipient.Item("SuperiorId2") Is DBNull.Value Then
                                                            .SetSuperiorId2Null()
                                                        Else
                                                            .SuperiorId2 = rdrRecipient.Item("SuperiorId2")
                                                        End If
                                                    End If

                                                    .ManagerId = rdrRecipient.Item("ManagerId")
                                                End While
                                                rdrRecipient.Close()
                                            End Using
                                        End If

                                        If .RoutingStatusId = 3 Then
                                            If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                           .ManagerId,
                                                                           cmbLeaveType.Text,
                                                                           StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                           departmentName,
                                                                           CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                           txtReason.Text.Trim)
                                            Else
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                           .ManagerId,
                                                                           cmbLeaveType.Text,
                                                                           StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase), departmentName,
                                                                           CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                           CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                           txtReason.Text.Trim)
                                            End If
                                        ElseIf .RoutingStatusId = 4 Then
                                            If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                           .SuperiorId2,
                                                                           cmbLeaveType.Text,
                                                                           StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                           departmentName,
                                                                           CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                           txtReason.Text.Trim)
                                            Else
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                           .SuperiorId2,
                                                                           cmbLeaveType.Text,
                                                                           StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                           departmentName,
                                                                           CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                           CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                           txtReason.Text.Trim)
                                            End If
                                        ElseIf .RoutingStatusId = 5 Then
                                            If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                           .SuperiorId1,
                                                                           cmbLeaveType.Text,
                                                                           StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                           departmentName,
                                                                           CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                           txtReason.Text.Trim)
                                            Else
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                           .SuperiorId1,
                                                                           cmbLeaveType.Text,
                                                                           StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                           departmentName,
                                                                           CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                           CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                           txtReason.Text.Trim)
                                            End If
                                        End If
                                    End With
                                End If
                                Me.adpLeaveFiling.Update(Me.dsHealth.LeaveFiling)
                                Me.dsHealth.AcceptChanges()

                            Else 'other leave types
                                With newScreeningRow
                                    .ScreenDate = dbHealth.GetServerDate
                                    .ScreenBy = attendantId
                                    .SetModifiedByNull()
                                    .SetModifiedDateNull()

                                    If employeeId = 0 Then
                                        .SetEmployeeIdNull()
                                    Else
                                        .EmployeeId = employeeId
                                    End If

                                    .EmployeeCode = txtEmployeeCode.Text.Trim
                                    .EmployeeName = txtEmployeeName.Text.Trim
                                    .AbsentFrom = CDate(txtAbsentFrom.Text)
                                    .AbsentTo = CDate(txtAbsentTo.Text)

                                    If cmbLeaveType.SelectedValue = 12 Then 'half-day leave
                                        .Quantity = 0.5
                                        .LeaveTypeId = 12
                                    Else
                                        .Quantity = GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text))
                                        .LeaveTypeId = cmbLeaveType.SelectedValue
                                    End If

                                    .Reason = txtReason.Text.Trim
                                    .Diagnosis = txtDiagnosis.Text.Trim

                                    If isUnfitToWork = True Then
                                        .IsFitToWork = False
                                    Else
                                        .IsFitToWork = True
                                    End If

                                    .IsUsed = True
                                End With
                                Me.dsHealth.Screening.AddScreeningRow(newScreeningRow)
                                Me.adpScreening.Update(Me.dsHealth.Screening)

                                If employeeId <> 0 Then
                                    Me.adpLeaveFiling.FillByLeaveFileId(Me.dsHealth.LeaveFiling, leaveFileId)
                                    Dim leaveFilingRow As LeaveFilingRow = Me.dsHealth.LeaveFiling.FindByLeaveFileId(leaveFileId)

                                    With leaveFilingRow
                                        .ScreenId = newScreeningRow.ScreenId
                                        .EmployeeId = employeeId
                                        .StartDate = CDate(txtAbsentFrom.Text)
                                        .EndDate = CDate(txtAbsentTo.Text)
                                        .Quantity = GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text))
                                        .Reason = txtReason.Text.Trim
                                        .LeaveCredits = GetLeaveCredits(employeeId)
                                        .LeaveBalance = GetLeaveBalance(employeeId)
                                        .ClinicIsApproved = True
                                        .ClinicId = attendantId
                                        .ClinicApprovalDate = dbHealth.GetServerDate
                                        .ClinicRemarks = txtDiagnosis.Text.Trim
                                        .IsLateFiling = 1
                                        .LeaveTypeId = cmbLeaveType.SelectedValue
                                        .ModifiedBy = attendantId
                                        .ModifiedDate = dbHealth.GetServerDate
                                        .IsEncoded = False
                                        .IsDone = False

                                        If .RoutingStatusId = 3 Then
                                            If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                       .ManagerId,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                            Else
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                       .ManagerId,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                       CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                            End If
                                        ElseIf .RoutingStatusId = 4 Then
                                            If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                       .SuperiorId2,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                            Else
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                       .SuperiorId2,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                       CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                            End If
                                        ElseIf .RoutingStatusId = 5 Then
                                            If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                       .SuperiorId1,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                            Else
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                       .SuperiorId1,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                       CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                            End If
                                        End If
                                    End With
                                End If
                                Me.adpLeaveFiling.Update(Me.dsHealth.LeaveFiling)
                                Me.dsHealth.AcceptChanges()
                            End If
                        Else
                            Return
                        End If
                    Else
                        'no duplicate record in leave filing (exact date)
                        'check if has duplicate record in leave filing (date range) i.e. date selected is overlapped or in-between of existing leave
                        Dim prmCountDate(6) As SqlParameter
                        prmCountDate(0) = New SqlParameter("@LeaveFileId", SqlDbType.Int)
                        prmCountDate(0).Value = Nothing
                        prmCountDate(1) = New SqlParameter("@ScreenId", SqlDbType.Int)
                        prmCountDate(1).Value = Nothing
                        prmCountDate(2) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                        prmCountDate(2).Value = employeeId
                        prmCountDate(3) = New SqlParameter("@StartDate", SqlDbType.Date)
                        prmCountDate(3).Value = CDate(txtAbsentFrom.Text)
                        prmCountDate(4) = New SqlParameter("@EndDate", SqlDbType.Date)
                        prmCountDate(4).Value = CDate(txtAbsentTo.Text)
                        prmCountDate(5) = New SqlParameter("TotalLeaveFileId", SqlDbType.Int)
                        prmCountDate(5).Direction = ParameterDirection.Output
                        prmCountDate(6) = New SqlParameter("TotalScreenId", SqlDbType.Int)
                        prmCountDate(6).Direction = ParameterDirection.Output

                        dbHealth.ExecuteScalar("CntLeaveFilingDateRange", CommandType.StoredProcedure, prmCountDate)

                        If prmCountDate(5).Value > 0 Then 'has duplicate entry in leave filing, do not allow
                            Dim rdrDateExact(2) As SqlParameter
                            rdrDateExact(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                            rdrDateExact(0).Value = employeeId
                            rdrDateExact(1) = New SqlParameter("@StartDate", SqlDbType.Date)
                            rdrDateExact(1).Value = CDate(txtAbsentFrom.Text)
                            rdrDateExact(2) = New SqlParameter("@EndDate", SqlDbType.Date)
                            rdrDateExact(2).Value = CDate(txtAbsentTo.Text)

                            Dim leaveFileId As Integer = 0
                            Dim startDate As Date = Nothing
                            Dim endDate As Date = Nothing
                            Dim question As String = String.Empty

                            'get the dates of existing leave (date range)
                            Using rdrDate As IDataReader = dbHealth.ExecuteReader("RdLeaveFilingByLeaveDate", CommandType.StoredProcedure, rdrDateExact)
                                While rdrDate.Read
                                    leaveFileId = rdrDate.Item("LeaveFileId")
                                    startDate = CDate(rdrDate.Item("StartDate"))
                                    endDate = CDate(rdrDate.Item("EndDate"))
                                End While
                                rdrDate.Close()
                            End Using

                            If startDate.Equals(endDate) Then
                                MessageBox.Show("Employee has existing leave dated {0}.", startDate.ToString("MMM dd, yyyy"))
                            Else
                                MessageBox.Show(String.Format("Employee has existing leave dated from {0} to {1}.", startDate.ToString("MMM dd, yyyy"),
                                                endDate.ToString("MMM dd, yyyy")))
                            End If

                        Else 'no existing leave (leave filing), save record
                            If cmbLeaveType.SelectedValue = 9 Or cmbLeaveType.SelectedValue = 14 Then
                                'direct - save to screening, automatic filing in leave application
                                'agency - save to screening only
                                With newScreeningRow
                                    .ScreenDate = dbHealth.GetServerDate
                                    .ScreenBy = attendantId
                                    .SetModifiedByNull()
                                    .SetModifiedDateNull()

                                    If employeeId = 0 Then
                                        .SetEmployeeIdNull() 'agency
                                    Else
                                        .EmployeeId = employeeId 'direct
                                    End If

                                    .EmployeeCode = txtEmployeeCode.Text.Trim
                                    .EmployeeName = txtEmployeeName.Text.Trim
                                    .AbsentFrom = CDate(txtAbsentFrom.Text)
                                    .AbsentTo = CDate(txtAbsentTo.Text)
                                    .Quantity = GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text))
                                    .LeaveTypeId = cmbLeaveType.SelectedValue
                                    .Reason = txtReason.Text.Trim
                                    .Diagnosis = txtDiagnosis.Text.Trim

                                    If cmbLeaveType.SelectedValue = 14 Then 'ecq - quarantine
                                        .IsFitToWork = False
                                    Else
                                        If isUnfitToWork = True Then
                                            .IsFitToWork = False
                                        Else
                                            .IsFitToWork = True
                                        End If
                                    End If

                                    .IsUsed = True
                                End With
                                Me.dsHealth.Screening.AddScreeningRow(newScreeningRow)
                                Me.adpScreening.Update(Me.dsHealth.Screening)

                                If employeeId <> 0 Then
                                    Dim newRowLeaveFiling As LeaveFilingRow = Me.dsHealth.LeaveFiling.NewLeaveFilingRow

                                    With newRowLeaveFiling
                                        .DateCreated = dbHealth.GetServerDate
                                        .ScreenId = newScreeningRow.ScreenId
                                        .EmployeeId = employeeId
                                        .DepartmentId = departmentId
                                        .TeamId = teamId
                                        .StartDate = CDate(txtAbsentFrom.Text)
                                        .EndDate = CDate(txtAbsentTo.Text)
                                        .Quantity = GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text))
                                        .Reason = txtReason.Text.Trim
                                        .LeaveCredits = GetLeaveCredits(employeeId)
                                        .LeaveBalance = GetLeaveBalance(employeeId)
                                        .ClinicIsApproved = 1
                                        .ClinicId = attendantId
                                        .ClinicApprovalDate = dbHealth.GetServerDate
                                        .ClinicRemarks = txtDiagnosis.Text.Trim
                                        .IsLateFiling = 1
                                        .LeaveTypeId = cmbLeaveType.SelectedValue
                                        .SetModifiedByNull()
                                        .SetModifiedDateNull()
                                        .IsEncoded = 0
                                        .IsDone = 0

                                        .SuperiorIsApproved1 = 0
                                        .SetSuperiorApprovalDate1Null()
                                        .SetSuperiorRemarks1Null()

                                        .SuperiorIsApproved2 = 0
                                        .SetSuperiorApprovalDate2Null()
                                        .SetSuperiorRemarks2Null()

                                        .ManagerIsApproved = 0
                                        .SetManagerApprovalDateNull()
                                        .SetManagerRemarksNull()

                                        Dim prmCountRecipient(2) As SqlParameter
                                        prmCountRecipient(0) = New SqlParameter("@DepartmentId", SqlDbType.Int)
                                        prmCountRecipient(0).Value = departmentId
                                        prmCountRecipient(1) = New SqlParameter("@TeamId", SqlDbType.Int)
                                        prmCountRecipient(1).Value = teamId
                                        prmCountRecipient(2) = New SqlParameter("PositionId", SqlDbType.Int)
                                        prmCountRecipient(2).Value = positionId

                                        Dim count As Integer = dbHealth.ExecuteScalar("SELECT COUNT(RecipientId) AS Count FROM dbo.Recipient WHERE DepartmentId = @DepartmentId " &
                                                                                      "AND TeamId = @TeamId And PositionId = @PositionId ", CommandType.Text, prmCountRecipient)

                                        If count = 0 Then 'inform the developer regarding automatic filing with no recipients
                                            frmMain.SendEmailDeveloper(employeeId, txtEmployeeName.Text.ToString.Trim, cmbLeaveType.SelectedValue,
                                                               cmbLeaveType.Text, departmentId, departmentName, teamId, teamName, positionId, positionName)
                                            'set the last approver based on the majority of other records per department
                                            Dim managerId As Integer = 0
                                            Dim prmDeptId(0) As SqlParameter
                                            prmDeptId(0) = New SqlParameter("@DepartmentId", SqlDbType.Int)
                                            prmDeptId(0).Value = departmentId

                                            managerId = dbHealth.ExecuteScalar("SELECT TOP 1 ManagerId FROM dbo.Recipient " &
                                                                               "WHERE DepartmentId = @DepartmentId GROUP BY ManagerId " &
                                                                               "ORDER BY COUNT(RecipientId) DESC",
                                                                               CommandType.Text, prmDeptId)

                                            If employeeId = managerId Then 'employee is a manager, set dgm as the approver
                                                .ManagerId = 70
                                            Else
                                                .ManagerId = managerId
                                            End If

                                            .RoutingStatusId = 3
                                        Else
                                            Dim prmRecipient(2) As SqlParameter
                                            prmRecipient(0) = New SqlParameter("@DepartmentId", SqlDbType.Int)
                                            prmRecipient(0).Value = departmentId
                                            prmRecipient(1) = New SqlParameter("@TeamId", SqlDbType.Int)
                                            prmRecipient(1).Value = teamId
                                            prmRecipient(2) = New SqlParameter("PositionId", SqlDbType.Int)
                                            prmRecipient(2).Value = positionId

                                            Using readerRecipient As IDataReader = dbHealth.ExecuteReader("RdRecipient", CommandType.StoredProcedure, prmRecipient)
                                                Dim superiorId1 As Integer = 0
                                                Dim superiorId2 As Integer = 0
                                                Dim managerId As Integer = 0

                                                While readerRecipient.Read
                                                    If readerRecipient.Item("SuperiorId1") Is DBNull.Value Then 'no superior 1
                                                        .SetSuperiorId1Null()

                                                        If readerRecipient.Item("SuperiorId2") Is DBNull.Value Then
                                                            .SetSuperiorId2Null()

                                                            If employeeId = readerRecipient.Item("ManagerId") Then 'employee is a manager, set dgm as the approver
                                                                .RoutingStatusId = 3
                                                                .ManagerId = 70 'dgm
                                                            Else
                                                                .RoutingStatusId = 3
                                                                .ManagerId = readerRecipient.Item("ManagerId")
                                                            End If
                                                        Else
                                                            If employeeId = readerRecipient.Item("SuperiorId2") Then
                                                                .RoutingStatusId = 3
                                                                .SetSuperiorId2Null()
                                                            Else
                                                                .RoutingStatusId = 4
                                                                .SuperiorId2 = readerRecipient.Item("SuperiorId2")
                                                            End If
                                                        End If

                                                    Else 'with superior 1
                                                        If employeeId = readerRecipient.Item("SuperiorId1") Then
                                                            .RoutingStatusId = 4
                                                            .SetSuperiorId1Null()
                                                        Else
                                                            .RoutingStatusId = 5
                                                            .SuperiorId1 = readerRecipient.Item("SuperiorId1")
                                                        End If

                                                        If readerRecipient.Item("SuperiorId2") Is DBNull.Value Then
                                                            .SetSuperiorId2Null()
                                                        Else
                                                            .SuperiorId2 = readerRecipient.Item("SuperiorId2")
                                                        End If
                                                    End If

                                                    .ManagerId = readerRecipient.Item("ManagerId")
                                                    managerId = readerRecipient.Item("ManagerId")
                                                End While
                                                readerRecipient.Close()
                                            End Using
                                        End If
                                    End With
                                    Me.dsHealth.LeaveFiling.AddLeaveFilingRow(newRowLeaveFiling)
                                    Me.adpLeaveFiling.Update(Me.dsHealth.LeaveFiling)

                                    If newRowLeaveFiling.RoutingStatusId = 3 Then
                                        If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.ManagerId,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        Else
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.ManagerId,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                       CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        End If
                                    ElseIf newRowLeaveFiling.RoutingStatusId = 4 Then
                                        If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.SuperiorId2,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        Else
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.SuperiorId2,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                       CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        End If
                                    ElseIf newRowLeaveFiling.RoutingStatusId = 5 Then
                                        If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.SuperiorId1,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        Else
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.SuperiorId1,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                       CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        End If
                                    End If
                                End If
                            Else 'other leave types
                                With newScreeningRow
                                    .ScreenDate = dbHealth.GetServerDate
                                    .ScreenBy = attendantId
                                    .SetModifiedByNull()
                                    .SetModifiedDateNull()

                                    If employeeId = 0 Then
                                        .SetEmployeeIdNull()
                                    Else
                                        .EmployeeId = employeeId
                                    End If

                                    .EmployeeCode = txtEmployeeCode.Text.Trim
                                    .EmployeeName = txtEmployeeName.Text.Trim
                                    .AbsentFrom = CDate(txtAbsentFrom.Text)
                                    .AbsentTo = CDate(txtAbsentTo.Text)

                                    If cmbLeaveType.SelectedValue = 12 Then 'half-day leave
                                        .Quantity = 0.5
                                        .LeaveTypeId = 12
                                    Else
                                        .Quantity = GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text))
                                        .LeaveTypeId = cmbLeaveType.SelectedValue
                                    End If

                                    .Reason = txtReason.Text.Trim
                                    .Diagnosis = txtDiagnosis.Text.Trim

                                    If isUnfitToWork = True Then
                                        .IsFitToWork = False
                                    Else
                                        .IsFitToWork = True
                                    End If

                                    .IsUsed = False
                                End With
                                Me.dsHealth.Screening.AddScreeningRow(newScreeningRow)
                                Me.adpScreening.Update(Me.dsHealth.Screening)

                                If employeeId > 0 Then
                                    If lstLeaveTypeId.Contains(cmbLeaveType.SelectedValue) Then
                                        If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                            frmMain.SendEmailEmployee(employeeId,
                                                                      CDate(dbHealth.GetServerDate).ToString("MMMM dd, yyyy hh:mm tt"),
                                                                      cmbLeaveType.Text,
                                                                      CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                      GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text)),
                                                                      txtReason.Text.Trim, txtDiagnosis.Text.Trim,
                                                                      IIf(isUnfitToWork = True, "NO", "YES"))
                                        Else
                                            If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                                frmMain.SendEmailEmployee(employeeId,
                                                                         CDate(dbHealth.GetServerDate).ToString("MMMM dd, yyyy hh:mm tt"),
                                                                          cmbLeaveType.Text,
                                                                          CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - ",
                                                                          GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text)),
                                                                          txtReason.Text.Trim, txtDiagnosis.Text.Trim,
                                                                          IIf(isUnfitToWork = True, "NO", "YES"))

                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                    Me.dsHealth.AcceptChanges()

                    For Each frm As Form In Application.OpenForms
                        If frm.Name = "frmHealthScreeningHeader" Then
                            Dim frmHeader As frmHealthScreeningHeader = DirectCast(frm, frmHealthScreeningHeader)
                            frmHeader.RefreshList()
                        End If
                    Next

                    ResetForm()

                End If

            Else 'old record
                Dim rowScreening As ScreeningRow = Me.dsHealth.Screening.FindByScreenId(screenId)

                Dim prmCountScrDate(4) As SqlParameter 'check if has duplicate record in screening (date range)
                prmCountScrDate(0) = New SqlParameter("@ScreenId", SqlDbType.Int)
                prmCountScrDate(0).Value = screenId
                prmCountScrDate(1) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                prmCountScrDate(1).Value = employeeId
                prmCountScrDate(2) = New SqlParameter("@AbsentFrom", SqlDbType.Date)
                prmCountScrDate(2).Value = CDate(txtAbsentFrom.Text)
                prmCountScrDate(3) = New SqlParameter("@AbsentTo", SqlDbType.Date)
                prmCountScrDate(3).Value = CDate(txtAbsentTo.Text)
                prmCountScrDate(4) = New SqlParameter("TotalCount", SqlDbType.Int)
                prmCountScrDate(4).Direction = ParameterDirection.Output

                dbHealth.ExecuteScalar("CntScreeningDateRange", CommandType.StoredProcedure, prmCountScrDate)

                If prmCountScrDate(4).Value > 0 Then 'do not allow duplicate entry in screening
                    MessageBox.Show("Record already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                Else
                    Dim prmCntLeaveFilingDateExact(6) As SqlParameter
                    'check if has duplicate record in leave filing (exact date) but not the same screen id i.e. leave filed in advance
                    prmCntLeaveFilingDateExact(0) = New SqlParameter("@LeaveFileId", SqlDbType.Int)
                    prmCntLeaveFilingDateExact(0).Value = Nothing
                    prmCntLeaveFilingDateExact(1) = New SqlParameter("@ScreenId", SqlDbType.Int)
                    prmCntLeaveFilingDateExact(1).Value = screenId
                    prmCntLeaveFilingDateExact(2) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                    prmCntLeaveFilingDateExact(2).Value = employeeId
                    prmCntLeaveFilingDateExact(3) = New SqlParameter("@StartDate", SqlDbType.Date)
                    prmCntLeaveFilingDateExact(3).Value = CDate(txtAbsentFrom.Text)
                    prmCntLeaveFilingDateExact(4) = New SqlParameter("@EndDate", SqlDbType.Date)
                    prmCntLeaveFilingDateExact(4).Value = CDate(txtAbsentTo.Text)
                    prmCntLeaveFilingDateExact(5) = New SqlParameter("TotalLeaveFileId", SqlDbType.Int)
                    prmCntLeaveFilingDateExact(5).Direction = ParameterDirection.Output
                    prmCntLeaveFilingDateExact(6) = New SqlParameter("TotalScreenId", SqlDbType.Int)
                    prmCntLeaveFilingDateExact(6).Direction = ParameterDirection.Output

                    dbHealth.ExecuteScalar("CntLeaveFilingDateExact", CommandType.StoredProcedure, prmCntLeaveFilingDateExact)

                    If prmCntLeaveFilingDateExact(5).Value > 0 Then 'has duplicate record in leave filing but not the same screen id, overwrite existing record
                        Dim rdrDateExact(2) As SqlParameter
                        rdrDateExact(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                        rdrDateExact(0).Value = employeeId
                        rdrDateExact(1) = New SqlParameter("@StartDate", SqlDbType.Date)
                        rdrDateExact(1).Value = CDate(txtAbsentFrom.Text)
                        rdrDateExact(2) = New SqlParameter("@EndDate", SqlDbType.Date)
                        rdrDateExact(2).Value = CDate(txtAbsentTo.Text)

                        Dim leaveFileId As Integer = 0 'get existing record in leave filing (exact date)
                        Dim startDate As Date = Nothing
                        Dim endDate As Date = Nothing
                        Dim question As String = String.Empty
                        Using rdrDate As IDataReader = dbHealth.ExecuteReader("RdLeaveFilingByLeaveDate", CommandType.StoredProcedure, rdrDateExact)
                            While rdrDate.Read
                                leaveFileId = rdrDate.Item("LeaveFileId")
                                startDate = CDate(rdrDate.Item("StartDate"))
                                endDate = CDate(rdrDate.Item("EndDate"))
                            End While
                            rdrDate.Close()
                        End Using

                        If startDate.Equals(endDate) Then
                            question = String.Format("Employee has existing leave dated {0}. Overwrite this record?", startDate.ToString("MMM dd, yyyy"))
                        Else
                            question = String.Format("Employee has existing leave dated from {0} to {1}. Overwrite this record?", startDate.ToString("MMM dd, yyyy"),
                                                     endDate.ToString("MMM dd, yyyy"))
                        End If

                        If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                            'direct - update screening and leave filing
                            'agency - update screening only
                            If cmbLeaveType.SelectedValue = 9 Or cmbLeaveType.SelectedValue = 14 Then 'ecq leaves
                                With rowScreening
                                    .ModifiedBy = attendantId
                                    .ModifiedDate = dbHealth.GetServerDate

                                    If employeeId = 0 Then
                                        .SetEmployeeIdNull() 'agency
                                    Else
                                        .EmployeeId = employeeId 'direct
                                    End If

                                    .AbsentFrom = CDate(txtAbsentFrom.Text)
                                    .AbsentTo = CDate(txtAbsentTo.Text)
                                    .Quantity = GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text))
                                    .LeaveTypeId = cmbLeaveType.SelectedValue
                                    .Reason = txtReason.Text.Trim
                                    .Diagnosis = txtDiagnosis.Text.Trim

                                    If cmbLeaveType.SelectedValue = 14 Then 'ecq - quarantine
                                        .IsFitToWork = False
                                    Else
                                        If isUnfitToWork = True Then
                                            .IsFitToWork = False
                                        Else
                                            .IsFitToWork = True
                                        End If
                                    End If
                                End With

                                If employeeId <> 0 Then
                                    Me.adpLeaveFiling.FillByLeaveFileId(Me.dsHealth.LeaveFiling, leaveFileId)
                                    Dim rowLeaveFiling As LeaveFilingRow = Me.dsHealth.LeaveFiling.FindByLeaveFileId(leaveFileId)

                                    'overwriting existing record in leave filing
                                    'change the modified date only, not the date created column
                                    'revert status to pending if already processed by hr
                                    With rowLeaveFiling
                                        .ScreenId = screenId
                                        .StartDate = CDate(txtAbsentFrom.Text)
                                        .EndDate = CDate(txtAbsentTo.Text)
                                        .Quantity = GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text))
                                        .Reason = txtReason.Text.Trim
                                        .LeaveCredits = GetLeaveCredits(employeeId)
                                        .LeaveBalance = GetLeaveBalance(employeeId)
                                        .ClinicIsApproved = True
                                        .ClinicId = attendantId
                                        .ClinicApprovalDate = dbHealth.GetServerDate
                                        .ClinicRemarks = txtDiagnosis.Text.Trim
                                        .IsLateFiling = 1
                                        .LeaveTypeId = cmbLeaveType.SelectedValue
                                        .ModifiedBy = attendantId
                                        .ModifiedDate = dbHealth.GetServerDate
                                        .IsEncoded = False
                                        .IsDone = False

                                        .SuperiorIsApproved1 = 0
                                        .SetSuperiorApprovalDate1Null()
                                        .SetSuperiorRemarks1Null()

                                        .SuperiorIsApproved2 = 0
                                        .SetSuperiorApprovalDate2Null()
                                        .SetSuperiorRemarks2Null()

                                        .ManagerIsApproved = 0
                                        .SetManagerApprovalDateNull()
                                        .SetManagerRemarksNull()

                                        Dim prmCountRecipient(2) As SqlParameter
                                        prmCountRecipient(0) = New SqlParameter("@DepartmentId", SqlDbType.Int)
                                        prmCountRecipient(0).Value = departmentId
                                        prmCountRecipient(1) = New SqlParameter("@TeamId", SqlDbType.Int)
                                        prmCountRecipient(1).Value = teamId
                                        prmCountRecipient(2) = New SqlParameter("PositionId", SqlDbType.Int)
                                        prmCountRecipient(2).Value = positionId

                                        'check if automatic filing has recipient
                                        Dim count As Integer = dbHealth.ExecuteScalar("SELECT COUNT(RecipientId) AS Count FROM dbo.Recipient WHERE DepartmentId = @DepartmentId " &
                                                                                      "AND TeamId = @TeamId And PositionId = @PositionId ", CommandType.Text, prmCountRecipient)

                                        If count = 0 Then 'inform the developer regarding automatic filing with no recipients
                                            frmMain.SendEmailDeveloper(employeeId, txtEmployeeName.Text.ToString.Trim, cmbLeaveType.SelectedValue,
                                                                       cmbLeaveType.Text, departmentId, departmentName, teamId, teamName, positionId, positionName)
                                            'set the last approver based on the majority of other records per department
                                            Dim managerId As Integer = 0
                                            Dim prmDeptId(0) As SqlParameter
                                            prmDeptId(0) = New SqlParameter("@DepartmentId", SqlDbType.Int)
                                            prmDeptId(0).Value = departmentId

                                            managerId = dbHealth.ExecuteScalar("SELECT TOP 1 ManagerId FROM dbo.Recipient " &
                                                                           "WHERE DepartmentId = @DepartmentId GROUP BY ManagerId " &
                                                                           "ORDER BY COUNT(RecipientId) DESC",
                                                                           CommandType.Text, prmDeptId)

                                            If employeeId = managerId Then 'employee is a manager, set dgm as the approver
                                                .ManagerId = 70
                                            Else
                                                .ManagerId = managerId
                                            End If

                                            .RoutingStatusId = 3
                                        Else
                                            Dim prmRecipient(2) As SqlParameter
                                            prmRecipient(0) = New SqlParameter("@DepartmentId", SqlDbType.Int)
                                            prmRecipient(0).Value = departmentId
                                            prmRecipient(1) = New SqlParameter("@TeamId", SqlDbType.Int)
                                            prmRecipient(1).Value = teamId
                                            prmRecipient(2) = New SqlParameter("PositionId", SqlDbType.Int)
                                            prmRecipient(2).Value = positionId

                                            Using rdrRecipient As IDataReader = dbHealth.ExecuteReader("RdRecipient", CommandType.StoredProcedure, prmRecipient)
                                                While rdrRecipient.Read
                                                    If rdrRecipient.Item("SuperiorId1") Is DBNull.Value Then 'no superior 1
                                                        .SetSuperiorId1Null()

                                                        If rdrRecipient.Item("SuperiorId2") Is DBNull.Value Then
                                                            .SetSuperiorId2Null()

                                                            If employeeId = rdrRecipient.Item("ManagerId") Then 'employee is a manager, set dgm as the approver
                                                                .RoutingStatusId = 3
                                                                .ManagerId = 70 'dgm
                                                            Else
                                                                .RoutingStatusId = 3
                                                                .ManagerId = rdrRecipient.Item("ManagerId")
                                                            End If
                                                        Else
                                                            If employeeId = rdrRecipient.Item("SuperiorId2") Then
                                                                .RoutingStatusId = 3
                                                                .SetSuperiorId2Null()
                                                            Else
                                                                .RoutingStatusId = 4
                                                                .SuperiorId2 = rdrRecipient.Item("SuperiorId2")
                                                            End If
                                                        End If
                                                    Else 'with superior 1
                                                        If employeeId = rdrRecipient.Item("SuperiorId1") Then
                                                            .RoutingStatusId = 4
                                                            .SetSuperiorId1Null()
                                                        Else
                                                            .RoutingStatusId = 5
                                                            .SuperiorId1 = rdrRecipient.Item("SuperiorId1")
                                                        End If

                                                        If rdrRecipient.Item("SuperiorId2") Is DBNull.Value Then
                                                            .SetSuperiorId2Null()
                                                        Else
                                                            .SuperiorId2 = rdrRecipient.Item("SuperiorId2")
                                                        End If
                                                    End If

                                                    .ManagerId = rdrRecipient.Item("ManagerId")
                                                End While
                                                rdrRecipient.Close()
                                            End Using
                                        End If

                                        If .RoutingStatusId = 3 Then
                                            If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                           .ManagerId,
                                                                           cmbLeaveType.Text,
                                                                           StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                           departmentName,
                                                                           CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                           txtReason.Text.Trim)
                                            Else
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                           .ManagerId,
                                                                           cmbLeaveType.Text,
                                                                           StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase), departmentName,
                                                                           CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                           CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                           txtReason.Text.Trim)
                                            End If
                                        ElseIf .RoutingStatusId = 4 Then
                                            If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                           .SuperiorId2,
                                                                           cmbLeaveType.Text,
                                                                           StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                           departmentName,
                                                                           CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                           txtReason.Text.Trim)
                                            Else
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                           .SuperiorId2,
                                                                           cmbLeaveType.Text,
                                                                           StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                           departmentName,
                                                                           CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                           CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                           txtReason.Text.Trim)
                                            End If
                                        ElseIf .RoutingStatusId = 5 Then
                                            If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                           .SuperiorId1,
                                                                           cmbLeaveType.Text,
                                                                           StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                           departmentName,
                                                                           CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                           txtReason.Text.Trim)
                                            Else
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                           .SuperiorId1,
                                                                           cmbLeaveType.Text,
                                                                           StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                           departmentName,
                                                                           CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                           CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                           txtReason.Text.Trim)
                                            End If
                                        End If
                                    End With
                                End If
                            Else 'other leave types
                                With rowScreening
                                    .ModifiedBy = attendantId
                                    .ModifiedDate = dbHealth.GetServerDate

                                    If employeeId = 0 Then
                                        .SetEmployeeIdNull() 'agency
                                    Else
                                        .EmployeeId = employeeId 'direct
                                    End If

                                    .AbsentFrom = CDate(txtAbsentFrom.Text)
                                    .AbsentTo = CDate(txtAbsentTo.Text)
                                    .Quantity = GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text))
                                    .LeaveTypeId = cmbLeaveType.SelectedValue
                                    .Reason = txtReason.Text.Trim
                                    .Diagnosis = txtDiagnosis.Text.Trim

                                    If cmbLeaveType.SelectedValue = 12 Then 'half-day leave
                                        .Quantity = 0.5
                                        .LeaveTypeId = 12
                                    Else
                                        .Quantity = GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text))
                                        .LeaveTypeId = cmbLeaveType.SelectedValue
                                    End If

                                    If isUnfitToWork = True Then
                                        .IsFitToWork = False
                                    Else
                                        .IsFitToWork = True
                                    End If
                                End With

                                If employeeId <> 0 Then
                                    Me.adpLeaveFiling.FillByLeaveFileId(Me.dsHealth.LeaveFiling, leaveFileId)
                                    Dim leaveFilingRow As LeaveFilingRow = Me.dsHealth.LeaveFiling.FindByLeaveFileId(leaveFileId)

                                    With leaveFilingRow
                                        .ScreenId = screenId
                                        .StartDate = CDate(txtAbsentFrom.Text)
                                        .EndDate = CDate(txtAbsentTo.Text)
                                        .Quantity = GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text))
                                        .Reason = txtReason.Text.Trim
                                        .LeaveCredits = GetLeaveCredits(employeeId)
                                        .LeaveBalance = GetLeaveBalance(employeeId)
                                        .ClinicIsApproved = True
                                        .ClinicId = attendantId
                                        .ClinicApprovalDate = dbHealth.GetServerDate
                                        .ClinicRemarks = txtDiagnosis.Text.Trim
                                        .IsLateFiling = 1
                                        .LeaveTypeId = cmbLeaveType.SelectedValue
                                        .ModifiedBy = attendantId
                                        .ModifiedDate = dbHealth.GetServerDate
                                        .IsEncoded = False
                                        .IsDone = False

                                        If .RoutingStatusId = 3 Then
                                            If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                       .ManagerId,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                            Else
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                       .ManagerId,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                       CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                            End If
                                        ElseIf .RoutingStatusId = 4 Then
                                            If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                       .SuperiorId2,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                            Else
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                       .SuperiorId2,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                       CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                            End If
                                        ElseIf .RoutingStatusId = 5 Then
                                            If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                       .SuperiorId1,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                            Else
                                                frmMain.SendEmailApprovers(.LeaveFileId,
                                                                       .SuperiorId1,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                       CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                            End If
                                        End If
                                    End With
                                End If
                            End If
                        Else
                            Return
                        End If
                    Else
                        'no duplicate record in leave filing (exact date)
                        'check if has duplicate record in leave filing (date range) i.e. date selected is overlapped or in-between of existing leave
                        Dim prmCountDate(6) As SqlParameter
                        prmCountDate(0) = New SqlParameter("@LeaveFileId", SqlDbType.Int)
                        prmCountDate(0).Value = Nothing
                        prmCountDate(1) = New SqlParameter("@ScreenId", SqlDbType.Int)
                        prmCountDate(1).Value = screenId
                        prmCountDate(2) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                        prmCountDate(2).Value = employeeId
                        prmCountDate(3) = New SqlParameter("@StartDate", SqlDbType.Date)
                        prmCountDate(3).Value = CDate(txtAbsentFrom.Text)
                        prmCountDate(4) = New SqlParameter("@EndDate", SqlDbType.Date)
                        prmCountDate(4).Value = CDate(txtAbsentTo.Text)
                        prmCountDate(5) = New SqlParameter("TotalLeaveFileId", SqlDbType.Int)
                        prmCountDate(5).Direction = ParameterDirection.Output
                        prmCountDate(6) = New SqlParameter("TotalScreenId", SqlDbType.Int)
                        prmCountDate(6).Direction = ParameterDirection.Output

                        dbHealth.ExecuteScalar("CntLeaveFilingDateRange", CommandType.StoredProcedure, prmCountDate)

                        If prmCountDate(5).Value > 0 Then 'has duplicate entry in leave filing, do not allow
                            Dim rdrDateExact(2) As SqlParameter
                            rdrDateExact(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                            rdrDateExact(0).Value = employeeId
                            rdrDateExact(1) = New SqlParameter("@StartDate", SqlDbType.Date)
                            rdrDateExact(1).Value = CDate(txtAbsentFrom.Text)
                            rdrDateExact(2) = New SqlParameter("@EndDate", SqlDbType.Date)
                            rdrDateExact(2).Value = CDate(txtAbsentTo.Text)

                            Dim leaveFileId As Integer = 0
                            Dim startDate As Date = Nothing
                            Dim endDate As Date = Nothing
                            Dim question As String = String.Empty

                            'get the dates of existing leave (date range)
                            Using rdrDate As IDataReader = dbHealth.ExecuteReader("RdLeaveFilingByLeaveDate", CommandType.StoredProcedure, rdrDateExact)
                                While rdrDate.Read
                                    leaveFileId = rdrDate.Item("LeaveFileId")
                                    startDate = CDate(rdrDate.Item("StartDate"))
                                    endDate = CDate(rdrDate.Item("EndDate"))
                                End While
                                rdrDate.Close()
                            End Using

                            If startDate.Equals(endDate) Then
                                MessageBox.Show("Employee has existing leave dated {0}.", startDate.ToString("MMM dd, yyyy"))
                            Else
                                MessageBox.Show(String.Format("Employee has existing leave dated from {0} to {1}.", startDate.ToString("MMM dd, yyyy"),
                                                endDate.ToString("MMM dd, yyyy")))
                            End If
                        Else 'no existing leave (leave filing), save record
                            If cmbLeaveType.SelectedValue = 9 Or cmbLeaveType.SelectedValue = 14 Then
                                'direct - save to screening, automatic filing in leave application
                                'agency - save to screening only
                                With rowScreening
                                    .ModifiedBy = attendantId
                                    .ModifiedDate = dbHealth.GetServerDate

                                    If employeeId = 0 Then
                                        .SetEmployeeIdNull() 'agency
                                    Else
                                        .EmployeeId = employeeId 'direct
                                    End If

                                    .AbsentFrom = CDate(txtAbsentFrom.Text)
                                    .AbsentTo = CDate(txtAbsentTo.Text)
                                    .Quantity = GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text))
                                    .LeaveTypeId = cmbLeaveType.SelectedValue
                                    .Reason = txtReason.Text.Trim
                                    .Diagnosis = txtDiagnosis.Text.Trim

                                    If cmbLeaveType.SelectedValue = 14 Then 'ecq - quarantine
                                        .IsFitToWork = False
                                    Else
                                        If isUnfitToWork = True Then
                                            .IsFitToWork = False
                                        Else
                                            .IsFitToWork = True
                                        End If
                                    End If
                                End With

                                If employeeId <> 0 Then
                                    Dim newRowLeaveFiling As LeaveFilingRow = Me.dsHealth.LeaveFiling.NewLeaveFilingRow

                                    With newRowLeaveFiling
                                        .DateCreated = dbHealth.GetServerDate
                                        .ScreenId = screenId
                                        .EmployeeId = employeeId
                                        .DepartmentId = departmentId
                                        .TeamId = teamId
                                        .StartDate = CDate(txtAbsentFrom.Text)
                                        .EndDate = CDate(txtAbsentTo.Text)
                                        .Quantity = GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text))
                                        .Reason = txtReason.Text.Trim
                                        .LeaveCredits = GetLeaveCredits(employeeId)
                                        .LeaveBalance = GetLeaveBalance(employeeId)
                                        .ClinicIsApproved = 1
                                        .ClinicId = attendantId
                                        .ClinicApprovalDate = dbHealth.GetServerDate
                                        .ClinicRemarks = txtDiagnosis.Text.Trim
                                        .IsLateFiling = 1
                                        .LeaveTypeId = cmbLeaveType.SelectedValue
                                        .SetModifiedByNull()
                                        .SetModifiedDateNull()
                                        .IsEncoded = 0
                                        .IsDone = 0

                                        .SuperiorIsApproved1 = 0
                                        .SetSuperiorApprovalDate1Null()
                                        .SetSuperiorRemarks1Null()

                                        .SuperiorIsApproved2 = 0
                                        .SetSuperiorApprovalDate2Null()
                                        .SetSuperiorRemarks2Null()

                                        .ManagerIsApproved = 0
                                        .SetManagerApprovalDateNull()
                                        .SetManagerRemarksNull()

                                        Dim prmCountRecipient(2) As SqlParameter
                                        prmCountRecipient(0) = New SqlParameter("@DepartmentId", SqlDbType.Int)
                                        prmCountRecipient(0).Value = departmentId
                                        prmCountRecipient(1) = New SqlParameter("@TeamId", SqlDbType.Int)
                                        prmCountRecipient(1).Value = teamId
                                        prmCountRecipient(2) = New SqlParameter("PositionId", SqlDbType.Int)
                                        prmCountRecipient(2).Value = positionId

                                        Dim count As Integer = dbHealth.ExecuteScalar("SELECT COUNT(RecipientId) AS Count FROM dbo.Recipient WHERE DepartmentId = @DepartmentId " &
                                                                                      "AND TeamId = @TeamId And PositionId = @PositionId ", CommandType.Text, prmCountRecipient)

                                        If count = 0 Then 'inform the developer regarding automatic filing with no recipients
                                            frmMain.SendEmailDeveloper(employeeId, txtEmployeeName.Text.ToString.Trim, cmbLeaveType.SelectedValue,
                                                               cmbLeaveType.Text, departmentId, departmentName, teamId, teamName, positionId, positionName)
                                            'set the last approver based on the majority of other records per department
                                            Dim managerId As Integer = 0
                                            Dim prmDeptId(0) As SqlParameter
                                            prmDeptId(0) = New SqlParameter("@DepartmentId", SqlDbType.Int)
                                            prmDeptId(0).Value = departmentId

                                            managerId = dbHealth.ExecuteScalar("SELECT TOP 1 ManagerId FROM dbo.Recipient " &
                                                                               "WHERE DepartmentId = @DepartmentId GROUP BY ManagerId " &
                                                                               "ORDER BY COUNT(RecipientId) DESC",
                                                                               CommandType.Text, prmDeptId)

                                            If employeeId = managerId Then 'employee is a manager, set dgm as the approver
                                                .ManagerId = 70
                                            Else
                                                .ManagerId = managerId
                                            End If

                                            .RoutingStatusId = 3
                                        Else
                                            Dim prmRecipient(2) As SqlParameter
                                            prmRecipient(0) = New SqlParameter("@DepartmentId", SqlDbType.Int)
                                            prmRecipient(0).Value = departmentId
                                            prmRecipient(1) = New SqlParameter("@TeamId", SqlDbType.Int)
                                            prmRecipient(1).Value = teamId
                                            prmRecipient(2) = New SqlParameter("PositionId", SqlDbType.Int)
                                            prmRecipient(2).Value = positionId

                                            Using readerRecipient As IDataReader = dbHealth.ExecuteReader("RdRecipient", CommandType.StoredProcedure, prmRecipient)
                                                Dim superiorId1 As Integer = 0
                                                Dim superiorId2 As Integer = 0
                                                Dim managerId As Integer = 0

                                                While readerRecipient.Read
                                                    If readerRecipient.Item("SuperiorId1") Is DBNull.Value Then 'no superior 1
                                                        .SetSuperiorId1Null()

                                                        If readerRecipient.Item("SuperiorId2") Is DBNull.Value Then
                                                            .SetSuperiorId2Null()

                                                            If employeeId = readerRecipient.Item("ManagerId") Then 'employee is a manager, set dgm as the approver
                                                                .RoutingStatusId = 3
                                                                .ManagerId = 70 'dgm
                                                            Else
                                                                .RoutingStatusId = 3
                                                                .ManagerId = readerRecipient.Item("ManagerId")
                                                            End If
                                                        Else
                                                            If employeeId = readerRecipient.Item("SuperiorId2") Then
                                                                .RoutingStatusId = 3
                                                                .SetSuperiorId2Null()
                                                            Else
                                                                .RoutingStatusId = 4
                                                                .SuperiorId2 = readerRecipient.Item("SuperiorId2")
                                                            End If
                                                        End If

                                                    Else 'with superior 1
                                                        If employeeId = readerRecipient.Item("SuperiorId1") Then
                                                            .RoutingStatusId = 4
                                                            .SetSuperiorId1Null()
                                                        Else
                                                            .RoutingStatusId = 5
                                                            .SuperiorId1 = readerRecipient.Item("SuperiorId1")
                                                        End If

                                                        If readerRecipient.Item("SuperiorId2") Is DBNull.Value Then
                                                            .SetSuperiorId2Null()
                                                        Else
                                                            .SuperiorId2 = readerRecipient.Item("SuperiorId2")
                                                        End If
                                                    End If

                                                    .ManagerId = readerRecipient.Item("ManagerId")
                                                    managerId = readerRecipient.Item("ManagerId")
                                                End While
                                                readerRecipient.Close()
                                            End Using
                                        End If
                                    End With
                                    Me.dsHealth.LeaveFiling.AddLeaveFilingRow(newRowLeaveFiling)
                                    Me.adpLeaveFiling.Update(Me.dsHealth.LeaveFiling)

                                    If newRowLeaveFiling.RoutingStatusId = 3 Then
                                        If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.ManagerId,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        Else
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.ManagerId,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                       CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        End If
                                    ElseIf newRowLeaveFiling.RoutingStatusId = 4 Then
                                        If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.SuperiorId2,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        Else
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.SuperiorId2,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                       CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        End If
                                    ElseIf newRowLeaveFiling.RoutingStatusId = 5 Then
                                        If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.SuperiorId1,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        Else
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.SuperiorId1,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                       CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        End If
                                    End If
                                End If
                            Else 'other leave types
                                With rowScreening
                                    .ModifiedBy = attendantId
                                    .ModifiedDate = dbHealth.GetServerDate

                                    If employeeId = 0 Then
                                        .SetEmployeeIdNull() 'agency
                                    Else
                                        .EmployeeId = employeeId 'direct
                                    End If

                                    .AbsentFrom = CDate(txtAbsentFrom.Text)
                                    .AbsentTo = CDate(txtAbsentTo.Text)
                                    .Quantity = GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text))
                                    .LeaveTypeId = cmbLeaveType.SelectedValue
                                    .Reason = txtReason.Text.Trim
                                    .Diagnosis = txtDiagnosis.Text.Trim

                                    If cmbLeaveType.SelectedValue = 12 Then 'half-day leave
                                        .Quantity = 0.5
                                        .LeaveTypeId = 12
                                    Else
                                        .Quantity = GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text))
                                        .LeaveTypeId = cmbLeaveType.SelectedValue
                                    End If

                                    If isUnfitToWork = True Then
                                        .IsFitToWork = False
                                    Else
                                        .IsFitToWork = True
                                    End If
                                End With

                                If employeeId <> 0 Then
                                    Dim newRowLeaveFiling As LeaveFilingRow = Me.dsHealth.LeaveFiling.NewLeaveFilingRow

                                    With newRowLeaveFiling
                                        .DateCreated = dbHealth.GetServerDate
                                        .ScreenId = screenId
                                        .EmployeeId = employeeId
                                        .DepartmentId = departmentId
                                        .TeamId = teamId
                                        .StartDate = CDate(txtAbsentFrom.Text)
                                        .EndDate = CDate(txtAbsentTo.Text)
                                        .Quantity = GetTotalDays(CDate(txtAbsentFrom.Text), CDate(txtAbsentTo.Text))
                                        .Reason = txtReason.Text.Trim
                                        .LeaveCredits = GetLeaveCredits(employeeId)
                                        .LeaveBalance = GetLeaveBalance(employeeId)
                                        .ClinicIsApproved = 1
                                        .ClinicId = attendantId
                                        .ClinicApprovalDate = dbHealth.GetServerDate
                                        .ClinicRemarks = txtDiagnosis.Text.Trim
                                        .IsLateFiling = 1
                                        .LeaveTypeId = cmbLeaveType.SelectedValue
                                        .SetModifiedByNull()
                                        .SetModifiedDateNull()
                                        .IsEncoded = 0
                                        .IsDone = 0

                                        .SuperiorIsApproved1 = 0
                                        .SetSuperiorApprovalDate1Null()
                                        .SetSuperiorRemarks1Null()

                                        .SuperiorIsApproved2 = 0
                                        .SetSuperiorApprovalDate2Null()
                                        .SetSuperiorRemarks2Null()

                                        .ManagerIsApproved = 0
                                        .SetManagerApprovalDateNull()
                                        .SetManagerRemarksNull()

                                        Dim prmCountRecipient(2) As SqlParameter
                                        prmCountRecipient(0) = New SqlParameter("@DepartmentId", SqlDbType.Int)
                                        prmCountRecipient(0).Value = departmentId
                                        prmCountRecipient(1) = New SqlParameter("@TeamId", SqlDbType.Int)
                                        prmCountRecipient(1).Value = teamId
                                        prmCountRecipient(2) = New SqlParameter("PositionId", SqlDbType.Int)
                                        prmCountRecipient(2).Value = positionId

                                        Dim count As Integer = dbHealth.ExecuteScalar("SELECT COUNT(RecipientId) AS Count FROM dbo.Recipient WHERE DepartmentId = @DepartmentId " &
                                                                                      "AND TeamId = @TeamId And PositionId = @PositionId ", CommandType.Text, prmCountRecipient)

                                        If count = 0 Then 'inform the developer regarding automatic filing with no recipients
                                            frmMain.SendEmailDeveloper(employeeId, txtEmployeeName.Text.ToString.Trim, cmbLeaveType.SelectedValue,
                                                               cmbLeaveType.Text, departmentId, departmentName, teamId, teamName, positionId, positionName)
                                            'set the last approver based on the majority of other records per department
                                            Dim managerId As Integer = 0
                                            Dim prmDeptId(0) As SqlParameter
                                            prmDeptId(0) = New SqlParameter("@DepartmentId", SqlDbType.Int)
                                            prmDeptId(0).Value = departmentId

                                            managerId = dbHealth.ExecuteScalar("SELECT TOP 1 ManagerId FROM dbo.Recipient " &
                                                                               "WHERE DepartmentId = @DepartmentId GROUP BY ManagerId " &
                                                                               "ORDER BY COUNT(RecipientId) DESC",
                                                                               CommandType.Text, prmDeptId)

                                            If employeeId = managerId Then 'employee is a manager, set dgm as the approver
                                                .ManagerId = 70
                                            Else
                                                .ManagerId = managerId
                                            End If

                                            .RoutingStatusId = 3
                                        Else
                                            Dim prmRecipient(2) As SqlParameter
                                            prmRecipient(0) = New SqlParameter("@DepartmentId", SqlDbType.Int)
                                            prmRecipient(0).Value = departmentId
                                            prmRecipient(1) = New SqlParameter("@TeamId", SqlDbType.Int)
                                            prmRecipient(1).Value = teamId
                                            prmRecipient(2) = New SqlParameter("PositionId", SqlDbType.Int)
                                            prmRecipient(2).Value = positionId

                                            Using readerRecipient As IDataReader = dbHealth.ExecuteReader("RdRecipient", CommandType.StoredProcedure, prmRecipient)
                                                Dim superiorId1 As Integer = 0
                                                Dim superiorId2 As Integer = 0
                                                Dim managerId As Integer = 0

                                                While readerRecipient.Read
                                                    If readerRecipient.Item("SuperiorId1") Is DBNull.Value Then 'no superior 1
                                                        .SetSuperiorId1Null()

                                                        If readerRecipient.Item("SuperiorId2") Is DBNull.Value Then
                                                            .SetSuperiorId2Null()

                                                            If employeeId = readerRecipient.Item("ManagerId") Then 'employee is a manager, set dgm as the approver
                                                                .RoutingStatusId = 3
                                                                .ManagerId = 70 'dgm
                                                            Else
                                                                .RoutingStatusId = 3
                                                                .ManagerId = readerRecipient.Item("ManagerId")
                                                            End If
                                                        Else
                                                            If employeeId = readerRecipient.Item("SuperiorId2") Then
                                                                .RoutingStatusId = 3
                                                                .SetSuperiorId2Null()
                                                            Else
                                                                .RoutingStatusId = 4
                                                                .SuperiorId2 = readerRecipient.Item("SuperiorId2")
                                                            End If
                                                        End If

                                                    Else 'with superior 1
                                                        If employeeId = readerRecipient.Item("SuperiorId1") Then
                                                            .RoutingStatusId = 4
                                                            .SetSuperiorId1Null()
                                                        Else
                                                            .RoutingStatusId = 5
                                                            .SuperiorId1 = readerRecipient.Item("SuperiorId1")
                                                        End If

                                                        If readerRecipient.Item("SuperiorId2") Is DBNull.Value Then
                                                            .SetSuperiorId2Null()
                                                        Else
                                                            .SuperiorId2 = readerRecipient.Item("SuperiorId2")
                                                        End If
                                                    End If

                                                    .ManagerId = readerRecipient.Item("ManagerId")
                                                    managerId = readerRecipient.Item("ManagerId")
                                                End While
                                                readerRecipient.Close()
                                            End Using
                                        End If
                                    End With
                                    Me.dsHealth.LeaveFiling.AddLeaveFilingRow(newRowLeaveFiling)
                                    Me.adpLeaveFiling.Update(Me.dsHealth.LeaveFiling)

                                    If newRowLeaveFiling.RoutingStatusId = 3 Then
                                        If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.ManagerId,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        Else
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.ManagerId,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                       CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        End If
                                    ElseIf newRowLeaveFiling.RoutingStatusId = 4 Then
                                        If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.SuperiorId2,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        Else
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.SuperiorId2,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                       CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        End If
                                    ElseIf newRowLeaveFiling.RoutingStatusId = 5 Then
                                        If CDate(txtAbsentFrom.Text).Date.Equals(CDate(txtAbsentTo.Text).Date) Then
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.SuperiorId1,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        Else
                                            frmMain.SendEmailApprovers(newRowLeaveFiling.LeaveFileId,
                                                                       newRowLeaveFiling.SuperiorId1,
                                                                       cmbLeaveType.Text,
                                                                       StrConv(txtEmployeeName.Text.Trim, VbStrConv.ProperCase),
                                                                       departmentName,
                                                                       CDate(txtAbsentFrom.Text).Date.ToString("MMMM dd, yyyy") & " - " &
                                                                       CDate(txtAbsentTo.Text).Date.ToString("MMMM dd, yyyy"),
                                                                       txtReason.Text.Trim)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                Me.Validate()
                Me.bsScreening.EndEdit()
                Me.bsLeaveFiling.EndEdit()

                If Me.dsHealth.HasChanges Then
                    Me.adpScreening.Update(Me.dsHealth.Screening)
                    Me.adpLeaveFiling.Update(Me.dsHealth.LeaveFiling)
                    Me.dsHealth.AcceptChanges()
                    Me.DialogResult = DialogResult.OK
                End If

            End If

            employeeId = 0
            departmentId = 0
            teamId = 0
            positionId = 0
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetEmployeeInformation(employeeCode As String)
        Try
            Dim count As Integer = 0
            Dim prmCount(0) As SqlParameter
            prmCount(0) = New SqlParameter("@EmployeeCode", SqlDbType.VarChar)
            prmCount(0).Value = employeeCode

            count = dbJeonsoft.ExecuteScalar("SELECT Count(Id) FROM viwGroupEmployees WHERE EmployeeCode = @EmployeeCode AND Active = 1", CommandType.Text, prmCount)

            If count > 0 Then 'direct employee
                Dim prmReader(0) As SqlParameter
                prmReader(0) = New SqlParameter("@EmployeeCode", SqlDbType.VarChar)
                prmReader(0).Value = employeeCode

                Using reader As IDataReader = dbHealth.ExecuteReader("RdEmployee", CommandType.StoredProcedure, prmReader)
                    While reader.Read
                        employeeId = reader.Item("Id")
                        departmentId = reader.Item("DepartmentId")
                        departmentName = reader.Item("DepartmentName")
                        positionId = reader.Item("PositionId")
                        positionName = reader.Item("PositionName")
                        txtEmployeeCode.Text = reader.Item("EmployeeCode").ToString.Trim
                        txtEmployeeName.Text = StrConv(reader("EmployeeName").ToString.Trim, VbStrConv.ProperCase)

                        If reader.Item("TeamId") Is DBNull.Value Then
                            teamId = 0
                            teamName = String.Empty
                        Else
                            teamId = reader.Item("TeamId")
                            teamName = reader.Item("TeamName").ToString.Trim
                        End If
                    End While
                    reader.Close()
                End Using

                cmbLeaveType.SelectedValue = 1
                cmbLeaveType.Enabled = True

                txtEmployeeScanId.Clear()
                txtEmployeeScanId.Enabled = False
                txtEmployeeName.Enabled = True
                txtEmployeeName.ReadOnly = True

                Dim prmEmployee(0) As SqlParameter
                prmEmployee(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                prmEmployee(0).Value = attendantId
                txtCreatedBy.Text = StrConv(dbHealth.ExecuteScalar("SELECT TRIM(EmployeeName) AS EmployeeName FROM VwClinic WHERE EmployeeId = @EmployeeId",
                                                                   CommandType.Text, prmEmployee), VbStrConv.ProperCase)

                txtCreatedDate.Text = Format(dbHealth.GetServerDate, "MMMM dd, yyyy HH:mm tt")

                txtAbsentFrom.Enabled = True
                txtAbsentFrom.ReadOnly = False
                txtAbsentTo.Enabled = True
                txtAbsentTo.ReadOnly = False
                txtReason.Enabled = True
                txtReason.ReadOnly = False
                txtDiagnosis.Enabled = True
                txtDiagnosis.ReadOnly = False
                chkNotFtw.Enabled = True

                Me.ActiveControl = txtReason

            Else 'agency employee (fmb)
                If employeeCode.Substring(0, 3).ToUpper.Trim.Equals("FMB") Then
                    employeeId = 0

                    cmbLeaveType.SelectedValue = 1
                    cmbLeaveType.Enabled = True

                    txtEmployeeScanId.Clear()
                    txtEmployeeScanId.Enabled = False
                    txtEmployeeCode.Text = employeeCode
                    txtEmployeeCode.Text = StrConv(txtEmployeeCode.Text.Trim, VbStrConv.Uppercase)
                    txtEmployeeName.Enabled = True
                    txtEmployeeName.ReadOnly = False

                    Dim prmEmployee(0) As SqlParameter
                    prmEmployee(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                    prmEmployee(0).Value = attendantId
                    txtCreatedBy.Text = StrConv(dbHealth.ExecuteScalar("SELECT TRIM(EmployeeName) AS EmployeeName FROM VwClinic WHERE EmployeeId = @EmployeeId",
                                                                       CommandType.Text, prmEmployee), VbStrConv.ProperCase)

                    txtCreatedDate.Text = Format(dbHealth.GetServerDate, "MMMM dd, yyyy HH:mm")

                    txtAbsentFrom.Enabled = True
                    txtAbsentFrom.ReadOnly = False
                    txtAbsentTo.Enabled = True
                    txtAbsentTo.ReadOnly = False
                    txtReason.Enabled = True
                    txtReason.ReadOnly = False
                    txtDiagnosis.Enabled = True
                    txtDiagnosis.ReadOnly = False
                    chkNotFtw.Enabled = True

                    Me.ActiveControl = txtReason
                Else
                    MessageBox.Show("Employee not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtEmployeeScanId.Focus()
                    Return
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetForm()
        screenId = 0
        employeeId = 0
        departmentId = 0
        teamId = 0
        positionId = 0

        Me.Text = "New Record"
        txtEmployeeScanId.Enabled = True
        txtEmployeeScanId.Clear()
        txtEmployeeCode.Text = ""
        txtEmployeeName.Clear()
        txtEmployeeName.Enabled = False

        txtCreatedDate.Text = ""
        txtCreatedBy.Text = ""
        txtModifiedDate.Text = ""
        txtModifiedBy.Text = ""

        cmbLeaveType.Enabled = False
        cmbLeaveType.SelectedValue = 0

        txtAbsentFrom.Enabled = False
        txtAbsentFrom.Text = String.Format("{0:MM/dd/yyyy}", GetLastWorkingDay(dbHealth.GetServerDate))
        txtAbsentFrom.ValidatingType = GetType(System.DateTime)
        txtAbsentTo.Enabled = False
        txtAbsentTo.Text = String.Format("{0:MM/dd/yyyy}", GetLastWorkingDay(dbHealth.GetServerDate))
        txtAbsentTo.ValidatingType = GetType(System.DateTime)

        txtReason.Clear()
        txtReason.Enabled = False
        txtDiagnosis.Clear()
        txtDiagnosis.Enabled = False

        chkNotFtw.Enabled = False
        chkNotFtw.CheckState = CheckState.Unchecked

        If HealthInformationSystem.My.MySettings.Default.IsDebug = True Then
            txtEmployeeScanId.Text = "2009-002"
        End If

        btnDelete.Enabled = False

        Me.Focus()
        Me.Activate()
        Me.ActiveControl = txtEmployeeScanId
    End Sub

    Private Sub maskedFrom_Format(sender As Object, e As ConvertEventArgs) Handles absentFrom.Format
        e.Value = Format(e.Value, "MM/dd/yyyy")
    End Sub

    Private Sub maskedTo_Format(sender As Object, e As ConvertEventArgs) Handles absentTo.Format
        e.Value = Format(e.Value, "MM/dd/yyyy")
    End Sub

    Private Sub txtAbsentFrom_TypeValidationCompleted(sender As Object, e As TypeValidationEventArgs) Handles txtAbsentFrom.TypeValidationCompleted
        If (Not e.IsValidInput) Then
            SendKeys.Send("{End}")
            MessageBox.Show("Please input date in Month/Day/Year format.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtAbsentTo_TypeValidationCompleted(sender As Object, e As TypeValidationEventArgs) Handles txtAbsentTo.TypeValidationCompleted
        If (Not e.IsValidInput) Then
            SendKeys.Send("{End}")
            MessageBox.Show("Please input date in Month/Day/Year format.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub lblNotFtw_Click(sender As Object, e As EventArgs) Handles lblNotFtw.Click
        If chkNotFtw.Enabled = True Then
            If chkNotFtw.CheckState = CheckState.Checked Then
                chkNotFtw.Checked = False
            Else
                chkNotFtw.Checked = True
            End If
        End If
    End Sub

    'set the absent date to the last working date - excluding sunday, company holidays and legal holidays
    Private Function GetLastWorkingDay(subjectDate As DateTime) As Date
        Try
            subjectDate = subjectDate.AddDays(-1)
            While IsHoliday(subjectDate) Or IsWeekend(subjectDate)
                subjectDate = subjectDate.AddDays(-1)
            End While
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return subjectDate
    End Function

    Private Function IsWeekend(subjectDate As Date) As Boolean
        If subjectDate.DayOfWeek.Equals(DayOfWeek.Sunday) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function IsHoliday(subjectDate As Date) As Boolean
        Dim count As Integer

        Try
            Dim prmHoliday(0) As SqlParameter
            prmHoliday(0) = New SqlParameter("@HolidayDate", SqlDbType.Date)
            prmHoliday(0).Value = subjectDate.ToShortDateString
            count = 0
            count = dbHealth.ExecuteScalar("SELECT COUNT(HolidayId) FROM dbo.Holiday WHERE HolidayDate = @HolidayDate", CommandType.Text, prmHoliday)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    'get the total number of days from start date up to end date - excluding holidays and sundays
    Private Function GetTotalDays(startDate As Date, endDate As Date) As Integer
        Dim count As Integer = 0

        Try
            If startDate.Date.Equals(endDate.Date) Then
                count = 1
            Else
                For _i As Integer = 0 To (endDate - startDate).Days
                    If Not IsHoliday(startDate) Then
                        If Not IsWeekend(startDate) Then
                            count += 1
                        End If
                    End If
                    startDate = startDate.AddDays(1)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return count
    End Function

    'get leave credits
    Private Function GetLeaveCredits(employeeId As Integer) As Integer
        Dim leaveCredits As Double = 0

        Try
            If Not cmbLeaveType.SelectedValue = 0 Then
                Dim prmCredits(1) As SqlParameter
                prmCredits(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                prmCredits(0).Value = employeeId
                prmCredits(1) = New SqlParameter("@LeaveTypeId", SqlDbType.Int)
                prmCredits(1).Value = cmbLeaveType.SelectedValue

                leaveCredits = dbJeonsoft.ExecuteScalar("SELECT TOP 1 EndBalance FROM dbo.tblLeaveLedger WHERE YEAR(Date) = YEAR(GETDATE()) AND " &
                                                        "EmployeeId = @EmployeeId AND LeaveTypeId = @LeaveTypeId ORDER BY Date ASC",
                                                        CommandType.Text, prmCredits)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return leaveCredits
    End Function

    'get leave balance
    Private Function GetLeaveBalance(employeeId As Integer) As Integer
        Dim leaveBalance As Double = 0

        Try
            If Not cmbLeaveType.SelectedValue = 0 Then
                Dim prmBalance(3) As SqlParameter
                prmBalance(0) = New SqlParameter("@CompanyId", SqlDbType.Int)
                prmBalance(0).Value = 1
                prmBalance(1) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                prmBalance(1).Value = employeeId
                prmBalance(2) = New SqlParameter("@LeaveTypeId", SqlDbType.Int)
                prmBalance(2).Value = cmbLeaveType.SelectedValue
                prmBalance(3) = New SqlParameter("@Date", SqlDbType.Date)
                prmBalance(3).Value = DBNull.Value

                leaveBalance = dbJeonsoft.ExecuteFunction(Of Double)("dbo.fnGetLeaveBalance", prmBalance)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return leaveBalance
    End Function

End Class