Imports System.Drawing.Printing

Public Class MyOperationsEngine2
    Implements IDisposable

    Public Enum Operation
        None
        Selecting
        Adding
        ResizingTop
        ResizingLeft
        ResizingBottom
        ResizingRight
        MovingLinePoint1
        MovingLinePoint2
        Moving
        ResizingAreaWidth
        ResizingAreaHeight
        ContextMenu
    End Enum
    Protected Friend Enum ItemAlignment
        Left
        Center
        Right
        Top
        Middle
        Bottom
        CenterArea
    End Enum
    Protected Friend Enum ModifyItemSize
        SameWidth_Largest
        SameWidth_Smallest
        SameHeight_Largest
        SameHeight_Smallest
        SameAll_Largest
        SameAll_Smallest
    End Enum
    Protected Friend Enum ModifyItemGap
        HorizontalAll
        HorizontalIncrease
        HorizontalDecrease
        VerticalAll
        VerticalIncrease
        VerticalDecrease
    End Enum
    Protected Friend Enum TextAlignment
        Left
        Center
        Right
        Top
        Middle
        Bottom
    End Enum
    Protected Friend Enum Border
        None
        Top
        Left
        Bottom
        Right
        All
    End Enum
    Protected Friend Enum MovementDirection
        Up
        Down
        Left
        Right
    End Enum
    Private Enum TransformHandle
        TransformItemTop
        TransformItemLeft
        TransformItemBottom
        TransformItemRight
        TransformLinePoint1
        TransformLinePoint2
        MoveItem
        TransformAreaWidth
        TransformAreaHeight
        None
    End Enum


#Region "Unmanaged"
    Private WithEvents iCanvasPanel As Panel
    Private WithEvents iPictureBox As PictureBox
    Private iDrawEngine As MyDrawEngine2
#End Region

#Region "Managed"
    Private iDocumentMousePos As Point

    Private iOperation As Operation
    Private iOperationStartPos As Point
    Private iAddingType As AddingType
    Private iAddingStarted As Boolean

    Private DefaultCursor As Cursor
    Private AddLineCursor As Cursor
    Private AddRectangleCursor As Cursor
    Private AddCircleCursor As Cursor
    Private AddTextCursor As Cursor
    Private AddPictureCursor As Cursor
    Private AddBarcodeCursor As Cursor

    Private iDefaultFont As Font
    Private iDefaultFontColor As Color
    Private iDefaultBackColor As Color

    Private iDataSelector As DataSelector
#End Region

    Event PropertySelect(Area As MyDocumentArea, Item() As MyItem)
    Event ItemRightClick(Item As MyItem, CanvasPoint As Point)
    Event AddOperationDone()

#Region "Properties"
    Protected Friend Property DesignerOperation As Operation
        Get
            Return iOperation
        End Get
        Set(value As Operation)
            iOperation = value
        End Set
    End Property
    Protected Friend Property DesignerAddingType As AddingType
        Get
            Return iAddingType
        End Get
        Set(value As AddingType)
            iAddingType = value
        End Set
    End Property
    Protected Friend Property DefaultFont As Font
        Get
            Return iDefaultFont
        End Get
        Set(value As Font)
            iDefaultFont = value
        End Set
    End Property
    Protected Friend Property DefaultFontColor As Color
        Get
            Return iDefaultFontColor
        End Get
        Set(value As Color)
            iDefaultFontColor = value
        End Set
    End Property
    Protected Friend Property DefaultBackColor As Color
        Get
            Return iDefaultBackColor
        End Get
        Set(value As Color)
            iDefaultBackColor = value
        End Set
    End Property

