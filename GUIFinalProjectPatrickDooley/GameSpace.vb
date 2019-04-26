''' <summary>
''' This class contains information about the spaces on the board.
''' </summary>

Public Class GameSpace

    Private _strName As String
    Private _strX As String
    Private _intY As Integer
    Private _picBox As PictureBox
    Private _piece As GamePiece

    Sub New(ByVal strName As String, ByVal strX As String, ByVal intY As Integer, ByVal picBox As PictureBox, ByVal piece As GamePiece)
        ' Constructor
        _strName = strName
        _strX = strX
        _intY = intY
        _picBox = picBox
        _piece = piece
    End Sub

    'Gets and sets
    Function getName() As String
        Return _strName
    End Function
    Function setName(ByVal strName As String)
        _strName = strName
        Return Nothing
    End Function

    Function getX() As String
        Return _strX
    End Function
    Function setX(ByVal strX As String)
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
End Class
