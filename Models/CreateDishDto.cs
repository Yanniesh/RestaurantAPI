﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI5.Models
{
    public class CreateDishDto
    {
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Descritpion { get; set; }
        public int restaurantId { get; set; }  
    }
}
