' Vectores.vb — ProInf.net — feb-2012
'
' Almacenan la información estadística de los recursos "array_*.csv" 

Public Class VectorNombres
    Inherits VectorAzarAbstracto(Of ValorNombre)

    Public Sub New(ByVal recurso As String)
        MyBase.New(recurso)
    End Sub

End Class

Public Class VectorApellidos
    Inherits VectorAzarAbstracto(Of ValorApellido)

    Public Sub New(ByVal recurso As String)
        MyBase.New(recurso)
    End Sub

End Class

Public Class VectorMunicipios
    Inherits VectorAzarAbstracto(Of ValorMunicipio)

    Public Sub New(ByVal recurso As String)
        MyBase.New(recurso)
    End Sub

End Class

Public Class VectorProvincias
    Inherits VectorAzarAbstracto(Of ValorProvincia)

    Public Sub New(ByVal recurso As String)
        MyBase.New(recurso)
    End Sub

    Protected Overrides Sub CalcularSumatorioFrecuencias()
        ObtenerFrecuenciasDesdeMunicipios()
        MyBase.CalcularSumatorioFrecuencias()
    End Sub

    Private Sub ObtenerFrecuenciasDesdeMunicipios()
        For indice = 0 To Recursos.municipios.Count - 1
            Dim frecuenciaMunicipio = Recursos.municipios(indice).Frecuencia
            Dim numeroProvincia = Recursos.municipios(indice).NumeroProvincia
            Me(numeroProvincia).Frecuencia += frecuenciaMunicipio
        Next
    End Sub

End Class

Public Class VectorPalabrasComunes
    Inherits VectorAzarAbstracto(Of ValorPalabraComun)

    Public Sub New(ByVal recurso As String)
        MyBase.New(recurso)
    End Sub

    Private ultimaPalabra As String = ""

    Public Function FraseAleatoria(ByVal numeroPalabras As Integer) As String
        Dim sb As New System.Text.StringBuilder()
        For i = 1 To numeroPalabras
            Dim palabra = PalabraAleatoria()
            If i = 1 Then palabra = Utilidades.Capitalizar(palabra)
            sb.Append(palabra)
            If i < numeroPalabras Then sb.Append(" ")
        Next
        sb.Append(".")
        Return sb.ToString()
    End Function

    Private Function PalabraAleatoria() As String
        Dim palabra As String
        Do : palabra = AleatorioPonderado().Texto
        Loop Until palabra <> ultimaPalabra
        ultimaPalabra = palabra
        Return palabra
    End Function

End Class

Public Class VectorPalabras
    Inherits VectorAzarAbstracto(Of ValorPalabra)

    Public Sub New(ByVal recurso As String)
        MyBase.New(recurso)
    End Sub

End Class

Public Class VectorAdjetivos
    Inherits VectorAzarAbstracto(Of ValorAdjetivo)

    Public Sub New(ByVal recurso As String)
        MyBase.New(recurso)
    End Sub

End Class

Public Class VectorDefinidosPredeterminados
    Inherits VectorAzarAbstracto(Of ValorCampoDefinido)

    Public Sub New(ByVal recurso As String)
        MyBase.New(recurso)
    End Sub

End Class