using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant_app_backend.DbModels
{
    public class Food : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
