Imports BlackCoffeeLibrary
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Public Class ConsultationDetail
    Private WithEvents bsMedicine As New BindingSource
    Private WithEvents bsMedicineTrxDetail As New BindingSource
    Private WithEvents bsMedicineUnit As New BindingSource
    Private WithEvents createdDate As Binding
    Private WithEvents lmp As Binding
    Private WithEvents modifiedDate As Binding
    Private WithEvents timeIn As Binding
    Private WithEvents timeOut As Binding
    Private adpMedicineTrxDetail As New SqlDataAdapter
    Private agencyId As Integer = 0
    Private arrSplitted() As String

    Private attachmentDirectories As New clsDirectory

    Private bsEmpMedAttach As New BindingSource
    Private bsEmpMedRecord As New BindingSource
    Private connection As New clsConnection
    Private currentIndex As Integer
    Private dbHealth As New SqlDbMethod(connection.MyConnection)
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)
    Private dbMain As New BlackCoffeeLibrary.Main
    Private doctorId As Integer = 0
    Private dsHealth As New dsHealth
    Private dtEmployeeMedicalAttachment As New DataTable
    Private dtEmployeeMedicalRecord As New DataTable
    Private dtMedicine As New DataTable
    Private dtMedicineTrxDetail As New DataTable
    Private dtMedicineTrxHeader As New DataTable
    Private dtMedicineUnit As New DataTable
    Private dtRestAlarm As New DataTable
    Private imgTmp As String = String.Empty
    Private initialDirectory As String = attachmentDirectories.IniDirMedRecord
    Private isDebug As Boolean = HealthInformationSystem.My.Settings.IsDebug
    Private lstAttachment As New List(Of clsAttachment)
    Private lstAttachmentForCopy As New List(Of clsAttachment)
    Private lstAttachmentForDelete As New List(Of clsAttachment)
    Private lstDocumentFiles As New List(Of String)(New String() {".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".txt"})
    Private lstImageFiles As New List(Of String)(New String() {".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tif", ".tiff"})
    Private lstPdfFiles As New List(Of String)(New String() {".pdf"})
    Private medRecordDirectory As String = attachmentDirectories.AttDirMedRecord
    Private orgBedId As Integer = 0
    Private orgRoomId As Integer = 0
    Private patientId As Integer = 0
    Private recordId As Integer = 0
    Private stockId As Integer = 0
    Private tsRest As TimeSpan = Nothing

    Private unitId As Integer = 0
    Public Sub New(_doctorId As Integer, Optional _recordId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        doctorId = _doctorId
        recordId = _recordId

        dbMain.EnableDoubleBuffered(dgvDetail)

        dtMedicineTrxDetail = CreateMedicineTrxDetail()
        dtMedicine = dbHealth.FillDataTable("RdMedicine", CommandType.StoredProcedure)
        dtMedicineUnit = dbHealth.FillDataTable("RdMedicineUnit", CommandType.StoredProcedure)

        Me.bsMedicine.DataSource = dtMedicine
        Me.bsMedicineUnit.DataSource = dtMedicineUnit

        'medicine log table
        Dim colMedicineName As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        colMedicineName.Name = "ColMedicineName"
        colMedicineName.DataPropertyName = "MedicineId"
        colMedicineName.HeaderText = "Medicine"
        colMedicineName.DataSource = Me.bsMedicine
        colMedicineName.ValueMember = "MedicineId"
        colMedicineName.DisplayMember = "MedicineName"
        colMedicineName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colMedicineName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colMedicineName.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        colMedicineName.SortMode = DataGridViewColumnSortMode.Automatic
        dgvDetail.Columns.Insert(1, colMedicineName)

        Dim colUnitCode As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        colUnitCode.Name = "ColUnitCode"
        colUnitCode.DataPropertyName = "UnitId"
        colUnitCode.HeaderText = "UOM"
        colUnitCode.DataSource = Me.bsMedicineUnit
        colUnitCode.ValueMember = "UnitId"
        colUnitCode.DisplayMember = "UnitCode"
        colUnitCode.Width = 50
        colUnitCode.DefaultCellStyle.Font = New Font("Segoe UI", 8.0!, FontStyle.Regular)
        colUnitCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        colUnitCode.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        colUnitCode.SortMode = DataGridViewColumnSortMode.Automatic
        dgvDetail.Columns.Insert(4, colUnitCode)

        If recordId = 0 Then
            Me.bsMedicineTrxDetail.DataSource = dtMedicineTrxDetail
            dgvDetail.AutoGenerateColumns = False
            dgvDetail.DataSource = Me.bsMedicineTrxDetail
        Else
            'employee medical record
            Dim prmEmployeeMedicalRecord(0) As SqlParameter
            prmEmployeeMedicalRecord(0) = New SqlParameter("@RecordId", SqlDbType.Int)
            prmEmployeeMedicalRecord(0).Value = recordId
            dtEmployeeMedicalRecord = dbHealth.FillDataTable("RdEmployeeMedicalRecordByRecordId", CommandType.StoredProcedure, prmEmployeeMedicalRecord)

            'medicine header
            Dim prmMedicineTrxHeader(0) As SqlParameter
            prmMedicineTrxHeader(0) = New SqlParameter("@RecordId", SqlDbType.Int)
            prmMedicineTrxHeader(0).Value = recordId
            dtMedicineTrxHeader = dbHealth.FillDataTable("RdMedicineTrxHeaderByRecordId", CommandType.StoredProcedure, prmMedicineTrxHeader)

            'medicine trx detail
            If dtMedicineTrxHeader.Rows.Count > 0 Then
                Dim con As New SqlConnection(connection.MyConnection)
                Dim cmdSel As SqlCommand = con.CreateCommand
                cmdSel.CommandText = "RdMedicineTrxDetailByTrxId"
                cmdSel.CommandType = CommandType.StoredProcedure
                cmdSel.Parameters.AddWithValue("@TrxId", dtMedicineTrxHeader.Rows(0).Item("TrxId"))
                adpMedicineTrxDetail.SelectCommand = cmdSel
                adpMedicineTrxDetail.Fill(dtMedicineTrxDetail)
            Else

            End If

            'rest alarm
            Dim prmRestAlarm(0) As SqlParameter
            prmRestAlarm(0) = New SqlParameter("@RecordId", SqlDbType.Int)
            prmRestAlarm(0).Value = recordId
            dtRestAlarm = dbHealth.FillDataTable("RdRestAlarmByRecordId", CommandType.StoredProcedure, prmRestAlarm)

            'employee medical attachment
            Dim prmEmployeeMedicalAttachment(0) As SqlParameter
            prmEmployeeMedicalAttachment(0) = New SqlParameter("@RecordId", SqlDbType.Int)
            prmEmployeeMedicalAttachment(0).Value = recordId
            dtEmployeeMedicalAttachment = dbHealth.FillDataTable("RdEmployeeMedicalAttachmentByRecordId", CommandType.StoredProcedure, prmEmployeeMedicalAttachment)
        End If
    End Sub

    Private Delegate Sub SetProgressInvoker(textProgress As String, labelProgress As Label)

    Public Function GetCurrentAge(dob As Date) As Integer
        Dim age As Integer
        age = Today.Year - dob.Year
        If (dob > Today.AddYears(-age)) Then age -= 1
        Return age
    End Function

    Public Function GetExpectedTimeout(dt As DateTime, interval As TimeSpan) As DateTime
        'https://stackoverflow.com/questions/31904449/how-to-add-30-mins-for-current-time
        Return dt.Add(interval)
    End Function

    Public Async Sub OpenImage(ByVal imagePath As String, ByVal time As Integer)
        Try
            Dim exePathReturnValue = New StringBuilder()
            FindExecutable(Path.GetFileName(imagePath), Path.GetDirectoryName(imagePath), exePathReturnValue)
            Dim exePath = exePathReturnValue.ToString()
            Dim arguments = """" & imagePath & """"

            If Path.GetFileName(exePath).Equals("photoviewer.dll", StringComparison.InvariantCultureIgnoreCase) Then
                arguments = """" & exePath & """, ImageView_Fullscreen " & imagePath
                exePath = "rundll32"
            End If

            Dim process = New Process()
            process.StartInfo.FileName = exePath
            process.StartInfo.Arguments = arguments
            process.EnableRaisingEvents = True
            AddHandler process.Exited, New EventHandler(AddressOf DeleteTempImg)
            process.Start()

            Await Task.Delay(time)

            If Not process.HasExited Then
                process.Kill()
            End If

            process.Close()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    <DllImport("shell32.dll")>
    Private Shared Function FindExecutable(ByVal lpFile As String, ByVal lpDirectory As String, <Out> ByVal lpResult As StringBuilder) As Integer
    End Function

    Private Sub bgWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker.DoWork
        If lstAttachmentForCopy.Count > 0 Then
            Dim streamRead As System.IO.FileStream
            Dim streamWrite As System.IO.FileStream

            For i As Integer = 0 To lstAttachmentForCopy.Count - 1
                streamRead = New System.IO.FileStream(lstAttachmentForCopy(i).FileName, System.IO.FileMode.Open)
                streamWrite = New System.IO.FileStream(medRecordDirectory & "\" & lstAttachmentForCopy(i).SafeName, IO.FileMode.Create, IO.FileAccess.Write, IO.FileShare.None)

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

    Private Sub bgWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgWorker.ProgressChanged
        pbAttachment.Value = e.ProgressPercentage
    End Sub

    Private Sub bgWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted
        If e.Cancelled = True Then
            pbAttachment.Visible = False
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

    Private Sub btnAddRow_Click(sender As Object, e As EventArgs) Handles btnAddRow.Click
        Try
            If cmbMedicine.SelectedValue = 0 Then
                MessageBox.Show("Please select medicine.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbMedicine.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtQty.Text) OrElse CInt(txtQty.Text.Trim) = 0 Then
                MessageBox.Show("Please input quantity to be issued.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtQty.Focus()
                Exit Sub
            End If

            If CInt(txtQty.Text.Trim) > CInt(txtStock.Text.Trim) Then
                MessageBox.Show("Quantity to issue is greater than to stock quantity.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtQty.Focus()
                Exit Sub
            End If

            Dim cnt As Integer = 0
            For Each row As DataGridViewRow In dgvDetail.Rows
                If row.Cells("ColMedicineId").Value = cmbMedicine.SelectedValue Then
                    cnt += 1
                End If
            Next

            If cnt > 0 Then
                MessageBox.Show("The selected medicine already on the list.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbMedicine.Focus()
                Exit Sub
            End If

            Me.bsMedicineTrxDetail.AddNew()
            Me.bsMedicineTrxDetail.MoveLast()
            Me.bsMedicineTrxDetail.Current("TrxId") = DBNull.Value
            Me.bsMedicineTrxDetail.Current("MedicineId") = cmbMedicine.SelectedValue
            Me.bsMedicineTrxDetail.Current("UnitId") = unitId
            Me.bsMedicineTrxDetail.Current("Qty") = txtQty.Text.Trim
            Me.bsMedicineTrxDetail.Current("StockId") = stockId
            Me.bsMedicineTrxDetail.EndEdit()

            cmbMedicine.SelectedValue = 0
            stockId = 0
            unitId = 0
            txtQty.Text = ""
            txtStock.Text = ""

            cmbMedicine.Focus()

            lblMedicineCount.Text = "Medicine Qty : " & dgvDetail.Rows.Count
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Try
            ofdRecDetail.Filter = "Image Files (*.jpeg, *.png) | *.jpg; *.jpeg; *.png; *.bmp; *.gif; *.tif; *.tiff; |" &
                                  "Word Documents (*.doc) | *.doc; *.docx; |" &
                                  "Excel Worksheets (*.xls, *.xlsx) | *.xls; *.xlsx |" &
                                  "Presentation Files (*.ppt, *pptx) | *.ppt; *.pptx; *.odp; |" &
                                  "PDF Files (*.pdf) | *.pdf; |" &
                                  "Text Files (*.txt) | *.txt |" &
                                  "All Files (*.*) | *.*"
            ofdRecDetail.FilterIndex = 7
            ofdRecDetail.ShowDialog()
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If recordId = 0 Then Exit Sub

            If MessageBox.Show("Are you sure you want to delete this record?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) =
                System.Windows.Forms.DialogResult.Yes Then

                Dim prmRdDetail(0) As SqlParameter
                prmRdDetail(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                prmRdDetail(0).Value = dtMedicineTrxHeader.Rows(0).Item("TrxId")

                're-add the issued medicine quantity to current ending balance
                Using rdr As IDataReader = dbHealth.ExecuteReader("RdMedicineTrxDetailByTrxId", CommandType.StoredProcedure, prmRdDetail)
                    While rdr.Read
                        Dim prmAdj(2) As SqlParameter
                        prmAdj(0) = New SqlParameter("@StockId", SqlDbType.Int)
                        prmAdj(0).Value = rdr.Item("StockId")
                        prmAdj(1) = New SqlParameter("@TrxTypeId", SqlDbType.Int)
                        prmAdj(1).Value = 1
                        prmAdj(2) = New SqlParameter("@Qty", SqlDbType.Int)
                        prmAdj(2).Value = rdr.Item("Qty")

                        dbHealth.ExecuteNonQuery("UpdMedicineStockByStockId", CommandType.StoredProcedure, prmAdj)
                    End While
                    rdr.Close()
                End Using

                If lstAttachment.Count > 0 Then
                    For i As Integer = 0 To lstAttachment.Count - 1
                        Dim ext As String = String.Empty
                        Dim newName As String = String.Empty
                        ext = Path.GetExtension(lstAttachment(i).FileName).ToLower

                        If patientId <> 0 AndAlso agencyId = 0 Then 'nbc
                            newName = patientId & "-" & recordId & "-" & lstAttachment(i).AttachmentId & ext
                        Else
                            newName = txtEmployeeCode.Text.Trim.ToLower & "-" & recordId & "-" & lstAttachment(i).AttachmentId & ext
                        End If

                        File.Delete(medRecordDirectory & "\" & newName)
                    Next
                End If

                If dtRestAlarm.Rows.Count > 0 Then
                    'selected room was changed
                    Dim activeRestAlarmId As Integer = 0
                    Dim prmRdOrgRoom(0) As SqlParameter
                    prmRdOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                    prmRdOrgRoom(0).Value = orgRoomId

                    activeRestAlarmId = dbHealth.ExecuteScalar("SELECT RestAlarmId FROM dbo.RestAlarm WHERE RoomId = @RoomId AND IsActive = 1 ORDER BY RestAlarmId DESC", CommandType.Text, prmRdOrgRoom)

                    If activeRestAlarmId = dtRestAlarm.Rows(0).Item("RestAlarmId") Then
                        Dim prmOrgBed(1) As SqlParameter
                        prmOrgBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                        prmOrgBed(0).Value = 1
                        prmOrgBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                        prmOrgBed(1).Value = orgBedId

                        dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmOrgBed)

                        Dim prmOrgRoom(0) As SqlParameter
                        prmOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                        prmOrgRoom(0).Value = orgRoomId

                        dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmOrgRoom)
                    End If
                End If

                Dim prmDelRecord(0) As SqlParameter
                prmDelRecord(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                prmDelRecord(0).Value = recordId
                dbHealth.ExecuteNonQuery("DelEmployeeMedicalRecord", CommandType.StoredProcedure, prmDelRecord)

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnManualOut_Click(sender As Object, e As EventArgs) Handles btnManualOut.Click
        LogOut()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            NextImage(1)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        Try
            NextImage(-1)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try
            If lstAttachment.Count = 0 Then

            Else
                If recordId = 0 Then
                    lstAttachment.RemoveAt(currentIndex)
                Else
                    If Not lstAttachment(currentIndex).AttachmentId = 0 Then
                        Dim forDeleteItem As New clsAttachment(medRecordDirectory & "\" & lstAttachment(currentIndex).FileName,
                                                                   lstAttachment(currentIndex).SafeName,
                                                                   Path.GetExtension(lstAttachment(currentIndex).SafeName),
                                                                   lstAttachment(currentIndex).AttachmentId)
                        lstAttachmentForDelete.Add(forDeleteItem)
                        lstAttachment.RemoveAt(currentIndex)
                    End If
                End If
            End If

            NextImage(-1)
            lblAttachmentCount.Text = String.Format("Attachment Qty : {0}", lstAttachment.Count)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemoveRow_Click(sender As Object, e As EventArgs) Handles btnRemoveRow.Click
        Try
            If dgvDetail.Rows.Count > 0 Then
                Dim question As String = "Are you sure you want to remove this item?"

                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim currentRow = CType(Me.bsMedicineTrxDetail.Current, DataRowView).Row
                    Dim rowState = currentRow.RowState

                    Select Case rowState
                        Case DataRowState.Added
                            Me.bsMedicineTrxDetail.RemoveCurrent()

                        Case DataRowState.Detached
                            Me.bsMedicineTrxDetail.CancelEdit()

                        Case DataRowState.Modified, DataRowState.Unchanged
                            If dgvDetail.SelectedCells.Count > 0 AndAlso dgvDetail.SelectedCells(0).RowIndex = dgvDetail.NewRowIndex Then
                                Me.bsMedicineTrxDetail.CancelEdit()
                                Exit Sub
                            End If

                            Me.bsMedicineTrxDetail.RemoveCurrent()

                        Case Else
                            Me.bsMedicineTrxDetail.RemoveCurrent()
                    End Select
                End If
            End If

            cmbMedicine.Focus()
            lblMedicineCount.Text = "Medicine Qty : " & dgvDetail.Rows.Count
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If IsMaskedTextBoxEmpty(txtTimeIn) = True Then
                MessageBox.Show("Please input the time in.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ActiveControl = txtTimeIn
                Return
            End If

            If chkRest.Checked = True Then
                If String.IsNullOrWhiteSpace(txtRestMinutes.Text.Trim) OrElse CInt(txtRestMinutes.Text.Trim) = 0 Then
                    MessageBox.Show("Please input the rest minutes.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.ActiveControl = txtRestMinutes
                    Return
                End If

                If CInt(txtRestMinutes.Text.Trim) > 30 Then
                    MessageBox.Show("Rest time is limited to 30 minutes only.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.ActiveControl = txtRestMinutes
                    Return
                End If

                If cmbRoom.SelectedValue = 0 Then
                    MessageBox.Show("Please select a room.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.ActiveControl = cmbRoom
                    Return
                End If

                If cmbBed.SelectedValue = 0 Then
                    MessageBox.Show("Please select a bed.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.ActiveControl = cmbBed
                    Return
                End If
            Else
                If IsMaskedTextBoxEmpty(txtTimeOut) = True Then
                    MessageBox.Show("Please input the time out.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.ActiveControl = txtTimeOut
                    Return
                End If
            End If

            If String.IsNullOrEmpty(txtChiefComplaint.Text.Trim) Then
                MessageBox.Show("Please input the chief complaint.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ActiveControl = txtChiefComplaint
                Return
            End If

            If String.IsNullOrEmpty(txtDiagnosis.Text.Trim) Then
                MessageBox.Show("Please enter the diagnosis.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.ActiveControl = txtDiagnosis
                Return
            End If

            Dim rowCount As Integer = dgvDetail.RowCount

            'employee medical record
            If recordId = 0 Then 'new record
                Dim prmMedicalRecord(27) As SqlParameter
                prmMedicalRecord(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                prmMedicalRecord(0).Direction = ParameterDirection.Output
                prmMedicalRecord(1) = New SqlParameter("@CreatedBy", SqlDbType.Int)
                prmMedicalRecord(1).Value = doctorId
                prmMedicalRecord(2) = New SqlParameter("@CreatedDate", SqlDbType.DateTime2)
                prmMedicalRecord(2).Value = dbHealth.GetServerDate
                prmMedicalRecord(3) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                prmMedicalRecord(3).Value = patientId
                prmMedicalRecord(4) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
                prmMedicalRecord(4).Value = txtEmployeeCode.Text.Trim

                If IsMaskedTextBoxEmpty(txtLmp) = True Then
                    prmMedicalRecord(5) = New SqlParameter("@LMP", SqlDbType.Date)
                    prmMedicalRecord(5).Value = Nothing
                Else
                    prmMedicalRecord(5) = New SqlParameter("@LMP", SqlDbType.Date)
                    prmMedicalRecord(5).Value = CDate(txtLmp.Text)
                End If

                If String.IsNullOrWhiteSpace(txtTemperature.Text.Trim) Then
                    prmMedicalRecord(6) = New SqlParameter("@Temperature", SqlDbType.NVarChar)
                    prmMedicalRecord(6).Value = Nothing
                Else
                    prmMedicalRecord(6) = New SqlParameter("@Temperature", SqlDbType.NVarChar)
                    prmMedicalRecord(6).Value = txtTemperature.Text.Trim
                End If

                If String.IsNullOrWhiteSpace(txtBloodPressure.Text.Trim) Then
                    prmMedicalRecord(7) = New SqlParameter("@BloodPressure", SqlDbType.NVarChar)
                    prmMedicalRecord(7).Value = Nothing
                Else
                    prmMedicalRecord(7) = New SqlParameter("@BloodPressure", SqlDbType.NVarChar)
                    prmMedicalRecord(7).Value = txtBloodPressure.Text.Trim
                End If

                If String.IsNullOrWhiteSpace(txtOxygenLevel.Text.Trim) Then
                    prmMedicalRecord(8) = New SqlParameter("@OxygenLevel", SqlDbType.NVarChar)
                    prmMedicalRecord(8).Value = Nothing
                Else
                    prmMedicalRecord(8) = New SqlParameter("@OxygenLevel", SqlDbType.NVarChar)
                    prmMedicalRecord(8).Value = txtOxygenLevel.Text.Trim
                End If

                If String.IsNullOrWhiteSpace(txtPulseRate.Text.Trim) Then
                    prmMedicalRecord(9) = New SqlParameter("@PulseRate", SqlDbType.NVarChar)
                    prmMedicalRecord(9).Value = Nothing
                Else
                    prmMedicalRecord(9) = New SqlParameter("@PulseRate", SqlDbType.NVarChar)
                    prmMedicalRecord(9).Value = txtPulseRate.Text.Trim
                End If

                If String.IsNullOrWhiteSpace(txtRespiratoryRate.Text.Trim) Then
                    prmMedicalRecord(10) = New SqlParameter("@RespiratoryRate", SqlDbType.NVarChar)
                    prmMedicalRecord(10).Value = Nothing
                Else
                    prmMedicalRecord(10) = New SqlParameter("@RespiratoryRate", SqlDbType.NVarChar)
                    prmMedicalRecord(10).Value = txtRespiratoryRate.Text.Trim
                End If

                prmMedicalRecord(11) = New SqlParameter("@ChiefComplaint", SqlDbType.NVarChar)
                prmMedicalRecord(11).Value = txtChiefComplaint.Text.Trim
                prmMedicalRecord(12) = New SqlParameter("@Diagnosis", SqlDbType.NVarChar)
                prmMedicalRecord(12).Value = txtDiagnosis.Text.Trim

                If String.IsNullOrWhiteSpace(txtPlan.Text.Trim) Then
                    prmMedicalRecord(13) = New SqlParameter("@Plano", SqlDbType.NVarChar)
                    prmMedicalRecord(13).Value = Nothing
                Else
                    prmMedicalRecord(13) = New SqlParameter("@Plano", SqlDbType.NVarChar)
                    prmMedicalRecord(13).Value = txtPlan.Text.Trim
                End If

                If String.IsNullOrWhiteSpace(txtHpi.Text.Trim) Then
                    prmMedicalRecord(14) = New SqlParameter("@HPI", SqlDbType.NVarChar)
                    prmMedicalRecord(14).Value = Nothing
                Else
                    prmMedicalRecord(14) = New SqlParameter("@HPI", SqlDbType.NVarChar)
                    prmMedicalRecord(14).Value = txtHpi.Text.Trim
                End If

                If chkFitToWork.Checked = True Then
                    prmMedicalRecord(15) = New SqlParameter("@IsFitToWork", SqlDbType.Bit)
                    prmMedicalRecord(15).Value = True
                Else
                    prmMedicalRecord(15) = New SqlParameter("@IsFitToWork", SqlDbType.Bit)
                    prmMedicalRecord(15).Value = False
                End If

                If chkSentHome.Checked = True Then
                    prmMedicalRecord(16) = New SqlParameter("@IsSentHome", SqlDbType.Bit)
                    prmMedicalRecord(16).Value = True
                Else
                    prmMedicalRecord(16) = New SqlParameter("@IsSentHome", SqlDbType.Bit)
                    prmMedicalRecord(16).Value = False
                End If

                If chkTeleconsult.Checked = True Then
                    prmMedicalRecord(17) = New SqlParameter("@IsTeleConsult", SqlDbType.Bit)
                    prmMedicalRecord(17).Value = True
                Else
                    prmMedicalRecord(17) = New SqlParameter("@IsTeleConsult", SqlDbType.Bit)
                    prmMedicalRecord(17).Value = False
                End If

                If chkRest.Checked = True Then
                    prmMedicalRecord(18) = New SqlParameter("@IsRest", SqlDbType.Bit)
                    prmMedicalRecord(18).Value = True
                Else
                    prmMedicalRecord(18) = New SqlParameter("@IsRest", SqlDbType.Bit)
                    prmMedicalRecord(18).Value = False
                End If

                prmMedicalRecord(19) = New SqlParameter("@DatetimeStarted", SqlDbType.SmallDateTime)
                prmMedicalRecord(19).Value = txtTimeIn.Text.Trim

                If chkRest.Checked = True Then
                    If IsMaskedTextBoxEmpty(txtTimeOut) = True Then
                        prmMedicalRecord(20) = New SqlParameter("@DatetimeEnded", SqlDbType.SmallDateTime)
                        prmMedicalRecord(20).Value = Nothing
                    Else
                        'if specified timeout is less than to expected timeout, actual value of timeout will be the expected timeout
                        'if specified timeout is greater than to expected timeout, actual value of timeout will be the specified timeout
                        Dim expectedTimeOut As DateTime = GetExpectedTimeout(txtTimeIn.Text.Trim, TimeSpan.FromMinutes(txtRestMinutes.Text.Trim))
                        If Convert.ToDateTime(txtTimeOut.Text.Trim) < expectedTimeOut Then
                            prmMedicalRecord(20) = New SqlParameter("@DatetimeEnded", SqlDbType.SmallDateTime)
                            prmMedicalRecord(20).Value = expectedTimeOut
                        Else
                            prmMedicalRecord(20) = New SqlParameter("@DatetimeEnded", SqlDbType.SmallDateTime)
                            prmMedicalRecord(20).Value = txtTimeOut.Text.Trim
                        End If
                    End If

                    prmMedicalRecord(21) = New SqlParameter("@TotalRestTime", SqlDbType.Int)
                    prmMedicalRecord(21).Value = txtRestMinutes.Text.Trim
                    prmMedicalRecord(22) = New SqlParameter("@RoomId", SqlDbType.Int)
                    prmMedicalRecord(22).Value = cmbRoom.SelectedValue
                    prmMedicalRecord(23) = New SqlParameter("@BedId", SqlDbType.Int)
                    prmMedicalRecord(23).Value = cmbBed.SelectedValue

                Else 'employee did not rest
                    prmMedicalRecord(20) = New SqlParameter("@DatetimeEnded", SqlDbType.SmallDateTime)
                    prmMedicalRecord(20).Value = txtTimeOut.Text.Trim

                    prmMedicalRecord(21) = New SqlParameter("@TotalRestTime", SqlDbType.Int)
                    prmMedicalRecord(21).Value = 0
                    prmMedicalRecord(22) = New SqlParameter("@RoomId", SqlDbType.Int)
                    prmMedicalRecord(22).Value = Nothing
                    prmMedicalRecord(23) = New SqlParameter("@BedId", SqlDbType.Int)
                    prmMedicalRecord(23).Value = Nothing
                End If

                If patientId <> 0 AndAlso agencyId = 0 Then 'nbc
                    prmMedicalRecord(24) = New SqlParameter("@IsAgency", SqlDbType.Bit)
                    prmMedicalRecord(24).Value = False
                    prmMedicalRecord(25) = New SqlParameter("@AgencyId", SqlDbType.Int)
                    prmMedicalRecord(25).Value = Nothing
                Else 'agency
                    prmMedicalRecord(24) = New SqlParameter("@IsAgency", SqlDbType.Bit)
                    prmMedicalRecord(24).Value = True

                    If cmbAgency.Visible = True Then
                        prmMedicalRecord(25) = New SqlParameter("@AgencyId", SqlDbType.Int)
                        prmMedicalRecord(25).Value = cmbAgency.SelectedValue
                    Else
                        prmMedicalRecord(25) = New SqlParameter("@AgencyId", SqlDbType.Int)
                        prmMedicalRecord(25).Value = agencyId
                    End If
                End If

                prmMedicalRecord(26) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                prmMedicalRecord(26).Value = Nothing
                prmMedicalRecord(27) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime2)
                prmMedicalRecord(27).Value = Nothing

                dbHealth.ExecuteNonQuery("InsEmployeeMedicalRecord", CommandType.StoredProcedure, prmMedicalRecord)

                'rest alarm
                If chkRest.Checked = True Then
                    Dim expectedTimeOut As DateTime = GetExpectedTimeout(txtTimeIn.Text.Trim, TimeSpan.FromMinutes(txtRestMinutes.Text.Trim))

                    If IsMaskedTextBoxEmpty(txtTimeOut) = True Then 'no specified timeout, check if need to set an alarm
                        If expectedTimeOut > dbHealth.GetServerDate Then 'expected timeout is later than to current datetime, set an alarm
                            Dim prmAlarm(4) As SqlParameter
                            prmAlarm(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                            prmAlarm(0).Value = prmMedicalRecord(0).Value
                            prmAlarm(1) = New SqlParameter("@RoomId", SqlDbType.Int)
                            prmAlarm(1).Value = cmbRoom.SelectedValue
                            prmAlarm(2) = New SqlParameter("@BedId", SqlDbType.Int)
                            prmAlarm(2).Value = cmbBed.SelectedValue
                            prmAlarm(3) = New SqlParameter("@AlarmTime", SqlDbType.SmallDateTime)
                            prmAlarm(3).Value = expectedTimeOut
                            prmAlarm(4) = New SqlParameter("@IsActive", SqlDbType.Bit)
                            prmAlarm(4).Value = 1

                            dbHealth.ExecuteNonQuery("InsRestAlarm", CommandType.StoredProcedure, prmAlarm)

                            Dim prmBed(1) As SqlParameter
                            prmBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                            prmBed(0).Value = 0
                            prmBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                            prmBed(1).Value = cmbBed.SelectedValue

                            dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmBed)

                            Dim prmRoom(0) As SqlParameter
                            prmRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                            prmRoom(0).Value = cmbRoom.SelectedValue

                            dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmRoom)
                        Else
                            'expected timeout is earlier than to current datetime, no need to set an alarm
                        End If

                    Else
                        'with specified timeout, still check if need to set an alarm
                        'specified timeout is later than to expected timeout, actual value of timeout will be the specified timeout
                        If Convert.ToDateTime(txtTimeOut.Text.Trim) > expectedTimeOut Then
                            If Convert.ToDateTime(txtTimeOut.Text.Trim) > dbHealth.GetServerDate Then 'specified timeout is later than to current datetime, set an alarm
                                Dim prmAlarm(4) As SqlParameter
                                prmAlarm(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                                prmAlarm(0).Value = prmMedicalRecord(0).Value
                                prmAlarm(1) = New SqlParameter("@RoomId", SqlDbType.Int)
                                prmAlarm(1).Value = cmbRoom.SelectedValue
                                prmAlarm(2) = New SqlParameter("@BedId", SqlDbType.Int)
                                prmAlarm(2).Value = cmbBed.SelectedValue
                                prmAlarm(3) = New SqlParameter("@AlarmTime", SqlDbType.SmallDateTime)
                                prmAlarm(3).Value = txtTimeOut.Text.Trim
                                prmAlarm(4) = New SqlParameter("@IsActive", SqlDbType.Bit)
                                prmAlarm(4).Value = 1

                                dbHealth.ExecuteNonQuery("InsRestAlarm", CommandType.StoredProcedure, prmAlarm)

                                Dim prmBed(1) As SqlParameter
                                prmBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                prmBed(0).Value = 0
                                prmBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                prmBed(1).Value = cmbBed.SelectedValue

                                dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmBed)

                                Dim prmRoom(0) As SqlParameter
                                prmRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                prmRoom(0).Value = cmbRoom.SelectedValue

                                dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmRoom)
                            Else
                                'specified timeout is earlier than to current datetime, no need to set an alarm
                                'assuming this new record is for back encoding only
                            End If

                        Else
                            'specified timeout is earlier than to expected timeout, actual value of timeout will be the expected timeout
                            If expectedTimeOut > dbHealth.GetServerDate Then 'expected timeout is later than to current datetime, set an alarm
                                Dim prmAlarm(4) As SqlParameter
                                prmAlarm(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                                prmAlarm(0).Value = prmMedicalRecord(0).Value
                                prmAlarm(1) = New SqlParameter("@RoomId", SqlDbType.Int)
                                prmAlarm(1).Value = cmbRoom.SelectedValue
                                prmAlarm(2) = New SqlParameter("@BedId", SqlDbType.Int)
                                prmAlarm(2).Value = cmbBed.SelectedValue
                                prmAlarm(3) = New SqlParameter("@AlarmTime", SqlDbType.SmallDateTime)
                                prmAlarm(3).Value = expectedTimeOut
                                prmAlarm(4) = New SqlParameter("@IsActive", SqlDbType.Bit)
                                prmAlarm(4).Value = 1

                                dbHealth.ExecuteNonQuery("InsRestAlarm", CommandType.StoredProcedure, prmAlarm)

                                Dim prmBed(1) As SqlParameter
                                prmBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                prmBed(0).Value = 0
                                prmBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                prmBed(1).Value = cmbBed.SelectedValue

                                dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmBed)

                                Dim prmRoom(0) As SqlParameter
                                prmRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                prmRoom(0).Value = cmbRoom.SelectedValue

                                dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmRoom)
                            Else
                                'expected timeout is earlier than to current datetime, no need to set an alarm
                                'assuming this new record is for back encoding only
                            End If
                        End If
                    End If
                End If

                If dgvDetail.Rows.Count > 0 Then
                    'medicine trx header
                    Dim prmMedicalHeader(11) As SqlParameter
                    prmMedicalHeader(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                    prmMedicalHeader(0).Direction = ParameterDirection.Output
                    prmMedicalHeader(1) = New SqlParameter("@CreatedBy", SqlDbType.Int)
                    prmMedicalHeader(1).Value = doctorId
                    prmMedicalHeader(2) = New SqlParameter("@CreatedDate", SqlDbType.DateTime2)
                    prmMedicalHeader(2).Value = dbHealth.GetServerDate
                    prmMedicalHeader(3) = New SqlParameter("@RecordId", SqlDbType.Int)
                    prmMedicalHeader(3).Value = prmMedicalRecord(0).Value
                    prmMedicalHeader(4) = New SqlParameter("@TrxTypeId", SqlDbType.Int)
                    prmMedicalHeader(4).Value = 2 'issue
                    prmMedicalHeader(5) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                    prmMedicalHeader(5).Value = patientId
                    prmMedicalHeader(6) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
                    prmMedicalHeader(6).Value = txtEmployeeCode.Text.Trim

                    If patientId <> 0 AndAlso agencyId = 0 Then 'nbc
                        prmMedicalHeader(7) = New SqlParameter("@IsAgency", SqlDbType.Bit)
                        prmMedicalHeader(7).Value = False
                        prmMedicalHeader(8) = New SqlParameter("@AgencyId", SqlDbType.Int)
                        prmMedicalHeader(8).Value = Nothing
                    Else 'agency
                        prmMedicalHeader(7) = New SqlParameter("@IsAgency", SqlDbType.Bit)
                        prmMedicalHeader(7).Value = True

                        If cmbAgency.Visible = True Then
                            prmMedicalHeader(8) = New SqlParameter("@AgencyId", SqlDbType.Int)
                            prmMedicalHeader(8).Value = cmbAgency.SelectedValue
                        Else
                            prmMedicalHeader(8) = New SqlParameter("@AgencyId", SqlDbType.Int)
                            prmMedicalHeader(8).Value = agencyId
                        End If
                    End If

                    prmMedicalHeader(9) = New SqlParameter("@Remarks", SqlDbType.VarChar)
                    prmMedicalHeader(9).Value = Nothing
                    prmMedicalHeader(10) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                    prmMedicalHeader(10).Value = Nothing
                    prmMedicalHeader(11) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime2)
                    prmMedicalHeader(11).Value = Nothing

                    dbHealth.ExecuteNonQuery("InsMedicineTrxHeader", CommandType.StoredProcedure, prmMedicalHeader)

                    'medicine trx detail
                    For Each dataRowView As DataRowView In Me.bsMedicineTrxDetail
                        Dim row = dataRowView.Row
                        row.Item("TrxId") = prmMedicalHeader(0).Value

                        Dim prmAdj(2) As SqlParameter
                        prmAdj(0) = New SqlParameter("@StockId", SqlDbType.Int)
                        prmAdj(0).Value = row.Item("StockId")
                        prmAdj(1) = New SqlParameter("@TrxTypeId", SqlDbType.Int)
                        prmAdj(1).Value = 2
                        prmAdj(2) = New SqlParameter("@Qty", SqlDbType.Int)
                        prmAdj(2).Value = row.Item("Qty")

                        dbHealth.ExecuteNonQuery("UpdMedicineStockByStockId", CommandType.StoredProcedure, prmAdj)
                    Next
                    bsMedicineTrxDetail.EndEdit()
                    adpMedicineTrxDetail.Update(dtMedicineTrxDetail)
                End If

                'employee medical attachment
                If lstAttachment.Count > 0 Then
                    For i As Integer = 0 To lstAttachment.Count - 1
                        Dim prmAttachment(2) As SqlParameter
                        prmAttachment(0) = New SqlParameter("@AttachmentId", SqlDbType.Int)
                        prmAttachment(0).Direction = ParameterDirection.Output
                        prmAttachment(1) = New SqlParameter("@RecordId", SqlDbType.Int)
                        prmAttachment(1).Value = prmMedicalRecord(0).Value
                        prmAttachment(2) = New SqlParameter("@Filename", SqlDbType.NVarChar)
                        prmAttachment(2).Value = ""

                        dbHealth.ExecuteNonQuery("InsEmployeeMedicalAttachment", CommandType.StoredProcedure, prmAttachment)

                        Dim ext As String = String.Empty
                        Dim newName As String = String.Empty
                        ext = Path.GetExtension(lstAttachment(i).FileName).ToLower

                        If patientId <> 0 AndAlso agencyId = 0 Then 'nbc
                            newName = patientId & "-" & prmMedicalRecord(0).Value & "-" & prmAttachment(0).Value & ext
                        Else 'agency
                            newName = txtEmployeeCode.Text.ToString.ToLower & "-" & prmMedicalRecord(0).Value & "-" & prmAttachment(0).Value & ext
                        End If

                        Dim prmUpd(2) As SqlParameter
                        prmUpd(0) = New SqlParameter("@AttachmentId", SqlDbType.Int)
                        prmUpd(0).Value = prmAttachment(0).Value
                        prmUpd(1) = New SqlParameter("@RecordId", SqlDbType.Int)
                        prmUpd(1).Value = prmMedicalRecord(0).Value
                        prmUpd(2) = New SqlParameter("@Filename", SqlDbType.NVarChar)
                        prmUpd(2).Value = newName

                        dbHealth.ExecuteNonQuery("UpdEmployeeMedicalAttachment", CommandType.StoredProcedure, prmUpd)

                        pbAttachment.Visible = True
                        lblProgress.Visible = True

                        Dim copyAttachment As New clsAttachment(lstAttachment(i).FileName, newName, lstAttachment(i).FileName)
                        lstAttachmentForCopy.Add(copyAttachment)
                    Next
                End If

                'check if employee name is already in the agency masterlist
                'if not, insert name, if yes, update name based on badge number
                If patientId = 0 AndAlso txtEmployeeNameAgency.Visible = True Then 'agency
                    Dim countEmp As Integer = 0
                    Dim prmCnt(0) As SqlParameter
                    prmCnt(0) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
                    prmCnt(0).Value = txtEmployeeCode.Text.Trim

                    countEmp = dbHealth.ExecuteScalar("SELECT COUNT(EmployeeCode) FROM dbo.EmployeeAgency WHERE TRIM(EmployeeCode) = @EmployeeCode", CommandType.Text, prmCnt)

                    If countEmp > 0 Then
                        Dim prmInsAgency(5) As SqlParameter
                        prmInsAgency(0) = New SqlParameter("@EmployeeName", SqlDbType.VarChar)
                        prmInsAgency(0).Value = txtEmployeeNameAgency.Text.Trim
                        prmInsAgency(1) = New SqlParameter("@AgencyId", SqlDbType.Int)
                        prmInsAgency(1).Value = cmbAgency.SelectedValue
                        prmInsAgency(2) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                        prmInsAgency(2).Value = doctorId
                        prmInsAgency(3) = New SqlParameter("@ModifiedDate", SqlDbType.VarChar)
                        prmInsAgency(3).Value = dbHealth.GetServerDate
                        prmInsAgency(4) = New SqlParameter("@IsActive", SqlDbType.Bit)
                        prmInsAgency(4).Value = True
                        prmInsAgency(5) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
                        prmInsAgency(5).Value = txtEmployeeCode.Text.Trim

                        dbHealth.ExecuteNonQuery("UpdEmployeeAgency", CommandType.StoredProcedure, prmInsAgency)
                    Else
                        Dim prmInsAgency(5) As SqlParameter
                        prmInsAgency(0) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
                        prmInsAgency(0).Value = txtEmployeeCode.Text.Trim
                        prmInsAgency(1) = New SqlParameter("@CreatedBy", SqlDbType.Int)
                        prmInsAgency(1).Value = doctorId
                        prmInsAgency(2) = New SqlParameter("@CreatedDate", SqlDbType.DateTime2)
                        prmInsAgency(2).Value = dbHealth.GetServerDate
                        prmInsAgency(3) = New SqlParameter("@EmployeeName", SqlDbType.VarChar)
                        prmInsAgency(3).Value = txtEmployeeNameAgency.Text.Trim
                        prmInsAgency(4) = New SqlParameter("@AgencyId", SqlDbType.Int)
                        prmInsAgency(4).Value = cmbAgency.SelectedValue
                        prmInsAgency(5) = New SqlParameter("@IsActive", SqlDbType.Bit)
                        prmInsAgency(5).Value = 1

                        dbHealth.ExecuteNonQuery("InsEmployeeAgency", CommandType.StoredProcedure, prmInsAgency)
                    End If
                End If

                btnPrevious.Enabled = False
                btnNext.Enabled = False
                btnView.Enabled = False
                btnBrowse.Enabled = False
                btnRemove.Enabled = False
                btnSave.Enabled = False
                btnCancel.Enabled = False
                btnDelete.Enabled = False
                btnClose.Enabled = False
                Me.ControlBox = False

                bgWorker.RunWorkerAsync()

            Else 'existing record
                Dim prmMedicalRecord(25) As SqlParameter
                prmMedicalRecord(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                prmMedicalRecord(0).Value = recordId
                prmMedicalRecord(1) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                prmMedicalRecord(1).Value = patientId
                prmMedicalRecord(2) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
                prmMedicalRecord(2).Value = txtEmployeeCode.Text.Trim

                If IsMaskedTextBoxEmpty(txtLmp) = True Then
                    prmMedicalRecord(3) = New SqlParameter("@LMP", SqlDbType.Date)
                    prmMedicalRecord(3).Value = Nothing
                Else
                    prmMedicalRecord(3) = New SqlParameter("@LMP", SqlDbType.Date)
                    prmMedicalRecord(3).Value = CDate(txtLmp.Text.Trim)
                End If

                prmMedicalRecord(4) = New SqlParameter("@Temperature", SqlDbType.NVarChar)
                prmMedicalRecord(4).Value = IIf(String.IsNullOrWhiteSpace(txtTemperature.Text.Trim) = True, Nothing, txtTemperature.Text.Trim)
                prmMedicalRecord(5) = New SqlParameter("@BloodPressure", SqlDbType.NVarChar)
                prmMedicalRecord(5).Value = IIf(String.IsNullOrWhiteSpace(txtBloodPressure.Text.Trim) = True, Nothing, txtBloodPressure.Text.Trim)
                prmMedicalRecord(6) = New SqlParameter("@OxygenLevel", SqlDbType.NVarChar)
                prmMedicalRecord(6).Value = IIf(String.IsNullOrWhiteSpace(txtOxygenLevel.Text.Trim) = True, Nothing, txtOxygenLevel.Text.Trim)
                prmMedicalRecord(7) = New SqlParameter("@PulseRate", SqlDbType.NVarChar)
                prmMedicalRecord(7).Value = IIf(String.IsNullOrWhiteSpace(txtPulseRate.Text.Trim) = True, Nothing, txtPulseRate.Text.Trim)
                prmMedicalRecord(8) = New SqlParameter("@RespiratoryRate", SqlDbType.NVarChar)
                prmMedicalRecord(8).Value = IIf(String.IsNullOrWhiteSpace(txtRespiratoryRate.Text.Trim) = True, Nothing, txtRespiratoryRate.Text.Trim)
                prmMedicalRecord(9) = New SqlParameter("@ChiefComplaint", SqlDbType.NVarChar)
                prmMedicalRecord(9).Value = txtChiefComplaint.Text.Trim
                prmMedicalRecord(10) = New SqlParameter("@Diagnosis", SqlDbType.NVarChar)
                prmMedicalRecord(10).Value = txtDiagnosis.Text.Trim
                prmMedicalRecord(11) = New SqlParameter("@Plano", SqlDbType.NVarChar)
                prmMedicalRecord(11).Value = IIf(String.IsNullOrWhiteSpace(txtPlan.Text.Trim) = True, Nothing, txtPlan.Text.Trim)
                prmMedicalRecord(12) = New SqlParameter("@HPI", SqlDbType.NVarChar)
                prmMedicalRecord(12).Value = IIf(String.IsNullOrWhiteSpace(txtHpi.Text.Trim) = True, Nothing, txtHpi.Text.Trim)
                prmMedicalRecord(13) = New SqlParameter("@IsFitToWork", SqlDbType.Bit)
                prmMedicalRecord(13).Value = IIf(chkFitToWork.Checked = True, True, False)
                prmMedicalRecord(14) = New SqlParameter("@IsSentHome", SqlDbType.Bit)
                prmMedicalRecord(14).Value = IIf(chkSentHome.Checked = True, True, False)
                prmMedicalRecord(15) = New SqlParameter("@IsTeleConsult", SqlDbType.Bit)
                prmMedicalRecord(15).Value = IIf(chkTeleconsult.Checked = True, True, False)

                If chkRest.Checked = True Then
                    prmMedicalRecord(16) = New SqlParameter("@IsRest", SqlDbType.Bit)
                    prmMedicalRecord(16).Value = True
                    prmMedicalRecord(17) = New SqlParameter("@DatetimeStarted", SqlDbType.SmallDateTime)
                    prmMedicalRecord(17).Value = Convert.ToDateTime(txtTimeIn.Text.Trim)

                    If IsMaskedTextBoxEmpty(txtTimeOut) = True Then
                        prmMedicalRecord(18) = New SqlParameter("@DatetimeEnded", SqlDbType.SmallDateTime)
                        prmMedicalRecord(18).Value = Nothing
                        prmMedicalRecord(19) = New SqlParameter("@TotalRestTime", SqlDbType.Int)
                        prmMedicalRecord(19).Value = 0
                    Else
                        'if specified timeout is less than to expected timeout, actual value of timeout will be the expected timeout
                        'if specified timeout is greater than to expected timeout, actual value of timeout will be the specified timeout
                        Dim expectedTimeOut As DateTime = GetExpectedTimeout(txtTimeIn.Text.Trim, TimeSpan.FromMinutes(txtRestMinutes.Text.Trim))
                        If Convert.ToDateTime(txtTimeOut.Text.Trim) < expectedTimeOut Then
                            prmMedicalRecord(18) = New SqlParameter("@DatetimeEnded", SqlDbType.SmallDateTime)
                            prmMedicalRecord(18).Value = expectedTimeOut
                        Else
                            prmMedicalRecord(18) = New SqlParameter("@DatetimeEnded", SqlDbType.SmallDateTime)
                            prmMedicalRecord(18).Value = txtTimeOut.Text.Trim
                        End If

                        prmMedicalRecord(19) = New SqlParameter("@TotalRestTime", SqlDbType.Int)
                        prmMedicalRecord(19).Value = txtRestMinutes.Text.Trim
                    End If

                    prmMedicalRecord(20) = New SqlParameter("@RoomId", SqlDbType.Int)
                    prmMedicalRecord(20).Value = cmbRoom.SelectedValue
                    prmMedicalRecord(21) = New SqlParameter("@BedId", SqlDbType.Int)
                    prmMedicalRecord(21).Value = cmbBed.SelectedValue

                Else 'employee did not rest
                    prmMedicalRecord(16) = New SqlParameter("@IsRest", SqlDbType.Bit)
                    prmMedicalRecord(16).Value = False
                    prmMedicalRecord(17) = New SqlParameter("@DatetimeStarted", SqlDbType.SmallDateTime)
                    prmMedicalRecord(17).Value = Convert.ToDateTime(txtTimeIn.Text.Trim)
                    prmMedicalRecord(18) = New SqlParameter("@DatetimeEnded", SqlDbType.SmallDateTime)
                    prmMedicalRecord(18).Value = txtTimeOut.Text.Trim

                    prmMedicalRecord(19) = New SqlParameter("@TotalRestTime", SqlDbType.Int)
                    prmMedicalRecord(19).Value = 0
                    prmMedicalRecord(20) = New SqlParameter("@RoomId", SqlDbType.Int)
                    prmMedicalRecord(20).Value = Nothing
                    prmMedicalRecord(21) = New SqlParameter("@BedId", SqlDbType.Int)
                    prmMedicalRecord(21).Value = Nothing
                End If

                If patientId <> 0 AndAlso agencyId = 0 Then 'nbc
                    prmMedicalRecord(22) = New SqlParameter("@IsAgency", SqlDbType.Bit)
                    prmMedicalRecord(22).Value = False
                    prmMedicalRecord(23) = New SqlParameter("@AgencyId", SqlDbType.Int)
                    prmMedicalRecord(23).Value = Nothing
                Else
                    prmMedicalRecord(22) = New SqlParameter("@IsAgency", SqlDbType.Bit)
                    prmMedicalRecord(22).Value = True
                    prmMedicalRecord(23) = New SqlParameter("@AgencyId", SqlDbType.Int)
                    prmMedicalRecord(23).Value = agencyId
                End If

                prmMedicalRecord(24) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                prmMedicalRecord(24).Value = doctorId
                prmMedicalRecord(25) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime2)
                prmMedicalRecord(25).Value = dbHealth.GetServerDate

                dbHealth.ExecuteNonQuery("UpdEmployeeMedicalRecordByRecordId", CommandType.StoredProcedure, prmMedicalRecord)

                'rest alarm
                If chkRest.Checked = True Then
                    Dim expectedTimeOut As DateTime = GetExpectedTimeout(txtTimeIn.Text.Trim, TimeSpan.FromMinutes(txtRestMinutes.Text.Trim))

                    If IsMaskedTextBoxEmpty(txtTimeOut) = True Then 'no timeout specified, check if need to set an alarm
                        If expectedTimeOut > dbHealth.GetServerDate Then 'expected timeout is later than to current datetime, set an alarm
                            If dtRestAlarm.Rows.Count > 0 Then
                                Dim prmAlarm(4) As SqlParameter
                                prmAlarm(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                                prmAlarm(0).Value = recordId
                                prmAlarm(1) = New SqlParameter("@RoomId", SqlDbType.Int)
                                prmAlarm(1).Value = cmbRoom.SelectedValue
                                prmAlarm(2) = New SqlParameter("@BedId", SqlDbType.Int)
                                prmAlarm(2).Value = cmbBed.SelectedValue
                                prmAlarm(3) = New SqlParameter("@AlarmTime", SqlDbType.SmallDateTime)
                                prmAlarm(3).Value = expectedTimeOut
                                prmAlarm(4) = New SqlParameter("@IsActive", SqlDbType.Bit)
                                prmAlarm(4).Value = 1

                                dbHealth.ExecuteNonQuery("UpdRestAlarmByRecordId", CommandType.StoredProcedure, prmAlarm)

                                'selected room was changed, selected bed id was also changed
                                If orgRoomId <> cmbRoom.SelectedValue Then
                                    Dim lastRestAlarmId As Integer = 0
                                    Dim prmRdOrgRoom(0) As SqlParameter
                                    prmRdOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                    prmRdOrgRoom(0).Value = orgRoomId

                                    lastRestAlarmId = dbHealth.ExecuteScalar("SELECT RestAlarmId FROM dbo.RestAlarm WHERE RoomId = @RoomId AND IsActive = 1 ORDER BY RestAlarmId DESC", CommandType.Text, prmRdOrgRoom)

                                    If lastRestAlarmId = dtRestAlarm.Rows(0).Item("RestAlarmId") Then 'last rest alarm trx using the original room, set original bed to vacant
                                        Dim prmOrgBed(1) As SqlParameter
                                        prmOrgBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                        prmOrgBed(0).Value = 1
                                        prmOrgBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                        prmOrgBed(1).Value = orgBedId

                                        dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmOrgBed)

                                        Dim prmOrgRoom(0) As SqlParameter
                                        prmOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                        prmOrgRoom(0).Value = orgRoomId

                                        dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmOrgRoom)
                                    End If
                                Else 'selected room was not changed, check if selected bed was changed
                                    If orgBedId <> cmbBed.SelectedValue Then
                                        Dim lastRestAlarmId As Integer = 0
                                        Dim prmRdOrgBed(0) As SqlParameter
                                        prmRdOrgBed(0) = New SqlParameter("@BedId", SqlDbType.Int)
                                        prmRdOrgBed(0).Value = orgRoomId

                                        lastRestAlarmId = dbHealth.ExecuteScalar("SELECT RestAlarmId FROM dbo.RestAlarm WHERE BedId = @BedId AND IsActive = 1 ORDER BY RestAlarmId DESC", CommandType.Text, prmRdOrgBed)

                                        If lastRestAlarmId = dtRestAlarm.Rows(0).Item("RestAlarmId") Then 'last rest alarm trx using the original bed, set original bed to vacant
                                            Dim prmOrgBed(1) As SqlParameter
                                            prmOrgBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                            prmOrgBed(0).Value = 1
                                            prmOrgBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                            prmOrgBed(1).Value = orgBedId

                                            dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmOrgBed)

                                            Dim prmOrgRoom(0) As SqlParameter
                                            prmOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                            prmOrgRoom(0).Value = orgRoomId

                                            dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmOrgRoom)
                                        End If
                                    End If
                                End If
                            Else
                                Dim prmAlarm(4) As SqlParameter
                                prmAlarm(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                                prmAlarm(0).Value = prmMedicalRecord(0).Value
                                prmAlarm(1) = New SqlParameter("@RoomId", SqlDbType.Int)
                                prmAlarm(1).Value = cmbRoom.SelectedValue
                                prmAlarm(2) = New SqlParameter("@BedId", SqlDbType.Int)
                                prmAlarm(2).Value = cmbBed.SelectedValue
                                prmAlarm(3) = New SqlParameter("@AlarmTime", SqlDbType.SmallDateTime)
                                prmAlarm(3).Value = expectedTimeOut
                                prmAlarm(4) = New SqlParameter("@IsActive", SqlDbType.Bit)
                                prmAlarm(4).Value = 1

                                dbHealth.ExecuteNonQuery("InsRestAlarm", CommandType.StoredProcedure, prmAlarm)
                            End If

                            Dim prmBed(1) As SqlParameter
                            prmBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                            prmBed(0).Value = 0
                            prmBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                            prmBed(1).Value = cmbBed.SelectedValue

                            dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmBed)

                            Dim prmRoom(0) As SqlParameter
                            prmRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                            prmRoom(0).Value = cmbRoom.SelectedValue

                            dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmRoom)

                        Else
                            'expected timeout is earlier than to current datetime, no need to set an alarm
                            'if has existing alarm, disable the alarm
                            If dtRestAlarm.Rows.Count > 0 Then 'disable scheduled alarm
                                Dim prmAlarm(4) As SqlParameter
                                prmAlarm(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                                prmAlarm(0).Value = recordId
                                prmAlarm(1) = New SqlParameter("@RoomId", SqlDbType.Int)
                                prmAlarm(1).Value = cmbRoom.SelectedValue
                                prmAlarm(2) = New SqlParameter("@BedId", SqlDbType.Int)
                                prmAlarm(2).Value = cmbBed.SelectedValue
                                prmAlarm(3) = New SqlParameter("@AlarmTime", SqlDbType.SmallDateTime)
                                prmAlarm(3).Value = expectedTimeOut
                                prmAlarm(4) = New SqlParameter("@IsActive", SqlDbType.Bit)
                                prmAlarm(4).Value = 0

                                dbHealth.ExecuteNonQuery("UpdRestAlarmByRecordId", CommandType.StoredProcedure, prmAlarm)

                                'selected room was changed
                                If orgRoomId <> cmbRoom.SelectedValue Then
                                    Dim lastRestAlarmId As Integer = 0
                                    Dim prmRdOrgRoom(0) As SqlParameter
                                    prmRdOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                    prmRdOrgRoom(0).Value = orgRoomId

                                    lastRestAlarmId = dbHealth.ExecuteScalar("SELECT RestAlarmId FROM dbo.RestAlarm WHERE RoomId = @RoomId AND IsActive = 1 ORDER BY RestAlarmId DESC", CommandType.Text, prmRdOrgRoom)

                                    If lastRestAlarmId = dtRestAlarm.Rows(0).Item("RestAlarmId") Then 'last rest alarm trx using the original room, set original bed to vacant
                                        Dim prmOrgBed(1) As SqlParameter
                                        prmOrgBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                        prmOrgBed(0).Value = 1
                                        prmOrgBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                        prmOrgBed(1).Value = orgBedId

                                        dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmOrgBed)

                                        Dim prmOrgRoom(0) As SqlParameter
                                        prmOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                        prmOrgRoom(0).Value = orgRoomId

                                        dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmOrgRoom)
                                    End If
                                Else 'selected room was not changed, check if selected bed was also changed
                                    If orgBedId <> cmbBed.SelectedValue Then
                                        Dim lastRestAlarmId As Integer = 0
                                        Dim prmRdOrgBed(0) As SqlParameter
                                        prmRdOrgBed(0) = New SqlParameter("@BedId", SqlDbType.Int)
                                        prmRdOrgBed(0).Value = orgBedId

                                        lastRestAlarmId = dbHealth.ExecuteScalar("SELECT RestAlarmId FROM dbo.RestAlarm WHERE BedId = @BedId AND IsActive = 1 ORDER BY RestAlarmId DESC", CommandType.Text, prmRdOrgBed)

                                        If lastRestAlarmId = dtRestAlarm.Rows(0).Item("RestAlarmId") Then 'last rest alarm trx using the original bed, set original bed to vacant
                                            Dim prmOrgBed(1) As SqlParameter
                                            prmOrgBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                            prmOrgBed(0).Value = 1
                                            prmOrgBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                            prmOrgBed(1).Value = orgBedId

                                            dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmOrgBed)

                                            Dim prmOrgRoom(0) As SqlParameter
                                            prmOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                            prmOrgRoom(0).Value = orgRoomId

                                            dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmOrgRoom)
                                        End If
                                    End If
                                End If

                                Dim prmBed(1) As SqlParameter
                                prmBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                prmBed(0).Value = 1
                                prmBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                prmBed(1).Value = cmbBed.SelectedValue

                                dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmBed)

                                Dim prmRoom(0) As SqlParameter
                                prmRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                prmRoom(0).Value = cmbRoom.SelectedValue

                                dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmRoom)
                            Else
                                'no need to set an alarm
                            End If
                        End If

                    Else 'with timeout specified, still check if need to set an alarm
                        'specified timeout is later than to expected timeout, actual value of timeout will be the specified timeou
                        If Convert.ToDateTime(txtTimeOut.Text.Trim) > expectedTimeOut Then
                            If Convert.ToDateTime(txtTimeOut.Text.Trim) > dbHealth.GetServerDate Then 'specified timeout is later than to current datetime, set an alarm
                                If dtRestAlarm.Rows.Count > 0 Then
                                    Dim prmAlarm(4) As SqlParameter
                                    prmAlarm(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                                    prmAlarm(0).Value = recordId
                                    prmAlarm(1) = New SqlParameter("@RoomId", SqlDbType.Int)
                                    prmAlarm(1).Value = cmbRoom.SelectedValue
                                    prmAlarm(2) = New SqlParameter("@BedId", SqlDbType.Int)
                                    prmAlarm(2).Value = cmbBed.SelectedValue
                                    prmAlarm(3) = New SqlParameter("@AlarmTime", SqlDbType.SmallDateTime)
                                    prmAlarm(3).Value = txtTimeOut.Text.Trim
                                    prmAlarm(4) = New SqlParameter("@IsActive", SqlDbType.Bit)
                                    prmAlarm(4).Value = 1

                                    dbHealth.ExecuteNonQuery("UpdRestAlarmByRecordId", CommandType.StoredProcedure, prmAlarm)

                                    'selected room was changed
                                    If orgRoomId <> cmbRoom.SelectedValue Then
                                        Dim activeRestAlarmId As Integer = 0
                                        Dim prmRdOrgRoom(0) As SqlParameter
                                        prmRdOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                        prmRdOrgRoom(0).Value = orgRoomId

                                        activeRestAlarmId = dbHealth.ExecuteScalar("SELECT RestAlarmId FROM dbo.RestAlarm WHERE RoomId = @RoomId AND IsActive = 1 ORDER BY RestAlarmId DESC", CommandType.Text, prmRdOrgRoom)

                                        If activeRestAlarmId = dtRestAlarm.Rows(0).Item("RestAlarmId") Then
                                            Dim prmOrgBed(1) As SqlParameter
                                            prmOrgBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                            prmOrgBed(0).Value = 1
                                            prmOrgBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                            prmOrgBed(1).Value = orgBedId

                                            dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmOrgBed)

                                            Dim prmOrgRoom(0) As SqlParameter
                                            prmOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                            prmOrgRoom(0).Value = orgRoomId

                                            dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmOrgRoom)
                                        End If
                                    Else
                                        If orgBedId <> cmbBed.SelectedValue Then
                                            Dim lastRestAlarmId As Integer = 0
                                            Dim prmRdOrgBed(0) As SqlParameter
                                            prmRdOrgBed(0) = New SqlParameter("@BedId", SqlDbType.Int)
                                            prmRdOrgBed(0).Value = orgBedId

                                            lastRestAlarmId = dbHealth.ExecuteScalar("SELECT RestAlarmId FROM dbo.RestAlarm WHERE BedId = @BedId AND IsActive = 1 ORDER BY RestAlarmId DESC", CommandType.Text, prmRdOrgBed)

                                            If lastRestAlarmId = dtRestAlarm.Rows(0).Item("RestAlarmId") Then 'last rest alarm trx using the original bed, set original bed to vacant
                                                Dim prmOrgBed(1) As SqlParameter
                                                prmOrgBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                                prmOrgBed(0).Value = 1
                                                prmOrgBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                                prmOrgBed(1).Value = orgBedId

                                                dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmOrgBed)

                                                Dim prmOrgRoom(0) As SqlParameter
                                                prmOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                                prmOrgRoom(0).Value = orgRoomId

                                                dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmOrgRoom)
                                            End If
                                        End If
                                    End If
                                Else
                                    Dim prmAlarm(4) As SqlParameter
                                    prmAlarm(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                                    prmAlarm(0).Value = prmMedicalRecord(0).Value
                                    prmAlarm(1) = New SqlParameter("@RoomId", SqlDbType.Int)
                                    prmAlarm(1).Value = cmbRoom.SelectedValue
                                    prmAlarm(2) = New SqlParameter("@BedId", SqlDbType.Int)
                                    prmAlarm(2).Value = cmbBed.SelectedValue
                                    prmAlarm(3) = New SqlParameter("@AlarmTime", SqlDbType.SmallDateTime)
                                    prmAlarm(3).Value = txtTimeOut.Text.Trim
                                    prmAlarm(4) = New SqlParameter("@IsActive", SqlDbType.Bit)
                                    prmAlarm(4).Value = 1

                                    dbHealth.ExecuteNonQuery("InsRestAlarm", CommandType.StoredProcedure, prmAlarm)
                                End If

                                Dim prmBed(1) As SqlParameter
                                prmBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                prmBed(0).Value = 0
                                prmBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                prmBed(1).Value = cmbBed.SelectedValue

                                dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmBed)

                                Dim prmRoom(0) As SqlParameter
                                prmRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                prmRoom(0).Value = cmbRoom.SelectedValue

                                dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmRoom)

                            Else
                                'specified timeout is earlier later than to current datetime, no need to set an alarm
                                'if has existing alarm, disable the alarm
                                If dtRestAlarm.Rows.Count > 0 Then
                                    Dim prmAlarm(4) As SqlParameter
                                    prmAlarm(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                                    prmAlarm(0).Value = recordId
                                    prmAlarm(1) = New SqlParameter("@RoomId", SqlDbType.Int)
                                    prmAlarm(1).Value = cmbRoom.SelectedValue
                                    prmAlarm(2) = New SqlParameter("@BedId", SqlDbType.Int)
                                    prmAlarm(2).Value = cmbBed.SelectedValue
                                    prmAlarm(3) = New SqlParameter("@AlarmTime", SqlDbType.SmallDateTime)
                                    prmAlarm(3).Value = txtTimeOut.Text.Trim
                                    prmAlarm(4) = New SqlParameter("@IsActive", SqlDbType.Bit)
                                    prmAlarm(4).Value = 0

                                    dbHealth.ExecuteNonQuery("UpdRestAlarmByRecordId", CommandType.StoredProcedure, prmAlarm)

                                    'selected room was changed
                                    If orgRoomId <> cmbRoom.SelectedValue Then
                                        Dim activeRestAlarmId As Integer = 0
                                        Dim prmRdOrgRoom(0) As SqlParameter
                                        prmRdOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                        prmRdOrgRoom(0).Value = orgRoomId

                                        activeRestAlarmId = dbHealth.ExecuteScalar("SELECT RestAlarmId FROM dbo.RestAlarm WHERE RoomId = @RoomId AND IsActive = 1 ORDER BY RestAlarmId DESC", CommandType.Text, prmRdOrgRoom)

                                        If activeRestAlarmId = dtRestAlarm.Rows(0).Item("RestAlarmId") Then
                                            Dim prmOrgBed(1) As SqlParameter
                                            prmOrgBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                            prmOrgBed(0).Value = 1
                                            prmOrgBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                            prmOrgBed(1).Value = orgBedId

                                            dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmOrgBed)

                                            Dim prmOrgRoom(0) As SqlParameter
                                            prmOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                            prmOrgRoom(0).Value = orgRoomId

                                            dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmOrgRoom)
                                        End If
                                    Else 'selected room was not changed, check if selected bed was also changed
                                        If orgBedId <> cmbBed.SelectedValue Then
                                            Dim lastRestAlarmId As Integer = 0
                                            Dim prmRdOrgBed(0) As SqlParameter
                                            prmRdOrgBed(0) = New SqlParameter("@BedId", SqlDbType.Int)
                                            prmRdOrgBed(0).Value = orgBedId

                                            lastRestAlarmId = dbHealth.ExecuteScalar("SELECT RestAlarmId FROM dbo.RestAlarm WHERE BedId = @BedId AND IsActive = 1 ORDER BY RestAlarmId DESC", CommandType.Text, prmRdOrgBed)

                                            If lastRestAlarmId = dtRestAlarm.Rows(0).Item("RestAlarmId") Then 'last rest alarm trx using the original bed, set original bed to vacant
                                                Dim prmOrgBed(1) As SqlParameter
                                                prmOrgBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                                prmOrgBed(0).Value = 1
                                                prmOrgBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                                prmOrgBed(1).Value = orgBedId

                                                dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmOrgBed)

                                                Dim prmOrgRoom(0) As SqlParameter
                                                prmOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                                prmOrgRoom(0).Value = orgRoomId

                                                dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmOrgRoom)
                                            End If
                                        End If
                                    End If

                                    Dim prmBed(1) As SqlParameter
                                    prmBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                    prmBed(0).Value = 1
                                    prmBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                    prmBed(1).Value = cmbBed.SelectedValue

                                    dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmBed)

                                    Dim prmRoom(0) As SqlParameter
                                    prmRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                    prmRoom(0).Value = cmbRoom.SelectedValue

                                    dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmRoom)
                                Else
                                    'no need to set an alarm
                                End If
                            End If

                        Else
                            'timeout specified is earlier later than to expected timeout, actual value of timeout will be the expected timeout
                            If expectedTimeOut > dbHealth.GetServerDate Then 'expected timeout is later than to current datetime, set an alarm
                                If dtRestAlarm.Rows.Count > 0 Then
                                    Dim prmAlarm(4) As SqlParameter
                                    prmAlarm(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                                    prmAlarm(0).Value = recordId
                                    prmAlarm(1) = New SqlParameter("@RoomId", SqlDbType.Int)
                                    prmAlarm(1).Value = cmbRoom.SelectedValue
                                    prmAlarm(2) = New SqlParameter("@BedId", SqlDbType.Int)
                                    prmAlarm(2).Value = cmbBed.SelectedValue
                                    prmAlarm(3) = New SqlParameter("@AlarmTime", SqlDbType.DateTime2)
                                    prmAlarm(3).Value = expectedTimeOut
                                    prmAlarm(4) = New SqlParameter("@IsActive", SqlDbType.Bit)
                                    prmAlarm(4).Value = 1

                                    dbHealth.ExecuteNonQuery("UpdRestAlarmByRecordId", CommandType.StoredProcedure, prmAlarm)

                                    'selected room was changed
                                    If orgRoomId <> cmbRoom.SelectedValue Then
                                        Dim activeRestAlarmId As Integer = 0
                                        Dim prmRdOrgRoom(0) As SqlParameter
                                        prmRdOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                        prmRdOrgRoom(0).Value = orgRoomId

                                        activeRestAlarmId = dbHealth.ExecuteScalar("SELECT RestAlarmId FROM dbo.RestAlarm WHERE RoomId = @RoomId AND IsActive = 1 ORDER BY RestAlarmId DESC", CommandType.Text, prmRdOrgRoom)

                                        If activeRestAlarmId = dtRestAlarm.Rows(0).Item("RestAlarmId") Then
                                            Dim prmOrgBed(1) As SqlParameter
                                            prmOrgBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                            prmOrgBed(0).Value = 1
                                            prmOrgBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                            prmOrgBed(1).Value = orgBedId

                                            dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmOrgBed)

                                            Dim prmOrgRoom(0) As SqlParameter
                                            prmOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                            prmOrgRoom(0).Value = orgRoomId

                                            dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmOrgRoom)
                                        End If
                                    Else 'selected room was not changed, check if selected bed was also changed
                                        If orgBedId <> cmbBed.SelectedValue Then
                                            Dim lastRestAlarmId As Integer = 0
                                            Dim prmRdOrgBed(0) As SqlParameter
                                            prmRdOrgBed(0) = New SqlParameter("@BedId", SqlDbType.Int)
                                            prmRdOrgBed(0).Value = orgBedId

                                            lastRestAlarmId = dbHealth.ExecuteScalar("SELECT RestAlarmId FROM dbo.RestAlarm WHERE BedId = @BedId AND IsActive = 1 ORDER BY RestAlarmId DESC", CommandType.Text, prmRdOrgBed)

                                            If lastRestAlarmId = dtRestAlarm.Rows(0).Item("RestAlarmId") Then 'last rest alarm trx using the original bed, set original bed to vacant
                                                Dim prmOrgBed(1) As SqlParameter
                                                prmOrgBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                                prmOrgBed(0).Value = 1
                                                prmOrgBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                                prmOrgBed(1).Value = orgBedId

                                                dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmOrgBed)

                                                Dim prmOrgRoom(0) As SqlParameter
                                                prmOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                                prmOrgRoom(0).Value = orgRoomId

                                                dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmOrgRoom)
                                            End If
                                        End If
                                    End If
                                Else
                                    Dim prmAlarm(4) As SqlParameter
                                    prmAlarm(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                                    prmAlarm(0).Value = prmMedicalRecord(0).Value
                                    prmAlarm(1) = New SqlParameter("@RoomId", SqlDbType.Int)
                                    prmAlarm(1).Value = cmbRoom.SelectedValue
                                    prmAlarm(2) = New SqlParameter("@BedId", SqlDbType.Int)
                                    prmAlarm(2).Value = cmbBed.SelectedValue
                                    prmAlarm(3) = New SqlParameter("@AlarmTime", SqlDbType.DateTime2)
                                    prmAlarm(3).Value = expectedTimeOut
                                    prmAlarm(4) = New SqlParameter("@IsActive", SqlDbType.Bit)
                                    prmAlarm(4).Value = 1

                                    dbHealth.ExecuteNonQuery("InsRestAlarm", CommandType.StoredProcedure, prmAlarm)
                                End If

                                Dim prmBed(1) As SqlParameter
                                prmBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                prmBed(0).Value = 0
                                prmBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                prmBed(1).Value = cmbBed.SelectedValue

                                dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmBed)

                                Dim prmRoom(0) As SqlParameter
                                prmRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                prmRoom(0).Value = cmbRoom.SelectedValue

                                dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmRoom)

                            Else
                                'expected timeout is earlier later than to current datetime, no need to set an alarm
                                If dtRestAlarm.Rows.Count > 0 Then
                                    Dim prmAlarm(4) As SqlParameter
                                    prmAlarm(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                                    prmAlarm(0).Value = recordId
                                    prmAlarm(1) = New SqlParameter("@RoomId", SqlDbType.Int)
                                    prmAlarm(1).Value = cmbRoom.SelectedValue
                                    prmAlarm(2) = New SqlParameter("@BedId", SqlDbType.Int)
                                    prmAlarm(2).Value = cmbBed.SelectedValue
                                    prmAlarm(3) = New SqlParameter("@AlarmTime", SqlDbType.DateTime2)
                                    prmAlarm(3).Value = expectedTimeOut
                                    prmAlarm(4) = New SqlParameter("@IsActive", SqlDbType.Bit)
                                    prmAlarm(4).Value = 0

                                    dbHealth.ExecuteNonQuery("UpdRestAlarmByRecordId", CommandType.StoredProcedure, prmAlarm)

                                    'selected room was changed
                                    If orgRoomId <> cmbRoom.SelectedValue Then
                                        Dim activeRestAlarmId As Integer = 0
                                        Dim prmRdOrgRoom(0) As SqlParameter
                                        prmRdOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                        prmRdOrgRoom(0).Value = orgRoomId

                                        activeRestAlarmId = dbHealth.ExecuteScalar("SELECT RestAlarmId FROM dbo.RestAlarm WHERE RoomId = @RoomId AND IsActive = 1 ORDER BY RestAlarmId DESC", CommandType.Text, prmRdOrgRoom)

                                        If activeRestAlarmId = dtRestAlarm.Rows(0).Item("RestAlarmId") Then
                                            Dim prmOrgBed(1) As SqlParameter
                                            prmOrgBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                            prmOrgBed(0).Value = 1
                                            prmOrgBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                            prmOrgBed(1).Value = orgBedId

                                            dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmOrgBed)

                                            Dim prmOrgRoom(0) As SqlParameter
                                            prmOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                            prmOrgRoom(0).Value = orgRoomId

                                            dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmOrgRoom)
                                        End If
                                    End If

                                    Dim prmBed(1) As SqlParameter
                                    prmBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                                    prmBed(0).Value = 1
                                    prmBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                                    prmBed(1).Value = cmbBed.SelectedValue

                                    dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmBed)

                                    Dim prmRoom(0) As SqlParameter
                                    prmRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                                    prmRoom(0).Value = cmbRoom.SelectedValue

                                    dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmRoom)
                                Else
                                    'no need to set alarm
                                End If
                            End If
                        End If
                    End If

                Else 'employee did not rest
                    If dtRestAlarm.Rows.Count > 0 Then
                        'selected room was changed
                        Dim activeRestAlarmId As Integer = 0
                        Dim prmRdOrgRoom(0) As SqlParameter
                        prmRdOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                        prmRdOrgRoom(0).Value = orgRoomId

                        activeRestAlarmId = dbHealth.ExecuteScalar("SELECT RestAlarmId FROM dbo.RestAlarm WHERE RoomId = @RoomId AND IsActive = 1 ORDER BY RestAlarmId DESC", CommandType.Text, prmRdOrgRoom)

                        If activeRestAlarmId = dtRestAlarm.Rows(0).Item("RestAlarmId") Then
                            Dim prmOrgBed(1) As SqlParameter
                            prmOrgBed(0) = New SqlParameter("@IsVacant", SqlDbType.Int)
                            prmOrgBed(0).Value = 1
                            prmOrgBed(1) = New SqlParameter("@BedId", SqlDbType.Int)
                            prmOrgBed(1).Value = orgBedId

                            dbHealth.ExecuteNonQuery("UpdBedIsVacant", CommandType.StoredProcedure, prmOrgBed)

                            Dim prmOrgRoom(0) As SqlParameter
                            prmOrgRoom(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                            prmOrgRoom(0).Value = orgRoomId

                            dbHealth.ExecuteNonQuery("UpdRoomIsFull", CommandType.StoredProcedure, prmOrgRoom)
                        End If

                        Dim prmDel(0) As SqlParameter
                        prmDel(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                        prmDel(0).Value = recordId

                        dbHealth.ExecuteNonQuery("DELETE FROM dbo.RestAlarm WHERE RecordId = @RecordId", CommandType.Text, prmDel)
                    End If
                End If

                'medicine trx header and trx detail
                If dgvDetail.Rows.Count > 0 Then
                    'medicine trx header
                    Dim headerCount As Integer = 0
                    Dim prmCntHeader(0) As SqlParameter
                    prmCntHeader(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                    prmCntHeader(0).Value = recordId

                    headerCount = dbHealth.ExecuteScalar("SELECT COUNT(TrxId) FROM dbo.MedicineTrxHeader WHERE RecordId = @RecordId", CommandType.Text, prmCntHeader)

                    If headerCount > 0 Then 'update the previous record of issuance
                        Dim prmMedicineTrxHeader(5) As SqlParameter
                        prmMedicineTrxHeader(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                        prmMedicineTrxHeader(0).Value = recordId
                        prmMedicineTrxHeader(1) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                        prmMedicineTrxHeader(1).Value = patientId
                        prmMedicineTrxHeader(2) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
                        prmMedicineTrxHeader(2).Value = txtEmployeeCode.Text.Trim
                        prmMedicineTrxHeader(3) = New SqlParameter("@IsAgency", SqlDbType.Bit)
                        prmMedicineTrxHeader(3).Value = IIf(patientId <> 0 AndAlso agencyId = 0, False, True)
                        prmMedicineTrxHeader(4) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                        prmMedicineTrxHeader(4).Value = doctorId
                        prmMedicineTrxHeader(5) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime2)
                        prmMedicineTrxHeader(5).Value = dbHealth.GetServerDate

                        dbHealth.ExecuteNonQuery("UpdMedicineTrxHeaderByRecordId", CommandType.StoredProcedure, prmMedicineTrxHeader)

                        'get the deleted rows from bsMedicineTexDetail by comparing it with MedicineTrxDetail table
                        Dim sbCount As New System.Text.StringBuilder("SELECT COUNT(TrxDetailId) FROM dbo.MedicineTrxDetail WHERE TrxId = @TrxId AND TrxDetailId NOT IN (")

                        Dim i As Integer = 0
                        For Each dataRowView As DataRowView In Me.bsMedicineTrxDetail
                            Dim row = dataRowView.Row

                            If i > 0 Then
                                sbCount.Append(",")
                            End If

                            If Not row.Item("TrxDetailId") Is DBNull.Value Then
                                sbCount.Append(row.Item("TrxDetailId"))
                                i += 1
                            End If

                        Next
                        sbCount.Append(")")

                        Dim prmCntDetail(0) As SqlParameter
                        prmCntDetail(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmCntDetail(0).Value = dtMedicineTrxHeader.Rows(0).Item("TrxId")

                        Dim detailCount As Integer = dbHealth.ExecuteScalar(sbCount.ToString, CommandType.Text, prmCntDetail)

                        If detailCount > 0 Then 'there is removed rows
                            Dim sbRead As New System.Text.StringBuilder("SELECT * FROM dbo.MedicineTrxDetail WHERE TrxId = @TrxId AND TrxDetailId NOT IN (")

                            Dim j As Integer = 0
                            For Each dataRowView As DataRowView In Me.bsMedicineTrxDetail
                                Dim row = dataRowView.Row

                                If j > 0 Then
                                    sbRead.Append(",")
                                End If

                                If Not row.Item("TrxDetailId") Is DBNull.Value Then
                                    sbRead.Append(row.Item("TrxDetailId"))
                                    j += 1
                                End If

                            Next
                            sbRead.Append(")")

                            Dim prmRdDetail(0) As SqlParameter
                            prmRdDetail(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                            prmRdDetail(0).Value = dtMedicineTrxHeader.Rows(0).Item("TrxId")

                            're-add the issued medicine quantity to current ending balance
                            Using rdr As IDataReader = dbHealth.ExecuteReader(sbRead.ToString, CommandType.Text, prmRdDetail)
                                While rdr.Read
                                    Dim prmAdj(2) As SqlParameter
                                    prmAdj(0) = New SqlParameter("@StockId", SqlDbType.Int)
                                    prmAdj(0).Value = rdr.Item("StockId")
                                    prmAdj(1) = New SqlParameter("@TrxTypeId", SqlDbType.Int)
                                    prmAdj(1).Value = 1
                                    prmAdj(2) = New SqlParameter("@Qty", SqlDbType.Int)
                                    prmAdj(2).Value = rdr.Item("Qty")

                                    dbHealth.ExecuteNonQuery("UpdMedicineStockByStockId", CommandType.StoredProcedure, prmAdj)
                                End While
                                rdr.Close()
                            End Using
                        End If

                        'get the newly added rows
                        'less the issued medicine quantity to current ending balance
                        For Each dataRowView As DataRowView In Me.bsMedicineTrxDetail
                            Dim row = dataRowView.Row

                            If row.Item("TrxId") Is DBNull.Value Then
                                Dim prmAdj(2) As SqlParameter
                                prmAdj(0) = New SqlParameter("@StockId", SqlDbType.Int)
                                prmAdj(0).Value = row.Item("StockId")
                                prmAdj(1) = New SqlParameter("@TrxTypeId", SqlDbType.Int)
                                prmAdj(1).Value = 2
                                prmAdj(2) = New SqlParameter("@Qty", SqlDbType.Int)
                                prmAdj(2).Value = row.Item("Qty")

                                dbHealth.ExecuteNonQuery("UpdMedicineStockByStockId", CommandType.StoredProcedure, prmAdj)
                            End If
                        Next

                        'send the updated values of bindingsource
                        For Each dataRowView As DataRowView In Me.bsMedicineTrxDetail
                            Dim row = dataRowView.Row
                            row.Item("TrxId") = dtMedicineTrxHeader.Rows(0).Item("TrxId")
                        Next
                        Me.bsMedicineTrxDetail.EndEdit()
                        Me.adpMedicineTrxDetail.Update(dtMedicineTrxDetail)

                    Else 'new record of issuance
                        Dim prmMedicalHeader(11) As SqlParameter
                        prmMedicalHeader(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmMedicalHeader(0).Direction = ParameterDirection.Output
                        prmMedicalHeader(1) = New SqlParameter("@CreatedBy", SqlDbType.Int)
                        prmMedicalHeader(1).Value = doctorId
                        prmMedicalHeader(2) = New SqlParameter("@CreatedDate", SqlDbType.DateTime2)
                        prmMedicalHeader(2).Value = dbHealth.GetServerDate
                        prmMedicalHeader(3) = New SqlParameter("@RecordId", SqlDbType.Int)
                        prmMedicalHeader(3).Value = recordId
                        prmMedicalHeader(4) = New SqlParameter("@TrxTypeId", SqlDbType.Int)
                        prmMedicalHeader(4).Value = 2
                        prmMedicalHeader(5) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                        prmMedicalHeader(5).Value = patientId
                        prmMedicalHeader(6) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
                        prmMedicalHeader(6).Value = txtEmployeeCode.Text.Trim

                        If patientId <> 0 AndAlso agencyId = 0 Then 'nbc
                            prmMedicalHeader(7) = New SqlParameter("@IsAgency", SqlDbType.Bit)
                            prmMedicalHeader(7).Value = False
                            prmMedicalHeader(8) = New SqlParameter("@AgencyId", SqlDbType.Int)
                            prmMedicalHeader(8).Value = Nothing
                        Else 'agency
                            prmMedicalHeader(7) = New SqlParameter("@IsAgency", SqlDbType.Bit)
                            prmMedicalHeader(7).Value = True
                            prmMedicalHeader(8) = New SqlParameter("@AgencyId", SqlDbType.Int)
                            prmMedicalHeader(8).Value = agencyId
                        End If

                        prmMedicalHeader(9) = New SqlParameter("@Remarks", SqlDbType.VarChar)
                        prmMedicalHeader(9).Value = Nothing
                        prmMedicalHeader(10) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                        prmMedicalHeader(10).Value = Nothing
                        prmMedicalHeader(11) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime2)
                        prmMedicalHeader(11).Value = Nothing

                        dbHealth.ExecuteNonQuery("InsMedicineTrxHeader", CommandType.StoredProcedure, prmMedicalHeader)

                        'get the newly added rows
                        'less the issued medicine quantity to current ending balance
                        For Each dataRowView As DataRowView In Me.bsMedicineTrxDetail
                            Dim row = dataRowView.Row

                            Dim prmAdj(2) As SqlParameter
                            prmAdj(0) = New SqlParameter("@StockId", SqlDbType.Int)
                            prmAdj(0).Value = row.Item("StockId")
                            prmAdj(1) = New SqlParameter("@TrxTypeId", SqlDbType.Int)
                            prmAdj(1).Value = 2
                            prmAdj(2) = New SqlParameter("@Qty", SqlDbType.Int)
                            prmAdj(2).Value = row.Item("Qty")

                            dbHealth.ExecuteNonQuery("UpdMedicineStockByStockId", CommandType.StoredProcedure, prmAdj)
                        Next

                        'send the updated values of bindingsource
                        For Each dataRowView As DataRowView In Me.bsMedicineTrxDetail
                            Dim row = dataRowView.Row
                            row.Item("TrxId") = prmMedicalHeader(0).Value
                        Next
                        Me.bsMedicineTrxDetail.EndEdit()
                        Me.adpMedicineTrxDetail.Update(dtMedicineTrxDetail)
                    End If

                Else 'did not issue medicine
                    Dim headerCount As Integer = 0
                    Dim prmCntHeader(0) As SqlParameter
                    prmCntHeader(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                    prmCntHeader(0).Value = recordId

                    headerCount = dbHealth.ExecuteScalar("SELECT COUNT(TrxId) FROM dbo.MedicineTrxHeader WHERE RecordId = @RecordId", CommandType.Text, prmCntHeader)

                    If headerCount > 0 Then
                        Dim detailCount As Integer = 0
                        Dim prmRdHeader(0) As SqlParameter
                        prmRdHeader(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                        prmRdHeader(0).Value = dtMedicineTrxHeader.Rows(0).Item("TrxId")

                        detailCount = dbHealth.ExecuteScalar("SELECT COUNT(TrxDetailId) FROM dbo.MedicineTrxDetail WHERE TrxId = @TrxId", CommandType.Text, prmRdHeader)

                        If detailCount > 0 Then 'extract the record to be deleted
                            Dim prmRdDetail(0) As SqlParameter
                            prmRdDetail(0) = New SqlParameter("@TrxId", SqlDbType.Int)
                            prmRdDetail(0).Value = dtMedicineTrxHeader.Rows(0).Item("TrxId")

                            're-add the issued medicine quantity to current ending balance
                            Using rdr As IDataReader = dbHealth.ExecuteReader("RdMedicineTrxDetailByTrxId", CommandType.StoredProcedure, prmRdDetail)
                                While rdr.Read
                                    Dim prmAdj(2) As SqlParameter
                                    prmAdj(0) = New SqlParameter("@StockId", SqlDbType.Int)
                                    prmAdj(0).Value = rdr.Item("StockId")
                                    prmAdj(1) = New SqlParameter("@TrxTypeId", SqlDbType.Int)
                                    prmAdj(1).Value = 1
                                    prmAdj(2) = New SqlParameter("@Qty", SqlDbType.Int)
                                    prmAdj(2).Value = rdr.Item("Qty")

                                    dbHealth.ExecuteNonQuery("UpdMedicineStockByStockId", CommandType.StoredProcedure, prmAdj)
                                End While
                                rdr.Close()
                            End Using
                        End If

                        'delete medicine trx header and detail
                        Dim prmMedicineTrxHeader(0) As SqlParameter
                        prmMedicineTrxHeader(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                        prmMedicineTrxHeader(0).Value = recordId

                        dbHealth.ExecuteNonQuery("DELETE FROM dbo.MedicineTrxHeader WHERE RecordId = @RecordId", CommandType.Text, prmMedicineTrxHeader)
                    End If
                End If

                If lstAttachmentForDelete.Count > 0 Then
                    For i As Integer = 0 To lstAttachmentForDelete.Count - 1
                        Dim ext As String = String.Empty
                        Dim newName As String = String.Empty
                        ext = Path.GetExtension(lstAttachmentForDelete(i).FileName).ToLower

                        If patientId <> 0 AndAlso agencyId = 0 Then 'nbc
                            newName = patientId & "-" & recordId & "-" & lstAttachmentForDelete(i).AttachmentId & ext
                        Else 'agency
                            newName = txtEmployeeCode.Text.ToString.ToLower & "-" & recordId & "-" & lstAttachmentForDelete(i).AttachmentId & ext
                        End If

                        File.Delete(medRecordDirectory & "\" & newName)
                        Dim prmDel(0) As SqlParameter
                        prmDel(0) = New SqlParameter("@AttachmentId", SqlDbType.Int)
                        prmDel(0).Value = lstAttachmentForDelete(i).AttachmentId

                        dbHealth.ExecuteNonQuery("DelEmployeeMedicalAttachemntByAttachmentId", CommandType.StoredProcedure, prmDel)
                    Next
                End If

                If lstAttachment.Count > 0 Then
                    For i As Integer = 0 To lstAttachment.Count - 1
                        If lstAttachment(i).AttachmentId = 0 Then
                            Dim prmAttachment(2) As SqlParameter
                            prmAttachment(0) = New SqlParameter("@AttachmentId", SqlDbType.Int)
                            prmAttachment(0).Direction = ParameterDirection.Output
                            prmAttachment(1) = New SqlParameter("@RecordId", SqlDbType.Int)
                            prmAttachment(1).Value = prmMedicalRecord(0).Value
                            prmAttachment(2) = New SqlParameter("@Filename", SqlDbType.NVarChar)
                            prmAttachment(2).Value = ""

                            dbHealth.ExecuteNonQuery("InsEmployeeMedicalAttachment", CommandType.StoredProcedure, prmAttachment)

                            Dim ext As String = String.Empty
                            Dim newName As String = String.Empty
                            ext = Path.GetExtension(lstAttachment(i).FileName).ToLower

                            If patientId <> 0 AndAlso agencyId = 0 Then 'nbc
                                newName = patientId & "-" & recordId & "-" & prmAttachment(0).Value & ext
                            Else 'agency
                                newName = txtEmployeeCode.Text.ToString.ToLower & "-" & recordId & "-" & prmAttachment(0).Value & ext
                            End If

                            Dim prmUpd(1) As SqlParameter
                            prmUpd(0) = New SqlParameter("@AttachmentId", SqlDbType.Int)
                            prmUpd(0).Value = prmAttachment(0).Value
                            prmUpd(1) = New SqlParameter("@Filename", SqlDbType.NVarChar)
                            prmUpd(1).Value = newName

                            dbHealth.ExecuteNonQuery("UpdEmployeeMedicalAttachmentByAttachmentId", CommandType.StoredProcedure, prmUpd)

                            pbAttachment.Visible = True
                            lblProgress.Visible = True

                            Dim copyAttachment As New clsAttachment(lstAttachment(i).FileName, newName, lstAttachment(i).FileName)
                            lstAttachmentForCopy.Add(copyAttachment)
                        End If
                    Next
                End If

                If patientId = 0 AndAlso txtEmployeeNameAgency.Visible = True Then
                    Dim countEmp As Integer = 0
                    Dim prmCnt(0) As SqlParameter
                    prmCnt(0) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
                    prmCnt(0).Value = txtEmployeeCode.Text.Trim

                    countEmp = dbHealth.ExecuteScalar("SELECT COUNT(EmployeeCode) FROM dbo.EmployeeAgency WHERE TRIM(EmployeeCode) = @EmployeeCode", CommandType.Text, prmCnt)

                    If countEmp > 0 Then
                        Dim prmInsAgency(5) As SqlParameter
                        prmInsAgency(0) = New SqlParameter("@EmployeeName", SqlDbType.VarChar)
                        prmInsAgency(0).Value = txtEmployeeNameAgency.Text.Trim
                        prmInsAgency(1) = New SqlParameter("@AgencyId", SqlDbType.Int)
                        prmInsAgency(1).Value = cmbAgency.SelectedValue
                        prmInsAgency(2) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                        prmInsAgency(2).Value = doctorId
                        prmInsAgency(3) = New SqlParameter("@ModifiedDate", SqlDbType.VarChar)
                        prmInsAgency(3).Value = dbHealth.GetServerDate
                        prmInsAgency(4) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
                        prmInsAgency(4).Value = txtEmployeeCode.Text.Trim
                        prmInsAgency(5) = New SqlParameter("@IsActive", SqlDbType.Bit)
                        prmInsAgency(5).Value = Nothing

                        dbHealth.ExecuteNonQuery("UpdEmployeeAgency", CommandType.StoredProcedure, prmInsAgency)
                    End If
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
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Try
            If lstAttachment.Count > 0 Then
                Process.Start(lstAttachment(currentIndex).FileName)
            Else
                'https://stackoverflow.com/questions/14866603/a-generic-error-occurred-in-gdi-when-attempting-to-use-image-save
                If Not picImage.Image Is Nothing Then
                    Dim bmp As Bitmap = New Bitmap(picImage.Image)
                    bmp.Save(imgTmp)
                    OpenImage(imgTmp, 30000) '30 seconds
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkRest_CheckedChanged(sender As Object, e As EventArgs) Handles chkRest.CheckedChanged
        If chkRest.Checked = True Then
            txtRestMinutes.Enabled = True
            cmbRoom.Enabled = True
            LoadRoom()
        Else
            txtRestMinutes.Enabled = False
            cmbRoom.Enabled = False
            cmbRoom.SelectedValue = 0
            cmbBed.SelectedValue = 0
        End If
    End Sub

    Private Sub chkRest_Click(sender As Object, e As EventArgs) Handles chkRest.Click
        Try
            If recordId = 0 Then
                If chkRest.Checked = True Then
                    If IsMaskedTextBoxEmpty(txtTimeOut) = True Then
                        Dim countVacant As Integer = 0
                        countVacant = dbHealth.ExecuteScalar("SELECT COUNT(RoomId) FROM dbo.Room WHERE IsFull = 0", CommandType.Text)

                        If countVacant = 0 Then
                            MessageBox.Show("No room and bed available.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            chkRest.Checked = False
                        End If
                    Else
                        'late encoding, show all room and bed
                    End If
                End If

            Else

            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbAgency_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbAgency.SelectedValueChanged
        Try
            LoadMedicineStock(0)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbAgency_Validating(sender As Object, e As CancelEventArgs) Handles cmbAgency.Validating
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbAgency.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbBed_Validating(sender As Object, e As CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbBed.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMedicine_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            Dim qtyActStock As Integer = 0
            Dim qtyMinStock As Integer = 0
            Dim unitCode As String = String.Empty

            If cmbMedicine.SelectedValue <> 0 Then 'selection made
                Dim prm(2) As SqlParameter
                prm(0) = New SqlParameter("@MedicineId", SqlDbType.Int)
                prm(0).Value = cmbMedicine.SelectedValue
                prm(1) = New SqlParameter("@IsAgency", SqlDbType.Bit)
                prm(1).Value = False
                prm(2) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prm(2).Value = True

                Using rdr As IDataReader = dbHealth.ExecuteReader("RdMedicineStock", CommandType.StoredProcedure, prm)
                    While rdr.Read
                        stockId = rdr.Item("StockId")
                        qtyActStock = rdr.Item("ActualStock").ToString
                        qtyMinStock = rdr.Item("MinStock").ToString
                        unitId = rdr.Item("UnitId")
                        unitCode = rdr.Item("UnitCode")
                    End While
                    rdr.Close()
                End Using

                txtStock.Text = qtyActStock
                txtUnitName.Text = unitCode

                If qtyActStock <= qtyMinStock Then
                    txtStock.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
                    txtStock.ForeColor = Color.Red
                Else
                    txtStock.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
                    txtStock.ForeColor = Color.Black
                End If

            Else 'no selection made
                stockId = 0
                unitId = 0
                txtStock.Text = ""
                txtUnitName.Text = ""
                txtStock.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
                txtStock.ForeColor = Color.Black
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMedicine_Validated(sender As Object, e As EventArgs) Handles cmbMedicine.Validated
        Try
            If cmbMedicine.SelectedValue = 0 Then
                cmbMedicine.SelectedValue = 0
                txtStock.Text = ""
                txtStock.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
                txtStock.ForeColor = Color.Black
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbRoom_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbRoom.SelectedValue = 0 Then
                cmbBed.Enabled = False
                cmbBed.SelectedValue = 0
            Else
                cmbBed.Enabled = True
                LoadBed(cmbRoom.SelectedValue)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbRoom_Validating(sender As Object, e As CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbRoom.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function CreateMedicineTrxDetail() As DataTable
        Dim dtMedicineTrxDetail As New DataTable
        Dim con As New SqlConnection(connection.MyConnection)

        Try
            If recordId = 0 Then
                Dim cmdSel As SqlCommand = con.CreateCommand
                cmdSel.CommandText = "RdMedicineTrxDetailByTrxId"
                cmdSel.CommandType = CommandType.StoredProcedure
                cmdSel.Parameters.AddWithValue("@TrxId", Nothing)
                adpMedicineTrxDetail.SelectCommand = cmdSel
            End If

            Dim cmdIns As SqlCommand = con.CreateCommand
            cmdIns.CommandText = "InsMedicineTrxDetail"
            cmdIns.CommandType = CommandType.StoredProcedure
            cmdIns.Parameters.Add("@TrxId", SqlDbType.Int, 0, "TrxId")
            cmdIns.Parameters.Add("@MedicineId", SqlDbType.Int, 0, "MedicineId")
            cmdIns.Parameters.Add("@Qty", SqlDbType.Int, 0, "Qty")
            cmdIns.Parameters.Add("@StockId", SqlDbType.Int, 0, "StockId")
            adpMedicineTrxDetail.InsertCommand = cmdIns

            Dim cmdUpd As SqlCommand = con.CreateCommand
            cmdUpd.CommandText = "UpdMedicineTrxDetailByTrxDetailId"
            cmdUpd.CommandType = CommandType.StoredProcedure
            cmdUpd.Parameters.Add("@TrxDetailId", SqlDbType.Int, 0, "TrxDetailId")
            cmdUpd.Parameters.Add("@MedicineId", SqlDbType.Int, 0, "MedicineId")
            cmdUpd.Parameters.Add("@Qty", SqlDbType.Int, 0, "Qty")
            cmdUpd.Parameters.Add("@StockId", SqlDbType.Int, 0, "StockId")
            adpMedicineTrxDetail.UpdateCommand = cmdUpd

            Dim cmdDel As SqlCommand = con.CreateCommand
            cmdDel.CommandText = "DelMedicineTrxDetailByTrxDetailId"
            cmdDel.CommandType = CommandType.StoredProcedure
            cmdDel.Parameters.Add("@TrxDetailId", SqlDbType.Int, 0, "TrxDetailId")
            adpMedicineTrxDetail.DeleteCommand = cmdDel

            Dim colTrxDetailId As DataColumn = New DataColumn("TrxDetailId")
            colTrxDetailId.DataType = System.Type.GetType("System.Int32")
            colTrxDetailId.AllowDBNull = True
            dtMedicineTrxDetail.Columns.Add(colTrxDetailId)

            Dim colTrxId As DataColumn = New DataColumn("TrxId")
            colTrxId.DataType = System.Type.GetType("System.Int32")
            colTrxId.AllowDBNull = True
            dtMedicineTrxDetail.Columns.Add(colTrxId)

            Dim colMedicineId As DataColumn = New DataColumn("MedicineId")
            colMedicineId.DataType = System.Type.GetType("System.Int32")
            dtMedicineTrxDetail.Columns.Add(colMedicineId)

            Dim colUnitId As DataColumn = New DataColumn("UnitId")
            colUnitId.DataType = System.Type.GetType("System.Int32")
            dtMedicineTrxDetail.Columns.Add(colUnitId)

            Dim colQty As New DataColumn("Qty")
            colQty.DataType = System.Type.GetType("System.Int32")
            dtMedicineTrxDetail.Columns.Add(colQty)

            Dim colStockId As DataColumn = New DataColumn("StockId")
            colStockId.DataType = System.Type.GetType("System.Int32")
            dtMedicineTrxDetail.Columns.Add(colStockId)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dtMedicineTrxDetail
    End Function

    Private Sub DeleteTempImg(ByVal sender As Object, ByVal e As System.EventArgs)
        If File.Exists(imgTmp) Then
            File.Delete(imgTmp)
        End If
    End Sub

    Private Sub dgvDetail_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvDetail.DataError
        e.Cancel = False
    End Sub

    Public Property fromMedLogs As Boolean = False

    Private Sub DisableForm(isDisable As Boolean)
        If isDisable = True Then
            txtTimeIn.Enabled = False
            btnManualOut.Enabled = False
            txtTimeOut.Enabled = False
            txtLmp.Enabled = False
            txtTemperature.Enabled = False
            txtBloodPressure.Enabled = False
            txtOxygenLevel.Enabled = False
            txtPulseRate.Enabled = False
            txtRespiratoryRate.Enabled = False
            chkFitToWork.Enabled = False
            chkSentHome.Enabled = False
            chkTeleconsult.Enabled = False
            chkRest.Enabled = False
            txtRestMinutes.Enabled = False
            cmbRoom.Enabled = False
            cmbBed.Enabled = False
            txtChiefComplaint.Enabled = False
            txtDiagnosis.Enabled = False
            txtPlan.Enabled = False
            txtHpi.Enabled = False
            cmbMedicine.Enabled = False
            txtQty.Enabled = False

            btnAddRow.Enabled = False
            btnRemoveRow.Enabled = False
            dgvDetail.Enabled = False

            pnlAttachment.Enabled = False

        Else
            txtTimeIn.Enabled = True
            btnManualOut.Enabled = True
            txtTimeOut.Enabled = True
            txtLmp.Enabled = True
            txtTemperature.Enabled = True
            txtBloodPressure.Enabled = True
            txtOxygenLevel.Enabled = True
            txtPulseRate.Enabled = True
            txtRespiratoryRate.Enabled = True
            chkFitToWork.Enabled = True
            chkSentHome.Enabled = True
            chkTeleconsult.Enabled = True
            chkRest.Enabled = True
            txtChiefComplaint.Enabled = True
            txtDiagnosis.Enabled = True
            txtPlan.Enabled = True
            txtHpi.Enabled = True
            cmbMedicine.Enabled = True
            txtQty.Enabled = True

            btnAddRow.Enabled = True
            btnRemoveRow.Enabled = True
            dgvDetail.Enabled = True

            pnlAttachment.Enabled = True
        End If
    End Sub

    Private Sub ConsultationDetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If recordId = 0 Then
                Me.Text = "New Record"
                btnDelete.Enabled = False

                GetEncoderInformation(doctorId)

                txtCreatedDate.Text = String.Format("{0:MMMM dd, yyyy  HH:mm}", dbHealth.GetServerDate)
                txtRestMinutes.Text = 30
                txtAttachmentName.Text = String.Empty
                chkFitToWork.Checked = True

                DisableForm(True)

                Me.ActiveControl = txtEmployeeCode

                If isDebug = True Then
                    txtEmployeeCode.Text = "2009-002"
                    txtEmployeeCode.Select(txtEmployeeCode.Text.Trim.Length, 0)
                End If

            Else
                Me.Text = "Record No. " & recordId
                btnDelete.Enabled = True

                'employee medical record
                For Each row As DataRow In dtEmployeeMedicalRecord.Rows
                    txtCreatedDate.Text = String.Format("{0:MM/dd/yyyy HH:mm}", row("CreatedDate"))

                    If row("ModifiedBy") Is DBNull.Value Then
                        GetEncoderInformation(doctorId)
                    Else
                        GetEncoderInformation(doctorId, row("ModifiedBy"))
                        txtModifiedDate.Text = String.Format("{0:MM/dd/yyyy HH:mm}", row("ModifiedDate"))
                    End If

                    GetEmployeeInformation(row("EmployeeCode"))

                    If Not row("LMP") Is DBNull.Value Then
                        txtLmp.Text = String.Format("{0:MM/dd/yyyy}", row("LMP"))
                    End If

                    If Not row("Temperature") Is DBNull.Value Then
                        txtTemperature.Text = row("Temperature")
                    End If

                    If Not row("BloodPressure") Is DBNull.Value Then
                        txtBloodPressure.Text = row("BloodPressure")
                    End If

                    If Not row("OxygenLevel") Is DBNull.Value Then
                        txtOxygenLevel.Text = row("OxygenLevel")
                    End If

                    If Not row("PulseRate") Is DBNull.Value Then
                        txtPulseRate.Text = row("PulseRate")
                    End If

                    If Not row("RespiratoryRate") Is DBNull.Value Then
                        txtRespiratoryRate.Text = row("RespiratoryRate")
                    End If

                    If Not row("ChiefComplaint") Is DBNull.Value Then
                        txtChiefComplaint.Text = row("ChiefComplaint")
                    End If

                    If Not row("Diagnosis") Is DBNull.Value Then
                        txtDiagnosis.Text = row("Diagnosis")
                    End If

                    If Not row("Plano") Is DBNull.Value Then
                        txtPlan.Text = row("Plano")
                    End If

                    If Not row("HPI") Is DBNull.Value Then
                        txtHpi.Text = row("HPI")
                    End If

                    If row("IsFitToWork") = True Then chkFitToWork.Checked = True Else chkFitToWork.Checked = False
                    If row("IsSentHome") = True Then chkSentHome.Checked = True Else chkSentHome.Checked = False
                    If row("IsTeleConsult") = True Then chkTeleconsult.Checked = True Else chkTeleconsult.Checked = False
                    If row("IsRest") = True Then chkRest.Checked = True Else chkRest.Checked = False

                    txtTimeIn.Text = String.Format("{0:MM/dd/yyyy HH:mm}", row("DatetimeStarted"))

                    If Not row("DatetimeEnded") Is DBNull.Value Then
                        txtTimeOut.Text = String.Format("{0:MM/dd/yyyy HH:mm}", row("DatetimeEnded"))
                    End If

                    txtRestMinutes.Text = row("TotalRestTime")
                Next

                'medicine trx header and detail
                If dtMedicineTrxHeader.Rows.Count > 0 Then
                    Me.bsMedicineTrxDetail.DataSource = dtMedicineTrxDetail
                    Me.bsMedicineTrxDetail.Position = dtMedicineTrxHeader.Rows(0).Item("TrxId")
                    Me.bsMedicineTrxDetail.Sort = "TrxDetailId"
                    dgvDetail.AutoGenerateColumns = False
                    dgvDetail.DataSource = Me.bsMedicineTrxDetail
                Else
                    Me.bsMedicineTrxDetail.DataSource = dtMedicineTrxDetail
                    Me.bsMedicineTrxDetail.Sort = "TrxDetailId"

                    dgvDetail.AutoGenerateColumns = False
                    dgvDetail.DataSource = Me.bsMedicineTrxDetail
                End If

                If chkRest.Checked = True Then
                    If dtRestAlarm.Rows.Count > 0 Then
                        orgRoomId = dtRestAlarm.Rows(0).Item("RoomId")
                        orgBedId = dtRestAlarm.Rows(0).Item("BedId")
                    End If

                    LoadRoom()
                    cmbRoom.SelectedValue = orgRoomId
                    LoadBed(orgRoomId)
                    cmbBed.SelectedValue = orgBedId
                Else
                    txtRestMinutes.Enabled = False
                    cmbRoom.Enabled = False
                    cmbBed.Enabled = False
                    cmbRoom.SelectedValue = 0
                    cmbBed.SelectedValue = 0
                End If

                'employee medical attachment
                Dim attachmentCount As Integer = 0
                Dim prmCnt(0) As SqlParameter
                prmCnt(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                prmCnt(0).Value = recordId

                attachmentCount = dbHealth.ExecuteScalar("CntEmployeeMedicalAttachmentByRecordId", CommandType.StoredProcedure, prmCnt)

                If attachmentCount > 0 Then
                    Dim prmAttachment(0) As SqlParameter
                    prmAttachment(0) = New SqlParameter("@RecordId", SqlDbType.Int)
                    prmAttachment(0).Value = recordId

                    dtEmployeeMedicalAttachment = dbHealth.FillDataTable("RdEmployeeMedicalAttachmentByRecordId", CommandType.StoredProcedure, prmAttachment)

                    For i As Integer = 0 To dtEmployeeMedicalAttachment.Rows.Count - 1
                        Dim oldAttachment As New clsAttachment(Path.Combine(medRecordDirectory, dtEmployeeMedicalAttachment.Rows(i).Item("Filename").ToString),
                                                               dtEmployeeMedicalAttachment.Rows(i).Item("Filename").ToString,
                                                               Path.GetExtension(Path.Combine(medRecordDirectory, dtEmployeeMedicalAttachment.Rows(i).Item("Filename").ToString)),
                                                               dtEmployeeMedicalAttachment.Rows(i).Item("AttachmentId"))
                        lstAttachment.Add(oldAttachment)
                        currentIndex = 0
                    Next
                    ShowAttachment()
                End If

                lblAttachmentCount.Text = String.Format("Attachment Qty : {0}", lstAttachment.Count)
                lblMedicineCount.Text = String.Format("Medicine Qty : {0}", Me.bsMedicineTrxDetail.Count)
            End If

            If fromMedLogs = True Then
                DisableForm(True)
                txtEmployeeCode.Enabled = False

                btnSave.Enabled = False
                btnDelete.Enabled = False
                btnCancel.Enabled = False

                Me.ActiveControl = btnClose
            End If

            If btnCancel.Enabled = True Then
                Me.CancelButton = btnCancel
            Else
                Me.CancelButton = btnClose
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmEmpRecordDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If fromMedLogs = False Then
            Select Case e.KeyCode
                Case Keys.F8
                    btnDelete.PerformClick()
                    e.Handled = True
                Case Keys.F10
                    e.Handled = True
                    btnSave.PerformClick()
            End Select
        End If
    End Sub
    Private Sub GetEmployeeInformation(employeeCode As String)
        Try
            Dim count1 As Integer = 0
            Dim prmCount1(0) As SqlParameter
            prmCount1(0) = New SqlParameter("@EmployeeCode", SqlDbType.VarChar)
            prmCount1(0).Value = employeeCode

            If recordId = 0 Then
                count1 = dbHealth.ExecuteScalar("SELECT COUNT(EmployeeId) FROM Employee WHERE EmployeeCode = @EmployeeCode AND IsActive = 1", CommandType.Text, prmCount1)
            Else
                count1 = dbHealth.ExecuteScalar("SELECT COUNT(EmployeeId) FROM Employee WHERE EmployeeCode = @EmployeeCode", CommandType.Text, prmCount1)
            End If

            txtDepartment.Text = ""
            txtSection.Text = ""
            txtPosition.Text = ""
            txtEmploymentStatus.Text = ""
            txtGender.Text = ""
            txtAge.Text = ""
            txtCivilStatus.Text = ""
            txtContactNumber.Text = ""
            txtLocalAddress.Text = ""
            txtBloodType.Text = ""
            txtAllergies.Text = ""
            txtEmgContactName.Text = ""
            txtEmgContactNumber.Text = ""
            txtEmgContactAddress.Text = ""

            LoadMedicineStock(0)

            If count1 > 0 Then 'direct
                Dim prmReader(0) As SqlParameter
                prmReader(0) = New SqlParameter("@EmployeeCode", SqlDbType.VarChar)
                prmReader(0).Value = employeeCode

                Using reader As IDataReader = dbHealth.ExecuteReader("RdEmployee", CommandType.StoredProcedure, prmReader)
                    While reader.Read
                        patientId = reader.Item("EmployeeId")
                        txtEmployeeCode.Text = reader.Item("EmployeeCode").ToString.Trim
                        txtEmployeeName.Text = StrConv(reader.Item("EmployeeName").ToString.Trim, VbStrConv.ProperCase)

                        If Not reader.Item("DepartmentId") Is DBNull.Value Then
                            txtDepartment.Text = StrConv(reader.Item("DepartmentName").ToString.Trim, vbProperCase)
                        End If

                        If Not reader.Item("TeamId") Is DBNull.Value Then
                            txtSection.Text = StrConv(reader.Item("TeamName").ToString.Trim, vbProperCase)
                        End If

                        If Not reader.Item("PositionId") Is DBNull.Value Then
                            txtPosition.Text = StrConv(reader.Item("PositionName").ToString.Trim, vbProperCase)
                        End If

                        If Not reader.Item("EmploymentTypeId") Is DBNull.Value Then
                            txtEmploymentStatus.Text = StrConv(reader.Item("EmploymentTypeName").ToString.Trim, vbProperCase)
                        End If

                        If Not reader.Item("GenderId") Is DBNull.Value Then
                            txtGender.Text = StrConv(reader.Item("GenderName").ToString.Trim, vbProperCase)
                        End If

                        If Not reader.Item("BirthDate") Is DBNull.Value Then
                            txtAge.Text = GetCurrentAge(reader.Item("BirthDate"))
                        End If

                        If Not reader.Item("MaritalStatusId") Is DBNull.Value Then
                            txtCivilStatus.Text = StrConv(reader.Item("MaritalStatusName").ToString.Trim, vbProperCase)
                        End If

                        If Not reader.Item("ContactNumber") Is DBNull.Value Then
                            txtPosition.Text = StrConv(reader.Item("ContactNumber").ToString.Trim, vbProperCase)
                        End If

                        If Not reader.Item("AddressLocal") Is DBNull.Value Then
                            txtLocalAddress.Text = StrConv(reader.Item("AddressLocal").ToString.Trim, vbProperCase)
                        End If

                        If Not reader.Item("BloodType") Is DBNull.Value Then
                            txtBloodType.Text = StrConv(reader.Item("BloodType").ToString.Trim, vbProperCase)
                        End If

                        If Not reader.Item("Allergies") Is DBNull.Value Then
                            txtAllergies.Text = StrConv(reader.Item("Allergies").ToString.Trim, vbProperCase)
                        End If

                        If Not reader.Item("EmergencyContactName") Is DBNull.Value Then
                            txtEmgContactName.Text = StrConv(reader.Item("EmergencyContactName").ToString.Trim, vbProperCase)
                        End If

                        If Not reader.Item("EmergencyContactNumber") Is DBNull.Value Then
                            txtEmgContactNumber.Text = StrConv(reader.Item("EmergencyContactNumber").ToString.Trim, vbProperCase)
                        End If

                        If Not reader.Item("EmergencyContactAddress") Is DBNull.Value Then
                            txtEmgContactAddress.Text = StrConv(reader.Item("EmergencyContactAddress").ToString.Trim, vbProperCase)
                        End If
                    End While
                End Using

                lblAgencyName.Visible = True
                lblAgencyName.Text = "NBC"
                agencyId = 0

                cmbAgency.Visible = False
                cmbAgency.DataSource = Nothing
                cmbAgency.Items.Clear()

                txtEmployeeNameAgency.Visible = False
                txtEmployeeNameAgency.Text = String.Empty
                txtEmployeeName.Visible = True

                DisableForm(False)
                Me.ActiveControl = txtLmp

                If recordId = 0 Then
                    txtTimeIn.Text = Format(dbHealth.GetServerDate, "MM/dd/yyyy HH:mm")
                    txtTimeOut.Text = Format(dbHealth.GetServerDate, "MM/dd/yyyy HH:mm")
                End If

            Else 'agency (fmb)
                If employeeCode.Substring(0, 3).ToUpper.Trim.Equals("FMB") Then
                    DisableForm(False)

                    Dim count2 As Integer = 0
                    Dim prmCount2(0) As SqlParameter
                    prmCount2(0) = New SqlParameter("@EmployeeCode", SqlDbType.VarChar)
                    prmCount2(0).Value = employeeCode

                    If recordId = 0 Then
                        count2 = dbHealth.ExecuteScalar("SELECT COUNT(EmployeeCode) FROM dbo.VwEmployeeAgency WHERE EmployeeCode = @EmployeeCode AND IsActive = 1", CommandType.Text, prmCount2)
                    Else
                        count2 = dbHealth.ExecuteScalar("SELECT COUNT(EmployeeCode) FROM dbo.VwEmployeeAgency WHERE EmployeeCode = @EmployeeCode", CommandType.Text, prmCount2)
                    End If

                    LoadAgency()
                    patientId = 0

                    If count2 = 0 Then 'not in the list
                        cmbAgency.Visible = True
                        lblAgencyName.Visible = False
                        lblAgencyName.Text = String.Empty

                        txtEmployeeName.Visible = False
                        txtEmployeeName.Text = String.Empty

                        txtEmployeeNameAgency.Visible = True
                        txtEmployeeNameAgency.Text = String.Empty

                        Me.ActiveControl = cmbAgency
                        cmbAgency.Select(cmbAgency.Text.ToString.Trim.Length, 0)

                    Else 'already in the list
                        If recordId = 0 Then
                            Dim prm(1) As SqlParameter
                            prm(0) = New SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50)
                            prm(0).Value = employeeCode
                            prm(1) = New SqlParameter("@IsActive", SqlDbType.Bit)
                            prm(1).Value = 1

                            Using rdr As IDataReader = dbHealth.ExecuteReader("RdEmployeeAgency", CommandType.StoredProcedure, prm)
                                While rdr.Read
                                    agencyId = rdr.Item("AgencyId")
                                    cmbAgency.SelectedValue = rdr.Item("AgencyId")
                                    lblAgencyName.Text = rdr.Item("AgencyName").ToString.Trim
                                    txtEmployeeCode.Text = rdr.Item("EmployeeCode").ToString.Trim
                                    txtEmployeeNameAgency.Text = rdr.Item("EmployeeName").ToString.Trim
                                End While
                                rdr.Close()
                            End Using

                        Else
                            Dim prm(0) As SqlParameter
                            prm(0) = New SqlParameter("@EmployeeCode", SqlDbType.VarChar, 50)
                            prm(0).Value = employeeCode

                            Using rdr As IDataReader = dbHealth.ExecuteReader("RdEmployeeAgency", CommandType.StoredProcedure, prm)
                                While rdr.Read
                                    agencyId = rdr.Item("AgencyId")
                                    cmbAgency.SelectedValue = rdr.Item("AgencyId")
                                    lblAgencyName.Text = rdr.Item("AgencyName").ToString.Trim
                                    txtEmployeeCode.Text = rdr.Item("EmployeeCode").ToString.Trim
                                    txtEmployeeNameAgency.Text = rdr.Item("EmployeeName").ToString.Trim
                                End While
                                rdr.Close()
                            End Using
                        End If

                        cmbAgency.Visible = True
                        lblAgencyName.Visible = False

                        txtEmployeeNameAgency.Visible = True
                        txtEmployeeName.Visible = False
                        txtEmployeeName.Text = String.Empty

                        Me.ActiveControl = txtEmployeeNameAgency
                        txtEmployeeNameAgency.Select(txtEmployeeNameAgency.Text.ToString.Trim.Length, 0)
                    End If

                    If recordId = 0 Then
                        txtTimeIn.Text = Format(dbHealth.GetServerDate, "MM/dd/yyyy HH:mm")
                        txtTimeOut.Text = Format(dbHealth.GetServerDate, "MM/dd/yyyy HH:mm")
                    End If
                Else
                    MessageBox.Show("Employee not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtEmployeeCode.Focus()
                    Return
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GetEncoderInformation(creator As Integer, Optional modifier As Integer = 0)
        Try
            Dim creatorName As String = String.Empty
            Dim prm1(0) As SqlParameter
            prm1(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            prm1(0).Value = creator

            creatorName = dbHealth.ExecuteScalar("SELECT TRIM(EmployeeName) AS EmployeeName FROM dbo.VwClinicAll WHERE EmployeeId = @EmployeeId", CommandType.Text, prm1)
            txtCreatedBy.Text = StrConv(creatorName, vbProperCase)

            If Not modifier = 0 Then
                Dim modifierName As String = String.Empty
                Dim prm2(0) As SqlParameter
                prm2(0) = New SqlParameter("@EmployeeId", SqlDbType.Int)
                prm2(0).Value = modifier

                modifierName = dbHealth.ExecuteScalar("SELECT TRIM(EmployeeName) AS EmployeeName FROM dbo.VwClinicAll WHERE EmployeeId = @EmployeeId", CommandType.Text, prm2)
                txtModifiedBy.Text = StrConv(modifierName, vbProperCase)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsMaskedTextBoxEmpty(mtb As MaskedTextBox) As Boolean
        Dim result As Boolean = False
        Dim cachedMaskFormat = mtb.TextMaskFormat

        Try
            mtb.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
            result = (mtb.Text = String.Empty)
            mtb.TextMaskFormat = cachedMaskFormat
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return result
    End Function
    Private Sub LoadAgency()
        Try
            cmbAgency.DisplayMember = "AgencyName"
            cmbAgency.ValueMember = "AgencyId"

            cmbAgency.DataSource = Nothing
            cmbAgency.Items.Clear()

            If recordId = 0 Then
                Dim prm(0) As SqlParameter
                prm(0) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prm(0).Value = True

                dbHealth.FillCmb("RdAgency", CommandType.StoredProcedure, "AgencyId", "AgencyName", cmbAgency, prm)
            Else
                dbHealth.FillCmb("RdAgency", CommandType.StoredProcedure, "AgencyId", "AgencyName", cmbAgency)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadBed(roomId As Integer)
        Try
            cmbBed.DisplayMember = "BedNo"
            cmbBed.ValueMember = "BedId"

            cmbBed.DataSource = Nothing
            cmbBed.Items.Clear()

            If recordId = 0 Then
                Dim prm(2) As SqlParameter
                prm(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                prm(0).Value = roomId
                prm(1) = New SqlParameter("@IsVacant", SqlDbType.Bit)
                prm(1).Value = True
                prm(2) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prm(2).Value = True

                dbHealth.FillCmbWithCaption("RdBed", CommandType.StoredProcedure, "BedId", "BedNo", cmbBed, "< Select Bed No >", prm)
            Else
                If dtRestAlarm.Rows.Count > 0 Then
                    If orgRoomId = cmbRoom.SelectedValue Then
                        Dim prm(3) As SqlParameter
                        prm(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                        prm(0).Value = roomId
                        prm(1) = New SqlParameter("@IsVacant", SqlDbType.Bit)
                        prm(1).Value = True
                        prm(2) = New SqlParameter("@IsActive", SqlDbType.Bit)
                        prm(2).Value = True
                        prm(3) = New SqlParameter("@Additional", SqlDbType.NVarChar)
                        prm(3).Value = String.Format(" OR A.BedId = {0}", orgBedId)

                        dbHealth.FillCmbWithCaption("RdBed", CommandType.StoredProcedure, "BedId", "BedNo", cmbBed, "< Select Bed No >", prm)
                    Else
                        Dim prm(2) As SqlParameter
                        prm(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                        prm(0).Value = roomId
                        prm(1) = New SqlParameter("@IsVacant", SqlDbType.Bit)
                        prm(1).Value = True
                        prm(2) = New SqlParameter("@IsActive", SqlDbType.Bit)
                        prm(2).Value = True

                        dbHealth.FillCmbWithCaption("RdBed", CommandType.StoredProcedure, "BedId", "BedNo", cmbBed, "< Select Bed No >", prm)
                    End If

                Else
                    Dim prm(2) As SqlParameter
                    prm(0) = New SqlParameter("@RoomId", SqlDbType.Int)
                    prm(0).Value = roomId
                    prm(1) = New SqlParameter("@IsVacant", SqlDbType.Bit)
                    prm(1).Value = True
                    prm(2) = New SqlParameter("@IsActive", SqlDbType.Bit)
                    prm(2).Value = True

                    dbHealth.FillCmbWithCaption("RdBed", CommandType.StoredProcedure, "BedId", "BedNo", cmbBed, "< Select Bed No >", prm)
                End If
            End If

            AddHandler cmbBed.Validating, AddressOf cmbBed_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMedicineStock(agencyId As Integer)
        Try
            cmbMedicine.DisplayMember = "MedicineName"
            cmbMedicine.ValueMember = "MedicineId"

            cmbMedicine.DataSource = Nothing
            cmbMedicine.Items.Clear()

            Dim prm(1) As SqlParameter
            prm(0) = New SqlParameter("@IsAgency", SqlDbType.Bit)
            prm(0).Value = False
            prm(1) = New SqlParameter("@IsActive", SqlDbType.Bit)
            prm(1).Value = True

            dbHealth.FillCmbWithCaption("SELECT A.MedicineId, TRIM(MedicineName) AS MedicineName " &
                                        "FROM dbo.MedicineStock A INNER JOIN dbo.Medicine B " &
                                        "On A.MedicineId = B.MedicineId " &
                                        "WHERE A.IsAgency = @IsAgency AND A.IsActive = @IsActive AND A.ActualStock > 0",
                                        CommandType.Text, "MedicineId", "MedicineName", cmbMedicine, "", prm)

            AddHandler cmbMedicine.SelectedValueChanged, AddressOf cmbMedicine_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadRoom()
        Try
            cmbRoom.DisplayMember = "RoomName"
            cmbRoom.ValueMember = "RoomId"

            cmbRoom.DataSource = Nothing
            cmbRoom.Items.Clear()

            If recordId = 0 Then
                Dim prm(1) As SqlParameter
                prm(0) = New SqlParameter("@IsFull", SqlDbType.Bit)
                prm(0).Value = False
                prm(1) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prm(1).Value = True

                dbHealth.FillCmbWithCaption("RdRoom", CommandType.StoredProcedure, "RoomId", "RoomName", cmbRoom, "< Select Room >", prm)
            Else
                If dtRestAlarm.Rows.Count > 0 Then
                    Dim prm(2) As SqlParameter
                    prm(0) = New SqlParameter("@IsFull", SqlDbType.Bit)
                    prm(0).Value = False
                    prm(1) = New SqlParameter("@IsActive", SqlDbType.Bit)
                    prm(1).Value = True
                    prm(2) = New SqlParameter("@Additional", SqlDbType.NVarChar)
                    prm(2).Value = String.Format(" OR A.RoomId = {0}", orgRoomId)

                    dbHealth.FillCmbWithCaption("RdRoom", CommandType.StoredProcedure, "RoomId", "RoomName", cmbRoom, "< Select Room >", prm)
                Else
                    Dim prm(1) As SqlParameter
                    prm(0) = New SqlParameter("@IsFull", SqlDbType.Bit)
                    prm(0).Value = False
                    prm(1) = New SqlParameter("@IsActive", SqlDbType.Bit)
                    prm(1).Value = True

                    dbHealth.FillCmbWithCaption("RdRoom", CommandType.StoredProcedure, "RoomId", "RoomName", cmbRoom, "< Select Room >", prm)
                End If
            End If

            AddHandler cmbRoom.Validating, AddressOf cmbRoom_Validating
            AddHandler cmbRoom.SelectedValueChanged, AddressOf cmbRoom_SelectedValueChanged
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LogOut()
        Try
            txtTimeOut.Text = Format(dbHealth.GetServerDate, "MM/dd/yyyy HH:mm")
            If chkRest.Checked = True Then

            Else

            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NextImage(val As Integer)
        Try
            If lstAttachment.Count < 1 Then
                picImage.Image = Nothing
                txtAttachmentName.Text = String.Empty
                AxAcroPDF.Visible = False
                AxAcroPDF.LoadFile("Empty")
                picImage.Visible = True
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

    Private Sub ofdRecDetail_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ofdRecDetail.FileOk
        Try
            For i As Integer = 0 To ofdRecDetail.FileNames.Length - 1
                Dim newAttachment As New clsAttachment(ofdRecDetail.FileNames(i), ofdRecDetail.SafeFileNames(i), Path.GetExtension(ofdRecDetail.SafeFileNames(i)).ToLower)
                lstAttachment.Add(newAttachment)
                currentIndex = lstAttachment.Count - 1
            Next
            ShowAttachment()

            ofdRecDetail.InitialDirectory = Path.GetDirectoryName(lstAttachment(currentIndex).FileName)
            lblAttachmentCount.Text = String.Format("Attachment Qty : {0}", lstAttachment.Count)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ShowAttachment()
        Try
            If lstImageFiles.Contains(lstAttachment(currentIndex).ExtensionName.ToString.Trim.ToLower) Then
                picImage.Visible = True
                AxAcroPDF.Visible = False

                Using img As Image = Image.FromFile(lstAttachment(currentIndex).FileName)
                    picImage.Image = New Bitmap(img)
                End Using

            ElseIf lstDocumentFiles.Contains(lstAttachment(currentIndex).ExtensionName.ToString.Trim.ToLower) Then
                picImage.Visible = True
                AxAcroPDF.Visible = False

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
                AxAcroPDF.Visible = True
                AxAcroPDF.src = lstAttachment(currentIndex).FileName + "#toolbar=0&scrollbar=0&navpanes=0"
                AxAcroPDF.setShowToolbar(False)
                AxAcroPDF.setShowScrollbars(False)
                AxAcroPDF.setView("Fit")
                AxAcroPDF.setLayoutMode("SinglePage")

            Else
                picImage.Visible = True
                AxAcroPDF.Visible = False
                picImage.Image = My.Resources.file_type_unknown_512px
            End If

            txtAttachmentName.Text = lstAttachment(currentIndex).SafeName
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ShowProgress(ByVal text As String, ByVal lbl As Label)
        If lbl.InvokeRequired Then
            lbl.Invoke(New SetProgressInvoker(AddressOf ShowProgress), text, lbl)
        Else
            lbl.Text = text
        End If
    End Sub

    Private Sub txtEmployeeCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmployeeCode.KeyDown
        Try
            If e.KeyCode.Equals(Keys.Enter) Then
                e.Handled = True
                If String.IsNullOrEmpty(txtEmployeeCode.Text.Trim) Then
                    Me.ActiveControl = txtEmployeeCode
                    MessageBox.Show("Please enter employee ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                arrSplitted = Split(txtEmployeeCode.Text.Trim, " ", 2)
                GetEmployeeInformation(arrSplitted(0).ToString)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtEmployeeCode_Validated(sender As Object, e As EventArgs) Handles txtEmployeeCode.Validated
        Try
            If String.IsNullOrEmpty(txtEmployeeCode.Text.Trim) Then
                Me.ActiveControl = txtEmployeeCode
                MessageBox.Show("Please enter employee ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            arrSplitted = Split(txtEmployeeCode.Text.Trim, " ", 2)
            GetEmployeeInformation(arrSplitted(0).ToString)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtLmp_TypeValidationCompleted(sender As Object, e As TypeValidationEventArgs) Handles txtLmp.TypeValidationCompleted
        Try
            If txtLmp.MaskCompleted = True Then
                If (Not e.IsValidInput) Then
                    SendKeys.Send("{End}")
                    MessageBox.Show("Please input date in MM/DD/YYYY format.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.Cancel = True
                End If
            Else
                txtLmp.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtPlan_TextChanged(sender As Object, e As EventArgs) Handles txtPlan.TextChanged

    End Sub

    Private Sub txtRestMinutes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRestMinutes.KeyPress, txtQty.KeyPress
        Try
            If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub createdDate_Format(sender As Object, e As ConvertEventArgs) Handles createdDate.Format
    '    If Not e.Value Is DBNull.Value Then
    '        e.Value = Format(e.Value, "MMMM dd, yyyy hh:mm:ss tt")
    '    Else
    '        e.Value = dbHealth.GetServerDate.ToString("MMMM dd, yyyy hh:mm:ss tt")
    '    End If
    'End Sub
    Private Sub txtTimeIn_TypeValidationCompleted(sender As Object, e As TypeValidationEventArgs) Handles txtTimeIn.TypeValidationCompleted
        Try
            If txtTimeIn.MaskCompleted = True Then
                If (Not e.IsValidInput) Then
                    SendKeys.Send("{End}")
                    MessageBox.Show("Please input datetime in MM/DD/YYYY HH:mm format.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.Cancel = True
                End If
            Else
                txtTimeIn.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtTimeOut_TypeValidationCompleted(sender As Object, e As TypeValidationEventArgs) Handles txtTimeOut.TypeValidationCompleted
        Try
            If txtTimeOut.MaskCompleted = True Then
                If (Not e.IsValidInput) Then
                    SendKeys.Send("{End}")
                    MessageBox.Show("Please input datetime in MM/DD/YYYY HH:mm format.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    e.Cancel = True
                End If
            Else
                txtTimeOut.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
