using System.Threading.Tasks;
using ConsoleUI.Controller;

namespace ConsoleUI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IntegracaoController controller = new IntegracaoController();
            await controller.RunAsync();
        }
    }
}
