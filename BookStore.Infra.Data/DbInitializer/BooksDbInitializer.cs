using BookStore.Domain.Entities;
using BookStore.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Infra.Data.DbInitializer
{
    public static class BooksDbInitializer
    {
            public static void Seed(BookStoreContext context)
            {
                if (!context.Books.Any())
                {
                context.AddRange
                    (

                             new Book
                             {
                                 Isbn = "9781593275848",
                                 Title = "Clean Code: A Handbook of Agile Software Craftsmanship",
                                 ShortDescription = "Clean Code: A Handbook of Agile Software Craftsmanship",
                                 PublicationYear = 2000,
                                 Publisher = "New Publisher",
                                 Price = 28_63,
                                 AvailableStock = 1,
                                 IsBestSeller = true,
                                 CreateDate = DateTime.Now
                             },
                             new Book
                             {
                                 Isbn = "9781593275847",
                                 Title = "A Game of Thrones: A Song of Ice and Fire, Book 1",
                                 ShortDescription = "A Game of Thrones: A Song of Ice and Fire, Book 1",
                                 PublicationYear = 2003,
                                 Publisher = "New Publisher",
                                 Price = 29_99,
                                 AvailableStock = 1,
                                 IsBestSeller = true,
                                 CreateDate = DateTime.Now
                             },

                             new Book
                             {
                                 Isbn = "9781593275846",
                                 Title = "Eloquent JavaScript, Second Edition",
                                 ShortDescription = "JavaScript lies at the heart of almost every modern web application, from social apps to the newest browser-based games. Though simple for beginners to pick up and play with, JavaScript is a flexible, complex language that you can use to build full-scale applications.",
                                 PublicationYear = 2019,
                                 Publisher = "No Starch Press",
                                 Price = 100_00,
                                 AvailableStock = 1,
                                 IsBestSeller = true,
                                 CreateDate = DateTime.Now
                             },

                             new Book
                             {
                                 Isbn = "9781449331818",
                                 Title = "Learning JavaScript Design Patterns",
                                 ShortDescription = "With Learning JavaScript Design Patterns, you'll learn how to write beautiful, structured, and maintainable JavaScript by applying classical and modern design patterns to the language. If you want to keep your code efficient, more manageable, and up-to-date with the latest best practices, this book is for you.",
                                 PublicationYear = 1999,
                                 Publisher = "O'Reilly Media",
                                 Price = 09_99,
                                 AvailableStock = 0,
                                 IsBestSeller = true,
                                 CreateDate = DateTime.Now

                             }

                    );
                    var output = context.SaveChanges();
                    var output1 = output;
                }
            }
        }
    }