Public Class clsDirectory

    Public Function IniDirMedRecord() As String
        If HealthInformationSystem.My.MySettings.Default.IsDebug = True Then
            Return ""
        Else
            Return ""
        End If
    End Function

    Public Function AttDirMedRecord() As String
        If HealthInformationSystem.My.MySettings.Default.IsDebug = True Then
            If Environment.MachineName.ToString.ToString = "NBCP-DT-032" Then
                Return "B:\Users BACKUP\NBCP-DT-032\Desktop\Attachment\Medical Record"
            Else
                Return "B:\Users BACKUP\NBCP-LT-043\Desktop\Attachment\Medical Record"
            End If
        Else
            Return "\\192.168.20.11\Clinic\SystemFiles\Medical Record"
        End If
    End Function

    Public Function IniDirApeRecord() As String
        If HealthInformationSystem.My.MySettings.Default.IsDebug = True Then
            Return ""
        Else
            Return ""
        End If
    End Function

    Public Function AttDirApeRecord() As String
        If HealthInformationSystem.My.MySettings.Default.IsDebug = True Then
            If Environment.MachineName.ToString.ToString = "NBCP-DT-032" Then
                Return "B:\Users BACKUP\NBCP-DT-032\Desktop\Attachment\APE"
            Else
                Return "B:\Users BACKUP\NBCP-LT-043\Desktop\Attachment\APE"
            End If
        Else
            Return "\\192.168.20.11\Clinic\SystemFiles\APE"
        End If

    End Function

End Class
