Imports System.ComponentModel
Imports System.Deployment.Application

Public Class results

    Dim IsDraggingForm As Boolean = False
    Private MousePos As New System.Drawing.Point(0, 0)

    Private Sub results_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            IsDraggingForm = True
            MousePos = e.Location
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseUp
        If e.Button = MouseButtons.Left Then IsDraggingForm = False
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove
        If IsDraggingForm Then
            Dim temp As Point = New Point(Me.Location + (e.Location - MousePos))
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub results_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        versionlabel.Text = Main.versionnum

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DataGridView1.Rows.Add("cheese assssss", "http://www.skematix.net")
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        For Each bgw As BackgroundWorker In Main.bgws
            bgw.CancelAsync()
        Next
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Try
            If DataGridView1.CurrentCell.ColumnIndex.Equals(1) Then
                Dim value As String = DataGridView1.Rows(e.RowIndex).Cells(1).Value
                Process.Start(value)
            End If

        Catch
        End Try
    End Sub

    Private Sub DataGridView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDown
        If e.Button = MouseButtons.Right Then
            ContextMenuStrip2.Show(MousePosition)
        End If
    End Sub


    Private Sub GoToURLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoToURLToolStripMenuItem.Click
        Try
            Dim i = DataGridView1.CurrentRow.Index
            Process.Start(DataGridView1.Item(1, i).Value)
        Catch
        End Try
    End Sub

    Private Sub FacebookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacebookToolStripMenuItem.Click
        Try
            Dim i = DataGridView1.CurrentRow.Index

            Process.Start("https://www.facebook.com/sharer/sharer.php?u=" & DataGridView1.Item(1, i).Value)
        Catch
        End Try
    End Sub

    Private Sub TwitterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TwitterToolStripMenuItem.Click
        Try
            Dim i = DataGridView1.CurrentRow.Index
            Process.Start("https://twitter.com/intent/tweet?original_referer" & DataGridView1.Item(1, i).Value & "&text=" & "Check this out: " & DataGridView1.Item(1, i).Value & "&via=imgupwidget")
        Catch
        End Try
    End Sub

    Private Sub RedditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedditToolStripMenuItem.Click




        Try
            Dim i = DataGridView1.CurrentRow.Index
            Process.Start("http://www.reddit.com/submit?url=" & DataGridView1.Item(1, i).Value)
        Catch
        End Try
    End Sub

    Private Sub StumbleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StumbleToolStripMenuItem.Click
        Try

            Dim i = DataGridView1.CurrentRow.Index
            Process.Start("http://www.stumbleupon.com/submit?url=" & DataGridView1.Item(1, i).Value)
        Catch
        End Try
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
        Catch
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        SaveFileDialog1.ShowDialog()

    End Sub

    Private Sub SaveGridData(ByRef ThisGrid As DataGridView, ByVal Filename As String)
        ThisGrid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        ThisGrid.SelectAll()
        IO.File.WriteAllText(Filename, ThisGrid.GetClipboardContent().GetText.TrimEnd)
        ThisGrid.ClearSelection()
    End Sub

    Private Sub SaveFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        SaveGridData(DataGridView1, SaveFileDialog1.FileName)
    End Sub

    Private Sub ContextMenuStrip2_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Process.Start("https://www.facebook.com/pages/Imgup/383655798446813")
    End Sub

    Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        Cursor = Cursors.Arrow
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show(My.Settings.screenpath.ToString)
    End Sub
End Class