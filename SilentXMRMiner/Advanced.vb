Public Class Advanced

    Public F As Form1

    Private Sub advanced_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Hide()
    End Sub

    Private Sub chkAdvanced_CheckedChanged_1(sender As Object) Handles chkAdvanced.CheckedChanged
        If chkAdvanced.Checked Then
            chkAdvanced.Text = "Enabled"
            txtAdvParam.Enabled = True
        Else
            chkAdvanced.Text = "Disabled"
            txtAdvParam.Enabled = False
        End If
    End Sub

End Class