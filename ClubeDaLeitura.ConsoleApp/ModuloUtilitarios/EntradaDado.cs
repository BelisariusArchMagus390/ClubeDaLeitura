using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloUtilitarios
{
    internal class EntradaDado
    {
        // mostra mensagem de erro padrão
        public void MostrarMensageDeErro(string mensagem)
        {
            Console.Clear();
            Console.WriteLine($"\n Erro! {mensagem}");
            Console.WriteLine(" Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        // verifica se o input é um inteiro
        public int VerificaValorInt(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string valor = Console.ReadLine();

                if (int.TryParse(valor, out int valorInt))
                {
                    return valorInt;
                }
                else
                    MostrarMensageDeErro(" Esse não é um valor inteiro.");
            }
        }
    }
}
