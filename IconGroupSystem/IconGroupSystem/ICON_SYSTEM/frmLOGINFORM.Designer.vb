<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLOGINFORM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLOGINFORM))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtCODE = New System.Windows.Forms.TextBox()
        Me.txtDEPARTMENT = New System.Windows.Forms.TextBox()
        Me.txtTYPE = New System.Windows.Forms.TextBox()
        Me.txtPOSITION = New System.Windows.Forms.TextBox()
        Me.txtDOMAIN = New System.Windows.Forms.TextBox()
        Me.txtDEPCODE = New System.Windows.Forms.TextBox()
        Me.txtUSERNAME = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.btnSAVE = New System.Windows.Forms.Button()
        Me.txtPASSWORD = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCLASS = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtWAREHOUSENAME = New System.Windows.Forms.TextBox()
        Me.txtWAREHOUSE_POSITION = New System.Windows.Forms.TextBox()
        Me.txtWAREHOUSESHARED = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(274, 258)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.txtCODE)
        Me.Panel1.Controls.Add(Me.txtDEPARTMENT)
        Me.Panel1.Controls.Add(Me.txtTYPE)
        Me.Panel1.Controls.Add(Me.txtPOSITION)
        Me.Panel1.Controls.Add(Me.txtDOMAIN)
        Me.Panel1.Controls.Add(Me.txtDEPCODE)
        Me.Panel1.Controls.Add(Me.txtUSERNAME)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.btnSAVE)
        Me.Panel1.Controls.Add(Me.txtPASSWORD)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(275, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(391, 231)
        Me.Panel1.TabIndex = 1
        '
        'txtCODE
        '
        Me.txtCODE.Enabled = False
        Me.txtCODE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCODE.Location = New System.Drawing.Point(244, 3)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.Size = New System.Drawing.Size(138, 31)
        Me.txtCODE.TabIndex = 283
        Me.txtCODE.Visible = False
        '
        'txtDEPARTMENT
        '
        Me.txtDEPARTMENT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtDEPARTMENT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtDEPARTMENT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDEPARTMENT.Enabled = False
        Me.txtDEPARTMENT.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDEPARTMENT.Location = New System.Drawing.Point(402, 155)
        Me.txtDEPARTMENT.Name = "txtDEPARTMENT"
        Me.txtDEPARTMENT.Size = New System.Drawing.Size(513, 31)
        Me.txtDEPARTMENT.TabIndex = 158
        Me.txtDEPARTMENT.Visible = False
        '
        'txtTYPE
        '
        Me.txtTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtTYPE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTYPE.Enabled = False
        Me.txtTYPE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTYPE.Location = New System.Drawing.Point(402, 118)
        Me.txtTYPE.Name = "txtTYPE"
        Me.txtTYPE.Size = New System.Drawing.Size(513, 31)
        Me.txtTYPE.TabIndex = 156
        Me.txtTYPE.Visible = False
        '
        'txtPOSITION
        '
        Me.txtPOSITION.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtPOSITION.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPOSITION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPOSITION.Enabled = False
        Me.txtPOSITION.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPOSITION.Location = New System.Drawing.Point(402, 81)
        Me.txtPOSITION.Name = "txtPOSITION"
        Me.txtPOSITION.Size = New System.Drawing.Size(513, 31)
        Me.txtPOSITION.TabIndex = 155
        Me.txtPOSITION.Visible = False
        '
        'txtDOMAIN
        '
        Me.txtDOMAIN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtDOMAIN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtDOMAIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDOMAIN.Enabled = False
        Me.txtDOMAIN.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDOMAIN.Location = New System.Drawing.Point(402, 8)
        Me.txtDOMAIN.Name = "txtDOMAIN"
        Me.txtDOMAIN.Size = New System.Drawing.Size(513, 31)
        Me.txtDOMAIN.TabIndex = 153
        Me.txtDOMAIN.Visible = False
        '
        'txtDEPCODE
        '
        Me.txtDEPCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtDEPCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtDEPCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDEPCODE.Enabled = False
        Me.txtDEPCODE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDEPCODE.Location = New System.Drawing.Point(402, 44)
        Me.txtDEPCODE.Name = "txtDEPCODE"
        Me.txtDEPCODE.Size = New System.Drawing.Size(513, 31)
        Me.txtDEPCODE.TabIndex = 154
        Me.txtDEPCODE.Visible = False
        '
        'txtUSERNAME
        '
        Me.txtUSERNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtUSERNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtUSERNAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUSERNAME.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUSERNAME.Location = New System.Drawing.Point(10, 41)
        Me.txtUSERNAME.Name = "txtUSERNAME"
        Me.txtUSERNAME.Size = New System.Drawing.Size(372, 31)
        Me.txtUSERNAME.TabIndex = 152
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gray
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(258, 168)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(124, 55)
        Me.Button1.TabIndex = 151
        Me.Button1.Text = "CLOSE"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Cambria", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(210, 138)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(172, 24)
        Me.CheckBox1.TabIndex = 150
        Me.CheckBox1.Text = "SHOW PASSWORD"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'btnSAVE
        '
        Me.btnSAVE.BackColor = System.Drawing.Color.Red
        Me.btnSAVE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSAVE.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSAVE.ForeColor = System.Drawing.Color.White
        Me.btnSAVE.Location = New System.Drawing.Point(128, 168)
        Me.btnSAVE.Name = "btnSAVE"
        Me.btnSAVE.Size = New System.Drawing.Size(124, 55)
        Me.btnSAVE.TabIndex = 149
        Me.btnSAVE.Text = "LOG IN"
        Me.btnSAVE.UseVisualStyleBackColor = False
        '
        'txtPASSWORD
        '
        Me.txtPASSWORD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPASSWORD.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPASSWORD.Location = New System.Drawing.Point(10, 101)
        Me.txtPASSWORD.Name = "txtPASSWORD"
        Me.txtPASSWORD.Size = New System.Drawing.Size(372, 31)
        Me.txtPASSWORD.TabIndex = 148
        Me.txtPASSWORD.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 23)
        Me.Label2.TabIndex = 147
        Me.Label2.Text = "PASSWORD"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(171, 23)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "EMPLOYEE NAME"
        '
        'txtCLASS
        '
        Me.txtCLASS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtCLASS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtCLASS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCLASS.Enabled = False
        Me.txtCLASS.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCLASS.Location = New System.Drawing.Point(285, 161)
        Me.txtCLASS.Name = "txtCLASS"
        Me.txtCLASS.Size = New System.Drawing.Size(108, 31)
        Me.txtCLASS.TabIndex = 159
        Me.txtCLASS.Visible = False
        '
        'txtID
        '
        Me.txtID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtID.Enabled = False
        Me.txtID.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(285, 198)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(108, 31)
        Me.txtID.TabIndex = 157
        Me.txtID.Visible = False
        '
        'txtWAREHOUSENAME
        '
        Me.txtWAREHOUSENAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtWAREHOUSENAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtWAREHOUSENAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWAREHOUSENAME.Enabled = False
        Me.txtWAREHOUSENAME.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWAREHOUSENAME.Location = New System.Drawing.Point(65, 86)
        Me.txtWAREHOUSENAME.Name = "txtWAREHOUSENAME"
        Me.txtWAREHOUSENAME.Size = New System.Drawing.Size(204, 31)
        Me.txtWAREHOUSENAME.TabIndex = 162
        Me.txtWAREHOUSENAME.Visible = False
        '
        'txtWAREHOUSE_POSITION
        '
        Me.txtWAREHOUSE_POSITION.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtWAREHOUSE_POSITION.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtWAREHOUSE_POSITION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWAREHOUSE_POSITION.Enabled = False
        Me.txtWAREHOUSE_POSITION.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWAREHOUSE_POSITION.Location = New System.Drawing.Point(65, 12)
        Me.txtWAREHOUSE_POSITION.Name = "txtWAREHOUSE_POSITION"
        Me.txtWAREHOUSE_POSITION.Size = New System.Drawing.Size(204, 31)
        Me.txtWAREHOUSE_POSITION.TabIndex = 160
        Me.txtWAREHOUSE_POSITION.Visible = False
        '
        'txtWAREHOUSESHARED
        '
        Me.txtWAREHOUSESHARED.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtWAREHOUSESHARED.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtWAREHOUSESHARED.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWAREHOUSESHARED.Enabled = False
        Me.txtWAREHOUSESHARED.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWAREHOUSESHARED.Location = New System.Drawing.Point(65, 49)
        Me.txtWAREHOUSESHARED.Name = "txtWAREHOUSESHARED"
        Me.txtWAREHOUSESHARED.Size = New System.Drawing.Size(204, 31)
        Me.txtWAREHOUSESHARED.TabIndex = 161
        Me.txtWAREHOUSESHARED.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(30, 260)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 23)
        Me.Label3.TabIndex = 160
        Me.Label3.Text = "717, 343"
        Me.Label3.Visible = False
        '
        'frmLOGINFORM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(695, 292)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtWAREHOUSENAME)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCLASS)
        Me.Controls.Add(Me.txtWAREHOUSESHARED)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.txtWAREHOUSE_POSITION)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLOGINFORM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ICON GROUP MANAGEMENT SYSTEM"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPASSWORD As System.Windows.Forms.TextBox
    Friend WithEvents btnSAVE As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Public WithEvents txtUSERNAME As System.Windows.Forms.TextBox
    Public WithEvents txtPOSITION As System.Windows.Forms.TextBox
    Public WithEvents txtDEPCODE As System.Windows.Forms.TextBox
    Public WithEvents txtDOMAIN As System.Windows.Forms.TextBox
    Public WithEvents txtTYPE As System.Windows.Forms.TextBox
    Public WithEvents txtID As System.Windows.Forms.TextBox
    Public WithEvents txtDEPARTMENT As System.Windows.Forms.TextBox
    Public WithEvents txtCLASS As System.Windows.Forms.TextBox
    Public WithEvents txtCODE As System.Windows.Forms.TextBox
    Public WithEvents txtWAREHOUSENAME As System.Windows.Forms.TextBox
    Public WithEvents txtWAREHOUSE_POSITION As System.Windows.Forms.TextBox
    Public WithEvents txtWAREHOUSESHARED As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
