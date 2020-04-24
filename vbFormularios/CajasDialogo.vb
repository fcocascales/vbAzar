' CajasDialogo.vb — ProInf.net — feb-2012

Module CajasDialogo

    Public Function DialogoConfirmar(Optional ByVal mensaje As String = "") As Boolean
        If mensaje = "" Then mensaje = "¿Estás seguro?"
        Return MessageBox.Show(
            mensaje,
            "Confirmación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2) = DialogResult.Yes
    End Function

    Public Sub DialogoAviso(ByVal mensaje As String)
        MessageBox.Show(
            mensaje,
            "Aviso",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation)
    End Sub

    Public Sub DialogoError(
        Optional ByVal excepcion As Exception = Nothing,
        Optional ByVal mensaje As String = ""
    )
        Dim titulo = "Error"
        If excepcion IsNot Nothing Then
            titulo &= ": " & excepcion.GetType().Name
            If mensaje.Length > 0 Then mensaje &= vbCrLf & vbCrLf
            mensaje &= excepcion.Message & vbCrLf & vbCrLf & excepcion.StackTrace
        End If
        MessageBox.Show(
            mensaje,
            titulo,
            MessageBoxButtons.OK,
            MessageBoxIcon.Stop)
    End Sub

End Module
