Imports BlackCoffeeLibrary
Imports System.Data.SqlClient

Public Class DoctorDetail
    Private connection As New clsConnection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.MyConnection)

    Private dtClinic As New DataTable

    Private orgEmployeeCode As String = String.Empty

    Private attendantId As Integer = 0
    Private editingUserId As Integer = 0

    'the word `byte` is not a valid identifier
    Public Sub New(attendantId As Integer, Optional editingUserId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.editingUserId = editingUserId
        Me.attendantId = attendantId
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If editingUserId > 0 Then
                Dim prmCnt(0) As SqlParameter
                prmCnt(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                prmCnt(0).Value = editingUserId

                Dim count As Integer = dbMethod.ExecuteScalar("CntClinicTrx", CommandType.StoredProcedure, prmCnt)

                If count > 0 Then
                    MessageBox.Show("This item contains records. Set to inactive instead.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                Dim question = String.Format("Are you sure you want to delete this item?")
                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim prmDel(0) As SqlParameter
                    prmDel(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                    prmDel(0).Value = editingUserId

                    dbMethod.ExecuteNonQuery("DelClinic", CommandType.StoredProcedure, prmDel)

                    Me.DialogResult = DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(txtEmployeeCode.Text.Trim) Then
                MessageBox.Show("Badge number is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmployeeCode.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtEmployeeName.Text.Trim) Then
                MessageBox.Show("Name is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmployeeName.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtPositionName.Text.Trim) Then
                MessageBox.Show("Position is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPositionName.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtPassword.Text.Trim) Then
                MessageBox.Show("Password is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPassword.Focus()
                Return
            End If

            If editingUserId = 0 Then 'new record
                If IsExistsEmployeeCode(txtEmployeeCode.Text.Trim) = True Then
                    MessageBox.Show("Badge number already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtEmployeeCode.Focus()
                    Return
                End If

                Dim prm(9) As SqlParameter
                prm(0) = New SqlParameter("@CreatedBy", SqlDbType.Int)
                prm(0).Value = attendantId
                prm(1) = New SqlParameter("@CreatedDate", SqlDbType.DateTime)
                prm(1).Value = dbMethod.GetServerDate
                prm(2) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
                prm(2).Value = txtEmployeeCode.Text.Trim
                prm(3) = New SqlParameter("@EmployeeName", SqlDbType.NVarChar)
                prm(3).Value = txtEmployeeName.Text.Trim
                prm(4) = New SqlParameter("@DepartmentName", SqlDbType.NVarChar)
                prm(4).Value = "Human Resource"
                prm(5) = New SqlParameter("@TeamName", SqlDbType.NVarChar)
                prm(5).Value = "Clinic"
                prm(6) = New SqlParameter("@PositionName", SqlDbType.NVarChar)
                prm(6).Value = "Company Doctor"
                prm(7) = New SqlParameter("@Password", SqlDbType.NVarChar)
                prm(7).Value = txtPassword.Text.Trim
                prm(8) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prm(8).Value = IIf(rdActive.Checked = True, True, False)
                prm(9) = New SqlParameter("@IsAdmin", SqlDbType.Bit)
                prm(9).Value = IIf(rdYes.Checked = True, True, False)

                dbMethod.ExecuteNonQuery("InsClinic", CommandType.StoredProcedure, prm)

            Else 'old record
                If Not txtEmployeeCode.Text.Trim.Equals(orgEmployeeCode) Then
                    If IsExistsEmployeeCode(txtEmployeeCode.Text.Trim) = True Then
                        MessageBox.Show("Badge number already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtEmployeeCode.Focus()
                        Return
                    End If
                End If

                Dim prm(8) As SqlParameter
                prm(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                prm(0).Value = editingUserId
                prm(1) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
                prm(1).Value = txtEmployeeCode.Text.Trim
                prm(2) = New SqlParameter("@EmployeeName", SqlDbType.NVarChar)
                prm(2).Value = txtEmployeeName.Text.Trim
                prm(3) = New SqlParameter("@PositionName", SqlDbType.NVarChar)
                prm(3).Value = txtPositionName.Text.Trim
                prm(4) = New SqlParameter("@Password", SqlDbType.NVarChar)
                prm(4).Value = txtPassword.Text.Trim
                prm(5) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                prm(5).Value = attendantId
                prm(6) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime)
                prm(6).Value = dbMethod.GetServerDate

                prm(7) = New SqlParameter("@IsActive", SqlDbType.Bit)
                If rdActive.Checked Then
                    prm(7).Value = True
                Else
                    prm(7).Value = False
                End If

                prm(8) = New SqlParameter("@IsAdmin", SqlDbType.Bit)
                If rdYes.Checked Then
                    prm(8).Value = True
                Else
                    prm(8).Value = False
                End If

                dbMethod.ExecuteNonQuery("UpdClinic", CommandType.StoredProcedure, prm)
            End If

            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsExistsEmployeeCode(employeeCode As String) As Boolean
        Dim count As Integer = 0

        Try
            Dim prmCnt(0) As SqlParameter
            prmCnt(0) = New SqlParameter("@EmployeeCode", SqlDbType.VarChar)
            prmCnt(0).Value = employeeCode

            count = dbMethod.ExecuteScalar("SELECT COUNT(EmployeeId) FROM dbo.Clinic WHERE TRIM(EmployeeCode) = @EmployeeCode", CommandType.Text, prmCnt)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Doctor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F8) Then
            e.Handled = True
            btnDelete.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub DoctorDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If editingUserId = 0 Then
                Me.Text = "New User Entry"
                rdActive.Checked = True
                rdNo.Checked = True
            Else
                Me.Text = "User No. " & editingUserId

                Dim prm(0) As SqlParameter
                prm(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                prm(0).Value = editingUserId

                dtClinic = dbMethod.FillDataTable("SELECT * FROM VwClinic WHERE EmployeeId = @EmployeeId", CommandType.Text, prm)

                For Each row As DataRow In dtClinic.Rows
                    txtCreatedBy.Text = row("CreatedByName")
                    txtCreatedDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("CreatedDate"))

                    If Not row("ModifiedByName") Is DBNull.Value Then
                        txtModifiedBy.Text = row("ModifiedByName")
                    End If

                    If Not row("ModifiedDate") Is DBNull.Value Then
                        txtModifiedDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("ModifiedDate"))
                    End If

                    orgEmployeeCode = row("EmployeeCode")
                    txtEmployeeCode.Text = row("EmployeeCode")
                    txtEmployeeName.Text = row("EmployeeName")
                    txtPositionName.Text = row("PositionName")
                    txtPassword.Text = row("Password")

                    If row("IsActive") = True Then
                        rdActive.Checked = True
                    Else
                        rdInactive.Checked = True
                    End If

                    If row("IsAdmin") = True Then
                        rdYes.Checked = True
                    Else
                        rdNo.Checked = True
                    End If
                Next
            End If

            Me.ActiveControl = txtEmployeeCode
            txtEmployeeCode.Select(txtEmployeeCode.Text.Trim.Length, 0)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class