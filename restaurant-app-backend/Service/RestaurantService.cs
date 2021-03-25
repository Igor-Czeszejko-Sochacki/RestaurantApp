using restaurant_app_backend.DbModels;
using restaurant_app_backend.DbModels.Request;
using restaurant_app_backend.DbModels.Response;
using restaurant_app_backend.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant_app_backend.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository<Restaurant> _restaurantRepo;

        public RestaurantService(IRepository<Restaurant> restaurantRepo)
        {
            _restaurantRepo = restaurantRepo;
        }

        public async Task<ResultDTO> AddRestaurant(NewRestaurantVM newRestaurantVM)
        {
            var result = new ResultDTO()
            {
                Response = null
            };
            try
            {
                var restaurant = (new Restaurant
                {
                    Name = newRestaurantVM.Name,
                    Description = newRestaurantVM.Description,
                    Category = newRestaurantVM.Category,
                    DeliveryPrice = newRestaurantVM.DeliveryPrice,
                    DeliveryTime = newRestaurantVM.DeliveryTime
                });
                await _restaurantRepo.Add(restaurant);
            }
            catch (Exception e)
            {
                result.Response = e.Message;
                return result;
            }
            return result;
        }

        public async Task<ResultDTO> PatchRestaurant(int restaurantId, NewRestaurantVM newRestaurantVm)
        {
            var result = new ResultDTO()
            {
                Response = null
            };

            try
            {
                var restaurant = await _restaurantRepo.GetSingleEntity(x => x.Id == restaurantId);
                if (restaurant == null)
                    result.Response = "Restaurant does not exits";
                if (newRestaurantVm.Name != null)
                    restaurant.Name = newRestaurantVm.Name;
                if (newRestaurantVm.Description != null)
                    restaurant.Description = newRestaurantVm.Description;
                if (newRestaurantVm.Category != null)
                    restaurant.Category = newRestaurantVm.Category;
                if (newRestaurantVm.DeliveryPrice != null)
                    restaurant.DeliveryPrice = newRestaurantVm.DeliveryPrice;
                if (newRestaurantVm.DeliveryTime != null)
                    restaurant.DeliveryTime = newRestaurantVm.DeliveryTime;
                await _restaurantRepo.Patch(restaurant);

            }
            catch (Exception e)
            {
                result.Response = e.Message;
                return result;
            }
            return result;

        }


        public async Task<RestaurantListDTO> GetAllRestaurants()
        {
            var restaurantList = new RestaurantListDTO()
            {
                RestaurantList = await _restaurantRepo.GetAll()
            };
            return restaurantList;
        }

        public async Task<RestaurantListDTO> GetRestaurantsByType(string type)
        {
            var restaurantList = new RestaurantListDTO()
            {
                RestaurantList = await _restaurantRepo.GetAll()
            };

            var filteredRestaurantList = new List<Restaurant>();

            foreach (Restaurant restaurant in restaurantList.RestaurantList)
            {
                if (restaurant.Category == type)
                    filteredRestaurantList.Add(restaurant);
            }
            restaurantList.RestaurantList = filteredRestaurantList;
            return restaurantList;
        }

        public async Task<ResultDTO> DeleteRestaurant(int restaurantId)
        {
            var result = new ResultDTO()
            {
                Response = null
            };
            try
            {
                var restaurant = await _restaurantRepo.GetSingleEntity(x => x.Id == restaurantId);
                if (restaurant == null)
                    result.Response = "Restaurant not found";
                else
                   await _restaurantRepo.Delete(restaurant);
            }
            catch (Exception e)
            {
                result.Response = e.Message;
                return result;
            }
            return result;
        }
    }
}
