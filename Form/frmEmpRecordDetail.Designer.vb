<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpRecordDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmpRecordDetail))
        Me.txtDateCreated = New System.Windows.Forms.Label()
        Me.lblDateCreated = New System.Windows.Forms.Label()
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
        Me.pnlImage = New System.Windows.Forms.Panel()
        Me.lblFilename = New System.Windows.Forms.Label()
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.btnNext = New PinkieControls.ButtonXP()
        Me.btnPrevious = New PinkieControls.ButtonXP()
        Me.btnRemove = New PinkieControls.ButtonXP()
        Me.btnAttach = New PinkieControls.ButtonXP()
        Me.txtEncoder = New System.Windows.Forms.Label()
        Me.lblEncoder = New System.Windows.Forms.Label()
        Me.lblFileCount = New System.Windows.Forms.Label()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.ofdRecDetail = New System.Windows.Forms.OpenFileDialog()
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.pnlImage.SuspendLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDateCreated
        '
        Me.txtDateCreated.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDateCreated.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtDateCreated.ForeColor = System.Drawing.Color.Black
        Me.txtDateCreated.Location = New System.Drawing.Point(123, 4)
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtDateCreated.Size = New System.Drawing.Size(155, 24)
        Me.txtDateCreated.TabIndex = 540
        Me.txtDateCreated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDateCreated
        '
        Me.lblDateCreated.BackColor = System.Drawing.SystemColors.Control
        Me.lblDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDateCreated.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblDateCreated.ForeColor = System.Drawing.Color.Black
        Me.lblDateCreated.Location = New System.Drawing.Point(4, 4)
        Me.lblDateCreated.Name = "lblDateCreated"
        Me.lblDateCreated.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblDateCreated.Size = New System.Drawing.Size(120, 24)
        Me.lblDateCreated.TabIndex = 539
        Me.lblDateCreated.Text = "Date"
        Me.lblDateCreated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLmp
        '
        Me.lblLmp.BackColor = System.Drawing.SystemColors.Control
        Me.lblLmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLmp.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblLmp.ForeColor = System.Drawing.Color.Black
        Me.lblLmp.Location = New System.Drawing.Point(4, 30)
        Me.lblLmp.Name = "lblLmp"
        Me.lblLmp.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblLmp.Size = New System.Drawing.Size(120, 24)
        Me.lblLmp.TabIndex = 541
        Me.lblLmp.Text = "LMP"
        Me.lblLmp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTemperature
        '
        Me.lblTemperature.BackColor = System.Drawing.SystemColors.Control
        Me.lblTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTemperature.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblTemperature.ForeColor = System.Drawing.Color.Black
        Me.lblTemperature.Location = New System.Drawing.Point(4, 56)
        Me.lblTemperature.Name = "lblTemperature"
        Me.lblTemperature.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblTemperature.Size = New System.Drawing.Size(120, 24)
        Me.lblTemperature.TabIndex = 543
        Me.lblTemperature.Text = "Temperature"
        Me.lblTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBloodPressure
        '
        Me.lblBloodPressure.BackColor = System.Drawing.SystemColors.Control
        Me.lblBloodPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBloodPressure.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblBloodPressure.ForeColor = System.Drawing.Color.Black
        Me.lblBloodPressure.Location = New System.Drawing.Point(4, 82)
        Me.lblBloodPressure.Name = "lblBloodPressure"
        Me.lblBloodPressure.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblBloodPressure.Size = New System.Drawing.Size(120, 24)
        Me.lblBloodPressure.TabIndex = 545
        Me.lblBloodPressure.Text = "Blood Pressure"
        Me.lblBloodPressure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRespiratoryRate
        '
        Me.lblRespiratoryRate.BackColor = System.Drawing.SystemColors.Control
        Me.lblRespiratoryRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRespiratoryRate.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblRespiratoryRate.ForeColor = System.Drawing.Color.Black
        Me.lblRespiratoryRate.Location = New System.Drawing.Point(281, 56)
        Me.lblRespiratoryRate.Name = "lblRespiratoryRate"
        Me.lblRespiratoryRate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblRespiratoryRate.Size = New System.Drawing.Size(120, 24)
        Me.lblRespiratoryRate.TabIndex = 549
        Me.lblRespiratoryRate.Text = "Respiratory Rate"
        Me.lblRespiratoryRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPulseRate
        '
        Me.lblPulseRate.BackColor = System.Drawing.SystemColors.Control
        Me.lblPulseRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPulseRate.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblPulseRate.ForeColor = System.Drawing.Color.Black
        Me.lblPulseRate.Location = New System.Drawing.Point(281, 30)
        Me.lblPulseRate.Name = "lblPulseRate"
        Me.lblPulseRate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblPulseRate.Size = New System.Drawing.Size(120, 24)
        Me.lblPulseRate.TabIndex = 547
        Me.lblPulseRate.Text = "Pulse Rate"
        Me.lblPulseRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTemperature
        '
        Me.txtTemperature.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtTemperature.Location = New System.Drawing.Point(123, 56)
        Me.txtTemperature.Name = "txtTemperature"
        Me.txtTemperature.Size = New System.Drawing.Size(155, 24)
        Me.txtTemperature.TabIndex = 1
        '
        'txtBloodPressure
        '
        Me.txtBloodPressure.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtBloodPressure.Location = New System.Drawing.Point(123, 82)
        Me.txtBloodPressure.Name = "txtBloodPressure"
        Me.txtBloodPressure.Size = New System.Drawing.Size(155, 24)
        Me.txtBloodPressure.TabIndex = 2
        '
        'txtPulseRate
        '
        Me.txtPulseRate.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtPulseRate.Location = New System.Drawing.Point(400, 30)
        Me.txtPulseRate.Name = "txtPulseRate"
        Me.txtPulseRate.Size = New System.Drawing.Size(155, 24)
        Me.txtPulseRate.TabIndex = 4
        '
        'txtRespiratoryRate
        '
        Me.txtRespiratoryRate.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtRespiratoryRate.Location = New System.Drawing.Point(400, 56)
        Me.txtRespiratoryRate.Name = "txtRespiratoryRate"
        Me.txtRespiratoryRate.Size = New System.Drawing.Size(155, 24)
        Me.txtRespiratoryRate.TabIndex = 5
        '
        'txtChiefComplaint
        '
        Me.txtChiefComplaint.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtChiefComplaint.Location = New System.Drawing.Point(4, 156)
        Me.txtChiefComplaint.Multiline = True
        Me.txtChiefComplaint.Name = "txtChiefComplaint"
        Me.txtChiefComplaint.Size = New System.Drawing.Size(551, 66)
        Me.txtChiefComplaint.TabIndex = 8
        '
        'lblChiefComplaint
        '
        Me.lblChiefComplaint.BackColor = System.Drawing.SystemColors.Control
        Me.lblChiefComplaint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblChiefComplaint.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblChiefComplaint.ForeColor = System.Drawing.Color.Black
        Me.lblChiefComplaint.Location = New System.Drawing.Point(4, 134)
        Me.lblChiefComplaint.Name = "lblChiefComplaint"
        Me.lblChiefComplaint.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblChiefComplaint.Size = New System.Drawing.Size(551, 24)
        Me.lblChiefComplaint.TabIndex = 551
        Me.lblChiefComplaint.Text = "Chief Complaint"
        Me.lblChiefComplaint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDiagnosis
        '
        Me.txtDiagnosis.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtDiagnosis.Location = New System.Drawing.Point(4, 247)
        Me.txtDiagnosis.Multiline = True
        Me.txtDiagnosis.Name = "txtDiagnosis"
        Me.txtDiagnosis.Size = New System.Drawing.Size(551, 66)
        Me.txtDiagnosis.TabIndex = 9
        '
        'lblDiagnosis
        '
        Me.lblDiagnosis.BackColor = System.Drawing.SystemColors.Control
        Me.lblDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDiagnosis.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblDiagnosis.ForeColor = System.Drawing.Color.Black
        Me.lblDiagnosis.Location = New System.Drawing.Point(4, 224)
        Me.lblDiagnosis.Name = "lblDiagnosis"
        Me.lblDiagnosis.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblDiagnosis.Size = New System.Drawing.Size(551, 24)
        Me.lblDiagnosis.TabIndex = 557
        Me.lblDiagnosis.Text = "Diagnosis"
        Me.lblDiagnosis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLmp
        '
        Me.txtLmp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLmp.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtLmp.Location = New System.Drawing.Point(123, 30)
        Me.txtLmp.Mask = "00/00/0000"
        Me.txtLmp.Name = "txtLmp"
        Me.txtLmp.PromptChar = Global.Microsoft.VisualBasic.ChrW(45)
        Me.txtLmp.Size = New System.Drawing.Size(155, 24)
        Me.txtLmp.TabIndex = 0
        Me.txtLmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtLmp.ValidatingType = GetType(Date)
        '
        'txtOxygenLevel
        '
        Me.txtOxygenLevel.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtOxygenLevel.Location = New System.Drawing.Point(123, 108)
        Me.txtOxygenLevel.Name = "txtOxygenLevel"
        Me.txtOxygenLevel.Size = New System.Drawing.Size(155, 24)
        Me.txtOxygenLevel.TabIndex = 3
        '
        'lblOxygenLevel
        '
        Me.lblOxygenLevel.BackColor = System.Drawing.SystemColors.Control
        Me.lblOxygenLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOxygenLevel.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblOxygenLevel.ForeColor = System.Drawing.Color.Black
        Me.lblOxygenLevel.Location = New System.Drawing.Point(4, 108)
        Me.lblOxygenLevel.Name = "lblOxygenLevel"
        Me.lblOxygenLevel.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblOxygenLevel.Size = New System.Drawing.Size(120, 24)
        Me.lblOxygenLevel.TabIndex = 562
        Me.lblOxygenLevel.Text = "Oxygen Level"
        Me.lblOxygenLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkFitToWork
        '
        Me.chkFitToWork.AutoSize = True
        Me.chkFitToWork.BackColor = System.Drawing.SystemColors.Control
        Me.chkFitToWork.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkFitToWork.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.chkFitToWork.Location = New System.Drawing.Point(287, 87)
        Me.chkFitToWork.Name = "chkFitToWork"
        Me.chkFitToWork.Size = New System.Drawing.Size(15, 14)
        Me.chkFitToWork.TabIndex = 6
        Me.chkFitToWork.UseVisualStyleBackColor = False
        '
        'lblFitToWork
        '
        Me.lblFitToWork.BackColor = System.Drawing.SystemColors.Control
        Me.lblFitToWork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFitToWork.ForeColor = System.Drawing.Color.Black
        Me.lblFitToWork.Location = New System.Drawing.Point(281, 82)
        Me.lblFitToWork.Name = "lblFitToWork"
        Me.lblFitToWork.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.lblFitToWork.Size = New System.Drawing.Size(274, 24)
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
        Me.chkSentHome.Location = New System.Drawing.Point(287, 113)
        Me.chkSentHome.Name = "chkSentHome"
        Me.chkSentHome.Size = New System.Drawing.Size(15, 14)
        Me.chkSentHome.TabIndex = 7
        Me.chkSentHome.UseVisualStyleBackColor = False
        '
        'lblSentHome
        '
        Me.lblSentHome.BackColor = System.Drawing.SystemColors.Control
        Me.lblSentHome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSentHome.ForeColor = System.Drawing.Color.Black
        Me.lblSentHome.Location = New System.Drawing.Point(281, 108)
        Me.lblSentHome.Name = "lblSentHome"
        Me.lblSentHome.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.lblSentHome.Size = New System.Drawing.Size(274, 24)
        Me.lblSentHome.TabIndex = 7
        Me.lblSentHome.Text = "Sent Home"
        Me.lblSentHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlImage
        '
        Me.pnlImage.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlImage.Controls.Add(Me.lblFilename)
        Me.pnlImage.Controls.Add(Me.picImage)
        Me.pnlImage.Controls.Add(Me.btnNext)
        Me.pnlImage.Controls.Add(Me.btnPrevious)
        Me.pnlImage.Controls.Add(Me.btnRemove)
        Me.pnlImage.Controls.Add(Me.btnAttach)
        Me.pnlImage.Location = New System.Drawing.Point(558, 4)
        Me.pnlImage.Name = "pnlImage"
        Me.pnlImage.Size = New System.Drawing.Size(280, 309)
        Me.pnlImage.TabIndex = 568
        '
        'lblFilename
        '
        Me.lblFilename.AutoSize = True
        Me.lblFilename.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblFilename.Location = New System.Drawing.Point(2, 2)
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Size = New System.Drawing.Size(58, 13)
        Me.lblFilename.TabIndex = 571
        Me.lblFilename.Text = "Filename"
        '
        'picImage
        '
        Me.picImage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picImage.BackColor = System.Drawing.Color.White
        Me.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picImage.ErrorImage = Nothing
        Me.picImage.InitialImage = Nothing
        Me.picImage.Location = New System.Drawing.Point(4, 18)
        Me.picImage.Name = "picImage"
        Me.picImage.Size = New System.Drawing.Size(270, 259)
        Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImage.TabIndex = 299
        Me.picImage.TabStop = False
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNext.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnNext.DefaultScheme = False
        Me.btnNext.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnNext.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Hint = "Next"
        Me.btnNext.Location = New System.Drawing.Point(30, 279)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnNext.Size = New System.Drawing.Size(26, 26)
        Me.btnNext.TabIndex = 298
        Me.btnNext.TabStop = False
        Me.btnNext.Text = ">"
        '
        'btnPrevious
        '
        Me.btnPrevious.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrevious.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnPrevious.DefaultScheme = False
        Me.btnPrevious.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnPrevious.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevious.Hint = "Previous"
        Me.btnPrevious.Location = New System.Drawing.Point(3, 279)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnPrevious.Size = New System.Drawing.Size(26, 26)
        Me.btnPrevious.TabIndex = 297
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
        Me.btnRemove.Hint = "Remove"
        Me.btnRemove.Location = New System.Drawing.Point(212, 279)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemove.Size = New System.Drawing.Size(63, 26)
        Me.btnRemove.TabIndex = 211
        Me.btnRemove.TabStop = False
        Me.btnRemove.Text = "Remove"
        '
        'btnAttach
        '
        Me.btnAttach.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAttach.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.btnAttach.DefaultScheme = False
        Me.btnAttach.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnAttach.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnAttach.Hint = "Attach pictures"
        Me.btnAttach.Image = Global.HealthInformationSystem.My.Resources.Resources.Load
        Me.btnAttach.Location = New System.Drawing.Point(134, 279)
        Me.btnAttach.Name = "btnAttach"
        Me.btnAttach.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAttach.Size = New System.Drawing.Size(76, 26)
        Me.btnAttach.TabIndex = 210
        Me.btnAttach.TabStop = False
        Me.btnAttach.Text = "Attach"
        '
        'txtEncoder
        '
        Me.txtEncoder.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtEncoder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEncoder.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtEncoder.ForeColor = System.Drawing.Color.Black
        Me.txtEncoder.Location = New System.Drawing.Point(400, 4)
        Me.txtEncoder.Name = "txtEncoder"
        Me.txtEncoder.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtEncoder.Size = New System.Drawing.Size(155, 24)
        Me.txtEncoder.TabIndex = 570
        Me.txtEncoder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEncoder
        '
        Me.lblEncoder.BackColor = System.Drawing.SystemColors.Control
        Me.lblEncoder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEncoder.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblEncoder.ForeColor = System.Drawing.Color.Black
        Me.lblEncoder.Location = New System.Drawing.Point(281, 4)
        Me.lblEncoder.Name = "lblEncoder"
        Me.lblEncoder.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEncoder.Size = New System.Drawing.Size(120, 24)
        Me.lblEncoder.TabIndex = 569
        Me.lblEncoder.Text = "Encoded by"
        Me.lblEncoder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFileCount
        '
        Me.lblFileCount.AutoSize = True
        Me.lblFileCount.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblFileCount.Location = New System.Drawing.Point(1, 342)
        Me.lblFileCount.Name = "lblFileCount"
        Me.lblFileCount.Size = New System.Drawing.Size(64, 13)
        Me.lblFileCount.TabIndex = 572
        Me.lblFileCount.Text = "File Count"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(748, 329)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 573
        Me.btnClose.Text = "Close"
        '
        'ofdRecDetail
        '
        Me.ofdRecDetail.Filter = "JPEGs (*.jpg, *.jpeg) | *.jpg; *.jpeg |GIFs (*.gif) | *.gif |Bitmaps (*.bmp) | *." & _
    "bmp |All Images (*.*) | *.jpg; *.jpeg; *.gif; *.bmp; *.png"
        Me.ofdRecDetail.FilterIndex = 4
        Me.ofdRecDetail.Multiselect = True
        Me.ofdRecDetail.Title = "Select image attachments"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancel.DefaultScheme = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Hint = "Cancel changes"
        Me.btnCancel.Image = Global.HealthInformationSystem.My.Resources.Resources.Undo
        Me.btnCancel.Location = New System.Drawing.Point(556, 329)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnCancel.Size = New System.Drawing.Size(90, 32)
        Me.btnCancel.TabIndex = 574
        Me.btnCancel.Text = "Cancel"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDelete.DefaultScheme = True
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Hint = "Delete"
        Me.btnDelete.Image = Global.HealthInformationSystem.My.Resources.Resources._Erase
        Me.btnDelete.Location = New System.Drawing.Point(652, 329)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 572
        Me.btnDelete.Text = "Delete"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSave.DefaultScheme = True
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSave.Hint = "Save"
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(460, 329)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 571
        Me.btnSave.Text = " Save"
        '
        'frmEmpRecordDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(842, 366)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblFileCount)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtEncoder)
        Me.Controls.Add(Me.lblEncoder)
        Me.Controls.Add(Me.pnlImage)
        Me.Controls.Add(Me.chkSentHome)
        Me.Controls.Add(Me.lblSentHome)
        Me.Controls.Add(Me.chkFitToWork)
        Me.Controls.Add(Me.lblFitToWork)
        Me.Controls.Add(Me.txtOxygenLevel)
        Me.Controls.Add(Me.lblOxygenLevel)
        Me.Controls.Add(Me.txtLmp)
        Me.Controls.Add(Me.txtDiagnosis)
        Me.Controls.Add(Me.lblDiagnosis)
        Me.Controls.Add(Me.txtChiefComplaint)
        Me.Controls.Add(Me.txtRespiratoryRate)
        Me.Controls.Add(Me.txtPulseRate)
        Me.Controls.Add(Me.txtBloodPressure)
        Me.Controls.Add(Me.txtTemperature)
        Me.Controls.Add(Me.lblChiefComplaint)
        Me.Controls.Add(Me.lblRespiratoryRate)
        Me.Controls.Add(Me.lblPulseRate)
        Me.Controls.Add(Me.lblBloodPressure)
        Me.Controls.Add(Me.lblTemperature)
        Me.Controls.Add(Me.lblLmp)
        Me.Controls.Add(Me.txtDateCreated)
        Me.Controls.Add(Me.lblDateCreated)
        Me.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEmpRecordDetail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.pnlImage.ResumeLayout(False)
        Me.pnlImage.PerformLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDateCreated As System.Windows.Forms.Label
    Friend WithEvents lblDateCreated As System.Windows.Forms.Label
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
    Friend WithEvents pnlImage As System.Windows.Forms.Panel
    Friend WithEvents picImage As System.Windows.Forms.PictureBox
    Friend WithEvents btnNext As PinkieControls.ButtonXP
    Friend WithEvents btnPrevious As PinkieControls.ButtonXP
    Friend WithEvents btnRemove As PinkieControls.ButtonXP
    Friend WithEvents btnAttach As PinkieControls.ButtonXP
    Friend WithEvents txtEncoder As System.Windows.Forms.Label
    Friend WithEvents lblEncoder As System.Windows.Forms.Label
    Friend WithEvents lblFilename As System.Windows.Forms.Label
    Friend WithEvents lblFileCount As System.Windows.Forms.Label
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents ofdRecDetail As System.Windows.Forms.OpenFileDialog
End Class
