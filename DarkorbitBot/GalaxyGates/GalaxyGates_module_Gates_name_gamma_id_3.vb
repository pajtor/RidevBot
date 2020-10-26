﻿Imports System.Net
Imports System.Text.RegularExpressions

Public Class GalaxyGates_module_Gates_name_gamma_id_3

    Public Shared WebClient_POST_3 As New System.Net.WebClient
    Public Shared Table_Load_3 As String = """.*) \/>"
    Public Shared Verification_3 As String = 0
    Public Shared Npc_current_3 As String

    Public Shared Function Load(ByVal Verification)

        If Verification_3 = 1 Then
            WebClient_POST_3.Headers.Add(HttpRequestHeader.Cookie, $"dosid={Utils.dosid};") 'POST / GET socket Information
            Dim WebClient_Data = WebClient_POST_3.DownloadString("https://" + Utils.server + ".darkorbit.com/flashinput/galaxyGates.php?userID=" + Utils.userid + "&action=init&sid=" + Utils.dosid)
            Dim WebClient_GET_All_elements_Gamma = Regex.Match(WebClient_Data, "<gate (.*id=""2" + Table_Load_3).Groups.Item(1).ToString 'G
            Console.WriteLine(WebClient_GET_All_elements_Gamma)

            If WebClient_GET_All_elements_Gamma.Contains("prepared=""1""") Then
                If Stats_module.WebClient_GET_Ship_compagny_reg = Nothing Then
                    Stats_module.Load()

                End If

                If Stats_module.WebClient_GET_Ship_compagny_reg = "mmo" Then
                    Form_Tools.ComboBox_map_to_travel.Text = "1-1"

                ElseIf Stats_module.WebClient_GET_Ship_compagny_reg = "eic" Then
                    Form_Tools.ComboBox_map_to_travel.Text = "2-1"

                ElseIf Stats_module.WebClient_GET_Ship_compagny_reg = "vru" Then
                    Form_Tools.ComboBox_map_to_travel.Text = "3-1"

                End If
            Else
                Console.WriteLine("No Gates avaibled")
                Exit Function
            End If

            Traveling_module.Load()
            Exit Function

        Else

            ' TROUVER LA POSITION DU PORTAIL MMO VRU ET EIC 
            ' RETURN TRAVELING
            ' POSITIF GG => " Verification =0 "

        End If
    End Function

    Public Shared Function Search_current_waves()

        WebClient_POST_3.Headers.Add(HttpRequestHeader.Cookie, $"dosid={Utils.dosid};") 'POST / GET socket Information
        Dim WebClient_Data = WebClient_POST_3.DownloadString("https://" + Utils.server + ".darkorbit.com/flashinput/galaxyGates.php?userID=" + Utils.userid + "&action=init&sid=" + Utils.dosid)
        Dim WebClient_GET_All_elements_Gamma = Regex.Match(WebClient_Data, "<gate (.*id=""2" + Table_Load_3).Groups.Item(1).ToString 'G
        Console.WriteLine(WebClient_GET_All_elements_Gamma)

        Dim WebClient_GET_All_elements_currentWave = Regex.Match(WebClient_GET_All_elements_Gamma, "currentWave="".*?([\s\S]*?)""").Groups.Item(1).ToString

        If WebClient_GET_All_elements_currentWave = "0" Or "1" Or "2" Or "3" Or "4" Then
            Npc_current_3 = "streuner"

        ElseIf WebClient_GET_All_elements_currentWave = "5" Or "6" Or "7" Or "8" Then
            Npc_current_3 = "lordakia"

        ElseIf WebClient_GET_All_elements_currentWave = "9" Or "10" Or "11" Or "12" Then
            Npc_current_3 = "mordon"

        ElseIf WebClient_GET_All_elements_currentWave = "13" Or "14" Or "15" Or "16" Then
            Npc_current_3 = "saimon"

        ElseIf WebClient_GET_All_elements_currentWave = "17" Or "18" Or "19" Or "20" Then
            Npc_current_3 = "devolarium"

        ElseIf WebClient_GET_All_elements_currentWave = "21" Or "22" Or "23" Or "24" Then
            Npc_current_3 = "kristallin"

        ElseIf WebClient_GET_All_elements_currentWave = "25" Or "26" Or "27" Or "28" Then
            Npc_current_3 = "sibelon"

        ElseIf WebClient_GET_All_elements_currentWave = "29" Or "30" Or "31" Or "32" Then
            Npc_current_3 = "sibelonit"

        ElseIf WebClient_GET_All_elements_currentWave = "33" Or "34" Or "35" Or "36" Then
            Npc_current_3 = "kristallon"

        ElseIf WebClient_GET_All_elements_currentWave = "37" Or "38" Or "39" Or "40" Then
            Npc_current_3 = "protegit"
        End If

    End Function

    Public Shared Function Progress_Gates()

    End Function

End Class