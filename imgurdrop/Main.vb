Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Text
Imports System.ComponentModel
Imports System.Collections.Specialized
Imports System.Text.RegularExpressions
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class Main

    Public workerURLs As New Queue(Of String)()
    Public workerURLsLock As Object = "LOCK"
    Public bgws As New List(Of BackgroundWorker)
    Public Structure AlbumInfo
        Public URL As String
        Public Hash As String
    End Structure

    Public AlbumState As Boolean
    Public Canceled As Boolean

    Public NumImages As Integer = 0

    Public publicalbum As AlbumInfo

    'Album declares
    Public TitleText As String
    Public DescriptionText As String
    Public PrivacyMode As String
    Public LayoutMode As String
    'end album declares
    Public versionnum As String = " v1.1"

    Public BWhash As String

    'functions

    'end functions

    'hotkeys
    Public Const MOD_ALT As Integer = &H1 'Alt key
    Public Const WM_HOTKEY As Integer = &H312



    <DllImport("User32.dll")> _
    Public Shared Function RegisterHotKey(ByVal hwnd As IntPtr, _
                        ByVal id As Integer, ByVal fsModifiers As Integer, _
                        ByVal vk As Integer) As Integer
    End Function



    <DllImport("User32.dll")> _
    Public Shared Function UnregisterHotKey(ByVal hwnd As IntPtr, _
                        ByVal id As Integer) As Integer
    End Function



    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_HOTKEY Then
            Dim id As IntPtr = m.WParam
            Select Case (id.ToString)
                Case "100"
                    Dim path As String = FullscreenShot()
                    If path = "canceled" Then
                        Exit Sub
                    End If

                    If My.Settings.autoup = False Then
                        prompt.ShowDialog()
                        If prompt.UploadBool = True Then
                            singleresult.TextBox1.Text = UploadImage(path)
                            singleresult.Show()
                        ElseIf prompt.UploadBool = False Then

                            Return
                        End If
                    ElseIf My.Settings.autoup Then
                        singleresult.TextBox1.Text = UploadImage(path)
                        singleresult.Show()
                    End If
                Case "200"

                    Region_Drag.Show()
                    Region_Drag.Focus()
            End Select
        End If
        MyBase.WndProc(m)
    End Sub
    'endhotkeys


    Public Function FullscreenShot()
        Me.Hide()
        Dim bmpSS As Bitmap
        Dim gfxSS As Graphics
        bmpSS = New Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb)
        gfxSS = Graphics.FromImage(bmpSS)
        gfxSS.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy)
        My.Computer.Audio.Play(My.Resources.camera, AudioPlayMode.Background)
        Dim saveDialog As New SaveFileDialog
        saveDialog.Filter = "Jpeg Image|*.jpg"
        saveDialog.Title = "Save Image as"
        saveDialog.FileName = "ScreenCap_" & My.Settings.shotcount
        Me.Show()

        If Not My.Settings.screenpath = "" Then
            Dim defalpath = My.Settings.screenpath & "\" & "ScreenCap_" & My.Settings.shotcount & ".jpg"
            bmpSS.Save(defalpath, ImageFormat.Jpeg)
            My.Settings.shotcount += 1
            My.Settings.Save()
            If My.Settings.openfolder Then
                Try
                    Process.Start(My.Settings.screenpath)
                Catch ex As Exception
                End Try
            End If
            Return defalpath
        Else
            Dim reesult = saveDialog.ShowDialog()
            If reesult = Windows.Forms.DialogResult.OK AndAlso saveDialog.FileName <> "" Then
                bmpSS.Save(saveDialog.FileName, ImageFormat.Jpeg)
                My.Settings.shotcount += 1
                My.Settings.Save()

                If My.Settings.openfolder Then
                    Try
                        Process.Start(System.IO.Path.GetDirectoryName(saveDialog.FileName))
                    Catch ex As Exception
                    End Try
                End If
            ElseIf reesult = Windows.Forms.DialogResult.Cancel Then
                Return ("canceled")
            End If

            bmpSS.Dispose()
            Return saveDialog.FileName
            End If
    End Function

    Public Function UploadImage(ByVal image As String)
        NotifyIcon1.ShowBalloonTip(3000, "Uploading...", "Uploading to Imgur", ToolTipIcon.Info)
        Dim w As New WebClient()
        w.Headers.Add("Authorization", "Client-ID " & ClientId)

        Dim Keys As New System.Collections.Specialized.NameValueCollection
        Try
            Keys.Add("image", Convert.ToBase64String(File.ReadAllBytes(image)))


            Dim responseArray As Byte() = w.UploadValues("https://api.imgur.com/3/image", Keys)

            Dim result = Encoding.ASCII.GetString(responseArray)
            Dim reg As New System.Text.RegularExpressions.Regex("link"":""(.*?)""")

            Dim match As Match = reg.Match(result)

            Dim url As String = match.ToString.Replace("link"":""", "").Replace("""", "").Replace("\/", "/")
            'link":"http:\/\/i.imgur.com\/pX8aHU3.jpg"

            Return url
        Catch s As Exception
            MessageBox.Show("Uh-oh, something went wrong. " & s.Message)
            Return "Failed!"
        End Try
    End Function

    Private Function UploadImageUrl(ByVal url1 As String)
        NotifyIcon1.ShowBalloonTip(3000, "Uploading...", "Uploading to Imgur", ToolTipIcon.Info)
        Dim w As New WebClient()
        w.Headers.Add("Authorization", "Client-ID " & ClientId)

        Dim Keys As New System.Collections.Specialized.NameValueCollection

        Keys.Add("image", url1)

        Try
            Dim responseArray As Byte() = w.UploadValues("https://api.imgur.com/3/image", Keys)

            Dim result = Encoding.ASCII.GetString(responseArray)
            Dim reg As New System.Text.RegularExpressions.Regex("link"":""(.*?)""")

            Dim match As Match = reg.Match(result)

            Dim url As String = match.ToString.Replace("link"":""", "").Replace("""", "").Replace("\/", "/").Replace("http://", "")
            'link":"http:\/\/i.imgur.com\/pX8aHU3.jpg"

            Return url
        Catch s As Exception
            MessageBox.Show("Uh-oh, something went wrong. " & s.Message)
            Return "Failed!"
        End Try
    End Function

    Private Function CreateAlbum(ByVal title As String, ByVal description As String, ByVal privacy As String, ByVal layout As String)
        Dim album As New AlbumInfo
        Dim w As New WebClient()
        w.Headers.Add("Authorization", "Client-ID " & ClientId)

        Dim Keys As New System.Collections.Specialized.NameValueCollection
        Keys.Add("title", title)
        Keys.Add("description", description)
        Keys.Add("privacy", privacy)
        Keys.Add("layout", layout)

        Dim responseArray As Byte() = w.UploadValues("https://api.imgur.com/3/album", Keys)

        Dim result = Encoding.ASCII.GetString(responseArray)

        'id parse
        Dim r As New System.Text.RegularExpressions.Regex("""id"":""(.*?)"",")


        Dim idmatch As Match = r.Match(result)


        Dim url As String = idmatch.ToString.Replace("""id"":""", "").Replace(""",", "")

        album.URL = "http://imgur.com/a/" & url
        'end id parse




        Dim r2 As New System.Text.RegularExpressions.Regex("""deletehash"":(.*?)""}")


        Dim hashmatch As Match = r2.Match(result)

        Dim hash As String = hashmatch.ToString.Replace("""deletehash"":", "").Replace("""}", "").Replace("""", "")
        album.Hash = hash


        Return album
    End Function


    Private Function AddImageToAlbum(ByVal image As String, ByVal album As String)
        Dim w As New WebClient()
        w.Headers.Add("Authorization", "Client-ID " & ClientId)

        Dim Keys As New System.Collections.Specialized.NameValueCollection

        Keys.Add("image", Convert.ToBase64String(File.ReadAllBytes(image)))
        Keys.Add("album", album)

        Dim responseArray As Byte() = w.UploadValues("https://api.imgur.com/3/image", Keys)

        Dim result = Encoding.ASCII.GetString(responseArray)

        Return result
    End Function

    'end functions

    Dim uploaded As Boolean
    Dim imgLink As String


    Dim ClientId As String = "e45f1bcd710f72b"
    Private Sub Form1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        Process.Start("http://www.imgur.com")
    End Sub

    Private Sub dragndrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)

    End Sub

    Public files() As String
    Private Sub Form1_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim temp As New List(Of String)
        Me.Opacity = 1
        Dim files2() As String = e.Data.GetData(DataFormats.FileDrop)

        For Each path2 As String In files2
            If System.IO.Path.GetExtension(path2).ToLower.Contains(".gif") _
                OrElse System.IO.Path.GetExtension(path2).ToLower.Contains(".jpg") _
                OrElse System.IO.Path.GetExtension(path2).ToLower.Contains(".png") _
                OrElse System.IO.Path.GetExtension(path2).ToLower.Contains(".apng") _
                OrElse System.IO.Path.GetExtension(path2).ToLower.Contains(".tiff") _
                OrElse System.IO.Path.GetExtension(path2).ToLower.Contains(".bmp") _
                OrElse System.IO.Path.GetExtension(path2).ToLower.Contains(".pdf") _
                OrElse System.IO.Path.GetExtension(path2).ToLower.Contains(".xcf") Then

                temp.Add(path2)



            End If

        Next
        If temp.Count = 0 Then
            MessageBox.Show("This file type is not supported")
            Return
        End If
        files = temp.ToArray


        For Each path As String In files



            If files.Count < 2 Then

                'single image upload

                singleresult.TextBox1.Text = UploadImage(path)

                singleresult.Show()

                Return

            End If
        Next

        albumprompt.ShowDialog()

        If AlbumState = True Then
            albuminfoform.ShowDialog()
            If Not Canceled Then



                publicalbum = CreateAlbum(TitleText, DescriptionText, "public", LayoutMode)
                BWhash = publicalbum.Hash.ToString

                For Each path2 In files

                    If path2.Contains("jpg") Or path2.Contains("gif") Or path2.Contains("png") Or path2.Contains("apng") Or path2.Contains("bmp") Or path2.Contains("pdf") Or path2.Contains("xcf") Then
                        NumImages = NumImages + 1
                        workerURLs.Enqueue(path2)
                    End If
                Next


                results.Show()
                results.Label1.Text = "Imgup Mass Uploader - Status: Working..."
                Dim maxThrds As Integer = 10


                For i As Integer = 0 To My.Settings.threads - 1

                    Dim bgw As New BackgroundWorker()

                    bgw.WorkerReportsProgress = True

                    bgw.WorkerSupportsCancellation = True

                    AddHandler bgw.DoWork, New DoWorkEventHandler(AddressOf bgw_DoWork)

                    AddHandler bgw.ProgressChanged, New ProgressChangedEventHandler(AddressOf bgw_ProgressChanged)

                    AddHandler bgw.RunWorkerCompleted, New RunWorkerCompletedEventHandler(AddressOf bgw_RunWorkerCompleted)
                    bgws.Add(bgw)
                    'Start The Worker 
                    bgw.RunWorkerAsync()

                Next
            Else
                Return
                Canceled = False
            End If

        ElseIf AlbumState = False Then

            For Each path2 In files
                If path2.Contains("jpg") Or path2.Contains("gif") Or path2.Contains("png") Or path2.Contains("apng") Or path2.Contains("bmp") Or path2.Contains("pdf") Or path2.Contains("xcf") Then
                    NumImages = NumImages + 1
                    workerURLs.Enqueue(path2)
                End If
            Next


            results.Show()
            results.Label1.Text = "Imgup Mass Uploader - Status: Working..."
            Dim maxThrds As Integer = 10


            For i As Integer = 0 To My.Settings.threads - 1

                Dim bgw As New BackgroundWorker()

                bgw.WorkerReportsProgress = True

                bgw.WorkerSupportsCancellation = True

                AddHandler bgw.DoWork, New DoWorkEventHandler(AddressOf bgw_DoWork)

                AddHandler bgw.ProgressChanged, New ProgressChangedEventHandler(AddressOf bgw_ProgressChanged)

                AddHandler bgw.RunWorkerCompleted, New RunWorkerCompletedEventHandler(AddressOf bgw_RunWorkerCompleted)
                bgws.Add(bgw)
                'Start The Worker 
                bgw.RunWorkerAsync()

            Next
        End If
    End Sub


    Private Sub bgw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)


        Dim bgw As BackgroundWorker = DirectCast(sender, BackgroundWorker)

        Dim workToDo As Boolean = True

        While workToDo
            Dim nextUrl As String = ""
            SyncLock workerURLsLock
                Try
                    nextUrl = workerURLs.Dequeue()
                Catch
                End Try

            End SyncLock

            If Not String.IsNullOrWhiteSpace(nextUrl) Then
                If bgw.CancellationPending Then
                    bgw.CancelAsync()
                    e.Cancel = True
                    Return
                End If

                'Do work

                Try

                    If AlbumState = True Then

                        AddImageToAlbum(nextUrl, BWhash)
                        NumImages = NumImages - 1
                        bgw.ReportProgress(0, publicalbum.URL & "*" & nextUrl)

                    ElseIf AlbumState = False Then
                        Dim ImageUrl = UploadImage(nextUrl)
                        NumImages = NumImages - 1
                        bgw.ReportProgress(0, ImageUrl & "*" & nextUrl)
                    End If


                Catch s As Exception
                    bgw.ReportProgress(0, "Failed:" & s.Message & "*" & nextUrl)

                End Try
            Else
                workToDo = False
            End If
        End While
    End Sub


    Private Sub bgw_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        Dim bgw As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        Dim data() As String = Split(DirectCast(e.UserState, String), "*", , CompareMethod.Text)

        results.DataGridView1.Rows.Add(data(1), data(0))
        results.Label1.Text = "Imgup Mass Uploader - Status: " & NumImages & " images left"

    End Sub

    Private Sub bgw_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Dim bgw As BackgroundWorker = DirectCast(sender, BackgroundWorker)
        bgws.Remove(bgw)
        bgw.Dispose()
        If bgws.Count = 0 Then
            NumImages = 0
            results.Show()
            results.Label1.Text = "Imgup Mass Uploader - Status: Idle"
            MessageBox.Show("Done!")
        End If
    End Sub


    Private Sub Form1_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
            Me.Opacity = 0.75
        End If
    End Sub


    Dim IsDraggingForm As Boolean = False
    Private MousePos As New System.Drawing.Point(0, 0)

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            IsDraggingForm = True
            MousePos = e.Location
        End If

        If e.Button = MouseButtons.Right Then
            ContextMenuStrip1.Show(MousePosition)
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

    Private Sub AlwaysOnTopToolStripMenuItem_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AlwaysOnTopToolStripMenuItem.CheckStateChanged
        If AlwaysOnTopToolStripMenuItem.Checked = True Then
            My.Settings.ontop = True
        ElseIf AlwaysOnTopToolStripMenuItem.Checked = False Then
            My.Settings.ontop = False

        End If
        My.Settings.Save()

        If My.Settings.ontop = True Then
            Me.TopMost = True
        End If

        If My.Settings.ontop = False Then
            Me.TopMost = False
        End If
    End Sub



    Private Sub AlwaysOnTopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlwaysOnTopToolStripMenuItem.Click
       
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub Form1_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DragLeave
        Me.Opacity = 1
    End Sub

    Private Sub OpenMassUploaderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenMassUploaderToolStripMenuItem.Click
        results.Show()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RegisterHotKey(Me.Handle, 100, MOD_ALT, Keys.F2)
        RegisterHotKey(Me.Handle, 200, MOD_ALT, Keys.F1)
        Me.Size = New System.Drawing.Size(60, 60)
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        Dim scr = Screen.FromPoint(Me.Location)
        Me.Location = New Point(scr.WorkingArea.Right - Me.Width + 30, scr.WorkingArea.Top + 10)
        MyBase.OnLoad(e)
    End Sub

    Private Sub SmallToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SmallToolStripMenuItem.Click
        SmallToolStripMenuItem.Checked = True
        MediumToolStripMenuItem.Checked = False
        LargeToolStripMenuItem.Checked = False
        Me.Size = New System.Drawing.Size(60, 60)

    End Sub


    Private Sub MediumToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MediumToolStripMenuItem.Click
        MediumToolStripMenuItem.Checked = True

        SmallToolStripMenuItem.Checked = False
        LargeToolStripMenuItem.Checked = False


        Me.Size = New System.Drawing.Size(90, 90)

    End Sub


    Private Sub LargeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LargeToolStripMenuItem.Click
        LargeToolStripMenuItem.Checked = True
        SmallToolStripMenuItem.Checked = False
        MediumToolStripMenuItem.Checked = False
        Me.Size = New System.Drawing.Size(120, 120)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        about.ShowDialog()
    End Sub

    Private Sub PasteURLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteURLToolStripMenuItem.Click
        singleresult.TextBox1.Text = "http://" & UploadImageUrl(Clipboard.GetText)
        singleresult.Show()
    End Sub

    Private Sub RandomCatPicToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RandomCatPicToolStripMenuItem.Click
        catpic.Show()
    End Sub

    Private Sub FacebookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacebookToolStripMenuItem.Click
        Process.Start("https://www.facebook.com/sharer/sharer.php?u=http://www.imgup.us")
    End Sub

    Private Sub TwitterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TwitterToolStripMenuItem.Click
        Process.Start("https://twitter.com/intent/tweet?original_referer" & "http://www.imgup.us" & "&text=" & "Check out Imgup the simple Imgur uploader!: " & "http://www.imgup.us" & "&via=imgupwidget")
    End Sub

    Private Sub ResToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        results.Show()
    End Sub

    Private Sub ResToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        results.Show()
    End Sub

    Private Sub FullScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FullScreenToolStripMenuItem.Click

        Dim path As String = FullscreenShot()
        If path = "canceled" Then
            Exit Sub
        End If

        If My.Settings.autoup = False Then
            prompt.ShowDialog()
            If prompt.UploadBool = True Then
                singleresult.TextBox1.Text = UploadImage(path)
                singleresult.Show()
            ElseIf prompt.UploadBool = False Then

                Return
            End If

        ElseIf My.Settings.autoup Then
            singleresult.TextBox1.Text = UploadImage(path)
            NotifyIcon1.ShowBalloonTip(3000, "Done!", "Upload Complete", ToolTipIcon.Info)
            singleresult.Show()
        End If

    End Sub
    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        settings.ShowDialog()

    End Sub

    Private Sub SelectRegionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectRegionToolStripMenuItem.Click
        Region_Drag.Show()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Save()
    End Sub

    Private Sub CheckForUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckForUpdateToolStripMenuItem.Click
        Try
            Dim webclient As New WebClient

            ' This bit of code reads the remote file, UpdateDetails.TXT.
            Dim url As String = "http://www.imgup.us/version.txt"

            Dim Source As New System.Text.StringBuilder
            Dim WebResponse As Net.WebResponse = Net.WebRequest.Create(url).GetResponse
            Dim StreamReader As New IO.StreamReader(WebResponse.GetResponseStream())

            Do
                Source.Append(StreamReader.ReadLine())
            Loop Until StreamReader.ReadLine() Is Nothing

            StreamReader.Close()

            ' This bit of code reads the remote file, UpdateChecker.TXT. If the version in the file is not equal to the version in Label1, then it displays a MessageBox with UpdateDetails.TXT.
            ' Make sure the UpdateChecker.TXT exactly reads '1.1' with no spaces or break spaces whatsoever.
            If webclient.DownloadString("http://www.imgup.us/version.txt") <> My.Application.Info.Version.ToString Then
                MessageBox.Show(Source.ToString, "Update available")
                Process.Start("http://www.imgup.us")

                'If the program is already the latest version, then show a MessageBox that it is already updated.
            ElseIf webclient.DownloadString("http://www.imgup.us/version.txt") = My.Application.Info.Version.ToString Then
                MessageBox.Show("You have the latest version!", "Up to date")
            End If
        Catch s As Exception
            MessageBox.Show("Uh-oh! Failed to reach the update server.  We got this error as a response: " & s.Message.ToString)
        End Try
    End Sub
End Class

