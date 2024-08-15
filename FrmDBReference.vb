Imports System.Data.Entity.Infrastructure
Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class FrmDBReference
    Private Sub FrmDBReference_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_LocalDb()
        LblDBSvrName.Select()
    End Sub

    Private Sub BtnDBTest_Click(sender As Object, e As EventArgs) Handles BtnDBTest.Click
        'MsgBox(Local_Hostname() & Local_Port() & Local_Username() & Local_Password())
        Dim dbConnTest As New SqlConnection("Data Source=" & TboxDBSvrName.Text & "," & TboxDBPort.Text & ";" & "Initial Catalog=sli_endorsement;Persist Security Info=True;User ID=" & TboxDBUsername.Text & ";" & "Password=" & TboxDBPass.Text & ";" & "Encrypt=False;Connection Timeout=30;")
        Try
            'If dbConnTest.State = ConnectionState.Open Then
            '    dbConnTest.Close()
            'Else
            dbConnTest.Open()
            MessageBox.Show("Connection successful.", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dbConnTest.Close()
            'End If
        Catch ex As SQLiteException
            MessageBox.Show(ex.Message, "SQLite Exception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Excception Handling", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnDBOK_Click(sender As Object, e As EventArgs) Handles BtnDBOK.Click
        If HostName = TboxDBSvrName.Text And Port = TboxDBPort.Text And Username = TboxDBUsername.Text And Password = TboxDBPass.Text Then
            MessageBox.Show("The fields are unchanged. Please make edits before saving.", "No Changes Detected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim dbQuery = "UPDATE SQLServerConnection SET server_name='" & TboxDBSvrName.Text & "', port='" & TboxDBPort.Text & "', username='" & TboxDBUsername.Text & "', password='" & TboxDBPass.Text & "'"
            dbLocalConn.Open()
            Using dbCmd As New SQLiteCommand(dbQuery, dbLocalConn)
                dbCmd.ExecuteNonQuery()
            End Using
            dbLocalConn.Close()

            Local_Hostname()
            Local_Port()
            Local_Username()
            Local_Password()
            'dbConn.Dispose()
            dbConn.Close()
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

    Private Sub BtnDBCancel_Click(sender As Object, e As EventArgs) Handles BtnDBCancel.Click
        Me.Close()
    End Sub
End Class