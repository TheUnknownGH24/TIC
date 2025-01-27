Imports MySql.Data.MySqlClient

Public Class frmUOM

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

        If txtUOM.Text = String.Empty Then

            MsgBox("Please Input UOM", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            Try
                If MsgBox("Save this UOM ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                    cn.Open()
                    cm = New MySqlCommand("INSERT into tbluom (uom) values(@uom)", cn)
                    cm.Parameters.AddWithValue("@uom", txtUOM.Text)
                    cm.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("UOM has been Successfully Saved!", vbInformation)
                    txtUOM.Clear()
                    txtUOM.Focus()
                    With frmITEM
                        .LoadUOM()
                    End With
                End If

            Catch ex As Exception
                cn.Close()
                MsgBox(ex.Message, vbCritical)
            End Try

        End If

    End Sub

    Private Sub frmUOM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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