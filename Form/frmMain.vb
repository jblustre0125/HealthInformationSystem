Imports System.Data.SqlClient
Imports System.Deployment.Application
Imports BlackCoffeeLibrary
Imports HealthInformationSystem
Imports HealthInformationSystem.dsHealth
Imports HealthInformationSystem.dsHealthTableAdapters

Public Class frmMain
    Private connection As New clsConnection
    Private dbHealth As New SqlDbMethod(connection.MyConnection)
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)
    Private dbMain As New Main

    Private employeeId As Integer = 0
    Private employeeCode As String = String.Empty
    Private employeeName As String = String.Empty
    Private positionName As String = String.Empty
    Private departmentName As String = String.Empty
    Private teamName As String = String.Empty

    Public Sub New(ByVal _employeeId As Integer, ByVal _employeeCode As String, ByVal _employeeName As String, _
                  ByVal _positionName As String, ByVal _departmentName As String, ByVal _teamName As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        employeeId = _employeeId
        employeeCode = _employeeCode
        employeeName = _employeeName
        positionName = _positionName
        departmentName = _departmentName
        teamName = _teamName

        If ApplicationDeployment.IsNetworkDeployed Then
            VersionToolStripStatusLabel.Text = "Version " & ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
        Else
            VersionToolStripStatusLabel.Text = "Version " & Application.ProductVersion.ToString
        End If

        UsernameToolStripMenuItem.Text = "  " & StrConv(employeeName, VbStrConv.ProperCase)
        UserItemToolStripMenuItem.Text = positionName

        DatetimeToolStripMenuItem.Text = CDate(dbHealth.GetServerDate).ToString("MMMM dd, yyyy")

        If departmentName.Equals(teamName) Then
            DepartmentToolStripStatusLabel.Text = departmentName
            SectionToolStripStatusLabel.Visible = False
        Else
            If String.IsNullOrEmpty(teamName) Then
                DepartmentToolStripStatusLabel.Text = departmentName
                SectionToolStripStatusLabel.Text = String.Empty
            Else
                DepartmentToolStripStatusLabel.Text = departmentName
                SectionToolStripStatusLabel.Text = teamName
            End If

            SectionToolStripStatusLabel.Text = teamName
            UserItemToolStripMenuItem.Text = positionName
        End If

        dbMain.FormLoader(Me, New frmEmpRecord(employeeId), True)

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrMain.Start()

        'disable the resize or maximize button of the form if is currently maximized, enable if minimized
        AddHandler Me.SizeChanged, AddressOf frmMain_SizeEventHandler

        Me.MaximizeBox = False
    End Sub

    Private Sub frmMain_MdiChildActivate(sender As Object, e As EventArgs) Handles MyBase.MdiChildActivate
        Dim _frm As Form = Me.ActiveMdiChild

        If Not _frm Is Nothing Then
            Me.Text = "Health Information System - " & _frm.Text & ""
        Else
            Me.Text = "Health Information System"
        End If
    End Sub

    Private Sub tmrMain_Tick(sender As Object, e As EventArgs) Handles tmrMain.Tick
        DatetimeToolStripMenuItem.Text = CDate(dbHealth.GetServerDate).ToString("MMMM dd, yyyy")
    End Sub

    'file
    Private Sub EmpRecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpRecordToolStripMenuItem.Click
        dbMain.FormLoader(Me, New frmEmpRecord(employeeId), True)
    End Sub

    Private Sub PasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasswordToolStripMenuItem.Click

    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Me.Hide()

        If Environment.MachineName.Substring(0, 8) = "NBCP-MDT" Then
            frmLogin.Show()
            frmLogin.BringToFront()
            frmLogin.txtEmployeeId.Clear()
        Else
            frmLogin.Show()
            frmLogin.BringToFront()
            frmLogin.txtEmployeeId.Clear()
            frmLogin.txtPassword.Clear()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    'maintenance menu item
    Private Sub EmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub HolidayToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'dbMain.FormLoader(Me, New frmHoliday, False)
    End Sub

    Private Sub GetPermission(ByVal _employeeId As Integer)
        Try
            'Dim _prm(0) As SqlParameter
            '_prm(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            '_prm(0).Value = _employeeId

            ''Dim _reader As IDataReader = dbLeaveFiling.ExecuteReader("SELECT * FROM dbo.Employee WHERE EmployeeId = @EmployeeId", CommandType.Text, _prm)

            'While _reader.Read
            '    isHrRecordsVisible = _reader.Item("IsHrRecords")
            '    isEmployeesVisible = _reader.Item("IsEmployee")
            '    isHolidaysVisible = _reader.Item("IsHoliday")

            '    isApprover = _reader.Item("IsApprover")
            '    isAllowEdit = _reader.Item("IsAllowEdit")
            '    isAllowDelete = _reader.Item("IsAllowDelete")
            'End While
            '_reader.Close()

            'If isHrRecordsVisible = True Then
            '    HrListToolStripMenuItem.Visible = True
            'Else
            '    HrListToolStripMenuItem.Visible = False
            'End If

            'If isEmployeesVisible = True Then
            '    EmployeeToolStripMenuItem.Visible = True
            'Else
            '    EmployeeToolStripMenuItem.Visible = False
            'End If

            'If isHolidaysVisible = True Then
            '    HolidayToolStripMenuItem.Visible = True
            'Else
            '    HolidayToolStripMenuItem.Visible = False
            'End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetEmailSettings(ByVal _settingsId As Integer)
        Try
            'Dim _prmSettingsId(0) As SqlParameter
            '_prmSettingsId(0) = New SqlParameter("@SettingsId", SqlDbType.Int)
            '_prmSettingsId(0).Value = _settingsId

            'Dim _reader As IDataReader = dbLeaveFiling.ExecuteReader("SELECT TRIM(EmailAddress) AS EmailAddress, TRIM(EmailPassword) AS EmailPassword " & _
            '                                                         "FROM dbo.Settings WHERE SettingsId = @SettingsId", _
            '                                                         CommandType.Text, _prmSettingsId)

            'While _reader.Read
            '    systemEmailAddress = _reader.Item("EmailAddress").ToString.Trim
            '    systemEmailPassword = _reader.Item("EmailPassword").ToString.Trim
            'End While
            '_reader.Close()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'prevent form resizing when dragged or double-clicked the titlebar
    Protected Overloads Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Const WM_NCLBUTTONDBLCLK As Integer = 163 'define doubleclick event
        Const WM_NCLBUTTONDOWN As Integer = 161 'define leftbuttondown event
        Const WM_SYSCOMMAND As Integer = 274 'define move action
        Const HTCAPTION As Integer = 2 'define that the WM_NCLBUTTONDOWN is at titlebar
        Const SC_MOVE As Integer = 61456 'trap move action
        'disable moving of titlebar
        If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32() = SC_MOVE) Then
            Exit Sub
        End If
        'track whether clicked on title bar
        If (m.Msg = WM_NCLBUTTONDOWN) AndAlso (m.WParam.ToInt32() = HTCAPTION) Then
            Exit Sub
        End If
        'disable double click on title bar
        If (m.Msg = WM_NCLBUTTONDBLCLK) Then
            Exit Sub
        End If

        MyBase.WndProc(m)
    End Sub

    'maximize the main form or MDI parent without hiding or overlapping the taskbar
    Private Sub frmMain_SizeEventHandler(ByVal sender As Object, ByVal e As EventArgs)
        If Me.WindowState = FormWindowState.Minimized Then
            Me.MaximizeBox = True

        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.MaximizeBox = False
        End If
    End Sub

    'send an email to the requestor to inform of remarks or comments from its approvers
    Public Sub SendRemarksNofitication(ByVal _employeeId As Integer, ByVal _remarksPosition As String, _
                                       ByVal _remarksFrom As String, ByVal _remarks As String, _
                                       ByVal _leaveType As String, ByVal _startDate As Date, _
                                       ByVal _endDate As Date)
        Try
            'Dim client As New SmtpClient()
            'Dim message As New MailMessage()
            'Dim messageBody As String = "<font size=""3"" face=""Segoe UI"" color=""black"">" & _
            '                            "Good day! <br> <br> "

            'message.From = New MailAddress(systemEmailAddress, "NBC Leave Notication")

            'Dim _prmRequestor(0) As SqlParameter
            '_prmRequestor(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            '_prmRequestor(0).Value = _employeeId

            'Dim _reader As IDataReader = dbJeonsoft.ExecuteReader("SELECT TRIM(EmailAddress) AS EmailAddress FROM dbo.tblEmployees WHERE Id = @EmployeeId", _
            '                                                      CommandType.Text, _prmRequestor)

            'While _reader.Read
            '    If _reader.Item("EmailAddress") Is DBNull.Value Then
            '        message.To.Add(emailDeveloper)
            '    Else
            '        If isDebug = True Then
            '            message.To.Add(emailDeveloper)
            '        Else
            '            message.To.Add(_reader.Item("EmailAddress").ToString.Trim)
            '        End If
            '    End If
            'End While
            '_reader.Close()

            'message.Subject = "Leave Notification"
            'message.IsBodyHtml = True

            'messageBody += "New comment to your " & _leaveType.ToString.Trim

            'If _startDate.Date.Date.Equals(_endDate.Date.Date) Then
            '    messageBody += " dated " & _startDate.Date.ToString("MMMM dd, yyyy")
            'Else
            '    messageBody += " dated " & _startDate.Date.ToString("MMMM dd, yyyy") & _
            '                   " to " & _endDate.Date.ToString("MMMM dd, yyyy")
            'End If

            'messageBody += " from your " & _remarksPosition.ToString.Trim & ". <br> <br>" & _
            '                StrConv(_remarksFrom.ToString.Trim, VbStrConv.ProperCase) & " : " & _remarks.ToString.Trim

            'messageBody += "<br> <br> <br>" & _
            '               "Please check on your Leave Application System." & _
            '               "<br> <br>" & _
            '               "If you have any concerns, please call IT (Local 232). Thank you. <br> <br>" & _
            '               "This is a system-generated email. Please do not reply."

            'message.Body = messageBody

            'client.Host = systemEmailHost
            'client.Port = systemEmailPort
            'client.EnableSsl = True
            'client.UseDefaultCredentials = False
            'client.Credentials = New Net.NetworkCredential(systemEmailAddress, systemEmailPassword)

            'Dim userState As String = "userState"
            'AddHandler client.SendCompleted, AddressOf SendCompletedCallback

            'client.SendAsync(message, userState)

            'StatusToolStripStatusLabel.Visible = True
            'StatusToolStripStatusLabel.Text = "Sending email, please wait......"
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'send an email to the requestor to inform of its returned application
    Public Sub SendEmailReturned(ByVal _employeeId As Integer, ByVal _leaveType As String, ByVal _startDate As Date, ByVal _endDate As Date)
        Try
            'Dim client As New SmtpClient()
            'Dim message As New MailMessage()
            'Dim messageBody As String = "<font size=""3"" face=""Segoe UI"" color=""black"">" & _
            '                            "Good day! <br> <br> "

            'message.From = New MailAddress(systemEmailAddress, "NBC Leave Notication")

            'Dim _prmRequestor(0) As SqlParameter
            '_prmRequestor(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            '_prmRequestor(0).Value = _employeeId

            'Dim _reader As IDataReader = dbJeonsoft.ExecuteReader("SELECT TRIM(EmailAddress) AS EmailAddress FROM dbo.tblEmployees WHERE Id = @EmployeeId", _
            '                                                      CommandType.Text, _prmRequestor)

            ''While _reader.Read
            ''    If _reader.Item("EmailAddress") Is DBNull.Value Then
            ''        message.To.Add(emailDeveloper)
            ''    Else
            ''        If isDebug = True Then
            ''            message.To.Add(emailDeveloper)
            ''        Else
            ''            message.To.Add(_reader.Item("EmailAddress").ToString.Trim)
            ''        End If
            ''    End If
            ''End While
            ''_reader.Close()

            'message.Subject = "Leave Notification"
            'message.IsBodyHtml = True

            'messageBody += "Your " & _leaveType.ToString.Trim

            'If _startDate.Date.Date.Equals(_endDate.Date.Date) Then
            '    messageBody += " dated " & _startDate.Date.ToString("MMMM dd, yyyy")
            'Else
            '    messageBody += " dated from " & _startDate.Date.ToString("MMMM dd, yyyy") & " to " & _endDate.Date.ToString("MMMM dd, yyyy")
            'End If

            'messageBody += " is returned for revision. Please update your application then resend it to your approvers. <br> <br>" & _
            '               "If you have any concerns, please call IT (Local 232). Thank you. <br> <br>" & _
            '               "This is a system-generated email. Please do not reply."

            'message.Body = messageBody

            'client.Host = systemEmailHost
            'client.Port = systemEmailPort
            'client.EnableSsl = True
            'client.UseDefaultCredentials = False
            'client.Credentials = New Net.NetworkCredential(systemEmailAddress, systemEmailPassword)

            'Dim userState As String = "userState"
            'AddHandler client.SendCompleted, AddressOf SendCompletedCallback

            'client.SendAsync(message, userState)

            'StatusToolStripStatusLabel.Visible = True
            'StatusToolStripStatusLabel.Text = "Sending email, please wait......"
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'send an email to the requestor to inform the final status of its application
    Public Sub SendEmailRequestor(ByVal _isApproved As Boolean, ByVal _employeeId As Integer, ByVal _leaveType As String, ByVal _startDate As Date, ByVal _endDate As Date)
        Try
            'Dim client As New SmtpClient()
            'Dim message As New MailMessage()
            'Dim messageBody As String = "<font size=""3"" face=""Segoe UI"" color=""black"">" & _
            '                            "Good day! <br> <br> "

            'message.From = New MailAddress(systemEmailAddress, "NBC Leave Notification")

            'Dim _prmRequestor(0) As SqlParameter
            '_prmRequestor(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            '_prmRequestor(0).Value = _employeeId

            'Dim _reader As IDataReader = dbJeonsoft.ExecuteReader("SELECT TRIM(EmailAddress) AS EmailAddress FROM dbo.tblEmployees WHERE Id = @EmployeeId", _
            '                                                      CommandType.Text, _prmRequestor)

            ''While _reader.Read
            ''    If _reader.Item("EmailAddress") Is DBNull.Value Then
            ''        message.To.Add(emailDeveloper)
            ''    Else
            ''        If isDebug = True Then
            ''            message.To.Add(emailDeveloper)
            ''        Else
            ''            message.To.Add(_reader.Item("EmailAddress").ToString.Trim)
            ''        End If
            ''    End If
            ''End While
            ''_reader.Close()

            'message.Subject = "Leave Notification"
            'message.IsBodyHtml = True

            'If _isApproved = True Then
            '    If _startDate.Date.Date.Equals(_endDate.Date.Date) Then
            '        messageBody += "Your " & _leaveType.ToString.Trim & " dated " & _startDate.Date.ToString("MMMM dd, yyyy") & _
            '                       " is approved. <br> <br>" & _
            '                       "If you have any concerns, please call IT (Local 232). Thank you. <br> <br>" & _
            '                       "This is a system-generated email. Please do not reply."
            '    Else
            '        messageBody += "Your " & _leaveType.ToString.Trim & " dated from " & _startDate.Date.ToString("MMMM dd, yyyy") & _
            '                       " to " & _endDate.Date.ToString("MMMM dd, yyyy") & " is approved. <br> <br>" & _
            '                       "If you have any concerns, please call IT (Local 232). Thank you. <br> <br>" & _
            '                       "This is a system-generated email. Please do not reply."
            '    End If
            'Else
            '    If _startDate.Date.Date.Equals(_endDate.Date.Date) Then
            '        messageBody += "Your " & _leaveType.ToString.Trim & " dated " & _startDate.Date.ToString("MMMM dd, yyyy") & _
            '                       " is disapproved. <br> <br>" & _
            '                       "If you have any concerns, please call IT (Local 232). Thank you. <br> <br>" & _
            '                       "This is a system-generated email. Please do not reply."
            '    Else
            '        messageBody += "Your " & _leaveType.ToString.Trim & " dated from " & _startDate.Date.ToString("MMMM dd, yyyy") & _
            '                       " to " & _endDate.Date.ToString("MMMM dd, yyyy") & " is disapproved. <br> <br>" & _
            '                       "If you have any concerns, please call IT (Local 232). Thank you. <br> <br>" & _
            '                       "This is a system-generated email. Please do not reply."
            '    End If
            'End If

            'message.Body = messageBody

            'client.Host = systemEmailHost
            'client.Port = systemEmailPort
            'client.EnableSsl = True
            'client.UseDefaultCredentials = False
            'client.Credentials = New Net.NetworkCredential(systemEmailAddress, systemEmailPassword)

            'Dim userState As String = "userState"
            'AddHandler client.SendCompleted, AddressOf SendCompletedCallback

            'client.SendAsync(message, userState)

            'StatusToolStripStatusLabel.Visible = True
            'StatusToolStripStatusLabel.Text = "Sending email, please wait......"
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'send an email to the next approver
    Public Sub SendEmailApprovers(ByVal _leaveFileId As Integer, ByVal _employeeId As Integer, ByVal _leaveType As String, ByVal _employeeName As String, _
                                  ByVal _department As String, ByVal _date As String, ByVal _reason As String)
        Try
            'Dim client As New SmtpClient()
            'Dim message As New MailMessage()
            'Dim messageBody As String = "<font size=""3"" face=""Segoe UI"" color=""black"">" & _
            '                            "Good day! <br> <br> " & _
            '                            "New leave application for your approval. Please check the information below for your reference. <br> <br> " & _
            '                            "<table style=""font-size: 20px;font-family:Segoe UI""> " & _
            '                            "<tr><td style=""width:10px""></td><td>Leave File ID: </td><td style=""width:50px""></td><td>" & _leaveFileId & "</td></tr>" & _
            '                            "<tr><td style=""width:10px""></td><td>Leave Type: </td><td style=""width:50px""></td><td>" & _leaveType.ToString.Trim & "</td></tr>" & _
            '                            "<tr><td style=""width:10px""></td><td>Employee Name: </td><td style=""width:50px""></td><td>" & _employeeName.ToString.Trim & "</td></tr>" & _
            '                            "<tr><td style=""width:10px""></td><td>Department/Section: </td><td style=""width:50px""></td><td>" & _department.ToString.Trim & "</td></tr>" & _
            '                            "<tr><td style=""width:10px""></td><td>Date: </td><td style=""width:50px""></td><td>" & _date.ToString.Trim & "</td></tr>" & _
            '                            "<tr><td style=""width:10px""></td><td>Reason: </td><td style=""width:50px""></td><td>" & _reason.ToString.Trim & "</td></tr>" & _
            '                            "</table>" & _
            '                            "<br>" & _
            '                            "Please check on your Leave Application System." & _
            '                            "<br> <br>" & _
            '                            "If you have any concerns, please call IT (Local 232). Thank you." & _
            '                            "<br> <br>" & _
            '                            "This is a system-generated email. Please do not reply."

            'message.From = New MailAddress(systemEmailAddress, "NBC Leave Notification")

            'Dim _prmApprover(0) As SqlParameter
            '_prmApprover(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            '_prmApprover(0).Value = _employeeId

            ''Dim _reader As IDataReader = dbLeaveFiling.ExecuteReader("SELECT TRIM(NbcEmailAddress) AS NbcEmailAddress FROM dbo.Employee WHERE EmployeeId = @EmployeeId", _
            '                                                         CommandType.Text, _prmApprover)

            ''While _reader.Read
            ''    If _reader.Item("NbcEmailAddress") Is DBNull.Value Then
            ''        message.To.Add(emailDeveloper)
            ''    Else
            ''        If isDebug = True Then
            ''            message.To.Add(emailDeveloper)
            ''        Else
            ''            message.To.Add(_reader.Item("NbcEmailAddress").ToString.Trim)
            ''        End If
            ''    End If
            ''End While
            ''_reader.Close()

            'message.Subject = "Leave Notification"
            'message.IsBodyHtml = True
            'message.Body = messageBody

            ''client.Host = systemEmailHost
            ''client.Port = systemEmailPort
            'client.UseDefaultCredentials = False
            'client.EnableSsl = True
            'client.Credentials = New Net.NetworkCredential(systemEmailAddress, systemEmailPassword)

            'Dim userState As String = "userState"
            'AddHandler client.SendCompleted, AddressOf SendCompletedCallback

            'client.SendAsync(message, userState)

            'StatusToolStripStatusLabel.Visible = True
            'StatusToolStripStatusLabel.Text = "Sending email, please wait......"
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'send an email to the HR (mam cath dela pena)
    Public Sub SendEmailHr(ByVal _leaveFileId As Integer, ByVal _isApproved As Boolean, _leaveType As String, ByVal _employeeName As String, _
                           ByVal _department As String, ByVal _date As String, ByVal _reason As String)
        Try
            'Dim client As New SmtpClient()
            'Dim message As New MailMessage()
            'Dim messageBody As String = String.Empty

            'If _isApproved = True Then
            '    messageBody = "<font size=""3"" face=""Segoe UI"" color=""black"">" & _
            '                "Good day! <br> <br> " & _
            '                "New approved leave application. Please check the information below for your reference. <br> <br> " & _
            '                "<table style=""font-size: 20px;font-family:Segoe UI""> " & _
            '                "<tr><td style=""width:10px""></td><td>Leave File ID: </td><td style=""width:50px""></td><td>" & _leaveFileId & "</td></tr>" & _
            '                "<tr><td style=""width:10px""></td><td>Leave Type: </td><td style=""width:50px""></td><td>" & _leaveType.ToString.Trim & "</td></tr>" & _
            '                "<tr><td style=""width:10px""></td><td>Employee Name: </td><td style=""width:50px""></td><td>" & _employeeName.ToString.Trim & "</td></tr>" & _
            '                "<tr><td style=""width:10px""></td><td>Department/Section: </td><td style=""width:50px""></td><td>" & _department.ToString.Trim & "</td></tr>" & _
            '                "<tr><td style=""width:10px""></td><td>Date: </td><td style=""width:50px""></td><td>" & _date.ToString.Trim & "</td></tr>" & _
            '                "<tr><td style=""width:10px""></td><td>Reason: </td><td style=""width:50px""></td><td>" & _reason.ToString.Trim & "</td></tr>" & _
            '                "</table>" & _
            '                "<br>" & _
            '                "Please check on your Leave Application System." & _
            '                "<br> <br>" & _
            '                "If you have any concerns, please call IT (Local 232). <br> <br>" & _
            '                "This is a system-generated email. Please do not reply."
            'Else
            '    messageBody = "<font size=""3"" face=""Segoe UI"" color=""black"">" & _
            '                "Good day! <br> <br> " & _
            '                "New disapproved leave application. Please check the information below for your reference. <br> <br> " & _
            '                "<table style=""font-size: 20px;font-family:Segoe UI""> " & _
            '                "<tr><td style=""width:10px""></td><td>Leave File ID: </td><td style=""width:50px""></td><td>" & _leaveFileId & "</td></tr>" & _
            '                "<tr><td style=""width:10px""></td><td>Leave Type: </td><td style=""width:50px""></td><td>" & _leaveType.ToString.Trim & "</td></tr>" & _
            '                "<tr><td style=""width:10px""></td><td>Employee Name: </td><td style=""width:50px""></td><td>" & _employeeName.ToString.Trim & "</td></tr>" & _
            '                "<tr><td style=""width:10px""></td><td>Department/Section: </td><td style=""width:50px""></td><td>" & _department.ToString.Trim & "</td></tr>" & _
            '                "<tr><td style=""width:10px""></td><td>Date: </td><td style=""width:50px""></td><td>" & _date.ToString.Trim & "</td></tr>" & _
            '                "<tr><td style=""width:10px""></td><td>Reason: </td><td style=""width:50px""></td><td>" & _reason.ToString.Trim & "</td></tr>" & _
            '                "</table>" & _
            '                "<br>" & _
            '                "Please check on your Leave Application System." & _
            '                "<br> <br>" & _
            '                "If you have any concerns, please call IT (Local 232). Thank you. <br> <br>" & _
            '                "This is a system-generated email. Please do not reply."
            'End If

            'message.From = New MailAddress(systemEmailAddress, "NBC Leave Notification")

            ''If isDebug = True Then
            ''    message.To.Add(emailDeveloper)
            ''Else
            ''    message.To.Add(emailHr)
            ''End If

            ''message.Subject = "Leave Notification"
            ''message.IsBodyHtml = True
            ''message.Body = messageBody

            ''client.Host = systemEmailHost
            ''client.Port = systemEmailPort
            'client.EnableSsl = True
            'client.UseDefaultCredentials = False
            'client.Credentials = New Net.NetworkCredential(systemEmailAddress, systemEmailPassword)

            'Dim userState As String = "userState"
            'AddHandler client.SendCompleted, AddressOf SendCompletedCallback

            'client.SendAsync(message, userState)

            'StatusToolStripStatusLabel.Visible = True
            'StatusToolStripStatusLabel.Text = "Sending email, please wait......"
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Async Sub SendCompletedCallback(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
    '    Try
    '        Dim token As String = CStr(e.UserState)

    '        If e.Cancelled Then
    '            StatusToolStripStatusLabel.Text = "Sending canceled."
    '        End If

    '        If e.Error IsNot Nothing Then
    '            StatusToolStripStatusLabel.Text = e.Error.ToString
    '        Else
    '            StatusToolStripStatusLabel.Text = "Email sent, thank you."
    '        End If

    '        Await HideStatus()

    '        isEmailSent = True
    '    Catch ex As Exception
    '        MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'timercallback of threading timer
    Private Sub ThreadingTimerTick(ByVal state As Object)
        If Not bgWorker.IsBusy.Equals(True) Then
            bgWorker.RunWorkerAsync()
        End If
    End Sub

    Private Async Function HideStatus() As Task(Of Boolean)
        Await Task.Delay(2000)
        StatusToolStripStatusLabel.Visible = False
        Return True
    End Function

    'get the next cut-off date of current period
    'Private Function GetCutOffDate(ByVal _currentDate As Date) As Date
    '    'Dim _cutOff As Date = Nothing

    '    'If _currentDate.Date.Day >= 6 AndAlso _currentDate.Date.Day <= 20 Then
    '    '    _cutOff = New DateTime(dbLeaveFiling.GetServerDate.Date.Year, dbLeaveFiling.GetServerDate.Date.Month, 23)
    '    'ElseIf _currentDate.Date.Day >= 21 Then
    '    '    _cutOff = New DateTime(dbLeaveFiling.GetServerDate.Date.Year, dbLeaveFiling.GetServerDate.Date.Month, 8)
    '    'ElseIf _currentDate.Date.Day <= 5 Then
    '    '    _cutOff = New DateTime(dbLeaveFiling.GetServerDate.Date.Year, dbLeaveFiling.GetServerDate.Date.Month, 8)
    '    'End If

    '    'Try
    '    '    While IsHoliday(_cutOff) = True Or IsWeekend(_cutOff) = True
    '    '        _cutOff = _cutOff.AddDays(1)
    '    '    End While
    '    'Catch ex As Exception
    '    '    MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    'End Try

    '    'Return _cutOff
    'End Function

    'check the date if it is sunday
    Private Function IsWeekend(ByVal _date As Date) As Boolean
        If _date.DayOfWeek.Equals(DayOfWeek.Sunday) Then
            Return True
        Else
            Return False
        End If
    End Function

    'check the data if it is a holiday
    Private Function IsHoliday(ByVal _date As Date) As Boolean
        Dim _count As Integer

        Try
            'Dim _paramHoliday(0) As SqlParameter
            '_paramHoliday(0) = New SqlParameter("@HolidayDate", SqlDbType.Date)
            '_paramHoliday(0).Value = _date.ToShortDateString
            '_count = 0
            '_count = dbLeaveFiling.ExecuteScalar("SELECT COUNT(HolidayId) FROM Holiday WHERE HolidayDate = @HolidayDate", CommandType.Text, _paramHoliday)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If _count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class