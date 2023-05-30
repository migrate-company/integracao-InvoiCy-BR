namespace ConsoleUI.Models
{
    public class RequestParams
    {
        public string cnpj { get; set; }
        public string chaveDeAcesso { get; set; }
        public string chaveDeParceiro { get; set; } //EmpPK
        public int jwtTokenExp { get; set; } //Tempo expiração Token JWT
    }
}

/* https://desenvolvedores.migrate.info/2020/06/integracao-via-api-rest-para-emissao-de-documentos/
 * O parâmetro “sub” é uma string com o CNPJ da empresa ou a chave de parceiro. 
 * Quando for gerado um token para cadastro/atualização de empresa deverá conter a chave de parceiro nesse caso, no restante das situações será utilizado o CNPJ da empresa. 
 * Mas atenção, quando for gerado um token para integração com a extensão InvoiCy Tax Template, o parâmetro “sub” também deve ser preenchido com a chave de parceiro.
 * 
 * O parâmetro “partnerKey” é uma string com a chave de parceiro fornecida pelo InvoiCy. 
 * Quando for gerado um token para cadastro de empresa, não enviar essa informação. 
 * Quando for gerado um token para integração com a extensão InvoiCy Tax Template, o parâmetro “partnerKey” também não deve ser informado.
 * 
 * A chave de acesso é a chave privada fornecida pelo InvoiCy para cada empresa cadastrada. 
 * Quando for gerado um token para cadastro de empresa deverá conter a chave de acesso do parceiro nesse caso. 
 * 
 * Obs: para consulta de empresa utilizar o token com o CNPJ e não chave de parceiro.
 */