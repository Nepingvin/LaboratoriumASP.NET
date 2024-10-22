using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController : Controller
{

    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1,
            new ContactModel()
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Kowalski",
                Email = "awa@wsei.wdu.pl",
                PhoneNumber = "111 111 111",
                BirthDate = new DateOnly(2003, 10, 10)

            }
        },
        {
            2,
            new ContactModel()
            {
                Id = 2,
                FirstName = "Adam",
                LastName = "Kowalski",
                Email = "",
                PhoneNumber = "",
                BirthDate = new DateOnly(2003, 10, 10)

            }
        },
        {
            3,
            new ContactModel()
            {
                Id = 3,
                FirstName = "Adam",
                LastName = "Kowalski",
                Email = "",
                PhoneNumber = "",
                BirthDate = new DateOnly(2003, 10, 10)

            }
        }

    };

    private static int currentId = 3;
    
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
        if (!ModelState.IsValid)
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