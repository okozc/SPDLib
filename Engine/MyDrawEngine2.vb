Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing

Public Class MyDrawEngine2
    Implements IDisposable

    Public Enum EngineOperationMode
        Print
        Design
    End Enum

#Region "Unmanaged"
    Private iDocument As MyDocument
    Private WithEvents iCanvasPanel As Panel
    Private iSelectedArea As MyDocumentArea

#End Region
#Region "Managed"
    Private iOperationMode As EngineOperationMode
    Private WithEvents iPictureBox As PictureBox
    Private iPictureBoxImage As Bitmap

    Private iDocumentMargins As Margins
    Private iDocumentInfoWidth As Integer
    Private iDocumentInfoMarginLeft As Integer
    Private iContentWidthPanel As Panel
    Private iContentHeightPanel As Panel

    Private iTransformShift As Rectangle
    Private _iTransformShift As Rectangle
    Private iControlsOffset As Point
    Private _iControlsOffset As Point
    Private iSelectRectangle As PointsRectangle
    Private _iSelectRectangle As PointsRectangle
    Private iSelectRectangleAsLine As Boolean
    Private iAreaVSeparatorShift As Integer
    Private _iAreaVSeparatorShift As Integer
    Private iAreaHSeparatorShift As Integer
    Private _iAreaHSeparatorShift As Integer

    Private iSeparatorWidth As Integer
    Private iShowGrid As Boolean
    Private iGridSize As Size
    Private iShowPadding As Boolean

    Private iSelectedItems As List(Of MyItem)

    'Brushes
    Private iTransformHandleColor As Color
    Private iSelectRectangleColor As Color

    Private iDrawAllLabels As Boolean
    Private HLabels As Integer
    Private VLabels As Integer
    Private VSpace As Integer
    Private HSpace As Integer
#End Region

    Event ItemSelectionChanged()

    Private disposedValue As Boolean

#Region "Properties"
    Protected Friend ReadOnly Property OperationMode As EngineOperationMode
        Get
            Return iOperationMode
        End Get
    End Property
    Protected Friend ReadOnly Property CanvasPanel As Panel
        Get
            Return iCanvasPanel
        End Get
    End Property
    Protected Friend ReadOnly Property PictureBox As PictureBox
        Get
            Return iPictureBox
        End Get
    End Property
    Protected Friend Property Document As MyDocument
        Get
            Return iDocument
        End Get
        Set(value As MyDocument)
            iDocument = value
            HLabels = 0
            VLabels = 0
            HSpace = 0
            VSpace = 0
            iCanvasPanel.Invalidate(True)
        End Set
    End Property
    Protected Friend Property DocumentMargins As Margins
        Get
            Return iDocumentMargins
        End Get
        Set(value As Margins)
            iDocumentMargins = value
            iCanvasPanel.Invalidate(True)
        End Set
    End Property
    Protected Friend Property DocumentInfoWidth As Integer
        Get
            Return iDocumentInfoWidth
        End Get
        Set(value As Integer)
            iDocumentInfoWidth = value
            iCanvasPanel.Invalidate(True)
        End Set
    End Property
    Protected Friend Property TransformShift As Rectangle
        Get
            Return iTransformShift
        End Get
        Set(value As Rectangle)
            _iTransformShift = New Rectangle(iTransformShift.Location, iTransformShift.Size)
            iTransformShift = value
            If iSelectedItems.Count > 0 Then
                Dim AreaOffset As Point = GetAreaOffset(iSelectedArea)
                For Each Item In iSelectedItems
                    Dim UR As New Rectangle(Item.X + iTransformShift.X,
                                            Item.Y + iTransformShift.Y,
                                            Item.Width + -iTransformShift.X + iTransformShift.Width,
                                            Item.Height + -iTransformShift.Y + iTransformShift.Height)
                    Dim _UR As New Rectangle(Item.X + _iTransformShift.X,
                                            Item.Y + _iTransformShift.Y,
                                            Item.Width + -_iTransformShift.X + _iTransformShift.Width,
                                            Item.Height + -_iTransformShift.Y + _iTransformShift.Height)
                    UR.Offset(AreaOffset)
                    _UR.Offset(AreaOffset)
                    UR.Inflate(5, 5)
                    _UR.Inflate(5, 5)
                    iPictureBox.Invalidate(UR)
                    iPictureBox.Invalidate(_UR)
                Next
                iPictureBox.Update()
            End If
        End Set
    End Property
    Protected Friend Property ControlsOffset As Point
        Get
            Return iControlsOffset
        End Get
        Set(value As Point)
            _iControlsOffset = New Point(iControlsOffset)
            iControlsOffset = value
            If iSelectedItems.Count > 0 Then
                Dim AreaOffset As Point = GetAreaOffset(iSelectedArea)
                For Each Item In iSelectedItems
                    Dim UR As Rectangle = Item.GetRectangle
                    Dim _UR As Rectangle = Item.GetRectangle
                    UR.Offset(iControlsOffset + AreaOffset)
                    _UR.Offset(_iControlsOffset + AreaOffset)
                    UR.Inflate(5, 5)
                    _UR.Inflate(5, 5)
                    iPictureBox.Invalidate(UR)
                    iPictureBox.Invalidate(_UR)
                Next
                iPictureBox.Update()
            End If
        End Set
    End Property
    Protected Friend Property SelectRectangle As PointsRectangle
        Get
            Return iSelectRectangle
        End Get
        Set(value As PointsRectangle)
            _iSelectRectangle = iSelectRectangle.Clone
            iSelectRectangle = value
            Dim UR As Rectangle
            Dim _UR As Rectangle
            If iSelectRectangleAsLine Then
                UR = iSelectRectangle.GetRectangle
                _UR = _iSelectRectangle.GetRectangle
                UR.Inflate(10, 10)
                _UR.Inflate(10, 10)
            Else
                UR = iSelectRectangle.GetRectangle
                _UR = _iSelectRectangle.GetRectangle
            End If
            UR.Inflate(2, 2)
            _UR.Inflate(2, 2)
            iPictureBox.Invalidate(UR)
            iPictureBox.Invalidate(_UR)
            iPictureBox.Update()
        End Set
    End Property
    Protected Friend Property SelectRectangleAsLine As Boolean
        Get
            Return iSelectRectangleAsLine
        End Get
        Set(value As Boolean)
            iSelectRectangleAsLine = value
        End Set
    End Property
    Public Property AreaVerticalResizingShift As Integer
        Get
            Return iAreaVSeparatorShift
        End Get
        Set(value As Integer)
            _iAreaVSeparatorShift = iAreaVSeparatorShift
            iAreaVSeparatorShift = value
            Dim UR As Rectangle = GetAreaHSeparatorDrawRectangle(iSelectedArea)
            Dim _UR As Rectangle = GetAreaHSeparatorDrawRectangle(iSelectedArea)
            UR.Height = 1
            _UR.Height = 1
            UR.Offset(0, iAreaVSeparatorShift)
            _UR.Offset(0, _iAreaVSeparatorShift)
            iPictureBox.Invalidate(UR)
            iPictureBox.Invalidate(_UR)
            iPictureBox.Update()
        End Set
    End Property
    Public Property AreaHorizontalResizingShift As Integer
        Get
            Return iAreaHSeparatorShift
        End Get
        Set(value As Integer)
            _iAreaHSeparatorShift = iAreaHSeparatorShift
            iAreaHSeparatorShift = value
            Dim UR As Rectangle = GetAreaVSeparatorDrawRectangle(iSelectedArea)
            Dim _UR As Rectangle = GetAreaVSeparatorDrawRectangle(iSelectedArea)
            UR.Width = 1
            _UR.Width = 1
            UR.Offset(iAreaHSeparatorShift, 0)
            _UR.Offset(_iAreaHSeparatorShift, 0)
            iPictureBox.Invalidate(UR)
            iPictureBox.Invalidate(_UR)
            iPictureBox.Update()
        End Set
    End Property
    Protected Friend Property SeparatorWidth As Integer
        Get
            Return iSeparatorWidth
        End Get
        Set(value As Integer)
            If value < 1 Then
                iSeparatorWidth = 1
            Else
                iSeparatorWidth = value
            End If
            iCanvasPanel.Invalidate(True)
        End Set
    End Property
    Protected Friend Property ShowGrid As Boolean
        Get
            Return iShowGrid
        End Get
        Set(value As Boolean)
            iShowGrid = value
            iPictureBox.Invalidate()
            iPictureBox.Update()
        End Set
    End Property
    Protected Friend Property GridSize As Size
        Get
            Return iGridSize
        End Get
        Set(value As Size)
            iGridSize = value
            iPictureBox.Invalidate()
        End Set
    End Property
    Protected Friend Property ShowPadding As Boolean
        Get
            Return iShowPadding
        End Get
        Set(value As Boolean)
            iShowPadding = value
            iPictureBox.Invalidate()
            iPictureBox.Update()
        End Set
    End Property
    Protected Friend Property SelectedArea As MyDocumentArea
        Get
            Return iSelectedArea
        End Get
        Set(value As MyDocumentArea)
            If iSelectedArea <> value Then
                iSelectedArea = value
                iCanvasPanel.Invalidate(New Rectangle(0, iDocumentMargins.Top, iDocumentMargins.Left - 1, iPictureBox.Height), False)
            End If
        End Set
    End Property
    Protected Friend ReadOnly Property SelectedItems As List(Of MyItem)
        Get
            Return iSelectedItems
        End Get
    End Property

    Protected Friend Property TransformHandleColor As Color
        Get
            Return iTransformHandleColor
        End Get
        Set(value As Color)
            iTransformHandleColor = value
        End Set
    End Property
    Protected Friend Property SelectRectangleColor As Color
        Get
            Return iSelectRectangleColor
        End Get
        Set(value As Color)
            iSelectRectangleColor = value
        End Set
    End Property

    Protected Friend Property DrawAllLabels As Boolean
        Get
            Return iDrawAllLabels
        End Get
        Set(value As Boolean)
            iDrawAllLabels = value
            iPictureBox.Invalidate()
            iPictureBox.Update()
        End Set
    End Property

    Protected Friend Property MouseCursor As Cursor
        Get
            Return iPictureBox.Cursor
        End Get
        Set(value As Cursor)
            iPictureBox.Cursor = value
        End Set
    End Property
