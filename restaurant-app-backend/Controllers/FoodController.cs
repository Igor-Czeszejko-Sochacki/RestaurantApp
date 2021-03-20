using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using restaurant_app_backend.DbModels.Request;
using restaurant_app_backend.Service;

namespace restaurant_app_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFood(NewFoodVM newFoodVM)
        {
            var result = await _foodService.AddFood(newFoodVM);
            if (result.Response != null)
                return BadRequest(result);
            return Ok("Food was added");
        }

        [HttpPatch]
        public async Task<IActionResult> PatchFood(int foodId, NewFoodVM newFoodVM)
        {
            var result = await _foodService.PatchFood(foodId, newFoodVM);
            if (result.Response != null)
                return BadRequest("Food does not exist");
            return Ok("Food was patched");
        }


        [HttpGet]
        public async Task<IActionResult> GetAllFood()
        {
            var foodList = await _foodService.GetAllFood();
            if (foodList == null)
                return BadRequest("No food to show");
            return Ok(foodList);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFood(int foodId)
        {
            var result = await _foodService.DeleteFood(foodId);
            if (result.Response != null)
                return BadRequest("Food does not exist");
            return Ok("Food was deleted");
        }
    }
}
