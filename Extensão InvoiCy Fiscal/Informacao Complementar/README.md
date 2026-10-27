# Informação Complementar

Cadastro das informações complementares (código e texto) citadas nos documentos fiscais, base do registro 0450 da EFD.

## Operações

| Método | Rota |
|---|---|
| POST | `{baseUrl}/API/Migrate/InfComplementar` |

Autenticação: header `Authorization: Bearer <accessToken>` (ver [Autenticação](../Autenticacao/README.md)).

## Regras

- **Finalidade:** Cadastro das informações complementares (código e texto) citadas nos documentos fiscais, base do registro 0450 da EFD.
- **Método e rota:** POST {baseUrl}/API/Migrate/InfComplementar ⚑ A rota pode passar a ser /API/v1/InfComplementar.
- **Formato:** JSON (Content-Type: application/json; charset=utf-8).
- **Autenticação:** Header Authorization: Bearer <accessToken> (aba Autenticação).
- **Envio:** Uma informação complementar por requisição, no objeto "InfComplementar", com "Usuario" ao lado.
- **Nomes dos campos:** Este endpoint usa CodEstab, DtInicial, CodInf e Txt (os demais cadastros usam Estab e Dt_Inicial).
- **Limites:** Código com até 6 caracteres e texto com até 255; acima disso, 422.
- **Validação:** Com qualquer erro (HTTP 422), nada é gravado.
- **Reenvio do mesmo código:** Comportamento ao reenviar um CodInf já cadastrado: [A CONFIRMAR].
- **Exclusão:** Não há endpoint de exclusão de informação complementar.
- **Mensagens:** Os textos de erro deste endpoint vêm sem acento. Trate as mensagens pelo início do texto.

## Layout Json - Informação Complementar (Envio)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| &nbsp;&nbsp;`InfComplementar` | Objeto | 1-1 | S | Dados da informação complementar. Objeto (não é lista). Campos no grupo B. Atenção aos nomes: CodEstab, DtInicial, CodInf e Txt (sem sublinhado). |
| &nbsp;&nbsp;`Usuario` | C | 1-1 | S | Usuário responsável pelo envio. Fica fora do objeto InfComplementar. Identifica quem enviou a carga. |
| &nbsp;&nbsp;&nbsp;&nbsp;`CodEstab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa) no sistema, vinculado à chave de parceiro. Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`DtInicial` | D | 1-1 | S | Data inicial da vigência. Data a partir da qual o cadastro vale, no formato AAAA-MM-DD. |
| &nbsp;&nbsp;&nbsp;&nbsp;`CodInf` | C (6) | 1-1 | S | Código da informação complementar. Até 6 caracteres; mais que isso: 422. Referenciado nos documentos fiscais. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Txt` | C (255) | 1-1 | S | Texto da informação complementar. Até 255 caracteres; mais que isso: 422. |

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Layout/Layout API Migrate - Informação Complementar.xlsx](Layout/Layout%20API%20Migrate%20-%20Informação%20Complementar.xlsx) | layout de/para com a EFD, retorno, códigos HTTP, erros e exemplos |
| [Exemplos/JSON/informacao-complementar-requisicao.json](Exemplos/JSON/informacao-complementar-requisicao.json) | POST /API/Migrate/InfComplementar - Gravar - informação complementar |
| [Exemplos/JSON/informacao-complementar-retorno-200.json](Exemplos/JSON/informacao-complementar-retorno-200.json) | HTTP 200 - Informação complementar gravada |
| [Exemplos/JSON/informacao-complementar-erro-validacao-requisicao.json](Exemplos/JSON/informacao-complementar-erro-validacao-requisicao.json) | POST /API/Migrate/InfComplementar - Erro - código com mais de 6 caracteres |
| [Exemplos/JSON/informacao-complementar-erro-validacao-retorno-422.json](Exemplos/JSON/informacao-complementar-erro-validacao-retorno-422.json) | HTTP 422 - Erro de validação |

⚑ = possível ajuste: comportamento atual, que pode mudar em versão futura.
