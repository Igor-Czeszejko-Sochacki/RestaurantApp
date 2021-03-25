using restaurant_app_backend.DbModels.Request;
using restaurant_app_backend.DbModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant_app_backend.Service
{
    public interface IRestaurantService
    {
        Task<ResultDTO> AddRestaurant(NewRestaurantVM newRestaurantVM);
        Task<ResultDTO> PatchRestaurant(int restaurantId, NewRestaurantVM newRestaurantVm);
        Task<RestaurantListDTO> GetAllRestaurants();
        Task<RestaurantListDTO> GetRestaurantsByType(string type);
        Task<ResultDTO> DeleteRestaurant(int restaurantId);
    }
}
