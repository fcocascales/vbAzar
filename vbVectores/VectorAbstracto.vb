' VectorAzarAbstracto.vb — ProInf.net — feb-2012
'
' Gestión de los datos estadísticos contenidos en los recursos: "array_*.csv"

Public MustInherit Class VectorAzarAbstracto(Of T As {ValorVector, New})

    Protected _items() As T
    Protected _sumatorio As Integer

    Public Sub New(ByVal recurso As String)
        IniciarArray(recurso)
        CalcularSumatorioFrecuencias()
    End Sub

    Protected Sub IniciarArray(ByVal recurso As String)
        Dim lista() As String = recurso.Split(vbLf)
        _items = New T(lista.Length - 1) {}
        For i = 0 To _items.Length - 1
            _items(i) = New T()
            _items(i).Analizar(lista(i))
        Next
    End Sub

    Protected Overridable Sub CalcularSumatorioFrecuencias()
        _sumatorio = 0
        For Each item In _items
            _sumatorio += item.Frecuencia
        Next
    End Sub

    Default Public Property Items(ByVal index As Integer) As T
        Get
            Return _items(index)
        End Get
        Set(ByVal value As T)
            _items(index) = value
        End Set
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            Return _items.Length
        End Get
    End Property

    Public Overridable Function Aleatorio() As T
        Dim fortuna As Integer = Azar.Entre(0, _items.Count - 1)
        Return Items(fortuna)
    End Function

    Public Overridable Function AleatorioPonderado() As T
        Dim aleatorio As Integer = Azar.Entre(0, _sumatorio)
        Dim frecuencia As Integer = 0
        For i = 0 To Count - 1
            Dim tipo = Items(i)
            frecuencia += tipo.Frecuencia
            If aleatorio < frecuencia Then
                Return tipo
            End If
        Next
        Return Nothing
    End Function

    Public Overridable Function BuscarPorTexto(ByVal texto As String) As T
        For Each item As T In _items
            If item.Texto = texto Then
                Return item
            End If
        Next
        Return Nothing
    End Function

End Class