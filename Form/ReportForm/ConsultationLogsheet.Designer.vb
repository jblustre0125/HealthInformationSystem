<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultationLogsheet
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.lblEmployeeName = New System.Windows.Forms.Label()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.lblEndDatetime = New System.Windows.Forms.Label()
        Me.lblStartDatetime = New System.Windows.Forms.Label()
        Me.cmbEmployeeName = New SergeUtils.EasyCompletionComboBox()
        Me.cmbCompany = New SergeUtils.EasyCompletionComboBox()
        Me.dtpEndDatetime = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDatetime = New System.Windows.Forms.DateTimePicker()
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
        Me.pnlTop.Controls.Add(Me.lblNote)
        Me.pnlTop.Controls.Add(Me.lblEmployeeName)
        Me.pnlTop.Controls.Add(Me.lblCompany)
        Me.pnlTop.Controls.Add(Me.lblEndDatetime)
        Me.pnlTop.Controls.Add(Me.lblStartDatetime)
        Me.pnlTop.Controls.Add(Me.cmbEmployeeName)
        Me.pnlTop.Controls.Add(Me.cmbCompany)
        Me.pnlTop.Controls.Add(Me.dtpEndDatetime)
        Me.pnlTop.Controls.Add(Me.dtpStartDatetime)
        Me.pnlTop.Controls.Add(Me.btnClose)
        Me.pnlTop.Controls.Add(Me.btnReset)
        Me.pnlTop.Controls.Add(Me.btnGenerate)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1193, 55)
        Me.pnlTop.TabIndex = 551
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNote.Location = New System.Drawing.Point(692, 35)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(420, 15)
        Me.lblNote.TabIndex = 596
        Me.lblNote.Text = "NOTE: Datetime was based on the actual time in/out, not on the date encoded."
        '
        'lblEmployeeName
        '
        Me.lblEmployeeName.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmployeeName.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblEmployeeName.ForeColor = System.Drawing.Color.Black
        Me.lblEmployeeName.Location = New System.Drawing.Point(287, 29)
        Me.lblEmployeeName.Name = "lblEmployeeName"
        Me.lblEmployeeName.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmployeeName.Size = New System.Drawing.Size(100, 23)
        Me.lblEmployeeName.TabIndex = 595
        Me.lblEmployeeName.Text = "Name"
        Me.lblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCompany
        '
        Me.lblCompany.BackColor = System.Drawing.SystemColors.Control
        Me.lblCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCompany.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblCompany.ForeColor = System.Drawing.Color.Black
        Me.lblCompany.Location = New System.Drawing.Point(287, 4)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblCompany.Size = New System.Drawing.Size(100, 23)
        Me.lblCompany.TabIndex = 594
        Me.lblCompany.Text = "Company"
        Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEndDatetime
        '
        Me.lblEndDatetime.BackColor = System.Drawing.SystemColors.Control
        Me.lblEndDatetime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEndDatetime.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblEndDatetime.ForeColor = System.Drawing.Color.Black
        Me.lblEndDatetime.Location = New System.Drawing.Point(5, 29)
        Me.lblEndDatetime.Name = "lblEndDatetime"
        Me.lblEndDatetime.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEndDatetime.Size = New System.Drawing.Size(100, 23)
        Me.lblEndDatetime.TabIndex = 593
        Me.lblEndDatetime.Text = "End Datetime"
        Me.lblEndDatetime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStartDatetime
        '
        Me.lblStartDatetime.BackColor = System.Drawing.SystemColors.Control
        Me.lblStartDatetime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStartDatetime.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblStartDatetime.ForeColor = System.Drawing.Color.Black
        Me.lblStartDatetime.Location = New System.Drawing.Point(5, 4)
        Me.lblStartDatetime.Name = "lblStartDatetime"
        Me.lblStartDatetime.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblStartDatetime.Size = New System.Drawing.Size(100, 23)
        Me.lblStartDatetime.TabIndex = 592
        Me.lblStartDatetime.Text = "Start Datetime"
        Me.lblStartDatetime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbEmployeeName
        '
        Me.cmbEmployeeName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmployeeName.FormattingEnabled = True
        Me.cmbEmployeeName.Items.AddRange(New Object() {"2202-022 MARIA CARIZZA IZZABELLE R. LACERNA"})
        Me.cmbEmployeeName.Location = New System.Drawing.Point(386, 29)
        Me.cmbEmployeeName.Name = "cmbEmployeeName"
        Me.cmbEmployeeName.Size = New System.Drawing.Size(300, 23)
        Me.cmbEmployeeName.TabIndex = 563
        '
        'cmbCompany
        '
        Me.cmbCompany.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCompany.FormattingEnabled = True
        Me.cmbCompany.Items.AddRange(New Object() {"Efraim Joshua Borja Malibong"})
        Me.cmbCompany.Location = New System.Drawing.Point(386, 4)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.Size = New System.Drawing.Size(300, 23)
        Me.cmbCompany.TabIndex = 561
        '
        'dtpEndDatetime
        '
        Me.dtpEndDatetime.CustomFormat = "MMMM dd, yyyy HH:mm"
        Me.dtpEndDatetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDatetime.Location = New System.Drawing.Point(104, 29)
        Me.dtpEndDatetime.Name = "dtpEndDatetime"
        Me.dtpEndDatetime.Size = New System.Drawing.Size(180, 23)
        Me.dtpEndDatetime.TabIndex = 558
        '
        'dtpStartDatetime
        '
        Me.dtpStartDatetime.CustomFormat = "MMMM dd, yyyy HH:mm"
        Me.dtpStartDatetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDatetime.Location = New System.Drawing.Point(104, 4)
        Me.dtpStartDatetime.Name = "dtpStartDatetime"
        Me.dtpStartDatetime.Size = New System.Drawing.Size(180, 23)
        Me.dtpStartDatetime.TabIndex = 556
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClose.Hint = "Remove filter"
        Me.btnClose.Location = New System.Drawing.Point(877, 2)
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
        Me.btnReset.Location = New System.Drawing.Point(783, 2)
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
        Me.btnGenerate.Location = New System.Drawing.Point(689, 2)
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
        Me.rptViewer.Location = New System.Drawing.Point(0, 55)
        Me.rptViewer.Name = "rptViewer"
        Me.rptViewer.Size = New System.Drawing.Size(1193, 395)
        Me.rptViewer.TabIndex = 557
        Me.rptViewer.TabStop = False
        '
        'ConsultationLogsheet
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
        Me.Name = "ConsultationLogsheet"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultation Logsheet"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTop As Panel
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnReset As PinkieControls.ButtonXP
    Friend WithEvents btnGenerate As PinkieControls.ButtonXP
    Friend WithEvents rptViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents cmbCompany As SergeUtils.EasyCompletionComboBox
    Friend WithEvents dtpEndDatetime As DateTimePicker
    Friend WithEvents dtpStartDatetime As DateTimePicker
    Friend WithEvents cmbEmployeeName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblStartDatetime As Label
    Friend WithEvents lblEmployeeName As Label
    Friend WithEvents lblCompany As Label
    Friend WithEvents lblEndDatetime As Label
    Friend WithEvents lblNote As Label
End Class
