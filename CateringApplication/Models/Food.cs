using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CateringApplication.Models
{
    public class Food
    {
        public int FoodID { get; set; }
        public int MenuID { get; set; }
        public int RestaurantID { get; set; }

        [Required]
        [Display(Name = "Food Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Food name cannot be above 50 or below 2 characters")]
        [Remote("DoesFoodExist", "Validation", AdditionalFields = "RestaurantName, EditInitial", ErrorMessage = "Food already exists in this restaurant")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency, ErrorMessage = "Fill in a valid currency")]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        /* image 
        public byte[] Photo { get; set; }
        public string PhotoContentType { get; set; } */

        public virtual Menu Menu { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}