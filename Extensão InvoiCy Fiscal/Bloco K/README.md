# Bloco K

Controle da produção e do estoque: período de apuração (K100) e estoque escriturado (K200) do Bloco K da EFD ICMS/IPI, com envio e exclusão.

## Operações

| Método | Rota |
|---|---|
| POST | `{baseUrl}/API/Migrate/BlocoKNew` |
| DELETE | `{baseUrl}/API/Migrate/BlocoKNew` |

Autenticação: header `Authorization: Bearer <accessToken>` (ver [Autenticação](../Autenticacao/README.md)).

## Regras

- **Finalidade:** Envio e exclusão do Bloco K da EFD ICMS/IPI: período de apuração (K100) e estoque escriturado (K200).
- **Métodos e rota:** POST e DELETE {baseUrl}/API/Migrate/BlocoKNew ⚑ A rota pode passar a ser /API/v1/BlocoKNew.
- **Formato:** JSON (Content-Type: application/json; charset=utf-8).
- **Autenticação:** Header Authorization: Bearer <accessToken> (aba Autenticação).
- **Envio:** Objeto "BlocoKNew" com a lista "EstK100_New" (K100 com a lista de K200 dentro) e "Usuario" ao lado. ⚑ Hoje a lista "EstK100_New" vazia (ou os registros fora da chave "BlocoKNew") responde 200 com sucesso = true e nada é gravado. Pode passar a responder 400 "Dados enviados invalidos.".
- **Usuario:** Nome de um usuário cadastrado no sistema (não o código nem o e-mail).
- **Validação:** Erros de validação retornam na lista "erros" (HTTP 422). ⚑ Hoje um envio recusado (422) por erro em um K200 pode deixar o K100 gravado, sem os K200. Previsto: com qualquer erro, nada é gravado. Até lá, após um 422, exclua pela OrigemExterna (DELETE) ou reenvie corrigido.
- **Reenvio:** Reenviar a mesma carga mantém o K100 do período e inclui novamente os K200 enviados. Para substituir, exclua pela OrigemExterna e envie de novo.
- **Exclusão:** DELETE com Idorigemext, Estab e Usuario na URL: inativa o K100 e todos os registros filhos com a OrigemExterna informada.
- **Fora desta versão:** Registros K210 a K302.

## Layout Json - Bloco K (Envio)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| &nbsp;&nbsp;`BlocoKNew` | Objeto | 1-1 | S | Carga do Bloco K. Objeto com a lista EstK100_New. ⚑ Hoje a lista "EstK100_New" vazia (ou os registros fora da chave "BlocoKNew") responde 200 com sucesso = true e nada é gravado. Pode passar a responder 400 "Dados enviados invalidos.". |
| &nbsp;&nbsp;&nbsp;&nbsp;`EstK100_New` | Lista | 1-N | S | Lista de K100 (período de apuração). Um item por estabelecimento e período. Campos no grupo B. ⚑ Hoje a lista "EstK100_New" vazia (ou os registros fora da chave "BlocoKNew") responde 200 com sucesso = true e nada é gravado. Pode passar a responder 400 "Dados enviados invalidos.". |
| &nbsp;&nbsp;`Usuario` | C | 1-1 | S | Usuário responsável pelo envio. Fica fora do objeto BlocoKNew. Nome de um usuário cadastrado no sistema (não é o código nem o e-mail). Ausente ou não encontrado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`(item)` | Objeto | 1-N | S | Período de apuração do ICMS/IPI |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`OrigemExterna` | C | 1-1 | S | Identificador do registro no sistema de origem. Chave usada na exclusão. Use a mesma OrigemExterna no K100 e nos K200 dele para que uma exclusão inative todos juntos. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Periodo` | C | 1-1 | S | Período de apuração. Formato MM/AAAA ou DD/MM/AAAA. Ausente ou inválido (ex.: mês 13): 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`CodigoEstab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa) no sistema, vinculado à chave de parceiro. Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`EstK200List` | L | 0-N | N | Lista de K200 do período. Campos no grupo C. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`(item)` | Objeto | 0-N | C | Estoque escriturado |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`OrigemExterna` | C | 1-1 | S | Identificador do registro no sistema de origem. Informe a mesma OrigemExterna do K100: a exclusão inativa todo registro com a OrigemExterna informada; com origem diferente, o K200 continua ativo. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`IdOrigem` | C | 0-1 | N | Identificador interno no sistema de origem. Uso na API: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`CodItem` | C (60) | 1-1 | S | Código do item. Item cadastrado e vigente no período. Ausente, inexistente ou fora de vigência: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Qtd` | C | 1-1 | S | Quantidade em estoque. Texto com vírgula decimal (ex.: "1,5"). Até 3 casas decimais (EFD). Ausente: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`IndEst` | C (1) | 1-1 | S | Indicador do tipo de estoque. 0 = estoque de propriedade do informante e em seu poder; 1 = de propriedade do informante e em posse de terceiros; 2 = de propriedade de terceiros e em posse do informante. Ausente ou fora do domínio: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`CodPart` | C (60) | 0-1 | C | Código do participante. Obrigatório quando IndEst = 1 ou 2 (o terceiro). Participante cadastrado e vigente no período. |

## Exclusão - Delete /Api/Migrate/Blocoknew (Parâmetros Da Url)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| `Idorigemext` | C | 1-1 | S | OrigemExterna dos registros a inativar. Inativa o K100 e todos os registros filhos com essa OrigemExterna. Ausente: 400. Nada a inativar: 404. |
| `Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento. Não localizado: 422. ⚑ Hoje a exclusão sem Estab responde 422 "Empresa/Estabelecimento nao encontrado: " (valor vazio). Pode passar a responder 400 (parâmetro obrigatório). |
| `Usuario` | C | 1-1 | S | Usuário responsável pela exclusão. Nome de um usuário cadastrado, como no envio. |
| `(registros)` | - | - | - | K100 e filhos com a OrigemExterna. Os registros são inativados (deixam de compor a escrituração). Repetir a exclusão: 404. |

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Layout/Layout API Migrate - Bloco K.xlsx](Layout/Layout%20API%20Migrate%20-%20Bloco%20K.xlsx) | layout de/para com a EFD, retorno, códigos HTTP, erros e exemplos |
| [Exemplos/JSON/bloco-k-gravar-requisicao.json](Exemplos/JSON/bloco-k-gravar-requisicao.json) | POST /API/Migrate/BlocoKNew - Gravar - K100 com K200 |
| [Exemplos/JSON/bloco-k-gravar-retorno-200.json](Exemplos/JSON/bloco-k-gravar-retorno-200.json) | HTTP 200 - Bloco K gravado |
| [Exemplos/JSON/bloco-k-erro-validacao-requisicao.json](Exemplos/JSON/bloco-k-erro-validacao-requisicao.json) | POST /API/Migrate/BlocoKNew - Erro - K200 sem participante com IndEst 1 |
| [Exemplos/JSON/bloco-k-erro-validacao-retorno-422.json](Exemplos/JSON/bloco-k-erro-validacao-retorno-422.json) | HTTP 422 - Erro de validação |
| [Exemplos/JSON/bloco-k-excluir-retorno-200.json](Exemplos/JSON/bloco-k-excluir-retorno-200.json) | HTTP 200 - Registros inativados |
| [Exemplos/JSON/bloco-k-excluir-nao-encontrado-retorno-404.json](Exemplos/JSON/bloco-k-excluir-nao-encontrado-retorno-404.json) | HTTP 404 - Nada a inativar |

⚑ = possível ajuste: comportamento atual, que pode mudar em versão futura.
