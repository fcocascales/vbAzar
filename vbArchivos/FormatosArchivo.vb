' FormatosArchivo.vb — ProInf.net — feb-2012
'
' Formatos de exportación de archivos: CSV, XML, HTML, etc.

Public Class ArchivoCSV 'Comma Separated Variable
    Inherits FormatoAbstracto

    'Importación:
    ' en LibreOffice 3.4 Calc >>> BIEN, mediante asistente automático
    ' en Microsoft Excel 2007 >>> ERROR, codificación incorrecta como ANSI (ISO-8859-1)

    Public Overrides Sub EscribirTitulos(ByVal titulos As String())
        EscribirLinea(Join(titulos, ";"))
    End Sub

    Public Overrides Sub EscribirValores(ByVal valores As String())
        EscribirLinea(Join(valores, ";"))
    End Sub

End Class

Public Class ArchivoTAB 'Tabuladores
    Inherits FormatoAbstracto

    'Importación:
    ' en LibreOffice 3.4 Calc >>> BIEN, haciendo en el archivo "Abrir con"
    ' en Microsoft Excel 2007 >>> BIEN, mediante asistente automático

    Public Overrides Sub EscribirTitulos(ByVal titulos As String())
        EscribirLinea(Join(titulos, vbTab))
    End Sub

    Public Overrides Sub EscribirValores(ByVal valores As String())
        EscribirLinea(Join(valores, vbTab))
    End Sub

End Class

