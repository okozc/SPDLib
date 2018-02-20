Imports System.ComponentModel

Public Class MyFunctionField
    Inherits MyField

    Private iCode As String
    Private iInputFields As List(Of MyField)

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
    <Browsable(False)> Public Property Code As String
        Get
            Return iCode
        End Get
        Set(value As String)
            iCode = value
        End Set
    End Property
    <Browsable(False)> Protected Friend WriteOnly Property SetValue As String
        Set(value As String)
            MyBase.Value = value
        End Set
    End Property
    <Browsable(False)> Protected Friend Property InputFields As List(Of MyField)
        Get
            Return iInputFields
        End Get
        Set(value As List(Of MyField))
            iInputFields = value
        End Set
    End Property

    Sub New()
        MyBase.New("FunctionField", FieldType.FunctionField)
        iCode = ""
    End Sub
    Sub New(FieldName As String, Optional FieldFormat As String = "")
        MyBase.New(FieldName, FieldType.FunctionField)
        Format = FieldFormat
        Description = ""
        iCode = ""
    End Sub
End Class
