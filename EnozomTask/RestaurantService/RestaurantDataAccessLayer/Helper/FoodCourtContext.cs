using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDataAccessLayer.Helper
{
   public class FoodCourtContext :DbContext
    {

       public FoodCourtContext()
           : base("name=FoodCourtContext")
        {
        }


       public virtual DbSet<Store> Store { get; set; }

    }
}
