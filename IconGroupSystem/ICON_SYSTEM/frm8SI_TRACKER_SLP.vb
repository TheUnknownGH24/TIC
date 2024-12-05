﻿Imports MySql.Data.MySqlClient

Public Class frm8SI_TRACKER_SLP

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try


    End Sub

    Sub LoadSLP()

        DataGridView2.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_requestslip", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView2.Rows.Add(dr.Item("controlno").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtSUPPLIERNAME_TextChanged(sender As Object, e As EventArgs) Handles txtREFERENCE.TextChanged

        DataGridView2.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_requestslip where `controlno` like '%" & txtREFERENCE.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView2.Rows.Add(dr.Item("controlno").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If txtREFERENCE.Text = String.Empty Then

            txtPRNO.Text = ""

            txtMANAGER_STATUS.Text = ""
            txtMANAGER_REMARKS.Text = ""

            txtGM_STATUS.Text = ""
            txtGM_REMARKS.Text = ""

        Else

            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_requestslip where `controlno` like '%" & txtREFERENCE.Text & "%'", cn)

            dr = cm.ExecuteReader

            While dr.Read

                txtPRNO.Text = dr("controlno").ToString()

                txtMANAGER_STATUS.Text = dr("manager_approval").ToString()
                txtMANAGER_REMARKS.Text = dr("manager_comment").ToString()

                txtGM_STATUS.Text = dr("gm_approval").ToString()
                txtGM_REMARKS.Text = dr("gm_comment").ToString()

            End While

            dr.Close()
            cn.Close()

        End If


    End Sub

    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView2.DoubleClick

        txtREFERENCE.Text = DataGridView2.CurrentRow.Cells(0).Value


    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub frm8SI_TRACKER_SLP_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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