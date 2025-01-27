Public Class frm8SI_PR_FORM_RECORD

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

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

        txtTOTALUNIT_1.Text = CDbl(TOTALUNIT_1).ToString("#,##0.000")
        txtVATTOTAL_1.Text = CDbl(VATTOTAL_1).ToString("#,##0.000")
        txtGRANDTOTAL_1.Text = CDbl(GRANDTOTAL_1).ToString("#,##0.000")

        txtTOTALUNIT_2.Text = CDbl(TOTALUNIT_2).ToString("#,##0.000")
        txtVATTOTAL_2.Text = CDbl(VATTOTAL_2).ToString("#,##0.000")
        txtGRANDTOTAL_2.Text = CDbl(GRANDTOTAL_2).ToString("#,##0.000")

        txtTOTALUNIT_3.Text = CDbl(TOTALUNIT_3).ToString("#,##0.000")
        txtVATTOTAL_3.Text = CDbl(VATTOTAL_3).ToString("#,##0.000")
        txtGRANDTOTAL_3.Text = CDbl(GRANDTOTAL_3).ToString("#,##0.000")

    End Sub

    Sub Supplier_sumselect()

        Dim TOTALUNIT_1 As Decimal = 0
        For i = 0 To DataGridView8.Rows.Count - 1
            TOTALUNIT_1 += DataGridView8.Rows(i).Cells(3).Value
        Next

        Dim VATTOTAL_1 As Decimal = 0
        For i = 0 To DataGridView8.Rows.Count - 1
            VATTOTAL_1 += DataGridView8.Rows(i).Cells(4).Value
        Next

        Dim GRANDTOTAL_1 As Decimal = 0
        For i = 0 To DataGridView8.Rows.Count - 1
            GRANDTOTAL_1 += DataGridView8.Rows(i).Cells(5).Value
        Next

        '=======================================================================

        Dim TOTALUNIT_2 As Decimal = 0
        For i = 0 To DataGridView7.Rows.Count - 1
            TOTALUNIT_2 += DataGridView7.Rows(i).Cells(3).Value
        Next

        Dim VATTOTAL_2 As Decimal = 0
        For i = 0 To DataGridView7.Rows.Count - 1
            VATTOTAL_2 += DataGridView7.Rows(i).Cells(4).Value
        Next

        Dim GRANDTOTAL_2 As Decimal = 0
        For i = 0 To DataGridView7.Rows.Count - 1
            GRANDTOTAL_2 += DataGridView7.Rows(i).Cells(5).Value
        Next

        '=======================================================================

        Dim TOTALUNIT_3 As Decimal = 0
        For i = 0 To DataGridView6.Rows.Count - 1
            TOTALUNIT_3 += DataGridView6.Rows(i).Cells(3).Value
        Next

        Dim VATTOTAL_3 As Decimal = 0
        For i = 0 To DataGridView6.Rows.Count - 1
            VATTOTAL_3 += DataGridView6.Rows(i).Cells(4).Value
        Next


        Dim GRANDTOTAL_3 As Decimal = 0
        For i = 0 To DataGridView6.Rows.Count - 1
            GRANDTOTAL_3 += DataGridView6.Rows(i).Cells(5).Value
        Next

        txtSELECT_UNIT1.Text = CDbl(TOTALUNIT_1).ToString("#,##0.000")
        txtSELECT_VAT1.Text = CDbl(VATTOTAL_1).ToString("#,##0.000")
        txtSELECT_TOTAL1.Text = CDbl(GRANDTOTAL_1).ToString("#,##0.000")

        txtSELECT_UNIT2.Text = CDbl(TOTALUNIT_2).ToString("#,##0.000")
        txtSELECT_VAT2.Text = CDbl(VATTOTAL_2).ToString("#,##0.000")
        txtSELECT_TOTAL2.Text = CDbl(GRANDTOTAL_2).ToString("#,##0.000")

        txtSELECT_UNIT3.Text = CDbl(TOTALUNIT_3).ToString("#,##0.000")
        txtSELECT_VAT3.Text = CDbl(VATTOTAL_3).ToString("#,##0.000")
        txtSELECT_TOTAL3.Text = CDbl(GRANDTOTAL_3).ToString("#,##0.000")

    End Sub

    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        If txtTYPE.Text = "ADMINISTRATOR" Then

            DataGridView5.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedrequest where `pr_no` like '%" & txtSEARCHNAME.Text & "%'", cn)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                DataGridView5.Rows.Add(i, dr.Item("id").ToString, dr.Item("pr_no").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("purpose").ToString, dr.Item("supplier_1").ToString, dr.Item("supplier_2").ToString, dr.Item("supplier_3").ToString)

            End While
            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView5.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedrequest where `department` like '%" & txtDEPARTMENTDATA.Text & "%' and `pr_no` like '%" & txtSEARCHNAME.Text & "%'", cn)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                DataGridView5.Rows.Add(i, dr.Item("id").ToString, dr.Item("pr_no").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("purpose").ToString, dr.Item("supplier_1").ToString, dr.Item("supplier_2").ToString, dr.Item("supplier_3").ToString)

            End While
            dr.Close()
            cn.Close()

        End If

    End Sub

    Sub LoadPURCHASEDList()

        DataGridView4.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_purchasedrequest_all where `pr_no` like '%" & txtCONTROL.Text & "%'", cn)
        dr = cm.ExecuteReader
        While dr.Read

            DataGridView4.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, dr.Item("supplier_1").ToString, CDbl(dr.Item("unit_price_1").ToString).ToString("#,##0.000"), dr.Item("vat_amount_1").ToString, dr.Item("total_amount_1").ToString, dr.Item("supplier_2").ToString, CDbl(dr.Item("unit_price_2").ToString).ToString("#,##0.000"), dr.Item("vat_amount_2").ToString, dr.Item("total_amount_2").ToString, dr.Item("supplier_3").ToString, CDbl(dr.Item("unit_price_3").ToString).ToString("#,##0.000"), dr.Item("vat_amount_3").ToString, dr.Item("total_amount_3").ToString, dr.Item("final_supplier").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub


    Sub LoadPRList()

        If txtTYPE.Text = "ADMINISTRATOR" Then

            DataGridView5.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedrequest", cn)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                DataGridView5.Rows.Add(i, dr.Item("id").ToString, dr.Item("pr_no").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("purpose").ToString, dr.Item("supplier_1").ToString, dr.Item("supplier_2").ToString, dr.Item("supplier_3").ToString)

            End While
            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView5.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedrequest where `department` like '%" & txtDEPARTMENTDATA.Text & "%'", cn)
            dr = cm.ExecuteReader
            While dr.Read
                i += 1
                DataGridView5.Rows.Add(i, dr.Item("id").ToString, dr.Item("pr_no").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("purpose").ToString, dr.Item("supplier_1").ToString, dr.Item("supplier_2").ToString, dr.Item("supplier_3").ToString)

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
            .Text = "VIEW"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End With
        DataGridView5.Columns.Insert(11, colApproval)

    End Sub


    Sub LoadPURCHASEDList_supplier1()

        If txtSUPPLIER_1.Text = String.Empty Then

            dataGridView1.Rows.Clear()

        Else

            dataGridView1.Rows.Clear()

            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedrequest_all where `pr_no` like '" & txtCONTROL.Text & "'  AND `supplier_1` like '" & txtSUPPLIER_1.Text & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                dataGridView1.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, CDbl(dr.Item("unit_price_1").ToString).ToString("#,##0.000"), dr.Item("vat_amount_1").ToString, dr.Item("total_amount_1").ToString)

            End While
            dr.Close()
            cn.Close()

        End If

    End Sub

    Sub LoadPURCHASEDList_supplier2()

        If txtSUPPLIER_2.Text = String.Empty Then

            DataGridView2.Rows.Clear()

        Else

            DataGridView2.Rows.Clear()

            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedrequest_all where `pr_no` like '" & txtCONTROL.Text & "'  AND `supplier_2` like '" & txtSUPPLIER_2.Text & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                DataGridView2.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, CDbl(dr.Item("unit_price_2").ToString).ToString("#,##0.000"), dr.Item("vat_amount_2").ToString, dr.Item("total_amount_2").ToString)

            End While
            dr.Close()
            cn.Close()

        End If

    End Sub

    Sub LoadPURCHASEDList_supplier3()

        If txtSUPPLIER_3.Text = String.Empty Then

            DataGridView3.Rows.Clear()

        Else

            DataGridView3.Rows.Clear()

            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedrequest_all where `pr_no` like '" & txtCONTROL.Text & "'  AND `supplier_3` like '" & txtSUPPLIER_3.Text & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                DataGridView3.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, CDbl(dr.Item("unit_price_3").ToString).ToString("#,##0.000"), dr.Item("vat_amount_3").ToString, dr.Item("total_amount_3").ToString)

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
            LoadPURCHASEDList_select1()
            LoadPURCHASEDList_select2()
            LoadPURCHASEDList_select3()
            LoadPURCHASEDList()
            Supplier_sum()
            Supplier_sumselect()
            Supplier_sumALL()
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

    Sub Supplier_sumALL()

        Dim TOTALUNIT_1 As Decimal = 0
        For i = 0 To dataGridView1.Rows.Count - 1
            TOTALUNIT_1 += DataGridView4.Rows(i).Cells(4).Value
        Next

        Dim VATTOTAL_1 As Decimal = 0
        For i = 0 To dataGridView1.Rows.Count - 1
            VATTOTAL_1 += DataGridView4.Rows(i).Cells(5).Value
        Next

        Dim GRANDTOTAL_1 As Decimal = 0
        For i = 0 To dataGridView1.Rows.Count - 1
            GRANDTOTAL_1 += DataGridView4.Rows(i).Cells(6).Value
        Next

        '=======================================================================

        Dim TOTALUNIT_2 As Decimal = 0
        For i = 0 To DataGridView2.Rows.Count - 1
            TOTALUNIT_2 += DataGridView4.Rows(i).Cells(8).Value
        Next

        Dim VATTOTAL_2 As Decimal = 0
        For i = 0 To DataGridView2.Rows.Count - 1
            VATTOTAL_2 += DataGridView4.Rows(i).Cells(9).Value
        Next

        Dim GRANDTOTAL_2 As Decimal = 0
        For i = 0 To DataGridView2.Rows.Count - 1
            GRANDTOTAL_2 += DataGridView4.Rows(i).Cells(10).Value
        Next

        '=======================================================================

        Dim TOTALUNIT_3 As Decimal = 0
        For i = 0 To DataGridView3.Rows.Count - 1
            TOTALUNIT_3 += DataGridView4.Rows(i).Cells(12).Value
        Next

        Dim VATTOTAL_3 As Decimal = 0
        For i = 0 To DataGridView3.Rows.Count - 1
            VATTOTAL_3 += DataGridView4.Rows(i).Cells(13).Value
        Next


        Dim GRANDTOTAL_3 As Decimal = 0
        For i = 0 To DataGridView3.Rows.Count - 1
            GRANDTOTAL_3 += DataGridView4.Rows(i).Cells(14).Value
        Next

        '=======================================================================

        txtUNIT1.Text = CDbl(TOTALUNIT_1).ToString("#,##0.000")
        txtVAT1.Text = CDbl(VATTOTAL_1).ToString("#,##0.000")
        txtTOTAL1.Text = CDbl(GRANDTOTAL_1).ToString("#,##0.000")

        txtUNIT2.Text = CDbl(TOTALUNIT_2).ToString("#,##0.000")
        txtVAT2.Text = CDbl(VATTOTAL_2).ToString("#,##0.000")
        txtTOTAL2.Text = CDbl(GRANDTOTAL_2).ToString("#,##0.000")

        txtUNIT3.Text = CDbl(TOTALUNIT_3).ToString("#,##0.000")
        txtVAT3.Text = CDbl(VATTOTAL_3).ToString("#,##0.000")
        txtTOTAL3.Text = CDbl(GRANDTOTAL_3).ToString("#,##0.000")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        PageSetupDialog1.Document = PrintDocument1
        PageSetupDialog1.Document.DefaultPageSettings.Color = False
        PageSetupDialog1.Document.DefaultPageSettings.Landscape = True
        PageSetupDialog1.ShowDialog()

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

            Dim rect1 As New Rectangle(50, 80, 950, 25)

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

        For i = 0 To dataGridView1.Rows.Count - 1
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
            e.Graphics.DrawString(txtSELECT_UNIT1.Text, line, Brushes.Black, total4, right)
            e.Graphics.DrawString(txtSELECT_VAT1.Text, line, Brushes.Black, total5, right)
            e.Graphics.DrawString(txtSELECT_TOTAL1.Text, line, Brushes.Black, total6, right)

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

            If DataGridView8.CurrentCell Is Nothing Then

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
            e.Graphics.DrawString("EMELYN TORIBIO", sign11, Brushes.Black, sign2, left)
            e.Graphics.DrawString("LERMA STA. CRUZ", sign11, Brushes.Black, sign3, left)
            e.Graphics.DrawString("DIVINA GRACIA YAPJUANGCO", sign11, Brushes.Black, sign4, left)

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

        For i = 0 To DataGridView2.Rows.Count - 1
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

            e.Graphics.DrawString(txtSELECT_UNIT2.Text, line, Brushes.Black, total4, right)
            e.Graphics.DrawString(txtSELECT_VAT2.Text, line, Brushes.Black, total5, right)
            e.Graphics.DrawString(txtSELECT_TOTAL2.Text, line, Brushes.Black, total6, right)

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

            If DataGridView7.CurrentCell Is Nothing Then

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

        For i = 0 To DataGridView3.Rows.Count - 1
            z += 17

            Dim supp1 As New Rectangle(1053, 220, 245, 14)

            Dim brush1 As SolidBrush = New SolidBrush(Color.Black)
            e.Graphics.FillRectangle(brush1, supp1)

            e.Graphics.DrawRectangle(Pens.White, supp1)

            e.Graphics.DrawString(txtSUPPLIER_3.Text, line, Brushes.White, supp1, center)

            '===============================================================================

            Dim total1 As New Rectangle(1053, 235, 75, 14)
            Dim total2 As New Rectangle(1138, 235, 75, 14)
            Dim total3 As New Rectangle(1223, 235, 75, 14)

            Dim total4 As New Rectangle(1053, 250, 75, 14)
            Dim total5 As New Rectangle(1138, 250, 75, 14)
            Dim total6 As New Rectangle(1223, 250, 75, 14)

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
            e.Graphics.DrawString(txtSELECT_UNIT3.Text, line, Brushes.Black, total4, right)
            e.Graphics.DrawString(txtSELECT_VAT3.Text, line, Brushes.Black, total5, right)
            e.Graphics.DrawString(txtSELECT_TOTAL3.Text, line, Brushes.Black, total6, right)

            '================================================================================

            Dim box3 As New Rectangle(1053, 270, 75, 14)
            Dim box4 As New Rectangle(1138, 270, 75, 14)
            Dim box5 As New Rectangle(1223, 270, 75, 14)


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

            Dim data3 As New Rectangle(1053, z, 75, 14)
            Dim data4 As New Rectangle(1138, z, 75, 14)
            Dim data5 As New Rectangle(1223, z, 75, 14)

            Dim brush4 As SolidBrush = New SolidBrush(Color.White)

            e.Graphics.FillRectangle(brush4, data3)
            e.Graphics.FillRectangle(brush4, data4)
            e.Graphics.FillRectangle(brush4, data5)

            e.Graphics.DrawRectangle(Pens.Black, data3)
            e.Graphics.DrawRectangle(Pens.Black, data4)
            e.Graphics.DrawRectangle(Pens.Black, data5)

            If DataGridView6.CurrentCell Is Nothing Then

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

    Sub LoadPURCHASEDList_select1()

        If txtSUPPLIER_1.Text = String.Empty Then

            DataGridView8.Rows.Clear()

        Else

            DataGridView8.Rows.Clear()

            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedrequestlist where `pr_no` like '" & txtCONTROL.Text & "'  AND `supplier_name` like '" & txtSUPPLIER_1.Text & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                DataGridView8.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, CDbl(dr.Item("unit_price").ToString).ToString("#,##0.000"), dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString)

            End While
            dr.Close()
            cn.Close()

        End If

    End Sub


    Sub LoadPURCHASEDList_select2()

        If txtSUPPLIER_2.Text = String.Empty Then

            DataGridView7.Rows.Clear()

        Else

            DataGridView7.Rows.Clear()

            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedrequestlist where `pr_no` like '" & txtCONTROL.Text & "'  AND `supplier_name` like '" & txtSUPPLIER_2.Text & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                DataGridView7.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, CDbl(dr.Item("unit_price").ToString).ToString("#,##0.000"), dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString)

            End While
            dr.Close()
            cn.Close()

        End If

    End Sub

    Sub LoadPURCHASEDList_select3()

        If txtSUPPLIER_3.Text = String.Empty Then

            DataGridView6.Rows.Clear()

        Else

            DataGridView6.Rows.Clear()

            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedrequestlist where `pr_no` like '" & txtCONTROL.Text & "'  AND `supplier_name` like '" & txtSUPPLIER_3.Text & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                DataGridView6.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, CDbl(dr.Item("unit_price").ToString).ToString("#,##0.000"), dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString)

            End While
            dr.Close()
            cn.Close()

        End If

    End Sub


    Private Sub frm8SI_PR_FORM_RECORD_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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