<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataSelector
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataSelector))
        Me.FieldsList = New System.Windows.Forms.ListView()
        Me.FieldName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FriendlyName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Cancel_BTN = New System.Windows.Forms.Button()
        Me.OK_BTN = New System.Windows.Forms.Button()
        Me.Img = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'FieldsList
        '
        Me.FieldsList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Img, Me.FieldName, Me.FriendlyName})
        Me.FieldsList.FullRowSelect = True
        Me.FieldsList.GridLines = True
        Me.FieldsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.FieldsList.Location = New System.Drawing.Point(16, 15)
        Me.FieldsList.Margin = New System.Windows.Forms.Padding(4)
        Me.FieldsList.Name = "FieldsList"
        Me.FieldsList.ShowItemToolTips = True
        Me.FieldsList.Size = New System.Drawing.Size(347, 469)
        Me.FieldsList.SmallImageList = Me.ListIcons
        Me.FieldsList.TabIndex = 0
        Me.FieldsList.UseCompatibleStateImageBehavior = False
        Me.FieldsList.View = System.Windows.Forms.View.Details
        '
        'FieldName
        '
        Me.FieldName.Text = "Name"
        Me.FieldName.Width = 125
        '
        'FriendlyName
        '
        Me.FriendlyName.Text = "Description"
        Me.FriendlyName.Width = 201
        '
        'Cancel_BTN
        '
        Me.Cancel_BTN.Location = New System.Drawing.Point(156, 492)
        Me.Cancel_BTN.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_BTN.Name = "Cancel_BTN"
        Me.Cancel_BTN.Size = New System.Drawing.Size(100, 28)
        Me.Cancel_BTN.TabIndex = 1
        Me.Cancel_BTN.Text = "Cancel"
        Me.Cancel_BTN.UseVisualStyleBackColor = True
        '
        'OK_BTN
        '
        Me.OK_BTN.Location = New System.Drawing.Point(264, 492)
        Me.OK_BTN.Margin = New System.Windows.Forms.Padding(4)
        Me.OK_BTN.Name = "OK_BTN"
        Me.OK_BTN.Size = New System.Drawing.Size(100, 28)
        Me.OK_BTN.TabIndex = 2
        Me.OK_BTN.Text = "OK"
        Me.OK_BTN.UseVisualStyleBackColor = True
        '
        'Img
        '
        Me.Img.Text = ""
        Me.Img.Width = 20
        '
        'ListIcons
        '
        Me.ListIcons.ImageStream = CType(resources.GetObject("ListIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.ListIcons.Images.SetKeyName(0, "static.png")
        Me.ListIcons.Images.SetKeyName(1, "field.png")
        Me.ListIcons.Images.SetKeyName(2, "function.png")
        '
        'DataSelector
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(380, 535)
        Me.ControlBox = False
        Me.Controls.Add(Me.OK_BTN)
        Me.Controls.Add(Me.Cancel_BTN)
        Me.Controls.Add(Me.FieldsList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "DataSelector"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Data Field ..."
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents OK_BTN As Button
    Private WithEvents Cancel_BTN As Button
    Private WithEvents FieldsList As ListView
    Friend WithEvents FieldName As ColumnHeader
    Friend WithEvents FriendlyName As ColumnHeader
    Friend WithEvents Img As ColumnHeader
    Friend WithEvents ListIcons As ImageList
End Class
