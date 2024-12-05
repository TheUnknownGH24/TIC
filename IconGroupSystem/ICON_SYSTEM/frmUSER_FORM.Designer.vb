<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUSER_FORM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUSER_FORM))
        Me.btnUPDATE = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEMPLOYEENAME = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEMPLOYEECODE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSAVE = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCLASS = New System.Windows.Forms.ComboBox()
        Me.txtTYPE = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPASSWORD = New System.Windows.Forms.TextBox()
        Me.txtDOMAIN = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPOSITION = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDEPCODE = New System.Windows.Forms.TextBox()
        Me.txtDERPARTMENT = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnUPDATE
        '
        Me.btnUPDATE.BackColor = System.Drawing.Color.Blue
        Me.btnUPDATE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUPDATE.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUPDATE.ForeColor = System.Drawing.Color.White
        Me.btnUPDATE.Location = New System.Drawing.Point(14, 302)
        Me.btnUPDATE.Name = "btnUPDATE"
        Me.btnUPDATE.Size = New System.Drawing.Size(124, 55)
        Me.btnUPDATE.TabIndex = 31
        Me.btnUPDATE.Text = "UPDATE"
        Me.btnUPDATE.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(10, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 23)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "DEPARTMENT"
        '
        'txtEMPLOYEENAME
        '
        Me.txtEMPLOYEENAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEMPLOYEENAME.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEMPLOYEENAME.Location = New System.Drawing.Point(228, 60)
        Me.txtEMPLOYEENAME.Name = "txtEMPLOYEENAME"
        Me.txtEMPLOYEENAME.Size = New System.Drawing.Size(457, 31)
        Me.txtEMPLOYEENAME.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(10, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 23)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "EMPLOYEE NAME"
        '
        'txtEMPLOYEECODE
        '
        Me.txtEMPLOYEECODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEMPLOYEECODE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEMPLOYEECODE.Location = New System.Drawing.Point(228, 21)
        Me.txtEMPLOYEECODE.Name = "txtEMPLOYEECODE"
        Me.txtEMPLOYEECODE.Size = New System.Drawing.Size(457, 31)
        Me.txtEMPLOYEECODE.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 23)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "EMPLOYEE CODE"
        '
        'btnSAVE
        '
        Me.btnSAVE.BackColor = System.Drawing.Color.Red
        Me.btnSAVE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSAVE.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSAVE.ForeColor = System.Drawing.Color.White
        Me.btnSAVE.Location = New System.Drawing.Point(561, 302)
        Me.btnSAVE.Name = "btnSAVE"
        Me.btnSAVE.Size = New System.Drawing.Size(124, 55)
        Me.btnSAVE.TabIndex = 13
        Me.btnSAVE.Text = "SAVE"
        Me.btnSAVE.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(697, 10)
        Me.Panel2.TabIndex = 21
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.DimGray
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(561, 13)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(124, 46)
        Me.Button5.TabIndex = 15
        Me.Button5.Text = "CLOSE"
        Me.Button5.UseVisualStyleBackColor = False
        Me.Button5.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Controls.Add(Me.txtID)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Location = New System.Drawing.Point(12, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(697, 62)
        Me.Panel1.TabIndex = 29
        '
        'txtID
        '
        Me.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtID.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(478, 21)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(77, 31)
        Me.txtID.TabIndex = 149
        Me.txtID.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(4, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(416, 46)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "REGISTRATION FORM"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.txtCLASS)
        Me.GroupBox1.Controls.Add(Me.txtTYPE)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnUPDATE)
        Me.GroupBox1.Controls.Add(Me.txtPASSWORD)
        Me.GroupBox1.Controls.Add(Me.txtDOMAIN)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnSAVE)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtPOSITION)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDEPCODE)
        Me.GroupBox1.Controls.Add(Me.txtDERPARTMENT)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtEMPLOYEENAME)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtEMPLOYEECODE)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gray
        Me.GroupBox1.Location = New System.Drawing.Point(12, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(697, 369)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        '
        'txtCLASS
        '
        Me.txtCLASS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtCLASS.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCLASS.FormattingEnabled = True
        Me.txtCLASS.Items.AddRange(New Object() {"EXECOM", "EXECOM ASSIST", "MANAGER", "SUPERVISOR", "RANK & FILE"})
        Me.txtCLASS.Location = New System.Drawing.Point(228, 178)
        Me.txtCLASS.Name = "txtCLASS"
        Me.txtCLASS.Size = New System.Drawing.Size(228, 31)
        Me.txtCLASS.TabIndex = 149
        '
        'txtTYPE
        '
        Me.txtTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtTYPE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTYPE.FormattingEnabled = True
        Me.txtTYPE.Items.AddRange(New Object() {"ADMINISTRATOR", "USER"})
        Me.txtTYPE.Location = New System.Drawing.Point(228, 256)
        Me.txtTYPE.Name = "txtTYPE"
        Me.txtTYPE.Size = New System.Drawing.Size(457, 31)
        Me.txtTYPE.TabIndex = 148
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(10, 262)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 23)
        Me.Label2.TabIndex = 147
        Me.Label2.Text = "USER TYPE"
        '
        'txtPASSWORD
        '
        Me.txtPASSWORD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPASSWORD.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPASSWORD.ForeColor = System.Drawing.Color.Red
        Me.txtPASSWORD.Location = New System.Drawing.Point(228, 217)
        Me.txtPASSWORD.Name = "txtPASSWORD"
        Me.txtPASSWORD.Size = New System.Drawing.Size(457, 31)
        Me.txtPASSWORD.TabIndex = 146
        '
        'txtDOMAIN
        '
        Me.txtDOMAIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtDOMAIN.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDOMAIN.FormattingEnabled = True
        Me.txtDOMAIN.Items.AddRange(New Object() {"THE ICON CLINIC - DERMA", "THE ICON CLINIC - SURGERY", "8SONAKA INC"})
        Me.txtDOMAIN.Location = New System.Drawing.Point(228, 99)
        Me.txtDOMAIN.Name = "txtDOMAIN"
        Me.txtDOMAIN.Size = New System.Drawing.Size(457, 31)
        Me.txtDOMAIN.TabIndex = 145
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(10, 220)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 23)
        Me.Label8.TabIndex = 144
        Me.Label8.Text = "PASSWORD"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(10, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 23)
        Me.Label7.TabIndex = 142
        Me.Label7.Text = "DOMAIN"
        '
        'txtPOSITION
        '
        Me.txtPOSITION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPOSITION.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPOSITION.Location = New System.Drawing.Point(462, 178)
        Me.txtPOSITION.Name = "txtPOSITION"
        Me.txtPOSITION.Size = New System.Drawing.Size(223, 31)
        Me.txtPOSITION.TabIndex = 141
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(10, 181)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 23)
        Me.Label6.TabIndex = 140
        Me.Label6.Text = "POSITION"
        '
        'txtDEPCODE
        '
        Me.txtDEPCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDEPCODE.Enabled = False
        Me.txtDEPCODE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDEPCODE.Location = New System.Drawing.Point(606, 138)
        Me.txtDEPCODE.Name = "txtDEPCODE"
        Me.txtDEPCODE.Size = New System.Drawing.Size(79, 31)
        Me.txtDEPCODE.TabIndex = 139
        '
        'txtDERPARTMENT
        '
        Me.txtDERPARTMENT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtDERPARTMENT.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDERPARTMENT.FormattingEnabled = True
        Me.txtDERPARTMENT.Location = New System.Drawing.Point(228, 137)
        Me.txtDERPARTMENT.Name = "txtDERPARTMENT"
        Me.txtDERPARTMENT.Size = New System.Drawing.Size(372, 31)
        Me.txtDERPARTMENT.TabIndex = 137
        '
        'frmUSER_FORM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(721, 451)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUSER_FORM"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnUPDATE As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEMPLOYEENAME As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEMPLOYEECODE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSAVE As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents txtDERPARTMENT As System.Windows.Forms.ComboBox
    Friend WithEvents txtDEPCODE As System.Windows.Forms.TextBox
    Friend WithEvents txtPOSITION As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPASSWORD As System.Windows.Forms.TextBox
    Public WithEvents txtDOMAIN As System.Windows.Forms.ComboBox
    Public WithEvents txtTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Public WithEvents txtCLASS As System.Windows.Forms.ComboBox
End Class
