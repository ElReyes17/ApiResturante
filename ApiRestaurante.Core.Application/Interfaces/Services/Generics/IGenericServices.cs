

namespace ApiRestaurante.Core.Application.Interfaces.Services.Generics
{
    public interface IGenericServices<SaveViewModel, ViewModel, Model>
        where SaveViewModel : class
        where ViewModel : class
        where Model : class
    {
        Task<List<ViewModel>> GetAll();

        Task<SaveViewModel> GetById(int id);

        Task<SaveViewModel> Add(SaveViewModel vm);

        Task Update(SaveViewModel vm, int id);
 
        Task Delete(int id);

       

       
    }
}
