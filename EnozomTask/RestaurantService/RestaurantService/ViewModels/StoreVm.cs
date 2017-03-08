using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantService.ViewModels
{
    public class StoreVm
    {
        public int StoreId { get; set; }

        public string StoreName { get; set; }

        public string StoreDescription { get; set; }

        public string StoreLogo { get; set; }
    }
}