Public Class frmWAREHOUSE_INVENTORY_LIST

    Sub LoadITEMList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblitem", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("classification").ToString, dr.Item("mother_class").ToString, dr.Item("sub_class_1").ToString, dr.Item("sub_class_2").ToString, dr.Item("sub_class_3").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Private Sub frmWAREHOUSE_INVENTORY_LIST_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Sub loadCOUNT_CLASSIFICATION()

        txtCLASSIFICATION_STOCK.Clear()

        cn.Open()
        Using cm = New MySqlCommand("select count(classification) from tbl_warehouse_inventory where `classification` like '" & txtCLASSICATION.Text & "'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            'Dim sum As Double

            txtCLASSIFICATION_STOCK.Text = String.Format("{0}", count)

            'sum = txtCLASSIFICATION_STOCK.Text + 1

            'txtCLASSIFICATION_STOCK.Text = Format(sum, "000")

        End Using
        cn.Close()

    End Sub

    Sub loadCOUNT_MOTHERCLASS()

        txtMOTHERCLASS_STOCK.Clear()

        cn.Open()
        Using cm = New MySqlCommand("select count(mother_class) from tbl_warehouse_inventory where `mother_class` like '" & txtMOTHERCLASS.Text & "'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            'Dim sum As Double

            txtMOTHERCLASS_STOCK.Text = String.Format("{0}", count)

            'sum = txtCLASSIFICATION_STOCK.Text + 1

            'txtCLASSIFICATION_STOCK.Text = Format(sum, "000")

        End Using
        cn.Close()

    End Sub

    Sub loadCOUNT_BRAND()

        txtBRAND_STOCK.Clear()

        cn.Open()
        Using cm = New MySqlCommand("select count(sub_class_1) from tbl_warehouse_inventory where `sub_class_1` like '" & txtBRAND.Text & "'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            'Dim sum As Double

            txtBRAND_STOCK.Text = String.Format("{0}", count)

            'sum = txtCLASSIFICATION_STOCK.Text + 1

            'txtCLASSIFICATION_STOCK.Text = Format(sum, "000")

        End Using
        cn.Close()

    End Sub


    Private Sub txtCLASSICATION_TextChanged(sender As Object, e As EventArgs) Handles txtCLASSICATION.TextChanged

        If txtCLASSICATION.Text = String.Empty Then
            txtCLASSIFICATION_STOCK.Text = ""
        Else
            loadCOUNT_CLASSIFICATION()
        End If

    End Sub

    Private Sub txtMOTHERCLASS_TextChanged(sender As Object, e As EventArgs) Handles txtMOTHERCLASS.TextChanged

        If txtMOTHERCLASS.Text = String.Empty Then
            txtMOTHERCLASS_STOCK.Text = ""
        Else
            loadCOUNT_MOTHERCLASS()
        End If

    End Sub

    Private Sub txtBRAND_TextChanged(sender As Object, e As EventArgs) Handles txtBRAND.TextChanged

        If txtBRAND.Text = String.Empty Then
            txtBRAND_STOCK.Text = ""
        Else
            loadCOUNT_BRAND()
        End If

    End Sub

    Sub loadCOUNT_STOCK()

        cn.Open()
        Using cm = New MySqlCommand("select count(itemname) from tbl_warehouse_inventory where `itemname` like '" & txtITEMNAME.Text & "'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            'Dim sum As Double

            txtSTATUSDATA.Text = String.Format("{0}", count)

            'sum = txtCLASSIFICATION_STOCK.Text + 1

            'txtCLASSIFICATION_STOCK.Text = Format(sum, "000")

        End Using
        cn.Close()

    End Sub

    Private Sub txtITEMNAME_TextChanged(sender As Object, e As EventArgs) Handles txtITEMNAME.TextChanged

        If txtITEMNAME.Text = String.Empty Then
            txtSTATUSDATA.Text = "0"
        Else
            loadCOUNT_STOCK()
        End If

    End Sub

    Private Sub dataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles dataGridView1.CurrentCellChanged

        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        dataGridView1.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Dim colname As String = dataGridView1.Columns(e.ColumnIndex).Name

        If colname = "VIEW" Then

            txtCLASSICATION.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
            txtMOTHERCLASS.Text = dataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString
            txtBRAND.Text = dataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString

            txtITEMCODE.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
            txtITEMNAME.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
            txtITEMNAME.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
            txtUOM.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
            txtITEMCLASSIFICATION.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
            txtITEMMOTHERCLASS.Text = dataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString
            txtITEMBRAND.Text = dataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
            txtCOLOR.Text = dataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString
            txtSIZE.Text = dataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString

        End If

    End Sub

    Sub SEARCH_ITEM()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblitem where `classification` like '%" & txtSEARCHCLASSIFICATION.Text & "%' AND `mother_class` like '%" & txtSEARCHMOTHERCLASS.Text & "%' AND `sub_class_1` like '%" & txtSEARCHBRAND.Text & "%' AND `sub_class_2` like '%" & txtSEARCHCOLORVARIANT.Text & "%' AND `sub_class_3` like '%" & txtSEARCHSIZE.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("classification").ToString, dr.Item("mother_class").ToString, dr.Item("sub_class_1").ToString, dr.Item("sub_class_2").ToString, dr.Item("sub_class_3").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub


    Private Sub txtSEARCHCLASSIFICATION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtSEARCHCLASSIFICATION.SelectedIndexChanged

        'txtSEARCHCLASSIFICATION.Items.Clear()
        'txtSEARCHMOTHERCLASS.Items.Clear()
        'txtSEARCHBRAND.Items.Clear()
        'txtSEARCHCOLORVARIANT.Items.Clear()
        'txtSEARCHSIZE.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from `tblmotherclass` WHERE `classification` LIKE '%" & txtSEARCHCLASSIFICATION.Text & "%' ", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtSEARCHMOTHERCLASS.Items.Add(dr.Item("generic_name").ToString)

        End While

        dr.Close()
        cn.Close()

        SEARCH_ITEM()

    End Sub


    Private Sub txtSEARCHMOTHERCLASS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtSEARCHMOTHERCLASS.SelectedIndexChanged

        txtSEARCHBRAND.Items.Clear()
        txtSEARCHCOLORVARIANT.Items.Clear()
        txtSEARCHSIZE.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from `tblitem` WHERE `classification` LIKE '%" & txtSEARCHCLASSIFICATION.Text & "%' AND `mother_class` LIKE '%" & txtSEARCHMOTHERCLASS.Text & "%' ", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtSEARCHBRAND.Items.Add(dr.Item("sub_class_1").ToString)

        End While

        dr.Close()
        cn.Close()

        SEARCH_ITEM()

    End Sub



    Private Sub txtSEARCHBRAND_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtSEARCHBRAND.SelectedIndexChanged

        txtSEARCHCOLORVARIANT.Items.Clear()
        txtSEARCHSIZE.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from `tblitem` WHERE `classification` LIKE '%" & txtSEARCHCLASSIFICATION.Text & "%' AND `mother_class` LIKE '%" & txtSEARCHMOTHERCLASS.Text & "%' AND `sub_class_1` LIKE '%" & txtSEARCHBRAND.Text & "%' ", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtSEARCHCOLORVARIANT.Items.Add(dr.Item("sub_class_2").ToString)

        End While

        dr.Close()
        cn.Close()

        SEARCH_ITEM()

    End Sub

    Private Sub txtSEARCHCOLORVARIANT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtSEARCHCOLORVARIANT.SelectedIndexChanged

        txtSEARCHSIZE.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from `tblitem` WHERE `classification` LIKE '%" & txtSEARCHCLASSIFICATION.Text & "%' AND `mother_class` LIKE '%" & txtSEARCHMOTHERCLASS.Text & "%' AND `sub_class_1` LIKE '%" & txtSEARCHBRAND.Text & "%' AND `sub_class_2` LIKE '%" & txtSEARCHCOLORVARIANT.Text & "%' ", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtSEARCHSIZE.Items.Add(dr.Item("sub_class_3").ToString)

        End While

        dr.Close()
        cn.Close()

        SEARCH_ITEM()

    End Sub

    Sub LoadClassification()

        txtSEARCHCLASSIFICATION.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblclassification", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtSEARCHCLASSIFICATION.Items.Add(dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub


    Private Sub txtSEARCHSIZE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtSEARCHSIZE.SelectedIndexChanged

        SEARCH_ITEM()

    End Sub


End Class

