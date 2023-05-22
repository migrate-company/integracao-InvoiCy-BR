<?php
header('Content-Type: text/html; charset=UTF-8'); //Este arquivo está em UTF-8 sem BOM

// Chave de acesso da empresa
$chaveAcesso = 'eKda2fcZg9ZMt3DrfF/KSIVoH59Ca6nN';
// Chave do parceiro
$chaveParceiro = 'TkyRwOxIhpAFturuC0e+Ug==';

// XML de envio
// XML NF-e
$xmlNFe = '<Envio>
	<ModeloDocumento>NFe</ModeloDocumento>
	<Versao>3.10</Versao>
	<ide>
		<cNF>111</cNF>
		<cUF>43</cUF>
		<natOp>NFE CST 00</natOp>
		<indPag>0</indPag>
		<mod>55</mod>
		<serie>111</serie>
		<nNF>408</nNF>
		<dhEmi>2013-06-09T08:40:00</dhEmi>
		<fusoHorario>-02:00</fusoHorario>
		<dhSaiEnt>2013-06-09T08:40:00</dhSaiEnt>
		<tpNf>1</tpNf>
		<idDest>2</idDest>
		<indFinal>0</indFinal>
		<indPres>0</indPres>
		<cMunFg>4309605</cMunFg>
		<tpImp>1</tpImp>
		<tpEmis>1</tpEmis>
		<tpAmb>2</tpAmb>
		<xJus/>
		<dhCont/>
		<finNFe>1</finNFe>
		<procEmi>0</procEmi>
		<verProc/>
		<EmailArquivos>teste@email.com.br</EmailArquivos>
	</ide>
	<emit>
		<CNPJ_emit>99999999000191</CNPJ_emit> 
		<xNome>MIGRATE COMPANY SISTEMAS DE INFORMACAO</xNome> 
		<xFant>EMPRESA DE TESTE</xFant>
		<enderEmit>
			<xLgr>RUA AGOSTINHO COSTI</xLgr> 
			<nro>99999</nro> 
			<xCpl>ANDAR 02</xCpl>
			<xBairro>BARRA DO JACARE</xBairro> 
			<cMun>4309605</cMun> 
			<xMun>ENCANTADO</xMun> 
			<UF>RS</UF> 
			<CEP>99999999</CEP> 
			<cPais>1058</cPais> 
			<xPais>BRASIL</xPais> 
			<fone>9999999999</fone>
			<fax>9999999999</fax>
			<Email>exemplo@exemplo.com.br</Email>
		</enderEmit>
		<IM>9999999</IM>
		<IE>9999999999</IE>
		<IEST />
		<CRT>3</CRT> 
	</emit>
	<dest>
		<CNPJ_dest>99999999000191</CNPJ_dest>
		<xNome_dest>NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL</xNome_dest>
		<enderDest>
			<nro_dest>67</nro_dest>
			<xCpl_dest>CENTRO</xCpl_dest>
			<xBairro_dest>KENNEDY</xBairro_dest>
			<xEmail_dest>teste@teste.com</xEmail_dest>
			<xLgr_dest>ROD BR 040 KM 688 AREA ESPECIAL 11</xLgr_dest>
			<xPais_dest>Brasil</xPais_dest>
			<cMun_dest>3118601</cMun_dest>
			<xMun_dest>CONTAGEM</xMun_dest>
			<UF_dest>MG</UF_dest>
			<CEP_dest>99999999</CEP_dest>
			<cPais_dest>1058</cPais_dest>
			<fone_dest>999999999</fone_dest>
		</enderDest>
		<idEstrangeiro/>
		<indIEDest>2</indIEDest>
		<IE_dest/>
		<ISUF />
	</dest>
	<autXML>
		<autXMLItem>
			<CNPJ_aut>99999999000191</CNPJ_aut>
			<CPF_aut/>
		</autXMLItem>
	</autXML>
	<det>
		<detItem>
			<prod>
				<cProd>00009</cProd>
				<xProd>01 CARRO</xProd>
				<NCM>87113000</NCM>
				<EXTIPI>87</EXTIPI>
				<CFOP>6102</CFOP>
				<uCOM>BOT</uCOM>
				<qCOM>1.0000</qCOM>
				<vUnCom>100.00</vUnCom>
				<vProd>100.00</vProd>
				<uTrib>BOT</uTrib>
				<qTrib>1.00</qTrib>
				<vUnTrib>100.00</vUnTrib>
				<vSeg>0.00</vSeg>
				<vDesc>0.00</vDesc>
				<vOutro_item>0.00</vOutro_item>
				<indTot>1</indTot>
				<nTipoItem>0</nTipoItem>
				<dProd>0</dProd>
				<xPed_item>abc</xPed_item>
				<nItemPed>123</nItemPed>
			</prod>
			<imposto>
				<ICMS>
					<orig>0</orig>
					<CST>40</CST>
				</ICMS>
				<PIS>
					<CST_pis>03</CST_pis>
					<vPIS>50.00</vPIS>
					<qBCprod_pis>10.00</qBCprod_pis>
					<vAliqProd_pis>5.00</vAliqProd_pis>
				</PIS>
				<COFINS>
					<CST_cofins>03</CST_cofins>
					<vCOFINS>50.00</vCOFINS>
					<qBCProd_cofins>10.00</qBCProd_cofins>
					<vAliqProd_cofins>5.00</vAliqProd_cofins>
				</COFINS>
			</imposto>			
		</detItem>
		<detItem>
			<prod>
				<cProd>00009</cProd>				
				<xProd>01 CARRO</xProd>
				<NCM>87113000</NCM>
				<EXTIPI>87</EXTIPI>
				<CFOP>6102</CFOP>
				<uCOM>BOT</uCOM>
				<qCOM>1.0000</qCOM>
				<vUnCom>101.00</vUnCom>
				<vProd>101.00</vProd>
				<uTrib>BOT</uTrib>
				<qTrib>1.00</qTrib>
				<vUnTrib>101.00</vUnTrib>				
				<vSeg>0.00</vSeg>
				<vDesc>0.00</vDesc>
				<vOutro_item>0.00</vOutro_item>
				<indTot>1</indTot>
				<nTipoItem>0</nTipoItem>
				<dProd>0</dProd>
				<xPed_item>abc</xPed_item>
				<nItemPed>123</nItemPed>
			</prod>
			<imposto>
				<ICMS>
					<orig>0</orig>
					<CST>40</CST>
				</ICMS>
				<PIS>
					<CST_pis>03</CST_pis>
					<vPIS>50.00</vPIS>
					<qBCprod_pis>10.00</qBCprod_pis>
					<vAliqProd_pis>5.00</vAliqProd_pis>
				</PIS>
				<COFINS>
					<CST_cofins>03</CST_cofins>
					<vCOFINS>50.00</vCOFINS>
					<qBCProd_cofins>10.00</qBCProd_cofins>
					<vAliqProd_cofins>5.00</vAliqProd_cofins>
				</COFINS>
			</imposto>			
		</detItem>
	</det>
	<total>
		<ICMStot>
			<vBC_ttlnfe>0.00</vBC_ttlnfe>
			<vICMS_ttlnfe>0.00</vICMS_ttlnfe>
			<vBCST_ttlnfe>0.00</vBCST_ttlnfe>
			<vST_ttlnfe>0.00</vST_ttlnfe>
			<vProd_ttlnfe>201.00</vProd_ttlnfe>
			<vFrete_ttlnfe>0</vFrete_ttlnfe>
			<vSeg_ttlnfe>0</vSeg_ttlnfe>
			<vDesc_ttlnfe>0</vDesc_ttlnfe>
			<vIPI_ttlnfe>0</vIPI_ttlnfe>
			<vPIS_ttlnfe>100.00</vPIS_ttlnfe>
			<vCOFINS_ttlnfe>100.00</vCOFINS_ttlnfe>
			<vOutro>0</vOutro>
			<vNF>201.00</vNF>
		</ICMStot>
	</total>
	<transp>
		<modFrete>1</modFrete>
		<vol>
			<volItem>
				<qVol>1</qVol>
				<esp>VOLUME</esp>
				<nVol>1</nVol>
				<pesoB_transp>3.700</pesoB_transp>
			</volItem>
			<volItem>
				<qVol>1</qVol>
				<esp>VOLUME</esp>
				<nVol>2</nVol>
				<pesoB_transp>4.900</pesoB_transp>
			</volItem>
		</vol>
	</transp>
	<infAdic>
		<infAdFisco/>
		<infCpl>7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 7898 2300 2286 2320 2297 2314 2287 </infCpl>
	</infAdic>
