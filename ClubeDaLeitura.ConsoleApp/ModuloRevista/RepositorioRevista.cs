using ClubeDaLeitura.ConsoleApp.ModuloModelo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class RepositorioRevista : RepositorioModelo
    {
        public List<Revista> SelecionarRevistasDisponiveis()
        {
            List<Revista> revistasDisponiveis = new List<Revista>();

            List<EntidadeModelo> registros = PegarRegistros();

            foreach (EntidadeModelo rd in registros)
            {
                Revista revista = (Revista)rd;

                if (revista.Status == "Disponivel")
                    revistasDisponiveis.Add(revista);
            }

            return revistasDisponiveis;
        }
    }
}
