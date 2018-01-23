Imports System.Drawing.Printing

Public Class MyPrintDialog
    Event PrintClicked()
    Event PrinterSetupClicked()

    Public Property PrintDocument As PrintDocument
        Get
            Return PreviewControl.Document
        End Get
        Set(value As PrintDocument)
            PreviewControl.Document = value
        End Set
    End Property
    Public Property ZoomLevel As Double
        Get
            Return PreviewControl.Zoom
        End Get
        Set(value As Double)
            PreviewControl.Zoom = value
        End Set
    End Property
    Public Property TotalPages As Integer
        Get
            Return PreviewControl.Rows
        End Get
        Set(value As Integer)
            PreviewControl.Rows = value
        End Set
    End Property
    Sub New()
        InitializeComponent()
        Zoom_CMB.Text = "75"
        PreviewControl.Zoom = 0.75
    End Sub

    Private Sub Print_BTN_Click(sender As Object, e As EventArgs) Handles Print_BTN.Click
        RaiseEvent PrintClicked()
        PrintDocument.Print()
        Hide()
    End Sub

    Private Sub PrinterSetup_BTN_Click(sender As Object, e As EventArgs) Handles PrinterSetup_BTN.Click
        RaiseEvent PrinterSetupClicked()

    End Sub

    Private Sub Zoom_CMB_TextUpdate(sender As Object, e As EventArgs) Handles Zoom_CMB.SelectedIndexChanged
        ZoomLevel = CInt(Zoom_CMB.Text) / 100
        'MsgBox(ZoomLevel.ToString)
        'PrintDocument.Print()
    End Sub
End Class