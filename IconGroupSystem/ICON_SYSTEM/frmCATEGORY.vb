Imports MySql.Data.MySqlClient

Public Class frmCATEGORY

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If txtADDCATEGORY.Text = String.Empty Then

            MsgBox("Please Input Category", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            Try
                If MsgBox("Save this Category ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                    cn.Open()
                    cm = New MySqlCommand("INSERT into tblCATEGORY (category) values(@category)", cn)
                    cm.Parameters.AddWithValue("@category", txtADDCATEGORY.Text)
                    cm.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("Category has been Successfully Saved!", vbInformation)
                    txtADDCATEGORY.Clear()
                    txtADDCATEGORY.Focus()
                    With frmPRODUCT
                        .LoadCategory()
                    End With
                    With frmPOS
                        .loadMenu()
                    End With
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
                frmPRODUCT.LoadCategory()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub frmCATEGORY_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Connection()

    End Sub

    Private Sub frmCATEGORY_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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