Imports System.IO

Public Module SharedFunctions
    Private Const mmpp As Double = 0.264583333

    Private Structure IconInfo
        Public fIcon As Boolean
        Public xHotspot As Integer
        Public yHotspot As Integer
        Public hbmMask As IntPtr
        Public hbmColor As IntPtr
    End Structure
    Private Declare Function GetIconInfo Lib "user32.dll" (hIcon As IntPtr, ByRef pIconInfo As IconInfo) As Boolean
    Private Declare Function CreateIconIndirect Lib "user32.dll" (ByRef icon As IconInfo) As IntPtr
    Public Function CreateCursorNoResize(bmp As Bitmap, xHotSpot As Integer, yHotSpot As Integer) As Cursor
        Dim ptr As IntPtr = bmp.GetHicon
        Dim tmp As IconInfo = New IconInfo()
        GetIconInfo(ptr, tmp)
        tmp.xHotspot = xHotSpot
        tmp.yHotspot = yHotSpot
        tmp.fIcon = False
        ptr = CreateIconIndirect(tmp)
        Return New Cursor(ptr)
    End Function

    Public Function ImageToBase64(ByVal Img As Image, Format As Imaging.ImageFormat) As String
        Using ms As MemoryStream = New MemoryStream
            Img.Save(ms, Format)
            Dim ImgBytes() As Byte = ms.ToArray
            Dim base64String As String = Convert.ToBase64String(ImgBytes)
            Return base64String
        End Using
    End Function
    Public Function Base64ToImage(ByVal base64String As String) As Image
        Dim ImgBytes() As Byte = Convert.FromBase64String(base64String)
        Dim ms As New MemoryStream(ImgBytes, 0, ImgBytes.Length)
        ms.Write(ImgBytes, 0, ImgBytes.Length)
        Dim Img As Image = Image.FromStream(ms, True)
        Return Img
    End Function

    Public Function GetFontByString(ByVal sFont As String) As Font
        sFont = sFont.Substring(1, sFont.Length - 2)
        sFont = Replace(sFont, "Font:", vbNullString)
        Dim sElement() As String = Split(sFont, ",")
        Dim sSingle() As String
        Dim sValue As String
        Dim FontName As String = "Arial"
        Dim FontSize As Single = 10
        Dim FontStyle As FontStyle = Drawing.FontStyle.Regular
        Dim FontUnit As GraphicsUnit = GraphicsUnit.Point
        Dim gdiCharSet As Byte
        Dim gdiVerticalFont As Boolean

        For Each sValue In sElement
            sValue = Trim(sValue)
            sSingle = Split(sValue, "=")
            If sSingle.GetUpperBound(0) > 0 Then
                If sSingle(0) = "Name" Then
                    FontName = sSingle(1)
                ElseIf sSingle(0) = "Size" Then
                    FontSize = CSng(sSingle(1))
                ElseIf sSingle(0) = "Units" Then
                    FontUnit = CInt(sSingle(1))
                ElseIf sSingle(0) = "GdiCharSet" Then
                    gdiCharSet = CByte(sSingle(1))
                ElseIf sSingle(0) = "GdiVerticalFont" Then
                    gdiVerticalFont = CBool(sSingle(1))
                End If
            End If
        Next
        Return New Font(FontName, FontSize, FontStyle, FontUnit, gdiCharSet, gdiVerticalFont)
    End Function
    Public Function XmlToString(XDoc As Xml.XmlDocument) As String
        Using SW As New StringWriter
            Using XW As Xml.XmlWriter = Xml.XmlWriter.Create(SW)
                XDoc.WriteTo(XW)
                XW.Flush()
                Return SW.GetStringBuilder.ToString
            End Using
        End Using
    End Function
    Public Function cLineStyle(Style As String) As LineStyle
        Select Case Style
            Case "None"
                Return LineStyle.None
            Case "Solid"
                Return LineStyle.Solid
            Case "Dashed"
                Return LineStyle.Dashed
            Case "Dotted"
                Return LineStyle.Dotted
            Case Else
                Return LineStyle.None
        End Select
    End Function
    Public Function cVAlignment(Alignment As String) As ItemVerticalAlignment
        Select Case Alignment
            Case "Top"
                Return ItemVerticalAlignment.Top
            Case "Center"
                Return ItemVerticalAlignment.Center
            Case "Bottom"
                Return ItemVerticalAlignment.Bottom
            Case Else
                Return ItemVerticalAlignment.Bottom
        End Select
    End Function
    Public Function cHAlignment(Alignment As String) As ItemHorizontalAlignment
        Select Case Alignment
            Case "Left"
                Return ItemHorizontalAlignment.Left
            Case "Center"
                Return ItemHorizontalAlignment.Center
            Case "Right"
                Return ItemHorizontalAlignment.Right
            Case Else
                Return ItemHorizontalAlignment.Left
        End Select
    End Function
    Public Function cAreaType(Type As String) As DocumentAreaType
        Select Case Type
            Case "Header1stPage"
                Return DocumentAreaType.Header1stPage
            Case "HeaderAllPages"
                Return DocumentAreaType.HeaderAllPages
            Case "Footer1stPage"
                Return DocumentAreaType.Footer1stPage
            Case "FooterAllPages"
                Return DocumentAreaType.FooterAllPages
            Case "Body"
                Return DocumentAreaType.Body
            Case "PageBackground"
                Return DocumentAreaType.PageBackground
            Case "MultiLabelBody"
                Return DocumentAreaType.MultiLabelBody
            Case Else
                Return DocumentAreaType.Body
        End Select
    End Function
    Public Function cDataSource(DataSource As String) As MyDocumentArea.MyDataSourceType
        Select Case DataSource
            Case "None"
                Return MyDocumentArea.MyDataSourceType.None
            Case "DataTable"
                Return MyDocumentArea.MyDataSourceType.DataTable
            Case "SQLQuery"
                Return MyDocumentArea.MyDataSourceType.SQLQuery
            Case "ODBCQuery"
                Return MyDocumentArea.MyDataSourceType.ODBCQuery
            Case Else
                Return MyDocumentArea.MyDataSourceType.None
        End Select
    End Function
    Public Function cItemPosition(Position As String) As MyItemPosition
        Select Case Position
            Case "Absolute"
                Return MyItemPosition.Absolute
            Case "Relative"
                Return MyItemPosition.Relative
            Case Else
                Return MyItemPosition.Absolute
        End Select
    End Function
    Public Function cItemVisibility(Visibility As String) As MyItemVisibility
        Select Case Visibility
            Case "Invisible"
                Return MyItemVisibility.Invisible
            Case "Visible"
                Return MyItemVisibility.Visible
            Case "Relative"
                Return MyItemVisibility.Relative
            Case Else
                Return MyItemVisibility.Visible
        End Select
    End Function
    Public Function cFieldValueType(ValueType As String) As MyField.FieldValueType
        Select Case ValueType
            Case "Text"
                Return MyField.FieldValueType.Text
            Case "Numeric"
                Return MyField.FieldValueType.Numeric
            Case "Date"
                Return MyField.FieldValueType.Date
            Case Else
                Return MyField.FieldValueType.Text
        End Select
    End Function
    Public Function mmTOp(mm As Single) As Integer
        Return Math.Round(mm / mmpp)
    End Function
    Public Function pTOmm(p As Integer) As Single
        Return p * mmpp
    End Function
End Module
