using System;

namespace ConsoleUI.Models.Documentos.NFe
{
    public class NFe
    {
        public object[] autXML { get; set; }
        public Cana cana { get; set; }
        public Cobr cobr { get; set; }
        public Compra compra { get; set; }
        public Dest dest { get; set; }
        public Det[] det { get; set; }
        public Emit emit { get; set; }
        public Entrega entrega { get; set; }
        public Exporta exporta { get; set; }
        public Ide ide { get; set; }
        public Infadic infAdic { get; set; }
        public string ModeloDocumento { get; set; }
        public Pag[] pag { get; set; }
        public Parametros Parametros { get; set; }
        public Retirada retirada { get; set; }
        public Total total { get; set; }
        public Transp transp { get; set; }
        public int Versao { get; set; }
    }

    public class Cana
    {
        public object[] canaDeducoes { get; set; }
        public object[] canaDiario { get; set; }
        public string qTotAnt { get; set; }
        public string qTotGer { get; set; }
        public string qTotMes { get; set; }
        public string _ref { get; set; }
        public string safra { get; set; }
        public string vFor { get; set; }
        public string vLiqFor { get; set; }
        public string vTotDed { get; set; }
    }

    public class Cobr
    {
        public object[] dup { get; set; }
        public Fat fat { get; set; }
    }

    public class Fat
    {
        public string nFat { get; set; }
        public string vDesc_cob { get; set; }
        public string vLiq { get; set; }
        public string vOrig { get; set; }
    }

    public class Compra
    {
        public string xCont { get; set; }
        public string xNEmp { get; set; }
        public string xPed { get; set; }
    }

    public class Dest
    {
        public string CNPJ_dest { get; set; }
        public string CPF_dest { get; set; }
        public Enderdest enderDest { get; set; }
        public string idEstrangeiro { get; set; }
        public string IE_dest { get; set; }
        public string IM_dest { get; set; }
        public int indIEDest { get; set; }
        public string ISUF { get; set; }
        public string xNome_dest { get; set; }
    }

    public class Enderdest
    {
        public int CEP_dest { get; set; }
        public int cMun_dest { get; set; }
        public int cPais_dest { get; set; }
        public long fone_dest { get; set; }
        public string nro_dest { get; set; }
        public string UF_dest { get; set; }
        public string xBairro_dest { get; set; }
        public string xCpl_dest { get; set; }
        public string xEmail_dest { get; set; }
        public string xLgr_dest { get; set; }
        public string xMun_dest { get; set; }
        public string xPais_dest { get; set; }
    }

    public class Emit
    {
        public string CNAE { get; set; }
        public string CNPJ_emit { get; set; }
        public string CPF_emit { get; set; }
        public int CRT { get; set; }
        public Enderemit enderEmit { get; set; }
        public string IE { get; set; }
        public string IEST { get; set; }
        public string IM { get; set; }
        public string xFant { get; set; }
        public string xNome { get; set; }
    }

    public class Enderemit
    {
        public int CEP { get; set; }
        public int cMun { get; set; }
        public int cPais { get; set; }
        public string Email { get; set; }
        public long fax { get; set; }
        public long fone { get; set; }
        public string nro { get; set; }
        public string UF { get; set; }
        public string xBairro { get; set; }
        public string xCpl { get; set; }
        public string xLgr { get; set; }
        public string xMun { get; set; }
        public string xPais { get; set; }
    }

    public class Entrega
    {
        public int CEP_entr { get; set; }
        public int cMun_entr { get; set; }
        public string CNPJ_entr { get; set; }
        public int cPais_entr { get; set; }
        public string CPF_entr { get; set; }
        public string email_entr { get; set; }
        public int fone_entr { get; set; }
        public string IE_entr { get; set; }
        public string nro_entr { get; set; }
        public string UF_entr { get; set; }
        public string xBairro_entr { get; set; }
        public string xCpl_entr { get; set; }
        public string xLgr_entr { get; set; }
        public string xMun_entr { get; set; }
        public string xNome_entr { get; set; }
        public string xPais_entr { get; set; }
    }

    public class Exporta
    {
        public string UFEmbarq { get; set; }
        public string xLocDespacho { get; set; }
        public string xLocEmbarq { get; set; }
    }

    public class Ide
    {
        public int cMunFg { get; set; }
        public int cNF { get; set; }
        public int cUF { get; set; }
        public string dhCont { get; set; }
        public DateTime dhEmi { get; set; }
        public string dhSaiEnt { get; set; }
        public string EmailArquivos { get; set; }
        public int finNFe { get; set; }
        public string fusoHorario { get; set; }
        public int idDest { get; set; }
        public int indFinal { get; set; }
        public int indPres { get; set; }
        public string mod { get; set; }
        public string natOp { get; set; }
        public int nNF { get; set; }
        public string NumeroPedido { get; set; }
        public string serie { get; set; }
        public int tpAmb { get; set; }
        public int tpEmis { get; set; }
        public int tpImp { get; set; }
        public int tpNf { get; set; }
        public string xJust { get; set; }
    }

