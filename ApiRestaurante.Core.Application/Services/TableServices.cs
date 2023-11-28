using ApiRestaurante.Core.Application.Dtos;
using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.Services.Generics;
using ApiRestaurante.Core.Application.ViewModels.Tables;
using ApiRestaurante.Core.Domain.Entities;
using AutoMapper;
using System.Linq.Expressions;

namespace ApiRestaurante.Core.Application.Services
{
    public class TableServices : GenericServices<SaveTablesViewModel, TablesViewModel, Tables>, ITableServices
    {
        private readonly ITableRepository _tableRepository;
        private readonly ITableStateRepository _tableStateRepository;
        private readonly IMapper _mapper;
        public TableServices(ITableRepository tableRepository, IMapper mapper, ITableStateRepository tableStateRepository) : base(tableRepository, mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
            _tableStateRepository = tableStateRepository;

        }

        public override async Task<List<TablesViewModel>> GetAll()
        {

           var list = await _tableRepository.GetAll();
            await _tableStateRepository.GetAll();

            var result = list.Select(a => new TablesViewModel
            {
                Id = a.Id,
                PeopleAmount = a.PeopleAmount,
                Description = a.Description,
                State = a.TableState.NameState


            }).ToList();
            


            return result;
        }

        public async Task<TablesViewModel> ShowById(int id)
        {
            var get = await _tableRepository.GetById(id);
            await _tableStateRepository.GetAll();

            TablesViewModel vm = new TablesViewModel {
         
            Id = get.Id,
            PeopleAmount = get.PeopleAmount,
            Description = get.Description,
            State = get.TableState.NameState,
        };

            return vm;
        }

        public async Task ChangeStatus(ChangeStatusRequest vm)
        {
            var get = await _tableRepository.GetById(vm.Id);

            get.Id = get.Id;
            get.PeopleAmount = get.PeopleAmount;
            get.Description = get.Description;
            get.StateId = vm.StatusId;

            await _tableRepository.Update(get, get.Id);

        }

        public override async Task<SaveTablesViewModel> Add(SaveTablesViewModel vm)
        {
            var add = new Tables
            {
                Id = vm.Id,
                PeopleAmount = vm.PeopleAmount,
                Description = vm.Description,
                StateId = 1

            };

            await _tableRepository.Add(add);
                    
            return vm;

        }

        public override async Task Update(SaveTablesViewModel vm, int id)
        {
            var get = await _tableRepository.GetById(id);

            get.Id = get.Id;
            get.PeopleAmount = vm.PeopleAmount;
            get.Description = vm.Description;
            get.StateId = get.StateId;
                       
            await _tableRepository.Update(get, id);

        }

        public async Task<string> ValidateTablesId (int id)
        {
            var validation = await _tableRepository.GetById(id);

            if (validation == null)
            {
                return $"El Id {id} de la Mesa no existe";
            }

            return null!;
        }
    }
}
