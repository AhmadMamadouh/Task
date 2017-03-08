using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using RestaurantDataAccessLayer.Helper;


namespace RestaurantService.Controllers
{
   
    public class StoresController : ApiController
    {

        public IEnumerable<ViewModels.StoreVm> getAll()
        {

            using (FoodCourtContext db = new FoodCourtContext())
            {

                var store = new RestaurantDataAccessLayer.Repository.RepositoryBase<RestaurantDataAccessLayer.Helper.Store>(db);
                List<RestaurantDataAccessLayer.Helper.Store> StoreList = store.GetAll().ToList();
                List<ViewModels.StoreVm> ListOfStores = (from item in StoreList
                                                         select new ViewModels.StoreVm
                                                                  {
                                                                      StoreId = item.StoreId,
                                                                      StoreName = item.StoreName,
                                                                      StoreDescription = item.StoreDescription,
                                                                      StoreLogo = item.StoreLogo

                                                                  }).ToList();

                return ListOfStores;
            }
            
        }





        public string AddStore(ViewModels.StoreVm StoreVm)
        {
            using (FoodCourtContext db = new FoodCourtContext())
            {

                var store = new RestaurantDataAccessLayer.Repository.RepositoryBase<RestaurantDataAccessLayer.Helper.Store>(db);

                RestaurantDataAccessLayer.Helper.Store _Store = new RestaurantDataAccessLayer.Helper.Store();
                _Store.StoreName = StoreVm.StoreName;
                _Store.StoreLogo = StoreVm.StoreLogo;
                _Store.StoreDescription = StoreVm.StoreDescription;

                try
                {
                    store.Insert(_Store);
                    return "Store Added";

                }
                catch (Exception Ex)
                {
                    Logger.ExceptionLogger _ExLogger = new Logger.ExceptionLogger();
                    _ExLogger.RecordExceptionlog(Ex);
                    return "Problem occured while adding store";
                }
            }

        }

        public string PutStore(ViewModels.StoreVm StoreVm)
        {
            using (FoodCourtContext db = new FoodCourtContext())
            {


                var store = new RestaurantDataAccessLayer.Repository.StoreRepository(db);

                RestaurantDataAccessLayer.Helper.Store _Store = new RestaurantDataAccessLayer.Helper.Store();
                _Store.StoreId = StoreVm.StoreId;
                _Store.StoreName = StoreVm.StoreName;
                _Store.StoreLogo = StoreVm.StoreLogo;
                _Store.StoreDescription = StoreVm.StoreDescription;

                try
                {
                    store.UpdateStore(_Store);
                    return "Store Updated";

                }
                catch (Exception Ex)
                {
                    Logger.ExceptionLogger _ExLogger = new Logger.ExceptionLogger();
                    _ExLogger.RecordExceptionlog(Ex);
                    return "Problem occured while adding store";
                }
            }


        }


        public string DeleteStore(int StoreId)
        {

            using (FoodCourtContext db = new FoodCourtContext())
            {

                var store = new RestaurantDataAccessLayer.Repository.RepositoryBase<RestaurantDataAccessLayer.Helper.Store>(db);
                RestaurantDataAccessLayer.Helper.Store _Store = store.GetById(StoreId);


                try
                {
                    store.Delete(_Store);
                    return "Store Deleted";

                }
                catch (Exception Ex)
                {
                    Logger.ExceptionLogger _ExLogger = new Logger.ExceptionLogger();
                    _ExLogger.RecordExceptionlog(Ex);
                    return "Problem occured while Deleting store";
                }
            }

        }

    }
}
