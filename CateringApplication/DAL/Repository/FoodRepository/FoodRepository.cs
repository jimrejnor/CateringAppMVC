using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CateringApplication.Models;

namespace CateringApplication.DAL.Repository
{
    public class FoodRepository : GenericRepository<Food>, IFoodRepository
    {
        public FoodRepository(CateringContext context)
            : base(context)
        {
            
        }
    }
}