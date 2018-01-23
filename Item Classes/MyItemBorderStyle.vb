Imports System.ComponentModel

Public Enum LineStyle
    None
    Solid
    Dashed
    Dotted
End Enum

<TypeConverterAttribute(GetType(System.ComponentModel.ExpandableObjectConverter))>
Public Class MyItemBorderStyle
    Implements IDisposable

    Private iStyleLeft As LineStyle
    Private iStyleRight As LineStyle
    Private iStyleTop As LineStyle
    Private iStyleBottom As LineStyle
    Private iWidthLeft As Integer
    Private iWidthRight As Integer
    Private iWidthTop As Integer
    Private iWidthBottom As Integer
    Private iColorLeft As Color
    Private iColorRight As Color
    Private iColorTop As Color
    Private iColorBottom As Color

    <Category("Style"), Description(""), Browsable(True), NotifyParentProperty(True)>
    Public Property StyleLeft As LineStyle
        Get
            Return iStyleLeft
        End Get
        Set(value As LineStyle)
            iStyleLeft = value
        End Set
    End Property
    <Category("Style"), Description(""), Browsable(True), NotifyParentProperty(True)>
    Public Property StyleRight As LineStyle
        Get
            Return iStyleRight
        End Get
        Set(value As LineStyle)
            iStyleRight = value
        End Set
    End Property
    <Category("Style"), Description(""), Browsable(True), NotifyParentProperty(True)>
    Public Property StyleTop As LineStyle
        Get
            Return iStyleTop
        End Get
        Set(value As LineStyle)
            iStyleTop = value
        End Set
    End Property
    <Category("Style"), Description(""), Browsable(True), NotifyParentProperty(True)>
    Public Property StyleBottom As LineStyle
        Get
            Return iStyleBottom
        End Get
        Set(value As LineStyle)
            iStyleBottom = value
        End Set
    End Property
    <Category("Width"), Description(""), Browsable(True), NotifyParentProperty(True)>
    Public Property WidthLeft As Integer
        Get
            Return iWidthLeft
        End Get
        Set(value As Integer)
            iWidthLeft = value
        End Set
    End Property
    <Category("Width"), Description(""), Browsable(True), NotifyParentProperty(True)>
    Public Property WidthRight As Integer
        Get
            Return iWidthRight
        End Get
        Set(value As Integer)
            iWidthRight = value
        End Set
    End Property
    <Category("Width"), Description(""), Browsable(True), NotifyParentProperty(True)>
    Public Property WidthTop As Integer
        Get
            Return iWidthTop
        End Get
        Set(value As Integer)
            iWidthTop = value
        End Set
    End Property
    <Category("Width"), Description(""), Browsable(True), NotifyParentProperty(True)>
    Public Property WidthBottom As Integer
        Get
            Return iWidthBottom
        End Get
        Set(value As Integer)
            iWidthBottom = value
        End Set
    End Property
    <Category("Color"), Description(""), Browsable(True), NotifyParentProperty(True)>
    Public Property ColorLeft As Color
        Get
            Return iColorLeft
        End Get
        Set(value As Color)
            iColorLeft = value
        End Set
    End Property
    <Category("Color"), Description(""), Browsable(True), NotifyParentProperty(True)>
    Public Property ColorRight As Color
        Get
            Return iColorRight
        End Get
        Set(value As Color)
            iColorRight = value
        End Set
    End Property
    <Category("Color"), Description(""), Browsable(True), NotifyParentProperty(True)>
    Public Property ColorTop As Color
        Get
            Return iColorTop
        End Get
        Set(value As Color)
            iColorTop = value
        End Set
    End Property
    <Category("Color"), Description(""), Browsable(True), NotifyParentProperty(True)>
    Public Property ColorBottom As Color
        Get
            Return iColorBottom
        End Get
        Set(value As Color)
            iColorBottom = value
        End Set
    End Property

    Sub New(StyleLeft As LineStyle, StyleRight As LineStyle, StyleTop As LineStyle, StyleBottom As LineStyle,
            WidthLeft As Integer, WidthRight As Integer, WidthTop As Integer, WidthBottom As Integer,
            ColorLeft As Color, ColorRight As Color, ColorTop As Color, ColorBottom As Color)
        iStyleLeft = StyleLeft
        iStyleRight = StyleRight
        iStyleTop = StyleTop
        iStyleBottom = StyleBottom
        iWidthLeft = WidthLeft
        iWidthRight = WidthRight
        iWidthTop = WidthTop
        iWidthBottom = WidthBottom
        iColorLeft = ColorLeft
        iColorRight = ColorRight
        iColorTop = ColorTop
        iColorBottom = ColorBottom
    End Sub
    Sub New(Style As LineStyle, Width As Integer, Color As Color)
        Me.New(Style, Style, Style, Style, Width, Width, Width, Width, Color, Color, Color, Color)
    End Sub
    Sub New()
        Me.New(LineStyle.None, 1, Color.Black)
    End Sub
    Public Overrides Function ToString() As String
        Return "BorderStyle"
    End Function

    Public Function GetString() As String
        Return "L," & StyleLeft.ToString & "," & WidthLeft & "," & ColorLeft.ToArgb & ";" &
            "R," & StyleRight.ToString & "," & WidthRight & "," & ColorRight.ToArgb & ";" &
            "T," & StyleTop.ToString & "," & WidthTop & "," & ColorTop.ToArgb & ";" &
            "B," & StyleBottom.ToString & "," & WidthBottom & "," & ColorBottom.ToArgb & ";"
    End Function
    Public Shared Function FromString(BorderString As String) As MyItemBorderStyle
        Dim NewBorder As New MyItemBorderStyle
        Dim Sides() As String = BorderString.Split(";")
        For Each Side In Sides
            Dim V() As String = Side.Split(",")
            Select Case V(0)
                Case "L"
                    Select Case V(1)
                        Case "Solid"
                            NewBorder.StyleLeft = LineStyle.Solid
                        Case "Dashed"
                            NewBorder.StyleLeft = LineStyle.Dashed
                        Case "Dotted"
                            NewBorder.StyleLeft = LineStyle.Dotted
                        Case "None"
                            NewBorder.StyleLeft = LineStyle.None
                    End Select
                    NewBorder.WidthLeft = CInt(V(2))
                    NewBorder.ColorLeft = Color.FromArgb(V(3))
                Case "R"
                    Select Case V(1)
                        Case "Solid"
                            NewBorder.StyleRight = LineStyle.Solid
                        Case "Dashed"
                            NewBorder.StyleRight = LineStyle.Dashed
                        Case "Dotted"
                            NewBorder.StyleRight = LineStyle.Dotted
                        Case "None"
                            NewBorder.StyleRight = LineStyle.None
                    End Select
                    NewBorder.WidthRight = CInt(V(2))
                    NewBorder.ColorRight = Color.FromArgb(V(3))
                Case "T"
                    Select Case V(1)
                        Case "Solid"
                            NewBorder.StyleTop = LineStyle.Solid
                        Case "Dashed"
                            NewBorder.StyleTop = LineStyle.Dashed
                        Case "Dotted"
                            NewBorder.StyleTop = LineStyle.Dotted
                        Case "None"
                            NewBorder.StyleTop = LineStyle.None
                    End Select
                    NewBorder.WidthTop = CInt(V(2))
                    NewBorder.ColorTop = Color.FromArgb(V(3))
                Case "B"
                    Select Case V(1)
                        Case "Solid"
                            NewBorder.StyleBottom = LineStyle.Solid
                        Case "Dashed"
                            NewBorder.StyleBottom = LineStyle.Dashed
                        Case "Dotted"
                            NewBorder.StyleBottom = LineStyle.Dotted
                        Case "None"
                            NewBorder.StyleBottom = LineStyle.None
                    End Select
                    NewBorder.WidthBottom = CInt(V(2))
                    NewBorder.ColorBottom = Color.FromArgb(V(3))
            End Select
        Next
        Return NewBorder
    End Function
#Region "IDisposable Support"
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                iStyleLeft = Nothing
                iStyleRight = Nothing
                iStyleTop = Nothing
                iStyleBottom = Nothing
                iWidthLeft = Nothing
                iWidthRight = Nothing
                iWidthTop = Nothing
                iWidthBottom = Nothing
                iColorLeft = Nothing
                iColorRight = Nothing
                iColorTop = Nothing
                iColorBottom = Nothing
            End If
        End If
        disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)

    End Sub
#End Region

End Class
