﻿Public Class frm8SI_PCV_REIMBURSEMENT_FINANCE

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Sub Add_Approval_Button()

        Dim colApproval As New DataGridViewButtonColumn
        With colApproval
            .Width = 50
            .Name = "MANAGER_APPROVAL"
            .HeaderText = ""
            .Text = ">"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End With
        DataGridView2.Columns.Insert(13, colApproval)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_pcv_reimbursement where `pcv_no` like '%" & TextBox3.Text & "%' AND `endorsed_approval` = 'APPROVED' AND `finance_approval` = 'FOR APPROVAL' AND `final_approval` = 'FOR APPROVAL' AND `STATUS` = 'ACTIVE'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("pcv_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("total_liquidation").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

            End While

            dr.Close()

        cn.Close()

    End Sub

    Sub LoadREIMList()

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_pcv_reimbursement where `endorsed_approval` = 'APPROVED' AND `finance_approval` = 'FOR APPROVAL' AND `final_approval` = 'FOR APPROVAL' AND `STATUS` = 'ACTIVE' ", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("pcv_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("total_liquidation").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

            End While

            dr.Close()
            cn.Close()

    End Sub


    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        Dim colname As String = DataGridView2.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_pcv_reimbursement where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString
                txtCONTROL.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
                txtREFERENCE.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value.ToString
                txtDATE.Text = DataGridView2.Rows(e.RowIndex).Cells(4).Value.ToString
                txtEMPLOYEE.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value.ToString
                txtDEPARTMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(6).Value.ToString
                txtDEPCODE.Text = DataGridView2.Rows(e.RowIndex).Cells(7).Value.ToString
                txtPURPOSE.Text = DataGridView2.Rows(e.RowIndex).Cells(8).Value.ToString

                txtTOTALLIQUIDATION.Text = DataGridView2.Rows(e.RowIndex).Cells(9).Value.ToString

                txtMANAGERCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(10).Value.ToString

            End While
            dr.Close()
            cn.Close()

            LoadREIMITEMLIST()

            btnSAVE.Enabled = True
            Button1.Enabled = True
            Button2.Enabled = True

        End If

    End Sub

    Sub LoadREIMITEMLIST()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_pcv_reimbursement_list where `pcv_no` like '%" & txtCONTROL.Text & "%' ", cn)
        dr = cm.ExecuteReader

        While dr.Read

            dataGridView1.Rows.Add(dr.Item("expense_categories").ToString, dr.Item("date_of_receipt").ToString, dr.Item("supplier_name").ToString, dr.Item("receipt_no").ToString, dr.Item("receipt_amount").ToString, dr.Item("remarks").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_pcv_reimbursement set finance_approval=@finance_approval, finance_comment=@finance_comment, status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@finance_approval", "APPROVED")
                .AddWithValue("@finance_comment", txtFINANCE.Text & "-" & DateTimePicker1.Value)

                .AddWithValue("@status", "ACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

            LoadREIMList()

            btnSAVE.Enabled = False
            Button1.Enabled = False
            Button2.Enabled = False

            MsgBox("PCV Reimbursement has been Successfully Verified!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_pcv_reimbursement set finance_approval=@finance_approval, finance_comment=@finance_comment, status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@finance_approval", "DISAPPROVED")
                .AddWithValue("@finance_comment", txtFINANCE.Text & "-" & DateTimePicker1.Value)

                .AddWithValue("@status", "DEACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

            LoadREIMList()

            btnSAVE.Enabled = False
            Button1.Enabled = False
            Button2.Enabled = False

            MsgBox("PCV Reimbursement has been Successfully Approved!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_pcv_reimbursement set endorsed_approval=@endorsed_approval, finance_approval=@finance_approval, finance_comment=@finance_comment, status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@endorsed_approval", "FOR APPROVAL")
                .AddWithValue("@finance_approval", "FOR APPROVAL")
                .AddWithValue("@finance_comment", txtFINANCE.Text & "-" & DateTimePicker1.Value)

                .AddWithValue("@status", "RETURNED")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

            LoadREIMList()

            btnSAVE.Enabled = False
            Button1.Enabled = False
            Button2.Enabled = False

            MsgBox("PCV Reimbursement has been Successfully Returned!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub frm8SI_PCV_REIMBURSEMENT_FINANCE_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtPURPOSE.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtMANAGERCOMMENT.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtFINANCE.Text
            .ShowDialog()

        End With

    End Sub
End Class