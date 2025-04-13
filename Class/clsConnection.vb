Public Class clsConnection

    Public Function MyConnection() As String
        If HealthInformationSystem.My.MySettings.Default.IsDebug = True Then
            Return "Data Source=NBCP-LT-144\SQLEXPRESS;Initial Catalog=LeaveFiling;Persist Security Info=True;User ID=sa;Password=Nbc12#"
        Else
            If CheckIfRunning("openvpn") = True Then
                Return "Data Source=192.168.20.230;Initial Catalog=LeaveFiling;Persist Security Info=True;User ID=sa;Password=Nbc12#"
            Else
                Return "Data Source=LENOVO-AX3RONG2;Initial Catalog=LeaveFiling;Persist Security Info=True;User ID=sa;Password=Nbc12#"
            End If
        End If
    End Function

    Public Function JeonsoftConnection() As String
        If HealthInformationSystem.My.MySettings.Default.IsDebug = True Then
            Return "Data Source=NBCP-LT-144\SQLEXPRESS;Initial Catalog=NBCTECHDB;Persist Security Info=True;User ID=sa;Password=Nbc12#"
        Else
            If CheckIfRunning("openvpn") = True Then
                Return "Data Source=L192.168.20.230;Initial Catalog=NBCTECHDB;Persist Security Info=True;User ID=sa;Password=Nbc12#"
            Else
                Return "Data Source=LENOVO-AX3RONG2;Initial Catalog=NBCTECHDB;Persist Security Info=True;User ID=sa;Password=Nbc12#"
            End If
        End If
    End Function

    Private Function CheckIfRunning(procName As String) As Boolean
        Dim isRunning As Boolean = False

        For Each prc As Process In Process.GetProcessesByName(procName)
            If prc.ProcessName.Contains(procName) Then
                isRunning = True
            Else
                isRunning = False
            End If
        Next

        Return isRunning
    End Function


End Class
