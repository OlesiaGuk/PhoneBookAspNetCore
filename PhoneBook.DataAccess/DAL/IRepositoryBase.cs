using System.Collections.Generic;

namespace PhoneBook.DataAccess.DAL
{
    public interface IRepositoryBase<T> : IRepository where T : class
    {
        void Add(T entity);

        void Update(T entity);

        public void Delete(T entity);

        List<T> GetAll();

        T GetById(int id);
    }
}