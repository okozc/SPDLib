Public Class MyPropertiesWindow

    Public Event ValueChanged()

    Public Property SelectObjects As Object()
        Get
            Return ObjectPropertyGrid.SelectedObjects
        End Get
        Set(value As Object())
            ObjectPropertyGrid.SelectedObjects = value
        End Set
    End Property
    Public Property SelectObject As Object
        Get
            Return ObjectPropertyGrid.SelectedObject
        End Get
        Set(value As Object)
            ObjectPropertyGrid.SelectedObject = value
        End Set
    End Property
    Sub New()
        InitializeComponent()

    End Sub

    Private Sub ObjectPropertyGrid_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles ObjectPropertyGrid.PropertyValueChanged
        RaiseEvent ValueChanged()
    End Sub

    Private Sub Hide_BTN_Click(sender As Object, e As EventArgs) Handles Hide_BTN.Click
        Hide()
    End Sub
End Class