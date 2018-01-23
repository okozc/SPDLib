Imports System.Text
Imports System.CodeDom.Compiler
Imports System.Reflection

Public Class MyCodeExecutor

    Sub New()
    End Sub

    Public Sub ExecuteFunction(ByVal CodeFunction As MyCodeFunction)

        Dim sReturn_DataType As String
        Dim sReturn_Value As String = ""
        Dim ErrorLineOffset As Integer = 0
        Try
            CodeFunction.Results = ""
            ' Instance our CodeDom wrapper
            Dim ep As New cVBEvalProvider

            ' Compile and run
            Dim objResult As Object = ep.Eval(CodeFunction, ErrorLineOffset)
            If ep.CompilerErrors.Count <> 0 Then
                'Diagnostics.Debug.WriteLine("ExecuteFunction: Compile Error Count = " & ep.CompilerErrors.Count)
                'Diagnostics.Debug.WriteLine(ep.CompilerErrors.Item(0))
                'For i = 0 To ep.CompilerErrors.Count
                '    CodeFunction.Results += ep.CompilerErrors.Item(i).ErrorText & vbCrLf
                'Next
                For Each cError As CompilerError In ep.CompilerErrors
                    CodeFunction.Results += "Line: " & CStr(cError.Line - ErrorLineOffset) & " - " & cError.ErrorText & vbCrLf  ' Forget it
                Next
            End If
            Dim t As Type = objResult.GetType()
            If t.ToString() = "System.String" Then
                sReturn_DataType = t.ToString
                sReturn_Value = Convert.ToString(objResult)
            Else
                ' Some other type of data - not really handled at 
                ' this point. rwd
                'ToDo: Add handlers for other data return types, if needed

                ' Here is an example to handle a dataset...
                'Dim ds As DataSet = DirectCast(objResult, DataSet)
                'DataGrid1.Visible = True
                'TextBox2.Visible = False
                'DataGrid1.DataSource = ds.Tables(0)
            End If

        Catch ex As Exception
            Dim sErrMsg As String
            sErrMsg = String.Format("{0}", ex.Message)
            CodeFunction.Results += sErrMsg & vbCrLf
            ' Do Nothing - This is just a negative case
            ' This outcome is expected in late interpreting
            ' I suppose what I am saying is: Don't stop my program because the script writer can't write
            ' script very well.  To be fair, we could log this somewhere and notify somebody.
        End Try

        CodeFunction.ReturnValue = sReturn_Value

    End Sub


End Class
Public Class cVBEvalProvider


    Private m_oCompilerErrors As CompilerErrorCollection

    Public Property CompilerErrors() As CompilerErrorCollection
        Get
            Return m_oCompilerErrors
        End Get
        Set(ByVal Value As CompilerErrorCollection)
            m_oCompilerErrors = Value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        m_oCompilerErrors = New CompilerErrorCollection
    End Sub

    Public Function Eval(ByVal CodeFunction As MyCodeFunction, ByRef ErrorLineOffset As Integer) As Object

        Dim oCodeProvider As VBCodeProvider = New VBCodeProvider
        ' Obsolete in 2.0 framework
        ' Dim oICCompiler As ICodeCompiler = oCodeProvider.CreateCompiler

        Dim oCParams As CompilerParameters = New CompilerParameters
        Dim oCResults As CompilerResults
        Dim oAssy As System.Reflection.Assembly
        Dim oExecInstance As Object = Nothing
        Dim oRetObj As Object = Nothing
        Dim oMethodInfo As MethodInfo
        Dim oType As Type


        Try

            ' Setup the Compiler Parameters  
            ' Add any referenced assemblies
            oCParams.ReferencedAssemblies.Add("system.dll")
            oCParams.ReferencedAssemblies.Add("system.xml.dll")
            oCParams.ReferencedAssemblies.Add("system.data.dll")
            oCParams.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll")
            oCParams.CompilerOptions = "/t:library"
            oCParams.GenerateInMemory = True

            ' Generate the Code Framework
            Dim sb As StringBuilder = New StringBuilder("")

            sb.Append("Imports System" & vbCrLf)
            sb.Append("Imports System.Xml" & vbCrLf)
            sb.Append("Imports System.Data" & vbCrLf)
            sb.Append("Imports Microsoft.VisualBasic" & vbCrLf)

            ' Build a little wrapper code, with our passed in code in the middle 
            sb.Append("Namespace dValuate" & vbCrLf)
            sb.Append("Class EvalRunTime " & vbCrLf)
            ErrorLineOffset = 6 + CodeFunction.InputValues.Count
            'sb.Append("Public Function EvaluateIt() As Object " & vbCrLf)
            For Each InputValue In CodeFunction.InputValues
                sb.Append("Private " & InputValue.Name & "=" & Chr(42) & InputValue.Value & Chr(42) & vbCrLf)
            Next
            sb.Append(CodeFunction.Code & vbCrLf)
            'sb.Append("End Function " & vbCrLf)
            sb.Append("End Class " & vbCrLf)
            sb.Append("End Namespace" & vbCrLf)
            'Debug.WriteLine(sb.ToString())

            Try
                ' Compile and get results 
                ' 2.0 Framework - Method called from Code Provider
                oCResults = oCodeProvider.CompileAssemblyFromSource(oCParams, sb.ToString)
                ' 1.1 Framework - Method called from CodeCompiler Interface
                ' cr = oICCompiler.CompileAssemblyFromSource (cp, sb.ToString)


                ' Check for compile time errors 
                If oCResults.Errors.Count <> 0 Then

                    Me.CompilerErrors = oCResults.Errors
                    Throw New Exception("Compile Errors")

                Else
                    ' No Errors On Compile, so continue to process...

                    oAssy = oCResults.CompiledAssembly
                    oExecInstance = oAssy.CreateInstance("dValuate.EvalRunTime")


                    oType = oExecInstance.GetType
                    oMethodInfo = oType.GetMethod("Main")

                    oRetObj = oMethodInfo.Invoke(oExecInstance, Nothing)
                    Return oRetObj

                End If

            Catch ex As Exception
                ' Compile Time Errors Are Caught Here
                ' Some other weird error 
                'Debug.WriteLine(ex.Message)
                CodeFunction.Results += ex.Message & vbCrLf
                'Stop
            End Try

        Catch ex As Exception
            'Debug.WriteLine(ex.Message)
            CodeFunction.Results += ex.Message & vbCrLf
            'Stop
        End Try

        Return oRetObj

    End Function

End Class

