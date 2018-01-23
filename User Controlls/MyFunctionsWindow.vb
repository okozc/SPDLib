Public Class MyFunctionsWindow

#Region "Unmanaged"
    Private iSelectedArea As MyDocumentArea
#End Region

    Public Property SelectedArea As MyDocumentArea
        Get
            Return iSelectedArea
        End Get
        Set(value As MyDocumentArea)
            iSelectedArea = value
            If IsNothing(iSelectedArea) Then
                Text = "Functions"
            Else
                Text = "Functions (" & iSelectedArea.ID & ")(" & iSelectedArea.Name & ")"
            End If
        End Set
    End Property


    Sub New()
        InitializeComponent()
    End Sub

    Private Sub Hide_BTN_Click(sender As Object, e As EventArgs) Handles Hide_BTN.Click
        Hide()
    End Sub

    Private Sub Plus_BTN_Click(sender As Object, e As EventArgs) Handles Plus_BTN.Click

    End Sub

    Private Sub Minus_BTN_Click(sender As Object, e As EventArgs) Handles Minus_BTN.Click

    End Sub

    Private Sub Edit_BTN_Click(sender As Object, e As EventArgs) Handles Edit_BTN.Click

    End Sub
End Class