using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using BookStore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Infra.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        public BookRepository(BookStoreContext context)
        {
            _db = context;
            _dbSet = _db.Set<Book>();
        }

        private readonly BookStoreContext _db;
        private readonly DbSet<Book> _dbSet;


        public virtual void Add(Book book)
        {
            _dbSet.Add(book);
        }

        public Book GetByIsbn(string isbn)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(x => x.Isbn == isbn);
        }

        public virtual IEnumerable<Book> GetAll()
        {
            return _dbSet;
        }

        public virtual void Update(Book book)
        {
            _db.Entry(book).State = EntityState.Modified;
            _dbSet.Update(book);
        }

        public virtual void Remove(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
