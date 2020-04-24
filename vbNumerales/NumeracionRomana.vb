' NumeracionRomana.vb — ProInf.net — 26-feb-2012
'
' Convierte un número a numeración romana
' superando la barrera de 3999 mediante los paréntesis
' que multiplican por mil

Public NotInheritable Class NumeracionRomana

    Public Const MINIMO_ROMANO As Integer = 1
    Public Const MAXIMO_ROMANO_SIN_PARENTESIS As Integer = 3999

    ' Los paréntesis multiplican por mil
    '
    ' Ejemplos:
    '   3572 = MMMDLXXII	
    '   3999 = MMMCMXCIX
    '   4000 = M(V)
    '   14285 = (X)M(V)CCLXXXV	
    '   17856 = (XV)MMDCCCLVI	
    '   46424 = (XLV)MCDXXIV	
    '   99989 = (XC)M(X)CMLXXXIX	
    '
    Public Shared Function Obtener(ByVal numero As Integer) As String
        If numero < MINIMO_ROMANO Then Return ""

        Dim resultado As New System.Text.StringBuilder()
        Dim potencia10 As Integer = 0

        Do While numero > 0
            Dim digitoDecimal = numero Mod 10
            numero \= 10
            Dim numeroRomano = ConvertirUnidades(digitoDecimal)

            If potencia10 > 0 Then
                Dim trio() As String = ObtenerTrioRomano(potencia10)
                numeroRomano = ReemplazarCifrasRomanas(numeroRomano, trio)
            End If
            potencia10 += 1

            resultado.Insert(0, numeroRomano)
        Loop
        Return ReducirParentesis(resultado.ToString())
    End Function

    Private Shared Function ObtenerTrioRomano(ByVal potencia10 As Integer) As String()
        'potencia10: 0,1,2,3,4,5,6,7,8,...
        Dim triosRomanos() = {"IVX", "XLC", "CDM", "MVX"}
        Dim indiceTrio = ((potencia10 - 1) Mod 3) + 1 '0, 1,2,3, 1,2,3, 1,2,3, ... 
        Dim numeroParentesis = (potencia10 - 1) \ 3   '0, 0,0,0, 1,1,1, 2,2,2, 3,3,3, ...
        Dim trio = triosRomanos(indiceTrio)
        Dim resultado(2) As String

        resultado(0) = AgregarParentesis(trio(0), numeroParentesis)
        If indiceTrio = 3 Then numeroParentesis += 1
        resultado(1) = AgregarParentesis(trio(1), numeroParentesis)
        resultado(2) = AgregarParentesis(trio(2), numeroParentesis)

        'IVX, XLC, CDM, M(VX), (XLC), (CDM), (M(VX)), ((XLC)), ((CDM)), ((M(VX))), ...
        Return resultado
    End Function

    Private Shared Function ReemplazarCifrasRomanas(
        ByVal numeroRomano As String, ByVal trio() As String
    ) As String
        Return numeroRomano.
            Replace("X", trio(2)).
            Replace("V", trio(1)).
            Replace("I", trio(0))
    End Function

    Public Shared Function ConvertirUnidades(ByVal cifras As Integer) As String
        Dim numerosRomanos = {"I", "II", "III", "IV", "V", "VI", "VII",
                              "VIII", "IX", "X", "XI", "XII", "XIII"}
        If cifras >= 1 And cifras <= 13 Then
            Return numerosRomanos(cifras - 1)
        Else
            Return ""
        End If
    End Function

    Private Shared Function AgregarParentesis(
        ByVal texto As String, ByVal numero As Integer
    ) As String
        If numero >= 1 Then
            Return StrDup(numero, "(") & texto & StrDup(numero, ")")
        Else
            Return texto
        End If
    End Function

    Private Shared Function ReducirParentesis(ByVal texto As String) As String
        Do While texto.Contains(")(")
            texto = texto.Replace(")(", "")
        Loop
        Return texto
    End Function

End Class
