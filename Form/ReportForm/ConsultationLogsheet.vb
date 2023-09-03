Imports System.Data.SqlClient
Imports BlackCoffeeLibrary
Imports Microsoft.Reporting.WinForms

Public Class ConsultationLogsheet
    Private connection As New clsConnection
    Private dbMain As New BlackCoffeeLibrary.Main
    Private dbMethod As New SqlDbMethod(connection.MyConnection)

    Private dicCompany As New Dictionary(Of String, Integer)
    Private dicEmployee As New Dictionary(Of String, String)

    Private agency As String = String.Empty
    Private employee As String = String.Empty

    Private Sub frmEmployeeRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCompany()
        LoadEmployees(cmbCompany.SelectedValue)

        Me.ActiveControl = btnGenerate
        Me.rptViewer.RefreshReport()
    End Sub

    Private Sub frmEmployeeRecord_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode.Equals(Keys.F10) Then
            e.Handled = True
            btnGenerate.PerformClick()
        End If
    End Sub

    Private Sub LoadCompany()
        Try
            dicCompany.Add("< All >", 0)
            dicCompany.Add("NBC", 99)

            Using rdr As IDataReader = dbMethod.ExecuteReader("RdAgency", CommandType.StoredProcedure)
                While rdr.Read
                    dicCompany.Add(rdr.Item("AgencyName"), rdr.Item("AgencyId"))
                End While
            End Using

            cmbCompany.DisplayMember = "Key"
            cmbCompany.ValueMember = "Value"
            cmbCompany.DataSource = New BindingSource(dicCompany, Nothing)

            AddHandler cmbCompany.SelectedValueChanged, AddressOf cmbCompany_SelectedValueChanged
            AddHandler cmbCompany.Validating, AddressOf cmbCompany_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadEmployees(companyId As Integer)
        Try
            cmbEmployeeName.SelectedValue = 0
            cmbEmployeeName.DataSource = Nothing
            cmbEmployeeName.Items.Clear()

            If companyId = 0 Then
                dbMethod.FillCmbWithCaption("RdEmployeeAll", CommandType.StoredProcedure, "EmployeeId", "EmployeeCodeName", cmbEmployeeName, "<All>")
            ElseIf companyId = 99 Then
                Dim prmNbc(0) As SqlParameter
                prmNbc(0) = New SqlParameter("@AgencyId", SqlDbType.Int)
                prmNbc(0).Value = 99

                dbMethod.FillCmbWithCaption("RdEmployeeAll", CommandType.StoredProcedure, "EmployeeId", "EmployeeCodeName", cmbEmployeeName, "<All>", prmNbc)
            Else
                Dim prmAgency(0) As SqlParameter
                prmAgency(0) = New SqlParameter("@AgencyId", SqlDbType.Int)
                prmAgency(0).Value = companyId

                dbMethod.FillCmbWithCaption("RdEmployeeAll", CommandType.StoredProcedure, "EmployeeId", "EmployeeCodeName", cmbEmployeeName, "<All>", prmAgency)
            End If

            AddHandler cmbEmployeeName.Validating, AddressOf cmbEmployeeName_Validating
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            If dtpStartDatetime.Value > dtpEndDatetime.Value Then
                MessageBox.Show("Start datetime is later than end datetime.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf dtpStartDatetime.Value.ToString("MMM dd, yyyy HH:mm") = dtpEndDatetime.Value.ToString("MMM dd, yyyy HH:mm") Then
                GenerateReport()
            Else
                GenerateReport()
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            dtpStartDatetime.Value = DateTime.Now
            dtpEndDatetime.Value = DateTime.Now
            cmbCompany.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub GenerateReport()
        Try
            Dim prmRpt(3) As SqlParameter
            prmRpt(0) = New SqlParameter("@StartDatetime", SqlDbType.DateTime2)
            prmRpt(0).Value = dtpStartDatetime.Value
            prmRpt(1) = New SqlParameter("@EndDatetime", SqlDbType.DateTime2)
            prmRpt(1).Value = dtpEndDatetime.Value
            prmRpt(2) = New SqlParameter("@AgencyId", SqlDbType.Int)
            prmRpt(2).Value = GetAgency()
            prmRpt(3) = New SqlParameter("@EmployeeId", SqlDbType.Int)
            prmRpt(3).Value = GetEmployeeId()

            Dim dtReport As New DataTable
            dtReport = dbMethod.FillDataTable("RptEmployeeMedicalRecord", CommandType.StoredProcedure, prmRpt)

            If dtReport.Rows.Count > 0 Then
                rptViewer.LocalReport.ReportPath = "ReportFile\ConsultationLogsheet.rdlc"
                rptViewer.LocalReport.DataSources.Clear()
                rptViewer.LocalReport.DataSources.Add(New ReportDataSource("dsReport", dtReport))

                If cmbCompany.SelectedValue = 0 Then
                    agency = " "
                ElseIf cmbCompany.SelectedValue = 99 Then
                    agency = "NBC"
                Else
                    agency = cmbCompany.Text.ToString
                End If

                If Not cmbEmployeeName.SelectedValue = 0 Then
                    employee = cmbEmployeeName.Text.ToString
                Else
                    employee = " "
                End If

                Dim rptParam As New ReportParameterCollection
                rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("StartDatetime", dtpStartDatetime.Value.ToString("MMM dd, yyyy HH:mm")))
                rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("EndDatetime", dtpEndDatetime.Value.ToString("MMM dd, yyyy HH:mm")))
                rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("Agency", agency))
                rptParam.Add(New Microsoft.Reporting.WinForms.ReportParameter("EmployeeName", employee))
                rptViewer.LocalReport.SetParameters(rptParam)

                rptViewer.SetDisplayMode(DisplayMode.PrintLayout)
                rptViewer.ZoomMode = ZoomMode.PageWidth
                rptViewer.LocalReport.DisplayName = "Consultation Logsheet"
                rptViewer.RefreshReport()
            Else
                MessageBox.Show("No records found.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbCompany_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            LoadEmployees(cmbCompany.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetAgency() As Object
        If cmbCompany.SelectedValue = 99 Then 'nbc
            Return 0
        ElseIf cmbCompany.SelectedValue = 0 Then
            Return Nothing
        Else
            Return cmbCompany.SelectedValue
        End If
    End Function

    Private Function GetEmployeeId() As Object
        If Not cmbEmployeeName.SelectedValue = 0 Then
            Return cmbEmployeeName.SelectedValue
        Else
            Return Nothing
        End If
    End Function

    Private Sub cmbCompany_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbCompany.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbEmployeeName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            e.Cancel = sender.FindStringExact(sender.text) < 0 Or String.IsNullOrEmpty(cmbEmployeeName.Text)
            If e.Cancel Then Beep()
        Catch ex As Exception
            MessageBox.Show(dbMain.SetExceptionMessage(ex), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class