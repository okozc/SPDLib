﻿Public Class MyElypseItem
    Inherits MyItem

    Private iFillColor As Color
    Private iBackColor As Color
    Private iLineColor As Color
    Private iLineWidth As Integer
    Private iLineStyle As LineStyle

    Public Property FillColor As Color
        Get
            Return iFillColor
        End Get
        Set(value As Color)
            iFillColor = value
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
    Public Property LineColor As Color
        Get
            Return iLineColor
        End Get
        Set(value As Color)
            iLineColor = value
        End Set
    End Property
    Public Property LineWidth As Integer
        Get
            Return iLineWidth
        End Get
        Set(value As Integer)
            iLineWidth = value
        End Set
    End Property
    Public Property LineStyle As LineStyle
        Get
            Return iLineStyle
        End Get
        Set(value As LineStyle)
            iLineStyle = value
        End Set
    End Property


    Protected Friend Sub New(ItemID As String, ItemName As String, ItemFillColor As Color, ItemBackColor As Color, ItemLineColor As Color, ItemLineWidth As Integer, ItemLineStyle As LineStyle)
        MyBase.New(ItemName, ItemType.Elypse, ItemID)
        iFillColor = ItemFillColor
        iBackColor = ItemBackColor
        iLineColor = ItemLineColor
        iLineWidth = ItemLineWidth
        iLineStyle = ItemLineStyle
    End Sub
    Sub New()
        MyBase.New("Elypse", ItemType.Elypse, Nothing)
        iFillColor = Color.Transparent
        iBackColor = Color.Transparent
        iLineColor = Color.Black
        iLineWidth = 1
        iLineStyle = LineStyle.Solid
    End Sub
    Sub New(Rect As Rectangle)
        Me.New
        Location = Rect.Location
        Size = Rect.Size
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            iFillColor = Nothing
            iBackColor = Nothing
            iLineColor = Nothing
            iLineWidth = Nothing
            iLineStyle = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
