Imports System.Math
Imports System.Drawing.Imaging

Public Class Region_Drag
    Dim bmp As Bitmap
    Dim graphics As Graphics
    Public showMon As Integer = 0
    Private MyRectangle As Rectangle
    Private Drawing As Boolean = False
    Private StartX, StartY, CursorX, CursorY As Single
    Public ClickPoint As New Point()
    Public CurrentTopLeft As New Point()
    Public CurrentBottomRight As New Point()
    Public DragClickRelative As New Point()

    'functions

    Private Function GetMyScreen() As Screen
        Dim myLocation As Point = Me.Location
        Return Screen.FromPoint(myLocation)
    End Function

    Public Function RegionShot()
        Try
            Dim myScreen As Screen = GetMyScreen()

            Dim screenshot As New Bitmap(MyRectangle.Width, MyRectangle.Height, PixelFormat.Format32bppArgb)
            Using g As Graphics = graphics.FromImage(screenshot)
                ' CopyFromScreen() has no concept of what monitor it captures from, so the source point must
                ' be in terms of the virtual desktop, not the monitor.
                Dim desiredPoint As New Point(MyRectangle.X, MyRectangle.Y)
                Dim topLeft As New Point(myScreen.Bounds.X, myScreen.Bounds.Y)
                desiredPoint.Offset(topLeft)
                g.CopyFromScreen(desiredPoint, New Point(0, 0), screenshot.Size)
            End Using
            
            Dim saveDialog As New SaveFileDialog
            saveDialog.Filter = "JPeg Image|*.jpg"
            saveDialog.Title = "Save Image as"
            saveDialog.FileName = "ScreenCap_" & My.Settings.shotcount
            Me.Dispose()
            My.Computer.Audio.Play(My.Resources.camera, AudioPlayMode.Background)

            If Not My.Settings.screenpath = "" Then

                Dim defalpath = My.Settings.screenpath & "\" & "ScreenCap_" & My.Settings.shotcount & ".jpg"
                screenshot.Save(defalpath, ImageFormat.Jpeg)
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
                    screenshot.Save(saveDialog.FileName, ImageFormat.Jpeg)
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

                screenshot.Dispose()
                Return saveDialog.FileName
                End If
            
        Catch
            Return ("failed")
        End Try

    End Function
    

    Private Sub ShowOnMonitor()
        Dim sc As Screen()
        sc = Screen.AllScreens

        ' Erase previous drawing
       

        showMon = GetNextMonIdx()

        If showMon > sc.Length - 1 Then
            Return
        End If

        Me.WindowState = FormWindowState.Normal
        Me.ClientSize = New System.Drawing.Size(518, 416)
        Application.DoEvents()

        Me.StartPosition = FormStartPosition.Manual
        Me.Left = sc(showMon).Bounds.Left
        Me.Top = sc(showMon).Bounds.Top
        Me.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Maximized


    End Sub

    Private Function GetPrimaryMonIdx() As Integer
        Dim sc As Screen()
        sc = Screen.AllScreens
        Dim idx As Integer = 0

        For Each s As Screen In sc
            If s.Bounds.Left = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Left Then
                Exit For
            Else
                idx += 1
            End If
        Next

        Return If((idx <= sc.Length), idx, 0)
    End Function

    Private Function GetNextMonIdx() As Integer
        Dim sc As Screen()
        sc = Screen.AllScreens
        Dim idx As Integer = 0

        For Each s As Screen In sc
            If s.Bounds.Left = Me.Left Then
                idx += 1
            Else
                Exit For
            End If
        Next

        Return If((idx <= sc.Length), idx, 0)
    End Function


    'end functions

    Private Sub Region_Drag_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim height As Integer = 0
        Dim width As Integer = 0
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyCode = Keys.S Then
            ShowOnMonitor()

        End If

    End Sub

    Private Sub Region_Drag_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Drawing = True
        StartX = e.X
        StartY = e.Y
        CursorX = e.X
        CursorY = e.Y
    End Sub

    Private Sub Region_Drag_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If Not Drawing Then Exit Sub
        Dim G As Graphics = Me.CreateGraphics
        CursorX = e.X
        CursorY = e.Y
        Me.Invalidate()
    End Sub


    Private Sub Region_Drag_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        Drawing = False
        Dim G As Graphics = Me.CreateGraphics
        G.DrawRectangle(Pens.Black, MyRectangle.X, MyRectangle.Y, MyRectangle.Width, MyRectangle.Height)
        Me.Invalidate()


        Dim path As String = RegionShot()


        If path = "canceled" Then
            Exit Sub
        End If

        If path = "failed" Then
            MessageBox.Show("Uh-oh")
            Exit Sub

        End If



        If My.Settings.autoup = False Then
            prompt.ShowDialog()
            If prompt.UploadBool = True Then
                singleresult.TextBox1.Text = Main.UploadImage(path)
                Main.NotifyIcon1.ShowBalloonTip(3000, "Done!", "Upload Complete", ToolTipIcon.Info)
                singleresult.ShowDialog()
            ElseIf prompt.UploadBool = False Then

                Return
            End If
        ElseIf My.Settings.autoup Then

            singleresult.TextBox1.Text = Main.UploadImage(path)
            Main.NotifyIcon1.ShowBalloonTip(3000, "Done!", "Upload Complete", ToolTipIcon.Info)
            singleresult.ShowDialog()
            
        End If

    End Sub


    Private Sub Region_Drag_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.Clear(Me.BackColor)
        If Drawing = True Then
            Dim Dashed_Pen As New Pen(Brushes.White, 1)

            Dashed_Pen.DashStyle = Drawing2D.DashStyle.Solid
            MyRectangle = New Rectangle(Min(StartX, CursorX), _
                                      Min(StartY, CursorY), _
                                      Abs(StartX - CursorX), _
                                      Abs(StartY - CursorY))

            e.Graphics.FillRectangle(New SolidBrush(Color.White), MyRectangle)

            e.Graphics.DrawRectangle(Dashed_Pen, MyRectangle)
        End If
    End Sub

    Private Sub Region_Drag_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Focus()


        Me.Width = My.Computer.Screen.WorkingArea.Width
        Me.Height = Screen.PrimaryScreen.Bounds.Height

        'Centers form to screen.
        Me.CenterToScreen()

        'Sets form to ontop of all other forms and Desktop!
        Me.TopMost = True

        'Sets Form state to minimize or maximize.
        Me.WindowState = FormWindowState.Maximized
        'Me.WindowState = FormWindowState.Minimized
        'Me.WindowState = FormWindowState.Normal


        Me.BackColor = Color.Black
        Me.DoubleBuffered = True
        Cursor = Cursors.Cross
    End Sub

    Private Sub Region_Drag_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.Focus()
    End Sub
End Class
