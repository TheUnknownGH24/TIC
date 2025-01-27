Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmMANAGER_PR_APPROVAL_FINAL

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

    Sub LoadSupplier_1()

        dataGridView1.Rows.Clear()

        If txtSUPPLIER_1.Text = String.Empty Then

            Exit Sub

        Else

            cn.Open()
            cm = New MySqlCommand("select * from tblpurchasedrequestlist where `pr_no` like '%" & txtCONTROL.Text & "%' and `supplier_name` like '%" & txtSUPPLIER_1.Text & "%'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                dataGridView1.Rows.Add(dr.Item("id").ToString, dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, dr.Item("unit_price").ToString, dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString)

            End While
            dr.Close()
            cn.Close()

        End If

    End Sub

    Sub LoadSupplier_2()

        DataGridView2.Rows.Clear()

        If txtSUPPLIER_2.Text = String.Empty Then

            Exit Sub

        Else

            cn.Open()
            cm = New MySqlCommand("select * from tblpurchasedrequestlist where `pr_no` like '%" & txtCONTROL.Text & "%' and `supplier_name` like '%" & txtSUPPLIER_2.Text & "%'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                DataGridView2.Rows.Add(dr.Item("id").ToString, dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, dr.Item("unit_price").ToString, dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString)

            End While
            dr.Close()
            cn.Close()

        End If

    End Sub

    Sub LoadSupplier_3()

        DataGridView3.Rows.Clear()

        If txtSUPPLIER_3.Text = String.Empty Then

            Exit Sub

        Else

            cn.Open()
            cm = New MySqlCommand("select * from tblpurchasedrequestlist where `pr_no` like '%" & txtCONTROL.Text & "%' and `supplier_name` like '%" & txtSUPPLIER_3.Text & "%'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                DataGridView3.Rows.Add(dr.Item("id").ToString, dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, dr.Item("unit_price").ToString, dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString)

            End While
            dr.Close()
            cn.Close()

        End If

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

        Dim TOTALUNIT_2 As Decimal = 0
        For i = 0 To DataGridView2.Rows.Count - 1
            TOTALUNIT_2 += DataGridView2.Rows(i).Cells(4).Value
        Next

        Dim VATTOTAL_2 As Decimal = 0
        For i = 0 To DataGridView2.Rows.Count - 1
            VATTOTAL_2 += DataGridView2.Rows(i).Cells(5).Value
        Next

        Dim GRANDTOTAL_2 As Decimal = 0
        For i = 0 To DataGridView2.Rows.Count - 1
            GRANDTOTAL_2 += DataGridView2.Rows(i).Cells(6).Value
        Next

        '=======================================================================

        Dim TOTALUNIT_3 As Decimal = 0
        For i = 0 To DataGridView3.Rows.Count - 1
            TOTALUNIT_3 += DataGridView3.Rows(i).Cells(4).Value
        Next

        Dim VATTOTAL_3 As Decimal = 0
        For i = 0 To DataGridView3.Rows.Count - 1
            VATTOTAL_3 += DataGridView3.Rows(i).Cells(5).Value
        Next

        Dim GRANDTOTAL_3 As Decimal = 0
        For i = 0 To DataGridView3.Rows.Count - 1
            GRANDTOTAL_3 += DataGridView3.Rows(i).Cells(6).Value
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

        If txtCOMMENT.Text = "" Then

            MsgBox("Please Input Remarks", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tblpurchasedrequest set pr_no=@pr_no, transaction_no=@transaction_no, employee=@employee, department=@department, date=@date, purpose=@purpose, supplier_1=@supplier_1, supplier_2=@supplier_2, supplier_3=@supplier_3, MANAGER_APPROVAL=@MANAGER_APPROVAL, manager_comment=@manager_comment where id=@id", cn)

                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@pr_no", txtCONTROL.Text)
                    .AddWithValue("@transaction_no", txtTRANSACTION.Text)
                    .AddWithValue("@employee", txtEMPLOYEE.Text)
                    .AddWithValue("@department", txtDEPARTMENT.Text)
                    .AddWithValue("@date", txtDATE.Text)
                    .AddWithValue("@purpose", txtREMARKS.Text)

                    .AddWithValue("@supplier_1", txtSUPPLIER_1.Text)
                    .AddWithValue("@supplier_2", txtSUPPLIER_2.Text)
                    .AddWithValue("@supplier_3", txtSUPPLIER_3.Text)

                    .AddWithValue("@MANAGER_APPROVAL", "APPROVED")
                    .AddWithValue("@manager_comment", txtCOMMENT.Text & " - " & DateTimePicker1.Value)

                End With
                cm.ExecuteNonQuery()
                cn.Close()

                MsgBox("Purchased Request has been Successfully Approved!", vbInformation + vbOKOnly, "CONFIRMATION")


            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        End If

    End Sub


End Class