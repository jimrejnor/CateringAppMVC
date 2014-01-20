using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CateringApplication.Models;

namespace CateringApplication.ViewModels
{
    public class TownIndex
    {
        public IEnumerable<Town> Towns { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}