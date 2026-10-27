# Documento Fiscal

Carga do documento fiscal completo (capa, itens e totais), base dos registros C100, C170 e C190 da EFD, com exclusão e alteração de situação.

## Operações

| Método | Rota |
|---|---|
| POST | `{baseUrl}/API/Migrate/DocFiscal` |
| DELETE | `{baseUrl}/API/Migrate/DocFiscal` |
| POST | `{baseUrl}/API/Migrate/DocFiscalAlteraSituacao` |

Autenticação: header `Authorization: Bearer <accessToken>` (ver [Autenticação](../Autenticacao/README.md)).

## Regras

- **Finalidade:** Carga do documento fiscal completo (capa, itens e totais), base dos registros C100, C170 e C190 da EFD.
- **Métodos e rotas:** POST {baseUrl}/API/Migrate/DocFiscal (envio) · DELETE {baseUrl}/API/Migrate/DocFiscal (exclusão) · POST {baseUrl}/API/Migrate/DocFiscalAlteraSituacao (alteração de situação) ⚑ As rotas podem passar a ser /API/v1/DocFiscal e /API/v1/DocFiscalAlteraSituacao.
- **Formato:** JSON (Content-Type: application/json; charset=utf-8).
- **Autenticação:** Header Authorization: Bearer <accessToken> (aba Autenticação).
- **Envio:** Um documento por requisição: objeto "DocFiscal" com o grupo "Est_nota_capa", que contém as listas "Est_nota_item" e "Est_nota_total"; "Usuario" fica ao lado de "DocFiscal". ⚑ Hoje o corpo sem o objeto "DocFiscal" (ou com outro nome) responde 422 "Empresa nao identificada!". Pode passar a responder 400 (requisição inválida). Tratar os dois códigos.
- **Valores e datas:** Valores como texto com vírgula decimal (ex.: "1000,00"); datas no formato AAAA-MM-DD. Campos sem valor podem ser omitidos.
- **Cadastros:** Participante, itens, unidades, contas e centros de custo citados no documento precisam estar cadastrados antes (endpoints de cadastro).
- **Identificação na origem:** Envie IdOrigemExt e CrpInProdutoId: são eles que localizam o documento na exclusão e na alteração de situação. ⚑ Hoje o IdCrpInProduto é obrigatório na alteração de situação (400 sem ele), embora o envio aceite documento sem CrpInProdutoId. A regra pode mudar. Recomendação: enviar sempre o CrpInProdutoId na gravação e usar o mesmo valor na exclusão e na alteração de situação.
- **Reenvio:** Documento já gravado é recusado (422). Para corrigir, exclua e envie de novo.
- **Exclusão:** DELETE com os identificadores na URL; exclui o documento com itens e totais. Documento apurado ou em período bloqueado não é excluído (422).
- **Alteração de situação:** Gera nova versão do documento com o Cod_Sit informado; a versão anterior é mantida.
- **Validação:** Com qualquer erro (HTTP 422), nada é gravado.
- **Modelos:** Os exemplos cobrem a NF-e (modelo 55). Os demais modelos usam a mesma estrutura; campos específicos por modelo: [A CONFIRMAR].
- **Fora desta versão:** Grupos complementares do documento (C105, C113, C176, C180, C185, C186, C380, A120, 1700 e C197).

