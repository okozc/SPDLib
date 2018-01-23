Public Class MyTranslator
    Implements IDisposable

    Private ini As IniFile
    Private iPreferredLanguage As String
    Private disposedValue As Boolean

    Public Property PreferredLanguage As String
        Get
            Return iPreferredLanguage
        End Get
        Set(value As String)
            iPreferredLanguage = value
        End Set
    End Property

    Sub New(ByVal LanguageINIFile As String)
        ini = New IniFile
        If IO.File.Exists(LanguageINIFile) Then
            ini.Load(LanguageINIFile)
        Else
            Throw New Exception("Language File Not Found!")
        End If
    End Sub

    Public Function Trn(ByVal ExpressionName As String) As String
        Return Trn(ExpressionName, iPreferredLanguage)
    End Function
    Public Function Trn(ByVal ExpressionName As String, ByVal Language As String) As String
        Dim Exp As String = (ini.GetKeyValue(Language, ExpressionName))
        If Not IsNothing(Exp) Then Return Exp
        Return "?"
    End Function


    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ini = Nothing
                iPreferredLanguage = Nothing
            End If
        End If
        disposedValue = True
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
    End Sub
End Class
