Imports MySql.Data.MySqlClient

Public Class frmPO_FORM

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Sub LoadPaymentTerms()

        txtPAYMENTTERMS.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblpayment_terms", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtPAYMENTTERMS.Items.Add(dr.Item("payment_terms").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        frmPAYMENTTERMS.StartPosition = FormStartPosition.CenterParent
        frmPAYMENTTERMS.ShowDialog()

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        LoadPaymentTerms()

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

    Private Sub txtSUPPLIER_1_CheckedChanged(sender As Object, e As EventArgs) Handles txtSUPPLIER_1.CheckedChanged

        If txtCONTROL.Text = String.Empty Then

            txtSUPPLIER.Text = ""

        Else

            If txtSUPPLIER_1.Checked = True Then

                txtSUPPLIER.Text = txtSUPPLIER_1.Text

            ElseIf txtSUPPLIER_2.Checked = True Then

                txtSUPPLIER.Text = txtSUPPLIER_2.Text

            ElseIf txtSUPPLIER_3.Checked = True Then

                txtSUPPLIER.Text = txtSUPPLIER_3.Text

            Else

                txtSUPPLIER.Text = ""

            End If

        End If


    End Sub

    Private Sub txtSUPPLIER_2_CheckedChanged(sender As Object, e As EventArgs) Handles txtSUPPLIER_2.CheckedChanged

        If txtCONTROL.Text = String.Empty Then

            txtSUPPLIER.Text = ""

        Else

            If txtSUPPLIER_1.Checked = True Then

                txtSUPPLIER.Text = txtSUPPLIER_1.Text

            ElseIf txtSUPPLIER_2.Checked = True Then

                txtSUPPLIER.Text = txtSUPPLIER_2.Text

            ElseIf txtSUPPLIER_3.Checked = True Then

                txtSUPPLIER.Text = txtSUPPLIER_3.Text

            Else

                txtSUPPLIER.Text = ""

            End If

        End If

    End Sub

    Private Sub txtSUPPLIER_3_CheckedChanged(sender As Object, e As EventArgs) Handles txtSUPPLIER_3.CheckedChanged

        If txtCONTROL.Text = String.Empty Then

            txtSUPPLIER.Text = ""

        Else

            If txtSUPPLIER_1.Checked = True Then

                txtSUPPLIER.Text = txtSUPPLIER_1.Text

            ElseIf txtSUPPLIER_2.Checked = True Then

                txtSUPPLIER.Text = txtSUPPLIER_2.Text

            ElseIf txtSUPPLIER_3.Checked = True Then

                txtSUPPLIER.Text = txtSUPPLIER_3.Text

            Else

                txtSUPPLIER.Text = ""

            End If

        End If

    End Sub

    Private Sub txtSUPPLIER_TextChanged(sender As Object, e As EventArgs) Handles txtSUPPLIER.TextChanged

        dataGridView1.Rows.Clear()

        If txtSUPPLIER.Text = String.Empty Then

            Exit Sub

        Else

            cn.Open()
            cm = New MySqlCommand("select * from tblpurchasedrequestlist where `pr_no` like '%" & txtCONTROL.Text & "%' and `supplier_name` like '%" & txtSUPPLIER.Text & "%'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                dataGridView1.Rows.Add(dr.Item("id").ToString, dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, dr.Item("unit_price").ToString, dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString)


            End While
            dr.Close()
            cn.Close()
            Supplier_sum()

        End If

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If txtSEARCHNAME.Text <> "" Then

            txtSEARCHNAME.Text = ""

        End If

        If txtTOTALUNIT_1.Text = 0 Then

            MsgBox("Please Select Supplier!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If txtSHIPPINGMETHOD.Text = "" Or txtPAYMENTTERMS.Text = "" Or txtDELIVERYADDRESS.Text = "" Then

            MsgBox("Please input all data!", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            reloadtextPO("Select * from tblpurchasedorder where pr_no='" & txtREFERENCE.Text & "' AND supplier='" & txtSUPPLIER.Text & "' ")

            If dt.Rows.Count > 0 Then
                MsgBox("Already Exist!", vbOKOnly + vbCritical, "CONFIRMATION")

            Else

                If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                    cn.Open()
                    cm = New MySqlCommand("INSERT into tblpurchasedorder (pr_no, employee, department, date, shipping_method, payment_terms, required_date, delivery_address, supplier, date_time, MANAGER_APPROVAL, GM_APPROVAL, COO_APPROVAL) values(@pr_no, @employee, @department, @date, @shipping_method, @payment_terms, @required_date, @delivery_address, @supplier, @date_time, @MANAGER_APPROVAL, @GM_APPROVAL, @COO_APPROVAL)", cn)
                    With cm.Parameters

                        .AddWithValue("@pr_no", txtREFERENCE.Text)
                        .AddWithValue("@employee", frm1HOME.txtHOMENAME.Text)
                        .AddWithValue("@department", frm1HOME.txtHOMEDEPARTMENT.Text)
                        .AddWithValue("@date", txtDATE.Text)
                        .AddWithValue("@shipping_method", txtSHIPPINGMETHOD.Text)
                        .AddWithValue("@payment_terms", txtPAYMENTTERMS.Text)
                        .AddWithValue("@required_date", txtREQUIREDDATE.Text)

                        .AddWithValue("@delivery_address", txtDELIVERYADDRESS.Text)
                        .AddWithValue("@supplier", txtSUPPLIER.Text)

                        .AddWithValue("@MANAGER_APPROVAL", "FOR APPROVAL")
                        .AddWithValue("@GM_APPROVAL", "FOR APPROVAL")
                        .AddWithValue("@COO_APPROVAL", "FOR APPROVAL")

                        .AddWithValue("@date_time", DateTimePicker1.Value)

                    End With
                    cm.ExecuteNonQuery()
                    cn.Close()
                    DisplayPO()
                    SaveInPOList()

                Else

                    MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

                End If

            End If
        End If

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

End Class