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
    public class TownController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public TownController()
            : this(new UnitOfWork())
        {
        }

        public TownController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /Order/

        public ViewResult Index(string searchString, string sortOrder, string currentFilter, bool showAllRestaurants = false)
        {
            var viewModel = new TownIndex();
            //viewModel.Towns = _db.Towns
            //    .Include("Restaurants");
            viewModel.Towns = _unitOfWork.TownRepository.Get();

            ViewBag.ShowAllRestaurants = showAllRestaurants;

            if (showAllRestaurants)
            {
                ViewBag.SortNameParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

                if (searchString == null)
                    searchString = currentFilter;

                ViewBag.CurrentFilter = searchString;

                viewModel.Restaurants = _unitOfWork.RestaurantRepository.Get();

                switch (sortOrder)
                {
                    case "name_desc":
                        viewModel.Restaurants = viewModel.Restaurants.OrderByDescending(r => r.Name);
                        break;
                    default:
                        viewModel.Restaurants = viewModel.Restaurants.OrderBy(r => r.Name);
                        break;
                }

                // we will set showAllRestaurants = true but will filter them
                // by searchString if there is any searchString
                if (!String.IsNullOrEmpty(searchString))
                {
                    viewModel.Restaurants = viewModel.Restaurants.Where(r => r.Name.ToUpper().Contains(searchString.ToUpper()));
                }
            }

            return View(viewModel);
        }

        //
        // GET: /Town/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Town/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Town town)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TownRepository.Insert(town);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(town);
        }

        //
        // GET: /Town/Edit/5

        public ActionResult Edit(int id)
        {
            Town town = _unitOfWork.TownRepository.GetByID(id);
            return View(town);
        }

        //
        // POST: /Town/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Town town)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TownRepository.Update(town);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(town);
        }

        //
        // GET: /Town/Delete/5

        public ActionResult Delete(int id)
        {
            Town town = _unitOfWork.TownRepository.GetByID(id);
            return View(town);
        }

        //
        // POST: /Town/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.TownRepository.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}