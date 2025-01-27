Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmTIC_PR_ADDSUPPLIER_2

    Sub LoadSupplierList()

        dataGridView1.Rows.Clear()
        txtID.Text = ""
        cn.Open()
        cm = New MySqlCommand("select * from tblsupplier", cn)
        dr = cm.ExecuteReader
        While dr.Read

            dataGridView1.Rows.Add(dr.Item("supplier_name").ToString, dr.Item("id").ToString)
        End While
        dr.Close()
        cn.Close()

    End Sub

    Private Sub dataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles dataGridView1.DoubleClick

        txtSEARCHNAME.Text = dataGridView1.CurrentRow.Cells(0).Value
        txtID.Text = dataGridView1.CurrentRow.Cells(1).Value

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If txtID.Text = String.Empty Then

            MsgBox("Please Select Exact Supplier!", vbCritical + vbOKOnly, "CONFIRMATION")

        Else

            frmTIC_PR_FORM.txtSUPPLIER_2.Text = txtSEARCHNAME.Text
            Dispose()

        End If

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try


    End Sub

    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        dataGridView1.Rows.Clear()
        txtID.Text = ""

        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblsupplier where supplier_name like '%" & txtSEARCHNAME.Text & "%' or address like '%" & txtSEARCHNAME.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(dr.Item("supplier_name").ToString, dr.Item("id").ToString)
        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub frmTIC_PR_ADDSUPPLIER_2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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