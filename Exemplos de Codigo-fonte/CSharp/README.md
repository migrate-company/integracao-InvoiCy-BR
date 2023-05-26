# Integração InvoiCy via API Rest em CSharp

Aqui são disponibilizados códigos fontes como exemplo para o desenvolvimento da integração com o InvoiCy via API Rest em C#.
Mais informações podem ser encontradas a seguir:
- [Integração API REST](https://desenvolvedores.migrate.info/2020/06/integracao-via-api-rest-para-emissao-de-documentos/ "Integração API REST")
- [Autenticação API Rest](https://desenvolvedores.migrate.info/2021/06/autenticacao-api-rest/)
- [accessToken e refreshToken](https://desenvolvedores.migrate.info/2020/06/integracao-via-api-rest-para-emissao-de-documentos/#:~:text=accessToken%20e%20refreshToken)
- [downloads](https://desenvolvedores.migrate.info/downloads/)
- [Exemplo POSTMAN](https://documenter.getpostman.com/view/9193875/SztEanQL?version=latest)

## Criação do Token JWT (JwtTokenCreator.cs)
Criar o JWT Token conforme [Autenticação API REST](https://desenvolvedores.migrate.info/2021/06/autenticacao-api-rest/):

```csharp 
RequestParams requestParams = new RequestParams(
    string CNPJ, 
    string Chave-de-acesso,
    string Chave-de-parceiro, 
    int TempoExpiracao);
    
string jwtToken = JwtTokenCreator.GeraTokenJWT(requestParams);
```

Onde requestParams (RequestParams.cs) é um objeto contendo as informações cadastrais da empresa e o tempo de expiração do AccessToken (padrão = 120 segundos).

## AccessToken e RefreshToken
Tendo criado o primeiro token JWT, deve-se enviar este token para a API de autenticação para obter o AccessToken e RefreshToken. Para simplificar o exemplo a classe Rest (Rest.cs) é responsável pela comunicação com a API.

```csharp
var url = "https://apibrhomolog.invoicy.com.br/oauth2/invoicy/auth"
var dados = "{\n\t \"token\": \"" + token + "\"\n}";

var token = await Rest.GetAsync(HttpMethod.Post, user, dados, uri, false);
userToken = JsonSerializer.Deserialize<UserToken>(token);
```

Onde GetAsync
	- HttpMethod metodo: Protocolo HTTP (Post, Put, Get, Delete)
	- User user: Objeto contendo os objetos RequestParams e UserToken
	- string dados: o corpo da mensagem (Json)
	- string uri: endereço url a ser enviado
	- bool hasHeader: com ou sem header

A string "token" será um JSON contendo o Token de Acesso e o Refresh Token. Essas informações podem ser armazenadas no objeto userToken (UserToken.cs). 

- O accessToken deverá ser enviado no header “Authorization” em todas as requisições de documentos ou empresa.
- O refreshToken será utilizado para criar um novo accessToken válido quando o mesmo expirar, a cada ~1 hora~. 
- Quando expirar o refreshToken após ~24 horas~, será necessário realizar o mesmo processo descrito acima para obter um novo token válido.

## Integrações API Rest:
No [Exemplo POSTMAN](https://documenter.getpostman.com/view/9193875/SztEanQL?version=latest) pode ser encontrado os comandos para diferentes tipos de requisições. A seguir será apresentado alguns códigos de exemplo.

### Validar token: 
```csharp
uri = $"https://apibrhomolog.invoicy.com.br/oauth2/invoicy";
var accessToken = user.Token.accessToken;
dados = "{\n\t \"token\": \"" + accessToken + "\"\n}";
var response = await Rest.GetAsync(HttpMethod.Post, user, dados, uri, false);
```
### Renovar token:  
```csharp
uri = "https://apibrhomolog.invoicy.com.br/oauth2/invoicy/auth";
var refreshToken = user.Token.refreshToken;
dados = "{\n\t \"refreshToken\": \"" + refreshToken + "\"\n}";
var tokenRenovado = await Rest.GetAsync(HttpMethod.Post, user, dados, uri, false);
```
### Cadastrar série: 
```csharp
uri = "https://apibrhomolog.invoicy.com.br/oauth2/invoicy/auth";
var refreshToken = user.Token.refreshToken;
dados = "{\n\t \"refreshToken\": \"" + refreshToken + "\"\n}";
var tokenRenovado = await Rest.GetAsync(HttpMethod.Post, user, dados, uri, false);
```
### Enviar arquivo (nfe):
```csharp
uri = "https://apibrhomolog.invoicy.com.br/companies/series";
Series serie = new Series()
{
	CNPJEmissor = "06354976000149",
	ModeloDocumento = "NF-e",
	Serie = "667",
	UltimoNumero = 0,
	SerieProduto = "S"
};
var serieJson = JsonSerializer.Serialize(serie, new JsonSerializerOptions() { WriteIndented = true });
var response = await Rest.GetAsync(HttpMethod.Post, user, serieJson, uri, true);
```
### Descartar arquivo (nfe):
```csharp
uri = "https://apibrhomolog.invoicy.com.br/senddocuments/nfe?type=Descarte";
dados = nfeJson; //Arquivo de solicitação de descarte em formato JSON
var response = await Rest.GetAsync(HttpMethod.Post, user, dados, uri, false);
```
