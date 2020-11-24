using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PhoneBook.DataAccess.Models;

namespace PhoneBook.DataAccess.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _db;

        public UnitOfWork(DbContext db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public T GetRepository<T>() where T : class, IRepository
        {
            if (typeof(T) == typeof(IContactRepository))
            {
                return new ContactRepository(_db) as T;
            }

            throw new Exception("Неизвестный тип репозитория:" + typeof(T));
        }
    }
}