<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExemploIntegracao
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExemploIntegracao))
        Me.lblChaParceiro = New System.Windows.Forms.Label()
        Me.txtChaveParceiro = New System.Windows.Forms.TextBox()
        Me.txtChaveComunicacao = New System.Windows.Forms.TextBox()
        Me.lblChaAcesso = New System.Windows.Forms.Label()
        Me.txtRetMensagem = New System.Windows.Forms.TextBox()
        Me.txtXML = New System.Windows.Forms.RichTextBox()
        Me.txtRetDocumento = New System.Windows.Forms.RichTextBox()
        Me.btnExecutar = New System.Windows.Forms.Button()
        Me.lblMsgRetorno = New System.Windows.Forms.Label()
        Me.lblDocumentoRetorno = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblChaParceiro
        '
        resources.ApplyResources(Me.lblChaParceiro, "lblChaParceiro")
        Me.lblChaParceiro.Name = "lblChaParceiro"
        '
        'txtChaveParceiro
        '
        resources.ApplyResources(Me.txtChaveParceiro, "txtChaveParceiro")
        Me.txtChaveParceiro.Name = "txtChaveParceiro"
        '
        'txtChaveComunicacao
        '
        resources.ApplyResources(Me.txtChaveComunicacao, "txtChaveComunicacao")
        Me.txtChaveComunicacao.Name = "txtChaveComunicacao"
        '
        'lblChaAcesso
        '
        resources.ApplyResources(Me.lblChaAcesso, "lblChaAcesso")
        Me.lblChaAcesso.Name = "lblChaAcesso"
        '
        'txtRetMensagem
        '
        resources.ApplyResources(Me.txtRetMensagem, "txtRetMensagem")
        Me.txtRetMensagem.Name = "txtRetMensagem"
        '
        'txtXML
        '
        resources.ApplyResources(Me.txtXML, "txtXML")
        Me.txtXML.Name = "txtXML"
        '
        'txtRetDocumento
        '
        resources.ApplyResources(Me.txtRetDocumento, "txtRetDocumento")
        Me.txtRetDocumento.Name = "txtRetDocumento"
        '
        'btnExecutar
        '
        resources.ApplyResources(Me.btnExecutar, "btnExecutar")
        Me.btnExecutar.Name = "btnExecutar"
        Me.btnExecutar.UseVisualStyleBackColor = True
        '
        'lblMsgRetorno
        '
        resources.ApplyResources(Me.lblMsgRetorno, "lblMsgRetorno")
        Me.lblMsgRetorno.Name = "lblMsgRetorno"
        '
        'lblDocumentoRetorno
        '
        resources.ApplyResources(Me.lblDocumentoRetorno, "lblDocumentoRetorno")
        Me.lblDocumentoRetorno.Name = "lblDocumentoRetorno"
        '
        'ExemploIntegracao
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblDocumentoRetorno)
        Me.Controls.Add(Me.lblMsgRetorno)
        Me.Controls.Add(Me.btnExecutar)
        Me.Controls.Add(Me.txtRetDocumento)
        Me.Controls.Add(Me.txtXML)
        Me.Controls.Add(Me.txtRetMensagem)
        Me.Controls.Add(Me.lblChaAcesso)
        Me.Controls.Add(Me.txtChaveComunicacao)
        Me.Controls.Add(Me.txtChaveParceiro)
        Me.Controls.Add(Me.lblChaParceiro)
        Me.MaximizeBox = False
        Me.Name = "ExemploIntegracao"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblChaParceiro As Label
    Friend WithEvents txtChaveParceiro As TextBox
    Friend WithEvents txtChaveComunicacao As TextBox
    Friend WithEvents lblChaAcesso As Label
    Friend WithEvents txtRetMensagem As TextBox
    Friend WithEvents txtXML As RichTextBox
    Friend WithEvents txtRetDocumento As RichTextBox
    Friend WithEvents btnExecutar As Button
    Friend WithEvents lblMsgRetorno As Label
    Friend WithEvents lblDocumentoRetorno As Label
End Class
