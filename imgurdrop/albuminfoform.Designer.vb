<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class albuminfoform
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(albuminfoform))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.descriptiontextbox = New System.Windows.Forms.TextBox()
        Me.titletextbox = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.horz = New System.Windows.Forms.RadioButton()
        Me.vert = New System.Windows.Forms.RadioButton()
        Me.blog = New System.Windows.Forms.RadioButton()
        Me.grid = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.YellowGreen
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Album Title (optional):"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.descriptiontextbox)
        Me.GroupBox1.Controls.Add(Me.titletextbox)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.ForeColor = System.Drawing.Color.YellowGreen
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(380, 342)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Create an album"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.Imgup.My.Resources.Resources.imguplogo
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(19, 293)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(99, 38)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button1.FlatAppearance.BorderSize = 2
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Silver
        Me.Button1.Location = New System.Drawing.Point(163, 295)
        Me.Button1.Margin = New System.Windows.Forms.Padding(5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 33)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Black
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button4.FlatAppearance.BorderSize = 2
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Silver
        Me.Button4.Location = New System.Drawing.Point(267, 295)
        Me.Button4.Margin = New System.Windows.Forms.Padding(5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(94, 33)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "Save"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.YellowGreen
        Me.Label2.Location = New System.Drawing.Point(16, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(232, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Album Description (optional):"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'descriptiontextbox
        '
        Me.descriptiontextbox.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.descriptiontextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.descriptiontextbox.ForeColor = System.Drawing.Color.White
        Me.descriptiontextbox.Location = New System.Drawing.Point(19, 90)
        Me.descriptiontextbox.Multiline = True
        Me.descriptiontextbox.Name = "descriptiontextbox"
        Me.descriptiontextbox.Size = New System.Drawing.Size(342, 145)
        Me.descriptiontextbox.TabIndex = 5
        '
        'titletextbox
        '
        Me.titletextbox.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.titletextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.titletextbox.ForeColor = System.Drawing.Color.White
        Me.titletextbox.Location = New System.Drawing.Point(19, 39)
        Me.titletextbox.Name = "titletextbox"
        Me.titletextbox.Size = New System.Drawing.Size(342, 20)
        Me.titletextbox.TabIndex = 4
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.horz)
        Me.GroupBox3.Controls.Add(Me.vert)
        Me.GroupBox3.Controls.Add(Me.blog)
        Me.GroupBox3.Controls.Add(Me.grid)
        Me.GroupBox3.Location = New System.Drawing.Point(19, 241)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(342, 46)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Layout"
        '
        'horz
        '
        Me.horz.AutoSize = True
        Me.horz.Location = New System.Drawing.Point(153, 19)
        Me.horz.Name = "horz"
        Me.horz.Size = New System.Drawing.Size(75, 17)
        Me.horz.TabIndex = 12
        Me.horz.Text = " Horizontal"
        Me.horz.UseVisualStyleBackColor = True
        '
        'vert
        '
        Me.vert.AutoSize = True
        Me.vert.Location = New System.Drawing.Point(246, 19)
        Me.vert.Name = "vert"
        Me.vert.Size = New System.Drawing.Size(60, 17)
        Me.vert.TabIndex = 11
        Me.vert.Text = "Vertical"
        Me.vert.UseVisualStyleBackColor = True
        '
        'blog
        '
        Me.blog.AutoSize = True
        Me.blog.Checked = True
        Me.blog.Location = New System.Drawing.Point(17, 19)
        Me.blog.Name = "blog"
        Me.blog.Size = New System.Drawing.Size(46, 17)
        Me.blog.TabIndex = 9
        Me.blog.TabStop = True
        Me.blog.Text = "Blog"
        Me.blog.UseVisualStyleBackColor = True
        '
        'grid
        '
        Me.grid.AutoSize = True
        Me.grid.Location = New System.Drawing.Point(91, 19)
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(44, 17)
        Me.grid.TabIndex = 10
        Me.grid.Text = "Grid"
        Me.grid.UseVisualStyleBackColor = True
        '
        'albuminfoform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(404, 366)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "albuminfoform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create an album"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents descriptiontextbox As System.Windows.Forms.TextBox
    Friend WithEvents titletextbox As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents horz As System.Windows.Forms.RadioButton
    Friend WithEvents vert As System.Windows.Forms.RadioButton
    Friend WithEvents grid As System.Windows.Forms.RadioButton
    Friend WithEvents blog As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
