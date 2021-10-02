Public Class Advanced

    Public F As Form1

    Private Sub advanced_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Hide()
    End Sub

    Private Sub chkAdvanced_CheckedChanged(sender As Object) Handles chkAdvanced.CheckedChanged
        chkAdvanced.Text = If(chkAdvanced.Checked, "Enabled", "Disabled")
        txtAdvParam.Enabled = chkAdvanced.Checked
    End Sub

    Private Sub chkRemoteConfig_CheckedChanged(sender As Object) Handles chkRemoteConfig.CheckedChanged
        chkRemoteConfig.Text = If(chkRemoteConfig.Checked, "Enabled", "Disabled")
        txtRemoteConfig.Enabled = chkRemoteConfig.Checked
    End Sub
End Class