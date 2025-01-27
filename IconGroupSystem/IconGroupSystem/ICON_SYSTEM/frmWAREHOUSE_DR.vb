Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Drawing.Printing

Public Class frmWAREHOUSE_DR

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim Longpaper As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If txtSO_NO.Text = "" Then

            MsgBox("All fields are Required", vbOKOnly + vbCritical, "CONFIRMATION")
        Else
            reloadtext("Select * from tbldeliveryreceipt where sales_orderno='" & txtSO_NO.Text & "' ")
            If dt.Rows.Count > 0 Then
                MsgBox("Sales Order Already Exist", vbOKOnly + vbCritical, "CONFIRMATION")

            Else

                If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                    cn.Open()
                    cm = New MySqlCommand("INSERT into tbldeliveryreceipt (sales_orderno, soldto, address, 	platforms, note, date) values(@sales_orderno, @soldto, @address, @platforms, @note, @date)", cn)
                    With cm.Parameters
                        .AddWithValue("@sales_orderno", txtSO_NO.Text)
                        .AddWithValue("@soldto", txtSOLDTO.Text)
                        .AddWithValue("@address", txtADDRESS.Text)
                        .AddWithValue("@platforms", txtPLATFORMS.Text)
                        .AddWithValue("@note", txtNOTE.Text)
                        .AddWithValue("@date", txtDATE.Text)
                    End With
                    cm.ExecuteNonQuery()
                    cn.Close()
                    DisplayDR()
                    SaveInDRList()
                    txtNOTE.Enabled = False

                Else

                    MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

                End If

            End If
        End If

    End Sub

    Sub DisplayDR()

        cn.Open()
        adp = New MySqlDataAdapter("select * from tbldeliveryreceipt where sales_orderno = '" & txtSO_NO.Text & "'", cn)
        dt = New DataTable
        adp.Fill(dt)

        txtDRNO.Text = dt.Rows(0)(1).ToString()

        cn.Close()

    End Sub

    Sub SaveInDRList()

        For Each row As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tbldeliveryreceipt_list (dr_no, so_no, product_name, unit_price, quantity, total) values(@dr_no, @so_no, @product_name, @unit_price, @quantity, @total)", cn)
            With cm.Parameters
                .AddWithValue("@dr_no", txtDRNO.Text)
                .AddWithValue("@so_no", txtSO_NO.Text)

                .AddWithValue("@product_code", row.Cells("PRODUCT_CODE").Value)
                .AddWithValue("@product_name", row.Cells("PRODUCT_NAME").Value)
                .AddWithValue("@unit_price", row.Cells("GROSS_SALES").Value)
                .AddWithValue("@quantity", row.Cells("QUANTITY").Value)
                .AddWithValue("@total", row.Cells("TOTAL").Value)
            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
        Next
        MsgBox("Delivery Receipt has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

    End Sub

    Public Sub reloadtext(ByVal sql As String)
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

    Sub Changelongpaper()
        Dim rowcount As Integer
        Longpaper = 0
        rowcount = dataGridView1.Rows.Count
        Longpaper = rowcount * 15
        Longpaper = Longpaper + 500

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Changelongpaper()
        PPD.Document = PD
        PPD.ShowDialog()

    End Sub

    Private Sub PD_BeginPrint(sender As Object, e As PrintEventArgs) Handles PD.BeginPrint

        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 250, Longpaper)
        PD.DefaultPageSettings = pagesetup

    End Sub

    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage

        Dim f8 As New Font("Cambria", 8, FontStyle.Regular)
        Dim f10 As New Font("Cambria", 10, FontStyle.Regular)
        Dim f10b As New Font("Cambria", 10, FontStyle.Bold)
        Dim f14 As New Font("Cambria", 14, FontStyle.Bold)

        Dim leftmargin As Integer = PD.DefaultPageSettings.Margins.Left
        Dim centermargin As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim rightmargin As Integer = PD.DefaultPageSettings.PaperSize.Width

        Dim right As New StringFormat
        Dim center As New StringFormat

        right.Alignment = StringAlignment.Far
        center.Alignment = StringAlignment.Center

        Dim line As String
        line = "__________________________________________________________________"

        e.Graphics.DrawString("Store", f14, Brushes.Black, centermargin, 5, center)
        e.Graphics.DrawString("SOURCE CODE PH", f10, Brushes.Black, centermargin, 25, center)
        e.Graphics.DrawString("RYAN CHRISTIAN MANALO", F10, Brushes.Black, centermargin, 40, center)

        e.Graphics.DrawString("Invoice#", f8, Brushes.Black, 0, 60)
        e.Graphics.DrawString("SOURCE CODE PH", f8, Brushes.Black, 50, 60)
        e.Graphics.DrawString("RYAN CHRISTIAN MANALO", f8, Brushes.Black, 70, 60)

        e.Graphics.DrawString("Cashier#", f8, Brushes.Black, 0, 75)
        e.Graphics.DrawString(":", f8, Brushes.Black, 50, 75)
        e.Graphics.DrawString("MAMA MO", f8, Brushes.Black, 70, 75)

        e.Graphics.DrawString("DATE" & Date.Now(), f8, Brushes.Black, 0, 90)
        'e.Graphics.DrawString(line, f8, Brushes.Black, 0, 100)



        Dim height As Integer
        Dim i As Long

        dataGridView1.AllowUserToAddRows = False

        For row As Integer = 0 To dataGridView1.RowCount - 1
            Height += 15
            e.Graphics.DrawString(dataGridView1.Rows(row).Cells(1).Value.ToString, f10, Brushes.Black, 0, 100 + height)
            e.Graphics.DrawString(dataGridView1.Rows(row).Cells(0).Value.ToString, f10, Brushes.Black, 25, 100 + height)

            i = dataGridView1.Rows(row).Cells(1).Value
            dataGridView1.Rows(row).Cells(1).Value = Format(i, "##,##0")
            e.Graphics.DrawString(dataGridView1.Rows(row).Cells(2).Value.ToString, f10, Brushes.Black, rightmargin, 100 + height, right)
        Next

        Dim height2 As Integer

        height2 = 110 + Height

        sumprice()

        e.Graphics.DrawString(line, f8, Brushes.Black, 0, height2)
        e.Graphics.DrawString("Total: " & Format(t_price, "##,##0"), f10b, Brushes.Black, rightmargin, 10 + height2, right)
        e.Graphics.DrawString(t_qty, f10b, Brushes.Black, 0, 10 + height2)
        e.Graphics.DrawString("Thanks for Shopping", f10, Brushes.Black, centermargin, 35 + height2, center)
        e.Graphics.DrawString("Source Code Ph", f10, Brushes.Black, centermargin, 50 + height2, center)


    End Sub

    Dim t_price As Long
    Dim t_qty As Long

    Sub sumprice()

        Dim countprice As Long = 0

        For rowitem As Long = 0 To DataGridView1.RowCount - 1
            countprice = countprice + Val(dataGridView1.Rows(rowitem).Cells(1).Value * dataGridView1.Rows(rowitem).Cells(1).Value)
        Next
        t_price = countprice

        Dim countqty As Long = 0
        For rowitem As Long = 0 To DataGridView1.RowCount - 1
            countqty = countqty + DataGridView1.Rows(rowitem).Cells(1).Value
        Next
        t_qty = countqty


    End Sub
End Class