' NumeracionAlfaromana.vb — ProInf.net — 26-feb-2012
'
' Numeración inventada por mi.
'
' Pronunciación vocálico-lógica de los números  inspirado en la numeración romana 
'
' Características:
'  * Es sencillo de recordar y fácil de contar.
'  * Los impares llevan una i en la primera o segunda letra.
'  * Se pueden escribir números colosales como yuñi (10^10^10)
'  * Las combinaciones de vocales son los números del 0 al 9
'  * Las potencias de 10 son las consonantes: b=10, z=100, d=1000, etc.
'  * Se escribe de menos a más significativo (que no es lo habitual)
'  * El cero es u y los decimales empiezan por u
'  * Se puede traducir una palabra en un número
' 
'  0  u      10  bi       20  ba       30  bai       40  be   
'  1  i      11  ibi      21  iba      31  ibai      41  ibe
'  2  a      12  abi      22  aba      32  abai      42  abe
'  3  ai     13  aibi     23  aiba     33  aibai     43  aibe
'  4  e      14  ebi      24  eba      34  ebai      44  ebe
'  5  ei     15  eibi     25  eiba     35  eibai     45  eibe
'  6  ea     16  eabi     26  eaba     36  eabai     46  eabe
'  7  io     17  iobi     27  ioba     37  iobai     47  iobe
'  8  o      18  obi      28  oba      38  obai      48  obe
'  9  oi     19  oibi     29  oiba     39  oibai     49  oibe
' 
'  10  bi      100  zi      1000  di      
'  20  ba      200  za      2000  da       
'  30  bai     300  zai     3000  dai    
'  40  be      400  ze      4000  de      
'  50  bei     500  zei     5000  dei    
'  60  bea     600  zea     6000  dea     
'  70  bio     700  zio     7000  dio      
'  80  bo      800  zo      8000  do      
'  90  boi     900  zoi     9000  doi     
'
'  0.1  u-i      0.01  u-u-i      0.11  u-ibi
'  0.2  u-a      0.02  u-u-a      0.12  u-abi
'  0.3  u-ai     0.03  u-u-ai     0.13  u-aibi
'  0.4  u-e      0.04  u-u-e      0.14  u-ebi
'  0.5  u-ei     0.05  u-u-ei     0.15  u-eibi
'  0.6  u-ea     0.06  u-u-ea     0.16  u-eabi
'  0.7  u-io     0.07  u-u-io     0.17  u-iobi
'  0.8  u-o      0.08  u-u-o      0.18  u-obi
'  0.9  u-oi     0.09  u-u-oi     0.19  u-oibi
'
'        10  bi           10.000.000  li    10^13  si
'       100  zi          100.000.000  mi    10^14  ti
'     1.000  di        1.000.000.000  ni    10^15  wi
'    10.000  fi       10.000.000.000  ñi    10^16  xi
'   100.000  ji      100.000.000.000  pi    10^17  yiobi  
' 1.000.000  ki    1.000.000.000.000  ri    10^18  yobi  
'
' 10^1  yi      10^7  yio     10^13  yaibi     10^19  yoibi    10^10^15 yuwi
' 10^2  ya      10^8  yo      10^14  yebi      10^20  yuba     10^10^16 yuxi 
' 10^3  yai     10^9  yoi     10^15  yeibi     10^21  yiba     10^10^17 yu-yiobi
' 10^4  ye     10^10  yubi    10^16  yeabi     10^22  yaba     10^10^18 yu-yobi
' 10^5  yei    10^11  yibi    10^17  yiobi     10^23  yaiba    10^10^10^17 yu-yu-yiobi 
' 10^6  yea    10^12  yabi    10^18  yobi      10^24  yeba     10^10^10^18 yu-yu-yobi  
'
' 10^-1  yui
' 10^-2  yua
' 10^-3  yuai
' 10^-4  yue
' 10^-5  yuei
' 10^-6  yuea
'
' 4321  i-ba-zai-de    eyai-aiya-ayi-i
' 5432  a-bai-ze-dei   eiyai-eya-aiyi-a
' 6543  ai-be-zei-dea  eayai-eiya-eyi-ai
' 7654  e-bei-zea-dio  ioyai-eaya-eiyi-e
' 8765  ei-bea-zio-do  oyai-ioya-eayi-ei
' 9876  ea-bio-zo-doi  oiyai-oya-ioyi-ea
'  987  io-bo-zoi      oiye-oye-io
' 1098  o-boi-di       yai-oiyi-o
' 2109  oi-zi-da       ayai-ya-oi
'
' federico > federiko > de-fe-ko-ri > 1.000.008.044.000
' adela > a-de-la > 20.004.002
' antonio > atonio > a-nio-to > 800.007.000.000.002
' ignacio > inazio > i-zio-na > 2.000.000.701
' abecedario > a-be-ze-da-rio > 7.000.000.002.442

