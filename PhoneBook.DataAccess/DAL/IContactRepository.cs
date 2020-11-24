using PhoneBook.DataAccess.Models;

namespace PhoneBook.DataAccess.DAL
{
    public interface IContactRepository : IRepositoryBase<Contact>
    {
        public void DeleteById(int id);
    }
}