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
            Return "B:\Users BACKUP\NBCP-LT-058\Desktop\Health Information System\Imgs\Medical Record"
        Else
            Return "\\192.168.20.11\GA\00---CLINIC\Imgs\Medical Record"
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
            Return "B:\Users BACKUP\NBCP-LT-058\Desktop\Health Information System\Imgs\APE"
        Else
            Return "\\192.168.20.11\GA\00---CLINIC\Imgs\APE"
        End If
    End Function

End Class
