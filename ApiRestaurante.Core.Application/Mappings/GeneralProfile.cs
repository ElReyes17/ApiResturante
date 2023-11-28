

using ApiRestaurante.Core.Application.ViewModels.Dishes;
using ApiRestaurante.Core.Application.ViewModels.Ingredients;
using ApiRestaurante.Core.Application.ViewModels.Orders;
using ApiRestaurante.Core.Application.ViewModels.Tables;
using ApiRestaurante.Core.Domain.Entities;
using AutoMapper;
using ApiRestaurante.Core.Application.Dtos.Account;
using ApiRestaurante.Core.Application.ViewModels.User;
using System.Net;

namespace ApiRestaurante.Core.Application.Mappings
{
   public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DishesProfile
           
            CreateMap<Dishes, DishesViewModel>()
         .ReverseMap()
         .ForMember(x => x.DishCategory, opt => opt.Ignore())
         .ForMember(x => x.DishIngredients, opt => opt.Ignore())
         .ForMember(x => x.DishCategoryId, opt => opt.Ignore());


            CreateMap<Dishes, SaveDishesViewModel>()
           .ReverseMap()
           .ForMember(x => x.DishCategory, opt => opt.Ignore())
           .ForMember(x => x.DishIngredients, opt => opt.Ignore());

            #endregion

            #region OrdersProfile
            CreateMap<Orders, OrdersViewModel>()
         .ReverseMap()
         .ForMember(x => x.Tables, opt => opt.Ignore())
         .ForMember(x => x.OrderState, opt => opt.Ignore())
         .ForMember(x => x.DishOrders, opt => opt.Ignore())
         .ForMember(x => x.StateId, opt => opt.Ignore())
         .ForMember(x => x.TableId, opt => opt.Ignore());


            CreateMap<Orders, SaveOrdersViewModel>()
           .ReverseMap()
           .ForMember(x => x.Tables, opt => opt.Ignore())
           .ForMember(x => x.OrderState, opt => opt.Ignore())
           .ForMember(x => x.DishOrders, opt => opt.Ignore());

            #endregion

            #region TablesProfile

            CreateMap<Tables, TablesViewModel>()
       .ReverseMap()
       .ForMember(x => x.StateId, opt => opt.Ignore())
       .ForMember(x => x.TableState, opt => opt.Ignore());



            CreateMap<Tables, SaveTablesViewModel>()
           .ReverseMap()
           .ForMember(x => x.TableState, opt => opt.Ignore());
         
            #endregion

            #region IngredientsProfile
            CreateMap<Ingredients, IngredientsViewModel>()
          .ReverseMap()
          .ForMember(x => x.DishIngredients, opt => opt.Ignore());



            CreateMap<Ingredients, SaveIngredientsViewModel>()
           .ReverseMap()
           .ForMember(x => x.DishIngredients, opt => opt.Ignore());

            #endregion

            #region UserProfile
            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgotPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();
            #endregion
        }


    }
}
