using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Utilitarios
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

        // verifica se o input é um decimal
        public decimal VerificaValorDecimal(string mensagem)
        {
            while (true)
            {
                Console.Clear();
                Console.Write(mensagem);
                string valor = Console.ReadLine();

                if (decimal.TryParse(valor, out decimal valorDecimal))
                {
                    return valorDecimal;
                }
                else
                    MostrarMensageDeErro(" Esse não é um valor numérico.");
            }
        }

        // verifica se o input é um DateTime
        public DateTime verificaDateTime(string mensagem)
        {
            while (true)
            {
                Console.Clear();
                Console.Write(mensagem);
                string valor = Console.ReadLine();

                if (DateTime.TryParse(valor, out DateTime valorDateTime))
                {
                    return valorDateTime;
                }
                else
                    MostrarMensageDeErro(" Esse não é um valor de data.");
            }
        }

        // verifica se o input é um inteiro
        public int VerificaValorInt(string mensagem)
        {
            while (true)
            {
                Console.Clear();
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
