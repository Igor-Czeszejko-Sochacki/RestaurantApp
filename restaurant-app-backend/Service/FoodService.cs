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
    public class FoodService : IFoodService
    {
        private readonly IRepository<Food> _foodRepo;
        private readonly IRepository<Restaurant> _restaurantRepo;

        public FoodService(IRepository<Food> foodRepo, IRepository<Restaurant> restaurantRepo)
        {
            _foodRepo = foodRepo;
            _restaurantRepo = restaurantRepo;
        }

        public async Task<ResultDTO> AddFood(NewFoodVM newFoodVM)
        {
            var result = new ResultDTO()
            {
                Response = null
            };
            try
            {
                Restaurant restaurant = await _restaurantRepo.GetSingleEntity(x => x.Id == newFoodVM.RestaurantId);

                var food = (new Food
                {
                    Name = newFoodVM.Name,
                    Description = newFoodVM.Description,
                    Price = newFoodVM.Price,
                    Restaurant = restaurant
                });
                await _foodRepo.Add(food);
            }
            catch (Exception e)
            {
                result.Response = e.Message;
                return result;
            }
            return result;
        }

        public async Task<ResultDTO> PatchFood(int foodId, NewFoodVM newFoodVM)
        {
            var result = new ResultDTO()
            {
                Response = null
            };

            try
            {
                var food = await _foodRepo.GetSingleEntity(x => x.Id == foodId);
                if (food == null)
                    result.Response = "Food does not exits";
                if (newFoodVM.Name != null)
                    food.Name = newFoodVM.Name;
                if (newFoodVM.Description != null)
                    food.Description = newFoodVM.Description;
                if (newFoodVM.Price != null)
                    food.Price = newFoodVM.Price;
                await _foodRepo.Patch(food);

            }
            catch (Exception e)
            {
                result.Response = e.Message;
                return result;
            }
            return result;

        }


        public async Task<FoodListDTO> GetAllFood()
        {
            var foodList = new FoodListDTO()
            {
                FoodList = await _foodRepo.GetAll()
            };
            return foodList;
        }

        public async Task<ResultDTO> DeleteFood(int foodId)
        {
            var result = new ResultDTO()
            {
                Response = null

            };
            try
            {
                var food = await _foodRepo.GetSingleEntity(x => x.Id == foodId);
                if (food == null)
                    result.Response = "Food not found";
                else
                    await _foodRepo.Delete(food);
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
