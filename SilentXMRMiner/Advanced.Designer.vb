<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Advanced
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Advanced))
        Me.TooltipHelper = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.MephTheme1 = New SilentXMRMiner.MephTheme()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.toggleCustomWatchdog = New SilentXMRMiner.MephToggleSwitch()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.chkAdvanced = New SilentXMRMiner.MephCheckBox()
        Me.txtAdvParam = New SilentXMRMiner.MephTextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.toggleEnableDebug = New SilentXMRMiner.MephToggleSwitch()
        Me.MephTheme1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TooltipHelper
        '
        Me.TooltipHelper.AutoPopDelay = 32000
        Me.TooltipHelper.BackColor = System.Drawing.Color.White
        Me.TooltipHelper.ForeColor = System.Drawing.Color.Black
        Me.TooltipHelper.InitialDelay = 100
        Me.TooltipHelper.IsBalloon = True
        Me.TooltipHelper.ReshowDelay = 100
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Help
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.Label1.ForeColor = System.Drawing.Color.Teal
        Me.Label1.Location = New System.Drawing.Point(191, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 20)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.Label1, "Pauses the miner compilation when Watchdog is compiled to allow obfuscation of th" &
        "e watchdog until resumed manually.You can find the Watchdog in the same folder a" &
        "s the miner.")
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Help
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.Label19.ForeColor = System.Drawing.Color.Teal
        Me.Label19.Location = New System.Drawing.Point(336, 73)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(18, 20)
        Me.Label19.TabIndex = 66
        Me.Label19.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.Label19, "The parameters to mine with. ONLY CHANGE THESE IF YOU KNOW WHAT YOU ARE DOING.")
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Help
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.Label26.ForeColor = System.Drawing.Color.Teal
        Me.Label26.Location = New System.Drawing.Point(120, 120)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(18, 20)
        Me.Label26.TabIndex = 60
        Me.Label26.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.Label26, "Will enable DEBUG mode which will display errors when they occur in the miner. !W" &
        "ARNING! Should only be used when testing!")
        '
        'MephTheme1
        '
        Me.MephTheme1.AccentColor = System.Drawing.Color.DarkRed
        Me.MephTheme1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.MephTheme1.Controls.Add(Me.Label1)
        Me.MephTheme1.Controls.Add(Me.Label2)
        Me.MephTheme1.Controls.Add(Me.toggleCustomWatchdog)
        Me.MephTheme1.Controls.Add(Me.Label20)
        Me.MephTheme1.Controls.Add(Me.Label19)
        Me.MephTheme1.Controls.Add(Me.chkAdvanced)
        Me.MephTheme1.Controls.Add(Me.txtAdvParam)
        Me.MephTheme1.Controls.Add(Me.Label26)
        Me.MephTheme1.Controls.Add(Me.Label27)
        Me.MephTheme1.Controls.Add(Me.toggleEnableDebug)
        Me.MephTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MephTheme1.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.729167!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MephTheme1.Location = New System.Drawing.Point(0, 0)
        Me.MephTheme1.Name = "MephTheme1"
        Me.MephTheme1.Size = New System.Drawing.Size(396, 151)
        Me.MephTheme1.SubHeader = "Advanced Options"
        Me.MephTheme1.TabIndex = 0
        Me.MephTheme1.Text = "Silent XMR Miner Builder"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(14, 75)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(171, 25)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Custom Watchdog:"
        '
        'toggleCustomWatchdog
        '
        Me.toggleCustomWatchdog.BackColor = System.Drawing.Color.Transparent
        Me.toggleCustomWatchdog.Checked = False
        Me.toggleCustomWatchdog.ForeColor = System.Drawing.Color.Black
        Me.toggleCustomWatchdog.Location = New System.Drawing.Point(136, 73)
        Me.toggleCustomWatchdog.Margin = New System.Windows.Forms.Padding(2)
        Me.toggleCustomWatchdog.Name = "toggleCustomWatchdog"
        Me.toggleCustomWatchdog.Size = New System.Drawing.Size(50, 24)
        Me.toggleCustomWatchdog.TabIndex = 68
        Me.toggleCustomWatchdog.Text = "Enable Nicehash Mining"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.Gray
        Me.Label20.Location = New System.Drawing.Point(250, 99)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(130, 15)
        Me.Label20.TabIndex = 67
        Me.Label20.Text = "Advanced Parameters:"
        '
        'chkAdvanced
        '
        Me.chkAdvanced.AccentColor = System.Drawing.Color.ForestGreen
        Me.chkAdvanced.BackColor = System.Drawing.Color.Transparent
        Me.chkAdvanced.Checked = False
        Me.chkAdvanced.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkAdvanced.ForeColor = System.Drawing.Color.Black
        Me.chkAdvanced.Location = New System.Drawing.Point(252, 68)
        Me.chkAdvanced.Margin = New System.Windows.Forms.Padding(2)
        Me.chkAdvanced.Name = "chkAdvanced"
        Me.chkAdvanced.Size = New System.Drawing.Size(111, 24)
        Me.chkAdvanced.TabIndex = 65
        Me.chkAdvanced.Text = "Disabled"
        '
        'txtAdvParam
        '
        Me.txtAdvParam.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtAdvParam.Enabled = False
        Me.txtAdvParam.ForeColor = System.Drawing.Color.Silver
        Me.txtAdvParam.Location = New System.Drawing.Point(251, 116)
        Me.txtAdvParam.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAdvParam.MaxLength = 32767
        Me.txtAdvParam.MultiLine = False
        Me.txtAdvParam.Name = "txtAdvParam"
        Me.txtAdvParam.Size = New System.Drawing.Size(136, 24)
        Me.txtAdvParam.TabIndex = 64
        Me.txtAdvParam.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtAdvParam.UseSystemPasswordChar = False
        Me.txtAdvParam.WordWrap = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(14, 117)
        Me.Label27.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(76, 25)
        Me.Label27.TabIndex = 59
        Me.Label27.Text = "DEBUG:"
        '
        'toggleEnableDebug
        '
        Me.toggleEnableDebug.BackColor = System.Drawing.Color.Transparent
        Me.toggleEnableDebug.Checked = False
        Me.toggleEnableDebug.ForeColor = System.Drawing.Color.Black
        Me.toggleEnableDebug.Location = New System.Drawing.Point(68, 114)
        Me.toggleEnableDebug.Margin = New System.Windows.Forms.Padding(2)
        Me.toggleEnableDebug.Name = "toggleEnableDebug"
        Me.toggleEnableDebug.Size = New System.Drawing.Size(50, 24)
        Me.toggleEnableDebug.TabIndex = 58
        Me.toggleEnableDebug.Text = "Enable Nicehash Mining"
        '
        'Advanced
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 151)
        Me.Controls.Add(Me.MephTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(396, 151)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(396, 151)
        Me.Name = "Advanced"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Advanced"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.MephTheme1.ResumeLayout(False)
        Me.MephTheme1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MephTheme1 As MephTheme
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents toggleEnableDebug As MephToggleSwitch
    Friend WithEvents TooltipHelper As ToolTip
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents chkAdvanced As MephCheckBox
    Friend WithEvents txtAdvParam As MephTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents toggleCustomWatchdog As MephToggleSwitch
End Class
