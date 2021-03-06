﻿Imports System.ComponentModel
Imports System.IO
Imports System.Net
'Imports AxMediaPlayer

Public Class AutoUpdater
    Public StartupPath As String = Application.StartupPath
    Public FileToUpdate As String = StartupPath + "\RidevBot.exe"
    Public FileUpdater As String = StartupPath + "\RidevBot_Updater.exe"

    'Update
    Private WC As New WebClient
    Private WC_Update_Version As New WebClient
    Private WC_Update_ChangeLog As New WebClient
    Private WC_Check_Maintenance As New WebClient
    Private WC_Download_AutoIt As New WebClient
    Private WC_Firebase_Secret As New WebClient

    Public LastVersion As String '= WC.DownloadString("")
    Public LastChangeLog As String
    Public Check_Maintenance As Boolean

    Public Shared A
    Public Shared B


    Private Sub AutoUpdater_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.Size = New Size(363, 264)

        'For Each f In Directory.GetFiles(Application.StartupPath, "*.exe")
        '    'Console.WriteLine(f)
        '    If Not f.Contains("RidevBot.exe") Then
        '        'Console.WriteLine($"Deleted-{f}")
        '        Try
        '            File.Delete(f)
        '        Catch ex As Exception
        '            Console.WriteLine($"Seems that i can't delete the file {f}")
        '        End Try
        '    End If
        'Next

        Timer_bar_cancel_auto_login.Start()

        FlatLabel_Version.Text = "Version : " + Application.ProductVersion
        FlatLabel_isUpdated.Select()

        'Console.WriteLine(My.Computer.Registry.LocalMachine)
        Dim Everest_Registry As Microsoft.Win32.RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\WOW6432Node\AutoIt v3\AutoIt")
        'MessageBox.Show(Everest_Registry.GetValue("InstallDir"))
        If Everest_Registry Is Nothing Then
            'key does not exist
            'MsgBox("Key does Not exist")
            MessageBox.Show($"It seems that you don't have our dependancies, we will now download them, and install them.{vbNewLine}{vbNewLine}If a popup is shown, click ""Yes"" in order to use the bot", "RidevBot", MessageBoxButtons.OK, MessageBoxIcon.Error)

            AddHandler WC_Download_AutoIt.DownloadFileCompleted, AddressOf WC_Download_AutoIt_DownloadFileAsyncCompleted
            WC_Download_AutoIt.DownloadFileAsync(New Uri("https://www.dropbox.com/s/5cll7ewkdlhi7n5/autoit-v3-setup.exe?raw=1"), Path.Combine(Path.GetTempPath, "autoit-setup.exe"))
            FlatTextBox_Changelog.Text = $"Downloading the dependancies...{vbNewLine}Please wait..."

            ProgressBar_cancel_autotlogin.Value = "100"
            ProgressBar_cancel_autotlogin.ForeColor = Color.Red

        Else

            AddHandler WC_Check_Maintenance.DownloadStringCompleted, AddressOf WC_Check_Maintenance_DownloadStringCompleted
            WC_Check_Maintenance.DownloadStringAsync(New Uri("https://www.dropbox.com/s/povcf3bfxjxy8ir/Maintenance.txt?dl=1"))
            '---
            AddHandler WC_Update_Version.DownloadStringCompleted, AddressOf WC_Update_Version_DownloadStringCompleted
            WC_Update_Version.DownloadStringAsync(New Uri("https://www.dropbox.com/s/5ergvrkppscoupo/Version.txt?dl=1"))
            '---
            AddHandler WC_Update_ChangeLog.DownloadStringCompleted, AddressOf WC_Update_ChangeLog_DownloadStringCompleted
            WC_Update_ChangeLog.DownloadStringAsync(New Uri("https://www.dropbox.com/s/q8wlkhxshwbnajo/Changelog.txt?dl=1"))
            '---
            'AddHandler WC_Firebase_Secret.DownloadStringCompleted, AddressOf WC_Firebase_Secret_DownloadStringCompleted
            'WC_Firebase_Secret.DownloadStringAsync(New Uri("https://www.dropbox.com/s/9yhkt6o33my54d0/Firebase_secret.txt?dl=1"))

            'Video_ridevbot_MediaPlayerAx.URL = FilePath
            'Video_ridevbot_MediaPlayerAx.Ctlcontrols.play()
            'Await Task.Delay(265)
            'Video_ridevbot_MediaPlayerAx.Visible = True

            'Await Task.Delay(2200)
            'Video_ridevbot_MediaPlayerAx.Ctlcontrols.pause()
            'key is valid, display actual name
            'MsgBox(Everest_Registry.Name)
            'Console.WriteLine(Everest_Registry.Name)
            'Console.WriteLine(Everest_Registry.SubKeyCount)
            'Console.WriteLine(Everest_Registry.GetValue("Version"))
        End If

    End Sub
    Public Shared Function Hashing()

        Dim Number_Hash As Integer
        Dim Number_Past As Integer
        Dim Number_secure As Integer
        Dim Number_clone As Integer
        Dim Number_front_end As Integer
        Dim Number_Key_front As Integer

        Dim N1 As Integer
        Dim randomN1 As New Random
        Dim N2 As Integer
        Dim randomN2 As New Random
        Dim N3 As Integer
        Dim randomN3 As New Random
        Dim N4 As Integer
        Dim randomN4 As New Random
        Dim N5 As Integer
        Dim randomN5 As New Random
        Dim N6 As Integer
        Dim randomN6 As New Random

        Dim alphabet As String = "abcdefghijklmnopqrstuvwxyz"

        Number_Hash = CInt(Int((0 * Rnd()) + 3))
        Number_Past = CInt(Int((3 * Rnd()) + 6))
        Number_secure = CInt(Int((6 * Rnd()) + 9))
        Number_clone = CInt(Int((0 * Rnd()) + 9))
        Number_front_end = CInt(Int((3 * Rnd()) + 6))
        Number_Key_front = CInt(Int((0 * Rnd()) + 3))


        N1 = randomN1.Next(0, 11)
        N2 = randomN2.Next(11, 25)
        N3 = randomN3.Next(0, 20)
        N4 = randomN4.Next(20, 25)
        N5 = randomN5.Next(0, 7)
        N6 = randomN6.Next(7, 25)

        A = (Number_Hash.ToString + alphabet.Substring(N1, 1).ToString + Number_Past.ToString + alphabet.Substring(N2, 1).ToString + Number_secure.ToString + alphabet.Substring(N3, 1).ToString)
        Console.WriteLine(A)
        B = (alphabet.Substring(N3, 1).ToString + Number_Hash.ToString + alphabet.Substring(N4, 1).ToString)
        Console.WriteLine(B)

        'past key

    End Function
    Private Async Sub WC_Download_AutoIt_DownloadFileAsyncCompleted(sender As Object, e As AsyncCompletedEventArgs)
        Dim CheckPassed As Integer = 0
        Try
            If e.Cancelled Then
                MessageBox.Show("An error occured or you cancelled the download. Aborting")
                Close()
            End If
            CheckPassed = 1
            'MessageBox.Show(e.GetType.ToString)

            'Dim installation = Shell(Path.Combine(Path.GetTempPath, "autoit-setup.exe /S"), AppWinStyle.NormalFocus, True, 1500)
            MessageBox.Show($"An installation package will be opened{vbNewLine}{vbNewLine}" +
                            $"PLEASE DO 'NEXT' EVERYWHERE, WE NEED THE DEFAULT PARAMETERS{vbNewLine}" +
                            $"If you don't do that, the bot won't work correctly !{vbNewLine}" +
                            $"Please press 'Yes' to install our dependancies", "RidevBot Installation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Process.Start(Path.Combine(Path.GetTempPath, "autoit-setup.exe"), "")
            FlatTextBox_Changelog.Text = $"Installing the dependancies...{vbNewLine}Please wait..."
            CheckPassed = 2

            Dim p() As Process
            p = Process.GetProcessesByName("autoit-setup.exe")
            Do Until p.Count = 0
                ' Process is running
                Await Task.Delay(500)
                p = Process.GetProcessesByName("autoit-setup.exe")
            Loop
            FlatTextBox_Changelog.Text = $"Done. Restarting..."
            CheckPassed = 3

            ' Process is not running
            Application.Restart()

        Catch ex As Exception
            MessageBox.Show($"Can't retrieve the bot dependancies.{vbNewLine}" +
                            $"Error: {ex.Message}|CP:{CheckPassed}{vbNewLine}" +
                            $"Aborting...", Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Sub

    Private Sub WC_Check_Maintenance_DownloadStringCompleted(sender As Object, e As DownloadStringCompletedEventArgs)
        Try
            Check_Maintenance = e.Result
            If Check_Maintenance Then
                MessageBox.Show($"A maintenance Is actually underway...{vbNewLine}" +
                            $"Please, try again later.{vbNewLine}" +
                            $"If the problem persist, contact our support at : https://discord.gg/GFzfcGR", "Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Close()
            Else
                Try
                    Form_Tools.Label_BotStatus.Text = "Online"
                    Form_Tools.Label_BotStatus.ForeColor = Color.LimeGreen
                Catch ex As Exception

                End Try
            End If
            FlatLabel_isUpdated.Select()
        Catch ex As Exception
            If File.Exists(Path.Combine(Application.StartupPath, "debug.ridevbot")) = True Then
                MessageBox.Show($"Can't retrieve the Maintenance information.{vbNewLine}" +
                            $"Aborting...{vbNewLine}" +
                            $"Error:{ex.Message}", Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show($"Can't retrieve the Maintenance information.{vbNewLine}" +
                            $"Aborting...", Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            End
        End Try

    End Sub

    Private Sub Update_Dialog()
        'Dans le cas où le programme n'est pas à jour
        'Timer_ChangeLog_Check.Stop()
        If Not File.Exists(FileUpdater) Then
            File.WriteAllBytes(FileUpdater, My.Resources.RidevBotUpdater)
        End If


        ProgressBar_cancel_autotlogin.Value = "100"
        ProgressBar_cancel_autotlogin.ForeColor = Color.DarkRed
        Dim result = MessageBox.Show("A new update is available (" & LastVersion & ")" & vbNewLine & vbNewLine & LastChangeLog & vbNewLine & vbNewLine & "-----------------------------------------------------------------" & vbNewLine & "The bot will now update.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        If result = DialogResult.OK Then
            Process.Start(FileUpdater)
            Close()
        Else
            Process.Start(FileUpdater)
            Close()
        End If
    End Sub

    Private Sub Button_Update_Click(sender As Object, e As EventArgs) Handles Button_Update.Click

        ' Verify if an update is available

        If Application.ProductVersion <> LastVersion Then
            Update_Dialog()
        Else
            If File.Exists(FileUpdater) Then
                File.Delete(FileUpdater)
            End If
            Form_Startup.Show()
            ' ConnectionForm.Show()

            Close()
        End If
        'Hide()
    End Sub

    Private Sub WC_Update_Version_DownloadStringCompleted(sender As Object, e As DownloadStringCompletedEventArgs)
        'MsgBox(e.Result)
        Try
            LastVersion = e.Result
            If Application.ProductVersion <> LastVersion Then
                'different
                FlatLabel_isUpdated.Text = "You are not up to date"
                FlatLabel_isUpdated.ForeColor = Color.DarkOrange
                FlatLabel_isUpdated.Visible = True
            Else
                FlatLabel_isUpdated.Visible = True
            End If
            FlatLabel_isUpdated.Select()
            'Button_Update.Enabled = True
        Catch ex As Exception
            If File.Exists(Path.Combine(Application.StartupPath, "debug.ridevbot")) = True Then
                MessageBox.Show($"Can't retrieve the program version.{vbNewLine}Aborting...{vbNewLine}Error:{ex.Message}", Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show($"Can't retrieve the program version.{vbNewLine}Aborting...", Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            End
        End Try

        'Throw New NotImplementedException()
    End Sub

    Private Async Sub WC_Update_ChangeLog_DownloadStringCompleted(sender As Object, e As DownloadStringCompletedEventArgs)
        'MsgBox(e.Result)
        Try
            LastChangeLog = e.Result
            FlatTextBox_Changelog.Text = e.Result
            FlatLabel_isUpdated.Select()
            Button_Update.Visible = True
            Button_Update.Enabled = True
            Form_Tools.TextBox_Changelog.Text = e.Result

            'AxWindowsMediaPlayer1.URL = FilePath
            'AxWindowsMediaPlayer1.Ctlcontrols.play()
            'Await Task.Delay(265)
            'AxWindowsMediaPlayer1.Visible = True

            'Await Task.Delay(2200)

            'AxWindowsMediaPlayer1.Ctlcontrols.pause()

            If Check_Maintenance = False And My.Settings.AutoUpdate = True Then
                Dim delay = Task.Delay(500)
                Await delay
                'Permet d'attendre 500 ms en + (secure)
                Button_Update.PerformClick()
            Else
                Close()
            End If

        Catch ex As Exception
            If File.Exists(Path.Combine(Application.StartupPath, "debug.ridevbot")) = True Then
                MessageBox.Show($"Can't retrieve the Changelog.{vbNewLine}Aborting...{vbNewLine}Error:{ex.Message}", Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show($"Can't retrieve the Changelog.{vbNewLine}Aborting...", Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Close()
        End Try
    End Sub

    Private Sub WC_Firebase_Secret_DownloadStringCompleted(sender As Object, e As DownloadStringCompletedEventArgs)
        'MsgBox(e.Result)
        Try
            Utils.Firebase_Secret = e.Result

        Catch ex As Exception
            MessageBox.Show($"Can't retrieve, error-69.{vbNewLine}Aborting...", Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub
    Private Sub Timer_bar_cancel_auto_login_Tick(sender As Object, e As EventArgs) Handles Timer_bar_cancel_auto_login.Tick

        If ProgressBar_cancel_autotlogin.Value = 100 Then
        Else ProgressBar_cancel_autotlogin.Value = ProgressBar_cancel_autotlogin.Value + 1
        End If

    End Sub

    Private Sub Button_cancel_auto_login_Click(sender As Object, e As EventArgs) Handles Button_cancel_auto_login.Click

        Form_Tools.CheckBox_AutoLogin.Checked = False
        Timer_bar_cancel_auto_login.Stop()
        Button_cancel_auto_login.Text = "Canceled.  Wait..."

    End Sub
End Class