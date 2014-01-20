using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CateringApplication.Models;
using CateringApplication.DAL;
using CateringApplication.DAL.Repository;
using CateringApplication.ViewModels;

namespace CateringApplication.Controllers
{
    public class FoodController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public FoodController()
            : this(new UnitOfWork())
        {
        }

        public FoodController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /RestaurantName/Food

        public ViewResult Index(string restaurantName)
        {
            // initialize viewModel
            var viewModel = new FoodIndex();

            viewModel.Restaurant = restaurantName;

            viewModel.Foods = _unitOfWork.FoodRepository.Get(
                filter: f => f.Restaurant.Name == restaurantName);

            // initialize empty List so we can add Menus
            // maybe we dont have all menus for this restaurant
            // so we dont use _unitOfWork.MenuRepository.Get()
            viewModel.Menus = new List<Menu>();
            foreach (Food food in viewModel.Foods)
            {
                if (!viewModel.Menus.Contains(food.Menu))
                {
                    viewModel.Menus.Add(food.Menu);
                }
            }

            // order menus to always have same order
            viewModel.Menus = viewModel.Menus.OrderBy(m => m.Name).ToList();

            return View(viewModel);
        }

  

        //
        // GET: /Food/Create

        public ActionResult Create(string restaurantName)
        {
            var restaurant = _unitOfWork.RestaurantRepository.Get(
                filter: r => r.Name == restaurantName).FirstOrDefault();

            Food food = new Food();
            food.Restaurant = restaurant;
            food.RestaurantID = restaurant.RestaurantID;

            PopulateMenuDropDownList();
            return View(food);
        }

        //
        // POST: /Food/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Food food)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.FoodRepository.Insert(food);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

           
            PopulateMenuDropDownList(food.MenuID);

            return View(food);
        }

        //
        // GET: /Restaurant/Edit/5

        public ActionResult Edit(int id)
        {
            Food food = _unitOfWork.FoodRepository.GetByID(id);
            PopulateMenuDropDownList(food.Menu.MenuID);
            return View(food);
        }

        //
        // POST: /Restaurant/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Food food)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.FoodRepository.Update(food);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(food);
        }

        //
        // GET: /Restaurant/Delete/5

        public ActionResult Delete(int id)
        {
            Food food = _unitOfWork.FoodRepository.GetByID(id);
            return View(food);
        }

        //
        // POST: /Restaurant/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.FoodRepository.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        private void PopulateMenuDropDownList(object selectedMenu = null)
        {
            var menus = _unitOfWork.MenuRepository.Get();
 
            ViewBag.MenuID = new SelectList(menus, "MenuID", "Name", selectedMenu);
        }

        //
        // GET: /Food/CreateMenu

        public ActionResult CreateMenu()
        {
            return View();
        }

        //
        // POST: /Food/CreateMenu

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMenu(Menu menu)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MenuRepository.Insert(menu);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}