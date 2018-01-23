Imports System.Windows.Forms.ComponentModel

Public Class DesignerControl

    Private iDocument As MyDocument
    Private WithEvents iDrawEngine As MyDrawEngine2
    Private WithEvents iOperationsEngine As MyOperationsEngine2
    Private WithEvents iPropertiesWindow As MyPropertiesWindow
    Private iFunctionsWindow As MyFunctionsWindow
    Private iAboutBox As AboutBox
    Private iCaptureKeys As Boolean

    Public Property Document As MyDocument
        Get
            Return iDocument
        End Get
        Set(value As MyDocument)
            iDocument = value
            If Not IsNothing(iDocument) Then iDocument.SortAreas()
            iDrawEngine.Document = value
        End Set
    End Property
    Public Property ShowGrid As Boolean
        Get
            Return iDrawEngine.ShowGrid
        End Get
        Set(value As Boolean)
            iDrawEngine.ShowGrid = value
        End Set
    End Property
    Public Property GridSize As Size
        Get
            Return iDrawEngine.GridSize
        End Get
        Set(value As Size)
            iDrawEngine.GridSize = value
        End Set
    End Property
    Public Property ShowPadding As Boolean
        Get
            Return iDrawEngine.ShowPadding
        End Get
        Set(value As Boolean)
            iDrawEngine.ShowPadding = value
        End Set
    End Property
    Public Property DrawAllLabels As Boolean
        Get
            Return iDrawEngine.DrawAllLabels
        End Get
        Set(value As Boolean)
            iDrawEngine.DrawAllLabels = value
        End Set
    End Property
    Public Property CaptureKeys As Boolean
        Get
            Return iCaptureKeys
        End Get
        Set(value As Boolean)
            iCaptureKeys = value
        End Set
    End Property
    Sub New()
        InitializeComponent()
        iDrawEngine = New MyDrawEngine2(CanvasBackground, Nothing)
        iOperationsEngine = New MyOperationsEngine2(iDrawEngine)
        SetButton(AddingType.None)
        ToolStripLeftSeparator.Margin = New Padding(iDrawEngine.DocumentMargins.Left, 0, 0, 0)
        iPropertiesWindow = New MyPropertiesWindow
        iFunctionsWindow = New MyFunctionsWindow
        iAboutBox = New AboutBox
        iCaptureKeys = False
    End Sub

    Private Sub SetPropertyPane(Area As MyDocumentArea, Item() As MyItem) Handles iOperationsEngine.PropertySelect
        If IsNothing(Area) And IsNothing(Item) Then
            iPropertiesWindow.SelectObject = iDocument
            'PropertiesGrid.SelectedObject = iDocument
        Else
            If IsNothing(Item) Or Item.Count = 0 Then
                iPropertiesWindow.SelectObject = Area
                iFunctionsWindow.SelectedArea = Area
                'PropertiesGrid.SelectedObject = Area
            Else
                iPropertiesWindow.SelectObjects = Item
                'PropertiesGrid.SelectedObject = Item
            End If
        End If
        iDrawEngine.CanvasPanel.Focus()

    End Sub

    'Private Sub PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PropertiesGrid.PropertyValueChanged
    '    iDrawEngine.DocumentPanel.Invalidate()
    'End Sub
    Private Sub PropertyValueChanged() Handles iPropertiesWindow.ValueChanged
        iDrawEngine.PictureBox.Invalidate()
    End Sub
