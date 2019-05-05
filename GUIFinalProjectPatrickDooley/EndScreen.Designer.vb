<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EndScreen
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
        Me.lblWinner = New System.Windows.Forms.Label()
        Me.lblRematch = New System.Windows.Forms.Label()
        Me.btnYes = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.btnLog = New System.Windows.Forms.Button()
        Me.btnCredits = New System.Windows.Forms.Button()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.PicPawn1 = New System.Windows.Forms.PictureBox()
        Me.PicPawn3 = New System.Windows.Forms.PictureBox()
        Me.PicPawn2 = New System.Windows.Forms.PictureBox()
        Me.PicKing = New System.Windows.Forms.PictureBox()
        CType(Me.PicPawn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPawn3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPawn2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicKing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(12, 9)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(431, 91)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Winner:"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblWinner
        '
        Me.lblWinner.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWinner.Location = New System.Drawing.Point(89, 100)
        Me.lblWinner.Name = "lblWinner"
        Me.lblWinner.Size = New System.Drawing.Size(276, 66)
        Me.lblWinner.TabIndex = 1
        Me.lblWinner.Text = "XXXXXX"
        Me.lblWinner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRematch
        '
        Me.lblRematch.AutoSize = True
        Me.lblRematch.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRematch.Location = New System.Drawing.Point(97, 494)
        Me.lblRematch.Name = "lblRematch"
        Me.lblRematch.Size = New System.Drawing.Size(260, 30)
        Me.lblRematch.TabIndex = 9
        Me.lblRematch.Text = "Don't You Want a Rematch?"
        '
        'btnYes
        '
        Me.btnYes.BackColor = System.Drawing.Color.Tan
        Me.btnYes.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYes.Location = New System.Drawing.Point(98, 538)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(129, 43)
        Me.btnYes.TabIndex = 10
        Me.btnYes.Text = "Runback!"
        Me.btnYes.UseVisualStyleBackColor = False
        '
        'btnNo
        '
        Me.btnNo.BackColor = System.Drawing.Color.Tan
        Me.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnNo.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo.Location = New System.Drawing.Point(233, 538)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(129, 43)
        Me.btnNo.TabIndex = 11
        Me.btnNo.Text = "Nah, I'm Good"
        Me.btnNo.UseVisualStyleBackColor = False
        '
        'btnLog
        '
        Me.btnLog.BackColor = System.Drawing.Color.Tan
        Me.btnLog.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLog.Location = New System.Drawing.Point(98, 438)
        Me.btnLog.Name = "btnLog"
        Me.btnLog.Size = New System.Drawing.Size(129, 43)
        Me.btnLog.TabIndex = 12
        Me.btnLog.Text = "Game Log"
        Me.btnLog.UseVisualStyleBackColor = False
        '
        'btnCredits
        '
        Me.btnCredits.BackColor = System.Drawing.Color.Tan
        Me.btnCredits.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCredits.Location = New System.Drawing.Point(233, 438)
        Me.btnCredits.Name = "btnCredits"
        Me.btnCredits.Size = New System.Drawing.Size(129, 43)
        Me.btnCredits.TabIndex = 13
        Me.btnCredits.Text = "Credits"
        Me.btnCredits.UseVisualStyleBackColor = False
        '
        'lblDescription
        '
        Me.lblDescription.Font = New System.Drawing.Font("Franklin Gothic Medium Cond", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(17, 354)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(426, 81)
        Me.lblDescription.TabIndex = 14
        Me.lblDescription.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PicPawn1
        '
        Me.PicPawn1.Location = New System.Drawing.Point(89, 263)
        Me.PicPawn1.Name = "PicPawn1"
        Me.PicPawn1.Size = New System.Drawing.Size(88, 88)
        Me.PicPawn1.TabIndex = 5
        Me.PicPawn1.TabStop = False
        '
        'PicPawn3
        '
        Me.PicPawn3.Location = New System.Drawing.Point(277, 263)
        Me.PicPawn3.Name = "PicPawn3"
        Me.PicPawn3.Size = New System.Drawing.Size(88, 88)
        Me.PicPawn3.TabIndex = 4
        Me.PicPawn3.TabStop = False
        '
        'PicPawn2
        '
        Me.PicPawn2.Location = New System.Drawing.Point(183, 263)
        Me.PicPawn2.Name = "PicPawn2"
        Me.PicPawn2.Size = New System.Drawing.Size(88, 88)
        Me.PicPawn2.TabIndex = 3
        Me.PicPawn2.TabStop = False
        '
        'PicKing
        '
        Me.PicKing.Location = New System.Drawing.Point(183, 169)
        Me.PicKing.Name = "PicKing"
        Me.PicKing.Size = New System.Drawing.Size(88, 88)
        Me.PicKing.TabIndex = 2
        Me.PicKing.TabStop = False
        '
        'EndScreen
        '
        Me.AcceptButton = Me.btnYes
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Bisque
        Me.CancelButton = Me.btnNo
        Me.ClientSize = New System.Drawing.Size(455, 593)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.btnCredits)
        Me.Controls.Add(Me.btnLog)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.lblRematch)
        Me.Controls.Add(Me.PicPawn1)
        Me.Controls.Add(Me.PicPawn3)
        Me.Controls.Add(Me.PicPawn2)
        Me.Controls.Add(Me.PicKing)
        Me.Controls.Add(Me.lblWinner)
        Me.Controls.Add(Me.lblHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "EndScreen"
        Me.Text = "EndScreen"
        CType(Me.PicPawn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicPawn3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicPawn2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicKing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents lblWinner As Label
    Friend WithEvents PicKing As PictureBox
    Friend WithEvents PicPawn2 As PictureBox
    Friend WithEvents PicPawn3 As PictureBox
    Friend WithEvents PicPawn1 As PictureBox
    Friend WithEvents lblRematch As Label
    Friend WithEvents btnYes As Button
    Friend WithEvents btnNo As Button
    Friend WithEvents btnLog As Button
    Friend WithEvents btnCredits As Button
    Friend WithEvents lblDescription As Label
End Class
