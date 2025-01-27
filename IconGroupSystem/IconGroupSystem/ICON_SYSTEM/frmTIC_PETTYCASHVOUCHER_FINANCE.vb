﻿Public Class frmTIC_PETTYCASHVOUCHER_FINANCE

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
        DataGridView2.Columns.Insert(14, colApproval)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_pettycash where `pcv_no` like '%" & TextBox3.Text & "%' AND `endorsed_approval` = 'APPROVED' AND `finance_approval` = 'FOR APPROVAL' AND `final_approval` = 'FOR RELEASE' AND `STATUS` = 'ACTIVE'", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("pcv_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("purpose").ToString, dr.Item("amount").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

        End While

        dr.Close()

        cn.Close()

    End Sub

    Sub LoadPCVList()


        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_pettycash where `endorsed_approval` = 'APPROVED' AND `finance_approval` = 'FOR APPROVAL' AND `final_approval` = 'FOR RELEASE' AND `STATUS` = 'ACTIVE' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("pcv_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("purpose").ToString, dr.Item("amount").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub DataGridView2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView2.CurrentCellDirtyStateChanged

        DataGridView2.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        Dim colname As String = DataGridView2.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_tic_pettycash where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString
                txtCONTROL.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
                txtTRANSACTION.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value.ToString
                txtDATE.Text = DataGridView2.Rows(e.RowIndex).Cells(4).Value.ToString
                txtEMPLOYEE.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value.ToString
                txtDEPARTMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(6).Value.ToString
                txtDEPCODE.Text = DataGridView2.Rows(e.RowIndex).Cells(7).Value.ToString
                txtDATENEEDED.Text = DataGridView2.Rows(e.RowIndex).Cells(8).Value.ToString

                txtPURPOSE.Text = DataGridView2.Rows(e.RowIndex).Cells(9).Value.ToString
                txtTOTALAMOUNT.Text = DataGridView2.Rows(e.RowIndex).Cells(10).Value.ToString

                txtMANAGERCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(11).Value.ToString

            End While
            dr.Close()
            cn.Close()

            LoadPCVITEMLIST()

            btnSAVE.Enabled = True
            Button1.Enabled = True
            btnRETURN.Enabled = True

        End If

    End Sub

    Sub LoadPCVITEMLIST()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_pettycashlist where `pcv_no` like '%" & txtCONTROL.Text & "%' ", cn)
        dr = cm.ExecuteReader

        While dr.Read

            dataGridView1.Rows.Add(dr.Item("expenses_categories").ToString, dr.Item("amount").ToString, dr.Item("remarks").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_tic_pettycash set finance_approval=@finance_approval, finance_comment=@finance_comment, status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@finance_approval", "APPROVED")
                .AddWithValue("@finance_comment", txtRELEASER.Text & "-" & DateTimePicker1.Value)

                .AddWithValue("@status", "ACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

            LoadPCVList()

            btnSAVE.Enabled = False
            Button1.Enabled = False
            btnRETURN.Enabled = False

            MsgBox("PETTY CASH has been Successfully Approved!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_tic_pettycash set finance_approval=@finance_approval, finance_comment=@finance_comment, status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@finance_approval", "DISAPPROVED")
                .AddWithValue("@finance_comment", txtRELEASER.Text & "-" & DateTimePicker1.Value)

                .AddWithValue("@status", "DEACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

            LoadPCVList()

            btnSAVE.Enabled = False
            Button1.Enabled = False
            btnRETURN.Enabled = False

            MsgBox("PETTY CASH has been Successfully Disapproved!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub btnRETURN_Click(sender As Object, e As EventArgs) Handles btnRETURN.Click

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_tic_pettycash set endorsed_approval=@endorsed_approval, finance_approval=@finance_approval, finance_comment=@finance_comment, status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@endorsed_approval", "FOR APPROVAL")
                .AddWithValue("@finance_approval", "FOR APPROVAL")
                .AddWithValue("@finance_comment", txtRELEASER.Text & "-" & DateTimePicker1.Value)

                .AddWithValue("@status", "RETURNED")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

            LoadPCVList()

            btnSAVE.Enabled = False
            Button1.Enabled = False
            btnRETURN.Enabled = False

            MsgBox("PETTY CASH has been Successfully Return!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub frmTIC_PETTYCASHVOUCHER_FINANCE_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtRELEASER.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub dataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles dataGridView1.CurrentCellChanged

        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        dataGridView1.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

    End Sub
End Class