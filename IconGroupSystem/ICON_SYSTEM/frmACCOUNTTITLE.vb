Public Class frmACCOUNTTITLE

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If txtACCTCODE.Text = String.Empty Or txtACCTTITLE.Text = String.Empty Or txtDEPCODE.Text = String.Empty Then

            MsgBox("Please Complete Data", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            Try
                If MsgBox("Save this Account Title ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                    cn.Open()
                    cm = New MySqlCommand("INSERT into tblaccount_title (account_code, account_title, dep_code) values(@account_code, @account_title, @dep_code)", cn)

                    With cm.Parameters

                        .AddWithValue("@account_code", txtACCTCODE.Text)
                        .AddWithValue("@account_title", txtACCTTITLE.Text)
                        .AddWithValue("@dep_code", txtDEPCODE.Text)

                    End With

                    cm.ExecuteNonQuery()
                    cn.Close()

                    MsgBox("Account Title has been Successfully Saved!", vbInformation)

                    txtACCTCODE.Clear()
                    txtACCTTITLE.Clear()
                    'txtDEPCODE.Clear()

                    txtACCTCODE.Focus()

                End If

            Catch ex As Exception

                cn.Close()
                MsgBox(ex.Message, vbCritical)

            End Try

        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Try

            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub frmACCOUNTTITLE_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            Else

                e.Cancel = True

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub
End Class