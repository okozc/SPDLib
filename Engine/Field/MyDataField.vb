Imports System.ComponentModel
Public Class MyDataField
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
    <[ReadOnly](True)> Public Overrides Property Value As String
        Get
            Return MyBase.Value
        End Get
        Set(value As String)
        End Set
    End Property
    <[ReadOnly](True)> Public Overrides Property ValueType As FieldValueType
        Get
            Return MyBase.ValueType
        End Get
        Set(value As FieldValueType)
        End Set
    End Property
    <Browsable(False)> Protected Friend WriteOnly Property SetValue As String
        Set(value As String)
            MyBase.Value = value
        End Set
    End Property

    Sub New()
        MyBase.New("DataField", FieldType.DataField)
    End Sub
    Sub New(FieldName As String, Optional FieldFormat As String = "")
        MyBase.New(FieldName, FieldType.DataField)
        Format = FieldFormat
        Description = ""
    End Sub
End Class
