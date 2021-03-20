using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant_app_backend.DbModels
{
    public class Restaurant : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Category { get; set; }
        public int DeliveryPrice { get; set; }
        public float DeliveryTime { get; set; }
    }
}
