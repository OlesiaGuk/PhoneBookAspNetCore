using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.BusinessLogic.Mapping;
using PhoneBook.Contracts;
using PhoneBook.DataAccess;
using PhoneBook.DataAccess.DAL;

namespace PhoneBook.Controllers
{
    public class PhoneBookController : ControllerBase
    {
        private PhoneBookDbContext db;

        public PhoneBookController(PhoneBookDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpGet]
        public List<ContactDto> GetContacts()
        {
            using var uow = new UnitOfWork(db);
            var contactsRepo = uow.GetRepository<IContactRepository>();

            return contactsRepo.GetAll().ToDtoList();
        }

        [HttpPost]
        public bool AddContact(ContactDto contactDto)
        {
            using var uow = new UnitOfWork(db);
            var contactsRepo = uow.GetRepository<IContactRepository>();

            contactsRepo.Add(contactDto.ToModel());
            uow.Save();

            return true;
        }

        [HttpPost]
        public bool DeleteContact(int id)
        {
            using var uow = new UnitOfWork(db);
            var contactsRepo = uow.GetRepository<IContactRepository>();

            contactsRepo.DeleteById(id);
            uow.Save();

            return true;
        }
    }
}
