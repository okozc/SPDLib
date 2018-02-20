Public Class MyDataField
    Inherits MyField

    Sub New(ColumnName As String, FriendlyName As String)
        MyBase.New(ColumnName, "", MyValueType.Text, MyFieldType.DataField)
        MyBase.FriendlyName = FriendlyName
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
