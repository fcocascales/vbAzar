' CamposPredefinidos.vb — ProInf.net — feb-2012
' 
' Campos que generan valores al azar:
'  - en base a cálculos 
'  - en base a datos estadísticos
'
' CampoId
' CampoNombre
' CampoApellido
' CampoSexo (depende de CampoNombre)
' CampoNIF
' CampoDireccion
' CampoMunicipio
' CampoProvincia (depende de CampoMunicipio)
' CampoCP (depende de CampoProvincia)
' CampoTelefono
' CampoTelefonoFijo (depende de CampoProvincia)
' CampoCorreo (depende de CampoNombre y CampoApellido)
' CampoNacimiento
' CampoEdad (depende de CampoNacimiento)
' CampoMatricula

Public Class CampoId
    Inherits CampoPredefinido
    Implements IReiniciable

    Private Shared _contador As Integer = 0

    Public Overrides Function Tipo() As TipoCampo
        Return TipoCampo.Entero
    End Function

    Public Overrides Function Aleatorio() As String
        _contador += 1
        Return _contador.ToString()
    End Function

    Public Sub Reiniciar() Implements IReiniciable.Reiniciar
        _contador = 0
    End Sub

End Class

Public Class CampoNombre
    Inherits CampoPredefinido

    Public Property Valor As ValorNombre

    Public Overrides Function Aleatorio() As String
        Valor = Recursos.nombres.AleatorioPonderado()
        Return Valor.Texto
    End Function

End Class

Public Class CampoApellido
    Inherits CampoPredefinido

    Public Property Valor As ValorApellido

    Public Overrides Function Aleatorio() As String
        Valor = Recursos.apellidos.AleatorioPonderado()
        Return Valor.Texto
    End Function

End Class

Public Class CampoSexo
    Inherits CampoPredefinido

    Public Property CampoNombre As CampoNombre

    Public Overrides Function Aleatorio() As String
        Dim sexo As EnumSexo
        If CampoNombre Is Nothing Then
            sexo = Azar.Entre(0, 1)
        Else
            sexo = CampoNombre.Valor.Sexo
        End If
        Return sexo.ToString()(0)
    End Function

End Class

Public Class CampoNIF
    Inherits CampoPredefinido

    Const LETRAS = "TRWAGMYFPDXBNJZSQVHLCKET"

    Public Overrides Function Aleatorio() As String
        Dim numero = Azar.Digitos(8)
        Dim letra = CalcularLetra(numero)
        Return String.Format("{0}{1}", numero, letra)
    End Function

    Public Shared Function CalcularLetra(ByVal numero As Integer)
        Return LETRAS(numero Mod 23)
    End Function

End Class