Public Class NumeracionAlfaromana

    Private Shared unidades() = {
        "u", "i", "a", "ai", "e", "ei", "ea", "io", "o", "oi"}
    '----0----1----2----3-----4----5-----6-----7-----8----9----

    Private Shared potencias As String = "ubzdfjklmnñprstwxy"
    '--------------------------------------vc--gc-----------

#If False Then
    'Ej: 32768.14590 --> "o-bea-zio-da-fai-u-bio-cei-de-fi"
    Public Shared Function ObtenerPronunciacion(
        ByVal numero As Decimal,
        Optional ByVal separacion As String = ""
    ) As String
        Dim texto As String = numero.ToString().Replace(",", ".").Replace("-", "")
        Dim items As String() = Split(texto, ".")
        Dim parteEntera As Integer = items(0)
        Dim parteDecimal As Integer = If(items.Length >= 2, items(0), 0)
        Dim resultado As New System.Text.StringBuilder()
        Dim espacio As String = If(separacion = "", " ", separacion)

        If numero < 0 Then
            resultado.Append("menos")
            resultado.Append(espacio)
        End If
        resultado.Append(ObtenerPronunciacion(parteEntera, separacion))
        If parteDecimal Then
            resultado.Append(espacio)
            resultado.Append("u")
            resultado.Append(separacion)
            resultado.Append(ObtenerPronunciacion(parteDecimal, separacion))
        End If

        Return resultado.ToString()
    End Function
#End If

    'Ej: 32768 --> "o-bea-zio-da-fai"
    'Ej: 14590 --> "bio-zei-de-fi"
    Public Shared Function Obtener(
        ByVal numero As Integer,
        Optional ByVal separacion As String = ""
    ) As String
        If numero = 0 Then Return unidades(0)

        Dim resultado As New System.Text.StringBuilder()
        Dim potencia As Integer = 0

        Do While numero > 0
            Dim digitoDecimal = numero Mod 10

            If digitoDecimal > 0 Then
                Dim pronunciacion =
                    ObtenerPotencia(potencia) & ObtenerUnidad(digitoDecimal)

                If resultado.Length > 0 Then resultado.Append(separacion)
                resultado.Append(pronunciacion)
            End If

            numero \= 10
            potencia += 1
        Loop
        Return resultado.ToString()
    End Function

    Private Shared Function ObtenerUnidad(ByVal digito As Integer) As String
        If digito >= 1 And digito <= 9 Then
            Return unidades(digito)
        Else
            Return ""
        End If
    End Function

    Private Shared Function ObtenerPotencia(ByVal potencia As Integer) As String
        If potencia = 0 Then
            Return ""
        ElseIf potencia >= 1 And potencia < potencias.Length Then
            Return potencias(potencia) 'Return Char.ToUpper(_potencias(potencia))
        Else
            Return "?"
        End If
    End Function

#If False Then
    'Ej: "o-bea-zio-da-fai" --> 32768
    'Ej: "bio-zei-de-fi" --> 14590
    Public Shared Function ObtenerNumero(ByVal pronunciacion As String) As Integer
        'TODO: Obtener número desde pronunciación alfaromana
        Dim numero As Integer = 0
        Dim items() = ObtenerItems(pronunciacion.ToLower())
        For i = items.Length - 1 To 0 Step -1
            Dim item = items(i)
            If "aeiou".Contains(item(0)) Then
                Dim digito = Array.IndexOf(_unidades, item)
                If digito > 0 Then numero += digito
            Else
                Dim potencia = _potencias.IndexOf(item(0))
                If potencia > 0 Then numero *= 10 ^ potencia
            End If
        Next
        Return numero
    End Function

    'TODO: Probar esta función
    Private Shared Function ObtenerItems(ByVal pronunciacion As String) As String()
        If pronunciacion.Contains("-") Then Return Split(pronunciacion, "-")
        Dim lista As New List(Of String)
        Dim inicio As Integer = 0
        Dim item As String
        For i = 0 To pronunciacion.Length - 1
            Dim caracter As Char = pronunciacion(i)
            If Not "aeiou".Contains(caracter) Then
                lista.Add(pronunciacion.Substring(inicio, i))
                lista.Add(pronunciacion(i))
                inicio = i + 1
            End If
        Next
        item = pronunciacion.Substring(inicio)
        lista.Add(item)
        Return lista.ToArray()
    End Function
#End If
End Class
