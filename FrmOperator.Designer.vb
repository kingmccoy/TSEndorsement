<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOperator
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
        Me.TboxOptIDNo = New System.Windows.Forms.TextBox()
        Me.LblOptIDNo = New System.Windows.Forms.Label()
        Me.TboxOptFName = New System.Windows.Forms.TextBox()
        Me.LblOptFName = New System.Windows.Forms.Label()
        Me.TboxOptMName = New System.Windows.Forms.TextBox()
        Me.LblOptMName = New System.Windows.Forms.Label()
        Me.TboxOptLName = New System.Windows.Forms.TextBox()
        Me.LblOptLName = New System.Windows.Forms.Label()
        Me.TboxOptUsername = New System.Windows.Forms.TextBox()
        Me.LblOptUsername = New System.Windows.Forms.Label()
        Me.TboxOptPsk = New System.Windows.Forms.TextBox()
        Me.LblOptPsk = New System.Windows.Forms.Label()
        Me.BtnOptClear = New System.Windows.Forms.Button()
        Me.BtnOptAdd = New System.Windows.Forms.Button()
        Me.DgvOpt = New System.Windows.Forms.DataGridView()
        Me.RBtnOptEnable = New System.Windows.Forms.RadioButton()
        Me.RBtnOptDisable = New System.Windows.Forms.RadioButton()
        Me.BtnOptAppy = New System.Windows.Forms.Button()
        Me.BtnOptEdit = New System.Windows.Forms.Button()
        Me.BtnOptDelete = New System.Windows.Forms.Button()
        Me.LblOptStatus = New System.Windows.Forms.Label()
        Me.LblOptStatusCurrent = New System.Windows.Forms.Label()
        Me.LblCheckExstLotStatus = New System.Windows.Forms.Label()
        Me.LblCheckExstLotStatusCurrent = New System.Windows.Forms.Label()
        Me.RBtnExstLotDisable = New System.Windows.Forms.RadioButton()
        Me.RBtnExstLotEnable = New System.Windows.Forms.RadioButton()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdnoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FirstnameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MiddlenameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastnameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsernameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PasswordDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DTOperatorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSOperator = New TS_Endorsement.DSOperator()
        Me.GboxOptFunction = New System.Windows.Forms.GroupBox()
        Me.GboxCheckExstLotFunction = New System.Windows.Forms.GroupBox()
        CType(Me.DgvOpt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTOperatorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSOperator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GboxOptFunction.SuspendLayout()
        Me.GboxCheckExstLotFunction.SuspendLayout()
        Me.SuspendLayout()
        '
        'TboxOptIDNo
        '
        Me.TboxOptIDNo.Location = New System.Drawing.Point(12, 25)
        Me.TboxOptIDNo.Name = "TboxOptIDNo"
        Me.TboxOptIDNo.Size = New System.Drawing.Size(209, 22)
        Me.TboxOptIDNo.TabIndex = 1
        Me.TboxOptIDNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblOptIDNo
        '
        Me.LblOptIDNo.AutoSize = True
        Me.LblOptIDNo.Location = New System.Drawing.Point(12, 9)
        Me.LblOptIDNo.Name = "LblOptIDNo"
        Me.LblOptIDNo.Size = New System.Drawing.Size(62, 13)
        Me.LblOptIDNo.TabIndex = 0
        Me.LblOptIDNo.Text = "ID Number"
        '
        'TboxOptFName
        '
        Me.TboxOptFName.Location = New System.Drawing.Point(12, 66)
        Me.TboxOptFName.Name = "TboxOptFName"
        Me.TboxOptFName.Size = New System.Drawing.Size(209, 22)
        Me.TboxOptFName.TabIndex = 3
        Me.TboxOptFName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblOptFName
        '
        Me.LblOptFName.AutoSize = True
        Me.LblOptFName.Location = New System.Drawing.Point(12, 50)
        Me.LblOptFName.Name = "LblOptFName"
        Me.LblOptFName.Size = New System.Drawing.Size(61, 13)
        Me.LblOptFName.TabIndex = 2
        Me.LblOptFName.Text = "First Name"
        '
        'TboxOptMName
        '
        Me.TboxOptMName.Location = New System.Drawing.Point(12, 107)
        Me.TboxOptMName.Name = "TboxOptMName"
        Me.TboxOptMName.Size = New System.Drawing.Size(209, 22)
        Me.TboxOptMName.TabIndex = 5
        Me.TboxOptMName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblOptMName
        '
        Me.LblOptMName.AutoSize = True
        Me.LblOptMName.Location = New System.Drawing.Point(12, 91)
        Me.LblOptMName.Name = "LblOptMName"
        Me.LblOptMName.Size = New System.Drawing.Size(75, 13)
        Me.LblOptMName.TabIndex = 4
        Me.LblOptMName.Text = "Middle Name"
        '
        'TboxOptLName
        '
        Me.TboxOptLName.Location = New System.Drawing.Point(12, 148)
        Me.TboxOptLName.Name = "TboxOptLName"
        Me.TboxOptLName.Size = New System.Drawing.Size(209, 22)
        Me.TboxOptLName.TabIndex = 7
        Me.TboxOptLName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblOptLName
        '
        Me.LblOptLName.AutoSize = True
        Me.LblOptLName.Location = New System.Drawing.Point(12, 132)
        Me.LblOptLName.Name = "LblOptLName"
        Me.LblOptLName.Size = New System.Drawing.Size(59, 13)
        Me.LblOptLName.TabIndex = 6
        Me.LblOptLName.Text = "Last Name"
        '
        'TboxOptUsername
        '
        Me.TboxOptUsername.Location = New System.Drawing.Point(12, 189)
        Me.TboxOptUsername.Name = "TboxOptUsername"
        Me.TboxOptUsername.Size = New System.Drawing.Size(209, 22)
        Me.TboxOptUsername.TabIndex = 9
        Me.TboxOptUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblOptUsername
        '
        Me.LblOptUsername.AutoSize = True
        Me.LblOptUsername.Location = New System.Drawing.Point(12, 173)
        Me.LblOptUsername.Name = "LblOptUsername"
        Me.LblOptUsername.Size = New System.Drawing.Size(58, 13)
        Me.LblOptUsername.TabIndex = 8
        Me.LblOptUsername.Text = "Username"
        '
        'TboxOptPsk
        '
        Me.TboxOptPsk.Location = New System.Drawing.Point(12, 230)
        Me.TboxOptPsk.Name = "TboxOptPsk"
        Me.TboxOptPsk.Size = New System.Drawing.Size(209, 22)
        Me.TboxOptPsk.TabIndex = 11
        Me.TboxOptPsk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblOptPsk
        '
        Me.LblOptPsk.AutoSize = True
        Me.LblOptPsk.Location = New System.Drawing.Point(12, 214)
        Me.LblOptPsk.Name = "LblOptPsk"
        Me.LblOptPsk.Size = New System.Drawing.Size(56, 13)
        Me.LblOptPsk.TabIndex = 10
        Me.LblOptPsk.Text = "Password"
        '
        'BtnOptClear
        '
        Me.BtnOptClear.Location = New System.Drawing.Point(65, 258)
        Me.BtnOptClear.Name = "BtnOptClear"
        Me.BtnOptClear.Size = New System.Drawing.Size(75, 32)
        Me.BtnOptClear.TabIndex = 12
        Me.BtnOptClear.Text = "Clear"
        Me.BtnOptClear.UseVisualStyleBackColor = True
        '
        'BtnOptAdd
        '
        Me.BtnOptAdd.Location = New System.Drawing.Point(146, 258)
        Me.BtnOptAdd.Name = "BtnOptAdd"
        Me.BtnOptAdd.Size = New System.Drawing.Size(75, 32)
        Me.BtnOptAdd.TabIndex = 13
        Me.BtnOptAdd.Text = "Add"
        Me.BtnOptAdd.UseVisualStyleBackColor = True
        '
        'DgvOpt
        '
        Me.DgvOpt.AllowUserToAddRows = False
        Me.DgvOpt.AllowUserToDeleteRows = False
        Me.DgvOpt.AllowUserToResizeRows = False
        Me.DgvOpt.AutoGenerateColumns = False
        Me.DgvOpt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgvOpt.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DgvOpt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgvOpt.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.IdnoDataGridViewTextBoxColumn, Me.FirstnameDataGridViewTextBoxColumn, Me.MiddlenameDataGridViewTextBoxColumn, Me.LastnameDataGridViewTextBoxColumn, Me.UsernameDataGridViewTextBoxColumn, Me.PasswordDataGridViewTextBoxColumn})
        Me.DgvOpt.DataSource = Me.DTOperatorBindingSource
        Me.DgvOpt.Location = New System.Drawing.Point(243, 12)
        Me.DgvOpt.Name = "DgvOpt"
        Me.DgvOpt.ReadOnly = True
        Me.DgvOpt.RowHeadersVisible = False
        Me.DgvOpt.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DgvOpt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvOpt.Size = New System.Drawing.Size(572, 278)
        Me.DgvOpt.TabIndex = 14
        '
        'RBtnOptEnable
        '
        Me.RBtnOptEnable.AutoSize = True
        Me.RBtnOptEnable.Checked = True
        Me.RBtnOptEnable.Location = New System.Drawing.Point(6, 21)
        Me.RBtnOptEnable.Name = "RBtnOptEnable"
        Me.RBtnOptEnable.Size = New System.Drawing.Size(59, 17)
        Me.RBtnOptEnable.TabIndex = 15
        Me.RBtnOptEnable.TabStop = True
        Me.RBtnOptEnable.Text = "Enable"
        Me.RBtnOptEnable.UseVisualStyleBackColor = True
        '
        'RBtnOptDisable
        '
        Me.RBtnOptDisable.AutoSize = True
        Me.RBtnOptDisable.Location = New System.Drawing.Point(72, 21)
        Me.RBtnOptDisable.Name = "RBtnOptDisable"
        Me.RBtnOptDisable.Size = New System.Drawing.Size(63, 17)
        Me.RBtnOptDisable.TabIndex = 16
        Me.RBtnOptDisable.Text = "Disable"
        Me.RBtnOptDisable.UseVisualStyleBackColor = True
        '
        'BtnOptAppy
        '
        Me.BtnOptAppy.Location = New System.Drawing.Point(740, 304)
        Me.BtnOptAppy.Name = "BtnOptAppy"
        Me.BtnOptAppy.Size = New System.Drawing.Size(75, 32)
        Me.BtnOptAppy.TabIndex = 13
        Me.BtnOptAppy.Text = "Apply"
        Me.BtnOptAppy.UseVisualStyleBackColor = True
        '
        'BtnOptEdit
        '
        Me.BtnOptEdit.Location = New System.Drawing.Point(243, 304)
        Me.BtnOptEdit.Name = "BtnOptEdit"
        Me.BtnOptEdit.Size = New System.Drawing.Size(75, 32)
        Me.BtnOptEdit.TabIndex = 18
        Me.BtnOptEdit.Text = "Edit"
        Me.BtnOptEdit.UseVisualStyleBackColor = True
        '
        'BtnOptDelete
        '
        Me.BtnOptDelete.Location = New System.Drawing.Point(324, 304)
        Me.BtnOptDelete.Name = "BtnOptDelete"
        Me.BtnOptDelete.Size = New System.Drawing.Size(75, 32)
        Me.BtnOptDelete.TabIndex = 19
        Me.BtnOptDelete.Text = "Delete"
        Me.BtnOptDelete.UseVisualStyleBackColor = True
        '
        'LblOptStatus
        '
        Me.LblOptStatus.AutoSize = True
        Me.LblOptStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOptStatus.Location = New System.Drawing.Point(40, 304)
        Me.LblOptStatus.Name = "LblOptStatus"
        Me.LblOptStatus.Size = New System.Drawing.Size(88, 13)
        Me.LblOptStatus.TabIndex = 20
        Me.LblOptStatus.Text = "Operator Status:"
        '
        'LblOptStatusCurrent
        '
        Me.LblOptStatusCurrent.AutoSize = True
        Me.LblOptStatusCurrent.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOptStatusCurrent.ForeColor = System.Drawing.Color.Green
        Me.LblOptStatusCurrent.Location = New System.Drawing.Point(143, 304)
        Me.LblOptStatusCurrent.Name = "LblOptStatusCurrent"
        Me.LblOptStatusCurrent.Size = New System.Drawing.Size(47, 13)
        Me.LblOptStatusCurrent.TabIndex = 21
        Me.LblOptStatusCurrent.Text = "ENABLE"
        '
        'LblCheckExstLotStatus
        '
        Me.LblCheckExstLotStatus.AutoSize = True
        Me.LblCheckExstLotStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCheckExstLotStatus.Location = New System.Drawing.Point(12, 323)
        Me.LblCheckExstLotStatus.Name = "LblCheckExstLotStatus"
        Me.LblCheckExstLotStatus.Size = New System.Drawing.Size(116, 13)
        Me.LblCheckExstLotStatus.TabIndex = 22
        Me.LblCheckExstLotStatus.Text = "Check Existing Status:"
        '
        'LblCheckExstLotStatusCurrent
        '
        Me.LblCheckExstLotStatusCurrent.AutoSize = True
        Me.LblCheckExstLotStatusCurrent.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCheckExstLotStatusCurrent.ForeColor = System.Drawing.Color.Green
        Me.LblCheckExstLotStatusCurrent.Location = New System.Drawing.Point(143, 323)
        Me.LblCheckExstLotStatusCurrent.Name = "LblCheckExstLotStatusCurrent"
        Me.LblCheckExstLotStatusCurrent.Size = New System.Drawing.Size(47, 13)
        Me.LblCheckExstLotStatusCurrent.TabIndex = 23
        Me.LblCheckExstLotStatusCurrent.Text = "ENABLE"
        '
        'RBtnExstLotDisable
        '
        Me.RBtnExstLotDisable.AutoSize = True
        Me.RBtnExstLotDisable.Location = New System.Drawing.Point(72, 21)
        Me.RBtnExstLotDisable.Name = "RBtnExstLotDisable"
        Me.RBtnExstLotDisable.Size = New System.Drawing.Size(63, 17)
        Me.RBtnExstLotDisable.TabIndex = 25
        Me.RBtnExstLotDisable.Text = "Disable"
        Me.RBtnExstLotDisable.UseVisualStyleBackColor = True
        '
        'RBtnExstLotEnable
        '
        Me.RBtnExstLotEnable.AutoSize = True
        Me.RBtnExstLotEnable.Checked = True
        Me.RBtnExstLotEnable.Location = New System.Drawing.Point(6, 21)
        Me.RBtnExstLotEnable.Name = "RBtnExstLotEnable"
        Me.RBtnExstLotEnable.Size = New System.Drawing.Size(59, 17)
        Me.RBtnExstLotEnable.TabIndex = 24
        Me.RBtnExstLotEnable.TabStop = True
        Me.RBtnExstLotEnable.Text = "Enable"
        Me.RBtnExstLotEnable.UseVisualStyleBackColor = True
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.FillWeight = 50.0!
        Me.IdDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IdnoDataGridViewTextBoxColumn
        '
        Me.IdnoDataGridViewTextBoxColumn.DataPropertyName = "id_no"
        Me.IdnoDataGridViewTextBoxColumn.HeaderText = "ID No"
        Me.IdnoDataGridViewTextBoxColumn.Name = "IdnoDataGridViewTextBoxColumn"
        Me.IdnoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FirstnameDataGridViewTextBoxColumn
        '
        Me.FirstnameDataGridViewTextBoxColumn.DataPropertyName = "first_name"
        Me.FirstnameDataGridViewTextBoxColumn.HeaderText = "First Name"
        Me.FirstnameDataGridViewTextBoxColumn.Name = "FirstnameDataGridViewTextBoxColumn"
        Me.FirstnameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MiddlenameDataGridViewTextBoxColumn
        '
        Me.MiddlenameDataGridViewTextBoxColumn.DataPropertyName = "middle_name"
        Me.MiddlenameDataGridViewTextBoxColumn.HeaderText = "Middle Name"
        Me.MiddlenameDataGridViewTextBoxColumn.Name = "MiddlenameDataGridViewTextBoxColumn"
        Me.MiddlenameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LastnameDataGridViewTextBoxColumn
        '
        Me.LastnameDataGridViewTextBoxColumn.DataPropertyName = "last_name"
        Me.LastnameDataGridViewTextBoxColumn.HeaderText = "Last Name"
        Me.LastnameDataGridViewTextBoxColumn.Name = "LastnameDataGridViewTextBoxColumn"
        Me.LastnameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'UsernameDataGridViewTextBoxColumn
        '
        Me.UsernameDataGridViewTextBoxColumn.DataPropertyName = "username"
        Me.UsernameDataGridViewTextBoxColumn.HeaderText = "Username"
        Me.UsernameDataGridViewTextBoxColumn.Name = "UsernameDataGridViewTextBoxColumn"
        Me.UsernameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PasswordDataGridViewTextBoxColumn
        '
        Me.PasswordDataGridViewTextBoxColumn.DataPropertyName = "password"
        Me.PasswordDataGridViewTextBoxColumn.HeaderText = "Password"
        Me.PasswordDataGridViewTextBoxColumn.Name = "PasswordDataGridViewTextBoxColumn"
        Me.PasswordDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DTOperatorBindingSource
        '
        Me.DTOperatorBindingSource.DataMember = "DTOperator"
        Me.DTOperatorBindingSource.DataSource = Me.DSOperator
        '
        'DSOperator
        '
        Me.DSOperator.DataSetName = "DSOperator"
        Me.DSOperator.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GboxOptFunction
        '
        Me.GboxOptFunction.Controls.Add(Me.RBtnOptDisable)
        Me.GboxOptFunction.Controls.Add(Me.RBtnOptEnable)
        Me.GboxOptFunction.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GboxOptFunction.Location = New System.Drawing.Point(430, 296)
        Me.GboxOptFunction.Name = "GboxOptFunction"
        Me.GboxOptFunction.Size = New System.Drawing.Size(138, 48)
        Me.GboxOptFunction.TabIndex = 27
        Me.GboxOptFunction.TabStop = False
        Me.GboxOptFunction.Text = "Operator Function"
        '
        'GboxCheckExstLotFunction
        '
        Me.GboxCheckExstLotFunction.Controls.Add(Me.RBtnExstLotDisable)
        Me.GboxCheckExstLotFunction.Controls.Add(Me.RBtnExstLotEnable)
        Me.GboxCheckExstLotFunction.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GboxCheckExstLotFunction.Location = New System.Drawing.Point(574, 296)
        Me.GboxCheckExstLotFunction.Name = "GboxCheckExstLotFunction"
        Me.GboxCheckExstLotFunction.Size = New System.Drawing.Size(138, 48)
        Me.GboxCheckExstLotFunction.TabIndex = 28
        Me.GboxCheckExstLotFunction.TabStop = False
        Me.GboxCheckExstLotFunction.Text = "Existing Lot Function:"
        '
        'FrmOperator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 352)
        Me.Controls.Add(Me.GboxCheckExstLotFunction)
        Me.Controls.Add(Me.GboxOptFunction)
        Me.Controls.Add(Me.LblCheckExstLotStatusCurrent)
        Me.Controls.Add(Me.LblCheckExstLotStatus)
        Me.Controls.Add(Me.LblOptStatusCurrent)
        Me.Controls.Add(Me.LblOptStatus)
        Me.Controls.Add(Me.BtnOptDelete)
        Me.Controls.Add(Me.BtnOptEdit)
        Me.Controls.Add(Me.DgvOpt)
        Me.Controls.Add(Me.BtnOptAppy)
        Me.Controls.Add(Me.BtnOptAdd)
        Me.Controls.Add(Me.BtnOptClear)
        Me.Controls.Add(Me.LblOptPsk)
        Me.Controls.Add(Me.LblOptUsername)
        Me.Controls.Add(Me.TboxOptPsk)
        Me.Controls.Add(Me.LblOptLName)
        Me.Controls.Add(Me.TboxOptUsername)
        Me.Controls.Add(Me.LblOptMName)
        Me.Controls.Add(Me.TboxOptLName)
        Me.Controls.Add(Me.LblOptFName)
        Me.Controls.Add(Me.TboxOptMName)
        Me.Controls.Add(Me.LblOptIDNo)
        Me.Controls.Add(Me.TboxOptFName)
        Me.Controls.Add(Me.TboxOptIDNo)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOperator"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Operator"
        CType(Me.DgvOpt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTOperatorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSOperator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GboxOptFunction.ResumeLayout(False)
        Me.GboxOptFunction.PerformLayout()
        Me.GboxCheckExstLotFunction.ResumeLayout(False)
        Me.GboxCheckExstLotFunction.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TboxOptIDNo As TextBox
    Friend WithEvents LblOptIDNo As Label
    Friend WithEvents TboxOptFName As TextBox
    Friend WithEvents LblOptFName As Label
    Friend WithEvents TboxOptMName As TextBox
    Friend WithEvents LblOptMName As Label
    Friend WithEvents TboxOptLName As TextBox
    Friend WithEvents LblOptLName As Label
    Friend WithEvents TboxOptUsername As TextBox
    Friend WithEvents LblOptUsername As Label
    Friend WithEvents TboxOptPsk As TextBox
    Friend WithEvents LblOptPsk As Label
    Friend WithEvents BtnOptClear As Button
    Friend WithEvents BtnOptAdd As Button
    Friend WithEvents DgvOpt As DataGridView
    Friend WithEvents RBtnOptEnable As RadioButton
    Friend WithEvents RBtnOptDisable As RadioButton
    Friend WithEvents BtnOptAppy As Button
    Friend WithEvents DTOperatorBindingSource As BindingSource
    Friend WithEvents DSOperator As DSOperator
    Friend WithEvents BtnOptEdit As Button
    Friend WithEvents BtnOptDelete As Button
    Friend WithEvents LblOptStatus As Label
    Friend WithEvents LblOptStatusCurrent As Label
    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdnoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FirstnameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MiddlenameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LastnameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UsernameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PasswordDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LblCheckExstLotStatus As Label
    Friend WithEvents LblCheckExstLotStatusCurrent As Label
    Friend WithEvents RBtnExstLotDisable As RadioButton
    Friend WithEvents RBtnExstLotEnable As RadioButton
    Friend WithEvents GboxOptFunction As GroupBox
    Friend WithEvents GboxCheckExstLotFunction As GroupBox
End Class
