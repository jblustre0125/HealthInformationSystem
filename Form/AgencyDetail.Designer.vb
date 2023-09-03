<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AgencyDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgencyDetail))
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.lblModifiedBy = New System.Windows.Forms.Label()
        Me.txtEmployeeCode = New System.Windows.Forms.TextBox()
        Me.lblModifiedDate = New System.Windows.Forms.Label()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.txtModifiedBy = New System.Windows.Forms.Label()
        Me.txtModifiedDate = New System.Windows.Forms.Label()
        Me.lblEmployeeName = New System.Windows.Forms.Label()
        Me.lblEmployeeCode = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblAgency = New System.Windows.Forms.Label()
        Me.cmbAgency = New SergeUtils.EasyCompletionComboBox()
        Me.pnlStatus = New System.Windows.Forms.Panel()
        Me.rdInactive = New System.Windows.Forms.RadioButton()
        Me.rdActive = New System.Windows.Forms.RadioButton()
        Me.pnlStatus.SuspendLayout()
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
        Me.btnSave.Location = New System.Drawing.Point(6, 161)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 2
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
        Me.btnDelete.Location = New System.Drawing.Point(196, 161)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 4
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
        Me.btnClose.Location = New System.Drawing.Point(291, 161)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 5
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
        Me.btnCancel.Location = New System.Drawing.Point(101, 161)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnCancel.Size = New System.Drawing.Size(90, 32)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        '
        'lblModifiedBy
        '
        Me.lblModifiedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedBy.Location = New System.Drawing.Point(4, 4)
        Me.lblModifiedBy.Name = "lblModifiedBy"
        Me.lblModifiedBy.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblModifiedBy.Size = New System.Drawing.Size(110, 23)
        Me.lblModifiedBy.TabIndex = 545
        Me.lblModifiedBy.Text = "Modified By"
        Me.lblModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeCode
        '
        Me.txtEmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmployeeCode.Location = New System.Drawing.Point(113, 54)
        Me.txtEmployeeCode.Name = "txtEmployeeCode"
        Me.txtEmployeeCode.Size = New System.Drawing.Size(270, 23)
        Me.txtEmployeeCode.TabIndex = 544
        '
        'lblModifiedDate
        '
        Me.lblModifiedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.lblModifiedDate.Location = New System.Drawing.Point(4, 29)
        Me.lblModifiedDate.Name = "lblModifiedDate"
        Me.lblModifiedDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblModifiedDate.Size = New System.Drawing.Size(110, 23)
        Me.lblModifiedDate.TabIndex = 547
        Me.lblModifiedDate.Text = "Modified Date"
        Me.lblModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmployeeName.Location = New System.Drawing.Point(113, 79)
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.Size = New System.Drawing.Size(270, 23)
        Me.txtEmployeeName.TabIndex = 546
        '
        'txtModifiedBy
        '
        Me.txtModifiedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedBy.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedBy.Location = New System.Drawing.Point(113, 4)
        Me.txtModifiedBy.Name = "txtModifiedBy"
        Me.txtModifiedBy.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtModifiedBy.Size = New System.Drawing.Size(270, 23)
        Me.txtModifiedBy.TabIndex = 585
        Me.txtModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtModifiedDate
        '
        Me.txtModifiedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModifiedDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModifiedDate.ForeColor = System.Drawing.Color.Black
        Me.txtModifiedDate.Location = New System.Drawing.Point(113, 29)
        Me.txtModifiedDate.Name = "txtModifiedDate"
        Me.txtModifiedDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtModifiedDate.Size = New System.Drawing.Size(270, 23)
        Me.txtModifiedDate.TabIndex = 586
        Me.txtModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmployeeName
        '
        Me.lblEmployeeName.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmployeeName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEmployeeName.ForeColor = System.Drawing.Color.Black
        Me.lblEmployeeName.Location = New System.Drawing.Point(4, 79)
        Me.lblEmployeeName.Name = "lblEmployeeName"
        Me.lblEmployeeName.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmployeeName.Size = New System.Drawing.Size(110, 23)
        Me.lblEmployeeName.TabIndex = 588
        Me.lblEmployeeName.Text = "Employee Name"
        Me.lblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmployeeCode
        '
        Me.lblEmployeeCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmployeeCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEmployeeCode.ForeColor = System.Drawing.Color.Black
        Me.lblEmployeeCode.Location = New System.Drawing.Point(4, 54)
        Me.lblEmployeeCode.Name = "lblEmployeeCode"
        Me.lblEmployeeCode.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblEmployeeCode.Size = New System.Drawing.Size(110, 23)
        Me.lblEmployeeCode.TabIndex = 587
        Me.lblEmployeeCode.Text = "Employee Code"
        Me.lblEmployeeCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(4, 129)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblStatus.Size = New System.Drawing.Size(110, 23)
        Me.lblStatus.TabIndex = 590
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAgency
        '
        Me.lblAgency.BackColor = System.Drawing.SystemColors.Control
        Me.lblAgency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAgency.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAgency.ForeColor = System.Drawing.Color.Black
        Me.lblAgency.Location = New System.Drawing.Point(4, 104)
        Me.lblAgency.Name = "lblAgency"
        Me.lblAgency.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblAgency.Size = New System.Drawing.Size(110, 23)
        Me.lblAgency.TabIndex = 589
        Me.lblAgency.Text = "Agency"
        Me.lblAgency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAgency
        '
        Me.cmbAgency.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbAgency.FormattingEnabled = True
        Me.cmbAgency.Location = New System.Drawing.Point(113, 104)
        Me.cmbAgency.Name = "cmbAgency"
        Me.cmbAgency.Size = New System.Drawing.Size(270, 23)
        Me.cmbAgency.TabIndex = 591
        '
        'pnlStatus
        '
        Me.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStatus.Controls.Add(Me.rdInactive)
        Me.pnlStatus.Controls.Add(Me.rdActive)
        Me.pnlStatus.Location = New System.Drawing.Point(113, 129)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(270, 23)
        Me.pnlStatus.TabIndex = 592
        '
        'rdInactive
        '
        Me.rdInactive.AutoSize = True
        Me.rdInactive.Location = New System.Drawing.Point(143, 1)
        Me.rdInactive.Name = "rdInactive"
        Me.rdInactive.Size = New System.Drawing.Size(66, 19)
        Me.rdInactive.TabIndex = 594
        Me.rdInactive.TabStop = True
        Me.rdInactive.Text = "Inactive"
        Me.rdInactive.UseVisualStyleBackColor = True
        '
        'rdActive
        '
        Me.rdActive.AutoSize = True
        Me.rdActive.Location = New System.Drawing.Point(56, 1)
        Me.rdActive.Name = "rdActive"
        Me.rdActive.Size = New System.Drawing.Size(58, 19)
        Me.rdActive.TabIndex = 593
        Me.rdActive.TabStop = True
        Me.rdActive.Text = "Active"
        Me.rdActive.UseVisualStyleBackColor = True
        '
        'AgencyDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(387, 198)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.lblAgency)
        Me.Controls.Add(Me.cmbAgency)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblEmployeeName)
        Me.Controls.Add(Me.lblEmployeeCode)
        Me.Controls.Add(Me.lblModifiedDate)
        Me.Controls.Add(Me.lblModifiedBy)
        Me.Controls.Add(Me.txtModifiedDate)
        Me.Controls.Add(Me.txtModifiedBy)
        Me.Controls.Add(Me.txtEmployeeName)
        Me.Controls.Add(Me.txtEmployeeCode)
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
        Me.Name = "AgencyDetail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.pnlStatus.ResumeLayout(False)
        Me.pnlStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents lblModifiedBy As Label
    Friend WithEvents txtEmployeeCode As TextBox
    Friend WithEvents lblModifiedDate As Label
    Friend WithEvents txtEmployeeName As TextBox
    Friend WithEvents txtModifiedBy As Label
    Friend WithEvents txtModifiedDate As Label
    Friend WithEvents lblEmployeeName As Label
    Friend WithEvents lblEmployeeCode As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblAgency As Label
    Friend WithEvents cmbAgency As SergeUtils.EasyCompletionComboBox
    Friend WithEvents pnlStatus As Panel
    Friend WithEvents rdInactive As RadioButton
    Friend WithEvents rdActive As RadioButton
End Class
