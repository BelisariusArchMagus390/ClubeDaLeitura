using ClubeDaLeitura.ConsoleApp.Modelo;
using ClubeDaLeitura.ConsoleApp.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Caixa
{
    public class TelaCaixa : TelaModelo
    {
        static EntradaDado Entrada = new EntradaDado();

        public TelaCaixa(RepositorioCaixa repositorio) : base("Caixa", repositorio) { }

        public override void MostrarRegistros(bool mostrarParaSelecao = false)
        {
            Console.WriteLine(
                " {0, -10} | {1, -30} | {2, -30} | {3, -30} ",
            " Id", "Etiqueta", "Cor", "Dias de Empréstimo"
            );

            foreach (Caixa c in Repositorio.PegarRegistros())
            {
                if (c == null)
                    continue;

                Console.WriteLine(
                    " {0, -10} | {1, -30} | {2, -30} | {3, -30} ",
                    " " + c.Id, c.Etiqueta, c.Cor, c.DiasEmprestimo
                );
            }

            if (mostrarParaSelecao == false)
            {
                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();
            }
        }

        protected override EntidadeModelo PegarDados()
        {
            Console.Clear();
            Console.Write("\n Digite a etiqueta da caixa (máx. 50 caracteres): ");
            string etiqueta = Console.ReadLine();

            Console.Clear();
            Console.Write("\n Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            int diasEmprestimo = Entrada.VerificaValorInt("\n Digite a quantidade de dias de empréstimo (opcional): ");

            Caixa caixa = new Caixa(etiqueta, cor, diasEmprestimo);

            return caixa;
        }
    }
}
