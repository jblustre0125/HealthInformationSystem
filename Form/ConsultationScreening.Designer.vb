<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConsultationScreening
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultationScreening))
        Me.lblMedCertDate = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.txtChiefComplaint = New System.Windows.Forms.TextBox()
        Me.lblChiefComplaint = New System.Windows.Forms.Label()
        Me.txtDiagnosis = New System.Windows.Forms.TextBox()
        Me.lblDiagnosis = New System.Windows.Forms.Label()
        Me.txtMedCertDate = New System.Windows.Forms.MaskedTextBox()
        Me.chkFitToWork = New System.Windows.Forms.CheckBox()
        Me.lblFitToWork = New System.Windows.Forms.Label()
        Me.chkSentHome = New System.Windows.Forms.CheckBox()
        Me.lblSentHome = New System.Windows.Forms.Label()
        Me.txtCreatedBy = New System.Windows.Forms.Label()
        Me.lblCreatedBy = New System.Windows.Forms.Label()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.ofdRecDetail = New System.Windows.Forms.OpenFileDialog()
        Me.txtModifiedBy = New System.Windows.Forms.Label()
        Me.lblModifiedBy = New System.Windows.Forms.Label()
        Me.txtCreatedDate = New System.Windows.Forms.Label()
        Me.lblCreatedDate = New System.Windows.Forms.Label()
        Me.txtModifiedDate = New System.Windows.Forms.Label()
        Me.lblModifiedDate = New System.Windows.Forms.Label()
        Me.lblEmployeeCode = New System.Windows.Forms.Label()
        Me.txtEmployeeCode = New System.Windows.Forms.TextBox()
        Me.txtEmployeeName = New System.Windows.Forms.Label()
        Me.lblEmployeeName = New System.Windows.Forms.Label()
        Me.lblConsultation = New System.Windows.Forms.Label()
        Me.txtStartDate = New System.Windows.Forms.MaskedTextBox()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.txtEndDate = New System.Windows.Forms.MaskedTextBox()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblLeaveType = New System.Windows.Forms.Label()
        Me.cmbLeaveType = New SergeUtils.EasyCompletionComboBox()
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.txtEmployeeNameAgency = New System.Windows.Forms.TextBox()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.txtG = New System.Windows.Forms.Label()
        Me.txtGp = New System.Windows.Forms.Label()
        Me.txtObHistory = New System.Windows.Forms.Label()
        Me.lblG = New System.Windows.Forms.Label()
        Me.lblGp = New System.Windows.Forms.Label()
        Me.lblObHistory = New System.Windows.Forms.Label()
        Me.txtSurgHistory = New System.Windows.Forms.Label()
        Me.txtMedHistory = New System.Windows.Forms.Label()
        Me.lblSurgHistory = New System.Windows.Forms.Label()
        Me.lblMedHistory = New System.Windows.Forms.Label()
        Me.lblEmer = New System.Windows.Forms.Label()
        Me.txtEmgContactAddress = New System.Windows.Forms.Label()
        Me.lblEmgContactAddress = New System.Windows.Forms.Label()
        Me.txtEmgContactNumber = New System.Windows.Forms.Label()
        Me.lblEmgContactNumber = New System.Windows.Forms.Label()
        Me.txtEmgContactName = New System.Windows.Forms.Label()
        Me.lblEmgContactName = New System.Windows.Forms.Label()
        Me.lblPersonalInfo = New System.Windows.Forms.Label()
        Me.txtAllergies = New System.Windows.Forms.Label()
        Me.lblAllergies = New System.Windows.Forms.Label()
        Me.txtBloodType = New System.Windows.Forms.Label()
        Me.lblBloodType = New System.Windows.Forms.Label()
        Me.txtLocalAddress = New System.Windows.Forms.Label()
        Me.lblLocalAddress = New System.Windows.Forms.Label()
        Me.txtContactNumber = New System.Windows.Forms.Label()
        Me.lblContactNumber = New System.Windows.Forms.Label()
        Me.txtCivilStatus = New System.Windows.Forms.Label()
        Me.lblCivilStatus = New System.Windows.Forms.Label()
        Me.txtAge = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.txtGender = New System.Windows.Forms.Label()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.txtEmploymentStatus = New System.Windows.Forms.Label()
        Me.lblEmploymentStatus = New System.Windows.Forms.Label()
        Me.txtPosition = New System.Windows.Forms.Label()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.txtSection = New System.Windows.Forms.Label()
        Me.lblSection = New System.Windows.Forms.Label()
        Me.txtDepartment = New System.Windows.Forms.Label()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.Label()
        Me.pnlLeft.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMedCertDate
        '
        Me.lblMedCertDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblMedCertDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMedCertDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMedCertDate.ForeColor = System.Drawing.Color.Black
        Me.lblMedCertDate.Location = New System.Drawing.Point(330, 278)
        Me.lblMedCertDate.Name = "lblMedCertDate"
        Me.lblMedCertDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblMedCertDate.Size = New System.Drawing.Size(110, 23)
        Me.lblMedCertDate.TabIndex = 541
        Me.lblMedCertDate.Text = "Med. Cert Date"
        Me.lblMedCertDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblQty
        '
        Me.lblQty.BackColor = System.Drawing.SystemColors.Control
        Me.lblQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQty.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblQty.ForeColor = System.Drawing.Color.Black
        Me.lblQty.Location = New System.Drawing.Point(330, 253)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblQty.Size = New System.Drawing.Size(110, 23)
        Me.lblQty.TabIndex = 543
        Me.lblQty.Text = "No. of Day(s)"
        Me.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtChiefComplaint
        '
        Me.txtChiefComplaint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChiefComplaint.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtChiefComplaint.Location = New System.Drawing.Point(330, 326)
        Me.txtChiefComplaint.Multiline = True
        Me.txtChiefComplaint.Name = "txtChiefComplaint"
        Me.txtChiefComplaint.Size = New System.Drawing.Size(379, 110)
        Me.txtChiefComplaint.TabIndex = 20
        '
        'lblChiefComplaint
        '
        Me.lblChiefComplaint.BackColor = System.Drawing.SystemColors.Control
        Me.lblChiefComplaint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChiefComplaint.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblChiefComplaint.ForeColor = System.Drawing.Color.Black
        Me.lblChiefComplaint.Location = New System.Drawing.Point(330, 303)
        Me.lblChiefComplaint.Name = "lblChiefComplaint"
        Me.lblChiefComplaint.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblChiefComplaint.Size = New System.Drawing.Size(379, 24)
        Me.lblChiefComplaint.TabIndex = 551
        Me.lblChiefComplaint.Text = "Chief Complaint"
        Me.lblChiefComplaint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDiagnosis
        '
        Me.txtDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiagnosis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDiagnosis.Location = New System.Drawing.Point(330, 462)
        Me.txtDiagnosis.Multiline = True
        Me.txtDiagnosis.Name = "txtDiagnosis"
        Me.txtDiagnosis.Size = New System.Drawing.Size(379, 135)
        Me.txtDiagnosis.TabIndex = 21
        '
        'lblDiagnosis
        '
        Me.lblDiagnosis.BackColor = System.Drawing.SystemColors.Control
        Me.lblDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDiagnosis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDiagnosis.ForeColor = System.Drawing.Color.Black
        Me.lblDiagnosis.Location = New System.Drawing.Point(330, 438)
        Me.lblDiagnosis.Name = "lblDiagnosis"
        Me.lblDiagnosis.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblDiagnosis.Size = New System.Drawing.Size(379, 25)
        Me.lblDiagnosis.TabIndex = 557
        Me.lblDiagnosis.Text = "Diagnosis"
        Me.lblDiagnosis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMedCertDate
        '
        Me.txtMedCertDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMedCertDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMedCertDate.Location = New System.Drawing.Point(439, 278)
        Me.txtMedCertDate.Mask = "00/00/0000"
        Me.txtMedCertDate.Name = "txtMedCertDate"
        Me.txtMedCertDate.PromptChar = Global.Microsoft.VisualBasic.ChrW(45)
        Me.txtMedCertDate.Size = New System.Drawing.Size(270, 23)
        Me.txtMedCertDate.TabIndex = 5
        Me.txtMedCertDate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtMedCertDate.ValidatingType = GetType(Date)
        '
        'chkFitToWork
        '
        Me.chkFitToWork.AutoSize = True
        Me.chkFitToWork.BackColor = System.Drawing.SystemColors.Control
        Me.chkFitToWork.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkFitToWork.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkFitToWork.Location = New System.Drawing.Point(336, 604)
        Me.chkFitToWork.Name = "chkFitToWork"
        Me.chkFitToWork.Size = New System.Drawing.Size(15, 14)
        Me.chkFitToWork.TabIndex = 15
        Me.chkFitToWork.UseVisualStyleBackColor = False
        '
        'lblFitToWork
        '
        Me.lblFitToWork.BackColor = System.Drawing.SystemColors.Control
        Me.lblFitToWork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFitToWork.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFitToWork.ForeColor = System.Drawing.Color.Black
        Me.lblFitToWork.Location = New System.Drawing.Point(330, 599)
        Me.lblFitToWork.Name = "lblFitToWork"
        Me.lblFitToWork.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.lblFitToWork.Size = New System.Drawing.Size(379, 23)
        Me.lblFitToWork.TabIndex = 6
        Me.lblFitToWork.Text = "Fit To Work"
        Me.lblFitToWork.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkSentHome
        '
        Me.chkSentHome.AutoSize = True
        Me.chkSentHome.BackColor = System.Drawing.SystemColors.Control
        Me.chkSentHome.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkSentHome.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.chkSentHome.Location = New System.Drawing.Point(336, 629)
        Me.chkSentHome.Name = "chkSentHome"
        Me.chkSentHome.Size = New System.Drawing.Size(15, 14)
        Me.chkSentHome.TabIndex = 16
        Me.chkSentHome.UseVisualStyleBackColor = False
        '
        'lblSentHome
        '
        Me.lblSentHome.BackColor = System.Drawing.SystemColors.Control
        Me.lblSentHome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSentHome.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSentHome.ForeColor = System.Drawing.Color.Black
        Me.lblSentHome.Location = New System.Drawing.Point(330, 624)
        Me.lblSentHome.Name = "lblSentHome"
        Me.lblSentHome.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.lblSentHome.Size = New System.Drawing.Size(379, 23)
        Me.lblSentHome.TabIndex = 7
        Me.lblSentHome.Text = "Sent Home"
        Me.lblSentHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreatedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCreatedBy.ForeColor = System.Drawing.Color.Black
        Me.txtCreatedBy.Location = New System.Drawing.Point(439, 28)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtCreatedBy.Size = New System.Drawing.Size(270, 23)
        Me.txtCreatedBy.TabIndex = 570
        Me.txtCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreatedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCreatedBy.ForeColor = System.Drawing.Color.Black
        Me.lblCreatedBy.Location = New System.Drawing.Point(330, 28)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblCreatedBy.Size = New System.Drawing.Size(110, 23)
        Me.lblCreatedBy.TabIndex = 569
        Me.lblCreatedBy.Text = "Created By"
        Me.lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(619, 662)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 16
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Close"
        '
        'ofdRecDetail
        '
        Me.ofdRecDetail.Multiselect = True
        '
        'txtModifiedBy
        '
        Me.txtModifiedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedBy.Location = New System.Drawing.Point(439, 78)
        Me.txtModifiedBy.Name = "txtModifiedBy"
        Me.txtModifiedBy.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtModifiedBy.Size = New System.Drawing.Size(270, 23)
        Me.txtModifiedBy.TabIndex = 582
        Me.txtModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblModifiedBy
        '
        Me.lblModifiedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedBy.Location = New System.Drawing.Point(330, 78)
        Me.lblModifiedBy.Name = "lblModifiedBy"
        Me.lblModifiedBy.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblModifiedBy.Size = New System.Drawing.Size(110, 23)
        Me.lblModifiedBy.TabIndex = 581
        Me.lblModifiedBy.Text = "Modified By"
        Me.lblModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCreatedDate
        '
        Me.txtCreatedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreatedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCreatedDate.ForeColor = System.Drawing.Color.Black
        Me.txtCreatedDate.Location = New System.Drawing.Point(439, 53)
        Me.txtCreatedDate.Name = "txtCreatedDate"
        Me.txtCreatedDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtCreatedDate.Size = New System.Drawing.Size(270, 23)
        Me.txtCreatedDate.TabIndex = 580
        Me.txtCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreatedDate
        '
        Me.lblCreatedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreatedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCreatedDate.ForeColor = System.Drawing.Color.Black
        Me.lblCreatedDate.Location = New System.Drawing.Point(330, 53)
        Me.lblCreatedDate.Name = "lblCreatedDate"
        Me.lblCreatedDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblCreatedDate.Size = New System.Drawing.Size(110, 23)
        Me.lblCreatedDate.TabIndex = 579
        Me.lblCreatedDate.Text = "Created Date"
        Me.lblCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtModifiedDate
        '
        Me.txtModifiedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedDate.Location = New System.Drawing.Point(439, 103)
        Me.txtModifiedDate.Name = "txtModifiedDate"
        Me.txtModifiedDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtModifiedDate.Size = New System.Drawing.Size(270, 23)
        Me.txtModifiedDate.TabIndex = 584
        Me.txtModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblModifiedDate
        '
        Me.lblModifiedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedDate.Location = New System.Drawing.Point(330, 103)
        Me.lblModifiedDate.Name = "lblModifiedDate"
        Me.lblModifiedDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblModifiedDate.Size = New System.Drawing.Size(110, 23)
        Me.lblModifiedDate.TabIndex = 583
        Me.lblModifiedDate.Text = "Modified Date"
        Me.lblModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmployeeCode
        '
        Me.lblEmployeeCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmployeeCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEmployeeCode.ForeColor = System.Drawing.Color.Black
        Me.lblEmployeeCode.Location = New System.Drawing.Point(330, 128)
        Me.lblEmployeeCode.Name = "lblEmployeeCode"
        Me.lblEmployeeCode.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmployeeCode.Size = New System.Drawing.Size(110, 23)
        Me.lblEmployeeCode.TabIndex = 588
        Me.lblEmployeeCode.Text = "Employee ID"
        Me.lblEmployeeCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeCode
        '
        Me.txtEmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmployeeCode.Location = New System.Drawing.Point(439, 128)
        Me.txtEmployeeCode.Name = "txtEmployeeCode"
        Me.txtEmployeeCode.Size = New System.Drawing.Size(270, 23)
        Me.txtEmployeeCode.TabIndex = 0
        Me.txtEmployeeCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmployeeName.ForeColor = System.Drawing.Color.Black
        Me.txtEmployeeName.Location = New System.Drawing.Point(439, 153)
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtEmployeeName.Size = New System.Drawing.Size(270, 23)
        Me.txtEmployeeName.TabIndex = 590
        Me.txtEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmployeeName
        '
        Me.lblEmployeeName.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmployeeName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEmployeeName.ForeColor = System.Drawing.Color.Black
        Me.lblEmployeeName.Location = New System.Drawing.Point(330, 153)
        Me.lblEmployeeName.Name = "lblEmployeeName"
        Me.lblEmployeeName.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmployeeName.Size = New System.Drawing.Size(110, 23)
        Me.lblEmployeeName.TabIndex = 589
        Me.lblEmployeeName.Text = "Employee Name"
        Me.lblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblConsultation
        '
        Me.lblConsultation.BackColor = System.Drawing.Color.DarkSlateGray
        Me.lblConsultation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblConsultation.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsultation.ForeColor = System.Drawing.Color.White
        Me.lblConsultation.Location = New System.Drawing.Point(330, 4)
        Me.lblConsultation.Name = "lblConsultation"
        Me.lblConsultation.Size = New System.Drawing.Size(379, 22)
        Me.lblConsultation.TabIndex = 625
        Me.lblConsultation.Text = "Health Screening"
        Me.lblConsultation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtStartDate
        '
        Me.txtStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStartDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtStartDate.Location = New System.Drawing.Point(439, 203)
        Me.txtStartDate.Mask = "00/00/0000"
        Me.txtStartDate.Name = "txtStartDate"
        Me.txtStartDate.PromptChar = Global.Microsoft.VisualBasic.ChrW(45)
        Me.txtStartDate.Size = New System.Drawing.Size(270, 23)
        Me.txtStartDate.TabIndex = 3
        Me.txtStartDate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtStartDate.ValidatingType = GetType(Date)
        '
        'lblStartDate
        '
        Me.lblStartDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStartDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStartDate.ForeColor = System.Drawing.Color.Black
        Me.lblStartDate.Location = New System.Drawing.Point(330, 203)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblStartDate.Size = New System.Drawing.Size(110, 23)
        Me.lblStartDate.TabIndex = 627
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEndDate
        '
        Me.txtEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEndDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEndDate.Location = New System.Drawing.Point(439, 228)
        Me.txtEndDate.Mask = "00/00/0000"
        Me.txtEndDate.Name = "txtEndDate"
        Me.txtEndDate.PromptChar = Global.Microsoft.VisualBasic.ChrW(45)
        Me.txtEndDate.Size = New System.Drawing.Size(270, 23)
        Me.txtEndDate.TabIndex = 4
        Me.txtEndDate.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtEndDate.ValidatingType = GetType(Date)
        '
        'lblEndDate
        '
        Me.lblEndDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEndDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEndDate.ForeColor = System.Drawing.Color.Black
        Me.lblEndDate.Location = New System.Drawing.Point(330, 228)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEndDate.Size = New System.Drawing.Size(110, 23)
        Me.lblEndDate.TabIndex = 629
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLeaveType
        '
        Me.lblLeaveType.BackColor = System.Drawing.SystemColors.Control
        Me.lblLeaveType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLeaveType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblLeaveType.ForeColor = System.Drawing.Color.Black
        Me.lblLeaveType.Location = New System.Drawing.Point(330, 178)
        Me.lblLeaveType.Name = "lblLeaveType"
        Me.lblLeaveType.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblLeaveType.Size = New System.Drawing.Size(110, 23)
        Me.lblLeaveType.TabIndex = 637
        Me.lblLeaveType.Text = "Leave Type"
        Me.lblLeaveType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbLeaveType
        '
        Me.cmbLeaveType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbLeaveType.FormattingEnabled = True
        Me.cmbLeaveType.Location = New System.Drawing.Point(439, 178)
        Me.cmbLeaveType.Name = "cmbLeaveType"
        Me.cmbLeaveType.Size = New System.Drawing.Size(270, 23)
        Me.cmbLeaveType.TabIndex = 14
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancel.CausesValidation = False
        Me.btnCancel.DefaultScheme = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnCancel.Hint = "Cancel changes"
        Me.btnCancel.Image = Global.HealthInformationSystem.My.Resources.Resources.Undo
        Me.btnCancel.Location = New System.Drawing.Point(429, 662)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnCancel.Size = New System.Drawing.Size(90, 32)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Cancel"
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
        Me.btnDelete.Location = New System.Drawing.Point(524, 662)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 15
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
        Me.btnSave.Location = New System.Drawing.Point(334, 662)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 13
        Me.btnSave.TabStop = False
        Me.btnSave.Text = " Save"
        '
        'txtEmployeeNameAgency
        '
        Me.txtEmployeeNameAgency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeNameAgency.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeNameAgency.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmployeeNameAgency.Location = New System.Drawing.Point(439, 153)
        Me.txtEmployeeNameAgency.Name = "txtEmployeeNameAgency"
        Me.txtEmployeeNameAgency.Size = New System.Drawing.Size(270, 23)
        Me.txtEmployeeNameAgency.TabIndex = 2
        Me.txtEmployeeNameAgency.Visible = False
        '
        'pnlLeft
        '
        Me.pnlLeft.AutoScroll = True
        Me.pnlLeft.Controls.Add(Me.txtG)
        Me.pnlLeft.Controls.Add(Me.txtGp)
        Me.pnlLeft.Controls.Add(Me.txtObHistory)
        Me.pnlLeft.Controls.Add(Me.lblG)
        Me.pnlLeft.Controls.Add(Me.lblGp)
        Me.pnlLeft.Controls.Add(Me.lblObHistory)
        Me.pnlLeft.Controls.Add(Me.txtSurgHistory)
        Me.pnlLeft.Controls.Add(Me.txtMedHistory)
        Me.pnlLeft.Controls.Add(Me.lblSurgHistory)
        Me.pnlLeft.Controls.Add(Me.lblMedHistory)
        Me.pnlLeft.Controls.Add(Me.lblEmer)
        Me.pnlLeft.Controls.Add(Me.txtEmgContactAddress)
        Me.pnlLeft.Controls.Add(Me.lblEmgContactAddress)
        Me.pnlLeft.Controls.Add(Me.txtEmgContactNumber)
        Me.pnlLeft.Controls.Add(Me.lblEmgContactNumber)
        Me.pnlLeft.Controls.Add(Me.txtEmgContactName)
        Me.pnlLeft.Controls.Add(Me.lblEmgContactName)
        Me.pnlLeft.Controls.Add(Me.lblPersonalInfo)
        Me.pnlLeft.Controls.Add(Me.txtAllergies)
        Me.pnlLeft.Controls.Add(Me.lblAllergies)
        Me.pnlLeft.Controls.Add(Me.txtBloodType)
        Me.pnlLeft.Controls.Add(Me.lblBloodType)
        Me.pnlLeft.Controls.Add(Me.txtLocalAddress)
        Me.pnlLeft.Controls.Add(Me.lblLocalAddress)
        Me.pnlLeft.Controls.Add(Me.txtContactNumber)
        Me.pnlLeft.Controls.Add(Me.lblContactNumber)
        Me.pnlLeft.Controls.Add(Me.txtCivilStatus)
        Me.pnlLeft.Controls.Add(Me.lblCivilStatus)
        Me.pnlLeft.Controls.Add(Me.txtAge)
        Me.pnlLeft.Controls.Add(Me.lblAge)
        Me.pnlLeft.Controls.Add(Me.txtGender)
        Me.pnlLeft.Controls.Add(Me.lblGender)
        Me.pnlLeft.Controls.Add(Me.txtEmploymentStatus)
        Me.pnlLeft.Controls.Add(Me.lblEmploymentStatus)
        Me.pnlLeft.Controls.Add(Me.txtPosition)
        Me.pnlLeft.Controls.Add(Me.lblPosition)
        Me.pnlLeft.Controls.Add(Me.txtSection)
        Me.pnlLeft.Controls.Add(Me.lblSection)
        Me.pnlLeft.Controls.Add(Me.txtDepartment)
        Me.pnlLeft.Controls.Add(Me.lblDepartment)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(330, 699)
        Me.pnlLeft.TabIndex = 656
        '
        'txtG
        '
        Me.txtG.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtG.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtG.ForeColor = System.Drawing.Color.Black
        Me.txtG.Location = New System.Drawing.Point(111, 546)
        Me.txtG.Name = "txtG"
        Me.txtG.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtG.Size = New System.Drawing.Size(200, 23)
        Me.txtG.TabIndex = 708
        Me.txtG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGp
        '
        Me.txtGp.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtGp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGp.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtGp.ForeColor = System.Drawing.Color.Black
        Me.txtGp.Location = New System.Drawing.Point(111, 521)
        Me.txtGp.Name = "txtGp"
        Me.txtGp.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtGp.Size = New System.Drawing.Size(200, 23)
        Me.txtGp.TabIndex = 707
        Me.txtGp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObHistory
        '
        Me.txtObHistory.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtObHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObHistory.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtObHistory.ForeColor = System.Drawing.Color.Black
        Me.txtObHistory.Location = New System.Drawing.Point(111, 402)
        Me.txtObHistory.Name = "txtObHistory"
        Me.txtObHistory.Padding = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.txtObHistory.Size = New System.Drawing.Size(200, 117)
        Me.txtObHistory.TabIndex = 706
        Me.txtObHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblG
        '
        Me.lblG.BackColor = System.Drawing.SystemColors.Control
        Me.lblG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblG.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblG.ForeColor = System.Drawing.Color.Black
        Me.lblG.Location = New System.Drawing.Point(2, 546)
        Me.lblG.Name = "lblG"
        Me.lblG.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblG.Size = New System.Drawing.Size(110, 23)
        Me.lblG.TabIndex = 705
        Me.lblG.Text = "G1; G2"
        Me.lblG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGp
        '
        Me.lblGp.BackColor = System.Drawing.SystemColors.Control
        Me.lblGp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGp.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblGp.ForeColor = System.Drawing.Color.Black
        Me.lblGp.Location = New System.Drawing.Point(2, 521)
        Me.lblGp.Name = "lblGp"
        Me.lblGp.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblGp.Size = New System.Drawing.Size(110, 23)
        Me.lblGp.TabIndex = 704
        Me.lblGp.Text = "G; P"
        Me.lblGp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblObHistory
        '
        Me.lblObHistory.BackColor = System.Drawing.SystemColors.Control
        Me.lblObHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblObHistory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObHistory.ForeColor = System.Drawing.Color.Black
        Me.lblObHistory.Location = New System.Drawing.Point(2, 402)
        Me.lblObHistory.Name = "lblObHistory"
        Me.lblObHistory.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblObHistory.Size = New System.Drawing.Size(110, 117)
        Me.lblObHistory.TabIndex = 703
        Me.lblObHistory.Text = "OB History" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Menarche" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Interval" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Duration" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Amount" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Symptoms"
        Me.lblObHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSurgHistory
        '
        Me.txtSurgHistory.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtSurgHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSurgHistory.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtSurgHistory.ForeColor = System.Drawing.Color.Black
        Me.txtSurgHistory.Location = New System.Drawing.Point(111, 365)
        Me.txtSurgHistory.Name = "txtSurgHistory"
        Me.txtSurgHistory.Padding = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.txtSurgHistory.Size = New System.Drawing.Size(200, 35)
        Me.txtSurgHistory.TabIndex = 702
        Me.txtSurgHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMedHistory
        '
        Me.txtMedHistory.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtMedHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMedHistory.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtMedHistory.ForeColor = System.Drawing.Color.Black
        Me.txtMedHistory.Location = New System.Drawing.Point(111, 328)
        Me.txtMedHistory.Name = "txtMedHistory"
        Me.txtMedHistory.Padding = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.txtMedHistory.Size = New System.Drawing.Size(200, 35)
        Me.txtMedHistory.TabIndex = 701
        Me.txtMedHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSurgHistory
        '
        Me.lblSurgHistory.BackColor = System.Drawing.SystemColors.Control
        Me.lblSurgHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSurgHistory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSurgHistory.ForeColor = System.Drawing.Color.Black
        Me.lblSurgHistory.Location = New System.Drawing.Point(2, 365)
        Me.lblSurgHistory.Name = "lblSurgHistory"
        Me.lblSurgHistory.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblSurgHistory.Size = New System.Drawing.Size(110, 35)
        Me.lblSurgHistory.TabIndex = 700
        Me.lblSurgHistory.Text = "Surgical History"
        Me.lblSurgHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMedHistory
        '
        Me.lblMedHistory.BackColor = System.Drawing.SystemColors.Control
        Me.lblMedHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMedHistory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedHistory.ForeColor = System.Drawing.Color.Black
        Me.lblMedHistory.Location = New System.Drawing.Point(2, 328)
        Me.lblMedHistory.Name = "lblMedHistory"
        Me.lblMedHistory.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblMedHistory.Size = New System.Drawing.Size(110, 35)
        Me.lblMedHistory.TabIndex = 699
        Me.lblMedHistory.Text = "Past Medical History"
        Me.lblMedHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmer
        '
        Me.lblEmer.BackColor = System.Drawing.Color.DarkSlateGray
        Me.lblEmer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmer.ForeColor = System.Drawing.Color.White
        Me.lblEmer.Location = New System.Drawing.Point(2, 571)
        Me.lblEmer.Name = "lblEmer"
        Me.lblEmer.Size = New System.Drawing.Size(309, 22)
        Me.lblEmer.TabIndex = 697
        Me.lblEmer.Text = "Emergency Contact Reference"
        Me.lblEmer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtEmgContactAddress
        '
        Me.txtEmgContactAddress.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtEmgContactAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmgContactAddress.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtEmgContactAddress.ForeColor = System.Drawing.Color.Black
        Me.txtEmgContactAddress.Location = New System.Drawing.Point(111, 645)
        Me.txtEmgContactAddress.Name = "txtEmgContactAddress"
        Me.txtEmgContactAddress.Padding = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.txtEmgContactAddress.Size = New System.Drawing.Size(200, 49)
        Me.txtEmgContactAddress.TabIndex = 696
        Me.txtEmgContactAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmgContactAddress
        '
        Me.lblEmgContactAddress.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmgContactAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmgContactAddress.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblEmgContactAddress.ForeColor = System.Drawing.Color.Black
        Me.lblEmgContactAddress.Location = New System.Drawing.Point(2, 645)
        Me.lblEmgContactAddress.Name = "lblEmgContactAddress"
        Me.lblEmgContactAddress.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmgContactAddress.Size = New System.Drawing.Size(110, 49)
        Me.lblEmgContactAddress.TabIndex = 695
        Me.lblEmgContactAddress.Text = "Address"
        Me.lblEmgContactAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmgContactNumber
        '
        Me.txtEmgContactNumber.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtEmgContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmgContactNumber.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtEmgContactNumber.ForeColor = System.Drawing.Color.Black
        Me.txtEmgContactNumber.Location = New System.Drawing.Point(111, 620)
        Me.txtEmgContactNumber.Name = "txtEmgContactNumber"
        Me.txtEmgContactNumber.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtEmgContactNumber.Size = New System.Drawing.Size(200, 23)
        Me.txtEmgContactNumber.TabIndex = 694
        Me.txtEmgContactNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmgContactNumber
        '
        Me.lblEmgContactNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmgContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmgContactNumber.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblEmgContactNumber.ForeColor = System.Drawing.Color.Black
        Me.lblEmgContactNumber.Location = New System.Drawing.Point(2, 620)
        Me.lblEmgContactNumber.Name = "lblEmgContactNumber"
        Me.lblEmgContactNumber.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmgContactNumber.Size = New System.Drawing.Size(110, 23)
        Me.lblEmgContactNumber.TabIndex = 693
        Me.lblEmgContactNumber.Text = "Contact Number"
        Me.lblEmgContactNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmgContactName
        '
        Me.txtEmgContactName.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtEmgContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmgContactName.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtEmgContactName.ForeColor = System.Drawing.Color.Black
        Me.txtEmgContactName.Location = New System.Drawing.Point(111, 595)
        Me.txtEmgContactName.Name = "txtEmgContactName"
        Me.txtEmgContactName.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtEmgContactName.Size = New System.Drawing.Size(200, 23)
        Me.txtEmgContactName.TabIndex = 692
        Me.txtEmgContactName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmgContactName
        '
        Me.lblEmgContactName.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmgContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmgContactName.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblEmgContactName.ForeColor = System.Drawing.Color.Black
        Me.lblEmgContactName.Location = New System.Drawing.Point(2, 595)
        Me.lblEmgContactName.Name = "lblEmgContactName"
        Me.lblEmgContactName.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmgContactName.Size = New System.Drawing.Size(110, 23)
        Me.lblEmgContactName.TabIndex = 691
        Me.lblEmgContactName.Text = "Name"
        Me.lblEmgContactName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPersonalInfo
        '
        Me.lblPersonalInfo.BackColor = System.Drawing.Color.DarkSlateGray
        Me.lblPersonalInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPersonalInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonalInfo.ForeColor = System.Drawing.Color.White
        Me.lblPersonalInfo.Location = New System.Drawing.Point(2, 5)
        Me.lblPersonalInfo.Name = "lblPersonalInfo"
        Me.lblPersonalInfo.Size = New System.Drawing.Size(309, 22)
        Me.lblPersonalInfo.TabIndex = 698
        Me.lblPersonalInfo.Text = "Personal Information"
        Me.lblPersonalInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtAllergies
        '
        Me.txtAllergies.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtAllergies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAllergies.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtAllergies.ForeColor = System.Drawing.Color.Black
        Me.txtAllergies.Location = New System.Drawing.Point(111, 291)
        Me.txtAllergies.Name = "txtAllergies"
        Me.txtAllergies.Padding = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.txtAllergies.Size = New System.Drawing.Size(200, 35)
        Me.txtAllergies.TabIndex = 690
        Me.txtAllergies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAllergies
        '
        Me.lblAllergies.BackColor = System.Drawing.SystemColors.Control
        Me.lblAllergies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAllergies.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblAllergies.ForeColor = System.Drawing.Color.Black
        Me.lblAllergies.Location = New System.Drawing.Point(2, 291)
        Me.lblAllergies.Name = "lblAllergies"
        Me.lblAllergies.Padding = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.lblAllergies.Size = New System.Drawing.Size(110, 35)
        Me.lblAllergies.TabIndex = 689
        Me.lblAllergies.Text = "Allergies"
        Me.lblAllergies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBloodType
        '
        Me.txtBloodType.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtBloodType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBloodType.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtBloodType.ForeColor = System.Drawing.Color.Black
        Me.txtBloodType.Location = New System.Drawing.Point(111, 266)
        Me.txtBloodType.Name = "txtBloodType"
        Me.txtBloodType.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtBloodType.Size = New System.Drawing.Size(200, 23)
        Me.txtBloodType.TabIndex = 688
        Me.txtBloodType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBloodType
        '
        Me.lblBloodType.BackColor = System.Drawing.SystemColors.Control
        Me.lblBloodType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBloodType.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblBloodType.ForeColor = System.Drawing.Color.Black
        Me.lblBloodType.Location = New System.Drawing.Point(2, 266)
        Me.lblBloodType.Name = "lblBloodType"
        Me.lblBloodType.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblBloodType.Size = New System.Drawing.Size(110, 23)
        Me.lblBloodType.TabIndex = 687
        Me.lblBloodType.Text = "Blood Type"
        Me.lblBloodType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLocalAddress
        '
        Me.txtLocalAddress.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtLocalAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocalAddress.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtLocalAddress.ForeColor = System.Drawing.Color.Black
        Me.txtLocalAddress.Location = New System.Drawing.Point(111, 229)
        Me.txtLocalAddress.Name = "txtLocalAddress"
        Me.txtLocalAddress.Padding = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.txtLocalAddress.Size = New System.Drawing.Size(200, 35)
        Me.txtLocalAddress.TabIndex = 686
        Me.txtLocalAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLocalAddress
        '
        Me.lblLocalAddress.BackColor = System.Drawing.SystemColors.Control
        Me.lblLocalAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLocalAddress.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblLocalAddress.ForeColor = System.Drawing.Color.Black
        Me.lblLocalAddress.Location = New System.Drawing.Point(2, 229)
        Me.lblLocalAddress.Name = "lblLocalAddress"
        Me.lblLocalAddress.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblLocalAddress.Size = New System.Drawing.Size(110, 35)
        Me.lblLocalAddress.TabIndex = 685
        Me.lblLocalAddress.Text = "Local Address"
        Me.lblLocalAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContactNumber
        '
        Me.txtContactNumber.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactNumber.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtContactNumber.ForeColor = System.Drawing.Color.Black
        Me.txtContactNumber.Location = New System.Drawing.Point(111, 204)
        Me.txtContactNumber.Name = "txtContactNumber"
        Me.txtContactNumber.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtContactNumber.Size = New System.Drawing.Size(200, 23)
        Me.txtContactNumber.TabIndex = 684
        Me.txtContactNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblContactNumber
        '
        Me.lblContactNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblContactNumber.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblContactNumber.ForeColor = System.Drawing.Color.Black
        Me.lblContactNumber.Location = New System.Drawing.Point(2, 204)
        Me.lblContactNumber.Name = "lblContactNumber"
        Me.lblContactNumber.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblContactNumber.Size = New System.Drawing.Size(110, 23)
        Me.lblContactNumber.TabIndex = 683
        Me.lblContactNumber.Text = "Contact Number"
        Me.lblContactNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCivilStatus
        '
        Me.txtCivilStatus.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCivilStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCivilStatus.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtCivilStatus.ForeColor = System.Drawing.Color.Black
        Me.txtCivilStatus.Location = New System.Drawing.Point(111, 179)
        Me.txtCivilStatus.Name = "txtCivilStatus"
        Me.txtCivilStatus.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtCivilStatus.Size = New System.Drawing.Size(200, 23)
        Me.txtCivilStatus.TabIndex = 682
        Me.txtCivilStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCivilStatus
        '
        Me.lblCivilStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblCivilStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCivilStatus.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblCivilStatus.ForeColor = System.Drawing.Color.Black
        Me.lblCivilStatus.Location = New System.Drawing.Point(2, 179)
        Me.lblCivilStatus.Name = "lblCivilStatus"
        Me.lblCivilStatus.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblCivilStatus.Size = New System.Drawing.Size(110, 23)
        Me.lblCivilStatus.TabIndex = 681
        Me.lblCivilStatus.Text = "Civil Status"
        Me.lblCivilStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAge
        '
        Me.txtAge.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAge.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtAge.ForeColor = System.Drawing.Color.Black
        Me.txtAge.Location = New System.Drawing.Point(111, 154)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtAge.Size = New System.Drawing.Size(200, 23)
        Me.txtAge.TabIndex = 680
        Me.txtAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAge
        '
        Me.lblAge.BackColor = System.Drawing.SystemColors.Control
        Me.lblAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAge.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblAge.ForeColor = System.Drawing.Color.Black
        Me.lblAge.Location = New System.Drawing.Point(2, 154)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblAge.Size = New System.Drawing.Size(110, 23)
        Me.lblAge.TabIndex = 679
        Me.lblAge.Text = "Age"
        Me.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGender
        '
        Me.txtGender.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGender.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtGender.ForeColor = System.Drawing.Color.Black
        Me.txtGender.Location = New System.Drawing.Point(111, 129)
        Me.txtGender.Name = "txtGender"
        Me.txtGender.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtGender.Size = New System.Drawing.Size(200, 23)
        Me.txtGender.TabIndex = 678
        Me.txtGender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGender
        '
        Me.lblGender.BackColor = System.Drawing.SystemColors.Control
        Me.lblGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGender.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblGender.ForeColor = System.Drawing.Color.Black
        Me.lblGender.Location = New System.Drawing.Point(2, 129)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblGender.Size = New System.Drawing.Size(110, 23)
        Me.lblGender.TabIndex = 677
        Me.lblGender.Text = "Gender"
        Me.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmploymentStatus
        '
        Me.txtEmploymentStatus.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtEmploymentStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmploymentStatus.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtEmploymentStatus.ForeColor = System.Drawing.Color.Black
        Me.txtEmploymentStatus.Location = New System.Drawing.Point(111, 104)
        Me.txtEmploymentStatus.Name = "txtEmploymentStatus"
        Me.txtEmploymentStatus.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtEmploymentStatus.Size = New System.Drawing.Size(200, 23)
        Me.txtEmploymentStatus.TabIndex = 676
        Me.txtEmploymentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmploymentStatus
        '
        Me.lblEmploymentStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmploymentStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmploymentStatus.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblEmploymentStatus.ForeColor = System.Drawing.Color.Black
        Me.lblEmploymentStatus.Location = New System.Drawing.Point(2, 104)
        Me.lblEmploymentStatus.Name = "lblEmploymentStatus"
        Me.lblEmploymentStatus.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmploymentStatus.Size = New System.Drawing.Size(110, 23)
        Me.lblEmploymentStatus.TabIndex = 675
        Me.lblEmploymentStatus.Text = "Emp. Status"
        Me.lblEmploymentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPosition
        '
        Me.txtPosition.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPosition.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtPosition.ForeColor = System.Drawing.Color.Black
        Me.txtPosition.Location = New System.Drawing.Point(111, 79)
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtPosition.Size = New System.Drawing.Size(200, 23)
        Me.txtPosition.TabIndex = 674
        Me.txtPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPosition
        '
        Me.lblPosition.BackColor = System.Drawing.SystemColors.Control
        Me.lblPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPosition.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblPosition.ForeColor = System.Drawing.Color.Black
        Me.lblPosition.Location = New System.Drawing.Point(2, 79)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblPosition.Size = New System.Drawing.Size(110, 23)
        Me.lblPosition.TabIndex = 673
        Me.lblPosition.Text = "Position"
        Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSection
        '
        Me.txtSection.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtSection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSection.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtSection.ForeColor = System.Drawing.Color.Black
        Me.txtSection.Location = New System.Drawing.Point(111, 54)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtSection.Size = New System.Drawing.Size(200, 23)
        Me.txtSection.TabIndex = 672
        Me.txtSection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSection
        '
        Me.lblSection.BackColor = System.Drawing.SystemColors.Control
        Me.lblSection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSection.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblSection.ForeColor = System.Drawing.Color.Black
        Me.lblSection.Location = New System.Drawing.Point(2, 54)
        Me.lblSection.Name = "lblSection"
        Me.lblSection.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblSection.Size = New System.Drawing.Size(110, 23)
        Me.lblSection.TabIndex = 671
        Me.lblSection.Text = "Section"
        Me.lblSection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDepartment
        '
        Me.txtDepartment.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepartment.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtDepartment.ForeColor = System.Drawing.Color.Black
        Me.txtDepartment.Location = New System.Drawing.Point(111, 29)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtDepartment.Size = New System.Drawing.Size(200, 23)
        Me.txtDepartment.TabIndex = 670
        Me.txtDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDepartment
        '
        Me.lblDepartment.BackColor = System.Drawing.SystemColors.Control
        Me.lblDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDepartment.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblDepartment.ForeColor = System.Drawing.Color.Black
        Me.lblDepartment.Location = New System.Drawing.Point(2, 29)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblDepartment.Size = New System.Drawing.Size(110, 23)
        Me.lblDepartment.TabIndex = 669
        Me.lblDepartment.Text = "Department"
        Me.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQty
        '
        Me.txtQty.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtQty.ForeColor = System.Drawing.Color.Black
        Me.txtQty.Location = New System.Drawing.Point(439, 253)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtQty.Size = New System.Drawing.Size(270, 23)
        Me.txtQty.TabIndex = 657
        Me.txtQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ConsultationScreening
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(714, 699)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.pnlLeft)
        Me.Controls.Add(Me.lblLeaveType)
        Me.Controls.Add(Me.cmbLeaveType)
        Me.Controls.Add(Me.txtEndDate)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.txtStartDate)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.lblConsultation)
        Me.Controls.Add(Me.lblEmployeeName)
        Me.Controls.Add(Me.lblEmployeeCode)
        Me.Controls.Add(Me.txtEmployeeCode)
        Me.Controls.Add(Me.lblQty)
        Me.Controls.Add(Me.txtModifiedDate)
        Me.Controls.Add(Me.lblModifiedDate)
        Me.Controls.Add(Me.txtModifiedBy)
        Me.Controls.Add(Me.lblModifiedBy)
        Me.Controls.Add(Me.txtCreatedDate)
        Me.Controls.Add(Me.lblCreatedDate)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtCreatedBy)
        Me.Controls.Add(Me.lblCreatedBy)
        Me.Controls.Add(Me.chkSentHome)
        Me.Controls.Add(Me.lblSentHome)
        Me.Controls.Add(Me.chkFitToWork)
        Me.Controls.Add(Me.lblFitToWork)
        Me.Controls.Add(Me.txtMedCertDate)
        Me.Controls.Add(Me.txtDiagnosis)
        Me.Controls.Add(Me.lblDiagnosis)
        Me.Controls.Add(Me.txtChiefComplaint)
        Me.Controls.Add(Me.lblChiefComplaint)
        Me.Controls.Add(Me.lblMedCertDate)
        Me.Controls.Add(Me.txtEmployeeName)
        Me.Controls.Add(Me.txtEmployeeNameAgency)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConsultationScreening"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.pnlLeft.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMedCertDate As System.Windows.Forms.Label
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents txtChiefComplaint As System.Windows.Forms.TextBox
    Friend WithEvents lblChiefComplaint As System.Windows.Forms.Label
    Friend WithEvents txtDiagnosis As System.Windows.Forms.TextBox
    Friend WithEvents lblDiagnosis As System.Windows.Forms.Label
    Friend WithEvents txtMedCertDate As System.Windows.Forms.MaskedTextBox
    Friend WithEvents chkFitToWork As System.Windows.Forms.CheckBox
    Friend WithEvents lblFitToWork As System.Windows.Forms.Label
    Friend WithEvents chkSentHome As System.Windows.Forms.CheckBox
    Friend WithEvents lblSentHome As System.Windows.Forms.Label
    Friend WithEvents txtCreatedBy As System.Windows.Forms.Label
    Friend WithEvents lblCreatedBy As System.Windows.Forms.Label
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents ofdRecDetail As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtModifiedBy As Label
    Friend WithEvents lblModifiedBy As Label
    Friend WithEvents txtCreatedDate As Label
    Friend WithEvents lblCreatedDate As Label
    Friend WithEvents txtModifiedDate As Label
    Friend WithEvents lblModifiedDate As Label
    Friend WithEvents lblEmployeeCode As Label
    Friend WithEvents txtEmployeeCode As TextBox
    Friend WithEvents txtEmployeeName As Label
    Friend WithEvents lblEmployeeName As Label
    Friend WithEvents lblConsultation As Label
    Friend WithEvents txtStartDate As MaskedTextBox
    Friend WithEvents lblStartDate As Label
    Friend WithEvents txtEndDate As MaskedTextBox
    Friend WithEvents lblEndDate As Label
    Friend WithEvents lblLeaveType As Label
    Friend WithEvents cmbLeaveType As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtEmployeeNameAgency As TextBox
    Friend WithEvents pnlLeft As Panel
    Friend WithEvents txtG As Label
    Friend WithEvents txtGp As Label
    Friend WithEvents txtObHistory As Label
    Friend WithEvents lblG As Label
    Friend WithEvents lblGp As Label
    Friend WithEvents lblObHistory As Label
    Friend WithEvents txtSurgHistory As Label
    Friend WithEvents txtMedHistory As Label
    Friend WithEvents lblSurgHistory As Label
    Friend WithEvents lblMedHistory As Label
    Friend WithEvents lblEmer As Label
    Friend WithEvents txtEmgContactAddress As Label
    Friend WithEvents lblEmgContactAddress As Label
    Friend WithEvents txtEmgContactNumber As Label
    Friend WithEvents lblEmgContactNumber As Label
    Friend WithEvents txtEmgContactName As Label
    Friend WithEvents lblEmgContactName As Label
    Friend WithEvents lblPersonalInfo As Label
    Friend WithEvents txtAllergies As Label
    Friend WithEvents lblAllergies As Label
    Friend WithEvents txtBloodType As Label
    Friend WithEvents lblBloodType As Label
    Friend WithEvents txtLocalAddress As Label
    Friend WithEvents lblLocalAddress As Label
    Friend WithEvents txtContactNumber As Label
    Friend WithEvents lblContactNumber As Label
    Friend WithEvents txtCivilStatus As Label
    Friend WithEvents lblCivilStatus As Label
    Friend WithEvents txtAge As Label
    Friend WithEvents lblAge As Label
    Friend WithEvents txtGender As Label
    Friend WithEvents lblGender As Label
    Friend WithEvents txtEmploymentStatus As Label
    Friend WithEvents lblEmploymentStatus As Label
    Friend WithEvents txtPosition As Label
    Friend WithEvents lblPosition As Label
    Friend WithEvents txtSection As Label
    Friend WithEvents lblSection As Label
    Friend WithEvents txtDepartment As Label
    Friend WithEvents lblDepartment As Label
    Friend WithEvents txtQty As Label
End Class
