Imports System.IO
Imports System.Threading

Public Class monitorArchivos
    Dim watcherOrigen As FileSystemWatcher
    Dim watcherDestino As FileSystemWatcher


    Dim rutaOrigen = "C:\Users\Daniel\Documents\TestMonitor\"
    Dim rutaDestino = "C:\Users\Daniel\Documents\XML"
    'Dim titulos = ""

    Public Sub monitorearOrigen()
        watcherOrigen = New FileSystemWatcher()
        watcherOrigen.Path = rutaOrigen
        watcherOrigen.Filter = "*.xml"
        watcherOrigen.IncludeSubdirectories = False

        watcherOrigen.NotifyFilter = NotifyFilters.FileName

        AddHandler watcherOrigen.Created, AddressOf Cambio

        watcherOrigen.EnableRaisingEvents = True
    End Sub

    Public Sub Cambio(sender As Object, e As FileSystemEventArgs)

        Dim monitorDestino As monitorArchivos = New monitorArchivos
        Dim nombre As String
        nombre = e.Name
        Dim fecha As String
        fecha = Format(DateTime.Now, "dd-MM-yyyy")
        My.Computer.FileSystem.MoveFile(rutaOrigen + nombre, rutaDestino + fecha + "\" + nombre)

        'titulos += nombre + ", "

        'Console.Write(titulos)

        'cargarXml.cargarEmisor(rutaOrigen, nombre)
        'CargarXml.cargarReceptor(rutaOrigen, nombre)
        'CargarXml.cargarConceptos(rutaOrigen, nombre)
        ''cargarXml.cargarTimbreFiscal(rutaOrigen, nombre)
        'CargarXml.cargarNomina(rutaOrigen, nombre)
        'CargarXml.nominaEmisor(rutaOrigen, nombre)
        'CargarXml.nominaReceptor(rutaOrigen, nombre)
        'CargarXml.percepciones(rutaOrigen, nombre)
        'CargarXml.percepcion(rutaOrigen, nombre)
        'CargarXml.deducciones(rutaOrigen, nombre)
        'CargarXml.deduccion(rutaOrigen, nombre)

        monitorDestino.monitorearDestino(fecha)

    End Sub

    Public Sub monitorearDestino(ByVal fecha As String)
        watcherDestino = New FileSystemWatcher()
        watcherDestino.Path = rutaDestino + fecha + "\"
        watcherDestino.Filter = "*.xml"
        watcherDestino.IncludeSubdirectories = False

        watcherDestino.NotifyFilter = NotifyFilters.FileName

        AddHandler watcherDestino.Created, AddressOf Leer

        watcherDestino.EnableRaisingEvents = True
    End Sub

    Public Sub Leer(sender As Object, e As FileSystemEventArgs)
        Dim cargarXml As CargarXml = New CargarXml()
        Dim fecha As String
        fecha = Format(DateTime.Now, "dd-MM-yyyy")
        Dim nombre As String
        nombre = e.Name

        CargarXml.cargarEmisor(rutaDestino, fecha, nombre)
        CargarXml.cargarReceptor(rutaDestino, fecha, nombre)
        CargarXml.cargarConceptos(rutaDestino, fecha, nombre)
        'cargarXml.cargarTimbreFiscal(rutaDestino, fecha, nombre)
        CargarXml.cargarNomina(rutaDestino, fecha, nombre)
        CargarXml.nominaEmisor(rutaDestino, fecha, nombre)
        CargarXml.nominaReceptor(rutaDestino, fecha, nombre)
        CargarXml.percepciones(rutaDestino, fecha, nombre)
        CargarXml.percepcion(rutaDestino, fecha, nombre)
        CargarXml.deducciones(rutaDestino, fecha, nombre)
        CargarXml.deduccion(rutaDestino, fecha, nombre)

    End Sub

End Class