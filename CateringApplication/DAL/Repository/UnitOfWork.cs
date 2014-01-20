using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CateringApplication.Models;

namespace CateringApplication.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public CateringContext Context { get; set; }

        private IGenericRepository<Food> _foodRepository;
        private IGenericRepository<Menu> _menuRepository;
        private IGenericRepository<Restaurant> _restaurantRepository;
        private IGenericRepository<Town> _townRepository;

        public UnitOfWork(CateringContext context)
        {
            Context = context;
        }

        public UnitOfWork()
        {
            Context = new CateringContext();
        }

        public IGenericRepository<Food> FoodRepository
        {
            get
            {
                if (_foodRepository == null)
                {
                    _foodRepository = new FoodRepository(Context);
                }
                return _foodRepository;
            }
        }

        public IGenericRepository<Restaurant> RestaurantRepository
        {
            get
            {
                if (_restaurantRepository == null)
                {
                    _restaurantRepository = new RestaurantRepository(Context);
                }
                return _restaurantRepository;
            }
        }

        public IGenericRepository<Town> TownRepository
        {
            get
            {
                if (_townRepository == null)
                {
                    _townRepository = new TownRepository(Context);
                }
                return _townRepository;
            }
        }

        public IGenericRepository<Menu> MenuRepository
        {
            get
            {
                if (_menuRepository == null)
                {
                    _menuRepository = new MenuRepository(Context);
                }
                return _menuRepository;
            }
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}