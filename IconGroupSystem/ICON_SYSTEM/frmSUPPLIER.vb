Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class frmSUPPLIER

    Public Function Vowels(ByVal S As String) As String

        Dim X As Long
        For X = 1 To Len(S)
            If Mid(S, X, 1) Like "[!AEIOU]" Then Mid(S, X) = " "
        Next
        Vowels = Replace(S, " ", "")

    End Function


    Public Function Consonants(ByVal S As String) As String

        Dim X As Long
        For X = 1 To Len(S)
            If Mid(S, X, 1) Like "[AEIOU]" Then Mid(S, X) = " "
        Next
        Consonants = Replace(S, " ", "")

    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Try

            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()
                frmPRODUCT.LoadCategory()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try


    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        Try

            If txtSUPPLIERNAME.Text = String.Empty Or txtTRADENAME.Text = String.Empty Or txtBUSINESSNAME.Text = String.Empty Or txtCONTACTPERSON.Text = String.Empty Or txtCONTACTNO.Text = String.Empty Or txtTIN.Text = String.Empty Or txtVATREGISTRATION.Text = String.Empty Or txtEMAIL.Text = String.Empty Or txtPAYMENTTERMS_1.Text = String.Empty Or txtORIGIN.Text = String.Empty Then
                MsgBox("Please complete data!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If MsgBox("Save this Supplier ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("INSERT into tblsupplier (supplier_code, supplier_name, trade_name, address, contact_person, contact_no, tin, vat_registration, email_address, payment_terms_1, payment_terms_2, payment_terms_3, origin) values(@supplier_code, @supplier_name, @trade_name, @address, @contact_person, @contact_no, @tin, @vat_registration, @email_address, @payment_terms_1, @payment_terms_2, @payment_terms_3, @origin)", cn)
                With cm.Parameters
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
                MsgBox("Supplier has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

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


    Private Sub txtSUPPLIERNAME_TextChanged(sender As Object, e As EventArgs) Handles txtSUPPLIERNAME.TextChanged

        txtSUPPLIERCODE.Text = Consonants(txtSUPPLIERNAME.Text)

    End Sub

    Private Sub btnUPDATE_Click(sender As Object, e As EventArgs) Handles btnUPDATE.Click

        Try

            If txtSUPPLIERNAME.Text = String.Empty Or txtTRADENAME.Text = String.Empty Or txtBUSINESSNAME.Text = String.Empty Or txtCONTACTPERSON.Text = String.Empty Or txtCONTACTNO.Text = String.Empty Or txtTIN.Text = String.Empty Or txtVATREGISTRATION.Text = String.Empty Or txtEMAIL.Text = String.Empty Or txtPAYMENTTERMS_1.Text = String.Empty Or txtPAYMENTTERMS_2.Text = String.Empty Or txtPAYMENTTERMS_3.Text = String.Empty Or txtORIGIN.Text = String.Empty Then
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

            End If

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub txtPAYMENTTERMS_2_Leave(sender As Object, e As EventArgs) Handles txtPAYMENTTERMS_2.Leave

        If txtPAYMENTTERMS_1.Text = String.Empty Then

            MsgBox("Please input Data Above!", vbCritical + vbOKOnly, "CONFIRMATION")
            txtPAYMENTTERMS_2.Items.Clear()

            LoadPaymentTerms_2()

        ElseIf txtPAYMENTTERMS_2.Text = txtPAYMENTTERMS_1.Text Then

            MsgBox("Payment Terms already use!", vbCritical + vbOKOnly, "CONFIRMATION")
            txtPAYMENTTERMS_2.Items.Clear()

            LoadPaymentTerms_2()

        Else

            Exit Sub

        End If

    End Sub

    Private Sub txtPAYMENTTERMS_3_Leave(sender As Object, e As EventArgs) Handles txtPAYMENTTERMS_3.Leave

        If txtPAYMENTTERMS_1.Text = String.Empty Or txtPAYMENTTERMS_2.Text = String.Empty Then

            MsgBox("Please input Data Above!", vbCritical + vbOKOnly, "CONFIRMATION")
            txtPAYMENTTERMS_3.Items.Clear()

            LoadPaymentTerms_3()

        ElseIf txtPAYMENTTERMS_3.Text = txtPAYMENTTERMS_1.Text Or txtPAYMENTTERMS_3.Text = txtPAYMENTTERMS_2.Text Then

            MsgBox("Payment Terms already use!", vbCritical + vbOKOnly, "CONFIRMATION")
            txtPAYMENTTERMS_3.Items.Clear()

            LoadPaymentTerms_3()

        Else

            Exit Sub

        End If


    End Sub

    Private Sub txtPAYMENTTERMS_1_Leave(sender As Object, e As EventArgs) Handles txtPAYMENTTERMS_1.Leave

        If txtPAYMENTTERMS_2.Text = String.Empty Or txtPAYMENTTERMS_3.Text = String.Empty Then

            Exit Sub

        ElseIf txtPAYMENTTERMS_1.Text = txtPAYMENTTERMS_2.Text Or txtPAYMENTTERMS_1.Text = txtPAYMENTTERMS_3.Text Then

            MsgBox("Payment Terms already use!", vbCritical + vbOKOnly, "CONFIRMATION")
            txtPAYMENTTERMS_1.Items.Clear()

            LoadPaymentTerms_1()

        Else

            Exit Sub

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        frmPAYMENTTERMS.StartPosition = FormStartPosition.CenterParent
        frmPAYMENTTERMS.ShowDialog()

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        LoadPaymentTerms()

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
 

    Private Sub frmSUPPLIER_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

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