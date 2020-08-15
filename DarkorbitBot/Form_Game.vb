﻿Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports AutoItX3Lib

Public Class Form_Game

    Dim AutoIt As New AutoItX3
    Dim X_TOP As Integer = 0
    Dim Y_TOP As Integer = 64
    Dim X_BOTTOM As Integer = 800
    Dim Y_BOTTOM As Integer = 618

    Private Sub FlatButton2_Click(sender As Object, e As EventArgs)
        'Try
        '    Dim A1 As Integer = (WebBrowser_Game_Ridevbot.Location.X)
        '    Dim A2 As Integer = (WebBrowser_Game_Ridevbot.Location.Y - 18)
        '    Dim A3 As Integer = (WebBrowser_Game_Ridevbot.Width)
        '    Dim A4 As Integer = (WebBrowser_Game_Ridevbot.Height)

        '    Dim result = AutoIt.PixelSearch(A1, A2, A3, A4, 13369344, 0, 1)


        '    Console.WriteLine(result)

        '    AutoIt.ControlClick("RidevBot", "", "[CLASS:MacromediaFlashPlayerActiveX; INSTANCE:1]", "left", 1, result(0) + 40, result(1) - 40)
        '    AutoIt.ControlSend("RidevBot", "", "[CLASS:MacromediaFlashPlayerActiveX; INSTANCE:1]", (1))
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub PictureBox_Close_Click(sender As Object, e As EventArgs) Handles PictureBox_Close.Click

        CloseForm.ShowDialog(Me)
        Form_Tools.Button_LaunchGameRidevBrowser.Text = "Open RidevBot Browser"
        Form_Tools.Button_LaunchGameRidevBrowser.Cursor = Cursors.Hand
        Shell("RunDll32.exe InetCpl.cpl,ClearMyTracksByProcess 8", vbHide)

    End Sub

    Private Sub WebBrowser_Game_Ridevbot_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser_Game_Ridevbot.DocumentCompleted

        Form_Tools.Button_LaunchGameRidevBrowser.Text = "Reload RidevBot Browser"

    End Sub

    Public found_palla As Boolean = False
    Private Sub Button_palladium_Click(sender As Object, e As EventArgs) Handles Button_palladium.Click

        Try

            If Not found_palla Then

                'Dim Palladium_1 = AutoIt.PixelSearch(X_TOP, Y_TOP, X_BOTTOM, Y_BOTTOM, 5073012, 2, 1)
                'Dim Palladium_2 = AutoIt.PixelSearch(X_TOP, Y_TOP, X_BOTTOM, Y_BOTTOM, 2771579, 2, 1)
                'Dim Palladium_3 = AutoIt.PixelSearch(X_TOP, Y_TOP, X_BOTTOM, Y_BOTTOM, 3695245, 2, 1)
                'Dim Palladium_4 = AutoIt.PixelSearch(X_TOP, Y_TOP, X_BOTTOM, Y_BOTTOM, 5664406, 2, 1)
                ''Console.WriteLine(Palladium_)
                ''Console.WriteLine(Palladium_(0))
                ''Console.WriteLine(Palladium_(1))
                'If Not Palladium_1(0).Equals(Nothing) Then
                '    GoToPalladium(Palladium_1)

                'ElseIf Not Palladium_2(0).Equals(Nothing) Then
                '    GoToPalladium(Palladium_2)

                'ElseIf Not Palladium_3(0).Equals(Nothing) Then
                '    GoToPalladium(Palladium_3)

                'ElseIf Not Palladium_4(0).Equals(Nothing) Then
                '    GoToPalladium(Palladium_4)

                'End If
                'Dim largeur As Integer = Screen.PrimaryScreen.Bounds.Width
                'Dim hauteur As Integer = Screen.PrimaryScreen.Bounds.Height

                'Dim screenshot As New Bitmap(largeur, hauteur)
                'Dim graph As Graphics = Graphics.FromImage(screenshot)

                Dim B = New Bitmap(WebBrowser_Game_Ridevbot.ClientSize.Width, WebBrowser_Game_Ridevbot.ClientSize.Height)
                Dim G As Graphics = Graphics.FromImage(B)
                G.CopyFromScreen(PointToScreen(WebBrowser_Game_Ridevbot.Location), New Point(0, 0), WebBrowser_Game_Ridevbot.ClientSize)
                'The bitmap Is ready. Do whatever you please with it!
                B.Save($"screenshot.jpg", ImageFormat.Jpeg)
                'MessageBox.Show("Screen Shot Saved!")

                'graph.CopyFromScreen(0, 64, 800, 618, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy)


                Dim dest_heal = My.Resources.heal
                Dim dest_bouclier = My.Resources.bouclier
                Dim dest_mission = My.Resources.mission
                Dim dest_map = My.Resources.map
                'screenshot.Save(IO.Path.Combine("test.bmp"))


                Dim pt_heal1 As Point = B.Contains(dest_heal)
                If pt_heal1 <> Nothing Then
                    '... image found at pt
                    MsgBox($"found heal at {pt_heal1.X}-{pt_heal1.Y}")
                    Cursor.Position = New Point(pt_heal1.X, pt_heal1.Y + 18)
                End If


                Dim pt_bouclier As Point = B.Contains(dest_bouclier)
                If pt_bouclier <> Nothing Then
                    '... image found at pt
                    MsgBox($"found logout at {pt_bouclier.X}-{pt_bouclier.Y}")
                    Cursor.Position = New Point(pt_bouclier.X, pt_bouclier.Y + 18)
                End If


                Dim pt_mission1 As Point = B.Contains(dest_mission)
                If pt_mission1 <> Nothing Then
                    '... image found at pt
                    MsgBox($"found mission at {pt_mission1.X}-{pt_mission1.Y}")
                    Cursor.Position = New Point(pt_mission1.X, pt_mission1.Y + 18)
                End If

                Dim pt_map As Point = B.Contains(dest_map)
                If pt_map <> Nothing Then
                    '... image found at pt
                    MsgBox($"found map at {pt_map.X}-{pt_map.Y}")
                    Cursor.Position = New Point(pt_map.X, pt_map.Y + 18)

                End If

            End If

        Catch Palladium_not_found As Exception
            'Console.WriteLine("[Form_Game] Can't find a palladium")
        End Try

    End Sub

    Private Async Sub GoToPalladium(palla)
        found_palla = True
        AutoIt.ControlClick("RidevBot", "", "[CLASS:MacromediaFlashPlayerActiveX; INSTANCE:1]", "left", 1, palla(0), palla(1))

        Dim temps = Task.Delay(Form_Tools.TextBox_palladium_ms.Text)
        Await temps
        found_palla = False
    End Sub

    Private Sub Button_bonusbox_Click(sender As Object, e As EventArgs) Handles Button_bonusbox.Click

        Dim Bonus_Box = AutoIt.PixelSearch(X_TOP, Y_TOP, X_BOTTOM, Y_BOTTOM, 1321834, 5, 1)

        Try
            AutoIt.ControlClick("RidevBot", "", "[CLASS:MacromediaFlashPlayerActiveX; INSTANCE:1]", "left", 1, Bonus_Box(0) - 0, Bonus_Box(1) - 0)
            '  Me.Invoke(New MethodInvoker(Sub() System.Threading.Thread.Sleep(Form_Tools.TextBox_cargobox_ms.Text)))

        Catch Bonus_Box_not_found As Exception
        End Try

    End Sub

    Private Sub Button_cargobox_Click(sender As Object, e As EventArgs) Handles Button_cargobox.Click

        Dim Cargo_Box = AutoIt.PixelSearch(X_TOP, Y_TOP, X_BOTTOM, Y_BOTTOM, 16777030, 5, 1)

        Try
            AutoIt.ControlClick("RidevBot", "", "[CLASS:MacromediaFlashPlayerActiveX; INSTANCE:1]", "left", 1, Cargo_Box(0) - 0, Cargo_Box(1) - 0)
            '   Me.Invoke(New MethodInvoker(Sub() System.Threading.Thread.Sleep(Form_Tools.TextBox_bonusbox_ms.Text)))

        Catch Cargo_Box_not_found As Exception
        End Try

    End Sub

End Class