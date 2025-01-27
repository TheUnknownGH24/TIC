Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmPORECORDS
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        LoadPOList()

    End Sub

    Sub LoadPOList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblpurchasedorder", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("po_no").ToString, dr.Item("pr_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("shipping_method").ToString, dr.Item("payment_terms").ToString, dr.Item("required_date").ToString, dr.Item("delivery_address").ToString, dr.Item("supplier").ToString, dr.Item("MANAGER_APPROVAL").ToString, dr.Item("manager_comment").ToString, dr.Item("GM_APPROVAL").ToString, dr.Item("gm_comment").ToString, dr.Item("COO_APPROVAL").ToString, dr.Item("coo_comment").ToString)

        End While

        dr.Close()
        cn.Close()

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
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblpurchasedorder where `po_no` like '%" & txtSEARCHNAME.Text & "%' or `supplier` like '%" & txtSEARCHNAME.Text & "%' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("po_no").ToString, dr.Item("pr_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("shipping_method").ToString, dr.Item("payment_terms").ToString, dr.Item("required_date").ToString, dr.Item("delivery_address").ToString, dr.Item("supplier").ToString, dr.Item("MANAGER_APPROVAL").ToString, dr.Item("manager_comment").ToString, dr.Item("GM_APPROVAL").ToString, dr.Item("gm_comment").ToString, dr.Item("COO_APPROVAL").ToString, dr.Item("coo_comment").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

End Class