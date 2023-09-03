<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReceiveMedicine
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReceiveMedicine))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.lblModifiedBy = New System.Windows.Forms.Label()
        Me.lblModifiedDate = New System.Windows.Forms.Label()
        Me.txtModifiedBy = New System.Windows.Forms.Label()
        Me.txtModifiedDate = New System.Windows.Forms.Label()
        Me.lblCreatedDate = New System.Windows.Forms.Label()
        Me.lblCreatedBy = New System.Windows.Forms.Label()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.cmbCompany = New SergeUtils.EasyCompletionComboBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.txtCategory = New System.Windows.Forms.Label()
        Me.lblStock = New System.Windows.Forms.Label()
        Me.lblExpiration = New System.Windows.Forms.Label()
        Me.txtExpiration = New System.Windows.Forms.MaskedTextBox()
        Me.dgvDetail = New System.Windows.Forms.DataGridView()
        Me.ColTrxId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMedicineId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStockOut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColEndingBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbName = New SergeUtils.EasyCompletionComboBox()
        Me.txtStock = New System.Windows.Forms.Label()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.txtUnit = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.btnRemove = New PinkieControls.ButtonXP()
        Me.ButtonXP2 = New PinkieControls.ButtonXP()
        Me.btnClear = New PinkieControls.ButtonXP()
        Me.btnList = New PinkieControls.ButtonXP()
        Me.txtCreatedBy = New System.Windows.Forms.Label()
        Me.txtCreatedDate = New System.Windows.Forms.Label()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.btnSave.Location = New System.Drawing.Point(619, 384)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = " Save"
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
        Me.btnDelete.Location = New System.Drawing.Point(809, 384)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = "Delete"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(904, 384)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
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
        Me.btnCancel.Location = New System.Drawing.Point(714, 384)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnCancel.Size = New System.Drawing.Size(90, 32)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        '
        'lblModifiedBy
        '
        Me.lblModifiedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedBy.Location = New System.Drawing.Point(4, 53)
        Me.lblModifiedBy.Name = "lblModifiedBy"
        Me.lblModifiedBy.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblModifiedBy.Size = New System.Drawing.Size(110, 23)
        Me.lblModifiedBy.TabIndex = 545
        Me.lblModifiedBy.Text = "Modified By"
        Me.lblModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblModifiedDate
        '
        Me.lblModifiedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedDate.Location = New System.Drawing.Point(4, 78)
        Me.lblModifiedDate.Name = "lblModifiedDate"
        Me.lblModifiedDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblModifiedDate.Size = New System.Drawing.Size(110, 23)
        Me.lblModifiedDate.TabIndex = 547
        Me.lblModifiedDate.Text = "Modified Date"
        Me.lblModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtModifiedBy
        '
        Me.txtModifiedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedBy.Location = New System.Drawing.Point(113, 53)
        Me.txtModifiedBy.Name = "txtModifiedBy"
        Me.txtModifiedBy.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtModifiedBy.Size = New System.Drawing.Size(200, 23)
        Me.txtModifiedBy.TabIndex = 585
        Me.txtModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtModifiedDate
        '
        Me.txtModifiedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedDate.Location = New System.Drawing.Point(113, 78)
        Me.txtModifiedDate.Name = "txtModifiedDate"
        Me.txtModifiedDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtModifiedDate.Size = New System.Drawing.Size(200, 23)
        Me.txtModifiedDate.TabIndex = 586
        Me.txtModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreatedDate
        '
        Me.lblCreatedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreatedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCreatedDate.ForeColor = System.Drawing.Color.Black
        Me.lblCreatedDate.Location = New System.Drawing.Point(4, 28)
        Me.lblCreatedDate.Name = "lblCreatedDate"
        Me.lblCreatedDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblCreatedDate.Size = New System.Drawing.Size(110, 23)
        Me.lblCreatedDate.TabIndex = 595
        Me.lblCreatedDate.Text = "Created Date"
        Me.lblCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreatedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCreatedBy.ForeColor = System.Drawing.Color.Black
        Me.lblCreatedBy.Location = New System.Drawing.Point(4, 3)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblCreatedBy.Size = New System.Drawing.Size(110, 23)
        Me.lblCreatedBy.TabIndex = 593
        Me.lblCreatedBy.Text = "Created By"
        Me.lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCompany
        '
        Me.lblCompany.BackColor = System.Drawing.SystemColors.Control
        Me.lblCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCompany.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCompany.ForeColor = System.Drawing.Color.Black
        Me.lblCompany.Location = New System.Drawing.Point(4, 103)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblCompany.Size = New System.Drawing.Size(110, 23)
        Me.lblCompany.TabIndex = 597
        Me.lblCompany.Text = "Company"
        Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCompany
        '
        Me.cmbCompany.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbCompany.FormattingEnabled = True
        Me.cmbCompany.Location = New System.Drawing.Point(113, 103)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.Size = New System.Drawing.Size(200, 23)
        Me.cmbCompany.TabIndex = 0
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.SystemColors.Control
        Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.Location = New System.Drawing.Point(4, 128)
        Me.lblName.Name = "lblName"
        Me.lblName.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblName.Size = New System.Drawing.Size(110, 23)
        Me.lblName.TabIndex = 600
        Me.lblName.Text = "Item Name"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblQty
        '
        Me.lblQty.BackColor = System.Drawing.SystemColors.Control
        Me.lblQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQty.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblQty.ForeColor = System.Drawing.Color.Black
        Me.lblQty.Location = New System.Drawing.Point(4, 228)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblQty.Size = New System.Drawing.Size(110, 23)
        Me.lblQty.TabIndex = 602
        Me.lblQty.Text = "Quantity"
        Me.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQty
        '
        Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtQty.Location = New System.Drawing.Point(113, 228)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(200, 23)
        Me.txtQty.TabIndex = 2
        Me.txtQty.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblCategory
        '
        Me.lblCategory.BackColor = System.Drawing.SystemColors.Control
        Me.lblCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCategory.ForeColor = System.Drawing.Color.Black
        Me.lblCategory.Location = New System.Drawing.Point(4, 153)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblCategory.Size = New System.Drawing.Size(110, 23)
        Me.lblCategory.TabIndex = 604
        Me.lblCategory.Text = "Category"
        Me.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCategory
        '
        Me.txtCategory.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCategory.ForeColor = System.Drawing.Color.Black
        Me.txtCategory.Location = New System.Drawing.Point(113, 153)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtCategory.Size = New System.Drawing.Size(200, 23)
        Me.txtCategory.TabIndex = 606
        Me.txtCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStock
        '
        Me.lblStock.BackColor = System.Drawing.SystemColors.Control
        Me.lblStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStock.ForeColor = System.Drawing.Color.Black
        Me.lblStock.Location = New System.Drawing.Point(4, 203)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblStock.Size = New System.Drawing.Size(110, 23)
        Me.lblStock.TabIndex = 608
        Me.lblStock.Text = "Current Stock"
        Me.lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblExpiration
        '
        Me.lblExpiration.BackColor = System.Drawing.SystemColors.Control
        Me.lblExpiration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblExpiration.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblExpiration.ForeColor = System.Drawing.Color.Black
        Me.lblExpiration.Location = New System.Drawing.Point(4, 253)
        Me.lblExpiration.Name = "lblExpiration"
        Me.lblExpiration.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblExpiration.Size = New System.Drawing.Size(110, 23)
        Me.lblExpiration.TabIndex = 609
        Me.lblExpiration.Text = "Expiration Date"
        Me.lblExpiration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtExpiration
        '
        Me.txtExpiration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExpiration.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtExpiration.Location = New System.Drawing.Point(113, 253)
        Me.txtExpiration.Mask = "00/00/0000"
        Me.txtExpiration.Name = "txtExpiration"
        Me.txtExpiration.PromptChar = Global.Microsoft.VisualBasic.ChrW(45)
        Me.txtExpiration.Size = New System.Drawing.Size(200, 23)
        Me.txtExpiration.TabIndex = 3
        Me.txtExpiration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtExpiration.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.txtExpiration.ValidatingType = GetType(Date)
        '
        'dgvDetail
        '
        Me.dgvDetail.AllowUserToAddRows = False
        Me.dgvDetail.AllowUserToDeleteRows = False
        Me.dgvDetail.AllowUserToResizeColumns = False
        Me.dgvDetail.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetail.ColumnHeadersHeight = 25
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColTrxId, Me.ColMedicineId, Me.ColStockOut, Me.ColEndingBalance})
        Me.dgvDetail.Location = New System.Drawing.Point(316, 28)
        Me.dgvDetail.MultiSelect = False
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.ReadOnly = True
        Me.dgvDetail.RowHeadersVisible = False
        Me.dgvDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetail.Size = New System.Drawing.Size(680, 350)
        Me.dgvDetail.TabIndex = 640
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
        Me.ColStockOut.HeaderText = "Quantity"
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
        'cmbName
        '
        Me.cmbName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbName.FormattingEnabled = True
        Me.cmbName.Location = New System.Drawing.Point(113, 128)
        Me.cmbName.Name = "cmbName"
        Me.cmbName.Size = New System.Drawing.Size(200, 23)
        Me.cmbName.TabIndex = 1
        '
        'txtStock
        '
        Me.txtStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtStock.ForeColor = System.Drawing.Color.Black
        Me.txtStock.Location = New System.Drawing.Point(113, 203)
        Me.txtStock.Name = "txtStock"
        Me.txtStock.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtStock.Size = New System.Drawing.Size(200, 23)
        Me.txtStock.TabIndex = 642
        Me.txtStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(4, 278)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Padding = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.lblRemarks.Size = New System.Drawing.Size(110, 100)
        Me.lblRemarks.TabIndex = 643
        Me.lblRemarks.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRemarks.Location = New System.Drawing.Point(113, 278)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(200, 100)
        Me.txtRemarks.TabIndex = 4
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCount.Location = New System.Drawing.Point(319, 7)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(56, 15)
        Me.lblCount.TabIndex = 649
        Me.lblCount.Text = "Quantity:"
        '
        'txtUnit
        '
        Me.txtUnit.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUnit.ForeColor = System.Drawing.Color.Black
        Me.txtUnit.Location = New System.Drawing.Point(113, 178)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtUnit.Size = New System.Drawing.Size(200, 23)
        Me.txtUnit.TabIndex = 651
        Me.txtUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUnit
        '
        Me.lblUnit.BackColor = System.Drawing.SystemColors.Control
        Me.lblUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUnit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnit.ForeColor = System.Drawing.Color.Black
        Me.lblUnit.Location = New System.Drawing.Point(4, 178)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblUnit.Size = New System.Drawing.Size(110, 23)
        Me.lblUnit.TabIndex = 650
        Me.lblUnit.Text = "UOM"
        Me.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRemove.DefaultScheme = True
        Me.btnRemove.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRemove.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnRemove.Hint = "Remove selected item"
        Me.btnRemove.Image = Global.HealthInformationSystem.My.Resources.Resources.Remove
        Me.btnRemove.Location = New System.Drawing.Point(99, 384)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemove.Size = New System.Drawing.Size(90, 32)
        Me.btnRemove.TabIndex = 6
        Me.btnRemove.Text = "Remove"
        '
        'ButtonXP2
        '
        Me.ButtonXP2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonXP2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonXP2.DefaultScheme = True
        Me.ButtonXP2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.ButtonXP2.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.ButtonXP2.Hint = "Add new item"
        Me.ButtonXP2.Image = Global.HealthInformationSystem.My.Resources.Resources.Apply
        Me.ButtonXP2.Location = New System.Drawing.Point(194, 384)
        Me.ButtonXP2.Name = "ButtonXP2"
        Me.ButtonXP2.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.ButtonXP2.Size = New System.Drawing.Size(119, 32)
        Me.ButtonXP2.TabIndex = 7
        Me.ButtonXP2.Text = "  Add Item"
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClear.DefaultScheme = True
        Me.btnClear.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnClear.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnClear.Hint = "Clear entry form"
        Me.btnClear.Image = Global.HealthInformationSystem.My.Resources.Resources.New_document
        Me.btnClear.Location = New System.Drawing.Point(4, 384)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClear.Size = New System.Drawing.Size(90, 32)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "Clear"
        '
        'btnList
        '
        Me.btnList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnList.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnList.DefaultScheme = True
        Me.btnList.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnList.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.btnList.Hint = "Delete"
        Me.btnList.Image = Global.HealthInformationSystem.My.Resources.Resources.List
        Me.btnList.Location = New System.Drawing.Point(316, 384)
        Me.btnList.Name = "btnList"
        Me.btnList.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnList.Size = New System.Drawing.Size(100, 32)
        Me.btnList.TabIndex = 8
        Me.btnList.Text = "View List"
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreatedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCreatedBy.ForeColor = System.Drawing.Color.Black
        Me.txtCreatedBy.Location = New System.Drawing.Point(113, 3)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtCreatedBy.Size = New System.Drawing.Size(200, 23)
        Me.txtCreatedBy.TabIndex = 658
        Me.txtCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCreatedDate
        '
        Me.txtCreatedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreatedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCreatedDate.ForeColor = System.Drawing.Color.Black
        Me.txtCreatedDate.Location = New System.Drawing.Point(113, 28)
        Me.txtCreatedDate.Name = "txtCreatedDate"
        Me.txtCreatedDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtCreatedDate.Size = New System.Drawing.Size(200, 23)
        Me.txtCreatedDate.TabIndex = 659
        Me.txtCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ReceiveMedicine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1000, 421)
        Me.Controls.Add(Me.txtCreatedDate)
        Me.Controls.Add(Me.txtCreatedBy)
        Me.Controls.Add(Me.lblCreatedBy)
        Me.Controls.Add(Me.btnList)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.ButtonXP2)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.txtStock)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.cmbName)
        Me.Controls.Add(Me.dgvDetail)
        Me.Controls.Add(Me.txtExpiration)
        Me.Controls.Add(Me.lblExpiration)
        Me.Controls.Add(Me.lblStock)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.lblQty)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.lblCompany)
        Me.Controls.Add(Me.cmbCompany)
        Me.Controls.Add(Me.lblCreatedDate)
        Me.Controls.Add(Me.lblModifiedDate)
        Me.Controls.Add(Me.lblModifiedBy)
        Me.Controls.Add(Me.txtModifiedDate)
        Me.Controls.Add(Me.txtModifiedBy)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReceiveMedicine"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Goods Receive"
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents lblModifiedBy As Label
    Friend WithEvents lblModifiedDate As Label
    Friend WithEvents txtModifiedBy As Label
    Friend WithEvents txtModifiedDate As Label
    Friend WithEvents lblCreatedDate As Label
    Friend WithEvents lblCreatedBy As Label
    Friend WithEvents lblCompany As Label
    Friend WithEvents cmbCompany As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblName As Label
    Friend WithEvents lblQty As Label
    Friend WithEvents txtQty As TextBox
    Friend WithEvents lblCategory As Label
    Friend WithEvents txtCategory As Label
    Friend WithEvents lblStock As Label
    Friend WithEvents lblExpiration As Label
    Friend WithEvents txtExpiration As MaskedTextBox
    Friend WithEvents dgvDetail As DataGridView
    Friend WithEvents ColTrxId As DataGridViewTextBoxColumn
    Friend WithEvents ColMedicineId As DataGridViewTextBoxColumn
    Friend WithEvents ColStockOut As DataGridViewTextBoxColumn
    Friend WithEvents ColEndingBalance As DataGridViewTextBoxColumn
    Friend WithEvents cmbName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtStock As Label
    Friend WithEvents lblRemarks As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents lblCount As Label
    Friend WithEvents txtUnit As Label
    Friend WithEvents lblUnit As Label
    Friend WithEvents btnRemove As PinkieControls.ButtonXP
    Friend WithEvents ButtonXP2 As PinkieControls.ButtonXP
    Friend WithEvents btnClear As PinkieControls.ButtonXP
    Friend WithEvents btnList As PinkieControls.ButtonXP
    Friend WithEvents txtCreatedBy As Label
    Friend WithEvents txtCreatedDate As Label
End Class
