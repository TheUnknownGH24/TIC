Public Class frmWAREHOUSE_RR_RECORD

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

    Private Sub DataGridView2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView2.CurrentCellDirtyStateChanged

        DataGridView2.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub dataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles dataGridView1.CurrentCellChanged

        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        dataGridView1.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Sub LoadRRList()

        If txtTYPE.Text = "ADMINISTRATOR" Or txtPOSITION.Text = "MANAGER" Or txtPOSITION.Text = "SUPERVISOR" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_rr", cn)
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
            cm = New MySqlCommand("select * from tbl_warehouse_rr", cn)
            ' cm = New MySqlCommand("select * from tbl_warehouse_rr `warehouse` like '%" & txtWAREHOUSENAME.Text & "%'", cn)

            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("rr_no").ToString, dr.Item("reference_no").ToString, dr.Item("employee_name").ToString, dr.Item("date").ToString, dr.Item("supplier_name").ToString, dr.Item("purpose").ToString, dr.Item("sub_reference").ToString, dr.Item("reference").ToString, dr.Item("date_received").ToString, dr.Item("delivery_status").ToString, dr.Item("warehouse").ToString, dr.Item("supervisor_name").ToString, dr.Item("supervisor_approval").ToString, dr.Item("supervisor_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString)

            End While

            dr.Close()
            cn.Close()

        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        If txtTYPE.Text = "ADMINISTRATOR" Or txtPOSITION.Text = "MANAGER" Or txtPOSITION.Text = "SUPERVISOR" Then

            DataGridView2.Rows.Clear()
            Dim i As Integer
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_rr where rr_no like '%" & TextBox1.Text & "%' ", cn)
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
            cm = New MySqlCommand("select * from tbl_warehouse_rr where rr_no like '%" & TextBox1.Text & "%' ", cn)
            'cm = New MySqlCommand("select * from tbl_warehouse_rr where rr_no like '%" & TextBox1.Text & "%' and `warehouse` like '%" & txtWAREHOUSENAME.Text & "%'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("rr_no").ToString, dr.Item("reference_no").ToString, dr.Item("employee_name").ToString, dr.Item("date").ToString, dr.Item("supplier_name").ToString, dr.Item("purpose").ToString, dr.Item("sub_reference").ToString, dr.Item("reference").ToString, dr.Item("date_received").ToString, dr.Item("delivery_status").ToString, dr.Item("warehouse").ToString, dr.Item("supervisor_name").ToString, dr.Item("supervisor_approval").ToString, dr.Item("supervisor_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString)

            End While

            dr.Close()
            cn.Close()

        End If

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

                txtAPPROVAL_1.Text = DataGridView2.Rows(e.RowIndex).Cells(14).Value.ToString

                txtMANAGERCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(16).Value.ToString & " - " & DataGridView2.Rows(e.RowIndex).Cells(18).Value.ToString

                txtAPPROVAL_2.Text = DataGridView2.Rows(e.RowIndex).Cells(17).Value.ToString

                txtSTATUSDATA.Text = DataGridView2.Rows(e.RowIndex).Cells(19).Value.ToString

            End While
            dr.Close()
            cn.Close()

            LoadRRITEMLIST()

        End If

    End Sub

    Sub LoadRRITEMLIST()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_rr_item where `rr_no` like '" & txtCONTROL.Text & "' ", cn)
        dr = cm.ExecuteReader

        While dr.Read

            dataGridView1.Rows.Add(dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("unit").ToString, dr.Item("qty_loose").ToString, dr.Item("qty_case_bulk").ToString, dr.Item("per_case_bulk").ToString, dr.Item("total_quantity").ToString, dr.Item("unit_price").ToString, dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString, dr.Item("status").ToString, dr.Item("remaining").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub


    Private Sub btnSAVE_Click(sender As Object, e As EventArgs)

        Try

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_warehouse_rr set final_name=@final_name, final_approval=@final_approval, final_comment=@final_comment, status=@status where id=@id", cn)

                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)

                    .AddWithValue("@final_name", txtNAME.Text)
                    .AddWithValue("@final_approval", "APPROVED")
                    .AddWithValue("@final_comment", txtMANAGERCOMMENT.Text & "-" & DateTimePicker1.Value)

                    .AddWithValue("@status", "ACTIVE")

                End With

                cm.ExecuteNonQuery()
                cn.Close()

                LoadRRList()

                MsgBox("Receiving Report has been Successfully Approved!", vbInformation + vbOKOnly, "CONFIRMATION")

            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        Catch ex As Exception

            cn.Close()
            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtSUPERVISORCOMMENT.Text
            .ShowDialog()

        End With



    End Sub

    Private Sub btnPRINT_Click(sender As Object, e As EventArgs)

        Try

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_warehouse_rr set supervisor_approval=@supervisor_approval, final_name=@final_name, final_approval=@final_approval, final_comment=@final_comment, status=@status where id=@id", cn)

                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)

                    .AddWithValue("@supervisor_approval", "FOR APPROVAL")

                    .AddWithValue("@final_name", txtNAME.Text)
                    .AddWithValue("@final_approval", "FOR APPROVAL")
                    .AddWithValue("@final_comment", txtMANAGERCOMMENT.Text & "-" & DateTimePicker1.Value)

                    .AddWithValue("@status", "RETURNED")

                End With

                cm.ExecuteNonQuery()
                cn.Close()

                LoadRRList()

                MsgBox("Receiving Report has been Successfully Returned!", vbInformation + vbOKOnly, "CONFIRMATION")

            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        Catch ex As Exception

            cn.Close()
            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtMANAGERCOMMENT.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub btnPRINT_Click_1(sender As Object, e As EventArgs) Handles btnPRINT.Click

        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.Document.DefaultPageSettings.Landscape = True
        PrintPreviewDialog1.Document.DefaultPageSettings.PaperSize = New Printing.PaperSize("Custom", 850, 1100)
        PrintPreviewDialog1.ShowDialog()

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


    Private Sub frmWAREHOUSE_RR_RECORD_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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