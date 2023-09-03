Imports BlackCoffeeLibrary
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Deployment.Application
Imports System.IO
Imports System.Net.Mail

Public Class Main
    Private connection As New clsConnection
    Private dbHealth As New SqlDbMethod(connection.MyConnection)
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private employeeId As Integer = 0
    Private employeeCode As String = String.Empty
    Private employeeName As String = String.Empty
    Private departmentName As String = String.Empty
    Private teamName As String = String.Empty
    Private positionName As String = String.Empty
    Private isAdmin As Boolean = False

    Private devEmailAddress As String = String.Empty
    Private devEmailPassword As String = String.Empty

    Private senderEmailAddress As String = String.Empty
    Private senderEmailPassword As String = String.Empty

    Private Shared IsSent As Boolean = False

    Private settingsId As Integer = HealthInformationSystem.My.Settings.SettingsId

    Public Sub New(_employeeId As Integer, _employeeCode As String, _employeeName As String, _departmentName As String, _teamName As String, _positionName As String,
                   _isAdmin As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        employeeId = _employeeId
        employeeCode = _employeeCode
        employeeName = _employeeName
        departmentName = _departmentName
        teamName = _teamName
        positionName = _positionName
        isAdmin = _isAdmin

        If ApplicationDeployment.IsNetworkDeployed Then
            VersionToolStripStatusLabel.Text = "Version " & ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
        Else
            VersionToolStripStatusLabel.Text = "Version " & Application.ProductVersion.ToString
        End If

        UsernameToolStripMenuItem.Text = "  " & StrConv(employeeName, VbStrConv.ProperCase)
        UserItemToolStripMenuItem.Text = positionName
        DatetimeToolStripMenuItem.Text = CDate(dbHealth.GetServerDate).ToString("dd MMMM yyyy")

        If departmentName.Equals(teamName) Then
            DepartmentToolStripStatusLabel.Text = departmentName
            SectionToolStripStatusLabel.Visible = False
        Else
            If String.IsNullOrWhiteSpace(teamName) Then
                DepartmentToolStripStatusLabel.Text = departmentName
                SectionToolStripStatusLabel.Text = String.Empty
            Else
                DepartmentToolStripStatusLabel.Text = departmentName
                SectionToolStripStatusLabel.Text = teamName
            End If
        End If

        If HealthInformationSystem.My.MySettings.Default.IsDebug = True Then
            dbMain.FormLoader(Me, New Consultation(employeeId, isAdmin), True)
            'dbMain.FormLoader(Me, New ReceiveMedicine(employeeId), False)
        Else
            dbMain.FormLoader(Me, New Consultation(employeeId, isAdmin), True)
        End If

        GetSetting()
    End Sub

    Public Sub SendEmailApprovers(leaveFileId As Integer, employeeId As Integer, leaveType As String, employeeName As String,
                                  department As String, leaveDate As String, reason As String)
        Try
            Dim client As New SmtpClient()
            Dim message As New MailMessage()
            Dim messageBody As String = "<font size=""3"" face=""Segoe UI"" color=""black"">" &
                                        "Good day! <br> <br> " &
                                        "New leave application for your approval. Please check the information below for your reference. <br> <br> " &
                                        "<table style=""font-size: 20px;font-family:Segoe UI""> " &
                                        "<tr><td style=""width:10px""></td><td>Leave File ID: </td><td style=""width:50px""></td><td>" & leaveFileId & "</td></tr>" &
                                        "<tr><td style=""width:10px""></td><td>Leave Type: </td><td style=""width:50px""></td><td>" & leaveType & "</td></tr>" &
                                        "<tr><td style=""width:10px""></td><td>Employee Name: </td><td style=""width:50px""></td><td>" & employeeName & "</td></tr>" &
                                        "<tr><td style=""width:10px""></td><td>Department/Section: </td><td style=""width:50px""></td><td>" & department & "</td></tr>" &
                                        "<tr><td style=""width:10px""></td><td>Date: </td><td style=""width:50px""></td><td>" & leaveDate & "</td></tr>" &
                                        "<tr><td style=""width:10px""></td><td>Reason: </td><td style=""width:50px""></td><td>" & reason & "</td></tr>" &
                                        "</table>" &
                                        "<br>" &
                                        "Please check on your Leave Application System." &
                                        "<br> <br>" &
                                        "If you have any concerns, please call IT (Local 232). Thank you." &
                                        "<br> <br>" &
                                        "<em>This is a system-generated email. Please do not reply.</em>"

            message.From = New MailAddress(senderEmailAddress, "NBC Leave Notification")

            Dim prmApprover(0) As SqlParameter
            prmApprover(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            prmApprover(0).Value = employeeId

            Using reader As IDataReader = dbHealth.ExecuteReader("SELECT TRIM(NbcEmailAddress) AS NbcEmailAddress FROM dbo.Employee WHERE EmployeeId = @EmployeeId",
                                                                  CommandType.Text, prmApprover)
                While reader.Read
                    If reader.Item("NbcEmailAddress") Is DBNull.Value Then
                        message.To.Add("it1@nbc-p.com")
                    Else
                        If HealthInformationSystem.My.MySettings.Default.IsDebug = True Then
                            message.To.Add("it1@nbc-p.com")
                        Else
                            message.To.Add(reader.Item("NbcEmailAddress").ToString.Trim)
                        End If
                    End If
                End While
                reader.Close()
            End Using

            message.Subject = "Leave Notification"
            message.IsBodyHtml = True
            message.Body = messageBody

            client.Host = "smtp.gmail.com"
            client.Port = 587
            client.UseDefaultCredentials = False
            client.EnableSsl = True
            client.Credentials = New Net.NetworkCredential(senderEmailAddress, senderEmailPassword)

            Dim userState As String = "userState"
            AddHandler client.SendCompleted, AddressOf SendCompletedCallback

            client.SendAsync(message, userState)

            StatusToolStripStatusLabel.Text = ""
            StatusToolStripStatusLabel.Text = "Sending email, do not close the application....."
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SendEmailDeveloper(employeeId As Integer, employeeName As String, leaveTypeId As Integer, leaveType As String,
                                  departmentId As Integer, departmentName As String, teamId As Integer, teamName As String,
                                  positionId As Integer, positionName As String)
        Try
            Dim client As New SmtpClient()
            Dim message As New MailMessage()
            Dim messageBody As String = "<font size=""3"" face=""Segoe UI"" color=""black"">" &
                                       "Good day! <br> <br> " &
                                       "New Automatic ECQ Leave Filing with no recipient. <br> <br> " &
                                       "<table style=""font-size: 20px;font-family:Segoe UI""> " &
                                       "<tr><td style=""width:10px""></td><td>Leave Type: </td><td style=""width:50px""></td><td>" & leaveType & "  (" & leaveTypeId & ")" & "</td></tr>" &
                                       "<tr><td style=""width:10px""></td><td>Employee Name: </td><td style=""width:50px""></td><td>" & employeeName & "  (" & employeeId & ")" & "</td></tr>" &
                                       "<tr><td style=""width:10px""></td><td>Department: </td><td style=""width:50px""></td><td>" & departmentName & "  (" &
                                       departmentId & ")" & "</td></tr>" &
                                       "<tr><td style=""width:10px""></td><td>Team: </td><td style=""width:50px""></td><td>" & teamName & "  (" &
                                       teamId & ")" & "</td></tr>" &
                                       "<tr><td style=""width:10px""></td><td>Position: </td><td style=""width:50px""></td><td>" & positionName & " (" &
                                       positionId & ")" & "</td></tr>" &
                                       "</table>" &
                                       "<br>" &
                                       "<em>This is a system-generated email. Please do not reply.</em>"

            message.From = New MailAddress(senderEmailAddress, "NBC Leave Notification")
            message.To.Add(devEmailAddress)

            message.Subject = "Leave Notification"
            message.IsBodyHtml = True
            message.Body = messageBody

            client.Host = "smtp.gmail.com"
            client.Port = 587
            client.UseDefaultCredentials = False
            client.EnableSsl = True
            client.Credentials = New Net.NetworkCredential(senderEmailAddress, senderEmailPassword)

            Dim userState As String = "userState"
            AddHandler client.SendCompleted, AddressOf SendCompletedCallback

            client.SendAsync(message, userState)

            StatusToolStripStatusLabel.Text = ""
            StatusToolStripStatusLabel.Text = "Sending email, do not close the application....."
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SendEmailEmployee(employeeId As Integer, screenDate As String, leaveTypeName As String, leaveDate As String, quantity As Integer, reason As String,
                                 diagnosis As String, isFitToWork As String)
        Try
            Dim client As New SmtpClient()
            Dim message As New MailMessage()
            Dim messageBody As String = "<font size=""3"" face=""Segoe UI"" color=""black"">" &
                                       "Good day! <br> <br> " &
                                       "Kindly apply your " & leaveTypeName & " to Leave Application System. Please check if the details below are correct. <br> <br> " &
                                       "<table style=""font-size: 20px;font-family:Segoe UI""> " &
                                       "<tr><td style=""width:10px""></td><td>Screen Date: </td><td style=""width:50px""></td><td>" & screenDate & "</td></tr>" &
                                       "<tr><td style=""width:10px""></td><td>Leave Date(s): </td><td style=""width:50px""></td><td>" & leaveDate & "</td></tr>" &
                                       "<tr><td style=""width:10px""></td><td>No. of Days: </td><td style=""width:50px""></td><td>" & quantity & "</td></tr>" &
                                       "<tr><td style=""width:10px""></td><td>Reason: </td><td style=""width:50px""></td><td>" & reason & "</td></tr>" &
                                       "<tr><td style=""width:10px""></td><td>Diagnosis: </td><td style=""width:50px""></td><td>" & diagnosis & "</td></tr>" &
                                       "<tr><td style=""width:10px""></td><td>Fit To Work: </td><td style=""width:50px""></td><td>" & isFitToWork & "</td></tr>" &
                                       "</table>" &
                                       "<br>" &
                                       "If you have any concerns, please call IT (Local 232). Thank you." &
                                       "<br> <br>" &
                                       "<em>This is a system-generated email. Please do not reply.</em>"

            message.From = New MailAddress(senderEmailAddress, "NBC Leave Notification")

            Dim prmRequestor(0) As SqlParameter
            prmRequestor(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            prmRequestor(0).Value = employeeId

            Using reader As IDataReader = dbJeonsoft.ExecuteReader("SELECT TRIM(EmailAddress) AS EmailAddress FROM dbo.tblEmployees WHERE Id = @EmployeeId",
                                                                  CommandType.Text, prmRequestor)
                While reader.Read
                    If reader.Item("EmailAddress") Is DBNull.Value Then
                        message.To.Add(devEmailAddress)
                    Else
                        If HealthInformationSystem.My.MySettings.Default.IsDebug = True Then
                            message.To.Add(devEmailAddress)
                        Else
                            message.To.Add(reader.Item("EmailAddress").ToString.Trim)
                        End If
                    End If
                End While
                reader.Close()
            End Using

            message.To.Add(devEmailAddress)

            message.Subject = "Leave Notification"
            message.IsBodyHtml = True
            message.Body = messageBody

            client.Host = "smtp.gmail.com"
            client.Port = 587
            client.UseDefaultCredentials = False
            client.EnableSsl = True
            client.Credentials = New Net.NetworkCredential(senderEmailAddress, senderEmailPassword)

            Dim userState As String = "userState"
            AddHandler client.SendCompleted, AddressOf SendCompletedCallback

            client.SendAsync(message, userState)

            StatusToolStripStatusLabel.Text = ""
            StatusToolStripStatusLabel.Text = "Sending email, do not close the application....."
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

    'file
    Private Sub ConsultationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultationToolStripMenuItem.Click
        dbMain.FormLoader(Me, New Consultation(employeeId, isAdmin), True)
    End Sub

    Private Sub HealthScreeningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HealthScreeningToolStripMenuItem.Click
        dbMain.FormLoader(Me, New frmHealthScreeningHeader(employeeId), True)
    End Sub

    Private Sub IndiRecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IndiRecordToolStripMenuItem.Click
        dbMain.FormLoader(Me, New IndividualRecordHdr(employeeId), False)
    End Sub

    Private Sub GoodsReceiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoodsReceiveToolStripMenuItem.Click
        dbMain.FormLoader(Me, New ReceiveMedicine(employeeId), True)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'disable the resize or maximize button of the form if is currently maximized, enable if minimized
        AddHandler Me.SizeChanged, AddressOf frmMain_SizeEventHandler

        Me.MaximizeBox = False

        tmrMain.Start()
    End Sub

    Private Sub frmMain_MdiChildActivate(sender As Object, e As EventArgs) Handles MyBase.MdiChildActivate
        Dim _frm As Form = Me.ActiveMdiChild

        If Not _frm Is Nothing Then
            Me.Text = "Health Information System - " & _frm.Text & ""
        Else
            Me.Text = "Health Information System"
        End If
    End Sub
    'maximize the main form or MDI parent without hiding or overlapping the taskbar
    Private Sub frmMain_SizeEventHandler(sender As Object, e As EventArgs)
        If Me.WindowState = FormWindowState.Minimized Then
            Me.MaximizeBox = True

        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.MaximizeBox = False
        End If
    End Sub

    Private Sub GetSetting()
        Try
            Dim prm(0) As SqlParameter
            prm(0) = New SqlParameter("@SettingId", SqlDbType.Int)
            prm(0).Value = settingsId

            Using reader As IDataReader = dbHealth.ExecuteReader("SELECT * FROM dbo.Setting WHERE SettingId = @SettingId", CommandType.Text, prm)
                While reader.Read
                    senderEmailAddress = reader.Item("SenderEmail").ToString.Trim
                    senderEmailPassword = reader.Item("SenderEmailPassword").ToString.Trim
                    devEmailAddress = reader.Item("DevEmail").ToString.Trim
                    devEmailPassword = reader.Item("DevEmailPassword").ToString.Trim
                End While
                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Function HideStatus() As Task(Of Boolean)
        Await Task.Delay(2000)
        StatusToolStripStatusLabel.Text = ""
        Return True
    End Function

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Me.Hide()

        Login.Show()
        Login.BringToFront()
        Login.txtEmployeeId.Clear()
        Login.txtPassword.Clear()
    End Sub

    'report
    Private Sub EmployeeMonitoringToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultationLogsheetToolStripMenuItem.Click
        dbMain.FormLoader(Me, New ConsultationLogsheet, True)
    End Sub

    Private Async Sub SendCompletedCallback(sender As Object, e As AsyncCompletedEventArgs)
        Try
            Dim token As String = CStr(e.UserState)

            If e.Cancelled Then
                StatusToolStripStatusLabel.Text = "Sending canceled."
            End If

            If e.Error IsNot Nothing Then
                StatusToolStripStatusLabel.Text = e.Error.ToString
            Else
                StatusToolStripStatusLabel.Text = "Email sent, thank you."
            End If

            Await HideStatus()

            IsSent = True
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tmrMain_Tick(sender As Object, e As EventArgs) Handles tmrMain.Tick
        DatetimeToolStripMenuItem.Text = CDate(dbHealth.GetServerDate).ToString("dd MMMM yyyy")

        ShowNotification()
    End Sub

    Private Shared Sub PlayNotificationSound(ByVal sound As String)
        Dim dbMainLoc As New BlackCoffeeLibrary.Main

        Try
            Dim soundsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds")
            Dim soundFile = Path.Combine(soundsFolder, sound & ".wav")

            Using player = New Media.SoundPlayer(soundFile)
                player.Play()
            End Using
        Catch ex As Exception
            MessageBox.Show(dbMainLoc.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function GetCurrentAge(dob As Date) As Integer
        Dim age As Integer
        age = Today.Year - dob.Year
        If (dob > Today.AddYears(-age)) Then age -= 1
        Return age
    End Function

    Private Sub ShowNotification()
        Try
            Dim alarmCount As Integer = 0
            Dim currentDt As DateTime = dbHealth.GetServerDate

            Dim alarmTime, timeIn As DateTime
            Dim restMinutes, recordId As Integer
            Dim employeeName, roomName, bedName As String

            Dim prmCount(0) As SqlParameter
            prmCount(0) = New SqlParameter("@AlarmTime", SqlDbType.SmallDateTime)
            prmCount(0).Value = currentDt.ToString("yyyy-MM-dd HH:mm")

            alarmCount = dbHealth.ExecuteScalar("SELECT COUNT(RestAlarmId) FROM dbo.RestAlarm WHERE AlarmTime = @AlarmTime AND IsActive = 1", CommandType.Text, prmCount)

            If alarmCount > 0 Then
                Dim lstDtls As New List(Of String)
                Dim prmAlarm(0) As SqlParameter
                prmAlarm(0) = New SqlParameter("@AlarmTime", SqlDbType.SmallDateTime)
                prmAlarm(0).Value = currentDt.ToString("yyyy-MM-dd HH:mm")

                Using rdrAlarm As IDataReader = dbHealth.ExecuteReader("RdRestAlarmByAlarmTime", CommandType.StoredProcedure, prmAlarm)
                    While rdrAlarm.Read
                        alarmTime = rdrAlarm.Item("AlarmTime")
                        recordId = rdrAlarm.Item("RecordId")
                        employeeName = rdrAlarm.Item("EmployeeName")
                        roomName = rdrAlarm.Item("RoomName")
                        bedName = rdrAlarm.Item("BedNo")
                        timeIn = rdrAlarm.Item("DatetimeStarted")
                        restMinutes = rdrAlarm.Item("TotalRestTime")

                        If alarmTime.ToString("yyyy-MM-dd HH:mm:ss").Equals(currentDt.ToString("yyyy-MM-dd HH:mm:ss")) Then
                            lstDtls.Add(" Alarm Time: " & alarmTime)
                            lstDtls.Add(" Room: " & roomName)
                            lstDtls.Add(" Bed No: " & bedName)
                            lstDtls.Add(" Time-in: " & timeIn)
                            lstDtls.Add(" Rest Minutes: " & restMinutes)

                            Dim notification = New RestAlarm(employeeName,
                                                         lstDtls,
                                                         -1,
                                                         FormAnimator.AnimationMethod.Slide,
                                                         FormAnimator.AnimationDirection.Up,
                                                         employeeId,
                                                         recordId)
                            PlayNotificationSound("festival")
                            notification.Show()
                            lstDtls.Clear()

                            Dim prmBed(1) As SqlParameter
                            prmBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                            prmBed(0).Value = 1
                            prmBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                            prmBed(1).Value = rdrAlarm.Item("BedId")

                            dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmBed)

                            Dim prmRoom(0) As SqlParameter
                            prmRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                            prmRoom(0).Value = rdrAlarm.Item("RoomId")

                            dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmRoom)

                            Dim prmDisableAlarm(0) As SqlParameter
                            prmDisableAlarm(0) = New SqlParameter("@RestAlarmId", SqlDbType.Int)
                            prmDisableAlarm(0).Value = rdrAlarm.Item("RestAlarmId")

                            dbHealth.ExecuteNonQuery("UPDATE dbo.RestAlarm SET IsActive = 0 WHERE RestAlarmId = @RestAlarmId", CommandType.Text, prmDisableAlarm)
                        End If
                    End While
                    rdrAlarm.Close()
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Main_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.Control AndAlso e.KeyCode.Equals(Keys.F12) Then
                ShowNotification()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class