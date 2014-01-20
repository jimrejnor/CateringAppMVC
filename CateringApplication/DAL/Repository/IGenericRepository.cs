using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CateringApplication.DAL.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Delete(object id);
        void Update(TEntity entity);

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetByID(object id);

    }
}
