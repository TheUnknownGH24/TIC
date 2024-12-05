Public Class frmSUPPLIER_FINANCE_LIST

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Sub LoadSupplierList()

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblsupplier_finance", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("supplier_name").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        With frmSUPPLIER_FINANCE
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Dim colname As String = dataGridView1.Columns(e.ColumnIndex).Name

        If colname = "colUPDATE" Then
            cn.Open()
            cm = New MySqlCommand("select * from tblsupplier_finance where id like '" & dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read
                txtID.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                txtSUPPLIERNAME.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
            End While
            dr.Close()
            cn.Close()
            btnUPDATE.Enabled = True

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        LoadSupplierList()
    End Sub

    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblsupplier_finance where supplier_name like '%" & txtSEARCHNAME.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("supplier_name").ToString)

        End While

        dr.Close()
        cn.Close()


    End Sub

    Private Sub btnUPDATE_Click(sender As Object, e As EventArgs) Handles btnUPDATE.Click

        Try

            If txtSUPPLIERNAME.Text = String.Empty Then
                MsgBox("Please input Supplier Name!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If MsgBox("Update this Supplier ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tblsupplier_finance set supplier_name=@supplier_name where id=@id", cn)
                With cm.Parameters
                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@supplier_name", txtSUPPLIERNAME.Text)

                End With
                cm.ExecuteNonQuery()
                cn.Close()

                MsgBox("Supplier has been Successfully Update!", vbInformation + vbOKOnly, "CONFIRMATION")

                txtID.Text = ""
                txtSUPPLIERNAME.Text = ""

                LoadSupplierList()

                btnUPDATE.Enabled = False

            End If

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try


    End Sub

End Class