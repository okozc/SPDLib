Imports System.Text.RegularExpressions

Public Class FunctionEditor
    Private iNormalFont As Font
    Private iHighlightFont As Font
    Private iCodeFunction As MyCodeFunction
    Private iFields As List(Of MyCodeFunction.InputValue)

    Sub New(ByVal Fields As List(Of MyCodeFunction.InputValue), ByVal CodeFunction As MyCodeFunction)
        InitializeComponent()
        iNormalFont = New Font("Consolas", 11.25, FontStyle.Regular)
        iHighlightFont = New Font("Consolas", 11.25, FontStyle.Bold)
        Text += " [" & CodeFunction.Name & "]"
        iFields = Fields
        iCodeFunction = CodeFunction
        With CodeEditor.Settings
            .EnableComments = True
            .Comment = "'"
            .CommentColor = Color.DarkGreen
            .EnableIntegers = True
            .IntegerColor = Color.DarkOliveGreen
            .EnableStrings = True
            .StringColor = Color.OrangeRed
            .KeywordColor = Color.RoyalBlue
            .Keywords.AddRange({"AddHandler", "AddressOf", "Alias", "And", "AndAlso",
                                    "As", "Boolean", "ByRef", "Byte", "ByVal", "Call",
                                    "Case", "Catch", "CBool", "CByte", "CChar", "CDate",
                                    "CDec", "CDbl", "Char", "CInt", "Class", "CLng",
                                    "CObj", "Const", "CShort", "CSng", "CStr", "CType",
                                    "Date", "Decimal", "Declare", "Default", "Delegate",
                                    "Dim", "DirectCast", "Do", "Double", "Each", "Else",
                                    "ElseIf", "End", "Enum", "Erase", "Error", "Event",
                                    "Exit", "False", "Finally", "For", "Friend",
                                    "Function", "Get", "GetType", "GoSub", "GoTo",
                                    "Handles", "If", "Implements", "Imports", "In",
                                    "Inherits", "Integer", "Interface", "Is", "Let", "Lib",
                                    "Like", "Long", "Loop", "Me", "Mod", "Module",
                                    "MustInherit", "MustOverride", "MyBase", "MyClass",
                                    "Namespace", "New", "Next", "Not", "Nothing",
                                    "NotInheritable", "NotOverridable", "Object", "On",
                                    "On", "Option", "Optional", "Or", "OrElse", "Overloads",
                                    "Overridable", "Overrides", "ParamArray", "Private",
                                    "Property", "Protected", "Public", "RaiseEvent",
                                    "ReadOnly", "ReDim", "RemoveHandler", "Resume", "Return",
                                    "Select", "Set", "Shadows", "Shared", "Short", "Single",
                                    "Static", "Step", "Stop", "String", "Structure", "Sub",
                                    "SyncLock", "Then", "Throw", "To", "True", "Try", "TypeOf",
                                    "Until", "Variant", "When", "While", "With", "WithEvents",
                                    "WriteOnly", "Xor", "#Const", "#ExternalSource", "#If",
                                    "#Else", "#ElseIf", "#Region", "Region", "#End"})
        End With
        CodeEditor.CompileKeywords()
        CodeEditor.Text = iCodeFunction.Code
        CodeEditor.ProcessAllLines()
    End Sub

    Private Sub Test_BTN_Click(sender As Object, e As EventArgs) Handles Test_BTN.Click
        Dim CE As New MyCodeExecutor
        Dim C As New MyCodeFunction("Test")
        C.Code = CodeEditor.Text
        CE.ExecuteFunction(C)
        DebugOutput.Text = ""
        DebugOutput.Text = C.Results
        If Not IsNothing(C.ReturnValue) Then DebugOutput.AppendText("ReturnValue = '" & C.ReturnValue & "'")
        C.Dispose()
    End Sub

    Private Sub Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Cancel_BTN.Click
        DialogResult = DialogResult.Cancel
        Hide()
    End Sub

    Private Sub Save_BTN_Click(sender As Object, e As EventArgs) Handles Save_BTN.Click
        DialogResult = DialogResult.OK
        Hide()
    End Sub

    Private Sub FunctionsList_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles FunctionsList.MouseDoubleClick

    End Sub

End Class