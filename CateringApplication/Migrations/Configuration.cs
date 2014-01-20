namespace CateringApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CateringApplication.Models;
    using System.Collections.Generic;
    using System.Drawing.Imaging;
    using System.Drawing;
    using CateringApplication.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<CateringApplication.DAL.CateringContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        

        protected override void Seed(CateringApplication.DAL.CateringContext context)
        {
            // MENU
            var menus = new List<Menu>
            {
                new Menu { 
                    Name = "Grill" 
                },
                new Menu { 
                    Name = "Pizza" 
                },
                new Menu { 
                    Name = "Pasta" 
                },
                new Menu { 
                    Name = "Salad" 
                }
            };
            menus.ForEach(s => context.Menus.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            // TOWN
            var towns = new List<Town>
            {
                new Town { 
                    Name = "Osijek" 
                },
                new Town { 
                    Name = "Split" 
                },
                new Town { 
                    Name = "Zagreb" 
                }
            };
            towns.ForEach(s => context.Towns.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            // RESTAURANT
            var restaurants = new List<Restaurant>
            {
                new Restaurant { 
                    Name = "Kod Joze",
                    Address = "Jozina 34",
                    PhoneNumber = "031-33-22-11",
                    TownID = towns.Single(s => s.Name == "Osijek").TownID,
                },
                new Restaurant { 
                    Name = "Pizza Cut",
                    Address = "Vukovarska 11",
                    PhoneNumber = "031-13-12-21",
                    TownID = towns.Single(s => s.Name == "Osijek").TownID,
                },
                new Restaurant { 
                    Name = "McDonalds",
                    Address = "Trg",
                    PhoneNumber = "031-445-961",
                    TownID = towns.Single(s => s.Name == "Osijek").TownID,
                },
                new Restaurant { 
                    Name = "Restoran Kod Duje",
                    Address = "Poljudska 17",
                    PhoneNumber = "035-1235611",
                    TownID = towns.Single(s => s.Name == "Split").TownID,
                },
                new Restaurant { 
                    Name = "Kebab Centar",
                    Address = "Strossmayerova 100",
                    PhoneNumber = "035-543735",
                    TownID = towns.Single(s => s.Name == "Split").TownID,
                },
                new Restaurant { 
                    Name = "Kineski Restoran Li-Mun",
                    Address = "Vlaska 4",
                    PhoneNumber = "01-3463461",
                    TownID = towns.Single(s => s.Name == "Zagreb").TownID,
                },
                new Restaurant { 
                    Name = "Mexican Restaurant Sanchez",
                    Address = "Franje Raèkog 25" ,
                    PhoneNumber = "01-13451467",
                    TownID = towns.Single(s => s.Name == "Zagreb").TownID,
                },
            };
            // Using this insted of AddOrUpdate (like above examples) because
            // we can have same restaurant name in different Towns ????
            //restaurants.ForEach(r => context.Restaurants.AddOrUpdate(p => p.Name, r));
            //context.SaveChanges();
            foreach (Restaurant r in restaurants)
            {
                var restaurantsInDB = context.Restaurants.Where(
                    s => s.Name == r.Name &&
                    s.TownID == r.TownID).SingleOrDefault();

                if (restaurantsInDB == null)
                {
                    context.Restaurants.Add(r);
                }
                // stopping same restaurant name in same town only if save changes here ????
                context.SaveChanges();
            }

            // FOOD
            var foods = new List<Food>
            {
                new Food { 
                    Name = "Vegetariana", 
                    Price = 25,
                    MenuID = menus.Single(m => m.Name == "Pizza").MenuID,
                    RestaurantID = restaurants.Single(r => r.Name == "Kod Joze").RestaurantID
                },
                new Food { 
                    Name = "Cheeseburger", 
                    Price = 25,
                    MenuID = menus.Single(m => m.Name == "Grill").MenuID,
                    RestaurantID = restaurants.Single(r => r.Name == "Kod Joze").RestaurantID
                },
                new Food { 
                    Name = "Vegetariana", 
                    Price = 30,
                    MenuID = menus.Single(m => m.Name == "Pizza").MenuID,
                    RestaurantID = restaurants.Single(r => r.Name == "Pizza Cut").RestaurantID
                },
                new Food { 
                    Name = "Margarita", 
                    Price = 35,
                    MenuID = menus.Single(m => m.Name == "Pizza").MenuID,
                    RestaurantID = restaurants.Single(r => r.Name == "Pizza Cut").RestaurantID
                },
                new Food { 
                    Name = "Hamburger", 
                    Price = 25,
                    MenuID = menus.Single(m => m.Name == "Grill").MenuID,
                    RestaurantID = restaurants.Single(r => r.Name == "McDonalds").RestaurantID
                },
                new Food { 
                    Name = "Cevapi", 
                    Price = 27,
                    MenuID = menus.Single(m => m.Name == "Grill").MenuID,
                    RestaurantID = restaurants.Single(r => r.Name == "McDonalds").RestaurantID
                },
                new Food { 
                    Name = "Pljeskavica", 
                    Price = 30,
                    MenuID = menus.Single(m => m.Name == "Grill").MenuID,
                    RestaurantID = restaurants.Single(r => r.Name == "Restoran Kod Duje").RestaurantID
                },
                new Food { 
                    Name = "Makaroni sa sirom", 
                    Price = 18,
                    MenuID = menus.Single(m => m.Name == "Pasta").MenuID,
                    RestaurantID = restaurants.Single(r => r.Name == "Restoran Kod Duje").RestaurantID
                },
                new Food { 
                    Name = "Kebab", 
                    Price = 12,
                    MenuID = menus.Single(m => m.Name == "Grill").MenuID,
                    RestaurantID = restaurants.Single(r => r.Name == "Kebab Centar").RestaurantID
                },
                new Food { 
                    Name = "Sopska salata", 
                    Price = 15,
                    MenuID = menus.Single(m => m.Name == "Salad").MenuID,
                    RestaurantID = restaurants.Single(r => r.Name == "Kebab Centar").RestaurantID
                },
                new Food { 
                    Name = "Peèena patka", 
                    Price = 15,
                    MenuID = menus.Single(m => m.Name == "Grill").MenuID,
                    RestaurantID = restaurants.Single(r => r.Name == "Kineski Restoran Li-Mun").RestaurantID
                },
                new Food { 
                    Name = "Salata od bambusa", 
                    Price = 15,
                    MenuID = menus.Single(m => m.Name == "Salad").MenuID,
                    RestaurantID = restaurants.Single(r => r.Name == "Kineski Restoran Li-Mun").RestaurantID
                },
                new Food { 
                    Name = "Ljuti odrezak s kukuruzom", 
                    Price = 15,
                    MenuID = menus.Single(m => m.Name == "Grill").MenuID,
                    RestaurantID = restaurants.Single(r => r.Name == "Mexican Restaurant Sanchez").RestaurantID
                },
                new Food { 
                    Name = "Pileæa rebarca u ljutom umaku", 
                    Price = 15,
                    MenuID = menus.Single(m => m.Name == "Grill").MenuID,
                    RestaurantID = restaurants.Single(r => r.Name == "Mexican Restaurant Sanchez").RestaurantID
                },
                new Food { 
                    Name = "Kukuruzna salata s ljutim umakom", 
                    Price = 15,
                    MenuID = menus.Single(m => m.Name == "Salad").MenuID,
                    RestaurantID = restaurants.Single(r => r.Name == "Mexican Restaurant Sanchez").RestaurantID
                },

            };
            foods.ForEach(s => context.Foods.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

        }

        void AddOrUpdateFood(CateringContext context, string restaurantName, string foodName)
        {
            var rest = context.Restaurants.SingleOrDefault(r => r.Name == restaurantName);
            var food = rest.Foods.SingleOrDefault(f => f.Name == foodName);
            if (food == null)
            {
                rest.Foods.Add(context.Foods.Single(f => f.Name == foodName));
            }
        }
    }
}
