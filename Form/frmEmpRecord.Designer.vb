<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpRecord
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmpRecord))
        Me.tabCtrl = New System.Windows.Forms.TabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvMed = New System.Windows.Forms.DataGridView()
        Me.ColRecordId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCreatedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCreatedByName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColChiefComplaint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDiagnosis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIsFitToWork = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColIsSentHome = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvApe = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnEdit = New PinkieControls.ButtonXP()
        Me.btnAdd = New PinkieControls.ButtonXP()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnRefresh = New PinkieControls.ButtonXP()
        Me.bindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.txtTotalPageNumber = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.txtPageNumber = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.tssGo = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGo = New System.Windows.Forms.ToolStripButton()
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
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.tabCtrl.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        CType(Me.dgvMed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage2.SuspendLayout()
        CType(Me.dgvApe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator.SuspendLayout()
        Me.pnlLeft.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabCtrl
        '
        Me.tabCtrl.Controls.Add(Me.tabPage1)
        Me.tabCtrl.Controls.Add(Me.tabPage2)
        Me.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabCtrl.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabCtrl.HotTrack = True
        Me.tabCtrl.Location = New System.Drawing.Point(400, 0)
        Me.tabCtrl.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.tabCtrl.Name = "tabCtrl"
        Me.tabCtrl.Padding = New System.Drawing.Point(20, 3)
        Me.tabCtrl.SelectedIndex = 0
        Me.tabCtrl.Size = New System.Drawing.Size(730, 722)
        Me.tabCtrl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.tabCtrl.TabIndex = 1
        Me.tabCtrl.TabStop = False
        '
        'tabPage1
        '
        Me.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabPage1.Controls.Add(Me.dgvMed)
        Me.tabPage1.Location = New System.Drawing.Point(4, 26)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(722, 692)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Medical Record"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'dgvMed
        '
        Me.dgvMed.AllowUserToAddRows = False
        Me.dgvMed.AllowUserToDeleteRows = False
        Me.dgvMed.AllowUserToResizeRows = False
        Me.dgvMed.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvMed.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMed.ColumnHeadersHeight = 25
        Me.dgvMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvMed.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColRecordId, Me.ColCreatedDate, Me.ColCreatedByName, Me.ColChiefComplaint, Me.ColDiagnosis, Me.ColIsFitToWork, Me.ColIsSentHome})
        Me.dgvMed.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMed.Location = New System.Drawing.Point(3, 3)
        Me.dgvMed.MultiSelect = False
        Me.dgvMed.Name = "dgvMed"
        Me.dgvMed.ReadOnly = True
        Me.dgvMed.RowHeadersVisible = False
        Me.dgvMed.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvMed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMed.Size = New System.Drawing.Size(714, 684)
        Me.dgvMed.TabIndex = 0
        '
        'ColRecordId
        '
        Me.ColRecordId.DataPropertyName = "RecordId"
        Me.ColRecordId.HeaderText = "Record ID"
        Me.ColRecordId.Name = "ColRecordId"
        Me.ColRecordId.ReadOnly = True
        '
        'ColCreatedDate
        '
        Me.ColCreatedDate.DataPropertyName = "CreatedDate"
        Me.ColCreatedDate.HeaderText = "Creation Date"
        Me.ColCreatedDate.Name = "ColCreatedDate"
        Me.ColCreatedDate.ReadOnly = True
        Me.ColCreatedDate.Width = 120
        '
        'ColCreatedByName
        '
        Me.ColCreatedByName.DataPropertyName = "CreatedByName"
        Me.ColCreatedByName.HeaderText = "Created By"
        Me.ColCreatedByName.Name = "ColCreatedByName"
        Me.ColCreatedByName.ReadOnly = True
        Me.ColCreatedByName.Visible = False
        '
        'ColChiefComplaint
        '
        Me.ColChiefComplaint.DataPropertyName = "ChiefComplaint"
        Me.ColChiefComplaint.HeaderText = "Chief Complaint"
        Me.ColChiefComplaint.Name = "ColChiefComplaint"
        Me.ColChiefComplaint.ReadOnly = True
        '
        'ColDiagnosis
        '
        Me.ColDiagnosis.DataPropertyName = "Diagnosis"
        Me.ColDiagnosis.HeaderText = "Diagnosis"
        Me.ColDiagnosis.Name = "ColDiagnosis"
        Me.ColDiagnosis.ReadOnly = True
        '
        'ColIsFitToWork
        '
        Me.ColIsFitToWork.DataPropertyName = "IsFitToWork"
        Me.ColIsFitToWork.HeaderText = "FTW"
        Me.ColIsFitToWork.Name = "ColIsFitToWork"
        Me.ColIsFitToWork.ReadOnly = True
        Me.ColIsFitToWork.Width = 50
        '
        'ColIsSentHome
        '
        Me.ColIsSentHome.DataPropertyName = "IsSentHome"
        Me.ColIsSentHome.HeaderText = "SH"
        Me.ColIsSentHome.Name = "ColIsSentHome"
        Me.ColIsSentHome.ReadOnly = True
        Me.ColIsSentHome.Width = 50
        '
        'tabPage2
        '
        Me.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabPage2.Controls.Add(Me.dgvApe)
        Me.tabPage2.Location = New System.Drawing.Point(4, 26)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(722, 692)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Annual Physical Exam"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'dgvApe
        '
        Me.dgvApe.AllowUserToAddRows = False
        Me.dgvApe.AllowUserToDeleteRows = False
        Me.dgvApe.AllowUserToResizeRows = False
        Me.dgvApe.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvApe.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
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
        Me.dgvApe.Size = New System.Drawing.Size(714, 684)
        Me.dgvApe.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "RecordId"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Record ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CreatedDate"
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
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDelete.DefaultScheme = True
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Hint = "Delete selected record"
        Me.btnDelete.Image = Global.HealthInformationSystem.My.Resources.Resources._Erase
        Me.btnDelete.Location = New System.Drawing.Point(642, 6)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(80, 32)
        Me.btnDelete.TabIndex = 559
        Me.btnDelete.Text = "Delete"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnEdit.DefaultScheme = True
        Me.btnEdit.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnEdit.Hint = "Edit existing record"
        Me.btnEdit.Image = Global.HealthInformationSystem.My.Resources.Resources.Modify
        Me.btnEdit.Location = New System.Drawing.Point(556, 6)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnEdit.Size = New System.Drawing.Size(80, 32)
        Me.btnEdit.TabIndex = 558
        Me.btnEdit.Text = "Edit"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdd.DefaultScheme = True
        Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnAdd.Hint = "Add new record"
        Me.btnAdd.Image = Global.HealthInformationSystem.My.Resources.Resources.Create
        Me.btnAdd.Location = New System.Drawing.Point(470, 6)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAdd.Size = New System.Drawing.Size(80, 32)
        Me.btnAdd.TabIndex = 557
        Me.btnAdd.Text = "Add"
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.White
        Me.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBottom.Controls.Add(Me.btnRefresh)
        Me.pnlBottom.Controls.Add(Me.bindingNavigator)
        Me.pnlBottom.Controls.Add(Me.btnDelete)
        Me.pnlBottom.Controls.Add(Me.btnEdit)
        Me.pnlBottom.Controls.Add(Me.btnAdd)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(400, 722)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(730, 46)
        Me.pnlBottom.TabIndex = 561
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRefresh.DefaultScheme = True
        Me.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRefresh.Hint = "Add new record"
        Me.btnRefresh.Image = Global.HealthInformationSystem.My.Resources.Resources.Sync
        Me.btnRefresh.Location = New System.Drawing.Point(207, 6)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRefresh.Size = New System.Drawing.Size(80, 32)
        Me.btnRefresh.TabIndex = 561
        Me.btnRefresh.Text = "Refresh"
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
        Me.bindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.txtPageNumber, Me.txtTotalPageNumber, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.tssGo, Me.btnGo})
        Me.bindingNavigator.Location = New System.Drawing.Point(2, 10)
        Me.bindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bindingNavigator.Name = "bindingNavigator"
        Me.bindingNavigator.PositionItem = Me.txtPageNumber
        Me.bindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.bindingNavigator.Size = New System.Drawing.Size(201, 25)
        Me.bindingNavigator.TabIndex = 560
        Me.bindingNavigator.Text = "PagerPanel"
        '
        'txtTotalPageNumber
        '
        Me.txtTotalPageNumber.Name = "txtTotalPageNumber"
        Me.txtTotalPageNumber.Size = New System.Drawing.Size(21, 22)
        Me.txtTotalPageNumber.Text = "of "
        Me.txtTotalPageNumber.ToolTipText = "Total page number"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
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
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'txtPageNumber
        '
        Me.txtPageNumber.AccessibleName = "Position"
        Me.txtPageNumber.AutoSize = False
        Me.txtPageNumber.Name = "txtPageNumber"
        Me.txtPageNumber.Size = New System.Drawing.Size(30, 23)
        Me.txtPageNumber.Text = "0"
        Me.txtPageNumber.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPageNumber.ToolTipText = "Current page"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'tssGo
        '
        Me.tssGo.Name = "tssGo"
        Me.tssGo.Size = New System.Drawing.Size(6, 25)
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
        'cmbName
        '
        Me.cmbName.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.cmbName.FormattingEnabled = True
        Me.cmbName.Location = New System.Drawing.Point(3, 26)
        Me.cmbName.Name = "cmbName"
        Me.cmbName.Size = New System.Drawing.Size(392, 24)
        Me.cmbName.TabIndex = 0
        '
        'lblBloodType
        '
        Me.lblBloodType.BackColor = System.Drawing.SystemColors.Control
        Me.lblBloodType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBloodType.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblBloodType.ForeColor = System.Drawing.Color.Black
        Me.lblBloodType.Location = New System.Drawing.Point(3, 283)
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
        Me.lblName.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(3, 3)
        Me.lblName.Name = "lblName"
        Me.lblName.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblName.Size = New System.Drawing.Size(392, 24)
        Me.lblName.TabIndex = 523
        Me.lblName.Text = "Name / Employee Code"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmerContactName
        '
        Me.lblEmerContactName.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmerContactName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmerContactName.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblEmerContactName.ForeColor = System.Drawing.Color.Black
        Me.lblEmerContactName.Location = New System.Drawing.Point(3, 390)
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
        Me.lblEmerContactNumber.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblEmerContactNumber.ForeColor = System.Drawing.Color.Black
        Me.lblEmerContactNumber.Location = New System.Drawing.Point(3, 416)
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
        Me.lblEmerContactAddress.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblEmerContactAddress.ForeColor = System.Drawing.Color.Black
        Me.lblEmerContactAddress.Location = New System.Drawing.Point(3, 442)
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
        Me.lblEmer.Font = New System.Drawing.Font("Segoe UI Semibold", 8.6!)
        Me.lblEmer.ForeColor = System.Drawing.Color.White
        Me.lblEmer.Location = New System.Drawing.Point(3, 366)
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
        Me.lblAge.Font = New System.Drawing.Font("Verdana", 8.5!)
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
        Me.txtAge.Font = New System.Drawing.Font("Verdana", 8.5!)
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
        Me.lblAddress.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblAddress.ForeColor = System.Drawing.Color.Black
        Me.lblAddress.Location = New System.Drawing.Point(3, 190)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Padding = New System.Windows.Forms.Padding(3, 7, 0, 0)
        Me.lblAddress.Size = New System.Drawing.Size(142, 55)
        Me.lblAddress.TabIndex = 533
        Me.lblAddress.Text = "Local Address"
        '
        'txtAddress
        '
        Me.txtAddress.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.txtAddress.ForeColor = System.Drawing.Color.Black
        Me.txtAddress.Location = New System.Drawing.Point(144, 190)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Padding = New System.Windows.Forms.Padding(3, 7, 0, 0)
        Me.txtAddress.Size = New System.Drawing.Size(251, 55)
        Me.txtAddress.TabIndex = 534
        Me.txtAddress.UseCompatibleTextRendering = True
        '
        'lblCivilStatus
        '
        Me.lblCivilStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblCivilStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCivilStatus.Font = New System.Drawing.Font("Verdana", 8.5!)
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
        Me.txtCivilStatus.Font = New System.Drawing.Font("Verdana", 8.5!)
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
        Me.lblDepartment.Font = New System.Drawing.Font("Verdana", 8.5!)
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
        Me.txtDepartment.Font = New System.Drawing.Font("Verdana", 8.5!)
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
        Me.lblEmploymentStatus.Font = New System.Drawing.Font("Verdana", 8.5!)
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
        Me.txtEmploymentStatus.Font = New System.Drawing.Font("Verdana", 8.5!)
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
        Me.lblAllergies.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblAllergies.ForeColor = System.Drawing.Color.Black
        Me.lblAllergies.Location = New System.Drawing.Point(3, 309)
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
        Me.lblSection.Font = New System.Drawing.Font("Verdana", 8.5!)
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
        Me.txtSection.Font = New System.Drawing.Font("Verdana", 8.5!)
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
        Me.lblPosition.Font = New System.Drawing.Font("Verdana", 8.5!)
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
        Me.txtPosition.Font = New System.Drawing.Font("Verdana", 8.5!)
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
        Me.txtBloodType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBloodType.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBloodType.Location = New System.Drawing.Point(144, 283)
        Me.txtBloodType.Name = "txtBloodType"
        Me.txtBloodType.Size = New System.Drawing.Size(251, 24)
        Me.txtBloodType.TabIndex = 1
        '
        'txtAllergies
        '
        Me.txtAllergies.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAllergies.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAllergies.Location = New System.Drawing.Point(144, 309)
        Me.txtAllergies.Margin = New System.Windows.Forms.Padding(3, 7, 0, 0)
        Me.txtAllergies.Multiline = True
        Me.txtAllergies.Name = "txtAllergies"
        Me.txtAllergies.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAllergies.Size = New System.Drawing.Size(251, 55)
        Me.txtAllergies.TabIndex = 2
        '
        'txtEmerContactName
        '
        Me.txtEmerContactName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmerContactName.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmerContactName.Location = New System.Drawing.Point(144, 390)
        Me.txtEmerContactName.Name = "txtEmerContactName"
        Me.txtEmerContactName.Size = New System.Drawing.Size(251, 24)
        Me.txtEmerContactName.TabIndex = 3
        '
        'txtEmerContactNumber
        '
        Me.txtEmerContactNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmerContactNumber.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmerContactNumber.Location = New System.Drawing.Point(144, 416)
        Me.txtEmerContactNumber.Name = "txtEmerContactNumber"
        Me.txtEmerContactNumber.Size = New System.Drawing.Size(251, 24)
        Me.txtEmerContactNumber.TabIndex = 4
        '
        'txtEmerContactAddress
        '
        Me.txtEmerContactAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmerContactAddress.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmerContactAddress.Location = New System.Drawing.Point(144, 442)
        Me.txtEmerContactAddress.Margin = New System.Windows.Forms.Padding(3, 7, 0, 0)
        Me.txtEmerContactAddress.Multiline = True
        Me.txtEmerContactAddress.Name = "txtEmerContactAddress"
        Me.txtEmerContactAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEmerContactAddress.Size = New System.Drawing.Size(251, 55)
        Me.txtEmerContactAddress.TabIndex = 5
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(308, 512)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(84, 32)
        Me.btnClose.TabIndex = 553
        Me.btnClose.Text = "Close"
        '
        'pnlLeft
        '
        Me.pnlLeft.BackColor = System.Drawing.Color.LightGray
        Me.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLeft.Controls.Add(Me.btnCancel)
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
        Me.pnlLeft.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(400, 768)
        Me.pnlLeft.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnCancel.DefaultScheme = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Hint = "Cancel"
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(218, 512)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnCancel.Size = New System.Drawing.Size(84, 32)
        Me.btnCancel.TabIndex = 554
        Me.btnCancel.Text = "Cancel"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.btnSave.DefaultScheme = True
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSave.Hint = "Save data then clear form"
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(128, 512)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(84, 32)
        Me.btnSave.TabIndex = 551
        Me.btnSave.Text = "Save"
        '
        'frmEmpRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1130, 768)
        Me.Controls.Add(Me.tabCtrl)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlLeft)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmEmpRecord"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Employee Record"
        Me.tabCtrl.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        CType(Me.dgvMed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage2.ResumeLayout(False)
        CType(Me.dgvApe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingNavigator.ResumeLayout(False)
        Me.bindingNavigator.PerformLayout()
        Me.pnlLeft.ResumeLayout(False)
        Me.pnlLeft.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabCtrl As System.Windows.Forms.TabControl
    Friend WithEvents tabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents tabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnEdit As PinkieControls.ButtonXP
    Friend WithEvents btnAdd As PinkieControls.ButtonXP
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
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
    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents bindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents txtTotalPageNumber As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtPageNumber As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents tssGo As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRefresh As PinkieControls.ButtonXP
    Friend WithEvents dgvMed As System.Windows.Forms.DataGridView
    Friend WithEvents ColRecordId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCreatedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCreatedByName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColChiefComplaint As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDiagnosis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIsFitToWork As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColIsSentHome As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgvApe As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
