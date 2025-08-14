Imports BlackCoffeeLibrary
Imports HealthInformationSystem
Imports System.Data.SqlClient
Imports System.Deployment.Application
Imports System.IO

Public Class Main
    Private connection As New clsConnection
    Private dbHealth As New SqlDbMethod(connection.LeaveConnection)
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private settingsId As Integer = My.Settings.SettingsId

    Private arrSplitted() As String

    Private departmentName As String = String.Empty
    Private devEmailAddress As String = String.Empty
    Private devEmailPassword As String = String.Empty
    Private employeeCode As String = String.Empty
    Private employeeId As Integer = 0
    Private employeeName As String = String.Empty
    Private isAdmin As Boolean = False
    Private positionName As String = String.Empty
    Private senderEmailAddress As String = String.Empty
    Private senderEmailPassword As String = String.Empty
    Private teamName As String = String.Empty

    Public Sub New(employeeId As Integer, employeeCode As String, employeeName As String, departmentName As String, teamName As String, positionName As String, isAdmin As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.employeeId = employeeId
        Me.employeeCode = employeeCode
        Me.employeeName = employeeName
        Me.departmentName = departmentName
        Me.teamName = teamName
        Me.positionName = positionName
        Me.isAdmin = isAdmin

        UsernameToolStripMenuItem.Text = "  " & StrConv(Me.employeeName, VbStrConv.ProperCase)
        UserItemToolStripMenuItem.Text = Me.positionName

        If Me.departmentName.Equals(Me.teamName) Then
            DepartmentToolStripStatusLabel.Text = Me.departmentName
            SectionToolStripStatusLabel.Text = String.Empty
            SectionToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.None
        Else
            If String.IsNullOrWhiteSpace(Me.teamName) Then
                DepartmentToolStripStatusLabel.Text = Me.departmentName
                SectionToolStripStatusLabel.Text = String.Empty
                SectionToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.None
            Else
                DepartmentToolStripStatusLabel.Text = Me.departmentName
                SectionToolStripStatusLabel.Text = Me.teamName
            End If
        End If

        If My.MySettings.Default.IsDebug = True Then
            dbMain.FormLoader(Me, New Consultation(Me.employeeId), True)
        Else
            dbMain.FormLoader(Me, New Consultation(Me.employeeId), True)
        End If

        If ApplicationDeployment.IsNetworkDeployed Then
            VersionToolStripStatusLabel.Text = "Version " & ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
        Else
            VersionToolStripStatusLabel.Text = "Version " & Application.ProductVersion.ToString
        End If
    End Sub

    'https://www.vbforums.com/showthread.php?551628-Manual-MDI-Window-List-Menu
    Public Sub RefreshWindowList()
        ' Count windows and Menuitems
        Dim mdiWindowCount As Integer = Me.MdiChildren.Count
        Dim menuItemWindowCount As Integer = Me.WindowToolStripMenuItem.DropDownItems.Count

        ' Remove all WINDOW MenuItems from the Window menu, but don't remove the
        ' extra items such as Close and the separator (first two) and the last item
        Dim item As ToolStripItem
        For i As Integer = menuItemWindowCount - 1 To 0 Step -1
            item = Me.WindowToolStripMenuItem.DropDownItems(i)

            If Not (item Is CloseAllToolStripMenuItem _
                    Or item Is CloseToolStripSeparator) Then
                Me.WindowToolStripMenuItem.DropDownItems.RemoveAt(i)
            End If
        Next

        If mdiWindowCount > 0 Then
            Dim menuItem As ToolStripMenuItem
            Dim counter As Integer = 1
            ' Add the new window items
            For Each window As Form In Me.MdiChildren
                'Create new menuitem
                menuItem = New ToolStripMenuItem

                'Set the text to for example "2. Windowtext"
                menuItem.Text = counter.ToString & ". " & window.Text

                'Set the tag to the current window so we can retrieve it later
                menuItem.Tag = window

                'Check the menuitem if this is the currently active window
                If window Is Me.ActiveMdiChild Then
                    menuItem.Checked = True
                End If

                'Add a Click EventHandler to be able to click it
                AddHandler menuItem.Click, AddressOf WindowMenuItemClicked

                'Finally add it to the actual menuitem list
                Me.WindowToolStripMenuItem.DropDownItems.Insert(0 + Me.WindowToolStripMenuItem.DropDownItems.Count - 2, menuItem)

                'Raise the counter by 1
                counter += 1
            Next
        End If
    End Sub

    'prevent form resizing when double clicked the titlebar or dragged
    Protected Overloads Overrides Sub WndProc(ByRef m As Message)
        Const WM_NCLBUTTONDBLCLK As Integer = 163 'define doubleclick event
        Const WM_NCLBUTTONDOWN As Integer = 161 'define leftbuttondown event
        Const WM_SYSCOMMAND As Integer = 274 'define move action
        Const HTCAPTION As Integer = 2 'define that the WM_NCLBUTTONDOWN is at titlebar
        Const SC_MOVE As Integer = 61456 'trap move action
        'disable moving of title bar
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

    Private Sub CloseAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        Try
            For Each frm As Form In Me.MdiChildren
                frm.Close()
            Next
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConsultationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultationToolStripMenuItem.Click
        dbMain.FormLoader(Me, New Consultation(employeeId), True)
    End Sub

    Private Sub EmployeeMonitoringToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultationLogsheetToolStripMenuItem.Click
        dbMain.FormLoader(Me, New ConsultationLogsheet, True)
    End Sub

    Private Sub EmployeeRecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeRecordToolStripMenuItem.Click
        dbMain.FormLoader(Me, New EmployeeRecord(employeeId), True)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub Form_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrMain.Start()

        'disable the resize or maximize button of the form if the form is maximized, then enable if the form is minimized
        AddHandler Me.SizeChanged, AddressOf Form_SizeEventHandler
        Me.MaximizeBox = False
    End Sub

    Private Sub Form_MdiChildActivate(sender As Object, e As EventArgs) Handles MyBase.MdiChildActivate
        Dim activeForm As Form = Me.ActiveMdiChild

        If Not activeForm Is Nothing Then
            arrSplitted = Split(activeForm.Text.Trim, " - ", 2)
            Me.Text = "Health Information System - " & arrSplitted(0) & ""
        Else
            Me.Text = "Health Information System"
        End If
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Me.Hide()

        Login.Show()
        Login.BringToFront()
        Login.txtEmployeeId.Clear()
        Login.txtPassword.Clear()
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.Control AndAlso e.KeyCode.Equals(Keys.F12) Then
                ShowNotification()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'maximize the main form or MDI parent without hiding or overlapping the taskbar
    Private Sub Form_SizeEventHandler(ByVal sender As Object, ByVal e As EventArgs)
        If Me.WindowState = FormWindowState.Minimized Then
            Me.MaximizeBox = True

        ElseIf Me.WindowState = FormWindowState.Maximized Then
            Me.MaximizeBox = False
        End If
    End Sub

    Private Sub MedicineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MedicineToolStripMenuItem.Click
        dbMain.FormLoader(Me, New Medicine(employeeId))
    End Sub

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

    Private Sub tmrForm_Tick(sender As Object, e As EventArgs) Handles tmrMain.Tick
        DatetimeToolStripMenuItem.Text = CDate(dbHealth.GetServerDate).ToString("dd MMMM yyyy")
        ShowNotification()
    End Sub

    Private Sub WindowMenuItemClicked(ByVal sender As Object, ByVal e As EventArgs)
        'Retrieve the clicked MenuItem from the sender object
        Dim menuItem As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)

        'Retrieve the corresponding form from the Tag property
        Dim frm As Form = TryCast(menuItem.Tag, Form)

        'Activate it
        If frm IsNot Nothing Then
            frm.Activate()
        End If
    End Sub

    Private Sub WindowToolStripMenuItem_DropDownOpened(sender As Object, e As EventArgs) Handles WindowToolStripMenuItem.DropDownOpened
        RefreshWindowList()
    End Sub

    Public Sub ClickMedicineLogs()
        dbMain.FormLoader(Me, New MedicineLog)
    End Sub

    Private Sub DoctorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DoctorToolStripMenuItem.Click
        dbMain.FormLoader(Me, New Doctor(employeeId))
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NurseToolStripMenuItem.Click
        dbMain.FormLoader(Me, New Nurse(employeeId))
    End Sub

    Private Sub ScreeningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScreeningToolStripMenuItem.Click
        dbMain.FormLoader(Me, New ScreeningLogsheet, True)
    End Sub

    Private Sub LeaveReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeaveReportToolStripMenuItem.Click
        dbMain.FormLoader(Me, New LeaveLogsheet, True)
    End Sub
End Class