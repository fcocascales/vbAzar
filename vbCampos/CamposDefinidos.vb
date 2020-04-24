' CamposDefinidos.vb — ProInf.net — feb-2012
'
' Campos definidos por el usuario:
'  - CampoCodigo
'  - CampoLista
'  - CampoRango
'  - CampoMoneda
'  - CampoFecha
'  - CampoHora
'  - CampoLogico

Public Class CampoCodigo
    Inherits CampoDefinido

    'TODO: ¡¡¡¡¡Tener en cuenta el formato!!!!!!????

    Public Property Longitud As Integer
    Public Property Caracteres As String
    Public Property Formato As String

    Public Sub New(Optional ByVal texto As String = "")
        MyBase.New(texto)
    End Sub

    Public Overrides Function Aleatorio() As String
        Return Azar.Simbolos(Longitud, Caracteres)
    End Function

    Public Overrides Function ToString() As String
        Return String.Format(ObtenerFormateo(),
            Nombre, Longitud, Caracteres, Formato)
    End Function

    Private Function ObtenerFormateo() As String
        If Formato Is Nothing OrElse Formato = "" Then
            Return "Codigo {0} = {1} de {2} "
        Else
            Return "Codigo {0} = {1} de {2} formato {3}"
        End If
    End Function

    'Ej: "Codigo Clave = 5 de ABCEFG"
    Public Overrides Sub Analizar(ByVal texto As String)
        Dim analisis As New Analisis(texto)
        Nombre = analisis.Nombre
        Dim items = Split(analisis.Parametros, " ")
        If items.Length >= 3 Then
            Longitud = Utilidades.ObtenerEntero(items(0))
            Caracteres = items(2)
        End If
        If items.Length >= 5 Then
            Formato = items(4)
        End If
    End Sub

End Class

Public Class CampoLista
    Inherits CampoDefinido

    Private _elementos As String()
    Public Property Elementos() As String()
        Get
            Return _elementos
        End Get
        Set(ByVal value As String())
            _elementos = value
            RecortarEspacios()
        End Set
    End Property

    Public Sub New(Optional ByVal texto As String = "")
        MyBase.New(texto)
    End Sub

    Public Overrides Function Aleatorio() As String
        Dim indice = Azar.Entre(0, Elementos.Length - 1)
        Return Elementos(indice)
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("Lista {0} = {1}", Nombre, Join(Elementos, ", "))
    End Function

    'Ej: "Lista Zona = Norte, Este, Sur, Oeste"
    Public Overrides Sub Analizar(ByVal texto As String)
        Dim analisis = New Analisis(texto)
        Nombre = analisis.Nombre
        Elementos = Split(analisis.Parametros.Trim(), ",")
    End Sub

    Private Sub RecortarEspacios()
        If _elementos IsNot Nothing Then
            For i = 0 To _elementos.Length - 1
                _elementos(i) = Trim(_elementos(i))
            Next
        End If
    End Sub

End Class

Public Class CampoRango
    Inherits CampoDefinido

    Public Property Minimo As Integer
    Public Property Maximo As Integer
    Public Property Numeral As Numerales

    Public Sub New(Optional ByVal texto As String = "")
        MyBase.New(texto)
    End Sub

    Public Overrides Function Tipo() As TipoCampo
        If Recursos.numerales.EsNumerico(Numeral) Then
            Tipo = TipoCampo.Entero
        Else
            Tipo = TipoCampo.Texto
        End If
    End Function

    Public Overrides Function Aleatorio() As String
        Dim numero = Azar.Entre(Minimo, Maximo)
        Dim resultado = Recursos.numerales(Numeral).Secuenciar(numero)
        Return resultado
    End Function

    Public Overrides Function ToString() As String
        Return String.Format(ObtenerFormateo(), Nombre, Minimo, Maximo, Numeral)
    End Function

    Private Function ObtenerFormateo() As String
        If Recursos.numerales.EsNumerico(Numeral) Then
            Return "Rango {0} = entre {1} y {2}"
        Else
            Return "Rango {0} = entre {1} y {2} numeral {3}"
        End If
    End Function

    'Ej: "Rango Importe = entre 50 y 300"
    Public Overrides Sub Analizar(ByVal texto As String)
        Dim analisis As New Analisis(texto)
        Nombre = analisis.Nombre
        Numeral = Numerales.Numeración_Arábiga
        Dim items = Split(analisis.Parametros, " ")
        If items.Length >= 4 Then
            Minimo = Utilidades.ObtenerEntero(items(1))
            Maximo = Utilidades.ObtenerEntero(items(3))
        End If
        If items.Length >= 6 Then
            Numeral = [Enum].Parse(GetType(Numerales), items(5))
        End If
    End Sub