#End Region

    Protected Friend Sub New(CanvasPanel As Panel, Optional Document As MyDocument = Nothing)
        iCanvasPanel = CanvasPanel
        iOperationMode = EngineOperationMode.Design
        iPictureBoxImage = New Bitmap(1, 1)
        iPictureBox = New PictureBox With {
            .SizeMode = PictureBoxSizeMode.Normal,
            .BorderStyle = BorderStyle.None,
            .BackColor = Color.Transparent,
            .Image = iPictureBoxImage}
        iDocumentMargins = New Margins(50, 50, 75, 50)
        iDocumentInfoWidth = 150
        iDocumentInfoMarginLeft = 10
        iContentWidthPanel = New Panel With {
            .Height = 1,
            .BorderStyle = BorderStyle.None,
            .BackColor = Color.Transparent}
        iContentHeightPanel = New Panel With {
            .Width = 1,
            .BorderStyle = BorderStyle.None,
            .BackColor = Color.Transparent}
        With iCanvasPanel.Controls
            .Add(iPictureBox)
            .Add(iContentWidthPanel)
            .Add(iContentHeightPanel)
        End With

        iTransformShift = New Rectangle(0, 0, 0, 0)
        _iTransformShift = New Rectangle(0, 0, 0, 0)
        iControlsOffset = New Point(0, 0)
        _iControlsOffset = New Point(0, 0)
        iSelectRectangle = New PointsRectangle
        _iSelectRectangle = New PointsRectangle
        iSelectRectangleAsLine = False
        iAreaVSeparatorShift = 0
        _iAreaVSeparatorShift = 0
        iAreaHSeparatorShift = 0
        _iAreaHSeparatorShift = 0

        iSeparatorWidth = 2
        iShowGrid = False
        iGridSize = New Size(5, 5)
        iShowPadding = False
        iSelectedItems = New List(Of MyItem)

        iTransformHandleColor = Color.BlueViolet
        iSelectRectangleColor = Color.DodgerBlue

        iDrawAllLabels = False
        HLabels = 0
        VLabels = 0
        HSpace = 0
        VSpace = 0

        AddHandler iCanvasPanel.Paint, AddressOf CanvasPaint
        iCanvasPanel.Invalidate(True)
    End Sub
    Protected Friend Sub New()
        iOperationMode = EngineOperationMode.Print
    End Sub

