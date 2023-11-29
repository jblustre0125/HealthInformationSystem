<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Consultation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Consultation))
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlSearchDate = New System.Windows.Forms.Panel()
        Me.dtpEndDateCommon = New System.Windows.Forms.DateTimePicker()
        Me.lblToCommon = New System.Windows.Forms.Label()
        Me.lblFromCommon = New System.Windows.Forms.Label()
        Me.dtpStartDateCommon = New System.Windows.Forms.DateTimePicker()
        Me.lblSearchCriteria = New System.Windows.Forms.Label()
        Me.cmbSearchCriteria = New System.Windows.Forms.ComboBox()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.btnSearch = New PinkieControls.ButtonXP()
        Me.btnReset = New PinkieControls.ButtonXP()
        Me.pnlSearchTxt = New System.Windows.Forms.Panel()
        Me.txtCommon = New System.Windows.Forms.TextBox()
        Me.pnlSearchCmb = New System.Windows.Forms.Panel()
        Me.cmbCommon = New SergeUtils.EasyCompletionComboBox()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnAdd = New PinkieControls.ButtonXP()
        Me.btnEdit = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.bindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorTotalPageNumber = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPageNumber = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorGo = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorRefresh = New System.Windows.Forms.ToolStripButton()
        Me.dgvConsultation = New System.Windows.Forms.DataGridView()
        Me.ColRecordId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCreatedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColEmployeeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTimeIn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTimeOut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColChiefComplaint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNurseIntervention = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvMedicine = New System.Windows.Forms.DataGridView()
        Me.dgvScreening = New System.Windows.Forms.DataGridView()
        Me.dgvApe = New System.Windows.Forms.DataGridView()
        Me.tcDashboard = New System.Windows.Forms.TabControl()
        Me.tbConsultation = New System.Windows.Forms.TabPage()
        Me.tbRest = New System.Windows.Forms.TabPage()
        Me.dgvRest = New System.Windows.Forms.DataGridView()
        Me.ColRestAlarmId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRestRecordId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRestDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRestEmployeeId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRestEmployeeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRestRoomId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRestRoomName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRestBedId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRestBedNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRestDatetimeStarted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRestDatetimeEnded = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRestMinutes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRestAlarm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRestIsActive = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tbTransaction = New System.Windows.Forms.TabPage()
        Me.dgvTransaction = New System.Windows.Forms.DataGridView()
        Me.pnlSearchDate.SuspendLayout()
        Me.pnlTop.SuspendLayout()
        Me.pnlSearchTxt.SuspendLayout()
        Me.pnlSearchCmb.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator.SuspendLayout()
        CType(Me.dgvConsultation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMedicine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvScreening, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvApe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcDashboard.SuspendLayout()
        Me.tbConsultation.SuspendLayout()
        Me.tbRest.SuspendLayout()
        CType(Me.dgvRest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbTransaction.SuspendLayout()
        CType(Me.dgvTransaction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSearchDate
        '
        Me.pnlSearchDate.BackColor = System.Drawing.Color.White
        Me.pnlSearchDate.Controls.Add(Me.dtpEndDateCommon)
        Me.pnlSearchDate.Controls.Add(Me.lblToCommon)
        Me.pnlSearchDate.Controls.Add(Me.lblFromCommon)
        Me.pnlSearchDate.Controls.Add(Me.dtpStartDateCommon)
        Me.pnlSearchDate.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.pnlSearchDate.Location = New System.Drawing.Point(230, 1)
        Me.pnlSearchDate.Name = "pnlSearchDate"
        Me.pnlSearchDate.Size = New System.Drawing.Size(322, 31)
        Me.pnlSearchDate.TabIndex = 539
        '
        'dtpEndDateCommon
        '
        Me.dtpEndDateCommon.CustomFormat = "  MMM dd, yyyy"
        Me.dtpEndDateCommon.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dtpEndDateCommon.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateCommon.Location = New System.Drawing.Point(193, 3)
        Me.dtpEndDateCommon.Name = "dtpEndDateCommon"
        Me.dtpEndDateCommon.Size = New System.Drawing.Size(125, 24)
        Me.dtpEndDateCommon.TabIndex = 27
        '
        'lblToCommon
        '
        Me.lblToCommon.AutoSize = True
        Me.lblToCommon.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblToCommon.Location = New System.Drawing.Point(171, 8)
        Me.lblToCommon.Name = "lblToCommon"
        Me.lblToCommon.Size = New System.Drawing.Size(19, 15)
        Me.lblToCommon.TabIndex = 29
        Me.lblToCommon.Text = "To"
        '
        'lblFromCommon
        '
        Me.lblFromCommon.AutoSize = True
        Me.lblFromCommon.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFromCommon.Location = New System.Drawing.Point(5, 8)
        Me.lblFromCommon.Name = "lblFromCommon"
        Me.lblFromCommon.Size = New System.Drawing.Size(35, 15)
        Me.lblFromCommon.TabIndex = 28
        Me.lblFromCommon.Text = "From"
        '
        'dtpStartDateCommon
        '
        Me.dtpStartDateCommon.CustomFormat = "  MMM dd, yyyy"
        Me.dtpStartDateCommon.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.dtpStartDateCommon.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDateCommon.Location = New System.Drawing.Point(43, 3)
        Me.dtpStartDateCommon.Name = "dtpStartDateCommon"
        Me.dtpStartDateCommon.Size = New System.Drawing.Size(125, 24)
        Me.dtpStartDateCommon.TabIndex = 26
        '
        'lblSearchCriteria
        '
        Me.lblSearchCriteria.BackColor = System.Drawing.SystemColors.Control
        Me.lblSearchCriteria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSearchCriteria.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchCriteria.ForeColor = System.Drawing.Color.Black
        Me.lblSearchCriteria.Location = New System.Drawing.Point(5, 3)
        Me.lblSearchCriteria.Name = "lblSearchCriteria"
        Me.lblSearchCriteria.Size = New System.Drawing.Size(60, 25)
        Me.lblSearchCriteria.TabIndex = 537
        Me.lblSearchCriteria.Text = "Criteria"
        Me.lblSearchCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSearchCriteria.UseCompatibleTextRendering = True
        '
        'cmbSearchCriteria
        '
        Me.cmbSearchCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchCriteria.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchCriteria.FormattingEnabled = True
        Me.cmbSearchCriteria.Location = New System.Drawing.Point(64, 3)
        Me.cmbSearchCriteria.Name = "cmbSearchCriteria"
        Me.cmbSearchCriteria.Size = New System.Drawing.Size(165, 25)
        Me.cmbSearchCriteria.TabIndex = 538
        '
        'pnlTop
        '
        Me.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTop.Controls.Add(Me.lblSearchCriteria)
        Me.pnlTop.Controls.Add(Me.btnSearch)
        Me.pnlTop.Controls.Add(Me.cmbSearchCriteria)
        Me.pnlTop.Controls.Add(Me.btnReset)
        Me.pnlTop.Controls.Add(Me.pnlSearchDate)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(916, 33)
        Me.pnlTop.TabIndex = 540
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnSearch.DefaultScheme = True
        Me.btnSearch.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnSearch.Hint = "Search"
        Me.btnSearch.Image = Global.HealthInformationSystem.My.Resources.Resources.View
        Me.btnSearch.Location = New System.Drawing.Point(553, 1)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSearch.Size = New System.Drawing.Size(85, 29)
        Me.btnSearch.TabIndex = 553
        Me.btnSearch.Text = "Search"
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnReset.DefaultScheme = True
        Me.btnReset.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnReset.Hint = "Remove filter"
        Me.btnReset.Image = Global.HealthInformationSystem.My.Resources.Resources.Undo
        Me.btnReset.Location = New System.Drawing.Point(641, 1)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnReset.Size = New System.Drawing.Size(85, 29)
        Me.btnReset.TabIndex = 554
        Me.btnReset.Text = "Reset"
        '
        'pnlSearchTxt
        '
        Me.pnlSearchTxt.BackColor = System.Drawing.Color.White
        Me.pnlSearchTxt.Controls.Add(Me.txtCommon)
        Me.pnlSearchTxt.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.pnlSearchTxt.Location = New System.Drawing.Point(230, 1)
        Me.pnlSearchTxt.Name = "pnlSearchTxt"
        Me.pnlSearchTxt.Size = New System.Drawing.Size(322, 31)
        Me.pnlSearchTxt.TabIndex = 541
        '
        'txtCommon
        '
        Me.txtCommon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCommon.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtCommon.Location = New System.Drawing.Point(3, 3)
        Me.txtCommon.Name = "txtCommon"
        Me.txtCommon.Size = New System.Drawing.Size(316, 25)
        Me.txtCommon.TabIndex = 543
        '
        'pnlSearchCmb
        '
        Me.pnlSearchCmb.BackColor = System.Drawing.Color.White
        Me.pnlSearchCmb.Controls.Add(Me.cmbCommon)
        Me.pnlSearchCmb.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.pnlSearchCmb.Location = New System.Drawing.Point(230, 1)
        Me.pnlSearchCmb.Name = "pnlSearchCmb"
        Me.pnlSearchCmb.Size = New System.Drawing.Size(322, 31)
        Me.pnlSearchCmb.TabIndex = 542
        '
        'cmbCommon
        '
        Me.cmbCommon.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cmbCommon.FormattingEnabled = True
        Me.cmbCommon.Location = New System.Drawing.Point(3, 3)
        Me.cmbCommon.Name = "cmbCommon"
        Me.cmbCommon.Size = New System.Drawing.Size(316, 25)
        Me.cmbCommon.TabIndex = 25
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.btnAdd)
        Me.pnlBottom.Controls.Add(Me.btnEdit)
        Me.pnlBottom.Controls.Add(Me.btnDelete)
        Me.pnlBottom.Controls.Add(Me.btnClose)
        Me.pnlBottom.Controls.Add(Me.bindingNavigator)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 414)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(916, 36)
        Me.pnlBottom.TabIndex = 543
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnAdd.DefaultScheme = True
        Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnAdd.Hint = "Create new record"
        Me.btnAdd.Image = Global.HealthInformationSystem.My.Resources.Resources.OK
        Me.btnAdd.Location = New System.Drawing.Point(541, 2)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAdd.Size = New System.Drawing.Size(90, 32)
        Me.btnAdd.TabIndex = 562
        Me.btnAdd.Text = "Create"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnEdit.DefaultScheme = True
        Me.btnEdit.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnEdit.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnEdit.Hint = "Edit selected record"
        Me.btnEdit.Image = Global.HealthInformationSystem.My.Resources.Resources.Modify
        Me.btnEdit.Location = New System.Drawing.Point(635, 2)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnEdit.Size = New System.Drawing.Size(90, 32)
        Me.btnEdit.TabIndex = 561
        Me.btnEdit.Text = "  Edit"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnDelete.DefaultScheme = True
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnDelete.Hint = "Delete selected record"
        Me.btnDelete.Image = Global.HealthInformationSystem.My.Resources.Resources._Erase
        Me.btnDelete.Location = New System.Drawing.Point(729, 2)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 560
        Me.btnDelete.Text = "Delete"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnClose.Hint = ""
        Me.btnClose.Location = New System.Drawing.Point(822, 2)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 559
        Me.btnClose.Text = "Close"
        '
        'bindingNavigator
        '
        Me.bindingNavigator.AddNewItem = Nothing
        Me.bindingNavigator.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bindingNavigator.BackColor = System.Drawing.Color.Transparent
        Me.bindingNavigator.CountItem = Me.BindingNavigatorTotalPageNumber
        Me.bindingNavigator.CountItemFormat = "of"
        Me.bindingNavigator.DeleteItem = Nothing
        Me.bindingNavigator.Dock = System.Windows.Forms.DockStyle.None
        Me.bindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.bindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorPageNumber, Me.BindingNavigatorTotalPageNumber, Me.BindingNavigatorSeparator2, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator3, Me.BindingNavigatorGo, Me.BindingNavigatorSeparator4, Me.BindingNavigatorRefresh})
        Me.bindingNavigator.Location = New System.Drawing.Point(6, 5)
        Me.bindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bindingNavigator.Name = "bindingNavigator"
        Me.bindingNavigator.PositionItem = Me.BindingNavigatorPageNumber
        Me.bindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.bindingNavigator.Size = New System.Drawing.Size(252, 25)
        Me.bindingNavigator.TabIndex = 1
        '
        'BindingNavigatorTotalPageNumber
        '
        Me.BindingNavigatorTotalPageNumber.Name = "BindingNavigatorTotalPageNumber"
        Me.BindingNavigatorTotalPageNumber.Size = New System.Drawing.Size(18, 22)
        Me.BindingNavigatorTotalPageNumber.Text = "of"
        Me.BindingNavigatorTotalPageNumber.ToolTipText = "Total number of pages"
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
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPageNumber
        '
        Me.BindingNavigatorPageNumber.AutoSize = False
        Me.BindingNavigatorPageNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BindingNavigatorPageNumber.Name = "BindingNavigatorPageNumber"
        Me.BindingNavigatorPageNumber.Size = New System.Drawing.Size(30, 25)
        Me.BindingNavigatorPageNumber.Text = "0"
        Me.BindingNavigatorPageNumber.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.BindingNavigatorPageNumber.ToolTipText = "Current Page"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'BindingNavigatorSeparator3
        '
        Me.BindingNavigatorSeparator3.Name = "BindingNavigatorSeparator3"
        Me.BindingNavigatorSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorGo
        '
        Me.BindingNavigatorGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BindingNavigatorGo.Margin = New System.Windows.Forms.Padding(2, 1, 2, 2)
        Me.BindingNavigatorGo.Name = "BindingNavigatorGo"
        Me.BindingNavigatorGo.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorGo.Size = New System.Drawing.Size(26, 22)
        Me.BindingNavigatorGo.Text = "Go"
        '
        'BindingNavigatorSeparator4
        '
        Me.BindingNavigatorSeparator4.Name = "BindingNavigatorSeparator4"
        Me.BindingNavigatorSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorRefresh
        '
        Me.BindingNavigatorRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BindingNavigatorRefresh.Name = "BindingNavigatorRefresh"
        Me.BindingNavigatorRefresh.Size = New System.Drawing.Size(53, 22)
        Me.BindingNavigatorRefresh.Text = " Refresh"
        Me.BindingNavigatorRefresh.ToolTipText = "Refresh"
        '
        'dgvConsultation
        '
        Me.dgvConsultation.AllowUserToAddRows = False
        Me.dgvConsultation.AllowUserToDeleteRows = False
        Me.dgvConsultation.AllowUserToResizeRows = False
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvConsultation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvConsultation.ColumnHeadersHeight = 25
        Me.dgvConsultation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvConsultation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColRecordId, Me.ColCreatedDate, Me.ColEmployeeName, Me.ColTimeIn, Me.ColTimeOut, Me.ColChiefComplaint, Me.ColNurseIntervention})
        Me.dgvConsultation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConsultation.Location = New System.Drawing.Point(3, 3)
        Me.dgvConsultation.MultiSelect = False
        Me.dgvConsultation.Name = "dgvConsultation"
        Me.dgvConsultation.ReadOnly = True
        Me.dgvConsultation.RowHeadersVisible = False
        Me.dgvConsultation.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvConsultation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvConsultation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvConsultation.Size = New System.Drawing.Size(902, 347)
        Me.dgvConsultation.TabIndex = 554
        '
        'ColRecordId
        '
        Me.ColRecordId.DataPropertyName = "RecordId"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColRecordId.DefaultCellStyle = DataGridViewCellStyle19
        Me.ColRecordId.HeaderText = "Rec No."
        Me.ColRecordId.Name = "ColRecordId"
        Me.ColRecordId.ReadOnly = True
        Me.ColRecordId.Width = 60
        '
        'ColCreatedDate
        '
        Me.ColCreatedDate.DataPropertyName = "CreatedDate"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle20.Format = "MM/dd/yyyy"
        Me.ColCreatedDate.DefaultCellStyle = DataGridViewCellStyle20
        Me.ColCreatedDate.HeaderText = "Date"
        Me.ColCreatedDate.Name = "ColCreatedDate"
        Me.ColCreatedDate.ReadOnly = True
        Me.ColCreatedDate.Width = 80
        '
        'ColEmployeeName
        '
        Me.ColEmployeeName.DataPropertyName = "EmployeeName"
        Me.ColEmployeeName.HeaderText = "Employee Name"
        Me.ColEmployeeName.Name = "ColEmployeeName"
        Me.ColEmployeeName.ReadOnly = True
        Me.ColEmployeeName.Width = 200
        '
        'ColTimeIn
        '
        Me.ColTimeIn.DataPropertyName = "DatetimeStarted"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.Format = "hh:mm tt"
        Me.ColTimeIn.DefaultCellStyle = DataGridViewCellStyle21
        Me.ColTimeIn.HeaderText = "In"
        Me.ColTimeIn.Name = "ColTimeIn"
        Me.ColTimeIn.ReadOnly = True
        Me.ColTimeIn.Width = 60
        '
        'ColTimeOut
        '
        Me.ColTimeOut.DataPropertyName = "DatetimeEnded"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle22.Format = "hh:mm tt"
        Me.ColTimeOut.DefaultCellStyle = DataGridViewCellStyle22
        Me.ColTimeOut.HeaderText = "Out"
        Me.ColTimeOut.Name = "ColTimeOut"
        Me.ColTimeOut.ReadOnly = True
        Me.ColTimeOut.Width = 60
        '
        'ColChiefComplaint
        '
        Me.ColChiefComplaint.DataPropertyName = "ChiefComplaint"
        Me.ColChiefComplaint.HeaderText = "Chief Complaint"
        Me.ColChiefComplaint.Name = "ColChiefComplaint"
        Me.ColChiefComplaint.ReadOnly = True
        '
        'ColNurseIntervention
        '
        Me.ColNurseIntervention.DataPropertyName = "Plano"
        Me.ColNurseIntervention.HeaderText = "Nurse Intervention"
        Me.ColNurseIntervention.Name = "ColNurseIntervention"
        Me.ColNurseIntervention.ReadOnly = True
        '
        'dgvMedicine
        '
        Me.dgvMedicine.AllowUserToAddRows = False
        Me.dgvMedicine.AllowUserToDeleteRows = False
        Me.dgvMedicine.AllowUserToResizeRows = False
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvMedicine.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.dgvMedicine.ColumnHeadersHeight = 25
        Me.dgvMedicine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvMedicine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMedicine.Location = New System.Drawing.Point(0, 0)
        Me.dgvMedicine.MultiSelect = False
        Me.dgvMedicine.Name = "dgvMedicine"
        Me.dgvMedicine.ReadOnly = True
        Me.dgvMedicine.RowHeadersVisible = False
        Me.dgvMedicine.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvMedicine.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvMedicine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMedicine.Size = New System.Drawing.Size(914, 354)
        Me.dgvMedicine.TabIndex = 555
        '
        'dgvScreening
        '
        Me.dgvScreening.AllowUserToAddRows = False
        Me.dgvScreening.AllowUserToDeleteRows = False
        Me.dgvScreening.AllowUserToResizeRows = False
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvScreening.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgvScreening.ColumnHeadersHeight = 25
        Me.dgvScreening.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvScreening.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvScreening.Location = New System.Drawing.Point(0, 0)
        Me.dgvScreening.MultiSelect = False
        Me.dgvScreening.Name = "dgvScreening"
        Me.dgvScreening.ReadOnly = True
        Me.dgvScreening.RowHeadersVisible = False
        Me.dgvScreening.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvScreening.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvScreening.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvScreening.Size = New System.Drawing.Size(914, 354)
        Me.dgvScreening.TabIndex = 556
        '
        'dgvApe
        '
        Me.dgvApe.AllowUserToAddRows = False
        Me.dgvApe.AllowUserToDeleteRows = False
        Me.dgvApe.AllowUserToResizeRows = False
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Tahoma", 8.25!)
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvApe.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.dgvApe.ColumnHeadersHeight = 25
        Me.dgvApe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvApe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvApe.Location = New System.Drawing.Point(0, 0)
        Me.dgvApe.MultiSelect = False
        Me.dgvApe.Name = "dgvApe"
        Me.dgvApe.ReadOnly = True
        Me.dgvApe.RowHeadersVisible = False
        Me.dgvApe.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvApe.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvApe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvApe.Size = New System.Drawing.Size(914, 354)
        Me.dgvApe.TabIndex = 556
        '
        'tcDashboard
        '
        Me.tcDashboard.Controls.Add(Me.tbConsultation)
        Me.tcDashboard.Controls.Add(Me.tbRest)
        Me.tcDashboard.Controls.Add(Me.tbTransaction)
        Me.tcDashboard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcDashboard.Location = New System.Drawing.Point(0, 33)
        Me.tcDashboard.Name = "tcDashboard"
        Me.tcDashboard.SelectedIndex = 0
        Me.tcDashboard.Size = New System.Drawing.Size(916, 381)
        Me.tcDashboard.TabIndex = 544
        '
        'tbConsultation
        '
        Me.tbConsultation.Controls.Add(Me.dgvConsultation)
        Me.tbConsultation.Location = New System.Drawing.Point(4, 24)
        Me.tbConsultation.Name = "tbConsultation"
        Me.tbConsultation.Padding = New System.Windows.Forms.Padding(3)
        Me.tbConsultation.Size = New System.Drawing.Size(908, 353)
        Me.tbConsultation.TabIndex = 0
        Me.tbConsultation.Text = "Consultation"
        Me.tbConsultation.UseVisualStyleBackColor = True
        '
        'tbRest
        '
        Me.tbRest.Controls.Add(Me.dgvRest)
        Me.tbRest.Location = New System.Drawing.Point(4, 24)
        Me.tbRest.Name = "tbRest"
        Me.tbRest.Padding = New System.Windows.Forms.Padding(3)
        Me.tbRest.Size = New System.Drawing.Size(908, 353)
        Me.tbRest.TabIndex = 1
        Me.tbRest.Text = "Rest Monitoring"
        Me.tbRest.UseVisualStyleBackColor = True
        '
        'dgvRest
        '
        Me.dgvRest.AllowUserToAddRows = False
        Me.dgvRest.AllowUserToDeleteRows = False
        Me.dgvRest.AllowUserToResizeRows = False
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvRest.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle26
        Me.dgvRest.ColumnHeadersHeight = 25
        Me.dgvRest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvRest.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColRestAlarmId, Me.ColRestRecordId, Me.ColRestDate, Me.ColRestEmployeeId, Me.ColRestEmployeeName, Me.ColRestRoomId, Me.ColRestRoomName, Me.ColRestBedId, Me.ColRestBedNo, Me.ColRestDatetimeStarted, Me.ColRestDatetimeEnded, Me.ColRestMinutes, Me.ColRestAlarm, Me.ColRestIsActive})
        Me.dgvRest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRest.Location = New System.Drawing.Point(3, 3)
        Me.dgvRest.MultiSelect = False
        Me.dgvRest.Name = "dgvRest"
        Me.dgvRest.ReadOnly = True
        Me.dgvRest.RowHeadersVisible = False
        Me.dgvRest.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvRest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvRest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRest.Size = New System.Drawing.Size(902, 347)
        Me.dgvRest.TabIndex = 557
        '
        'ColRestAlarmId
        '
        Me.ColRestAlarmId.DataPropertyName = "RestAlarmId"
        Me.ColRestAlarmId.HeaderText = "AlarmId"
        Me.ColRestAlarmId.Name = "ColRestAlarmId"
        Me.ColRestAlarmId.ReadOnly = True
        Me.ColRestAlarmId.Visible = False
        '
        'ColRestRecordId
        '
        Me.ColRestRecordId.DataPropertyName = "RecordId"
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColRestRecordId.DefaultCellStyle = DataGridViewCellStyle27
        Me.ColRestRecordId.HeaderText = "Rec No."
        Me.ColRestRecordId.Name = "ColRestRecordId"
        Me.ColRestRecordId.ReadOnly = True
        Me.ColRestRecordId.Width = 60
        '
        'ColRestDate
        '
        Me.ColRestDate.DataPropertyName = "CreatedDate"
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle28.Format = "MM/dd/yyyy"
        Me.ColRestDate.DefaultCellStyle = DataGridViewCellStyle28
        Me.ColRestDate.HeaderText = "Date"
        Me.ColRestDate.Name = "ColRestDate"
        Me.ColRestDate.ReadOnly = True
        Me.ColRestDate.Width = 80
        '
        'ColRestEmployeeId
        '
        Me.ColRestEmployeeId.DataPropertyName = "EmployeeId"
        Me.ColRestEmployeeId.HeaderText = "EmployeeId"
        Me.ColRestEmployeeId.Name = "ColRestEmployeeId"
        Me.ColRestEmployeeId.ReadOnly = True
        Me.ColRestEmployeeId.Visible = False
        '
        'ColRestEmployeeName
        '
        Me.ColRestEmployeeName.DataPropertyName = "EmployeeName"
        Me.ColRestEmployeeName.HeaderText = "Employee Name"
        Me.ColRestEmployeeName.Name = "ColRestEmployeeName"
        Me.ColRestEmployeeName.ReadOnly = True
        Me.ColRestEmployeeName.Width = 200
        '
        'ColRestRoomId
        '
        Me.ColRestRoomId.DataPropertyName = "RoomId"
        Me.ColRestRoomId.HeaderText = "RoomId"
        Me.ColRestRoomId.Name = "ColRestRoomId"
        Me.ColRestRoomId.ReadOnly = True
        Me.ColRestRoomId.Visible = False
        '
        'ColRestRoomName
        '
        Me.ColRestRoomName.DataPropertyName = "RoomName"
        Me.ColRestRoomName.HeaderText = "Room Name"
        Me.ColRestRoomName.Name = "ColRestRoomName"
        Me.ColRestRoomName.ReadOnly = True
        '
        'ColRestBedId
        '
        Me.ColRestBedId.DataPropertyName = "BedId"
        Me.ColRestBedId.HeaderText = "BedId"
        Me.ColRestBedId.Name = "ColRestBedId"
        Me.ColRestBedId.ReadOnly = True
        Me.ColRestBedId.Visible = False
        '
        'ColRestBedNo
        '
        Me.ColRestBedNo.DataPropertyName = "BedNo"
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColRestBedNo.DefaultCellStyle = DataGridViewCellStyle29
        Me.ColRestBedNo.HeaderText = "Bed No"
        Me.ColRestBedNo.Name = "ColRestBedNo"
        Me.ColRestBedNo.ReadOnly = True
        Me.ColRestBedNo.Width = 50
        '
        'ColRestDatetimeStarted
        '
        Me.ColRestDatetimeStarted.DataPropertyName = "DatetimeStarted"
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle30.Format = "hh:mm tt"
        Me.ColRestDatetimeStarted.DefaultCellStyle = DataGridViewCellStyle30
        Me.ColRestDatetimeStarted.HeaderText = "Time In"
        Me.ColRestDatetimeStarted.Name = "ColRestDatetimeStarted"
        Me.ColRestDatetimeStarted.ReadOnly = True
        Me.ColRestDatetimeStarted.Width = 60
        '
        'ColRestDatetimeEnded
        '
        Me.ColRestDatetimeEnded.DataPropertyName = "DatetimeEnded"
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle31.Format = "hh:mm tt"
        Me.ColRestDatetimeEnded.DefaultCellStyle = DataGridViewCellStyle31
        Me.ColRestDatetimeEnded.HeaderText = "Time Out"
        Me.ColRestDatetimeEnded.Name = "ColRestDatetimeEnded"
        Me.ColRestDatetimeEnded.ReadOnly = True
        Me.ColRestDatetimeEnded.Width = 60
        '
        'ColRestMinutes
        '
        Me.ColRestMinutes.DataPropertyName = "TotalRestTime"
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColRestMinutes.DefaultCellStyle = DataGridViewCellStyle32
        Me.ColRestMinutes.HeaderText = "Minutes"
        Me.ColRestMinutes.Name = "ColRestMinutes"
        Me.ColRestMinutes.ReadOnly = True
        Me.ColRestMinutes.Width = 50
        '
        'ColRestAlarm
        '
        Me.ColRestAlarm.DataPropertyName = "AlarmTime"
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle33.Format = "hh:mm tt"
        Me.ColRestAlarm.DefaultCellStyle = DataGridViewCellStyle33
        Me.ColRestAlarm.HeaderText = "Alarm"
        Me.ColRestAlarm.Name = "ColRestAlarm"
        Me.ColRestAlarm.ReadOnly = True
        Me.ColRestAlarm.Width = 60
        '
        'ColRestIsActive
        '
        Me.ColRestIsActive.DataPropertyName = "IsActive"
        Me.ColRestIsActive.HeaderText = "*"
        Me.ColRestIsActive.Name = "ColRestIsActive"
        Me.ColRestIsActive.ReadOnly = True
        Me.ColRestIsActive.Width = 30
        '
        'tbTransaction
        '
        Me.tbTransaction.Controls.Add(Me.dgvTransaction)
        Me.tbTransaction.Location = New System.Drawing.Point(4, 24)
        Me.tbTransaction.Name = "tbTransaction"
        Me.tbTransaction.Size = New System.Drawing.Size(908, 353)
        Me.tbTransaction.TabIndex = 2
        Me.tbTransaction.Text = "Transaction"
        Me.tbTransaction.UseVisualStyleBackColor = True
        '
        'dgvTransaction
        '
        Me.dgvTransaction.AllowUserToAddRows = False
        Me.dgvTransaction.AllowUserToDeleteRows = False
        Me.dgvTransaction.AllowUserToResizeRows = False
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle34.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvTransaction.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle34
        Me.dgvTransaction.ColumnHeadersHeight = 25
        Me.dgvTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvTransaction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTransaction.Location = New System.Drawing.Point(0, 0)
        Me.dgvTransaction.MultiSelect = False
        Me.dgvTransaction.Name = "dgvTransaction"
        Me.dgvTransaction.ReadOnly = True
        Me.dgvTransaction.RowHeadersVisible = False
        Me.dgvTransaction.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvTransaction.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvTransaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransaction.Size = New System.Drawing.Size(908, 353)
        Me.dgvTransaction.TabIndex = 558
        '
        'Consultation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(916, 450)
        Me.Controls.Add(Me.tcDashboard)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlSearchCmb)
        Me.Controls.Add(Me.pnlSearchTxt)
        Me.Controls.Add(Me.pnlTop)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Consultation"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Dashboard"
        Me.pnlSearchDate.ResumeLayout(False)
        Me.pnlSearchDate.PerformLayout()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlSearchTxt.ResumeLayout(False)
        Me.pnlSearchTxt.PerformLayout()
        Me.pnlSearchCmb.ResumeLayout(False)
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        CType(Me.bindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingNavigator.ResumeLayout(False)
        Me.bindingNavigator.PerformLayout()
        CType(Me.dgvConsultation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMedicine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvScreening, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvApe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcDashboard.ResumeLayout(False)
        Me.tbConsultation.ResumeLayout(False)
        Me.tbRest.ResumeLayout(False)
        CType(Me.dgvRest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbTransaction.ResumeLayout(False)
        CType(Me.dgvTransaction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlSearchDate As Panel
    Friend WithEvents dtpEndDateCommon As DateTimePicker
    Friend WithEvents lblToCommon As Label
    Friend WithEvents lblFromCommon As Label
    Friend WithEvents dtpStartDateCommon As DateTimePicker
    Friend WithEvents lblSearchCriteria As Label
    Friend WithEvents cmbSearchCriteria As ComboBox
    Friend WithEvents pnlTop As Panel
    Friend WithEvents pnlSearchTxt As Panel
    Friend WithEvents txtCommon As TextBox
    Friend WithEvents pnlSearchCmb As Panel
    Friend WithEvents cmbCommon As SergeUtils.EasyCompletionComboBox
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents bindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorTotalPageNumber As ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorPageNumber As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator3 As ToolStripSeparator
    Friend WithEvents BindingNavigatorGo As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator4 As ToolStripSeparator
    Friend WithEvents BindingNavigatorRefresh As ToolStripButton
    Friend WithEvents btnAdd As PinkieControls.ButtonXP
    Friend WithEvents btnEdit As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnSearch As PinkieControls.ButtonXP
    Friend WithEvents btnReset As PinkieControls.ButtonXP
    Friend WithEvents dgvConsultation As DataGridView
    Friend WithEvents dgvMedicine As DataGridView
    Friend WithEvents dgvScreening As DataGridView
    Friend WithEvents dgvApe As DataGridView
    Friend WithEvents tcDashboard As TabControl
    Friend WithEvents tbConsultation As TabPage
    Friend WithEvents tbRest As TabPage
    Friend WithEvents dgvRest As DataGridView
    Friend WithEvents ColRestAlarmId As DataGridViewTextBoxColumn
    Friend WithEvents ColRestRecordId As DataGridViewTextBoxColumn
    Friend WithEvents ColRestDate As DataGridViewTextBoxColumn
    Friend WithEvents ColRestEmployeeId As DataGridViewTextBoxColumn
    Friend WithEvents ColRestEmployeeName As DataGridViewTextBoxColumn
    Friend WithEvents ColRestRoomId As DataGridViewTextBoxColumn
    Friend WithEvents ColRestRoomName As DataGridViewTextBoxColumn
    Friend WithEvents ColRestBedId As DataGridViewTextBoxColumn
    Friend WithEvents ColRestBedNo As DataGridViewTextBoxColumn
    Friend WithEvents ColRestDatetimeStarted As DataGridViewTextBoxColumn
    Friend WithEvents ColRestDatetimeEnded As DataGridViewTextBoxColumn
    Friend WithEvents ColRestMinutes As DataGridViewTextBoxColumn
    Friend WithEvents ColRestAlarm As DataGridViewTextBoxColumn
    Friend WithEvents ColRestIsActive As DataGridViewCheckBoxColumn
    Friend WithEvents ColRecordId As DataGridViewTextBoxColumn
    Friend WithEvents ColCreatedDate As DataGridViewTextBoxColumn
    Friend WithEvents ColEmployeeName As DataGridViewTextBoxColumn
    Friend WithEvents ColTimeIn As DataGridViewTextBoxColumn
    Friend WithEvents ColTimeOut As DataGridViewTextBoxColumn
    Friend WithEvents ColChiefComplaint As DataGridViewTextBoxColumn
    Friend WithEvents ColNurseIntervention As DataGridViewTextBoxColumn
    Friend WithEvents tbTransaction As TabPage
    Friend WithEvents dgvTransaction As DataGridView
End Class
