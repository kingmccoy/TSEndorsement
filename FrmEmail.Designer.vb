<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmail
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
        Me.components = New System.ComponentModel.Container()
        Me.TboxEmailSMTPServer = New System.Windows.Forms.TextBox()
        Me.LblEmailSMTPServer = New System.Windows.Forms.Label()
        Me.BtnEmailSMTPClear = New System.Windows.Forms.Button()
        Me.TboxEmailSMTPPort = New System.Windows.Forms.TextBox()
        Me.GboxEmailSMTP = New System.Windows.Forms.GroupBox()
        Me.LblEmailSMTPPort = New System.Windows.Forms.Label()
        Me.GboxEmailCredential = New System.Windows.Forms.GroupBox()
        Me.LblEmailCredPass = New System.Windows.Forms.Label()
        Me.TboxEmailCredEmail = New System.Windows.Forms.TextBox()
        Me.TboxEmailCredPass = New System.Windows.Forms.TextBox()
        Me.LblEmailCredEmail = New System.Windows.Forms.Label()
        Me.BtnEmailCredClear = New System.Windows.Forms.Button()
        Me.DgvRecipient = New System.Windows.Forms.DataGridView()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmailDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DTEmailRecipientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSEmailRecipient = New TS_Endorsement.DSEmailRecipient()
        Me.GboxEmailRecipient = New System.Windows.Forms.GroupBox()
        Me.BtnRecipientDelete = New System.Windows.Forms.Button()
        Me.BtnRecipientClear = New System.Windows.Forms.Button()
        Me.BtnRecipientAdd = New System.Windows.Forms.Button()
        Me.TboxRecipientEmail = New System.Windows.Forms.TextBox()
        Me.LblRecipientEmail = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BtnEmailSentTest = New System.Windows.Forms.Button()
        Me.BtnEmailSave = New System.Windows.Forms.Button()
        Me.GboxEmailSMTP.SuspendLayout()
        Me.GboxEmailCredential.SuspendLayout()
        CType(Me.DgvRecipient, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTEmailRecipientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSEmailRecipient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GboxEmailRecipient.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TboxEmailSMTPServer
        '
        Me.TboxEmailSMTPServer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TboxEmailSMTPServer.Location = New System.Drawing.Point(6, 34)
        Me.TboxEmailSMTPServer.Name = "TboxEmailSMTPServer"
        Me.TboxEmailSMTPServer.Size = New System.Drawing.Size(194, 22)
        Me.TboxEmailSMTPServer.TabIndex = 1
        '
        'LblEmailSMTPServer
        '
        Me.LblEmailSMTPServer.AutoSize = True
        Me.LblEmailSMTPServer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmailSMTPServer.Location = New System.Drawing.Point(6, 18)
        Me.LblEmailSMTPServer.Name = "LblEmailSMTPServer"
        Me.LblEmailSMTPServer.Size = New System.Drawing.Size(38, 13)
        Me.LblEmailSMTPServer.TabIndex = 0
        Me.LblEmailSMTPServer.Text = "Server"
        '
        'BtnEmailSMTPClear
        '
        Me.BtnEmailSMTPClear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEmailSMTPClear.Location = New System.Drawing.Point(406, 31)
        Me.BtnEmailSMTPClear.Name = "BtnEmailSMTPClear"
        Me.BtnEmailSMTPClear.Size = New System.Drawing.Size(72, 28)
        Me.BtnEmailSMTPClear.TabIndex = 4
        Me.BtnEmailSMTPClear.Text = "Clear"
        Me.BtnEmailSMTPClear.UseVisualStyleBackColor = True
        '
        'TboxEmailSMTPPort
        '
        Me.TboxEmailSMTPPort.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TboxEmailSMTPPort.Location = New System.Drawing.Point(206, 34)
        Me.TboxEmailSMTPPort.Name = "TboxEmailSMTPPort"
        Me.TboxEmailSMTPPort.Size = New System.Drawing.Size(194, 22)
        Me.TboxEmailSMTPPort.TabIndex = 3
        '
        'GboxEmailSMTP
        '
        Me.GboxEmailSMTP.Controls.Add(Me.LblEmailSMTPPort)
        Me.GboxEmailSMTP.Controls.Add(Me.TboxEmailSMTPServer)
        Me.GboxEmailSMTP.Controls.Add(Me.TboxEmailSMTPPort)
        Me.GboxEmailSMTP.Controls.Add(Me.LblEmailSMTPServer)
        Me.GboxEmailSMTP.Controls.Add(Me.BtnEmailSMTPClear)
        Me.GboxEmailSMTP.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GboxEmailSMTP.Location = New System.Drawing.Point(12, 12)
        Me.GboxEmailSMTP.Name = "GboxEmailSMTP"
        Me.GboxEmailSMTP.Size = New System.Drawing.Size(484, 74)
        Me.GboxEmailSMTP.TabIndex = 0
        Me.GboxEmailSMTP.TabStop = False
        Me.GboxEmailSMTP.Text = "SMTP"
        '
        'LblEmailSMTPPort
        '
        Me.LblEmailSMTPPort.AutoSize = True
        Me.LblEmailSMTPPort.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmailSMTPPort.Location = New System.Drawing.Point(206, 18)
        Me.LblEmailSMTPPort.Name = "LblEmailSMTPPort"
        Me.LblEmailSMTPPort.Size = New System.Drawing.Size(28, 13)
        Me.LblEmailSMTPPort.TabIndex = 2
        Me.LblEmailSMTPPort.Text = "Port"
        '
        'GboxEmailCredential
        '
        Me.GboxEmailCredential.Controls.Add(Me.LblEmailCredPass)
        Me.GboxEmailCredential.Controls.Add(Me.TboxEmailCredEmail)
        Me.GboxEmailCredential.Controls.Add(Me.TboxEmailCredPass)
        Me.GboxEmailCredential.Controls.Add(Me.LblEmailCredEmail)
        Me.GboxEmailCredential.Controls.Add(Me.BtnEmailCredClear)
        Me.GboxEmailCredential.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GboxEmailCredential.Location = New System.Drawing.Point(12, 92)
        Me.GboxEmailCredential.Name = "GboxEmailCredential"
        Me.GboxEmailCredential.Size = New System.Drawing.Size(484, 74)
        Me.GboxEmailCredential.TabIndex = 1
        Me.GboxEmailCredential.TabStop = False
        Me.GboxEmailCredential.Text = "Credential"
        '
        'LblEmailCredPass
        '
        Me.LblEmailCredPass.AutoSize = True
        Me.LblEmailCredPass.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmailCredPass.Location = New System.Drawing.Point(206, 18)
        Me.LblEmailCredPass.Name = "LblEmailCredPass"
        Me.LblEmailCredPass.Size = New System.Drawing.Size(56, 13)
        Me.LblEmailCredPass.TabIndex = 2
        Me.LblEmailCredPass.Text = "Password"
        '
        'TboxEmailCredEmail
        '
        Me.TboxEmailCredEmail.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TboxEmailCredEmail.Location = New System.Drawing.Point(6, 34)
        Me.TboxEmailCredEmail.Name = "TboxEmailCredEmail"
        Me.TboxEmailCredEmail.Size = New System.Drawing.Size(194, 22)
        Me.TboxEmailCredEmail.TabIndex = 1
        '
        'TboxEmailCredPass
        '
        Me.TboxEmailCredPass.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TboxEmailCredPass.Location = New System.Drawing.Point(206, 34)
        Me.TboxEmailCredPass.Name = "TboxEmailCredPass"
        Me.TboxEmailCredPass.Size = New System.Drawing.Size(194, 22)
        Me.TboxEmailCredPass.TabIndex = 3
        '
        'LblEmailCredEmail
        '
        Me.LblEmailCredEmail.AutoSize = True
        Me.LblEmailCredEmail.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmailCredEmail.Location = New System.Drawing.Point(6, 18)
        Me.LblEmailCredEmail.Name = "LblEmailCredEmail"
        Me.LblEmailCredEmail.Size = New System.Drawing.Size(34, 13)
        Me.LblEmailCredEmail.TabIndex = 0
        Me.LblEmailCredEmail.Text = "Email"
        '
        'BtnEmailCredClear
        '
        Me.BtnEmailCredClear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEmailCredClear.Location = New System.Drawing.Point(406, 31)
        Me.BtnEmailCredClear.Name = "BtnEmailCredClear"
        Me.BtnEmailCredClear.Size = New System.Drawing.Size(72, 28)
        Me.BtnEmailCredClear.TabIndex = 4
        Me.BtnEmailCredClear.Text = "Clear"
        Me.BtnEmailCredClear.UseVisualStyleBackColor = True
        '
        'DgvRecipient
        '
        Me.DgvRecipient.AllowUserToAddRows = False
        Me.DgvRecipient.AllowUserToDeleteRows = False
        Me.DgvRecipient.AllowUserToResizeRows = False
        Me.DgvRecipient.AutoGenerateColumns = False
        Me.DgvRecipient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgvRecipient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRecipient.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.EmailDataGridViewTextBoxColumn})
        Me.DgvRecipient.DataSource = Me.DTEmailRecipientBindingSource
        Me.DgvRecipient.Location = New System.Drawing.Point(6, 62)
        Me.DgvRecipient.Name = "DgvRecipient"
        Me.DgvRecipient.ReadOnly = True
        Me.DgvRecipient.RowHeadersVisible = False
        Me.DgvRecipient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvRecipient.Size = New System.Drawing.Size(472, 198)
        Me.DgvRecipient.TabIndex = 5
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.FillWeight = 20.0!
        Me.IdDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EmailDataGridViewTextBoxColumn
        '
        Me.EmailDataGridViewTextBoxColumn.DataPropertyName = "email"
        Me.EmailDataGridViewTextBoxColumn.FillWeight = 149.2386!
        Me.EmailDataGridViewTextBoxColumn.HeaderText = "Email"
        Me.EmailDataGridViewTextBoxColumn.Name = "EmailDataGridViewTextBoxColumn"
        Me.EmailDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DTEmailRecipientBindingSource
        '
        Me.DTEmailRecipientBindingSource.DataMember = "DTEmailRecipient"
        Me.DTEmailRecipientBindingSource.DataSource = Me.DSEmailRecipient
        '
        'DSEmailRecipient
        '
        Me.DSEmailRecipient.DataSetName = "DSEmailRecipient"
        Me.DSEmailRecipient.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GboxEmailRecipient
        '
        Me.GboxEmailRecipient.Controls.Add(Me.BtnRecipientDelete)
        Me.GboxEmailRecipient.Controls.Add(Me.BtnRecipientClear)
        Me.GboxEmailRecipient.Controls.Add(Me.BtnRecipientAdd)
        Me.GboxEmailRecipient.Controls.Add(Me.TboxRecipientEmail)
        Me.GboxEmailRecipient.Controls.Add(Me.LblRecipientEmail)
        Me.GboxEmailRecipient.Controls.Add(Me.DgvRecipient)
        Me.GboxEmailRecipient.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GboxEmailRecipient.Location = New System.Drawing.Point(12, 172)
        Me.GboxEmailRecipient.Name = "GboxEmailRecipient"
        Me.GboxEmailRecipient.Size = New System.Drawing.Size(484, 266)
        Me.GboxEmailRecipient.TabIndex = 2
        Me.GboxEmailRecipient.TabStop = False
        Me.GboxEmailRecipient.Text = "Recipient"
        '
        'BtnRecipientDelete
        '
        Me.BtnRecipientDelete.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRecipientDelete.Location = New System.Drawing.Point(375, 31)
        Me.BtnRecipientDelete.Name = "BtnRecipientDelete"
        Me.BtnRecipientDelete.Size = New System.Drawing.Size(72, 28)
        Me.BtnRecipientDelete.TabIndex = 4
        Me.BtnRecipientDelete.Text = "Delete"
        Me.BtnRecipientDelete.UseVisualStyleBackColor = True
        '
        'BtnRecipientClear
        '
        Me.BtnRecipientClear.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRecipientClear.Location = New System.Drawing.Point(297, 31)
        Me.BtnRecipientClear.Name = "BtnRecipientClear"
        Me.BtnRecipientClear.Size = New System.Drawing.Size(72, 28)
        Me.BtnRecipientClear.TabIndex = 3
        Me.BtnRecipientClear.Text = "Clear"
        Me.BtnRecipientClear.UseVisualStyleBackColor = True
        '
        'BtnRecipientAdd
        '
        Me.BtnRecipientAdd.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRecipientAdd.Location = New System.Drawing.Point(219, 31)
        Me.BtnRecipientAdd.Name = "BtnRecipientAdd"
        Me.BtnRecipientAdd.Size = New System.Drawing.Size(72, 28)
        Me.BtnRecipientAdd.TabIndex = 2
        Me.BtnRecipientAdd.Text = "Add"
        Me.BtnRecipientAdd.UseVisualStyleBackColor = True
        '
        'TboxRecipientEmail
        '
        Me.TboxRecipientEmail.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TboxRecipientEmail.Location = New System.Drawing.Point(6, 34)
        Me.TboxRecipientEmail.Name = "TboxRecipientEmail"
        Me.TboxRecipientEmail.Size = New System.Drawing.Size(194, 22)
        Me.TboxRecipientEmail.TabIndex = 1
        '
        'LblRecipientEmail
        '
        Me.LblRecipientEmail.AutoSize = True
        Me.LblRecipientEmail.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRecipientEmail.Location = New System.Drawing.Point(6, 18)
        Me.LblRecipientEmail.Name = "LblRecipientEmail"
        Me.LblRecipientEmail.Size = New System.Drawing.Size(34, 13)
        Me.LblRecipientEmail.TabIndex = 0
        Me.LblRecipientEmail.Text = "Email"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'BtnEmailSentTest
        '
        Me.BtnEmailSentTest.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEmailSentTest.Location = New System.Drawing.Point(387, 444)
        Me.BtnEmailSentTest.Name = "BtnEmailSentTest"
        Me.BtnEmailSentTest.Size = New System.Drawing.Size(109, 28)
        Me.BtnEmailSentTest.TabIndex = 3
        Me.BtnEmailSentTest.Text = "Send Test Email"
        Me.BtnEmailSentTest.UseVisualStyleBackColor = True
        '
        'BtnEmailSave
        '
        Me.BtnEmailSave.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEmailSave.Location = New System.Drawing.Point(309, 444)
        Me.BtnEmailSave.Name = "BtnEmailSave"
        Me.BtnEmailSave.Size = New System.Drawing.Size(72, 28)
        Me.BtnEmailSave.TabIndex = 5
        Me.BtnEmailSave.Text = "Save"
        Me.BtnEmailSave.UseVisualStyleBackColor = True
        '
        'FrmEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 482)
        Me.Controls.Add(Me.BtnEmailSave)
        Me.Controls.Add(Me.BtnEmailSentTest)
        Me.Controls.Add(Me.GboxEmailRecipient)
        Me.Controls.Add(Me.GboxEmailCredential)
        Me.Controls.Add(Me.GboxEmailSMTP)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmEmail"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Email"
        Me.GboxEmailSMTP.ResumeLayout(False)
        Me.GboxEmailSMTP.PerformLayout()
        Me.GboxEmailCredential.ResumeLayout(False)
        Me.GboxEmailCredential.PerformLayout()
        CType(Me.DgvRecipient, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTEmailRecipientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSEmailRecipient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GboxEmailRecipient.ResumeLayout(False)
        Me.GboxEmailRecipient.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TboxEmailSMTPServer As TextBox
    Friend WithEvents LblEmailSMTPServer As Label
    Friend WithEvents BtnEmailSMTPClear As Button
    Friend WithEvents TboxEmailSMTPPort As TextBox
    Friend WithEvents GboxEmailSMTP As GroupBox
    Friend WithEvents LblEmailSMTPPort As Label
    Friend WithEvents GboxEmailCredential As GroupBox
    Friend WithEvents LblEmailCredPass As Label
    Friend WithEvents TboxEmailCredEmail As TextBox
    Friend WithEvents TboxEmailCredPass As TextBox
    Friend WithEvents LblEmailCredEmail As Label
    Friend WithEvents BtnEmailCredClear As Button
    Friend WithEvents DgvRecipient As DataGridView
    Friend WithEvents GboxEmailRecipient As GroupBox
    Friend WithEvents BtnRecipientDelete As Button
    Friend WithEvents BtnRecipientClear As Button
    Friend WithEvents BtnRecipientAdd As Button
    Friend WithEvents TboxRecipientEmail As TextBox
    Friend WithEvents LblRecipientEmail As Label
    Friend WithEvents DTEmailRecipientBindingSource As BindingSource
    Friend WithEvents DSEmailRecipient As DSEmailRecipient
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EmailDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BtnEmailSentTest As Button
    Friend WithEvents BtnEmailSave As Button
End Class
