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
    public class EstadoView
    {
        public void imprimirMenu()
        {
            MetodosView.Limpar();
            Console.ForegroundColor = ConsoleColor.Blue; // Define a cor do texto
            Console.WriteLine("Bem-vindo ao Sistema Lsmetro Orçamentos");
            Console.WriteLine("Escolha uma das opções abaixo:");
            Console.WriteLine("1 - Listar Todos os Estados");
            Console.WriteLine("2 - Cadastrar Novo Estado");
            Console.WriteLine("3 - Listar Estados por País");
            Console.WriteLine("0 - Sair");
            Console.Write("Digite a Opção Desejada: ");
        }

        public void Menu()
        {
            int opcao = -1;
            do
            {
                imprimirMenu();

                try
                {
                    //****** LÉ DIGITADO USUARIO ******
                    opcao = Convert.ToInt32(Console.ReadLine());

                    //****** ESCOLHE MENU ******
                    EscolheMenu(opcao);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Define a cor do texto para vermelho
                    Console.WriteLine("Opção inválida, digite apenas números.");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Define a cor do texto para vermelho
                    Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
                }

                //****** TEMPO QUE VAI MOSTRAR MSG *******
                MetodosView.Limpar();

            } while (opcao != 0);
        }

        private void EscolheMenu(int opcao)
        {
            //****** ESCOLHE OPÇÃO NO MENU ******
            switch (opcao)
            {
                case 1:
                    ListarEstados();
                    break;
                case 2:
                    CadastrarMenu();
                    break;
                case 3:
                    ListarEstadosPorPais();
                    break;
                case 0:
                    Console.WriteLine("Saindo");
                    break;
                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
            //****** TEMPO QUE VAI MOSTRAR MSG *******
            MetodosView.Limpar();
        }

        private void ListarEstados()
        {
            //****** METODO LIMPAR & MOSTRAR CABECALHO ******
            MetodosView.Cabecalho("Lista de Estados");

            //****** CRIANDO OBJETO estadoRepository PARA USAR ******
            EstadoRepository estadoRepository = new EstadoRepository();

            //****** USANDO OBJETO estadoRepository ******
            //****** CRIANDO VARIAVEL PARA ARMAZENAR ******
            var estados = estadoRepository.ReadAll();

            //****** VERIFICA E TRAZ OS DADOS ******
            if (estados == null || estados.Count == 0)
            {
                Console.WriteLine("Nenhum Estado cadastrado ainda.");
            }
            else
            {
                //****** VAI EXIBE LISTA DE ESTADOS ****** 
                foreach (var estado in estados)
                {
                    Console.WriteLine($"{estado.Id} - {estado.Nome} ({estado.Sigla}), População: {estado.Populacao}, País ID: {estado.Pais.Id}");
                }
            }
        }

        private void ListarEstadosPorPais()
        {
            //****** METODO LIMPAR & MOSTRAR CABECALHO ******
            MetodosView.Cabecalho("Lista de Estados por País");

            //****** CRIANDO OBJETO paisRepository PARA USAR ******
            PaisRepository paisRepository = new PaisRepository();

            //****** USANDO OBJETO paisRepository ******
            //****** CRIANDO VARIAVEL PARA ARMAZENAR ******
            var paises = paisRepository.GetAll();

            //****** VERIFICA E TRAZ OS DADOS ******
            if (paises == null || paises.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red; // Define a cor do texto para vermelho
                Console.WriteLine("Nenhum país cadastrado. Cadastre um país antes de listar estados.");
                return;
            }

            //****** EXIBE LISTA DE PAIS ******
            Console.WriteLine("Selecione o país para listar os estados:");
            for (int i = 0; i < paises.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {paises[i].Nome}");
            }

            Console.Write("Digite o número do país: ");
            if (!int.TryParse(Console.ReadLine(), out int paisIndex) || paisIndex <= 0 || paisIndex > paises.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrada inválida. Operação cancelada.");
                return;
            }

            //****** VAI BUSCAR LISTA DadosBancarios ********
            var paisSelecionado = paises[paisIndex - 1];
            EstadoRepository estadoRepository = new EstadoRepository();

            //****** CRIADA VARIAVEL PARA ARMAZENAR A LISTA PARA PODE USAR ******
            var estados = estadoRepository.ReadByPais(paisSelecionado.Id);

            //****** VERIFICA E TRAZ OS DADOS ******
            if (estados == null || estados.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Nenhum estado cadastrado para o país {paisSelecionado.Nome}.");
            }
            else
            {
                // Exibe a lista de estados
                foreach (var estado in estados)
                {
                    Console.WriteLine($"{estado.Id} - {estado.Nome} ({estado.Sigla}), População: {estado.Populacao}, País ID: {estado.Pais.Id}");
                }
            }
        }

        private void CadastrarMenu()
        {
            //****** METODO LIMPAR & MOSTRAR CABECALHO ******
            MetodosView.Cabecalho("Cadastro de Estado");

            //****** CRIANDO OBJETO paisRepository PARA USAR ******
            PaisRepository paisRepository = new PaisRepository();

            //****** USANDO OBJETO paisRepository ******
            //****** CRIANDO VARIAVEL PARA ARMAZENAR ******
            var paises = paisRepository.GetAll();

            //****** VERIFICA E TRAZ OS DADOS ******
            if (paises == null || paises.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum país cadastrado. Cadastre um país antes de cadastrar um estado.");
                return;
            }

            //****** CRIANDO OBJETO estadoRepository PARA USAR ******
            EstadoRepository estadoRepository = new EstadoRepository();
            Estado estado = new Estado();

            //****** SOLICITANDO PARA DIGITAR ******
            Console.Write("Digite o Nome do Estado: ");
            estado.Nome = Console.ReadLine();

            //****** SOLICITANDO PARA DIGITAR ******
            Console.Write("Digite a Sigla do Estado: ");
            estado.Sigla = Console.ReadLine();

            //****** SOLICITANDO PARA DIGITAR ******
            Console.Write("Digite a População do Estado: ");
            if (!int.TryParse(Console.ReadLine(), out int populacao))
            {
                Console.ForegroundColor = ConsoleColor.Red; // Define a cor do texto para vermelho
                Console.WriteLine("População inválida. Operação cancelada.");
                return;
            }
            estado.Populacao = populacao;

            //****** EXIBE LISTA DE PAIS ******
            Console.WriteLine("Selecione o país para o estado:");
            for (int i = 0; i < paises.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {paises[i].Nome}");
            }

            //****** SOLICITANDO PARA DIGITAR ******
            Console.Write("Digite o número do país: ");
            if (!int.TryParse(Console.ReadLine(), out int paisIndex) || paisIndex < 1 || paisIndex > paises.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("País inválido. Operação cancelada.");
                return;
            }

            estado.Pais = paises[paisIndex - 1];

            //****** CRIANDO estado NO TXT ******
            Console.WriteLine(estadoRepository.Create(estado));
            Console.WriteLine("\n***** Obrigado por cadastrar *****\n");

            //****** IMPRIMINDO DADOS EM TXT ******
            Console.WriteLine($"{estado.Id} - {estado.Nome} ({estado.Sigla}), População: {estado.Populacao}, País ID: {estado.Pais.Id}");
        }

        internal void ExibirListaDeEstados(List<Estado> estados)
        {
            throw new NotImplementedException(); // Método ainda não implementado
        }
    }
}
