Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports BlackCoffeeLibrary

Public Class MedicineReceive
    Private bsTrxDetail As New BindingSource
    Private dtTrxHeader As New DataTable
    Private dtTrxDetail As New DataTable
    Private adpTrxDetail As New SqlDataAdapter
    Private bite As Byte()
    Private bsMedicine As New BindingSource
    Private dbConnection As New clsConnection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(dbConnection.MyConnection)
    Private dicPartSelection As New Dictionary(Of String, Integer)
    Private dtMedicine As New DataTable
    Private isActive As Boolean = False
    Private mStream As New MemoryStream
    Private trxId As Integer = 0
    Private userId As Integer = 0
    Private stockId As Integer = 0
    'the word `byte` is not a valid identifier
    Public Sub New(Optional _userId As Integer = 0, Optional _trxId As Integer = 0)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userId = _userId
        trxId = _trxId

        dbMain.EnableDoubleBuffered(dgvTrxDetail)

        dbMethod.FillCmbWithCaption("RdClinicNbc", CommandType.StoredProcedure, "EmployeeId", "EmployeeName", cmbReceiver, "")

        If trxId = 0 Then
            dtTrxDetail = CreateTrxMedicineDetail()

            Me.bsTrxDetail.DataSource = dtTrxDetail
            dgvTrxDetail.AutoGenerateColumns = False
            dgvTrxDetail.DataSource = Me.bsTrxDetail

            cmbReceiver.SelectedValue = userId
            ActiveControl = cmbMedicine

        Else
            Dim prmHeader(0) As SqlParameter
            prmHeader(0) = New SqlParameter("TrxId", SqlDbType.Int)
            prmHeader(0).Value = trxId

            dtTrxHeader = dbMethod.FillDataTable("RdMedicineTrxHeaderByTrxId", CommandType.StoredProcedure, prmHeader)

            Dim prmDetail(0) As SqlParameter
            prmDetail(0) = New SqlParameter("TrxId", SqlDbType.Int)
            prmDetail(0).Value = trxId

            dtTrxDetail = dbMethod.FillDataTable("RdMedicineTrxDetailByTrxId", CommandType.StoredProcedure, prmDetail)

            Me.Text = "Transaction No. " & trxId

            For Each row As DataRow In dtTrxHeader.Rows
                dtpDateReceived.Value = row("CreatedDate")
                cmbReceiver.SelectedValue = row("CreatedBy")

                If Not row("Remarks") Is DBNull.Value Then
                    txtRemarks.Text = row("Remarks").ToString.Trim
                End If
            Next

            Me.ActiveControl = btnClose
        End If

        Dim prm(0) As SqlParameter
        prm(0) = New SqlParameter("@IsActive", SqlDbType.Bit)
        prm(0).Value = True

        dtMedicine = dbMethod.FillDataTable("SELECT MedicineId, TRIM(MedicineName) AS MedicineName FROM dbo.Medicine WHERE IsActive = @IsActive", CommandType.Text, prm)

        Me.bsMedicine.DataSource = dtMedicine

        'transaction part detail table
        Dim colMedicineName As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        colMedicineName.Name = "ColMedicineName"
        colMedicineName.DataPropertyName = "MedicineId"
        colMedicineName.HeaderText = "Medicine"
        colMedicineName.DataSource = Me.bsMedicine
        colMedicineName.ValueMember = "MedicineId"
        colMedicineName.DisplayMember = "MedicineName"
        colMedicineName.Width = 415
        colMedicineName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colMedicineName.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        colMedicineName.SortMode = DataGridViewColumnSortMode.Automatic
        dgvTrxDetail.Columns.Insert(2, colMedicineName)

        AddHandler cmbReceiver.Validating, AddressOf cmbTechnician_Validating
        AddHandler cmbReceiver.Validated, AddressOf cmbTechnician_Validated
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If cmbMedicine.SelectedValue = 0 Then
                MessageBox.Show("Please select an item.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbMedicine.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtQty.Text) OrElse CInt(txtQty.Text.Trim) = 0 Then
                MessageBox.Show("Please input quantity to receive.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtQty.Focus()
                Exit Sub
            End If

            Dim cnt As Integer = 0
            For Each row As DataGridViewRow In dgvTrxDetail.Rows
                If row.Cells("ColMedicineId").Value = cmbMedicine.SelectedValue Then
                    cnt += 1
                End If
            Next

            If cnt > 0 Then
                MessageBox.Show("The selected item is already on the list.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbMedicine.Focus()
                Exit Sub
            End If

            Me.bsTrxDetail.AddNew()
            Me.bsTrxDetail.MoveLast()
            Me.bsTrxDetail.Current("TrxId") = DBNull.Value
            Me.bsTrxDetail.Current("MedicineId") = cmbMedicine.SelectedValue
            Me.bsTrxDetail.Current("Qty") = txtQty.Text.Trim
            Me.bsTrxDetail.Current("StockId") = stockId
            Me.bsTrxDetail.EndEdit()

            cmbMedicine.SelectedValue = 0
            stockId = 0
            txtCurrentStock.Text = ""
            txtOrderingPoint.Text = ""
            txtUnit.Text = ""
            txtQty.Clear()

            Me.ActiveControl = cmbReceiver
            Me.ActiveControl = cmbMedicine
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            Me.DialogResult = DialogResult.Cancel
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try
            If dgvTrxDetail.Rows.Count > 0 Then
                Dim question As String = "Are you sure you want to remove this item?"

                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim currentRow = CType(Me.bsTrxDetail.Current, DataRowView).Row
                    Dim rowState = currentRow.RowState

                    Select Case rowState
                        Case DataRowState.Added
                            Me.bsTrxDetail.RemoveCurrent()

                        Case DataRowState.Detached
                            Me.bsTrxDetail.CancelEdit()

                        Case DataRowState.Modified, DataRowState.Unchanged
                            If dgvTrxDetail.SelectedCells.Count > 0 AndAlso dgvTrxDetail.SelectedCells(0).RowIndex = dgvTrxDetail.NewRowIndex Then
                                Me.bsTrxDetail.CancelEdit()
                                Exit Sub
                            End If

                            Me.bsTrxDetail.RemoveCurrent()

                        Case Else
                            Me.bsTrxDetail.RemoveCurrent()
                    End Select
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If btnSave.Enabled = False Then
                Exit Sub
            End If

            If cmbReceiver.SelectedValue = 0 Then
                MessageBox.Show("Please select receiver of items.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbReceiver.Focus()
                Exit Sub
            End If

            If dgvTrxDetail.Rows.Count = 0 Then
                MessageBox.Show("Please select items to receive.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbMedicine.Focus()
                Exit Sub
            End If

            Dim prmMedicalHeader(11) As SqlParameter
            prmMedicalHeader(0) = New SqlParameter("@TrxId", SqlDbType.Int)
            prmMedicalHeader(0).Direction = ParameterDirection.Output
            prmMedicalHeader(1) = New SqlParameter("@CreatedBy", SqlDbType.Int)
            prmMedicalHeader(1).Value = userId
            prmMedicalHeader(2) = New SqlParameter("@CreatedDate", SqlDbType.DateTime2)
            prmMedicalHeader(2).Value = dbMethod.GetServerDate
            prmMedicalHeader(3) = New SqlParameter("@RecordId", SqlDbType.Int)
            prmMedicalHeader(3).Value = Nothing
            prmMedicalHeader(4) = New SqlParameter("@TrxTypeId", SqlDbType.Int)
            prmMedicalHeader(4).Value = 1 'rec
            prmMedicalHeader(5) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            prmMedicalHeader(5).Value = Nothing
            prmMedicalHeader(6) = New SqlParameter("@EmployeeCode", SqlDbType.NVarChar)
            prmMedicalHeader(6).Value = Nothing
            prmMedicalHeader(7) = New SqlParameter("@IsAgency", SqlDbType.Bit)
            prmMedicalHeader(7).Value = False
            prmMedicalHeader(8) = New SqlParameter("@AgencyId", SqlDbType.Int)
            prmMedicalHeader(8).Value = Nothing
            prmMedicalHeader(9) = New SqlParameter("@Remarks", SqlDbType.VarChar)
            prmMedicalHeader(9).Value = IIf(String.IsNullOrWhiteSpace(txtRemarks.Text.Trim), Nothing, txtRemarks.Text.Trim)
            prmMedicalHeader(10) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
            prmMedicalHeader(10).Value = Nothing
            prmMedicalHeader(11) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime2)
            prmMedicalHeader(11).Value = Nothing

            dbMethod.ExecuteNonQuery("InsMedicineTrxHeader", CommandType.StoredProcedure, prmMedicalHeader)

            For Each dataRowView As DataRowView In Me.bsTrxDetail
                Dim row = dataRowView.Row
                row.Item("TrxId") = prmMedicalHeader(0).Value

                Dim prmAdj(2) As SqlParameter
                prmAdj(0) = New SqlParameter("@StockId", SqlDbType.Int)
                prmAdj(0).Value = row.Item("StockId")
                prmAdj(1) = New SqlParameter("@TrxTypeId", SqlDbType.Int)
                prmAdj(1).Value = 1
                prmAdj(2) = New SqlParameter("@Qty", SqlDbType.Int)
                prmAdj(2).Value = row.Item("Qty")

                dbMethod.ExecuteNonQuery("UpdMedicineStockByStockId", CommandType.StoredProcedure, prmAdj)
            Next
            bsTrxDetail.EndEdit()
            adpTrxDetail.Update(dtTrxDetail)

            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbTechnician_Enter(sender As Object, e As EventArgs) Handles cmbReceiver.Enter
        lblReceiver.ForeColor = Color.White
        lblReceiver.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub cmbTechnician_Leave(sender As Object, e As EventArgs) Handles cmbReceiver.Leave
        lblReceiver.ForeColor = Color.Black
        lblReceiver.BackColor = SystemColors.Control
    End Sub

    Private Sub cmbTechnician_Validated(sender As Object, e As EventArgs)
        Try
            If cmbReceiver.SelectedValue = 0 Then
                cmbReceiver.SelectedValue = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbTechnician_Validating(sender As Object, e As CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 AndAlso String.IsNullOrEmpty(cmbReceiver.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CreateTrxMedicineDetail() As DataTable
        Dim dtMntTrxPartDetail As New DataTable
        Dim con As New SqlConnection(dbConnection.MyConnection)

        Try
            Dim query As String = String.Empty

            query = "SELECT TrxDetailId, TrxId, MedicineId, Qty, StockId FROM dbo.MedicineTrxDetail"

            Dim cmd As New SqlCommand(query, con)
            adpTrxDetail = New SqlDataAdapter(cmd)
            Dim cbTrxDetail As New SqlCommandBuilder(adpTrxDetail)

            Dim colTrxDetailId As DataColumn = New DataColumn("TrxDetailId")
            colTrxDetailId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colTrxDetailId)

            Dim colTrxId As DataColumn = New DataColumn("TrxId")
            colTrxId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colTrxId)

            Dim colMedicineId As DataColumn = New DataColumn("MedicineId")
            colMedicineId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colMedicineId)

            Dim colQty As DataColumn = New DataColumn("Qty")
            colQty.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colQty)

            Dim colStockId As DataColumn = New DataColumn("StockId")
            colStockId.DataType = System.Type.GetType("System.Int32")
            dtMntTrxPartDetail.Columns.Add(colStockId)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dtMntTrxPartDetail
    End Function

    Private Sub dgvPartDetail_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvTrxDetail.DataError
        e.Cancel = False
    End Sub

    Private Sub MntTrxActvityLog_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub MedicineReceive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If trxId = 0 Then
            Dim prmRd(0) As SqlParameter
            prmRd(0) = New SqlParameter("@IsActive", SqlDbType.Bit)
            prmRd(0).Value = True

            dbMethod.FillCmbWithCaption("RdMedicineStock", CommandType.StoredProcedure, "MedicineId", "MedicineName", cmbMedicine, "", prmRd)

            AddHandler cmbMedicine.Validated, AddressOf cmbMedicine_Validated
            AddHandler cmbMedicine.SelectedValueChanged, AddressOf cmbMedicine_SelectedValueChanged
            AddHandler cmbMedicine.Validating, AddressOf cmbMedicine_Validating

        Else
            dtpDateReceived.Enabled = False
            cmbReceiver.Enabled = False
            cmbMedicine.Enabled = False
            txtQty.Enabled = False
            txtRemarks.Enabled = False
            btnAdd.Enabled = False
            btnRemove.Enabled = False
            dgvTrxDetail.Enabled = False
            btnDelete.Enabled = False
            btnCancel.Enabled = False
            btnSave.Enabled = False
        End If

        Me.bsTrxDetail.DataSource = dtTrxDetail
        dgvTrxDetail.AutoGenerateColumns = False
        dgvTrxDetail.DataSource = Me.bsTrxDetail

        If trxId <> 0 Then
            dgvTrxDetail.ClearSelection()
        End If

        Me.dgvTrxDetail.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
        Try
            If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MntTrxPartReceive_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            If trxId <> 0 Then
                cmbReceiver.SelectionLength = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMedicine_Validated(sender As Object, e As EventArgs)
        Try
            If cmbMedicine.SelectedValue = 0 Then
                txtCurrentStock.Text = ""
                txtCurrentStock.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
                txtCurrentStock.ForeColor = Color.Black

                txtOrderingPoint.Text = ""
                txtUnit.Text = ""
                txtQty.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMedicine_Validating(sender As Object, e As CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbMedicine_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            If cmbMedicine.SelectedValue <> 0 Then
                Dim prm(1) As SqlParameter
                prm(0) = New SqlParameter("@MedicineId", SqlDbType.Int)
                prm(0).Value = cmbMedicine.SelectedValue
                prm(1) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prm(1).Value = True

                Using rdr As IDataReader = dbMethod.ExecuteReader("RdMedicineStock", CommandType.StoredProcedure, prm)
                    While rdr.Read
                        stockId = rdr.Item("StockId")
                        txtCurrentStock.Text = rdr.Item("ActualStock").ToString
                        txtOrderingPoint.Text = rdr.Item("OrderingPoint").ToString
                        txtUnit.Text = rdr.Item("UnitCode").ToString
                    End While
                    rdr.Close()
                End Using

                If CInt(txtCurrentStock.Text) <= CInt(txtOrderingPoint.Text) Then
                    txtCurrentStock.ForeColor = Color.Red
                Else
                    txtCurrentStock.ForeColor = Color.Black
                End If
            Else
                txtCurrentStock.Text = ""
                txtOrderingPoint.Text = ""
                txtUnit.Text = ""
                txtQty.Clear()

                stockId = 0
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class