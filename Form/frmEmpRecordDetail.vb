Imports BlackCoffeeLibrary
Imports HealthInformationSystem
Imports HealthInformationSystem.dsHealth
Imports HealthInformationSystem.dsHealthTableAdapters
Imports System.Data.SqlClient
Imports System.Deployment.Application
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class frmEmpRecordDetail
    Private connection As New clsConnection
    Private directories As New clsDirectory
    Private dbHealth As New SqlDbMethod(connection.MyConnection)
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)
    Private dbMain As New Main

    Private patientId As Integer = 0
    Private doctorId As Integer = 0
    Private recordId As Integer = 0

    Private dsHealth As New dsHealth
    Private adpEmpMedRecord As New EmployeeMedicalRecordTableAdapter
    Private adpEmpMedAttach As New EmployeeMedicalAttachmentTableAdapter
    Private dtEmpMedRecord As New EmployeeMedicalRecordDataTable
    Private dtEmpMedAttach As New EmployeeMedicalAttachmentDataTable
    Private bsEmpMedRecord As New BindingSource
    Private bsEmpMedAttach As New BindingSource

    Private WithEvents dateCreated As Binding
    Private WithEvents lmp As Binding

    Private imgList As New List(Of clsPicture)
    Private imgListForDelete As New List(Of clsPicture)
    Private currentIndex As Integer

    Private initialDirectory As String = directories.IniDirMedRecord
    Private attachmentDirectory As String = directories.AttDirMedRecord

    Public Sub New(ByVal _patientId As Integer, ByVal _doctorId As Integer, Optional ByVal _recordId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        patientId = _patientId
        doctorId = _doctorId
        recordId = _recordId
    End Sub

    Private Sub frmEmployeeRecordDetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        If recordId = 0 Then
            Me.Text = "Create New Record"
            txtDateCreated.Text = String.Format("{0:MM/dd/yyyy  HH:mm}", dbHealth.GetServerDate)

            Dim _prm(0) As SqlParameter
            _prm(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            _prm(0).Value = doctorId
            txtEncoder.Text = StrConv(dbHealth.ExecuteScalar("SELECT EmployeeName FROM VwClinic WHERE EmployeeId = @EmployeeId", CommandType.Text, _prm), VbStrConv.ProperCase)

            chkFitToWork.CheckState = CheckState.Checked
            btnDelete.Enabled = False

            lblFileCount.Text = String.Format("File Count : {0}", 0)

            Me.ActiveControl = txtLmp

        Else
            Me.Text = String.Format("Record ID : {0}", recordId)
            btnDelete.Enabled = True

            Me.adpEmpMedRecord.FillEmployeeMedicalRecordByRecordId(Me.dsHealth.EmployeeMedicalRecord, recordId)
            Me.bsEmpMedRecord.DataSource = Me.dsHealth
            Me.bsEmpMedRecord.DataMember = dtEmpMedRecord.TableName
            Me.bsEmpMedRecord.Position = Me.bsEmpMedRecord.Find("RecordId", recordId)

            dateCreated = New Binding("Text", Me.bsEmpMedRecord.Current, "CreatedDate")
            txtDateCreated.DataBindings.Add(dateCreated)

            txtEncoder.DataBindings.Add(New Binding("Text", Me.bsEmpMedRecord.Current, "CreatedByName"))

            If CType(Me.bsEmpMedRecord.Current, DataRowView).Item("LMP") Is DBNull.Value Then
                txtLmp.Text = String.Empty
            Else
                lmp = New Binding("Text", Me.bsEmpMedRecord.Current, "LMP")
                txtLmp.DataBindings.Add(lmp)
            End If

            If CType(Me.bsEmpMedRecord.Current, DataRowView).Item("Temperature") Is DBNull.Value Then
                txtTemperature.Text = String.Empty
            Else
                txtTemperature.DataBindings.Add(New Binding("Text", Me.bsEmpMedRecord.Current, "Temperature"))
            End If

            If CType(Me.bsEmpMedRecord.Current, DataRowView).Item("BloodPressure") Is DBNull.Value Then
                txtBloodPressure.Text = String.Empty
            Else
                txtBloodPressure.DataBindings.Add(New Binding("Text", Me.bsEmpMedRecord.Current, "BloodPressure"))
            End If

            If CType(Me.bsEmpMedRecord.Current, DataRowView).Item("OxygenLevel") Is DBNull.Value Then
                txtOxygenLevel.Text = String.Empty
            Else
                txtOxygenLevel.DataBindings.Add(New Binding("Text", Me.bsEmpMedRecord.Current, "OxygenLevel"))
            End If

            If CType(Me.bsEmpMedRecord.Current, DataRowView).Item("PulseRate") Is DBNull.Value Then
                txtPulseRate.Text = String.Empty
            Else
                txtPulseRate.DataBindings.Add(New Binding("Text", Me.bsEmpMedRecord.Current, "PulseRate"))
            End If

            If CType(Me.bsEmpMedRecord.Current, DataRowView).Item("RespiratoryRate") Is DBNull.Value Then
                txtRespiratoryRate.Text = String.Empty
            Else
                txtRespiratoryRate.DataBindings.Add(New Binding("Text", Me.bsEmpMedRecord.Current, "RespiratoryRate"))
            End If

            txtChiefComplaint.DataBindings.Add(New Binding("Text", Me.bsEmpMedRecord.Current, "ChiefComplaint"))
            txtDiagnosis.DataBindings.Add(New Binding("Text", Me.bsEmpMedRecord.Current, "Diagnosis"))

            If CType(Me.bsEmpMedRecord.Current, DataRowView).Item("IsFitToWork") = True Then
                chkFitToWork.Checked = True
            Else
                chkFitToWork.Checked = False
            End If

            If CType(Me.bsEmpMedRecord.Current, DataRowView).Item("IsSentHome") = True Then
                chkSentHome.Checked = True
            Else
                chkSentHome.Checked = False
            End If

            If String.IsNullOrEmpty(attachmentDirectory) Or Not Directory.Exists(attachmentDirectory) Then
                MessageBox.Show("The attachment directory was not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim _attachmentCount As Integer = Me.adpEmpMedAttach.CntEmployeeMedicalAttachmentByRecordId(recordId)

            If _attachmentCount > 0 Then
                dtEmpMedAttach = Me.adpEmpMedAttach.GetEmployeeMedicalAttachmentByRecordId(recordId)

                For i As Integer = 0 To dtEmpMedAttach.Count - 1
                    Dim _oldPic As New clsPicture(attachmentDirectory & "\" & dtEmpMedAttach.Rows(i).Item("Filename").ToString,
                                                  dtEmpMedAttach.Rows(i).Item("Filename").ToString,
                                                  dtEmpMedAttach.Rows(i).Item("AttachmentId"))
                    imgList.Add(_oldPic)
                    currentIndex = 0
                Next
                ShowImage()
            End If

            lblFileCount.Text = String.Format("File Count : {0}", imgList.Count)
            Me.ActiveControl = txtLmp
            txtLmp.Select(txtLmp.Text.Trim.Length, 0)
        End If

        If String.IsNullOrEmpty(initialDirectory) Then
            ofdRecDetail.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        Else
            ofdRecDetail.InitialDirectory = initialDirectory
        End If
    End Sub

    Private Sub frmEmpRecordDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            If String.IsNullOrEmpty(txtChiefComplaint.Text.Trim) Then
                MessageBox.Show("Please indicate the chief complain.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ActiveControl = txtChiefComplaint
                Return
            End If

            If String.IsNullOrEmpty(txtDiagnosis.Text.Trim) Then
                MessageBox.Show("Please indicate the diagnosis.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ActiveControl = txtDiagnosis
                Return
            End If

            If recordId = 0 Then
                Dim _newRecordRow As EmployeeMedicalRecordRow = Me.dsHealth.EmployeeMedicalRecord.NewEmployeeMedicalRecordRow

                With _newRecordRow
                    .CreatedDate = dbHealth.GetServerDate
                    .CreatedBy = doctorId
                    .EmployeeId = patientId

                    If txtLmp.MaskCompleted = True Then
                        .LMP = CDate(txtLmp.Text)
                    Else
                        .SetLMPNull()
                    End If

                    If String.IsNullOrEmpty(txtTemperature.Text.Trim) Then
                        .SetTemperatureNull()
                    Else
                        .Temperature = txtTemperature.Text.Trim
                    End If

                    If String.IsNullOrEmpty(txtBloodPressure.Text.Trim) Then
                        .SetBloodPressureNull()
                    Else
                        .BloodPressure = txtBloodPressure.Text.Trim
                    End If

                    If String.IsNullOrEmpty(txtOxygenLevel.Text.Trim) Then
                        .SetOxygenLevelNull()
                    Else
                        .OxygenLevel = txtOxygenLevel.Text.Trim
                    End If

                    If String.IsNullOrEmpty(txtPulseRate.Text.Trim) Then
                        .SetPulseRateNull()
                    Else
                        .PulseRate = txtPulseRate.Text.Trim
                    End If

                    If String.IsNullOrEmpty(txtRespiratoryRate.Text.Trim) Then
                        .SetRespiratoryRateNull()
                    Else
                        .RespiratoryRate = txtRespiratoryRate.Text.Trim
                    End If

                    .ChiefComplaint = txtChiefComplaint.Text.Trim
                    .Diagnosis = txtDiagnosis.Text.Trim
                    .IsFitToWork = IIf(chkFitToWork.CheckState = CheckState.Checked, True, False)
                    .IsSentHome = IIf(chkSentHome.CheckState = CheckState.Checked, True, False)
                    .SetModifiedDateNull()
                    .SetModifiedByNull()
                End With
                Me.dsHealth.EmployeeMedicalRecord.AddEmployeeMedicalRecordRow(_newRecordRow)
                Me.adpEmpMedRecord.Update(Me.dsHealth.EmployeeMedicalRecord)

                If Not Directory.Exists(attachmentDirectory) Then
                    Directory.CreateDirectory(attachmentDirectory)
                End If

                If imgList.Count > 0 Then
                    For i As Integer = 0 To imgList.Count - 1
                        Dim _newAttachmentRow As EmployeeMedicalAttachmentRow = Me.dsHealth.EmployeeMedicalAttachment.NewEmployeeMedicalAttachmentRow

                        With _newAttachmentRow
                            .RecordId = _newRecordRow.RecordId
                            .Filename = ""
                        End With
                        Me.dsHealth.EmployeeMedicalAttachment.AddEmployeeMedicalAttachmentRow(_newAttachmentRow)
                        Me.adpEmpMedAttach.Update(Me.dsHealth.EmployeeMedicalAttachment)

                        Dim _ext As String = String.Empty
                        Dim _newName As String = String.Empty
                        Dim _img As Image = Image.FromFile(imgList(i).FileName)
                        _ext = Path.GetExtension(imgList(i).FileName).ToLower
                        _newName = patientId & "-" & _newRecordRow.RecordId & "-" & _newAttachmentRow.AttachmentId & _ext
                        _img.Save(attachmentDirectory & "\" & _newName)

                        Me.adpEmpMedAttach.UpdEmployeeMedicalAttachmentByAttachmentId(_newAttachmentRow.AttachmentId, _newName)
                    Next
                End If

                Me.dsHealth.AcceptChanges()

            Else
                Dim _rowRecord As EmployeeMedicalRecordRow = Me.dsHealth.EmployeeMedicalRecord.FindByRecordId(recordId)

                With _rowRecord
                    If txtLmp.MaskCompleted = True Then
                        .LMP = CDate(txtLmp.Text)
                    Else
                        .SetLMPNull()
                    End If

                    If String.IsNullOrEmpty(txtTemperature.Text.Trim) Then
                        .SetTemperatureNull()
                    Else
                        .Temperature = txtTemperature.Text.Trim
                    End If

                    If String.IsNullOrEmpty(txtBloodPressure.Text.Trim) Then
                        .SetBloodPressureNull()
                    Else
                        .BloodPressure = txtBloodPressure.Text.Trim
                    End If

                    If String.IsNullOrEmpty(txtOxygenLevel.Text.Trim) Then
                        .SetOxygenLevelNull()
                    Else
                        .OxygenLevel = txtOxygenLevel.Text.Trim
                    End If

                    If String.IsNullOrEmpty(txtPulseRate.Text.Trim) Then
                        .SetPulseRateNull()
                    Else
                        .PulseRate = txtPulseRate.Text.Trim
                    End If

                    If String.IsNullOrEmpty(txtRespiratoryRate.Text.Trim) Then
                        .SetRespiratoryRateNull()
                    Else
                        .RespiratoryRate = txtRespiratoryRate.Text.Trim
                    End If

                    .ChiefComplaint = txtChiefComplaint.Text.Trim
                    .Diagnosis = txtDiagnosis.Text.Trim
                    .IsFitToWork = chkFitToWork.Checked
                    .IsSentHome = chkSentHome.Checked
                    .ModifiedBy = doctorId
                    .ModifiedDate = dbHealth.GetServerDate
                End With

                If imgListForDelete.Count > 0 Then
                    For _i As Integer = 0 To imgListForDelete.Count - 1
                        Dim _ext As String = String.Empty
                        Dim _newName As String = String.Empty
                        _ext = Path.GetExtension(imgListForDelete(_i).FileName).ToLower
                        _newName = patientId & "-" & recordId & "-" & imgListForDelete(_i).AttachmentId & _ext
                        File.Delete(attachmentDirectory & "\" & _newName)
                        Me.adpEmpMedAttach.DelEmployeeMedicalAttachmentByAttachmentId(imgListForDelete(_i).AttachmentId)
                    Next
                End If

                If imgList.Count > 0 Then
                    For i As Integer = 0 To imgList.Count - 1
                        If imgList(i).AttachmentId = 0 Then
                            Dim _newAttachmentRow As EmployeeMedicalAttachmentRow = Me.dsHealth.EmployeeMedicalAttachment.NewEmployeeMedicalAttachmentRow

                            With _newAttachmentRow
                                .RecordId = recordId
                                .Filename = ""
                            End With
                            Me.dsHealth.EmployeeMedicalAttachment.AddEmployeeMedicalAttachmentRow(_newAttachmentRow)
                            Me.adpEmpMedAttach.Update(Me.dsHealth.EmployeeMedicalAttachment)

                            Dim _ext As String = String.Empty
                            Dim _newName As String = String.Empty
                            Dim _img As Image = Image.FromFile(imgList(i).FileName)
                            _ext = Path.GetExtension(imgList(i).FileName).ToLower
                            _newName = patientId & "-" & recordId & "-" & _newAttachmentRow.AttachmentId & _ext

                            _img.Save(attachmentDirectory & "\" & _newName)
                            Me.adpEmpMedAttach.UpdEmployeeMedicalAttachmentByAttachmentId(_newAttachmentRow.AttachmentId, _newName)
                        End If
                    Next
                End If

                Me.bsEmpMedRecord.EndEdit()
                Me.adpEmpMedRecord.Update(Me.dsHealth.EmployeeMedicalRecord)
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

                Me.bsEmpMedRecord.RemoveCurrent()
                Me.adpEmpMedRecord.Update(Me.dsHealth.EmployeeMedicalRecord)
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
            ofdRecDetail.ShowDialog()
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

    Private Sub ofdRecDetail_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ofdRecDetail.FileOk
        Try
            For i As Integer = 0 To ofdRecDetail.FileNames.Length - 1
                Dim _newPicture As New clsPicture(ofdRecDetail.FileNames(i), ofdRecDetail.SafeFileNames(i))
                imgList.Add(_newPicture)
                currentIndex = imgList.Count - 1
            Next
            ShowImage()

            ofdRecDetail.InitialDirectory = ofdRecDetail.FileName
            lblFileCount.Text = String.Format("File Count : {0}", imgList.Count)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtLmp_TypeValidationCompleted(sender As Object, e As TypeValidationEventArgs) Handles txtLmp.TypeValidationCompleted
        If (txtLmp.MaskCompleted) AndAlso (Not e.IsValidInput) Then
            SendKeys.Send("{End}")
            MessageBox.Show("Please input date in MM/DD/YYYY format.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True
        End If
    End Sub

    Private Sub dateCreated_Format(sender As Object, e As ConvertEventArgs) Handles dateCreated.Format
        If Not e.Value Is DBNull.Value Then
            e.Value = Format(e.Value, "MMMM dd, yyyy")
        Else
            e.Value = dbHealth.GetServerDate.ToString("MMMM dd, yyyy")
        End If
    End Sub

    Private Sub lmp_Format(sender As Object, e As ConvertEventArgs) Handles lmp.Format
        e.Value = Format(e.Value, "MM/dd/yyyy")
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