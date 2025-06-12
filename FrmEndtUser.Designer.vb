<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEndtUser
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
        Me.TboxEndtUsername = New System.Windows.Forms.TextBox()
        Me.BtnEndtLogin = New System.Windows.Forms.Button()
        Me.TboxEndtPsk = New System.Windows.Forms.TextBox()
        Me.LblEndtUsername = New System.Windows.Forms.Label()
        Me.LblEndtPsk = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TboxEndtUsername
        '
        Me.TboxEndtUsername.Location = New System.Drawing.Point(12, 25)
        Me.TboxEndtUsername.Name = "TboxEndtUsername"
        Me.TboxEndtUsername.Size = New System.Drawing.Size(170, 22)
        Me.TboxEndtUsername.TabIndex = 1
        '
        'BtnEndtLogin
        '
        Me.BtnEndtLogin.Location = New System.Drawing.Point(107, 94)
        Me.BtnEndtLogin.Name = "BtnEndtLogin"
        Me.BtnEndtLogin.Size = New System.Drawing.Size(75, 28)
        Me.BtnEndtLogin.TabIndex = 4
        Me.BtnEndtLogin.Text = "Login"
        Me.BtnEndtLogin.UseVisualStyleBackColor = True
        '
        'TboxEndtPsk
        '
        Me.TboxEndtPsk.Location = New System.Drawing.Point(12, 66)
        Me.TboxEndtPsk.Name = "TboxEndtPsk"
        Me.TboxEndtPsk.Size = New System.Drawing.Size(170, 22)
        Me.TboxEndtPsk.TabIndex = 3
        '
        'LblEndtUsername
        '
        Me.LblEndtUsername.AutoSize = True
        Me.LblEndtUsername.Location = New System.Drawing.Point(12, 9)
        Me.LblEndtUsername.Name = "LblEndtUsername"
        Me.LblEndtUsername.Size = New System.Drawing.Size(58, 13)
        Me.LblEndtUsername.TabIndex = 0
        Me.LblEndtUsername.Text = "Username"
        '
        'LblEndtPsk
        '
        Me.LblEndtPsk.AutoSize = True
        Me.LblEndtPsk.Location = New System.Drawing.Point(12, 50)
        Me.LblEndtPsk.Name = "LblEndtPsk"
        Me.LblEndtPsk.Size = New System.Drawing.Size(56, 13)
        Me.LblEndtPsk.TabIndex = 2
        Me.LblEndtPsk.Text = "Password"
        '
        'FrmEndtUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(194, 132)
        Me.Controls.Add(Me.LblEndtPsk)
        Me.Controls.Add(Me.LblEndtUsername)
        Me.Controls.Add(Me.BtnEndtLogin)
        Me.Controls.Add(Me.TboxEndtPsk)
        Me.Controls.Add(Me.TboxEndtUsername)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmEndtUser"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Endorsement User"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TboxEndtUsername As TextBox
    Friend WithEvents BtnEndtLogin As Button
    Friend WithEvents TboxEndtPsk As TextBox
    Friend WithEvents LblEndtUsername As Label
    Friend WithEvents LblEndtPsk As Label
End Class