#Region "Buttons"
    Private Sub Pointer_BTN_Click(sender As Object, e As EventArgs) Handles Pointer_BTN.Click
        iOperationsEngine.DesignerOperation = MyOperationsEngine2.Operation.None
        iOperationsEngine.DesignerAddingType = AddingType.None
        SetButton(AddingType.None)
    End Sub
    Private Sub Line_BTN_Click(sender As Object, e As EventArgs) Handles Line_BTN.Click
        iOperationsEngine.DesignerOperation = MyOperationsEngine2.Operation.Adding
        iOperationsEngine.DesignerAddingType = AddingType.Line
        SetButton(AddingType.Line)
    End Sub
    Private Sub Rectangle_BTN_Click(sender As Object, e As EventArgs) Handles Rectangle_BTN.Click
        iOperationsEngine.DesignerOperation = MyOperationsEngine2.Operation.Adding
        iOperationsEngine.DesignerAddingType = AddingType.Rectangle
        SetButton(AddingType.Rectangle)
    End Sub
    Private Sub Elypse_BTN_Click(sender As Object, e As EventArgs) Handles Elypse_BTN.Click
        iOperationsEngine.DesignerOperation = MyOperationsEngine2.Operation.Adding
        iOperationsEngine.DesignerAddingType = AddingType.Circle
        SetButton(AddingType.Circle)
    End Sub
    Private Sub Text_BTN_Click(sender As Object, e As EventArgs) Handles Text_BTN.Click
        iOperationsEngine.DesignerOperation = MyOperationsEngine2.Operation.Adding
        iOperationsEngine.DesignerAddingType = AddingType.Text
        SetButton(AddingType.Text)
    End Sub
    Private Sub Picture_BTN_Click(sender As Object, e As EventArgs) Handles Picture_BTN.Click
        iOperationsEngine.DesignerOperation = MyOperationsEngine2.Operation.Adding
        iOperationsEngine.DesignerAddingType = AddingType.Picture
        SetButton(AddingType.Picture)
    End Sub
    Private Sub Data_BTN_Click(sender As Object, e As EventArgs) Handles Data_BTN.Click
        iOperationsEngine.DesignerOperation = MyOperationsEngine2.Operation.Adding
        iOperationsEngine.DesignerAddingType = AddingType.Data
        SetButton(AddingType.Data)
    End Sub
    Private Sub Code39_BTN_Click(sender As Object, e As EventArgs) Handles Code39_BTN.Click
        iOperationsEngine.DesignerOperation = MyOperationsEngine2.Operation.Adding
        iOperationsEngine.DesignerAddingType = AddingType.Code39
        SetButton(AddingType.Code39)
    End Sub
    Private Sub Code39EX_BTN_Click(sender As Object, e As EventArgs) Handles Code39EX_BTN.Click
        iOperationsEngine.DesignerOperation = MyOperationsEngine2.Operation.Adding
        iOperationsEngine.DesignerAddingType = AddingType.Code39EX
        SetButton(AddingType.Code39EX)
    End Sub
    Private Sub Code128_BTN_Click(sender As Object, e As EventArgs) Handles Code128_BTN.Click
        iOperationsEngine.DesignerOperation = MyOperationsEngine2.Operation.Adding
        iOperationsEngine.DesignerAddingType = AddingType.Code128
        SetButton(AddingType.Code128)
    End Sub
    Private Sub GS1_128_BTN_Click(sender As Object, e As EventArgs) Handles GS1_128_BTN.Click
        iOperationsEngine.DesignerOperation = MyOperationsEngine2.Operation.Adding
        iOperationsEngine.DesignerAddingType = AddingType.GS1_128
        SetButton(AddingType.GS1_128)
    End Sub
    Private Sub QrCode_BTN_Click(sender As Object, e As EventArgs) Handles QrCode_BTN.Click
        iOperationsEngine.DesignerOperation = MyOperationsEngine2.Operation.Adding
        iOperationsEngine.DesignerAddingType = AddingType.QrCode
        SetButton(AddingType.QrCode)
    End Sub
    Private Sub DataMatrix_BTN_Click(sender As Object, e As EventArgs) Handles DataMatrix_BTN.Click
        iOperationsEngine.DesignerOperation = MyOperationsEngine2.Operation.Adding
        iOperationsEngine.DesignerAddingType = AddingType.DataMatrix
        SetButton(AddingType.DataMatrix)
    End Sub
    Private Sub Properties_BTN_Click(sender As Object, e As EventArgs) Handles Properties_BTN.Click
        iPropertiesWindow.Show()
    End Sub
    Private Sub Functions_BTN_Click(sender As Object, e As EventArgs) Handles Functions_BTN.Click
        iFunctionsWindow.Show()
    End Sub
    Private Sub About_BTN_Click(sender As Object, e As EventArgs) Handles About_BTN.Click
        iAboutBox.ShowDialog()
    End Sub

    Private Sub ToFront_BTN_Click(sender As Object, e As EventArgs) Handles ToFront_BTN.Click
        iOperationsEngine.SelectedItemsToFront()
    End Sub
    Private Sub ToBack_BTN_Click(sender As Object, e As EventArgs) Handles ToBack_BTN.Click
        iOperationsEngine.SelectedItemsToBack()
    End Sub

    Private Sub Font_BTN_Click(sender As Object, e As EventArgs) Handles Font_BTN.Click
        FontSelectDialog.Font = iOperationsEngine.DefaultFont
        If FontSelectDialog.ShowDialog = DialogResult.OK Then
            iOperationsEngine.SetSelectedItemsFont(FontSelectDialog.Font)
            iOperationsEngine.DefaultFont = FontSelectDialog.Font
        End If
    End Sub
    Private Sub FontColor_BTN_Click(sender As Object, e As EventArgs) Handles FontColor_BTN.Click
        ColorSelectDialog.Color = iOperationsEngine.DefaultFontColor
        If ColorSelectDialog.ShowDialog = DialogResult.OK Then
            iOperationsEngine.SetSelectedItemsFontColor(ColorSelectDialog.Color)
            iOperationsEngine.DefaultFontColor = ColorSelectDialog.Color
        End If
    End Sub
    Private Sub BackColorBTN_Click(sender As Object, e As EventArgs) Handles BackColorBTN.Click
        ColorSelectDialog.Color = iOperationsEngine.DefaultBackColor
        If ColorSelectDialog.ShowDialog = DialogResult.OK Then
            iOperationsEngine.SetSelectedItemsBackColor(ColorSelectDialog.Color)
            iOperationsEngine.DefaultBackColor = ColorSelectDialog.Color
        End If
    End Sub
    Private Sub AlignTextLeft_BTN_Click(sender As Object, e As EventArgs) Handles AlignTextLeft_BTN.Click
        iOperationsEngine.SetSelectedItemsTextAlignment(MyOperationsEngine2.TextAlignment.Left)
    End Sub
    Private Sub AlignTextCenter_BTN_Click(sender As Object, e As EventArgs) Handles AlignTextCenter_BTN.Click
        iOperationsEngine.SetSelectedItemsTextAlignment(MyOperationsEngine2.TextAlignment.Center)
    End Sub
    Private Sub AlignTextRight_BTN_Click(sender As Object, e As EventArgs) Handles AlignTextRight_BTN.Click
        iOperationsEngine.SetSelectedItemsTextAlignment(MyOperationsEngine2.TextAlignment.Right)
    End Sub
    Private Sub AlignTextTop_BTN_Click(sender As Object, e As EventArgs) Handles AlignTextTop_BTN.Click
        iOperationsEngine.SetSelectedItemsTextAlignment(MyOperationsEngine2.TextAlignment.Top)
    End Sub
    Private Sub AlignTextMiddle_BTN_Click(sender As Object, e As EventArgs) Handles AlignTextMiddle_BTN.Click
        iOperationsEngine.SetSelectedItemsTextAlignment(MyOperationsEngine2.TextAlignment.Middle)
    End Sub
    Private Sub AlignTextBottom_BTN_Click(sender As Object, e As EventArgs) Handles AlignTextBottom_BTN.Click
        iOperationsEngine.SetSelectedItemsTextAlignment(MyOperationsEngine2.TextAlignment.Bottom)
    End Sub
    Private Sub BorderNone_BTN_Click(sender As Object, e As EventArgs) Handles BorderNone_BTN.Click
        iOperationsEngine.SetSelectedItemsBorder(MyOperationsEngine2.Border.None)
    End Sub
    Private Sub BorderTop_BTN_Click(sender As Object, e As EventArgs) Handles BorderTop_BTN.Click
        iOperationsEngine.SetSelectedItemsBorder(MyOperationsEngine2.Border.Top)
    End Sub
    Private Sub BorderLeft_BTN_Click(sender As Object, e As EventArgs) Handles BorderLeft_BTN.Click
        iOperationsEngine.SetSelectedItemsBorder(MyOperationsEngine2.Border.Left)
    End Sub
    Private Sub BorderBottom_BTN_Click(sender As Object, e As EventArgs) Handles BorderBottom_BTN.Click
        iOperationsEngine.SetSelectedItemsBorder(MyOperationsEngine2.Border.Bottom)
    End Sub
    Private Sub BorderRight_BTN_Click(sender As Object, e As EventArgs) Handles BorderRight_BTN.Click
        iOperationsEngine.SetSelectedItemsBorder(MyOperationsEngine2.Border.Right)
    End Sub
    Private Sub BorderAll_BTN_Click(sender As Object, e As EventArgs) Handles BorderAll_BTN.Click
        iOperationsEngine.SetSelectedItemsBorder(MyOperationsEngine2.Border.All)
    End Sub

    Private Sub AlignLeft_BTN_Click(sender As Object, e As EventArgs) Handles AlignLeft_BTN.Click
        iOperationsEngine.AlignSelectedItems(MyOperationsEngine2.ItemAlignment.Left)
    End Sub
    Private Sub AlignCenter_BTN_Click(sender As Object, e As EventArgs) Handles AlignCenter_BTN.Click
        iOperationsEngine.AlignSelectedItems(MyOperationsEngine2.ItemAlignment.Center)
    End Sub
    Private Sub AlignRight_BTN_Click(sender As Object, e As EventArgs) Handles AlignRight_BTN.Click
        iOperationsEngine.AlignSelectedItems(MyOperationsEngine2.ItemAlignment.Right)
    End Sub
    Private Sub AlignTop_BTN_Click(sender As Object, e As EventArgs) Handles AlignTop_BTN.Click
        iOperationsEngine.AlignSelectedItems(MyOperationsEngine2.ItemAlignment.Top)
    End Sub
    Private Sub AlignMiddle_BTN_Click(sender As Object, e As EventArgs) Handles AlignMiddle_BTN.Click
        iOperationsEngine.AlignSelectedItems(MyOperationsEngine2.ItemAlignment.Middle)
    End Sub
    Private Sub AlignBottom_BTN_Click(sender As Object, e As EventArgs) Handles AlignBottom_BTN.Click
        iOperationsEngine.AlignSelectedItems(MyOperationsEngine2.ItemAlignment.Bottom)
    End Sub
    Private Sub Center_BTN_Click(sender As Object, e As EventArgs) Handles Center_BTN.Click
        iOperationsEngine.AlignSelectedItems(MyOperationsEngine2.ItemAlignment.CenterArea)
    End Sub

    Private Sub SameWidth_l_BTN_Click(sender As Object, e As EventArgs) Handles SameWidth_l_BTN.Click
        iOperationsEngine.ModifySelectedItemsSize(MyOperationsEngine2.ModifyItemSize.SameWidth_Largest)
    End Sub
    Private Sub SameWidth_s_BTN_Click(sender As Object, e As EventArgs) Handles SameWidth_s_BTN.Click
        iOperationsEngine.ModifySelectedItemsSize(MyOperationsEngine2.ModifyItemSize.SameWidth_Smallest)
    End Sub
    Private Sub SameHeight_l_BTN_Click(sender As Object, e As EventArgs) Handles SameHeight_l_BTN.Click
        iOperationsEngine.ModifySelectedItemsSize(MyOperationsEngine2.ModifyItemSize.SameHeight_Largest)
    End Sub
    Private Sub SameHeight_s_BTN_Click(sender As Object, e As EventArgs) Handles SameHeight_s_BTN.Click
        iOperationsEngine.ModifySelectedItemsSize(MyOperationsEngine2.ModifyItemSize.SameHeight_Smallest)
    End Sub
    Private Sub SameAll_l_BTN_Click(sender As Object, e As EventArgs) Handles SameAll_l_BTN.Click
        iOperationsEngine.ModifySelectedItemsSize(MyOperationsEngine2.ModifyItemSize.SameAll_Largest)
    End Sub
    Private Sub SameAll_s_BTN_Click(sender As Object, e As EventArgs) Handles SameAll_s_BTN.Click
        iOperationsEngine.ModifySelectedItemsSize(MyOperationsEngine2.ModifyItemSize.SameAll_Smallest)
    End Sub
    Private Sub Remove_BTN_Click(sender As Object, e As EventArgs) Handles Remove_BTN.Click
        If iDrawEngine.SelectedItems.Count > 0 Then
            If MsgBox("Deleting " & iDrawEngine.SelectedItems.Count.ToString & " Item(s)." & vbCrLf & "Are You Sure?",
                  MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Delete") = MsgBoxResult.Yes Then
                iOperationsEngine.RemoveSelectedItems()
            End If
        End If
    End Sub
#End Region

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If iCaptureKeys Then
            Dim Distance As Integer = 5
            Dim Key As Keys = keyData
            If Key.HasFlag(Keys.Control) Then
                Distance = 1
                Key -= Keys.Control
            End If
            If Key.HasFlag(Keys.Shift) Then
                Distance = 10
                Key -= Keys.Shift
            End If
            Select Case Key
                Case Keys.Up
                    iOperationsEngine.MoveSelectedItems(MyOperationsEngine2.MovementDirection.Up, Distance)
                    Return True
                Case Keys.Down
                    iOperationsEngine.MoveSelectedItems(MyOperationsEngine2.MovementDirection.Down, Distance)
                    Return True
                Case Keys.Left
                    iOperationsEngine.MoveSelectedItems(MyOperationsEngine2.MovementDirection.Left, Distance)
                    Return True
                Case Keys.Right
                    iOperationsEngine.MoveSelectedItems(MyOperationsEngine2.MovementDirection.Right, Distance)
                    Return True
                Case Keys.Delete
                    If iDrawEngine.SelectedItems.Count > 0 Then
                        If MsgBox("Deleting " & iDrawEngine.SelectedItems.Count.ToString & " Item(s)." & vbCrLf & "Are You Sure?",
                              MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Delete") = MsgBoxResult.Yes Then
                            iOperationsEngine.RemoveSelectedItems()
                        End If
                    End If
                    Return True
            End Select
            'Debug.WriteLine(keyData.ToString)
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub SetButton(DesignerAddingType As AddingType)
        For Each Itm As ToolStripItem In ToolMenu.Items
            If Itm.GetType = GetType(ToolStripButton) Then
                Dim Btn As ToolStripButton = CType(Itm, ToolStripButton)
                Btn.Checked = False
            End If
        Next
        Select Case DesignerAddingType
            Case AddingType.None
                Pointer_BTN.Checked = True
            Case AddingType.Line
                Line_BTN.Checked = True
            Case AddingType.Rectangle
                Rectangle_BTN.Checked = True
            Case AddingType.Circle
                Elypse_BTN.Checked = True
            Case AddingType.Text
                Text_BTN.Checked = True
            Case AddingType.Picture
                Picture_BTN.Checked = True
            Case AddingType.Code39
                Code39_BTN.Checked = True
            Case AddingType.Code39EX
                Code39EX_BTN.Checked = True
            Case AddingType.Code128
                Code128_BTN.Checked = True
            Case AddingType.GS1_128
                GS1_128_BTN.Checked = True
            Case AddingType.QrCode
                QrCode_BTN.Checked = True
            Case AddingType.DataMatrix
                DataMatrix_BTN.Checked = True
            Case AddingType.Data
                Data_BTN.Checked = True
        End Select
    End Sub

#Region "Event Handlers"
    Private Sub AddOperationComplete() Handles iOperationsEngine.AddOperationDone
        SetButton(AddingType.None)
    End Sub

#End Region


    Private Sub iDispose() Handles Me.Disposed
        iDocument = Nothing
        If Not IsNothing(iDrawEngine) Then iDrawEngine.Dispose()
        iDrawEngine = Nothing
        If Not IsNothing(iOperationsEngine) Then iOperationsEngine.Dispose()
        iOperationsEngine = Nothing
        If Not IsNothing(iPropertiesWindow) Then iPropertiesWindow.Dispose()
        iPropertiesWindow = Nothing
        If Not IsNothing(iFunctionsWindow) Then iFunctionsWindow.Dispose()
        iFunctionsWindow = Nothing
        If Not IsNothing(iAboutBox) Then iAboutBox.Dispose()
        iAboutBox = Nothing
        iCaptureKeys = Nothing
    End Sub


End Class
