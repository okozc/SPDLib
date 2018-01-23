<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyPropertiesWindow
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
        Me.ObjectPropertyGrid = New System.Windows.Forms.PropertyGrid()
        Me.Hide_BTN = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ObjectPropertyGrid
        '
        Me.ObjectPropertyGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ObjectPropertyGrid.HelpVisible = False
        Me.ObjectPropertyGrid.LineColor = System.Drawing.SystemColors.ControlDark
        Me.ObjectPropertyGrid.Location = New System.Drawing.Point(0, 0)
        Me.ObjectPropertyGrid.Margin = New System.Windows.Forms.Padding(2)
        Me.ObjectPropertyGrid.Name = "ObjectPropertyGrid"
        Me.ObjectPropertyGrid.Size = New System.Drawing.Size(249, 398)
        Me.ObjectPropertyGrid.TabIndex = 0
        '
        'Hide_BTN
        '
        Me.Hide_BTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Hide_BTN.Location = New System.Drawing.Point(9, 403)
        Me.Hide_BTN.Margin = New System.Windows.Forms.Padding(2)
        Me.Hide_BTN.Name = "Hide_BTN"
        Me.Hide_BTN.Size = New System.Drawing.Size(56, 19)
        Me.Hide_BTN.TabIndex = 1
        Me.Hide_BTN.Text = "Hide"
        Me.Hide_BTN.UseVisualStyleBackColor = True
        '
        'MyPropertiesWindow
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(249, 427)
        Me.ControlBox = False
        Me.Controls.Add(Me.Hide_BTN)
        Me.Controls.Add(Me.ObjectPropertyGrid)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "MyPropertiesWindow"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Properties"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents ObjectPropertyGrid As PropertyGrid
    Friend WithEvents Hide_BTN As Button
End Class
