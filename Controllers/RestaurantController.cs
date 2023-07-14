using Microsoft.AspNetCore.Mvc;
using RestaurantAPI5.Entites;
using RestaurantAPI5.Exceptions;
using RestaurantAPI5.IServices;
using RestaurantAPI5.Models;
using System.Collections.Generic;

namespace RestaurantAPI5.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _service;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _service =  restaurantService;   
        }
        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDTO>> GetRestaurants()
        {
            var restaurants = _service.GetAll();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public ActionResult<Restaurant> GetRestaurant([FromRoute] int id)
        {
            var restaurant = _service.GetById(id);
            return Ok(restaurant);
        }
        [HttpPost]
        public ActionResult AddRestaurant([FromBody]CreateRestaurantDto dto)
        {            
            int result = _service.AddRestaurant(dto);
            return Created($"/restaurant/{result}", null);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteRestaurant([FromRoute] int id)
        {
             _service.DeleteById(id); 
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult ModifyRestaurant([FromRoute]int id, [FromBody]ModifyRestaurantDto dto)
        {
            _service.ModifyRestaurantById(id, dto);
            return Ok();
        }
    }
}