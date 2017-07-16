Module Module1

    Sub Main()
        Dim cargarXml As CargarXml = New CargarXml
        cargarXml.cargarEmisor()
        cargarXml.cargarReceptor()
        cargarXml.cargarConceptos()
        cargarXml.cargarTimbreFiscal()
        cargarXml.cargarNomina()
        cargarXml.nominaEmisor()
        cargarXml.nominaReceptor()
        cargarXml.percepciones()
        cargarXml.percepcion()
        cargarXml.deducciones()
        cargarXml.deduccion()
        Console.ReadKey()

    End Sub


End Module
