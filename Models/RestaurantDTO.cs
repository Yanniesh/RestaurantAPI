﻿using RestaurantAPI5.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI5.Models
{
    public class RestaurantDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool HasDelivery { get; set; }
        
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public List<DishDTO> Dishes { get; set; }
    }
}
