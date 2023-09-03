<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHealthScreeningHeader
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHealthScreeningHeader))
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.btnReset = New PinkieControls.ButtonXP()
        Me.btnSearch = New PinkieControls.ButtonXP()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.pnlText = New System.Windows.Forms.Panel()
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.cmbSearchCriteria = New System.Windows.Forms.ComboBox()
        Me.bindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.txtTotalPageNumber = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.txtPageNumber = New System.Windows.Forms.ToolStripTextBox()
        Me.tssPageNumber = New System.Windows.Forms.ToolStripSeparator()
        Me.tssGo = New System.Windows.Forms.ToolStripSeparator()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.ColScreenId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColScreenDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColEmployeeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDiagnosis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLeaveTypeId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLeaveType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFitToWork = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColScreenByName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlDate = New System.Windows.Forms.Panel()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.lblDateTo = New System.Windows.Forms.Label()
        Me.lblDateFrom = New System.Windows.Forms.Label()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.pnlEmployeeName = New System.Windows.Forms.Panel()
        Me.cmbEmployeeName = New SergeUtils.EasyCompletionComboBox()
        Me.btnRefresh = New PinkieControls.ButtonXP()
        Me.btnEdit = New PinkieControls.ButtonXP()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.btnGo = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnAdd = New PinkieControls.ButtonXP()
        Me.pnlTop.SuspendLayout()
        Me.pnlText.SuspendLayout()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDate.SuspendLayout()
        Me.pnlEmployeeName.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTop.Controls.Add(Me.pnlText)
        Me.pnlTop.Controls.Add(Me.btnReset)
        Me.pnlTop.Controls.Add(Me.btnSearch)
        Me.pnlTop.Controls.Add(Me.lblDepartment)
        Me.pnlTop.Controls.Add(Me.cmbSearchCriteria)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1200, 35)
        Me.pnlTop.TabIndex = 0
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnReset.DefaultScheme = False
        Me.btnReset.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnReset.Hint = "Reset"
        Me.btnReset.Location = New System.Drawing.Point(669, 3)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnReset.Size = New System.Drawing.Size(76, 27)
        Me.btnReset.TabIndex = 545
        Me.btnReset.TabStop = False
        Me.btnReset.Text = "Reset"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnSearch.DefaultScheme = False
        Me.btnSearch.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnSearch.Hint = "Search"
        Me.btnSearch.Location = New System.Drawing.Point(590, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSearch.Size = New System.Drawing.Size(76, 27)
        Me.btnSearch.TabIndex = 544
        Me.btnSearch.TabStop = False
        Me.btnSearch.Text = "Search"
        '
        'lblDepartment
        '
        Me.lblDepartment.BackColor = System.Drawing.SystemColors.Control
        Me.lblDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDepartment.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartment.ForeColor = System.Drawing.Color.Black
        Me.lblDepartment.Location = New System.Drawing.Point(5, 5)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblDepartment.Size = New System.Drawing.Size(60, 23)
        Me.lblDepartment.TabIndex = 538
        Me.lblDepartment.Text = "Criteria"
        Me.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlText
        '
        Me.pnlText.BackColor = System.Drawing.Color.White
        Me.pnlText.Controls.Add(Me.pnlEmployeeName)
        Me.pnlText.Controls.Add(Me.txtText)
        Me.pnlText.Location = New System.Drawing.Point(248, 1)
        Me.pnlText.Name = "pnlText"
        Me.pnlText.Size = New System.Drawing.Size(339, 30)
        Me.pnlText.TabIndex = 540
        '
        'txtText
        '
        Me.txtText.Font = New System.Drawing.Font("Verdana", 9.5!)
        Me.txtText.Location = New System.Drawing.Point(3, 4)
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(333, 23)
        Me.txtText.TabIndex = 0
        '
        'cmbSearchCriteria
        '
        Me.cmbSearchCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchCriteria.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbSearchCriteria.FormattingEnabled = True
        Me.cmbSearchCriteria.Location = New System.Drawing.Point(64, 5)
        Me.cmbSearchCriteria.Name = "cmbSearchCriteria"
        Me.cmbSearchCriteria.Size = New System.Drawing.Size(180, 23)
        Me.cmbSearchCriteria.TabIndex = 539
        '
        'bindingNavigator
        '
        Me.bindingNavigator.AddNewItem = Nothing
        Me.bindingNavigator.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bindingNavigator.BackColor = System.Drawing.Color.White
        Me.bindingNavigator.CountItem = Me.txtTotalPageNumber
        Me.bindingNavigator.CountItemFormat = "of "
        Me.bindingNavigator.DeleteItem = Nothing
        Me.bindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.bindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.bindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.txtPageNumber, Me.txtTotalPageNumber, Me.tssPageNumber, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.tssGo, Me.btnGo})
        Me.bindingNavigator.Location = New System.Drawing.Point(98, 9)
        Me.bindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bindingNavigator.Name = "bindingNavigator"
        Me.bindingNavigator.PositionItem = Me.txtPageNumber
        Me.bindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.bindingNavigator.Size = New System.Drawing.Size(201, 25)
        Me.bindingNavigator.TabIndex = 543
        '
        'txtTotalPageNumber
        '
        Me.txtTotalPageNumber.Name = "txtTotalPageNumber"
        Me.txtTotalPageNumber.Size = New System.Drawing.Size(21, 22)
        Me.txtTotalPageNumber.Text = "of "
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'txtPageNumber
        '
        Me.txtPageNumber.AccessibleName = "Position"
        Me.txtPageNumber.AutoSize = False
        Me.txtPageNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPageNumber.Name = "txtPageNumber"
        Me.txtPageNumber.Size = New System.Drawing.Size(30, 23)
        Me.txtPageNumber.Text = "0"
        Me.txtPageNumber.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPageNumber.ToolTipText = "Current page"
        '
        'tssPageNumber
        '
        Me.tssPageNumber.Name = "tssPageNumber"
        Me.tssPageNumber.Size = New System.Drawing.Size(6, 25)
        '
        'tssGo
        '
        Me.tssGo.Name = "tssGo"
        Me.tssGo.Size = New System.Drawing.Size(6, 25)
        '
        'pnlBottom
        '
        Me.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBottom.Controls.Add(Me.btnRefresh)
        Me.pnlBottom.Controls.Add(Me.btnEdit)
        Me.pnlBottom.Controls.Add(Me.btnClose)
        Me.pnlBottom.Controls.Add(Me.bindingNavigator)
        Me.pnlBottom.Controls.Add(Me.btnDelete)
        Me.pnlBottom.Controls.Add(Me.btnAdd)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 406)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(1200, 44)
        Me.pnlBottom.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(1103, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 20
        Me.btnClose.Text = "Close"
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.AllowUserToResizeRows = False
        Me.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvList.ColumnHeadersHeight = 25
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColScreenId, Me.ColScreenDate, Me.ColEmployeeName, Me.ColReason, Me.ColDiagnosis, Me.ColLeaveTypeId, Me.ColLeaveType, Me.ColFitToWork, Me.ColScreenByName})
        Me.dgvList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvList.Location = New System.Drawing.Point(0, 35)
        Me.dgvList.MultiSelect = False
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList.Size = New System.Drawing.Size(1200, 371)
        Me.dgvList.TabIndex = 2
        '
        'ColScreenId
        '
        Me.ColScreenId.DataPropertyName = "ScreenId"
        Me.ColScreenId.HeaderText = "#"
        Me.ColScreenId.Name = "ColScreenId"
        Me.ColScreenId.ReadOnly = True
        Me.ColScreenId.Width = 60
        '
        'ColScreenDate
        '
        Me.ColScreenDate.DataPropertyName = "ScreenDate"
        DataGridViewCellStyle2.Format = "MM/dd/yyyy hh:mm tt"
        Me.ColScreenDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColScreenDate.HeaderText = "Screen Date"
        Me.ColScreenDate.Name = "ColScreenDate"
        Me.ColScreenDate.ReadOnly = True
        Me.ColScreenDate.Width = 130
        '
        'ColEmployeeName
        '
        Me.ColEmployeeName.DataPropertyName = "EmployeeName"
        Me.ColEmployeeName.HeaderText = "Employee Name"
        Me.ColEmployeeName.Name = "ColEmployeeName"
        Me.ColEmployeeName.ReadOnly = True
        Me.ColEmployeeName.Width = 250
        '
        'ColReason
        '
        Me.ColReason.DataPropertyName = "Reason"
        Me.ColReason.HeaderText = "Reason / Chief Complaint"
        Me.ColReason.Name = "ColReason"
        Me.ColReason.ReadOnly = True
        Me.ColReason.Width = 250
        '
        'ColDiagnosis
        '
        Me.ColDiagnosis.DataPropertyName = "Diagnosis"
        Me.ColDiagnosis.HeaderText = "Diagnosis"
        Me.ColDiagnosis.Name = "ColDiagnosis"
        Me.ColDiagnosis.ReadOnly = True
        Me.ColDiagnosis.Width = 200
        '
        'ColLeaveTypeId
        '
        Me.ColLeaveTypeId.DataPropertyName = "LeaveTypeId"
        Me.ColLeaveTypeId.HeaderText = "Leave Type Id"
        Me.ColLeaveTypeId.Name = "ColLeaveTypeId"
        Me.ColLeaveTypeId.ReadOnly = True
        Me.ColLeaveTypeId.Visible = False
        '
        'ColLeaveType
        '
        Me.ColLeaveType.DataPropertyName = "LeaveTypeCode"
        Me.ColLeaveType.HeaderText = "Type"
        Me.ColLeaveType.Name = "ColLeaveType"
        Me.ColLeaveType.ReadOnly = True
        Me.ColLeaveType.Width = 60
        '
        'ColFitToWork
        '
        Me.ColFitToWork.DataPropertyName = "IsFitToWork"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColFitToWork.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColFitToWork.HeaderText = "FTW"
        Me.ColFitToWork.Name = "ColFitToWork"
        Me.ColFitToWork.ReadOnly = True
        Me.ColFitToWork.Width = 50
        '
        'ColScreenByName
        '
        Me.ColScreenByName.DataPropertyName = "ScreenByName"
        Me.ColScreenByName.HeaderText = "Encoded By"
        Me.ColScreenByName.Name = "ColScreenByName"
        Me.ColScreenByName.ReadOnly = True
        Me.ColScreenByName.Width = 160
        '
        'pnlDate
        '
        Me.pnlDate.BackColor = System.Drawing.Color.White
        Me.pnlDate.Controls.Add(Me.dtpDateTo)
        Me.pnlDate.Controls.Add(Me.lblDateTo)
        Me.pnlDate.Controls.Add(Me.lblDateFrom)
        Me.pnlDate.Controls.Add(Me.dtpDateFrom)
        Me.pnlDate.Location = New System.Drawing.Point(249, 2)
        Me.pnlDate.Name = "pnlDate"
        Me.pnlDate.Size = New System.Drawing.Size(339, 30)
        Me.pnlDate.TabIndex = 541
        '
        'dtpDateTo
        '
        Me.dtpDateTo.CustomFormat = "MMM dd, yyyy"
        Me.dtpDateTo.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateTo.Location = New System.Drawing.Point(206, 4)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(130, 24)
        Me.dtpDateTo.TabIndex = 27
        '
        'lblDateTo
        '
        Me.lblDateTo.AutoSize = True
        Me.lblDateTo.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblDateTo.Location = New System.Drawing.Point(180, 8)
        Me.lblDateTo.Name = "lblDateTo"
        Me.lblDateTo.Size = New System.Drawing.Size(22, 17)
        Me.lblDateTo.TabIndex = 29
        Me.lblDateTo.Text = "To"
        '
        'lblDateFrom
        '
        Me.lblDateFrom.AutoSize = True
        Me.lblDateFrom.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.lblDateFrom.Location = New System.Drawing.Point(4, 8)
        Me.lblDateFrom.Name = "lblDateFrom"
        Me.lblDateFrom.Size = New System.Drawing.Size(38, 17)
        Me.lblDateFrom.TabIndex = 28
        Me.lblDateFrom.Text = "From"
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.CustomFormat = "MMM dd, yyyy"
        Me.dtpDateFrom.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateFrom.Location = New System.Drawing.Point(44, 4)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(130, 24)
        Me.dtpDateFrom.TabIndex = 26
        '
        'pnlEmployeeName
        '
        Me.pnlEmployeeName.BackColor = System.Drawing.Color.White
        Me.pnlEmployeeName.Controls.Add(Me.cmbEmployeeName)
        Me.pnlEmployeeName.Location = New System.Drawing.Point(0, 0)
        Me.pnlEmployeeName.Name = "pnlEmployeeName"
        Me.pnlEmployeeName.Size = New System.Drawing.Size(339, 30)
        Me.pnlEmployeeName.TabIndex = 542
        '
        'cmbEmployeeName
        '
        Me.cmbEmployeeName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmployeeName.FormattingEnabled = True
        Me.cmbEmployeeName.Location = New System.Drawing.Point(3, 4)
        Me.cmbEmployeeName.Name = "cmbEmployeeName"
        Me.cmbEmployeeName.Size = New System.Drawing.Size(333, 23)
        Me.cmbEmployeeName.TabIndex = 1
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnRefresh.DefaultScheme = True
        Me.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRefresh.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnRefresh.Hint = "Save"
        Me.btnRefresh.Image = Global.HealthInformationSystem.My.Resources.Resources.Refresh
        Me.btnRefresh.Location = New System.Drawing.Point(5, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRefresh.Size = New System.Drawing.Size(90, 32)
        Me.btnRefresh.TabIndex = 21
        Me.btnRefresh.Text = "Refresh"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnEdit.DefaultScheme = True
        Me.btnEdit.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnEdit.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnEdit.Hint = "Edit selected record"
        Me.btnEdit.Image = Global.HealthInformationSystem.My.Resources.Resources.Modify
        Me.btnEdit.Location = New System.Drawing.Point(890, 5)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnEdit.Size = New System.Drawing.Size(97, 32)
        Me.btnEdit.TabIndex = 18
        Me.btnEdit.Text = "Edit (F3)"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'btnGo
        '
        Me.btnGo.AutoSize = False
        Me.btnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnGo.Image = CType(resources.GetObject("btnGo.Image"), System.Drawing.Image)
        Me.btnGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(35, 22)
        Me.btnGo.Text = "Go"
        Me.btnGo.ToolTipText = "Go to page number specified"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnDelete.DefaultScheme = True
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnDelete.Hint = "Delete selected record"
        Me.btnDelete.Image = Global.HealthInformationSystem.My.Resources.Resources._Erase
        Me.btnDelete.Location = New System.Drawing.Point(993, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(104, 32)
        Me.btnDelete.TabIndex = 19
        Me.btnDelete.Text = "Delete (F8)"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnAdd.DefaultScheme = True
        Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnAdd.Hint = "Add new record"
        Me.btnAdd.Image = Global.HealthInformationSystem.My.Resources.Resources.Create
        Me.btnAdd.Location = New System.Drawing.Point(787, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAdd.Size = New System.Drawing.Size(97, 32)
        Me.btnAdd.TabIndex = 17
        Me.btnAdd.Text = "Add (F2)"
        '
        'frmHealthScreeningHeader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1200, 450)
        Me.Controls.Add(Me.pnlDate)
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlTop)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmHealthScreeningHeader"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Health Screening"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlText.ResumeLayout(False)
        Me.pnlText.PerformLayout()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingNavigator.ResumeLayout(False)
        Me.bindingNavigator.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDate.ResumeLayout(False)
        Me.pnlDate.PerformLayout()
        Me.pnlEmployeeName.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents lblDepartment As Label
    Friend WithEvents cmbSearchCriteria As ComboBox
    Friend WithEvents dgvList As DataGridView
    Friend WithEvents btnEdit As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnAdd As PinkieControls.ButtonXP
    Friend WithEvents btnRefresh As PinkieControls.ButtonXP
    Friend WithEvents pnlText As Panel
    Friend WithEvents txtText As TextBox
    Friend WithEvents bindingNavigator As BindingNavigator
    Friend WithEvents txtTotalPageNumber As ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents txtPageNumber As ToolStripTextBox
    Friend WithEvents tssPageNumber As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents tssGo As ToolStripSeparator
    Friend WithEvents btnGo As ToolStripButton
    Friend WithEvents btnReset As PinkieControls.ButtonXP
    Friend WithEvents btnSearch As PinkieControls.ButtonXP
    Friend WithEvents ColScreenId As DataGridViewTextBoxColumn
    Friend WithEvents ColScreenDate As DataGridViewTextBoxColumn
    Friend WithEvents ColEmployeeName As DataGridViewTextBoxColumn
    Friend WithEvents ColReason As DataGridViewTextBoxColumn
    Friend WithEvents ColDiagnosis As DataGridViewTextBoxColumn
    Friend WithEvents ColLeaveTypeId As DataGridViewTextBoxColumn
    Friend WithEvents ColLeaveType As DataGridViewTextBoxColumn
    Friend WithEvents ColFitToWork As DataGridViewCheckBoxColumn
    Friend WithEvents ColScreenByName As DataGridViewTextBoxColumn
    Friend WithEvents pnlDate As Panel
    Friend WithEvents dtpDateTo As DateTimePicker
    Friend WithEvents lblDateTo As Label
    Friend WithEvents lblDateFrom As Label
    Friend WithEvents dtpDateFrom As DateTimePicker
    Friend WithEvents pnlEmployeeName As Panel
    Friend WithEvents cmbEmployeeName As SergeUtils.EasyCompletionComboBox
End Class
