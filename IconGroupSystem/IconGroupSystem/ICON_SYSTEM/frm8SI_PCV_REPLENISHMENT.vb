Public Class frm8SI_PCV_REPLENISHMENT

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Sub Add_Approval_Button()

        Dim colApproval As New DataGridViewButtonColumn
        With colApproval
            .Width = 50
            .Name = "MANAGER_APPROVAL"
            .HeaderText = ""
            .Text = "SELECT"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End With
        DataGridView1.Columns.Insert(3, colApproval)

    End Sub

    Sub Add_Approval_Checkedbox()

        Dim checkboxcol As New DataGridViewCheckBoxColumn
        With checkboxcol
            .Width = 20
            '.Name = "checkboxcol"
            '.HeaderText = "#"
            .DefaultCellStyle.NullValue = True
        End With
        DataGridView2.Columns.Insert(0, checkboxcol)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

        DataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_pettycash_liquidation where `pcv_no` like '%" & TextBox3.Text & "%' AND `endorsed_approval` = 'APPROVED' AND `finance_approval` = 'APPROVED' AND `final_approval` = 'APPROVED' AND `STATUS` = 'ACTIVE'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1

            DataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("pcv_no").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub LoadPCVLIQList()

        DataGridView1.Rows.Clear()
        Dim i As Integer

        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_pettycash_liquidation where `STATUS` = 'LIQUIDATED' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1

            DataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("pcv_no").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub LoadPCVREIMList()

        Dim i As Integer

        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_pcv_reimbursement where `STATUS` = 'RELEASED' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1

            DataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("pcv_no").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub frm8SI_PCV_REPLENISHMENT_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Sub PCV_Total()

        Dim TOTALPRICE As Decimal = 0

        For i = 0 To DataGridView2.Rows.Count - 1
            TOTALPRICE += DataGridView2.Rows(i).Cells(5).Value
        Next

        txtPCVAMOUNT.Text = CDbl(TOTALPRICE).ToString("#,##0.00")

    End Sub

    Sub PCV_GrandTotal()

        Dim TOTALPRICE As Decimal = 0

        For i = 0 To DataGridView3.Rows.Count - 1
            TOTALPRICE += DataGridView3.Rows(i).Cells(5).Value
        Next

        txtTOTAL.Text = CDbl(TOTALPRICE).ToString("#,##0.00")

    End Sub

    Sub PCV_Available()

        If txtTOTAL.Text = String.Empty Then

            Dim TOTALPRICE As Decimal = 0

            TOTALPRICE = 10000 - txtPCVAMOUNT.Text

            txtAVAILABLE.Text = CDbl(TOTALPRICE).ToString("#,##0.00")

        Else

            Dim TOTALPRICE As Decimal = 0

            TOTALPRICE = 10000 - txtTOTAL.Text - txtPCVAMOUNT.Text

            txtAVAILABLE.Text = CDbl(TOTALPRICE).ToString("#,##0.00")

        End If

    End Sub

    Private Sub dataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellChanged

        DataGridView1.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Try

            If DataGridView1.Columns(e.ColumnIndex).Name = "MANAGER_APPROVAL" Then

                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                txtPCV_SELECT.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString

            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Sub LoadPCVITEMLIST()

        If txtCODE.Text = String.Empty Then

            DataGridView2.Rows.Clear()

        ElseIf txtCODE.Text = "PCV" Then

            DataGridView2.Rows.Clear()

            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_pettycash_liquidationlist where `pcv_no` like '" & txtPCV_SELECT.Text & "' ", cn)
            dr = cm.ExecuteReader

            While dr.Read

                DataGridView2.Rows.Add(dr.Item("pcv_no").ToString, dr.Item("expense_categories").ToString, dr.Item("date_of_receipt").ToString, dr.Item("supplier_name").ToString, dr.Item("receipt_no").ToString, dr.Item("receipt_amount").ToString, dr.Item("remarks").ToString)

            End While

            dr.Close()
            cn.Close()

        ElseIf txtCODE.Text = "PCVREIM" Then

            DataGridView2.Rows.Clear()

            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_pcv_reimbursement_list where `pcv_no` like '" & txtPCV_SELECT.Text & "' ", cn)
            dr = cm.ExecuteReader

            While dr.Read

                DataGridView2.Rows.Add(dr.Item("pcv_no").ToString, dr.Item("expense_categories").ToString, dr.Item("date_of_receipt").ToString, dr.Item("supplier_name").ToString, dr.Item("receipt_no").ToString, dr.Item("receipt_amount").ToString, dr.Item("remarks").ToString)
            End While

            dr.Close()
            cn.Close()

        End If

    End Sub

    Private Sub txtPCVAMOUNT_TextChanged(sender As Object, e As EventArgs) Handles txtPCVAMOUNT.TextChanged

        PCV_Available()

    End Sub

    Sub PassData()

        'References to source and target grid.

        Dim sourceGrid As DataGridView = Me.DataGridView2
        Dim targetGrid As DataGridView = Me.DataGridView3

        'Copy all rows and cells.

        Dim targetRows = New List(Of DataGridViewRow)

        For Each sourceRow As DataGridViewRow In sourceGrid.Rows

            If (Not sourceRow.IsNewRow) Then

                Dim targetRow = CType(sourceRow.Clone(), DataGridViewRow)

                For Each cell As DataGridViewCell In sourceRow.Cells
                    targetRow.Cells(cell.ColumnIndex).Value = cell.Value
                Next

                targetRows.Add(targetRow)

            End If

        Next

        For Each column As DataGridViewColumn In sourceGrid.Columns
            targetGrid.Columns.Add(CType(column.Clone(), DataGridViewColumn))
        Next

        'It's recommended to use the AddRange method (if available)
        'when adding multiple items to a collection.

        targetGrid.Rows.AddRange(targetRows.ToArray())

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If txtPCV_SELECT.Text = String.Empty Then

            MsgBox("Please Select Petty Cash Voucher!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If txtAVAILABLE.Text < 0 Then

            MsgBox("Replenishment below Php 10,000.00!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        Try
            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Replenished()

                PCV_GrandTotal()

                PCV_UPDATE()

                LoadPCVLIQList()
                LoadPCVREIMList()

                txtPCV_SELECT.Text = String.Empty

                If txtCONTROL.Text = String.Empty Or txtCONTROL.Text = "" Then

                    SAVE_DATA()
                    DisplayCANO()
                    SavePCVREPLENISHlist()

                Else

                    UPDATE_DATA()
                    DeleteInCALIQList()
                    SavePCVREPLENISHlist()

                End If

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Sub PCV_UPDATE()

        If txtCODE.Text = "PCV" Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_pettycash_liquidation set status=@status where pcv_no=@pcv_no", cn)

            With cm.Parameters

                .AddWithValue("@pcv_no", txtPCV_SELECT.Text)
                .AddWithValue("@status", "REPLENISHED")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        ElseIf txtCODE.Text = "PCVREIM" Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_pcv_reimbursement set status=@status where pcv_no=@pcv_no", cn)

            With cm.Parameters

                .AddWithValue("@pcv_no", txtPCV_SELECT.Text)
                .AddWithValue("@status", "REPLENISHED")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        End If

    End Sub

    Private Sub txtPCV_SELECT_TextChanged(sender As Object, e As EventArgs) Handles txtPCV_SELECT.TextChanged

        Dim s As String = txtPCV_SELECT.Text
        Dim i As Integer = s.IndexOf("_")
        Dim TinCombo As String = s.Substring(i + 1, s.IndexOf("_", i + 1) - i - 1)
        txtCODE.Text = TinCombo

        LoadPCVITEMLIST()

        txtPETTYCASH.Text = CDbl("10,000.0").ToString("#,##0.00")

        PCV_Total()

    End Sub

    Sub Replenished()

        For i = 0 To DataGridView2.Rows.Count - 1

            DataGridView3.Rows.Add(DataGridView2.Rows(i).Cells.Cast(Of DataGridViewCell).Select(Function(A) A.Value).ToArray)

        Next

        DataGridView2.Rows.Clear()

    End Sub
    Private Sub DataGridView2_CurrentCellChanged(sender As Object, e As EventArgs) Handles DataGridView2.CurrentCellChanged

        DataGridView2.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub DataGridView3_CurrentCellChanged(sender As Object, e As EventArgs) Handles DataGridView3.CurrentCellChanged

        DataGridView3.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Sub SAVE_DATA()

        Try

            cn.Open()
            cm = New MySqlCommand("INSERT into tbl_8si_pcv_replenishment (transaction_no, employee_name, department, dep_code, date, grand_total, manager_approval, manager_comment, gm_approval, gm_comment, date_time, status) values(@transaction_no, @employee_name, @department, @dep_code, @date, @grand_total, @manager_approval, @manager_comment, @gm_approval, @gm_comment, @date_time, @status)", cn)

            With cm.Parameters

                .AddWithValue("@transaction_no", txtTRANSACTION.Text)
                .AddWithValue("@employee_name", txtEMPLOYEE.Text)
                .AddWithValue("@department", txtDEPARTMENT.Text)
                .AddWithValue("@dep_code", txtDEPCODE.Text)
                .AddWithValue("@date", txtDATE.Text)
                .AddWithValue("@grand_total", txtTOTAL.Text)

                .AddWithValue("@manager_approval", "FOR APPROVAL")
                .AddWithValue("@manager_comment", " ")

                .AddWithValue("@gm_approval", "FOR APPROVAL")
                .AddWithValue("@gm_comment", " ")

                .AddWithValue("@date_time", DateTimePicker1.Value)

                .AddWithValue("@status", "ACTIVE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception

            cn.Close()
            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Sub DisplayCANO()

        Try

            cn.Open()

            adp = New MySqlDataAdapter("select * from tbl_8si_pcv_replenishment where `transaction_no` = '" & txtTRANSACTION.Text & "' ORDER BY id DESC LIMIT 1", cn)
            dt = New DataTable
            adp.Fill(dt)

            txtCONTROL.Text = dt.Rows(0)(1).ToString()

            cn.Close()

        Catch ex As Exception

            cn.Close()
            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Sub SavePCVREPLENISHlist()

        Try

            For Each row As DataGridViewRow In DataGridView3.Rows

                cm = New MySqlCommand("INSERT into tbl_8si_pcv_replenishment_list (pcv_no, expense_categories, date_of_receipt, supplier_name, receipt_no, receipt_amount, remarks) values(@pcv_no, @expense_categories, @date_of_receipt, @supplier_name, @receipt_no, @receipt_amount, @remarks)", cn)

                With cm.Parameters

                    .AddWithValue("@pcv_no", txtCONTROL.Text)

                    .AddWithValue("@expense_categories", row.Cells("EXPENSE_CATEGORIES").Value)
                    .AddWithValue("@date_of_receipt", row.Cells("date_of_receipt").Value)
                    .AddWithValue("@supplier_name", row.Cells("supplier_name").Value)
                    .AddWithValue("@receipt_no", row.Cells("receipt_no").Value)
                    .AddWithValue("@receipt_amount", row.Cells("RECEIPT_AMOUNT").Value)
                    .AddWithValue("@remarks", row.Cells("remarks").Value)

                End With

                cn.Open()
                cm.ExecuteNonQuery()
                cn.Close()

            Next

            MsgBox("PCV Replenishment has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

        Catch ex As Exception

            cn.Close()
            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Sub DeleteInCALIQList()

        cm = New MySqlCommand("DELETE FROM tbl_8si_pcv_replenishment_list WHERE `pcv_no` like '" & txtCONTROL.Text & "'", cn)

        cn.Open()
        cm.ExecuteNonQuery()
        cn.Close()

    End Sub

    Sub UPDATE_DATA()

        Try

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_pcv_replenishment set grand_total=@grand_total where pcv_replenishment=@pcv_replenishment", cn)

            With cm.Parameters

                .AddWithValue("@pcv_replenishment", txtCONTROL.Text)

                .AddWithValue("@grand_total", txtTOTAL.Text)

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception

            cn.Close()
            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

End Class