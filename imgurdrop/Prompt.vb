Public Class prompt
    Public UploadBool As Boolean

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        UploadBool = True
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        UploadBool = False
        Me.Close()
    End Sub
End Class