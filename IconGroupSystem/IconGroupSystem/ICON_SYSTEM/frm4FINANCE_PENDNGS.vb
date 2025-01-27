Public Class frm4FINANCE_PENDNGS

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim f As New frmVIEW_TIC_CA_LIQUIDATION_FINANCE
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Button2.Enabled = False
        f.Show()

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim f As New frmVIEW_8SI_CA_LIQUIDATION_FINANCE
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Button2.Enabled = False
        f.Show()

    End Sub




    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim f As New frmVIEW_TIC_CASHADVANCE_FINANCE
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Button2.Enabled = False
        f.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim f As New frmVIEW_8SI_CASHADVANCE_FINANCE
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Button2.Enabled = False
        f.Show()

    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim f As New frmVIEW_TIC_CHECKVOUCHER_FINANCE
        f.LoadCVList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim f As New frmVIEW_TIC_CHECKVOUCHER_FINANCE
        f.LoadCVList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Dim f As New frmVIEW_TIC_PAYMENTREQUEST_FINANCE
        f.LoadList()
        f.Add_Approval_Button()
        f.btnAPPROVED.Enabled = False
        f.btnDISAPPROVED.Enabled = False
        f.btnRETURN.Enabled = False
        f.Show()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Dim f As New frmVIEW_8SI_PAYMENTREQUEST_FINANCE
        f.LoadList()
        f.Add_Approval_Button()
        f.btnAPPROVED.Enabled = False
        f.btnDISAPPROVED.Enabled = False
        f.btnRETURN.Enabled = False
        f.Show()

    End Sub


    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        Dim f As New frmVIEW_TIC_REIMBURSEMENT_FINANCE
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Button2.Enabled = False
        f.Show()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        Dim f As New frmVIEW_8SI_REIMBURSEMENT_FINANCE
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Button2.Enabled = False
        f.Show()

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        Dim f As New frmVIEW_TIC_RF_REPLENISHMENT_FINANCE
        f.LoadRFList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        Dim f As New frmVIEW_TIC_RF_REPLENISHMENT_FINANCE
        f.LoadRFList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub


End Class