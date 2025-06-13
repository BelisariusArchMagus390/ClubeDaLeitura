using ClubeDaLeitura.ConsoleApp.ModuloReservas;
using ClubeDaLeitura.ConsoleApp.ModuloModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloReservas
{
    public class RepositorioReservas : RepositorioModelo
    {
        public List<Reservas> SelecionarReservasAtivas()
        {
            List<Reservas> reservasAtivas = new List<Reservas>();

            List<EntidadeModelo> registros = PegarRegistros();

            foreach (EntidadeModelo rd in registros)
            {
                Reservas reservas = (Reservas)rd;

                if (reservas.Status == "Ativa")
                    reservasAtivas.Add(reservas);
            }

            return reservasAtivas;
        }
    }
}
