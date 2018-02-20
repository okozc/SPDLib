Imports System.ComponentModel

Public Class MyStaticTextField
    Inherits MyField

    <[ReadOnly](True)> Public Overrides Property Name As String
        Get
            Return MyBase.Name
        End Get
        Set(value As String)
        End Set
    End Property
    <[ReadOnly](True)> Public Overrides Property Description As String
        Get
            Return MyBase.Description
        End Get
        Set(value As String)
            MyBase.Description = value
        End Set
    End Property
    <Browsable(False)> Public Overrides Property Format As String
    Public Overrides Property Value As String
        Get
            Return MyBase.Value
        End Get
        Set(value As String)
            MyBase.Value = value
        End Set
    End Property
    <Browsable(False)> Public Overrides Property ValueType As FieldValueType
        Get
            Return MyBase.ValueType
        End Get
        Set(value As FieldValueType)
        End Set
    End Property


    Sub New()
        MyBase.New("StaticTextField", FieldType.StaticTextField)
    End Sub
    Sub New(FieldName As String)
        MyBase.New(FieldName, FieldType.StaticTextField)
        Description = ""
    End Sub
End Class
