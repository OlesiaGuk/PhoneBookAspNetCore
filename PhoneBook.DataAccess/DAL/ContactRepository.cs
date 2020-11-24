using System.Linq;
using Microsoft.EntityFrameworkCore;
using PhoneBook.DataAccess.Models;

namespace PhoneBook.DataAccess.DAL
{
    public class ContactRepository : BaseEfRepository<Contact>, IContactRepository
    {
        public ContactRepository(DbContext db) : base(db)
        {
        }

        public void DeleteById(int id)
        {
            var contact = _dbSet.FirstOrDefault(c => c.Id == id);

            Delete(contact);
        }
    }
}