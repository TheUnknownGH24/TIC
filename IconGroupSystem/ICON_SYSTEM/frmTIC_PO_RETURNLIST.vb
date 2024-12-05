Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmTIC_PO_RETURNLIST

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        LoadPOList()

    End Sub

    Sub LoadPOList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_purchasedorder where `STATUS` = 'RETURN' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("po_no").ToString, dr.Item("pr_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("shipping_method").ToString, dr.Item("payment_terms").ToString, dr.Item("required_date").ToString, dr.Item("delivery_address").ToString, dr.Item("supplier").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString, dr.Item("coo_comment").ToString)

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
            .Text = "VIEW"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End With
        dataGridView1.Columns.Insert(15, colApproval)

    End Sub



    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick


        Dim colname As String = dataGridView1.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            With frmTIC_PO_RETURN_FORM
                cn.Open()
                cm = New MySqlCommand("select * from tbl_tic_purchasedorder where id like '" & dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
                dr = cm.ExecuteReader
                While dr.Read

                    .txtID.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                    .txtPONO.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                    .txtCONTROL.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                    .txtEMPLOYEE.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                    .txtDEPARTMENT.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
                    .txtDATE.Text = dataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString
                    .txtSHIPPINGMETHOD.Text = dataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString

                    .txtPAYMENTTERMS.Text = dataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString
                    .txtREQUIREDDATE.Text = dataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString
                    .txtDELIVERYADDRESS.Text = dataGridView1.Rows(e.RowIndex).Cells(10).Value.ToString

                    .txtSUPPLIER.Text = dataGridView1.Rows(e.RowIndex).Cells(11).Value.ToString
                    .txtMANAGERCOMMENT.Text = dataGridView1.Rows(e.RowIndex).Cells(12).Value.ToString
                    .txtGMCOMMENT.Text = dataGridView1.Rows(e.RowIndex).Cells(13).Value.ToString
                    .txtCOOCOMMENT.Text = dataGridView1.Rows(e.RowIndex).Cells(14).Value.ToString

                End While
                dr.Close()
                cn.Close()
                .LoadItemList()
                .Supplier_sum()
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With

        End If

    End Sub

    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_purchasedrequest where pr_no like '%" & txtSEARCHNAME.Text & "%' AND `MANAGER_APPROVAL` = 'APPROVED' AND `GM_APPROVAL` = 'APPROVED' AND `COO_APPROVAL` = 'FOR APPROVAL' AND `STATUS` = 'ACTIVE'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("pr_no").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("purpose").ToString, dr.Item("supplier_1").ToString, dr.Item("supplier_2").ToString, dr.Item("supplier_3").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub frmTIC_PO_RETURNLIST_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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