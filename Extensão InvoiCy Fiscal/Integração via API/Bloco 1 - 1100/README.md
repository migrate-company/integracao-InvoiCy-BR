# Bloco 1 - 1100

Informações sobre exportação (registros 1100, 1105 e 1110 do Bloco 1 da EFD ICMS/IPI), com envio e exclusão.

## Operações

| Método | Rota |
|---|---|
| POST | `{baseUrl}/API/Migrate/Reg1100` |
| DELETE | `{baseUrl}/API/Migrate/Reg1100` |

Autenticação: header `Authorization: Bearer <accessToken>` (ver [Autenticação](../Autenticacao/README.md)).

## Regras

- **Finalidade:** Envio e exclusão das informações sobre exportação do Bloco 1 da EFD ICMS/IPI: declaração (1100), documentos de exportação (1105) e operações de exportação indireta (1110).
- **Métodos e rota:** POST e DELETE {baseUrl}/API/Migrate/Reg1100 ⚑ A rota pode passar a ser /API/v1/Reg1100.
- **Formato:** JSON (Content-Type: application/json; charset=utf-8).
- **Autenticação:** Header Authorization: Bearer <accessToken> (aba Autenticação).
- **Envio:** Lista "Reg1100" (1105 e 1110 dentro de cada 1100), com "Usuario" ao lado.
- **Validação:** Erros de validação retornam na lista "erros" (HTTP 422); nada é gravado.
- **País:** Códigos de país aceitos no campo Pais: [A CONFIRMAR].
- **Exclusão:** DELETE com Usuario na URL e Estab, CrpInProdutoId, IdOrigem e IdOrigemExt no corpo (objeto).

## Layout Json - Registro 1100 (Envio)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| &nbsp;&nbsp;`Reg1100` | Lista | 1-N | S | Lista de 1100. Lista (não objeto). Lista vazia, objeto no lugar de lista ou outra chave: 400. Campos no grupo B. |
| &nbsp;&nbsp;`Usuario` | C | 1-1 | S | Usuário responsável pelo envio. Fica fora da lista "Reg1100". Identifica quem enviou a carga. |
| &nbsp;&nbsp;`(item)` | Objeto | 1-N | S | Registro de informações sobre exportação |
| &nbsp;&nbsp;&nbsp;&nbsp;`Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa) no sistema, vinculado à chave de parceiro. Ausente ou não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Ind_Doc` | C (1) | 1-1 | S | Tipo do documento de exportação. 0 = declaração de exportação; 1 = declaração simplificada de exportação; 2 = declaração única de exportação. Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Nro_De` | C (14) | 1-1 | S | Número da declaração. Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Dt_De` | D | 1-1 | S | Data da declaração. Data AAAA-MM-DD. Fora do formato: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Nat_Exp` | C (1) | 1-1 | S | Natureza da exportação. 0 = exportação direta; 1 = exportação indireta. Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Nro_Re` | N (12) | 0-1 | [A CONFIRMAR] | Número do registro de exportação |
| &nbsp;&nbsp;&nbsp;&nbsp;`Dt_Re` | D | 0-1 | [A CONFIRMAR] | Data do registro de exportação. Data AAAA-MM-DD. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Chc_Emb` | C (18) | 0-1 | [A CONFIRMAR] | Número do conhecimento de embarque |
| &nbsp;&nbsp;&nbsp;&nbsp;`Dt_Chc` | D | 0-1 | [A CONFIRMAR] | Data do conhecimento de embarque. Data AAAA-MM-DD. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Dt_Avb` | D | 1-1 | S | Data da averbação da declaração. Data AAAA-MM-DD. Fora do formato: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Tp_Chc` | N (2) | 1-1 | S | Tipo do conhecimento de embarque. Código da tabela de tipos de conhecimento da EFD (ex.: "01" = AWB). Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Pais` | N (3) | 1-1 | S | País de destino. Códigos aceitos: [A CONFIRMAR]. Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`CrpInProdutoId` | N | 0-1 | N | Identificador do sistema de origem. Informe o mesmo valor na exclusão (0 quando não houver). |
| &nbsp;&nbsp;&nbsp;&nbsp;`IdOrigem` | N | 0-1 | N | Identificador interno no sistema de origem. Informe o mesmo valor na exclusão (0 quando não houver). |
| &nbsp;&nbsp;&nbsp;&nbsp;`IdOrigemExt` | C | 1-1 | S | Identificador do registro no sistema de origem. Chave usada na exclusão. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Est1105List` | L | 0-N | N | Lista de 1105 (documentos de exportação). Campos no grupo C. |
| &nbsp;&nbsp;&nbsp;&nbsp;`(item)` | Objeto | 0-N | N | Documentos fiscais de exportação |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ID1100` | C | 1-1 | [A CONFIRMAR] | Vínculo com o 1100. Conteúdo esperado: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Mod` | C (2) | 1-1 | S | Modelo do documento fiscal. Ex.: "55" (NF-e). Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Serie` | C (3) | 0-1 | N | Série do documento fiscal |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Num_Doc` | N (9) | 1-1 | S | Número do documento fiscal. Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Chv_Nfe` | N (44) | 0-1 | N | Chave da NF-e |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Dt_Doc` | D | 1-1 | S | Data de emissão do documento. Data AAAA-MM-DD. Inválida: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Item` | C (60) | 1-1 | S | Código do item exportado. Item cadastrado. Ausente ou inexistente: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Est1110List` | L | 0-N | N | Lista de 1110 (exportação indireta). Campos no grupo D. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`(item)` | Objeto | 0-N | N | Operações de exportação indireta - mercadorias de terceiros |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`ID1105` | C | 1-1 | [A CONFIRMAR] | Vínculo com o 1105. Conteúdo esperado: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Part` | C (60) | 1-1 | S | Código do participante (remetente). Participante cadastrado. Ausente: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Mod` | C (2) | 1-1 | S | Modelo do documento fiscal. Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ser` | C (4) | 0-1 | N | Série do documento fiscal |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Num_Doc` | N (9) | 1-1 | S | Número do documento fiscal. Não negativo. Inválido: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Dt_Doc` | D | 1-1 | S | Data de emissão do documento. Data AAAA-MM-DD. Inválida: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Chv_Nfe` | N (44) | 0-1 | N | Chave da NF-e |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Nr_Memo` | C | 0-1 | [A CONFIRMAR] | Número do memorando de exportação |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Qtd` | N (-,3) | 1-1 | S | Quantidade do item efetivamente exportado. Inválida: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Unid` | C (6) | 1-1 | S | Unidade do item. Unidade cadastrada do item. Inválida: 422. |

