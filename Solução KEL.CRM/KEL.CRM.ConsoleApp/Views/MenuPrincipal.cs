using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEL.CRM.ConsoleApp.Views
{
    public class MenuPrincipal
    {
        public void MenuEscolha()
        {
            int opcao = 0;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Bem-vindo ao Sistema Lsmetro Orçamentos");
                Console.WriteLine("Escolha uma das opções abaixo:");
                Console.WriteLine("1 - Menu Países");
                Console.WriteLine("2 - Menu Estados");
                Console.WriteLine("0 - Sair");
                Console.Write("Digite a opção desejada: ");

                //****** VAI CONVERTER STRING EM INT ******
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Thread.Sleep(2000);
                    continue;
                }

                EscolheMenu(opcao);

            } while (opcao != 0);
        }
        private void EscolheMenu(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    PaisView paisView = new PaisView();
                    paisView.Menu();
                    break;
                case 2:
                    EstadoView estadoView = new EstadoView();
                    estadoView.Menu();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
}
