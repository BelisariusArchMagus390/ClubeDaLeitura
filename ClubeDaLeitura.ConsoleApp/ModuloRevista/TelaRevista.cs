using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloModelo;
using ClubeDaLeitura.ConsoleApp.ModuloUtilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class TelaRevista : TelaModelo
    {
        private RepositorioCaixa RepositorioCaixa;
        static EntradaDado Entrada = new EntradaDado();
        private static int IdContador = 0;

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

        public void VisualizarCaixa()
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
        }

        protected override EntidadeModelo PegarDados()
        {
            Console.Clear();
            Console.Write("\n Digite o título da revista: ");
            string titulo = Console.ReadLine();

            int numeroEdicao = Entrada.VerificaValorInt("\n Digite o número de edição da revista: ");

            int anoPublicacao = Entrada.VerificaValorInt("\n Digite o ano de publicação da revista: ");

            VisualizarCaixa();

            int idCaixa = Entrada.VerificaValorInt("\n Digite o ID do caixa que deseja: ");

            Caixa caixa = (Caixa)RepositorioCaixa.SelecionarRegistroPorId(idCaixa);

            Revista revista = new Revista(titulo, numeroEdicao, anoPublicacao, caixa);
            revista.Id = IdContador;
            IdContador++;

            return caixa;
        }
    }
}
