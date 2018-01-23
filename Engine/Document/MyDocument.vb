Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.Xml

Public Enum DocumentPageOrientation
    Portrait
    Landscape
End Enum
Public Enum DocumentType
    Page
    MultiLabel
End Enum

<ToolboxBitmap(GetType(FlowLayoutPanel))> Public Class MyDocument
    Implements IComponent

    Private iDocumentAreas As List(Of MyDocumentArea)
    Private iPageWidth As Integer
    Private iPageHeight As Integer
    Private iMargins As Margins
    Private iPageOrientation As DocumentPageOrientation
    Private iDocumentType As DocumentType
    Private iDocumentName As String
    Private iStaticFields As List(Of MyField)
    Public Event DocumentChanged()

    Private curSite As ISite
    Public Event Disposed As EventHandler Implements IComponent.Disposed

    <Browsable(False)> Public Property Site As ISite Implements IComponent.Site
        Get
            Return curSite
        End Get
        Set(value As ISite)
            curSite = value
        End Set
    End Property
    <Browsable(False)> Protected Friend ReadOnly Property DocumentAreas As List(Of MyDocumentArea)
        Get
            Return iDocumentAreas
        End Get
    End Property
    Public Property PageWidth As Integer
        Get
            If iPageOrientation = DocumentPageOrientation.Portrait Then
                Return iPageWidth
            Else
                Return iPageHeight
            End If
        End Get
        Set(value As Integer)
            iPageWidth = value
        End Set
    End Property
    Public Property PageHeight As Integer
        Get
            If iPageOrientation = DocumentPageOrientation.Portrait Then
                Return iPageHeight
            Else
                Return iPageWidth
            End If
        End Get
        Set(value As Integer)
            iPageHeight = value
        End Set
    End Property
    Public Property Margins As Margins
        Get
            Return iMargins
        End Get
        Set(value As Margins)
            iMargins = value
        End Set
    End Property

    <[ReadOnly](True)> Public Property PageOrientation As DocumentPageOrientation
        Get
            Return iPageOrientation
        End Get
        Set(value As DocumentPageOrientation)
            iPageOrientation = value
        End Set
    End Property
    <[ReadOnly](True)> Public Property DocumentType As DocumentType
        Get
            Return iDocumentType
        End Get
        Set(value As DocumentType)
            iDocumentType = value
        End Set
    End Property
    Public Property Name As String
        Get
            Return iDocumentName
        End Get
        Set(value As String)
            iDocumentName = value
        End Set
    End Property
    Public ReadOnly Property StaticFields As List(Of MyField)
        Get
            Return iStaticFields
        End Get
    End Property

    Sub New(PageWidth_px As Integer, PageHeight_px As Integer, Margins_px As Margins, PageOrientation As DocumentPageOrientation, DocumentType As DocumentType)
        iDocumentAreas = New List(Of MyDocumentArea)
        iPageWidth = PageWidth_px
        iPageHeight = PageHeight_px
        iMargins = Margins_px
        iPageOrientation = PageOrientation
        iDocumentType = DocumentType
        iDocumentName = "Document"
        iStaticFields = New List(Of MyField) From {
            New MyStaticField("PageNumber", "#", MyField.MyValueType.Number) With {.FriendlyName = "Page Number"},
            New MyStaticField("TotalPages", "#", MyField.MyValueType.Number) With {.FriendlyName = "Total Pages"},
            New MyStaticField("DocumentName", "", MyField.MyValueType.Text) With {.FriendlyName = "Document Name"}
        }
    End Sub
    Sub New()
        Me.New(794, 1123, New Margins(10, 10, 15, 15), DocumentPageOrientation.Portrait, DocumentType.Page)
    End Sub

    Public Function GetAreaByID(AreaID As String) As MyDocumentArea
        For Each Area As MyDocumentArea In iDocumentAreas
            If Area.ID = AreaID Then Return Area
        Next
        Return Nothing
    End Function
    Public Function GetAreaByName(AreaName As String) As MyDocumentArea
        For Each Area As MyDocumentArea In iDocumentAreas
            If Area.Name = AreaName Then Return Area
        Next
        Return Nothing
    End Function
    Public Function GetAreaByType(AreaType As DocumentAreaType) As List(Of MyDocumentArea)
        Dim AreaList As New List(Of MyDocumentArea)
        For Each Area As MyDocumentArea In iDocumentAreas
            If Area.Type = AreaType Then AreaList.Add(Area)
        Next
        Return AreaList
    End Function

    Public Function GetFieldByName(FieldName As String) As MyField
        For Each Fld In iStaticFields
            If Fld.Name = FieldName Then Return Fld
        Next
        Return Nothing
    End Function

    Public Sub AddArea(Area As MyDocumentArea)
        Select Case iDocumentType
            Case DocumentType.Page
                Select Case Area.Type
                    Case DocumentAreaType.Header1stPage
                        If Not AreaExists(DocumentAreaType.Header1stPage) Then
                            iDocumentAreas.Add(Area)
                            RaiseEvent DocumentChanged()
                        Else
                            Throw New Exception("Area of type 'Header1stPage' allready exists. Only one per document allowed.")
                        End If
                    Case DocumentAreaType.HeaderAllPages
                        If Not AreaExists(DocumentAreaType.HeaderAllPages) Then
                            iDocumentAreas.Add(Area)
                            RaiseEvent DocumentChanged()
                        Else
                            Throw New Exception("Area of type 'HeaderAllPages' allready exists. Only one per document allowed.")
                        End If
                    Case DocumentAreaType.Footer1stPage
                        If Not AreaExists(DocumentAreaType.Footer1stPage) Then
                            iDocumentAreas.Add(Area)
                            RaiseEvent DocumentChanged()
                        Else
                            Throw New Exception("Area of type 'Footer1stPage' allready exists. Only one per document allowed.")
                        End If
                    Case DocumentAreaType.FooterAllPages
                        If Not AreaExists(DocumentAreaType.FooterAllPages) Then
                            iDocumentAreas.Add(Area)
                            RaiseEvent DocumentChanged()
                        Else
                            Throw New Exception("Area of type 'FooterAllPages' allready exists. Only one per document allowed.")
                        End If
                    Case DocumentAreaType.Body
                        iDocumentAreas.Add(Area)
                        RaiseEvent DocumentChanged()
                    Case DocumentAreaType.MultiLabelBody
                        If Not AreaExists(DocumentAreaType.MultiLabelBody) Then
                            iDocumentAreas.Add(Area)
                            RaiseEvent DocumentChanged()
                        Else
                            Throw New Exception("Area of type 'MultiLabelBody' not allowed in 'DocumentType.Page'.")
                        End If
                End Select
            Case DocumentType.MultiLabel
                Select Case Area.Type
                    Case DocumentAreaType.MultiLabelBody
                        If Not AreaExists(DocumentAreaType.MultiLabelBody) Then
                            iDocumentAreas.Add(Area)
                            RaiseEvent DocumentChanged()
                        Else
                            Throw New Exception("Area of type 'MultiLabelBody' allready exists. Only one per document allowed.")
                        End If
                    Case Else
                        Throw New Exception("Only area of type 'MultiLabelBody' allowed in 'DocumentType.MultiLabel'.")
                End Select
        End Select

    End Sub
    Public Sub SortAreas()
        Select Case iDocumentType
            Case DocumentType.Page
                Dim iList As New List(Of MyDocumentArea)
                If AreaExists(DocumentAreaType.Header1stPage) Then iList.Add(GetAreaByType(DocumentAreaType.Header1stPage)(0))
                If AreaExists(DocumentAreaType.HeaderAllPages) Then iList.Add(GetAreaByType(DocumentAreaType.HeaderAllPages)(0))
                If AreaExists(DocumentAreaType.Body) Then iList.AddRange(GetAreaByType(DocumentAreaType.Body))
                If AreaExists(DocumentAreaType.Footer1stPage) Then iList.Add(GetAreaByType(DocumentAreaType.Footer1stPage)(0))
                If AreaExists(DocumentAreaType.FooterAllPages) Then iList.Add(GetAreaByType(DocumentAreaType.FooterAllPages)(0))
                iDocumentAreas.Clear()
                iDocumentAreas = iList
        End Select
    End Sub

    Public Function AreaExists(Area As DocumentAreaType) As Boolean
        For Each ar In iDocumentAreas
            If ar.Type = Area Then Return True
        Next
        Return False
    End Function

    Public Function GetDocumentSlice(HParts As Integer, VParts As Integer) As Size
        Dim SWidth As Integer
        Dim SHeight As Integer
        SWidth = Math.Floor(PageWidth / HParts)
        SHeight = Math.Floor(PageHeight / VParts)
        Return New Size(SWidth, SHeight)
    End Function

