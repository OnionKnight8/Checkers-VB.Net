''' <summary>
''' This class contains information about the game pieces.
''' </summary>

Public Class GamePiece

    Private _intPlayer As Integer
    Private _strPieceName As String
    Private _strLocation As String
    Private _isAlive As Boolean
    Private _isKing As Boolean

    Sub New(ByVal intPlayer As Integer, ByVal strPieceName As String, ByVal strLocation As String, ByVal isAlive As Boolean, ByVal isKing As Boolean)
        ' Constructor

        _intPlayer = intPlayer
        _strPieceName = strPieceName
        _strLocation = strLocation
        _isAlive = isAlive
        _isKing = isKing
    End Sub

    ' Gets and Sets
    Function getPlayer() As String
        Return _intPlayer
    End Function
    Function setPlayer(ByVal intPlayer As Integer)
        _intPlayer = intPlayer
        Return Nothing
    End Function

    Function getName() As String
        Return _strPieceName
    End Function
    Function setName(ByVal strPieceName As String)
        _strPieceName = strPieceName
        Return Nothing
    End Function

    Function getLocation() As String
        Return _strLocation
    End Function
    Function setLocation(ByVal strLocation As String)
        _strLocation = strLocation
        Return Nothing
    End Function

    Function getAlive() As Boolean
        Return _isAlive
    End Function
    Function setAlive(ByVal isAlive As Boolean)
        _isAlive = isAlive
        Return Nothing
    End Function

    Function getKing() As Boolean
        Return _isKing
    End Function
    Function setKing(ByVal isKing As Boolean)
        _isKing = isKing
        Return Nothing
    End Function

End Class
