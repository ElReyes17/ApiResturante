
using ApiRestaurante.Core.Application.Interfaces.Repositories.Generics;
using ApiRestaurante.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;


namespace ApiRestaurante.Infrastructure.Persistence.Repositories.Generics
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext _contexto;

        private readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationContext context)
        {
            _contexto = context;
            _dbSet = _contexto.Set<T>();
        }


        public virtual async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<List<T>> GetAllWithInclude(List<string> propierties)
        {
            var query = _dbSet.AsQueryable();
            foreach (string propiedad in propierties)
            {
                query.Include(propiedad);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {

            var busqueda = await _dbSet.FindAsync(id);
           
            return busqueda;
            
           
        }
        public virtual async Task<T> Add(T objeto)
        {
            await _dbSet.AddAsync(objeto);
            await _contexto.SaveChangesAsync();
            return objeto;
        }
        public virtual async Task Update(T objeto, int id)
        {
            var entry = await _dbSet.FindAsync(id);
            _dbSet.Entry(entry).CurrentValues.SetValues(objeto);
            await _contexto.SaveChangesAsync();
        }
        public virtual async Task Delete(T objeto)
        {

            _dbSet.Remove(objeto);
            await _contexto.SaveChangesAsync();

        }
    }
}
