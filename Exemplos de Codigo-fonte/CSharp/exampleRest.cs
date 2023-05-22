using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Security.Policy;

namespace IntegracaoInvoicy.Models
{
    public class ExampleRest
    {
        public static string VerToken(UserToken _user)
        {
            return JsonSerializer.Serialize(_user, new JsonSerializerOptions() { WriteIndented = true });;
        }

        public static async Task<string> GerarToken(string jwtToken)
        {
            var requestContent = "{\n\t \"token\": \"" + jwtToken + "\"\n}";
            var content = new StringContent(requestContent, null, "application/json");
            var uri = "https://apibrhomolog.invoicy.com.br/oauth2/invoicy/auth";

            var httpClient = new HttpClient();
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, uri);
            httpRequest.Content = content;
            var response = await httpClient.SendAsync(httpRequest);
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Verifica se o accessToken é válido
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<string> ValidarToken(UserToken user)
        {
            var accessToken = user.accessToken;
            var requestContent = "{\n\t \"token\": \"" + accessToken + "\"\n}";
            var content = new StringContent(requestContent, null, "application/json");

            var uri = "https://apibrhomolog.invoicy.com.br/oauth2/invoicy/validate";
            var response = await GetAsync(HttpMethod.Post, (content, null), uri);
            return response;
        }


        /// <summary>
        /// Sends refreshToken and gets a new AccessToken
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<(string token, UserToken user)> RenovarToken(UserToken user)
        {
            var refreshToken = user.refreshToken;
            var requestContent = "{\n\t \"refreshToken\": \"" + refreshToken + "\"\n}";
            var content = new StringContent(requestContent, null, "application/json");

            var uri = "https://apibrhomolog.invoicy.com.br/oauth2/invoicy/auth";
            var response = await GetAsync(HttpMethod.Post, (content, null), uri);

            user = JsonSerializer.Deserialize<UserToken>(response);

            return (response, user);
        }

        /// <summary>
        /// Consults a Company Info
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static async Task<string> ConsultarEmpresa(UserToken user, string cnpj)
        {
            StringContent content = null;
            var uri = $"https://apibrhomolog.invoicy.com.br/companies?CNPJ={cnpj}";
            var header = user.accessToken;

            var response = await GetAsync(HttpMethod.Get, (null, header), uri);
            return response;
        }

        public static async Task<string> CadastrarSerie(UserToken user, Series serie)
        {
            var content = new StringContent(JsonSerializer.Serialize<Series>(serie, new JsonSerializerOptions() { WriteIndented = true }), null, "application/json");
            var header = user.accessToken;
            var uri = "https://apibrhomolog.invoicy.com.br/companies/series";

            var response = await GetAsync(HttpMethod.Post, (content, header), uri);
            return response;
        }

