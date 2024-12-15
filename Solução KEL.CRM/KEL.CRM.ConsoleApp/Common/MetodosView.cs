﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEL.CRM.ConsoleApp.Common
{
    public static class MetodosView
    {

        //****** METODO LIMPAR & MOSTRAR CABECALHO ******
        public static void Cabecalho(string titulo)
        {
            Console.Clear(); // Limpa a tela antes de imprimir o cabeçalho
            Console.WriteLine($" {titulo}"); // Exibe o cabeçalho
        }

        public static void Limpar() 
        {
            //****** TEMPO QUE VAI MOSTRAR MSG *******
            Thread.Sleep(2000);
            Console.Clear(); // Limpa a tela após exibir a opção escolhida
        }

    }
}
