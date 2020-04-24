' CifrasEnLetras.vb — ProInf.net — 19-ene-2011
' http://proinf.net/permalink/convertir_cifras_en_letras

Imports System.Text

''' <summary>
''' CifrasEnLetras sirve para expresar una serie de cifras en letras. 
''' A modo de ejemplo convierte <q>22</q> en <q>veintidós</q>.
''' Puede convertir un número entre una y ciento veintiséis cifras como máximo.
''' </summary>
''' <dl>
''' <dt>Ejemplos de uso:</dt>
''' <dd><code>CifrasEnLetras.convertirEurosEnLetras(22.34)</code> &rarr; <samp>"veintidós euros con treinta y cuatro céntimos"</samp></dd>
''' <dd><code>CifrasEnLetras.convertirNumeroEnLetras("35,67")</code> &rarr; <samp>"treinta y cinco con sesenta y siete"</samp></dd> 
'''
''' <dt>Enlaces de referencia:</dt>
''' <dd><a href="http://es.wikipedia.org/wiki/Anexo:Lista_de_n%C3%BAmeros">Lista de números en la Wikipedia</a></dd>
''' <dd><a href="http://es.encarta.msn.com/encyclopedia_761577100/Signos_matem%C3%A1ticos.html">Signos matemáticos en Encarta</a></dd>
''' <dd><a href="http://es.wikipedia.org/wiki/Nombres_de_los_n%C3%BAmeros_en_espa%C3%B1ol">Nombres de los números en español</a></dd>
''' 
''' <dt>Tareas pendientes:</dt>
''' <dd>Función ConvertirAñosEnLetras: "cuatro años", "un lustro", "una década", "dos décadas", "un siglo", "un milenio"</dd>
''' <dd>Función ConvertirOrdinalesEnLetras: "primero", "segundo", etc.</dd>
''' <dd>Función ConvertirCifrasEnRomano y convertirRomanoEnCifras</dd>
''' <dd>Función ConvertirFechasEnLetras: "21-XI-2007" &rarr; "veintiuno de noviembre de dos mil siete"</dd>
''' 
''' <dt>Licencia:</dt>
''' <dd><a href="http://creativecommons.org/licenses/GPL/2.0/deed.es">
''' Este software está sujeto a la CC-GNU GPL</a>
''' </dd> 
''' </dl>
''' 
''' @author Francisco Cascales <fco@proinf.net>
''' @version 0.01,  8-dic-2007 - Inicio del proyecto
''' @version 0.02, 12-dic-2007 - Cifras en femenino
''' @version 0.03, 17-dic-2007 - Formatear cifras separándolas en grupos
''' @version 0.04, 22-dic-2007 - Múltiplos de millón con preposición "de" antes del concepto: 
'''                                "un millón de euros", "dos millones de euros", "un millón mil un euros"  
'''                              Las cifras superiores al millón siempre en masculino.
'''                                "doscientos millones doscientas mil personas"
''' @version 0.05,  7-ene-2008 - Mejoras estructurales
''' @versión 0.06  19-ene-2011 - Convertido a C# con MonoDevelop 2.4
''' @version 0.07  20-ene-2011 - Convertido a VB.NET
''' 
Public NotInheritable Class CifrasEnLetras

    '------------------------------------------------------------
    ' CONSTANTES

    Private Const PREFIJO_ERROR As String = "Error: "
    Private Const COMA As String = ","
    Private Const MENOS As String = "-"

    '------------------------------------------------------------
    ' ENUMERACIONES

    Public Enum Genero
        neutro
        masculino
        femenino
    End Enum

    Public Shared Function generoDesdeNumero(ByVal numero As Integer) As Genero
        If numero = 0 Then
            Return Genero.neutro
        ElseIf numero = 1 Then
            Return Genero.masculino
        End If
        Return Genero.femenino
    End Function

    '------------------------------------------------------------
    ' LISTAS

    ' Letras de los números entre el 0 y el 29 
    Private Shared listaUnidades As String() = {"cero", "un", "dos", "tres", "cuatro", "cinco", _
     "seis", "siete", "ocho", "nueve", "diez", "once", _
     "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", _
     "dieciocho", "diecinueve", "veinte", "veintiún", "veintidós", "veintitrés", _
    "veinticuatro", "veinticinco", "veintiséis", "veintisiete", "veintiocho", "veintinueve"}

    ' Letras de las decenas 
    Private Shared listaDecenas As String() = {"", "diez", "veinte", "treinta", "cuarenta", "cincuenta", _
    "sesenta", "setenta", "ochenta", "noventa"}

    ' Letras de las centenas 
    Private Shared listaCentenas As String() = {"", "cien", "doscientos", "trescientos", "cuatrocientos", "quinientos", _
    "seiscientos", "setecientos", "ochocientos", "novecientos"}

    ' Letras en singular de los órdenes de millón.
    Private Shared listaOrdenesMillonSingular As String() = {"", "millón", "billón", "trillón", "cuatrillón", "quintillón", _
     "sextillón", "septillón", "octillón", "nonillón", "decillón", "undecillón", _
     "duodecillón", "tridecillón", "cuatridecillón", "quidecillón", "sexdecillón", "septidecillón", _
    "octodecillón", "nonidecillón", "vigillón"}

    ' Letras en plural de los órdenes de millón 
    Private Shared listaOrdenesMillonPlural As String() = {"", "millones", "billones", "trillones", "cuatrillones", "quintillones", _
     "sextillones", "septillones", "octillones", "nonillones", "decillones", "undecillones", _
     "duodecillones", "tridecillones", "cuatridecillones", "quidecillones", "sexdecillones", "septidecillones", _
    "octodecillones", "nonidecillones", "vigillones"}

    '------------------------------------------------------------
    ' MÉTODOS PRINCIPALES

    ''' Convierte a letras los números entre 0 y 29. 
    '''  Ejemplo: <code>convertirUnidades(21,Genero.femenino)</code> &rarr; <samp>"veintiuna"</samp>
    '''
    Public Shared Function convertirUnidades(ByVal unidades As Integer, ByVal elGenero As Genero) As String
        If unidades = 1 Then
            If elGenero = Genero.masculino Then
                Return "uno"
            ElseIf elGenero = Genero.femenino Then
                Return "una"
            End If
        ElseIf unidades = 21 Then
            If elGenero = Genero.masculino Then
                Return "veintiuno"
            ElseIf elGenero = Genero.femenino Then
                Return "veintiuna"
            End If
        End If
        Return listaUnidades(unidades)
    End Function

    ''' Convierte a letras las centenas 
    ''' Ejemplo: <code>convertirCentenas(2,Genero.femenino)</code> &rarr; <samp>"doscientas"</samp>
    '''
    Public Shared Function convertirCentenas(ByVal centenas As Integer, ByVal elGenero As Genero) As String
        Dim resultado As String = listaCentenas(centenas)
        If elGenero = Genero.femenino Then
            resultado = resultado.Replace("iento", "ienta")
        End If
        Return resultado
    End Function

    ''' Primer centenar: del cero al noventa y nueve.
    ''' <dl>
    ''' <dt>Ejemplos:</dt>
    ''' <dd><code>convertirDosCifras(22,Genero.neutro)</code> &rarr; <samp>"veintidós"</samp></dd>
    ''' </dl>
    ''' <see cref="convertirUnidades(int,Genero)"/>
    '''
    Public Shared Function convertirDosCifras(ByVal cifras As Integer, ByVal elGenero As Genero) As String
        Dim unidad As Integer = cifras Mod 10
        Dim decena As Integer = cifras \ 10
        If cifras < 30 Then
            Return convertirUnidades(cifras, elGenero)
        ElseIf unidad = 0 Then
            Return listaDecenas(decena)
        Else
            Return listaDecenas(decena) & " y " & convertirUnidades(unidad, elGenero)
        End If
    End Function

    ''' Primer millar: del cero al novecientos noventa y nueve.
    ''' <dl>
    ''' <dt>Ejemplos:</dt>
    ''' <dd><code>convertirTresCifras(222,Genero.neutro)</code> &rarr; <samp>"doscientos veintidós"</samp></dd>
    ''' </dl>
    ''' <see cref="convertirDosCifras(int,Genero)"/>
    ''' <see cref="convertirCentenas(int,Genero)"/>
    '''
    Public Shared Function convertirTresCifras(ByVal cifras As Integer, ByVal elGenero As Genero) As String
        Dim decenas_y_unidades As Integer = cifras Mod 100
        Dim centenas As Integer = cifras \ 100
        If cifras < 100 Then
            Return convertirDosCifras(cifras, elGenero)
        ElseIf decenas_y_unidades = 0 Then
            Return convertirCentenas(centenas, elGenero)
        ElseIf centenas = 1 Then
            Return "ciento " & convertirDosCifras(decenas_y_unidades, elGenero)
        Else
            Return convertirCentenas(centenas, elGenero) & " " & convertirDosCifras(decenas_y_unidades, elGenero)
        End If
    End Function

    ''' Primer millón: del cero al novecientos noventa y nueve mil novecientos noventa y nueve.     
    ''' <dl>
    ''' <dt>Ejemplos:</dt>
    ''' <dd><code>convertirSeisCifras(222222)</code> &rarr; <samp>"doscientos veintidós mil doscientos veintidós"</samp></dd>
    ''' </dl>
    ''' <see cref="convertirTresCifras(int,Genero)"/>
    '''
    Public Shared Function convertirSeisCifras(ByVal cifras As Integer, ByVal elGenero As Genero) As String
        Dim primerMillar As Integer = cifras Mod 1000
        Dim grupoMiles As Integer = cifras \ 1000
        Dim generoMiles As Genero = If(elGenero = Genero.masculino, Genero.neutro, elGenero)
        If grupoMiles = 0 Then
            Return convertirTresCifras(primerMillar, elGenero)
        ElseIf grupoMiles = 1 Then
            If primerMillar = 0 Then
                Return "mil"
            Else
                Return "mil " & convertirTresCifras(primerMillar, elGenero)
            End If
        ElseIf primerMillar = 0 Then
            Return convertirTresCifras(grupoMiles, generoMiles) & " mil"
        Else
            Return convertirTresCifras(grupoMiles, generoMiles) & " mil " & convertirTresCifras(primerMillar, elGenero)
        End If
    End Function

    ''' <summary>
    ''' Números enteros entre el cero y el novecientos noventa y nueve mil novecientos noventa y nueve vigillones... etc, etc.<br />
    ''' Es decir entre el 0 y el (10<sup>126</sup>)-1 o bien números entre 1 y 126 cifras.<br />
    ''' Las cifras por debajo del millón pueden ir en masculino o en femenino.
    ''' </summary>	    
    '''<dl>
    '''<dt>Ejemplos:</dt>
    '''<dd><code>convertirCifrasEnLetras("22222222")</code> &rarr; <samp>"veintidós millones doscientos veintidós mil doscientos veintidós"</samp></dd>
    ''' <dd><code>convertirCifrasEnLetras("")</code> &rarr; <samp>"No hay ningún número"</samp></dd>
    ''' <dd><code>convertirCifrasEnLetras(repetirCaracter('9',127))</code> &rarr; <samp>"El número es demasiado grande ya que tiene más de 126 cifras"</samp></dd>
    ''' <dd><code>convertirCifrasEnLetras("0x")</code> &rarr; <samp>"Uno de los caracteres no es una cifra decimal"</samp></dd>
    ''' <dd><code>convertirCifrasEnLetras(repetirCaracter('9',126))</code> &rarr; <samp>"novecientos noventa y nueve mil novecientos noventa y nueve vigillones..."</samp></dd>
    ''' <dd><code>convertirCifrasEnLetras(10^6)</code> &rarr; <samp>"un millón"</samp></dd>
    ''' <dd><code>convertirCifrasEnLetras(10^12)</code> &rarr; <samp>"un billón"</samp></dd>
    ''' <dd><code>convertirCifrasEnLetras(10200050)</code> &rarr; <samp>"diez millones doscientos mil cincuenta"</samp></dd>
    ''' <dd><code>convertirCifrasEnLetras(10001000)</code> &rarr; <samp>"diez millones mil"</samp></dd>
    ''' <dd><code>convertirCifrasEnLetras("1" + repetirCaracter('0',120))</code> &rarr; <samp>"un vigillón"</samp></dd>
    ''' <dd><code>convertirCifrasEnLetras("2" + repetirCaracter('0',18))</code> &rarr; <samp>"dos trillones"</samp></dd>
    ''' <dd><code>convertirCifrasEnLetras("4792347927489", "\n")</code> &rarr; <samp>"..."</samp></dd>
    ''' <dd><code>convertirCifrasEnLetrasFemeninas("501")</code> &rarr; <samp>"quinientas una"</samp></dd>
    ''' <dd><code>convertirCifrasEnLetrasFemeninas("240021")</code> &rarr; <samp>"doscientas cuarenta mil veintiuna"</samp></dd>
    ''' </dl>
    ''' <see cref="convertirSeisCifras(int,Genero)"/>
    '''
    Public Shared Function convertirCifrasEnLetras( _
        ByVal cifras As String, _
        ByVal elGenero As Genero, _
        ByVal separadorGruposSeisCifras As String _
     ) As String

        ' Inicialización
        cifras = cifras.Trim()
        Dim numeroCifras As Integer = cifras.Length

        ' Comprobación
        If numeroCifras = 0 Then
            Return PREFIJO_ERROR & "No hay ningún número"
        End If
        For indiceCifra As Integer = 0 To numeroCifras - 1
            Dim cifra As Char = cifras(indiceCifra)
            Dim esDecimal As Boolean = "0123456789".IndexOf(cifra) >= 0
            If Not esDecimal Then
                Return PREFIJO_ERROR & "Uno de los caracteres no es una cifra decimal"
            End If
        Next
        If numeroCifras > 126 Then
            Return PREFIJO_ERROR & "El número es demasiado grande ya que tiene más de 126 cifras"
        End If

        ' Preparación
        Dim numeroGruposSeisCifras As Integer = numeroCifras \ 6 + Math.Sign(numeroCifras)
        Dim cerosIzquierda As New String("0"c, numeroGruposSeisCifras * 6 - numeroCifras)
        cifras = cerosIzquierda & cifras
        Dim ordenMillon As Integer = numeroGruposSeisCifras - 1

        ' Procesamiento
        Dim resultado As New StringBuilder()
        For indiceGrupo As Integer = 0 To numeroGruposSeisCifras * 6 - 1 Step 6
            Dim seisCifras As Integer = Integer.Parse(cifras.Substring(indiceGrupo, 6))
            If seisCifras <> 0 Then
                If resultado.Length > 0 Then
                    resultado.Append(separadorGruposSeisCifras)
                End If

                If ordenMillon = 0 Then
                    resultado.Append(convertirSeisCifras(seisCifras, elGenero))
                ElseIf seisCifras = 1 Then
                    resultado.Append("un " & listaOrdenesMillonSingular(ordenMillon))
                Else
                    resultado.Append(convertirSeisCifras(seisCifras, Genero.neutro) & " " & listaOrdenesMillonPlural(ordenMillon))
                End If
            End If
            ordenMillon -= 1
        Next

        ' Finalización
        If resultado.Length = 0 Then
            resultado.Append(listaUnidades(0))
        End If
        Return resultado.ToString()
    End Function

    ''' <see cref="convertirCifrasEnLetras(string, Genero, string)"/> 
    Public Shared Function convertirCifrasEnLetras(ByVal cifras As String) As String
        Return convertirCifrasEnLetras(cifras, Genero.neutro, " ")
    End Function
    ''' <see cref="convertirCifrasEnLetras(string, Genero, string)"/> 
    Public Shared Function convertirCifrasEnLetrasMasculinas(ByVal cifras As String) As String
        Return convertirCifrasEnLetras(cifras, Genero.masculino, " ")
    End Function
    ''' <see cref="convertirCifrasEnLetras(string, Genero, string)"/>
    Public Shared Function convertirCifrasEnLetrasFemeninas(ByVal cifras As String) As String
        Return convertirCifrasEnLetras(cifras, Genero.femenino, " ")
    End Function

    ''' Expresa un número con decimales y signo en letras
    ''' acompañado del tipo de medida para la parte entera y la parte decimal.
    ''' <ul>
    ''' <li>Los caracteres no numéricos son ignorados.</li>
    ''' <li>Los múltiplos de millón tienen la preposición <q>de</q> antes de la palabra.</li>
    ''' <li>El género masculino o femenino sólo puede influir en las cifras inferiores al millón</li>
    ''' </ul>
    ''' <dl><dt>Ejemplos:</dt>
    ''' <dd><code>convertirNumeroEnLetras("-123,45",2)</code> &rarr; <samp>"menos ciento veintitrés con cuarenta y cinco"</samp></dd>
    ''' <dd><code>convertirNumeroEnLetras("2.000,25", 3, "kilo","gramo")</code> &rarr; <samp>"dos mil kilos con doscientos cincuenta gramos"</samp></dd>
    ''' <dd><code>convertirNumeroEnLetras("43,005", 3, "kilómetro","metro")</code> &rarr; <samp>"cuarenta y tres kilómetros con cinco metros"</samp></dd>
    ''' <dd><code>convertirNumeroEnLetras("1.270,23", 2, "euro","céntimo")</code> &rarr; <samp>"mil doscientos setenta euros con veintitrés céntimos"</samp></dd>
    ''' <dd><code>convertirNumeroEnLetras("1", 2, "euro","céntimo")</code> &rarr; <samp>"un euro con cero céntimos"</samp></dd>
    ''' <dd><code>convertirNumeroEnLetras("0,678", 2, "euro","céntimo")</code> &rarr; <samp>"cero euros con sesenta y siete céntimos"</samp></dd>
    ''' <dd><code>convertirNumeroEnLetras("22.000,55", 0, "euro","")</code> &rarr; <samp>"veintidós mil euros"</samp></dd>
    ''' <dd><code>convertirNumeroEnLetras("-,889")</code> &rarr; <samp>"menos cero con ochocientos ochenta y nueve"</samp></dd>
    ''' <dd><code>convertirNumeroEnLetras("200",0,"manzana",true)</code> &rarr; <samp>"doscientas manzanas"</samp></dd>
    ''' <dd><code>convertirNumeroEnLetras("1,5",2,"peseta","céntimo",true,false)</code> &rarr; <samp>"una peseta con cincuenta céntimos"</samp></dd>
    ''' <dd><code>convertirNumeroEnLetras("300,56",3,"segundo","milésima",false,true)</code> &rarr; <samp>"trescientos segundos con quinientas sesenta milésimas"</samp></dd>
    ''' <dd><code>convertirNumeroEnLetras("21,21",2,"niño","niña",false,true)</code> &rarr; <samp>"veintiún niños con veintiuna niñas"</samp></dd>
    ''' <dd><code>convertirNumeroEnLetras("1000000",,"euro")</code> &rarr; <samp>"un millón de euros"</samp></dd>
    ''' <dd><code>convertirNumeroEnLetras("200.200.200","persona",true)</code> &rarr; <samp>"doscientos millones doscientas mil doscientas personas"</samp></dd>
    ''' <dd><code>convertirNumeroEnLetras("221.221.221")</code> &rarr; <samp>"doscientos veintiún millones doscientos veintiún mil doscientos veintiuno"</samp></dd>
    ''' </dl>
    ''' @param numeroDecimales Si es -1 el número de decimales es automático
    ''' <see cref="convertirCifrasEnLetras(string, Genero, string)"/>
    ''' <see cref="procesarEnLetras(string, string, string, bool)"/>
    '''
    Public Shared Function convertirNumeroEnLetras( _
     ByVal cifras As String, ByVal numeroDecimales As Integer, _
     ByVal palabraEnteraSingular As String, ByVal palabraEnteraPlural As String, ByVal esFemeninaPalabraEntera As Boolean, _
     ByVal palabraDecimalSingular As String, ByVal palabraDecimalPlural As String, ByVal esFemeninaPalabraDecimal As Boolean _
     ) As String

        ' Limpieza
        cifras = dejarSoloCaracteresDeseados(cifras, "0123456789" & COMA & MENOS)

        ' Comprobaciones
        Dim repeticionesMenos As Integer = numeroRepeticiones(cifras, MENOS)
        Dim repeticionesComa As Integer = numeroRepeticiones(cifras, COMA)
        If repeticionesMenos > 1 OrElse (repeticionesMenos = 1 AndAlso Not cifras.StartsWith(MENOS)) Then
            Return PREFIJO_ERROR & "Símbolo negativo incorrecto o demasiados símbolos negativos"
        ElseIf repeticionesComa > 1 Then
            Return PREFIJO_ERROR & "Demasiadas comas decimales"
        End If

        ' Negatividad
        Dim esNegativo As Boolean = cifras.StartsWith(MENOS)
        If esNegativo Then
            cifras = cifras.Substring(1)
        End If

        ' Preparación
        Dim posicionComa As Integer = cifras.IndexOf(COMA)
        If posicionComa = -1 Then
            posicionComa = cifras.Length
        End If

        Dim cifrasEntera As String = cifras.Substring(0, posicionComa)
        If cifrasEntera.Equals("") OrElse cifrasEntera.Equals(MENOS) Then
            cifrasEntera = "0"
        End If
        Dim cifrasDecimal As String = cifras.Substring(Math.Min(posicionComa + 1, cifras.Length))

        Dim esAutomaticoNumeroDecimales As Boolean = numeroDecimales < 0
        If esAutomaticoNumeroDecimales Then
            numeroDecimales = cifrasDecimal.Length
        Else
            cifrasDecimal = cifrasDecimal.Substring(0, Math.Min(numeroDecimales, cifrasDecimal.Length))
            Dim cerosDerecha As New String("0"c, numeroDecimales - cifrasDecimal.Length)
            cifrasDecimal = cifrasDecimal & cerosDerecha
        End If

        ' Cero
        Dim esCero As Boolean = dejarSoloCaracteresDeseados(cifrasEntera, "123456789").Equals("") AndAlso dejarSoloCaracteresDeseados(cifrasDecimal, "123456789").Equals("")

        ' Procesar        
        Dim resultado As New StringBuilder()

        If esNegativo AndAlso Not esCero Then
            resultado.Append("menos ")
        End If

        Dim parteEntera As String = procesarEnLetras(cifrasEntera, palabraEnteraSingular, palabraEnteraPlural, esFemeninaPalabraEntera)
        If parteEntera.StartsWith(PREFIJO_ERROR) Then
            Return parteEntera
        End If
        resultado.Append(parteEntera)

        If Not cifrasDecimal.Equals("") Then
            Dim parteDecimal As String = procesarEnLetras(cifrasDecimal, palabraDecimalSingular, palabraDecimalPlural, esFemeninaPalabraDecimal)
            If parteDecimal.StartsWith(PREFIJO_ERROR) Then
                Return parteDecimal
            End If
            resultado.Append(" con ")
            resultado.Append(parteDecimal)
        End If

        Return resultado.ToString()
    End Function

    ''' @see #convertirNumeroEnLetras(string, int, string, string, bool, string, string, bool) 
    Public Shared Function convertirNumeroEnLetras(ByVal cifras As String) As String
        Return convertirNumeroEnLetras(cifras, -1, "", "", False, "", "", False)
    End Function
    ''' @see #convertirNumeroEnLetras(string, int, string, string, bool, string, string, bool) 
    Public Shared Function convertirNumeroEnLetras(ByVal cifras As String, ByVal numeroDecimales As Integer) As String
        Return convertirNumeroEnLetras(cifras, numeroDecimales, "", "", False, "", "", False)
    End Function
    ''' @see #convertirNumeroEnLetras(string, int, string, string, bool, string, string, bool) 
    Public Shared Function convertirNumeroEnLetras(ByVal cifras As String, ByVal palabraEntera As String) As String
        Return convertirNumeroEnLetras(cifras, 0, palabraEntera, palabraEntera & "s", False, "", "", False)
    End Function
    ''' @see #convertirNumeroEnLetras(string, int, string, string, bool, string, string, bool) 
    Public Shared Function convertirNumeroEnLetras(ByVal cifras As String, ByVal palabraEntera As String, ByVal esFemeninaPalabraEntera As Boolean) As String
        Return convertirNumeroEnLetras(cifras, 0, palabraEntera, palabraEntera & "s", esFemeninaPalabraEntera, "", "", False)
    End Function
    ''' @see #convertirNumeroEnLetras(string, int, string, string, bool, string, string, bool) 
    Public Shared Function convertirNumeroEnLetras(ByVal cifras As String, ByVal numeroDecimales As Integer, ByVal palabraEntera As String, ByVal palabraDecimal As String) As String
        Return convertirNumeroEnLetras(cifras, numeroDecimales, palabraEntera, palabraEntera & "s", False, palabraDecimal, palabraDecimal & "s", False)
    End Function
    ''' @see #convertirNumeroEnLetras(string, int, string, string, bool, string, string, bool) 
    Public Shared Function convertirNumeroEnLetras(ByVal cifras As String, ByVal numeroDecimales As Integer, ByVal palabraEntera As String, ByVal palabraDecimal As String, ByVal esFemeninaPalabraEntera As Boolean, ByVal esFemeninaPalabraDecimal As Boolean) As String
        Return convertirNumeroEnLetras(cifras, numeroDecimales, palabraEntera, palabraEntera & "s", esFemeninaPalabraEntera, palabraDecimal, palabraDecimal & "s", esFemeninaPalabraDecimal)
    End Function

    ''' Función auxiliar de <code>convertirNumeroEnLetras</code>
    ''' para procesar por separado la parte entera y la parte decimal
    ''' <see cref="convertirCifrasEnLetras(string, bool, string)"/>
    '''
    Private Shared Function procesarEnLetras(ByVal cifras As String, ByVal palabraSingular As String, ByVal palabraPlural As String, ByVal esFemenina As Boolean) As String
        ' Género
        Dim elGenero As Genero = Genero.neutro
        If esFemenina Then
            elGenero = Genero.femenino
        ElseIf palabraSingular.Equals("") Then
            elGenero = Genero.masculino
        End If

        ' Letras
        Dim letras As String = convertirCifrasEnLetras(cifras, elGenero, " ")
        If letras.StartsWith(PREFIJO_ERROR) Then
            Return letras
        End If

        ' Propiedades // 7-ene-2008
        Dim esCero As Boolean = letras.Equals(convertirUnidades(0, elGenero)) OrElse letras.Equals("")
        '---letras.Equals("cero") || letras.Equals("");
        Dim esUno As Boolean = letras.Equals(convertirUnidades(1, elGenero))
        '---letras.Equals("un") || letras.Equals("una") || letras.Equals("uno");
        Dim esMultiploMillon As Boolean = Not esCero AndAlso cifras.EndsWith("000000")

        ' Palabra        
        Dim palabra As String = ""
        If Not palabraSingular.Equals("") Then
            If esUno OrElse palabraPlural.Equals("") Then
                palabra = palabraSingular
            Else
                palabra = palabraPlural
            End If
        End If

        ' Resultado
        Dim resultado As New StringBuilder()
        resultado.Append(letras)
        If Not palabra.Equals("") Then
            If esMultiploMillon Then
                resultado.Append(" de ")
            Else
                resultado.Append(" ")
            End If
            resultado.Append(palabra)
        End If
        Return resultado.ToString()
    End Function

    ''' Convertir euros en letras
    ''' <dl>
    ''' <dt>Ejemplos:</dt>
    ''' <dd><code>convertirEurosEnLetras("44276598801,2",2)</code> &rarr; <samp>"cuatrocientos noventa y ocho mil un euros con veinte céntimos"</samp></dd>
    ''' <dd><code>convertirEurosEnLetras(85009)</code> &rarr; <samp>"ochenta y cinco mil nueve euros"</samp></dd>
    ''' <dd><code>convertirEurosEnLetras(10200.35)</code> &rarr; <samp>"diez mil doscientos euros con treinta y cinco céntimos"</samp></dd>
    ''' </dl>
    ''' <see cref="convertirNumeroEnLetras(string, int, string, string)"/>
    '''
    Public Shared Function convertirEurosEnLetras(ByVal cifras As String, ByVal numeroDecimales As Integer) As String
        Return convertirNumeroEnLetras(cifras, numeroDecimales, "euro", "céntimo")
    End Function
    ''' <see cref="convertirEurosEnLetras(string, int)"/> 
    Public Shared Function convertirEurosEnLetras(ByVal euros As Long) As String
        Dim cifras As String = euros.ToString()
        Return convertirEurosEnLetras(cifras, 0)
    End Function
    ''' <see cref="convertirEurosEnLetras(string, int)"/> 
    Public Shared Function convertirEurosEnLetras(ByVal euros As Double) As String
        Dim cifras As String = euros.ToString().Replace("."c, ","c)
        Return convertirEurosEnLetras(cifras, 2)
    End Function

    '------------------------------------------------------------
    ' FUNCIONES AUXILIARES

    ''' Borra todos los caracteres del texto que no sea alguno de los caracteres deseados.
    ''' <dl>
    ''' <dt>Ejemplos:</dt>
    ''' <dd><code>dejarSoloCaracteresDeseados("89.500.400","0123456789")</code> &rarr; <samp>"89500400"</samp></dd>
    ''' <dd><code>dejarSoloCaracteresDeseados("ABC-000-123-X-456","0123456789")</code> &rarr; <samp>"000123456"</samp></dd>
    ''' </dl>
    ''' 
    Public Shared Function dejarSoloCaracteresDeseados(ByVal texto As String, ByVal caracteresDeseados As String) As String
        Dim indice As Integer = 0
        Dim resultado As New StringBuilder(texto)
        While indice < resultado.Length
            Dim caracter As Char = resultado(indice)
            If caracteresDeseados.IndexOf(caracter) < 0 Then
                resultado.Remove(indice, 1)
            Else
                indice += 1
            End If
        End While
        Return resultado.ToString()
    End Function

    ''' Cuenta el número de repeticiones en el texto de los caracteres indicados
    ''' <dl>
    ''' <dt>Ejemplos:</dt>
    ''' <dd><code>numeroRepeticiones("89.500.400","0")</code> &rarr; <samp>4</samp></dd>
    ''' </dl>
    '''
    Public Shared Function numeroRepeticiones(ByVal texto As String, ByVal caracteres As String) As Integer
        Dim resultado As Integer = 0
        For indice As Integer = 0 To texto.Length - 1
            Dim caracter As Char = texto(indice)
            If caracteres.IndexOf(caracter) >= 0 Then
                resultado += 1
            End If
        Next
        Return resultado
    End Function

    ''' Separa las cifras en grupos de 6 con subrayados y los grupos de 6 en grupos de 2 con punto
    ''' <dl>
    ''' <dt>Ejemplos:</dt>
    ''' <dd><code>formatearCifras("-4739249,2")</code> &rarr; <samp>"-4_739.249,2"</samp></dd>
    ''' </dl>
    '''
    Public Shared Function formatearCifras(ByVal cifras As String) As String
        cifras = dejarSoloCaracteresDeseados(cifras, "0123456789" & COMA & MENOS)
        If cifras.Length = 0 Then
            Return cifras
        End If

        Dim esNegativo As Boolean = cifras.StartsWith(MENOS)
        If esNegativo Then
            cifras = cifras.Substring(1)
        End If

        Dim posicionComa As Integer = cifras.IndexOf(COMA)
        Dim esDecimal As Boolean = posicionComa >= 0

        If Not esDecimal Then
            posicionComa = cifras.Length
        End If
        Dim cifrasEntera As String = cifras.Substring(0, posicionComa)
        Dim cifrasDecimal As String = ""

        If esDecimal Then
            cifrasDecimal = cifras.Substring(Math.Min(posicionComa + 1, cifras.Length))
        End If
        If cifrasEntera.Equals("") Then
            cifrasEntera = "0"
        End If

        Dim resultado As New StringBuilder()
        Dim numeroCifras As Integer = cifrasEntera.Length
        'int numeroGruposTresCifras = numeroCifras / 3 + Integer.signum(numeroCifras);
        Dim par As Boolean = True

        For indice As Integer = 0 To numeroCifras - 1 Step 3
            Dim indiceGrupo As Integer = numeroCifras - indice
            Dim tresCifras As String = cifras.Substring(Math.Max(indiceGrupo - 3, 0), indiceGrupo)
            If indice > 0 Then
                resultado.Insert(0, If(par = True, "."c, "_"c))
                par = Not par
            End If
            resultado.Insert(0, tresCifras)
        Next
        If esNegativo Then
            resultado.Insert(0, MENOS)
        End If
        If esDecimal Then
            resultado.Append(COMA & cifrasDecimal)
        End If

        Return resultado.ToString()
    End Function

End Class ' class CifrasEnLetras

