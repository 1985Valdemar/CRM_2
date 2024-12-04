using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEL.CRM.ConsoleApp.Views
{
    public class MenuPrincipal
    {

        public void ImprimirMenu()
        {
            int opcao = 0;
            do
            {
                Console.WriteLine("Bem ao Sistema Lsmetro Orçamentos");
                Console.WriteLine("Escolha Uma das Opçãos Abaixo:");
                Console.WriteLine("1 - Pais");
                Console.WriteLine("2 - Cliente");
                Console.WriteLine("0 - Sair");
                Console.Write("Digite a Opção Desejada: ");
                opcao = Convert.ToInt32(Console.ReadLine());

                EscolheMenu(opcao);

            } while (opcao != 0);
        }
        public void EscolheMenu(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    PaisView paisView = new PaisView();
                    paisView.ImprimirMenu();
                    break;

                case 2:
                    ClienteView clienteView = new ClienteView();
                    clienteView.ImprimirMenu();
                    break;
                
                case 0:
                    Console.WriteLine("Saindo");
                    break;

                default:
                    Console.WriteLine("Opçao Invalida");
                    break;

            }
            Thread.Sleep(2000);
            Console.Clear();
        }

    }
}