        public static async Task<string> EnviarDocumento(UserToken user, string docType)
        {
            var content = new StringContent("[\n    {\n        \"Documento\": {\n            \"ModeloDocumento\": \"NFCe\",\n            \"Versao\": 4,\n            \"ide\": {\n                \"cUF\": 43,\n                \"natOp\": \"Venda no supermercado\",\n                \"mod\": \"65\",\n                \"serie\": \"260\",\n                \"nNF\": 2019,\n                \"dhEmi\": \"2021-02-23T09:20:55\",\n                \"fusoHorario\": \"-03:00\",\n                \"dhSaiEnt\": \"0000-00-00T00:00:00\",\n                \"tpNf\": 1,\n                \"idDest\": 1,\n                \"indFinal\": 1,\n                \"indPres\": 4,\n                \"cMunFg\": 4321808,\n                \"tpImp\": 4,\n                \"tpEmis\": 1,\n                \"tpAmb\": 2,\n                \"xJust\": \"\",\n                \"dhCont\": \"0000-00-00T00:00:00\",\n                \"finNFe\": 1,\n                \"EmailArquivos\": \"email@gmail.com\",\n                \"indIntermed\": 1,\n                \"NFRef\": []\n            },\n            \"infIntermed\": {\n                \"CNPJ_int\": \"99325560000183\",\n                \"idCadIntTran\": \"Fredi\"\n            },\n            \"emit\": {\n                \"CNPJ_emit\": \"06354976000149\",\n                \"CPF_emit\": \"\",\n                \"xNome\": \"EMPRESA TESTE NFe e NFCe\",\n                \"xFant\": \"\",\n                \"IM\": \"\",\n                \"CNAE\": \"\",\n                \"IE\": \"1470049241\",\n                \"IEST\": \"\",\n                \"CRT\": 3,\n                \"enderEmit\": {\n                    \"xLgr\": \"Rua Sen. Salgado filho\",\n                    \"nro\": \"666\",\n                    \"xCpl\": \"\",\n                    \"xBairro\": \"centro\",\n                    \"cMun\": 4321808,\n                    \"xMun\": \"tres de maio\",\n                    \"UF\": \"RS\",\n                    \"CEP\": 98910000,\n                    \"cPais\": 0,\n                    \"xPais\": \"\",\n                    \"fone\": 0,\n                    \"fax\": 0,\n                    \"Email\": \"\"\n                }\n            },\n            \"dest\": {\n                \"CNPJ_dest\": \"\",\n                \"CPF_dest\": \"02370449004\",\n                \"idEstrangeiro\": \"\",\n                \"xNome_dest\": \"NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL\",\n                \"IE_dest\": \"\",\n                \"ISUF\": \"\",\n                \"indIEDest\": 9,\n                \"IM_dest\": \"\",\n                \"enderDest\": {\n                    \"nro_dest\": \"12\",\n                    \"xCpl_dest\": \"CENTRO\",\n                    \"xBairro_dest\": \"Primavera\",\n                    \"xEmail_dest\": \"brunakalschne@migrate.com.br\",\n                    \"xLgr_dest\": \"Rua das Margaridas\",\n                    \"xPais_dest\": \"Brasil\",\n                    \"cMun_dest\": 4317103,\n                    \"xMun_dest\": \"CONTAGEM\",\n                    \"UF_dest\": \"RS\",\n                    \"CEP_dest\": 32145900,\n                    \"cPais_dest\": 1058,\n                    \"fone_dest\": 5543481105\n                }\n            },\n            \"retirada\": {\n                \"CNPJ_ret\": \"\",\n                \"CPF_ret\": \"\",\n                \"xNome_ret\": \"\",\n                \"xLgr_ret\": \"\",\n                \"nro_ret\": \"\",\n                \"xCpl_ret\": \"\",\n                \"xBairro_ret\": \"\",\n                \"xMun_ret\": \"\",\n                \"cMun_ret\": 0,\n                \"UF_ret\": \"\",\n                \"CEP_ret\": 0,\n                \"cPais_ret\": 0,\n                \"xPais_ret\": \"\",\n                \"fone_ret\": 0,\n                \"email_ret\": \"\",\n                \"IE_ret\": \"\"\n            },\n            \"entrega\": {\n                \"CNPJ_entr\": \"\",\n                \"CPF_entr\": \"\",\n                \"xLgr_entr\": \"\",\n                \"nro_entr\": \"\",\n                \"xCpl_entr\": \"\",\n                \"xBairro_entr\": \"\",\n                \"cMun_entr\": 0,\n                \"xMun_entr\": \"\",\n                \"UF_entr\": \"\",\n                \"xNome_entr\": \"\",\n                \"CEP_entr\": 0,\n                \"cPais_entr\": 0,\n                \"xPais_entr\": \"\",\n                \"fone_entr\": 0,\n                \"email_entr\": \"\",\n                \"IE_entr\": \"\"\n            },\n            \"autXML\": [\n                {\n                    \"CNPJ_aut\": \"\",\n                    \"CPF_aut\": \"72345067993\"\n                }\n            ],\n            \"det\": [\n                {\n                    \"infADProd\": \"Informações Adicionais\",\n                    \"prod\": {\n                        \"cProd\": \"1\",\n                        \"cEAN\": \"SEM GTIN\",\n                        \"xProd\": \"NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL\",\n                        \"NCM\": \"39231090\",\n                        \"EXTIPI\": \"\",\n                        \"CFOP\": 5102,\n                        \"uCOM\": \"UN\",\n                        \"qCOM\": \"1.0000\",\n                        \"vUnCom\": \"10.0000000000\",\n                        \"vProd\": \"10.00\",\n                        \"cEANTrib\": \"SEM GTIN\",\n                        \"uTrib\": \"UN\",\n                        \"qTrib\": \"1.0000\",\n                        \"vUnTrib\": \"10.0000000000\",\n                        \"vFrete\": \"0.00\",\n                        \"vSeg\": \"0.00\",\n                        \"vDesc\": \"0.00\",\n                        \"vOutro_item\": \"0.00\",\n                        \"indTot\": 1,\n                        \"nTipoItem\": 0,\n                        \"dProd\": 0,\n                        \"xPed_item\": \"\",\n                        \"nItemPed\": \"\",\n                        \"nFCI\": \"\",\n                        \"nRECOPI\": \"\",\n                        \"CEST\": \"1234567\",\n                        \"cBenef\": \"RS051011\"\n                    },\n                    \"imposto\": {\n                        \"vTotTrib\": \"\",\n                        \"ICMS\": {\n                            \"orig\": 0,\n                            \"CST\": \"40\",\n                            \"modBC\": \"\",\n                            \"vBC\": \"0.00\",\n                            \"pICMS\": 0,\n                            \"vICMS_icms\": \"0.00\",\n                            \"modBCST\": 0,\n                            \"pMVAST\": 0,\n                            \"pRedBCST\": 0,\n                            \"vBCST\": \"0.00\",\n                            \"vBCSTRet\": \"0.00\",\n                            \"pICMSST\": 0,\n                            \"vICMSST_icms\": \"0.00\",\n                            \"vICMSSTRet\": \"0.00\",\n                            \"pRedBC\": 0,\n                            \"motDesICMS\": 0,\n                            \"vICMSDeson\": \"0.00\",\n                            \"vICMSOp\": \"0.00\",\n                            \"pDif\": 0,\n                            \"vICMSDif\": \"0.00\",\n                            \"pBCOp\": 0,\n                            \"UFST\": \"\",\n                            \"vBCSTDest\": \"0.00\",\n                            \"vICMSSTDest_icms\": \"0.00\",\n                            \"pCredSN\": 0,\n                            \"vCredICMSSN\": \"0.00\",\n                            \"pFCP\": 0,\n                            \"vFCP\": \"0.00\",\n                            \"vBCFCP\": \"0.00\",\n                            \"vBCFCPST\": \"0.00\",\n                            \"pFCPST\": 0,\n                            \"vFCPST\": \"0.00\",\n                            \"pST\": 0,\n                            \"vICMSSubstituto\": \"0.00\",\n                            \"vBCFCPSTRet\": \"0.00\",\n                            \"pFCPSTRet\": 0,\n                            \"vFCPSTRet\": \"0.00\",\n                            \"GerarICMSST\": \"\",\n                            \"pRedBCEfet\": 0,\n                            \"vBCEfet\": \"0.00\",\n                            \"pICMSEfet\": 0,\n                            \"vICMSEfet\": \"0.00\"\n                        },\n                        \"IPI\": {\n                            \"CNPJProd\": \"\",\n                            \"cSelo\": \"\",\n                            \"qSelo\": 0,\n                            \"cEnq\": \"\",\n                            \"CSTIPI\": {\n                                \"CST_IPI\": \"\",\n                                \"vBC_IPI\": \"0.00\",\n                                \"qUnid_IPI\": \"0.0000\",\n                                \"vUnid_IPI\": \"0.0000\",\n                                \"pIPI\": 0,\n                                \"vIPI\": \"0.00\"\n                            }\n                        }\n                    }\n                }\n            ],\n            \"total\": {\n                \"ICMStot\": {\n                    \"vBC_ttlnfe\": \"0.00\",\n                    \"vICMS_ttlnfe\": \"0.00\",\n                    \"vICMSDeson_ttlnfe\": \"0.00\",\n                    \"vBCST_ttlnfe\": \"0.00\",\n                    \"vST_ttlnfe\": \"0.00\",\n                    \"vProd_ttlnfe\": \"10.00\",\n                    \"vFrete_ttlnfe\": \"0.00\",\n                    \"vSeg_ttlnfe\": \"0.00\",\n                    \"vDesc_ttlnfe\": \"0.00\",\n                    \"vII_ttlnfe\": \"0.00\",\n                    \"vIPI_ttlnfe\": \"0.00\",\n                    \"vPIS_ttlnfe\": \"0.00\",\n                    \"vCOFINS_ttlnfe\": \"0.00\",\n                    \"vOutro\": \"0.00\",\n                    \"vNF\": \"10.00\",\n                    \"vTotTrib_ttlnfe\": \"0\"\n                }\n            },\n            \"transp\": {\n                \"modFrete\": 2,\n                \"balsa\": \"\",\n                \"vagao\": \"\",\n                \"transporta\": {\n                    \"CNPJ_transp\": \"\",\n                    \"CPF_transp\": \"46118182418\",\n                    \"xNome_transp\": \"Transportador\",\n                    \"IE_transp\": \"\",\n                    \"xEnder\": \"\",\n                    \"xMun_transp\": \"\",\n                    \"UF_transp\": \"RS\"\n                },\n                \"retTransp\": {\n                    \"vServ_transp\": \"0.00\",\n                    \"vBCRet\": \"0.00\",\n                    \"pICMSRet\": 0,\n                    \"vICMSRet\": \"0.00\",\n                    \"CFOP_transp\": 0,\n                    \"cMunFG_transp\": 0\n                },\n                \"veicTransp\": {\n                    \"placa\": \"\",\n                    \"UF_veictransp\": \"\",\n                    \"RNTC\": \"\"\n                },\n                \"reboque\": [],\n                \"vol\": []\n            },\n            \"cobr\": {\n                \"fat\": {\n                    \"nFat\": \"\",\n                    \"vOrig\": \"0.00\",\n                    \"vDesc_cob\": \"0.00\",\n                    \"vLiq\": \"0.00\"\n                },\n                \"dup\": []\n            },\n            \"pag\": [\n                {\n                    \"indPag_pag\": \"\",\n                    \"tPag\": \"16\",\n                    \"vPag\": \"10.00\",\n                    \"card\": {\n                        \"tipoIntegracao\": 0,\n                        \"CNPJ_card\": \"\",\n                        \"tBand\": \"\",\n                        \"cAut\": \"\"\n                    }\n                }\n            ],\n            \"vTroco\": \"0.00\",\n            \"infSuplem\": {\n                \"qrCode\": \"\",\n                \"urlChave\": \"\"\n            },\n            \"RespTecnico\": {\n                \"CNPJ\": \"14185211000150\",\n                \"xContato\": \"Joao Carlos da Cunha Pereira\",\n                \"email\": \"testemigrate@gmail.com\",\n                \"fone\": 35351285,\n                \"idCSRT\": \"12\",\n                \"hashCSRT\": \"v61uDiGY1KWigdgMfHGYi6qilQo=\"\n            }\n        }\n    }\n]", null, "application/json");
            var header = user.accessToken;
            var uri = $"https://apibrhomolog.invoicy.com.br/senddocuments/{docType.ToLower()}?type=Emissao";

            var response = await GetAsync(HttpMethod.Post, (content, header), uri);
            return response;
        }




