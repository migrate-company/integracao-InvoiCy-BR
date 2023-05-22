# Integração InvoiCy via API Rest em CSharp

Aqui serão disponibilizados os códigos fontes como exemplo para o desenvolvimento da integração com o InvoiCy via API Rest em C#.
Mais informações podem ser encontradas a seguir:
- [Integração API REST](https://desenvolvedores.migrate.info/2020/06/integracao-via-api-rest-para-emissao-de-documentos/ "Integração API REST")
- [Autenticação API Rest](https://desenvolvedores.migrate.info/2021/06/autenticacao-api-rest/)
- [accessToken e refreshToken](https://desenvolvedores.migrate.info/2020/06/integracao-via-api-rest-para-emissao-de-documentos/#:~:text=accessToken%20e%20refreshToken)
- [downloads](https://desenvolvedores.migrate.info/downloads/)

## Criação do Token JWT (JwtTokenCreator.cs)

```csharp 
string token = JwtTokenCreator.GeraTokenJWT(requestParams);
```
onde requestParams (RequestParams.cs) é um objeto contendo as informações cadastrais da empresa e o tempo de expiração do AccessToken (padrão = 120 segundos).

```csharp 
RequestParams requestParams = new RequestParams(
    string CNPJ, 
    string Chave-de-acesso,
    string Chave-de-parceiro, 
    int TempoExpiracao);
```
