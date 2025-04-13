Imports BlackCoffeeLibrary
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO

Public Class ApeDetail
    Private connection As New clsConnection
    Private directory As New clsDirectory
    Private dbHealth As New SqlDbMethod(connection.MyConnection)
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private dtApe As New DataTable
    Private dtAttachment As New DataTable

    Private lstAttachment As New List(Of clsAttachment)
    Private lstAttachmentDelete As New List(Of clsAttachment)
    Private lstAttachmentCopy As New List(Of clsAttachment)
    Private lstImageFiles As New List(Of String)(New String() {".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tif", ".tiff"})
    Private lstDocumentFiles As New List(Of String)(New String() {".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".txt"})
    Private lstPdfFiles As New List(Of String)(New String() {".pdf"})
    Private currentIndex As Integer

    Private initialDirectory As String = directory.IniDirApeRecord
    Private attachmentDirectory As String = directory.AttDirApeRecord

    Private patientId As Integer = 0
    Private attendantId As Integer = 0
    Private recordId As Integer = 0

    Private orgYearId As Integer = 0

    Public Sub New(patientId As Integer, attendantId As Integer, Optional recordId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.patientId = patientId
        Me.attendantId = attendantId
        Me.recordId = recordId

        Me.TopMost = True
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TopMost = False

        If recordId = 0 Then
            Me.Text = "New Record Entry"
            txtCreatedDate.Text = String.Format("{0:MMMM dd, yyyy hh:mm tt}", dbHealth.GetServerDate)

            Dim prmAttendant(0) As SqlParameter
            prmAttendant(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            prmAttendant(0).Value = attendantId

            txtCreatedBy.Text = StrConv(dbHealth.ExecuteScalar("SELECT TRIM(EmployeeName) FROM VwClinicAll WHERE EmployeeId = @EmployeeId", CommandType.Text, prmAttendant), VbStrConv.ProperCase)

            lblFilename.Text = String.Empty
            lblAttachmentCount.Text = String.Format("Attachment(s) : {0}", 0)

            txtYearId.Text = String.Format("{0:yyyy}", dbHealth.GetServerDate)

        Else
            If String.IsNullOrEmpty(attachmentDirectory) Or Not IO.Directory.Exists(attachmentDirectory) Then
                MessageBox.Show("The attachment directory was not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Me.Text = String.Format("Record No. {0}", recordId)
            btnDelete.Enabled = True

            Dim prmApe(0) As SqlParameter
            prmApe(0) = New SqlParameter("@RecordId", SqlDbType.Int)
            prmApe(0).Value = recordId

            dtApe = dbHealth.FillDataTable("RdEmployeeApeByRecordId", CommandType.StoredProcedure, prmApe)

            For Each row As DataRow In dtApe.Rows
                txtCreatedBy.Text = row("CreatedByName")
                txtCreatedDate.Text = String.Format("{0:MMMM dd, yyyy hh:mm tt}", row("CreatedDate"))

                If Not row("ModifiedByName") Is DBNull.Value Then
                    txtModifiedBy.Text = row("ModifiedByName")
                End If

                If Not row("ModifiedDate") Is DBNull.Value Then
                    txtModifiedDate.Text = String.Format("{0:MMMM dd, yyyy hh:mm tt}", row("ModifiedDate"))
                End If

                txtYearId.Text = row("YearId")
                txtRemarks.Text = row("Remarks")

                orgYearId = row("YearId")
            Next

            Dim prmCount(0) As SqlParameter
            prmCount(0) = New SqlParameter("@RecordId", SqlDbType.Int)
            prmCount(0).Value = recordId

            Dim attachmentCount As Integer = dbHealth.ExecuteScalar("CntEmployeeApeAttachmentByRecordId", CommandType.StoredProcedure, prmCount)

            If attachmentCount > 0 Then
                Dim prmAttachment(0) As SqlParameter
                prmAttachment(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                prmAttachment(0).Value = recordId

                dtAttachment = dbHealth.FillDataTable("RdEmployeeApeAttachmentByRecordId", CommandType.StoredProcedure, prmAttachment)

                For i As Integer = 0 To dtAttachment.Rows.Count - 1
                    Dim oldAttachment As New clsAttachment(attachmentDirectory & "\" & dtAttachment.Rows(i).Item("Filename").ToString, dtAttachment.Rows(i).Item("Filename").ToString, Path.GetExtension(Path.Combine(attachmentDirectory, dtAttachment.Rows(i).Item("Filename").ToString)), dtAttachment.Rows(i).Item("AttachmentId"))
                    lstAttachment.Add(oldAttachment)
                    currentIndex = 0
                Next

                ShowAttachment()
            Else
                lblFilename.Text = ""
            End If

            lblAttachmentCount.Text = String.Format("Attachment(s) : {0}", lstAttachment.Count)
        End If

        Me.ActiveControl = txtYearId
        txtYearId.Select(txtYearId.Text.Trim.Length, 0)

        If String.IsNullOrEmpty(initialDirectory) Then
            ofdApeDetail.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        Else
            ofdApeDetail.InitialDirectory = initialDirectory
        End If
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

            If Not IO.Directory.Exists(attachmentDirectory) Then
                IO.Directory.CreateDirectory(attachmentDirectory)
            End If

            If recordId = 0 Then
                Dim prmCount(1) As SqlParameter
                prmCount(0) = New SqlParameter("@YearId", SqlDbType.Int)
                prmCount(0).Value = txtYearId.Text.Trim
                prmCount(1) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                prmCount(1).Value = patientId

                Dim countYear As Integer = dbHealth.ExecuteScalar("CntEmployeeApeByYearId", CommandType.StoredProcedure, prmCount)

                If countYear > 0 Then
                    MessageBox.Show("APE Record for year " & txtYearId.Text.Trim & " already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.ActiveControl = txtYearId
                    Return
                End If

                Dim prmInsApe(5) As SqlParameter
                prmInsApe(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                prmInsApe(0).Direction = ParameterDirection.Output
                prmInsApe(1) = New SqlParameter("@CreatedDate", SqlDbType.DateTime)
                prmInsApe(1).Value = dbHealth.GetServerDate
                prmInsApe(2) = New SqlParameter("@CreatedBy", SqlDbType.Int)
                prmInsApe(2).Value = attendantId
                prmInsApe(3) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                prmInsApe(3).Value = patientId
                prmInsApe(4) = New SqlParameter("@YearId", SqlDbType.Int)
                prmInsApe(4).Value = txtYearId.Text.Trim
                prmInsApe(5) = New SqlParameter("@Remarks", SqlDbType.NVarChar)
                prmInsApe(5).Value = IIf(String.IsNullOrEmpty(txtRemarks.Text.Trim), Nothing, txtRemarks.Text.Trim)

                dbHealth.ExecuteNonQuery("InsEmployeeApe", CommandType.StoredProcedure, prmInsApe)

                If lstAttachment.Count > 0 Then
                    For i As Integer = 0 To lstAttachment.Count - 1
                        Dim prmInsAttachment(2) As SqlParameter
                        prmInsAttachment(0) = New SqlParameter("@AttachmentId", SqlDbType.Int)
                        prmInsAttachment(0).Direction = ParameterDirection.Output
                        prmInsAttachment(1) = New SqlParameter("@RecordId", SqlDbType.Int)
                        prmInsAttachment(1).Value = prmInsApe(0).Value
                        prmInsAttachment(2) = New SqlParameter("@FileName", SqlDbType.NVarChar)
                        prmInsAttachment(2).Value = ""

                        dbHealth.ExecuteNonQuery("InsEmployeeApeAttachment", CommandType.StoredProcedure, prmInsAttachment)

                        Dim ext As String = String.Empty
                        Dim newName As String = String.Empty
                        ext = Path.GetExtension(lstAttachment(i).FileName).ToLower
                        newName = patientId & "-" & prmInsApe(0).Value & "-" & prmInsAttachment(0).Value & ext

                        Dim prmUpdAttachment(1) As SqlParameter
                        prmUpdAttachment(0) = New SqlParameter("@AttachmentId", SqlDbType.Int)
                        prmUpdAttachment(0).Value = prmInsAttachment(0).Value
                        prmUpdAttachment(1) = New SqlParameter("Filename", SqlDbType.NVarChar)
                        prmUpdAttachment(1).Value = newName

                        dbHealth.ExecuteNonQuery("UpdEmployeeApeAttachment", CommandType.StoredProcedure, prmUpdAttachment)

                        progBar.Visible = True
                        lblProgress.Visible = True

                        Dim copyAttachment As New clsAttachment(lstAttachment(i).FileName, newName, lstAttachment(i).FileName)
                        lstAttachmentCopy.Add(copyAttachment)
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

            Else
                Dim prmCount(1) As SqlParameter
                prmCount(0) = New SqlParameter("@YearId", SqlDbType.Int)
                prmCount(0).Value = txtYearId.Text.Trim
                prmCount(1) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                prmCount(1).Value = patientId

                Dim countYear As Integer = dbHealth.ExecuteScalar("CntEmployeeApeByYearId", CommandType.StoredProcedure, prmCount)

                If countYear > 0 AndAlso orgYearId <> txtYearId.Text.Trim Then
                    MessageBox.Show("APE Record for year " & txtYearId.Text.Trim & " already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.ActiveControl = txtYearId
                    Return
                End If

                Dim prmUpd(4) As SqlParameter
                prmUpd(0) = New SqlParameter("@YearId", SqlDbType.Int)
                prmUpd(0).Value = txtYearId.Text
                prmUpd(1) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                prmUpd(1).Value = attendantId
                prmUpd(2) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime)
                prmUpd(2).Value = dbHealth.GetServerDate
                prmUpd(3) = New SqlParameter("@Remarks", SqlDbType.NVarChar)
                prmUpd(3).Value = IIf(String.IsNullOrEmpty(txtRemarks.Text.Trim), Nothing, txtRemarks.Text.Trim)
                prmUpd(4) = New SqlParameter("@RecordId", SqlDbType.Int)
                prmUpd(4).Value = recordId

                If lstAttachmentDelete.Count > 0 Then
                    For i As Integer = 0 To lstAttachmentDelete.Count - 1
                        Dim ext As String = String.Empty
                        Dim newName As String = String.Empty
                        ext = Path.GetExtension(lstAttachmentDelete(i).FileName).ToLower
                        newName = patientId & "-" & recordId & "-" & lstAttachmentDelete(i).AttachmentId & ext
                        File.Delete(attachmentDirectory & "\" & newName)

                        Dim prmDel(0) As SqlParameter
                        prmDel(0) = New SqlParameter("@AttachmentId", SqlDbType.Int)
                        prmDel(0).Value = lstAttachmentDelete(i).AttachmentId

                        dbHealth.ExecuteNonQuery("DelEmployeeApeAttachment", CommandType.StoredProcedure, prmDel)
                    Next
                End If

                If lstAttachment.Count > 0 Then
                    For i As Integer = 0 To lstAttachment.Count - 1
                        If lstAttachment(i).AttachmentId = 0 Then
                            Dim prmIns(2) As SqlParameter
                            prmIns(0) = New SqlParameter("@AttachmentId", SqlDbType.Int)
                            prmIns(0).Direction = ParameterDirection.Output
                            prmIns(1) = New SqlParameter("@RecordId", SqlDbType.Int)
                            prmIns(1).Value = recordId
                            prmIns(2) = New SqlParameter("@FileName", SqlDbType.NVarChar)
                            prmIns(2).Value = ""

                            dbHealth.ExecuteNonQuery("InsEmployeeApeAttachment", CommandType.StoredProcedure, prmIns)

                            Dim ext As String = String.Empty
                            Dim newName As String = String.Empty
                            ext = Path.GetExtension(lstAttachment(i).FileName).ToLower
                            newName = patientId & "-" & recordId & "-" & prmIns(0).Value & ext

                            Dim prmUpdNew(1) As SqlParameter
                            prmUpdNew(0) = New SqlParameter("@AttachmentId", SqlDbType.Int)
                            prmUpdNew(0).Value = prmIns(0).Value
                            prmUpdNew(1) = New SqlParameter("Filename", SqlDbType.NVarChar)
                            prmUpdNew(1).Value = newName

                            dbHealth.ExecuteNonQuery("UpdEmployeeApeAttachment", CommandType.StoredProcedure, prmUpd)

                            progBar.Visible = True
                            lblProgress.Visible = True

                            Dim copyAttachment As New clsAttachment(lstAttachment(i).FileName, newName, lstAttachment(i).FileName)
                            lstAttachmentCopy.Add(copyAttachment)
                        End If
                    Next
                End If

                dbHealth.ExecuteNonQuery("UpdEmployeeApe", CommandType.StoredProcedure, prmUpd)

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
               DialogResult.Yes Then

                If lstAttachmentDelete.Count > 0 Then
                    For i As Integer = 0 To lstAttachmentDelete.Count - 1
                        Dim ext As String = String.Empty
                        Dim newName As String = String.Empty
                        ext = Path.GetExtension(lstAttachmentDelete(i).FileName).ToLower
                        newName = patientId & "-" & recordId & "-" & lstAttachmentDelete(i).AttachmentId & ext
                        File.Delete(attachmentDirectory & "\" & newName)
                    Next
                End If

                If lstAttachment.Count > 0 Then
                    For i As Integer = 0 To lstAttachment.Count - 1
                        Dim ext As String = String.Empty
                        Dim newName As String = String.Empty
                        ext = Path.GetExtension(lstAttachment(i).FileName).ToLower
                        newName = patientId & "-" & recordId & "-" & lstAttachment(i).AttachmentId & ext
                        File.Delete(attachmentDirectory & "\" & newName)
                    Next
                End If

                Dim prm(0) As SqlParameter
                prm(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                prm(0).Value = recordId

                dbHealth.ExecuteNonQuery("DelEmployeeApeRecordId", CommandType.StoredProcedure, prm)

                Me.DialogResult = DialogResult.OK
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
            If lstAttachment.Count < 1 Then
                picImage.Image = Nothing
                lblFilename.Text = String.Empty
                Exit Sub
            Else
                If lstAttachment.Count > 0 Then
                    If File.Exists(lstAttachment(currentIndex).FileName) Then
                        Process.Start(lstAttachment(currentIndex).FileName)
                    End If
                End If
            End If
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
                        lstAttachmentDelete.Add(forDeleteItem)
                        lstAttachment.RemoveAt(currentIndex)
                    End If
                End If
            End If

            NextImage(-1)
            lblAttachmentCount.Text = String.Format("Attachment(s) : {0}", lstAttachment.Count)
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
            lblAttachmentCount.Text = String.Format("Attachment(s) : {0}", lstAttachment.Count)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

                If File.Exists(lstAttachment(currentIndex).FileName) Then
                    Using img As Image = Image.FromFile(lstAttachment(currentIndex).FileName)
                        picImage.Image = New Bitmap(img)
                    End Using
                Else
                    MessageBox.Show("Attachment is missing. Please contact IT.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            ElseIf lstDocumentFiles.Contains(lstAttachment(currentIndex).ExtensionName.ToString.Trim.ToLower) Then
                picImage.Visible = True
                axAcroPdf.Visible = False

                If File.Exists(lstAttachment(currentIndex).FileName) Then
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
                Else
                    MessageBox.Show("Attachment is missing. Please contact IT.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            ElseIf lstPdfFiles.Contains(lstAttachment(currentIndex).ExtensionName.ToString.Trim.ToLower) Then
                picImage.Visible = False
                axAcroPdf.Visible = True

                If File.Exists(lstAttachment(currentIndex).FileName) Then
                    axAcroPdf.src = lstAttachment(currentIndex).FileName + "#toolbar=0"
                    axAcroPdf.setShowToolbar(False)
                Else
                    MessageBox.Show("Attachment is missing. Please contact IT.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                picImage.Visible = True
                axAcroPdf.Visible = False
                picImage.Image = My.Resources.file_type_unknown_512px
            End If

            If File.Exists(lstAttachment(currentIndex).FileName) Then
                lblFilename.Text = lstAttachment(currentIndex).SafeName
            Else
                lblFilename.Text = ""
            End If

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
        If lstAttachmentCopy.Count > 0 Then
            Dim streamRead As System.IO.FileStream
            Dim streamWrite As System.IO.FileStream

            For i As Integer = 0 To lstAttachmentCopy.Count - 1
                streamRead = New System.IO.FileStream(lstAttachmentCopy(i).FileName, System.IO.FileMode.Open)
                streamWrite = New System.IO.FileStream(attachmentDirectory & "\" & lstAttachmentCopy(i).SafeName, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)

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