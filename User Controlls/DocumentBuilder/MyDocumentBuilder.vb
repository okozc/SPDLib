Public Class MyDocumentBuilder

    Private Class ATList
        Public Property AreaName As String
        Public Property AreaTable As String
        Public Sub New()
            AreaName = String.Empty
            AreaTable = String.Empty
        End Sub
        Sub New(Name As String, Table As String)
            AreaName = Name
            AreaTable = Table
        End Sub
    End Class

#Region "Unmanaged"
    Private iDocument As MyDocument
#End Region
#Region "Managed"
    Private iAreaSelector As AreaSelector
    Private iDocWidth As Integer
    Private iDocHeight As Integer
    Private iDocOrientation As DocumentPageOrientation
    Private iDocType As DocumentType
    Private iDataTables As List(Of DataTable)
    Private iAreaTableList As List(Of ATList)
    Private lowIndex As Integer
    Private hiIndex As Integer
#End Region

    Public ReadOnly Property CreatedDocument As MyDocument
        Get
            Return iDocument
        End Get
    End Property

    Sub New()
        InitializeComponent()
        iDocument = Nothing
        iAreaSelector = New AreaSelector(Me)
        DocType_CMB.SelectedIndex = 0
        DocName_TXT.Text = "New Document"
        Orientation_P_RAD.Checked = True
        DocWidth_NUM.Value = 794
        DocHeight_NUM.Value = 1123
        AreaWidth_NUM.Value = 0
        AreaHeight_NUM.Value = 0
        AreaWidth_mm_LBL.Text = "0 mm"
        AreaHeight_mm_LBL.Text = "0 mm"
        Fields_N_RAD.Checked = True
        iDataTables = New List(Of DataTable)
        iAreaTableList = New List(Of ATList)
        lowIndex = 0
        hiIndex = 0
        ClearTables()

        Dim T1 As New DataTable("Polozky")
        T1.Columns.AddRange({New DataColumn("Pozícia"), New DataColumn("Artikel"), New DataColumn("Názov"), New DataColumn("Cena"), New DataColumn("Množstvo")})
        Dim T2 As New DataTable("PolozkySumár")
        T2.Columns.AddRange({New DataColumn("CenaCelkom"), New DataColumn("ZákladDane")})
        AddTable(T1)
        AddTable(T2)
    End Sub

    Public Sub AddTable(Table As DataTable)
        iDataTables.Add(Table)
        Dim TLV As New ListViewItem(Table.TableName)
        TLV.SubItems.Add(Table.Columns.Count)
        DataTables_LVW.Items.Add(TLV)
        Fields_D_RAD.Enabled = True
    End Sub
    Public Sub ClearTables()
        iDataTables.Clear()
        Fields_D_RAD.Enabled = False
    End Sub

    Private Sub SelectTable(TableName As String)
        If TableName = "None" Or TableName = String.Empty Then
            Fields_N_RAD.Checked = True
            DataTables_LVW.SelectedItems.Clear()
        ElseIf Fields_D_RAD.Enabled Then
            Fields_D_RAD.Checked = True
            For Each LVI As ListViewItem In DataTables_LVW.Items
                If TableName = LVI.Text Then LVI.Selected = True
            Next
        End If
    End Sub
    Private Sub SortAreaList()
        Dim item As ListViewItem = Nothing
        lowIndex = 0
        hiIndex = 0
        For i = 0 To AreaList.Items.Count - 1
            If AreaList.Items(i).Text = "Header1stPage" Then
                item = AreaList.Items(i)
                AreaList.Items.RemoveAt(i)
                AreaList.Items.Insert(0, item)
                lowIndex = 1
            End If
            If AreaList.Items(i).Text = "HeaderAllPages" Then
                item = AreaList.Items(i)
                AreaList.Items.RemoveAt(i)
                AreaList.Items.Insert(lowIndex, item)
                lowIndex = 2
            End If
            If AreaList.Items(i).Text = "Body" Then
                hiIndex = i
            End If
            If AreaList.Items(i).Text = "Footer1stPage" Then
                item = AreaList.Items(i)
                AreaList.Items.RemoveAt(i)
                AreaList.Items.Add(item)
            End If
            If AreaList.Items(i).Text = "FooterAllPages" Then
                item = AreaList.Items(i)
                AreaList.Items.RemoveAt(i)
                AreaList.Items.Add(item)
            End If
            If AreaList.Items(i).Text = "PageBackground" Then
                item = AreaList.Items(i)
                AreaList.Items.RemoveAt(i)
                AreaList.Items.Add(item)
            End If
        Next

    End Sub
    Private Function GetAreaListItem(Index As Integer) As ListViewItem
        Return AreaList.Items(Index)
    End Function
    Private Function GetATListByName(Name As String) As ATList
        For Each At As ATList In iAreaTableList
            If At.AreaName = Name Then Return At
        Next
        Return Nothing
    End Function

    Private Sub Create_BTN_Click(sender As Object, e As EventArgs) Handles Create_BTN.Click
        DialogResult = DialogResult.OK
        iDocument = New MyDocument()
        With iDocument
            .DocumentType = iDocType
            .Name = DocName_TXT.Text
            .PageWidth = iDocWidth
            .PageHeight = iDocHeight
            .PageOrientation = iDocOrientation
            For Each Area As ListViewItem In AreaList.Items
                Dim NewArea As New MyDocumentArea
                With NewArea
                    .Name = Area.SubItems(1).Text
                    .SetType = cAreaType(Area.Text)
                    .Width = Area.SubItems(2).Text
                    .Height = Area.SubItems(3).Text
                    .DynamicHeight = False
                    Dim AT As ATList = GetATListByName(Area.SubItems(1).Text)
                    Select Case AT.AreaTable
                        Case "None"
                            .SetDatasourceType = MyDocumentArea.MyDataSourceType.None
                        Case Else
                            .SetDatasourceType = MyDocumentArea.MyDataSourceType.DataTable
                            For Each DT As DataTable In iDataTables
                                If DT.TableName = AT.AreaTable Then
                                    For Each TC As DataColumn In DT.Columns
                                        .Fields.Add(New MyDataField(TC.ColumnName, "") With {.ValueType = MyField.FieldValueType.Text})
                                    Next
                                End If
                            Next
                    End Select
                End With
                .AddArea(NewArea)
            Next
        End With
        Hide()
    End Sub
    Private Sub Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Cancel_BTN.Click
        DialogResult = DialogResult.Cancel
        Hide()
    End Sub
    Private Sub AddArea_BTN_Click(sender As Object, e As EventArgs) Handles AddArea_BTN.Click
        iAreaSelector.Clear()
        Select Case iDocType
            Case DocumentType.MultiLabel
                If AreaList.Items.Count > 0 Then
                    MsgBox("Document of Type 'Label' can contain only one Area.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFO")
                    Exit Sub
                Else
                    iAreaSelector.Add("MultiLabelBody")
                    If iAreaSelector.ShowDialog = DialogResult.OK Then
                        iAreaTableList.Add(New ATList(iAreaSelector.SelectedName, "None"))
                        DocType_CMB.Enabled = False
                        Dim ALI As New ListViewItem(iAreaSelector.SelectedType.ToString)
                        ALI.SubItems.Add(iAreaSelector.SelectedName)
                        ALI.SubItems.Add(0)
                        ALI.SubItems.Add(0)
                        AreaList.Items.Add(ALI).Selected = True
                    End If
                End If
            Case DocumentType.Page
                Dim AA() As String = {"Header1stPage", "HeaderAllPages", "Footer1stPage", "FooterAllPages", "PageBackground"}
                For Each AvArea As String In AA
                    Dim Found As Boolean = False
                    For Each Area As ListViewItem In AreaList.Items
                        If AvArea = Area.Text Then Found = True
                    Next
                    If Not Found Then
                        iAreaSelector.Add(AvArea)
                    End If
                Next
                iAreaSelector.Add("Body")
                For Each Area As ListViewItem In AreaList.Items
                    iAreaSelector.UsedNames.Add(Area.SubItems(1).Text)
                Next
                If iAreaSelector.ShowDialog = DialogResult.OK Then
                    iAreaTableList.Add(New ATList(iAreaSelector.SelectedName, "None"))
                    DocType_CMB.Enabled = False
                    Dim ALI As New ListViewItem(iAreaSelector.SelectedType.ToString)
                    ALI.SubItems.Add(iAreaSelector.SelectedName)
                    ALI.SubItems.Add(0)
                    ALI.SubItems.Add(0)
                    AreaList.Items.Add(ALI).Selected = True
                    SortAreaList()
                End If
        End Select
    End Sub
    Private Sub RemoveArea_BTN_Click(sender As Object, e As EventArgs) Handles RemoveArea_BTN.Click
        If AreaList.SelectedItems.Count > 0 Then
            Dim AT As ATList = GetATListByName(AreaList.SelectedItems(0).SubItems(1).Text)
            iAreaTableList.Remove(AT)
            AT = Nothing
            AreaList.Items.Remove(AreaList.SelectedItems(0))
            If AreaList.Items.Count = 0 Then DocType_CMB.Enabled = True
        End If
    End Sub
    Private Sub EditArea_BTN_Click(sender As Object, e As EventArgs) Handles EditArea_BTN.Click
        If AreaList.SelectedItems.Count > 0 Then
            iAreaSelector.Clear()
            For Each Area As ListViewItem In AreaList.Items
                If Not Area.Selected Then
                    iAreaSelector.UsedNames.Add(Area.SubItems(1).Text)
                Else
                    iAreaSelector.Add(Area.Text)
                End If
            Next
            Dim AName As String = AreaList.SelectedItems(0).SubItems(1).Text
            If iAreaSelector.ShowDialog(AName) = DialogResult.OK Then
                AreaList.SelectedItems(0).SubItems(1).Text = iAreaSelector.SelectedName
                GetATListByName(AName).AreaName = iAreaSelector.SelectedName
            End If
        End If
    End Sub
    Private Sub MoveAreaUp_BTN_Click(sender As Object, e As EventArgs) Handles MoveAreaUp_BTN.Click
        If AreaList.SelectedItems.Count > 0 Then
            Dim item As ListViewItem = Nothing
            For i = 0 To AreaList.Items.Count - 1
                item = AreaList.Items(i)
                If item.Selected And item.Text = "Body" And i > lowIndex Then
                    AreaList.Items.RemoveAt(i)
                    AreaList.Items.Insert(i - 1, item)
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Sub MoveAreaDown_BTN_Click(sender As Object, e As EventArgs) Handles MoveAreaDown_BTN.Click
        If AreaList.SelectedItems.Count > 0 Then
            Dim item As ListViewItem = Nothing
            For i = 0 To AreaList.Items.Count - 1
                item = AreaList.Items(i)
                If item.Selected And item.Text = "Body" And i <= hiIndex Then
                    AreaList.Items.RemoveAt(i)
                    AreaList.Items.Insert(i + 1, item)
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Sub DocWidth_NUM_ValueChanged(sender As Object, e As EventArgs) Handles DocWidth_NUM.ValueChanged
        DocWidth_mm_LBL.Text = CInt(pTOmm(DocWidth_NUM.Value)) & " mm"
        Select Case iDocOrientation
            Case DocumentPageOrientation.Portrait
                iDocWidth = DocWidth_NUM.Value
            Case DocumentPageOrientation.Landscape
                iDocHeight = DocWidth_NUM.Value
        End Select
    End Sub
    Private Sub DocHeight_NUM_ValueChanged(sender As Object, e As EventArgs) Handles DocHeight_NUM.ValueChanged
        DocHeight_mm_LBL.Text = CInt(pTOmm(DocHeight_NUM.Value)) & " mm"
        Select Case iDocOrientation
            Case DocumentPageOrientation.Portrait
                iDocHeight = DocHeight_NUM.Value
            Case DocumentPageOrientation.Landscape
                iDocWidth = DocHeight_NUM.Value
        End Select
    End Sub
    Private Sub OrientationChanged(sender As Object, e As EventArgs) Handles Orientation_L_RAD.CheckedChanged, Orientation_P_RAD.CheckedChanged
        If Orientation_P_RAD.Checked Then iDocOrientation = DocumentPageOrientation.Portrait
        If Orientation_L_RAD.Checked Then iDocOrientation = DocumentPageOrientation.Landscape
        Select Case iDocOrientation
            Case DocumentPageOrientation.Portrait
                DocWidth_NUM.Value = iDocWidth
                DocHeight_NUM.Value = iDocHeight
            Case DocumentPageOrientation.Landscape
                DocWidth_NUM.Value = iDocHeight
                DocHeight_NUM.Value = iDocWidth
        End Select
    End Sub
    Private Sub DocType_CMB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DocType_CMB.SelectedIndexChanged
        Select Case DocType_CMB.SelectedItem.ToString
            Case "Page"
                iDocType = DocumentType.Page
                AreaWidth_NUM.Value = 0
                AreaWidth_NUM.Enabled = False
            Case "Label"
                iDocType = DocumentType.MultiLabel
                AreaWidth_NUM.Enabled = True
        End Select
    End Sub
    Private Sub AreaWidth_NUM_ValueChanged(sender As Object, e As EventArgs) Handles AreaWidth_NUM.ValueChanged
        AreaWidth_mm_LBL.Text = CInt(pTOmm(AreaWidth_NUM.Value)) & " mm"
    End Sub
    Private Sub AreaHeight_NUM_ValueChanged(sender As Object, e As EventArgs) Handles AreaHeight_NUM.ValueChanged
        AreaHeight_mm_LBL.Text = CInt(pTOmm(AreaHeight_NUM.Value)) & " mm"
    End Sub
    Private Sub DataSourceChanged(sender As Object, e As EventArgs) Handles Fields_N_RAD.CheckedChanged, Fields_D_RAD.CheckedChanged
        If Fields_N_RAD.Checked = True Then
            DataTables_LVW.Enabled = False
        Else
            DataTables_LVW.Enabled = True
        End If
    End Sub
    Private Sub AreaList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AreaList.SelectedIndexChanged
        If AreaList.SelectedItems.Count = 0 Then
            AreaGroup.Enabled = False
            AreaGroup.Visible = False
        Else
            Dim AT As ATList = GetATListByName(AreaList.SelectedItems(0).SubItems(1).Text)
            SelectTable(AT.AreaTable)
            AreaWidth_NUM.Value = AreaList.SelectedItems(0).SubItems(2).Text
            AreaHeight_NUM.Value = AreaList.SelectedItems(0).SubItems(3).Text
            AreaGroup.Enabled = True
            AreaGroup.Visible = True
        End If
    End Sub
    Private Sub Set_BTN_Click(sender As Object, e As EventArgs) Handles Set_BTN.Click
        If AreaList.SelectedItems.Count > 0 Then
            AreaList.SelectedItems(0).SubItems(2).Text = AreaWidth_NUM.Value
            AreaList.SelectedItems(0).SubItems(3).Text = AreaHeight_NUM.Value
        End If
    End Sub
    Private Sub SetTable_BTN_Click(sender As Object, e As EventArgs) Handles SetTable_BTN.Click
        If AreaList.SelectedItems.Count > 0 Then
            Dim AT As ATList = GetATListByName(AreaList.SelectedItems(0).SubItems(1).Text)
            If Fields_N_RAD.Checked Then
                AT.AreaTable = "None"
            End If
            If Fields_D_RAD.Checked And DataTables_LVW.SelectedItems.Count > 0 Then
                AT.AreaTable = DataTables_LVW.SelectedItems(0).Text
            End If
        End If
    End Sub

    Private Sub iDispose() Handles Me.Disposed
        iDocument = Nothing
        iAreaSelector.Dispose()
        iDataTables.Clear()
        iDataTables = Nothing
        iAreaTableList.Clear()
        iAreaTableList = Nothing
        lowIndex = Nothing
        hiIndex = Nothing
    End Sub
End Class