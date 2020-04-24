' Alfabeto.vb — ProInf.net — feb-2012
'
' Clases para generar secuencias de números, letras, etc.
'
'
' Posible ampliación:
' - El sistema numérico Nahuatl - www.elsurcodelsembrador.com/ximopanolti/content/view/37/51/

'================================================
' NUMERALES
'¡Esta enumeración se ha de sincronizar con DiccionarioNumerales!

Public Enum Numerales
    Alfabético ' A B C D E ... Z AA AB ...
    Alfabético_Español ' a be ce de e ...
    Alfabético_Griego ' Alfa Beta Gamma Delta Épsilon ...
    Alfabético_Musical 'do re mi fa sol la si dodo dore ...
    Alfabético_Radiofónico ' Alfa Bravo Charlie Delta Echo
    Cardinal_Alfaromano ' i a ai e ei  ..
    Cardinal_Español ' uno dos tres cuatro cinco ... 
    Cardinal_Esperanto ' unu du tri kvar kvin ...
    Cardinal_Interlingua 'un duo tres quatro cinque ...
    Cardinal_Klingon ' wa' cha' wej loS vagh ...
    Cardinal_Japonés ' ichi ni san yen go ...
    Cardinal_Latín ' unus duo tres quattuor quinque ...
    Cardinal_Lojban 'pa re ci vo mu ...
    Cardinal_Sona ' enna do tin ca pen ...
    Medición_Internacional '(con byte) un byte ... 2 kilobytes y tres bytes ...
    Medición_Temporal 'un día, dos días, ..., tres años y un día ...
    Numeración_Arábiga ' 1 2 3 4 5 ...
    Numeración_Hexadecimal ' 1 2 3 4 5 6 7 8 9 A B C ...
    Numeración_Romana ' I II III IV V ... 
    Ordinal_Español ' primero segundo tercero cuarto quinto ...
End Enum

Public Interface INumeral
    Function Secuenciar(ByVal numero As Decimal) As String
    Function Separador() As String
    'Function Ejemplo() As String
End Interface

Public MustInherit Class NumeralAbstracto
    Implements INumeral

Public MustOverride Function Secuenciar(ByVal numero As Decimal) As String _
Implements INumeral.Secuenciar

    Public Overridable Function Separador() As String _
    Implements INumeral.Separador
        Return ""
    End Function

    Public Shared Sub Secuenciar(
        ByVal numero As Integer,
        ByVal total As Integer,
        ByVal accion As Action(Of Integer)
    )
        Dim cociente As Integer = numero - 1
        Do
            Dim modulo = cociente Mod total
            accion(modulo)
            cociente = cociente \ total - 1
        Loop Until cociente < 0
    End Sub
End Class

Public MustInherit Class NumeralArray
    Inherits NumeralAbstracto

    Protected MustOverride Function ObtenerArray() As String()

    Public Overrides Function Separador() As String
        Return " "
    End Function

    Public Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Dim lista As New List(Of String)
        Dim array = ObtenerArray()
        Secuenciar(numero, array.Length,
            Sub(modulo As Integer)
                If modulo >= 0 Then
                    lista.Insert(0, array(modulo))
                End If
            End Sub)
        Return Join(lista.ToArray(), Separador())
    End Function

End Class

'================================================
' IMPLEMENTACIÓN DE LOS NUMERALES

Public Class NumeralAlfabetico 'Como las columnas de una hoja de cálculo
    Inherits NumeralAbstracto

    Private Shared alfabetico As String = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"

    Public Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Dim sb As New System.Text.StringBuilder()
        Secuenciar(numero, alfabetico.Length, Sub(modulo As Integer) sb.Insert(0, alfabetico(modulo)))
        Return sb.ToString()
    End Function

End Class

Public Class NumeralAlfabeticoEspañol
    Inherits NumeralArray

    'http://www.rae.es/

    Public Property Plural As Boolean

    Private Shared singulares = {
        "a", "be", "ce", "de", "e", "efe", "ge", "hache", "i", "jota", "ka",
        "ele", "eme", "ene", "eñe", "o", "pe", "cu", "erre", "ese", "te",
        "u", "uve", "uve doble", "equis", "ye", "zeta"
    }
    Private Shared plurales = {
        "aes", "bes", "ces", "des", "es", "efes", "ges", "haches", "íes", "jotas", "kas",
        "eles", "emes", "enes", "eñes", "oes", "pes", "cus", "erres", "eses", "tes",
        "úes", "uves", "uves dobles", "equis", "yes", "zetas"
    }

    Public Sub New(Optional ByVal enPlural As Boolean = False)
        Plural = enPlural
    End Sub

    Protected Overrides Function ObtenerArray() As String()
        If Plural Then Return plurales Else Return singulares
    End Function

