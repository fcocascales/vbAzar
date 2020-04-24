Public Class Azar
    Private Shared random As New Random()

    Public Shared Function Entre(ByVal inferior As Integer, ByVal superior As Integer) As Integer
        Return random.Next(inferior, superior + 1)
    End Function

    Public Shared Function Digitos(ByVal total As Integer) As String
        Return Simbolos(total, "0123456789")
    End Function

    Public Shared Function Simbolos(ByVal total As Integer, ByVal caracteres As String) As String
        Dim vector() As Char = New Char(total - 1) {}
        For i = 0 To vector.Length - 1
            vector(i) = caracteres(random.Next(caracteres.Length))
        Next
        Return New String(vector)
    End Function

    Public Shared Function ElementoArray(ByVal array As Object()) As String
        Return array(Entre(0, array.Count - 1)).ToString()
    End Function

End Class


