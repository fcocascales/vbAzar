' Diccionarios.vb — ProInf.net — feb-2012
'
' Parte fija y compartida de los datos

Public Class DiccionarioFormatosArchivo
    Inherits Dictionary(Of String, FormatoAbstracto)

    Public Sub New()
        Add("Punto y coma CSV", New ArchivoCSV())
        Add("Tabulado TAB", New ArchivoTAB())
        Add("Espaciado PRN", New ArchivoPRN())
        Add("Datos JSON", New ArchivoJSON())
        Add("Datos XML", New ArchivoXML())
        Add("Página web HTML", New ArchivoHTML())
        Add("Hoja cálculo XLS", New ArchivoXLS())
        Add("Base datos SQL", New ArchivoSQL())
    End Sub

End Class

Public Class DiccionarioPredefinidos
    Inherits Dictionary(Of String, CampoPredefinido)

    Public Sub New()
        AgregarCamposPredefinidos()

        EnlazarSexoConNombre(True)
        EnlazarProvinciaConMunicipio(True)
        EnlazarEdadConNacimiento(True)

        NombrarCampos()
    End Sub

    Private Sub AgregarCamposPredefinidos()
        Add("id", New CampoId())
        Add("nombre", New CampoNombre())
        Add("apellido1", New CampoApellido())
        Add("apellido2", New CampoApellido())
        Add("sexo", New CampoSexo())
        Add("nif", New CampoNIF())
        Add("direccion", New CampoDireccion())
        Add("municipio", New CampoMunicipio())
        Add("provincia", New CampoProvincia())
        Add("cp", New CampoCodigoPostal())
        Add("movil", New CampoTelefono())
        Add("telefono", New CampoTelefonoFijo())
        Add("correo", New CampoCorreo())
        Add("nacimiento", New CampoNacimiento())
        Add("edad", New CampoEdad())
        Add("matricula", New CampoMatricula())
    End Sub

    Public Sub EnlazarSexoConNombre(ByVal ok As Boolean)
        Dim sexo As CampoSexo = Me("sexo")
        sexo.CampoNombre = If(ok, Me("nombre"), Nothing)
    End Sub

    Public Sub EnlazarProvinciaConMunicipio(ByVal ok As Boolean)
        Dim provincia As CampoProvincia = Me("provincia")
        provincia.CampoMunicipio = If(ok, Me("municipio"), Nothing)
    End Sub

    Public Sub EnlazarEdadConNacimiento(ByVal ok As Boolean)
        Dim edad As CampoEdad = Me("edad")
        edad.CampoNacimiento = If(ok, Me("nacimiento"), Nothing)
    End Sub

    Public Sub EnlazarCodigoPostalConProvincia(ByVal ok As Boolean)
        Dim cp As CampoCodigoPostal = Me("cp")
        cp.CampoProvincia = If(ok, Me("provincia"), Nothing)
    End Sub

    Public Sub EnlazarTelefonoFijoConProvincia(ByVal ok As Boolean)
        Dim fijo As CampoTelefonoFijo = Me("telefono")
        fijo.CampoProvincia = If(ok, Me("provincia"), Nothing)
    End Sub

    Public Sub EnlazarCorreoConNombre(ByVal ok As Boolean)
        Dim correo As CampoCorreo = Me("correo")
        correo.CampoNombre = If(ok, Me("nombre"), Nothing)
    End Sub

    Public Sub EnlazarCorreoConApellido(ByVal ok As Boolean)
        Dim correo As CampoCorreo = Me("correo")
        correo.CampoApellido = If(ok, Me("apellido1"), Nothing)
    End Sub

    Private Sub NombrarCampos()
        Dim enumerador As IDictionaryEnumerator = Me.GetEnumerator()
        Do While enumerador.MoveNext()
            Dim campo As CampoPredefinido = enumerador.Value
            campo.Nombre = Utilidades.Capitalizar(enumerador.Key)
        Loop
    End Sub

End Class

Public Class DiccionarioCamposSQL
    Inherits Dictionary(Of String, String)

    Public Sub New()
        AgregarCamposPredefinidos()
        AgregarTiposCampo()
    End Sub

    Private Sub AgregarCamposPredefinidos()
        Add("id", "INTEGER AUTO_INCREMENT PRIMARY KEY")
        Add("nombre", "VARCHAR(25) NOT NULL")
        Add("apellido1", "VARCHAR(25)")
        Add("apellido2", "VARCHAR(25)")
        Add("sexo", "ENUM ('H','M')")
        Add("nif", "CHAR(9)")
        Add("direccion", "VARCHAR(100)")
        Add("municipio", "VARCHAR(25)")
        Add("provincia", "VARCHAR(25)")
        Add("cp", "CHAR(5)")
        Add("movil", "VARCHAR(50)")
        Add("telefono", "VARCHAR(50)")
        Add("correo", "VARCHAR(50)")
        Add("nacimiento", "DATE")
        Add("edad", "INTEGER")
        Add("matricula", "CHAR(8)")
    End Sub

    Private Sub AgregarTiposCampo()
        Add("texto", "VARCHAR(50)")
        Add("entero", "INTEGER")
        Add("numero", "NUMERIC(10,2)")
        Add("logico", "BOOLEAN")
        Add("fecha", "DATE")
        Add("hora", "TIME")
    End Sub

    Function ObtenerTipo(ByVal campo As ICampo) As String
        Try
            Return Me(campo.Nombre.ToLower())
        Catch ex As KeyNotFoundException
            Try
                Return Me(campo.Tipo.ToString().ToLower())
            Catch ex2 As KeyNotFoundException
                Return ""
            End Try
        End Try
    End Function

End Class

Public Class DiccionarioNumerales
    Inherits Dictionary(Of Numerales, INumeral)

    Public Sub New()
        Add(Numerales.Alfabético, New NumeralAlfabetico())
        Add(Numerales.Alfabético_Español, New NumeralAlfabeticoEspañol(enPlural:=False))
        Add(Numerales.Alfabético_Griego, New NumeralGriego())
        Add(Numerales.Alfabético_Musical, New NumeralMusical())
        Add(Numerales.Alfabético_Radiofónico, New NumeralRadiofonico())
        Add(Numerales.Cardinal_Alfaromano, New NumeralAlfaromano())
        Add(Numerales.Cardinal_Español, New NumeralEspañol())
        Add(Numerales.Cardinal_Esperanto, New NumeralEsperanto())
        Add(Numerales.Cardinal_Interlingua, New NumeralInterlingua())
        Add(Numerales.Cardinal_Klingon, New NumeralKlingon())
        Add(Numerales.Cardinal_Japonés, New NumeralJapones())
        Add(Numerales.Cardinal_Latín, New NumeralLatin())
        Add(Numerales.Cardinal_Lojban, New NumeralLojban())
        Add(Numerales.Cardinal_Sona, New NumeralSona())
        Add(Numerales.Medición_Internacional, New NumeralInternacional(enLetras:=True))
        Add(Numerales.Medición_Temporal, New NumeralTemporal(enLetras:=True))
        Add(Numerales.Numeración_Arábiga, New NumeralArabigo())
        Add(Numerales.Numeración_Hexadecimal, New NumeralHexadecimal())
        Add(Numerales.Numeración_Romana, New NumeralRomano())
        Add(Numerales.Ordinal_Español, New NumeralOrdinalEspañol())
    End Sub

    Public Function EsNumerico(ByVal alfabeto As Numerales) As Boolean
        Return alfabeto = Numerales.Numeración_Arábiga
    End Function

End Class