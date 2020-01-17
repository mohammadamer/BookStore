using AutoMapper;
using BookStore.API.ViewModels;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Mappers
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<BookViewModel, Book>();
            CreateMap<Book, BookViewModel>();
        }
    }
}
