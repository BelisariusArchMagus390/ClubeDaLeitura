using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Modelo
{
    public abstract class EntidadeModelo
    {
        public int Id;

        public abstract void AtualizaRegistro(EntidadeModelo registro);
        public abstract string Validar();
    }
}
