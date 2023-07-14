using Microsoft.EntityFrameworkCore;
using RestaurantAPI5.Entites;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI5
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext dbContext;

        public RestaurantSeeder(RestaurantDbContext _dbContext)
        {
            dbContext = _dbContext; 
        }

        public void seed()
        {
            if (dbContext.Database.CanConnect())
            {
                if (!dbContext.restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    dbContext.restaurants.AddRange(restaurants);
                    dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "Bieda strasza",
                    ContactMail = "bieda@example.com",
                    ContactNumber = "509509509",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "kupa",
                            Price = 9.99M
                        },
                        new Dish()
                        {
                            Name = "Kupnczyk",
                            Price = 9.99M
                        }
                    },
                    Address = new Address()
                    {
                        City = "Matka",
                        PostalCode = "89-900",
                        Street = "shebelongs"
                    }
                },
                new Restaurant()
                {
                    Name = "KFC2",
                    Category = "Fast Food",
                    Description = "Bieda strasza",
                    ContactMail = "bieda@example.com",
                    ContactNumber = "509509509",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "kupa",
                            Price = 9.99M
                        },
                        new Dish()
                        {
                            Name = "Kupnczyk",
                            Price = 9.99M
                        }
                    },
                    Address = new Address()
                    {
                        City = "Matka2",
                        PostalCode = "89-900",
                        Street = "shebelongs"
                    }
                }
            };
            return restaurants;
        }
    }
}
