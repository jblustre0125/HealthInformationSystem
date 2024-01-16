Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports BlackCoffeeLibrary

Public Class MedicineDetail

    Private connection As New clsConnection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.MyConnection)

    Private dtMedicine As New DataTable

    Private orgMedicineName As String = String.Empty
    Private stockId As Integer = 0
    Private medicineId As Integer = 0
    Private userId As Integer = 0

    'the word `byte` is not a valid identifier

    Public Sub New(_userId As Integer, Optional _medicineid As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        medicineId = _medicineid
        userId = _userId

        LoadCategory()
        LoadMedicineUnit()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If medicineId > 0 Then
                Dim prmCnt(0) As SqlParameter
                prmCnt(0) = New SqlParameter("@MedicineId", SqlDbType.Int)
                prmCnt(0).Value = medicineId

                Dim count As Integer = dbMethod.ExecuteScalar("CntMedicineTrx", CommandType.StoredProcedure, prmCnt)

                If count > 0 Then
                    MessageBox.Show("This item contains records. Set to inactive instead.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                Dim question = String.Format("Are you sure you want to delete this item?")
                If MessageBox.Show(question, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim prmDel(0) As SqlParameter
                    prmDel(0) = New SqlParameter("@MedicineId", SqlDbType.Int)
                    prmDel(0).Value = medicineId

                    dbMethod.ExecuteNonQuery("DelMedicine", CommandType.StoredProcedure, prmDel)

                    Me.DialogResult = DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrEmpty(txtMedicineName.Text.Trim) Then
                MessageBox.Show("Medicine name is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMedicineName.Focus()
                Return
            End If

            If cmbCategory.SelectedValue = 0 Then
                MessageBox.Show("Category is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbCategory.Focus()
                Return
            End If

            If cmbUnit.SelectedValue = 0 Then
                MessageBox.Show("Unit of measurement is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbUnit.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtOrderingPoint.Text.Trim) Then
                MessageBox.Show("Ordering point is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtOrderingPoint.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtMaxStock.Text.Trim) Then
                MessageBox.Show("Maximum stock is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMaxStock.Focus()
                Return
            End If

            If String.IsNullOrEmpty(txtMinStock.Text.Trim) Then
                MessageBox.Show("Minimum stock is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMinStock.Focus()
                Return
            End If

            Dim res As Decimal = 0.00
            If Decimal.TryParse(txtUnitPrice.Text.Trim, res) = False Then
                MessageBox.Show("Unit price should be 2 decimal digits.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUnitPrice.Focus()
                Return
            End If

            If medicineId = 0 Then 'new record
                If IsExists(txtMedicineName.Text.Trim) = True Then
                    MessageBox.Show("Medicine already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtMedicineName.Focus()
                    Return
                End If

                Dim prm(12) As SqlParameter
                prm(0) = New SqlParameter("@CreatedBy", SqlDbType.Int)
                prm(0).Value = userId
                prm(1) = New SqlParameter("@CreatedDate", SqlDbType.DateTime)
                prm(1).Value = dbMethod.GetServerDate
                prm(2) = New SqlParameter("@MedicineName", SqlDbType.NVarChar)
                prm(2).Value = txtMedicineName.Text.Trim
                prm(3) = New SqlParameter("@CategoryId", SqlDbType.Int)
                prm(3).Value = cmbCategory.SelectedValue
                prm(4) = New SqlParameter("@UnitId", SqlDbType.Int)
                prm(4).Value = cmbUnit.SelectedValue
                prm(5) = New SqlParameter("@ActualStock", SqlDbType.Int)
                prm(5).Value = IIf(String.IsNullOrEmpty(txtStock.Text.Trim), 0, txtStock.Text)
                prm(6) = New SqlParameter("@OrderingPoint", SqlDbType.Int)
                prm(6).Value = txtOrderingPoint.Text.Trim
                prm(7) = New SqlParameter("@MaxStock", SqlDbType.Int)
                prm(7).Value = txtMaxStock.Text.Trim
                prm(8) = New SqlParameter("@MinStock", SqlDbType.Int)
                prm(8).Value = txtMinStock.Text.Trim
                prm(9) = New SqlParameter("@UnitPrice", SqlDbType.Decimal)
                prm(9).Value = IIf(String.IsNullOrEmpty(txtUnitPrice.Text.Trim), 0, txtUnitPrice.Text)
                prm(10) = New SqlParameter("@Remarks", SqlDbType.VarChar)
                prm(10).Value = IIf(String.IsNullOrEmpty(txtRemarks.Text.Trim), Nothing, txtRemarks.Text.Trim)
                prm(11) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prm(11).Value = IIf(rdActive.Checked = True, True, False)
                prm(12) = New SqlParameter("@MedicineId", SqlDbType.Int)
                prm(12).Direction = ParameterDirection.Output

                dbMethod.ExecuteNonQuery("InsMedicine", CommandType.StoredProcedure, prm)

            Else 'old record
                If Not txtMedicineName.Text.Trim.Equals(orgMedicineName) Then
                    If IsExists(txtMedicineName.Text.Trim) = True Then
                        MessageBox.Show("Medicine already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtMedicineName.Focus()
                        Return
                    End If
                End If

                Dim prm(11) As SqlParameter
                prm(0) = New SqlParameter("@MedicineId", SqlDbType.Int)
                prm(0).Value = medicineId
                prm(1) = New SqlParameter("@MedicineName", SqlDbType.NVarChar)
                prm(1).Value = txtMedicineName.Text.Trim
                prm(2) = New SqlParameter("@CategoryId", SqlDbType.Int)
                prm(2).Value = cmbCategory.SelectedValue
                prm(3) = New SqlParameter("@UnitId", SqlDbType.Int)
                prm(3).Value = cmbUnit.SelectedValue
                prm(4) = New SqlParameter("@OrderingPoint", SqlDbType.Int)
                prm(4).Value = txtOrderingPoint.Text.Trim
                prm(5) = New SqlParameter("@MaxStock", SqlDbType.Int)
                prm(5).Value = txtMaxStock.Text.Trim
                prm(6) = New SqlParameter("@MinStock", SqlDbType.Int)
                prm(6).Value = txtMinStock.Text.Trim
                prm(7) = New SqlParameter("@UnitPrice", SqlDbType.Decimal)
                prm(7).Value = IIf(String.IsNullOrEmpty(txtUnitPrice.Text.Trim), 0, txtUnitPrice.Text)
                prm(8) = New SqlParameter("@Remarks", SqlDbType.VarChar)
                prm(8).Value = IIf(String.IsNullOrEmpty(txtRemarks.Text.Trim), Nothing, txtRemarks.Text.Trim)
                prm(9) = New SqlParameter("@IsActive", SqlDbType.Bit)
                prm(9).Value = IIf(rdActive.Checked = True, True, False)
                prm(10) = New SqlParameter("@ModifiedBy", SqlDbType.Int)
                prm(10).Value = userId
                prm(11) = New SqlParameter("@ModifiedDate", SqlDbType.DateTime)
                prm(11).Value = dbMethod.GetServerDate

                dbMethod.ExecuteNonQuery("UpdMedicine", CommandType.StoredProcedure, prm)
            End If

            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbCategory_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbCategory.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbUnit_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbUnit.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function GetMachineStatus(machineStatusId As Integer) As String
        Dim status As String = String.Empty

        Try
            Dim prm(0) As SqlParameter
            prm(0) = New SqlParameter("@MachineStatusId", SqlDbType.Int)
            prm(0).Value = machineStatusId

            Dim rdr As IDataReader = dbMethod.ExecuteReader("RdMntMachineStatus", CommandType.StoredProcedure, prm)

            While rdr.Read
                status = rdr("MachineStatusName").ToString
            End While
            rdr.Close()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return status
    End Function

    Private Function IsExists(medicineName As String) As Boolean
        Dim count As Integer = 0

        Try
            Dim prmCnt(0) As SqlParameter
            prmCnt(0) = New SqlParameter("@MedicineName", SqlDbType.VarChar)
            prmCnt(0).Value = medicineName

            count = dbMethod.ExecuteScalar("SELECT COUNT(MedicineId) FROM dbo.Medicine WHERE TRIM(MedicineName) = @MedicineName", CommandType.Text, prmCnt)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub LoadCategory()
        Try
            dbMethod.FillCmbWithCaption("RdMedicineCategory", CommandType.StoredProcedure, "CategoryId", "CategoryName", cmbCategory, "< Select Category >")
            AddHandler cmbCategory.Validating, AddressOf cmbCategory_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMedicineUnit()
        Try
            dbMethod.FillCmbWithCaption("RdMedicineUnit", CommandType.StoredProcedure, "UnitId", "UnitName", cmbUnit, "< Select Unit >")
            AddHandler cmbUnit.Validating, AddressOf cmbUnit_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MntMchSchedDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F8) Then
            e.Handled = True
            btnDelete.PerformClick()
        ElseIf e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub MedicineDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If medicineId = 0 Then
                Me.Text = "New Medicine Entry"
                rdActive.Checked = True
            Else
                Me.Text = "Medicine No. " & medicineId
                txtStock.Enabled = False

                Dim prm(0) As SqlParameter
                prm(0) = New SqlParameter("@MedicineId", SqlDbType.Int)
                prm(0).Value = medicineId

                dtMedicine = dbMethod.FillDataTable("RdMedicineStock", CommandType.StoredProcedure, prm)

                For Each row As DataRow In dtMedicine.Rows
                    txtCreatedBy.Text = row("CreatedBy")
                    txtCreatedDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("CreatedDate"))

                    If Not row("ModifiedBy") Is DBNull.Value Then
                        txtModifiedBy.Text = row("ModifiedBy")
                    End If

                    If Not row("ModifiedDate") Is DBNull.Value Then
                        txtModifiedDate.Text = String.Format("{0:MMMM dd, yyyy HH:mm}", row("ModifiedDate"))
                    End If

                    orgMedicineName = row("MedicineName")
                    stockId = row("StockId")

                    txtMedicineName.Text = row("MedicineName")
                    cmbCategory.SelectedValue = row("CategoryId")
                    cmbUnit.SelectedValue = row("UnitId")
                    txtOrderingPoint.Text = row("OrderingPoint")
                    txtMaxStock.Text = row("MaxStock")
                    txtMinStock.Text = row("MinStock")
                    txtUnitPrice.Text = row("UnitPrice")
                    txtStock.Text = row("ActualStock")

                    If Not row("Remarks") Is DBNull.Value Then
                        txtRemarks.Text = row("Remarks")
                    End If

                    If row("IsActive") = True Then
                        rdActive.Checked = True
                    Else
                        rdInactive.Checked = True
                    End If
                Next
            End If

            Me.ActiveControl = txtMedicineName
            txtMedicineName.Select(txtMedicineName.Text.Trim.Length, 0)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrderingPoint.KeyPress, txtMaxStock.KeyPress, txtMinStock.KeyPress, txtStock.KeyPress

        Try
            If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtMedicineName_Enter(sender As Object, e As EventArgs) Handles txtMedicineName.Enter
        lblMedicineName.ForeColor = Color.White
        lblMedicineName.BackColor = Color.DarkSlateGray
    End Sub

    Private Sub txtMedicineName_Leave(sender As Object, e As EventArgs) Handles txtMedicineName.Leave
        lblMedicineName.ForeColor = Color.Black
        lblMedicineName.BackColor = SystemColors.Control
    End Sub

    Private Sub txtUnitPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnitPrice.KeyPress
        Try
            If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtUnitPrice_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtUnitPrice.Validating
        Try
            'Dim res As Decimal = 0.00
            'If Decimal.TryParse(txtUnitPrice.Text, res) Then
            '    e.Cancel = False
            'Else
            '    e.Cancel = True
            'End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class