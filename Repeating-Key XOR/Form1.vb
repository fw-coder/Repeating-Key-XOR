Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ' Getting repeating key and text to encrypt
        Dim key As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(TextBox1.Text)
        Dim txt As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(RichTextBox1.Text)
        Dim counter As Integer = 0

        For i As Integer = 0 To txt.Length - 1 Step 3
            For j As Integer = 0 To key.Length - 1
                Dim out As Byte = txt(counter) Xor key(j)
                If counter = 0 And out < &H10 Then
                    TextBox3.Text = TextBox3.Text & "0" & Convert.ToString(out, 16) 'add leading 0 to first byte
                Else
                    TextBox3.Text = TextBox3.Text & Convert.ToString(out, 16)
                End If
                counter = counter + 1
                If counter = txt.Length Then Exit For
            Next
        Next

    End Sub
End Class
