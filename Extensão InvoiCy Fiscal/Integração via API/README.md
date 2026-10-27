# Integração com a API Migrate Fiscal

A API Migrate Fiscal recebe os dados que alimentam a escrituração fiscal (EFD ICMS/IPI e EFD-Contribuições): cadastros, documentos fiscais, ajustes da apuração e os registros dos blocos F, H, I, K e 1.

Todas as chamadas usam HTTPS e JSON (UTF-8). Cada endpoint tem, no repositório de integração (GitHub), o layout de/para em XLSX (campo do JSON ↔ registro e campo da EFD) e os exemplos de requisição e retorno em JSON.

## Como começar

1. Solicite o endereço da API (`baseUrl`), a **chave de parceiro** e a **chave de acesso**.
2. Gere o token de parceiro (JWT) e troque-o por um `accessToken` (pasta **Autenticação**).
3. Envie o `accessToken` no header `Authorization: Bearer <accessToken>` de cada chamada.

## Variáveis do ambiente (Postman)

| Variável | Conteúdo |
|---|---|
| `baseUrl` | endereço da API, sem `/` no fim |
| `chaveParceiro` | chave de parceiro (vai no `sub` do JWT) |
| `chaveAcesso` | chave de acesso do parceiro (assina o JWT) - secreta |
| `estab` | código do estabelecimento usado nos exemplos |
| `usuario` | usuário informado nas cargas (campo `Usuario`) |

Importe o ambiente modelo, preencha as variáveis e selecione-o. O script da coleção gera o JWT e obtém o `accessToken` antes de cada requisição: não é preciso copiar token.

## Padrão de retorno

Todas as respostas trazem o mesmo envelope:

```json
{
  "sucesso": false,
  "mensagem": "Descrição geral do resultado",
  "erros": ["Uma mensagem por erro encontrado"]
}
```

| HTTP | Quando ocorre | `sucesso` |
|---|---|---|
| 200 | Requisição processada | `true` |
| 400 | JSON malformado, fora da estrutura esperada ou sem os parâmetros obrigatórios | `false` |
| 401 | Token ausente, inválido ou expirado | `false` |
| 403 | Token válido, sem autorização para os dados enviados | `false` |
| 404 | Registro não encontrado (exclusão e alteração) | `false` |
| 422 | Erro de validação dos dados: a lista `erros` traz cada um; nada é gravado | `false` |
| 500 | Erro interno | `false` |

As mensagens de erro têm uma parte variável no fim (o valor recebido, a posição do registro na lista). Trate pelo início da mensagem e pelo código HTTP.

## Possível ajuste (⚑)

O material documenta o comportamento atual da API. Onde ele pode mudar em versão futura, o ponto vem marcado com ⚑ e com o comportamento previsto. Ao integrar, prefira não depender do ponto marcado (por exemplo, trate a mensagem pelo início, não pelo texto completo).

## Organização

Os diretórios são separados por serviço. Cada um traz o layout de/para em XLSX (`Layout/`), os exemplos de requisição e retorno em JSON (`Exemplos/JSON/`) e um README com as operações e as regras.

| Serviço | Grupo | Operações |
|---|---|---|
| [Autenticação](Autenticacao/README.md) | - | `POST /API/JWT/Auth` |
| [Participante](Participante/README.md) | Cadastros | `POST /API/Migrate/Participante` |
| [Produto](Produto/README.md) | Cadastros | `POST /API/Migrate/Produto` |
| [Centro de Custo](Centro%20de%20Custo/README.md) | Cadastros | `POST /API/Migrate/Reg0600` |
| [Informação Complementar](Informacao%20Complementar/README.md) | Cadastros | `POST /API/Migrate/InfComplementar` |
| [Bloco E111](Bloco%20E111/README.md) | Apuração do ICMS | `POST /API/Migrate/BlocoE111` · `DELETE /API/Migrate/BlocoE111` |
| [Bloco E115](Bloco%20E115/README.md) | Apuração do ICMS | `POST /API/Migrate/BlocoE115` · `DELETE /API/Migrate/BlocoE115` |
| [Documento Fiscal](Documento%20Fiscal/README.md) | Documentos Fiscais | `POST /API/Migrate/DocFiscal` · `DELETE /API/Migrate/DocFiscal` · `POST /API/Migrate/DocFiscalAlteraSituacao` |
| [Bloco F - F100](Bloco%20F%20-%20F100/README.md) | Bloco F | `POST /API/Migrate/BlocoF100` |
| [Bloco F - F120 e F130](Bloco%20F%20-%20F120%20e%20F130/README.md) | Bloco F | `POST /API/Migrate/BlocoF` |
| [Bloco F - F500](Bloco%20F%20-%20F500/README.md) | Bloco F | `POST /API/Migrate/F500` · `DELETE /API/Migrate/F500` |
| [Bloco F - F600](Bloco%20F%20-%20F600/README.md) | Bloco F | `POST /API/Migrate/BlocoF600` · `DELETE /API/Migrate/BlocoF600` |
| [Bloco H](Bloco%20H/README.md) | Bloco H | `DELETE /API/Migrate/BlocoH` |
| [Bloco I](Bloco%20I/README.md) | Bloco I | `POST /API/Migrate/BlocoI` · `DELETE /API/Migrate/BlocoI` |
| [Bloco K](Bloco%20K/README.md) | Bloco K | `POST /API/Migrate/BlocoKNew` · `DELETE /API/Migrate/BlocoKNew` |
| [Bloco 1 - 1100](Bloco%201%20-%201100/README.md) | Bloco 1 | `POST /API/Migrate/Reg1100` · `DELETE /API/Migrate/Reg1100` |
| [Bloco 1 - 1601](Bloco%201%20-%201601/README.md) | Bloco 1 | `POST /API/Migrate/Bloco1601` · `DELETE /API/Migrate/Bloco1601` |
| [Bloco 1 - 1900](Bloco%201%20-%201900/README.md) | Bloco 1 | `POST /API/Migrate/Reg1900` · `DELETE /API/Migrate/Reg1900` |

## Postman

A biblioteca `API Migrate Fiscal` (coleção e ambiente modelo) traz um exemplo de cada operação, com os retornos possíveis.

Versão 1.0 · 23/10/2026
