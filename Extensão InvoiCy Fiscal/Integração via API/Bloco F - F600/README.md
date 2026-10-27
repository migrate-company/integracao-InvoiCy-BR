# Bloco F - F600

Carga e exclusão do registro F600 da EFD-Contribuições: contribuições de PIS/Pasep e Cofins retidas na fonte.

## Operações

| Método | Rota |
|---|---|
| POST | `{baseUrl}/API/Migrate/BlocoF600` |
| DELETE | `{baseUrl}/API/Migrate/BlocoF600` |

Autenticação: header `Authorization: Bearer <accessToken>` (ver [Autenticação](../Autenticacao/README.md)).

## Regras

- **Finalidade:** Carga e exclusão do registro F600 da EFD-Contribuições: contribuições de PIS/Pasep e Cofins retidas na fonte.
- **Método e rota:** POST e DELETE {baseUrl}/API/Migrate/BlocoF600 ⚑ A rota pode passar a ser /API/v1/BlocoF600.
- **Formato:** JSON (Content-Type: application/json; charset=utf-8).
- **Autenticação:** Header Authorization: Bearer <accessToken> (aba Autenticação).
- **Envio:** Lista "BlocoF600" com um ou mais registros e "Usuario" ao lado. ⚑ Hoje, lista vazia, objeto no lugar da lista ou outra chave respondem 200 (sucesso true) sem gravar nada. Previsto: 400. Não envie corpo sem registros.
- **Validação:** Erros na lista "erros" (HTTP 422). Com erro, nada é gravado.
- **Reenvio:** Reenviar o mesmo registro (mesmo IdOrigemExt) altera o registro gravado; os campos não enviados são preservados.
- **Exclusão:** DELETE com os identificadores na URL (aba Exclusão), sem corpo. O registro é apagado; sem registro correspondente: 404.

## Layout Json - Bloco F600 (Envio)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| &nbsp;&nbsp;`BlocoF600` | Lista | 1-N | S | Registros F600. Lista com ao menos um registro. Campos no grupo B. ⚑ Hoje, lista vazia, objeto no lugar da lista ou outra chave respondem 200 (sucesso true) sem gravar nada. Previsto: 400. Não envie corpo sem registros. |
| &nbsp;&nbsp;`Usuario` | C | 1-1 | S | Usuário responsável pelo envio. Fica fora da lista. Identifica quem enviou a carga. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa), vinculado à chave de parceiro. Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Ind_Nat_Ret` | N (2) | 1-1 | S | Natureza da retenção na fonte. Código da natureza da retenção da EFD-Contribuições, vigente na data (ex.: "01"). Sem vigência: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Dt_Ret` | D | 1-1 | S | Data da retenção. AAAA-MM-DD. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Ret` | N | 1-1 | S | Base de cálculo da retenção. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Vl_Ret` | N | 1-1 | S | Valor total retido. Na EFD, o total retido de PIS/Pasep e Cofins. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cod_Rec` | C (4) | 0-1 | N | Código da receita. Código de receita do recolhimento (ex.: "5952"). |
| &nbsp;&nbsp;&nbsp;&nbsp;`Ind_Nat_Rec` | N (1) | 1-1 | S | Natureza da receita. 0 = receita de natureza não cumulativa; 1 = receita de natureza cumulativa. Fora do domínio: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`CNPJ` | N (14) | 1-1 | S | CNPJ da fonte pagadora ou beneficiária. CNPJ responsável pela retenção (declarante beneficiário) ou beneficiário (declarante responsável). Só dígitos. Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Vl_Ret_Pis` | N | 0-1 | N | Valor retido de PIS/Pasep. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Vl_Ret_Cofins` | N | 0-1 | N | Valor retido de Cofins. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Ind_Dec` | N (1) | 1-1 | S | Condição do declarante. 0 = beneficiária da retenção/recolhimento; 1 = responsável pelo recolhimento. Fora do domínio: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`CrpInProdutoId` | N | 0-1 | N | Identificador do sistema de origem. Número. Enviar 0 quando não houver; o mesmo valor vai na exclusão. |
| &nbsp;&nbsp;&nbsp;&nbsp;`IdOrigem` | N | 0-1 | N | Identificador de origem (numérico). Enviar 0 quando não houver; o mesmo valor vai na exclusão. |
| &nbsp;&nbsp;&nbsp;&nbsp;`IdOrigemExt` | C | 1-1 | S | Identificador do registro no sistema de origem. Identifica o registro: reenviar o mesmo IdOrigemExt altera o registro; a exclusão usa este valor. |

## Layout - Bloco F600 (Exclusão: Parâmetros Na Url)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| `Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento do registro. Ausente: 400. Não localizado: 422. |
| `CrpInProdutoId` | N | 1-1 | S | Identificador do sistema de origem. O CrpInProdutoId enviado na gravação (0 quando não houver). ⚑ Hoje, ausente ou vazio vale 0. Previsto: obrigatório (400 "CrpInProdutoId: Campo obrigatorio."). Envie sempre, com 0 quando não houver. |
| `IdOrigem` | N | 0-1 | C | Identificador de origem. O IdOrigem enviado na gravação (0 quando não houver). Informe IdOrigemExt ou IdOrigem: 0 conta como não informado (400 sem os dois). |
| `IdOrigemExt` | C | 0-1 | C | Identificador do registro no sistema de origem. O IdOrigemExt enviado na gravação. |
| `Usuario` | C | 1-1 | S | Usuário responsável pela exclusão |

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Layout/Layout API Migrate - Bloco F - F600.xlsx](Layout/Layout%20API%20Migrate%20-%20Bloco%20F%20-%20F600.xlsx) | layout de/para com a EFD, retorno, códigos HTTP, erros e exemplos |
| [Exemplos/JSON/bloco-f600-requisicao.json](Exemplos/JSON/bloco-f600-requisicao.json) | POST /API/Migrate/BlocoF600 - Gravar F600 |
| [Exemplos/JSON/bloco-f600-retorno-200.json](Exemplos/JSON/bloco-f600-retorno-200.json) | HTTP 200 - F600 gravado |
| [Exemplos/JSON/bloco-f600-erro-validacao-requisicao.json](Exemplos/JSON/bloco-f600-erro-validacao-requisicao.json) | POST /API/Migrate/BlocoF600 - Erro - indicador fora do domínio |
| [Exemplos/JSON/bloco-f600-erro-validacao-retorno-422.json](Exemplos/JSON/bloco-f600-erro-validacao-retorno-422.json) | HTTP 422 - Domínio inválido |
| [Exemplos/JSON/bloco-f600-exclusao-retorno-200.json](Exemplos/JSON/bloco-f600-exclusao-retorno-200.json) | HTTP 200 - F600 excluído |
| [Exemplos/JSON/bloco-f600-exclusao-retorno-404.json](Exemplos/JSON/bloco-f600-exclusao-retorno-404.json) | HTTP 404 - Nenhum registro encontrado |

⚑ = possível ajuste: comportamento atual, que pode mudar em versão futura.
