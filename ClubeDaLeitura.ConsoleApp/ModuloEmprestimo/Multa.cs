using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class Multa
    {
        public decimal Valor { get; set; }
        public DateTime DataOcorrencia { get; set; }

        public Multa(decimal valor)
        {
            this.Valor = valor;
            this.DataOcorrencia = DateTime.Now;
        }
    }
}
