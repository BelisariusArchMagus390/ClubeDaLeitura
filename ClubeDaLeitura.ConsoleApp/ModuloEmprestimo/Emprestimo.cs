﻿using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloModelo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimo : EntidadeModelo
    {
        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao 
        {
            get
            {
                return DataEmprestimo.AddDays(Revista.Caixa.DiasEmprestimo);
            }
        }
        public string Status { get; set; }
        public Multa Multa 
        {
            get
            {
                if (DateTime.Now <= DataDevolucao)
                    return null;

                TimeSpan diferencaDatas = DateTime.Now.Subtract(DataDevolucao);

                decimal valorMulta = 2.00m * diferencaDatas.Days;

                Multa multa = new Multa(valorMulta);

                return multa;
                
            }
        }
        public bool MultaPaga = false;

        public Emprestimo(Amigo amigo, Revista revista)
        {
            this.Amigo = amigo;
            this.Revista = revista;
            this.DataEmprestimo = DateTime.Now;
            this.Status = "Aberto";
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
            this.Status = "Concluído";
            this.Revista.Status = "Disponível";
        }
    }
}
