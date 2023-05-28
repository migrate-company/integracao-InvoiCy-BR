using System;

namespace ConsoleUI.View
{
    public class IntegracaoView
    {
        public void Inicio()
        {
            Console.WriteLine("************ MIGRATE INVOICY - INTEGRAÇÃO REST C# ************");
            Console.WriteLine("Os dados da sua empresa devem ser editados na criação do usuário no arquivo IntegracaoController.cs");
            Console.WriteLine("Os arquivos em formato Json devem ser editados no arquivo Source.cs");
            Console.WriteLine("************ MIGRATE INVOICY - INTEGRAÇÃO REST C# ************");
        }

        public int MenuInicial()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Selecione a opção desejada");
            Console.WriteLine("1 - Autenticação");
            Console.WriteLine("2 - Empresa");
            Console.WriteLine("3 - Série");
            Console.WriteLine("4 - Documentos");
            int.TryParse(Console.ReadLine().Trim(), out int valor);
            return valor;
        }

        public int MenuAutenticacao()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Selecione a opção desejada:");
            Console.WriteLine("1 - Visualizar Token");
            Console.WriteLine("2 - Gerar Token");       //POST
            Console.WriteLine("3 - Validar Token");     //POST
            Console.WriteLine("4 - RenovarToken Token");//POST
            int.TryParse(Console.ReadLine().Trim(), out int valor);
            return valor;
        }

        public int MenuEmpresa()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Selecione a opção desejada:");
            Console.WriteLine("1 - Consultar Empresa"); //GET
            Console.WriteLine("2 - Cadastrar Empresa"); //POST
            Console.WriteLine("3 - Atualizar Empresa"); //PUT
            Console.WriteLine("4 - Licenciamento Empresa"); //POST
            Console.WriteLine("5 - Bilhetagem"); //POST
            Console.WriteLine("6 - Consulta CNPJ Sefaz"); //POST
            Console.WriteLine("7 - Consulta de MDF-e não encerrados"); //POST
            int.TryParse(Console.ReadLine().Trim(), out int valor);
            return valor;
        }

        public int MenuSerie()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Selecione a opção desejada:");
            Console.WriteLine("1 - Consultar Série");   //GET
            Console.WriteLine("2 - Cadastrar Série");   //POST
            Console.WriteLine("3 - Atualizar Série");   //PUT
            Console.WriteLine("4 - Deletar Série");    //DEL
            int.TryParse(Console.ReadLine().Trim(), out int valor);
            return valor;
        }

        public int MenuDocumentos()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Selecione a opção desejada:");
            Console.WriteLine("1 - Enviar");        //POST
            Console.WriteLine("2 - Consultar");     //GET
            Console.WriteLine("3 - Inutilizar");    //POST
            Console.WriteLine("4 - Descartar");     //POST
            Console.WriteLine("5 - Eventos");       //POST
            Console.WriteLine("6 - Exportar");      //POST //Console.WriteLine("7 - Exportar V2");   //POST
            //Console.WriteLine("7 - Importar");      //POST
            //Console.WriteLine("8 - Consultar Exportação");   //GET //Console.WriteLine("10 - Consultar Exportação V2");//GET
            int.TryParse(Console.ReadLine().Trim(), out int valor);
            return valor;
        }

        public int MenuTipoDocumentos()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Tipo de documento");
            Console.WriteLine("1 - NFe");
            Console.WriteLine("2 - NFCe");
            Console.WriteLine("3 - MDFe");
            Console.WriteLine("4 - NFSe");
            Console.WriteLine("5 - CTe");
            Console.WriteLine("6 - Sefaz");
            int.TryParse(Console.ReadLine().Trim(), out int valor);
            return valor;
        }

        public void TempoExpirado(string token)
        {
            Console.WriteLine(); 
            Console.WriteLine("**************************************************************");
            Console.WriteLine($"{token} EXPIRADO!");
            Console.WriteLine("**************************************************************");
        }

        public void Erro(string erro)
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine($"Erro: {erro}");
        }
    }
}
