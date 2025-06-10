using ClubeDaLeitura.ConsoleApp.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Emprestimo
{
    public class Emprestimo : EntidadeModelo
    {
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public string Status { get; set; }

        public Emprestimo(Amigo amigo, Revista revista)
        {
            Amigo = amigo;
            Revista = revista;
            DataEmprestimo = DateTime.Now;
            DataDevolucao = DataEmprestimo.AddDays(Revista.Caixa.DiasEmprestimo);
            Status = "Aberto";
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
            Status = "Concluído";
        }
    }
}
