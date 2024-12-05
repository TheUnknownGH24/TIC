Public Class frmWAREHOUSE_SR

    Dim dt As DataTable
    Dim adp As MySqlDataAdapter

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

    Sub LoadITEM()

        DataGridView2.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tblitem", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView2.Rows.Add(dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        If txtSEARCHCLASSIFICATION.Text = "" Or txtSEARCHCLASSIFICATION.Text = String.Empty Then

            MsgBox("Please Select Classification!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        DataGridView2.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tblitem where `itemname` like '%" & txtSEARCHNAME.Text & "%' AND  `classification` like '%" & txtSEARCHCLASSIFICATION.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView2.Rows.Add(dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtSEARCHCLASSIFICATION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtSEARCHCLASSIFICATION.SelectedIndexChanged

        txtITEMCODE.Text = ""
        txtITEMDESCRIPTION.Text = ""
        txtCLASSIFICATION.Text = ""
        txtUOM.Text = ""
        txtQTYREQUESTED.Text = ""

        txtITEMCODE.Text = String.Empty
        txtITEMDESCRIPTION.Text = String.Empty
        txtCLASSIFICATION.Text = String.Empty
        txtUOM.Text = String.Empty
        txtQTYREQUESTED.Text = String.Empty

        DataGridView2.Rows.Clear()
        cn.Open()
        cm = New MySqlCommand("select * from tblitem where `classification` like '%" & txtSEARCHCLASSIFICATION.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read

            DataGridView2.Rows.Add(dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("uom").ToString, dr.Item("classification").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView2.DoubleClick

        txtITEMCODE.Text = DataGridView2.CurrentRow.Cells(0).Value
        txtITEMDESCRIPTION.Text = DataGridView2.CurrentRow.Cells(1).Value
        txtUOM.Text = DataGridView2.CurrentRow.Cells(2).Value
        txtCLASSIFICATION.Text = DataGridView2.CurrentRow.Cells(3).Value

    End Sub

    Private Sub frmWAREHOUSE_IPR_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Private Sub txtDATEREQUIRED_ValueChanged(sender As Object, e As EventArgs) Handles txtDATEREQUIRED.ValueChanged

        If txtDATEREQUIRED.Text <= Date.Now Then

            MsgBox("Please Enter Valid Date!", vbOKOnly + vbCritical, "CONFIRMATION")
            txtDATEREQUIRED.Text = Now.AddDays(1)
            txtDATEREQUIRED.Focus()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If txtITEMCODE.Text = String.Empty Or txtITEMDESCRIPTION.Text = String.Empty Or txtCLASSIFICATION.Text = String.Empty Or txtUOM.Text = String.Empty Or txtQTYREQUESTED.Text = String.Empty Then
            MsgBox("Please Complete data!", vbCritical + vbOKOnly, "CONFIRMATION")
            Return
        End If

        For i As Integer = 0 To dataGridView1.Rows.Count - 1

            If txtITEMCODE.Text = dataGridView1.Rows(i).Cells(0).Value.ToString() Then

                MsgBox("Item Already in List of Data!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return

            End If

        Next

        '=========================================================================================

        Try

            dataGridView1.Rows.Add(txtITEMCODE.Text, txtITEMDESCRIPTION.Text, txtCLASSIFICATION.Text, txtUOM.Text, txtQTYREQUESTED.Text)

            '=========================================================================================

            txtITEMCODE.Text = ""
            txtITEMDESCRIPTION.Text = ""
            txtCLASSIFICATION.Text = ""
            txtUOM.Text = ""
            txtQTYREQUESTED.Text = ""

            txtITEMCODE.Text = String.Empty
            txtITEMDESCRIPTION.Text = String.Empty
            txtCLASSIFICATION.Text = String.Empty
            txtUOM.Text = String.Empty
            txtQTYREQUESTED.Text = String.Empty


            btnSAVE.Enabled = True

        Catch ex As Exception

            'MessageBox.Show(ex.Message.ToString())

        End Try

    End Sub

    Private Sub dataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles dataGridView1.CurrentCellChanged

        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        dataGridView1.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

        If dataGridView1.CurrentCell Is Nothing Then

            txtSEARCHCLASSIFICATION.Enabled = True

        Else

            txtSEARCHCLASSIFICATION.Enabled = False

        End If

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Try

            If dataGridView1.Columns(e.ColumnIndex).Name = "EDIT" Then

                Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)
                txtITEMCODE.Text = dataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString
                txtITEMDESCRIPTION.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                txtCLASSIFICATION.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                txtUOM.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                txtQTYREQUESTED.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString

            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "UPDATE" Then

                Dim update As DataGridViewRow = dataGridView1.SelectedRows(0)

                update.Cells(0).Value = txtITEMCODE.Text
                update.Cells(1).Value = txtITEMDESCRIPTION.Text
                update.Cells(2).Value = txtCLASSIFICATION.Text
                update.Cells(3).Value = txtUOM.Text
                update.Cells(4).Value = txtQTYREQUESTED.Text

                txtITEMCODE.Text = ""
                txtITEMDESCRIPTION.Text = ""
                txtCLASSIFICATION.Text = ""
                txtUOM.Text = ""
                txtQTYREQUESTED.Text = ""

                txtITEMCODE.Text = String.Empty
                txtITEMDESCRIPTION.Text = String.Empty
                txtCLASSIFICATION.Text = String.Empty
                txtUOM.Text = String.Empty
                txtQTYREQUESTED.Text = String.Empty

            ElseIf dataGridView1.Columns(e.ColumnIndex).Name = "DELETE" Then

                Try

                    If MsgBox("Do you want to Delete ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows(0).Index)

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, vbCritical)

                End Try

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If txtPURPOSE.Text = "" Then

            MsgBox("Please input Purpose!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If dataGridView1.CurrentCell Is Nothing Then

            MsgBox("Please Entry Data!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

            cn.Open()
            cm = New MySqlCommand("INSERT into tbl_warehouse_sr (date, transactionno, date_required, requestor, department, purpose, warehouse, classification, manager_name, manager_approval, manager_comment, final_name, final_approval, final_comment, date_time, status, request_status) values(@date, @transactionno, @date_required, @requestor, @department, @purpose, @warehouse, @classification, @manager_name, @manager_approval, @manager_comment, @final_name, @final_approval, @final_comment, @date_time, @status, @request_status)", cn)
            With cm.Parameters

                .AddWithValue("@date", txtDATE.Text)
                .AddWithValue("@transactionno", txtTRANSACTION.Text)
                .AddWithValue("@date_required", txtDATEREQUIRED.Text)
                .AddWithValue("@requestor", txtREQUESTOR.Text)
                .AddWithValue("@department", txtDEPARTMENT.Text)
                .AddWithValue("@purpose", txtPURPOSE.Text)
                .AddWithValue("@warehouse", txtWAREHOUSE.Text)
                .AddWithValue("@classification", txtSEARCHCLASSIFICATION.Text)

                .AddWithValue("@manager_name", " ")
                .AddWithValue("@manager_approval", "FOR APPROVAL")
                .AddWithValue("@manager_comment", " ")

                .AddWithValue("@final_name", " ")
                .AddWithValue("@final_approval", "FOR APPROVAL")
                .AddWithValue("@final_comment", " ")

                .AddWithValue("@date_time", DateTimePicker1.Value)
                .AddWithValue("@status", "ACTIVE")

                .AddWithValue("@request_status", " ")

            End With
            cm.ExecuteNonQuery()
            cn.Close()

            DisplaySR()
            SaveInISRList()

            btnSAVE.Enabled = False
            btnPRINT.Enabled = True
            Button2.Enabled = False

            dataGridView1.Enabled = False

            txtDATEREQUIRED.Enabled = False
            txtPURPOSE.Enabled = False
            txtSEARCHCLASSIFICATION.Enabled = False

            MsgBox("Stock Replenishment Request has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

        Else

            MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Sub DisplaySR()

        cn.Open()
        adp = New MySqlDataAdapter("select * from tbl_warehouse_sr where `transactionno` = '" & txtTRANSACTION.Text & "'", cn)
        dt = New DataTable
        adp.Fill(dt)

        txtCONTROL.Text = dt.Rows(0)(1).ToString()

        cn.Close()

    End Sub

    Sub SaveInISRList()

        For Each row As DataGridViewRow In dataGridView1.Rows

            cm = New MySqlCommand("INSERT into tbl_warehouse_sr_item (sr_no, item_code, item_name, classification, uom, qty_requested) values(@sr_no, @item_code, @item_name, @classification, @uom, @qty_requested)", cn)

            With cm.Parameters

                .AddWithValue("@sr_no", txtCONTROL.Text)

                .AddWithValue("@item_code", row.Cells("ITEM_CODE").Value)
                .AddWithValue("@item_name", row.Cells("ITEM_DESCRIPTION").Value)
                .AddWithValue("@classification", row.Cells("CLASSIFICATION").Value)
                .AddWithValue("@uom", row.Cells("UOM").Value)
                .AddWithValue("@qty_requested", row.Cells("QTY_REQUESTED").Value)

            End With
            cn.Open()
            cm.ExecuteNonQuery()
            cn.Close()
        Next

    End Sub

    Private Sub btnRESET_Click(sender As Object, e As EventArgs) Handles btnRESET.Click

        Try
            If MsgBox("Do you want to Reset ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                txtCONTROL.Text = ""
                txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")
                txtPURPOSE.Text = ""

                txtCONTROL.Text = String.Empty
                txtPURPOSE.Text = String.Empty

                dataGridView1.Rows.Clear()

                Button2.Enabled = True

                txtDATEREQUIRED.Enabled = True
                txtPURPOSE.Enabled = True
                txtSEARCHCLASSIFICATION.Enabled = True

                LoadClassification()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub








End Class