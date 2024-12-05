Public Class frmLOGIN

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click

        Me.Hide()
        frm1HOME.txtHOMENAME.Text = "SAMPLE"
        frm1HOME.txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT"
        frm1HOME.txtHOMEDEPCODE.Text = "IT"
        frm1HOME.txtPOSITION.Text = "GENERAL MANAGER"

        frm1HOME.ShowDialog()

    End Sub

End Class
