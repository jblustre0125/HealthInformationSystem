<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmpRecordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatetimeToolStripMenuItem = New System.Windows.Forms.ToolStripLabel()
        Me.UserItemToolStripMenuItem = New System.Windows.Forms.ToolStripLabel()
        Me.UsernameToolStripMenuItem = New System.Windows.Forms.ToolStripLabel()
        Me.stsMain = New System.Windows.Forms.StatusStrip()
        Me.DepartmentToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SectionToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.VersionToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmrMain = New System.Windows.Forms.Timer(Me.components)
        Me.bgWorker = New System.ComponentModel.BackgroundWorker()
        Me.mnuMain.SuspendLayout()
        Me.stsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.BackColor = System.Drawing.Color.White
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ReportToolStripMenuItem, Me.WindowToolStripMenuItem, Me.DatetimeToolStripMenuItem, Me.UserItemToolStripMenuItem, Me.UsernameToolStripMenuItem})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.MdiWindowListItem = Me.WindowToolStripMenuItem
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(805, 24)
        Me.mnuMain.TabIndex = 1
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmpRecordToolStripMenuItem, Me.ToolStripSeparator1, Me.PasswordToolStripMenuItem, Me.FileToolStripSeparator, Me.LogOutToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EmpRecordToolStripMenuItem
        '
        Me.EmpRecordToolStripMenuItem.Name = "EmpRecordToolStripMenuItem"
        Me.EmpRecordToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.EmpRecordToolStripMenuItem.Text = "Employee Record"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(165, 6)
        '
        'PasswordToolStripMenuItem
        '
        Me.PasswordToolStripMenuItem.Name = "PasswordToolStripMenuItem"
        Me.PasswordToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.PasswordToolStripMenuItem.Text = "Change Password"
        '
        'FileToolStripSeparator
        '
        Me.FileToolStripSeparator.Name = "FileToolStripSeparator"
        Me.FileToolStripSeparator.Size = New System.Drawing.Size(165, 6)
        '
        'LogOutToolStripMenuItem
        '
        Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.LogOutToolStripMenuItem.Text = "Log Out"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.WindowToolStripMenuItem.Text = "Window"
        '
        'DatetimeToolStripMenuItem
        '
        Me.DatetimeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.DatetimeToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.DatetimeToolStripMenuItem.Name = "DatetimeToolStripMenuItem"
        Me.DatetimeToolStripMenuItem.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.DatetimeToolStripMenuItem.Size = New System.Drawing.Size(65, 17)
        Me.DatetimeToolStripMenuItem.Text = "Datetime"
        '
        'UserItemToolStripMenuItem
        '
        Me.UserItemToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.UserItemToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.UserItemToolStripMenuItem.Name = "UserItemToolStripMenuItem"
        Me.UserItemToolStripMenuItem.Size = New System.Drawing.Size(54, 17)
        Me.UserItemToolStripMenuItem.Text = "UserItem"
        '
        'UsernameToolStripMenuItem
        '
        Me.UsernameToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.UsernameToolStripMenuItem.Image = Global.HealthInformationSystem.My.Resources.Resources.user_png
        Me.UsernameToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UsernameToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 1, 10, 2)
        Me.UsernameToolStripMenuItem.Name = "UsernameToolStripMenuItem"
        Me.UsernameToolStripMenuItem.Size = New System.Drawing.Size(76, 17)
        Me.UsernameToolStripMenuItem.Text = "Username"
        '
        'stsMain
        '
        Me.stsMain.BackColor = System.Drawing.Color.White
        Me.stsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DepartmentToolStripStatusLabel, Me.SectionToolStripStatusLabel, Me.VersionToolStripStatusLabel, Me.StatusToolStripStatusLabel})
        Me.stsMain.Location = New System.Drawing.Point(0, 237)
        Me.stsMain.Name = "stsMain"
        Me.stsMain.Size = New System.Drawing.Size(805, 24)
        Me.stsMain.SizingGrip = False
        Me.stsMain.TabIndex = 2
        '
        'DepartmentToolStripStatusLabel
        '
        Me.DepartmentToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.DepartmentToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.DepartmentToolStripStatusLabel.Name = "DepartmentToolStripStatusLabel"
        Me.DepartmentToolStripStatusLabel.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.DepartmentToolStripStatusLabel.Size = New System.Drawing.Size(79, 19)
        Me.DepartmentToolStripStatusLabel.Text = "Department"
        '
        'SectionToolStripStatusLabel
        '
        Me.SectionToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.SectionToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.SectionToolStripStatusLabel.Name = "SectionToolStripStatusLabel"
        Me.SectionToolStripStatusLabel.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.SectionToolStripStatusLabel.Size = New System.Drawing.Size(55, 19)
        Me.SectionToolStripStatusLabel.Text = "Section"
        '
        'VersionToolStripStatusLabel
        '
        Me.VersionToolStripStatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.VersionToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.VersionToolStripStatusLabel.Name = "VersionToolStripStatusLabel"
        Me.VersionToolStripStatusLabel.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.VersionToolStripStatusLabel.Size = New System.Drawing.Size(54, 19)
        Me.VersionToolStripStatusLabel.Text = "Version"
        '
        'StatusToolStripStatusLabel
        '
        Me.StatusToolStripStatusLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.StatusToolStripStatusLabel.ForeColor = System.Drawing.Color.Red
        Me.StatusToolStripStatusLabel.Name = "StatusToolStripStatusLabel"
        Me.StatusToolStripStatusLabel.Size = New System.Drawing.Size(602, 19)
        Me.StatusToolStripStatusLabel.Spring = True
        Me.StatusToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tmrMain
        '
        Me.tmrMain.Interval = 1000
        '
        'bgWorker
        '
        Me.bgWorker.WorkerReportsProgress = True
        Me.bgWorker.WorkerSupportsCancellation = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(805, 261)
        Me.Controls.Add(Me.stsMain)
        Me.Controls.Add(Me.mnuMain)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnuMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Health Information System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.stsMain.ResumeLayout(False)
        Me.stsMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents stsMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tmrMain As System.Windows.Forms.Timer
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsernameToolStripMenuItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents UserItemToolStripMenuItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DatetimeToolStripMenuItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents FileToolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LogOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DepartmentToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SectionToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents StatusToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bgWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents VersionToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents EmpRecordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
