using Projeto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Classes
{
    class AnimalRepositorio : IRepositorio<Animal>
    {
        private List<Animal> listaAnimais = new List<Animal>();
        public void Atualiza(int id, Animal entidade)
        {
            listaAnimais[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaAnimais[id].Excluir();
        }

        public void Insere(Animal entidade)
        {
            listaAnimais.Add(entidade);
        }

        public List<Animal> Lista()
        {
            return listaAnimais;
        }

        public int ProximoId()
        {
            return listaAnimais.Count;
        }

        public Animal RetornaPorId(int id)
        {
            return listaAnimais[id];
        }
    }
}
