using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
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

        public TelaPrincipal()
        {
            RepositorioAmigo = new RepositorioAmigo();
            RepositorioCaixa = new RepositorioCaixa();
            RepositorioRevista = new RepositorioRevista();
            RepositorioEmprestimo = new RepositorioEmprestimo();

            TelaAmigo = new TelaAmigo(RepositorioAmigo);
            TelaCaixa = new TelaCaixa(RepositorioCaixa);
            TelaRevista = new TelaRevista(RepositorioRevista, RepositorioCaixa);
            TelaEmprestimo = new TelaEmprestimo(RepositorioEmprestimo, RepositorioAmigo, RepositorioRevista);

            Amigo amigo = new Amigo("Júnior", "Amanda", "49 99999-3333");
            RepositorioAmigo.AdicionarRegistro(amigo);

            Caixa caixa = new Caixa("Ação", "Vermelha", 1);
            RepositorioCaixa.AdicionarRegistro(caixa);

            Revista revista = new Revista("Superman", 150, 1995, caixa);
            RepositorioRevista.AdicionarRegistro(revista);

            Emprestimo emprestimo = new Emprestimo(amigo, revista);
            emprestimo.DataEmprestimo = DateTime.Now.AddDays(-2);
            RepositorioEmprestimo.AdicionarRegistro(emprestimo);
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
            Console.WriteLine(" 5 - Sair");
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
            }
            return null;
        }
    }
}
