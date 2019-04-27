''' <summary>
''' Contains information about the player.
''' </summary>

Public Class Player
    Private _intNumber As Integer
    Private _strPlayerName As String
    Private _intPiecesTaken As Integer
    Private _intPiecesRemaining As Integer

    Sub New(ByVal intNumber As Integer, ByVal strPlayerName As String, ByVal intPiecesTaken As Integer, ByVal intPiecesRemaining As Integer)
        ' Constructor

        _intNumber = intNumber
        _strPlayerName = strPlayerName
        _intPiecesTaken = intPiecesTaken
        _intPiecesRemaining = intPiecesRemaining
    End Sub

    'Gets and Sets
    Function getNumber() As Integer
        Return _intNumber
    End Function
    Function setPlayer(ByVal intNumber As Integer)
        _intNumber = intNumber
        Return Nothing
    End Function

    Function getName() As String
        Return _strPlayerName
    End Function
    Function setName(ByVal strPlayerName As String)
        _strPlayerName = strPlayerName
        Return Nothing
    End Function

    Function getPiecesTaken() As Integer
        Return _intPiecesTaken
    End Function
    Function setLocation(ByVal intPiecesTaken As Integer)
        _intPiecesTaken = intPiecesTaken
        Return Nothing
    End Function

    Function getPiecesRemaining() As Integer
        Return _intPiecesRemaining
    End Function
    Function setPiecesremaining(ByVal piecesRemaining)
        _intPiecesRemaining = piecesRemaining
        Return Nothing
    End Function
End Class
