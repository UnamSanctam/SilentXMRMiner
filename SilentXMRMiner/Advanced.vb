Public Class Advanced

    Public F As Form1

    Private Sub advanced_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Hide()
    End Sub

    Private Sub chkAdvanced_CheckedChanged(sender As Object) Handles chkAdvanced.CheckedChanged
        If chkAdvanced.Checked Then
            chkAdvanced.Text = "Enabled"
            txtAdvParam.Enabled = True
        Else
            chkAdvanced.Text = "Disabled"
            txtAdvParam.Enabled = False
        End If
    End Sub

    Private Sub chkRemoteConfig_CheckedChanged(sender As Object) Handles chkRemoteConfig.CheckedChanged
        If chkRemoteConfig.Checked Then
            chkRemoteConfig.Text = "Enabled"
            txtRemoteConfig.Enabled = True
        Else
            chkRemoteConfig.Text = "Disabled"
            txtRemoteConfig.Enabled = False
        End If
    End Sub
End Class