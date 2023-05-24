object Form1: TForm1
  Left = 0
  Top = 0
  BorderIcons = [biSystemMenu, biMinimize]
  Caption = 'Exemplo de Integra'#231#227'o InvoiCy'
  ClientHeight = 567
  ClientWidth = 576
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 17
    Top = 16
    Width = 88
    Height = 13
    Caption = 'Chave de Parceiro'
  end
  object Label2: TLabel
    Left = 305
    Top = 16
    Width = 83
    Height = 13
    Caption = 'Chave de Acesso'
  end
  object Label3: TLabel
    Left = 17
    Top = 72
    Width = 92
    Height = 13
    Caption = 'XML de integra'#231#227'o:'
  end
  object Label4: TLabel
    Left = 17
    Top = 349
    Width = 121
    Height = 13
    Caption = 'Retorno do Web Service:'
  end
  object Label5: TLabel
    Left = 17
    Top = 374
    Width = 55
    Height = 13
    Caption = 'Mensagem:'
  end
  object Label6: TLabel
    Left = 17
    Top = 423
    Width = 54
    Height = 13
    Caption = 'Documento'
  end
  object Button1: TButton
    Left = 17
    Top = 301
    Width = 113
    Height = 34
    Caption = 'Enviar'
    TabOrder = 0
    OnClick = Button1Click
  end
  object memEnvio: TMemo
    Left = 17
    Top = 90
    Width = 537
    Height = 198
    ScrollBars = ssVertical
    TabOrder = 1
  end
  object memRetorno: TMemo
    Left = 17
    Top = 444
    Width = 537
    Height = 97
    ScrollBars = ssVertical
    TabOrder = 2
  end
  object EdtChaveParceiro: TEdit
    Left = 17
    Top = 35
    Width = 241
    Height = 21
    TabOrder = 3
  end
  object EdtChaveComunicacao: TEdit
    Left = 305
    Top = 35
    Width = 249
    Height = 21
    TabOrder = 4
  end
  object EdtMensagem: TEdit
    Left = 17
    Top = 393
    Width = 537
    Height = 21
    TabOrder = 5
  end
end
