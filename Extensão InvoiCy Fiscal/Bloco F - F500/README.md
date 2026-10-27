# Bloco F - F500

Carga e exclusão do registro F500 da EFD-Contribuições: consolidação das receitas recebidas pela pessoa jurídica do lucro presumido no regime de caixa.

## Operações

| Método | Rota |
|---|---|
| POST | `{baseUrl}/API/Migrate/F500` |
| DELETE | `{baseUrl}/API/Migrate/F500` |

Autenticação: header `Authorization: Bearer <accessToken>` (ver [Autenticação](../Autenticacao/README.md)).

## Regras

- **Finalidade:** Carga e exclusão do registro F500 da EFD-Contribuições: consolidação das receitas recebidas pela pessoa jurídica do lucro presumido no regime de caixa.
- **Método e rota:** POST e DELETE {baseUrl}/API/Migrate/F500 ⚑ A rota pode passar a ser /API/v1/F500.
- **Formato:** JSON (Content-Type: application/json; charset=utf-8).
- **Autenticação:** Header Authorization: Bearer <accessToken> (aba Autenticação).
- **Envio:** Lista "F500" com um ou mais registros e "Usuario" ao lado.
- **Validação:** Erros na lista "erros" (HTTP 422). Com erro, nada é gravado.
- **Reenvio:** O mesmo F500 reenviado é recusado como duplicado (422). Para alterar: excluir e enviar de novo.
- **Exclusão:** DELETE com os identificadores na URL (aba Exclusão), sem corpo. O registro é apagado; sem registro correspondente: 404. ⚑ Os nomes dos parâmetros da exclusão podem passar a ser IdCrpInProduto, IdOrigem e IdOrigemExt (mesma grafia da gravação).

## Layout Json - F500 (Envio)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| &nbsp;&nbsp;`F500` | Lista | 1-N | S | Registros F500. Lista (não aceita objeto único). Lista vazia, objeto no lugar da lista ou outra chave: HTTP 400. Campos no grupo B. |
| &nbsp;&nbsp;`Usuario` | C | 1-1 | S | Usuário responsável pelo envio. Fica fora da lista. Identifica quem enviou a carga. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Estabelecimento` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa), vinculado à chave de parceiro. Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Dt_Referencia` | D | 1-1 | S | Período de referência. Primeiro dia do mês (AAAA-MM-01). |
| &nbsp;&nbsp;&nbsp;&nbsp;`Vl_Rec` | C | 1-1 | S | Valor total da receita recebida. Texto com vírgula decimal (ex.: "1000,00"). Aceite como número JSON: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Ind_Aliquota` | C (1) | 1-1 | S | Indicador da alíquota. Valores aceitos: 1 ou 2 (significado de cada um: [A CONFIRMAR]). Fora do domínio: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cst_Pis` | N (2) | 1-1 | S | CST do PIS/Pasep. Tabela 4.3.3 da EFD-Contribuições, vigente no período. Não cadastrado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Vl_Desc_Pis` | N | 0-1 | N | Desconto ou exclusão do PIS/Pasep. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Pis` | N | 0-1 | N | Base de cálculo do PIS/Pasep. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Aliq_Pis` | N | 0-1 | N | Alíquota do PIS/Pasep. Percentual, até 4 casas decimais (ex.: 0.65). |
| &nbsp;&nbsp;&nbsp;&nbsp;`Vl_Pis` | N | 0-1 | N | Valor do PIS/Pasep. Base × alíquota / 100. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cst_Cofins` | N (2) | 1-1 | S | CST da Cofins. Tabela 4.3.4 da EFD-Contribuições, vigente no período. Não cadastrado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Vl_Desc_Cofins` | N | 0-1 | N | Desconto ou exclusão da Cofins. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Cofins` | N | 0-1 | N | Base de cálculo da Cofins. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Aliq_Cofins` | N | 0-1 | N | Alíquota da Cofins. Percentual, até 4 casas decimais (ex.: 0.65). |
| &nbsp;&nbsp;&nbsp;&nbsp;`Vl_Cofins` | N | 0-1 | N | Valor da Cofins. Base × alíquota / 100. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cod_Mod` | C (2) | 0-1 | N | Modelo do documento fiscal. Tabela 4.1.1 da EFD (ex.: "55"). Fora do domínio: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`CFOP` | N (4) | 0-1 | N | CFOP. Vigente no período. Não cadastrado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cod_Cta` | C (60) | 1-1 | S | Conta contábil. Conta do plano de contas vigente no período (ex.: 1.01.01.001). Não cadastrada: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Inf_Compl` | C | 0-1 | N | Informação complementar |
| &nbsp;&nbsp;&nbsp;&nbsp;`Nat_Rec` | C | 0-1 | N | Natureza da receita. Uso e domínio: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Categ_Lanc` | C | 0-1 | N | Categoria de lançamento. Categoria de lançamento do estabelecimento. Informada e não cadastrada para o período: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`CrpInProdutoId` | N | 0-1 | N | Identificador do sistema de origem. Número. Enviar 0 quando não houver; o mesmo valor vai na exclusão (Idcrpinproduto). |
| &nbsp;&nbsp;&nbsp;&nbsp;`IdOrigem` | N | 0-1 | N | Identificador de origem (numérico). Enviar 0 quando não houver; o mesmo valor vai na exclusão (Idorigem). |
| &nbsp;&nbsp;&nbsp;&nbsp;`IdOrigemExt` | C | 1-1 | S | Identificador do registro no sistema de origem. Identifica o registro para a exclusão (Idorigemext). |

## Layout - F500 (Exclusão: Parâmetros Na Url)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| `Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento do registro. Não localizado: também 404 (mesma mensagem de registro não encontrado). |
| `Idcrpinproduto` | N | 1-1 | S | Identificador do sistema de origem. O CrpInProdutoId enviado na gravação (0 quando não houver). |
| `Idorigem` | N | 1-1 | S | Identificador de origem. O IdOrigem enviado na gravação (0 quando não houver). |
| `Idorigemext` | C | 1-1 | S | Identificador do registro no sistema de origem. O IdOrigemExt enviado na gravação. Ausente: 400. |
| `Usuario` | C | 1-1 | S | Usuário responsável pela exclusão |

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Layout/Layout API Migrate - Bloco F - F500.xlsx](Layout/Layout%20API%20Migrate%20-%20Bloco%20F%20-%20F500.xlsx) | layout de/para com a EFD, retorno, códigos HTTP, erros e exemplos |
| [Exemplos/JSON/f500-requisicao.json](Exemplos/JSON/f500-requisicao.json) | POST /API/Migrate/F500 - Gravar F500 |
| [Exemplos/JSON/f500-retorno-200.json](Exemplos/JSON/f500-retorno-200.json) | HTTP 200 - F500 gravado |
| [Exemplos/JSON/f500-erro-validacao-requisicao.json](Exemplos/JSON/f500-erro-validacao-requisicao.json) | POST /API/Migrate/F500 - Erro - indicador de alíquota fora do domínio |
| [Exemplos/JSON/f500-erro-validacao-retorno-422.json](Exemplos/JSON/f500-erro-validacao-retorno-422.json) | HTTP 422 - Domínio inválido |
| [Exemplos/JSON/f500-exclusao-retorno-200.json](Exemplos/JSON/f500-exclusao-retorno-200.json) | HTTP 200 - F500 excluído |
| [Exemplos/JSON/f500-exclusao-retorno-404.json](Exemplos/JSON/f500-exclusao-retorno-404.json) | HTTP 404 - Nenhum registro encontrado |

⚑ = possível ajuste: comportamento atual, que pode mudar em versão futura.
