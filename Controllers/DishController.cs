using Microsoft.AspNetCore.Mvc;
using RestaurantAPI5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI5.Controllers
{
    [Route("{restaurantId/dish}")]
    [ApiController]
    public class DishController : ControllerBase
    {
        public DishController()
        {
        }
        public ActionResult Post([FromRoute]int restaurantId, CreateDishDto dto)
        {
            
            return Ok();
        }
    }
}
