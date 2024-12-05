Public Class frmWAREHOUSE_RR_MIR

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_mir where `mir_no` like '%" & TextBox1.Text & "%' AND `STATUS` = 'ACTIVE' AND `manager_approval` = 'APPROVED' AND `final_approval` = 'APPROVED' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("mir_no").ToString, dr.Item("date").ToString, dr.Item("transactionno").ToString, dr.Item("date_required").ToString, dr.Item("requestor").ToString, dr.Item("department").ToString, dr.Item("purpose").ToString, dr.Item("production_no").ToString, dr.Item("production_name").ToString, dr.Item("manager_name").ToString, dr.Item("manager_approval").ToString, dr.Item("manager_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("date_time").ToString, dr.Item("status").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub LoadIPRList()

        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_mir where `STATUS` = 'ACTIVE' AND `manager_approval` = 'APPROVED' AND `final_approval` = 'APPROVED' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("mir_no").ToString, dr.Item("date").ToString, dr.Item("transactionno").ToString, dr.Item("date_required").ToString, dr.Item("requestor").ToString, dr.Item("department").ToString, dr.Item("purpose").ToString, dr.Item("production_no").ToString, dr.Item("production_name").ToString, dr.Item("manager_name").ToString, dr.Item("manager_approval").ToString, dr.Item("manager_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("date_time").ToString, dr.Item("status").ToString)

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
            .Text = ">"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End With
        DataGridView2.Columns.Insert(19, colApproval)

    End Sub

    Private Sub DataGridView2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView2.CurrentCellDirtyStateChanged

        DataGridView2.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        txtCONTROL.Text = String.Empty
        txtSUBREFERENCE.Text = String.Empty
        txtREFERENCE.Text = String.Empty
        txtSTATUS.Text = String.Empty

        txtRR_REFERENCE.Text = String.Empty

        dataGridView1.Rows.Clear()

        dataGridView1.Enabled = True

        Dim colname As String = DataGridView2.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_mir where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtPONO.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
                txtSUPPLIERNAME.Text = DataGridView2.Rows(e.RowIndex).Cells(6).Value.ToString

                txtPURPOSE.Text = DataGridView2.Rows(e.RowIndex).Cells(8).Value.ToString

            End While
            dr.Close()
            cn.Close()

            SHOW_RR_REFERENCE()

            LoadItemList()

            btnSAVE.Enabled = True

        End If

    End Sub

    Private Sub frm8SI_PAYMENTREQUEST_PO_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Sub LoadItemList()


        If txtRR_REFERENCE.Text = String.Empty Or txtRR_REFERENCE.Text = "" Then

            DataGridView3.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_mir_item where `mir_no` like '" & txtPONO.Text & "' ", cn)
            dr = cm.ExecuteReader
            While dr.Read
                DataGridView3.Rows.Add(dr.Item("qty_requested").ToString, dr.Item("uom").ToString, dr.Item("item_name").ToString, dr.Item(0).ToString, dr.Item(0).ToString, dr.Item(0).ToString)

            End While
            dr.Close()
            cn.Close()

        Else

            DataGridView3.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_rr_item where `rr_no` like '" & txtRR_REFERENCE.Text & "' AND `status` like 'PARTIAL'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                DataGridView3.Rows.Add(dr.Item("remaining").ToString, dr.Item("unit").ToString, dr.Item("itemname").ToString, dr.Item("unit_price").ToString, dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString)

            End While
            dr.Close()
            cn.Close()


        End If

    End Sub

    Private Sub DataGridViewCheckBoxColumn_Uncheck()

        For Each row As DataGridViewRow In DataGridView3.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells(6)
            cell.Value = False
        Next

    End Sub

    Private Sub txtQTY_TextChanged(sender As Object, e As EventArgs) Handles txtQTY.TextChanged

        Dim qty_1 As Double
        Dim unit_1 As Double
        Dim vat_1 As Double
        Dim total_vatable As Double
        Dim non_vat_1 As Double

        If txtQTY.Text = String.Empty Then

            txtTOTALVAT.Text = String.Empty
            txtTOTALVAT.Text = ""

            txtGRANDTOTAL.Text = String.Empty
            txtGRANDTOTAL.Text = ""

        Else

            qty_1 = txtQTY.Text
            unit_1 = txtUNITPRICE.Text

            vat_1 = (qty_1 * unit_1) * 0.12

            non_vat_1 = (qty_1 * unit_1)

            total_vatable = non_vat_1 * 1.12

            If txtVATAMOUNT.Text = String.Empty Then

                txtTOTALVAT.Text = CDbl("0").ToString("#,##0.00")
                txtGRANDTOTAL.Text = CDbl(non_vat_1).ToString("#,##0.00")

                txtNONVATTOTAL.Text = CDbl(non_vat_1).ToString("#,##0.00")

            Else

                txtTOTALVAT.Text = CDbl(vat_1).ToString("#,##0.00")
                txtGRANDTOTAL.Text = CDbl(total_vatable).ToString("#,##0.00")

                txtNONVATTOTAL.Text = CDbl(non_vat_1).ToString("#,##0.00")

            End If

        End If

        txtQTYLESS.Text = txtQTYTOTAL.Text - txtQTY.Text

    End Sub

    Private Sub txtQTYLOOSE_TextChanged(sender As Object, e As EventArgs) Handles txtQTYLOOSE.TextChanged

        Dim QTY_TOTAL As Integer

        Dim QTY_CASE As Integer
        Dim QTY_PERCASE As Integer
        Dim QTY_LOOSE As Integer

        If txtQTYLOOSE.Text = String.Empty Then

            QTY_LOOSE = 0

        Else

            QTY_LOOSE = txtQTYLOOSE.Text

        End If

        '=========================================

        If txtQTYCASE.Text = String.Empty Then

            QTY_CASE = 0

        Else

            QTY_CASE = txtQTYCASE.Text

        End If

        '=========================================

        If txtQTYPERCASE.Text = String.Empty Then

            QTY_PERCASE = 0

        Else

            QTY_PERCASE = txtQTYPERCASE.Text

        End If

        '=========================================

        QTY_TOTAL = QTY_CASE * QTY_PERCASE

        txtQTY.Text = QTY_TOTAL + QTY_LOOSE


    End Sub


    Private Sub txtQTYCASE_TextChanged(sender As Object, e As EventArgs) Handles txtQTYCASE.TextChanged

        Dim QTY_TOTAL As Integer

        Dim QTY_CASE As Integer
        Dim QTY_PERCASE As Integer
        Dim QTY_LOOSE As Integer

        If txtQTYLOOSE.Text = String.Empty Then

            QTY_LOOSE = 0

        Else

            QTY_LOOSE = txtQTYLOOSE.Text

        End If

        '=========================================

        If txtQTYCASE.Text = String.Empty Then

            QTY_CASE = 0

        Else

            QTY_CASE = txtQTYCASE.Text

        End If

        '=========================================

        If txtQTYPERCASE.Text = String.Empty Then

            QTY_PERCASE = 0

        Else

            QTY_PERCASE = txtQTYPERCASE.Text

        End If

        '=========================================

        QTY_TOTAL = QTY_CASE * QTY_PERCASE

        txtQTY.Text = QTY_TOTAL + QTY_LOOSE

    End Sub

    Private Sub txtQTYPERCASE_TextChanged(sender As Object, e As EventArgs) Handles txtQTYPERCASE.TextChanged

        Dim QTY_TOTAL As Integer

        Dim QTY_CASE As Integer
        Dim QTY_PERCASE As Integer
        Dim QTY_LOOSE As Integer

        If txtQTYLOOSE.Text = String.Empty Then

            QTY_LOOSE = 0

        Else

            QTY_LOOSE = txtQTYLOOSE.Text

        End If

        '=========================================

        If txtQTYCASE.Text = String.Empty Then

            QTY_CASE = 0

        Else

            QTY_CASE = txtQTYCASE.Text

        End If

        '=========================================

        If txtQTYPERCASE.Text = String.Empty Then

            QTY_PERCASE = 0

        Else

            QTY_PERCASE = txtQTYPERCASE.Text

        End If

        '=========================================

        QTY_TOTAL = QTY_CASE * QTY_PERCASE

        txtQTY.Text = QTY_TOTAL + QTY_LOOSE

    End Sub

    Sub SHOW_CODE()

        cn.Open()
        cm = New MySqlCommand("select * from tblitem WHERE `itemname` like '" & txtITEMNAME.Text & "'", cn)

        dr = cm.ExecuteReader

        While dr.Read

            txtCODE.Text = dr("itemcode").ToString()

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtITEMNAME_TextChanged(sender As Object, e As EventArgs) Handles txtITEMNAME.TextChanged

        If txtITEMNAME.Text = String.Empty Then

            Exit Sub

        Else

            SHOW_CODE()

        End If

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If txtITEMNAME.Text = String.Empty Or txtQTY.Text = String.Empty Then
            MsgBox("Please Complete data!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        If txtQTYLESS.Text < 0 Then
            MsgBox("Please Enter Valid Qty!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        If txtQTYLOOSE.Text = String.Empty Then
            txtQTYLOOSE.Text = 0
        End If

        If txtQTYCASE.Text = String.Empty Then
            txtQTYCASE.Text = 0
        End If

        If txtQTYPERCASE.Text = String.Empty Then
            txtQTYPERCASE.Text = 0
        End If


        For i As Integer = 0 To dataGridView1.Rows.Count - 1

            If txtCODE.Text = dataGridView1.Rows(i).Cells(0).Value.ToString() Then

                MsgBox("No Duplication!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return

            End If

        Next

        '=========================================================================================

        Try

            dataGridView1.Rows.Add(txtCODE.Text, txtITEMNAME.Text, txtUNIT.Text, txtQTYLOOSE.Text, txtQTYCASE.Text, txtQTYPERCASE.Text, txtQTY.Text, CDbl(txtUNITPRICE.Text).ToString("#,##0.00"), CDbl(txtTOTALVAT.Text).ToString("#,##0.00"), CDbl(txtGRANDTOTAL.Text).ToString("#,##0.00"), CDbl(txtNONVATTOTAL.Text).ToString("#,##0.00"), txtSTAT.Text, txtQTYLESS.Text)

            '=========================================================================================

            PASS_DATA()

            '=========================================================================================

            GET_SUM()

            txtCODE.Text = ""
            txtITEMNAME.Text = ""
            txtUNIT.Text = ""
            txtQTYLOOSE.Text = ""
            txtQTYCASE.Text = ""
            txtQTYPERCASE.Text = ""
            txtQTY.Text = ""

            txtQTYTOTAL.Text = String.Empty
            txtQTYLESS.Text = String.Empty
            txtSTAT.Text = String.Empty
            txtVATAMOUNT.Text = String.Empty

            txtUNITPRICE.Text = String.Empty
            txtTOTALVAT.Text = String.Empty
            txtGRANDTOTAL.Text = String.Empty
            txtNONVATTOTAL.Text = String.Empty

            btnSAVE.Enabled = True

        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString())
        End Try

    End Sub

    Private Sub txtQTYLESS_TextChanged(sender As Object, e As EventArgs) Handles txtQTYLESS.TextChanged

        If txtQTYLESS.Text = 0 Then

            txtSTAT.Text = "FULLY DELIVERED"

        Else

            txtSTAT.Text = "PARTIAL"

        End If

    End Sub

    Private Sub dataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles dataGridView1.CurrentCellChanged

        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        dataGridView1.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub


    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Try

            If dataGridView1.Columns(e.ColumnIndex).Name = "EDIT" Then

                Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)

                txtITEMNAME.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                txtUNIT.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                txtQTYLOOSE.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                txtQTYCASE.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                txtQTYPERCASE.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString

                txtUNITPRICE.Text = dataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString

                txtVATAMOUNT.Text = dataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString


            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "UPDATE" Then

                Dim update As DataGridViewRow = dataGridView1.SelectedRows(0)

                update.Cells(0).Value = txtCODE.Text
                update.Cells(1).Value = txtITEMNAME.Text
                update.Cells(2).Value = txtUNIT.Text
                update.Cells(3).Value = txtQTYLOOSE.Text
                update.Cells(4).Value = txtQTYCASE.Text
                update.Cells(5).Value = txtQTYPERCASE.Text
                update.Cells(6).Value = txtQTY.Text

                update.Cells(7).Value = txtUNITPRICE.Text
                update.Cells(8).Value = txtTOTALVAT.Text
                update.Cells(9).Value = txtGRANDTOTAL.Text
                update.Cells(10).Value = txtNONVATTOTAL.Text
                update.Cells(11).Value = txtSTAT.Text
                update.Cells(12).Value = txtQTYLESS.Text


                GET_SUM()

                txtCODE.Text = ""
                txtITEMNAME.Text = ""
                txtUNIT.Text = ""
                txtQTYLOOSE.Text = ""
                txtQTYCASE.Text = ""
                txtQTYPERCASE.Text = ""
                txtQTY.Text = ""

                txtQTYTOTAL.Text = String.Empty
                txtQTYLESS.Text = String.Empty
                txtSTAT.Text = String.Empty
                txtVATAMOUNT.Text = String.Empty

                txtUNITPRICE.Text = String.Empty
                txtTOTALVAT.Text = String.Empty
                txtGRANDTOTAL.Text = String.Empty
                txtNONVATTOTAL.Text = String.Empty


            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "DELETE" Then

                Try

                    If MsgBox("Do you want to Delete ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows(0).Index)

                        GET_SUM()

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, vbCritical)

                End Try

            End If

        Catch ex As Exception
            'MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Sub GET_SUM()

        Dim TOTALPRICE As Decimal = 0

        For i = 0 To dataGridView1.Rows.Count - 1
            TOTALPRICE += dataGridView1.Rows(i).Cells(12).Value
        Next

        txtTOTAL.Text = TOTALPRICE

    End Sub

    Private Sub txtTOTAL_TextChanged(sender As Object, e As EventArgs) Handles txtTOTAL.TextChanged

        If txtTOTAL.Text = 0 Then

            txtSTATUS.Text = "FULLY DELIVERED"

        Else

            txtSTATUS.Text = "PARTIALLY DELIVERED"

        End If

    End Sub


    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If dataGridView1.CurrentCell Is Nothing Then

            MsgBox("Please Entry Data!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If txtSUBREFERENCE.Text = "" Or txtREFERENCE.Text = "" Then

            MsgBox("Please input SI & DR!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("INSERT into tbl_warehouse_rr (reference_no, employee_name, date, supplier_name, purpose, sub_reference, reference, date_received, delivery_status, warehouse, supervisor_name, supervisor_approval, supervisor_comment, final_name, final_approval, final_comment, date_time, status) values(@reference_no, @employee_name, @date, @supplier_name, @purpose, @sub_reference, @reference, @date_received, @delivery_status, @warehouse, @supervisor_name, @supervisor_approval, @supervisor_comment, @final_name, @final_approval, @final_comment, @date_time, @status)", cn)
            With cm.Parameters

                .AddWithValue("@reference_no", txtPONO.Text)
                .AddWithValue("@employee_name", txtNAME.Text)
                .AddWithValue("@date", txtDATE.Text)
                .AddWithValue("@supplier_name", txtSUPPLIERNAME.Text)
                .AddWithValue("@purpose", txtPURPOSE.Text)
                .AddWithValue("@sub_reference", txtSUBREFERENCE.Text)
                .AddWithValue("@reference", txtREFERENCE.Text)

                .AddWithValue("@date_received", txtRECEIVEDDATE.Text)
                .AddWithValue("@delivery_status", txtSTATUS.Text)
                .AddWithValue("@warehouse", txtWAREHOUSE.Text)

                .AddWithValue("@supervisor_name", " ")
                .AddWithValue("@supervisor_approval", "FOR APPROVAL")
                .AddWithValue("@supervisor_comment", " ")

                .AddWithValue("@final_name", " ")
                .AddWithValue("@final_approval", "FOR APPROVAL")
                .AddWithValue("@final_comment", " ")

                .AddWithValue("@date_time", DateTimePicker1.Value)
                .AddWithValue("@status", "ACTIVE")

            End With
            cm.ExecuteNonQuery()
            cn.Close()

            DisplayRRNO()
            SaveInRRList()
            SaveInRRListTOP()

            RR_UPDATE()
            LoadIPRList()

            btnSAVE.Enabled = False
            Button3.Enabled = False
            btnPRINT.Enabled = True

            dataGridView1.Enabled = False

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Sub RR_UPDATE()


        If txtSTATUS.Text = "PARTIALLY DELIVERED" Then

            Exit Sub

        ElseIf txtSTATUS.Text = "FULLY DELIVERED" Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_warehouse_mir set status=@status where ipr_no=@ipr_no", cn)

            With cm.Parameters

                .AddWithValue("@ipr_no", txtPONO.Text)
                .AddWithValue("@status", "FULLY DELIVERED")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        End If

    End Sub

    Sub DisplayRRNO()

        cn.Open()
        adp = New MySqlDataAdapter("select * from tbl_warehouse_rr where `reference_no` = '" & txtPONO.Text & "' ORDER BY id DESC LIMIT 1", cn)
        dt = New DataTable
        adp.Fill(dt)

        txtCONTROL.Text = dt.Rows(0)(1).ToString()

        cn.Close()

    End Sub

    Sub SaveInRRList()

        For Each row As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tbl_warehouse_rr_item (rr_no, reference_no, itemcode, itemname, qty_loose, qty_case_bulk, per_case_bulk, total_quantity, unit, unit_price, vat_amount, grand_total, nonvat_total, remaining, status) values(@rr_no, @reference_no, @itemcode, @itemname, @qty_loose, @qty_case_bulk, @per_case_bulk, @total_quantity, @unit, @unit_price, @vat_amount, @grand_total, @nonvat_total, @remaining, @status)", cn)
            With cm.Parameters

                .AddWithValue("@rr_no", txtCONTROL.Text)
                .AddWithValue("@reference_no", txtPONO.Text)

                .AddWithValue("@itemcode", row.Cells("ITEM_CODE").Value)
                .AddWithValue("@itemname", row.Cells("ITEM_DESC").Value)
                .AddWithValue("@qty_loose", row.Cells("QTY_LOOSE").Value)
                .AddWithValue("@qty_case_bulk", row.Cells("QTY_CASE_BULK").Value)
                .AddWithValue("@per_case_bulk", row.Cells("PER_CASE_BULK").Value)
                .AddWithValue("@total_quantity", row.Cells("TOTAL_QTY").Value)
                .AddWithValue("@unit", row.Cells("UOM").Value)
                .AddWithValue("@unit_price", row.Cells("UNITPRICE").Value)
                .AddWithValue("@vat_amount", row.Cells("VAT").Value)
                .AddWithValue("@grand_total", row.Cells("GRAND_TOTAL").Value)
                .AddWithValue("@nonvat_total", row.Cells("TOTAL_NONVAT").Value)
                .AddWithValue("@remaining", row.Cells("REMAINING").Value)
                .AddWithValue("@status", row.Cells("STATUS").Value)

            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
        Next

    End Sub

    Sub SaveInRRListTOP()

        For Each row As DataGridViewRow In DataGridView3.Rows

            cm = New MySqlCommand("INSERT into tbl_warehouse_rr_item (rr_no, reference_no, itemcode, itemname, qty_loose, qty_case_bulk, per_case_bulk, total_quantity, unit, unit_price, vat_amount, grand_total, nonvat_total, remaining, status) values(@rr_no, @reference_no, @itemcode, @itemname, @qty_loose, @qty_case_bulk, @per_case_bulk, @total_quantity, @unit, @unit_price, @vat_amount, @grand_total, @nonvat_total, @remaining, @status)", cn)
            With cm.Parameters

                .AddWithValue("@rr_no", txtCONTROL.Text)
                .AddWithValue("@reference_no", txtPONO.Text)

                .AddWithValue("@itemcode", row.Cells("ITEMCODE").Value)
                .AddWithValue("@itemname", row.Cells("ITEMDESC").Value)

                .AddWithValue("@qty_loose", " ")
                .AddWithValue("@qty_case_bulk", " ")
                .AddWithValue("@per_case_bulk", " ")
                .AddWithValue("@total_quantity", " ")

                .AddWithValue("@unit", row.Cells("UNIT").Value)
                .AddWithValue("@unit_price", row.Cells("UNIT_PRICE").Value)
                .AddWithValue("@vat_amount", row.Cells("VAT_AMOUNT").Value)
                .AddWithValue("@grand_total", row.Cells("GRAND_TOTAL").Value)
                .AddWithValue("@nonvat_total", " ")


                .AddWithValue("@remaining", row.Cells("QUANTITY").Value)
                .AddWithValue("@status", "PARTIAL")

            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
        Next

        MsgBox("Receiving Report has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

    End Sub

    Sub SHOW_RR_REFERENCE()

        If txtPONO.Text = String.Empty Then

            LoadItemList()

        Else

            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_rr WHERE `reference_no` like '" & txtPONO.Text & "' ORDER BY id DESC LIMIT 1", cn)

            dr = cm.ExecuteReader

            While dr.Read

                txtRR_REFERENCE.Text = dr("rr_no").ToString()

            End While

            dr.Close()
            cn.Close()

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim rowindex As String
        Dim found As Boolean = False
        For Each row As DataGridViewRow In DataGridView3.Rows
            If row.Cells.Item("ITEM_NAME").Value = txtSEARCH.Text Then
                rowindex = row.Index.ToString()
                found = True
                Dim actie As String = row.Cells("QUANTITY").Value.ToString()
                MsgBox(actie)
                Exit For
            End If
        Next
        If Not found Then
            MsgBox("Item not found")
        End If

    End Sub

    Sub PASS_DATA()

        If (DataGridView3.Rows.Count - 0) Then

            DataGridView4.Rows.Add(DataGridView3.SelectedRows(0).Cells.Cast(Of DataGridViewCell).Select(Function(A) A.Value).ToArray)
            DataGridView3.Rows.Remove(DataGridView3.SelectedRows(0))

        End If

    End Sub


    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

        Dim cell As DataGridViewCheckBoxCell = DataGridView3.Rows(e.RowIndex).Cells(6)

        DataGridViewCheckBoxColumn_Uncheck()
        cell.Value = True

        txtQTYTOTAL.Text = DataGridView3.CurrentRow.Cells(0).Value

        txtUNIT.Text = DataGridView3.CurrentRow.Cells(1).Value
        txtITEMNAME.Text = DataGridView3.CurrentRow.Cells(2).Value

        txtUNITPRICE.Text = 0 'DataGridView3.CurrentRow.Cells(3).Value
        txtVATAMOUNT.Text = 0 'DataGridView3.CurrentRow.Cells(4).Value

    End Sub

End Class