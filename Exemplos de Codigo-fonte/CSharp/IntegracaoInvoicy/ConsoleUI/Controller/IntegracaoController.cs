using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using ConsoleUI.View;
using ConsoleUI.Models;
using ConsoleUI.Services;
using System.Windows.Threading;

namespace ConsoleUI.Controller
{
    public class IntegracaoController
    {
        IntegracaoView View { get; set; }
        Source Dados { get; set; }
        User Usuario {get; set; }

        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        bool isAccessOk, isRefreshOk;

        public IntegracaoController()
        {
            this.View = new IntegracaoView();
            this.Dados = new Source();
            this.Usuario = new User()
            {
                Params = new RequestParams()
                {
                    cnpj = "06354976000149",
                    chaveDeAcesso = "eKdz2fcZg9ZMt3DrfF/KSIVoH59Ca6nN",
                    chaveDeParceiro = "YPxRwGxIbpWZtwhuC0m+Wg==",
                    segundosExp = 10
                },
                Token = new UserToken()
            };

            dispatcherTimer.Interval = new TimeSpan(0,0,1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!isAccessOk && !isRefreshOk)
            {
                dispatcherTimer.Stop();
                return;
            }

            var TempoAccessToken = Usuario.Token.accessTokenExpireAt - DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var TempoRefreshToken = Usuario.Token.refreshTokenExpireAt - DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            
            if (TempoAccessToken <= 0 && isAccessOk)
            {
                View.TempoExpirado("AccessToken");
                isAccessOk = false;
            }
            if (TempoRefreshToken <= 0 && isRefreshOk)
            {
                View.TempoExpirado("RefreshToken");
                isRefreshOk = false;
            }
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
                        View.Erro("Opção inválida.");
                        break;
                }
            }

            async Task AutenticarAsync(int opcao)
            {
                var uri = "https://apibrhomolog.invoicy.com.br/oauth2/invoicy";
                string dados = "";
                switch (opcao)
                {
                    case 1:
                        var actualToken = JsonSerializer.Serialize(Usuario.Token, new JsonSerializerOptions() { WriteIndented = true }); ;
                        Console.WriteLine($"Token atual: {actualToken}");
                        break;

                    case 2:
                        uri = $"{uri}/auth";
                        var tokenJWT = JwtTokenCreator.GeraTokenJWT(Usuario.Params); //obtém um token JWT
                        dados = "{\n\t \"token\": \"" + tokenJWT + "\"\n}";

                        var tokenGerado = await Rest.GetAsync(HttpMethod.Post, Usuario, dados, uri, false);

                        try
                        {
                            Usuario.Token = JsonSerializer.Deserialize<UserToken>(tokenGerado);
                            Console.WriteLine($"JWT Token: {tokenJWT}\n");
                            Console.WriteLine($"Token gerado: {tokenGerado}");
                            isAccessOk = true; isRefreshOk = true;
                            dispatcherTimer.Start();
                        }
                        catch
                        {
                            View.Erro(tokenGerado);
                        }
                        break;

                    case 3:
                        uri = $"{uri}/validate";
                        var accessToken = Usuario.Token.accessToken;
                        dados = "{\n\t \"token\": \"" + accessToken + "\"\n}";

                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, Usuario, dados, uri, false));
                        break;

                    case 4:
                        uri = $"{uri}/auth";
                        var refreshToken = Usuario.Token.refreshToken;
                        dados = "{\n\t \"refreshToken\": \"" + refreshToken + "\"\n}";

                        var tokenRenovado = await Rest.GetAsync(HttpMethod.Post, Usuario, dados, uri, false);
                        Usuario.Token = JsonSerializer.Deserialize<UserToken>(tokenRenovado);

                        Console.WriteLine($"Token renovado: {tokenRenovado}");

