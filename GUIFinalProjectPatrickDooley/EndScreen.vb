''' <summary>
''' This is the form that displays the winner (or lack of one). It allows
''' the players to request a rematch.
''' </summary>

Public Class EndScreen
    Private _winCondition As String
    Private _p1 As Player
    Private _p2 As Player

    Sub New(ByVal winCondition As String, ByVal p1 As Player, ByVal p2 As Player)
        '   Contructor
        InitializeComponent()
        _winCondition = winCondition
        _p1 = p1
        _p2 = p2
    End Sub

    Private Sub EndScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   Sets up form
        Select Case _winCondition
            Case "p1Win"
                lblWinner.Text = _p1.getName & "!"
                PicKing.Image = My.Resources.p1KingPiece
                PicPawn1.Image = My.Resources.p1NormalPiece
                PicPawn2.Image = My.Resources.p1NormalPiece
                PicPawn3.Image = My.Resources.p1NormalPiece
                lblDescription.Text = ("The crabs captured all of the squids pieces." & vbNewLine & "Well done, " + _p1.getName + "!")
            Case "p2Win"
                lblWinner.Text = _p2.getName & "!"
                PicKing.Image = My.Resources.p2KingPiece
                PicPawn1.Image = My.Resources.p2NormalPiece
                PicPawn2.Image = My.Resources.p2NormalPiece
                PicPawn3.Image = My.Resources.p2NormalPiece
                lblDescription.Text = ("The squids captured all of the crabs pieces." & vbNewLine & "Well done, " + _p2.getName + "!")
            Case "p1WinStall"
                lblWinner.Text = _p1.getName & "!"
                PicKing.Image = My.Resources.p1KingPiece
                PicPawn1.Image = My.Resources.p1NormalPiece
                PicPawn2.Image = My.Resources.p1NormalPiece
                PicPawn3.Image = My.Resources.p1NormalPiece
                lblDescription.Text = ("The crabs won by stalling." & vbNewLine & "Lame!")
            Case "p2WinStall"
                lblWinner.Text = _p1.getName & "!"
                PicKing.Image = My.Resources.p1KingPiece
                PicPawn1.Image = My.Resources.p1NormalPiece
                PicPawn2.Image = My.Resources.p1NormalPiece
                PicPawn3.Image = My.Resources.p1NormalPiece
                lblDescription.Text = ("The squids won by stalling." & vbNewLine & "Lame!")
            Case "draw"
                lblWinner.Text = "Nobody!"
                PicKing.Image = My.Resources.question
                lblDescription.Text = ("How did this even happen?")
        End Select

        writeLog()
    End Sub

    Private Function writeLog()
        '   Writes the result of the game to the top of the game log. Only the last 10 games are stored.
        Dim fileLocation As String = System.IO.Path.Combine(Application.StartupPath, "GameLog.csv")
        Dim toWrite As String = (_winCondition & "," & _p1.getName & "," & _p2.getName)
        Dim lines As New List(Of String)
        lines.Add(toWrite)
        Dim iterate As Integer = 0

        Try
            If IO.File.Exists(fileLocation) Then
                Dim objReader As New System.IO.StreamReader(fileLocation)
                Do While objReader.Peek <> -1
                    lines.Add(objReader.ReadLine())
                Loop
                objReader.Close()
            End If

            Dim objWriter As New System.IO.StreamWriter(fileLocation, False)
            For Each item As String In lines
                If iterate < 10 Then
                    objWriter.WriteLine(item)
                End If
                iterate += 1
            Next
            objWriter.Close()

        Catch ex As Exception
            MsgBox("Could not create or write to game log!", , "Error")
        End Try

        Return Nothing
    End Function
End Class