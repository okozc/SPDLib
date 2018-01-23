Public Class PointsRectangle
    Implements IDisposable

    Private iPoint1 As Point
    Private iPoint2 As Point

    Public Property X1 As Integer
        Get
            Return iPoint1.X
        End Get
        Set(value As Integer)
            iPoint1.X = value
        End Set
    End Property
    Public Property Y1 As Integer
        Get
            Return iPoint1.Y
        End Get
        Set(value As Integer)
            iPoint1.Y = value
        End Set
    End Property
    Public Property X2 As Integer
        Get
            Return iPoint2.X
        End Get
        Set(value As Integer)
            iPoint2.X = value
        End Set
    End Property
    Public Property Y2 As Integer
        Get
            Return iPoint2.Y
        End Get
        Set(value As Integer)
            iPoint2.Y = value
        End Set
    End Property
    Public Property Point1 As Point
        Get
            Return iPoint1
        End Get
        Set(value As Point)
            iPoint1 = value
        End Set
    End Property
    Public Property Point2 As Point
        Get
            Return iPoint2
        End Get
        Set(value As Point)
            iPoint2 = value
        End Set
    End Property

    Public Sub New(X1 As Integer, Y1 As Integer, X2 As Integer, Y2 As Integer)
        Me.New
        With iPoint1
            .X = X1
            .Y = Y1
        End With
        With iPoint2
            .X = X2
            .Y = Y2
        End With
    End Sub
    Public Sub New(Location1 As Point, Location2 As Point)
        iPoint1 = New Point(Location1)
        iPoint2 = New Point(Location2)
    End Sub
    Public Sub New()
        iPoint1 = New Point
        iPoint2 = New Point
    End Sub
    Public Sub Offset(p As Point)
        Offset(p.X, p.Y)
    End Sub
    Public Sub Offset(dX As Integer, dY As Integer)
        iPoint1.Offset(dX, dY)
        iPoint2.Offset(dX, dY)
    End Sub
    Public Function GetRectangle() As Rectangle
        Dim Rect As New Rectangle
        If X1 < X2 Then
            Rect.X = X1
            Rect.Width = X2 - X1
        Else
            Rect.X = X2
            Rect.Width = X1 - X2
        End If
        If Y1 < Y2 Then
            Rect.Y = Y1
            Rect.Height = Y2 - Y1
        Else
            Rect.Y = Y2
            Rect.Height = Y1 - Y2
        End If
        Return Rect
    End Function
    Public Function Clone() As PointsRectangle
        Return New PointsRectangle(iPoint1, iPoint2)
    End Function

    Public Overrides Function ToString() As String
        Return "{X1=" & Point1.X & ",Y1=" & Point1.Y & ",X2=" & Point2.X & ",Y2=" & Point2.Y & "}"
    End Function



#Region "IDisposable Support"
    Private disposedValue As Boolean
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                iPoint1 = Nothing
                iPoint2 = Nothing
            End If
        End If
        disposedValue = True
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
    End Sub
#End Region
End Class
