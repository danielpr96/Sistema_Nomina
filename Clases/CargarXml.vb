Imports System.Xml
Imports System.IO
Public Class CargarXml

    Public Sub cargarComprobante()
        Dim document As XmlDocument = New XmlDocument
        document.Load("")
        Dim root As XmlNode = document.DocumentElement
        Dim xmlManager = New XmlNamespaceManager(document.NameTable)
        xmlManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
    End Sub

    Public Sub cargarEmisor()
        Dim nombre As String = ""
        Dim rfc As String = ""
        Dim document As XmlDocument = New XmlDocument
        document.Load("C:\Users\Daniel\Downloads\xmles\XMLFILE.xml")
        Dim root As XmlNode = document.DocumentElement
        Dim xmlManager = New XmlNamespaceManager(document.NameTable)
        xmlManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
        Try
            nombre = document.SelectSingleNode("cfdi:Comprobante /cfdi:Emisor", xmlManager).Attributes("nombre").Value
        Catch ex As Exception
            MsgBox("Error de lectura de nombre de emisor")
        End Try
        Try
            rfc = document.SelectSingleNode("cfdi:Comprobante /cfdi:Emisor", xmlManager).Attributes("rfc").Value
        Catch ex As Exception
            MsgBox("Error de lectura de rfc de emisor")
        End Try
        Console.WriteLine(nombre)
        Console.WriteLine(rfc)
    End Sub

    Public Sub cargarReceptor()
        Dim nombre As String = ""
        Dim rfc As String = ""
        Dim document As XmlDocument = New XmlDocument
        document.Load("C:\Users\Daniel\Downloads\xmles\XMLFILE.xml")
        Dim root As XmlNode = document.DocumentElement
        Dim xmlManager = New XmlNamespaceManager(document.NameTable)
        xmlManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
        Try
            nombre = document.SelectSingleNode("cfdi:Comprobante /cfdi:Receptor", xmlManager).Attributes("nombre").Value
        Catch ex As Exception
            MsgBox("Error de lectura de nombre de receptor")
        End Try
        Try
            rfc = document.SelectSingleNode("cfdi:Comprobante /cfdi:Receptor", xmlManager).Attributes("rfc").Value
        Catch ex As Exception
            MsgBox("Error de lectura de rfc de receptor")
        End Try
        Console.WriteLine(nombre)
        Console.WriteLine(rfc)
    End Sub

    Public Sub cargarConceptos()
        Dim xmlManager As XNamespace = "http://www.sat.gob.mx/cfd/3"
        Dim archivoXml As XDocument = XDocument.Load("C:\Users\Daniel\Downloads\xmles\XMLFILE.xml")
        Dim cont As Integer = 0
        Try
            For Each concepto As XElement In archivoXml.Descendants(xmlManager + "Comprobante").Elements(xmlManager + "Conceptos").Elements()
                Dim cantidad As String = concepto.Attribute("cantidad").Value
                Dim unidad As String = concepto.Attribute("unidad").Value
                Dim descripcion As String = concepto.Attribute("descripcion").Value
                Dim valorUnitario As String = concepto.Attribute("valorUnitario").Value
                Dim importe As String = concepto.Attribute("importe").Value
                Console.WriteLine(cantidad)
                Console.WriteLine(unidad)
                Console.WriteLine(descripcion)
                Console.WriteLine(valorUnitario)
                Console.WriteLine(importe)
            Next
        Catch ex As Exception
            MsgBox("Error de lectura de conceptos")
        End Try

    End Sub

    Public Sub cargarTimbreFiscal()
        Dim uuid As String = ""
        Dim fechaTimbrado As DateTime
        Dim selloCFD As String = ""
        Dim noCertificadoSat As String = ""
        Dim selloSat As String = ""
        Dim document As XmlDocument = New XmlDocument
        document.Load("C:\Users\Daniel\Downloads\xmles\XMLFILE.xml")
        Dim root As XmlNode = document.DocumentElement
        Dim xmlManager = New XmlNamespaceManager(document.NameTable)
        xmlManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
        xmlManager.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital")
        Try
            uuid = document.SelectSingleNode("cfdi:Comprobante /cfdi:Complemento /tfd:TimbreFiscalDigital", xmlManager).Attributes("UUID").Value
        Catch ex As Exception
            MsgBox("Error de lectura de uuid")
        End Try
        Try
            fechaTimbrado = document.SelectSingleNode("cfdi:Comprobante /cfdi:Complemento /tfd:TimbreFiscalDigital", xmlManager).Attributes("FechaTimbrado").Value

        Catch ex As Exception
            MsgBox("Error de lectura de fecha de timbrado")
        End Try
        Try
            selloCFD = document.SelectSingleNode("cfdi:Comprobante /cfdi:Complemento /tfd:TimbreFiscalDigital", xmlManager).Attributes("selloCFD").Value

        Catch ex As Exception
            MsgBox("Error de lectura de selloCFD")
        End Try
        Try
            noCertificadoSat = document.SelectSingleNode("cfdi:Comprobante /cfdi:Complemento /tfd:TimbreFiscalDigital", xmlManager).Attributes("noCertificadoSAT").Value

        Catch ex As Exception
            MsgBox("Error de lectura de noCertificadoSat")
        End Try
        Try
            selloSat = document.SelectSingleNode("cfdi:Comprobante /cfdi:Complemento /tfd:TimbreFiscalDigital", xmlManager).Attributes("selloSAT").Value

        Catch ex As Exception
            MsgBox("Error de lectura de selloSat")
        End Try
        Console.WriteLine(uuid)
        Console.WriteLine(fechaTimbrado)
        Console.WriteLine(selloCFD)
        Console.WriteLine(noCertificadoSat)
        Console.WriteLine(selloSat)
    End Sub

    Public Sub cargarNomina()
        Dim tipoNomina As String = ""
        Dim fechaPago As Date
        Dim fechaInicialPago As Date
        Dim fechaFinalPago As Date
        Dim numDiasPagados As String = ""
        Dim totalPercepciones As Decimal = 0.0
        Dim totalDeducciones As Decimal = 0.0
        Dim document As XmlDocument = New XmlDocument
        document.Load("C:\Users\Daniel\Downloads\xmles\XMLFILE.xml")
        Dim root As XmlNode = document.DocumentElement
        Dim xmlManager = New XmlNamespaceManager(document.NameTable)
        xmlManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
        xmlManager.AddNamespace("nomina12", "http://www.sat.gob.mx/nomina12")
        Try
            tipoNomina = document.SelectSingleNode("cfdi:Comprobante /cfdi:Complemento /nomina12:Nomina", xmlManager).Attributes("TipoNomina").Value

        Catch ex As Exception
            MsgBox("Error de lectura tipoNomina")
        End Try
        Try
            fechaPago = document.SelectSingleNode("cfdi:Comprobante /cfdi:Complemento /nomina12:Nomina", xmlManager).Attributes("FechaPago").Value

        Catch ex As Exception
            MsgBox("Error de lectura fechaPago")
        End Try
        Try
            fechaInicialPago = document.SelectSingleNode("cfdi:Comprobante /cfdi:Complemento /nomina12:Nomina", xmlManager).Attributes("FechaInicialPago").Value

        Catch ex As Exception
            MsgBox("Error de lectura fechaInicialPago")
        End Try
        Try
            fechaFinalPago = document.SelectSingleNode("cfdi:Comprobante /cfdi:Complemento /nomina12:Nomina", xmlManager).Attributes("FechaFinalPago").Value

        Catch ex As Exception
            MsgBox("Error de lectura fechaFinalPago")
        End Try
        Try
            numDiasPagados = document.SelectSingleNode("cfdi:Comprobante /cfdi:Complemento /nomina12:Nomina", xmlManager).Attributes("NumDiasPagados").Value

        Catch ex As Exception
            MsgBox("Error de lectura numDiasPagados")
        End Try
        Try
            totalPercepciones = document.SelectSingleNode("cfdi:Comprobante /cfdi:Complemento /nomina12:Nomina", xmlManager).Attributes("TotalPercepciones").Value

        Catch ex As Exception
            MsgBox("Error de lectura totalPercepciones")
        End Try
        Try
            totalDeducciones = document.SelectSingleNode("cfdi:Comprobante /cfdi:Complemento /nomina12:Nomina", xmlManager).Attributes("TotalDeducciones").Value

        Catch ex As Exception
            MsgBox("Error de lectura totalDeducciones")
        End Try
        Console.WriteLine(tipoNomina)
        Console.WriteLine(fechaPago)
        Console.WriteLine(fechaInicialPago)
        Console.WriteLine(fechaFinalPago)
        Console.WriteLine(numDiasPagados)
        Console.WriteLine(totalPercepciones)
        Console.WriteLine(totalDeducciones)
    End Sub

    Public Sub nominaEmisor()
        Dim registroPatronal As String = ""
        Dim document As XmlDocument = New XmlDocument
        document.Load("C:\Users\Daniel\Downloads\xmles\XMLFILE.xml")
        Dim root As XmlNode = document.DocumentElement
        Dim xmlManager = New XmlNamespaceManager(document.NameTable)
        xmlManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
        xmlManager.AddNamespace("nomina12", "http://www.sat.gob.mx/nomina12")
        Try
            registroPatronal = document.SelectSingleNode("cfdi:Comprobante /cfdi:Complemento /nomina12:Nomina /nomina12:Emisor", xmlManager).Attributes("RegistroPatronal").Value

        Catch ex As Exception
            MsgBox("Error de lectura registroPatronal emisor")
        End Try
        Console.WriteLine(registroPatronal)
    End Sub

    Public Sub nominaReceptor()
        Dim curp As String = ""
        Dim numSeguroSocial As String = ""
        Dim fechaInicioRelLaboral As Date
        Dim antiguedad As String = ""
        Dim tipoContrato As String = ""
        Dim tipoJornada As String = ""
        Dim tipoRegimen As String = ""
        Dim numEmpleado As String = ""
        Dim departamento As String = ""
        Dim puesto As String = ""
        Dim riesgoPuesto As String = ""
        Dim periodicidadPago As String = ""
        Dim cuentaBancaria As String = ""
        Dim salarioBaseCotApor As Decimal = 0.0
        Dim salarioDiarioIntegrado As Decimal = 0.0
        Dim claveEntFed As String = ""
        Dim document As XmlDocument = New XmlDocument
        document.Load("C:\Users\Daniel\Downloads\xmles\XMLFILE.xml")
        Dim root As XmlNode = document.DocumentElement
        Dim xmlManager = New XmlNamespaceManager(document.NameTable)
        xmlManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
        xmlManager.AddNamespace("nomina12", "http://www.sat.gob.mx/nomina12")
        Try
            curp = document.SelectSingleNode("cfdi:Comprobante /cfdi:Complemento /nomina12:Nomina /nomina12:Receptor", xmlManager).Attributes("Curp").Value

        Catch ex As Exception
            MsgBox("")
        End Try
        numSeguroSocial = document.SelectSingleNode("cfdi:Comprobante /cfdi:Complemento /nomina12:Nomina /nomina12:Receptor", xmlManager).Attributes("NumSeguridadSocial").Value
        fechaInicioRelLaboral = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Receptor", xmlManager).Attributes("FechaInicioRelLaboral").Value
        antiguedad = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Receptor", xmlManager).Attributes("Antigüedad").Value
        tipoContrato = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Receptor", xmlManager).Attributes("TipoContrato").Value
        tipoJornada = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Receptor", xmlManager).Attributes("TipoJornada").Value
        tipoRegimen = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Receptor", xmlManager).Attributes("TipoRegimen").Value
        numEmpleado = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Receptor", xmlManager).Attributes("NumEmpleado").Value
        departamento = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Receptor", xmlManager).Attributes("Departamento").Value
        puesto = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Receptor", xmlManager).Attributes("Puesto").Value
        riesgoPuesto = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Receptor", xmlManager).Attributes("RiesgoPuesto").Value
        periodicidadPago = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Receptor", xmlManager).Attributes("PeriodicidadPago").Value
        cuentaBancaria = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Receptor", xmlManager).Attributes("CuentaBancaria").Value
        salarioBaseCotApor = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Receptor", xmlManager).Attributes("SalarioBaseCotApor").Value
        salarioDiarioIntegrado = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Receptor", xmlManager).Attributes("SalarioDiarioIntegrado").Value
        claveEntFed = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Receptor", xmlManager).Attributes("ClaveEntFed").Value
        Console.WriteLine(curp)
        Console.WriteLine(numSeguroSocial)
        Console.WriteLine(fechaInicioRelLaboral)
        Console.WriteLine(antiguedad)
        Console.WriteLine(tipoContrato)
        Console.WriteLine(tipoJornada)
        Console.WriteLine(tipoRegimen)
        Console.WriteLine(numEmpleado)
        Console.WriteLine(departamento)
        Console.WriteLine(puesto)
        Console.WriteLine(riesgoPuesto)
        Console.WriteLine(periodicidadPago)
        Console.WriteLine(cuentaBancaria)
        Console.WriteLine(salarioBaseCotApor)
        Console.WriteLine(salarioDiarioIntegrado)
        Console.WriteLine(claveEntFed)
    End Sub

    Public Sub percepciones()
        Dim totalSueldos As Decimal = 0.0
        Dim totalGravado As Decimal = 0.0
        Dim totalExento As Decimal = 0.0
        Dim document As XmlDocument = New XmlDocument
        document.Load("C:\Users\Daniel\Downloads\xmles\XMLFILE.xml")
        Dim root As XmlNode = document.DocumentElement
        Dim xmlManager = New XmlNamespaceManager(document.NameTable)
        xmlManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
        xmlManager.AddNamespace("nomina12", "http://www.sat.gob.mx/nomina12")
        totalSueldos = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Percepciones", xmlManager).Attributes("TotalSueldos").Value
        totalGravado = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Percepciones", xmlManager).Attributes("TotalGravado").Value
        totalExento = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Percepciones", xmlManager).Attributes("TotalExento").Value
        Console.WriteLine(totalSueldos)
        Console.WriteLine(totalGravado)
        Console.WriteLine(totalExento)
    End Sub

    Public Sub percepcion()
        Dim xmlManager As XNamespace = "http://www.sat.gob.mx/cfd/3"
        Dim xmlNomina As XNamespace = "http://www.sat.gob.mx/nomina12"
        Dim archivoXml As XDocument = XDocument.Load("C:\Users\Daniel\Downloads\xmles\XMLFILE.xml")
        Dim cont As Integer = 0
        For Each per As XElement In archivoXml.Descendants(xmlManager + "Comprobante").Elements(xmlManager + "Complemento").Elements(xmlNomina + "Nomina").Elements(xmlNomina + "Percepciones").Elements(xmlNomina + "Percepcion")
            Dim tipoPercepcion As String = per.Attribute("TipoPercepcion").Value
            Dim clave As String = per.Attribute("Clave").Value
            Dim concepto As String = per.Attribute("Concepto").Value
            Dim importeGravado As String = per.Attribute("ImporteGravado").Value
            Dim importeExento As String = per.Attribute("ImporteExento").Value
            Console.WriteLine(tipoPercepcion & " " & clave & " " & concepto & " " & importeGravado & " " & importeExento)

        Next

    End Sub

    Public Sub deducciones()
        Dim totalOtrasDeducciones As Decimal = 0.0
        Dim totalImpuestosRetenidos As Decimal = 0.0
        Dim document As XmlDocument = New XmlDocument
        document.Load("C:\Users\Daniel\Downloads\xmles\XMLFILE.xml")
        Dim root As XmlNode = document.DocumentElement
        Dim xmlManager = New XmlNamespaceManager(document.NameTable)
        xmlManager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
        xmlManager.AddNamespace("nomina12", "http://www.sat.gob.mx/nomina12")
        totalOtrasDeducciones = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Deducciones", xmlManager).Attributes("TotalOtrasDeducciones").Value
        totalImpuestosRetenidos = document.SelectSingleNode("cfdi:Comprobante / cfdi:Complemento /nomina12:Nomina /nomina12:Deducciones", xmlManager).Attributes("TotalImpuestosRetenidos").Value
        Console.WriteLine(totalOtrasDeducciones)
        Console.WriteLine(totalImpuestosRetenidos)
    End Sub

    Public Sub deduccion()
        Dim xmlManager As XNamespace = "http://www.sat.gob.mx/cfd/3"
        Dim xmlNomina As XNamespace = "http://www.sat.gob.mx/nomina12"
        Dim archivoXml As XDocument = XDocument.Load("C:\Users\Daniel\Downloads\xmles\XMLFILE.xml")
        Dim cont As Integer = 0
        For Each ded As XElement In archivoXml.Descendants(xmlManager + "Comprobante").Elements(xmlManager + "Complemento").Elements(xmlNomina + "Nomina").Elements(xmlNomina + "Deducciones").Elements(xmlNomina + "Deduccion")
            Dim tipoDeduccion As String = ded.Attribute("TipoDeduccion").Value
            Dim clave As String = ded.Attribute("Clave").Value
            Dim concepto As String = ded.Attribute("Concepto").Value
            Dim importe As String = ded.Attribute("Importe").Value
            Console.WriteLine(tipoDeduccion & " " & clave & " " & concepto & " " & importe)

        Next
    End Sub
End Class