Imports System.IO
Imports System.Threading
Imports System.Net.Mail

Public Class MonitorFile
    Dim watcher As FileSystemWatcher
    Dim ruta As ArrayList

    Public Sub monitorear()
        watcher = New FileSystemWatcher()
        watcher.Path = "C:\Users\Daniel\Documents\TestMonitor"
        watcher.Filter = "*.xml"
        watcher.IncludeSubdirectories = False

        watcher.NotifyFilter = NotifyFilters.FileName
        'Or NotifyFilters.CreationTime Or NotifyFilters.LastAccess Or NotifyFilters.LastWrite Or NotifyFilters.FileName Or NotifyFilters.DirectoryName

        AddHandler watcher.Created, AddressOf Cambio
        'AddHandler watcher.Changed, AddressOf Cambio
        'AddHandler watcher.Deleted, AddressOf Cambio
        'AddHandler watcher.Renamed, AddressOf Renombre

        watcher.EnableRaisingEvents = True

        'CheckForIllegalCrossThreadCalls = False

        'Console.WriteLine.Items.Clear()
        ruta = New ArrayList
    End Sub

    'Private Sub Renombre(sender As Object, e As RenamedEventArgs)
    '    Console.Write.Items.Add(Now.ToLongTimeString & " - " & e.FullPath & " - " & e.ChangeType.ToString)
    '    ruta.Add(e.FullPath)
    'End Sub

    Public Sub Cambio(sender As Object, e As FileSystemEventArgs)
        Dim fecha As String
        fecha = Format(DateTime.Now, "dd-MM-yyyy")
        Dim nombre As String
        nombre = e.Name
        'listRutas.Items.Add(Now.ToLongTimeString & " - " & e.FullPath & " - " & e.ChangeType.ToString)
        ruta.Add(e.FullPath)
        My.Computer.FileSystem.MoveFile("C:\Users\Daniel\Documents\TestMonitor\" + nombre, "C:\Users\Daniel\Documents\XML'" + fecha + "'\" + nombre)
    End Sub

End Class