## Layout Json - Documento Fiscal (Envio)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| &nbsp;&nbsp;`DocFiscal` | Objeto | 1-1 | S | Documento fiscal. Objeto (não é lista) com o grupo Est_nota_capa. ⚑ Hoje o corpo sem o objeto "DocFiscal" (ou com outro nome) responde 422 "Empresa nao identificada!". Pode passar a responder 400 (requisição inválida). Tratar os dois códigos. |
| &nbsp;&nbsp;`Usuario` | C | 1-1 | S | Usuário responsável pelo envio. Fica fora do objeto DocFiscal. Identifica quem enviou a carga. |
| &nbsp;&nbsp;&nbsp;&nbsp;`Est_nota_capa` | Objeto | 1-1 | S | Capa do documento. Dados da capa; contém as listas Est_nota_item (grupo C) e Est_nota_total (grupo D). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Id` | C | 0-1 | N | Identificador do registro. Finalidade e formato: [A CONFIRMAR]. Os exemplos não o enviam. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento (empresa) no sistema, vinculado à chave de parceiro. Não localizado: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ind_Oper` | C (1) | 1-1 | S | Indicador do tipo de operação. 0 = entrada; 1 = saída. Fora do domínio: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ind_Emit` | C (1) | 1-1 | S | Indicador do emitente. 0 = emissão própria; 1 = terceiros. Fora do domínio: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Part` | C (60) | 1-1 | S | Código do participante. Código do participante já cadastrado no estabelecimento (endpoint Participante). Não informado ou sem cadastro: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Mod` | C (2) | 1-1 | S | Código do modelo do documento. Tabela 4.1.1 da EFD (ex.: 55 = NF-e). Fora do domínio: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Sit` | N (2) | 1-1 | S | Código da situação do documento. Tabela 4.1.2 da EFD (ex.: 00 = documento regular; 02 = cancelado). Fora do domínio: 422. Para mudar a situação de um documento já gravado, usar a alteração de situação (aba Alteração de situação). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ser` | C (3) | 0-1 | C | Série do documento. Obrigatória quando o documento tem série (Guia da EFD). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Num_Doc` | N (9) | 1-1 | S | Número do documento |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Dt_Doc` | D | 1-1 | S | Data de emissão. Formato AAAA-MM-DD. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Chv` | N (44) | 0-1 | C | Chave de acesso. Obrigatória para documento eletrônico (ex.: NF-e, modelo 55) pelo Guia da EFD. Só dígitos. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Dt_E_S` | D | 0-1 | C | Data de entrada ou saída. Formato AAAA-MM-DD. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Doc` | N (2 dec.) | 1-1 | S | Valor total do documento. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ind_Pgto` | C (1) | 1-1 | S | Indicador do tipo de pagamento. 0 = à vista; 1 = a prazo; 2 = outros (Guia da EFD). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Merc` | N (2 dec.) | 0-1 | C | Valor das mercadorias. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ind_Frt` | C (1) | 1-1 | S | Indicador do tipo de frete. 0 = por conta do remetente (CIF); 1 = do destinatário (FOB); 2 = de terceiros; 3 = próprio do remetente; 4 = próprio do destinatário; 9 = sem frete (Guia da EFD). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Icms` | N (2 dec.) | 0-1 | C | Base de cálculo do ICMS. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Icms` | N (2 dec.) | 0-1 | C | Valor do ICMS. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Pis` | N (2 dec.) | 0-1 | C | Valor do PIS. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Cofins` | N (2 dec.) | 0-1 | C | Valor da COFINS. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Pis` | N (2 dec.) | 0-1 | N | Base de cálculo do PIS. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Cofins` | N (2 dec.) | 0-1 | N | Base de cálculo da COFINS. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Num_Doc_Serv` | C | 0-1 | N | Número do documento de serviço. Finalidade: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Hash` | C | 0-1 | N | Hash do registro. Finalidade: [A CONFIRMAR]. Os exemplos não o enviam. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`IdOrigem` | N | 0-1 | N | Identificador numérico na origem. Identificador do documento no sistema de origem. Se enviado, pode ser usado para excluir e alterar a situação. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`IdOrigemExt` | C | 0-1 | N | Identificador do documento na origem. Identificador do documento no sistema de origem (ex.: chave do ERP). Recomendado: é por ele que se exclui e se altera a situação do documento. Tamanho máximo: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`CrpInProdutoId` | N | 0-1 | N | Produto de integração. Código numérico do sistema de origem da carga; vai no parâmetro IdCrpInProduto da exclusão e da alteração de situação. Recomendado: a alteração de situação o exige. Valor a utilizar: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`OrigemDados` | C | 0-1 | N | Origem dos dados. Valores aceitos: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Mun_Dest` | N (7) | 0-1 | N | Município de destino. Código IBGE do município. Uso por modelo: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Fin_Doc` | C | 0-1 | N | Finalidade do documento. Valores aceitos: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Cons` | C | 0-1 | N | Classe de consumo. Documentos de energia, água e gás (C500). Valor fora do domínio: 422. Domínio: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Tp_Ligacao` | C | 0-1 | N | Tipo de ligação. Documentos de energia elétrica (C500). Valor fora do domínio: 422. Domínio: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Grupo_Tensao` | C | 0-1 | N | Grupo de tensão. Documentos de energia elétrica (C500). Valor fora do domínio: 422. Domínio: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Tp_Cte` | C | 0-1 | N | Tipo do conhecimento de transporte. Conhecimentos de transporte (D100). Valor fora do domínio: 422. Domínio: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ind_Dest` | C | 0-1 | N | Indicador do destinatário. Valor fora do domínio: 422. Domínio e modelos: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Outras_Ded` | C | 0-1 | N | Outras deduções. Valor fora do domínio: 422. Domínio e modelos: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Cta` | C | 0-1 | N | Conta contábil. Código da conta já cadastrada no plano de contas. Sem cadastro: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Est_nota_item` | Lista | 0-N | C | Lista de itens. Um elemento por item. Obrigatória quando a EFD exige o C170 (ex.: documento de entrada de terceiros). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Est_nota_item` | Objeto | 1-1 | S | Item (elemento da lista). Cada elemento vem embrulhado no nome: {"Est_nota_item": {...campos...}}. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Id` | C | 0-1 | N | Identificador do registro. Finalidade e formato: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Num_Item` | N (3) | 1-1 | S | Número sequencial do item |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Item` | C (60) | 1-1 | S | Código do item. Código do item já cadastrado no estabelecimento (endpoint Produto). Sem cadastro: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Qtd` | N (5 dec.) | 0-1 | C | Quantidade. Texto com vírgula decimal (ex.: "1" ou "2,5"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Unid` | C (6) | 0-1 | C | Unidade. Unidade já cadastrada. Sem cadastro: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Item` | N (2 dec.) | 1-1 | S | Valor total do item. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ind_Mov` | C (1) | 1-1 | S | Movimentação física. 0 = sim; 1 = não. Fora do domínio: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cst_Icms` | N (3) | 1-1 | S | CST do ICMS. Origem + tributação (tabela 4.3.1 da EFD). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`CFOP` | N (4) | 1-1 | S | CFOP |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Nat` | C (10) | 0-1 | N | Natureza da operação |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Icms` | N (2 dec.) | 0-1 | C | Base de cálculo do ICMS. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Aliq_Icms` | N (6,2) | 0-1 | C | Alíquota do ICMS. Percentual, com vírgula decimal (ex.: "12,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Icms` | N (2 dec.) | 0-1 | C | Valor do ICMS. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cst_Ipi` | C (2) | 0-1 | C | CST do IPI |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cst_Pis` | N (2) | 0-1 | C | CST do PIS |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Pis` | N (2 dec.) | 0-1 | C | Base de cálculo do PIS. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Aliq_Pis` | N (8,4) | 0-1 | C | Alíquota do PIS (%). Percentual, com vírgula decimal (ex.: "1,6500"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Pis` | N (2 dec.) | 0-1 | C | Valor do PIS. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cst_Cofins` | N (2) | 0-1 | C | CST da COFINS |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Cofins` | N (2 dec.) | 0-1 | C | Base de cálculo da COFINS. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Aliq_Cofins` | N (8,4) | 0-1 | C | Alíquota da COFINS (%). Percentual, com vírgula decimal (ex.: "7,6000"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Cofins` | N (2 dec.) | 0-1 | C | Valor da COFINS. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Red_Bc` | N (2 dec.) | 0-1 | N | Valor da redução da base de cálculo. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Cta` | C | 0-1 | N | Conta contábil. Código da conta já cadastrada no plano de contas. Sem cadastro: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Contabil` | N (2 dec.) | 0-1 | N | Valor contábil do item. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`IsActive` | B | 0-1 | N | Item ativo. Enviado como texto "true". Efeito de "false": [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Hash` | C | 0-1 | N | Hash do registro. Finalidade: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Icms_Partilha` | N (2 dec.) | 0-1 | N | Base de cálculo do ICMS de partilha. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Nat_Bc_Cred` | C (2) | 0-1 | N | Natureza da base de cálculo do crédito. Tabela 4.3.7 da EFD-Contribuições. Fora do domínio: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ind_Nat_Frt` | C (1) | 0-1 | N | Natureza do frete contratado. Domínio do campo IND_NAT_FRT da EFD-Contribuições. Fora do domínio: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ind_Orig_Cred` | C (1) | 0-1 | N | Origem do crédito. 0 = mercado interno; 1 = importação. Fora do domínio: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Ind_Rec` | C | 0-1 | N | Indicador da receita. Fora do domínio: 422. Domínio: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Nat_Rec` | C (3) | 0-1 | N | Natureza da receita. Tabelas 4.3.10 a 4.3.16 da EFD-Contribuições, conforme o CST do PIS. Combinação inexistente: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Cta_Pis` | C | 0-1 | N | Conta contábil do PIS/COFINS. Conta já cadastrada no plano de contas. Sem cadastro: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cod_Ccus` | C | 0-1 | N | Centro de custo. Centro de custo já cadastrado (endpoint Reg0600). Sem cadastro: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`CrpCodRecIrrf` | C | 0-1 | N | Código de receita do IRRF. Código já cadastrado. Sem cadastro: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`CrpCodRecInss` | C | 0-1 | N | Código de receita do INSS. Código já cadastrado. Sem cadastro: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`CrpCodRecIdPIS` | C | 0-1 | N | Código de receita do PIS retido. Código já cadastrado. Sem cadastro: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`CrpCodRecIdCOFINS` | C | 0-1 | N | Código de receita da COFINS retida. Código já cadastrado. Sem cadastro: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`CrpCodRecIdCSLL` | C | 0-1 | N | Código de receita da CSLL retida. Código já cadastrado. Sem cadastro: 422. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Est_nota_total` | Lista | 0-N | C | Lista de totais (registro analítico). Um elemento por combinação de CST do ICMS, CFOP e alíquota. Obrigatória quando a EFD exige o C190 (documento regular). A soma de Vl_Opr deve fechar com Vl_Doc. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Est_nota_total` | Objeto | 1-1 | S | Total (elemento da lista). Cada elemento vem embrulhado no nome: {"Est_nota_total": {...campos...}}. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Id` | C | 0-1 | N | Identificador do registro. Finalidade e formato: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Origem_Icms` | C (1) | 0-1 | N | Origem da mercadoria. Uso: [A CONFIRMAR]. |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Cst_Icms` | N (3) | 1-1 | S | CST do ICMS |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`CFOP` | N (4) | 1-1 | S | CFOP |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Aliq_Icms` | N (6,2) | 0-1 | C | Alíquota do ICMS. Percentual, com vírgula decimal (ex.: "12,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Opr` | N (2 dec.) | 1-1 | S | Valor da operação. Soma dos itens com o mesmo CST, CFOP e alíquota. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Bc_Icms` | N (2 dec.) | 1-1 | S | Base de cálculo do ICMS. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Icms` | N (2 dec.) | 1-1 | S | Valor do ICMS. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Vl_Red_Bc` | N (2 dec.) | 0-1 | C | Valor da redução da base de cálculo. Texto com vírgula decimal (ex.: "1000,00"). |
| &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;`Hash` | C | 0-1 | N | Hash do registro. Finalidade: [A CONFIRMAR]. |

## Layout - Exclusão Do Documento (Delete)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| `IdCrpInProduto` | N | 0-1 | C | Produto de integração. O mesmo valor enviado em CrpInProdutoId na gravação. Se o documento foi gravado sem CrpInProdutoId, não enviar o parâmetro (enviar 0 não localiza o documento). |
| `IdOrigem` | N | 0-1 | C | Identificador numérico na origem. O mesmo valor enviado em IdOrigem na gravação. Se o documento foi gravado sem IdOrigem, não enviar o parâmetro. |
| `IdOrigemExt` | C | 0-1 | C | Identificador do documento na origem. O mesmo valor enviado em IdOrigemExt na gravação. Informar IdOrigemExt ou IdOrigem; só o IdOrigemExt basta para localizar o documento. |
| `Usuario` | C | 1-1 | S | Usuário responsável pela exclusão. Identifica quem pediu a exclusão. |
| `(sem corpo)` | - | - | - | A exclusão não tem corpo. Os identificadores vão só na URL. Não há parâmetro de estabelecimento: o documento é localizado pelos identificadores de origem. |
| `(resultado)` | - | - | - | Documento excluído. 200: documento excluído com itens e totais. Nenhum documento com os identificadores: 404. Documento já apurado ou em período bloqueado: 422 (aba Erros). |

## Layout Json - Alteração De Situação (Post)

| Campo | Tipo | Ocorr. | Obrig. | Descrição |
|---|---|---|---|---|
| &nbsp;&nbsp;`Estab` | C | 1-1 | S | Estabelecimento. Código do estabelecimento do documento. Ausente: 400. Não localizado: 422. |
| &nbsp;&nbsp;`IdCrpInProduto` | N | 1-1 | S | Produto de integração. O mesmo valor enviado em CrpInProdutoId na gravação. Ausente: 400, antes das demais validações. ⚑ Hoje o IdCrpInProduto é obrigatório na alteração de situação (400 sem ele), embora o envio aceite documento sem CrpInProdutoId. A regra pode mudar. Recomendação: enviar sempre o CrpInProdutoId na gravação e usar o mesmo valor na exclusão e na alteração de situação. |
| &nbsp;&nbsp;`IdOrigem` | N | 0-1 | C | Identificador numérico na origem. Informar IdOrigem ou IdOrigemExt (ao menos um). Sem os dois: 400. Se não usado, pode ir vazio. |
| &nbsp;&nbsp;`IdOrigemExt` | C | 0-1 | C | Identificador do documento na origem. O mesmo valor enviado em IdOrigemExt na gravação. Mesma regra do IdOrigem. |
| &nbsp;&nbsp;`Cod_Sit` | N (2) | 1-1 | S | Nova situação do documento. Tabela 4.1.2 da EFD (C100 - 06 COD_SIT; ex.: 02 = cancelado). Fora do domínio: 422. Situações aceitas na alteração: [A CONFIRMAR]. |
| &nbsp;&nbsp;`Usuario` | C | 1-1 | S | Usuário responsável pela alteração. Identifica quem pediu a alteração. |
| `(resultado)` | - | - | - | Nova versão do documento. 200: é gerada uma nova versão do documento com a situação informada; a versão anterior é mantida no histórico. Documento não localizado: 404. Período bloqueado: 422. |

## Arquivos

| Arquivo | Conteúdo |
|---|---|
| [Layout/Layout API Migrate - Documento Fiscal.xlsx](Layout/Layout%20API%20Migrate%20-%20Documento%20Fiscal.xlsx) | layout de/para com a EFD, retorno, códigos HTTP, erros e exemplos |
| [Exemplos/JSON/docfiscal-nfe-entrada-requisicao.json](Exemplos/JSON/docfiscal-nfe-entrada-requisicao.json) | POST /API/Migrate/DocFiscal - Gravar - NF-e de entrada (modelo 55) |
| [Exemplos/JSON/docfiscal-nfe-entrada-retorno-200.json](Exemplos/JSON/docfiscal-nfe-entrada-retorno-200.json) | HTTP 200 - Documento gravado |
| [Exemplos/JSON/docfiscal-erro-participante-requisicao.json](Exemplos/JSON/docfiscal-erro-participante-requisicao.json) | POST /API/Migrate/DocFiscal - Erro - participante sem cadastro |
| [Exemplos/JSON/docfiscal-erro-participante-retorno-422.json](Exemplos/JSON/docfiscal-erro-participante-retorno-422.json) | HTTP 422 - Participante sem cadastro |
| [Exemplos/JSON/docfiscal-erro-reenvio-requisicao.json](Exemplos/JSON/docfiscal-erro-reenvio-requisicao.json) | POST /API/Migrate/DocFiscal - Erro - reenvio do mesmo documento |
| [Exemplos/JSON/docfiscal-erro-reenvio-retorno-422.json](Exemplos/JSON/docfiscal-erro-reenvio-retorno-422.json) | HTTP 422 - Documento já gravado |
| [Exemplos/JSON/docfiscal-excluir-retorno-200.json](Exemplos/JSON/docfiscal-excluir-retorno-200.json) | HTTP 200 - Documento excluído |
| [Exemplos/JSON/docfiscal-excluir-inexistente-retorno-404.json](Exemplos/JSON/docfiscal-excluir-inexistente-retorno-404.json) | HTTP 404 - Documento não encontrado |
| [Exemplos/JSON/docfiscal-alterar-situacao-requisicao.json](Exemplos/JSON/docfiscal-alterar-situacao-requisicao.json) | POST /API/Migrate/DocFiscalAlteraSituacao - Alterar situação - cancelar documento |
| [Exemplos/JSON/docfiscal-alterar-situacao-retorno-200.json](Exemplos/JSON/docfiscal-alterar-situacao-retorno-200.json) | HTTP 200 - Situação alterada |
| [Exemplos/JSON/docfiscal-erro-situacao-requisicao.json](Exemplos/JSON/docfiscal-erro-situacao-requisicao.json) | POST /API/Migrate/DocFiscalAlteraSituacao - Erro - alterar situação com Cod_Sit inválido |
| [Exemplos/JSON/docfiscal-erro-situacao-retorno-422.json](Exemplos/JSON/docfiscal-erro-situacao-retorno-422.json) | HTTP 422 - Situação inválida |

⚑ = possível ajuste: comportamento atual, que pode mudar em versão futura.
