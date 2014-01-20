using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CateringApplication.Models
{
    public class Menu
    {
        public int MenuID { get; set; }

        [Required]
        [Display(Name = "Menu Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Menu cannot be above 50 or below 2 characters")]
        [Remote("DoesMenuExist", "Validation", ErrorMessage = "Menu already exists in MenuRepository")]
        public string Name { get; set; }
    }
    
}