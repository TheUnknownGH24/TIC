Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmMANAGER_PO_LIST

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        LoadPOList()

    End Sub

    Sub LoadPOList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblpurchasedorder where `MANAGER_APPROVAL` = 'FOR APPROVAL' AND `STATUS` = '' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("po_no").ToString, dr.Item("pr_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("shipping_method").ToString, dr.Item("payment_terms").ToString, dr.Item("required_date").ToString, dr.Item("delivery_address").ToString, dr.Item("supplier").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub Add_Approval_Button()

        Dim colApproval As New DataGridViewButtonColumn
        With colApproval
            .Width = 50
            .Name = "MANAGER_APPROVAL"
            .HeaderText = ""
            .Text = "VIEW_AND_APPROVED"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End With
        dataGridView1.Columns.Insert(12, colApproval)

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
        cm = New MySqlCommand("select * from tblpurchasedorder where `po_no` like '%" & txtSEARCHNAME.Text & "%' AND `MANAGER_APPROVAL` = 'FOR APPROVAL'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("po_no").ToString, dr.Item("pr_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("shipping_method").ToString, dr.Item("payment_terms").ToString, dr.Item("required_date").ToString, dr.Item("delivery_address").ToString, dr.Item("supplier").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Dim colname As String = dataGridView1.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            With frmMANAGER_PO_APPROVAL
                cn.Open()
                cm = New MySqlCommand("select * from tblpurchasedorder where id like '" & dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
                dr = cm.ExecuteReader
                While dr.Read
                    .txtID.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                    .txtPONO.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                    .txtREFERENCE.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString

                    .txtDATE.Text = dataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString
                    .txtSHIPPINGMETHOD.Text = dataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
                    .txtPAYMENTTERMS.Text = dataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString
                    .txtREQUIREDDATE.Text = dataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString

                    .txtDELIVERYADDRESS.Text = dataGridView1.Rows(e.RowIndex).Cells(10).Value.ToString

                    .txtSUPPLIER.Text = dataGridView1.Rows(e.RowIndex).Cells(11).Value.ToString

                End While
                dr.Close()
                cn.Close()
                '.LoadPaymentTerms()
                .LoadPURCHASEDList()
                .Supplier_sum()
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With

        End If

    End Sub

End Class