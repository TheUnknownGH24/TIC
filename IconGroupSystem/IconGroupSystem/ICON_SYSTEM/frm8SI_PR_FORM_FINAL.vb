Imports MySql.Data.MySqlClient

Public Class frm8SI_PR_FORM_FINAL

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

    Sub Supplier_sum_DATA()

        Dim TOTALUNIT_1 As Decimal = 0
        For i = 0 To DataGridView5.Rows.Count - 1
            TOTALUNIT_1 += DataGridView5.Rows(i).Cells(3).Value
        Next

        Dim VATTOTAL_1 As Decimal = 0
        For i = 0 To DataGridView5.Rows.Count - 1
            VATTOTAL_1 += DataGridView5.Rows(i).Cells(4).Value
        Next

        Dim GRANDTOTAL_1 As Decimal = 0
        For i = 0 To DataGridView5.Rows.Count - 1
            GRANDTOTAL_1 += DataGridView5.Rows(i).Cells(5).Value
        Next

        '=======================================================================

        Dim TOTALUNIT_2 As Decimal = 0
        For i = 0 To DataGridView6.Rows.Count - 1
            TOTALUNIT_2 += DataGridView6.Rows(i).Cells(3).Value
        Next

        Dim VATTOTAL_2 As Decimal = 0
        For i = 0 To DataGridView6.Rows.Count - 1
            VATTOTAL_2 += DataGridView6.Rows(i).Cells(4).Value
        Next

        Dim GRANDTOTAL_2 As Decimal = 0
        For i = 0 To DataGridView6.Rows.Count - 1
            GRANDTOTAL_2 += DataGridView6.Rows(i).Cells(5).Value
        Next

        '=======================================================================

        Dim TOTALUNIT_3 As Decimal = 0
        For i = 0 To DataGridView7.Rows.Count - 1
            TOTALUNIT_3 += DataGridView7.Rows(i).Cells(3).Value
        Next

        Dim VATTOTAL_3 As Decimal = 0
        For i = 0 To DataGridView7.Rows.Count - 1
            VATTOTAL_3 += DataGridView7.Rows(i).Cells(4).Value
        Next

        Dim GRANDTOTAL_3 As Decimal = 0
        For i = 0 To DataGridView7.Rows.Count - 1
            GRANDTOTAL_3 += DataGridView7.Rows(i).Cells(5).Value
        Next

        txtUNIT1.Text = CDbl(TOTALUNIT_1).ToString("#,##0.00")
        txtVAT1.Text = CDbl(VATTOTAL_1).ToString("#,##0.00")
        txtTOTAL1.Text = CDbl(GRANDTOTAL_1).ToString("#,##0.00")

        txtUNIT2.Text = CDbl(TOTALUNIT_2).ToString("#,##0.00")
        txtVAT2.Text = CDbl(VATTOTAL_2).ToString("#,##0.00")
        txtTOTAL2.Text = CDbl(GRANDTOTAL_2).ToString("#,##0.00")

        txtUNIT3.Text = CDbl(TOTALUNIT_3).ToString("#,##0.00")
        txtVAT3.Text = CDbl(VATTOTAL_3).ToString("#,##0.00")
        txtTOTAL3.Text = CDbl(GRANDTOTAL_3).ToString("#,##0.00")

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click


        If txtREMARKS.Text = "" Then

            MsgBox("Please input Purpose!", vbOKOnly + vbCritical, "CONFIRMATION")
        Else
            'reloadtextPR("Select * from tbl_8si_purchasedrequest where transaction_no='" & txtTRANSACTION.Text & "' ")

            'If dt.Rows.Count > 0 Then
            ' MsgBox("Transaction No. Already Exist!", vbOKOnly + vbCritical, "CONFIRMATION")

            'Else

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("INSERT into tbl_8si_purchasedrequest (transaction_no, employee, department, date, purpose, supplier_1, supplier_2, supplier_3, date_time, MANAGER_APPROVAL, GM_APPROVAL, COO_APPROVAL, STATUS, manager_comment, gm_comment, coo_comment) values(@transaction_no, @employee, @department, @date, @purpose, @supplier_1, @supplier_2, @supplier_3, @date_time, @MANAGER_APPROVAL, @GM_APPROVAL, @COO_APPROVAL, @STATUS, @manager_comment, @gm_comment, @coo_comment)", cn)
                With cm.Parameters

                    .AddWithValue("@transaction_no", txtTRANSACTION.Text)
                    .AddWithValue("@employee", txtEMPLOYEE.Text)
                    .AddWithValue("@department", txtDEPARTMENT.Text)
                    .AddWithValue("@date", txtDATE.Text)
                    .AddWithValue("@purpose", txtREMARKS.Text)
                    .AddWithValue("@supplier_1", txtSUPPLIER_1.Text)
                    .AddWithValue("@supplier_2", txtSUPPLIER_2.Text)
                    .AddWithValue("@supplier_3", txtSUPPLIER_3.Text)
                    .AddWithValue("@date_time", DateTimePicker1.Value)

                    .AddWithValue("@MANAGER_APPROVAL", "FOR APPROVAL")
                    .AddWithValue("@manager_comment", "-")

                    .AddWithValue("@GM_APPROVAL", "FOR APPROVAL")
                    .AddWithValue("@gm_comment", "-")

                    .AddWithValue("@COO_APPROVAL", "FOR APPROVAL")
                    .AddWithValue("@coo_comment", "-")

                    .AddWithValue("@STATUS", "ACTIVE")

                End With
                cm.ExecuteNonQuery()
                cn.Close()
                DisplayPR()
                SaveInPRList_1()
                SaveInPRList_2()
                SaveInPRList_3()
                SaveInPRList_all()
                SavePR_SupplierSelect_1()
                SavePR_SupplierSelect_2()
                SavePR_SupplierSelect_3()

                UpdateRequest()
            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

            'End If
        End If

    End Sub

    Sub DisplayPR()

        cn.Open()
        adp = New MySqlDataAdapter("select * from tbl_8si_purchasedrequest where transaction_no = '" & txtTRANSACTION.Text & "' ORDER BY id DESC LIMIT 1", cn)
        dt = New DataTable
        adp.Fill(dt)

        txtCONTROL.Text = dt.Rows(0)(1).ToString()

        cn.Close()

    End Sub

    Sub SavePR_SupplierSelect_1()


        If dataGridView1.CurrentCell Is Nothing Then

            Exit Sub

        Else

            cn.Open()
            cm = New MySqlCommand("INSERT into tbl_8si_purchasedrequest_select (pr_no, supplier_name, status) values (@pr_no, @supplier_name, @status)", cn)

            With cm.Parameters

                .AddWithValue("@pr_no", txtCONTROL.Text)
                .AddWithValue("@supplier_name", txtSUPPLIER_1.Text)
                .AddWithValue("@status", "ACTIVE")

            End With
            cm.ExecuteNonQuery()
            cn.Close()


        End If


    End Sub

    Sub SavePR_SupplierSelect_2()


        If DataGridView2.CurrentCell Is Nothing Then

            Exit Sub

        Else

            cn.Open()
            cm = New MySqlCommand("INSERT into tbl_8si_purchasedrequest_select (pr_no, supplier_name, status) values (@pr_no, @supplier_name, @status)", cn)

            With cm.Parameters

                .AddWithValue("@pr_no", txtCONTROL.Text)
                .AddWithValue("@supplier_name", txtSUPPLIER_2.Text)
                .AddWithValue("@status", "ACTIVE")

            End With
            cm.ExecuteNonQuery()
            cn.Close()


        End If

    End Sub

    Sub SavePR_SupplierSelect_3()

        If DataGridView3.CurrentCell Is Nothing Then

            Exit Sub

        Else

            cn.Open()
            cm = New MySqlCommand("INSERT into tbl_8si_purchasedrequest_select (pr_no, supplier_name, status) values (@pr_no, @supplier_name, @status)", cn)

            With cm.Parameters

                .AddWithValue("@pr_no", txtCONTROL.Text)
                .AddWithValue("@supplier_name", txtSUPPLIER_3.Text)
                .AddWithValue("@status", "ACTIVE")

            End With
            cm.ExecuteNonQuery()
            cn.Close()


        End If

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

    Sub UpdateRequest()

        If txtTOTALCOUNT.Text <= 0 Or txtTOTALCOUNT.Text = String.Empty Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_8si_requestslip set status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)
                .AddWithValue("@status", "DONE")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        Else

            Exit Sub

        End If

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

        'height, width, length,

        If txtSUPPLIER_3.Text = String.Empty Then

            Dim rect1 As New Rectangle(50, 80, 1000, 25)

            Dim brush As SolidBrush = New SolidBrush(Color.Black)
            e.Graphics.FillRectangle(brush, rect1)

            e.Graphics.DrawRectangle(Pens.Black, rect1)

            e.Graphics.DrawImage(Me.PictureBox1.Image, 440, 30, PictureBox1.Width - 15, PictureBox1.Height - 25)

            e.Graphics.DrawString("PURCHASE REQUISITION FORM", header, Brushes.White, rect1, center)

        Else

            Dim rect1 As New Rectangle(50, 80, 1300, 25)

            Dim brush As SolidBrush = New SolidBrush(Color.Black)
            e.Graphics.FillRectangle(brush, rect1)

            e.Graphics.DrawRectangle(Pens.Black, rect1)

            e.Graphics.DrawImage(Me.PictureBox1.Image, 440, 30, PictureBox1.Width - 15, PictureBox1.Height - 25)

            e.Graphics.DrawString("PURCHASED REQUISITION FORM", header, Brushes.White, rect1, center)

        End If

        '================================================================================

        Dim title As New Font("Arial Black", 8, FontStyle.Bold)
        Dim control As New Font("Arial", 8, FontStyle.Regular)
        Dim sign As New Font("CAMBRIA", 8, FontStyle.Bold)
        Dim sign11 As New Font("Arial Black", 8, FontStyle.Underline)
        Dim name As New Font("CAMBRIA", 8, FontStyle.Underline)
        Dim label As New Font("CAMBRIA", 8, FontStyle.Italic)
        Dim data As New Font("CAMBRIA", 10, FontStyle.Bold)

        Dim line As New Font("CAMBRIA", 8, FontStyle.Bold)
        Dim lin2 As New Font("CAMBRIA", 8, FontStyle.Bold)
        Dim lin3 As New Font("CAMBRIA", 8, FontStyle.Bold)

        Dim lineerror As New Font("CAMBRIA", 8, FontStyle.Strikeout)


        e.Graphics.DrawString("PURCHASED REQUISITION#", sign, Brushes.Black, 530, 120)
        e.Graphics.DrawString("DEPARTMENT", sign, Brushes.Black, 530, 140)

        e.Graphics.DrawString("DATE", sign, Brushes.Black, 50, 120)
        e.Graphics.DrawString("EMPLOYEE NAME", sign, Brushes.Black, 50, 140)
        e.Graphics.DrawString("PURPOSE", sign, Brushes.Black, 50, 160)

        e.Graphics.DrawString(":", title, Brushes.Black, 690, 120)
        e.Graphics.DrawString(":", title, Brushes.Black, 690, 140)

        e.Graphics.DrawString(":", title, Brushes.Black, 200, 120)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 140)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 160)

        e.Graphics.DrawString(txtCONTROL.Text, title, Brushes.Black, 700, 118)
        e.Graphics.DrawString(txtDEPARTMENT.Text, title, Brushes.Black, 700, 140)

        e.Graphics.DrawString(txtDATE.Text, title, Brushes.Black, 230, 120)
        e.Graphics.DrawString(txtEMPLOYEE.Text, title, Brushes.Black, 230, 140)
        e.Graphics.DrawString(txtREMARKS.Text, title, Brushes.Black, 230, 160)

        '================================================================================

        If txtSUPPLIER_3.Text = String.Empty Then

            Dim rect2 As New Rectangle(50, 190, 1000, 25)
            Dim brush2 As SolidBrush = New SolidBrush(Color.Red)
            e.Graphics.FillRectangle(brush2, rect2)

            e.Graphics.DrawRectangle(Pens.Black, rect2)

            'e.Graphics.DrawString("I T E M   L I S T", header, Brushes.White, rect2, center)

        Else

            Dim rect2 As New Rectangle(50, 190, 1300, 25)
            Dim brush2 As SolidBrush = New SolidBrush(Color.Red)
            e.Graphics.FillRectangle(brush2, rect2)

            e.Graphics.DrawRectangle(Pens.Black, rect2)

            'e.Graphics.DrawString("I T E M   L I S T", header, Brushes.White, rect2, center)



        End If

        '================================================================================


        Dim y As Integer = 270

        For i = 0 To DataGridView5.Rows.Count - 1
            y += 17

            Dim supp1 As New Rectangle(528, 220, 255, 14)

            Dim brush1 As SolidBrush = New SolidBrush(Color.Black)
            e.Graphics.FillRectangle(brush1, supp1)

            e.Graphics.DrawRectangle(Pens.White, supp1)

            e.Graphics.DrawString(txtSUPPLIER_1.Text, line, Brushes.White, supp1, center)

            '============================================================================

            Dim grand1 As New Rectangle(350, 235, 175, 14)

            Dim gbrush1 As SolidBrush = New SolidBrush(Color.Black)
            e.Graphics.FillRectangle(gbrush1, grand1)

            e.Graphics.DrawRectangle(Pens.White, grand1)

            e.Graphics.DrawString("GRAND TOTAL", line, Brushes.White, grand1, right)

            Dim approved1 As New Rectangle(350, 250, 175, 14)

            Dim abrush1 As SolidBrush = New SolidBrush(Color.Black)
            e.Graphics.FillRectangle(abrush1, approved1)

            e.Graphics.DrawRectangle(Pens.White, approved1)

            e.Graphics.DrawString("APPROVED TOTAL", line, Brushes.White, approved1, right)

            '===============================================================================

            Dim total1 As New Rectangle(528, 235, 85, 14)
            Dim total2 As New Rectangle(613, 235, 85, 14)
            Dim total3 As New Rectangle(698, 235, 85, 14)

            Dim total4 As New Rectangle(528, 250, 85, 14)
            Dim total5 As New Rectangle(613, 250, 85, 14)
            Dim total6 As New Rectangle(698, 250, 85, 14)

            Dim brushtotal3 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brushtotal3, total1)
            e.Graphics.FillRectangle(brushtotal3, total2)
            e.Graphics.FillRectangle(brushtotal3, total3)
            e.Graphics.FillRectangle(brushtotal3, total4)
            e.Graphics.FillRectangle(brushtotal3, total5)
            e.Graphics.FillRectangle(brushtotal3, total6)

            e.Graphics.DrawRectangle(Pens.Black, total1)
            e.Graphics.DrawRectangle(Pens.Black, total2)
            e.Graphics.DrawRectangle(Pens.Black, total3)
            e.Graphics.DrawRectangle(Pens.Black, total4)
            e.Graphics.DrawRectangle(Pens.Black, total5)
            e.Graphics.DrawRectangle(Pens.Black, total6)

            e.Graphics.DrawString(txtUNIT1.Text, line, Brushes.Black, total1, right)
            e.Graphics.DrawString(txtVAT1.Text, line, Brushes.Black, total2, right)
            e.Graphics.DrawString(txtTOTAL1.Text, line, Brushes.Black, total3, right)
            e.Graphics.DrawString(txtTOTALUNIT_1.Text, line, Brushes.Black, total4, right)
            e.Graphics.DrawString(txtVATTOTAL_1.Text, line, Brushes.Black, total5, right)
            e.Graphics.DrawString(txtGRANDTOTAL_1.Text, line, Brushes.Black, total6, right)

            '================================================================================

            Dim box0 As New Rectangle(50, 270, 70, 14)
            Dim box1 As New Rectangle(120, 270, 50, 14)
            Dim box2 As New Rectangle(170, 270, 350, 14)

            Dim box3 As New Rectangle(528, 270, 85, 14)
            Dim box4 As New Rectangle(613, 270, 85, 14)
            Dim box5 As New Rectangle(698, 270, 85, 14)


            Dim brush3 As SolidBrush = New SolidBrush(Color.Black)
            e.Graphics.FillRectangle(brush3, box0)
            e.Graphics.FillRectangle(brush3, box1)
            e.Graphics.FillRectangle(brush3, box2)
            e.Graphics.FillRectangle(brush3, box3)
            e.Graphics.FillRectangle(brush3, box4)
            e.Graphics.FillRectangle(brush3, box5)

            e.Graphics.DrawRectangle(Pens.White, box0)
            e.Graphics.DrawRectangle(Pens.White, box1)
            e.Graphics.DrawRectangle(Pens.White, box2)
            e.Graphics.DrawRectangle(Pens.White, box3)
            e.Graphics.DrawRectangle(Pens.White, box4)
            e.Graphics.DrawRectangle(Pens.White, box5)

            e.Graphics.DrawString("QTY", line, Brushes.White, box0, center)
            e.Graphics.DrawString("UNIT", line, Brushes.White, box1, center)
            e.Graphics.DrawString("DESCRIPTION", line, Brushes.White, box2, center)

            e.Graphics.DrawString("UNIT PRICE", line, Brushes.White, box3, center)
            e.Graphics.DrawString("VAT", line, Brushes.White, box4, center)
            e.Graphics.DrawString("TOTAL PRICE", line, Brushes.White, box5, center)

            '================================================================================

            Dim data0 As New Rectangle(50, y, 70, 14)
            Dim data1 As New Rectangle(120, y, 50, 14)
            Dim data2 As New Rectangle(170, y, 350, 14)

            Dim data3 As New Rectangle(528, y, 85, 14)
            Dim data4 As New Rectangle(613, y, 85, 14)
            Dim data5 As New Rectangle(698, y, 85, 14)

            Dim brush4 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush4, data0)
            e.Graphics.FillRectangle(brush4, data1)
            e.Graphics.FillRectangle(brush4, data2)

            e.Graphics.FillRectangle(brush4, data3)
            e.Graphics.FillRectangle(brush4, data4)
            e.Graphics.FillRectangle(brush4, data5)

            e.Graphics.DrawRectangle(Pens.Black, data0)
            e.Graphics.DrawRectangle(Pens.Black, data1)
            e.Graphics.DrawRectangle(Pens.Black, data2)

            e.Graphics.DrawRectangle(Pens.Black, data3)
            e.Graphics.DrawRectangle(Pens.Black, data4)
            e.Graphics.DrawRectangle(Pens.Black, data5)

            e.Graphics.DrawString(DataGridView4.Rows(i).Cells(0).Value, line, Brushes.Black, data0, center)
            e.Graphics.DrawString(DataGridView4.Rows(i).Cells(1).Value, line, Brushes.Black, data1, center)
            e.Graphics.DrawString(DataGridView4.Rows(i).Cells(2).Value, line, Brushes.Black, data2, left)

            If dataGridView1.CurrentCell Is Nothing Then

                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(4).Value, lineerror, Brushes.Black, data3, right)
                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(5).Value, lineerror, Brushes.Black, data4, right)
                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(6).Value, lineerror, Brushes.Black, data5, right)

            Else

                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(4).Value, line, Brushes.Black, data3, right)
                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(5).Value, line, Brushes.Black, data4, right)
                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(6).Value, line, Brushes.Black, data5, right)

            End If

            Dim p As Integer = 700

            p += 18

            Dim title1 As New Rectangle(50, p, 230, 20)
            Dim title2 As New Rectangle(280, p, 230, 20)
            Dim title3 As New Rectangle(510, p, 230, 20)
            Dim title4 As New Rectangle(740, p, 230, 20)

            Dim brush6 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush6, title1)
            e.Graphics.FillRectangle(brush6, title2)
            e.Graphics.FillRectangle(brush6, title3)
            e.Graphics.FillRectangle(brush6, title4)

            e.Graphics.DrawRectangle(Pens.White, title1)
            e.Graphics.DrawRectangle(Pens.White, title2)
            e.Graphics.DrawRectangle(Pens.White, title3)
            e.Graphics.DrawRectangle(Pens.White, title4)

            e.Graphics.DrawString("PREPARED BY:", sign, Brushes.Black, title1, left)
            e.Graphics.DrawString("ENDORSED BY:", sign, Brushes.Black, title2, left)
            e.Graphics.DrawString("APPROVED BY:", sign, Brushes.Black, title3, left)
            e.Graphics.DrawString("RECIEVED BY:", sign, Brushes.Black, title4, left)

            '=============================================================================

            Dim s As Integer = 740

            s += 18

            Dim sign1 As New Rectangle(50, s, 230, 20)
            Dim sign2 As New Rectangle(280, s, 230, 20)
            Dim sign3 As New Rectangle(510, s, 230, 20)
            Dim sign4 As New Rectangle(740, s, 230, 20)

            Dim brush7 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush7, sign1)
            e.Graphics.FillRectangle(brush7, sign2)
            e.Graphics.FillRectangle(brush7, sign3)
            e.Graphics.FillRectangle(brush7, sign4)

            e.Graphics.DrawRectangle(Pens.White, sign1)
            e.Graphics.DrawRectangle(Pens.White, sign2)
            e.Graphics.DrawRectangle(Pens.White, sign3)
            e.Graphics.DrawRectangle(Pens.White, sign4)

            e.Graphics.DrawString(txtEMPLOYEE.Text, sign11, Brushes.Black, sign1, left)
            e.Graphics.DrawString("_________________________", sign11, Brushes.Black, sign2, left)
            e.Graphics.DrawString("_________________________", sign11, Brushes.Black, sign3, left)
            e.Graphics.DrawString("_________________________", sign11, Brushes.Black, sign4, left)

            '=============================================================================

            Dim l As Integer = 760

            l += 18

            Dim label1 As New Rectangle(50, l, 220, 20)
            Dim label2 As New Rectangle(280, l, 220, 20)
            Dim label3 As New Rectangle(510, l, 220, 20)
            Dim label4 As New Rectangle(740, l, 220, 20)

            Dim brush8 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush8, label1)
            e.Graphics.FillRectangle(brush8, label2)
            e.Graphics.FillRectangle(brush8, label3)
            e.Graphics.FillRectangle(brush8, label4)

            e.Graphics.DrawRectangle(Pens.White, label1)
            e.Graphics.DrawRectangle(Pens.White, label2)
            e.Graphics.DrawRectangle(Pens.White, label3)
            e.Graphics.DrawRectangle(Pens.White, label4)

            e.Graphics.DrawString("SIGN & DATE", label, Brushes.Black, label1, left)
            e.Graphics.DrawString("PURCHASING MANAGER", label, Brushes.Black, label2, left)
            e.Graphics.DrawString("GENERAL MANAGER", label, Brushes.Black, label3, left)
            e.Graphics.DrawString("CHIEF OPERATING OFFICER", label, Brushes.Black, label4, left)


        Next

        '================================================================================

        Dim x As Integer = 270

        For i = 0 To DataGridView6.Rows.Count - 1
            x += 17

            Dim supp1 As New Rectangle(790, 220, 255, 14)

            Dim brush1 As SolidBrush = New SolidBrush(Color.Black)
            e.Graphics.FillRectangle(brush1, supp1)

            e.Graphics.DrawRectangle(Pens.White, supp1)

            e.Graphics.DrawString(txtSUPPLIER_2.Text, line, Brushes.White, supp1, center)

            '===============================================================================

            Dim total1 As New Rectangle(790, 235, 85, 14)
            Dim total2 As New Rectangle(875, 235, 85, 14)
            Dim total3 As New Rectangle(960, 235, 85, 14)

            Dim total4 As New Rectangle(790, 250, 85, 14)
            Dim total5 As New Rectangle(875, 250, 85, 14)
            Dim total6 As New Rectangle(960, 250, 85, 14)

            Dim brushtotal3 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brushtotal3, total1)
            e.Graphics.FillRectangle(brushtotal3, total2)
            e.Graphics.FillRectangle(brushtotal3, total3)
            e.Graphics.FillRectangle(brushtotal3, total4)
            e.Graphics.FillRectangle(brushtotal3, total5)
            e.Graphics.FillRectangle(brushtotal3, total6)

            e.Graphics.DrawRectangle(Pens.Black, total1)
            e.Graphics.DrawRectangle(Pens.Black, total2)
            e.Graphics.DrawRectangle(Pens.Black, total3)
            e.Graphics.DrawRectangle(Pens.Black, total4)
            e.Graphics.DrawRectangle(Pens.Black, total5)
            e.Graphics.DrawRectangle(Pens.Black, total6)

            e.Graphics.DrawString(txtUNIT2.Text, line, Brushes.Black, total1, right)
            e.Graphics.DrawString(txtVAT2.Text, line, Brushes.Black, total2, right)
            e.Graphics.DrawString(txtTOTAL2.Text, line, Brushes.Black, total3, right)

            e.Graphics.DrawString(txtTOTALUNIT_2.Text, line, Brushes.Black, total4, right)
            e.Graphics.DrawString(txtVATTOTAL_2.Text, line, Brushes.Black, total5, right)
            e.Graphics.DrawString(txtGRANDTOTAL_2.Text, line, Brushes.Black, total6, right)

            '================================================================================

            Dim box3 As New Rectangle(790, 270, 85, 14)
            Dim box4 As New Rectangle(875, 270, 85, 14)
            Dim box5 As New Rectangle(960, 270, 85, 14)


            Dim brush3 As SolidBrush = New SolidBrush(Color.Black)
            e.Graphics.FillRectangle(brush3, box3)
            e.Graphics.FillRectangle(brush3, box4)
            e.Graphics.FillRectangle(brush3, box5)

            e.Graphics.DrawRectangle(Pens.White, box3)
            e.Graphics.DrawRectangle(Pens.White, box4)
            e.Graphics.DrawRectangle(Pens.White, box5)

            e.Graphics.DrawString("UNIT PRICE", line, Brushes.White, box3, center)
            e.Graphics.DrawString("VAT", line, Brushes.White, box4, center)
            e.Graphics.DrawString("TOTAL PRICE", line, Brushes.White, box5, center)

            '================================================================================

            Dim data3 As New Rectangle(790, x, 85, 14)
            Dim data4 As New Rectangle(875, x, 85, 14)
            Dim data5 As New Rectangle(960, x, 85, 14)

            Dim brush4 As SolidBrush = New SolidBrush(Color.White)

            e.Graphics.FillRectangle(brush4, data3)
            e.Graphics.FillRectangle(brush4, data4)
            e.Graphics.FillRectangle(brush4, data5)

            e.Graphics.DrawRectangle(Pens.Black, data3)
            e.Graphics.DrawRectangle(Pens.Black, data4)
            e.Graphics.DrawRectangle(Pens.Black, data5)

            If DataGridView2.CurrentCell Is Nothing Then

                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(8).Value, lineerror, Brushes.Black, data3, right)
                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(9).Value, lineerror, Brushes.Black, data4, right)
                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(10).Value, lineerror, Brushes.Black, data5, right)

            Else

                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(8).Value, line, Brushes.Black, data3, right)
                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(9).Value, line, Brushes.Black, data4, right)
                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(10).Value, line, Brushes.Black, data5, right)

            End If

        Next

        '================================================================================

        Dim z As Integer = 270

        For i = 0 To DataGridView7.Rows.Count - 1
            z += 17

            Dim supp1 As New Rectangle(1053, 220, 255, 14)

            Dim brush1 As SolidBrush = New SolidBrush(Color.Black)
            e.Graphics.FillRectangle(brush1, supp1)

            e.Graphics.DrawRectangle(Pens.White, supp1)

            e.Graphics.DrawString(txtSUPPLIER_3.Text, line, Brushes.White, supp1, center)

            '===============================================================================

            Dim total1 As New Rectangle(1053, 235, 85, 14)
            Dim total2 As New Rectangle(1138, 235, 85, 14)
            Dim total3 As New Rectangle(1223, 235, 85, 14)

            Dim total4 As New Rectangle(1053, 250, 85, 14)
            Dim total5 As New Rectangle(1138, 250, 85, 14)
            Dim total6 As New Rectangle(1223, 250, 85, 14)

            Dim brushtotal3 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brushtotal3, total1)
            e.Graphics.FillRectangle(brushtotal3, total2)
            e.Graphics.FillRectangle(brushtotal3, total3)
            e.Graphics.FillRectangle(brushtotal3, total4)
            e.Graphics.FillRectangle(brushtotal3, total5)
            e.Graphics.FillRectangle(brushtotal3, total6)

            e.Graphics.DrawRectangle(Pens.Black, total1)
            e.Graphics.DrawRectangle(Pens.Black, total2)
            e.Graphics.DrawRectangle(Pens.Black, total3)
            e.Graphics.DrawRectangle(Pens.Black, total4)
            e.Graphics.DrawRectangle(Pens.Black, total5)
            e.Graphics.DrawRectangle(Pens.Black, total6)

            e.Graphics.DrawString(txtUNIT3.Text, line, Brushes.Black, total1, right)
            e.Graphics.DrawString(txtVAT3.Text, line, Brushes.Black, total2, right)
            e.Graphics.DrawString(txtTOTAL3.Text, line, Brushes.Black, total3, right)
            e.Graphics.DrawString(txtTOTALUNIT_3.Text, line, Brushes.Black, total4, right)
            e.Graphics.DrawString(txtVATTOTAL_3.Text, line, Brushes.Black, total5, right)
            e.Graphics.DrawString(txtGRANDTOTAL_3.Text, line, Brushes.Black, total6, right)

            '================================================================================

            Dim box3 As New Rectangle(1053, 270, 85, 14)
            Dim box4 As New Rectangle(1138, 270, 85, 14)
            Dim box5 As New Rectangle(1223, 270, 85, 14)


            Dim brush3 As SolidBrush = New SolidBrush(Color.Black)
            e.Graphics.FillRectangle(brush3, box3)
            e.Graphics.FillRectangle(brush3, box4)
            e.Graphics.FillRectangle(brush3, box5)

            e.Graphics.DrawRectangle(Pens.White, box3)
            e.Graphics.DrawRectangle(Pens.White, box4)
            e.Graphics.DrawRectangle(Pens.White, box5)

            e.Graphics.DrawString("UNIT PRICE", line, Brushes.White, box3, center)
            e.Graphics.DrawString("VAT", line, Brushes.White, box4, center)
            e.Graphics.DrawString("TOTAL PRICE", line, Brushes.White, box5, center)

            '================================================================================

            Dim data3 As New Rectangle(1053, z, 85, 14)
            Dim data4 As New Rectangle(1138, z, 85, 14)
            Dim data5 As New Rectangle(1223, z, 85, 14)

            Dim brush4 As SolidBrush = New SolidBrush(Color.White)

            e.Graphics.FillRectangle(brush4, data3)
            e.Graphics.FillRectangle(brush4, data4)
            e.Graphics.FillRectangle(brush4, data5)

            e.Graphics.DrawRectangle(Pens.Black, data3)
            e.Graphics.DrawRectangle(Pens.Black, data4)
            e.Graphics.DrawRectangle(Pens.Black, data5)

            If DataGridView3.CurrentCell Is Nothing Then

                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(12).Value, lineerror, Brushes.Black, data3, right)
                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(13).Value, lineerror, Brushes.Black, data4, right)
                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(14).Value, lineerror, Brushes.Black, data5, right)

            Else

                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(12).Value, line, Brushes.Black, data3, right)
                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(13).Value, line, Brushes.Black, data4, right)
                e.Graphics.DrawString(DataGridView4.Rows(i).Cells(14).Value, line, Brushes.Black, data5, right)

            End If

            '=============================================================================

        Next

    End Sub

    Private Sub btnPRINT_Click(sender As Object, e As EventArgs) Handles btnPRINT.Click

        If txtSUPPLIER_3.Text = String.Empty Then

            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.Document.DefaultPageSettings.Landscape = True
            PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize = New Printing.PaperSize("Custom", 850, 1100)
            PrintPreviewDialog1.ShowDialog()

        Else

            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.Document.DefaultPageSettings.Landscape = True
            PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize = New Printing.PaperSize("Custom", 850, 1400)
            PrintPreviewDialog1.ShowDialog()

        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

        PageSetupDialog1.Document = PrintDocument1
        PageSetupDialog1.Document.DefaultPageSettings.Color = False
        PageSetupDialog1.Document.DefaultPageSettings.Landscape = True
        PageSetupDialog1.ShowDialog()

    End Sub

    Private Sub frm8SI_PR_FORM_FINAL_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click


        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtREMARKS.Text
            .ShowDialog()

        End With

    End Sub
End Class