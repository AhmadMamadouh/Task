using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDataAccessLayer.IRepository
{
    public interface IStoreRepository
    {
        IQueryable<Helper.Store> FindStoreById(int  Id);
    }
}
