Public Class frm8SI_CA_LIQUIDATION_SUPPLIER

    Sub LoadSupplierList()

        dataGridView1.Rows.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblsupplier_finance", cn)
        dr = cm.ExecuteReader
        While dr.Read

            dataGridView1.Rows.Add(dr.Item("id").ToString, dr.Item("supplier_name").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        frm8SI_CA_LIQUIDATION.txtSUPPLIER.Text = txtSEARCHNAME.Text
        Dispose()

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

    Private Sub txtSEARCHNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSEARCHNAME.TextChanged

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblsupplier_finance where supplier_name like '%" & txtSEARCHNAME.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(dr.Item("id").ToString, dr.Item("supplier_name").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If txtADDCATEGORY.Text = String.Empty Then

            MsgBox("Please Input Supplier", vbOKOnly + vbCritical, "CONFIRMATION")

        Else

            Try
                If MsgBox("Save this Supplier ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                    cn.Open()
                    cm = New MySqlCommand("INSERT into tblsupplier_finance (supplier_name) values(@supplier_name)", cn)
                    cm.Parameters.AddWithValue("@supplier_name", txtADDCATEGORY.Text)
                    cm.ExecuteNonQuery()
                    cn.Close()
                    MsgBox("Supplier has been Successfully Saved!", vbInformation)
                    txtADDCATEGORY.Clear()
                    txtADDCATEGORY.Focus()
                    LoadSupplierList()
                End If

            Catch ex As Exception
                cn.Close()
                MsgBox(ex.Message, vbCritical)
            End Try

        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        dataGridView1.Rows.Clear()
        Dim i As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tblsupplier_finance where supplier_name like '%" & TextBox1.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(dr.Item("id").ToString, dr.Item("supplier_name").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub dataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles dataGridView1.DoubleClick

        txtID.Text = dataGridView1.CurrentRow.Cells(0).Value
        txtSEARCHNAME.Text = dataGridView1.CurrentRow.Cells(1).Value

    End Sub

    Private Sub frm8SI_CA_LIQUIDATION_SUPPLIER_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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