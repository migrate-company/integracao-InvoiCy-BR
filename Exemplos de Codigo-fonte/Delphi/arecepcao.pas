// ************************************************************************ //
// The types declared in this file were generated from data read from the
// WSDL File described below:
// WSDL     : https://homolog.invoicy.com.br/arecepcao.aspx?wsdl
//  >Import : https://homolog.invoicy.com.br/arecepcao.aspx?wsdl>0
// Encoding : utf-8
// Version  : 1.0
// (16/05/2014 17:26:50 - - $Rev: 34800 $)
// ************************************************************************ //

unit arecepcao;

interface

uses InvokeRegistry, SOAPHTTPClient, Types, XSBuiltIns;

const
  IS_OPTN = $0001;
  IS_UNBD = $0002;
  IS_REF  = $0080;


type

  // ************************************************************************ //
  // The following types, referred to in the WSDL document are not being represented
  // in this file. They are either aliases[@] of other types represented or were referred
  // to but never[!] declared in the document. The types from the latter category
  // typically map to predefined/known XML or Embarcadero types; however, they could also
  // indicate incorrect WSDL documents that failed to declare or import a schema type.
  // ************************************************************************ //
  // !:int             - "http://www.w3.org/2001/XMLSchema"[Gbl]
  // !:string          - "http://www.w3.org/2001/XMLSchema"[Gbl]

  recepcao_Execute     = class;                 { "InvoiCy"[Lit][GblElm] }
  recepcao_ExecuteResponse = class;             { "InvoiCy"[Lit][GblElm] }
  InvoiCy              = class;                 { "InvoiCy"[GblCplx] }
  Invoicyretorno       = class;                 { "InvoiCy"[GblCplx] }
  InvoiCyRecepcao_DadosItem = class;            { "InvoiCy"[GblCplx] }
  InvoiCyRecepcao_Cabecalho = class;            { "InvoiCy"[GblCplx] }
  InvoiCyRecepcao_Informacoes = class;          { "InvoiCy"[GblCplx] }
  InvoiCyRetorno_MensagemItem_DocumentosItem = class;   { "InvoiCy"[GblCplx] }
  InvoiCyRetorno_MensagemItem = class;          { "InvoiCy"[GblCplx] }



  // ************************************************************************ //
  // XML       : recepcao.Execute, global, <element>
  // Namespace : InvoiCy
  // Serializtn: [xoLiteralParam]
  // Info      : Wrapper
  // ************************************************************************ //
  recepcao_Execute = class(TRemotable)
  private
    FInvoicyrecepcao: InvoiCy;
  public
    constructor Create; override;
    destructor Destroy; override;
  published
    property Invoicyrecepcao: InvoiCy  read FInvoicyrecepcao write FInvoicyrecepcao;
  end;



  // ************************************************************************ //
  // XML       : recepcao.ExecuteResponse, global, <element>
  // Namespace : InvoiCy
  // Serializtn: [xoLiteralParam]
  // Info      : Wrapper
  // ************************************************************************ //
  recepcao_ExecuteResponse = class(TRemotable)
  private
    FInvoicyretorno: Invoicyretorno;
  public
    constructor Create; override;
    destructor Destroy; override;
  published
    property Invoicyretorno: Invoicyretorno  read FInvoicyretorno write FInvoicyretorno;
  end;

  Documentos = array of InvoiCyRetorno_MensagemItem_DocumentosItem;   { "InvoiCy"[Cplx] }
  Dados      = array of InvoiCyRecepcao_DadosItem;   { "InvoiCy"[Cplx] }


  // ************************************************************************ //
  // XML       : InvoiCy, global, <complexType>
  // Namespace : InvoiCy
  // ************************************************************************ //
  InvoiCy = class(TRemotable)
  private
    FCabecalho: InvoiCyRecepcao_Cabecalho;
    FInformacoes: InvoiCyRecepcao_Informacoes;
    FDados: Dados;
  public
    destructor Destroy; override;

  published
    property Cabecalho:   InvoiCyRecepcao_Cabecalho    read FCabecalho write FCabecalho;
    property Informacoes: InvoiCyRecepcao_Informacoes  read FInformacoes write FInformacoes;
    property Dados:       Dados                        read FDados write FDados;
  end;

  Mensagem   = array of InvoiCyRetorno_MensagemItem;   { "InvoiCy"[Cplx] }


  // ************************************************************************ //
  // XML       : Invoicyretorno, global, <complexType>
  // Namespace : InvoiCy
  // ************************************************************************ //
  Invoicyretorno = class(TRemotable)
  private
    FMensagem: Mensagem;
  public
    destructor Destroy; override;
  published
    property Mensagem: Mensagem  read FMensagem write FMensagem;
  end;



  // ************************************************************************ //
  // XML       : InvoiCyRecepcao.DadosItem, global, <complexType>
  // Namespace : InvoiCy
  // ************************************************************************ //
  InvoiCyRecepcao_DadosItem = class(TRemotable)
  private
    FDocumento: string;
    FParametros: string;
  published
    property Documento:  string  read FDocumento write FDocumento;
    property Parametros: string  read FParametros write FParametros;
  end;



  // ************************************************************************ //
  // XML       : InvoiCyRecepcao.Cabecalho, global, <complexType>
  // Namespace : InvoiCy
  // ************************************************************************ //
  InvoiCyRecepcao_Cabecalho = class(TRemotable)
  private
    FEmpPK: string;
    FEmpCK: string;
    FEmpCO: string;
  published
    property EmpPK: string  read FEmpPK write FEmpPK;
    property EmpCK: string  read FEmpCK write FEmpCK;
    property EmpCO: string  read FEmpCO write FEmpCO;
  end;



  // ************************************************************************ //
  // XML       : InvoiCyRecepcao.Informacoes, global, <complexType>
  // Namespace : InvoiCy
  // ************************************************************************ //
  InvoiCyRecepcao_Informacoes = class(TRemotable)
  private
    FTexto: string;
  published
    property Texto: string  read FTexto write FTexto;
  end;



  // ************************************************************************ //
  // XML       : InvoiCyRetorno.MensagemItem.DocumentosItem, global, <complexType>
  // Namespace : InvoiCy
  // ************************************************************************ //
  InvoiCyRetorno_MensagemItem_DocumentosItem = class(TRemotable)
  private
    FDocumento: string;
  published
    property Documento: string  read FDocumento write FDocumento;
  end;



  // ************************************************************************ //
  // XML       : InvoiCyRetorno.MensagemItem, global, <complexType>
  // Namespace : InvoiCy
  // ************************************************************************ //
  InvoiCyRetorno_MensagemItem = class(TRemotable)
  private
    FCodigo: Integer;
    FDescricao: string;
    FDocumentos: Documentos;
  public
    destructor Destroy; override;
  published
    property Codigo:     Integer     read FCodigo write FCodigo;
    property Descricao:  string      read FDescricao write FDescricao;
    property Documentos: Documentos  read FDocumentos write FDocumentos;
  end;


  // ************************************************************************ //
  // Namespace : InvoiCy
  // soapAction: InvoiCyaction/ARECEPCAO.Execute
  // transport : http://schemas.xmlsoap.org/soap/http
  // style     : document
  // use       : literal
  // binding   : recepcaoSoapBinding
  // service   : recepcao
  // port      : recepcaoSoapPort
  // URL       : http://homolog.invoicy.com.br/arecepcao.aspx
  // ************************************************************************ //
  recepcaoSoapPort = interface(IInvokable)
  ['{934B4BF5-ABE5-DE0F-11AA-480CF50E183B}']

    // Cannot unwrap:
    //     - Input element wrapper name does not match operation's name
    function  Execute(const parameters: recepcao_Execute): recepcao_ExecuteResponse; stdcall;
  end;

