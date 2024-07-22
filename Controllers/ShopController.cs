using Microsoft.AspNetCore.Mvc;
using Sklep_internetowy.ShopAppServices;

namespace Sklep_internetowy.Controllers
{
    public class ShopController : Controller
    {
        ShopAppService shopAppService = new ShopAppService();
        public IActionResult Index()
        {
            var model = shopAppService.GetAll();
            return View(model);
        }
        public IActionResult Details(long id)
        {

            var model = shopAppService.GetElementById(id);
            return View(model);
        }
    }
}
