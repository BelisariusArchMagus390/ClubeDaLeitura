using ClubeDaLeitura.ConsoleApp.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Caixa
{
    public class Caixa : EntidadeModelo
    {
        public string Etiqueta { get; set; }
        public string Cor { get; set; }
        public int DiasEmprestimo { get; set; }

        public Caixa(string etiqueta, string cor)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = 7;
        }

        public Caixa(string etiqueta, string cor, int diasEmprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasEmprestimo;
        }

        public override string ValidarDados()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Etiqueta) || Etiqueta.Length > 50)
                erros += "\n O campo etiqueta deve ser texto único e no máximo 50 caracteres.";

            if (string.IsNullOrWhiteSpace(Cor))
                erros += "\n O campo cor é obrigatório.";

            if (DiasEmprestimo < 1)
                erros += "\n O campo de dias de empréstimo deve ser maior que 0.";

            return erros;
        }

        public override void AtualizarRegistro(EntidadeModelo registro)
        {
            Caixa caixaAtualizado = (Caixa)registro;

            this.Etiqueta = caixaAtualizado.Etiqueta;
            this.Cor = caixaAtualizado.Cor;
            this.DiasEmprestimo = caixaAtualizado.DiasEmprestimo;
        }
    }
}
