# Bloco 1 - 1601

Carga e exclusão do registro 1601 da EFD ICMS/IPI: operações com instrumentos de pagamento eletrônico (totais do mês por instituição de pagamento e intermediador).

## Operações

| Método | Rota |
|---|---|
| POST | `{baseUrl}/API/Migrate/Bloco1601` |
| DELETE | `{baseUrl}/API/Migrate/Bloco1601` |

Autenticação: header `Authorization: Bearer <accessToken>` (ver [Autenticação](../Autenticacao/README.md)).

## Regras

- **Finalidade:** Carga e exclusão do registro 1601 da EFD ICMS/IPI: operações com instrumentos de pagamento eletrônico (totais do mês por instituição de pagamento e intermediador).
- **Método e rota:** POST e DELETE {baseUrl}/API/Migrate/Bloco1601 ⚑ A rota pode passar a ser /API/v1/Bloco1601.
- **Formato:** JSON (Content-Type: application/json; charset=utf-8).
- **Autenticação:** Header Authorization: Bearer <accessToken> (aba Autenticação).
- **Envio:** Lista "Bloco1601" com um ou mais registros e "Usuario" ao lado.
- **Período:** O 1601 é mensal: o período do mês da Data é criado se ainda não existir.
- **Validação:** Erros na lista "erros" (HTTP 422). Com erro, nada é gravado.
- **Reenvio:** Reenviar o 1601 no mesmo período é recusado (422). Para alterar: excluir e enviar de novo.
- **Exclusão:** DELETE com os identificadores na URL (aba Exclusão), sem corpo. O registro é apagado; sem registro correspondente: 404. ⚑ Quando não houver período escriturado para a data, a mensagem pode passar a ser específica ("Período não encontrado ... para a data informada"), também 404. Tratar pelo código HTTP.

## Layout Json - Bloco 1601 (Envio)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| &nbsp;&nbsp;`Bloco1601` | Lista | 1-N | S | Registros 1601. Lista (não aceita objeto único). Lista vazia, objeto no lugar da lista ou outra chave: HTTP 400. Campos no grupo B. |
| &nbsp;&nbsp;`Usuario` | C | 1-1 | S | Usuário responsável pelo envio. Fica fora da lista. Identifica quem enviou a carga. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Estabelecimento` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa), vinculado à chave de parceiro. Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Data` | D | 1-1 | S | Data de referência. AAAA-MM-DD, dentro do mês a que o 1601 se refere. O período mensal é criado se ainda não existir. A mesma data vai na exclusão. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cod_Part_Ip` | C (60) | 1-1 | S | Participante instituição de pagamento. Código do participante (registro 0150) da instituição facilitadora, intermediadora ou arranjo de pagamento, vigente na data. Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cod_Part_It` | C (60) | 0-1 | N | Participante intermediador. Código do participante (registro 0150) do intermediador da transação, quando houver. Informado e não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Tot_Vs` | N | 1-1 | S | Valor total das vendas e prestações. Total bruto das vendas e prestações de serviço com ICMS no período. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Tot_Iss` | N | 1-1 | S | Valor total das prestações com ISS. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Tot_Outros` | N | 1-1 | S | Valor total de outras operações. Demais valores. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;`CrpInProdutoId` | C | 0-1 | N | Identificador do sistema de origem. Vazio quando não houver. |
| &nbsp;&nbsp;&nbsp;&nbsp;`IdOrigem` | C | 0-1 | N | Identificador de origem. Identificador complementar do registro no sistema de origem; também aceito na exclusão. |
| &nbsp;&nbsp;&nbsp;&nbsp;`IdOrigemExt` | C | 1-1 | S | Identificador do registro no sistema de origem. Identifica o registro para a exclusão. |

## Layout - Bloco 1601 (Exclusão: Parâmetros Na Url)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| `Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento do registro. Não localizado: 422. |
| `Data` | D | 1-1 | S | Data do registro. AAAA-MM-DD, a mesma enviada na gravação. Ausente ou inválida: 422. |
| `IdOrigemExt` | C | 0-1 | C | Identificador do registro no sistema de origem. O IdOrigemExt enviado na gravação. Informe IdOrigemExt ou IdOrigem (sem nenhum identificador: 400). |
| `IdOrigem` | C | 0-1 | C | Identificador de origem. Alternativa ao IdOrigemExt: o IdOrigem enviado na gravação. CrpInProdutoId como terceira alternativa: [A CONFIRMAR]. |
| `Usuario` | C | 1-1 | S | Usuário responsável pela exclusão |

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Layout/Layout API Migrate - Bloco 1 - 1601.xlsx](Layout/Layout%20API%20Migrate%20-%20Bloco%201%20-%201601.xlsx) | layout de/para com a EFD, retorno, códigos HTTP, erros e exemplos |
| [Exemplos/JSON/bloco-1601-requisicao.json](Exemplos/JSON/bloco-1601-requisicao.json) | POST /API/Migrate/Bloco1601 - Gravar 1601 |
| [Exemplos/JSON/bloco-1601-retorno-200.json](Exemplos/JSON/bloco-1601-retorno-200.json) | HTTP 200 - 1601 gravado |
| [Exemplos/JSON/bloco-1601-erro-validacao-requisicao.json](Exemplos/JSON/bloco-1601-erro-validacao-requisicao.json) | POST /API/Migrate/Bloco1601 - Erro - estabelecimento não localizado |
| [Exemplos/JSON/bloco-1601-erro-validacao-retorno-422.json](Exemplos/JSON/bloco-1601-erro-validacao-retorno-422.json) | HTTP 422 - Estabelecimento não localizado |
| [Exemplos/JSON/bloco-1601-exclusao-retorno-200.json](Exemplos/JSON/bloco-1601-exclusao-retorno-200.json) | HTTP 200 - 1601 excluído |
| [Exemplos/JSON/bloco-1601-exclusao-retorno-404.json](Exemplos/JSON/bloco-1601-exclusao-retorno-404.json) | HTTP 404 - Nenhum registro encontrado |

⚑ = possível ajuste: comportamento atual, que pode mudar em versão futura.
