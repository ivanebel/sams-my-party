Public Class frmPreview

    Private Sub frmPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        previewBox.ImageLocation = My.Settings.ServerIP & originalImagePath
        tmrResize.Enabled = True
    End Sub

    Private Sub tmrResize_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrResize.Tick
        Me.Height = previewBox.Image.Height + 20
        Me.Width = previewBox.Image.Width + 20
    End Sub

    Private Sub previewBox_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles previewBox.MouseHover
        ToolTip1.SetToolTip(previewBox, "Press Esc to close this preview dialog")
    End Sub

End Class