Imports System.ComponentModel

Public Class MyLineItem
    Inherits MyItem

    Private iWidth As Integer
    Private iColor As Color
    Private iLocation2 As Point
    Public Property LineWidth As Integer
        Get
            Return iWidth
        End Get
        Set(value As Integer)
            iWidth = value
        End Set
    End Property
    Public Property LineColor As Color
        Get
            Return iColor
        End Get
        Set(value As Color)
            iColor = value
        End Set
    End Property
    <Browsable(False)> Public Overrides Property Size As Size
        Get
            Throw New Exception("Property 'Size' not implemented for 'MyLineItem'")
            Return Nothing
        End Get
        Set(value As Size)
            Throw New Exception("Property 'Size' not implemented for 'MyLineItem'")
        End Set
    End Property
    Public Property Location2 As Point
        Get
            Return iLocation2
        End Get
        Set(value As Point)
            iLocation2 = value
        End Set
    End Property
    <Browsable(False)> Public Property X2 As Integer
        Get
            Return iLocation2.X
        End Get
        Set(value As Integer)
            iLocation2.X = value
        End Set
    End Property
    <Browsable(False)> Public Property Y2 As Integer
        Get
            Return iLocation2.Y
        End Get
        Set(value As Integer)
            iLocation2.Y = value
        End Set
    End Property
    Sub New(ItemID As String, ItemName As String, x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer, LineWidth As Integer, LineColor As Color)
        MyBase.New(ItemName, ItemType.Line, ItemID)
        MyBase.X = x1
        MyBase.Y = y1
        MyBase.Width = x2
        MyBase.Height = y2
        iWidth = LineWidth
        iColor = LineColor
    End Sub
    Sub New(x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer)
        Me.New(Nothing, "", x1, y1, x2, y2, 1, Color.Black)
    End Sub
    Sub New()
        Me.New(Nothing, "", 10, 10, 110, 10, 1, Color.Black)
    End Sub
    Sub New(LineRect As Rectangle)
        Me.New(Nothing, "Line", LineRect.X, LineRect.Y, LineRect.Width, LineRect.Height, 1, Color.Black)
    End Sub

    Public Overrides Function GetRectangle() As Rectangle
        Dim Rect As New Rectangle
        If X < X2 Then
            Rect.X = X
            Rect.Width = X2 - X
        Else
            Rect.X = X2
            Rect.Width = X - X2
        End If
        If Y < Y2 Then
            Rect.Y = Y
            Rect.Height = Y2 - Y
        Else
            Rect.Y = Y2
            Rect.Height = Y - Y2
        End If
        If Rect.Width < 1 Then Rect.Inflate(1, 0)
        If Rect.Height < 1 Then Rect.Inflate(0, 1)
        Return Rect
    End Function

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            iWidth = Nothing
            iColor = Nothing
            iLocation2 = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
