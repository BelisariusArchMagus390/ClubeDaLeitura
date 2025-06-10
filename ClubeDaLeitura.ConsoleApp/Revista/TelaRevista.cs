using ClubeDaLeitura.ConsoleApp.Caixa;
using ClubeDaLeitura.ConsoleApp.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Revista
{
    public class TelaRevista : TelaModelo
    {
        private RepositorioCaixa RepositorioCaixa;

        public TelaRevista(RepositorioRevista repositorio, RepositorioCaixa repositorioCaixa) : base("Revista", repositorio)
        {
            this.RepositorioCaixa = repositorioCaixa;
        }

        public override void MostrarRegistros(bool mostrarParaSelecao = false)
        {
            Console.WriteLine(
                " {0, -10} | {1, -30} | {2, -20} | {3, -20} | {4, -20} | {5, -20} ",
            " Id", "Título", "Edição", "Ano de Publicação", "Caixa", "Status"
            );

            foreach (Revista r in Repositorio.PegarRegistros())
            {
                if (r == null)
                    continue;

                Console.WriteLine(
                    " {0, -10} | {1, -30} | {2, -20} | {3, -20} | {4, -20} | {5, -20} ",
                    " " + r.Id, r.Titulo, r.NumeroEdicao, r.AnoPublicacao, r.Caixa.Etiqueta, r.Status
                );
            }

            if (mostrarParaSelecao == false)
            {
                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();
            }
        }

        public void VisualizarCaixa(bool mostrarParaSelecao = false)
        {
            Console.WriteLine(
                " {0, -10} | {1, -30} | {2, -30} | {3, -30} ",
            " Id", "Etiqueta", "Cor", "Dias de Empréstimo"
            );

            foreach (Caixa c in RepositorioCaixa.PegarRegistros())
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

        }
    }
}
