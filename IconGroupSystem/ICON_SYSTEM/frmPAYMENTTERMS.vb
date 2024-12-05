Imports MySql.Data.MySqlClient

Public Class frmPAYMENTTERMS

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Try

            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                frmPO_FORM.LoadPaymentTerms()
                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If txtADDPAYMENTTERMS.Text = String.Empty Then

            MsgBox("Please Input Category", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            Try
                If MsgBox("Save this Payment Terms ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                    cn.Open()
                    cm = New MySqlCommand("INSERT into tblpayment_terms (payment_terms) values(@payment_terms)", cn)
                    cm.Parameters.AddWithValue("@payment_terms", txtADDPAYMENTTERMS.Text)
                    cm.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("Category has been Successfully Saved!", vbInformation)
                    txtADDPAYMENTTERMS.Clear()
                    txtADDPAYMENTTERMS.Focus()

                    With frmPO_FORM
                        .LoadPaymentTerms()
                    End With

                End If

            Catch ex As Exception
                cn.Close()
                MsgBox(ex.Message, vbCritical)
            End Try

        End If

    End Sub

    Private Sub frmPAYMENTTERMS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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