</Envio>';

// XML NFC-e
$xmlNFCe = '<Envio>
	<ModeloDocumento>NFCe</ModeloDocumento>
	<Versao>3.10</Versao>
	<ide>
		<cNF>00000001</cNF>
		<cUF>43</cUF>
		<natOp>Venda no supermercado</natOp>
		<indPag>0</indPag>
		<mod>65</mod>
		<serie>667</serie>
		<nNF>2</nNF>
		<dhEmi>2014-05-28T14:00:00</dhEmi>
		<fusoHorario>-03:00</fusoHorario>
		<tpNf>1</tpNf>
		<idDest>1</idDest>
		<indFinal>1</indFinal>
		<indPres>1</indPres>
		<cMunFg>1301902</cMunFg>
		<tpImp>4</tpImp>
		<tpEmis>1</tpEmis>
		<tpAmb>2</tpAmb>
		<finNFe>1</finNFe>
		<procEmi>0</procEmi>
	</ide>
	<emit>
		<CNPJ_emit>99999999000191</CNPJ_emit>
		<xNome>EMPRESA TESTE NFe e NFCe</xNome>
		<enderEmit>
			<xLgr>Rua Sen. Salgado filho</xLgr>
			<nro>666</nro>
			<xBairro>centro</xBairro>
			<cMun>1301902</cMun>
			<xMun>ENCANTADO</xMun>
			<UF>AM</UF>
			<CEP>69076448</CEP>
		</enderEmit>
		<IE>042239010</IE>
		<CRT>3</CRT>
	</emit>
	<det>
		<detItem>
			<prod>
				<cProd>1</cProd>
				<cEAN/>
				<xProd>Chinelo de dedo</xProd>
				<NCM>99999999</NCM>
				<CFOP>5102</CFOP>
				<uCOM>UN</uCOM>
				<qCOM>1</qCOM>
				<vUnCom>5.00</vUnCom>
				<vProd>5.00</vProd>
				<cEANTrib/>
				<uTrib>UN</uTrib>
				<qTrib>1</qTrib>
				<vUnTrib>5.00</vUnTrib>
				<indTot>1</indTot>
				<nTipoItem>0</nTipoItem>
			</prod>
			<imposto>
				<ICMS>
					<orig>0</orig>
					<CST>00</CST>
					<modBC>3</modBC>
					<vBC>100.00</vBC>
					<pICMS>17.00</pICMS>
					<vICMS_icms>17.00</vICMS_icms>
				</ICMS>
			</imposto>
		</detItem>
	</det>
	<total>
		<ICMStot>
			<vBC_ttlnfe>100.00</vBC_ttlnfe>
			<vICMS_ttlnfe>17.00</vICMS_ttlnfe>
			<vBCST_ttlnfe>0.00</vBCST_ttlnfe>
			<vST_ttlnfe>0.00</vST_ttlnfe>
			<vProd_ttlnfe>5.00</vProd_ttlnfe>
			<vFrete_ttlnfe>0</vFrete_ttlnfe>
			<vSeg_ttlnfe>0</vSeg_ttlnfe>
			<vDesc_ttlnfe>0</vDesc_ttlnfe>
			<vIPI_ttlnfe>0</vIPI_ttlnfe>
			<vPIS_ttlnfe>0</vPIS_ttlnfe>
			<vCOFINS_ttlnfe>0</vCOFINS_ttlnfe>
			<vOutro>0</vOutro>
			<vICMSDeson_ttlnfe>0.00</vICMSDeson_ttlnfe>
			<vNF>5.00</vNF>
			<vTotTrib_ttlnfe>0.00</vTotTrib_ttlnfe>
		</ICMStot>
	</total>
	<transp>
		<modFrete>9</modFrete>
	</transp>
	<pag>
		<pagItem>
			<tPag>01</tPag>
			<vPag>5.00</vPag>
		</pagItem>
	</pag>
