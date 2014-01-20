using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CateringApplication.Models
{
    public class Town
    {
        public int TownID { get; set; }

        [Required]
        [Display(Name = "Town")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Food name cannot be above 50 or below 2 characters")]
        [Remote("DoesTownExist", "Validation", AdditionalFields = "EditInitial", ErrorMessage = "Town already exists")]
        public string Name { get; set; }

        [Display(Name = "Restaurant")]
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}