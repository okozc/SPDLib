Module ConvertValue
    Public Function ToCode39Extended(Value As String) As String
        Dim ConvertedString As String = ""
        Dim ConvertedChar() As String =
            {"%U", "$A", "$B", "$C", "$D", "$E", "$F", "$G", "$H", "$I", "$J", "$K", "$L", "$M",
            "$N", "$O", "$P", "$Q", "$R", "$S", "$T", "$U", "$V", "$W", "$X", "$Y", "$Z", "%A",
            "%B", "%C", "%D", "%E", " ", "/A", "/B", "/C", "/D", "/E", "/F", "/G", "/H", "/I",
            "/J", "/K", "/L", "-", ".", "/O", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
            "/Z", "%F", "%G", "%H", "%I", "%J", "%V", "A", "B", "C", "D", "E", "F", "G", "H", "I",
            "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
            "%K", "%L", "%M", "%N", "%O", "%W", "+A", "+B", "+C", "+D", "+E", "+F", "+G", "+H",
            "+I", "+J", "+K", "+L", "+M", "+N", "+O", "+P", "+Q", "+R", "+S", "+T", "+U", "+V",
            "+W", "+X", "+Y", "+Z", "%P", "%Q", "%R", "%S", "%T"}.ToArray
        If Not String.IsNullOrEmpty(Value) Then
            Dim ASCII As Byte() = Text.Encoding.ASCII.GetBytes(Value)
            For index As Integer = 0 To Value.Length - 1
                ConvertedString += ConvertedChar(ASCII(index))
            Next
        End If
        ConvertedChar = Nothing
        Return ConvertedString
    End Function

End Module
