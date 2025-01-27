Public Class frm8SI_PO_RECORD

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

    Private Sub txtCONTROL_TextChanged(sender As Object, e As EventArgs)

        txtREFERENCE.Text = txtCONTROL.Text

    End Sub

    Sub LoadItemList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_purchasedorderlist where `po_no` like '" & txtPONO.Text & "' and supplier_name like '" & txtSUPPLIER.Text & "'", cn)
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

    Sub SaveInPOList()

        For Each row_1 As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tbl_8si_purchasedorderlist (po_no, pr_no, supplier_name, delivery_address, quantity, unit, item_name, unit_price, vat_amount, grand_total) values(@po_no, @pr_no, @supplier_name, @delivery_address, @quantity, @unit, @item_name, @unit_price, @vat_amount, @grand_total)", cn)

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
            btnPRINT.Enabled = False
        Next

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If txtTYPE.Text = "ADMINISTRATOR" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedorder where `po_no` like '%" & TextBox1.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("po_no").ToString, dr.Item("pr_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("shipping_method").ToString, dr.Item("payment_terms").ToString, dr.Item("required_date").ToString, dr.Item("delivery_address").ToString, dr.Item("supplier").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString)

            End While

            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedorder where `po_no` like '%" & TextBox1.Text & "%' AND `department` like '%" & txtDEPARTMENTDATA.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("po_no").ToString, dr.Item("pr_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("shipping_method").ToString, dr.Item("payment_terms").ToString, dr.Item("required_date").ToString, dr.Item("delivery_address").ToString, dr.Item("supplier").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString)

            End While

            dr.Close()
            cn.Close()

        End If


    End Sub

    Private Sub DataGridView2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView2.CurrentCellDirtyStateChanged

        DataGridView2.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        Dim colname As String = DataGridView2.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedorder where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
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

            End While
            dr.Close()
            cn.Close()
            LoadItemList()
            Supplier_sum()

            btnPRINT.Enabled = True
        End If

    End Sub

    Sub LoadPOList()

        If txtTYPE.Text = "ADMINISTRATOR" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedorder", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("po_no").ToString, dr.Item("pr_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("shipping_method").ToString, dr.Item("payment_terms").ToString, dr.Item("required_date").ToString, dr.Item("delivery_address").ToString, dr.Item("supplier").ToString)

            End While

            dr.Close()
            cn.Close()

        ElseIf txtTYPE.Text = "USER" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedorder where `department` like '%" & txtDEPARTMENTDATA.Text & "%' ", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("po_no").ToString, dr.Item("pr_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("date").ToString, dr.Item("shipping_method").ToString, dr.Item("payment_terms").ToString, dr.Item("required_date").ToString, dr.Item("delivery_address").ToString, dr.Item("supplier").ToString)

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
        DataGridView2.Columns.Insert(12, colApproval)

    End Sub

    Private Sub btnPRINT_Click_1(sender As Object, e As EventArgs) Handles btnPRINT.Click

        PrintPreviewDialog1.Document = PrintDocument1
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

        'height, width, length, 
        Dim rect1 As New Rectangle(50, 100, 750, 25)
        Dim brush As SolidBrush = New SolidBrush(Color.Black)
        e.Graphics.FillRectangle(brush, rect1)

        e.Graphics.DrawRectangle(Pens.Black, rect1)

        e.Graphics.DrawImage(Me.PictureBox1.Image, 320, 30, PictureBox1.Width - 15, PictureBox1.Height - 25)

        e.Graphics.DrawString("PURCHASE ORDER", header, Brushes.White, rect1, center)

        '================================================================================

        Dim title As New Font("Arial Black", 8, FontStyle.Bold)
        Dim control As New Font("Arial", 8, FontStyle.Regular)
        Dim sign As New Font("CAMBRIA", 8, FontStyle.Bold)
        Dim name As New Font("CAMBRIA", 8, FontStyle.Underline)
        Dim label As New Font("CAMBRIA", 8, FontStyle.Italic)
        Dim line As New Font("Arial Black", 8, FontStyle.Bold)
        Dim data As New Font("CAMBRIA", 10, FontStyle.Bold)


        e.Graphics.DrawString("PO#", sign, Brushes.Black, 400, 150)
        e.Graphics.DrawString("SUPPLIER NAME", sign, Brushes.Black, 400, 170)
        e.Graphics.DrawString("PAYMENT TERMS", sign, Brushes.Black, 400, 190)
        e.Graphics.DrawString("SHIPPING METHOD", sign, Brushes.Black, 400, 210)

        e.Graphics.DrawString("DATE", sign, Brushes.Black, 50, 150)
        e.Graphics.DrawString("PR NO", sign, Brushes.Black, 50, 170)
        e.Graphics.DrawString("REQUIRED DATE", sign, Brushes.Black, 50, 190)
        e.Graphics.DrawString("DELIVERY ADDRESS", sign, Brushes.Black, 50, 210)

        e.Graphics.DrawString(txtNAME.Text, sign, Brushes.Black, 50, 240)
        e.Graphics.DrawString(txtADDRESS.Text, sign, Brushes.Black, 50, 260)
        e.Graphics.DrawString(txtPERSON.Text, sign, Brushes.Black, 50, 280)

        e.Graphics.DrawString(":", title, Brushes.Black, 510, 150)
        e.Graphics.DrawString(":", title, Brushes.Black, 510, 170)
        e.Graphics.DrawString(":", title, Brushes.Black, 510, 190)
        e.Graphics.DrawString(":", title, Brushes.Black, 510, 210)

        e.Graphics.DrawString(":", title, Brushes.Black, 200, 150)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 170)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 190)
        e.Graphics.DrawString(":", title, Brushes.Black, 200, 210)

        e.Graphics.DrawString(txtPONO.Text, title, Brushes.Black, 520, 150)
        e.Graphics.DrawString(txtSUPPLIER.Text, title, Brushes.Black, 520, 170)
        e.Graphics.DrawString(txtPAYMENTTERMS.Text, title, Brushes.Black, 520, 190)
        e.Graphics.DrawString(txtSHIPPINGMETHOD.Text, title, Brushes.Black, 520, 210)

        e.Graphics.DrawString(txtDATE.Text, title, Brushes.Black, 230, 150)
        e.Graphics.DrawString(txtCONTROL.Text, title, Brushes.Black, 230, 170)
        e.Graphics.DrawString(txtREQUIREDDATE.Text, title, Brushes.Black, 230, 190)
        e.Graphics.DrawString(txtDELIVERYADDRESS.Text, title, Brushes.Black, 230, 210)

        '================================================================================

        Dim box1 As New Rectangle(50, 300, 90, 18)
        Dim box2 As New Rectangle(140, 300, 60, 18)
        Dim box3 As New Rectangle(200, 300, 400, 18)
        Dim box4 As New Rectangle(600, 300, 100, 18)
        Dim box5 As New Rectangle(700, 300, 100, 18)

        Dim total1 As New Rectangle(580, 240, 120, 18)
        Dim total2 As New Rectangle(580, 260, 120, 18)
        Dim total3 As New Rectangle(580, 280, 120, 18)

        Dim totaldata1 As New Rectangle(700, 240, 100, 18)
        Dim totaldata2 As New Rectangle(700, 260, 100, 18)
        Dim totaldata3 As New Rectangle(700, 280, 100, 18)

        Dim brush3 As SolidBrush = New SolidBrush(Color.Black)
        e.Graphics.FillRectangle(brush3, box1)
        e.Graphics.FillRectangle(brush3, box2)
        e.Graphics.FillRectangle(brush3, box3)
        e.Graphics.FillRectangle(brush3, box4)
        e.Graphics.FillRectangle(brush3, box5)

        Dim totalbrush1 As SolidBrush = New SolidBrush(Color.Red)
        e.Graphics.FillRectangle(totalbrush1, total1)
        e.Graphics.FillRectangle(totalbrush1, total2)
        e.Graphics.FillRectangle(totalbrush1, total3)

        Dim totalbrush2 As SolidBrush = New SolidBrush(Color.White)
        e.Graphics.FillRectangle(totalbrush2, totaldata1)
        e.Graphics.FillRectangle(totalbrush2, totaldata2)
        e.Graphics.FillRectangle(totalbrush2, totaldata3)

        e.Graphics.DrawRectangle(Pens.White, box1)
        e.Graphics.DrawRectangle(Pens.White, box2)
        e.Graphics.DrawRectangle(Pens.White, box3)
        e.Graphics.DrawRectangle(Pens.White, box4)
        e.Graphics.DrawRectangle(Pens.White, box5)

        e.Graphics.DrawRectangle(Pens.White, total1)
        e.Graphics.DrawRectangle(Pens.White, total2)
        e.Graphics.DrawRectangle(Pens.White, total3)

        e.Graphics.DrawRectangle(Pens.Black, totaldata1)
        e.Graphics.DrawRectangle(Pens.Black, totaldata2)
        e.Graphics.DrawRectangle(Pens.Black, totaldata3)

        e.Graphics.DrawString("QTY", line, Brushes.White, box1, center)
        e.Graphics.DrawString("UNIT", line, Brushes.White, box2, center)
        e.Graphics.DrawString("DESCRIPTION", line, Brushes.White, box3, center)
        e.Graphics.DrawString("UNIT PRICE", line, Brushes.White, box4, center)
        e.Graphics.DrawString("AMOUNT", line, Brushes.White, box5, center)

        e.Graphics.DrawString("TOTAL VAT(EX)", title, Brushes.White, 580, 240, left)
        e.Graphics.DrawString("VAT", title, Brushes.White, 580, 260, left)
        e.Graphics.DrawString("GRAND TOTAL", title, Brushes.White, 580, 280, left)

        e.Graphics.DrawString(txtTOTALUNIT_1.Text, title, Brushes.Black, totaldata1, right)
        e.Graphics.DrawString(txtVATTOTAL_1.Text, title, Brushes.Black, totaldata2, right)
        e.Graphics.DrawString(txtGRANDTOTAL_1.Text, title, Brushes.Black, totaldata3, right)

        '================================================================================

        Dim y As Integer = 300

        For i = 0 To dataGridView1.Rows.Count - 1
            y += 18

            Dim data1 As New Rectangle(50, y, 90, 18)
            Dim data2 As New Rectangle(140, y, 60, 18)
            Dim data3 As New Rectangle(200, y, 400, 18)
            Dim data4 As New Rectangle(600, y, 100, 18)
            Dim data5 As New Rectangle(700, y, 100, 18)

            Dim brush5 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush5, data1)
            e.Graphics.FillRectangle(brush5, data2)
            e.Graphics.FillRectangle(brush5, data3)
            e.Graphics.FillRectangle(brush5, data4)
            e.Graphics.FillRectangle(brush5, data5)

            e.Graphics.DrawRectangle(Pens.Black, data1)
            e.Graphics.DrawRectangle(Pens.Black, data2)
            e.Graphics.DrawRectangle(Pens.Black, data3)
            e.Graphics.DrawRectangle(Pens.Black, data4)
            e.Graphics.DrawRectangle(Pens.Black, data5)

            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(0).Value, data, Brushes.Black, data1, center)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(1).Value, data, Brushes.Black, data2, center)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(2).Value, data, Brushes.Black, data3, left)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(3).Value, data, Brushes.Black, data4, center)
            e.Graphics.DrawString(dataGridView1.Rows(i).Cells(5).Value, data, Brushes.Black, data5, center)

            Dim x As Integer = 700

            x += 18

            Dim title1 As New Rectangle(50, x, 189, 20)
            Dim title2 As New Rectangle(239, x, 189, 20)
            Dim title3 As New Rectangle(428, x, 189, 20)
            Dim title4 As New Rectangle(617, x, 189, 20)

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
            e.Graphics.DrawString("APPROVED BY:", sign, Brushes.Black, title2, left)
            'e.Graphics.DrawString("APPROVED BY:", sign, Brushes.Black, title3, left)
            'e.Graphics.DrawString("APPROVED BY:", sign, Brushes.Black, title4, left)

            '=============================================================================

            Dim s As Integer = 740

            s += 18

            Dim sign1 As New Rectangle(50, s, 189, 20)
            Dim sign2 As New Rectangle(239, s, 189, 20)
            Dim sign3 As New Rectangle(428, s, 189, 20)
            Dim sign4 As New Rectangle(617, s, 189, 20)

            Dim brush7 As SolidBrush = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(brush7, sign1)
            e.Graphics.FillRectangle(brush7, sign2)
            e.Graphics.FillRectangle(brush7, sign3)
            e.Graphics.FillRectangle(brush7, sign4)

            e.Graphics.DrawRectangle(Pens.White, sign1)
            e.Graphics.DrawRectangle(Pens.White, sign2)
            e.Graphics.DrawRectangle(Pens.White, sign3)
            e.Graphics.DrawRectangle(Pens.White, sign4)

            e.Graphics.DrawString(txtEMPLOYEE.Text, sign, Brushes.Black, sign1, left)
            e.Graphics.DrawString("EMELYN TORIBIO", sign, Brushes.Black, sign2, left)
            'e.Graphics.DrawString("LERMA STA. CRUZ", sign, Brushes.Black, sign3, left)
            'e.Graphics.DrawString("DIVINA GRACIA YAPJUANGCO", sign, Brushes.Black, sign4, left)

            '=============================================================================

            Dim l As Integer = 760

            l += 18

            Dim label1 As New Rectangle(50, l, 189, 20)
            Dim label2 As New Rectangle(239, l, 189, 20)
            Dim label3 As New Rectangle(428, l, 189, 20)
            Dim label4 As New Rectangle(617, l, 189, 20)

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
            e.Graphics.DrawString("DEPARTMENT MANAGER", label, Brushes.Black, label2, left)
            ' e.Graphics.DrawString("GENERAL MANAGER", label, Brushes.Black, label3, left)
            ' e.Graphics.DrawString("CHIEF OPERATING OFFICER", label, Brushes.Black, label4, left)


            'Dim terms1 As New Rectangle(50, 800, 800, 18)
            'Dim terms2 As New Rectangle(50, 820, 800, 18)
            'Dim terms3 As New Rectangle(50, 840, 800, 18)
            'Dim terms4 As New Rectangle(50, 860, 800, 18)
            'Dim terms5 As New Rectangle(50, 890, 800, 18)

            'Dim termsbrush1 As SolidBrush = New SolidBrush(Color.White)
            'e.Graphics.FillRectangle(termsbrush1, terms1)
            'e.Graphics.FillRectangle(termsbrush1, terms2)
            'e.Graphics.FillRectangle(termsbrush1, terms3)
            'e.Graphics.FillRectangle(termsbrush1, terms4)
            'e.Graphics.FillRectangle(termsbrush1, terms5)

            'e.Graphics.DrawRectangle(Pens.Black, terms1)
            'e.Graphics.DrawRectangle(Pens.Black, terms2)
            'e.Graphics.DrawRectangle(Pens.Black, terms3)
            'e.Graphics.DrawRectangle(Pens.Black, terms4)
            'e.Graphics.DrawRectangle(Pens.Black, terms5)

            'e.Graphics.DrawString("Terms and Conditions", title, Brushes.Black, terms1, left)
            'e.Graphics.DrawString("1. This Purchase Order is given subject to supplier's ability to meet the delivery dates herein stated. Changes to delivery date may result in changes to or cancellation of this Purchase Order.", title, Brushes.Black, terms2, left)
            'e'.Graphics.DrawString("2. This Purchase Order is given subject to the quality, shelf life and specifications of the items or services ordered being in conformity with 8sonaka", title, Brushes.Black, terms3, left)
            'e.Graphics.DrawString("", title, Brushes.Black, terms4, left)
            'e.Graphics.DrawString("", title, Brushes.Black, terms5, left)

        Next

    End Sub

    Private Sub txtDELIVERYADDRESS_TextChanged(sender As Object, e As EventArgs) Handles txtDELIVERYADDRESS.TextChanged

        If txtDELIVERYADDRESS.Text = String.Empty Then

            txtNAME.Text = ""
            txtADDRESS.Text = ""
            txtPERSON.Text = ""

        ElseIf txtDELIVERYADDRESS.Text = "WAREHOUSE" Then

            txtNAME.Text = "WAREHOUSE"
            txtADDRESS.Text = "276 M.A REYES SAN JUAN CITY"
            txtPERSON.Text = "ATTN:MARVIN HIPOLITO  (WAREHOUSE SUPERVISOR)"

        ElseIf txtDELIVERYADDRESS.Text = "HEAD OFFICE" Then

            txtNAME.Text = "HEAD OFFICE"
            txtADDRESS.Text = "290 P.GUEVARRA ST. SAN JUAN METRO MANILA"
            txtPERSON.Text = "ATTN:EMELYN TORIBIO  (PURCHASING MANAGER)"

        ElseIf txtDELIVERYADDRESS.Text = "AMR" Then

            txtNAME.Text = "A.M. Rieta Chemicals, Trading and Manufacturing"
            txtADDRESS.Text = "KALAYAAN ROAD, ADVINCULA AVE., SAN SEBASTIAN, KAWIT, CAVITE"
            txtPERSON.Text = "(046)454-3640 / 09209202788 / amrietachemical@yahoo.com"

        ElseIf txtDELIVERYADDRESS.Text = "BTTC" Then

            txtNAME.Text = "THE ICON CLINIC"
            txtADDRESS.Text = "UNIT G3 BTTC CENTRE 288 ORTIGAS AVE, CORNER ROOSEVELT, SAN JUAN CITY"
            txtPERSON.Text = "0920 947 6202"

        ElseIf txtDELIVERYADDRESS.Text = "VERSAMAN" Then

            txtNAME.Text = "VERSAMAN CONSUMER PRODUCTS MANUFACTURING"
            txtADDRESS.Text = "49 FR M Altoveros St., Brgy. Bagbaguin, Meycauayan City, Bulacan"
            txtPERSON.Text = " "

        End If

    End Sub

    Private Sub frm8SI_PO_RECORD_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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