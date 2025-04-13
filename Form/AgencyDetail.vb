Imports BlackCoffeeLibrary
Imports HealthInformationSystem
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Deployment.Application
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class AgencyDetail
    Private connection As New clsConnection
    Private directories As New clsDirectory
    Private dbHealth As New SqlDbMethod(connection.MyConnection)
    Private dbJeonsoft As New SqlDbMethod(connection.JeonsoftConnection)
    Private dbMain As New BlackCoffeeLibrary.Main

    Private isNewRecord As Boolean = False
    Private doctorId As Integer = 0
    Private employeeCode As String = String.Empty
    Private isFromParentForm As Boolean = False

    Private bsEmpApe As New BindingSource
    Private bsEmpApeAttach As New BindingSource

    Private WithEvents modifiedDate As Binding

    Public Sub New(_isNewRecord As Boolean, _doctoId As Integer, Optional _employeeCode As String = "", Optional _isFromParentForm As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        isNewRecord = _isNewRecord
        doctorId = _doctoId
        employeeCode = _employeeCode
        isFromParentForm = _isFromParentForm
    End Sub

    Private Sub AgencyDetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        If isNewRecord = True Then
            txtModifiedDate.Text = String.Format("{0:MMMM dd, yyyy  HH:mm}", dbHealth.GetServerDate)
            GetEncoderInformation(doctorId)
            txtEmployeeCode.Text = employeeCode.ToString.Trim

            Me.ActiveControl = txtEmployeeName
        Else

        End If


    End Sub

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

    Private Sub GetEncoderInformation(Optional modifier As Integer = 0)
        Try
            If Not modifier = 0 Then
                Dim modifierName As String = String.Empty
                Dim prm(0) As SqlParameter
                prm(0) = New SqlParameter("@EmployeeCode", SqlDbType.Int)
                prm(0).Value = modifier

                modifierName = dbHealth.ExecuteScalar("SELECT TRIM(EmployeeName) AS EmployeeName FROM dbo.VwClinicAll WHERE EmployeeCode = @EmployeeCode", CommandType.Text, prm)
                txtModifiedBy.Text = StrConv(modifierName, vbProperCase)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadAgency(Optional agencyId As Integer = 0)
        Try

            If agencyId <> 0 Then
                Dim prm(0) As SqlParameter
                prm(0) = New SqlParameter
                prm(0).Value = agencyId

                dbHealth.FillCmbWithCaption("RdAgency", CommandType.StoredProcedure, "AgencyId", "AgenyName", cmbAgency, "< Select Agency >", prm)
            Else

            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class