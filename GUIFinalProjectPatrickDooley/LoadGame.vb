Public Class LoadGame
    Protected _intNumberOfPieces = 23
    Protected _intNumberOfSpaces = 63
    Private _p1 As Player
    Private _p2 As Player
    Private _currentTurn As Player
    Private _pieces(_intNumberOfPieces) As GamePiece
    Private _spaces(_intNumberOfSpaces) As GameSpace
    Private _comboPiece As GamePiece
    Private _turnsWithoutCapture As Integer
    Private _success As Boolean

    Sub New(ByVal spaces() As GameSpace)
        'Contructor
        _spaces = spaces
        loadGame()
    End Sub

    Private Sub loadGame()
        '   Attempts to read SaveGame.csv and parse data into a new instance of Checkers.vb.
        Try
            Dim fileLocation As String = System.IO.Path.Combine(Application.StartupPath, "SaveGame.csv")
            Dim objReader As New System.IO.StreamReader(fileLocation)
            Dim line As String
            Dim splitLine As String()
            Dim newPiece As GamePiece
            Dim isAlive As Boolean
            Dim isKing As Boolean
            Dim player As Player
            Dim space As GameSpace
            Dim image As Image

            line = objReader.ReadLine()
            splitLine = line.Split(New Char() {","c})
            _p1 = New Player(splitLine(0), splitLine(1), splitLine(2), splitLine(3))

            line = objReader.ReadLine()
            splitLine = line.Split(New Char() {","c})
            _p2 = New Player(splitLine(0), splitLine(1), splitLine(2), splitLine(3))

            line = objReader.ReadLine()
            If line = _p1.getNumber Then
                _currentTurn = _p1
            ElseIf line = _p2.getNumber Then
                _currentTurn = _p2
            End If

            line = objReader.ReadLine()
            _turnsWithoutCapture = Integer.Parse(line)

            For i = 0 To _intNumberOfPieces
                line = objReader.ReadLine()
                splitLine = line.Split(New Char() {","c})

                Select Case splitLine(0)
                    Case 1
                        player = _p1
                        Select Case splitLine(4)
                            Case "True"
                                isKing = True
                                image = My.Resources.p1KingPiece
                            Case "False"
                                isKing = False
                                image = My.Resources.p1NormalPiece
                        End Select
                    Case 2
                        player = _p2
                        Select Case splitLine(4)
                            Case "True"
                                isKing = True
                                image = My.Resources.p2KingPiece
                            Case "False"
                                isKing = False
                                image = My.Resources.p2NormalPiece
                        End Select
                End Select
                Select Case splitLine(2)
                    Case "True"
                        isAlive = True
                        For j = 0 To _intNumberOfSpaces
                            If _spaces(j).getName = splitLine(3) Then
                                space = _spaces(j)
                                Exit For
                            End If
                        Next
                        newPiece = New GamePiece(player, splitLine(1), space, isAlive, isKing, image)
                        _pieces(i) = newPiece
                    Case "False"
                        isAlive = False
                        newPiece = New GamePiece(player, splitLine(1), Nothing, isAlive, isKing, image)
                        _pieces(i) = newPiece
                End Select
            Next

            line = objReader.ReadLine()
            If line <> "Nothing" Then
                For i = 0 To _intNumberOfPieces
                    If line = _pieces(i).getName Then
                        _comboPiece = _pieces(i)
                        Exit For
                    End If
                Next
            Else
                _comboPiece = Nothing
            End If

            objReader.Close()
            _success = True
            MsgBox("Game successfully loaded!", , "Success")
        Catch ex As Exception
            MsgBox("Failed to load game, data may be corrupt or missing!", , "Error")
            _success = False
        End Try
    End Sub

    Function getSuccess()
        Return _success
    End Function
    Function getP1()
        Return _p1
    End Function
    Function getP2()
        Return _p2
    End Function
    Function getCurrentTurn()
        Return _currentTurn
    End Function
    Function getTurnsWithoutCapture()
        Return _turnsWithoutCapture
    End Function
    Function getPieces()
        Return _pieces
    End Function
    Function getComboPiece()
        Return _comboPiece
    End Function
End Class
