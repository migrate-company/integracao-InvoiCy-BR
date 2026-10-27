# Participante

Cadastro de participantes (clientes, fornecedores e demais pessoas com quem o estabelecimento opera), base do registro 0150 da EFD.

## Operações

| Método | Rota |
|---|---|
| POST | `{baseUrl}/API/Migrate/Participante` |

Autenticação: header `Authorization: Bearer <accessToken>` (ver [Autenticação](../Autenticacao/README.md)).

## Regras

- **Finalidade:** Cadastro de participantes (clientes, fornecedores e demais pessoas com quem o estabelecimento opera), base do registro 0150 da EFD.
- **Método e rota:** POST {baseUrl}/API/Migrate/Participante ⚑ A rota pode passar a ser /API/v1/Participante.
- **Formato:** JSON (Content-Type: application/json; charset=utf-8).
- **Autenticação:** Header Authorization: Bearer <accessToken> (aba Autenticação).
- **Envio:** Um participante por requisição, no objeto "Participante", com "Usuario" ao lado.
- **Validação:** Todos os erros encontrados retornam juntos na lista "erros" (HTTP 422). Com qualquer erro, nada é gravado.
- **Exclusão:** Não há endpoint de exclusão de participante.
- **Fora desta versão:** Blocos complementares do participante (dependentes, sociedade em conta de participação, plano de saúde e FCI).

## Layout Json - Participante (Envio)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| &nbsp;&nbsp;`Participante` | Objeto | 1-1 | S | Dados do participante. Objeto (não é lista). Campos no grupo B. |
| &nbsp;&nbsp;`Usuario` | C | 1-1 | S | Usuário responsável pelo envio. Fica fora do objeto Participante. Identifica quem enviou a carga. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa) no sistema, vinculado à chave de parceiro. Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cod_Part` | C (60) | 1-1 | S | Código do participante. Código de identificação do participante, único por estabelecimento. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Nome` | C (100) | 1-1 | S | Nome. Nome pessoal ou empresarial. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Pais` | N (5) | 0-1 | N | País. Código do país da tabela do Banco Central (ex.: 1058 = Brasil). Não informado: Brasil (1058). Código inexistente: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`CNPJ` | N (14) | 0-1 | C | CNPJ. Pessoa jurídica. Informar CNPJ ou CPF, nunca os dois. Um dos dois é obrigatório quando o país exige documento (Brasil). |
| &nbsp;&nbsp;&nbsp;&nbsp;`CPF` | N (11) | 0-1 | C | CPF. Pessoa física. Mesma regra do CNPJ. |
| &nbsp;&nbsp;&nbsp;&nbsp;`IE` | C (14) | 0-1 | N | Inscrição estadual. Inscrição estadual do participante (ex.: "ISENTO"). |
| &nbsp;&nbsp;&nbsp;&nbsp;`Municipio` | N (7) | 1-1 | S | Município. Código IBGE do município (7 dígitos). Exterior: 9999999. Código inexistente: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`End` | C (60) | 1-1 | S | Endereço. Logradouro. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Num` | C | 0-1 | N | Número. Número do imóvel. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Compl` | C (60) | 0-1 | N | Complemento |
| &nbsp;&nbsp;&nbsp;&nbsp;`Bairro` | C (60) | 0-1 | N | Bairro |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cep` | N (8) | 0-1 | N | CEP. Só dígitos. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Telefone` | C | 0-1 | N | Telefone. Só dígitos, com DDD. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Dt_Inicial` | D | 1-1 | S | Data inicial da vigência. Data a partir da qual o cadastro vale, no formato AAAA-MM-DD. |
| &nbsp;&nbsp;&nbsp;&nbsp;`IsSimplesNacional` | C | 0-1 | N | Optante do Simples Nacional. Valores aceitos: [A CONFIRMAR]. Valor fora do domínio: 422. |

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Layout/Layout API Migrate - Participante.xlsx](Layout/Layout%20API%20Migrate%20-%20Participante.xlsx) | layout de/para com a EFD, retorno, códigos HTTP, erros e exemplos |
| [Exemplos/JSON/participante-pessoa-juridica-requisicao.json](Exemplos/JSON/participante-pessoa-juridica-requisicao.json) | POST /API/Migrate/Participante - Gravar - pessoa jurídica (CNPJ) |
| [Exemplos/JSON/participante-pessoa-juridica-retorno-200.json](Exemplos/JSON/participante-pessoa-juridica-retorno-200.json) | HTTP 200 - Participante gravado |
| [Exemplos/JSON/participante-pessoa-fisica-requisicao.json](Exemplos/JSON/participante-pessoa-fisica-requisicao.json) | POST /API/Migrate/Participante - Gravar - pessoa física (CPF) |
| [Exemplos/JSON/participante-pessoa-fisica-retorno-200.json](Exemplos/JSON/participante-pessoa-fisica-retorno-200.json) | HTTP 200 - Participante gravado |
| [Exemplos/JSON/participante-erro-validacao-requisicao.json](Exemplos/JSON/participante-erro-validacao-requisicao.json) | POST /API/Migrate/Participante - Erro - CPF e CNPJ juntos e município inexistente |
| [Exemplos/JSON/participante-erro-validacao-retorno-422.json](Exemplos/JSON/participante-erro-validacao-retorno-422.json) | HTTP 422 - Erros de validação |

⚑ = possível ajuste: comportamento atual, que pode mudar em versão futura.
