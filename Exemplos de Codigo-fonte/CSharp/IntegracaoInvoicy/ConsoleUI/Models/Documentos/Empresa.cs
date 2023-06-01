namespace ConsoleUI.Models.Documentos
{
    public class Empresa
    {
        public string EmpNomFantasia { get; set; }
        public string EmpApelido { get; set; }
        public string EmpRazSocial { get; set; }
        public string EmpCNPJ { get; set; }
        public string EmpCPF { get; set; }
        public string EmpIE { get; set; }
        public string EmpTelefone { get; set; }
        public string EmpEndereco { get; set; }
        public string EmpNumero { get; set; }
        public string EmpBairro { get; set; }
        public string EmpCEP { get; set; }
        public string EmpComplemento { get; set; }
        public string EmpIM { get; set; }
        public int MunCodigo { get; set; }
        public string EmpCNAE { get; set; }
        public int EmpCRT { get; set; }
        public string EmpIEST { get; set; }
        public string EmpMarca { get; set; }
        public string EmpMarcaExtensao { get; set; }
        public string EmpEmail { get; set; }
        public string EmpObservacao { get; set; }
        public string EmpTpoEndereco { get; set; }
        public Certificado Certificado { get; set; }
        public Usuario[] Usuarios { get; set; }
        public Caixaenvioemail CaixaEnvioEmail { get; set; }
        public Caixasleituraemail[] CaixasLeituraEmail { get; set; }
        public Parametros Parametros { get; set; }
        public Licenciamento[] Licenciamento { get; set; }
        public Impressao Impressao { get; set; }
        public Extensao[] Extensao { get; set; }
    }
    public class Certificado
    {
        public string ArquivoPFX { get; set; }
        public string Senha { get; set; }
        public int TipoCertificado { get; set; }
        public string MetodoCriptografiaSenha { get; set; }
    }

    public class Caixaenvioemail
    {
        public string EmlValCertificado { get; set; }
        public int EmlTmpEspera { get; set; }
        public string EmlAutenticacao { get; set; }
        public string EmlSSL { get; set; }
        public int EmlPorta { get; set; }
        public string EmlHost { get; set; }
        public string EmlSenha { get; set; }
        public string EmlUsuario { get; set; }
        public string EmlNomeRemetente { get; set; }
        public string EmlEmailRemetente { get; set; }
    }

    public class Parametros
    {
        public Nfe NFe { get; set; }
        public Nfse NFSe { get; set; }
        public Mdfe MDFe { get; set; }
        public Nfce NFCe { get; set; }
        public Cte CTe { get; set; }
    }

    public class Nfe
    {
        public int FormaRetornoPDFIntegracao { get; set; }
        public int FormaRetornoXMLIntegracao { get; set; }
        public string UltimoNSU { get; set; }
        public string JustInut { get; set; }
        public string JustCanc { get; set; }
        public string JustCont { get; set; }
        public string TextoEmailAutorizado { get; set; }
        public string TextoEmailCancelado { get; set; }
        public string TextoEmailCCe { get; set; }
        public string EmailTitulo { get; set; }
        public string EnviarPDFEmail { get; set; }
        public string EnviarXMLEmail { get; set; }
        public Ordemcontingencia[] OrdemContingencia { get; set; }
    }

    public class Ordemcontingencia
    {
        public int OrdemContingenciaNFe { get; set; }
    }

    public class Nfse
    {
        public string CodCMC { get; set; }
        public int AmbienteEmissao { get; set; }
        public int MaxRPSLote { get; set; }
        public string TipoProcessamento { get; set; }
        public string UsuarioAutent { get; set; }
        public string SenhaAutent { get; set; }
        public string ImprimeNFSeEfetivada { get; set; }
        public string EnviarNFSeTomador { get; set; }
        public string EmpRetImpPrefeitura { get; set; }
        public string EmpConcatOutrasInfo { get; set; }
        public int EmpImprimeCanhoto { get; set; }
        public string EmpChavePrimaria { get; set; }
        public int FormaRetornoPDFIntegracao { get; set; }
        public int FormaRetornoXmlIntegracao { get; set; }
        public string EmpDiscriminacaoBetha { get; set; }
        public string EmpAutorizacaoRegimeRPS { get; set; }
        public string EmpEspelhoNovo { get; set; }
        public string EmpEnviaCPFPrestador { get; set; }
        public int VerCodigo { get; set; }
        public string DataAdesaoSimplesNacional { get; set; }
        public string EmpEnviaEmailCompactado { get; set; }
        public string ImprimeItensEspelho { get; set; }
        public string EmpClientId { get; set; }
        public string EmpClientSecret { get; set; }
        public string EmpImgRodapeBase64 { get; set; }
        public int FaixaRPSAutorizadoInicial { get; set; }
        public int FaixaRPSAutorizadoFinal { get; set; }
        public string ImprimirOutrasInformacoes { get; set; }
        public string ImprimirRetencoesFederais { get; set; }
        public string XMLRetornoRequisicao { get; set; }
        public string NomeCanhoto { get; set; }
        public string ReceberEmailEmpresaTrancada { get; set; }
    }

    public class Mdfe
    {
        public int FormaRetornoPDFIntegracao { get; set; }
        public int FormaRetornoXMLIntegracao { get; set; }
        public string UltimoNSU { get; set; }
        public string JustCanc { get; set; }
        public string JustCont { get; set; }
    }

    public class Nfce
    {
        public int FormaRetornoPDFIntegracao { get; set; }
        public int FormaRetornoXMLIntegracao { get; set; }
        public string IDTokenCscSEFAZ { get; set; }
        public string CscSEFAZ { get; set; }
        public string PossuiLeituraX { get; set; }
        public string JustInut { get; set; }
        public string JustCanc { get; set; }
        public string JustCont { get; set; }
        public string TextoEmailAutorizado { get; set; }
        public string TextoEmailCancelado { get; set; }
        public string EmailTitulo { get; set; }
        public string EnviarPDFEmail { get; set; }
        public string EnviarXMLEmail { get; set; }
        public Ordemcontingencia1[] OrdemContingencia { get; set; }
    }

    public class Ordemcontingencia1
    {
        public int OrdemContingenciaNFCe { get; set; }
    }

    public class Cte
    {
        public int FormaRetornoPDFIntegracao { get; set; }
        public int FormaRetornoXMLIntegracao { get; set; }
        public string UltimoNSU { get; set; }
        public string JustInut { get; set; }
        public string JustCanc { get; set; }
        public string JustCont { get; set; }
        public string TextoEmailAutorizado { get; set; }
        public string TextoEmailCancelado { get; set; }
        public string TextoEmailCCe { get; set; }
        public string EmailTitulo { get; set; }
        public string EnviarPDFEmail { get; set; }
        public string EnviarXMLEmail { get; set; }
        public Ordemcontingencia2[] OrdemContingencia { get; set; }
    }

    public class Ordemcontingencia2
    {
        public int OrdemContingenciaCTe { get; set; }
    }

    public class Impressao
    {
        public Nfe1 NFe { get; set; }
        public Mdfe1 MDFe { get; set; }
        public Cte1 CTe { get; set; }
        public Nfce1 NFCe { get; set; }
    }

    public class Nfe1
    {
        public int OrientacaoNFe { get; set; }
        public string ImprimirDataHoraImpressao { get; set; }
        public string ImprimirTributos { get; set; }
        public string TextoImpressaoTributos { get; set; }
        public string ExibirDescontoEIcmsNoItem { get; set; }
        public string LocalImpressaoCanhoto { get; set; }
        public string MolduraNaLogomarca { get; set; }
        public int ModeloDANFE { get; set; }
        public string ExibirEndEntregaInfoAdic { get; set; }
        public string ImprimirDuplicatas { get; set; }
        public string UtilizarImagemInfoEmitente { get; set; }
        public string ImprimirVolumesItensDestacados { get; set; }
        public string ImprimirTotalPISCOFINS { get; set; }
        public string InfoComplementar { get; set; }
        public string DestaqueProdutosPerigosos { get; set; }
        public int TamanhoFonteInfComplementares { get; set; }
        public string ImprimeUNTribDiferenteComercial { get; set; }
        public int ImprimirEnderecoEntregaRetirada { get; set; }
        public string ImprimirCamposDIFAL { get; set; }
        public string ImprimirICMSCST51 { get; set; }
        public string TamanhoFonteProdutos { get; set; }
        public string TamanhoFonteInfComplementaresProd { get; set; }
        public string ImprimirICMSDesonerado { get; set; }
        public string ImprimirEmitenteCentralizado { get; set; }
        public string ImprimirFatura { get; set; }
        public string ImprimirVolumes { get; set; }
        public string ImprimirVolumesNegrito { get; set; }
        public string ImprimirVolumesEspacados { get; set; }
        public string ImprimirItensEspacados { get; set; }
        public string AgruparInfoAdicProdutos { get; set; }
        public string ImprimirTotalAFRMM { get; set; }
        public string ImprimirICMSSTItem { get; set; }
        public string ImprimirTotalImpostoImportacao { get; set; }
        public string ImprimirFCP { get; set; }
        public string ImprimirTextosNegrito { get; set; }
        public string ImprimirFCI { get; set; }
        public string ImprimirConfirmEntregaCanhoto { get; set; }
    }

    public class Mdfe1
    {
        public int OrientacaoMDFe { get; set; }
        public string MolduraNaLogomarca { get; set; }
    }

    public class Cte1
    {
        public int OrientacaoCTe { get; set; }
        public string MolduraNaLogomarca { get; set; }
        public string LocalImpressaoCanhoto { get; set; }
        public string TextoImpressaoTributos { get; set; }
    }

    public class Nfce1
    {
        public string ModeloDANFE { get; set; }
        public string ImpAcrescDescItens { get; set; }
        public string FormatoDANFE { get; set; }
    }

    public class Usuario
    {
        public string UsrNome { get; set; }
        public string UsrEmail { get; set; }
        public string UsrSenha { get; set; }
        public Permissoes Permissoes { get; set; }
    }

    public class Permissoes
    {
        public Permissaocte PermissaoCTe { get; set; }
        public Permissaomdfe PermissaoMDFe { get; set; }
        public Permissaonfse PermissaoNFSe { get; set; }
        public Permissaonfe PermissaoNFe { get; set; }
        public Permissaonfce PermissaoNFCe { get; set; }
        public Permissoesgerais PermissoesGerais { get; set; }
    }

    public class Permissaocte
    {
        public string Visualizar { get; set; }
        public string Baixar { get; set; }
    }

    public class Permissaomdfe
    {
        public string Visualizar { get; set; }
        public string Baixar { get; set; }
    }

    public class Permissaonfse
    {
        public string Visualizar { get; set; }
        public string Baixar { get; set; }
        public string EnviarConsultarDocs { get; set; }
    }

    public class Permissaonfe
    {
        public string Visualizar { get; set; }
        public string Baixar { get; set; }
    }

    public class Permissaonfce
    {
        public string Visualizar { get; set; }
        public string Baixar { get; set; }
    }

    public class Permissoesgerais
    {
        public string ImportarDocumentos { get; set; }
        public string AlterarDadosDoUsuario { get; set; }
        public string AlterarDadosDaEmpresa { get; set; }
        public string AlterarMarcasDaEmpresa { get; set; }
        public string AlterarCertificadosDaEmpresa { get; set; }
        public string AlterarConfiguracoesParametros { get; set; }
        public string CadastrarEmpresas { get; set; }
        public string AlterarCaixasDeEmail { get; set; }
        public string AlterarPermissoesDeUsuario { get; set; }
        public string AdicionarNovosUsuarios { get; set; }
        public string VisualizarChaveAcesso { get; set; }
        public string VisualizarAcoesDeUsuarios { get; set; }
        public string VisualizarQuantidadesEmitidas { get; set; }
        public string VisualizarLicencas { get; set; }
        public string ConfiguracaoSenha { get; set; }
        public string GerarRelatorios { get; set; }
        public string InutilizarDocumentos { get; set; }
        public string FerramentasIntegracao { get; set; }
    }

    public class Caixasleituraemail
    {
        public string EmlValCertificado { get; set; }
        public int EmlTmpEspera { get; set; }
        public string EmlAutenticacao { get; set; }
        public string EmlSSL { get; set; }
        public int EmlPorta { get; set; }
        public string EmlHost { get; set; }
        public string EmlSenha { get; set; }
        public string EmlUsuario { get; set; }
        public string EmlNomeRemetente { get; set; }
        public string EmlEmailRemetente { get; set; }
    }

    public class Licenciamento
    {
        public string CnpjEmpresa { get; set; }
        public string tpAmb { get; set; }
        public string Acao { get; set; }
        public string Modulo { get; set; }
        public string Modelo { get; set; }
        public string Autor { get; set; }
    }

    public class Extensao
    {
        public int TipoExtensao { get; set; }
        public Modulo[] Modulos { get; set; }
        public Parametrosext ParametrosExt { get; set; }
        public string Ativar { get; set; }
    }

    public class Parametrosext
    {
        public int NumeroConsultasDiarias { get; set; }
        public string ArmazenarEveTerceiros { get; set; }
        public string BaixarDocsNaoArmazenados { get; set; }
        public int CienciaAutomatica { get; set; }
        public string Justificativa { get; set; }
        public string ValorMin { get; set; }
        public string Email { get; set; }
        public int TipoNotificacao { get; set; }
        public string BuscarDocsRetroativos { get; set; }
        public string TipoConsultaNFSe { get; set; }
    }

    public class Modulo
    {
        public string modulo { get; set; }
    }
}


