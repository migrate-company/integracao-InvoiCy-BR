# Bloco F - F120 e F130

Carga dos registros F130 (crédito sobre o valor de aquisição) e F120 (crédito sobre depreciação/amortização) de bens do ativo imobilizado, na EFD-Contribuições.

## Operações

| Método | Rota |
|---|---|
| POST | `{baseUrl}/API/Migrate/BlocoF` |

Autenticação: header `Authorization: Bearer <accessToken>` (ver [Autenticação](../Autenticacao/README.md)).

## Regras

- **Finalidade:** Carga dos registros F130 (crédito sobre o valor de aquisição) e F120 (crédito sobre depreciação/amortização) de bens do ativo imobilizado, na EFD-Contribuições.
- **Método e rota:** POST {baseUrl}/API/Migrate/BlocoF ⚑ A rota pode passar a ser /API/v1/BlocoF.
- **Formato:** JSON (Content-Type: application/json; charset=utf-8).
- **Autenticação:** Header Authorization: Bearer <accessToken> (aba Autenticação).
- **Envio:** Lista "BlocoF" (cada item com EstF130 e/ou EstF120) e, fora da lista, DtIni, DtFin, Estabs e Usuario.
- **Campos da carga:** DtIni, DtFin (DD/MM/AAAA) e Estabs são exigidos hoje. ⚑ Exigido hoje. O contrato previsto não traz DtIni, DtFin e Estabs: podem deixar de ser necessários (período e estabelecimento vindo só de cada registro).
- **Validação:** Erros na lista "erros" (HTTP 422). Com erro, nada é gravado.
- **Reenvio:** O mesmo bem reenviado no período responde 200 e não é duplicado. ⚑ Hoje o reenvio do mesmo bem no período responde 200 e não duplica. Pode passar a responder 422 "Ja Existe um Registro F130 (ou F120) Contendo essas informacoes..." (para alterar: excluir e reenviar).
- **Exclusão:** Não há endpoint de exclusão do F120/F130.

