Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmTIC_PO_COO_FORM

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try


    End Sub

    Private Sub txtCONTROL_TextChanged(sender As Object, e As EventArgs) Handles txtCONTROL.TextChanged

        txtREFERENCE.Text = txtCONTROL.Text

    End Sub

    Sub LoadItemList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_purchasedorderlist where `po_no` like '" & txtPONO.Text & "' and supplier_name like '" & txtSUPPLIER.Text & "'", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            dataGridView1.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, dr.Item("unit_price").ToString, dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Sub Supplier_sum()

        Dim TOTALUNIT_1 As Decimal = 0
        For i = 0 To dataGridView1.Rows.Count - 1
            TOTALUNIT_1 += dataGridView1.Rows(i).Cells(3).Value
        Next

        Dim VATTOTAL_1 As Decimal = 0
        For i = 0 To dataGridView1.Rows.Count - 1
            VATTOTAL_1 += dataGridView1.Rows(i).Cells(4).Value
        Next

        Dim GRANDTOTAL_1 As Decimal = 0
        For i = 0 To dataGridView1.Rows.Count - 1
            GRANDTOTAL_1 += dataGridView1.Rows(i).Cells(5).Value
        Next

        '=======================================================================

        txtTOTALUNIT_1.Text = CDbl(TOTALUNIT_1).ToString("#,##0.00")
        txtVATTOTAL_1.Text = CDbl(VATTOTAL_1).ToString("#,##0.00")
        txtGRANDTOTAL_1.Text = CDbl(GRANDTOTAL_1).ToString("#,##0.00")

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If txtSEARCHNAME.Text <> "" Then

            txtSEARCHNAME.Text = ""

        End If

        If txtSHIPPINGMETHOD.Text = "" Or txtPAYMENTTERMS.Text = "" Or txtDELIVERYADDRESS.Text = "" Then

            MsgBox("Please input all data!", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_tic_purchasedorder set required_date=@required_date, COO_APPROVAL=@COO_APPROVAL, coo_comment=@coo_comment where id=@id", cn)
                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@required_date", txtREQUIREDDATE.Text)

                    .AddWithValue("@COO_APPROVAL", "APPROVED")
                    .AddWithValue("@coo_comment", txtCOOCOMMENT.Text & " - " & DateTimePicker1.Value)

                End With
                cm.ExecuteNonQuery()
                cn.Close()
                DeleteInPOList()
                SaveInPOList()

                LoadPOList()

                MsgBox("Purchased Order has been Successfully Approved!", vbInformation + vbOKOnly, "CONFIRMATION")

            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        End If

    End Sub

    Sub DeleteInPOList()

        cm = New MySqlCommand("DELETE FROM tbl_tic_purchasedorderlist WHERE `po_no` like '" & txtPONO.Text & "'", cn)

        cn.Open()
        cm.ExecuteNonQuery()
        cn.Close()

    End Sub

    Sub SaveInPOList()

        For Each row_1 As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tbl_tic_purchasedorderlist (po_no, pr_no, supplier_name, delivery_address, quantity, unit, item_name, unit_price, vat_amount, grand_total) values(@po_no, @pr_no, @supplier_name, @delivery_address, @quantity, @unit, @item_name, @unit_price, @vat_amount, @grand_total)", cn)

            With cm.Parameters

                .AddWithValue("@po_no", txtPONO.Text)
                .AddWithValue("@pr_no", txtREFERENCE.Text)
                .AddWithValue("@supplier_name", txtSUPPLIER.Text)
                .AddWithValue("@delivery_address", txtDELIVERYADDRESS.Text)

                .AddWithValue("@quantity", row_1.Cells("QUANTITY").Value)
                .AddWithValue("@unit", row_1.Cells("UNIT").Value)
                .AddWithValue("@item_name", row_1.Cells("ITEM_NAME").Value)
                .AddWithValue("@unit_price", row_1.Cells("UNIT_PRICE").Value)
                .AddWithValue("@vat_amount", row_1.Cells("VAT_AMOUNT").Value)
                .AddWithValue("@grand_total", row_1.Cells("TOTAL_PRICE").Value)

            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
            btnSAVE.Enabled = False
            btnPRINT.Enabled = False
            btnRETURN.Enabled = False
        Next

    End Sub

    Private Sub btnPRINT_Click(sender As Object, e As EventArgs) Handles btnPRINT.Click

        If txtSEARCHNAME.Text <> "" Then

            txtSEARCHNAME.Text = ""

        End If

        If txtSHIPPINGMETHOD.Text = "" Or txtPAYMENTTERMS.Text = "" Or txtDELIVERYADDRESS.Text = "" Then

            MsgBox("Please input all data!", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_tic_purchasedorder set required_date=@required_date, COO_APPROVAL=@COO_APPROVAL, coo_comment=@coo_comment, status=@status where id=@id", cn)
                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@required_date", txtREQUIREDDATE.Text)

                    .AddWithValue("@COO_APPROVAL", "DISAPPROVED")
                    .AddWithValue("@coo_comment", txtCOOCOMMENT.Text & " - " & DateTimePicker1.Value)
                    .AddWithValue("@status", "DEACTIVE")
                End With
                cm.ExecuteNonQuery()
                cn.Close()
                DeleteInPOList()
                SaveInPOList()

                LoadPOList()

                MsgBox("Purchased Order has been Successfully Disapproved!", vbInformation + vbOKOnly, "CONFIRMATION")


            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRETURN.Click

        If txtSEARCHNAME.Text <> "" Then

            txtSEARCHNAME.Text = ""

        End If

        If txtSHIPPINGMETHOD.Text = "" Or txtPAYMENTTERMS.Text = "" Or txtDELIVERYADDRESS.Text = "" Then

            MsgBox("Please input all data!", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_tic_purchasedorder set required_date=@required_date, MANAGER_APPROVAL=@MANAGER_APPROVAL, manager_comment=@manager_comment, GM_APPROVAL=@GM_APPROVAL, gm_comment=@gm_comment, COO_APPROVAL=@COO_APPROVAL, coo_comment=@coo_comment, status=@status where id=@id", cn)
                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@required_date", txtREQUIREDDATE.Text)

                    .AddWithValue("@MANAGER_APPROVAL", "FOR APPROVAL")
                    .AddWithValue("@manager_comment", " ")

                    .AddWithValue("@GM_APPROVAL", "FOR APPROVAL")
                    .AddWithValue("@gm_comment", " ")

                    .AddWithValue("@COO_APPROVAL", "FOR APPROVAL")
                    .AddWithValue("@coo_comment", txtCOOCOMMENT.Text & " - " & DateTimePicker1.Value)

                    .AddWithValue("@status", "RETURN")
                End With
                cm.ExecuteNonQuery()
                cn.Close()
                DeleteInPOList()
                SaveInPOList()

                LoadPOList()

                MsgBox("Purchased Order has been Successfully Return!", vbInformation + vbOKOnly, "CONFIRMATION")

            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_purchasedorder where pr_no like '%" & TextBox1.Text & "%' AND `MANAGER_APPROVAL` = 'APPROVED' AND `GM_APPROVAL` = 'APPROVED' AND `COO_APPROVAL` = 'FOR APPROVAL' AND `STATUS` = 'ACTIVE'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("po_no").ToString, dr.Item("pr_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("shipping_method").ToString, dr.Item("payment_terms").ToString, dr.Item("required_date").ToString, dr.Item("delivery_address").ToString, dr.Item("supplier").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString)

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
            cm = New MySqlCommand("select * from tbl_tic_purchasedorder where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString
                txtPONO.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
                txtCONTROL.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value.ToString
                txtEMPLOYEE.Text = DataGridView2.Rows(e.RowIndex).Cells(4).Value.ToString
                txtDEPARTMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value.ToString
                txtDATE.Text = DataGridView2.Rows(e.RowIndex).Cells(6).Value.ToString
                txtSHIPPINGMETHOD.Text = DataGridView2.Rows(e.RowIndex).Cells(7).Value.ToString

                txtPAYMENTTERMS.Text = DataGridView2.Rows(e.RowIndex).Cells(8).Value.ToString
                txtREQUIREDDATE.Text = DataGridView2.Rows(e.RowIndex).Cells(9).Value.ToString
                txtDELIVERYADDRESS.Text = DataGridView2.Rows(e.RowIndex).Cells(10).Value.ToString

                txtSUPPLIER.Text = DataGridView2.Rows(e.RowIndex).Cells(11).Value.ToString
                txtMANAGERCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(12).Value.ToString
                txtGMCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(13).Value.ToString

            End While
            dr.Close()
            cn.Close()
            LoadItemList()
            Supplier_sum()

            btnSAVE.Enabled = True
            btnPRINT.Enabled = True
            btnRETURN.Enabled = True


        End If

    End Sub

    Sub LoadPOList()

        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_purchasedorder where `MANAGER_APPROVAL` = 'APPROVED' AND `GM_APPROVAL` = 'APPROVED' AND `COO_APPROVAL` = 'FOR APPROVAL' AND `STATUS` = 'ACTIVE' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("po_no").ToString, dr.Item("pr_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("shipping_method").ToString, dr.Item("payment_terms").ToString, dr.Item("required_date").ToString, dr.Item("delivery_address").ToString, dr.Item("supplier").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString)

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
        DataGridView2.Columns.Insert(14, colApproval)

    End Sub

    Private Sub frmTIC_PO_COO_FORM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

            .txtSHOWPURPOSE.Text = txtMANAGERCOMMENT.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtGMCOMMENT.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtCOOCOMMENT.Text
            .ShowDialog()

        End With

    End Sub
End Class