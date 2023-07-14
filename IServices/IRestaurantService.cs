using Microsoft.AspNetCore.Mvc;
using RestaurantAPI5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI5.IServices
{
    public interface IRestaurantService
    {
        public IEnumerable<RestaurantDTO> GetAll();
        public RestaurantDTO GetById(int id);
        public int AddRestaurant(CreateRestaurantDto dto);
        public void DeleteById(int id);
        public void ModifyRestaurantById(int id, ModifyRestaurantDto dto);
    }
}
