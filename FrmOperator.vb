Imports System.Data.Common
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Infrastructure.DependencyResolution
Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Deployment.Application
Imports System.Runtime.ConstrainedExecution
Imports System.Data.SQLite

Public Class FrmOperator
    Public i As String ' DataGridView ID number
    Public dgvRow As DataGridViewRow ' DataGridView Current Row
    Public dgvIntRow As Integer ' DataGridView Current Row as Integer

    Dim ExistingIDNo, ExistingUsername As Boolean
    Dim err As New ErrorProvider

    Dim IDNo, FName, MName, LName, UName, Psk As String
    Dim edit As Boolean

    Private Sub BtnOptAdd_Click(sender As Object, e As EventArgs) Handles BtnOptAdd.Click
        If BtnOptAdd.Text = "Add" Then
            If String.IsNullOrEmpty(TboxOptIDNo.Text) Or
                   String.IsNullOrEmpty(TboxOptFName.Text) Or
                   String.IsNullOrEmpty(TboxOptMName.Text) Or
                   String.IsNullOrEmpty(TboxOptLName.Text) Or
                   String.IsNullOrEmpty(TboxOptUsername.Text) Or
                   String.IsNullOrEmpty(TboxOptPsk.Text) Then
                MessageBox.Show("Please fill in all the required fields to complete the process", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ExistingIDNo = False
            ExistingUsername = False

            Check_Duplication_Records()

            If ExistingIDNo = True Then
                MessageBox.Show("User ID already registered.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If ExistingUsername = True Then
                MessageBox.Show("Username already registered.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Insert Operator Credential
            Try
                Dim DbQuery = "INSERT INTO operator (id_no, first_name, middle_name, last_name, username, password) 
                           VALUES ('" & TboxOptIDNo.Text & "','" & TboxOptFName.Text & "','" & TboxOptMName.Text & "',
                           '" & TboxOptLName.Text & "','" & TboxOptUsername.Text & "','" & TboxOptPsk.Text & "')"
                dbConn.Open()
                Using dbCmd As New SqlCommand(DbQuery, dbConn)
                    dbCmd.ExecuteNonQuery()
                End Using
                dbConn.Close()
            Catch sqlex As SqlException
                MessageBox.Show(sqlex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "General Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try

            Load_Operators()

            BtnOptClear.PerformClick()
        End If

        If BtnOptAdd.Text = "Update" Then
            If edit = True Then
                ExistingIDNo = False
                ExistingUsername = False

                Check_Duplication_Records()

                If String.IsNullOrEmpty(TboxOptIDNo.Text) Or
                   String.IsNullOrEmpty(TboxOptFName.Text) Or
                   String.IsNullOrEmpty(TboxOptMName.Text) Or
                   String.IsNullOrEmpty(TboxOptLName.Text) Or
                   String.IsNullOrEmpty(TboxOptUsername.Text) Or
                   String.IsNullOrEmpty(TboxOptPsk.Text) Then
                    MessageBox.Show("Please fill in all the required fields to complete the process", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                If TboxOptIDNo.Text = IDNo And
                   TboxOptFName.Text = FName And
                   TboxOptMName.Text = MName And
                   TboxOptLName.Text = LName And
                   TboxOptUsername.Text = UName And
                   TboxOptPsk.Text = Psk Then
                    MessageBox.Show("No changes has been made.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Check_Duplication_Records()

                If TboxOptIDNo.Text <> IDNo Then
                    If ExistingIDNo = True Then
                        MessageBox.Show("User ID already registered.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End If

                If TboxOptUsername.Text <> UName Then
                    If ExistingUsername = True Then
                        MessageBox.Show("Username already registered.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End If

                Try
                    Dim dbQuery = "UPDATE operator SET id_no=@id_no, first_name=@fname, middle_name=@mname, last_name=@lname, username=@username, password=@psk WHERE id=@id"
                    dbConn.Open()
                    Using dbCmd As New SqlCommand(dbQuery, dbConn)
                        dbCmd.Parameters.AddWithValue("@id", i)
                        dbCmd.Parameters.AddWithValue("@id_no", TboxOptIDNo.Text)
                        dbCmd.Parameters.AddWithValue("@fname", TboxOptFName.Text)
                        dbCmd.Parameters.AddWithValue("@mname", TboxOptMName.Text)
                        dbCmd.Parameters.AddWithValue("@lname", TboxOptLName.Text)
                        dbCmd.Parameters.AddWithValue("@username", TboxOptUsername.Text)
                        dbCmd.Parameters.AddWithValue("@psk", TboxOptPsk.Text)
                        dbCmd.ExecuteNonQuery()
                        edit = False
                    End Using
                    dbConn.Close()
                Catch sqlex As SqlException
                    MessageBox.Show(sqlex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "General Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If dbConn.State = ConnectionState.Open Then
                        dbConn.Close()
                    End If
                End Try

                Load_Operators()
                BtnOptClear.Text = "Clear"
                BtnOptAdd.Text = "Add"
                DgvOpt.Enabled = True
                BtnOptEdit.Enabled = True
                BtnOptDelete.Enabled = True
                BtnOptClear.PerformClick()
            End If '
        End If
    End Sub

    Private Sub Check_Duplication_Records()
        ' Check existing user ID
        Try
            Dim dbQuery = "SELECT id_no FROM operator WHERE id_no = @id_no"
            dbConn.Open()
            Using dbCmd As New SqlCommand(dbQuery, dbConn)
                dbCmd.Parameters.AddWithValue("@id_no", TboxOptIDNo.Text)
                Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                    dbReader.Read()
                    If dbReader.HasRows Then
                        ExistingIDNo = True
                    End If
                End Using
            End Using
            dbConn.Close()
        Catch sqlex As SqlException
            MessageBox.Show(sqlex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "General Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try

        ' Check exising username
        Try
            Dim dbQuery = "SELECT username FROM operator WHERE username = @username"
            dbConn.Open()
            Using dbCmd As New SqlCommand(dbQuery, dbConn)
                dbCmd.Parameters.AddWithValue("@username", TboxOptUsername.Text)
                Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                    dbReader.Read()
                    If dbReader.HasRows Then
                        ExistingUsername = True
                    End If
                End Using
            End Using
            dbConn.Close()
        Catch sqlex As SqlException
            MessageBox.Show(sqlex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "General Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try
    End Sub

    Private Sub Load_Operators()
        Try
            Dim dbTable As New DSOperator.DTOperatorDataTable
            Dim dbQuery = "SELECT * FROM operator"
            dbConn.Open()
            Using dbCmd As New SqlCommand(dbQuery, dbConn)
                Using dbAdapter As New SqlDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbConn.Close()
            DgvOpt.DataSource = dbTable
            DgvOpt.ClearSelection()
            dgvIntRow = -1
        Catch sqlex As SqlException
            MessageBox.Show(sqlex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "General Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try
    End Sub

    Private Sub Load_Function_Switch()
        '' SQL Server basis
        'Try
        '    Dim dbQuery = "SELECT * FROM operator_switch"
        '    dbConn.Open()
        '    Using dbCmd As New SqlCommand(dbQuery, dbConn)
        '        Using dbReader As SqlDataReader = dbCmd.ExecuteReader
        '            dbReader.Read()
        '            If dbReader.HasRows Then
        '                If dbReader("switch") = 1 Then
        '                    RBtnEnable.Checked = True
        '                    LblOptStatusCurrent.Text = "ENABLE"
        '                    LblOptStatusCurrent.ForeColor = Color.Green
        '                End If

        '                If dbReader("switch") = 0 Then
        '                    RBtnDisable.Checked = True
        '                    LblOptStatusCurrent.Text = "DISABLE"
        '                    LblOptStatusCurrent.ForeColor = Color.Red
        '                End If
        '            End If
        '        End Using
        '    End Using
        '    dbConn.Close()
        'Catch sqlex As SqlException
        '    MessageBox.Show(sqlex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "General Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    If dbConn.State = ConnectionState.Open Then
        '        dbConn.Close()
        '    End If
        'End Try

        ' Stand alone SQLite basis
        Try
            Dim dbQuery = "SELECT * FROM Reference_Switch"
            dbLocalConn.Open()
            Using dbCmd As New SQLiteCommand(dbQuery, dbLocalConn)
                Using dbReader As SQLiteDataReader = dbCmd.ExecuteReader
                    dbReader.Read()
                    If dbReader.HasRows Then
                        If dbReader("operator_switch") = 1 Then
                            RBtnOptEnable.Checked = True
                            LblOptStatusCurrent.Text = "ENABLE"
                            LblOptStatusCurrent.ForeColor = Color.Green
                        End If

                        If dbReader("operator_switch") = 0 Then
                            RBtnOptDisable.Checked = True
                            LblOptStatusCurrent.Text = "DISABLE"
                            LblOptStatusCurrent.ForeColor = Color.Red
                        End If

                        If dbReader("lotno_check_switch") = 1 Then
                            RBtnExstLotEnable.Checked = True
                            LblCheckExstLotStatusCurrent.Text = "ENABLE"
                            LblCheckExstLotStatusCurrent.ForeColor = Color.Green
                        End If

                        If dbReader("lotno_check_switch") = 0 Then
                            RBtnExstLotDisable.Checked = True
                            LblCheckExstLotStatusCurrent.Text = "DISABLE"
                            LblCheckExstLotStatusCurrent.ForeColor = Color.Red
                        End If
                    End If
                End Using
            End Using
            dbLocalConn.Close()
        Catch sqlex As SQLiteException
            MessageBox.Show(sqlex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "General Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConn.State = ConnectionState.Open Then
                dbConn.Close()
            End If
        End Try
    End Sub

    Private Sub FrmOperator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvOpt.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 8.25, FontStyle.Regular)

        Load_Operators()
        Load_Function_Switch()
        BtnOptAppy.Enabled = False
    End Sub

    Private Sub BtnOptAppy_Click(sender As Object, e As EventArgs) Handles BtnOptAppy.Click
        Dim Operator_Enable, Operator_Disable,
            Lot_Enable, Lot_Disable As Boolean

        Operator_Enable = RBtnOptEnable.Checked = True
        Operator_Disable = RBtnOptDisable.Checked = True
        Lot_Enable = RBtnExstLotEnable.Checked = True
        Lot_Disable = RBtnExstLotDisable.Checked = True

        Dim operator_switch, lotno_switch As Integer

        ' Operator switch
        If Operator_Enable Then
            operator_switch = 1
            LblOptStatusCurrent.Text = "ENABLE"
            LblOptStatusCurrent.ForeColor = Color.Green
            'FrmMain.TBoxEndorsedBy.ReadOnly = True
        End If

        If Operator_Disable Then
            operator_switch = 0
            LblOptStatusCurrent.Text = "DISABLE"
            LblOptStatusCurrent.ForeColor = Color.Red
            'FrmMain.TBoxEndorsedBy.ReadOnly = False
        End If

        ' Existing Lot Number switch
        If Lot_Enable Then
            lotno_switch = 1
            LblCheckExstLotStatusCurrent.Text = "ENABLE"
            LblCheckExstLotStatusCurrent.ForeColor = Color.Green
            'FrmMain.TBoxEndorsedBy.ReadOnly = True
        End If

        If Lot_Disable Then
            lotno_switch = 0
            LblCheckExstLotStatusCurrent.Text = "DISABLE"
            LblCheckExstLotStatusCurrent.ForeColor = Color.Red
            'FrmMain.TBoxEndorsedBy.ReadOnly = False
        End If

        '' SQL Server base
        'Try
        '    Dim DbQuery = "UPDATE operator_switch SET switch = @switch"
        '    dbConn.Open()
        '    Using dbCmd As New SqlCommand(DbQuery, dbConn)
        '        dbCmd.Parameters.AddWithValue("@switch", switch)
        '        dbCmd.ExecuteNonQuery()
        '    End Using
        '    dbConn.Close()
        'Catch sqlex As SqlException
        '    MessageBox.Show(sqlex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "General Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    If dbConn.State = ConnectionState.Open Then
        '        dbConn.Close()
        '    End If
        'End Try

        ' Stand alone SQLite basis
        Try ' update operator switch
            Dim DbQuery = "UPDATE Reference_Switch SET operator_switch = @switch"
            dbLocalConn.Open()
            Using dbCmd As New SQLiteCommand(DbQuery, dbLocalConn)
                dbCmd.Parameters.AddWithValue("@switch", operator_switch)
                dbCmd.ExecuteNonQuery()
            End Using
            dbLocalConn.Close()
        Catch sqlex As SQLiteException
            MessageBox.Show(sqlex.Message, "SQLite Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "General Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbLocalConn.State = ConnectionState.Open Then
                dbLocalConn.Close()
            End If
        End Try

        ' Stand alone SQLite basis
        Try ' update lot number switch
            Dim DbQuery = "UPDATE Reference_Switch SET lotno_check_switch = @switch"
            dbLocalConn.Open()
            Using dbCmd As New SQLiteCommand(DbQuery, dbLocalConn)
                dbCmd.Parameters.AddWithValue("@switch", lotno_switch)
                dbCmd.ExecuteNonQuery()
            End Using
            dbLocalConn.Close()
        Catch sqlex As SQLiteException
            MessageBox.Show(sqlex.Message, "SQLite Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "General Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbLocalConn.State = ConnectionState.Open Then
                dbLocalConn.Close()
            End If
        End Try

        MessageBox.Show("Settings successfully applied.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub RBtnEnable_CheckedChanged(sender As Object, e As EventArgs) Handles RBtnOptEnable.CheckedChanged
        If RBtnOptEnable.Checked = True Then
            BtnOptAppy.Enabled = True
        End If
    End Sub

    Private Sub RBtnDisable_CheckedChanged(sender As Object, e As EventArgs) Handles RBtnOptDisable.CheckedChanged
        If RBtnOptDisable.Checked = True Then
            BtnOptAppy.Enabled = True
        End If
    End Sub

    Private Sub RBtnExstLotEnable_CheckedChanged(sender As Object, e As EventArgs) Handles RBtnExstLotEnable.CheckedChanged
        If RBtnExstLotEnable.Checked = True Then
            BtnOptAppy.Enabled = True
        End If
    End Sub

    Private Sub RBtnExstLotDisable_CheckedChanged(sender As Object, e As EventArgs) Handles RBtnExstLotDisable.CheckedChanged
        If RBtnExstLotDisable.Checked = True Then
            BtnOptAppy.Enabled = True
        End If
    End Sub

    Private Sub TboxOptIDNo_TextChanged(sender As Object, e As EventArgs) Handles TboxOptIDNo.TextChanged
        TboxOptIDNo.MaxLength = 6

        If String.IsNullOrEmpty(TboxOptIDNo.Text) Then ' Clear Then Error For empty input
            err.SetError(TboxOptIDNo, Nothing)
            'TboxOptIDNo.BackColor = Color.White;

        Else
            If TboxOptIDNo.Text.Length = 6 Then ' // Cleaer Then Error For valid input
                err.SetError(TboxOptIDNo, Nothing)
                'TboxOptIDNo.BackColor = Color.White;

            Else '// Set error for invalid input
                err.SetError(TboxOptIDNo, "Invalid ID number")
                'TboxOptIDNo.BackColor = Color.Red
            End If
        End If
    End Sub

    Private Sub BtnOptDelete_Click(sender As Object, e As EventArgs) Handles BtnOptDelete.Click
        If dgvIntRow >= 0 Then
            Dim ResultDiag = MessageBox.Show("Are you sure you want to delete this user?" & vbCrLf & "This action cannot be undone.", "Delete User Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If ResultDiag = DialogResult.Yes Then
                Try
                    Dim dbQuery = "DELETE FROM operator WHERE id=@id"
                    dbConn.Open()
                    Using dbCmd As New SqlCommand(dbQuery, dbConn)
                        dbCmd.Parameters.AddWithValue("@id", i)
                        dbCmd.ExecuteNonQuery()
                    End Using
                    dbConn.Close()
                Catch sqlex As SqlException
                    MessageBox.Show(sqlex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "General Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If dbConn.State = ConnectionState.Open Then
                        dbConn.Close()
                    End If
                End Try

                Load_Operators()
                DgvOpt.ClearSelection()
                'DgvOpt.Enabled = False
                'BtnOptAdd.Text = "Update"
                ' BtnOptClear.Text = "Cancel"
                'BtnOptEdit.Enabled = False
                'BtnOptDelete.Enabled = False
            End If
        End If
    End Sub

    Private Sub PressEnter_KeyDown(sender As Object, e As KeyEventArgs) Handles TboxOptIDNo.KeyDown, TboxOptFName.KeyDown, TboxOptMName.KeyDown, TboxOptLName.KeyDown, TboxOptUsername.KeyDown, TboxOptPsk.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnOptAdd.PerformClick()
        End If
    End Sub

    Private Sub TboxOptIDNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TboxOptIDNo.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
            If Not Char.IsDigit(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub FrmOperator_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub DgvOpt_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvOpt.CellContentClick
        'MsgBox(e.RowIndex)
        If e.RowIndex >= 0 Then
            dgvRow = DgvOpt.Rows(e.RowIndex) ' get the row index of the selected datagridview
            dgvIntRow = DgvOpt.SelectedCells.Item(0).RowIndex ' get the row index of the selected column of row index
            i = dgvRow.Cells(0).Value.ToString() ' get the value of the 1st column of selected row index

            'MsgBox("dgv " & dgvIntRow)
        End If

        'MsgBox("selection change " & i)
    End Sub

    Private Sub DgvOpt_SelectionChanged(sender As Object, e As EventArgs) Handles DgvOpt.SelectionChanged
        Dim iRowIndex As Integer
        Dim iRow As String

        For n As Integer = 0 To DgvOpt.SelectedCells.Count - 1
            iRowIndex = DgvOpt.SelectedCells.Item(n).RowIndex
            iRow = DgvOpt.Rows(iRowIndex).Cells(0).Value.ToString
            i = iRow
            'MsgBox(n)
            'MsgBox(i & " & Row index " & Format(iRowIndex) & " " & iRowIndex)
        Next

        dgvIntRow = iRowIndex
        'MsgBox("selection change " & i)
    End Sub

    Private Sub BtnOptEdit_Click(sender As Object, e As EventArgs) Handles BtnOptEdit.Click
        If dgvIntRow >= 0 Then
            edit = True
            Try
                Dim dbQuery = "SELECT * FROM operator WHERE id = @id"
                dbConn.Open()
                Using dbCmd As New SqlCommand(dbQuery, dbConn)
                    dbCmd.Parameters.AddWithValue("@id", i)
                    Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                        dbReader.Read()
                        If dbReader.HasRows Then
                            IDNo = dbReader("id_no").ToString
                            FName = dbReader("first_name").ToString
                            MName = dbReader("middle_name").ToString
                            LName = dbReader("last_name").ToString
                            UName = dbReader("username").ToString
                            Psk = dbReader("password").ToString

                            TboxOptIDNo.Text = IDNo
                            TboxOptFName.Text = FName
                            TboxOptMName.Text = MName
                            TboxOptLName.Text = LName
                            TboxOptUsername.Text = UName
                            TboxOptPsk.Text = Psk
                        End If
                    End Using
                End Using
                dbConn.Close()
                DgvOpt.Enabled = False
                BtnOptAdd.Text = "Update"
                BtnOptClear.Text = "Cancel"
                BtnOptEdit.Enabled = False
                BtnOptDelete.Enabled = False
            Catch sqlex As SqlException
                MessageBox.Show(sqlex.Message, "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "General Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbConn.State = ConnectionState.Open Then
                    dbConn.Close()
                End If
            End Try

            LblOptIDNo.Select()
        End If
    End Sub

    Private Sub BtnOptClear_Click(sender As Object, e As EventArgs) Handles BtnOptClear.Click
        If BtnOptClear.Text = "Clear" Then
            TboxOptIDNo.Clear()
            TboxOptFName.Clear()
            TboxOptMName.Clear()
            TboxOptLName.Clear()
            TboxOptUsername.Clear()
            TboxOptPsk.Clear()
        End If

        If BtnOptClear.Text = "Cancel" Then
            TboxOptIDNo.Clear()
            TboxOptFName.Clear()
            TboxOptMName.Clear()
            TboxOptLName.Clear()
            TboxOptUsername.Clear()
            TboxOptPsk.Clear()

            DgvOpt.Enabled = True
            BtnOptAdd.Text = "Add"
            BtnOptClear.Text = "Clear"
            BtnOptEdit.Enabled = True
            BtnOptDelete.Enabled = True
            DgvOpt.ClearSelection()
            dgvIntRow = -1
        End If
    End Sub
End Class