using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Dtos;
using WebApi.Models.Users;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Manager, ManagerModel>();
            CreateMap<RegisterModel, Manager>();
            CreateMap<UpdateModel, Manager>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<OrderInputDto, Order>();
            CreateMap<Order, OrderInputDto>();
            CreateMap<VacationPackage, VacationPackageDto>();
            CreateMap<VacationPackageDto, VacationPackage>();
        }
    }
}