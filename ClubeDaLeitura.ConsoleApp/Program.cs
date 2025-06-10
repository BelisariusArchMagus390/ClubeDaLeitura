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
                telaPrincipal.MostrarMenuGeral();

                TelaModelo telaEscolhida = telaPrincipal.SelecionarTela();

                if (telaEscolhida == null)
                    break;

                char opcao = telaEscolhida.MostrarMenu();

                if (opcao == '5')
                    break;

                if (telaEscolhida is TelaEmprestimo)
                {
                    TelaEmprestimo telaEmprestimo = (TelaEmprestimo)telaEscolhida;

                    switch (opcao)
                    {
                        case '1':
                            telaEmprestimo.Registrar();
                            break;

                        case '2':
                            telaEmprestimo.DevolverEmprestimo();
                            break;

                        case '3':
                            telaEmprestimo.MostrarRegistros();
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