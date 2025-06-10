using ClubeDaLeitura.ConsoleApp.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Amigo
{
    public class Amigo : EntidadeModelo
    {
        public string Nome;
        public string Responsavel;
        public string Telefone;

        public override string ValidarDados()
        {
            throw new NotImplementedException();
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
