using ClubeDaLeitura.ConsoleApp.Modelo;
using ClubeDaLeitura.ConsoleApp.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClubeDaLeitura.ConsoleApp.Amigo
{
    public class TelaAmigo : TelaModelo
    {
        static EntradaDado Entrada = new EntradaDado();

        public TelaAmigo(RepositorioAmigo repositorio) : base("Amigo", repositorio) { }

        public override void Registrar()
        {
            Amigo amigoNovoRegistro = (Amigo)PegarDados();

            string erros = amigoNovoRegistro.ValidarDados();

            if (erros.Length > 0)
            {
                Console.Clear();

                Console.WriteLine(erros);

                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();

                Registrar();
                return;
            }

            foreach (Amigo a in Repositorio.PegarRegistros())
            {
                if (amigoNovoRegistro.Nome == a.Nome || amigoNovoRegistro.Telefone == a.Telefone)
                {
                    Entrada.MostrarMensageDeErro(" Um amigo com este nome ou telefone já foi cadastrado.");

                    Registrar();
                    return;
                }
            }

            Repositorio.AdicionarRegistro(amigoNovoRegistro);

            Console.Clear();
            Console.WriteLine("\n Amigo registrado com sucesso!");
            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public override void Editar()
        {
            MostrarRegistros(true);

            int id = Entrada.VerificaValorInt("\n Entre com o ID do registro que deseja: ");

            Amigo amigoAtualizado = (Amigo)PegarDados();

            string erros = amigoAtualizado.ValidarDados();

            if (erros.Length > 0)
            {
                Console.Clear();

                Console.WriteLine(erros);

                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();

                Editar();
                return;
            }

            foreach (Amigo a in Repositorio.PegarRegistros())
            {
                if (amigoAtualizado.Nome == a.Nome || amigoAtualizado.Telefone == a.Telefone)
                {
                    Entrada.MostrarMensageDeErro(" Um amigo com este nome ou telefone já foi cadastrado.");

                    Editar();
                    return;
                }
            }

            Console.Clear();

            if (Repositorio.EditarRegistro(id, amigoAtualizado))
            {
                Console.WriteLine("\n Amigo atualizado com sucesso!");
                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();
            }
            else
            {
                Entrada.MostrarMensageDeErro(" Não foi encontrado o ID desejado.");
                Editar();
                return;
            }
        }

        public override void MostrarRegistros(bool mostrarParaSelecao = false)
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

            if (mostrarParaSelecao == false)
            {
                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();
            }
        }

        protected override EntidadeModelo PegarDados()
        {
            Console.Clear();
            Console.Write("\n Digite o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.Clear();
            Console.Write("\n Digite o nome do responsável do amigo: ");
            string responsavel = Console.ReadLine();

            Console.Clear();
            Console.Write("\n Digite o telefone do amigo ou do responsável: ");
            string telefone = Console.ReadLine();

            Amigo amigo = new Amigo(nome, responsavel, telefone);

            return amigo;
        }
    }
}
