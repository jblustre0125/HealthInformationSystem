Imports BlackCoffeeLibrary
Imports HealthInformationSystem
Imports HealthInformationSystem.dsHealth
Imports HealthInformationSystem.dsHealthTableAdapters
Imports System.Data.SqlClient
Imports System.Deployment.Application
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class frmEmpApeDetail
    Private connection As New clsConnection
    Private directories As New clsDirectory
    Private dbHealth As New SqlDbMethod(connection.MyConnection)
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)
    Private dbMain As New Main

    Private patientId As Integer = 0
    Private doctorId As Integer = 0
    Private recordId As Integer = 0

    Private dsHealth As New dsHealth
    Private adpEmpApe As New EmployeeApeTableAdapter
    Private adpEmpApeAttach As New EmployeeApeAttachmentTableAdapter
    Private dtEmpApe As New EmployeeApeDataTable
    Private dtEmpApeAttach As New EmployeeApeAttachmentDataTable
    Private bsEmpApe As New BindingSource
    Private bsEmpApeAttach As New BindingSource

    Private WithEvents dateCreated As Binding

    Private imgList As New List(Of clsPicture)
    Private imgListForDelete As New List(Of clsPicture)
    Private currentIndex As Integer

    Private initialDirectory As String = directories.IniDirApeRecord
    Private attachmentDirectory As String = directories.AttDirApeRecord

    Public Sub New(ByVal _patientId As Integer, ByVal _doctorId As Integer, Optional ByVal _recordId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        patientId = _patientId
        doctorId = _doctorId
        recordId = _recordId
    End Sub

    Private Sub frmEmpApeDetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        If recordId = 0 Then
            Me.Text = "Create New Record"
            txtCreatedDate.Text = String.Format("{0:MM-dd-yyyy HH:mm tt}", dbHealth.GetServerDate)

            Dim _prm(0) As SqlParameter
            _prm(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            _prm(0).Value = doctorId
            txtCreatedBy.Text = StrConv(dbHealth.ExecuteScalar("SELECT EmployeeName FROM VwClinic WHERE EmployeeId = @EmployeeId", CommandType.Text, _prm), VbStrConv.ProperCase)

            btnDelete.Enabled = False

            lblFileCount.Text = String.Format("File Count : {0}", 0)

            Me.ActiveControl = txtYearId
        Else
            Me.Text = String.Format("Record ID : {0}", recordId)
            btnDelete.Enabled = True

            Me.adpEmpApe.FillEmployeeApeByRecordId(Me.dsHealth.EmployeeApe, recordId)
            Me.bsEmpApe.DataSource = Me.dsHealth
            Me.bsEmpApe.DataMember = dtEmpApe.TableName
            Me.bsEmpApe.Position = Me.bsEmpApe.Find("RecordId", recordId)

            dateCreated = New Binding("Text", Me.bsEmpApe.Current, "CreatedDate")
            txtCreatedDate.DataBindings.Add(dateCreated)

            txtCreatedBy.DataBindings.Add(New Binding("Text", Me.bsEmpApe.Current, "CreatedByName"))

            txtYearId.DataBindings.Add(New Binding("Text", Me.bsEmpApe.Current, "YearId"))
            txtRemarks.DataBindings.Add(New Binding("Text", Me.bsEmpApe.Current, "Remarks"))

            If String.IsNullOrEmpty(attachmentDirectory) Or Not Directory.Exists(attachmentDirectory) Then
                MessageBox.Show("The attachment directory was not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim _attachmentCount As Integer = Me.adpEmpApeAttach.CntEmployeeApeAttachmentByRecordId(recordId)

            If _attachmentCount > 0 Then
                dtEmpApeAttach = Me.adpEmpApeAttach.GetEmployeeApeAttachmentByRecordId(recordId)

                For i As Integer = 0 To dtEmpApeAttach.Count - 1
                    Dim _oldPic As New clsPicture(attachmentDirectory & "\" & dtEmpApeAttach.Rows(i).Item("Filename").ToString,
                                                  dtEmpApeAttach.Rows(i).Item("Filename").ToString,
                                                  dtEmpApeAttach.Rows(i).Item("AttachmentId"))
                    imgList.Add(_oldPic)
                    currentIndex = 0
                Next
                ShowImage()
            End If

            lblFileCount.Text = String.Format("File Count : {0}", imgList.Count)
            Me.ActiveControl = txtYearId
            txtYearId.Select(txtYearId.Text.Trim.Length, 0)
        End If

        If String.IsNullOrEmpty(initialDirectory) Then
            ofdApeDetail.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        Else
            ofdApeDetail.InitialDirectory = initialDirectory
        End If
    End Sub

    Private Sub frmEmpApeDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F8
                btnDelete.PerformClick()
            Case Keys.F10
                btnSave.PerformClick()
            Case Keys.Enter
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End Select
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(txtYearId.Text.Trim) Then
                MessageBox.Show("Year is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ActiveControl = txtYearId
                Return
            End If

            If recordId = 0 Then
                Dim _yearCount As Integer = Me.adpEmpApe.CntEmployeeApeByYearId(txtYearId.Text.Trim)

                If _yearCount > 0 Then
                    MessageBox.Show("APE Record for year " & txtYearId.Text.Trim & " already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.ActiveControl = txtYearId
                    Return
                End If

                Dim _newRecordRow As EmployeeApeRow = Me.dsHealth.EmployeeApe.NewEmployeeApeRow

                With _newRecordRow
                    .CreatedDate = dbHealth.GetServerDate
                    .CreatedBy = doctorId
                    .EmployeeId = patientId
                    .YearId = txtYearId.Text.Trim

                    If String.IsNullOrEmpty(txtRemarks.Text.Trim) Then
                        .SetRemarksNull()
                    Else
                        .Remarks = txtRemarks.Text.Trim
                    End If

                    .SetModifiedDateNull()
                    .SetModifiedByNull()
                End With
                Me.dsHealth.EmployeeApe.AddEmployeeApeRow(_newRecordRow)
                Me.adpEmpApe.Update(Me.dsHealth.EmployeeApe)

                If Not Directory.Exists(attachmentDirectory) Then
                    Directory.CreateDirectory(attachmentDirectory)
                End If

                If imgList.Count > 0 Then
                    For i As Integer = 0 To imgList.Count - 1
                        Dim _newAttachmentRow As EmployeeApeAttachmentRow = Me.dsHealth.EmployeeApeAttachment.NewEmployeeApeAttachmentRow

                        With _newAttachmentRow
                            .RecordId = _newRecordRow.RecordId
                            .Filename = ""
                        End With
                        Me.dsHealth.EmployeeApeAttachment.AddEmployeeApeAttachmentRow(_newAttachmentRow)
                        Me.adpEmpApeAttach.Update(Me.dsHealth.EmployeeApeAttachment)

                        Dim _ext As String = String.Empty
                        Dim _newName As String = String.Empty
                        Dim _img As Image = Image.FromFile(imgList(i).FileName)
                        _ext = Path.GetExtension(imgList(i).FileName).ToLower
                        _newName = patientId & "-" & _newRecordRow.RecordId & "-" & _newAttachmentRow.AttachmentId & _ext
                        _img.Save(attachmentDirectory & "\" & _newName)

                        Me.adpEmpApeAttach.UpdEmployeeApeAttachmentByAttachmentId(_newAttachmentRow.AttachmentId, _newName)
                    Next
                End If

                Me.dsHealth.AcceptChanges()

            Else
                Dim _yearCount As Integer = Me.adpEmpApe.CntEmployeeApeByYearId(txtYearId.Text.Trim)

                If _yearCount > 0 AndAlso CType(Me.bsEmpApe.Current, DataRowView).Item("YearId") <> txtYearId.Text.Trim Then
                    MessageBox.Show("APE Record for year " & txtYearId.Text.Trim & " already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.ActiveControl = txtYearId
                    Return
                End If

                Dim _rowApe As EmployeeApeRow = Me.dsHealth.EmployeeApe.FindByRecordId(recordId)

                With _rowApe
                    .YearId = txtYearId.Text.Trim
                    .Remarks = txtRemarks.Text.Trim
                    .ModifiedDate = dbHealth.GetServerDate
                    .ModifiedBy = doctorId
                End With

                If imgListForDelete.Count > 0 Then
                    For _i As Integer = 0 To imgListForDelete.Count - 1
                        Dim _ext As String = String.Empty
                        Dim _newName As String = String.Empty
                        _ext = Path.GetExtension(imgListForDelete(_i).FileName).ToLower
                        _newName = patientId & "-" & recordId & "-" & imgListForDelete(_i).AttachmentId & _ext
                        File.Delete(attachmentDirectory & "\" & _newName)
                        Me.adpEmpApeAttach.DelEmployeeApeAttachmentByAttachmentId(imgListForDelete(_i).AttachmentId)
                    Next
                End If

                If imgList.Count > 0 Then
                    For i As Integer = 0 To imgList.Count - 1
                        If imgList(i).AttachmentId = 0 Then
                            Dim _newAttachmentRow As EmployeeApeAttachmentRow = Me.dsHealth.EmployeeApeAttachment.NewEmployeeApeAttachmentRow

                            With _newAttachmentRow
                                .RecordId = recordId
                                .Filename = ""
                            End With
                            Me.dsHealth.EmployeeApeAttachment.AddEmployeeApeAttachmentRow(_newAttachmentRow)
                            Me.adpEmpApeAttach.Update(Me.dsHealth.EmployeeApeAttachment)

                            Dim _ext As String = String.Empty
                            Dim _newName As String = String.Empty
                            Dim _img As Image = Image.FromFile(imgList(i).FileName)
                            _ext = Path.GetExtension(imgList(i).FileName).ToLower
                            _newName = patientId & "-" & recordId & "-" & _newAttachmentRow.AttachmentId & _ext

                            _img.Save(attachmentDirectory & "\" & _newName)
                            Me.adpEmpApeAttach.UpdEmployeeApeAttachmentByAttachmentId(_newAttachmentRow.AttachmentId, _newName)
                        End If
                    Next
                End If

                Me.bsEmpApe.EndEdit()
                Me.adpEmpApe.Update(Me.dsHealth.EmployeeApe)
                Me.dsHealth.AcceptChanges()
            End If

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            If recordId = 0 Then Exit Sub
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If recordId = 0 Then Exit Sub

            If MessageBox.Show("Are you sure you want to delete this record?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) =
                System.Windows.Forms.DialogResult.Yes Then

                If imgListForDelete.Count > 0 Then
                    For _i As Integer = 0 To imgListForDelete.Count - 1
                        Dim _ext As String = String.Empty
                        Dim _newName As String = String.Empty
                        _ext = Path.GetExtension(imgListForDelete(_i).FileName).ToLower
                        _newName = patientId & "-" & recordId & "-" & imgListForDelete(_i).AttachmentId & _ext
                        File.Delete(attachmentDirectory & "\" & _newName)
                    Next
                End If

                If imgList.Count > 0 Then
                    For _i As Integer = 0 To imgList.Count - 1
                        Dim _ext As String = String.Empty
                        Dim _newName As String = String.Empty
                        _ext = Path.GetExtension(imgList(_i).FileName).ToLower
                        _newName = patientId & "-" & recordId & "-" & imgList(_i).AttachmentId & _ext
                        File.Delete(attachmentDirectory & "\" & _newName)
                    Next
                End If

                Me.bsEmpApe.RemoveCurrent()
                Me.adpEmpApe.Update(Me.dsHealth.EmployeeApe)
                Me.dsHealth.AcceptChanges()
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        Try
            NextImage(-1)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            NextImage(1)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Try
            ofdApeDetail.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try
            If imgList.Count < 1 Then
                picImage.Image = Nothing
                lblFilename.Text = String.Empty
                Exit Sub
            Else
                If Not recordId = 0 Then
                    If Not imgList(currentIndex).AttachmentId = 0 Then
                        Dim _deleteItem As New clsPicture(attachmentDirectory & "\" & imgList(currentIndex).FileName,
                                                          imgList(currentIndex).FileName,
                                                          imgList(currentIndex).AttachmentId)
                        imgListForDelete.Add(_deleteItem)
                        imgList.RemoveAt(currentIndex)
                    End If
                Else
                    imgList.RemoveAt(currentIndex)
                End If
            End If

            NextImage(-1)
            lblFileCount.Text = String.Format("File Count : {0}", imgList.Count)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ofdApeDetail_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ofdApeDetail.FileOk
        Try
            For i As Integer = 0 To ofdApeDetail.FileNames.Length - 1
                Dim _newPicture As New clsPicture(ofdApeDetail.FileNames(i), ofdApeDetail.SafeFileNames(i))
                imgList.Add(_newPicture)
                currentIndex = imgList.Count - 1
            Next
            ShowImage()

            ofdApeDetail.InitialDirectory = ofdApeDetail.FileName
            lblFileCount.Text = String.Format("File Count : {0}", imgList.Count)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dateCreated_Format(sender As Object, e As ConvertEventArgs) Handles dateCreated.Format
        If Not e.Value Is DBNull.Value Then
            e.Value = Format(e.Value, "MMMM dd, yyyy")
        Else
            e.Value = dbHealth.GetServerDate.ToString("MMMM dd, yyyy")
        End If
    End Sub

    Private Sub txtYearId_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtYearId.Validating
        Try
            'If txtYearId.Text.Trim.Length > 4 Then
            '    MessageBox.Show("Please input a valid year.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Me.ActiveControl = txtYearId
            'End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtYearId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtYearId.KeyPress
        If ((Asc(e.KeyChar) >= 48 AndAlso Asc(e.KeyChar) <= 57) OrElse Asc(e.KeyChar) = 8 OrElse Asc(e.KeyChar) = 13 OrElse Asc(e.KeyChar) = 127) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub ShowImage()
        Try
            Dim _img As Image = Image.FromFile(imgList(currentIndex).FileName)
            picImage.Image = New Bitmap(_img)
            _img.Dispose()

            lblFilename.Text = imgList(currentIndex).SafeName
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NextImage(val As Integer)
        Try
            If imgList.Count < 1 Then
                picImage.Image = Nothing
                lblFilename.Text = String.Empty
                Exit Sub
            End If

            currentIndex += val
            If currentIndex < 0 Then currentIndex = 0
            If currentIndex > imgList.Count - 1 Then currentIndex = 0
            If currentIndex = imgList.Count - 1 Then currentIndex = imgList.Count - 1
            ShowImage()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class