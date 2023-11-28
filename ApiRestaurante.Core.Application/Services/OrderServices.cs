
using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.Services.Generics;
using ApiRestaurante.Core.Application.ViewModels.Dishes;
using ApiRestaurante.Core.Application.ViewModels.Orders;
using ApiRestaurante.Core.Domain.Entities;
using AutoMapper;

namespace ApiRestaurante.Core.Application.Services
{
    public class OrderServices : GenericServices<SaveOrdersViewModel, OrdersViewModel, Orders>, IOrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderStateRepository _orderStateRepository;
        private readonly IDishOrderRepository _dishOrderRepository;
        private readonly IDishServices _dishServices;
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;
        public OrderServices(IOrderRepository orderRepository, IMapper mapper, 
            IDishOrderRepository dishOrderRepository, IDishServices dishServices, IOrderStateRepository orderStateRepository, IDishRepository dishRepository) 
            : base( orderRepository, mapper )
        {
            _orderRepository = orderRepository;
            _orderStateRepository = orderStateRepository;
            _mapper = mapper;          
            _dishServices = dishServices;
            _dishOrderRepository = dishOrderRepository;
            _dishServices = dishServices;
        }

        

        public override async Task<List<OrdersViewModel>> GetAll()
        {

            var list = await _orderRepository.GetAll();
           
            await _orderStateRepository.GetAll();
            await _dishServices.GetAll();

            List<OrdersViewModel> result = new List<OrdersViewModel>(); 

            foreach (var item in list ) { 
            
                OrdersViewModel vm = new OrdersViewModel();
                vm.Id = item.Id;
                vm.TableNumber = item.TableId;
                vm.SubTotal = item.SubTotal;
                vm.State = item.OrderState.NameState;

                var dishesList =  _dishOrderRepository.GetDishList(item.Id);

              

                vm.DishOrders = dishesList.Select(a => new DishOrdersViewModel { 
                
                    DishName = a.Name,
                    Price = a.Price,
                   
                }).ToList();


                result.Add(vm);
            
            }         


            return result;
        }

        public async Task<OrdersViewModel> ShowById(int id)
        {
            var get = await _orderRepository.GetById(id);

            await _orderStateRepository.GetAll();
            await _dishServices.GetAll();

            OrdersViewModel newobject = new OrdersViewModel()
            {

                Id = get.Id,
                TableNumber = get.TableId,
                SubTotal = get.SubTotal,
                State = get.OrderState.NameState,
                

            };
           
            var dishesList = _dishOrderRepository.GetDishList(get.Id);

          

            newobject.DishOrders = dishesList.Select(a => new DishOrdersViewModel
            {

                DishName = a.Name,
                Price = a.Price,

            }).ToList();


            return newobject;

        }

        public override async Task<SaveOrdersViewModel> Add(SaveOrdersViewModel vm)
        {

            var dishesList = _dishOrderRepository.GetDishList(vm.Id);


            double subtotal = 0;


       foreach (var dish in vm.DishOrdersId)
            {

                var d = await _dishServices.GetById(dish);
                subtotal += d.Price;

            }

            var add = new Orders
            {
                TableId = vm.TableId,
                StateId = 1,
                DishOrders = vm.DishOrdersId.Select(id => new DishOrders
                {
                    DishesId = id,

                }).ToList(),
                SubTotal = subtotal
               

            };

            await _orderRepository.Add(add);

         
            return vm;


        }

        public override async Task Update(SaveOrdersViewModel vm, int id)
        {
           
            var element = await _orderRepository.GetById(id);

            element.Id = id;
            element.TableId = vm.TableId;
            element.StateId = element.StateId;

            var dishes = _dishOrderRepository.GetDishList(id);

            foreach (var item in dishes)
            {
                await _dishRepository.Delete(item);
            }

            foreach(var dO in vm.DishOrdersId)
            {
                element.DishOrders.Add(new DishOrders
                {
                    DishesId = dO,
                    OrdersId = element.Id
                    
                });

            }

            await _orderRepository.Update(element, id);
           

        }

        public async Task<List<OrdersViewModel>> GetAllOrders(int tablesId)
        {
            var list =  _orderRepository.GetAllOrders(tablesId);
                   
            await _orderStateRepository.GetAll();
            await _dishServices.GetAll();

             List<OrdersViewModel> orders = new List<OrdersViewModel>();

            foreach (var item in list)
            {
                OrdersViewModel vm = new OrdersViewModel();

                vm.Id = item.Id;
                vm.State = item.OrderState.NameState;
                vm.TableNumber = item.TableId;
                vm.SubTotal = item.SubTotal;
                
                     
                var dishesList = _dishOrderRepository.GetDishList(vm.Id);


                vm.DishOrders = dishesList.Select(a => new DishOrdersViewModel
                {

                    DishName = a.Name,
                    Price = a.Price,

                }).ToList();


                orders.Add(vm);
            }
            
            return orders;
        }


    }
}
