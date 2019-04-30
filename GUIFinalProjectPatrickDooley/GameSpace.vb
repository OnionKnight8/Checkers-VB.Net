''' <summary>
''' This class contains information about the spaces on the board.
''' </summary>

Public Class GameSpace

    Private _strName As String
    Private _strX As Char
    Private _intY As Integer
    Private _picBox As PictureBox
    Private _piece As GamePiece
    Private _color As Color
    Private _adjUpLeft As GameSpace
    Private _adjUpRight As GameSpace
    Private _adjDownLeft As GameSpace
    Private _adjDownRight As GameSpace

    Sub New(ByVal strName As String, ByVal strX As Char, ByVal intY As Integer, ByVal picBox As PictureBox, ByVal piece As GamePiece, ByVal color As Color,
            ByVal adjUpLeft As GameSpace, ByVal adjUpRight As GameSpace, ByVal adjDownLeft As GameSpace, ByVal adjDownRight As GameSpace)
        ' Constructor
        _strName = strName
        _strX = strX
        _intY = intY
        _picBox = picBox
        _piece = piece
        _color = color
        _adjUpLeft = adjUpLeft
        _adjUpRight = adjUpRight
        _adjDownLeft = adjDownLeft
        _adjDownRight = adjDownRight
    End Sub

    'Gets and sets
    Function getName() As String
        Return _strName
    End Function
    Function setName(ByVal strName As String)
        _strName = strName
        Return Nothing
    End Function

    Function getX() As Char
        Return _strX
    End Function
    Function setX(ByVal strX As Char)
        _strX = strX
        Return Nothing
    End Function

    Function getY() As Integer
        Return _intY
    End Function
    Function setY(ByVal intY As Integer)
        _intY = intY
        Return Nothing
    End Function

    Function getPicBox() As PictureBox
        Return _picBox
    End Function
    Function setPlayer(ByVal picBox As PictureBox)
        _picBox = picBox
        Return Nothing
    End Function

    Function getPiece() As GamePiece
        Return _piece
    End Function
    Function setPiece(ByVal piece As GamePiece)
        _piece = piece
        Return Nothing
    End Function

    Function getColor() As Color
        Return _color
    End Function
    Function setColor(ByVal color As Color)
        _color = color
        Return Nothing
    End Function

    Function getUpLeft() As GameSpace
        Return _adjUpLeft
    End Function
    Function setUpLeft(ByVal adjUpLeft As GameSpace)
        _adjUpLeft = adjUpLeft
        Return Nothing
    End Function

    Function getUpRight() As GameSpace
        Return _adjUpRight
    End Function
    Function setUpRight(ByVal adjUpRight As GameSpace)
        _adjUpRight = adjUpRight
        Return Nothing
    End Function

    Function getDownLeft() As GameSpace
        Return _adjDownLeft
    End Function
    Function setDownLeft(ByVal adjDownLeft As GameSpace)
        _adjDownLeft = adjDownLeft
        Return Nothing
    End Function

    Function getDownRight() As GameSpace
        Return _adjDownRight
    End Function
    Function setDownRight(ByVal adjDownRight As GameSpace)
        _adjDownRight = adjDownRight
        Return Nothing
    End Function
End Class
