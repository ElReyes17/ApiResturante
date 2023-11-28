

using ApiRestaurante.Core.Application.Dtos;
using ApiRestaurante.Core.Application.Interfaces.Services.Generics;
using ApiRestaurante.Core.Application.ViewModels.Orders;
using ApiRestaurante.Core.Application.ViewModels.Tables;
using ApiRestaurante.Core.Domain.Entities;

namespace ApiRestaurante.Core.Application.Interfaces.Services
{
    public interface ITableServices : IGenericServices<SaveTablesViewModel, TablesViewModel, Tables>
    {
        Task<TablesViewModel> ShowById(int id);
        Task ChangeStatus(ChangeStatusRequest vm);
        Task<string> ValidateTablesId(int id);
    }
}
