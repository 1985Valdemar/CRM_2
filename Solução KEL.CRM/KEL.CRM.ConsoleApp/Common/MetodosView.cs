using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEL.CRM.ConsoleApp.Common
{
<<<<<<< HEAD
    public class MetodosView
    {
        public static void Mensagem(string texto) 
        {
            Console.WriteLine(texto);
            Thread.Sleep(2000);
        }
=======
    public static class MetodosView
    {
>>>>>>> 46336e4f27a453c1d01c97414a6ecb39816b771e

        //****** METODO LIMPAR & MOSTRAR CABECALHO ******
        public static void Cabecalho(string titulo)
        {
            Console.Clear(); // Limpa a tela antes de imprimir o cabeçalho
            Console.WriteLine($" {titulo}"); // Exibe o cabeçalho
        }

<<<<<<< HEAD
        //****** METODO LIMPAR ******
        public static void Limpar()
=======
        public static void Limpar() 
>>>>>>> 46336e4f27a453c1d01c97414a6ecb39816b771e
        {
            //****** TEMPO QUE VAI MOSTRAR MSG *******
            Thread.Sleep(2000);
            Console.Clear(); // Limpa a tela após exibir a opção escolhida
        }
<<<<<<< HEAD
=======

>>>>>>> 46336e4f27a453c1d01c97414a6ecb39816b771e
    }
}
