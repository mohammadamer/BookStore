using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Interfaces.Repository
{
    public interface IBookRepository
    {
        void Add(Book book);
        Book GetByIsbn(string isbn);
        IEnumerable<Book> GetAll();
        void Update(Book book);
        void Remove(int id);
        int SaveChanges();
    }
}
