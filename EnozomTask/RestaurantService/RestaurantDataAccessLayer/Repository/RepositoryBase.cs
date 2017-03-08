using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace RestaurantDataAccessLayer.Repository
{
    

        public class RepositoryBase<TEntity> :RestaurantDataAccessLayer.IRepository.IRepositoryBase<TEntity> where TEntity : class
        {
            private readonly Helper.FoodCourtContext _dbContext;

            public RepositoryBase(Helper.FoodCourtContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.CommandTimeout = 180;

        }

        public void Insert(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }
       
        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }



        }
    
}
