Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Drawing.Printing

Public Class frm8SI_PR_MANAGER_FORM_FINAL

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Private Sub Button5_Click(sender As Object, e As EventArgs)

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

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

        Dim TOTALUNIT_2 As Decimal = 0
        For i = 0 To DataGridView2.Rows.Count - 1
            TOTALUNIT_2 += DataGridView2.Rows(i).Cells(3).Value
        Next

        Dim VATTOTAL_2 As Decimal = 0
        For i = 0 To DataGridView2.Rows.Count - 1
            VATTOTAL_2 += DataGridView2.Rows(i).Cells(4).Value
        Next

        Dim GRANDTOTAL_2 As Decimal = 0
        For i = 0 To DataGridView2.Rows.Count - 1
            GRANDTOTAL_2 += DataGridView2.Rows(i).Cells(5).Value
        Next

        '=======================================================================

        Dim TOTALUNIT_3 As Decimal = 0
        For i = 0 To DataGridView3.Rows.Count - 1
            TOTALUNIT_3 += DataGridView3.Rows(i).Cells(3).Value
        Next

        Dim VATTOTAL_3 As Decimal = 0
        For i = 0 To DataGridView3.Rows.Count - 1
            VATTOTAL_3 += DataGridView3.Rows(i).Cells(4).Value
        Next


        Dim GRANDTOTAL_3 As Decimal = 0
        For i = 0 To DataGridView3.Rows.Count - 1
            GRANDTOTAL_3 += DataGridView3.Rows(i).Cells(5).Value
        Next

        txtTOTALUNIT_1.Text = CDbl(TOTALUNIT_1).ToString("#,##0.00")
        txtVATTOTAL_1.Text = CDbl(VATTOTAL_1).ToString("#,##0.00")
        txtGRANDTOTAL_1.Text = CDbl(GRANDTOTAL_1).ToString("#,##0.00")

        txtTOTALUNIT_2.Text = CDbl(TOTALUNIT_2).ToString("#,##0.00")
        txtVATTOTAL_2.Text = CDbl(VATTOTAL_2).ToString("#,##0.00")
        txtGRANDTOTAL_2.Text = CDbl(GRANDTOTAL_2).ToString("#,##0.00")

        txtTOTALUNIT_3.Text = CDbl(TOTALUNIT_3).ToString("#,##0.00")
        txtVATTOTAL_3.Text = CDbl(VATTOTAL_3).ToString("#,##0.00")
        txtGRANDTOTAL_3.Text = CDbl(GRANDTOTAL_3).ToString("#,##0.00")

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click


        If txtREMARKS.Text = "" Then

            MsgBox("Please input Purpose!", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_8si_purchasedrequest set purpose=@purpose, MANAGER_APPROVAL=@MANAGER_APPROVAL, manager_comment=@manager_comment where id=@id", cn)
                With cm.Parameters
                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@purpose", txtREMARKS.Text)
                    .AddWithValue("@MANAGER_APPROVAL", "APPROVED")
                    .AddWithValue("@manager_comment", txtCOMMENT.Text & " - " & DateTimePicker1.Value)
                End With
                cm.ExecuteNonQuery()
                cn.Close()
                'DeleteInPRListAll()
                'DeleteInPRList()
                'SaveInPRList_1()
                'SaveInPRList_2()
                'SaveInPRList_3()
                'SaveInPRList_all()

                LoadPRList()

                btnSAVE.Enabled = False
                btnPRINT.Enabled = False
                Button2.Enabled = False

                MsgBox("Purchased Request has been Successfully Approved!", vbInformation + vbOKOnly, "CONFIRMATION")

            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        End If

    End Sub

    Sub DeleteInPRListAll()

        cm = New MySqlCommand("DELETE FROM tbl_8si_purchasedrequest_all WHERE `pr_no` like '%" & txtCONTROL.Text & "%'", cn)

        cn.Open()
        cm.ExecuteNonQuery()
        cn.Close()

    End Sub

    Sub DeleteInPRList()

        cm = New MySqlCommand("DELETE FROM tbl_8si_purchasedrequestlist WHERE `pr_no` like '%" & txtCONTROL.Text & "%'", cn)

        cn.Open()
        cm.ExecuteNonQuery()
        cn.Close()

    End Sub

    Sub DisplayPR()

        cn.Open()
        adp = New MySqlDataAdapter("select * from tbl_8si_purchasedrequest where transaction_no = '" & txtTRANSACTION.Text & "'", cn)
        dt = New DataTable
        adp.Fill(dt)

        txtCONTROL.Text = dt.Rows(0)(1).ToString()

        cn.Close()

    End Sub

    Sub SaveInPRList_1()

        For Each row_1 As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tbl_8si_purchasedrequestlist (pr_no, transaction_no, supplier_name, quantity, unit, item_name, unit_price, vat_amount, grand_total) values(@pr_no, @transaction_no, @supplier_name, @quantity, @unit, @item_name, @unit_price, @vat_amount, @grand_total)", cn)

            With cm.Parameters
                .AddWithValue("@pr_no", txtCONTROL.Text)
                .AddWithValue("@transaction_no", txtTRANSACTION.Text)
                .AddWithValue("@supplier_name", txtSUPPLIER_1.Text)

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

        Next

    End Sub

    Sub SaveInPRList_2()

        For Each row_2 As DataGridViewRow In DataGridView2.Rows

            cm = New MySqlCommand("INSERT into tbl_8si_purchasedrequestlist (pr_no, transaction_no, supplier_name, quantity, unit, item_name, unit_price, vat_amount, grand_total) values(@pr_no, @transaction_no, @supplier_name, @quantity, @unit, @item_name, @unit_price, @vat_amount, @grand_total)", cn)

            With cm.Parameters
                .AddWithValue("@pr_no", txtCONTROL.Text)
                .AddWithValue("@transaction_no", txtTRANSACTION.Text)
                .AddWithValue("@supplier_name", txtSUPPLIER_2.Text)

                .AddWithValue("@quantity", row_2.Cells("QUANTITY").Value)
                .AddWithValue("@unit", row_2.Cells("UNIT").Value)
                .AddWithValue("@item_name", row_2.Cells("ITEM_NAME").Value)
                .AddWithValue("@unit_price", row_2.Cells("UNIT_PRICE").Value)
                .AddWithValue("@vat_amount", row_2.Cells("VAT_AMOUNT").Value)
                .AddWithValue("@grand_total", row_2.Cells("TOTAL_PRICE").Value)

            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()

        Next

    End Sub

    Sub SaveInPRList_3()

        For Each row_3 As DataGridViewRow In DataGridView3.Rows

            cm = New MySqlCommand("INSERT into tbl_8si_purchasedrequestlist (pr_no, transaction_no, supplier_name, quantity, unit, item_name, unit_price, vat_amount, grand_total) values(@pr_no, @transaction_no, @supplier_name, @quantity, @unit, @item_name, @unit_price, @vat_amount, @grand_total)", cn)

            With cm.Parameters
                .AddWithValue("@pr_no", txtCONTROL.Text)
                .AddWithValue("@transaction_no", txtTRANSACTION.Text)
                .AddWithValue("@supplier_name", txtSUPPLIER_3.Text)

                .AddWithValue("@quantity", row_3.Cells("QUANTITY").Value)
                .AddWithValue("@unit", row_3.Cells("UNIT").Value)
                .AddWithValue("@item_name", row_3.Cells("ITEM_NAME").Value)
                .AddWithValue("@unit_price", row_3.Cells("UNIT_PRICE").Value)
                .AddWithValue("@vat_amount", row_3.Cells("VAT_AMOUNT").Value)
                .AddWithValue("@grand_total", row_3.Cells("TOTAL_PRICE").Value)

            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()

        Next

    End Sub


    Public Sub reloadtextPR(ByVal sql As String)
        Try
            cn.Open()
            With cm
                .Connection = cn
                .CommandText = sql
            End With
            dt = New DataTable
            adp = New MySqlDataAdapter(sql, cn)
            adp.Fill(dt)

        Catch ex As Exception
            MsgBox(ex.Message & "reloadtext", vbCritical)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
                adp.Dispose()
            End If
        End Try
    End Sub

    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        DataGridView5.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_purchasedrequest where pr_no like '%" & txtSEARCHNAME.Text & "%' AND `MANAGER_APPROVAL` = 'FOR APPROVAL' AND `STATUS` = 'ACTIVE'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView5.Rows.Add(i, dr.Item("id").ToString, dr.Item("pr_no").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("purpose").ToString, dr.Item("supplier_1").ToString, dr.Item("supplier_2").ToString, dr.Item("supplier_3").ToString)

        End While

        dr.Close()
        cn.Close()


    End Sub

    Sub LoadPRList()

        DataGridView5.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_purchasedrequest where `MANAGER_APPROVAL` = 'FOR APPROVAL' AND `STATUS` = 'ACTIVE' ", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView5.Rows.Add(i, dr.Item("id").ToString, dr.Item("pr_no").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("purpose").ToString, dr.Item("supplier_1").ToString, dr.Item("supplier_2").ToString, dr.Item("supplier_3").ToString)

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
        DataGridView5.Columns.Insert(11, colApproval)

    End Sub


    Sub LoadPURCHASEDList_supplier1()

        If txtSUPPLIER_1.Text = String.Empty Then

            dataGridView1.Rows.Clear()
            Exit Sub

        Else

            dataGridView1.Rows.Clear()

            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedrequest_all where `pr_no` like '" & txtCONTROL.Text & "'  AND `supplier_1` like '" & txtSUPPLIER_1.Text & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                dataGridView1.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, dr.Item("unit_price_1").ToString, dr.Item("vat_amount_1").ToString, dr.Item("total_amount_1").ToString)

            End While
            dr.Close()
            cn.Close()

        End If

    End Sub

    Sub LoadPURCHASEDList_supplier2()

        If txtSUPPLIER_2.Text = String.Empty Then

            DataGridView2.Rows.Clear()
            Exit Sub

        Else

            DataGridView2.Rows.Clear()

            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedrequest_all where `pr_no` like '" & txtCONTROL.Text & "'  AND `supplier_2` like '" & txtSUPPLIER_2.Text & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                DataGridView2.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, dr.Item("unit_price_2").ToString, dr.Item("vat_amount_2").ToString, dr.Item("total_amount_2").ToString)

            End While
            dr.Close()
            cn.Close()

        End If

    End Sub

    Sub LoadPURCHASEDList_supplier3()

        If txtSUPPLIER_3.Text = String.Empty Then

            DataGridView3.Rows.Clear()
            Exit Sub

        Else

            DataGridView3.Rows.Clear()

            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedrequest_all where `pr_no` like '" & txtCONTROL.Text & "'  AND `supplier_3` like '" & txtSUPPLIER_3.Text & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                DataGridView3.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, dr.Item("unit_price_3").ToString, dr.Item("vat_amount_3").ToString, dr.Item("total_amount_3").ToString)

            End While
            dr.Close()
            cn.Close()

        End If

    End Sub


    Private Sub DataGridView5_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView2.CurrentCellDirtyStateChanged

        DataGridView5.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub


    Private Sub DataGridView5_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView5.CellContentClick

        Dim colname As String = DataGridView5.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedrequest where id like '" & DataGridView5.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader

            While dr.Read

                txtID.Text = DataGridView5.Rows(e.RowIndex).Cells(1).Value.ToString
                txtCONTROL.Text = DataGridView5.Rows(e.RowIndex).Cells(2).Value.ToString
                txtTRANSACTION.Text = DataGridView5.Rows(e.RowIndex).Cells(3).Value.ToString
                txtEMPLOYEE.Text = DataGridView5.Rows(e.RowIndex).Cells(4).Value.ToString
                txtDEPARTMENT.Text = DataGridView5.Rows(e.RowIndex).Cells(5).Value.ToString
                txtDATE.Text = DataGridView5.Rows(e.RowIndex).Cells(6).Value.ToString
                txtREMARKS.Text = DataGridView5.Rows(e.RowIndex).Cells(7).Value.ToString

                txtSUPPLIER_1.Text = DataGridView5.Rows(e.RowIndex).Cells(8).Value.ToString
                txtSUPPLIER_2.Text = DataGridView5.Rows(e.RowIndex).Cells(9).Value.ToString
                txtSUPPLIER_3.Text = DataGridView5.Rows(e.RowIndex).Cells(10).Value.ToString

            End While
            dr.Close()
            cn.Close()
            LoadPURCHASEDList_supplier1()
            LoadPURCHASEDList_supplier2()
            LoadPURCHASEDList_supplier3()
            Supplier_sum()
            btnSAVE.Enabled = True
            btnPRINT.Enabled = True
            Button2.Enabled = True
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub btnPRINT_Click(sender As Object, e As EventArgs) Handles btnPRINT.Click

        If txtREMARKS.Text = "" Then

            MsgBox("Please input Purpose!", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_8si_purchasedrequest set purpose=@purpose, MANAGER_APPROVAL=@MANAGER_APPROVAL, manager_comment=@manager_comment, status=@status where id=@id", cn)
                With cm.Parameters
                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@purpose", txtREMARKS.Text)
                    .AddWithValue("@MANAGER_APPROVAL", "DISAPPROVED")
                    .AddWithValue("@manager_comment", txtCOMMENT.Text & " - " & DateTimePicker1.Value)
                    .AddWithValue("@status", "DEACTIVE")
                End With
                cm.ExecuteNonQuery()
                cn.Close()
                'DeleteInPRListAll()
                'DeleteInPRList()
                'SaveInPRList_1()
                'SaveInPRList_2()
                'SaveInPRList_3()

                LoadPRList()

                MsgBox("Purchased Request has been Successfully Approved!", vbInformation + vbOKOnly, "CONFIRMATION")

            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        frm8SI_PR_MANAGER_FORM_VIEW.txtSUPPLIER_1.Text = txtSUPPLIER_1.Text
        frm8SI_PR_MANAGER_FORM_VIEW.txtSUPPLIER_2.Text = txtSUPPLIER_2.Text
        frm8SI_PR_MANAGER_FORM_VIEW.txtSUPPLIER_3.Text = txtSUPPLIER_3.Text

        frm8SI_PR_MANAGER_FORM_VIEW.txtPRNO_1.Text = txtCONTROL.Text
        frm8SI_PR_MANAGER_FORM_VIEW.txtPRNO_2.Text = txtCONTROL.Text
        frm8SI_PR_MANAGER_FORM_VIEW.txtPRNO_3.Text = txtCONTROL.Text

        frm8SI_PR_MANAGER_FORM_VIEW.LoadPURCHASEDList_supplier1_FINAL()
        frm8SI_PR_MANAGER_FORM_VIEW.LoadPURCHASEDList_supplier2_FINAL()
        frm8SI_PR_MANAGER_FORM_VIEW.LoadPURCHASEDList_supplier3_FINAL()

        frm8SI_PR_MANAGER_FORM_VIEW.Supplier_sum()

        frm8SI_PR_MANAGER_FORM_VIEW.StartPosition = FormStartPosition.CenterScreen
        frm8SI_PR_MANAGER_FORM_VIEW.Show()

    End Sub


    Private Sub frm8SI_PR_MANAGER_FORM_FINAL_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

            .txtSHOWPURPOSE.Text = txtREMARKS.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtCOMMENT.Text
            .ShowDialog()

        End With

    End Sub
End Class