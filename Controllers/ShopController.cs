using Microsoft.AspNetCore.Mvc;
using Sklep_internetowy.ShopAppServices;

namespace Sklep_internetowy.Controllers
{
    public class ShopController : Controller
    {
        private readonly ShopAppService _shopAppService;
        public ShopController(ShopAppService shopAppService)
        {
            _shopAppService = shopAppService;
        }
        public IActionResult Index()
        {
            var model = _shopAppService.GetAll();
            return View(model);
        }
        public IActionResult Details(long id)
        {

            var model = _shopAppService.GetElementById(id);
            return View(model);
        }
    }
}
