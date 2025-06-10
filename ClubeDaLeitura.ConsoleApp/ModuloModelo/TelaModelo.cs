using ClubeDaLeitura.ConsoleApp.ModuloUtilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClubeDaLeitura.ConsoleApp.ModuloModelo
{
    public abstract class TelaModelo
    {
        protected string NomeEntidade;
        protected RepositorioModelo Repositorio;
        static EntradaDado Entrada = new EntradaDado();

        protected TelaModelo(string nomeEntidade, RepositorioModelo repositorio)
        {
            this.NomeEntidade = nomeEntidade;
            this.Repositorio = repositorio;
        }

        public virtual char MostrarMenu()
        {
            Console.WriteLine(" --------------------------------------------");
            Console.WriteLine($"\n GESTÃO DE {NomeEntidade.ToUpper()}");
            Console.WriteLine("\n --------------------------------------------");

            Console.WriteLine($"\n 1 - Registrar novo {NomeEntidade}");
            Console.WriteLine($" 2 - Mostrar {NomeEntidade}s");
            Console.WriteLine($" 3 - Atualizar registro de {NomeEntidade}");
            Console.WriteLine($" 4 - Excluir registro de {NomeEntidade}");
            Console.WriteLine(" 5 - Sair");

            Console.Write("\n Escolha uma das opções acima: ");
            char opcao = Console.ReadLine()[0];

            return opcao;
        }

        public virtual void Registrar()
        {
            EntidadeModelo novoRegistro = PegarDados();

            string erros = novoRegistro.ValidarDados();

            if (erros.Length > 0)
            {
                Console.Clear();

                Console.WriteLine(erros);

                Console.WriteLine("\n Aperte ENTER para continuar...");
                Console.ReadLine();

                Registrar();
                return;
            }

            Repositorio.AdicionarRegistro(novoRegistro);

            Console.Clear();
            Console.WriteLine($"\n {NomeEntidade} registrado com sucesso!");
            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public virtual void Editar()
        {
            MostrarRegistros(true);

            int id = Entrada.VerificaValorInt("\n Entre com o ID do registro que deseja: ");

            EntidadeModelo registroAtualizado = PegarDados();

            Console.Clear();

            if(Repositorio.EditarRegistro(id, registroAtualizado))
                Console.WriteLine($"\n {NomeEntidade} atualizado com sucesso!");
            else
                Console.WriteLine($"\n Erro! Não foi encontrado o ID desejado.");

            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public void Remover()
        {
            MostrarRegistros(true);

            int id = Entrada.VerificaValorInt("\n Entre com o ID do registro que deseja: ");

            Console.Clear();

            if (Repositorio.RemoverRegistro(id))
                Console.WriteLine($"\n {NomeEntidade} removido com sucesso!");
            else
                Console.WriteLine($"\n Erro! Não foi encontrado o ID desejado.");

            Console.WriteLine("\n Aperte ENTER para continuar...");
            Console.ReadLine();
        }

        public abstract void MostrarRegistros(bool mostrarParaSelecao = false);

        protected abstract EntidadeModelo PegarDados();
    }
}
