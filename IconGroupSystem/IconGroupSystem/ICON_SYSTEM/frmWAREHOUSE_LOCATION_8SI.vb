Public Class frmWAREHOUSE_LOCATION_8SI

    Private Sub frmWAREHOUSE_LOCATION_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Sub LoadPO()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_po_8si", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("po_no").ToString, dr.Item("supplier_name").ToString, dr.Item("location_1").ToString, dr.Item("location_2").ToString, dr.Item("location_3").ToString, dr.Item("location_4").ToString, dr.Item("location_5").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub txtREFERENCE_TextChanged(sender As Object, e As EventArgs) Handles txtREFERENCE.TextChanged

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_po_8si where `po_no` like '%" & txtREFERENCE.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("po_no").ToString, dr.Item("supplier_name").ToString, dr.Item("location_1").ToString, dr.Item("location_2").ToString, dr.Item("location_3").ToString, dr.Item("location_4").ToString, dr.Item("location_5").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        If txtREFERENCE.Text = String.Empty Then

            txtPONO.Text = ""

            txtLOCATION_1.Text = ""
            txtLOCATION_2.Text = ""
            txtLOCATION_3.Text = ""
            txtLOCATION_4.Text = ""
            txtLOCATION_5.Text = ""

        Else

            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_po_8si where `po_no` like '" & txtREFERENCE.Text & "'", cn)

            dr = cm.ExecuteReader

            While dr.Read

                txtPONO.Text = dr("po_no").ToString()

                txtLOCATION_1.Text = dr("location_1").ToString()
                txtLOCATION_2.Text = dr("location_2").ToString()
                txtLOCATION_3.Text = dr("location_3").ToString()
                txtLOCATION_4.Text = dr("location_4").ToString()
                txtLOCATION_5.Text = dr("location_5").ToString()

            End While

            dr.Close()
            cn.Close()

        End If

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        Try

            If txtLOCATION_1.Text = String.Empty Then
                MsgBox("Please select 1 location from list!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If MsgBox("Update Delivery Location ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_warehouse_po_8si set location_1=@location_1, location_2=@location_2, location_3=@location_3, location_4=@location_4, location_5=@location_5 where po_no=@po_no", cn)
                With cm.Parameters

                    .AddWithValue("@po_no", txtPONO.Text)

                    .AddWithValue("@location_1", txtLOCATION_1.Text)


                    If txtLOCATION_2.Text = String.Empty Or txtLOCATION_2.Text = "" Then
                        .AddWithValue("@location_2", " ")
                    Else
                        .AddWithValue("@location_2", txtLOCATION_2.Text)
                    End If


                    If txtLOCATION_3.Text = String.Empty Or txtLOCATION_3.Text = "" Then
                        .AddWithValue("@location_3", " ")
                    Else
                        .AddWithValue("@location_3", txtLOCATION_3.Text)
                    End If


                    If txtLOCATION_4.Text = String.Empty Or txtLOCATION_4.Text = "" Then
                        .AddWithValue("@location_4", " ")
                    Else
                        .AddWithValue("@location_4", txtLOCATION_4.Text)
                    End If


                    If txtLOCATION_5.Text = String.Empty Or txtLOCATION_5.Text = "" Then
                        .AddWithValue("@location_5", " ")
                    Else
                        .AddWithValue("@location_5", txtLOCATION_5.Text)
                    End If

                End With
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Data has been Successfully Update!", vbInformation + vbOKOnly, "CONFIRMATION")

                txtID.Text = ""

                txtPONO.Text = ""
                txtSUPPLIER.Text = ""

                txtLOCATION_1.SelectedIndex = -1
                txtLOCATION_2.SelectedIndex = -1
                txtLOCATION_3.SelectedIndex = -1
                txtLOCATION_4.SelectedIndex = -1
                txtLOCATION_5.SelectedIndex = -1

                LoadPO()

                btnSAVE.Enabled = False

            End If

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Sub LoadWAREHOUSE()

        txtLOCATION_1.Items.Clear()
        txtLOCATION_2.Items.Clear()
        txtLOCATION_3.Items.Clear()
        txtLOCATION_4.Items.Clear()
        txtLOCATION_5.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtLOCATION_1.Items.Add(dr.Item("warehouse_name").ToString)
            txtLOCATION_2.Items.Add(dr.Item("warehouse_name").ToString)
            txtLOCATION_3.Items.Add(dr.Item("warehouse_name").ToString)
            txtLOCATION_4.Items.Add(dr.Item("warehouse_name").ToString)
            txtLOCATION_5.Items.Add(dr.Item("warehouse_name").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Dim colname As String = dataGridView1.Columns(e.ColumnIndex).Name

        LoadWAREHOUSE()

        If colname = "colUPDATE" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_po_8si where id like '" & dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                txtPONO.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                txtSUPPLIER.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString

                txtLOCATION_1.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                txtLOCATION_2.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
                txtLOCATION_3.Text = dataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString
                txtLOCATION_4.Text = dataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
                txtLOCATION_5.Text = dataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString

            End While
            dr.Close()
            cn.Close()

            btnSAVE.Enabled = True

        End If

    End Sub


End Class