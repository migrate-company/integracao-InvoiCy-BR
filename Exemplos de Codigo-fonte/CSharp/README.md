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
RequestParams requestParams = new RequestParams(
    string CNPJ, 
    string Chave-de-acesso,
    string Chave-de-parceiro, 
    int TempoExpiracao);
    
string jwtToken = JwtTokenCreator.GeraTokenJWT(requestParams);
```

Onde requestParams (RequestParams.cs) é um objeto contendo as informações cadastrais da empresa e o tempo de expiração do AccessToken (padrão = 120 segundos).

### AccessToken e RefreshToken
Tendo criado o primeiro token JWT, deverá ser enviado para a API de autenticação para obter o refreshToken e accessToken. Foi implementado o código das integrações na classe ExemploRest.cs.

```csharp
var token = await ExemploRest.GerarToken(jwtToken);
userToken = JsonSerializer.Deserialize<UserToken>(token);
```

A string "token" será um JSON contendo o Token de Acesso e o Refresh Token. Essas informações podem ser armazenadas em um objeto userToken (UserToken.cs). 

- O accessToken deverá ser enviado no header “Authorization” em todas as requisições de documentos ou empresa.
- O refreshToken será utilizado para criar um novo accessToken válido quando o mesmo expirar, a cada ~1 hora~. 
- Quando expirar o refreshToken após ~24 horas~, será necessário realizar o mesmo processo descrito acima para obter um novo token válido.

### Integrações API Rest:
No [Exemplo POSTMAN](https://documenter.getpostman.com/view/9193875/SztEanQL?version=latest) pode ser encontrado os comandos para diferentes tipos de requisições. A seguir será apresentado alguns códigos de exemplo. Em breve será disponibilizado um aplicativo desktop com as implementações.

- Validar token: ExemploRest.GerarToken(UserToken _user)
- Renovar token: ExemploRest.RenovarToken(UserToken _user)
- Ver token: ExemploRest.VerToken(UserToken _user)
- Consultar empresa: ExemploRest.Consultar(string cnpj)
- Cadastrar série: ExemploRest.CadastrarSerie(UserToken _user, Series serie)
- Enviar arquivo: ExemploRest.EnviarDocumento(UserToken _user, NFCe nfce)
