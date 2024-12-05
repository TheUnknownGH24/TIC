Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Drawing.Printing

Public Class frm8SI_PR_RETURN_FORM_FINAL

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

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
                cm = New MySqlCommand("Update tbl_8si_purchasedrequest set purpose=@purpose, status=@status where id=@id", cn)
                With cm.Parameters
                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@purpose", txtREMARKS.Text)
                    .AddWithValue("@status", "ACTIVE")
                End With
                cm.ExecuteNonQuery()
                cn.Close()
                DeleteInPRListAll()
                DeleteInPRList()
                SaveInPRList_1()
                SaveInPRList_2()
                SaveInPRList_3()
                SaveInPRList_all()

            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        End If

    End Sub

    Sub UpdateRequest()

        cn.Open()
        cm = New MySqlCommand("Update tbl_8si_requestslip set status=@status where id=@id", cn)

        With cm.Parameters

            .AddWithValue("@id", txtID.Text)
            .AddWithValue("@status", "DONE")

        End With

        cm.ExecuteNonQuery()
        cn.Close()

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

    Sub SaveInPRList_all()

        For Each row_all As DataGridViewRow In DataGridView4.Rows

            cm = New MySqlCommand("INSERT into tbl_8si_purchasedrequest_all (pr_no, transaction_no, quantity, unit, item_name, supplier_1, unit_price_1, vat_amount_1, total_amount_1, supplier_2, unit_price_2, vat_amount_2, total_amount_2, supplier_3, unit_price_3, vat_amount_3, total_amount_3, final_supplier) values(@pr_no, @transaction_no, @quantity, @unit, @item_name, @supplier_1, @unit_price_1, @vat_amount_1, @total_amount_1, @supplier_2, @unit_price_2, @vat_amount_2, @total_amount_2, @supplier_3, @unit_price_3, @vat_amount_3, @total_amount_3, @final_supplier)", cn)

            With cm.Parameters

                .AddWithValue("@pr_no", txtCONTROL.Text)
                .AddWithValue("@transaction_no", txtTRANSACTION.Text)

                .AddWithValue("@quantity", row_all.Cells("QUANTITY").Value)
                .AddWithValue("@unit", row_all.Cells("UNIT").Value)
                .AddWithValue("@item_name", row_all.Cells("ITEM_NAME").Value)

                .AddWithValue("@supplier_1", row_all.Cells("SUPPLIER_NAME_1").Value)
                .AddWithValue("@unit_price_1", row_all.Cells("UNIT_PRICE_1").Value)
                .AddWithValue("@vat_amount_1", row_all.Cells("VAT_AMOUNT_1").Value)
                .AddWithValue("@total_amount_1", row_all.Cells("TOTAL_PRICE_1").Value)

                .AddWithValue("@supplier_2", row_all.Cells("SUPPLIER_NAME_2").Value)
                .AddWithValue("@unit_price_2", row_all.Cells("UNIT_PRICE_2").Value)
                .AddWithValue("@vat_amount_2", row_all.Cells("VAT_AMOUNT_2").Value)
                .AddWithValue("@total_amount_2", row_all.Cells("TOTAL_PRICE_2").Value)

                .AddWithValue("@supplier_3", row_all.Cells("SUPPLIER_NAME_3").Value)
                .AddWithValue("@unit_price_3", row_all.Cells("UNIT_PRICE_3").Value)
                .AddWithValue("@vat_amount_3", row_all.Cells("VAT_AMOUNT_3").Value)
                .AddWithValue("@total_amount_3", row_all.Cells("TOTAL_PRICE_3").Value)

                .AddWithValue("@final_supplier", row_all.Cells("CHOOSE_SUPPLIER").Value)

            End With

            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
            btnSAVE.Enabled = False
            btnPRINT.Enabled = False
            btnRETURN.Enabled = False
        Next

        MsgBox("Purchased Request has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")


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


    Private Sub btnPRINT_Click(sender As Object, e As EventArgs) Handles btnPRINT.Click

    End Sub

    Private Sub btnRETURN_Click(sender As Object, e As EventArgs) Handles btnRETURN.Click

        If txtREMARKS.Text = "" Then

            MsgBox("Please input Purpose!", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_8si_purchasedrequest set purpose=@purpose, COO_APPROVAL=@COO_APPROVAL, coo_comment=@coo_comment, status=@status where id=@id", cn)
                With cm.Parameters
                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@purpose", txtREMARKS.Text)
                    .AddWithValue("@COO_APPROVAL", "FOR APPROVAL")
                    .AddWithValue("@coo_comment", txtCOOCOMMENT.Text & " - " & DateTimePicker1.Value)
                    .AddWithValue("@status", "RETURN")
                End With
                cm.ExecuteNonQuery()
                cn.Close()
                DeleteInPRListAll()
                DeleteInPRList()
                SaveInPRList_1()
                SaveInPRList_2()
                SaveInPRList_3()
                SaveInPRList_all()

            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        End If

    End Sub

    Private Sub frm8SI_PR_RETURN_FORM_FINAL_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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