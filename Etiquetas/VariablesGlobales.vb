Module VariablesGlobales
    Public TipLabel As Integer = 0
    Public Function ObtenerIP() As String
        Dim nombreHost As String = System.Net.Dns.GetHostName
        Dim hostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(My.Computer.Name)
        'MsgBox("El nombre de tu maquina es: " & hostInfo.HostName.ToString)
        'For Each ip As System.Net.IPAddress In hostInfo.AddressList
        ' Para windows Xp
        Return hostInfo.AddressList(0).ToString
        'Para windows 7
        'Return hostInfo.AddressList(2).ToString
        'Next
    End Function
End Module