Public Class ArchivoJSON 'JavaScript Object Notation
    Inherits FormatoAbstracto

    'Importación:
    ' para lenguajes JavaScript y otros
    'http://www.json.org/json-es.html

    Private _titulos As String()
    Private _campos As ICampo()

    Protected Overrides Sub InicioDocumento()
        EscribirLinea(String.Format("var {0} = [", ObtenerNombreTabla))
    End Sub

    Protected Overrides Sub FinDocumento()
        EscribirLinea("];")
    End Sub

    Public Overrides Sub EscribirMetadatos(ByVal campos() As ICampo)
        _campos = campos
    End Sub

    Public Overrides Sub EscribirTitulos(ByVal titulos As String())
        _titulos = titulos
    End Sub

    Public Overrides Sub EscribirValores(ByVal valores As String())
        Escribir("{")
        For i = 0 To valores.Length - 1
            Dim titulo = Entrecomillar(_titulos(i))
            Dim valor = valores(i)
            If RequiereComillas(_campos(i)) Then
                valor = Entrecomillar(CodificarEscape(valor))
            End If
            Escribir(String.Format("{0}: {1}", titulo, valor))
            If i < valores.Length - 1 Then Escribir(", ")
        Next
        EscribirLinea("},")
    End Sub

    '--------------------------------------------
    ' AUXILIAR

    Shared Function Entrecomillar(ByVal texto As String) As String
        Return """" & texto & """"
    End Function

    Shared Function CodificarEscape(ByVal texto As String) As String
        Return texto.Replace("\", "\\").Replace("""", "\""")
    End Function

    Shared Function RequiereComillas(ByVal campo As ICampo) As Boolean
        Return campo.Tipo = TipoCampo.Texto Or
            campo.Tipo = TipoCampo.Fecha Or
            campo.Tipo = TipoCampo.Hora
    End Function

End Class

Public Class ArchivoXML 'Extensible Markup Language
    Inherits FormatoAbstracto

    'Importación:
    ' en LibreOffice 3.4 Calc >>> ERROR, de entrada y salida
    ' en Microsoft Excel 2007 >>> BIEN, lo convierte en tabla

    Private _titulos As String()

    Protected Overrides Sub InicioDocumento()
        EscribirLinea("<?xml version=""1.0""?>")
        EscribirLinea(String.Format("<{0}>", ObtenerNombreTabla()))
    End Sub

    Protected Overrides Sub FinDocumento()
        EscribirLinea(String.Format("</{0}>", ObtenerNombreTabla()))
    End Sub

    Public Overrides Sub EscribirTitulos(ByVal titulos As String())
        _titulos = titulos
    End Sub

    Public Overrides Sub EscribirValores(ByVal valores As String())
        Escribir("<fila>")
        For i = 0 To valores.Length - 1
            Dim valor = Utilidades.CodificarHTML(valores(i))
            Escribir(String.Format("<{1}>{0}</{1}>", valor, _titulos(i)))
        Next
        EscribirLinea("</fila>")
    End Sub
End Class

Public Class ArchivoHTML 'Página web
    Inherits FormatoAbstracto

    'Importación:
    ' en LibreOffice 3.4 Calc >>> BIEN, haciendo en el archivo "Abrir con"
    ' en Microsoft Excel 2007 >>> BIEN, formatea los títulos

    Protected Overrides Sub InicioDocumento()
        'Dim titulo = System.IO.Path.GetFileNameWithoutExtension(Ruta)
        EscribirLinea("<html>")
        EscribirLinea("<head>")
        EscribirLinea("<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />")
        EscribirLinea(String.Format("<title>{0}</title>", ObtenerNombreTabla()))
        EscribirLinea("</head>")
        EscribirLinea("<body>")
        EscribirLinea(Space(1) & "<table border=1>")
    End Sub

    Protected Overrides Sub FinDocumento()
        EscribirLinea(Space(2) & "</tbody>")
        EscribirLinea(Space(1) & "</table>")
        EscribirLinea("</body>")
        EscribirLinea("</html>")
    End Sub

    Public Overrides Sub EscribirTitulos(ByVal titulos As String())
        EscribirLinea(Space(2) & "<thead>")
        Escribir(Space(3) & "<tr>")
        For Each titulo In titulos
            Escribir(String.Format("<th>{0}</th>", Utilidades.CodificarHTML(titulo)))
        Next
        EscribirLinea("</tr>")
        EscribirLinea(Space(2) & "</thead>")
        EscribirLinea(Space(2) & "<tbody>")
    End Sub

    Public Overrides Sub EscribirValores(ByVal valores As String())
        Escribir(Space(3) & "<tr>")
        For Each valor In valores
            Escribir(String.Format("<td>{0}</td>", Utilidades.CodificarHTML(valor)))
        Next
        EscribirLinea("</tr>")
    End Sub

End Class

Public Class ArchivoSQL 'Base de datos
    Inherits FormatoAbstracto

    'Importación:
    ' en MySQL >>> BIEN

    Private _campos As ICampo()
    Private _tabla As String

    '--------------------------------------------
    ' INTERFAZ

    Public Overrides Sub EscribirMetadatos(ByVal campos As ICampo())
        _campos = campos
        _tabla = ObtenerNombreTabla()
        EscribirLinea(String.Format("CREATE TABLE {0} (", _tabla))
        For i = 0 To campos.Length - 1
            Dim nombre = Utilidades.SimplificarNombre(campos(i).Nombre)
            Dim tipo = Recursos.camposSQL.ObtenerTipo(campos(i))
            Escribir(String.Format("  {0} {1}", nombre, tipo))
            If i < campos.Length - 1 Then Escribir(",")
            EscribirLinea()
        Next
        EscribirLinea(");")
        EscribirLinea()
    End Sub

    Public Overrides Sub EscribirValores(ByVal valores As String())
        Escribir(String.Format("INSERT INTO {0} VALUES (", _tabla))
        For i = 0 To valores.Length - 1
            If i > 0 Then Escribir(", ")
            If RequiereComillas(_campos(i)) Then
                Escribir(Entrecomillar(DuplicarComillas(valores(i))))
            Else
                Escribir(valores(i))
            End If
        Next
        EscribirLinea(");")
    End Sub

    '--------------------------------------------
    ' AUXILIAR

    Shared Function Entrecomillar(ByVal texto As String) As String
        Return "'" & texto & "'"
    End Function

    Shared Function DuplicarComillas(ByVal texto As String) As String
        Return texto.Replace("'", "''")
    End Function

    Shared Function RequiereComillas(ByVal campo As ICampo) As Boolean
        Return campo.Tipo = TipoCampo.Texto Or
            campo.Tipo = TipoCampo.Fecha Or
            campo.Tipo = TipoCampo.Hora
    End Function

End Class

Public Class ArchivoXLS 'Hoja de cálculo MS-Excel
    Inherits FormatoAbstracto

    'Importación:
    ' en LibreOffice 3.4 Calc >>> BIEN, aunque toma la fecha como texto
    ' en Microsoft Excel 2007 >>> BIEN

    Const CODIFICACION = "UTF-8" 'Codificaciones posibles: "ISO-8859-1", "UTF-8"

    Private _campos As ICampo()

    '--------------------------------------------
    ' INTERFAZ

    Protected Overrides Sub InicioDocumento()
        EscribirLinea(String.Format("<?xml version=""1.0"" encoding=""{0}""?>", CODIFICACION))
        EscribirLinea("<Workbook ")
        EscribirLinea("  xmlns=""urn:schemas-microsoft-com:office:spreadsheet"" ")
        EscribirLinea("  xmlns:x=""urn:schemas-microsoft-com:office:excel"" ")
        EscribirLinea("  xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"" ")
        EscribirLinea("  xmlns:html=""http://www.w3.org/TR/REC-html40"">")
        EscribirLinea("<Styles>")
        EscribirLinea("  <Style ss:ID=""Default"" ss:Name=""Normal"">")
        EscribirLinea("    <Alignment ss:Vertical=""Top"" ss:WrapText=""1"" />")
        EscribirLinea("  </Style>")
        EscribirLinea("</Styles>")
        EscribirLinea(String.Format("<Worksheet ss:Name=""{0}"">", ObtenerNombreTabla()))
        EscribirLinea("<Table>")
    End Sub

    Protected Overrides Sub FinDocumento()
        EscribirLinea("</Table>")
        EscribirLinea("</Worksheet>")
        EscribirLinea("</Workbook>")
    End Sub

    Public Overrides Sub EscribirMetadatos(ByVal campos As ICampo())
        _campos = campos
    End Sub

    Public Overrides Sub EscribirTitulos(ByVal titulos As String())
        EscribirLinea("<Row>")
        For Each titulo In titulos
            EscribirLinea(String.Format("<Cell><Data ss:Type=""String"">{0}</Data></Cell>", titulo))
        Next
        EscribirLinea("</Row>")
    End Sub

    Public Overrides Sub EscribirValores(ByVal valores As String())
        EscribirLinea("<Row>")
        For i = 0 To valores.Length - 1
            Dim tipo = _campos(i).Tipo
            Dim valor = Utilidades.CodificarHTML(Normalizar(valores(i), tipo))
            EscribirLinea(String.Format("<Cell><Data ss:Type=""{1}"">{0}</Data></Cell>", valor, ObtenerTipoCelda(tipo)))
        Next
        EscribirLinea("</Row>")
    End Sub

    '--------------------------------------------
    ' AUXILIAR

    Shared Function Normalizar(ByVal valor As String, ByVal tipo As TipoCampo) As String
        Select Case tipo
            Case TipoCampo.Fecha : Return NormalizarFecha(valor)
            Case Else : Return valor
        End Select
    End Function

    Shared Function NormalizarFecha(ByVal fechaSQL As String) As String
        Dim fecha = Date.Parse(fechaSQL)
        Return String.Format("{0}/{1}/{2}", fecha.Day, fecha.Month, fecha.Year)
    End Function

    Shared Function ObtenerTipoCelda(ByVal tipo As TipoCampo) As String
        If tipo = TipoCampo.Texto Or
            tipo = TipoCampo.Fecha Or
            tipo = TipoCampo.Hora Then
            Return "String"
        Else
            Return "Number"
        End If
    End Function

End Class

Public Class ArchivoPRN 'Alineado con espacios en blanco para imprimir
    Inherits FormatoAbstracto

    'Importación:
    ' en LibreOffice 3.4 Calc >  BIEN, haciendo en el archivo "Abrir con"
    ' en Microsoft Excel 2007 >  BIEN, mediante asistente

    Private _campos As ICampo()
    Private Shared _diccio As New DiccionarioTiposCampos()

    Public Overrides Sub EscribirMetadatos(ByVal campos As ICampo())
        _campos = campos
    End Sub

    Public Overrides Sub EscribirTitulos(ByVal titulos As String())
        EscribirDatos(titulos)
    End Sub

    Public Overrides Sub EscribirValores(ByVal valores As String())
        EscribirDatos(valores)
    End Sub

    '--------------------------------------------
    ' AUXILIAR

    Private Sub EscribirDatos(ByVal textos As String())
        For i = 0 To textos.Length - 1
            Dim texto = _diccio.Recortar(textos(i), _campos(i))
            Escribir(texto)
        Next
        EscribirLinea()
    End Sub

    Private Class DiccionarioTiposCampos
        Inherits Dictionary(Of TipoCampo, Estructura)
        Sub New()
            Add(TipoCampo.Texto, New Estructura(25, Alineacion.Izquierda))
            Add(TipoCampo.Entero, New Estructura(10, Alineacion.Derecha))
            Add(TipoCampo.Numero, New Estructura(15, Alineacion.Derecha))
            Add(TipoCampo.Logico, New Estructura(5, Alineacion.Izquierda))
            Add(TipoCampo.Fecha, New Estructura(10, Alineacion.Izquierda))
            Add(TipoCampo.Hora, New Estructura(8, Alineacion.Izquierda))
        End Sub
        Function Recortar(ByVal texto As String, ByVal campo As ICampo) As String
            Dim tipo = Me(campo.Tipo)
            Dim salida As String = ""
            Dim espacios = Math.Max(0, tipo.Largo - texto.Length)
            Select Case tipo.Alineacion
                Case Alineacion.Izquierda : salida = texto & Space(espacios)
                Case Alineacion.Derecha : salida = Space(espacios) & texto
            End Select
            Return salida.Substring(0, tipo.Largo)
        End Function
    End Class

    Private Structure Estructura
        Dim Largo As String
        Dim Alineacion As Alineacion
        Sub New(ByVal largo As Integer, ByVal alineacion As Alineacion)
            Me.Largo = largo
            Me.Alineacion = alineacion
        End Sub
    End Structure

    Private Enum Alineacion
        Izquierda
        Derecha
    End Enum

End Class
