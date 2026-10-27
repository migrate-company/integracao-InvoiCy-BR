# Bloco H

Exclusão (inativação) do inventário do Bloco H da EFD ICMS/IPI pelo identificador do sistema de origem.

## Operações

| Método | Rota |
|---|---|
| DELETE | `{baseUrl}/API/Migrate/BlocoH` |

Autenticação: header `Authorization: Bearer <accessToken>` (ver [Autenticação](../Autenticacao/README.md)).

## Regras

- **Finalidade:** Exclusão (inativação) do inventário do Bloco H da EFD ICMS/IPI pelo identificador do sistema de origem.
- **Método e rota:** DELETE {baseUrl}/API/Migrate/BlocoH ⚑ A rota pode passar a ser /API/v1/BlocoH.
- **Autenticação:** Header Authorization: Bearer <accessToken> (aba Autenticação).
- **Exclusão:** Idorigemext, Estab e Usuario na URL, sem corpo.
- **Envio:** Esta versão documenta só a exclusão; o envio do inventário não faz parte deste material.

## Exclusão - Delete /Api/Migrate/Blocoh (Parâmetros Da Url)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| `Idorigemext` | C | 1-1 | S | Identificador do inventário no sistema de origem. Identificador externo informado no envio do inventário. Ausente: 400. Sem inventário com esse identificador: 404. |
| `Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa) no sistema, vinculado à chave de parceiro. Ausente: 400. Não localizado: 422. |
| `Usuario` | C | 1-1 | S | Usuário responsável pela exclusão. Identifica quem solicitou a exclusão. |
| `(inventário)` | - | - | - | Inventário do Bloco H. O inventário com o identificador informado é inativado (deixa de compor a escrituração). Repetir a exclusão: 404. |

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Layout/Layout API Migrate - Bloco H.xlsx](Layout/Layout%20API%20Migrate%20-%20Bloco%20H.xlsx) | layout de/para com a EFD, retorno, códigos HTTP, erros e exemplos |
| [Exemplos/JSON/bloco-h-excluir-retorno-200.json](Exemplos/JSON/bloco-h-excluir-retorno-200.json) | HTTP 200 - Inventário inativado |
| [Exemplos/JSON/bloco-h-excluir-nao-encontrado-retorno-404.json](Exemplos/JSON/bloco-h-excluir-nao-encontrado-retorno-404.json) | HTTP 404 - Nada a inativar |
| [Exemplos/JSON/bloco-h-excluir-sem-estab-retorno-400.json](Exemplos/JSON/bloco-h-excluir-sem-estab-retorno-400.json) | HTTP 400 - Parâmetro ausente |

⚑ = possível ajuste: comportamento atual, que pode mudar em versão futura.
