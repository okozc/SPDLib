Imports System.ComponentModel

<TypeConverterAttribute(GetType(System.ComponentModel.ExpandableObjectConverter))>
Public MustInherit Class MyField
    Implements IDisposable

    Public Enum MyValueType
        Text
        Number
        DateTime
    End Enum
    Public Enum MyFieldType
        DataField
        FunctionField
        StaticField
    End Enum

    Private iType As MyFieldType
    Private iFieldName As String
    Private iFieldFriendlyName As String
    Private iFieldValue As String
    Private iFieldFormat As String
    Private iValueType As MyValueType
    Private disposedValue As Boolean

    Public ReadOnly Property Type As MyFieldType
        Get
            Return iType
        End Get
    End Property
    Public Overridable Property Name As String
        Get
            Return iFieldName
        End Get
        Set(value As String)
            iFieldName = value
        End Set
    End Property
    Public Overridable Property FriendlyName As String
        Get
            Return iFieldFriendlyName
        End Get
        Set(value As String)
            iFieldFriendlyName = value
        End Set
    End Property
    Public Overridable Property Value As String
        Get
            Dim Ret As String
            Select Case iValueType
                Case MyValueType.Text
                    Ret = iFieldValue
                Case MyValueType.Number
                    If IsNumeric(iFieldValue) Then
                        Ret = Strings.Format(CDbl(iFieldValue), iFieldFormat)
                    Else
                        Ret = iFieldValue
                    End If
                Case MyValueType.DateTime
                    If IsDate(iFieldValue) Then
                        Ret = Strings.Format(CDate(iFieldValue), iFieldFormat)
                    Else
                        Ret = iFieldValue
                    End If
                Case Else
                    Ret = iFieldValue
            End Select
            Return Ret
        End Get
        Set(value As String)
            iFieldValue = value
        End Set
    End Property
    Public Overridable Property Format As String
        Get
            Return iFieldFormat
        End Get
        Set(value As String)
            iFieldFormat = value
        End Set
    End Property
    Public Overridable Property ValueType As MyValueType
        Get
            Return iValueType
        End Get
        Set(value As MyValueType)
            iValueType = value
        End Set
    End Property

    Sub New(FieldName As String, FieldFormat As String, ValueType As MyValueType, FieldType As MyFieldType)
        iFieldName = FieldName
        iFieldFormat = FieldFormat
        Select Case ValueType
            Case MyValueType.Text
                iFieldValue = ""
            Case MyValueType.Number
                iFieldValue = 0
            Case MyValueType.DateTime
                iFieldValue = Now
        End Select
        iValueType = ValueType
        iType = FieldType
    End Sub

    Protected Friend Sub New(Type As MyFieldType, Name As String)
        iType = Type
        iFieldName = Name
        iValueType = MyValueType.Text
    End Sub


    Public Overrides Function ToString() As String
        Return Value.ToString
    End Function

#Region "IDisposable Support"
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                iFieldName = Nothing
                iFieldFormat = Nothing
                iFieldValue = Nothing
                iFieldFriendlyName = Nothing
            End If
            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        ' TODO: uncomment the following line if Finalize() is overridden above.
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
