Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmTIC_PO_RETURN_FORM

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
                cm = New MySqlCommand("Update tbl_tic_purchasedorder set required_date=@required_date, status=@status where id=@id", cn)
                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@required_date", txtREQUIREDDATE.Text)

                    .AddWithValue("@status", "ACTIVE")

                End With
                cm.ExecuteNonQuery()
                cn.Close()
                DeleteInPOList()
                SaveInPOList()

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
        Next

        MsgBox("Purchased Order has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        If txtSEARCHNAME.Text <> "" Then

            txtSEARCHNAME.Text = ""

        End If

        If txtSHIPPINGMETHOD.Text = "" Or txtPAYMENTTERMS.Text = "" Or txtDELIVERYADDRESS.Text = "" Then

            MsgBox("Please input all data!", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_tic_purchasedorder set required_date=@required_date, coo_comment=@coo_comment, status=@status where id=@id", cn)
                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@required_date", txtREQUIREDDATE.Text)

                    .AddWithValue("@coo_comment", txtMANAGERCOMMENT.Text & " - " & DateTimePicker1.Value)
                    .AddWithValue("@status", "RETURN")
                End With
                cm.ExecuteNonQuery()
                cn.Close()
                DeleteInPOList()
                SaveInPOList()

            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        End If

    End Sub


    Private Sub frmTIC_PO_RETURN_FORM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtCOOCOMMENT.Text
            .ShowDialog()

        End With

    End Sub
End Class