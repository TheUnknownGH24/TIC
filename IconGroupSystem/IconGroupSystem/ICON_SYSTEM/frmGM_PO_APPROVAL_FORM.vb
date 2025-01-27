Imports MySql.Data.MySqlClient

Public Class frmGM_PO_APPROVAL_FORM

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Private Sub Button2_Click(sender As Object, e As EventArgs)

        frmPAYMENTTERMS.StartPosition = FormStartPosition.CenterParent
        frmPAYMENTTERMS.ShowDialog()

    End Sub

    Sub LoadPURCHASEDList()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblpurchasedorderlist where `po_no` like '%" & txtPONO.Text & "%' and `supplier_name` like '%" & txtSUPPLIER.Text & "%'", cn)
        dr = cm.ExecuteReader
        While dr.Read
            dataGridView1.Rows.Add(dr.Item("id").ToString, dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, dr.Item("unit_price").ToString, dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub


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

        If txtCONTROL.Text = String.Empty Then

            txtSUPPLIER_1.Text = "----------------------------------------------------------------------"
            txtSUPPLIER_2.Text = "----------------------------------------------------------------------"
            txtSUPPLIER_3.Text = "----------------------------------------------------------------------"

            txtSUPPLIER_1.Checked = False
            txtSUPPLIER_2.Checked = False
            txtSUPPLIER_3.Checked = False

        Else

            cn.Open()
            cm = New MySqlCommand("select * from tblpurchasedrequest where `pr_no` like '%" & txtCONTROL.Text & "%' and `COO_APPROVAL` like 'APPROVED'", cn)

            dr = cm.ExecuteReader

            While dr.Read

                txtSUPPLIER_1.Text = dr("supplier_1").ToString()
                txtSUPPLIER_2.Text = dr("supplier_2").ToString()
                txtSUPPLIER_3.Text = dr("supplier_3").ToString()

                txtREFERENCE.Text = dr("pr_no").ToString()

            End While

            dr.Close()
            cn.Close()

        End If


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
                cm = New MySqlCommand("Update tblpurchasedorder set po_no=@po_no, pr_no=@pr_no, employee=@employee, department=@department, date=@date, date=@date, shipping_method=@shipping_method, payment_terms=@payment_terms, required_date=@required_date, delivery_address=@delivery_address, supplier=@supplier, GM_APPROVAL=@GM_APPROVAL where id=@id", cn)


                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@po_no", txtPONO.Text)
                    .AddWithValue("@pr_no", txtREFERENCE.Text)
                    .AddWithValue("@employee", frm1HOME.txtHOMENAME.Text)
                    .AddWithValue("@department", frm1HOME.txtHOMEDEPARTMENT.Text)
                    .AddWithValue("@date", txtDATE.Text)
                    .AddWithValue("@shipping_method", txtSHIPPINGMETHOD.Text)
                    .AddWithValue("@payment_terms", txtPAYMENTTERMS.Text)
                    .AddWithValue("@required_date", txtREQUIREDDATE.Text)

                    .AddWithValue("@delivery_address", txtDELIVERYADDRESS.Text)
                    .AddWithValue("@supplier", txtSUPPLIER.Text)

                    .AddWithValue("@GM_APPROVAL", "APPROVED")
                    .AddWithValue("@gm_comment", txtREMARKS.Text & " - " & DateTimePicker1.Value)


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

        cm = New MySqlCommand("DELETE FROM tblpurchasedorderlist WHERE `po_no` like '%" & txtPONO.Text & "%'", cn)

        cn.Open()
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
        adp = New MySqlDataAdapter("select * from tblpurchasedorder where pr_no='" & txtREFERENCE.Text & "' AND supplier='" & txtSUPPLIER.Text & "' ", cn)
        dt = New DataTable
        adp.Fill(dt)

        txtPONO.Text = dt.Rows(0)(1).ToString()

        cn.Close()

    End Sub

    Sub SaveInPOList()

        For Each row_1 As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tblpurchasedorderlist (po_no, pr_no, supplier_name, delivery_address, quantity, unit, item_name, unit_price, vat_amount, grand_total) values(@po_no, @pr_no, @supplier_name, @delivery_address, @quantity, @unit, @item_name, @unit_price, @vat_amount, @grand_total)", cn)

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

        MsgBox("Purchased Order has been Successfully Approved!", vbInformation + vbOKOnly, "CONFIRMATION")

    End Sub

    Sub SaveInPOList_DEACTIVE()

        For Each row_1 As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tblpurchasedorderlist (po_no, pr_no, supplier_name, delivery_address, quantity, unit, item_name, unit_price, vat_amount, grand_total) values(@po_no, @pr_no, @supplier_name, @delivery_address, @quantity, @unit, @item_name, @unit_price, @vat_amount, @grand_total)", cn)

            With cm.Parameters

                .AddWithValue("@po_no", txtPONO.Text & "_" & "DEACTIVE")
                .AddWithValue("@pr_no", txtREFERENCE.Text & "_" & "DEACTIVE")
                .AddWithValue("@supplier_name", txtSUPPLIER.Text & "_" & "DEACTIVE")
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

    Sub Supplier_sum()

        Dim TOTALUNIT_1 As Decimal = 0
        For i = 0 To dataGridView1.Rows.Count - 1
            TOTALUNIT_1 += dataGridView1.Rows(i).Cells(4).Value
        Next

        Dim VATTOTAL_1 As Decimal = 0
        For i = 0 To dataGridView1.Rows.Count - 1
            VATTOTAL_1 += dataGridView1.Rows(i).Cells(5).Value
        Next

        Dim GRANDTOTAL_1 As Decimal = 0
        For i = 0 To dataGridView1.Rows.Count - 1
            GRANDTOTAL_1 += dataGridView1.Rows(i).Cells(6).Value
        Next

        '=======================================================================

        txtTOTALUNIT_1.Text = CDbl(TOTALUNIT_1).ToString("#,##0.00")
        txtVATTOTAL_1.Text = CDbl(VATTOTAL_1).ToString("#,##0.00")
        txtGRANDTOTAL_1.Text = CDbl(GRANDTOTAL_1).ToString("#,##0.00")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

        If txtSEARCHNAME.Text <> "" Then

            txtSEARCHNAME.Text = ""

        End If

        If txtSHIPPINGMETHOD.Text = "" Or txtPAYMENTTERMS.Text = "" Or txtDELIVERYADDRESS.Text = "" Then

            MsgBox("Please input all data!", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tblpurchasedorder set po_no=@po_no, pr_no=@pr_no, employee=@employee, department=@department, date=@date, date=@date, shipping_method=@shipping_method, payment_terms=@payment_terms, required_date=@required_date, delivery_address=@delivery_address, supplier=@supplier, modified_data_time=@modified_data_time, status=@status where id=@id", cn)


                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@po_no", txtPONO.Text & "_" & "DEACTIVE")
                    .AddWithValue("@pr_no", txtREFERENCE.Text & "_" & "DEACTIVE")
                    .AddWithValue("@employee", frm1HOME.txtHOMENAME.Text)
                    .AddWithValue("@department", frm1HOME.txtHOMEDEPARTMENT.Text)
                    .AddWithValue("@date", txtDATE.Text)
                    .AddWithValue("@shipping_method", txtSHIPPINGMETHOD.Text)
                    .AddWithValue("@payment_terms", txtPAYMENTTERMS.Text)
                    .AddWithValue("@required_date", txtREQUIREDDATE.Text)

                    .AddWithValue("@delivery_address", txtDELIVERYADDRESS.Text)
                    .AddWithValue("@supplier", txtSUPPLIER.Text)

                    .AddWithValue("@modified_data_time", DateTimePicker1.Value)

                    .AddWithValue("@STATUS", "DEACTIVE")

                End With
                cm.ExecuteNonQuery()
                cn.Close()
                DeleteInPOList()
                SaveInPOList_DEACTIVE()

            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        End If

    End Sub

End Class