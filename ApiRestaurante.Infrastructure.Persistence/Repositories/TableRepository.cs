
using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Domain.Entities;
using ApiRestaurante.Infrastructure.Persistence.Contexts;
using ApiRestaurante.Infrastructure.Persistence.Repositories.Generics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiRestaurante.Infrastructure.Persistence.Repositories
{
   public class TableRepository : GenericRepository<Tables>, ITableRepository
    {
        private readonly ApplicationContext _context;
        public TableRepository(ApplicationContext context) : base(context) 
        {
            _context = context;
        }

        

    }
}
