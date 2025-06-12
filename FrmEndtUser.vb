Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FrmEndtUser
    Private Sub BtnEndtLogin_Click(sender As Object, e As EventArgs) Handles BtnEndtLogin.Click
        Dim UserExists As Boolean
        Try
            Dim dbQuery = "SELECT * FROM operator WHERE username=@username AND password=@password"
            dbConn.Open()
            Using dbCmd As New SqlCommand(dbQuery, dbConn)
                dbCmd.Parameters.AddWithValue("@username", TboxEndtUsername.Text)
                dbCmd.Parameters.AddWithValue("@password", TboxEndtPsk.Text)
                Using dbReader As SqlDataReader = dbCmd.ExecuteReader
                    dbReader.Read()
                    If dbReader.HasRows Then
                        FrmMain.Username = dbReader("username").ToString
                        UserExists = True
                    Else
                        MessageBox.Show("Invalid username or password", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        If UserExists Then
            Me.Close()
            FrmMain.UserExists = True
            'FrmMain.TBoxEndorsedBy.Focus()
            'FrmMain.TBoxLotNo.Select()
        End If
    End Sub

    Private Sub FrmEndtUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TboxEndtUsername.Clear()
        TboxEndtPsk.Clear()
        TboxEndtUsername.Select()
    End Sub

    Private Sub FrmEndtUser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'If TboxEndtUsername.TextLength = 0 And TboxEndtPsk.TextLength = 0 Then
        '    FrmMain.TBoxEndorsedBy.ReadOnly = False
        'End If

        'FrmMain.TBoxLotNo.Focus()
        'FrmMain.TBoxLotNo.Select()
    End Sub

    Private Sub FrmEndtUser_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If TboxEndtUsername.TextLength = 0 And TboxEndtPsk.TextLength = 0 Then
            FrmMain.TBoxEndorsedBy.ReadOnly = False
        End If

        'FrmMain.TBoxLotNo.Focus()
        'FrmMain.TBoxLotNo.Select()
    End Sub

    Private Sub PressEnter_KeyDown(sender As Object, e As KeyEventArgs) Handles TboxEndtUsername.KeyDown, TboxEndtPsk.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnEndtLogin.PerformClick()
        End If
    End Sub

    Private Sub TboxEndtPsk_TextChanged(sender As Object, e As EventArgs) Handles TboxEndtPsk.TextChanged
        TboxEndtPsk.UseSystemPasswordChar = True
    End Sub
End Class