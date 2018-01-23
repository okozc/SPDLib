Public Class MyFunctionField
    Inherits MyField

    Private iFunction As MyCodeFunction

    Public Property Code As String
        Get
            Return iFunction.Code
        End Get
        Set(value As String)
            iFunction.Code = value
        End Set
    End Property
    Sub New()
        MyBase.New(MyFieldType.FunctionField, "NewFunctionField")
        iFunction = New MyCodeFunction(Name)
        iFunction.Name = Name
    End Sub
    Sub New(Name As String, CodeFunction As MyCodeFunction)
        MyBase.New(MyFieldType.FunctionField, Name)
        iFunction = CodeFunction
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If Not IsNothing(iFunction) Then iFunction.Dispose()
            iFunction = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
