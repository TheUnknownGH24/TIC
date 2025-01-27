Public Class frmWAREHOUSE_RR_RETURN

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Private Sub DataGridView2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs)

        DataGridView2.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

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

    Private Sub dataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles dataGridView1.CurrentCellChanged

        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        dataGridView1.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Sub LoadItemList()


        If txtRR_REFERENCE.Text = String.Empty Or txtRR_REFERENCE.Text = "" Then

            DataGridView3.Rows.Clear()
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedorderlist where `po_no` like '" & txtPONO.Text & "' and supplier_name like '" & txtSUPPLIERNAME.Text & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read
                DataGridView3.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, dr.Item("unit_price").ToString, dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString)

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

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

        Dim cell As DataGridViewCheckBoxCell = DataGridView3.Rows(e.RowIndex).Cells(6)

        DataGridViewCheckBoxColumn_Uncheck()
        cell.Value = True

        txtQTYTOTAL.Text = DataGridView3.CurrentRow.Cells(0).Value

        txtUNIT.Text = DataGridView3.CurrentRow.Cells(1).Value
        txtITEMNAME.Text = DataGridView3.CurrentRow.Cells(2).Value

        txtUNITPRICE.Text = DataGridView3.CurrentRow.Cells(3).Value
        txtVATAMOUNT.Text = DataGridView3.CurrentRow.Cells(4).Value

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
            cm = New MySqlCommand("Update tbl_warehouse_rr set sub_reference=@sub_reference, reference=@reference, date_received=@date_received, delivery_status=@delivery_status, warehouse=@warehouse, status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)
                .AddWithValue("@sub_reference", txtSUBREFERENCE.Text)
                .AddWithValue("@reference", txtREFERENCE.Text)

                .AddWithValue("@date_received", txtRECEIVEDDATE.Text)
                .AddWithValue("@delivery_status", txtSTATUS.Text)
                .AddWithValue("@warehouse", txtWAREHOUSE.Text)

                .AddWithValue("@status", "ACTIVE")

            End With
            cm.ExecuteNonQuery()
            cn.Close()

            DeleteInRRList()
            SaveInRRList()

            LoadRRList()

            btnSAVE.Enabled = False
            Button3.Enabled = False
            btnPRINT.Enabled = True

            dataGridView1.Enabled = False

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Sub DeleteInRRList()

        cm = New MySqlCommand("DELETE FROM tbl_warehouse_rr_item WHERE `rr_no` like '" & txtCONTROL.Text & "'", cn)

        cn.Open()
        cm.ExecuteNonQuery()
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

                .AddWithValue("@itemcode", row.Cells("ITEM_CODE").Value)
                .AddWithValue("@itemname", row.Cells("ITEM_DESC").Value)

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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If txtTYPE.Text = "ADMINISTRATOR" Or txtPOSITION.Text = "MANAGER" Or txtPOSITION.Text = "SUPERVISOR" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_rr where rr_no like '%" & TextBox1.Text & "%' AND status` like 'RETURNED'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("rr_no").ToString, dr.Item("reference_no").ToString, dr.Item("employee_name").ToString, dr.Item("date").ToString, dr.Item("supplier_name").ToString, dr.Item("purpose").ToString, dr.Item("sub_reference").ToString, dr.Item("reference").ToString, dr.Item("date_received").ToString, dr.Item("delivery_status").ToString, dr.Item("warehouse").ToString, dr.Item("supervisor_name").ToString, dr.Item("supervisor_approval").ToString, dr.Item("supervisor_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString)

            End While

            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_rr where rr_no like '%" & TextBox1.Text & "%' and `warehouse` like '%" & txtWAREHOUSENAME.Text & "%' AND status` like 'RETURNED'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("rr_no").ToString, dr.Item("reference_no").ToString, dr.Item("employee_name").ToString, dr.Item("date").ToString, dr.Item("supplier_name").ToString, dr.Item("purpose").ToString, dr.Item("sub_reference").ToString, dr.Item("reference").ToString, dr.Item("date_received").ToString, dr.Item("delivery_status").ToString, dr.Item("warehouse").ToString, dr.Item("supervisor_name").ToString, dr.Item("supervisor_approval").ToString, dr.Item("supervisor_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString)

            End While

            dr.Close()
            cn.Close()

        End If

    End Sub

    Sub LoadRRList()

        If txtTYPE.Text = "ADMINISTRATOR" Or txtPOSITION.Text = "MANAGER" Or txtPOSITION.Text = "SUPERVISOR" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_rr WHERE `status` like 'RETURNED'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("rr_no").ToString, dr.Item("reference_no").ToString, dr.Item("employee_name").ToString, dr.Item("date").ToString, dr.Item("supplier_name").ToString, dr.Item("purpose").ToString, dr.Item("sub_reference").ToString, dr.Item("reference").ToString, dr.Item("date_received").ToString, dr.Item("delivery_status").ToString, dr.Item("warehouse").ToString, dr.Item("supervisor_name").ToString, dr.Item("supervisor_approval").ToString, dr.Item("supervisor_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString)

            End While

            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_rr where `warehouse` like '%" & txtWAREHOUSENAME.Text & "%' AND status` like 'RETURNED'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("rr_no").ToString, dr.Item("reference_no").ToString, dr.Item("employee_name").ToString, dr.Item("date").ToString, dr.Item("supplier_name").ToString, dr.Item("purpose").ToString, dr.Item("sub_reference").ToString, dr.Item("reference").ToString, dr.Item("date_received").ToString, dr.Item("delivery_status").ToString, dr.Item("warehouse").ToString, dr.Item("supervisor_name").ToString, dr.Item("supervisor_approval").ToString, dr.Item("supervisor_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString)

            End While

            dr.Close()
            cn.Close()

        End If

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
        DataGridView2.Columns.Insert(20, colApproval)

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        dataGridView1.Rows.Clear()
        txtSUPERVISORCOMMENT.Text = ""
        txtSUPERVISORCOMMENT.Text = String.Empty

        txtMANAGERCOMMENT.Text = ""
        txtMANAGERCOMMENT.Text = String.Empty

        Dim colname As String = DataGridView2.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_rr where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString
                txtCONTROL.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
                txtPONO.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value.ToString

                txtDATE.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value.ToString
                txtSUPPLIERNAME.Text = DataGridView2.Rows(e.RowIndex).Cells(6).Value.ToString
                txtPURPOSE.Text = DataGridView2.Rows(e.RowIndex).Cells(7).Value.ToString

                txtSUBREFERENCE.Text = DataGridView2.Rows(e.RowIndex).Cells(8).Value.ToString
                txtREFERENCE.Text = DataGridView2.Rows(e.RowIndex).Cells(9).Value.ToString
                txtRECEIVEDDATE.Text = DataGridView2.Rows(e.RowIndex).Cells(10).Value.ToString

                txtSTATUS.Text = DataGridView2.Rows(e.RowIndex).Cells(11).Value.ToString
                txtWAREHOUSE.Text = DataGridView2.Rows(e.RowIndex).Cells(12).Value.ToString

                txtSUPERVISORCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(13).Value.ToString & " - " & DataGridView2.Rows(e.RowIndex).Cells(15).Value.ToString

                txtMANAGERCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(16).Value.ToString & " - " & DataGridView2.Rows(e.RowIndex).Cells(18).Value.ToString

            End While
            dr.Close()
            cn.Close()

            LoadItemList()
            LoadRRITEMLIST()

            btnSAVE.Enabled = True
            btnPRINT.Enabled = True

        End If

    End Sub

    Sub LoadRRITEMLIST()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_rr_item where `rr_no` like '" & txtCONTROL.Text & "' ", cn)
        dr = cm.ExecuteReader

        While dr.Read

            dataGridView1.Rows.Add(dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("unit").ToString, dr.Item("qty_loose").ToString, dr.Item("qty_case_bulk").ToString, dr.Item("per_case_bulk").ToString, dr.Item("total_quantity").ToString, dr.Item("unit_price").ToString, dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString, dr.Item("nonvat_total").ToString, dr.Item("status").ToString, dr.Item("remaining").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtPONO_TextChanged(sender As Object, e As EventArgs) Handles txtPONO.TextChanged

        Dim text1 As String = txtPONO.Text
        Dim index1 As Integer = text1.IndexOfAny("_")

        If index1 > -1 Then
            Dim firstLetter As Char = text1(index1 - 3)
            txtCODE1.Text = firstLetter
        End If

        '==================================================

        Dim text2 As String = txtPONO.Text
        Dim index2 As Integer = text2.IndexOfAny("_")

        If index2 > -1 Then
            Dim secondLetter As Char = text2(index2 - 2)
            txtCODE2.Text = secondLetter
        End If

        '==================================================

        Dim text3 As String = txtPONO.Text
        Dim index3 As Integer = text2.IndexOfAny("_")

        If index3 > -1 Then
            Dim thirdLetter As Char = text3(index3 - 1)
            txtCODE3.Text = thirdLetter
        End If

        '==================================================

        txtFINALCODE.Text = txtCODE1.Text & txtCODE2.Text & txtCODE3.Text

    End Sub


    Private Sub btnPRINT_Click(sender As Object, e As EventArgs) Handles btnPRINT.Click

        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.Document.DefaultPageSettings.Landscape = True
        PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize = New Printing.PaperSize("Custom", 850, 1100)
        PrintPreviewDialog1.ShowDialog()

    End Sub


    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim header As New Font("Arial Black", 12, FontStyle.Regular)
        Dim f8b As New Font("Verdana", 8, FontStyle.Regular)

        Dim left As New StringFormat
        Dim center As New StringFormat
        Dim right As New StringFormat

        left.Alignment = StringAlignment.Near
        center.Alignment = StringAlignment.Center
        right.Alignment = StringAlignment.Far

        Dim rect1 As New Rectangle(50, 80, 1000, 25)

        Dim brush As SolidBrush = New SolidBrush(Color.Black)
        e.Graphics.FillRectangle(brush, rect1)

        e.Graphics.DrawRectangle(Pens.Black, rect1)

        If txtFINALCODE.Text = "8SI" Then

            e.Graphics.DrawImage(Me.Picture_8si.Image, 440, 30, Picture_8si.Width - 15, Picture_8si.Height - 25)

        ElseIf txtFINALCODE.Text = "TIC" Then

            e.Graphics.DrawImage(Me.Picture_tic.Image, 440, 30, Picture_tic.Width - 15, Picture_tic.Height - 25)

        Else

            e.Graphics.DrawImage(Me.Picture_8si.Image, 300, 30, Picture_8si.Width - 15, Picture_8si.Height - 25)
            e.Graphics.DrawImage(Me.Picture_tic.Image, 600, 30, Picture_tic.Width - 15, Picture_tic.Height - 25)

        End If

        e.Graphics.DrawString("RECEIVING REPORT", header, Brushes.White, rect1, center)

        '================================================================================

        Dim title As New Font("Arial Black", 8, FontStyle.Bold)
        Dim control As New Font("Arial", 8, FontStyle.Regular)
        Dim sign As New Font("CAMBRIA", 8, FontStyle.Bold)
        Dim sign11 As New Font("Arial Black", 8, FontStyle.Underline)
        Dim name As New Font("CAMBRIA", 8, FontStyle.Underline)
        Dim label As New Font("CAMBRIA", 8, FontStyle.Italic)
        Dim data As New Font("CAMBRIA", 10, FontStyle.Bold)

        Dim line As New Font("CAMBRIA", 10, FontStyle.Bold)
        Dim lin2 As New Font("CAMBRIA", 8, FontStyle.Bold)
        Dim lin3 As New Font("CAMBRIA", 8, FontStyle.Bold)

        Dim lineerror As New Font("CAMBRIA", 8, FontStyle.Strikeout)


        e.Graphics.DrawString("RECEIVING REPORT#", sign, Brushes.Black, 530, 120)
        e.Graphics.DrawString("DATE", sign, Brushes.Black, 530, 160)
        e.Graphics.DrawString("DELIVERY STATUS", sign, Brushes.Black, 530, 180)
        e.Graphics.DrawString("DATE RECEIVED", sign, Brushes.Black, 530, 200)
        e.Graphics.DrawString("WAREHOUSE", sign, Brushes.Black, 530, 220)

        e.Graphics.DrawString("PURPOSE", sign, Brushes.Black, 50, 120)
        e.Graphics.DrawString("SUPPLIER NAME", sign, Brushes.Black, 50, 140)
        e.Graphics.DrawString("PO#", sign, Brushes.Black, 50, 160)
        e.Graphics.DrawString("REFERENCE/SI", sign, Brushes.Black, 50, 180)
        e.Graphics.DrawString("SUB-REFERENCE/DR", sign, Brushes.Black, 50, 200)

        e.Graphics.DrawString(":", title, Brushes.Black, 690, 120)
        e.Graphics.DrawString(":", title, Brushes.Black, 690, 160)
        e.Graphics.DrawString(":", title, Brushes.Black, 690, 180)
        e.Graphics.DrawString(":", title, Brushes.Black, 690, 200)
        e.Graphics.DrawString(":", title, Brushes.Black, 690, 220)

        e.Graphics.DrawString(":", title, Brushes.Black, 200, 120)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 140)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 160)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 180)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 200)

        e.Graphics.DrawString(txtCONTROL.Text, title, Brushes.Black, 700, 118)
        e.Graphics.DrawString(txtDATE.Text, title, Brushes.Black, 700, 160)
        e.Graphics.DrawString(txtSTATUS.Text, title, Brushes.Black, 700, 180)
        e.Graphics.DrawString(txtRECEIVEDDATE.Text, title, Brushes.Black, 700, 200)
        e.Graphics.DrawString(txtWAREHOUSE.Text, title, Brushes.Black, 700, 220)

        e.Graphics.DrawString(txtPURPOSE.Text, title, Brushes.Black, 230, 120)
        e.Graphics.DrawString(txtSUPPLIERNAME.Text, title, Brushes.Black, 230, 140)
        e.Graphics.DrawString(txtREFERENCE.Text, title, Brushes.Black, 230, 160)
        e.Graphics.DrawString(txtSUBREFERENCE.Text, title, Brushes.Black, 230, 180)

        '================================================================================
        '================================================================================

        Dim title1 As New Rectangle(50, 250, 500, 14)
        Dim title2 As New Rectangle(550, 250, 100, 14)
        Dim title3 As New Rectangle(650, 250, 100, 14)
        Dim title4 As New Rectangle(750, 250, 100, 14)
        Dim title5 As New Rectangle(850, 250, 100, 14)
        Dim title6 As New Rectangle(950, 250, 100, 14)

        Dim brushtotal3 As SolidBrush = New SolidBrush(Color.Black)
        e.Graphics.FillRectangle(brushtotal3, title1)
        e.Graphics.FillRectangle(brushtotal3, title2)
        e.Graphics.FillRectangle(brushtotal3, title3)
        e.Graphics.FillRectangle(brushtotal3, title4)
        e.Graphics.FillRectangle(brushtotal3, title5)
        e.Graphics.FillRectangle(brushtotal3, title6)

        e.Graphics.DrawRectangle(Pens.White, title1)
        e.Graphics.DrawRectangle(Pens.White, title2)
        e.Graphics.DrawRectangle(Pens.White, title3)
        e.Graphics.DrawRectangle(Pens.White, title4)
        e.Graphics.DrawRectangle(Pens.White, title5)
        e.Graphics.DrawRectangle(Pens.White, title6)

        e.Graphics.DrawString("ITEM DESCRIPTION", lin2, Brushes.White, title1, center)
        e.Graphics.DrawString("UOM", lin2, Brushes.White, title2, center)
        e.Graphics.DrawString("QTY LOOSE", lin2, Brushes.White, title3, center)
        e.Graphics.DrawString("# OF CASE", lin2, Brushes.White, title4, center)
        e.Graphics.DrawString("QTY PER CASE", lin2, Brushes.White, title5, center)
        e.Graphics.DrawString("TOTAL QTY", lin2, Brushes.White, title6, center)

        '================================================================================

        Dim d As Integer = 250

        For i = 0 To dataGridView1.Rows.Count - 1

            d += 18

            Dim data0 As New Rectangle(50, d, 500, 14)
            Dim data1 As New Rectangle(550, d, 100, 14)
            Dim data2 As New Rectangle(650, d, 100, 14)
            Dim data3 As New Rectangle(750, d, 100, 14)
            Dim data4 As New Rectangle(850, d, 100, 14)
            Dim data5 As New Rectangle(950, d, 100, 14)

            Dim databrush As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(databrush, data0)
            e.Graphics.FillRectangle(databrush, data1)
            e.Graphics.FillRectangle(databrush, data2)
            e.Graphics.FillRectangle(databrush, data3)
            e.Graphics.FillRectangle(databrush, data4)
            e.Graphics.FillRectangle(databrush, data5)

            e.Graphics.DrawRectangle(Pens.Black, data0)
            e.Graphics.DrawRectangle(Pens.Black, data1)
            e.Graphics.DrawRectangle(Pens.Black, data2)
            e.Graphics.DrawRectangle(Pens.Black, data3)
            e.Graphics.DrawRectangle(Pens.Black, data4)
            e.Graphics.DrawRectangle(Pens.Black, data5)

            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(1).Value, lin2, Brushes.Black, data0, left)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(2).Value, lin2, Brushes.Black, data1, center)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(3).Value, lin2, Brushes.Black, data2, center)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(4).Value, lin2, Brushes.Black, data3, center)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(5).Value, lin2, Brushes.Black, data4, center)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(6).Value, lin2, Brushes.Black, data5, center)

            '================================================================================

            Dim p As Integer = 700

            p += 18

            Dim label1 As New Rectangle(50, p, 334, 20)
            Dim label2 As New Rectangle(384, p, 334, 20)
            Dim label3 As New Rectangle(718, p, 334, 20)

            Dim brush6 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush6, label1)
            e.Graphics.FillRectangle(brush6, label2)
            e.Graphics.FillRectangle(brush6, label3)

            e.Graphics.DrawRectangle(Pens.White, label1)
            e.Graphics.DrawRectangle(Pens.White, label2)
            e.Graphics.DrawRectangle(Pens.White, label3)

            e.Graphics.DrawString("PREPARED BY:", sign, Brushes.Black, label1, left)
            e.Graphics.DrawString("CHECKED BY:", sign, Brushes.Black, label2, left)
            e.Graphics.DrawString("RECOMMENDED BY:", sign, Brushes.Black, label3, left)

            '=============================================================================

            Dim s As Integer = 740

            s += 18

            Dim sign1 As New Rectangle(50, s, 334, 20)
            Dim sign2 As New Rectangle(384, s, 334, 20)
            Dim sign3 As New Rectangle(718, s, 334, 20)

            Dim brush7 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush7, sign1)
            e.Graphics.FillRectangle(brush7, sign2)
            e.Graphics.FillRectangle(brush7, sign3)

            e.Graphics.DrawRectangle(Pens.White, sign1)
            e.Graphics.DrawRectangle(Pens.White, sign2)
            e.Graphics.DrawRectangle(Pens.White, sign3)

            e.Graphics.DrawString(txtNAME.Text, sign11, Brushes.Black, sign1, left)
            e.Graphics.DrawString("______________________________", sign11, Brushes.Black, sign2, left)
            e.Graphics.DrawString("______________________________", sign11, Brushes.Black, sign3, left)

            '=============================================================================

            Dim l As Integer = 760

            l += 18

            Dim position1 As New Rectangle(50, l, 334, 20)
            Dim position2 As New Rectangle(384, l, 334, 20)
            Dim position3 As New Rectangle(718, l, 334, 20)

            Dim brush8 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush8, position1)
            e.Graphics.FillRectangle(brush8, position2)
            e.Graphics.FillRectangle(brush8, position3)

            e.Graphics.DrawRectangle(Pens.White, position1)
            e.Graphics.DrawRectangle(Pens.White, position2)
            e.Graphics.DrawRectangle(Pens.White, position3)

            e.Graphics.DrawString("SIGN & DATE", label, Brushes.Black, position1, left)
            e.Graphics.DrawString("WAREHOUSE SUPERVISOR", label, Brushes.Black, position2, left)
            e.Graphics.DrawString("WAREHOUSE MANAGER", label, Brushes.Black, position3, left)

        Next

    End Sub


End Class