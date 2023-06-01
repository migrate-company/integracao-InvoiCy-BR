using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using ConsoleUI.View;
using ConsoleUI.Models;
using ConsoleUI.Services;
using System.Timers;
using ConsoleUI.Models.Documentos;

namespace ConsoleUI.Controller
{
    public class IntegracaoController
    {
        IntegracaoView View { get; set; }
        Source Fonte { get; set; }
        User Usuario {get; set; }

        static Timer _timer = new Timer();

        public IntegracaoController()
        {
            View = new IntegracaoView();
            Fonte = new Source();
            Usuario = new User()
            {
                Params = new RequestParams()
                {
                    cnpj = "06354976000149",
                    chaveDeAcesso = "eKdz2fcZg9ZMt3DrfF/KSIVoH59Ca6nN",
                    chaveDeParceiro = "YPxRwGxIbpWZtwhuC0m+Wg==",
                    jwtTokenExp = 120
                },
                Token = new UserToken()
            };

            _timer.Interval = 1000;
            _timer.Elapsed += Timer_Tick;
            _timer.Enabled = false;

        }

        private async void Timer_Tick(object sender, ElapsedEventArgs e)
        {

            var TempoAccessToken = Usuario.Token.accessTokenExpireAt - DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var TempoRefreshToken = Usuario.Token.refreshTokenExpireAt - DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            if (TempoAccessToken <= 0)
            {
                View.Message($"AccessToken EXPIRADO!");
                await AutenticarAsync(4);
            }
            if (TempoRefreshToken <= 0)
            {
                View.Message($"RefreshToken EXPIRADO!");
                await   AutenticarAsync(2);
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
                        View.Message("Opção inválida.");
                        break;
                }
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
                    View.Message($"Token atual: {actualToken}");
                    break;

                case 2:
                    uri = $"{uri}/auth";
                    var jwtToken = JwtTokenCreator.GeraTokenJWT(Usuario.Params); //obtém um token JWT
                    View.Message($"JWT Token: {jwtToken}\n");

                    dados = "{\n\t \"token\": \"" + jwtToken + "\"\n}";
                    var tokenGerado = await Rest.GetAsync(HttpMethod.Post, Usuario, dados, uri, false);

                    if (!tokenGerado.Contains("Erro: "))
                    {
                        Usuario.Token = JsonSerializer.Deserialize<UserToken>(tokenGerado);
                        View.Message($"Token gerado: {tokenGerado}");

                        _timer.Enabled = true;
                        break;
                    }

                    View.Message($"Erro: {tokenGerado}");
                    break;

                case 3:
                    uri = $"{uri}/validate";
                    var accessToken = Usuario.Token.accessToken;
                    dados = "{\n\t \"token\": \"" + accessToken + "\"\n}";

                    View.Message(await Rest.GetAsync(HttpMethod.Post, Usuario, dados, uri, false));
                    break;

                case 4:
                    uri = $"{uri}/auth";
                    var refreshToken = Usuario.Token.refreshToken;
                    dados = "{\n\t \"refreshToken\": \"" + refreshToken + "\"\n}";

                    var tokenRenovado = await Rest.GetAsync(HttpMethod.Post, Usuario, dados, uri, false);
                    Usuario.Token = JsonSerializer.Deserialize<UserToken>(tokenRenovado);

                    View.Message($"Token renovado: {tokenRenovado}");

                    _timer.Enabled = true;
                    break;

                default:
                    View.Message("Opção inválida");
                    break;
            }
        }

