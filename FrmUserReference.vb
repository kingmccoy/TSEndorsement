Imports System.Data.SQLite

Public Class FrmUserReference
    Private Sub FrmUserReference_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_User()
        Load_CurrentUser()
        CboxUser.Text = user
        LblUser.Select()
    End Sub

    Private Sub Load_User()
        Try
            Dim dbQuery = "SELECT user FROM User"
            Dim dbTable As New DataTable
            dbLocalConn.Open()
            Using dbCmd As New SQLiteCommand(dbQuery, dbLocalConn)
                Using dbAdapter As New SQLiteDataAdapter(dbCmd)
                    dbAdapter.Fill(dbTable)
                End Using
            End Using
            dbLocalConn.Close()
            CboxUser.DataSource = dbTable
            CboxUser.DisplayMember = "user"
        Catch ex As SQLiteException
            MessageBox.Show(ex.Message, "SQLite Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbLocalConn.State = ConnectionState.Open Then
                dbLocalConn.Close()
            End If
        End Try
    End Sub

    Private Sub BtnUserOk_Click(sender As Object, e As EventArgs) Handles BtnUserOk.Click
        Try
            Dim dbQuery = "UPDATE CurrentUser SET current_user='" & CboxUser.Text & "'"
            dbLocalConn.Open()
            Using dbCmd As New SQLiteCommand(dbQuery, dbLocalConn)
                dbCmd.ExecuteNonQuery()
                FrmMain.Text = "Endorsement - " & CboxUser.Text
                user = CboxUser.Text
            End Using
            dbLocalConn.Close()
        Catch ex As SQLiteException
            MessageBox.Show(ex.Message, "SQLite Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        FrmMain.Check_User()
        Me.Close()
    End Sub

    Private Sub FrmUserReference_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FrmAdminPass.Close()
        FrmAdminPass.Dispose()
    End Sub
End Class