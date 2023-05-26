using ConsoleUI.View;
using ConsoleUI.Models;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using ConsoleUI.Services;

namespace ConsoleUI.Controller
{
    public class IntegracaoController
    {
        IntegracaoView View { get; set; }
        Source Dados { get; set; }
        User user {get; set; }

        public IntegracaoController()
        {
            this.View = new IntegracaoView();
            this.Dados = new Source();
            this.user = new User()
            {
                Params = new RequestParams()
                {
                    cnpj = "06354976000149",
                    chaveDeAcesso = "eKdz2fcZg9ZMt3DrfF/KSIVoH59Ca6nN",
                    chaveDeParceiro = "YPxRwGxIbpWZtwhuC0m+Wg==",
                    segundosExp = 120
                },
                Token = new UserToken()
            };
        }

        public async Task RunAsync()
        {
            View.Inicio();

            bool isAlive = true;
            while (isAlive)
            {
                var option = View.MenuInicial();

                switch(option)
                {
                    case 1:
                        var opcaoAutenticacao = View.MenuAutenticacao();
                        await AutenticarAsync(opcaoAutenticacao);
                        break;

                    case 2:
                        var opcaoEmpresa = View.MenuEmpresa();
                        await EmpresaAsync(opcaoEmpresa);
                        break;

                    case 3:
                        var opcaoSerie = View.MenuSerie();
                        await SerieAsync(opcaoSerie);
                        break;
                    case 4:
                        var opcaoDocumentos = View.MenuDocumentos();
                        var opcaoTipoDoc = View.MenuTipoDocumentos();
                        await DocumentosAsync(opcaoDocumentos, opcaoTipoDoc);
                        break;

                    default:
                        View.Erro();
                        break;
                }
            }

            async Task AutenticarAsync(int opcao)
            {
                var uri = "https://apibrhomolog.invoicy.com.br/oauth2/invoicy";
                string token = "";
                string dados = "";
                switch (opcao)
                {
                    case 1:
                        var actualToken = JsonSerializer.Serialize(user.Token, new JsonSerializerOptions() { WriteIndented = true }); ;
                        Console.WriteLine($"Token atual: {actualToken}");
                        break;

                    case 2:
                        uri = $"{uri}/auth";
                        token = JwtTokenCreator.GeraTokenJWT(user.Params); //obtém um token JWT
                        dados = "{\n\t \"token\": \"" + token + "\"\n}";

                        var tokenGerado = await Rest.GetAsync(HttpMethod.Post, user, dados, uri, false);
                        user.Token = JsonSerializer.Deserialize<UserToken>(tokenGerado);

                        Console.WriteLine($"JWT Token: {token}");
                        Console.WriteLine($"Token gerado: {tokenGerado}");
                        break;

                    case 3:
                        uri = $"{uri}/validate";
                        var accessToken = user.Token.accessToken;
                        dados = "{\n\t \"token\": \"" + accessToken + "\"\n}";

                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, user, dados, uri, false));
                        break;

                    case 4:
                        uri = $"{uri}/auth";
                        var refreshToken = user.Token.refreshToken;
                        dados = "{\n\t \"refreshToken\": \"" + refreshToken + "\"\n}";

                        var tokenRenovado = await Rest.GetAsync(HttpMethod.Post, user, dados, uri, false);
                        user.Token = JsonSerializer.Deserialize<UserToken>(tokenRenovado);

                        Console.WriteLine($"Token renovado: {tokenRenovado}");
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }

            async Task EmpresaAsync(int opcao)
            {
                var uri = $"https://apibrhomolog.invoicy.com.br/companies";
                switch (opcao)
                {
                    case 1:
                        uri = $"{uri}?CNPJ={user.Params.cnpj}";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Get, user, null, uri, true));
                        break;

