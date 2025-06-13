using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloModelo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.ModuloUtilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloReservas
{
    public class TelaReservas : TelaModelo
    {
        private RepositorioReservas Repositorio;
        private RepositorioAmigo RepositorioAmigo;
        private RepositorioRevista RepositorioRevista;
        private RepositorioEmprestimo RepositorioEmprestimo;
        static EntradaDado Entrada = new EntradaDado();
        private static int IdContador = 0;

        public TelaReservas(
            RepositorioReservas repositorio,
            RepositorioAmigo repositorioAmigo,
            RepositorioRevista repositorioRevista,
            RepositorioEmprestimo repositorioEmprestimo
        ) : base("Reserva", repositorio)
        {
            this.Repositorio = repositorio;
            this.RepositorioAmigo = repositorioAmigo;
            this.RepositorioRevista = repositorioRevista;
            this.RepositorioEmprestimo = repositorioEmprestimo;
        }

        public override char MostrarMenu()
        {
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine($"\n GESTÃO DE {NomeEntidade.ToUpper()}");
            Console.WriteLine("\n --------------------------------------------");

            Console.WriteLine($"\n 1 - Registrar nova {NomeEntidade}");
            Console.WriteLine($" 2 - Mostrar {NomeEntidade}s");
            Console.WriteLine($" 3 - Cancelar {NomeEntidade}");
            Console.WriteLine(" 4 - Voltar");

            Console.Write("\n Escolha uma das opções acima: ");
            char opcao = Console.ReadLine()[0];

            return opcao;
        }

        public override void Registrar()
        {
            Reservas reservaNovoRegistro = (Reservas)PegarDados();

            string erros = reservaNovoRegistro.ValidarDados();

            if (erros.Length > 0)
            {
                Console.Clear();

                Console.WriteLine(erros);

                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();

                Registrar();
                return;
            }

            foreach (Emprestimo e in RepositorioEmprestimo.PegarRegistros())
            {
                if (reservaNovoRegistro.Amigo.Id == e.Amigo.Id && e.Multa != null && !e.MultaPaga)
                {
                    Entrada.MostrarMensageDeErro(" Esse amigo tem uma multa em aberto.");

                    Registrar();
                    return;
                }
            }

            Repositorio.AdicionarRegistro(reservaNovoRegistro);

            Console.Clear();
            Console.WriteLine($"\n {NomeEntidade} registrada com sucesso!");
            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public void CancelarReserva()
        {
            Reservas reserva;

            while (true)
            {
                Console.Clear();

                MostrarReservasAtivas();

                int idReserva = Entrada.VerificaValorInt("\n Digite o ID da reserva que deseja concluir: ");
                reserva = (Reservas)Repositorio.SelecionarRegistroPorId(idReserva);

                if (reserva == null)
                    Console.WriteLine($"\n Erro! Não foi encontrado o ID da reserva desejada.");
                else
                {
                    Console.WriteLine($"\n Reserva selecionado com sucesso!");
                    break;
                }
            }

            Console.Write("\n Deseja confirmar a conclusão da reserva (S/N)? ");
            string opcao = Console.ReadLine();

            if (opcao.ToUpper() == "S")
            {
                reserva.AtualizarRegistro(reserva);

                Console.Clear();
                Console.WriteLine($"\n Reserva concluído com sucesso!");
                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();
            }
        }

        public override void MostrarRegistros(bool mostrarParaSelecao = false)
        {
            Console.WriteLine(
                " {0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} ",
            " Id", "Amigo", "Revista", "Data da Reserva", "Status"
            );

            foreach (Reservas r in Repositorio.PegarRegistros())
            {
                if (r == null)
                    continue;

                Console.WriteLine(
                    " {0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} ",
                    " " + r.Id, r.Amigo.Nome, r.Revista.Titulo, r.DataReserva.ToShortDateString(), r.Status
                );
            }

            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
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

            revista.Status = "Reservada";

            Reservas reserva = new Reservas(amigo, revista);
            reserva.Id = IdContador;
            IdContador++;

            return reserva;
        }

        public void MostrarAmigos()
        {
            Console.WriteLine(
                " {0, -10} | {1, -30} | {2, -30} | {3, -20} ",
            " Id", "Nome", "Responsável", "Telefone"
            );

            foreach (Amigo a in RepositorioAmigo.PegarRegistros())
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

        public void MostrarReservasAtivas()
        {
            List<Reservas> reservasAtivas = Repositorio.SelecionarReservasAtivas();

            Console.WriteLine(
                " {0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} ",
            " Id", "Amigo", "Revista", "Data da Reserva", "Status"
            );

            foreach (Reservas r in reservasAtivas)
            {
                if (r == null)
                    continue;

                Console.WriteLine(
                    " {0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} ",
                    " " + r.Id, r.Amigo.Nome, r.Revista.Titulo, r.DataReserva.ToShortDateString(), r.Status
                );
            }
        }
    }
}
