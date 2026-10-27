# Bloco F - F100

Carga do registro F100 da EFD-Contribuições: demais documentos e operações geradoras de contribuição e crédito de PIS/Pasep e Cofins.

## Operações

| Método | Rota |
|---|---|
| POST | `{baseUrl}/API/Migrate/BlocoF100` |

Autenticação: header `Authorization: Bearer <accessToken>` (ver [Autenticação](../Autenticacao/README.md)).

## Regras

- **Finalidade:** Carga do registro F100 da EFD-Contribuições: demais documentos e operações geradoras de contribuição e crédito de PIS/Pasep e Cofins.
- **Método e rota:** POST {baseUrl}/API/Migrate/BlocoF100 ⚑ A rota pode passar a ser /API/v1/BlocoF100.
- **Formato:** JSON (Content-Type: application/json; charset=utf-8).
- **Autenticação:** Header Authorization: Bearer <accessToken> (aba Autenticação).
- **Envio:** Lista "BlocoF100" com um ou mais registros e "Usuario" ao lado.
- **Cadastros:** Participante, item, conta, centro de custo e categoria de lançamento precisam existir no estabelecimento antes do envio.
- **Categoria de lançamento:** Obrigatória na prática: sem uma categoria cadastrada no estabelecimento, o registro é recusado (422).
- **Validação:** Erros na lista "erros" (HTTP 422). Com erro, nada é gravado.
- **Reenvio:** Reenvio do mesmo registro: [A CONFIRMAR].
- **Exclusão:** Não há endpoint de exclusão do F100.

## Layout Json - Bloco F100 (Envio)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| &nbsp;&nbsp;`BlocoF100` | Lista | 1-N | S | Registros F100. Lista (não aceita objeto único). Lista vazia, objeto no lugar da lista ou outra chave: HTTP 400. Campos no grupo B. |
| &nbsp;&nbsp;`Usuario` | C | 1-1 | S | Usuário responsável pelo envio. Fica fora da lista. Identifica quem enviou a carga. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa) no sistema, vinculado à chave de parceiro. Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Dt_Oper` | D | 1-1 | S | Data da operação. AAAA-MM-DD. Inválida: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cod_Part` | C (60) | 0-1 | N | Código do participante. Participante cadastrado (registro 0150). Informado e não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cod_Item` | C (60) | 0-1 | N | Código do item. Item cadastrado (registro 0200). Informado e não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cod_Cta` | C (60) | 0-1 | N | Conta contábil. Conta analítica do plano de contas (ex.: 1.01.01.001). Informada e não localizada: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cod_Ccus` | C (60) | 0-1 | N | Centro de custo. Centro de custo cadastrado (registro 0600). Informado e não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cod_Categ_Lanc` | C | 1-1 | S | Categoria de lançamento. Código de uma categoria de lançamento ativa do estabelecimento. Obrigatória na prática: ausente ou não cadastrada, 422 "Categoria de lançamento inválida!". |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cst_Pis` | N (2) | 1-1 | S | CST do PIS/Pasep. Tabela 4.3.3 da EFD-Contribuições (ex.: "01"). Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cst_Cofins` | N (2) | 1-1 | S | CST da Cofins. Tabela 4.3.4 da EFD-Contribuições (ex.: "01"). Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Nat_Bc_Cred` | C (2) | 0-1 | C | Natureza da base de cálculo do crédito. Tabela 4.3.7 da EFD-Contribuições. Informar nas operações com direito a crédito. Inválida: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Ind_Orig_Cred` | C (1) | 0-1 | C | Indicador da origem do crédito. 0 = operação no mercado interno; 1 = operação de importação. Obrigatório quando o CST indica crédito (422 sem ele). Fora do domínio: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Vl_Oper` | N | 1-1 | S | Valor da operação. Número decimal, 2 casas (ex.: 1000.00). |
| &nbsp;&nbsp;&nbsp;&nbsp;`Desc_Doc_Oper` | C | 0-1 | N | Descrição do documento ou operação |
| &nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Pis` | N | 0-1 | N | Base de cálculo do PIS/Pasep. Número decimal, 2 casas (ex.: 1000.00). |
| &nbsp;&nbsp;&nbsp;&nbsp;`Aliq_Pis` | N | 0-1 | N | Alíquota do PIS/Pasep. Percentual, até 4 casas decimais (ex.: 1.65). |
| &nbsp;&nbsp;&nbsp;&nbsp;`Vl_Pis` | N | 0-1 | N | Valor do PIS/Pasep. Base × alíquota / 100. Número decimal, 2 casas (ex.: 1000.00). |
| &nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Cofins` | N | 0-1 | N | Base de cálculo da Cofins. Número decimal, 2 casas (ex.: 1000.00). |
| &nbsp;&nbsp;&nbsp;&nbsp;`Aliq_Cofins` | N | 0-1 | N | Alíquota da Cofins. Percentual, até 4 casas decimais (ex.: 1.65). |
| &nbsp;&nbsp;&nbsp;&nbsp;`Vl_Cofins` | N | 0-1 | N | Valor da Cofins. Base × alíquota / 100. Número decimal, 2 casas (ex.: 1000.00). |
| &nbsp;&nbsp;&nbsp;&nbsp;`CrpInProdutoId` | N | 0-1 | N | Identificador do sistema de origem. Número. Enviar 0 quando não houver. |
| &nbsp;&nbsp;&nbsp;&nbsp;`IdOrigem` | C | 0-1 | N | Identificador de origem. Identificador complementar do registro no sistema de origem. Uso [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;`IdOrigemExt` | C | 0-1 | N | Identificador do registro no sistema de origem. Identifica o registro enviado (ex.: o id no ERP). Recomendado; obrigatoriedade [A CONFIRMAR]. |

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Layout/Layout API Migrate - Bloco F - F100.xlsx](Layout/Layout%20API%20Migrate%20-%20Bloco%20F%20-%20F100.xlsx) | layout de/para com a EFD, retorno, códigos HTTP, erros e exemplos |
| [Exemplos/JSON/bloco-f100-requisicao.json](Exemplos/JSON/bloco-f100-requisicao.json) | POST /API/Migrate/BlocoF100 - Gravar F100 |
| [Exemplos/JSON/bloco-f100-retorno-200.json](Exemplos/JSON/bloco-f100-retorno-200.json) | HTTP 200 - F100 gravado |
| [Exemplos/JSON/bloco-f100-erro-categoria-requisicao.json](Exemplos/JSON/bloco-f100-erro-categoria-requisicao.json) | POST /API/Migrate/BlocoF100 - Erro - categoria de lançamento ausente |
| [Exemplos/JSON/bloco-f100-erro-categoria-retorno-422.json](Exemplos/JSON/bloco-f100-erro-categoria-retorno-422.json) | HTTP 422 - Categoria inválida |

⚑ = possível ajuste: comportamento atual, que pode mudar em versão futura.
