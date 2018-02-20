Public Class AreaSelector

    Private iParrent As Form
    Private iToolTip As ToolTip
    Private iUsedNames As List(Of String)

    Protected Friend ReadOnly Property SelectedType As DocumentAreaType
        Get
            Return cAreaType(AreaList.SelectedItem.ToString)
        End Get
    End Property
    Protected Friend ReadOnly Property SelectedName As String
        Get
            Return AreaNameTXT.Text
        End Get
    End Property
    Protected Friend ReadOnly Property UsedNames As List(Of String)
        Get
            Return iUsedNames
        End Get
    End Property
    Protected Friend Sub New(ParrentForm As Form)
        InitializeComponent()
        iParrent = ParrentForm
        iToolTip = New ToolTip
        iUsedNames = New List(Of String)
    End Sub

    Protected Friend Overloads Function ShowDialog(Optional AreaName As String = "") As DialogResult
        AreaNameTXT.Text = AreaName
        Return MyBase.ShowDialog
    End Function

    Protected Friend Sub Add(ItemName As String)
        AreaList.Items.Add(ItemName)
        If AreaList.Items.Count > 0 Then
            AreaList.SelectedIndex = 0
            OK_BTN.Enabled = True
        End If
    End Sub
    Protected Friend Sub Clear()
        AreaList.Items.Clear()
        iUsedNames.Clear()
        AreaNameTXT.Text = ""
        OK_BTN.Enabled = False
    End Sub
    Private Sub OK_BTN_Click(sender As Object, e As EventArgs) Handles OK_BTN.Click
        If Len(AreaNameTXT.Text) = 0 Then
            AreaNameTXT.BackColor = Color.LightCoral
            iToolTip.Hide(AreaNameTXT)
            iToolTip.SetToolTip(AreaNameTXT, "Please enter Area Name")
            iToolTip.IsBalloon = True
            iToolTip.Show("Please enter Area Name", AreaNameTXT, 4000)
            Exit Sub
        End If
        If iUsedNames.Contains(AreaNameTXT.Text) Then
            AreaNameTXT.BackColor = Color.LightCoral
            iToolTip.Hide(AreaNameTXT)
            iToolTip.SetToolTip(AreaNameTXT, "Area Name must be unique")
            iToolTip.IsBalloon = True
            iToolTip.Show("Area Name must be unique", AreaNameTXT, 4000)
            Exit Sub
        Else
            DialogResult = DialogResult.OK
            Hide()
        End If
    End Sub
    Private Sub Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Cancel_BTN.Click
        DialogResult = DialogResult.Cancel
        Hide()
    End Sub
    Private Sub AreaSelector_Enter(sender As Object, e As EventArgs) Handles Me.Activated
        Location = New Point(iParrent.Location.X + 21, iParrent.Location.Y + 69)
        AreaNameTXT.Focus()
    End Sub
    Private Sub AreaNameTXT_TextChanged(sender As Object, e As EventArgs) Handles AreaNameTXT.TextChanged
        AreaNameTXT.BackColor = SystemColors.Window
    End Sub
    Private Sub iDispose() Handles Me.Disposed
        Clear()
        iParrent = Nothing
        iToolTip.Dispose()
        iToolTip = Nothing
        iUsedNames = Nothing
    End Sub


End Class