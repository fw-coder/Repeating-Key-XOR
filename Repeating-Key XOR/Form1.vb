Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ' Getting repeating key and text to encrypt
        Dim key As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(TextBox1.Text)
        Dim txt As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(TextBox2.Text)
        Dim counter As Integer = 0

        For i As Integer = 0 To txt.Length - 1 Step 3
            For j As Integer = 0 To key.Length - 1
                Dim out As Byte = txt(counter) Xor key(j)
                TextBox3.Text = TextBox3.Text & out ' this is wrong - needs to be converted to hex string
                counter = counter + 1
                If counter = txt.Length Then Exit For
            Next
        Next

    End Sub
End Class
