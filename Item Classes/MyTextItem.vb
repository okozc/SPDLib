Imports System.ComponentModel
Imports System.Drawing.Design

Public Class MyTextItem
    Inherits MyItem

    Private iText As String
    Private iFont As Font
    Private iColor As Color
    Private iWordWrap As Boolean
    Private iBackColor As Color
    Private iBorder As MyItemBorderStyle
    Private iAlignH As ItemHorizontalAlignment
    Private iAlignV As ItemVerticalAlignment
    Private iRotation As Integer

    <Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", GetType(UITypeEditor))>
    Public Overridable Property Text As String
        Get
            Return iText
        End Get
        Set(value As String)
            iText = value
        End Set
    End Property
    Public Property TextFont As Font
        Get
            Return iFont
        End Get
        Set(value As Font)
            iFont = value
        End Set
    End Property
    Public Property TextColor As Color
        Get
            Return iColor
        End Get
        Set(value As Color)
            iColor = value
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
    Public Property WordWrap As Boolean
        Get
            Return iWordWrap
        End Get
        Set(value As Boolean)
            iWordWrap = value
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
    <Category("Alignment"), Description(""), Browsable(True)> Public Property VerticalAlignment As ItemVerticalAlignment
        Get
            Return iAlignV
        End Get
        Set(value As ItemVerticalAlignment)
            iAlignV = value
        End Set
    End Property
    <Category("Alignment"), Description(""), Browsable(True)> Public Property HorizontalAlignment As ItemHorizontalAlignment
        Get
            Return iAlignH
        End Get
        Set(value As ItemHorizontalAlignment)
            iAlignH = value
        End Set
    End Property
    <Category("Alignment"), Description(""), Browsable(True)> Public Property Rotation As Integer
        Get
            Return iRotation
        End Get
        Set(value As Integer)
            Dim rot As Integer = value
            If rot < 0 Then rot = 0
            If rot > 359 Then rot = 359
            iRotation = rot
        End Set
    End Property

    Protected Friend Sub New(ItemID As String, ItemName As String, TextFont As Font, TextColor As Color, BackColor As Color, WordWrap As Boolean,
                             Border As MyItemBorderStyle, VAlignment As ItemVerticalAlignment, HAlignment As ItemHorizontalAlignment,
                             Rotation As Integer, Text As String)
        MyBase.New(ItemName, ItemType.Text, ItemID)
        iFont = TextFont
        iColor = TextColor
        iBackColor = BackColor
        iWordWrap = WordWrap
        iBorder = Border
        iAlignV = VAlignment
        iAlignH = HAlignment
        iRotation = Rotation
        iText = Text
    End Sub
    Sub New(ItemID As String, ItemName As String, x As Integer, y As Integer, w As Integer, h As Integer,
            Text As String, TextFont As Font, TextColor As Color, BackColor As Color, WordWrap As Boolean,
            Border As MyItemBorderStyle, VAlignment As ItemVerticalAlignment, HAlignment As ItemHorizontalAlignment, Rotation As Integer)
        MyBase.New(ItemName, ItemType.Text, ItemID)
        MyBase.X = x
        MyBase.Y = y
        MyBase.Width = w
        MyBase.Height = h
        iText = Text
        iFont = TextFont
        iColor = TextColor
        iBackColor = BackColor
        iWordWrap = WordWrap
        iBorder = Border
        iAlignV = VAlignment
        iAlignH = HAlignment
        iRotation = Rotation
    End Sub
    Sub New(ItemID As String, ItemName As String, ItemRect As Rectangle,
            Text As String, TextFont As Font, TextColor As Color, BackColor As Color, WordWrap As Boolean,
            Border As MyItemBorderStyle, VAlignment As ItemVerticalAlignment, HAlignment As ItemHorizontalAlignment, Rotation As Integer)
        Me.New(ItemID, ItemName, ItemRect.X, ItemRect.Y, ItemRect.Width, ItemRect.Height, Text, TextFont,
               TextColor, BackColor, WordWrap, Border, VAlignment, HAlignment, Rotation)
    End Sub
    Sub New(ItemRect As Rectangle)
        Me.New(Nothing, "Text", ItemRect, "Text", New Font("Arial", 11), Color.Black, Color.Transparent, False, New MyItemBorderStyle(),
               ItemVerticalAlignment.Bottom, ItemHorizontalAlignment.Left, 0)
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            iText = Nothing
            iFont.Dispose()
            iColor = Nothing
            iWordWrap = Nothing
            iBackColor = Nothing
            iBorder.Dispose()
            iAlignH = Nothing
            iAlignV = Nothing
            iRotation = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
