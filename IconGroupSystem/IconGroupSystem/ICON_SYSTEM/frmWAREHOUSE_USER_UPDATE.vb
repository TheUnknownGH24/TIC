Public Class frmWAREHOUSE_USER_UPDATE

    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_area where employee_name like '%" & txtSEARCHNAME.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("employee_name").ToString, dr.Item("position").ToString, dr.Item("shared").ToString, dr.Item("warehouse_name").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub LoadUSERList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse_area", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("employee_name").ToString, dr.Item("position").ToString, dr.Item("shared").ToString, dr.Item("warehouse_name").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Sub SHOW_NAME()

        cn.Open()
        cm = New MySqlCommand("select `employee_name` from tbl_login", cn)
        dr = cm.ExecuteReader
        Dim mydata As AutoCompleteStringCollection = New AutoCompleteStringCollection()
        While dr.Read

            mydata.Add(dr.GetString(0))

        End While

        txtEMPLOYEENAME.AutoCompleteCustomSource = mydata

        dr.Close()
        cn.Close()

    End Sub

    Sub SHOW_WAREHOUSE()

        txtWAREHOUSE.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tbl_warehouse", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtWAREHOUSE.Items.Add(dr.Item("warehouse_name").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Dim colname As String = dataGridView1.Columns(e.ColumnIndex).Name

        SHOW_NAME()
        SHOW_WAREHOUSE()

        If colname = "colUPDATE" Then
            cn.Open()
            cm = New MySqlCommand("select * from tbl_warehouse_area where id like '" & dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read

                txtID.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                txtEMPLOYEENAME.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                txtPOSITION.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                txtSHARED.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                txtWAREHOUSE.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString

            End While
            dr.Close()
            cn.Close()

            btnUPDATE.Enabled = True

        End If

    End Sub

    Private Sub btnUPDATE_Click(sender As Object, e As EventArgs) Handles btnUPDATE.Click

        Try

            If txtEMPLOYEENAME.Text = String.Empty Then
                MsgBox("Please input Employee Name!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If txtPOSITION.Text = String.Empty Then
                MsgBox("Please select position from list!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If txtSHARED.Text = String.Empty Then
                MsgBox("Please select domain from list!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If txtWAREHOUSE.Text = String.Empty Then
                MsgBox("Please select location from list!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If MsgBox("Update this Item ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_warehouse_area set employee_name=@employee_name, position=@position, shared=@shared, warehouse_name=@warehouse_name where id=@id", cn)
                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@employee_name", txtEMPLOYEENAME.Text)
                    .AddWithValue("@position", txtPOSITION.Text)
                    .AddWithValue("@shared", txtSHARED.Text)
                    .AddWithValue("@warehouse_name", txtWAREHOUSE.Text)

                End With
                cm.ExecuteNonQuery()
                cn.Close()
                MsgBox("Data has been Successfully Update!", vbInformation + vbOKOnly, "CONFIRMATION")

                txtID.Text = ""
                txtEMPLOYEENAME.Text = ""
                txtPOSITION.SelectedIndex = -1
                txtSHARED.SelectedIndex = -1

                SHOW_NAME()
                SHOW_WAREHOUSE()
                LoadUSERList()

                btnUPDATE.Enabled = False

            End If

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub frmWAREHOUSE_USER_UPDATE_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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