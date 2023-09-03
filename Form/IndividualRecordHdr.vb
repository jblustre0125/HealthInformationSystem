Imports BlackCoffeeLibrary
Imports HealthInformationSystem.dsHealth
Imports HealthInformationSystem.dsHealthTableAdapters
Imports System.Data.SqlClient
Imports System.IO

Public Class IndividualRecordHdr
    Private connection As New clsConnection
    Private directories As New clsDirectory
    Private dbHealth As New SqlDbMethod(connection.MyConnection)
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private pageSize As Integer
    Private pageIndex As Integer
    Private totalCount As Integer
    Private pageCount As Integer
    Private indexScroll As Integer = 0
    Private indexPosition As Integer = 0

    Private dsHealth As New dsHealth
    Private adpEmpMedRec As New EmployeeMedicalRecordTableAdapter
    Private adpEmpMedAttach As New EmployeeMedicalAttachmentTableAdapter
    Private adpEmpApe As New EmployeeApeTableAdapter
    Private adpEmpApeAttach As New EmployeeApeAttachmentTableAdapter
    Private dtEmpMedRec As New EmployeeMedicalRecordDataTable
    Private dtEmpMedAttach As New EmployeeMedicalAttachmentDataTable
    Private dtEmpApe As New EmployeeApeDataTable
    Private dtEmpApeAttach As New EmployeeApeAttachmentDataTable
    Private bsEmpMedRec As New BindingSource
    Private bsEmployeeApe As New BindingSource

    Private imgList As New List(Of clsAttachment)
    Private attendantId As Integer = 0

    Private iniDirMedicalRecord As String = directories.IniDirMedRecord
    Private attachDirMedicalRecord As String = directories.AttDirMedRecord
    Private iniDirApe As String = directories.IniDirApeRecord
    Private attachDirApe As String = directories.AttDirApeRecord

    Public Sub New(_attendantId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        attendantId = _attendantId
    End Sub

    Private Sub frmEmployeeRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbJeonsoft.FillCmbWithCaption("SELECT Id, (TRIM(EmployeeCode) + '  ' + (FirstName + ' ' + ISNULL(SUBSTRING(CASE WHEN LEN(TRIM(MiddleName)) = 0 " &
                                      "THEN NULL WHEN TRIM(MiddleName) = '-' THEN NULL ELSE TRIM(MiddleName) END, 1, 1) + '. ' , '') + LastName)) AS Name " &
                                      "FROM dbo.tblEmployees WHERE Active = 1 And EmployeeCode IS NOT NULL", CommandType.Text, "Id", "Name", cmbName, "")

        pageIndex = 0
        pageSize = 100

        Me.dgvApe.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        dbMain.EnableDoubleBuffered(dgvApe)

        If HealthInformationSystem.My.MySettings.Default.IsDebug = True Then
            cmbName.SelectedValue = 806
            tabCtrl.SelectedTab = tpApe
        End If
    End Sub

    Private Sub frmEmployeeRecord_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            Dim prmUpdate(6) As SqlParameter
            prmUpdate(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            prmUpdate(0).Value = cmbName.SelectedValue
            prmUpdate(1) = New SqlParameter("@ContactNumber", SqlDbType.NVarChar)
            prmUpdate(1).Value = txtContactNumber.Text.ToString.Trim
            prmUpdate(2) = New SqlParameter("@BloodType", SqlDbType.NVarChar)
            prmUpdate(2).Value = txtBloodType.Text.ToString.Trim
            prmUpdate(3) = New SqlParameter("@EmergencyContactName", SqlDbType.NVarChar)
            prmUpdate(3).Value = txtEmerContactName.Text.ToString.Trim
            prmUpdate(4) = New SqlParameter("@EmergencyContactNumber", SqlDbType.NVarChar)
            prmUpdate(4).Value = txtEmerContactNumber.Text.ToString.Trim
            prmUpdate(5) = New SqlParameter("@EmergencyContactAddress", SqlDbType.NVarChar)
            prmUpdate(5).Value = txtEmerContactAddress.Text.ToString.Trim
            prmUpdate(6) = New SqlParameter("@Allergies", SqlDbType.NVarChar)
            prmUpdate(6).Value = txtAllergies.Text.ToString.Trim

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
                    Using frmDetail As New Ape(cmbName.SelectedValue, attendantId)
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
                        Dim _recordId As Integer = CType(Me.bsEmployeeApe.Current, DataRowView).Item("RecordId")
                        Using frmDetail As New Ape(cmbName.SelectedValue, attendantId, _recordId)
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
                        Dim recordId As Integer = CType(Me.bsEmpMedRec.Current, DataRowView).Item("RecordId")
                        Dim patientId As Integer = CType(Me.bsEmpMedRec.Current, DataRowView).Item("EmployeeId")

                        If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
                            Dim attachmentCount As Integer = Me.adpEmpApeAttach.CntEmployeeApeAttachmentByRecordId(recordId)
                            If attachmentCount > 0 Then
                                dtEmpApeAttach = Me.adpEmpApeAttach.GetEmployeeApeAttachmentByRecordId(recordId)
                                For i As Integer = 0 To dtEmpApeAttach.Count - 1
                                    Dim oldPic As New clsAttachment(attachDirApe & "\" & dtEmpApeAttach.Rows(i).Item("Filename").ToString,
                                                 dtEmpApeAttach.Rows(i).Item("Filename").ToString, Path.GetExtension(dtEmpApeAttach.Rows(i).Item("Filename")).ToLower,
                                                 dtEmpApeAttach.Rows(i).Item("AttachmentId"))
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

                            Me.bsEmployeeApe.RemoveCurrent()
                        End If
                    End If
                    Me.adpEmpApe.Update(Me.dsHealth.EmployeeApe)
            End Select

            imgList.Clear()
            Me.dsHealth.AcceptChanges()
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

            Me.adpEmpApe.FillEmployeeApeByEmployeeId(Me.dsHealth.EmployeeApe, pageIndex, pageSize, totalCount, cmbName.SelectedValue)

            Me.bsEmployeeApe.DataSource = Me.dsHealth
            Me.bsEmployeeApe.DataMember = dtEmpApe.TableName
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
        If isEmpty = True Then
            Me.ActiveControl = cmbName

            txtDepartment.Text = String.Empty
            txtSection.Text = String.Empty
            txtPosition.Text = String.Empty
            txtEmploymentStatus.Text = String.Empty
            txtAge.Text = String.Empty
            txtAddress.Text = String.Empty
            txtCivilStatus.Text = String.Empty
            txtContactNumber.ReadOnly = True
            txtBloodType.ReadOnly = True
            txtAllergies.ReadOnly = True
            txtEmerContactName.ReadOnly = True
            txtEmerContactNumber.ReadOnly = True
            txtEmerContactAddress.ReadOnly = True

            txtContactNumber.Text = String.Empty
            txtBloodType.Text = String.Empty
            txtAllergies.Text = String.Empty
            txtEmerContactName.Text = String.Empty
            txtEmerContactNumber.Text = String.Empty
            txtEmerContactAddress.Text = String.Empty

            tabCtrl.Enabled = False
            cmbName.SelectedValue = 0

            dtEmpMedRec.Clear()

            dgvApe.DataSource = Nothing
            dtEmpApe.Clear()
            dgvApe.DataSource = dtEmpApe.TableName

        Else
            txtContactNumber.ReadOnly = False
            txtBloodType.ReadOnly = False
            txtAllergies.ReadOnly = False
            txtEmerContactName.ReadOnly = False
            txtEmerContactNumber.ReadOnly = False
            txtEmerContactAddress.ReadOnly = False

            tabCtrl.Enabled = True
        End If

        tabCtrl.SelectedTab = tpApe
    End Sub

    Public Function GetCurrentAge(dob As Date) As Integer
        Dim age As Integer
        age = Today.Year - dob.Year
        If (dob > Today.AddYears(-age)) Then age -= 1
        Return age
    End Function

End Class