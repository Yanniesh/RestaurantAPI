using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantAPI5.Entites;
using RestaurantAPI5.Exceptions;
using RestaurantAPI5.IServices;
using RestaurantAPI5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI5.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RestaurantService> _logger;

        public RestaurantService(RestaurantDbContext dbContext, IMapper mapper, ILogger<RestaurantService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<RestaurantDTO> GetAll()
        {
            var restaurants = _dbContext.restaurants
               .Include(r => r.Dishes)
               .Include(r => r.Address)
               .ToList();
            if (restaurants is null) return null;
            var restaurantsDTO = _mapper.Map<List<RestaurantDTO>>(restaurants);
            return restaurantsDTO;
        }
        public RestaurantDTO GetById(int id)
        {
            var restaurant = _dbContext.restaurants
               .Include(r => r.Dishes)
               .Include(r => r.Address)
               .ToList()
               .FirstOrDefault(r => r.Id == id);
            if (restaurant is null) 
                throw new NotFoundException("Restaurant not found");
            var restaurantDTO = _mapper.Map<RestaurantDTO>(restaurant);
            return restaurantDTO;
        }
        public int AddRestaurant(CreateRestaurantDto dto)
        {

            var restaurant = _mapper.Map<Restaurant>(dto);
            _dbContext.restaurants.Add(restaurant);
            _dbContext.SaveChanges();
            return restaurant.Id;
        }

        public void DeleteById(int id)
        {
            _logger.LogError($"Restaurant with id: {id}, DELETE action invoked.");
            var entity = _dbContext.restaurants.FirstOrDefault(r => r.Id == id);
            if (entity is null)
            {
                throw new NotFoundException("Restaurant not found");
            }
            _dbContext.restaurants.Remove(entity);
            _dbContext.SaveChanges();
        }
        public void ModifyRestaurantById(int id, ModifyRestaurantDto dto)
        {
            var restaurant = _dbContext.restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant is null)
            {
                throw new NotFoundException("Restaurant not found");
            }
            restaurant.Name = dto.Name;
            restaurant.Description = dto.Description;
            restaurant.HasDelivery = dto.HasDelivery;
            _dbContext.SaveChanges();
        }
    }
}
