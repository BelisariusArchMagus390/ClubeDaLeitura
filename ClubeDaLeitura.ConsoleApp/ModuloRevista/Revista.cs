﻿using ClubeDaLeitura.ConsoleApp.ModuloModelo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class Revista : EntidadeModelo
    {
        public string Titulo { get; set; }
        public int NumeroEdicao { get; set; }
        public int AnoPublicacao { get; set; }
        public Caixa Caixa { get; set; }
        public string Status { get; set; }

        public Revista(string titulo, int numeroEdicao, int anoPublicao, Caixa caixa)
        {
            this.Titulo = titulo;
            this.NumeroEdicao = numeroEdicao;
            this.AnoPublicacao = anoPublicao;
            this.Caixa = caixa;
            this.Status = "Disponivel";
        }

        public override string ValidarDados()
        {
            string erros = "";

            if (Titulo.Length < 2 || Titulo.Length > 100)
                erros += "\n O campo título deve ter no mínimo 2 e no máximo 100 caracteres.";

            if (NumeroEdicao < 1)
                erros += "\n O campo número de edição deve ter um valor maior que 0.";

            if (AnoPublicacao < DateTime.MinValue.Year || AnoPublicacao > DateTime.Now.Year)
                erros += "\n O campo ano de publicação precisa conter uma data válida.";

            if (Caixa == null)
                erros += "\n O campo caixa é obrigatório.";

            return erros;
        }

        public override void AtualizarRegistro(EntidadeModelo registro)
        {
            Revista revistaAtualizado = (Revista)registro;

            this.Titulo = revistaAtualizado.Titulo;
            this.NumeroEdicao = revistaAtualizado.NumeroEdicao;
            this.AnoPublicacao = revistaAtualizado.AnoPublicacao;
            this.Caixa = revistaAtualizado.Caixa;
        }
    }
}
