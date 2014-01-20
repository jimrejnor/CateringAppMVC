using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CateringApplication.Models;

namespace CateringApplication.DAL.Repository
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        public MenuRepository(CateringContext context)
            : base(context)
        {
            
        }
    }
}