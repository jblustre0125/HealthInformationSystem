Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection
Imports BlackCoffeeLibrary
Imports Microsoft.Reporting.WinForms

Public Class LeaveLogsheet
    Private connection As New clsConnection
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)
    Private dbLeaveFiling As New SqlDbMethod(connection.LeaveConnection)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private dicDate As New Dictionary(Of String, Integer)
    Private dicStatus As New Dictionary(Of String, Integer)

    Private containerTable As New DataTable

    Private Sub frmHr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dicDate.Add(" Leave Date", 0)
            dicDate.Add(" Date Filed", 1)
            cmbDateType.DisplayMember = "Key"
            cmbDateType.ValueMember = "Value"
            cmbDateType.DataSource = New BindingSource(dicDate, Nothing)

            dbJeonsoft.FillCmbWithCaption("SELECT Id, (TRIM(EmployeeCode) + '  ' + (FirstName + ' ' + ISNULL(SUBSTRING(CASE WHEN LEN(TRIM(MiddleName)) = 0 THEN NULL " &
                                          "WHEN TRIM(MiddleName) = '-' THEN NULL ELSE TRIM(MiddleName) END, 1, 1) + '. ' , '') + LastName)) AS Name FROM dbo.tblEmployees WHERE " &
                                          "Active = 1 And EmployeeCode Is NOT NULL", CommandType.Text, "Id", "Name", cmbName, "")

            dbLeaveFiling.FillCmbWithCaption("SELECT L.LeaveTypeId, TRIM(L.LeaveTypeCode) AS LeaveTypeCode, TRIM(L.LeaveTypeName) AS LeaveTypeName FROM dbo.LeaveType L WHERE L.IsActive = 1 AND L.IsClinic = 1", CommandType.Text, "LeaveTypeId", "LeaveTypeName", cmbLeaveType, "< Select Leave Type >")

            dicStatus.Add(" All", 0)
            dicStatus.Add(" Pending", 1)
            dicStatus.Add(" Approved", 2)
            dicStatus.Add(" Disapproved", 3)
            cmbRoutingStatus.DisplayMember = "Key"
            cmbRoutingStatus.ValueMember = "Value"
            cmbRoutingStatus.DataSource = New BindingSource(dicStatus, Nothing)

            cmbDateType.SelectedValue = 0
            cmbRoutingStatus.SelectedValue = 0

            dtpStartDate.Value = Date.Now
            dtpEndDate.Value = Date.Now

            rptViewer.LocalReport.ReportPath = ""

            BuildContainerTable(containerTable)

            Me.ActiveControl = btnGenerate
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.rptViewer.RefreshReport()
    End Sub

    Public Shared Sub SetReportEmbeddedResource(ByVal reportViewer As Microsoft.Reporting.WinForms.ReportViewer, ByVal reportName As String)
        Using s As Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(reportName)
            reportViewer.LocalReport.LoadReportDefinition(s)
        End Using
    End Sub

    Private Sub frmRptHrLeave_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnGenerate.PerformClick()
        End If
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            If dtpStartDate.Value.Date > dtpEndDate.Value.Date Then
                MessageBox.Show("Start date is later than the end date.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf dtpStartDate.Value.Date = dtpEndDate.Value.Date Then
                GenerateReport()
            Else
                GenerateReport()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Try
            cmbDateType.SelectedValue = 0
            dtpStartDate.Value = Date.Now
            dtpEndDate.Value = Date.Now
            cmbLeaveType.SelectedValue = 0
            cmbName.SelectedValue = 0
            cmbRoutingStatus.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs)
        Try
            If containerTable.Rows.Count > 0 Then

            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub GenerateReport()
        Try
            Dim prmRpt(5) As SqlParameter
            prmRpt(0) = New SqlParameter("@StartDate", SqlDbType.Date)
            prmRpt(0).Value = dbMain.FormatDate(dtpStartDate.Value.Date, False)
            prmRpt(1) = New SqlParameter("@EndDate", SqlDbType.Date)
            prmRpt(1).Value = dbMain.FormatDate(dtpEndDate.Value.Date, False)
            prmRpt(2) = New SqlParameter("@DateType", SqlDbType.Char)
            prmRpt(2).Value = GetDateType()
            prmRpt(3) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            prmRpt(3).Value = GetEmployee()
            prmRpt(4) = New SqlParameter("@LeaveTypeId", SqlDbType.Int)
            prmRpt(4).Value = GetLeaveType()
            prmRpt(5) = New SqlParameter("@RoutingStatusId", SqlDbType.Char)
            prmRpt(5).Value = GetStatus()

            Dim dtReport As New DataTable
            dtReport = dbLeaveFiling.FillDataTable("RptJeonsoft", CommandType.StoredProcedure, prmRpt)

            If dtReport.Rows.Count = 0 Then
                MessageBox.Show("No records found.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If containerTable.Rows.Count > 0 Then
                containerTable.Clear()
            End If

            For i As Integer = 0 To dtReport.Rows.Count - 1
                Dim quantity As Integer = CInt(dtReport.Rows(i).Item("Quantity").ToString)

                If quantity > 1 Then
                    Dim startDate As Date = CDate(dtReport.Rows(i).Item("StartDate"))
                    Dim endDate As Date = CDate(dtReport.Rows(i).Item("EndDate"))

                    For j As Integer = 0 To (endDate - startDate).Days
                        If IsHoliday(startDate) = False Then
                            If IsSunday(startDate) = False Then
                                Dim conNewRow As DataRow = containerTable.NewRow
                                conNewRow("EmployeeCode") = dtReport.Rows(i).Item("EmployeeCode")
                                conNewRow("EmployeeName") = dtReport.Rows(i).Item("EmployeeName")
                                conNewRow("LeaveDate") = startDate.Date.ToString("MM/dd/yyyy")
                                conNewRow("LeaveCode") = dtReport.Rows(i).Item("LeaveCode")
                                conNewRow("Quantity") = 1
                                conNewRow("Status") = dtReport.Rows(i).Item("Status")
                                conNewRow("DateFiled") = CDate(dtReport.Rows(i).Item("DateCreated")).ToString("MM/dd/yyyy")
                                conNewRow("Reason") = dtReport.Rows(i).Item("Reason")
                                conNewRow("SuperiorRemarks1") = dtReport.Rows(i).Item("SuperiorRemarks1")
                                conNewRow("SuperiorRemarks2") = dtReport.Rows(i).Item("SuperiorRemarks2")
                                conNewRow("ManagerRemarks") = dtReport.Rows(i).Item("ManagerRemarks")
                                containerTable.Rows.Add(conNewRow)
                            End If
                        End If
                        startDate = startDate.AddDays(1)
                    Next

                Else
                    Dim conNewRow As DataRow = containerTable.NewRow
                    conNewRow("EmployeeCode") = dtReport.Rows(i).Item("EmployeeCode")
                    conNewRow("EmployeeName") = dtReport.Rows(i).Item("EmployeeName")
                    conNewRow("LeaveDate") = CDate(dtReport.Rows(i).Item("StartDate")).ToString("MM/dd/yyyy")
                    conNewRow("LeaveCode") = dtReport.Rows(i).Item("LeaveCode")
                    conNewRow("Quantity") = dtReport.Rows(i).Item("Quantity")
                    conNewRow("Status") = dtReport.Rows(i).Item("Status")
                    conNewRow("DateFiled") = CDate(dtReport.Rows(i).Item("DateCreated")).ToString("MM/dd/yyyy")
                    conNewRow("Reason") = dtReport.Rows(i).Item("Reason")
                    conNewRow("SuperiorRemarks1") = dtReport.Rows(i).Item("SuperiorRemarks1")
                    conNewRow("SuperiorRemarks2") = dtReport.Rows(i).Item("SuperiorRemarks2")
                    conNewRow("ManagerRemarks") = dtReport.Rows(i).Item("ManagerRemarks")
                    containerTable.Rows.Add(conNewRow)
                End If
            Next

            containerTable.AcceptChanges()
            rptViewer.LocalReport.ReportPath = "ReportFile\RptJeonsoft.rdlc"
            rptViewer.LocalReport.DataSources.Clear()
            rptViewer.LocalReport.DataSources.Add(New ReportDataSource("RptJeonsoft", containerTable))

            Dim rptParam As New ReportParameterCollection
            Dim leaveType As String = String.Empty
            Dim empName As String = String.Empty
            Dim status As String = String.Empty

            If Not cmbLeaveType.SelectedValue = 0 Then
                leaveType = cmbLeaveType.Text
            Else
                leaveType = " "
            End If

            If Not cmbName.SelectedValue = 0 Then
                empName = cmbName.Text
            Else
                empName = " "
            End If

            If Not cmbRoutingStatus.SelectedValue = 0 Then
                status = cmbRoutingStatus.Text
            Else
                status = " "
            End If

            rptParam.Add(New ReportParameter("StartDate", dtpStartDate.Value.Date.ToString("MMMM dd, yyyy")))
            rptParam.Add(New ReportParameter("EndDate", dtpEndDate.Value.Date.ToString("MMMM dd, yyyy")))
            rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("LeaveType", leaveType))
            rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("EmployeeName", empName))
            rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("Status", status))
            rptViewer.LocalReport.SetParameters(rptParam)

            rptViewer.SetDisplayMode(DisplayMode.PrintLayout)
            rptViewer.ZoomMode = ZoomMode.PageWidth
            rptViewer.LocalReport.DisplayName = "Leave Report"
            rptViewer.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BuildContainerTable(table As DataTable)
        Try
            Dim column As DataColumn

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "EmployeeCode"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "EmployeeName"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.DateTime")
            column.ColumnName = "LeaveDate"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "LeaveCode"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.Double")
            column.ColumnName = "Quantity"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "Status"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.DateTime")
            column.ColumnName = "DateFiled"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "Reason"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "SuperiorRemarks1"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "SuperiorRemarks2"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "ManagerRemarks"
            column.AutoIncrement = False
            column.ReadOnly = False
            column.Unique = False
            table.Columns.Add(column)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'check if sunday
    Private Function IsSunday(subjectDate As Date) As Boolean
        If subjectDate.DayOfWeek.Equals(DayOfWeek.Sunday) Then
            Return True
        Else
            Return False
        End If
    End Function

    'check if included to holiday list
    Private Function IsHoliday(subjectDate As Date) As Boolean
        Dim count As Integer

        Try
            Dim prmDate(0) As SqlParameter
            prmDate(0) = New SqlParameter("@HolidayDate", SqlDbType.Date)
            prmDate(0).Value = subjectDate.ToShortDateString
            count = 0
            count = dbLeaveFiling.ExecuteScalar("SELECT COUNT(HolidayId) FROM Holiday WHERE HolidayDate = @HolidayDate", CommandType.Text, prmDate)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function GetDateType() As Object
        If cmbDateType.SelectedValue = 0 Then Return "L" Else Return "F"
    End Function

    Private Function GetEmployee() As Object
        If cmbName.SelectedValue = 0 Then Return Nothing Else Return cmbName.SelectedValue
    End Function

    Private Function GetLeaveType() As Object
        If cmbLeaveType.SelectedValue = 0 Then Return Nothing Else Return cmbLeaveType.SelectedValue
    End Function

    Private Function GetStatus() As Object
        Select Case cmbRoutingStatus.SelectedValue
            Case 0
                Return "Z"
            Case 1
                Return "P"
            Case 2
                Return "A"
            Case 3
                Return "D"
            Case Else
                Return Nothing
        End Select
    End Function

End Class