End Class

Public Class CampoMoneda
    Inherits CampoDefinido

    Public Shared unidades() As Decimal = {
        0.01, 0.02, 0.05,
        0.1, 0.2, 0.5,
        1, 2, 5,
        10, 20, 50,
        100, 200, 500,
        1000, 2000, 5000}

    Public Property Minimo() As Decimal
    Public Property Maximo() As Decimal
    Public Property Unidad() As Decimal

    Public Property IndiceUnidad() As Integer
        Get
            Return Array.IndexOf(unidades, Unidad)
        End Get
        Set(ByVal value As Integer)
            Unidad = unidades(value)
        End Set
    End Property

    Public Sub New(Optional ByVal texto As String = "")
        MyBase.New(texto)
    End Sub

    Public Overrides Function Tipo() As TipoCampo
        Return TipoCampo.Numero
    End Function

    Public Overrides Function Aleatorio() As String
        Dim moneda As Decimal = Unidad * Azar.Entre(Minimo / Unidad, Maximo / Unidad)
        Return NormalizarDecimal(moneda)
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("Moneda {0} = entre {1} y {2} unidad {3}",
            Nombre, Minimo, Maximo, Unidad)
    End Function

    'Ej: "Moneda Importe = entre 1000 y 5000 unidad 0,5"
    Public Overrides Sub Analizar(ByVal texto As String)
        Dim analisis = New Analisis(texto)
        Nombre = analisis.Nombre
        Dim items = Split(analisis.Parametros, " ")
        If items.Count >= 6 Then
            Minimo = Utilidades.ObtenerEntero(items(1))
            Maximo = Utilidades.ObtenerEntero(items(3))
            Unidad = Utilidades.ObtenerDecimal(items(5))
        End If
    End Sub

    Public Shared Function NormalizarDecimal(ByVal numero As Decimal) As String
        Return numero.ToString("0.00").Replace(",", ".")
    End Function

End Class

