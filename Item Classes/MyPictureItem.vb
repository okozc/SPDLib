Imports System.ComponentModel

Public Class MyPictureItem
    Inherits MyItem

    Private iImage As Image
    Private iScale As Boolean
    Private iBorder As MyItemBorderStyle
    Private iBackColor As Color

    Public Property Image As Image
        Get
            Return iImage
        End Get
        Set(value As Image)
            iImage = value
        End Set
    End Property
    Public Property Scale As Boolean
        Get
            Return iScale
        End Get
        Set(value As Boolean)
            iScale = value
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
    Public Property BackColor As Color
        Get
            Return iBackColor
        End Get
        Set(value As Color)
            iBackColor = value
        End Set
    End Property

    Protected Friend Sub New(ItemID As String, ItemName As String, Scale As Boolean, Border As MyItemBorderStyle, BackColor As Color, Image As Image)
        MyBase.New(ItemName, ItemType.Picture, ItemID)
        iScale = Scale
        iBorder = Border
        iBackColor = BackColor
        iImage = Image
    End Sub
    Sub New()
        MyBase.New("", ItemType.Picture, Nothing)
        iScale = True
        iBorder = New MyItemBorderStyle(LineStyle.Solid, 1, Color.Black)
        iBackColor = Color.Transparent
    End Sub
    Sub New(PicRect As Rectangle)
        Me.New
        Location = PicRect.Location
        Size = PicRect.Size
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If Not IsNothing(iImage) Then iImage.Dispose()
            iImage = Nothing
            iScale = Nothing
            iBorder.Dispose()
            iBorder = Nothing
            iBackColor = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
