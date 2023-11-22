using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Controllers
{
    public class TaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
