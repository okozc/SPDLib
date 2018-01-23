<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CombinedFieldBuilder
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Add_BTN = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.FType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Up_BTN = New System.Windows.Forms.Button()
        Me.Down_BTN = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Ok_BTN = New System.Windows.Forms.Button()
        Me.Cancel_BTN = New System.Windows.Forms.Button()
        Me.SelectData_BTN = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Field", "Text"})
        Me.ComboBox1.Location = New System.Drawing.Point(60, 12)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(111, 24)
        Me.ComboBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Field:"
        '
        'Add_BTN
        '
        Me.Add_BTN.Location = New System.Drawing.Point(184, 10)
        Me.Add_BTN.Name = "Add_BTN"
        Me.Add_BTN.Size = New System.Drawing.Size(61, 27)
        Me.Add_BTN.TabIndex = 2
        Me.Add_BTN.Text = "Add"
        Me.Add_BTN.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.FType, Me.FName, Me.FValue})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 42)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(347, 302)
        Me.ListView1.TabIndex = 3
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'FType
        '
        Me.FType.Text = "T"
        Me.FType.Width = 20
        '
        'FName
        '
        Me.FName.Text = "Name"
        Me.FName.Width = 84
        '
        'FValue
        '
        Me.FValue.Text = "Value"
        Me.FValue.Width = 215
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(66, 350)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(266, 54)
        Me.TextBox1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 353)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Value:"
        '
        'Up_BTN
        '
        Me.Up_BTN.Image = Global.SPDLib.My.Resources.Resources.up
        Me.Up_BTN.Location = New System.Drawing.Point(365, 67)
        Me.Up_BTN.Name = "Up_BTN"
        Me.Up_BTN.Size = New System.Drawing.Size(20, 20)
        Me.Up_BTN.TabIndex = 6
        Me.Up_BTN.UseVisualStyleBackColor = True
        '
        'Down_BTN
        '
        Me.Down_BTN.Image = Global.SPDLib.My.Resources.Resources.down
        Me.Down_BTN.Location = New System.Drawing.Point(365, 93)
        Me.Down_BTN.Name = "Down_BTN"
        Me.Down_BTN.Size = New System.Drawing.Size(20, 20)
        Me.Down_BTN.TabIndex = 7
        Me.Down_BTN.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(12, 410)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(371, 83)
        Me.TextBox2.TabIndex = 8
        '
        'Ok_BTN
        '
        Me.Ok_BTN.Location = New System.Drawing.Point(308, 499)
        Me.Ok_BTN.Name = "Ok_BTN"
        Me.Ok_BTN.Size = New System.Drawing.Size(75, 32)
        Me.Ok_BTN.TabIndex = 9
        Me.Ok_BTN.Text = "OK"
        Me.Ok_BTN.UseVisualStyleBackColor = True
        '
        'Cancel_BTN
        '
        Me.Cancel_BTN.Location = New System.Drawing.Point(12, 499)
        Me.Cancel_BTN.Name = "Cancel_BTN"
        Me.Cancel_BTN.Size = New System.Drawing.Size(75, 32)
        Me.Cancel_BTN.TabIndex = 10
        Me.Cancel_BTN.Text = "Cancel"
        Me.Cancel_BTN.UseVisualStyleBackColor = True
        '
        'SelectData_BTN
        '
        Me.SelectData_BTN.Location = New System.Drawing.Point(338, 350)
        Me.SelectData_BTN.Name = "SelectData_BTN"
        Me.SelectData_BTN.Size = New System.Drawing.Size(45, 54)
        Me.SelectData_BTN.TabIndex = 11
        Me.SelectData_BTN.Text = "..."
        Me.SelectData_BTN.UseVisualStyleBackColor = True
        '
        'CombinedFieldBuilder
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(397, 542)
        Me.ControlBox = False
        Me.Controls.Add(Me.SelectData_BTN)
        Me.Controls.Add(Me.Cancel_BTN)
        Me.Controls.Add(Me.Ok_BTN)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Down_BTN)
        Me.Controls.Add(Me.Up_BTN)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Add_BTN)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "CombinedFieldBuilder"
        Me.Text = "Combined Field Builder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Add_BTN As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents FType As ColumnHeader
    Friend WithEvents FName As ColumnHeader
    Friend WithEvents FValue As ColumnHeader
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Up_BTN As Button
    Friend WithEvents Down_BTN As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Ok_BTN As Button
    Friend WithEvents Cancel_BTN As Button
    Friend WithEvents SelectData_BTN As Button
End Class
