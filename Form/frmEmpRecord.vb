Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Deployment.Application
Imports BlackCoffeeLibrary
Imports HealthInformationSystem
Imports HealthInformationSystem.dsHealth
Imports HealthInformationSystem.dsHealthTableAdapters
Imports System.IO

Public Class frmEmpRecord
    Private connection As New clsConnection
    Private directories As New clsDirectory
    Private dbHealth As New SqlDbMethod(connection.MyConnection)
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)
    Private dbMain As New Main

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

    Private imgList As New List(Of clsPicture)
    Private attendantId As Integer = 0

    Private iniDirMedicalRecord As String = directories.IniDirMedRecord
    Private attachDirMedicalRecord As String = directories.AttDirMedRecord
    Private iniDirApe As String = directories.IniDirApeRecord
    Private attachDirApe As String = directories.AttDirApeRecord

    Public Sub New(ByVal _attendantId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        attendantId = _attendantId
    End Sub

    Private Sub frmEmployeeRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbJeonsoft.FillCmbWithCaption("SELECT Id, (TRIM(EmployeeCode) + '  ' + (FirstName + ' ' + ISNULL(SUBSTRING(CASE WHEN LEN(TRIM(MiddleName)) = 0 THEN NULL WHEN TRIM(MiddleName) = '-' THEN NULL ELSE TRIM(MiddleName) END, 1, 1) + '. ' , '') + LastName)) AS Name FROM dbo.tblEmployees WHERE Active = 1 AND EmployeeCode IS NOT NULL", CommandType.Text, "Id", "Name", cmbName, "")
        pageIndex = 0
        pageSize = 100
        ResetForm(True)

        Me.dgvMed.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvMed.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dgvApe.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        dbMain.EnableDoubleBuffered(dgvMed)
        dbMain.EnableDoubleBuffered(dgvApe)

        'cmbName.SelectedValue = 806
    End Sub

    Private Sub frmEmployeeRecord_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                e.Handled = True
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
            Case Keys.F2
                e.Handled = True
                btnAdd.PerformClick()
            Case Keys.F3
                e.Handled = True
                btnEdit.PerformClick()
            Case Keys.F8
                e.Handled = True
                btnDelete.PerformClick()
            Case Keys.F10
                e.Handled = True
                btnSave.PerformClick()
        End Select
    End Sub

    Private Sub cmbName_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbName.SelectedValueChanged
        If Not cmbName.SelectedValue = 0 Then
            ResetForm(False)
            GetEmployeeInformation(cmbName.SelectedValue)
            pageIndex = 0

            Select Case tabCtrl.SelectedIndex
                Case 0
                    BindPageMedRecord()
                Case 1
                    BindPageApe()
                Case 2

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

    Private Sub dgvTransactionHeader_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMed.CellDoubleClick
        btnEdit.PerformClick()
    End Sub

    Private Sub dgvApe_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvApe.CellDoubleClick
        btnEdit.PerformClick()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim _prmUpdate(5) As SqlParameter
            _prmUpdate(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            _prmUpdate(0).Value = cmbName.SelectedValue
            _prmUpdate(1) = New SqlParameter("@BloodType", SqlDbType.NVarChar)
            _prmUpdate(1).Value = txtBloodType.Text.ToString.Trim
            _prmUpdate(2) = New SqlParameter("@EmergencyContactName", SqlDbType.NVarChar)
            _prmUpdate(2).Value = txtEmerContactName.Text.ToString.Trim
            _prmUpdate(3) = New SqlParameter("@EmergencyContactNumber", SqlDbType.NVarChar)
            _prmUpdate(3).Value = txtEmerContactNumber.Text.ToString.Trim
            _prmUpdate(4) = New SqlParameter("@EmergencyContactAddress", SqlDbType.NVarChar)
            _prmUpdate(4).Value = txtEmerContactAddress.Text.ToString.Trim
            _prmUpdate(5) = New SqlParameter("@Allergies", SqlDbType.NVarChar)
            _prmUpdate(5).Value = txtAllergies.Text.ToString.Trim

            dbHealth.ExecuteNonQuery("UpdEmployeeByEmployeeId", CommandType.StoredProcedure, _prmUpdate)

            ResetForm(True)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
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
                    Using frmDetail As New frmEmpRecordDetail(cmbName.SelectedValue, attendantId)
                        frmDetail.ShowDialog(Me)
                        If frmDetail.DialogResult = System.Windows.Forms.DialogResult.OK Then
                            RefreshList()
                        End If
                    End Using

                Case 1
                    Using frmDetail As New frmEmpApeDetail(cmbName.SelectedValue, attendantId)
                        frmDetail.ShowDialog(Me)
                        If frmDetail.DialogResult = System.Windows.Forms.DialogResult.OK Then
                            RefreshList()
                        End If
                    End Using

                Case 2

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
                    If dgvMed.SelectedRows.Count > 0 Then
                        Dim _recordId As Integer = CType(Me.bsEmpMedRec.Current, DataRowView).Item("RecordId")
                        Using frmDetail As New frmEmpRecordDetail(cmbName.SelectedValue, attendantId, _recordId)
                            frmDetail.ShowDialog(Me)
                            If frmDetail.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                RefreshList()
                            End If
                        End Using
                    End If

                Case 1
                    If dgvApe.SelectedRows.Count > 0 Then
                        Dim _recordId As Integer = CType(Me.bsEmployeeApe.Current, DataRowView).Item("RecordId")
                        Using frmDetail As New frmEmpApeDetail(cmbName.SelectedValue, attendantId, _recordId)
                            frmDetail.ShowDialog(Me)
                            If frmDetail.DialogResult = System.Windows.Forms.DialogResult.OK Then
                                RefreshList()
                            End If
                        End Using
                    End If

                Case 2

            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If cmbName.SelectedValue = 0 Then Exit Sub

            Select Case tabCtrl.SelectedIndex
                Case 0
                    If dgvMed.SelectedRows.Count > 0 Then
                        Dim _question As String = "Are you sure you want to delete this record?"
                        Dim _recordId As Integer = CType(Me.bsEmpMedRec.Current, DataRowView).Item("RecordId")
                        Dim _patientId As Integer = CType(Me.bsEmpMedRec.Current, DataRowView).Item("EmployeeId")

                        If MessageBox.Show(_question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
                            Dim _attachmentCount As Integer = Me.adpEmpMedAttach.CntEmployeeMedicalAttachmentByRecordId(_recordId)
                            If _attachmentCount > 0 Then
                                dtEmpMedAttach = Me.adpEmpMedAttach.GetEmployeeMedicalAttachmentByRecordId(_recordId)
                                For i As Integer = 0 To dtEmpMedAttach.Count - 1
                                    Dim _oldPic As New clsPicture(attachDirMedicalRecord & "\" & dtEmpMedAttach.Rows(i).Item("Filename").ToString,
                                                 dtEmpMedAttach.Rows(i).Item("Filename").ToString,
                                                 dtEmpMedAttach.Rows(i).Item("AttachmentId"))
                                    imgList.Add(_oldPic)
                                Next

                                If imgList.Count > 0 Then
                                    For _i As Integer = 0 To imgList.Count - 1
                                        Dim _ext As String = String.Empty
                                        Dim _newName As String = String.Empty
                                        _ext = Path.GetExtension(imgList(_i).FileName).ToLower
                                        _newName = _patientId & "-" & _recordId & "-" & imgList(_i).AttachmentId & _ext
                                        File.Delete(attachDirMedicalRecord & "\" & _newName)
                                    Next
                                End If
                            End If

                            Me.bsEmpMedRec.RemoveCurrent()
                        End If
                    End If
                    Me.adpEmpMedRec.Update(Me.dsHealth.EmployeeMedicalRecord)

                Case 1
                    If dgvApe.SelectedRows.Count > 0 Then
                        Dim _question As String = "Are you sure you want to delete this record?"
                        If MessageBox.Show(_question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
                            Me.bsEmployeeApe.RemoveCurrent()
                        End If
                    End If
                    Me.adpEmpApe.Update(Me.dsHealth.EmployeeApe)

                Case 2

            End Select

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

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        Go()
    End Sub

    Private Sub GetEmployeeInformation(ByVal _employeeId As Integer)
        Try
            Dim _prm(0) As SqlParameter
            _prm(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            _prm(0).Value = _employeeId

            Dim _reader As IDataReader = dbHealth.ExecuteReader("RdEmployeeByEmployeeId", CommandType.StoredProcedure, _prm)

            While _reader.Read
                txtDepartment.Text = _reader.Item("DepartmentName").ToString.Trim
                txtSection.Text = _reader.Item("TeamName").ToString.Trim
                txtPosition.Text = _reader.Item("PositionName").ToString.Trim
                txtEmploymentStatus.Text = _reader.Item("EmploymentTypeName").ToString.Trim
                txtCivilStatus.Text = _reader.Item("MaritalStatusName").ToString.Trim
                txtAge.Text = GetCurrentAge(_reader.Item("BirthDate"))
                txtAddress.Text = _reader.Item("AddressLocal").ToString.Trim
                txtBloodType.Text = _reader.Item("BloodType").ToString.Trim
                txtAllergies.Text = _reader.Item("Allergies").ToString.Trim
                txtEmerContactName.Text = _reader.Item("EmergencyContactName").ToString.Trim
                txtEmerContactNumber.Text = _reader.Item("EmergencyContactNumber").ToString.Trim
                txtEmerContactAddress.Text = _reader.Item("EmergencyContactAddress").ToString.Trim
            End While
            _reader.Close()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BindPageMedRecord()
        Try
            totalCount = 0

            Me.adpEmpMedRec.FillEmployeeMedicalRecordByEmployeeId(Me.dsHealth.EmployeeMedicalRecord, pageIndex, pageSize, totalCount, cmbName.SelectedValue)

            Me.bsEmpMedRec.DataSource = Me.dsHealth
            Me.bsEmpMedRec.DataMember = dtEmpMedRec.TableName
            Me.bsEmpMedRec.ResetBindings(True)
            Me.dgvMed.AutoGenerateColumns = False
            Me.dgvMed.DataSource = Me.bsEmpMedRec

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
            txtPageNumber.Text = pageIndex + 1
            txtTotalPageNumber.Text = "of " & CInt(pageCount) & " Page(s)"

            'enables pager
            txtPageNumber.Enabled = True
            txtTotalPageNumber.Enabled = True
            BindingNavigatorMoveFirstItem.Enabled = True
            BindingNavigatorMovePreviousItem.Enabled = True
            BindingNavigatorMoveNextItem.Enabled = True
            BindingNavigatorMoveLastItem.Enabled = True
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
            txtPageNumber.Text = pageIndex + 1
            txtTotalPageNumber.Text = "of " & CInt(pageCount) & " Page(s)"

            'enables pager
            txtPageNumber.Enabled = True
            txtTotalPageNumber.Enabled = True
            BindingNavigatorMoveFirstItem.Enabled = True
            BindingNavigatorMovePreviousItem.Enabled = True
            BindingNavigatorMoveNextItem.Enabled = True
            BindingNavigatorMoveLastItem.Enabled = True
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
                    BindPageMedRecord()
                Case 1
                    BindPageApe()
                Case 2

            End Select
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub RefreshList()
        Select Case tabCtrl.SelectedIndex
            Case 0
                If dgvMed IsNot Nothing AndAlso dgvMed.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))
                pageIndex = 0
                BindPageMedRecord()
                If dgvMed IsNot Nothing AndAlso dgvMed.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf SetScrollingIndex))

            Case 1
                If dgvApe IsNot Nothing AndAlso dgvApe.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf GetScrollingIndex))
                pageIndex = 0
                BindPageApe()
                If dgvApe IsNot Nothing AndAlso dgvApe.CurrentRow IsNot Nothing Then Me.Invoke(New Action(AddressOf SetScrollingIndex))

            Case 2

        End Select
    End Sub

    Private Sub GetScrollingIndex()
        Select Case tabCtrl.SelectedIndex
            Case 0
                indexScroll = dgvMed.FirstDisplayedCell.RowIndex
                indexPosition = dgvMed.CurrentRow.Index

            Case 1
                indexScroll = dgvApe.FirstDisplayedCell.RowIndex
                indexPosition = dgvApe.CurrentRow.Index

            Case 2

        End Select
    End Sub

    Private Sub SetScrollingIndex()
        Select Case tabCtrl.SelectedIndex
            Case 0
                dgvMed.FirstDisplayedScrollingRowIndex = indexScroll
                If dgvMed.Rows.Count > indexPosition Then
                    dgvMed.Rows(indexPosition).Selected = True
                Else
                    dgvMed.Rows(indexPosition - 1).Selected = True
                End If
                Me.bsEmpMedRec.Position = dgvMed.SelectedCells(0).RowIndex

            Case 1
                dgvApe.FirstDisplayedScrollingRowIndex = indexScroll
                If dgvApe.Rows.Count > indexPosition Then
                    dgvApe.Rows(indexPosition).Selected = True
                Else
                    dgvApe.Rows(indexPosition - 1).Selected = True
                End If
                Me.bsEmployeeApe.Position = dgvApe.SelectedCells(0).RowIndex

            Case 2

        End Select
    End Sub

    Private Sub ResetForm(ByVal _isEmpty As Boolean)
        If _isEmpty = True Then
            Me.ActiveControl = cmbName

            txtDepartment.Text = String.Empty
            txtSection.Text = String.Empty
            txtPosition.Text = String.Empty
            txtEmploymentStatus.Text = String.Empty
            txtAge.Text = String.Empty
            txtAddress.Text = String.Empty
            txtCivilStatus.Text = String.Empty
            txtBloodType.ReadOnly = True
            txtAllergies.ReadOnly = True
            txtEmerContactName.ReadOnly = True
            txtEmerContactNumber.ReadOnly = True
            txtEmerContactAddress.ReadOnly = True

            txtBloodType.Text = String.Empty
            txtAllergies.Text = String.Empty
            txtEmerContactName.Text = String.Empty
            txtEmerContactNumber.Text = String.Empty
            txtEmerContactAddress.Text = String.Empty

            tabCtrl.Enabled = False
            cmbName.SelectedValue = 0

            dgvMed.DataSource = Nothing
            dtEmpMedRec.Clear()
            dgvMed.DataSource = dtEmpMedRec.TableName

            dgvApe.DataSource = Nothing
            dtEmpApe.Clear()
            dgvApe.DataSource = dtEmpApe.TableName
        Else
            txtBloodType.ReadOnly = False
            txtAllergies.ReadOnly = False
            txtEmerContactName.ReadOnly = False
            txtEmerContactNumber.ReadOnly = False
            txtEmerContactAddress.ReadOnly = False

            tabCtrl.Enabled = True
        End If

        tabCtrl.SelectedTab = tabPage1
    End Sub

    Public Function GetCurrentAge(ByVal _dateOfBirth As Date) As Integer
        Dim _age As Integer
        _age = Today.Year - _dateOfBirth.Year
        If (_dateOfBirth > Today.AddYears(-_age)) Then _age -= 1
        Return _age
    End Function

    Private Sub dgvMed_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvMed.DataError
        e.Cancel = False
    End Sub

    Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
        pageIndex = 0

        Select Case tabCtrl.SelectedIndex
            Case 0
                BindPageMedRecord()
            Case 1
                BindPageApe()
            Case 2

        End Select
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        pageIndex -= 1
        If pageIndex < 0 Then
            pageIndex = 0
        End If

        Select Case tabCtrl.SelectedIndex
            Case 0
                BindPageMedRecord()
            Case 1
                BindPageApe()
            Case 2

        End Select
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
        pageIndex += 1
        If pageIndex > pageCount - 1 Then
            pageIndex = pageCount - 1
        End If

        Select Case tabCtrl.SelectedIndex
            Case 0
                BindPageMedRecord()
            Case 1
                BindPageApe()
            Case 2

        End Select
    End Sub

    Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
        pageIndex = pageCount - 1

        Select Case tabCtrl.SelectedIndex
            Case 0
                BindPageMedRecord()
            Case 1
                BindPageApe()
            Case 2

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

    Private Sub tabCtrl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabCtrl.SelectedIndexChanged
        Select Case tabCtrl.SelectedIndex
            Case 0
                BindPageMedRecord()
            Case 1
                BindPageApe()
            Case 2

        End Select
    End Sub

End Class