## Layout Json - Bloco F, F120 E F130 (Envio)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| &nbsp;&nbsp;`BlocoF` | Lista | 1-N | S | Bens da carga. Lista de itens; cada item traz o F130 e/ou o F120 de um bem (grupo B). Lista vazia, objeto no lugar da lista ou outra chave: HTTP 400. |
| &nbsp;&nbsp;`DtIni` | C (10) | 1-1 | S | Data inicial da carga. Formato DD/MM/AAAA (ex.: 01/03/2026). Fica fora da lista. Sem DtIni, DtFin e Estabs: 422 "F130: Empresa informada no registro invalida!". ⚑ Exigido hoje. O contrato previsto não traz DtIni, DtFin e Estabs: podem deixar de ser necessários (período e estabelecimento vindo só de cada registro). |
| &nbsp;&nbsp;`DtFin` | C (10) | 1-1 | S | Data final da carga. Formato DD/MM/AAAA (ex.: 31/03/2026). ⚑ Exigido hoje. O contrato previsto não traz DtIni, DtFin e Estabs: podem deixar de ser necessários (período e estabelecimento vindo só de cada registro). |
| &nbsp;&nbsp;`Estabs` | C | 1-1 | S | Estabelecimento da carga. Código do estabelecimento dos registros. Formato para mais de um estabelecimento: [A CONFIRMAR]. ⚑ Exigido hoje. O contrato previsto não traz DtIni, DtFin e Estabs: podem deixar de ser necessários (período e estabelecimento vindo só de cada registro). |
| &nbsp;&nbsp;`Usuario` | C | 1-1 | S | Usuário responsável pelo envio. Identifica quem enviou a carga. |
| &nbsp;&nbsp;&nbsp;&nbsp;`EstF130` | Objeto | 0-1 | C | Registro F130 (crédito sobre o valor de aquisição). Campos no grupo C. Informe o F130, o F120 ou os dois ([A CONFIRMAR] o envio de só um deles). |
| &nbsp;&nbsp;&nbsp;&nbsp;`EstF120` | Objeto | 0-1 | C | Registro F120 (crédito sobre depreciação/amortização). Campos no grupo D. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa). Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Dt_Ref` | D | 1-1 | S | Período de referência. Primeiro dia do mês (AAAA-MM-01), dentro do intervalo DtIni-DtFin. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ident_Bem_Imob` | N (2) | 1-1 | S | Identificação do bem. 01 = edificações e benfeitorias em imóveis próprios; 02 = em imóveis de terceiros; 03 = instalações; 04 = máquinas; 05 = equipamentos; 06 = veículos; 99 = outros. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ind_Orig_Cred` | C (1) | 1-1 | S | Indicador da origem do crédito. 0 = operação no mercado interno; 1 = operação de importação. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ind_Util_Bem_Imob` | N (1) | 1-1 | S | Indicador da utilização do bem. 1 = produção de bens destinados a venda; 2 = prestação de serviços; 3 = locação a terceiros; 9 = outros. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Mes_Oper_Aquis` | D | 1-1 | S | Mês da aquisição do bem. AAAA-MM-01 (na EFD vai como MMAAAA). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Oper_Aquis` | N | 1-1 | S | Valor de aquisição. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Parc_Oper_Nao_Bc_Cred` | N | 0-1 | N | Parcela excluída da base do crédito. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Cred` | N | 1-1 | S | Base de cálculo do crédito. Valor de aquisição menos a parcela excluída. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ind_Nr_Parc` | N (1) | 1-1 | S | Número de parcelas do crédito. 1 = integral (mês da aquisição); 2 = 12 meses; 3 = 24 meses; 4 = 48 meses; 5 = 6 meses (embalagens de bebidas frias); 9 = outra periodicidade. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cst_Pis` | N (2) | 1-1 | S | CST do PIS/Pasep. Tabela 4.3.3 da EFD-Contribuições (CST de crédito, ex.: "01"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Pis` | N | 1-1 | S | Base de cálculo do PIS/Pasep. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Aliq_Pis` | N | 1-1 | S | Alíquota do PIS/Pasep. Percentual, até 4 casas decimais (ex.: 1.65). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Pis` | N | 1-1 | S | Valor do crédito de PIS/Pasep. Base × alíquota / 100. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cst_Cofins` | N (2) | 1-1 | S | CST da Cofins. Tabela 4.3.4 da EFD-Contribuições. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Cofins` | N | 1-1 | S | Base de cálculo da Cofins. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Aliq_Cofins` | N | 1-1 | S | Alíquota da Cofins. Percentual, até 4 casas decimais (ex.: 1.65). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Cofins` | N | 1-1 | S | Valor do crédito de Cofins. Base × alíquota / 100. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Cta` | C (60) | 0-1 | N | Conta contábil. Conta analítica do plano de contas (ex.: 1.01.01.001). Informada e não localizada: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Ccus` | C (60) | 0-1 | N | Centro de custo. Centro de custo cadastrado (registro 0600). Informado e não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Desc_Bem_Imob` | C | 0-1 | N | Descrição do bem. Descrição complementar do bem ou grupo de bens. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa). Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Dt_Ref` | D | 1-1 | S | Período de referência. Primeiro dia do mês (AAAA-MM-01), dentro do intervalo DtIni-DtFin. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Nat_Bc_Cred` | C (2) | 1-1 | S | Natureza da base de cálculo do crédito. 09 = depreciação/amortização de bens do ativo imobilizado; 11 = amortização e depreciação de edificações e benfeitorias (tabela 4.3.7). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ident_Bem_Imob` | N (2) | 1-1 | S | Identificação do bem. 01 = edificações e benfeitorias em imóveis próprios; 02 = em imóveis de terceiros; 03 = instalações; 04 = máquinas; 05 = equipamentos; 06 = veículos; 99 = outros. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ind_Orig_Cred` | C (1) | 1-1 | S | Indicador da origem do crédito. 0 = operação no mercado interno; 1 = operação de importação. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ind_Util_Bem_Imob` | N (1) | 1-1 | S | Indicador da utilização do bem. 1 = produção de bens destinados a venda; 2 = prestação de serviços; 3 = locação a terceiros; 9 = outros. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Oper_Dep` | N | 1-1 | S | Valor da depreciação/amortização no período. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Parc_Oper_Nao_Bc_Cred` | N | 0-1 | N | Parcela excluída da base do crédito. A base de PIS/Cofins é o valor da depreciação menos esta parcela. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cst_Pis` | N (2) | 1-1 | S | CST do PIS/Pasep. Tabela 4.3.3 da EFD-Contribuições (CST de crédito, ex.: "01"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Pis` | N | 1-1 | S | Base de cálculo do PIS/Pasep. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Aliq_Pis` | N | 1-1 | S | Alíquota do PIS/Pasep. Percentual, até 4 casas decimais (ex.: 1.65). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Pis` | N | 1-1 | S | Valor do crédito de PIS/Pasep. Base × alíquota / 100. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cst_Cofins` | N (2) | 1-1 | S | CST da Cofins. Tabela 4.3.4 da EFD-Contribuições. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Cofins` | N | 1-1 | S | Base de cálculo da Cofins. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Aliq_Cofins` | N | 1-1 | S | Alíquota da Cofins. Percentual, até 4 casas decimais (ex.: 1.65). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Cofins` | N | 1-1 | S | Valor do crédito de Cofins. Base × alíquota / 100. Número decimal, 2 casas. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Cta` | C (60) | 0-1 | N | Conta contábil. Conta analítica do plano de contas (ex.: 1.01.01.001). Informada e não localizada: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Ccus` | C (60) | 0-1 | N | Centro de custo. Centro de custo cadastrado (registro 0600). Informado e não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Desc_Bem_Imob` | C | 0-1 | N | Descrição do bem. Descrição complementar do bem ou grupo de bens. |

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Layout/Layout API Migrate - Bloco F - F120 e F130.xlsx](Layout/Layout%20API%20Migrate%20-%20Bloco%20F%20-%20F120%20e%20F130.xlsx) | layout de/para com a EFD, retorno, códigos HTTP, erros e exemplos |
| [Exemplos/JSON/bloco-f-f130-f120-requisicao.json](Exemplos/JSON/bloco-f-f130-f120-requisicao.json) | POST /API/Migrate/BlocoF - Gravar F130 e F120 |
| [Exemplos/JSON/bloco-f-f130-f120-retorno-200.json](Exemplos/JSON/bloco-f-f130-f120-retorno-200.json) | HTTP 200 - F130 e F120 gravados |
| [Exemplos/JSON/bloco-f-erro-campos-da-carga-requisicao.json](Exemplos/JSON/bloco-f-erro-campos-da-carga-requisicao.json) | POST /API/Migrate/BlocoF - Erro - sem DtIni, DtFin e Estabs |
| [Exemplos/JSON/bloco-f-erro-campos-da-carga-retorno-422.json](Exemplos/JSON/bloco-f-erro-campos-da-carga-retorno-422.json) | HTTP 422 - Campos da carga ausentes |

⚑ = possível ajuste: comportamento atual, que pode mudar em versão futura.
