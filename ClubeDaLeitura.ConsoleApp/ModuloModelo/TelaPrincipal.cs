using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloReservas;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloModelo
{
    public class TelaPrincipal
    {
        private char Opcao;

        private RepositorioAmigo RepositorioAmigo;
        private TelaAmigo TelaAmigo;

        private RepositorioCaixa RepositorioCaixa;
        private TelaCaixa TelaCaixa;

        private RepositorioRevista RepositorioRevista;
        private TelaRevista TelaRevista;

        private RepositorioEmprestimo RepositorioEmprestimo;
        private TelaEmprestimo TelaEmprestimo;

        private RepositorioReservas RepositorioReservas;
        private TelaReservas TelaReservas;

        public TelaPrincipal()
        {
            RepositorioAmigo = new RepositorioAmigo();
            RepositorioCaixa = new RepositorioCaixa();
            RepositorioRevista = new RepositorioRevista();
            RepositorioEmprestimo = new RepositorioEmprestimo();
            RepositorioReservas = new RepositorioReservas();

            TelaAmigo = new TelaAmigo(RepositorioAmigo, RepositorioEmprestimo);
            TelaCaixa = new TelaCaixa(RepositorioCaixa);
            TelaRevista = new TelaRevista(RepositorioRevista, RepositorioCaixa);
            TelaEmprestimo = new TelaEmprestimo(RepositorioEmprestimo, RepositorioAmigo, RepositorioRevista, RepositorioReservas);
            TelaReservas = new TelaReservas(RepositorioReservas, RepositorioAmigo, RepositorioRevista, RepositorioEmprestimo);
        }

        public void MostrarMenuGeral()
        {
            Console.WriteLine("  --------------------------------------");
            Console.WriteLine(" |                                      |");
            Console.WriteLine(" |           CLUBE DA LEITURA           |");
            Console.WriteLine(" |                                      |");
            Console.WriteLine("  --------------------------------------");

            Console.WriteLine("\n 1 - Gestão de Amigos");
            Console.WriteLine(" 2 - Gestão de Caixas");
            Console.WriteLine(" 3 - Gestão de Revistas");
            Console.WriteLine(" 4 - Gestão de Empréstimos");
            Console.WriteLine(" 5 - Gestão de Reservas");
            Console.WriteLine(" S - Sair");
            Console.Write("\n Escolha uma das opções acima: ");

            Opcao = Console.ReadLine()[0];
        }

        public TelaModelo SelecionarTela()
        {
            switch (Opcao)
            {
                case '1':
                    return TelaAmigo;
                case '2':
                    return TelaCaixa;
                case '3':
                    return TelaRevista;
                case '4':
                    return TelaEmprestimo;
                case '5':
                    return TelaReservas;
            }
            return null;
        }
    }
}
