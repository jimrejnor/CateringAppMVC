using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CateringApplication.DAL.Repository;

namespace CateringApplication.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidationController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public ValidationController()
            : this(new UnitOfWork())
        {
        }

        public ValidationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //
        // GET: /Validation/

        public ActionResult Index()
        {
            return View();
        }

        // check whether food exists in current restaurant,
        // if so show validation errorMessage
        // @param string Name is Food.Name
        public JsonResult DoesFoodExist(string Name, string RestaurantName, string EditInitial)
        {
            // @param string EditInitial is used to check validation in editing form.
            // If we start editing name field e.g. "Cevapi", change it to something
            // and then back to "Cevapi" we would get validation error that food name
            // already exists in database and that we can't save that edit 
            if (Name == EditInitial)
            {
                // if name textfield is set back to initial edit text we don't show error
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            var food = _unitOfWork.FoodRepository.Get(
                filter: f => f.Name == Name &&
                             f.Restaurant.Name == RestaurantName);

            return Json(food.Count() == 0, JsonRequestBehavior.AllowGet);
        }

        // check whether restaurant exists in current town,
        // if so show validation errorMessage
        // @param string Name is Restaurant.Name
        public JsonResult DoesRestaurantExist(string Name, string TownName, string EditInitial)
        {
            // @param string EditInitial explained in "DoesFoodExist" function
            if (Name == EditInitial)
            {
                // if name textfield is set back to initial edit text we don't show error
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            var restaurant = _unitOfWork.RestaurantRepository.Get(
                filter: r => r.Name == Name &&
                             r.Town.Name == TownName);

            return Json(restaurant.Count() == 0, JsonRequestBehavior.AllowGet);
        }

        // check whether Town with given name exists
        // if so show validation errorMessage
        // @param string Name is Food.Name
        public JsonResult DoesTownExist(string Name, string EditInitial)
        {
            // @param string EditInitial explained in "DoesFoodExist" function
            if (Name == EditInitial)
            {
                // if name textfield is set back to initial edit text we don't show error
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            var town = _unitOfWork.TownRepository.Get(
                filter: t => t.Name == Name);

            return Json(town.Count() == 0, JsonRequestBehavior.AllowGet);
        }

        // check whether Menu with given name exists
        // if so show validation errorMessage
        // @param string Name is Menu.Name
        public JsonResult DoesMenuExist(string Name)
        {
            var menu = _unitOfWork.MenuRepository.Get(
                filter: m => m.Name == Name);

            return Json(menu.Count() == 0, JsonRequestBehavior.AllowGet);
        }
    }
}
