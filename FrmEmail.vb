Imports System.Data.SqlClient
Imports System.Data.SQLite
Imports System.Text.RegularExpressions

Public Class FrmEmail
    Public i As String ' DataGridView ID number
    Public dgvRow As DataGridViewRow ' DataGridView Current Row
    Public dgvIntRow As Integer ' DataGridView Current Row as Integer
    Private Invalid_Email As Boolean

    Private Sub FrmEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Email_Reference()
        LblEmailSMTPServer.Select()
    End Sub

    Private Sub Load_Email_Reference()
        ' Get SMTP Server
        Try
            Dim dbQuery = "SELECT * FROM Email_SMTPServer"
            dbLocalConn.Open()
            Using dbCmd As New SQLiteCommand(dbQuery, dbLocalConn)
                Using dbReader As SQLiteDataReader = dbCmd.ExecuteReader
                    dbReader.Read()
                    If dbReader.HasRows Then
                        TboxEmailSMTPServer.Text = dbReader("smtp_server").ToString
                        TboxEmailSMTPPort.Text = dbReader("port").ToString
                    Else
                        TboxEmailSMTPServer.Clear()
                        TboxEmailSMTPPort.Clear()
                    End If
                End Using
            End Using
            dbLocalConn.Close()
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "SQLite Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            dbLocalConn.Close()
            MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbLocalConn.State = ConnectionState.Open Then
                dbLocalConn.Close()
            End If
        End Try

        ' Get Credential
        Try
            Dim dbQuery = "SELECT * FROM Email_Credential"
            dbLocalConn.Open()
            Using dbCmd As New SQLiteCommand(dbQuery, dbLocalConn)
                Using dbReader As SQLiteDataReader = dbCmd.ExecuteReader
                    dbReader.Read()
                    If dbReader.HasRows Then
                        TboxEmailCredEmail.Text = dbReader("email").ToString
                        TboxEmailCredPass.Text = dbReader("password").ToString
                    Else
                        TboxEmailCredEmail.Clear()
                        TboxEmailCredPass.Clear()
                    End If
                End Using
            End Using
            dbLocalConn.Close()
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "SQLite Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            dbLocalConn.Close()
            MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbLocalConn.State = ConnectionState.Open Then
                dbLocalConn.Close()
            End If
        End Try

        ' Get Recipient
        Try
            Dim dbTable As New DataTable
            Dim dbQuery = "SELECT * FROM Email_Recipient"
            dbLocalConn.Open()
            Using dbCmd As New SQLiteCommand(dbQuery, dbLocalConn)
                Using dbAdapter As New SQLiteDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbLocalConn.Close()
            DgvRecipient.DataSource = dbTable
            i = Nothing
            dgvRow = Nothing
            dgvIntRow = -1
            DgvRecipient.ClearSelection()
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "SQLite Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            dbLocalConn.Close()
            MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbLocalConn.State = ConnectionState.Open Then
                dbLocalConn.Close()
            End If
        End Try
    End Sub

    Private Sub BtnRecipientClear_Click(sender As Object, e As EventArgs) Handles BtnRecipientClear.Click
        TboxRecipientEmail.Clear()
        ErrorProvider1.SetError(TboxRecipientEmail, Nothing)
    End Sub

    Private Sub BtnRecipientAdd_Click(sender As Object, e As EventArgs) Handles BtnRecipientAdd.Click
        If TboxRecipientEmail.Text = Nothing Then
            MessageBox.Show("Please ensure all the fields are filled out before proceeding.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Invalid_Email = True Then
            MessageBox.Show("Invalid email address entered. Please check and try again.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Dim dbQuery = "INSERT INTO Email_Recipient (email) VALUES ('" & TboxRecipientEmail.Text & "')"
            dbLocalConn.Open()
            Using dbCmd As New SQLiteCommand(dbQuery, dbLocalConn)
                dbCmd.ExecuteNonQuery()
            End Using
            dbLocalConn.Close()
            TboxRecipientEmail.Clear()
            ErrorProvider1.SetError(TboxRecipientEmail, Nothing)
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "SQLite Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            dbLocalConn.Close()
            MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbLocalConn.State = ConnectionState.Open Then
                dbLocalConn.Close()
            End If
        End Try

        Load_Email_Reference()
    End Sub

    Private Sub TboxRecipientEmail_TextChanged(sender As Object, e As EventArgs) Handles TboxRecipientEmail.TextChanged
        Dim Email_Format = "^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9-]+\.[a-zA-Z]{2,}$"

        If Regex.IsMatch(TboxRecipientEmail.Text, Email_Format) Then
            ErrorProvider1.SetError(TboxRecipientEmail, Nothing)
            Invalid_Email = False
        Else
            ErrorProvider1.SetError(TboxRecipientEmail, "Invalid Email")
            Invalid_Email = True
        End If
    End Sub

    Private Sub BtnRecipientDelete_Click(sender As Object, e As EventArgs) Handles BtnRecipientDelete.Click
        Try
            Dim dbQuery = "DELETE FROM Email_Recipient WHERE id='" & i & "'"
            dbLocalConn.Open()
            Using dbCmd As New SQLiteCommand(dbQuery, dbLocalConn)
                dbCmd.ExecuteNonQuery()
            End Using
            dbLocalConn.Close()
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "SQLite Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            dbLocalConn.Close()
            MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbLocalConn.State = ConnectionState.Open Then
                dbLocalConn.Close()
            End If
        End Try

        Load_Email_Reference()
    End Sub

    Private Sub DgvRecipient_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRecipient.CellContentClick
        If e.RowIndex >= 0 Then
            dgvRow = DgvRecipient.Rows(e.RowIndex) ' get the row index of the selected datagridview
            dgvIntRow = DgvRecipient.SelectedCells.Item(0).RowIndex ' get the row index of the selected column of row index
            i = dgvRow.Cells(0).Value.ToString() ' get the value of the 1st column of selected row index

            'MsgBox("dgv " & dgvIntRow)
        End If
    End Sub

    Private Sub DgvRecipient_SelectionChanged(sender As Object, e As EventArgs) Handles DgvRecipient.SelectionChanged
        Dim iRowIndex As Integer
        Dim iRow As String

        For n As Integer = 0 To DgvRecipient.SelectedCells.Count - 1
            iRowIndex = DgvRecipient.SelectedCells.Item(n).RowIndex
            iRow = DgvRecipient.Rows(iRowIndex).Cells(0).Value.ToString
            i = iRow
            'MsgBox(n)
            'MsgBox(i & " & Row index " & Format(iRowIndex) & " " & iRowIndex)
        Next

        dgvIntRow = iRowIndex
        'MsgBox("selection change " & i)
    End Sub

    Private Sub BtnEmailSMTPClear_Click(sender As Object, e As EventArgs) Handles BtnEmailSMTPClear.Click
        'Dim MessageDiag As DialogResult = MessageBox.Show("Confirm save SMTP Server?", "SMTP Server", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'If MessageDiag = DialogResult.Yes Then
        '    Try
        '        Dim dbQuery = "UPDATE Email_SMTPServer SET smtp_server='" & TboxEmailSMTPServer.Text & "', port='" & TboxEmailSMTPPort.Text & "'"
        '        dbLocalConn.Open()
        '        Using dbCmd As New SQLiteCommand(dbQuery, dbLocalConn)
        '            dbCmd.ExecuteNonQuery()
        '        End Using
        '        dbLocalConn.Close()
        '    Catch ex As SqlException
        '        MessageBox.Show(ex.Message, "SQLite Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Catch ex As Exception
        '        dbLocalConn.Close()
        '        MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Finally
        '        If dbLocalConn.State = ConnectionState.Open Then
        '            dbLocalConn.Close()
        '        End If
        '    End Try

        '    Load_Email_Reference()

        TboxEmailSMTPServer.Clear()
        TboxEmailSMTPPort.Clear()
        'End If
    End Sub

    Private Sub BtnEmailCredClear_Click(sender As Object, e As EventArgs) Handles BtnEmailCredClear.Click
        'Dim MessageDiag As DialogResult = MessageBox.Show("Confirm save Email credentials?", "SMTP Server", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'If MessageDiag = DialogResult.Yes Then
        '    Try
        '        Dim dbQuery = "UPDATE Email_Credential SET email='" & TboxEmailCredEmail.Text & "', password='" & TboxEmailCredPass.Text & "'"
        '        dbLocalConn.Open()
        '        Using dbCmd As New SQLiteCommand(dbQuery, dbLocalConn)
        '            dbCmd.ExecuteNonQuery()
        '        End Using
        '        dbLocalConn.Close()
        '    Catch ex As SqlException
        '        MessageBox.Show(ex.Message, "SQLite Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Catch ex As Exception
        '        dbLocalConn.Close()
        '        MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Finally
        '        If dbLocalConn.State = ConnectionState.Open Then
        '            dbLocalConn.Close()
        '        End If
        '    End Try

        TboxEmailCredEmail.Clear()
        TboxEmailCredPass.Clear()

        '    Load_Email_Reference()
        'End If
    End Sub

    Private Sub FrmEmail_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Close()
    End Sub

    Private Sub BtnEmailSentTest_Click(sender As Object, e As EventArgs) Handles BtnEmailSentTest.Click
        Send_eMail(FrmMain.TboxEndorsementNo, FrmMain.TBoxEndorsedBy, FrmMain.LblTotalQty) 'this is for trial sending 
    End Sub

    Private Sub BtnEmailSave_Click(sender As Object, e As EventArgs) Handles BtnEmailSave.Click
        If String.IsNullOrEmpty(TboxEmailCredEmail.Text) Or
            String.IsNullOrEmpty(TboxEmailCredPass.Text) Or
            String.IsNullOrEmpty(TboxEmailSMTPServer.Text) Or
            String.IsNullOrEmpty(TboxEmailSMTPPort.Text) Then
            MessageBox.Show("Please ensure all fields are filled out before proceeding.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim MessageDiag As DialogResult = MessageBox.Show("Confirm save Email credentials?", "SMTP Server", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If MessageDiag = DialogResult.Yes Then
            Try
                Dim dbQuery = "UPDATE Email_Credential SET email='" & TboxEmailCredEmail.Text & "', password='" & TboxEmailCredPass.Text & "'"
                dbLocalConn.Open()
                Using dbCmd As New SQLiteCommand(dbQuery, dbLocalConn)
                    dbCmd.ExecuteNonQuery()
                End Using
                dbLocalConn.Close()
            Catch ex As SqlException
                MessageBox.Show(ex.Message, "SQLite Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                dbLocalConn.Close()
                MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If dbLocalConn.State = ConnectionState.Open Then
                    dbLocalConn.Close()
                End If
            End Try
        End If
    End Sub
End Class