        public static async Task<string> AtualizarEmpresa()
        {
            await Task.Delay(1000);
            return "AtualizarEmpresa";
        }

        public static async Task<string> ConsultaBilhetagem()
        {
            await Task.Delay(1000);
            return "ConsultaBilhetagem";
        }

        public static async Task<string> ConsultaCNPJSefaz()
        {
            await Task.Delay(1000);
            return "ConsultaCNPJSefaz";
        }

        public static async Task<string> ConsuldaMDFeNaoEncerrados()
        {
            await Task.Delay(1000);
            return "ConsuldaMDFeNaoEncerrados";
        }

        public static async Task<string> CadastrarSerie()
        {
            await Task.Delay(1000);
            return "CadastrarSerie";
        }

        //private static async Task<string> GetAsync(HttpMethod method, StringContent content, string header,  string uri)
        private static async Task<string> GetAsync(HttpMethod method, (StringContent content, string header) content, string uri)
        {
            var httpClient = new HttpClient();
            var httpRequest = new HttpRequestMessage(method, uri);

            if (content.content != null)
            {
                httpRequest.Content = content.content;
            }
            if (content.header != null)
            {
                httpRequest.Headers.Add("Authorization", content.header);
            }

            var httpResponse = await httpClient.SendAsync(httpRequest);
            //response.EnsureSuccessStatusCode();

            return await httpResponse.Content.ReadAsStringAsync();

        }
        //private static async Task<string> GetAsync(HttpMethod method, (StringContent content, (string type,string value) header) content, string uri)
        //{
        //    var httpClient = new HttpClient();
        //    var httpRequest = new HttpRequestMessage(method, uri);

        //    if (content.content != null)
        //    {
        //        httpRequest.Content = content.content;
        //    }

        //    httpRequest.Headers.Add(content.header.type, content.header.value);

        //    var response = await httpClient.SendAsync(httpRequest);
        //    response.EnsureSuccessStatusCode();
        //    return await response.Content.ReadAsStringAsync();
        //}







    }
}


