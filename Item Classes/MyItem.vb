Imports System.ComponentModel

Public Enum ItemType
    None
    Text
    Line
    Rectangle
    Elypse
    Picture
    Barcode
    Data
End Enum
Public Enum ItemHorizontalAlignment
    Left
    Center
    Right
End Enum
Public Enum ItemVerticalAlignment
    Top
    Center
    Bottom
End Enum
Public Enum MyItemPosition
    Absolute
    Relative
End Enum
Public Enum MyItemVisibility
    Invisible
    Visible
    Relative
End Enum

Public MustInherit Class MyItem
    Implements IDisposable

    Private iName As String
    Private iID As String
    Private iType As ItemType

    Private iLocation As Point
    Private iSize As Size

    Private iHorizontalPosition As MyItemPosition
    Private iVerticalPosition As MyItemPosition
    Private iVisibility As MyItemVisibility
    Private iHorizontalPositionParrent As String
    Private iVerticalPositionParrent As String
    Private iVisibilityParrent As String

    Public Property Name As String
        Get
            Return iName
        End Get
        Set(value As String)
            iName = value
        End Set
    End Property
    Public ReadOnly Property ID As String
        Get
            Return iID
        End Get
    End Property
    Public ReadOnly Property Type As ItemType
        Get
            Return iType
        End Get
    End Property
    Protected Friend WriteOnly Property SetType As ItemType
        Set(value As ItemType)
            iType = value
        End Set
    End Property
    Public Property Location As Point
        Get
            Return iLocation
        End Get
        Set(value As Point)
            iLocation = value
        End Set
    End Property
    Public Overridable Property Size As Size
        Get
            Return iSize
        End Get
        Set(value As Size)
            iSize = value
        End Set
    End Property
    <Browsable(False)> Public Property X As Integer
        Get
            Return iLocation.X
        End Get
        Set(value As Integer)
            iLocation.X = value
        End Set
    End Property
    <Browsable(False)> Public Property Y As Integer
        Get
            Return iLocation.Y
        End Get
        Set(value As Integer)
            iLocation.Y = value
        End Set
    End Property
    <Browsable(False)> Public Property Width As Integer
        Get
            Return iSize.Width
        End Get
        Set(value As Integer)
            iSize.Width = value
        End Set
    End Property
    <Browsable(False)> Public Property Height As Integer
        Get
            Return iSize.Height
        End Get
        Set(value As Integer)
            iSize.Height = value
        End Set
    End Property
    <Browsable(False)> Public ReadOnly Property Right As Integer
        Get
            Return iLocation.X + iSize.Width - 1
        End Get
    End Property
    <Browsable(False)> Public ReadOnly Property Bottom As Integer
        Get
            Return iLocation.Y + iSize.Height - 1
        End Get
    End Property
    <Category("Position Dependency")> Public Property HorizontalPosition As MyItemPosition
        Get
            Return iHorizontalPosition
        End Get
        Set(value As MyItemPosition)
            iHorizontalPosition = value
        End Set
    End Property
    <Category("Position Dependency")> Public Property VerticalPosition As MyItemPosition
        Get
            Return iVerticalPosition
        End Get
        Set(value As MyItemPosition)
            iVerticalPosition = value
        End Set
    End Property
    <Category("Position Dependency")> Public Property HorizontalPositionParrent As String
        Get
            Return iHorizontalPositionParrent
        End Get
        Set(value As String)
            iHorizontalPositionParrent = value
        End Set
    End Property
    <Category("Position Dependency")> Public Property VerticalPositionParrent As String
        Get
            Return iVerticalPositionParrent
        End Get
        Set(value As String)
            iVerticalPositionParrent = value
        End Set
    End Property
    <Category("Visibility Dependency")> Public Property Visibility As MyItemVisibility
        Get
            Return iVisibility
        End Get
        Set(value As MyItemVisibility)
            iVisibility = value
        End Set
    End Property
    <Category("Visibility Dependency")> Public Property VisibilityParrent As String
        Get
            Return iVisibilityParrent
        End Get
        Set(value As String)
            iVisibilityParrent = value
        End Set
    End Property

    Protected Sub New(ItemName As String, ItemType As ItemType, Optional ItemID As String = Nothing)
        If IsNothing(ItemID) Then ItemID = Guid.NewGuid().ToString("N")
        iName = ItemName
        iType = ItemType
        iID = ItemID
        'iRect = New Rectangle(0, 0, 20, 20)
        iLocation = New Point(0, 0)
        iSize = New Size(20, 20)
        iHorizontalPosition = MyItemPosition.Absolute
        iVisibility = MyItemVisibility.Visible
        iVerticalPositionParrent = ""
        iVisibilityParrent = ""
    End Sub

    Public Overridable Function GetRectangle() As Rectangle
        Return New Rectangle(iLocation, iSize)
    End Function

    Public Shared Operator =(i1 As MyItem, i2 As MyItem)
        If IsNothing(i1) And IsNothing(i2) Then Return True
        If IsNothing(i1) And Not IsNothing(i2) Then Return False
        If Not IsNothing(i1) And IsNothing(i2) Then Return False
        If i1.ID = i2.ID And i1.Type = i2.Type And i1.Name = i2.Name Then Return True Else Return False
    End Operator
    Public Shared Operator <>(i1 As MyItem, i2 As MyItem)
        If IsNothing(i1) And IsNothing(i2) Then Return False
        If IsNothing(i1) And Not IsNothing(i2) Then Return True
        If Not IsNothing(i1) And IsNothing(i2) Then Return True
        If i1.ID <> i2.ID Or i1.Name <> i2.Name Or i1.Type <> i2.Type Then Return True Else Return False
    End Operator
    Public Overrides Function ToString() As String
        Return iType.ToString & "(" & Name & ")"
    End Function
#Region "IDisposable Support"
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                iName = Nothing
                iID = Nothing
                iType = Nothing
                iLocation = Nothing
                iSize = Nothing
                iHorizontalPosition = Nothing
                iVerticalPosition = Nothing
                iVisibility = Nothing
                iHorizontalPositionParrent = Nothing
                iVerticalPositionParrent = Nothing
                iVisibilityParrent = Nothing
            End If
        End If
        disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
    End Sub
#End Region
End Class