Public Class CampoFecha
    Inherits CampoDefinido

    Public Property Minimo As Date
    Public Property Maximo As Date
    Public Property Semana As String 'LMXJVSD

    Public Property DiasSemana As Integer()
        Get
            Dim lista As New List(Of Integer)
            For Each caracter In Semana
                Dim indice = "LMXJVSD".IndexOf(caracter)
                If indice >= 0 Then lista.Add(indice)
            Next
            Return lista.ToArray()
        End Get
        Set(ByVal value As Integer())
            Dim dias As New List(Of Char)
            For Each indice In value
                If indice >= 0 And indice <= 6 Then
                    dias.Add("LMXJVSD"(indice))
                End If
            Next
            Semana = New String(dias.ToArray())
        End Set
    End Property

    Public Sub New(Optional ByVal texto As String = "")
        MyBase.New(texto)
    End Sub

    Public Overrides Function Tipo() As TipoCampo
        Return TipoCampo.Fecha
    End Function

    Public Overrides Function Aleatorio() As String
        Dim dias As TimeSpan = Maximo.Subtract(Minimo)
        Dim fortuna As Integer = Azar.Entre(0, dias.Days)
        Dim fecha As Date = Minimo.AddDays(fortuna)
        If Semana <> "" Then fecha = ObtenerDiaSemana(fecha)
        Return fecha.ToString("yyyy-MM-dd")
    End Function

    Private Function ObtenerDiaSemana(ByVal fecha As Date) As Date
        For i = 1 To 7
            If EsDiaSemana(fecha) Then Exit For
            fecha = fecha.AddDays(1)
        Next
        Return fecha
    End Function

    Private Function EsDiaSemana(ByVal fecha As Date) As Boolean
        If Semana = "" Then Return True
        For Each caracter In Semana
            Dim diaSemana = "DLMXJVS".IndexOf(caracter)
            If diaSemana < 0 Or diaSemana = fecha.DayOfWeek Then Return True
        Next
        Return False
    End Function

    Public Overrides Function ToString() As String
        Return String.Format(ObtenerFormateo(), Nombre,
            Minimo.ToString("yyyy-MM-dd"),
            Maximo.ToString("yyyy-MM-dd"),
            Semana.ToUpper())
    End Function

    Private Function ObtenerFormateo() As String
        If Semana = "" Then
            Return "Fecha {0} = entre {1} y {2}"
        Else
            Return "Fecha {0} = entre {1} y {2} semana {3}"
        End If
    End Function

    'Ej: "Fecha Alta = entre 2012-01-01 y 2012-01-31"
    Public Overrides Sub Analizar(ByVal texto As String)
        Dim analisis = New Analisis(texto)
        Nombre = analisis.Nombre
        Semana = ""
        Dim items = analisis.Parametros.Split(" ")
        If items.Length >= 4 Then
            Minimo = Date.Parse(items(1))
            Maximo = Date.Parse(items(3))
        End If
        If items.Length >= 6 Then
            Semana = items(5)
        End If
    End Sub
End Class

Public Class CampoHora
    Inherits CampoDefinido

    Public Property Minimo() As Date
    Public Property Maximo() As Date

    Public Sub New(Optional ByVal texto As String = "")
        MyBase.New(texto)
    End Sub

    Public Overrides Function Tipo() As TipoCampo
        Return TipoCampo.Hora
    End Function

    Public Overrides Function Aleatorio() As String
        Dim tiempo As TimeSpan = Maximo.Subtract(Minimo)
        Dim segundos = (tiempo.Hours * 60 + tiempo.Minutes) * 60 + tiempo.Seconds
        Dim fortuna As Integer = Azar.Entre(0, segundos)
        Dim fecha As Date = Minimo.AddSeconds(fortuna)
        Return fecha.ToString("HH:mm")
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("Hora {0} = entre {1} y {2}", Nombre,
            Minimo.ToString("HH:mm"),
            Maximo.ToString("HH:mm"))
    End Function

    'Ej: "Hora Entrada = entre 09:00 y 13:30"
    Public Overrides Sub Analizar(ByVal texto As String)
        Dim analisis = New Analisis(texto)
        Nombre = analisis.Nombre
        Dim items = analisis.Parametros.Split(" ")
        If items.Length >= 4 Then
            Minimo = Date.Parse(items(1))
            Maximo = Date.Parse(items(3))
        End If
    End Sub
End Class

Public Class CampoLogico
    Inherits CampoDefinido

    Public Sub New(Optional ByVal texto As String = "")
        MyBase.New(texto)
    End Sub

    Public Overrides Function Tipo() As TipoCampo
        Return TipoCampo.Logico
    End Function

    Public Overrides Function Aleatorio() As String
        Return {"False", "True"}(Azar.Entre(0, 1))
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("Logico {0} = False, True", Nombre)
    End Function

    Public Overrides Sub Analizar(ByVal texto As String)
        Dim analisis = New Analisis(texto)
        Nombre = analisis.Nombre
    End Sub

End Class

