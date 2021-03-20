using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant_app_backend.DbModels.Response
{
    public class NewRestaurantVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int DeliveryPrice { get; set; }
        public float DeliveryTime { get; set; }
    }
}
