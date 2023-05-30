using System;

namespace ConsoleUI.Models.Documentos.NFe
{
    public class NFeRetorno
    {
        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public int Codigo { get; set; }
            public string Descricao { get; set; }
            public Documento[] Documentos { get; set; }
        }

        public class Documento
        {
            public string DocModelo { get; set; }
            public int DocNumero { get; set; }
            public string DocSerie { get; set; }
            public string DocChaAcesso { get; set; }
            public string DocProtocolo { get; set; }
            public int DocEvenSeq { get; set; }
            public int DocEveTp { get; set; }
            public string DocEveId { get; set; }
            public string DocPDFBase64 { get; set; }
            public string DocPDFDownload { get; set; }
            public DateTime DocDhAut { get; set; }
            public string DocDigestValue { get; set; }
            public string DocXMLBase64 { get; set; }
            public string DocXMLDownload { get; set; }
            public string DocImpressora { get; set; }
            public Situacao Situacao { get; set; }
            public Mensagemsefaz MensagemSefaz { get; set; }
            public Nfse NFSe { get; set; }
            public string DocImpPrefeitura { get; set; }
            public string DocCompleto { get; set; }
        }

        public class Situacao
        {
            public int SitCodigo { get; set; }
            public string SitDescricao { get; set; }
        }

        public class Mensagemsefaz
        {
            public int CodMsg { get; set; }
            public string DscMsg { get; set; }
        }

        public class Nfse
        {
            public int NFSeNumero { get; set; }
            public string NFSeCodVerificacao { get; set; }
            public string NFSeDataEmissao { get; set; }
        }
    }
}