## Exclusão - Delete /Api/Migrate/Reg1100 (Identificadores No Corpo)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| `Usuario` | C | 1-1 | S | Usuário responsável pela exclusão. Identifica quem solicitou a exclusão. |
| &nbsp;&nbsp;`Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento. Ausente: 400. Não localizado: 422. |
| &nbsp;&nbsp;`CrpInProdutoId` | N | 1-1 | S | Identificador do sistema de origem. O mesmo valor do envio (0 quando não houver). |
| &nbsp;&nbsp;`IdOrigem` | N | 1-1 | S | Identificador interno no sistema de origem. O mesmo valor do envio (0 quando não houver). |
| &nbsp;&nbsp;`IdOrigemExt` | C | 1-1 | S | Identificador do registro no sistema de origem. O mesmo IdOrigemExt do envio. Sem registro: 404. |
| `(registros)` | - | - | - | 1100 e seus 1105/1110. O 1100 localizado e os registros filhos são excluídos. Repetir a exclusão: 404. |

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Layout/Layout API Migrate - Bloco 1 - 1100.xlsx](Layout/Layout%20API%20Migrate%20-%20Bloco%201%20-%201100.xlsx) | layout de/para com a EFD, retorno, códigos HTTP, erros e exemplos |
| [Exemplos/JSON/reg1100-gravar-requisicao.json](Exemplos/JSON/reg1100-gravar-requisicao.json) | POST /API/Migrate/Reg1100 - Gravar - 1100 com 1105 e 1110 |
| [Exemplos/JSON/reg1100-gravar-retorno-200.json](Exemplos/JSON/reg1100-gravar-retorno-200.json) | HTTP 200 - 1100 gravado |
| [Exemplos/JSON/reg1100-erro-validacao-requisicao.json](Exemplos/JSON/reg1100-erro-validacao-requisicao.json) | POST /API/Migrate/Reg1100 - Erro - estabelecimento não localizado |
| [Exemplos/JSON/reg1100-erro-validacao-retorno-422.json](Exemplos/JSON/reg1100-erro-validacao-retorno-422.json) | HTTP 422 - Erro de validação |
| [Exemplos/JSON/reg1100-excluir-requisicao.json](Exemplos/JSON/reg1100-excluir-requisicao.json) | DELETE /API/Migrate/Reg1100 - Excluir - 1100 pelos identificadores (corpo) |
| [Exemplos/JSON/reg1100-excluir-retorno-200.json](Exemplos/JSON/reg1100-excluir-retorno-200.json) | HTTP 200 - 1100 excluído |
| [Exemplos/JSON/reg1100-excluir-nao-encontrado-requisicao.json](Exemplos/JSON/reg1100-excluir-nao-encontrado-requisicao.json) | DELETE /API/Migrate/Reg1100 - Erro - excluir sem registro |
| [Exemplos/JSON/reg1100-excluir-nao-encontrado-retorno-404.json](Exemplos/JSON/reg1100-excluir-nao-encontrado-retorno-404.json) | HTTP 404 - Nada a excluir |

⚑ = possível ajuste: comportamento atual, que pode mudar em versão futura.
