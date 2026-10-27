# Bloco I

Operações das instituições financeiras e assemelhadas no Bloco I da EFD-Contribuições (I100, I200 e I300), com envio e exclusão.

## Operações

| Método | Rota |
|---|---|
| POST | `{baseUrl}/API/Migrate/BlocoI` |
| DELETE | `{baseUrl}/API/Migrate/BlocoI` |

Autenticação: header `Authorization: Bearer <accessToken>` (ver [Autenticação](../Autenticacao/README.md)).

## Regras

- **Finalidade:** Envio e exclusão do Bloco I da EFD-Contribuições: consolidação das operações por CST (I100), composição das receitas e deduções (I200) e complemento (I300).
- **Métodos e rota:** POST e DELETE {baseUrl}/API/Migrate/BlocoI ⚑ A rota pode passar a ser /API/v1/BlocoI.
- **Formato:** JSON (Content-Type: application/json; charset=utf-8).
- **Autenticação:** Header Authorization: Bearer <accessToken> (aba Autenticação).
- **Envio:** Lista de I100 sob a chave "sdtSetBlocoI" (I200 e I300 dentro de cada I100), com "Usuario" ao lado.
- **Validação:** Erros de validação retornam na lista "erros" (HTTP 422); nada é gravado. ⚑ Hoje a conta não é validada (o envio é aceito). Pode passar a recusar conta inexistente com 422 "Conta contabil invalida!" (I200) ou "I300: Conta contabil invalida!" (I300).
- **Reenvio:** I100 igual no mesmo período e estabelecimento é recusado (422). Para alterar, exclua e envie novamente.
- **Exclusão:** DELETE com Estab, Periodo, Conopecrpinprdid, Conopeidorigemext e Usuario na URL. ⚑ Os parâmetros podem passar a ter os nomes IdCrpInProduto, IdOrigem e IdOrigemExt. Hoje só os nomes desta aba são reconhecidos.
- **Datas nas mensagens:** As mensagens trazem a data com ano de 2 dígitos (DD/MM/AA).

## Layout Json - Bloco I (Envio)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| &nbsp;&nbsp;`sdtSetBlocoI` | Lista | 1-N | S | Lista de I100. Lista (não objeto) sob a chave "sdtSetBlocoI". Lista vazia, objeto no lugar de lista ou outra chave: 400. Campos no grupo B. |
| &nbsp;&nbsp;`Usuario` | C | 1-1 | S | Usuário responsável pelo envio. Fica fora da lista "sdtSetBlocoI". Identifica quem enviou a carga. |
| &nbsp;&nbsp;`(item)` | Objeto | 1-N | S | Consolidação das operações por CST |
| &nbsp;&nbsp;&nbsp;&nbsp;`CodigoEstab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa) no sistema, vinculado à chave de parceiro. Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Periodo` | D | 1-1 | S | Período de apuração. Primeiro dia do mês, AAAA-MM-DD. Inválido: 422. Informe o mesmo valor na exclusão. |
| &nbsp;&nbsp;&nbsp;&nbsp;`VlRec` | N (-,2) | 1-1 | S | Valor total do faturamento/receita |
| &nbsp;&nbsp;&nbsp;&nbsp;`CstPisCofins` | N (2) | 1-1 | S | CST do PIS/Pasep e da Cofins. Código da situação tributária (tabela da EFD-Contribuições). Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`VlTotDedGer` | N (-,2) | 1-1 | S | Total das deduções e exclusões de caráter geral. Sem valor: 0. |
| &nbsp;&nbsp;&nbsp;&nbsp;`VlTotDedEsp` | N (-,2) | 1-1 | S | Total das deduções e exclusões de caráter específico. Sem valor: 0. |
| &nbsp;&nbsp;&nbsp;&nbsp;`VlBcPis` | N (-,2) | 1-1 | S | Base de cálculo do PIS/Pasep |
| &nbsp;&nbsp;&nbsp;&nbsp;`AliqPis` | N (-,4) | 1-1 | S | Alíquota do PIS/Pasep (%) |
| &nbsp;&nbsp;&nbsp;&nbsp;`VlPis` | N (-,2) | 1-1 | S | Valor do PIS/Pasep |
| &nbsp;&nbsp;&nbsp;&nbsp;`VlBcCofins` | N (-,2) | 1-1 | S | Base de cálculo da Cofins |
| &nbsp;&nbsp;&nbsp;&nbsp;`AliqCofins` | N (-,4) | 1-1 | S | Alíquota da Cofins (%) |
| &nbsp;&nbsp;&nbsp;&nbsp;`VlCofins` | N (-,2) | 1-1 | S | Valor da Cofins |
| &nbsp;&nbsp;&nbsp;&nbsp;`InfoCompl` | C | 0-1 | N | Informação complementar. Faz parte da checagem de duplicidade (ver aba Erros). |
| &nbsp;&nbsp;&nbsp;&nbsp;`CrpInProdutoId` | N | 1-1 | S | Identificador do sistema de origem. Valores aceitos: [A CONFIRMAR]. Informe o mesmo valor na exclusão (Conopecrpinprdid). |
| &nbsp;&nbsp;&nbsp;&nbsp;`IdOrigem` | C | 0-1 | N | Identificador interno no sistema de origem |
| &nbsp;&nbsp;&nbsp;&nbsp;`IdOrigemExt` | C | 1-1 | S | Identificador do registro no sistema de origem. Chave usada na exclusão (Conopeidorigemext). |
| &nbsp;&nbsp;&nbsp;&nbsp;`EstI200List` | L | 0-N | N | Lista de I200 do I100. Campos no grupo C. |
| &nbsp;&nbsp;&nbsp;&nbsp;`(item)` | Objeto | 0-N | N | Composição das receitas, deduções e exclusões |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`NumCampo` | C (2) | 1-1 | S | Campo do I100 detalhado. Número do campo do I100 a que o detalhamento se refere (ex.: "02" = VL_REC), conforme a EFD-Contribuições. Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`CodDet` | C | 1-1 | S | Código do detalhamento. Código da tabela de detalhamento da EFD-Contribuições correspondente ao campo. Inválido: 422. Tamanho: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`DetValor` | N (-,2) | 1-1 | S | Valor detalhado |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`CodCta` | C (255) | 0-1 | N | Conta contábil. Conta do plano de contas do estabelecimento. ⚑ Hoje a conta não é validada (o envio é aceito). Pode passar a recusar conta inexistente com 422 "Conta contabil invalida!" (I200) ou "I300: Conta contabil invalida!" (I300). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`InfoCompl` | C | 0-1 | N | Informação complementar |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`EstI300List` | L | 0-N | N | Lista de I300 do I200. Campos no grupo D. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`(item)` | Objeto | 0-N | N | Complemento das operações |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`CodComp` | C | 1-1 | S | Código do complemento do detalhamento. Código da tabela de complemento da EFD-Contribuições correspondente ao detalhamento. Inválido: 422. Tamanho: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`DetValor` | N (-,2) | 1-1 | S | Valor do complemento |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`CodCta` | C (255) | 0-1 | N | Conta contábil. Conta do plano de contas do estabelecimento. ⚑ Hoje a conta não é validada (o envio é aceito). Pode passar a recusar conta inexistente com 422 "Conta contabil invalida!" (I200) ou "I300: Conta contabil invalida!" (I300). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`InfoCompl` | C | 0-1 | N | Informação complementar |

