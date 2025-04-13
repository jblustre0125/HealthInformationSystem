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
            Return "B:\Users BACKUP\NBCP-LT-144\Desktop\Attachment\Medical Record"
        Else
            Return "\\192.168.20.230\HIS_Attachment\Medical Record"
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
            Return "B:\Users BACKUP\NBCP-LT-144\Desktop\Attachment\APE"
        Else
            Return "\\192.168.20.230\HIS_Attachment\APE"
        End If
    End Function

End Class
