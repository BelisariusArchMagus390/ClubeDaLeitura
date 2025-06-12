using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloModelo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloReservas
{
    public class Reservas : EntidadeModelo
    {
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public DateTime DataReserva { get; set; }
        public string Status { get; set; }

        public Reservas(Amigo amigo, Revista revista)
        {
            this.Amigo = amigo;
            this.Revista = revista;
            this.DataReserva = DateTime.Now;
            this.Status = "Ativa";
        }

        public override string ValidarDados()
        {
            string erros = "";

            if (Amigo == null)
                erros += "\n O campo amigo é obrigatório.";

            if (Revista == null)
                erros += "\n O campo revista é obrigatório.";

            return erros;
        }

        public override void AtualizarRegistro(EntidadeModelo registro)
        {
            Status = "Concluída";
        }
    }
}
