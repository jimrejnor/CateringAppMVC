using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CateringApplication.Models;

namespace CateringApplication.DAL.Repository
{
    public class RestaurantRepository : GenericRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(CateringContext context)
            : base(context)
        {
            
        }
    }
}