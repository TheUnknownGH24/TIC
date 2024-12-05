Public Class frm8SIVOUCHER

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub
End Class