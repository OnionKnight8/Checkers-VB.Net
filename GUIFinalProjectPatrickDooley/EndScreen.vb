''' <summary>
''' This is the form that displays the winner (or lack of one). It allows
''' the players to request a rematch.
''' </summary>

Public Class EndScreen
    Private _winCondition As String

    Sub New(ByVal winCondition As String)
        InitializeComponent()
        _winCondition = winCondition
    End Sub

    Private Sub EndScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class