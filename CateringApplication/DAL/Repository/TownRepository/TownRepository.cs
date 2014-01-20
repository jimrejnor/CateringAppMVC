using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CateringApplication.Models;

namespace CateringApplication.DAL.Repository
{
    public class TownRepository : GenericRepository<Town>, ITownRepository
    {
        public TownRepository(CateringContext context)
            : base(context)
        {
            
        }
    }
}