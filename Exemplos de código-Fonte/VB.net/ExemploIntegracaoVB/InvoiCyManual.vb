Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Net

Public Class InvoiCyManual

    Public Sub New()
        ' método construtor
    End Sub

    ' atributos públicos de entrada
    Public UrlWs As String

    Public Soap As String

    'atributos públicos de saída
    Public ErrorCode As Integer

    Public SoapRet As String

    Public ErrorDesc As String


    'Função que executa requisição ao Web service
    Public Sub ExecutaWS()

        'faz o requisição ao invoiCy
        Try
            Dim req As HttpWebRequest = CType(WebRequest.Create(UrlWs), HttpWebRequest)
            req.Method = "POST"

            Dim stm As System.IO.Stream = req.GetRequestStream()

            Dim stmw As System.IO.StreamWriter = New System.IO.StreamWriter(stm)

            stmw.Write(Soap)

            stmw.Close()
            stmw.Dispose()

            stm.Close()
            stm.Dispose()


            'Faz a leitura do retorno da chamada
            Try

                Dim response As System.Net.WebResponse = req.GetResponse()
                Dim responseStream As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())

                SoapRet = responseStream.ReadToEnd().Trim().Replace("\n", "").Replace("\t", "")

                ErrorCode = 100
                responseStream.Close()
                responseStream.Dispose()


                'Falha na requisição
            Catch wexc As WebException
                Dim resp As System.Net.HttpWebResponse = wexc.Response 'As System.Net.HttpWebResponse 
                Dim responseStream As System.IO.StreamReader = New System.IO.StreamReader(resp.GetResponseStream())
                SoapRet = responseStream.ReadToEnd()

                ErrorDesc = "Falha na comunicação: " + SoapRet
                ErrorCode = 801
                responseStream.Close()
                responseStream.Dispose()

            End Try


            'falha na requisição  
        Catch exc As Exception
            ErrorCode = 999
            ErrorDesc = exc.Message + exc.StackTrace

        End Try

    End Sub

    'Função que realiza a escrita do SOAP
    Public Function EscreveSoap(ByVal xml As String, ByVal EmpPK As String, ByVal HashGerado As String) As String
        'Lineariza o XML do documento           
        xml = xml.Replace("(?ism)(?<=>)[^a-z|0-9]*(?=<)", "")

        'Converte para texto o xml do documento
        Dim XmlEnvio As String = xml
        XmlEnvio = XmlEnvio.Replace("<", "&lt;")
        XmlEnvio = XmlEnvio.Replace(">", "&gt;")
        XmlEnvio = XmlEnvio.Replace("\", "&quot")

        Dim sBody As String = ""

        sBody += "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:inv=""InvoiCy"">"
        sBody += "<soapenv:Header/>"
        sBody += "<soapenv:Body>"
        sBody += "<inv:recepcao.Execute>"
        sBody += "<inv:Invoicyrecepcao>"
        sBody += "<inv:Cabecalho>"
        sBody += "<inv:EmpPK>" + EmpPK + "</inv:EmpPK>"
        sBody += "<inv:EmpCK>" + HashGerado + "</inv:EmpCK>"
        sBody += "<inv:EmpCO></inv:EmpCO>"
        sBody += "</inv:Cabecalho>"
        sBody += "<inv:Informacoes>"
        sBody += "<inv:Texto></inv:Texto>"
        sBody += "</inv:Informacoes>"
        sBody += "<inv:Dados>"
        sBody += "<inv:DadosItem>"
        sBody += "<inv:Documento>" + XmlEnvio + "</inv:Documento>"
        sBody += "<inv:Parametros></inv:Parametros>"
        sBody += "</inv:DadosItem>"

        'Caso deseja enviar mais de um documento, repetir a tag "DadosItem"

        sBody += "</inv:Dados>"
        sBody += "</inv:Invoicyrecepcao>"
        sBody += "</inv:recepcao.Execute>"
        sBody += "</soapenv:Body>"
        sBody += "</soapenv:Envelope>"

        Return sBody
    End Function



End Class