    public class Infadic
    {
        public string infAdFisco { get; set; }
        public string infCpl { get; set; }
        public object[] obsCont { get; set; }
        public object[] procRef { get; set; }
    }

    public class Parametros
    {
        public string ApelidoLogomarca { get; set; }
    }

    public class Retirada
    {
        public int CEP_ret { get; set; }
        public int cMun_ret { get; set; }
        public string CNPJ_ret { get; set; }
        public int cPais_ret { get; set; }
        public string CPF_ret { get; set; }
        public string email_ret { get; set; }
        public int fone_ret { get; set; }
        public string IE_ret { get; set; }
        public string nro_ret { get; set; }
        public string UF_ret { get; set; }
        public string xBairro_ret { get; set; }
        public string xCpl_ret { get; set; }
        public string xLgr_ret { get; set; }
        public string xMun_ret { get; set; }
        public string xNome_ret { get; set; }
        public string xPais_ret { get; set; }
    }

    public class Total
    {
        public Icmstot ICMStot { get; set; }
        public Issqntot ISSQNtot { get; set; }
        public Rettrib retTrib { get; set; }
    }

    public class Icmstot
    {
        public string vAFRMM_ttlnfe { get; set; }
        public string vBC_ttlnfe { get; set; }
        public string vBCST_ttlnfe { get; set; }
        public string vCOFINS_ttlnfe { get; set; }
        public string vDesc_ttlnfe { get; set; }
        public string vFCP_ttlnfe { get; set; }
        public string vFCPST_ttlnfe { get; set; }
        public string vFCPSTRet_ttlnfe { get; set; }
        public string vFCPUFDest_ttlnfe { get; set; }
        public string vFrete_ttlnfe { get; set; }
        public string vICMS_ttlnfe { get; set; }
        public string vICMSDeson_ttlnfe { get; set; }
        public string vICMSUFDest_ttlnfe { get; set; }
        public string vICMSUFRemet_ttlnfe { get; set; }
        public string vII_ttlnfe { get; set; }
        public string vIPI_ttlnfe { get; set; }
        public string vIPIDevol_ttlnfe { get; set; }
        public string vNF { get; set; }
        public string vOutro { get; set; }
        public string vPIS_ttlnfe { get; set; }
        public string vProd_ttlnfe { get; set; }
        public string vSeg_ttlnfe { get; set; }
        public string vST_ttlnfe { get; set; }
        public string vTotTrib_ttlnfe { get; set; }
    }

    public class Issqntot
    {
        public int cRegTrib { get; set; }
        public string dCompet { get; set; }
        public string vBC_ttlnfe_iss { get; set; }
        public string vCOFINS_servttlnfe { get; set; }
        public string vDeducao_servttlnfe { get; set; }
        public string vDescCond_servttlnfe { get; set; }
        public string vDescIncond_servttlnfe { get; set; }
        public string vISS { get; set; }
        public string vISSRet_servttlnfe { get; set; }
        public string vOutro_servttlnfe { get; set; }
        public string vPIS_servttlnfe { get; set; }
        public string vServ { get; set; }
    }

    public class Rettrib
    {
        public string vBCIRRF { get; set; }
        public string vBCRetPrev { get; set; }
        public string vIRRF { get; set; }
        public string vRetCOFINS_servttlnfe { get; set; }
        public string vRetCSLL { get; set; }
        public string vRetPIS { get; set; }
        public string vRetPrev { get; set; }
    }

    public class Transp
    {
        public string balsa { get; set; }
        public int modFrete { get; set; }
        public Reboque[] reboque { get; set; }
        public Rettransp retTransp { get; set; }
        public Transporta transporta { get; set; }
        public string vagao { get; set; }
        public Veictransp veicTransp { get; set; }
        public object[] vol { get; set; }
    }

    public class Rettransp
    {
        public int CFOP_transp { get; set; }
        public int cMunFG_transp { get; set; }
        public int pICMSRet { get; set; }
        public string vBCRet { get; set; }
        public string vICMSRet { get; set; }
        public string vServ_transp { get; set; }
    }

    public class Transporta
    {
        public string CNPJ_transp { get; set; }
        public string CPF_transp { get; set; }
        public string IE_transp { get; set; }
        public string UF_transp { get; set; }
        public string xEnder { get; set; }
        public string xMun_transp { get; set; }
        public string xNome_transp { get; set; }
    }

