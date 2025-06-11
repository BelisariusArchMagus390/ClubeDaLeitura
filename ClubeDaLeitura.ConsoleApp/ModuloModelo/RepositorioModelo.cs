using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloModelo
{
    public abstract class RepositorioModelo
    {
        private List<EntidadeModelo> Registros = new List<EntidadeModelo>();

        public void AdicionarRegistro(EntidadeModelo novoRegistro)
        {
            Registros.Add(novoRegistro);
        }

        public bool EditarRegistro(int id, EntidadeModelo registroAtualizado) 
        {
            EntidadeModelo registro = SelecionarRegistroPorId(id);

            if (registro == null)
                return false;

            registro.AtualizarRegistro(registroAtualizado);

            return true;
        }

        public bool RemoverRegistro(int id) 
        {
            EntidadeModelo registro = SelecionarRegistroPorId(id);

            if (registro != null)
            {
                int indice = Registros.IndexOf(registro);
                Registros.RemoveAt(indice);
                return true;
            }
            return false;
        }

        public List<EntidadeModelo> PegarRegistros() 
        {
            return Registros;
        }

        public EntidadeModelo SelecionarRegistroPorId(int id) 
        {
            foreach (EntidadeModelo m in Registros)
            {
                if (m.Id == id)
                    return m;
            }
            return null;
        }
    }
}
