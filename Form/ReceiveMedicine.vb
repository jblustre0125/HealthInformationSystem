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

Public Class ReceiveMedicine
    Private connection As New clsConnection
    Private directories As New clsDirectory
    Private dbHealth As New SqlDbMethod(connection.MyConnection)
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private doctorId As Integer = 0
    Private recordId As Integer = 0


    Private dsHealth As New dsHealth
    Private adpEmpApe As New EmployeeApeTableAdapter
    Private adpEmpApeAttach As New EmployeeApeAttachmentTableAdapter
    Private dtEmpApe As New EmployeeApeDataTable
    Private dtEmpApeAttach As New EmployeeApeAttachmentDataTable
    Private bsEmpApe As New BindingSource
    Private bsEmpApeAttach As New BindingSource
    Private adpMedicineTrxDetail As New SqlDataAdapter

    Private dtMedicineTrxDetail As New DataTable

    Private WithEvents modifiedDate As Binding

    Private dicCompany As New Dictionary(Of String, Integer)

    Public Sub New(_doctoId As Integer, Optional _recordId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        doctorId = _doctoId
        recordId = _recordId

        dbMain.EnableDoubleBuffered(dgvDetail)

        dtMedicineTrxDetail = CreateMedicineTrxDetail()

        LoadCompany()
    End Sub

    Private Sub ReceiveMedicine_Load(sender As Object, e As EventArgs) Handles Me.Load
        If recordId = 0 Then
            GetEncoderInformation(doctorId)
            txtModifiedDate.Text = String.Format("{0:MMMM dd, yyyy  HH:mm}", dbHealth.GetServerDate)



            Me.ActiveControl = cmbCompany
        Else

        End If

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

    Private Sub AgencyDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F8
                btnDelete.PerformClick()
            Case Keys.F10
                btnSave.PerformClick()
        End Select
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try

        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try


        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
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

    Private Sub LoadCompany()
        Try
            dicCompany.Add("NBC", 99)

            Using rdr As IDataReader = dbHealth.ExecuteReader("RdAgency", CommandType.StoredProcedure)
                While rdr.Read
                    dicCompany.Add(rdr.Item("AgencyName"), rdr.Item("AgencyId"))
                End While
            End Using

            cmbCompany.DisplayMember = "Key"
            cmbCompany.ValueMember = "Value"
            cmbCompany.DataSource = New BindingSource(dicCompany, Nothing)

            'AddHandler cmbCompany.SelectedValueChanged, AddressOf cmbCompany_SelectedValueChanged
            'AddHandler cmbCompany.Validating, AddressOf cmbCompany_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class