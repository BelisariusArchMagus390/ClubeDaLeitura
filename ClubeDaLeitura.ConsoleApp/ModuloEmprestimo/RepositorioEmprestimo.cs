using ClubeDaLeitura.ConsoleApp.ModuloModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class RepositorioEmprestimo : RepositorioModelo
    {
        public List<Emprestimo> SelecionarEmprestimosAtivos()
        {
            List<Emprestimo> emprestimosAtivos = new List<Emprestimo>();

            List<EntidadeModelo> registros = PegarRegistros();

            foreach (EntidadeModelo rd in registros)
            {
                Emprestimo emprestimo = (Emprestimo)rd;

                if (emprestimo.Status == "Aberto" || emprestimo.Status == "Atrasado")
                    emprestimosAtivos.Add(emprestimo);
            }

            return emprestimosAtivos;
        }

        public List<Emprestimo> SelecionarEmprestimosComMulta()
        {
            List<Emprestimo> emprestimosComMulta = new List<Emprestimo>();

            List<EntidadeModelo> registros = PegarRegistros();

            foreach (EntidadeModelo rd in registros)
            {
                Emprestimo emprestimo = (Emprestimo)rd;

                if (emprestimo.Status == "Aberto" && emprestimo.Multa != null && !emprestimo.MultaPaga)
                    emprestimosComMulta.Add(emprestimo);
            }

            return emprestimosComMulta;
        }
    }
}
