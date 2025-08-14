Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports BlackCoffeeLibrary

Public Class ScreeningLogsheet
    Private connection As New clsConnection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbLeave As New SqlDbMethod(connection.LeaveConnection)
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)

    Private employeeName As String = String.Empty
    Private status As String = String.Empty

    Private dicDateType As New Dictionary(Of String, Integer)
    Private dicEmploymentType As New Dictionary(Of String, Integer)
    Private dicStatus As New Dictionary(Of String, Integer)

    Private dicEmployee As New Dictionary(Of String, String)

    Private agency As String = String.Empty
    Private employee As String = String.Empty

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStatus()
        LoadDateType()
        LoadEmploymentType()
        LoadLeaveType()
        LoadEmployee(0)

        Me.ActiveControl = btnGenerate
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnGenerate.PerformClick()
        End If
    End Sub

    Private Sub LoadDateType()
        Try
            dicDateType.Add("Absent Date", 1)
            dicDateType.Add("Screen Date", 2)
            dicDateType.Add("Medcert Date", 3)

            cmbDateType.DisplayMember = "Key"
            cmbDateType.ValueMember = "Value"
            cmbDateType.DataSource = New BindingSource(dicDateType, Nothing)

            AddHandler cmbDateType.Validating, AddressOf cmbDateType_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadStatus()
        Try
            dicStatus.Add("< All >", 0)
            dicStatus.Add("Fit To Work", 1)
            dicStatus.Add("Unfit To Work", 2)

            cmbStatus.DisplayMember = "Key"
            cmbStatus.ValueMember = "Value"
            cmbStatus.DataSource = New BindingSource(dicStatus, Nothing)

            AddHandler cmbStatus.Validating, AddressOf cmbStatus_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadLeaveType()
        Try
            dbLeave.FillCmbWithCaption("RdLeaveType", CommandType.Text, "LeaveTypeId", "LeaveTypeName", cmbLeaveType, "< Select Leave Type >")

            AddHandler cmbLeaveType.Validating, AddressOf cmbLeaveType_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadEmploymentType()
        Try
            dicEmploymentType.Add("< All >", 0)
            dicEmploymentType.Add("Direct", 1)
            dicEmploymentType.Add("Agency", 2)

            cmbEmploymentType.DisplayMember = "Key"
            cmbEmploymentType.ValueMember = "Value"
            cmbEmploymentType.DataSource = New BindingSource(dicEmploymentType, Nothing)

            AddHandler cmbEmploymentType.Validating, AddressOf cmbEmploymentType_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadEmployee(companyId As Integer)
        Try
            cmbEmployeeName.SelectedValue = 0
            cmbEmployeeName.DataSource = Nothing
            cmbEmployeeName.Items.Clear()

            Select Case companyId
                Case 0
                    dbLeave.FillCmbWithCaption("RdEmployeeAll", CommandType.StoredProcedure, "EmployeeId", "EmployeeName", cmbEmployeeName, "<All>")

                Case 1 ' Nbc employees
                    Dim prmNbc(0) As SqlParameter
                    prmNbc(0) = New SqlParameter("@AgencyId", SqlDbType.Int)
                    prmNbc(0).Value = 99

                    dbLeave.FillCmbWithCaption("RdEmployeeAll", CommandType.StoredProcedure, "EmployeeId", "EmployeeName", cmbEmployeeName, "<All>", prmNbc)

                Case 2 ' Agency employees
                    Dim prmAgency(0) As SqlParameter
                    prmAgency(0) = New SqlParameter("@IsAllAgency", SqlDbType.Int)
                    prmAgency(0).Value = True

                    dbLeave.FillCmbWithCaption("RdEmployeeAll", CommandType.StoredProcedure, "EmployeeId", "EmployeeName", cmbEmployeeName, "<All>", prmAgency)
            End Select

            AddHandler cmbEmploymentType.Validating, AddressOf cmbEmployeeName_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            If dtpStartDate.Value > dtpEndDate.Value Then
                MessageBox.Show("Start datetime is later than end datetime.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf dtpStartDate.Value.Date = dtpEndDate.Value.Date Then
                GenerateReport()
            Else
                GenerateReport()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            cmbDateType.SelectedValue = 1
            dtpStartDate.Value = Convert.ToDateTime(dbLeave.GetServerDate).Date
            dtpEndDate.Value = Convert.ToDateTime(dbLeave.GetServerDate).Date
            dtpEndDate.Value = DateTime.Now
            cmbStatus.SelectedValue = 0
            cmbLeaveType.SelectedValue = 0
            cmbEmploymentType.SelectedValue = 0
            LoadEmployee(cmbEmploymentType.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub GenerateReport()
        Try
            Dim prmRpt(6) As SqlParameter
            prmRpt(0) = New SqlParameter("@AbsentFrom", SqlDbType.Date)
            prmRpt(0).Value = dtpStartDate.Value.Date
            prmRpt(1) = New SqlParameter("@AbsentTo", SqlDbType.Date)
            prmRpt(1).Value = dtpEndDate.Value.Date
            prmRpt(2) = New SqlParameter("@DateType", SqlDbType.Char)
            prmRpt(2).Value = cmbDateType.SelectedValue
            prmRpt(3) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            prmRpt(3).Value = GetEmployee()
            prmRpt(4) = New SqlParameter("@LeaveTypeId", SqlDbType.Int)
            prmRpt(4).Value = GetLeaveType()
            prmRpt(5) = New SqlParameter("@Status", SqlDbType.Int)
            prmRpt(5).Value = GetStatus()
            prmRpt(6) = New SqlParameter("@EmploymentTypeId", SqlDbType.Int)
            prmRpt(6).Value = GetEmploymentType()

            Dim dtReport As New DataTable
            dtReport = dbLeave.FillDataTable("RptScreening", CommandType.StoredProcedure, prmRpt)

            If dtReport.Rows.Count = 0 Then
                MessageBox.Show("No records found.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If dtReport.Rows.Count > 0 Then
                rptViewer.LocalReport.ReportPath = "ReportFile\ScreeningLogsheet.rdlc"
                rptViewer.LocalReport.DataSources.Clear()
                rptViewer.LocalReport.DataSources.Add(New ReportDataSource("RptScreening", dtReport))

                Dim rptParam As New ReportParameterCollection
                Dim periodCovered As String = String.Empty
                Dim leaveType As String = String.Empty
                Dim employmentType As String = String.Empty

                If dtpStartDate.Value.Date.Equals(dtpEndDate.Value.Date) Then
                    periodCovered = dtpStartDate.Value.ToString("MMMM dd, yyyy")
                Else
                    periodCovered = dtpStartDate.Value.ToString("MMMM dd, yyyy") & " to " & dtpEndDate.Value.ToString("MMMM dd, yyyy")
                End If

                If Not cmbLeaveType.SelectedValue = 0 Then
                    leaveType = cmbLeaveType.Text
                Else
                    leaveType = " "
                End If

                If Not cmbEmploymentType.SelectedValue = 0 Then
                    If cmbEmploymentType.SelectedValue = 1 Then
                        employmentType = "Direct"
                    ElseIf cmbEmploymentType.SelectedValue = 2 Then
                        employmentType = "Agency"
                    End If
                Else
                    employmentType = " "
                End If

                If Not cmbEmployeeName.SelectedValue = 0 Then
                    employeeName = cmbEmployeeName.Text
                Else
                    employeeName = " "
                End If

                If Not cmbStatus.SelectedValue = 0 Then
                    status = cmbStatus.Text
                Else
                    status = " "
                End If

                rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("PeriodCovered", periodCovered))
                rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("LeaveType", leaveType))
                rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("EmploymentType", employmentType))
                rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("EmployeeName", employeeName))
                rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("Status", status))
                rptViewer.LocalReport.SetParameters(rptParam)

                rptViewer.SetDisplayMode(DisplayMode.PrintLayout)
                rptViewer.ZoomMode = ZoomMode.PageWidth
                rptViewer.LocalReport.DisplayName = "Screening Logsheet"
                rptViewer.RefreshReport()
            Else
                MessageBox.Show("No records found.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbDateType_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbDateType.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbStatus_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbStatus.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbLeaveType_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbLeaveType.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbEmploymentType_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbEmploymentType.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbEmployeeName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbEmploymentType.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbEmploymentType_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEmploymentType.SelectedValueChanged
        Try
            LoadEmployee(cmbEmploymentType.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetEmployee() As Object
        If cmbEmployeeName.SelectedValue = 0 Then Return Nothing Else Return cmbEmployeeName.SelectedValue
    End Function

    Private Function GetLeaveType() As Object
        If cmbLeaveType.SelectedValue = 0 Then Return Nothing Else Return cmbLeaveType.SelectedValue
    End Function

    Private Function GetStatus() As Object
        If cmbStatus.SelectedValue = 0 Then Return Nothing Else Return cmbStatus.SelectedValue
    End Function

    Private Function GetEmploymentType() As Object
        If cmbEmploymentType.SelectedValue = 0 Then Return Nothing Else Return cmbEmploymentType.SelectedValue
    End Function

End Class