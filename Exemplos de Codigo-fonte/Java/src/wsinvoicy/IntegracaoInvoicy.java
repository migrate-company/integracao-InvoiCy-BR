//GEN-FIRST:event_btnEnviarActionPerformed
/*//GEN-LAST:event_btnEnviarActionPerformed
* To change this template, choose Tools | Templates
* and open the template in the editor.
 */
package wsinvoicy;

//~--- non-JDK imports --------------------------------------------------------


import invoicy.RecepcaoStub;
import invoicy.RecepcaoStub.InvoiCyRecepcaoCabecalho;

import org.apache.http.client.methods.CloseableHttpResponse;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.ContentType;
import org.apache.http.entity.InputStreamEntity;
import org.apache.http.impl.client.CloseableHttpClient;
import org.apache.http.impl.client.HttpClients;

//~--- JDK imports ------------------------------------------------------------

import java.io.BufferedReader;
import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.io.InputStreamReader;

import java.nio.charset.StandardCharsets;
import java.rmi.RemoteException;

import java.security.MessageDigest;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JOptionPane;
import javax.xml.stream.XMLStreamException;
import org.apache.axis2.AxisFault;


/**
 *
 * @author migrate
 */
public class IntegracaoInvoicy extends javax.swing.JFrame {

    // Variables declaration - do not modify
    private javax.swing.JButton     btnEnviar;
    private javax.swing.JLabel      jLabel1;
    private javax.swing.JLabel      jLabel2;
    private javax.swing.JLabel      jLabel3;
    private javax.swing.JLabel      jLabel4;
    private javax.swing.JLabel      jLabel5;
    private javax.swing.JLabel      jLabel6;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JScrollPane jScrollPane3;
    private javax.swing.JTextArea   jTextArea1;
    private javax.swing.JTextField  txtChaveAcesso;
    private javax.swing.JTextField  txtChaveParceiro;
    private javax.swing.JTextArea   txtRetDocumento;
    private javax.swing.JTextField  txtRetMensagem;
    private javax.swing.JTextArea   txtXML;

    /**
     * Creates new form IntegracaoInvoicy
     */
    public IntegracaoInvoicy() {
        initComponents();
    }

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")

