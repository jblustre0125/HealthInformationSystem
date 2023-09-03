Imports System.Configuration

Namespace My

    'This class allows you to handle specific events on the settings class:
    ' The SettingChanging event is raised before a setting's value is changed.
    ' The PropertyChanged event is raised after a setting's value is changed.
    ' The SettingsLoaded event is raised after the setting values are loaded.
    ' The SettingsSaving event is raised before the setting values are saved.
    Partial Friend NotInheritable Class MySettings

        Private Sub MySettings_SettingsLoaded(sender As Object, e As SettingsLoadedEventArgs) Handles Me.SettingsLoaded
            If HealthInformationSystem.My.MySettings.Default.IsDebug = True Then
                If Environment.MachineName.ToString.Trim = "NBCP-DT-032" Then
                    Me.Item("HealthConnectionString") = "Data Source=NBCP-DT-032\SQLEXPRESS;Initial Catalog=LeaveFiling;Persist Security Info=True;User ID=sa;Password=Nbc12#"
                    Me.Item("JeonsoftConnectionString") = "Data Source=NBCP-DT-032\SQLEXPRESS;Initial Catalog=NBCTECHDB;Persist Security Info=True;User ID=sa;Password=Nbc12#"
                Else
                    Me.Item("HealthConnectionString") = "Data Source=NBCP-LT-043\SQLEXPRESS;Initial Catalog=LeaveFiling;Persist Security Info=True;User ID=sa;Password=Nbc12#"
                    Me.Item("JeonsoftConnectionString") = "Data Source=NBCP-LT-043\SQLEXPRESS;Initial Catalog=NBCTECHDB;Persist Security Info=True;User ID=sa;Password=Nbc12#"
                End If
            Else
                If CheckIfRunning("openvpn") Then
                    Me.Item("HealthConnectionString") = "Data Source=192.168.20.230;Initial Catalog=LeaveFiling;Persist Security Info=True;User ID=sa;Password=Nbc12#"
                    Me.Item("JeonsoftConnectionString") = "Data Source=192.168.20.230;Initial Catalog=NBCTECHDB;Persist Security Info=True;User ID=sa;Password=Nbc12#"
                Else
                    Me.Item("HealthConnectionString") = "Data Source=LENOVO-AX3RONG2;Initial Catalog=LeaveFiling;Persist Security Info=True;User ID=sa;Password=Nbc12#"
                    Me.Item("JeonsoftConnectionString") = "Data Source=LENOVO-AX3RONG2;Initial Catalog=NBCTECHDB;Persist Security Info=True;User ID=sa;Password=Nbc12#"
                End If
            End If
        End Sub

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

End Namespace
