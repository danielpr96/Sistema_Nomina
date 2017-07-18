Imports System.Data.SqlClient

Public Class conexion
    Public cnn As SqlConnection

    Sub abrirConexion()
        Try
            cnn = New SqlConnection("Data Source=DANIELPR96\SQLEXPRESS; Initial Catalog=nomias; User Id=dportillo; Password=123456")
            cnn.Open()
        Catch ex As Exception
            MsgBox("No conecto" + ex.ToString)
        End Try
    End Sub

    Sub cerrarConexion()
        Try
            With (cnn)
                .Close()
                .Dispose()
            End With
            cnn = Nothing
        Catch ex As Exception

        End Try
    End Sub
End Class
