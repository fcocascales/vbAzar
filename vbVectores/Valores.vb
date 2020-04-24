' Valores.vb — ProInf.net — feb-2012
'
' Cada una de las líneas de los archivos estadísticos "array_*.csv" 
' Son los elementos de las clases Vectores

Public MustInherit Class ValorVector
    Public Property Texto As String
    Public Property Frecuencia As Integer = 0
    Public MustOverride Sub Analizar(ByVal linea As String)
End Class

Public Class ValorProvincia
    Inherits ValorVector
    Public Property CodigoPostal As String
    Public Property PrefijoTelefonico As String
    Public Overrides Sub Analizar(ByVal linea As String)
        'línea="Soria,42,975"
        Dim items = linea.Split(",")
        Texto = items(0)
        CodigoPostal = items(1)
        PrefijoTelefonico = items(2)
    End Sub
End Class

Public Class ValorMunicipio
    Inherits ValorVector
    Public Property NumeroProvincia As Integer
    Public ReadOnly Property Provincia As String
        Get
            Return Recursos.provincias(NumeroProvincia).Texto
        End Get
    End Property
    Public Overrides Sub Analizar(ByVal linea As String)
        'línea="197488,Pamplona,23"
        Dim items = linea.Split(",")
        Frecuencia = items(0)
        Texto = items(1)
        NumeroProvincia = items(2)
    End Sub
End Class

Public Enum EnumSexo
    Mujer
    Hombre
End Enum

Public Class ValorNombre
    Inherits ValorVector
    Public Property Sexo As EnumSexo
    Public Overrides Sub Analizar(ByVal linea As String)
        'línea="776445,Antonio,1"
        Dim items = linea.Split(",")
        Frecuencia = items(0)
        Texto = items(1)
        Sexo = items(2)
    End Sub
End Class

Public Class ValorApellido
    Inherits ValorVector
    Public Overrides Sub Analizar(ByVal linea As String)
        'línea="1483939,García"
        Dim items = linea.Split(",")
        Frecuencia = items(0)
        Texto = items(1)
    End Sub
End Class


Public Class ValorPalabraComun
    Inherits ValorVector
    Public Overrides Sub Analizar(ByVal linea As String)
        'línea="vamos,2378"
        Dim items = linea.Split(",")
        Texto = items(0)
        Frecuencia = items(1)
    End Sub
End Class

Public Class ValorPalabra
    Inherits ValorVector
    Public Property Articulo As String
    Public Overrides Sub Analizar(ByVal linea As String)
        'línea="Cosmos,El"
        Try
            Dim items = linea.Split(",")
            Texto = items(0)
            Articulo = items(1)
        Catch ex As Exception
            MsgBox("Error en ValorPalabra: " & linea)
        End Try
    End Sub
End Class

Public Class ValorAdjetivo
    Inherits ValorVector
    Public Overrides Sub Analizar(ByVal linea As String)
        Texto = linea
    End Sub
End Class

Public Class ValorCampoDefinido
    Inherits ValorVector
    Public Overrides Sub Analizar(ByVal linea As String)
        Texto = linea
    End Sub
End Class