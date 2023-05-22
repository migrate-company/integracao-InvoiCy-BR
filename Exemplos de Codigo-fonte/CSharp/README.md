# Integração InvoiCy via API Rest em CSharp

Aqui serão disponibilizados os códigos fontes como exemplo para o desenvolvimento da integração com o InvoiCy via API Rest em C#.
Mais informações podem ser encontradas a seguir:
- [Integração API REST](https://desenvolvedores.migrate.info/2020/06/integracao-via-api-rest-para-emissao-de-documentos/ "Integração API REST")
- [Autenticação API Rest](https://desenvolvedores.migrate.info/2021/06/autenticacao-api-rest/)
- [accessToken e refreshToken](https://desenvolvedores.migrate.info/2020/06/integracao-via-api-rest-para-emissao-de-documentos/#:~:text=accessToken%20e%20refreshToken)
- [downloads](https://desenvolvedores.migrate.info/downloads/)
- [Exemplo POSTMAN](https://documenter.getpostman.com/view/9193875/SztEanQL?version=latest)

### Criação do Token JWT (JwtTokenCreator.cs)
Criar o JWT Token conforme [Autenticação API REST](https://desenvolvedores.migrate.info/2021/06/autenticacao-api-rest/):

```csharp 
string jwtToken = JwtTokenCreator.GeraTokenJWT(requestParams);
```

onde requestParams (RequestParams.cs) é um objeto contendo as informações cadastrais da empresa e o tempo de expiração do AccessToken (padrão = 120 segundos).

```csharp 
RequestParams requestParams = new RequestParams(
    string CNPJ, 
    string Chave-de-acesso,
    string Chave-de-parceiro, 
    int TempoExpiracao);
```

### AccessToken e RefreshToken
Tendo criado o primeiro token JWT, deverá ser enviado para a API de autenticação para obter o refreshToken e accessToken. 

```csharp
var token = await GerarToken(jwtToken);
userToken = JsonSerializer.Deserialize<UserToken>(token);

async Task<string> GerarToken(string jwtToken)
{
    var requestContent = "{\n\t \"token\": \"" + jwtToken + "\"\n}";
    var content = new StringContent(requestContent, null, "application/json");
    var uri = "https://apibrhomolog.invoicy.com.br/oauth2/invoicy/auth";

    var httpClient = new HttpClient();
    var httpRequest = new HttpRequestMessage(HttpMethod.Post, uri);
    httpRequest.Content = content.content;
    var response = await httpClient.SendAsync(httpRequest);
    return await httpResponse.Content.ReadAsStringAsync();
}
```

A string "token" será um JSON contendo o Token de Acesso e o Refresh Token. Essas informações podem ser armazenadas em um objeto userToken (UserToken.cs). 

- O accessToken deverá ser enviado no header “Authorization” em todas as requisições de documentos ou empresa.
- O refreshToken será utilizado para criar um novo accessToken válido quando o mesmo expirar, a cada ~1 hora~. 
- Quando expirar o refreshToken após ~24 horas~, será necessário realizar o mesmo processo descrito acima para obter um novo token válido.

### Integrações API Rest:
No [Exemplo POSTMAN](https://documenter.getpostman.com/view/9193875/SztEanQL?version=latest) pode ser encontrado os comandos para diferentes tipos de requisições. A seguir será apresentado alguns códigos de exemplo. Em breve será disponibilizado um aplicativo desktop com as implementações.

- Validar token:
bla
- Atualizar token:
bla
- Consultar empresa:
bla
- Cadastrar série:
bla
- Enviar arquivo:
bla
