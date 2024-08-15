<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDBReference
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
        Me.TboxDBSvrName = New System.Windows.Forms.TextBox()
        Me.LblDBSvrName = New System.Windows.Forms.Label()
        Me.TboxDBPass = New System.Windows.Forms.TextBox()
        Me.LblDBPass = New System.Windows.Forms.Label()
        Me.BtnDBCancel = New System.Windows.Forms.Button()
        Me.BtnDBOK = New System.Windows.Forms.Button()
        Me.BtnDBTest = New System.Windows.Forms.Button()
        Me.TboxDBUsername = New System.Windows.Forms.TextBox()
        Me.LblDBUsername = New System.Windows.Forms.Label()
        Me.TboxDBPort = New System.Windows.Forms.TextBox()
        Me.LblDBPort = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TboxDBSvrName
        '
        Me.TboxDBSvrName.Location = New System.Drawing.Point(90, 12)
        Me.TboxDBSvrName.Name = "TboxDBSvrName"
        Me.TboxDBSvrName.Size = New System.Drawing.Size(181, 22)
        Me.TboxDBSvrName.TabIndex = 1
        '
        'LblDBSvrName
        '
        Me.LblDBSvrName.AutoSize = True
        Me.LblDBSvrName.Location = New System.Drawing.Point(12, 17)
        Me.LblDBSvrName.Name = "LblDBSvrName"
        Me.LblDBSvrName.Size = New System.Drawing.Size(72, 13)
        Me.LblDBSvrName.TabIndex = 0
        Me.LblDBSvrName.Text = "Server name:"
        '
        'TboxDBPass
        '
        Me.TboxDBPass.Location = New System.Drawing.Point(90, 96)
        Me.TboxDBPass.Name = "TboxDBPass"
        Me.TboxDBPass.Size = New System.Drawing.Size(181, 22)
        Me.TboxDBPass.TabIndex = 3
        '
        'LblDBPass
        '
        Me.LblDBPass.AutoSize = True
        Me.LblDBPass.Location = New System.Drawing.Point(25, 101)
        Me.LblDBPass.Name = "LblDBPass"
        Me.LblDBPass.Size = New System.Drawing.Size(59, 13)
        Me.LblDBPass.TabIndex = 2
        Me.LblDBPass.Text = "Password:"
        '
        'BtnDBCancel
        '
        Me.BtnDBCancel.Location = New System.Drawing.Point(196, 124)
        Me.BtnDBCancel.Name = "BtnDBCancel"
        Me.BtnDBCancel.Size = New System.Drawing.Size(75, 28)
        Me.BtnDBCancel.TabIndex = 5
        Me.BtnDBCancel.Text = "Cancel"
        Me.BtnDBCancel.UseVisualStyleBackColor = True
        '
        'BtnDBOK
        '
        Me.BtnDBOK.Location = New System.Drawing.Point(104, 124)
        Me.BtnDBOK.Name = "BtnDBOK"
        Me.BtnDBOK.Size = New System.Drawing.Size(75, 28)
        Me.BtnDBOK.TabIndex = 4
        Me.BtnDBOK.Text = "OK"
        Me.BtnDBOK.UseVisualStyleBackColor = True
        '
        'BtnDBTest
        '
        Me.BtnDBTest.Location = New System.Drawing.Point(12, 124)
        Me.BtnDBTest.Name = "BtnDBTest"
        Me.BtnDBTest.Size = New System.Drawing.Size(75, 28)
        Me.BtnDBTest.TabIndex = 4
        Me.BtnDBTest.Text = "Test"
        Me.BtnDBTest.UseVisualStyleBackColor = True
        '
        'TboxDBUsername
        '
        Me.TboxDBUsername.Location = New System.Drawing.Point(90, 68)
        Me.TboxDBUsername.Name = "TboxDBUsername"
        Me.TboxDBUsername.Size = New System.Drawing.Size(181, 22)
        Me.TboxDBUsername.TabIndex = 3
        '
        'LblDBUsername
        '
        Me.LblDBUsername.AutoSize = True
        Me.LblDBUsername.Location = New System.Drawing.Point(23, 73)
        Me.LblDBUsername.Name = "LblDBUsername"
        Me.LblDBUsername.Size = New System.Drawing.Size(61, 13)
        Me.LblDBUsername.TabIndex = 2
        Me.LblDBUsername.Text = "Username:"
        '
        'TboxDBPort
        '
        Me.TboxDBPort.Location = New System.Drawing.Point(90, 40)
        Me.TboxDBPort.Name = "TboxDBPort"
        Me.TboxDBPort.Size = New System.Drawing.Size(181, 22)
        Me.TboxDBPort.TabIndex = 1
        '
        'LblDBPort
        '
        Me.LblDBPort.AutoSize = True
        Me.LblDBPort.Location = New System.Drawing.Point(53, 45)
        Me.LblDBPort.Name = "LblDBPort"
        Me.LblDBPort.Size = New System.Drawing.Size(31, 13)
        Me.LblDBPort.TabIndex = 0
        Me.LblDBPort.Text = "Port:"
        '
        'FrmDBReference
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(283, 164)
        Me.Controls.Add(Me.BtnDBTest)
        Me.Controls.Add(Me.BtnDBOK)
        Me.Controls.Add(Me.BtnDBCancel)
        Me.Controls.Add(Me.LblDBUsername)
        Me.Controls.Add(Me.LblDBPass)
        Me.Controls.Add(Me.LblDBPort)
        Me.Controls.Add(Me.LblDBSvrName)
        Me.Controls.Add(Me.TboxDBUsername)
        Me.Controls.Add(Me.TboxDBPass)
        Me.Controls.Add(Me.TboxDBPort)
        Me.Controls.Add(Me.TboxDBSvrName)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "FrmDBReference"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Database Connection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TboxDBSvrName As TextBox
    Friend WithEvents LblDBSvrName As Label
    Friend WithEvents TboxDBPass As TextBox
    Friend WithEvents LblDBPass As Label
    Friend WithEvents BtnDBCancel As Button
    Friend WithEvents BtnDBOK As Button
    Friend WithEvents BtnDBTest As Button
    Friend WithEvents TboxDBUsername As TextBox
    Friend WithEvents LblDBUsername As Label
    Friend WithEvents TboxDBPort As TextBox
    Friend WithEvents LblDBPort As Label
End Class
