<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DesignerControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DesignerControl))
        Me.ToolMenu = New System.Windows.Forms.ToolStrip()
        Me.Pointer_BTN = New System.Windows.Forms.ToolStripButton()
        Me.Line_BTN = New System.Windows.Forms.ToolStripButton()
        Me.Rectangle_BTN = New System.Windows.Forms.ToolStripButton()
        Me.Elypse_BTN = New System.Windows.Forms.ToolStripButton()
        Me.Text_BTN = New System.Windows.Forms.ToolStripButton()
        Me.Picture_BTN = New System.Windows.Forms.ToolStripButton()
        Me.Data_BTN = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Code39_BTN = New System.Windows.Forms.ToolStripButton()
        Me.Code39EX_BTN = New System.Windows.Forms.ToolStripButton()
        Me.Code128_BTN = New System.Windows.Forms.ToolStripButton()
        Me.GS1_128_BTN = New System.Windows.Forms.ToolStripButton()
        Me.QrCode_BTN = New System.Windows.Forms.ToolStripButton()
        Me.DataMatrix_BTN = New System.Windows.Forms.ToolStripButton()
        Me.CanvasBackground = New System.Windows.Forms.Panel()
        Me.FunctionImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.TopToolMenu = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLeftSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToFront_BTN = New System.Windows.Forms.ToolStripButton()
        Me.ToBack_BTN = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Font_BTN = New System.Windows.Forms.ToolStripButton()
        Me.FontColor_BTN = New System.Windows.Forms.ToolStripButton()
        Me.BackColorBTN = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton3 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TextAlignmentDropDown = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AlignTextLeft_BTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlignTextCenter_BTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlignTextRight_BTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlignTextTop_BTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlignTextMiddle_BTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlignTextBottom_BTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BorderDropDown = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BorderNone_BTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorderTop_BTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorderLeft_BTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorderBottom_BTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorderRight_BTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorderAll_BTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.AlignLeft_BTN = New System.Windows.Forms.ToolStripButton()
        Me.AlignCenter_BTN = New System.Windows.Forms.ToolStripButton()
        Me.AlignRight_BTN = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.AlignTop_BTN = New System.Windows.Forms.ToolStripButton()
        Me.AlignMiddle_BTN = New System.Windows.Forms.ToolStripButton()
        Me.AlignBottom_BTN = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.SameWidth_l_BTN = New System.Windows.Forms.ToolStripButton()
        Me.SameWidth_s_BTN = New System.Windows.Forms.ToolStripButton()
        Me.SameHeight_l_BTN = New System.Windows.Forms.ToolStripButton()
        Me.SameHeight_s_BTN = New System.Windows.Forms.ToolStripButton()
        Me.SameAll_l_BTN = New System.Windows.Forms.ToolStripButton()
        Me.SameAll_s_BTN = New System.Windows.Forms.ToolStripButton()
        Me.Center_BTN = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.Remove_BTN = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.Properties_BTN = New System.Windows.Forms.ToolStripButton()
        Me.Functions_BTN = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.About_BTN = New System.Windows.Forms.ToolStripButton()
        Me.FontSelectDialog = New System.Windows.Forms.FontDialog()
        Me.ColorSelectDialog = New System.Windows.Forms.ColorDialog()
        Me.ToolMenu.SuspendLayout()
        Me.TopToolMenu.SuspendLayout()
        Me.TextAlignmentDropDown.SuspendLayout()
        Me.BorderDropDown.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolMenu
        '
        Me.ToolMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ToolMenu.AutoSize = False
        Me.ToolMenu.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolMenu.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Pointer_BTN, Me.Line_BTN, Me.Rectangle_BTN, Me.Elypse_BTN, Me.Text_BTN, Me.Picture_BTN, Me.Data_BTN, Me.ToolStripButton1, Me.Code39_BTN, Me.Code39EX_BTN, Me.Code128_BTN, Me.GS1_128_BTN, Me.QrCode_BTN, Me.DataMatrix_BTN})
        Me.ToolMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table
        Me.ToolMenu.Location = New System.Drawing.Point(0, 33)
        Me.ToolMenu.Name = "ToolMenu"
        Me.ToolMenu.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolMenu.Size = New System.Drawing.Size(32, 608)
        Me.ToolMenu.TabIndex = 0
        Me.ToolMenu.Text = "ToolStrip1"
        '
        'Pointer_BTN
        '
        Me.Pointer_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Pointer_BTN.Image = Global.SPDLib.My.Resources.Resources.arrow
        Me.Pointer_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Pointer_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Pointer_BTN.Name = "Pointer_BTN"
        Me.Pointer_BTN.Size = New System.Drawing.Size(28, 28)
        Me.Pointer_BTN.Text = "Pointer"
        '
        'Line_BTN
        '
        Me.Line_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Line_BTN.Image = Global.SPDLib.My.Resources.Resources.line1
        Me.Line_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Line_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Line_BTN.Name = "Line_BTN"
        Me.Line_BTN.Size = New System.Drawing.Size(28, 28)
        Me.Line_BTN.Text = "Line"
        '
        'Rectangle_BTN
        '
        Me.Rectangle_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Rectangle_BTN.Image = Global.SPDLib.My.Resources.Resources.rectangle1
        Me.Rectangle_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Rectangle_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Rectangle_BTN.Name = "Rectangle_BTN"
        Me.Rectangle_BTN.Size = New System.Drawing.Size(28, 28)
        Me.Rectangle_BTN.Text = "Rectangle"
        '
        'Elypse_BTN
        '
        Me.Elypse_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Elypse_BTN.Image = Global.SPDLib.My.Resources.Resources.circle
        Me.Elypse_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Elypse_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Elypse_BTN.Name = "Elypse_BTN"
        Me.Elypse_BTN.Size = New System.Drawing.Size(28, 28)
        Me.Elypse_BTN.Text = "Elypse"
        '
        'Text_BTN
        '
        Me.Text_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Text_BTN.Image = Global.SPDLib.My.Resources.Resources.text1
        Me.Text_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Text_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Text_BTN.Name = "Text_BTN"
        Me.Text_BTN.Size = New System.Drawing.Size(28, 28)
        Me.Text_BTN.Text = "Text"
        '
        'Picture_BTN
        '
        Me.Picture_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Picture_BTN.Image = Global.SPDLib.My.Resources.Resources.picture1
        Me.Picture_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Picture_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Picture_BTN.Name = "Picture_BTN"
        Me.Picture_BTN.Size = New System.Drawing.Size(28, 28)
        Me.Picture_BTN.Text = "Picture"
        '
        'Data_BTN
        '
        Me.Data_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Data_BTN.Image = Global.SPDLib.My.Resources.Resources.data
        Me.Data_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Data_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Data_BTN.Name = "Data_BTN"
        Me.Data_BTN.Size = New System.Drawing.Size(28, 28)
        Me.Data_BTN.Text = "Data"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.SPDLib.My.Resources.Resources.combined
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'Code39_BTN
        '
        Me.Code39_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Code39_BTN.Image = Global.SPDLib.My.Resources.Resources.barcode
        Me.Code39_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Code39_BTN.Name = "Code39_BTN"
        Me.Code39_BTN.Size = New System.Drawing.Size(28, 28)
        Me.Code39_BTN.Text = "Code39"
        '
        'Code39EX_BTN
        '
        Me.Code39EX_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Code39EX_BTN.Image = Global.SPDLib.My.Resources.Resources.barcode
        Me.Code39EX_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Code39EX_BTN.Name = "Code39EX_BTN"
        Me.Code39EX_BTN.Size = New System.Drawing.Size(28, 28)
        Me.Code39EX_BTN.Text = "Code39 Extended"
        '
        'Code128_BTN
        '
        Me.Code128_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Code128_BTN.Image = Global.SPDLib.My.Resources.Resources.barcode
        Me.Code128_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Code128_BTN.Name = "Code128_BTN"
        Me.Code128_BTN.Size = New System.Drawing.Size(28, 28)
        Me.Code128_BTN.Text = "Code128"
        '
        'GS1_128_BTN
        '
        Me.GS1_128_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.GS1_128_BTN.Image = Global.SPDLib.My.Resources.Resources.barcode
        Me.GS1_128_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GS1_128_BTN.Name = "GS1_128_BTN"
        Me.GS1_128_BTN.Size = New System.Drawing.Size(28, 28)
        Me.GS1_128_BTN.Text = "GS1-128"
        '
        'QrCode_BTN
        '
        Me.QrCode_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.QrCode_BTN.Image = Global.SPDLib.My.Resources.Resources.qrcode
        Me.QrCode_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.QrCode_BTN.Name = "QrCode_BTN"
        Me.QrCode_BTN.Size = New System.Drawing.Size(28, 28)
        Me.QrCode_BTN.Text = "QR Code"
        '
        'DataMatrix_BTN
        '
        Me.DataMatrix_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DataMatrix_BTN.Image = Global.SPDLib.My.Resources.Resources.datamatrix
        Me.DataMatrix_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DataMatrix_BTN.Name = "DataMatrix_BTN"
        Me.DataMatrix_BTN.Size = New System.Drawing.Size(28, 28)
        Me.DataMatrix_BTN.Text = "DataMatrix"
        '
        'CanvasBackground
        '
        Me.CanvasBackground.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CanvasBackground.AutoScroll = True
        Me.CanvasBackground.BackColor = System.Drawing.Color.Silver
        Me.CanvasBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CanvasBackground.Location = New System.Drawing.Point(32, 32)
        Me.CanvasBackground.Margin = New System.Windows.Forms.Padding(4)
        Me.CanvasBackground.Name = "CanvasBackground"
        Me.CanvasBackground.Size = New System.Drawing.Size(952, 609)
        Me.CanvasBackground.TabIndex = 0
        '
        'FunctionImageList
        '
        Me.FunctionImageList.ImageStream = CType(resources.GetObject("FunctionImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.FunctionImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.FunctionImageList.Images.SetKeyName(0, "function.png")
        Me.FunctionImageList.Images.SetKeyName(1, "static.png")
        '
        'TopToolMenu
        '
        Me.TopToolMenu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TopToolMenu.AutoSize = False
        Me.TopToolMenu.Dock = System.Windows.Forms.DockStyle.None
        Me.TopToolMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TopToolMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.TopToolMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLeftSeparator, Me.ToFront_BTN, Me.ToBack_BTN, Me.ToolStripSeparator2, Me.Font_BTN, Me.FontColor_BTN, Me.BackColorBTN, Me.ToolStripDropDownButton3, Me.ToolStripDropDownButton2, Me.ToolStripSeparator8, Me.AlignLeft_BTN, Me.AlignCenter_BTN, Me.AlignRight_BTN, Me.ToolStripSeparator3, Me.AlignTop_BTN, Me.AlignMiddle_BTN, Me.AlignBottom_BTN, Me.ToolStripSeparator4, Me.SameWidth_l_BTN, Me.SameWidth_s_BTN, Me.SameHeight_l_BTN, Me.SameHeight_s_BTN, Me.SameAll_l_BTN, Me.SameAll_s_BTN, Me.Center_BTN, Me.ToolStripSeparator6, Me.Remove_BTN, Me.ToolStripSeparator7, Me.Properties_BTN, Me.Functions_BTN, Me.ToolStripSeparator5, Me.About_BTN})
        Me.TopToolMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.TopToolMenu.Location = New System.Drawing.Point(32, 0)
        Me.TopToolMenu.Name = "TopToolMenu"
        Me.TopToolMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TopToolMenu.Size = New System.Drawing.Size(952, 33)
        Me.TopToolMenu.TabIndex = 3
        Me.TopToolMenu.Text = "ToolStrip1"
        '
        'ToolStripLeftSeparator
        '
        Me.ToolStripLeftSeparator.Margin = New System.Windows.Forms.Padding(100, 0, 0, 0)
        Me.ToolStripLeftSeparator.Name = "ToolStripLeftSeparator"
        Me.ToolStripLeftSeparator.Size = New System.Drawing.Size(6, 33)
        '
        'ToFront_BTN
        '
        Me.ToFront_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToFront_BTN.Image = Global.SPDLib.My.Resources.Resources.tofront
        Me.ToFront_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToFront_BTN.Name = "ToFront_BTN"
        Me.ToFront_BTN.Size = New System.Drawing.Size(24, 30)
        Me.ToFront_BTN.Text = "To Front"
        '
        'ToBack_BTN
        '
        Me.ToBack_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToBack_BTN.Image = Global.SPDLib.My.Resources.Resources.toback
        Me.ToBack_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToBack_BTN.Name = "ToBack_BTN"
        Me.ToBack_BTN.Size = New System.Drawing.Size(24, 30)
        Me.ToBack_BTN.Text = "To Back"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 33)
        '
        'Font_BTN
        '
        Me.Font_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Font_BTN.Image = Global.SPDLib.My.Resources.Resources.font
        Me.Font_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Font_BTN.Name = "Font_BTN"
        Me.Font_BTN.Size = New System.Drawing.Size(24, 30)
        Me.Font_BTN.Text = "Font"
        '
        'FontColor_BTN
        '
        Me.FontColor_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FontColor_BTN.Image = Global.SPDLib.My.Resources.Resources.font_color
        Me.FontColor_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FontColor_BTN.Name = "FontColor_BTN"
        Me.FontColor_BTN.Size = New System.Drawing.Size(24, 30)
        Me.FontColor_BTN.Text = "Font Color"
        '
        'BackColorBTN
        '
        Me.BackColorBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BackColorBTN.Image = Global.SPDLib.My.Resources.Resources.back_color
        Me.BackColorBTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BackColorBTN.Name = "BackColorBTN"
        Me.BackColorBTN.Size = New System.Drawing.Size(24, 30)
        Me.BackColorBTN.Text = "Background Color"
        '
        'ToolStripDropDownButton3
        '
        Me.ToolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton3.DropDown = Me.TextAlignmentDropDown
        Me.ToolStripDropDownButton3.Image = Global.SPDLib.My.Resources.Resources.algn_tleft
        Me.ToolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton3.Name = "ToolStripDropDownButton3"
        Me.ToolStripDropDownButton3.Size = New System.Drawing.Size(33, 30)
        Me.ToolStripDropDownButton3.Text = "Text Alignment"
        '
        'TextAlignmentDropDown
        '
        Me.TextAlignmentDropDown.AutoSize = False
        Me.TextAlignmentDropDown.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.TextAlignmentDropDown.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlignTextLeft_BTN, Me.AlignTextCenter_BTN, Me.AlignTextRight_BTN, Me.AlignTextTop_BTN, Me.AlignTextMiddle_BTN, Me.AlignTextBottom_BTN})
        Me.TextAlignmentDropDown.Name = "TextAlignmentDropDown"
        Me.TextAlignmentDropDown.OwnerItem = Me.ToolStripDropDownButton3
        Me.TextAlignmentDropDown.Size = New System.Drawing.Size(30, 160)
        '
        'AlignTextLeft_BTN
        '
        Me.AlignTextLeft_BTN.AutoToolTip = True
        Me.AlignTextLeft_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AlignTextLeft_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_tleft
        Me.AlignTextLeft_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AlignTextLeft_BTN.Name = "AlignTextLeft_BTN"
        Me.AlignTextLeft_BTN.Size = New System.Drawing.Size(118, 26)
        Me.AlignTextLeft_BTN.Text = "Left"
        '
        'AlignTextCenter_BTN
        '
        Me.AlignTextCenter_BTN.AutoToolTip = True
        Me.AlignTextCenter_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AlignTextCenter_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_tcenter
        Me.AlignTextCenter_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AlignTextCenter_BTN.Name = "AlignTextCenter_BTN"
        Me.AlignTextCenter_BTN.Size = New System.Drawing.Size(118, 26)
        Me.AlignTextCenter_BTN.Text = "Center"
        '
        'AlignTextRight_BTN
        '
        Me.AlignTextRight_BTN.AutoToolTip = True
        Me.AlignTextRight_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AlignTextRight_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_tright
        Me.AlignTextRight_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AlignTextRight_BTN.Name = "AlignTextRight_BTN"
        Me.AlignTextRight_BTN.Size = New System.Drawing.Size(118, 26)
        Me.AlignTextRight_BTN.Text = "Right"
        '
        'AlignTextTop_BTN
        '
        Me.AlignTextTop_BTN.AutoToolTip = True
        Me.AlignTextTop_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AlignTextTop_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_ttop
        Me.AlignTextTop_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AlignTextTop_BTN.Name = "AlignTextTop_BTN"
        Me.AlignTextTop_BTN.Size = New System.Drawing.Size(118, 26)
        Me.AlignTextTop_BTN.Text = "Top"
        '
        'AlignTextMiddle_BTN
        '
        Me.AlignTextMiddle_BTN.AutoToolTip = True
        Me.AlignTextMiddle_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AlignTextMiddle_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_tmiddle
        Me.AlignTextMiddle_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AlignTextMiddle_BTN.Name = "AlignTextMiddle_BTN"
        Me.AlignTextMiddle_BTN.Size = New System.Drawing.Size(118, 26)
        Me.AlignTextMiddle_BTN.Text = "Middle"
        '
        'AlignTextBottom_BTN
        '
        Me.AlignTextBottom_BTN.AutoToolTip = True
        Me.AlignTextBottom_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AlignTextBottom_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_tbottom
        Me.AlignTextBottom_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AlignTextBottom_BTN.Name = "AlignTextBottom_BTN"
        Me.AlignTextBottom_BTN.Size = New System.Drawing.Size(118, 26)
        Me.AlignTextBottom_BTN.Text = "Bottom"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton2.DropDown = Me.BorderDropDown
        Me.ToolStripDropDownButton2.Image = Global.SPDLib.My.Resources.Resources.border_none
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(33, 30)
        Me.ToolStripDropDownButton2.Text = "Border"
        '
        'BorderDropDown
        '
        Me.BorderDropDown.AutoSize = False
        Me.BorderDropDown.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BorderDropDown.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BorderNone_BTN, Me.BorderTop_BTN, Me.BorderLeft_BTN, Me.BorderBottom_BTN, Me.BorderRight_BTN, Me.BorderAll_BTN})
        Me.BorderDropDown.Name = "BorderDropDown"
        Me.BorderDropDown.OwnerItem = Me.ToolStripDropDownButton2
        Me.BorderDropDown.Size = New System.Drawing.Size(30, 160)
        '
        'BorderNone_BTN
        '
        Me.BorderNone_BTN.AutoToolTip = True
        Me.BorderNone_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BorderNone_BTN.Image = Global.SPDLib.My.Resources.Resources.border_none
        Me.BorderNone_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BorderNone_BTN.Name = "BorderNone_BTN"
        Me.BorderNone_BTN.Size = New System.Drawing.Size(118, 26)
        Me.BorderNone_BTN.Text = "None"
        '
        'BorderTop_BTN
        '
        Me.BorderTop_BTN.AutoToolTip = True
        Me.BorderTop_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BorderTop_BTN.Image = Global.SPDLib.My.Resources.Resources.border_top
        Me.BorderTop_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BorderTop_BTN.Name = "BorderTop_BTN"
        Me.BorderTop_BTN.Size = New System.Drawing.Size(118, 26)
        Me.BorderTop_BTN.Text = "Top"
        '
        'BorderLeft_BTN
        '
        Me.BorderLeft_BTN.AutoToolTip = True
        Me.BorderLeft_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BorderLeft_BTN.Image = Global.SPDLib.My.Resources.Resources.border_left
        Me.BorderLeft_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BorderLeft_BTN.Name = "BorderLeft_BTN"
        Me.BorderLeft_BTN.Size = New System.Drawing.Size(118, 26)
        Me.BorderLeft_BTN.Text = "Left"
        '
        'BorderBottom_BTN
        '
        Me.BorderBottom_BTN.AutoToolTip = True
        Me.BorderBottom_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BorderBottom_BTN.Image = Global.SPDLib.My.Resources.Resources.border_bottom
        Me.BorderBottom_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BorderBottom_BTN.Name = "BorderBottom_BTN"
        Me.BorderBottom_BTN.Size = New System.Drawing.Size(118, 26)
        Me.BorderBottom_BTN.Text = "Bottom"
        '
        'BorderRight_BTN
        '
        Me.BorderRight_BTN.AutoToolTip = True
        Me.BorderRight_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BorderRight_BTN.Image = Global.SPDLib.My.Resources.Resources.border_right
        Me.BorderRight_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BorderRight_BTN.Name = "BorderRight_BTN"
        Me.BorderRight_BTN.Size = New System.Drawing.Size(118, 26)
        Me.BorderRight_BTN.Text = "Right"
        '
        'BorderAll_BTN
        '
        Me.BorderAll_BTN.AutoToolTip = True
        Me.BorderAll_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BorderAll_BTN.Image = Global.SPDLib.My.Resources.Resources.border_all
        Me.BorderAll_BTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BorderAll_BTN.Name = "BorderAll_BTN"
        Me.BorderAll_BTN.Size = New System.Drawing.Size(118, 26)
        Me.BorderAll_BTN.Text = "All"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 33)
        '
        'AlignLeft_BTN
        '
        Me.AlignLeft_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AlignLeft_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_vleft
        Me.AlignLeft_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AlignLeft_BTN.Name = "AlignLeft_BTN"
        Me.AlignLeft_BTN.Size = New System.Drawing.Size(24, 30)
        Me.AlignLeft_BTN.Text = "Align Left"
        '
        'AlignCenter_BTN
        '
        Me.AlignCenter_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AlignCenter_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_vcenter
        Me.AlignCenter_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AlignCenter_BTN.Name = "AlignCenter_BTN"
        Me.AlignCenter_BTN.Size = New System.Drawing.Size(24, 30)
        Me.AlignCenter_BTN.Text = "Align Center"
        '
        'AlignRight_BTN
        '
        Me.AlignRight_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AlignRight_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_vright
        Me.AlignRight_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AlignRight_BTN.Name = "AlignRight_BTN"
        Me.AlignRight_BTN.Size = New System.Drawing.Size(24, 30)
        Me.AlignRight_BTN.Text = "Align Right"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 33)
        '
        'AlignTop_BTN
        '
        Me.AlignTop_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AlignTop_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_htop
        Me.AlignTop_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AlignTop_BTN.Name = "AlignTop_BTN"
        Me.AlignTop_BTN.Size = New System.Drawing.Size(24, 30)
        Me.AlignTop_BTN.Text = "Align Top"
        '
        'AlignMiddle_BTN
        '
        Me.AlignMiddle_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AlignMiddle_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_hcenter
        Me.AlignMiddle_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AlignMiddle_BTN.Name = "AlignMiddle_BTN"
        Me.AlignMiddle_BTN.Size = New System.Drawing.Size(24, 30)
        Me.AlignMiddle_BTN.Text = "Align Middle"
        '
        'AlignBottom_BTN
        '
        Me.AlignBottom_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AlignBottom_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_hbottom
        Me.AlignBottom_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AlignBottom_BTN.Name = "AlignBottom_BTN"
        Me.AlignBottom_BTN.Size = New System.Drawing.Size(24, 30)
        Me.AlignBottom_BTN.Text = "Align Bottom"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 33)
        '
        'SameWidth_l_BTN
        '
        Me.SameWidth_l_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SameWidth_l_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_swidth_l
        Me.SameWidth_l_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SameWidth_l_BTN.Name = "SameWidth_l_BTN"
        Me.SameWidth_l_BTN.Size = New System.Drawing.Size(24, 30)
        Me.SameWidth_l_BTN.Text = "Same Width (Largest)"
        '
        'SameWidth_s_BTN
        '
        Me.SameWidth_s_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SameWidth_s_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_swidth_s
        Me.SameWidth_s_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SameWidth_s_BTN.Name = "SameWidth_s_BTN"
        Me.SameWidth_s_BTN.Size = New System.Drawing.Size(24, 30)
        Me.SameWidth_s_BTN.Text = "Same Width (Smallest)"
        '
        'SameHeight_l_BTN
        '
        Me.SameHeight_l_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SameHeight_l_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_sheight_l
        Me.SameHeight_l_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SameHeight_l_BTN.Name = "SameHeight_l_BTN"
        Me.SameHeight_l_BTN.Size = New System.Drawing.Size(24, 30)
        Me.SameHeight_l_BTN.Text = "Same Height (Largest)"
        '
        'SameHeight_s_BTN
        '
        Me.SameHeight_s_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SameHeight_s_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_sheight_s
        Me.SameHeight_s_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SameHeight_s_BTN.Name = "SameHeight_s_BTN"
        Me.SameHeight_s_BTN.Size = New System.Drawing.Size(24, 30)
        Me.SameHeight_s_BTN.Text = "Same Height (Smallest)"
        '
        'SameAll_l_BTN
        '
        Me.SameAll_l_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SameAll_l_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_sall_l
        Me.SameAll_l_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SameAll_l_BTN.Name = "SameAll_l_BTN"
        Me.SameAll_l_BTN.Size = New System.Drawing.Size(24, 30)
        Me.SameAll_l_BTN.Text = "Same All (Largest)"
        '
        'SameAll_s_BTN
        '
        Me.SameAll_s_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SameAll_s_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_sall_s
        Me.SameAll_s_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SameAll_s_BTN.Name = "SameAll_s_BTN"
        Me.SameAll_s_BTN.Size = New System.Drawing.Size(24, 30)
        Me.SameAll_s_BTN.Text = "Same All (Smallest)"
        '
        'Center_BTN
        '
        Me.Center_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Center_BTN.Image = Global.SPDLib.My.Resources.Resources.algn_dcenter
        Me.Center_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Center_BTN.Name = "Center_BTN"
        Me.Center_BTN.Size = New System.Drawing.Size(24, 30)
        Me.Center_BTN.Text = "Center"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 33)
        '
        'Remove_BTN
        '
        Me.Remove_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Remove_BTN.Image = Global.SPDLib.My.Resources.Resources.deletedoc
        Me.Remove_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Remove_BTN.Name = "Remove_BTN"
        Me.Remove_BTN.Size = New System.Drawing.Size(24, 30)
        Me.Remove_BTN.Text = "Remove"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 33)
        '
        'Properties_BTN
        '
        Me.Properties_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Properties_BTN.Image = Global.SPDLib.My.Resources.Resources.properties
        Me.Properties_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Properties_BTN.Name = "Properties_BTN"
        Me.Properties_BTN.Size = New System.Drawing.Size(24, 30)
        Me.Properties_BTN.Text = "Object Properties"
        '
        'Functions_BTN
        '
        Me.Functions_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Functions_BTN.Image = Global.SPDLib.My.Resources.Resources._function
        Me.Functions_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Functions_BTN.Name = "Functions_BTN"
        Me.Functions_BTN.Size = New System.Drawing.Size(24, 30)
        Me.Functions_BTN.Text = "Functions"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 33)
        '
        'About_BTN
        '
        Me.About_BTN.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.About_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.About_BTN.Image = Global.SPDLib.My.Resources.Resources.about
        Me.About_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.About_BTN.Name = "About_BTN"
        Me.About_BTN.Size = New System.Drawing.Size(24, 30)
        Me.About_BTN.Text = "About"
        '
        'ColorSelectDialog
        '
        Me.ColorSelectDialog.AnyColor = True
        Me.ColorSelectDialog.FullOpen = True
        '
        'DesignerControl
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoScroll = True
        Me.Controls.Add(Me.CanvasBackground)
        Me.Controls.Add(Me.TopToolMenu)
        Me.Controls.Add(Me.ToolMenu)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "DesignerControl"
        Me.Size = New System.Drawing.Size(989, 646)
        Me.ToolMenu.ResumeLayout(False)
        Me.ToolMenu.PerformLayout()
        Me.TopToolMenu.ResumeLayout(False)
        Me.TopToolMenu.PerformLayout()
        Me.TextAlignmentDropDown.ResumeLayout(False)
        Me.BorderDropDown.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolMenu As ToolStrip
    Friend WithEvents Pointer_BTN As ToolStripButton
    Friend WithEvents Line_BTN As ToolStripButton
    Friend WithEvents Rectangle_BTN As ToolStripButton
    Friend WithEvents Elypse_BTN As ToolStripButton
    Friend WithEvents Text_BTN As ToolStripButton
    Friend WithEvents Picture_BTN As ToolStripButton
    Friend WithEvents Data_BTN As ToolStripButton
    Friend WithEvents CanvasBackground As Panel
    Friend WithEvents FunctionImageList As ImageList
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents TopToolMenu As ToolStrip
    Friend WithEvents ToFront_BTN As ToolStripButton
    Friend WithEvents ToBack_BTN As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripLeftSeparator As ToolStripSeparator
    Friend WithEvents AlignLeft_BTN As ToolStripButton
    Friend WithEvents AlignCenter_BTN As ToolStripButton
    Friend WithEvents AlignRight_BTN As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents Properties_BTN As ToolStripButton
    Friend WithEvents Functions_BTN As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents AlignTop_BTN As ToolStripButton
    Friend WithEvents AlignMiddle_BTN As ToolStripButton
    Friend WithEvents AlignBottom_BTN As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents About_BTN As ToolStripButton
    Friend WithEvents SameWidth_l_BTN As ToolStripButton
    Friend WithEvents SameHeight_l_BTN As ToolStripButton
    Friend WithEvents SameAll_l_BTN As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents SameWidth_s_BTN As ToolStripButton
    Friend WithEvents SameHeight_s_BTN As ToolStripButton
    Friend WithEvents SameAll_s_BTN As ToolStripButton
    Friend WithEvents Center_BTN As ToolStripButton
    Friend WithEvents Font_BTN As ToolStripButton
    Friend WithEvents FontColor_BTN As ToolStripButton
    Friend WithEvents ToolStripDropDownButton3 As ToolStripDropDownButton
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents BackColorBTN As ToolStripButton
    Friend WithEvents TextAlignmentDropDown As ContextMenuStrip
    Friend WithEvents AlignTextLeft_BTN As ToolStripMenuItem
    Friend WithEvents AlignTextCenter_BTN As ToolStripMenuItem
    Friend WithEvents AlignTextRight_BTN As ToolStripMenuItem
    Friend WithEvents AlignTextTop_BTN As ToolStripMenuItem
    Friend WithEvents AlignTextMiddle_BTN As ToolStripMenuItem
    Friend WithEvents AlignTextBottom_BTN As ToolStripMenuItem
    Friend WithEvents BorderDropDown As ContextMenuStrip
    Friend WithEvents BorderNone_BTN As ToolStripMenuItem
    Friend WithEvents BorderTop_BTN As ToolStripMenuItem
    Friend WithEvents BorderLeft_BTN As ToolStripMenuItem
    Friend WithEvents BorderBottom_BTN As ToolStripMenuItem
    Friend WithEvents BorderRight_BTN As ToolStripMenuItem
    Friend WithEvents BorderAll_BTN As ToolStripMenuItem
    Friend WithEvents FontSelectDialog As FontDialog
    Friend WithEvents ColorSelectDialog As ColorDialog
    Friend WithEvents Remove_BTN As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents Code39_BTN As ToolStripButton
    Friend WithEvents Code39EX_BTN As ToolStripButton
    Friend WithEvents Code128_BTN As ToolStripButton
    Friend WithEvents GS1_128_BTN As ToolStripButton
    Friend WithEvents QrCode_BTN As ToolStripButton
    Friend WithEvents DataMatrix_BTN As ToolStripButton
End Class
