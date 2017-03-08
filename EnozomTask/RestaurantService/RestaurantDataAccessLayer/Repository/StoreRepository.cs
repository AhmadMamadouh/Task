using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantDataAccessLayer.IRepository;


namespace RestaurantDataAccessLayer.Repository
{
   public class StoreRepository:RepositoryBase<Helper.Store>,IStoreRepository
    {
       private Helper.FoodCourtContext context;
       public StoreRepository(Helper.FoodCourtContext datacontext)
           : base(datacontext)
       {
           context = datacontext;
       }

       public IQueryable<Helper.Store> FindStoreById(int Id)
       {
           return context.Store.Where(m => m.StoreId == Id);
       }

       public void UpdateStore(Helper.Store UpdatedStore)
       {
           Helper.Store Store = FindStoreById(UpdatedStore.StoreId).FirstOrDefault();
           Store.StoreName = UpdatedStore.StoreName;
           Store.StoreLogo = UpdatedStore.StoreLogo;
           Store.StoreDescription = UpdatedStore.StoreDescription;
           context.SaveChanges();
       }

    }
}