Public Class CampoDireccion
    Inherits CampoPredefinido

    Private Shared _vias() = {"Avenida", "Calle", "Paseo", "Plaza"}
    Private Shared _formatos() = {"{0} {1} {2}, {3}º {4}ª", "{0} {1} {2}, {3}º", "{0} {1} {2}, {3}"}

    Public Overrides Function Aleatorio() As String
        Dim formato = Azar.ElementoArray(_formatos)
        Dim via = Azar.ElementoArray(_vias)
        Dim frase = ObtenerFrase()
        Dim numero = Azar.Entre(1, 300) & If(Azar.Entre(1, 20) = 1, " bis", "")
        Dim piso = Azar.Entre(1, 6)
        Dim puerta = Azar.Entre(1, 6)
        Dim direccion = String.Format(formato, via, frase, numero, piso, puerta)
        Return direccion
    End Function

    Private Shared Function ObtenerFrase() As String
        Dim palabra = Recursos.palabras.Aleatorio()
        Dim preposicion = Azar.ElementoArray({"", "de"})
        Dim articulo = Azar.ElementoArray({"", palabra.Articulo.ToLower()})
        Dim contraccion = ObtenerContraccion(preposicion, articulo)
        Dim adjetivo = CasarGenero(ObtenerAdjetivo(), palabra.Articulo.ToLower())
        Dim formato = Azar.ElementoArray({"{1}", "{0} {1}", "{0} {1} {2}", "{1} {2}"})
        Return String.Format(formato, contraccion, palabra.Texto, adjetivo)
    End Function

    Private Shared Function ObtenerContraccion(ByVal preposicion As String, ByVal articulo As String) As String
        If preposicion = "" Then
            Return articulo
        ElseIf preposicion = "de" And articulo = "el" Then
            Return "del"
        Else
            Return String.Format("{0} {1}", preposicion, articulo)
        End If
    End Function

    Private Shared Function ObtenerAdjetivo() As String
        Dim adjetivo = Recursos.adjetivos.Aleatorio().Texto
        Return Utilidades.Capitalizar(adjetivo)
    End Function

    Private Shared Function CasarGenero(ByVal adjetivo As String, ByVal articulo As String)
        If articulo = "el" And adjetivo.EndsWith("a") Then
            Return CambiarUltimaLetra(adjetivo, "o")
        ElseIf articulo = "la" And adjetivo.EndsWith("o") Then
            Return CambiarUltimaLetra(adjetivo, "a")
        Else
            Return adjetivo
        End If
    End Function

    Private Shared Function CambiarUltimaLetra(ByVal texto As String, ByVal letra As Char) As String
        Return texto.Substring(0, texto.Length - 1) & letra
    End Function

End Class

Public Class CampoMunicipio
    Inherits CampoPredefinido

    Public Property Valor As ValorMunicipio

    Public Overrides Function Aleatorio() As String
        Valor = Recursos.municipios.AleatorioPonderado()
        Return Valor.Texto
    End Function

End Class

Public Class CampoProvincia
    Inherits CampoPredefinido

    Public Property Valor As ValorProvincia
    Public Property CampoMunicipio As CampoMunicipio

    Public Overrides Function Aleatorio() As String
        If CampoMunicipio Is Nothing Then
            Valor = Recursos.provincias.AleatorioPonderado()
        Else
            Valor = Recursos.provincias(CampoMunicipio.Valor.NumeroProvincia)
        End If
        Return Valor.Texto
    End Function

End Class

Public Class CampoCodigoPostal
    Inherits CampoPredefinido

    Public Property CampoProvincia As CampoProvincia

    Public Overrides Function Aleatorio() As String
        Dim cp As String
        If CampoProvincia Is Nothing Then
            cp = Recursos.provincias.AleatorioPonderado().CodigoPostal
        Else
            cp = CampoProvincia.Valor.CodigoPostal
        End If
        cp &= Azar.Digitos(5 - cp.Length)
        Return cp
    End Function

End Class

Public Class CampoTelefono
    Inherits CampoPredefinido

    Public Overrides Function Aleatorio() As String
        Dim prefijo As String = Azar.Entre(600, 699)
        Return TelefonoAzar(prefijo)
    End Function

    Public Shared Function TelefonoAzar(Optional ByVal prefijo As String = "") As String
        If prefijo.Length < 3 Then
            prefijo = prefijo & Azar.Digitos(3 - prefijo.Length)
        End If
        Dim telefono = String.Format("{0}-{1}-{2}", prefijo, Azar.Digitos(3), Azar.Digitos(3))
        Return telefono
    End Function

End Class

Public Class CampoTelefonoFijo
    Inherits CampoTelefono

    Public Property CampoProvincia As CampoProvincia

    Public Overrides Function Aleatorio() As String
        Dim prefijo As String
        If CampoProvincia Is Nothing Then
            prefijo = Recursos.provincias.AleatorioPonderado().PrefijoTelefonico
        Else
            prefijo = CampoProvincia.Valor.PrefijoTelefonico
        End If
        Return TelefonoAzar(prefijo)
    End Function

End Class

