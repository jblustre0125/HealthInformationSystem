<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MedicineDetail
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
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblMedicineName = New System.Windows.Forms.Label()
        Me.txtMedicineName = New System.Windows.Forms.TextBox()
        Me.txtCreatedDate = New System.Windows.Forms.Label()
        Me.lblCreatedDate = New System.Windows.Forms.Label()
        Me.txtCreatedBy = New System.Windows.Forms.Label()
        Me.lblCreatedBy = New System.Windows.Forms.Label()
        Me.txtModifiedDate = New System.Windows.Forms.Label()
        Me.lblModifiedDate = New System.Windows.Forms.Label()
        Me.txtModifiedBy = New System.Windows.Forms.Label()
        Me.lblModifiedBy = New System.Windows.Forms.Label()
        Me.lblStock = New System.Windows.Forms.Label()
        Me.txtOrderingPoint = New System.Windows.Forms.TextBox()
        Me.lblOrderingPoint = New System.Windows.Forms.Label()
        Me.txtMinStock = New System.Windows.Forms.TextBox()
        Me.lblMinStock = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.cmbUnit = New SergeUtils.EasyCompletionComboBox()
        Me.txtMaxStock = New System.Windows.Forms.TextBox()
        Me.lblMaxStock = New System.Windows.Forms.Label()
        Me.cmbCategory = New SergeUtils.EasyCompletionComboBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.txtUnitPrice = New System.Windows.Forms.TextBox()
        Me.lblUnitPrice = New System.Windows.Forms.Label()
        Me.pnlStatus = New System.Windows.Forms.Panel()
        Me.rdInactive = New System.Windows.Forms.RadioButton()
        Me.rdActive = New System.Windows.Forms.RadioButton()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.pnlStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = False
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(308, 371)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 11
        Me.btnClose.TabStop = False
        Me.btnClose.Text = "Close"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDelete.DefaultScheme = False
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDelete.Hint = "Delete record"
        Me.btnDelete.Location = New System.Drawing.Point(214, 371)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "Delete"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSave.DefaultScheme = False
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnSave.Hint = "Save record"
        Me.btnSave.Location = New System.Drawing.Point(120, 371)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 9
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "Save"
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(4, 302)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblStatus.Size = New System.Drawing.Size(100, 23)
        Me.lblStatus.TabIndex = 568
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMedicineName
        '
        Me.lblMedicineName.BackColor = System.Drawing.SystemColors.Control
        Me.lblMedicineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMedicineName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMedicineName.ForeColor = System.Drawing.Color.Black
        Me.lblMedicineName.Location = New System.Drawing.Point(4, 102)
        Me.lblMedicineName.Name = "lblMedicineName"
        Me.lblMedicineName.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblMedicineName.Size = New System.Drawing.Size(100, 23)
        Me.lblMedicineName.TabIndex = 555
        Me.lblMedicineName.Text = "Name"
        Me.lblMedicineName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMedicineName
        '
        Me.txtMedicineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMedicineName.Location = New System.Drawing.Point(103, 102)
        Me.txtMedicineName.MaxLength = 50
        Me.txtMedicineName.Name = "txtMedicineName"
        Me.txtMedicineName.Size = New System.Drawing.Size(295, 23)
        Me.txtMedicineName.TabIndex = 0
        '
        'txtCreatedDate
        '
        Me.txtCreatedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreatedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCreatedDate.ForeColor = System.Drawing.Color.Black
        Me.txtCreatedDate.Location = New System.Drawing.Point(103, 27)
        Me.txtCreatedDate.Name = "txtCreatedDate"
        Me.txtCreatedDate.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtCreatedDate.Size = New System.Drawing.Size(295, 23)
        Me.txtCreatedDate.TabIndex = 591
        Me.txtCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtCreatedDate.UseCompatibleTextRendering = True
        '
        'lblCreatedDate
        '
        Me.lblCreatedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreatedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCreatedDate.ForeColor = System.Drawing.Color.Black
        Me.lblCreatedDate.Location = New System.Drawing.Point(4, 27)
        Me.lblCreatedDate.Name = "lblCreatedDate"
        Me.lblCreatedDate.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblCreatedDate.Size = New System.Drawing.Size(100, 23)
        Me.lblCreatedDate.TabIndex = 593
        Me.lblCreatedDate.Text = "Created Date"
        Me.lblCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreatedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCreatedBy.ForeColor = System.Drawing.Color.Black
        Me.txtCreatedBy.Location = New System.Drawing.Point(103, 2)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtCreatedBy.Size = New System.Drawing.Size(295, 23)
        Me.txtCreatedBy.TabIndex = 590
        Me.txtCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtCreatedBy.UseCompatibleTextRendering = True
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreatedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCreatedBy.ForeColor = System.Drawing.Color.Black
        Me.lblCreatedBy.Location = New System.Drawing.Point(4, 2)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblCreatedBy.Size = New System.Drawing.Size(100, 23)
        Me.lblCreatedBy.TabIndex = 592
        Me.lblCreatedBy.Text = "Created By"
        Me.lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtModifiedDate
        '
        Me.txtModifiedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedDate.Location = New System.Drawing.Point(103, 77)
        Me.txtModifiedDate.Name = "txtModifiedDate"
        Me.txtModifiedDate.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtModifiedDate.Size = New System.Drawing.Size(295, 23)
        Me.txtModifiedDate.TabIndex = 595
        Me.txtModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtModifiedDate.UseCompatibleTextRendering = True
        '
        'lblModifiedDate
        '
        Me.lblModifiedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedDate.Location = New System.Drawing.Point(4, 77)
        Me.lblModifiedDate.Name = "lblModifiedDate"
        Me.lblModifiedDate.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblModifiedDate.Size = New System.Drawing.Size(100, 23)
        Me.lblModifiedDate.TabIndex = 597
        Me.lblModifiedDate.Text = "Modified Date"
        Me.lblModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtModifiedBy
        '
        Me.txtModifiedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedBy.Location = New System.Drawing.Point(103, 52)
        Me.txtModifiedBy.Name = "txtModifiedBy"
        Me.txtModifiedBy.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtModifiedBy.Size = New System.Drawing.Size(295, 23)
        Me.txtModifiedBy.TabIndex = 594
        Me.txtModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtModifiedBy.UseCompatibleTextRendering = True
        '
        'lblModifiedBy
        '
        Me.lblModifiedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedBy.Location = New System.Drawing.Point(4, 52)
        Me.lblModifiedBy.Name = "lblModifiedBy"
        Me.lblModifiedBy.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblModifiedBy.Size = New System.Drawing.Size(100, 23)
        Me.lblModifiedBy.TabIndex = 596
        Me.lblModifiedBy.Text = "Modified By"
        Me.lblModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStock
        '
        Me.lblStock.BackColor = System.Drawing.SystemColors.Control
        Me.lblStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStock.ForeColor = System.Drawing.Color.Black
        Me.lblStock.Location = New System.Drawing.Point(4, 277)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblStock.Size = New System.Drawing.Size(100, 23)
        Me.lblStock.TabIndex = 599
        Me.lblStock.Text = "Current Stock"
        Me.lblStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOrderingPoint
        '
        Me.txtOrderingPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOrderingPoint.Location = New System.Drawing.Point(103, 177)
        Me.txtOrderingPoint.MaxLength = 50
        Me.txtOrderingPoint.Name = "txtOrderingPoint"
        Me.txtOrderingPoint.Size = New System.Drawing.Size(295, 23)
        Me.txtOrderingPoint.TabIndex = 3
        Me.txtOrderingPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblOrderingPoint
        '
        Me.lblOrderingPoint.BackColor = System.Drawing.SystemColors.Control
        Me.lblOrderingPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOrderingPoint.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblOrderingPoint.ForeColor = System.Drawing.Color.Black
        Me.lblOrderingPoint.Location = New System.Drawing.Point(4, 177)
        Me.lblOrderingPoint.Name = "lblOrderingPoint"
        Me.lblOrderingPoint.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblOrderingPoint.Size = New System.Drawing.Size(100, 23)
        Me.lblOrderingPoint.TabIndex = 601
        Me.lblOrderingPoint.Text = "Ordering Point"
        Me.lblOrderingPoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMinStock
        '
        Me.txtMinStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMinStock.Location = New System.Drawing.Point(103, 227)
        Me.txtMinStock.MaxLength = 50
        Me.txtMinStock.Name = "txtMinStock"
        Me.txtMinStock.Size = New System.Drawing.Size(295, 23)
        Me.txtMinStock.TabIndex = 5
        Me.txtMinStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMinStock
        '
        Me.lblMinStock.BackColor = System.Drawing.SystemColors.Control
        Me.lblMinStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMinStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMinStock.ForeColor = System.Drawing.Color.Black
        Me.lblMinStock.Location = New System.Drawing.Point(4, 227)
        Me.lblMinStock.Name = "lblMinStock"
        Me.lblMinStock.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblMinStock.Size = New System.Drawing.Size(100, 23)
        Me.lblMinStock.TabIndex = 603
        Me.lblMinStock.Text = "Min Stock"
        Me.lblMinStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCategory
        '
        Me.lblCategory.BackColor = System.Drawing.SystemColors.Control
        Me.lblCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCategory.ForeColor = System.Drawing.Color.Black
        Me.lblCategory.Location = New System.Drawing.Point(4, 127)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblCategory.Size = New System.Drawing.Size(100, 23)
        Me.lblCategory.TabIndex = 605
        Me.lblCategory.Text = "Category"
        Me.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUnit
        '
        Me.lblUnit.BackColor = System.Drawing.SystemColors.Control
        Me.lblUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUnit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnit.ForeColor = System.Drawing.Color.Black
        Me.lblUnit.Location = New System.Drawing.Point(4, 152)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblUnit.Size = New System.Drawing.Size(100, 23)
        Me.lblUnit.TabIndex = 607
        Me.lblUnit.Text = "UOM"
        Me.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbUnit
        '
        Me.cmbUnit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbUnit.FormattingEnabled = True
        Me.cmbUnit.Location = New System.Drawing.Point(103, 152)
        Me.cmbUnit.Name = "cmbUnit"
        Me.cmbUnit.Size = New System.Drawing.Size(295, 23)
        Me.cmbUnit.TabIndex = 2
        '
        'txtMaxStock
        '
        Me.txtMaxStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaxStock.Location = New System.Drawing.Point(103, 202)
        Me.txtMaxStock.MaxLength = 50
        Me.txtMaxStock.Name = "txtMaxStock"
        Me.txtMaxStock.Size = New System.Drawing.Size(295, 23)
        Me.txtMaxStock.TabIndex = 4
        Me.txtMaxStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMaxStock
        '
        Me.lblMaxStock.BackColor = System.Drawing.SystemColors.Control
        Me.lblMaxStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMaxStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMaxStock.ForeColor = System.Drawing.Color.Black
        Me.lblMaxStock.Location = New System.Drawing.Point(4, 202)
        Me.lblMaxStock.Name = "lblMaxStock"
        Me.lblMaxStock.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblMaxStock.Size = New System.Drawing.Size(100, 23)
        Me.lblMaxStock.TabIndex = 613
        Me.lblMaxStock.Text = "Max Stock"
        Me.lblMaxStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCategory
        '
        Me.cmbCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(103, 127)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(295, 23)
        Me.cmbCategory.TabIndex = 1
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Location = New System.Drawing.Point(103, 327)
        Me.txtRemarks.MaxLength = 50
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(295, 40)
        Me.txtRemarks.TabIndex = 9
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemarks.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(4, 327)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblRemarks.Size = New System.Drawing.Size(100, 40)
        Me.lblRemarks.TabIndex = 624
        Me.lblRemarks.Text = "Remarks"
        Me.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitPrice.Location = New System.Drawing.Point(103, 252)
        Me.txtUnitPrice.MaxLength = 50
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(295, 23)
        Me.txtUnitPrice.TabIndex = 6
        Me.txtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.BackColor = System.Drawing.SystemColors.Control
        Me.lblUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUnitPrice.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnitPrice.ForeColor = System.Drawing.Color.Black
        Me.lblUnitPrice.Location = New System.Drawing.Point(4, 252)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblUnitPrice.Size = New System.Drawing.Size(100, 23)
        Me.lblUnitPrice.TabIndex = 626
        Me.lblUnitPrice.Text = "Unit Price"
        Me.lblUnitPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlStatus
        '
        Me.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStatus.Controls.Add(Me.rdInactive)
        Me.pnlStatus.Controls.Add(Me.rdActive)
        Me.pnlStatus.Location = New System.Drawing.Point(103, 302)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(295, 23)
        Me.pnlStatus.TabIndex = 8
        '
        'rdInactive
        '
        Me.rdInactive.AutoSize = True
        Me.rdInactive.Location = New System.Drawing.Point(164, 1)
        Me.rdInactive.Name = "rdInactive"
        Me.rdInactive.Size = New System.Drawing.Size(66, 19)
        Me.rdInactive.TabIndex = 1
        Me.rdInactive.TabStop = True
        Me.rdInactive.Text = "Inactive"
        Me.rdInactive.UseVisualStyleBackColor = True
        '
        'rdActive
        '
        Me.rdActive.AutoSize = True
        Me.rdActive.Location = New System.Drawing.Point(62, 1)
        Me.rdActive.Name = "rdActive"
        Me.rdActive.Size = New System.Drawing.Size(58, 19)
        Me.rdActive.TabIndex = 0
        Me.rdActive.TabStop = True
        Me.rdActive.Text = "Active"
        Me.rdActive.UseVisualStyleBackColor = True
        '
        'txtStock
        '
        Me.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStock.Location = New System.Drawing.Point(103, 277)
        Me.txtStock.MaxLength = 50
        Me.txtStock.Name = "txtStock"
        Me.txtStock.Size = New System.Drawing.Size(295, 23)
        Me.txtStock.TabIndex = 7
        Me.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MedicineDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(402, 407)
        Me.Controls.Add(Me.txtStock)
        Me.Controls.Add(Me.txtUnitPrice)
        Me.Controls.Add(Me.lblUnitPrice)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.cmbCategory)
        Me.Controls.Add(Me.txtMaxStock)
        Me.Controls.Add(Me.lblMaxStock)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.cmbUnit)
        Me.Controls.Add(Me.txtMinStock)
        Me.Controls.Add(Me.lblMinStock)
        Me.Controls.Add(Me.txtOrderingPoint)
        Me.Controls.Add(Me.lblOrderingPoint)
        Me.Controls.Add(Me.lblStock)
        Me.Controls.Add(Me.txtModifiedDate)
        Me.Controls.Add(Me.lblModifiedDate)
        Me.Controls.Add(Me.txtModifiedBy)
        Me.Controls.Add(Me.lblModifiedBy)
        Me.Controls.Add(Me.txtCreatedDate)
        Me.Controls.Add(Me.lblCreatedDate)
        Me.Controls.Add(Me.txtCreatedBy)
        Me.Controls.Add(Me.lblCreatedBy)
        Me.Controls.Add(Me.txtMedicineName)
        Me.Controls.Add(Me.lblMedicineName)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MedicineDetail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Medicine Detail"
        Me.pnlStatus.ResumeLayout(False)
        Me.pnlStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents lblMedicineName As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents txtMedicineName As TextBox
    Friend WithEvents txtCreatedDate As Label
    Friend WithEvents lblCreatedDate As Label
    Friend WithEvents txtCreatedBy As Label
    Friend WithEvents lblCreatedBy As Label
    Friend WithEvents txtModifiedDate As Label
    Friend WithEvents lblModifiedDate As Label
    Friend WithEvents txtModifiedBy As Label
    Friend WithEvents lblModifiedBy As Label
    Friend WithEvents lblStock As Label
    Friend WithEvents txtOrderingPoint As TextBox
    Friend WithEvents lblOrderingPoint As Label
    Friend WithEvents txtMinStock As TextBox
    Friend WithEvents lblMinStock As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblUnit As Label
    Friend WithEvents cmbUnit As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtMaxStock As TextBox
    Friend WithEvents lblMaxStock As Label
    Friend WithEvents cmbCategory As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents lblRemarks As Label
    Friend WithEvents txtUnitPrice As TextBox
    Friend WithEvents lblUnitPrice As Label
    Friend WithEvents pnlStatus As Panel
    Friend WithEvents rdInactive As RadioButton
    Friend WithEvents rdActive As RadioButton
    Friend WithEvents txtStock As TextBox
End Class
