' Apalabrado.vb — ProInf.net — 7-mar-2012

'================================================
' INTERFACE APALABRADO

Public Interface IApalabrado
    Sub Apalabrar(ByVal palabra As String, ByVal esFemenina As Boolean)
End Interface

Public Class Apalabrado
    Implements IApalabrado

    Private _palabraSingular As String
    Private _palabraPlural As String
    Private _femenina As Boolean

    Public Sub Apalabrar(ByVal palabra As String, ByVal esFemenina As Boolean
    ) Implements IApalabrado.Apalabrar
        If palabra.Contains(";") Then
            Dim items = Split(palabra, ";")
            _palabraSingular = items(0)
            _palabraPlural = items(1)
        Else
            _palabraSingular = palabra
            _palabraPlural = EnPlural(palabra)
        End If
        _femenina = esFemenina
    End Sub

    Public Function Obtener(ByVal enSingular As Boolean) As String
        If _palabraSingular = "" Then
            Return ""
        ElseIf enSingular Then
            Return " " & _palabraSingular
        Else
            Return " " & _palabraPlural
        End If
    End Function

    Public Function EsFemenina() As Boolean
        Return _femenina
    End Function

    Protected Shared Function EnPlural(ByVal texto As String) As String
        If texto = "" Then
            Return ""
        ElseIf AcabaEnVocal(texto) Then
            Return texto & "s"
        Else
            Return texto & "es"
        End If
    End Function

    Public Shared Function AcabaEnVocal(ByVal texto As String) As String
        Return "aeiou".Contains(texto(texto.Length - 1))
    End Function

End Class
