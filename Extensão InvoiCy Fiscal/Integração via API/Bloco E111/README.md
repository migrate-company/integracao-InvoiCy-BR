# Bloco E111

Ajustes da apuração do ICMS (registro E111), com as informações adicionais (E112) e os documentos fiscais (E113) de cada ajuste: gravação e exclusão.

## Operações

| Método | Rota |
|---|---|
| POST | `{baseUrl}/API/Migrate/BlocoE111` |
| DELETE | `{baseUrl}/API/Migrate/BlocoE111` |

Autenticação: header `Authorization: Bearer <accessToken>` (ver [Autenticação](../Autenticacao/README.md)).

## Regras

- **Finalidade:** Ajustes da apuração do ICMS (registro E111 da EFD ICMS/IPI), com as informações adicionais (E112) e os documentos fiscais (E113) de cada ajuste.
- **Métodos e rota:** POST {baseUrl}/API/Migrate/BlocoE111 (gravação) e DELETE {baseUrl}/API/Migrate/BlocoE111 (exclusão). ⚑ A rota pode passar a ser /API/v1/BlocoE111.
- **Formato:** JSON (Content-Type: application/json; charset=utf-8). Valores e números de documento como número JSON. A exclusão não tem corpo: os dados vão na URL.
- **Autenticação:** Header Authorization: Bearer <accessToken> (aba Autenticação).
- **Envio:** Lista "BlocoE111" com um ou mais ajustes, cada um com as listas EstE112LIST e EstE113LIST, e "Usuario" ao lado da lista. Lista vazia: 400.
- **Validação:** Com qualquer erro (HTTP 422), nada é gravado - nem o ajuste, nem os demais ajustes da lista.
- **Dependências:** Código de ajuste ativo na UF do estabelecimento; participante (0150) e item (0200) do E113 já cadastrados.
- **Reenvio:** Reenviar o ajuste com o mesmo estabelecimento, período, código de ajuste e IDORIGEMEXT atualiza o registro, sem duplicar.
- **Exclusão:** Pelo IdOrigemExt e o estabelecimento informados na URL. Sem registro para excluir: 404. Exclusão dos E112 e E113 do ajuste junto com ele: [A CONFIRMAR].
- **Mensagens:** Trate as mensagens pelo início do texto e sem diferenciar acentos.