Public Class CampoTexto
    Inherits CampoDefinido

    Public Property Minimo As Integer
    Public Property Maximo As Integer

    Public Sub New(Optional ByVal texto As String = "")
        MyBase.New(texto)
    End Sub

    Public Overrides Function Aleatorio() As String
        Dim totalPalabras = Azar.Entre(Minimo, Maximo)
        Dim contadorPalabras = 0
        Dim sb As New System.Text.StringBuilder()
        Do Until contadorPalabras >= totalPalabras
            Dim numeroPalabrasFrase = Azar.Entre(5, 30)
            Dim quedanPalabras = totalPalabras - contadorPalabras
            If quedanPalabras <= 10 Or numeroPalabrasFrase > quedanPalabras Then
                numeroPalabrasFrase = quedanPalabras
            End If
            contadorPalabras += numeroPalabrasFrase
            Dim frase = Recursos.palabrasComunes.FraseAleatoria(numeroPalabrasFrase)
            sb.Append(frase)
            sb.Append(" ")
        Loop
        Return sb.ToString()
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("Texto {0} = entre {1} y {2} palabras", Nombre, Minimo, Maximo)
    End Function

    Public Overrides Sub Analizar(ByVal texto As String)
        Dim analisis = New Analisis(texto)
        Nombre = analisis.Nombre
        Dim items = Split(analisis.Parametros, " ")
        If items.Length >= 4 Then
            Minimo = Utilidades.ObtenerEntero(items(1))
            Maximo = Utilidades.ObtenerEntero(items(3))
        End If
    End Sub

End Class

Public Class CampoContador
    Inherits CampoDefinido
    Implements IReiniciable

    Private _contador As Decimal = 1

    Public Property Inicio As Decimal
    Public Property Incremento As Decimal
    Public Property Numeral As Numerales
    Public Property Palabra As String
    Public Property Femenina As Boolean

    Public Sub New(Optional ByVal texto As String = "")
        MyBase.New(texto)
    End Sub

    Public Overrides Function Tipo() As TipoCampo
        If Recursos.numerales.EsNumerico(Numeral) Then
            Tipo = TipoCampo.Entero
        Else
            Tipo = TipoCampo.Texto
        End If
    End Function

    Public Overrides Function Aleatorio() As String
        Dim numeracion As INumeral = Recursos.numerales(Numeral)
        Dim esApalabrado = TypeOf numeracion Is IApalabrado
        If esApalabrado Then DirectCast(numeracion, IApalabrado).Apalabrar(Palabra, Femenina)
        Dim valor = numeracion.Secuenciar(_contador)
        AumentarContador()
        Return If(esApalabrado, valor, Palabra & valor)
    End Function

    Private Sub AumentarContador()
        Try
            _contador += Incremento
        Catch ex As OverflowException
            _contador = 1
        End Try
    End Sub

    Public Overrides Function ToString() As String
        Dim genero = If(Femenina, "F", "M")
        Return String.Format(ObtenerFormateo(),
            Nombre, Inicio, Incremento, Numeral, Palabra, genero)
    End Function

    Private Function ObtenerFormateo() As String
        If Palabra Is Nothing OrElse Palabra.Trim() = "" Then
            If Numeral = Numerales.Numeración_Arábiga Then
                Return "Contador {0} = desde {1} sumando {2}"
            Else
                Return "Contador {0} = desde {1} sumando {2} numeral {3}"
            End If
        Else
            Return "Contador {0} = desde {1} sumando {2} numeral {3} palabra '{4}' {5}"
        End If
    End Function

    'Ej: "Contador cuenta = desde 1 sumando 5 numeral Griego"
    Public Overrides Sub Analizar(ByVal texto As String)
        Dim analisis = New Analisis(texto)
        Nombre = analisis.Nombre
        Numeral = Numerales.Numeración_Arábiga
        Palabra = ""
        Dim items = Split(analisis.Parametros, " ")
        If items.Length >= 4 Then
            Inicio = Utilidades.ObtenerEntero(items(1))
            Incremento = Utilidades.ObtenerEntero(items(3))
        End If
        If items.Length >= 6 Then Numeral = [Enum].Parse(GetType(Numerales), items(5))
        If items.Length >= 8 Then Palabra = Utilidades.RecortarComillas(items(7))
        If items.Length >= 9 Then Femenina = (items(8) = "F")

    End Sub

    Public Sub Reiniciar() Implements IReiniciable.Reiniciar
        _contador = Inicio
    End Sub

End Class
