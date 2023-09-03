<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHealthScreeningDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHealthScreeningDetail))
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.lblLeaveType = New System.Windows.Forms.Label()
        Me.cmbLeaveType = New System.Windows.Forms.ComboBox()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.lblDiagnosis = New System.Windows.Forms.Label()
        Me.txtDiagnosis = New System.Windows.Forms.TextBox()
        Me.chkNotFtw = New System.Windows.Forms.CheckBox()
        Me.lblNotFtw = New System.Windows.Forms.Label()
        Me.txtAbsentTo = New System.Windows.Forms.MaskedTextBox()
        Me.lblAbsentFrom = New System.Windows.Forms.Label()
        Me.txtAbsentFrom = New System.Windows.Forms.MaskedTextBox()
        Me.lblAbsentTo = New System.Windows.Forms.Label()
        Me.txtEmployeeScanId = New System.Windows.Forms.TextBox()
        Me.txtEmployeeCode = New System.Windows.Forms.Label()
        Me.lblEmployeeCode = New System.Windows.Forms.Label()
        Me.txtCreatedDate = New System.Windows.Forms.Label()
        Me.lblCreatedDate = New System.Windows.Forms.Label()
        Me.lblEmployeeName = New System.Windows.Forms.Label()
        Me.lblReason = New System.Windows.Forms.Label()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.lblEmployeeScanId = New System.Windows.Forms.Label()
        Me.txtCreatedBy = New System.Windows.Forms.Label()
        Me.lblCreatedBy = New System.Windows.Forms.Label()
        Me.txtModifiedBy = New System.Windows.Forms.Label()
        Me.lblModifedBy = New System.Windows.Forms.Label()
        Me.txtModifiedDate = New System.Windows.Forms.Label()
        Me.lblModifiedDate = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancel.DefaultScheme = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnCancel.Hint = "Cancel changes"
        Me.btnCancel.Image = Global.HealthInformationSystem.My.Resources.Resources.Undo
        Me.btnCancel.Location = New System.Drawing.Point(163, 464)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnCancel.Size = New System.Drawing.Size(90, 32)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Cancel"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(353, 464)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 12
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Close"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDelete.DefaultScheme = True
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnDelete.Hint = "Delete"
        Me.btnDelete.Image = Global.HealthInformationSystem.My.Resources.Resources._Erase
        Me.btnDelete.Location = New System.Drawing.Point(258, 464)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "Delete"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSave.DefaultScheme = True
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnSave.Hint = "Save"
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(68, 464)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 9
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "Save"
        '
        'lblLeaveType
        '
        Me.lblLeaveType.BackColor = System.Drawing.SystemColors.Control
        Me.lblLeaveType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLeaveType.ForeColor = System.Drawing.Color.Black
        Me.lblLeaveType.Location = New System.Drawing.Point(5, 230)
        Me.lblLeaveType.Name = "lblLeaveType"
        Me.lblLeaveType.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblLeaveType.Size = New System.Drawing.Size(100, 23)
        Me.lblLeaveType.TabIndex = 565
        Me.lblLeaveType.Text = "Leave Type"
        Me.lblLeaveType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbLeaveType
        '
        Me.cmbLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLeaveType.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.cmbLeaveType.FormattingEnabled = True
        Me.cmbLeaveType.Location = New System.Drawing.Point(104, 230)
        Me.cmbLeaveType.Name = "cmbLeaveType"
        Me.cmbLeaveType.Size = New System.Drawing.Size(340, 21)
        Me.cmbLeaveType.TabIndex = 2
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmployeeName.Location = New System.Drawing.Point(104, 205)
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.Size = New System.Drawing.Size(340, 23)
        Me.txtEmployeeName.TabIndex = 1
        '
        'lblDiagnosis
        '
        Me.lblDiagnosis.BackColor = System.Drawing.SystemColors.Control
        Me.lblDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDiagnosis.ForeColor = System.Drawing.Color.Black
        Me.lblDiagnosis.Location = New System.Drawing.Point(5, 354)
        Me.lblDiagnosis.Name = "lblDiagnosis"
        Me.lblDiagnosis.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblDiagnosis.Size = New System.Drawing.Size(439, 23)
        Me.lblDiagnosis.TabIndex = 564
        Me.lblDiagnosis.Text = "Diagnosis"
        Me.lblDiagnosis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDiagnosis
        '
        Me.txtDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiagnosis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDiagnosis.Location = New System.Drawing.Point(5, 376)
        Me.txtDiagnosis.Multiline = True
        Me.txtDiagnosis.Name = "txtDiagnosis"
        Me.txtDiagnosis.Size = New System.Drawing.Size(439, 50)
        Me.txtDiagnosis.TabIndex = 6
        '
        'chkNotFtw
        '
        Me.chkNotFtw.AutoSize = True
        Me.chkNotFtw.BackColor = System.Drawing.SystemColors.Control
        Me.chkNotFtw.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkNotFtw.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.chkNotFtw.Location = New System.Drawing.Point(14, 433)
        Me.chkNotFtw.Name = "chkNotFtw"
        Me.chkNotFtw.Size = New System.Drawing.Size(15, 14)
        Me.chkNotFtw.TabIndex = 8
        Me.chkNotFtw.UseVisualStyleBackColor = False
        '
        'lblNotFtw
        '
        Me.lblNotFtw.BackColor = System.Drawing.SystemColors.Control
        Me.lblNotFtw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNotFtw.ForeColor = System.Drawing.Color.Black
        Me.lblNotFtw.Location = New System.Drawing.Point(5, 428)
        Me.lblNotFtw.Name = "lblNotFtw"
        Me.lblNotFtw.Padding = New System.Windows.Forms.Padding(25, 0, 0, 0)
        Me.lblNotFtw.Size = New System.Drawing.Size(223, 23)
        Me.lblNotFtw.TabIndex = 7
        Me.lblNotFtw.Text = "Not Fit To Work (F11)"
        Me.lblNotFtw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAbsentTo
        '
        Me.txtAbsentTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAbsentTo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAbsentTo.Location = New System.Drawing.Point(308, 255)
        Me.txtAbsentTo.Mask = "00/00/0000"
        Me.txtAbsentTo.Name = "txtAbsentTo"
        Me.txtAbsentTo.PromptChar = Global.Microsoft.VisualBasic.ChrW(45)
        Me.txtAbsentTo.RejectInputOnFirstFailure = True
        Me.txtAbsentTo.Size = New System.Drawing.Size(136, 23)
        Me.txtAbsentTo.TabIndex = 4
        Me.txtAbsentTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtAbsentTo.ValidatingType = GetType(Date)
        '
        'lblAbsentFrom
        '
        Me.lblAbsentFrom.BackColor = System.Drawing.SystemColors.Control
        Me.lblAbsentFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAbsentFrom.ForeColor = System.Drawing.Color.Black
        Me.lblAbsentFrom.Location = New System.Drawing.Point(5, 255)
        Me.lblAbsentFrom.Name = "lblAbsentFrom"
        Me.lblAbsentFrom.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblAbsentFrom.Size = New System.Drawing.Size(100, 23)
        Me.lblAbsentFrom.TabIndex = 561
        Me.lblAbsentFrom.Text = "Absent From"
        Me.lblAbsentFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAbsentFrom
        '
        Me.txtAbsentFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAbsentFrom.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAbsentFrom.Location = New System.Drawing.Point(103, 255)
        Me.txtAbsentFrom.Mask = "00/00/0000"
        Me.txtAbsentFrom.Name = "txtAbsentFrom"
        Me.txtAbsentFrom.PromptChar = Global.Microsoft.VisualBasic.ChrW(45)
        Me.txtAbsentFrom.Size = New System.Drawing.Size(136, 23)
        Me.txtAbsentFrom.TabIndex = 3
        Me.txtAbsentFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtAbsentFrom.ValidatingType = GetType(Date)
        '
        'lblAbsentTo
        '
        Me.lblAbsentTo.BackColor = System.Drawing.SystemColors.Control
        Me.lblAbsentTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAbsentTo.ForeColor = System.Drawing.Color.Black
        Me.lblAbsentTo.Location = New System.Drawing.Point(241, 255)
        Me.lblAbsentTo.Name = "lblAbsentTo"
        Me.lblAbsentTo.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblAbsentTo.Size = New System.Drawing.Size(68, 23)
        Me.lblAbsentTo.TabIndex = 562
        Me.lblAbsentTo.Text = "To"
        Me.lblAbsentTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeScanId
        '
        Me.txtEmployeeScanId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeScanId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeScanId.Font = New System.Drawing.Font("Segoe UI", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployeeScanId.Location = New System.Drawing.Point(5, 26)
        Me.txtEmployeeScanId.Name = "txtEmployeeScanId"
        Me.txtEmployeeScanId.ShortcutsEnabled = False
        Me.txtEmployeeScanId.Size = New System.Drawing.Size(439, 52)
        Me.txtEmployeeScanId.TabIndex = 0
        Me.txtEmployeeScanId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEmployeeCode
        '
        Me.txtEmployeeCode.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtEmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmployeeCode.ForeColor = System.Drawing.Color.Black
        Me.txtEmployeeCode.Location = New System.Drawing.Point(104, 180)
        Me.txtEmployeeCode.Name = "txtEmployeeCode"
        Me.txtEmployeeCode.Size = New System.Drawing.Size(340, 23)
        Me.txtEmployeeCode.TabIndex = 560
        Me.txtEmployeeCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtEmployeeCode.UseCompatibleTextRendering = True
        '
        'lblEmployeeCode
        '
        Me.lblEmployeeCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmployeeCode.ForeColor = System.Drawing.Color.Black
        Me.lblEmployeeCode.Location = New System.Drawing.Point(5, 180)
        Me.lblEmployeeCode.Name = "lblEmployeeCode"
        Me.lblEmployeeCode.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmployeeCode.Size = New System.Drawing.Size(100, 23)
        Me.lblEmployeeCode.TabIndex = 559
        Me.lblEmployeeCode.Text = "ID Number"
        Me.lblEmployeeCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCreatedDate
        '
        Me.txtCreatedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreatedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCreatedDate.ForeColor = System.Drawing.Color.Black
        Me.txtCreatedDate.Location = New System.Drawing.Point(104, 105)
        Me.txtCreatedDate.Name = "txtCreatedDate"
        Me.txtCreatedDate.Size = New System.Drawing.Size(340, 23)
        Me.txtCreatedDate.TabIndex = 558
        Me.txtCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtCreatedDate.UseCompatibleTextRendering = True
        '
        'lblCreatedDate
        '
        Me.lblCreatedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreatedDate.ForeColor = System.Drawing.Color.Black
        Me.lblCreatedDate.Location = New System.Drawing.Point(5, 105)
        Me.lblCreatedDate.Name = "lblCreatedDate"
        Me.lblCreatedDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblCreatedDate.Size = New System.Drawing.Size(100, 23)
        Me.lblCreatedDate.TabIndex = 557
        Me.lblCreatedDate.Text = "Created Date"
        Me.lblCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmployeeName
        '
        Me.lblEmployeeName.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmployeeName.ForeColor = System.Drawing.Color.Black
        Me.lblEmployeeName.Location = New System.Drawing.Point(5, 205)
        Me.lblEmployeeName.Name = "lblEmployeeName"
        Me.lblEmployeeName.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmployeeName.Size = New System.Drawing.Size(100, 23)
        Me.lblEmployeeName.TabIndex = 556
        Me.lblEmployeeName.Text = "Name"
        Me.lblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReason
        '
        Me.lblReason.BackColor = System.Drawing.SystemColors.Control
        Me.lblReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReason.ForeColor = System.Drawing.Color.Black
        Me.lblReason.Location = New System.Drawing.Point(5, 280)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblReason.Size = New System.Drawing.Size(439, 23)
        Me.lblReason.TabIndex = 555
        Me.lblReason.Text = "Reason / Chief Complaint"
        Me.lblReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReason
        '
        Me.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReason.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtReason.Location = New System.Drawing.Point(5, 302)
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(439, 50)
        Me.txtReason.TabIndex = 5
        '
        'lblEmployeeScanId
        '
        Me.lblEmployeeScanId.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployeeScanId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmployeeScanId.ForeColor = System.Drawing.Color.Black
        Me.lblEmployeeScanId.Location = New System.Drawing.Point(5, 4)
        Me.lblEmployeeScanId.Name = "lblEmployeeScanId"
        Me.lblEmployeeScanId.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmployeeScanId.Size = New System.Drawing.Size(439, 23)
        Me.lblEmployeeScanId.TabIndex = 567
        Me.lblEmployeeScanId.Text = "Employee ID"
        Me.lblEmployeeScanId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreatedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCreatedBy.ForeColor = System.Drawing.Color.Black
        Me.txtCreatedBy.Location = New System.Drawing.Point(104, 80)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.Size = New System.Drawing.Size(340, 23)
        Me.txtCreatedBy.TabIndex = 569
        Me.txtCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtCreatedBy.UseCompatibleTextRendering = True
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreatedBy.ForeColor = System.Drawing.Color.Black
        Me.lblCreatedBy.Location = New System.Drawing.Point(5, 80)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblCreatedBy.Size = New System.Drawing.Size(100, 23)
        Me.lblCreatedBy.TabIndex = 568
        Me.lblCreatedBy.Text = "Created By"
        Me.lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtModifiedBy
        '
        Me.txtModifiedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedBy.Location = New System.Drawing.Point(104, 130)
        Me.txtModifiedBy.Name = "txtModifiedBy"
        Me.txtModifiedBy.Size = New System.Drawing.Size(340, 23)
        Me.txtModifiedBy.TabIndex = 573
        Me.txtModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtModifiedBy.UseCompatibleTextRendering = True
        '
        'lblModifedBy
        '
        Me.lblModifedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifedBy.ForeColor = System.Drawing.Color.Black
        Me.lblModifedBy.Location = New System.Drawing.Point(5, 130)
        Me.lblModifedBy.Name = "lblModifedBy"
        Me.lblModifedBy.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblModifedBy.Size = New System.Drawing.Size(100, 23)
        Me.lblModifedBy.TabIndex = 572
        Me.lblModifedBy.Text = "Modified By"
        Me.lblModifedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtModifiedDate
        '
        Me.txtModifiedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedDate.Location = New System.Drawing.Point(104, 155)
        Me.txtModifiedDate.Name = "txtModifiedDate"
        Me.txtModifiedDate.Size = New System.Drawing.Size(340, 23)
        Me.txtModifiedDate.TabIndex = 571
        Me.txtModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtModifiedDate.UseCompatibleTextRendering = True
        '
        'lblModifiedDate
        '
        Me.lblModifiedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedDate.Location = New System.Drawing.Point(5, 155)
        Me.lblModifiedDate.Name = "lblModifiedDate"
        Me.lblModifiedDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblModifiedDate.Size = New System.Drawing.Size(100, 23)
        Me.lblModifiedDate.TabIndex = 570
        Me.lblModifiedDate.Text = "Modified Date"
        Me.lblModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmHealthScreeningDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(449, 501)
        Me.Controls.Add(Me.txtModifiedBy)
        Me.Controls.Add(Me.lblModifedBy)
        Me.Controls.Add(Me.txtModifiedDate)
        Me.Controls.Add(Me.lblModifiedDate)
        Me.Controls.Add(Me.txtCreatedBy)
        Me.Controls.Add(Me.lblCreatedBy)
        Me.Controls.Add(Me.lblEmployeeScanId)
        Me.Controls.Add(Me.lblLeaveType)
        Me.Controls.Add(Me.cmbLeaveType)
        Me.Controls.Add(Me.txtEmployeeName)
        Me.Controls.Add(Me.lblDiagnosis)
        Me.Controls.Add(Me.txtDiagnosis)
        Me.Controls.Add(Me.chkNotFtw)
        Me.Controls.Add(Me.lblNotFtw)
        Me.Controls.Add(Me.txtAbsentTo)
        Me.Controls.Add(Me.lblAbsentFrom)
        Me.Controls.Add(Me.txtAbsentFrom)
        Me.Controls.Add(Me.lblAbsentTo)
        Me.Controls.Add(Me.txtEmployeeScanId)
        Me.Controls.Add(Me.txtEmployeeCode)
        Me.Controls.Add(Me.lblEmployeeCode)
        Me.Controls.Add(Me.txtCreatedDate)
        Me.Controls.Add(Me.lblCreatedDate)
        Me.Controls.Add(Me.lblEmployeeName)
        Me.Controls.Add(Me.lblReason)
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHealthScreeningDetail"
        Me.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents lblLeaveType As Label
    Friend WithEvents cmbLeaveType As ComboBox
    Friend WithEvents txtEmployeeName As TextBox
    Friend WithEvents lblDiagnosis As Label
    Friend WithEvents txtDiagnosis As TextBox
    Friend WithEvents chkNotFtw As CheckBox
    Friend WithEvents lblNotFtw As Label
    Friend WithEvents txtAbsentTo As MaskedTextBox
    Friend WithEvents lblAbsentFrom As Label
    Friend WithEvents txtAbsentFrom As MaskedTextBox
    Friend WithEvents lblAbsentTo As Label
    Friend WithEvents txtEmployeeScanId As TextBox
    Friend WithEvents txtEmployeeCode As Label
    Friend WithEvents lblEmployeeCode As Label
    Friend WithEvents txtCreatedDate As Label
    Friend WithEvents lblCreatedDate As Label
    Friend WithEvents lblEmployeeName As Label
    Friend WithEvents lblReason As Label
    Friend WithEvents txtReason As TextBox
    Friend WithEvents lblEmployeeScanId As Label
    Friend WithEvents txtCreatedBy As Label
    Friend WithEvents lblCreatedBy As Label
    Friend WithEvents txtModifiedBy As Label
    Friend WithEvents lblModifedBy As Label
    Friend WithEvents txtModifiedDate As Label
    Friend WithEvents lblModifiedDate As Label
End Class
