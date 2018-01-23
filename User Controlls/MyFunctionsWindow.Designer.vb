<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyFunctionsWindow
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
        Me.FunctionToolStrip = New System.Windows.Forms.ToolStrip()
        Me.Plus_BTN = New System.Windows.Forms.ToolStripButton()
        Me.Minus_BTN = New System.Windows.Forms.ToolStripButton()
        Me.Edit_BTN = New System.Windows.Forms.ToolStripButton()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Hide_BTN = New System.Windows.Forms.Button()
        Me.FunctionToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'FunctionToolStrip
        '
        Me.FunctionToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.FunctionToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.FunctionToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Plus_BTN, Me.Minus_BTN, Me.Edit_BTN})
        Me.FunctionToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.FunctionToolStrip.Name = "FunctionToolStrip"
        Me.FunctionToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.FunctionToolStrip.Size = New System.Drawing.Size(249, 27)
        Me.FunctionToolStrip.TabIndex = 0
        Me.FunctionToolStrip.Text = "ToolStrip1"
        '
        'Plus_BTN
        '
        Me.Plus_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Plus_BTN.Image = Global.SPDLib.My.Resources.Resources.plus
        Me.Plus_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Plus_BTN.Name = "Plus_BTN"
        Me.Plus_BTN.Size = New System.Drawing.Size(24, 24)
        Me.Plus_BTN.Text = "Add Function"
        '
        'Minus_BTN
        '
        Me.Minus_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Minus_BTN.Image = Global.SPDLib.My.Resources.Resources.minus
        Me.Minus_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Minus_BTN.Name = "Minus_BTN"
        Me.Minus_BTN.Size = New System.Drawing.Size(24, 24)
        Me.Minus_BTN.Text = "Remove Function"
        '
        'Edit_BTN
        '
        Me.Edit_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Edit_BTN.Image = Global.SPDLib.My.Resources.Resources.edit
        Me.Edit_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Edit_BTN.Name = "Edit_BTN"
        Me.Edit_BTN.Size = New System.Drawing.Size(24, 24)
        Me.Edit_BTN.Text = "Edit Function"
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Location = New System.Drawing.Point(0, 26)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(249, 372)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Hide_BTN
        '
        Me.Hide_BTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Hide_BTN.Location = New System.Drawing.Point(9, 403)
        Me.Hide_BTN.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Hide_BTN.Name = "Hide_BTN"
        Me.Hide_BTN.Size = New System.Drawing.Size(56, 19)
        Me.Hide_BTN.TabIndex = 2
        Me.Hide_BTN.Text = "Hide"
        Me.Hide_BTN.UseVisualStyleBackColor = True
        '
        'MyFunctionsWindow
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(249, 427)
        Me.ControlBox = False
        Me.Controls.Add(Me.Hide_BTN)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.FunctionToolStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "MyFunctionsWindow"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Functions"
        Me.TopMost = True
        Me.FunctionToolStrip.ResumeLayout(False)
        Me.FunctionToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents FunctionToolStrip As ToolStrip
    Private WithEvents Plus_BTN As ToolStripButton
    Private WithEvents Minus_BTN As ToolStripButton
    Private WithEvents Edit_BTN As ToolStripButton
    Private WithEvents ListView1 As ListView
    Private WithEvents Hide_BTN As Button
End Class
