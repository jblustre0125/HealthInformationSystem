Imports BlackCoffeeLibrary
Imports HealthInformationSystem
Imports HealthInformationSystem.dsHealth
Imports HealthInformationSystem.dsHealthTableAdapters
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Deployment.Application
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class Ape
    Private connection As New clsConnection
    Private directories As New clsDirectory
    Private dbHealth As New SqlDbMethod(connection.MyConnection)
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)
    Private dbMain As New BlackCoffeeLibrary.Main

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

    Private WithEvents createdDate As Binding
    Private WithEvents modifiedDate As Binding

    Private lstAttachment As New List(Of clsAttachment)
    Private lstAttachmentForDelete As New List(Of clsAttachment)
    Private lstAttachmentForCopy As New List(Of clsAttachment)
    Private lstImageFiles As New List(Of String)(New String() {".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tif", ".tiff"})
    Private lstDocumentFiles As New List(Of String)(New String() {".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".txt"})
    Private lstPdfFiles As New List(Of String)(New String() {".pdf"})
    Private currentIndex As Integer

    Private initialDirectory As String = directories.IniDirApeRecord
    Private attachmentDirectory As String = directories.AttDirApeRecord

    Public Sub New(_patientId As Integer, _doctorId As Integer, Optional _recordId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        patientId = _patientId
        doctorId = _doctorId
        recordId = _recordId

        Me.TopMost = True
    End Sub

    Private Sub frmEmpApeDetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TopMost = False

        If recordId = 0 Then
            Me.Text = "New Record"
            lblFilename.Text = String.Empty
            txtCreatedDate.Text = String.Format("{0:MMMM dd yyyy hh:mm tt}", dbHealth.GetServerDate)

            Dim prmEmployee(0) As SqlParameter
            prmEmployee(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            prmEmployee(0).Value = doctorId
            txtCreatedBy.Text = StrConv(dbHealth.ExecuteScalar("SELECT TRIM(EmployeeName) FROM VwClinicAll WHERE EmployeeId = @EmployeeId", CommandType.Text, prmEmployee), VbStrConv.ProperCase)

            btnDelete.Enabled = False

            lblFileCount.Text = String.Format("File Count : {0}", 0)

            txtYearId.Text = String.Format("{0:yyyy}", dbHealth.GetServerDate)

        Else
            If String.IsNullOrEmpty(attachmentDirectory) Or Not Directory.Exists(attachmentDirectory) Then
                MessageBox.Show("The attachment directory was not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Me.Text = String.Format("Record ID : {0}", recordId)
            btnDelete.Enabled = True

            Me.adpEmpApe.FillEmployeeApeByRecordId(Me.dsHealth.EmployeeApe, recordId)
            Me.bsEmpApe.DataSource = Me.dsHealth
            Me.bsEmpApe.DataMember = dtEmpApe.TableName
            Me.bsEmpApe.Position = Me.bsEmpApe.Find("RecordId", recordId)

            createdDate = New Binding("Text", Me.bsEmpApe.Current, "CreatedDate")
            txtCreatedDate.DataBindings.Add(createdDate)
            modifiedDate = New Binding("Text", Me.bsEmpApe.Current, "ModifiedDate")
            txtModifiedDate.DataBindings.Add(modifiedDate)

            txtCreatedBy.DataBindings.Add(New Binding("Text", Me.bsEmpApe.Current, "CreatedByName"))
            txtModifiedBy.DataBindings.Add(New Binding("Text", Me.bsEmpApe.Current, "ModifiedByName"))

            txtYearId.DataBindings.Add(New Binding("Text", Me.bsEmpApe.Current, "YearId"))
            txtRemarks.DataBindings.Add(New Binding("Text", Me.bsEmpApe.Current, "Remarks"))

            Dim attachmentCount As Integer = Me.adpEmpApeAttach.CntEmployeeApeAttachmentByRecordId(recordId)

            If attachmentCount > 0 Then
                dtEmpApeAttach = Me.adpEmpApeAttach.GetEmployeeApeAttachmentByRecordId(recordId)

                For i As Integer = 0 To dtEmpApeAttach.Count - 1
                    Dim oldAttachment As New clsAttachment(attachmentDirectory & "\" & dtEmpApeAttach.Rows(i).Item("Filename").ToString,
                                                  dtEmpApeAttach.Rows(i).Item("Filename").ToString,
                                                  Path.GetExtension(Path.Combine(attachmentDirectory, dtEmpApeAttach.Rows(i).Item("Filename").ToString)),
                                                  dtEmpApeAttach.Rows(i).Item("AttachmentId"))
                    lstAttachment.Add(oldAttachment)
                    currentIndex = 0
                Next
                ShowAttachment()
            End If

            lblFileCount.Text = String.Format("File Count : {0}", lstAttachment.Count)
        End If

        Me.ActiveControl = txtYearId
        txtYearId.Select(txtYearId.Text.Trim.Length, 0)

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
                Dim countYear As Integer = Me.adpEmpApe.CntEmployeeApeByYearId(txtYearId.Text.Trim, patientId)

                If countYear > 0 Then
                    MessageBox.Show("APE Record for year " & txtYearId.Text.Trim & " already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.ActiveControl = txtYearId
                    Return
                End If

                Dim newRecordRow As EmployeeApeRow = Me.dsHealth.EmployeeApe.NewEmployeeApeRow

                With newRecordRow
                    .CreatedDate = dbHealth.GetServerDate
                    .CreatedBy = doctorId
                    .SetModifiedDateNull()
                    .SetModifiedByNull()
                    .EmployeeId = patientId
                    .YearId = txtYearId.Text.Trim

                    If String.IsNullOrEmpty(txtRemarks.Text.Trim) Then
                        .SetRemarksNull()
                    Else
                        .Remarks = txtRemarks.Text.Trim
                    End If
                End With
                Me.dsHealth.EmployeeApe.AddEmployeeApeRow(newRecordRow)
                Me.adpEmpApe.Update(Me.dsHealth.EmployeeApe)

                If Not Directory.Exists(attachmentDirectory) Then
                    Directory.CreateDirectory(attachmentDirectory)
                End If

                If lstAttachment.Count > 0 Then
                    For i As Integer = 0 To lstAttachment.Count - 1
                        Dim newAttachmentRow As EmployeeApeAttachmentRow = Me.dsHealth.EmployeeApeAttachment.NewEmployeeApeAttachmentRow

                        With newAttachmentRow
                            .RecordId = newRecordRow.RecordId
                            .Filename = ""
                        End With
                        Me.dsHealth.EmployeeApeAttachment.AddEmployeeApeAttachmentRow(newAttachmentRow)
                        Me.adpEmpApeAttach.Update(Me.dsHealth.EmployeeApeAttachment)

                        Dim ext As String = String.Empty
                        Dim newName As String = String.Empty
                        ext = Path.GetExtension(lstAttachment(i).FileName).ToLower
                        newName = patientId & "-" & newRecordRow.RecordId & "-" & newAttachmentRow.AttachmentId & ext

                        Me.adpEmpApeAttach.UpdEmployeeApeAttachmentByAttachmentId(newAttachmentRow.AttachmentId, newName)

                        progBar.Visible = True
                        lblProgress.Visible = True

                        Dim copyAttachment As New clsAttachment(lstAttachment(i).FileName, newName, lstAttachment(i).FileName)
                        lstAttachmentForCopy.Add(copyAttachment)
                    Next
                End If

                btnPrevious.Enabled = False
                btnNext.Enabled = False
                btnView.Enabled = False
                btnBrowse.Enabled = False
                btnRemove.Enabled = False
                btnSave.Enabled = False
                btnDelete.Enabled = False
                btnCancel.Enabled = False
                btnClose.Enabled = False
                Me.ControlBox = False

                bgWorker.RunWorkerAsync()
                Me.dsHealth.AcceptChanges()

            Else
                Dim countYear As Integer = Me.adpEmpApe.CntEmployeeApeByYearId(txtYearId.Text.Trim, patientId)

                If countYear > 0 AndAlso CType(Me.bsEmpApe.Current, DataRowView).Item("YearId") <> txtYearId.Text.Trim Then
                    MessageBox.Show("APE Record for year " & txtYearId.Text.Trim & " already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.ActiveControl = txtYearId
                    Return
                End If

                Dim rowApe As EmployeeApeRow = Me.dsHealth.EmployeeApe.FindByRecordId(recordId)

                With rowApe
                    .YearId = txtYearId.Text.Trim
                    .ModifiedDate = dbHealth.GetServerDate
                    .ModifiedBy = doctorId

                    If String.IsNullOrEmpty(txtRemarks.Text.Trim) Then
                        .SetRemarksNull()
                    Else
                        .Remarks = txtRemarks.Text.Trim
                    End If
                End With

                If lstAttachmentForDelete.Count > 0 Then
                    For i As Integer = 0 To lstAttachmentForDelete.Count - 1
                        Dim ext As String = String.Empty
                        Dim newName As String = String.Empty
                        ext = Path.GetExtension(lstAttachmentForDelete(i).FileName).ToLower
                        newName = patientId & "-" & recordId & "-" & lstAttachmentForDelete(i).AttachmentId & ext
                        File.Delete(attachmentDirectory & "\" & newName)
                        Me.adpEmpApeAttach.DelEmployeeApeAttachmentByAttachmentId(lstAttachmentForDelete(i).AttachmentId)
                    Next
                End If

                If lstAttachment.Count > 0 Then
                    For i As Integer = 0 To lstAttachment.Count - 1
                        If lstAttachment(i).AttachmentId = 0 Then
                            Dim newAttachmentRow As EmployeeApeAttachmentRow = Me.dsHealth.EmployeeApeAttachment.NewEmployeeApeAttachmentRow

                            With newAttachmentRow
                                .RecordId = recordId
                                .Filename = ""
                            End With
                            Me.dsHealth.EmployeeApeAttachment.AddEmployeeApeAttachmentRow(newAttachmentRow)
                            Me.adpEmpApeAttach.Update(Me.dsHealth.EmployeeApeAttachment)

                            Dim ext As String = String.Empty
                            Dim newName As String = String.Empty
                            ext = Path.GetExtension(lstAttachment(i).FileName).ToLower
                            newName = patientId & "-" & recordId & "-" & newAttachmentRow.AttachmentId & ext

                            Me.adpEmpApeAttach.UpdEmployeeApeAttachmentByAttachmentId(newAttachmentRow.AttachmentId, newName)

                            progBar.Visible = True
                            lblProgress.Visible = True

                            Dim copyAttachment As New clsAttachment(lstAttachment(i).FileName, newName, lstAttachment(i).FileName)
                            lstAttachmentForCopy.Add(copyAttachment)
                        End If
                    Next
                End If

                btnPrevious.Enabled = False
                btnNext.Enabled = False
                btnView.Enabled = False
                btnBrowse.Enabled = False
                btnRemove.Enabled = False
                btnSave.Enabled = False
                btnDelete.Enabled = False
                btnCancel.Enabled = False
                btnClose.Enabled = False

                bgWorker.RunWorkerAsync()

                Me.bsEmpApe.EndEdit()
                Me.adpEmpApe.Update(Me.dsHealth.EmployeeApe)
                Me.dsHealth.AcceptChanges()
            End If
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

                If lstAttachmentForDelete.Count > 0 Then
                    For _i As Integer = 0 To lstAttachmentForDelete.Count - 1
                        Dim _ext As String = String.Empty
                        Dim _newName As String = String.Empty
                        _ext = Path.GetExtension(lstAttachmentForDelete(_i).FileName).ToLower
                        _newName = patientId & "-" & recordId & "-" & lstAttachmentForDelete(_i).AttachmentId & _ext
                        File.Delete(attachmentDirectory & "\" & _newName)
                    Next
                End If

                If lstAttachment.Count > 0 Then
                    For _i As Integer = 0 To lstAttachment.Count - 1
                        Dim _ext As String = String.Empty
                        Dim _newName As String = String.Empty
                        _ext = Path.GetExtension(lstAttachment(_i).FileName).ToLower
                        _newName = patientId & "-" & recordId & "-" & lstAttachment(_i).AttachmentId & _ext
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

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Try
            Process.Start(lstAttachment(currentIndex).FileName)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Try
            ofdApeDetail.Filter = "Image Files (*.jpeg, *.png) | *.jpg; *.jpeg; *.png; *.bmp; *.gif; *.tif; *.tiff; |" &
                                  "Word Documents (*.doc) | *.doc; *.docx; |" &
                                  "Excel Worksheets (*.xls, *.xlsx) | *.xls; *.xlsx |" &
                                  "Presentation Files (*.ppt, *pptx) | *.ppt; *.pptx; *.odp; |" &
                                  "PDF Files (*.pdf) | *.pdf; |" &
                                  "Text Files (*.txt) | *.txt |" &
                                  "All Files (*.*) | *.*"
            ofdApeDetail.FilterIndex = 7
            ofdApeDetail.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try
            If lstAttachment.Count < 1 Then
                picImage.Image = Nothing
                lblFilename.Text = String.Empty
                Exit Sub
            Else
                If recordId = 0 Then
                    lstAttachment.RemoveAt(currentIndex)
                Else
                    If Not lstAttachment(currentIndex).AttachmentId = 0 Then
                        Dim forDeleteItem As New clsAttachment(attachmentDirectory & "\" & lstAttachment(currentIndex).FileName,
                                                               lstAttachment(currentIndex).SafeName,
                                                               Path.GetExtension(lstAttachment(currentIndex).SafeName),
                                                               lstAttachment(currentIndex).AttachmentId)
                        lstAttachmentForDelete.Add(forDeleteItem)
                        lstAttachment.RemoveAt(currentIndex)
                    End If
                End If
            End If

            NextImage(-1)
            lblFileCount.Text = String.Format("File Count : {0}", lstAttachment.Count)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ofdApeDetail_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ofdApeDetail.FileOk
        Try
            For i As Integer = 0 To ofdApeDetail.FileNames.Length - 1
                Dim newAttachment As New clsAttachment(ofdApeDetail.FileNames(i), ofdApeDetail.SafeFileNames(i), Path.GetExtension(ofdApeDetail.SafeFileNames(i)).ToLower)
                lstAttachment.Add(newAttachment)
                currentIndex = lstAttachment.Count - 1
            Next
            ShowAttachment()

            ofdApeDetail.InitialDirectory = Path.GetDirectoryName(lstAttachment(currentIndex).FileName)
            lblFileCount.Text = String.Format("File Count : {0}", lstAttachment.Count)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub createdDate_Format(sender As Object, e As ConvertEventArgs) Handles createdDate.Format
        If Not e.Value Is DBNull.Value Then
            e.Value = Format(e.Value, "MMMM dd, yyyy hh:mm:ss tt")
        Else
            e.Value = dbHealth.GetServerDate.ToString("MMMM dd, yyyy hh:mm:ss tt")
        End If
    End Sub

    Private Sub modifiedDate_Format(sender As Object, e As ConvertEventArgs) Handles modifiedDate.Format
        If Not e.Value Is DBNull.Value Then
            e.Value = Format(e.Value, "MMMM dd, yyyy hh:mm:ss tt")
        Else
            e.Value = ""
        End If
    End Sub

    Private Sub txtYearId_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtYearId.Validating
        Try
            If txtYearId.Text.Trim.Length > 4 Then
                MessageBox.Show("Please input a valid year.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ActiveControl = txtYearId
            End If
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

    Private Sub ShowAttachment()
        Try
            If lstImageFiles.Contains(lstAttachment(currentIndex).ExtensionName.ToString.Trim.ToLower) Then
                picImage.Visible = True
                axAcroPdf.Visible = False

                Using img As Image = Image.FromFile(lstAttachment(currentIndex).FileName)
                    picImage.Image = New Bitmap(img)
                End Using

            ElseIf lstDocumentFiles.Contains(lstAttachment(currentIndex).ExtensionName.ToString.Trim.ToLower) Then
                picImage.Visible = True
                axAcroPdf.Visible = False

                Select Case lstAttachment(currentIndex).ExtensionName.ToString.Trim.ToLower
                    Case ".doc", ".docx"
                        picImage.Image = My.Resources.file_type_doc_512px

                    Case ".xls", ".xlsx"
                        picImage.Image = My.Resources.file_type_xls_512px

                    Case ".ppt", ".pptx"
                        picImage.Image = My.Resources.file_type_ppt_512px

                    Case ".txt"
                        picImage.Image = My.Resources.file_type_txt_512px
                End Select

            ElseIf lstPdfFiles.Contains(lstAttachment(currentIndex).ExtensionName.ToString.Trim.ToLower) Then
                picImage.Visible = False
                axAcroPdf.Visible = True
                axAcroPdf.src = lstAttachment(currentIndex).FileName + "#toolbar=0"
                axAcroPdf.setShowToolbar(False)

            Else
                picImage.Visible = True
                axAcroPdf.Visible = False
                picImage.Image = My.Resources.file_type_unknown_512px
            End If

            lblFilename.Text = lstAttachment(currentIndex).SafeName
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NextImage(val As Integer)
        Try
            If lstAttachment.Count < 1 Then
                picImage.Image = Nothing
                lblFilename.Text = String.Empty
                Exit Sub
            End If

            currentIndex += val
            If currentIndex < 0 Then currentIndex = lstAttachment.Count - 1
            If currentIndex > lstAttachment.Count - 1 Then currentIndex = 0
            If currentIndex = lstAttachment.Count - 1 Then currentIndex = lstAttachment.Count - 1
            ShowAttachment()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bgWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker.DoWork
        If lstAttachmentForCopy.Count > 0 Then
            Dim streamRead As System.IO.FileStream
            Dim streamWrite As System.IO.FileStream

            For i As Integer = 0 To lstAttachmentForCopy.Count - 1
                streamRead = New System.IO.FileStream(lstAttachmentForCopy(i).FileName, System.IO.FileMode.Open)
                streamWrite = New System.IO.FileStream(attachmentDirectory & "\" & lstAttachmentForCopy(i).SafeName, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)

                Dim lngLen As Long = streamRead.Length - 1
                Dim byteBuffer(4096) As Byte
                Dim intBytesRead As Integer

                ShowProgress("Uploading files : (0/" + (lngLen * 100).ToString + ")", lblProgress)

                While streamRead.Position < lngLen
                    If (bgWorker.CancellationPending = True) Then
                        e.Cancel = True
                        Exit While
                    End If

                    bgWorker.ReportProgress(CInt(streamRead.Position / lngLen * 100))
                    ShowProgress("Uploading files : (" + CInt(streamRead.Position).ToString + "/" + (lngLen * 100).ToString + ")", lblProgress)
                    intBytesRead = (streamRead.Read(byteBuffer, 0, 4096))

                    streamWrite.Write(byteBuffer, 0, intBytesRead)
                End While

                streamRead.Dispose()
                streamWrite.Dispose()
            Next
        End If
    End Sub

    Private Sub ShowProgress(ByVal text As String, ByVal lbl As Label)
        If lbl.InvokeRequired Then
            lbl.Invoke(New SetProgressInvoker(AddressOf ShowProgress), text, lbl)
        Else
            lbl.Text = text
        End If
    End Sub

    Private Delegate Sub SetProgressInvoker(textProgress As String, labelProgress As Label)

    Private Sub bgWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgWorker.ProgressChanged
        progBar.Value = e.ProgressPercentage
    End Sub

    Private Sub bgWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted
        If e.Cancelled = True Then
            progBar.Visible = False
            lblProgress.Visible = False

            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnView.Enabled = True
            btnBrowse.Enabled = True
            btnRemove.Enabled = True
            btnSave.Enabled = True
            btnDelete.Enabled = True
            btnClose.Enabled = True
        Else
            Me.DialogResult = DialogResult.OK
        End If
    End Sub
End Class