Imports MySql.Data.MySqlClient
Imports OfficeOpenXml
Imports System.Data
Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frm2EXTRACTION

    Private Sub txtSELECTDATABASE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtSELECTDATABASE.SelectedIndexChanged


        If txtSELECTDATABASE.Text = String.Empty Or txtDOMAIN.Text = "String.Empty" Or txtSELECTDATABASE.Text = "" Or txtDOMAIN.Text = "" Then

            txtDATABASE.Text = ""
            txtDATABASELIST.Text = ""
            txtCODE.Text = ""

        ElseIf txtSELECTDATABASE.Text = "CASH_ADVANCE" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_cashadvance"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "CASH_ADVANCE_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_cashadvancelist"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "CA_LIQUIDATION" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_cashadvance_liquidation"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "CA_LIQUIDATION_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_cashadvance_liquidationlist"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "CHECK_VOUCHER" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_checkvoucher"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "CHECK_VOUCHER_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_checkvoucher_accounttitle"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PAYMENT_REQUEST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_paymentrequest"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PURCHASED_ORDER" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_purchasedorder"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PURCHASED_ORDER_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_purchasedorderlist"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "REIMBURSEMENT" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_reimbursement"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "REIMBURSEMENT_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_reimbursement_list"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "RF_REPLENISHMENT" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_rf_replenishment"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "RF_REPLENISHMENT_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_rf_replenishment_list"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PCV_REIMBURSEMENT" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_pcv_reimbursement"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PCV_REIMBURSEMENT_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_pcv_reimbursement_list"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PETTY_CASH" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_pettycash"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PETTY_CASH_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_pettycashlist"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PETTY_CASH_LIQUIDATION" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_pettycash_liquidation"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PETTY_CASH_LIQUIDATION_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_pettycash_liquidationlist"
            txtCODE.Text = "tic"

            '===================================================================================================================

        ElseIf txtSELECTDATABASE.Text = "CASH_ADVANCE" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_cashadvance"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "CASH_ADVANCE_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_cashadvancelist"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "CA_LIQUIDATION" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_cashadvance_liquidation"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "CA_LIQUIDATION_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_cashadvance_liquidationlist"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "CHECK_VOUCHER" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_checkvoucher"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "CHECK_VOUCHER_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_checkvoucher_accounttitle"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PAYMENT_REQUEST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_paymentrequest"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PURCHASED_ORDER" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_purchasedorder"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PURCHASED_ORDER_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_purchasedorderlist"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "REIMBURSEMENT" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_reimbursement"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "REIMBURSEMENT_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_reimbursement_list"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "RF_REPLENISHMENT" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_rf_replenishment"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "RF_REPLENISHMENT_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_rf_replenishment_list"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PCV_REIMBURSEMENT" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_pcv_reimbursement"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PCV_REIMBURSEMENT_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_pcv_reimbursement_list"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PETTY_CASH" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_pettycash"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PETTY_CASH_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_pettycashlist"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PETTY_CASH_LIQUIDATION" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_pettycash_liquidation"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PETTY_CASH_LIQUIDATION_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_pettycash_liquidationlist"
            txtCODE.Text = "8si"

        End If

    End Sub

    Private Sub frm2EXTRACTION_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            If MsgBox("Do you want to Exit ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Me.Dispose()

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Sub EXTRACT_DATABASE()

        ' Database connection details
        'Dim connectionString As String = "server=localhost;user id=root;password=;database=u135454512_finance"
        Dim connectionString As String = "server=db4free.net; user id=ryanicongroup; password=sample1+1; database=db_icongroup; pooling=true; SslMode=none; old guids=true"

        Dim saveLocation As String
        Dim RunDate

        RunDate = txtCODE.Text & "_" & txtSELECTDATABASE.Text & "_" & Now.ToString("yyyy-MM-dd")

        saveLocation = txtPATH.Text & "\"

        Dim query As String = "SELECT * FROM `" & txtDATABASE.Text & "`"

        ' Table and Excel file details
        Dim tableName As String = txtDATABASE.Text
        Dim excelFilePath As String = saveLocation & RunDate & ".xlsx"

        ' Establish database connection
        Using connection As MySqlConnection = New MySqlConnection(connectionString)
            connection.Open()

            ' Create a command to execute the querys
            Using command As MySqlCommand = New MySqlCommand(query, connection)
                ' Execute the query and retrieve the data
                Using reader As MySqlDataReader = command.ExecuteReader()
                    ' Create a new Excel package
                    Using package As ExcelPackage = New ExcelPackage()
                        ' Add a worksheet to the Excel package
                        Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add(txtDATABASE.Text)

                        ' Write column headers to the first row
                        For i As Integer = 0 To reader.FieldCount - 1
                            worksheet.Cells(1, i + 1).Value = reader.GetName(i)
                        Next

                        ' Write data to the worksheet
                        Dim row As Integer = 2
                        While reader.Read()
                            For i As Integer = 0 To reader.FieldCount - 1
                                worksheet.Cells(row, i + 1).Value = reader(i).ToString()
                            Next
                            row += 1
                        End While

                        ' Save the Excel package to a file
                        package.SaveAs(New IO.FileInfo(excelFilePath))
                    End Using
                End Using
            End Using
        End Using

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If txtDATABASE.Text = String.Empty Then

            MsgBox("Please Select Database!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        If txtPATH.Text = String.Empty Then

            MsgBox("Please Select Path File!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

        EXTRACT_DATABASE()

        MsgBox("Successfully Extract!", vbInformation + vbOKOnly, "CONFIRMATION")

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim folderBrowserDialog As New FolderBrowserDialog()

        ' Set the initial folder (optional)
        ' folderBrowserDialog.SelectedPath = "C:\Your\Initial\Folder"

        ' Show the dialog and get the result
        Dim result As DialogResult = folderBrowserDialog.ShowDialog()

        ' Check if the user selected a folder
        If result = DialogResult.OK Then
            ' Display the selected folder path

            txtPATH.Text = folderBrowserDialog.SelectedPath

        End If

    End Sub

    Private Sub txtDOMAIN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtDOMAIN.SelectedIndexChanged

        If txtSELECTDATABASE.Text = String.Empty Or txtDOMAIN.Text = "String.Empty" Or txtSELECTDATABASE.Text = "" Or txtDOMAIN.Text = "" Then

            txtDATABASE.Text = ""
            txtDATABASELIST.Text = ""
            txtCODE.Text = ""

        ElseIf txtSELECTDATABASE.Text = "CASH_ADVANCE" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_cashadvance"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "CASH_ADVANCE_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_cashadvancelist"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "CA_LIQUIDATION" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_cashadvance_liquidation"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "CA_LIQUIDATION_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_cashadvance_liquidationlist"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "CHECK_VOUCHER" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_checkvoucher"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "CHECK_VOUCHER_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_checkvoucher_accounttitle"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PAYMENT_REQUEST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_paymentrequest"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PURCHASED_ORDER" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_purchasedorder"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PURCHASED_ORDER_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_purchasedorderlist"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "REIMBURSEMENT" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_reimbursement"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "REIMBURSEMENT_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_reimbursement_list"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "RF_REPLENISHMENT" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_rf_replenishment"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "RF_REPLENISHMENT_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_rf_replenishment_list"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PCV_REIMBURSEMENT" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_pcv_reimbursement"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PCV_REIMBURSEMENT_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_pcv_reimbursement_list"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PETTY_CASH" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_pettycash"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PETTY_CASH_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_pettycashlist"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PETTY_CASH_LIQUIDATION" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_pettycash_liquidation"
            txtCODE.Text = "tic"

        ElseIf txtSELECTDATABASE.Text = "PETTY_CASH_LIQUIDATION_LIST" And txtDOMAIN.Text = "THE_ICON_CLINIC" Then

            txtDATABASE.Text = "tbl_tic_pettycash_liquidationlist"
            txtCODE.Text = "tic"

            '===================================================================================================================

        ElseIf txtSELECTDATABASE.Text = "CASH_ADVANCE" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_cashadvance"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "CASH_ADVANCE_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_cashadvancelist"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "CA_LIQUIDATION" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_cashadvance_liquidation"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "CA_LIQUIDATION_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_cashadvance_liquidationlist"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "CHECK_VOUCHER" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_checkvoucher"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "CHECK_VOUCHER_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_checkvoucher_accounttitle"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PAYMENT_REQUEST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_paymentrequest"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PURCHASED_ORDER" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_purchasedorder"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PURCHASED_ORDER_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_purchasedorderlist"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "REIMBURSEMENT" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_reimbursement"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "REIMBURSEMENT_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_reimbursement_list"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "RF_REPLENISHMENT" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_rf_replenishment"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "RF_REPLENISHMENT_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_rf_replenishment_list"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PCV_REIMBURSEMENT" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_pcv_reimbursement"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PCV_REIMBURSEMENT_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_pcv_reimbursement_list"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PETTY_CASH" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_pettycash"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PETTY_CASH_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_pettycashlist"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PETTY_CASH_LIQUIDATION" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_pettycash_liquidation"
            txtCODE.Text = "8si"

        ElseIf txtSELECTDATABASE.Text = "PETTY_CASH_LIQUIDATION_LIST" And txtDOMAIN.Text = "8SONAKA_INC" Then

            txtDATABASE.Text = "tbl_8si_pettycash_liquidationlist"
            txtCODE.Text = "8si"

        End If

    End Sub

    Private Sub txtALLDOMAIN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtALLDOMAIN.SelectedIndexChanged


        If txtALLDOMAIN.Text = "8SONAKA_INC" Then

            ALL_SONAKA()

        ElseIf txtALLDOMAIN.Text = "THE_ICON_CLINIC" Then

            ALL_ICON()

        ElseIf txtALLDOMAIN.Text = "" Or txtALLDOMAIN.Text = String.Empty Then

            DataGridView1.Rows.Clear()
            DataGridView2.Rows.Clear()
            DataGridView3.Rows.Clear()
            DataGridView4.Rows.Clear()
            DataGridView5.Rows.Clear()
            DataGridView6.Rows.Clear()

        End If

    End Sub

    Sub ALL_SONAKA()

        'CASH ADVANCE

        DataGridView1.Rows.Clear()
        Dim a As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_cashadvance", cn)
        dr = cm.ExecuteReader

        While dr.Read
            a += 1
            DataGridView1.Rows.Add(a, dr.Item("id").ToString, dr.Item("ca_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("purpose").ToString, dr.Item("total_amount").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString, dr.Item("endorsed_approval").ToString, dr.Item("finance_approval").ToString, dr.Item("final_approval").ToString)

        End While

        dr.Close()
        cn.Close()


        'CA_LIQUIDATION            

        DataGridView2.Rows.Clear()
        Dim b As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_cashadvance_liquidation", cn)
        dr = cm.ExecuteReader

        While dr.Read
            b += 1
            DataGridView2.Rows.Add(b, dr.Item("id").ToString, dr.Item("cano_liquidation").ToString, dr.Item("ca_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("total_caamount").ToString, dr.Item("total_liquidation").ToString, dr.Item("total_balance").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString, dr.Item("endorsed_approval").ToString, dr.Item("finance_approval").ToString, dr.Item("final_approval").ToString)

        End While

        dr.Close()
        cn.Close()


        'CHECK VOUCHER

        DataGridView3.Rows.Clear()
        Dim c As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_checkvoucher", cn)
        dr = cm.ExecuteReader

        While dr.Read
            c += 1
            DataGridView3.Rows.Add(c, dr.Item("id").ToString, dr.Item("cv_no").ToString, dr.Item("reference").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("supplier_name").ToString, dr.Item("payee_name").ToString, dr.Item("reference_code").ToString, dr.Item("subreference_code").ToString, dr.Item("checkvoucher_date").ToString, dr.Item("check_no").ToString, dr.Item("bank_branch").ToString, dr.Item("check_date").ToString, dr.Item("particulars").ToString, dr.Item("amount_due").ToString, dr.Item("debit_total").ToString, dr.Item("credit_total").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString, dr.Item("coo_comment").ToString, dr.Item("status").ToString, dr.Item("manager_approval").ToString, dr.Item("gm_approval").ToString, dr.Item("coo_approval").ToString)

        End While

        dr.Close()
        cn.Close()

        'PAYMENT REQUEST

        DataGridView4.Rows.Clear()
        Dim d As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_paymentrequest", cn)
        dr = cm.ExecuteReader

        While dr.Read
            d += 1
            DataGridView4.Rows.Add(d, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("type_payment").ToString, dr.Item("date_needed").ToString, dr.Item("mode_payment").ToString, dr.Item("date").ToString, dr.Item("mode_release").ToString, dr.Item("supplier_name").ToString, dr.Item("account_name").ToString, dr.Item("account_no").ToString, dr.Item("bank_name").ToString, dr.Item("amount").ToString, dr.Item("amount_words").ToString, dr.Item("payment_remarks").ToString, dr.Item("reference_code").ToString, dr.Item("sub_referencecode").ToString, dr.Item("manager_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("gm_comment").ToString, dr.Item("coo_comment").ToString, dr.Item("status").ToString, dr.Item("manager_approval").ToString, dr.Item("finance_approval").ToString, dr.Item("gm_approval").ToString, dr.Item("coo_approval").ToString)

        End While

        dr.Close()
        cn.Close()


        'REIMBURSEMENT

        DataGridView5.Rows.Clear()
        Dim e As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_reimbursement", cn)
        dr = cm.ExecuteReader

        While dr.Read
            e += 1
            DataGridView5.Rows.Add(e, dr.Item("id").ToString, dr.Item("reimbursementno").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("total_liquidation").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString, dr.Item("endorsed_approval").ToString, dr.Item("finance_approval").ToString, dr.Item("final_approval").ToString)

        End While

        dr.Close()
        cn.Close()


        'RF

        DataGridView6.Rows.Clear()
        Dim f As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_8si_rf_replenishment", cn)
        dr = cm.ExecuteReader

        While dr.Read
            f += 1
            DataGridView6.Rows.Add(f, dr.Item("id").ToString, dr.Item("rf_no").ToString, dr.Item("reference").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("revolving_fund").ToString, dr.Item("total_liquidation").ToString, dr.Item("unreplenish").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString, dr.Item("endorsed_approval").ToString, dr.Item("finance_approval").ToString, dr.Item("final_approval").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

    Sub ALL_ICON()

        'CASH ADVANCE

        DataGridView1.Rows.Clear()
        Dim a As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_cashadvance", cn)
        dr = cm.ExecuteReader

        While dr.Read
            a += 1
            DataGridView1.Rows.Add(a, dr.Item("id").ToString, dr.Item("ca_no").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("date_needed").ToString, dr.Item("purpose").ToString, dr.Item("total_amount").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString, dr.Item("endorsed_approval").ToString, dr.Item("finance_approval").ToString, dr.Item("final_approval").ToString)

        End While

        dr.Close()
        cn.Close()


        'CA_LIQUIDATION            

        DataGridView2.Rows.Clear()
        Dim b As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_cashadvance_liquidation", cn)
        dr = cm.ExecuteReader

        While dr.Read
            b += 1
            DataGridView2.Rows.Add(b, dr.Item("id").ToString, dr.Item("cano_liquidation").ToString, dr.Item("ca_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("total_caamount").ToString, dr.Item("total_liquidation").ToString, dr.Item("total_balance").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString, dr.Item("endorsed_approval").ToString, dr.Item("finance_approval").ToString, dr.Item("final_approval").ToString)

        End While

        dr.Close()
        cn.Close()


        'CHECK VOUCHER

        DataGridView3.Rows.Clear()
        Dim c As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_checkvoucher", cn)
        dr = cm.ExecuteReader

        While dr.Read
            c += 1
            DataGridView3.Rows.Add(c, dr.Item("id").ToString, dr.Item("cv_no").ToString, dr.Item("reference").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("supplier_name").ToString, dr.Item("payee_name").ToString, dr.Item("reference_code").ToString, dr.Item("subreference_code").ToString, dr.Item("checkvoucher_date").ToString, dr.Item("check_no").ToString, dr.Item("bank_branch").ToString, dr.Item("check_date").ToString, dr.Item("particulars").ToString, dr.Item("amount_due").ToString, dr.Item("debit_total").ToString, dr.Item("credit_total").ToString, dr.Item("manager_comment").ToString, dr.Item("gm_comment").ToString, dr.Item("coo_comment").ToString, dr.Item("status").ToString, dr.Item("manager_approval").ToString, dr.Item("gm_approval").ToString, dr.Item("coo_approval").ToString)

        End While

        dr.Close()
        cn.Close()

        'PAYMENT REQUEST

        DataGridView4.Rows.Clear()
        Dim d As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_paymentrequest", cn)
        dr = cm.ExecuteReader

        While dr.Read
            d += 1
            DataGridView4.Rows.Add(d, dr.Item("id").ToString, dr.Item("controlno").ToString, dr.Item("transaction_no").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("type_payment").ToString, dr.Item("date_needed").ToString, dr.Item("mode_payment").ToString, dr.Item("date").ToString, dr.Item("mode_release").ToString, dr.Item("supplier_name").ToString, dr.Item("account_name").ToString, dr.Item("account_no").ToString, dr.Item("bank_name").ToString, dr.Item("amount").ToString, dr.Item("amount_words").ToString, dr.Item("payment_remarks").ToString, dr.Item("reference_code").ToString, dr.Item("sub_referencecode").ToString, dr.Item("manager_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("gm_comment").ToString, dr.Item("coo_comment").ToString, dr.Item("status").ToString, dr.Item("manager_approval").ToString, dr.Item("finance_approval").ToString, dr.Item("gm_approval").ToString, dr.Item("coo_approval").ToString)

        End While

        dr.Close()
        cn.Close()


        'REIMBURSEMENT

        DataGridView5.Rows.Clear()
        Dim e As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_reimbursement", cn)
        dr = cm.ExecuteReader

        While dr.Read
            e += 1
            DataGridView5.Rows.Add(e, dr.Item("id").ToString, dr.Item("reimbursementno").ToString, dr.Item("transaction_no").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("total_liquidation").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString, dr.Item("endorsed_approval").ToString, dr.Item("finance_approval").ToString, dr.Item("final_approval").ToString)

        End While

        dr.Close()
        cn.Close()


        'RF

        DataGridView6.Rows.Clear()
        Dim f As Integer
        cn.Open()
        cm = New MySqlCommand("select * from tbl_tic_rf_replenishment", cn)
        dr = cm.ExecuteReader

        While dr.Read
            f += 1
            DataGridView6.Rows.Add(f, dr.Item("id").ToString, dr.Item("rf_no").ToString, dr.Item("reference").ToString, dr.Item("date").ToString, dr.Item("employee").ToString, dr.Item("department").ToString, dr.Item("depcode").ToString, dr.Item("purpose").ToString, dr.Item("revolving_fund").ToString, dr.Item("total_liquidation").ToString, dr.Item("unreplenish").ToString, dr.Item("endorsed_comment").ToString, dr.Item("finance_comment").ToString, dr.Item("final_comment").ToString, dr.Item("status").ToString, dr.Item("endorsed_approval").ToString, dr.Item("finance_approval").ToString, dr.Item("final_approval").ToString)

        End While

        dr.Close()
        cn.Close()

    End Sub

End Class