## Exclusão - Delete /Api/Migrate/Blocoi (Parâmetros Da Url)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| `Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento. Ausente: 400. Não localizado: 422. |
| `Periodo` | D | 1-1 | S | Período do I100. O mesmo período do envio, AAAA-MM-DD. Ausente ou inválido: 400. |
| `Conopecrpinprdid` | N | 1-1 | S | Identificador do sistema de origem. O mesmo CrpInProdutoId do envio. Ausente: 400. ⚑ Os parâmetros podem passar a ter os nomes IdCrpInProduto, IdOrigem e IdOrigemExt. Hoje só os nomes desta aba são reconhecidos. |
| `Conopeidorigemext` | C | 1-1 | S | Identificador do registro no sistema de origem. O mesmo IdOrigemExt do envio. Ausente: 400. Sem registro: 404. ⚑ Os parâmetros podem passar a ter os nomes IdCrpInProduto, IdOrigem e IdOrigemExt. Hoje só os nomes desta aba são reconhecidos. |
| `Usuario` | C | 1-1 | S | Usuário responsável pela exclusão. Identifica quem solicitou a exclusão. |
| `(registros)` | - | - | - | I100 e seus I200/I300. O I100 localizado e os registros filhos são excluídos. Repetir a exclusão: 404. |

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Layout/Layout API Migrate - Bloco I.xlsx](Layout/Layout%20API%20Migrate%20-%20Bloco%20I.xlsx) | layout de/para com a EFD, retorno, códigos HTTP, erros e exemplos |
| [Exemplos/JSON/bloco-i-gravar-requisicao.json](Exemplos/JSON/bloco-i-gravar-requisicao.json) | POST /API/Migrate/BlocoI - Gravar - I100 com I200 e I300 |
| [Exemplos/JSON/bloco-i-gravar-retorno-200.json](Exemplos/JSON/bloco-i-gravar-retorno-200.json) | HTTP 200 - Bloco I gravado |
| [Exemplos/JSON/bloco-i-erro-validacao-requisicao.json](Exemplos/JSON/bloco-i-erro-validacao-requisicao.json) | POST /API/Migrate/BlocoI - Erro - CST inválido |
| [Exemplos/JSON/bloco-i-erro-validacao-retorno-422.json](Exemplos/JSON/bloco-i-erro-validacao-retorno-422.json) | HTTP 422 - Erro de validação |
| [Exemplos/JSON/bloco-i-excluir-retorno-200.json](Exemplos/JSON/bloco-i-excluir-retorno-200.json) | HTTP 200 - Registros excluídos |
| [Exemplos/JSON/bloco-i-excluir-nao-encontrado-retorno-404.json](Exemplos/JSON/bloco-i-excluir-nao-encontrado-retorno-404.json) | HTTP 404 - Nada a excluir |

⚑ = possível ajuste: comportamento atual, que pode mudar em versão futura.
