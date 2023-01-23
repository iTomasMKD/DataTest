using HackerDataTest.Models;
using HackerDataTest.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HackerDataTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IItemService itemService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _itemService = itemService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            //no good practice for implement buisness logic or call directly repository
            //List<Item> items = new List<Item>();
            //items = await _itemService.GetHackerData(id);
            //return View(items);

            //clean solution to call service
            if (id == null)
            {
                _logger.LogError("Object sent from the frontend is null.");
                return BadRequest("Object sent from the frontend is null.");
            }
            var result = await _itemService.GetHackerData(id);
            return View(result);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}