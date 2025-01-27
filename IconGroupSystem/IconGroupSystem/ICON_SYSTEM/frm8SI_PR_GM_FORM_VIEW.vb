Public Class frm8SI_PR_GM_FORM_VIEW

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Sub LoadPURCHASEDList_supplier1_FINAL()

        If txtSUPPLIER_1.Text = String.Empty Then

            Exit Sub

        Else

            dataGridView1.Rows.Clear()

            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedrequestlist where `pr_no` like '" & txtPRNO_1.Text & "'  AND `supplier_name` like '" & txtSUPPLIER_1.Text & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                dataGridView1.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, dr.Item("unit_price").ToString, dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString)

            End While
            dr.Close()
            cn.Close()

        End If

    End Sub

    Sub LoadPURCHASEDList_supplier2_FINAL()

        If txtSUPPLIER_2.Text = String.Empty Then

            Exit Sub

        Else

            DataGridView2.Rows.Clear()

            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedrequestlist where `pr_no` like '" & txtPRNO_2.Text & "'  AND `supplier_name` like '" & txtSUPPLIER_2.Text & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                DataGridView2.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, dr.Item("unit_price").ToString, dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString)

            End While
            dr.Close()
            cn.Close()

        End If

    End Sub

    Sub LoadPURCHASEDList_supplier3_FINAL()

        If txtSUPPLIER_3.Text = String.Empty Then

            Exit Sub

        Else

            DataGridView3.Rows.Clear()

            cn.Open()
            cm = New MySqlCommand("select * from tbl_8si_purchasedrequestlist where `pr_no` like '" & txtPRNO_3.Text & "'  AND `supplier_name` like '" & txtSUPPLIER_3.Text & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                DataGridView3.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, dr.Item("unit_price").ToString, dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString)

            End While
            dr.Close()
            cn.Close()

        End If

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


    Private Sub frm8SI_PR_GM_FORM_VIEW_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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