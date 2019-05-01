Public Class Form1
    Dim dict As Dictionary(Of String, String)
    Dim ArabicStr = "ظ ز و ة ى لا ر ؤ ء ئ ط ك م ن ت ا ل ب ي س ش د ج ح خ ه ع غ ف ق ث ص ض | + _ ) ( * & ^ % $ # @ ! ّ \ = - 0 9 8 7 6 5 4 3 2 1 ذ"
    Dim EnglishStr = "/ . , m n b v c x z ' ; l k j h g f d s a ] [ p o i u y t r e w q | + _ ) ( * & ^ % $ # @ ! ~ \ = - 0 9 8 7 6 5 4 3 2 1 `"
    Dim FrenchStr = " ! : ; , n b v c x w ù m l k j h g f d s q $ ^ p o i u y t r e z a µ + ° 0 9 8 7 6 5 4 3 2 1 * = ) à ç _ è - ( ' % é & ²"
    Dim RusianStr = ". ю б ь т и м с ч я э ж д л о р п а в ы ф ъ х з щ ш г н е к у ц й / + _ ) ( * ? : % ; № Э ! Ё \ = - 0 9 8 7 6 5 4 3 2 1 ё"
    Dim ArabicArr As String() = ArabicStr.Split(" ")
    Dim EnglishArr As String() = EnglishStr.Split(" ")
    Dim FrenchArr As String() = FrenchStr.Split(" ")
    Dim RusianArr As String() = RusianStr.Split(" ")

    Function CheckLanguage(FirstChar As String)
        Dim LanguageDetector = "UnKnown"

        If EnglishArr.Contains(FirstChar) Then
            LanguageDetector = "English"


        ElseIf ArabicArr.Contains(FirstChar) Then
            LanguageDetector = "Arabic"


        ElseIf FrenchArr.Contains(FirstChar) Then
            LanguageDetector = "Franch"


        ElseIf RusianArr.Contains(FirstChar) Then
            LanguageDetector = "Russian"


        Else
            MessageBox.Show("UnKnown")
            Throw New Exception("can't Detect the Language")
        End If
        Return LanguageDetector
    End Function

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked AndAlso Not RichTextBox1.Text = "" Then
            ChooseFromTo(EnglishArr)
        End If
    End Sub
   

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked AndAlso Not RichTextBox1.Text = "" Then
            ChooseFromTo(ArabicArr)
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked AndAlso Not RichTextBox1.Text = "" Then
            ChooseFromTo(FrenchArr)
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked AndAlso Not RichTextBox1.Text = "" Then
            ChooseFromTo(RusianArr)
        End If
    End Sub

    Function FillDictionary(Key As String(), Value As String())
        dict = New Dictionary(Of String, String)
        For i = 0 To 60
            dict.Add(Key(i), Value(i))
        Next
        dict.Add(" ", " ")
        Return 0
    End Function

    Function ChooseFromTo(ToLanguage As String())
        If Not RichTextBox1.Text = "" Then
            Dim Arr = SplitString(LCase(RichTextBox1.Text), 1)

            Dim MyLanguage As String = CheckLanguage(Arr(0))

            Select Case (MyLanguage)

                Case "English"
                    FillDictionary(EnglishArr, ToLanguage)

                Case "Arabic"
                    FillDictionary(ArabicArr, ToLanguage)

                Case "Franch"
                    FillDictionary(FrenchArr, ToLanguage)

                Case "Russian"
                    FillDictionary(RusianArr, ToLanguage)

                Case Else
                    Throw New Exception("not found")

            End Select
            Dim str As String = ""
            For i = 0 To Arr.Length - 1
                str += dict.Item(Arr(i))
            Next
            'RichTextBox1.Text = ""
            If RadioButton1.Checked AndAlso Control.IsKeyLocked(Keys.CapsLock) Then
                RichTextBox1.Text = UCase(str)
            Else
                RichTextBox1.Text = str
            End If
        End If
        Return 0
    End Function

    Function SplitString(TheString As String, StringLen As Integer) As String()
        Dim ArrCount As Integer  'as it is declared locally, it will automatically reset to 0 when this is called again
        Dim I As Long  'we are going to use it.. so declare it (with local scope to avoid breaking other code)
        Dim TempArray() As String
        ReDim TempArray((Len(TheString) - 1) \ StringLen)
        For I = 1 To Len(TheString) Step StringLen
            TempArray(ArrCount) = Mid$(TheString, I, StringLen)
            ArrCount = ArrCount + 1
        Next
        SplitString = TempArray   'actually return the value 1 2 3 4 5 6 7 8 9 0    
    End Function
End Class