function GetrecepcaoSoapPort(UseWSDL: Boolean=System.False; Addr: string=''; HTTPRIO: THTTPRIO = nil): recepcaoSoapPort;


implementation
  uses SysUtils;

function GetrecepcaoSoapPort(UseWSDL: Boolean; Addr: string; HTTPRIO: THTTPRIO): recepcaoSoapPort;
const
  defWSDL = 'https://homolog.invoicy.com.br/arecepcao.aspx?wsdl';
  defURL  = 'https://homolog.invoicy.com.br/arecepcao.aspx';
  defSvc  = 'recepcao';
  defPrt  = 'recepcaoSoapPort';
var
  RIO: THTTPRIO;
begin
  Result := nil;
  if (Addr = '') then
  begin
    if UseWSDL then
      Addr := defWSDL
    else
      Addr := defURL;
  end;
  if HTTPRIO = nil then
    RIO := THTTPRIO.Create(nil)
  else
    RIO := HTTPRIO;
  try
    Result := (RIO as recepcaoSoapPort);
    if UseWSDL then
    begin
      RIO.WSDLLocation := Addr;
      RIO.Service := defSvc;
      RIO.Port := defPrt;
    end else
      RIO.URL := Addr;
  finally
    if (Result = nil) and (HTTPRIO = nil) then
      RIO.Free;
  end;
end;


constructor recepcao_Execute.Create;
begin
  inherited Create;
  FSerializationOptions := [xoLiteralParam];
end;

destructor recepcao_Execute.Destroy;
begin
  SysUtils.FreeAndNil(FInvoicyrecepcao);
  inherited Destroy;
