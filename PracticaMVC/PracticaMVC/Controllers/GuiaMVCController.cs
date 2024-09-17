using Microsoft.AspNetCore.Mvc;

namespace PracticaMVC.Controllers
{
    public class GuiaMVCController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
