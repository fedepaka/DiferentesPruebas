Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace Modelo
    Friend Class EjemploDapper
        Public Function Consultar() As Integer
            Dim sql As String = "SELECT TOP 10 * FROM OrderDetails"

            Using connection = New SqlConnection(FiddleHelper.GetConnectionStringSqlServerW3Schools())
                Dim orderDetails = connection.Query(Of OrderDetail)(sql).ToList()
            End Using

            Return 0
        End Function
    End Class
End Namespace