## Layout Json - Bloco E111 (Envio)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| &nbsp;&nbsp;`BlocoE111` | Lista | 1-N | S | Lista de ajustes da apuração. Lista (array), mesmo com um ajuste só. Lista vazia: 400. Campos de cada ajuste no grupo B. As mensagens de erro citam a posição do ajuste na lista (1 = primeiro) e, no E113, a posição do documento (1.1 = primeiro documento do primeiro ajuste). |
| &nbsp;&nbsp;`Usuario` | C | 1-1 | S | Usuário responsável pelo envio. Fica fora da lista BlocoE111. Identifica quem enviou a carga. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa) no sistema, vinculado à chave de parceiro. Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Periodo` | D | 1-1 | S | Período da apuração. Primeiro dia do mês da apuração, no formato AAAA-MM-DD. Ausente ou fora do dia 1: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`COD_AJ_APUR` | C (8) | 1-1 | S | Código do ajuste da apuração. Código da Tabela 5.1.1 (ajustes da apuração do ICMS) da UF do estabelecimento, ativo. Inexistente ou inativo: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`DESCR_COMPL_AJ` | C | 0-1 | N | Descrição complementar do ajuste |
| &nbsp;&nbsp;&nbsp;&nbsp;`SUBS_TRIB` | C (1) | 0-1 | N | Indicador de substituição tributária. Valores aceitos: [A CONFIRMAR] (o exemplo usa "N"). |
| &nbsp;&nbsp;&nbsp;&nbsp;`DIF_ALIQUOTA` | C (1) | 0-1 | N | Indicador de diferencial de alíquota. Valores aceitos: [A CONFIRMAR] (o exemplo usa "N"). |
| &nbsp;&nbsp;&nbsp;&nbsp;`VL_AJ_APUR` | N (2 decimais) | 1-1 | S | Valor do ajuste da apuração. Número JSON com ponto decimal (ex.: 100.00). |
| &nbsp;&nbsp;&nbsp;&nbsp;`IDORIGEMEXT` | C | 0-1 | C | Identificador do ajuste no sistema de origem. Chave usada para excluir o ajuste pela API (DELETE). Sem ele, o ajuste não pode ser excluído pela API. Obrigatoriedade na gravação: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;`EstE112LIST` | Lista | 0-N | N | Informações adicionais do ajuste (E112). Processos e documentos de arrecadação do ajuste. Campos no grupo C. |
| &nbsp;&nbsp;&nbsp;&nbsp;`EstE113LIST` | Lista | 0-N | N | Documentos fiscais do ajuste (E113). Documentos fiscais relacionados ao ajuste. Campos no grupo D. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`NUM_DA` | C | 0-1 | N | Número do documento de arrecadação |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`NUM_PROC` | C (60) | 0-1 | N | Número do processo |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`IND_PROC` | N (1) | 0-1 | N | Origem do processo. 0 = SEFAZ, 1 = Justiça Federal, 2 = Justiça Estadual, 9 = Outros. No exemplo, número JSON. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`PROC` | C | 0-1 | N | Descrição do processo |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`TXT_COMPL` | C | 0-1 | N | Descrição complementar |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`COD_PART` | C (60) | 0-1 | C | Código do participante. Participante já cadastrado no estabelecimento (registro 0150). Obrigatório quando o documento tem participante. Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`COD_MOD` | C (2) | 1-1 | S | Modelo do documento fiscal. Código da Tabela 4.1.1 (modelos de documentos fiscais). Fora da tabela: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`SERIE` | C (4) | 0-1 | N | Série do documento |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`SUBSERIE` | N (3) | 0-1 | N | Subsérie do documento |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`NUM_DOC` | N (9) | 1-1 | S | Número do documento. No exemplo, número JSON. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`DT_DOC` | D | 1-1 | S | Data de emissão do documento. Formato AAAA-MM-DD. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`COD_ITEM` | C (60) | 0-1 | N | Código do item. Item já cadastrado no estabelecimento (registro 0200), quando informado. Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`VL_AJ_ITEM` | N (2 decimais) | 1-1 | S | Valor do ajuste para o documento/item. Número JSON com ponto decimal. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`CHV_DOCe` | N (44) | 0-1 | N | Chave do documento eletrônico. Só dígitos, enviado como texto. |

## Layout - Exclusão (Parâmetros Da Url)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| `Idorigemext` | C | 1-1 | S | Identificador do ajuste no sistema de origem. O mesmo IDORIGEMEXT enviado na gravação. Atenção à grafia do parâmetro: Idorigemext. Ausente ou vazio: 400. |
| `Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento usado na gravação. Ausente: 400. Não localizado: 422. |
| `Usuario` | C | 1-1 | S | Usuário responsável pela exclusão. Identifica quem pediu a exclusão. |

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Layout/Layout API Migrate - Bloco E111.xlsx](Layout/Layout%20API%20Migrate%20-%20Bloco%20E111.xlsx) | layout de/para com a EFD, retorno, códigos HTTP, erros e exemplos |
| [Exemplos/JSON/bloco-e111-requisicao.json](Exemplos/JSON/bloco-e111-requisicao.json) | POST /API/Migrate/BlocoE111 - Gravar - ajuste com E112 e E113 |
| [Exemplos/JSON/bloco-e111-retorno-200.json](Exemplos/JSON/bloco-e111-retorno-200.json) | HTTP 200 - Ajuste gravado |
| [Exemplos/JSON/bloco-e111-erro-validacao-requisicao.json](Exemplos/JSON/bloco-e111-erro-validacao-requisicao.json) | POST /API/Migrate/BlocoE111 - Erro - período fora do primeiro dia do mês |
| [Exemplos/JSON/bloco-e111-erro-validacao-retorno-422.json](Exemplos/JSON/bloco-e111-erro-validacao-retorno-422.json) | HTTP 422 - Erro de validação |
| [Exemplos/JSON/bloco-e111-erro-lista-vazia-requisicao.json](Exemplos/JSON/bloco-e111-erro-lista-vazia-requisicao.json) | POST /API/Migrate/BlocoE111 - Erro - lista vazia |
| [Exemplos/JSON/bloco-e111-erro-lista-vazia-retorno-400.json](Exemplos/JSON/bloco-e111-erro-lista-vazia-retorno-400.json) | HTTP 400 - Dados inválidos |
| [Exemplos/JSON/bloco-e111-exclusao-retorno-200.json](Exemplos/JSON/bloco-e111-exclusao-retorno-200.json) | HTTP 200 - Ajuste excluído |
| [Exemplos/JSON/bloco-e111-exclusao-retorno-404.json](Exemplos/JSON/bloco-e111-exclusao-retorno-404.json) | HTTP 404 - Nada para excluir |
| [Exemplos/JSON/bloco-e111-exclusao-erro-retorno-400.json](Exemplos/JSON/bloco-e111-exclusao-erro-retorno-400.json) | HTTP 400 - Parâmetro obrigatório |

⚑ = possível ajuste: comportamento atual, que pode mudar em versão futura.