End Class

Public Class NumeralAlfaromano 'Cardinal inventado
    Inherits NumeralAbstracto

    Public Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Dim texto = NumeracionAlfaromana.Obtener(numero)
        Return Utilidades.Capitalizar(texto)
    End Function

End Class

Public Class NumeralArabigo 'Numérico
    Inherits NumeralAbstracto

    Public Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Return numero.ToString()
    End Function

End Class

Public Class NumeralEspañol 'Cardinal en Español
    Inherits NumeralAbstracto
    Implements IApalabrado

    Private apalabrado As New Apalabrado()

    'Nombres de los números en español
    'http://es.wikipedia.org/wiki/Anexo:Nombres_de_los_números_en_español

    Public Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Dim cardinal As String
        Dim palabra As String = apalabrado.Obtener(numero = 1)
        If apalabrado.EsFemenina() Then
            cardinal = CifrasEnLetras.convertirCifrasEnLetrasFemeninas(numero)
        ElseIf palabra <> "" Then
            cardinal = CifrasEnLetras.convertirCifrasEnLetras(numero)
        Else
            cardinal = CifrasEnLetras.convertirCifrasEnLetrasMasculinas(numero)
        End If
        Return Utilidades.Capitalizar(cardinal & palabra)
    End Function

    Public Sub Apalabrar(ByVal palabra As String, ByVal esFemenina As Boolean
    ) Implements IApalabrado.Apalabrar
        apalabrado.Apalabrar(palabra, esFemenina)
    End Sub

End Class

Public Class NumeralEsperanto 'Cardinal en Esperanto
    Inherits NumeralAbstracto

    Public Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Dim texto = NumeracionEsperanto.Obtener(numero)
        Return Utilidades.Capitalizar(texto)
    End Function

End Class

Public Class NumeralGriego 'Alfabético en Griego
    Inherits NumeralArray

    Public Shared griego = {"Alfa", "Beta", "Gamma", "Delta", "Épsilon", "Dseta",
        "Eta", "Theta", "Iota", "Kappa", "Lambda", "Mi", "Ni", "Xi", "Ómicron", "Pi",
        "Rho", "Sigma", "Tau", "Ípsilon", "Fi", "Ji", "Psi", "Omega"}

    Protected Overrides Function ObtenerArray() As String()
        Return griego
    End Function

End Class

Public Class NumeralHexadecimal 'Numeración en hexadecimal
    Inherits NumeralAbstracto

    Public Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Return Hex(numero)
    End Function

End Class

Public Class NumeralInterlingua 'Cardinal en Interlingua
    Inherits NumeralAbstracto

    'http://www.languagesandnumbers.com/como-contar-en-interlingua/es/ina/

    Public Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Dim texto = NumeracionInterlingua.Obtener(numero)
        Return Utilidades.Capitalizar(texto)
    End Function

End Class

Public Class NumeralInternacional 'Medición en el Sistema Internacional
    Inherits NumeralAbstracto
    Implements IApalabrado

    Private _enLetras As Boolean
    Private _palabra As String
    Private _femenina As Boolean

    Public Sub New(ByVal enLetras As Boolean)
        _enLetras = enLetras
    End Sub

    Public Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Dim texto As String
        If _enLetras Then
            texto = NumeracionInternacional.ObtenerEnLetras(numero, _palabra, , _femenina)
        Else
            texto = NumeracionInternacional.ObtenerEnCifras(numero, _palabra)
        End If
        Return Utilidades.Capitalizar(texto)
    End Function

    Public Sub Apalabrar(ByVal palabra As String, ByVal esFemenina As Boolean
    ) Implements IApalabrado.Apalabrar
        _palabra = palabra
        _femenina = esFemenina
    End Sub

End Class

