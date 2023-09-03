<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IndividualRecordHdr
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IndividualRecordHdr))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbName = New SergeUtils.EasyCompletionComboBox()
        Me.lblBloodType = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblEmerContactName = New System.Windows.Forms.Label()
        Me.lblEmerContactNumber = New System.Windows.Forms.Label()
        Me.lblEmerContactAddress = New System.Windows.Forms.Label()
        Me.lblEmer = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.txtAge = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.Label()
        Me.lblCivilStatus = New System.Windows.Forms.Label()
        Me.txtCivilStatus = New System.Windows.Forms.Label()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.txtDepartment = New System.Windows.Forms.Label()
        Me.lblEmploymentStatus = New System.Windows.Forms.Label()
        Me.txtEmploymentStatus = New System.Windows.Forms.Label()
        Me.lblAllergies = New System.Windows.Forms.Label()
        Me.lblSection = New System.Windows.Forms.Label()
        Me.txtSection = New System.Windows.Forms.Label()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.txtPosition = New System.Windows.Forms.Label()
        Me.txtBloodType = New System.Windows.Forms.TextBox()
        Me.txtAllergies = New System.Windows.Forms.TextBox()
        Me.txtEmerContactName = New System.Windows.Forms.TextBox()
        Me.txtEmerContactNumber = New System.Windows.Forms.TextBox()
        Me.txtEmerContactAddress = New System.Windows.Forms.TextBox()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.lblContactNumber = New System.Windows.Forms.Label()
        Me.txtContactNumber = New System.Windows.Forms.TextBox()
        Me.btnClear = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.btnFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.btnPrevItem = New System.Windows.Forms.ToolStripButton()
        Me.sep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtPageNumber = New System.Windows.Forms.ToolStripTextBox()
        Me.txtTotalPageNumber = New System.Windows.Forms.ToolStripLabel()
        Me.sep6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNextItem = New System.Windows.Forms.ToolStripButton()
        Me.btnLastItem = New System.Windows.Forms.ToolStripButton()
        Me.btnGo = New System.Windows.Forms.ToolStripButton()
        Me.bindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.sep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.sep3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.sep4 = New System.Windows.Forms.ToolStripSeparator()
        Me.sep5 = New System.Windows.Forms.ToolStripSeparator()
        Me.pnlRight = New System.Windows.Forms.Panel()
        Me.tabCtrl = New System.Windows.Forms.TabControl()
        Me.tpApe = New System.Windows.Forms.TabPage()
        Me.dgvApe = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlLeft.SuspendLayout()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator.SuspendLayout()
        Me.pnlRight.SuspendLayout()
        Me.tabCtrl.SuspendLayout()
        Me.tpApe.SuspendLayout()
        CType(Me.dgvApe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbName
        '
        Me.cmbName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbName.FormattingEnabled = True
        Me.cmbName.Location = New System.Drawing.Point(3, 26)
        Me.cmbName.Name = "cmbName"
        Me.cmbName.Size = New System.Drawing.Size(392, 23)
        Me.cmbName.TabIndex = 0
        '
        'lblBloodType
        '
        Me.lblBloodType.BackColor = System.Drawing.SystemColors.Control
        Me.lblBloodType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBloodType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBloodType.ForeColor = System.Drawing.Color.Black
        Me.lblBloodType.Location = New System.Drawing.Point(3, 299)
        Me.lblBloodType.Name = "lblBloodType"
        Me.lblBloodType.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblBloodType.Size = New System.Drawing.Size(142, 24)
        Me.lblBloodType.TabIndex = 403
        Me.lblBloodType.Text = "Blood Type"
        Me.lblBloodType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.SystemColors.Control
        Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(3, 3)
        Me.lblName.Name = "lblName"
        Me.lblName.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblName.Size = New System.Drawing.Size(392, 24)
        Me.lblName.TabIndex = 523
        Me.lblName.Text = "Employee ID / Name"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmerContactName
        '
        Me.lblEmerContactName.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmerContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmerContactName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmerContactName.ForeColor = System.Drawing.Color.Black
        Me.lblEmerContactName.Location = New System.Drawing.Point(3, 414)
        Me.lblEmerContactName.Margin = New System.Windows.Forms.Padding(3, 7, 0, 0)
        Me.lblEmerContactName.Name = "lblEmerContactName"
        Me.lblEmerContactName.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmerContactName.Size = New System.Drawing.Size(142, 24)
        Me.lblEmerContactName.TabIndex = 524
        Me.lblEmerContactName.Text = "Name"
        Me.lblEmerContactName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmerContactNumber
        '
        Me.lblEmerContactNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmerContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmerContactNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmerContactNumber.ForeColor = System.Drawing.Color.Black
        Me.lblEmerContactNumber.Location = New System.Drawing.Point(3, 440)
        Me.lblEmerContactNumber.Margin = New System.Windows.Forms.Padding(3, 7, 0, 0)
        Me.lblEmerContactNumber.Name = "lblEmerContactNumber"
        Me.lblEmerContactNumber.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmerContactNumber.Size = New System.Drawing.Size(142, 24)
        Me.lblEmerContactNumber.TabIndex = 526
        Me.lblEmerContactNumber.Text = "Contact Number"
        Me.lblEmerContactNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmerContactAddress
        '
        Me.lblEmerContactAddress.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmerContactAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmerContactAddress.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmerContactAddress.ForeColor = System.Drawing.Color.Black
        Me.lblEmerContactAddress.Location = New System.Drawing.Point(3, 466)
        Me.lblEmerContactAddress.Margin = New System.Windows.Forms.Padding(3, 7, 0, 0)
        Me.lblEmerContactAddress.Name = "lblEmerContactAddress"
        Me.lblEmerContactAddress.Padding = New System.Windows.Forms.Padding(3, 7, 0, 0)
        Me.lblEmerContactAddress.Size = New System.Drawing.Size(142, 55)
        Me.lblEmerContactAddress.TabIndex = 528
        Me.lblEmerContactAddress.Text = "Registered Address"
        '
        'lblEmer
        '
        Me.lblEmer.BackColor = System.Drawing.Color.DarkSlateGray
        Me.lblEmer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmer.ForeColor = System.Drawing.Color.White
        Me.lblEmer.Location = New System.Drawing.Point(3, 390)
        Me.lblEmer.Name = "lblEmer"
        Me.lblEmer.Size = New System.Drawing.Size(392, 22)
        Me.lblEmer.TabIndex = 530
        Me.lblEmer.Text = "Emergency Contact Reference"
        Me.lblEmer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAge
        '
        Me.lblAge.BackColor = System.Drawing.SystemColors.Control
        Me.lblAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAge.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAge.ForeColor = System.Drawing.Color.Black
        Me.lblAge.Location = New System.Drawing.Point(3, 164)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblAge.Size = New System.Drawing.Size(142, 24)
        Me.lblAge.TabIndex = 531
        Me.lblAge.Text = "Age"
        Me.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAge
        '
        Me.txtAge.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAge.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAge.ForeColor = System.Drawing.Color.Black
        Me.txtAge.Location = New System.Drawing.Point(144, 164)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtAge.Size = New System.Drawing.Size(251, 24)
        Me.txtAge.TabIndex = 532
        Me.txtAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddress
        '
        Me.lblAddress.BackColor = System.Drawing.SystemColors.Control
        Me.lblAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAddress.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress.ForeColor = System.Drawing.Color.Black
        Me.lblAddress.Location = New System.Drawing.Point(3, 190)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Padding = New System.Windows.Forms.Padding(3, 5, 0, 0)
        Me.lblAddress.Size = New System.Drawing.Size(142, 55)
        Me.lblAddress.TabIndex = 533
        Me.lblAddress.Text = "Local Address"
        '
        'txtAddress
        '
        Me.txtAddress.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.ForeColor = System.Drawing.Color.Black
        Me.txtAddress.Location = New System.Drawing.Point(144, 190)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Padding = New System.Windows.Forms.Padding(3, 5, 0, 0)
        Me.txtAddress.Size = New System.Drawing.Size(251, 55)
        Me.txtAddress.TabIndex = 534
        '
        'lblCivilStatus
        '
        Me.lblCivilStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblCivilStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCivilStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCivilStatus.ForeColor = System.Drawing.Color.Black
        Me.lblCivilStatus.Location = New System.Drawing.Point(3, 247)
        Me.lblCivilStatus.Name = "lblCivilStatus"
        Me.lblCivilStatus.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblCivilStatus.Size = New System.Drawing.Size(142, 24)
        Me.lblCivilStatus.TabIndex = 535
        Me.lblCivilStatus.Text = "Civil Status"
        Me.lblCivilStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCivilStatus
        '
        Me.txtCivilStatus.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCivilStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCivilStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCivilStatus.ForeColor = System.Drawing.Color.Black
        Me.txtCivilStatus.Location = New System.Drawing.Point(144, 247)
        Me.txtCivilStatus.Name = "txtCivilStatus"
        Me.txtCivilStatus.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtCivilStatus.Size = New System.Drawing.Size(251, 24)
        Me.txtCivilStatus.TabIndex = 536
        Me.txtCivilStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDepartment
        '
        Me.lblDepartment.BackColor = System.Drawing.SystemColors.Control
        Me.lblDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDepartment.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartment.ForeColor = System.Drawing.Color.Black
        Me.lblDepartment.Location = New System.Drawing.Point(3, 60)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblDepartment.Size = New System.Drawing.Size(142, 24)
        Me.lblDepartment.TabIndex = 537
        Me.lblDepartment.Text = "Department"
        Me.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDepartment
        '
        Me.txtDepartment.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepartment.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartment.ForeColor = System.Drawing.Color.Black
        Me.txtDepartment.Location = New System.Drawing.Point(144, 60)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtDepartment.Size = New System.Drawing.Size(251, 24)
        Me.txtDepartment.TabIndex = 538
        Me.txtDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmploymentStatus
        '
        Me.lblEmploymentStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmploymentStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmploymentStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmploymentStatus.ForeColor = System.Drawing.Color.Black
        Me.lblEmploymentStatus.Location = New System.Drawing.Point(3, 138)
        Me.lblEmploymentStatus.Name = "lblEmploymentStatus"
        Me.lblEmploymentStatus.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmploymentStatus.Size = New System.Drawing.Size(142, 24)
        Me.lblEmploymentStatus.TabIndex = 539
        Me.lblEmploymentStatus.Text = "Employment Status"
        Me.lblEmploymentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmploymentStatus
        '
        Me.txtEmploymentStatus.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtEmploymentStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmploymentStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmploymentStatus.ForeColor = System.Drawing.Color.Black
        Me.txtEmploymentStatus.Location = New System.Drawing.Point(144, 138)
        Me.txtEmploymentStatus.Name = "txtEmploymentStatus"
        Me.txtEmploymentStatus.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtEmploymentStatus.Size = New System.Drawing.Size(251, 24)
        Me.txtEmploymentStatus.TabIndex = 540
        Me.txtEmploymentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAllergies
        '
        Me.lblAllergies.BackColor = System.Drawing.SystemColors.Control
        Me.lblAllergies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAllergies.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAllergies.ForeColor = System.Drawing.Color.Black
        Me.lblAllergies.Location = New System.Drawing.Point(3, 325)
        Me.lblAllergies.Name = "lblAllergies"
        Me.lblAllergies.Padding = New System.Windows.Forms.Padding(3, 7, 0, 0)
        Me.lblAllergies.Size = New System.Drawing.Size(142, 55)
        Me.lblAllergies.TabIndex = 541
        Me.lblAllergies.Text = "Allergies"
        '
        'lblSection
        '
        Me.lblSection.BackColor = System.Drawing.SystemColors.Control
        Me.lblSection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSection.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSection.ForeColor = System.Drawing.Color.Black
        Me.lblSection.Location = New System.Drawing.Point(3, 86)
        Me.lblSection.Name = "lblSection"
        Me.lblSection.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblSection.Size = New System.Drawing.Size(142, 24)
        Me.lblSection.TabIndex = 542
        Me.lblSection.Text = "Section"
        Me.lblSection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSection
        '
        Me.txtSection.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtSection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSection.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSection.ForeColor = System.Drawing.Color.Black
        Me.txtSection.Location = New System.Drawing.Point(144, 86)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtSection.Size = New System.Drawing.Size(251, 24)
        Me.txtSection.TabIndex = 543
        Me.txtSection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPosition
        '
        Me.lblPosition.BackColor = System.Drawing.SystemColors.Control
        Me.lblPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPosition.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosition.ForeColor = System.Drawing.Color.Black
        Me.lblPosition.Location = New System.Drawing.Point(3, 112)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblPosition.Size = New System.Drawing.Size(142, 24)
        Me.lblPosition.TabIndex = 544
        Me.lblPosition.Text = "Position"
        Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPosition
        '
        Me.txtPosition.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPosition.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPosition.ForeColor = System.Drawing.Color.Black
        Me.txtPosition.Location = New System.Drawing.Point(144, 112)
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtPosition.Size = New System.Drawing.Size(251, 24)
        Me.txtPosition.TabIndex = 545
        Me.txtPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBloodType
        '
        Me.txtBloodType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBloodType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBloodType.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBloodType.Location = New System.Drawing.Point(144, 299)
        Me.txtBloodType.Name = "txtBloodType"
        Me.txtBloodType.Size = New System.Drawing.Size(251, 24)
        Me.txtBloodType.TabIndex = 2
        '
        'txtAllergies
        '
        Me.txtAllergies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAllergies.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAllergies.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAllergies.Location = New System.Drawing.Point(144, 325)
        Me.txtAllergies.Multiline = True
        Me.txtAllergies.Name = "txtAllergies"
        Me.txtAllergies.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAllergies.Size = New System.Drawing.Size(251, 55)
        Me.txtAllergies.TabIndex = 3
        '
        'txtEmerContactName
        '
        Me.txtEmerContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmerContactName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmerContactName.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmerContactName.Location = New System.Drawing.Point(144, 414)
        Me.txtEmerContactName.Name = "txtEmerContactName"
        Me.txtEmerContactName.Size = New System.Drawing.Size(251, 24)
        Me.txtEmerContactName.TabIndex = 4
        '
        'txtEmerContactNumber
        '
        Me.txtEmerContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmerContactNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmerContactNumber.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmerContactNumber.Location = New System.Drawing.Point(144, 440)
        Me.txtEmerContactNumber.Name = "txtEmerContactNumber"
        Me.txtEmerContactNumber.Size = New System.Drawing.Size(251, 24)
        Me.txtEmerContactNumber.TabIndex = 5
        '
        'txtEmerContactAddress
        '
        Me.txtEmerContactAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmerContactAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmerContactAddress.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmerContactAddress.Location = New System.Drawing.Point(144, 466)
        Me.txtEmerContactAddress.Margin = New System.Windows.Forms.Padding(0)
        Me.txtEmerContactAddress.Multiline = True
        Me.txtEmerContactAddress.Name = "txtEmerContactAddress"
        Me.txtEmerContactAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEmerContactAddress.Size = New System.Drawing.Size(251, 55)
        Me.txtEmerContactAddress.TabIndex = 6
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(305, 530)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Close"
        '
        'pnlLeft
        '
        Me.pnlLeft.BackColor = System.Drawing.Color.LightGray
        Me.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLeft.Controls.Add(Me.lblContactNumber)
        Me.pnlLeft.Controls.Add(Me.txtContactNumber)
        Me.pnlLeft.Controls.Add(Me.btnClear)
        Me.pnlLeft.Controls.Add(Me.lblEmerContactName)
        Me.pnlLeft.Controls.Add(Me.lblBloodType)
        Me.pnlLeft.Controls.Add(Me.lblAllergies)
        Me.pnlLeft.Controls.Add(Me.lblEmerContactNumber)
        Me.pnlLeft.Controls.Add(Me.lblEmerContactAddress)
        Me.pnlLeft.Controls.Add(Me.btnClose)
        Me.pnlLeft.Controls.Add(Me.btnSave)
        Me.pnlLeft.Controls.Add(Me.txtEmerContactAddress)
        Me.pnlLeft.Controls.Add(Me.txtEmerContactNumber)
        Me.pnlLeft.Controls.Add(Me.txtEmerContactName)
        Me.pnlLeft.Controls.Add(Me.txtAllergies)
        Me.pnlLeft.Controls.Add(Me.txtBloodType)
        Me.pnlLeft.Controls.Add(Me.txtPosition)
        Me.pnlLeft.Controls.Add(Me.lblPosition)
        Me.pnlLeft.Controls.Add(Me.txtSection)
        Me.pnlLeft.Controls.Add(Me.lblSection)
        Me.pnlLeft.Controls.Add(Me.txtEmploymentStatus)
        Me.pnlLeft.Controls.Add(Me.lblEmploymentStatus)
        Me.pnlLeft.Controls.Add(Me.txtDepartment)
        Me.pnlLeft.Controls.Add(Me.lblDepartment)
        Me.pnlLeft.Controls.Add(Me.txtCivilStatus)
        Me.pnlLeft.Controls.Add(Me.lblCivilStatus)
        Me.pnlLeft.Controls.Add(Me.txtAddress)
        Me.pnlLeft.Controls.Add(Me.lblAddress)
        Me.pnlLeft.Controls.Add(Me.txtAge)
        Me.pnlLeft.Controls.Add(Me.lblAge)
        Me.pnlLeft.Controls.Add(Me.lblEmer)
        Me.pnlLeft.Controls.Add(Me.lblName)
        Me.pnlLeft.Controls.Add(Me.cmbName)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(400, 768)
        Me.pnlLeft.TabIndex = 0
        '
        'lblContactNumber
        '
        Me.lblContactNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblContactNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContactNumber.ForeColor = System.Drawing.Color.Black
        Me.lblContactNumber.Location = New System.Drawing.Point(3, 273)
        Me.lblContactNumber.Name = "lblContactNumber"
        Me.lblContactNumber.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblContactNumber.Size = New System.Drawing.Size(142, 24)
        Me.lblContactNumber.TabIndex = 556
        Me.lblContactNumber.Text = "Contact Number"
        Me.lblContactNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContactNumber
        '
        Me.txtContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtContactNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContactNumber.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactNumber.Location = New System.Drawing.Point(144, 273)
        Me.txtContactNumber.Name = "txtContactNumber"
        Me.txtContactNumber.Size = New System.Drawing.Size(251, 24)
        Me.txtContactNumber.TabIndex = 1
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnClear.DefaultScheme = True
        Me.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClear.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClear.Hint = "Clear form"
        Me.btnClear.Image = Global.HealthInformationSystem.My.Resources.Resources.Cancel
        Me.btnClear.Location = New System.Drawing.Point(209, 530)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClear.Size = New System.Drawing.Size(90, 32)
        Me.btnClear.TabIndex = 8
        Me.btnClear.Text = " Clear"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnSave.DefaultScheme = True
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnSave.Hint = "Save employee record"
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(113, 530)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = " Save"
        '
        'btnFirstItem
        '
        Me.btnFirstItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFirstItem.Image = CType(resources.GetObject("btnFirstItem.Image"), System.Drawing.Image)
        Me.btnFirstItem.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.btnFirstItem.Name = "btnFirstItem"
        Me.btnFirstItem.RightToLeftAutoMirrorImage = True
        Me.btnFirstItem.Size = New System.Drawing.Size(23, 23)
        Me.btnFirstItem.Text = "Move first"
        '
        'btnPrevItem
        '
        Me.btnPrevItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnPrevItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPrevItem.Image = CType(resources.GetObject("btnPrevItem.Image"), System.Drawing.Image)
        Me.btnPrevItem.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.btnPrevItem.Name = "btnPrevItem"
        Me.btnPrevItem.RightToLeftAutoMirrorImage = True
        Me.btnPrevItem.Size = New System.Drawing.Size(23, 23)
        Me.btnPrevItem.Text = "Move previous"
        '
        'sep2
        '
        Me.sep2.Name = "sep2"
        Me.sep2.Size = New System.Drawing.Size(6, 25)
        '
        'txtPageNumber
        '
        Me.txtPageNumber.AccessibleName = "Position"
        Me.txtPageNumber.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.txtPageNumber.AutoSize = False
        Me.txtPageNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPageNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.txtPageNumber.Name = "txtPageNumber"
        Me.txtPageNumber.Size = New System.Drawing.Size(30, 23)
        Me.txtPageNumber.Text = "0"
        Me.txtPageNumber.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPageNumber.ToolTipText = "Current page"
        '
        'txtTotalPageNumber
        '
        Me.txtTotalPageNumber.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.txtTotalPageNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTotalPageNumber.Margin = New System.Windows.Forms.Padding(0)
        Me.txtTotalPageNumber.Name = "txtTotalPageNumber"
        Me.txtTotalPageNumber.Size = New System.Drawing.Size(21, 25)
        Me.txtTotalPageNumber.Text = "of "
        Me.txtTotalPageNumber.ToolTipText = "Total page number"
        '
        'sep6
        '
        Me.sep6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.sep6.Name = "sep6"
        Me.sep6.Size = New System.Drawing.Size(6, 25)
        '
        'btnNextItem
        '
        Me.btnNextItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNextItem.Image = CType(resources.GetObject("btnNextItem.Image"), System.Drawing.Image)
        Me.btnNextItem.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.btnNextItem.Name = "btnNextItem"
        Me.btnNextItem.RightToLeftAutoMirrorImage = True
        Me.btnNextItem.Size = New System.Drawing.Size(23, 23)
        Me.btnNextItem.Text = "Move next"
        '
        'btnLastItem
        '
        Me.btnLastItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLastItem.Image = CType(resources.GetObject("btnLastItem.Image"), System.Drawing.Image)
        Me.btnLastItem.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.btnLastItem.Name = "btnLastItem"
        Me.btnLastItem.RightToLeftAutoMirrorImage = True
        Me.btnLastItem.Size = New System.Drawing.Size(23, 23)
        Me.btnLastItem.Text = "Move last"
        '
        'btnGo
        '
        Me.btnGo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnGo.AutoSize = False
        Me.btnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnGo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnGo.Image = CType(resources.GetObject("btnGo.Image"), System.Drawing.Image)
        Me.btnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGo.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(35, 23)
        Me.btnGo.Text = "Go"
        Me.btnGo.ToolTipText = "Go to page number specified"
        '
        'bindingNavigator
        '
        Me.bindingNavigator.AddNewItem = Nothing
        Me.bindingNavigator.AutoSize = False
        Me.bindingNavigator.BackColor = System.Drawing.Color.White
        Me.bindingNavigator.CountItem = Me.txtTotalPageNumber
        Me.bindingNavigator.CountItemFormat = "of "
        Me.bindingNavigator.DeleteItem = Nothing
        Me.bindingNavigator.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.bindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.bindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.sep1, Me.btnEdit, Me.sep2, Me.btnDelete, Me.sep3, Me.btnRefresh, Me.btnGo, Me.sep4, Me.btnLastItem, Me.btnNextItem, Me.sep5, Me.txtTotalPageNumber, Me.txtPageNumber, Me.sep6, Me.btnPrevItem, Me.btnFirstItem})
        Me.bindingNavigator.Location = New System.Drawing.Point(400, 0)
        Me.bindingNavigator.MoveFirstItem = Me.btnFirstItem
        Me.bindingNavigator.MoveLastItem = Me.btnLastItem
        Me.bindingNavigator.MoveNextItem = Me.btnNextItem
        Me.bindingNavigator.MovePreviousItem = Me.btnPrevItem
        Me.bindingNavigator.Name = "bindingNavigator"
        Me.bindingNavigator.Padding = New System.Windows.Forms.Padding(5, 0, 1, 0)
        Me.bindingNavigator.PositionItem = Me.txtPageNumber
        Me.bindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.bindingNavigator.Size = New System.Drawing.Size(730, 25)
        Me.bindingNavigator.Stretch = True
        Me.bindingNavigator.TabIndex = 560
        Me.bindingNavigator.Text = "PagerPanel"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.btnAdd.Image = Global.HealthInformationSystem.My.Resources.Resources.Create
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(119, 23)
        Me.btnAdd.Text = " Add New Record"
        Me.btnAdd.ToolTipText = "Add new record"
        '
        'sep1
        '
        Me.sep1.Name = "sep1"
        Me.sep1.Size = New System.Drawing.Size(6, 25)
        '
        'btnEdit
        '
        Me.btnEdit.AutoSize = False
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.btnEdit.Image = Global.HealthInformationSystem.My.Resources.Resources.Modify
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(63, 23)
        Me.btnEdit.Text = " Edit"
        Me.btnEdit.ToolTipText = "Edit record"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.btnDelete.Image = Global.HealthInformationSystem.My.Resources.Resources._Erase
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(63, 23)
        Me.btnDelete.Text = " Delete"
        Me.btnDelete.ToolTipText = "Delete record"
        '
        'sep3
        '
        Me.sep3.Name = "sep3"
        Me.sep3.Size = New System.Drawing.Size(6, 25)
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.btnRefresh.Image = Global.HealthInformationSystem.My.Resources.Resources.Sync
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(69, 23)
        Me.btnRefresh.Text = " Refresh"
        '
        'sep4
        '
        Me.sep4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.sep4.Name = "sep4"
        Me.sep4.Size = New System.Drawing.Size(6, 25)
        '
        'sep5
        '
        Me.sep5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.sep5.Name = "sep5"
        Me.sep5.Size = New System.Drawing.Size(6, 25)
        '
        'pnlRight
        '
        Me.pnlRight.BackColor = System.Drawing.Color.White
        Me.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRight.Controls.Add(Me.tabCtrl)
        Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRight.Location = New System.Drawing.Point(400, 25)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(730, 743)
        Me.pnlRight.TabIndex = 557
        '
        'tabCtrl
        '
        Me.tabCtrl.Alignment = System.Windows.Forms.TabAlignment.Right
        Me.tabCtrl.Controls.Add(Me.tpApe)
        Me.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabCtrl.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabCtrl.HotTrack = True
        Me.tabCtrl.Location = New System.Drawing.Point(0, 0)
        Me.tabCtrl.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.tabCtrl.Multiline = True
        Me.tabCtrl.Name = "tabCtrl"
        Me.tabCtrl.Padding = New System.Drawing.Point(20, 3)
        Me.tabCtrl.SelectedIndex = 0
        Me.tabCtrl.ShowToolTips = True
        Me.tabCtrl.Size = New System.Drawing.Size(728, 741)
        Me.tabCtrl.TabIndex = 1
        '
        'tpApe
        '
        Me.tpApe.Controls.Add(Me.dgvApe)
        Me.tpApe.Location = New System.Drawing.Point(4, 4)
        Me.tpApe.Name = "tpApe"
        Me.tpApe.Padding = New System.Windows.Forms.Padding(3)
        Me.tpApe.Size = New System.Drawing.Size(697, 733)
        Me.tpApe.TabIndex = 1
        Me.tpApe.Text = "Annual Physical Exam"
        '
        'dgvApe
        '
        Me.dgvApe.AllowUserToAddRows = False
        Me.dgvApe.AllowUserToDeleteRows = False
        Me.dgvApe.AllowUserToResizeRows = False
        Me.dgvApe.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvApe.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvApe.ColumnHeadersHeight = 25
        Me.dgvApe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvApe.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        Me.dgvApe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvApe.Location = New System.Drawing.Point(3, 3)
        Me.dgvApe.MultiSelect = False
        Me.dgvApe.Name = "dgvApe"
        Me.dgvApe.ReadOnly = True
        Me.dgvApe.RowHeadersVisible = False
        Me.dgvApe.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvApe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvApe.Size = New System.Drawing.Size(691, 727)
        Me.dgvApe.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "RecordId"
        Me.DataGridViewTextBoxColumn1.HeaderText = "#"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 60
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CreatedDate"
        DataGridViewCellStyle2.Format = "MM/dd/yyyy hh:mm tt"
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn2.HeaderText = "Creation Date"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 120
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CreatedByName"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Created By"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "YearId"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Year"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Remarks"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Remarks"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'IndividualRecordHdr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClear
        Me.ClientSize = New System.Drawing.Size(1130, 768)
        Me.Controls.Add(Me.pnlRight)
        Me.Controls.Add(Me.bindingNavigator)
        Me.Controls.Add(Me.pnlLeft)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "IndividualRecordHdr"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Employee Record"
        Me.pnlLeft.ResumeLayout(False)
        Me.pnlLeft.PerformLayout()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingNavigator.ResumeLayout(False)
        Me.bindingNavigator.PerformLayout()
        Me.pnlRight.ResumeLayout(False)
        Me.tabCtrl.ResumeLayout(False)
        Me.tpApe.ResumeLayout(False)
        CType(Me.dgvApe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblBloodType As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblEmerContactName As System.Windows.Forms.Label
    Friend WithEvents lblEmerContactNumber As System.Windows.Forms.Label
    Friend WithEvents lblEmerContactAddress As System.Windows.Forms.Label
    Friend WithEvents lblEmer As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents txtAge As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.Label
    Friend WithEvents lblCivilStatus As System.Windows.Forms.Label
    Friend WithEvents txtCivilStatus As System.Windows.Forms.Label
    Friend WithEvents lblDepartment As System.Windows.Forms.Label
    Friend WithEvents txtDepartment As System.Windows.Forms.Label
    Friend WithEvents lblEmploymentStatus As System.Windows.Forms.Label
    Friend WithEvents txtEmploymentStatus As System.Windows.Forms.Label
    Friend WithEvents lblAllergies As System.Windows.Forms.Label
    Friend WithEvents lblSection As System.Windows.Forms.Label
    Friend WithEvents txtSection As System.Windows.Forms.Label
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents txtPosition As System.Windows.Forms.Label
    Friend WithEvents txtBloodType As System.Windows.Forms.TextBox
    Friend WithEvents txtAllergies As System.Windows.Forms.TextBox
    Friend WithEvents txtEmerContactName As System.Windows.Forms.TextBox
    Friend WithEvents txtEmerContactNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtEmerContactAddress As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents btnClear As PinkieControls.ButtonXP
    Friend WithEvents lblContactNumber As Label
    Friend WithEvents txtContactNumber As TextBox
    Friend WithEvents btnFirstItem As ToolStripButton
    Friend WithEvents btnPrevItem As ToolStripButton
    Friend WithEvents sep2 As ToolStripSeparator
    Friend WithEvents txtPageNumber As ToolStripTextBox
    Friend WithEvents txtTotalPageNumber As ToolStripLabel
    Friend WithEvents sep6 As ToolStripSeparator
    Friend WithEvents btnNextItem As ToolStripButton
    Friend WithEvents btnLastItem As ToolStripButton
    Friend WithEvents btnGo As ToolStripButton
    Friend WithEvents bindingNavigator As BindingNavigator
    Friend WithEvents pnlRight As Panel
    Friend WithEvents btnAdd As ToolStripButton
    Friend WithEvents sep1 As ToolStripSeparator
    Friend WithEvents btnEdit As ToolStripButton
    Friend WithEvents btnDelete As ToolStripButton
    Friend WithEvents sep4 As ToolStripSeparator
    Friend WithEvents sep5 As ToolStripSeparator
    Friend WithEvents sep3 As ToolStripSeparator
    Friend WithEvents btnRefresh As ToolStripButton
    Friend WithEvents tabCtrl As TabControl
    Friend WithEvents tpApe As TabPage
    Friend WithEvents dgvApe As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
End Class
