# Bloco 1 - 1900

Carga e exclusão do registro 1900 da EFD-Contribuições: consolidação dos documentos emitidos no período (receitas por modelo, situação, CST e conta).

## Operações

| Método | Rota |
|---|---|
| POST | `{baseUrl}/API/Migrate/Reg1900` |
| DELETE | `{baseUrl}/API/Migrate/Reg1900` |

Autenticação: header `Authorization: Bearer <accessToken>` (ver [Autenticação](../Autenticacao/README.md)).

## Regras

- **Finalidade:** Carga e exclusão do registro 1900 da EFD-Contribuições: consolidação dos documentos emitidos no período (receitas por modelo, situação, CST e conta).
- **Método e rota:** POST e DELETE {baseUrl}/API/Migrate/Reg1900 ⚑ A rota pode passar a ser /API/v1/Reg1900.
- **Formato:** JSON (Content-Type: application/json; charset=utf-8).
- **Autenticação:** Header Authorization: Bearer <accessToken> (aba Autenticação).
- **Envio:** Lista "Reg1900" com um ou mais registros e "Usuario" ao lado.
- **Validação:** Erros na lista "erros" (HTTP 422). Com erro, nada é gravado.
- **Reenvio:** O mesmo 1900 reenviado (mesmo período, empresa e dados) é recusado como duplicado (422). Para alterar: excluir e enviar de novo.
- **Exclusão:** DELETE com Usuario na URL e os identificadores no corpo, em lista (aba Exclusão). O registro é apagado; sem registro correspondente: 404.

## Layout Json - Registro 1900 (Envio)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| &nbsp;&nbsp;`Reg1900` | Lista | 1-N | S | Registros 1900. Lista (não aceita objeto único). Lista vazia, objeto no lugar da lista ou outra chave: HTTP 400. Campos no grupo B. |
| &nbsp;&nbsp;`Usuario` | C | 1-1 | S | Usuário responsável pelo envio. Fica fora da lista. Identifica quem enviou a carga. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Empresa` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa), vinculado à chave de parceiro. Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`PeriododeReferencia` | D | 1-1 | S | Período de referência. Primeiro dia do mês (AAAA-MM-01). |
| &nbsp;&nbsp;&nbsp;&nbsp;`CNPJ` | N (14) | 1-1 | S | CNPJ do estabelecimento emitente. Só dígitos. Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`CodModelo` | C (2) | 1-1 | S | Modelo do documento. Tabela 4.1.1 da EFD, além de 98 e 99 (outros documentos). Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Serie` | C (4) | 0-1 | N | Série do documento |
| &nbsp;&nbsp;&nbsp;&nbsp;`SubSerie` | C (20) | 0-1 | N | Subsérie do documento |
| &nbsp;&nbsp;&nbsp;&nbsp;`CodSituacao` | N (2) | 1-1 | S | Situação do documento. Tabela 4.1.2 da EFD (ex.: "00" = regular). Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`TotaldaReceita` | N | 1-1 | S | Valor total da receita. Receita dos documentos emitidos no período. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;`TotaldeDocumentosEmitidos` | N | 0-1 | N | Quantidade de documentos emitidos. Número inteiro. |
| &nbsp;&nbsp;&nbsp;&nbsp;`CSTdoPIS` | N (2) | 1-1 | S | CST do PIS/Pasep. Tabela 4.3.3 da EFD-Contribuições. Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`CSTdaCOFINS` | N (2) | 1-1 | S | CST da Cofins. Tabela 4.3.4 da EFD-Contribuições. Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`CFOP` | N (4) | 0-1 | N | CFOP. Informado: precisa ser válido (422). |
| &nbsp;&nbsp;&nbsp;&nbsp;`InformacaoCompl` | C | 0-1 | N | Informação complementar |
| &nbsp;&nbsp;&nbsp;&nbsp;`CodigoConta` | C (60) | 0-1 | N | Conta contábil. Conta analítica do plano de contas (ex.: 1.01.01.001). Informada e não localizada: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`CrpInProdutoId` | C | 0-1 | N | Identificador do sistema de origem. Vazio quando não houver. |
| &nbsp;&nbsp;&nbsp;&nbsp;`IdOrigem` | C | 0-1 | N | Identificador de origem. Identificador complementar do registro no sistema de origem; também aceito na exclusão. |
| &nbsp;&nbsp;&nbsp;&nbsp;`IdOrigemExt` | C | 1-1 | S | Identificador do registro no sistema de origem. Identifica o registro para a exclusão. |

## Layout - Registro 1900 (Exclusão: Usuario Na Url, Identificadores No Corpo)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| `Usuario` | C | 1-1 | S | Usuário responsável pela exclusão. Parâmetro da URL. |
| `[ ]` | Lista | 1-N | S | Registros a excluir. O corpo é a própria lista (sem chave). Lista vazia: 400. |
| &nbsp;&nbsp;`Empresa` | C | 1-1 | S | Estabelecimento. Código do estabelecimento do registro. Não localizado: 422. |
| &nbsp;&nbsp;`IdOrigemExt` | C | 0-1 | C | Identificador do registro no sistema de origem. O IdOrigemExt enviado na gravação. Informe IdOrigemExt ou IdOrigem (sem nenhum identificador: 400). |
| &nbsp;&nbsp;`IdOrigem` | C | 0-1 | C | Identificador de origem. Alternativa ao IdOrigemExt: o IdOrigem enviado na gravação. CrpInProdutoId como terceira alternativa: [A CONFIRMAR]. |

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Layout/Layout API Migrate - Bloco 1 - 1900.xlsx](Layout/Layout%20API%20Migrate%20-%20Bloco%201%20-%201900.xlsx) | layout de/para com a EFD, retorno, códigos HTTP, erros e exemplos |
| [Exemplos/JSON/reg1900-requisicao.json](Exemplos/JSON/reg1900-requisicao.json) | POST /API/Migrate/Reg1900 - Gravar 1900 |
| [Exemplos/JSON/reg1900-retorno-200.json](Exemplos/JSON/reg1900-retorno-200.json) | HTTP 200 - 1900 gravado |
| [Exemplos/JSON/reg1900-erro-validacao-requisicao.json](Exemplos/JSON/reg1900-erro-validacao-requisicao.json) | POST /API/Migrate/Reg1900 - Erro - estabelecimento não localizado |
| [Exemplos/JSON/reg1900-erro-validacao-retorno-422.json](Exemplos/JSON/reg1900-erro-validacao-retorno-422.json) | HTTP 422 - Estabelecimento não localizado |
| [Exemplos/JSON/reg1900-exclusao-requisicao.json](Exemplos/JSON/reg1900-exclusao-requisicao.json) | DELETE /API/Migrate/Reg1900 - Excluir 1900 |
| [Exemplos/JSON/reg1900-exclusao-retorno-200.json](Exemplos/JSON/reg1900-exclusao-retorno-200.json) | HTTP 200 - 1900 excluído |
| [Exemplos/JSON/reg1900-exclusao-retorno-404.json](Exemplos/JSON/reg1900-exclusao-retorno-404.json) | HTTP 404 - Nenhum registro encontrado |

⚑ = possível ajuste: comportamento atual, que pode mudar em versão futura.
