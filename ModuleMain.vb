Module ModuleMain

    Sub Main()
        Dim monitor As monitorArchivos = New monitorArchivos()
        monitor.monitorearOrigen()

        Console.ReadKey()
    End Sub

End Module
