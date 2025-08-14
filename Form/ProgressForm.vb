Public Class ProgressForm

    Private Sub ProgressForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblProgress.Text = "Exporting, please wait..."
        Me.ControlBox = False
        Me.StartPosition = FormStartPosition.CenterParent
    End Sub

End Class