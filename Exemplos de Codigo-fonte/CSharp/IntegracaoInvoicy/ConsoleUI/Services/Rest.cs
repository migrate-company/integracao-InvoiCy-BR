using System;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleUI.Models;
using Microsoft.IdentityModel.Tokens;
using static System.Net.WebRequestMethods;

namespace ConsoleUI.Services
{
    /// <summary>
    /// Classe que executa requisição do REST API
    /// </summary>
    public class Rest
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public static async Task<string> GetAsync(HttpMethod metodo, User user, string dados, string uri, bool hasHeader)
        {
            var header = hasHeader ? user.Token.accessToken : null;
            var content = dados.IsNullOrEmpty() ? null : new StringContent(dados, null, "application/json");

            using (HttpRequestMessage httpRequest = new HttpRequestMessage(metodo, uri))
            {
                httpRequest.Content = content ?? null;

                if (header != null)
                {
                    httpRequest.Headers.Add("Authorization", header);
                }
                try
                {
                    using (HttpResponseMessage httpResponse = await _httpClient.SendAsync(httpRequest))
                    {
                        try
                        {
                            var resposta = await httpResponse.Content.ReadAsStringAsync();
                            httpRequest.Dispose();
                            httpResponse.Dispose();
                            return resposta;
                        }
                        //Falha na requisição
                        catch (HttpRequestException httpEx)
                        {
                            return $"Erro: {httpEx.Message}\n{httpEx.InnerException.Message}";
                        }
                    }
                }
                //Falha na requisição-comunicação
                catch (HttpRequestException httpEx)
                {
                    return $"Erro: {httpEx.Message}\n{httpEx.InnerException.Message}";
                }
            }
        }
    }
}
