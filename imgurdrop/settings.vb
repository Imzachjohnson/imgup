Imports System.IO

Public Class settings
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Settings.Reload()
        Me.Close()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles settingssave.Click
        If Not Directory.Exists(TextBox1.Text) And Not TextBox1.Text = "" Then
            MessageBox.Show("You have not entered a valid path for screenshots. Please enter a valid path then save.")
            Return
        End If
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FolderBrowserDialog1.ShowDialog()
        My.Settings.screenpath = FolderBrowserDialog1.SelectedPath
        TextBox1.Text = My.Settings.screenpath
    End Sub
End Class