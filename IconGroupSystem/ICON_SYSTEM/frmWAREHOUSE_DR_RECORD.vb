Public Class frmWAREHOUSE_DR_RECORD

    Sub Add_Approval_Button()

        Dim colApproval As New DataGridViewButtonColumn
        With colApproval
            .Width = 50
            .Name = "MANAGER_APPROVAL"
            .HeaderText = ""
            .Text = ">"
            .UseColumnTextForButtonValue = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End With
        DataGridView2.Columns.Insert(23, colApproval)

    End Sub

    Sub LoadDRList()

        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_dr", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("dr_no").ToString, dr.Item("reference_no").ToString, dr.Item("employee_name").ToString, dr.Item("date").ToString, dr.Item("requestor_name").ToString, dr.Item("purpose").ToString, dr.Item("sub_reference").ToString, dr.Item("reference").ToString, dr.Item("date_received").ToString, dr.Item("delivery_status").ToString, dr.Item("warehouse").ToString, dr.Item("supervisor_name").ToString, dr.Item("supervisor_approval").ToString, dr.Item("supervisor_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("date_time").ToString, dr.Item("status").ToString, dr.Item("dispatch").ToString, dr.Item("recieved").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        DataGridView2.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_dr where dr_no like '%" & TextBox1.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            DataGridView2.Rows.Add(i, dr.Item("id").ToString, dr.Item("dr_no").ToString, dr.Item("reference_no").ToString, dr.Item("employee_name").ToString, dr.Item("date").ToString, dr.Item("requestor_name").ToString, dr.Item("purpose").ToString, dr.Item("sub_reference").ToString, dr.Item("reference").ToString, dr.Item("date_received").ToString, dr.Item("delivery_status").ToString, dr.Item("warehouse").ToString, dr.Item("supervisor_name").ToString, dr.Item("supervisor_approval").ToString, dr.Item("supervisor_comment").ToString, dr.Item("final_name").ToString, dr.Item("final_approval").ToString, dr.Item("final_comment").ToString, dr.Item("date_time").ToString, dr.Item("status").ToString, dr.Item("dispatch").ToString, dr.Item("recieved").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub DataGridView2_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView2.CurrentCellDirtyStateChanged

        DataGridView2.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        dataGridView1.Rows.Clear()
        txtSUPERVISORCOMMENT.Text = ""
        txtSUPERVISORCOMMENT.Text = String.Empty

        txtMANAGERCOMMENT.Text = ""
        txtMANAGERCOMMENT.Text = String.Empty

        Dim colname As String = DataGridView2.Columns(e.ColumnIndex).Name

        If colname = "MANAGER_APPROVAL" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_dr where id like '" & DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = DataGridView2.Rows(e.RowIndex).Cells(1).Value.ToString
                txtCONTROL.Text = DataGridView2.Rows(e.RowIndex).Cells(2).Value.ToString
                txtPONO.Text = DataGridView2.Rows(e.RowIndex).Cells(3).Value.ToString

                txtDATE.Text = DataGridView2.Rows(e.RowIndex).Cells(5).Value.ToString
                txtSUPPLIERNAME.Text = DataGridView2.Rows(e.RowIndex).Cells(6).Value.ToString
                txtPURPOSE.Text = DataGridView2.Rows(e.RowIndex).Cells(7).Value.ToString

                txtSUBREFERENCE.Text = DataGridView2.Rows(e.RowIndex).Cells(8).Value.ToString
                txtREFERENCE.Text = DataGridView2.Rows(e.RowIndex).Cells(9).Value.ToString
                'txtRECEIVEDDATE.Text = DataGridView2.Rows(e.RowIndex).Cells(10).Value.ToString

                txtSTATUS.Text = DataGridView2.Rows(e.RowIndex).Cells(11).Value.ToString
                txtWAREHOUSE.Text = DataGridView2.Rows(e.RowIndex).Cells(12).Value.ToString

                txtSUPERVISORCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(13).Value.ToString & " - " & DataGridView2.Rows(e.RowIndex).Cells(15).Value.ToString

                txtMANAGERCOMMENT.Text = DataGridView2.Rows(e.RowIndex).Cells(16).Value.ToString & " - " & DataGridView2.Rows(e.RowIndex).Cells(18).Value.ToString

                txtAPPROVAL_1.Text = DataGridView2.Rows(e.RowIndex).Cells(14).Value.ToString
                txtAPPROVAL_2.Text = DataGridView2.Rows(e.RowIndex).Cells(17).Value.ToString

                txtSTATUSDATA.Text = DataGridView2.Rows(e.RowIndex).Cells(20).Value.ToString

            End While
            dr.Close()
            cn.Close()

            LoadDRITEMLIST()

            btnPRINT.Enabled = True

        End If

    End Sub

    Sub LoadDRITEMLIST()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_dr_item where `dr_no` like '" & txtCONTROL.Text & "' ", cn)
        dr = cm.ExecuteReader

        While dr.Read

            dataGridView1.Rows.Add(dr.Item("itemcode").ToString, dr.Item("itemname").ToString, dr.Item("unit").ToString, dr.Item("qty_loose").ToString, dr.Item("qty_case_bulk").ToString, dr.Item("per_case_bulk").ToString, dr.Item("total_quantity").ToString, dr.Item("unit_price").ToString, dr.Item("vat_amount").ToString, dr.Item("grand_total").ToString, dr.Item("status").ToString, dr.Item("remaining").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtSUPERVISORCOMMENT.Text
            .ShowDialog()

        End With



    End Sub

    Private Sub btnPRINT_Click(sender As Object, e As EventArgs) Handles btnPRINT.Click

        Try

            If MsgBox("Do you want to Proceed ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_warehouse_dr set supervisor_approval=@supervisor_approval, final_name=@final_name, final_approval=@final_approval, final_comment=@final_comment, status=@status where id=@id", cn)

                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)

                    .AddWithValue("@supervisor_approval", "FOR APPROVAL")

                    .AddWithValue("@final_name", txtNAME.Text)
                    .AddWithValue("@final_approval", "FOR APPROVAL")
                    .AddWithValue("@final_comment", txtSUPERVISORCOMMENT.Text & "-" & DateTimePicker1.Value)

                    .AddWithValue("@status", "RETURNED")

                End With

                cm.ExecuteNonQuery()
                cn.Close()

                LoadDRList()

                btnPRINT.Enabled = False

                MsgBox("Delivery Receipt has been Successfully Returned!", vbInformation + vbOKOnly, "CONFIRMATION")

            Else

                MsgBox("Saving Termindated", vbOKOnly + vbCritical, "CONFIRMATION")

            End If

        Catch ex As Exception

            cn.Close()
            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub dataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles dataGridView1.CurrentCellChanged

        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        dataGridView1.DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        With frmPURPOSE

            .txtSHOWPURPOSE.Text = txtMANAGERCOMMENT.Text
            .ShowDialog()

        End With

    End Sub

    Private Sub frmWAREHOUSE_DR_RECORD_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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