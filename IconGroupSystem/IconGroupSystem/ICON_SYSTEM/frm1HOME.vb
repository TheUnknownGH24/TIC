Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Public Class frm1HOME

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub toolStripMenuItem2_Click(sender As Object, e As EventArgs)

        Dim f As New frmWAREHOUSE_DR_LOYVERSE
        f.MdiParent = Me
        f.btnBROWSE.Enabled = True
        f.btnDISPLAY.Enabled = False
        f.btnCREATE.Enabled = False
        f.Show()

    End Sub

    Private Sub fileMenu_Click(sender As Object, e As EventArgs) Handles fileMenu.Click
        System.Diagnostics.Process.Start("calc.exe")
    End Sub

    Private Sub editMenu_Click(sender As Object, e As EventArgs) Handles editMenu.Click
        System.Diagnostics.Process.Start("excel.exe")
    End Sub

    Private Sub viewMenu_Click(sender As Object, e As EventArgs) Handles viewMenu.Click
        System.Diagnostics.Process.Start("WINWORD.exe")
    End Sub

    Private Sub toolsMenu_Click(sender As Object, e As EventArgs) Handles toolsMenu.Click
        System.Diagnostics.Process.Start("POWERPNT.exe")
    End Sub

    Private Sub windowsMenu_Click(sender As Object, e As EventArgs) Handles windowsMenu.Click
        System.Diagnostics.Process.Start("notepad.exe")
    End Sub

    Private Sub printPreviewToolStripButton_Click(sender As Object, e As EventArgs) Handles printPreviewToolStripButton.Click

        Try
            If MsgBox("Do you want to Log out ?", vbYesNo + vbQuestion, "CONFIRMATION") = vbYes Then

                Application.Exit()

                'Me.Dispose()

                '                With frmLOGINFORM

                '                .txtUSERNAME.Text = String.Empty
                '                .txtPASSWORD.Text = String.Empty
                '                .ShowDialog()

                '                End With

            End If

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub IMPORTSHOPEEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IMPORTSHOPEEToolStripMenuItem.Click

        Dim f As New frmDR_SHOPEE
        f.MdiParent = Me
        f.btnBROWSE.Enabled = True
        f.btnDISPLAY.Enabled = False
        f.txtSEARCHNAME.Enabled = False
        f.btnCREATE.Enabled = False
        f.Show()


    End Sub

    Private Sub sALESINVOICEToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MAINTANANCEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MAINTANANCEToolStripMenuItem.Click

        If txtHOMETYPE.Text = "ADMINISTRATOR" Then


            Dim f As New frmPRODUCTLIST
            f.MdiParent = Me
            f.LoadProductList()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub MANAGEPRODCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MANAGEPRODCToolStripMenuItem.Click

        If txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmPRODUCT
            f.MdiParent = Me
            f.LoadCategory()
            f.btnUPDATE.Enabled = True
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub CATEGORYENTRYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CATEGORYENTRYToolStripMenuItem.Click

        If txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmCATEGORY
            f.MdiParent = Me
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub IMPORTLAZADAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IMPORTLAZADAToolStripMenuItem.Click

        Dim f As New frmWAREHOUSE_DR_LAZADA
        f.MdiParent = Me
        'f.LoadList()
        f.Show()

    End Sub

    Private Sub IMPORTTIKTOKToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles IMPORTTIKTOKToolStripMenuItem1.Click

        Dim f As New frmDR_TIKTOK
        f.MdiParent = Me
        f.btnBROWSE.Enabled = True
        f.btnDISPLAY.Enabled = False
        f.txtSEARCHNAME.Enabled = False
        f.btnCREATE.Enabled = False
        f.Show()

    End Sub

    Private Sub dRMODIFYToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Dim f As New frmMODIFY_DR
        f.MdiParent = Me
        f.LoadDRList()
        f.Show()

    End Sub

    Private Sub IMPORTSALESINVOICEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IMPORTSALESINVOICEToolStripMenuItem.Click

        Dim f As New frmMODIFY_SI
        f.MdiParent = Me
        f.LoadSIList()
        f.Show()

    End Sub

    Private Sub LIQUIDATIONFORMToolStripMenuItem_Click(sender As Object, e As EventArgs)

        'Dim f As New frmPAYMENTREQUEST
        'f.MdiParent = Me
        'f.Show()

    End Sub

    Private Sub CASHADVANCEFORMToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Dim f As New frm8SI_CASHADVANCE
        f.MdiParent = Me
        f.Show()

    End Sub

    Private Sub REIMBURSEMENTFORMToolStripMenuItem_Click(sender As Object, e As EventArgs)

        'Dim f As New frmREIMBURSEMENT
        'f.MdiParent = Me
        'f.Show()

    End Sub

    Private Sub RFREPLENISHMENTToolStripMenuItem_Click(sender As Object, e As EventArgs)

        'Dim f As New frmRFREPLENISHMENT
        'f.MdiParent = Me
        'f.Show()

    End Sub

    Private Sub PETTYCASHREPLENISHMENTToolStripMenuItem1_Click(sender As Object, e As EventArgs)

        Dim f As New frmPCVREPLENISHMENT
        f.MdiParent = Me
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem_Click(sender As Object, e As EventArgs)

        'Dim f As New frmTICVOUCHER
        'f.MdiParent = Me
        'f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem_Click(sender As Object, e As EventArgs)

        'Dim f As New frm8SIVOUCHER
        'f.MdiParent = Me
        'f.Show()

    End Sub

    Private Sub ITEMDATAENTRYUToolStripMenuItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub pURCHASEDREQUISITIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles pURCHASEDREQUISITIONToolStripMenuItem.Click

        'Dim f As New frmPURCHASEDREQUEST
        'f.MdiParent = Me
        'f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        'f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        'f.LoadITEM()
        'f.LoadSupplier()
        'f.txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")
        'f.Show()

    End Sub

    Private Sub PORECORDSToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Dim f As New frmPORECORDS
        f.MdiParent = Me
        f.LoadPOList()
        f.Show()

    End Sub

    Private Sub SUPPLYREQUISITIONToolStripMenuItem2_Click(sender As Object, e As EventArgs)

        If txtPOSITION.Text = "MANAGER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmSRS_MANAGER_APPROVAL
            f.MdiParent = Me
            f.LoadSRSList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SUPPLYREQUISITUIBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SUPPLYREQUISITUIBToolStripMenuItem.Click

        If txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmSRS_MODIFY
            f.MdiParent = Me
            f.LoadSRSList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub ITEMRETURNRTVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ITEMRETURNRTVToolStripMenuItem.Click

        Dim f As New frmWAREHOUSE_RR_RTV
        f.MdiParent = Me
        f.Show()

    End Sub

    Private Sub RETURNINVENTORYPULLOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RETURNINVENTORYPULLOUTToolStripMenuItem.Click

        Dim f As New frmWAREHOUSE_RR_IPR
        f.MdiParent = Me
        f.LoadIPRList()
        f.Add_Approval_Button()

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text
        f.txtNAME.Text = txtHOMENAME.Text

        f.Show()

    End Sub

    Private Sub SUPPLYREQUISITIONToolStripMenuItem5_Click(sender As Object, e As EventArgs)

        If txtPOSITION.Text = "GENERAL MANAGER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmSRS_GM_APPROVAL
            f.MdiParent = Me
            f.LoadSRSList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub SUPPLYREQUISITIONToolStripMenuItem3_Click(sender As Object, e As EventArgs)

        Dim f As New frmDR_WAREHOUSE_SRS_LIST
        f.MdiParent = Me
        f.LoadSRSList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub ADDUSERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ADDUSERToolStripMenuItem.Click

        If txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmUSER_FORM
            f.MdiParent = Me
            f.btnUPDATE.Enabled = False
            f.btnUPDATE.Visible = False
            f.LoadDepartmentList()
            f.Show()


        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub USERLISTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles USERLISTToolStripMenuItem.Click

        If txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmUSERLIST
            f.MdiParent = Me
            f.LoadUSERList()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub CHANGEPASSWORDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CHANGEPASSWORDToolStripMenuItem.Click

        Dim f As New frmCHANGEPASS
        f.MdiParent = Me
        f.txtID.Text = txtHOMEID.Text
        f.load_pass()
        f.Show()

    End Sub

    Private Sub DELIVERYRECEIPTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DELIVERYRECEIPTToolStripMenuItem.Click

        Dim f As New frmDR_WAREHOUSE_MODIFY_SRS_LIST
        f.MdiParent = Me
        f.LoadDRSRSList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem5.Click

        Dim f As New frmTIC_REQUESTSLIP
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtTRANSAC.Text = Now.ToString("yyyyMMddHHmmss")
        f.LoadITEM()
        f.LoadClassification()
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem5.Click

        Dim f As New frm8SI_REQUESTSLIP
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtTRANSAC.Text = Now.ToString("yyyyMMddHHmmss")
        f.LoadITEM()
        f.LoadClassification()
        f.btnSAVE.Enabled = False
        'f.btnPRINT.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem8_Click(sender As Object, e As EventArgs)

        Dim f As New frmTIC_REQUESTSLIP_GM_FORM
        f.MdiParent = Me
        f.LoadAPPROVALLIST()
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem7_Click(sender As Object, e As EventArgs)

        If txtHOMECLASS.Text = "MANAGER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_REQUESTSLIP_MANAGER_FORM
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.LoaDAPPROVALList()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem7_Click(sender As Object, e As EventArgs)

        If txtHOMECLASS.Text = "MANAGER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_REQUESTSLIP_MANAGER_FORM
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.txtDEP.Text = txtHOMEDEPCODE.Text
            f.LoaDAPPROVALList()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem8.Click


        Dim f As New frm8SI_REQUESTSLIP_GM_FORM
        f.MdiParent = Me
        f.LoadAPPROVALLIST()
        f.Show()


    End Sub

    Private Sub THEICONCLINICToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem1.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_PR_REQUEST_LIST
            f.MdiParent = Me
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.LoadREQUESTList()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub SONAKAINCToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem1.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then


            Dim f As New frm8SI_PR_REQUEST_LIST
            f.MdiParent = Me
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.LoadREQUESTList()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub PRMODIFYToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PRMODIFYToolStripMenuItem1.Click

        'If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

        If txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_PR_MODIFY
            f.MdiParent = Me
            f.LoadPRList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub PRMODIFYToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles PRMODIFYToolStripMenuItem2.Click

        'If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

        If txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_PR_MODIFY
            f.MdiParent = Me
            f.LoadPRList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub PRAPPROVALToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRAPPROVALToolStripMenuItem.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" And txtHOMECLASS.Text = "MANAGER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_PR_MANAGER_FORM_FINAL
            f.MdiParent = Me
            f.LoadPRList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub PRAPPROVALToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles PRAPPROVALToolStripMenuItem4.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" And txtHOMECLASS.Text = "MANAGER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_PR_MANAGER_FORM_FINAL
            f.MdiParent = Me
            f.LoadPRList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.btnPRINT.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem9.Click

        Dim f As New frmTIC_PR_GM_FORM_FINAL
        f.MdiParent = Me
        f.LoadPRList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub ITEMLISTToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ITEMLISTToolStripMenuItem1.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmITEMLIST
            f.MdiParent = Me
            f.LoadITEMList()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub ITEMENTRYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ITEMENTRYToolStripMenuItem.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmITEM
            f.MdiParent = Me
            f.LoadClassification()
            f.LoadUOM()
            'f.LoadGENERICNAME()
            f.btnUPDATE.Enabled = False
            f.btnUPDATE.Visible = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub SUPPLIERLISTToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SUPPLIERLISTToolStripMenuItem1.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmSUPPLIERLIST
            f.MdiParent = Me
            f.LoadSupplierList()
            f.btnUPDATE.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub SUPPLIERENTRYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SUPPLIERENTRYToolStripMenuItem.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmSUPPLIER
            f.MdiParent = Me
            f.btnUPDATE.Enabled = False
            f.btnUPDATE.Visible = False
            f.LoadPaymentTerms()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub THEICONCLINICToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem12.Click

        Dim f As New frmTIC_REQUESTLIST_RETURN
        f.MdiParent = Me
        f.LoadREQUESTList()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem11.Click

        Dim f As New frm8SI_REQUESTLIST_RETURN
        f.MdiParent = Me
        f.LoadREQUESTList()
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem10.Click

        Dim f As New frmTIC_PR_COO_FORM_FINAL
        f.MdiParent = Me
        f.LoadPRList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub GENERALMANAGERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GENERALMANAGERToolStripMenuItem.Click

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem13.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then


            Dim f As New frmTIC_PR_RETURN
            f.MdiParent = Me
            f.LoadPRList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub SONAKAINCToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem12.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_PR_RETURN
            f.MdiParent = Me
            f.LoadPRList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub POAPPROVALToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles POAPPROVALToolStripMenuItem4.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" And txtHOMECLASS.Text = "MANAGER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_PO_MANAGER_FORM
            f.MdiParent = Me
            f.LoadPOList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub SONAKAINCToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem9.Click

        Dim f As New frm8SI_PR_GM_FORM_FINAL
        f.MdiParent = Me
        f.LoadPRList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem10.Click

        Dim f As New frm8SI_PR_COO_FORM_FINAL
        f.MdiParent = Me
        f.LoadPRList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem2.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_PO_PR_LIST
            f.MdiParent = Me
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.LoadREQUESTList()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub POAPPROVALToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles POAPPROVALToolStripMenuItem.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" And txtHOMECLASS.Text = "MANAGER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_PO_MANAGER_FORM
            f.MdiParent = Me
            f.LoadPOList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub THEICONCLINICToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem15.Click

        Dim f As New frmTIC_PO_GM_FORM
        f.MdiParent = Me
        f.LoadPOList()
        f.Add_Approval_Button()
        f.Show()


    End Sub

    Private Sub THEICONCLINICToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem14.Click

        Dim f As New frmTIC_PO_COO_FORM
        f.MdiParent = Me
        f.LoadPOList()
        f.Add_Approval_Button()
        f.Show()
    End Sub

    Private Sub POMODIFYToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles POMODIFYToolStripMenuItem1.Click

        'If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

        If txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_PO_MODIFYLIST
            f.MdiParent = Me
            f.LoadPOList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub SONAKAINCToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem2.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_PO_PR_LIST
            f.MdiParent = Me
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.LoadREQUESTList()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub THEICONCLINICToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem16.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then


            Dim f As New frmTIC_PO_MODIFYLIST
            f.MdiParent = Me
            f.LoadPOList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub SONAKAINCToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem15.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_PO_MODIFYLIST
            f.MdiParent = Me
            f.LoadPOList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub POMODIFYToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles POMODIFYToolStripMenuItem2.Click

        'If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

        If txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_PO_MODIFYLIST
            f.MdiParent = Me
            f.LoadPOList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem14.Click

        Dim f As New frm8SI_PO_GM_FORM
        f.MdiParent = Me
        f.LoadPOList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem13.Click

        Dim f As New frm8SI_PO_COO_FORM
        f.MdiParent = Me
        f.LoadPOList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem18.Click

        Dim f As New frmTIC_TRACKER_PR
        f.MdiParent = Me
        f.LoadPR()
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem19.Click

        Dim f As New frmTIC_TRACKER_PO
        f.MdiParent = Me
        f.LoadPO()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem17.Click

        Dim f As New frm8SI_TRACKER_PR
        f.MdiParent = Me
        f.LoadPR()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem18.Click

        Dim f As New frm8SI_TRACKER_PO
        f.MdiParent = Me
        f.LoadPO()
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem17.Click

        Dim f As New frmTIC_TRACKER_SLP
        f.MdiParent = Me
        f.LoadSLP()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem16.Click

        Dim f As New frm8SI_TRACKER_SLP
        f.MdiParent = Me
        f.LoadSLP()
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem20_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem20.Click

        Dim f As New frmTIC_REQUESTLIST
        f.MdiParent = Me
        f.LoadREQUESTList()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem19.Click

        Dim f As New frm8SI_REQUESTLIST
        f.MdiParent = Me
        f.LoadREQUESTList()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem6_Click(sender As Object, e As EventArgs)

        Dim f As New frm8SI_CASHADVANCE_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtDEP.Text = txtHOMEDEPCODE.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub CASHADVANCEFORMToolStripMenuItem2_Click(sender As Object, e As EventArgs)




    End Sub

    Private Sub THEICONCLINICToolStripMenuItem23_Click(sender As Object, e As EventArgs)

        If txtPOSITION.Text = "CHIEF OPERATING OFFICER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_CASHADVANCE_GM_COO
            f.MdiParent = Me
            f.LoadCAList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button5.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem23_Click(sender As Object, e As EventArgs)

        Dim f As New frm8SI_CASHADVANCE
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem24_Click(sender As Object, e As EventArgs)

        Dim f As New frmTIC_CASHADVANCE
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.Show()


    End Sub

    Private Sub CASHADVANCEToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CASHADVANCEToolStripMenuItem2.Click

        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_CASHADVANCE_FINANCE
            f.MdiParent = Me
            f.LoadCAList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub CASHADVANCEFORMToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CASHADVANCEFORMToolStripMenuItem.Click

        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_CASHADVANCE_FINANCE
            f.MdiParent = Me
            f.LoadCAList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem6_Click(sender As Object, e As EventArgs)

        Dim f As New frmTIC_CASHADVANCE_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub


    Private Sub SONAKAINCToolStripMenuItem21_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem21.Click

        If txtPOSITION.Text = "GENERAL MANAGER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_CASHADVANCE_GM_COO
            f.MdiParent = Me
            f.LoadCAList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem22_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem22.Click

        If txtPOSITION.Text = "CHIEF OPERATING OFFICER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_CASHADVANCE_COO
            f.MdiParent = Me
            f.LoadCAList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem21_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem21.Click

        If txtPOSITION.Text = "GENERAL MANAGER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_CASHADVANCE_GM_COO
            f.MdiParent = Me
            f.LoadCAList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem22_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem22.Click

        If txtPOSITION.Text = "CHIEF OPERATING OFFICER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_CASHADVANCE_COO
            f.MdiParent = Me
            f.LoadCAList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub SONAKAINCToolStripMenuItem24_Click(sender As Object, e As EventArgs)

        Dim f As New frm8SI_CA_LIQUIDATION
        f.MdiParent = Me
        f.LoadCAList()
        f.Add_Approval_Button()
        f.Show()

    End Sub


    Private Sub SONAKAINCToolStripMenuItem25_Click(sender As Object, e As EventArgs)

        Dim f As New frm8SI_CA_LIQUIDATION_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtDEP.Text = txtHOMEDEPCODE.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub CALIQUIDATIONToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles CALIQUIDATIONToolStripMenuItem3.Click

        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_CA_LIQUIDATION_FINANCE
            f.MdiParent = Me
            f.LoadCAList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem26_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem26.Click

        If txtPOSITION.Text = "GENERAL MANAGER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_CA_LIQUIDATION_GM_COO
            f.MdiParent = Me
            f.LoadCAList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub SONAKAINCToolStripMenuItem27_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem27.Click

        If txtPOSITION.Text = "CHIEF OPERATING OFFICER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_CA_LIQUIDATION_COO
            f.MdiParent = Me
            f.LoadCAList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem28_Click(sender As Object, e As EventArgs)

        Dim f As New frm8SI_CASHADVANCE_RETURN
        f.MdiParent = Me
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem28_Click(sender As Object, e As EventArgs)

        Dim f As New frmTIC_CASHADVANCE_RETURN
        f.MdiParent = Me
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem29_Click(sender As Object, e As EventArgs)

        Dim f As New frm8SI_CA_LIQUIDATION_RETURN
        f.MdiParent = Me
        f.txtDEP.Text = txtHOMEDEPCODE.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub



    Private Sub THEICONCLINICToolStripMenuItem23_Click_1(sender As Object, e As EventArgs)

        Dim f As New frmTIC_CA_LIQUIDATION
        f.MdiParent = Me
        f.LoadCAList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem29_Click(sender As Object, e As EventArgs)

        Dim f As New frmTIC_CA_LIQUIDATION_RETURN
        f.MdiParent = Me
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub CALIQUIDATIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CALIQUIDATIONToolStripMenuItem.Click

        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_CA_LIQUIDATION_FINANCE
            f.MdiParent = Me
            f.LoadCAList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem25_Click(sender As Object, e As EventArgs)

        Dim f As New frmTIC_CA_LIQUIDATION_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem26_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem26.Click

        If txtPOSITION.Text = "GENERAL MANAGER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_CA_LIQUIDATION_GM_COO
            f.MdiParent = Me
            f.LoadCAList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem27_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem27.Click

        If txtPOSITION.Text = "CHIEF OPERATING OFFICER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_CA_LIQUIDATION_COO
            f.MdiParent = Me
            f.LoadCAList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem30_Click(sender As Object, e As EventArgs)

        Dim f As New frm8SI_PETTYCASHVOUCHER
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")
        f.Show()


    End Sub

    Private Sub THEICONCLINICToolStripMenuItem30_Click(sender As Object, e As EventArgs)

        Dim f As New frmTIC_PETTYCASHVOUCHER
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem31_Click(sender As Object, e As EventArgs)

        Dim f As New frm8SI_PETTYCASHVOUCHER_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem31_Click(sender As Object, e As EventArgs)

        Dim f As New frmTIC_PETTYCASHVOUCHER_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub PETTYCASHToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PETTYCASHToolStripMenuItem1.Click


        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_PETTYCASHVOUCHER_FINANCE
            f.MdiParent = Me
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.LoadPCVList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub PETTYCASHToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles PETTYCASHToolStripMenuItem2.Click


        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_PETTYCASHVOUCHER_FINANCE
            f.MdiParent = Me
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.LoadPCVList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub ONAKAINCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ONAKAINCToolStripMenuItem.Click

        Dim f As New frm8SI_REQUESTSLIP_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadAPPROVALLIST()
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem11.Click

        Dim f As New frmTIC_REQUESTSLIP_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadAPPROVALLIST()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem33_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem33.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_PR_FORM_RECORD
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.LoadPRList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem33_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem33.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then


            Dim f As New frmTIC_PR_FORM_RECORD
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.LoadPRList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub IMPORTDIRECTSALESToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CASHADVANCEFORMToolStripMenuItem2_Click_1(sender As Object, e As EventArgs) Handles CASHADVANCEFORMToolStripMenuItem2.Click

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem35_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem35.Click

        Dim f As New frmTIC_CASHADVANCE
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.dataGridView1.Enabled = True
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem36_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem36.Click

        Dim f As New frm8SI_CASHADVANCE
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.dataGridView1.Enabled = True
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem36_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem36.Click

        Dim f As New frmTIC_CA_LIQUIDATION
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.Show()


    End Sub

    Private Sub SONAKAINCToolStripMenuItem37_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem37.Click

        Dim f As New frm8SI_CA_LIQUIDATION
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.Show()


    End Sub

    Private Sub THEICONCLINICToolStripMenuItem37_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem37.Click

        Dim f As New frmTIC_CASHADVANCE_RETURN
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem38_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem38.Click

        Dim f As New frm8SI_CASHADVANCE_RETURN
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.txtDEP.Text = txtHOMEDEPCODE.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem38_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem38.Click

        Dim f As New frmTIC_CA_LIQUIDATION_RETURN
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.LoadSupplierList()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()


    End Sub

    Private Sub SONAKAINCToolStripMenuItem39_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem39.Click

        Dim f As New frm8SI_CA_LIQUIDATION_RETURN
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.txtDEP.Text = txtHOMEDEPCODE.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.LoadSupplierList()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub SUPPLIERENTRYToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SUPPLIERENTRYToolStripMenuItem1.Click

        If txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmSUPPLIER_FINANCE
            f.MdiParent = Me
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

    End Sub


    Private Sub SUPPLIERRECORDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SUPPLIERRECORDToolStripMenuItem.Click

        If txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmSUPPLIER_FINANCE_LIST
            f.MdiParent = Me
            f.LoadSupplierList()
            f.btnUPDATE.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

    End Sub


    Private Sub SONAKAINCToolStripMenuItem52_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem52.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_PO_RECORD
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.LoadPOList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub


    Private Sub THEICONCLINICToolStripMenuItem49_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem49.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_PO_RECORD
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.LoadPOList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub ToolStripDropDownButton2_Click(sender As Object, e As EventArgs)

        If txtHOMECLASS.Text = "MANAGER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Exit Sub

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        If txtHOMECLASS.Text = "EXECOM" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Exit Sub

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem35_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem35.Click

        Dim f As New frm8SI_RF_REPLENISHMENT
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.txtREFERENCE.Text = Now.ToString("yyyyMMddHHmmss")
        f.LoadSupplierList()
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.dataGridView1.Enabled = True
        f.Show()

    End Sub


    Private Sub THEICONCLINICToolStripMenuItem34_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem34.Click

        Dim f As New frmTIC_RF_REPLENISHMENT
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.txtREFERENCE.Text = Now.ToString("yyyyMMddHHmmss")
        f.LoadSupplierList()
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.dataGridView1.Enabled = True
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem3_Click(sender As Object, e As EventArgs)

        Dim f As New frm8SI_RF_REPLENISHMENT_CHECKED
        f.MdiParent = Me
        f.LoadRFList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub RFREPLENISHMENTToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RFREPLENISHMENTToolStripMenuItem2.Click

        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_RF_REPLENISHMENT_FINANCE
            f.MdiParent = Me
            f.LoadRFList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem46_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem46.Click

        Dim f As New frm8SI_RF_REPLENISHMENT_FINAL
        f.MdiParent = Me
        f.LoadRFList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub


    Private Sub THEICONCLINICToolStripMenuItem40_Click(sender As Object, e As EventArgs)

        Dim f As New frmTIC_RF_REPLENISHMENT_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadRFList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem3_Click(sender As Object, e As EventArgs)

        Dim f As New frmTIC_RF_REPLENISHMENT_CHECKED
        f.MdiParent = Me
        f.LoadRFList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub RFREPLENISHMEMTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RFREPLENISHMEMTToolStripMenuItem.Click

        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then


            Dim f As New frmTIC_RF_REPLENISHMENT_FINANCE
            f.MdiParent = Me
            f.LoadRFList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If



    End Sub


    Private Sub THEICONCLINICToolStripMenuItem44_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem44.Click

        Dim f As New frmTIC_RF_REPLENISHMENT_FINAL
        f.MdiParent = Me
        f.LoadRFList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem53_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem53.Click

        Dim f As New frm8SI_CA_LIQUIDATION_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.txtDEP.Text = txtHOMEDEPCODE.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem4.Click

        Dim f As New frm8SI_CASHADVANCE_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.txtDEP.Text = txtHOMEDEPCODE.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem4.Click

        Dim f As New frmTIC_CASHADVANCE_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem51_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem51.Click

        Dim f As New frmTIC_RF_REPLENISHMENT_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.LoadRFList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem54_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem54.Click

        Dim f As New frm8SI_RF_REPLENISHMENT_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.txtDEP.Text = txtHOMEDEPCODE.Text
        f.LoadRFList()
        f.Add_Approval_Button()
        f.Show()

    End Sub


    Private Sub SONAKAINCToolStripMenuItem40_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem40.Click

        Dim f As New frm8SI_PAYMENTREQUEST
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")
        f.LoadSupplierList()
        f.LoadPaymentType()
        f.btnPRINT.Enabled = False
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem43_Click(sender As Object, e As EventArgs)

        Dim f As New frm8SI_PAYMENTREQUEST_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadList()
        f.Add_Approval_Button()
        f.btnAPPROVED.Enabled = False
        f.btnDISAPPROVED.Enabled = False
        f.Show()

    End Sub

    Private Sub PAYMENTREQUESTToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PAYMENTREQUESTToolStripMenuItem1.Click

        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then


            Dim f As New frm8SI_PAYMENTREQUEST_FINANCE
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.LoadList()
            f.Add_Approval_Button()
            f.btnAPPROVED.Enabled = False
            f.btnDISAPPROVED.Enabled = False
            f.btnRETURN.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub


    Private Sub SONAKAINCToolStripMenuItem45_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem45.Click

        Dim f As New frm8SI_PAYMENTREQUEST_GM
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadList()
        f.Add_Approval_Button()
        f.btnAPPROVED.Enabled = False
        f.btnDISAPPROVED.Enabled = False
        f.btnRETURN.Enabled = False
        f.Show()

    End Sub


    Private Sub SONAKAINCToolStripMenuItem49_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem49.Click

        Dim f As New frm8SI_PAYMENTREQUEST_COO
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadList()
        f.Add_Approval_Button()
        f.btnAPPROVED.Enabled = False
        f.btnDISAPPROVED.Enabled = False
        f.btnRETURN.Enabled = False
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem57_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem57.Click

        Dim f As New frm8SI_PAYMENTREQUEST_RETURN
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem58_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem58.Click

        Dim f As New frm8SI_PAYMENTREQUEST_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.LoadList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem32_Click_1(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem32.Click

        Dim f As New frmTIC_PAYMENTREQUEST
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")
        f.LoadSupplierList()
        f.LoadPaymentType()
        f.btnPRINT.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem54_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem54.Click

        Dim f As New frmTIC_PAYMENTREQUEST_RETURN
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem55_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem55.Click

        Dim f As New frmTIC_PAYMENTREQUEST_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub PAYMENTREToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PAYMENTREToolStripMenuItem.Click

        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_PAYMENTREQUEST_FINANCE
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.LoadList()
            f.Add_Approval_Button()
            f.btnAPPROVED.Enabled = False
            f.btnDISAPPROVED.Enabled = False
            f.btnRETURN.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem41_Click(sender As Object, e As EventArgs)

        Dim f As New frmTIC_PAYMENTREQUEST_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadList()
        f.Add_Approval_Button()
        f.btnAPPROVED.Enabled = False
        f.btnDISAPPROVED.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem43_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem43.Click

        Dim f As New frmTIC_PAYMENTREQUEST_GM
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadList()
        f.Add_Approval_Button()
        f.btnAPPROVED.Enabled = False
        f.btnDISAPPROVED.Enabled = False
        f.btnRETURN.Enabled = False
        f.Show()

    End Sub

    Private Sub UESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UESToolStripMenuItem.Click

        Dim f As New frmTIC_PAYMENTREQUEST_COO
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadList()
        f.Add_Approval_Button()
        f.btnAPPROVED.Enabled = False
        f.btnDISAPPROVED.Enabled = False
        f.btnRETURN.Enabled = False
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem32_Click_1(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem32.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_PAYMENTREQUEST_PO
            f.MdiParent = Me
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
            f.LoadPOList()
            f.Add_Approval_Button()
            f.btnPRINT.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub THEICONCLINICToolStripMenuItem30_Click_1(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem30.Click


        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_PAYMENTREQUEST_PO
            f.MdiParent = Me
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
            f.LoadPOList()
            f.Add_Approval_Button()
            f.btnPRINT.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub


    Private Sub SONAKAINCToolStripMenuItem34_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem34.Click

        Dim f As New frm8SI_REIMBURSEMENT
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.txtREFERENCE.Text = Now.ToString("yyyyMMddHHmmss")
        f.LoadSupplierList()
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.dataGridView1.Enabled = True
        f.Show()

    End Sub


    Private Sub SONAKAINCToolStripMenuItem41_Click(sender As Object, e As EventArgs)

        Dim f As New frm8SI_REIMBURSEMENT_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub


    Private Sub REIMBURSEMENTFORMToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles REIMBURSEMENTFORMToolStripMenuItem2.Click

        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_REIMBURSEMENT_FINANCE
            f.MdiParent = Me
            f.LoadREIMList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem47_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem47.Click

        Dim f As New frm8SI_REIMBURSEMENT_FINAL
        f.MdiParent = Me
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Button2.Enabled = False
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem51_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem51.Click

        Dim f As New frm8SI_REIMBURSEMENT_COO
        f.MdiParent = Me
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Button2.Enabled = False
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem55_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem55.Click

        Dim f As New frm8SI_REIMBURSEMENT_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.txtDEP.Text = txtHOMEDEPCODE.Text
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem59_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem59.Click

        Dim f As New frm8SI_REIMBURSEMENT_RETURN
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.txtDEP.Text = txtHOMEDEPCODE.Text
        f.LoadREIMList()
        f.LoadSupplierList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub


    Private Sub THEICONCLINICToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem.Click

        Dim f As New frmTIC_REIMBURSEMENT
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.txtREFERENCE.Text = Now.ToString("yyyyMMddHHmmss")
        f.LoadSupplierList()
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.dataGridView1.Enabled = True
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem52_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem52.Click

        Dim f As New frmTIC_REIMBURSEMENT_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem56_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem56.Click

        Dim f As New frmTIC_REIMBURSEMENT_RETURN
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.LoadREIMList()
        f.LoadSupplierList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem39_Click(sender As Object, e As EventArgs)

        Dim f As New frmTIC_REIMBURSEMENT_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem45_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem45.Click

        Dim f As New frmTIC_REIMBURSEMENT_FINAL
        f.MdiParent = Me
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Button2.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem48_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem48.Click

        Dim f As New frmTIC_REIMBURSEMENT_COO
        f.MdiParent = Me
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Button2.Enabled = False
        f.Show()

    End Sub


    Private Sub SONAKAINCToolStripMenuItem23_Click_1(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem23.Click

        Dim f As New frm8SI_PETTYCASHVOUCHER
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.dataGridView1.Enabled = True
        f.Show()

    End Sub


    Private Sub SONAKAINCToolStripMenuItem29_Click_1(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem29.Click

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_PETTYCASHVOUCHER_FINAL
            f.MdiParent = Me
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.LoadPCVList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem29_Click_1(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem29.Click

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_PETTYCASHVOUCHER_FINAL
            f.MdiParent = Me
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.LoadPCVList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False

            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

    End Sub


    Private Sub THEICONCLINICToolStripMenuItem23_Click_2(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem23.Click

        Dim f As New frmTIC_PETTYCASHVOUCHER
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.dataGridView1.Enabled = True
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem24_Click_1(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem24.Click

        Dim f As New frm8SI_PCV_LIQUIDATION
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem60_Click(sender As Object, e As EventArgs)

        Dim f As New frm8SI_PCV_LIQUIDATION_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem61_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem61.Click

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_PCV_LIQUIDATION_FINANCE
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.LoadPCVList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem62_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem62.Click

        Dim f As New frm8SI_PETTYCASHVOUCHER_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem59_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem59.Click

        Dim f As New frmTIC_PETTYCASHVOUCHER_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem63_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem63.Click

        Dim f As New frm8SI_PCV_LIQUIDATION_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Show()

    End Sub


    Private Sub PETTYCASHLIQUIDATIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PETTYCASHLIQUIDATIONToolStripMenuItem.Click

        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_PCV_LIQUIDATION_FINAL
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.LoadPCVList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub PETTYCASHLIWUIDATIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PETTYCASHLIWUIDATIONToolStripMenuItem.Click

        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_PCV_LIQUIDATION_FINAL
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.LoadPCVList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem58_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem58.Click

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_PCV_LIQUIDATION_FINANCE
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.LoadPCVList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If


    End Sub

    Private Sub THEICONCLINICToolStripMenuItem60_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem60.Click

        Dim f As New frmTIC_PCV_LIQUIDATION_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem57_Click(sender As Object, e As EventArgs)

        Dim f As New frmTIC_PCV_LIQUIDATION_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem28_Click_1(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem28.Click

        Dim f As New frm8SI_PCV_REPLENISHMENT
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")
        f.txtDATE.Text = Format(Date.Now)
        f.LoadPCVLIQList()
        f.LoadPCVREIMList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem50_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem50.Click

        Dim f As New frmTIC_CA_LIQUIDATION_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub REIMBURSEMENTFORMToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles REIMBURSEMENTFORMToolStripMenuItem.Click

        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_REIMBURSEMENT_FINANCE
            f.MdiParent = Me
            f.LoadREIMList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem50_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem50.Click

        Dim f As New frm8SI_RF_REPLENISHMENT_COO
        f.MdiParent = Me
        f.LoadRFList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem47_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem47.Click

        Dim f As New frmTIC_RF_REPLENISHMENT_COO
        f.MdiParent = Me
        f.LoadRFList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem56_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem56.Click

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_CHECKVOUCHER_PAYREQUEST
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
            f.LoadAccountTitle()
            f.LoadList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub SONAKAINCToolStripMenuItem64_Click(sender As Object, e As EventArgs)

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_CHECKVOUCHER_REIMREQUEST
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
            f.LoadAccountTitle()
            f.LoadREIMList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem65_Click(sender As Object, e As EventArgs)

        Dim f As New frm8SI_CHECKVOUCHER_CASHADVANCE
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.LoadAccountTitle()
        f.LoadCAList()
        f.Add_Approval_Button()
        f.Show()

    End Sub


    Private Sub SONAKAINCToolStripMenuItem68_Click(sender As Object, e As EventArgs)

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_CHECKVOUCHER_RFREPLENISHMENT
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
            f.LoadAccountTitle()
            f.LoadRFList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem66_Click(sender As Object, e As EventArgs)

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_CHECKVOUCHER_CALIQ
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
            f.LoadAccountTitle()
            f.LoadCAList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem53_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem53.Click

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_CHECKVOUCHER_PAYREQUEST
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
            f.LoadAccountTitle()
            f.LoadList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem61_Click(sender As Object, e As EventArgs)

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_CHECKVOUCHER_REIMREQUEST
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
            f.LoadAccountTitle()
            f.LoadREIMList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem62_Click(sender As Object, e As EventArgs)

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_CHECKVOUCHER_CASHADVANCE
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
            f.LoadAccountTitle()
            f.LoadCAList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem65_Click(sender As Object, e As EventArgs)

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_CHECKVOUCHER_RFREPLENISHMENT
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
            f.LoadAccountTitle()
            f.LoadRFList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem63_Click(sender As Object, e As EventArgs)

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_CHECKVOUCHER_CALIQ
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
            f.LoadAccountTitle()
            f.LoadCAList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub


    Private Sub SONAKAINCToolStripMenuItem69_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem69.Click

        Dim f As New frm8SI_CHECKVOUCHER_RECORD
        f.MdiParent = Me
        f.LoadCVList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem66_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem66.Click

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_CHECKVOUCHER_RECORD
            f.MdiParent = Me
            f.LoadCVList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub


    Private Sub CHECKVOUCHERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CHECKVOUCHERToolStripMenuItem.Click

        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then


            Dim f As New frm8SI_CHECKVOUCHER_FINANCE
            f.MdiParent = Me
            f.LoadCVList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub

    Private Sub SONAKAINCToolStripMenuItem71_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem71.Click

        Dim f As New frm8SI_CHECKVOUCHER_GM
        f.MdiParent = Me
        f.LoadCVList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem72_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem72.Click

        Dim f As New frm8SI_CHECKVOUCHER_COO
        f.MdiParent = Me
        f.LoadCVList()
        f.Add_Approval_Button()
        f.Show()

    End Sub


    Private Sub SONAKAINCToolStripMenuItem70_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem70.Click


        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then


            Dim f As New frm8SI_CHECKVOUCHER_RETURN
            f.MdiParent = Me
            f.LoadAccountTitleLIST()
            f.LoadCVList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub


    Private Sub THEICONCLINICToolStripMenuItem67_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem67.Click

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then


            Dim f As New frmTIC_CHECKVOUCHER_RETURN
            f.MdiParent = Me
            f.LoadAccountTitleLIST()
            f.LoadCVList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub CHECKVOUCHERToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CHECKVOUCHERToolStripMenuItem1.Click

        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_CHECKVOUCHER_FINANCE
            f.MdiParent = Me
            f.LoadCVList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem68_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem68.Click

        Dim f As New frmTIC_CHECKVOUCHER_GM
        f.MdiParent = Me
        f.LoadCVList()
        f.Add_Approval_Button()

        f.Show()
    End Sub

    Private Sub THEICONCLINICToolStripMenuItem69_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem69.Click

        Dim f As New frmTIC_CHECKVOUCHER_COO
        f.MdiParent = Me
        f.LoadCVList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem73_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem73.Click

        Dim f As New frm8SI_PCV_LIQUIDATION_RETURN
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.LoadSupplierList()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem70_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem70.Click

        Dim f As New frmTIC_PCV_LIQUIDATION_RETURN
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.LoadSupplierList()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem3_Click_1(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem3.Click

        Dim f As New frm8SI_RF_REPLENISHMENT_RETURN
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.txtDEP.Text = txtHOMEDEPCODE.Text
        f.LoadRFList()
        f.Add_Approval_Button()
        f.LoadSupplierList()
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem3_Click_1(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem3.Click

        Dim f As New frmTIC_RF_REPLENISHMENT_RETURN
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtNAME.Text = txtHOMENAME.Text
        f.LoadRFList()
        f.Add_Approval_Button()
        f.LoadSupplierList()
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.Show()

    End Sub


    Private Sub SONAKAINCToolStripMenuItem44_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem44.Click

        Dim f As New frm8SI_PETTYCASHVOUCHER_RETURN
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.Show()

    End Sub


    Private Sub THEICONCLINICToolStripMenuItem42_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem42.Click

        Dim f As New frmTIC_PETTYCASHVOUCHER_RETURN
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.Show()

    End Sub


    Private Sub THEICONCLINICToolStripMenuItem24_Click_1(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem24.Click

        Dim f As New frmTIC_PCV_LIQUIDATION
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem75_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem75.Click

        Dim f As New frm8SI_PCV_REIMBURSEMENT
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.txtREFERENCE.Text = Now.ToString("yyyyMMddHHmmss")
        f.LoadSupplierList()
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.dataGridView1.Enabled = True
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem72_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem72.Click

        Dim f As New frmTIC_PCV_REIMBURSEMENT
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
        f.txtREFERENCE.Text = Now.ToString("yyyyMMddHHmmss")
        f.LoadSupplierList()
        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False
        f.dataGridView1.Enabled = True
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem76_Click(sender As Object, e As EventArgs)

        Dim f As New frm8SI_PCV_REIMBURSEMENT_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()


    End Sub


    Private Sub PETTYCASHREIMBURSEMENTToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles PETTYCASHREIMBURSEMENTToolStripMenuItem2.Click

        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_PCV_REIMBURSEMENT_FINAL
            f.MdiParent = Me
            f.LoadREIMList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem77_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem77.Click

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_PCV_REIMBURSEMENT_FINANCE
            f.MdiParent = Me
            f.LoadREIMList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem78_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem78.Click

        Dim f As New frm8SI_PCV_REIMBURSEMENT_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem79_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem79.Click

        Dim f As New frm8SI_PCV_REIMBURSEMENT_RETURN
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadREIMList()
        f.LoadSupplierList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem76_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem76.Click

        Dim f As New frmTIC_PCV_REIMBURSEMENT_RETURN
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadREIMList()
        f.LoadSupplierList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub


    Private Sub PETTYCASHREIMBURSEMENTToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles PETTYCASHREIMBURSEMENTToolStripMenuItem3.Click

        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_PCV_REIMBURSEMENT_FINAL
            f.MdiParent = Me
            f.LoadREIMList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem73_Click(sender As Object, e As EventArgs)

        Dim f As New frmTIC_PCV_REIMBURSEMENT_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub


    Private Sub THEICONCLINICToolStripMenuItem75_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem75.Click

        Dim f As New frmTIC_PCV_REIMBURSEMENT_RECORD
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem74_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem74.Click

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_PCV_REIMBURSEMENT_FINANCE
            f.MdiParent = Me
            f.LoadREIMList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Button1.Enabled = False
            f.Button2.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

    End Sub


    Private Sub SONAKAINCToolStripMenuItem80_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem80.Click

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_CHECKVOUCHER_RELEASING
            f.MdiParent = Me
            f.LoadCVList()
            f.Add_Approval_Button()
            f.btnPRINT.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub


    Private Sub THEICONCLINICToolStripMenuItem77_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem77.Click

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then
            Dim f As New frmTIC_CHECKVOUCHER_RELEASING
            f.MdiParent = Me
            f.LoadCVList()
            f.Add_Approval_Button()
            f.btnPRINT.Enabled = False
            f.Show()
        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If


    End Sub


    Private Sub SONAKAINCToolStripMenuItem81_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem81.Click

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then
            Dim f As New frm8SI_PCV_REIMBURSEMENT_RELEASE
            f.MdiParent = Me
            f.LoadREIMList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Show()


        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem78_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem78.Click


        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_PCV_REIMBURSEMENT_RELEASE
            f.MdiParent = Me
            f.LoadREIMList()
            f.Add_Approval_Button()
            f.btnSAVE.Enabled = False
            f.Show()


        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

    End Sub

    Private Sub DISBURSEMENTVOUCHERToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DISBURSEMENTVOUCHERToolStripMenuItem1.Click

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Exit Sub

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")
            Return

        End If

    End Sub

    Private Sub txtHOMECLASS_TextChanged(sender As Object, e As EventArgs) Handles txtHOMECLASS.TextChanged

        If txtHOMECLASS.Text = "EXECOM" Then

            ApprovalPanel.Visible = True

        ElseIf txtHOMECLASS.Text = "MANAGER" Then

            ApprovalPanel.Visible = True

        End If

    End Sub

    '=================== MANAGER =====================================

    Sub loadMANAGERCOUNT_REQUEST_8SI()

        txtREQUEST_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(manager_approval) from tbl_8si_requestslip where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `manager_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtREQUEST_8SI.Text = String.Format("{0}", count)

            sum = txtREQUEST_8SI.Text
            txtREQUEST_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadMANAGERCOUNT_REQUEST_TIC()

        txtREQUEST_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(manager_approval) from tbl_tic_requestslip where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `manager_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtREQUEST_TIC.Text = String.Format("{0}", count)

            sum = txtREQUEST_TIC.Text
            txtREQUEST_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadMANAGERCOUNT_CASHADVANCE_8SI()

        txtCASHADVANCE_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(endorsed_approval) from tbl_8si_cashadvance where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `endorsed_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCASHADVANCE_8SI.Text = String.Format("{0}", count)

            sum = txtCASHADVANCE_8SI.Text
            txtCASHADVANCE_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadMANAGERCOUNT_CASHADVANCE_TIC()

        txtCASHADVANCE_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(endorsed_approval) from tbl_tic_cashadvance where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `endorsed_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCASHADVANCE_TIC.Text = String.Format("{0}", count)

            sum = txtCASHADVANCE_TIC.Text
            txtCASHADVANCE_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadMANAGERCOUNT_CALIQIUDATION_8SI()

        txtCALIQUIDATION_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(endorsed_approval) from tbl_8si_cashadvance_liquidation where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `endorsed_approval` = 'FOR APPROVAL' AND `status` = 'ON-GOING LIQUIDATION'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCALIQUIDATION_8SI.Text = String.Format("{0}", count)

            sum = txtCALIQUIDATION_8SI.Text
            txtCALIQUIDATION_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadMANAGERCOUNT_CALIQIUDATION_TIC()

        txtCALIQUIDATION_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(endorsed_approval) from tbl_tic_cashadvance_liquidation where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `endorsed_approval` = 'FOR APPROVAL' AND `status` = 'ON-GOING LIQUIDATION'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCALIQUIDATION_TIC.Text = String.Format("{0}", count)

            sum = txtCALIQUIDATION_TIC.Text
            txtCALIQUIDATION_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadMANAGERCOUNT_REIMBURSEMENT_8SI()

        txtREIMBURSEMENT_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(endorsed_approval) from tbl_8si_reimbursement where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `endorsed_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtREIMBURSEMENT_8SI.Text = String.Format("{0}", count)

            sum = txtREIMBURSEMENT_8SI.Text
            txtREIMBURSEMENT_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadMANAGERCOUNT_REIMBURSEMENT_TIC()

        txtREIMBURSEMENT_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(endorsed_approval) from tbl_tic_reimbursement where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `endorsed_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtREIMBURSEMENT_TIC.Text = String.Format("{0}", count)

            sum = txtREIMBURSEMENT_TIC.Text
            txtREIMBURSEMENT_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadMANAGERCOUNT_RFREPLENISHMENT_8SI()

        txtRFREPLENISHMENT_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(endorsed_approval) from tbl_8si_rf_replenishment where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `endorsed_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtRFREPLENISHMENT_8SI.Text = String.Format("{0}", count)

            sum = txtRFREPLENISHMENT_8SI.Text
            txtRFREPLENISHMENT_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadMANAGERCOUNT_RFREPLENISHMENT_TIC()

        txtRFREPLENISHMENT_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(endorsed_approval) from tbl_tic_rf_replenishment where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `endorsed_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtRFREPLENISHMENT_TIC.Text = String.Format("{0}", count)

            sum = txtRFREPLENISHMENT_TIC.Text
            txtRFREPLENISHMENT_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadMANAGERCOUNT_PAYMENTREQUEST_8SI()

        txtPAYMENTREQUEST_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(manager_approval) from tbl_8si_paymentrequest where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `manager_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtPAYMENTREQUEST_8SI.Text = String.Format("{0}", count)

            sum = txtPAYMENTREQUEST_8SI.Text
            txtPAYMENTREQUEST_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadMANAGERCOUNT_PAYMENTREQUEST_TIC()

        txtPAYMENTREQUEST_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(manager_approval) from tbl_tic_paymentrequest where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `manager_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtPAYMENTREQUEST_TIC.Text = String.Format("{0}", count)

            sum = txtPAYMENTREQUEST_TIC.Text
            txtPAYMENTREQUEST_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadMANAGERCOUNT_PR_8SI()

        txtPURCHASEDREQUEST_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(MANAGER_APPROVAL) from tbl_8si_purchasedrequest where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `MANAGER_APPROVAL` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtPURCHASEDREQUEST_8SI.Text = String.Format("{0}", count)

            sum = txtPURCHASEDREQUEST_8SI.Text
            txtPURCHASEDREQUEST_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadMANAGERCOUNT_PR_TIC()

        txtPURCHASEDREQUEST_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(MANAGER_APPROVAL) from tbl_tic_purchasedrequest where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `MANAGER_APPROVAL` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtPURCHASEDREQUEST_TIC.Text = String.Format("{0}", count)

            sum = txtPURCHASEDREQUEST_TIC.Text
            txtPURCHASEDREQUEST_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadMANAGERCOUNT_PO_8SI()

        txtPURCHASEDORDER_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(MANAGER_APPROVAL) from tbl_8si_purchasedorder where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `MANAGER_APPROVAL` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtPURCHASEDORDER_8SI.Text = String.Format("{0}", count)

            sum = txtPURCHASEDORDER_8SI.Text
            txtPURCHASEDORDER_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadMANAGERCOUNT_PO_TIC()

        txtPURCHASEDORDER_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(MANAGER_APPROVAL) from tbl_tic_purchasedorder where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `MANAGER_APPROVAL` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtPURCHASEDORDER_TIC.Text = String.Format("{0}", count)

            sum = txtPURCHASEDORDER_TIC.Text
            txtPURCHASEDORDER_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadMANAGERCOUNT_CV_8SI()

        txtCHECKVOUCHER_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(manager_approval) from tbl_8si_checkvoucher where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `manager_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCHECKVOUCHER_8SI.Text = String.Format("{0}", count)

            sum = txtCHECKVOUCHER_8SI.Text
            txtCHECKVOUCHER_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadMANAGERCOUNT_CV_TIC()

        txtCHECKVOUCHER_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(manager_approval) from tbl_tic_checkvoucher where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `manager_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCHECKVOUCHER_TIC.Text = String.Format("{0}", count)

            sum = txtCHECKVOUCHER_TIC.Text
            txtCHECKVOUCHER_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If txtPOSITION.Text = "GENERAL MANAGER" Then

            ApprovalPanel.Visible = True

            loadGENERALMANAGERCOUNT_REQUEST_8SI()
            loadGENERALMANAGERCOUNT_REQUEST_TIC()
            loadGENERALMANAGERCOUNT_CASHADVANCE_8SI()
            loadGENERALMANAGERCOUNT_CASHADVANCE_TIC()
            loadGENERALMANAGERCOUNT_CALIQIUDATION_8SI()
            loadGENERALMANAGERCOUNT_CALIQIUDATION_TIC()
            loadGENERALMANAGERCOUNT_REIMBURSEMENT_8SI()
            loadGENERALMANAGERCOUNT_REIMBURSEMENT_TIC()
            loadGENERALMANAGERCOUNT_RFREPLENISHMENT_8SI()
            loadGENERALMANAGERCOUNT_RFREPLENISHMENT_TIC()
            loadGENERALMANAGERCOUNT_PAYMENTREQUEST_8SI()
            loadGENERALMANAGERCOUNT_PAYMENTREQUEST_TIC()
            loadGENERALMANAGERCOUNT_PR_8SI()
            loadGENERALMANAGERCOUNT_PR_TIC()
            loadGENERALMANAGERCOUNT_CV_8SI()
            loadGENERALMANAGERCOUNT_CV_TIC()

        ElseIf txtPOSITION.Text = "CHIEF OPERATING OFFICER" Then

            ApprovalPanel.Visible = True

            loadCOOCOUNT_CASHADVANCE_8SI()
            loadCOOCOUNT_CASHADVANCE_TIC()
            loadCOOCOUNT_CALIQIUDATION_8SI()
            loadCOOCOUNT_CALIQIUDATION_TIC()
            loadCOOCOUNT_REIMBURSEMENT_8SI()
            loadCOOCOUNT_REIMBURSEMENT_TIC()
            loadCOOCOUNT_RFREPLENISHMENT_8SI()
            loadCOOCOUNT_RFREPLENISHMENT_TIC()
            loadCOOCOUNT_PAYMENTREQUEST_8SI()
            loadCOOCOUNT_PAYMENTREQUEST_TIC()
            loadCOOCOUNT_PR_8SI()
            loadCOOCOUNT_PR_TIC()
            loadCOOCOUNT_CV_8SI()
            loadCOOCOUNT_CV_TIC()

        ElseIf txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" And txtHOMECLASS.Text = "MANAGER" Then

            ApprovalPanel.Visible = True

            loadFINANCECOUNT_REQUEST_8SI()
            loadFINANCECOUNT_REQUEST_TIC()
            loadFINANCECOUNT_CASHADVANCE_8SI()
            loadFINANCECOUNT_CASHADVANCE_TIC()
            loadFINANCECOUNT_CALIQIUDATION_8SI()
            loadFINANCECOUNT_CALIQIUDATION_TIC()
            loadFINANCECOUNT_REIMBURSEMENT_8SI()
            loadFINANCECOUNT_REIMBURSEMENT_TIC()
            loadFINANCECOUNT_RFREPLENISHMENT_8SI()
            loadFINANCECOUNT_RFREPLENISHMENT_TIC()
            loadFINANCECOUNT_PAYMENTREQUEST_8SI()
            loadFINANCECOUNT_PAYMENTREQUEST_TIC()
            loadFINANCECOUNT_CV_8SI()
            loadFINANCECOUNT_CV_TIC()

        ElseIf txtHOMECLASS.Text = "MANAGER" Then

            ApprovalPanel.Visible = True

            loadMANAGERCOUNT_REQUEST_8SI()
            loadMANAGERCOUNT_REQUEST_TIC()

            loadMANAGERCOUNT_CASHADVANCE_8SI()
            loadMANAGERCOUNT_CASHADVANCE_TIC()

            loadMANAGERCOUNT_CALIQIUDATION_8SI()
            loadMANAGERCOUNT_CALIQIUDATION_TIC()

            loadMANAGERCOUNT_REIMBURSEMENT_8SI()
            loadMANAGERCOUNT_REIMBURSEMENT_TIC()

            loadMANAGERCOUNT_RFREPLENISHMENT_8SI()
            loadMANAGERCOUNT_RFREPLENISHMENT_TIC()

            loadMANAGERCOUNT_PAYMENTREQUEST_8SI()
            loadMANAGERCOUNT_PAYMENTREQUEST_TIC()

            loadMANAGERCOUNT_PR_8SI()
            loadMANAGERCOUNT_PR_TIC()

            loadMANAGERCOUNT_PO_8SI()
            loadMANAGERCOUNT_PO_TIC()

            loadMANAGERCOUNT_CV_8SI()
            loadMANAGERCOUNT_CV_TIC()

        End If

        MsgBox("Successfully Refresh!", vbInformation + vbOKOnly, "CONFIRMATION")

    End Sub

    '=================== FINANCE =====================================

    Sub loadFINANCECOUNT_REQUEST_8SI()

        txtREQUEST_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(manager_approval) from tbl_8si_requestslip where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `manager_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtREQUEST_8SI.Text = String.Format("{0}", count)

            sum = txtREQUEST_8SI.Text
            txtREQUEST_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadFINANCECOUNT_REQUEST_TIC()

        txtREQUEST_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(manager_approval) from tbl_tic_requestslip where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `manager_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtREQUEST_TIC.Text = String.Format("{0}", count)

            sum = txtREQUEST_TIC.Text
            txtREQUEST_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadFINANCECOUNT_CASHADVANCE_8SI()

        txtCASHADVANCE_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(finance_approval) from tbl_8si_cashadvance where `endorsed_approval` = 'APPROVED' and `finance_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCASHADVANCE_8SI.Text = String.Format("{0}", count)

            sum = txtCASHADVANCE_8SI.Text
            txtCASHADVANCE_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadFINANCECOUNT_CASHADVANCE_TIC()

        txtCASHADVANCE_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(finance_approval) from tbl_tic_cashadvance where `endorsed_approval` = 'APPROVED' and `finance_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCASHADVANCE_TIC.Text = String.Format("{0}", count)

            sum = txtCASHADVANCE_TIC.Text
            txtCASHADVANCE_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadFINANCECOUNT_CALIQIUDATION_8SI()

        txtCALIQUIDATION_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(finance_approval) from tbl_8si_cashadvance_liquidation where `endorsed_approval` = 'APPROVED' and `finance_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCALIQUIDATION_8SI.Text = String.Format("{0}", count)

            sum = txtCALIQUIDATION_8SI.Text
            txtCALIQUIDATION_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadFINANCECOUNT_CALIQIUDATION_TIC()

        txtCALIQUIDATION_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(finance_approval) from tbl_tic_cashadvance_liquidation where `endorsed_approval` = 'APPROVED' and `finance_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCALIQUIDATION_TIC.Text = String.Format("{0}", count)

            sum = txtCALIQUIDATION_TIC.Text
            txtCALIQUIDATION_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadFINANCECOUNT_REIMBURSEMENT_8SI()

        txtREIMBURSEMENT_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(finance_approval) from tbl_8si_reimbursement where `endorsed_approval` = 'APPROVED' and `finance_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtREIMBURSEMENT_8SI.Text = String.Format("{0}", count)

            sum = txtREIMBURSEMENT_8SI.Text
            txtREIMBURSEMENT_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadFINANCECOUNT_REIMBURSEMENT_TIC()

        txtREIMBURSEMENT_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(finance_approval) from tbl_tic_reimbursement where `endorsed_approval` = 'APPROVED' and `finance_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtREIMBURSEMENT_TIC.Text = String.Format("{0}", count)

            sum = txtREIMBURSEMENT_TIC.Text
            txtREIMBURSEMENT_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadFINANCECOUNT_RFREPLENISHMENT_8SI()

        txtRFREPLENISHMENT_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(finance_approval) from tbl_8si_rf_replenishment where `endorsed_approval` = 'APPROVED' AND `finance_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtRFREPLENISHMENT_8SI.Text = String.Format("{0}", count)

            sum = txtRFREPLENISHMENT_8SI.Text
            txtRFREPLENISHMENT_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadFINANCECOUNT_RFREPLENISHMENT_TIC()

        txtRFREPLENISHMENT_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(finance_approval) from tbl_tic_rf_replenishment where `endorsed_approval` = 'APPROVED' AND `finance_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtRFREPLENISHMENT_TIC.Text = String.Format("{0}", count)

            sum = txtRFREPLENISHMENT_TIC.Text
            txtRFREPLENISHMENT_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadFINANCECOUNT_PAYMENTREQUEST_8SI()

        txtPAYMENTREQUEST_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(finance_approval) from tbl_8si_paymentrequest where `manager_approval` = 'APPROVED' AND `finance_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtPAYMENTREQUEST_8SI.Text = String.Format("{0}", count)

            sum = txtPAYMENTREQUEST_8SI.Text
            txtPAYMENTREQUEST_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadFINANCECOUNT_PAYMENTREQUEST_TIC()

        txtPAYMENTREQUEST_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(finance_approval) from tbl_tic_paymentrequest where `manager_approval` = 'APPROVED' AND `finance_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtPAYMENTREQUEST_TIC.Text = String.Format("{0}", count)

            sum = txtPAYMENTREQUEST_TIC.Text
            txtPAYMENTREQUEST_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadFINANCECOUNT_CV_8SI()

        txtCHECKVOUCHER_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(manager_approval) from tbl_8si_checkvoucher where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `manager_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCHECKVOUCHER_8SI.Text = String.Format("{0}", count)

            sum = txtCHECKVOUCHER_8SI.Text
            txtCHECKVOUCHER_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadFINANCECOUNT_CV_TIC()

        txtCHECKVOUCHER_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(manager_approval) from tbl_tic_checkvoucher where `department` like '%" & txtHOMEDEPARTMENT.Text & "%' and `manager_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCHECKVOUCHER_TIC.Text = String.Format("{0}", count)

            sum = txtCHECKVOUCHER_TIC.Text
            txtCHECKVOUCHER_TIC.Text = Format(sum, "00")

        End Using

        cn.Close()

    End Sub

    '=================== GENERAL MANAGER =====================================

    Sub loadGENERALMANAGERCOUNT_REQUEST_8SI()

        txtREQUEST_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(gm_approval) from tbl_8si_requestslip where `manager_approval` = 'APPROVED' AND `gm_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtREQUEST_8SI.Text = String.Format("{0}", count)

            sum = txtREQUEST_8SI.Text
            txtREQUEST_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadGENERALMANAGERCOUNT_REQUEST_TIC()

        txtREQUEST_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(gm_approval) from tbl_tic_requestslip where `manager_approval` = 'APPROVED' AND `gm_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtREQUEST_TIC.Text = String.Format("{0}", count)

            sum = txtREQUEST_TIC.Text
            txtREQUEST_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadGENERALMANAGERCOUNT_CASHADVANCE_8SI()

        txtCASHADVANCE_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(final_approval) from tbl_8si_cashadvance where `finance_approval` = 'APPROVED' AND `final_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCASHADVANCE_8SI.Text = String.Format("{0}", count)

            sum = txtCASHADVANCE_8SI.Text
            txtCASHADVANCE_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadGENERALMANAGERCOUNT_CASHADVANCE_TIC()

        txtCASHADVANCE_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(final_approval) from tbl_tic_cashadvance where `finance_approval` = 'APPROVED' AND `final_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCASHADVANCE_TIC.Text = String.Format("{0}", count)

            sum = txtCASHADVANCE_TIC.Text
            txtCASHADVANCE_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadGENERALMANAGERCOUNT_CALIQIUDATION_8SI()

        txtCALIQUIDATION_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(final_approval) from tbl_8si_cashadvance_liquidation where `finance_approval` = 'APPROVED' AND `final_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCALIQUIDATION_8SI.Text = String.Format("{0}", count)

            sum = txtCALIQUIDATION_8SI.Text
            txtCALIQUIDATION_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadGENERALMANAGERCOUNT_CALIQIUDATION_TIC()

        txtCALIQUIDATION_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(final_approval) from tbl_tic_cashadvance_liquidation where `finance_approval` = 'APPROVED' AND `final_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCALIQUIDATION_TIC.Text = String.Format("{0}", count)

            sum = txtCALIQUIDATION_TIC.Text
            txtCALIQUIDATION_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadGENERALMANAGERCOUNT_REIMBURSEMENT_8SI()

        txtREIMBURSEMENT_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(final_approval) from tbl_8si_reimbursement where `finance_approval` = 'APPROVED' AND `final_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtREIMBURSEMENT_8SI.Text = String.Format("{0}", count)

            sum = txtREIMBURSEMENT_8SI.Text
            txtREIMBURSEMENT_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadGENERALMANAGERCOUNT_REIMBURSEMENT_TIC()

        txtREIMBURSEMENT_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(final_approval) from tbl_tic_reimbursement where `finance_approval` = 'APPROVED' AND `final_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtREIMBURSEMENT_TIC.Text = String.Format("{0}", count)

            sum = txtREIMBURSEMENT_TIC.Text
            txtREIMBURSEMENT_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadGENERALMANAGERCOUNT_RFREPLENISHMENT_8SI()

        txtRFREPLENISHMENT_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(final_approval) from tbl_8si_rf_replenishment where `finance_approval` = 'APPROVED' AND `final_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtRFREPLENISHMENT_8SI.Text = String.Format("{0}", count)

            sum = txtRFREPLENISHMENT_8SI.Text
            txtRFREPLENISHMENT_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadGENERALMANAGERCOUNT_RFREPLENISHMENT_TIC()

        txtRFREPLENISHMENT_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(final_approval) from tbl_tic_rf_replenishment where `finance_approval` = 'APPROVED' AND `final_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtRFREPLENISHMENT_TIC.Text = String.Format("{0}", count)

            sum = txtRFREPLENISHMENT_TIC.Text
            txtRFREPLENISHMENT_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadGENERALMANAGERCOUNT_PAYMENTREQUEST_8SI()

        txtPAYMENTREQUEST_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(gm_approval) from tbl_8si_paymentrequest where `finance_approval` = 'APPROVED' AND `gm_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtPAYMENTREQUEST_8SI.Text = String.Format("{0}", count)

            sum = txtPAYMENTREQUEST_8SI.Text
            txtPAYMENTREQUEST_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadGENERALMANAGERCOUNT_PAYMENTREQUEST_TIC()

        txtPAYMENTREQUEST_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(gm_approval) from tbl_tic_paymentrequest where `finance_approval` = 'APPROVED' AND `gm_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtPAYMENTREQUEST_TIC.Text = String.Format("{0}", count)

            sum = txtPAYMENTREQUEST_TIC.Text
            txtPAYMENTREQUEST_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadGENERALMANAGERCOUNT_PR_8SI()

        txtPURCHASEDREQUEST_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(GM_APPROVAL) from tbl_8si_purchasedrequest where `MANAGER_APPROVAL` = 'APPROVED' AND `GM_APPROVAL` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtPURCHASEDREQUEST_8SI.Text = String.Format("{0}", count)

            sum = txtPURCHASEDREQUEST_8SI.Text
            txtPURCHASEDREQUEST_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadGENERALMANAGERCOUNT_PR_TIC()

        txtPURCHASEDREQUEST_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(GM_APPROVAL) from tbl_tic_purchasedrequest where `MANAGER_APPROVAL` = 'APPROVED' AND `GM_APPROVAL` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtPURCHASEDREQUEST_TIC.Text = String.Format("{0}", count)

            sum = txtPURCHASEDREQUEST_TIC.Text
            txtPURCHASEDREQUEST_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadGENERALMANAGERCOUNT_CV_8SI()

        txtCHECKVOUCHER_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(gm_approval) from tbl_8si_checkvoucher where `manager_approval` = 'APPROVED' AND `gm_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCHECKVOUCHER_8SI.Text = String.Format("{0}", count)

            sum = txtCHECKVOUCHER_8SI.Text
            txtCHECKVOUCHER_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadGENERALMANAGERCOUNT_CV_TIC()

        txtCHECKVOUCHER_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(gm_approval) from tbl_tic_checkvoucher where `manager_approval` = 'APPROVED' AND `gm_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCHECKVOUCHER_TIC.Text = String.Format("{0}", count)

            sum = txtCHECKVOUCHER_TIC.Text
            txtCHECKVOUCHER_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    '=================== COO =====================================

    Sub loadCOOCOUNT_CASHADVANCE_8SI()

        txtCASHADVANCE_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(final_approval) from tbl_8si_cashadvance where `finance_approval` = 'APPROVED' AND `final_approval` = 'APPROVED' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCASHADVANCE_8SI.Text = String.Format("{0}", count)

            sum = txtCASHADVANCE_8SI.Text
            txtCASHADVANCE_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadCOOCOUNT_CASHADVANCE_TIC()

        txtCASHADVANCE_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(final_approval) from tbl_tic_cashadvance where `finance_approval` = 'APPROVED' AND `final_approval` = 'APPROVED' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCASHADVANCE_TIC.Text = String.Format("{0}", count)

            sum = txtCASHADVANCE_TIC.Text
            txtCASHADVANCE_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadCOOCOUNT_CALIQIUDATION_8SI()

        txtCALIQUIDATION_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(final_approval) from tbl_8si_cashadvance_liquidation where `finance_approval` = 'APPROVED' AND `final_approval` = 'APPROVED' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCALIQUIDATION_8SI.Text = String.Format("{0}", count)

            sum = txtCALIQUIDATION_8SI.Text
            txtCALIQUIDATION_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadCOOCOUNT_CALIQIUDATION_TIC()

        txtCALIQUIDATION_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(final_approval) from tbl_tic_cashadvance_liquidation where `finance_approval` = 'APPROVED' AND `final_approval` = 'APPROVED' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCALIQUIDATION_TIC.Text = String.Format("{0}", count)

            sum = txtCALIQUIDATION_TIC.Text
            txtCALIQUIDATION_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadCOOCOUNT_REIMBURSEMENT_8SI()

        txtREIMBURSEMENT_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(final_approval) from tbl_8si_reimbursement where `finance_approval` = 'APPROVED' AND `final_approval` = 'APPROVED' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtREIMBURSEMENT_8SI.Text = String.Format("{0}", count)

            sum = txtREIMBURSEMENT_8SI.Text
            txtREIMBURSEMENT_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadCOOCOUNT_REIMBURSEMENT_TIC()

        txtREIMBURSEMENT_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(final_approval) from tbl_tic_reimbursement where `finance_approval` = 'APPROVED' AND `final_approval` = 'APPROVED' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtREIMBURSEMENT_TIC.Text = String.Format("{0}", count)

            sum = txtREIMBURSEMENT_TIC.Text
            txtREIMBURSEMENT_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadCOOCOUNT_RFREPLENISHMENT_8SI()

        txtRFREPLENISHMENT_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(final_approval) from tbl_8si_rf_replenishment where `finance_approval` = 'APPROVED' AND `final_approval` = 'APPROVED' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtRFREPLENISHMENT_8SI.Text = String.Format("{0}", count)

            sum = txtRFREPLENISHMENT_8SI.Text
            txtRFREPLENISHMENT_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadCOOCOUNT_RFREPLENISHMENT_TIC()

        txtRFREPLENISHMENT_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(final_approval) from tbl_tic_rf_replenishment where `finance_approval` = 'APPROVED' AND `final_approval` = 'APPROVED' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtRFREPLENISHMENT_TIC.Text = String.Format("{0}", count)

            sum = txtRFREPLENISHMENT_TIC.Text
            txtRFREPLENISHMENT_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadCOOCOUNT_PAYMENTREQUEST_8SI()

        txtPAYMENTREQUEST_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(coo_approval) from tbl_8si_paymentrequest where `gm_approval` = 'APPROVED' AND `coo_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtPAYMENTREQUEST_8SI.Text = String.Format("{0}", count)

            sum = txtPAYMENTREQUEST_8SI.Text
            txtPAYMENTREQUEST_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadCOOCOUNT_PAYMENTREQUEST_TIC()

        txtPAYMENTREQUEST_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(coo_approval) from tbl_tic_paymentrequest where `gm_approval` = 'APPROVED' AND `coo_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtPAYMENTREQUEST_TIC.Text = String.Format("{0}", count)

            sum = txtPAYMENTREQUEST_TIC.Text
            txtPAYMENTREQUEST_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadCOOCOUNT_PR_8SI()

        txtPURCHASEDREQUEST_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(COO_APPROVAL) from tbl_8si_purchasedrequest where `GM_APPROVAL` = 'APPROVED' AND `COO_APPROVAL` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtPURCHASEDREQUEST_8SI.Text = String.Format("{0}", count)

            sum = txtPURCHASEDREQUEST_8SI.Text
            txtPURCHASEDREQUEST_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadCOOCOUNT_PR_TIC()

        txtPURCHASEDREQUEST_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(COO_APPROVAL) from tbl_tic_purchasedrequest where `GM_APPROVAL` = 'APPROVED' AND `COO_APPROVAL` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtPURCHASEDREQUEST_TIC.Text = String.Format("{0}", count)

            sum = txtPURCHASEDREQUEST_TIC.Text
            txtPURCHASEDREQUEST_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadCOOCOUNT_CV_8SI()

        txtCHECKVOUCHER_8SI.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(coo_approval) from tbl_8si_checkvoucher where `gm_approval` = 'APPROVED' AND `coo_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCHECKVOUCHER_8SI.Text = String.Format("{0}", count)

            sum = txtCHECKVOUCHER_8SI.Text
            txtCHECKVOUCHER_8SI.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub

    Sub loadCOOCOUNT_CV_TIC()

        txtCHECKVOUCHER_TIC.Clear()

        cn.Open()

        Using cm = New MySqlCommand("select count(coo_approval) from tbl_tic_checkvoucher where `gm_approval` = 'APPROVED' AND `coo_approval` = 'FOR APPROVAL' AND `status` = 'ACTIVE'", cn)

            Dim count As Int32 = CType(cm.ExecuteScalar(), Int32)
            Dim sum As Double

            txtCHECKVOUCHER_TIC.Text = String.Format("{0}", count)

            sum = txtCHECKVOUCHER_TIC.Text
            txtCHECKVOUCHER_TIC.Text = Format(sum, "00")

        End Using
        cn.Close()

    End Sub


    Private Sub SONAKAINCToolStripMenuItem82_Click(sender As Object, e As EventArgs)

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_CHECKVOUCHER_FUNDTRANSFER
            f.MdiParent = Me
            f.txtTRANSACTION.Text = Now.ToString("yyyy") & "_PAYRE_" & Now.ToString("HHmmss")
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
            f.LoadAccountTitle()
            f.LoadSupplierList()
            f.LoadBankAccount()
            f.btnPRINT.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub ENTRYFORMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ENTRYFORMToolStripMenuItem.Click

        If txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmWAREHOUSE_USER
            f.MdiParent = Me
            f.SHOW_NAME()
            f.SHOW_WAREHOUSE()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub


    Private Sub ENTRYLISTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ENTRYLISTToolStripMenuItem.Click

        If txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmWAREHOUSE_USER_UPDATE
            f.MdiParent = Me
            f.LoadUSERList()
            f.SHOW_WAREHOUSE()
            f.SHOW_NAME()
            f.btnUPDATE.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem83_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem83.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmWAREHOUSE_LOCATION_8SI
            f.MdiParent = Me
            f.LoadPO()
            f.btnSAVE.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem80_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem80.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmWAREHOUSE_LOCATION_TIC
            f.MdiParent = Me
            f.LoadPO()
            f.btnSAVE.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub SONAKAINCToolStripMenuItem84_Click(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem84.Click

        Dim f As New frmWAREHOUSE_RR_PO_8SI
        f.MdiParent = Me
        f.LoadPOList()
        f.Add_Approval_Button()

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text
        f.txtNAME.Text = txtHOMENAME.Text

        f.Show()

    End Sub


    Private Sub THEICONCLINICToolStripMenuItem81_Click(sender As Object, e As EventArgs) Handles THEICONCLINICToolStripMenuItem81.Click

        Dim f As New frmWAREHOUSE_RR_PO_TIC
        f.MdiParent = Me
        f.LoadPOList()
        f.Add_Approval_Button()

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text
        f.txtNAME.Text = txtHOMENAME.Text

        f.Show()


    End Sub

    Private Sub RECEIVINGREPORTToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RECEIVINGREPORTToolStripMenuItem1.Click

        Dim f As New frmWAREHOUSE_RR_SUPERVISOR
        f.MdiParent = Me
        f.LoadRRList()
        f.Add_Approval_Button()

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text
        f.txtNAME.Text = txtHOMENAME.Text

        f.Show()

    End Sub

    Private Sub DELIVERYRECEIPTToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles DELIVERYRECEIPTToolStripMenuItem2.Click

        Dim f As New frmWAREHOUSE_RR_MANAGER
        f.MdiParent = Me
        f.LoadRRList()
        f.Add_Approval_Button()

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text
        f.txtNAME.Text = txtHOMENAME.Text

        f.Show()

    End Sub

    Private Sub DELIVERYRECEIPTToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles DELIVERYRECEIPTToolStripMenuItem3.Click

        Dim f As New frmWAREHOUSE_DR_MANAGER
        f.MdiParent = Me
        f.LoadDRList()
        f.Add_Approval_Button()

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text
        f.txtNAME.Text = txtHOMENAME.Text

        f.Show()

    End Sub

    Private Sub DELIVERYRECEIPTToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles DELIVERYRECEIPTToolStripMenuItem4.Click

        Dim f As New frmWAREHOUSE_DR_SUPERVISOR
        f.MdiParent = Me
        f.LoadDRList()
        f.Add_Approval_Button()

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text
        f.txtNAME.Text = txtHOMENAME.Text

        f.Show()

    End Sub



    Private Sub MATERIALISSUANCEToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles MATERIALISSUANCEToolStripMenuItem2.Click

        Dim f As New frmWAREHOUSE_DR_MIR
        f.MdiParent = Me
        f.LoadList()
        f.Add_Approval_Button()

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text
        f.txtNAME.Text = txtHOMENAME.Text

        f.Show()

    End Sub

    Private Sub STOCKREPLENISHMENTToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles STOCKREPLENISHMENTToolStripMenuItem6.Click

        Dim f As New frmWAREHOUSE_DR_SR
        f.MdiParent = Me
        f.LoadList()
        f.Add_Approval_Button()

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text
        f.txtNAME.Text = txtHOMENAME.Text

        f.Show()

    End Sub

    Private Sub DISPATCHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DISPATCHToolStripMenuItem.Click

        Dim f As New frmWAREHOUSE_DR_DISPATCH
        f.MdiParent = Me
        f.LoadDRList()
        f.Add_Approval_Button()

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text
        f.txtNAME.Text = txtHOMENAME.Text

        f.Show()

    End Sub


    Private Sub STOCKREPLENISHMENTToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles STOCKREPLENISHMENTToolStripMenuItem3.Click

        Dim f As New frmWAREHOUSE_RR_SR
        f.MdiParent = Me
        f.Show()

    End Sub

    Private Sub THEICONCLINICToolStripMenuItem79_Click(sender As Object, e As EventArgs)

        If txtHOMEDEPARTMENT.Text = "FINANCE DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmTIC_CHECKVOUCHER_FUNDTRANSFER
            f.MdiParent = Me
            f.txtTRANSACTION.Text = Now.ToString("yyyy") & "_PAYRE_" & Now.ToString("HHmmss")
            f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
            f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
            f.txtDEPCODE.Text = Me.txtHOMEDEPCODE.Text
            f.LoadAccountTitle()
            f.LoadSupplierList()
            f.LoadBankAccount()
            f.btnPRINT.Enabled = False
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub RECORDToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles RECORDToolStripMenuItem7.Click

        Dim f As New frmWAREHOUSE_RR_RECORD
        f.MdiParent = Me

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text
        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadRRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub



    Private Sub RETURNToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles RETURNToolStripMenuItem8.Click

        Dim f As New frmWAREHOUSE_RR_RETURN
        f.MdiParent = Me

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text
        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadRRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub INVENTORYPULLOUTToolStripMenuItem5_Click(sender As Object, e As EventArgs)

        Dim f As New frmWAREHOUSE_IPR_MANAGER
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub INVENTORYPULLOUTToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles INVENTORYPULLOUTToolStripMenuItem4.Click

        Dim f As New frmWAREHOUSE_IPR_MANAGER
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.Show()

    End Sub

    Private Sub INVENTORYPULLOUTToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles INVENTORYPULLOUTToolStripMenuItem6.Click

        Dim f As New frmWAREHOUSE_IPR_GM
        f.MdiParent = Me
        f.LoadIPRList()
        f.Add_Approval_Button()

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.Show()

    End Sub

    Private Sub INVENTORYPULLOUTToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles INVENTORYPULLOUTToolStripMenuItem7.Click

        Dim f As New frmWAREHOUSE_IPR_GM
        f.MdiParent = Me
        f.LoadIPRList()
        f.Add_Approval_Button()

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.Show()

    End Sub


    Private Sub RECORDToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles RECORDToolStripMenuItem8.Click

        Dim f As New frmWAREHOUSE_IPR_RECORD
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub



    Private Sub FORMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FORMToolStripMenuItem.Click

        Dim f As New frmWAREHOUSE_IPR
        f.MdiParent = Me

        f.txtREQUESTOR.Text = txtHOMENAME.Text
        f.txtDEPARTMENT.Text = txtHOMEDEPARTMENT.Text

        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")

        f.LoadClassification()
        f.LoadITEM()

        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False

        f.Show()

    End Sub

    Private Sub RETURNJToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RETURNJToolStripMenuItem.Click

        Dim f As New frmWAREHOUSE_IPR_RETURN
        f.MdiParent = Me

        f.txtREQUESTOR.Text = txtHOMENAME.Text
        f.txtDEPARTMENT.Text = txtHOMEDEPARTMENT.Text
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text

        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadClassification()
        f.LoadITEM()

        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub IPDESTINATIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IPDESTINATIONToolStripMenuItem.Click

        Dim f As New frmWAREHOUSE_IPR_DESTINATION
        f.MdiParent = Me

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub FORMENTRYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FORMENTRYToolStripMenuItem.Click

        Dim f As New frmWAREHOUSE_SRS
        f.MdiParent = Me

        f.txtREQUESTOR.Text = txtHOMENAME.Text
        f.txtDEPARTMENT.Text = txtHOMEDEPARTMENT.Text

        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")

        f.LoadITEM()

        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False

        f.Show()

    End Sub

    Private Sub SUPPLYREQUISITIONToolStripMenuItem3_Click_1(sender As Object, e As EventArgs)

        Dim f As New frmWAREHOUSE_SRS_MANAGER
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub STOCKREPLENISHMENTToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles STOCKREPLENISHMENTToolStripMenuItem7.Click

        Dim f As New frmWAREHOUSE_SRS_MANAGER
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub


    Private Sub SUPPLYREQUISITIONToolStripMenuItem4_Click(sender As Object, e As EventArgs)

        If txtPOSITION.Text = "MANAGER" And txtHOMEDEPARTMENT.Text = "HR DEPARTMENT" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmWAREHOUSE_SRS_HR
            f.MdiParent = Me

            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.txtPOSITION.Text = txtPOSITION.Text
            f.txtSHARED.Text = txtWAREHOUSESHARED.Text
            f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

            f.txtNAME.Text = txtHOMENAME.Text

            f.LoadIPRList()
            f.Add_Approval_Button()

            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub



    Private Sub SRSRELEASERToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Dim f As New frmWAREHOUSE_SRS_RELEASER
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub RECORDToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles RECORDToolStripMenuItem9.Click

        Dim f As New frmWAREHOUSE_SRS_RECORD
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub SRSRECEIVEToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Dim f As New frmWAREHOUSE_SRS_RECEIVER
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub RETURNToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles RETURNToolStripMenuItem9.Click

        Dim f As New frmWAREHOUSE_SRS_RETURN
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadITEM()

        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub FORENTRYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FORENTRYToolStripMenuItem.Click

        Dim f As New frmWAREHOUSE_MIR
        f.MdiParent = Me

        f.txtREQUESTOR.Text = txtHOMENAME.Text
        f.txtDEPARTMENT.Text = txtHOMEDEPARTMENT.Text

        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")

        f.LoadClassification()
        f.LoadITEM()

        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False

        f.Show()

    End Sub

    Private Sub MATERIALISSUANCEToolStripMenuItem5_Click(sender As Object, e As EventArgs)

        Dim f As New frmWAREHOUSE_MIR_MANAGER
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub MATERIALISSUANCEToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles MATERIALISSUANCEToolStripMenuItem4.Click

        Dim f As New frmWAREHOUSE_MIR_MANAGER
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub MATERIALISSUANCEToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles MATERIALISSUANCEToolStripMenuItem6.Click

        Dim f As New frmWAREHOUSE_MIR_FINAL
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub MATERIALISSUANCEToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles MATERIALISSUANCEToolStripMenuItem7.Click

        Dim f As New frmWAREHOUSE_MIR_FINAL
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub


    Private Sub RECORDToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles RECORDToolStripMenuItem10.Click

        Dim f As New frmWAREHOUSE_MIR_RECORD
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub RETURNToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles RETURNToolStripMenuItem10.Click

        Dim f As New frmWAREHOUSE_MIR_RETURN
        f.MdiParent = Me

        f.txtREQUESTOR.Text = txtHOMENAME.Text
        f.txtDEPARTMENT.Text = txtHOMEDEPARTMENT.Text

        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.LoadClassification()
        f.LoadITEM()

        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False

        f.Show()


    End Sub

    Private Sub FORENTRYToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FORENTRYToolStripMenuItem1.Click

        Dim f As New frmWAREHOUSE_SR
        f.MdiParent = Me

        f.txtREQUESTOR.Text = txtHOMENAME.Text
        f.txtDEPARTMENT.Text = txtHOMEDEPARTMENT.Text

        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text

        f.txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")

        f.LoadClassification()
        f.LoadITEM()

        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False

        f.Show()

    End Sub


    Private Sub STOCKREPLENISHMENTToolStripMenuItem8_Click(sender As Object, e As EventArgs)

        Dim f As New frmWAREHOUSE_SR_MANAGER
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub



    Private Sub STOCKREPLENISHMENTToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles STOCKREPLENISHMENTToolStripMenuItem9.Click

        Dim f As New frmWAREHOUSE_SR_GM
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub STOCKREPLENISHMENTToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles STOCKREPLENISHMENTToolStripMenuItem10.Click

        Dim f As New frmWAREHOUSE_SR_GM
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub RECORDToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles RECORDToolStripMenuItem11.Click

        Dim f As New frmWAREHOUSE_SR_RECORD
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub


    Private Sub INVENTORYLISTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INVENTORYLISTToolStripMenuItem.Click

        Dim f As New frmWAREHOUSE_INVENTORY_LIST
        f.MdiParent = Me
        f.LoadITEMList()
        f.LoadClassification()
        f.Show()

    End Sub

    Private Sub EXTRACTIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXTRACTIONToolStripMenuItem.Click

        Dim f As New frm2EXTRACTION
        f.MdiParent = Me
        f.Show()

    End Sub

    Private Sub SRDESTINATIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SRDESTINATIONToolStripMenuItem.Click

        Dim f As New frmWAREHOUSE_IPR_DESTINATION
        f.MdiParent = Me

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub


    Private Sub RETURNMATERIALISSUANCEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RETURNMATERIALISSUANCEToolStripMenuItem.Click

        Dim f As New frmWAREHOUSE_RR_MIR
        f.MdiParent = Me
        f.LoadIPRList()
        f.Add_Approval_Button()

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text
        f.txtNAME.Text = txtHOMENAME.Text

        f.Show()

    End Sub

    Private Sub WAREHOUSEREQUESTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WAREHOUSEREQUESTToolStripMenuItem.Click

        Dim f As New frmWAREHOUSE_SRS_WAREHOUSE
        f.MdiParent = Me

        f.txtREQUESTOR.Text = txtHOMENAME.Text
        f.txtDEPARTMENT.Text = txtHOMEDEPARTMENT.Text

        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtTRANSACTION.Text = Now.ToString("yyyyMMddHHmmss")

        f.LoadITEM()

        f.btnSAVE.Enabled = False
        f.btnPRINT.Enabled = False

        f.Show()

    End Sub


    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click

        Dim f As New frmWAREHOUSE_SRS_RELEASER
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click

        Dim f As New frmWAREHOUSE_SRS_RECEIVER
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub


    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click

        Dim f As New frmWAREHOUSE_SRS_HR
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub SUPPLYREQUISITIONToolStripMenuItem5_Click_1(sender As Object, e As EventArgs) Handles SUPPLYREQUISITIONToolStripMenuItem5.Click

        Dim f As New frmWAREHOUSE_DR_SRS
        f.MdiParent = Me
        f.LoadList()
        f.Add_Approval_Button()

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text
        f.txtNAME.Text = txtHOMENAME.Text

        f.Show()

    End Sub



    Private Sub RECORDToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles RECORDToolStripMenuItem12.Click

        Dim f As New frmWAREHOUSE_DR_RECORD
        f.MdiParent = Me

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text
        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadDRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub

    Private Sub STOCKRECEIVEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STOCKRECEIVEToolStripMenuItem.Click

        Dim f As New frmWAREHOUSE_DR_RECEIVER_SRS
        f.MdiParent = Me
        f.LoadDRList()
        f.Add_Approval_Button()

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text
        f.txtNAME.Text = txtHOMENAME.Text

        f.Show()

    End Sub

    Private Sub INVENTORYPULLOUTToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles INVENTORYPULLOUTToolStripMenuItem2.Click

        Dim f As New frmWAREHOUSE_DR_IPR
        f.MdiParent = Me
        f.LoadList()
        f.Add_Approval_Button()

        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text

        f.txtWAREHOUSE.Text = txtWAREHOUSENAME.Text
        f.txtNAME.Text = txtHOMENAME.Text

        f.Show()

    End Sub


    Private Sub IMPORTLOYVERSEToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Dim f As New frmWAREHOUSE_DR_LOYVERSE
        f.MdiParent = Me
        f.LoadList()
        f.Show()

    End Sub


    Private Sub txtPOSITION_TextChanged(sender As Object, e As EventArgs) Handles txtPOSITION.TextChanged

        If txtPOSITION.Text = "CHIEF OPERATING OFFICER" Then

            btnbtn.Visible = True

        Else

            btnbtn.Visible = False

        End If

    End Sub

    Private Sub btnbtn_Click(sender As Object, e As EventArgs) Handles btnbtn.Click

        Dim f As New frm4FINANCE_PENDNGS
        f.MdiParent = Me
        f.Show()

    End Sub

    Private Sub RRMANUALToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RRMANUALToolStripMenuItem.Click



    End Sub



    Private Sub CALIQUIDATIONToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles CALIQUIDATIONToolStripMenuItem5.Click

        Dim f As New frm8SI_APV_CA_LIQUIDATION
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.btnSAVE.Enabled = False
        f.Show()

    End Sub

    Private Sub PAYMENTREQUESTToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles PAYMENTREQUESTToolStripMenuItem4.Click

        Dim f As New frm8SI_APV_PAYMENT_REQUEST
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.btnSAVE.Enabled = False
        f.Show()

    End Sub

    Private Sub REIMBURSMENTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REIMBURSMENTToolStripMenuItem.Click

        Dim f As New frm8SI_APV_REIMBURSEMENT
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.btnSAVE.Enabled = False
        f.Show()

    End Sub


    Private Sub RFREPLENISHMENTToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles RFREPLENISHMENTToolStripMenuItem3.Click

        Dim f As New frm8SI_APV_RF_REPLENISHMENT
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.btnSAVE.Enabled = False
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem30_Click_1(sender As Object, e As EventArgs) Handles SONAKAINCToolStripMenuItem30.Click

        Dim f As New frm8SI_CR_DR
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.btnSAVE.Enabled = False
        f.Show()

    End Sub

    Private Sub CRMANUALToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CRMANUALToolStripMenuItem.Click

        Dim f As New frm8SI_CR_MANUAL
        f.MdiParent = Me
        f.txtDEPARTMENT.Text = Me.txtHOMEDEPARTMENT.Text
        f.txtEMPLOYEE.Text = Me.txtHOMENAME.Text
        f.btnSAVE.Enabled = False
        f.Show()

    End Sub


    Private Sub ToolStripMenuItem34_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem34.Click

        Dim f As New frm8SI_RF_REPLENISHMENT_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtDEP.Text = txtHOMEDEPCODE.Text
        f.LoadRFList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False

        f.Show()
    End Sub


    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click

        If txtPOSITION.Text = "MANAGER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frmSRS_MANAGER_APPROVAL
            f.MdiParent = Me
            f.LoadSRSList()
            f.Add_Approval_Button()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click

        Dim f As New frm8SI_CASHADVANCE_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtDEP.Text = txtHOMEDEPCODE.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click

        Dim f As New frmTIC_CASHADVANCE_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem19.Click

        Dim f As New frm8SI_CA_LIQUIDATION_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtDEP.Text = txtHOMEDEPCODE.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem18.Click

        Dim f As New frmTIC_CA_LIQUIDATION_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadCAList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub ToolStripMenuItem22_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem22.Click

        Dim f As New frm8SI_PETTYCASHVOUCHER_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub ToolStripMenuItem21_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem21.Click

        Dim f As New frmTIC_PETTYCASHVOUCHER_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub ToolStripMenuItem25_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem25.Click

        Dim f As New frm8SI_PCV_REIMBURSEMENT_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()



    End Sub

    Private Sub ToolStripMenuItem24_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem24.Click

        Dim f As New frmTIC_PCV_REIMBURSEMENT_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()


    End Sub

    Private Sub ToolStripMenuItem28_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem28.Click

        Dim f As New frm8SI_PCV_LIQUIDATION_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.Show()

    End Sub

    Private Sub ToolStripMenuItem27_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem27.Click

        Dim f As New frmTIC_PCV_LIQUIDATION_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadPCVList()
        f.Add_Approval_Button()
        f.Show()

    End Sub


    Private Sub ToolStripMenuItem31_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem31.Click

        Dim f As New frm8SI_REIMBURSEMENT_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtDEP.Text = txtHOMEDEPCODE.Text
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub

    Private Sub ToolStripMenuItem30_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem30.Click

        Dim f As New frmTIC_REIMBURSEMENT_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadREIMList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub



    Private Sub ToolStripMenuItem33_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem33.Click

        Dim f As New frmTIC_RF_REPLENISHMENT_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.LoadRFList()
        f.Add_Approval_Button()
        f.btnSAVE.Enabled = False
        f.Button1.Enabled = False
        f.Show()

    End Sub


    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click

        If txtHOMECLASS.Text = "MANAGER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

            Dim f As New frm8SI_REQUESTSLIP_MANAGER_FORM
            f.MdiParent = Me
            f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
            f.txtTYPE.Text = txtHOMETYPE.Text
            f.txtDEP.Text = txtHOMEDEPCODE.Text
            f.LoaDAPPROVALList()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

    Private Sub ToolStripMenuItem37_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem37.Click

        Dim f As New frm8SI_PAYMENTREQUEST_MANAGER
        f.MdiParent = Me
        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtDEP.Text = txtHOMEDEPCODE.Text
        f.LoadList()
        f.Add_Approval_Button()
        f.btnAPPROVED.Enabled = False
        f.btnDISAPPROVED.Enabled = False
        f.Show()

    End Sub


    Private Sub ToolStripMenuItem38_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem38.Click

        Dim f As New frmWAREHOUSE_IPR_MANAGER
        f.MdiParent = Me

        f.txtDEPARTMENTDATA.Text = txtHOMEDEPARTMENT.Text
        f.txtTYPE.Text = txtHOMETYPE.Text
        f.txtPOSITION.Text = txtPOSITION.Text
        f.txtSHARED.Text = txtWAREHOUSESHARED.Text
        f.txtWAREHOUSENAME.Text = txtWAREHOUSENAME.Text
        f.txtDEP.Text = txtHOMEDEPCODE.Text

        f.txtNAME.Text = txtHOMENAME.Text

        f.LoadIPRList()
        f.Add_Approval_Button()

        f.Show()

    End Sub


    Private Sub THEICONCLINICToolStripMenuItem6_Click_1(sender As Object, e As EventArgs)

        Dim f As New frmTIC_REQUESTSLIP_COO
        f.MdiParent = Me
        f.LoadAPPROVALLIST()
        f.Show()

    End Sub

    Private Sub SONAKAINCToolStripMenuItem_Click_1(sender As Object, e As EventArgs)

        Dim f As New frm8SI_REQUESTSLIP_COO
        f.MdiParent = Me
        f.LoadAPPROVALLIST()
        f.Show()

    End Sub


    Private Sub REQUESTSLIPToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles REQUESTSLIPToolStripMenuItem2.Click

        If txtHOMEDEPARTMENT.Text = "PURCHASING DEPARTMENT" And txtHOMECLASS.Text = "MANAGER" Or txtHOMETYPE.Text = "ADMINISTRATOR" Then

        Dim f As New frmTIC_REQUESTSLIP_GM_FORM
            f.MdiParent = Me
            f.LoadAPPROVALLIST()
            f.Show()

        Else

            MsgBox("You Don't Have Permission!", vbOKOnly + vbCritical, "CONFIRMATION")

        End If

    End Sub

End Class