                    case 2:
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, user, Dados.Empresa["Cadastro"], uri, true));
                        break;

                    case 3:
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Put, user, Dados.Empresa["Editar"], uri, true));
                        break;

                    case 4:
                        uri = $"{uri}?type=licenciamento";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Put, user, Dados.Empresa["Licenciamento"], uri, true));
                        break;
                }
            }

            async Task SerieAsync(int opcao)
            {
                var uri = "https://apibrhomolog.invoicy.com.br/companies/series";
                switch (opcao)
                {
                    case 1: //  StatusCode: 400, ReasonPhrase: 'Bad Request'
                        uri = $"{uri}?CNPJEmissor={user.Params.cnpj}&ModeloDocumento={"NFS-e"}";
                        uri = "https://apibrhomolog.invoicy.com.br/companies/series?CNPJEmissor=06354976000149&ModeloDocumento=NFS-e";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Get, user, null, uri, true));
                        break;

                    case 2:
                        Series serie = new Series()
                        {
                            CNPJEmissor = "06354976000149",
                            ModeloDocumento = "NF-e",
                            Serie = "667",
                            UltimoNumero = 0,
                            SerieProduto = "S"
                        };
                        var serieJson = JsonSerializer.Serialize(serie, new JsonSerializerOptions() { WriteIndented = true });

                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, user, serieJson, uri, true));
                        break;

                    case 3:
                        Series serieAtualizada = new Series()
                        {
                            CNPJEmissor = "06354976000149",
                            ModeloDocumento = "NFS-e",
                            Serie = "A1",
                            UltimoNumero = 2,
                            SerieProduto = "S"
                        };

                        var serieAtualizadaJson = JsonSerializer.Serialize(serieAtualizada, new JsonSerializerOptions() { WriteIndented = true });

                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Put, user, serieAtualizadaJson, uri, true));
                        break;

                    case 4:
                        //  The page you are looking for cannot be displayed because an invalid method (HTTP verb) is being used.
                        //  StatusCode: 405, ReasonPhrease: 'Method Not Allowed'...
                        Series serieDelete = new Series()
                        {
                            CNPJEmissor = "06354976000149",
                            ModeloDocumento = "NFS-e",
                            Serie = "A1"
                        };
                        var serieDeleteJson = JsonSerializer.Serialize(serieDelete, new JsonSerializerOptions() { WriteIndented = true });

                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Delete, user, serieDeleteJson, uri, true));
                        break;
                }
            }

            async Task DocumentosAsync(int opcao, int opcaoTipo)
            {
                var tipoDocumento = opcaoTipo == 1 ? "NFe" :
                    opcaoTipo == 2 ? "NFCe" :
                    opcaoTipo == 3 ? "MDFe" :
                    opcaoTipo == 4 ? "NFSe" :
                    opcaoTipo == 5 ? "CTe" :
                    opcaoTipo == 6 ? "Sefaz" : "Error"; //{"type":"about:blank","title":""Not found"","status":404,"detail":""}

                var uri = $"https://apibrhomolog.invoicy.com.br/senddocuments";
                var tipoAcao = "";

                switch (opcao)
                {
                    case 1:
                        tipoAcao = "Emissao";
                        uri = $"{uri}/{tipoDocumento.ToLower()}?type={tipoAcao}";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, user, Dados.NFe["Emissao"], uri, true));
                        break;

                    case 2: // ok mas a resposta é vazia ""
                        tipoAcao = "Consulta";
                        var CnpjEmissor = user.Params.cnpj;
                        var NumeroInicial = 25;
                        var NumeroFinal = 26;
                        var Serie = 245;
                        var Versao = 4.00;
                        var CnpjEmpresa = user.Params.cnpj;
                        var tpAmb = 2;
                        var dhUF = "";
                        var ChaveAcesso = "";
                        var DataEmissaoInicial = "";
                        var DataEmissaoFinal = "";
                        var DataInclusaoFinal = "";
                        var DataInclusaoInicial = "";
                        var StatusDocumento = 2;
                        var EmitidoRecebido = "E";
                        var ParmTipoImpressao = "N";
                        var DocumentosResumo = "N";
                        var ParmAutorizadoDownload = "N";
                        var ParmXMLLink = "S";
                        var ParmXMLCompleto = "N";
                        var ParmPDFBase64 = "N";
                        var ParmPDFLink = "S";
                        var ParmEventos = "N";
                        var ParmSituacao = "S";
                        uri = $"{uri}/{tipoDocumento.ToLower()}?type={tipoAcao}&" +
                            $"CnpjEmissor={CnpjEmissor}&" +
                            $"NumeroInicial={NumeroInicial}&" +
                            $"NumeroFinal={NumeroFinal}&" +
                            $"Serie={Serie}&" +
                            $"Versao={Versao}&" +
                            $"CnpjEmpresa={CnpjEmpresa}&" +
                            $"tpAmb={tpAmb}&" +
                            $"dhUF={dhUF}&" +
                            $"ChaveAcesso={ChaveAcesso}&" +
                            $"DataEmissaoInicial={DataEmissaoInicial}&" +
                            $"DataEmissaoFinal={DataEmissaoFinal}&" +
                            $"DataInclusaoFinal={DataInclusaoFinal}&" +
                            $"DataInclusaoInicial={DataInclusaoInicial}&" +
                            $"StatusDocumento={StatusDocumento}&" +
                            $"EmitidoRecebido={EmitidoRecebido}&" +
                            $"ParmTipoImpressao={ParmTipoImpressao}&" +
                            $"DocumentosResumo={DocumentosResumo}&" +
                            $"ParmAutorizadoDownload={ParmAutorizadoDownload}&" +
                            $"ParmXMLLink={ParmXMLLink}&" +
                            $"ParmXMLCompleto={ParmXMLCompleto}&" +
                            $"ParmPDFBase64={ParmPDFBase64}&" +
                            $"ParmPDFLink={ParmPDFLink}&" +
                            $"ParmEventos={ParmEventos}&" +
                            $"ParmSituacao={ParmSituacao}";

                        uri = "https://apibrhomolog.invoicy.com.br/senddocuments/nfce?type=Consulta&CnpjEmissor=06354976000149&NumeroInicial=25&NumeroFinal=26&Serie=245&Versao=4.00&CnpjEmpresa=06354976000149&tpAmb=2&ParmPDFBase64=N&ParmPDFLink=S&ParmEventos=N&ParmSituacao=S";

                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Get, user, null, uri, true));
                        break;

                    case 3:
                        tipoAcao = "Inutilizacao";
                        uri = $"{uri}/{tipoDocumento.ToLower()}?type={tipoAcao}";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, user, Dados.NFe["Inutilizacao"], uri, true));
                        break;

                    case 4:
                        tipoAcao = "Descarte";
                        uri = $"{uri}/{tipoDocumento.ToLower()}?type={tipoAcao}";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, user, Dados.NFe["Descarte"], uri, true));
                        break;

                    case 5:
                        tipoAcao = "Evento";
                        uri = $"{uri}/{tipoDocumento.ToLower()}?type={tipoAcao}";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, user, Dados.NFe["Evento"], uri, true));
                        break;

                    case 6:
                        tipoAcao = "exportdocuments";
                        uri = $"{uri}/{tipoDocumento.ToLower()}?type={tipoAcao}";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, user, Dados.NFe["exportdocuments"], uri, true));
                        break;

                    case 7:
                        tipoAcao = "Importacao";
                        uri = $"{uri}/{tipoDocumento.ToLower()}?type={tipoAcao}";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, user, Dados.NFe["Importacao"], uri, true));
                        break;
                }
            }

        }
    }
}
