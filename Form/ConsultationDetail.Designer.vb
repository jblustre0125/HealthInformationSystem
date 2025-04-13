<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConsultationDetail
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultationDetail))
        Me.lblLmp = New System.Windows.Forms.Label()
        Me.lblTemperature = New System.Windows.Forms.Label()
        Me.lblBloodPressure = New System.Windows.Forms.Label()
        Me.lblRespiratoryRate = New System.Windows.Forms.Label()
        Me.lblPulseRate = New System.Windows.Forms.Label()
        Me.txtTemperature = New System.Windows.Forms.TextBox()
        Me.txtBloodPressure = New System.Windows.Forms.TextBox()
        Me.txtPulseRate = New System.Windows.Forms.TextBox()
        Me.txtRespiratoryRate = New System.Windows.Forms.TextBox()
        Me.txtChiefComplaint = New System.Windows.Forms.TextBox()
        Me.lblChiefComplaint = New System.Windows.Forms.Label()
        Me.txtDiagnosis = New System.Windows.Forms.TextBox()
        Me.lblDiagnosis = New System.Windows.Forms.Label()
        Me.txtLmp = New System.Windows.Forms.MaskedTextBox()
        Me.txtOxygenLevel = New System.Windows.Forms.TextBox()
        Me.lblOxygenLevel = New System.Windows.Forms.Label()
        Me.chkFitToWork = New System.Windows.Forms.CheckBox()
        Me.lblFitToWork = New System.Windows.Forms.Label()
        Me.chkSentHome = New System.Windows.Forms.CheckBox()
        Me.lblSentHome = New System.Windows.Forms.Label()
        Me.pnlAttachment = New System.Windows.Forms.Panel()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.pbAttachment = New System.Windows.Forms.ProgressBar()
        Me.btnView = New PinkieControls.ButtonXP()
        Me.txtFilename = New System.Windows.Forms.Label()
        Me.btnNext = New PinkieControls.ButtonXP()
        Me.btnPrevious = New PinkieControls.ButtonXP()
        Me.btnRemove = New PinkieControls.ButtonXP()
        Me.btnBrowse = New PinkieControls.ButtonXP()
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.txtCreatedBy = New System.Windows.Forms.Label()
        Me.lblCreatedBy = New System.Windows.Forms.Label()
        Me.lblAttachmentCount = New System.Windows.Forms.Label()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.ofdRecDetail = New System.Windows.Forms.OpenFileDialog()
        Me.txtHpi = New System.Windows.Forms.TextBox()
        Me.lblHpi = New System.Windows.Forms.Label()
        Me.txtPlan = New System.Windows.Forms.TextBox()
        Me.lblPlan = New System.Windows.Forms.Label()
        Me.txtModifiedBy = New System.Windows.Forms.Label()
        Me.lblModifiedBy = New System.Windows.Forms.Label()
        Me.txtCreatedDate = New System.Windows.Forms.Label()
        Me.lblCreatedDate = New System.Windows.Forms.Label()
        Me.txtModifiedDate = New System.Windows.Forms.Label()
        Me.lblModifiedDate = New System.Windows.Forms.Label()
        Me.chkTeleconsult = New System.Windows.Forms.CheckBox()
        Me.lblTeleconsult = New System.Windows.Forms.Label()
        Me.bgWorker = New System.ComponentModel.BackgroundWorker()
        Me.lblEmployeeCode = New System.Windows.Forms.Label()
        Me.txtEmployeeCode = New System.Windows.Forms.TextBox()
        Me.txtEmployeeName = New System.Windows.Forms.Label()
        Me.lblEmployeeName = New System.Windows.Forms.Label()
        Me.lblAgencyName = New System.Windows.Forms.Label()
        Me.lblConsultation = New System.Windows.Forms.Label()
        Me.txtTimeIn = New System.Windows.Forms.MaskedTextBox()
        Me.lblTimeIn = New System.Windows.Forms.Label()
        Me.txtTimeOut = New System.Windows.Forms.MaskedTextBox()
        Me.lblTimeOut = New System.Windows.Forms.Label()
        Me.chkRest = New System.Windows.Forms.CheckBox()
        Me.lblRest = New System.Windows.Forms.Label()
        Me.lblRestMinutes = New System.Windows.Forms.Label()
        Me.txtRestMinutes = New System.Windows.Forms.TextBox()
        Me.lblRoom = New System.Windows.Forms.Label()
        Me.cmbRoom = New SergeUtils.EasyCompletionComboBox()
        Me.lblBed = New System.Windows.Forms.Label()
        Me.cmbBed = New SergeUtils.EasyCompletionComboBox()
        Me.dgvDetail = New System.Windows.Forms.DataGridView()
        Me.ColTrxId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMedicineId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStockOut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColEndingBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblMedicine = New System.Windows.Forms.Label()
        Me.cmbMedicine = New SergeUtils.EasyCompletionComboBox()
        Me.lblMedQty = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.btnRemoveRow = New PinkieControls.ButtonXP()
        Me.btnAddRow = New PinkieControls.ButtonXP()
        Me.lblMedicineCount = New System.Windows.Forms.Label()
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.cmbAgency = New SergeUtils.EasyCompletionComboBox()
        Me.txtEmployeeNameAgency = New System.Windows.Forms.TextBox()
        Me.btnManualOut = New PinkieControls.ButtonXP()
        Me.lblStock = New System.Windows.Forms.Label()
        Me.txtStock = New System.Windows.Forms.Label()
        Me.txtUnitName = New System.Windows.Forms.Label()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.AxAcroPDF = New AxAcroPDFLib.AxAcroPDF()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.txtDepartment = New System.Windows.Forms.Label()
        Me.lblSection = New System.Windows.Forms.Label()
        Me.txtSection = New System.Windows.Forms.Label()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.txtPosition = New System.Windows.Forms.Label()
        Me.lblEmploymentStatus = New System.Windows.Forms.Label()
        Me.txtEmploymentStatus = New System.Windows.Forms.Label()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.txtGender = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.txtAge = New System.Windows.Forms.Label()
        Me.lblCivilStatus = New System.Windows.Forms.Label()
        Me.txtCivilStatus = New System.Windows.Forms.Label()
        Me.lblContactNumber = New System.Windows.Forms.Label()
        Me.txtContactNumber = New System.Windows.Forms.Label()
        Me.lblLocalAddress = New System.Windows.Forms.Label()
        Me.txtLocalAddress = New System.Windows.Forms.Label()
        Me.lblBloodType = New System.Windows.Forms.Label()
        Me.txtBloodType = New System.Windows.Forms.Label()
        Me.lblAllergies = New System.Windows.Forms.Label()
        Me.txtAllergies = New System.Windows.Forms.Label()
        Me.lblPersonalInfo = New System.Windows.Forms.Label()
        Me.lblEmgContactName = New System.Windows.Forms.Label()
        Me.txtEmgContactName = New System.Windows.Forms.Label()
        Me.lblEmgContactNumber = New System.Windows.Forms.Label()
        Me.txtEmgContactNumber = New System.Windows.Forms.Label()
        Me.lblEmgContactAddress = New System.Windows.Forms.Label()
        Me.txtEmgContactAddress = New System.Windows.Forms.Label()
        Me.lblEmer = New System.Windows.Forms.Label()
        Me.lblMedHistory = New System.Windows.Forms.Label()
        Me.lblSurgHistory = New System.Windows.Forms.Label()
        Me.txtMedHistory = New System.Windows.Forms.Label()
        Me.txtSurgHistory = New System.Windows.Forms.Label()
        Me.lblObHistory = New System.Windows.Forms.Label()
        Me.lblGp = New System.Windows.Forms.Label()
        Me.lblG = New System.Windows.Forms.Label()
        Me.txtObHistory = New System.Windows.Forms.Label()
        Me.txtGp = New System.Windows.Forms.Label()
        Me.txtG = New System.Windows.Forms.Label()
        Me.txtMaintenance = New System.Windows.Forms.Label()
        Me.lblMaintenance = New System.Windows.Forms.Label()
        Me.pnlAttachment.SuspendLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLeft.SuspendLayout()
        CType(Me.AxAcroPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLmp
        '
        Me.lblLmp.BackColor = System.Drawing.SystemColors.Control
        Me.lblLmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLmp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblLmp.ForeColor = System.Drawing.Color.Black
        Me.lblLmp.Location = New System.Drawing.Point(330, 228)
        Me.lblLmp.Name = "lblLmp"
        Me.lblLmp.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblLmp.Size = New System.Drawing.Size(110, 23)
        Me.lblLmp.TabIndex = 541
        Me.lblLmp.Text = "LMP"
        Me.lblLmp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTemperature
        '
        Me.lblTemperature.BackColor = System.Drawing.SystemColors.Control
        Me.lblTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTemperature.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTemperature.ForeColor = System.Drawing.Color.Black
        Me.lblTemperature.Location = New System.Drawing.Point(330, 253)
        Me.lblTemperature.Name = "lblTemperature"
        Me.lblTemperature.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblTemperature.Size = New System.Drawing.Size(110, 23)
        Me.lblTemperature.TabIndex = 543
        Me.lblTemperature.Text = "Temperature"
        Me.lblTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBloodPressure
        '
        Me.lblBloodPressure.BackColor = System.Drawing.SystemColors.Control
        Me.lblBloodPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBloodPressure.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblBloodPressure.ForeColor = System.Drawing.Color.Black
        Me.lblBloodPressure.Location = New System.Drawing.Point(330, 278)
        Me.lblBloodPressure.Name = "lblBloodPressure"
        Me.lblBloodPressure.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblBloodPressure.Size = New System.Drawing.Size(110, 23)
        Me.lblBloodPressure.TabIndex = 545
        Me.lblBloodPressure.Text = "Blood Pressure"
        Me.lblBloodPressure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRespiratoryRate
        '
        Me.lblRespiratoryRate.BackColor = System.Drawing.SystemColors.Control
        Me.lblRespiratoryRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRespiratoryRate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRespiratoryRate.ForeColor = System.Drawing.Color.Black
        Me.lblRespiratoryRate.Location = New System.Drawing.Point(330, 353)
        Me.lblRespiratoryRate.Name = "lblRespiratoryRate"
        Me.lblRespiratoryRate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblRespiratoryRate.Size = New System.Drawing.Size(110, 23)
        Me.lblRespiratoryRate.TabIndex = 549
        Me.lblRespiratoryRate.Text = "Respiratory Rate"
        Me.lblRespiratoryRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPulseRate
        '
        Me.lblPulseRate.BackColor = System.Drawing.SystemColors.Control
        Me.lblPulseRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPulseRate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPulseRate.ForeColor = System.Drawing.Color.Black
        Me.lblPulseRate.Location = New System.Drawing.Point(330, 328)
        Me.lblPulseRate.Name = "lblPulseRate"
        Me.lblPulseRate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblPulseRate.Size = New System.Drawing.Size(110, 23)
        Me.lblPulseRate.TabIndex = 547
        Me.lblPulseRate.Text = "Pulse Rate"
        Me.lblPulseRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTemperature
        '
        Me.txtTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTemperature.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTemperature.Location = New System.Drawing.Point(439, 253)
        Me.txtTemperature.Name = "txtTemperature"
        Me.txtTemperature.Size = New System.Drawing.Size(230, 23)
        Me.txtTemperature.TabIndex = 6
        '
        'txtBloodPressure
        '
        Me.txtBloodPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBloodPressure.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtBloodPressure.Location = New System.Drawing.Point(439, 278)
        Me.txtBloodPressure.Name = "txtBloodPressure"
        Me.txtBloodPressure.Size = New System.Drawing.Size(230, 23)
        Me.txtBloodPressure.TabIndex = 7
        '
        'txtPulseRate
        '
        Me.txtPulseRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPulseRate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPulseRate.Location = New System.Drawing.Point(439, 328)
        Me.txtPulseRate.Name = "txtPulseRate"
        Me.txtPulseRate.Size = New System.Drawing.Size(230, 23)
        Me.txtPulseRate.TabIndex = 9
        '
        'txtRespiratoryRate
        '
        Me.txtRespiratoryRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRespiratoryRate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRespiratoryRate.Location = New System.Drawing.Point(439, 353)
        Me.txtRespiratoryRate.Name = "txtRespiratoryRate"
        Me.txtRespiratoryRate.Size = New System.Drawing.Size(230, 23)
        Me.txtRespiratoryRate.TabIndex = 10
        '
        'txtChiefComplaint
        '
        Me.txtChiefComplaint.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtChiefComplaint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChiefComplaint.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtChiefComplaint.Location = New System.Drawing.Point(974, 51)
        Me.txtChiefComplaint.Multiline = True
        Me.txtChiefComplaint.Name = "txtChiefComplaint"
        Me.txtChiefComplaint.Size = New System.Drawing.Size(356, 135)
        Me.txtChiefComplaint.TabIndex = 20
        '
        'lblChiefComplaint
        '
        Me.lblChiefComplaint.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblChiefComplaint.BackColor = System.Drawing.SystemColors.Control
        Me.lblChiefComplaint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChiefComplaint.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblChiefComplaint.ForeColor = System.Drawing.Color.Black
        Me.lblChiefComplaint.Location = New System.Drawing.Point(974, 28)
        Me.lblChiefComplaint.Name = "lblChiefComplaint"
        Me.lblChiefComplaint.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblChiefComplaint.Size = New System.Drawing.Size(356, 24)
        Me.lblChiefComplaint.TabIndex = 551
        Me.lblChiefComplaint.Text = "Chief Complaint"
        Me.lblChiefComplaint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDiagnosis
        '
        Me.txtDiagnosis.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiagnosis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDiagnosis.Location = New System.Drawing.Point(974, 212)
        Me.txtDiagnosis.Multiline = True
        Me.txtDiagnosis.Name = "txtDiagnosis"
        Me.txtDiagnosis.Size = New System.Drawing.Size(356, 135)
        Me.txtDiagnosis.TabIndex = 21
        '
        'lblDiagnosis
        '
        Me.lblDiagnosis.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDiagnosis.BackColor = System.Drawing.SystemColors.Control
        Me.lblDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDiagnosis.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDiagnosis.ForeColor = System.Drawing.Color.Black
        Me.lblDiagnosis.Location = New System.Drawing.Point(974, 188)
        Me.lblDiagnosis.Name = "lblDiagnosis"
        Me.lblDiagnosis.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblDiagnosis.Size = New System.Drawing.Size(356, 25)
        Me.lblDiagnosis.TabIndex = 557
        Me.lblDiagnosis.Text = "Diagnosis"
        Me.lblDiagnosis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLmp
        '
        Me.txtLmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLmp.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtLmp.Location = New System.Drawing.Point(439, 228)
        Me.txtLmp.Mask = "00/00/0000"
        Me.txtLmp.Name = "txtLmp"
        Me.txtLmp.PromptChar = Global.Microsoft.VisualBasic.ChrW(45)
        Me.txtLmp.Size = New System.Drawing.Size(230, 23)
        Me.txtLmp.TabIndex = 5
        Me.txtLmp.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtLmp.ValidatingType = GetType(Date)
        '
        'txtOxygenLevel
        '
        Me.txtOxygenLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOxygenLevel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtOxygenLevel.Location = New System.Drawing.Point(439, 303)
        Me.txtOxygenLevel.Name = "txtOxygenLevel"
        Me.txtOxygenLevel.Size = New System.Drawing.Size(230, 23)
        Me.txtOxygenLevel.TabIndex = 8
        '
        'lblOxygenLevel
        '
        Me.lblOxygenLevel.BackColor = System.Drawing.SystemColors.Control
        Me.lblOxygenLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOxygenLevel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblOxygenLevel.ForeColor = System.Drawing.Color.Black
        Me.lblOxygenLevel.Location = New System.Drawing.Point(330, 303)
        Me.lblOxygenLevel.Name = "lblOxygenLevel"
        Me.lblOxygenLevel.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblOxygenLevel.Size = New System.Drawing.Size(110, 23)
        Me.lblOxygenLevel.TabIndex = 562
        Me.lblOxygenLevel.Text = "Oxygen Level"
        Me.lblOxygenLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkFitToWork
        '
        Me.chkFitToWork.AutoSize = True
        Me.chkFitToWork.BackColor = System.Drawing.SystemColors.Control
        Me.chkFitToWork.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkFitToWork.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkFitToWork.Location = New System.Drawing.Point(678, 383)
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
        Me.lblFitToWork.Location = New System.Drawing.Point(672, 378)
        Me.lblFitToWork.Name = "lblFitToWork"
        Me.lblFitToWork.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.lblFitToWork.Size = New System.Drawing.Size(300, 23)
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
        Me.chkSentHome.Location = New System.Drawing.Point(678, 408)
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
        Me.lblSentHome.Location = New System.Drawing.Point(672, 403)
        Me.lblSentHome.Name = "lblSentHome"
        Me.lblSentHome.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.lblSentHome.Size = New System.Drawing.Size(300, 23)
        Me.lblSentHome.TabIndex = 7
        Me.lblSentHome.Text = "Sent Home"
        Me.lblSentHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlAttachment
        '
        Me.pnlAttachment.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAttachment.Controls.Add(Me.lblProgress)
        Me.pnlAttachment.Controls.Add(Me.pbAttachment)
        Me.pnlAttachment.Controls.Add(Me.btnView)
        Me.pnlAttachment.Controls.Add(Me.txtFilename)
        Me.pnlAttachment.Controls.Add(Me.btnNext)
        Me.pnlAttachment.Controls.Add(Me.btnPrevious)
        Me.pnlAttachment.Controls.Add(Me.btnRemove)
        Me.pnlAttachment.Controls.Add(Me.btnBrowse)
        Me.pnlAttachment.Controls.Add(Me.picImage)
        Me.pnlAttachment.Controls.Add(Me.AxAcroPDF)
        Me.pnlAttachment.Location = New System.Drawing.Point(672, 28)
        Me.pnlAttachment.Name = "pnlAttachment"
        Me.pnlAttachment.Size = New System.Drawing.Size(300, 348)
        Me.pnlAttachment.TabIndex = 17
        '
        'lblProgress
        '
        Me.lblProgress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblProgress.AutoSize = True
        Me.lblProgress.BackColor = System.Drawing.Color.Gainsboro
        Me.lblProgress.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblProgress.Location = New System.Drawing.Point(11, 292)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(24, 15)
        Me.lblProgress.TabIndex = 575
        Me.lblProgress.Text = "0/0"
        Me.lblProgress.Visible = False
        '
        'pbAttachment
        '
        Me.pbAttachment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbAttachment.Location = New System.Drawing.Point(7, 288)
        Me.pbAttachment.Name = "pbAttachment"
        Me.pbAttachment.Size = New System.Drawing.Size(286, 23)
        Me.pbAttachment.TabIndex = 574
        Me.pbAttachment.Visible = False
        '
        'btnView
        '
        Me.btnView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnView.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnView.DefaultScheme = False
        Me.btnView.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnView.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Hint = "View"
        Me.btnView.Image = Global.HealthInformationSystem.My.Resources.Resources.Expand
        Me.btnView.Location = New System.Drawing.Point(59, 317)
        Me.btnView.Name = "btnView"
        Me.btnView.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnView.Size = New System.Drawing.Size(26, 26)
        Me.btnView.TabIndex = 572
        Me.btnView.TabStop = False
        '
        'txtFilename
        '
        Me.txtFilename.AutoSize = True
        Me.txtFilename.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFilename.Location = New System.Drawing.Point(2, 3)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Size = New System.Drawing.Size(55, 15)
        Me.txtFilename.TabIndex = 571
        Me.txtFilename.Text = "Filename"
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNext.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnNext.DefaultScheme = False
        Me.btnNext.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnNext.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Hint = "Next"
        Me.btnNext.Location = New System.Drawing.Point(30, 317)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnNext.Size = New System.Drawing.Size(26, 26)
        Me.btnNext.TabIndex = 1
        Me.btnNext.TabStop = False
        Me.btnNext.Text = ">"
        '
        'btnPrevious
        '
        Me.btnPrevious.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrevious.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnPrevious.DefaultScheme = False
        Me.btnPrevious.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnPrevious.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevious.Hint = "Previous"
        Me.btnPrevious.Location = New System.Drawing.Point(2, 317)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnPrevious.Size = New System.Drawing.Size(26, 26)
        Me.btnPrevious.TabIndex = 0
        Me.btnPrevious.TabStop = False
        Me.btnPrevious.Text = "<"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnRemove.DefaultScheme = False
        Me.btnRemove.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemove.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnRemove.Hint = "Remove attachment"
        Me.btnRemove.Location = New System.Drawing.Point(219, 317)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemove.Size = New System.Drawing.Size(76, 26)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.TabStop = False
        Me.btnRemove.Text = "Remove"
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnBrowse.DefaultScheme = False
        Me.btnBrowse.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnBrowse.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnBrowse.Hint = "Browse files"
        Me.btnBrowse.Location = New System.Drawing.Point(139, 317)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnBrowse.Size = New System.Drawing.Size(76, 26)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.TabStop = False
        Me.btnBrowse.Text = "Browse"
        '
        'picImage
        '
        Me.picImage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picImage.BackColor = System.Drawing.Color.White
        Me.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picImage.ErrorImage = Nothing
        Me.picImage.InitialImage = Nothing
        Me.picImage.Location = New System.Drawing.Point(5, 21)
        Me.picImage.Name = "picImage"
        Me.picImage.Size = New System.Drawing.Size(290, 292)
        Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage.TabIndex = 576
        Me.picImage.TabStop = False
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
        Me.txtCreatedBy.Size = New System.Drawing.Size(230, 23)
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
        'lblAttachmentCount
        '
        Me.lblAttachmentCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAttachmentCount.AutoSize = True
        Me.lblAttachmentCount.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblAttachmentCount.Location = New System.Drawing.Point(700, 652)
        Me.lblAttachmentCount.Name = "lblAttachmentCount"
        Me.lblAttachmentCount.Size = New System.Drawing.Size(98, 15)
        Me.lblAttachmentCount.TabIndex = 572
        Me.lblAttachmentCount.Text = "Attachment Qty :"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(1239, 662)
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
        'txtHpi
        '
        Me.txtHpi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHpi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHpi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHpi.Location = New System.Drawing.Point(974, 530)
        Me.txtHpi.Multiline = True
        Me.txtHpi.Name = "txtHpi"
        Me.txtHpi.Size = New System.Drawing.Size(356, 119)
        Me.txtHpi.TabIndex = 23
        '
        'lblHpi
        '
        Me.lblHpi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHpi.BackColor = System.Drawing.SystemColors.Control
        Me.lblHpi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHpi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblHpi.ForeColor = System.Drawing.Color.Black
        Me.lblHpi.Location = New System.Drawing.Point(974, 506)
        Me.lblHpi.Name = "lblHpi"
        Me.lblHpi.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblHpi.Size = New System.Drawing.Size(356, 25)
        Me.lblHpi.TabIndex = 578
        Me.lblHpi.Text = "History of Present Illness (HPI)"
        Me.lblHpi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPlan
        '
        Me.txtPlan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPlan.Location = New System.Drawing.Point(974, 371)
        Me.txtPlan.Multiline = True
        Me.txtPlan.Name = "txtPlan"
        Me.txtPlan.Size = New System.Drawing.Size(356, 133)
        Me.txtPlan.TabIndex = 22
        '
        'lblPlan
        '
        Me.lblPlan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPlan.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPlan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPlan.ForeColor = System.Drawing.Color.Black
        Me.lblPlan.Location = New System.Drawing.Point(974, 349)
        Me.lblPlan.Name = "lblPlan"
        Me.lblPlan.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblPlan.Size = New System.Drawing.Size(356, 24)
        Me.lblPlan.TabIndex = 577
        Me.lblPlan.Text = "Plan"
        Me.lblPlan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.txtModifiedBy.Size = New System.Drawing.Size(230, 23)
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
        Me.txtCreatedDate.Size = New System.Drawing.Size(230, 23)
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
        Me.txtModifiedDate.Size = New System.Drawing.Size(230, 23)
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
        'chkTeleconsult
        '
        Me.chkTeleconsult.AutoSize = True
        Me.chkTeleconsult.BackColor = System.Drawing.SystemColors.Control
        Me.chkTeleconsult.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkTeleconsult.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.chkTeleconsult.Location = New System.Drawing.Point(678, 433)
        Me.chkTeleconsult.Name = "chkTeleconsult"
        Me.chkTeleconsult.Size = New System.Drawing.Size(15, 14)
        Me.chkTeleconsult.TabIndex = 17
        Me.chkTeleconsult.UseVisualStyleBackColor = False
        '
        'lblTeleconsult
        '
        Me.lblTeleconsult.BackColor = System.Drawing.SystemColors.Control
        Me.lblTeleconsult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTeleconsult.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTeleconsult.ForeColor = System.Drawing.Color.Black
        Me.lblTeleconsult.Location = New System.Drawing.Point(672, 428)
        Me.lblTeleconsult.Name = "lblTeleconsult"
        Me.lblTeleconsult.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.lblTeleconsult.Size = New System.Drawing.Size(300, 23)
        Me.lblTeleconsult.TabIndex = 586
        Me.lblTeleconsult.Text = "Tele Consult"
        Me.lblTeleconsult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'bgWorker
        '
        Me.bgWorker.WorkerReportsProgress = True
        Me.bgWorker.WorkerSupportsCancellation = True
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
        Me.txtEmployeeCode.Size = New System.Drawing.Size(101, 23)
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
        Me.txtEmployeeName.Size = New System.Drawing.Size(230, 23)
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
        'lblAgencyName
        '
        Me.lblAgencyName.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblAgencyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAgencyName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblAgencyName.ForeColor = System.Drawing.Color.Black
        Me.lblAgencyName.Location = New System.Drawing.Point(542, 128)
        Me.lblAgencyName.Name = "lblAgencyName"
        Me.lblAgencyName.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblAgencyName.Size = New System.Drawing.Size(127, 23)
        Me.lblAgencyName.TabIndex = 619
        Me.lblAgencyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblConsultation
        '
        Me.lblConsultation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblConsultation.BackColor = System.Drawing.Color.DarkSlateGray
        Me.lblConsultation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblConsultation.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsultation.ForeColor = System.Drawing.Color.White
        Me.lblConsultation.Location = New System.Drawing.Point(330, 4)
        Me.lblConsultation.Name = "lblConsultation"
        Me.lblConsultation.Size = New System.Drawing.Size(1000, 22)
        Me.lblConsultation.TabIndex = 625
        Me.lblConsultation.Text = "Consultation"
        Me.lblConsultation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTimeIn
        '
        Me.txtTimeIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTimeIn.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTimeIn.Location = New System.Drawing.Point(439, 178)
        Me.txtTimeIn.Mask = "00/00/0000 90:00"
        Me.txtTimeIn.Name = "txtTimeIn"
        Me.txtTimeIn.PromptChar = Global.Microsoft.VisualBasic.ChrW(45)
        Me.txtTimeIn.Size = New System.Drawing.Size(230, 23)
        Me.txtTimeIn.TabIndex = 3
        Me.txtTimeIn.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtTimeIn.ValidatingType = GetType(Date)
        '
        'lblTimeIn
        '
        Me.lblTimeIn.BackColor = System.Drawing.SystemColors.Control
        Me.lblTimeIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTimeIn.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTimeIn.ForeColor = System.Drawing.Color.Black
        Me.lblTimeIn.Location = New System.Drawing.Point(330, 178)
        Me.lblTimeIn.Name = "lblTimeIn"
        Me.lblTimeIn.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblTimeIn.Size = New System.Drawing.Size(110, 23)
        Me.lblTimeIn.TabIndex = 627
        Me.lblTimeIn.Text = "Time In"
        Me.lblTimeIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTimeOut
        '
        Me.txtTimeOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTimeOut.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTimeOut.Location = New System.Drawing.Point(439, 203)
        Me.txtTimeOut.Mask = "00/00/0000 90:00"
        Me.txtTimeOut.Name = "txtTimeOut"
        Me.txtTimeOut.PromptChar = Global.Microsoft.VisualBasic.ChrW(45)
        Me.txtTimeOut.Size = New System.Drawing.Size(230, 23)
        Me.txtTimeOut.TabIndex = 4
        Me.txtTimeOut.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtTimeOut.ValidatingType = GetType(Date)
        '
        'lblTimeOut
        '
        Me.lblTimeOut.BackColor = System.Drawing.SystemColors.Control
        Me.lblTimeOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTimeOut.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTimeOut.ForeColor = System.Drawing.Color.Black
        Me.lblTimeOut.Location = New System.Drawing.Point(330, 203)
        Me.lblTimeOut.Name = "lblTimeOut"
        Me.lblTimeOut.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblTimeOut.Size = New System.Drawing.Size(110, 23)
        Me.lblTimeOut.TabIndex = 629
        Me.lblTimeOut.Text = "Time Out"
        Me.lblTimeOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkRest
        '
        Me.chkRest.AutoSize = True
        Me.chkRest.BackColor = System.Drawing.SystemColors.Control
        Me.chkRest.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkRest.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.chkRest.Location = New System.Drawing.Point(337, 383)
        Me.chkRest.Name = "chkRest"
        Me.chkRest.Size = New System.Drawing.Size(15, 14)
        Me.chkRest.TabIndex = 11
        Me.chkRest.UseVisualStyleBackColor = False
        '
        'lblRest
        '
        Me.lblRest.BackColor = System.Drawing.SystemColors.Control
        Me.lblRest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRest.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRest.ForeColor = System.Drawing.Color.Black
        Me.lblRest.Location = New System.Drawing.Point(330, 378)
        Me.lblRest.Name = "lblRest"
        Me.lblRest.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.lblRest.Size = New System.Drawing.Size(110, 23)
        Me.lblRest.TabIndex = 631
        Me.lblRest.Text = "Rest"
        Me.lblRest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRestMinutes
        '
        Me.lblRestMinutes.BackColor = System.Drawing.SystemColors.Control
        Me.lblRestMinutes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRestMinutes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRestMinutes.ForeColor = System.Drawing.Color.Black
        Me.lblRestMinutes.Location = New System.Drawing.Point(442, 378)
        Me.lblRestMinutes.Name = "lblRestMinutes"
        Me.lblRestMinutes.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblRestMinutes.Size = New System.Drawing.Size(50, 23)
        Me.lblRestMinutes.TabIndex = 633
        Me.lblRestMinutes.Text = "Mins."
        Me.lblRestMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRestMinutes
        '
        Me.txtRestMinutes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRestMinutes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRestMinutes.Location = New System.Drawing.Point(491, 378)
        Me.txtRestMinutes.Name = "txtRestMinutes"
        Me.txtRestMinutes.Size = New System.Drawing.Size(178, 23)
        Me.txtRestMinutes.TabIndex = 12
        Me.txtRestMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblRoom
        '
        Me.lblRoom.BackColor = System.Drawing.SystemColors.Control
        Me.lblRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRoom.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRoom.ForeColor = System.Drawing.Color.Black
        Me.lblRoom.Location = New System.Drawing.Point(330, 403)
        Me.lblRoom.Name = "lblRoom"
        Me.lblRoom.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblRoom.Size = New System.Drawing.Size(110, 23)
        Me.lblRoom.TabIndex = 635
        Me.lblRoom.Text = "Room"
        Me.lblRoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbRoom
        '
        Me.cmbRoom.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbRoom.FormattingEnabled = True
        Me.cmbRoom.Location = New System.Drawing.Point(439, 403)
        Me.cmbRoom.Name = "cmbRoom"
        Me.cmbRoom.Size = New System.Drawing.Size(230, 23)
        Me.cmbRoom.TabIndex = 13
        '
        'lblBed
        '
        Me.lblBed.BackColor = System.Drawing.SystemColors.Control
        Me.lblBed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBed.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblBed.ForeColor = System.Drawing.Color.Black
        Me.lblBed.Location = New System.Drawing.Point(330, 428)
        Me.lblBed.Name = "lblBed"
        Me.lblBed.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblBed.Size = New System.Drawing.Size(110, 23)
        Me.lblBed.TabIndex = 637
        Me.lblBed.Text = "Bed No"
        Me.lblBed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbBed
        '
        Me.cmbBed.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbBed.FormattingEnabled = True
        Me.cmbBed.Location = New System.Drawing.Point(439, 428)
        Me.cmbBed.Name = "cmbBed"
        Me.cmbBed.Size = New System.Drawing.Size(230, 23)
        Me.cmbBed.TabIndex = 14
        '
        'dgvDetail
        '
        Me.dgvDetail.AllowUserToAddRows = False
        Me.dgvDetail.AllowUserToDeleteRows = False
        Me.dgvDetail.AllowUserToResizeColumns = False
        Me.dgvDetail.AllowUserToResizeRows = False
        Me.dgvDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetail.ColumnHeadersHeight = 25
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColTrxId, Me.ColMedicineId, Me.ColStockOut, Me.ColEndingBalance})
        Me.dgvDetail.Location = New System.Drawing.Point(330, 506)
        Me.dgvDetail.MultiSelect = False
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.ReadOnly = True
        Me.dgvDetail.RowHeadersVisible = False
        Me.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetail.Size = New System.Drawing.Size(642, 143)
        Me.dgvDetail.TabIndex = 639
        Me.dgvDetail.TabStop = False
        '
        'ColTrxId
        '
        Me.ColTrxId.DataPropertyName = "TrxId"
        Me.ColTrxId.HeaderText = "TrxId"
        Me.ColTrxId.Name = "ColTrxId"
        Me.ColTrxId.ReadOnly = True
        Me.ColTrxId.Visible = False
        '
        'ColMedicineId
        '
        Me.ColMedicineId.DataPropertyName = "MedicineId"
        Me.ColMedicineId.HeaderText = "MedicineId"
        Me.ColMedicineId.Name = "ColMedicineId"
        Me.ColMedicineId.ReadOnly = True
        Me.ColMedicineId.Visible = False
        '
        'ColStockOut
        '
        Me.ColStockOut.DataPropertyName = "Qty"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColStockOut.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColStockOut.HeaderText = "Qty"
        Me.ColStockOut.Name = "ColStockOut"
        Me.ColStockOut.ReadOnly = True
        Me.ColStockOut.Width = 60
        '
        'ColEndingBalance
        '
        Me.ColEndingBalance.DataPropertyName = "StockId"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColEndingBalance.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColEndingBalance.HeaderText = "StockId"
        Me.ColEndingBalance.Name = "ColEndingBalance"
        Me.ColEndingBalance.ReadOnly = True
        Me.ColEndingBalance.Visible = False
        Me.ColEndingBalance.Width = 60
        '
        'lblMedicine
        '
        Me.lblMedicine.BackColor = System.Drawing.SystemColors.Control
        Me.lblMedicine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMedicine.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMedicine.ForeColor = System.Drawing.Color.Black
        Me.lblMedicine.Location = New System.Drawing.Point(330, 453)
        Me.lblMedicine.Name = "lblMedicine"
        Me.lblMedicine.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblMedicine.Size = New System.Drawing.Size(110, 23)
        Me.lblMedicine.TabIndex = 640
        Me.lblMedicine.Text = "Medicine"
        Me.lblMedicine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMedicine
        '
        Me.cmbMedicine.DisplayMember = "MedicineName"
        Me.cmbMedicine.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMedicine.FormattingEnabled = True
        Me.cmbMedicine.Location = New System.Drawing.Point(439, 453)
        Me.cmbMedicine.Name = "cmbMedicine"
        Me.cmbMedicine.Size = New System.Drawing.Size(230, 23)
        Me.cmbMedicine.TabIndex = 18
        Me.cmbMedicine.ValueMember = "MedicineId"
        '
        'lblMedQty
        '
        Me.lblMedQty.BackColor = System.Drawing.SystemColors.Control
        Me.lblMedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMedQty.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMedQty.ForeColor = System.Drawing.Color.Black
        Me.lblMedQty.Location = New System.Drawing.Point(672, 453)
        Me.lblMedQty.Name = "lblMedQty"
        Me.lblMedQty.Size = New System.Drawing.Size(40, 23)
        Me.lblMedQty.TabIndex = 643
        Me.lblMedQty.Text = "Qty"
        Me.lblMedQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtQty
        '
        Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtQty.Location = New System.Drawing.Point(711, 453)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(55, 23)
        Me.txtQty.TabIndex = 19
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnRemoveRow
        '
        Me.btnRemoveRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRemoveRow.DefaultScheme = False
        Me.btnRemoveRow.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemoveRow.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnRemoveRow.Hint = "Remove highlighted medicine from the list"
        Me.btnRemoveRow.Location = New System.Drawing.Point(832, 477)
        Me.btnRemoveRow.Name = "btnRemoveRow"
        Me.btnRemoveRow.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemoveRow.Size = New System.Drawing.Size(140, 28)
        Me.btnRemoveRow.TabIndex = 645
        Me.btnRemoveRow.TabStop = False
        Me.btnRemoveRow.Text = "Remove Medicine"
        '
        'btnAddRow
        '
        Me.btnAddRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAddRow.DefaultScheme = False
        Me.btnAddRow.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnAddRow.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnAddRow.Hint = "Add selected medicine to the list"
        Me.btnAddRow.Location = New System.Drawing.Point(672, 477)
        Me.btnAddRow.Name = "btnAddRow"
        Me.btnAddRow.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAddRow.Size = New System.Drawing.Size(157, 28)
        Me.btnAddRow.TabIndex = 644
        Me.btnAddRow.TabStop = False
        Me.btnAddRow.Text = "Add Medicine"
        '
        'lblMedicineCount
        '
        Me.lblMedicineCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMedicineCount.AutoSize = True
        Me.lblMedicineCount.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblMedicineCount.Location = New System.Drawing.Point(346, 652)
        Me.lblMedicineCount.Name = "lblMedicineCount"
        Me.lblMedicineCount.Size = New System.Drawing.Size(84, 15)
        Me.lblMedicineCount.TabIndex = 647
        Me.lblMedicineCount.Text = "Medicine Qty :"
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
        Me.btnCancel.Location = New System.Drawing.Point(1049, 662)
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
        Me.btnDelete.Location = New System.Drawing.Point(1144, 662)
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
        Me.btnSave.Location = New System.Drawing.Point(954, 662)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 13
        Me.btnSave.TabStop = False
        Me.btnSave.Text = " Save"
        '
        'cmbAgency
        '
        Me.cmbAgency.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbAgency.FormattingEnabled = True
        Me.cmbAgency.Location = New System.Drawing.Point(542, 128)
        Me.cmbAgency.Name = "cmbAgency"
        Me.cmbAgency.Size = New System.Drawing.Size(127, 23)
        Me.cmbAgency.TabIndex = 1
        Me.cmbAgency.Visible = False
        '
        'txtEmployeeNameAgency
        '
        Me.txtEmployeeNameAgency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeNameAgency.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeNameAgency.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmployeeNameAgency.Location = New System.Drawing.Point(439, 153)
        Me.txtEmployeeNameAgency.Name = "txtEmployeeNameAgency"
        Me.txtEmployeeNameAgency.Size = New System.Drawing.Size(230, 23)
        Me.txtEmployeeNameAgency.TabIndex = 2
        Me.txtEmployeeNameAgency.Visible = False
        '
        'btnManualOut
        '
        Me.btnManualOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnManualOut.DefaultScheme = False
        Me.btnManualOut.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnManualOut.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManualOut.Hint = "Set current datetime then save record"
        Me.btnManualOut.Image = Global.HealthInformationSystem.My.Resources.Resources.Clock
        Me.btnManualOut.Location = New System.Drawing.Point(643, 204)
        Me.btnManualOut.Name = "btnManualOut"
        Me.btnManualOut.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnManualOut.Size = New System.Drawing.Size(25, 21)
        Me.btnManualOut.TabIndex = 651
        Me.btnManualOut.TabStop = False
        '
        'lblStock
        '
        Me.lblStock.BackColor = System.Drawing.SystemColors.Control
        Me.lblStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStock.ForeColor = System.Drawing.Color.Black
        Me.lblStock.Location = New System.Drawing.Point(855, 453)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(55, 23)
        Me.lblStock.TabIndex = 653
        Me.lblStock.Text = "Stock"
        Me.lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtStock
        '
        Me.txtStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtStock.ForeColor = System.Drawing.Color.Black
        Me.txtStock.Location = New System.Drawing.Point(909, 453)
        Me.txtStock.Name = "txtStock"
        Me.txtStock.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtStock.Size = New System.Drawing.Size(63, 23)
        Me.txtStock.TabIndex = 654
        Me.txtStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtUnitName
        '
        Me.txtUnitName.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtUnitName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUnitName.ForeColor = System.Drawing.Color.Black
        Me.txtUnitName.Location = New System.Drawing.Point(765, 453)
        Me.txtUnitName.Name = "txtUnitName"
        Me.txtUnitName.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtUnitName.Size = New System.Drawing.Size(91, 23)
        Me.txtUnitName.TabIndex = 655
        Me.txtUnitName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlLeft
        '
        Me.pnlLeft.AutoScroll = True
        Me.pnlLeft.Controls.Add(Me.txtMaintenance)
        Me.pnlLeft.Controls.Add(Me.lblMaintenance)
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
        'AxAcroPDF
        '
        Me.AxAcroPDF.Enabled = True
        Me.AxAcroPDF.Location = New System.Drawing.Point(5, 21)
        Me.AxAcroPDF.Name = "AxAcroPDF"
        Me.AxAcroPDF.OcxState = CType(resources.GetObject("AxAcroPDF.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF.Size = New System.Drawing.Size(290, 292)
        Me.AxAcroPDF.TabIndex = 577
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
        'lblEmgContactName
        '
        Me.lblEmgContactName.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmgContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmgContactName.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblEmgContactName.ForeColor = System.Drawing.Color.Black
        Me.lblEmgContactName.Location = New System.Drawing.Point(2, 632)
        Me.lblEmgContactName.Name = "lblEmgContactName"
        Me.lblEmgContactName.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmgContactName.Size = New System.Drawing.Size(110, 23)
        Me.lblEmgContactName.TabIndex = 691
        Me.lblEmgContactName.Text = "Name"
        Me.lblEmgContactName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmgContactName
        '
        Me.txtEmgContactName.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtEmgContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmgContactName.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtEmgContactName.ForeColor = System.Drawing.Color.Black
        Me.txtEmgContactName.Location = New System.Drawing.Point(111, 632)
        Me.txtEmgContactName.Name = "txtEmgContactName"
        Me.txtEmgContactName.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtEmgContactName.Size = New System.Drawing.Size(200, 23)
        Me.txtEmgContactName.TabIndex = 692
        Me.txtEmgContactName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmgContactNumber
        '
        Me.lblEmgContactNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmgContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmgContactNumber.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblEmgContactNumber.ForeColor = System.Drawing.Color.Black
        Me.lblEmgContactNumber.Location = New System.Drawing.Point(2, 657)
        Me.lblEmgContactNumber.Name = "lblEmgContactNumber"
        Me.lblEmgContactNumber.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmgContactNumber.Size = New System.Drawing.Size(110, 23)
        Me.lblEmgContactNumber.TabIndex = 693
        Me.lblEmgContactNumber.Text = "Contact Number"
        Me.lblEmgContactNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmgContactNumber
        '
        Me.txtEmgContactNumber.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtEmgContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmgContactNumber.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtEmgContactNumber.ForeColor = System.Drawing.Color.Black
        Me.txtEmgContactNumber.Location = New System.Drawing.Point(111, 657)
        Me.txtEmgContactNumber.Name = "txtEmgContactNumber"
        Me.txtEmgContactNumber.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtEmgContactNumber.Size = New System.Drawing.Size(200, 23)
        Me.txtEmgContactNumber.TabIndex = 694
        Me.txtEmgContactNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmgContactAddress
        '
        Me.lblEmgContactAddress.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmgContactAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmgContactAddress.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblEmgContactAddress.ForeColor = System.Drawing.Color.Black
        Me.lblEmgContactAddress.Location = New System.Drawing.Point(2, 682)
        Me.lblEmgContactAddress.Name = "lblEmgContactAddress"
        Me.lblEmgContactAddress.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmgContactAddress.Size = New System.Drawing.Size(110, 49)
        Me.lblEmgContactAddress.TabIndex = 695
        Me.lblEmgContactAddress.Text = "Address"
        Me.lblEmgContactAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmgContactAddress
        '
        Me.txtEmgContactAddress.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtEmgContactAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmgContactAddress.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtEmgContactAddress.ForeColor = System.Drawing.Color.Black
        Me.txtEmgContactAddress.Location = New System.Drawing.Point(111, 682)
        Me.txtEmgContactAddress.Name = "txtEmgContactAddress"
        Me.txtEmgContactAddress.Padding = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.txtEmgContactAddress.Size = New System.Drawing.Size(200, 49)
        Me.txtEmgContactAddress.TabIndex = 696
        Me.txtEmgContactAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmer
        '
        Me.lblEmer.BackColor = System.Drawing.Color.DarkSlateGray
        Me.lblEmer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmer.ForeColor = System.Drawing.Color.White
        Me.lblEmer.Location = New System.Drawing.Point(2, 608)
        Me.lblEmer.Name = "lblEmer"
        Me.lblEmer.Size = New System.Drawing.Size(309, 22)
        Me.lblEmer.TabIndex = 697
        Me.lblEmer.Text = "Emergency Contact Reference"
        Me.lblEmer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'lblObHistory
        '
        Me.lblObHistory.BackColor = System.Drawing.SystemColors.Control
        Me.lblObHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblObHistory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObHistory.ForeColor = System.Drawing.Color.Black
        Me.lblObHistory.Location = New System.Drawing.Point(2, 439)
        Me.lblObHistory.Name = "lblObHistory"
        Me.lblObHistory.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblObHistory.Size = New System.Drawing.Size(110, 117)
        Me.lblObHistory.TabIndex = 703
        Me.lblObHistory.Text = "OB History" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Menarche" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Interval" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Duration" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Amount" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Symptoms"
        Me.lblObHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGp
        '
        Me.lblGp.BackColor = System.Drawing.SystemColors.Control
        Me.lblGp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGp.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblGp.ForeColor = System.Drawing.Color.Black
        Me.lblGp.Location = New System.Drawing.Point(2, 558)
        Me.lblGp.Name = "lblGp"
        Me.lblGp.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblGp.Size = New System.Drawing.Size(110, 23)
        Me.lblGp.TabIndex = 704
        Me.lblGp.Text = "G; P"
        Me.lblGp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblG
        '
        Me.lblG.BackColor = System.Drawing.SystemColors.Control
        Me.lblG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblG.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblG.ForeColor = System.Drawing.Color.Black
        Me.lblG.Location = New System.Drawing.Point(2, 583)
        Me.lblG.Name = "lblG"
        Me.lblG.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblG.Size = New System.Drawing.Size(110, 23)
        Me.lblG.TabIndex = 705
        Me.lblG.Text = "G1; G2"
        Me.lblG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObHistory
        '
        Me.txtObHistory.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtObHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObHistory.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtObHistory.ForeColor = System.Drawing.Color.Black
        Me.txtObHistory.Location = New System.Drawing.Point(111, 439)
        Me.txtObHistory.Name = "txtObHistory"
        Me.txtObHistory.Padding = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.txtObHistory.Size = New System.Drawing.Size(200, 117)
        Me.txtObHistory.TabIndex = 706
        Me.txtObHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGp
        '
        Me.txtGp.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtGp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGp.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtGp.ForeColor = System.Drawing.Color.Black
        Me.txtGp.Location = New System.Drawing.Point(111, 558)
        Me.txtGp.Name = "txtGp"
        Me.txtGp.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtGp.Size = New System.Drawing.Size(200, 23)
        Me.txtGp.TabIndex = 707
        Me.txtGp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtG
        '
        Me.txtG.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtG.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.txtG.ForeColor = System.Drawing.Color.Black
        Me.txtG.Location = New System.Drawing.Point(111, 583)
        Me.txtG.Name = "txtG"
        Me.txtG.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtG.Size = New System.Drawing.Size(200, 23)
        Me.txtG.TabIndex = 708
        Me.txtG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMaintenance
        '
        Me.txtMaintenance.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtMaintenance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaintenance.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtMaintenance.ForeColor = System.Drawing.Color.Black
        Me.txtMaintenance.Location = New System.Drawing.Point(111, 402)
        Me.txtMaintenance.Name = "txtMaintenance"
        Me.txtMaintenance.Padding = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.txtMaintenance.Size = New System.Drawing.Size(200, 35)
        Me.txtMaintenance.TabIndex = 710
        Me.txtMaintenance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMaintenance
        '
        Me.lblMaintenance.BackColor = System.Drawing.SystemColors.Control
        Me.lblMaintenance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMaintenance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaintenance.ForeColor = System.Drawing.Color.Black
        Me.lblMaintenance.Location = New System.Drawing.Point(2, 402)
        Me.lblMaintenance.Name = "lblMaintenance"
        Me.lblMaintenance.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblMaintenance.Size = New System.Drawing.Size(110, 35)
        Me.lblMaintenance.TabIndex = 709
        Me.lblMaintenance.Text = "Maintenance"
        Me.lblMaintenance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ConsultationDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1334, 699)
        Me.Controls.Add(Me.pnlLeft)
        Me.Controls.Add(Me.pnlAttachment)
        Me.Controls.Add(Me.txtStock)
        Me.Controls.Add(Me.lblStock)
        Me.Controls.Add(Me.btnManualOut)
        Me.Controls.Add(Me.lblMedicineCount)
        Me.Controls.Add(Me.btnRemoveRow)
        Me.Controls.Add(Me.btnAddRow)
        Me.Controls.Add(Me.lblMedQty)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.lblMedicine)
        Me.Controls.Add(Me.cmbMedicine)
        Me.Controls.Add(Me.dgvDetail)
        Me.Controls.Add(Me.lblBed)
        Me.Controls.Add(Me.cmbBed)
        Me.Controls.Add(Me.lblRoom)
        Me.Controls.Add(Me.cmbRoom)
        Me.Controls.Add(Me.lblRestMinutes)
        Me.Controls.Add(Me.txtRestMinutes)
        Me.Controls.Add(Me.chkRest)
        Me.Controls.Add(Me.lblRest)
        Me.Controls.Add(Me.txtTimeOut)
        Me.Controls.Add(Me.lblTimeOut)
        Me.Controls.Add(Me.txtTimeIn)
        Me.Controls.Add(Me.lblTimeIn)
        Me.Controls.Add(Me.lblConsultation)
        Me.Controls.Add(Me.lblEmployeeName)
        Me.Controls.Add(Me.lblEmployeeCode)
        Me.Controls.Add(Me.txtEmployeeCode)
        Me.Controls.Add(Me.lblOxygenLevel)
        Me.Controls.Add(Me.lblRespiratoryRate)
        Me.Controls.Add(Me.lblPulseRate)
        Me.Controls.Add(Me.lblBloodPressure)
        Me.Controls.Add(Me.lblTemperature)
        Me.Controls.Add(Me.chkTeleconsult)
        Me.Controls.Add(Me.lblTeleconsult)
        Me.Controls.Add(Me.txtModifiedDate)
        Me.Controls.Add(Me.lblModifiedDate)
        Me.Controls.Add(Me.txtModifiedBy)
        Me.Controls.Add(Me.lblModifiedBy)
        Me.Controls.Add(Me.txtCreatedDate)
        Me.Controls.Add(Me.lblCreatedDate)
        Me.Controls.Add(Me.txtHpi)
        Me.Controls.Add(Me.lblHpi)
        Me.Controls.Add(Me.txtPlan)
        Me.Controls.Add(Me.lblPlan)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblAttachmentCount)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtCreatedBy)
        Me.Controls.Add(Me.lblCreatedBy)
        Me.Controls.Add(Me.chkSentHome)
        Me.Controls.Add(Me.lblSentHome)
        Me.Controls.Add(Me.chkFitToWork)
        Me.Controls.Add(Me.lblFitToWork)
        Me.Controls.Add(Me.txtOxygenLevel)
        Me.Controls.Add(Me.txtLmp)
        Me.Controls.Add(Me.txtDiagnosis)
        Me.Controls.Add(Me.lblDiagnosis)
        Me.Controls.Add(Me.txtChiefComplaint)
        Me.Controls.Add(Me.txtRespiratoryRate)
        Me.Controls.Add(Me.txtPulseRate)
        Me.Controls.Add(Me.txtBloodPressure)
        Me.Controls.Add(Me.txtTemperature)
        Me.Controls.Add(Me.lblChiefComplaint)
        Me.Controls.Add(Me.lblLmp)
        Me.Controls.Add(Me.txtUnitName)
        Me.Controls.Add(Me.lblAgencyName)
        Me.Controls.Add(Me.txtEmployeeName)
        Me.Controls.Add(Me.cmbAgency)
        Me.Controls.Add(Me.txtEmployeeNameAgency)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConsultationDetail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.pnlAttachment.ResumeLayout(False)
        Me.pnlAttachment.PerformLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLeft.ResumeLayout(False)
        CType(Me.AxAcroPDF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblLmp As System.Windows.Forms.Label
    Friend WithEvents lblTemperature As System.Windows.Forms.Label
    Friend WithEvents lblBloodPressure As System.Windows.Forms.Label
    Friend WithEvents lblRespiratoryRate As System.Windows.Forms.Label
    Friend WithEvents lblPulseRate As System.Windows.Forms.Label
    Friend WithEvents txtTemperature As System.Windows.Forms.TextBox
    Friend WithEvents txtBloodPressure As System.Windows.Forms.TextBox
    Friend WithEvents txtPulseRate As System.Windows.Forms.TextBox
    Friend WithEvents txtRespiratoryRate As System.Windows.Forms.TextBox
    Friend WithEvents txtChiefComplaint As System.Windows.Forms.TextBox
    Friend WithEvents lblChiefComplaint As System.Windows.Forms.Label
    Friend WithEvents txtDiagnosis As System.Windows.Forms.TextBox
    Friend WithEvents lblDiagnosis As System.Windows.Forms.Label
    Friend WithEvents txtLmp As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtOxygenLevel As System.Windows.Forms.TextBox
    Friend WithEvents lblOxygenLevel As System.Windows.Forms.Label
    Friend WithEvents chkFitToWork As System.Windows.Forms.CheckBox
    Friend WithEvents lblFitToWork As System.Windows.Forms.Label
    Friend WithEvents chkSentHome As System.Windows.Forms.CheckBox
    Friend WithEvents lblSentHome As System.Windows.Forms.Label
    Friend WithEvents pnlAttachment As System.Windows.Forms.Panel
    Friend WithEvents btnNext As PinkieControls.ButtonXP
    Friend WithEvents btnPrevious As PinkieControls.ButtonXP
    Friend WithEvents btnRemove As PinkieControls.ButtonXP
    Friend WithEvents txtCreatedBy As System.Windows.Forms.Label
    Friend WithEvents lblCreatedBy As System.Windows.Forms.Label
    Friend WithEvents txtFilename As System.Windows.Forms.Label
    Friend WithEvents lblAttachmentCount As System.Windows.Forms.Label
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents ofdRecDetail As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtHpi As TextBox
    Friend WithEvents lblHpi As Label
    Friend WithEvents txtPlan As TextBox
    Friend WithEvents lblPlan As Label
    Friend WithEvents txtModifiedBy As Label
    Friend WithEvents lblModifiedBy As Label
    Friend WithEvents txtCreatedDate As Label
    Friend WithEvents lblCreatedDate As Label
    Friend WithEvents txtModifiedDate As Label
    Friend WithEvents lblModifiedDate As Label
    Friend WithEvents btnBrowse As PinkieControls.ButtonXP
    Friend WithEvents chkTeleconsult As CheckBox
    Friend WithEvents lblTeleconsult As Label
    Friend WithEvents btnView As PinkieControls.ButtonXP
    Friend WithEvents pbAttachment As ProgressBar
    Friend WithEvents bgWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblProgress As Label
    Friend WithEvents lblEmployeeCode As Label
    Friend WithEvents txtEmployeeCode As TextBox
    Friend WithEvents txtEmployeeName As Label
    Friend WithEvents lblEmployeeName As Label
    Friend WithEvents lblAgencyName As Label
    Friend WithEvents lblConsultation As Label
    Friend WithEvents txtTimeIn As MaskedTextBox
    Friend WithEvents lblTimeIn As Label
    Friend WithEvents txtTimeOut As MaskedTextBox
    Friend WithEvents lblTimeOut As Label
    Friend WithEvents chkRest As CheckBox
    Friend WithEvents lblRest As Label
    Friend WithEvents lblRestMinutes As Label
    Friend WithEvents txtRestMinutes As TextBox
    Friend WithEvents lblRoom As Label
    Friend WithEvents cmbRoom As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblBed As Label
    Friend WithEvents cmbBed As SergeUtils.EasyCompletionComboBox
    Friend WithEvents dgvDetail As DataGridView
    Friend WithEvents lblMedicine As Label
    Friend WithEvents cmbMedicine As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblMedQty As Label
    Friend WithEvents txtQty As TextBox
    Friend WithEvents btnRemoveRow As PinkieControls.ButtonXP
    Friend WithEvents btnAddRow As PinkieControls.ButtonXP
    Friend WithEvents lblMedicineCount As Label
    Friend WithEvents cmbAgency As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtEmployeeNameAgency As TextBox
    Friend WithEvents btnManualOut As PinkieControls.ButtonXP
    Friend WithEvents lblStock As Label
    Friend WithEvents txtStock As Label
    Friend WithEvents txtUnitName As Label
    Friend WithEvents picImage As PictureBox
    Friend WithEvents AxAcroPDF As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents ColTrxId As DataGridViewTextBoxColumn
    Friend WithEvents ColMedicineId As DataGridViewTextBoxColumn
    Friend WithEvents ColStockOut As DataGridViewTextBoxColumn
    Friend WithEvents ColEndingBalance As DataGridViewTextBoxColumn
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
    Friend WithEvents txtMaintenance As Label
    Friend WithEvents lblMaintenance As Label
End Class
