Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmTIC_PO_FORM

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        frmPAYMENTTERMS.StartPosition = FormStartPosition.CenterParent
        frmPAYMENTTERMS.ShowDialog()


    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        LoadPaymentTerms()

    End Sub

    Private Sub txtCONTROL_TextChanged(sender As Object, e As EventArgs) Handles txtCONTROL.TextChanged

        txtREFERENCE.Text = txtCONTROL.Text

    End Sub

    Sub LoadItemList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_purchasedrequestlist where `pr_no` like '" & txtREFERENCE.Text & "' and supplier_name like '" & txtSUPPLIER.Text & "'", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            dataGridView1.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, dr.Item("unit_price").ToString, dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtSUPPLIER_TextChanged(sender As Object, e As EventArgs) Handles txtSUPPLIER.TextChanged

        LoadItemList()
        Supplier_sum()
        LoadPaymentTerms()
        loadORIGIN()

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

        If txtTOTALUNIT_1.Text = 0 Then

            MsgBox("Please Select Supplier!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

        If txtSHIPPINGMETHOD.Text = "" Or txtPAYMENTTERMS.Text = "" Or txtDELIVERYADDRESS.Text = "" Then

            MsgBox("Please input all data!", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            reloadtextPO("Select * from tbl_tic_purchasedorder where pr_no='" & txtREFERENCE.Text & "' AND supplier='" & txtSUPPLIER.Text & "' ")

            If dt.Rows.Count > 0 Then
                MsgBox("Already Exist!", vbOKOnly + vbCritical, "CONFIRMATION")

            Else

                If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                    cn.Open()
                    cm = New MySqlCommand("INSERT into tbl_tic_purchasedorder (pr_no, employee, department, date, shipping_method, payment_terms, required_date, delivery_address, supplier, date_time, MANAGER_APPROVAL, GM_APPROVAL, COO_APPROVAL, status, manager_comment, gm_comment, coo_comment) values(@pr_no, @employee, @department, @date, @shipping_method, @payment_terms, @required_date, @delivery_address, @supplier, @date_time, @MANAGER_APPROVAL, @GM_APPROVAL, @COO_APPROVAL, @status, @manager_comment, @gm_comment, @coo_comment)", cn)
                    With cm.Parameters

                        .AddWithValue("@pr_no", txtREFERENCE.Text)
                        .AddWithValue("@employee", txtEMPLOYEE.Text)
                        .AddWithValue("@department", txtDEPARTMENT.Text)
                        .AddWithValue("@date", txtDATE.Text)
                        .AddWithValue("@shipping_method", txtSHIPPINGMETHOD.Text)
                        .AddWithValue("@payment_terms", txtPAYMENTTERMS.Text)
                        .AddWithValue("@required_date", txtREQUIREDDATE.Text)

                        .AddWithValue("@delivery_address", txtDELIVERYADDRESS.Text)
                        .AddWithValue("@supplier", txtSUPPLIER.Text)

                        .AddWithValue("@MANAGER_APPROVAL", "FOR APPROVAL")
                        .AddWithValue("@manager_comment", "-")

                        .AddWithValue("@GM_APPROVAL", "FOR APPROVAL")
                        .AddWithValue("@gm_comment", "-")

                        .AddWithValue("@COO_APPROVAL", "FOR APPROVAL")
                        .AddWithValue("@coo_comment", "-")

                        .AddWithValue("@date_time", DateTimePicker1.Value)
                        .AddWithValue("@status", "ACTIVE")

                    End With

                    cm.ExecuteNonQuery()
                    cn.Close()
                    DisplayPO()
                    UpdateRequestSelect()
                    SaveInPOList()
                    SaveUPDATELIST()
                    SaveUPDATE_COUNT()
                    UpdateRequest()
                    LoadSupplierList()
                    SaveSupplier()


                Else

                    MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

                End If

            End If
        End If

    End Sub

    Sub SaveSupplier()

        Try
            cn.Open()
            cm = New MySqlCommand("INSERT into tbl_warehouse_po_tic (po_no, supplier_name, location_1, location_2, location_3, location_4, location_5, status) values(@po_no, @supplier_name, @location_1, @location_2, @location_3, @location_4, @location_5, @status)", cn)

            With cm.Parameters

                .AddWithValue("@po_no", txtPONO.Text)
                .AddWithValue("@supplier_name", txtSUPPLIER.Text)

                .AddWithValue("@location_1", txtDELIVERYADDRESS.Text)
                .AddWithValue("@location_2", " ")
                .AddWithValue("@location_3", " ")
                .AddWithValue("@location_4", " ")
                .AddWithValue("@location_5", " ")
                .AddWithValue("@status", " ")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception

            cn.Close()
            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Sub SaveUPDATELIST()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_purchasedrequest_select where `pr_no` like '" & txtCONTROL.Text & "' AND `status` like 'ACTIVE' ", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtSELECTSUPPLIER.Items.Add(dr.Item("supplier_name").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub SaveUPDATE_COUNT()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_purchasedrequest_select where `pr_no` like '" & txtCONTROL.Text & "' AND `status` like 'ACTIVE' ", cn)

        dr = cm.ExecuteReader

        While dr.Read

            txtCOUNT.Text = dr("supplier_name").ToString()

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub UpdateRequest()

        If txtCOUNT.Text = String.Empty Then

            cn.Open()
            cm = New MySqlCommand("Update tbl_tic_purchasedrequest set status=@status where id=@id", cn)

            With cm.Parameters

                .AddWithValue("@id", txtID.Text)
                .AddWithValue("@status", "DONE PO")

            End With

            cm.ExecuteNonQuery()
            cn.Close()

        Else

            Exit Sub

        End If

    End Sub

    Sub UpdateRequestSelect()

        cn.Open()
        cm = New MySqlCommand("Update tbl_tic_purchasedrequest_select set status=@status where pr_no=@pr_no and supplier_name=@supplier_name", cn)

        With cm.Parameters

            .AddWithValue("@pr_no", txtCONTROL.Text)
            .AddWithValue("@supplier_name", txtSELECTSUPPLIER.Text)
            .AddWithValue("@status", "DONE PO")

        End With

        cm.ExecuteNonQuery()
        cn.Close()

    End Sub


    Public Sub reloadtextPO(ByVal sql As String)
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

    Sub DisplayPO()

        cn.Open()
        adp = New MySqlDataAdapter("select * from tbl_tic_purchasedorder where pr_no='" & txtREFERENCE.Text & "' AND supplier='" & txtSUPPLIER.Text & "' ", cn)
        dt = New DataTable
        adp.Fill(dt)

        txtPONO.Text = dt.Rows(0)(1).ToString()

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

        Next

        MsgBox("Purchased Order has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

    End Sub

    Sub LoadPaymentTerms()

        txtPAYMENTTERMS.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblsupplier where `supplier_name` like '" & txtSUPPLIER.Text & "' ", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtPAYMENTTERMS.Items.Add(dr.Item("payment_terms_1").ToString)
            txtPAYMENTTERMS.Items.Add(dr.Item("payment_terms_2").ToString)
            txtPAYMENTTERMS.Items.Add(dr.Item("payment_terms_3").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub LoadSupplierList()

        txtSELECTSUPPLIER.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_purchasedrequest_select where `pr_no` like '" & txtCONTROL.Text & "' AND `status` like 'ACTIVE' ", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtSELECTSUPPLIER.Items.Add(dr.Item("supplier_name").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtSELECTSUPPLIER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtSELECTSUPPLIER.SelectedIndexChanged

        txtSUPPLIER.Text = txtSELECTSUPPLIER.Text

        LoadItemList()
        LoadPaymentTerms()

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If txtCOUNT.Text = String.Empty Then

            btnSAVE.Enabled = False

        Else

            txtPONO.Text = ""
            txtSUPPLIER.Text = ""
            btnSAVE.Enabled = True
            LoadSupplierList()
            LoadPaymentTerms()
            LoadItemList()

        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        PageSetupDialog1.Document = PrintDocument1
        PageSetupDialog1.Document.DefaultPageSettings.Color = False
        PageSetupDialog1.ShowDialog()

    End Sub

    Private Sub btnPRINT_Click(sender As Object, e As EventArgs) Handles btnPRINT.Click

        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()

    End Sub

    Sub loadORIGIN()

        cn.Open()
        cm = New MySqlCommand("select * from tblsupplier where `supplier_name` like '" & txtSUPPLIER.Text & "'", cn)

        dr = cm.ExecuteReader

        While dr.Read

            txtORIGIN.Text = dr("origin").ToString()

        End While

        dr.Close()
        cn.Close()

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
            e.Graphics.DrawString("REVIEWED BY:", sign, Brushes.Black, title2, left)
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
            'e.Graphics.DrawString("GENERAL MANAGER", label, Brushes.Black, label3, left)
            'e.Graphics.DrawString("CHIEF OPERATING OFFICER", label, Brushes.Black, label4, left)


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

    Private Sub txtDELIVERYADDRESS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtDELIVERYADDRESS.SelectedIndexChanged

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

        End If

    End Sub


    Private Sub frmTIC_PO_FORM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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