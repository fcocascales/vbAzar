' Recursos.vb — ProInf.net — feb-2012
'
' Agregar recursos:
' - Menú: Proyecto > Mostrar todos los archivos
' - Explorador de soluciones: MyProject > Resources.resx
' - Agregar recurso > Agregar archivo existente > *.csv

Public Class Recursos

    Public Shared nombres As New VectorNombres(My.Resources.array_nombres)
    Public Shared apellidos As New VectorApellidos(My.Resources.array_apellidos)
    Public Shared municipios As New VectorMunicipios(My.Resources.array_municipios)
    Public Shared provincias As New VectorProvincias(My.Resources.array_provincias)

    Public Shared palabras As New VectorPalabras(My.Resources.array_palabras)
    Public Shared palabrasComunes As New VectorPalabrasComunes(My.Resources.array_comunes)
    Public Shared adjetivos As New VectorAdjetivos(My.Resources.array_adjetivos)

    Public Shared definidosPredeterminados As New VectorDefinidosPredeterminados(My.Resources.array_definidos)

    Public Shared formatosArchivo As New DiccionarioFormatosArchivo()
    Public Shared camposPredefinidos As New DiccionarioPredefinidos()
    Public Shared camposSQL As New DiccionarioCamposSQL()
    Public Shared numerales As New DiccionarioNumerales()

End Class




