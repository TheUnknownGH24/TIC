Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class frmMODIFY_DR

    Dim da As New OleDbDataAdapter
    Dim dset As New DataSet
    Dim cmm As OleDbCommand
    Dim ccode As String

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
        cm = New MySqlCommand("select tbldeliveryreceipt.id, tbldeliveryreceipt.dr_no, tbldeliveryreceipt.sales_orderno, tbldeliveryreceipt.soldto, tbldeliveryreceipt.address, tbldeliveryreceipt.platforms, tbldeliveryreceipt.note, tbldeliveryreceipt_list.product_code, tbldeliveryreceipt_list.product_name, tbldeliveryreceipt_list.unit_price, tbldeliveryreceipt_list.quantity, tbldeliveryreceipt_list.total from tbldeliveryreceipt inner join tbldeliveryreceipt_list on tbldeliveryreceipt.sales_orderno=tbldeliveryreceipt_list.so_no where tbldeliveryreceipt.dr_no like '%" & txtSEARCHNAME.Text & "%' or tbldeliveryreceipt.sales_orderno like '%" & txtSEARCHNAME.Text & "%' or tbldeliveryreceipt.soldto like '%" & txtSEARCHNAME.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("dr_no").ToString, dr.Item("sales_orderno").ToString, dr.Item("soldto").ToString, dr.Item("address").ToString, dr.Item("platforms").ToString, dr.Item("note").ToString, dr.Item("product_code").ToString, dr.Item("product_name").ToString, dr.Item("unit_price").ToString, dr.Item("quantity").ToString, dr.Item("total").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub LoadDRList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select tbldeliveryreceipt.id, tbldeliveryreceipt.dr_no, tbldeliveryreceipt.sales_orderno, tbldeliveryreceipt.soldto, tbldeliveryreceipt.address, tbldeliveryreceipt.platforms, tbldeliveryreceipt.note, tbldeliveryreceipt_list.product_code, tbldeliveryreceipt_list.product_name, tbldeliveryreceipt_list.unit_price, tbldeliveryreceipt_list.quantity, tbldeliveryreceipt_list.total from tbldeliveryreceipt inner join tbldeliveryreceipt_list on tbldeliveryreceipt.sales_orderno=tbldeliveryreceipt_list.so_no", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("dr_no").ToString, dr.Item("sales_orderno").ToString, dr.Item("soldto").ToString, dr.Item("address").ToString, dr.Item("platforms").ToString, dr.Item("note").ToString, dr.Item("product_code").ToString, dr.Item("product_name").ToString, dr.Item("unit_price").ToString, dr.Item("quantity").ToString, dr.Item("total").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        txtSEARCHNAME.Text = dataGridView1.CurrentRow.Cells(3).Value

        txtSO_NO.Text = dataGridView1.CurrentRow.Cells(3).Value
        txtSOLDTO.Text = dataGridView1.CurrentRow.Cells(4).Value
        txtADDRESS.Text = dataGridView1.CurrentRow.Cells(5).Value
        txtPLATFORMS.Text = dataGridView1.CurrentRow.Cells(6).Value


    End Sub

    Private Sub btnCREATE_Click(sender As Object, e As EventArgs) Handles btnCREATE.Click

        If txtSEARCHNAME.Text = String.Empty Then

            MsgBox("Please Select Order", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            frmSALESINVOICE.txtSO_NO.Text = Me.txtSO_NO.Text
            frmSALESINVOICE.txtSOLDTO.Text = Me.txtSOLDTO.Text
            frmSALESINVOICE.txtADDRESS.Text = Me.txtADDRESS.Text
            frmSALESINVOICE.txtPLATFORMS.Text = Me.txtPLATFORMS.Text

            Dim dt2 As New DataTable
            dt2.Columns.Add("SKU_CODE")
            dt2.Columns.Add("ITEM_NAME")
            dt2.Columns.Add("UNIT_PRICE")
            dt2.Columns.Add("QUANTITY")
            dt2.Columns.Add("TOTAL")
            For Each row As DataGridViewRow In Me.dataGridView1.Rows
                Dim ischecked As Boolean = Convert.ToBoolean(row.Cells(0).Value)
                If ischecked Then
                    dt2.Rows.Add(row.Cells(8).Value, row.Cells(9).Value, row.Cells(10).Value, row.Cells(11).Value, row.Cells(12).Value)
                End If
            Next
            frmSALESINVOICE.dataGridView1.DataSource = dt2

            frmSALESINVOICE.ShowDialog()
            frmSALESINVOICE.txtNOTE.Enabled = True

        End If

    End Sub
End Class