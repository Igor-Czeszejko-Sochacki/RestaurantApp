using restaurant_app_backend.DbModels.Request;
using restaurant_app_backend.DbModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant_app_backend.Service
{
    public interface IFoodService
    {
        Task<ResultDTO> AddFood(NewFoodVM newFoodVM);
        Task<ResultDTO> PatchFood(int foodId, NewFoodVM newFoodVm);
        Task<FoodListDTO> GetAllFood();
        Task<ResultDTO> DeleteFood(int foodId);
    }
}
