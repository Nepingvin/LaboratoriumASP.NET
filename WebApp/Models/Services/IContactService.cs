namespace WebApp.Models.Services
{
    public interface IContactService
    {
        void Add(ContactModel model);
        void Delete(int id);
        void Update(ContactModel model);
        List<ContactModel> GetAll();
        ContactModel? GetById(int id);

    }
}
