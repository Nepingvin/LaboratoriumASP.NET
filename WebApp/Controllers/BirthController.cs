using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Result(Birth model)
        {
            if (!model.isValid())
            {
                return View("Error");
            }
            return View(model);
        }
    }
}
