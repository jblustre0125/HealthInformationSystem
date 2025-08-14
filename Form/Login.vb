Imports BlackCoffeeLibrary
Imports HealthInformationSystem
Imports System.Data.SqlClient
Imports System.Deployment.Application

Public Class Login
    Private connection As New clsConnection
    Private dbHealth As New SqlDbMethod(connection.LeaveConnection)
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private settingsId As Integer = My.Settings.SettingsId

    Private departmentName As String = String.Empty
    Private employeeCode As String = String.Empty
    Private employeeId As Integer = 0
    Private employeeName As String = String.Empty
    Private isAdmin As Boolean = False
    Private positionName As String = String.Empty
    Private teamName As String = String.Empty

    Dim imgHide As Image = My.Resources.password_hide_blue
    Dim imgShow As Image = My.Resources.password_show_blue

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If Not String.IsNullOrWhiteSpace(txtEmployeeId.Text.Trim) Or Not String.IsNullOrWhiteSpace(txtPassword.Text.Trim) Then
            If MessageBox.Show("Do you want to quit the application?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Application.Exit()
            End If
        Else
            Application.Exit()
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            If ApplicationDeployment.IsNetworkDeployed Then
                If Not My.Computer.Network.IsAvailable Then
                    MessageBox.Show("No network connection.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End If

            If String.IsNullOrEmpty(txtEmployeeId.Text.Trim) Then
                MessageBox.Show("Please enter your employee ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmployeeId.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtPassword.Text.Trim) Then
                MessageBox.Show("Please enter your password.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPassword.Focus()
                Return
            End If

            Dim count As Integer = 0
            Dim prmCount(1) As SqlParameter
            prmCount(0) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
            prmCount(0).Value = txtEmployeeId.Text.Trim
            prmCount(1) = New SqlParameter("@Password", SqlDbType.NVarChar)
            prmCount(1).Value = txtPassword.Text.Trim

            count = dbHealth.ExecuteScalar("SELECT COUNT(EmployeeId) FROM VwClinicAll WHERE TRIM(EmployeeCode) = @EmployeeCode AND " &
                                           "(TRIM(Password) COLLATE Latin1_General_CS_AS = @Password) AND IsActive = 1", CommandType.Text, prmCount)

            If count > 0 Then
                Dim prmRdr(1) As SqlParameter
                prmRdr(0) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
                prmRdr(0).Value = txtEmployeeId.Text.Trim
                prmRdr(1) = New SqlParameter("@Password", SqlDbType.NVarChar)
                prmRdr(1).Value = txtPassword.Text.Trim

                Using rdrClinic As IDataReader = dbHealth.ExecuteReader("RdClinicAll", CommandType.StoredProcedure, prmRdr)
                    While rdrClinic.Read
                        employeeId = rdrClinic("EmployeeId")
                        employeeCode = rdrClinic("EmployeeCode")
                        employeeName = rdrClinic("EmployeeName")
                        departmentName = IIf(rdrClinic("DepartmentName") Is DBNull.Value, GetDefaultDepartmentName, rdrClinic("DepartmentName"))
                        teamName = IIf(rdrClinic("TeamName") Is DBNull.Value, GetDefaultTeamName, rdrClinic("TeamName"))
                        positionName = rdrClinic("PositionName")
                        isAdmin = rdrClinic("IsAdmin")
                    End While
                    rdrClinic.Close()
                End Using

                Me.Hide()

                Dim frmMain As New Main(employeeId, employeeCode, employeeName, departmentName, teamName, positionName, isAdmin)
                frmMain.Show()
                txtEmployeeId.Clear()
                txtPassword.Clear()
            Else
                MessageBox.Show("Incorrect employeee ID or password.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmployeeId.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        ActiveControl = txtEmployeeId
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        If ApplicationDeployment.IsNetworkDeployed Then
            lblVersion.Text = "ver. " & ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
        Else
            lblVersion.Text = "ver. " & Application.ProductVersion.ToString
        End If

        picPassword.Image = imgHide
        txtPassword.UseSystemPasswordChar = True
        txtPassword.PasswordChar = "●"

        Me.ActiveControl = txtEmployeeId
    End Sub

    Private Function GetDefaultDepartmentName()
        Dim deptName As String = String.Empty

        Try
            Dim prmDep(0) As SqlParameter
            prmDep(0) = New SqlParameter("@SettingId", SqlDbType.Int)
            prmDep(0).Value = settingsId

            deptName = dbHealth.ExecuteScalar("SELECT TRIM(DefaultDepartmentName) FROM dbo.Setting WHERE SettingId = @SettingId", CommandType.Text, prmDep)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return deptName
    End Function

    Private Function GetDefaultTeamName()
        Dim teamName As String = String.Empty

        Try
            Dim prmDep(0) As SqlParameter
            prmDep(0) = New SqlParameter("@SettingId", SqlDbType.Int)
            prmDep(0).Value = settingsId

            teamName = dbHealth.ExecuteScalar("SELECT TRIM(DefaultTeamName) FROM dbo.Setting WHERE SettingId = @SettingId", CommandType.Text, prmDep)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return teamName
    End Function

    Private Sub picPassword_Click(sender As Object, e As EventArgs) Handles picPassword.Click
        If picPassword.Image Is imgHide Then
            picPassword.Image = imgShow
            txtPassword.UseSystemPasswordChar = False
            txtPassword.PasswordChar = ""
        Else
            picPassword.Image = imgHide
            txtPassword.UseSystemPasswordChar = True
            txtPassword.PasswordChar = "●"
        End If
    End Sub

End Class