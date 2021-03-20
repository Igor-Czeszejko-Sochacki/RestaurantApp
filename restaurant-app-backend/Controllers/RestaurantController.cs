using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using restaurant_app_backend.DbModels.Response;
using restaurant_app_backend.Service;

namespace restaurant_app_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpPost]
        public async Task<IActionResult> AddRestaurant(NewRestaurantVM newRestaurantVM)
        {
            var result = await _restaurantService.AddRestaurant(newRestaurantVM);
            if (result.Response != null)
                return BadRequest(result);
            return Ok("Restaurant was added");
        }

        [HttpPatch]
        public async Task<IActionResult> PatchRestaurant(int restaurantId, NewRestaurantVM newRestaurantVM)
        {
            var result = await _restaurantService.PatchRestaurant(restaurantId, newRestaurantVM);
            if (result.Response != null)
                return BadRequest("Restaurant does not exist");
            return Ok("Restaurant was patched");
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var restaurantList = await _restaurantService.GetAllRestaurants();
            if (restaurantList == null)
                return BadRequest("No restaurants to show");
            return Ok(restaurantList);
        }

    }
}
