''' <summary>
''' This is the primary frame in which the game is played. The program keeps track of the
''' initial space (first one clicked) and determines if there is a piece there. It then
''' keeps track of the second space selected, and determines if it is a valid move.
''' </summary>

Public Class Checkers
    Protected _intNumberOfSpaces = 63
    Protected _intNumberOfPieces = 23
    Private _turnsWithoutCapture As Integer
    Private _initialSpace As GameSpace
    Private _targetSpace As GameSpace
    Private _selectedSpace As GameSpace
    Private _spaces(_intNumberOfSpaces) As GameSpace
    Private _pieces(_intNumberOfPieces) As GamePiece
    Private _comboPiece As GamePiece
    Private _capturedPiece As GamePiece
    Private _currentTurn As Player
    Private _winCondition As String
    Private _p1 As Player
    Private _p2 As Player
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

            If Asc(_spaces(i).getX) < Asc("H") Then
                If (_spaces(i).getY) < 8 Then
                    For j = 0 To _intNumberOfSpaces
                        If Asc(_spaces(j).getX) = (Asc(_spaces(i).getX) + 1) And _spaces(j).getY = (_spaces(i).getY + 1) Then
                            _spaces(i).setUpRight(_spaces(j))
                            Exit For
                        End If
                    Next
                End If

                If (_spaces(i).getY) > 1 Then
                    For j = 0 To _intNumberOfSpaces
                        If Asc(_spaces(j).getX) = (Asc(_spaces(i).getX) + 1) And _spaces(j).getY = (_spaces(i).getY - 1) Then
                            _spaces(i).setDownRight(_spaces(j))
                            Exit For
                        End If
                    Next
                End If
            End If

            If Asc(_spaces(i).getX) > Asc("A") Then
                If ((_spaces(i).getY + 1) <= 8) Then
                    For j = 0 To _intNumberOfSpaces
                        If Asc(_spaces(j).getX) = (Asc(_spaces(i).getX) - 1) And _spaces(j).getY = (_spaces(i).getY + 1) Then
                            _spaces(i).setUpLeft(_spaces(j))
                            Exit For
                        End If
                    Next
                End If

                If (_spaces(i).getY) > 1 Then
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
            newPiece = New GamePiece(_p1, i, Nothing, True, False, My.Resources.p1NormalPiece)
            _pieces(i) = newPiece
        Next
        For i = 12 To _intNumberOfPieces
            newPiece = New GamePiece(_p2, i, Nothing, True, False, My.Resources.p2NormalPiece)
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
                If _currentTurn Is _selectedSpace.getPiece.getPlayer Then
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
        _turnsWithoutCapture = 0
        _currentTurn = _p1
        picP1Turn.Visible = True

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

    Private Sub loadGame(ByVal startOrGame As String)
        ' Loads a saved game.
        Dim loadGame As New LoadGame(_spaces)
        If loadGame.getSuccess() Then
            _initialSpace = Nothing
            lblInitialSpace.Text = ""
            lblTargetSpace.Text = ""
            _targetSpace = Nothing
            _p1 = loadGame.getP1
            _p2 = loadGame.getP2
            _currentTurn = loadGame.getCurrentTurn
            If _currentTurn Is _p1 Then
                picP1Turn.Show()
                picP2Turn.Hide()
            ElseIf _currentTurn Is _p2 Then
                picP2Turn.Show()
                picP1Turn.Hide()
            End If
            _turnsWithoutCapture = loadGame.getTurnsWithoutCapture
            _pieces = loadGame.getPieces

            For i = 0 To _intNumberOfSpaces
                _spaces(i).setPiece(Nothing)
                _spaces(i).getPicBox.Image = Nothing
                _spaces(i).getPicBox.BackColor = _spaces(i).getColor
            Next

            For i = 0 To _intNumberOfPieces
                For j = 0 To _intNumberOfSpaces
                    If _pieces(i).getLocation Is _spaces(j) Then
                        _spaces(j).setPiece(_pieces(i))
                        _spaces(j).getPicBox.Image = _pieces(i).getImage
                        Exit For
                    End If
                Next
            Next
            _comboPiece = loadGame.getComboPiece()
            If _comboPiece IsNot Nothing Then
                _initialSpace = _comboPiece.getLocation
                lblInitialSpace.Text = _initialSpace.getName
                _initialSpace.getPicBox.BackColor = Color.Tan
            End If

            lblPlayer1Name.Text = _p1.getName
            lblPlayer2Name.Text = _p2.getName
            lblP1PiecesTaken.Text = _p1.getPiecesTaken.ToString
            lblP2PiecesTaken.Text = _p2.getPiecesTaken.ToString
        Else
            If _newOrLoad = "loadFromStart" Then
                Dim StartScreen As New StartScreen
                StartScreen.Show()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub updateGame()
        '   Used to set pieces, check if a player has won, and swwitch turns.

        If _capturedPiece IsNot Nothing Then
            _capturedPiece.setAlive(False)
            _capturedPiece.getPlayer.setPiecesRemaining((_capturedPiece.getPlayer.getPiecesRemaining - 1))
            _capturedPiece.getLocation.getPicBox.Image = Nothing
            _capturedPiece.getLocation.setPiece(Nothing)
            _capturedPiece.setLocation(Nothing)
            _capturedPiece = Nothing
            _turnsWithoutCapture = 0
            If _currentTurn Is _p1 Then
                _p1.setPiecesTaken((_p1.getPiecesTaken + 1))
            ElseIf _currentTurn Is _p2 Then
                _p2.setPiecesTaken((_p2.getPiecesTaken + 1))
            End If
        Else
            _turnsWithoutCapture += 1
            If _turnsWithoutCapture = 25 Then
                MsgBox("25 turns have gone by without a capture, game will end at 50!", , "Warning!")
            ElseIf _turnsWithoutCapture = 40 Then
                MsgBox("10 turns remaining! Capture a piece to reset timer!", , "Warning!")
            ElseIf _turnsWithoutCapture = 47 Then
                MsgBox("3 turns remaining!", , "Warning!")
            ElseIf _turnsWithoutCapture = 48 Then
                MsgBox("2 turns remaining!", , "Warning!")
            ElseIf _turnsWithoutCapture = 49 Then
                MsgBox("1 turn remaining!", , "Warning!")
            End If
        End If

        For i = 0 To _intNumberOfSpaces
            If _spaces(i).getPiece IsNot Nothing Then
                _spaces(i).getPiece.setLocation(_spaces(i))
            End If
        Next

        For i = 0 To _intNumberOfPieces
            If _pieces(i).getAlive Then
                If _pieces(i).getKing = False Then
                    If _pieces(i).getPlayer Is _p1 Then
                        If _pieces(i).getLocation.getY = 8 Then
                            _pieces(i).setKing(True)
                            _pieces(i).setImage(My.Resources.p1KingPiece)
                        End If
                    ElseIf _pieces(i).getPlayer Is _p2 Then
                        If _pieces(i).getLocation.getY = 1 Then
                            _pieces(i).setKing(True)
                            _pieces(i).setImage(My.Resources.p2KingPiece)
                        End If
                    End If
                End If
            End If
        Next

        For i = 0 To _intNumberOfSpaces
            If _spaces(i).getPiece IsNot Nothing Then
                _spaces(i).getPicBox.Image = _spaces(i).getPiece.getImage
            Else
                _spaces(i).getPicBox.Image = Nothing
            End If
        Next

        If _p1.getPiecesRemaining = 0 Then
            _winCondition = "p2Win"
        ElseIf _p2.getPiecesRemaining = 0 Then
            _winCondition = "p1Win"
        ElseIf _turnsWithoutCapture = 50 And _p1.getPiecesRemaining > _p2.getPiecesRemaining Then
            _winCondition = "p1WinStall"
        ElseIf _turnsWithoutCapture = 50 And _p2.getPiecesRemaining > _p1.getPiecesRemaining Then
            _winCondition = "p2WinStall"
        ElseIf _turnsWithoutCapture = 50 And _p1.getPiecesRemaining = _p2.getPiecesRemaining Then
            _winCondition = "draw"
        End If

        If _winCondition IsNot Nothing Then
            Dim EndScreen As New EndScreen(_winCondition, _p1, _p2)
            EndScreen.Show()
            Me.Close()
        End If

        '   Change turns
        If _comboPiece Is Nothing Then
            If _currentTurn Is _p1 Then
                _currentTurn = _p2
                picP1Turn.Visible = False
                picP2Turn.Visible = True
            ElseIf _currentTurn Is _p2 Then
                _currentTurn = _p1
                picP2Turn.Visible = False
                picP1Turn.Visible = True
            End If
        Else
            If mustJump(_comboPiece) Then
                _initialSpace.getPicBox.BackColor = _initialSpace.getColor
                _initialSpace = _comboPiece.getLocation
                _initialSpace.getPicBox.BackColor = Color.Tan
                lblInitialSpace.Text = _initialSpace.getName
                _targetSpace = Nothing
                lblTargetSpace.Text = ""
            Else
                If _currentTurn Is _p1 Then
                    _comboPiece = Nothing
                    _currentTurn = _p2
                    picP1Turn.Visible = False
                    picP2Turn.Visible = True
                ElseIf _currentTurn Is _p2 Then
                    _comboPiece = Nothing
                    _currentTurn = _p1
                    picP2Turn.Visible = False
                    picP1Turn.Visible = True
                End If
            End If
        End If

        lblP1PiecesTaken.Text = _p1.getPiecesTaken.ToString
        lblP2PiecesTaken.Text = _p2.getPiecesTaken.ToString
    End Sub

    Private Function mustJump(ByVal piece As GamePiece)
        '   Check if player must jump.
        Dim canJump As Boolean = False

        If piece.getKing Then
            If piece.getLocation.getUpRight IsNot Nothing Then
                If piece.getLocation.getUpRight.getPiece IsNot Nothing Then
                    If piece.getLocation.getUpRight.getPiece.getPlayer IsNot _currentTurn Then
                        If piece.getLocation.getUpRight.getUpRight IsNot Nothing Then
                            If piece.getLocation.getUpRight.getUpRight.getPiece Is Nothing Then
                                canJump = True
                            End If
                        End If
                    End If
                End If
            End If
            If piece.getLocation.getUpLeft IsNot Nothing Then
                If piece.getLocation.getUpLeft.getPiece IsNot Nothing Then
                    If piece.getLocation.getUpLeft.getPiece.getPlayer IsNot _currentTurn Then
                        If piece.getLocation.getUpLeft.getUpLeft IsNot Nothing Then
                            If piece.getLocation.getUpLeft.getUpLeft.getPiece Is Nothing Then
                                canJump = True
                            End If
                        End If
                    End If
                End If
            End If
            If piece.getLocation.getDownRight IsNot Nothing Then
                If piece.getLocation.getDownRight.getPiece IsNot Nothing Then
                    If piece.getLocation.getDownRight.getPiece.getPlayer IsNot _currentTurn Then
                        If piece.getLocation.getDownRight.getDownRight IsNot Nothing Then
                            If piece.getLocation.getDownRight.getDownRight.getPiece Is Nothing Then
                                canJump = True
                            End If
                        End If
                    End If
                End If
            End If
            If piece.getLocation.getDownLeft IsNot Nothing Then
                If piece.getLocation.getDownLeft.getPiece IsNot Nothing Then
                    If piece.getLocation.getDownLeft.getPiece.getPlayer IsNot _currentTurn Then
                        If piece.getLocation.getDownLeft.getDownLeft IsNot Nothing Then
                            If piece.getLocation.getDownLeft.getDownLeft.getPiece Is Nothing Then
                                canJump = True
                            End If
                        End If
                    End If
                End If
            End If

        Else
            If _currentTurn Is _p1 Then
                If piece.getLocation.getUpRight IsNot Nothing Then
                    If piece.getLocation.getUpRight.getPiece IsNot Nothing Then
                        If piece.getLocation.getUpRight.getPiece.getPlayer IsNot _currentTurn Then
                            If piece.getLocation.getUpRight.getUpRight IsNot Nothing Then
                                If piece.getLocation.getUpRight.getUpRight.getPiece Is Nothing Then
                                    canJump = True
                                End If
                            End If
                        End If
                    End If
                End If
                If piece.getLocation.getUpLeft IsNot Nothing Then
                    If piece.getLocation.getUpLeft.getPiece IsNot Nothing Then
                        If piece.getLocation.getUpLeft.getPiece.getPlayer IsNot _currentTurn Then
                            If piece.getLocation.getUpLeft.getUpLeft IsNot Nothing Then
                                If piece.getLocation.getUpLeft.getUpLeft.getPiece Is Nothing Then
                                    canJump = True
                                End If
                            End If
                        End If
                    End If
                End If

            ElseIf _currentTurn Is _p2 Then
                If piece.getLocation.getDownRight IsNot Nothing Then
                    If piece.getLocation.getDownRight.getPiece IsNot Nothing Then
                        If piece.getLocation.getDownRight.getPiece.getPlayer IsNot _currentTurn Then
                            If piece.getLocation.getDownRight.getDownRight IsNot Nothing Then
                                If piece.getLocation.getDownRight.getDownRight.getPiece Is Nothing Then
                                    canJump = True
                                End If
                            End If
                        End If
                    End If
                End If
                If piece.getLocation.getDownLeft IsNot Nothing Then
                    If piece.getLocation.getDownLeft.getPiece IsNot Nothing Then
                        If piece.getLocation.getDownLeft.getPiece.getPlayer IsNot _currentTurn Then
                            If piece.getLocation.getDownLeft.getDownLeft IsNot Nothing Then
                                If piece.getLocation.getDownLeft.getDownLeft.getPiece Is Nothing Then
                                    canJump = True
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Return canJump
    End Function

    Private Function jumpCheck()
        Dim mustJump As Boolean = False

        If _initialSpace.getPiece.getKing() Then
            If _initialSpace.getUpRight IsNot Nothing Then
                If _initialSpace.getUpRight.getPiece IsNot Nothing Then
                    If _initialSpace.getUpRight.getPiece.getPlayer IsNot _currentTurn Then
                        If _initialSpace.getUpRight.getUpRight IsNot Nothing Then
                            If _targetSpace Is _initialSpace.getUpRight.getUpRight Then
                                mustJump = True
                                _capturedPiece = _initialSpace.getUpRight.getPiece
                            End If
                        End If
                    End If
                End If
            End If

            If _initialSpace.getUpLeft IsNot Nothing Then
                If _initialSpace.getUpLeft.getPiece IsNot Nothing Then
                    If _initialSpace.getUpLeft.getPiece.getPlayer IsNot _currentTurn Then
                        If _initialSpace.getUpLeft.getUpLeft IsNot Nothing Then
                            If _targetSpace Is _initialSpace.getUpLeft.getUpLeft Then
                                mustJump = True
                                _capturedPiece = _initialSpace.getUpLeft.getPiece
                            End If
                        End If
                    End If
                End If
            End If
            If _initialSpace.getDownRight IsNot Nothing Then
                If _initialSpace.getDownRight.getPiece IsNot Nothing Then
                    If _initialSpace.getDownRight.getPiece.getPlayer IsNot _currentTurn Then
                        If _initialSpace.getDownRight.getDownRight IsNot Nothing Then
                            If _targetSpace Is _initialSpace.getDownRight.getDownRight Then
                                mustJump = True
                                _capturedPiece = _initialSpace.getDownRight.getPiece
                            End If
                        End If
                    End If
                End If
            End If

            If _initialSpace.getDownLeft IsNot Nothing Then
                If _initialSpace.getDownLeft.getPiece IsNot Nothing Then
                    If _initialSpace.getDownLeft.getPiece.getPlayer IsNot _currentTurn Then
                        If _initialSpace.getDownLeft.getDownLeft IsNot Nothing Then
                            If _targetSpace Is _initialSpace.getDownLeft.getDownLeft Then
                                mustJump = True
                                _capturedPiece = _initialSpace.getDownLeft.getPiece
                            End If
                        End If
                    End If
                End If
            End If

        Else
            If _currentTurn Is _p1 Then
                If _initialSpace.getUpRight IsNot Nothing Then
                    If _initialSpace.getUpRight.getPiece IsNot Nothing Then
                        If _initialSpace.getUpRight.getPiece.getPlayer IsNot _currentTurn Then
                            If _initialSpace.getUpRight.getUpRight IsNot Nothing Then
                                If _targetSpace Is _initialSpace.getUpRight.getUpRight Then
                                    mustJump = True
                                    _capturedPiece = _initialSpace.getUpRight.getPiece
                                End If
                            End If
                        End If
                    End If
                End If

                If _initialSpace.getUpLeft IsNot Nothing Then
                    If _initialSpace.getUpLeft.getPiece IsNot Nothing Then
                        If _initialSpace.getUpLeft.getPiece.getPlayer IsNot _currentTurn Then
                            If _initialSpace.getUpLeft.getUpLeft IsNot Nothing Then
                                If _targetSpace Is _initialSpace.getUpLeft.getUpLeft Then
                                    mustJump = True
                                    _capturedPiece = _initialSpace.getUpLeft.getPiece
                                End If
                            End If
                        End If
                    End If
                End If

            ElseIf _currentTurn Is _p2 Then
                If _initialSpace.getDownRight IsNot Nothing Then
                    If _initialSpace.getDownRight.getPiece IsNot Nothing Then
                        If _initialSpace.getDownRight.getPiece.getPlayer IsNot _currentTurn Then
                            If _initialSpace.getDownRight.getDownRight IsNot Nothing Then
                                If _targetSpace Is _initialSpace.getDownRight.getDownRight Then
                                    mustJump = True
                                    _capturedPiece = _initialSpace.getDownRight.getPiece
                                End If
                            End If
                        End If
                    End If
                End If

                If _initialSpace.getDownLeft IsNot Nothing Then
                    If _initialSpace.getDownLeft.getPiece IsNot Nothing Then
                        If _initialSpace.getDownLeft.getPiece.getPlayer IsNot _currentTurn Then
                            If _initialSpace.getDownLeft.getDownLeft IsNot Nothing Then
                                If _targetSpace Is _initialSpace.getDownLeft.getDownLeft Then
                                    mustJump = True
                                    _capturedPiece = _initialSpace.getDownLeft.getPiece
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Return mustJump
    End Function


    Private Sub btnMove_Click(sender As Object, e As EventArgs) Handles btnMove.Click
        '   When the move button is clicked, the application will check if the move
        '   the player is attempting to make is valid and then execute it.
        Dim checkJump As Boolean = False

        If _comboPiece Is Nothing Then
            For i = 0 To _intNumberOfPieces
                If _pieces(i).getAlive Then
                    If _pieces(i).getPlayer Is _currentTurn Then
                        If mustJump(_pieces(i)) Then
                            checkJump = True
                        End If
                    End If
                End If
            Next
        End If

        If _initialSpace Is Nothing Or _targetSpace Is Nothing Then
            MsgBox("Select a piece you want to move and where you want to move it!", , "Error")
        ElseIf _targetSpace.getPiece IsNot Nothing Then
            MsgBox("You cannot move a piece on top of another piece!", , "Error")

            '   Actually move piece. 
        ElseIf checkJump Or _comboPiece IsNot Nothing Then
            If jumpCheck() Then
                _targetSpace.setPiece(_initialSpace.getPiece)
                _comboPiece = _initialSpace.getPiece
                _initialSpace.setPiece(Nothing)
                updateGame()
            Else
                MsgBox("You must jump this turn!", , "Error")
            End If
        Else
            If _initialSpace.getPiece.getKing() Then
                If (_initialSpace.getUpRight Is _targetSpace) Or (_initialSpace.getUpLeft Is _targetSpace) Or (_initialSpace.getDownLeft Is _targetSpace) Or (_initialSpace.getDownRight Is _targetSpace) Then
                    _targetSpace.setPiece(_initialSpace.getPiece)
                    _initialSpace.setPiece(Nothing)
                    updateGame()
                Else
                    MsgBox("This piece can only move one space in any direction diagonally!", , "Error")
                End If
            Else
                If _currentTurn Is _p1 Then
                    If (_initialSpace.getUpRight Is _targetSpace) Or (_initialSpace.getUpLeft Is _targetSpace) Then
                        _targetSpace.setPiece(_initialSpace.getPiece)
                        _initialSpace.setPiece(Nothing)
                        updateGame()
                    Else
                        MsgBox("This piece can only move diagonally right or diagonally left one space!", , "Error")
                    End If

                ElseIf _currentTurn Is _p2 Then
                    If (_initialSpace.getDownRight Is _targetSpace) Or (_initialSpace.getDownLeft Is _targetSpace) Then
                        _targetSpace.setPiece(_initialSpace.getPiece)
                        _initialSpace.setPiece(Nothing)
                        updateGame()
                    Else
                        MsgBox("This piece can only move diagonally right or diagonally left one space!", , "Error")
                    End If
                End If
            End If
        End If

        If _comboPiece Is Nothing Then
            If _initialSpace IsNot Nothing Then
                _initialSpace.getPicBox.BackColor = _initialSpace.getColor
                lblInitialSpace.Text = ""
            End If
            _initialSpace = Nothing
        End If
        If _targetSpace IsNot Nothing Then
            _targetSpace.getPicBox.BackColor = _targetSpace.getColor
            lblTargetSpace.Text = ""
        End If
        _selectedSpace = Nothing
        _targetSpace = Nothing
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        '   The clear button resets the player's turn.
        If _comboPiece IsNot Nothing Then
            MsgBox("You must jump with selected piece.", , "Warning")
        Else
            If _initialSpace IsNot Nothing Then
                lblInitialSpace.Text = ""
                _initialSpace.getPicBox.BackColor = _initialSpace.getColor
                _initialSpace = Nothing
            End If
        End If

        If _targetSpace IsNot Nothing Then
            lblTargetSpace.Text = ""
            _targetSpace.getPicBox.BackColor = _targetSpace.getColor
            _targetSpace = Nothing
        End If

        _selectedSpace = Nothing
    End Sub

    Private Sub Checkers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   Sets up the board on load, distributes pieces and clears text fields.
        lblInitialSpace.Text = ""
        lblTargetSpace.Text = ""
        Select Case _newOrLoad
            Case "new"
                newGame()
            Case "load"
                loadGame("game")
            Case "loadFromStart"
                loadGame("start")
        End Select
        lblPlayer1Name.Text = _p1.getName
        lblPlayer2Name.Text = _p2.getName
        lblP1PiecesTaken.Text = _p1.getPiecesTaken.ToString
        lblP2PiecesTaken.Text = _p2.getPiecesTaken.ToString
    End Sub

    Private Sub mnuLoad_Click(sender As Object, e As EventArgs) Handles mnuLoad.Click
        '   Allows user to select game to load, and then loads it.
        Dim query = MsgBox("Are you sure that you want to load? (Unsaved progress will be lost!)", vbYesNo, "Caution!")
        Select Case query
            Case vbYes
                loadGame("load")
        End Select
    End Sub

    Private Sub mnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click
        '   Creates a new game (asks user if they are sure first).
        Dim query = MsgBox("Are you sure that you want to make a new game? (Unsaved progress will be lost!)", vbYesNo, "Caution!")
        Select Case query
            Case vbYes
                Dim newCheckers As New Checkers(_p1, _p2, "new")
                newCheckers.Show()
                Me.Close()
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
        Dim gameLog As New GameLog
        gameLog.ShowDialog()

    End Sub

    Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
        'Saves the users game.
        Dim fileLocation As String = System.IO.Path.Combine(Application.StartupPath, "SaveGame.csv")
        Dim query = MsgBox("Are you sure you want to save? Previous save game will be erased!", vbYesNo, "Caution")
        Select Case query
            Case vbYes
                Try
                    Dim objWriter As New System.IO.StreamWriter(fileLocation, False)

                    objWriter.WriteLine(_p1.getNumber & "," & _p1.getName & "," & _p1.getPiecesTaken & "," & _p1.getPiecesRemaining)
                    objWriter.WriteLine(_p2.getNumber & "," & _p2.getName & "," & _p2.getPiecesTaken & "," & _p2.getPiecesRemaining)
                    objWriter.WriteLine(_currentTurn.getNumber)
                    objWriter.WriteLine(_turnsWithoutCapture)
                    For i = 0 To _intNumberOfPieces
                        If _pieces(i).getAlive Then
                            objWriter.WriteLine(_pieces(i).getPlayer.getNumber & "," & _pieces(i).getName & "," & _pieces(i).getAlive &
                            "," & _pieces(i).getLocation.getName & "," & _pieces(i).getKing)
                        Else
                            objWriter.WriteLine(_pieces(i).getPlayer.getNumber & "," & _pieces(i).getName & "," & _pieces(i).getAlive &
                            "," & "Nothing" & "," & _pieces(i).getKing)
                        End If
                    Next
                    If _comboPiece IsNot Nothing Then
                        objWriter.WriteLine(_comboPiece.getName())
                    Else
                        objWriter.WriteLine("Nothing")
                    End If

                    objWriter.Close()
                    MsgBox("Game was saved successfully!", , "Success")
                Catch ex As Exception
                    MsgBox("Something went wrong, game could not be saved!", , "Error")
                End Try
        End Select
    End Sub
End Class