#Region "Draw Engine"
    Private Sub CanvasPaint(ByVal s As Object, ByVal e As PaintEventArgs)
        If Not IsNothing(iDocument) Then
            Dim HOffset As Integer = iCanvasPanel.AutoScrollPosition.X
            Dim VOffset As Integer = iCanvasPanel.AutoScrollPosition.Y

            Dim iDesignerDocWidth As Integer
            Dim iDesignerDocHeight As Integer
            Select Case iDocument.DocumentType
                Case DocumentType.Page
                    iDesignerDocWidth = iDocument.PageWidth + (iSeparatorWidth * 2)
                    iDesignerDocHeight = iSeparatorWidth
                    For Each Area In iDocument.DocumentAreas
                        iDesignerDocHeight += Area.Height + iSeparatorWidth
                    Next
                Case DocumentType.MultiLabel
                    Dim Area As MyDocumentArea = iDocument.GetAreaByType(DocumentAreaType.MultiLabelBody)(0)
                    HLabels = Math.Floor(iDocument.PageWidth / Area.Width)
                    VLabels = Math.Floor(iDocument.PageHeight / Area.Height)
                    iDesignerDocWidth = iDocument.PageWidth + (iSeparatorWidth * (HLabels + 1))
                    iDesignerDocHeight = iDocument.PageHeight + (iSeparatorWidth * (VLabels + 1))
                    HSpace = Math.Floor((iPictureBox.Width - (iSeparatorWidth + ((Area.Width + iSeparatorWidth) * HLabels))) / 2)
                    VSpace = Math.Floor((iPictureBox.Height - (iSeparatorWidth + ((Area.Height + iSeparatorWidth) * VLabels))) / 2)
            End Select

            Dim iDocTop As Integer = iDocumentMargins.Top + VOffset
            Dim iDocLeft As Integer = iDocumentMargins.Left + HOffset
            Dim iInfoTop As Integer = iDocTop
            Dim iInfoLeft As Integer = iDocLeft + iDesignerDocWidth + iDocumentInfoMarginLeft
            Dim iRightSpacerTop As Integer = iDocTop
            Dim iRightSpacerLeft As Integer = iInfoLeft + iDocumentInfoWidth
            Dim iBottomSpacerTop As Integer = iDocTop + iDesignerDocHeight
            Dim iBottomSpacerLeft As Integer = iDocLeft

            'iDocWpx = iDesignerDocWidth + iSeparatorWidth
            'iDocHpx = iDesignerDocHeight

            iPictureBoxImage.Dispose()
            iPictureBoxImage = New Bitmap(iDesignerDocWidth, iDesignerDocHeight)

            With iPictureBox
                .Width = iDesignerDocWidth
                .Height = iDesignerDocHeight
                .BorderStyle = BorderStyle.None
                .BackColor = Color.White
                .Top = iDocTop
                .Left = iDocLeft
                .Image = iPictureBoxImage
            End With
            With iContentWidthPanel
                .Width = iDocumentMargins.Left + iDesignerDocWidth + iDocumentInfoMarginLeft + iDocumentInfoWidth + iDocumentMargins.Right
                .Height = 1
                .BorderStyle = BorderStyle.None
                .BackColor = Color.Transparent
                .Top = VOffset
                .Left = HOffset
            End With
            With iContentHeightPanel
                .Width = 1
                .Height = iDocumentMargins.Top + iDesignerDocHeight + iDocumentMargins.Bottom
                .BorderStyle = BorderStyle.None
                .BackColor = Color.Transparent
                .Top = VOffset
                .Left = HOffset
            End With

            Dim VPoint As Integer = iDocumentMargins.Top + iSeparatorWidth
            Dim HPoint As Integer = iDocumentMargins.Left + iPictureBox.Width - 1
            Dim bigArrow As New AdjustableArrowCap(10, 5)
            Dim littleArrow As New AdjustableArrowCap(5, 5)
            Dim iLinePen As New Pen(Color.Black)
            With iLinePen
                .Width = 1
                .CustomEndCap = bigArrow
            End With
            Dim iAreaHeightLinePen As New Pen(Color.Black)
            With iAreaHeightLinePen
                .Width = 1
                .CustomStartCap = littleArrow
                .CustomEndCap = littleArrow
            End With
            Dim infoFontV As New Font("Verdana", 7, FontStyle.Regular)
            Dim infoFontBrushV As New SolidBrush(Color.Black)
            Dim infoAreaWidthSF As New StringFormat(StringFormatFlags.DirectionVertical)
            Dim infoFont As New Font("Verdana", 9, FontStyle.Regular)
            Dim infoFontBrush As New SolidBrush(Color.Black)

            Dim th As Integer = 0
            Dim fs As String = ""
            Dim ph As String = ""
            Dim SF As New StringFormat
            SF.Alignment = StringAlignment.Center
            SF.LineAlignment = StringAlignment.Center
            fs = Format(pTOmm(iDocument.PageWidth), "#########")
            ph = Format(pTOmm(iDocument.PageHeight), "#########")
            Dim InfoRect As New Rectangle(iDocumentMargins.Left + HOffset + iSeparatorWidth, VOffset, iDocument.PageWidth, 40)
            e.Graphics.DrawString(iDocument.Name & " (" & iDocument.PageOrientation.ToString & ") " & fs & "x" & ph, New Font("Verdana", 11, FontStyle.Bold), infoFontBrush, InfoRect, SF)
            th = e.Graphics.MeasureString(fs & " mm", infoFontV).Width
            If iDocument.DocumentType = DocumentType.MultiLabel Then
                Dim Area As MyDocumentArea = iDocument.GetAreaByType(DocumentAreaType.MultiLabelBody)(0)
                e.Graphics.DrawString(Format(pTOmm(Area.Width), "#########") & " mm", infoFontV, infoFontBrushV,
                                      iDocumentMargins.Left + HOffset + HSpace + ((Area.Width / 2) - (th / 2)),
                                      VOffset + 40)
                e.Graphics.DrawLine(iAreaHeightLinePen,
                                    iDocLeft + HSpace + iSeparatorWidth,
                                    iDocumentMargins.Top - 15 + VOffset,
                                    iDocLeft + HSpace + iSeparatorWidth + Area.Width - 1,
                                    iDocumentMargins.Top - 15 + VOffset)
            Else
                e.Graphics.DrawString(fs & " mm", infoFontV, infoFontBrushV, iDocumentMargins.Left + HOffset + ((iDocument.PageWidth / 2) - (th / 2)), VOffset + 40)
                e.Graphics.DrawLine(iAreaHeightLinePen,
                                    iDocLeft + iSeparatorWidth,
                                    iDocumentMargins.Top - 15 + VOffset,
                                    iDocLeft + iDesignerDocWidth + iSeparatorWidth - (iSeparatorWidth * 2) - 1,
                                    iDocumentMargins.Top - 15 + VOffset)
            End If

            For Each Area In iDocument.DocumentAreas
                If Area = iSelectedArea Then
                    e.Graphics.DrawLine(iLinePen,
                                        iDocLeft - 15,
                                        VSpace + CInt(VPoint + (Area.Height / 2) + VOffset),
                                        iDocLeft - 14,
                                        VSpace + CInt(VPoint + (Area.Height / 2)) + VOffset)
                End If
                e.Graphics.DrawLine(iAreaHeightLinePen,
                                    HPoint + 15 + HOffset,
                                    VPoint + VSpace + VOffset,
                                    HPoint + 15 + HOffset,
                                    VPoint + VSpace + Area.Height + VOffset - 1)
                fs = Format(pTOmm(Area.Height), "### ### ###.#")
                th = e.Graphics.MeasureString(fs & " mm", infoFontV).Width
                e.Graphics.DrawString(fs & " mm", infoFontV, infoFontBrushV,
                                      HPoint + 20 + HOffset,
                                      VPoint + VSpace + ((Area.Height / 2) - (th / 2)) + VOffset,
                                      infoAreaWidthSF)
                th = e.Graphics.MeasureString(Area.Name, infoFont).Height
                e.Graphics.DrawString(Area.Name, infoFont, infoFontBrush,
                                      HPoint + 40 + HOffset,
                                      VPoint + VSpace + ((Area.Height / 2) - (th / 2)) + VOffset)
                VPoint += Area.Height + iSeparatorWidth
            Next
        End If
    End Sub
    Private Sub DocumentPaint(ByVal s As Object, ByVal e As PaintEventArgs) Handles iPictureBox.Paint
        If Not IsNothing(iDocument) Then
            Select Case iDocument.DocumentType
                Case DocumentType.Page
                    DrawAreaSeparator(Nothing, e.Graphics)
                    For Each Area In iDocument.DocumentAreas
                        Dim AreaOffset As New Point(iSeparatorWidth, GetAreaVOffset(Area))
                        Dim AreaRectangle As New Rectangle(AreaOffset.X, AreaOffset.Y, iDocument.PageWidth, Area.Height)
                        If iShowGrid Then
                            DrawGrid(AreaRectangle, iGridSize, e.Graphics)
                        End If
                        DrawAreaEdges(Area, e.Graphics)
                        DrawAreaSeparator(Area, e.Graphics)
                        For Each Item In Area.Items
                            DrawItem(AreaOffset, Item, e.Graphics, True)
                        Next
                        If iShowPadding Then
                            DrawPadding(Area, iDocument.Margins, e.Graphics)
                        End If
                    Next
                    For Each Item In iSelectedItems
                        DrawControls(GetAreaInnerDrawRectangle(Item).Location, Item, e.Graphics)
                    Next
                    DrawSelection(iSelectRectangle, e.Graphics)
                    If Not IsNothing(iSelectedArea) Then
                        DrawAreaVerticalSeparatorOutline(iSelectedArea, iAreaVSeparatorShift, e.Graphics)
                        DrawAreaHorizontalSeparatorOutline(iSelectedArea, iAreaHSeparatorShift, e.Graphics)
                    End If
                Case DocumentType.MultiLabel
                    Dim Area As MyDocumentArea = iDocument.GetAreaByType(DocumentAreaType.MultiLabelBody)(0)
                    Dim AreaOffset As Point = GetAreaOffset(Area)
                    Dim AreaRectangle As New Rectangle(AreaOffset, Area.GetLabelSize)

                    If iShowGrid Then
                        DrawGrid(AreaRectangle, iGridSize, e.Graphics)
                    End If
                    DrawLabelGrid(Area, e.Graphics)
                    If iShowPadding Then
                        DrawPadding(Area, iDocument.Margins, e.Graphics)
                    End If
                    For Each Item In Area.Items
                        DrawItem(AreaOffset, Item, e.Graphics, True)
                    Next
                    For Each Item In iSelectedItems
                        DrawControls(AreaOffset, Item, e.Graphics)
                    Next
                    DrawSelection(iSelectRectangle, e.Graphics)
                    If Not IsNothing(iSelectedArea) Then
                        DrawAreaVerticalSeparatorOutline(iSelectedArea, iAreaVSeparatorShift, e.Graphics)
                        DrawAreaHorizontalSeparatorOutline(iSelectedArea, iAreaHSeparatorShift, e.Graphics)
                    End If
            End Select

        End If
    End Sub
    Private Sub DrawItem(DrawingOffset As Point, Item As MyItem, g As Graphics, Optional DesignerMode As Boolean = False)
        'Debug.WriteLine("DrawItem ClipBounds " & g.ClipBounds.ToString)

        Dim LineItem As MyLineItem = Nothing
        Dim RectangleItem As MyRectangleItem = Nothing
        Dim ElypseItem As MyElypseItem = Nothing
        Dim TextItem As MyTextItem = Nothing
        Dim PictureItem As MyPictureItem = Nothing
        Dim DataItem As MyDataItem = Nothing
        Dim BarcodeItem As MyBarcodeItem = Nothing
        Dim ItemRectangle As Rectangle = Item.GetRectangle
        Dim ItemBorder As MyItemBorderStyle = Nothing
        Dim ItemBackgroundColor As Color = Color.Transparent
        Dim ItemPen As New Pen(Color.Black)
        Dim ItemDesignBorderPen As New Pen(Color.Gray, 1) With {.DashStyle = DashStyle.Dot}
        Dim ItemStringFormat As New StringFormat
        ItemRectangle.Offset(DrawingOffset)

        Select Case Item.Type
            Case ItemType.Line
                LineItem = CType(Item, MyLineItem)
            Case ItemType.Rectangle
                RectangleItem = CType(Item, MyRectangleItem)
                ItemBackgroundColor = RectangleItem.BackColor
            Case ItemType.Elypse
                ElypseItem = CType(Item, MyElypseItem)
                ItemBackgroundColor = ElypseItem.BackColor
            Case ItemType.Text
                TextItem = CType(Item, MyTextItem)
                ItemBorder = TextItem.Border
                ItemBackgroundColor = TextItem.BackColor
            Case ItemType.Picture
                PictureItem = CType(Item, MyPictureItem)
                ItemBorder = PictureItem.Border
                ItemBackgroundColor = PictureItem.BackColor
            Case ItemType.Data
                DataItem = CType(Item, MyDataItem)
                ItemBorder = DataItem.Border
                ItemBackgroundColor = DataItem.BackColor
            Case ItemType.Barcode
                BarcodeItem = CType(Item, MyBarcodeItem)
                ItemBorder = BarcodeItem.Border
                ItemBackgroundColor = BarcodeItem.BackColor
        End Select
        '(1)********** Draw Item Background
        If Item.Type = ItemType.Rectangle Or
           Item.Type = ItemType.Elypse Or
           Item.Type = ItemType.Text Or
           Item.Type = ItemType.Data Or
           Item.Type = ItemType.Picture Or
           Item.Type = ItemType.Barcode Then
            If DesignerMode And ItemBackgroundColor.ToArgb = 16777215 Then
                If ItemBackgroundColor = Color.Transparent Or ItemBackgroundColor = Color.FromArgb(Color.Transparent.ToArgb) Then
                    g.FillRectangle(New SolidBrush(Color.LemonChiffon), ItemRectangle)
                End If
                g.DrawRectangle(ItemDesignBorderPen, ItemRectangle.X, ItemRectangle.Y, ItemRectangle.Width - 1, ItemRectangle.Height - 1)
            Else
                g.FillRectangle(New SolidBrush(ItemBackgroundColor), ItemRectangle)
            End If
        End If
        '(2)********** Draw Item Content
        Select Case Item.Type
            Case ItemType.Line
                ItemPen.Color = LineItem.LineColor
                ItemPen.Width = LineItem.LineWidth
                g.DrawLine(ItemPen, LineItem.Location + DrawingOffset, LineItem.Location2 + DrawingOffset)
            Case ItemType.Rectangle
                Select Case RectangleItem.LineStyle
                    Case LineStyle.None
                        ItemPen.Color = Color.Transparent
                    Case LineStyle.Solid
                        ItemPen.DashStyle = DashStyle.Solid
                    Case LineStyle.Dotted
                        ItemPen.DashStyle = DashStyle.Dot
                    Case LineStyle.Dashed
                        ItemPen.DashStyle = DashStyle.Dash
                End Select
                ItemPen.Width = RectangleItem.LineWidth
                g.DrawRectangle(ItemPen, ItemRectangle.X, ItemRectangle.Y, ItemRectangle.Width - 1, ItemRectangle.Height - 1)
            Case ItemType.Elypse
                Select Case ElypseItem.LineStyle
                    Case LineStyle.None
                        ItemPen.Color = Color.Transparent
                    Case LineStyle.Solid
                        ItemPen.DashStyle = DashStyle.Solid
                    Case LineStyle.Dotted
                        ItemPen.DashStyle = DashStyle.Dot
                    Case LineStyle.Dashed
                        ItemPen.DashStyle = DashStyle.Dash
                End Select
                ItemPen.Width = ElypseItem.LineWidth
                g.FillEllipse(New SolidBrush(ElypseItem.FillColor), ItemRectangle.X, ItemRectangle.Y, ItemRectangle.Width - 1, ItemRectangle.Height - 1)
                g.DrawEllipse(ItemPen, ItemRectangle.X, ItemRectangle.Y, ItemRectangle.Width - 1, ItemRectangle.Height - 1)
            Case ItemType.Text
                Select Case TextItem.HorizontalAlignment
                    Case ItemHorizontalAlignment.Left
                        ItemStringFormat.Alignment = StringAlignment.Near
                    Case ItemHorizontalAlignment.Center
                        ItemStringFormat.Alignment = StringAlignment.Center
                    Case ItemHorizontalAlignment.Right
                        ItemStringFormat.Alignment = StringAlignment.Far
                End Select
                Select Case TextItem.VerticalAlignment
                    Case ItemVerticalAlignment.Top
                        ItemStringFormat.LineAlignment = StringAlignment.Near
                    Case ItemVerticalAlignment.Center
                        ItemStringFormat.LineAlignment = StringAlignment.Center
                    Case ItemVerticalAlignment.Bottom
                        ItemStringFormat.LineAlignment = StringAlignment.Far
                End Select
                If Not TextItem.WordWrap Then ItemStringFormat.FormatFlags = StringFormatFlags.NoWrap
                g.DrawString(TextItem.Text, TextItem.TextFont, New SolidBrush(TextItem.TextColor), ItemRectangle, ItemStringFormat)
            Case ItemType.Picture
                If Not IsNothing(PictureItem.Image) Then
                    If PictureItem.Scale Then
                        g.DrawImage(PictureItem.Image, ItemRectangle)
                    Else
                        g.DrawImageUnscaledAndClipped(PictureItem.Image, ItemRectangle)
                    End If
                End If
            Case ItemType.Data
                Select Case DataItem.HorizontalAlignment
                    Case ItemHorizontalAlignment.Left
                        ItemStringFormat.Alignment = StringAlignment.Near
                    Case ItemHorizontalAlignment.Center
                        ItemStringFormat.Alignment = StringAlignment.Center
                    Case ItemHorizontalAlignment.Right
                        ItemStringFormat.Alignment = StringAlignment.Far
                End Select
                Select Case DataItem.VerticalAlignment
                    Case ItemVerticalAlignment.Top
                        ItemStringFormat.LineAlignment = StringAlignment.Near
                    Case ItemVerticalAlignment.Center
                        ItemStringFormat.LineAlignment = StringAlignment.Center
                    Case ItemVerticalAlignment.Bottom
                        ItemStringFormat.LineAlignment = StringAlignment.Far
                End Select
                If Not DataItem.WordWrap Then ItemStringFormat.FormatFlags = StringFormatFlags.NoWrap
                g.DrawString(If(DesignerMode, DataItem.DataField.FriendlyName, DataItem.Value), DataItem.TextFont, New SolidBrush(DataItem.TextColor), ItemRectangle, ItemStringFormat)
            Case ItemType.Barcode
                DrawBarcode(ItemRectangle.Location, BarcodeItem, g, DesignerMode)
        End Select
        '(3)********** Draw Item Border
        If Item.Type = ItemType.Text Or
           Item.Type = ItemType.Picture Or
           Item.Type = ItemType.Data Or
           Item.Type = ItemType.Barcode Then
            Dim P As New Pen(Color.Black)
            P.EndCap = Drawing2D.LineCap.Square
            P.StartCap = Drawing2D.LineCap.Square
            P.Color = ItemBorder.ColorTop
            P.Width = ItemBorder.WidthTop
            Select Case ItemBorder.StyleTop
                Case LineStyle.Solid : P.DashStyle = Drawing2D.DashStyle.Solid
                Case LineStyle.Dotted : P.DashStyle = Drawing2D.DashStyle.Dot
                Case LineStyle.Dashed : P.DashStyle = Drawing2D.DashStyle.Dash
            End Select
            If ItemBorder.StyleTop <> LineStyle.None Then g.DrawLine(P, ItemRectangle.X, ItemRectangle.Y,
                                                                      ItemRectangle.X + ItemRectangle.Width - 1, ItemRectangle.Y)
            P.Color = ItemBorder.ColorLeft
            P.Width = ItemBorder.WidthLeft
            Select Case ItemBorder.StyleLeft
                Case LineStyle.Solid : P.DashStyle = Drawing2D.DashStyle.Solid
                Case LineStyle.Dotted : P.DashStyle = Drawing2D.DashStyle.Dot
                Case LineStyle.Dashed : P.DashStyle = Drawing2D.DashStyle.Dash
            End Select
            If ItemBorder.StyleLeft <> LineStyle.None Then g.DrawLine(P, ItemRectangle.X, ItemRectangle.Y,
                                                                       ItemRectangle.X, ItemRectangle.Y + ItemRectangle.Height - 1)
            P.Color = ItemBorder.ColorBottom
            P.Width = ItemBorder.WidthBottom
            Select Case ItemBorder.StyleBottom
                Case LineStyle.Solid : P.DashStyle = Drawing2D.DashStyle.Solid
                Case LineStyle.Dotted : P.DashStyle = Drawing2D.DashStyle.Dot
                Case LineStyle.Dashed : P.DashStyle = Drawing2D.DashStyle.Dash
            End Select
            If ItemBorder.StyleBottom <> LineStyle.None Then g.DrawLine(P, ItemRectangle.X, ItemRectangle.Y + ItemRectangle.Height - 1,
                                                                        ItemRectangle.X + ItemRectangle.Width - 1, ItemRectangle.Y + ItemRectangle.Height - 1)
            P.Color = ItemBorder.ColorRight
            P.Width = ItemBorder.WidthRight
            Select Case ItemBorder.StyleRight
                Case LineStyle.Solid : P.DashStyle = Drawing2D.DashStyle.Solid
                Case LineStyle.Dotted : P.DashStyle = Drawing2D.DashStyle.Dot
                Case LineStyle.Dashed : P.DashStyle = Drawing2D.DashStyle.Dash
            End Select
            If ItemBorder.StyleRight <> LineStyle.None Then g.DrawLine(P, ItemRectangle.X + ItemRectangle.Width - 1, ItemRectangle.Y,
                                                                       ItemRectangle.X + ItemRectangle.Width - 1, ItemRectangle.Y + ItemRectangle.Height - 1)
        End If
        '(4)********** Cleanup
        ItemStringFormat.Dispose()
        ItemPen.Dispose()
        ItemDesignBorderPen.Dispose()
    End Sub
    Private Sub DrawControls(DrawingOffset As Point, Item As MyItem, g As Graphics)
        Dim VOffset As Integer = DrawingOffset.Y
        Dim HOffset As Integer = DrawingOffset.X
        Dim tcPen As New Pen(Color.Black, 1)
        Dim tcbPen As New Pen(Color.Black, 1)
        Dim tcbBrush As New SolidBrush(iTransformHandleColor)
        tcPen.DashStyle = DashStyle.Dot
        tcbPen.DashStyle = DashStyle.Solid
        Dim hr As Rectangle
        Dim hrT As Rectangle
        Dim hrL As Rectangle
        Dim hrB As Rectangle
        Dim hrR As Rectangle
        If Item.Type = ItemType.Line Then
            Dim LineItem As MyLineItem = CType(Item, MyLineItem)
            Dim P1 As New Point(HOffset + LineItem.X, VOffset + LineItem.Y)
            Dim P2 As New Point(HOffset + LineItem.X2, VOffset + LineItem.Y2)
            hr = LineItem.GetRectangle
            hr.Offset(HOffset, VOffset)
            hr.Inflate(2, 2)
            hrL = New Rectangle(P1.X - 3, P1.Y - 3, 5, 5)
            hrR = New Rectangle(P2.X - 3, P2.Y - 3, 5, 5)

            With hr
                .X += iTransformShift.X
                .Y += iTransformShift.Y
                .Width += -iTransformShift.X + iTransformShift.Width
                .Height += -iTransformShift.Y + iTransformShift.Height
                .Offset(iControlsOffset)
            End With

            g.DrawRectangle(tcPen, hr)
            g.FillRectangle(tcbBrush, hrL)
            g.DrawRectangle(tcbPen, hrL)
            g.FillRectangle(tcbBrush, hrR)
            g.DrawRectangle(tcbPen, hrR)
        Else
            hr = New Rectangle(HOffset + Item.X - 2, VOffset + Item.Y - 2, Item.Width + 3, Item.Height + 3)
            hrT = New Rectangle(hr.X + (hr.Width / 2) - 3, hr.Y - 3, 5, 5)
            hrL = New Rectangle(hr.X - 3, hr.Y + (hr.Height / 2) - 3, 5, 5)
            hrB = New Rectangle(hr.X + (hr.Width / 2) - 3, hr.Y + hr.Height - 2, 5, 5)
            hrR = New Rectangle(hr.X + hr.Width - 2, hr.Y + (hr.Height / 2) - 3, 5, 5)

            With hr
                .X += iTransformShift.X
                .Y += iTransformShift.Y
                .Width += -iTransformShift.X + iTransformShift.Width
                .Height += -iTransformShift.Y + iTransformShift.Height
                .Offset(iControlsOffset)
            End With

            g.DrawRectangle(tcPen, hr)
            g.FillRectangle(tcbBrush, hrT)
            g.DrawRectangle(tcbPen, hrT)
            g.FillRectangle(tcbBrush, hrL)
            g.DrawRectangle(tcbPen, hrL)
            g.FillRectangle(tcbBrush, hrB)
            g.DrawRectangle(tcbPen, hrB)
            g.FillRectangle(tcbBrush, hrR)
            g.DrawRectangle(tcbPen, hrR)
        End If

        tcPen.Dispose()
        tcbPen.Dispose()
        tcbBrush.Dispose()
    End Sub
    Private Sub DrawSelection(SelectionRectangle As PointsRectangle, g As Graphics)
        Dim SRect As Rectangle = SelectionRectangle.GetRectangle
        If SRect.Width > 0 And SRect.Height > 0 Then
            Dim sPen As New Pen(iSelectRectangleColor, 1) With {
                .DashStyle = DashStyle.Solid}
            If iSelectRectangleAsLine Then
                g.DrawLine(sPen, SelectionRectangle.Point1, SelectionRectangle.Point2)
            Else
                g.DrawRectangle(sPen, SRect)
            End If
            sPen.Dispose()
        End If
    End Sub
    Private Sub DrawBarcode(DrawingOffset As Point, BarcodeItem As MyBarcodeItem, g As Graphics, Optional DesignerMode As Boolean = False)
        Dim bWidth As Integer
        Dim bHeight As Integer
        Dim BW As New ZXing.BarcodeWriter
        Dim I As Bitmap = Nothing
        Dim B As ZXing.Common.BitMatrix
        Dim SF As New StringFormat With {
                    .Alignment = StringAlignment.Center,
                    .LineAlignment = StringAlignment.Far,
                    .FormatFlags = StringFormatFlags.NoWrap}
        If BarcodeItem.HumanReadable Then
            Dim Tbr As New SolidBrush(BarcodeItem.TextColor)
            bWidth = BarcodeItem.Width
            bHeight = BarcodeItem.Height - g.MeasureString(BarcodeItem.Value, BarcodeItem.TextFont, BarcodeItem.Width, SF).ToSize.Height
            g.DrawString(BarcodeItem.Value, BarcodeItem.TextFont, Tbr, New Rectangle(DrawingOffset.X, DrawingOffset.Y + bHeight, bWidth, BarcodeItem.Height - bHeight), SF)
            Tbr.Dispose()
        Else
            bWidth = BarcodeItem.Width
            bHeight = BarcodeItem.Height
        End If
        Dim ValidValue As Boolean = False
        Select Case BarcodeItem.BarcodeType
            Case MyBarcodeItem.MyBarcodeType.Code39
                Dim Item As Code39 = CType(BarcodeItem, Code39)
                If Item.ValueIsValid(Item.Value) Then ValidValue = True
            Case MyBarcodeItem.MyBarcodeType.Code39Extended
                Dim Item As Code39EX = CType(BarcodeItem, Code39EX)
                If Item.ValueIsValid(Item.Value) Then
                    ValidValue = True
                    Item.EncodeValue()
                End If
            Case MyBarcodeItem.MyBarcodeType.Code128
                Dim Item As Code128 = CType(BarcodeItem, Code128)
                If Item.ValueIsValid(Item.Value) Then ValidValue = True
            Case MyBarcodeItem.MyBarcodeType.GS1_128

        End Select
        Select Case BarcodeItem.BarcodeType
            Case MyBarcodeItem.MyBarcodeType.Code39, MyBarcodeItem.MyBarcodeType.Code39Extended
                If ValidValue And bWidth > 0 And bHeight > 0 Then
                    Dim W As New ZXing.OneD.Code39Writer
                    BW.Encoder = W
                    Dim hints As New Dictionary(Of ZXing.EncodeHintType, Object)
                    hints.Add(ZXing.EncodeHintType.CHARACTER_SET, "UTF-8")
                    hints.Add(ZXing.EncodeHintType.PURE_BARCODE, True)
                    B = W.encode(If(BarcodeItem.BarcodeType = MyBarcodeItem.MyBarcodeType.Code39,
                                 BarcodeItem.Value, BarcodeItem.EncodedValue),
                                 ZXing.BarcodeFormat.CODE_39, bWidth * 2, bHeight * 2, hints)
                    I = BW.Write(B)
                    g.DrawImage(I, DrawingOffset.X + 1, DrawingOffset.Y + 1, bWidth - 2, bHeight - 2)

                    W = Nothing
                    hints = Nothing
                End If
            Case MyBarcodeItem.MyBarcodeType.Code128
                If ValidValue And bWidth > 0 And bHeight > 0 Then
                    Dim W As New ZXing.OneD.Code128Writer
                    BW.Encoder = W
                    Dim hints As New Dictionary(Of ZXing.EncodeHintType, Object)
                    hints.Add(ZXing.EncodeHintType.CHARACTER_SET, "UTF-8")
                    hints.Add(ZXing.EncodeHintType.PURE_BARCODE, True)
                    B = W.encode(BarcodeItem.Value, ZXing.BarcodeFormat.CODE_128, bWidth * 2, bHeight * 2, hints)
                    I = BW.Write(B)
                    g.DrawImage(I, DrawingOffset.X + 1, DrawingOffset.Y + 1, bWidth - 2, bHeight - 2)
                    W = Nothing
                    hints = Nothing
                End If
            Case MyBarcodeItem.MyBarcodeType.GS1_128

            Case MyBarcodeItem.MyBarcodeType.QrCode

            Case MyBarcodeItem.MyBarcodeType.DataMatrix
        End Select
        B = Nothing
        BW = Nothing
        SF.Dispose()
        If Not IsNothing(I) Then I.Dispose()
    End Sub

    Private Sub DrawAreaSeparator(Area As MyDocumentArea, g As Graphics)
        Dim SeparatorBrush As New HatchBrush(HatchStyle.Vertical, Color.White, Color.DarkGray)
        Dim AreaSepRect As Rectangle = GetAreaHSeparatorDrawRectangle(Area)
        AreaSepRect.Width += iSeparatorWidth * 2
        AreaSepRect.Offset(-iSeparatorWidth, 0)
        g.FillRectangle(SeparatorBrush, AreaSepRect)
        SeparatorBrush.Dispose()
    End Sub
    Private Sub DrawAreaEdges(Area As MyDocumentArea, g As Graphics)
        Dim SeparatorBrush As New Drawing2D.HatchBrush(Drawing2D.HatchStyle.Horizontal, Color.White, Color.DarkGray)
        Dim LeftRect As Rectangle = GetAreaDrawRectangle(Area)
        Dim RightRect As Rectangle = GetAreaDrawRectangle(Area)
        LeftRect.Width = iSeparatorWidth
        RightRect.X = RightRect.Width + iSeparatorWidth
        RightRect.Width = iSeparatorWidth
        g.FillRectangle(SeparatorBrush, LeftRect)
        g.FillRectangle(SeparatorBrush, RightRect)
        SeparatorBrush.Dispose()
    End Sub
    Private Sub DrawLabelGrid(Area As MyDocumentArea, g As Graphics)
        Dim HBrush As New Drawing2D.HatchBrush(Drawing2D.HatchStyle.Vertical, Color.White, Color.DarkGray)
        Dim VBrush As New Drawing2D.HatchBrush(Drawing2D.HatchStyle.Horizontal, Color.White, Color.DarkGray)
        Dim NBrush As New SolidBrush(Color.Gainsboro)
        Dim VOffset As Integer
        Dim HOffset As Integer
        Dim AreaDrawRect As Rectangle = Area.GetRectangle
        AreaDrawRect.Inflate(iSeparatorWidth, iSeparatorWidth)
        For V = 0 To VLabels - 1
            VOffset = VSpace + ((Area.Height + iSeparatorWidth) * V)
            For H = 0 To HLabels - 1
                HOffset = HSpace + ((Area.Width + iSeparatorWidth) * H)
                AreaDrawRect.Location = New Point(HOffset, VOffset)
                If Not (V = 0 And H = 0) Then
                    g.FillRectangle(NBrush, AreaDrawRect)
                    If iDrawAllLabels Then
                        DrawArea(New Point(HOffset + iSeparatorWidth, VOffset + iSeparatorWidth), Area, g, False)
                    End If
                End If
                Dim TR As New Rectangle(AreaDrawRect.X, AreaDrawRect.Y, AreaDrawRect.Width, iSeparatorWidth)
                Dim BR As New Rectangle(AreaDrawRect.X, AreaDrawRect.Bottom - iSeparatorWidth, AreaDrawRect.Width, iSeparatorWidth)
                Dim LR As New Rectangle(AreaDrawRect.X, AreaDrawRect.Y, iSeparatorWidth, AreaDrawRect.Height)
                Dim RR As New Rectangle(AreaDrawRect.Right - iSeparatorWidth, AreaDrawRect.Y, iSeparatorWidth, AreaDrawRect.Height)
                g.FillRectangle(VBrush, LR)
                g.FillRectangle(VBrush, RR)
                g.FillRectangle(HBrush, TR)
                g.FillRectangle(HBrush, BR)
            Next
        Next
        HBrush.Dispose()
        VBrush.Dispose()
        NBrush.Dispose()
    End Sub
    Private Sub DrawSelectOutline(SelectRectangle As Rectangle, g As Graphics)
        Dim tcPen As New Pen(Color.Black, 1)
        Dim SRect As New Rectangle(SelectRectangle.Location, SelectRectangle.Size)
        SRect.Width -= 1
        SRect.Height -= 1
        tcPen.DashStyle = DashStyle.Dash
        g.DrawRectangle(tcPen, SRect)
    End Sub
    Private Sub DrawAreaVerticalSeparatorOutline(Area As MyDocumentArea, Shift As Integer, g As Graphics)
        If Shift <> 0 Then
            Dim tcPen As New Pen(Color.Black, 1) With {.DashStyle = DashStyle.Dash}
            Dim sRect As Rectangle = GetAreaHSeparatorDrawRectangle(Area)
            g.DrawLine(tcPen, sRect.X, sRect.Y + Shift, sRect.Right, sRect.Y + Shift)
            tcPen.Dispose()
        End If
    End Sub
    Private Sub DrawAreaHorizontalSeparatorOutline(Area As MyDocumentArea, Shift As Integer, g As Graphics)
        If Shift <> 0 Then
            Dim tcPen As New Pen(Color.Black, 1) With {.DashStyle = DashStyle.Dash}
            Dim sRect As Rectangle = GetAreaVSeparatorDrawRectangle(Area)
            g.DrawLine(tcPen, sRect.X + Shift, sRect.Y, sRect.X + Shift, sRect.Bottom)
            tcPen.Dispose()
        End If
    End Sub
    Private Sub DrawGrid(GridRectangle As Rectangle, GridSpacing As Size, g As Graphics)
        Dim Pattern As New Bitmap(GridSpacing.Width, GridSpacing.Height)
        g.RenderingOrigin = New Point(GridRectangle.Location)
        For i = 0 To GridSpacing.Width - 1
            Pattern.SetPixel(i, 0, Color.LightGray)
        Next
        For i = 0 To GridSpacing.Height - 1
            Pattern.SetPixel(0, i, Color.LightGray)
        Next
        Dim PatternBrush As New TextureBrush(Pattern, WrapMode.Tile)
        g.FillRectangle(PatternBrush, GridRectangle)

        PatternBrush.Dispose()
        Pattern.Dispose()
    End Sub
    Private Sub DrawPadding(Area As MyDocumentArea, Padding As Margins, g As Graphics)
        Dim tcPen As New Pen(Color.LightCoral, 1) With {.DashStyle = DashStyle.Solid}
        Dim AreaRect As Rectangle
        If Area.Type = DocumentAreaType.MultiLabelBody Then
            AreaRect = New Rectangle(iSeparatorWidth, iSeparatorWidth, iPictureBox.Width - (iSeparatorWidth * 2), iPictureBox.Height - (iSeparatorWidth * 2))
        Else
            AreaRect = GetAreaInnerDrawRectangle(Area)
        End If
        Select Case Area.Type
            Case DocumentAreaType.Header1stPage, DocumentAreaType.HeaderAllPages
                g.DrawLine(tcPen, AreaRect.X + Padding.Left, AreaRect.Y + Padding.Top, AreaRect.Right - Padding.Right, AreaRect.Y + Padding.Top) 'TOP
                g.DrawLine(tcPen, AreaRect.X + Padding.Left, AreaRect.Y + Padding.Top, AreaRect.X + Padding.Left, AreaRect.Bottom) 'LEFT
                g.DrawLine(tcPen, AreaRect.Right - Padding.Right, AreaRect.Y + Padding.Top, AreaRect.Right - Padding.Right, AreaRect.Bottom) 'RIGHT
            Case DocumentAreaType.Footer1stPage, DocumentAreaType.FooterAllPages
                g.DrawLine(tcPen, AreaRect.X + Padding.Left, AreaRect.Bottom - Padding.Bottom, AreaRect.Right - Padding.Right, AreaRect.Bottom - Padding.Bottom) 'BOTTOM
                g.DrawLine(tcPen, AreaRect.X + Padding.Left, AreaRect.Y, AreaRect.X + Padding.Left, AreaRect.Bottom - Padding.Bottom) 'LEFT
                g.DrawLine(tcPen, AreaRect.Right - Padding.Right, AreaRect.Y, AreaRect.Right - Padding.Right, AreaRect.Bottom - Padding.Bottom) 'RIGHT
            Case DocumentAreaType.Body
                g.DrawLine(tcPen, AreaRect.X + Padding.Left, AreaRect.Y, AreaRect.X + Padding.Left, AreaRect.Bottom) 'LEFT
                g.DrawLine(tcPen, AreaRect.Right - Padding.Right, AreaRect.Y, AreaRect.Right - Padding.Right, AreaRect.Bottom) 'RIGHT
            Case DocumentAreaType.MultiLabelBody
                g.DrawLine(tcPen, AreaRect.X + Padding.Left, AreaRect.Y + Padding.Top, AreaRect.Right - Padding.Right, AreaRect.Y + Padding.Top) 'TOP
                g.DrawLine(tcPen, AreaRect.X + Padding.Left, AreaRect.Bottom - Padding.Bottom, AreaRect.Right - Padding.Right, AreaRect.Bottom - Padding.Bottom) 'BOTTOM
                g.DrawLine(tcPen, AreaRect.X + Padding.Left, AreaRect.Y + Padding.Top, AreaRect.X + Padding.Left, AreaRect.Bottom - Padding.Bottom) 'LEFT
                g.DrawLine(tcPen, AreaRect.Right - Padding.Right, AreaRect.Y + Padding.Top, AreaRect.Right - Padding.Right, AreaRect.Bottom - Padding.Bottom) 'RIGHT
        End Select
    End Sub
    Protected Friend Sub DrawArea(DrawingOffset As Point, Area As MyDocumentArea, g As Graphics, Optional Designermode As Boolean = False)
        For Each Item In Area.Items
            DrawItem(DrawingOffset, Item, g, Designermode)
        Next
    End Sub
    Protected Friend Sub DrawItem(Item As MyItem, Optional InvalidateWithControlls As Boolean = False)
        Dim UR As Rectangle = Item.GetRectangle
        UR.Offset(GetAreaOffset(Item))
        If iSelectedItems.Contains(Item) Or InvalidateWithControlls Then UR.Inflate(10, 10)
        iPictureBox.Invalidate(UR)
        iPictureBox.Update()
    End Sub
    Protected Friend Sub RedrawSelectedItems()
        For Each Item In iSelectedItems
            DrawItem(Item)
        Next
    End Sub
    Protected Friend Sub RedrawArea(Area As MyDocumentArea)
        Dim InvRect As Rectangle = GetAreaInnerDrawRectangle(Area)
        InvRect.Inflate(iSeparatorWidth + 5, iSeparatorWidth + 5)
        iPictureBox.Invalidate(InvRect)
        iPictureBox.Update()
    End Sub
    Protected Friend Sub RedrawDocument()
        iPictureBox.Invalidate()
        iPictureBox.Update()
    End Sub
