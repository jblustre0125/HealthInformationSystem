<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RestAlarm
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
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.tmrNotification = New System.Windows.Forms.Timer(Me.components)
        Me.lsvDetail = New System.Windows.Forms.ListView()
        Me.pbClose = New System.Windows.Forms.PictureBox()
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.DodgerBlue
        Me.lblHeader.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Padding = New System.Windows.Forms.Padding(5)
        Me.lblHeader.Size = New System.Drawing.Size(334, 31)
        Me.lblHeader.TabIndex = 2
        Me.lblHeader.Text = "Notification Header"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrNotification
        '
        '
        'lsvDetail
        '
        Me.lsvDetail.BackColor = System.Drawing.Color.DodgerBlue
        Me.lsvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvDetail.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.lsvDetail.ForeColor = System.Drawing.Color.White
        Me.lsvDetail.GridLines = True
        Me.lsvDetail.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lsvDetail.HideSelection = False
        Me.lsvDetail.Location = New System.Drawing.Point(0, 31)
        Me.lsvDetail.MultiSelect = False
        Me.lsvDetail.Name = "lsvDetail"
        Me.lsvDetail.ShowGroups = False
        Me.lsvDetail.ShowItemToolTips = True
        Me.lsvDetail.Size = New System.Drawing.Size(362, 129)
        Me.lsvDetail.TabIndex = 3
        Me.lsvDetail.UseCompatibleStateImageBehavior = False
        '
        'pbClose
        '
        Me.pbClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbClose.Image = Global.HealthInformationSystem.My.Resources.Resources.Delete
        Me.pbClose.Location = New System.Drawing.Point(336, 8)
        Me.pbClose.Name = "pbClose"
        Me.pbClose.Size = New System.Drawing.Size(16, 16)
        Me.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbClose.TabIndex = 4
        Me.pbClose.TabStop = False
        '
        'RestAlarm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DodgerBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(362, 160)
        Me.ControlBox = False
        Me.Controls.Add(Me.pbClose)
        Me.Controls.Add(Me.lsvDetail)
        Me.Controls.Add(Me.lblHeader)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RestAlarm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Notification"
        Me.TopMost = True
        CType(Me.pbClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents lblHeader As Label
    Private WithEvents tmrNotification As Timer
    Friend WithEvents lsvDetail As ListView
    Friend WithEvents pbClose As PictureBox
End Class
