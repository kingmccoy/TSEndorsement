Imports System.ComponentModel
Imports System.Data.Entity.Infrastructure

Public Class FrmFlashScreen
    Private Sub FrmFlashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BgWorkerFlashScreen.WorkerReportsProgress = True
        BgWorkerFlashScreen.WorkerSupportsCancellation = True
        BgWorkerFlashScreen.RunWorkerAsync()
    End Sub

    Private Sub BgWorkerFlashScreen_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgWorkerFlashScreen.DoWork
        ' Perform initialization tasks here
        ' Simulate some work
        For i As Integer = 1 To 10
            System.Threading.Thread.Sleep(300) ' Simulate work
            BgWorkerFlashScreen.ReportProgress(i * 10)
        Next

        ' Example: Connect to database
        ConnectToDatabase()
    End Sub

    Private Sub BgWorkerFlashScreen_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgWorkerFlashScreen.ProgressChanged
        If ProgressBarDBConn.InvokeRequired Then
            ProgressBarDBConn.Invoke(New MethodInvoker(Sub() ProgressBarDBConn.Value = e.ProgressPercentage))
        Else
            ProgressBarDBConn.Value = e.ProgressPercentage
        End If
    End Sub

    Private Sub BgWorkerFlashScreen_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgWorkerFlashScreen.RunWorkerCompleted
        If DataBaseConnection.dbConn.State = ConnectionState.Open Then
            dbConn.Close()
        Else
            If dbConn.State = ConnectionState.Connecting Then
                dbConn.Close()
            End If

            Dim errorMessage As String = $"Failed to connect to the database at {HostName}:{Port}. Please check your network connection and try again."
            MessageBox.Show(errorMessage, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Environment.Exit(0)
        End If
    End Sub

    Private Sub ConnectToDatabase()
        Try
            If DataBaseConnection.dbConn.State = ConnectionState.Closed Then
                dbConn.Open()
            End If
            'dbConn.Close()
        Catch ex As Exception
            MessageBox.Show("Error connecting to the database: " & ex.Message)
        End Try
    End Sub
End Class
