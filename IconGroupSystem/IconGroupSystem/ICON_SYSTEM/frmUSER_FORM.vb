Imports MySql.Data.MySqlClient

Public Class frmUSER_FORM

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

    Private Sub txtDERPARTMENT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtDERPARTMENT.SelectedIndexChanged

        If txtDERPARTMENT.Text = "CLINIC ADMIN" Then

            txtDEPCODE.Text = "CLNC"

        ElseIf txtDERPARTMENT.Text = "EXECUTIVE DEPARTMENT" Then

            txtDEPCODE.Text = "EXECOM"

        ElseIf txtDERPARTMENT.Text = "ECOMMERCE - SALES DEPARTMENT" Then

            txtDEPCODE.Text = "ECOM"

        ElseIf txtDERPARTMENT.Text = "EXPORT - SALES DEPARTMENT" Then

            txtDEPCODE.Text = "EXP"

        ElseIf txtDERPARTMENT.Text = "FINANCE DEPARTMENT" Then

            txtDEPCODE.Text = "FIN"

        ElseIf txtDERPARTMENT.Text = "HR DEPARTMENT" Then

            txtDEPCODE.Text = "HRD"

        ElseIf txtDERPARTMENT.Text = "ICON CARE GROUP" Then

            txtDEPCODE.Text = "ICG"

        ElseIf txtDERPARTMENT.Text = "ICON DERMA TEAM (DERMA)" Then

            txtDEPCODE.Text = "IDT"

        ElseIf txtDERPARTMENT.Text = "ICON SURGERY TEAM (OR)" Then

            txtDEPCODE.Text = "IST"

        ElseIf txtDERPARTMENT.Text = "IT DEPARTMENT" Then

            txtDEPCODE.Text = "IT"

        ElseIf txtDERPARTMENT.Text = "LOGISTICS DEPARTMENT" Then

            txtDEPCODE.Text = "LGS"

        ElseIf txtDERPARTMENT.Text = "MARKETING DEPARTMENT" Then

            txtDEPCODE.Text = "MKTG"

        ElseIf txtDERPARTMENT.Text = "PRODUCTION DEPARTMENT" Then

            txtDEPCODE.Text = "PRD"

        ElseIf txtDERPARTMENT.Text = "PURCHASING DEPARTMENT" Then

            txtDEPCODE.Text = "PRH"

        ElseIf txtDERPARTMENT.Text = "RESEARCH AND DEVELOPMENT" Then

            txtDEPCODE.Text = "RND"

        ElseIf txtDERPARTMENT.Text = "RETAIL - SALES DEPARTMENT" Then

            txtDEPCODE.Text = "RTL"

        ElseIf txtDERPARTMENT.Text = "WAREHOUSE DEPARTMENT" Then

            txtDEPCODE.Text = "WRH"

        ElseIf txtDERPARTMENT.Text = "DIRECT SELLING - OPERATIONS" Or txtDERPARTMENT.Text = "DIRECT SELLING - OPERATIONS - (CENTRAL AND NORTH LUZON)" Or txtDERPARTMENT.Text = "DIRECT SELLING - OPERATIONS - (NCR AND SOUTH LUZON)" Or txtDERPARTMENT.Text = "DIRECT SELLING - OPERATIONS - (MINDANAO)" Or txtDERPARTMENT.Text = "DIRECT SELLING - OPERATIONS - (VISAYAS)" Then

            txtDEPCODE.Text = "DRS"

        ElseIf txtDERPARTMENT.Text = "DIRECT SELLING - BUSINESS DEV" Then

            txtDEPCODE.Text = "DRS"

        ElseIf txtDERPARTMENT.Text = "" Then

            txtDEPCODE.Text = ""


        End If



    End Sub

    Private Sub txtDOMAIN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtDOMAIN.SelectedIndexChanged

        If txtDOMAIN.Text = "THE ICON CLINIC - SURGERY" Or txtDOMAIN.Text = "THE ICON CLINIC - DERMA" Then

            txtDERPARTMENT.Items.Clear()

            txtDERPARTMENT.Items.Add("EXECUTIVE DEPARTMENT")
            txtDERPARTMENT.Items.Add("HR DEPARTMENT")
            txtDERPARTMENT.Items.Add("FINANCE DEPARTMENT")
            txtDERPARTMENT.Items.Add("IT DEPARTMENT")
            txtDERPARTMENT.Items.Add("ICON CARE GROUP")
            txtDERPARTMENT.Items.Add("CLINIC ADMIN")
            txtDERPARTMENT.Items.Add("ICON SURGERY TEAM (OR)")
            txtDERPARTMENT.Items.Add("ICON DERMA TEAM (DERMA)")
            txtDERPARTMENT.Items.Add("MARKETING DEPARTMENT")
            txtDERPARTMENT.Items.Add("PURCHASING DEPARTMENT")
            txtDERPARTMENT.Items.Add("WAREHOUSE DEPARTMENT")

        Else

            'txtDERPARTMENT.Items.Clear()

            'txtDERPARTMENT.Items.Add("EXECUTIVE DEPARTMENT")
            'txtDERPARTMENT.Items.Add("HR DEPARTMENT")
            'txtDERPARTMENT.Items.Add("FINANCE DEPARTMENT")
            'txtDERPARTMENT.Items.Add("IT DEPARTMENT")
            'txtDERPARTMENT.Items.Add("RESEARCH AND DEVELOPMENT")
            'txtDERPARTMENT.Items.Add("MARKETING DEPARTMENT")
            'txtDERPARTMENT.Items.Add("PRODUCTION DEPARTMENT")
            'txtDERPARTMENT.Items.Add("WAREHOUSE DEPARTMENT")
            'txtDERPARTMENT.Items.Add("LOGISTICS DEPARTMENT")
            'txtDERPARTMENT.Items.Add("PURCHASING DEPARTMENT")
            'txtDERPARTMENT.Items.Add("RETAIL - SALES DEPARTMENT")
            'txtDERPARTMENT.Items.Add("ECOMMERCE - SALES DEPARTMENT")
            'txtDERPARTMENT.Items.Add("EXPORT - SALES DEPARTMENT")
            'txtDERPARTMENT.Items.Add("DIRECT SELLING - OPERATIONS")
            'txtDERPARTMENT.Items.Add("DIRECT SELLING - BUSINESS DEV")

            LoadDepartmentList()

        End If

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        Try

            If txtEMPLOYEECODE.Text = String.Empty Or txtEMPLOYEENAME.Text = String.Empty Or txtDOMAIN.Text = String.Empty Or txtDERPARTMENT.Text = String.Empty Or txtPOSITION.Text = String.Empty Or txtPASSWORD.Text = String.Empty Then
                MsgBox("Please input data!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If MsgBox("Save this Data ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("INSERT into tbl_login (employee_code, employee_name, domain, department, department_code, position, password, type, classification) values(@employee_code, @employee_name, @domain, @department, @department_code, @position, @password, @type, @classification)", cn)

                With cm.Parameters

                    .AddWithValue("@employee_code", txtEMPLOYEECODE.Text)
                    .AddWithValue("@employee_name", txtEMPLOYEENAME.Text)
                    .AddWithValue("@domain", txtDOMAIN.Text)
                    .AddWithValue("@department", txtDERPARTMENT.Text)
                    .AddWithValue("@department_code", txtDEPCODE.Text)
                    .AddWithValue("@position", txtPOSITION.Text)
                    .AddWithValue("@password", txtPASSWORD.Text)
                    .AddWithValue("@type", txtTYPE.Text)
                    .AddWithValue("@classification", txtCLASS.Text)

                End With

                cm.ExecuteNonQuery()
                cn.Close()

                MsgBox("Account has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

                txtEMPLOYEECODE.Text = ""
                txtEMPLOYEENAME.Text = ""
                txtDOMAIN.Text = ""
                txtDERPARTMENT.Items.Clear()
                txtDEPCODE.Text = ""
                txtPOSITION.Text = ""
                txtPASSWORD.Text = ""
                txtTYPE.Text = ""
                txtCLASS.Text = ""

            End If

        Catch ex As Exception
            cn.Close()
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub

    Private Sub btnUPDATE_Click(sender As Object, e As EventArgs) Handles btnUPDATE.Click

        Try

            If txtEMPLOYEECODE.Text = String.Empty Or txtEMPLOYEENAME.Text = String.Empty Or txtDOMAIN.Text = String.Empty Or txtDERPARTMENT.Text = String.Empty Or txtPOSITION.Text = String.Empty Or txtPASSWORD.Text = String.Empty Then
                MsgBox("Please input data!", vbCritical + vbOKOnly, "CONFIRMATION")
                Return
            End If

            If MsgBox("Save this Data ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                cn.Open()
                cm = New MySqlCommand("Update tbl_login set employee_code=@employee_code, employee_name=@employee_name, domain=@domain, department=@department, department_code=@department_code, position=@position, password=@password, type=@type, classification=@classification where id=@id", cn)

                With cm.Parameters

                    .AddWithValue("@id", txtID.Text)
                    .AddWithValue("@employee_code", txtEMPLOYEECODE.Text)
                    .AddWithValue("@employee_name", txtEMPLOYEENAME.Text)
                    .AddWithValue("@domain", txtDOMAIN.Text)
                    .AddWithValue("@department", txtDERPARTMENT.Text)
                    .AddWithValue("@department_code", txtDEPCODE.Text)
                    .AddWithValue("@position", txtPOSITION.Text)
                    .AddWithValue("@password", txtPASSWORD.Text)
                    .AddWithValue("@type", txtTYPE.Text)
                    .AddWithValue("@classification", txtCLASS.Text)

                End With

                cm.ExecuteNonQuery()
                cn.Close()

                MsgBox("Account has been Successfully Saved!", vbInformation + vbOKOnly, "CONFIRMATION")

                txtID.Text = ""
                txtEMPLOYEECODE.Text = ""
                txtEMPLOYEENAME.Text = ""
                txtDOMAIN.Text = ""
                txtDERPARTMENT.Text = ""
                txtDEPCODE.Text = ""
                txtPOSITION.Text = ""
                txtPASSWORD.Text = ""
                txtTYPE.Text = ""
                txtCLASS.Text = ""

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

    Sub LoadDepartmentList()

        txtDERPARTMENT.Items.Clear()

        cn.Open()
        cm = New MySqlCommand("select * from tblareasalesmanager", cn)
        dr = cm.ExecuteReader
        While dr.Read

            txtDERPARTMENT.Items.Add(dr.Item("Department").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub



End Class