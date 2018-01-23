Public Class AboutBox
    Sub New()
        InitializeComponent()
    End Sub

    Private Sub OK_BTN_Click(sender As Object, e As EventArgs) Handles OK_BTN.Click
        Hide()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("mailto:roman.ocenas@gmail.com")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("https://www.codeproject.com/Members/Patrik-Svensson")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("https://paypal.me/RomanOcenas")
    End Sub
End Class