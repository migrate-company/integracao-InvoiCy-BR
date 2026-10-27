# Centro de Custo

Cadastro de centros de custo, base do registro 0600 da EFD.

## Operações

| Método | Rota |
|---|---|
| POST | `{baseUrl}/API/Migrate/Reg0600` |

Autenticação: header `Authorization: Bearer <accessToken>` (ver [Autenticação](../Autenticacao/README.md)).

## Regras

- **Finalidade:** Cadastro de centros de custo, base do registro 0600 da EFD.
- **Método e rota:** POST {baseUrl}/API/Migrate/Reg0600 ⚑ A rota pode passar a ser /API/v1/Reg0600.
- **Formato:** JSON (Content-Type: application/json; charset=utf-8).
- **Autenticação:** Header Authorization: Bearer <accessToken> (aba Autenticação).
- **Envio:** Lista "Reg0600" com um ou mais centros de custo, com "Usuario" ao lado da lista.
- **Validação:** Com qualquer erro (HTTP 422), nada é gravado. As mensagens citam a posição do item na lista.
- **Lista vazia:** Lista vazia ou corpo sem a chave "Reg0600": hoje responde 200 sem gravar nada. ⚑ Hoje, lista vazia ou corpo sem a chave "Reg0600" responde 200 (sucesso: true) sem gravar nada. Pode passar a responder 400 com "Dados enviados invalidos." na lista erros.
- **Reenvio do mesmo código:** Comportamento ao reenviar um Cod_Ccus já cadastrado: [A CONFIRMAR].
- **Exclusão:** Não há endpoint de exclusão de centro de custo.
- **Mensagens:** Trate as mensagens pelo início do texto e sem diferenciar acentos.

## Layout Json - Centro De Custo (Envio)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| &nbsp;&nbsp;`Reg0600` | Lista | 1-N | S | Lista de centros de custo. Lista (array), mesmo com um centro de custo só. Campos de cada item no grupo B. As mensagens de erro citam a posição do item na lista (1 = primeiro). ⚑ Hoje, lista vazia ou corpo sem a chave "Reg0600" responde 200 (sucesso: true) sem gravar nada. Pode passar a responder 400 com "Dados enviados invalidos." na lista erros. |
| &nbsp;&nbsp;`Usuario` | C | 1-1 | S | Usuário responsável pelo envio. Fica fora da lista Reg0600. Identifica quem enviou a carga. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa) no sistema, vinculado à chave de parceiro. Não informado ou não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Dt_Inicial` | D | 1-1 | S | Data inicial da vigência. Data a partir da qual o cadastro vale, no formato AAAA-MM-DD. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cod_Ccus` | C (60) | 1-1 | S | Código do centro de custo |
| &nbsp;&nbsp;&nbsp;&nbsp;`Ccus` | C (60) | 1-1 | S | Nome do centro de custo |

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Layout/Layout API Migrate - Centro de Custo.xlsx](Layout/Layout%20API%20Migrate%20-%20Centro%20de%20Custo.xlsx) | layout de/para com a EFD, retorno, códigos HTTP, erros e exemplos |
| [Exemplos/JSON/centro-custo-requisicao.json](Exemplos/JSON/centro-custo-requisicao.json) | POST /API/Migrate/Reg0600 - Gravar - centro de custo |
| [Exemplos/JSON/centro-custo-retorno-200.json](Exemplos/JSON/centro-custo-retorno-200.json) | HTTP 200 - Centro de custo gravado |
| [Exemplos/JSON/centro-custo-erro-validacao-requisicao.json](Exemplos/JSON/centro-custo-erro-validacao-requisicao.json) | POST /API/Migrate/Reg0600 - Erro - descrição não informada |
| [Exemplos/JSON/centro-custo-erro-validacao-retorno-422.json](Exemplos/JSON/centro-custo-erro-validacao-retorno-422.json) | HTTP 422 - Erro de validação |

⚑ = possível ajuste: comportamento atual, que pode mudar em versão futura.
