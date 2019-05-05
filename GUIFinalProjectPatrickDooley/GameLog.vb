''' <summary>
''' This form shows a log of the last 10 games played.
''' </summary>

Public Class GameLog
    Private Sub GameLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   When the form is loaded, the app checks if GameLog.csv exists and 
        '   loads the data from it to display.

        Dim fileLocation As String = System.IO.Path.Combine(Application.StartupPath, "GameLog.csv")
        Dim iterate As Integer = 1
        Dim line As String
        Dim splitLine As String()
        Try
            Dim objReader As New System.IO.StreamReader(fileLocation)
            Do While objReader.Peek <> -1
                line = objReader.ReadLine()
                splitLine = line.Split(New Char() {","c})

                Select Case splitLine(0)
                    Case "p1Win"
                        lstLog.Items.Add(iterate.ToString() & ". " & splitLine(1) & " captured all of " & splitLine(2) & "'s pieces!")
                    Case "p2Win"
                        lstLog.Items.Add(iterate.ToString() & ". " & splitLine(2) & " captured all of " & splitLine(1) & "'s pieces!")
                    Case "p1WinStall"
                        lstLog.Items.Add(iterate.ToString() & ". " & splitLine(1) & " stalled out " & splitLine(2) & "!")
                    Case "p2WinStall"
                        lstLog.Items.Add(iterate.ToString() & ". " & splitLine(2) & " stalled out " & splitLine(1) & "!")
                    Case "draw"
                        lstLog.Items.Add(iterate.ToString() & ". " & splitLine(1) & " and " & splitLine(2) & " had a draw!")
                End Select
                iterate += 1
            Loop
            objReader.Close()

        Catch ex As Exception
            lstLog.Items.Add("Something went wrong loading the game log!")
            lstLog.Items.Add("If data in log was modified, delete GameLog.csv.")
        End Try
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Close()
    End Sub
End Class