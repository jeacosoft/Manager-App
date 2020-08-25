<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RegisterUsers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegisterUsers))
        Me.GunaButton1 = New Guna.UI.WinForms.GunaButton()
        Me.GunaButton2 = New Guna.UI.WinForms.GunaButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GunaTextBoxname = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxdesg = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaTextBoxusername = New Guna.UI.WinForms.GunaTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GunaTextBoxpassword = New Guna.UI.WinForms.GunaTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GunaComboBoxsex = New Guna.UI.WinForms.GunaComboBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaButton1
        '
        Me.GunaButton1.AnimationHoverSpeed = 0.07!
        Me.GunaButton1.AnimationSpeed = 0.03!
        Me.GunaButton1.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaButton1.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.GunaButton1.BorderSize = 3
        Me.GunaButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton1.ForeColor = System.Drawing.Color.White
        Me.GunaButton1.Image = Nothing
        Me.GunaButton1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton1.Location = New System.Drawing.Point(12, 275)
        Me.GunaButton1.Name = "GunaButton1"
        Me.GunaButton1.OnHoverBaseColor = System.Drawing.Color.Maroon
        Me.GunaButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton1.OnHoverImage = Nothing
        Me.GunaButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton1.Radius = 10
        Me.GunaButton1.Size = New System.Drawing.Size(160, 42)
        Me.GunaButton1.TabIndex = 0
        Me.GunaButton1.Text = "SUBMIT"
        Me.GunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GunaButton2
        '
        Me.GunaButton2.AnimationHoverSpeed = 0.07!
        Me.GunaButton2.AnimationSpeed = 0.03!
        Me.GunaButton2.BackColor = System.Drawing.Color.Transparent
        Me.GunaButton2.BaseColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GunaButton2.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.GunaButton2.BorderSize = 3
        Me.GunaButton2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaButton2.FocusedColor = System.Drawing.Color.Empty
        Me.GunaButton2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaButton2.ForeColor = System.Drawing.Color.White
        Me.GunaButton2.Image = Nothing
        Me.GunaButton2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.GunaButton2.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaButton2.Location = New System.Drawing.Point(201, 275)
        Me.GunaButton2.Name = "GunaButton2"
        Me.GunaButton2.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaButton2.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaButton2.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaButton2.OnHoverImage = Nothing
        Me.GunaButton2.OnPressedColor = System.Drawing.Color.Black
        Me.GunaButton2.Radius = 10
        Me.GunaButton2.Size = New System.Drawing.Size(160, 42)
        Me.GunaButton2.TabIndex = 1
        Me.GunaButton2.Text = "CLEAR"
        Me.GunaButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Designation"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Sex"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Username"
        '
        'GunaTextBoxname
        '
        Me.GunaTextBoxname.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxname.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxname.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxname.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxname.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxname.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxname.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxname.Location = New System.Drawing.Point(73, 55)
        Me.GunaTextBoxname.Name = "GunaTextBoxname"
        Me.GunaTextBoxname.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxname.Radius = 10
        Me.GunaTextBoxname.Size = New System.Drawing.Size(269, 30)
        Me.GunaTextBoxname.TabIndex = 6
        '
        'GunaTextBoxdesg
        '
        Me.GunaTextBoxdesg.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxdesg.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxdesg.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxdesg.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxdesg.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxdesg.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxdesg.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxdesg.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxdesg.Location = New System.Drawing.Point(73, 148)
        Me.GunaTextBoxdesg.Name = "GunaTextBoxdesg"
        Me.GunaTextBoxdesg.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxdesg.Radius = 10
        Me.GunaTextBoxdesg.Size = New System.Drawing.Size(269, 30)
        Me.GunaTextBoxdesg.TabIndex = 8
        '
        'GunaTextBoxusername
        '
        Me.GunaTextBoxusername.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxusername.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxusername.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxusername.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxusername.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxusername.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxusername.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxusername.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxusername.Location = New System.Drawing.Point(73, 191)
        Me.GunaTextBoxusername.Name = "GunaTextBoxusername"
        Me.GunaTextBoxusername.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxusername.Radius = 10
        Me.GunaTextBoxusername.Size = New System.Drawing.Size(269, 30)
        Me.GunaTextBoxusername.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.MANAGER.My.Resources.Resources.download__3_3
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(1, -3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(371, 52)
        Me.Panel1.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(81, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(210, 25)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "REGISTER USERS"
        '
        'GunaTextBoxpassword
        '
        Me.GunaTextBoxpassword.BackColor = System.Drawing.Color.Transparent
        Me.GunaTextBoxpassword.BaseColor = System.Drawing.Color.White
        Me.GunaTextBoxpassword.BorderColor = System.Drawing.Color.Silver
        Me.GunaTextBoxpassword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaTextBoxpassword.FocusedBaseColor = System.Drawing.Color.White
        Me.GunaTextBoxpassword.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaTextBoxpassword.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.GunaTextBoxpassword.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaTextBoxpassword.Location = New System.Drawing.Point(73, 228)
        Me.GunaTextBoxpassword.Name = "GunaTextBoxpassword"
        Me.GunaTextBoxpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaTextBoxpassword.Radius = 10
        Me.GunaTextBoxpassword.Size = New System.Drawing.Size(269, 30)
        Me.GunaTextBoxpassword.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 236)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Password"
        '
        'GunaComboBoxsex
        '
        Me.GunaComboBoxsex.BackColor = System.Drawing.Color.Transparent
        Me.GunaComboBoxsex.BaseColor = System.Drawing.Color.White
        Me.GunaComboBoxsex.BorderColor = System.Drawing.Color.Silver
        Me.GunaComboBoxsex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.GunaComboBoxsex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.GunaComboBoxsex.FocusedColor = System.Drawing.Color.Empty
        Me.GunaComboBoxsex.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GunaComboBoxsex.ForeColor = System.Drawing.Color.Black
        Me.GunaComboBoxsex.FormattingEnabled = True
        Me.GunaComboBoxsex.Items.AddRange(New Object() {"Male", "Female"})
        Me.GunaComboBoxsex.Location = New System.Drawing.Point(73, 99)
        Me.GunaComboBoxsex.Name = "GunaComboBoxsex"
        Me.GunaComboBoxsex.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaComboBoxsex.OnHoverItemForeColor = System.Drawing.Color.White
        Me.GunaComboBoxsex.Radius = 10
        Me.GunaComboBoxsex.Size = New System.Drawing.Size(269, 26)
        Me.GunaComboBoxsex.TabIndex = 13
        '
        'RegisterUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.MANAGER.My.Resources.Resources.download__4_1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(370, 331)
        Me.Controls.Add(Me.GunaComboBoxsex)
        Me.Controls.Add(Me.GunaTextBoxpassword)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GunaTextBoxusername)
        Me.Controls.Add(Me.GunaTextBoxdesg)
        Me.Controls.Add(Me.GunaTextBoxname)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GunaButton2)
        Me.Controls.Add(Me.GunaButton1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(386, 370)
        Me.Name = "RegisterUsers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RegisterUsers"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaButton1 As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaButton2 As Guna.UI.WinForms.GunaButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GunaTextBoxname As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxdesg As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaTextBoxusername As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents GunaTextBoxpassword As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GunaComboBoxsex As Guna.UI.WinForms.GunaComboBox
End Class
