Imports System.Data.OleDb
Imports System.Data.SQLite

Public Class FrmAdminPass
    Public DBReference, UserReference As Boolean
    Dim Pass As String

    Private Sub FrmAdminPass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TboxAdminPass.UseSystemPasswordChar = True
        Load_Admin_Pass()
    End Sub

    Private Sub Load_Admin_Pass()
        Try
            Dim dbQuery = "SELECT * FROM Admin"
            dbLocalConn.Open()
            Using dbCmd As New SQLiteCommand(dbQuery, dbLocalConn)
                Using dbReader As SQLiteDataReader = dbCmd.ExecuteReader
                    dbReader.Read()
                    If dbReader.HasRows Then
                        Pass = dbReader("password").ToString
                    End If
                End Using
            End Using
            dbLocalConn.Close()
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

    Private Sub TboxAdminPass_KeyDown(sender As Object, e As KeyEventArgs) Handles TboxAdminPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnAdminOk.PerformClick()
        End If
    End Sub

    Private Sub BtnAdminOk_Click(sender As Object, e As EventArgs) Handles BtnAdminOk.Click
        If TboxAdminPass.Text = Pass Then
            If DBReference = True Then
                Me.Close()
                DBReference = False
                FrmDBReference.ShowDialog()
            End If

            If UserReference = True Then
                Me.Close()
                UserReference = False
                FrmUserReference.ShowDialog()
            End If
        Else
            MessageBox.Show("Incorrect administrator passsword.", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class