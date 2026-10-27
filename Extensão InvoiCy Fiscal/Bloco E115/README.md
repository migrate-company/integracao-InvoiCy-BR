# Bloco E115

Informações adicionais da apuração do ICMS (valores declaratórios), registro E115 da EFD ICMS/IPI: gravação e exclusão.

## Operações

| Método | Rota |
|---|---|
| POST | `{baseUrl}/API/Migrate/BlocoE115` |
| DELETE | `{baseUrl}/API/Migrate/BlocoE115` |

Autenticação: header `Authorization: Bearer <accessToken>` (ver [Autenticação](../Autenticacao/README.md)).

## Regras

- **Finalidade:** Informações adicionais da apuração do ICMS (valores declaratórios), registro E115 da EFD ICMS/IPI.
- **Métodos e rota:** POST {baseUrl}/API/Migrate/BlocoE115 (gravação) e DELETE {baseUrl}/API/Migrate/BlocoE115 (exclusão). ⚑ A rota pode passar a ser /API/v1/BlocoE115.
- **Formato:** JSON (Content-Type: application/json; charset=utf-8). A exclusão não tem corpo: os dados vão na URL.
- **Autenticação:** Header Authorization: Bearer <accessToken> (aba Autenticação).
- **Envio:** Lista "BlocoE115" com um ou mais registros, com "Usuario" ao lado da lista. Lista vazia: 400. ⚑ Hoje "BlocoE115" precisa ser lista (array): um objeto único, sem lista, responde 400. Pode passar a aceitar também um objeto único.
- **Validação:** Com qualquer erro (HTTP 422), nada é gravado - nem os demais registros da lista. As mensagens citam a posição do item na lista.
- **Reenvio:** Regra de atualização ao reenviar um registro já gravado: [A CONFIRMAR].
- **Exclusão:** Pelo IdOrigemExt e o estabelecimento informados na URL. Sem registro para excluir: 404.
- **Mensagens:** Trate as mensagens pelo início do texto e sem diferenciar acentos.

## Layout Json - Bloco E115 (Envio)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| &nbsp;&nbsp;`BlocoE115` | Lista | 1-N | S | Lista de informações adicionais da apuração. Lista (array), mesmo com um registro só. Lista vazia: 400. Campos de cada item no grupo B. As mensagens de erro citam a posição do item na lista (1 = primeiro). ⚑ Hoje "BlocoE115" precisa ser lista (array): um objeto único, sem lista, responde 400. Pode passar a aceitar também um objeto único. |
| &nbsp;&nbsp;`Usuario` | C | 1-1 | S | Usuário responsável pelo envio. Fica fora da lista BlocoE115. Identifica quem enviou a carga. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa) no sistema, vinculado à chave de parceiro. Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Periodo` | D | 1-1 | S | Período da apuração. Primeiro dia do mês da apuração, no formato AAAA-MM-DD. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cod_Inf_Adic` | C (8) | 1-1 | S | Código da informação adicional. Código da Tabela 5.2 (informações adicionais da apuração - valores declaratórios) da UF do estabelecimento, ativo. Fora da tabela ou inativo: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Vl_Inf_Adic` | N (2 decimais) | 1-1 | S | Valor da informação adicional. Número JSON com ponto decimal (ex.: 1234.56). |
| &nbsp;&nbsp;&nbsp;&nbsp;`Descr_Compl_Aj` | C | 0-1 | N | Descrição complementar |
| &nbsp;&nbsp;&nbsp;&nbsp;`IdOrigemExt` | C | 0-1 | C | Identificador do registro no sistema de origem. Chave usada para excluir o registro pela API (DELETE). Sem ele, o registro não pode ser excluído pela API. Obrigatoriedade na gravação: [A CONFIRMAR]. |

## Layout - Exclusão (Parâmetros Da Url)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| `Idorigemext` | C | 1-1 | S | Identificador do registro no sistema de origem. O mesmo IdOrigemExt enviado na gravação. Atenção à grafia do parâmetro: Idorigemext. Ausente ou vazio: 400. |
| `Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento usado na gravação. Não localizado: 422. |
| `Usuario` | C | 1-1 | S | Usuário responsável pela exclusão. Identifica quem pediu a exclusão. |

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Layout/Layout API Migrate - Bloco E115.xlsx](Layout/Layout%20API%20Migrate%20-%20Bloco%20E115.xlsx) | layout de/para com a EFD, retorno, códigos HTTP, erros e exemplos |
| [Exemplos/JSON/bloco-e115-requisicao.json](Exemplos/JSON/bloco-e115-requisicao.json) | POST /API/Migrate/BlocoE115 - Gravar - informações adicionais da apuração |
| [Exemplos/JSON/bloco-e115-retorno-200.json](Exemplos/JSON/bloco-e115-retorno-200.json) | HTTP 200 - E115 gravado |
| [Exemplos/JSON/bloco-e115-erro-validacao-requisicao.json](Exemplos/JSON/bloco-e115-erro-validacao-requisicao.json) | POST /API/Migrate/BlocoE115 - Erro - estabelecimento não localizado |
| [Exemplos/JSON/bloco-e115-erro-validacao-retorno-422.json](Exemplos/JSON/bloco-e115-erro-validacao-retorno-422.json) | HTTP 422 - Erro de validação |
| [Exemplos/JSON/bloco-e115-erro-lista-vazia-requisicao.json](Exemplos/JSON/bloco-e115-erro-lista-vazia-requisicao.json) | POST /API/Migrate/BlocoE115 - Erro - lista vazia |
| [Exemplos/JSON/bloco-e115-erro-lista-vazia-retorno-400.json](Exemplos/JSON/bloco-e115-erro-lista-vazia-retorno-400.json) | HTTP 400 - Dados inválidos |
| [Exemplos/JSON/bloco-e115-exclusao-retorno-200.json](Exemplos/JSON/bloco-e115-exclusao-retorno-200.json) | HTTP 200 - E115 excluído |
| [Exemplos/JSON/bloco-e115-exclusao-erro-retorno-400.json](Exemplos/JSON/bloco-e115-exclusao-erro-retorno-400.json) | HTTP 400 - Parâmetro obrigatório |

⚑ = possível ajuste: comportamento atual, que pode mudar em versão futura.
