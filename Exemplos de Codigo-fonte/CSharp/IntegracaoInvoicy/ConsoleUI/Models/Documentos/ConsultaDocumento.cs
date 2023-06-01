namespace ConsoleUI.Models.Documentos
{
    public class ConsultaDocumento
    {
        public string document;
        public string type;// = Consulta &
        public string CnpjEmissor;// = 06354976000149 &
        public int? NumeroInicial;// = 25 &
        public int? NumeroFinal;// = 26 &
        public int? Serie;// = 245 &
        public string Versao;// = 4.00 &
        public string CnpjEmpresa;// = 06354976000149 &
        public int? tpAmb;// = 2 &
        public string dhUF;
        public string ChaveAcesso;
        public string DataEmissaoInicial;
        public string DataEmissaoFinal;
        public string DataInclusaoFinal;
        public string DataInclusaoInicial;
        public string StatusDocumento;
        public string EmitidoRecebido; 
        public string ParmTipoImpressao; 
        public string DocumentosResumo;
        public string ParmAutorizadoDownload;
        public string ParmXMLLink;
        public string ParmXMLCompleto;
        public string ParmPDFBase64;// = N &
        public string ParmPDFLink;// = S &
        public string ParmEventos;// = N &
        public string ParmSituacao;// = S

        public ConsultaDocumento(string document, string type, string CnpjEmissor, int NumeroInicial, int NumeroFinal, int Serie, string CnpjEmpresa, int tpAmb)
        {
            this.document = document;
            this.type = type;
            this.CnpjEmissor = CnpjEmissor;
            this.NumeroInicial = NumeroInicial;
            this.NumeroFinal = NumeroFinal;
            this.Serie = Serie;
            this.CnpjEmpresa = CnpjEmpresa;
            this.tpAmb = tpAmb;
        }


        //{{api-invoicy-br}}/senddocuments/nfce?type=Consulta&CnpjEmissor=06354976000149&NumeroInicial=25&NumeroFinal=26&Serie=245&CnpjEmpresa=06354976000149&tpAmb=2&ParmPDFBase64=N&ParmPDFLink=S&ParmEventos=N&ParmSituacao=S

        public string GetLink()
        {
            var uri = $"https://apibrhomolog.invoicy.com.br/senddocuments";
            if (document != null)
            {
                uri = $"{uri}/{document.ToLower()}?";
            }
            if (type != null)
            {
                uri = $"{uri}type={type}&";
            }
            if (CnpjEmissor != null)
            {
                uri = $"{uri}CnpjEmissor={CnpjEmissor}&";
            }
            if (NumeroInicial != null)
            {
                uri = $"{uri}NumeroInicial={NumeroInicial}&";
            }
            if (NumeroFinal != null)
            {
                uri = $"{uri}NumeroFinal={NumeroFinal}&";
            }
            if (Serie != null)
            {
                uri = $"{uri}Serie={Serie}&";
            }
            if (Versao != null)
            {
                uri = $"{uri}Versao={Versao}&";
            }
            if (CnpjEmpresa != null)
            {
                uri = $"{uri}CnpjEmpresa={CnpjEmpresa}&";
            }
            if (tpAmb != null)
            {
                uri = $"{uri}tpAmb={tpAmb}&";
            }
            if (dhUF != null)
            {
                uri = $"{uri}dhUF={dhUF}&";
            }
            if (ChaveAcesso != null)
            {
                uri = $"{uri}ChaveAcesso={ChaveAcesso}&";
            }
            if (DataEmissaoInicial != null)
            {
                uri = $"{uri}DataEmissaoInicial={DataEmissaoInicial}&";
            }
            if (DataEmissaoFinal != null)
            {
                uri = $"{uri}DataEmissaoFinal={DataEmissaoFinal}&";
            }
            if (DataInclusaoFinal != null)
            {
                uri = $"{uri}DataInclusaoFinal={DataInclusaoFinal}&";
            }
            if (DataInclusaoInicial != null)
            {
                uri = $"{uri}DataInclusaoInicial={DataInclusaoInicial}&";
            }
            if (StatusDocumento != null)
            {
                uri = $"{uri}StatusDocumento={StatusDocumento}&";
            }
            if (EmitidoRecebido != null)
            {
                uri = $"{uri}EmitidoRecebido={EmitidoRecebido}&";
            }
            if (ParmTipoImpressao != null)
            {
                uri = $"{uri}ParmTipoImpressao={ParmTipoImpressao}&";
            }
            if (EmitidoRecebido != null)
            {
                uri = $"{uri}EmitidoRecebido={EmitidoRecebido}&";
            }
            if (DocumentosResumo != null)
            {
                uri = $"{uri}DocumentosResumo={DocumentosResumo}&";
            }
            if (ParmAutorizadoDownload != null)
            {
                uri = $"{uri}ParmAutorizadoDownload={ParmAutorizadoDownload}&";
            }
            if (ParmXMLLink != null)
            {
                uri = $"{uri}ParmXMLLink={ParmXMLLink}&";
            }
            if (ParmXMLCompleto != null)
            {
                uri = $"{uri}ParmXMLCompleto={ParmXMLCompleto}&";
            }
            if (ParmPDFBase64 != null)
            {
                uri = $"{uri}ParmPDFBase64={ParmPDFBase64}&";
            }
            if (ParmPDFLink != null)
            {
                uri = $"{uri}ParmPDFLink={ParmPDFLink}&";
            }
            if (ParmEventos != null)
            {
                uri = $"{uri}ParmEventos={ParmEventos}&";
            }
            if (ParmSituacao != null)
            {
                uri = $"{uri}ParmSituacao={ParmSituacao}&";
            }


            return uri;
        }

    }
}
