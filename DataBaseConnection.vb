Imports System.Data.SqlClient

Module DataBaseConnection
    Public dbConn As New SqlConnection("Data Source=10.10.15.25,1444;Initial Catalog=sli_endorsement;Persist Security Info=True;User ID=test;Password=test123;Encrypt=False;Connection Timeout=30;")
End Module
