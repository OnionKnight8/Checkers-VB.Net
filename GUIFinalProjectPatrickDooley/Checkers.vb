''' <summary>
''' This is the primary frame in which the game is played. The program keeps track of the
''' initial space (first one clicked) and determines if there is a piece there. It then
''' keeps track of the second space selected, and determines if it is a valid move.
''' </summary>

Public Class Checkers
    Protected _intNumberOfSpaces = 63
    Private _initialSpace As GameSpace
    Private _targetSpace As GameSpace
    Private _spaces(_intNumberOfSpaces) As GameSpace
    Protected _p1 As Player
    Protected _p2 As Player

    Sub New(ByVal p1 As Player, ByVal p2 As Player)
        ' Constructor
        InitializeComponent()
        _p1 = p1
        _p2 = p2
        SetSpaces()
    End Sub

    Sub SetSpaces()
        ' Creates an array of all spaces on the board.

        Dim picSpaces = {picA1, picA2, picA3, picA4, picA5, picA6, picA7, picA8,
            picB1, picB2, picB3, picB4, picB5, picB6, picB7, picB8,
            picC1, picC2, picC3, picC4, picC5, picC6, picC7, picC8,
            picD1, picD2, picD3, picD4, picD5, picD6, picD7, picD8,
            picE1, picE2, picE3, picE4, picE5, picE6, picE7, picE8,
            picF1, picF2, picF3, picF4, picF5, picF6, picF7, picF8,
            picG1, picG2, picG3, picG4, picG5, picG6, picG7, picG8,
            picH1, picH2, picH3, picH4, picH5, picH6, picH7, picH8}

        Dim x As String
        Dim y As String
        Dim i As Integer
        Dim newSpace As GameSpace
        For i = 0 To _intNumberOfSpaces
            x = picSpaces(i).Name.Substring(3, 1).ToString
            y = picSpaces(i).Name.Substring(4, 1).ToString
            newSpace = New GameSpace((x & y), x, Integer.Parse(y), picSpaces(i), Nothing)
            _spaces(i) = newSpace
        Next
    End Sub

    Private Sub AllPictureBoxes_ClickHandler(sender As Object, e As EventArgs) Handles picA1.Click,
            picA2.Click, picA3.Click, picA4.Click, picA5.Click, picA6.Click, picA7.Click, picA8.Click,
            picB1.Click, picB2.Click, picB3.Click, picB4.Click, picB5.Click, picB6.Click, picB7.Click, picB8.Click,
            picC1.Click, picC2.Click, picC3.Click, picC4.Click, picC5.Click, picC6.Click, picC7.Click, picC8.Click,
            picD1.Click, picD2.Click, picD3.Click, picD4.Click, picD5.Click, picD6.Click, picD7.Click, picD8.Click,
            picE1.Click, picE2.Click, picE3.Click, picE4.Click, picE5.Click, picE6.Click, picE7.Click, picE8.Click,
            picF1.Click, picF2.Click, picF3.Click, picF4.Click, picF5.Click, picF6.Click, picF7.Click, picF8.Click,
            picG1.Click, picG2.Click, picG3.Click, picG4.Click, picG5.Click, picG6.Click, picG7.Click, picG8.Click,
            picH1.Click, picH2.Click, picH3.Click, picH4.Click, picH5.Click, picH6.Click, picH7.Click, picH8.Click

        ' This is the handler for all of the picture boxes, or spaces, that allows the user
        ' to select where they want to move.
        Dim selectedBox As PictureBox = DirectCast(sender, PictureBox)
        Dim selectedSpace As GameSpace
        Dim i As Integer
        For i = 0 To _intNumberOfSpaces
            If _spaces(i).getName = selectedBox.Name.Substring(3).ToString Then
                selectedSpace = _spaces(i)
                Exit For
            End If
        Next

        If _initialSpace Is Nothing Then
            _initialSpace = selectedSpace
            lblInitialSpace.Text = _initialSpace.getName
        ElseIf _targetSpace Is Nothing Then
            _targetSpace = selectedSpace
            lblTargetSpace.Text = _targetSpace.getName
        End If
    End Sub

    Private Sub btnMove_Click(sender As Object, e As EventArgs) Handles btnMove.Click

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' The clear button resets the player's turn.

        lblInitialSpace.Text = ""
        lblTargetSpace.Text = ""
        _initialSpace = Nothing
        _targetSpace = Nothing
    End Sub

    Private Sub Checkers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Sets up the board on load, distributes pieces and clears text fields.
        'InitializeComponent()
        lblPlayer1Name.Text = _p1.getName
        lblPlayer2Name.Text = _p2.getName
        lblP1PiecesTaken.Text = _p1.getPiecesTaken.ToString
        lblP2PiecesTaken.Text = _p2.getPiecesTaken.ToString
        lblInitialSpace.Text = ""
        lblTargetSpace.Text = ""
    End Sub
End Class