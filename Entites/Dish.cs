using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI5.Entites
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Descritpion { get; set; } 
        public int RestaurantId { get; set; }   
        public virtual Restaurant Restaurant { get; set; }

    }
}
