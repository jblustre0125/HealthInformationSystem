<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpApeDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmpApeDetail))
        Me.lblCreatedDate = New System.Windows.Forms.Label()
        Me.txtCreatedDate = New System.Windows.Forms.Label()
        Me.lblYearId = New System.Windows.Forms.Label()
        Me.txtCreatedBy = New System.Windows.Forms.Label()
        Me.lblCreatedBy = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.pnlImage = New System.Windows.Forms.Panel()
        Me.lblFilename = New System.Windows.Forms.Label()
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.btnNext = New PinkieControls.ButtonXP()
        Me.btnPrevious = New PinkieControls.ButtonXP()
        Me.btnRemove = New PinkieControls.ButtonXP()
        Me.btnAttach = New PinkieControls.ButtonXP()
        Me.btnCancel = New PinkieControls.ButtonXP()
        Me.btnClose = New PinkieControls.ButtonXP()
        Me.btnDelete = New PinkieControls.ButtonXP()
        Me.btnSave = New PinkieControls.ButtonXP()
        Me.txtYearId = New System.Windows.Forms.TextBox()
        Me.lblFileCount = New System.Windows.Forms.Label()
        Me.ofdApeDetail = New System.Windows.Forms.OpenFileDialog()
        Me.pnlImage.SuspendLayout()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCreatedDate
        '
        Me.lblCreatedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCreatedDate.BackColor = System.Drawing.SystemColors.Control
        Me.lblCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreatedDate.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblCreatedDate.ForeColor = System.Drawing.Color.Black
        Me.lblCreatedDate.Location = New System.Drawing.Point(288, 4)
        Me.lblCreatedDate.Name = "lblCreatedDate"
        Me.lblCreatedDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblCreatedDate.Size = New System.Drawing.Size(120, 24)
        Me.lblCreatedDate.TabIndex = 540
        Me.lblCreatedDate.Text = "Date Created"
        Me.lblCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCreatedDate
        '
        Me.txtCreatedDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCreatedDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreatedDate.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtCreatedDate.ForeColor = System.Drawing.Color.Black
        Me.txtCreatedDate.Location = New System.Drawing.Point(407, 4)
        Me.txtCreatedDate.Name = "txtCreatedDate"
        Me.txtCreatedDate.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtCreatedDate.Size = New System.Drawing.Size(259, 24)
        Me.txtCreatedDate.TabIndex = 541
        Me.txtCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblYearId
        '
        Me.lblYearId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblYearId.BackColor = System.Drawing.SystemColors.Control
        Me.lblYearId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblYearId.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblYearId.ForeColor = System.Drawing.Color.Black
        Me.lblYearId.Location = New System.Drawing.Point(288, 56)
        Me.lblYearId.Name = "lblYearId"
        Me.lblYearId.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblYearId.Size = New System.Drawing.Size(120, 24)
        Me.lblYearId.TabIndex = 542
        Me.lblYearId.Text = "Year"
        Me.lblYearId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCreatedBy.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCreatedBy.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.txtCreatedBy.ForeColor = System.Drawing.Color.Black
        Me.txtCreatedBy.Location = New System.Drawing.Point(407, 30)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.txtCreatedBy.Size = New System.Drawing.Size(259, 24)
        Me.txtCreatedBy.TabIndex = 545
        Me.txtCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCreatedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreatedBy.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblCreatedBy.ForeColor = System.Drawing.Color.Black
        Me.lblCreatedBy.Location = New System.Drawing.Point(288, 30)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblCreatedBy.Size = New System.Drawing.Size(120, 24)
        Me.lblCreatedBy.TabIndex = 544
        Me.lblCreatedBy.Text = "Created By"
        Me.lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRemarks
        '
        Me.txtRemarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRemarks.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtRemarks.Location = New System.Drawing.Point(288, 105)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(378, 208)
        Me.txtRemarks.TabIndex = 558
        '
        'lblRemarks
        '
        Me.lblRemarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRemarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemarks.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(288, 82)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblRemarks.Size = New System.Drawing.Size(378, 24)
        Me.lblRemarks.TabIndex = 559
        Me.lblRemarks.Text = "Remarks"
        Me.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.pnlImage.Location = New System.Drawing.Point(5, 4)
        Me.pnlImage.Name = "pnlImage"
        Me.pnlImage.Size = New System.Drawing.Size(280, 309)
        Me.pnlImage.TabIndex = 569
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
        Me.btnNext.Hint = ""
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
        Me.btnPrevious.Hint = ""
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
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancel.DefaultScheme = True
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Hint = "Cancel changes"
        Me.btnCancel.Image = Global.HealthInformationSystem.My.Resources.Resources.Undo
        Me.btnCancel.Location = New System.Drawing.Point(384, 324)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnCancel.Size = New System.Drawing.Size(90, 32)
        Me.btnCancel.TabIndex = 578
        Me.btnCancel.Text = "Cancel"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.DefaultScheme = True
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Hint = "Close"
        Me.btnClose.Location = New System.Drawing.Point(576, 324)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnClose.Size = New System.Drawing.Size(90, 32)
        Me.btnClose.TabIndex = 577
        Me.btnClose.Text = "Close"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDelete.DefaultScheme = True
        Me.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None
        Me.btnDelete.Hint = "Delete"
        Me.btnDelete.Image = Global.HealthInformationSystem.My.Resources.Resources._Erase
        Me.btnDelete.Location = New System.Drawing.Point(480, 324)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnDelete.Size = New System.Drawing.Size(90, 32)
        Me.btnDelete.TabIndex = 576
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
        Me.btnSave.Location = New System.Drawing.Point(288, 324)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue
        Me.btnSave.Size = New System.Drawing.Size(90, 32)
        Me.btnSave.TabIndex = 575
        Me.btnSave.Text = " Save"
        '
        'txtYearId
        '
        Me.txtYearId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtYearId.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.txtYearId.Location = New System.Drawing.Point(407, 56)
        Me.txtYearId.MaxLength = 4
        Me.txtYearId.Name = "txtYearId"
        Me.txtYearId.Size = New System.Drawing.Size(259, 24)
        Me.txtYearId.TabIndex = 579
        '
        'lblFileCount
        '
        Me.lblFileCount.AutoSize = True
        Me.lblFileCount.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.lblFileCount.Location = New System.Drawing.Point(2, 339)
        Me.lblFileCount.Name = "lblFileCount"
        Me.lblFileCount.Size = New System.Drawing.Size(64, 13)
        Me.lblFileCount.TabIndex = 580
        Me.lblFileCount.Text = "File Count"
        '
        'ofdApeDetail
        '
        Me.ofdApeDetail.Filter = "JPEGs (*.jpg, *.jpeg) | *.jpg; *.jpeg |GIFs (*.gif) | *.gif |Bitmaps (*.bmp) | *." & _
    "bmp |All Images (*.*) | *.jpg; *.jpeg; *.gif; *.bmp; *.png"
        Me.ofdApeDetail.FilterIndex = 4
        Me.ofdApeDetail.Multiselect = True
        Me.ofdApeDetail.Title = "Select image attachments"
        '
        'frmEmpApeDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(672, 361)
        Me.Controls.Add(Me.lblFileCount)
        Me.Controls.Add(Me.txtYearId)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.pnlImage)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.txtCreatedBy)
        Me.Controls.Add(Me.lblCreatedBy)
        Me.Controls.Add(Me.lblYearId)
        Me.Controls.Add(Me.txtCreatedDate)
        Me.Controls.Add(Me.lblCreatedDate)
        Me.Font = New System.Drawing.Font("Verdana", 8.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEmpApeDetail"
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
    Friend WithEvents lblCreatedDate As System.Windows.Forms.Label
    Friend WithEvents txtCreatedDate As System.Windows.Forms.Label
    Friend WithEvents lblYearId As System.Windows.Forms.Label
    Friend WithEvents txtCreatedBy As System.Windows.Forms.Label
    Friend WithEvents lblCreatedBy As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents pnlImage As System.Windows.Forms.Panel
    Friend WithEvents lblFilename As System.Windows.Forms.Label
    Friend WithEvents picImage As System.Windows.Forms.PictureBox
    Friend WithEvents btnNext As PinkieControls.ButtonXP
    Friend WithEvents btnPrevious As PinkieControls.ButtonXP
    Friend WithEvents btnRemove As PinkieControls.ButtonXP
    Friend WithEvents btnAttach As PinkieControls.ButtonXP
    Friend WithEvents btnCancel As PinkieControls.ButtonXP
    Friend WithEvents btnClose As PinkieControls.ButtonXP
    Friend WithEvents btnDelete As PinkieControls.ButtonXP
    Friend WithEvents btnSave As PinkieControls.ButtonXP
    Friend WithEvents txtYearId As System.Windows.Forms.TextBox
    Friend WithEvents lblFileCount As System.Windows.Forms.Label
    Friend WithEvents ofdApeDetail As System.Windows.Forms.OpenFileDialog
End Class
