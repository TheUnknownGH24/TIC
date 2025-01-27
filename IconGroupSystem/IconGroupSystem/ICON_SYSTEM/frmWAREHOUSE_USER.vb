Public Class frmWAREHOUSE_USER

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        Try

            If txtEMPLOYEENAME.Text = String.Empty Or txtWAREHOUSE.Text = String.Empty Then
                MsgBox("Please input data!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If MsgBox("Save this Data ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("INSERT into tbl_warehouse_area (employee_name, position, shared, warehouse_name) values(@employee_name, @position, @shared, @warehouse_name)", cn)

                With cm.Parameters

                    .AddWithValue("@employee_name", txtEMPLOYEENAME.Text)
                    .AddWithValue("@position", txtPOSITION.Text)
                    .AddWithValue("@shared", txtSHARED.Text)
                    .AddWithValue("@warehouse_name", txtWAREHOUSE.Text)

                End With

                cm.ExecuteNonQuery()
                cn.Close()

                MsgBox("Data has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

                txtEMPLOYEENAME.Text = ""
                txtPOSITION.SelectedIndex = -1
                txtSHARED.SelectedIndex = -1

                SHOW_NAME()
                SHOW_WAREHOUSE()

            End If

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub frmUSER_FORM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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

    Sub SHOW_NAME()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_login", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("employee_name").ToString)

        End While
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

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_login where `employee_name` like '%" & txtSEARCHNAME.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("employee_name").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Dim colname As String = dataGridView1.Columns(e.ColumnIndex).Name

        If colname = "colUPDATE" Then

            txtEMPLOYEENAME.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString

        End If

    End Sub

End Class