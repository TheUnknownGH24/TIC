Imports System.Data.OleDb
Imports System.Text

Public Class frmWAREHOUSE_DR_LAZADA

    Private Sub btnBROWSE_Click(sender As Object, e As EventArgs) Handles btnBROWSE.Click

        OpenFileDialog1.Filter = "Excel|*.xls;*.xlsx"
        OpenFileDialog1.ShowDialog()
        txtFILEPATH.Text = OpenFileDialog1.FileName

        Dim filepath As String = txtFILEPATH.Text
        Dim connstring As String = String.Empty
        If filepath.EndsWith(".xls") Then
            connstring = String.Format("Provider=Microsoft.Jet.Oledb.4.0;" &
                                       "Data Source={0};Extended Properties='Excel 8.0;HDR=yes'", filepath)
        Else
            connstring = String.Format("Provider=Microsoft.Ace.Oledb.12.0;" &
                                       "Data Source={0};Extended Properties='Excel 8.0;HDR=yes'", filepath)
        End If
        Dim conn As New OleDbConnection(connstring)
        conn.Open()
        txtSHEETS.DataSource = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        txtSHEETS.DisplayMember = "Table_Name"
        txtSHEETS.ValueMember = "Table_Name"
        conn.Close()
        btnBROWSE.Enabled = True
        btnDISPLAY.Enabled = True
        btnBROWSE.Enabled = True
        btnDISPLAY.Enabled = True

    End Sub

    Private Sub btnDISPLAY_Click(sender As Object, e As EventArgs) Handles btnDISPLAY.Click

        Dim filepath As String = txtFILEPATH.Text
        Dim connstring As String = String.Empty
        If filepath.EndsWith(".xls") Then
            connstring = String.Format("Provider=Microsoft.Jet.Oledb.4.0;" &
                                       "Data Source={0};Extended Properties='Excel 8.0;HDR=yes'", filepath)
        Else
            connstring = String.Format("Provider=Microsoft.Ace.Oledb.12.0;" &
                                       "Data Source={0};Extended Properties='Excel 8.0;HDR=yes'", filepath)
        End If
        Dim cmd As New OleDbDataAdapter("Select * from[" & txtSHEETS.Text & "" & "]", connstring)
        cmd.TableMappings.Add("Table", "Table")
        Dim dt As New DataSet
        cmd.Fill(dt)
        dataGridView1.DataSource = dt.Tables(0)

        Dim checkboxcol As New DataGridViewCheckBoxColumn
        With checkboxcol
            .Width = 50
            .Name = "checkboxcol"
            .HeaderText = "#"
            .DefaultCellStyle.NullValue = False
        End With

        'dataGridView1.Columns.Insert(0, checkboxcol)
        'btnBROWSE.Enabled = True
        'btnDISPLAY.Enabled = True
        'txtSEARCHNAME.Enabled = True
        'btnCREATE.Enabled = False

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

        'txtSO_NO.Text = DataGridView1.CurrentRow.Cells(2).Value
        'txtSOLDTO.Text = dataGridView1.CurrentRow.Cells(19).Value
        'txtADDRESS.Text = dataGridView1.CurrentRow.Cells(17).Value

        btnBROWSE.Enabled = True
        btnDISPLAY.Enabled = True
        btnCREATE.Enabled = True

    End Sub

    Private Sub btnCREATE_Click(sender As Object, e As EventArgs) Handles btnCREATE.Click

        If DataGridView2.CurrentCell Is Nothing Then

            MsgBox("Please Extract Data!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            txtTRANSAC.Text = Now.ToString("yyyyMMddHHmmss")

            DeleteInList()
            Save_Data()
            Save_list()

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Sub DeleteInList()

        cm = New MySqlCommand("TRUNCATE tbl_warehouse_extract_loyverse", cn)

        cn.Open()
        cm.ExecuteNonQuery()
        cn.Close()

    End Sub

    Sub Save_Data()

        For Each row As DataGridViewRow In DataGridView2.Rows

            cm = New MySqlCommand("INSERT into tbl_warehouse_extract_loyverse (date, receipt_number, receipt_type, category, sku, item, variant, modifiers_applied, quantity, gross_sales, discounts, net_sales, cost_of_goods, gross_profit, taxes, pos, store, cashier_name, customer_name, customer_contacts, comment, status, transaction_no) values(@date, @receipt_number, @receipt_type, @category, @sku, @item, @variant, @modifiers_applied, @quantity, @gross_sales, @discounts, @net_sales, @cost_of_goods, @gross_profit, @taxes, @pos, @store, @cashier_name, @customer_name, @customer_contacts, @comment, @status, @transaction_no)", cn)
            With cm.Parameters

                .AddWithValue("@date", row.Cells("Date_").Value)
                .AddWithValue("@receipt_number", row.Cells("Receipt_number").Value)
                .AddWithValue("@receipt_type", row.Cells("Receipt_type").Value)
                .AddWithValue("@category", "-")
                .AddWithValue("@sku", row.Cells("SKU").Value)
                .AddWithValue("@item", row.Cells("Item").Value)
                .AddWithValue("@variant", "-")
                .AddWithValue("@modifiers_applied", "-")
                .AddWithValue("@quantity", row.Cells("Quantity").Value)
                .AddWithValue("@gross_sales", row.Cells("Gross_sales").Value)
                .AddWithValue("@discounts", row.Cells("Discounts").Value)
                .AddWithValue("@net_sales", row.Cells("Net_sales").Value)
                .AddWithValue("@cost_of_goods", row.Cells("Cost_of_goods").Value)
                .AddWithValue("@gross_profit", row.Cells("Gross_profit").Value)
                .AddWithValue("@taxes", row.Cells("Taxes").Value)
                .AddWithValue("@pos", row.Cells("POS").Value)
                .AddWithValue("@store", row.Cells("Store").Value)
                .AddWithValue("@cashier_name", row.Cells("Cashier_name").Value)
                .AddWithValue("@customer_name", row.Cells("Customer_name").Value)
                .AddWithValue("@customer_contacts", "-")
                .AddWithValue("@comment", "-")
                .AddWithValue("@status", "-")
                .AddWithValue("@transaction_no", txtTRANSAC.Text)

            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()

        Next

    End Sub

    Sub Save_list()

        For Each row As DataGridViewRow In DataGridView1.Rows

            cm = New MySqlCommand("INSERT into tbl_warehouse_extract_loyverse_list (sales_order, sku, item, quantity, item_amount, discount, net_sales, customer_name, type, transaction_no) values(@sales_order, @sku, @item, @quantity, @item_amount, @discount, @net_sales, @customer_name, @type, @transaction_no)", cn)
            With cm.Parameters

                .AddWithValue("@sales_order", row.Cells("Receipt number").Value)
                .AddWithValue("@sku", row.Cells("SKU").Value)
                .AddWithValue("@item", row.Cells("Item").Value)
                .AddWithValue("@quantity", row.Cells("Quantity").Value)
                .AddWithValue("@item_amount", row.Cells("Gross sales").Value)
                .AddWithValue("@discount", row.Cells("Discounts").Value)
                .AddWithValue("@net_sales", row.Cells("Net sales").Value)
                .AddWithValue("@customer_name", row.Cells("Customer name").Value)

                .AddWithValue("@type", "LOYVERSE")

                .AddWithValue("@transaction_no", txtTRANSAC.Text)

            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()

        Next

        MsgBox("Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        COPY_DBASE_DELETE()
        REMOVE_DUPLICATE()

        REMOVE_CANCEL_1()
        REMOVE_CANCEL_1()
        REMOVE_CANCEL_1()

        REMOVE_CANCEL_2()
        REMOVE_CANCEL_2()
        REMOVE_CANCEL_2()

        'REMOVE_REFUND()
        'REMOVE_REFUND()
        'REMOVE_REFUND()

        'REMOVE_NONE_1()
        'REMOVE_NONE_1()
        'REMOVE_NONE_1()

        'REMOVE_NONE_2()
        'REMOVE_NONE_2()
        'REMOVE_NONE_2()

    End Sub

    Sub COPY_DBASE_DELETE()

        For i = 0 To DataGridView1.Rows.Count - 1

            DataGridView2.Rows.Add(DataGridView1.Rows(i).Cells.Cast(Of DataGridViewCell).Select(Function(A) A.Value).ToArray)

        Next

    End Sub

    Sub REMOVE_DUPLICATE()

        Dim uniqueValues As New HashSet(Of String)()

        For i As Integer = DataGridView2.Rows.Count - 1 To 0 Step -1
            Dim row As DataGridViewRow = DataGridView2.Rows(i)
            Dim value As String = row.Cells("orderItemId").Value.ToString()
            If uniqueValues.Contains(value) Then
                DataGridView2.Rows.Remove(row)
            Else
                uniqueValues.Add(value)
            End If
        Next

    End Sub

    Sub REMOVE_CANCEL_1()

        For Each row As DataGridViewRow In DataGridView1.Rows
            ' Assuming you're looking for a specific value in the first column
            If Not row.IsNewRow AndAlso row.Cells(65).Value IsNot Nothing AndAlso row.Cells(65).Value.ToString() = "canceled" Then
                DataGridView1.Rows.Remove(row)
            End If
        Next

    End Sub

    Sub REMOVE_CANCEL_2()

        For Each row As DataGridViewRow In DataGridView2.Rows
            ' Assuming you're looking for a specific value in the first column
            If Not row.IsNewRow AndAlso row.Cells(65).Value IsNot Nothing AndAlso row.Cells(65).Value.ToString() = "canceled" Then
                DataGridView2.Rows.Remove(row)
            End If
        Next

    End Sub

    Sub REMOVE_REFUND()

        For Each row As DataGridViewRow In DataGridView2.Rows
            ' Assuming you're looking for a specific value in the first column
            If Not row.IsNewRow AndAlso row.Cells(2).Value IsNot Nothing AndAlso row.Cells(2).Value.ToString() = "Refund" Then
                DataGridView2.Rows.Remove(row)
            End If
        Next

    End Sub

    Sub REMOVE_NONE_1()

        For Each row As DataGridViewRow In DataGridView1.Rows
            ' Assuming you're looking for a specific value in the first column
            If Not row.IsNewRow AndAlso row.Cells(18).Value IsNot Nothing AndAlso row.Cells(18).Value.ToString() = "" Then
                DataGridView1.Rows.Remove(row)
            End If
        Next

    End Sub

    Sub REMOVE_NONE_2()

        For Each row As DataGridViewRow In DataGridView2.Rows
            ' Assuming you're looking for a specific value in the first column
            If Not row.IsNewRow AndAlso row.Cells(18).Value IsNot Nothing AndAlso row.Cells(18).Value.ToString() = "" Then
                DataGridView2.Rows.Remove(row)
            End If
        Next

    End Sub

    Sub LoadList()

        DataGridView2.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_extract_loyverse", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView2.Rows.Add(dr.Item("date").ToString, dr.Item("receipt_number").ToString, dr.Item("receipt_type").ToString, dr.Item("category").ToString, dr.Item("sku").ToString, dr.Item("item").ToString, dr.Item("variant").ToString, dr.Item("modifiers_applied").ToString, dr.Item("quantity").ToString, dr.Item("gross_sales").ToString, dr.Item("discounts").ToString, dr.Item("net_sales").ToString, dr.Item("cost_of_goods").ToString, dr.Item("gross_profit").ToString, dr.Item("taxes").ToString, dr.Item("pos").ToString, dr.Item("store").ToString, dr.Item("cashier_name").ToString, dr.Item("customer_name").ToString, dr.Item("customer_contacts").ToString, dr.Item("comment").ToString, dr.Item("status").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub frmWAREHOUSE_DR_LAZADA_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub




End Class