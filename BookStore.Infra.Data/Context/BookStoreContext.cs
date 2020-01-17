using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookStore.Infra.Data.Context
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options){ }

        public DbSet<Book> Books { get; set; }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    //builder.ApplyConfiguration(new BookConfiguration());
            
        //}
    }
}
