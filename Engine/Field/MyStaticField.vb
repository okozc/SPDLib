Imports System.ComponentModel

Public Class MyStaticField
    Inherits MyField

    <[ReadOnly](True)> Public Overrides Property Name As String
        Get
            Return MyBase.Name
        End Get
        Set(value As String)
        End Set
    End Property
    <[ReadOnly](True)> Public Overrides Property FriendlyName As String
        Get
            Return MyBase.FriendlyName
        End Get
        Set(value As String)
            MyBase.FriendlyName = value
        End Set
    End Property
    <[ReadOnly](True)> Public Overrides Property Value As String
        Get
            Return MyBase.Value
        End Get
        Set(value As String)
        End Set
    End Property
    Public Overrides Property Format As String
        Get
            Return MyBase.Format
        End Get
        Set(value As String)
            MyBase.Format = value
        End Set
    End Property
    <[ReadOnly](True)> Public Overrides Property ValueType As MyValueType
        Get
            Return MyBase.ValueType
        End Get
        Set(value As MyValueType)
        End Set
    End Property
    <Browsable(False)> Protected Friend WriteOnly Property SetValue As String
        Set(value As String)
            MyBase.Value = value
        End Set
    End Property

    Sub New(Name As String, Format As String, ValueType As MyValueType)
        MyBase.New(Name, Format, ValueType, MyFieldType.StaticField)
    End Sub

    Public Overrides Function ToString() As String
        Return FriendlyName
    End Function
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then

        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
