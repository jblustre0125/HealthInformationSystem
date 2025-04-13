<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NurseDetail
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
        Me.lblIsAdmin = New System.Windows.Forms.Label()
        Me.lblEmployeeCode = New System.Windows.Forms.Label()
        Me.txtCreatedDate = New System.Windows.Forms.Label()
        Me.lblCreatedDate = New System.Windows.Forms.Label()
        Me.txtCreatedBy = New System.Windows.Forms.Label()
        Me.lblCreatedBy = New System.Windows.Forms.Label()
        Me.txtModifiedDate = New System.Windows.Forms.Label()
        Me.lblModifiedDate = New System.Windows.Forms.Label()
        Me.txtModifiedBy = New System.Windows.Forms.Label()
        Me.lblModifiedBy = New System.Windows.Forms.Label()
        Me.lblEmployeeName = New System.Windows.Forms.Label()
        Me.lblPositionName = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmbEmployeeName = New SergeUtils.EasyCompletionComboBox()
        Me.txtEmployeeCode = New System.Windows.Forms.Label()
        Me.txtPosition = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.Label()
        Me.txtIsAdmin = New System.Windows.Forms.Label()
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
        Me.btnClose.Location = New System.Drawing.Point(308, 229)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 8
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
        Me.btnDelete.Location = New System.Drawing.Point(214, 229)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 7
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
        Me.btnSave.Location = New System.Drawing.Point(120, 229)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 6
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "Save"
        '
        'lblIsAdmin
        '
        Me.lblIsAdmin.BackColor = System.Drawing.SystemColors.Control
        Me.lblIsAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIsAdmin.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIsAdmin.ForeColor = System.Drawing.Color.Black
        Me.lblIsAdmin.Location = New System.Drawing.Point(4, 202)
        Me.lblIsAdmin.Name = "lblIsAdmin"
        Me.lblIsAdmin.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblIsAdmin.Size = New System.Drawing.Size(100, 23)
        Me.lblIsAdmin.TabIndex = 568
        Me.lblIsAdmin.Text = "Is Admin?"
        Me.lblIsAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmployeeCode
        '
        Me.lblEmployeeCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmployeeCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEmployeeCode.ForeColor = System.Drawing.Color.Black
        Me.lblEmployeeCode.Location = New System.Drawing.Point(4, 102)
        Me.lblEmployeeCode.Name = "lblEmployeeCode"
        Me.lblEmployeeCode.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblEmployeeCode.Size = New System.Drawing.Size(100, 23)
        Me.lblEmployeeCode.TabIndex = 555
        Me.lblEmployeeCode.Text = "Employee Code"
        Me.lblEmployeeCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'lblEmployeeName
        '
        Me.lblEmployeeName.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmployeeName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEmployeeName.ForeColor = System.Drawing.Color.Black
        Me.lblEmployeeName.Location = New System.Drawing.Point(4, 127)
        Me.lblEmployeeName.Name = "lblEmployeeName"
        Me.lblEmployeeName.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblEmployeeName.Size = New System.Drawing.Size(100, 23)
        Me.lblEmployeeName.TabIndex = 628
        Me.lblEmployeeName.Text = "Name"
        Me.lblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPositionName
        '
        Me.lblPositionName.BackColor = System.Drawing.SystemColors.Control
        Me.lblPositionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPositionName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPositionName.ForeColor = System.Drawing.Color.Black
        Me.lblPositionName.Location = New System.Drawing.Point(4, 152)
        Me.lblPositionName.Name = "lblPositionName"
        Me.lblPositionName.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblPositionName.Size = New System.Drawing.Size(100, 23)
        Me.lblPositionName.TabIndex = 630
        Me.lblPositionName.Text = "Position"
        Me.lblPositionName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(4, 177)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblStatus.Size = New System.Drawing.Size(100, 23)
        Me.lblStatus.TabIndex = 632
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbEmployeeName
        '
        Me.cmbEmployeeName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbEmployeeName.FormattingEnabled = True
        Me.cmbEmployeeName.Location = New System.Drawing.Point(103, 127)
        Me.cmbEmployeeName.Name = "cmbEmployeeName"
        Me.cmbEmployeeName.Size = New System.Drawing.Size(295, 23)
        Me.cmbEmployeeName.TabIndex = 3
        '
        'txtEmployeeCode
        '
        Me.txtEmployeeCode.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtEmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmployeeCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmployeeCode.ForeColor = System.Drawing.Color.Black
        Me.txtEmployeeCode.Location = New System.Drawing.Point(103, 102)
        Me.txtEmployeeCode.Name = "txtEmployeeCode"
        Me.txtEmployeeCode.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtEmployeeCode.Size = New System.Drawing.Size(295, 23)
        Me.txtEmployeeCode.TabIndex = 633
        Me.txtEmployeeCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtEmployeeCode.UseCompatibleTextRendering = True
        '
        'txtPosition
        '
        Me.txtPosition.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPosition.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPosition.ForeColor = System.Drawing.Color.Black
        Me.txtPosition.Location = New System.Drawing.Point(103, 152)
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtPosition.Size = New System.Drawing.Size(295, 23)
        Me.txtPosition.TabIndex = 634
        Me.txtPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtPosition.UseCompatibleTextRendering = True
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtStatus.ForeColor = System.Drawing.Color.Black
        Me.txtStatus.Location = New System.Drawing.Point(103, 177)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtStatus.Size = New System.Drawing.Size(295, 23)
        Me.txtStatus.TabIndex = 635
        Me.txtStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtStatus.UseCompatibleTextRendering = True
        '
        'txtIsAdmin
        '
        Me.txtIsAdmin.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtIsAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIsAdmin.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtIsAdmin.ForeColor = System.Drawing.Color.Black
        Me.txtIsAdmin.Location = New System.Drawing.Point(103, 202)
        Me.txtIsAdmin.Name = "txtIsAdmin"
        Me.txtIsAdmin.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.txtIsAdmin.Size = New System.Drawing.Size(295, 23)
        Me.txtIsAdmin.TabIndex = 636
        Me.txtIsAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.txtIsAdmin.UseCompatibleTextRendering = True
        '
        'NurseDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(402, 265)
        Me.Controls.Add(Me.txtIsAdmin)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.txtPosition)
        Me.Controls.Add(Me.txtEmployeeCode)
        Me.Controls.Add(Me.cmbEmployeeName)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblPositionName)
        Me.Controls.Add(Me.lblEmployeeName)
        Me.Controls.Add(Me.txtModifiedDate)
        Me.Controls.Add(Me.lblModifiedDate)
        Me.Controls.Add(Me.txtModifiedBy)
        Me.Controls.Add(Me.lblModifiedBy)
        Me.Controls.Add(Me.txtCreatedDate)
        Me.Controls.Add(Me.lblCreatedDate)
        Me.Controls.Add(Me.txtCreatedBy)
        Me.Controls.Add(Me.lblCreatedBy)
        Me.Controls.Add(Me.lblEmployeeCode)
        Me.Controls.Add(Me.lblIsAdmin)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NurseDetail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Nurse Detail"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents lblEmployeeCode As Label
    Friend WithEvents lblIsAdmin As Label
    Friend WithEvents txtCreatedDate As Label
    Friend WithEvents lblCreatedDate As Label
    Friend WithEvents txtCreatedBy As Label
    Friend WithEvents lblCreatedBy As Label
    Friend WithEvents txtModifiedDate As Label
    Friend WithEvents lblModifiedDate As Label
    Friend WithEvents txtModifiedBy As Label
    Friend WithEvents lblModifiedBy As Label
    Friend WithEvents lblEmployeeName As Label
    Friend WithEvents lblPositionName As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents cmbEmployeeName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents txtEmployeeCode As Label
    Friend WithEvents txtPosition As Label
    Friend WithEvents txtStatus As Label
    Friend WithEvents txtIsAdmin As Label
End Class
