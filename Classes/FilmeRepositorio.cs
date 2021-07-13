using System;
using System.Collections.Generic;
using Cadastro_Series.Interfaces;

namespace Cadastro_Series
{
    public class FilmeRepositorio : iRepositorio<Filme>
    {
      private List<Filme> listaFilme = new List<Filme>();
        public void Atualizar(int id, Filme objeto)
        {
            listaFilme[id] = objeto;
        }

        public void Excluir(int id)
        {
            // listaSerie.RemoveAt(id); cria inconssistencia na array

            listaFilme[id].Excluir();
        }

        public void Insere(Filme objeto)
        {
            listaFilme.Add(objeto);
        }

        public List<Filme> Lista()
        {
            return listaFilme;
        }

        public int ProximoId()
        {
            return listaFilme.Count;
        }

        public Filme RetornaPorId(int id)
        {
            return listaFilme[id];
        }
    }
}