end;

constructor recepcao_ExecuteResponse.Create;
begin
  inherited Create;
  FSerializationOptions := [xoLiteralParam];
end;

destructor recepcao_ExecuteResponse.Destroy;
begin
  SysUtils.FreeAndNil(FInvoicyretorno);
  inherited Destroy;
end;

destructor InvoiCy.Destroy;
var
  I: Integer;
begin
  for I := 0 to System.Length(FDados)-1 do
    SysUtils.FreeAndNil(FDados[I]);
  System.SetLength(FDados, 0);
  SysUtils.FreeAndNil(FCabecalho);
  SysUtils.FreeAndNil(FInformacoes);
  inherited Destroy;
end;


destructor Invoicyretorno.Destroy;
var
  I: Integer;
begin
  for I := 0 to System.Length(FMensagem)-1 do
    SysUtils.FreeAndNil(FMensagem[I]);
  System.SetLength(FMensagem, 0);
  inherited Destroy;
end;

destructor InvoiCyRetorno_MensagemItem.Destroy;
var
  I: Integer;
begin
  for I := 0 to System.Length(FDocumentos)-1 do
    SysUtils.FreeAndNil(FDocumentos[I]);
  System.SetLength(FDocumentos, 0);
  inherited Destroy;
end;

initialization
  { recepcaoSoapPort }
  InvRegistry.RegisterInterface(TypeInfo(recepcaoSoapPort), 'InvoiCy', 'utf-8');
  InvRegistry.RegisterDefaultSOAPAction(TypeInfo(recepcaoSoapPort), 'InvoiCyaction/ARECEPCAO.Execute');
  InvRegistry.RegisterInvokeOptions(TypeInfo(recepcaoSoapPort), ioDocument);
  InvRegistry.RegisterInvokeOptions(TypeInfo(recepcaoSoapPort), ioLiteral);
  RemClassRegistry.RegisterXSClass(recepcao_Execute, 'InvoiCy', 'recepcao_Execute', 'recepcao.Execute');
  RemClassRegistry.RegisterSerializeOptions(recepcao_Execute, [xoLiteralParam]);
  RemClassRegistry.RegisterXSClass(recepcao_ExecuteResponse, 'InvoiCy', 'recepcao_ExecuteResponse', 'recepcao.ExecuteResponse');
  RemClassRegistry.RegisterSerializeOptions(recepcao_ExecuteResponse, [xoLiteralParam]);
  RemClassRegistry.RegisterXSInfo(TypeInfo(Documentos), 'InvoiCy', 'Documentos');
  RemClassRegistry.RegisterXSInfo(TypeInfo(Dados), 'InvoiCy', 'Dados');
  RemClassRegistry.RegisterXSClass(InvoiCy, 'InvoiCy', 'InvoiCy');
  RemClassRegistry.RegisterExternalPropName(TypeInfo(InvoiCy), 'Dados', '[ArrayItemName="DadosItem"]');
  RemClassRegistry.RegisterXSInfo(TypeInfo(Mensagem), 'InvoiCy', 'Mensagem');
  RemClassRegistry.RegisterXSClass(Invoicyretorno, 'InvoiCy', 'Invoicyretorno');
  RemClassRegistry.RegisterExternalPropName(TypeInfo(Invoicyretorno), 'Mensagem', '[ArrayItemName="MensagemItem"]');
  RemClassRegistry.RegisterXSClass(InvoiCyRecepcao_DadosItem, 'InvoiCy', 'InvoiCyRecepcao_DadosItem', 'InvoiCyRecepcao.DadosItem');
  RemClassRegistry.RegisterXSClass(InvoiCyRecepcao_Cabecalho, 'InvoiCy', 'InvoiCyRecepcao_Cabecalho', 'InvoiCyRecepcao.Cabecalho');
  RemClassRegistry.RegisterXSClass(InvoiCyRecepcao_Informacoes, 'InvoiCy', 'InvoiCyRecepcao_Informacoes', 'InvoiCyRecepcao.Informacoes');
  RemClassRegistry.RegisterXSClass(InvoiCyRetorno_MensagemItem_DocumentosItem, 'InvoiCy', 'InvoiCyRetorno_MensagemItem_DocumentosItem', 'InvoiCyRetorno.MensagemItem.DocumentosItem');
  RemClassRegistry.RegisterXSClass(InvoiCyRetorno_MensagemItem, 'InvoiCy', 'InvoiCyRetorno_MensagemItem', 'InvoiCyRetorno.MensagemItem');
  RemClassRegistry.RegisterExternalPropName(TypeInfo(InvoiCyRetorno_MensagemItem), 'Documentos', '[ArrayItemName="DocumentosItem"]');

end.
