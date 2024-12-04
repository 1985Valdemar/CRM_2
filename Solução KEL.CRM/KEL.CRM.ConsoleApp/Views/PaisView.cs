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

        public void ImprimirMenu()
        {
            Console.Clear(); // Limpa a tela antes de imprimir o menu
            Console.WriteLine("\nLista de Clientes Cadastrados:");

            //****** VAI BUSCAR LISTA ******
            PaisRepository paisRepository = new PaisRepository();

            //****** CRIANDO VARIAVEL PARA ARMAZENAR GetAll ******
            var paises = paisRepository.GetAll();

            //****** VERIFICAÇÃO DA LISTA E TRAZENDO Clientes ******
            if (paises.Count > 0)
            {
                foreach (var paise in paises)
                {
                    Console.WriteLine($"Id: {paise.Id}, Nome: {paise.Nome}, População: {paise.Populacao}, Idioma: {paise.Idioma}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum País cadastrado ainda.");
            }

            Console.WriteLine("\nCadastro Cliente\n");

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

    }
}
