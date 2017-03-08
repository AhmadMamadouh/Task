using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RestaurantDataAccessLayer.Helper
{
   public class Store
    {
       [Key]
        public int StoreId { get; set; }
       [Required]
        public string StoreName { get; set; }
       [Required]
        public string StoreDescription { get; set; }
    
        public string StoreLogo { get; set; }

    }
}
