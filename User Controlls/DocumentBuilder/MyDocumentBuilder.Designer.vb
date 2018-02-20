<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyDocumentBuilder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MyDocumentBuilder))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.AddArea_BTN = New System.Windows.Forms.ToolStripButton()
        Me.RemoveArea_BTN = New System.Windows.Forms.ToolStripButton()
        Me.EditArea_BTN = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MoveAreaUp_BTN = New System.Windows.Forms.ToolStripButton()
        Me.MoveAreaDown_BTN = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SetTable_BTN = New System.Windows.Forms.Button()
        Me.DataTables_LVW = New System.Windows.Forms.ListView()
        Me.DTName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DTColumns = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fields_N_RAD = New System.Windows.Forms.RadioButton()
        Me.Fields_D_RAD = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DocName_TXT = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DocType_CMB = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Orientation_L_RAD = New System.Windows.Forms.RadioButton()
        Me.Orientation_P_RAD = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DocHeight_mm_LBL = New System.Windows.Forms.Label()
        Me.DocWidth_mm_LBL = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DocHeight_NUM = New System.Windows.Forms.NumericUpDown()
        Me.DocWidth_NUM = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Create_BTN = New System.Windows.Forms.Button()
        Me.Cancel_BTN = New System.Windows.Forms.Button()
        Me.AreaGroup = New System.Windows.Forms.GroupBox()
        Me.Set_BTN = New System.Windows.Forms.Button()
        Me.AreaHeight_mm_LBL = New System.Windows.Forms.Label()
        Me.AreaWidth_mm_LBL = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.AreaHeight_NUM = New System.Windows.Forms.NumericUpDown()
        Me.AreaWidth_NUM = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AreaList = New System.Windows.Forms.ListView()
        Me.AreaType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AreaName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AWidth = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AHeight = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DocHeight_NUM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocWidth_NUM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AreaGroup.SuspendLayout()
        CType(Me.AreaHeight_NUM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AreaWidth_NUM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddArea_BTN, Me.RemoveArea_BTN, Me.EditArea_BTN, Me.ToolStripSeparator1, Me.MoveAreaUp_BTN, Me.MoveAreaDown_BTN})
        Me.ToolStrip1.Location = New System.Drawing.Point(12, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(405, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'AddArea_BTN
        '
        Me.AddArea_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AddArea_BTN.Image = Global.SPDLib.My.Resources.Resources.plus
        Me.AddArea_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddArea_BTN.Name = "AddArea_BTN"
        Me.AddArea_BTN.Size = New System.Drawing.Size(24, 22)
        Me.AddArea_BTN.Text = "Add Area"
        '
        'RemoveArea_BTN
        '
        Me.RemoveArea_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RemoveArea_BTN.Image = Global.SPDLib.My.Resources.Resources.minus
        Me.RemoveArea_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RemoveArea_BTN.Name = "RemoveArea_BTN"
        Me.RemoveArea_BTN.Size = New System.Drawing.Size(24, 22)
        Me.RemoveArea_BTN.Text = "Remove Area"
        '
        'EditArea_BTN
        '
        Me.EditArea_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EditArea_BTN.Image = Global.SPDLib.My.Resources.Resources.edit
        Me.EditArea_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditArea_BTN.Name = "EditArea_BTN"
        Me.EditArea_BTN.Size = New System.Drawing.Size(24, 22)
        Me.EditArea_BTN.Text = "Edit Area"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'MoveAreaUp_BTN
        '
        Me.MoveAreaUp_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MoveAreaUp_BTN.Image = CType(resources.GetObject("MoveAreaUp_BTN.Image"), System.Drawing.Image)
        Me.MoveAreaUp_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MoveAreaUp_BTN.Name = "MoveAreaUp_BTN"
        Me.MoveAreaUp_BTN.Size = New System.Drawing.Size(24, 22)
        Me.MoveAreaUp_BTN.Text = "Move Up"
        '
        'MoveAreaDown_BTN
        '
        Me.MoveAreaDown_BTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MoveAreaDown_BTN.Image = CType(resources.GetObject("MoveAreaDown_BTN.Image"), System.Drawing.Image)
        Me.MoveAreaDown_BTN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MoveAreaDown_BTN.Name = "MoveAreaDown_BTN"
        Me.MoveAreaDown_BTN.Size = New System.Drawing.Size(24, 22)
        Me.MoveAreaDown_BTN.Text = "Move Down"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SetTable_BTN)
        Me.GroupBox1.Controls.Add(Me.DataTables_LVW)
        Me.GroupBox1.Controls.Add(Me.Fields_N_RAD)
        Me.GroupBox1.Controls.Add(Me.Fields_D_RAD)
        Me.GroupBox1.Location = New System.Drawing.Point(423, 230)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(384, 351)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fields"
        '
        'SetTable_BTN
        '
        Me.SetTable_BTN.Location = New System.Drawing.Point(318, 19)
        Me.SetTable_BTN.Name = "SetTable_BTN"
        Me.SetTable_BTN.Size = New System.Drawing.Size(52, 50)
        Me.SetTable_BTN.TabIndex = 16
        Me.SetTable_BTN.Text = "SET"
        Me.SetTable_BTN.UseVisualStyleBackColor = True
        '
        'DataTables_LVW
        '
        Me.DataTables_LVW.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.DTName, Me.DTColumns})
        Me.DataTables_LVW.FullRowSelect = True
        Me.DataTables_LVW.GridLines = True
        Me.DataTables_LVW.HideSelection = False
        Me.DataTables_LVW.Location = New System.Drawing.Point(28, 75)
        Me.DataTables_LVW.MultiSelect = False
        Me.DataTables_LVW.Name = "DataTables_LVW"
        Me.DataTables_LVW.Size = New System.Drawing.Size(342, 260)
        Me.DataTables_LVW.TabIndex = 9
        Me.DataTables_LVW.UseCompatibleStateImageBehavior = False
        Me.DataTables_LVW.View = System.Windows.Forms.View.Details
        '
        'DTName
        '
        Me.DTName.Text = "Table Name"
        Me.DTName.Width = 269
        '
        'DTColumns
        '
        Me.DTColumns.Text = "Cols"
        Me.DTColumns.Width = 42
        '
        'Fields_N_RAD
        '
        Me.Fields_N_RAD.AutoSize = True
        Me.Fields_N_RAD.Location = New System.Drawing.Point(6, 21)
        Me.Fields_N_RAD.Name = "Fields_N_RAD"
        Me.Fields_N_RAD.Size = New System.Drawing.Size(51, 17)
        Me.Fields_N_RAD.TabIndex = 8
        Me.Fields_N_RAD.TabStop = True
        Me.Fields_N_RAD.Text = "None"
        Me.Fields_N_RAD.UseVisualStyleBackColor = True
        '
        'Fields_D_RAD
        '
        Me.Fields_D_RAD.AutoSize = True
        Me.Fields_D_RAD.Location = New System.Drawing.Point(6, 48)
        Me.Fields_D_RAD.Name = "Fields_D_RAD"
        Me.Fields_D_RAD.Size = New System.Drawing.Size(75, 17)
        Me.Fields_D_RAD.TabIndex = 0
        Me.Fields_D_RAD.TabStop = True
        Me.Fields_D_RAD.Text = "DataTable"
        Me.Fields_D_RAD.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Width:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DocName_TXT)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.DocType_CMB)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Orientation_L_RAD)
        Me.GroupBox2.Controls.Add(Me.Orientation_P_RAD)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.DocHeight_mm_LBL)
        Me.GroupBox2.Controls.Add(Me.DocWidth_mm_LBL)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.DocHeight_NUM)
        Me.GroupBox2.Controls.Add(Me.DocWidth_NUM)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(423, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(384, 221)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Document"
        '
        'DocName_TXT
        '
        Me.DocName_TXT.Location = New System.Drawing.Point(75, 58)
        Me.DocName_TXT.Name = "DocName_TXT"
        Me.DocName_TXT.Size = New System.Drawing.Size(297, 20)
        Me.DocName_TXT.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Name:"
        '
        'DocType_CMB
        '
        Me.DocType_CMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DocType_CMB.FormattingEnabled = True
        Me.DocType_CMB.Items.AddRange(New Object() {"Page", "Label"})
        Me.DocType_CMB.Location = New System.Drawing.Point(75, 28)
        Me.DocType_CMB.Name = "DocType_CMB"
        Me.DocType_CMB.Size = New System.Drawing.Size(92, 21)
        Me.DocType_CMB.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Type:"
        '
        'Orientation_L_RAD
        '
        Me.Orientation_L_RAD.AutoSize = True
        Me.Orientation_L_RAD.Location = New System.Drawing.Point(75, 191)
        Me.Orientation_L_RAD.Name = "Orientation_L_RAD"
        Me.Orientation_L_RAD.Size = New System.Drawing.Size(78, 17)
        Me.Orientation_L_RAD.TabIndex = 13
        Me.Orientation_L_RAD.TabStop = True
        Me.Orientation_L_RAD.Text = "Landscape"
        Me.Orientation_L_RAD.UseVisualStyleBackColor = True
        '
        'Orientation_P_RAD
        '
        Me.Orientation_P_RAD.AutoSize = True
        Me.Orientation_P_RAD.Location = New System.Drawing.Point(75, 164)
        Me.Orientation_P_RAD.Name = "Orientation_P_RAD"
        Me.Orientation_P_RAD.Size = New System.Drawing.Size(58, 17)
        Me.Orientation_P_RAD.TabIndex = 12
        Me.Orientation_P_RAD.TabStop = True
        Me.Orientation_P_RAD.Text = "Portrait"
        Me.Orientation_P_RAD.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Orientation:"
        '
        'DocHeight_mm_LBL
        '
        Me.DocHeight_mm_LBL.AutoSize = True
        Me.DocHeight_mm_LBL.Location = New System.Drawing.Point(213, 116)
        Me.DocHeight_mm_LBL.Name = "DocHeight_mm_LBL"
        Me.DocHeight_mm_LBL.Size = New System.Drawing.Size(44, 13)
        Me.DocHeight_mm_LBL.TabIndex = 10
        Me.DocHeight_mm_LBL.Text = "888 mm"
        '
        'DocWidth_mm_LBL
        '
        Me.DocWidth_mm_LBL.AutoSize = True
        Me.DocWidth_mm_LBL.Location = New System.Drawing.Point(213, 88)
        Me.DocWidth_mm_LBL.Name = "DocWidth_mm_LBL"
        Me.DocWidth_mm_LBL.Size = New System.Drawing.Size(44, 13)
        Me.DocWidth_mm_LBL.TabIndex = 9
        Me.DocWidth_mm_LBL.Text = "888 mm"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(173, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "px ="
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(173, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "px ="
        '
        'DocHeight_NUM
        '
        Me.DocHeight_NUM.Location = New System.Drawing.Point(75, 114)
        Me.DocHeight_NUM.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.DocHeight_NUM.Name = "DocHeight_NUM"
        Me.DocHeight_NUM.Size = New System.Drawing.Size(92, 20)
        Me.DocHeight_NUM.TabIndex = 6
        '
        'DocWidth_NUM
        '
        Me.DocWidth_NUM.Location = New System.Drawing.Point(75, 86)
        Me.DocWidth_NUM.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.DocWidth_NUM.Name = "DocWidth_NUM"
        Me.DocWidth_NUM.Size = New System.Drawing.Size(92, 20)
        Me.DocWidth_NUM.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Height:"
        '
        'Create_BTN
        '
        Me.Create_BTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Create_BTN.Location = New System.Drawing.Point(731, 592)
        Me.Create_BTN.Name = "Create_BTN"
        Me.Create_BTN.Size = New System.Drawing.Size(75, 32)
        Me.Create_BTN.TabIndex = 5
        Me.Create_BTN.Text = "Create"
        Me.Create_BTN.UseVisualStyleBackColor = True
        '
        'Cancel_BTN
        '
        Me.Cancel_BTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cancel_BTN.Location = New System.Drawing.Point(12, 592)
        Me.Cancel_BTN.Name = "Cancel_BTN"
        Me.Cancel_BTN.Size = New System.Drawing.Size(75, 32)
        Me.Cancel_BTN.TabIndex = 6
        Me.Cancel_BTN.Text = "Cancel"
        Me.Cancel_BTN.UseVisualStyleBackColor = True
        '
        'AreaGroup
        '
        Me.AreaGroup.Controls.Add(Me.Set_BTN)
        Me.AreaGroup.Controls.Add(Me.AreaHeight_mm_LBL)
        Me.AreaGroup.Controls.Add(Me.AreaWidth_mm_LBL)
        Me.AreaGroup.Controls.Add(Me.Label14)
        Me.AreaGroup.Controls.Add(Me.Label15)
        Me.AreaGroup.Controls.Add(Me.AreaHeight_NUM)
        Me.AreaGroup.Controls.Add(Me.AreaWidth_NUM)
        Me.AreaGroup.Controls.Add(Me.Label11)
        Me.AreaGroup.Controls.Add(Me.Label3)
        Me.AreaGroup.Enabled = False
        Me.AreaGroup.Location = New System.Drawing.Point(12, 494)
        Me.AreaGroup.Name = "AreaGroup"
        Me.AreaGroup.Size = New System.Drawing.Size(405, 87)
        Me.AreaGroup.TabIndex = 7
        Me.AreaGroup.TabStop = False
        Me.AreaGroup.Text = "Area"
        Me.AreaGroup.Visible = False
        '
        'Set_BTN
        '
        Me.Set_BTN.Location = New System.Drawing.Point(347, 21)
        Me.Set_BTN.Name = "Set_BTN"
        Me.Set_BTN.Size = New System.Drawing.Size(52, 50)
        Me.Set_BTN.TabIndex = 15
        Me.Set_BTN.Text = "SET"
        Me.Set_BTN.UseVisualStyleBackColor = True
        '
        'AreaHeight_mm_LBL
        '
        Me.AreaHeight_mm_LBL.AutoSize = True
        Me.AreaHeight_mm_LBL.Location = New System.Drawing.Point(203, 51)
        Me.AreaHeight_mm_LBL.Name = "AreaHeight_mm_LBL"
        Me.AreaHeight_mm_LBL.Size = New System.Drawing.Size(44, 13)
        Me.AreaHeight_mm_LBL.TabIndex = 14
        Me.AreaHeight_mm_LBL.Text = "888 mm"
        '
        'AreaWidth_mm_LBL
        '
        Me.AreaWidth_mm_LBL.AutoSize = True
        Me.AreaWidth_mm_LBL.Location = New System.Drawing.Point(203, 23)
        Me.AreaWidth_mm_LBL.Name = "AreaWidth_mm_LBL"
        Me.AreaWidth_mm_LBL.Size = New System.Drawing.Size(44, 13)
        Me.AreaWidth_mm_LBL.TabIndex = 13
        Me.AreaWidth_mm_LBL.Text = "888 mm"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(163, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(27, 13)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "px ="
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(163, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(27, 13)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "px ="
        '
        'AreaHeight_NUM
        '
        Me.AreaHeight_NUM.Location = New System.Drawing.Point(65, 49)
        Me.AreaHeight_NUM.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.AreaHeight_NUM.Name = "AreaHeight_NUM"
        Me.AreaHeight_NUM.Size = New System.Drawing.Size(92, 20)
        Me.AreaHeight_NUM.TabIndex = 3
        '
        'AreaWidth_NUM
        '
        Me.AreaWidth_NUM.Location = New System.Drawing.Point(65, 21)
        Me.AreaWidth_NUM.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.AreaWidth_NUM.Name = "AreaWidth_NUM"
        Me.AreaWidth_NUM.Size = New System.Drawing.Size(92, 20)
        Me.AreaWidth_NUM.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Height:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Width:"
        '
        'AreaList
        '
        Me.AreaList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.AreaType, Me.AreaName, Me.AWidth, Me.AHeight})
        Me.AreaList.FullRowSelect = True
        Me.AreaList.GridLines = True
        Me.AreaList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.AreaList.HideSelection = False
        Me.AreaList.Location = New System.Drawing.Point(12, 31)
        Me.AreaList.MultiSelect = False
        Me.AreaList.Name = "AreaList"
        Me.AreaList.Size = New System.Drawing.Size(405, 457)
        Me.AreaList.TabIndex = 8
        Me.AreaList.UseCompatibleStateImageBehavior = False
        Me.AreaList.View = System.Windows.Forms.View.Details
        '
        'AreaType
        '
        Me.AreaType.Text = "Type"
        Me.AreaType.Width = 123
        '
        'AreaName
        '
        Me.AreaName.Text = "Name"
        Me.AreaName.Width = 164
        '
        'AWidth
        '
        Me.AWidth.Text = "W"
        Me.AWidth.Width = 47
        '
        'AHeight
        '
        Me.AHeight.Text = "H"
        Me.AHeight.Width = 43
        '
        'MyDocumentBuilder
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(818, 636)
        Me.ControlBox = False
        Me.Controls.Add(Me.AreaList)
        Me.Controls.Add(Me.AreaGroup)
        Me.Controls.Add(Me.Cancel_BTN)
        Me.Controls.Add(Me.Create_BTN)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "MyDocumentBuilder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Document Builder"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DocHeight_NUM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocWidth_NUM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AreaGroup.ResumeLayout(False)
        Me.AreaGroup.PerformLayout()
        CType(Me.AreaHeight_NUM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AreaWidth_NUM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AddArea_BTN As ToolStripButton
    Friend WithEvents RemoveArea_BTN As ToolStripButton
    Friend WithEvents EditArea_BTN As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents MoveAreaUp_BTN As ToolStripButton
    Friend WithEvents MoveAreaDown_BTN As ToolStripButton
    Friend WithEvents DTName As ColumnHeader
    Friend WithEvents DTColumns As ColumnHeader
    Private WithEvents ToolStrip1 As ToolStrip
    Private WithEvents GroupBox1 As GroupBox
    Private WithEvents Fields_D_RAD As RadioButton
    Private WithEvents Fields_N_RAD As RadioButton
    Private WithEvents Label4 As Label
    Private WithEvents GroupBox2 As GroupBox
    Private WithEvents Orientation_L_RAD As RadioButton
    Private WithEvents Orientation_P_RAD As RadioButton
    Private WithEvents Label10 As Label
    Private WithEvents DocHeight_mm_LBL As Label
    Private WithEvents DocWidth_mm_LBL As Label
    Private WithEvents Label7 As Label
    Private WithEvents Label6 As Label
    Private WithEvents DocHeight_NUM As NumericUpDown
    Private WithEvents DocWidth_NUM As NumericUpDown
    Private WithEvents Label5 As Label
    Private WithEvents DataTables_LVW As ListView
    Private WithEvents Create_BTN As Button
    Private WithEvents Cancel_BTN As Button
    Private WithEvents DocType_CMB As ComboBox
    Private WithEvents Label1 As Label
    Private WithEvents DocName_TXT As TextBox
    Private WithEvents Label2 As Label
    Private WithEvents AreaGroup As GroupBox
    Private WithEvents AreaHeight_mm_LBL As Label
    Private WithEvents AreaWidth_mm_LBL As Label
    Private WithEvents Label14 As Label
    Private WithEvents Label15 As Label
    Private WithEvents AreaHeight_NUM As NumericUpDown
    Private WithEvents AreaWidth_NUM As NumericUpDown
    Private WithEvents Label11 As Label
    Private WithEvents Label3 As Label
    Private WithEvents AreaList As ListView
    Private WithEvents AreaType As ColumnHeader
    Private WithEvents AreaName As ColumnHeader
    Friend WithEvents AWidth As ColumnHeader
    Friend WithEvents AHeight As ColumnHeader
    Friend WithEvents Set_BTN As Button
    Friend WithEvents SetTable_BTN As Button
End Class
