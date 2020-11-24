using System;

namespace PhoneBook.DataAccess.DAL
{
    public interface IUnitOfWork:IDisposable
    {
        void Save();

        T GetRepository<T>() where T : class, IRepository;
    }
}