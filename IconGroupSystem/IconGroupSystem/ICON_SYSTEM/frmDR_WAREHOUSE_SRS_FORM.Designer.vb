<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDR_WAREHOUSE_SRS_FORM
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDR_WAREHOUSE_SRS_FORM))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtITEMID = New System.Windows.Forms.TextBox()
        Me.txtSRS = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDATE = New System.Windows.Forms.DateTimePicker()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnSAVE = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPLATFORMS = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDRNO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDEPARTMENT = New System.Windows.Forms.TextBox()
        Me.txtREQUESTOR = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDATENEEDED = New System.Windows.Forms.DateTimePicker()
        Me.txtREF = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtREMAINING = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtQTYISSUED = New System.Windows.Forms.TextBox()
        Me.txtUNIT = New System.Windows.Forms.TextBox()
        Me.txtITEMCODE = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSTOCK = New System.Windows.Forms.TextBox()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtQTY = New System.Windows.Forms.TextBox()
        Me.txtREMARKS = New System.Windows.Forms.TextBox()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.QUANTITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UNIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPTION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REMARKS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QTY_ISSUED = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REMAINING = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EDIT = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.UPDATE = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DimGray
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(1111, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(180, 46)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "CLOSE"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.txtID)
        Me.Panel1.Controls.Add(Me.txtITEMID)
        Me.Panel1.Controls.Add(Me.txtSRS)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1300, 63)
        Me.Panel1.TabIndex = 30
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(749, 21)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(69, 31)
        Me.txtID.TabIndex = 117
        Me.txtID.Visible = False
        '
        'txtITEMID
        '
        Me.txtITEMID.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtITEMID.Location = New System.Drawing.Point(824, 21)
        Me.txtITEMID.Name = "txtITEMID"
        Me.txtITEMID.Size = New System.Drawing.Size(69, 31)
        Me.txtITEMID.TabIndex = 116
        Me.txtITEMID.Visible = False
        '
        'txtSRS
        '
        Me.txtSRS.Enabled = False
        Me.txtSRS.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSRS.Location = New System.Drawing.Point(899, 21)
        Me.txtSRS.Name = "txtSRS"
        Me.txtSRS.Size = New System.Drawing.Size(206, 31)
        Me.txtSRS.TabIndex = 26
        Me.txtSRS.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1300, 10)
        Me.Panel2.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(795, 46)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "DELIVERY RECEIPT_SUPPLY REQUISITION"
        '
        'txtDATE
        '
        Me.txtDATE.Enabled = False
        Me.txtDATE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDATE.Location = New System.Drawing.Point(366, 25)
        Me.txtDATE.Name = "txtDATE"
        Me.txtDATE.Size = New System.Drawing.Size(230, 31)
        Me.txtDATE.TabIndex = 121
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Yellow
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(1111, 77)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(180, 63)
        Me.Button3.TabIndex = 33
        Me.Button3.Text = "PRINT"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btnSAVE
        '
        Me.btnSAVE.BackColor = System.Drawing.Color.Red
        Me.btnSAVE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSAVE.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSAVE.ForeColor = System.Drawing.Color.White
        Me.btnSAVE.Location = New System.Drawing.Point(1111, 12)
        Me.btnSAVE.Name = "btnSAVE"
        Me.btnSAVE.Size = New System.Drawing.Size(180, 63)
        Me.btnSAVE.TabIndex = 30
        Me.btnSAVE.Text = "SAVE"
        Me.btnSAVE.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(605, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 23)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "DATE NEEDED"
        '
        'txtPLATFORMS
        '
        Me.txtPLATFORMS.Enabled = False
        Me.txtPLATFORMS.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPLATFORMS.Location = New System.Drawing.Point(755, 67)
        Me.txtPLATFORMS.Name = "txtPLATFORMS"
        Me.txtPLATFORMS.Size = New System.Drawing.Size(350, 31)
        Me.txtPLATFORMS.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(605, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 23)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "PLATFORMS"
        '
        'txtDRNO
        '
        Me.txtDRNO.Enabled = False
        Me.txtDRNO.Font = New System.Drawing.Font("Arial Black", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDRNO.Location = New System.Drawing.Point(755, 16)
        Me.txtDRNO.Name = "txtDRNO"
        Me.txtDRNO.Size = New System.Drawing.Size(350, 46)
        Me.txtDRNO.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(602, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 38)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "DR NO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(10, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 23)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "REF NO"
        '
        'txtDEPARTMENT
        '
        Me.txtDEPARTMENT.Enabled = False
        Me.txtDEPARTMENT.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDEPARTMENT.Location = New System.Drawing.Point(154, 109)
        Me.txtDEPARTMENT.Name = "txtDEPARTMENT"
        Me.txtDEPARTMENT.Size = New System.Drawing.Size(443, 31)
        Me.txtDEPARTMENT.TabIndex = 8
        '
        'txtREQUESTOR
        '
        Me.txtREQUESTOR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtREQUESTOR.Enabled = False
        Me.txtREQUESTOR.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREQUESTOR.Location = New System.Drawing.Point(154, 67)
        Me.txtREQUESTOR.Name = "txtREQUESTOR"
        Me.txtREQUESTOR.Size = New System.Drawing.Size(443, 31)
        Me.txtREQUESTOR.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(10, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 23)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "DEPARTMENT"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(10, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 23)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "REQUESTOR"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.txtDATENEEDED)
        Me.GroupBox1.Controls.Add(Me.txtDATE)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.btnSAVE)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtPLATFORMS)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDRNO)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtREF)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDEPARTMENT)
        Me.GroupBox1.Controls.Add(Me.txtREQUESTOR)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(12, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1300, 156)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        '
        'txtDATENEEDED
        '
        Me.txtDATENEEDED.Enabled = False
        Me.txtDATENEEDED.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDATENEEDED.Location = New System.Drawing.Point(755, 106)
        Me.txtDATENEEDED.Name = "txtDATENEEDED"
        Me.txtDATENEEDED.Size = New System.Drawing.Size(350, 31)
        Me.txtDATENEEDED.TabIndex = 122
        '
        'txtREF
        '
        Me.txtREF.Enabled = False
        Me.txtREF.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREF.Location = New System.Drawing.Point(154, 25)
        Me.txtREF.Name = "txtREF"
        Me.txtREF.Size = New System.Drawing.Size(206, 31)
        Me.txtREF.TabIndex = 25
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtREMAINING)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtQTYISSUED)
        Me.GroupBox2.Controls.Add(Me.txtUNIT)
        Me.GroupBox2.Controls.Add(Me.txtITEMCODE)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtSTOCK)
        Me.GroupBox2.Controls.Add(Me.txtDESCRIPTION)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtQTY)
        Me.GroupBox2.Controls.Add(Me.txtREMARKS)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 225)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1300, 82)
        Me.GroupBox2.TabIndex = 115
        Me.GroupBox2.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial Black", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(1184, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 19)
        Me.Label15.TabIndex = 123
        Me.Label15.Text = "REMAINING"
        '
        'txtREMAINING
        '
        Me.txtREMAINING.Enabled = False
        Me.txtREMAINING.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREMAINING.Location = New System.Drawing.Point(1178, 40)
        Me.txtREMAINING.Name = "txtREMAINING"
        Me.txtREMAINING.Size = New System.Drawing.Size(114, 31)
        Me.txtREMAINING.TabIndex = 124
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial Black", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(1057, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(105, 19)
        Me.Label14.TabIndex = 121
        Me.Label14.Text = "QTY ISSUED"
        '
        'txtQTYISSUED
        '
        Me.txtQTYISSUED.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQTYISSUED.Location = New System.Drawing.Point(1048, 40)
        Me.txtQTYISSUED.Name = "txtQTYISSUED"
        Me.txtQTYISSUED.Size = New System.Drawing.Size(124, 31)
        Me.txtQTYISSUED.TabIndex = 122
        '
        'txtUNIT
        '
        Me.txtUNIT.Enabled = False
        Me.txtUNIT.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUNIT.ForeColor = System.Drawing.Color.Red
        Me.txtUNIT.Location = New System.Drawing.Point(123, 40)
        Me.txtUNIT.Name = "txtUNIT"
        Me.txtUNIT.Size = New System.Drawing.Size(76, 31)
        Me.txtUNIT.TabIndex = 120
        '
        'txtITEMCODE
        '
        Me.txtITEMCODE.Enabled = False
        Me.txtITEMCODE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtITEMCODE.Location = New System.Drawing.Point(290, 40)
        Me.txtITEMCODE.Name = "txtITEMCODE"
        Me.txtITEMCODE.Size = New System.Drawing.Size(176, 31)
        Me.txtITEMCODE.TabIndex = 119
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial Black", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(332, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 19)
        Me.Label13.TabIndex = 118
        Me.Label13.Text = "ITEM CODE"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial Black", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(211, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 19)
        Me.Label12.TabIndex = 116
        Me.Label12.Text = "STOCK"
        '
        'txtSTOCK
        '
        Me.txtSTOCK.Enabled = False
        Me.txtSTOCK.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSTOCK.ForeColor = System.Drawing.Color.Red
        Me.txtSTOCK.Location = New System.Drawing.Point(205, 40)
        Me.txtSTOCK.Name = "txtSTOCK"
        Me.txtSTOCK.Size = New System.Drawing.Size(79, 31)
        Me.txtSTOCK.TabIndex = 117
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Enabled = False
        Me.txtDESCRIPTION.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(472, 40)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(376, 31)
        Me.txtDESCRIPTION.TabIndex = 115
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Black", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(17, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 19)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "QUANTITY"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Black", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(138, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 19)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "UNIT"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial Black", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(585, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 19)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "DESCRIPTION"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial Black", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(905, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 19)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "REMARKS"
        '
        'txtQTY
        '
        Me.txtQTY.Enabled = False
        Me.txtQTY.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQTY.Location = New System.Drawing.Point(9, 40)
        Me.txtQTY.Name = "txtQTY"
        Me.txtQTY.Size = New System.Drawing.Size(108, 31)
        Me.txtQTY.TabIndex = 12
        '
        'txtREMARKS
        '
        Me.txtREMARKS.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtREMARKS.Location = New System.Drawing.Point(854, 40)
        Me.txtREMARKS.Name = "txtREMARKS"
        Me.txtREMARKS.Size = New System.Drawing.Size(188, 31)
        Me.txtREMARKS.TabIndex = 42
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.AllowUserToDeleteRows = False
        Me.dataGridView1.AllowUserToResizeColumns = False
        Me.dataGridView1.AllowUserToResizeRows = False
        Me.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Cambria", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dataGridView1.ColumnHeadersHeight = 30
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.QUANTITY, Me.UNIT, Me.DESCRIPTION, Me.REMARKS, Me.ITEM_ID, Me.QTY_ISSUED, Me.REMAINING, Me.EDIT, Me.UPDATE})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Ivory
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dataGridView1.EnableHeadersVisualStyles = False
        Me.dataGridView1.Location = New System.Drawing.Point(12, 313)
        Me.dataGridView1.Name = "dataGridView1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Aqua
        Me.dataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dataGridView1.RowTemplate.Height = 24
        Me.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridView1.Size = New System.Drawing.Size(1300, 469)
        Me.dataGridView1.TabIndex = 116
        '
        'QUANTITY
        '
        Me.QUANTITY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.QUANTITY.HeaderText = "QUANTITY"
        Me.QUANTITY.Name = "QUANTITY"
        Me.QUANTITY.Width = 101
        '
        'UNIT
        '
        Me.UNIT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.UNIT.HeaderText = "UNIT"
        Me.UNIT.Name = "UNIT"
        Me.UNIT.Width = 66
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DESCRIPTION.HeaderText = "DESCRIPTION"
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.Width = 123
        '
        'REMARKS
        '
        Me.REMARKS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.REMARKS.HeaderText = "REMARKS"
        Me.REMARKS.Name = "REMARKS"
        '
        'ITEM_ID
        '
        Me.ITEM_ID.HeaderText = "ITEM_ID"
        Me.ITEM_ID.Name = "ITEM_ID"
        Me.ITEM_ID.Visible = False
        '
        'QTY_ISSUED
        '
        Me.QTY_ISSUED.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.QTY_ISSUED.HeaderText = "QTY_ISSUED"
        Me.QTY_ISSUED.Name = "QTY_ISSUED"
        Me.QTY_ISSUED.Width = 111
        '
        'REMAINING
        '
        Me.REMAINING.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.REMAINING.HeaderText = "REMAINING"
        Me.REMAINING.Name = "REMAINING"
        Me.REMAINING.Width = 110
        '
        'EDIT
        '
        Me.EDIT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        Me.EDIT.DefaultCellStyle = DataGridViewCellStyle2
        Me.EDIT.HeaderText = ""
        Me.EDIT.Name = "EDIT"
        Me.EDIT.Text = "EDIT"
        Me.EDIT.UseColumnTextForButtonValue = True
        Me.EDIT.Width = 5
        '
        'UPDATE
        '
        Me.UPDATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.UPDATE.HeaderText = ""
        Me.UPDATE.Name = "UPDATE"
        Me.UPDATE.Text = "UPDATE"
        Me.UPDATE.UseColumnTextForButtonValue = True
        Me.UPDATE.Width = 5
        '
        'frmDR_WAREHOUSE_SRS_FORM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1324, 794)
        Me.Controls.Add(Me.dataGridView1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDR_WAREHOUSE_SRS_FORM"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents txtPLATFORMS As System.Windows.Forms.TextBox
    Public WithEvents txtDRNO As System.Windows.Forms.TextBox
    Public WithEvents txtDEPARTMENT As System.Windows.Forms.TextBox
    Public WithEvents txtREQUESTOR As System.Windows.Forms.TextBox
    Public WithEvents txtREF As System.Windows.Forms.TextBox
    Public WithEvents txtDATENEEDED As System.Windows.Forms.DateTimePicker
    Public WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtDATE As System.Windows.Forms.DateTimePicker
    Public WithEvents Button3 As System.Windows.Forms.Button
    Public WithEvents btnSAVE As System.Windows.Forms.Button
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents txtSRS As System.Windows.Forms.TextBox
    Public WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents txtITEMCODE As System.Windows.Forms.TextBox
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents txtSTOCK As System.Windows.Forms.TextBox
    Public WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents txtQTY As System.Windows.Forms.TextBox
    Public WithEvents txtREMARKS As System.Windows.Forms.TextBox
    Public WithEvents txtUNIT As System.Windows.Forms.TextBox
    Public WithEvents txtITEMID As System.Windows.Forms.TextBox
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents txtQTYISSUED As System.Windows.Forms.TextBox
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents txtREMAINING As System.Windows.Forms.TextBox
    Public WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Public WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents QUANTITY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UNIT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPTION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REMARKS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEM_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QTY_ISSUED As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REMAINING As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EDIT As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents UPDATE As System.Windows.Forms.DataGridViewButtonColumn
End Class
