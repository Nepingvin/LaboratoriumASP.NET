
namespace WebApp.Models.Services
{
    public class MemoryContactService : IContactService
    {
        private int currentId = 3;
        private Dictionary<int, ContactModel> _contacts = new()
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
                    BirthDate = new DateOnly(2003, 10, 10),
                    Category = Category.Business
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
                    BirthDate = new DateOnly(2000, 02, 11),
                    Category = Category.Family
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
                    BirthDate = new DateOnly(1998, 06, 01),
                    Category = Category.Friend
                }
            }
        };
        public void Add(ContactModel model)
        {
            model.Id = ++currentId;
            _contacts.Add(model.Id, model);
        }

        public void Delete(int id)
        {
            _contacts.Remove(id);
        }

        public List<ContactModel> GetAll()
        {
            return _contacts.Values.ToList();
        }

        public ContactModel? GetById(int id)
        {
            return _contacts[id];
        }

        public void Update(ContactModel model)
        {
            if(_contacts.ContainsKey(model.Id))
            {
                _contacts[model.Id] = model;
            }
        }
    }
}
