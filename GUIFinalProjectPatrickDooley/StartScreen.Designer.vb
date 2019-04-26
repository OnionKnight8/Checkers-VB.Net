<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartScreen
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
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblInstruct = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblPlayer1 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPlayer1 = New System.Windows.Forms.TextBox()
        Me.txtPlayer2 = New System.Windows.Forms.TextBox()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLoad = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClear = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInstruct = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(12, 24)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(430, 91)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Checkers!"
        '
        'lblInstruct
        '
        Me.lblInstruct.AutoSize = True
        Me.lblInstruct.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstruct.Location = New System.Drawing.Point(59, 416)
        Me.lblInstruct.Name = "lblInstruct"
        Me.lblInstruct.Size = New System.Drawing.Size(336, 30)
        Me.lblInstruct.TabIndex = 1
        Me.lblInstruct.Text = "Welcome! Who will be playing today?"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.GUIFinalProjectPatrickDooley.My.Resources.Resources.checkerboard
        Me.PictureBox1.Location = New System.Drawing.Point(20, 118)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(414, 286)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'lblPlayer1
        '
        Me.lblPlayer1.AutoSize = True
        Me.lblPlayer1.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayer1.Location = New System.Drawing.Point(118, 456)
        Me.lblPlayer1.Name = "lblPlayer1"
        Me.lblPlayer1.Size = New System.Drawing.Size(71, 24)
        Me.lblPlayer1.TabIndex = 3
        Me.lblPlayer1.Text = "Player 1:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(118, 493)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 24)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Player 2:"
        '
        'txtPlayer1
        '
        Me.txtPlayer1.BackColor = System.Drawing.Color.Tan
        Me.txtPlayer1.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlayer1.Location = New System.Drawing.Point(195, 453)
        Me.txtPlayer1.Name = "txtPlayer1"
        Me.txtPlayer1.Size = New System.Drawing.Size(142, 29)
        Me.txtPlayer1.TabIndex = 5
        '
        'txtPlayer2
        '
        Me.txtPlayer2.BackColor = System.Drawing.Color.Tan
        Me.txtPlayer2.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlayer2.Location = New System.Drawing.Point(195, 490)
        Me.txtPlayer2.Name = "txtPlayer2"
        Me.txtPlayer2.Size = New System.Drawing.Size(142, 29)
        Me.txtPlayer2.TabIndex = 6
        '
        'btnPlay
        '
        Me.btnPlay.BackColor = System.Drawing.Color.Tan
        Me.btnPlay.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlay.Location = New System.Drawing.Point(155, 538)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(145, 43)
        Me.btnPlay.TabIndex = 7
        Me.btnPlay.Text = "Play!"
        Me.btnPlay.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(455, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLoad, Me.mnuClear, Me.mnuExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'mnuLoad
        '
        Me.mnuLoad.Name = "mnuLoad"
        Me.mnuLoad.Size = New System.Drawing.Size(101, 22)
        Me.mnuLoad.Text = "Load"
        '
        'mnuClear
        '
        Me.mnuClear.Name = "mnuClear"
        Me.mnuClear.Size = New System.Drawing.Size(101, 22)
        Me.mnuClear.Text = "Clear"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(101, 22)
        Me.mnuExit.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuInstruct, Me.mnuLog, Me.mnuAbout})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'mnuInstruct
        '
        Me.mnuInstruct.Name = "mnuInstruct"
        Me.mnuInstruct.Size = New System.Drawing.Size(149, 22)
        Me.mnuInstruct.Text = "Instructions"
        '
        'mnuLog
        '
        Me.mnuLog.Name = "mnuLog"
        Me.mnuLog.Size = New System.Drawing.Size(149, 22)
        Me.mnuLog.Text = "Game Log"
        '
        'mnuAbout
        '
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(149, 22)
        Me.mnuAbout.Text = "About/Credits"
        '
        'StartScreen
        '
        Me.AcceptButton = Me.btnPlay
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Bisque
        Me.ClientSize = New System.Drawing.Size(455, 593)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.txtPlayer2)
        Me.Controls.Add(Me.txtPlayer1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblPlayer1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblInstruct)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "StartScreen"
        Me.Text = "Player Select"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents lblInstruct As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblPlayer1 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPlayer1 As TextBox
    Friend WithEvents txtPlayer2 As TextBox
    Friend WithEvents btnPlay As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuLoad As ToolStripMenuItem
    Friend WithEvents mnuClear As ToolStripMenuItem
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuInstruct As ToolStripMenuItem
    Friend WithEvents mnuAbout As ToolStripMenuItem
    Friend WithEvents mnuLog As ToolStripMenuItem
End Class
