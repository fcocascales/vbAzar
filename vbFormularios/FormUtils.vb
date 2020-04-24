Class FormUtils

    Public Shared Sub ChequearCajaLista(
        ByVal cajaLista As CheckedListBox,
        Optional ByVal marcar As Boolean = True
    )
        For i = 0 To cajaLista.Items.Count - 1
            cajaLista.SetItemChecked(i, marcar)
        Next
    End Sub

    Public Shared Sub ChequearCajaLista(
        ByVal cajaLista As CheckedListBox,
        ByVal indices As IEnumerable
    )
        ChequearCajaLista(cajaLista, False)
        For Each indice As Integer In indices
            If indice >= 0 And indice < cajaLista.Items.Count Then
                cajaLista.SetItemChecked(indice, True)
            End If
        Next
    End Sub

    Public Shared Function ObtenerIndicesChequeados(
        ByVal cajaLista As CheckedListBox
    ) As Integer()
        Dim lista As New List(Of Integer)
        For Each indice As Integer In cajaLista.CheckedIndices
            lista.Add(indice)
        Next
        Return lista.ToArray()
    End Function

    Public Shared Sub MoverArribaSeleccionado(ByVal cajaLista As ListBox)
        If cajaLista.SelectedItems.Count = 1 Then
            Dim indice As Integer = cajaLista.SelectedIndex
            If indice > 0 Then
                Dim elemento As Object = cajaLista.SelectedItem
                cajaLista.Items.Remove(elemento)
                indice -= 1
                cajaLista.Items.Insert(indice, elemento)
                cajaLista.SelectedIndex = indice
            End If
        End If
    End Sub

    Public Shared Sub MoverAbajoSeleccionado(ByVal cajaLista As ListBox)
        If cajaLista.SelectedItems.Count = 1 Then
            Dim indice As Integer = cajaLista.SelectedIndex
            If indice < cajaLista.Items.Count - 1 Then
                Dim elemento As Object = cajaLista.SelectedItem
                cajaLista.Items.RemoveAt(indice)
                indice += 1
                cajaLista.Items.Insert(indice, elemento)
                cajaLista.SelectedIndex = indice
            End If
        End If
    End Sub

End Class
