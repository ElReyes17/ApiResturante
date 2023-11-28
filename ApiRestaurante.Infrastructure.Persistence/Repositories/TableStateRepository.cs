

using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Domain.Entities;
using ApiRestaurante.Infrastructure.Persistence.Contexts;
using ApiRestaurante.Infrastructure.Persistence.Repositories.Generics;

namespace ApiRestaurante.Infrastructure.Persistence.Repositories
{
    public class TableStateRepository : GenericRepository<TableState>, ITableStateRepository
    {
        private readonly ApplicationContext _context;
        public TableStateRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

    }
}
