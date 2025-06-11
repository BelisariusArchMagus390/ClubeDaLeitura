using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloModelo;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaPrincipal telaPrincipal = new TelaPrincipal();

            while (true)
            {
                Console.Clear();

                telaPrincipal.MostrarMenuGeral();

                TelaModelo telaEscolhida = telaPrincipal.SelecionarTela();

                if (telaEscolhida == null)
                    break;

                Console.Clear();

                char opcao = telaEscolhida.MostrarMenu();
                opcao = Char.ToUpper(opcao);

                if (opcao == 'S')
                    break;

                Console.Clear();

                if (telaEscolhida is TelaEmprestimo)
                {
                    TelaEmprestimo telaEmprestimo = (TelaEmprestimo)telaEscolhida;

                    Console.Clear();

                    switch (opcao)
                    {
                        case '1':
                            telaEmprestimo.Registrar();
                            break;

                        case '2':
                            telaEmprestimo.MostrarRegistros();
                            break;

                        case '3':
                            telaEmprestimo.DevolverEmprestimo();
                            break;
                    }
                }
                else
                {
                    switch (opcao)
                    {
                        case '1':
                            telaEscolhida.Registrar();
                            break;

                        case '2':
                            telaEscolhida.MostrarRegistros();
                            break;

                        case '3':
                            telaEscolhida.Editar();
                            break;

                        case '4':
                            telaEscolhida.Remover();
                            break;
                    }
                }
            }
        }
    }
}