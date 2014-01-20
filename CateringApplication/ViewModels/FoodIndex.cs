using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CateringApplication.Models;

namespace CateringApplication.ViewModels
{
    public class FoodIndex
    {
        public IEnumerable<Food> Foods { get; set; }
        public IList<Menu> Menus { get; set; }
        public string Restaurant { get; set; }
    }
}