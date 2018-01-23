<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyPrintDialog
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
        Me.PreviewControl = New System.Windows.Forms.PrintPreviewControl()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Print_BTN = New System.Windows.Forms.ToolStripButton()
        Me.PrinterSetup_BTN = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Zoom_CMB = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PreviewControl
        '
        Me.PreviewControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PreviewControl.AutoZoom = False
        Me.PreviewControl.Location = New System.Drawing.Point(0, 30)
        Me.PreviewControl.Name = "PreviewControl"
        Me.PreviewControl.Size = New System.Drawing.Size(853, 649)
        Me.PreviewControl.TabIndex = 0
        Me.PreviewControl.UseAntiAlias = True
        Me.PreviewControl.Zoom = 1.0R
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Print_BTN, Me.PrinterSetup_BTN, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.Zoom_CMB, Me.ToolStripLabel2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.ShowItemToolTips = False
        Me.ToolStrip1.Size = New System.Drawing.Size(853, 31)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Print_BTN
        '
        Me.Print_BTN.Image = Global.SPDLib.My.Resources.Resources.printer
        Me.Print_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Print_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Print_BTN.Name = "Print_BTN"
        Me.Print_BTN.Size = New System.Drawing.Size(67, 28)
        Me.Print_BTN.Text = "Print"
        '
        'PrinterSetup_BTN
        '
        Me.PrinterSetup_BTN.Image = Global.SPDLib.My.Resources.Resources.printer_setup
        Me.PrinterSetup_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrinterSetup_BTN.Name = "PrinterSetup_BTN"
        Me.PrinterSetup_BTN.Size = New System.Drawing.Size(122, 28)
        Me.PrinterSetup_BTN.Text = "Printer Setup"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Image = Global.SPDLib.My.Resources.Resources.zoom
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(24, 28)
        '
        'Zoom_CMB
        '
        Me.Zoom_CMB.AutoSize = False
        Me.Zoom_CMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Zoom_CMB.Items.AddRange(New Object() {"25", "50", "75", "100", "125", "150", "175", "200", "250", "300"})
        Me.Zoom_CMB.Name = "Zoom_CMB"
        Me.Zoom_CMB.Size = New System.Drawing.Size(80, 28)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(21, 28)
        Me.ToolStripLabel2.Text = "%"
        '
        'MyPrintDialog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(853, 679)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PreviewControl)
        Me.Name = "MyPrintDialog"
        Me.Text = "Print Dialog"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Private WithEvents PreviewControl As PrintPreviewControl
    Private WithEvents ToolStrip1 As ToolStrip
    Private WithEvents Print_BTN As ToolStripButton
    Private WithEvents PrinterSetup_BTN As ToolStripButton
    Private WithEvents Zoom_CMB As ToolStripComboBox
    Private WithEvents ToolStripLabel1 As ToolStripLabel
End Class
