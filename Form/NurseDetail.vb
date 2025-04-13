Imports BlackCoffeeLibrary
Imports System.Data.SqlClient

Public Class NurseDetail
    Private connection As New clsConnection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.MyConnection)

    Private dtNurse As New DataTable

    Private orgEmployeeId As String = String.Empty

    Private attendantId As Integer = 0
    Private editingUserId As Integer = 0

    'the word `byte` is not a valid identifier
    Public Sub New(attendantId As Integer, Optional editingUserId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.editingUserId = editingUserId
        Me.attendantId = attendantId

        ' Load all HR personnels
        ' All clinic members were transferred to HR section
        LoadEmployee(1)
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

                Dim count As Integer = dbMethod.ExecuteScalar("CntNurseTrx", CommandType.StoredProcedure, prmCnt)

                If count > 0 Then
                    MessageBox.Show("This item contains records. Set to inactive instead.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                Dim question = String.Format("Are you sure you want to delete this item?")
                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim prmDel(0) As SqlParameter
                    prmDel(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                    prmDel(0).Value = editingUserId

                    dbMethod.ExecuteNonQuery("DelNurse", CommandType.StoredProcedure, prmDel)

                    Me.DialogResult = DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If cmbEmployeeName.SelectedValue = 0 Then
                MessageBox.Show("Employee name is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbEmployeeName.Focus()
                Return
            End If

            If editingUserId = 0 Then 'new record
                If IsExistsEmployeeId(cmbEmployeeName.SelectedValue) = True Then
                    MessageBox.Show("Employee already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    cmbEmployeeName.Focus()
                    Return
                End If

                Dim prm(0) As SqlParameter
                prm(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                prm(0).Value = cmbEmployeeName.SelectedValue

                dbMethod.ExecuteNonQuery("InsNurse", CommandType.StoredProcedure, prm)

            Else 'old record
                If Not cmbEmployeeName.Text.Trim.Equals(orgEmployeeId) Then
                    If IsExistsEmployeeId(cmbEmployeeName.SelectedValue) = True Then
                        MessageBox.Show("Employee already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        cmbEmployeeName.Focus()
                        Return
                    End If
                End If

                Dim prm(1) As SqlParameter
                prm(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                prm(0).Value = cmbEmployeeName.SelectedValue
                prm(1) = New SqlParameter("@EditingEmployeeId", SqlDbType.Int)
                prm(1).Value = editingUserId

                dbMethod.ExecuteNonQuery("UpdNurse", CommandType.StoredProcedure, prm)
            End If

            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsExistsEmployeeId(employeeId As Integer) As Boolean
        Dim count As Integer = 0

        Try
            Dim prmCnt(0) As SqlParameter
            prmCnt(0) = New SqlParameter("@EmployeeId", SqlDbType.VarChar)
            prmCnt(0).Value = employeeId

            count = dbMethod.ExecuteScalar("SELECT COUNT(EmployeeId) FROM dbo.Nurse WHERE EmployeeId = @EmployeeId", CommandType.Text, prmCnt)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F8) Then
            e.Handled = True
            btnDelete.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If editingUserId = 0 Then
                Me.Text = "New User Entry"
                cmbEmployeeName.SelectedValue = 0
            Else
                Me.Text = "User No. " & editingUserId

                Dim prm(0) As SqlParameter
                prm(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                prm(0).Value = editingUserId

                dtNurse = dbMethod.FillDataTable("RdEmployee", CommandType.StoredProcedure, prm)

                For Each row As DataRow In dtNurse.Rows
                    txtCreatedBy.Text = row("CreatedByName")
                    txtCreatedDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("CreatedDate"))

                    If Not row("ModifiedByName") Is DBNull.Value Then
                        txtModifiedBy.Text = row("ModifiedByName")
                    End If

                    If Not row("ModifiedDate") Is DBNull.Value Then
                        txtModifiedDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("ModifiedDate"))
                    End If

                    txtEmployeeCode.Text = row("EmployeeCode")

                    orgEmployeeId = row("EmployeeId")
                    cmbEmployeeName.SelectedValue = row("EmployeeId")
                    txtPosition.Text = row("PositionName")

                    If row("IsActive") Then
                        txtStatus.Text = "Active"
                    Else
                        txtStatus.Text = "Inactive"
                    End If

                    If row("IsAdmin") Then
                        txtIsAdmin.Text = "Yes"
                    Else
                        txtIsAdmin.Text = "No"
                    End If
                Next
            End If

            Me.ActiveControl = cmbEmployeeName
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadEmployee(id As Integer)
        Try
            dbMethod.FillCmbWithCaption("RdEmployee", CommandType.StoredProcedure, "EmployeeId", "EmployeeName", cmbEmployeeName, "< Select Employee >")
            AddHandler cmbEmployeeName.Validating, AddressOf cmbEmployeeName_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbEmployeeName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbEmployeeName.Validating
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbEmployeeName.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbEmployeeName_Validated(sender As Object, e As EventArgs) Handles cmbEmployeeName.Validated
        Try
            If cmbEmployeeName.Text.Trim.Length = 0 Or cmbEmployeeName.SelectedValue = 0 Then
                cmbEmployeeName.SelectedValue = 0
                cmbEmployeeName.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbEmployeeName_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEmployeeName.SelectedValueChanged
        If Not cmbEmployeeName.SelectedValue = 0 Then
            Dim prm(0) As SqlParameter
            prm(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            prm(0).Value = cmbEmployeeName.SelectedValue

            dtNurse = dbMethod.FillDataTable("RdEmployee", CommandType.StoredProcedure, prm)

            For Each row As DataRow In dtNurse.Rows
                txtCreatedBy.Text = row("CreatedByName")
                txtCreatedDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("CreatedDate"))

                If Not row("ModifiedByName") Is DBNull.Value Then
                    txtModifiedBy.Text = row("ModifiedByName")
                End If

                If Not row("ModifiedDate") Is DBNull.Value Then
                    txtModifiedDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("ModifiedDate"))
                End If

                txtEmployeeCode.Text = row("EmployeeCode")

                cmbEmployeeName.SelectedValue = row("EmployeeId")
                txtPosition.Text = row("PositionName")

                If row("IsActive") Then
                    txtStatus.Text = "Active"
                Else
                    txtStatus.Text = "Inactive"
                End If

                If row("IsAdmin") Then
                    txtIsAdmin.Text = "Yes"
                Else
                    txtIsAdmin.Text = "No"
                End If
            Next
        End If
    End Sub

End Class