unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, SOAPHTTPTrans, IdHashMessageDigest, RegularExpressions, arecepcao;

type
  TForm1 = class(TForm)
    Button1: TButton;
    memEnvio: TMemo;
    memRetorno: TMemo;
    Label1: TLabel;
    EdtChaveParceiro: TEdit;
    EdtChaveComunicacao: TEdit;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    EdtMensagem: TEdit;
    Label5: TLabel;
    Label6: TLabel;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
    procedure ConsomeWsComWsdlImporter;
    procedure ConsomeWsSoapManual;
    function GeraHashMd5(texto: string):String;
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
   {Exemplo de consumo com o WSDL Import}
   ConsomeWsComWsdlImporter;

   {Exemplo de consumo, escrevendo o SOAP manualmente}
   //ConsomeWsSoapManual;

end;

procedure TForm1.ConsomeWsSoapManual;
var
  reqResp: THTTPReqResp;
  strStream: TStringStream;
  soap: String;
  xmlEnvio: string;
  ret: TMatchCollection;
begin
   try
    reqResp := THTTPReqResp.Create(nil);
    strStream := TStringStream.Create;

    try
      //------Lineariza XML de integração
      memEnvio.Lines.Text := StringReplace(memEnvio.Lines.Text,#9,'',[rfReplaceAll]);  //tabulação
      memEnvio.Lines.Text := StringReplace(memEnvio.Lines.Text,#13#10,'',[rfReplaceAll]); //quebras de linha

      //------Escreve XML SOAP
      soap := '<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:inv="InvoiCy">';
      soap := soap+'<soapenv:Header/>';
      soap := soap+ '<soapenv:Body>';
      soap := soap+   '<inv:recepcao.Execute>';
      soap := soap+     '<inv:Invoicyrecepcao>';
      soap := soap+       '<inv:Cabecalho>';
      soap := soap+         '<inv:EmpPK>'+EdtChaveParceiro.Text+'</inv:EmpPK>';
      soap := soap+         '<inv:EmpCK>'+LowerCase(GeraHashMd5(EdtChaveComunicacao.Text+memEnvio.Lines.Text))+'</inv:EmpCK>';
      soap := soap+         '<inv:EmpCO/>'; //tag utilizada apenas pelo DarumaFramework
      soap := soap+       '</inv:Cabecalho>';
      soap := soap+       '<inv:Informacoes>';
      soap := soap+         '<inv:Texto/>'; //grupo utilizado pelo DarumaFramework
      soap := soap+       '</inv:Informacoes>';
      soap := soap+       '<inv:Dados>';
      soap := soap+         '<inv:DadosItem>'; //Grupo dadosItem, pode repetir de acordo com a quantidade de documentos a ser enviada

      //converte XML de envio para texto
      xmlEnvio := memEnvio.Lines.Text;
      xmlEnvio := StringReplace(xmlEnvio,'<','&lt;',[rfReplaceAll]);
      xmlEnvio := StringReplace(xmlEnvio,'>','&gt;',[rfReplaceAll]);
      xmlEnvio := StringReplace(xmlEnvio,'"','&quot;',[rfReplaceAll]);

      soap := soap+           '<inv:Documento>'+xmlEnvio+'</inv:Documento>';
      soap := soap+           '<inv:Parametros></inv:Parametros>';
      soap := soap+         '</inv:DadosItem>';
      soap := soap+       '</inv:Dados>';
      soap := soap+     '</inv:Invoicyrecepcao>';
      soap := soap+   '</inv:recepcao.Execute>';
      soap := soap+ '</soapenv:Body>';
      soap := soap+'</soapenv:Envelope>';

      //------Define parâmetros da requisição
      reqResp.URL := 'https://homolog.invoicy.com.br/arecepcao.aspx';
      reqResp.SoapAction := 'InvoiCyaction/ARECEPCAO.Execute';
      reqResp.UseUTF8InHeader := True;

      //------Consome Web Service e coloca o retorno no Stream
      reqResp.Execute(soap,strStream);

      //------Trata o retorno
      {Para este exemplo, foi utilizado expressões regulares. Porém, o retorno também poderá ser lido como um XML.}
      ret := TRegEx.Matches(strStream.DataString,'<Codigo>(.*?)</Codigo>');
      EdtMensagem.Text := ret.Item[0].Groups[1].Value;
      ret := TRegEx.Matches(strStream.DataString,'<Descricao>(.*?)</Descricao>');
      EdtMensagem.Text := EdtMensagem.Text+' - '+ret.Item[0].Groups[1].Value;
      ret := TRegEx.Matches(strStream.DataString,'<Documento>(.*?)</Documento>');
      memRetorno.Lines.Text := ret.Item[0].Groups[1].Value;

    finally
      reqResp.Free;
      strStream.Free;

    end;

   except  on E:Exception do
      ShowMessage('Ocorreu um erro: '+e.Message);
   end;
end;


procedure TForm1.ConsomeWsComWsdlImporter;
var
  exec: recepcao_Execute;
  resp: recepcao_ExecuteResponse;
  inv: InvoiCy;
  cab: InvoiCyRecepcao_Cabecalho;
  dados: InvoiCyRecepcao_DadosItem;
  docs: arecepcao.Dados;
begin
  {Classe "arecepcao" foi gerada com o WSDLImporter}

  try
    //inicializa objetos da classe "arecepcao"
    exec := recepcao_Execute.Create;
    resp := recepcao_ExecuteResponse.Create;
    inv := InvoiCy.Create;
    cab := InvoiCyRecepcao_Cabecalho.Create;
    dados := InvoiCyRecepcao_DadosItem.Create;

    try
       //------Lineariza XML de integração
       memEnvio.Lines.Text := StringReplace(memEnvio.Lines.Text,#9,'',[rfReplaceAll]);  //tabulação
       memEnvio.Lines.Text := StringReplace(memEnvio.Lines.Text,#13#10,'',[rfReplaceAll]); //quebras de linha

       //------Preenche dados do cabeçalho
       cab.EmpPK := EdtChaveParceiro.Text;
       //Gera hash MD5 concatenando Chave de Comunicação e XML de integração
       cab.EmpCK := LowerCase(GeraHashMd5(EdtChaveComunicacao.Text+memEnvio.Lines.Text));
       inv.Cabecalho := cab;

       //------Preenche documento a ser enviado de acordo com o módulo (NF-e, NFC-e, MDF-e, CT-e)
       dados.Documento := memEnvio.Lines.Text;
       dados.Parametros := '';//Os parâmetros do documento, quando houver
       SetLength(docs,1);
       docs[0] := dados;
       inv.Dados := docs;
       {Para este exemplo foi enviado somente um documento "SetLength(docs,1)" para teste, porém pode-se enviar até 50 documentos na mesma chamada}

       //------Junta todos os dados a serem enviados
       exec.Invoicyrecepcao := inv;

       //Consome Web Service e atribui ao objeto a resposta
       resp := GetrecepcaoSoapPort.Execute(exec);

       //Trata retorno
       EdtMensagem.Text := IntToStr(resp.Invoicyretorno.Mensagem[0].Codigo)+' - '+resp.Invoicyretorno.Mensagem[0].Descricao;
       if resp.Invoicyretorno.Mensagem[0].Codigo = 100 then
         memRetorno.Lines.Text := resp.Invoicyretorno.Mensagem[0].Documentos[0].Documento;
       {O retorno do documento sempre será em formato XML. Desta forma, o XML poderá ser lido e as tags poderão ser tratadas individualmente}

    finally
      exec.Free;
      resp.Free;

    end;
  except on E:Exception do
      ShowMessage('Ocorreu um erro: '+E.Message);
  end;
End;

function TForm1.GeraHashMd5(texto: string):String;
var
  Md5: TidHashMessageDigest5;
begin
    Md5 := TidHashMessageDigest5.Create();
    try
      result := Md5.HashStringAsHex(texto)
    finally
      Md5.Free;
    end;
end;

end.
