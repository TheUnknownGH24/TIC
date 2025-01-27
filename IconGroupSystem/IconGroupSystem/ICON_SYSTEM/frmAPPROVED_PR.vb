Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmAPPROVED_PR

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try


    End Sub
End Class