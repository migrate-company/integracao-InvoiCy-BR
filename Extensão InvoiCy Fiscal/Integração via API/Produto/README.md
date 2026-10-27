# Produto

Cadastro de produtos e serviços (itens), base do registro 0200 da EFD.

## Operações

| Método | Rota |
|---|---|
| POST | `{baseUrl}/API/Migrate/Produto` |

Autenticação: header `Authorization: Bearer <accessToken>` (ver [Autenticação](../Autenticacao/README.md)).

## Regras

- **Finalidade:** Cadastro de produtos e serviços (itens), base do registro 0200 da EFD.
- **Método e rota:** POST {baseUrl}/API/Migrate/Produto ⚑ A rota pode passar a ser /API/v1/Produto.
- **Formato:** JSON (Content-Type: application/json; charset=utf-8).
- **Autenticação:** Header Authorization: Bearer <accessToken> (aba Autenticação).
- **Envio:** Um item por requisição, no objeto "Produto", com "Usuario" ao lado.
- **Validação:** A validação para no primeiro erro encontrado: a lista "erros" (HTTP 422) traz um erro por vez. Com erro, nada é gravado.
- **Dependências:** A unidade de medida (Unid_Inv) e o NCM precisam existir nos cadastros do sistema.
- **Reenvio do mesmo código:** Comportamento ao reenviar um Cod_Item já cadastrado: [A CONFIRMAR].
- **Exclusão:** Não há endpoint de exclusão de produto.
- **Fora desta versão:** Gênero, código de serviço, combustível, CEST, conversões de unidade (0220) e itens correlacionados (0221).
- **Mensagens:** Trate as mensagens pelo início do texto e sem diferenciar acentos.

## Layout Json - Produto (Envio)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| &nbsp;&nbsp;`Produto` | Objeto | 1-1 | S | Dados do item. Objeto (não é lista). Campos no grupo B. |
| &nbsp;&nbsp;`Usuario` | C | 1-1 | S | Usuário responsável pelo envio. Fica fora do objeto Produto. Identifica quem enviou a carga. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa) no sistema, vinculado à chave de parceiro. Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Dt_Inicial` | D | 1-1 | S | Data inicial da vigência. Data a partir da qual o cadastro vale, no formato AAAA-MM-DD. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Cod_Item` | C (60) | 1-1 | S | Código do item. Código de identificação do item, único por estabelecimento. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Descr_Item` | C | 1-1 | S | Descrição do item |
| &nbsp;&nbsp;&nbsp;&nbsp;`Tipo_Item` | N (2) | 1-1 | S | Tipo do item. Tabela do campo TIPO_ITEM da EFD: 00 mercadoria para revenda, 01 matéria-prima, 02 embalagem, 03 produto em processo, 04 produto acabado, 05 subproduto, 06 produto intermediário, 07 material de uso e consumo, 08 ativo imobilizado, 09 serviços, 10 outros insumos, 99 outras. Valor fora da tabela: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Unid_Inv` | C (6) | 1-1 | S | Unidade de medida do estoque. Código de unidade de medida já cadastrado (base do registro 0190). Unidade não cadastrada: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;`NCM` | C (8) | 0-1 | N | Código NCM. Nomenclatura Comum do Mercosul, 8 dígitos. Código inexistente: 422. |

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Layout/Layout API Migrate - Produto.xlsx](Layout/Layout%20API%20Migrate%20-%20Produto.xlsx) | layout de/para com a EFD, retorno, códigos HTTP, erros e exemplos |
| [Exemplos/JSON/produto-item-requisicao.json](Exemplos/JSON/produto-item-requisicao.json) | POST /API/Migrate/Produto - Gravar - item |
| [Exemplos/JSON/produto-item-retorno-200.json](Exemplos/JSON/produto-item-retorno-200.json) | HTTP 200 - Item gravado |
| [Exemplos/JSON/produto-erro-validacao-requisicao.json](Exemplos/JSON/produto-erro-validacao-requisicao.json) | POST /API/Migrate/Produto - Erro - unidade não cadastrada |
| [Exemplos/JSON/produto-erro-validacao-retorno-422.json](Exemplos/JSON/produto-erro-validacao-retorno-422.json) | HTTP 422 - Erro de validação |

⚑ = possível ajuste: comportamento atual, que pode mudar em versão futura.