                        isAccessOk = true; isRefreshOk = true;
                        dispatcherTimer.Start();
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
                        uri = $"{uri}?CNPJ={Usuario.Params.cnpj}";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Get, Usuario, null, uri, true));
                        break;

                    case 2:
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, Usuario, Dados.Empresa["Cadastro"], uri, true));
                        break;

                    case 3:
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Put, Usuario, Dados.Empresa["Editar"], uri, true));
                        break;

                    case 4:
                        uri = $"{uri}?type=licenciamento";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, Usuario, Dados.Empresa["Licenciamento"], uri, true));
                        break;

                    case 5:
                        uri = $"{uri}?ModeloDocumento=nfe&type=consultabilhetagem&tpAmb=2&TipoConsulta=2&Acumulado=&DataInclusaoInicial=2021-02-01&DataInclusaoFinal=2021-02-11&Emissores=06354976000149,09346994000177";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Get, Usuario, null, uri, true));
                        break;

                    case 6:
                        uri = $"{uri}?tpAmb=2&type=consultasefaz&Versao=2&CNPJ_emit=06354976000149&CPF_emit&cUF=43";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Get, Usuario, null, uri, true));
                        break;

                    case 7:
                        uri = $"{uri}?tpAmb=2&type=docnaoencerrado&Versao=3.00&CNPJEmissor=06354976000149&ModeloDocumento=MDFe";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Get, Usuario, null, uri, true));
                        break;
                }
            }

            async Task SerieAsync(int opcao)
            {
                var uri = "https://apibrhomolog.invoicy.com.br/companies/series";
                switch (opcao)
                {
                    case 1:
                        uri = $"{uri}?CNPJEmissor={Usuario.Params.cnpj}&ModeloDocumento={"NFS-e"}"; //  StatusCode: 400, ReasonPhrase: 'Bad Request'
                        uri = "https://apibrhomolog.invoicy.com.br/companies/series?CNPJEmissor=06354976000149&ModeloDocumento=NFS-e"; //  StatusCode: 400, ReasonPhrase: 'Bad Request'
                        uri = "https://apibrhomolog.invoicy.com.br/companies/series";/*{ "Codigo": 606, "Descricao": "Não foi possível processar a operação, verifique os dados enviados e tente novamente." }*/
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Get, Usuario, null, uri, true));
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

                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, Usuario, serieJson, uri, true));
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

                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Put, Usuario, serieAtualizadaJson, uri, true));
                        break;

                    case 4:
                        //  The page you are looking for cannot be displayed because an invalid method (HTTP verb) is being used.
                        //  StatusCode: 405, ReasonPhrease: 'Method Not Allowed'...
                        Series serieDelete = new Series()
                        {
                            CNPJEmissor = "06354976000149",
                            ModeloDocumento = "NF-e",
                            Serie = "667"
                        };
                        var delete = "{\n    \"CNPJEmissor\": \"06354976000149\",\n    \"ModeloDocumento\": \"NFS-e\",\n    \"Serie\": \"A1\"\n}";
                        var serieDeleteJson = JsonSerializer.Serialize(serieDelete, new JsonSerializerOptions() { WriteIndented = true });

                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Delete, Usuario, delete, uri, true));
                        break;
                }
            }

            async Task DocumentosAsync(int opcao, int opcaoTipo)
            {
                var tipoDocumento = 
                    opcaoTipo == 1 ? "NFe" :
                    opcaoTipo == 2 ? "NFCe" :
                    opcaoTipo == 3 ? "MDFe" :
                    opcaoTipo == 4 ? "NFSe" :
                    opcaoTipo == 5 ? "CTe" :
                    opcaoTipo == 6 ? "Sefaz" : "Error"; //{"type":"about:blank","title":""Not found"","status":404,"detail":""}

                var dados = opcaoTipo == 1 ? Dados.NFe : 
                    opcaoTipo == 2 ?
                    Dados.NFCe : opcaoTipo == 3 ?
                    Dados.MDFe : opcaoTipo == 4 ?
                    Dados.NFSe : opcaoTipo == 5 ?
                    Dados.CTe : null;

                var uri = $"https://apibrhomolog.invoicy.com.br/senddocuments";
                var tipoAcao = "";

                switch (opcao)
                {
                    case 1:
                        tipoAcao = "Emissao";
                        uri = $"{uri}/{tipoDocumento.ToLower()}?type={tipoAcao}";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, Usuario, dados["Emissao"], uri, true));
                        break;

                    case 2: // ok mas a resposta é vazia ""
                        tipoAcao = "Consulta";
                        var CnpjEmissor = Usuario.Params.cnpj;
                        var NumeroInicial = 25;
                        var NumeroFinal = 26;
                        var Serie = 245;
                        var Versao = 4.00;
                        var CnpjEmpresa = Usuario.Params.cnpj;
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

                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Get, Usuario, null, uri, true));
                        break;

                    case 3:
                        tipoAcao = "Inutilizacao";
                        uri = $"{uri}/{tipoDocumento.ToLower()}?type={tipoAcao}";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, Usuario, dados["Inutilizacao"], uri, true));
                        break;

                    case 4:
                        tipoAcao = "Descarte";
                        uri = $"{uri}/{tipoDocumento.ToLower()}?type={tipoAcao}";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, Usuario, dados["Descarte"], uri, true));
                        break;

                    case 5:tipoAcao = "Evento";
                        uri = $"{uri}/{tipoDocumento.ToLower()}?type={tipoAcao}";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, Usuario, dados["Cancelamento"], uri, true));
                        break;

                    case 6:
                        tipoAcao = "exportdocuments";
                        uri = $"{uri}/{tipoDocumento.ToLower()}?type={tipoAcao}";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, Usuario, dados["exportdocuments"], uri, true));
                        break;

                    case 7:
                        tipoAcao = "Importacao";
                        uri = $"{uri}/{tipoDocumento.ToLower()}?type={tipoAcao}";
                        Console.WriteLine(await Rest.GetAsync(HttpMethod.Post, Usuario, dados["Importacao"], uri, true));
                        break;
                }
            }

        }
    }
}
