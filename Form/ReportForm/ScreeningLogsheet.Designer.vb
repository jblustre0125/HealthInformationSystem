<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ScreeningLogsheet
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.lblEmployeeName = New System.Windows.Forms.Label()
        Me.cmbEmployeeName = New SergeUtils.EasyCompletionComboBox()
        Me.cmbLeaveType = New SergeUtils.EasyCompletionComboBox()
        Me.lblLeaveType = New System.Windows.Forms.Label()
        Me.lblDateType = New System.Windows.Forms.Label()
        Me.cmbDateType = New SergeUtils.EasyCompletionComboBox()
        Me.lblEmploymentType = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblEndTo = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.cmbEmploymentType = New SergeUtils.EasyCompletionComboBox()
        Me.cmbStatus = New SergeUtils.EasyCompletionComboBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnReset = New PinkieControls.ButtonXP()
        Me.btnGenerate = New PinkieControls.ButtonXP()
        Me.rptViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.pnlTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.White
        Me.pnlTop.Controls.Add(Me.lblEmployeeName)
        Me.pnlTop.Controls.Add(Me.cmbEmployeeName)
        Me.pnlTop.Controls.Add(Me.cmbLeaveType)
        Me.pnlTop.Controls.Add(Me.lblLeaveType)
        Me.pnlTop.Controls.Add(Me.lblDateType)
        Me.pnlTop.Controls.Add(Me.cmbDateType)
        Me.pnlTop.Controls.Add(Me.lblEmploymentType)
        Me.pnlTop.Controls.Add(Me.lblStatus)
        Me.pnlTop.Controls.Add(Me.lblEndTo)
        Me.pnlTop.Controls.Add(Me.lblStartDate)
        Me.pnlTop.Controls.Add(Me.cmbEmploymentType)
        Me.pnlTop.Controls.Add(Me.cmbStatus)
        Me.pnlTop.Controls.Add(Me.dtpEndDate)
        Me.pnlTop.Controls.Add(Me.dtpStartDate)
        Me.pnlTop.Controls.Add(Me.btnClose)
        Me.pnlTop.Controls.Add(Me.btnReset)
        Me.pnlTop.Controls.Add(Me.btnGenerate)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1193, 92)
        Me.pnlTop.TabIndex = 551
        '
        'lblEmployeeName
        '
        Me.lblEmployeeName.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmployeeName.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblEmployeeName.ForeColor = System.Drawing.Color.Black
        Me.lblEmployeeName.Location = New System.Drawing.Point(661, 29)
        Me.lblEmployeeName.Name = "lblEmployeeName"
        Me.lblEmployeeName.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmployeeName.Size = New System.Drawing.Size(100, 23)
        Me.lblEmployeeName.TabIndex = 601
        Me.lblEmployeeName.Text = "Name"
        Me.lblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbEmployeeName
        '
        Me.cmbEmployeeName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmployeeName.FormattingEnabled = True
        Me.cmbEmployeeName.Location = New System.Drawing.Point(760, 29)
        Me.cmbEmployeeName.Name = "cmbEmployeeName"
        Me.cmbEmployeeName.Size = New System.Drawing.Size(428, 23)
        Me.cmbEmployeeName.TabIndex = 600
        '
        'cmbLeaveType
        '
        Me.cmbLeaveType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLeaveType.FormattingEnabled = True
        Me.cmbLeaveType.Items.AddRange(New Object() {"Efraim Joshua Borja Malibong"})
        Me.cmbLeaveType.Location = New System.Drawing.Point(760, 3)
        Me.cmbLeaveType.Name = "cmbLeaveType"
        Me.cmbLeaveType.Size = New System.Drawing.Size(428, 23)
        Me.cmbLeaveType.TabIndex = 599
        '
        'lblLeaveType
        '
        Me.lblLeaveType.BackColor = System.Drawing.SystemColors.Control
        Me.lblLeaveType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLeaveType.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblLeaveType.ForeColor = System.Drawing.Color.Black
        Me.lblLeaveType.Location = New System.Drawing.Point(661, 3)
        Me.lblLeaveType.Name = "lblLeaveType"
        Me.lblLeaveType.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblLeaveType.Size = New System.Drawing.Size(100, 23)
        Me.lblLeaveType.TabIndex = 598
        Me.lblLeaveType.Text = "Leave Type"
        Me.lblLeaveType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDateType
        '
        Me.lblDateType.BackColor = System.Drawing.SystemColors.Control
        Me.lblDateType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDateType.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblDateType.ForeColor = System.Drawing.Color.Black
        Me.lblDateType.Location = New System.Drawing.Point(5, 3)
        Me.lblDateType.Name = "lblDateType"
        Me.lblDateType.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblDateType.Size = New System.Drawing.Size(100, 23)
        Me.lblDateType.TabIndex = 597
        Me.lblDateType.Text = "Date Type"
        Me.lblDateType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDateType
        '
        Me.cmbDateType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDateType.FormattingEnabled = True
        Me.cmbDateType.Items.AddRange(New Object() {"Efraim Joshua Borja Malibong"})
        Me.cmbDateType.Location = New System.Drawing.Point(104, 3)
        Me.cmbDateType.Name = "cmbDateType"
        Me.cmbDateType.Size = New System.Drawing.Size(150, 23)
        Me.cmbDateType.TabIndex = 596
        '
        'lblEmploymentType
        '
        Me.lblEmploymentType.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmploymentType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmploymentType.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblEmploymentType.ForeColor = System.Drawing.Color.Black
        Me.lblEmploymentType.Location = New System.Drawing.Point(310, 29)
        Me.lblEmploymentType.Name = "lblEmploymentType"
        Me.lblEmploymentType.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmploymentType.Size = New System.Drawing.Size(100, 23)
        Me.lblEmploymentType.TabIndex = 595
        Me.lblEmploymentType.Text = "Employment"
        Me.lblEmploymentType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(5, 29)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblStatus.Size = New System.Drawing.Size(100, 23)
        Me.lblStatus.TabIndex = 594
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEndTo
        '
        Me.lblEndTo.BackColor = System.Drawing.SystemColors.Control
        Me.lblEndTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEndTo.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblEndTo.ForeColor = System.Drawing.Color.Black
        Me.lblEndTo.Location = New System.Drawing.Point(459, 3)
        Me.lblEndTo.Name = "lblEndTo"
        Me.lblEndTo.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEndTo.Size = New System.Drawing.Size(50, 23)
        Me.lblEndTo.TabIndex = 593
        Me.lblEndTo.Text = "To"
        Me.lblEndTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStartDate
        '
        Me.lblStartDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStartDate.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblStartDate.ForeColor = System.Drawing.Color.Black
        Me.lblStartDate.Location = New System.Drawing.Point(257, 3)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblStartDate.Size = New System.Drawing.Size(50, 23)
        Me.lblStartDate.TabIndex = 592
        Me.lblStartDate.Text = "From"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbEmploymentType
        '
        Me.cmbEmploymentType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmploymentType.FormattingEnabled = True
        Me.cmbEmploymentType.Items.AddRange(New Object() {"2202-022 MARIA CARIZZA IZZABELLE R. LACERNA"})
        Me.cmbEmploymentType.Location = New System.Drawing.Point(409, 29)
        Me.cmbEmploymentType.Name = "cmbEmploymentType"
        Me.cmbEmploymentType.Size = New System.Drawing.Size(249, 23)
        Me.cmbEmploymentType.TabIndex = 563
        '
        'cmbStatus
        '
        Me.cmbStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"Efraim Joshua Borja Malibong"})
        Me.cmbStatus.Location = New System.Drawing.Point(104, 29)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(203, 23)
        Me.cmbStatus.TabIndex = 561
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "MMMM dd, yyyy HH:mm"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(508, 3)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(150, 23)
        Me.dtpEndDate.TabIndex = 558
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "MMMM dd, yyyy HH:mm"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(306, 3)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(150, 23)
        Me.dtpStartDate.TabIndex = 556
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClose.Hint = "Remove filter"
        Me.btnClose.Location = New System.Drawing.Point(192, 56)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 555
        Me.btnClose.Text = "Close"
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnReset.CausesValidation = False
        Me.btnReset.DefaultScheme = True
        Me.btnReset.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnReset.Hint = "Remove filter"
        Me.btnReset.Location = New System.Drawing.Point(98, 56)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnReset.Size = New System.Drawing.Size(90, 32)
        Me.btnReset.TabIndex = 554
        Me.btnReset.Text = "Reset"
        '
        'btnGenerate
        '
        Me.btnGenerate.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnGenerate.DefaultScheme = True
        Me.btnGenerate.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnGenerate.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnGenerate.Hint = "Search"
        Me.btnGenerate.Location = New System.Drawing.Point(4, 56)
        Me.btnGenerate.Margin = New System.Windows.Forms.Padding(2)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnGenerate.Size = New System.Drawing.Size(90, 32)
        Me.btnGenerate.TabIndex = 553
        Me.btnGenerate.Text = "Generate"
        '
        'rptViewer
        '
        Me.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptViewer.Location = New System.Drawing.Point(0, 92)
        Me.rptViewer.Name = "rptViewer"
        Me.rptViewer.Size = New System.Drawing.Size(1193, 358)
        Me.rptViewer.TabIndex = 557
        Me.rptViewer.TabStop = False
        '
        'ScreeningLogsheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.LightGray
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1193, 450)
        Me.Controls.Add(Me.rptViewer)
        Me.Controls.Add(Me.pnlTop)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "ScreeningLogsheet"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Screening Logsheet"
        Me.pnlTop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTop As Panel
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnReset As PinkieControls.ButtonXP
    Friend WithEvents btnGenerate As PinkieControls.ButtonXP
    Friend WithEvents rptViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents lblStartDate As Label
    Friend WithEvents lblEndTo As Label
    Friend WithEvents cmbLeaveType As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblLeaveType As Label
    Friend WithEvents lblEmployeeName As Label
    Friend WithEvents cmbEmployeeName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblDateType As Label
    Friend WithEvents cmbDateType As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblEmploymentType As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents cmbEmploymentType As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cmbStatus As SergeUtils.EasyCompletionComboBox
End Class