    public class Veictransp
    {
        public string placa { get; set; }
        public string RNTC { get; set; }
        public string UF_veictransp { get; set; }
    }

    public class Reboque
    {
        public string placa_rebtransp { get; set; }
        public string RNTC_rebtransp { get; set; }
        public string UF_rebtransp { get; set; }
    }

    public class Det
    {
        public Imposto imposto { get; set; }
        public Impostodevol impostoDevol { get; set; }
        public string infADProd { get; set; }
        public Prod prod { get; set; }
    }

    public class Imposto
    {
        public COFINS COFINS { get; set; }
        public COFINSST COFINSST { get; set; }
        public ICMS ICMS { get; set; }
        public Icmsufdest ICMSUFDest { get; set; }
        public II II { get; set; }
        public IPI IPI { get; set; }
        public ISSQN ISSQN { get; set; }
        public PIS PIS { get; set; }
        public PISST PISST { get; set; }
    }

    public class COFINS
    {
        public string CST_cofins { get; set; }
        public int pCOFINS { get; set; }
        public string qBCProd_cofins { get; set; }
        public string vAliqProd_cofins { get; set; }
        public string vBC_cofins { get; set; }
        public string vCOFINS { get; set; }
    }

    public class COFINSST
    {
        public int pCOFINS_cofins_ST { get; set; }
        public string qBCProd_cofins_ST { get; set; }
        public string vAliqProd_cofins_ST { get; set; }
        public string vBC_cofins_ST { get; set; }
        public string vCOFINS_cofins_ST { get; set; }
    }

    public class ICMS
    {
        public string CST { get; set; }
        public string GerarICMSST { get; set; }
        public string GerarTagStRet { get; set; }
        public string modBC { get; set; }
        public int modBCST { get; set; }
        public int motDesICMS { get; set; }
        public int orig { get; set; }
        public int pBCOp { get; set; }
        public int pCredSN { get; set; }
        public int pDif { get; set; }
        public int pFCP { get; set; }
        public int pFCPST { get; set; }
        public int pFCPSTRet { get; set; }
        public int pICMS { get; set; }
        public int pICMSEfet { get; set; }
        public int pICMSST { get; set; }
        public int pMVAST { get; set; }
        public int pRedBC { get; set; }
        public int pRedBCEfet { get; set; }
        public int pRedBCST { get; set; }
        public int pST { get; set; }
        public string UFST { get; set; }
        public string vBC { get; set; }
        public string vBCEfet { get; set; }
        public string vBCFCP { get; set; }
        public string vBCFCPST { get; set; }
        public string vBCFCPSTRet { get; set; }
        public string vBCST { get; set; }
        public string vBCSTDest { get; set; }
        public string vBCSTRet { get; set; }
        public string vCredICMSSN { get; set; }
        public string vFCP { get; set; }
        public string vFCPST { get; set; }
        public string vFCPSTRet { get; set; }
        public string vICMS_icms { get; set; }
        public string vICMSDeson { get; set; }
        public string vICMSDif { get; set; }
        public string vICMSEfet { get; set; }
        public string vICMSOp { get; set; }
        public string vICMSST_icms { get; set; }
        public string vICMSSTDest_icms { get; set; }
        public string vICMSSTRet { get; set; }
        public string vICMSSubstituto { get; set; }
    }

    public class Icmsufdest
    {
        public int pFCPUFDest { get; set; }
        public int pICMSInter { get; set; }
        public int pICMSInterPart { get; set; }
        public int pICMSUFDest { get; set; }
        public string vBCFCPUFDest { get; set; }
        public string vBCUFDest { get; set; }
        public string vFCPUFDest { get; set; }
        public string vICMSUFDest { get; set; }
        public string vICMSUFRemet { get; set; }
    }

    public class II
    {
        public string vBC_imp { get; set; }
        public string vDespAdu { get; set; }
        public string vII { get; set; }
        public string vIOF { get; set; }
    }

    public class IPI
    {
        public string cEnq { get; set; }
        public string clEnq { get; set; }
        public string CNPJProd { get; set; }
        public string cSelo { get; set; }
        public CSTIPI CSTIPI { get; set; }
        public int qSelo { get; set; }
    }

    public class CSTIPI
    {
        public string CST_IPI { get; set; }
        public int pIPI { get; set; }
        public string qUnid_IPI { get; set; }
        public string vBC_IPI { get; set; }
        public string vIPI { get; set; }
        public string vUnid_IPI { get; set; }
    }

