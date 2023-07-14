using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RestaurantAPI5.Entites;
using RestaurantAPI5.Models;


namespace RestaurantAPI5
{
    public class RestauranMappingProfile : Profile
    {
        public RestauranMappingProfile()
        {
            CreateMap<Restaurant, RestaurantDTO>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street));
            CreateMap<Dish, DishDTO>();
            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(r => r.Address, c => c.MapFrom(dto => new Address() 
                {City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street}));

        }
    }
}
