using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CateringApplication.Models;


namespace CateringApplication.DAL.Repository
{
    public interface IUnitOfWork 
    {
        CateringContext Context { get; set; }

        IGenericRepository<Food> FoodRepository { get; }
        IGenericRepository<Menu> MenuRepository { get; }
        IGenericRepository<Restaurant> RestaurantRepository { get; }
        IGenericRepository<Town> TownRepository { get; }


        void Save();
        void Dispose();
    }
}