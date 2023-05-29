# 🚀 Integração InvoiCy via API Rest em CSharp 🚀

## Descrição do Projeto
Aplicativo Console no Padrão MVC. O código fonte deste aplicativo pode ser utilizado como base para o desenvolvimento da integração com o InvoiCy via API Rest em C#.

🔗 Mais informações podem ser encontradas a seguir:
- [Integração API REST](https://desenvolvedores.migrate.info/2020/06/integracao-via-api-rest-para-emissao-de-documentos/ "Integração API REST")
- [Autenticação API Rest](https://desenvolvedores.migrate.info/2021/06/autenticacao-api-rest/)
- [accessToken e refreshToken](https://desenvolvedores.migrate.info/2020/06/integracao-via-api-rest-para-emissao-de-documentos/#:~:text=accessToken%20e%20refreshToken)
- [downloads](https://desenvolvedores.migrate.info/downloads/)
- [Exemplo POSTMAN](https://documenter.getpostman.com/view/9193875/SztEanQL?version=latest)

## Token JWT  [<img src="https://jwt.io/img/pic_logo.svg" height="20px"/>](https://jwt.io/)
Criar o JWT Token conforme [Autenticação API REST](https://desenvolvedores.migrate.info/2021/06/autenticacao-api-rest/).
A função que implementa a criação do Token JWT esta no arquivo JwtTokenCreator.cs.

Para implementar deve-se primeiro passar os parâmetros da empresa na classe RequestParams. Por padrão, o tempo de expiração do AcessToken é definido como 120 segundos.

```csharp 
RequestParams requestParams = new RequestParams(
    string CNPJ, 
    string Chave-de-acesso,
    string Chave-de-parceiro, 
    int TempoExpiracao);
    
string jwtToken = JwtTokenCreator.GeraTokenJWT(requestParams);
```

## AccessToken e RefreshToken
Tendo criado o primeiro token JWT, deve-se enviar este token para a API de autenticação para obter o AccessToken e RefreshToken. 

```csharp
var url = "https://apibrhomolog.invoicy.com.br/oauth2/invoicy/auth"
var dados = "{\n\t \"token\": \"" + token + "\"\n}";

var token = await Rest.GetAsync(HttpMethod.Post, user, dados, uri, false);
userToken = JsonSerializer.Deserialize<UserToken>(token);
```
Para simplificar o exemplo a classe Rest (Rest.cs) é responsável pela comunicação com a API.

Onde <i>GetAsync(HttpMethod metodo, User user, string dados, string uri, bool hasHeader)</i>:
- <strong>HttpMethod metodo:</strong> Protocolo HTTP (Post, Put, Get, Delete)
- <strong>User user:</strong> Objeto contendo os objetos RequestParams e UserToken
- <strong>string dados:</strong> o corpo da mensagem (Json)
- <strong>string uri:</strong> endereço url a ser enviado
- <strong>bool hasHeader:</strong> com ou sem header

A string "token" será um JSON contendo o AccessToken e RefreshToken. Essas informações podem ser armazenadas no objeto userToken (UserToken.cs). 

- O accessToken deverá ser enviado no header “Authorization” em todas as requisições de documentos ou empresa.
- O refreshToken será utilizado para criar um novo accessToken válido quando o mesmo expirar, a cada ~1 hora~. 
- Quando expirar o refreshToken após ~24 horas~, será necessário realizar o mesmo processo descrito acima para obter um novo token válido.

## Integrações API Rest:
No Exemplo POSTMAN  [<img src="https://res.cloudinary.com/postman/image/upload/t_team_logo/v1629869194/team/2893aede23f01bfcbd2319326bc96a6ed0524eba759745ed6d73405a3a8b67a8" height="20px" />](https://documenter.getpostman.com/view/9193875/SztEanQL?version=latest) pode ser encontrado os comandos para diferentes tipos de requisições. 

Várias dessas requisições foram implementadas neste aplicativo. Caso queira utilizar arquivos pessoais, por favor edite os arquivos na fonte de dados (Source.cs).

A seguir será apresentado alguns códigos de exemplo.

### Validar token: 
```csharp
uri = $"https://apibrhomolog.invoicy.com.br/oauth2/invoicy/validate";
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

### Enviar arquivo (nfe):
```csharp
uri = "https://apibrhomolog.invoicy.com.br/senddocuments/nfe?type=Emissao";
dados = Dados.NFe["Emissao"]; //Arquivo NFe a ser enviado em formato Json
var response = await Rest.GetAsync(HttpMethod.Post, user, dados, uri, true);
```

### Descartar arquivo (nfe):
```csharp
uri = "https://apibrhomolog.invoicy.com.br/senddocuments/nfe?type=Descarte";
dados = nfeJson; //Arquivo de solicitação de descarte em formato JSON
var response = await Rest.GetAsync(HttpMethod.Post, user, dados, uri, false);
```
