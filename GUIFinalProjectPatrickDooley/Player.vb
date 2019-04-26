''' <summary>
''' Contains information about the player.
''' </summary>

Public Class Player
    Private _intNumber As Integer
    Private _strPlayerName As String
    Private _intPiecesTaken As Integer

    Sub New(ByVal intNumber As Integer, ByVal strPlayerName As String, ByVal intPiecesTaken As Integer)
        ' Constructor

        _intNumber = intNumber
        _strPlayerName = strPlayerName
        _intPiecesTaken = intPiecesTaken
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

    Function getPiecesTaken() As String
        Return _intPiecesTaken
    End Function
    Function setLocation(ByVal intPiecesTaken As Integer)
        _intPiecesTaken = intPiecesTaken
        Return Nothing
    End Function
End Class
