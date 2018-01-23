<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FunctionEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.FunctionsList = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DebugOutput = New System.Windows.Forms.TextBox()
        Me.Test_BTN = New System.Windows.Forms.Button()
        Me.Save_BTN = New System.Windows.Forms.Button()
        Me.Cancel_BTN = New System.Windows.Forms.Button()
        Me.CodeEditor = New SyntaxHighlighter.SyntaxRichTextBox()
        Me.SuspendLayout()
        '
        'FunctionsList
        '
        Me.FunctionsList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FunctionsList.FullRowSelect = True
        Me.FunctionsList.GridLines = True
        Me.FunctionsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.FunctionsList.Location = New System.Drawing.Point(16, 34)
        Me.FunctionsList.Margin = New System.Windows.Forms.Padding(4)
        Me.FunctionsList.Name = "FunctionsList"
        Me.FunctionsList.Size = New System.Drawing.Size(205, 538)
        Me.FunctionsList.TabIndex = 1
        Me.FunctionsList.UseCompatibleStateImageBehavior = False
        Me.FunctionsList.View = System.Windows.Forms.View.Details
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fields:"
        '
        'DebugOutput
        '
        Me.DebugOutput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DebugOutput.Location = New System.Drawing.Point(231, 374)
        Me.DebugOutput.Margin = New System.Windows.Forms.Padding(4)
        Me.DebugOutput.Multiline = True
        Me.DebugOutput.Name = "DebugOutput"
        Me.DebugOutput.ReadOnly = True
        Me.DebugOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.DebugOutput.Size = New System.Drawing.Size(741, 163)
        Me.DebugOutput.TabIndex = 3
        '
        'Test_BTN
        '
        Me.Test_BTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Test_BTN.Location = New System.Drawing.Point(231, 545)
        Me.Test_BTN.Margin = New System.Windows.Forms.Padding(4)
        Me.Test_BTN.Name = "Test_BTN"
        Me.Test_BTN.Size = New System.Drawing.Size(173, 28)
        Me.Test_BTN.TabIndex = 4
        Me.Test_BTN.Text = "Test Code"
        Me.Test_BTN.UseVisualStyleBackColor = True
        '
        'Save_BTN
        '
        Me.Save_BTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Save_BTN.Location = New System.Drawing.Point(800, 545)
        Me.Save_BTN.Margin = New System.Windows.Forms.Padding(4)
        Me.Save_BTN.Name = "Save_BTN"
        Me.Save_BTN.Size = New System.Drawing.Size(173, 28)
        Me.Save_BTN.TabIndex = 5
        Me.Save_BTN.Text = "Save"
        Me.Save_BTN.UseVisualStyleBackColor = True
        '
        'Cancel_BTN
        '
        Me.Cancel_BTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_BTN.Location = New System.Drawing.Point(619, 545)
        Me.Cancel_BTN.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_BTN.Name = "Cancel_BTN"
        Me.Cancel_BTN.Size = New System.Drawing.Size(173, 28)
        Me.Cancel_BTN.TabIndex = 6
        Me.Cancel_BTN.Text = "Cancel"
        Me.Cancel_BTN.UseVisualStyleBackColor = True
        '
        'CodeEditor
        '
        Me.CodeEditor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CodeEditor.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.CodeEditor.Location = New System.Drawing.Point(231, 12)
        Me.CodeEditor.Name = "CodeEditor"
        Me.CodeEditor.Size = New System.Drawing.Size(741, 355)
        Me.CodeEditor.TabIndex = 7
        Me.CodeEditor.Text = ""
        '
        'FunctionEditor
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(989, 588)
        Me.Controls.Add(Me.CodeEditor)
        Me.Controls.Add(Me.Cancel_BTN)
        Me.Controls.Add(Me.Save_BTN)
        Me.Controls.Add(Me.Test_BTN)
        Me.Controls.Add(Me.DebugOutput)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FunctionsList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FunctionEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Function Editor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Private WithEvents FunctionsList As ListView
    Private WithEvents DebugOutput As TextBox
    Private WithEvents Test_BTN As Button
    Private WithEvents Save_BTN As Button
    Private WithEvents Cancel_BTN As Button
    Private WithEvents CodeEditor As SyntaxHighlighter.SyntaxRichTextBox
End Class
