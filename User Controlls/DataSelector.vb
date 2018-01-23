Public Class DataSelector


    Public ReadOnly Property Items As ListView.ListViewItemCollection
        Get
            Return FieldsList.Items
        End Get
    End Property

    Public ReadOnly Property SelectedField As String
        Get
            If FieldsList.SelectedItems.Count > 0 Then
                Return FieldsList.SelectedItems(0).SubItems(1).Text
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public ReadOnly Property SelectedFieldType As Integer
        Get
            If FieldsList.SelectedItems.Count > 0 Then
                Return FieldsList.SelectedItems(0).ImageIndex
            Else
                Return Nothing
            End If
        End Get
    End Property
    Sub New()
        InitializeComponent()
        FieldsList.Items.Clear()
    End Sub

    Private Sub OK_BTN_Click(sender As Object, e As EventArgs) Handles OK_BTN.Click
        DialogResult = DialogResult.OK
        Hide()
    End Sub
    Private Sub Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Cancel_BTN.Click
        DialogResult = DialogResult.Cancel
        Hide()
    End Sub

    Private Sub FieldsList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FieldsList.SelectedIndexChanged
        If FieldsList.SelectedItems.Count = 1 Then
            OK_BTN.Enabled = True
        Else
            OK_BTN.Enabled = False
        End If
    End Sub

    Public Sub Clear()
        FieldsList.Items.Clear()
    End Sub
    Public Sub AddItem(ImgIndex As Integer, Name As String, FriendlyName As String)
        Dim lv As New ListViewItem("")
        lv.SubItems.Add(Name)
        lv.SubItems.Add(FriendlyName)
        lv.ImageIndex = ImgIndex
        Select Case ImgIndex
            Case 0
                lv.ToolTipText = "Static"
            Case 1
                lv.ToolTipText = "Field"
            Case 2
                lv.ToolTipText = "Function"
        End Select
        FieldsList.Items.Add(lv)
    End Sub
End Class