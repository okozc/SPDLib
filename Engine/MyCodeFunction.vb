Public Class MyCodeFunction
    Implements IDisposable

    Public Class InputValue
        Implements IDisposable

        Private iName As String
        Private iValue As String
        Private disposedValue As Boolean ' To detect redundant calls

        Public Property Name As String
            Get
                Return iName
            End Get
            Set(value As String)
                iName = value
            End Set
        End Property
        Public Property Value As String
            Get
                Return iValue
            End Get
            Set(value As String)
                iValue = value
            End Set
        End Property
        Sub New(Name As String, Value As String)
            iName = Name
            iValue = Value
        End Sub
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    iName = Nothing
                    iValue = Nothing
                End If
            End If
            disposedValue = True
        End Sub
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
        End Sub
    End Class

    Private iReturnValue As String
    Private iInputValues As List(Of InputValue)
    Private iCode As String
    Private iName As String
    Private disposedValue As Boolean
    Private iResults As String
    Public Property ReturnValue As String
        Get
            Return iReturnValue
        End Get
        Set(value As String)
            iReturnValue = value
        End Set
    End Property
    Public ReadOnly Property InputValues As List(Of InputValue)
        Get
            Return iInputValues
        End Get
    End Property
    Public Property Code As String
        Get
            Return iCode
        End Get
        Set(value As String)
            iCode = value
        End Set
    End Property
    Public Property Name As String
        Get
            Return iName
        End Get
        Set(value As String)
            iName = "FN" & value
        End Set
    End Property
    Public Property Results As String
        Get
            Return iResults
        End Get
        Set(value As String)
            iResults = value
        End Set
    End Property
    Sub New(Name As String)
        iReturnValue = ""
        iInputValues = New List(Of InputValue)
        iName = Name
        iCode = "Function Main()" & vbCrLf
        iCode += "  Dim ReturnValue As String" & vbCrLf
        iCode += "  'Your Code Here" & vbCrLf
        iCode += "  Return ReturnValue" & vbCrLf
        iCode += "End Function"
    End Sub
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                iReturnValue = Nothing
                For Each InputValue In iInputValues
                    InputValue.Dispose()
                Next
                iInputValues.Clear()
                iInputValues = Nothing
                iCode = Nothing
                iName = Nothing
                iResults = Nothing
            End If
        End If
        disposedValue = True
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
    End Sub
End Class
