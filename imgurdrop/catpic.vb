Imports System.Net

Public Class catpic

    Private Sub catpic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim s As New WebClient
            Dim response As String = s.DownloadString("http://thecatapi.com/api/images/get?format=xml&results_per_page=1")

            Dim r As New System.Text.RegularExpressions.Regex("<url>(.*?)</url>")

            Dim match As System.Text.RegularExpressions.Match = r.Match(response)

            Dim CatPic As String = match.ToString.Replace("<url>", "").Replace("</url>", "")


            PictureBox1.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(CatPic)))
        Catch
            MessageBox.Show("OH NOES! Error getting the cat pic. Sorry!")
        End Try



        Me.Size = PictureBox1.Size
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2

        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2

    End Sub

    Private Sub catpic_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.Close()
    End Sub
End Class