Imports BlackCoffeeLibrary
Imports HealthInformationSystem
Imports System.Data.SqlClient
Imports System.IO

Public Class EmployeeRecord
    Private connection As New clsConnection
    Private directory As New clsDirectory
    Private dbHealth As New SqlDbMethod(connection.LeaveConnection)
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private imgList As New List(Of clsAttachment)

    Private attachDirApe As String = directory.AttDirApeRecord

    Private bsEmployeeApe As New BindingSource
    Private dtEmployeeApe As New DataTable
    Private dtEmployeeRecord As New DataTable

    Private pageSize As Integer
    Private pageIndex As Integer
    Private totalCount As Integer
    Private pageCount As Integer
    Private indexScroll As Integer = 0
    Private indexPosition As Integer = 0

    Private attendantId As Integer = 0

    Public Sub New(attendantId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.attendantId = attendantId
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbJeonsoft.FillCmbWithCaption("SELECT Id, (TRIM(EmployeeCode) + '  ' + (FirstName + ' ' + ISNULL(SUBSTRING(CASE WHEN LEN(TRIM(MiddleName)) = 0 " &
                                      "THEN NULL WHEN TRIM(MiddleName) = '-' THEN NULL ELSE TRIM(MiddleName) END, 1, 1) + '. ' , '') + LastName)) AS Name " &
                                      "FROM dbo.tblEmployees WHERE Active = 1 And EmployeeCode IS NOT NULL", CommandType.Text, "Id", "Name", cmbName, "")

        pageIndex = 0
        pageSize = 100

        If My.Settings.IsDebug Then
            cmbName.SelectedValue = 806
        End If

        Me.dgvApe.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        dbMain.EnableDoubleBuffered(dgvApe)
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                e.Handled = True
                btnAdd.PerformClick()
            Case Keys.F3
                e.Handled = True
                btnEdit.PerformClick()
            Case Keys.F4
                e.Handled = True
            Case Keys.F8
                e.Handled = True
                btnDelete.PerformClick()
            Case Keys.F10
                e.Handled = True
                btnSave.PerformClick()
        End Select
    End Sub

    Private Sub tabCtrl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabCtrl.SelectedIndexChanged
        Select Case tabCtrl.SelectedIndex
            Case 0
                BindPageApe()
        End Select
    End Sub

    Private Sub cmbName_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbName.SelectedValueChanged
        If Not cmbName.SelectedValue = 0 Then
            ResetForm(False)
            GetEmployeeInformation(cmbName.SelectedValue)
            pageIndex = 0

            Select Case tabCtrl.SelectedIndex
                Case 0
                    BindPageApe()
            End Select
        Else
            ResetForm(True)
        End If
    End Sub

    Private Sub cmbName_Validated(sender As Object, e As EventArgs) Handles cmbName.Validated
        If cmbName.Text.Trim.Length = 0 Or cmbName.SelectedValue = 0 Then
            cmbName.SelectedValue = 0
            cmbName.Focus()
        End If
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvApe.CellDoubleClick
        btnEdit.PerformClick()
    End Sub

    Private Sub dgv_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvApe.DataError
        e.Cancel = False
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim prmUpdate(21) As SqlParameter
            prmUpdate(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            prmUpdate(0).Value = cmbName.SelectedValue

            If String.IsNullOrEmpty(txtContactNumber.Text.Trim) Then
                prmUpdate(1) = New SqlParameter("@ContactNumber", SqlDbType.NVarChar)
                prmUpdate(1).Value = Nothing
            Else
                prmUpdate(1) = New SqlParameter("@ContactNumber", SqlDbType.NVarChar)
                prmUpdate(1).Value = txtContactNumber.Text.ToString.Trim
            End If

            If String.IsNullOrEmpty(txtBloodType.Text.Trim) Then
                prmUpdate(2) = New SqlParameter("@BloodType", SqlDbType.NVarChar)
                prmUpdate(2).Value = Nothing
            Else
                prmUpdate(2) = New SqlParameter("@BloodType", SqlDbType.NVarChar)
                prmUpdate(2).Value = txtBloodType.Text.ToString.Trim
            End If

            If String.IsNullOrEmpty(txtEmerContactName.Text.Trim) Then
                prmUpdate(3) = New SqlParameter("@EmergencyContactName", SqlDbType.NVarChar)
                prmUpdate(3).Value = Nothing
            Else
                prmUpdate(3) = New SqlParameter("@EmergencyContactName", SqlDbType.NVarChar)
                prmUpdate(3).Value = txtEmerContactName.Text.ToString.Trim
            End If

            If String.IsNullOrEmpty(txtEmerContactNumber.Text.Trim) Then
                prmUpdate(4) = New SqlParameter("@EmergencyContactNumber", SqlDbType.NVarChar)
                prmUpdate(4).Value = Nothing
            Else
                prmUpdate(4) = New SqlParameter("@EmergencyContactNumber", SqlDbType.NVarChar)
                prmUpdate(4).Value = txtEmerContactNumber.Text.ToString.Trim
            End If

            If String.IsNullOrEmpty(txtEmerContactAddress.Text.Trim) Then
                prmUpdate(5) = New SqlParameter("@EmergencyContactAddress", SqlDbType.NVarChar)
                prmUpdate(5).Value = Nothing
            Else
                prmUpdate(5) = New SqlParameter("@EmergencyContactAddress", SqlDbType.NVarChar)
                prmUpdate(5).Value = txtEmerContactAddress.Text.ToString.Trim
            End If

            If String.IsNullOrEmpty(txtAllergies.Text.Trim) Then
                prmUpdate(6) = New SqlParameter("@Allergies", SqlDbType.NVarChar)
                prmUpdate(6).Value = Nothing
            Else
                prmUpdate(6) = New SqlParameter("@Allergies", SqlDbType.NVarChar)
                prmUpdate(6).Value = txtAllergies.Text.ToString.Trim
            End If

            If String.IsNullOrEmpty(txtMedHistory.Text.Trim) Then
                prmUpdate(7) = New SqlParameter("@PastMedicalHistory", SqlDbType.NVarChar)
                prmUpdate(7).Value = Nothing
            Else
                prmUpdate(7) = New SqlParameter("@PastMedicalHistory", SqlDbType.NVarChar)
                prmUpdate(7).Value = txtMedHistory.Text.ToString.Trim
            End If

            If String.IsNullOrEmpty(txtSurgHistory.Text.Trim) Then
                prmUpdate(8) = New SqlParameter("@SurgicalHistory", SqlDbType.NVarChar)
                prmUpdate(8).Value = Nothing
            Else
                prmUpdate(8) = New SqlParameter("@SurgicalHistory", SqlDbType.NVarChar)
                prmUpdate(8).Value = txtSurgHistory.Text.ToString.Trim
            End If

            If String.IsNullOrEmpty(txtMenarche.Text.Trim) Then
                prmUpdate(9) = New SqlParameter("@ObMenarche", SqlDbType.NVarChar)
                prmUpdate(9).Value = Nothing
            Else
                prmUpdate(9) = New SqlParameter("@ObMenarche", SqlDbType.NVarChar)
                prmUpdate(9).Value = txtMenarche.Text.ToString.Trim
            End If

            If String.IsNullOrEmpty(txtInterval.Text.Trim) Then
                prmUpdate(10) = New SqlParameter("@ObInterval", SqlDbType.NVarChar)
                prmUpdate(10).Value = Nothing
            Else
                prmUpdate(10) = New SqlParameter("@ObInterval", SqlDbType.NVarChar)
                prmUpdate(10).Value = txtInterval.Text.ToString.Trim
            End If

            If String.IsNullOrEmpty(txtDuration.Text.Trim) Then
                prmUpdate(11) = New SqlParameter("@ObDuration", SqlDbType.NVarChar)
                prmUpdate(11).Value = Nothing
            Else
                prmUpdate(11) = New SqlParameter("@ObDuration", SqlDbType.NVarChar)
                prmUpdate(11).Value = txtDuration.Text.ToString.Trim
            End If

            If String.IsNullOrEmpty(txtAmount.Text.Trim) Then
                prmUpdate(12) = New SqlParameter("@ObAmount", SqlDbType.NVarChar)
                prmUpdate(12).Value = Nothing
            Else
                prmUpdate(12) = New SqlParameter("@ObAmount", SqlDbType.NVarChar)
                prmUpdate(12).Value = txtAmount.Text.ToString.Trim
            End If

            If String.IsNullOrEmpty(txtSymptoms.Text.Trim) Then
                prmUpdate(13) = New SqlParameter("@ObSymptoms", SqlDbType.NVarChar)
                prmUpdate(13).Value = Nothing
            Else
                prmUpdate(13) = New SqlParameter("@ObSymptoms", SqlDbType.NVarChar)
                prmUpdate(13).Value = txtSymptoms.Text.ToString.Trim
            End If

            If String.IsNullOrEmpty(txtG.Text.Trim) Then
                prmUpdate(14) = New SqlParameter("@G", SqlDbType.NVarChar)
                prmUpdate(14).Value = Nothing
            Else
                prmUpdate(14) = New SqlParameter("@G", SqlDbType.NVarChar)
                prmUpdate(14).Value = txtG.Text.ToString.Trim
            End If

            If String.IsNullOrEmpty(txtP.Text.Trim) Then
                prmUpdate(15) = New SqlParameter("@P", SqlDbType.NVarChar)
                prmUpdate(15).Value = Nothing
            Else
                prmUpdate(15) = New SqlParameter("@P", SqlDbType.NVarChar)
                prmUpdate(15).Value = txtP.Text.ToString.Trim
            End If

            If String.IsNullOrEmpty(txtGp.Text.Trim) Then
                prmUpdate(16) = New SqlParameter("@PNumber", SqlDbType.NVarChar)
                prmUpdate(16).Value = Nothing
            Else
                prmUpdate(16) = New SqlParameter("@PNumber", SqlDbType.NVarChar)
                prmUpdate(16).Value = txtGp.Text.ToString.Trim
            End If

            If String.IsNullOrEmpty(txtG1.Text.Trim) Then
                prmUpdate(17) = New SqlParameter("@G1", SqlDbType.NVarChar)
                prmUpdate(17).Value = Nothing
            Else
                prmUpdate(17) = New SqlParameter("@G1", SqlDbType.NVarChar)
                prmUpdate(17).Value = txtG1.Text.ToString.Trim
            End If

            If String.IsNullOrEmpty(txtG2.Text.Trim) Then
                prmUpdate(18) = New SqlParameter("@G2", SqlDbType.NVarChar)
                prmUpdate(18).Value = Nothing
            Else
                prmUpdate(18) = New SqlParameter("@G2", SqlDbType.NVarChar)
                prmUpdate(18).Value = txtG2.Text.ToString.Trim
            End If

            prmUpdate(19) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
            prmUpdate(19).Value = attendantId
            prmUpdate(20) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime)
            prmUpdate(20).Value = dbHealth.GetServerDate

            If String.IsNullOrEmpty(txtMaintenance.Text.Trim) Then
                prmUpdate(21) = New SqlParameter("@Maintenance", SqlDbType.NVarChar)
                prmUpdate(21).Value = Nothing
            Else
                prmUpdate(21) = New SqlParameter("@Maintenance", SqlDbType.NVarChar)
                prmUpdate(21).Value = txtMaintenance.Text.ToString.Trim
            End If

            dbHealth.ExecuteNonQuery("UpdEmployeeByEmployeeId", CommandType.StoredProcedure, prmUpdate)

            ResetForm(True)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ResetForm(True)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If cmbName.SelectedValue = 0 Then Exit Sub

            Select Case tabCtrl.SelectedIndex
                Case 0
                    Using frmDetail As New ApeDetail(cmbName.SelectedValue, attendantId)
                        If frmDetail.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                            RefreshList()
                        End If
                    End Using
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If cmbName.SelectedValue = 0 Then Exit Sub

            Select Case tabCtrl.SelectedIndex
                Case 0
                    If dgvApe.SelectedRows.Count > 0 Then
                        Dim recordId As Integer = CType(Me.bsEmployeeApe.Current, DataRowView).Item("RecordId")

                        Using frmDetail As New ApeDetail(cmbName.SelectedValue, attendantId, recordId)
                            frmDetail.ShowDialog(Me)

                            If frmDetail.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                RefreshList()
                            End If
                        End Using
                    End If
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If cmbName.SelectedValue = 0 Then Exit Sub

            Dim question As String = "Are you sure you want to delete this record?"

            Select Case tabCtrl.SelectedIndex
                Case 0
                    If dgvApe.SelectedRows.Count > 0 AndAlso dgvApe.SelectedRows.Count > 0 Then
                        Dim recordId As Integer = CType(Me.bsEmployeeApe.Current, DataRowView).Item("RecordId")
                        Dim patientId As Integer = CType(Me.bsEmployeeApe.Current, DataRowView).Item("EmployeeId")

                        If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) =
                            System.Windows.Forms.DialogResult.Yes Then

                            Dim prmCount(0) As SqlParameter
                            prmCount(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                            prmCount(0).Value = recordId

                            Dim attachmentCount As Integer = dbHealth.ExecuteScalar("CntEmployeeApeAttachmentByRecordId", CommandType.StoredProcedure, prmCount)

                            If attachmentCount > 0 Then
                                Dim prm(0) As SqlParameter
                                prm(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                                prm(0).Value = recordId

                                dtEmployeeRecord = dbHealth.FillDataTable("RdEmployeeApeAttachmentByRecordId", CommandType.StoredProcedure, prm)

                                For i As Integer = 0 To dtEmployeeRecord.Rows.Count - 1
                                    Dim oldPic As New clsAttachment(attachDirApe & "\" & dtEmployeeRecord.Rows(i).Item("Filename").ToString,
                                                                    dtEmployeeRecord.Rows(i).Item("Filename").ToString,
                                                                    Path.GetExtension(dtEmployeeRecord.Rows(i).Item("Filename")).ToLower,
                                                                    dtEmployeeRecord.Rows(i).Item("AttachmentId"))
                                    imgList.Add(oldPic)
                                Next

                                If imgList.Count > 0 Then
                                    For i As Integer = 0 To imgList.Count - 1
                                        Dim ext As String = String.Empty
                                        Dim newName As String = String.Empty
                                        ext = Path.GetExtension(imgList(i).FileName).ToLower
                                        newName = patientId & "-" & recordId & "-" & imgList(i).AttachmentId & ext
                                        File.Delete(attachDirApe & "\" & newName)
                                    Next
                                End If
                            End If

                            Dim prmDel(0) As SqlParameter
                            prmDel(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                            prmDel(0).Value = recordId

                            dbHealth.ExecuteNonQuery("DelEmployeeApeRecordId", CommandType.StoredProcedure, prmDel)
                        End If
                    End If
            End Select

            imgList.Clear()
            RefreshList()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            RefreshList()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles btnFirstItem.Click
        pageIndex = 0

        Select Case tabCtrl.SelectedIndex
            Case 0
                BindPageApe()
        End Select
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles btnPrevItem.Click
        pageIndex -= 1
        If pageIndex < 0 Then
            pageIndex = 0
        End If

        Select Case tabCtrl.SelectedIndex
            Case 0
                BindPageApe()
        End Select
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles btnNextItem.Click
        pageIndex += 1
        If pageIndex > pageCount - 1 Then
            pageIndex = pageCount - 1
        End If

        Select Case tabCtrl.SelectedIndex
            Case 0
                BindPageApe()
        End Select
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles btnLastItem.Click
        pageIndex = pageCount - 1

        Select Case tabCtrl.SelectedIndex
            Case 0
                BindPageApe()
        End Select
    End Sub

    Private Sub txtPageNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPageNumber.KeyPress
        If ((Asc(e.KeyChar) >= 48 AndAlso Asc(e.KeyChar) <= 57) OrElse Asc(e.KeyChar) = 8 OrElse Asc(e.KeyChar) = 13 OrElse Asc(e.KeyChar) = 127) Then
            e.Handled = False
            If Asc(e.KeyChar) = 13 Then
                Go()
            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Go()
    End Sub

    Private Sub GetEmployeeInformation(employeeId As Integer)
        Try
            Dim prmEmployee(0) As SqlParameter
            prmEmployee(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            prmEmployee(0).Value = employeeId

            Using rdrEmployee As IDataReader = dbHealth.ExecuteReader("RdEmployeeByEmployeeId", CommandType.StoredProcedure, prmEmployee)
                While rdrEmployee.Read
                    txtDepartment.Text = rdrEmployee.Item("DepartmentName").ToString.Trim
                    txtSection.Text = rdrEmployee.Item("TeamName").ToString.Trim
                    txtPosition.Text = rdrEmployee.Item("PositionName").ToString.Trim
                    txtEmploymentStatus.Text = rdrEmployee.Item("EmploymentTypeName").ToString.Trim
                    txtCivilStatus.Text = rdrEmployee.Item("MaritalStatusName").ToString.Trim
                    txtAge.Text = GetCurrentAge(rdrEmployee.Item("BirthDate"))
                    txtAddress.Text = rdrEmployee.Item("AddressLocal").ToString.Trim
                    txtContactNumber.Text = rdrEmployee.Item("ContactNumber").ToString.Trim
                    txtBloodType.Text = rdrEmployee.Item("BloodType").ToString.Trim
                    txtAllergies.Text = rdrEmployee.Item("Allergies").ToString.Trim
                    txtEmerContactName.Text = rdrEmployee.Item("EmergencyContactName").ToString.Trim
                    txtEmerContactNumber.Text = rdrEmployee.Item("EmergencyContactNumber").ToString.Trim
                    txtEmerContactAddress.Text = rdrEmployee.Item("EmergencyContactAddress").ToString.Trim
                    txtMedHistory.Text = rdrEmployee.Item("PastMedicalHistory").ToString.Trim
                    txtSurgHistory.Text = rdrEmployee.Item("SurgicalHistory").ToString.Trim
                    txtMenarche.Text = rdrEmployee.Item("ObMenarche").ToString.Trim
                    txtInterval.Text = rdrEmployee.Item("ObInterval").ToString.Trim
                    txtDuration.Text = rdrEmployee.Item("ObDuration").ToString.Trim
                    txtAmount.Text = rdrEmployee.Item("ObAmount").ToString.Trim
                    txtSymptoms.Text = rdrEmployee.Item("ObSymptoms").ToString.Trim
                    txtG.Text = rdrEmployee.Item("G").ToString.Trim
                    txtP.Text = rdrEmployee.Item("P").ToString.Trim
                    txtGp.Text = rdrEmployee.Item("PNumber").ToString.Trim
                    txtG1.Text = rdrEmployee.Item("G1").ToString.Trim
                    txtG2.Text = rdrEmployee.Item("G1").ToString.Trim
                    txtMaintenance.Text = rdrEmployee.Item("Maintenance").ToString.Trim
                End While
                rdrEmployee.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BindPageApe()
        Try
            totalCount = 0

            Dim prm(3) As SqlParameter
            prm(0) = New SqlParameter("@PageIndex", SqlDbType.Int)
            prm(0).Value = pageIndex
            prm(1) = New SqlParameter("@PageSize", SqlDbType.Int)
            prm(1).Value = pageSize
            prm(2) = New SqlParameter("@TotalCount", SqlDbType.Int)
            prm(2).Direction = ParameterDirection.Output
            prm(2).Value = totalCount
            prm(3) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            prm(3).Value = cmbName.SelectedValue

            dtEmployeeApe = dbHealth.FillDataTable("RdEmployeeApeByEmployeeId", CommandType.StoredProcedure, prm)

            Me.bsEmployeeApe.DataSource = dtEmployeeApe
            Me.bsEmployeeApe.ResetBindings(True)
            Me.dgvApe.AutoGenerateColumns = False
            Me.dgvApe.DataSource = Me.bsEmployeeApe

            If totalCount Mod pageSize = 0 Then
                If totalCount = 0 Then
                    pageCount = (totalCount / pageSize) + 1
                Else
                    pageCount = totalCount / pageSize
                End If
            Else
                pageCount = Math.Truncate(totalCount / pageSize) + 1
            End If

            'current page index and total number of pages
            txtPageNumber.Enabled = True
            txtTotalPageNumber.Enabled = True
            txtPageNumber.Text = pageIndex + 1
            txtTotalPageNumber.Text = "of " & CInt(pageCount) & " Page(s)"

            'enables pager
            txtPageNumber.Enabled = True
            txtTotalPageNumber.Enabled = True
            btnFirstItem.Enabled = True
            btnPrevItem.Enabled = True
            btnNextItem.Enabled = True
            btnLastItem.Enabled = True
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetScrollingIndex()
        Select Case tabCtrl.SelectedIndex
            Case 0
                indexScroll = dgvApe.FirstDisplayedCell.RowIndex
                indexPosition = dgvApe.CurrentRow.Index
        End Select
    End Sub

    Private Sub SetScrollingIndex()
        Select Case tabCtrl.SelectedIndex
            Case 0
                dgvApe.FirstDisplayedScrollingRowIndex = indexScroll
                If dgvApe.Rows.Count > indexPosition Then
                    dgvApe.Rows(indexPosition).Selected = True
                Else
                    dgvApe.Rows(indexPosition - 1).Selected = True
                End If
                Me.bsEmployeeApe.Position = dgvApe.SelectedCells(0).RowIndex
        End Select
    End Sub

    Public Sub RefreshList()
        Select Case tabCtrl.SelectedIndex
            Case 0
                If dgvApe IsNot Nothing AndAlso dgvApe.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))
                pageIndex = 0
                BindPageApe()
                If dgvApe IsNot Nothing AndAlso dgvApe.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf SetScrollingIndex))
        End Select
    End Sub

    Private Sub Go()
        Try
            If String.IsNullOrEmpty(txtPageNumber.Text) Then
                MessageBox.Show("Page not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPageNumber.Focus()
                Return
            End If

            If CInt(txtPageNumber.Text) > pageCount Then
                MessageBox.Show("Page not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPageNumber.Focus()
                Return
            End If

            If CInt(txtPageNumber.Text) = 0 Then
                MessageBox.Show("Page not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPageNumber.Focus()
                Return
            End If

            pageIndex = CInt(txtPageNumber.Text) - 1

            Select Case tabCtrl.SelectedIndex
                Case 0

                Case 1
                    BindPageApe()
            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetForm(isEmpty As Boolean)
        If isEmpty Then
            Me.ActiveControl = cmbName

            txtDepartment.Text = String.Empty
            txtSection.Text = String.Empty
            txtPosition.Text = String.Empty
            txtEmploymentStatus.Text = String.Empty
            txtAge.Text = String.Empty
            txtAddress.Text = String.Empty
            txtCivilStatus.Text = String.Empty
            txtContactNumber.Text = String.Empty
            txtBloodType.Text = String.Empty
            txtAllergies.Text = String.Empty
            txtMedHistory.Text = String.Empty
            txtSurgHistory.Text = String.Empty
            txtMenarche.Text = String.Empty
            txtInterval.Text = String.Empty
            txtDuration.Text = String.Empty
            txtAmount.Text = String.Empty
            txtSymptoms.Text = String.Empty
            txtG.Text = String.Empty
            txtP.Text = String.Empty
            txtGp.Text = String.Empty
            txtG1.Text = String.Empty
            txtG2.Text = String.Empty
            txtMaintenance.Text = String.Empty
            txtEmerContactName.Text = String.Empty
            txtEmerContactNumber.Text = String.Empty
            txtEmerContactAddress.Text = String.Empty

            tabCtrl.Enabled = False
            cmbName.SelectedValue = 0

            dtEmployeeRecord.Clear()
            dtEmployeeApe.Clear()
            dgvApe.DataSource = Nothing
            dgvApe.DataSource = dtEmployeeApe

        Else
            txtContactNumber.ReadOnly = False
            txtBloodType.ReadOnly = False
            txtAllergies.ReadOnly = False
            txtMedHistory.ReadOnly = False
            txtSurgHistory.ReadOnly = False
            txtMenarche.ReadOnly = False
            txtInterval.ReadOnly = False
            txtDuration.ReadOnly = False
            txtAmount.ReadOnly = False
            txtSymptoms.ReadOnly = False
            txtG.ReadOnly = False
            txtP.ReadOnly = False
            txtGp.ReadOnly = False
            txtG1.ReadOnly = False
            txtG2.ReadOnly = False
            txtMaintenance.ReadOnly = False
            txtEmerContactName.ReadOnly = False
            txtEmerContactNumber.ReadOnly = False
            txtEmerContactAddress.ReadOnly = False

            tabCtrl.Enabled = True
        End If

        tabCtrl.SelectedTab = tpApe
    End Sub

    Public Function GetCurrentAge(dob As Date) As Integer
        Dim age As Integer

        Try
            age = Today.Year - dob.Year
            If (dob > Today.AddYears(-age)) Then age -= 1
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return age
    End Function

End Class