    // <editor-fold defaultstate="collapsed" desc="Generated Code">
    private void initComponents() {
        jScrollPane1     = new javax.swing.JScrollPane();
        jTextArea1       = new javax.swing.JTextArea();
        jLabel1          = new javax.swing.JLabel();
        txtChaveParceiro = new javax.swing.JTextField();
        jLabel2          = new javax.swing.JLabel();
        txtChaveAcesso   = new javax.swing.JTextField();
        jLabel3          = new javax.swing.JLabel();
        jScrollPane2     = new javax.swing.JScrollPane();
        txtXML           = new javax.swing.JTextArea();
        btnEnviar        = new javax.swing.JButton();
        jLabel4          = new javax.swing.JLabel();
        jLabel5          = new javax.swing.JLabel();
        txtRetMensagem   = new javax.swing.JTextField();
        jLabel6          = new javax.swing.JLabel();
        jScrollPane3     = new javax.swing.JScrollPane();
        txtRetDocumento  = new javax.swing.JTextArea();
        jTextArea1.setColumns(20);
        jTextArea1.setRows(5);
        jScrollPane1.setViewportView(jTextArea1);
        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        jLabel1.setText("Chave do Parceiro");
        jLabel2.setText("Chave de Acesso");
        jLabel3.setText("XML de Integração");
        txtXML.setColumns(20);
        txtXML.setLineWrap(true);
        txtXML.setRows(5);
        jScrollPane2.setViewportView(txtXML);
        btnEnviar.setText("Enviar");
        btnEnviar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                try {
                        try {
                            btnEnviarActionPerformed(evt);
                        } catch (RemoteException ex) {
                            Logger.getLogger(IntegracaoInvoicy.class.getName()).log(Level.SEVERE, null, ex);
                        }
                } catch (XMLStreamException ex) {
                    Logger.getLogger(IntegracaoInvoicy.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
        });
        jLabel4.setText("Retorno do Web Service");
        jLabel5.setText("Mensagem");
        jLabel6.setText("Documento");
        txtRetDocumento.setColumns(20);
        txtRetDocumento.setLineWrap(true);
        txtRetDocumento.setRows(5);
        jScrollPane3.setViewportView(txtRetDocumento);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());

        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup().addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(jScrollPane2)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                    .addComponent(jLabel1)
                                    .addComponent(txtChaveParceiro, javax.swing.GroupLayout.PREFERRED_SIZE, 240,
                                        javax.swing.GroupLayout.PREFERRED_SIZE))
                                            .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                                .addGroup(layout
                                                    .createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                                                        .addComponent(jLabel2)
                                                            .addComponent(txtChaveAcesso,
                                                                javax.swing.GroupLayout.PREFERRED_SIZE, 252,
                                                                    javax.swing.GroupLayout.PREFERRED_SIZE)))
                                                                        .addComponent(jLabel3).addComponent(btnEnviar)
                                                                            .addComponent(jLabel4).addComponent(jLabel5)
                                                                                .addComponent(jLabel6))
                                                                                    .addGap(0, 180, Short.MAX_VALUE))
                                                                                        .addComponent(jScrollPane3)
                                                                                            .addComponent(txtRetMensagem))
                                                                                                .addContainerGap()));
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(
                layout.createSequentialGroup().addContainerGap().addGroup(
                    layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(
                        jLabel1).addComponent(jLabel2)).addPreferredGap(
                            javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(
                            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(
                                txtChaveParceiro, javax.swing.GroupLayout.PREFERRED_SIZE,
                                javax.swing.GroupLayout.DEFAULT_SIZE,
                                javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(
                                    txtChaveAcesso, javax.swing.GroupLayout.PREFERRED_SIZE,
                                    javax.swing.GroupLayout.DEFAULT_SIZE,
                                    javax.swing.GroupLayout.PREFERRED_SIZE)).addGap(18, 18, 18).addComponent(
                                        jLabel3).addPreferredGap(
                                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                                        jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 223,
                                        javax.swing.GroupLayout.PREFERRED_SIZE).addGap(18, 18, 18).addComponent(
                                            btnEnviar).addGap(18, 18, 18).addComponent(jLabel4).addPreferredGap(
                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                                                    jLabel5).addPreferredGap(
                                                        javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                                                            txtRetMensagem, javax.swing.GroupLayout.PREFERRED_SIZE,
                                                                javax.swing.GroupLayout.DEFAULT_SIZE,
                                                                    javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(
                                                                        javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addComponent(
                                                                            jLabel6).addPreferredGap(
                                                                                javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(
                                                                                    jScrollPane3,
                                                                                        javax.swing.GroupLayout.DEFAULT_SIZE,
                                                                                            197,
                                                                                            Short.MAX_VALUE).addContainerGap()));
        pack();
    }    // </editor-fold>

    private void btnEnviarActionPerformed(java.awt.event.ActionEvent evt) throws XMLStreamException, AxisFault, RemoteException {

        
        //Exemplo de consumo manual do Web Service
		ExemploManual();
		
		//Exemplo de consumo utilizando as classes geradas
        //ExemploStub();
    }

    //Função que executa a requisição do webservice via importação da biblioteca InvoiCyNfeClient.
    public void ExemploStub() throws RemoteException{

        // Passa para variaveis o texto do XML dos campos da tela da tela
        String EmpPK            = txtChaveParceiro.getText();
        String XmlIntegracao    = txtXML.getText();
        String ChaveComunicacao = txtChaveAcesso.getText();

        // Lineariza o xml de integração com expressão regular. 
        XmlIntegracao = XmlIntegracao.replaceAll("(?ism)(?<=>)[^a-z|0-9]*(?=<)", "");

        // Gera Hash MD5
        String texto      = ChaveComunicacao + XmlIntegracao;
        String HashGerado = GeraHashMD5(texto);
        
        //Monta um objeto Cabecalho contendo os dados da PK, CK e CO
        InvoiCyRecepcaoCabecalho cabecalho = new RecepcaoStub.InvoiCyRecepcaoCabecalho();
        cabecalho.setEmpPK(EmpPK);
        cabecalho.setEmpCK(HashGerado);
        cabecalho.setEmpCO("");
        
        //Obrigatório instanciar um objeto
        RecepcaoStub.InvoiCyRecepcaoInformacoes informacoes = new RecepcaoStub.InvoiCyRecepcaoInformacoes();
        informacoes.setTexto("");
        
        //Insere os itens dos dados da conexao. 
        RecepcaoStub.InvoiCyRecepcaoDadosItem dadosItem = new RecepcaoStub.InvoiCyRecepcaoDadosItem();
        dadosItem.setDocumento(XmlIntegracao); 
        dadosItem.setParametros("");
        
        //Instancia um objeto contendo os itens dos dados da conexão
        RecepcaoStub.Dados_type0 dados = new RecepcaoStub.Dados_type0();
        dados.addDadosItem(dadosItem);
		//Neste exemplo foi utilizado apenas um item, porém vários documentos podem ser enviados na mesma chamada
      
        //Insere na conexão o cabeçalho, dados e informações.
        RecepcaoStub.InvoiCy inv = new RecepcaoStub.InvoiCy();
        inv.setCabecalho(cabecalho);
        inv.setDados(dados);
        inv.setInformacoes(informacoes);
        
        //Instancia um objeto com a requisição para chamar o webservice
        RecepcaoStub.RecepcaoExecute exec = new RecepcaoStub.RecepcaoExecute();
        exec.setInvoicyrecepcao(inv);
        
        //Executa e recebe o retorno da requisição
        RecepcaoStub stub = new RecepcaoStub();
        RecepcaoStub.RecepcaoExecuteResponse resp = stub.execute(exec);
       
        //Busca o retorno e recupera as mensagens de retorno
        RecepcaoStub.Invoicyretorno retorno =  resp.getInvoicyretorno();
        RecepcaoStub.Mensagem_type0 mensagem = retorno.getMensagem();
        RecepcaoStub.InvoiCyRetornoMensagemItem[] item = mensagem.getMensagemItem();
      
        //Mostra em tela o código e a mensagem de retorno.
        txtRetMensagem.setText(item[0].getCodigo() + " - " + item[0].getDescricao());
        
        //Recupera os dados de retorno.
        RecepcaoStub.Documentos_type0 docs = item[0].getDocumentos();
        RecepcaoStub.InvoiCyRetornoMensagemItemDocumentosItem[] docItem = docs.getDocumentosItem();
        
        //Mostra em tela o xml do reotrno da conexão.
        txtRetDocumento.setText(docItem[0].getDocumento().trim());
                
    }
        

    //Função que executa a requisição do webservice manualmente.
    public void ExemploManual() {
        try {

            // Adiciono para variaveis o texto do XML da tela
            String EmpPK            = txtChaveParceiro.getText();
            String XmlIntegracao    = txtXML.getText();
            String ChaveComunicacao = txtChaveAcesso.getText();

            // Chama função que faz a escrita do SOAP
            String xmlGerado = retornaEscritaSoap(XmlIntegracao, EmpPK, ChaveComunicacao);

            // Guarda em stream o contedúdo da escrita do XML
            InputStream stream = new ByteArrayInputStream(xmlGerado.getBytes(StandardCharsets.UTF_8));

            // Pega o conteudo stream e define codificação a ele.
            InputStreamEntity reqEntity = new InputStreamEntity(stream, -1, ContentType.TEXT_XML);

            // Informar True, pois o tamanho da entidade é desconhecido, ou seja, pode variar dependendo do tamanho da string
            reqEntity.setChunked(true);

            // Informa o nome da URL que será feito o POST
            HttpPost httppost = new HttpPost("https://homolog.invoicy.com.br:443/arecepcao.aspx");

            httppost.setEntity(reqEntity);

            // Instancia um objeto httpclient
            CloseableHttpClient httpclient = HttpClients.createDefault();

            // Instancia um objeto httpresponse para receber o retorno da requisição
            CloseableHttpResponse response = httpclient.execute(httppost);

            // Grava em buffer o stream do retorno da requisição
            BufferedReader rd = new BufferedReader(new InputStreamReader(response.getEntity().getContent()));

            // Faz a leitura linha a linha do retorno da requisição
            StringBuilder result = new StringBuilder();
            String        line   = "";

            while ((line = rd.readLine()) != null) {
                result.append(line.replaceAll("\t", "").replaceAll("\n", ""));
            }

            //Recupera do xml de reotrno o código e a descrição do retorno da requisição.
            String codigoRetorno = result.substring(result.indexOf("<Codigo>"), result.indexOf("</Codigo>")).replaceAll("<Codigo>", "");
            String descricaoRetorno = result.substring(result.indexOf("<Descricao>"), result.indexOf("</Descricao>")).replaceAll("<Descricao>", "");
            txtRetMensagem.setText(codigoRetorno + " - " + descricaoRetorno);
            
            String resultado = result.toString();                   
            txtRetDocumento.setText("" + resultado);
            
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }

    
    
    public static String retornaEscritaSoap(String XmlIntegracao, String EmpPK, String ChaveComunicacao) {
        String sBody = "";

        sBody = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:inv=\"InvoiCy\">";
        sBody += "<soapenv:Header/>";
        sBody += "<soapenv:Body>";
        sBody += "<inv:recepcao.Execute>";
        sBody += "<inv:Invoicyrecepcao>";
        sBody += "<inv:Cabecalho>";
        sBody += "<inv:EmpPK>" + EmpPK + "</inv:EmpPK>";

        // Lineariza o xml de integração com expressão regular.
        XmlIntegracao = XmlIntegracao.replaceAll("(?ism)(?<=>)[^a-z|0-9]*(?=<)", "");

        // Gera Hash MD5
        String texto      = ChaveComunicacao + XmlIntegracao;
        String HashGerado = GeraHashMD5(texto);

//        JOptionPane.showMessageDialog(null, HashGerado);
        
        sBody += "<inv:EmpCK>" + HashGerado + "</inv:EmpCK>";
        sBody += "<inv:EmpCO></inv:EmpCO>";
        sBody += "</inv:Cabecalho>";
        sBody += "<inv:Informacoes>";
        sBody += "<inv:Texto></inv:Texto>";
        sBody += "</inv:Informacoes>";
        sBody += "<inv:Dados>";
        sBody += "<inv:DadosItem>";

        // Converte XML de integração para texto
        String XmlEnvio = XmlIntegracao;

        XmlEnvio = XmlEnvio.replaceAll("<", "&lt;");
        XmlEnvio = XmlEnvio.replaceAll(">", "&gt;");
        XmlEnvio = XmlEnvio.replaceAll("\"", "&quot;");
        sBody    += "<inv:Documento>" + XmlEnvio + "</inv:Documento>";
        sBody    += "<inv:Parametros></inv:Parametros>";
        sBody    += "</inv:DadosItem>";
        sBody    += "</inv:Dados>";
        sBody    += "</inv:Invoicyrecepcao>";
        sBody    += "</inv:recepcao.Execute>";
        sBody    += "</soapenv:Body>";
        sBody    += "</soapenv:Envelope>";

        return sBody;
    }


    public static String GeraHashMD5(String xml) {
        try {
            
            MessageDigest md        = MessageDigest.getInstance("MD5");
            byte[]        thedigest = md.digest(xml.getBytes("UTF-8"));
            StringBuilder sb        = new StringBuilder();

            for (int i = 0; i < thedigest.length; i++) {
                sb.append(Integer.toHexString((thedigest[i] & 0xFF) | 0x100).substring(1, 3));
            }

            return sb.toString();

        } catch (Exception ex) {
            return ex.toString();
        }
    }

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {

        /*
         * Set the Nimbus look and feel
         */

        // <editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">

        /*
         * If Nimbus (introduced in Java SE 6) is not available, stay with the
         * default look and feel. For details see
         * http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());

                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(IntegracaoInvoicy.class.getName()).log(java.util.logging.Level.SEVERE,
                                               null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(IntegracaoInvoicy.class.getName()).log(java.util.logging.Level.SEVERE,
                                               null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(IntegracaoInvoicy.class.getName()).log(java.util.logging.Level.SEVERE,
                                               null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(IntegracaoInvoicy.class.getName()).log(java.util.logging.Level.SEVERE,
                                               null, ex);
        }

        // </editor-fold>

        /*
         * Create and display the form
         */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new IntegracaoInvoicy().setVisible(true);
            }
        });
    }

    // End of variables declaration
}


//~ Formatted by Jindent --- http://www.jindent.com