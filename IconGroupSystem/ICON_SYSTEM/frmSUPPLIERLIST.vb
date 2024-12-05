Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmSUPPLIERLIST

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
        cm = New MySqlCommand("select * from tblsupplier", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("supplier_code").ToString, dr.Item("supplier_name").ToString, dr.Item("trade_name").ToString, dr.Item("address").ToString, dr.Item("contact_person"), dr.Item("contact_no").ToString, dr.Item("tin").ToString, dr.Item("vat_registration").ToString, dr.Item("email_address").ToString, dr.Item("payment_terms_1").ToString, dr.Item("payment_terms_2").ToString, dr.Item("payment_terms_3").ToString, dr.Item("origin").ToString)

        End While
        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        With frmSUPPLIER
            .StartPosition = FormStartPosition.CenterScreen
            .btnUPDATE.Enabled = False
            .btnUPDATE.Visible = False
            .ShowDialog()
        End With

    End Sub

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

        Dim colname As String = dataGridView1.Columns(e.ColumnIndex).Name

        LoadPaymentTerms()

        If colname = "colUPDATE" Then
            cn.Open()
            cm = New MySqlCommand("select * from tblsupplier where id like '" & dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
            dr = cm.ExecuteReader
            While dr.Read
                txtID.Text = dataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString
                txtSUPPLIERCODE.Text = dataGridView1.Rows(e.RowIndex).Cells(2).Value.ToString
                txtSUPPLIERNAME.Text = dataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString
                txtTRADENAME.Text = dataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
                txtBUSINESSNAME.Text = dataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
                txtCONTACTPERSON.Text = dataGridView1.Rows(e.RowIndex).Cells(6).Value.ToString
                txtCONTACTNO.Text = dataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
                txtTIN.Text = dataGridView1.Rows(e.RowIndex).Cells(8).Value.ToString
                txtVATREGISTRATION.Text = dataGridView1.Rows(e.RowIndex).Cells(9).Value.ToString
                txtEMAIL.Text = dataGridView1.Rows(e.RowIndex).Cells(10).Value.ToString
                txtPAYMENTTERMS_1.Text = dataGridView1.Rows(e.RowIndex).Cells(11).Value.ToString
                txtPAYMENTTERMS_2.Text = dataGridView1.Rows(e.RowIndex).Cells(12).Value.ToString
                txtPAYMENTTERMS_3.Text = dataGridView1.Rows(e.RowIndex).Cells(13).Value.ToString
                txtORIGIN.Text = dataGridView1.Rows(e.RowIndex).Cells(14).Value.ToString
            End While
            dr.Close()
            cn.Close()
            btnUPDATE.Enabled = True
            'LoadPaymentTerms()
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
        cm = New MySqlCommand("select * from tblsupplier where supplier_name like '%" & txtSEARCHNAME.Text & "%' or address like '%" & txtSEARCHNAME.Text & "%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dataGridView1.Rows.Add(i, dr.Item("id").ToString, dr.Item("supplier_code").ToString, dr.Item("supplier_name").ToString, dr.Item("trade_name").ToString, dr.Item("address").ToString, dr.Item("contact_person"), dr.Item("contact_no").ToString, dr.Item("tin").ToString, dr.Item("vat_registration").ToString, dr.Item("email_address").ToString, dr.Item("payment_terms_1").ToString, dr.Item("payment_terms_2").ToString, dr.Item("payment_terms_3").ToString, dr.Item("origin").ToString)

        End While

        dr.Close()
        cn.Close()


    End Sub

    Private Sub btnUPDATE_Click(sender As Object, e As EventArgs) Handles btnUPDATE.Click

        Try

            If txtSUPPLIERNAME.Text = String.Empty Or txtTRADENAME.Text = String.Empty Or txtBUSINESSNAME.Text = String.Empty Or txtCONTACTPERSON.Text = String.Empty Or txtCONTACTNO.Text = String.Empty Or txtTIN.Text = String.Empty Or txtVATREGISTRATION.Text = String.Empty Or txtEMAIL.Text = String.Empty Or txtPAYMENTTERMS_1.Text = String.Empty Or txtORIGIN.Text = String.Empty Then
                MsgBox("Please complete data!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If MsgBox("Update this Supplier ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tblsupplier set supplier_code=@supplier_code, supplier_name=@supplier_name, trade_name=@trade_name, address=@address, contact_person=@contact_person, contact_no=@contact_no, tin=@tin, vat_registration=@vat_registration, email_address=@email_address, payment_terms_1=@payment_terms_1, payment_terms_2=@payment_terms_2, payment_terms_3=@payment_terms_3, origin=@origin where id=@id", cn)
                With cm.Parameters
                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@supplier_code", txtSUPPLIERCODE.Text)
                    .AddWithValue("@supplier_name", txtSUPPLIERNAME.Text)
                    .AddWithValue("@trade_name", txtTRADENAME.Text)
                    .AddWithValue("@address", txtBUSINESSNAME.Text)
                    .AddWithValue("@contact_person", txtCONTACTPERSON.Text)
                    .AddWithValue("@contact_no", txtCONTACTNO.Text)
                    .AddWithValue("@tin", txtTIN.Text)
                    .AddWithValue("@vat_registration", txtVATREGISTRATION.Text)
                    .AddWithValue("@email_address", txtEMAIL.Text)
                    .AddWithValue("@payment_terms_1", txtPAYMENTTERMS_1.Text)
                    .AddWithValue("@payment_terms_2", txtPAYMENTTERMS_2.Text)
                    .AddWithValue("@payment_terms_3", txtPAYMENTTERMS_3.Text)
                    .AddWithValue("@origin", txtORIGIN.Text)
                End With
                cm.ExecuteNonQuery()
                cn.Close()

                MsgBox("Supplier has been Successfully Update!", vbInformation + vbOKOnly, "CONFIRMATION")

                txtSUPPLIERCODE.Text = ""
                txtSUPPLIERNAME.Text = ""
                txtTRADENAME.Text = ""
                txtBUSINESSNAME.Text = ""
                txtCONTACTPERSON.Text = ""
                txtCONTACTNO.Text = ""
                txtTIN.Text = ""
                txtVATREGISTRATION.Text = ""
                txtEMAIL.Text = ""
                txtORIGIN.Text = ""

                txtPAYMENTTERMS_1.Items.Clear()
                txtPAYMENTTERMS_2.Items.Clear()
                txtPAYMENTTERMS_3.Items.Clear()

                LoadPaymentTerms()

                LoadSupplierList()

                btnUPDATE.Enabled = False

            End If

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try


    End Sub

    Sub LoadPaymentTerms()

        txtPAYMENTTERMS_1.Items.Clear()
        txtPAYMENTTERMS_2.Items.Clear()
        txtPAYMENTTERMS_3.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblpayment_terms", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtPAYMENTTERMS_1.Items.Add(dr.Item("payment_terms").ToString)
            txtPAYMENTTERMS_2.Items.Add(dr.Item("payment_terms").ToString)
            txtPAYMENTTERMS_3.Items.Add(dr.Item("payment_terms").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub LoadPaymentTerms_1()

        txtPAYMENTTERMS_1.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblpayment_terms", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtPAYMENTTERMS_1.Items.Add(dr.Item("payment_terms").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub LoadPaymentTerms_2()

        txtPAYMENTTERMS_2.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblpayment_terms", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtPAYMENTTERMS_2.Items.Add(dr.Item("payment_terms").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub LoadPaymentTerms_3()

        txtPAYMENTTERMS_3.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblpayment_terms", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtPAYMENTTERMS_3.Items.Add(dr.Item("payment_terms").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        LoadPaymentTerms()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        frmPAYMENTTERMS.StartPosition = FormStartPosition.CenterParent
        frmPAYMENTTERMS.ShowDialog()

    End Sub

    Private Sub frmSUPPLIERLIST_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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