#End Region

    Protected Friend Sub New(DrawEngine As MyDrawEngine2)
        iDrawEngine = DrawEngine
        iCanvasPanel = iDrawEngine.CanvasPanel
        iPictureBox = iDrawEngine.PictureBox

        iDocumentMousePos = New Point(0, 0)

        iOperation = Operation.None
        iOperationStartPos = New Point(0, 0)
        iAddingType = AddingType.None
        iAddingStarted = False

        AddHandler iCanvasPanel.MouseMove, AddressOf CMM
        AddHandler iPictureBox.MouseMove, AddressOf DMM
        AddHandler iCanvasPanel.MouseDown, AddressOf CMD
        AddHandler iPictureBox.MouseDown, AddressOf DMD
        AddHandler iCanvasPanel.MouseUp, AddressOf CMU
        AddHandler iPictureBox.MouseUp, AddressOf DMU
        AddHandler iPictureBox.MouseDoubleClick, AddressOf DDC

        DefaultCursor = CreateCursorNoResize(My.Resources.ptr_default, 0, 0)
        AddLineCursor = CreateCursorNoResize(My.Resources.ptr_add_line, 0, 0)
        AddRectangleCursor = CreateCursorNoResize(My.Resources.ptr_add_rectangle, 0, 0)
        AddCircleCursor = CreateCursorNoResize(My.Resources.ptr_add_circle, 0, 0)
        AddTextCursor = CreateCursorNoResize(My.Resources.ptr_add_text, 0, 0)
        AddPictureCursor = CreateCursorNoResize(My.Resources.ptr_add_picture, 0, 0)
        AddBarcodeCursor = CreateCursorNoResize(My.Resources.ptr_add_barcode, 0, 0)

        iDefaultFont = New Font("Arial", 11)
        iDefaultFontColor = Color.Black
        iDefaultBackColor = Color.Transparent

        iDataSelector = New DataSelector
    End Sub

    Private Sub DMD(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim ManualStartPos As Boolean = False
        Select Case e.Button
            Case MouseButtons.Left
                Select Case iOperation
                    Case Operation.None
                        Dim Item As MyItem = Nothing
                        Select Case HotSpot(iDocumentMousePos, Item)
                            Case TransformHandle.None
                                iOperation = Operation.Selecting
                                'iDrawEngine.SelectRectangle = New PointsRectangle(iDocumentMousePos, iDocumentMousePos)
                            Case TransformHandle.MoveItem
                                If My.Computer.Keyboard.ShiftKeyDown Or My.Computer.Keyboard.CtrlKeyDown Then
                                    iOperation = Operation.Selecting
                                    'iDrawEngine.SelectRectangle = New PointsRectangle(iDocumentMousePos, iDocumentMousePos)
                                Else
                                    iOperation = Operation.Moving
                                End If
                            Case TransformHandle.TransformItemTop
                                iOperation = Operation.ResizingTop
                            Case TransformHandle.TransformItemLeft
                                iOperation = Operation.ResizingLeft
                            Case TransformHandle.TransformItemBottom
                                iOperation = Operation.ResizingBottom
                            Case TransformHandle.TransformItemRight
                                iOperation = Operation.ResizingRight
                            Case TransformHandle.TransformLinePoint1
                                Dim LineItem As MyLineItem = CType(Item, MyLineItem)
                                iDrawEngine.ClearSelectedItems()
                                iDrawEngine.AddSelectedItem(Item)
                                iOperation = Operation.MovingLinePoint1
                                ManualStartPos = True
                                iOperationStartPos = New Point(LineItem.Location2 + iDrawEngine.GetAreaOffset(Item))
                            Case TransformHandle.TransformLinePoint2
                                Dim LineItem As MyLineItem = CType(Item, MyLineItem)
                                iDrawEngine.ClearSelectedItems()
                                iDrawEngine.AddSelectedItem(Item)
                                iOperation = Operation.MovingLinePoint2
                                ManualStartPos = True
                                iOperationStartPos = New Point(LineItem.Location + iDrawEngine.GetAreaOffset(Item))
                            Case TransformHandle.TransformAreaHeight
                                iOperation = Operation.ResizingAreaHeight
                            Case TransformHandle.TransformAreaWidth
                                iOperation = Operation.ResizingAreaWidth
                        End Select
                        If Not ManualStartPos Then iOperationStartPos = New Point(iDocumentMousePos)
                    Case Operation.Adding
                        iAddingStarted = True
                        iOperationStartPos = New Point(iDocumentMousePos)
                End Select
            Case MouseButtons.Right

        End Select

    End Sub
    Private Sub DMM(ByVal sender As Object, ByVal e As MouseEventArgs)
        iDocumentMousePos = e.Location
        Select Case iOperation
            Case Operation.None
                Select Case HotSpot(iDocumentMousePos)
                    Case TransformHandle.TransformAreaHeight
                        iDrawEngine.MouseCursor = Cursors.HSplit
                    Case TransformHandle.TransformAreaWidth
                        iDrawEngine.MouseCursor = Cursors.VSplit
                    Case TransformHandle.TransformItemTop
                        iDrawEngine.MouseCursor = Cursors.SizeNS
                    Case TransformHandle.TransformItemLeft
                        iDrawEngine.MouseCursor = Cursors.SizeWE
                    Case TransformHandle.TransformItemBottom
                        iDrawEngine.MouseCursor = Cursors.SizeNS
                    Case TransformHandle.TransformItemRight
                        iDrawEngine.MouseCursor = Cursors.SizeWE
                    Case TransformHandle.TransformLinePoint1, TransformHandle.TransformLinePoint2
                        iDrawEngine.MouseCursor = Cursors.Cross
                    Case TransformHandle.MoveItem
                        iDrawEngine.MouseCursor = Cursors.SizeAll
                    Case Else
                        iDrawEngine.MouseCursor = DefaultCursor
                End Select
            Case Operation.Selecting
                iDrawEngine.SelectRectangle = New PointsRectangle(iOperationStartPos, iDocumentMousePos)
                'iDrawEngine.SelectRectangle.Point1 = New Point(iOperationStartPos)
                'iDrawEngine.SelectRectangle.Point2 = New Point(iDocumentMousePos)
            Case Operation.Adding
                Select Case iAddingType
                    Case AddingType.Line
                        iDrawEngine.MouseCursor = AddLineCursor
                    Case AddingType.Rectangle
                        iDrawEngine.MouseCursor = AddRectangleCursor
                    Case AddingType.Circle
                        iDrawEngine.MouseCursor = AddCircleCursor
                    Case AddingType.Text
                        iDrawEngine.MouseCursor = AddTextCursor
                    Case AddingType.Picture
                        iDrawEngine.MouseCursor = AddPictureCursor
                    Case AddingType.Code39, AddingType.Code39EX, AddingType.Code128
                        iDrawEngine.MouseCursor = AddBarcodeCursor
                End Select
                If iAddingStarted Then
                    Dim SelectSize As New Size(iDocumentMousePos.X - iOperationStartPos.X, iDocumentMousePos.Y - iOperationStartPos.Y)
                    If iAddingType = AddingType.Line Then iDrawEngine.SelectRectangleAsLine = True
                    iDrawEngine.SelectRectangle = New PointsRectangle(iOperationStartPos, iDocumentMousePos)
                    'iDrawEngine.SelectRectangle.Point1 = New Point(iOperationStartPos)
                    'iDrawEngine.SelectRectangle.Point2 = New Point(iDocumentMousePos)
                End If
            Case Operation.Moving
                Dim Shift As New Point(iDocumentMousePos - iOperationStartPos)
                iDrawEngine.ControlsOffset = Shift
            Case Operation.ResizingTop
                Dim Shift As New Rectangle(0, iDocumentMousePos.Y - iOperationStartPos.Y, 0, 0)
                iDrawEngine.TransformShift = Shift
            Case Operation.ResizingLeft
                Dim Shift As New Rectangle(iDocumentMousePos.X - iOperationStartPos.X, 0, 0, 0)
                iDrawEngine.TransformShift = Shift
            Case Operation.ResizingBottom
                Dim Shift As New Rectangle(0, 0, 0, iDocumentMousePos.Y - iOperationStartPos.Y)
                iDrawEngine.TransformShift = Shift
            Case Operation.ResizingRight
                Dim Shift As New Rectangle(0, 0, iDocumentMousePos.X - iOperationStartPos.X, 0)
                iDrawEngine.TransformShift = Shift
            Case Operation.ResizingAreaHeight
                Dim Shift As Integer = iDocumentMousePos.Y - iOperationStartPos.Y
                iDrawEngine.AreaVerticalResizingShift = Shift
            Case Operation.ResizingAreaWidth
                Dim Shift As Integer = iDocumentMousePos.X - iOperationStartPos.X
                iDrawEngine.AreaHorizontalResizingShift = Shift
            Case Operation.MovingLinePoint1
                iDrawEngine.SelectRectangleAsLine = True
                iDrawEngine.SelectRectangle = New PointsRectangle(iOperationStartPos, iDocumentMousePos)
            Case Operation.MovingLinePoint2
                iDrawEngine.SelectRectangleAsLine = True
                iDrawEngine.SelectRectangle = New PointsRectangle(iOperationStartPos, iDocumentMousePos)
        End Select
    End Sub
    Private Sub DMU(ByVal sender As Object, ByVal e As MouseEventArgs)
        Select Case iOperation
            Case Operation.None
                ' Do Nothing
            Case Operation.Selecting
                Dim Area As MyDocumentArea = Nothing
                Dim SelectRectangle As Rectangle = iDrawEngine.SelectRectangle.GetRectangle
                HitDocument(iOperationStartPos, Area, Nothing)
                'Debug.WriteLine("SelectRectangle " & SelectRectangle.ToString)
                If SelectRectangle.Width = 0 And SelectRectangle.Height = 0 Then
                    Dim Item As MyItem = Nothing
                    HitDocument(iOperationStartPos, Nothing, Item)
                    If IsNothing(Item) Then
                        iDrawEngine.ClearSelectedItems()
                    Else
                        If My.Computer.Keyboard.CtrlKeyDown Or My.Computer.Keyboard.ShiftKeyDown Then
                            If iDrawEngine.SelectedItems.Contains(Item) Then
                                iDrawEngine.RemoveSelectedItem(Item)
                            Else
                                iDrawEngine.AddSelectedItem(Item)
                            End If
                        Else
                            iDrawEngine.ClearSelectedItems()
                            iDrawEngine.AddSelectedItem(Item)
                        End If
                    End If
                Else
                    If Not IsNothing(Area) Then
                        If Not My.Computer.Keyboard.CtrlKeyDown And Not My.Computer.Keyboard.ShiftKeyDown Then iDrawEngine.ClearSelectedItems()
                        For Each Item In Area.Items
                            Dim ItemRect As Rectangle = iDrawEngine.GetItemDrawRectangle(Item)
                            If SelectRectangle.Contains(ItemRect) Then
                                If Not iDrawEngine.SelectedItems.Contains(Item) Then
                                    iDrawEngine.AddSelectedItem(Item)
                                End If
                            End If
                        Next
                    End If
                End If
                RaiseEvent PropertySelect(Area, iDrawEngine.SelectedItems.ToArray)
                iDrawEngine.SelectedArea = Area
                iOperation = Operation.None
                iDrawEngine.SelectRectangle = New PointsRectangle
            Case Operation.Moving
                Dim Shift As New Point(iDocumentMousePos - iOperationStartPos)
                For Each Item In iDrawEngine.SelectedItems
                    Dim RealShift As Point = ValidShift(Item, Shift)
                    If Item.Type = ItemType.Line Then
                        Dim LineItem As MyLineItem = CType(Item, MyLineItem)
                        LineItem.Location += RealShift
                        LineItem.Location2 += RealShift
                    Else
                        Item.Location += RealShift
                    End If
                Next
                iOperation = Operation.None
                iDrawEngine.ControlsOffset = New Point(0, 0)
                iDrawEngine.RedrawDocument()
            Case Operation.ResizingTop, Operation.ResizingLeft, Operation.ResizingBottom, Operation.ResizingRight
                For Each Item In iDrawEngine.SelectedItems
                    Dim Transform As Rectangle = ValidTransform(Item, iDrawEngine.TransformShift)
                    Dim ItemRect As Rectangle = Item.GetRectangle
                    ItemRect.Offset(Transform.Location)
                    ItemRect.Width = -Transform.X + Item.Width + Transform.Width
                    ItemRect.Height = -Transform.Y + Item.Height + Transform.Height
                    Item.Location = ItemRect.Location
                    Item.Size = ItemRect.Size
                Next
                iOperation = Operation.None
                iDrawEngine.TransformShift = New Rectangle(0, 0, 0, 0)
                iDrawEngine.RedrawArea(iDrawEngine.SelectedArea)
            Case Operation.ResizingAreaHeight
                Dim Shift As Integer = iDrawEngine.AreaVerticalResizingShift
                If (iDrawEngine.SelectedArea.Height + Shift) < 0 Then
                    Shift = -iDrawEngine.SelectedArea.Height
                End If
                iDrawEngine.SelectedArea.Height += Shift
                iOperation = Operation.None
                iDrawEngine.AreaVerticalResizingShift = 0
                ValidateDocumentArea(iDrawEngine.SelectedArea)
                iDrawEngine.CanvasPanel.Invalidate(True)
                iDrawEngine.CanvasPanel.Update()
            Case Operation.ResizingAreaWidth
                Dim Shift As Integer = iDrawEngine.AreaHorizontalResizingShift
                If (iDrawEngine.SelectedArea.Width + Shift) < 0 Then
                    Shift = -iDrawEngine.SelectedArea.Width
                End If
                iDrawEngine.SelectedArea.Width += Shift
                iOperation = Operation.None
                iDrawEngine.AreaHorizontalResizingShift = 0
                iDrawEngine.CanvasPanel.Invalidate(True)
                iDrawEngine.CanvasPanel.Update()
            Case Operation.MovingLinePoint1
                Dim LineItem As MyLineItem = CType(iDrawEngine.SelectedItems(0), MyLineItem)
                Dim NewCoords As New PointsRectangle(iDrawEngine.SelectRectangle.Point1, iDrawEngine.SelectRectangle.Point2)
                Dim Offset As Point = iDrawEngine.GetAreaOffset(LineItem)
                NewCoords.Offset(-Offset.X, -Offset.Y)
                LineItem.Location = NewCoords.Point2
                LineItem.Location2 = NewCoords.Point1
                iOperation = Operation.None
                iDrawEngine.SelectRectangleAsLine = False
                iDrawEngine.SelectRectangle = New PointsRectangle
                iDrawEngine.RedrawArea(iDrawEngine.SelectedArea)
            Case Operation.MovingLinePoint2
                Dim LineItem As MyLineItem = CType(iDrawEngine.SelectedItems(0), MyLineItem)
                Dim NewCoords As New PointsRectangle(iDrawEngine.SelectRectangle.Point1, iDrawEngine.SelectRectangle.Point2)
                Dim Offset As Point = iDrawEngine.GetAreaOffset(LineItem)
                NewCoords.Offset(-Offset.X, -Offset.Y)
                LineItem.Location = NewCoords.Point1
                LineItem.Location2 = NewCoords.Point2
                iOperation = Operation.None
                iDrawEngine.SelectRectangleAsLine = False
                iDrawEngine.SelectRectangle = New PointsRectangle
                iDrawEngine.RedrawArea(iDrawEngine.SelectedArea)
            Case Operation.Adding
                Dim Area As MyDocumentArea = Nothing
                HitDocument(iDrawEngine.SelectRectangle.Point1, Area, Nothing)
                If IsNothing(Area) Then
                    iAddingStarted = False
                    iOperation = Operation.None
                    iDrawEngine.SelectRectangle = New PointsRectangle
                    RaiseEvent AddOperationDone()
                    Exit Sub
                Else
                    iDrawEngine.SelectedArea = Area
                    'Dim AreaLoc As New Point(iDrawEngine.SelectRectangle.Location)
                    Dim ItemRect As Rectangle = iDrawEngine.SelectRectangle.GetRectangle
                    ItemRect.Offset(-iDrawEngine.GetAreaInnerDrawRectangle(Area).Location.X,
                                    -iDrawEngine.GetAreaInnerDrawRectangle(Area).Location.Y)
                    iDrawEngine.SelectedItems.Clear()
                    Select Case iAddingType
                        Case AddingType.Line
                            iDrawEngine.SelectRectangleAsLine = False
                            Dim Item As New MyLineItem With {.X = ItemRect.X, .Y = ItemRect.Y, .X2 = ItemRect.Right, .Y2 = ItemRect.Bottom}
                            Area.Items.Add(Item)
                            iDrawEngine.ClearSelectedItems()
                            iDrawEngine.AddSelectedItem(Item)
                            RaiseEvent PropertySelect(Area, iDrawEngine.SelectedItems.ToArray)
                        Case AddingType.Rectangle
                            Dim Item As New MyRectangleItem(ItemRect) With {.BackColor = iDefaultBackColor}
                            Area.Items.Add(Item)
                            iDrawEngine.ClearSelectedItems()
                            iDrawEngine.AddSelectedItem(Item)
                            RaiseEvent PropertySelect(Area, iDrawEngine.SelectedItems.ToArray)
                        Case AddingType.Circle
                            Dim Item As New MyElypseItem(ItemRect) With {.FillColor = iDefaultBackColor}
                            Area.Items.Add(Item)
                            iDrawEngine.ClearSelectedItems()
                            iDrawEngine.AddSelectedItem(Item)
                            RaiseEvent PropertySelect(Area, iDrawEngine.SelectedItems.ToArray)
                        Case AddingType.Text
                            Dim Item As New MyTextItem(ItemRect) With {
                                .TextFont = iDefaultFont.Clone,
                                .TextColor = iDefaultFontColor,
                                .BackColor = iDefaultBackColor}
                            Area.Items.Add(Item)
                            iDrawEngine.ClearSelectedItems()
                            iDrawEngine.AddSelectedItem(Item)
                            RaiseEvent PropertySelect(Area, iDrawEngine.SelectedItems.ToArray)
                        Case AddingType.Picture
                            Dim Item As New MyPictureItem(ItemRect) With {.BackColor = iDefaultBackColor}
                            Area.Items.Add(Item)
                            iDrawEngine.ClearSelectedItems()
                            iDrawEngine.AddSelectedItem(Item)
                            RaiseEvent PropertySelect(Area, iDrawEngine.SelectedItems.ToArray)
                        Case AddingType.Data
                            iDataSelector.Clear()
                            For Each Field In iDrawEngine.Document.StaticFields
                                iDataSelector.AddItem(0, Field.Name, Field.FriendlyName)
                            Next
                            For Each Field In Area.GetFieldsByType(MyField.MyFieldType.DataField)
                                iDataSelector.AddItem(1, Field.Name, Field.FriendlyName)
                            Next
                            For Each Field In Area.GetFieldsByType(MyField.MyFieldType.FunctionField)
                                iDataSelector.AddItem(2, Field.Name, Field.FriendlyName)
                            Next
                            If iDataSelector.ShowDialog = DialogResult.OK Then
                                Dim Item As New MyDataItem(ItemRect) With {
                                    .TextFont = iDefaultFont.Clone,
                                    .TextColor = iDefaultFontColor,
                                    .BackColor = iDefaultBackColor}
                                Select Case iDataSelector.SelectedFieldType
                                    Case 0
                                        Item.DataField = iDrawEngine.Document.GetFieldByName(iDataSelector.SelectedField)
                                    Case 1, 2
                                        Item.DataField = Area.GetFieldByName(iDataSelector.SelectedField)
                                End Select
                                Area.Items.Add(Item)
                                iDrawEngine.ClearSelectedItems()
                                iDrawEngine.AddSelectedItem(Item)
                                RaiseEvent PropertySelect(Area, iDrawEngine.SelectedItems.ToArray)
                            End If
                        Case AddingType.Code39
                            Dim Item As New Code39(ItemRect) With {
                                .TextFont = iDefaultFont.Clone,
                                .TextColor = iDefaultFontColor,
                                .BackColor = iDefaultBackColor}
                            Area.Items.Add(Item)
                            iDrawEngine.ClearSelectedItems()
                            iDrawEngine.AddSelectedItem(Item)
                            RaiseEvent PropertySelect(Area, iDrawEngine.SelectedItems.ToArray)
                        Case AddingType.Code39EX
                            Dim Item As New Code39EX(ItemRect) With {
                                .TextFont = iDefaultFont.Clone,
                                .TextColor = iDefaultFontColor,
                                .BackColor = iDefaultBackColor}
                            Area.Items.Add(Item)
                            iDrawEngine.ClearSelectedItems()
                            iDrawEngine.AddSelectedItem(Item)
                            RaiseEvent PropertySelect(Area, iDrawEngine.SelectedItems.ToArray)
                        Case AddingType.Code128
                            Dim Item As New Code128(ItemRect) With {
                                .TextFont = iDefaultFont.Clone,
                                .TextColor = iDefaultFontColor,
                                .BackColor = iDefaultBackColor}
                            Area.Items.Add(Item)
                            iDrawEngine.ClearSelectedItems()
                            iDrawEngine.AddSelectedItem(Item)
                            RaiseEvent PropertySelect(Area, iDrawEngine.SelectedItems.ToArray)
                    End Select
                    iAddingStarted = False
                    iOperation = Operation.None
                    iDrawEngine.SelectRectangle = New PointsRectangle
                    RaiseEvent AddOperationDone()
                End If
        End Select
        For Each Area In iDrawEngine.Document.DocumentAreas
            ValidateDocumentArea(Area)
        Next
    End Sub
    Private Sub DDC(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim Area As MyDocumentArea = Nothing
        Dim Item As MyItem = Nothing
        HitDocument(iDocumentMousePos, Area, Item)
        If Not IsNothing(Area) And Not IsNothing(Item) Then
            If Item.Type = ItemType.Data Then
                Dim cItem As MyDataItem = CType(Item, MyDataItem)
                iDataSelector.Clear()
                For Each Field In iDrawEngine.Document.StaticFields
                    iDataSelector.AddItem(0, Field.Name, Field.FriendlyName)
                Next
                For Each Field In Area.GetFieldsByType(MyField.MyFieldType.DataField)
                    iDataSelector.AddItem(1, Field.Name, Field.FriendlyName)
                Next
                For Each Field In Area.GetFieldsByType(MyField.MyFieldType.FunctionField)
                    iDataSelector.AddItem(2, Field.Name, Field.FriendlyName)
                Next
                If iDataSelector.ShowDialog = DialogResult.OK Then
                    Select Case iDataSelector.SelectedFieldType
                        Case 0
                            cItem.DataField = iDrawEngine.Document.GetFieldByName(iDataSelector.SelectedField)
                        Case 1, 2
                            cItem.DataField = Area.GetFieldByName(iDataSelector.SelectedField)
                    End Select
                End If
                iDrawEngine.DrawItem(cItem, True)
            End If
        End If
    End Sub

    Private Sub CMM(ByVal sender As Object, ByVal e As MouseEventArgs)

    End Sub
    Private Sub CMD(ByVal sender As Object, ByVal e As MouseEventArgs)

    End Sub
    Private Sub CMU(ByVal sender As Object, ByVal e As MouseEventArgs)

    End Sub

    Protected Friend Sub MoveSelectedItems(Direction As MovementDirection, Optional Distance As Integer = 1)
        If iDrawEngine.SelectedItems.Count > 0 Then
            For Each Item In iDrawEngine.SelectedItems
                If Item.Type = ItemType.Line Then
                    Select Case Direction
                        Case MovementDirection.Up
                            If Item.Y > 0 Then Item.Y -= Distance
                            If Item.Height > 0 Then Item.Height -= Distance
                        Case MovementDirection.Down
                            Item.Y += Distance
                            Item.Height += Distance
                        Case MovementDirection.Left
                            If Item.X > 0 Then Item.X -= Distance
                            If Item.Width > 0 Then Item.Width -= Distance
                        Case MovementDirection.Right
                            Item.X += Distance
                            Item.Width += Distance
                    End Select
                Else
                    Select Case Direction
                        Case MovementDirection.Up
                            If Item.Y > 0 Then Item.Y -= Distance
                        Case MovementDirection.Down
                            Item.Y += Distance
                        Case MovementDirection.Left
                            If Item.X > 0 Then Item.X -= Distance
                        Case MovementDirection.Right
                            Item.X += Distance
                    End Select
                End If

            Next
            If Not ValidateDocumentArea(iDrawEngine.SelectedArea) Then iDrawEngine.RedrawArea(iDrawEngine.SelectedArea)
        End If
    End Sub
    Protected Friend Sub RemoveSelectedItems()
        If iDrawEngine.SelectedItems.Count > 0 Then
            For Each Item In iDrawEngine.SelectedItems
                iDrawEngine.SelectedArea.Items.Remove(Item)
                Item.Dispose()
            Next
            iDrawEngine.ClearSelectedItems()
            RaiseEvent PropertySelect(iDrawEngine.SelectedArea, iDrawEngine.SelectedItems.ToArray)
        End If
    End Sub

    Protected Friend Sub SelectedItemsToFront()
        If iDrawEngine.SelectedItems.Count > 0 Then
            Dim iCount As Integer = iDrawEngine.SelectedItems.Count - 1
            Dim ItemIndex(iCount) As Integer
            Dim ItemIndexCounter As Integer = 0
            For Each Item In iDrawEngine.SelectedItems
                ItemIndex(ItemIndexCounter) = iDrawEngine.SelectedArea.Items.IndexOf(Item)
                ItemIndexCounter += 1
            Next
            Dim LastIndex As Integer = iDrawEngine.SelectedArea.Items.Count
            For Each Index In ItemIndex
                iDrawEngine.SelectedArea.Items.Insert(LastIndex, iDrawEngine.SelectedArea.Items(Index))
                iDrawEngine.SelectedArea.Items.RemoveAt(Index)
            Next
            iDrawEngine.RedrawArea(iDrawEngine.SelectedArea)
        End If
    End Sub
    Protected Friend Sub SelectedItemsToBack()
        If iDrawEngine.SelectedItems.Count > 0 Then
            Dim iCount As Integer = iDrawEngine.SelectedItems.Count - 1
            Dim ItemIndex(iCount) As Integer
            Dim ItemIndexCounter As Integer = 0
            For Each Item In iDrawEngine.SelectedItems
                ItemIndex(ItemIndexCounter) = iDrawEngine.SelectedArea.Items.IndexOf(Item)
                ItemIndexCounter += 1
            Next
            'Dim FirstIndex As Integer = iDrawEngine.SelectedArea.AreaItems.Count
            For Each Index In ItemIndex
                iDrawEngine.SelectedArea.Items.Insert(0, iDrawEngine.SelectedArea.Items(Index))
                iDrawEngine.SelectedArea.Items.RemoveAt(Index + 1)
            Next
            iDrawEngine.RedrawArea(iDrawEngine.SelectedArea)
        End If
    End Sub

    Protected Friend Sub SetSelectedItemsFont(NewFont As Font)
        If iDrawEngine.SelectedItems.Count > 0 Then
            For Each Item In iDrawEngine.SelectedItems
                Select Case Item.Type
                    Case ItemType.Text
                        Dim cItem As MyTextItem = CType(Item, MyTextItem)
                        cItem.TextFont = NewFont.Clone
                    Case ItemType.Data
                        Dim cItem As MyDataItem = CType(Item, MyDataItem)
                        cItem.TextFont = NewFont.Clone
                End Select
            Next
            iDrawEngine.RedrawArea(iDrawEngine.SelectedArea)
        End If
    End Sub
    Protected Friend Sub SetSelectedItemsFontColor(NewColor As Color)
        If iDrawEngine.SelectedItems.Count > 0 Then
            For Each Item In iDrawEngine.SelectedItems
                Select Case Item.Type
                    Case ItemType.Text
                        Dim cItem As MyTextItem = CType(Item, MyTextItem)
                        cItem.TextColor = NewColor
                    Case ItemType.Data
                        Dim cItem As MyDataItem = CType(Item, MyDataItem)
                        cItem.TextColor = NewColor
                End Select
            Next
            iDrawEngine.RedrawArea(iDrawEngine.SelectedArea)
        End If
    End Sub
    Protected Friend Sub SetSelectedItemsBackColor(NewColor As Color)
        If iDrawEngine.SelectedItems.Count > 0 Then
            For Each Item In iDrawEngine.SelectedItems
                Select Case Item.Type
                    Case ItemType.Rectangle
                        Dim cItem As MyRectangleItem = CType(Item, MyRectangleItem)
                        cItem.BackColor = NewColor
                    Case ItemType.Elypse
                        Dim cItem As MyElypseItem = CType(Item, MyElypseItem)
                        cItem.FillColor = NewColor
                    Case ItemType.Text
                        Dim cItem As MyTextItem = CType(Item, MyTextItem)
                        cItem.BackColor = NewColor
                    Case ItemType.Picture
                        Dim cItem As MyPictureItem = CType(Item, MyPictureItem)
                        cItem.BackColor = NewColor
                    Case ItemType.Data
                        Dim cItem As MyDataItem = CType(Item, MyDataItem)
                        cItem.BackColor = NewColor
                End Select
            Next
            iDrawEngine.RedrawArea(iDrawEngine.SelectedArea)
        End If
    End Sub
    Protected Friend Sub SetSelectedItemsTextAlignment(Alignment As TextAlignment)
        If iDrawEngine.SelectedItems.Count > 0 Then
            For Each Item In iDrawEngine.SelectedItems
                Select Case Item.Type
                    Case ItemType.Text
                        Dim cItem As MyTextItem = CType(Item, MyTextItem)
                        Select Case Alignment
                            Case TextAlignment.Left
                                cItem.HorizontalAlignment = ItemHorizontalAlignment.Left
                            Case TextAlignment.Center
                                cItem.HorizontalAlignment = ItemHorizontalAlignment.Center
                            Case TextAlignment.Right
                                cItem.HorizontalAlignment = ItemHorizontalAlignment.Right
                            Case TextAlignment.Top
                                cItem.VerticalAlignment = ItemVerticalAlignment.Top
                            Case TextAlignment.Middle
                                cItem.VerticalAlignment = ItemVerticalAlignment.Center
                            Case TextAlignment.Bottom
                                cItem.VerticalAlignment = ItemVerticalAlignment.Bottom
                        End Select
                    Case ItemType.Data
                        Dim cItem As MyDataItem = CType(Item, MyDataItem)
                        Select Case Alignment
                            Case TextAlignment.Left
                                cItem.HorizontalAlignment = ItemHorizontalAlignment.Left
                            Case TextAlignment.Center
                                cItem.HorizontalAlignment = ItemHorizontalAlignment.Center
                            Case TextAlignment.Right
                                cItem.HorizontalAlignment = ItemHorizontalAlignment.Right
                            Case TextAlignment.Top
                                cItem.VerticalAlignment = ItemVerticalAlignment.Top
                            Case TextAlignment.Middle
                                cItem.VerticalAlignment = ItemVerticalAlignment.Center
                            Case TextAlignment.Bottom
                                cItem.VerticalAlignment = ItemVerticalAlignment.Bottom
                        End Select
                End Select
            Next
            iDrawEngine.RedrawArea(iDrawEngine.SelectedArea)
        End If
    End Sub
    Protected Friend Sub SetSelectedItemsBorder(SetBorder As Border)
        If iDrawEngine.SelectedItems.Count > 0 Then
            For Each Item In iDrawEngine.SelectedItems
                Select Case SetBorder
                    Case Border.None
                        Select Case Item.Type
                            Case ItemType.Text
                                Dim cItem As MyTextItem = CType(Item, MyTextItem)
                                cItem.Border.StyleTop = LineStyle.None
                                cItem.Border.StyleLeft = LineStyle.None
                                cItem.Border.StyleBottom = LineStyle.None
                                cItem.Border.StyleRight = LineStyle.None
                            Case ItemType.Picture
                                Dim cItem As MyPictureItem = CType(Item, MyPictureItem)
                                cItem.Border.StyleTop = LineStyle.None
                                cItem.Border.StyleLeft = LineStyle.None
                                cItem.Border.StyleBottom = LineStyle.None
                                cItem.Border.StyleRight = LineStyle.None
                            Case ItemType.Data
                                Dim cItem As MyDataItem = CType(Item, MyDataItem)
                                cItem.Border.StyleTop = LineStyle.None
                                cItem.Border.StyleLeft = LineStyle.None
                                cItem.Border.StyleBottom = LineStyle.None
                                cItem.Border.StyleRight = LineStyle.None
                        End Select
                    Case Border.Top
                        Select Case Item.Type
                            Case ItemType.Text
                                Dim cItem As MyTextItem = CType(Item, MyTextItem)
                                cItem.Border.StyleTop = LineStyle.Solid
                            Case ItemType.Picture
                                Dim cItem As MyPictureItem = CType(Item, MyPictureItem)
                                cItem.Border.StyleTop = LineStyle.Solid
                            Case ItemType.Data
                                Dim cItem As MyDataItem = CType(Item, MyDataItem)
                                cItem.Border.StyleTop = LineStyle.Solid
                        End Select
                    Case Border.Left
                        Select Case Item.Type
                            Case ItemType.Text
                                Dim cItem As MyTextItem = CType(Item, MyTextItem)
                                cItem.Border.StyleLeft = LineStyle.Solid
                            Case ItemType.Picture
                                Dim cItem As MyPictureItem = CType(Item, MyPictureItem)
                                cItem.Border.StyleLeft = LineStyle.Solid
                            Case ItemType.Data
                                Dim cItem As MyDataItem = CType(Item, MyDataItem)
                                cItem.Border.StyleLeft = LineStyle.Solid
                        End Select
                    Case Border.Bottom
                        Select Case Item.Type
                            Case ItemType.Text
                                Dim cItem As MyTextItem = CType(Item, MyTextItem)
                                cItem.Border.StyleBottom = LineStyle.Solid
                            Case ItemType.Picture
                                Dim cItem As MyPictureItem = CType(Item, MyPictureItem)
                                cItem.Border.StyleBottom = LineStyle.Solid
                            Case ItemType.Data
                                Dim cItem As MyDataItem = CType(Item, MyDataItem)
                                cItem.Border.StyleBottom = LineStyle.Solid
                        End Select
                    Case Border.Right
                        Select Case Item.Type
                            Case ItemType.Text
                                Dim cItem As MyTextItem = CType(Item, MyTextItem)
                                cItem.Border.StyleRight = LineStyle.Solid
                            Case ItemType.Picture
                                Dim cItem As MyPictureItem = CType(Item, MyPictureItem)
                                cItem.Border.StyleRight = LineStyle.Solid
                            Case ItemType.Data
                                Dim cItem As MyDataItem = CType(Item, MyDataItem)
                                cItem.Border.StyleRight = LineStyle.Solid
                        End Select
                    Case Border.All
                        Select Case Item.Type
                            Case ItemType.Text
                                Dim cItem As MyTextItem = CType(Item, MyTextItem)
                                cItem.Border.StyleTop = LineStyle.Solid
                                cItem.Border.StyleLeft = LineStyle.Solid
                                cItem.Border.StyleBottom = LineStyle.Solid
                                cItem.Border.StyleRight = LineStyle.Solid
                            Case ItemType.Picture
                                Dim cItem As MyPictureItem = CType(Item, MyPictureItem)
                                cItem.Border.StyleTop = LineStyle.Solid
                                cItem.Border.StyleLeft = LineStyle.Solid
                                cItem.Border.StyleBottom = LineStyle.Solid
                                cItem.Border.StyleRight = LineStyle.Solid
                            Case ItemType.Data
                                Dim cItem As MyDataItem = CType(Item, MyDataItem)
                                cItem.Border.StyleTop = LineStyle.Solid
                                cItem.Border.StyleLeft = LineStyle.Solid
                                cItem.Border.StyleBottom = LineStyle.Solid
                                cItem.Border.StyleRight = LineStyle.Solid
                        End Select
                End Select
            Next
            iDrawEngine.RedrawArea(iDrawEngine.SelectedArea)
        End If
    End Sub

    Protected Friend Sub AlignSelectedItems(Alignment As ItemAlignment)
        If iDrawEngine.SelectedItems.Count > 1 Then
            'Dim RefCoodinates As Rectangle = iDrawEngine.SelectedItems(0).ItemLocation
            Select Case Alignment
                Case ItemAlignment.Left
                    Dim NewValue As Integer = iDrawEngine.SelectedItems(0).X
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.X < NewValue Then NewValue = Item.X
                    Next
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Type = ItemType.Line Then
                            'Dim LineItem As MyLineItem = CType(Item, MyLineItem)
                            'Dim LineRect As Rectangle = LineItem.GetRectangle
                            'LineItem.X = NewValue
                            'LineItem.X2 = LineItem.X - LineRect.Width
                        Else
                            Item.X = NewValue
                        End If
                    Next
                Case ItemAlignment.Center
                    Dim NewValue As Integer = iDrawEngine.SelectedItems(0).X
                    Dim RefRect As Rectangle = iDrawEngine.SelectedItems(0).GetRectangle
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.X < NewValue Then
                            NewValue = Item.X
                            RefRect = Item.GetRectangle
                        End If
                    Next
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Type = ItemType.Line Then

                        Else
                            Item.X = RefRect.X + ((RefRect.Width - Item.Width) / 2)
                        End If
                    Next
                Case ItemAlignment.Right
                    Dim NewValue As Integer = iDrawEngine.SelectedItems(0).Right
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Right > NewValue Then NewValue = Item.Right
                    Next
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Type = ItemType.Line Then

                        Else
                            Item.X = NewValue - Item.Width + 1
                        End If
                    Next
                Case ItemAlignment.Top
                    Dim NewValue As Integer = iDrawEngine.SelectedItems(0).Y
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Y < NewValue Then NewValue = Item.Y
                    Next
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Type = ItemType.Line Then

                        Else
                            Item.Y = NewValue
                        End If
                    Next
                Case ItemAlignment.Middle
                    Dim NewValue As Integer = iDrawEngine.SelectedItems(0).Y
                    Dim RefRectangle As Rectangle = iDrawEngine.SelectedItems(0).GetRectangle
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Y < NewValue Then
                            NewValue = Item.Y
                            RefRectangle = Item.GetRectangle
                        End If
                    Next
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Type = ItemType.Line Then

                        Else
                            Item.Y = RefRectangle.Y + ((RefRectangle.Height - Item.Height) / 2)
                        End If
                    Next
                Case ItemAlignment.Bottom
                    Dim NewValue As Integer = iDrawEngine.SelectedItems(0).Bottom
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Bottom > NewValue Then NewValue = Item.Bottom
                    Next
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Type = ItemType.Line Then

                        Else
                            Item.Y = NewValue - Item.Height + 1
                        End If
                    Next
                Case ItemAlignment.CenterArea
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Type = ItemType.Line Then

                        Else
                            Item.X = (If(iDrawEngine.Document.DocumentType = DocumentType.Page,
                                         iDrawEngine.Document.PageWidth,
                                         iDrawEngine.SelectedArea.Width) / 2) - (Item.Width / 2)
                        End If
                    Next
            End Select
            If Not ValidateDocumentArea(iDrawEngine.SelectedArea) Then iDrawEngine.RedrawArea(iDrawEngine.SelectedArea)
        ElseIf iDrawEngine.SelectedItems.Count = 1 And Alignment = ItemAlignment.CenterArea Then
            iDrawEngine.SelectedItems(0).X = (If(iDrawEngine.Document.DocumentType = DocumentType.Page,
                                                 iDrawEngine.Document.PageWidth,
                                                 iDrawEngine.SelectedArea.Width) / 2) - (iDrawEngine.SelectedItems(0).Width / 2)
            If Not ValidateDocumentArea(iDrawEngine.SelectedArea) Then iDrawEngine.RedrawArea(iDrawEngine.SelectedArea)
        End If
    End Sub
    Protected Friend Sub ModifySelectedItemsSize(Modify As ModifyItemSize)
        If iDrawEngine.SelectedItems.Count > 1 Then
            Select Case Modify
                Case ModifyItemSize.SameWidth_Largest
                    Dim NewValue As Integer = iDrawEngine.SelectedItems(0).Width
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Width > NewValue Then NewValue = Item.Width
                    Next
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Type = ItemType.Line Then

                        Else
                            Item.Width = NewValue
                        End If
                    Next
                Case ModifyItemSize.SameWidth_Smallest
                    Dim NewValue As Integer = iDrawEngine.SelectedItems(0).Width
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Width < NewValue Then NewValue = Item.Width
                    Next
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Type = ItemType.Line Then

                        Else
                            Item.Width = NewValue
                        End If
                    Next
                Case ModifyItemSize.SameHeight_Largest
                    Dim NewValue As Integer = iDrawEngine.SelectedItems(0).Height
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Height > NewValue Then NewValue = Item.Height
                    Next
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Type = ItemType.Line Then

                        Else
                            Item.Height = NewValue
                        End If
                    Next
                Case ModifyItemSize.SameHeight_Smallest
                    Dim NewValue As Integer = iDrawEngine.SelectedItems(0).Height
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Height < NewValue Then NewValue = Item.Height
                    Next
                    For Each Item In iDrawEngine.SelectedItems
                        If Item.Type = ItemType.Line Then

                        Else
                            Item.Height = NewValue
                        End If
                    Next
                Case ModifyItemSize.SameAll_Largest
                    ModifySelectedItemsSize(ModifyItemSize.SameWidth_Largest)
                    ModifySelectedItemsSize(ModifyItemSize.SameHeight_Largest)
                Case ModifyItemSize.SameAll_Smallest
                    ModifySelectedItemsSize(ModifyItemSize.SameWidth_Smallest)
                    ModifySelectedItemsSize(ModifyItemSize.SameHeight_Smallest)
            End Select
            If Not ValidateDocumentArea(iDrawEngine.SelectedArea) Then iDrawEngine.RedrawArea(iDrawEngine.SelectedArea)
        End If
    End Sub
    Protected Friend Sub ModifySelectedItemsGap(Modify As ModifyItemGap)
        If iDrawEngine.SelectedItems.Count > 1 Then

            Select Case Modify
                Case ModifyItemGap.HorizontalAll

                Case ModifyItemGap.HorizontalIncrease

                Case ModifyItemGap.HorizontalDecrease

                Case ModifyItemGap.VerticalAll

                Case ModifyItemGap.VerticalIncrease

                Case ModifyItemGap.VerticalDecrease

            End Select
            If Not ValidateDocumentArea(iDrawEngine.SelectedArea) Then iDrawEngine.RedrawArea(iDrawEngine.SelectedArea)
        End If
    End Sub


    Private Sub HitDocument(ByVal DocumentHitPoint As Point, ByRef HitArea As MyDocumentArea, ByRef HitItem As MyItem)
        Dim foundArea As MyDocumentArea = Nothing
        Dim foundItem As MyItem = Nothing
        If IsNothing(iDrawEngine.Document) Then Exit Sub
        For Each Area In iDrawEngine.Document.DocumentAreas
            If iDrawEngine.GetAreaDrawRectangle(Area).Contains(DocumentHitPoint) Then
                foundArea = Area
            End If
            If iDrawEngine.GetAreaHSeparatorDrawRectangle(Area).Contains(DocumentHitPoint) Then
                foundArea = Area
            End If
            If iDrawEngine.GetAreaVSeparatorDrawRectangle(Area).Contains(DocumentHitPoint) Then
                foundArea = Area
            End If
            For Each Item In Area.Items
                If iDrawEngine.GetItemDrawRectangle(Item).Contains(DocumentHitPoint) Then
                    foundItem = Item
                End If
            Next
        Next
        HitArea = foundArea
        HitItem = foundItem
    End Sub
    Private Function HotSpot(ByVal DocumentHitPoint As Point, Optional ByRef RefItem As MyItem = Nothing) As TransformHandle
        If IsNothing(iDrawEngine.Document) Then Return TransformHandle.None
        Dim DocHPX = DocumentHitPoint.X
        Dim DocHPY = DocumentHitPoint.Y

        Dim SepRect As Rectangle
        Dim ItemRect As Rectangle
        Dim HandleRect(3) As Rectangle

        'Item HotSpots
        For Each Item In iDrawEngine.SelectedItems
            ItemRect = iDrawEngine.GetItemDrawRectangle(Item)
            If Item.Type = ItemType.Line Then
                Dim LineItem As MyLineItem = CType(Item, MyLineItem)
                Dim Offset As Point = iDrawEngine.GetAreaOffset(Item)
                Dim Handle1 As New Rectangle(LineItem.X + Offset.X - 3, LineItem.Y + Offset.Y - 3, 5, 5)
                Dim Handle2 As New Rectangle(LineItem.X2 + Offset.X - 3, LineItem.Y2 + Offset.Y - 3, 5, 5)
                If Handle1.Contains(DocHPX, DocHPY) Then
                    RefItem = Item
                    Return TransformHandle.TransformLinePoint1
                End If
                If Handle2.Contains(DocHPX, DocHPY) Then
                    RefItem = Item
                    Return TransformHandle.TransformLinePoint2
                End If
            Else
                HandleRect(TransformHandle.TransformItemTop) = New Rectangle(ItemRect.X + (ItemRect.Width / 2) - 3, ItemRect.Y - 3, 5, 5)
                HandleRect(TransformHandle.TransformItemLeft) = New Rectangle(ItemRect.X - 3, ItemRect.Y + (ItemRect.Height / 2) - 3, 5, 5)
                HandleRect(TransformHandle.TransformItemBottom) = New Rectangle(ItemRect.X + (ItemRect.Width / 2) - 3, ItemRect.Y + ItemRect.Height - 2, 5, 5)
                HandleRect(TransformHandle.TransformItemRight) = New Rectangle(ItemRect.X + ItemRect.Width - 2, ItemRect.Y + (ItemRect.Height / 2) - 3, 5, 5)
                For i = 0 To 3
                    HandleRect(i).Inflate(2, 2)
                Next
                If HandleRect(TransformHandle.TransformItemTop).Contains(DocHPX, DocHPY) Then
                    RefItem = Item
                    Return TransformHandle.TransformItemTop
                End If
                If HandleRect(TransformHandle.TransformItemLeft).Contains(DocHPX, DocHPY) Then
                    RefItem = Item
                    Return TransformHandle.TransformItemLeft
                End If
                If HandleRect(TransformHandle.TransformItemBottom).Contains(DocHPX, DocHPY) Then
                    RefItem = Item
                    Return TransformHandle.TransformItemBottom
                End If
                If HandleRect(TransformHandle.TransformItemRight).Contains(DocHPX, DocHPY) Then
                    RefItem = Item
                    Return TransformHandle.TransformItemRight
                End If
            End If
            If ItemRect.Contains(DocHPX, DocHPY) Then
                RefItem = Item
                Return TransformHandle.MoveItem
            End If
        Next
        'Area HotSpots
        If Not IsNothing(iDrawEngine.SelectedArea) Then
            SepRect = iDrawEngine.GetAreaHSeparatorDrawRectangle(iDrawEngine.SelectedArea)
            If SepRect.Contains(DocHPX, DocHPY) Then Return TransformHandle.TransformAreaHeight
            SepRect = iDrawEngine.GetAreaVSeparatorDrawRectangle(iDrawEngine.SelectedArea)
            If SepRect.Contains(DocHPX, DocHPY) Then Return TransformHandle.TransformAreaWidth
        End If
        Return TransformHandle.None
    End Function
    Private Function ValidateDocumentArea(Area As MyDocumentArea) As Boolean
        Dim Changed As Boolean = False
        Dim Bottom As Integer = 0
        For Each Item In Area.Items
            If Item.Type = ItemType.Line Then
                Dim LineBottom As Integer = Item.GetRectangle.Bottom
                If LineBottom > Bottom Then Bottom = LineBottom + 1
            Else
                If (Item.Y + Item.Height - 1) > Bottom Then Bottom = (Item.Y + Item.Height - 1) + 1
            End If
        Next
        If Area.DynamicHeight And Area.Height <> Bottom Then
            Area.Height = Bottom
            Changed = True
        Else
            If Bottom > Area.Height Then
                Area.Height = Bottom
                Changed = True
            End If
        End If
        If Changed Then
            iDrawEngine.CanvasPanel.Invalidate(True)
            Return True
        Else
            Return False
        End If
    End Function

    Private Function ValidShift(Item As MyItem, Shift As Point) As Point
        Dim Area As MyDocumentArea = iDrawEngine.GetItemArea(Item)
        Dim AreaWidth As Integer = IIf(iDrawEngine.Document.DocumentType = DocumentType.Page,
                                       iDrawEngine.Document.PageWidth,
                                       Area.Width)
        Dim AreaHeight As Integer = Area.Height
        If (Item.Location + Shift).X < 0 Then
            Shift.X = -Item.X
        End If
        If (Item.Location + Shift).Y < 0 Then
            Shift.Y = -Item.Y
        End If
        If (Item.X + Item.Width - 1 + Shift.X) > AreaWidth Then
            Shift.X = Shift.X - ((Item.X + Item.Width - 1 + Shift.X) - AreaWidth) - 1
        End If
        If iDrawEngine.Document.DocumentType = DocumentType.MultiLabel Then
            If (Item.Y + Item.Height - 1 + Shift.Y) > AreaHeight Then
                Shift.Y = Shift.Y - ((Item.Y + Item.Height - 1 + Shift.Y) - AreaHeight) - 1
            End If
        End If
        Return Shift
    End Function
    Private Function ValidTransform(Item As MyItem, Transform As Rectangle) As Rectangle
        Dim Area As MyDocumentArea = iDrawEngine.GetItemArea(Item)
        Dim AreaWidth As Integer = IIf(iDrawEngine.Document.DocumentType = DocumentType.Page,
                                       iDrawEngine.Document.PageWidth,
                                       Area.Width)
        Dim AreaHeight As Integer = Area.Height
        If (Item.Location + Transform.Location).X < 0 Then
            Transform.X = -Item.X
        End If
        If (Item.Location + Transform.Location).Y < 0 Then
            Transform.Y = -Item.Y
        End If
        If (Item.X + Item.Width - 1 + Transform.Width) > AreaWidth Then
            Transform.Width = Transform.Width - ((Item.X + Item.Width - 1 + Transform.Width) - AreaWidth) - 1
        End If
        If iDrawEngine.Document.DocumentType = DocumentType.MultiLabel Then
            If (Item.Y + Item.Height - 1 + Transform.Height) > AreaHeight Then
                Transform.Height = Transform.Height - ((Item.Y + Item.Height - 1 + Transform.Height) - AreaHeight) - 1
            End If
        End If
        Return Transform
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                iDocumentMousePos = Nothing
                iOperation = Nothing
                iOperationStartPos = Nothing
                iAddingType = Nothing
                iAddingStarted = Nothing
                If Not IsNothing(DefaultCursor) Then DefaultCursor.Dispose()
                DefaultCursor = Nothing
                If Not IsNothing(AddLineCursor) Then AddLineCursor.Dispose()
                AddLineCursor = Nothing
                If Not IsNothing(AddRectangleCursor) Then AddRectangleCursor.Dispose()
                AddRectangleCursor = Nothing
                If Not IsNothing(AddCircleCursor) Then AddCircleCursor.Dispose()
                AddCircleCursor = Nothing
                If Not IsNothing(AddTextCursor) Then AddTextCursor.Dispose()
                AddTextCursor = Nothing
                If Not IsNothing(AddPictureCursor) Then AddPictureCursor.Dispose()
                AddPictureCursor = Nothing
                If Not IsNothing(AddBarcodeCursor) Then AddBarcodeCursor.Dispose()
                AddBarcodeCursor = Nothing
                If Not IsNothing(iDefaultFont) Then iDefaultFont.Dispose()
                iDefaultFont = Nothing
                If Not IsNothing(iDataSelector) Then iDataSelector.Dispose()
                iDataSelector = Nothing
                iDefaultFontColor = Nothing
                iDefaultBackColor = Nothing
                RemoveHandler iCanvasPanel.MouseMove, AddressOf CMM
                RemoveHandler iPictureBox.MouseMove, AddressOf DMM
                RemoveHandler iCanvasPanel.MouseDown, AddressOf CMD
                RemoveHandler iPictureBox.MouseDown, AddressOf DMD
                RemoveHandler iCanvasPanel.MouseUp, AddressOf CMU
                RemoveHandler iPictureBox.MouseUp, AddressOf DMU
                RemoveHandler iPictureBox.MouseDoubleClick, AddressOf DDC
            End If
            iCanvasPanel = Nothing
            iPictureBox = Nothing
            iDrawEngine = Nothing
        End If
        disposedValue = True
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
