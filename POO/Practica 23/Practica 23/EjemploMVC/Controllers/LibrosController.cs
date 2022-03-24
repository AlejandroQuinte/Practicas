using Microsoft.AspNetCore.Mvc;

namespace EjemploMVC.Controllers {
    public class LibrosController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
