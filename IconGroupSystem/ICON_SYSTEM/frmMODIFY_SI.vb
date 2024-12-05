Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class frmMODIFY_SI

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try
    End Sub

    Sub LoadSIList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select tblsaleinvoice.id, tblsaleinvoice.si_no, tblsaleinvoice.sales_order, tblsaleinvoice.soldto, tblsaleinvoice.address, tblsaleinvoice.platforms, tblsaleinvoice.note, tblsalesinvoice_list.item_code, tblsalesinvoice_list.item_name, tblsalesinvoice_list.gross_sales, tblsalesinvoice_list.quantity, tblsalesinvoice_list.discount, tblsalesinvoice_list.gross_profit from tblsaleinvoice inner join tblsalesinvoice_list on tblsaleinvoice.sales_order=tblsalesinvoice_list.so_no", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("si_no").ToString, dr.Item("sales_order").ToString, dr.Item("soldto").ToString, dr.Item("address").ToString, dr.Item("platforms").ToString, dr.Item("note").ToString, dr.Item("item_code").ToString, dr.Item("item_name").ToString, dr.Item("gross_sales").ToString, dr.Item("quantity").ToString, dr.Item("gross_profit").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub


    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select tblsaleinvoice.id, tblsaleinvoice.si_no, tblsaleinvoice.sales_order, tblsaleinvoice.soldto, tblsaleinvoice.address, tblsaleinvoice.platforms, tblsaleinvoice.note, tblsalesinvoice_list.item_code, tblsalesinvoice_list.item_name, tblsalesinvoice_list.gross_sales, tblsalesinvoice_list.quantity, tblsalesinvoice_list.discount, tblsalesinvoice_list.gross_profit from tblsaleinvoice inner join tblsalesinvoice_list on tblsaleinvoice.sales_order=tblsalesinvoice_list.so_no  where tblsaleinvoice.si_no like '%" & txtSEARCHNAME.Text & "%' or tblsaleinvoice.sales_order like '%" & txtSEARCHNAME.Text & "%' or tblsaleinvoice.soldto like '%" & txtSEARCHNAME.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("si_no").ToString, dr.Item("sales_order").ToString, dr.Item("soldto").ToString, dr.Item("address").ToString, dr.Item("platforms").ToString, dr.Item("note").ToString, dr.Item("item_code").ToString, dr.Item("item_name").ToString, dr.Item("gross_sales").ToString, dr.Item("quantity").ToString, dr.Item("gross_profit").ToString)

        End While

        dr.Close()
        cn.Close()


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

            frmWAREHOUSE_DR.txtSO_NO.Text = Me.txtSO_NO.Text
            frmWAREHOUSE_DR.txtSOLDTO.Text = Me.txtSOLDTO.Text
            frmWAREHOUSE_DR.txtADDRESS.Text = Me.txtADDRESS.Text
            frmWAREHOUSE_DR.txtPLATFORMS.Text = Me.txtPLATFORMS.Text

            Dim dt2 As New DataTable
            dt2.Columns.Add("PRODUCT_CODE")
            dt2.Columns.Add("PRODUCT_NAME")
            dt2.Columns.Add("GROSS_SALES")
            dt2.Columns.Add("QUANTITY")
            dt2.Columns.Add("TOTAL")
            For Each row As DataGridViewRow In Me.dataGridView1.Rows
                Dim ischecked As Boolean = Convert.ToBoolean(row.Cells(0).Value)
                If ischecked Then
                    dt2.Rows.Add(row.Cells(8).Value, row.Cells(9).Value, row.Cells(10).Value, row.Cells(11).Value, row.Cells(12).Value)
                End If
            Next
            frmWAREHOUSE_DR.dataGridView1.DataSource = dt2

            frmWAREHOUSE_DR.ShowDialog()
            frmWAREHOUSE_DR.txtNOTE.Enabled = True

        End If
    End Sub

End Class