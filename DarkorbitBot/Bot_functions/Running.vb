﻿Public Class Running

    Public Shared Async Sub Start()

        If Var.security = 1 Then
            Var.security = 0 ' minimap configuration
            Console.WriteLine("redirection effectué /set")
            GoTo Minimap_backup
        End If

        If Var.security_traveling = 1 Then
            Var.security_traveling = 0
            Console.WriteLine("redirection Traveling effectué /set")
            GoTo Retour_error_map_traveling
        End If

        If Var.security_T_backup = 1 Then
            Var.security_T_backup = 1 = 0
            Console.WriteLine("redirection Traveling success effectué /set")
            GoTo Backup_traveling_success
        End If


        If Var.User_Stop_Bot Then
            Console.WriteLine("Stooped")

        Else Console.WriteLine("Started")
            Form_Game.WebBrowser_Game_Ridevbot.Select()
        End If

Recharge_functions:

        If Var.User_Stop_Bot Then Exit Sub
        Await Dead.Load

        If Var.User_Stop_Bot Then Exit Sub
        Await Reconnect.Load

        If Var.User_Stop_Bot Then Exit Sub
        Await Dependency.Load

Retour_error_map_traveling:
        If Var.User_Stop_Bot Then Exit Sub
        Minimap_configuration.Load()
        Exit Sub
Minimap_backup:
        Console.WriteLine("redirection effectué get/set")

        If Var.User_Stop_Bot Then Exit Sub
        Await Checking_map.Load
        Console.WriteLine("Map Loaded")

        If Var.User_Stop_Bot Then Exit Sub
        Traveling_module.Load()
        Exit Sub
Backup_traveling_success:

        If Var.User_Stop_Bot Then Exit Sub
        Await Pet_module.Post_function

        GoTo Recharge_functions


    End Sub

End Class
