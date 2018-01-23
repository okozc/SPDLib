Public Class QrCode
    Inherits MyBarcodeItem

    Public Sub New(BcRect As Rectangle)
        MyBase.New(MyBarcodeType.Code128)
        Location = BcRect.Location
        Size = BcRect.Size
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            'ValidCharacters = Nothing

        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
