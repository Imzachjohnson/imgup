<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PasteURLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TakeAScreenshotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectRegionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FullScreenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlwaysOnTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SmallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MediumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LargeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenMassUploaderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RandomCatPicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShareUsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacebookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TwitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckForUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PasteURLToolStripMenuItem, Me.TakeAScreenshotToolStripMenuItem, Me.AlwaysOnTopToolStripMenuItem, Me.SizeToolStripMenuItem, Me.OpenMassUploaderToolStripMenuItem, Me.RandomCatPicToolStripMenuItem, Me.ShareUsToolStripMenuItem, Me.ToolStripMenuItem1, Me.AboutToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.CheckForUpdateToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(174, 274)
        '
        'PasteURLToolStripMenuItem
        '
        Me.PasteURLToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasteURLToolStripMenuItem.Image = Global.Imgup.My.Resources.Resources.clipboard_past_icon_32
        Me.PasteURLToolStripMenuItem.Name = "PasteURLToolStripMenuItem"
        Me.PasteURLToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.PasteURLToolStripMenuItem.Text = "Paste URL"
        '
        'TakeAScreenshotToolStripMenuItem
        '
        Me.TakeAScreenshotToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectRegionToolStripMenuItem, Me.FullScreenToolStripMenuItem})
        Me.TakeAScreenshotToolStripMenuItem.Image = Global.Imgup.My.Resources.Resources.photo_icon_32
        Me.TakeAScreenshotToolStripMenuItem.Name = "TakeAScreenshotToolStripMenuItem"
        Me.TakeAScreenshotToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.TakeAScreenshotToolStripMenuItem.Text = "Take a screenshot"
        '
        'SelectRegionToolStripMenuItem
        '
        Me.SelectRegionToolStripMenuItem.Image = Global.Imgup.My.Resources.Resources.cursor_drag_arrow_icon_32
        Me.SelectRegionToolStripMenuItem.Name = "SelectRegionToolStripMenuItem"
        Me.SelectRegionToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.SelectRegionToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.SelectRegionToolStripMenuItem.Text = "Select region"
        '
        'FullScreenToolStripMenuItem
        '
        Me.FullScreenToolStripMenuItem.Image = Global.Imgup.My.Resources.Resources.monitor_icon_32
        Me.FullScreenToolStripMenuItem.Name = "FullScreenToolStripMenuItem"
        Me.FullScreenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F2), System.Windows.Forms.Keys)
        Me.FullScreenToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.FullScreenToolStripMenuItem.Text = "Fullscreen"
        Me.FullScreenToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AlwaysOnTopToolStripMenuItem
        '
        Me.AlwaysOnTopToolStripMenuItem.Checked = Global.Imgup.My.MySettings.Default.ontop
        Me.AlwaysOnTopToolStripMenuItem.CheckOnClick = True
        Me.AlwaysOnTopToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.AlwaysOnTopToolStripMenuItem.Image = Global.Imgup.My.Resources.Resources.round_and_up_icon_32
        Me.AlwaysOnTopToolStripMenuItem.Name = "AlwaysOnTopToolStripMenuItem"
        Me.AlwaysOnTopToolStripMenuItem.ShowShortcutKeys = False
        Me.AlwaysOnTopToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.AlwaysOnTopToolStripMenuItem.Text = "Always on top"
        '
        'SizeToolStripMenuItem
        '
        Me.SizeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SmallToolStripMenuItem, Me.MediumToolStripMenuItem, Me.LargeToolStripMenuItem})
        Me.SizeToolStripMenuItem.Image = Global.Imgup.My.Resources.Resources.zoom_icon_32
        Me.SizeToolStripMenuItem.Name = "SizeToolStripMenuItem"
        Me.SizeToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SizeToolStripMenuItem.Text = "Size"
        '
        'SmallToolStripMenuItem
        '
        Me.SmallToolStripMenuItem.Checked = True
        Me.SmallToolStripMenuItem.CheckOnClick = True
        Me.SmallToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SmallToolStripMenuItem.Name = "SmallToolStripMenuItem"
        Me.SmallToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.SmallToolStripMenuItem.Text = "Small"
        '
        'MediumToolStripMenuItem
        '
        Me.MediumToolStripMenuItem.CheckOnClick = True
        Me.MediumToolStripMenuItem.Name = "MediumToolStripMenuItem"
        Me.MediumToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.MediumToolStripMenuItem.Text = "Medium"
        '
        'LargeToolStripMenuItem
        '
        Me.LargeToolStripMenuItem.CheckOnClick = True
        Me.LargeToolStripMenuItem.Name = "LargeToolStripMenuItem"
        Me.LargeToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.LargeToolStripMenuItem.Text = "Large"
        '
        'OpenMassUploaderToolStripMenuItem
        '
        Me.OpenMassUploaderToolStripMenuItem.Image = Global.Imgup.My.Resources.Resources.round1
        Me.OpenMassUploaderToolStripMenuItem.Name = "OpenMassUploaderToolStripMenuItem"
        Me.OpenMassUploaderToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.OpenMassUploaderToolStripMenuItem.Text = "Open Mass Uploader"
        '
        'RandomCatPicToolStripMenuItem
        '
        Me.RandomCatPicToolStripMenuItem.Image = Global.Imgup.My.Resources.Resources.emotion_smile_icon_32
        Me.RandomCatPicToolStripMenuItem.Name = "RandomCatPicToolStripMenuItem"
        Me.RandomCatPicToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.RandomCatPicToolStripMenuItem.Text = "Random Cat Pic"
        '
        'ShareUsToolStripMenuItem
        '
        Me.ShareUsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FacebookToolStripMenuItem, Me.TwitterToolStripMenuItem})
        Me.ShareUsToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShareUsToolStripMenuItem.Image = Global.Imgup.My.Resources.Resources.share_2_icon_32
        Me.ShareUsToolStripMenuItem.Name = "ShareUsToolStripMenuItem"
        Me.ShareUsToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.ShareUsToolStripMenuItem.Text = "Share Imgup!"
        '
        'FacebookToolStripMenuItem
        '
        Me.FacebookToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FacebookToolStripMenuItem.Image = Global.Imgup.My.Resources.Resources.facebook_icon_32
        Me.FacebookToolStripMenuItem.Name = "FacebookToolStripMenuItem"
        Me.FacebookToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.FacebookToolStripMenuItem.Text = "Facebook"
        '
        'TwitterToolStripMenuItem
        '
        Me.TwitterToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TwitterToolStripMenuItem.Image = Global.Imgup.My.Resources.Resources.twitter_icon_32
        Me.TwitterToolStripMenuItem.Name = "TwitterToolStripMenuItem"
        Me.TwitterToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.TwitterToolStripMenuItem.Text = "Twitter"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(170, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = Global.Imgup.My.Resources.Resources.info_icon_32
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Image = Global.Imgup.My.Resources.Resources.wrench_plus_2_icon_32
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'CheckForUpdateToolStripMenuItem
        '
        Me.CheckForUpdateToolStripMenuItem.Image = Global.Imgup.My.Resources.Resources.refresh_icon_32
        Me.CheckForUpdateToolStripMenuItem.Name = "CheckForUpdateToolStripMenuItem"
        Me.CheckForUpdateToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.CheckForUpdateToolStripMenuItem.Text = "Check for updates"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = Global.Imgup.My.Resources.Resources.delete_icon_32
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Imgup"
        Me.NotifyIcon1.Visible = True
        '
        'Main
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.Imgup.My.Resources.Resources.logo
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(90, 90)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.ShowInTaskbar = False
        Me.Text = "Form1"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AlwaysOnTopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SmallToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MediumToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LargeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenMassUploaderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteURLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RandomCatPicToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShareUsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacebookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TwitterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TakeAScreenshotToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FullScreenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectRegionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CheckForUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon

End Class
