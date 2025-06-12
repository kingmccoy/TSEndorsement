Imports System.Data.OleDb
Imports System.Data.SQLite

Public Class FrmAdminPass
    Public DBReference, UserReference, EmailReference, OperatorReference As Boolean
    Dim Pass As String

    Private Sub FrmAdminPass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TboxAdminPass.UseSystemPasswordChar = True
        Load_Admin_Pass()
    End Sub

    Private Sub FrmAdminPass_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
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
                Me.Dispose()
                DBReference = False
                FrmDBReference.ShowDialog(FrmMain)
            End If

            If UserReference = True Then
                Me.Dispose()
                UserReference = False
                FrmUserReference.ShowDialog(FrmMain)
            End If

            If EmailReference = True Then
                Me.Dispose()
                EmailReference = False
                FrmEmail.ShowDialog(FrmMain)
            End If

            If OperatorReference = True Then
                Me.Dispose()
                OperatorReference = False
                FrmOperator.ShowDialog(FrmMain)
            End If
        Else
            MessageBox.Show("Incorrect administrator passsword.", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TboxAdminPass.Clear()
            TboxAdminPass.Focus()
        End If
    End Sub
End Class