    public class ISSQN
    {
        public string cListServ { get; set; }
        public int cMun_issqn { get; set; }
        public int cMunFg_issqn { get; set; }
        public int cPais_issqn { get; set; }
        public string cServico { get; set; }
        public string cSitTrib { get; set; }
        public int indIncentivo { get; set; }
        public int indISS { get; set; }
        public int indISSRet { get; set; }
        public string nProcesso { get; set; }
        public int vAliq { get; set; }
        public string vBC_issqn { get; set; }
        public string vDeducao { get; set; }
        public string vDescCond { get; set; }
        public string vDescIncond { get; set; }
        public string vISSQN { get; set; }
        public string vISSRet { get; set; }
        public string vOutro_issqn { get; set; }
    }

    public class PIS
    {
        public string CST_pis { get; set; }
        public int pPIS { get; set; }
        public string qBCprod_pis { get; set; }
        public string vAliqProd_pis { get; set; }
        public string vBC_pis { get; set; }
        public string vPIS { get; set; }
    }

    public class PISST
    {
        public int pPIS_ST { get; set; }
        public string qBCprod_pis_ST { get; set; }
        public string vAliqProd_pis_ST { get; set; }
        public string vBC_pis_ST { get; set; }
        public string vPIS_ST { get; set; }
    }

    public class Impostodevol
    {
        public Ipidevol IPIDevol { get; set; }
        public int pDevol { get; set; }
    }

    public class Ipidevol
    {
        public string vIPIDevol { get; set; }
    }

    public class Prod
    {
        public object[] arma { get; set; }
        public string cBenef { get; set; }
        public string cEAN { get; set; }
        public string cEANTrib { get; set; }
        public string CEST { get; set; }
        public int CFOP { get; set; }
        public string CNPJFab { get; set; }
        public Comb comb { get; set; }
        public string cProd { get; set; }
        public object[] detDI { get; set; }
        public object[] detExport { get; set; }
        public int dProd { get; set; }
        public string EXTIPI { get; set; }
        public string indEscala { get; set; }
        public int indTot { get; set; }
        public object[] med { get; set; }
        public string NCM { get; set; }
        public string nFCI { get; set; }
        public string nItemPed { get; set; }
        public string nRECOPI { get; set; }
        public int nTipoItem { get; set; }
        public object[] NVEs { get; set; }
        public string qCOM { get; set; }
        public string qTrib { get; set; }
        public object[] Rastro { get; set; }
        public string uCOM { get; set; }
        public string uTrib { get; set; }
        public string vDesc { get; set; }
        public Veicprod veicProd { get; set; }
        public string vFrete { get; set; }
        public string vOutro_item { get; set; }
        public string vProd { get; set; }
        public string vSeg { get; set; }
        public string vUnCom { get; set; }
        public string vUnTrib { get; set; }
        public string xPed_item { get; set; }
        public string xProd { get; set; }
    }

    public class Comb
    {
        public CIDE CIDE { get; set; }
        public string CODIF { get; set; }
        public int cProdANP { get; set; }
        public string descANP { get; set; }
        public Encerrante Encerrante { get; set; }
        public int pGLP { get; set; }
        public int pGNi { get; set; }
        public int pGNn { get; set; }
        public int pMixGN { get; set; }
        public string qTemp { get; set; }
        public string UFcons { get; set; }
        public string vPart { get; set; }
    }

    public class CIDE
    {
        public string qBCprod { get; set; }
        public string vAliqProd { get; set; }
        public string vCIDE { get; set; }
    }

    public class Encerrante
    {
        public int nBico { get; set; }
        public int nBomba { get; set; }
        public int nTanque { get; set; }
        public int vEncerranteFim { get; set; }
        public int vEncerranteIni { get; set; }
    }

    public class Veicprod
    {
        public int anoFab { get; set; }
        public int anoMod { get; set; }
        public string cCor { get; set; }
        public string cCorDENATRAN { get; set; }
        public string chassi { get; set; }
        public string cilin { get; set; }
        public int cMod { get; set; }
        public string CMT { get; set; }
        public int condVeic { get; set; }
        public string dist { get; set; }
        public int espVeic { get; set; }
        public int lota { get; set; }
        public string nMotor { get; set; }
        public string nSerie { get; set; }
        public string PesoB { get; set; }
        public string PesoL { get; set; }
        public string pot { get; set; }
        public string RENAVAM { get; set; }
        public string tpComb { get; set; }
        public int tpOp { get; set; }
        public string tpPint { get; set; }
        public int tpRest { get; set; }
        public string tpVeic { get; set; }
        public string VIN { get; set; }
        public string xCor { get; set; }
    }

    public class Pag
    {
        public Card card { get; set; }
        public string indPag_pag { get; set; }
        public string tPag { get; set; }
        public string vPag { get; set; }
    }

    public class Card
    {
        public string cAut { get; set; }
        public string CNPJ_card { get; set; }
        public string tBand { get; set; }
        public int tipoIntegracao { get; set; }
    }

}


