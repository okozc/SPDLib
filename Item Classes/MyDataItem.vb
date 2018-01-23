Imports System.ComponentModel

Public Class MyDataItem
    Inherits MyTextItem

    Private iDataField As MyField
    'Private iDataValue As String
    Public Property DataField As MyField
        Get
            Return iDataField
        End Get
        Set(value As MyField)
            iDataField = value
        End Set
    End Property
    Public ReadOnly Property Value As String
        Get
            Return iDataField.Value
        End Get
    End Property
    <Browsable(False)>
    Public Overrides Property Text As String
        Get
            Return Name
        End Get
        Set(value As String)
        End Set
    End Property


    Sub New(ItemID As String, ItemName As String, ItemRect As Rectangle,
            Text As String, TextFont As Font, TextColor As Color, BackColor As Color, WordWrap As Boolean,
            Border As MyItemBorderStyle, VAlignment As ItemVerticalAlignment, HAlignment As ItemHorizontalAlignment, Rotation As Integer)
        MyBase.New(ItemID, ItemName, ItemRect.X, ItemRect.Y, ItemRect.Width, ItemRect.Height, Text, TextFont,
                   TextColor, BackColor, WordWrap, Border, VAlignment, HAlignment, Rotation)
        SetType = ItemType.Data
        'iDataField = New MyField(Name, "", MyField.MyValueTypeType.Number)
        'iDataValue = ""
    End Sub
    Sub New(Rect As Rectangle)
        Me.New(Nothing, "Data", Rect, "", New Font("Arial", 11), Color.Black, Color.Transparent, False,
               New MyItemBorderStyle(LineStyle.None, 1, Color.Black), ItemVerticalAlignment.Bottom, ItemHorizontalAlignment.Left, 0)
    End Sub

    Public Sub Assign(Row As DataRow)
        Try
            iDataField.Value = Row(iDataField.Name).ToString
        Catch ex As Exception
            iDataField.Value = ""
        End Try
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            iDataField = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
