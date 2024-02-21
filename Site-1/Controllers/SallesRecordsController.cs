using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Site_1.Services;

namespace Site_1.Controllers
{
    public class SallesRecordsController : Controller
    {
        private readonly SallesRecordsService _salles; 
        public SallesRecordsController(SallesRecordsService service) {
            _salles = service;
        }    
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? min, DateTime? max)
        {
            if (!min.HasValue)
            {
                min = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!max.HasValue) {
                max = new DateTime(DateTime.Now.Year);
            }
            ViewData["minDate"] = min.Value.ToString("yyyy, MM, dd");
            ViewData["maxDate"] = max.Value.ToString("yyyy, MM, dd");
            var result = await _salles.FindByDateAsync(min, max); 
            return View(result);
        }
        public async Task<IActionResult> GroupingSearch(DateTime? min, DateTime? max)
        {
            if (!min.HasValue)
            {
                min = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!max.HasValue)
            {
                max = new DateTime(DateTime.Now.Year);
            }
            ViewData["minDate"] = min.Value.ToString("yyyy, MM, dd");
            ViewData["maxDate"] = max.Value.ToString("yyyy, MM, dd");
            var result = await _salles.FindByDateGroupingAsync(min, max);
            return View(result);
        }
    }
}