        async Task SerieAsync(int opcao)
        {
            var uri = "https://apibrhomolog.invoicy.com.br/companies/series";
            switch (opcao)
            {
                case 1:
                    uri = new Series()
                    {
                        CNPJEmissor = "06354976000149",
                        ModeloDocumento = "NF-e",
                        Serie = "667",
                        UltimoNumero = 0,
                        SerieProduto = "S"
                    }.GetLink();
                    
                    View.Message(await Rest.GetAsync(HttpMethod.Get, Usuario, null, uri, true));
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
                    View.Message(await Rest.GetAsync(HttpMethod.Post, Usuario, serieJson, uri, true));
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

                    View.Message(await Rest.GetAsync(HttpMethod.Put, Usuario, serieAtualizadaJson, uri, true));

                    break;

                case 4:
                    //  The page you are looking for cannot be displayed because an invalid method (HTTP verb) is being used.
                    //  StatusCode: 405, ReasonPhrease: 'Method Not Allowed'... 
                    //  Same as POSTMAN
                    Series serieDelete = new Series()
                    {
                        CNPJEmissor = "06354976000149",
                        ModeloDocumento = "NF-e",
                        Serie = "667"
                    };
                    var serieDeleteJson = JsonSerializer.Serialize(serieDelete, new JsonSerializerOptions() { WriteIndented = true });

                    View.Message(await Rest.GetAsync(HttpMethod.Delete, Usuario, serieDeleteJson, uri, true));
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
                    View.Message(await Rest.GetAsync(HttpMethod.Get, Usuario, null, uri, true));
                    break;

                case 2:
                    //await Deserialize<Empresa>(jsonString);

                    View.Message(await Rest.GetAsync(HttpMethod.Post, Usuario, Fonte.Empresa["Cadastro"], uri, true));
                    break;

                case 3:
                    View.Message(await Rest.GetAsync(HttpMethod.Put, Usuario, Fonte.Empresa["Editar"], uri, true));
                    break;

                case 4: //[{"Codigo":173,"Descricao":"Chave de comunicação inválida."}]

                    uri = $"{uri}?type=licenciamento";
                    View.Message(await Rest.GetAsync(HttpMethod.Post, Usuario, Fonte.Empresa["Licenciamento"], uri, true));
                    break;

                case 5:
                    uri = $"{uri}?ModeloDocumento=nfe&type=consultabilhetagem&tpAmb=2&TipoConsulta=2&Acumulado=&DataInclusaoInicial=2021-02-01&DataInclusaoFinal=2021-02-11&Emissores=06354976000149,09346994000177";
                    View.Message(await Rest.GetAsync(HttpMethod.Get, Usuario, null, uri, true));
                    break;

                case 6:
                    uri = $"{uri}?tpAmb=2&type=consultasefaz&Versao=2&CNPJ_emit=06354976000149&CPF_emit&cUF=43";
                    View.Message(await Rest.GetAsync(HttpMethod.Get, Usuario, null, uri, true));
                    break;

                case 7:
                    uri = $"{uri}?tpAmb=2&type=docnaoencerrado&Versao=3.00&CNPJEmissor=06354976000149&ModeloDocumento=MDFe";
                    View.Message(await Rest.GetAsync(HttpMethod.Get, Usuario, null, uri, true));
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

            var tipoAcao =
                opcao == 1 ? "Emissao" :
                opcao == 2 ? "Consulta" :
                opcao == 3 ? "Inutilizacao" :
                opcao == 4 ? "Descarte" :
                opcao == 5 ? "Evento" :
                opcao == 6 ? "exportdocuments" :
                opcao == 7 ? "Importacao" : null;

            var dados = Fonte.Dados[tipoDocumento][tipoAcao];

            var uri = $"https://apibrhomolog.invoicy.com.br/senddocuments";
            uri = $"{uri}/{tipoDocumento.ToLower()}?type={tipoAcao}";

            switch (opcao)
            {
                case 1:
                    View.Message(await Rest.GetAsync(HttpMethod.Post, Usuario, dados, uri, true));
                    break;

                case 2:
                    uri = new ConsultaDocumento(tipoDocumento, tipoAcao, Usuario.Params.cnpj, 25, 26, 245, Usuario.Params.cnpj, 2).GetLink();
                    View.Message(await Rest.GetAsync(HttpMethod.Get, Usuario, null, uri, true));
                    break;

                case 3:
                    View.Message(await Rest.GetAsync(HttpMethod.Post, Usuario, dados, uri, true));
                    break;

                case 4:
                    dados = JsonSerializer.Serialize(new Descarte
                    {
                        ModeloDocumento = tipoDocumento,
                        tpAmb = 2,
                        CNPJ_emit = "06354976000149",
                        Numero = 04823096,
                        Serie = "251"
                    });

                    View.Message(await Rest.GetAsync(HttpMethod.Post, Usuario, dados, uri, true));
                    break;

                case 5:
                    View.Message(await Rest.GetAsync(HttpMethod.Post, Usuario, dados, uri, true));
                    break;

                case 6:
                    View.Message(await Rest.GetAsync(HttpMethod.Post, Usuario, dados, uri, true));
                    break;

                case 7:
                    View.Message(await Rest.GetAsync(HttpMethod.Post, Usuario, dados, uri, true));
                    break;
            }

        }

        //T Deserialize<T>(string value)
        //{
        //    if (value[0] == '[')
        //    {
        //        value.TrimStart('[').TrimEnd(']');
        //    }
        //    return JsonSerializer.Deserialize<T>(value, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        //}

        //string Serialize<T>(string value)
        //{
        //    return JsonSerializer.Serialize(value);
        //}
    }
}
