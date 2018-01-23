Imports System.ComponentModel
Public MustInherit Class MyBarcodeItem
    Inherits MyItem

    Enum MyBarcodeType
        Code39
        Code39Extended
        Code128
        GS1_128
        QrCode
        DataMatrix
    End Enum

    Private iBarcodeType As MyBarcodeType
    Private iValue As String
    Private iEncodedValue As String
    Private iShowLabel As Boolean
    Private iLabelFont As Font
    Private iFontColor As Color
    Private iFillColor As Color
    Private iBorder As MyItemBorderStyle

    Public ReadOnly Property BarcodeType As MyBarcodeType
        Get
            Return iBarcodeType
        End Get
    End Property
    Public Overridable Property Value As String
        Get
            Return iValue
        End Get
        Set(value As String)
            iValue = value
        End Set
    End Property
    Public Overridable ReadOnly Property EncodedValue As String
        Get
            Return iEncodedValue
        End Get
    End Property
    Protected WriteOnly Property SetEncodedValue As String
        Set(value As String)
            iEncodedValue = value
        End Set
    End Property
    Public Property HumanReadable As Boolean
        Get
            Return iShowLabel
        End Get
        Set(value As Boolean)
            iShowLabel = value
        End Set
    End Property
    Public Property TextFont As Font
        Get
            Return iLabelFont
        End Get
        Set(value As Font)
            iLabelFont = value
        End Set
    End Property
    Public Property TextColor As Color
        Get
            Return iFontColor
        End Get
        Set(value As Color)
            iFontColor = value
        End Set
    End Property
    Public Property BackColor As Color
        Get
            Return iFillColor
        End Get
        Set(value As Color)
            iFillColor = value
        End Set
    End Property
    <Category("Border"), Description(""), Browsable(True)> Public Property Border As MyItemBorderStyle
        Get
            Return iBorder
        End Get
        Set(value As MyItemBorderStyle)
            iBorder = value
        End Set
    End Property
    Sub New(BarcodeType As MyBarcodeType)
        MyBase.New("Barcode", ItemType.Barcode, Nothing)
        iValue = "0"
        iBarcodeType = BarcodeType
        iShowLabel = True
        iLabelFont = New Font("Arial", 11)
        iFontColor = Color.Black
        iFillColor = Color.Transparent
        iBorder = New MyItemBorderStyle(LineStyle.None, 1, Color.Black)
    End Sub
    Sub New(BarcodeRect As Rectangle, BarcodeType As MyBarcodeType)
        Me.New(BarcodeType)
        Location = BarcodeRect.Location
        Size = BarcodeRect.Size
    End Sub



    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            iBarcodeType = Nothing
            iValue = Nothing
            iEncodedValue = Nothing
            iShowLabel = Nothing
            iLabelFont.Dispose()
            iLabelFont = Nothing
            iFontColor = Nothing
            iFillColor = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
