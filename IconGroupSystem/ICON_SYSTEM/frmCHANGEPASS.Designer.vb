<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCHANGEPASS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCHANGEPASS))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtVERIFYPASSWORD = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTYPE = New System.Windows.Forms.TextBox()
        Me.txtPOSITION = New System.Windows.Forms.TextBox()
        Me.txtDOMAIN = New System.Windows.Forms.TextBox()
        Me.txtDEPCODE = New System.Windows.Forms.TextBox()
        Me.txtOLDPASSWORD = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.btnSAVE = New System.Windows.Forms.Button()
        Me.txtNEWPASSWORD = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.txtVERIFYPASSWORD)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtTYPE)
        Me.Panel1.Controls.Add(Me.txtPOSITION)
        Me.Panel1.Controls.Add(Me.txtDOMAIN)
        Me.Panel1.Controls.Add(Me.txtDEPCODE)
        Me.Panel1.Controls.Add(Me.txtOLDPASSWORD)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.btnSAVE)
        Me.Panel1.Controls.Add(Me.txtNEWPASSWORD)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 68)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(392, 310)
        Me.Panel1.TabIndex = 2
        '
        'txtVERIFYPASSWORD
        '
        Me.txtVERIFYPASSWORD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVERIFYPASSWORD.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVERIFYPASSWORD.Location = New System.Drawing.Point(10, 170)
        Me.txtVERIFYPASSWORD.Name = "txtVERIFYPASSWORD"
        Me.txtVERIFYPASSWORD.Size = New System.Drawing.Size(372, 31)
        Me.txtVERIFYPASSWORD.TabIndex = 158
        Me.txtVERIFYPASSWORD.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(6, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(184, 23)
        Me.Label3.TabIndex = 157
        Me.Label3.Text = "VERIFY PASSWORD"
        '
        'txtTYPE
        '
        Me.txtTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtTYPE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTYPE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTYPE.Location = New System.Drawing.Point(458, 138)
        Me.txtTYPE.Name = "txtTYPE"
        Me.txtTYPE.Size = New System.Drawing.Size(70, 31)
        Me.txtTYPE.TabIndex = 156
        '
        'txtPOSITION
        '
        Me.txtPOSITION.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtPOSITION.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtPOSITION.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPOSITION.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPOSITION.Location = New System.Drawing.Point(458, 96)
        Me.txtPOSITION.Name = "txtPOSITION"
        Me.txtPOSITION.Size = New System.Drawing.Size(70, 31)
        Me.txtPOSITION.TabIndex = 155
        '
        'txtDOMAIN
        '
        Me.txtDOMAIN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtDOMAIN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtDOMAIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDOMAIN.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDOMAIN.Location = New System.Drawing.Point(458, 11)
        Me.txtDOMAIN.Name = "txtDOMAIN"
        Me.txtDOMAIN.Size = New System.Drawing.Size(70, 31)
        Me.txtDOMAIN.TabIndex = 153
        '
        'txtDEPCODE
        '
        Me.txtDEPCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtDEPCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtDEPCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDEPCODE.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDEPCODE.Location = New System.Drawing.Point(458, 53)
        Me.txtDEPCODE.Name = "txtDEPCODE"
        Me.txtDEPCODE.Size = New System.Drawing.Size(70, 31)
        Me.txtDEPCODE.TabIndex = 154
        '
        'txtOLDPASSWORD
        '
        Me.txtOLDPASSWORD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtOLDPASSWORD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtOLDPASSWORD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOLDPASSWORD.Enabled = False
        Me.txtOLDPASSWORD.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOLDPASSWORD.Location = New System.Drawing.Point(10, 41)
        Me.txtOLDPASSWORD.Name = "txtOLDPASSWORD"
        Me.txtOLDPASSWORD.Size = New System.Drawing.Size(372, 31)
        Me.txtOLDPASSWORD.TabIndex = 152
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gray
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Arial Black", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(28, 224)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(124, 55)
        Me.Button1.TabIndex = 151
        Me.Button1.Text = "CLOSE"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Cambria", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(210, 211)
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
        Me.btnSAVE.Location = New System.Drawing.Point(258, 241)
        Me.btnSAVE.Name = "btnSAVE"
        Me.btnSAVE.Size = New System.Drawing.Size(124, 55)
        Me.btnSAVE.TabIndex = 149
        Me.btnSAVE.Text = "CHANGE"
        Me.btnSAVE.UseVisualStyleBackColor = False
        '
        'txtNEWPASSWORD
        '
        Me.txtNEWPASSWORD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNEWPASSWORD.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNEWPASSWORD.Location = New System.Drawing.Point(10, 106)
        Me.txtNEWPASSWORD.Name = "txtNEWPASSWORD"
        Me.txtNEWPASSWORD.Size = New System.Drawing.Size(372, 31)
        Me.txtNEWPASSWORD.TabIndex = 148
        Me.txtNEWPASSWORD.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 23)
        Me.Label2.TabIndex = 147
        Me.Label2.Text = "NEW PASSWORD"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 23)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "OLD PASSWORD"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Silver
        Me.Panel2.Controls.Add(Me.txtID)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(12, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(392, 62)
        Me.Panel2.TabIndex = 24
        '
        'txtID
        '
        Me.txtID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtID.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(274, 16)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(108, 31)
        Me.txtID.TabIndex = 158
        Me.txtID.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(392, 10)
        Me.Panel3.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Black", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(-2, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(226, 46)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "PASSWORD"
        '
        'frmCHANGEPASS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(417, 395)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCHANGEPASS"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents txtTYPE As System.Windows.Forms.TextBox
    Public WithEvents txtPOSITION As System.Windows.Forms.TextBox
    Public WithEvents txtDOMAIN As System.Windows.Forms.TextBox
    Public WithEvents txtDEPCODE As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents btnSAVE As System.Windows.Forms.Button
    Friend WithEvents txtNEWPASSWORD As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVERIFYPASSWORD As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents txtOLDPASSWORD As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents txtID As System.Windows.Forms.TextBox
End Class
