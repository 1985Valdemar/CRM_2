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
                Console.WriteLine("1 - Dados Bancarios");
                Console.WriteLine("2 - Endereço");
                Console.WriteLine("3 - Cidade");
                Console.WriteLine("4 - Estado");
                Console.WriteLine("5 - Pais");
                Console.WriteLine("6 - Cliente");
                Console.WriteLine("7 - Produto");
                Console.WriteLine("8 - Estoque");
                Console.WriteLine("9 - Pedido");
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
                
                case 6:
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
