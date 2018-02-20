Public MustInherit Class MyField
    Implements IDisposable

    Public Enum FieldType
        StaticField
        FunctionField
        DataField
        StaticTextField
    End Enum
    Public Enum FieldValueType
        Text
        Numeric
        [Date]
    End Enum

    Private iName As String
    Private iDescription As String
    Private iType As FieldType
    Private iFormat As String
    Private iValue As String
    Private iValueType As FieldValueType

    Private disposedValue As Boolean

    Public Overridable Property Name As String
        Get
            Return iName
        End Get
        Set(value As String)
            iName = value
        End Set
    End Property
    Public Overridable Property Description As String
        Get
            Return iDescription
        End Get
        Set(value As String)
            iDescription = value
        End Set
    End Property
    Public ReadOnly Property Type As FieldType
        Get
            Return iType
        End Get
    End Property
    Public Overridable Property Format As String
        Get
            Return iFormat
        End Get
        Set(value As String)
            iFormat = value
        End Set
    End Property
    Public Overridable Property Value As String
        Get
            Return iValue
        End Get
        Set(value As String)
            iValue = value
        End Set
    End Property
    Public Overridable Property ValueType As FieldValueType
        Get
            Return iValueType
        End Get
        Set(value As FieldValueType)
            iValueType = value
        End Set
    End Property

    Sub New(FieldName As String, FieldType As FieldType)
        iName = FieldName
        iType = FieldType
        iFormat = ""
    End Sub

#Region "IDisposable Support"
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                iName = Nothing
                iDescription = Nothing
                iType = Nothing
                iFormat = Nothing
                iValue = Nothing
                iValueType = Nothing
            End If
        End If
        disposedValue = True
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
    End Sub
#End Region
End Class