</Envio>';

// Lineariza o XML. Se o XML já estiver linearizado não é necessário fazer esta substituição
$xmlNFe = preg_replace('/>\s+</', '><', $xmlNFe);
$xmlNFCe = preg_replace('/>\s+</', '><', $xmlNFCe);
// Gera a chave de comunicação
$chaveComunicacao = md5($chaveAcesso . $xmlNFe);

// Define os valores dos parâmetros do WS
$arrParametrosSOAP = array(
	'Invoicyrecepcao' => array(
		'Cabecalho' => array(
			'EmpPK' => $chaveParceiro,
			'EmpCK' => $chaveComunicacao,
			'EmpCO' => null,
		),
		'Informacoes' => null,
		'Dados' => array(
			array( //DadosItem
				'Documento' => $xmlNFe, //NF-E
				'Parametros' => null,
			),
			array( //DadosItem
				'Documento' => $xmlNFCe, //NFC-e
				'Parametros' => null,
			),
		),
	),
);

try {
	
	$url = "https://homolog.invoicy.com.br/arecepcao.aspx?WSDL";
	$objSoapClient = new SoapClient($url, array('location' => $url));
	$objRetorno = $objSoapClient->Execute($arrParametrosSOAP);
	
	if (!empty($objRetorno->Invoicyretorno)) {
		$arrMensagemItem = $objRetorno->Invoicyretorno->Mensagem->MensagemItem;
		// Se for enviado somente <DadosItem> de um mesmo tipo, retorna um objeto pronto.
		// Se foram enviados <DadosItem> de mais de um tipo (NFC-e, NF-e, NFS-e, etc), retorna um array de objetos
		// Ex.: Foram enviadas uma ou mais NF-e e uma ou mais NFC-e na mesma comunicação
		if (!is_array($arrMensagemItem)) { // Se foi enviado apenas um tipo, transforma para array para poder reaproveitar o código do foreach
			$arrMensagemItem = array($arrMensagemItem);
		}
		foreach($arrMensagemItem as $objMensagemItem) { // Para cada tipo enviado (NFC-e, NF-e, NFS-e, etc), retorna um MensagemItem
			
			if ($objMensagemItem->Codigo == 100) { // Código = 100 é sucesso
				// Documentos processados
				echo '<br>Mensagem Item: <b>' . $objMensagemItem->Descricao . '</b><br>';
				$arrDocumentosItem = $objMensagemItem->Documentos->DocumentosItem;
				// Se foi enviado somente um <DadosItem> de um mesmo tipo, retorna um objeto pronto.
				// Se foram enviados mais de um <DadosItem> de um tipo (NFC-e, NF-e, NFS-e, etc), retorna um array de objetos
				// Ex.: Foram enviadas duas NF-e
				if (!is_array($arrDocumentosItem)) { // Se foi enviado apenas uma nota, transforma para array para poder reaproveitar o código do foreach
					$arrDocumentosItem = array($arrDocumentosItem);
				}
				
				foreach($arrDocumentosItem as $objDocumentosItem) {
					$xmlDocumentoRetorno = $objDocumentosItem->Documento;
					echo 'Documento Retorno: ' . htmlentities($xmlDocumentoRetorno, ENT_QUOTES, 'UTF-8') . '<br>';
				}
				
			} else { // Código <> 100 é falha no processo
				
				echo 'Falha: ' . '[' . $objMensagemItem->Codigo . '] ' . $objMensagemItem->Descricao . '<br>';
				
			}
		}
	} else {
		echo 'Retorno inválido!';
		echo '<pre>';
		var_dump($objRetorno);
		echo '</pre>';
	}
} catch (SoapFault $ex) {
	// Captura o erro do SOAP. Documentação da SoapFault: http://www.php.net/manual/pt_BR/class.soapfault.php
	echo 'Falha no SOAP: ' . '[' . $ex->getCode() . '] ' . $ex->getMessage() . '<br>';
	echo '<pre>';
	var_dump($ex);
	echo '</pre>';
}