Public Class CampoCorreo
    Inherits CampoPredefinido

    Private Shared _servidores() = {"email", "mail", "correo"}
    Private Shared _dominios() = {"com", "net", "es"}

    Public Property CampoNombre As CampoNombre
    Public Property CampoApellido As CampoApellido

    Public Overrides Function Aleatorio() As String
        Dim correo = String.Format("{0}@{1}.{2}", ObtenerUsuario(),
            Azar.ElementoArray(_servidores),
            Azar.ElementoArray(_dominios))
        Return correo
    End Function

    Private Function ObtenerUsuario() As String
        Dim formatos() = {"{0}{1}", "{0}{1}", "{0}.{1}", "{1}{2}", "{0}{1}{2}"}
        Dim formato As String = Azar.ElementoArray(formatos)
        Dim nombre As String = RecortarNombre(Normalizar(ObtenerNombre()))
        Dim apellido As String = Normalizar(ObtenerApellido())
        Return String.Format(formato, nombre, apellido, Azar.Entre(1, 100))
    End Function

    Private Function ObtenerNombre() As String
        If CampoNombre Is Nothing Then
            Return Recursos.nombres.AleatorioPonderado().Texto
        Else
            Return CampoNombre.Valor.Texto
        End If
    End Function

    Private Function ObtenerApellido() As String
        If CampoApellido Is Nothing Then
            Return Recursos.apellidos.AleatorioPonderado().Texto
        Else
            Return CampoApellido.Valor.Texto
        End If
    End Function

    Private Function Normalizar(ByVal texto As String) As String
        texto = texto.ToLower()
        texto = Utilidades.QuitarAcentos(texto)
        texto = RecortarEspacio(texto)
        Return texto
    End Function

    Private Function RecortarEspacio(ByVal texto As String) As String
        Dim posicionEspacio = texto.IndexOf(" ")
        If posicionEspacio > 0 Then
            If Azar.Entre(0, 1) Then
                texto = texto.Substring(0, posicionEspacio - 1)
            Else
                texto = texto.Replace(" ", "")
            End If
        End If
        Return texto
    End Function

    Private Function RecortarNombre(ByVal texto As String) As String
        If texto.Length > 3 Then
            Select Case Azar.Entre(1, 3)
                Case 2 : texto = texto.Substring(0, 1)
                Case 3 : texto = texto.Substring(0, 3)
            End Select
        End If
        Return texto
    End Function

End Class

Public Class CampoNacimiento
    Inherits CampoPredefinido

    Public Property Fecha() As Date
    Public Property MinimaEdad() As Integer = 18
    Public Property MaximaEdad() As Integer = 85

    Public Overrides Function Tipo() As TipoCampo
        Return TipoCampo.Fecha
    End Function

    Public Overrides Function Aleatorio() As String
        Dim añoActual = Date.Today.Year
        Dim año = Azar.Entre(añoActual - MaximaEdad, añoActual - MinimaEdad)
        Dim mes = Azar.Entre(1, 12)
        Dim diasMes = Date.DaysInMonth(año, mes)
        Dim dia = Azar.Entre(1, Math.Min(diasMes, 31))
        Fecha = New Date(año, mes, dia)
        Return Fecha.ToString("yyyy-MM-dd")
    End Function

End Class

Public Class CampoEdad
    Inherits CampoPredefinido

    Public Property CampoNacimiento As CampoNacimiento

    Public Overrides Function Tipo() As TipoCampo
        Return TipoCampo.Entero
    End Function

    Public Overrides Function Aleatorio() As String
        If CampoNacimiento Is Nothing Then
            Return Azar.Entre(18, 85)
        Else
            Return Utilidades.CalcularEdad(CampoNacimiento.Fecha)
        End If
    End Function

End Class

Public Class CampoMatricula
    Inherits CampoPredefinido

    Const LETRAS = "BCDFGHJKLMNPRSTVWXYZ"

    Public Overrides Function Aleatorio() As String
        Return String.Format("{0} {1}",
            Azar.Digitos(4),
            Azar.Simbolos(3, LETRAS))
    End Function

End Class