<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MedicineReceive
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
        Me.lblMedicineReceiving = New System.Windows.Forms.Label()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.cmbMedicine = New SergeUtils.EasyCompletionComboBox()
        Me.lblCurrentStock = New System.Windows.Forms.Label()
        Me.txtCurrentStock = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.txtUnit = New System.Windows.Forms.Label()
        Me.btnAdd = New PinkieControls.ButtonXP()
        Me.btnRemove = New PinkieControls.ButtonXP()
        Me.dgvTrxDetail = New System.Windows.Forms.DataGridView()
        Me.txtOrderingPoint = New System.Windows.Forms.Label()
        Me.lblOrderingPoint = New System.Windows.Forms.Label()
        Me.lblItemList = New System.Windows.Forms.Label()
        Me.lblReceiver = New System.Windows.Forms.Label()
        Me.cmbReceiver = New SergeUtils.EasyCompletionComboBox()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.lblDateReceived = New System.Windows.Forms.Label()
        Me.dtpDateReceived = New System.Windows.Forms.DateTimePicker()
        Me.lblMedicine = New System.Windows.Forms.Label()
        Me.ColMedicineId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStockId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvTrxDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMedicineReceiving
        '
        Me.lblMedicineReceiving.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMedicineReceiving.BackColor = System.Drawing.SystemColors.Control
        Me.lblMedicineReceiving.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMedicineReceiving.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMedicineReceiving.ForeColor = System.Drawing.Color.Black
        Me.lblMedicineReceiving.Location = New System.Drawing.Point(4, 2)
        Me.lblMedicineReceiving.Name = "lblMedicineReceiving"
        Me.lblMedicineReceiving.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblMedicineReceiving.Size = New System.Drawing.Size(750, 24)
        Me.lblMedicineReceiving.TabIndex = 565
        Me.lblMedicineReceiving.Text = "Medicine Receiving Form"
        Me.lblMedicineReceiving.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.CausesValidation = False
        Me.btnClose.DefaultScheme = False
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(665, 412)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 589
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Close"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDelete.DefaultScheme = False
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnDelete.Hint = "Delete record"
        Me.btnDelete.Location = New System.Drawing.Point(571, 412)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 588
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "Delete"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancel.CausesValidation = False
        Me.btnCancel.DefaultScheme = False
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnCancel.Hint = "Cancel changes"
        Me.btnCancel.Location = New System.Drawing.Point(477, 412)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnCancel.Size = New System.Drawing.Size(90, 32)
        Me.btnCancel.TabIndex = 587
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "Cancel"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSave.DefaultScheme = False
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnSave.Hint = "Save record"
        Me.btnSave.Location = New System.Drawing.Point(383, 412)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 586
        Me.btnSave.TabStop = False
        Me.btnSave.Text = " Save"
        '
        'cmbMedicine
        '
        Me.cmbMedicine.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMedicine.FormattingEnabled = True
        Me.cmbMedicine.Location = New System.Drawing.Point(122, 55)
        Me.cmbMedicine.Name = "cmbMedicine"
        Me.cmbMedicine.Size = New System.Drawing.Size(632, 25)
        Me.cmbMedicine.TabIndex = 3
        '
        'lblCurrentStock
        '
        Me.lblCurrentStock.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrentStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCurrentStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCurrentStock.ForeColor = System.Drawing.Color.Black
        Me.lblCurrentStock.Location = New System.Drawing.Point(198, 82)
        Me.lblCurrentStock.Name = "lblCurrentStock"
        Me.lblCurrentStock.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblCurrentStock.Size = New System.Drawing.Size(90, 25)
        Me.lblCurrentStock.TabIndex = 593
        Me.lblCurrentStock.Text = "Current Stock"
        Me.lblCurrentStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCurrentStock
        '
        Me.txtCurrentStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCurrentStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCurrentStock.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.txtCurrentStock.ForeColor = System.Drawing.Color.Black
        Me.txtCurrentStock.Location = New System.Drawing.Point(287, 82)
        Me.txtCurrentStock.Name = "txtCurrentStock"
        Me.txtCurrentStock.Size = New System.Drawing.Size(80, 25)
        Me.txtCurrentStock.TabIndex = 592
        Me.txtCurrentStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtCurrentStock.UseCompatibleTextRendering = True
        '
        'lblQty
        '
        Me.lblQty.BackColor = System.Drawing.SystemColors.Control
        Me.lblQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQty.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblQty.ForeColor = System.Drawing.Color.Black
        Me.lblQty.Location = New System.Drawing.Point(3, 82)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblQty.Size = New System.Drawing.Size(120, 25)
        Me.lblQty.TabIndex = 595
        Me.lblQty.Text = "Quantity"
        Me.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQty
        '
        Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQty.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtQty.Location = New System.Drawing.Point(122, 82)
        Me.txtQty.MaxLength = 15
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(73, 25)
        Me.txtQty.TabIndex = 4
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblUnit
        '
        Me.lblUnit.BackColor = System.Drawing.SystemColors.Control
        Me.lblUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUnit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnit.ForeColor = System.Drawing.Color.Black
        Me.lblUnit.Location = New System.Drawing.Point(552, 82)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblUnit.Size = New System.Drawing.Size(50, 25)
        Me.lblUnit.TabIndex = 598
        Me.lblUnit.Text = "UOM"
        Me.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnit
        '
        Me.txtUnit.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnit.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtUnit.ForeColor = System.Drawing.Color.Black
        Me.txtUnit.Location = New System.Drawing.Point(601, 82)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(153, 25)
        Me.txtUnit.TabIndex = 597
        Me.txtUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtUnit.UseCompatibleTextRendering = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdd.DefaultScheme = False
        Me.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnAdd.Hint = ""
        Me.btnAdd.Location = New System.Drawing.Point(573, 196)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnAdd.Size = New System.Drawing.Size(90, 32)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "Add"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRemove.DefaultScheme = False
        Me.btnRemove.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnRemove.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.btnRemove.Hint = "Remove selected items"
        Me.btnRemove.Location = New System.Drawing.Point(665, 196)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnRemove.Size = New System.Drawing.Size(90, 32)
        Me.btnRemove.TabIndex = 7
        Me.btnRemove.Text = "Remove"
        '
        'dgvTrxDetail
        '
        Me.dgvTrxDetail.AllowUserToAddRows = False
        Me.dgvTrxDetail.AllowUserToDeleteRows = False
        Me.dgvTrxDetail.AllowUserToResizeColumns = False
        Me.dgvTrxDetail.AllowUserToResizeRows = False
        Me.dgvTrxDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTrxDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTrxDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvTrxDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColMedicineId, Me.ColStockId, Me.ColQty})
        Me.dgvTrxDetail.Location = New System.Drawing.Point(3, 254)
        Me.dgvTrxDetail.MultiSelect = False
        Me.dgvTrxDetail.Name = "dgvTrxDetail"
        Me.dgvTrxDetail.ReadOnly = True
        Me.dgvTrxDetail.RowHeadersVisible = False
        Me.dgvTrxDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvTrxDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTrxDetail.Size = New System.Drawing.Size(752, 150)
        Me.dgvTrxDetail.TabIndex = 603
        Me.dgvTrxDetail.TabStop = False
        '
        'txtOrderingPoint
        '
        Me.txtOrderingPoint.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtOrderingPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrderingPoint.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtOrderingPoint.ForeColor = System.Drawing.Color.Black
        Me.txtOrderingPoint.Location = New System.Drawing.Point(469, 82)
        Me.txtOrderingPoint.Name = "txtOrderingPoint"
        Me.txtOrderingPoint.Size = New System.Drawing.Size(80, 25)
        Me.txtOrderingPoint.TabIndex = 599
        Me.txtOrderingPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtOrderingPoint.UseCompatibleTextRendering = True
        '
        'lblOrderingPoint
        '
        Me.lblOrderingPoint.BackColor = System.Drawing.SystemColors.Control
        Me.lblOrderingPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrderingPoint.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblOrderingPoint.ForeColor = System.Drawing.Color.Black
        Me.lblOrderingPoint.Location = New System.Drawing.Point(370, 82)
        Me.lblOrderingPoint.Name = "lblOrderingPoint"
        Me.lblOrderingPoint.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblOrderingPoint.Size = New System.Drawing.Size(100, 25)
        Me.lblOrderingPoint.TabIndex = 600
        Me.lblOrderingPoint.Text = "Ordering Point"
        Me.lblOrderingPoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblItemList
        '
        Me.lblItemList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblItemList.BackColor = System.Drawing.SystemColors.Control
        Me.lblItemList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblItemList.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblItemList.ForeColor = System.Drawing.Color.Black
        Me.lblItemList.Location = New System.Drawing.Point(3, 231)
        Me.lblItemList.Name = "lblItemList"
        Me.lblItemList.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblItemList.Size = New System.Drawing.Size(752, 24)
        Me.lblItemList.TabIndex = 616
        Me.lblItemList.Text = "Item List"
        Me.lblItemList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblReceiver
        '
        Me.lblReceiver.BackColor = System.Drawing.SystemColors.Control
        Me.lblReceiver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReceiver.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblReceiver.ForeColor = System.Drawing.Color.Black
        Me.lblReceiver.Location = New System.Drawing.Point(315, 28)
        Me.lblReceiver.Name = "lblReceiver"
        Me.lblReceiver.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblReceiver.Size = New System.Drawing.Size(120, 25)
        Me.lblReceiver.TabIndex = 627
        Me.lblReceiver.Text = "Received By"
        Me.lblReceiver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbReceiver
        '
        Me.cmbReceiver.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbReceiver.FormattingEnabled = True
        Me.cmbReceiver.Location = New System.Drawing.Point(434, 28)
        Me.cmbReceiver.Name = "cmbReceiver"
        Me.cmbReceiver.Size = New System.Drawing.Size(320, 25)
        Me.cmbReceiver.TabIndex = 2
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(3, 109)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblRemarks.Size = New System.Drawing.Size(751, 23)
        Me.lblRemarks.TabIndex = 631
        Me.lblRemarks.Text = "Remarks"
        Me.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRemarks.Location = New System.Drawing.Point(3, 131)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(751, 62)
        Me.txtRemarks.TabIndex = 5
        '
        'lblDateReceived
        '
        Me.lblDateReceived.BackColor = System.Drawing.SystemColors.Control
        Me.lblDateReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDateReceived.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDateReceived.ForeColor = System.Drawing.Color.Black
        Me.lblDateReceived.Location = New System.Drawing.Point(3, 28)
        Me.lblDateReceived.Name = "lblDateReceived"
        Me.lblDateReceived.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblDateReceived.Size = New System.Drawing.Size(120, 25)
        Me.lblDateReceived.TabIndex = 635
        Me.lblDateReceived.Text = "Date Received"
        Me.lblDateReceived.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpDateReceived
        '
        Me.dtpDateReceived.CustomFormat = "MMMM dd, yyyy"
        Me.dtpDateReceived.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.dtpDateReceived.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateReceived.Location = New System.Drawing.Point(122, 28)
        Me.dtpDateReceived.Name = "dtpDateReceived"
        Me.dtpDateReceived.Size = New System.Drawing.Size(190, 25)
        Me.dtpDateReceived.TabIndex = 0
        '
        'lblMedicine
        '
        Me.lblMedicine.BackColor = System.Drawing.SystemColors.Control
        Me.lblMedicine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMedicine.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMedicine.ForeColor = System.Drawing.Color.Black
        Me.lblMedicine.Location = New System.Drawing.Point(3, 55)
        Me.lblMedicine.Name = "lblMedicine"
        Me.lblMedicine.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.lblMedicine.Size = New System.Drawing.Size(120, 25)
        Me.lblMedicine.TabIndex = 636
        Me.lblMedicine.Text = "Medicine"
        Me.lblMedicine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ColMedicineId
        '
        Me.ColMedicineId.DataPropertyName = "MedicineId"
        Me.ColMedicineId.HeaderText = "MedicineId"
        Me.ColMedicineId.Name = "ColMedicineId"
        Me.ColMedicineId.ReadOnly = True
        Me.ColMedicineId.Visible = False
        '
        'ColStockId
        '
        Me.ColStockId.DataPropertyName = "StockId"
        Me.ColStockId.HeaderText = "StockId"
        Me.ColStockId.Name = "ColStockId"
        Me.ColStockId.ReadOnly = True
        Me.ColStockId.Visible = False
        '
        'ColQty
        '
        Me.ColQty.DataPropertyName = "Qty"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColQty.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColQty.HeaderText = "Quantity"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.ReadOnly = True
        Me.ColQty.Width = 60
        '
        'MedicineReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(758, 447)
        Me.Controls.Add(Me.lblMedicine)
        Me.Controls.Add(Me.lblDateReceived)
        Me.Controls.Add(Me.dtpDateReceived)
        Me.Controls.Add(Me.cmbMedicine)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.lblReceiver)
        Me.Controls.Add(Me.cmbReceiver)
        Me.Controls.Add(Me.lblItemList)
        Me.Controls.Add(Me.dgvTrxDetail)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblOrderingPoint)
        Me.Controls.Add(Me.txtOrderingPoint)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.lblQty)
        Me.Controls.Add(Me.lblCurrentStock)
        Me.Controls.Add(Me.txtCurrentStock)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblMedicineReceiving)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MedicineReceive"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.dgvTrxDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMedicineReceiving As Label
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents cmbMedicine As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblCurrentStock As Label
    Public WithEvents txtCurrentStock As Label
    Friend WithEvents lblQty As Label
    Friend WithEvents txtQty As TextBox
    Friend WithEvents lblUnit As Label
    Public WithEvents txtUnit As Label
    Friend WithEvents btnAdd As PinkieControls.ButtonXP
    Friend WithEvents btnRemove As PinkieControls.ButtonXP
    Public WithEvents txtOrderingPoint As Label
    Friend WithEvents lblOrderingPoint As Label
    Public WithEvents dgvTrxDetail As DataGridView
    Friend WithEvents lblItemList As Label
    Friend WithEvents lblReceiver As Label
    Friend WithEvents cmbReceiver As SergeUtils.EasyCompletionComboBox
    Friend WithEvents lblRemarks As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents lblDateReceived As Label
    Friend WithEvents dtpDateReceived As DateTimePicker
    Friend WithEvents lblMedicine As Label
    Friend WithEvents ColMedicineId As DataGridViewTextBoxColumn
    Friend WithEvents ColStockId As DataGridViewTextBoxColumn
    Friend WithEvents ColQty As DataGridViewTextBoxColumn
End Class
