''' <summary>
''' This is the primary frame in which the game is played. The program keeps track of the
''' initial space (first one clicked) and determines if there is a piece there. It then
''' keeps track of the second space selected, and determines if it is a valid move.
''' </summary>

Public Class Checkers
    Protected _intNumberOfSpaces = 63
    Protected _intNumberOfPieces = 23
    Private _turnCount As Integer
    Private _turnsWithoutCapture As Integer
    Private _initialSpace As GameSpace
    Private _targetSpace As GameSpace
    Private _selectedSpace As GameSpace
    Private _spaces(_intNumberOfSpaces) As GameSpace
    Private _pieces(_intNumberOfPieces) As GamePiece
    Private _currentTurn As Player
    Protected _p1 As Player
    Protected _p2 As Player
    Private _newOrLoad As String

    Sub New(ByVal p1 As Player, ByVal p2 As Player, ByVal newOrLoad As String)
        '   Constructor
        InitializeComponent()
        _p1 = p1
        _p2 = p2
        _newOrLoad = newOrLoad
        SetSpaces()
        SetPieces()
    End Sub

    Private Sub SetSpaces()
        '   Creates an array of all spaces on the board, and sets their adjacencys. 

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

        '   Creates game spaces.
        For i = 0 To _intNumberOfSpaces
            x = picSpaces(i).Name.Substring(3, 1).ToString
            y = picSpaces(i).Name.Substring(4, 1).ToString
            newSpace = New GameSpace((x & y), x, Integer.Parse(y), picSpaces(i), Nothing, picSpaces(i).BackColor, Nothing, Nothing, Nothing, Nothing)
            _spaces(i) = newSpace
        Next

        '   Sets spaces adjacencys.
        For i = 0 To _intNumberOfSpaces

            If (Asc(_spaces(i).getX) + 1) <= Asc("H") Then
                If ((_spaces(i).getY + 1) <= 8) Then
                    For j = 0 To _intNumberOfSpaces
                        If Asc(_spaces(j).getX) = (Asc(_spaces(i).getX) + 1) And _spaces(j).getY = (_spaces(i).getY + 1) Then
                            _spaces(i).setUpRight(_spaces(j))
                            Exit For
                        End If
                    Next
                End If

                If ((_spaces(i).getY - 1) >= 1) Then
                    For j = 0 To _intNumberOfSpaces
                        If Asc(_spaces(j).getX) = (Asc(_spaces(i).getX) + 1) And _spaces(j).getY = (_spaces(i).getY - 1) Then
                            _spaces(i).setDownRight(_spaces(j))
                            Exit For
                        End If
                    Next
                End If
            End If

            If (Asc(_spaces(i).getX) - 1) >= Asc("A") Then
                If ((_spaces(i).getY + 1) <= 8) Then
                    For j = 0 To _intNumberOfSpaces
                        If Asc(_spaces(j).getX) = (Asc(_spaces(i).getX) - 1) And _spaces(j).getY = (_spaces(i).getY + 1) Then
                            _spaces(i).setUpLeft(_spaces(j))
                            Exit For
                        End If
                    Next
                End If

                If ((_spaces(i).getY - 1) >= 1) Then
                    For j = 0 To _intNumberOfSpaces
                        If Asc(_spaces(j).getX) = (Asc(_spaces(i).getX) - 1) And _spaces(j).getY = (_spaces(i).getY - 1) Then
                            _spaces(i).setDownLeft(_spaces(j))
                            Exit For
                        End If
                    Next
                End If
            End If
        Next
    End Sub

    Private Sub SetPieces()
        '   Creates array of game pieces.

        Dim newPiece As GamePiece
        For i = 0 To 11
            newPiece = New GamePiece(1, i, Nothing, True, False, My.Resources.p1NormalPiece)
            _pieces(i) = newPiece
        Next
        For i = 12 To _intNumberOfPieces
            newPiece = New GamePiece(2, i, Nothing, True, False, My.Resources.p2NormalPiece)
            _pieces(i) = newPiece
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

        '   This is the handler for all of the picture boxes, or spaces, that allows the user
        '   to select where they want to move.

        Dim selectedBox As PictureBox = DirectCast(sender, PictureBox)
        For i = 0 To _intNumberOfSpaces
            If _spaces(i).getName = selectedBox.Name.Substring(3).ToString Then
                _selectedSpace = _spaces(i)
                Exit For
            End If
        Next

        If _selectedSpace IsNot Nothing Then
            If _initialSpace Is Nothing And _selectedSpace.getPiece IsNot Nothing Then
                If _currentTurn.getNumber = _selectedSpace.getPiece.getPlayer Then
                    _initialSpace = _selectedSpace
                    lblInitialSpace.Text = _initialSpace.getName
                    _initialSpace.getPicBox.BackColor = Color.Tan
                End If
            ElseIf _initialSpace IsNot Nothing And _targetSpace Is Nothing Then
                _targetSpace = _selectedSpace
                lblTargetSpace.Text = _targetSpace.getName
                _targetSpace.getPicBox.BackColor = Color.Tan
            End If
        End If

        _selectedSpace = Nothing
    End Sub

    Private Sub newGame()
        '   Creates a new game.

        lblInitialSpace.Text = ""
        lblTargetSpace.Text = ""
        lblP1PiecesTaken.Text = _p1.getPiecesTaken.ToString
        lblP2PiecesTaken.Text = _p2.getPiecesTaken.ToString
        _turnCount = 0
        _turnsWithoutCapture = 0
        _currentTurn = _p1
        SetPieces()

        For i = 0 To _intNumberOfSpaces
            If (_spaces(i).getName = "A1") Then
                _spaces(i).setPiece(_pieces(0))
            ElseIf (_spaces(i).getName = "C1") Then
                _spaces(i).setPiece(_pieces(1))
            ElseIf (_spaces(i).getName = "E1") Then
                _spaces(i).setPiece(_pieces(2))
            ElseIf (_spaces(i).getName = "G1") Then
                _spaces(i).setPiece(_pieces(3))
            ElseIf (_spaces(i).getName = "B2") Then
                _spaces(i).setPiece(_pieces(4))
            ElseIf (_spaces(i).getName = "D2") Then
                _spaces(i).setPiece(_pieces(5))
            ElseIf (_spaces(i).getName = "F2") Then
                _spaces(i).setPiece(_pieces(6))
            ElseIf (_spaces(i).getName = "H2") Then
                _spaces(i).setPiece(_pieces(7))
            ElseIf (_spaces(i).getName = "A3") Then
                _spaces(i).setPiece(_pieces(8))
            ElseIf (_spaces(i).getName = "C3") Then
                _spaces(i).setPiece(_pieces(9))
            ElseIf (_spaces(i).getName = "E3") Then
                _spaces(i).setPiece(_pieces(10))
            ElseIf (_spaces(i).getName = "G3") Then
                _spaces(i).setPiece(_pieces(11))
            ElseIf (_spaces(i).getName = "B6") Then
                _spaces(i).setPiece(_pieces(12))
            ElseIf (_spaces(i).getName = "D6") Then
                _spaces(i).setPiece(_pieces(13))
            ElseIf (_spaces(i).getName = "F6") Then
                _spaces(i).setPiece(_pieces(14))
            ElseIf (_spaces(i).getName = "H6") Then
                _spaces(i).setPiece(_pieces(15))
            ElseIf (_spaces(i).getName = "A7") Then
                _spaces(i).setPiece(_pieces(16))
            ElseIf (_spaces(i).getName = "C7") Then
                _spaces(i).setPiece(_pieces(17))
            ElseIf (_spaces(i).getName = "E7") Then
                _spaces(i).setPiece(_pieces(18))
            ElseIf (_spaces(i).getName = "G7") Then
                _spaces(i).setPiece(_pieces(19))
            ElseIf (_spaces(i).getName = "B8") Then
                _spaces(i).setPiece(_pieces(20))
            ElseIf (_spaces(i).getName = "D8") Then
                _spaces(i).setPiece(_pieces(21))
            ElseIf (_spaces(i).getName = "F8") Then
                _spaces(i).setPiece(_pieces(22))
            ElseIf (_spaces(i).getName = "H8") Then
                _spaces(i).setPiece(_pieces(23))
            End If

            If _spaces(i).getPiece IsNot Nothing Then
                _spaces(i).getPiece.setLocation(_spaces(i))
                _spaces(i).getPicBox.Image = _spaces(i).getPiece.getImage
            End If
        Next
    End Sub

    Private Sub loadGame()
        ' Loads a saved game.

    End Sub

    Private Sub gameOverCheck()
        If _p1.getPiecesRemaining = 0 Then
            '_winCondition = "p2Win"
        ElseIf _p2.getPiecesRemaining = 0 Then
            '_winCondition = "p1Win"
        ElseIf _turnsWithoutCapture = 49 Then
            '_winCondition = "draw"
        End If
    End Sub

    Private Function mustJump()
        '   Check if player must jump.
        Dim canJump As Boolean = False

        For i = 0 To _intNumberOfSpaces

            If _spaces(i).getUpRight IsNot Nothing Then
                If _spaces(i).getUpRight.getPiece IsNot Nothing Then
                    If _spaces(i).getUpRight.getPiece.getPlayer <> _currentTurn.getNumber Then
                        canJump = True
                        Exit For
                    End If
                End If
            End If

            If _spaces(i).getUpLeft IsNot Nothing Then
                If _spaces(i).getUpLeft.getPiece IsNot Nothing Then
                    If _spaces(i).getUpLeft.getPiece.getPlayer <> _currentTurn.getNumber Then
                        canJump = True
                        Exit For
                    End If
                End If
            End If

            If _spaces(i).getDownRight IsNot Nothing Then
                If _spaces(i).getDownRight.getPiece IsNot Nothing Then
                    If _spaces(i).getDownRight.getPiece.getPlayer <> _currentTurn.getNumber Then
                        canJump = True
                        Exit For
                    End If
                End If
            End If

            If _spaces(i).getDownLeft IsNot Nothing Then
                If _spaces(i).getDownLeft.getPiece IsNot Nothing Then
                    If _spaces(i).getDownLeft.getPiece.getPlayer <> _currentTurn.getNumber Then
                        canJump = True
                        Exit For
                    End If
                End If
            End If
        Next
        Return canJump
    End Function


    Private Sub btnMove_Click(sender As Object, e As EventArgs) Handles btnMove.Click
        '   When the move button is clicked, the application will check if the move
        '   the player is attempting to make is valid and then execute it.

        If _initialSpace Is Nothing Or _targetSpace Is Nothing Then
            MsgBox("Select a piece you want to move and where you want to move it!", , "Error")
        ElseIf _targetSpace.getPiece IsNot Nothing Then
            MsgBox("You cannot move a piece on top of another piece!", , "Error")
        End If

        '   Actually move piece. 
        If mustJump() Then

        Else
            If _initialSpace.getPiece.getKing() Then
                If (_initialSpace.getUpRight Is _targetSpace) Or (_initialSpace.getUpLeft Is _targetSpace) Or (_initialSpace.getDownLeft Is _targetSpace) Or (_initialSpace.getDownRight Is _targetSpace) Then

                Else
                    MsgBox("This piece can only move one space in any direction diagonally!", , "Error")
                End If
            Else
                If (_initialSpace.getUpRight Is _targetSpace) Or (_initialSpace.getUpLeft Is _targetSpace) Then

                Else
                    MsgBox("This piece can only move diagonally right or diagonally left one space!", , "Error")
                End If
            End If
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        '   The clear button resets the player's turn.

        lblInitialSpace.Text = ""
        lblTargetSpace.Text = ""
        _initialSpace.getPicBox.BackColor = _initialSpace.getColor
        _targetSpace.getPicBox.BackColor = _targetSpace.getColor
        _selectedSpace = Nothing
        _initialSpace = Nothing
        _targetSpace = Nothing
    End Sub

    Private Sub Checkers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   Sets up the board on load, distributes pieces and clears text fields.
        lblPlayer1Name.Text = _p1.getName
        lblPlayer2Name.Text = _p2.getName
        lblP1PiecesTaken.Text = _p1.getPiecesTaken.ToString
        lblP2PiecesTaken.Text = _p2.getPiecesTaken.ToString
        lblInitialSpace.Text = ""
        lblTargetSpace.Text = ""
        Select Case _newOrLoad
            Case "new"
                newGame()
            Case "load"
                loadGame()
        End Select
    End Sub

    Private Sub mnuLoad_Click(sender As Object, e As EventArgs) Handles mnuLoad.Click
        '   Allows user to select game to load, and then loads it.

    End Sub

    Private Sub mnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click
        '   Creates a new game (asks user if they are sure first).
        Dim query = MsgBox("Are you sure that you want to make a new game? (Unsaved progress will be lost!)", vbYesNo, "Caution!")
        Select Case query
            Case vbYes
                newGame()
        End Select
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        '   Exits application (asks user if they are sure first).
        Dim query = MsgBox("Are you sure that you want to exit? (Unsaved progress will be lost!)", vbYesNo, "Caution!")
        Select Case query
            Case vbYes
                Application.Exit()
        End Select
    End Sub

    Private Sub mnuInstruct_Click(sender As Object, e As EventArgs) Handles mnuInstruct.Click
        '   Opens Instructions form.
        Dim instructionsForm As New Instructions
        instructionsForm.ShowDialog()

    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        'Opens About form.
        Dim aboutForm As New About
        aboutForm.ShowDialog()

    End Sub

    Private Sub mnuLog_Click(sender As Object, e As EventArgs) Handles mnuLog.Click
        'Opens GameLog form.
    End Sub
End Class