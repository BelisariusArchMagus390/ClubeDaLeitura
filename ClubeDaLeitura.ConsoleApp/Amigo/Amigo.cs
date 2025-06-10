using ClubeDaLeitura.ConsoleApp.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Amigo
{
    public class Amigo : EntidadeModelo
    {
        public string Nome { get; set; }
        public string Responsavel { get; set; }
        public string Telefone { get; set; }

        public Amigo(string nome, string responsavel, string telefone)
        {
            this.Nome = nome;
            this.Responsavel = responsavel;
            this.Telefone = telefone;
        }

        public override string ValidarDados()
        {
            string erros = "";

            if (Nome.Length < 3 || Nome.Length > 100)
                erros += "\n O campo nome deve conter no mínimo 3 e no máximo 100 caracteres.";

            if (Responsavel.Length < 3 || Responsavel.Length > 100)
                erros += "\n O campo nome do responsável deve conter no mínimo 3 e no máximo 100 caracteres.";

            if (!Regex.IsMatch(Telefone, @"^\(?\d{2}\)?\s?(9\d{4}|\d{4})-?\d{4}$"))
            {
                erros += "\n O campo telefone deve seguir o seguinte padrão: (DDD) 90000-0000.";
            }

            return erros;
        }

        public override void AtualizarRegistro(EntidadeModelo registro)
        {
            Amigo amigoAtualizado = (Amigo)registro;

            this.Nome = amigoAtualizado.Nome;
            this.Responsavel = amigoAtualizado.Responsavel;
            this.Telefone = amigoAtualizado.Telefone;
        }
    }
}
