﻿'   Title: Checkers!
'   Author: Patrick Dooley
'   Date: 4/23/2019
'   Purpose: A game of checkers for two players. Saves scores and allows users to save/load
'   a game.


Public Class StartScreen
    '   This form is the first one opened. It allows users to enter their names.
    '   The menu bar allows them to view isntructions or credits, and load a game.

    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        '   The play button validates the users input, and then opens the chekerboard form.

        Dim strErrorNotChar As String = "Please only enter letters."
        Dim strErrorBlank As String = "Names cannot be blank!"
        Dim strErrorTooManyChars As String = "Names can only be 10 characters or less."

        If txtPlayer1.Text = "" Or txtPlayer2.Text = "" Then
            MsgBox(strErrorBlank, , "Error")
        ElseIf Not Char.isLetter(txtPlayer1.Text) Or Not Char.IsLetter(txtPlayer2.Text) Then
            MsgBox(strErrorNotChar, , "Error")
        ElseIf txtPlayer1.Text.Length > 10 Or txtPlayer2.Text.Length > 10 Then
            MsgBox(strErrorTooManyChars, , "Error")
        End If
    End Sub

    Private Sub mnuLoad_Click(sender As Object, e As EventArgs) Handles mnuLoad.Click
        '   Allows user to select game to load, and then loads it.

    End Sub

    Private Sub mnuClear_Click(sender As Object, e As EventArgs) Handles mnuClear.Click
        '   Clears text boxes.

        txtPlayer1.Text = ""
        txtPlayer2.Text = ""
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        '   Exits application.

        Application.Exit()
    End Sub

    Private Sub mnuInstruct_Click(sender As Object, e As EventArgs) Handles mnuInstruct.Click
        '   Opens Instructions form.


    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        'Opens About form.


    End Sub

    Private Sub mnuLog_Click(sender As Object, e As EventArgs) Handles mnuLog.Click
        'Opens GameLog form.
    End Sub
End Class