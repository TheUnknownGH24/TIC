Imports MySql.Data.MySqlClient

Public Class frmGENERICNAME

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Try

            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If txtADDGENERICNAME.Text = String.Empty Or txtCLASSIFICATION.Text = String.Empty Then

            MsgBox("Please Input Complete Data", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            Try
                If MsgBox("Save this Classification ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                    cn.Open()
                    cm = New MySqlCommand("INSERT into tblmotherclass (generic_name, classification) values(@generic_name, @classification)", cn)
                    cm.Parameters.AddWithValue("@generic_name", txtADDGENERICNAME.Text)
                    cm.Parameters.AddWithValue("@classification", txtCLASSIFICATION.Text)
                    cm.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("Generic Name has been Successfully Saved!", vbInformation)
                    txtADDGENERICNAME.Clear()
                    txtCLASSIFICATION.Text = ""
                    txtADDGENERICNAME.Focus()
                    With frmITEM
                        .LoadGENERICNAME()
                    End With
                End If

            Catch ex As Exception
                cn.Close()
                MsgBox(ex.Message, vbCritical)
            End Try

        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        With frmCLASSIFICATION

            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()

        End With

    End Sub

    Sub LoadClassification()

        txtCLASSIFICATION.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblclassification", cn)
        dr = cm.ExecuteReader
        While dr.Read


            txtCLASSIFICATION.Items.Add(dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        LoadClassification()

    End Sub


    Private Sub frmGENERICNAME_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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