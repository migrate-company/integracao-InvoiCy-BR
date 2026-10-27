# Autenticação

A API usa dois tokens:

1. **Token de parceiro (JWT)** - gerado pelo cliente a cada troca, válido por no máximo 120 s:
   - header: `{"alg": "HS256", "typ": "JWT"}`
   - payload: `{"iat": <agora, Unix time>, "exp": <iat + 120>, "sub": "<chave de parceiro>"}`
   - assinatura: HMAC-SHA256 de `base64url(header) + "." + base64url(payload)`, com a chave de acesso como segredo (JSON sem espaços).
2. **accessToken** - devolvido por `POST {baseUrl}/API/JWT/Auth` com `{"Token": "<JWT>"}`; vai no header `Authorization: Bearer <accessToken>` das demais chamadas.

A chave de parceiro identifica o parceiro e a base de dados: não há identificação de base na URL nem no corpo. Nesta coleção o script da coleção faz os dois passos sozinho; a requisição abaixo serve para conferir as credenciais.

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Exemplos/JSON/jwt-header.json](Exemplos/JSON/jwt-header.json) | header do JWT |
| [Exemplos/JSON/jwt-payload.json](Exemplos/JSON/jwt-payload.json) | payload do JWT |
| [Exemplos/JSON/auth-requisicao.json](Exemplos/JSON/auth-requisicao.json) | corpo do POST /API/JWT/Auth |
| [Exemplos/JSON/auth-retorno-200.json](Exemplos/JSON/auth-retorno-200.json) | retorno com o accessToken |
