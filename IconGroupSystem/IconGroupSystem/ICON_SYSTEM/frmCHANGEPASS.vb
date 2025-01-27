Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class frmCHANGEPASS

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()
                frmPRODUCT.LoadCategory()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If txtNEWPASSWORD.UseSystemPasswordChar = True Then

            txtNEWPASSWORD.UseSystemPasswordChar = False
            txtVERIFYPASSWORD.UseSystemPasswordChar = False

        Else

            txtNEWPASSWORD.UseSystemPasswordChar = True
            txtVERIFYPASSWORD.UseSystemPasswordChar = True

        End If

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs)

    End Sub

    Sub load_pass()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_login where `id` like '%" & txtID.Text & "%'", cn)

        dr = cm.ExecuteReader

        While dr.Read

            txtOLDPASSWORD.Text = dr("password").ToString()

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub btnSAVE_Click_1(sender As Object, e As EventArgs) Handles btnSAVE.Click

        Try

            If txtNEWPASSWORD.Text = String.Empty Or txtVERIFYPASSWORD.Text = String.Empty Then
                MsgBox("Please input data!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If txtNEWPASSWORD.Text <> txtVERIFYPASSWORD.Text Then
                MsgBox("Password not Match!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If txtNEWPASSWORD.Text = txtOLDPASSWORD.Text Then
                MsgBox("Old Password and New Password is Same!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If MsgBox("Save this Data ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_login set password=@password where id=@id", cn)

                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@password", txtNEWPASSWORD.Text)

                End With

                cm.ExecuteNonQuery()
                cn.Close()

                MsgBox("Password has been Successfully Change!", vbInformation + vbOKOnly, "CONFIRMATION")

                txtID.Text = ""
                txtNEWPASSWORD.Text = ""
                txtVERIFYPASSWORD.Text = ""
                txtOLDPASSWORD.Text = ""

            End If

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub frmCHANGEPASS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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