Imports System
Imports System.IO
Imports System.Text

Public Class Form1


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ' Getting repeating key and text to encrypt
        Dim key As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(TextBox1.Text)
        Dim txt As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(RichTextBox1.Text)
        Dim fileOut(txt.Length) As Byte

        Dim counter As Integer = 0

        For i As Integer = 0 To txt.Length - 1 Step key.Length
            For j As Integer = 0 To key.Length - 1
                Dim out As Byte = txt(counter) Xor key(j)
                fileOut(counter) = out
                If out < &H10 Then
                    RichTextBox3.Text = RichTextBox3.Text & "0" & Convert.ToString(out, 16) 'add leading 0 to first byte
                Else
                    RichTextBox3.Text = RichTextBox3.Text & Convert.ToString(out, 16)
                End If
                counter = counter + 1
                If counter = txt.Length Then Exit For
            Next
        Next

        Dim path As String = "c:\ttemp\MyTest.txt"
        Dim fs As FileStream = File.Create(path)
        fs.Write(fileOut, 0, fileOut.Length)
        fs.Close()
    End Sub
End Class
