﻿Public Class frmVIEW_8SI_CA_LIQUIDATION_FINANCE

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
        DataGridView2.Columns.Insert(15, colApproval)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_cashadvance_liquidation where `cano_liquidation` like '%" & TextBox3.Text & "%' AND `endorsed_approval` = 'APPROVED' AND `finance_approval` = 'FOR APPROVAL' OR `finance_approval` = 'APPROVED' AND `final_approval` = 'FOR APPROVAL' AND `STATUS` = 'ON-GOING LIQUIDATION'", cn)
        dr = cm.ExecuteReader

        While dr.Read

            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("cano_liquidation").ToString, dr.Item("ca_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("total_caamount").ToString, dr.Item("total_liquidation").ToString, dr.Item("total_balance").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

        End While

        dr.Close()

        cn.Close()


    End Sub

    Sub LoadCAList()

        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_cashadvance_liquidation where `endorsed_approval` = 'APPROVED' AND `finance_approval` = 'FOR APPROVAL' OR `finance_approval` = 'APPROVED' AND `final_approval` = 'FOR APPROVAL' AND `STATUS` = 'ON-GOING LIQUIDATION' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("cano_liquidation").ToString, dr.Item("ca_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("total_caamount").ToString, dr.Item("total_liquidation").ToString, dr.Item("total_balance").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString)

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
            cm = New MySqlCommand("select * from tbl_8si_cashadvance_liquidation where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
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

                txtTOTALCASHADVANCE.Text = DataGridView2.Rows(e.RowIndex).Cells(9).Value.ToString
                txtTOTALLIQUIDATION.Text = DataGridView2.Rows(e.RowIndex).Cells(10).Value.ToString
                txtTOTALBALANCE.Text = DataGridView2.Rows(e.RowIndex).Cells(11).Value.ToString

                txtMANAGERCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(12).Value.ToString

            End While
            dr.Close()
            cn.Close()

            LoadCAITEMLIST()

            btnSAVE.Visible = False
            'Button1.Enabled = True
            Button2.Visible = False

        End If

    End Sub

    Sub LoadCAITEMLIST()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_cashadvance_liquidationlist where `cano_liquidation` like '%" & txtCONTROL.Text & "%' ", cn)
        dr = cm.ExecuteReader

        While dr.Read

            dataGridView1.Rows.Add(dr.Item("expense_categories").ToString, dr.Item("date_of_receipt").ToString, dr.Item("supplier_name").ToString, dr.Item("receipt_no").ToString, dr.Item("receipt_amount").ToString, dr.Item("remarks").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_cashadvance_liquidation set finance_approval=@finance_approval, finance_comment=@finance_comment where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)

                .AddWithValue("@finance_approval", "DISAPPROVED")
                .AddWithValue("@finance_comment", txtFINANCECOMMENT.Text & "-" & DateTimePicker1.Value)

                .AddWithValue("@status", "DEACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

            LoadCAList()

            btnSAVE.Enabled = False
            Button1.Enabled = False
            Button2.Enabled = False

            MsgBox("CA LIQUIDATION has been Successfully Disapproved!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub frm8SI_CA_LIQUIDATION_FINANCE_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtPURPOSE.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtMANAGERCOMMENT.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtFINANCECOMMENT.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

    End Sub

    Private Sub dataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles dataGridView1.CurrentCellChanged

        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        dataGridView1.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

End Class