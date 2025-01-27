Imports MySql.Data.MySqlClient

Public Class frmCLASSIFICATION

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Try

            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()
                frmPRODUCT.LoadCategory()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If txtADDCLASSIFICATION.Text = String.Empty Then

            MsgBox("Please Input Classification", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            Try
                If MsgBox("Save this Classification ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                    cn.Open()
                    cm = New MySqlCommand("INSERT into tblclassification (classification) values(@classification)", cn)
                    cm.Parameters.AddWithValue("@classification", txtADDCLASSIFICATION.Text)
                    cm.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("Classification has been Successfully Saved!", vbInformation)
                    txtADDCLASSIFICATION.Clear()
                    txtADDCLASSIFICATION.Focus()
                    With frmITEM
                        .LoadClassification()
                    End With
                End If

            Catch ex As Exception
                cn.Close()
                MsgBox(ex.Message, vbCritical)
            End Try

        End If

    End Sub

    Private Sub frmCLASSIFICATION_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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