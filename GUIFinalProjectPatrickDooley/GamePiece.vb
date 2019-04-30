''' <summary>
''' This class contains information about the game pieces.
''' </summary>

Public Class GamePiece

    Private _player As Player
    Private _strPieceName As Integer
    Private _location As GameSpace
    Private _isAlive As Boolean
    Private _isKing As Boolean
    Private _image As Image

    Sub New(ByVal player As Player, ByVal strPieceName As Integer, ByVal location As GameSpace, ByVal isAlive As Boolean, ByVal isKing As Boolean, ByVal image As Image)
        ' Constructor

        _player = player
        _strPieceName = strPieceName
        _location = location
        _isAlive = isAlive
        _isKing = isKing
        _image = image
    End Sub

    ' Gets and Sets
    Function getPlayer() As Player
        Return _player
    End Function
    Function setPlayer(ByVal player As Player)
        _player = player
        Return Nothing
    End Function

    Function getName() As Integer
        Return _strPieceName
    End Function
    Function setName(ByVal strPieceName As Integer)
        _strPieceName = strPieceName
        Return Nothing
    End Function

    Function getLocation() As GameSpace
        Return _location
    End Function
    Function setLocation(ByVal location As GameSpace)
        _location = location
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

    Function getImage() As Image
        Return _image
    End Function
    Function setImage(ByVal image As Image)
        _image = image
        Return Nothing
    End Function
End Class
