using System.Collections.Generic;
using System.Linq;
using PhoneBook.Contracts;
using PhoneBook.DataAccess.Models;

namespace PhoneBook.BusinessLogic.Mapping
{
    public static class MappingExtensions
    {
        public static ContactDto ToDto(this Contact contact)
        {
            return new ContactDto
            {
                Id = contact.Id,
                Surname = contact.Surname,
                Name = contact.Name,
                Phone = contact.Phone
            };
        }

        public static Contact ToModel(this ContactDto contactDto)
        {
            return new Contact
            {
                Id = contactDto.Id,
                Surname = contactDto.Surname,
                Name = contactDto.Name,
                Phone = contactDto.Phone
            };
        }

        public static List<ContactDto> ToDtoList(this List<Contact> contactsList)
        {
            return contactsList.Select(c => c.ToDto()).ToList();
        }
    }
}