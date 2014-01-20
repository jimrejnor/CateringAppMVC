using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CateringApplication.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        public int TownID { get; set; }

        [Required]
        [Display(Name = "Restaurant name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Menu cannot be above 50 or below 2 characters")]
        [Remote("DoesRestaurantExist", "Validation", AdditionalFields = "TownName, EditInitial", ErrorMessage = "Restaurant already exists in this town")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Address")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Menu cannot be above 50 or below 2 characters")]
        public string Address { get; set; }

        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string  PhoneNumber { get; set; }

        public virtual ICollection<Food> Foods { get; set; }

        [Display(Name = "Town")]
        public virtual Town Town { get; set; }
    }
}