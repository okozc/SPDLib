Public Class Code128
    Inherits MyBarcodeItem

    Private ValidCharacters(127) As Char

    Public Sub New(BcRect As Rectangle)
        MyBase.New(MyBarcodeType.Code128)
        Location = BcRect.Location
        Size = BcRect.Size
        For i = 0 To 127
            ValidCharacters(i) = Chr(i)
        Next
    End Sub

    Public Function ValueIsValid(Value As String) As Boolean
        Dim result As Boolean = True
        If Not String.IsNullOrEmpty(Value) Then
            For index As Integer = 0 To Value.Length - 1
                If ValidCharacters.Contains(Convert.ToChar(Value.Substring(index, 1))) Then
                    result = True
                Else
                    Return False
                End If
            Next
        Else
            Return False
        End If
        Return result
    End Function

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            ValidCharacters = Nothing

        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