#End Region

    Protected Friend Function GetAreaVOffset(Item As MyItem) As Integer
        For Each iArea In iDocument.DocumentAreas
            If iArea.Items.Contains(Item) Then
                Return GetAreaVOffset(iArea)
            End If
        Next
        Return 0
    End Function
    Protected Friend Function GetAreaVOffset(Area As MyDocumentArea) As Integer
        Dim VPoint As Integer = VSpace + iSeparatorWidth
        For Each iArea In iDocument.DocumentAreas
            If iArea = Area Then
                Return VPoint
            End If
            VPoint += iArea.Height + iSeparatorWidth
        Next
        Return 0
    End Function
    Protected Friend Function GetAreaOffset(Area As MyDocumentArea) As Point
        Dim Offset As New Point(HSpace + iSeparatorWidth, GetAreaVOffset(Area))
        Return Offset
    End Function
    Protected Friend Function GetAreaOffset(Item As MyItem) As Point
        For Each Area In iDocument.DocumentAreas
            If Area.Items.Contains(Item) Then
                Return GetAreaOffset(Area)
            End If
        Next
        Return Nothing
    End Function
    Protected Friend Function GetItemDrawRectangle(Item As MyItem) As Rectangle
        Dim IRe As Rectangle = Item.GetRectangle
        IRe.Offset(HSpace + iSeparatorWidth, GetAreaVOffset(Item))
        Return IRe
    End Function
    Protected Friend Function GetAreaDrawRectangle(Area As MyDocumentArea) As Rectangle
        Dim ARe As Rectangle
        Select Case Area.Type
            Case DocumentAreaType.MultiLabelBody
                ARe = New Rectangle(HSpace, GetAreaVOffset(Area), Area.Width, Area.Height)
            Case Else
                ARe = New Rectangle(HSpace, GetAreaVOffset(Area), iDocument.PageWidth, Area.Height)
        End Select
        Return ARe
    End Function
    Protected Friend Function GetAreaInnerDrawRectangle(Area As MyDocumentArea) As Rectangle
        Dim ARe As Rectangle
        Select Case Area.Type
            Case DocumentAreaType.MultiLabelBody
                ARe = New Rectangle(HSpace + iSeparatorWidth, GetAreaVOffset(Area), Area.Width, Area.Height)
            Case Else
                ARe = New Rectangle(HSpace + iSeparatorWidth, GetAreaVOffset(Area), iDocument.PageWidth, Area.Height)
        End Select
        Return ARe
    End Function
    Protected Friend Function GetAreaInnerDrawRectangle(Item As MyItem) As Rectangle
        Dim Area As MyDocumentArea = GetItemArea(Item)
        Return GetAreaInnerDrawRectangle(Area)
    End Function
    Protected Friend Function GetAreaHSeparatorDrawRectangle(Area As MyDocumentArea) As Rectangle
        If IsNothing(Area) Then
            Return New Rectangle(iSeparatorWidth, 0, iDocument.PageWidth, iSeparatorWidth)
        End If
        Dim SRe As Rectangle
        Select Case Area.Type
            Case DocumentAreaType.MultiLabelBody
                SRe = New Rectangle(HSpace + iSeparatorWidth, GetAreaVOffset(Area) + Area.Height, Area.Width, iSeparatorWidth)
            Case Else
                SRe = New Rectangle(iSeparatorWidth, GetAreaVOffset(Area) + Area.Height, iDocument.PageWidth, iSeparatorWidth)
        End Select
        Return SRe
    End Function
    Protected Friend Function GetAreaVSeparatorDrawRectangle(Area As MyDocumentArea) As Rectangle
        Dim SRe As Rectangle
        Select Case Area.Type
            Case DocumentAreaType.MultiLabelBody
                SRe = New Rectangle(HSpace + iSeparatorWidth + Area.Width - 1, GetAreaVOffset(Area), iSeparatorWidth, Area.Height)
            Case Else
                SRe = New Rectangle(iSeparatorWidth + iDocument.PageWidth - 1, GetAreaVOffset(Area), iSeparatorWidth, iDocument.PageHeight)
        End Select
        Return SRe
    End Function
    Protected Friend Function GetItemArea(Item As MyItem) As MyDocumentArea
        For Each Area In iDocument.DocumentAreas
            If Area.Items.Contains(Item) Then Return Area
        Next
        Return Nothing
    End Function


    Protected Friend Sub ClearSelectedItems()
        iSelectedItems.Clear()
        If Not IsNothing(iSelectedArea) Then
            RedrawArea(iSelectedArea)
        End If
        RaiseEvent ItemSelectionChanged()
    End Sub
    Protected Friend Sub AddSelectedItem(Item As MyItem)
        iSelectedItems.Add(Item)
        RedrawSelectedItems()
        RaiseEvent ItemSelectionChanged()
    End Sub
    Protected Friend Sub RemoveSelectedItem(Item As MyItem)
        If iSelectedItems.Contains(Item) Then
            iSelectedItems.Remove(Item)
            DrawItem(Item, True)
            RaiseEvent ItemSelectionChanged()
        End If
    End Sub

