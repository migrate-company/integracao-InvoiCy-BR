using System.Net.Http;
using System.Threading.Tasks;
using ConsoleUI.Models;
using Microsoft.IdentityModel.Tokens;

namespace ConsoleUI.Services
{
    public class Rest
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public static async Task<string> GetAsync(HttpMethod metodo, User user, string dados, string uri, bool hasHeader)
        {
            var header = hasHeader ? user.Token.accessToken : null;
            var content = dados.IsNullOrEmpty() ? null : new StringContent(dados, null, "application/json");

            using (HttpRequestMessage httpRequest = new HttpRequestMessage(metodo, uri))
            {
                if (content != null)
                {
                    httpRequest.Content = content;
                }
                if (header != null)
                {
                    httpRequest.Headers.Add("Authorization", header);
                }
                using (HttpResponseMessage httpResponse = await _httpClient.SendAsync(httpRequest))
                {
                    var resposta = await httpResponse.Content.ReadAsStringAsync();
                    return resposta;
                }
            }
        }
    }
}
