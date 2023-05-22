Public Class ExemploIntegracao

    Private Sub btnExecutar_Click(sender As Object, e As EventArgs) Handles btnExecutar.Click

        'Exemplo de envio com Web Reference
        EnvioAutomatico()

        'Exemplo de envio escrevendo o SOAP
        'EnvioManual()

    End Sub


    Private Sub EnvioManual()

        'Gera CK
        Dim CK As String = GeraHashMD5(txtXML.Text)

        'instancia um objeto da classe de envio ao webservice e atribui a eles os parametros necessários.
        Dim client As InvoiCyManual = New InvoiCyManual()
        client.UrlWs = "https://homolog.invoicy.com.br/arecepcao.aspx?wsdl"
        client.Soap = client.EscreveSoap(txtXML.Text, txtChaveParceiro.Text, CK)

        'Recebe o retorno da requisição.
        client.ExecutaWS()

        'Busca o código e a descrição de retorno.
        Dim descricaoRetorno As String = client.SoapRet.Substring(client.SoapRet.IndexOf("<Descricao>"), client.SoapRet.IndexOf("</Descricao>") - client.SoapRet.IndexOf("<Descricao>")).Replace("<Descricao>", "")
        Dim codigoRetorno As String = client.SoapRet.Substring(client.SoapRet.IndexOf("<Codigo>"), client.SoapRet.IndexOf("</Codigo>") - client.SoapRet.IndexOf("<Codigo>")).Replace("<Codigo>", "")

        'Mostra em tela a mensagem e o documento de retorno da requisição.
        txtRetMensagem.Text = ""
        txtRetDocumento.Text = ""

        If client.ErrorCode = 100 Then
            txtRetMensagem.Text = codigoRetorno & " - " & descricaoRetorno     'Sucesso no envio
        Else
            txtRetMensagem.Text = client.ErrorCode & " - " & client.ErrorDesc  'Retorna erros ocorridos no envio
        End If

        txtRetDocumento.Text = client.SoapRet


    End Sub

    Private Sub EnvioAutomatico()

        'Cria um objeto para guardar os dados do cabeçalho da conexão
        Dim cabecalho As InvoiCyRecepcao.InvoiCyRecepcaoCabecalho = New InvoiCyRecepcao.InvoiCyRecepcaoCabecalho
        cabecalho.EmpPK = txtChaveParceiro.Text
        cabecalho.EmpCO = ""

        'Chama a função que gera a CK, e depois adiciona a mesma no cabeçalho.
        cabecalho.EmpCK = GeraHashMD5(txtXML.Text)

        'Armazena os dados da requisição.
        Dim dados As InvoiCyRecepcao.InvoiCyRecepcaoDadosItem = New InvoiCyRecepcao.InvoiCyRecepcaoDadosItem
        dados.Documento = txtXML.Text
        dados.Parametros = ""

        'Adiciona os dados na recepção
        Dim IVC As InvoiCyRecepcao.InvoiCy = New InvoiCyRecepcao.InvoiCy()
        IVC.Cabecalho = cabecalho

        Dim list As InvoiCyRecepcao.InvoiCy.DadosType = New InvoiCyRecepcao.InvoiCy.DadosType()
        list.Add(dados)
        IVC.Dados = list
        'Exemplo de envio de somente um documento, porém vários podem ser adicionados na mesma chamada

        'Adiciona as informações da requisição
        Dim info As InvoiCyRecepcao.InvoiCyRecepcaoInformacoes = New InvoiCyRecepcao.InvoiCyRecepcaoInformacoes
        info.Texto = ""
        IVC.Informacoes = info

        'Envia e recebe o retorno da requisição.
        Dim recepcao As InvoiCyRecepcao.recepcaoSoapPort = New InvoiCyRecepcao.recepcaoSoapPortClient
        Dim retorno As InvoiCyRecepcao.ExecuteResponse = recepcao.Execute(New InvoiCyRecepcao.ExecuteRequest(IVC))

        'Leitura do retorno
        txtRetMensagem.Text = ""
        txtRetDocumento.Text = ""
        For Each msgItem As InvoiCyRecepcao.InvoiCyRetornoMensagemItem In retorno.Invoicyretorno.Mensagem

            txtRetMensagem.Text += msgItem.Codigo.ToString + " - " + msgItem.Descricao

            If msgItem.Documentos.Count > 0 Then

                For Each docItem As InvoiCyRecepcao.InvoiCyRetornoMensagemItem.DocumentosItem In msgItem.Documentos

                    txtRetDocumento.Text += docItem.Documento.Trim

                Next

            End If

        Next


    End Sub

    'Função de geração de hashMD5 para CK.
    Private Function GeraHashMD5(ByVal texto As String) As String
        Dim md5Hash As System.Security.Cryptography.MD5 = System.Security.Cryptography.MD5.Create()

        Dim data() As Byte = md5Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(txtChaveComunicacao.Text + texto.Trim()))

        Dim sBuilder As System.Text.StringBuilder = New System.Text.StringBuilder()

        Dim i As Integer
        For i = 0 To data.Length - 1 Step i + 1
            sBuilder.Append(data(i).ToString("x2"))
        Next
        Return sBuilder.ToString()

    End Function



End Class
