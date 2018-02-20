<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AreaSelector
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
        Me.AreaList = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.AreaNameTXT = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cancel_BTN = New System.Windows.Forms.Button()
        Me.OK_BTN = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AreaList
        '
        Me.AreaList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AreaList.FormattingEnabled = True
        Me.AreaList.Location = New System.Drawing.Point(95, 35)
        Me.AreaList.Name = "AreaList"
        Me.AreaList.Size = New System.Drawing.Size(209, 24)
        Me.AreaList.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.AreaNameTXT)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Cancel_BTN)
        Me.Panel1.Controls.Add(Me.OK_BTN)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.AreaList)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(317, 106)
        Me.Panel1.TabIndex = 1
        '
        'AreaNameTXT
        '
        Me.AreaNameTXT.Location = New System.Drawing.Point(95, 8)
        Me.AreaNameTXT.Margin = New System.Windows.Forms.Padding(2)
        Me.AreaNameTXT.Name = "AreaNameTXT"
        Me.AreaNameTXT.Size = New System.Drawing.Size(209, 22)
        Me.AreaNameTXT.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Area Name:"
        '
        'Cancel_BTN
        '
        Me.Cancel_BTN.Location = New System.Drawing.Point(149, 61)
        Me.Cancel_BTN.Name = "Cancel_BTN"
        Me.Cancel_BTN.Size = New System.Drawing.Size(75, 33)
        Me.Cancel_BTN.TabIndex = 3
        Me.Cancel_BTN.Text = "Cancel"
        Me.Cancel_BTN.UseVisualStyleBackColor = True
        '
        'OK_BTN
        '
        Me.OK_BTN.Location = New System.Drawing.Point(230, 61)
        Me.OK_BTN.Name = "OK_BTN"
        Me.OK_BTN.Size = New System.Drawing.Size(75, 33)
        Me.OK_BTN.TabIndex = 2
        Me.OK_BTN.Text = "OK"
        Me.OK_BTN.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Area Type:"
        '
        'AreaSelector
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(317, 106)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AreaSelector"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "AreaSelector"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents AreaList As ComboBox
    Private WithEvents Panel1 As Panel
    Private WithEvents Cancel_BTN As Button
    Private WithEvents OK_BTN As Button
    Private WithEvents Label1 As Label
    Private WithEvents AreaNameTXT As TextBox
    Private WithEvents Label2 As Label
End Class
