using AutoMapper;
using PP.DAL.Models;
using PP.WebApi.ViewModels;

namespace PP.WebApi
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeView>();
            CreateMap<Employee, Employee>();
            CreateMap<EmployeeInsert, Employee>();
            CreateMap<EmployeeUpdate, Employee>();
            CreateMap<Order, OrderView>();
            CreateMap<Order, Order>();
            CreateMap<OrderInsert, Order>();
            CreateMap<OrderUpdate, Order>();
            CreateMap<UserInsert, User>();
        }
    }
}
