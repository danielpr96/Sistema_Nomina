Imports System.Data.SqlClient
Public Class procedimientos

    Public Sub AltaNomina(ByVal fechaComprobante As DateTime, ByVal formaPago As String, ByVal noCertificado As String, ByVal certificado As String, ByVal subTotalComprobante As Decimal,
                          ByVal descuentoComprobante As Decimal, ByVal moneda As String, ByVal totalComprobante As Decimal)
        Try
            Dim conexion As New conexion
            conexion.abrirConexion()
            Dim cmd As New SqlCommand
            cmd.CommandText = "[AltaNomina]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = conexion.cnn
            cmd.Parameters.AddWithValue("@fechaComprobante", fechaComprobante)
            cmd.Parameters.AddWithValue("@formaPago", formaPago)
            cmd.Parameters.AddWithValue("@noCertificado", noCertificado)
            cmd.Parameters.AddWithValue("@certificado", certificado)
            cmd.Parameters.AddWithValue("@subTotalComprobante", subTotalComprobante)
            cmd.Parameters.AddWithValue("@descuentoComprobante", descuentoComprobante)
            cmd.Parameters.AddWithValue("@moneda", moneda)
            cmd.Parameters.AddWithValue("@totalComprobante", totalComprobante)
            cmd.ExecuteNonQuery()
            conexion.cerrarConexion()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
