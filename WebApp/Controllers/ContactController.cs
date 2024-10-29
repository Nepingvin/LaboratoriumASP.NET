using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ContactController : Controller
    {
        private static int currentId = 3;
        private static Dictionary<int, ContactModel> _contacts = new()
        {
            {
                1,
                new ContactModel ()
                {
                    Id = 1,
                    FirstName = "Foo",
                    LastName = "Bar",
                    Email = "foobar@gmail.com",
                    PhoneNumber = "123 456 789",
                    BirthDate = new DateOnly(2003, 10, 10)
                }
            },
            {
                2,
                new ContactModel ()
                {
                    Id = 2,
                    FirstName = "Adam",
                    LastName = "Nowicki",
                    Email = "nowicki@gmail.com",
                    PhoneNumber = "111 222 333",
                    BirthDate = new DateOnly(2000, 02, 11)
                }
            },
            {
                3,
                new ContactModel ()
                {
                    Id = 3,
                    FirstName = "Lukasz",
                    LastName = "Niewiadomy",
                    Email = "lukasz123@gmail.com",
                    PhoneNumber = "101 252 233",
                    BirthDate = new DateOnly(1998, 06, 01)
                }
            }
        };

        // lista kontaktow, przycisk dodawania
        public IActionResult Index()
        {
            return View(_contacts);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ContactModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            model.Id = ++currentId;
            _contacts.Add(model.Id, model);

            return View("Index", _contacts);
        }

        public IActionResult Delete(int id)
        {
            _contacts.Remove(id);

            return View("Index", _contacts);
        }

        
    }
}
