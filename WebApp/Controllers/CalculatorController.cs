using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: CalculatorController
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult Result(string op, double x, double y)
        {
            switch (op)
            {
                case "+":
                    ViewBag.Result = x + y;
                    break;
                case "-":
                    ViewBag.Result = x - y;
                    break;
                case "*":
                    ViewBag.Result = x * y;
                    break;
                case "/":
                    ViewBag.Result = x / y ;
                    break;
            }

            return View();
        }
        public IActionResult Form(string op, double x, double y)
        {
            return Result( op,  x,  y);
        }

    }
}