Public Class NumeralKlingon 'Cardinal en Klingon (Star Trek)
    Inherits NumeralAbstracto

    'http://www.languagesandnumbers.com/como-contar-en-klingon/es/tlh/

    Public Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Return NumeracionKlingon.Obtener(numero)
    End Function

End Class

Public Class NumeralJapones 'Cardinal en Japonés
    Inherits NumeralAbstracto

    'http://es.wikipedia.org/wiki/Numeración_japonesa

    Public Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Dim texto = NumeracionJaponesa.Obtener(numero)
        Return Utilidades.Capitalizar(texto)
    End Function

End Class

Public Class NumeralMusical 'Alfabético de notas musicales
    Inherits NumeralArray

    Public Shared notas = {"Do", "Re", "Mi", "Fa", "Sol", "La", "Si"}

    Public Overrides Function Separador() As String
        Return " "
    End Function

    Protected Overrides Function ObtenerArray() As String()
        Return notas
    End Function

    Public Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Dim texto As String = MyBase.Secuenciar(numero)
        Return texto
    End Function

End Class

Public Class NumeralLatin 'Cardinal en Latín
    Inherits NumeralAbstracto

    Public Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Dim texto = NumeracionLatin.ObtenerEnMasculino(numero)
        Return Utilidades.Capitalizar(texto)
    End Function

End Class

Public Class NumeralOrdinalEspañol 'Ordinal en Español
    Inherits NumeralAbstracto
    Implements IApalabrado

    'http://es.wikipedia.org/wiki/Número_ordinal

    Public Overloads Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Dim texto As String = NumeracionOrdinal.Obtener(numero)
        Return Utilidades.Capitalizar(texto)
    End Function

    Public Sub Apalabrar(ByVal palabra As String, ByVal esFemenina As Boolean
    ) Implements IApalabrado.Apalabrar
        NumeracionOrdinal.Apalabrar(palabra, esFemenina)
    End Sub

End Class

Public Class NumeralRadiofonico 'Alfabético radiofónico
    Inherits NumeralArray

    'http://es.wikipedia.org/wiki/Alfabeto_por_palabras
    'http://es.wikipedia.org/wiki/Alfabeto_radiofónico

    Public Shared radiofonico = {"Alfa", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot",
        "Golf", "Hotel", "India", "Juliet", "Kilo", "Lima", "Mike", "November", "Oscar",
        "Papa", "Quebec", "Romeo", "Sierra", "Tango", "Uniform", "Victor", "Whiskey",
        "X-ray", "Yankee", "Zulu"}

    Protected Overrides Function ObtenerArray() As String()
        Return radiofonico
    End Function

End Class

Public Class NumeralRomano 'Numeración en Romano
    Inherits NumeralAbstracto

    'http://es.wikipedia.org/wiki/Numeración_romana

    Public Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Return NumeracionRomana.Obtener(numero)
    End Function

End Class

Public Class NumeralTemporal 'Medición de tiempo transcurrido
    Inherits NumeralAbstracto

    'http://es.wikipedia.org/wiki/Sistemas_de_tiempo

    Private _enLetras As Boolean

    Public Sub New(ByVal enLetras As Boolean)
        _enLetras = enLetras
    End Sub

    Public Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Dim texto As String
        If _enLetras Then
            texto = NumeracionTemporal.ObtenerEnLetras(numero)
        Else
            texto = NumeracionTemporal.ObtenerEnCifras(numero)
        End If
        Return Utilidades.Capitalizar(texto)
    End Function

End Class

Public Class NumeralSona 'Cardinal en Sona
    Inherits NumeralAbstracto

    Public Overloads Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Return NumeracionSona.Obtener(numero)
    End Function

End Class

Public Class NumeralLojban 'Cardinal en Lojban
    Inherits NumeralAbstracto

    ' http://es.wikipedia.org/wiki/Lojban

    '0..9
    Private Shared digitos As String() = {
        "no", "pa", "re", "ci", "vo", "mu", "xa", "ze", "bi", "so"}

    Public Overloads Overrides Function Secuenciar(ByVal numero As Decimal) As String
        Dim sb As New System.Text.StringBuilder()
        Do
            Dim digito = numero Mod 10
            numero \= 10
            sb.Insert(0, digitos(digito))
        Loop While numero > 0
        Return sb.ToString()
    End Function

End Class