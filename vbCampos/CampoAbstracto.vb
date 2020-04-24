' CampoAbstracto.vb — ProInf.net — feb-2012
'
' Base de los campos predefinidos (cálculos y estadística)
' y de los definidos por el usuario

Public Enum TipoCampo
    Texto
    Entero
    Numero
    Logico
    Fecha
    Hora
End Enum

Public Interface ICampo
    Property Nombre() As String
    Function Tipo() As TipoCampo
    Function Aleatorio() As String
End Interface

Public Interface IAnalizable
    Sub Analizar(ByVal linea As String)
End Interface

Public Interface IReiniciable
    Sub Reiniciar()
End Interface

Public MustInherit Class CampoPredefinido 'para cálculo o estadística
    Implements ICampo

    Public Property Nombre() As String Implements ICampo.Nombre

    Public Overridable Function Tipo() As TipoCampo Implements ICampo.Tipo
        Return TipoCampo.Texto
    End Function

    Public MustOverride Function Aleatorio() As String Implements ICampo.Aleatorio

    Public Overrides Function ToString() As String
        Return Nombre 'String.Format("{0}: {1}", Nombre, Me.GetType().Name)
    End Function

End Class

Public MustInherit Class CampoDefinido ' por el usuario en el formulario
    Inherits CampoPredefinido
    Implements IAnalizable

    Public Sub New(Optional ByVal texto As String = "")
        Analizar(texto)
    End Sub

    Public MustOverride Sub Analizar(ByVal texto As String) Implements IAnalizable.Analizar

    Public Shared Function Instanciar(ByVal texto As String) As CampoDefinido
        Try
            Dim analisis As New Analisis(texto)
            Dim nombreClase = "ProInf.BaseDatosAleatoria." & analisis.Clase
            Dim objeto = Activator.CreateInstance(Type.GetType(nombreClase), texto)
            Return objeto
        Catch ex As Exception
            DialogoError(ex)
            Return Nothing
        End Try
    End Function

    Protected Class Analisis
        Public Nombre As String = ""
        Public Clase As String = ""
        Public Parametros As String = ""

        Public Sub New(ByVal texto As String) 'Ej: "Tipo El nombre = Los parámetros"
            Dim posicionIgual = texto.IndexOf("=")
            If posicionIgual > 0 Then
                Parametros = texto.Substring(posicionIgual + 1).Trim()
                Dim izquierdaIgual = texto.Substring(0, posicionIgual)
                Dim posicionEspacio = izquierdaIgual.IndexOf(" ")
                If posicionEspacio > 0 Then
                    Clase = "Campo" & izquierdaIgual.Substring(0, posicionEspacio).Trim()
                    Nombre = izquierdaIgual.Substring(posicionEspacio + 1).Trim()
                End If
            End If
        End Sub

    End Class

End Class