Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class frmTIC_PR_MANAGER_FORM

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

    Private Sub button3_Click(sender As Object, e As EventArgs) Handles button3.Click

        If txtQTY.Text = String.Empty Or txtUNIT.Text = String.Empty Or txtDESCRIPTION.Text = String.Empty Or txtDESCRIPTION.Text = String.Empty Then
            MsgBox("Please Complete data!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        If txtSUPPLIER_1.Text = String.Empty Or txtUNITPRICE_1.Text = String.Empty Then
            MsgBox("Please Choose atleast 1 Supplier!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        If txtSUPPLIER_1.Text = String.Empty Then

            txtUNITPRICE_1.Text = CDbl("0").ToString("#,##0.00")
            txtVATAMOUNT_1.Text = CDbl("0").ToString("#,##0.00")
            txtTOTALPRICE_1.Text = CDbl("0").ToString("#,##0.00")

        End If

        If txtSUPPLIER_2.Text = String.Empty Then

            txtUNITPRICE_2.Text = CDbl("0").ToString("#,##0.00")
            txtVATAMOUNT_2.Text = CDbl("0").ToString("#,##0.00")
            txtTOTALPRICE_2.Text = CDbl("0").ToString("#,##0.00")

        End If

        If txtSUPPLIER_3.Text = String.Empty Then

            txtUNITPRICE_3.Text = CDbl("0").ToString("#,##0.00")
            txtVATAMOUNT_3.Text = CDbl("0").ToString("#,##0.00")
            txtTOTALPRICE_3.Text = CDbl("0").ToString("#,##0.00")

        End If

        '============================================================================================

        For i As Integer = 0 To dataGridView1.Rows.Count - 1

            If txtDESCRIPTION.Text = dataGridView1.Rows(i).Cells(2).Value.ToString() Then

                MsgBox("Item Already in the List!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return

            End If

        Next

        '============================================================================================

        Try

            dataGridView1.Rows.Add(txtQTY.Text, txtUNIT.Text, txtDESCRIPTION.Text, txtSUPPLIER_1.Text, txtUNITPRICE_1.Text, txtVATAMOUNT_1.Text, txtTOTALPRICE_1.Text, txtSUPPLIER_2.Text, txtUNITPRICE_2.Text, txtVATAMOUNT_2.Text, txtTOTALPRICE_2.Text, txtSUPPLIER_3.Text, txtUNITPRICE_3.Text, txtVATAMOUNT_3.Text, txtTOTALPRICE_3.Text)


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try

        '===============================================================================

        Dim totalunit_1 As Decimal = 0
        Dim totalvat_1 As Decimal = 0
        Dim totalgrand_1 As Decimal = 0

        For i = 0 To dataGridView1.Rows.Count - 1
            totalunit_1 += dataGridView1.Rows(i).Cells(4).Value
            totalgrand_1 += dataGridView1.Rows(i).Cells(6).Value

            If txtVATAMOUNT_1.Text = String.Empty Then

                Exit For

            Else

                totalvat_1 += CDbl(dataGridView1.Rows(i).Cells(5).Value).ToString("#,##0.00")
                txtVATTOTAL_1.Text = CDbl(totalvat_1).ToString("#,##0.00")

            End If


        Next

        txtTOTALUNIT_1.Text = totalunit_1
        txtGRANDTOTAL_1.Text = totalgrand_1

        '===============================================================================

        Dim totalunit_2 As Decimal = 0
        Dim totalvat_2 As Decimal = 0
        Dim totalgrand_2 As Decimal = 0

        For i = 0 To dataGridView1.Rows.Count - 1
            totalunit_2 += dataGridView1.Rows(i).Cells(8).Value
            totalgrand_2 += dataGridView1.Rows(i).Cells(10).Value

            If txtVATAMOUNT_2.Text = String.Empty Then

                Exit For

            Else

                totalvat_2 += CDbl(dataGridView1.Rows(i).Cells(9).Value).ToString("#,##0.00")
                txtVATTOTAL_2.Text = CDbl(totalvat_2).ToString("#,##0.00")

            End If


        Next

        txtTOTALUNIT_2.Text = totalunit_2
        txtGRANDTOTAL_2.Text = totalgrand_2


        '===============================================================================

        Dim totalunit_3 As Decimal = 0
        Dim totalvat_3 As Decimal = 0
        Dim totalgrand_3 As Decimal = 0

        For i = 0 To dataGridView1.Rows.Count - 1
            totalunit_3 += dataGridView1.Rows(i).Cells(12).Value
            totalgrand_3 += dataGridView1.Rows(i).Cells(14).Value

            If txtVATAMOUNT_3.Text = String.Empty Then

                Exit For

            Else

                totalvat_3 += CDbl(dataGridView1.Rows(i).Cells(13).Value).ToString("#,##0.00")
                txtVATTOTAL_3.Text = CDbl(totalvat_3).ToString("#,##0.00")

            End If


        Next

        txtTOTALUNIT_3.Text = totalunit_3
        txtGRANDTOTAL_3.Text = totalgrand_3


        Dim combo As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn
        combo.HeaderText = "CHOOSE_SUPPLIER"
        combo.Name = "CHOOSE_SUPPLIER"
        combo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        combo.Items.Add(txtSUPPLIER_1.Text)
        combo.Items.Add(txtSUPPLIER_2.Text)
        combo.Items.Add(txtSUPPLIER_3.Text)
        dataGridView1.Columns.Add(combo)


        Clear()

    End Sub

    Private Sub txtVAT_1_CheckedChanged(sender As Object, e As EventArgs) Handles txtVAT_1.CheckedChanged

        Dim qty_1 As Double
        Dim unit_1 As Double
        Dim vat_1 As Double
        Dim total_vatable As Double
        Dim non_vat_1 As Double

        If txtUNITPRICE_1.Text = String.Empty Or txtQTY.Text = String.Empty Then

            Exit Sub

        Else

            qty_1 = txtQTY.Text
            unit_1 = txtUNITPRICE_1.Text

            vat_1 = (qty_1 * unit_1) * 0.12

            non_vat_1 = (qty_1 * unit_1)

            total_vatable = non_vat_1 * 1.12

            If txtVAT_1.Checked Then

                txtVATAMOUNT_1.Text = CDbl(vat_1).ToString("#,##0.00")
                txtTOTALPRICE_1.Text = CDbl(total_vatable).ToString("#,##0.00")

            Else

                txtVATAMOUNT_1.Text = CDbl("0").ToString("#,##0.00")
                txtTOTALPRICE_1.Text = CDbl(non_vat_1).ToString("#,##0.00")

            End If

        End If

    End Sub

    Private Sub txtQTY_KeyPress(sender As Object, e As KeyPressEventArgs)

        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select

    End Sub

    Private Sub txtUNITPRICE_1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUNITPRICE_1.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select

        If txtSUPPLIER_1.Text = String.Empty Then

            MsgBox("Please enter Supplier Name", vbOKOnly + vbCritical, "CONFIRMATION")
            txtUNITPRICE_1.Text = ""

        End If

    End Sub

    Private Sub txtUNITPRICE_1_TextChanged(sender As Object, e As EventArgs) Handles txtUNITPRICE_1.TextChanged

        Dim qty_1 As Double
        Dim unit_1 As Double
        Dim vat_1 As Double
        Dim total_vatable As Double
        Dim non_vat_1 As Double

        If txtUNITPRICE_1.Text = String.Empty Or txtQTY.Text = String.Empty Then

            Exit Sub

        Else

            qty_1 = txtQTY.Text
            unit_1 = txtUNITPRICE_1.Text

            vat_1 = (qty_1 * unit_1) * 0.12

            non_vat_1 = (qty_1 * unit_1)

            total_vatable = non_vat_1 * 1.12

            If txtVAT_1.Checked Then

                txtVATAMOUNT_1.Text = CDbl(vat_1).ToString("#,##0.00")
                txtTOTALPRICE_1.Text = CDbl(total_vatable).ToString("#,##0.00")

            Else

                txtVATAMOUNT_1.Text = CDbl("0").ToString("#,##0.00")
                txtTOTALPRICE_1.Text = CDbl(non_vat_1).ToString("#,##0.00")

            End If

        End If

    End Sub

    Private Sub txtQTY_TextChanged(sender As Object, e As EventArgs)

        Dim qty_1 As Double
        Dim unit_1 As Double
        Dim vat_1 As Double
        Dim total_vatable As Double
        Dim non_vat_1 As Double

        If txtUNITPRICE_1.Text = String.Empty Or txtQTY.Text = String.Empty Then

            Exit Sub

        Else

            qty_1 = txtQTY.Text
            unit_1 = txtUNITPRICE_1.Text

            vat_1 = (qty_1 * unit_1) * 0.12

            non_vat_1 = (qty_1 * unit_1)

            total_vatable = non_vat_1 * 1.12

            If txtVAT_1.Checked Then

                txtVATAMOUNT_1.Text = CDbl(vat_1).ToString("#,##0.00")
                txtTOTALPRICE_1.Text = CDbl(total_vatable).ToString("#,##0.00")

            Else

                txtVATAMOUNT_1.Text = CDbl("0").ToString("#,##0.00")
                txtTOTALPRICE_1.Text = CDbl(non_vat_1).ToString("#,##0.00")

            End If

        End If

        '=================================================================================

        If txtUNITPRICE_2.Text = String.Empty Then

            Exit Sub

        Else

            qty_1 = txtQTY.Text
            unit_1 = txtUNITPRICE_2.Text

            vat_1 = (qty_1 * unit_1) * 0.12

            non_vat_1 = (qty_1 * unit_1)

            total_vatable = non_vat_1 * 1.12

            If txtVAT_2.Checked Then

                txtVATAMOUNT_2.Text = CDbl(vat_1).ToString("#,##0.00")
                txtTOTALPRICE_2.Text = CDbl(total_vatable).ToString("#,##0.00")

            Else

                txtVATAMOUNT_2.Text = CDbl("0").ToString("#,##0.00")
                txtTOTALPRICE_2.Text = CDbl(non_vat_1).ToString("#,##0.00")

            End If

        End If

        '=================================================================================

        If txtUNITPRICE_3.Text = String.Empty Then

            Exit Sub

        Else

            qty_1 = txtQTY.Text
            unit_1 = txtUNITPRICE_3.Text

            vat_1 = (qty_1 * unit_1) * 0.12

            non_vat_1 = (qty_1 * unit_1)

            total_vatable = non_vat_1 * 1.12

            If txtVAT_3.Checked Then

                txtVATAMOUNT_3.Text = CDbl(vat_1).ToString("#,##0.00")
                txtTOTALPRICE_3.Text = CDbl(total_vatable).ToString("#,##0.00")

            Else

                txtVATAMOUNT_3.Text = CDbl("0").ToString("#,##0.00")
                txtTOTALPRICE_3.Text = CDbl(non_vat_1).ToString("#,##0.00")

            End If

        End If

        '===========================================================================

    End Sub

    Private Sub txtVAT_2_CheckedChanged(sender As Object, e As EventArgs) Handles txtVAT_2.CheckedChanged

        Dim qty_2 As Double
        Dim unit_2 As Double
        Dim vat_2 As Double
        Dim total_vatable As Double
        Dim non_vat_2 As Double

        If txtUNITPRICE_2.Text = String.Empty Or txtQTY.Text = String.Empty Then

            Exit Sub

        Else

            qty_2 = txtQTY.Text
            unit_2 = txtUNITPRICE_2.Text

            vat_2 = (qty_2 * unit_2) * 0.12

            non_vat_2 = (qty_2 * unit_2)

            total_vatable = non_vat_2 * 1.12

            If txtVAT_2.Checked Then

                txtVATAMOUNT_2.Text = CDbl(vat_2).ToString("#,##0.00")
                txtTOTALPRICE_2.Text = CDbl(total_vatable).ToString("#,##0.00")

            Else

                txtVATAMOUNT_2.Text = CDbl("0").ToString("#,##0.00")
                txtTOTALPRICE_2.Text = CDbl(non_vat_2).ToString("#,##0.00")

            End If

        End If


    End Sub

    Private Sub txtVAT_3_CheckedChanged(sender As Object, e As EventArgs) Handles txtVAT_3.CheckedChanged

        Dim qty_3 As Double
        Dim unit_3 As Double
        Dim vat_3 As Double
        Dim total_vatable As Double
        Dim non_vat_3 As Double

        If txtUNITPRICE_3.Text = String.Empty Or txtQTY.Text = String.Empty Then

            Exit Sub

        Else

            qty_3 = txtQTY.Text
            unit_3 = txtUNITPRICE_3.Text

            vat_3 = (qty_3 * unit_3) * 0.12

            non_vat_3 = (qty_3 * unit_3)

            total_vatable = non_vat_3 * 1.12

            If txtVAT_3.Checked Then

                txtVATAMOUNT_3.Text = CDbl(vat_3).ToString("#,##0.00")
                txtTOTALPRICE_3.Text = CDbl(total_vatable).ToString("#,##0.00")

            Else

                txtVATAMOUNT_3.Text = CDbl("0").ToString("#,##0.00")
                txtTOTALPRICE_3.Text = CDbl(non_vat_3).ToString("#,##0.00")

            End If

        End If

    End Sub

    Private Sub txtUNITPRICE_2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUNITPRICE_2.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select

        If txtSUPPLIER_2.Text = String.Empty Then

            MsgBox("Please enter Supplier Name", vbOKOnly + vbCritical, "CONFIRMATION")
            txtUNITPRICE_2.Text = ""

        End If

    End Sub

    Private Sub txtUNITPRICE_2_TextChanged(sender As Object, e As EventArgs) Handles txtUNITPRICE_2.TextChanged

        Dim qty_1 As Double
        Dim unit_1 As Double
        Dim vat_1 As Double
        Dim total_vatable As Double
        Dim non_vat_1 As Double

        If txtUNITPRICE_2.Text = String.Empty Or txtQTY.Text = String.Empty Then

            Exit Sub

        Else

            qty_1 = txtQTY.Text
            unit_1 = txtUNITPRICE_2.Text

            vat_1 = (qty_1 * unit_1) * 0.12

            non_vat_1 = (qty_1 * unit_1)

            total_vatable = non_vat_1 * 1.12

            If txtVAT_2.Checked Then

                txtVATAMOUNT_2.Text = CDbl(vat_1).ToString("#,##0.00")
                txtTOTALPRICE_2.Text = CDbl(total_vatable).ToString("#,##0.00")

            Else

                txtVATAMOUNT_2.Text = CDbl("0").ToString("#,##0.00")
                txtTOTALPRICE_2.Text = CDbl(non_vat_1).ToString("#,##0.00")

            End If

        End If

    End Sub

    Private Sub txtUNITPRICE_3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUNITPRICE_3.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46
            Case 8
            Case Else
                e.Handled = True
        End Select

        If txtSUPPLIER_3.Text = String.Empty Then

            MsgBox("Please enter Supplier Name", vbOKOnly + vbCritical, "CONFIRMATION")
            txtUNITPRICE_3.Text = ""

        End If



    End Sub

    Private Sub txtUNITPRICE_3_TextChanged(sender As Object, e As EventArgs) Handles txtUNITPRICE_3.TextChanged

        Dim qty_1 As Double
        Dim unit_1 As Double
        Dim vat_1 As Double
        Dim total_vatable As Double
        Dim non_vat_1 As Double

        If txtUNITPRICE_3.Text = String.Empty Or txtQTY.Text = String.Empty Then

            Exit Sub

        Else

            qty_1 = txtQTY.Text
            unit_1 = txtUNITPRICE_3.Text

            vat_1 = (qty_1 * unit_1) * 0.12

            non_vat_1 = (qty_1 * unit_1)

            total_vatable = non_vat_1 * 1.12

            If txtVAT_3.Checked Then

                txtVATAMOUNT_3.Text = CDbl(vat_1).ToString("#,##0.00")
                txtTOTALPRICE_3.Text = CDbl(total_vatable).ToString("#,##0.00")

            Else

                txtVATAMOUNT_3.Text = CDbl("0").ToString("#,##0.00")
                txtTOTALPRICE_3.Text = CDbl(non_vat_1).ToString("#,##0.00")

            End If

        End If

    End Sub

    Sub LoadITEM()

        DataGridView2.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_requestsliplist where `controlno` like '%" & txtTRANSACTION.Text & "%' ", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView2.Rows.Add(dr.Item("controlno").ToString, dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("description").ToString, dr.Item("remarks").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub LoadITEMNAME()

        txtDESCRIPTION.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblitem where `mother_class` like '" & txtITEM.Text & "'", cn)
        dr = cm.ExecuteReader
        While dr.Read


            txtDESCRIPTION.Items.Add(dr.Item("itemname").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub


    Sub LoadSupplier()

        cn.Open()
        cm = New MySqlCommand("select supplier_name from tblsupplier", cn)
        dr = cm.ExecuteReader
        Dim mydata As AutoCompleteStringCollection = New AutoCompleteStringCollection()
        While dr.Read
            mydata.Add(dr.GetString(0))
        End While

        txtSUPPLIER_1.AutoCompleteCustomSource = mydata
        txtSUPPLIER_2.AutoCompleteCustomSource = mydata
        txtSUPPLIER_3.AutoCompleteCustomSource = mydata

        dr.Close()
        cn.Close()

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        frmTIC_PR_MANAGER_FORM_FINAL.txtID.Text = txtID.Text
        frmTIC_PR_MANAGER_FORM_FINAL.txtCONTROL.Text = txtCONTROL.Text
        frmTIC_PR_MANAGER_FORM_FINAL.txtEMPLOYEE.Text = txtEMPLOYEE.Text
        frmTIC_PR_MANAGER_FORM_FINAL.txtDEPARTMENT.Text = txtDEPARTMENT.Text
        frmTIC_PR_MANAGER_FORM_FINAL.txtDATE.Text = txtDATE.Text
        frmTIC_PR_MANAGER_FORM_FINAL.txtTRANSACTION.Text = txtTRANSACTION.Text
        frmTIC_PR_MANAGER_FORM_FINAL.txtREMARKS.Text = txtREMARKS.Text

        frmTIC_PR_MANAGER_FORM_FINAL.txtSUPPLIER_1.Text = txtSUPPLIER_1.Text

        frmTIC_PR_MANAGER_FORM_FINAL.txtSUPPLIER_2.Text = txtSUPPLIER_2.Text

        frmTIC_PR_MANAGER_FORM_FINAL.txtSUPPLIER_3.Text = txtSUPPLIER_3.Text

        '==============================================================================================================

        Dim dt_1 As New DataTable()
        Dim dt_2 As New DataTable()
        Dim dt_3 As New DataTable()
        Dim dt_all As New DataTable()

        dt_1.Columns.Add("QUANTITY")
        dt_1.Columns.Add("UNIT")
        dt_1.Columns.Add("ITEM_NAME")
        dt_1.Columns.Add("UNIT_PRICE")
        dt_1.Columns.Add("VAT_AMOUNT")
        dt_1.Columns.Add("TOTAL_PRICE")

        dt_2.Columns.Add("QUANTITY")
        dt_2.Columns.Add("UNIT")
        dt_2.Columns.Add("ITEM_NAME")
        dt_2.Columns.Add("UNIT_PRICE")
        dt_2.Columns.Add("VAT_AMOUNT")
        dt_2.Columns.Add("TOTAL_PRICE")

        dt_3.Columns.Add("QUANTITY")
        dt_3.Columns.Add("UNIT")
        dt_3.Columns.Add("ITEM_NAME")
        dt_3.Columns.Add("UNIT_PRICE")
        dt_3.Columns.Add("VAT_AMOUNT")
        dt_3.Columns.Add("TOTAL_PRICE")

        '==========================================

        dt_all.Columns.Add("QUANTITY")
        dt_all.Columns.Add("UNIT")
        dt_all.Columns.Add("ITEM_NAME")

        dt_all.Columns.Add("SUPPLIER_NAME_1")
        dt_all.Columns.Add("UNIT_PRICE_1")
        dt_all.Columns.Add("VAT_AMOUNT_1")
        dt_all.Columns.Add("TOTAL_PRICE_1")

        dt_all.Columns.Add("SUPPLIER_NAME_2")
        dt_all.Columns.Add("UNIT_PRICE_2")
        dt_all.Columns.Add("VAT_AMOUNT_2")
        dt_all.Columns.Add("TOTAL_PRICE_2")

        dt_all.Columns.Add("SUPPLIER_NAME_3")
        dt_all.Columns.Add("UNIT_PRICE_3")
        dt_all.Columns.Add("VAT_AMOUNT_3")
        dt_all.Columns.Add("TOTAL_PRICE_3")

        dt_all.Columns.Add("CHOOSE_SUPPLIER")

        '==========================================


        For Each row_1 As DataGridViewRow In dataGridView1.Rows
            Dim isSelected As String = row_1.Cells("CHOOSE_SUPPLIER").Value
            If isSelected = txtSUPPLIER_1.Text Then
                dt_1.Rows.Add(row_1.Cells(0).Value, row_1.Cells(1).Value, row_1.Cells(2).Value, row_1.Cells(4).Value, row_1.Cells(5).Value, row_1.Cells(6).Value)
            End If
        Next
        frmTIC_PR_MANAGER_FORM_FINAL.dataGridView1.DataSource = dt_1

        '==============================================================================================================

        For Each row_2 As DataGridViewRow In dataGridView1.Rows
            Dim isSelected As String = row_2.Cells("CHOOSE_SUPPLIER").Value
            If isSelected = txtSUPPLIER_2.Text Then
                dt_2.Rows.Add(row_2.Cells(0).Value, row_2.Cells(1).Value, row_2.Cells(2).Value, row_2.Cells(8).Value, row_2.Cells(9).Value, row_2.Cells(10).Value)

            End If
        Next
        frmTIC_PR_MANAGER_FORM_FINAL.DataGridView2.DataSource = dt_2

        '==============================================================================================================

        For Each row_3 As DataGridViewRow In dataGridView1.Rows
            Dim isSelected As String = row_3.Cells("CHOOSE_SUPPLIER").Value
            If isSelected = txtSUPPLIER_3.Text Then
                dt_3.Rows.Add(row_3.Cells(0).Value, row_3.Cells(1).Value, row_3.Cells(2).Value, row_3.Cells(12).Value, row_3.Cells(13).Value, row_3.Cells(14).Value)

            End If
        Next
        frmTIC_PR_MANAGER_FORM_FINAL.DataGridView3.DataSource = dt_3

        '==============================================================================================================

        For Each row_all As DataGridViewRow In dataGridView1.Rows

            dt_all.Rows.Add(row_all.Cells(0).Value, row_all.Cells(1).Value, row_all.Cells(2).Value, row_all.Cells(3).Value, row_all.Cells(4).Value, row_all.Cells(5).Value, row_all.Cells(6).Value, row_all.Cells(7).Value, row_all.Cells(8).Value, row_all.Cells(9).Value, row_all.Cells(10).Value, row_all.Cells(11).Value, row_all.Cells(12).Value, row_all.Cells(13).Value, row_all.Cells(14).Value, row_all.Cells(15).Value)

        Next


        frmTIC_PR_MANAGER_FORM_FINAL.Supplier_sum()
        frmTIC_PR_MANAGER_FORM_FINAL.StartPosition = FormStartPosition.CenterParent
        frmTIC_PR_MANAGER_FORM_FINAL.ShowDialog()


    End Sub


    Sub DisplayPR()

        cn.Open()
        ' adp = New MySqlDataAdapter("select * from tblsaleinvoice where sales_order = '" & txtSO_NO.Text & "'", cn)
        dt = New DataTable
        adp.Fill(dt)

        'txtSINO.Text = dt.Rows(0)(1).ToString()

        cn.Close()

    End Sub

    Sub SaveInPRList()

        For Each row As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tblsalesinvoice_list (si_no, so_no,item_code, item_name, gross_sales, quantity, gross_profit) values(@si_no, @so_no,@item_code, @item_name, @gross_sales, @quantity, @gross_profit)", cn)
            With cm.Parameters

                ' .AddWithValue("@si_no", txtSINO.Text)
                ' .AddWithValue("@so_no", txtSO_NO.Text)

                .AddWithValue("@item_code", row.Cells("SKU_CODE").Value)
                .AddWithValue("@item_name", row.Cells("ITEM_NAME").Value)
                .AddWithValue("@gross_sales", row.Cells("UNIT_PRICE").Value)
                .AddWithValue("@quantity", row.Cells("QUANTITY").Value)
                .AddWithValue("@gross_profit", row.Cells("TOTAL").Value)

            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
        Next
        MsgBox("Sales Invoice has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

    End Sub


    Private Sub txtTOTALUNIT_1_TextChanged(sender As Object, e As EventArgs) Handles txtTOTALUNIT_1.TextChanged

        txtTOTALUNIT_1.Text = CDbl(txtTOTALUNIT_1.Text).ToString("#,##0.00")

    End Sub

    Private Sub txtGRANDTOTAL_1_TextChanged(sender As Object, e As EventArgs) Handles txtGRANDTOTAL_1.TextChanged

        txtGRANDTOTAL_1.Text = CDbl(txtGRANDTOTAL_1.Text).ToString("#,##0.00")

    End Sub

    Private Sub txtTOTALUNIT_2_TextChanged(sender As Object, e As EventArgs) Handles txtTOTALUNIT_2.TextChanged

        txtTOTALUNIT_2.Text = CDbl(txtTOTALUNIT_2.Text).ToString("#,##0.00")

    End Sub

    Private Sub txtGRANDTOTAL_2_TextChanged(sender As Object, e As EventArgs) Handles txtGRANDTOTAL_2.TextChanged

        txtGRANDTOTAL_2.Text = CDbl(txtGRANDTOTAL_2.Text).ToString("#,##0.00")

    End Sub

    Private Sub txtUNITTOTAL_3_TextChanged(sender As Object, e As EventArgs) Handles txtTOTALUNIT_3.TextChanged

        txtTOTALUNIT_3.Text = CDbl(txtTOTALUNIT_3.Text).ToString("#,##0.00")

    End Sub

    Private Sub txtGRANDTOTAL_3_TextChanged(sender As Object, e As EventArgs) Handles txtGRANDTOTAL_3.TextChanged

        txtGRANDTOTAL_3.Text = CDbl(txtGRANDTOTAL_3.Text).ToString("#,##0.00")

    End Sub

    Sub Clear()

        txtQTY.Text = ""
        txtUNIT.Text = ""
        txtDESCRIPTION.Text = ""

        txtUNITPRICE_1.Text = ""
        txtVAT_1.Checked = False
        txtVATAMOUNT_1.Text = ""
        txtTOTALPRICE_1.Text = ""

        txtUNITPRICE_2.Text = ""
        txtVAT_2.Checked = False
        txtVATAMOUNT_2.Text = ""
        txtTOTALPRICE_2.Text = ""

        txtUNITPRICE_3.Text = ""
        txtVAT_3.Checked = False
        txtVATAMOUNT_3.Text = ""
        txtTOTALPRICE_3.Text = ""

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)


        Try

            If dataGridView1.Columns(e.ColumnIndex).Name = "EDIT" Then

                Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)
                txtQTY.Text = dataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
                txtUNIT.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                txtDESCRIPTION.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString


                txtSUPPLIER_1.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                txtUNITPRICE_1.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                txtVATAMOUNT_1.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
                txtTOTALPRICE_1.Text = dataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString

                If txtVATAMOUNT_1.Text = 0 Then

                    txtVAT_1.Checked = False
                Else

                    txtVAT_1.Checked = True

                End If

                txtSUPPLIER_2.Text = dataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
                txtUNITPRICE_2.Text = dataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString
                txtVATAMOUNT_2.Text = dataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString
                txtTOTALPRICE_2.Text = dataGridView1.Rows(e.RowIndex).Cells(10).Value.ToString

                If txtVATAMOUNT_2.Text = 0 Then

                    txtVAT_2.Checked = False
                Else

                    txtVAT_2.Checked = True

                End If

                txtSUPPLIER_3.Text = dataGridView1.Rows(e.RowIndex).Cells(11).Value.ToString
                txtUNITPRICE_3.Text = dataGridView1.Rows(e.RowIndex).Cells(12).Value.ToString
                txtVATAMOUNT_3.Text = dataGridView1.Rows(e.RowIndex).Cells(13).Value.ToString
                txtTOTALPRICE_3.Text = dataGridView1.Rows(e.RowIndex).Cells(14).Value.ToString

                If txtVATAMOUNT_3.Text = 0 Then

                    txtVAT_3.Checked = False
                Else

                    txtVAT_3.Checked = True

                End If

            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "UPDATE" Then

                Dim update As DataGridViewRow = dataGridView1.SelectedRows(0)

                update.Cells(0).Value = txtQTY.Text
                update.Cells(1).Value = txtUNIT.Text
                update.Cells(2).Value = txtDESCRIPTION.Text

                update.Cells(3).Value = txtSUPPLIER_1.Text
                update.Cells(4).Value = txtUNITPRICE_1.Text
                update.Cells(5).Value = txtVATAMOUNT_1.Text
                update.Cells(6).Value = txtTOTALPRICE_1.Text

                update.Cells(7).Value = txtSUPPLIER_2.Text
                update.Cells(8).Value = txtUNITPRICE_2.Text
                update.Cells(9).Value = txtVATAMOUNT_2.Text
                update.Cells(10).Value = txtTOTALPRICE_2.Text

                update.Cells(11).Value = txtSUPPLIER_3.Text
                update.Cells(12).Value = txtUNITPRICE_3.Text
                update.Cells(13).Value = txtVATAMOUNT_3.Text
                update.Cells(14).Value = txtTOTALPRICE_3.Text

                '===============================================================================

                '===============================================================================

                Dim totalunit_1 As Decimal = 0
                Dim totalvat_1 As Decimal = 0
                Dim totalgrand_1 As Decimal = 0

                For i = 0 To dataGridView1.Rows.Count - 1
                    totalunit_1 += dataGridView1.Rows(i).Cells(4).Value
                    totalgrand_1 += dataGridView1.Rows(i).Cells(6).Value

                    If txtVATAMOUNT_1.Text = String.Empty Then

                        Exit For

                    Else

                        totalvat_1 += dataGridView1.Rows(i).Cells(5).Value
                        txtVATTOTAL_1.Text = totalvat_1

                    End If


                Next

                txtTOTALUNIT_1.Text = totalunit_1
                txtGRANDTOTAL_1.Text = totalgrand_1

                '===============================================================================

                If txtSUPPLIER_2.Text = String.Empty Then

                    Exit Sub

                Else

                    Dim totalunit_2 As Decimal = 0
                    Dim totalvat_2 As Decimal = 0
                    Dim totalgrand_2 As Decimal = 0

                    For i = 0 To dataGridView1.Rows.Count - 1
                        totalunit_2 += dataGridView1.Rows(i).Cells(8).Value
                        totalgrand_2 += dataGridView1.Rows(i).Cells(10).Value

                        If txtVATAMOUNT_2.Text = String.Empty Then

                            Exit For

                        Else

                            totalvat_2 += dataGridView1.Rows(i).Cells(9).Value
                            txtVATTOTAL_2.Text = totalvat_2

                        End If

                    Next

                    txtTOTALUNIT_2.Text = totalunit_2
                    txtVATTOTAL_2.Text = totalvat_2
                    txtGRANDTOTAL_2.Text = totalgrand_2

                End If

                '===============================================================================

                If txtSUPPLIER_3.Text = String.Empty Then

                    Exit Sub

                Else

                    Dim totalunit_3 As Decimal = 0
                    Dim totalvat_3 As Decimal = 0
                    Dim totalgrand_3 As Decimal = 0

                    For i = 0 To dataGridView1.Rows.Count - 1
                        totalunit_3 += dataGridView1.Rows(i).Cells(12).Value
                        totalgrand_3 += dataGridView1.Rows(i).Cells(14).Value

                        If txtVATAMOUNT_3.Text = String.Empty Then

                            Exit For

                        Else

                            totalvat_3 += dataGridView1.Rows(i).Cells(13).Value
                            txtVATTOTAL_3.Text = totalvat_3

                        End If

                    Next

                    txtTOTALUNIT_3.Text = totalunit_3
                    txtGRANDTOTAL_3.Text = totalgrand_3

                    Clear()

                End If

            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "DELETE" Then

                Try

                    If MsgBox("Do you want to Delete ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows(0).Index)

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, vbCritical)

                End Try

                '===============================================================================

                Dim totalunit_1 As Decimal = 0
                Dim totalvat_1 As Decimal = 0
                Dim totalgrand_1 As Decimal = 0

                For i = 0 To dataGridView1.Rows.Count - 1
                    totalunit_1 += dataGridView1.Rows(i).Cells(4).Value
                    totalvat_1 += dataGridView1.Rows(i).Cells(5).Value
                    totalgrand_1 += dataGridView1.Rows(i).Cells(6).Value
                Next

                txtTOTALUNIT_1.Text = totalunit_1
                txtVATTOTAL_1.Text = totalvat_1
                txtGRANDTOTAL_1.Text = totalgrand_1

                '===============================================================================

                If txtSUPPLIER_2.Text = String.Empty Then

                    Exit Sub

                Else

                    Dim totalunit_2 As Decimal = 0
                    Dim totalvat_2 As Decimal = 0
                    Dim totalgrand_2 As Decimal = 0

                    For i = 0 To dataGridView1.Rows.Count - 1
                        totalunit_2 += dataGridView1.Rows(i).Cells(8).Value
                        totalvat_2 += dataGridView1.Rows(i).Cells(9).Value
                        totalgrand_2 += dataGridView1.Rows(i).Cells(10).Value
                    Next

                    txtTOTALUNIT_2.Text = totalunit_2
                    txtVATTOTAL_2.Text = totalvat_2
                    txtGRANDTOTAL_2.Text = totalgrand_2

                End If

                '===============================================================================

                If txtSUPPLIER_3.Text = String.Empty Then

                    Exit Sub

                Else

                    Dim totalunit_3 As Decimal = 0
                    Dim totalvat_3 As Decimal = 0
                    Dim totalgrand_3 As Decimal = 0

                    For i = 0 To dataGridView1.Rows.Count - 1
                        totalunit_3 += dataGridView1.Rows(i).Cells(12).Value
                        totalvat_3 += dataGridView1.Rows(i).Cells(13).Value
                        totalgrand_3 += dataGridView1.Rows(i).Cells(14).Value
                    Next


                    txtTOTALUNIT_3.Text = totalunit_3
                    txtVATTOTAL_3.Text = totalvat_3
                    txtGRANDTOTAL_3.Text = totalgrand_3

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub txtSUPPLIER_2_Leave(sender As Object, e As EventArgs) Handles txtSUPPLIER_2.Leave

        If txtSUPPLIER_2.Text = txtSUPPLIER_1.Text Or txtSUPPLIER_2.Text = txtSUPPLIER_3.Text Then

            MsgBox("Double Entry of Supplier Name!", vbOKOnly + vbCritical, "CONFIRMATION")
            txtSUPPLIER_2.Text = ""

        Else

            Exit Sub

        End If

    End Sub

    Private Sub txtSUPPLIER_3_Leave(sender As Object, e As EventArgs) Handles txtSUPPLIER_3.Leave

        If txtSUPPLIER_3.Text = txtSUPPLIER_1.Text Or txtSUPPLIER_3.Text = txtSUPPLIER_2.Text Then

            MsgBox("Double Entry of Supplier Name!", vbOKOnly + vbCritical, "CONFIRMATION")
            txtSUPPLIER_3.Text = ""

        Else

            Exit Sub

        End If

    End Sub

    Private Sub txtDESCRIPTION_TextChanged(sender As Object, e As EventArgs)

        DataGridView2.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tblitem where `itemname` like '%" & txtDESCRIPTION.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView2.Rows.Add(dr.Item("id").ToString, dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("stock_on_hand").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs)


        txtDESCRIPTION.Text = DataGridView2.CurrentRow.Cells(2).Value
        txtUNIT.Text = DataGridView2.CurrentRow.Cells(3).Value

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        With frmTIC_PR_MODIFY_ADDSUPPLIER_1

            .StartPosition = FormStartPosition.CenterParent
            .LoadSupplierList()
            .ShowDialog()

        End With

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        With frmTIC_PR_MODIFY_ADDSUPPLIER_2

            .StartPosition = FormStartPosition.CenterParent
            .LoadSupplierList()
            .ShowDialog()

        End With

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        With frmTIC_PR_MODIFY_ADDSUPPLIER_3

            .StartPosition = FormStartPosition.CenterParent
            .LoadSupplierList()
            .ShowDialog()

        End With

    End Sub

    Sub LoadPURCHASEDList()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_purchasedrequest_all where `pr_no` like '%" & txtCONTROL.Text & "%'", cn)
        dr = cm.ExecuteReader
        While dr.Read

            dataGridView1.Rows.Add(dr.Item("quantity").ToString, dr.Item("unit").ToString, dr.Item("item_name").ToString, dr.Item("supplier_1").ToString, dr.Item("unit_price_1").ToString, dr.Item("vat_amount_1").ToString, dr.Item("total_amount_1").ToString, dr.Item("supplier_2").ToString, dr.Item("unit_price_2").ToString, dr.Item("vat_amount_2").ToString, dr.Item("total_amount_2").ToString, dr.Item("supplier_3").ToString, dr.Item("unit_price_3").ToString, dr.Item("vat_amount_3").ToString, dr.Item("total_amount_3").ToString, dr.Item("final_supplier").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Sub Supplier_sum()

        Dim totalunit_1 As Decimal = 0
        Dim totalvat_1 As Decimal = 0
        Dim totalgrand_1 As Decimal = 0

        For i = 0 To dataGridView1.Rows.Count - 1
            totalunit_1 += dataGridView1.Rows(i).Cells(4).Value
            totalgrand_1 += dataGridView1.Rows(i).Cells(6).Value

            If txtVATAMOUNT_1.Text = String.Empty Then

                Exit For

            Else

                totalvat_1 += CDbl(dataGridView1.Rows(i).Cells(5).Value).ToString("#,##0.00")
                txtVATTOTAL_1.Text = CDbl(totalvat_1).ToString("#,##0.00")

            End If


        Next

        txtTOTALUNIT_1.Text = totalunit_1
        txtGRANDTOTAL_1.Text = totalgrand_1

        '===============================================================================

        Dim totalunit_2 As Decimal = 0
        Dim totalvat_2 As Decimal = 0
        Dim totalgrand_2 As Decimal = 0

        For i = 0 To dataGridView1.Rows.Count - 1
            totalunit_2 += dataGridView1.Rows(i).Cells(8).Value
            totalgrand_2 += dataGridView1.Rows(i).Cells(10).Value

            If txtVATAMOUNT_2.Text = String.Empty Then

                Exit For

            Else

                totalvat_2 += CDbl(dataGridView1.Rows(i).Cells(9).Value).ToString("#,##0.00")
                txtVATTOTAL_2.Text = CDbl(totalvat_2).ToString("#,##0.00")

            End If


        Next

        txtTOTALUNIT_2.Text = totalunit_2
        txtGRANDTOTAL_2.Text = totalgrand_2


        '===============================================================================

        Dim totalunit_3 As Decimal = 0
        Dim totalvat_3 As Decimal = 0
        Dim totalgrand_3 As Decimal = 0

        For i = 0 To dataGridView1.Rows.Count - 1
            totalunit_3 += dataGridView1.Rows(i).Cells(12).Value
            totalgrand_3 += dataGridView1.Rows(i).Cells(14).Value

            If txtVATAMOUNT_3.Text = String.Empty Then

                Exit For

            Else

                totalvat_3 += CDbl(dataGridView1.Rows(i).Cells(13).Value).ToString("#,##0.00")
                txtVATTOTAL_3.Text = CDbl(totalvat_3).ToString("#,##0.00")

            End If


        Next

        txtTOTALUNIT_3.Text = totalunit_3
        txtGRANDTOTAL_3.Text = totalgrand_3


    End Sub

    Sub supplier_list()

        Dim combo As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn
        combo.HeaderText = "CHOOSE_SUPPLIER"
        combo.Name = "CHOOSE_SUPPLIER"
        combo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        combo.Items.Add(txtSUPPLIER_1.Text)
        combo.Items.Add(txtSUPPLIER_2.Text)
        combo.Items.Add(txtSUPPLIER_3.Text)
        dataGridView1.Columns.Add(combo)

    End Sub



    Private Sub dataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Try

            If dataGridView1.Columns(e.ColumnIndex).Name = "EDIT" Then

                Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)
                txtQTY.Text = dataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
                txtUNIT.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                txtDESCRIPTION.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString


                txtSUPPLIER_1.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                txtUNITPRICE_1.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                txtVATAMOUNT_1.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
                txtTOTALPRICE_1.Text = dataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString

                If txtVATAMOUNT_1.Text = 0 Then

                    txtVAT_1.Checked = False
                Else

                    txtVAT_1.Checked = True

                End If

                txtSUPPLIER_2.Text = dataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
                txtUNITPRICE_2.Text = dataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString
                txtVATAMOUNT_2.Text = dataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString
                txtTOTALPRICE_2.Text = dataGridView1.Rows(e.RowIndex).Cells(10).Value.ToString

                If txtVATAMOUNT_2.Text = 0 Then

                    txtVAT_2.Checked = False
                Else

                    txtVAT_2.Checked = True

                End If

                txtSUPPLIER_3.Text = dataGridView1.Rows(e.RowIndex).Cells(11).Value.ToString
                txtUNITPRICE_3.Text = dataGridView1.Rows(e.RowIndex).Cells(12).Value.ToString
                txtVATAMOUNT_3.Text = dataGridView1.Rows(e.RowIndex).Cells(13).Value.ToString
                txtTOTALPRICE_3.Text = dataGridView1.Rows(e.RowIndex).Cells(14).Value.ToString

                If txtVATAMOUNT_3.Text = 0 Then

                    txtVAT_3.Checked = False
                Else

                    txtVAT_3.Checked = True

                End If

            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "UPDATE" Then

                Dim update As DataGridViewRow = dataGridView1.SelectedRows(0)

                update.Cells(0).Value = txtQTY.Text
                update.Cells(1).Value = txtUNIT.Text
                update.Cells(2).Value = txtDESCRIPTION.Text

                update.Cells(3).Value = txtSUPPLIER_1.Text
                update.Cells(4).Value = txtUNITPRICE_1.Text
                update.Cells(5).Value = txtVATAMOUNT_1.Text
                update.Cells(6).Value = txtTOTALPRICE_1.Text

                update.Cells(7).Value = txtSUPPLIER_2.Text
                update.Cells(8).Value = txtUNITPRICE_2.Text
                update.Cells(9).Value = txtVATAMOUNT_2.Text
                update.Cells(10).Value = txtTOTALPRICE_2.Text

                update.Cells(11).Value = txtSUPPLIER_3.Text
                update.Cells(12).Value = txtUNITPRICE_3.Text
                update.Cells(13).Value = txtVATAMOUNT_3.Text
                update.Cells(14).Value = txtTOTALPRICE_3.Text

                '===============================================================================

                '===============================================================================

                Dim totalunit_1 As Decimal = 0
                Dim totalvat_1 As Decimal = 0
                Dim totalgrand_1 As Decimal = 0

                For i = 0 To dataGridView1.Rows.Count - 1
                    totalunit_1 += dataGridView1.Rows(i).Cells(4).Value
                    totalgrand_1 += dataGridView1.Rows(i).Cells(6).Value

                    If txtVATAMOUNT_1.Text = String.Empty Then

                        Exit For

                    Else

                        totalvat_1 += dataGridView1.Rows(i).Cells(5).Value
                        txtVATTOTAL_1.Text = totalvat_1

                    End If


                Next

                txtTOTALUNIT_1.Text = totalunit_1
                txtGRANDTOTAL_1.Text = totalgrand_1

                '===============================================================================

                If txtSUPPLIER_2.Text = String.Empty Then

                    Exit Sub

                Else

                    Dim totalunit_2 As Decimal = 0
                    Dim totalvat_2 As Decimal = 0
                    Dim totalgrand_2 As Decimal = 0

                    For i = 0 To dataGridView1.Rows.Count - 1
                        totalunit_2 += dataGridView1.Rows(i).Cells(8).Value
                        totalgrand_2 += dataGridView1.Rows(i).Cells(10).Value

                        If txtVATAMOUNT_2.Text = String.Empty Then

                            Exit For

                        Else

                            totalvat_2 += dataGridView1.Rows(i).Cells(9).Value
                            txtVATTOTAL_2.Text = totalvat_2

                        End If

                    Next

                    txtTOTALUNIT_2.Text = totalunit_2
                    txtVATTOTAL_2.Text = totalvat_2
                    txtGRANDTOTAL_2.Text = totalgrand_2

                End If

                '===============================================================================

                If txtSUPPLIER_3.Text = String.Empty Then

                    Exit Sub

                Else

                    Dim totalunit_3 As Decimal = 0
                    Dim totalvat_3 As Decimal = 0
                    Dim totalgrand_3 As Decimal = 0

                    For i = 0 To dataGridView1.Rows.Count - 1
                        totalunit_3 += dataGridView1.Rows(i).Cells(12).Value
                        totalgrand_3 += dataGridView1.Rows(i).Cells(14).Value

                        If txtVATAMOUNT_3.Text = String.Empty Then

                            Exit For

                        Else

                            totalvat_3 += dataGridView1.Rows(i).Cells(13).Value
                            txtVATTOTAL_3.Text = totalvat_3

                        End If

                    Next

                    txtTOTALUNIT_3.Text = totalunit_3
                    txtGRANDTOTAL_3.Text = totalgrand_3

                    Clear()

                End If

            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "DELETE" Then

                Try

                    If MsgBox("Do you want to Delete ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows(0).Index)

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, vbCritical)

                End Try

                '===============================================================================

                Dim totalunit_1 As Decimal = 0
                Dim totalvat_1 As Decimal = 0
                Dim totalgrand_1 As Decimal = 0

                For i = 0 To dataGridView1.Rows.Count - 1
                    totalunit_1 += dataGridView1.Rows(i).Cells(4).Value
                    totalvat_1 += dataGridView1.Rows(i).Cells(5).Value
                    totalgrand_1 += dataGridView1.Rows(i).Cells(6).Value
                Next

                txtTOTALUNIT_1.Text = totalunit_1
                txtVATTOTAL_1.Text = totalvat_1
                txtGRANDTOTAL_1.Text = totalgrand_1

                '===============================================================================

                If txtSUPPLIER_2.Text = String.Empty Then

                    Exit Sub

                Else

                    Dim totalunit_2 As Decimal = 0
                    Dim totalvat_2 As Decimal = 0
                    Dim totalgrand_2 As Decimal = 0

                    For i = 0 To dataGridView1.Rows.Count - 1
                        totalunit_2 += dataGridView1.Rows(i).Cells(8).Value
                        totalvat_2 += dataGridView1.Rows(i).Cells(9).Value
                        totalgrand_2 += dataGridView1.Rows(i).Cells(10).Value
                    Next

                    txtTOTALUNIT_2.Text = totalunit_2
                    txtVATTOTAL_2.Text = totalvat_2
                    txtGRANDTOTAL_2.Text = totalgrand_2

                End If

                '===============================================================================

                If txtSUPPLIER_3.Text = String.Empty Then

                    Exit Sub

                Else

                    Dim totalunit_3 As Decimal = 0
                    Dim totalvat_3 As Decimal = 0
                    Dim totalgrand_3 As Decimal = 0

                    For i = 0 To dataGridView1.Rows.Count - 1
                        totalunit_3 += dataGridView1.Rows(i).Cells(12).Value
                        totalvat_3 += dataGridView1.Rows(i).Cells(13).Value
                        totalgrand_3 += dataGridView1.Rows(i).Cells(14).Value
                    Next


                    txtTOTALUNIT_3.Text = totalunit_3
                    txtVATTOTAL_3.Text = totalvat_3
                    txtGRANDTOTAL_3.Text = totalgrand_3

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        LoadITEMNAME()

    End Sub

    Private Sub txtITEM_TextChanged(sender As Object, e As EventArgs) Handles txtITEM.TextChanged

        LoadITEMNAME()

    End Sub

    Private Sub frmTIC_PR_MANAGER_FORM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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