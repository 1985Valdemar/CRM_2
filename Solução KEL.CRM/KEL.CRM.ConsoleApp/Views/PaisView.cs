using KEL.CRM.ConsoleApp.Common;
using KEL.CRM.ConsoleApp.Models;
using KEL.CRM.ConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEL.CRM.ConsoleApp.Views
{
    public class PaisView
    {
        private void CadastrarMenu()
        {
            //****** METODO LIMPAR & MOSTRAR CABECALHO ******
            MetodosView.Cabecalho("Bem vindo Cadastro");

            //****** VAI BUSCAR LISTA ******
            PaisRepository paisRepository = new PaisRepository();

            Pais pais = new Pais();

            //****** SOLICITANDO PARA DIGITAR ******
            Console.Write("Digite Nome País: ");
            pais.Nome = Console.ReadLine();

            //****** SOLICITANDO PARA DIGITAR ******
            Console.Write("Digite População: ");
            pais.Populacao = Convert.ToInt32(Console.ReadLine());

            //****** SOLICITANDO PARA DIGITAR ******
            Console.Write("Digite Seu Idioma: ");
            pais.Idioma = Console.ReadLine();

            //****** CRIANDO cliente1 NO TXT ******
            Console.WriteLine(paisRepository.Create(pais));

            Console.WriteLine("\n***** Obrigado Por Cadastrar *****\n");

            //****** IMPRIMINDO DADOS EM TXT ******
            Console.WriteLine(pais);
        }
        public void Menu()
        {

            int opcao = -1;
            do
            {
                //****** VAI IMPRIMIR OPÇÕES ******
                imprimiMenu();

                //****** TRATANDO POSSIVEIS ERROS ******
                try
                {
                    //****** LÉ DIGITADO USUARIO ******
                    opcao = Convert.ToInt32(Console.ReadLine());

                    EscolheMenu(opcao);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Digite Apenas Numeros");
                }
                //****** TEMPO QUE VAI MOSTRAR MSG *******
                MetodosView.Limpar();

            } while (opcao != 0);
        }
        public void imprimiMenu()
        {
            MetodosView.Limpar();
            //****** INSERINDO COR ******
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Bem ao Sistema Lsmetro Orçamentos");
            Console.WriteLine("Escolha Uma das Opçãos Abaixo:");
            Console.WriteLine("1 - Listar");
            Console.WriteLine("2 - Cadastrar");
            Console.WriteLine("0 - Sair");
            Console.Write("Digite a Opção Desejada: ");
        }
        private void EscolheMenu(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    ListarPaises();
                    break;
                case 2:
                    CadastrarMenu();
                    break;
                case 0:
                    Console.WriteLine("Saindo");
                    break;

                default:
                    Console.WriteLine("Opçao Invalida");
                    break;

            }
            MetodosView.Limpar();

        }

        private void ListarPaises()
        {
            //****** METODO LIMPAR & MOSTRAR CABECALHO ******
            MetodosView.Cabecalho("Lista Paises");

            //****** VAI BUSCAR LISTA ******
            PaisRepository paisRepository = new PaisRepository();

            //****** CRIANDO VARIAVEL PARA ARMAZENAR GetAll ******
            var paises = paisRepository.GetAll();

            //****** VERIFICAÇÃO DA LISTA E TRAZENDO PAISES ******
            if (paises.Count > 0)
            {
                foreach (var pais in paises)
                {
                    Console.WriteLine(pais);
                }
            }
            else
            {
                Console.WriteLine("Nenhum País cadastrado ainda.");
            }
        }


    }
}
