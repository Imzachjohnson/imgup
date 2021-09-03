Public Class albuminfoform

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Main.Canceled = True
        Me.Close()


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Main.TitleText = titletextbox.Text
        Main.DescriptionText = descriptiontextbox.Text



        If blog.Checked Then
            Main.LayoutMode = "blog"
        ElseIf grid.Checked Then
            Main.LayoutMode = "grid"
        ElseIf horz.Checked Then
            Main.LayoutMode = "horizontal"
        ElseIf vert.Checked Then
            Main.LayoutMode = "vertical"
        End If
        Me.Close()

    End Sub
End Class