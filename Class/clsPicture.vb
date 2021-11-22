Public Class clsPicture
    Public FileName As String
    Public SafeName As String
    Public AttachmentId As Integer

    Public Sub New(_fileName As String, _safeName As String, Optional _attachmentId As Integer = 0)
        FileName = _fileName
        SafeName = _safeName
        AttachmentId = _attachmentId
    End Sub

End Class
