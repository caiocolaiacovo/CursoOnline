using System.Collections.Generic;
using System.Linq;
using CursoOnline.Dominio.Base;
using CursoOnline.Dominio.Dados.Contextos;

namespace CursoOnline.Dominio.Dados.Repositorios
{
    public class RepositorioBase<T> : IRepositorio<T> where T : Entidade
    {
        protected readonly ApplicationDbContext Contexto;

        public RepositorioBase (ApplicationDbContext contexto)
        {
            Contexto = contexto;
        }

        public void Adicionar(T entidade)
        {
            Contexto.Set<T>().Add(entidade);
        }

        public virtual T ObterPorId(int id)
        {
            var query = Contexto.Set<T>().Where(e => e.Id.Equals(id));
            return query.Any() ? query.First() : null;
        }

        public virtual List<T> Consultar()
        {
            var entidades = Contexto.Set<T>().ToList();
            return entidades.Any() ? entidades : new List<T>();
        }
    }
}