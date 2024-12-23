﻿using KEL.CRM.ConsoleApp.Models;
using KEL.CRM.ConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEL.CRM.ConsoleApp.Views
{
    public class ClienteView
    {
        public void ImprimirMenu()
        {
            Console.Clear(); // Limpa a tela antes de imprimir o menu
            Console.WriteLine("\nLista de Clientes Cadastrados:");

            //****** VAI BUSCAR LISTA ******
            ClienteRepository clienteRepository = new ClienteRepository();

            //****** CRIANDO VARIAVEL PARA ARMAZENAR GetAll ******
            var clientes = clienteRepository.GetAll();

            //****** VERIFICAÇÃO DA LISTA E TRAZENDO Clientes ******
            if (clientes.Count > 0)
            {
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, Sobrenome: {cliente.Sobrenome}, CPF: {cliente.Cpf}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum cliente cadastrado ainda.");
            }

            Console.WriteLine("\nCadastro Cliente\n");

            Cliente cliente1 = new Cliente();

            //****** SOLICITANDO PARA DIGITAR ******
            Console.Write("Digite Seu Nome: ");
            cliente1.Nome = Console.ReadLine();

            //****** SOLICITANDO PARA DIGITAR ******
            Console.Write("Digite Seu Sobrenome: ");
            cliente1.Sobrenome = Console.ReadLine();

            //****** SOLICITANDO PARA DIGITAR ******
            Console.Write("Digite Seu CPF: ");
            cliente1.Cpf = Console.ReadLine();

            //****** CRIANDO cliente1 NO TXT ******
            Console.WriteLine(clienteRepository.Create(cliente1));

            Console.WriteLine("\n***** Obrigado Por Cadastrar *****\n");

            //****** IMPRIMINDO DADOS EM TXT ******
            Console.WriteLine(cliente1);
        }

    }
}
