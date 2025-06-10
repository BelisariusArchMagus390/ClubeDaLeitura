using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloModelo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.ModuloUtilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class TelaEmprestimo : TelaModelo
    {
        private RepositorioEmprestimo Repositorio;
        private RepositorioAmigo RepositorioAmigo;
        private RepositorioRevista RepositorioRevista;
        static EntradaDado Entrada = new EntradaDado();

        public TelaEmprestimo(
            RepositorioEmprestimo repositorio, 
            RepositorioAmigo repositorioAmigo, 
            RepositorioRevista repositorioRevista
        ) : base("Emprestimo", repositorio)
        {
            Repositorio = repositorio;
            RepositorioAmigo = repositorioAmigo;
            RepositorioRevista = repositorioRevista;
        }

        public override char MostrarMenu()
        {
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine($"\n GESTÃO DE {NomeEntidade.ToUpper()}");
            Console.WriteLine("\n --------------------------------------------");

            Console.WriteLine($"\n 1 - Registrar novo {NomeEntidade}");
            Console.WriteLine($" 2 - Mostrar {NomeEntidade}s");
            Console.WriteLine($" 3 - Devolução de {NomeEntidade}s");
            Console.WriteLine(" 4 - Sair");

            Console.Write("\n Escolha uma das opções acima: ");
            char opcao = Console.ReadLine()[0];

            return opcao;
        }

        public override void Registrar()
        {
            Emprestimo emprestimoNovoRegistro = (Emprestimo)PegarDados();

            string erros = emprestimoNovoRegistro.ValidarDados();

            if (erros.Length > 0)
            {
                Console.Clear();

                Console.WriteLine(erros);

                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();

                Registrar();
                return;
            }

            foreach (Emprestimo e in Repositorio.PegarRegistros())
            {
                if (e.Amigo.Id == emprestimoNovoRegistro.Amigo.Id)
                {
                    Entrada.MostrarMensageDeErro(" Esse amigo já tem um empréstimo ativo (máx. de 1 por pessoa).");

                    Registrar();
                    return;
                }
            }

            Repositorio.AdicionarRegistro(emprestimoNovoRegistro);

            Console.Clear();
            Console.WriteLine("\n Emprestimo registrado com sucesso!");
            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public void DevolverEmprestimo()
        {
            Emprestimo emprestimo;

            while (true)
            {
                Console.Clear();

                MostrarEmprestimosAtivos();

                int idEmprestimo = Entrada.VerificaValorInt("\n Digite o ID do emprestimo que deseja concluir: ");
                emprestimo = (Emprestimo)Repositorio.SelecionarRegistroPorId(idEmprestimo);

                if (emprestimo == null)
                    Console.WriteLine($"\n Erro! Não foi encontrado o ID do emprestimo desejado.");
                else
                {
                    Console.WriteLine($"\n Emprestimo selecionado com sucesso!");
                    break;
                }
            }

            Console.Write("\n Deseja confirmar a conclusão do empréstimo? (S/N)");
            string opcao = Console.ReadLine();

            if (opcao.ToUpper() == "S")
            {
                emprestimo.AtualizarRegistro(emprestimo);

                Console.Clear();
                Console.WriteLine($"\n Emprestimo concluído com sucesso!");
                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();
            }
        }

        protected override EntidadeModelo PegarDados()
        {
            Amigo amigo;
            Revista revista;

            while (true)
            {
                Console.Clear();

                MostrarAmigos();

                int idAmigo = Entrada.VerificaValorInt("\n Digite o ID do amigo que deseja: ");
                amigo = (Amigo)RepositorioAmigo.SelecionarRegistroPorId(idAmigo);

                if (amigo == null)
                    Console.WriteLine($"\n Erro! Não foi encontrado o ID do amigo desejado.");
                else
                {
                    Console.WriteLine($"\n Amigo selecionado com sucesso!");
                    break;
                }
            }

            while (true)
            {
                Console.Clear();

                MostrarRevistasDisponiveis();

                int idRevista = Entrada.VerificaValorInt("\n Digite o ID da revista que deseja: ");
                revista = (Revista)RepositorioRevista.SelecionarRegistroPorId(idRevista);

                if (amigo == null)
                    Console.WriteLine($"\n Erro! Não foi encontrado o ID da revista desejado.");
                else
                {
                    Console.WriteLine($"\n Revista selecionado com sucesso!");
                    break;
                }
            }

            Emprestimo emprestimo = new Emprestimo(amigo, revista);

            return emprestimo;
        }

        public override void MostrarRegistros(bool mostrarParaSelecao = false)
        {
            Console.WriteLine(
                " {0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} | {5, -15} ",
            " Id", "Amigo", "Revista", "Data do Empréstimo", "Data de Devolução", "Status"
            );

            foreach (Emprestimo e in Repositorio.PegarRegistros())
            {
                if (e == null)
                    continue;

                if (e.Status == "Atrasado")
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine(
                    " {0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} | {5, -15} ",
                    " " + e.Id, e.Amigo.Nome, e.Revista.Titulo, e.DataEmprestimo.ToShortDateString(), e.DataDevolucao.ToShortDateString(), e.Status
                );

                Console.ResetColor();
            }
        }

        public void MostrarEmprestimosAtivos()
        {
            List<Emprestimo> emprestimosAtivos = Repositorio.SelecionarEmprestimosAtivos();

            Console.WriteLine(
                " {0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} | {5, -15} ",
            " Id", "Amigo", "Revista", "Data do Empréstimo", "Data de Devolução", "Status"
            );

            foreach (Emprestimo e in emprestimosAtivos)
            {
                if (e == null)
                    continue;

                Console.WriteLine(
                    " {0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} | {5, -15} ",
                    " " + e.Id, e.Amigo.Nome, e.Revista.Titulo, e.DataEmprestimo.ToShortDateString(), e.DataDevolucao.ToShortDateString(), e.Status
                );
            }
        }

        public void MostrarAmigos()
        {
            Console.WriteLine(
                " {0, -10} | {1, -30} | {2, -30} | {3, -20} ",
            " Id", "Nome", "Responsável", "Telefone"
            );

            foreach (Amigo a in Repositorio.PegarRegistros())
            {
                if (a == null)
                    continue;

                Console.WriteLine(
                    " {0, -10} | {1, -20} | {2, -10} | {3, -10} ",
                    " " + a.Id, a.Nome, a.Responsavel, a.Telefone
                );
            }
        }

        public void MostrarRevistasDisponiveis()
        {
            List<Revista> revistasDisponiveis = RepositorioRevista.SelecionarRevistasDisponiveis();

            Console.WriteLine(
                " {0, -10} | {1, -30} | {2, -20} | {3, -20} | {4, -20} | {5, -20} ",
            " Id", "Título", "Edição", "Ano de Publicação", "Caixa", "Status"
            );

            foreach (Revista r in revistasDisponiveis)
            {
                if (r == null)
                    continue;

                Console.WriteLine(
                    " {0, -10} | {1, -30} | {2, -20} | {3, -20} | {4, -20} | {5, -20} ",
                    " " + r.Id, r.Titulo, r.NumeroEdicao, r.AnoPublicacao, r.Caixa.Etiqueta, r.Status
                );
            }
        }
    }
}
