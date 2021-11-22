Imports System.Deployment.Application
Imports BlackCoffeeLibrary
Imports System.Data.SqlClient

Public Class frmLogin
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

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        ''doc omman
        'txtEmployeeId.Text = "FMB-0451"
        'txtPassword.Text = "1001"

        'mam irene
        'txtEmployeeId.Text = "1805-003"
        'txtPassword.Text = "torejas"

        If ApplicationDeployment.IsNetworkDeployed Then
            lblVersion.Text = "ver. " & ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString
        Else
            lblVersion.Text = "ver. " & Application.ProductVersion.ToString
        End If

        Me.ActiveControl = txtEmployeeId
    End Sub

    Private Sub frmLogin_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        ActiveControl = txtEmployeeId
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
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

            Dim _count As Integer = 0
            Dim _prm1(1) As SqlParameter
            _prm1(0) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
            _prm1(0).Value = txtEmployeeId.Text.Trim
            _prm1(1) = New SqlParameter("@Password", SqlDbType.NVarChar)
            _prm1(1).Value = txtPassword.Text.Trim

            _count = dbHealth.ExecuteScalar("SELECT COUNT(EmployeeId) FROM VwClinic WHERE TRIM(EmployeeCode) = @EmployeeCode AND " & _
                                            "(TRIM(Password) COLLATE Latin1_General_CS_AS = @Password)", CommandType.Text, _prm1)

            If _count > 0 Then
                Dim _prm2(1) As SqlParameter
                _prm2(0) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
                _prm2(0).Value = txtEmployeeId.Text.Trim
                _prm2(1) = New SqlParameter("@Password", SqlDbType.NVarChar)
                _prm2(1).Value = txtPassword.Text.Trim

                Dim _reader As IDataReader = dbHealth.ExecuteReader("RdClinicCombined", CommandType.StoredProcedure, _prm2)

                While _reader.Read
                    employeeId = _reader.Item("EmployeeId")
                    employeeCode = _reader.Item("EmployeeCode").ToString.Trim
                    employeeName = _reader.Item("EmployeeName").ToString.Trim
                    positionName = _reader.Item("PositionName").ToString.Trim
                End While
                _reader.Close()

                Dim _prm3(0) As SqlParameter
                _prm3(0) = New SqlParameter("@SettingsId", SqlDbType.Int)
                _prm3(0).Value = HealthInformationSystem.My.Settings.SettingsId

                Dim _reader2 As IDataReader = dbHealth.ExecuteReader("SELECT TRIM(DefaultDepartmentName) AS DefaultDepartmentName, TRIM(DefaultSectionName) AS DefaultSectionName " & _
                                                                     "FROM Settings WHERE SettingsId = @SettingsId", CommandType.Text, _prm3)

                While _reader2.Read
                    departmentName = _reader2.Item("DefaultDepartmentName").ToString.Trim
                    teamName = _reader2.Item("DefaultSectionName").ToString.Trim
                End While
                _reader2.Close()

                Me.Hide()

                Dim frmMain As New frmMain(employeeId, employeeCode, employeeName, positionName, departmentName, teamName)
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

End Class