#Region "IDisposable Support"
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                iOperationMode = Nothing
                If Not IsNothing(iPictureBoxImage) Then iPictureBoxImage.Dispose()
                iPictureBoxImage = Nothing
                If Not IsNothing(iPictureBox) Then iPictureBox.Dispose()
                iPictureBox = Nothing
                iDocumentMargins = Nothing
                iDocumentInfoWidth = Nothing
                iDocumentInfoMarginLeft = Nothing
                If Not IsNothing(iContentWidthPanel) Then iContentWidthPanel.Dispose()
                iContentWidthPanel = Nothing
                If Not IsNothing(iContentHeightPanel) Then iContentHeightPanel.Dispose()
                iContentHeightPanel = Nothing
                iTransformShift = Nothing
                _iTransformShift = Nothing
                iControlsOffset = Nothing
                _iControlsOffset = Nothing
                If Not IsNothing(iSelectRectangle) Then iSelectRectangle.Dispose()
                iSelectRectangle = Nothing
                If Not IsNothing(_iSelectRectangle) Then _iSelectRectangle.Dispose()
                _iSelectRectangle = Nothing
                iSelectRectangleAsLine = Nothing
                iAreaVSeparatorShift = Nothing
                _iAreaVSeparatorShift = Nothing
                iAreaHSeparatorShift = Nothing
                _iAreaHSeparatorShift = Nothing
                iSeparatorWidth = Nothing
                iShowGrid = Nothing
                iGridSize = Nothing
                iShowPadding = Nothing
                If Not IsNothing(iSelectedItems) Then iSelectedItems.Clear()
                iSelectedItems = Nothing
                iTransformHandleColor = Nothing
                iSelectRectangleColor = Nothing
                iDrawAllLabels = Nothing
                HLabels = Nothing
                VLabels = Nothing
                HSpace = Nothing
                VSpace = Nothing
            End If
            iDocument = Nothing
            iCanvasPanel = Nothing
            iSelectedArea = Nothing
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