#Region "Export / Import"
    Public Function GetXML() As XmlDocument
        Dim XMLex As New XmlDocument
        Dim MainNode As XmlNode = XMLex.CreateNode(XmlNodeType.Element, "SPDLibDocument", "")
        CreateAttribute(XMLex, MainNode, "Name", Name)
        CreateAttribute(XMLex, MainNode, "Width", iPageWidth.ToString)
        CreateAttribute(XMLex, MainNode, "Height", iPageHeight.ToString)
        CreateAttribute(XMLex, MainNode, "Orientation", iPageOrientation.ToString)
        CreateAttribute(XMLex, MainNode, "Type", iDocumentType.ToString)
        CreateAttribute(XMLex, MainNode, "Margins", iMargins.Left & "," & iMargins.Right & "," & iMargins.Top & "," & iMargins.Bottom)
        'For Each SField As MyStaticField In iStaticFields
        '    Dim FieldNode As XmlNode = XMLex.CreateNode(XmlNodeType.Element, "StaticField", "")

        '    MainNode.AppendChild(FieldNode)
        'Next
        For Each Area In DocumentAreas
            Dim AreaNode As XmlNode = XMLex.CreateNode(XmlNodeType.Element, "Area", "")
            CreateAttribute(XMLex, AreaNode, "Name", Area.Name)
            CreateAttribute(XMLex, AreaNode, "ID", Area.ID)
            CreateAttribute(XMLex, AreaNode, "Width", Area.Width)
            CreateAttribute(XMLex, AreaNode, "Height", Area.Height)
            CreateAttribute(XMLex, AreaNode, "DynamicH", Area.DynamicHeight)
            CreateAttribute(XMLex, AreaNode, "Type", Area.Type.ToString)
            CreateAttribute(XMLex, AreaNode, "DataSource", Area.DataSourceType.ToString)
            Select Case Area.DataSourceType
                Case MyDocumentArea.MyDataSourceType.SQLQuery
                    Dim QueryNode As XmlNode = XMLex.CreateNode(XmlNodeType.Element, "SQLQuery", "")
                    QueryNode.InnerText = Area.DataSourceSQLQuery
                    AreaNode.AppendChild(QueryNode)
                Case MyDocumentArea.MyDataSourceType.ODBCQuery
                    Dim QueryNode As XmlNode = XMLex.CreateNode(XmlNodeType.Element, "ODBCQuery", "")
                    QueryNode.InnerText = Area.DataSourceODBCQuery
                    AreaNode.AppendChild(QueryNode)
            End Select
            For Each AreaFL As MyDataField In Area.GetFieldsByType(MyField.MyFieldType.DataField)
                Dim FieldNode As XmlNode = XMLex.CreateNode(XmlNodeType.Element, "Field", "")
                CreateAttribute(XMLex, FieldNode, "Name", AreaFL.Name)
                CreateAttribute(XMLex, FieldNode, "FName", AreaFL.FriendlyName)
                CreateAttribute(XMLex, FieldNode, "Type", AreaFL.Type.ToString)
                CreateAttribute(XMLex, FieldNode, "ValueType", AreaFL.ValueType)
                CreateAttribute(XMLex, FieldNode, "Format", AreaFL.Format)
                FieldNode.InnerText = AreaFL.Value
                AreaNode.AppendChild(FieldNode)
            Next
            For Each AreaFN As MyFunctionField In Area.GetFieldsByType(MyField.MyFieldType.FunctionField)
                Dim FieldNode As XmlNode = XMLex.CreateNode(XmlNodeType.Element, "Field", "")
                CreateAttribute(XMLex, FieldNode, "Name", AreaFN.Name)
                CreateAttribute(XMLex, FieldNode, "FName", AreaFN.FriendlyName)
                CreateAttribute(XMLex, FieldNode, "Type", AreaFN.Type.ToString)
                CreateAttribute(XMLex, FieldNode, "ValueType", AreaFN.ValueType)
                CreateAttribute(XMLex, FieldNode, "Format", AreaFN.Format)
                FieldNode.InnerText = AreaFN.Code
                AreaNode.AppendChild(FieldNode)
            Next
            'Area Fields, Functions, Query ...
            For Each Item In Area.Items
                Dim ItemNode As XmlNode = XMLex.CreateNode(XmlNodeType.Element, "Item", "")
                CreateAttribute(XMLex, ItemNode, "Name", Item.Name)
                CreateAttribute(XMLex, ItemNode, "ID", Item.ID)
                CreateAttribute(XMLex, ItemNode, "Type", Item.Type.ToString)
                CreateAttribute(XMLex, ItemNode, "X", Item.X)
                CreateAttribute(XMLex, ItemNode, "Y", Item.Y)
                CreateAttribute(XMLex, ItemNode, "Width", Item.Width)
                CreateAttribute(XMLex, ItemNode, "Height", Item.Height)
                CreateAttribute(XMLex, ItemNode, "HPosition", Item.HorizontalPosition.ToString)
                CreateAttribute(XMLex, ItemNode, "VPosition", Item.VerticalPosition.ToString)
                CreateAttribute(XMLex, ItemNode, "HParrent", Item.HorizontalPositionParrent)
                CreateAttribute(XMLex, ItemNode, "VParrent", Item.VerticalPositionParrent)
                CreateAttribute(XMLex, ItemNode, "Visibility", Item.Visibility)
                CreateAttribute(XMLex, ItemNode, "VisibilityParrent", Item.VisibilityParrent)
                Select Case Item.Type
                    Case ItemType.Line
                        Dim cItem As MyLineItem = CType(Item, MyLineItem)
                        CreateAttribute(XMLex, ItemNode, "X2", cItem.X2)
                        CreateAttribute(XMLex, ItemNode, "Y2", cItem.Y2)
                        CreateAttribute(XMLex, ItemNode, "LineWidth", cItem.LineWidth)
                        CreateAttribute(XMLex, ItemNode, "LineColor", cItem.LineColor.ToArgb)
                    Case ItemType.Rectangle
                        Dim cItem As MyRectangleItem = CType(Item, MyRectangleItem)
                        CreateAttribute(XMLex, ItemNode, "BackColor", cItem.BackColor.ToArgb)
                        CreateAttribute(XMLex, ItemNode, "LineColor", cItem.LineColor.ToArgb)
                        CreateAttribute(XMLex, ItemNode, "LineWidth", cItem.LineWidth)
                        CreateAttribute(XMLex, ItemNode, "LineStyle", cItem.LineStyle.ToString)
                    Case ItemType.Elypse
                        Dim cItem As MyElypseItem = CType(Item, MyElypseItem)
                        CreateAttribute(XMLex, ItemNode, "FillColor", cItem.FillColor.ToArgb)
                        CreateAttribute(XMLex, ItemNode, "BackColor", cItem.BackColor.ToArgb)
                        CreateAttribute(XMLex, ItemNode, "LineColor", cItem.LineColor.ToArgb)
                        CreateAttribute(XMLex, ItemNode, "LineWidth", cItem.LineWidth)
                        CreateAttribute(XMLex, ItemNode, "LineStyle", cItem.LineStyle.ToString)
                    Case ItemType.Text
                        Dim cItem As MyTextItem = CType(Item, MyTextItem)
                        CreateAttribute(XMLex, ItemNode, "TextFont", cItem.TextFont.ToString)
                        CreateAttribute(XMLex, ItemNode, "TextColor", cItem.TextColor.ToArgb)
                        CreateAttribute(XMLex, ItemNode, "BackColor", cItem.BackColor.ToArgb)
                        CreateAttribute(XMLex, ItemNode, "WordWrap", cItem.WordWrap)
                        CreateAttribute(XMLex, ItemNode, "Border", cItem.Border.GetString)
                        CreateAttribute(XMLex, ItemNode, "VAlignment", cItem.VerticalAlignment.ToString)
                        CreateAttribute(XMLex, ItemNode, "HAlignment", cItem.HorizontalAlignment.ToString)
                        CreateAttribute(XMLex, ItemNode, "Rotation", cItem.Rotation)
                        ItemNode.InnerText = cItem.Text
                    Case ItemType.Picture
                        Dim cItem As MyPictureItem = CType(Item, MyPictureItem)
                        CreateAttribute(XMLex, ItemNode, "Scale", cItem.Scale)
                        CreateAttribute(XMLex, ItemNode, "BackColor", cItem.BackColor.ToArgb)
                        CreateAttribute(XMLex, ItemNode, "Border", cItem.Border.GetString)
                        ItemNode.InnerText = ImageToBase64(cItem.Image, cItem.Image.RawFormat)
                    Case ItemType.Data

                    Case ItemType.Barcode

                End Select
                AreaNode.AppendChild(ItemNode)
            Next
            MainNode.AppendChild(AreaNode)
        Next
        XMLex.AppendChild(MainNode)
        Return XMLex
    End Function
    Public Function Parse(XML As XmlDocument) As String
        Dim ErrorList As String = String.Empty
        If Not IsNothing(XML) Then
            Dim MainNode As XmlNode = XML.GetElementsByTagName("SPDLibDocument")(0)
            Dim xAreas As XmlNodeList = MainNode.ChildNodes
            iDocumentName = GetAttributeValue(MainNode, "Name")
            iPageWidth = CInt(GetAttributeValue(MainNode, "Width"))
            iPageHeight = CInt(GetAttributeValue(MainNode, "Height"))
            Select Case GetAttributeValue(MainNode, "Orientation")
                Case "Portrait"
                    iPageOrientation = DocumentPageOrientation.Portrait
                Case "Landscape"
                    iPageOrientation = DocumentPageOrientation.Landscape
            End Select
            Select Case GetAttributeValue(MainNode, "Type")
                Case "Page"
                    iDocumentType = DocumentType.Page
                Case "MultiLabel"
                    iDocumentType = DocumentType.MultiLabel
            End Select
            Dim M() As String = GetAttributeValue(MainNode, "Margins").Split(",")
            iMargins.Left = CInt(M(0))
            iMargins.Right = CInt(M(1))
            iMargins.Top = CInt(M(2))
            iMargins.Bottom = CInt(M(3))
            For Each xArea As XmlNode In xAreas
                Dim Area As New MyDocumentArea(GetAttributeValue(xArea, "ID"),
                                               GetAttributeValue(xArea, "Name"),
                                               GetAttributeValue(xArea, "Width"),
                                               GetAttributeValue(xArea, "Height"),
                                               CBool(GetAttributeValue(xArea, "DynamicH")),
                                               cAreaType(GetAttributeValue(xArea, "Type")))
                Area.SetDatasourceType = cDataSource(GetAttributeValue(xArea, "DataSource"))
                'Area Fields, Functions, Query ...
                For Each xItem As XmlNode In xArea.ChildNodes
                    Select Case xItem.Name
                        Case "Field"

                        Case "Function"

                        Case "Item"
                            Dim Item As MyItem = Nothing
                            Select Case GetAttributeValue(xItem, "Type")
                                Case "Line"
                                    Item = New MyLineItem(GetAttributeValue(xItem, "ID"),
                                                               GetAttributeValue(xItem, "Name"),
                                                               0,
                                                               0,
                                                               GetAttributeValue(xItem, "X2"),
                                                               GetAttributeValue(xItem, "Y2"),
                                                               GetAttributeValue(xItem, "LineWidth"),
                                                               Color.FromArgb(GetAttributeValue(xItem, "LineColor")))
                                Case "Rectangle"
                                    Item = New MyRectangleItem(GetAttributeValue(xItem, "ID"),
                                                               GetAttributeValue(xItem, "Name"),
                                                               Color.FromArgb(GetAttributeValue(xItem, "BackColor")),
                                                               Color.FromArgb(GetAttributeValue(xItem, "LineColor")),
                                                               GetAttributeValue(xItem, "LineWidth"),
                                                               cLineStyle(GetAttributeValue(xItem, "LineStyle")))
                                Case "Elypse"
                                    Item = New MyElypseItem(GetAttributeValue(xItem, "ID"),
                                                            GetAttributeValue(xItem, "Name"),
                                                            Color.FromArgb(GetAttributeValue(xItem, "FillColor")),
                                                            Color.FromArgb(GetAttributeValue(xItem, "BackColor")),
                                                            Color.FromArgb(GetAttributeValue(xItem, "LineColor")),
                                                            GetAttributeValue(xItem, "LineWidth"),
                                                            cLineStyle(GetAttributeValue(xItem, "LineStyle")))
                                Case "Text"
                                    Item = New MyTextItem(GetAttributeValue(xItem, "ID"),
                                                          GetAttributeValue(xItem, "Name"),
                                                          GetFontByString(GetAttributeValue(xItem, "TextFont")),
                                                          Color.FromArgb(GetAttributeValue(xItem, "TextColor")),
                                                          Color.FromArgb(GetAttributeValue(xItem, "BackColor")),
                                                          CBool(GetAttributeValue(xItem, "WordWrap")),
                                                          MyItemBorderStyle.FromString(GetAttributeValue(xItem, "Border")),
                                                          cVAlignment(GetAttributeValue(xItem, "VAlignment")),
                                                          cHAlignment(GetAttributeValue(xItem, "VAlignment")),
                                                          GetAttributeValue(xItem, "Rotation"),
                                                          xItem.InnerText)
                                Case "Picture"
                                    Item = New MyPictureItem(GetAttributeValue(xItem, "ID"),
                                                             GetAttributeValue(xItem, "Name"),
                                                             CBool(GetAttributeValue(xItem, "Scale")),
                                                             MyItemBorderStyle.FromString(GetAttributeValue(xItem, "Border")),
                                                             Color.FromArgb(GetAttributeValue(xItem, "BackColor")),
                                                             Base64ToImage(xItem.InnerText))
                            End Select
                            If Not IsNothing(Item) Then
                                Item.X = GetAttributeValue(xItem, "X")
                                Item.Y = GetAttributeValue(xItem, "Y")
                                Item.Width = GetAttributeValue(xItem, "Width")
                                Item.Height = GetAttributeValue(xItem, "Height")
                                Item.HorizontalPosition = cItemPosition(GetAttributeValue(xItem, "HPosition"))
                                Item.VerticalPosition = cItemPosition(GetAttributeValue(xItem, "VPosition"))
                                Item.HorizontalPositionParrent = GetAttributeValue(xItem, "HParrent")
                                Item.VerticalPositionParrent = GetAttributeValue(xItem, "VParrent")
                                Item.Visibility = cItemVisibility(GetAttributeValue(xItem, "Visibility"))
                                Item.VisibilityParrent = GetAttributeValue(xItem, "VisibilityParrent")
                                Area.Items.Add(Item)
                            End If
                    End Select
                Next
                DocumentAreas.Add(Area)
            Next
        End If
        Return ErrorList
    End Function


    Private Sub CreateAttribute(Document As XmlDocument, Node As XmlNode, AttributeName As String, AttributeValue As String)
        Dim attr As XmlAttribute = Document.CreateAttribute(AttributeName)
        attr.Value = AttributeValue
        Node.Attributes.Append(attr)
    End Sub
    Private Function GetAttributeValue(Node As XmlNode, Attribute As String) As String
        Return Node.Attributes.GetNamedItem(Attribute).Value
    End Function
#End Region
#Region "IDisposable Support"
    Private disposedValue As Boolean
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                For Each Area In iDocumentAreas
                    Area.Dispose()
                Next
                iDocumentAreas.Clear()
                iDocumentAreas = Nothing
                iPageWidth = Nothing
                iPageHeight = Nothing
                iMargins = Nothing
                iPageOrientation = Nothing
                iDocumentType = Nothing
                iStaticFields.Clear()
                iStaticFields = Nothing
                curSite = Nothing
            End If
        End If
        disposedValue = True
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
    End Sub
#End Region

End Class
